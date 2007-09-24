Imports Microsoft.DirectX.Direct3D
Public Class Form1
    Dim bm As New Bitmap(1000, 1000)

    Private Function SetAlpha(ByRef bmp As Bitmap, ByVal pos As Point, ByVal size As Size, ByVal alpha As Integer) As Bitmap
        Dim b As New Bitmap(size.Width, size.Height, Imaging.PixelFormat.Format32bppArgb)
        For i As Integer = 0 To size.Width() - 1
            For j As Integer = 0 To size.Height() - 1
                Dim pix As Color = bmp.GetPixel(i + pos.X, j + pos.Y)
                b.SetPixel(i, j, Color.FromArgb(alpha, pix.R, pix.G, pix.B))
            Next
        Next
        Return b
    End Function

    Private Sub DrawScreen()
        Dim b As New System.Drawing.Bitmap("c:\Grid.png")        
        b = SetAlpha(b, New Point(0, 0), New Size(64, 32), 150)
        b.MakeTransparent(Color.FromArgb(100, 255, 0, 255))

        Dim g As Graphics = Graphics.FromImage(bm)
        g.FillRectangle(Brushes.Black, New RectangleF(0, 0, 1000, 1000))
        g.FillRectangle(New SolidBrush(Color.FromArgb(255, 200, 0, 0)), New Rectangle(50, 50, 100, 100))
        g.DrawImage(b, New Rectangle(100, 100, 64, 32), New Rectangle(0, 0, 64, 32), GraphicsUnit.Pixel)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Panel1.AutoScrollMinSize = New Size(1000, 1000)
        Me.pnlObjects.AutoScrollMinSize = New Size(0, 1000)
        DrawScreen()
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        Me.TextBox1.Text = e.X - Me.Panel1.AutoScrollPosition.X
        Me.TextBox2.Text = e.Y - Me.Panel1.AutoScrollPosition.Y
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Me.Panel1.SuspendLayout()
        e.Graphics.TranslateTransform(Me.Panel1.AutoScrollPosition.X, Me.Panel1.AutoScrollPosition.Y)
        e.Graphics.DrawImage(bm, New Point(0, 0))
        Me.Panel1.ResumeLayout()
    End Sub

    Private Sub pnlObjects_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlObjects.Paint
        Dim g As Graphics = e.Graphics
        Me.pnlObjects.SuspendLayout()
        g.FillRectangle(Brushes.Black, New RectangleF(0, 0, Me.Panel1.Width, Me.Panel1.Height))
        g.TranslateTransform(Me.Panel1.AutoScrollPosition.X, Me.Panel1.AutoScrollPosition.Y)
        Me.pnlObjects.ResumeLayout()
    End Sub

    Private Sub Panel1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Panel1.Scroll
        Me.Panel1.Invalidate()
    End Sub

    Private Sub pnlObjects_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles pnlObjects.Scroll
        Me.pnlObjects.Invalidate()
    End Sub
End Class
