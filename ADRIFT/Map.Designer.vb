<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Map
    Inherits System.Windows.Forms.UserControl

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Map))
        Me.tabsMap = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.tabSharedPage = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.txtRename = New System.Windows.Forms.TextBox()
        Me.imgMap = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAddNode = New System.Windows.Forms.ToolStripButton()
        Me.btnPlanView = New System.Windows.Forms.ToolStripButton()
        Me.btnCentralise = New System.Windows.Forms.ToolStripButton()
        Me.btnZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.btnZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.cmsNode = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEditLocation = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRenameLocation = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDeleteNode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miMoveToPage = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMoveUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMoveDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsLink = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEditLink = New System.Windows.Forms.ToolStripMenuItem()
        Me.miOneWayLink = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRestrictions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miDeleteLink = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAddAnchor = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsTabs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miRenamePage = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAddPage = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.tabsMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsMap.SuspendLayout()
        Me.tabSharedPage.SuspendLayout()
        CType(Me.imgMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.cmsNode.SuspendLayout()
        Me.cmsLink.SuspendLayout()
        Me.cmsTabs.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabsMap
        '
        Me.tabsMap.AllowTabMoving = True
        Me.tabsMap.Controls.Add(Me.tabSharedPage)
        Me.tabsMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsMap.Location = New System.Drawing.Point(0, 25)
        Me.tabsMap.Name = "tabsMap"
        Me.tabsMap.SharedControls.AddRange(New System.Windows.Forms.Control() {Me.txtRename, Me.imgMap})
        Me.tabsMap.SharedControlsPage = Me.tabSharedPage
        Me.tabsMap.Size = New System.Drawing.Size(266, 229)
        Me.tabsMap.TabIndex = 0
        Me.tabsMap.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.BottomLeft
        '
        'tabSharedPage
        '
        Me.tabSharedPage.Controls.Add(Me.txtRename)
        Me.tabSharedPage.Controls.Add(Me.imgMap)
        Me.tabSharedPage.Location = New System.Drawing.Point(1, 1)
        Me.tabSharedPage.Name = "tabSharedPage"
        Me.tabSharedPage.Size = New System.Drawing.Size(262, 206)
        '
        'txtRename
        '
        Me.txtRename.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRename.Location = New System.Drawing.Point(152, -1000)
        Me.txtRename.Name = "txtRename"
        Me.txtRename.Size = New System.Drawing.Size(107, 20)
        Me.txtRename.TabIndex = 1
        Me.txtRename.Visible = False
        '
        'imgMap
        '
        Me.imgMap.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.imgMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgMap.Location = New System.Drawing.Point(0, 0)
        Me.imgMap.Name = "imgMap"
        Me.imgMap.Size = New System.Drawing.Size(262, 206)
        Me.imgMap.TabIndex = 0
        Me.imgMap.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddNode, Me.btnPlanView, Me.btnCentralise, Me.btnZoomIn, Me.btnZoomOut})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(266, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAddNode
        '
        Me.btnAddNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAddNode.Image = Global.ADRIFT.My.Resources.imgLocation16
        Me.btnAddNode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddNode.Name = "btnAddNode"
        Me.btnAddNode.Size = New System.Drawing.Size(23, 22)
        Me.btnAddNode.Text = "Add Location"
        '
        'btnPlanView
        '
        Me.btnPlanView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPlanView.Image = CType(resources.GetObject("btnPlanView.Image"), System.Drawing.Image)
        Me.btnPlanView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPlanView.Name = "btnPlanView"
        Me.btnPlanView.Size = New System.Drawing.Size(23, 22)
        Me.btnPlanView.Text = "Reset map to plan view"
        '
        'btnCentralise
        '
        Me.btnCentralise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCentralise.Image = CType(resources.GetObject("btnCentralise.Image"), System.Drawing.Image)
        Me.btnCentralise.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCentralise.Name = "btnCentralise"
        Me.btnCentralise.Size = New System.Drawing.Size(23, 22)
        Me.btnCentralise.Text = "Centralise Map"
        '
        'btnZoomIn
        '
        Me.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomIn.Image = Global.ADRIFT.My.Resources.imgZoomIn16
        Me.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(23, 22)
        Me.btnZoomIn.Text = "Zoom In"
        '
        'btnZoomOut
        '
        Me.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomOut.Image = Global.ADRIFT.My.Resources.imgZoomOut16
        Me.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.btnZoomOut.Text = "Zoom Out"
        '
        'cmsNode
        '
        Me.cmsNode.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEditLocation, Me.miRenameLocation, Me.miDeleteNode, Me.ToolStripSeparator1, Me.miMoveToPage, Me.miMoveUp, Me.miMoveDown})
        Me.cmsNode.Name = "cmsMap"
        Me.cmsNode.Size = New System.Drawing.Size(181, 142)
        '
        'miEditLocation
        '
        Me.miEditLocation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.miEditLocation.Name = "miEditLocation"
        Me.miEditLocation.Size = New System.Drawing.Size(180, 22)
        Me.miEditLocation.Text = "Edit Location"
        '
        'miRenameLocation
        '
        Me.miRenameLocation.Name = "miRenameLocation"
        Me.miRenameLocation.Size = New System.Drawing.Size(180, 22)
        Me.miRenameLocation.Text = "Rename Location"
        '
        'miDeleteNode
        '
        Me.miDeleteNode.Image = Global.ADRIFT.My.Resources.imgDelete
        Me.miDeleteNode.Name = "miDeleteNode"
        Me.miDeleteNode.Size = New System.Drawing.Size(180, 22)
        Me.miDeleteNode.Text = "Delete Location"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'miMoveToPage
        '
        Me.miMoveToPage.Name = "miMoveToPage"
        Me.miMoveToPage.Size = New System.Drawing.Size(180, 22)
        Me.miMoveToPage.Text = "Move to page"
        '
        'miMoveUp
        '
        Me.miMoveUp.Name = "miMoveUp"
        Me.miMoveUp.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.miMoveUp.Size = New System.Drawing.Size(180, 22)
        Me.miMoveUp.Text = "Move Up"
        '
        'miMoveDown
        '
        Me.miMoveDown.Name = "miMoveDown"
        Me.miMoveDown.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.miMoveDown.Size = New System.Drawing.Size(180, 22)
        Me.miMoveDown.Text = "Move Down"
        '
        'cmsLink
        '
        Me.cmsLink.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEditLink, Me.miOneWayLink, Me.miRestrictions, Me.ToolStripSeparator2, Me.miDeleteLink, Me.miAddAnchor})
        Me.cmsLink.Name = "cmsLink"
        Me.cmsLink.Size = New System.Drawing.Size(161, 142)
        '
        'miEditLink
        '
        Me.miEditLink.Enabled = False
        Me.miEditLink.Name = "miEditLink"
        Me.miEditLink.Size = New System.Drawing.Size(160, 22)
        Me.miEditLink.Text = "Edit Link"
        '
        'miOneWayLink
        '
        Me.miOneWayLink.Name = "miOneWayLink"
        Me.miOneWayLink.Size = New System.Drawing.Size(160, 22)
        Me.miOneWayLink.Text = "One-way Link"
        '
        'miRestrictions
        '
        Me.miRestrictions.Enabled = False
        Me.miRestrictions.Name = "miRestrictions"
        Me.miRestrictions.Size = New System.Drawing.Size(160, 22)
        Me.miRestrictions.Text = "Add Restrictions"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(157, 6)
        '
        'miDeleteLink
        '
        Me.miDeleteLink.Image = Global.ADRIFT.My.Resources.imgDelete
        Me.miDeleteLink.Name = "miDeleteLink"
        Me.miDeleteLink.Size = New System.Drawing.Size(160, 22)
        Me.miDeleteLink.Text = "Delete Link"
        '
        'miAddAnchor
        '
        Me.miAddAnchor.Name = "miAddAnchor"
        Me.miAddAnchor.Size = New System.Drawing.Size(160, 22)
        Me.miAddAnchor.Text = "Add Anchor"
        '
        'cmsTabs
        '
        Me.cmsTabs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miRenamePage, Me.miAddPage})
        Me.cmsTabs.Name = "cmsTabs"
        Me.cmsTabs.Size = New System.Drawing.Size(153, 70)
        '
        'miRenamePage
        '
        Me.miRenamePage.Name = "miRenamePage"
        Me.miRenamePage.Size = New System.Drawing.Size(152, 22)
        Me.miRenamePage.Text = "Rename Page"
        '
        'miAddPage
        '
        Me.miAddPage.Name = "miAddPage"
        Me.miAddPage.Size = New System.Drawing.Size(152, 22)
        Me.miAddPage.Text = "Add Page"
        '
        'Map
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tabsMap)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Map"
        Me.Size = New System.Drawing.Size(266, 254)
        CType(Me.tabsMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsMap.ResumeLayout(False)
        Me.tabSharedPage.ResumeLayout(False)
        Me.tabSharedPage.PerformLayout()
        CType(Me.imgMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.cmsNode.ResumeLayout(False)
        Me.cmsLink.ResumeLayout(False)
        Me.cmsTabs.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabsMap As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents tabSharedPage As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents imgMap As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnPlanView As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCentralise As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmsNode As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMoveUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMoveDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEditLocation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnZoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents miDeleteNode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsLink As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miEditLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDeleteLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAddAnchor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAddNode As System.Windows.Forms.ToolStripButton
    Friend WithEvents miRenameLocation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtRename As System.Windows.Forms.TextBox
    Friend WithEvents miOneWayLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miRestrictions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miMoveToPage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsTabs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miRenamePage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAddPage As System.Windows.Forms.ToolStripMenuItem

End Class
