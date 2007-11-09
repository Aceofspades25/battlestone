<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TileManager
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("All tile groups")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TileManager))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblSelectTile = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripImage = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbSave = New System.Windows.Forms.ToolStripButton
        Me.tsbNewGroup = New System.Windows.Forms.ToolStripButton
        Me.tsbRenameGroup = New System.Windows.Forms.ToolStripButton
        Me.tsbDeleteGroup = New System.Windows.Forms.ToolStripButton
        Me.tsbNewTile = New System.Windows.Forms.ToolStripButton
        Me.tsbDeleteTile = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSelectTile)
        Me.SplitContainer1.Size = New System.Drawing.Size(677, 488)
        Me.SplitContainer1.SplitterDistance = 180
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 0
        '
        'TreeView1
        '
        Me.TreeView1.AllowDrop = True
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.HideSelection = False
        Me.TreeView1.LabelEdit = True
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.ImageIndex = 1
        TreeNode1.Name = "Node0"
        TreeNode1.StateImageIndex = 0
        TreeNode1.Text = "All tile groups"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TreeView1.Size = New System.Drawing.Size(176, 484)
        Me.TreeView1.StateImageList = Me.ImageList1
        Me.TreeView1.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "AllGroups.gif")
        Me.ImageList1.Images.SetKeyName(1, "group.gif")
        Me.ImageList1.Images.SetKeyName(2, "ground.gif")
        Me.ImageList1.Images.SetKeyName(3, "Wall.gif")
        Me.ImageList1.Images.SetKeyName(4, "car.gif")
        Me.ImageList1.Images.SetKeyName(5, "floor.gif")
        Me.ImageList1.Images.SetKeyName(6, "Character.gif")
        '
        'lblSelectTile
        '
        Me.lblSelectTile.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblSelectTile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectTile.Location = New System.Drawing.Point(125, 133)
        Me.lblSelectTile.Name = "lblSelectTile"
        Me.lblSelectTile.Size = New System.Drawing.Size(237, 118)
        Me.lblSelectTile.TabIndex = 3
        Me.lblSelectTile.Text = "Select a tile to edit, or click ""new""" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to create a new one."
        Me.lblSelectTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripImage, Me.ToolStripStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 510)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(677, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripImage
        '
        Me.ToolStripImage.Image = Global.BattleEdit.My.Resources.Resources.car
        Me.ToolStripImage.Name = "ToolStripImage"
        Me.ToolStripImage.Size = New System.Drawing.Size(16, 17)
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(131, 17)
        Me.ToolStripStatusLabel.Text = "Currently editing: Barrel 1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbNewGroup, Me.tsbRenameGroup, Me.tsbDeleteGroup, Me.tsbNewTile, Me.tsbDeleteTile})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(677, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.Image = Global.BattleEdit.My.Resources.Resources.save
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(51, 22)
        Me.tsbSave.Text = "Save"
        '
        'tsbNewGroup
        '
        Me.tsbNewGroup.Image = Global.BattleEdit.My.Resources.Resources.newGroup
        Me.tsbNewGroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNewGroup.Margin = New System.Windows.Forms.Padding(4, 1, 0, 2)
        Me.tsbNewGroup.Name = "tsbNewGroup"
        Me.tsbNewGroup.Size = New System.Drawing.Size(79, 22)
        Me.tsbNewGroup.Text = "New group"
        Me.tsbNewGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsbRenameGroup
        '
        Me.tsbRenameGroup.Image = Global.BattleEdit.My.Resources.Resources.renameGroup
        Me.tsbRenameGroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRenameGroup.Name = "tsbRenameGroup"
        Me.tsbRenameGroup.Size = New System.Drawing.Size(97, 22)
        Me.tsbRenameGroup.Text = "Rename group"
        '
        'tsbDeleteGroup
        '
        Me.tsbDeleteGroup.Image = Global.BattleEdit.My.Resources.Resources.deleteGroup
        Me.tsbDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDeleteGroup.Margin = New System.Windows.Forms.Padding(4, 1, 0, 2)
        Me.tsbDeleteGroup.Name = "tsbDeleteGroup"
        Me.tsbDeleteGroup.Size = New System.Drawing.Size(89, 22)
        Me.tsbDeleteGroup.Text = "Delete group"
        '
        'tsbNewTile
        '
        Me.tsbNewTile.Image = Global.BattleEdit.My.Resources.Resources.newTile
        Me.tsbNewTile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNewTile.Margin = New System.Windows.Forms.Padding(4, 1, 0, 2)
        Me.tsbNewTile.Name = "tsbNewTile"
        Me.tsbNewTile.Size = New System.Drawing.Size(65, 22)
        Me.tsbNewTile.Text = "New tile"
        '
        'tsbDeleteTile
        '
        Me.tsbDeleteTile.Image = Global.BattleEdit.My.Resources.Resources.deleteTile
        Me.tsbDeleteTile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDeleteTile.Margin = New System.Windows.Forms.Padding(4, 1, 0, 2)
        Me.tsbDeleteTile.Name = "tsbDeleteTile"
        Me.tsbDeleteTile.Size = New System.Drawing.Size(75, 22)
        Me.tsbDeleteTile.Text = "Delete tile"
        '
        'TileManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 532)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TileManager"
        Me.Text = "Tile manager"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNewGroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDeleteGroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNewTile As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDeleteTile As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblSelectTile As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripImage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbRenameGroup As System.Windows.Forms.ToolStripButton
End Class
