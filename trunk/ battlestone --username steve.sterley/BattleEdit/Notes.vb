Public Class Notes

    Public Enum Sections
        FloorTiles
        WallTiles
        Objects
        Characters
    End Enum

    Private _sect As Sections

    Public Property Section() As Sections
        Get
            Return _sect
        End Get
        Set(ByVal value As Sections)
            _sect = value
        End Set
    End Property

    Private Sub Show_Notes()
        Select Case _sect
            Case Sections.FloorTiles
                Me.lbl.Text = "Notes on floor tiles"
                Me.tbxNotes.Text = "For now all floor tiles have to be square i.e. 1x1, 2x2, 3x3 etc." & _
                " Sorry about that. If anyone feels there is a need for rectangular shaped floor tiles," & _
                " get back to me at aceofspades25@hotmail.co.uk and I will try and incorporate that. " & _
                "It's like this at the moment, becuase I am just trying to get this finished as quickly " & _
                "as possible, so I can get started on the level editor" & vbCrLf & vbCrLf
                Me.tbxNotes.Text &= "For now obstacles cannot be added for floor tiles, but I will be adding this soon."
        End Select
    End Sub

    Private Sub Notes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Show_Notes()
        Me.tbxNotes.Select(0, 0)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class