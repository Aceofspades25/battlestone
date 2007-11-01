Public Class SelectSprite
    Dim DragStart As Point '= New Point(0, 0)
    Dim DragSize As New Size(0, 0)
    Dim actualStart As Point '= New Point(0, 0)
    Dim actualSize As New Size(0, 0)
    Dim _sizeConstraint As Size = Nothing
    Dim fName As String
    Dim bm As Bitmap            ' Stores the background image

    Public Property TileStart() As Point
        Get
            Return actualStart
        End Get
        Set(ByVal value As Point)
            actualStart = value
        End Set
    End Property

    Public Property TileSize() As Size
        Get
            Return actualSize
        End Get
        Set(ByVal value As Size)
            actualSize = value
        End Set
    End Property

    Public Property ImageFile() As String
        Get
            Return fName
        End Get
        Set(ByVal value As String)
            fName = value
        End Set
    End Property

    Public Property SizeConstraint() As Size
        Get
            Return _sizeConstraint
        End Get
        Set(ByVal value As Size)
            _sizeConstraint = value
        End Set
    End Property

    Private Sub Load_Image(ByVal fName As String)
        Me.fName = fName
        Dim b As New System.Drawing.Bitmap(fName)
        b.MakeTransparent(Color.FromArgb(100, 255, 0, 255))

        bm = New Bitmap(b.Width, b.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        g.FillRectangle(Brushes.Black, New RectangleF(0, 0, bm.Width, bm.Height))
        g.DrawImage(b, 0, 0)        
    End Sub

    Private Sub Calculate_Actuals()
        actualStart = DragStart
        actualSize = DragSize
        If DragSize.Width < 0 Then
            actualStart.X = DragStart.X + DragSize.Width
            actualSize.Width = -1 * DragSize.Width
        End If
        If DragSize.Height < 0 Then
            actualStart.Y = DragStart.Y + DragSize.Height
            actualSize.Height = -1 * DragSize.Height
        End If
    End Sub

    Private Sub Update_Status()
        If actualSize.Width <> 0 And actualSize.Height <> 0 Then
            Me.ToolStripStatusLabel1.Text = "Selection top left: " & actualStart.X & ", " & actualStart.Y & _
            ". Bounding rectangle size: " & actualSize.Width & " x " & actualSize.Height
        Else
            Me.ToolStripStatusLabel1.Text = "Select an area"
        End If
    End Sub

    Private Sub SelectSprite_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.AcceptButton = btnOkay
        'Me.CancelButton = btnCancel
        Me.OpenFileDialog1.InitialDirectory = My.Application.Info.DirectoryPath & "\Sprites\"
        If fName Is Nothing AndAlso Me.OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Load_Image(Me.OpenFileDialog1.FileName)
        ElseIf Not fName Is Nothing Then
            Load_Image(fName)
        Else
            Me.Close()
            Return
        End If
        Me.pnlImage.AutoScrollMinSize = New Size(bm.Width, bm.Height)
    End Sub

    Private Sub pnlImage_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlImage.MouseDown
        If DragStart = Nothing Then DragStart = New Point()
        DragStart.X = e.X - Me.pnlImage.AutoScrollPosition.X
        DragStart.Y = e.Y - Me.pnlImage.AutoScrollPosition.Y
        DragSize.Width = 0
        DragSize.Height = 0
        Calculate_Actuals()
        ' Now make DragStart a factor of 32
        DragStart.X = CType((DragStart.X / 32), Integer) * 32
        DragStart.Y = CType((DragStart.Y / 32), Integer) * 32
        If DragStart.X > bm.Width Then DragStart.X = bm.Width
        If DragStart.Y > bm.Height Then DragStart.Y = bm.Height
        pnlImage.Invalidate()
        Update_Status()
    End Sub

    Private Sub pnlImage_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlImage.MouseMove
        If DragStart = Nothing Then Return
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim oldSize As Size = DragSize
            DragSize.Width = Math.Max(Math.Min(e.X - Me.pnlImage.AutoScrollPosition.X, bm.Width), 0) - DragStart.X
            DragSize.Height = Math.Max(Math.Min(e.Y - Me.pnlImage.AutoScrollPosition.Y, bm.Height), 0) - DragStart.Y
            DragSize.Width = CType((DragSize.Width / 32), Integer) * 32
            DragSize.Height = CType((DragSize.Height / 32), Integer) * 32
            Calculate_Actuals()
            If (DragSize <> oldSize) Then
                pnlImage.Invalidate()
                Update_Status()
            End If
        End If
    End Sub

    Private Sub pnlImage_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlImage.Paint
        Dim g As Graphics = e.Graphics
        Me.pnlImage.SuspendLayout()
        If pnlImage.Width > bm.Width Then
            g.FillRectangle(Brushes.Black, New RectangleF(bm.Width, 0, pnlImage.Width - bm.Width, pnlImage.Height))
        End If
        If pnlImage.Height > bm.Height Then
            g.FillRectangle(Brushes.Black, New RectangleF(0, bm.Height, pnlImage.Width, pnlImage.Height - bm.Height))
        End If
        e.Graphics.TranslateTransform(Me.pnlImage.AutoScrollPosition.X, Me.pnlImage.AutoScrollPosition.Y)
        e.Graphics.DrawImage(bm, New Point(0, 0))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(100, 0, 0, 200)), New Rectangle(actualStart.X, actualStart.Y, actualSize.Width, actualSize.Height))
        e.Graphics.DrawRectangle(New Pen(Color.Blue, 2), New Rectangle(actualStart.X, actualStart.Y, actualSize.Width, actualSize.Height))
        Me.pnlImage.ResumeLayout()
    End Sub

    Private Sub btnOkay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOkay.Click
        ' Check that the selected area is  equal to the constraint if there is one
        If Not _sizeConstraint = Nothing Then
            If actualSize.Width <> _sizeConstraint.Width * 32 Or actualSize.Height <> _sizeConstraint.Height * 32 Then
                MessageBox.Show("The selected image must be the following size: (" & _sizeConstraint.Width * 32 & "x" & _sizeConstraint.Height * 32 & ")", "Invalid selection size", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.DialogResult = Windows.Forms.DialogResult.None
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

    End Sub
End Class