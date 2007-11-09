Public Class SingleMap
    Dim currentImage As System.Drawing.Bitmap
    Dim imageStart As Point
    Dim szMap As New Size(100, 100)

    Private Sub Draw_Map(ByVal pt As Point, ByVal sz As Size)
        ' This sub draws a portion of the Map, starting at pt, and with Size sz
        'If Not currentImage Is Nothing Then currentImage.Dispose()
        currentImage = New Bitmap(sz.Width, sz.Height)
        Dim g As Graphics = Graphics.FromImage(currentImage)
        ' Fill the image with Black
        g.FillRectangle(Brushes.Black, 0, 0, currentImage.Width, currentImage.Height)
        ' Now Draw Just the portion of the map that falls in this area

    End Sub

    Private Sub SingleMap_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.pnlMap.AutoScrollMinSize = New Size(64 * szMap.Width, 32 * szMap.Height)
        Draw_Map(New Point(0, 0), New Size(Me.pnlMap.Width * 1.5, Me.pnlMap.Height * 1.5))
    End Sub

    Private Sub pnlMap_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlMap.Paint        
        e.Graphics.TranslateTransform(Me.pnlMap.AutoScrollPosition.X, Me.pnlMap.AutoScrollPosition.Y)
        e.Graphics.DrawImage(currentImage, 0, 0)
    End Sub


End Class