Public Class MyGraphics

    Public Shared Function MultiplyChannels(ByVal bm As Bitmap, ByVal factor As Integer, ByVal rect As Rectangle) As Bitmap
        Dim newBM As New Bitmap(rect.Width, rect.Height, bm.PixelFormat)
        For x As Integer = 0 To rect.Width - 1
            For y As Integer = 0 To rect.Height - 1
                newBM.SetPixel(x, y, bm.GetPixel(x + rect.Left, y + rect.Top))
            Next y
        Next x
        Return newBM
    End Function

End Class
