Public Class ctlWall

    Dim wallPositionLeft As Point = Nothing
    Dim wallPositionRight As Point = Nothing
    Dim wallSize As Size = Nothing
    Dim topDepthSize As Size = Nothing
    Dim topDepthPosition As Point = Nothing
    Dim tileFile As String = ""
    Dim currentImage As Bitmap
    Dim obstacles As New ArrayList
    Dim bPreview As Boolean = False
    Dim wallLength As Integer = 0

    Dim dsTiles As DataSet  ' The Global DataSet which stores all tile data
    Dim wallID As String ' The ID for this particular Tile
    Dim nodeRef As TreeNode ' Stores a ref. to the treenode this was opened from

    Public Overrides Sub Save()
        ' When this control is browsed away from, save all the changes made to the global dataset (dsTiles)
        Dim flrRow As DataRow
        Try
            flrRow = dsTiles.Tables("Wall").Select("Wall_Id = " & wallID)(0)
        Catch ex As IndexOutOfRangeException
            ' If the index is out of range, the node has just been deleted and we don't need to save it
            Exit Sub
        End Try
        flrRow.Item("TileName") = Me.tbxTileName.Text
        flrRow.Item("TopLeftLeft") = wallPositionLeft
        If cbxMirrored.Checked Then
            flrRow.Item("TopLeftRight") = System.DBNull.Value
        Else
            flrRow.Item("TopLeftRight") = wallPositionRight
        End If
        flrRow.Item("Dimension") = wallSize
        flrRow.Item("Mirrored") = cbxMirrored.Checked
        flrRow.Item("HasDepth") = cbxDepth.Checked
        flrRow.Item("Depth") = nudDepth.Value
        flrRow.Item("DepthTopLeft") = topDepthPosition
        flrRow.Item("DepthDimension") = topDepthSize
        'flrRow.Item("TopLeftDepthR") = depthPositionR
        'flrRow.Item("DimensionDepthR") = depthSizeR
        flrRow.Item("ImageFile") = tileFile.Replace(My.Application.Info.DirectoryPath & "\", "")
        flrRow.Item("Group_Id") = ddlGroup.SelectedValue
        '' Now save the obstacles
        'Dim obsRows() As DataRow = dsTiles.Tables("Obstacle").Select("Floor_Id = " & wallID)
        '' Delete all the previous rows
        'For Each obsRow As DataRow In obsRows
        '    dsTiles.Tables("Obstacle").Rows.Remove(obsRow)
        'Next
        '' Add the latest rows
        'For Each obs As Point In obstacles
        '    Dim newRow As DataRow = dsTiles.Tables("Obstacle").NewRow()
        '    newRow.Item("Position") = obs
        '    newRow.Item("Floor_Id") = wallID
        '    dsTiles.Tables("Obstacle").Rows.Add(newRow)
        'Next
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

    Private Sub Populate_Groups(ByVal dt As DataTable)
        ddlGroup.DisplayMember = "GroupName"
        ddlGroup.ValueMember = "Group_Id"
        ddlGroup.DataSource = dt
    End Sub

    Private Sub Draw_Image()
        If tileFile = "" Then
            currentImage = New Bitmap(pnlPreview.Width, pnlPreview.Height)
            Dim g As Graphics = Graphics.FromImage(currentImage)
            g.FillRectangle(Brushes.Black, 0, 0, currentImage.Width, currentImage.Height)
        Else
            Dim imgSize As New Size(wallSize.Width * 2 + 64, wallSize.Height + 16)
            Dim startPos As New Point((pnlPreview.Width - imgSize.Width) / 2, (pnlPreview.Height - imgSize.Height) / 2)
            Dim size As New Size(pnlPreview.Width, pnlPreview.Height)
            If (imgSize.Width > pnlPreview.Width) Then
                startPos.X = 32
                size.Width = imgSize.Width
            End If
            If (imgSize.Height > pnlPreview.Height) Then
                ' Add 8 for depth pieces
                startPos.Y = 16
                size.Height = imgSize.Height
            End If
            ' currentImage stores what will currently be shown in the preview panel
            currentImage = New Bitmap(size.Width, size.Height)
            Dim g As Graphics = Graphics.FromImage(currentImage)
            g.FillRectangle(Brushes.Black, 0, 0, currentImage.Width, currentImage.Height)
            Dim bm As New Bitmap(tileFile)
            bm.MakeTransparent(Color.FromArgb(100, 255, 0, 255))
            ' Draw the left wall
            If wallPositionLeft <> Nothing Then
                g.DrawImage(bm, New Rectangle(startPos.X, startPos.Y, wallSize.Width, wallSize.Height), New Rectangle(wallPositionLeft.X, wallPositionLeft.Y, wallSize.Width, wallSize.Height), GraphicsUnit.Pixel)
            End If
            ' Draw the right wall
            If wallPositionLeft <> Nothing And cbxMirrored.Checked Then
                ' the right wall mirrors the left
                'g.DrawImage(bm, New Rectangle(startPos.X + wallSize.Width, startPos.Y, wallSize.Width, wallSize.Height), New Rectangle(wallPositionLeft.X + wallSize.Width - 1, wallPositionLeft.Y, -wallSize.Width, wallSize.Height), GraphicsUnit.Pixel)
                Dim lightenedBM As Bitmap = MyGraphics.MultiplyChannels(bm, 1.7, New Rectangle(wallPositionLeft.X, wallPositionLeft.Y, wallSize.Width, wallSize.Height))
                g.DrawImage(lightenedBM, New Rectangle(startPos.X + wallSize.Width, startPos.Y, wallSize.Width, wallSize.Height), New Rectangle(lightenedBM.Width, 0, -lightenedBM.Width, wallSize.Height), GraphicsUnit.Pixel)
            ElseIf wallPositionRight <> Nothing Then
                ' the right wall doesn't mirror the left, it is specified
                g.DrawImage(bm, New Rectangle(startPos.X + wallSize.Width, startPos.Y, wallSize.Width, wallSize.Height), New Rectangle(wallPositionRight.X, wallPositionRight.Y, wallSize.Width, wallSize.Height), GraphicsUnit.Pixel)
            End If
            ' If there is depth
            If cbxDepth.Checked Then
                ' Draw the left wall depth
                If wallPositionLeft <> Nothing Then
                    If cbxMirrored.Checked Then
                        ' If it's a mirrored wall
                        Dim lightenedBM As Bitmap = MyGraphics.MultiplyChannels(bm, 1.6, New Rectangle(wallPositionLeft.X, wallPositionLeft.Y, nudDepth.Value, wallSize.Height))
                        g.DrawImage(lightenedBM, New Rectangle(startPos.X - nudDepth.Value, startPos.Y, nudDepth.Value, wallSize.Height), New Rectangle(lightenedBM.Width, 0, -lightenedBM.Width, wallSize.Height), GraphicsUnit.Pixel)
                    ElseIf wallPositionRight <> Nothing Then
                        g.DrawImage(bm, New Rectangle(startPos.X - nudDepth.Value, startPos.Y, nudDepth.Value, wallSize.Height), New Rectangle(wallPositionRight.X + wallSize.Width - nudDepth.Value, wallPositionRight.Y, nudDepth.Value, wallSize.Height), GraphicsUnit.Pixel)
                    End If
                End If
                ' Draw the right wall depth
                If (cbxMirrored.Checked Or wallPositionRight <> Nothing) And wallPositionLeft <> Nothing Then
                    g.DrawImage(bm, New Rectangle(startPos.X + wallSize.Width * 2, startPos.Y, nudDepth.Value, wallSize.Height), New Rectangle(wallPositionLeft.X, wallPositionLeft.Y, nudDepth.Value, wallSize.Height), GraphicsUnit.Pixel)
                End If                       
                If topDepthPosition <> Nothing Then
                    If wallPositionLeft <> Nothing Then
                        For i As Integer = 0 To wallLength - 1
                            g.DrawImage(bm, New Rectangle(startPos.X + wallSize.Width - 64 - (i * 32), startPos.Y - 16 + (i * 16), 64, 32), New Rectangle(topDepthPosition.X, topDepthPosition.Y, topDepthSize.Width, topDepthSize.Height), GraphicsUnit.Pixel)
                        Next i
                    End If
                    If (cbxMirrored.Checked Or wallPositionRight <> Nothing) And wallPositionLeft <> Nothing Then
                        For i As Integer = 0 To wallLength - 1
                            g.DrawImage(bm, New Rectangle(startPos.X + wallSize.Width + (i * 32), startPos.Y - 16 + (i * 16), 64, 32), New Rectangle(topDepthPosition.X + topDepthSize.Width, topDepthPosition.Y, -topDepthSize.Width, topDepthSize.Height), GraphicsUnit.Pixel)
                        Next i
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ctlWall_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnlPreview.AutoScrollMinSize = New Size(wallSize.Width * 2 + 64, wallSize.Height + 16)
        Draw_Image()
        If wallSize.Width * 2 + 64 > pnlPreview.Width Or wallSize.Height + 8 > pnlPreview.Height Then
            bPreview = True
        Else
            bPreview = False
        End If
    End Sub

    Private Sub btnSelectWallLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectWallLeft.Click
        Dim frmSS As New SelectSprite()
        ' If a wall piece has been selected, use it to apply a constraint
        If tbxImageFile.Text <> "" Then
            frmSS.SizeConstraint = wallSize
            frmSS.ImageFile = tileFile
        End If
        If frmSS.ShowDialog(Me) = DialogResult.OK Then
            tileFile = frmSS.ImageFile
            wallPositionLeft = frmSS.TileStart
            wallSize = frmSS.TileSize
            Me.tbxImageFile.Text = tileFile.Split("\")(tileFile.Split("\").Length - 1)
            Me.tbxWallLeftLocation.Text = "(" & wallPositionLeft.X & ", " & wallPositionLeft.Y & ")"
            Me.tbxWallLeftDimension.Text = wallSize.Width & " x " & wallSize.Height
            wallLength = wallSize.Width / 32
            Me.tbxWallLength.Text = wallLength & " cell(s)"
            Draw_Image()
            If wallSize.Width * 2 + 32 > pnlPreview.Width Or wallSize.Height + 26 > pnlPreview.Height Then
                bPreview = True
            Else
                bPreview = False
            End If
            Me.pnlPreview.Invalidate()
        End If
    End Sub

    Private Sub btnSelectWallRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectWallRight.Click
        Dim frmSS As New SelectSprite()
        ' If a wall piece has been selected, use it to apply a constraint
        If tbxImageFile.Text <> "" Then
            frmSS.SizeConstraint = wallSize
            frmSS.ImageFile = tileFile
        End If
        If frmSS.ShowDialog(Me) = DialogResult.OK Then
            tileFile = frmSS.ImageFile
            wallPositionRight = frmSS.TileStart
            wallSize = frmSS.TileSize
            Me.tbxImageFile.Text = tileFile.Split("\")(tileFile.Split("\").Length - 1)
            Me.tbxWallRightLocation.Text = "(" & wallPositionLeft.X & ", " & wallPositionLeft.Y & ")"
            Me.tbxWallRightDimension.Text = wallSize.Width & " x " & wallSize.Height
            wallLength = wallSize.Width / 32
            Me.tbxWallLength.Text = wallLength & " cell(s)"
            Draw_Image()
            If wallSize.Width * 2 + 32 > pnlPreview.Width Or wallSize.Height + 26 > pnlPreview.Height Then
                bPreview = True
            Else
                bPreview = False
            End If
            Me.pnlPreview.Invalidate()
        End If
    End Sub

    Private Sub btnWallTopDepth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWallTopDepth.Click
        Dim frmSS As New SelectSprite()
        ' If a wall piece has been selected, use it to apply a constraint
        If tbxImageFile.Text <> "" Then
            frmSS.SizeConstraint = New Size(64, 32)
            frmSS.ImageFile = tileFile        
            If frmSS.ShowDialog(Me) = DialogResult.OK Then
                topDepthPosition = frmSS.TileStart
                topDepthSize = frmSS.TileSize
                Me.tbxWallTopLocation.Text = "(" & topDepthPosition.X & ", " & topDepthPosition.Y & ")"
                Me.tbxWallTopDimension.Text = topDepthSize.Width & " x " & topDepthSize.Height
                Draw_Image()
                Me.pnlPreview.Invalidate()
            End If
        Else
            MessageBox.Show("Please select the wall piece first.", "Select wall piece first", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Set_UI_State()
        ' Sets the state of various UI elements depending on which checkboxes are checked
        If cbxMirrored.Checked Then
            btnSelectWallRight.Enabled = False
            tbxWallRightLocation.Enabled = False
            tbxWallRightDimension.Enabled = False
            lblWallRight.Enabled = False
            lblWallRightLocation.Enabled = False
            lblWallRightDimension.Enabled = False
            btnDeleteWallRight.Enabled = False
        Else
            btnSelectWallRight.Enabled = True
            tbxWallRightLocation.Enabled = True
            tbxWallRightDimension.Enabled = True
            lblWallRight.Enabled = True
            lblWallRightLocation.Enabled = True
            lblWallRightDimension.Enabled = True
            btnDeleteWallRight.Enabled = True
        End If
        If Not cbxDepth.Checked Then
            lblDepth.Enabled = False
            nudDepth.Enabled = False
            lblWallTopDepth.Enabled = False
            btnWallTopDepth.Enabled = False
            lblWallTopLocation.Enabled = False
            lblWallTopDimension.Enabled = False
            tbxWallTopLocation.Enabled = False
            tbxWallTopDimension.Enabled = False
        Else
            lblDepth.Enabled = True
            nudDepth.Enabled = True
            lblWallTopDepth.Enabled = True
            btnWallTopDepth.Enabled = True
            lblWallTopLocation.Enabled = True
            lblWallTopDimension.Enabled = True
            tbxWallTopLocation.Enabled = True
            tbxWallTopDimension.Enabled = True
        End If
    End Sub

    Private Sub cbxMirrored_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxMirrored.Click
        Set_UI_State()
        Draw_Image()
        Me.pnlPreview.Invalidate()
    End Sub

    Private Sub cbxDepth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDepth.Click
        Set_UI_State()
        Draw_Image()
        Me.pnlPreview.Invalidate()
    End Sub

    Private Sub nudDepth_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nudDepth.KeyUp
        Draw_Image()
        Me.pnlPreview.Invalidate()
    End Sub

    Private Sub btnDeleteWallLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteWallLeft.Click
        If MessageBox.Show("Are you sure you want to delete this image?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            wallPositionLeft = Nothing
            Me.tbxWallLeftLocation.Text = ""
            Me.tbxWallLeftDimension.Text = ""
            If wallPositionRight = Nothing Then
                wallSize = Nothing
            End If
            Draw_Image()
            Me.pnlPreview.Invalidate()
        End If
    End Sub

    Private Sub btnDeleteWallRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteWallRight.Click
        If MessageBox.Show("Are you sure you want to delete this image?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            wallPositionRight = Nothing
            Me.tbxWallRightLocation.Text = ""
            Me.tbxWallRightDimension.Text = ""
            If wallPositionLeft = Nothing Then
                wallSize = Nothing
            End If
            Draw_Image()
            Me.pnlPreview.Invalidate()
        End If
    End Sub

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
        wallID = node.Name
        nodeRef = node
        '
        ' Set up the panel fields here
        '
        Populate_Groups(ds.Tables("Group"))
        Dim wallRow As DataRow = ds.Tables("Wall").Select("Wall_Id = " & wallID)(0)
        Me.ddlGroup.SelectedValue = wallRow.Item("Group_Id")
        Me.tbxTileID.Text = wallRow.Item("WallID")
        Me.tbxTileName.Text = wallRow.Item("TileName")
        If Not wallRow.Item("ImageFile") Is Nothing AndAlso Not IsDBNull(wallRow.Item("ImageFile")) AndAlso wallRow.Item("ImageFile") <> "" Then
            tileFile = My.Application.Info.DirectoryPath & "\" & wallRow.Item("ImageFile")
            Me.tbxImageFile.Text = tileFile.Split("\")(tileFile.Split("\").Length - 1)
        End If
        If Not wallRow.Item("TopLeftLeft") Is Nothing AndAlso Not IsDBNull(wallRow.Item("TopLeftLeft")) Then
            wallPositionLeft = wallRow.Item("TopLeftLeft")
            Me.tbxWallLeftLocation.Text = "(" & wallPositionLeft.X & ", " & wallPositionLeft.Y & ")"
        End If
        If Not wallRow.Item("Mirrored") Is Nothing AndAlso Not IsDBNull(wallRow.Item("Mirrored")) Then
            cbxMirrored.Checked = wallRow.Item("Mirrored")            
        End If
        If Not wallRow.Item("HasDepth") Is Nothing AndAlso Not IsDBNull(wallRow.Item("HasDepth")) Then
            cbxDepth.Checked = wallRow.Item("HasDepth")
            nudDepth.Value = wallRow.Item("Depth")
        End If
        If Not cbxMirrored.Checked AndAlso Not wallRow.Item("TopLeftRight") Is Nothing AndAlso Not IsDBNull(wallRow.Item("TopLeftRight")) Then
            wallPositionRight = wallRow.Item("TopLeftRight")
            Me.tbxWallRightLocation.Text = "(" & wallPositionRight.X & ", " & wallPositionRight.Y & ")"
        End If
        If Not wallRow.Item("Dimension") Is Nothing AndAlso Not IsDBNull(wallRow.Item("Dimension")) Then
            wallSize = wallRow.Item("Dimension")
            Me.tbxWallLeftDimension.Text = wallSize.Width & " x " & wallSize.Height
            If Not cbxMirrored.Checked Then _
            Me.tbxWallRightDimension.Text = wallSize.Width & " x " & wallSize.Height
            wallLength = wallSize.Width / 32
            Me.tbxWallLength.Text = wallLength & " cell(s)"            
        End If
        If Not wallRow.Item("DepthTopLeft") Is Nothing AndAlso Not IsDBNull(wallRow.Item("DepthTopLeft")) Then
            topDepthPosition = wallRow.Item("DepthTopLeft")
            topDepthSize = wallRow.Item("DepthDimension")
            Me.tbxWallTopLocation.Text = "(" & topDepthPosition.X & ", " & topDepthPosition.Y & ")"
            Me.tbxWallTopDimension.Text = topDepthSize.Width & " x " & topDepthSize.Height
        End If        
        Set_UI_State()
    End Sub

    Private Sub btnNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotes.Click
        Dim frmNotes As New Notes()
        frmNotes.Section = Notes.Sections.WallTiles
        frmNotes.MdiParent = Me.ParentForm.MdiParent
        frmNotes.Show()
    End Sub
End Class
