Public Class Parent
    Dim tmOpen As Boolean = False

    Private Sub Launch_TileManager()
        If Not tmOpen Then
            Dim frmTM As New TileManager
            frmTM.MdiParent = Me
            frmTM.Show()
            AddHandler frmTM.FormClosed, AddressOf Form_Closed
            tmOpen = True
        Else
            MessageBox.Show("Only one instance of the tile manager is allowed open at a time.", "One instance at a time.", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub Show_About()
        MessageBox.Show("BattleEdit" & vbCrLf & "The Battlestone editor" & vbCrLf & "Credits...." & vbCrLf & "2007", "About BattleEdit", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub tsbTileManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbTileManager.Click
        Launch_TileManager()
    End Sub

    Private Sub Parent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        For Each c As Control In Me.Controls
            If c.GetType.Name = "MdiClient" Then
                c.BackgroundImage = My.Resources.BattleStone
            End If
        Next
    End Sub

    Private Sub Parent_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        For Each c As Control In Me.Controls
            If c.GetType.Name = "MdiClient" Then
                ' This property keeps getting reset Grrr...
                c.BackgroundImage = My.Resources.BattleStone
            End If
        Next
    End Sub

    Private Sub Form_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        Select Case sender.Name
            Case "TileManager" : tmOpen = False
        End Select
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TileManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileManagerToolStripMenuItem.Click
        Launch_TileManager()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Show_About()
    End Sub
End Class