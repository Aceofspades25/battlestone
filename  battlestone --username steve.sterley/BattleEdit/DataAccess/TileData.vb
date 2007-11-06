Public Class TileData
    ' This class represents one of the objects within the data access layer
    ' it is responsible for adding, editing and deleting tiles
    Dim dsTileData As DataSet

    Enum TileTypes
        Floor
        Wall
        [Object]
        Character
    End Enum

    Public ReadOnly Property TileDataSet() As DataSet
        Get
            Return dsTileData
        End Get
    End Property

    Public Sub Delete_Tile(ByVal tType As TileTypes, ByVal tID As String)
        Select Case tType
            Case TileTypes.Character
            Case TileTypes.Floor
                Dim dr As DataRow = dsTileData.Tables("Floor").Select("Floor_Id = " & tID)(0)
                dsTileData.Tables("Floor").Rows.Remove(dr)
            Case TileTypes.Object
                Dim dr As DataRow = dsTileData.Tables("Object").Select("Object_Id = " & tID)(0)
                dsTileData.Tables("Object").Rows.Remove(dr)
            Case TileTypes.Wall
                Dim dr As DataRow = dsTileData.Tables("Wall").Select("Wall_Id = " & tID)(0)
                dsTileData.Tables("Wall").Rows.Remove(dr)
        End Select
    End Sub

    Public Sub Move_Tile(ByVal tType As TileTypes, ByVal tileID As String, ByVal groupID As String)
        Select Case tType
            Case TileTypes.Character
            Case TileTypes.Floor
                Dim dRow As DataRow = dsTileData.Tables("Floor").Select("Floor_Id = " & tileID)(0)
                dRow.Item("Group_Id") = groupID
            Case TileTypes.Object
                Dim dRow As DataRow = dsTileData.Tables("Object").Select("Object_Id = " & tileID)(0)
                dRow.Item("Group_Id") = groupID
            Case TileTypes.Wall
        End Select

    End Sub

    Public Sub Rename_Group(ByVal groupID As String, ByVal newName As String)
        Dim drGroup As DataRow = dsTileData.Tables("Group").Select("Group_Id = " & groupID)(0)
        drGroup.Item("GroupName") = newName
    End Sub

    Public Sub New(ByRef ds As DataSet)
        ' The Dataset is passed by reference so it can be altered by this class
        dsTileData = ds
    End Sub
End Class
