<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlFloor
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
        Me.btnSelectObstacles = New System.Windows.Forms.Button
        Me.ddlGroup = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnSelectSprite = New System.Windows.Forms.Button
        Me.pnlPreview = New BattleEdit.CustomPanel
        Me.pbPreview = New System.Windows.Forms.PictureBox
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.tbxDimensionR = New System.Windows.Forms.TextBox
        Me.tbxTopLeftR = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.tbxTopLeftL = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnSelectImageR = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnSelectImageL = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbxDimensionL = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.dtgObstacles = New System.Windows.Forms.DataGridView
        Me.RelativeX = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RelativeY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnNotes = New System.Windows.Forms.Button
        Me.pnlPreview.SuspendLayout()
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgObstacles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelectObstacles
        '
        Me.btnSelectObstacles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectObstacles.Location = New System.Drawing.Point(373, 174)
        Me.btnSelectObstacles.Name = "btnSelectObstacles"
        Me.btnSelectObstacles.Size = New System.Drawing.Size(96, 23)
        Me.btnSelectObstacles.TabIndex = 57
        Me.btnSelectObstacles.Text = "Select obstacles"
        Me.btnSelectObstacles.UseVisualStyleBackColor = True
        '
        'ddlGroup
        '
        Me.ddlGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddlGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlGroup.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlGroup.FormattingEnabled = True
        Me.ddlGroup.Location = New System.Drawing.Point(99, 66)
        Me.ddlGroup.Name = "ddlGroup"
        Me.ddlGroup.Size = New System.Drawing.Size(187, 22)
        Me.ddlGroup.TabIndex = 56
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 14)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Tile type:"
        '
        'btnSelectSprite
        '
        Me.btnSelectSprite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectSprite.Location = New System.Drawing.Point(292, 174)
        Me.btnSelectSprite.Name = "btnSelectSprite"
        Me.btnSelectSprite.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectSprite.TabIndex = 53
        Me.btnSelectSprite.Text = "Select sprite"
        Me.btnSelectSprite.UseVisualStyleBackColor = True
        '
        'pnlPreview
        '
        Me.pnlPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPreview.AutoScroll = True
        Me.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPreview.Controls.Add(Me.pbPreview)
        Me.pnlPreview.Location = New System.Drawing.Point(292, 9)
        Me.pnlPreview.Name = "pnlPreview"
        Me.pnlPreview.Size = New System.Drawing.Size(204, 160)
        Me.pnlPreview.TabIndex = 52
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
        Me.Label6.Location = New System.Drawing.Point(12, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 14)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Tile name:"
        '
        'tbxTileName
        '
        Me.tbxTileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTileName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTileName.Location = New System.Drawing.Point(99, 91)
        Me.tbxTileName.Name = "tbxTileName"
        Me.tbxTileName.Size = New System.Drawing.Size(186, 22)
        Me.tbxTileName.TabIndex = 50
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 14)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Group:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 14)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Dimension:"
        '
        'tbxDimension
        '
        Me.tbxDimension.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxDimension.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDimension.Location = New System.Drawing.Point(100, 175)
        Me.tbxDimension.Name = "tbxDimension"
        Me.tbxDimension.ReadOnly = True
        Me.tbxDimension.Size = New System.Drawing.Size(186, 22)
        Me.tbxDimension.TabIndex = 47
        '
        'tbxTopLeft
        '
        Me.tbxTopLeft.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTopLeft.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTopLeft.Location = New System.Drawing.Point(99, 147)
        Me.tbxTopLeft.Name = "tbxTopLeft"
        Me.tbxTopLeft.ReadOnly = True
        Me.tbxTopLeft.Size = New System.Drawing.Size(186, 22)
        Me.tbxTopLeft.TabIndex = 46
        '
        'tbxImageFile
        '
        Me.tbxImageFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxImageFile.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxImageFile.Location = New System.Drawing.Point(100, 119)
        Me.tbxImageFile.Name = "tbxImageFile"
        Me.tbxImageFile.ReadOnly = True
        Me.tbxImageFile.Size = New System.Drawing.Size(186, 22)
        Me.tbxImageFile.TabIndex = 45
        '
        'tbxTileID
        '
        Me.tbxTileID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTileID.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTileID.Location = New System.Drawing.Point(100, 9)
        Me.tbxTileID.Name = "tbxTileID"
        Me.tbxTileID.ReadOnly = True
        Me.tbxTileID.Size = New System.Drawing.Size(186, 22)
        Me.tbxTileID.TabIndex = 44
        Me.tbxTileID.Text = "1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Top left:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 14)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Image file:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 14)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Tile ID:"
        '
        'tbxTileType
        '
        Me.tbxTileType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTileType.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTileType.Location = New System.Drawing.Point(99, 37)
        Me.tbxTileType.Name = "tbxTileType"
        Me.tbxTileType.ReadOnly = True
        Me.tbxTileType.Size = New System.Drawing.Size(186, 22)
        Me.tbxTileType.TabIndex = 54
        Me.tbxTileType.Text = "Floor"
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
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbxTopLeftL, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbxDimensionL, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 2, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(10, 203)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(486, 80)
        Me.TableLayoutPanel1.TabIndex = 58
        '
        'tbxDimensionR
        '
        Me.tbxDimensionR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxDimensionR.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDimensionR.Location = New System.Drawing.Point(346, 53)
        Me.tbxDimensionR.Name = "tbxDimensionR"
        Me.tbxDimensionR.ReadOnly = True
        Me.tbxDimensionR.Size = New System.Drawing.Size(137, 22)
        Me.tbxDimensionR.TabIndex = 66
        Me.tbxDimensionR.Visible = False
        '
        'tbxTopLeftR
        '
        Me.tbxTopLeftR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTopLeftR.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTopLeftR.Location = New System.Drawing.Point(346, 28)
        Me.tbxTopLeftR.Name = "tbxTopLeftR"
        Me.tbxTopLeftR.ReadOnly = True
        Me.tbxTopLeftR.Size = New System.Drawing.Size(137, 22)
        Me.tbxTopLeftR.TabIndex = 65
        Me.tbxTopLeftR.Visible = False
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
        Me.Label13.Visible = False
        '
        'tbxTopLeftL
        '
        Me.tbxTopLeftL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTopLeftL.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTopLeftL.Location = New System.Drawing.Point(103, 28)
        Me.tbxTopLeftL.Name = "tbxTopLeftL"
        Me.tbxTopLeftL.ReadOnly = True
        Me.tbxTopLeftL.Size = New System.Drawing.Size(137, 22)
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.btnSelectImageR)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Location = New System.Drawing.Point(243, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(243, 25)
        Me.Panel2.TabIndex = 51
        Me.Panel2.Visible = False
        '
        'btnSelectImageR
        '
        Me.btnSelectImageR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectImageR.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectImageR.Location = New System.Drawing.Point(165, 4)
        Me.btnSelectImageR.Name = "btnSelectImageR"
        Me.btnSelectImageR.Size = New System.Drawing.Size(75, 19)
        Me.btnSelectImageR.TabIndex = 51
        Me.btnSelectImageR.Text = "Select image"
        Me.btnSelectImageR.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(111, 14)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Tile depth - right"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.btnSelectImageL)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(243, 25)
        Me.Panel1.TabIndex = 50
        '
        'btnSelectImageL
        '
        Me.btnSelectImageL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectImageL.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectImageL.Location = New System.Drawing.Point(165, 4)
        Me.btnSelectImageL.Name = "btnSelectImageL"
        Me.btnSelectImageL.Size = New System.Drawing.Size(75, 19)
        Me.btnSelectImageL.TabIndex = 50
        Me.btnSelectImageL.Text = "Select image"
        Me.btnSelectImageL.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 14)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Tile depth - left"
        '
        'tbxDimensionL
        '
        Me.tbxDimensionL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxDimensionL.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDimensionL.Location = New System.Drawing.Point(103, 53)
        Me.tbxDimensionL.Name = "tbxDimensionL"
        Me.tbxDimensionL.ReadOnly = True
        Me.tbxDimensionL.Size = New System.Drawing.Size(137, 22)
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
        Me.Label12.Location = New System.Drawing.Point(246, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 14)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Dimension:"
        Me.Label12.Visible = False
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 286)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 14)
        Me.Label14.TabIndex = 59
        Me.Label14.Text = "Obstacles:"
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
        Me.dtgObstacles.Location = New System.Drawing.Point(10, 306)
        Me.dtgObstacles.Margin = New System.Windows.Forms.Padding(0)
        Me.dtgObstacles.MultiSelect = False
        Me.dtgObstacles.Name = "dtgObstacles"
        Me.dtgObstacles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgObstacles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgObstacles.ShowEditingIcon = False
        Me.dtgObstacles.Size = New System.Drawing.Size(486, 117)
        Me.dtgObstacles.TabIndex = 60
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
        'btnNotes
        '
        Me.btnNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotes.Location = New System.Drawing.Point(418, 285)
        Me.btnNotes.Name = "btnNotes"
        Me.btnNotes.Size = New System.Drawing.Size(75, 19)
        Me.btnNotes.TabIndex = 61
        Me.btnNotes.Text = "Notes!"
        Me.btnNotes.UseVisualStyleBackColor = True
        '
        'ctlFloor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnNotes)
        Me.Controls.Add(Me.dtgObstacles)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnSelectObstacles)
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
        Me.Name = "ctlFloor"
        Me.Size = New System.Drawing.Size(510, 435)
        Me.pnlPreview.ResumeLayout(False)
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtgObstacles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSelectObstacles As System.Windows.Forms.Button
    Friend WithEvents ddlGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSelectSprite As System.Windows.Forms.Button
    Friend WithEvents pnlPreview As BattleEdit.CustomPanel
    Friend WithEvents pbPreview As System.Windows.Forms.PictureBox
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
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnSelectImageR As System.Windows.Forms.Button
    Friend WithEvents btnSelectImageL As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbxTopLeftL As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbxDimensionL As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbxDimensionR As System.Windows.Forms.TextBox
    Friend WithEvents tbxTopLeftR As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtgObstacles As System.Windows.Forms.DataGridView
    Friend WithEvents RelativeX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RelativeY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnNotes As System.Windows.Forms.Button

End Class
