Public Class frmOptions
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoadForm()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnApply As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tabsOptions As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents chkShowExits As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents txtIFID As System.Windows.Forms.TextBox
    Friend WithEvents lnkBabel As System.Windows.Forms.LinkLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents fileGraphics As ADRIFT.DirectoryBox
    Friend WithEvents btnSetFont As System.Windows.Forms.Button
    Private WithEvents txtFont As System.Windows.Forms.TextBox
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents fd As System.Windows.Forms.FontDialog
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbForgiveness As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents txtHeadline As System.Windows.Forms.TextBox
    Friend WithEvents lblAuthor As Infragistics.Win.Misc.UltraLabel
    Private WithEvents txtAuthor As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As Infragistics.Win.Misc.UltraLabel
    Private WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents cmbGenre As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbPerspective As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents nudVersion As System.Windows.Forms.NumericUpDown
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents optHighestPriorityPassingTask As System.Windows.Forms.RadioButton
    Friend WithEvents optHighestPriorityTask As System.Windows.Forms.RadioButton
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents chkEnableMenu As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Private WithEvents txtKeyPrefix As System.Windows.Forms.TextBox
    Friend WithEvents lblKeyPrefix As Infragistics.Win.Misc.UltraLabel
    Private WithEvents txtStatusbar As OOTextbox
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents imgGraphics As ADRIFT.clsImage
    Friend WithEvents chkDebugger As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents txtWait As ADRIFT.NumericTextbox
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblLinkColour As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents pnlLinkColour As System.Windows.Forms.Panel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblOutputColour As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents pnlBackgroundColour As System.Windows.Forms.Panel
    Friend WithEvents lblInputColour As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents pnlOutputColour As System.Windows.Forms.Panel
    Friend WithEvents pnlInputColour As System.Windows.Forms.Panel
    Friend WithEvents tabGeneral As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem18 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem19 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem20 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem13 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem14 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem15 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem16 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem17 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem35 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem36 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem37 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem38 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem39 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.tabGeneral = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lblLinkColour = New Infragistics.Win.Misc.UltraLabel()
        Me.pnlLinkColour = New System.Windows.Forms.Panel()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblOutputColour = New Infragistics.Win.Misc.UltraLabel()
        Me.pnlBackgroundColour = New System.Windows.Forms.Panel()
        Me.lblInputColour = New Infragistics.Win.Misc.UltraLabel()
        Me.pnlOutputColour = New System.Windows.Forms.Panel()
        Me.pnlInputColour = New System.Windows.Forms.Panel()
        Me.txtWait = New ADRIFT.NumericTextbox()
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel()
        Me.chkDebugger = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.txtStatusbar = New ADRIFT.OOTextbox()
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel()
        Me.chkEnableMenu = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.cmbPerspective = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnSetFont = New System.Windows.Forms.Button()
        Me.txtFont = New System.Windows.Forms.TextBox()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.chkShowExits = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.imgGraphics = New ADRIFT.clsImage()
        Me.nudVersion = New System.Windows.Forms.NumericUpDown()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmbGenre = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmbForgiveness = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtHeadline = New System.Windows.Forms.TextBox()
        Me.lblAuthor = New Infragistics.Win.Misc.UltraLabel()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.lblTitle = New Infragistics.Win.Misc.UltraLabel()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.fileGraphics = New ADRIFT.DirectoryBox()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.lnkBabel = New System.Windows.Forms.LinkLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtIFID = New System.Windows.Forms.TextBox()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.txtKeyPrefix = New System.Windows.Forms.TextBox()
        Me.lblKeyPrefix = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.optHighestPriorityPassingTask = New System.Windows.Forms.RadioButton()
        Me.optHighestPriorityTask = New System.Windows.Forms.RadioButton()
        Me.btnApply = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.tabsOptions = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.fd = New System.Windows.Forms.FontDialog()
        Me.tabGeneral.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.chkDebugger, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEnableMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPerspective, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowExits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.nudVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbGenre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbForgiveness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabsOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.UltraGroupBox2)
        Me.tabGeneral.Controls.Add(Me.txtWait)
        Me.tabGeneral.Controls.Add(Me.UltraLabel11)
        Me.tabGeneral.Controls.Add(Me.chkDebugger)
        Me.tabGeneral.Controls.Add(Me.txtStatusbar)
        Me.tabGeneral.Controls.Add(Me.UltraLabel10)
        Me.tabGeneral.Controls.Add(Me.chkEnableMenu)
        Me.tabGeneral.Controls.Add(Me.cmbPerspective)
        Me.tabGeneral.Controls.Add(Me.UltraLabel9)
        Me.tabGeneral.Controls.Add(Me.btnSetFont)
        Me.tabGeneral.Controls.Add(Me.txtFont)
        Me.tabGeneral.Controls.Add(Me.UltraLabel4)
        Me.tabGeneral.Controls.Add(Me.chkShowExits)
        Me.tabGeneral.Location = New System.Drawing.Point(1, 23)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Size = New System.Drawing.Size(524, 562)
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.lblLinkColour)
        Me.UltraGroupBox2.Controls.Add(Me.pnlLinkColour)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox2.Controls.Add(Me.lblOutputColour)
        Me.UltraGroupBox2.Controls.Add(Me.pnlBackgroundColour)
        Me.UltraGroupBox2.Controls.Add(Me.lblInputColour)
        Me.UltraGroupBox2.Controls.Add(Me.pnlOutputColour)
        Me.UltraGroupBox2.Controls.Add(Me.pnlInputColour)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(11, 66)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(308, 103)
        Me.UltraGroupBox2.TabIndex = 28
        Me.UltraGroupBox2.Text = "Default Colours"
        '
        'lblLinkColour
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Right"
        Me.lblLinkColour.Appearance = Appearance5
        Me.lblLinkColour.Location = New System.Drawing.Point(18, 68)
        Me.lblLinkColour.Name = "lblLinkColour"
        Me.lblLinkColour.Size = New System.Drawing.Size(100, 19)
        Me.lblLinkColour.TabIndex = 26
        Me.lblLinkColour.Text = "Link colour"
        '
        'pnlLinkColour
        '
        Me.pnlLinkColour.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.pnlLinkColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLinkColour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlLinkColour.Location = New System.Drawing.Point(124, 62)
        Me.pnlLinkColour.Name = "pnlLinkColour"
        Me.pnlLinkColour.Size = New System.Drawing.Size(25, 25)
        Me.pnlLinkColour.TabIndex = 23
        '
        'UltraLabel12
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Me.UltraLabel12.Appearance = Appearance6
        Me.UltraLabel12.Location = New System.Drawing.Point(18, 37)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(100, 19)
        Me.UltraLabel12.TabIndex = 25
        Me.UltraLabel12.Text = "Background colour"
        '
        'lblOutputColour
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Me.lblOutputColour.Appearance = Appearance7
        Me.lblOutputColour.Location = New System.Drawing.Point(186, 68)
        Me.lblOutputColour.Name = "lblOutputColour"
        Me.lblOutputColour.Size = New System.Drawing.Size(100, 19)
        Me.lblOutputColour.TabIndex = 23
        Me.lblOutputColour.Text = "Output colour"
        '
        'pnlBackgroundColour
        '
        Me.pnlBackgroundColour.BackColor = System.Drawing.Color.Black
        Me.pnlBackgroundColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBackgroundColour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBackgroundColour.Location = New System.Drawing.Point(124, 31)
        Me.pnlBackgroundColour.Name = "pnlBackgroundColour"
        Me.pnlBackgroundColour.Size = New System.Drawing.Size(25, 25)
        Me.pnlBackgroundColour.TabIndex = 24
        '
        'lblInputColour
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Me.lblInputColour.Appearance = Appearance8
        Me.lblInputColour.Location = New System.Drawing.Point(186, 37)
        Me.lblInputColour.Name = "lblInputColour"
        Me.lblInputColour.Size = New System.Drawing.Size(100, 19)
        Me.lblInputColour.TabIndex = 21
        Me.lblInputColour.Text = "Input colour"
        '
        'pnlOutputColour
        '
        Me.pnlOutputColour.BackColor = System.Drawing.Color.SeaGreen
        Me.pnlOutputColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOutputColour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlOutputColour.Location = New System.Drawing.Point(155, 62)
        Me.pnlOutputColour.Name = "pnlOutputColour"
        Me.pnlOutputColour.Size = New System.Drawing.Size(25, 25)
        Me.pnlOutputColour.TabIndex = 22
        '
        'pnlInputColour
        '
        Me.pnlInputColour.BackColor = System.Drawing.Color.Red
        Me.pnlInputColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInputColour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlInputColour.Location = New System.Drawing.Point(155, 31)
        Me.pnlInputColour.Name = "pnlInputColour"
        Me.pnlInputColour.Size = New System.Drawing.Size(25, 25)
        Me.pnlInputColour.TabIndex = 20
        '
        'txtWait
        '
        Me.txtWait.Location = New System.Drawing.Point(294, 269)
        Me.txtWait.MaxDecimalPlaces = 0
        Me.txtWait.MinDecimalPlaces = 0
        Me.txtWait.Name = "txtWait"
        Me.txtWait.Size = New System.Drawing.Size(59, 22)
        Me.txtWait.TabIndex = 16
        Me.txtWait.Value = 3.0R
        '
        'UltraLabel11
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel11.Appearance = Appearance11
        Me.UltraLabel11.Location = New System.Drawing.Point(16, 274)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(313, 23)
        Me.UltraLabel11.TabIndex = 15
        Me.UltraLabel11.Text = "How many turns should pass when the player waits:"
        '
        'chkDebugger
        '
        Me.chkDebugger.BackColor = System.Drawing.Color.Transparent
        Me.chkDebugger.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkDebugger.Location = New System.Drawing.Point(133, 362)
        Me.chkDebugger.Name = "chkDebugger"
        Me.chkDebugger.Size = New System.Drawing.Size(288, 20)
        Me.chkDebugger.TabIndex = 14
        Me.chkDebugger.Text = "Enable debugger"
        '
        'txtStatusbar
        '
        Me.txtStatusbar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatusbar.AutoWordSelection = False
        Me.txtStatusbar.DetectUrls = False
        Me.txtStatusbar.EnableAutoDragDrop = False
        Me.txtStatusbar.Location = New System.Drawing.Point(133, 231)
        Me.txtStatusbar.Multiline = False
        Me.txtStatusbar.Name = "txtStatusbar"
        Me.txtStatusbar.Padding = New System.Drawing.Size(0, 2)
        Me.txtStatusbar.ScrollBarDisplayStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarDisplayStyle.Never
        Me.txtStatusbar.SelectedText = Nothing
        Me.txtStatusbar.SelectionLength = 0
        Me.txtStatusbar.SelectionStart = -1
        Me.txtStatusbar.Size = New System.Drawing.Size(373, 20)
        Me.txtStatusbar.TabIndex = 13
        Me.txtStatusbar.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI
        Me.txtStatusbar.Value = Nothing
        Me.txtStatusbar.WrapText = False
        '
        'UltraLabel10
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel10.Appearance = Appearance14
        Me.UltraLabel10.Location = New System.Drawing.Point(16, 234)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel10.TabIndex = 12
        Me.UltraLabel10.Text = "Custom Statusbar:"
        '
        'chkEnableMenu
        '
        Me.chkEnableMenu.BackColor = System.Drawing.Color.Transparent
        Me.chkEnableMenu.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkEnableMenu.Location = New System.Drawing.Point(133, 336)
        Me.chkEnableMenu.Name = "chkEnableMenu"
        Me.chkEnableMenu.Size = New System.Drawing.Size(288, 20)
        Me.chkEnableMenu.TabIndex = 10
        Me.chkEnableMenu.Text = "Enable context sensitive menu in games"
        '
        'cmbPerspective
        '
        Me.cmbPerspective.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem18.DataValue = 1
        ValueListItem18.DisplayText = "First Person (e.g. I am...)"
        ValueListItem19.DataValue = 2
        ValueListItem19.DisplayText = "Second Person (e.g. You are...)"
        ValueListItem20.DataValue = 3
        ValueListItem20.DisplayText = "Third Person (e.g. Player is...)"
        Me.cmbPerspective.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem18, ValueListItem19, ValueListItem20})
        Me.cmbPerspective.Location = New System.Drawing.Point(133, 189)
        Me.cmbPerspective.Name = "cmbPerspective"
        Me.cmbPerspective.Size = New System.Drawing.Size(196, 21)
        Me.cmbPerspective.TabIndex = 9
        Me.cmbPerspective.Text = "Second Person (e.g. You are...)"
        '
        'UltraLabel9
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel9.Appearance = Appearance3
        Me.UltraLabel9.Location = New System.Drawing.Point(16, 193)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(119, 23)
        Me.UltraLabel9.TabIndex = 8
        Me.UltraLabel9.Text = "Player Perspective:"
        '
        'btnSetFont
        '
        Me.btnSetFont.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetFont.Location = New System.Drawing.Point(431, 28)
        Me.btnSetFont.Name = "btnSetFont"
        Me.btnSetFont.Size = New System.Drawing.Size(75, 23)
        Me.btnSetFont.TabIndex = 7
        Me.btnSetFont.Text = "Set Font"
        Me.btnSetFont.UseVisualStyleBackColor = True
        '
        'txtFont
        '
        Me.txtFont.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFont.Location = New System.Drawing.Point(133, 30)
        Me.txtFont.Name = "txtFont"
        Me.txtFont.Size = New System.Drawing.Size(298, 20)
        Me.txtFont.TabIndex = 6
        '
        'UltraLabel4
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel4.Appearance = Appearance13
        Me.UltraLabel4.Location = New System.Drawing.Point(16, 33)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel4.TabIndex = 5
        Me.UltraLabel4.Text = "Default font:"
        '
        'chkShowExits
        '
        Me.chkShowExits.BackColor = System.Drawing.Color.Transparent
        Me.chkShowExits.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkShowExits.Location = New System.Drawing.Point(133, 310)
        Me.chkShowExits.Name = "chkShowExits"
        Me.chkShowExits.Size = New System.Drawing.Size(288, 20)
        Me.chkShowExits.TabIndex = 4
        Me.chkShowExits.Text = "Show exits from locations along with descriptions"
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.imgGraphics)
        Me.UltraTabPageControl1.Controls.Add(Me.nudVersion)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbGenre)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel8)
        Me.UltraTabPageControl1.Controls.Add(Me.txtDescription)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel7)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbForgiveness)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel6)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel5)
        Me.UltraTabPageControl1.Controls.Add(Me.txtHeadline)
        Me.UltraTabPageControl1.Controls.Add(Me.lblAuthor)
        Me.UltraTabPageControl1.Controls.Add(Me.txtAuthor)
        Me.UltraTabPageControl1.Controls.Add(Me.lblTitle)
        Me.UltraTabPageControl1.Controls.Add(Me.txtTitle)
        Me.UltraTabPageControl1.Controls.Add(Me.fileGraphics)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel3)
        Me.UltraTabPageControl1.Controls.Add(Me.lnkBabel)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl1.Controls.Add(Me.txtIFID)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(524, 562)
        '
        'imgGraphics
        '
        Me.imgGraphics.BackColor = System.Drawing.Color.Transparent
        Me.imgGraphics.BackColour = System.Drawing.Color.Transparent
        Me.imgGraphics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgGraphics.Image = Nothing
        Me.imgGraphics.Location = New System.Drawing.Point(127, 314)
        Me.imgGraphics.Name = "imgGraphics"
        Me.imgGraphics.Size = New System.Drawing.Size(240, 240)
        Me.imgGraphics.SizeMode = ADRIFT.clsImage.SizeModeEnum.ActualSizeCentred
        Me.imgGraphics.TabIndex = 29
        '
        'nudVersion
        '
        Me.nudVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudVersion.Location = New System.Drawing.Point(430, 53)
        Me.nudVersion.Name = "nudVersion"
        Me.nudVersion.Size = New System.Drawing.Size(49, 20)
        Me.nudVersion.TabIndex = 28
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel2.Appearance = Appearance2
        Me.UltraLabel2.Location = New System.Drawing.Point(379, 56)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel2.TabIndex = 27
        Me.UltraLabel2.Text = "Version:"
        '
        'cmbGenre
        '
        ValueListItem1.DataValue = "Children's Fiction"
        ValueListItem2.DataValue = "Collegiate Fiction"
        ValueListItem3.DataValue = "Comedy"
        ValueListItem4.DataValue = "Erotica"
        ValueListItem5.DataValue = "Fairy Tale"
        ValueListItem6.DataValue = "Fantasy"
        ValueListItem7.DataValue = "Fiction"
        ValueListItem8.DataValue = "Historical"
        ValueListItem9.DataValue = "Horror"
        ValueListItem10.DataValue = "Mystery"
        ValueListItem11.DataValue = "Non-Fiction"
        ValueListItem12.DataValue = "Other"
        ValueListItem13.DataValue = "Religious Fiction"
        ValueListItem14.DataValue = "Romance"
        ValueListItem15.DataValue = "Science Fiction"
        ValueListItem16.DataValue = "Surreal"
        ValueListItem17.DataValue = "Western"
        Me.cmbGenre.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3, ValueListItem4, ValueListItem5, ValueListItem6, ValueListItem7, ValueListItem8, ValueListItem9, ValueListItem10, ValueListItem11, ValueListItem12, ValueListItem13, ValueListItem14, ValueListItem15, ValueListItem16, ValueListItem17})
        Me.cmbGenre.Location = New System.Drawing.Point(359, 157)
        Me.cmbGenre.Name = "cmbGenre"
        Me.cmbGenre.Size = New System.Drawing.Size(120, 21)
        Me.cmbGenre.TabIndex = 26
        Me.cmbGenre.Text = "Fiction"
        '
        'UltraLabel8
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel8.Appearance = Appearance4
        Me.UltraLabel8.Location = New System.Drawing.Point(312, 161)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel8.TabIndex = 25
        Me.UltraLabel8.Text = "Genre:"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(127, 184)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(352, 96)
        Me.txtDescription.TabIndex = 24
        '
        'UltraLabel7
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel7.Appearance = Appearance16
        Me.UltraLabel7.Location = New System.Drawing.Point(21, 190)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel7.TabIndex = 23
        Me.UltraLabel7.Text = "Description:"
        '
        'cmbForgiveness
        '
        Me.cmbForgiveness.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem35.DataValue = "Merciful"
        ValueListItem36.DataValue = "Polite"
        ValueListItem37.DataValue = "Tough"
        ValueListItem38.DataValue = "Nasty"
        ValueListItem39.DataValue = "Cruel"
        Me.cmbForgiveness.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem35, ValueListItem36, ValueListItem37, ValueListItem38, ValueListItem39})
        Me.cmbForgiveness.Location = New System.Drawing.Point(127, 157)
        Me.cmbForgiveness.Name = "cmbForgiveness"
        Me.cmbForgiveness.Size = New System.Drawing.Size(120, 21)
        Me.cmbForgiveness.TabIndex = 22
        Me.cmbForgiveness.Text = "Merciful"
        '
        'UltraLabel6
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel6.Appearance = Appearance10
        Me.UltraLabel6.Location = New System.Drawing.Point(21, 161)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel6.TabIndex = 21
        Me.UltraLabel6.Text = "Forgiveness:"
        '
        'UltraLabel5
        '
        Appearance17.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel5.Appearance = Appearance17
        Me.UltraLabel5.Location = New System.Drawing.Point(21, 134)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel5.TabIndex = 20
        Me.UltraLabel5.Text = "Headline:"
        '
        'txtHeadline
        '
        Me.txtHeadline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHeadline.Location = New System.Drawing.Point(127, 131)
        Me.txtHeadline.Name = "txtHeadline"
        Me.txtHeadline.Size = New System.Drawing.Size(352, 20)
        Me.txtHeadline.TabIndex = 19
        '
        'lblAuthor
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Me.lblAuthor.Appearance = Appearance9
        Me.lblAuthor.Location = New System.Drawing.Point(21, 82)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(100, 23)
        Me.lblAuthor.TabIndex = 18
        Me.lblAuthor.Text = "Author:"
        '
        'txtAuthor
        '
        Me.txtAuthor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAuthor.Location = New System.Drawing.Point(127, 79)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(352, 20)
        Me.txtAuthor.TabIndex = 17
        '
        'lblTitle
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Appearance = Appearance12
        Me.lblTitle.Location = New System.Drawing.Point(21, 56)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(100, 23)
        Me.lblTitle.TabIndex = 16
        Me.lblTitle.Text = "Title:"
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitle.Location = New System.Drawing.Point(127, 53)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(229, 20)
        Me.txtTitle.TabIndex = 15
        '
        'fileGraphics
        '
        Me.fileGraphics.AllowDrop = True
        Me.fileGraphics.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fileGraphics.BackColor = System.Drawing.Color.Transparent
        Me.fileGraphics.BoxType = ADRIFT.DirectoryBox.BoxTypeEnum.File
        Me.fileGraphics.Directory = "*** Incorrect BoxType ***"
        Me.fileGraphics.FileFilter = "Image Files|*.jpg;*.png|All Files (*.*)|*.*"
        Me.fileGraphics.Filename = ""
        Me.fileGraphics.Location = New System.Drawing.Point(127, 286)
        Me.fileGraphics.Name = "fileGraphics"
        Me.fileGraphics.OpenOrSave = ADRIFT.DirectoryBox.OpenOrSaveEnum.Open
        Me.fileGraphics.Size = New System.Drawing.Size(384, 22)
        Me.fileGraphics.TabIndex = 13
        '
        'UltraLabel3
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel3.Appearance = Appearance1
        Me.UltraLabel3.Location = New System.Drawing.Point(21, 290)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel3.TabIndex = 12
        Me.UltraLabel3.Text = "Cover image:"
        '
        'lnkBabel
        '
        Me.lnkBabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkBabel.BackColor = System.Drawing.Color.Transparent
        Me.lnkBabel.LinkArea = New System.Windows.Forms.LinkArea(86, 26)
        Me.lnkBabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkBabel.Location = New System.Drawing.Point(11, 12)
        Me.lnkBabel.Name = "lnkBabel"
        Me.lnkBabel.Size = New System.Drawing.Size(504, 29)
        Me.lnkBabel.TabIndex = 11
        Me.lnkBabel.TabStop = True
        Me.lnkBabel.Text = "This page allows you to populate data according to The Treaty of Babel.  Please v" & _
    "isit http://babel.ifarchive.org  for more information."
        Me.lnkBabel.UseCompatibleTextRendering = True
        '
        'UltraLabel1
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance15
        Me.UltraLabel1.Location = New System.Drawing.Point(21, 108)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel1.TabIndex = 8
        Me.UltraLabel1.Text = "IFID:"
        '
        'txtIFID
        '
        Me.txtIFID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIFID.Enabled = False
        Me.txtIFID.Location = New System.Drawing.Point(127, 105)
        Me.txtIFID.Name = "txtIFID"
        Me.txtIFID.Size = New System.Drawing.Size(352, 20)
        Me.txtIFID.TabIndex = 7
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.txtKeyPrefix)
        Me.UltraTabPageControl2.Controls.Add(Me.lblKeyPrefix)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(524, 562)
        '
        'txtKeyPrefix
        '
        Me.txtKeyPrefix.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKeyPrefix.Location = New System.Drawing.Point(148, 171)
        Me.txtKeyPrefix.Name = "txtKeyPrefix"
        Me.txtKeyPrefix.Size = New System.Drawing.Size(203, 20)
        Me.txtKeyPrefix.TabIndex = 17
        '
        'lblKeyPrefix
        '
        Appearance18.BackColor = System.Drawing.Color.Transparent
        Me.lblKeyPrefix.Appearance = Appearance18
        Me.lblKeyPrefix.Location = New System.Drawing.Point(42, 174)
        Me.lblKeyPrefix.Name = "lblKeyPrefix"
        Me.lblKeyPrefix.Size = New System.Drawing.Size(100, 23)
        Me.lblKeyPrefix.TabIndex = 18
        Me.lblKeyPrefix.Text = "Key Prefix:"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox1.Controls.Add(Me.optHighestPriorityPassingTask)
        Me.UltraGroupBox1.Controls.Add(Me.optHighestPriorityTask)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(16, 18)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(495, 135)
        Me.UltraGroupBox1.TabIndex = 11
        Me.UltraGroupBox1.Text = "Task Execution logic"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'optHighestPriorityPassingTask
        '
        Me.optHighestPriorityPassingTask.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optHighestPriorityPassingTask.BackColor = System.Drawing.Color.Transparent
        Me.optHighestPriorityPassingTask.Location = New System.Drawing.Point(26, 59)
        Me.optHighestPriorityPassingTask.Name = "optHighestPriorityPassingTask"
        Me.optHighestPriorityPassingTask.Size = New System.Drawing.Size(458, 62)
        Me.optHighestPriorityPassingTask.TabIndex = 1
        Me.optHighestPriorityPassingTask.TabStop = True
        Me.optHighestPriorityPassingTask.Text = "Execute the highest priority task matching command input that passes restrictions" & _
    ".  If none are found, execute the highest priority task matching command input t" & _
    "hat fails restrictions."
        Me.optHighestPriorityPassingTask.UseVisualStyleBackColor = False
        '
        'optHighestPriorityTask
        '
        Me.optHighestPriorityTask.AutoSize = True
        Me.optHighestPriorityTask.BackColor = System.Drawing.Color.Transparent
        Me.optHighestPriorityTask.Location = New System.Drawing.Point(26, 36)
        Me.optHighestPriorityTask.Name = "optHighestPriorityTask"
        Me.optHighestPriorityTask.Size = New System.Drawing.Size(417, 17)
        Me.optHighestPriorityTask.TabIndex = 0
        Me.optHighestPriorityTask.TabStop = True
        Me.optHighestPriorityTask.Text = "Execute the highest priority task matching command input, whether it passes or no" & _
    "t."
        Me.optHighestPriorityTask.UseVisualStyleBackColor = False
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(424, 594)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(88, 32)
        Me.btnApply.TabIndex = 18
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(328, 594)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(232, 594)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "OK"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 588)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(528, 48)
        Me.UltraStatusBar1.TabIndex = 15
        '
        'tabsOptions
        '
        Me.tabsOptions.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabsOptions.Controls.Add(Me.tabGeneral)
        Me.tabsOptions.Controls.Add(Me.UltraTabPageControl1)
        Me.tabsOptions.Controls.Add(Me.UltraTabPageControl2)
        Me.tabsOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsOptions.Location = New System.Drawing.Point(0, 0)
        Me.tabsOptions.Name = "tabsOptions"
        Me.tabsOptions.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabsOptions.Size = New System.Drawing.Size(528, 588)
        Me.tabsOptions.TabIndex = 19
        UltraTab1.Key = "General"
        UltraTab1.TabPage = Me.tabGeneral
        UltraTab1.Text = "General"
        UltraTab2.Key = "Bibliography"
        UltraTab2.TabPage = Me.UltraTabPageControl1
        UltraTab2.Text = "Bibliography"
        UltraTab3.Key = "Advanced"
        UltraTab3.TabPage = Me.UltraTabPageControl2
        UltraTab3.Text = "Advanced"
        Me.tabsOptions.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(524, 562)
        '
        'frmOptions
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(528, 636)
        Me.Controls.Add(Me.tabsOptions)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.MinimumSize = New System.Drawing.Size(544, 672)
        Me.Name = "frmOptions"
        Me.ShowInTaskbar = False
        Me.Text = "Options"
        Me.tabGeneral.ResumeLayout(False)
        Me.tabGeneral.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.chkDebugger, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEnableMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPerspective, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowExits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.nudVersion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbGenre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbForgiveness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabsOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private bChanged As Boolean


    Public Property Changed() As Boolean
        Get
            Return bChanged
        End Get
        Set(ByVal Value As Boolean)
            bChanged = Value
            If bChanged Then
                btnApply.Enabled = True
            Else
                btnApply.Enabled = False
            End If
        End Set
    End Property


    Private Sub LoadForm()

        If Adventure.Player IsNot Nothing Then SetCombo(cmbPerspective, CInt(Adventure.Player.Perspective))
        txtTitle.Text = Adventure.Title
        txtAuthor.Text = Adventure.Author
        txtFont.Text = Adventure.DefaultFontName & ", " & Adventure.DefaultFontSize
        txtStatusbar.Text = Adventure.sUserStatus
        pnlBackgroundColour.BackColor = Adventure.DeveloperDefaultBackgroundColour
        pnlInputColour.BackColor = Adventure.DeveloperDefaultInputColour
        pnlOutputColour.BackColor = Adventure.DeveloperDefaultOutputColour
        pnlLinkColour.BackColor = Adventure.DeveloperDefaultLinkColour

        With Adventure.BabelTreatyInfo.Stories(0)
            txtIFID.Text = .Identification.IFID
            If .Cover IsNot Nothing Then
                imgGraphics.Image = .Cover.imgCoverArt
                fileGraphics.Filename = Adventure.CoverFilename ' .Cover.Filename
            End If
            If .Bibliographic IsNot Nothing Then
                txtTitle.Text = .Bibliographic.Title
                txtAuthor.Text = .Bibliographic.Author
                txtHeadline.Text = .Bibliographic.Headline
                SetCombo(cmbGenre, .Bibliographic.Genre)
                If cmbGenre.Text <> .Bibliographic.Genre Then cmbGenre.Text = .Bibliographic.Genre
                txtDescription.Text = SafeString(.Bibliographic.Description).Replace("<br>", vbCrLf)
                SetCombo(cmbForgiveness, .Bibliographic.Forgiveness.ToString)
            End If
            If .Releases IsNot Nothing AndAlso .Releases.Attached IsNot Nothing AndAlso .Releases.Attached.Release IsNot Nothing Then
                nudVersion.Value = .Releases.Attached.Release.Version
            End If
        End With
        If Adventure.TaskExecution = clsAdventure.TaskExecutionEnum.HighestPriorityTask Then
            optHighestPriorityTask.Checked = True
        Else
            optHighestPriorityPassingTask.Checked = True
        End If

        chkShowExits.Checked = Adventure.ShowExits
        chkEnableMenu.Checked = Adventure.EnableMenu
        chkDebugger.Checked = Adventure.EnableDebugger

        txtWait.Value = Adventure.WaitTurns

        tabsOptions.Tabs("Advanced").Visible = Not fGenerator.SimpleMode
        If Adventure.KeyPrefix <> "" Then
            txtKeyPrefix.Text = Adventure.KeyPrefix
        Else
            txtKeyPrefix.Text = fGenerator.KeyPrefix
        End If

        Changed = False
        Me.Show()

    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ApplyOptions()
        CloseOptions(Me)
    End Sub


    Private Sub ApplyOptions()

        Adventure.Title = txtTitle.Text
        Adventure.Author = txtAuthor.Text
        Adventure.ShowExits = chkShowExits.Checked
        Adventure.EnableMenu = chkEnableMenu.Checked
        Adventure.EnableDebugger = chkDebugger.Checked
        Adventure.WaitTurns = CInt(txtWait.Value)

        If Adventure.Player IsNot Nothing Then Adventure.Player.Perspective = CType(cmbPerspective.SelectedItem.DataValue, PerspectiveEnum)
        Adventure.sUserStatus = txtStatusbar.Text
        If txtFont.Text.Contains(",") Then
            Adventure.DefaultFontName = txtFont.Text.Split(","c)(0)
            Adventure.DefaultFontSize = SafeInt(txtFont.Text.Split(","c)(1))
        End If
        Adventure.DeveloperDefaultBackgroundColour = pnlBackgroundColour.BackColor
        Adventure.DeveloperDefaultInputColour = pnlInputColour.BackColor
        Adventure.DeveloperDefaultOutputColour = pnlOutputColour.BackColor
        Adventure.DeveloperDefaultLinkColour = pnlLinkColour.BackColor

        With Adventure.BabelTreatyInfo.Stories(0)
            Adventure.CoverFilename = fileGraphics.Filename
            '.Cover = New clsBabelTreatyInfo.clsStory.clsCover
            'With .Cover

            '    .imgCoverArt = imgGraphics.Image
            'End With
            With .Bibliographic
                .Title = txtTitle.Text
                .Author = txtAuthor.Text
                .Headline = txtHeadline.Text
                .Genre = cmbGenre.Text 'SelectedItem.DataValue.ToString
                .Description = txtDescription.Text.Replace(vbCrLf, "<br>")
                .Forgiveness = CType([Enum].Parse(GetType(clsBabelTreatyInfo.clsStory.clsBibliographic.ForgivenessEnum), cmbForgiveness.SelectedItem.DataValue.ToString), clsBabelTreatyInfo.clsStory.clsBibliographic.ForgivenessEnum)
            End With
            With .Releases.Attached.Release
                .Version = CInt(nudVersion.Value)
            End With
        End With
        If optHighestPriorityTask.Checked Then
            Adventure.TaskExecution = clsAdventure.TaskExecutionEnum.HighestPriorityTask
        Else
            Adventure.TaskExecution = clsAdventure.TaskExecutionEnum.HighestPriorityPassingTask
        End If

        tabsOptions.Tabs("Advanced").Visible = Not fGenerator.SimpleMode
        fGenerator.KeyPrefix = txtKeyPrefix.Text
        Adventure.KeyPrefix = txtKeyPrefix.Text

        For Each f As Form In colAllForms
            SetWindowStyle(f, fGenerator.UTMMain, fGenerator.UDMGenerator)
        Next

        Adventure.Changed = True

    End Sub


    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ApplyOptions()
        Changed = False
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then ApplyOptions()
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        CloseOptions(Me)
    End Sub


    Private Sub frmOptions_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        fGenerator.fOptions = Nothing
    End Sub



    Private Sub frmOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = Icon.FromHandle(My.Resources.imgOptions16.GetHicon)
        GetFormPosition(Me)
        imgGraphics.AllowDrop = True
        fileGraphics.AllowDrop = True
    End Sub



    Private Sub lnkBabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkBabel.LinkClicked
        System.Diagnostics.Process.Start("http://babel.ifarchive.org/")
    End Sub

    Private Sub fileGraphics_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles fileGraphics.DragDrop
        Dim sFilename As String = String.Empty
        If GetFilename(sFilename, e) Then
            fileGraphics.Filename = sFilename
        End If
    End Sub

    Private Sub fileGraphics_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles fileGraphics.DragEnter
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
                filename = CStr((e.Data).GetData("System.String")) ' FileName into Array...?

                Dim ext As String = IO.Path.GetExtension(filename).ToLower
                Select Case ext
                    Case ".jpg", ".png"
                        Return True
                    Case Else
                        Return False
                End Select
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function


    Private Sub fileGraphics_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fileGraphics.TextChanged
        Try
            If fileGraphics.Filename <> "" Then
                If IO.File.Exists(fileGraphics.Filename) OrElse fileGraphics.Filename.ToLower.StartsWith("http") Then
                    fileGraphics.txtDir.ForeColor = Color.DarkRed
                    imgGraphics.Load(fileGraphics.Filename) ' Loads either from file or from URL
                    fileGraphics.txtDir.ForeColor = SystemColors.ControlText
                End If
            End If

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



    Private Sub frmOptions_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        Dim iHeight As Integer = Height - 440
        Dim iWidth As Integer = Width - 190 ' 296

        iHeight = Math.Min(iHeight, iWidth)
        iWidth = Math.Min(iHeight, iWidth)

        imgGraphics.Size = New Size(iHeight, iWidth)

    End Sub


    Private Sub txtDescription_GotFocus(sender As Object, e As System.EventArgs) Handles txtDescription.GotFocus
        Me.AcceptButton = Nothing
    End Sub


    Private Sub txtDescription_LostFocus(sender As Object, e As System.EventArgs) Handles txtDescription.LostFocus
        Me.AcceptButton = btnOK
    End Sub



    Private Sub StuffChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowExits.CheckedChanged, fileGraphics.TextChanged, txtAuthor.TextChanged, txtTitle.TextChanged, txtHeadline.TextChanged, txtDescription.TextChanged, cmbGenre.ValueChanged, cmbForgiveness.ValueChanged, chkEnableMenu.CheckedChanged
        Changed = True
    End Sub


    Private Sub btnSetFont_Click(sender As System.Object, e As System.EventArgs) Handles btnSetFont.Click

        With fd
            .FontMustExist = False
            .MinSize = 8
            .MaxSize = 36

            If txtFont.Text <> "" Then
                Dim sName As String = ""
                Dim emSize As Single = 0

                Dim sFont() As String = txtFont.Text.Split(","c)
                If sFont(0) <> "" Then sName = sFont(0)

                If sFont(1) <> "" Then
                    If SafeDbl(sFont(1)) > 0 Then emSize = CSng(SafeDbl(sFont(1)))
                End If
                If sName <> "" AndAlso emSize > 0 Then
                    Dim f As New Font(sName, emSize)
                    .Font = f
                End If
            End If
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim sFontInfo() As String = .Font.ToString.Split(","c)
                txtFont.Text = sFontInfo(0).Replace("[Font: Name=", "") & ", " & SafeInt(sFontInfo(1).Replace(" Size=", ""))
            End If
        End With
    End Sub

    Private Sub pnlBackgroundColour_Click(sender As Object, e As System.EventArgs) Handles pnlInputColour.Click, pnlOutputColour.Click, pnlBackgroundColour.Click, pnlLinkColour.Click

        Dim dlgColour As New ColorDialog
        dlgColour.Color = CType(sender, Panel).BackColor

        If dlgColour.ShowDialog = Windows.Forms.DialogResult.OK Then
            CType(sender, Panel).BackColor = dlgColour.Color
            Changed = True
        End If

    End Sub

End Class
