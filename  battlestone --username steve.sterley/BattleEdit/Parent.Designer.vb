<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Parent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Parent))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbTileManager = New System.Windows.Forms.ToolStripButton
        Me.tsbMapBrowser = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LaunchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MapBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScriptEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GameVariablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CreatureBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EquipmentManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbTileManager, Me.tsbMapBrowser, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1008, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'tsbTileManager
        '
        Me.tsbTileManager.Image = Global.BattleEdit.My.Resources.Resources.group
        Me.tsbTileManager.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTileManager.Name = "tsbTileManager"
        Me.tsbTileManager.Size = New System.Drawing.Size(88, 22)
        Me.tsbTileManager.Text = "Tile manager"
        '
        'tsbMapBrowser
        '
        Me.tsbMapBrowser.Image = Global.BattleEdit.My.Resources.Resources.map
        Me.tsbMapBrowser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMapBrowser.Name = "tsbMapBrowser"
        Me.tsbMapBrowser.Size = New System.Drawing.Size(89, 22)
        Me.tsbMapBrowser.Text = "Map browser"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.BattleEdit.My.Resources.Resources.wand
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(85, 22)
        Me.ToolStripButton2.Text = "Script editor"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = Global.BattleEdit.My.Resources.Resources.coins
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(100, 22)
        Me.ToolStripButton3.Text = "Game variables"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = Global.BattleEdit.My.Resources.Resources.dragon
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(112, 22)
        Me.ToolStripButton4.Text = "Creature browser"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = Global.BattleEdit.My.Resources.Resources.helmet
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(122, 22)
        Me.ToolStripButton5.Text = "Equipment manager"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 710)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1008, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(114, 17)
        Me.ToolStripStatusLabel2.Text = "Battlestone The editor"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.LaunchToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1008, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.BattleEdit.My.Resources.Resources._cross
        Me.ExitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'LaunchToolStripMenuItem
        '
        Me.LaunchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TileManagerToolStripMenuItem, Me.MapBrowserToolStripMenuItem, Me.ScriptEditorToolStripMenuItem, Me.GameVariablesToolStripMenuItem, Me.CreatureBrowserToolStripMenuItem, Me.EquipmentManagerToolStripMenuItem})
        Me.LaunchToolStripMenuItem.Name = "LaunchToolStripMenuItem"
        Me.LaunchToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.LaunchToolStripMenuItem.Text = "&Launch"
        '
        'TileManagerToolStripMenuItem
        '
        Me.TileManagerToolStripMenuItem.Image = Global.BattleEdit.My.Resources.Resources.group
        Me.TileManagerToolStripMenuItem.Name = "TileManagerToolStripMenuItem"
        Me.TileManagerToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TileManagerToolStripMenuItem.Text = "&Tile manager"
        '
        'MapBrowserToolStripMenuItem
        '
        Me.MapBrowserToolStripMenuItem.Image = Global.BattleEdit.My.Resources.Resources.map
        Me.MapBrowserToolStripMenuItem.Name = "MapBrowserToolStripMenuItem"
        Me.MapBrowserToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MapBrowserToolStripMenuItem.Text = "&Map browser"
        '
        'ScriptEditorToolStripMenuItem
        '
        Me.ScriptEditorToolStripMenuItem.Image = Global.BattleEdit.My.Resources.Resources.wand
        Me.ScriptEditorToolStripMenuItem.Name = "ScriptEditorToolStripMenuItem"
        Me.ScriptEditorToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ScriptEditorToolStripMenuItem.Text = "&Script editor"
        '
        'GameVariablesToolStripMenuItem
        '
        Me.GameVariablesToolStripMenuItem.Image = Global.BattleEdit.My.Resources.Resources.coins
        Me.GameVariablesToolStripMenuItem.Name = "GameVariablesToolStripMenuItem"
        Me.GameVariablesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GameVariablesToolStripMenuItem.Text = "&Game variables"
        '
        'CreatureBrowserToolStripMenuItem
        '
        Me.CreatureBrowserToolStripMenuItem.Image = Global.BattleEdit.My.Resources.Resources.dragon
        Me.CreatureBrowserToolStripMenuItem.Name = "CreatureBrowserToolStripMenuItem"
        Me.CreatureBrowserToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CreatureBrowserToolStripMenuItem.Text = "&Creature browser"
        '
        'EquipmentManagerToolStripMenuItem
        '
        Me.EquipmentManagerToolStripMenuItem.Image = Global.BattleEdit.My.Resources.Resources.helmet
        Me.EquipmentManagerToolStripMenuItem.Name = "EquipmentManagerToolStripMenuItem"
        Me.EquipmentManagerToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EquipmentManagerToolStripMenuItem.Text = "&Equipment manager"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.HelpToolStripMenuItem1})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = Global.BattleEdit.My.Resources.Resources.info
        Me.AboutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Image = Global.BattleEdit.My.Resources.Resources.help
        Me.HelpToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(114, 22)
        Me.HelpToolStripMenuItem1.Text = "&Help"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Image = Global.BattleEdit.My.Resources.Resources.dragon
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(26, 16)
        '
        'Parent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1008, 732)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Parent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Battlestone game editor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbTileManager As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbMapBrowser As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaunchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MapBrowserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScriptEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GameVariablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreatureBrowserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EquipmentManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
