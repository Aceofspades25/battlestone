<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreviewSprite
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreviewSprite))
        Me.pnlPreview = New BattleEdit.CustomPanel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'pnlPreview
        '
        Me.pnlPreview.AutoScroll = True
        Me.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPreview.Location = New System.Drawing.Point(0, 0)
        Me.pnlPreview.Name = "pnlPreview"
        Me.pnlPreview.Size = New System.Drawing.Size(284, 264)
        Me.pnlPreview.TabIndex = 32
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'PreviewSprite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.pnlPreview)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PreviewSprite"
        Me.Text = "Preview sprite"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlPreview As BattleEdit.CustomPanel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
