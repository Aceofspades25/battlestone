Public Class ctlFloor

    Dim tilePosition As Point = Nothing
    Dim tileSize As Size = Nothing
    Dim depthSizeL As Size = Nothing
    Dim depthPositionL As Point = Nothing
    'Dim depthSizeR As Size = Nothing
    'Dim depthPositionR As Point = Nothing
    Dim tileFile As String = ""
    Dim currentImage As Bitmap
    Dim obstacles As New ArrayList
    Dim bPreview As Boolean = False

    Dim dsTiles As DataSet  ' The Global DataSet which stores all tile data
    Dim floorID As String ' The ID for this particular Tile
    Dim nodeRef As TreeNode ' Stores a ref. to the treenode this was opened from

    Public Overrides Sub Save()
        ' When this control is browsed away from, save all the changes made to the global dataset (dsTiles)
        Dim flrRow As DataRow
        Try
            flrRow = dsTiles.Tables("Floor").Select("Floor_Id = " & floorID)(0)
        Catch ex As IndexOutOfRangeException
            ' If the index is out of range, the node has just been deleted and we don't need to save it
            Exit Sub
        End Try
        flrRow.Item("TileName") = Me.tbxTileName.Text
        flrRow.Item("TopLeft") = tilePosition
        flrRow.Item("Dimension") = tileSize
        flrRow.Item("TopLeftDepthL") = depthPositionL
        flrRow.Item("DimensionDepthL") = depthSizeL
        'flrRow.Item("TopLeftDepthR") = depthPositionR
        'flrRow.Item("DimensionDepthR") = depthSizeR
        flrRow.Item("ImageFile") = tileFile.Replace(My.Application.Info.DirectoryPath & "\", "")
        flrRow.Item("Group_Id") = ddlGroup.SelectedValue
        ' Now save the obstacles
        Dim obsRows() As DataRow = dsTiles.Tables("Obstacle").Select("Floor_Id = " & floorID)
        ' Delete all the previous rows
        For Each obsRow As DataRow In obsRows
            dsTiles.Tables("Obstacle").Rows.Remove(obsRow)
        Next
        ' Add the latest rows
        For Each obs As Point In obstacles
            Dim newRow As DataRow = dsTiles.Tables("Obstacle").NewRow()
            newRow.Item("Position") = obs
            newRow.Item("Floor_Id") = floorID
            dsTiles.Tables("Obstacle").Rows.Add(newRow)
        Next
        ' Now update the TreeNode that represents this structure
        nodeRef.Text = Me.tbxTileName.Text
        If nodeRef.Parent.Parent.Name <> ddlGroup.SelectedValue Then            
            Dim groupNode As TreeNode = nodeRef.TreeView.Nodes(0).Nodes(ddlGroup.SelectedValue.ToString())
            Dim targetNode As TreeNode = groupNode.Nodes(nodeRef.Parent.Name)
            ' If the current node is the selected one, de-select it, so that the following node doesn't get selected the moment this is removed
            If nodeRef.TreeView.SelectedNode Is nodeRef Then nodeRef.TreeView.SelectedNode = Nothing
            nodeRef.Remove()
            targetNode.Nodes.Add(nodeRef)
        End If
    End Sub

    Private Sub pnlPreview_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlPreview.Paint
        ' Translate to the scroll bar position
        e.Graphics.TranslateTransform(Me.pnlPreview.AutoScrollPosition.X, Me.pnlPreview.AutoScrollPosition.Y)
        ' Draw the pre-calculated image
        e.Graphics.DrawImage(currentImage, 0, 0)
    End Sub

    Private Sub ctlFloor_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        currentImage.Dispose()
        obstacles.Clear()
    End Sub

    Private Sub Draw_Image()
        If tileFile = "" Then
            currentImage = New Bitmap(pnlPreview.Width, pnlPreview.Height)
            Dim g As Graphics = Graphics.FromImage(currentImage)
            g.FillRectangle(Brushes.Black, 0, 0, currentImage.Width, currentImage.Height)
        Else
            Dim startPos As New Point((pnlPreview.Width - tileSize.Width) / 2, (pnlPreview.Height - tileSize.Height) / 2)
            Dim size As New Size(pnlPreview.Width, pnlPreview.Height)
            If (tileSize.Width > pnlPreview.Width) Then
                startPos.X = 0
                size.Width = tileSize.Width
            End If
            If (tileSize.Height + 16 > pnlPreview.Height) Then
                ' Add 16 for depth pieces
                startPos.Y = 0
                size.Height = tileSize.Height + 16
            End If
            ' currentImage stores what will currently be shown in the preview panel
            currentImage = New Bitmap(size.Width, size.Height)
            Dim g As Graphics = Graphics.FromImage(currentImage)
            g.FillRectangle(Brushes.Black, 0, 0, currentImage.Width, currentImage.Height)
            Dim bm As New Bitmap(tileFile)
            bm.MakeTransparent(Color.FromArgb(100, 255, 0, 255))
            g.DrawImage(bm, New Rectangle(startPos.X, startPos.Y, tileSize.Width, tileSize.Height), New Rectangle(tilePosition.X, tilePosition.Y, tileSize.Width, tileSize.Height), GraphicsUnit.Pixel)
            If Not depthSizeL = Nothing Then
                ' If a left depth image has been specified
                Dim tileLength As Integer = tileSize.Width / 64
                For i As Integer = 0 To tileLength - 1
                    g.DrawImage(bm, New Rectangle(startPos.X + (i * 32), startPos.Y + tileSize.Height / 2 + (i * 16), depthSizeL.Width, depthSizeL.Height), New Rectangle(depthPositionL.X, depthPositionL.Y, depthSizeL.Width, depthSizeL.Height), GraphicsUnit.Pixel)
                Next i
            End If
            If Not depthSizeL = Nothing Then
                ' If a left depth image has been specified
                Dim tileLength As Integer = tileSize.Width / 64
                Dim darkenedBM As Bitmap = MyGraphics.MultiplyChannels(bm, 0.6, New Rectangle(depthPositionL.X, depthPositionL.Y, depthSizeL.Width, depthSizeL.Height))
                For i As Integer = 0 To tileLength - 1
                    g.DrawImage(darkenedBM, New Rectangle(startPos.X + tileSize.Width / 2 + (i * 32), startPos.Y + tileSize.Height - (depthSizeL.Height / 2) - (i * 16), depthSizeL.Width, depthSizeL.Height), New Rectangle(darkenedBM.Width, 0, -darkenedBM.Width, darkenedBM.Height), GraphicsUnit.Pixel)
                Next i
            End If
        End If
    End Sub

    Private Sub ctlFloor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlPreview.AutoScrollMinSize = New Size(tileSize.Width, tileSize.Height + 16)
        Draw_Image()
        If tileSize.Width > pnlPreview.Width Or tileSize.Height + 16 > pnlPreview.Height Then
            bPreview = True
        Else
            bPreview = False
        End If
    End Sub

    Private Sub Populate_Obstacles()
        Me.dtgObstacles.Rows.Clear()
        For Each pt As Point In obstacles
            Dim strX As String = "Anchor"
            Dim strY As String = "Anchor"
            Select Case pt.X
                Case Is < 0
                    strX &= " - " & Math.Abs(pt.X)
                Case Is > 0
                    strX &= " + " & pt.X
            End Select

            Select Case CType(pt.Y, Integer)
                Case Is < 0
                    strY &= " - " & Math.Abs(pt.Y)
                Case Is > 0
                    strY &= " + " & pt.Y
            End Select

            Me.dtgObstacles.Rows.Add(strX, strY)
        Next
    End Sub

    Private Sub Populate_Groups(ByVal dt As DataTable)
        ddlGroup.DisplayMember = "GroupName"
        ddlGroup.ValueMember = "Group_Id"
        ddlGroup.DataSource = dt
    End Sub

    Private Sub btnSelectSprite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSprite.Click
        Dim frmSS As New SelectSprite()
        If frmSS.ShowDialog(Me) = DialogResult.OK Then
            tileFile = frmSS.ImageFile '.Replace(My.Application.Info.DirectoryPath & "\", "")
            tilePosition = frmSS.TileStart
            tileSize = frmSS.TileSize
            Me.tbxImageFile.Text = tileFile.Split("\")(tileFile.Split("\").Length - 1)
            Me.tbxTopLeft.Text = "(" & tilePosition.X & ", " & tilePosition.Y & ")"
            Me.tbxDimension.Text = tileSize.Width & " x " & tileSize.Height
            Draw_Image()
            If tileSize.Width > pnlPreview.Width Or tileSize.Height > pnlPreview.Height Then
                bPreview = True
            Else
                bPreview = False
            End If
            Me.pnlPreview.Invalidate()
        End If
    End Sub

    Private Sub btnSelectImageL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectImageL.Click
        If Not tileSize = Nothing Then
            ' They must first select the main tile before selecting the depth pieces
            Dim frmSS As New SelectSprite()
            frmSS.ImageFile = tileFile
            frmSS.SizeConstraint = New Size(32, 32) 'New Size(tileSize.Width / 2, Math.Ceiling(tileSize.Height / 32 / 2) * 32)
            If frmSS.ShowDialog(Me) = DialogResult.OK Then
                depthPositionL = frmSS.TileStart
                depthSizeL = frmSS.TileSize
                Me.tbxTopLeftL.Text = "(" & depthPositionL.X & ", " & depthPositionL.Y & ")"
                Me.tbxDimensionL.Text = depthSizeL.Width & " x " & depthSizeL.Height
                Draw_Image()
                Me.pnlPreview.Invalidate()
            End If
        End If
    End Sub

    'Private Sub btnSelectImageR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectImageR.Click
    '    If Not tileSize = Nothing Then
    '        ' They must first select the main tile before selecting the depth pieces
    '        Dim frmSS As New SelectSprite()
    '        frmSS.ImageFile = tileFile
    '        frmSS.SizeConstraint = New Size(32, 32) 'New Size(tileSize.Width / 2, Math.Ceiling(tileSize.Height / 32 / 2) * 32)
    '        If frmSS.ShowDialog(Me) = DialogResult.OK Then
    '            depthPositionR = frmSS.TileStart
    '            depthSizeR = frmSS.TileSize
    '            Me.tbxTopLeftR.Text = "(" & depthPositionR.X & ", " & depthPositionR.Y & ")"
    '            Me.tbxDimensionR.Text = depthSizeR.Width & " x " & depthSizeR.Height
    '            Draw_Image()
    '            Me.pnlPreview.Invalidate()
    '        End If
    '    End If
    'End Sub

    Private Sub pbPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbPreview.Click
        Dim frmPreview As New PreviewSprite()
        frmPreview.Image = currentImage
        frmPreview.MdiParent = Me.ParentForm.MdiParent
        frmPreview.Show()
    End Sub

    Private Sub pnlPreview_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles pnlPreview.Scroll
        pbPreview.Location = New Point(-pnlPreview.AutoScrollPosition.X / pnlPreview.AutoScrollMinSize.Height + 5, -pnlPreview.AutoScrollPosition.Y / pnlPreview.AutoScrollMinSize.Width + 5)
    End Sub

    Private Sub pnlPreview_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPreview.MouseEnter
        If bPreview Then
            pbPreview.Visible = True
            pbPreview.Image = My.Resources.Preview
        End If
    End Sub

    Private Sub pnlPreview_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPreview.MouseLeave
        If pbPreview.Visible Then
            pbPreview.Image = Nothing
        End If
    End Sub

    Private Sub pbPreview_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbPreview.MouseEnter
        pbPreview.Image = My.Resources.Preview
    End Sub

    Public Sub New(ByRef ds As DataSet, ByRef node As TreeNode)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        dsTiles = ds
        floorID = node.Name
        nodeRef = node
        '
        ' Set up the panel fields here
        '
        Populate_Groups(ds.Tables("Group"))
        Dim flrRow As DataRow = ds.Tables("Floor").Select("Floor_Id = " & floorID)(0)
        Me.ddlGroup.SelectedValue = flrRow.Item("Group_Id")
        Me.tbxTileID.Text = flrRow.Item("FloorID")
        Me.tbxTileName.Text = flrRow.Item("TileName")
        If Not flrRow.Item("TopLeft") Is Nothing AndAlso Not IsDBNull(flrRow.Item("TopLeft")) Then
            tilePosition = flrRow.Item("TopLeft")
            Me.tbxTopLeft.Text = "(" & tilePosition.X & ", " & tilePosition.Y & ")"
        End If
        If Not flrRow.Item("Dimension") Is Nothing AndAlso Not IsDBNull(flrRow.Item("Dimension")) Then
            tileSize = flrRow.Item("Dimension")
            Me.tbxDimension.Text = tileSize.Width & " x " & tileSize.Height
        End If

        If Not flrRow.Item("TopLeftDepthL") Is Nothing AndAlso Not IsDBNull(flrRow.Item("TopLeftDepthL")) Then
            depthPositionL = flrRow.Item("TopLeftDepthL")
            Me.tbxTopLeftL.Text = "(" & depthPositionL.X & ", " & depthPositionL.Y & ")"
        End If
        If Not flrRow.Item("DimensionDepthL") Is Nothing AndAlso Not IsDBNull(flrRow.Item("DimensionDepthL")) Then
            depthSizeL = flrRow.Item("DimensionDepthL")
            Me.tbxDimensionL.Text = depthSizeL.Width & " x " & depthSizeL.Height
        End If

        'If Not flrRow.Item("TopLeftDepthR") Is Nothing AndAlso Not IsDBNull(flrRow.Item("TopLeftDepthR")) Then
        '    depthPositionR = flrRow.Item("TopLeftDepthR")
        '    Me.tbxTopLeftR.Text = "(" & depthPositionR.X & ", " & depthPositionR.Y & ")"
        'End If
        'If Not flrRow.Item("DimensionDepthR") Is Nothing AndAlso Not IsDBNull(flrRow.Item("DimensionDepthR")) Then
        '    depthSizeR = flrRow.Item("DimensionDepthR")
        '    Me.tbxDimensionR.Text = depthSizeR.Width & " x " & depthSizeR.Height
        'End If

        If Not flrRow.Item("ImageFile") Is Nothing AndAlso Not IsDBNull(flrRow.Item("ImageFile")) AndAlso flrRow.Item("ImageFile") <> "" Then
            tileFile = My.Application.Info.DirectoryPath & "\" & flrRow.Item("ImageFile")
            Me.tbxImageFile.Text = tileFile.Split("\")(tileFile.Split("\").Length - 1)
        End If
        '
        ' Add the obstacles here
        '
        Dim obsts() As DataRow = ds.Tables("Obstacle").Select("Floor_Id = " & floorID)
        If obsts.Length > 0 Then
            For Each oRow As DataRow In obsts
                ' Duplicate this row into obstacles arraylist
                obstacles.Add(oRow.Item("Position"))
            Next
            Populate_Obstacles()
        End If
    End Sub

    Private Sub btnSelectObstacles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectObstacles.Click
        MessageBox.Show("This will definitely be needed, since we could have" & vbCrLf & "floor tiles that represent either a river or an ocean," & vbCrLf & "that shouldn't be walked over... Coming soon!", "Coming soon!")
    End Sub

    Private Sub btnNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotes.Click
        Dim frmNotes As New Notes()
        frmNotes.Section = Notes.Sections.FloorTiles
        frmNotes.MdiParent = Me.ParentForm.MdiParent
        frmNotes.Show()
    End Sub
End Class
