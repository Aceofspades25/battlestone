<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Test
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Test))
        Me.pnlData = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.Label13 = New System.Windows.Forms.Label
        Me.tbxNumFights = New System.Windows.Forms.TextBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.rbAnyLevel1 = New System.Windows.Forms.RadioButton
        Me.tbxMLevel = New System.Windows.Forms.TextBox
        Me.rbRange = New System.Windows.Forms.RadioButton
        Me.rbSetLevel = New System.Windows.Forms.RadioButton
        Me.tbxLower = New System.Windows.Forms.TextBox
        Me.tbxUpper = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.rbAnyLevel2 = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnLeft = New System.Windows.Forms.Button
        Me.pnlMonster = New System.Windows.Forms.Panel
        Me.pbNext = New System.Windows.Forms.PictureBox
        Me.pbCurrent = New System.Windows.Forms.PictureBox
        Me.tbxCName = New System.Windows.Forms.TextBox
        Me.btnRight = New System.Windows.Forms.Button
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.tbxNextLevel = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.tbxPLevel = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.tbxName = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.tbxXP = New System.Windows.Forms.TextBox
        Me.tbxGold = New System.Windows.Forms.TextBox
        Me.tbxLocation = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.tbxAge = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbxAttack = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbxArmour = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbxHP = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.cbxTakeDamage = New System.Windows.Forms.CheckBox
        Me.cbxPauseDuringBattle = New System.Windows.Forms.CheckBox
        Me.cbxStopBefore = New System.Windows.Forms.CheckBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Sell = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.QuantityToSell = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlData.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlMonster.SuspendLayout()
        CType(Me.pbNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCurrent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlData
        '
        Me.pnlData.ColumnCount = 3
        Me.pnlData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.pnlData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlData.Controls.Add(Me.TableLayoutPanel4, 0, 2)
        Me.pnlData.Controls.Add(Me.PictureBox4, 2, 0)
        Me.pnlData.Controls.Add(Me.PictureBox3, 1, 0)
        Me.pnlData.Controls.Add(Me.PictureBox2, 0, 0)
        Me.pnlData.Controls.Add(Me.TableLayoutPanel2, 2, 1)
        Me.pnlData.Controls.Add(Me.Panel2, 1, 1)
        Me.pnlData.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.pnlData.Controls.Add(Me.Panel3, 1, 2)
        Me.pnlData.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlData.Location = New System.Drawing.Point(3, 3)
        Me.pnlData.Name = "pnlData"
        Me.pnlData.RowCount = 3
        Me.pnlData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.pnlData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.pnlData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlData.Size = New System.Drawing.Size(815, 204)
        Me.pnlData.TabIndex = 23
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label13, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.tbxNumFights, 1, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 174)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(321, 27)
        Me.TableLayoutPanel4.TabIndex = 27
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(0, 7)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "No fights:"
        '
        'tbxNumFights
        '
        Me.tbxNumFights.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxNumFights.Location = New System.Drawing.Point(73, 3)
        Me.tbxNumFights.Name = "tbxNumFights"
        Me.tbxNumFights.Size = New System.Drawing.Size(245, 18)
        Me.tbxNumFights.TabIndex = 28
        Me.tbxNumFights.Text = "20"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox4.Image = Global.HackPets.My.Resources.Resources.Level
        Me.PictureBox4.Location = New System.Drawing.Point(613, 0)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(75, 30)
        Me.PictureBox4.TabIndex = 24
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox3.Image = Global.HackPets.My.Resources.Resources.Monster
        Me.PictureBox3.Location = New System.Drawing.Point(351, 0)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(112, 30)
        Me.PictureBox3.TabIndex = 24
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox2.Image = Global.HackPets.My.Resources.Resources.Stats
        Me.PictureBox2.Location = New System.Drawing.Point(120, 0)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(86, 30)
        Me.PictureBox2.TabIndex = 23
        Me.PictureBox2.TabStop = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.rbAnyLevel1, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.tbxMLevel, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbRange, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.rbSetLevel, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.tbxLower, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.tbxUpper, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.rbAnyLevel2, 0, 3)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(490, 33)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(322, 124)
        Me.TableLayoutPanel2.TabIndex = 26
        '
        'rbAnyLevel1
        '
        Me.rbAnyLevel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbAnyLevel1.AutoSize = True
        Me.rbAnyLevel1.Checked = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.rbAnyLevel1, 4)
        Me.rbAnyLevel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAnyLevel1.ForeColor = System.Drawing.Color.White
        Me.rbAnyLevel1.Location = New System.Drawing.Point(3, 54)
        Me.rbAnyLevel1.Name = "rbAnyLevel1"
        Me.rbAnyLevel1.Size = New System.Drawing.Size(191, 17)
        Me.rbAnyLevel1.TabIndex = 25
        Me.rbAnyLevel1.TabStop = True
        Me.rbAnyLevel1.Text = "Any level available to me"
        Me.rbAnyLevel1.UseVisualStyleBackColor = True
        '
        'tbxMLevel
        '
        Me.tbxMLevel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.tbxMLevel, 3)
        Me.tbxMLevel.Location = New System.Drawing.Point(103, 3)
        Me.tbxMLevel.Name = "tbxMLevel"
        Me.tbxMLevel.Size = New System.Drawing.Size(216, 18)
        Me.tbxMLevel.TabIndex = 1
        '
        'rbRange
        '
        Me.rbRange.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbRange.AutoSize = True
        Me.rbRange.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRange.ForeColor = System.Drawing.Color.White
        Me.rbRange.Location = New System.Drawing.Point(3, 29)
        Me.rbRange.Name = "rbRange"
        Me.rbRange.Size = New System.Drawing.Size(69, 17)
        Me.rbRange.TabIndex = 1
        Me.rbRange.Text = "Range:"
        Me.rbRange.UseVisualStyleBackColor = True
        '
        'rbSetLevel
        '
        Me.rbSetLevel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbSetLevel.AutoSize = True
        Me.rbSetLevel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSetLevel.ForeColor = System.Drawing.Color.White
        Me.rbSetLevel.Location = New System.Drawing.Point(3, 4)
        Me.rbSetLevel.Name = "rbSetLevel"
        Me.rbSetLevel.Size = New System.Drawing.Size(86, 17)
        Me.rbSetLevel.TabIndex = 28
        Me.rbSetLevel.Text = "Set level:"
        Me.rbSetLevel.UseVisualStyleBackColor = True
        '
        'tbxLower
        '
        Me.tbxLower.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxLower.Location = New System.Drawing.Point(103, 28)
        Me.tbxLower.Name = "tbxLower"
        Me.tbxLower.Size = New System.Drawing.Size(95, 18)
        Me.tbxLower.TabIndex = 26
        '
        'tbxUpper
        '
        Me.tbxUpper.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxUpper.Location = New System.Drawing.Point(224, 28)
        Me.tbxUpper.Name = "tbxUpper"
        Me.tbxUpper.Size = New System.Drawing.Size(95, 18)
        Me.tbxUpper.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(201, 31)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "to"
        '
        'rbAnyLevel2
        '
        Me.rbAnyLevel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbAnyLevel2.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.rbAnyLevel2, 4)
        Me.rbAnyLevel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAnyLevel2.ForeColor = System.Drawing.Color.White
        Me.rbAnyLevel2.Location = New System.Drawing.Point(3, 79)
        Me.rbAnyLevel2.Name = "rbAnyLevel2"
        Me.rbAnyLevel2.Size = New System.Drawing.Size(178, 17)
        Me.rbAnyLevel2.TabIndex = 29
        Me.rbAnyLevel2.Text = "Any level I could win at"
        Me.rbAnyLevel2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel2.Controls.Add(Me.btnLeft)
        Me.Panel2.Controls.Add(Me.pnlMonster)
        Me.Panel2.Controls.Add(Me.tbxCName)
        Me.Panel2.Controls.Add(Me.btnRight)
        Me.Panel2.Location = New System.Drawing.Point(331, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(151, 124)
        Me.Panel2.TabIndex = 23
        '
        'btnLeft
        '
        Me.btnLeft.Image = Global.HackPets.My.Resources.Resources.Left
        Me.btnLeft.Location = New System.Drawing.Point(2, 0)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(19, 127)
        Me.btnLeft.TabIndex = 20
        Me.btnLeft.UseVisualStyleBackColor = True
        '
        'pnlMonster
        '
        Me.pnlMonster.Controls.Add(Me.pbNext)
        Me.pnlMonster.Controls.Add(Me.pbCurrent)
        Me.pnlMonster.Location = New System.Drawing.Point(25, 0)
        Me.pnlMonster.Name = "pnlMonster"
        Me.pnlMonster.Size = New System.Drawing.Size(100, 100)
        Me.pnlMonster.TabIndex = 18
        '
        'pbNext
        '
        Me.pbNext.Image = Global.HackPets.My.Resources.Resources.GreenwhichForest
        Me.pbNext.Location = New System.Drawing.Point(100, 0)
        Me.pbNext.Margin = New System.Windows.Forms.Padding(0)
        Me.pbNext.Name = "pbNext"
        Me.pbNext.Size = New System.Drawing.Size(100, 100)
        Me.pbNext.TabIndex = 22
        Me.pbNext.TabStop = False
        '
        'pbCurrent
        '
        Me.pbCurrent.Image = Global.HackPets.My.Resources.Resources.Random
        Me.pbCurrent.Location = New System.Drawing.Point(0, 0)
        Me.pbCurrent.Margin = New System.Windows.Forms.Padding(0)
        Me.pbCurrent.Name = "pbCurrent"
        Me.pbCurrent.Size = New System.Drawing.Size(100, 100)
        Me.pbCurrent.TabIndex = 21
        Me.pbCurrent.TabStop = False
        '
        'tbxCName
        '
        Me.tbxCName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCName.Location = New System.Drawing.Point(25, 106)
        Me.tbxCName.Name = "tbxCName"
        Me.tbxCName.ReadOnly = True
        Me.tbxCName.Size = New System.Drawing.Size(100, 21)
        Me.tbxCName.TabIndex = 21
        Me.tbxCName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnRight
        '
        Me.btnRight.Image = Global.HackPets.My.Resources.Resources.Right
        Me.btnRight.Location = New System.Drawing.Point(129, 1)
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Size = New System.Drawing.Size(19, 126)
        Me.btnRight.TabIndex = 19
        Me.btnRight.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.tbxNextLevel, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label12, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxPLevel, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxName, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label10, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxXP, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxGold, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxLocation, 3, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 2, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxAge, 3, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label6, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxAttack, 3, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label5, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxArmour, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxHP, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label14, 0, 3)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 33)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(321, 124)
        Me.TableLayoutPanel3.TabIndex = 25
        '
        'tbxNextLevel
        '
        Me.tbxNextLevel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxNextLevel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNextLevel.Location = New System.Drawing.Point(53, 78)
        Me.tbxNextLevel.Name = "tbxNextLevel"
        Me.tbxNextLevel.ReadOnly = True
        Me.tbxNextLevel.Size = New System.Drawing.Size(97, 21)
        Me.tbxNextLevel.TabIndex = 42
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(0, 106)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Gold:"
        '
        'tbxPLevel
        '
        Me.tbxPLevel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxPLevel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxPLevel.Location = New System.Drawing.Point(53, 28)
        Me.tbxPLevel.Name = "tbxPLevel"
        Me.tbxPLevel.ReadOnly = True
        Me.tbxPLevel.Size = New System.Drawing.Size(97, 21)
        Me.tbxPLevel.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Level:"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(0, 6)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Name:"
        '
        'tbxName
        '
        Me.tbxName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxName.Location = New System.Drawing.Point(53, 3)
        Me.tbxName.Name = "tbxName"
        Me.tbxName.ReadOnly = True
        Me.tbxName.Size = New System.Drawing.Size(97, 21)
        Me.tbxName.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(0, 56)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "XP:"
        '
        'tbxXP
        '
        Me.tbxXP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxXP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxXP.Location = New System.Drawing.Point(53, 53)
        Me.tbxXP.Name = "tbxXP"
        Me.tbxXP.ReadOnly = True
        Me.tbxXP.Size = New System.Drawing.Size(97, 21)
        Me.tbxXP.TabIndex = 36
        '
        'tbxGold
        '
        Me.tbxGold.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxGold.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxGold.Location = New System.Drawing.Point(53, 103)
        Me.tbxGold.Name = "tbxGold"
        Me.tbxGold.ReadOnly = True
        Me.tbxGold.Size = New System.Drawing.Size(97, 21)
        Me.tbxGold.TabIndex = 38
        '
        'tbxLocation
        '
        Me.tbxLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxLocation.Location = New System.Drawing.Point(221, 103)
        Me.tbxLocation.Name = "tbxLocation"
        Me.tbxLocation.ReadOnly = True
        Me.tbxLocation.Size = New System.Drawing.Size(97, 21)
        Me.tbxLocation.TabIndex = 40
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(153, 106)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Loc:"
        '
        'tbxAge
        '
        Me.tbxAge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxAge.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxAge.Location = New System.Drawing.Point(221, 78)
        Me.tbxAge.Name = "tbxAge"
        Me.tbxAge.ReadOnly = True
        Me.tbxAge.Size = New System.Drawing.Size(97, 21)
        Me.tbxAge.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(153, 81)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Age:"
        '
        'tbxAttack
        '
        Me.tbxAttack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxAttack.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxAttack.Location = New System.Drawing.Point(221, 53)
        Me.tbxAttack.Name = "tbxAttack"
        Me.tbxAttack.ReadOnly = True
        Me.tbxAttack.Size = New System.Drawing.Size(97, 21)
        Me.tbxAttack.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(153, 56)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Attack:"
        '
        'tbxArmour
        '
        Me.tbxArmour.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxArmour.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxArmour.Location = New System.Drawing.Point(221, 28)
        Me.tbxArmour.Name = "tbxArmour"
        Me.tbxArmour.ReadOnly = True
        Me.tbxArmour.Size = New System.Drawing.Size(97, 21)
        Me.tbxArmour.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(153, 31)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Armour:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(153, 6)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "HP:"
        '
        'tbxHP
        '
        Me.tbxHP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxHP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxHP.Location = New System.Drawing.Point(221, 3)
        Me.tbxHP.Name = "tbxHP"
        Me.tbxHP.ReadOnly = True
        Me.tbxHP.Size = New System.Drawing.Size(97, 21)
        Me.tbxHP.TabIndex = 29
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(0, 81)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Nxtlvl:"
        '
        'Panel3
        '
        Me.pnlData.SetColumnSpan(Me.Panel3, 2)
        Me.Panel3.Controls.Add(Me.CheckBox1)
        Me.Panel3.Controls.Add(Me.cbxTakeDamage)
        Me.Panel3.Controls.Add(Me.cbxPauseDuringBattle)
        Me.Panel3.Controls.Add(Me.cbxStopBefore)
        Me.Panel3.Location = New System.Drawing.Point(327, 160)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(398, 40)
        Me.Panel3.TabIndex = 28
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(184, 20)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(8, 3, 3, 8)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(187, 17)
        Me.CheckBox1.TabIndex = 31
        Me.CheckBox1.Text = "Loose before leveling up"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cbxTakeDamage
        '
        Me.cbxTakeDamage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxTakeDamage.AutoSize = True
        Me.cbxTakeDamage.Checked = True
        Me.cbxTakeDamage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxTakeDamage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxTakeDamage.ForeColor = System.Drawing.Color.White
        Me.cbxTakeDamage.Location = New System.Drawing.Point(5, 4)
        Me.cbxTakeDamage.Margin = New System.Windows.Forms.Padding(8, 3, 3, 8)
        Me.cbxTakeDamage.Name = "cbxTakeDamage"
        Me.cbxTakeDamage.Size = New System.Drawing.Size(114, 17)
        Me.cbxTakeDamage.TabIndex = 28
        Me.cbxTakeDamage.Text = "Take damage"
        Me.cbxTakeDamage.UseVisualStyleBackColor = True
        '
        'cbxPauseDuringBattle
        '
        Me.cbxPauseDuringBattle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxPauseDuringBattle.AutoSize = True
        Me.cbxPauseDuringBattle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxPauseDuringBattle.ForeColor = System.Drawing.Color.White
        Me.cbxPauseDuringBattle.Location = New System.Drawing.Point(184, 4)
        Me.cbxPauseDuringBattle.Margin = New System.Windows.Forms.Padding(8, 3, 3, 8)
        Me.cbxPauseDuringBattle.Name = "cbxPauseDuringBattle"
        Me.cbxPauseDuringBattle.Size = New System.Drawing.Size(160, 17)
        Me.cbxPauseDuringBattle.TabIndex = 29
        Me.cbxPauseDuringBattle.Text = "Pause during battles"
        Me.cbxPauseDuringBattle.UseVisualStyleBackColor = True
        '
        'cbxStopBefore
        '
        Me.cbxStopBefore.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxStopBefore.AutoSize = True
        Me.cbxStopBefore.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxStopBefore.ForeColor = System.Drawing.Color.White
        Me.cbxStopBefore.Location = New System.Drawing.Point(5, 20)
        Me.cbxStopBefore.Margin = New System.Windows.Forms.Padding(8, 3, 3, 8)
        Me.cbxStopBefore.Name = "cbxStopBefore"
        Me.cbxStopBefore.Size = New System.Drawing.Size(178, 17)
        Me.cbxStopBefore.TabIndex = 30
        Me.cbxStopBefore.Text = "Stop before leveling up"
        Me.cbxStopBefore.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.ItemSize = New System.Drawing.Size(61, 15)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(829, 259)
        Me.TabControl1.TabIndex = 24
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.pnlData)
        Me.TabPage1.ImageKey = "close.gif"
        Me.TabPage1.Location = New System.Drawing.Point(4, 19)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(821, 236)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Battle"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.CheckBox2)
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.ImageIndex = 0
        Me.TabPage2.Location = New System.Drawing.Point(4, 19)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(821, 236)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Sell"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Verdana", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label2.Location = New System.Drawing.Point(66, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(716, 45)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Click connect to populate this list"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox2.ForeColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Location = New System.Drawing.Point(21, 10)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sell, Me.QuantityToSell, Me.ItemName, Me.Quantity})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.ShowCellErrors = False
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.ShowRowErrors = False
        Me.DataGridView1.Size = New System.Drawing.Size(815, 230)
        Me.DataGridView1.TabIndex = 0
        '
        'Sell
        '
        Me.Sell.FillWeight = 1.0!
        Me.Sell.HeaderText = ""
        Me.Sell.Name = "Sell"
        Me.Sell.Width = 40
        '
        'QuantityToSell
        '
        Me.QuantityToSell.FillWeight = 1.0!
        Me.QuantityToSell.HeaderText = "Quantity to sell"
        Me.QuantityToSell.Name = "QuantityToSell"
        '
        'ItemName
        '
        Me.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ItemName.HeaderText = "Item name"
        Me.ItemName.Name = "ItemName"
        Me.ItemName.ReadOnly = True
        Me.ItemName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Quantity
        '
        Me.Quantity.FillWeight = 1.0!
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "_tickGreen.gif")
        Me.ImageList1.Images.SetKeyName(1, "close.gif")
        Me.ImageList1.Images.SetKeyName(2, "info.gif")
        Me.ImageList1.Images.SetKeyName(3, "open.gif")
        '
        'Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(853, 595)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Test"
        Me.Text = "Test"
        Me.pnlData.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlMonster.ResumeLayout(False)
        CType(Me.pbNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCurrent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlData As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbxNumFights As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbAnyLevel1 As System.Windows.Forms.RadioButton
    Friend WithEvents tbxMLevel As System.Windows.Forms.TextBox
    Friend WithEvents rbRange As System.Windows.Forms.RadioButton
    Friend WithEvents rbSetLevel As System.Windows.Forms.RadioButton
    Friend WithEvents tbxLower As System.Windows.Forms.TextBox
    Friend WithEvents tbxUpper As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rbAnyLevel2 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnLeft As System.Windows.Forms.Button
    Friend WithEvents pnlMonster As System.Windows.Forms.Panel
    Friend WithEvents pbNext As System.Windows.Forms.PictureBox
    Friend WithEvents pbCurrent As System.Windows.Forms.PictureBox
    Friend WithEvents tbxCName As System.Windows.Forms.TextBox
    Friend WithEvents btnRight As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbxNextLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbxPLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbxName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbxXP As System.Windows.Forms.TextBox
    Friend WithEvents tbxGold As System.Windows.Forms.TextBox
    Friend WithEvents tbxLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbxAge As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbxAttack As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbxArmour As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbxHP As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbxTakeDamage As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPauseDuringBattle As System.Windows.Forms.CheckBox
    Friend WithEvents cbxStopBefore As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Sell As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents QuantityToSell As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
