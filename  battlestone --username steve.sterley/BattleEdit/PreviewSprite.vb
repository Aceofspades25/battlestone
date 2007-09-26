Public Class PreviewSprite
    Dim dsTiles As DataSet
    Dim tID As Integer
    Dim tSize As Size
    Dim tileFile As String
    Dim currentImage As Bitmap
    Dim dtAnimFrames As DataTable
    Dim currentFrame As Integer = 1

    Public Property TileDataSet() As DataSet
        Get
            Return dsTiles
        End Get
        Set(ByVal value As DataSet)
            dsTiles = value
        End Set
    End Property

    Public Property TileID() As Integer
        Get
            Return tID
        End Get
        Set(ByVal value As Integer)
            tID = value
        End Set
    End Property

    Private Sub Draw_Frame()
        currentImage = New Bitmap(tSize.Width, tSize.Height)
        Dim g As Graphics = Graphics.FromImage(currentImage)
        g.FillRectangle(Brushes.Black, 0, 0, currentImage.Width, currentImage.Height)
        Dim bm As New Bitmap(tileFile)
        bm.MakeTransparent(Color.FromArgb(255, 255, 0, 255))
        Dim imgStart As Point = dtAnimFrames.Rows(currentFrame - 1).Item("TopLeft")
        g.DrawImage(bm, New Rectangle(0, 0, tSize.Width, tSize.Height), New Rectangle(imgStart.X, imgStart.Y, tSize.Width, tSize.Height), GraphicsUnit.Pixel)
    End Sub

    Private Sub Setup_Preview()
        Dim objRow As DataRow = dsTiles.Tables("Object").Select("Object_Id = " & tID)(0)
        tSize = objRow.Item("Dimension")
        tileFile = My.Application.Info.DirectoryPath & "\" & objRow.Item("ImageFile")
        '
        ' Add the animation frames here
        '
        dtAnimFrames = New DataTable("AnimationFrames")
        dtAnimFrames.Columns.Add("FrameNum", GetType(Integer))
        dtAnimFrames.Columns.Add("TopLeft", GetType(Point))
        dtAnimFrames.Columns.Add("Dimension", GetType(Size))

        Dim frames() As DataRow = dsTiles.Tables("Frames").Select("Object_Id = " & tID)
        If frames.Length > 0 Then
            For Each fRow As DataRow In frames
                ' Duplicate this row into dtAnimFrames
                Dim dr As DataRow = dtAnimFrames.NewRow()
                dr.Item("FrameNum") = fRow.Item("FrameNum")
                dr.Item("TopLeft") = fRow.Item("TopLeft")
                dr.Item("Dimension") = fRow.Item("Dimension")
                dtAnimFrames.Rows.Add(dr)
            Next
        End If

        Dim mySize As New Size
        Me.ClientSize = New Size(Math.Min(tSize.Width, 800), Math.Min(tSize.Height, 600))
        Me.AutoScrollMinSize = tSize
        Draw_Frame()
        If dtAnimFrames.Rows.Count > 1 Then
            Timer1.Start()
        End If
    End Sub

    Private Sub PreviewSprite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Setup_Preview()
    End Sub

    Private Sub pnlPreview_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlPreview.Paint
        ' Translate to the scroll bar position
        e.Graphics.TranslateTransform(Me.pnlPreview.AutoScrollPosition.X, Me.pnlPreview.AutoScrollPosition.Y)
        ' Draw the pre-calculated image
        e.Graphics.DrawImage(currentImage, 0, 0)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        currentFrame += 1
        If currentFrame > dtAnimFrames.Rows.Count Then currentFrame = 1
        Draw_Frame()
        Me.pnlPreview.Invalidate()
    End Sub
End Class