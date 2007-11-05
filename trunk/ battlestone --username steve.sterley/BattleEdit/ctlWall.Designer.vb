<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlWall
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
        Me.dtgObstacles = New System.Windows.Forms.DataGridView
        Me.RelativeX = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RelativeY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label14 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.tbxDimensionR = New System.Windows.Forms.TextBox
        Me.tbxTopLeftR = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnNotes = New System.Windows.Forms.Button
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.nudDepth = New System.Windows.Forms.NumericUpDown
        Me.cbxDepth = New System.Windows.Forms.CheckBox
        Me.tbxWallTopLocation = New System.Windows.Forms.TextBox
        Me.lblWallTopLocation = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnWallTopDepth = New System.Windows.Forms.Button
        Me.lblWallTopDepth = New System.Windows.Forms.Label
        Me.tbxWallTopDimension = New System.Windows.Forms.TextBox
        Me.lblWallTopDimension = New System.Windows.Forms.Label
        Me.lblDepth = New System.Windows.Forms.Label
        Me.cbxMirrored = New System.Windows.Forms.CheckBox
        Me.ddlGroup = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.tbxTileType = New System.Windows.Forms.TextBox
        Me.pnlPreview = New BattleEdit.CustomPanel
        Me.pbPreview = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbxTileName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbxImageFile = New System.Windows.Forms.TextBox
        Me.tbxTileID = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.tbxWallRightDimension = New System.Windows.Forms.TextBox
        Me.tbxWallRightLocation = New System.Windows.Forms.TextBox
        Me.lblWallRightLocation = New System.Windows.Forms.Label
        Me.tbxWallLeftLocation = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.btnDeleteWallRight = New System.Windows.Forms.Button
        Me.btnSelectWallRight = New System.Windows.Forms.Button
        Me.lblWallRight = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btnDeleteWallLeft = New System.Windows.Forms.Button
        Me.btnSelectWallLeft = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.tbxWallLeftDimension = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblWallRightDimension = New System.Windows.Forms.Label
        Me.tbxWallLength = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        CType(Me.dtgObstacles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.nudDepth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlPreview.SuspendLayout()
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgObstacles
        '
        Me.dtgObstacles.AllowUserToAddRows = False
        Me.dtgObstacles.AllowUserToDeleteRows = False
        Me.dtgObstacles.AllowUserToResizeColumns = False
        Me.dtgObstacles.AllowUserToResizeRows = False
        Me.dtgObstacles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgObstacles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgObstacles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RelativeX, Me.RelativeY})
        Me.dtgObstacles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgObstacles.Location = New System.Drawing.Point(44, 352)
        Me.dtgObstacles.Margin = New System.Windows.Forms.Padding(0)
        Me.dtgObstacles.MultiSelect = False
        Me.dtgObstacles.Name = "dtgObstacles"
        Me.dtgObstacles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgObstacles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgObstacles.ShowEditingIcon = False
        Me.dtgObstacles.Size = New System.Drawing.Size(486, 117)
        Me.dtgObstacles.TabIndex = 81
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
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(46, 332)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 14)
        Me.Label14.TabIndex = 80
        Me.Label14.Text = "Obstacles:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tbxDimensionR, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbxTopLeftR, 3, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'tbxDimensionR
        '
        Me.tbxDimensionR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxDimensionR.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDimensionR.Location = New System.Drawing.Point(203, 43)
        Me.tbxDimensionR.Name = "tbxDimensionR"
        Me.tbxDimensionR.ReadOnly = True
        Me.tbxDimensionR.Size = New System.Drawing.Size(1, 22)
        Me.tbxDimensionR.TabIndex = 66
        '
        'tbxTopLeftR
        '
        Me.tbxTopLeftR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTopLeftR.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTopLeftR.Location = New System.Drawing.Point(203, 23)
        Me.tbxTopLeftR.Name = "tbxTopLeftR"
        Me.tbxTopLeftR.ReadOnly = True
        Me.tbxTopLeftR.Size = New System.Drawing.Size(1, 22)
        Me.tbxTopLeftR.TabIndex = 65
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(246, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 14)
        Me.Label13.TabIndex = 64
        Me.Label13.Text = "Top left:"
        '
        'btnNotes
        '
        Me.btnNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotes.Location = New System.Drawing.Point(430, 427)
        Me.btnNotes.Name = "btnNotes"
        Me.btnNotes.Size = New System.Drawing.Size(75, 19)
        Me.btnNotes.TabIndex = 82
        Me.btnNotes.Text = "Notes!"
        Me.btnNotes.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.nudDepth, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.cbxDepth, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.tbxWallTopLocation, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblWallTopLocation, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.tbxWallTopDimension, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblWallTopDimension, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDepth, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.cbxMirrored, 2, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(12, 258)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(496, 80)
        Me.TableLayoutPanel2.TabIndex = 79
        '
        'nudDepth
        '
        Me.nudDepth.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudDepth.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudDepth.Location = New System.Drawing.Point(351, 54)
        Me.nudDepth.Maximum = New Decimal(New Integer() {32, 0, 0, 0})
        Me.nudDepth.Name = "nudDepth"
        Me.nudDepth.Size = New System.Drawing.Size(142, 22)
        Me.nudDepth.TabIndex = 87
        Me.nudDepth.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'cbxDepth
        '
        Me.cbxDepth.AutoSize = True
        Me.cbxDepth.Checked = True
        Me.cbxDepth.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbxDepth, 2)
        Me.cbxDepth.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDepth.Location = New System.Drawing.Point(251, 28)
        Me.cbxDepth.Name = "cbxDepth"
        Me.cbxDepth.Size = New System.Drawing.Size(136, 18)
        Me.cbxDepth.TabIndex = 68
        Me.cbxDepth.Text = "Walls have depth"
        Me.cbxDepth.UseVisualStyleBackColor = True
        '
        'tbxWallTopLocation
        '
        Me.tbxWallTopLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxWallTopLocation.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxWallTopLocation.Location = New System.Drawing.Point(103, 28)
        Me.tbxWallTopLocation.Name = "tbxWallTopLocation"
        Me.tbxWallTopLocation.ReadOnly = True
        Me.tbxWallTopLocation.Size = New System.Drawing.Size(142, 22)
        Me.tbxWallTopLocation.TabIndex = 60
        '
        'lblWallTopLocation
        '
        Me.lblWallTopLocation.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWallTopLocation.AutoSize = True
        Me.lblWallTopLocation.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWallTopLocation.Location = New System.Drawing.Point(3, 30)
        Me.lblWallTopLocation.Name = "lblWallTopLocation"
        Me.lblWallTopLocation.Size = New System.Drawing.Size(59, 14)
        Me.lblWallTopLocation.TabIndex = 59
        Me.lblWallTopLocation.Text = "Top left:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.btnWallTopDepth)
        Me.Panel1.Controls.Add(Me.lblWallTopDepth)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(248, 25)
        Me.Panel1.TabIndex = 50
        '
        'btnWallTopDepth
        '
        Me.btnWallTopDepth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWallTopDepth.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWallTopDepth.Location = New System.Drawing.Point(170, 4)
        Me.btnWallTopDepth.Name = "btnWallTopDepth"
        Me.btnWallTopDepth.Size = New System.Drawing.Size(75, 19)
        Me.btnWallTopDepth.TabIndex = 50
        Me.btnWallTopDepth.Text = "Select image"
        Me.btnWallTopDepth.UseVisualStyleBackColor = True
        '
        'lblWallTopDepth
        '
        Me.lblWallTopDepth.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWallTopDepth.AutoSize = True
        Me.lblWallTopDepth.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWallTopDepth.Location = New System.Drawing.Point(3, 5)
        Me.lblWallTopDepth.Name = "lblWallTopDepth"
        Me.lblWallTopDepth.Size = New System.Drawing.Size(100, 14)
        Me.lblWallTopDepth.TabIndex = 49
        Me.lblWallTopDepth.Text = "Wall top depth"
        '
        'tbxWallTopDimension
        '
        Me.tbxWallTopDimension.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxWallTopDimension.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxWallTopDimension.Location = New System.Drawing.Point(103, 53)
        Me.tbxWallTopDimension.Name = "tbxWallTopDimension"
        Me.tbxWallTopDimension.ReadOnly = True
        Me.tbxWallTopDimension.Size = New System.Drawing.Size(142, 22)
        Me.tbxWallTopDimension.TabIndex = 61
        '
        'lblWallTopDimension
        '
        Me.lblWallTopDimension.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWallTopDimension.AutoSize = True
        Me.lblWallTopDimension.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWallTopDimension.Location = New System.Drawing.Point(3, 58)
        Me.lblWallTopDimension.Name = "lblWallTopDimension"
        Me.lblWallTopDimension.Size = New System.Drawing.Size(77, 14)
        Me.lblWallTopDimension.TabIndex = 62
        Me.lblWallTopDimension.Text = "Dimension:"
        '
        'lblDepth
        '
        Me.lblDepth.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDepth.AutoSize = True
        Me.lblDepth.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepth.Location = New System.Drawing.Point(251, 58)
        Me.lblDepth.Name = "lblDepth"
        Me.lblDepth.Size = New System.Drawing.Size(79, 14)
        Me.lblDepth.TabIndex = 63
        Me.lblDepth.Text = "Depth (px):"
        '
        'cbxMirrored
        '
        Me.cbxMirrored.AutoSize = True
        Me.cbxMirrored.Checked = True
        Me.cbxMirrored.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbxMirrored, 2)
        Me.cbxMirrored.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMirrored.Location = New System.Drawing.Point(251, 3)
        Me.cbxMirrored.Name = "cbxMirrored"
        Me.cbxMirrored.Size = New System.Drawing.Size(159, 18)
        Me.cbxMirrored.TabIndex = 67
        Me.cbxMirrored.Text = "Right wall mirrors left"
        Me.cbxMirrored.UseVisualStyleBackColor = True
        '
        'ddlGroup
        '
        Me.ddlGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddlGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlGroup.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlGroup.FormattingEnabled = True
        Me.ddlGroup.Location = New System.Drawing.Point(101, 67)
        Me.ddlGroup.Name = "ddlGroup"
        Me.ddlGroup.Size = New System.Drawing.Size(197, 22)
        Me.ddlGroup.TabIndex = 77
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 14)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Tile type:"
        '
        'tbxTileType
        '
        Me.tbxTileType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTileType.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTileType.Location = New System.Drawing.Point(101, 38)
        Me.tbxTileType.Name = "tbxTileType"
        Me.tbxTileType.ReadOnly = True
        Me.tbxTileType.Size = New System.Drawing.Size(196, 22)
        Me.tbxTileType.TabIndex = 75
        Me.tbxTileType.Text = "Wall"
        '
        'pnlPreview
        '
        Me.pnlPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPreview.AutoScroll = True
        Me.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPreview.Controls.Add(Me.pbPreview)
        Me.pnlPreview.Location = New System.Drawing.Point(304, 10)
        Me.pnlPreview.Name = "pnlPreview"
        Me.pnlPreview.Size = New System.Drawing.Size(204, 160)
        Me.pnlPreview.TabIndex = 73
        '
        'pbPreview
        '
        Me.pbPreview.BackColor = System.Drawing.Color.Transparent
        Me.pbPreview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbPreview.Image = Global.BattleEdit.My.Resources.Resources.Preview
        Me.pbPreview.Location = New System.Drawing.Point(5, 5)
        Me.pbPreview.Name = "pbPreview"
        Me.pbPreview.Size = New System.Drawing.Size(30, 30)
        Me.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbPreview.TabIndex = 0
        Me.pbPreview.TabStop = False
        Me.pbPreview.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 14)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "Tile name:"
        '
        'tbxTileName
        '
        Me.tbxTileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTileName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTileName.Location = New System.Drawing.Point(101, 92)
        Me.tbxTileName.Name = "tbxTileName"
        Me.tbxTileName.Size = New System.Drawing.Size(196, 22)
        Me.tbxTileName.TabIndex = 71
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 14)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Group:"
        '
        'tbxImageFile
        '
        Me.tbxImageFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxImageFile.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxImageFile.Location = New System.Drawing.Point(102, 120)
        Me.tbxImageFile.Name = "tbxImageFile"
        Me.tbxImageFile.ReadOnly = True
        Me.tbxImageFile.Size = New System.Drawing.Size(196, 22)
        Me.tbxImageFile.TabIndex = 66
        '
        'tbxTileID
        '
        Me.tbxTileID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTileID.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTileID.Location = New System.Drawing.Point(102, 10)
        Me.tbxTileID.Name = "tbxTileID"
        Me.tbxTileID.ReadOnly = True
        Me.tbxTileID.Size = New System.Drawing.Size(196, 22)
        Me.tbxTileID.TabIndex = 65
        Me.tbxTileID.Text = "1"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 123)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 14)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "Image file:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 14)
        Me.Label16.TabIndex = 62
        Me.Label16.Text = "Tile ID:"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.tbxWallRightDimension, 3, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxWallRightLocation, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblWallRightLocation, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxWallLeftLocation, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel3, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxWallLeftDimension, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label18, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblWallRightDimension, 2, 2)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(12, 177)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(496, 80)
        Me.TableLayoutPanel3.TabIndex = 83
        '
        'tbxWallRightDimension
        '
        Me.tbxWallRightDimension.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxWallRightDimension.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxWallRightDimension.Location = New System.Drawing.Point(351, 53)
        Me.tbxWallRightDimension.Name = "tbxWallRightDimension"
        Me.tbxWallRightDimension.ReadOnly = True
        Me.tbxWallRightDimension.Size = New System.Drawing.Size(142, 22)
        Me.tbxWallRightDimension.TabIndex = 66
        '
        'tbxWallRightLocation
        '
        Me.tbxWallRightLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxWallRightLocation.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxWallRightLocation.Location = New System.Drawing.Point(351, 28)
        Me.tbxWallRightLocation.Name = "tbxWallRightLocation"
        Me.tbxWallRightLocation.ReadOnly = True
        Me.tbxWallRightLocation.Size = New System.Drawing.Size(142, 22)
        Me.tbxWallRightLocation.TabIndex = 65
        '
        'lblWallRightLocation
        '
        Me.lblWallRightLocation.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWallRightLocation.AutoSize = True
        Me.lblWallRightLocation.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWallRightLocation.Location = New System.Drawing.Point(251, 30)
        Me.lblWallRightLocation.Name = "lblWallRightLocation"
        Me.lblWallRightLocation.Size = New System.Drawing.Size(59, 14)
        Me.lblWallRightLocation.TabIndex = 64
        Me.lblWallRightLocation.Text = "Top left:"
        '
        'tbxWallLeftLocation
        '
        Me.tbxWallLeftLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxWallLeftLocation.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxWallLeftLocation.Location = New System.Drawing.Point(103, 28)
        Me.tbxWallLeftLocation.Name = "tbxWallLeftLocation"
        Me.tbxWallLeftLocation.ReadOnly = True
        Me.tbxWallLeftLocation.Size = New System.Drawing.Size(142, 22)
        Me.tbxWallLeftLocation.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Top left:"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.SetColumnSpan(Me.Panel3, 2)
        Me.Panel3.Controls.Add(Me.btnDeleteWallRight)
        Me.Panel3.Controls.Add(Me.btnSelectWallRight)
        Me.Panel3.Controls.Add(Me.lblWallRight)
        Me.Panel3.Location = New System.Drawing.Point(248, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(248, 25)
        Me.Panel3.TabIndex = 51
        '
        'btnDeleteWallRight
        '
        Me.btnDeleteWallRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteWallRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteWallRight.Image = Global.BattleEdit.My.Resources.Resources._cross
        Me.btnDeleteWallRight.Location = New System.Drawing.Point(226, 4)
        Me.btnDeleteWallRight.Name = "btnDeleteWallRight"
        Me.btnDeleteWallRight.Size = New System.Drawing.Size(19, 19)
        Me.btnDeleteWallRight.TabIndex = 52
        Me.btnDeleteWallRight.UseVisualStyleBackColor = True
        '
        'btnSelectWallRight
        '
        Me.btnSelectWallRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectWallRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectWallRight.Location = New System.Drawing.Point(150, 4)
        Me.btnSelectWallRight.Name = "btnSelectWallRight"
        Me.btnSelectWallRight.Size = New System.Drawing.Size(75, 19)
        Me.btnSelectWallRight.TabIndex = 51
        Me.btnSelectWallRight.Text = "Select image"
        Me.btnSelectWallRight.UseVisualStyleBackColor = True
        '
        'lblWallRight
        '
        Me.lblWallRight.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWallRight.AutoSize = True
        Me.lblWallRight.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWallRight.Location = New System.Drawing.Point(3, 5)
        Me.lblWallRight.Name = "lblWallRight"
        Me.lblWallRight.Size = New System.Drawing.Size(76, 14)
        Me.lblWallRight.TabIndex = 49
        Me.lblWallRight.Text = "Wall - right"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.btnDeleteWallLeft)
        Me.Panel4.Controls.Add(Me.btnSelectWallLeft)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(248, 25)
        Me.Panel4.TabIndex = 50
        '
        'btnDeleteWallLeft
        '
        Me.btnDeleteWallLeft.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteWallLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteWallLeft.Image = Global.BattleEdit.My.Resources.Resources._cross
        Me.btnDeleteWallLeft.Location = New System.Drawing.Point(226, 4)
        Me.btnDeleteWallLeft.Name = "btnDeleteWallLeft"
        Me.btnDeleteWallLeft.Size = New System.Drawing.Size(19, 19)
        Me.btnDeleteWallLeft.TabIndex = 51
        Me.btnDeleteWallLeft.UseVisualStyleBackColor = True
        '
        'btnSelectWallLeft
        '
        Me.btnSelectWallLeft.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectWallLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectWallLeft.Location = New System.Drawing.Point(150, 4)
        Me.btnSelectWallLeft.Name = "btnSelectWallLeft"
        Me.btnSelectWallLeft.Size = New System.Drawing.Size(75, 19)
        Me.btnSelectWallLeft.TabIndex = 50
        Me.btnSelectWallLeft.Text = "Select image"
        Me.btnSelectWallLeft.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 14)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Wall - left"
        '
        'tbxWallLeftDimension
        '
        Me.tbxWallLeftDimension.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxWallLeftDimension.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxWallLeftDimension.Location = New System.Drawing.Point(103, 53)
        Me.tbxWallLeftDimension.Name = "tbxWallLeftDimension"
        Me.tbxWallLeftDimension.ReadOnly = True
        Me.tbxWallLeftDimension.Size = New System.Drawing.Size(142, 22)
        Me.tbxWallLeftDimension.TabIndex = 61
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 14)
        Me.Label18.TabIndex = 62
        Me.Label18.Text = "Dimension:"
        '
        'lblWallRightDimension
        '
        Me.lblWallRightDimension.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWallRightDimension.AutoSize = True
        Me.lblWallRightDimension.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWallRightDimension.Location = New System.Drawing.Point(251, 58)
        Me.lblWallRightDimension.Name = "lblWallRightDimension"
        Me.lblWallRightDimension.Size = New System.Drawing.Size(77, 14)
        Me.lblWallRightDimension.TabIndex = 63
        Me.lblWallRightDimension.Text = "Dimension:"
        '
        'tbxWallLength
        '
        Me.tbxWallLength.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxWallLength.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxWallLength.Location = New System.Drawing.Point(102, 148)
        Me.tbxWallLength.Name = "tbxWallLength"
        Me.tbxWallLength.ReadOnly = True
        Me.tbxWallLength.Size = New System.Drawing.Size(196, 22)
        Me.tbxWallLength.TabIndex = 85
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(14, 151)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(83, 14)
        Me.Label26.TabIndex = 86
        Me.Label26.Text = "Wall length:"
        '
        'ctlWall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.tbxWallLength)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.btnNotes)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.ddlGroup)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbxTileType)
        Me.Controls.Add(Me.pnlPreview)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbxTileName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbxImageFile)
        Me.Controls.Add(Me.tbxTileID)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Name = "ctlWall"
        Me.Size = New System.Drawing.Size(520, 458)
        CType(Me.dtgObstacles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.nudDepth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlPreview.ResumeLayout(False)
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgObstacles As System.Windows.Forms.DataGridView
    Friend WithEvents RelativeX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RelativeY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbxDimensionR As System.Windows.Forms.TextBox
    Friend WithEvents tbxTopLeftR As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnNotes As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbxWallTopLocation As System.Windows.Forms.TextBox
    Friend WithEvents lblWallTopLocation As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnWallTopDepth As System.Windows.Forms.Button
    Friend WithEvents lblWallTopDepth As System.Windows.Forms.Label
    Friend WithEvents tbxWallTopDimension As System.Windows.Forms.TextBox
    Friend WithEvents lblWallTopDimension As System.Windows.Forms.Label
    Friend WithEvents ddlGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbxTileType As System.Windows.Forms.TextBox
    Friend WithEvents pnlPreview As BattleEdit.CustomPanel
    Friend WithEvents pbPreview As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbxTileName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbxImageFile As System.Windows.Forms.TextBox
    Friend WithEvents tbxTileID As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbxWallRightDimension As System.Windows.Forms.TextBox
    Friend WithEvents tbxWallRightLocation As System.Windows.Forms.TextBox
    Friend WithEvents lblWallRightLocation As System.Windows.Forms.Label
    Friend WithEvents tbxWallLeftLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnSelectWallRight As System.Windows.Forms.Button
    Friend WithEvents lblWallRight As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnSelectWallLeft As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbxWallLeftDimension As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblWallRightDimension As System.Windows.Forms.Label
    Friend WithEvents tbxWallLength As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cbxMirrored As System.Windows.Forms.CheckBox
    Friend WithEvents lblDepth As System.Windows.Forms.Label
    Friend WithEvents cbxDepth As System.Windows.Forms.CheckBox
    Friend WithEvents nudDepth As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnDeleteWallLeft As System.Windows.Forms.Button
    Friend WithEvents btnDeleteWallRight As System.Windows.Forms.Button

End Class
