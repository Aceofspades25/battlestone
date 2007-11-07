Public Class SelectObstacles
    Dim strImage As String = ""  ' The filename of the image
    Dim ptStart As New Point(0, 0)
    Dim szDimensions As New Size(512, 512)
    Dim currentImage As Bitmap
    Dim bOffSet As Boolean = False
    Dim alObstacles As New ArrayList
    Dim mouseGridPos As New Point(0, 0)
    Dim gridOffset As Integer = 0

    Dim PI As Double = CType(4.0, Double) * Math.Atan(1.0)
    Dim Tan_PI_6 As Double = Math.Tan(PI / CType(6.0, Double))
    Dim Sqrt_5_8 As Double = CType(8.0, Double) * Math.Sqrt(5.0)

    Public Property ImageFile() As String
        Get
            Return strImage
        End Get
        Set(ByVal value As String)
            strImage = value
        End Set
    End Property

    Public Property ImageStart() As Point
        Get
            Return ptStart
        End Get
        Set(ByVal value As Point)
            ptStart = value
        End Set
    End Property

    Public Property ImageSize() As Size
        Get
            Return szDimensions
        End Get
        Set(ByVal value As Size)
            szDimensions = value
        End Set
    End Property

    Public Property OffSet() As Boolean
        Get
            Return bOffSet
        End Get
        Set(ByVal value As Boolean)
            bOffSet = value
        End Set
    End Property

    Public Property Obstacles() As ArrayList
        Get
            Return alObstacles
        End Get
        Set(ByVal value As ArrayList)
            alObstacles = value
        End Set
    End Property

    Private Sub DrawDiamond(ByVal g As Graphics, ByVal x As Single, ByVal y As Single)
        Dim points(3) As PointF
        points(0).X = x * 64
        points(0).Y = y * 32 + 16 + 16
        points(1).X = x * 64 + 32
        points(1).Y = y * 32 + 16 + 16 - 16
        points(2).X = x * 64 + 32 + 32
        points(2).Y = y * 32 + 16 + 16
        points(3).X = x * 64 + 32
        points(3).Y = y * 32 + 16 + 32
        g.DrawPolygon(Pens.Red, points)
    End Sub

    Private Sub DrawAnchor(ByVal g As Graphics, ByVal x As Single, ByVal y As Single)
        Dim points(3) As PointF
        points(0).X = x * 64
        points(0).Y = y * 32 + 16 + 16
        points(1).X = x * 64 + 32
        points(1).Y = y * 32 + 16 + 16 - 16
        points(2).X = x * 64 + 32 + 32
        points(2).Y = y * 32 + 16 + 16
        points(3).X = x * 64 + 32
        points(3).Y = y * 32 + 16 + 32
        g.DrawPolygon(New Pen(Color.Blue, 2), points)
        g.DrawString("A", New Font("Verdana", 12, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Blue, x * 64 + 25, y * 32 + 24)
    End Sub

    Private Sub DrawOrthoGrid()
        Dim g As Graphics = Graphics.FromImage(currentImage)
        ' Draw the orthogonal grid starting in the top left corner of the image
        Dim i As Integer
        Dim j As Integer
        For i = 0 To Math.Ceiling(szDimensions.Width / 64) - 1
            ' Diamonds across
            For j = 0 To Math.Ceiling(szDimensions.Height / 32) - 1
                DrawDiamond(g, i, j)
                DrawDiamond(g, i - 0.5, j - 0.5)
                DrawDiamond(g, i + 0.5, j - 0.5)
                DrawDiamond(g, i - 0.5, j + 0.5)
                DrawDiamond(g, i + 0.5, j + 0.5)
            Next j
        Next i
        DrawAnchor(g, i - 1, j - 1)
    End Sub

    Private Sub PaintCell(ByVal g As Graphics, ByVal pt As Point)
        Dim offSet As New Point(pt.Y * 32 + pt.X * 32, pt.Y * 16 - pt.X * 16)
        Dim points(3) As PointF
        points(0).X = szDimensions.Width - 32 + offSet.X - 32 + gridOffset
        points(0).Y = szDimensions.Height + offSet.Y
        points(1).X = szDimensions.Width + offSet.X - 32 + gridOffset
        points(1).Y = szDimensions.Height - 16 + offSet.Y
        points(2).X = szDimensions.Width + 32 + offSet.X - 32 + gridOffset
        points(2).Y = szDimensions.Height + offSet.Y
        points(3).X = szDimensions.Width + offSet.X - 32 + gridOffset
        points(3).Y = szDimensions.Height + 16 + offSet.Y
        g.FillPolygon(New SolidBrush(Color.FromArgb(150, 255, 0, 0)), points)
    End Sub

    Private Sub PaintSelectedCells()
        Dim g As Graphics = Graphics.FromImage(currentImage)
        ' Paints the selected cells onto the orthogonal grid
        For Each pt As Point In alObstacles
            PaintCell(g, pt)
        Next
    End Sub

    Private Sub DrawPanel()
        If strImage <> "" Then
            currentImage = New Bitmap(Math.Max(pnlImage.Width, szDimensions.Width + 64), Math.Max(pnlImage.Height, szDimensions.Height + 32))
            Dim g As Graphics = Graphics.FromImage(currentImage)
            g.FillRectangle(Brushes.Black, 0, 0, currentImage.Width, currentImage.Height)
            Dim bm As New Bitmap(strImage)
            bm.MakeTransparent(Color.FromArgb(100, 255, 0, 255))
            g.DrawImage(bm, New Rectangle(bOffSet * -32, 16, szDimensions.Width, szDimensions.Height), New Rectangle(ptStart.X, ptStart.Y, szDimensions.Width, szDimensions.Height), GraphicsUnit.Pixel)
            PaintSelectedCells()
            DrawOrthoGrid()
        End If
    End Sub

    Private Sub SelectObstacles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load        
        If szDimensions.Width Mod 64 = 0 Then
            ' If there are an even number of cells in the images width then the grid will start 32 in the normal position
            gridOffset = 0
        Else
            ' If there are an even number of cells in the images width then the grid will start 32 pixels forwards
            gridOffset = 32
        End If

        Me.pnlImage.AutoScrollMinSize = New Size(szDimensions.Width + 64, szDimensions.Height + 32)
        If bOffSet Then
            ' Set the button states
            tsbShiftLeft.Enabled = False
            tsbShiftRight.Enabled = True
        Else
            tsbShiftLeft.Enabled = True
            tsbShiftRight.Enabled = False
        End If
        DrawPanel()
    End Sub

    Private Sub pnlImage_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlImage.MouseClick
        ' If they click on the grid, add the orthogonal co-ords to the arraylist, if they aren't already there
        ' Remove them if they are already there
        ' If there was a change, re-paint pnlImage
        If e.Button = Windows.Forms.MouseButtons.Left And e.Location.X < szDimensions.Width + 32 + gridOffset + Me.pnlImage.AutoScrollPosition.X And e.Location.Y < szDimensions.Height + 32 + Me.pnlImage.AutoScrollPosition.Y Then
            If alObstacles.Contains(mouseGridPos) Then
                ' The grid position is stored, so remove it.
                alObstacles.Remove(mouseGridPos)
            Else
                ' The grid position is new, so add it.
                alObstacles.Add(mouseGridPos)
            End If
            DrawPanel()
            Me.pnlImage.Invalidate()
        End If
    End Sub

    Private Function To_Radians(ByVal degAngle As Double) As Double
        Return degAngle / CType(180, Double) * PI
    End Function

    Private Sub pnlImage_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlImage.MouseMove
        ' Calculates the Mouse' co-ordinates on the orthagonal grid        
        If e.Location.X < szDimensions.Width + 32 + gridOffset + Me.pnlImage.AutoScrollPosition.X And e.Location.Y < szDimensions.Height + 32 + Me.pnlImage.AutoScrollPosition.Y Then
            ' TODO: This algorithm goes wrong, and needs re-thinking.
            ' This is the same algorithm used in the engine.
            ' The new Point with respect to the anchor cell

            Dim newLoc As New PointF(e.Location.X - szDimensions.Width - Me.pnlImage.AutoScrollPosition.X + 32 - gridOffset, e.Location.Y - szDimensions.Height - Me.pnlImage.AutoScrollPosition.Y)
            'Dim vertHeightAboveOrthY As Single = (-newLoc.X * Tan_PI_6) + newLoc.Y
            'Dim vertHeightAboveOrthX As Single = newLoc.Y + (newLoc.X * Tan_PI_6)
            'Dim orthX As Double = -vertHeightAboveOrthY + 2.0 * Sqrt_5_8
            'Dim orthY As Double = vertHeightAboveOrthX
            'orthX /= 2.0 * Sqrt_5_8
            'orthY /= 2.0 * Sqrt_5_8
            'mouseGridPos.X = CType(orthX, Integer)
            'mouseGridPos.Y = CType(orthY, Integer)
            newLoc.Y *= CType(1.11, Double)
            newLoc.X *= CType(0.984, Double)
            Dim angle As Double = (Math.Atan(newLoc.Y / newLoc.X)) / PI * CType(180, Double)
            Dim alpha As Double
            Dim beta As Double
            'If angle < 0 Then
            beta = angle + CType(30, Double)
            alpha = CType(150, Double) + angle
            'Else
            '    alpha = angle - 30
            '    beta = 150 - angle
            'End If
            Dim l As Double = Math.Sqrt(newLoc.X * newLoc.X + newLoc.Y * newLoc.Y)
            Dim isomX As Double = l * Math.Sin(To_Radians(alpha)) / Math.Sin(To_Radians(60))
            Dim isomY As Double = l * Math.Sin(To_Radians(beta)) / Math.Sin(To_Radians(60))
            isomX /= (CType(2.0, Double) * Sqrt_5_8)
            isomY /= (CType(2.0, Double) * Sqrt_5_8)
            If newLoc.X < 0 Then
                isomY *= -1
                isomX *= -1
            End If
            'If newLoc.Y > 0 Then
            '    isomX *= -1
            'End If
            Try
                mouseGridPos.X = CType(isomX, Integer)
                mouseGridPos.Y = CType(isomY, Integer)
            Catch ex As System.OverflowException
                mouseGridPos.X = 0
                mouseGridPos.Y = 0
            End Try

            Dim strX = "Anchor"
            Dim strY = "Anchor"
            Select Case mouseGridPos.X
                Case Is < 0
                    strX &= " - " & Math.Abs(mouseGridPos.X)
                Case Is > 0
                    strX &= " + " & mouseGridPos.X
            End Select

            Select Case mouseGridPos.Y
                Case Is < 0
                    strY &= " - " & Math.Abs(mouseGridPos.Y)
                Case Is > 0
                    strY &= " + " & mouseGridPos.Y
            End Select

            ToolStripStatusLabel1.Text = "Current cell: {X = " & strX & ", Y = " & strY & "}"
        Else
            ToolStripStatusLabel1.Text = "Select the obstacles"
        End If
    End Sub

    Private Sub pnlImage_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlImage.Paint
        ' Translate to the scroll bar position
        e.Graphics.TranslateTransform(Me.pnlImage.AutoScrollPosition.X, Me.pnlImage.AutoScrollPosition.Y)
        ' Draw the pre-calculated image
        e.Graphics.DrawImage(currentImage, 0, 0)
    End Sub

    Private Sub tsbShiftLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbShiftLeft.Click
        bOffSet = True
        tsbShiftLeft.Enabled = False
        tsbShiftRight.Enabled = True
        DrawPanel()
        pnlImage.Invalidate()
    End Sub

    Private Sub tsbShiftRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbShiftRight.Click
        bOffSet = False
        tsbShiftLeft.Enabled = True
        tsbShiftRight.Enabled = False
        DrawPanel()
        pnlImage.Invalidate()
    End Sub

    Private Sub SelectObstacles_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DrawPanel()
    End Sub
End Class