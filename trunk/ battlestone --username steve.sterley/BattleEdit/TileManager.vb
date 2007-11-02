Public Class TileManager
    Dim currentPanel As TileEditor
    Dim dsTiles As New DataSet

    Private Sub Populate_TileTree()
        Dim dtGroup As DataTable = dsTiles.Tables("Group")
        Dim dtObject As DataTable = dsTiles.Tables("Object")
        Dim dtWall As DataTable = dsTiles.Tables("Wall")
        Dim dtFloor As DataTable = dsTiles.Tables("Floor")
        Dim dtCharacter As DataTable = dsTiles.Tables("Character")
        For Each grRow As DataRow In dtGroup.Rows
            Dim newGroup As TreeNode = Me.TreeView1.Nodes(0).Nodes.Add(grRow.Item("GroupName"))
            newGroup.Name = grRow.Item("Group_Id")
            newGroup.StateImageKey = "group.gif"
            ' Add Each of the categories to the group
            Dim newFloorRoot As TreeNode = newGroup.Nodes.Add("Floors", "Floors")
            newFloorRoot.StateImageKey = "floor.gif"
            Dim newWallRoot As TreeNode = newGroup.Nodes.Add("Walls", "Walls")
            newWallRoot.StateImageKey = "wall.gif"
            Dim newObjectRoot As TreeNode = newGroup.Nodes.Add("Objects", "Objects")
            newObjectRoot.StateImageKey = "car.gif"
            Dim newCharacterRoot As TreeNode = newGroup.Nodes.Add("Characters", "Characters")
            newCharacterRoot.StateImageKey = "character.gif"
            Dim objects() As DataRow = dtObject.Select("Group_Id = " & grRow.Item("Group_Id"))
            For Each obj As DataRow In objects
                ' Add Each object for this group
                Dim newObject As TreeNode = newObjectRoot.Nodes.Add(obj.Item("TileName"))
                newObject.StateImageKey = "car.gif"
                newObject.Name = obj.Item("Object_Id")
            Next
            Dim walls() As DataRow = dtWall.Select("Group_Id = " & grRow.Item("Group_Id"))
            For Each wall As DataRow In walls
                ' Add Each object for this group
                Dim newWall As TreeNode = newWallRoot.Nodes.Add(wall.Item("TileName"))
                newWall.StateImageKey = "wall.gif"
                newWall.Name = wall.Item("Wall_Id")
            Next
            Dim floors() As DataRow = dtFloor.Select("Group_Id = " & grRow.Item("Group_Id"))
            For Each floor As DataRow In floors
                ' Add Each object for this group
                Dim newFloor As TreeNode = newFloorRoot.Nodes.Add(floor.Item("TileName"))
                newFloor.StateImageKey = "floor.gif"
                newFloor.Name = floor.Item("Floor_Id")
            Next
            Dim characters() As DataRow = dtCharacter.Select("Group_Id = " & grRow.Item("Group_Id"))
            For Each character As DataRow In characters
                ' Add Each object for this group
                Dim newChar As TreeNode = newCharacterRoot.Nodes.Add(character.Item("TileName"))
                newChar.StateImageKey = "character.gif"
                newChar.Name = character.Item("Character_Id")
            Next
        Next
    End Sub

    Private Sub TileManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dsTiles.ReadXmlSchema(My.Application.Info.DirectoryPath & "\Data\TileSchema.xsd")
        dsTiles.ReadXml(My.Application.Info.DirectoryPath & "\Data\TileData.xml")
        'dsTiles.WriteXmlSchema("TileSchema.xsd")
        Populate_TileTree()
    End Sub

    Private Sub InsertPanel()
        Me.lblSelectTile.Visible = False
        Me.SplitContainer1.Panel2.Controls.Add(currentPanel)
        currentPanel.Dock = DockStyle.Fill
    End Sub

    Private Sub DestroyCurrentPanel()
        If Not currentPanel Is Nothing Then
            currentPanel.Save()
            currentPanel.Dispose()
            currentPanel = Nothing
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Not e.Node.Parent Is Nothing Then
            Select Case e.Node.Parent.Text
                Case "Floors"
                    DestroyCurrentPanel()
                    currentPanel = New ctlFloor(dsTiles, e.Node)
                    InsertPanel()
                Case "Walls"
                    DestroyCurrentPanel()
                    currentPanel = New ctlWall(dsTiles, e.Node)
                    InsertPanel()
                Case "Objects"
                    DestroyCurrentPanel()
                    currentPanel = New ctlObject(dsTiles, e.Node)
                    InsertPanel()
                Case "Characters"
                    DestroyCurrentPanel()
                    currentPanel = New ctlCharacter()
                    InsertPanel()
                Case Else
                    DestroyCurrentPanel()
                    Me.lblSelectTile.Visible = True
            End Select
        Else
            DestroyCurrentPanel()
            Me.lblSelectTile.Visible = True
        End If
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        If Not currentPanel Is Nothing Then currentPanel.Save()
        Me.dsTiles.WriteXml(My.Application.Info.DirectoryPath & "\Data\TileData.xml")
        MessageBox.Show("All tile data saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub TreeView1_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles TreeView1.ItemDrag
        Dim tn As TreeNode = CType(e.Item, TreeNode)
        If tn.Level = 3 Then
            ' Only allow Drag and Drop on level 3 nodes
            TreeView1.SelectedNode = tn.Parent
            DoDragDrop(tn, DragDropEffects.Move)
        End If
    End Sub

    Private Sub TreeView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            'TreeNode found allow move effect
            e.Effect = DragDropEffects.Move
        Else
            'No TreeNode found, prevent move
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TreeView1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragOver
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
        Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        Dim targetNode As TreeNode = TreeView1.GetNodeAt(pt)
        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
        If targetNode.Level = 1 Or (targetNode.Level = 2 And targetNode.Name = dropNode.Parent.Name) Then
            ' You can drag a node to another group, or any other category as long as its the same
            TreeView1.SelectedNode = targetNode
            e.Effect = DragDropEffects.Move
        End If
    End Sub

    Private Sub TreeView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragDrop
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
        Dim targetNode As TreeNode = TreeView1.SelectedNode
        If IsNumeric(targetNode.Name) Then
            ' If the target node is a group
            ' Change the target node to the appropriate category under this group
            targetNode = targetNode.Nodes(dropNode.Parent.Name)
        End If
        ' Update the DataSet
        Dim td As New TileData(dsTiles)
        Select Case dropNode.Parent.Name
            Case "Floors"
                td.Move_Tile(TileData.TileTypes.Floor, dropNode.Name, targetNode.Parent.Name)
            Case "Walls"
            Case "Objects"
                td.Move_Tile(TileData.TileTypes.Object, dropNode.Name, targetNode.Parent.Name)
            Case "Characters"
        End Select
        ' Update the treeview
        dropNode.Remove()
        targetNode.Nodes.Add(dropNode)

        dropNode.EnsureVisible()
        TreeView1.SelectedNode = dropNode
    End Sub

    Private Sub tsbNewGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNewGroup.Click
        Dim frmNG As New SingleGroup()
        If frmNG.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim dtGroups As DataTable = dsTiles.Tables("Group")
            Dim newGroup As DataRow = dtGroups.NewRow()
            newGroup.Item("GroupName") = frmNG.GroupName
            dtGroups.Rows.Add(newGroup)
            ' Add the new group to the treeview
            Dim tn As New TreeNode(frmNG.GroupName)
            tn.Name = newGroup.Item("Group_Id")
            tn.StateImageKey = "group.gif"
            TreeView1.Nodes(0).Nodes.Add(tn)
            ' Add Each of the categories to the group
            Dim newFloorRoot As TreeNode = tn.Nodes.Add("Floors", "Floors")
            newFloorRoot.StateImageKey = "floor.gif"
            Dim newWallRoot As TreeNode = tn.Nodes.Add("Walls", "Walls")
            newWallRoot.StateImageKey = "wall.gif"
            Dim newObjectRoot As TreeNode = tn.Nodes.Add("Objects", "Objects")
            newObjectRoot.StateImageKey = "car.gif"
            Dim newCharRoot As TreeNode = tn.Nodes.Add("Characters", "Characters")
            newObjectRoot.StateImageKey = "character.gif"
        End If
    End Sub

    Private Sub tsbRenameGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRenameGroup.Click
        If TreeView1.SelectedNode.Level = 1 Then
            If TreeView1.SelectedNode.Text = "Not specified" Then
                MessageBox.Show("This group may not be renamed", "Can't rename group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            TreeView1.SelectedNode.BeginEdit()
        Else
            MessageBox.Show("Please select a group first", "Select a group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub TreeView1_BeforeLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles TreeView1.BeforeLabelEdit
        If TreeView1.SelectedNode.Level <> 1 Then
            ' You can only edit group names
            e.CancelEdit = True
        End If
        If TreeView1.SelectedNode.Text = "Not specified" Then
            ' You can't edit the not specified group
            e.CancelEdit = True
        End If
    End Sub

    Private Sub TreeView1_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles TreeView1.AfterLabelEdit
        If e.Label = "Not specified" Then
            e.CancelEdit = True
            MessageBox.Show("Please select a different group name", "Invalid group name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim td As New TileData(dsTiles)
        td.Rename_Group(TreeView1.SelectedNode.Name, e.Label)
    End Sub

    Private Sub MoveChildNodes(ByVal oldNode As TreeNode, ByVal newNode As TreeNode)
        Dim groupNum As Integer = 0
        For Each node As TreeNode In oldNode.Nodes
            While node.Nodes.Count > 0
                Dim currNode As TreeNode = node.Nodes(0)
                currNode.Remove()
                newNode.Nodes(groupNum).Nodes.Add(currNode)
            End While
            groupNum += 1
        Next
    End Sub

    Private Function FindNode(ByVal strNodeName As String, ByVal start As TreeNode) As TreeNode
        For Each node As TreeNode In start.Nodes
            If node.Text = strNodeName Then
                Return node
            Else
                FindNode(strNodeName, node)
            End If
        Next
        Return Nothing
    End Function

    Private Sub Move_Rows(ByVal oldGroupId As Integer, ByVal newGroupID As Integer)
        ' Start off with Objects
        Dim objRows() As DataRow = dsTiles.Tables("Object").Select("Group_Id = " & oldGroupId)
        For Each dRow As dataRow In objRows
            dRow.Item("Group_Id") = newGroupID
        Next
        ' Move floors
        Dim floorRows() As DataRow = dsTiles.Tables("Floor").Select("Group_Id = " & oldGroupId)
        For Each dRow As DataRow In floorRows
            dRow.Item("Group_Id") = newGroupID
        Next
        ' Move walls
        Dim wallRows() As DataRow = dsTiles.Tables("Wall").Select("Group_Id = " & oldGroupId)
        For Each dRow As DataRow In wallRows
            dRow.Item("Group_Id") = newGroupID
        Next
    End Sub

    Private Sub tsbDeleteGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDeleteGroup.Click
        If TreeView1.SelectedNode.Level = 1 Then
            ' DONE: Don't allow to delete not specified
            If TreeView1.SelectedNode.Text = "Not specified" Then
                MessageBox.Show("This group may not be deleted", "Can't delete group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If MessageBox.Show("Are you sure you want to delete this group?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim dtGroups As DataTable = dsTiles.Tables("Group")
                ' TODO: Move all child tiles to Not Specified
                Dim notSpecifiedNode As TreeNode = FindNode("Not specified", TreeView1.Nodes(0))
                MoveChildNodes(TreeView1.SelectedNode, notSpecifiedNode)
                Move_Rows(TreeView1.SelectedNode.Name, notSpecifiedNode.Name)
                dtGroups.Rows.Remove(dtGroups.Select("Group_Id = " & TreeView1.SelectedNode.Name)(0))
                TreeView1.SelectedNode.Remove()
            End If
        Else
            MessageBox.Show("Please select a group first", "Select a group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub tsbNewTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNewTile.Click
        Dim frmNT As New NewTile()
        frmNT.GroupsTable = dsTiles.Tables("Group")
        Select Case TreeView1.SelectedNode.Level
            Case 1
                frmNT.SelectedGroup = TreeView1.SelectedNode.Name
            Case 2
                frmNT.SelectedGroup = TreeView1.SelectedNode.Parent.Name
                frmNT.SelectedType = TreeView1.SelectedNode.Text
            Case 3
                frmNT.SelectedGroup = TreeView1.SelectedNode.Parent.Parent.Name
                frmNT.SelectedType = TreeView1.SelectedNode.Parent.Text
        End Select
        If frmNT.ShowDialog = Windows.Forms.DialogResult.OK Then            
            Dim strTableName As String = ""
            Dim strIDField As String = ""
            Dim strAutoNumField As String = ""
            Dim strImageKey As String = ""
            Select Case frmNT.SelectedType
                Case "Objects"
                    ' If it was a new object
                    strTableName = "Object"
                    strIDField = "ObjectID"
                    strAutoNumField = "Object_Id"
                    strImageKey = "car.gif"
                Case "Floors"
                    ' If it was a new floor
                    strTableName = "Floor"
                    strIDField = "FloorID"
                    strAutoNumField = "Floor_Id"
                    strImageKey = "floor.gif"
            End Select
            Dim dr As DataRow = dsTiles.Tables(strTableName).NewRow()
            dr.Item(strIDField) = dsTiles.Tables(strTableName).Compute("Max(" & strIDField & ")", "") + 1
            dr.Item("Group_Id") = frmNT.SelectedGroup
            dr.Item("TileName") = "New tile"
            dsTiles.Tables(strTableName).Rows.Add(dr)

            Dim newTileNode As New TreeNode("New tile")
            newTileNode.Name = dr.Item(strAutoNumField)
            newTileNode.StateImageKey = strImageKey
            Dim parentGroup As TreeNode = TreeView1.Nodes.Find(dr.Item("Group_Id"), True)(0)
            Dim parent As TreeNode = parentGroup.Nodes.Find(frmNT.SelectedType, True)(0)
            parent.Nodes.Add(newTileNode)
            newTileNode.EnsureVisible()
            TreeView1.SelectedNode = newTileNode
        End If
    End Sub

    Private Sub tsbDeleteTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDeleteTile.Click
        If TreeView1.SelectedNode.Level = 3 Then
            If MessageBox.Show("Are you sure you want to delete the" & vbCrLf & "tile named '" & TreeView1.SelectedNode.Text & "' in the group '" & TreeView1.SelectedNode.Parent.Parent.Text & "'?", _
            "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim td As New TileData(dsTiles)
                ' Determine the tiles type to delete the dataRow
                Select Case TreeView1.SelectedNode.Parent.Name
                    Case "Floors"
                        td.Delete_Tile(TileData.TileTypes.Floor, TreeView1.SelectedNode.Name)
                    Case "Walls"
                    Case "Objects"
                        td.Delete_Tile(TileData.TileTypes.Object, TreeView1.SelectedNode.Name)
                    Case "Characters"
                End Select
                ' Delete and detach the tree node
                TreeView1.SelectedNode.Remove()
                ' Delete the tree Node
                'TreeView1.SelectedNode.
            End If
        Else
            MessageBox.Show("Please select a tile first", "Select a tile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
End Class