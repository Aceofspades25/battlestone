<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlObject
    Inherits TileEditor

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnSelectSprite = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbxTileName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbxDimension = New System.Windows.Forms.TextBox
        Me.tbxTopLeft = New System.Windows.Forms.TextBox
        Me.tbxImageFile = New System.Windows.Forms.TextBox
        Me.tbxTileID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbxTileType = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.ddlGroup = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtgObstacles = New System.Windows.Forms.DataGridView
        Me.RelativeX = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RelativeY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cbxAnimated = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.dtgAnimated = New System.Windows.Forms.DataGridView
        Me.FrameNum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TopLeft = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Dimension = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnSelectObstacles = New System.Windows.Forms.Button
        Me.btnAddFrame = New System.Windows.Forms.Button
        Me.btnDeleteFrame = New System.Windows.Forms.Button
        Me.pnlPreview = New BattleEdit.CustomPanel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dtgObstacles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dtgAnimated, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelectSprite
        '
        Me.btnSelectSprite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectSprite.Location = New System.Drawing.Point(248, 173)
        Me.btnSelectSprite.Name = "btnSelectSprite"
        Me.btnSelectSprite.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectSprite.TabIndex = 32
        Me.btnSelectSprite.Text = "Select sprite"
        Me.btnSelectSprite.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 14)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Tile name:"
        '
        'tbxTileName
        '
        Me.tbxTileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTileName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTileName.Location = New System.Drawing.Point(99, 90)
        Me.tbxTileName.Name = "tbxTileName"
        Me.tbxTileName.Size = New System.Drawing.Size(142, 22)
        Me.tbxTileName.TabIndex = 29
        Me.tbxTileName.Text = "Barrel 1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 14)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Group:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 14)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Dimension:"
        '
        'tbxDimension
        '
        Me.tbxDimension.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxDimension.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDimension.Location = New System.Drawing.Point(100, 174)
        Me.tbxDimension.Name = "tbxDimension"
        Me.tbxDimension.ReadOnly = True
        Me.tbxDimension.Size = New System.Drawing.Size(142, 22)
        Me.tbxDimension.TabIndex = 25
        '
        'tbxTopLeft
        '
        Me.tbxTopLeft.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTopLeft.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTopLeft.Location = New System.Drawing.Point(99, 146)
        Me.tbxTopLeft.Name = "tbxTopLeft"
        Me.tbxTopLeft.ReadOnly = True
        Me.tbxTopLeft.Size = New System.Drawing.Size(142, 22)
        Me.tbxTopLeft.TabIndex = 24
        '
        'tbxImageFile
        '
        Me.tbxImageFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxImageFile.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxImageFile.Location = New System.Drawing.Point(100, 118)
        Me.tbxImageFile.Name = "tbxImageFile"
        Me.tbxImageFile.ReadOnly = True
        Me.tbxImageFile.Size = New System.Drawing.Size(142, 22)
        Me.tbxImageFile.TabIndex = 23
        '
        'tbxTileID
        '
        Me.tbxTileID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTileID.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTileID.Location = New System.Drawing.Point(100, 8)
        Me.tbxTileID.Name = "tbxTileID"
        Me.tbxTileID.ReadOnly = True
        Me.tbxTileID.Size = New System.Drawing.Size(142, 22)
        Me.tbxTileID.TabIndex = 22
        Me.tbxTileID.Text = "1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Top left:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 14)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Image file:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 14)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Tile ID:"
        '
        'tbxTileType
        '
        Me.tbxTileType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTileType.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTileType.Location = New System.Drawing.Point(99, 36)
        Me.tbxTileType.Name = "tbxTileType"
        Me.tbxTileType.ReadOnly = True
        Me.tbxTileType.Size = New System.Drawing.Size(142, 22)
        Me.tbxTileType.TabIndex = 33
        Me.tbxTileType.Text = "Object"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 14)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Tile type:"
        '
        'ddlGroup
        '
        Me.ddlGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddlGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlGroup.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlGroup.FormattingEnabled = True
        Me.ddlGroup.Location = New System.Drawing.Point(99, 65)
        Me.ddlGroup.Name = "ddlGroup"
        Me.ddlGroup.Size = New System.Drawing.Size(143, 22)
        Me.ddlGroup.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 5)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 14)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Obstacles:"
        '
        'dtgObstacles
        '
        Me.dtgObstacles.AllowUserToAddRows = False
        Me.dtgObstacles.AllowUserToDeleteRows = False
        Me.dtgObstacles.AllowUserToResizeColumns = False
        Me.dtgObstacles.AllowUserToResizeRows = False
        Me.dtgObstacles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgObstacles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RelativeX, Me.RelativeY})
        Me.dtgObstacles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgObstacles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgObstacles.Location = New System.Drawing.Point(0, 25)
        Me.dtgObstacles.Margin = New System.Windows.Forms.Padding(0)
        Me.dtgObstacles.MultiSelect = False
        Me.dtgObstacles.Name = "dtgObstacles"
        Me.dtgObstacles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgObstacles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgObstacles.ShowEditingIcon = False
        Me.dtgObstacles.Size = New System.Drawing.Size(439, 96)
        Me.dtgObstacles.TabIndex = 37
        '
        'RelativeX
        '
        Me.RelativeX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.RelativeX.FillWeight = 50.0!
        Me.RelativeX.HeaderText = "Relative X"
        Me.RelativeX.Name = "RelativeX"
        '
        'RelativeY
        '
        Me.RelativeY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.RelativeY.FillWeight = 50.0!
        Me.RelativeY.HeaderText = "Relative Y"
        Me.RelativeY.Name = "RelativeY"
        '
        'cbxAnimated
        '
        Me.cbxAnimated.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxAnimated.AutoSize = True
        Me.cbxAnimated.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAnimated.Location = New System.Drawing.Point(0, 124)
        Me.cbxAnimated.Margin = New System.Windows.Forms.Padding(0)
        Me.cbxAnimated.Name = "cbxAnimated"
        Me.cbxAnimated.Size = New System.Drawing.Size(85, 18)
        Me.cbxAnimated.TabIndex = 38
        Me.cbxAnimated.Text = "Animated"
        Me.cbxAnimated.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dtgAnimated, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxAnimated, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtgObstacles, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(13, 199)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(439, 243)
        Me.TableLayoutPanel1.TabIndex = 39
        '
        'dtgAnimated
        '
        Me.dtgAnimated.AllowUserToAddRows = False
        Me.dtgAnimated.AllowUserToResizeColumns = False
        Me.dtgAnimated.AllowUserToResizeRows = False
        Me.dtgAnimated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAnimated.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FrameNum, Me.TopLeft, Me.Dimension})
        Me.dtgAnimated.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgAnimated.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgAnimated.Location = New System.Drawing.Point(0, 146)
        Me.dtgAnimated.Margin = New System.Windows.Forms.Padding(0)
        Me.dtgAnimated.MultiSelect = False
        Me.dtgAnimated.Name = "dtgAnimated"
        Me.dtgAnimated.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgAnimated.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAnimated.ShowEditingIcon = False
        Me.dtgAnimated.Size = New System.Drawing.Size(439, 97)
        Me.dtgAnimated.TabIndex = 39
        '
        'FrameNum
        '
        Me.FrameNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.FrameNum.DataPropertyName = "FrameNum"
        Me.FrameNum.FillWeight = 1.0!
        Me.FrameNum.HeaderText = "Frame num"
        Me.FrameNum.Name = "FrameNum"
        '
        'TopLeft
        '
        Me.TopLeft.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TopLeft.DataPropertyName = "TopLeft"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.TopLeft.DefaultCellStyle = DataGridViewCellStyle1
        Me.TopLeft.FillWeight = 50.0!
        Me.TopLeft.HeaderText = "Top left"
        Me.TopLeft.Name = "TopLeft"
        '
        'Dimension
        '
        Me.Dimension.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Dimension.DataPropertyName = "Dimension"
        Me.Dimension.FillWeight = 50.0!
        Me.Dimension.HeaderText = "Dimension"
        Me.Dimension.Name = "Dimension"
        '
        'btnSelectObstacles
        '
        Me.btnSelectObstacles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectObstacles.Location = New System.Drawing.Point(329, 173)
        Me.btnSelectObstacles.Name = "btnSelectObstacles"
        Me.btnSelectObstacles.Size = New System.Drawing.Size(96, 23)
        Me.btnSelectObstacles.TabIndex = 40
        Me.btnSelectObstacles.Text = "Select obstacles"
        Me.btnSelectObstacles.UseVisualStyleBackColor = True
        '
        'btnAddFrame
        '
        Me.btnAddFrame.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAddFrame.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddFrame.Location = New System.Drawing.Point(376, 323)
        Me.btnAddFrame.Name = "btnAddFrame"
        Me.btnAddFrame.Size = New System.Drawing.Size(75, 19)
        Me.btnAddFrame.TabIndex = 41
        Me.btnAddFrame.Text = "Add frame"
        Me.btnAddFrame.UseVisualStyleBackColor = True
        '
        'btnDeleteFrame
        '
        Me.btnDeleteFrame.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnDeleteFrame.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteFrame.Location = New System.Drawing.Point(299, 323)
        Me.btnDeleteFrame.Name = "btnDeleteFrame"
        Me.btnDeleteFrame.Size = New System.Drawing.Size(75, 19)
        Me.btnDeleteFrame.TabIndex = 42
        Me.btnDeleteFrame.Text = "Delete frame"
        Me.btnDeleteFrame.UseVisualStyleBackColor = True
        '
        'pnlPreview
        '
        Me.pnlPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPreview.AutoScroll = True
        Me.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPreview.Location = New System.Drawing.Point(248, 8)
        Me.pnlPreview.Name = "pnlPreview"
        Me.pnlPreview.Size = New System.Drawing.Size(204, 160)
        Me.pnlPreview.TabIndex = 31
        '
        'Timer1
        '
        Me.Timer1.Interval = 25
        '
        'ctlObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnDeleteFrame)
        Me.Controls.Add(Me.btnAddFrame)
        Me.Controls.Add(Me.btnSelectObstacles)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ddlGroup)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbxTileType)
        Me.Controls.Add(Me.btnSelectSprite)
        Me.Controls.Add(Me.pnlPreview)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbxTileName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbxDimension)
        Me.Controls.Add(Me.tbxTopLeft)
        Me.Controls.Add(Me.tbxImageFile)
        Me.Controls.Add(Me.tbxTileID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ctlObject"
        Me.Size = New System.Drawing.Size(462, 445)
        CType(Me.dtgObstacles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dtgAnimated, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSelectSprite As System.Windows.Forms.Button
    Friend WithEvents pnlPreview As CustomPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbxTileName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbxDimension As System.Windows.Forms.TextBox
    Friend WithEvents tbxTopLeft As System.Windows.Forms.TextBox
    Friend WithEvents tbxImageFile As System.Windows.Forms.TextBox
    Friend WithEvents tbxTileID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbxTileType As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ddlGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtgObstacles As System.Windows.Forms.DataGridView
    Friend WithEvents cbxAnimated As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dtgAnimated As System.Windows.Forms.DataGridView
    Friend WithEvents RelativeX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RelativeY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSelectObstacles As System.Windows.Forms.Button
    Friend WithEvents FrameNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TopLeft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dimension As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAddFrame As System.Windows.Forms.Button
    Friend WithEvents btnDeleteFrame As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
