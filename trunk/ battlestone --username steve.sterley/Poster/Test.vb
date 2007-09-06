Public Class Test

    Private Sub Test_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed 
        'Me.DataGridView1.Rows(0).Cells(0).Controls.Add()
        'Me.DataGridView1.Columns(0).HeaderCell.Controls.Add()
        'Me.DataGridView1.Rows(-1).Cells(0).add()
        For i As Integer = 1 To 20
            Me.DataGridView1.Rows.Add()
        Next i

    End Sub

    Private Sub tabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics = e.Graphics
        Dim p As New Pen(Color.Blue, 4)
        g.FillRectangle(Brushes.Black, Me.TabPage1.Bounds)
        'e.Graphics.
    End Sub

End Class