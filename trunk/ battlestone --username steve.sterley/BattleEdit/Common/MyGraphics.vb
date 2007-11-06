Public Class MyGraphics

    Public Shared Function MultiplyChannels(ByVal bm As Bitmap, ByVal f As Single, ByVal rect As Rectangle) As Bitmap
        ' Returns a portion of a specified bitmap, that has either been darkened or lightened
        ' 0 < f < 1 : Darkens the image
        ' f > 1     : Lightens the image
        Dim newBM As New Bitmap(rect.Width, rect.Height, bm.PixelFormat)
        For x As Integer = 0 To rect.Width - 1
            For y As Integer = 0 To rect.Height - 1
                Dim c As Color = bm.GetPixel(x + rect.Left, y + rect.Top)
                newBM.SetPixel(x, y, Color.FromArgb(c.A, Math.Min(c.R * f, 255), Math.Min(c.G * f, 255), Math.Min(c.B * f, 255)))
            Next y
        Next x
        Return newBM
    End Function

End Class
