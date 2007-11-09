Public Class ctlObject

    Dim nodeRef As TreeNode
    Dim dtAnimFrames As DataTable
    Dim tilePosition As Point
    Dim tileSize As Size
    Dim tileFile As String = ""
    Dim currentFrame As Integer = 1
    Dim currentImage As Bitmap
    Dim imageOffSet As Boolean = False  ' Does the image have an offset with respect to the underlying grid?
    Dim obstacles As New ArrayList
    Dim bPreview As Boolean = False

    Dim dsTiles As DataSet  ' The Global DataSet which stores all tile data
    Dim objID As String ' The ID for this particular Tile

    Public Overrides Sub Save()
        ' When this control is browsed away from, save all the changes made to the global dataset (dsTiles)
        Dim objRow As DataRow
        Try
            objRow = dsTiles.Tables("Object").Select("Object_Id = " & objID)(0)
        Catch ex As IndexOutOfRangeException
            ' If the index is out of range, the node has just been deleted and we don't need to save it
            Exit Sub
        End Try
        objRow.Item("TileName") = Me.tbxTileName.Text
        objRow.Item("TopLeft") = tilePosition 'tilePosition.X & "," & tilePosition.Y
        objRow.Item("Dimension") = tileSize '.Width & "," & tileSize.Height
        objRow.Item("ImageFile") = tileFile.Replace(My.Application.Info.DirectoryPath & "\", "")
        objRow.Item("Group_Id") = ddlGroup.SelectedValue
        ' Now save the obstacles
        Dim obsRows() As DataRow = dsTiles.Tables("Obstacle").Select("Object_Id = " & objID)
        ' Delete all the previous rows
        For Each obsRow As DataRow In obsRows
            dsTiles.Tables("Obstacle").Rows.Remove(obsRow)
        Next
        ' Add the latest rows
        For Each obs As Point In obstacles
            Dim newRow As DataRow = dsTiles.Tables("Obstacle").NewRow()
            newRow.Item("Position") = obs 'obs.X & "," & obs.Y
            newRow.Item("Object_Id") = objID
            dsTiles.Tables("Obstacle").Rows.Add(newRow)
        Next
        ' Now save the animation frames
        Dim animRows() As DataRow = dsTiles.Tables("Frames").Select("Object_Id = " & objID)
        ' Delete all the previous rows
        For Each animRow As DataRow In animRows
            dsTiles.Tables("Frames").Rows.Remove(animRow)
        Next
        ' Add the latest rows
        For Each anim As DataRow In dtAnimFrames.Rows
            Dim newRow As DataRow = dsTiles.Tables("Frames").NewRow()
            newRow.Item("FrameNum") = anim.Item("FrameNum")
            newRow.Item("TopLeft") = anim.Item("TopLeft") '.X & "," & anim.Item("TopLeft").Y
            newRow.Item("Dimension") = anim.Item("Dimension") '.Width & "," & anim.Item("Dimension").Height
            newRow.Item("Object_Id") = objID
            dsTiles.Tables("Frames").Rows.Add(newRow)
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

    Private Sub ctlObject_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        dtAnimFrames.Dispose()
        currentImage.Dispose()
        obstacles.Clear()
    End Sub

    Private Sub ctlObject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgAnimated.DataSource = dtAnimFrames
        pnlPreview.AutoScrollMinSize = New Size(tileSize.Width, tileSize.Height)
        If tileSize.Width > pnlPreview.Width Or tileSize.Height > pnlPreview.Height Then
            bPreview = True
        Else
            bPreview = False
        End If
        Draw_Frame()
    End Sub

    Private Sub Show_Preview(ByVal fName As String, ByVal pos As Point, ByVal size As Size)
        pnlPreview.AutoScrollMinSize = New Size(tileSize.Width, tileSize.Height)
        If tileSize.Width > pnlPreview.Width Or tileSize.Height > pnlPreview.Height Then
            bPreview = True
        Else
            bPreview = False
        End If
        Draw_Frame()
        Me.pnlPreview.Invalidate()
    End Sub

    Private Sub Add_To_Animation()
        If dtAnimFrames.Rows.Count = 0 Then
            Dim newRow As DataRow = dtAnimFrames.NewRow()
            newRow.Item("FrameNum") = 1
            newRow.Item("TopLeft") = tilePosition
            newRow.Item("Dimension") = tileSize
            dtAnimFrames.Rows.Add(newRow)
        Else
            ' If they are changing the object
            Dim firstRow As DataRow = dtAnimFrames.Rows(0)
            firstRow.Item("TopLeft") = tilePosition
            firstRow.Item("Dimension") = tileSize
        End If
    End Sub

    Private Sub Draw_Frame()
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
            If (tileSize.Height > pnlPreview.Height) Then
                startPos.Y = 0
                size.Height = tileSize.Height
            End If
            ' currentImage stores what will currently be shown in the preview panel
            currentImage = New Bitmap(size.Width, size.Height)
            Dim g As Graphics = Graphics.FromImage(currentImage)
            g.FillRectangle(Brushes.Black, 0, 0, currentImage.Width, currentImage.Height)
            Dim bm As New Bitmap(tileFile)
            bm.MakeTransparent(Color.FromArgb(100, 255, 0, 255))
            If Not Me.cbxAnimated.Checked Then
                Dim imgStart As Point = dtAnimFrames.Rows(dtgAnimated.SelectedRows(0).Index).Item("TopLeft")
                g.DrawImage(bm, New Rectangle(startPos.X, startPos.Y, tileSize.Width, tileSize.Height), New Rectangle(imgStart.X, imgStart.Y, tileSize.Width, tileSize.Height), GraphicsUnit.Pixel)
            Else
                ' If it's animated then draw the next portion of the animation sequence
                Dim imgStart As Point = dtAnimFrames.Rows(currentFrame - 1).Item("TopLeft")
                g.DrawImage(bm, New Rectangle(startPos.X, startPos.Y, tileSize.Width, tileSize.Height), New Rectangle(imgStart.X, imgStart.Y, tileSize.Width, tileSize.Height), GraphicsUnit.Pixel)
            End If
        End If
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
            Add_To_Animation()
            Show_Preview(frmSS.ImageFile, frmSS.TileStart, frmSS.TileSize)
        End If
    End Sub

    Private Sub pnlPreview_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlPreview.Paint
        ' Translate to the scroll bar position
        e.Graphics.TranslateTransform(Me.pnlPreview.AutoScrollPosition.X, Me.pnlPreview.AutoScrollPosition.Y)
        ' Draw the pre-calculated image
        e.Graphics.DrawImage(currentImage, 0, 0)
    End Sub

    Private Sub Select_Frame(ByVal dtRow As DataRow)
        Dim frmSS As New SelectSprite()
        frmSS.TileStart = dtRow.Item(1)
        frmSS.TileSize = dtRow.Item(2)
        frmSS.ImageFile = tileFile
        If frmSS.ShowDialog(Me) = DialogResult.OK Then
            dtRow.Item(0) = dtAnimFrames.Rows.Count
            dtRow.Item(1) = frmSS.TileStart
            dtRow.Item(2) = frmSS.TileSize
        End If
    End Sub

    Private Sub Add_Frame()
        Dim frmSS As New SelectSprite()
        frmSS.ImageFile = tileFile
        If frmSS.ShowDialog(Me) = DialogResult.OK Then
            Dim dtRow As DataRow = dtAnimFrames.NewRow()
            dtRow.Item(0) = dtAnimFrames.Rows.Count + 1
            dtRow.Item(1) = frmSS.TileStart
            dtRow.Item(2) = frmSS.TileSize
            dtAnimFrames.Rows.Add(dtRow)
        End If
    End Sub

    Private Sub dtgAnimated_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgAnimated.CellDoubleClick
        If e.RowIndex > 0 Then
            Select_Frame(dtAnimFrames.Rows(e.RowIndex))
        Else
            MessageBox.Show("The first frame must correlate with the original tile." & vbCrLf & "You may only change it by clicking ""Select sprite""", "The first frame may not be edited.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub dtgAnimated_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgAnimated.CellFormatting
        If e.ColumnIndex = 2 Then
            If Not e.Value Is Nothing AndAlso Not IsDBNull(e.Value) Then
                Dim sz As Size = CType(e.Value, Size)
                e.Value = sz.Width & " x " & sz.Height
            End If
        End If
    End Sub

    Private Sub btnAddFrame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFrame.Click
        If dtAnimFrames.Rows.Count = 0 Then
            MessageBox.Show("Please select the tile first before adding a frame", "Tile not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Add_Frame()
        End If
    End Sub

    Private Sub btnDeleteFrame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteFrame.Click
        If Me.dtgAnimated.CurrentCell.RowIndex = 0 Then
            MessageBox.Show("The first frame may not be deleted.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            dtAnimFrames.Rows(Me.dtgAnimated.CurrentCell.RowIndex).Delete()
            Dim count As Integer = 1
            For Each dRow As DataRow In dtAnimFrames.Rows
                dRow.Item(0) = count
                count += 1
            Next
        End If
    End Sub

    Private Sub cbxAnimated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxAnimated.CheckedChanged
        'If cbxAnimated.Checked = False AndAlso dtAnimFrames.Rows.Count > 1 Then
        'MessageBox.Show("Caution: If you leave this box unchecked, all of the new frames" & vbCrLf & "for this object will be lost when you browse away from it.", "Added frames will be lost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        If cbxAnimated.Checked Then
            Timer1.Start()
        Else
            Timer1.Stop()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        currentFrame += 1
        If currentFrame > dtAnimFrames.Rows.Count Then currentFrame = 1
        Draw_Frame()
        Me.pnlPreview.Invalidate()
    End Sub

    Private Sub dtgAnimated_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgAnimated.RowEnter
        If Not cbxAnimated.Checked Then
            dtgAnimated.Rows(e.RowIndex).Selected = True
            Draw_Frame()
            Me.pnlPreview.Invalidate()
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

    Private Sub btnSelectObstacles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectObstacles.Click
        If tileFile <> "" Then
            Dim frmSO As New SelectObstacles()
            frmSO.ImageFile = tileFile
            frmSO.ImageStart = tilePosition
            frmSO.ImageSize = tileSize
            frmSO.OffSet = imageOffSet
            frmSO.Obstacles = obstacles
            If frmSO.ShowDialog(Me) = DialogResult.OK Then
                imageOffSet = frmSO.OffSet
                obstacles = frmSO.Obstacles
                Populate_Obstacles()
            End If
        Else
            MessageBox.Show("Please select the tile first before defining obstacles", "Tile not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Populate_Groups(ByVal dt As DataTable)
        ddlGroup.DisplayMember = "GroupName"
        ddlGroup.ValueMember = "Group_Id"
        ddlGroup.DataSource = dt
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
        objID = node.Name
        nodeRef = node
        '
        ' Set up the panel fields here
        '
        Populate_Groups(ds.Tables("Group"))
        Dim objRow As DataRow = ds.Tables("Object").Select("Object_Id = " & objID)(0)
        Me.ddlGroup.SelectedValue = objRow.Item("Group_Id")
        Me.tbxTileID.Text = objRow.Item("ObjectID")
        Me.tbxTileName.Text = objRow.Item("TileName") 'AndAlso objRow.Item("TopLeft") <> ""
        If Not objRow.Item("TopLeft") Is Nothing AndAlso Not IsDBNull(objRow.Item("TopLeft")) Then
            tilePosition = objRow.Item("TopLeft") 'New Point(objRow.Item("TopLeft").split(",")(0), objRow.Item("TopLeft").split(",")(1))
            Me.tbxTopLeft.Text = "(" & tilePosition.X & ", " & tilePosition.Y & ")"
        End If
        If Not objRow.Item("Dimension") Is Nothing AndAlso Not IsDBNull(objRow.Item("Dimension")) Then 'AndAlso objRow.Item("Dimension") <> "" Then
            tileSize = objRow.Item("Dimension") 'New Size(objRow.Item("Dimension").split(",")(0), objRow.Item("Dimension").split(",")(1))
            Me.tbxDimension.Text = tileSize.Width & " x " & tileSize.Height
        End If
        If Not objRow.Item("ImageFile") Is Nothing AndAlso Not IsDBNull(objRow.Item("ImageFile")) AndAlso objRow.Item("ImageFile") <> "" Then
            tileFile = My.Application.Info.DirectoryPath & "\" & objRow.Item("ImageFile")
            Me.tbxImageFile.Text = tileFile.Split("\")(tileFile.Split("\").Length - 1)
        End If
        '
        ' Add the animation frames here
        '
        dtAnimFrames = New DataTable("AnimationFrames")
        dtAnimFrames.Columns.Add("FrameNum", GetType(Integer))
        dtAnimFrames.Columns.Add("TopLeft", GetType(Point))
        dtAnimFrames.Columns.Add("Dimension", GetType(Size))

        Dim frames() As DataRow = ds.Tables("Frames").Select("Object_Id = " & objID)
        If frames.Length > 0 Then
            For Each fRow As DataRow In frames
                ' Duplicate this row into dtAnimFrames
                Dim dr As DataRow = dtAnimFrames.NewRow()
                dr.Item("FrameNum") = fRow.Item("FrameNum")
                dr.Item("TopLeft") = fRow.Item("TopLeft") 'New Point(fRow.Item("TopLeft").split(",")(0), fRow.Item("TopLeft").split(",")(1))
                dr.Item("Dimension") = fRow.Item("Dimension") 'New Size(fRow.Item("Dimension").split(",")(0), fRow.Item("Dimension").split(",")(1))
                dtAnimFrames.Rows.Add(dr)
            Next
        End If
        '
        ' Add the obstacles here
        '
        Dim obsts() As DataRow = ds.Tables("Obstacle").Select("Object_Id = " & objID)
        If obsts.Length > 0 Then
            For Each oRow As DataRow In obsts
                ' Duplicate this row into obstacles arraylist
                obstacles.Add(oRow.Item("Position")) 'New Point(oRow.Item("Position").split(",")(0), oRow.Item("Position").split(",")(1)))
            Next
            Populate_Obstacles()
        End If
    End Sub

End Class
