Public Class ctlWall

    Dim wallPositionLeft As Point = Nothing
    Dim wallPositionRight As Point = Nothing
    Dim wallSize As Size = Nothing
    Dim depthSizeL As Size = Nothing
    Dim depthPositionL As Point = Nothing
    Dim depthSizeR As Size = Nothing
    Dim depthPositionR As Point = Nothing
    Dim tileFile As String = ""
    Dim currentImage As Bitmap
    Dim obstacles As New ArrayList
    Dim bPreview As Boolean = False

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
        flrRow.Item("TopLeftRight") = wallPositionRight
        flrRow.Item("Dimension") = wallSize
        'flrRow.Item("TopLeftDepthL") = depthPositionL
        'flrRow.Item("DimensionDepthL") = depthSizeL
        'flrRow.Item("TopLeftDepthR") = depthPositionR
        'flrRow.Item("DimensionDepthR") = depthSizeR
        flrRow.Item("ImageFile") = tileFile.Replace(My.Application.Info.DirectoryPath & "\", "")
        'flrRow.Item("Group_Id") = ddlGroup.SelectedValue
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
        '' Now update the TreeNode that represents this structure
        'nodeRef.Text = Me.tbxTileName.Text
        'If nodeRef.Parent.Parent.Name <> ddlGroup.SelectedValue Then
        '    Dim groupNode As TreeNode = nodeRef.TreeView.Nodes(0).Nodes(ddlGroup.SelectedValue.ToString())
        '    Dim targetNode As TreeNode = groupNode.Nodes(nodeRef.Parent.Name)
        '    ' If the current node is the selected one, de-select it, so that the following node doesn't get selected the moment this is removed
        '    If nodeRef.TreeView.SelectedNode Is nodeRef Then nodeRef.TreeView.SelectedNode = Nothing
        '    nodeRef.Remove()
        '    targetNode.Nodes.Add(nodeRef)
        'End If
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
            Dim imgSize As New Size(wallSize.Width * 2 + 32, wallSize.Height + 16)
            Dim startPos As New Point((pnlPreview.Width - imgSize.Width) / 2, (pnlPreview.Height - imgSize.Height) / 2)
            Dim size As New Size(pnlPreview.Width, pnlPreview.Height)
            If (imgSize.Width > pnlPreview.Width) Then
                startPos.X = 0
                size.Width = imgSize.Width
            End If
            If (imgSize.Height > pnlPreview.Height) Then
                ' Add 16 for depth pieces
                startPos.Y = 0
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
            If wallPositionRight <> Nothing Then
                g.DrawImage(bm, New Rectangle(startPos.X + wallSize.Width, startPos.Y, wallSize.Width, wallSize.Height), New Rectangle(wallPositionRight.X, wallPositionRight.Y, wallSize.Width, wallSize.Height), GraphicsUnit.Pixel)
            End If
            'If Not depthSizeL = Nothing Then
            '    ' If a left depth image has been specified
            '    g.DrawImage(bm, New Rectangle(startPos.X, startPos.Y + tileSize.Height / 2, depthSizeL.Width, depthSizeL.Height), New Rectangle(depthPositionL.X, depthPositionL.Y, depthSizeL.Width, depthSizeL.Height), GraphicsUnit.Pixel)
            'End If
            'If Not depthSizeR = Nothing Then
            '    ' If a right depth image has been specified
            '    g.DrawImage(bm, New Rectangle(startPos.X + tileSize.Width / 2, startPos.Y + tileSize.Height / 2, depthSizeR.Width, depthSizeR.Height), New Rectangle(depthPositionR.X, depthPositionR.Y, depthSizeR.Width, depthSizeR.Height), GraphicsUnit.Pixel)
            'End If
            End If
    End Sub

    Private Sub ctlWall_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnlPreview.AutoScrollMinSize = New Size(wallSize.Width * 2 + 32, wallSize.Height + 16)
        Draw_Image()
        If wallSize.Width * 2 + 32 > pnlPreview.Width Or wallSize.Height + 16 > pnlPreview.Height Then
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
            Me.tbxWallLength.Text = wallSize.Width / 32 & " cell(s)"
            Draw_Image()
            If wallSize.Width * 2 + 32 > pnlPreview.Width Or wallSize.Height + 26 > pnlPreview.Height Then
                bPreview = True
            Else
                bPreview = False
            End If
            Me.pnlPreview.Invalidate()
        End If
    End Sub

    Private Sub SelectWallRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectWallRight.Click
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
            Me.tbxWallLength.Text = wallSize.Width / 32 & " cell(s)"
            Draw_Image()
            If wallSize.Width * 2 + 32 > pnlPreview.Width Or wallSize.Height + 26 > pnlPreview.Height Then
                bPreview = True
            Else
                bPreview = False
            End If
            Me.pnlPreview.Invalidate()
        End If
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
        If Not wallRow.Item("TopLeftRight") Is Nothing AndAlso Not IsDBNull(wallRow.Item("TopLeftRight")) Then
            wallPositionRight = wallRow.Item("TopLeftRight")
            Me.tbxWallRightLocation.Text = "(" & wallPositionRight.X & ", " & wallPositionRight.Y & ")"
        End If
        If Not wallRow.Item("Dimension") Is Nothing AndAlso Not IsDBNull(wallRow.Item("Dimension")) Then
            wallSize = wallRow.Item("Dimension")
            Me.tbxWallLeftDimension.Text = wallSize.Width & " x " & wallSize.Height
            Me.tbxWallRightDimension.Text = wallSize.Width & " x " & wallSize.Height
            Me.tbxWallLength.Text = wallSize.Width / 32 & " cell(s)"
        End If
    End Sub

    Private Sub btnNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotes.Click
        Dim frmNotes As New Notes()
        frmNotes.Section = Notes.Sections.WallTiles
        frmNotes.MdiParent = Me.ParentForm.MdiParent
        frmNotes.Show()
    End Sub

End Class
