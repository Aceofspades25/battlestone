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
            Case Sections.WallTiles
                Me.lbl.Text = "Notes on wall tiles"
                Me.tbxNotes.Text = "You cannot set obstacles for wall tiles yet, but this will be coming soon. " & _
                "For now, the entire length of any wall will be considered solid, and characters won't be able to " & _
                "pass through them. Later you will be able to allow characters to pass through sections of wall tiles. " & _
                "e.g. picture a big open gate that forms part of a fence." & vbCrLf & vbCrLf
                Me.tbxNotes.Text &= "There is a small square piece that forms part of the wall depth that should show " & _
                "at any point where a horizontal and vertical wall join. I haven't quite figured whether I will let " & _
                "that be set here, or even if it's really needed. I may try to generate this automatically by using the " & _
                "existing wall depth pieces." & vbCrLf & vbCrLf
                Me.tbxNotes.Text &= "When you choose for the right wall to mirror the left, it won't show as being lighter " & _
                "than the left wall. This is because this editor was written in vb.net using GDI+. GDI+ Can darken and lighten " & _
                "pixels, but the easy way to do this is slow and inefficient. Because of this, the two walls will appear to have " & _
                "the same brightness. On the other hand, within the game itself, the walls will be rendered in DirectX. The " & _
                """in game"" mirrored walls will be shaded appropriately."
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