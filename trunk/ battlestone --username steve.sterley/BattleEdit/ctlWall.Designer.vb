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
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbxTopLeftL = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnSelectSideR = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnSelectSideL = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbxDimensionL = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbxWallLeftLocation = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.SelectWallRight = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btnSelectWallLeft = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.tbxWallLeftDimension = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.btnSelectTopR = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.btnSelectTopL = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.tbxWallLength = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        CType(Me.dtgObstacles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlPreview.SuspendLayout()
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
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
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox1, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox2, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.tbxTopLeftL, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.tbxDimensionL, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 2, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(12, 258)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(496, 80)
        Me.TableLayoutPanel2.TabIndex = 79
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(351, 53)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(142, 22)
        Me.TextBox1.TabIndex = 66
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(351, 28)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(142, 22)
        Me.TextBox2.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(251, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Top left:"
        '
        'tbxTopLeftL
        '
        Me.tbxTopLeftL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTopLeftL.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTopLeftL.Location = New System.Drawing.Point(103, 28)
        Me.tbxTopLeftL.Name = "tbxTopLeftL"
        Me.tbxTopLeftL.ReadOnly = True
        Me.tbxTopLeftL.Size = New System.Drawing.Size(142, 22)
        Me.tbxTopLeftL.TabIndex = 60
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 14)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "Top left:"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.btnSelectSideR)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Location = New System.Drawing.Point(248, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(248, 25)
        Me.Panel2.TabIndex = 51
        '
        'btnSelectSideR
        '
        Me.btnSelectSideR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectSideR.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectSideR.Location = New System.Drawing.Point(170, 4)
        Me.btnSelectSideR.Name = "btnSelectSideR"
        Me.btnSelectSideR.Size = New System.Drawing.Size(75, 19)
        Me.btnSelectSideR.TabIndex = 51
        Me.btnSelectSideR.Text = "Select image"
        Me.btnSelectSideR.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(146, 14)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Side wall depth - right"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.btnSelectSideL)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(248, 25)
        Me.Panel1.TabIndex = 50
        '
        'btnSelectSideL
        '
        Me.btnSelectSideL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectSideL.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectSideL.Location = New System.Drawing.Point(170, 4)
        Me.btnSelectSideL.Name = "btnSelectSideL"
        Me.btnSelectSideL.Size = New System.Drawing.Size(75, 19)
        Me.btnSelectSideL.TabIndex = 50
        Me.btnSelectSideL.Text = "Select image"
        Me.btnSelectSideL.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(137, 14)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Side wall depth - left"
        '
        'tbxDimensionL
        '
        Me.tbxDimensionL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxDimensionL.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDimensionL.Location = New System.Drawing.Point(103, 53)
        Me.tbxDimensionL.Name = "tbxDimensionL"
        Me.tbxDimensionL.ReadOnly = True
        Me.tbxDimensionL.Size = New System.Drawing.Size(142, 22)
        Me.tbxDimensionL.TabIndex = 61
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 14)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "Dimension:"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(251, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 14)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Dimension:"
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
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxWallLeftLocation, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel3, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxWallLeftDimension, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label18, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label19, 2, 2)
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
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(251, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 14)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Top left:"
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
        Me.Panel3.Controls.Add(Me.SelectWallRight)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(248, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(248, 25)
        Me.Panel3.TabIndex = 51
        '
        'SelectWallRight
        '
        Me.SelectWallRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectWallRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectWallRight.Location = New System.Drawing.Point(170, 4)
        Me.SelectWallRight.Name = "SelectWallRight"
        Me.SelectWallRight.Size = New System.Drawing.Size(75, 19)
        Me.SelectWallRight.TabIndex = 51
        Me.SelectWallRight.Text = "Select image"
        Me.SelectWallRight.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 14)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Wall - right"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.btnSelectWallLeft)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(248, 25)
        Me.Panel4.TabIndex = 50
        '
        'btnSelectWallLeft
        '
        Me.btnSelectWallLeft.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectWallLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectWallLeft.Location = New System.Drawing.Point(170, 4)
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
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(251, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 14)
        Me.Label19.TabIndex = 63
        Me.Label19.Text = "Dimension:"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.TextBox7, 3, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.TextBox8, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label20, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.TextBox9, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label21, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel5, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel6, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TextBox10, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Label24, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Label25, 2, 2)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(12, 339)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(496, 80)
        Me.TableLayoutPanel4.TabIndex = 84
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(351, 53)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(142, 22)
        Me.TextBox7.TabIndex = 66
        '
        'TextBox8
        '
        Me.TextBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(351, 28)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(142, 22)
        Me.TextBox8.TabIndex = 65
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(251, 30)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 14)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "Top left:"
        '
        'TextBox9
        '
        Me.TextBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(103, 28)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(142, 22)
        Me.TextBox9.TabIndex = 60
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(3, 30)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 14)
        Me.Label21.TabIndex = 59
        Me.Label21.Text = "Top left:"
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.SetColumnSpan(Me.Panel5, 2)
        Me.Panel5.Controls.Add(Me.btnSelectTopR)
        Me.Panel5.Controls.Add(Me.Label22)
        Me.Panel5.Location = New System.Drawing.Point(248, 0)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(248, 25)
        Me.Panel5.TabIndex = 51
        '
        'btnSelectTopR
        '
        Me.btnSelectTopR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectTopR.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectTopR.Location = New System.Drawing.Point(170, 4)
        Me.btnSelectTopR.Name = "btnSelectTopR"
        Me.btnSelectTopR.Size = New System.Drawing.Size(75, 19)
        Me.btnSelectTopR.TabIndex = 51
        Me.btnSelectTopR.Text = "Select image"
        Me.btnSelectTopR.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(3, 5)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(142, 14)
        Me.Label22.TabIndex = 49
        Me.Label22.Text = "Top wall depth - right"
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.SetColumnSpan(Me.Panel6, 2)
        Me.Panel6.Controls.Add(Me.btnSelectTopL)
        Me.Panel6.Controls.Add(Me.Label23)
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(248, 25)
        Me.Panel6.TabIndex = 50
        '
        'btnSelectTopL
        '
        Me.btnSelectTopL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectTopL.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectTopL.Location = New System.Drawing.Point(170, 4)
        Me.btnSelectTopL.Name = "btnSelectTopL"
        Me.btnSelectTopL.Size = New System.Drawing.Size(75, 19)
        Me.btnSelectTopL.TabIndex = 50
        Me.btnSelectTopL.Text = "Select image"
        Me.btnSelectTopL.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(3, 5)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(133, 14)
        Me.Label23.TabIndex = 49
        Me.Label23.Text = "Top wall depth - left"
        '
        'TextBox10
        '
        Me.TextBox10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.Location = New System.Drawing.Point(103, 53)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(142, 22)
        Me.TextBox10.TabIndex = 61
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(3, 58)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 14)
        Me.Label24.TabIndex = 62
        Me.Label24.Text = "Dimension:"
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(251, 58)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(77, 14)
        Me.Label25.TabIndex = 63
        Me.Label25.Text = "Dimension:"
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
        Me.Controls.Add(Me.TableLayoutPanel4)
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
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbxTopLeftL As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSelectSideR As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSelectSideL As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbxDimensionL As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbxWallLeftLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents SelectWallRight As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnSelectWallLeft As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbxWallLeftDimension As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnSelectTopR As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnSelectTopL As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents tbxWallLength As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label

End Class
