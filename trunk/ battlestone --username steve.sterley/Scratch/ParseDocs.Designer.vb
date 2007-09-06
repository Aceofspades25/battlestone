<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParseDocs
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
        Me.btnExecute = New System.Windows.Forms.Button
        Me.tbxResults = New System.Windows.Forms.TextBox
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.tbxFolder = New System.Windows.Forms.TextBox
        Me.cbDataBase = New System.Windows.Forms.ComboBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.btnStop = New System.Windows.Forms.Button
        Me.btnDirectory = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnExecute
        '
        Me.btnExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExecute.Location = New System.Drawing.Point(342, 12)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(103, 23)
        Me.btnExecute.TabIndex = 0
        Me.btnExecute.Text = "Parse documents"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'tbxResults
        '
        Me.tbxResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxResults.BackColor = System.Drawing.Color.Black
        Me.tbxResults.ForeColor = System.Drawing.Color.White
        Me.tbxResults.Location = New System.Drawing.Point(12, 56)
        Me.tbxResults.Multiline = True
        Me.tbxResults.Name = "tbxResults"
        Me.tbxResults.ReadOnly = True
        Me.tbxResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbxResults.Size = New System.Drawing.Size(466, 191)
        Me.tbxResults.TabIndex = 1
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Select the folder from which to parse documents"
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.FolderBrowserDialog1.SelectedPath = "c:\inetpub\wwwroot\sbssys\documents\"
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'tbxFolder
        '
        Me.tbxFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxFolder.BackColor = System.Drawing.SystemColors.Window
        Me.tbxFolder.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.tbxFolder.Location = New System.Drawing.Point(45, 14)
        Me.tbxFolder.Name = "tbxFolder"
        Me.tbxFolder.ReadOnly = True
        Me.tbxFolder.Size = New System.Drawing.Size(213, 19)
        Me.tbxFolder.TabIndex = 3
        '
        'cbDataBase
        '
        Me.cbDataBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDataBase.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDataBase.FormattingEnabled = True
        Me.cbDataBase.Items.AddRange(New Object() {"NSCSBS", "(local)"})
        Me.cbDataBase.Location = New System.Drawing.Point(264, 13)
        Me.cbDataBase.Name = "cbDataBase"
        Me.cbDataBase.Size = New System.Drawing.Size(72, 20)
        Me.cbDataBase.TabIndex = 4
        Me.cbDataBase.Text = "NSCSBS"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 253)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(466, 23)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Document no:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(104, 40)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 7
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.Image = Global.Scratch.My.Resources.Resources.close
        Me.btnStop.Location = New System.Drawing.Point(451, 12)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(27, 23)
        Me.btnStop.TabIndex = 8
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnDirectory
        '
        Me.btnDirectory.Image = Global.Scratch.My.Resources.Resources.open
        Me.btnDirectory.Location = New System.Drawing.Point(12, 12)
        Me.btnDirectory.Name = "btnDirectory"
        Me.btnDirectory.Size = New System.Drawing.Size(27, 23)
        Me.btnDirectory.TabIndex = 2
        Me.btnDirectory.UseVisualStyleBackColor = True
        '
        'ParseDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 288)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.cbDataBase)
        Me.Controls.Add(Me.tbxFolder)
        Me.Controls.Add(Me.btnDirectory)
        Me.Controls.Add(Me.tbxResults)
        Me.Controls.Add(Me.btnExecute)
        Me.Name = "ParseDocs"
        Me.Text = "Parse SBS documents"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents tbxResults As System.Windows.Forms.TextBox
    Friend WithEvents btnDirectory As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents tbxFolder As System.Windows.Forms.TextBox
    Friend WithEvents cbDataBase As System.Windows.Forms.ComboBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnStop As System.Windows.Forms.Button

End Class
