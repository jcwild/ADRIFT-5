<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GenTextbox
    Inherits System.Windows.Forms.UserControl

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
    Friend WithEvents nudChannel As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblChannel As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkLoop As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents pnlAudio As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents pnlChannel As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents lblImageInstructions As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkPlay As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkStop As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkPause As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents tabpageGraphics As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    '<System.Diagnostics.DebuggerStepThrough()> 
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("tbFormat")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("CheckSpelling")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnBold")
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnItalics")
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnUnderline")
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnSecondaryColour")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("CheckSpelling")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim PopupMenuTool1 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuPopup")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("CheckSpelling")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("AddAlternateDescription")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("AddAlternateDescription")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnBold")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool11 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnItalics")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool12 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnUnderline")
        Dim ButtonTool13 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnSecondaryColour")
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me._Panel2_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._Panel2_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
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
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tabpageSource.Size = New System.Drawing.Size(442, 348)
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
        Me.txtBorder.Size = New System.Drawing.Size(442, 348)
        Me.txtBorder.TabIndex = 1
        Me.txtBorder.TabStop = False
        Me.txtBorder.Text = "UltraTextEditor1"
        '
        'tabpagePreview
        '
        Me.tabpagePreview.Controls.Add(Me.rtxtPreview)
        Me.tabpagePreview.Location = New System.Drawing.Point(-10000, -10000)
        Me.tabpagePreview.Name = "tabpagePreview"
        Me.tabpagePreview.Size = New System.Drawing.Size(442, 348)
        '
        'rtxtPreview
        '
        Me.rtxtPreview.BackColor = System.Drawing.Color.Black
        Me.rtxtPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtxtPreview.ForeColor = System.Drawing.Color.Lime
        Me.rtxtPreview.Location = New System.Drawing.Point(0, 0)
        Me.rtxtPreview.Name = "rtxtPreview"
        Me.rtxtPreview.Size = New System.Drawing.Size(442, 348)
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
        Me.tabpageGraphics.Size = New System.Drawing.Size(442, 348)
        '
        'lblImageInstructions
        '
        Me.lblImageInstructions.AllowDrop = True
        Me.lblImageInstructions.Anchor = System.Windows.Forms.AnchorStyles.None
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.lblImageInstructions.Appearance = Appearance1
        Me.lblImageInstructions.Location = New System.Drawing.Point(71, 121)
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
        Me.imgGraphics.Size = New System.Drawing.Size(433, 310)
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
        Me.fileGraphics.Location = New System.Drawing.Point(5, 322)
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
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(442, 348)
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
        Me.fileAudio.Location = New System.Drawing.Point(5, 322)
        Me.fileAudio.Name = "fileAudio"
        Me.fileAudio.OpenOrSave = ADRIFT.DirectoryBox.OpenOrSaveEnum.Open
        Me.fileAudio.Size = New System.Drawing.Size(434, 22)
        Me.fileAudio.TabIndex = 1
        '
        'pnlAudio
        '
        Me.pnlAudio.Anchor = System.Windows.Forms.AnchorStyles.None
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.pnlAudio.Appearance = Appearance2
        '
        'pnlAudio.ClientArea
        '
        Me.pnlAudio.ClientArea.Controls.Add(Me.chkLoop)
        Me.pnlAudio.ClientArea.Controls.Add(Me.pnlChannel)
        Me.pnlAudio.ClientArea.Controls.Add(Me.pnlButtons)
        Me.pnlAudio.Location = New System.Drawing.Point(5, 6)
        Me.pnlAudio.Name = "pnlAudio"
        Me.pnlAudio.Size = New System.Drawing.Size(434, 323)
        Me.pnlAudio.TabIndex = 8
        '
        'chkLoop
        '
        Appearance3.FontData.Name = "ariel"
        Appearance3.FontData.SizeInPoints = 10.0!
        Me.chkLoop.Appearance = Appearance3
        Me.chkLoop.Enabled = False
        Me.chkLoop.Location = New System.Drawing.Point(248, 241)
        Me.chkLoop.Name = "chkLoop"
        Me.chkLoop.Size = New System.Drawing.Size(61, 20)
        Me.chkLoop.TabIndex = 7
        Me.chkLoop.Text = "Loop"
        '
        'pnlChannel
        '
        Me.pnlChannel.Anchor = System.Windows.Forms.AnchorStyles.None
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Me.pnlChannel.Appearance = Appearance4
        '
        'pnlChannel.ClientArea
        '
        Me.pnlChannel.ClientArea.Controls.Add(Me.nudChannel)
        Me.pnlChannel.ClientArea.Controls.Add(Me.lblChannel)
        Me.pnlChannel.Location = New System.Drawing.Point(116, 238)
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
        Me.lblChannel.Location = New System.Drawing.Point(0, 4)
        Me.lblChannel.Name = "lblChannel"
        Me.lblChannel.Size = New System.Drawing.Size(66, 19)
        Me.lblChannel.TabIndex = 3
        Me.lblChannel.Text = "Channel:"
        '
        'pnlButtons
        '
        Me.pnlButtons.Anchor = System.Windows.Forms.AnchorStyles.None
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Me.pnlButtons.Appearance = Appearance5
        '
        'pnlButtons.ClientArea
        '
        Me.pnlButtons.ClientArea.Controls.Add(Me.chkStop)
        Me.pnlButtons.ClientArea.Controls.Add(Me.chkPause)
        Me.pnlButtons.ClientArea.Controls.Add(Me.chkPlay)
        Me.pnlButtons.Location = New System.Drawing.Point(116, 72)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(193, 154)
        Me.pnlButtons.TabIndex = 2
        '
        'chkStop
        '
        Me.chkStop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance6.Image = Global.ADRIFT.My.Resources.Resources.imgStop48
        Appearance6.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance6.TextHAlignAsString = "Center"
        Me.chkStop.Appearance = Appearance6
        Me.chkStop.BackColor = System.Drawing.Color.Transparent
        Me.chkStop.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkStop.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.chkStop.Location = New System.Drawing.Point(1, 103)
        Me.chkStop.Name = "chkStop"
        Me.chkStop.Size = New System.Drawing.Size(191, 50)
        Me.chkStop.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkStop.TabIndex = 30
        Me.chkStop.Text = "Stop Audio"
        Me.chkStop.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'chkPause
        '
        Me.chkPause.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.Image = Global.ADRIFT.My.Resources.Resources.imgPause48
        Appearance7.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance7.TextHAlignAsString = "Center"
        Me.chkPause.Appearance = Appearance7
        Me.chkPause.BackColor = System.Drawing.Color.Transparent
        Me.chkPause.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkPause.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.chkPause.Location = New System.Drawing.Point(1, 52)
        Me.chkPause.Name = "chkPause"
        Me.chkPause.Size = New System.Drawing.Size(191, 50)
        Me.chkPause.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkPause.TabIndex = 29
        Me.chkPause.Text = "Pause Audio"
        Me.chkPause.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'chkPlay
        '
        Me.chkPlay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance8.Image = Global.ADRIFT.My.Resources.Resources.imgPlay48
        Appearance8.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance8.TextHAlignAsString = "Center"
        Me.chkPlay.Appearance = Appearance8
        Me.chkPlay.BackColor = System.Drawing.Color.Transparent
        Me.chkPlay.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkPlay.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.chkPlay.Location = New System.Drawing.Point(1, 1)
        Me.chkPlay.Name = "chkPlay"
        Me.chkPlay.Size = New System.Drawing.Size(191, 50)
        Me.chkPlay.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkPlay.TabIndex = 28
        Me.chkPlay.Text = "Play Audio"
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
        Me.SplitContainer.Panel2.Controls.Add(Me._Panel2_Toolbars_Dock_Area_Bottom)
        Me.SplitContainer.Panel2.Controls.Add(Me._Panel2_Toolbars_Dock_Area_Top)
        Me.SplitContainer.Size = New System.Drawing.Size(496, 403)
        Me.SplitContainer.SplitterDistance = 25
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
        Me.Tabs.Location = New System.Drawing.Point(27, 25)
        Me.Tabs.MinTabWidth = 10
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tabs.Size = New System.Drawing.Size(469, 352)
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
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(442, 348)
        '
        '_Panel2_Toolbars_Dock_Area_Left
        '
        Me._Panel2_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._Panel2_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control
        Me._Panel2_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._Panel2_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Panel2_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 25)
        Me._Panel2_Toolbars_Dock_Area_Left.Name = "_Panel2_Toolbars_Dock_Area_Left"
        Me._Panel2_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(27, 352)
        Me._Panel2_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UTMText
        '
        'UTMText
        '
        Me.UTMText.DesignerFlags = 1
        Me.UTMText.DockWithinContainer = Me.SplitContainer.Panel2
        Me.UTMText.ShowFullMenusDelay = 500
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.FloatingSize = New System.Drawing.Size(100, 20)
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool6, ButtonTool7, ButtonTool8, ButtonTool9})
        UltraToolbar1.Text = "Format"
        Me.UTMText.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Appearance9.Image = Global.ADRIFT.My.Resources.Resources.imgSpelling
        ButtonTool2.SharedPropsInternal.AppearancesLarge.Appearance = Appearance9
        Appearance10.Image = Global.ADRIFT.My.Resources.Resources.imgSpelling
        ButtonTool2.SharedPropsInternal.AppearancesSmall.Appearance = Appearance10
        ButtonTool2.SharedPropsInternal.Caption = "Spelling..."
        ButtonTool2.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.F7
        PopupMenuTool1.SharedPropsInternal.Caption = "PopupMenuTool1"
        PopupMenuTool1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool3, ButtonTool4})
        Appearance11.Image = Global.ADRIFT.My.Resources.Resources.imgNew16
        ButtonTool5.SharedPropsInternal.AppearancesSmall.Appearance = Appearance11
        ButtonTool5.SharedPropsInternal.Caption = "Add Alternative Description"
        Appearance12.Image = Global.ADRIFT.My.Resources.Resources.imgBold
        ButtonTool10.SharedPropsInternal.AppearancesSmall.Appearance = Appearance12
        ButtonTool10.SharedPropsInternal.Caption = "Bold"
        Appearance13.Image = Global.ADRIFT.My.Resources.Resources.imgItalic
        ButtonTool11.SharedPropsInternal.AppearancesSmall.Appearance = Appearance13
        ButtonTool11.SharedPropsInternal.Caption = "Italics"
        ButtonTool12.SharedPropsInternal.Caption = "Underline"
        ButtonTool13.SharedPropsInternal.Caption = "Secondary Colour"
        Me.UTMText.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool2, PopupMenuTool1, ButtonTool5, ButtonTool10, ButtonTool11, ButtonTool12, ButtonTool13})
        '
        '_Panel2_Toolbars_Dock_Area_Right
        '
        Me._Panel2_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._Panel2_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control
        Me._Panel2_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._Panel2_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Panel2_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(496, 25)
        Me._Panel2_Toolbars_Dock_Area_Right.Name = "_Panel2_Toolbars_Dock_Area_Right"
        Me._Panel2_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 352)
        Me._Panel2_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UTMText
        '
        '_Panel2_Toolbars_Dock_Area_Bottom
        '
        Me._Panel2_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._Panel2_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._Panel2_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._Panel2_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Panel2_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 377)
        Me._Panel2_Toolbars_Dock_Area_Bottom.Name = "_Panel2_Toolbars_Dock_Area_Bottom"
        Me._Panel2_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(496, 0)
        Me._Panel2_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UTMText
        '
        '_Panel2_Toolbars_Dock_Area_Top
        '
        Me._Panel2_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._Panel2_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control
        Me._Panel2_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._Panel2_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Panel2_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._Panel2_Toolbars_Dock_Area_Top.Name = "_Panel2_Toolbars_Dock_Area_Top"
        Me._Panel2_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(496, 25)
        Me._Panel2_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UTMText
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
        Appearance14.Image = Global.ADRIFT.My.Resources.Resources.imgNew16
        UltraTab5.HotTrackAppearance = Appearance14
        UltraTab5.Key = "tabNew"
        UltraTab5.Text = " "
        Me.tabsDescriptions.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab4, UltraTab5})
        '
        'cmsTabs
        '
        Me.cmsTabs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miRenameTab, Me.mnuDeleteTab})
        Me.cmsTabs.Name = "cmsTabs"
        Me.cmsTabs.Size = New System.Drawing.Size(139, 48)
        '
        'miRenameTab
        '
        Me.miRenameTab.Name = "miRenameTab"
        Me.miRenameTab.Size = New System.Drawing.Size(138, 22)
        Me.miRenameTab.Text = "Rename Tab"
        '
        'mnuDeleteTab
        '
        Me.mnuDeleteTab.Image = Global.ADRIFT.My.Resources.Resources.imgDelete
        Me.mnuDeleteTab.Name = "mnuDeleteTab"
        Me.mnuDeleteTab.Size = New System.Drawing.Size(138, 22)
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
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
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



End Class
