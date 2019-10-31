Imports System.ComponentModel
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinSpellChecker
'Imports System.Data


Public Class GenTextbox
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()        
        MyBase.New()
        'DebugTimeRecord("GenTextbox New")
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'DebugTimeFinish("GenTextbox New")
        'Add any initialization after the InitializeComponent() call
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent
        rtxtSource.Arguments = Arguments
    End Sub

    'UserControl1 overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        Try
            MyBase.Dispose(disposing) ' Cross threading error here sometimes (Infragistics?)
        Catch
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Tabs As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents tabpageSource As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents tabpagePreview As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents rtxtPreview As System.Windows.Forms.RichTextBox
    Friend WithEvents UTMText As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents UltraSpellChecker1 As Infragistics.Win.UltraWinSpellChecker.UltraSpellChecker
    Friend WithEvents txtBorder As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents rtxtSource As OOTextbox ' System.Windows.Forms.RichTextBox    
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents RestrictSummary As ADRIFT.RestrictSummary
    Friend WithEvents tabsDescriptions As Infragistics.Win.UltraWinTabControl.UltraTabStripControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents cmsTabs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDeleteTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbDisplayWhen As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblAreAllMetThen As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _Panel2_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _Panel2_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _Panel2_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _Panel2_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents fileGraphics As ADRIFT.DirectoryBox       
    Friend WithEvents imgGraphics As ADRIFT.clsImage    
    Friend WithEvents miRenameTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents fileAudio As ADRIFT.DirectoryBox
    Friend WithEvents pnlButtons As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents chkPlay As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents nudChannel As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblChannel As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkPause As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkStop As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkLoop As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents pnlAudio As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents pnlChannel As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents lblImageInstructions As Infragistics.Win.Misc.UltraLabel    
    Friend WithEvents tabpageGraphics As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    '<System.Diagnostics.DebuggerStepThrough()> 
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraToolbar2 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("tbFormat")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("CheckSpelling")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("CheckSpelling")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim PopupMenuTool1 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuPopup")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("CheckSpelling")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("AddAlternateDescription")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("AddAlternateDescription")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.tabpageSource = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.rtxtSource = New ADRIFT.OOTextbox()
        Me.txtBorder = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.tabpagePreview = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.rtxtPreview = New System.Windows.Forms.RichTextBox()
        Me.tabpageGraphics = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.lblImageInstructions = New Infragistics.Win.Misc.UltraLabel()
        Me.imgGraphics = New ADRIFT.clsImage()
        Me.fileGraphics = New ADRIFT.DirectoryBox()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.fileAudio = New ADRIFT.DirectoryBox()
        Me.pnlAudio = New Infragistics.Win.Misc.UltraPanel()
        Me.chkLoop = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.pnlChannel = New Infragistics.Win.Misc.UltraPanel()
        Me.nudChannel = New System.Windows.Forms.NumericUpDown()
        Me.lblChannel = New Infragistics.Win.Misc.UltraLabel()
        Me.pnlButtons = New Infragistics.Win.Misc.UltraPanel()
        Me.chkStop = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkPause = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkPlay = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.cmbDisplayWhen = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblAreAllMetThen = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RestrictSummary = New ADRIFT.RestrictSummary()
        Me.Tabs = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me._Panel2_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UTMText = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._Panel2_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._Panel2_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._Panel2_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.tabsDescriptions = New Infragistics.Win.UltraWinTabControl.UltraTabStripControl()
        Me.cmsTabs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miRenameTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.tabpageSource.SuspendLayout()
        CType(Me.txtBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpagePreview.SuspendLayout()
        Me.tabpageGraphics.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.pnlAudio.ClientArea.SuspendLayout()
        Me.pnlAudio.SuspendLayout()
        CType(Me.chkLoop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChannel.ClientArea.SuspendLayout()
        Me.pnlChannel.SuspendLayout()
        CType(Me.nudChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.ClientArea.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        CType(Me.chkStop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPause, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.cmbDisplayWhen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tabs.SuspendLayout()
        CType(Me.UTMText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabsDescriptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsDescriptions.SuspendLayout()
        Me.cmsTabs.SuspendLayout()
        Me.UltraTabSharedControlsPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabpageSource
        '
        Me.tabpageSource.Controls.Add(Me.rtxtSource)
        Me.tabpageSource.Controls.Add(Me.txtBorder)
        Me.tabpageSource.Location = New System.Drawing.Point(1, 1)
        Me.tabpageSource.Name = "tabpageSource"
        Me.tabpageSource.Size = New System.Drawing.Size(442, 374)
        '
        'rtxtSource
        '
        Me.rtxtSource.AllowDrop = True
        Me.UTMText.SetContextMenuUltra(Me.rtxtSource, "mnuPopup")
        Me.rtxtSource.DetectUrls = False
        Me.rtxtSource.Dock = System.Windows.Forms.DockStyle.None
        Me.rtxtSource.EnableAutoDragDrop = True
        Me.rtxtSource.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtxtSource.Location = New System.Drawing.Point(-1, -1)
        Me.rtxtSource.Multiline = True
        Me.rtxtSource.Name = "rtxtSource"
        Me.rtxtSource.Size = New System.Drawing.Size(442, 374)
        Me.rtxtSource.TabIndex = 0
        Me.rtxtSource.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI
        Me.rtxtSource.Value = New Infragistics.Win.FormattedLinkLabel.ParsedFormattedTextValue("")
        Me.rtxtSource.TreatValueAs = Infragistics.Win.FormattedLinkLabel.TreatValueAs.FormattedText
        '
        'txtBorder
        '
        Me.txtBorder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBorder.Location = New System.Drawing.Point(0, 0)
        Me.txtBorder.Multiline = True
        Me.txtBorder.Name = "txtBorder"
        Me.txtBorder.Size = New System.Drawing.Size(442, 374)
        Me.txtBorder.TabIndex = 1
        Me.txtBorder.TabStop = False
        Me.txtBorder.Text = "UltraTextEditor1"
        '
        'tabpagePreview
        '
        Me.tabpagePreview.Controls.Add(Me.rtxtPreview)
        Me.tabpagePreview.Enabled = False
        Me.tabpagePreview.Location = New System.Drawing.Point(-10000, -10000)
        Me.tabpagePreview.Name = "tabpagePreview"
        Me.tabpagePreview.Size = New System.Drawing.Size(442, 374)
        '
        'rtxtPreview
        '
        Me.rtxtPreview.BackColor = System.Drawing.Color.Black
        Me.rtxtPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtxtPreview.ForeColor = System.Drawing.Color.Lime
        Me.rtxtPreview.Location = New System.Drawing.Point(0, 0)
        Me.rtxtPreview.Name = "rtxtPreview"
        Me.rtxtPreview.Size = New System.Drawing.Size(442, 374)
        Me.rtxtPreview.TabIndex = 0
        Me.rtxtPreview.Text = ""
        '
        'tabpageGraphics
        '
        Me.tabpageGraphics.Controls.Add(Me.lblImageInstructions)
        Me.tabpageGraphics.Controls.Add(Me.imgGraphics)
        Me.tabpageGraphics.Controls.Add(Me.fileGraphics)
        Me.tabpageGraphics.Location = New System.Drawing.Point(-10000, -10000)
        Me.tabpageGraphics.Name = "tabpageGraphics"
        Me.tabpageGraphics.Size = New System.Drawing.Size(442, 374)
        '
        'lblImageInstructions
        '
        Me.lblImageInstructions.AllowDrop = True
        Me.lblImageInstructions.Anchor = System.Windows.Forms.AnchorStyles.None
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Center"
        Appearance5.TextVAlignAsString = "Middle"
        Me.lblImageInstructions.Appearance = Appearance5
        Me.lblImageInstructions.Location = New System.Drawing.Point(71, 134)
        Me.lblImageInstructions.Name = "lblImageInstructions"
        Me.lblImageInstructions.Size = New System.Drawing.Size(310, 71)
        Me.lblImageInstructions.TabIndex = 4
        Me.lblImageInstructions.Text = "Select an Image file, enter a web URL, or drag an image into this window"
        '
        'imgGraphics
        '
        Me.imgGraphics.AllowDrop = True
        Me.imgGraphics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgGraphics.BackColor = System.Drawing.Color.Transparent
        Me.imgGraphics.BackColour = System.Drawing.Color.Transparent
        Me.imgGraphics.Image = Nothing
        Me.imgGraphics.Location = New System.Drawing.Point(5, 5)
        Me.imgGraphics.Name = "imgGraphics"
        Me.imgGraphics.Size = New System.Drawing.Size(433, 336)
        Me.imgGraphics.SizeMode = ADRIFT.clsImage.SizeModeEnum.ActualSizeCentred
        Me.imgGraphics.TabIndex = 2
        '
        'fileGraphics
        '
        Me.fileGraphics.AllowDrop = True
        Me.fileGraphics.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fileGraphics.BackColor = System.Drawing.Color.Transparent
        Me.fileGraphics.BoxType = ADRIFT.DirectoryBox.BoxTypeEnum.File
        Me.fileGraphics.Directory = "*** Incorrect BoxType ***"
        Me.fileGraphics.FileFilter = "Image Files|*.jpg;*.gif;*.png|All Files (*.*)|*.*"
        Me.fileGraphics.Filename = ""
        Me.fileGraphics.Location = New System.Drawing.Point(5, 348)
        Me.fileGraphics.Name = "fileGraphics"
        Me.fileGraphics.OpenOrSave = ADRIFT.DirectoryBox.OpenOrSaveEnum.Open
        Me.fileGraphics.Size = New System.Drawing.Size(434, 22)
        Me.fileGraphics.TabIndex = 0
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.fileAudio)
        Me.UltraTabPageControl1.Controls.Add(Me.pnlAudio)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(442, 374)
        '
        'fileAudio
        '
        Me.fileAudio.AllowDrop = True
        Me.fileAudio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fileAudio.BackColor = System.Drawing.Color.Transparent
        Me.fileAudio.BoxType = ADRIFT.DirectoryBox.BoxTypeEnum.File
        Me.fileAudio.Directory = "*** Incorrect BoxType ***"
        Me.fileAudio.Enabled = False
        Me.fileAudio.FileFilter = "Audio Files|*.wav;*.mp3;*.mid|All Files (*.*)|*.*"
        Me.fileAudio.Filename = ""
        Me.fileAudio.Location = New System.Drawing.Point(5, 348)
        Me.fileAudio.Name = "fileAudio"
        Me.fileAudio.OpenOrSave = ADRIFT.DirectoryBox.OpenOrSaveEnum.Open
        Me.fileAudio.Size = New System.Drawing.Size(434, 22)
        Me.fileAudio.TabIndex = 1
        '
        'pnlAudio
        '
        Me.pnlAudio.Anchor = System.Windows.Forms.AnchorStyles.None
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Me.pnlAudio.Appearance = Appearance6
        '
        'pnlAudio.ClientArea
        '
        Me.pnlAudio.ClientArea.Controls.Add(Me.chkLoop)
        Me.pnlAudio.ClientArea.Controls.Add(Me.pnlChannel)
        Me.pnlAudio.ClientArea.Controls.Add(Me.pnlButtons)
        Me.pnlAudio.Location = New System.Drawing.Point(5, 129)
        Me.pnlAudio.Name = "pnlAudio"
        Me.pnlAudio.Size = New System.Drawing.Size(434, 86)
        Me.pnlAudio.TabIndex = 8
        '
        'chkLoop
        '
        Appearance19.FontData.Name = "ariel"
        Appearance19.FontData.SizeInPoints = 10.0!
        Me.chkLoop.Appearance = Appearance19
        Me.chkLoop.Enabled = False
        Me.chkLoop.Location = New System.Drawing.Point(247, 61)
        Me.chkLoop.Name = "chkLoop"
        Me.chkLoop.Size = New System.Drawing.Size(61, 20)
        Me.chkLoop.TabIndex = 7
        Me.chkLoop.Text = "Loop"
        '
        'pnlChannel
        '
        Me.pnlChannel.Anchor = System.Windows.Forms.AnchorStyles.None
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Me.pnlChannel.Appearance = Appearance7
        '
        'pnlChannel.ClientArea
        '
        Me.pnlChannel.ClientArea.Controls.Add(Me.nudChannel)
        Me.pnlChannel.ClientArea.Controls.Add(Me.lblChannel)
        Me.pnlChannel.Location = New System.Drawing.Point(134, 58)
        Me.pnlChannel.Name = "pnlChannel"
        Me.pnlChannel.Size = New System.Drawing.Size(92, 24)
        Me.pnlChannel.TabIndex = 9
        '
        'nudChannel
        '
        Me.nudChannel.Location = New System.Drawing.Point(57, 2)
        Me.nudChannel.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.nudChannel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudChannel.Name = "nudChannel"
        Me.nudChannel.Size = New System.Drawing.Size(33, 22)
        Me.nudChannel.TabIndex = 2
        Me.nudChannel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblChannel
        '
        Me.lblChannel.Location = New System.Drawing.Point(0, 5)
        Me.lblChannel.Name = "lblChannel"
        Me.lblChannel.Size = New System.Drawing.Size(100, 23)
        Me.lblChannel.TabIndex = 3
        Me.lblChannel.Text = "Channel:"
        '
        'pnlButtons
        '
        Me.pnlButtons.Anchor = System.Windows.Forms.AnchorStyles.None
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Me.pnlButtons.Appearance = Appearance23
        '
        'pnlButtons.ClientArea
        '
        Me.pnlButtons.ClientArea.Controls.Add(Me.chkStop)
        Me.pnlButtons.ClientArea.Controls.Add(Me.chkPause)
        Me.pnlButtons.ClientArea.Controls.Add(Me.chkPlay)
        Me.pnlButtons.Location = New System.Drawing.Point(111, 2)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(210, 52)
        Me.pnlButtons.TabIndex = 2
        '
        'chkStop
        '
        Appearance22.AlphaLevel = CType(128, Short)
        Appearance22.BackColor = System.Drawing.Color.Transparent
        Appearance22.BorderColor = System.Drawing.Color.Transparent
        Appearance22.Image = Global.ADRIFT.My.Resources.imgStop48
        Appearance22.ImageAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Me.chkStop.Appearance = Appearance22
        Me.chkStop.BackColor = System.Drawing.Color.Transparent
        Me.chkStop.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkStop.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button
        Appearance24.Image = Global.ADRIFT.My.Resources.imgStopShadow48
        Appearance24.ImageAlpha = Infragistics.Win.Alpha.Opaque
        Me.chkStop.CheckedAppearance = Appearance24
        Appearance31.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.chkStop.HotTrackingAppearance = Appearance31
        Me.chkStop.Location = New System.Drawing.Point(159, 1)
        Me.chkStop.Name = "chkStop"
        Me.chkStop.Size = New System.Drawing.Size(50, 50)
        Me.chkStop.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkStop.TabIndex = 6
        Me.chkStop.TabStop = False
        Me.chkStop.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.chkStop.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'chkPause
        '
        Appearance25.AlphaLevel = CType(128, Short)
        Appearance25.BackColor = System.Drawing.Color.Transparent
        Appearance25.BorderColor = System.Drawing.Color.Transparent
        Appearance25.Image = Global.ADRIFT.My.Resources.imgPause48
        Appearance25.ImageAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Me.chkPause.Appearance = Appearance25
        Me.chkPause.BackColor = System.Drawing.Color.Transparent
        Me.chkPause.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkPause.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button
        Appearance26.Image = Global.ADRIFT.My.Resources.imgPauseShadow48
        Appearance26.ImageAlpha = Infragistics.Win.Alpha.Opaque
        Me.chkPause.CheckedAppearance = Appearance26
        Appearance30.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.chkPause.HotTrackingAppearance = Appearance30
        Me.chkPause.Location = New System.Drawing.Point(81, 1)
        Me.chkPause.Name = "chkPause"
        Me.chkPause.Size = New System.Drawing.Size(50, 50)
        Me.chkPause.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkPause.TabIndex = 5
        Me.chkPause.TabStop = False
        Me.chkPause.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.chkPause.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'chkPlay
        '
        Appearance27.AlphaLevel = CType(128, Short)
        Appearance27.BackColor = System.Drawing.Color.Transparent
        Appearance27.BorderColor = System.Drawing.Color.Transparent
        Appearance27.Image = Global.ADRIFT.My.Resources.imgPlay48
        Appearance27.ImageAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Me.chkPlay.Appearance = Appearance27
        Me.chkPlay.BackColor = System.Drawing.Color.Transparent
        Me.chkPlay.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkPlay.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button
        Appearance28.Image = Global.ADRIFT.My.Resources.imgPlayShadow48
        Appearance28.ImageAlpha = Infragistics.Win.Alpha.Opaque
        Me.chkPlay.CheckedAppearance = Appearance28
        Appearance29.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.chkPlay.HotTrackingAppearance = Appearance29
        Me.chkPlay.Location = New System.Drawing.Point(1, 1)
        Me.chkPlay.Name = "chkPlay"
        Me.chkPlay.Size = New System.Drawing.Size(49, 49)
        Me.chkPlay.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkPlay.TabIndex = 4
        Me.chkPlay.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.chkPlay.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer.IsSplitterFixed = True
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer.Panel1.Controls.Add(Me.cmbDisplayWhen)
        Me.SplitContainer.Panel1.Controls.Add(Me.lblAreAllMetThen)
        Me.SplitContainer.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer.Panel1.Controls.Add(Me.RestrictSummary)
        Me.SplitContainer.Panel1MinSize = 24
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.Tabs)
        Me.SplitContainer.Panel2.Controls.Add(Me._Panel2_Toolbars_Dock_Area_Left)
        Me.SplitContainer.Panel2.Controls.Add(Me._Panel2_Toolbars_Dock_Area_Right)
        Me.SplitContainer.Panel2.Controls.Add(Me._Panel2_Toolbars_Dock_Area_Top)
        Me.SplitContainer.Panel2.Controls.Add(Me._Panel2_Toolbars_Dock_Area_Bottom)
        Me.SplitContainer.Size = New System.Drawing.Size(496, 403)
        Me.SplitContainer.SplitterDistance = 24
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 2
        '
        'cmbDisplayWhen
        '
        Me.cmbDisplayWhen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDisplayWhen.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = 0
        ValueListItem1.DisplayText = "start description with:"
        ValueListItem2.DataValue = 1
        ValueListItem2.DisplayText = "display this after default:"
        ValueListItem3.DataValue = 2
        ValueListItem3.DisplayText = "append this to previous:"
        Me.cmbDisplayWhen.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.cmbDisplayWhen.Location = New System.Drawing.Point(341, 2)
        Me.cmbDisplayWhen.Name = "cmbDisplayWhen"
        Me.cmbDisplayWhen.Size = New System.Drawing.Size(152, 21)
        Me.cmbDisplayWhen.TabIndex = 1
        '
        'lblAreAllMetThen
        '
        Me.lblAreAllMetThen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAreAllMetThen.AutoSize = True
        Me.lblAreAllMetThen.Location = New System.Drawing.Point(259, 6)
        Me.lblAreAllMetThen.Name = "lblAreAllMetThen"
        Me.lblAreAllMetThen.Size = New System.Drawing.Size(79, 13)
        Me.lblAreAllMetThen.TabIndex = 2
        Me.lblAreAllMetThen.Text = "are all met then"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "If"
        '
        'RestrictSummary
        '
        Me.RestrictSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictSummary.BackColor = System.Drawing.Color.Transparent
        Me.RestrictSummary.Location = New System.Drawing.Point(19, 2)
        Me.RestrictSummary.Name = "RestrictSummary"
        Me.RestrictSummary.Size = New System.Drawing.Size(240, 21)
        Me.RestrictSummary.TabIndex = 0
        '
        'Tabs
        '
        Me.Tabs.BackColorInternal = System.Drawing.Color.Transparent
        Me.Tabs.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tabs.Controls.Add(Me.tabpageSource)
        Me.Tabs.Controls.Add(Me.tabpagePreview)
        Me.Tabs.Controls.Add(Me.tabpageGraphics)
        Me.Tabs.Controls.Add(Me.UltraTabPageControl1)
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tabs.Location = New System.Drawing.Point(27, 0)
        Me.Tabs.MinTabWidth = 10
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tabs.Size = New System.Drawing.Size(469, 378)
        Me.Tabs.TabIndex = 0
        Me.Tabs.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.RightTop
        UltraTab1.Key = "tabSource"
        UltraTab1.TabPage = Me.tabpageSource
        UltraTab1.Text = "Source"
        UltraTab2.Key = "tabPreview"
        UltraTab2.TabPage = Me.tabpagePreview
        UltraTab2.Text = "Preview"
        UltraTab3.Key = "tabGraphics"
        UltraTab3.TabPage = Me.tabpageGraphics
        UltraTab3.Text = "Graphics"
        UltraTab6.Key = "tabAudio"
        UltraTab6.TabPage = Me.UltraTabPageControl1
        UltraTab6.Text = "Audio"
        Me.Tabs.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3, UltraTab6})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(442, 374)
        '
        '_Panel2_Toolbars_Dock_Area_Left
        '
        Me._Panel2_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._Panel2_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control
        Me._Panel2_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._Panel2_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Panel2_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 0)
        Me._Panel2_Toolbars_Dock_Area_Left.Name = "_Panel2_Toolbars_Dock_Area_Left"
        Me._Panel2_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(27, 378)
        Me._Panel2_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UTMText
        '
        'UTMText
        '
        Me.UTMText.DesignerFlags = 1
        Me.UTMText.DockWithinContainer = Me.SplitContainer.Panel2
        Me.UTMText.ShowFullMenusDelay = 500
        UltraToolbar2.DockedColumn = 0
        UltraToolbar2.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        UltraToolbar2.DockedRow = 0
        UltraToolbar2.FloatingSize = New System.Drawing.Size(100, 20)
        UltraToolbar2.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1})
        UltraToolbar2.Text = "Format"
        Me.UTMText.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar2})
        Appearance1.Image = Global.ADRIFT.My.Resources.imgSpelling
        ButtonTool2.SharedPropsInternal.AppearancesLarge.Appearance = Appearance1
        Appearance2.Image = Global.ADRIFT.My.Resources.imgSpelling
        ButtonTool2.SharedPropsInternal.AppearancesSmall.Appearance = Appearance2
        ButtonTool2.SharedPropsInternal.Caption = "Spelling..."
        ButtonTool2.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.F7
        PopupMenuTool1.SharedPropsInternal.Caption = "PopupMenuTool1"
        PopupMenuTool1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool3, ButtonTool4})
        Appearance3.Image = Global.ADRIFT.My.Resources.imgNew16
        ButtonTool5.SharedPropsInternal.AppearancesSmall.Appearance = Appearance3
        ButtonTool5.SharedPropsInternal.Caption = "Add Alternative Description"
        Me.UTMText.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool2, PopupMenuTool1, ButtonTool5})
        '
        '_Panel2_Toolbars_Dock_Area_Right
        '
        Me._Panel2_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._Panel2_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control
        Me._Panel2_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._Panel2_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Panel2_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(496, 0)
        Me._Panel2_Toolbars_Dock_Area_Right.Name = "_Panel2_Toolbars_Dock_Area_Right"
        Me._Panel2_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 378)
        Me._Panel2_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UTMText
        '
        '_Panel2_Toolbars_Dock_Area_Top
        '
        Me._Panel2_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._Panel2_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control
        Me._Panel2_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._Panel2_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Panel2_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._Panel2_Toolbars_Dock_Area_Top.Name = "_Panel2_Toolbars_Dock_Area_Top"
        Me._Panel2_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(496, 0)
        Me._Panel2_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UTMText
        '
        '_Panel2_Toolbars_Dock_Area_Bottom
        '
        Me._Panel2_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._Panel2_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._Panel2_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._Panel2_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Panel2_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 378)
        Me._Panel2_Toolbars_Dock_Area_Bottom.Name = "_Panel2_Toolbars_Dock_Area_Bottom"
        Me._Panel2_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(496, 0)
        Me._Panel2_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UTMText
        '
        'tabsDescriptions
        '
        Me.tabsDescriptions.AllowTabMoving = True
        Me.tabsDescriptions.ContextMenuStrip = Me.cmsTabs
        Me.tabsDescriptions.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.tabsDescriptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsDescriptions.Location = New System.Drawing.Point(0, 0)
        Me.tabsDescriptions.Name = "tabsDescriptions"
        Me.tabsDescriptions.SharedControls.AddRange(New System.Windows.Forms.Control() {Me.SplitContainer})
        Me.tabsDescriptions.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.tabsDescriptions.Size = New System.Drawing.Size(500, 429)
        Me.tabsDescriptions.TabIndex = 11
        Me.tabsDescriptions.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowCompressed
        Me.tabsDescriptions.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.BottomLeft
        UltraTab4.Key = "tabDefault"
        UltraTab4.Text = "Default Description"
        Appearance4.Image = Global.ADRIFT.My.Resources.imgNew16
        UltraTab5.HotTrackAppearance = Appearance4
        UltraTab5.Key = "tabNew"
        UltraTab5.Text = " "
        Me.tabsDescriptions.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab4, UltraTab5})
        '
        'cmsTabs
        '
        Me.cmsTabs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miRenameTab, Me.mnuDeleteTab})
        Me.cmsTabs.Name = "cmsTabs"
        Me.cmsTabs.Size = New System.Drawing.Size(141, 48)
        '
        'miRenameTab
        '
        Me.miRenameTab.Name = "miRenameTab"
        Me.miRenameTab.Size = New System.Drawing.Size(140, 22)
        Me.miRenameTab.Text = "Rename Tab"
        '
        'mnuDeleteTab
        '
        Me.mnuDeleteTab.Image = Global.ADRIFT.My.Resources.imgDelete
        Me.mnuDeleteTab.Name = "mnuDeleteTab"
        Me.mnuDeleteTab.Size = New System.Drawing.Size(140, 22)
        Me.mnuDeleteTab.Text = "Delete Tab"
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Controls.Add(Me.SplitContainer)
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(1, 1)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(496, 403)
        '
        'GenTextbox
        '
        Me.Controls.Add(Me.tabsDescriptions)
        Me.Name = "GenTextbox"
        Me.Size = New System.Drawing.Size(500, 429)
        Me.tabpageSource.ResumeLayout(False)
        Me.tabpageSource.PerformLayout()
        CType(Me.txtBorder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpagePreview.ResumeLayout(False)
        Me.tabpageGraphics.ResumeLayout(False)
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.pnlAudio.ClientArea.ResumeLayout(False)
        Me.pnlAudio.ResumeLayout(False)
        CType(Me.chkLoop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChannel.ClientArea.ResumeLayout(False)
        Me.pnlChannel.ResumeLayout(False)
        CType(Me.nudChannel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ClientArea.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        CType(Me.chkStop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPause, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPlay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.cmbDisplayWhen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tabs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tabs.ResumeLayout(False)
        CType(Me.UTMText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabsDescriptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsDescriptions.ResumeLayout(False)
        Me.cmsTabs.ResumeLayout(False)
        Me.UltraTabSharedControlsPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private bLocked As Boolean
    Public Shadows Event GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Shadows Event LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    Friend oDescription As Description
    Private bLoading As Boolean = True
    Private sWord As String
    Private iWordStart As Integer
    Private tabRightClick As Infragistics.Win.UltraWinTabControl.UltraTab
    Private sGraphicsTag As String
    Private sAudioTag As String
    Private WithEvents tmrToolDropdown As New Timer

    Public Declare Function SendMessageLong Lib "user32" Alias "SendMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long

    Public Event Changed(ByVal sender As Object, ByVal e As System.EventArgs)

    Friend Property Arguments As List(Of clsUserFunction.Argument)

    Private bFirstTabHasRestrictions As Boolean = False
    Public Property FirstTabHasRestrictions As Boolean
        Get
            Return bFirstTabHasRestrictions
        End Get
        Set(value As Boolean)
            bFirstTabHasRestrictions = value
        End Set
    End Property


    Dim msCommand As String
    Public Property sCommand() As String ' Used for restrictions to know about %object% etc
        Get
            Return msCommand
        End Get
        Set(ByVal value As String)
            msCommand = value
            RestrictSummary.sCommand = value
        End Set
    End Property

    ' Hide the Text property
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), Obsolete("Text Property not in use", True)> _
    Public Overrides Property Text() As String
        Get
            Return Nothing
        End Get
        Set(ByVal Value As String)
            Value = Nothing
        End Set
    End Property


    Friend Property Description() As Description
        Get
            Return oDescription
        End Get
        Set(ByVal value As Description)
            If oDescription IsNot value Then
                oDescription = value
                If tabsDescriptions.Tabs.Count > 2 Then
                    For i As Integer = tabsDescriptions.Tabs.Count - 2 To 1 Step -1
                        tabsDescriptions.Tabs.RemoveAt(i)
                    Next
                End If
                If oDescription IsNot Nothing AndAlso tabsDescriptions.Tabs.Count = 2 Then
                    If oDescription(0).sTabLabel <> "" Then tabsDescriptions.Tabs(0).Text = oDescription(0).sTabLabel
                    For iTabs As Integer = 1 To oDescription.Count - 1
                        Dim sTabLabel As String = "Alternative Description " & iTabs
                        If oDescription(iTabs).sTabLabel <> "" Then sTabLabel = oDescription(iTabs).sTabLabel
                        tabsDescriptions.Tabs.Insert(iTabs, "tab" & iTabs, sTabLabel)
                    Next
                    If oDescription.Count > 1 Then
                        Me.Visible = False
                        tabsDescriptions.Visible = True
                        Tabs.Parent = SplitContainer.Panel2
                        Me.Visible = True
                    End If
                    If oDescription.Count > 0 Then LoadTab(oDescription(0))
                End If
                bLoading = False
            End If
        End Set
    End Property


    Private bAllowAlternateDescriptions As Boolean = True
    Public Property AllowAlternateDescriptions() As Boolean
        Get
            Return bAllowAlternateDescriptions
        End Get
        Set(ByVal value As Boolean)
            bAllowAlternateDescriptions = value
        End Set
    End Property


    Public Overrides ReadOnly Property Focused() As Boolean
        Get
            Return Me.rtxtSource.Focused OrElse Me.rtxtPreview.Focused 'OrElse rtxtSource.Parent.Focused
        End Get
    End Property


    Private Sub LocationGroup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtxtPreview.GotFocus, rtxtSource.GotFocus
        RaiseEvent GotFocus(Me, e)
    End Sub

    Private Sub LocationGroup_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtxtPreview.LostFocus, rtxtSource.LostFocus
        If Not Me.Focused Then RaiseEvent LostFocus(Me, e)
    End Sub


    'Public Property txtSource() As String
    '    Get
    '        Return Me.rtxtSource.Text
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.rtxtSource.Text = Value
    '        FormatTextbox()
    '    End Set
    'End Property

    'Public Property txtPreview() As String
    '    Get
    '        Return Me.rtxtPreview.Text
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.rtxtPreview.Text = Value
    '    End Set
    'End Property



    Private Sub Tabs_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tabs.SelectedTabChanged
        Select Case e.Tab.Key
            Case "tabSource"
                UTMText.Visible = False
                'tabpageSource.Enabled = True
                'tabpagePreview.Enabled = False
                'tabpageGraphics.Enabled = False
                'rtxtPreview.Enabled = False
                'rtxtSource.Enabled = True
                'fileGraphics.Enabled = False               
            Case "tabPreview"
                ' TODO - Only allow this as an option, and if selected, disable the preview box from being edited
                Dim sSourceText As String = ReplaceALRs(ReplaceFunctions(rtxtSource.Text))

                Source2HTML(sSourceText, rtxtPreview, True) ' If we do above won't be able to use formatting
                UTMText.Visible = True
                'rtxtPreview.Enabled = True
                'rtxtSource.Enabled = False
                'fileGraphics.Enabled = False
                'tabpageSource.Enabled = False
                'tabpagePreview.Enabled = True
                'tabpageGraphics.Enabled = False
            Case "tabGraphics"
                'rtxtPreview.Enabled = False
                'rtxtSource.Enabled = False
                'fileGraphics.Enabled = True
                'tabpageSource.Enabled = False
                'tabpagePreview.Enabled = False
                'tabpageGraphics.Enabled = True
        End Select

    End Sub


    Dim bFormatting As Boolean = False



    Private Enum BlockTypeEnum As Integer
        NoFormat = 0
        StandardTag = 1
        [Function] = 2
        Key = 3
        Variable = 4
        References = 5
        Comments = 6
        EmbeddedExpression = 7
    End Enum



    Private Sub ReplaceIfNotFormatted(ByVal sSearch As String, ByVal sReplace As String, ByVal colour As Color, Optional regexoptions As System.Text.RegularExpressions.RegexOptions = System.Text.RegularExpressions.RegexOptions.IgnoreCase, Optional ByVal iFromStart As Integer = 0, Optional ByVal iFromEnd As Integer = 0)

        Dim re As New System.Text.RegularExpressions.Regex(sSearch, regexoptions)
        Dim iOffset As Integer = 0
        For Each match As System.Text.RegularExpressions.Match In re.Matches(sTextCode)
            If match.Index + iOffset < sTextCode.Length Then
                iMatchNo += 1
                Dim iMatchIndex As Integer = match.Index + iOffset
                Dim sActualReplace As String = sReplace.Replace("$&", match.Value)
                Dim sStart As String = sActualReplace.Substring(0, iFromStart)
                Dim sEnd As String = sActualReplace.Substring(sActualReplace.Length - iFromEnd)
                sActualReplace = sStart & "<font color=""#" & Hex(colour.ToArgb) & """>" & sActualReplace.Substring(iFromStart, sActualReplace.Length - iFromEnd - iFromStart) & "</font>" & sEnd
                dictMatches.Add(iMatchNo, sActualReplace)
                iOffset -= match.Value.Length - 7 - iMatchNo.ToString.Length
                sTextCode = re.Replace(sTextCode, "@[@#" & iMatchNo & "@]@", 1, iMatchIndex)
            End If
        Next

    End Sub


    'Private fte As Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor
    Private dictMatches As Dictionary(Of Integer, String)
    Private iMatchNo As Integer
    Private sTextCode As String

    Friend Sub FormatTextbox()
        'Exit Sub
        dictMatches = New Dictionary(Of Integer, String)
        iMatchNo = 0

        'If fte Is Nothing Then fte = New Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor
        'If rtxtSource.fte.Text <> rtxtSource.Text Then
        'rtxtSource.fte.Text = rtxtSource.Text
        sTextCode = rtxtSource.fte.Value.ToString ' Unformatted version of the encoding

        ' XML comments                        
        ReplaceIfNotFormatted("&lt;!--.*?--&gt;", "<i>$&</i>", Color.DimGray, System.Text.RegularExpressions.RegexOptions.IgnoreCase) ' Or System.Text.RegularExpressions.RegexOptions.Singleline)
        ReplaceIfNotFormatted("&lt;!--.*?(?!--&gt;)$", "<i>$&</i>", Color.DimGray, System.Text.RegularExpressions.RegexOptions.IgnoreCase) ' Or System.Text.RegularExpressions.RegexOptions.Singleline)

        ' Embedded expressions            
        ReplaceIfNotFormatted("&lt;#.*?#&gt;", "$&", Color.DodgerBlue, System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Singleline)
        ReplaceIfNotFormatted("&lt;#.*?(?!#&gt;)$", "$&", Color.DodgerBlue, System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Singleline)

        ' Standard Tags
        For Each sTag As String In New String() {"b", "/b", "u", "/u", "i", "/i", "c", "/c", "font", "/font", "br", "center", "/center", "centre", "/centre", "del", "img", "audio"}
            ReplaceIfNotFormatted("&lt;" & sTag & "&gt;", "&lt;<b><font color=""#" & Hex(Color.Purple.ToArgb) & """>" & sTag & "</font></b>&gt;", Color.DarkBlue)
        Next
        ReplaceIfNotFormatted("&lt;font ", "&lt;<b><font color=""#" & Hex(Color.Purple.ToArgb) & """>font</font></b> ", Color.DarkBlue)
        ReplaceIfNotFormatted("&lt;img ", "&lt;<b><font color=""#" & Hex(Color.Purple.ToArgb) & """>img</font></b> ", Color.DarkBlue)
        ReplaceIfNotFormatted("&lt;audio ", "&lt;<b><font color=""#" & Hex(Color.Purple.ToArgb) & """>audio</font></b> ", Color.DarkBlue)

        ' Functions
        For Each sFunction As String In FunctionNames()
            ReplaceIfNotFormatted("%" & sFunction & "%", "%" & sFunction & "%", Color.Blue)
            ReplaceIfNotFormatted("%" & sFunction & "\[", "%" & sFunction & "[", Color.Blue)
        Next

        ' Variables
        If Adventure IsNot Nothing Then
            For Each cVar As clsVariable In Adventure.htblVariables.Values
                ReplaceIfNotFormatted("%" & cVar.Name & "(%|\[.*?]%)", "$&", Color.Purple)
            Next
        End If

        ' References
        For Each sRef As String In ReferenceNames()
            ReplaceIfNotFormatted(sRef, "$&", Color.Green)
        Next

        ' Keys - Only display if they're used within square brackets, or in a function
        If Adventure IsNot Nothing Then
            For Each sKey As String In Adventure.AllKeys
                sKey = sKey.Replace("|", "\|") ' Imported v4 State keys...                
                Dim re As New System.Text.RegularExpressions.Regex(sKey, System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
                Dim iOffset As Integer = 0
                For Each match As System.Text.RegularExpressions.Match In re.Matches(sTextCode)
                    Dim iMatchIndex As Integer = match.Index + iOffset
                    Dim sBefore As String = ""
                    If iMatchIndex > 0 Then sBefore = sTextCode(iMatchIndex - 1)
                    Dim sAfter As String = ""
                    If iMatchIndex + match.Value.Length < sTextCode.Length Then sAfter = sTextCode(iMatchIndex + match.Value.Length)
                    If sAfter = "." AndAlso iMatchIndex + match.Value.Length < sTextCode.Length - 1 Then sAfter &= sTextCode(iMatchIndex + match.Value.Length + 1)
                    If (sBefore = "[" AndAlso sAfter = "]") OrElse (sBefore = ".") OrElse (sAfter.StartsWith(".") AndAlso sAfter <> ". " AndAlso sAfter <> "." AndAlso sAfter <> ".&" AndAlso sAfter <> ".<") Then
                        iMatchNo += 1
                        dictMatches.Add(iMatchNo, "<font color=""#" & Hex(Color.OrangeRed.ToArgb) & """>" & sKey & "</font>")
                        iOffset -= match.Value.Length - 7 - iMatchNo.ToString.Length
                        sTextCode = re.Replace(sTextCode, "@[@#" & iMatchNo & "@]@", 1, iMatchIndex)
                    End If
                Next
            Next
        End If

        ' OO keywords
        For Each sKey As String In New String() {"Children", "Contents", "Count", "Description", "Descriptor", "Exits", "Held", "Length", "List", "LocationTo", "Location", "Name", "Objects", "Parent", "Position", "ProperName", "Sum", "WornAndHeld", "Worn"}
            ReplaceIfNotFormatted("\." & sKey, "$&", Color.DarkRed, System.Text.RegularExpressions.RegexOptions.ExplicitCapture, 1)
        Next

        ' Arguments
        If Arguments IsNot Nothing Then
            For Each arg As clsUserFunction.Argument In Arguments
                ReplaceIfNotFormatted("%" & arg.Name & "%", "%" & arg.Name & "%", Color.Teal)
            Next
        End If

        ' End-Functions            
        ReplaceIfNotFormatted("\]%", "]%", Color.Blue)

        For i As Integer = 0 To 1 ' Do it twice in case a later replacement has an earlier dictionary key as it's value (e.g. <#<!--x-->#>)
            For Each iMatch As Integer In dictMatches.Keys
                sTextCode = sTextCode.Replace("@[@#" & iMatch & "@]@", dictMatches(iMatch))
            Next
        Next

        bTextChanging = True
        If rtxtSource.Value.ToString <> sTextCode Then
            rtxtSource.TreatValueAs = Infragistics.Win.FormattedLinkLabel.TreatValueAs.FormattedText
            rtxtSource.Value = sTextCode
        Else
            sTextCode = sTextCode
        End If

        bTextChanging = False
        'End If

    End Sub



    Private Function GetNextWord(ByRef iStart As Integer, ByRef iOffset As Integer) As String

        'Dim iStart As Integer = iOffset
        While iOffset < rtxtSource.TextLength
            Select Case rtxtSource.Text(iOffset)
                Case " "c, "%"c, Chr(10)
                    'iOffset += 1
                    If iOffset <> iStart Then
                        Return rtxtSource.Text.Substring(iStart, iOffset - iStart)
                    Else
                        iStart += 1
                        iOffset += 1
                    End If
                Case "<"c, "["c
                    If iOffset <> iStart Then
                        Return rtxtSource.Text.Substring(iStart, iOffset - iStart)
                    Else
                        iOffset += 1
                    End If
                Case ">"c, "]"c
                    iOffset += 1
                    Return rtxtSource.Text.Substring(iStart, iOffset - iStart)
                    'Case "%"c

                Case Else
                    iOffset += 1
            End Select
        End While

        Return rtxtSource.Text.Substring(iStart, iOffset - iStart)

    End Function


    Friend bTextChanging As Boolean = False
    Private Sub rtxtSource_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtxtSource.TextChanged
        If bTextChanging Then Exit Sub
        FormatTextbox()
        UpdateDescription()
    End Sub



    Private Sub cmsIntellisense_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        'rtxtSource.AppendText(e.ClickedItem.Tag.ToString)
    End Sub



    'Private Sub cmsIntellisense_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs)
    '    Select Case e.KeyData
    '        Case Keys.Space, Keys.Tab
    '            If rtxtSource.Text.EndsWith(sIntellisenseWord) Then
    '                rtxtSource.Text = sLeft(rtxtSource.Text, rtxtSource.TextLength - sIntellisenseWord.Length)
    '                rtxtSource.SelectionStart = rtxtSource.TextLength
    '                rtxtSource.SelectedText = lstIntellisense.SelectedItems(0).Tag.ToString
    '                rtxtSource.SelectedText = lstIntellisense.Items(0).Tag.ToString
    '            End If
    '            rtxtSource.SelectedText = " "
    '            rtxtSource.SelectionStart = rtxtSource.TextLength
    '            popupList.Close() ' cmsIntellisense.Hide()
    '        Case Keys.Up, Keys.Down, Keys.Enter
    '            ' ignore
    '        Case Else
    '            'rtxtSource.AppendText("x")                
    '            Dim cNew As Char = CChar(ChrW(e.KeyValue))
    '            If Not e.Shift Then cNew = Char.ToLower(cNew)
    '            sIntellisenseWord &= cNew
    '            rtxtSource.SelectedText = cNew

    '            'rtxtSource.SelectedText = CChar(ChrW(e.KeyValue))
    '            'cmsIntellisense.BringToFront()
    '            'e.SuppressKeyPress = True
    '            'e.Handled = True
    '            'cmsIntellisense.Show()
    '    End Select

    'End Sub


    Private Sub UpdateDescription()
        If Not bLoading Then
            Dim iIndex As Integer = tabsDescriptions.SelectedTab.VisibleIndex
            If Description IsNot Nothing Then Description(iIndex).Description = rtxtSource.Text
            If Description(iIndex).Description.EndsWith(vbCrLf) Then Description(iIndex).Description = sLeft(Description(iIndex).Description, Description(iIndex).Description.Length - 2) ' Fix UltraFormattedTextEditor bug that is adding an extra Carriage Return (urgh!)
            'If fileGraphics.Filename <> "" Then Description(tabsDescriptions.SelectedTab.Index).Description &= "<img src=""" & fileGraphics.Filename & """>"
            'If fileGraphics.Filename <> "" Then Description(iIndex).Description = "<img src=""" & fileGraphics.Filename & """>" & Description(iIndex).Description
            If sGraphicsTag <> "" Then Description(iIndex).Description = sGraphicsTag & Description(iIndex).Description
            If sAudioTag <> "" Then Description(iIndex).Description = sAudioTag & Description(iIndex).Description
            RaiseEvent Changed(Me, New EventArgs)
        End If
    End Sub


    Private WithEvents tmrMoveFocus As New Timer

    Private Sub GenTextbox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        tmrMoveFocus.Interval = 1
        tmrMoveFocus.Start()
    End Sub


    Private Sub tmrMoveFocus_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrMoveFocus.Tick
        tmrMoveFocus.Enabled = False
        ' Focus on textbox, not tab on enter   
        If Tabs.SelectedTab IsNot Nothing Then
            Select Case Tabs.SelectedTab.Key
                Case "tabSource"
                    rtxtSource.Focus()
                Case "tabPreview"
                    rtxtPreview.Focus()
                Case "tabGraphics"
                    fileGraphics.Focus()
            End Select
        End If
    End Sub


    Private Sub GenTextbox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        DisallowOKButton()
    End Sub

    Private Sub AllowOKButton()

        Dim ctlParent As Control = Me.Parent
        While Not TypeOf ctlParent Is Form
            ctlParent = ctlParent.Parent
            If ctlParent Is Nothing Then Exit Sub
        End While

        With CType(ctlParent, Form)
            For Each ctlButton As Control In .Controls
                If TypeOf ctlButton Is Infragistics.Win.Misc.UltraButton Then
                    If CType(ctlButton, Infragistics.Win.Misc.UltraButton).Text = "OK" Then
                        .AcceptButton = CType(ctlButton, Infragistics.Win.Misc.UltraButton)
                    End If
                End If
            Next
        End With

    End Sub

    Private Sub DisallowOKButton()

        Dim ctlParent As Control = Me.Parent
        While Not TypeOf ctlParent Is Form
            ctlParent = ctlParent.Parent
            If ctlParent Is Nothing Then Exit Sub
        End While

        With CType(ctlParent, Form)
            .AcceptButton = Nothing
        End With

    End Sub


    Private Sub InitSpellCheck()

        Try
            Me.UltraSpellChecker1 = New Infragistics.Win.UltraWinSpellChecker.UltraSpellChecker(Me.components)
            CType(Me.UltraSpellChecker1, System.ComponentModel.ISupportInitialize).BeginInit()
            'Me.UltraSpellChecker1.SetSpellCheckerSettings(Me.rtxtSource, New Infragistics.Win.UltraWinSpellChecker.SpellCheckerSettings(True))
            rtxtSource.SpellChecker = Me.UltraSpellChecker1


            With UltraSpellChecker1
                .ContainingControl = Me
                .Mode = Infragistics.Win.UltraWinSpellChecker.SpellCheckingMode.AsYouType
                .SpellOptions.AllowCapitalizedWords = True
                .SpellOptions.ConsiderationRange = 15
                .UnderlineSpellingErrorColor = System.Drawing.Color.Red
                .UnderlineSpellingErrorStyle = Infragistics.Win.UltraWinSpellChecker.UnderlineErrorsStyle.Squiggle
                .UseAppStyling = True
                CType(Me.UltraSpellChecker1, System.ComponentModel.ISupportInitialize).EndInit()

                Try
                    .UserDictionary = sUserDictionary
                Catch ex As UnauthorizedAccessException
                    ErrMsg("Error accessing user dictionary at " & sUserDictionary & vbCrLf & vbCrLf & "Please go to Settings and set the dictionary to a path you have write permissions for.")
                End Try
                If sMainDictionary <> "" Then
                    Try
                        .Dictionary = sMainDictionary
                    Catch exDict As Exception
                        ErrMsg("Error assigning main dictionary """ & sMainDictionary & """", exDict)
                        .Dictionary = ""
                    End Try
                End If
                Select Case sDictionary
                    Case "English"
                        .SpellOptions.LanguageParser = Infragistics.Win.UltraWinSpellChecker.LanguageType.English
                        '.Dictionary = ""
                    Case "Dutch"
                        .SpellOptions.LanguageParser = Infragistics.Win.UltraWinSpellChecker.LanguageType.Dutch
                    Case "French"
                        .SpellOptions.LanguageParser = Infragistics.Win.UltraWinSpellChecker.LanguageType.French
                    Case "German"
                        .SpellOptions.LanguageParser = Infragistics.Win.UltraWinSpellChecker.LanguageType.German
                    Case "Italian"
                        .SpellOptions.LanguageParser = Infragistics.Win.UltraWinSpellChecker.LanguageType.Italian
                    Case "Portugese"
                        .SpellOptions.LanguageParser = Infragistics.Win.UltraWinSpellChecker.LanguageType.Portuguese
                    Case "Spanish"
                        .SpellOptions.LanguageParser = Infragistics.Win.UltraWinSpellChecker.LanguageType.Spanish
                End Select
                Try
                    For Each sFunction As String In FunctionNames()
                        .IgnoreAll(sFunction)
                    Next
                    For Each sReference As String In ReferenceNames()
                        .IgnoreAll(sReference.Replace("%", ""))
                    Next
                    For Each sKey As String In Adventure.AllKeys()
                        If Not sKey.Contains("|") AndAlso Not sKey.Contains("_") AndAlso Not sKey.Contains(" ") Then .IgnoreAll(sKey)
                    Next
                    For Each oVar As clsVariable In Adventure.htblVariables.Values
                        If Not oVar.Name.Contains("_") AndAlso Not oVar.Name.Contains(" ") AndAlso Not oVar.Name.Contains("/") AndAlso Not oVar.Name.Contains("&") AndAlso Not oVar.Name.Contains("!") AndAlso Not oVar.Name.Contains("#") AndAlso Not oVar.Name.Contains("?") AndAlso Not oVar.Name.Contains("(") AndAlso Not oVar.Name.Contains(")") Then .IgnoreAll(oVar.Name)
                    Next
                Catch
                    ' In case it's not a 'proper' word.
                End Try
            End With
        Catch exDNF As System.IO.DirectoryNotFoundException
            ErrMsg(exDNF.Message)
        Catch ex As Exception
            ErrMsg("Error Initialising Spell Check", ex)
        End Try

    End Sub


    Private Sub GenTextbox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If DesignMode Then Exit Sub

        Try
            'DebugTimeRecord("GenTextbox Load")
            If Description IsNot Nothing AndAlso Description.Count < 2 Then
                If Not FirstTabHasRestrictions Then
                    Tabs.Parent = Me
                Else
                    SplitContainer.Parent = Me
                    Tabs.Parent = SplitContainer.Panel2
                End If
                tabsDescriptions.Visible = False
            End If

            imgGraphics.AllowDrop = True
            If Not bEnableGraphics Then Tabs.Tabs("tabGraphics").Visible = False
            If Not bEnableAudio Then Tabs.Tabs("tabAudio").Visible = False
            If Not bEnablePreview Then Tabs.Tabs("tabPreview").Visible = False

            If Not (bEnableGraphics Or bEnableAudio Or bEnablePreview) Then
                ' Don't display the right-hand tabs at all!
                ' Stick it on a TextEditor so we get a nice border
                'Dim pnl As New Infragistics.Win.UltraWinEditors.UltraComboEditor ' .UltraTextEditor                                                          
                'pnl.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
                'pnl.Parent = Tabs.Parent
                'pnl.AutoSize = False
                ''pnl.Multiline = True
                'pnl.Dock = DockStyle.Fill
                'pnl.ReadOnly = True                
                'pnl.BringToFront()

                Tabs.Visible = False
                tabsDescriptions.Parent = Me
                rtxtSource.Dock = DockStyle.Fill ' DockStyle.None
                'rtxtSource.Location = New Point(0, 0)
                'rtxtSource.Size = New Size(pnl.Width, pnl.Height)
                'rtxtSource.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
                rtxtSource.Parent = Tabs.Parent ' pnl
                rtxtSource.fte.Parent = Tabs.Parent ' Me.ParentForm ' pnl
                rtxtSource.fte.BringToFront() 'SendToBack()
                'pnl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False
                'pnl.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
            Else
                rtxtSource.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
                rtxtSource.Size = New Size(tabpageSource.Width + 2, tabpageSource.Height + 2)
            End If
            'rtxtSource.AutoWordSelection = False

            'DebugTimeFinish("GenTextbox Load")
        Catch ex As Exception
            ErrMsg("Error loading GenTextbox", ex)
        End Try

    End Sub

    Private Sub GenTextbox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        AllowOKButton()
    End Sub

    Private Sub GenTextbox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        Dim iTotalWidth As Integer = 0
        Dim iTabs As Integer = 1

        If bEnableAudio Then iTabs += 1
        If bEnableGraphics Then iTabs += 1
        If bEnablePreview Then iTabs += 1

        If Height > (45 * iTabs) Then
            Tabs.Tabs("tabSource").Text = "Source"
            Tabs.Tabs("tabPreview").Text = "Preview"
            Tabs.Tabs("tabGraphics").Text = "Graphics"
            Tabs.Tabs("tabAudio").Text = "Audio"
        ElseIf Height > (25 * iTabs) Then
            Tabs.Tabs("tabSource").Text = "Src"
            Tabs.Tabs("tabPreview").Text = "Pvw"
            Tabs.Tabs("tabGraphics").Text = "Gfx"
            Tabs.Tabs("tabAudio").Text = "Aud"
        Else
            Tabs.Tabs("tabSource").Text = "S"
            Tabs.Tabs("tabPreview").Text = "P"
            Tabs.Tabs("tabGraphics").Text = "G"
            Tabs.Tabs("tabAudio").Text = "A"
        End If

        If Height < 120 Then
            pnlButtons.Location = New Point(50, 19)
            pnlChannel.Location = New Point(pnlButtons.Width + 70, 21)
            chkLoop.Location = New Point(pnlButtons.Width + 72, 46)
        Else
            pnlButtons.Location = New Point(111, 2)
            pnlChannel.Location = New Point(134, 58)
            chkLoop.Location = New Point(247, 61)
        End If

        If iTabs > 1 Then
            rtxtSource.Size = New Size(tabpageSource.Width + 2, tabpageSource.Height + 2) '  New Size(rtxtPreview.Width + 2, rtxtPreview.Height + 2) 'rtxtPreview.Parent.Parent.Size.Width + 2, rtxtPreview.Parent.Parent.Size.Height + 2)        
        End If

    End Sub


    ' Fudge, because this event is firing before the text selection change registers
    Dim bPoppingUp As Boolean = False
    Private Sub UTMText_BeforeToolDropdown(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventArgs) Handles UTMText.BeforeToolDropdown
        If Not bPoppingUp Then
            e.Cancel = True
            bPoppingUp = True
            tmrToolDropdown.Interval = 1
            tmrToolDropdown.Start()
        Else
            bPoppingUp = False
            DropDownTool()
        End If
    End Sub


    Private Sub tmrToolDropdown_Tick(sender As Object, e As System.EventArgs) Handles tmrToolDropdown.Tick
        tmrToolDropdown.Stop()
        UTMText.ShowPopup("mnuPopup")
    End Sub


    Private Sub DropDownTool()
        Try
            'Application.DoEvents() ' Allow the cursor to finish moving first
            Debug.WriteLine(Now.ToString & " UTMText_BeforeToolDropdown")

            ' Check the current word
            Dim x1 As Integer = rtxtSource.SelectionStart
            Debug.Write("X1: " & x1)
            While x1 > 0 AndAlso System.Text.RegularExpressions.Regex.IsMatch(rtxtSource.Text(x1 - 1), "[A-Za-z]") ' AndAlso rtxtSource.Text(x1 - 1) <> " " AndAlso rtxtSource.Text(x1 - 1) <> "." AndAlso rtxtSource.Text(x1 - 1) <> "," AndAlso rtxtSource.Text(x1 - 1) <> vbLf                
                x1 -= 1
            End While
            Dim x2 As Integer = rtxtSource.SelectionStart
            Debug.WriteLine(", X2: " & x2)
            While x2 <= rtxtSource.TextLength - 1 AndAlso System.Text.RegularExpressions.Regex.IsMatch(rtxtSource.Text(x2), "[A-Za-z]") ' AndAlso rtxtSource.Text(x2) <> " " AndAlso rtxtSource.Text(x2) <> "." AndAlso rtxtSource.Text(x2) <> "," AndAlso rtxtSource.Text(x2) <> vbCr
                x2 += 1
            End While
            x2 -= 1
            Dim sSelectedWord As String = rtxtSource.Text.Substring(x1, x2 - x1 + 1)
            Debug.WriteLine("Selected word: #" & sSelectedWord & "# (" & x1 & ", " & x2 - x1 + 1 & ")")
            iWordStart = x1

            CType(UTMText.Tools("mnuPopup"), PopupMenuTool).Tools.Clear()

            If sSelectedWord <> "" Then
                If UltraSpellChecker1 Is Nothing Then InitSpellCheck()
                Dim result As WordCheckResult = UltraSpellChecker1.CheckWord(sSelectedWord)
                If Not result.SpelledCorrectly Then
                    sWord = sSelectedWord
                    Dim iIndex As Integer = 0
                    For Each sSuggestion As String In result.SpellingError.Suggestions
                        Debug.WriteLine(sSuggestion)
                        Dim menu As ButtonTool = AddToMenu("mnuPopup", "Suggestion_" & sSuggestion, sSuggestion, True, iIndex)
                        iIndex += 1
                    Next
                    AddToMenu("mnuPopup", "Ignore", "I&gnore").InstanceProps.IsFirstInGroup = True
                    AddToMenu("mnuPopup", "IgnoreAll", "&Ignore All")
                    AddToMenu("mnuPopup", "AddToDictionary", "&Add to Dictionary")

                    AddToMenu("mnuPopup", "Language", "&Language").InstanceProps.IsFirstInGroup = True
                    With AddToMenu("mnuPopup", "CheckSpelling", "&Spelling...").InstanceProps
                        .AppearancesSmall.Appearance.Image = Global.ADRIFT.My.Resources.imgSpelling
                    End With

                    With AddToMenu("mnuPopup", "Cut", "Cu&t")
                        .InstanceProps.IsFirstInGroup = True
                        .InstanceProps.AppearancesSmall.Appearance.Image = Global.ADRIFT.My.Resources.imgCut
                        .SharedProps.Enabled = (rtxtSource.SelectionLength > 0)
                    End With
                    With AddToMenu("mnuPopup", "Copy", "&Copy")
                        .InstanceProps.AppearancesSmall.Appearance.Image = Global.ADRIFT.My.Resources.imgCopy
                        .SharedProps.Enabled = (rtxtSource.SelectionLength > 0)
                    End With
                    With AddToMenu("mnuPopup", "Paste", "&Paste")
                        .InstanceProps.AppearancesSmall.Appearance.Image = Global.ADRIFT.My.Resources.imgPaste
                        .SharedProps.Enabled = Clipboard.ContainsText
                    End With

                    Exit Sub
                End If
            End If

            sWord = ""
            With AddToMenu("mnuPopup", "Cut", "Cu&t")
                .InstanceProps.AppearancesSmall.Appearance.Image = Global.ADRIFT.My.Resources.imgCut
                .SharedProps.Enabled = (rtxtSource.SelectionLength > 0)
            End With
            With AddToMenu("mnuPopup", "Copy", "&Copy")
                .InstanceProps.AppearancesSmall.Appearance.Image = Global.ADRIFT.My.Resources.imgCopy
                .SharedProps.Enabled = (rtxtSource.SelectionLength > 0)
            End With
            With AddToMenu("mnuPopup", "Paste", "&Paste")
                .InstanceProps.AppearancesSmall.Appearance.Image = Global.ADRIFT.My.Resources.imgPaste
                .SharedProps.Enabled = Clipboard.ContainsText
            End With

            If bAllowAlternateDescriptions Then
                With AddToMenu("mnuPopup", "AddAlternateDescription", "Add Alternative Description").InstanceProps
                    .IsFirstInGroup = True
                    .AppearancesSmall.Appearance.Image = Global.ADRIFT.My.Resources.imgNew16
                End With
            End If

            With CType(AddToMenu("mnuPopup", "ShowOnce", "Only Display &Once", , , ButtonType.StateButtonTool), Infragistics.Win.UltraWinToolbars.StateButtonTool)
                .Checked = Description(tabsDescriptions.SelectedTab.VisibleIndex).DisplayOnce
            End With
            With CType(AddToMenu("mnuPopup", "ReturnToDefault", "&Return to Default", , , ButtonType.StateButtonTool), Infragistics.Win.UltraWinToolbars.StateButtonTool)
                .SharedProps.Enabled = Description(tabsDescriptions.SelectedTab.VisibleIndex).DisplayOnce
                .Checked = Description(tabsDescriptions.SelectedTab.VisibleIndex).ReturnToDefault
                If Not .SharedProps.Enabled Then .Checked = False
            End With

        Catch ex As Exception
            ErrMsg("BeforeToolDropdown error", ex)
        End Try

    End Sub


    Private Sub UTMText_ToolClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UTMText.ToolClick
        DoToolClick(e.Tool.Key, e.Tool.SharedProps.Caption, CStr(e.Tool.SharedProps.Tag))
    End Sub


    Private Sub DoToolClick(ByVal sKey As String, ByVal sCaption As String, ByVal sTag As String)

        fGenerator.sDestinationList = ""

        Select Case sKey
            Case "AddAlternateDescription"
                AddTab()
            Case "AddToDictionary"
                UltraSpellChecker1.AddWordToUserDictionary(sWord)
            Case "CheckSpelling"
                UltraSpellChecker1.ShowSpellCheck(Me.rtxtSource)
            Case "Copy"
                'Try
                '    Clipboard.SetText(rtxtSource.SelectedText)
                'Catch
                'End Try
                rtxtSource.EditInfo.PerformAction(Infragistics.Win.FormattedLinkLabel.FormattedLinkEditorAction.Copy)
            Case "Cut"
                'Try
                '    Clipboard.SetText(rtxtSource.SelectedText)
                '    rtxtSource.SelectedText = ""
                'Catch
                'End Try   
                rtxtSource.EditInfo.PerformAction(Infragistics.Win.FormattedLinkLabel.FormattedLinkEditorAction.Cut)
            Case "Ignore"
                UltraSpellChecker1.IgnoreError(Me.rtxtSource, UltraSpellChecker1.GetErrorAtPoint(Me.rtxtSource, rtxtSource.GetPositionFromCharIndex(rtxtSource.EditInfo.SelectionStart)))
            Case "IgnoreAll"
                UltraSpellChecker1.IgnoreAll(sWord)
            Case "Paste"
                'rtxtSource.SelectedText = Clipboard.GetText
                rtxtSource.EditInfo.PerformAction(Infragistics.Win.FormattedLinkLabel.FormattedLinkEditorAction.Paste)
            Case "ShowOnce"
                Description(tabsDescriptions.SelectedTab.VisibleIndex).DisplayOnce = CType(UTMText.Tools("ShowOnce"), StateButtonTool).Checked
            Case "ReturnToDefault"
                Description(tabsDescriptions.SelectedTab.VisibleIndex).ReturnToDefault = CType(UTMText.Tools("ReturnToDefault"), StateButtonTool).Checked
            Case Else
                If sKey.StartsWith("Suggestion_") Then
                    Dim iPos As Integer = rtxtSource.SelectionStart
                    rtxtSource.Text = sLeft(rtxtSource.Text, iWordStart) & sKey.Replace("Suggestion_", "") & sRight(rtxtSource.Text, rtxtSource.TextLength - iWordStart - sWord.Length)
                    rtxtSource.SelectionStart = iPos
                End If
        End Select

    End Sub



    Private Sub tabsDescriptions_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabsDescriptions.SelectedTabChanged

        If e.Tab IsNot Nothing Then
            If e.Tab.Key = "tabNew" Then AddTab()

            If e.Tab.Key = "tabDefault" AndAlso Not FirstTabHasRestrictions Then
                SplitContainer.Panel1Collapsed = True
            Else
                SplitContainer.Panel1Collapsed = False
            End If
            If Description IsNot Nothing Then LoadTab(Description(tabsDescriptions.SelectedTab.VisibleIndex))
        End If

    End Sub



    Private Sub AddTab()

        If Not tabsDescriptions.Visible Then            
            SplitContainer.Parent = tabsDescriptions.SharedControlsPage            
            If Tabs.Visible Then
                Tabs.BeginUpdate()
                Tabs.Parent = SplitContainer.Panel2
                Tabs.Dock = DockStyle.None
                Tabs.Location = New Point(-1, -1)
                Tabs.Size = New Size(SplitContainer.Panel2.Width + 2, SplitContainer.Panel2.Height + 2)
                Tabs.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                Tabs.EndUpdate()
            Else
                Dim pnl As OOTextbox = rtxtSource ' Infragistics.Win.UltraWinEditors.UltraComboEditor = CType(rtxtSource.Parent, Infragistics.Win.UltraWinEditors.UltraComboEditor)
                pnl.Parent = SplitContainer.Panel2
                pnl.Dock = DockStyle.None
                pnl.Location = New Point(-1, -1)
                pnl.Size = New Size(SplitContainer.Panel2.Width + 2, SplitContainer.Panel2.Height + 2)
                pnl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top                
            End If
            tabsDescriptions.Visible = True
        End If

        Dim iTabs As Integer = tabsDescriptions.Tabs.Count - 1
        Dim sd As New SingleDescription()
        Description.Add(sd)
        Dim sTabName As String = "Alternative Description " & iTabs
        While tabsDescriptions.Tabs.Exists("tab" & iTabs)
            iTabs += 1
            sTabName = "Alternative Description " & iTabs
        End While
        bAdding = True
        Dim tabNew As Infragistics.Win.UltraWinTabControl.UltraTab = tabsDescriptions.Tabs.Insert(tabsDescriptions.Tabs.Count - 1, "tab" & iTabs, sTabName)
        tabNew.VisibleIndex = tabsDescriptions.Tabs.Count - 2
        bAdding = False
        tabsDescriptions.SelectedTab = tabsDescriptions.Tabs("tab" & iTabs)
        fileGraphics.Filename = ""
        LoadTab()

    End Sub


    Private Function StartsWithIgnoringTags(ByVal sDescription As String, ByVal sMatch As String) As Boolean

        If sDescription.StartsWith(sMatch) Then Return True

        ' Ok, get rid of any tags at the start
        While sDescription.StartsWith("<")
            If sDescription.Contains(">") Then
                sDescription = sDescription.Substring(sDescription.IndexOf(">") + 1)
                Return StartsWithIgnoringTags(sDescription, sMatch)
            Else
                Return False
            End If
        End While

        Return False

    End Function

    Private Sub LoadGraphics(ByRef sDescription As String)

        Dim re As New System.Text.RegularExpressions.Regex(IMGREGEX, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        If re.IsMatch(sDescription) Then
            Dim sMatch As String = re.Match(sDescription).ToString
            If re.Matches(sDescription).Count = 1 AndAlso sDescription.StartsWith(sMatch) Then ' Can't ignore tags here as we want <cls> and <centre> to be allowed before initial image
                Dim sLocation As String = sMid(sMatch, 10, sMatch.Length - 10)
                If sLocation.StartsWith("""") Then sLocation = sLocation.Substring(1)
                If sLocation.EndsWith("""") Then sLocation = sLocation.Substring(0, sLocation.Length - 1)
                Me.fileGraphics.Filename = sLocation
                sDescription = sDescription.Replace(sMatch, "")
            Else
                Tabs.Tabs("tabGraphics").Visible = False
            End If
        Else
            Me.fileGraphics.Filename = ""
        End If

    End Sub

    Private Sub LoadAudio(ByRef sDescription As String)

        Dim re As New System.Text.RegularExpressions.Regex(AUDREGEX, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        If re.IsMatch(sDescription) Then
            Dim m As System.Text.RegularExpressions.Match = re.Match(sDescription)
            Dim sMatch As String = m.ToString
            If re.Matches(sDescription).Count = 1 AndAlso StartsWithIgnoringTags(sDescription, sMatch) Then ' sDescription.StartsWith(sMatch) Then
                If m.Groups("src").Length > 0 Then
                    Dim sLocation As String = m.Groups("src").Value ' sMid(sMatch, 10, sMatch.Length - 10)
                    If sLocation.StartsWith("""") Then sLocation = sLocation.Substring(1)
                    If sLocation.EndsWith("""") Then sLocation = sLocation.Substring(0, sLocation.Length - 1)
                    Me.fileAudio.Filename = sLocation
                End If
                If m.Groups("channel").Length > 0 Then
                    nudChannel.Value = SafeInt(m.Groups("channel").Value)
                End If
                If m.Groups("loop").Length > 0 Then
                    chkLoop.Checked = (m.Groups("loop").Value.ToUpper = "Y")
                End If
                If sMatch.Contains(" pause") Then
                    chkPause.Checked = True
                ElseIf sMatch.Contains(" stop") Then
                    chkStop.Checked = True
                Else
                    chkPlay.Checked = True
                End If
                sDescription = sDescription.Replace(sMatch, "")
            Else
                Tabs.Tabs("tabAudio").Visible = False
            End If
        Else
            Me.fileAudio.Filename = ""
        End If

    End Sub


    Private Sub LoadTab(Optional ByVal sd As SingleDescription = Nothing)

        bLoading = True
        If sd Is Nothing Then sd = New SingleDescription

        'SplitContainer.Panel1Collapsed = False
        RestrictSummary.LoadRestrictions(sd.Restrictions)
        RestrictSummary.sCommand = Me.sCommand
        RestrictSummary.Arguments = Me.Arguments
        SetMetLabel()

        Dim sDescription As String = sd.Description

        Dim iGraphics As Integer = sDescription.IndexOf("<img ")
        Dim iAudio As Integer = sDescription.IndexOf("<audio ")

        If iGraphics < iAudio Then
            LoadGraphics(sDescription)
            LoadAudio(sDescription)
        Else
            LoadAudio(sDescription)
            LoadGraphics(sDescription)
        End If

        rtxtSource.Text = sDescription
        If sDescription.EndsWith(vbCrLf) Then rtxtSource.Text &= vbCrLf ' Add the extra vbCrLf to fix the UltraFormattedTextEditor bug (urgh!)
        SetCombo(cmbDisplayWhen, sd.eDisplayWhen)
        bLoading = False

        'Audio_Changed(Nothing, Nothing) ' So we save our sAudioTag
        'fileGraphics_TextChanged(Nothing, Nothing)

    End Sub


    Private Sub RestrictSummary_RestrictionsChanged() Handles RestrictSummary.RestrictionsChanged
        Description(tabsDescriptions.SelectedTab.VisibleIndex).Restrictions = RestrictSummary.arlRestrictions
        SetMetLabel()
        RaiseEvent Changed(Me, New EventArgs)
    End Sub


    Private Sub SetMetLabel()
        If RestrictSummary.arlRestrictions.Count <= 1 Then
            lblAreAllMetThen.Text = "   is met then"
        Else
            lblAreAllMetThen.Text = "are all met then"
        End If
    End Sub


    Private Sub fileGraphics_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles fileGraphics.DragDrop, imgGraphics.DragDrop, lblImageInstructions.DragDrop

        Dim sFilename As String = String.Empty
        If GetFilename(sFilename, e) Then
            fileGraphics.Filename = sFilename
        End If

    End Sub


    Private Sub fileGraphics_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles fileGraphics.DragEnter, imgGraphics.DragEnter, lblImageInstructions.DragEnter

        Dim sFilename As String = String.Empty
        If GetFilename(sFilename, e) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub


    Private Function GetFilename(ByRef filename As String, ByVal e As DragEventArgs) As Boolean

        Try
            Dim ret As Boolean = False
            filename = String.Empty

            If ((e.AllowedEffect And DragDropEffects.Copy) = DragDropEffects.Copy) Then
                Dim oData As Object = e.Data.GetData("FileName")
                If oData IsNot Nothing Then
                    If TypeOf oData Is String() Then filename = CType(oData, String())(0)
                Else
                    filename = CStr((e.Data).GetData("System.String")) ' FileName into Array...?
                End If

                If filename IsNot Nothing Then
                    Dim ext As String = IO.Path.GetExtension(filename).ToLower
                    Select Case ext
                        Case ".jpg", ".png", ".bmp", ".gif"
                            Return True
                        Case Else
                            Return False
                    End Select
                End If

            End If
        Catch ex As Exception
            Return False
        End Try

    End Function



    Private Enum ButtonType
        ButtonTool
        StateButtonTool
    End Enum
    Private Function AddToMenu(ByVal sMenuKey As String, ByVal sKey As String, ByVal sDescription As String, Optional ByVal bBold As Boolean = False, Optional ByVal iIndex As Integer = -1, Optional ByVal eType As ButtonType = ButtonType.ButtonTool) As ButtonTool

        If Not UTMText.Tools.Exists(sKey) Then
            Dim newTool As ButtonTool
            Select Case eType
                Case ButtonType.StateButtonTool
                    newTool = New StateButtonTool(sKey)
                Case Else
                    newTool = New ButtonTool(sKey)
            End Select
            newTool.SharedProps.Caption = sDescription
            If bBold Then newTool.SharedProps.AppearancesSmall.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            UTMText.Tools.Add(newTool)
        End If

        Dim newInstance As ButtonTool = Nothing

        If iIndex > -1 Then
            newInstance = CType(CType(UTMText.Tools(sMenuKey), PopupMenuTool).Tools.InsertTool(iIndex, sKey), ButtonTool)
        Else
            newInstance = CType(CType(UTMText.Tools(sMenuKey), PopupMenuTool).Tools.AddTool(sKey), ButtonTool)
        End If

        Return newInstance

    End Function


    'Private iSelStartCache As Integer = -1
    Private Sub rtxtSource_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rtxtSource.MouseDown

        'If e.Button = Windows.Forms.MouseButtons.Right AndAlso rtxtSource.SelectionLength = 0 Then
        '    rtxtSource.SelectionStart = rtxtSource.GetCharIndexFromPosition(rtxtSource.PointToClient(MousePosition))
        '    'If rtxtSource.SelectionStart = rtxtSource.TextLength - 1 Then rtxtSource.SelectionStart = rtxtSource.TextLength ' Dunno why it's doing this...
        '    Dim ptMouse As Point = rtxtSource.PointToClient(MousePosition)
        '    Dim ptLastChar As Point = rtxtSource.GetPositionFromCharIndex(rtxtSource.TextLength)
        '    If ptMouse.Y > ptLastChar.Y + 16 OrElse (ptMouse.X > ptLastChar.X AndAlso ptMouse.Y > ptLastChar.Y) Then
        '        rtxtSource.SelectionStart = rtxtSource.TextLength
        '    End If
        'End If

        'If Not Control.ModifierKeys = Keys.Shift Then
        '    iSelStartCache = rtxtSource.GetCharIndexFromPosition(rtxtSource.PointToClient(MousePosition))
        '    If rtxtSource.SelectionStart > iSelStartCache Then
        '        iSelStartCache = rtxtSource.SelectionStart
        '    End If
        'End If

        'If Control.ModifierKeys = Keys.Shift Then
        '    FixSelections()
        'End If
        'rtxtSource.AutoWordSelection = False
    End Sub


    'Private Sub rtxtSource_SelectionChanged(sender As Object, e As System.EventArgs) Handles rtxtSource.SelectionChanged
    '    'If Not Control.ModifierKeys = Keys.Shift AndAlso Not MouseButtons = Windows.Forms.MouseButtons.Left Then iSelStartCache = rtxtSource.SelectionStart
    'End Sub


    'Private Sub rtxtSource_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles rtxtSource.MouseMove

    '    If MouseButtons = Windows.Forms.MouseButtons.Left AndAlso iSelStartCache <> -1 Then
    '        FixSelections()
    '    End If

    'End Sub


    '' The RichTextBox doesn't select things properly on certain characters, so we have to overrride it... :(
    'Private Sub FixSelections()
    '    Exit Sub
    '    Dim ptMouse As Point = rtxtSource.PointToClient(MousePosition)
    '    Dim iNewIndex As Integer = rtxtSource.GetCharIndexFromPosition(ptMouse) ' + 1        

    '    ' Select right to the end if we're definitely past the end of the text
    '    Dim ptLastChar As Point = rtxtSource.GetPositionFromCharIndex(rtxtSource.TextLength)
    '    If ptMouse.Y > ptLastChar.Y + 16 OrElse (ptMouse.X > ptLastChar.X AndAlso ptMouse.Y > ptLastChar.Y) Then
    '        iNewIndex = rtxtSource.TextLength '+ 1
    '    End If

    '    rtxtSource.SuspendLayout()
    '    If iNewIndex > iSelStartCache Then
    '        If rtxtSource.SelectionStart <> iSelStartCache Then rtxtSource.SelectionStart = iSelStartCache
    '        If rtxtSource.SelectionLength <> iNewIndex - iSelStartCache Then rtxtSource.SelectionLength = iNewIndex - iSelStartCache
    '    ElseIf iNewIndex < iSelStartCache Then
    '        If rtxtSource.SelectionStart <> iNewIndex Then rtxtSource.SelectionStart = iNewIndex
    '        If rtxtSource.SelectionLength <> iSelStartCache - iNewIndex Then rtxtSource.SelectionLength = iSelStartCache - iNewIndex
    '    End If
    '    rtxtSource.ResumeLayout()
    '    'rtxtSource.Visible = True

    'End Sub


    'Private bLastPressedDot As Boolean = False
    Private Sub rtxtSource_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rtxtSource.KeyDown

        If UltraSpellChecker1 Is Nothing Then InitSpellCheck()

        'bLastPressedDot = False
        Select Case e.KeyData
            Case Keys.Control Or Keys.T
                AddTab()
                'Case Keys.OemPeriod
                '    bLastPressedDot = True            
        End Select

    End Sub


    Private Sub Audio_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles fileAudio.TextChanged, chkLoop.CheckedChanged, chkPlay.CheckedChanged, chkPause.CheckedChanged, chkStop.CheckedChanged, nudChannel.ValueChanged
        Try
            If Description Is Nothing Then Exit Sub ' OrElse bLoading  ' this stops audio being set on load

            Dim iIndex As Integer = 0
            If tabsDescriptions.SelectedTab IsNot Nothing Then iIndex = tabsDescriptions.SelectedTab.VisibleIndex

            Dim sType As String = ""
            If chkPlay.Checked Then
                sType = " play"
            ElseIf chkPause.Checked Then
                sType = " pause"
            ElseIf chkStop.Checked Then
                sType = " stop"
            End If

            ' Trim off any existing <audio> tag
            Dim re As New System.Text.RegularExpressions.Regex(AUDREGEX, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            If re.IsMatch(Description(iIndex).Description) Then
                If re.Matches(Description(iIndex).Description).Count = 1 Then
                    Dim sMatch As String = re.Match(Description(iIndex).Description).ToString
                    'If Description(iIndex).Description.StartsWith(sMatch) Then
                    Description(iIndex).Description = Description(iIndex).Description.Replace(sMatch, "")
                    'End If
                End If
            End If

            sAudioTag = ""
            If sType <> "" Then
                Dim sSrc As String = ""

                If sType = " play" AndAlso fileAudio.Filename <> "" Then
                    If IO.File.Exists(fileAudio.Filename) OrElse fileAudio.Filename.ToLower.StartsWith("http") Then
                        fileAudio.txtDir.ForeColor = SystemColors.ControlText

                        'Description(iIndex).Description = "<audio src=""" & fileAudio.Filename & """>" & Description(iIndex).Description
                        sSrc = " src=""" & fileAudio.Filename & """"
                    End If
                End If

                Dim sChannel As String = ""
                If nudChannel.Value > 1 Then sChannel = " channel=" & nudChannel.Value

                Dim sLoop As String = ""
                If chkLoop.Checked AndAlso sType = " play" Then sLoop = " loop=Y"

                Dim sAudio As String = "<audio" & sType & sSrc & sChannel & sLoop & ">"

                If Not (sType = " play" AndAlso fileAudio.Filename = "") Then
                    sAudioTag = sAudio
                    Description(iIndex).Description = sAudioTag & Description(iIndex).Description
                End If
            End If

            If sender IsNot Nothing Then RaiseEvent Changed(sender, e)

        Catch ex As Exception
            ErrMsg("Load Audio error", ex)
        End Try
    End Sub


    Private Sub chkPlay_CheckedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPlay.CheckedValueChanged
        If chkPlay.Checked AndAlso fileAudio.Filename = "" Then
            fileAudio.OpenFileDialog()
        End If
    End Sub


    Private Sub fileGraphics_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fileGraphics.TextChanged
        Try
            'If bLoading Then Exit Sub ' this stops graphics from appearing when loading the form

            Dim iIndex As Integer = 0
            If tabsDescriptions.SelectedTab IsNot Nothing Then iIndex = tabsDescriptions.SelectedTab.VisibleIndex

            ' Trim off any existing <img> tag - Why, this just deletes the tag from the text?
            Dim re As New System.Text.RegularExpressions.Regex(IMGREGEX, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            If re.IsMatch(Description(iIndex).Description) Then
                If re.Matches(Description(iIndex).Description).Count = 1 Then
                    Dim sMatch As String = re.Match(Description(iIndex).Description).ToString
                    'If Description(iIndex).Description.StartsWith(sMatch) Then
                    Description(iIndex).Description = Description(iIndex).Description.Replace(sMatch, "")
                    'End If
                End If
            End If

            sGraphicsTag = ""
            If fileGraphics.Filename <> "" Then
                If IO.File.Exists(fileGraphics.Filename) OrElse fileGraphics.Filename.ToLower.StartsWith("http") Then
                    fileGraphics.txtDir.ForeColor = Color.DarkRed
                    Me.Cursor = Cursors.WaitCursor
                    imgGraphics.Load(fileGraphics.Filename) ' Loads either from file or from URL
                    fileGraphics.txtDir.ForeColor = SystemColors.ControlText
                    lblImageInstructions.Visible = False

                    'Dim bResult As Boolean
                    'bResult = New System.Text.RegularExpressions.Regex("[a-zA-Z]:(\\[\w_\.]+)*\.\w+").IsMatch("C:\Users\CampbellWild\Pictures\hon\GEGEBEASKJVV.jpg")

                    If fileGraphics.Filename <> "" Then
                        sGraphicsTag = "<img src=""" & fileGraphics.Filename & """>"
                        Description(iIndex).Description = sGraphicsTag & Description(iIndex).Description
                    End If
                    Me.Cursor = Cursors.Arrow
                End If
            Else
                imgGraphics.Image = Nothing
                lblImageInstructions.Visible = True
                'If Description(iIndex).Description.StartsWith("<img src=") AndAlso Description(iIndex).Description.Contains(">") Then
                '    Description(iIndex).Description = Description(iIndex).Description.Substring(Description(iIndex).Description.IndexOf(">") + 1)
                'End If
            End If

            If sender IsNot Nothing Then RaiseEvent Changed(sender, e)

        Catch exArg As System.ArgumentException
            imgGraphics.Image = Nothing
        Catch exWeb As System.Net.WebException
            imgGraphics.Image = Nothing
        Catch exFNF As IO.FileNotFoundException
            imgGraphics.Image = Nothing
        Catch exIO As IO.IOException
            imgGraphics.Image = Nothing
        Catch ex As Exception
            ErrMsg("Load Graphics error", ex)
        End Try
    End Sub


    Public Shadows Function Focus() As Boolean
        Return rtxtSource.Focus()
    End Function


    Private Sub cmbDisplayWhen_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDisplayWhen.ValueChanged
        Dim iIndex As Integer = 0
        If tabsDescriptions.SelectedTab IsNot Nothing Then iIndex = tabsDescriptions.SelectedTab.VisibleIndex
        Dim eNewDisplayWhen As SingleDescription.DisplayWhenEnum = CType(cmbDisplayWhen.SelectedItem.DataValue, SingleDescription.DisplayWhenEnum)
        If Description(iIndex).eDisplayWhen <> eNewDisplayWhen Then
            Description(iIndex).eDisplayWhen = eNewDisplayWhen
            RaiseEvent Changed(Me, New EventArgs)
        End If

    End Sub


    Private Sub mnuDeleteTab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDeleteTab.Click

        If tabRightClick IsNot Nothing Then
            If Description(tabRightClick.Index).Description <> "" OrElse Description(tabRightClick.Index).Restrictions.Count > 0 Then
                If MsgBox("Are you sure you wish to delete tab " & tabRightClick.Text & "?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            End If

            Description.RemoveAt(tabRightClick.VisibleIndex)
            tabsDescriptions.Tabs.RemoveAt(tabRightClick.Index)
            RaiseEvent Changed(sender, e)
        End If

    End Sub

    Private Sub cmsTabs_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsTabs.Opening
        tabRightClick = tabsDescriptions.TabFromPoint(tabsDescriptions.PointToClient(MousePosition))
        If tabRightClick Is Nothing Then
            e.Cancel = True
        ElseIf tabRightClick.Key = "tabDefault" OrElse tabRightClick.Text = " " Then
            e.Cancel = True
        End If
        'mnuDeleteTab.Visible = Not (tabRightClick Is Nothing OrElse tabRightClick.Key = "tabDefault")
        'If tabRightClick.Text = " " Then e.Cancel = True ' "New" tab
    End Sub


    Private Sub miRenameTab_Click(sender As Object, e As System.EventArgs) Handles miRenameTab.Click

        If tabRightClick IsNot Nothing Then
            Dim sTabLabel As String = InputBox("Enter tab label:", "Rename tab", tabRightClick.Text)
            If sTabLabel <> "" Then
                tabRightClick.Text = sTabLabel

                Dim iIndex As Integer = tabRightClick.VisibleIndex
                If Description IsNot Nothing Then Description(iIndex).sTabLabel = sTabLabel
                RaiseEvent Changed(Me, New EventArgs)
            End If
        End If
    End Sub



    Private bAdding As Boolean = False
    Private Sub tabsDescriptions_TabMoved(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabControl.TabMovedEventArgs) Handles tabsDescriptions.TabMoved

        If bAdding Then Exit Sub

        Dim iTab1 As Integer = CInt(e.Tab.Tag) ' e.Tab.VisibleIndex
        Dim iTab2 As Integer = CInt(e.RelativeTab.Tag) ' e.RelativeTab.VisibleIndex

        'Debug.WriteLine("Moving tab at position " & iTab1 & " to " & e.RelativePosition.ToString & " tab at position " & iTab2)

        If iTab1 < iTab2 Then
            If e.RelativePosition = Infragistics.Win.RelativePosition.Before Then iTab2 -= 1
        Else
            If e.RelativePosition = Infragistics.Win.RelativePosition.After Then iTab2 += 1
        End If

        'If iTab1 = iTab2 Then
        '    Debug.WriteLine("Nothing needs doing")
        'Else
        '    Debug.WriteLine("Move tab " & iTab1 & " to " & iTab2)
        'End If

        ''Exit Sub

        'For i As Integer = Math.Min(iTab1, iTab2) To Math.Max(iTab1, iTab2) - 1
        '    Dim tempDesc As SingleDescription = oDescription(i)
        '    oDescription(i) = oDescription(i + 1)
        '    oDescription(i + 1) = tempDesc
        'Next

        Dim tempDesc As SingleDescription = oDescription(iTab1)
        If iTab2 > iTab1 Then
            For i As Integer = iTab1 To iTab2 - 1
                oDescription(i) = oDescription(i + 1)
            Next
        Else
            For i As Integer = iTab1 To iTab2 + 1 Step -1
                oDescription(i) = oDescription(i - 1)
            Next
        End If
        oDescription(iTab2) = tempDesc

        'oDescription(iTab1) = oDescription(iTab2)
        'oDescription(iTab2) = tempDesc


    End Sub


    ' Don't allow user to move a tab before the default one
    Private Sub tabsDescriptions_TabMoving(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabControl.TabMovingEventArgs) Handles tabsDescriptions.TabMoving
        If e.Tab Is tabsDescriptions.Tabs(0) Then e.Cancel = True
        If e.RelativePosition = Infragistics.Win.RelativePosition.Before AndAlso e.RelativeTab Is tabsDescriptions.Tabs(0) Then e.Cancel = True
        If e.RelativePosition = Infragistics.Win.RelativePosition.After AndAlso e.RelativeTab Is tabsDescriptions.Tabs(tabsDescriptions.Tabs.Count - 1) Then e.Cancel = True
        e.Tab.Tag = e.Tab.VisibleIndex
        e.RelativeTab.Tag = e.RelativeTab.VisibleIndex
    End Sub


    
    Private Sub chkPlay_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPlay.CheckedChanged
        fileAudio.Enabled = chkPlay.Checked
        chkLoop.Enabled = chkPlay.Checked
        If chkPlay.Checked Then
            chkPause.Checked = False
            chkStop.Checked = False
        End If
    End Sub

    Private Sub chkPause_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPause.CheckedChanged
        If chkPause.Checked Then
            chkPlay.Checked = False
            chkStop.Checked = False
        End If
    End Sub

    Private Sub chkStop_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkStop.CheckedChanged
        If chkStop.Checked Then
            chkPlay.Checked = False
            chkPause.Checked = False
        End If
    End Sub

    Private Sub chkPlay_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles chkPlay.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then PlaySound(fileAudio.Filename, CInt(nudChannel.Value), chkLoop.Checked)
    End Sub

    Private Sub chkPause_Click(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles chkPause.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then PauseSound(CInt(nudChannel.Value))
    End Sub

    Private Sub chkStop_Click(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles chkStop.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then StopSound(CInt(nudChannel.Value))
    End Sub

    Private Sub chkPlayPauseStop_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles chkPlay.MouseDown, chkPause.MouseDown, chkStop.MouseDown
        CType(sender, Infragistics.Win.UltraWinEditors.UltraCheckEditor).HotTrackingAppearance.BorderColor = Color.Transparent
    End Sub

    Private Sub chkPauseStop_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles chkPause.MouseUp, chkStop.MouseUp
        nudChannel.Focus()
        CType(sender, Infragistics.Win.UltraWinEditors.UltraCheckEditor).HotTrackingAppearance.BorderColor = SystemColors.ActiveBorder
    End Sub

    Private Sub chkPlay_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles chkPlay.MouseUp
        If fileAudio.Enabled Then fileAudio.Focus() Else nudChannel.Focus()
        CType(sender, Infragistics.Win.UltraWinEditors.UltraCheckEditor).HotTrackingAppearance.BorderColor = SystemColors.ActiveBorder
    End Sub

End Class
