Public Class frmSettings
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
    Friend WithEvents _lblInfo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnAdd As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lvwLibraries As System.Windows.Forms.ListView
    Friend WithEvents btnRemove As Infragistics.Win.Misc.UltraButton
    Public WithEvents Library As System.Windows.Forms.ColumnHeader
    Friend WithEvents tabLibraries As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents tabsOptions As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents tabGeneral As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents cmbViewStyle As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblTheme As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnDown As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnUp As Infragistics.Win.Misc.UltraButton
    Friend WithEvents chkHideLibraryItems As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbDictionary As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblDictionary As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dbUserDictionary As ADRIFT.DirectoryBox
    Friend WithEvents dbDictionary As ADRIFT.DirectoryBox
    Friend WithEvents chkShowInTaskbar As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbReciprocalLink As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmbReciprocalRestriction As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbColour As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmbOverwriteLibraries As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbReplaceNames As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents chkSimpleMode As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkAutoComplete As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkAudio As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkGraphics As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkPreview As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkVersion As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents cmbDefaultTaskActions As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblLibraryDescription As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents chkKeyNames As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkShowKeys As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem21 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem22 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem23 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem26 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem27 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem28 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem29 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem24 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem25 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem17 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem13 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.tabGeneral = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chkGraphics = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkPreview = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkAudio = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmbReciprocalLink = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmbReciprocalRestriction = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbReplaceNames = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmbDictionary = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblDictionary = New Infragistics.Win.Misc.UltraLabel()
        Me.dbDictionary = New ADRIFT.DirectoryBox()
        Me.dbUserDictionary = New ADRIFT.DirectoryBox()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lblTheme = New Infragistics.Win.Misc.UltraLabel()
        Me.cmbViewStyle = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.chkShowKeys = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkShowInTaskbar = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.cmbColour = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel()
        Me.chkSimpleMode = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkAutoComplete = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmbDefaultTaskActions = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.chkVersion = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.tabLibraries = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.lblLibraryDescription = New Infragistics.Win.Misc.UltraLabel()
        Me.cmbOverwriteLibraries = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.chkHideLibraryItems = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.btnDown = New Infragistics.Win.Misc.UltraButton()
        Me.btnUp = New Infragistics.Win.Misc.UltraButton()
        Me.btnRemove = New Infragistics.Win.Misc.UltraButton()
        Me.btnAdd = New Infragistics.Win.Misc.UltraButton()
        Me._lblInfo = New Infragistics.Win.Misc.UltraLabel()
        Me.lvwLibraries = New System.Windows.Forms.ListView()
        Me.Library = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.chkKeyNames = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.btnApply = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.tabsOptions = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.tabGeneral.SuspendLayout()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.chkGraphics, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAudio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.cmbReciprocalLink, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbReciprocalRestriction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbReplaceNames, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.cmbDictionary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.cmbViewStyle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowKeys, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowInTaskbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbColour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSimpleMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutoComplete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDefaultTaskActions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLibraries.SuspendLayout()
        CType(Me.cmbOverwriteLibraries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHideLibraryItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.chkKeyNames, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabsOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.UltraGroupBox4)
        Me.tabGeneral.Controls.Add(Me.UltraGroupBox3)
        Me.tabGeneral.Controls.Add(Me.UltraGroupBox2)
        Me.tabGeneral.Controls.Add(Me.UltraGroupBox1)
        Me.tabGeneral.Controls.Add(Me.cmbDefaultTaskActions)
        Me.tabGeneral.Controls.Add(Me.UltraLabel7)
        Me.tabGeneral.Controls.Add(Me.chkVersion)
        Me.tabGeneral.Location = New System.Drawing.Point(1, 22)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Size = New System.Drawing.Size(568, 458)
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox4.Controls.Add(Me.chkGraphics)
        Me.UltraGroupBox4.Controls.Add(Me.chkPreview)
        Me.UltraGroupBox4.Controls.Add(Me.chkAudio)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(326, 290)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(233, 116)
        Me.UltraGroupBox4.TabIndex = 46
        Me.UltraGroupBox4.Text = "Text Boxes"
        Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'chkGraphics
        '
        Me.chkGraphics.BackColor = System.Drawing.Color.Transparent
        Me.chkGraphics.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkGraphics.Location = New System.Drawing.Point(31, 29)
        Me.chkGraphics.Name = "chkGraphics"
        Me.chkGraphics.Size = New System.Drawing.Size(109, 20)
        Me.chkGraphics.TabIndex = 39
        Me.chkGraphics.Text = "Enable Graphics"
        '
        'chkPreview
        '
        Me.chkPreview.BackColor = System.Drawing.Color.Transparent
        Me.chkPreview.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkPreview.Location = New System.Drawing.Point(31, 81)
        Me.chkPreview.Name = "chkPreview"
        Me.chkPreview.Size = New System.Drawing.Size(109, 20)
        Me.chkPreview.TabIndex = 41
        Me.chkPreview.Text = "Enable Preview"
        '
        'chkAudio
        '
        Me.chkAudio.BackColor = System.Drawing.Color.Transparent
        Me.chkAudio.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkAudio.Location = New System.Drawing.Point(31, 55)
        Me.chkAudio.Name = "chkAudio"
        Me.chkAudio.Size = New System.Drawing.Size(109, 20)
        Me.chkAudio.TabIndex = 40
        Me.chkAudio.Text = "Enable Audio"
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox3.Controls.Add(Me.cmbReciprocalLink)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox3.Controls.Add(Me.cmbReciprocalRestriction)
        Me.UltraGroupBox3.Controls.Add(Me.cmbReplaceNames)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(11, 289)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(309, 117)
        Me.UltraGroupBox3.TabIndex = 30
        Me.UltraGroupBox3.Text = "Prompts"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel3
        '
        Me.UltraLabel3.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel3.Location = New System.Drawing.Point(20, 29)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(134, 16)
        Me.UltraLabel3.TabIndex = 32
        Me.UltraLabel3.Text = "Copy reciprocal links:"
        '
        'cmbReciprocalLink
        '
        Me.cmbReciprocalLink.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem7.DataValue = 0
        ValueListItem7.DisplayText = "Prompt"
        ValueListItem8.DataValue = 6
        ValueListItem8.DisplayText = "Always"
        ValueListItem9.DataValue = 7
        ValueListItem9.DisplayText = "Never"
        Me.cmbReciprocalLink.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem7, ValueListItem8, ValueListItem9})
        Me.cmbReciprocalLink.Location = New System.Drawing.Point(185, 25)
        Me.cmbReciprocalLink.Name = "cmbReciprocalLink"
        Me.cmbReciprocalLink.Size = New System.Drawing.Size(80, 21)
        Me.cmbReciprocalLink.TabIndex = 31
        Me.cmbReciprocalLink.Text = "Prompt"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel4.Location = New System.Drawing.Point(20, 57)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(153, 16)
        Me.UltraLabel4.TabIndex = 34
        Me.UltraLabel4.Text = "Copy reciprocal restrictions:"
        '
        'cmbReciprocalRestriction
        '
        Me.cmbReciprocalRestriction.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem4.DataValue = 0
        ValueListItem4.DisplayText = "Prompt"
        ValueListItem5.DataValue = 6
        ValueListItem5.DisplayText = "Always"
        ValueListItem6.DataValue = 7
        ValueListItem6.DisplayText = "Never"
        Me.cmbReciprocalRestriction.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem4, ValueListItem5, ValueListItem6})
        Me.cmbReciprocalRestriction.Location = New System.Drawing.Point(185, 53)
        Me.cmbReciprocalRestriction.Name = "cmbReciprocalRestriction"
        Me.cmbReciprocalRestriction.Size = New System.Drawing.Size(80, 21)
        Me.cmbReciprocalRestriction.TabIndex = 33
        Me.cmbReciprocalRestriction.Text = "Prompt"
        '
        'cmbReplaceNames
        '
        Me.cmbReplaceNames.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem21.DataValue = 0
        ValueListItem21.DisplayText = "Prompt"
        ValueListItem22.DataValue = 6
        ValueListItem22.DisplayText = "Always"
        ValueListItem23.DataValue = 7
        ValueListItem23.DisplayText = "Never"
        Me.cmbReplaceNames.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem21, ValueListItem22, ValueListItem23})
        Me.cmbReplaceNames.Location = New System.Drawing.Point(185, 80)
        Me.cmbReplaceNames.Name = "cmbReplaceNames"
        Me.cmbReplaceNames.Size = New System.Drawing.Size(80, 21)
        Me.cmbReplaceNames.TabIndex = 36
        Me.cmbReplaceNames.Text = "Prompt"
        '
        'UltraLabel6
        '
        Me.UltraLabel6.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel6.Location = New System.Drawing.Point(20, 84)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(160, 17)
        Me.UltraLabel6.TabIndex = 37
        Me.UltraLabel6.Text = "Replace Character Names:"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox2.Controls.Add(Me.cmbDictionary)
        Me.UltraGroupBox2.Controls.Add(Me.lblDictionary)
        Me.UltraGroupBox2.Controls.Add(Me.dbDictionary)
        Me.UltraGroupBox2.Controls.Add(Me.dbUserDictionary)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(11, 136)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(548, 147)
        Me.UltraGroupBox2.TabIndex = 39
        Me.UltraGroupBox2.Text = "Spell Check"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel2
        '
        Me.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel2.Location = New System.Drawing.Point(20, 32)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(109, 16)
        Me.UltraLabel2.TabIndex = 24
        Me.UltraLabel2.Text = "Dictionary language:"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel1.Location = New System.Drawing.Point(20, 106)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(134, 16)
        Me.UltraLabel1.TabIndex = 23
        Me.UltraLabel1.Text = "User dictionary location:"
        '
        'cmbDictionary
        '
        Me.cmbDictionary.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "English"
        ValueListItem2.DataValue = "Dutch"
        ValueListItem3.DataValue = "French"
        ValueListItem26.DataValue = "German"
        ValueListItem27.DataValue = "Italian"
        ValueListItem28.DataValue = "Portugese"
        ValueListItem29.DataValue = "Spanish"
        Me.cmbDictionary.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3, ValueListItem26, ValueListItem27, ValueListItem28, ValueListItem29})
        Me.cmbDictionary.Location = New System.Drawing.Point(155, 28)
        Me.cmbDictionary.Name = "cmbDictionary"
        Me.cmbDictionary.Size = New System.Drawing.Size(144, 21)
        Me.cmbDictionary.TabIndex = 25
        Me.cmbDictionary.Text = "English"
        '
        'lblDictionary
        '
        Me.lblDictionary.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblDictionary.Location = New System.Drawing.Point(20, 69)
        Me.lblDictionary.Name = "lblDictionary"
        Me.lblDictionary.Size = New System.Drawing.Size(134, 16)
        Me.lblDictionary.TabIndex = 27
        Me.lblDictionary.Text = "Main dictionary location:"
        '
        'dbDictionary
        '
        Me.dbDictionary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dbDictionary.BackColor = System.Drawing.Color.Transparent
        Me.dbDictionary.BoxType = ADRIFT.DirectoryBox.BoxTypeEnum.File
        Me.dbDictionary.Directory = "*** Incorrect BoxType ***"
        Me.dbDictionary.FileFilter = "Dictionary Files (*.dict)|*.dict|All Files (*.*)|*.*"
        Me.dbDictionary.Filename = ""
        Me.dbDictionary.Location = New System.Drawing.Point(155, 64)
        Me.dbDictionary.Name = "dbDictionary"
        Me.dbDictionary.OpenOrSave = ADRIFT.DirectoryBox.OpenOrSaveEnum.Open
        Me.dbDictionary.Size = New System.Drawing.Size(370, 21)
        Me.dbDictionary.TabIndex = 28
        '
        'dbUserDictionary
        '
        Me.dbUserDictionary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dbUserDictionary.BackColor = System.Drawing.Color.Transparent
        Me.dbUserDictionary.BoxType = ADRIFT.DirectoryBox.BoxTypeEnum.File
        Me.dbUserDictionary.Directory = "*** Incorrect BoxType ***"
        Me.dbUserDictionary.FileFilter = "Dictionary Files (*.dict)|*.dict|All Files (*.*)|*.*"
        Me.dbUserDictionary.Filename = ""
        Me.dbUserDictionary.Location = New System.Drawing.Point(155, 102)
        Me.dbUserDictionary.Name = "dbUserDictionary"
        Me.dbUserDictionary.OpenOrSave = ADRIFT.DirectoryBox.OpenOrSaveEnum.Open
        Me.dbUserDictionary.Size = New System.Drawing.Size(370, 21)
        Me.dbUserDictionary.TabIndex = 29
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox1.Controls.Add(Me.lblTheme)
        Me.UltraGroupBox1.Controls.Add(Me.cmbViewStyle)
        Me.UltraGroupBox1.Controls.Add(Me.chkShowKeys)
        Me.UltraGroupBox1.Controls.Add(Me.chkShowInTaskbar)
        Me.UltraGroupBox1.Controls.Add(Me.cmbColour)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel14)
        Me.UltraGroupBox1.Controls.Add(Me.chkSimpleMode)
        Me.UltraGroupBox1.Controls.Add(Me.chkAutoComplete)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel8)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel13)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel9)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel10)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(11, 12)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(548, 118)
        Me.UltraGroupBox1.TabIndex = 45
        Me.UltraGroupBox1.Text = "Appearance"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'lblTheme
        '
        Me.lblTheme.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblTheme.Location = New System.Drawing.Point(20, 37)
        Me.lblTheme.Name = "lblTheme"
        Me.lblTheme.Size = New System.Drawing.Size(91, 16)
        Me.lblTheme.TabIndex = 0
        Me.lblTheme.Text = "Window theme:"
        '
        'cmbViewStyle
        '
        Me.cmbViewStyle.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbViewStyle.Location = New System.Drawing.Point(155, 32)
        Me.cmbViewStyle.Name = "cmbViewStyle"
        Me.cmbViewStyle.Size = New System.Drawing.Size(144, 21)
        Me.cmbViewStyle.TabIndex = 20
        '
        'chkShowKeys
        '
        Me.chkShowKeys.BackColor = System.Drawing.Color.Transparent
        Me.chkShowKeys.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkShowKeys.Location = New System.Drawing.Point(24, 65)
        Me.chkShowKeys.Name = "chkShowKeys"
        Me.chkShowKeys.Size = New System.Drawing.Size(160, 20)
        Me.chkShowKeys.TabIndex = 21
        Me.chkShowKeys.Text = "Show Keys on Edit forms"
        '
        'chkShowInTaskbar
        '
        Me.chkShowInTaskbar.BackColor = System.Drawing.Color.Transparent
        Me.chkShowInTaskbar.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkShowInTaskbar.Location = New System.Drawing.Point(262, 65)
        Me.chkShowInTaskbar.Name = "chkShowInTaskbar"
        Me.chkShowInTaskbar.Size = New System.Drawing.Size(198, 20)
        Me.chkShowInTaskbar.TabIndex = 30
        Me.chkShowInTaskbar.Text = "Show all open windows in taskbar"
        '
        'cmbColour
        '
        Me.cmbColour.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbColour.Location = New System.Drawing.Point(305, 32)
        Me.cmbColour.Name = "cmbColour"
        Me.cmbColour.Size = New System.Drawing.Size(114, 21)
        Me.cmbColour.TabIndex = 35
        Me.cmbColour.Visible = False
        '
        'UltraLabel14
        '
        Me.UltraLabel14.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel14.Location = New System.Drawing.Point(-215, 152)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.Size = New System.Drawing.Size(134, 16)
        Me.UltraLabel14.TabIndex = 23
        Me.UltraLabel14.Text = "User dictionary location:"
        '
        'chkSimpleMode
        '
        Me.chkSimpleMode.BackColor = System.Drawing.Color.Transparent
        Me.chkSimpleMode.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkSimpleMode.Location = New System.Drawing.Point(24, 91)
        Me.chkSimpleMode.Name = "chkSimpleMode"
        Me.chkSimpleMode.Size = New System.Drawing.Size(98, 20)
        Me.chkSimpleMode.TabIndex = 38
        Me.chkSimpleMode.Text = "Simple Mode"
        '
        'chkAutoComplete
        '
        Me.chkAutoComplete.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoComplete.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkAutoComplete.Location = New System.Drawing.Point(262, 91)
        Me.chkAutoComplete.Name = "chkAutoComplete"
        Me.chkAutoComplete.Size = New System.Drawing.Size(184, 20)
        Me.chkAutoComplete.TabIndex = 38
        Me.chkAutoComplete.Text = "Auto Complete dropdown lists"
        '
        'UltraLabel8
        '
        Me.UltraLabel8.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel8.Location = New System.Drawing.Point(-215, 152)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(134, 16)
        Me.UltraLabel8.TabIndex = 23
        Me.UltraLabel8.Text = "User dictionary location:"
        '
        'UltraLabel13
        '
        Me.UltraLabel13.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel13.Location = New System.Drawing.Point(-215, 78)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(109, 16)
        Me.UltraLabel13.TabIndex = 24
        Me.UltraLabel13.Text = "Dictionary language:"
        '
        'UltraLabel12
        '
        Me.UltraLabel12.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel12.Location = New System.Drawing.Point(-215, 115)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(134, 16)
        Me.UltraLabel12.TabIndex = 27
        Me.UltraLabel12.Text = "Main dictionary location:"
        '
        'UltraLabel9
        '
        Me.UltraLabel9.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel9.Location = New System.Drawing.Point(-215, 78)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(109, 16)
        Me.UltraLabel9.TabIndex = 24
        Me.UltraLabel9.Text = "Dictionary language:"
        '
        'UltraLabel10
        '
        Me.UltraLabel10.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel10.Location = New System.Drawing.Point(-215, 115)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(134, 16)
        Me.UltraLabel10.TabIndex = 27
        Me.UltraLabel10.Text = "Main dictionary location:"
        '
        'cmbDefaultTaskActions
        '
        Me.cmbDefaultTaskActions.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem24.DataValue = 0
        ValueListItem24.DisplayText = "Before Actions"
        ValueListItem25.DataValue = 1
        ValueListItem25.DisplayText = "After Actions"
        Me.cmbDefaultTaskActions.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem24, ValueListItem25})
        Me.cmbDefaultTaskActions.Location = New System.Drawing.Point(196, 421)
        Me.cmbDefaultTaskActions.Name = "cmbDefaultTaskActions"
        Me.cmbDefaultTaskActions.Size = New System.Drawing.Size(94, 21)
        Me.cmbDefaultTaskActions.TabIndex = 43
        Me.cmbDefaultTaskActions.Text = "After Actions"
        '
        'UltraLabel7
        '
        Me.UltraLabel7.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel7.Location = New System.Drawing.Point(26, 425)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(169, 17)
        Me.UltraLabel7.TabIndex = 44
        Me.UltraLabel7.Text = "Default task messages to output"
        '
        'chkVersion
        '
        Me.chkVersion.BackColor = System.Drawing.Color.Transparent
        Me.chkVersion.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkVersion.Location = New System.Drawing.Point(357, 422)
        Me.chkVersion.Name = "chkVersion"
        Me.chkVersion.Size = New System.Drawing.Size(191, 20)
        Me.chkVersion.TabIndex = 42
        Me.chkVersion.Text = "Check for new version on startup"
        '
        'tabLibraries
        '
        Me.tabLibraries.Controls.Add(Me.lblLibraryDescription)
        Me.tabLibraries.Controls.Add(Me.cmbOverwriteLibraries)
        Me.tabLibraries.Controls.Add(Me.UltraLabel5)
        Me.tabLibraries.Controls.Add(Me.chkHideLibraryItems)
        Me.tabLibraries.Controls.Add(Me.btnDown)
        Me.tabLibraries.Controls.Add(Me.btnUp)
        Me.tabLibraries.Controls.Add(Me.btnRemove)
        Me.tabLibraries.Controls.Add(Me.btnAdd)
        Me.tabLibraries.Controls.Add(Me._lblInfo)
        Me.tabLibraries.Controls.Add(Me.lvwLibraries)
        Me.tabLibraries.Location = New System.Drawing.Point(-10000, -10000)
        Me.tabLibraries.Name = "tabLibraries"
        Me.tabLibraries.Size = New System.Drawing.Size(568, 458)
        '
        'lblLibraryDescription
        '
        Me.lblLibraryDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLibraryDescription.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lblLibraryDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLibraryDescription.Location = New System.Drawing.Point(16, 202)
        Me.lblLibraryDescription.Name = "lblLibraryDescription"
        Me.lblLibraryDescription.Size = New System.Drawing.Size(512, 183)
        Me.lblLibraryDescription.TabIndex = 35
        '
        'cmbOverwriteLibraries
        '
        Me.cmbOverwriteLibraries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbOverwriteLibraries.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem11.DataValue = 0
        ValueListItem11.DisplayText = "Prompt per library"
        ValueListItem17.DataValue = 1
        ValueListItem17.DisplayText = "Prompt per item"
        ValueListItem12.DataValue = 2
        ValueListItem12.DisplayText = "Always overwrite"
        ValueListItem13.DataValue = 3
        ValueListItem13.DisplayText = "Never overwrite"
        Me.cmbOverwriteLibraries.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem11, ValueListItem17, ValueListItem12, ValueListItem13})
        Me.cmbOverwriteLibraries.Location = New System.Drawing.Point(356, 423)
        Me.cmbOverwriteLibraries.Name = "cmbOverwriteLibraries"
        Me.cmbOverwriteLibraries.Size = New System.Drawing.Size(128, 21)
        Me.cmbOverwriteLibraries.TabIndex = 33
        Me.cmbOverwriteLibraries.Text = "Prompt per library"
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel5.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel5.Location = New System.Drawing.Point(18, 427)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(332, 16)
        Me.UltraLabel5.TabIndex = 34
        Me.UltraLabel5.Text = "When loading a newer library item than in the current adventure:"
        '
        'chkHideLibraryItems
        '
        Me.chkHideLibraryItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkHideLibraryItems.BackColor = System.Drawing.Color.Transparent
        Me.chkHideLibraryItems.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkHideLibraryItems.Location = New System.Drawing.Point(16, 391)
        Me.chkHideLibraryItems.Name = "chkHideLibraryItems"
        Me.chkHideLibraryItems.Size = New System.Drawing.Size(160, 20)
        Me.chkHideLibraryItems.TabIndex = 22
        Me.chkHideLibraryItems.Text = "Hide Library Items"
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDown.Enabled = False
        Me.btnDown.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnDown.Location = New System.Drawing.Point(534, 126)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(24, 23)
        Me.btnDown.TabIndex = 8
        Me.btnDown.Text = "6"
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUp.Enabled = False
        Me.btnUp.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnUp.Location = New System.Drawing.Point(534, 97)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(24, 23)
        Me.btnUp.TabIndex = 7
        Me.btnUp.Text = "5"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Enabled = False
        Me.btnRemove.Location = New System.Drawing.Point(400, 389)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(128, 22)
        Me.btnRemove.TabIndex = 5
        Me.btnRemove.Text = "Remove Library"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(266, 389)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(128, 22)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add New Library"
        '
        '_lblInfo
        '
        Me._lblInfo.BackColorInternal = System.Drawing.Color.Transparent
        Me._lblInfo.Location = New System.Drawing.Point(16, 16)
        Me._lblInfo.Name = "_lblInfo"
        Me._lblInfo.Size = New System.Drawing.Size(464, 24)
        Me._lblInfo.TabIndex = 1
        Me._lblInfo.Text = "The following Libraries will be pre-loaded in all new games and older version upg" &
    "rades."
        '
        'lvwLibraries
        '
        Me.lvwLibraries.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwLibraries.CheckBoxes = True
        Me.lvwLibraries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Library})
        Me.lvwLibraries.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwLibraries.FullRowSelect = True
        Me.lvwLibraries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvwLibraries.HideSelection = False
        Me.lvwLibraries.Location = New System.Drawing.Point(16, 48)
        Me.lvwLibraries.Name = "lvwLibraries"
        Me.lvwLibraries.Size = New System.Drawing.Size(512, 148)
        Me.lvwLibraries.TabIndex = 0
        Me.lvwLibraries.UseCompatibleStateImageBehavior = False
        Me.lvwLibraries.View = System.Windows.Forms.View.Details
        '
        'Library
        '
        Me.Library.Width = 284
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.chkKeyNames)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(568, 458)
        '
        'chkKeyNames
        '
        Me.chkKeyNames.BackColor = System.Drawing.Color.Transparent
        Me.chkKeyNames.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkKeyNames.Location = New System.Drawing.Point(30, 39)
        Me.chkKeyNames.Name = "chkKeyNames"
        Me.chkKeyNames.Size = New System.Drawing.Size(237, 20)
        Me.chkKeyNames.TabIndex = 22
        Me.chkKeyNames.Text = "Generate Key names from item names"
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(466, 489)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(88, 32)
        Me.btnApply.TabIndex = 18
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(370, 489)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(274, 489)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "OK"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 481)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(570, 48)
        Me.UltraStatusBar1.TabIndex = 15
        '
        'tabsOptions
        '
        Me.tabsOptions.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabsOptions.Controls.Add(Me.tabLibraries)
        Me.tabsOptions.Controls.Add(Me.tabGeneral)
        Me.tabsOptions.Controls.Add(Me.UltraTabPageControl1)
        Me.tabsOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsOptions.Location = New System.Drawing.Point(0, 0)
        Me.tabsOptions.Name = "tabsOptions"
        Me.tabsOptions.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabsOptions.Size = New System.Drawing.Size(570, 481)
        Me.tabsOptions.TabIndex = 19
        UltraTab1.Key = "General"
        UltraTab1.TabPage = Me.tabGeneral
        UltraTab1.Text = "General"
        UltraTab2.Key = "Libraries"
        UltraTab2.TabPage = Me.tabLibraries
        UltraTab2.Text = "Libraries"
        UltraTab3.Key = "Advanced"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "Advanced"
        Me.tabsOptions.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3})
        Me.tabsOptions.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(568, 458)
        '
        'frmSettings
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(570, 529)
        Me.Controls.Add(Me.tabsOptions)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(586, 567)
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = False
        Me.Text = "Settings"
        Me.tabGeneral.ResumeLayout(False)
        Me.tabGeneral.PerformLayout()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        CType(Me.chkGraphics, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAudio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.cmbReciprocalLink, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbReciprocalRestriction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbReplaceNames, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.cmbDictionary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.cmbViewStyle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowKeys, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowInTaskbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbColour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSimpleMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutoComplete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDefaultTaskActions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkVersion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLibraries.ResumeLayout(False)
        Me.tabLibraries.PerformLayout()
        CType(Me.cmbOverwriteLibraries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHideLibraryItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.chkKeyNames, System.ComponentModel.ISupportInitialize).EndInit()
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

        ' Load Libraries from registry
        'Dim sLibraries() As String = GetSetting("ADRIFT", "Generator", "Libraries").Split("|"c)

        Dim lvi As ListViewItem = Nothing
        For Each sLibrary As String In GetLibraries
            If sLibrary <> "" Then
                Dim sFile As String
                Dim bChecked As Boolean = True
                If sLibrary.Contains("#") Then
                    sFile = sLibrary.Split("#"c)(0)
                    bChecked = CBool(sLibrary.Split("#"c)(1))
                Else
                    sFile = sLibrary
                End If

                lvi = lvwLibraries.Items.Add(sFile)
                lvi.Checked = bChecked

            End If
        Next

        'cmbViewStyle.Items.Add(Infragistics.Win.Misc.GroupBoxViewStyle.Office2000, Infragistics.Win.Misc.GroupBoxViewStyle.Office2000.ToString)
        'cmbViewStyle.Items.Add(Infragistics.Win.Misc.GroupBoxViewStyle.XP, Infragistics.Win.Misc.GroupBoxViewStyle.XP.ToString)

        cmbViewStyle.Items.Add(Infragistics.Win.UltraWinToolbars.ToolbarStyle.Default, Infragistics.Win.UltraWinToolbars.ToolbarStyle.Default.ToString)
        cmbViewStyle.Items.Add(Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003, Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003.ToString)
        cmbViewStyle.Items.Add(Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007, Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007.ToString)
        cmbViewStyle.Items.Add(Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2010, Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2010.ToString)
        cmbViewStyle.Items.Add(Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013, Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013.ToString)
        cmbViewStyle.Items.Add(Infragistics.Win.UltraWinToolbars.ToolbarStyle.VisualStudio2005, Infragistics.Win.UltraWinToolbars.ToolbarStyle.VisualStudio2005.ToString)

        'Dim eViewStyle As Infragistics.Win.UltraWinToolbars.ToolbarStyle = EnumParseViewStyle(GetSetting("ADRIFT", "Generator", "ViewStyle", "Standard"))
        'SetCombo(cmbViewStyle, eViewStyle)

        'cmbColour.Items.Add(Infragistics.Win.Office2007ColorScheme.Blue, Infragistics.Win.Office2007ColorScheme.Blue.ToString)
        'cmbColour.Items.Add(Infragistics.Win.Office2007ColorScheme.Silver, Infragistics.Win.Office2007ColorScheme.Silver.ToString)
        'cmbColour.Items.Add(Infragistics.Win.Office2007ColorScheme.Black, Infragistics.Win.Office2007ColorScheme.Black.ToString)

        'Dim eColourScheme2007 As Infragistics.Win.Office2007ColorScheme = EnumParseColourScheme2007(GetSetting("ADRIFT", "Generator", "ColourScheme", "Blue"))
        'SetCombo(cmbColour, eColourScheme)

        Dim eViewStyle As Infragistics.Win.UltraWinToolbars.ToolbarStyle = EnumParseViewStyle(GetSetting("ADRIFT", "Generator", "ViewStyle", "Office2007"))
        SetCombo(cmbViewStyle, eViewStyle)
        Select Case eStyle
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007
                Dim eColourScheme2007 As Infragistics.Win.Office2007ColorScheme = EnumParseColourScheme2007(GetSetting("ADRIFT", "Generator", "ColourScheme", "Blue"))
                SetCombo(cmbColour, eColourScheme2007)
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2010
                Dim eColourScheme2010 As Infragistics.Win.Office2010ColorScheme = EnumParseColourScheme2010(GetSetting("ADRIFT", "Generator", "ColourScheme", "Blue"))
                SetCombo(cmbColour, eColourScheme2010)
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013
                Dim eColourScheme2013 As Infragistics.Win.Office2013ColorScheme = EnumParseColourScheme2013(GetSetting("ADRIFT", "Generator", "ColourScheme", "LightGray"))
                SetCombo(cmbColour, eColourScheme2013)
        End Select

        chkShowKeys.Checked = SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0"))
        chkHideLibraryItems.Checked = SafeBool(GetSetting("ADRIFT", "Generator", "HideLibraryItems", "-1"))
        chkShowInTaskbar.Checked = SafeBool(GetSetting("ADRIFT", "Generator", "ShowInTaskBar", "0"))
        chkSimpleMode.Checked = fGenerator.SimpleMode
        chkAutoComplete.Checked = fGenerator.AutoComplete
        chkVersion.Checked = SafeBool(CInt(GetSetting("ADRIFT", "Shared", "AutoCheck", "1")))
        chkKeyNames.Checked = SafeBool(CInt(GetSetting("ADRIFT", "Generator", "KeyNames", "-1")))

        SetCombo(cmbDictionary, sDictionary)
        dbUserDictionary.Filename = sUserDictionary
        dbDictionary.Filename = sMainDictionary

        SetCombo(cmbReciprocalLink, SafeInt(GetSetting("ADRIFT", "Generator", "ReciprocalLink", "0")))
        SetCombo(cmbReciprocalRestriction, SafeInt(GetSetting("ADRIFT", "Generator", "ReciprocalRestriction", "0")))
        SetCombo(cmbReplaceNames, SafeInt(GetSetting("ADRIFT", "Generator", "ReplaceCharacterNames", "0")))
        SetCombo(cmbOverwriteLibraries, CInt(eOverwriteLibraries))
        SetCombo(cmbDefaultTaskActions, SafeInt(GetSetting("ADRIFT", "Generator", "DefaultActions", "1")))

        chkGraphics.Checked = bEnableGraphics
        chkAudio.Checked = bEnableAudio
        chkPreview.Checked = bEnablePreview

        Changed = False
        Me.Show()

    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ApplySettings()
        CloseSettings(Me)
    End Sub


    Private Sub ApplySettings()

        ' Save Libraries to Registry
        Dim sLibraries As String = ""
        For Each lvi As ListViewItem In lvwLibraries.Items
            sLibraries &= lvi.Text & "#" & lvi.Checked & "|"
        Next
        SaveSetting("ADRIFT", "Generator", "Libraries", sLibraries)
        SaveSetting("ADRIFT", "Generator", "ShowKeys", CInt(chkShowKeys.Checked).ToString)
        SaveSetting("ADRIFT", "Generator", "HideLibraryItems", CInt(chkHideLibraryItems.Checked).ToString)
        SaveSetting("ADRIFT", "Generator", "KeyNames", CInt(chkKeyNames.Checked).ToString)

        ' Show/Hide any current library items as applicable 
        fGenerator.FolderList1.HideLibrary = chkHideLibraryItems.Checked
        For Each child As frmFolder In fGenerator.MDIFolders
            child.Folder.HideLibrary = chkHideLibraryItems.Checked
        Next
        'If chkHideLibraryItems.Checked Then
        '    'SaveListsToXML() ' Save where all our library tasks are, in case we turn them back on...

        '    For Each frmList As frmList In fGenerator.MdiChildren
        '        For Each lvi As ListViewItem In frmList.ItemList.lvwList.Items
        '            Dim sKey As String = lvi.SubItems(2).Text
        '            If CType(Adventure.dictAllItems(sKey), clsItem).IsLibrary Then
        '                If TypeOf Adventure.dictAllItems(sKey) Is clsTask OrElse TypeOf Adventure.dictAllItems(sKey) Is clsProperty Then lvi.Remove()
        '            End If
        '        Next
        '    Next
        'Else
        '    'LoadLists(False)           
        'End If

        SaveSetting("ADRIFT", "Generator", "ShowInTaskbar", CInt(chkShowInTaskbar.Checked).ToString)
        fGenerator.SimpleMode = chkSimpleMode.Checked
        fGenerator.AutoComplete = chkAutoComplete.Checked
        tabsOptions.Tabs("Advanced").Visible = Not fGenerator.SimpleMode

        eStyle = CType(cmbViewStyle.SelectedItem.DataValue, Infragistics.Win.UltraWinToolbars.ToolbarStyle)
        SaveSetting("ADRIFT", "Generator", "ViewStyle", eStyle.ToString)
        Select Case eStyle
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013
                eColour2013 = CType(cmbColour.SelectedItem.DataValue, Infragistics.Win.Office2013ColorScheme)
                SaveSetting("ADRIFT", "Generator", "ColourScheme", eColour2013.ToString)
                Infragistics.Win.Office2013ColorTable.ColorScheme = eColour2013
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2010
                eColour2010 = CType(cmbColour.SelectedItem.DataValue, Infragistics.Win.Office2010ColorScheme)
                SaveSetting("ADRIFT", "Generator", "ColourScheme", eColour2010.ToString)
                Infragistics.Win.Office2010ColorTable.ColorScheme = eColour2010
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007
                eColour2007 = CType(cmbColour.SelectedItem.DataValue, Infragistics.Win.Office2007ColorScheme)
                SaveSetting("ADRIFT", "Generator", "ColourScheme", eColour2007.ToString)
                Infragistics.Win.Office2007ColorTable.ColorScheme = eColour2007
        End Select

        'For Each fChild As Form In fGenerator.MdiChildren

        'Next
        sDictionary = cmbDictionary.SelectedItem.DataValue.ToString
        SaveSetting("ADRIFT", "Generator", "DictionaryLanguage", sDictionary)
        sUserDictionary = dbUserDictionary.Filename
        SaveSetting("ADRIFT", "Generator", "UserDictionaryLocation", sUserDictionary)
        sMainDictionary = dbDictionary.Filename
        SaveSetting("ADRIFT", "Generator", "DictionaryLocation", sMainDictionary)
        SaveSetting("ADRIFT", "Generator", "ReciprocalLink", cmbReciprocalLink.SelectedItem.DataValue.ToString)
        SaveSetting("ADRIFT", "Generator", "ReplaceCharacterNames", cmbReplaceNames.SelectedItem.DataValue.ToString)
        SaveSetting("ADRIFT", "Generator", "ReciprocalRestriction", cmbReciprocalRestriction.SelectedItem.DataValue.ToString)
        eOverwriteLibraries = CType(cmbOverwriteLibraries.SelectedItem.DataValue, OverwriteLibrariesEnum)
        SaveSetting("ADRIFT", "Generator", "OverwriteLibraries", CInt(eOverwriteLibraries).ToString)
        bEnableGraphics = chkGraphics.Checked
        SaveSetting("ADRIFT", "Generator", "EnableGraphics", CInt(bEnableGraphics).ToString)
        bEnableAudio = chkAudio.Checked
        SaveSetting("ADRIFT", "Generator", "EnableAudio", CInt(bEnableAudio).ToString)
        bEnablePreview = chkPreview.Checked
        SaveSetting("ADRIFT", "Generator", "EnablePreview", CInt(bEnablePreview).ToString)
        SaveSetting("ADRIFT", "Shared", "AutoCheck", CInt(chkVersion.Checked).ToString)
        SaveSetting("ADRIFT", "Generator", "DefaultActions", CInt(cmbDefaultTaskActions.SelectedItem.DataValue).ToString)

        For Each f As Form In colAllForms
            SetWindowStyle(f, fGenerator.UTMMain, fGenerator.UDMGenerator)
        Next

    End Sub


    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ApplySettings()
        Changed = False
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then ApplySettings()
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        CloseSettings(Me)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If Not IsRegistered Then
            NotAvailable()
            Exit Sub
        End If

        With ofd
            .DefaultExt = "amf"
            .FileName = ""
            .Filter = "ADRIFT Module (*.amf)|*.amf|All Files (*.*)|*.*"
            .Title = "Please select an ADRIFT Module"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim lvi As ListViewItem = lvwLibraries.Items.Add(.FileName)
                lvi.Checked = True
                lvwLibraries.SelectedItems.Clear()
                lvi.Selected = True
                Changed = True
                DoButtons()
                lvwLibraries.Columns(lvwLibraries.Columns.Count - 1).Width = -1
            End If

        End With

    End Sub

    Private Sub lvwLibraries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwLibraries.SelectedIndexChanged
        DoButtons()

        Try
            If lvwLibraries.SelectedItems.Count = 1 AndAlso IO.File.Exists(lvwLibraries.SelectedItems(0).Text) Then
                Dim xmlDoc As New Xml.XmlDocument
                Dim sDescription As String = ""
                xmlDoc.Load(lvwLibraries.SelectedItems(0).Text)
                If xmlDoc.Item("Adventure") IsNot Nothing Then
                    With xmlDoc.Item("Adventure")
                        If .Item("Title") IsNot Nothing Then sDescription = .Item("Title").InnerText
                        If .Item("Author") IsNot Nothing AndAlso .Item("Author").InnerText <> "" Then sDescription &= " by " & .Item("Author").InnerText
                        If .Item("Description") IsNot Nothing AndAlso .Item("Description").InnerText <> "" Then
                            If sDescription <> "" Then sDescription &= vbCrLf & vbCrLf
                            sDescription &= .Item("Description").InnerText
                        End If
                    End With
                End If
                lblLibraryDescription.Text = sDescription
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click

        If lvwLibraries.SelectedItems.Count > 0 Then
            lvwLibraries.SelectedItems(0).Remove()
            Changed = True
            DoButtons()
        End If

    End Sub

    Private Sub DoButtons()

        If lvwLibraries.SelectedItems.Count > 0 Then
            btnRemove.Enabled = True
            If lvwLibraries.SelectedItems(0).Index > 0 Then btnUp.Enabled = True Else btnUp.Enabled = False
            If lvwLibraries.SelectedItems(0).Index < lvwLibraries.Items.Count - 1 Then btnDown.Enabled = True Else btnDown.Enabled = False
        Else
            btnRemove.Enabled = False
            btnUp.Enabled = False
            btnDown.Enabled = False
        End If

    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click, btnDown.Click

        Dim iUpDown As Integer = CInt(IIf(sender Is btnUp, -1, +1))

        Dim iSelIndex As Integer = lvwLibraries.SelectedItems(0).Index
        Dim sTemp As String = lvwLibraries.SelectedItems(0).Text
        Dim bChecked As Boolean = lvwLibraries.SelectedItems(0).Checked
        lvwLibraries.SelectedItems(0).Text = lvwLibraries.Items(iSelIndex + iUpDown).Text
        lvwLibraries.SelectedItems(0).Checked = lvwLibraries.Items(iSelIndex + iUpDown).Checked
        lvwLibraries.Items(iSelIndex + iUpDown).Text = sTemp
        lvwLibraries.Items(iSelIndex + iUpDown).Checked = bChecked
        lvwLibraries.Items(iSelIndex).Selected = False
        lvwLibraries.Items(iSelIndex + iUpDown).Selected = True
        DoButtons()
        lvwLibraries.Focus()
        Changed = True

    End Sub

    Private Sub frmSettings_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        fGenerator.fSettings = Nothing
    End Sub

    'Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click

    '    Dim iSelIndex As Integer = lvwLibraries.SelectedItems(0).Index
    '    Dim sTemp As String = lvwLibraries.SelectedItems(0).Text
    '    lvwLibraries.SelectedItems(0).Text = lvwLibraries.Items(iSelIndex - 1).Text
    '    lvwLibraries.Items(iSelIndex - 1).Text = sTemp
    '    lvwLibraries.Items(iSelIndex).Selected = False
    '    lvwLibraries.Items(iSelIndex - 1).Selected = True
    '    DoButtons()
    '    lvwLibraries.Focus()

    'End Sub

    Private Sub frmOptions_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        'lvwLibraries.Columns(0).Width = lvwLibraries.Width - 6
    End Sub

    Private Sub frmOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = Icon.FromHandle(My.Resources.imgSettings16.GetHicon)
        GetFormPosition(Me)
        tabsOptions.Tabs("Advanced").Visible = Not fGenerator.SimpleMode
    End Sub


    Private Sub cmbViewStyle_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbViewStyle.SelectionChanged

        Select Case CType(cmbViewStyle.SelectedItem.DataValue, Infragistics.Win.UltraWinToolbars.ToolbarStyle)
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007
                If cmbColour.Items.Count = 0 OrElse CType(cmbColour.Items(0).DataValue, Infragistics.Win.Office2007ColorScheme) <> Infragistics.Win.Office2007ColorScheme.Blue OrElse cmbColour.Items(0).DisplayText <> Infragistics.Win.Office2007ColorScheme.Blue.ToString Then

                    cmbColour.Items.Clear()
                    cmbColour.Items.Add(Infragistics.Win.Office2007ColorScheme.Blue, Infragistics.Win.Office2007ColorScheme.Blue.ToString)
                    cmbColour.Items.Add(Infragistics.Win.Office2007ColorScheme.Silver, Infragistics.Win.Office2007ColorScheme.Silver.ToString)
                    cmbColour.Items.Add(Infragistics.Win.Office2007ColorScheme.Black, Infragistics.Win.Office2007ColorScheme.Black.ToString)
                    Select Case _PreviousColour
                        Case "Blue", "LightGray"
                            SetCombo(cmbColour, Infragistics.Win.Office2007ColorScheme.Blue)
                        Case "Black", "DarkGray"
                            SetCombo(cmbColour, Infragistics.Win.Office2007ColorScheme.Black)
                        Case "Silver", "White"
                            SetCombo(cmbColour, Infragistics.Win.Office2007ColorScheme.Silver)
                    End Select
                End If
                cmbColour.Visible = True

            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2010
                If cmbColour.Items.Count = 0 OrElse CType(cmbColour.Items(0).DataValue, Infragistics.Win.Office2010ColorScheme) <> Infragistics.Win.Office2010ColorScheme.Blue OrElse cmbColour.Items(0).DisplayText <> Infragistics.Win.Office2010ColorScheme.Blue.ToString Then
                    cmbColour.Items.Clear()
                    cmbColour.Items.Add(Infragistics.Win.Office2010ColorScheme.Blue, Infragistics.Win.Office2010ColorScheme.Blue.ToString)
                    cmbColour.Items.Add(Infragistics.Win.Office2010ColorScheme.Silver, Infragistics.Win.Office2010ColorScheme.Silver.ToString)
                    cmbColour.Items.Add(Infragistics.Win.Office2010ColorScheme.Black, Infragistics.Win.Office2010ColorScheme.Black.ToString)
                    Select Case _PreviousColour
                        Case "Blue", "LightGray"
                            SetCombo(cmbColour, Infragistics.Win.Office2010ColorScheme.Blue)
                        Case "Black", "DarkGray"
                            SetCombo(cmbColour, Infragistics.Win.Office2010ColorScheme.Black)
                        Case "Silver", "White"
                            SetCombo(cmbColour, Infragistics.Win.Office2010ColorScheme.Silver)
                    End Select
                End If
                cmbColour.Visible = True

            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013
                If cmbColour.Items.Count = 0 OrElse CType(cmbColour.Items(0).DataValue, Infragistics.Win.Office2013ColorScheme) <> Infragistics.Win.Office2013ColorScheme.LightGray OrElse cmbColour.Items(0).DisplayText <> Infragistics.Win.Office2013ColorScheme.LightGray.ToString Then
                    cmbColour.Items.Clear()
                    cmbColour.Items.Add(Infragistics.Win.Office2013ColorScheme.LightGray, Infragistics.Win.Office2013ColorScheme.LightGray.ToString)
                    cmbColour.Items.Add(Infragistics.Win.Office2013ColorScheme.White, Infragistics.Win.Office2013ColorScheme.White.ToString)
                    cmbColour.Items.Add(Infragistics.Win.Office2013ColorScheme.DarkGray, Infragistics.Win.Office2013ColorScheme.DarkGray.ToString)
                    Select Case _PreviousColour
                        Case "Blue", "LightGray"
                            SetCombo(cmbColour, Infragistics.Win.Office2013ColorScheme.LightGray)
                        Case "Black", "DarkGray"
                            SetCombo(cmbColour, Infragistics.Win.Office2013ColorScheme.DarkGray)
                        Case "Silver", "White"
                            SetCombo(cmbColour, Infragistics.Win.Office2013ColorScheme.White)
                    End Select
                End If
                cmbColour.Visible = True
            Case Else
                cmbColour.Visible = False
        End Select

    End Sub


    Private Sub StuffChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbViewStyle.ValueChanged, cmbReciprocalLink.ValueChanged, cmbReciprocalRestriction.ValueChanged, cmbColour.ValueChanged, dbDictionary.TextChanged, dbUserDictionary.TextChanged, cmbReplaceNames.SelectionChanged, chkAudio.CheckedChanged, chkGraphics.CheckedChanged, chkPreview.CheckedChanged, chkVersion.CheckedChanged, cmbOverwriteLibraries.SelectionChanged, chkKeyNames.CheckedChanged
        Changed = True
    End Sub


    Private _PreviousColour As String = ""
    Private Sub cmbColour_SelectionChanged(ByVal o As Object, ByVal e As EventArgs) Handles cmbColour.SelectionChanged
        _PreviousColour = cmbColour.SelectedItem.DisplayText
    End Sub


    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        Const WM_PAINT As Integer = &HF  ' 15

        Select Case m.Msg
            Case WM_PAINT
                If lvwLibraries.View = View.Details AndAlso lvwLibraries.Columns.Count > 0 Then
                    lvwLibraries.Columns(lvwLibraries.Columns.Count - 1).Width = -1 ' -2
                End If
        End Select

        MyBase.WndProc(m)

    End Sub

    Private Sub Checkboxes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkHideLibraryItems.Click, chkShowInTaskbar.Click, chkShowKeys.Click, chkSimpleMode.Click, chkAutoComplete.Click
        Changed = True
    End Sub

    Private Sub frmSettings_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Changed = False
    End Sub

    Private Sub frmSettings_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        ShowHelp(Me, "Settings")
    End Sub

End Class
