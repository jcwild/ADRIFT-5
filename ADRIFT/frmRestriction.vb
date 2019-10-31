Public Class frmRestriction
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call        

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
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents cmbLocationExtra As AutoCompleteCombo
    Friend WithEvents cmbLocation As AutoCompleteCombo
    Friend WithEvents lblElse As System.Windows.Forms.Label
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmbWhatL As AutoCompleteCombo
    Friend WithEvents cmbMustNotL As AutoCompleteCombo
    Friend WithEvents cmbObjectExtra As AutoCompleteCombo
    Friend WithEvents cmbWhatO As AutoCompleteCombo
    Friend WithEvents cmbMustNotO As AutoCompleteCombo
    Friend WithEvents cmbObject As AutoCompleteCombo
    Friend WithEvents cmbMustNotT As AutoCompleteCombo
    Friend WithEvents cmbTask As AutoCompleteCombo
    Friend WithEvents lblComplete As System.Windows.Forms.Label
    Friend WithEvents txtMessage As ADRIFT.GenTextbox
    Friend WithEvents tabsRestrictions As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents cmbCharacterExtra As AutoCompleteCombo
    Friend WithEvents cmbWhatC As AutoCompleteCombo
    Friend WithEvents cmbMustNotC As AutoCompleteCombo
    Friend WithEvents cmbCharacter As AutoCompleteCombo
    Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents cmbPropertyOb As AutoCompleteCombo
    Friend WithEvents cmbMustNotP As AutoCompleteCombo
    Friend WithEvents cmbProperty As AutoCompleteCombo
    Friend WithEvents isVariable As ADRIFT.ItemSelector
    Friend WithEvents cmbWhatV As AutoCompleteCombo
    Friend WithEvents cmbMustNotV As AutoCompleteCombo
    Friend WithEvents cmbVariable As AutoCompleteCombo
    Friend WithEvents UltraTabPageControl7 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents cmbMustNotD As AutoCompleteCombo
    Friend WithEvents cmbDirection As AutoCompleteCombo
    Friend WithEvents lblBe As System.Windows.Forms.Label
    Friend WithEvents lblReferencedDirection As System.Windows.Forms.Label
    Friend WithEvents cmbPropertyValue As ADRIFT.PropertyValue
    Friend WithEvents cmbPropEqual As AutoCompleteCombo
    Friend WithEvents cmbIndexEdit As AutoCompleteCombo
    Friend WithEvents cmbIndex As AutoCompleteCombo
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents UltraTabPageControl8 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Expression As ADRIFT.Expression
    Friend WithEvents UltraTabPageControl9 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents cmbItemExtra As AutoCompleteCombo
    Friend WithEvents cmbWhatI As AutoCompleteCombo
    Friend WithEvents cmbMustNotI As AutoCompleteCombo
    Friend WithEvents cmbItem As AutoCompleteCombo
    Friend WithEvents lblFor As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem18 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem19 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem20 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem21 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem16 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem39 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem40 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem24 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem25 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem26 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem27 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem28 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem29 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem30 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem31 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem32 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem33 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem34 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem35 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem36 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem37 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem38 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem22 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem23 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab9 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab7 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab8 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRestriction))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.cmbWhatL = New AutoCompleteCombo()
        Me.cmbLocationExtra = New AutoCompleteCombo()
        Me.cmbMustNotL = New AutoCompleteCombo()
        Me.cmbLocation = New AutoCompleteCombo()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.cmbObjectExtra = New AutoCompleteCombo()
        Me.cmbWhatO = New AutoCompleteCombo()
        Me.cmbMustNotO = New AutoCompleteCombo()
        Me.cmbObject = New AutoCompleteCombo()
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.cmbCharacterExtra = New AutoCompleteCombo()
        Me.cmbWhatC = New AutoCompleteCombo()
        Me.cmbMustNotC = New AutoCompleteCombo()
        Me.cmbCharacter = New AutoCompleteCombo()
        Me.UltraTabPageControl9 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.cmbItemExtra = New AutoCompleteCombo()
        Me.cmbWhatI = New AutoCompleteCombo()
        Me.cmbMustNotI = New AutoCompleteCombo()
        Me.cmbItem = New AutoCompleteCombo()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.lblComplete = New System.Windows.Forms.Label()
        Me.cmbMustNotT = New AutoCompleteCombo()
        Me.cmbTask = New AutoCompleteCombo()
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.cmbVariable = New AutoCompleteCombo()
        Me.cmbIndex = New AutoCompleteCombo()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.cmbIndexEdit = New AutoCompleteCombo()
        Me.isVariable = New ADRIFT.ItemSelector()
        Me.cmbWhatV = New AutoCompleteCombo()
        Me.cmbMustNotV = New AutoCompleteCombo()
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.cmbPropEqual = New AutoCompleteCombo()
        Me.cmbMustNotP = New AutoCompleteCombo()
        Me.cmbPropertyValue = New ADRIFT.PropertyValue()
        Me.lblFor = New System.Windows.Forms.Label()
        Me.cmbPropertyOb = New AutoCompleteCombo()
        Me.cmbProperty = New AutoCompleteCombo()
        Me.UltraTabPageControl7 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.cmbDirection = New AutoCompleteCombo()
        Me.lblBe = New System.Windows.Forms.Label()
        Me.cmbMustNotD = New AutoCompleteCombo()
        Me.lblReferencedDirection = New System.Windows.Forms.Label()
        Me.UltraTabPageControl8 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Expression = New ADRIFT.Expression()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabsRestrictions = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.lblElse = New System.Windows.Forms.Label()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.txtMessage = New ADRIFT.GenTextbox()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.cmbWhatL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLocationExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMustNotL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.cmbObjectExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbWhatO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMustNotO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbObject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl4.SuspendLayout()
        CType(Me.cmbCharacterExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbWhatC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMustNotC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCharacter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl9.SuspendLayout()
        CType(Me.cmbItemExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbWhatI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMustNotI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.cmbMustNotT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl5.SuspendLayout()
        CType(Me.cmbVariable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIndexEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbWhatV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMustNotV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl6.SuspendLayout()
        CType(Me.cmbPropEqual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMustNotP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPropertyOb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbProperty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl7.SuspendLayout()
        CType(Me.cmbDirection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMustNotD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl8.SuspendLayout()
        CType(Me.tabsRestrictions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsRestrictions.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.cmbWhatL)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbLocationExtra)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbMustNotL)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbLocation)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(614, 38)
        '
        'cmbWhatL
        '
        Me.cmbWhatL.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbWhatL.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbWhatL.Location = New System.Drawing.Point(308, 8)
        Me.cmbWhatL.Name = "cmbWhatL"
        Me.cmbWhatL.Size = New System.Drawing.Size(124, 21)
        Me.cmbWhatL.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbWhatL.TabIndex = 4
        '
        'cmbLocationExtra
        '
        Me.cmbLocationExtra.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbLocationExtra.Location = New System.Drawing.Point(393, 8)
        Me.cmbLocationExtra.Name = "cmbLocationExtra"
        Me.cmbLocationExtra.Size = New System.Drawing.Size(192, 21)
        Me.cmbLocationExtra.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbLocationExtra.TabIndex = 5
        '
        'cmbMustNotL
        '
        Me.cmbMustNotL.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbMustNotL.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem3.DataValue = "Must"
        ValueListItem3.DisplayText = "must"
        ValueListItem4.DataValue = "MustNot"
        ValueListItem4.DisplayText = "must not"
        Me.cmbMustNotL.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4})
        Me.cmbMustNotL.Location = New System.Drawing.Point(241, 8)
        Me.cmbMustNotL.Name = "cmbMustNotL"
        Me.cmbMustNotL.Size = New System.Drawing.Size(68, 21)
        Me.cmbMustNotL.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbMustNotL.TabIndex = 3
        '
        'cmbLocation
        '
        Me.cmbLocation.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbLocation.Location = New System.Drawing.Point(8, 8)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(192, 21)
        Me.cmbLocation.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbLocation.TabIndex = 2
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.cmbObjectExtra)
        Me.UltraTabPageControl2.Controls.Add(Me.cmbWhatO)
        Me.UltraTabPageControl2.Controls.Add(Me.cmbMustNotO)
        Me.UltraTabPageControl2.Controls.Add(Me.cmbObject)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(614, 38)
        '
        'cmbObjectExtra
        '
        Me.cmbObjectExtra.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbObjectExtra.Location = New System.Drawing.Point(372, 8)
        Me.cmbObjectExtra.Name = "cmbObjectExtra"
        Me.cmbObjectExtra.Size = New System.Drawing.Size(156, 21)
        Me.cmbObjectExtra.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbObjectExtra.TabIndex = 9
        '
        'cmbWhatO
        '
        Me.cmbWhatO.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbWhatO.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbWhatO.Location = New System.Drawing.Point(292, 8)
        Me.cmbWhatO.MaxDropDownItems = 12
        Me.cmbWhatO.Name = "cmbWhatO"
        Me.cmbWhatO.Size = New System.Drawing.Size(123, 21)
        Me.cmbWhatO.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbWhatO.TabIndex = 8
        '
        'cmbMustNotO
        '
        Me.cmbMustNotO.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbMustNotO.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "Must"
        ValueListItem1.DisplayText = "must"
        ValueListItem2.DataValue = "MustNot"
        ValueListItem2.DisplayText = "must not"
        Me.cmbMustNotO.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.cmbMustNotO.Location = New System.Drawing.Point(225, 8)
        Me.cmbMustNotO.Name = "cmbMustNotO"
        Me.cmbMustNotO.Size = New System.Drawing.Size(68, 21)
        Me.cmbMustNotO.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbMustNotO.TabIndex = 7
        '
        'cmbObject
        '
        Me.cmbObject.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbObject.Location = New System.Drawing.Point(8, 8)
        Me.cmbObject.Name = "cmbObject"
        Me.cmbObject.Size = New System.Drawing.Size(176, 21)
        Me.cmbObject.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbObject.TabIndex = 6
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.cmbCharacterExtra)
        Me.UltraTabPageControl4.Controls.Add(Me.cmbWhatC)
        Me.UltraTabPageControl4.Controls.Add(Me.cmbMustNotC)
        Me.UltraTabPageControl4.Controls.Add(Me.cmbCharacter)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(614, 38)
        '
        'cmbCharacterExtra
        '
        Me.cmbCharacterExtra.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbCharacterExtra.Location = New System.Drawing.Point(425, 8)
        Me.cmbCharacterExtra.Name = "cmbCharacterExtra"
        Me.cmbCharacterExtra.Size = New System.Drawing.Size(168, 21)
        Me.cmbCharacterExtra.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbCharacterExtra.TabIndex = 13
        '
        'cmbWhatC
        '
        Me.cmbWhatC.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbWhatC.Location = New System.Drawing.Point(232, 8)
        Me.cmbWhatC.MaxDropDownItems = 12
        Me.cmbWhatC.Name = "cmbWhatC"
        Me.cmbWhatC.Size = New System.Drawing.Size(151, 21)
        Me.cmbWhatC.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbWhatC.TabIndex = 12
        '
        'cmbMustNotC
        '
        Me.cmbMustNotC.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem5.DataValue = "Must"
        ValueListItem5.DisplayText = "must"
        ValueListItem6.DataValue = "MustNot"
        ValueListItem6.DisplayText = "must not"
        Me.cmbMustNotC.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem5, ValueListItem6})
        Me.cmbMustNotC.Location = New System.Drawing.Point(166, 8)
        Me.cmbMustNotC.Name = "cmbMustNotC"
        Me.cmbMustNotC.Size = New System.Drawing.Size(67, 21)
        Me.cmbMustNotC.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbMustNotC.TabIndex = 11
        '
        'cmbCharacter
        '
        Me.cmbCharacter.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbCharacter.Location = New System.Drawing.Point(8, 8)
        Me.cmbCharacter.Name = "cmbCharacter"
        Me.cmbCharacter.Size = New System.Drawing.Size(168, 21)
        Me.cmbCharacter.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbCharacter.TabIndex = 10
        '
        'UltraTabPageControl9
        '
        Me.UltraTabPageControl9.Controls.Add(Me.cmbItemExtra)
        Me.UltraTabPageControl9.Controls.Add(Me.cmbWhatI)
        Me.UltraTabPageControl9.Controls.Add(Me.cmbMustNotI)
        Me.UltraTabPageControl9.Controls.Add(Me.cmbItem)
        Me.UltraTabPageControl9.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl9.Name = "UltraTabPageControl9"
        Me.UltraTabPageControl9.Size = New System.Drawing.Size(614, 38)
        '
        'cmbItemExtra
        '
        Me.cmbItemExtra.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbItemExtra.Location = New System.Drawing.Point(372, 8)
        Me.cmbItemExtra.Name = "cmbItemExtra"
        Me.cmbItemExtra.Size = New System.Drawing.Size(156, 21)
        Me.cmbItemExtra.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbItemExtra.TabIndex = 13
        '
        'cmbWhatI
        '
        Me.cmbWhatI.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbWhatI.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbWhatI.Location = New System.Drawing.Point(292, 8)
        Me.cmbWhatI.MaxDropDownItems = 12
        Me.cmbWhatI.Name = "cmbWhatI"
        Me.cmbWhatI.Size = New System.Drawing.Size(123, 21)
        Me.cmbWhatI.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbWhatI.TabIndex = 12
        '
        'cmbMustNotI
        '
        Me.cmbMustNotI.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbMustNotI.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem18.DataValue = "Must"
        ValueListItem18.DisplayText = "must"
        ValueListItem19.DataValue = "MustNot"
        ValueListItem19.DisplayText = "must not"
        Me.cmbMustNotI.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem18, ValueListItem19})
        Me.cmbMustNotI.Location = New System.Drawing.Point(225, 8)
        Me.cmbMustNotI.Name = "cmbMustNotI"
        Me.cmbMustNotI.Size = New System.Drawing.Size(68, 21)
        Me.cmbMustNotI.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbMustNotI.TabIndex = 11
        '
        'cmbItem
        '
        Me.cmbItem.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbItem.Location = New System.Drawing.Point(8, 8)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(176, 21)
        Me.cmbItem.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbItem.TabIndex = 10
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.lblComplete)
        Me.UltraTabPageControl3.Controls.Add(Me.cmbMustNotT)
        Me.UltraTabPageControl3.Controls.Add(Me.cmbTask)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(614, 38)
        '
        'lblComplete
        '
        Me.lblComplete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblComplete.BackColor = System.Drawing.Color.Transparent
        Me.lblComplete.Location = New System.Drawing.Point(554, 12)
        Me.lblComplete.Name = "lblComplete"
        Me.lblComplete.Size = New System.Drawing.Size(56, 16)
        Me.lblComplete.TabIndex = 10
        Me.lblComplete.Text = "Complete"
        '
        'cmbMustNotT
        '
        Me.cmbMustNotT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMustNotT.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem20.DataValue = "Must"
        ValueListItem20.DisplayText = "must be"
        ValueListItem21.DataValue = "MustNot"
        ValueListItem21.DisplayText = "must not be"
        Me.cmbMustNotT.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem20, ValueListItem21})
        Me.cmbMustNotT.Location = New System.Drawing.Point(466, 8)
        Me.cmbMustNotT.Name = "cmbMustNotT"
        Me.cmbMustNotT.Size = New System.Drawing.Size(80, 21)
        Me.cmbMustNotT.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbMustNotT.TabIndex = 9
        '
        'cmbTask
        '
        Me.cmbTask.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTask.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbTask.Location = New System.Drawing.Point(8, 8)
        Me.cmbTask.Name = "cmbTask"
        Me.cmbTask.Size = New System.Drawing.Size(458, 21)
        Me.cmbTask.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbTask.TabIndex = 8
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.cmbVariable)
        Me.UltraTabPageControl5.Controls.Add(Me.cmbIndex)
        Me.UltraTabPageControl5.Controls.Add(Me.lblRight)
        Me.UltraTabPageControl5.Controls.Add(Me.lblLeft)
        Me.UltraTabPageControl5.Controls.Add(Me.cmbIndexEdit)
        Me.UltraTabPageControl5.Controls.Add(Me.isVariable)
        Me.UltraTabPageControl5.Controls.Add(Me.cmbWhatV)
        Me.UltraTabPageControl5.Controls.Add(Me.cmbMustNotV)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(614, 38)
        '
        'cmbVariable
        '
        Me.cmbVariable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbVariable.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbVariable.Location = New System.Drawing.Point(8, 8)
        Me.cmbVariable.Name = "cmbVariable"
        Me.cmbVariable.Size = New System.Drawing.Size(224, 21)
        Me.cmbVariable.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbVariable.TabIndex = 9
        '
        'cmbIndex
        '
        Me.cmbIndex.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbIndex.Location = New System.Drawing.Point(132, 8)
        Me.cmbIndex.Name = "cmbIndex"
        Me.cmbIndex.Size = New System.Drawing.Size(91, 21)
        Me.cmbIndex.TabIndex = 17
        Me.cmbIndex.Visible = False
        '
        'lblRight
        '
        Me.lblRight.AutoSize = True
        Me.lblRight.BackColor = System.Drawing.Color.Transparent
        Me.lblRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRight.Location = New System.Drawing.Point(222, 10)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(12, 16)
        Me.lblRight.TabIndex = 19
        Me.lblRight.Text = "]"
        Me.lblRight.Visible = False
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = True
        Me.lblLeft.BackColor = System.Drawing.Color.Transparent
        Me.lblLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeft.Location = New System.Drawing.Point(124, 10)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(12, 16)
        Me.lblLeft.TabIndex = 18
        Me.lblLeft.Text = "["
        Me.lblLeft.Visible = False
        '
        'cmbIndexEdit
        '
        Appearance1.TextHAlignAsString = "Right"
        Me.cmbIndexEdit.Appearance = Appearance1
        ValueListItem16.DataValue = "ValueListItem1"
        ValueListItem16.DisplayText = "Select a variable"
        Me.cmbIndexEdit.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem16})
        Me.cmbIndexEdit.Location = New System.Drawing.Point(107, 8)
        Me.cmbIndexEdit.Name = "cmbIndexEdit"
        Me.cmbIndexEdit.Size = New System.Drawing.Size(125, 21)
        Me.cmbIndexEdit.TabIndex = 16
        Me.cmbIndexEdit.Text = "0"
        Me.cmbIndexEdit.Visible = False
        '
        'isVariable
        '
        Me.isVariable.AllowAddEdit = True
        Me.isVariable.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Variable Or ADRIFT.ItemSelector.ItemEnum.Expression), ADRIFT.ItemSelector.ItemEnum)
        Me.isVariable.AllowHidden = False
        Me.isVariable.BackColor = System.Drawing.Color.Transparent
        Me.isVariable.Key = Nothing
        Me.isVariable.ListType = ADRIFT.ItemSelector.ItemEnum.Variable
        Me.isVariable.Location = New System.Drawing.Point(454, 8)
        Me.isVariable.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.isVariable.MinimumSize = New System.Drawing.Size(10, 21)
        Me.isVariable.Name = "isVariable"
        Me.isVariable.RestrictProperty = Nothing
        Me.isVariable.Size = New System.Drawing.Size(151, 21)
        Me.isVariable.TabIndex = 15
        '
        'cmbWhatV
        '
        Me.cmbWhatV.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbWhatV.Location = New System.Drawing.Point(312, 8)
        Me.cmbWhatV.MaxDropDownItems = 12
        Me.cmbWhatV.Name = "cmbWhatV"
        Me.cmbWhatV.Size = New System.Drawing.Size(140, 21)
        Me.cmbWhatV.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbWhatV.TabIndex = 14
        '
        'cmbMustNotV
        '
        Me.cmbMustNotV.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem7.DataValue = "Must"
        ValueListItem7.DisplayText = "must be"
        ValueListItem8.DataValue = "MustNot"
        ValueListItem8.DisplayText = "must not be"
        Me.cmbMustNotV.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem7, ValueListItem8})
        Me.cmbMustNotV.Location = New System.Drawing.Point(231, 8)
        Me.cmbMustNotV.Name = "cmbMustNotV"
        Me.cmbMustNotV.Size = New System.Drawing.Size(82, 21)
        Me.cmbMustNotV.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbMustNotV.TabIndex = 13
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.cmbPropEqual)
        Me.UltraTabPageControl6.Controls.Add(Me.cmbMustNotP)
        Me.UltraTabPageControl6.Controls.Add(Me.cmbPropertyValue)
        Me.UltraTabPageControl6.Controls.Add(Me.lblFor)
        Me.UltraTabPageControl6.Controls.Add(Me.cmbPropertyOb)
        Me.UltraTabPageControl6.Controls.Add(Me.cmbProperty)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(614, 38)
        '
        'cmbPropEqual
        '
        Me.cmbPropEqual.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbPropEqual.Location = New System.Drawing.Point(459, 8)
        Me.cmbPropEqual.MaxDropDownItems = 12
        Me.cmbPropEqual.Name = "cmbPropEqual"
        Me.cmbPropEqual.Size = New System.Drawing.Size(40, 21)
        Me.cmbPropEqual.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbPropEqual.TabIndex = 20
        Me.cmbPropEqual.Visible = False
        '
        'cmbMustNotP
        '
        Me.cmbMustNotP.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbMustNotP.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem39.DataValue = "Must"
        ValueListItem39.DisplayText = "must be"
        ValueListItem40.DataValue = "MustNot"
        ValueListItem40.DisplayText = "must not be"
        Me.cmbMustNotP.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem39, ValueListItem40})
        Me.cmbMustNotP.Location = New System.Drawing.Point(369, 8)
        Me.cmbMustNotP.Name = "cmbMustNotP"
        Me.cmbMustNotP.Size = New System.Drawing.Size(84, 21)
        Me.cmbMustNotP.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbMustNotP.TabIndex = 15
        '
        'cmbPropertyValue
        '
        Me.cmbPropertyValue.Location = New System.Drawing.Point(475, 8)
        Me.cmbPropertyValue.Name = "cmbPropertyValue"
        Me.cmbPropertyValue.PropertyKey = ""
        Me.cmbPropertyValue.Size = New System.Drawing.Size(134, 21)
        Me.cmbPropertyValue.TabIndex = 19
        Me.cmbPropertyValue.Value = Nothing
        '
        'lblFor
        '
        Me.lblFor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFor.BackColor = System.Drawing.Color.Transparent
        Me.lblFor.Location = New System.Drawing.Point(234, 12)
        Me.lblFor.Name = "lblFor"
        Me.lblFor.Size = New System.Drawing.Size(19, 16)
        Me.lblFor.TabIndex = 18
        Me.lblFor.Text = "for"
        '
        'cmbPropertyOb
        '
        Me.cmbPropertyOb.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbPropertyOb.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem24.DataValue = "Alone"
        ValueListItem24.DisplayText = "be alone"
        ValueListItem25.DataValue = "AtLocation"
        ValueListItem25.DisplayText = "be at location"
        ValueListItem26.DataValue = "HoldingObject"
        ValueListItem26.DisplayText = "be holding"
        ValueListItem27.DataValue = "WithinLocationGroup"
        ValueListItem27.DisplayText = "be in location group"
        ValueListItem28.DataValue = "InSameLocationAs"
        ValueListItem28.DisplayText = "be in same location as"
        ValueListItem29.DataValue = "LyingOnObject"
        ValueListItem29.DisplayText = "be lying on"
        ValueListItem30.DataValue = "MemberOfGroup"
        ValueListItem30.DisplayText = "be member of group"
        ValueListItem31.DataValue = "OfGender"
        ValueListItem31.DisplayText = "be of gender"
        ValueListItem32.DataValue = "SittingOnObject"
        ValueListItem32.DisplayText = "be sitting on"
        ValueListItem33.DataValue = "StandingOnObject"
        ValueListItem33.DisplayText = "be standing on"
        ValueListItem34.DataValue = "WearingObject"
        ValueListItem34.DisplayText = "be wearing"
        ValueListItem35.DataValue = "HaveRouteInDirection"
        ValueListItem35.DisplayText = "have route to"
        ValueListItem36.DataValue = "HaveSeenCharacter"
        ValueListItem36.DisplayText = "have seen character"
        ValueListItem37.DataValue = "HaveSeenLocation"
        ValueListItem37.DisplayText = "have seen location"
        ValueListItem38.DataValue = "HaveSeenObject"
        ValueListItem38.DisplayText = "have seen object"
        Me.cmbPropertyOb.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem24, ValueListItem25, ValueListItem26, ValueListItem27, ValueListItem28, ValueListItem29, ValueListItem30, ValueListItem31, ValueListItem32, ValueListItem33, ValueListItem34, ValueListItem35, ValueListItem36, ValueListItem37, ValueListItem38})
        Me.cmbPropertyOb.Location = New System.Drawing.Point(217, 8)
        Me.cmbPropertyOb.MaxDropDownItems = 12
        Me.cmbPropertyOb.Name = "cmbPropertyOb"
        Me.cmbPropertyOb.Size = New System.Drawing.Size(152, 21)
        Me.cmbPropertyOb.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbPropertyOb.TabIndex = 16
        '
        'cmbProperty
        '
        Me.cmbProperty.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbProperty.Location = New System.Drawing.Point(8, 8)
        Me.cmbProperty.Name = "cmbProperty"
        Me.cmbProperty.Size = New System.Drawing.Size(144, 21)
        Me.cmbProperty.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbProperty.TabIndex = 14
        '
        'UltraTabPageControl7
        '
        Me.UltraTabPageControl7.Controls.Add(Me.cmbDirection)
        Me.UltraTabPageControl7.Controls.Add(Me.lblBe)
        Me.UltraTabPageControl7.Controls.Add(Me.cmbMustNotD)
        Me.UltraTabPageControl7.Controls.Add(Me.lblReferencedDirection)
        Me.UltraTabPageControl7.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl7.Name = "UltraTabPageControl7"
        Me.UltraTabPageControl7.Size = New System.Drawing.Size(614, 38)
        '
        'cmbDirection
        '
        Me.cmbDirection.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbDirection.Location = New System.Drawing.Point(239, 8)
        Me.cmbDirection.Name = "cmbDirection"
        Me.cmbDirection.Size = New System.Drawing.Size(351, 21)
        Me.cmbDirection.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbDirection.TabIndex = 21
        '
        'lblBe
        '
        Me.lblBe.BackColor = System.Drawing.Color.Transparent
        Me.lblBe.Location = New System.Drawing.Point(215, 13)
        Me.lblBe.Name = "lblBe"
        Me.lblBe.Size = New System.Drawing.Size(29, 16)
        Me.lblBe.TabIndex = 20
        Me.lblBe.Text = "be"
        '
        'cmbMustNotD
        '
        Me.cmbMustNotD.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem22.DataValue = "Must"
        ValueListItem22.DisplayText = "must be"
        ValueListItem23.DataValue = "MustNot"
        ValueListItem23.DisplayText = "must not be"
        Me.cmbMustNotD.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem22, ValueListItem23})
        Me.cmbMustNotD.Location = New System.Drawing.Point(126, 9)
        Me.cmbMustNotD.Name = "cmbMustNotD"
        Me.cmbMustNotD.Size = New System.Drawing.Size(82, 21)
        Me.cmbMustNotD.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbMustNotD.TabIndex = 14
        '
        'lblReferencedDirection
        '
        Me.lblReferencedDirection.BackColor = System.Drawing.Color.Transparent
        Me.lblReferencedDirection.Location = New System.Drawing.Point(11, 13)
        Me.lblReferencedDirection.Name = "lblReferencedDirection"
        Me.lblReferencedDirection.Size = New System.Drawing.Size(129, 16)
        Me.lblReferencedDirection.TabIndex = 19
        Me.lblReferencedDirection.Text = "Referenced Direction"
        '
        'UltraTabPageControl8
        '
        Me.UltraTabPageControl8.Controls.Add(Me.Expression)
        Me.UltraTabPageControl8.Controls.Add(Me.Label1)
        Me.UltraTabPageControl8.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl8.Name = "UltraTabPageControl8"
        Me.UltraTabPageControl8.Size = New System.Drawing.Size(614, 38)
        '
        'Expression
        '
        Me.Expression.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Expression.BackColor = System.Drawing.Color.Transparent
        Me.Expression.Location = New System.Drawing.Point(132, 8)
        Me.Expression.Name = "Expression"
        Me.Expression.Size = New System.Drawing.Size(476, 21)
        Me.Expression.TabIndex = 21
        Me.Expression.Value = ""
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(11, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Expression to evaluate:"
        '
        'tabsRestrictions
        '
        Me.tabsRestrictions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabsRestrictions.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.tabsRestrictions.Controls.Add(Me.UltraTabPageControl1)
        Me.tabsRestrictions.Controls.Add(Me.UltraTabPageControl2)
        Me.tabsRestrictions.Controls.Add(Me.UltraTabPageControl3)
        Me.tabsRestrictions.Controls.Add(Me.UltraTabPageControl4)
        Me.tabsRestrictions.Controls.Add(Me.UltraTabPageControl5)
        Me.tabsRestrictions.Controls.Add(Me.UltraTabPageControl6)
        Me.tabsRestrictions.Controls.Add(Me.UltraTabPageControl7)
        Me.tabsRestrictions.Controls.Add(Me.UltraTabPageControl8)
        Me.tabsRestrictions.Controls.Add(Me.UltraTabPageControl9)
        Me.tabsRestrictions.Location = New System.Drawing.Point(0, 0)
        Me.tabsRestrictions.Name = "tabsRestrictions"
        Me.tabsRestrictions.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.tabsRestrictions.Size = New System.Drawing.Size(618, 64)
        Me.tabsRestrictions.TabIndex = 1
        Appearance8.Image = Global.ADRIFT.My.Resources.imgLocation16
        UltraTab1.Appearance = Appearance8
        UltraTab1.Key = "Location"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Location"
        Appearance2.Image = Global.ADRIFT.My.Resources.imgObjectDynamic16
        UltraTab2.Appearance = Appearance2
        UltraTab2.Key = "Object"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Object"
        Appearance4.Image = Global.ADRIFT.My.Resources.imgCharacter16
        UltraTab4.Appearance = Appearance4
        UltraTab4.Key = "Character"
        UltraTab4.TabPage = Me.UltraTabPageControl4
        UltraTab4.Text = "Character"
        Appearance10.Image = Global.ADRIFT.My.Resources.imgHelp16
        UltraTab9.Appearance = Appearance10
        UltraTab9.Key = "Item"
        UltraTab9.TabPage = Me.UltraTabPageControl9
        UltraTab9.Text = "Item"
        UltraTab9.Visible = False
        Appearance3.Image = Global.ADRIFT.My.Resources.imgTaskSpecific16
        UltraTab3.Appearance = Appearance3
        UltraTab3.Key = "Task"
        UltraTab3.TabPage = Me.UltraTabPageControl3
        UltraTab3.Text = "Task"
        Appearance5.Image = Global.ADRIFT.My.Resources.imgVariable16
        UltraTab5.Appearance = Appearance5
        UltraTab5.Key = "Variable"
        UltraTab5.TabPage = Me.UltraTabPageControl5
        UltraTab5.Text = "Variable"
        Appearance6.Image = Global.ADRIFT.My.Resources.imgProperty16
        UltraTab6.Appearance = Appearance6
        UltraTab6.Key = "Property"
        UltraTab6.TabPage = Me.UltraTabPageControl6
        UltraTab6.Text = "Property"
        Appearance7.Image = Global.ADRIFT.My.Resources.imgChildren
        UltraTab7.Appearance = Appearance7
        UltraTab7.Key = "Direction"
        UltraTab7.TabPage = Me.UltraTabPageControl7
        UltraTab7.Text = "Direction"
        Appearance9.Image = Global.ADRIFT.My.Resources.imgExpression
        UltraTab8.Appearance = Appearance9
        UltraTab8.Key = "Expression"
        UltraTab8.TabPage = Me.UltraTabPageControl8
        UltraTab8.Text = "Expression"
        Me.tabsRestrictions.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab4, UltraTab9, UltraTab3, UltraTab5, UltraTab6, UltraTab7, UltraTab8})
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(614, 38)
        '
        'lblElse
        '
        Me.lblElse.Location = New System.Drawing.Point(8, 70)
        Me.lblElse.Name = "lblElse"
        Me.lblElse.Size = New System.Drawing.Size(408, 23)
        Me.lblElse.TabIndex = 3
        Me.lblElse.Text = "The restriction above must be passed, otherwise the following will be displayed:"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(426, 215)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(522, 215)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        '
        'txtMessage
        '
        Me.txtMessage.AllowAlternateDescriptions = True
        Me.txtMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessage.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtMessage.FirstTabHasRestrictions = False
        Me.txtMessage.Location = New System.Drawing.Point(8, 88)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.sCommand = Nothing
        Me.txtMessage.Size = New System.Drawing.Size(602, 119)
        Me.txtMessage.TabIndex = 2
        '
        'frmRestriction
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(618, 257)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.lblElse)
        Me.Controls.Add(Me.tabsRestrictions)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(400, 232)
        Me.Name = "frmRestriction"
        Me.Text = "Restriction"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.cmbWhatL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLocationExtra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMustNotL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.cmbObjectExtra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbWhatO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMustNotO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbObject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.UltraTabPageControl4.PerformLayout()
        CType(Me.cmbCharacterExtra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbWhatC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMustNotC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCharacter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl9.ResumeLayout(False)
        Me.UltraTabPageControl9.PerformLayout()
        CType(Me.cmbItemExtra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbWhatI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMustNotI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        CType(Me.cmbMustNotT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl5.ResumeLayout(False)
        Me.UltraTabPageControl5.PerformLayout()
        CType(Me.cmbVariable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIndex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIndexEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbWhatV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMustNotV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl6.ResumeLayout(False)
        Me.UltraTabPageControl6.PerformLayout()
        CType(Me.cmbPropEqual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMustNotP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPropertyOb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbProperty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl7.ResumeLayout(False)
        Me.UltraTabPageControl7.PerformLayout()
        CType(Me.cmbDirection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMustNotD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl8.ResumeLayout(False)
        CType(Me.tabsRestrictions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsRestrictions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Restriction As clsRestriction
    Public sCommand As String ' To calc refs from
    Friend Property Arguments As List(Of clsUserFunction.Argument)
    Private bLoadingRestriction As Boolean


    Private arlDirectionRefs As New StringArrayList
    Private arlObjectRefs As New StringArrayList
    Private arlCharacterRefs As New StringArrayList
    Private arlNumericRefs As New StringArrayList
    Private arlTextRefs As New StringArrayList
    Private arlLocationRefs As New StringArrayList
    Private arlItemRefs As New StringArrayList


    Private Sub frmRestriction_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is AutoCompleteCombo Then ctrl.Visible = False
        Next

        cmbLocation.Width = Me.cmbMustNotL.Left - cmbLocation.Left + 1
        cmbLocationExtra.Left = Me.cmbWhatL.Left + Me.cmbWhatL.Width - 1
        cmbLocationExtra.Width = Me.Width - Me.cmbWhatL.Left - 147

        cmbObject.Width = Me.cmbMustNotO.Left - cmbObject.Left + 1
        cmbObjectExtra.Left = Me.cmbWhatO.Left + Me.cmbWhatO.Width - 1
        cmbObjectExtra.Width = Me.Width - Me.cmbWhatO.Left - 146

        cmbItem.Width = Me.cmbMustNotI.Left - cmbItem.Left + 1
        cmbItemExtra.Left = Me.cmbWhatI.Left + Me.cmbWhatI.Width - 1
        cmbItemExtra.Width = Me.Width - Me.cmbWhatI.Left - 146

        cmbMustNotT.Left = cmbTask.Left + cmbTask.Width - 1

        cmbMustNotC.Left = CInt((Me.Width - (cmbMustNotC.Width + cmbWhatC.Width)) / 2)
        cmbWhatC.Left = cmbMustNotC.Left + cmbMustNotC.Width - 1 'cmbWhatC.Left + cmbWhatC.Width - 1
        cmbCharacter.Width = cmbMustNotC.Left - 7 ' Me.cmbMustNotC.Left - cmbCharacter.Left
        cmbCharacterExtra.Left = cmbWhatC.Left + cmbWhatC.Width - 1
        cmbCharacterExtra.Width = Me.Width - cmbCharacterExtra.Left - 25 ' Me.cmbWhatC.Left - 162

        If cmbPropEqual.Visible Then
            cmbProperty.Width = CInt(Width / 4)
            lblFor.Left = cmbProperty.Left + cmbProperty.Width + 3
            cmbPropertyOb.Left = cmbProperty.Left + cmbProperty.Width + 24
            cmbPropertyOb.Width = CInt(Width / 4) - 60
            cmbMustNotP.Left = cmbPropertyOb.Left + cmbPropertyOb.Width - 1
            cmbPropEqual.Left = cmbMustNotP.Left + cmbMustNotP.Width - 1
            cmbPropertyValue.Left = cmbPropEqual.Left + cmbPropEqual.Width - 1
            cmbPropertyValue.Width = Width - cmbPropertyValue.Left - 24 ' CInt(Width / 3) - 78
        Else
            cmbProperty.Width = CInt(Width / 3)
            lblFor.Left = cmbProperty.Left + cmbProperty.Width + 3
            cmbPropertyOb.Left = cmbProperty.Left + cmbProperty.Width + 24
            cmbPropertyOb.Width = CInt(Width / 3) - 60
            cmbMustNotP.Left = cmbPropertyOb.Left + cmbPropertyOb.Width - 1
            cmbPropertyValue.Left = cmbMustNotP.Left + cmbMustNotP.Width - 1
            cmbPropertyValue.Width = Width - cmbPropertyValue.Left - 24 ' CInt(Width / 3) - 78
        End If

        cmbVariable_SelectionChanged(Nothing, Nothing)
        'cmbVariable.Width = Me.cmbMustNotV.Left - cmbVariable.Left + 1
        isVariable.Width = Me.Width - (cmbWhatV.Left + cmbWhatV.Width) - 25

        cmbDirection.Width = Me.Width - cmbDirection.Left - 24

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is AutoCompleteCombo Then ctrl.Visible = True
        Next

    End Sub


    Public Sub LoadRestriction(ByVal Restriction As clsRestriction)

        bLoadingRestriction = True
        'txtMessage.RestrictSummary.sCommand = Me.sCommand
        txtMessage.sCommand = Me.sCommand
        txtMessage.Arguments = Me.Arguments
        LoadCombos()

        Me.Restriction = Restriction
        txtMessage.Description = Restriction.oMessage

        If Restriction.StringValue = "*NEW*" Then
            Restriction.StringValue = ""
            bLoadingRestriction = False
            isVariable.ListType = ItemSelector.ItemEnum.Variable
            'With Restriction
            '    If .IntValue = Integer.MinValue Then
            '        isVariable.ListType = ItemSelector.ItemEnum.Variable                    
            '    Else
            '        isVariable.ListType = ItemSelector.ItemEnum.Expression                    
            '    End If
            'End With
            Exit Sub ' To prevent loading some combos and making it look messy
        End If

        With Restriction
            Select Case .eType
                Case clsRestriction.RestrictionTypeEnum.Location
                    tabsRestrictions.SelectedTab = tabsRestrictions.Tabs("Location")
                    SetCombo(cmbLocation, .sKey1)
                    SetCombo(cmbMustNotL, WriteEnum(.eMust))
                    SetCombo(cmbWhatL, WriteEnum(.eLocation))
                    SetCombo(cmbLocationExtra, .sKey2)

                Case clsRestriction.RestrictionTypeEnum.Object
                    tabsRestrictions.SelectedTab = tabsRestrictions.Tabs("Object")
                    SetCombo(cmbObject, .sKey1)
                    SetCombo(cmbMustNotO, WriteEnum(.eMust))
                    SetCombo(cmbWhatO, WriteEnum(.eObject))
                    SetCombo(cmbObjectExtra, .sKey2)

                Case clsRestriction.RestrictionTypeEnum.Task
                    tabsRestrictions.SelectedTab = tabsRestrictions.Tabs("Task")
                    SetCombo(cmbTask, .sKey1)
                    SetCombo(cmbMustNotT, WriteEnum(.eMust))

                Case clsRestriction.RestrictionTypeEnum.Character
                    tabsRestrictions.SelectedTab = tabsRestrictions.Tabs("Character")
                    SetCombo(cmbCharacter, .sKey1)
                    SetCombo(cmbMustNotC, WriteEnum(.eMust))
                    SetCombo(cmbWhatC, WriteEnum(.eCharacter))
                    'If .eCharacter = clsRestriction.CharacterEnum.BeOfGender OrElse .eCharacter = clsRestriction.CharacterEnum.HaveRouteInDirection Then
                    'SetCombo(cmbCharacterExtra, .IntValue)
                    'Else
                    SetCombo(cmbCharacterExtra, .sKey2)
                    'End If

                Case clsRestriction.RestrictionTypeEnum.Item
                    tabsRestrictions.SelectedTab = tabsRestrictions.Tabs("Item")
                    SetCombo(cmbItem, .sKey1)
                    SetCombo(cmbMustNotI, WriteEnum(.eMust))
                    SetCombo(cmbWhatI, WriteEnum(.eItem))
                    SetCombo(cmbItemExtra, .sKey2)

                Case clsRestriction.RestrictionTypeEnum.Variable
                    tabsRestrictions.SelectedTab = tabsRestrictions.Tabs("Variable")
                    SetCombo(cmbVariable, .sKey1)
                    If .sKey2 <> "" AndAlso Not Adventure.htblVariables.ContainsKey(.sKey2) Then
                        ' See if our expression resolves to a variable name
                        For Each v As clsVariable In Adventure.htblVariables.Values
                            If .sKey2 = "%" & v.Name & "%" Then
                                .sKey2 = v.Key
                                Exit For
                            End If
                        Next
                    End If
                    If .sKey2 IsNot Nothing AndAlso Adventure.htblVariables.ContainsKey(.sKey2) Then
                        ' Simply selected a variable
                        SetCombo(cmbIndex, .sKey2)
                        cmbIndexEdit.Visible = False
                    Else
                        ' Index contains an expression
                        cmbIndexEdit.Visible = True
                        cmbIndexEdit.Text = .sKey2
                        cmbIndex.Visible = False
                    End If
                    SetCombo(cmbMustNotV, WriteEnum(.eMust))
                    SetCombo(cmbWhatV, WriteEnum(.eVariable))
                    If .IntValue = Integer.MinValue Then
                        isVariable.ListType = ItemSelector.ItemEnum.Variable
                        If Adventure.htblVariables.ContainsKey(.StringValue) Then isVariable.Key = .StringValue
                    Else
                        isVariable.ListType = ItemSelector.ItemEnum.Expression
                        If .IntValue <> 0 Then
                            isVariable.Expression.Value = .IntValue.ToString
                        Else
                            isVariable.Expression.Value = .StringValue
                        End If
                    End If

                Case clsRestriction.RestrictionTypeEnum.Property
                    tabsRestrictions.SelectedTab = tabsRestrictions.Tabs("Property")
                    SetCombo(cmbProperty, .sKey1)
                    SetCombo(cmbPropertyOb, .sKey2)
                    SetCombo(cmbMustNotP, WriteEnum(.eMust))
                    SetCombo(cmbPropEqual, .IntValue) ' cmbPropEqual.SelectedIndex = .IntValue
                    cmbPropertyValue.Value = .StringValue

                Case clsRestriction.RestrictionTypeEnum.Direction
                    tabsRestrictions.SelectedTab = tabsRestrictions.Tabs("Direction")
                    SetCombo(cmbMustNotD, WriteEnum(.eMust))
                    SetCombo(cmbDirection, .sKey1)

                Case clsRestriction.RestrictionTypeEnum.Expression
                    tabsRestrictions.SelectedTab = tabsRestrictions.Tabs("Expression")
                    Expression.Value = .StringValue

            End Select
        End With

        bLoadingRestriction = False

    End Sub


    Private Sub LoadCombos()

        arlDirectionRefs = GetReferences(ReferencesType.Direction, Me.sCommand)
        arlObjectRefs = GetReferences(ReferencesType.Object, Me.sCommand, Me.Arguments)
        arlCharacterRefs = GetReferences(ReferencesType.Character, Me.sCommand, Me.Arguments)
        arlNumericRefs = GetReferences(ReferencesType.Number, Me.sCommand, Me.Arguments)
        arlTextRefs = GetReferences(ReferencesType.Text, Me.sCommand, Me.Arguments)
        arlLocationRefs = GetReferences(ReferencesType.Location, Me.sCommand, Me.Arguments)
        arlItemRefs = GetReferences(ReferencesType.Item, Me.sCommand)

        cmbLocation.Items.Clear()
        cmbLocation.Items.Add(PLAYERLOCATION, "[ The Player's Location ]")
        For Each l As String In arlLocationRefs
            cmbLocation.Items.Add(l, Adventure.GetNameFromKey(l, False))
        Next
        For Each loc As clsLocation In Adventure.htblLocations.Values
            cmbLocation.Items.Add(loc.Key, loc.ShortDescription.ToString)
        Next

        cmbObject.Items.Clear()
        cmbObject.Items.Add(ANYOBJECT, "[ Any Object ]")
        cmbObject.Items.Add(NOOBJECT, "[ No Object ]")
        For Each o As String In arlObjectRefs
            cmbObject.Items.Add(o, Adventure.GetNameFromKey(o, False))
        Next
        For Each ob As clsObject In Adventure.htblObjects.Values
            cmbObject.Items.Add(ob.Key, ob.FullName)
        Next

        cmbTask.Items.Clear()
        For Each tas As clsTask In Adventure.htblTasks.Values
            cmbTask.Items.Add(tas.Key, tas.Description)
        Next

        cmbCharacter.Items.Clear()
        cmbCharacter.Items.Add(ANYCHARACTER, "[ Any Character ]")
        cmbCharacter.Items.Add(THEPLAYER, "[ The Player Character ]")
        For Each d As String In arlCharacterRefs
            cmbCharacter.Items.Add(d, Adventure.GetNameFromKey(d, False))
        Next
        For Each ch As clsCharacter In Adventure.htblCharacters.Values
            cmbCharacter.Items.Add(ch.Key, ch.Name)
        Next

        cmbItem.Items.Clear()
        cmbItem.Items.Add(ANYCHARACTER, "[ Any Item ]")        
        For Each i As String In arlItemRefs
            cmbItem.Items.Add(i, Adventure.GetNameFromKey(i, False))
        Next

        cmbVariable.Items.Clear()
        cmbIndex.Items.Clear()
        cmbIndex.Items.Add("<Enter own value>")
        For Each v As String In arlNumericRefs            
            cmbVariable.Items.Add(v, Adventure.GetNameFromKey(v, False))         
        Next
        For Each v As String In arlTextRefs
            cmbVariable.Items.Add(v, Adventure.GetNameFromKey(v, False))
        Next
        For Each var As clsVariable In Adventure.htblVariables.Values
            cmbVariable.Items.Add(var.Key, var.Name)
            If var.Length < 2 AndAlso var.Type = clsVariable.VariableTypeEnum.Numeric Then cmbIndex.Items.Add(var.Key, var.Name)            
        Next

        cmbPropertyValue.Command = Me.sCommand
        cmbProperty.Items.Clear()
        For Each prop As clsProperty In Adventure.htblAllProperties.Values
            If prop.Type <> clsProperty.PropertyTypeEnum.SelectionOnly AndAlso Not (prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.AppendToProperty <> "") Then
                cmbProperty.Items.Add(prop.Key, prop.Description)
            End If
        Next

        With cmbWhatL
            .Items.Add(clsRestriction.LocationEnum.BeInGroup.ToString, "be in group")
            .Items.Add(clsRestriction.LocationEnum.HaveBeenSeenByCharacter.ToString, "have been seen by")
            .Items.Add(clsRestriction.LocationEnum.HaveProperty.ToString, "have property")
            .Items.Add(clsRestriction.LocationEnum.BeLocation.ToString, "be location")
            .Items.Add(clsRestriction.LocationEnum.Exist.ToString, "exist")
        End With

        With cmbWhatO
            .Items.Add(clsRestriction.ObjectEnum.BeAtLocation.ToString, "be at location")
            '.Items.Add(clsRestriction.ObjectEnum.BeExactText, "")
            .Items.Add(clsRestriction.ObjectEnum.BeHeldByCharacter.ToString, "be held by")
            .Items.Add(clsRestriction.ObjectEnum.BeHidden.ToString, "be hidden")
            .Items.Add(clsRestriction.ObjectEnum.BeInGroup.ToString, "be within group")
            .Items.Add(clsRestriction.ObjectEnum.BeInsideObject.ToString, "be inside object")
            .Items.Add(clsRestriction.ObjectEnum.BeInState.ToString, "be in state")
            .Items.Add(clsRestriction.ObjectEnum.BeOnObject.ToString, "be on object")
            .Items.Add(clsRestriction.ObjectEnum.BePartOfCharacter.ToString, "be part of character")
            .Items.Add(clsRestriction.ObjectEnum.BePartOfObject.ToString, "be part of object")
            .Items.Add(clsRestriction.ObjectEnum.BeVisibleToCharacter.ToString, "be visible to")
            .Items.Add(clsRestriction.ObjectEnum.BeWornByCharacter.ToString, "be worn by")
            .Items.Add(clsRestriction.ObjectEnum.Exist.ToString, "exist")
            .Items.Add(clsRestriction.ObjectEnum.HaveBeenSeenByCharacter.ToString, "have been seen by")
            .Items.Add(clsRestriction.ObjectEnum.HaveProperty.ToString, "have property")
            .Items.Add(clsRestriction.ObjectEnum.BeObject.ToString, "be object")
        End With

        With cmbWhatC
            .Items.Add(clsRestriction.CharacterEnum.BeAlone.ToString, "be alone")
            .Items.Add(clsRestriction.CharacterEnum.BeAloneWith.ToString, "be alone with")
            .Items.Add(clsRestriction.CharacterEnum.BeAtLocation.ToString, "be at location")
            .Items.Add(clsRestriction.CharacterEnum.BeCharacter.ToString, "be character")
            .Items.Add(clsRestriction.CharacterEnum.BeInConversationWith.ToString, "be in conversation with")
            .Items.Add(clsRestriction.CharacterEnum.BeHoldingObject.ToString, "be holding")
            .Items.Add(clsRestriction.CharacterEnum.BeWithinLocationGroup.ToString, "be in location group")
            .Items.Add(clsRestriction.CharacterEnum.BeInSameLocationAsCharacter.ToString, "be same loc as character")
            .Items.Add(clsRestriction.CharacterEnum.BeVisibleToCharacter.ToString, "be visible to")
            .Items.Add(clsRestriction.CharacterEnum.BeInSameLocationAsObject.ToString, "be same loc as object")
            .Items.Add(clsRestriction.CharacterEnum.BeLyingOnObject.ToString, "be lying on")
            .Items.Add(clsRestriction.CharacterEnum.BeInGroup.ToString, "be member of group")
            .Items.Add(clsRestriction.CharacterEnum.BeOfGender.ToString, "be of gender")
            .Items.Add(clsRestriction.CharacterEnum.BeSittingOnObject.ToString, "be sitting on")
            .Items.Add(clsRestriction.CharacterEnum.BeStandingOnObject.ToString, "be standing on")
            .Items.Add(clsRestriction.CharacterEnum.BeWearingObject.ToString, "be wearing")
            .Items.Add(clsRestriction.CharacterEnum.HaveRouteInDirection.ToString, "have route to")
            .Items.Add(clsRestriction.CharacterEnum.HaveSeenCharacter.ToString, "have seen character")
            .Items.Add(clsRestriction.CharacterEnum.HaveSeenLocation.ToString, "have seen location")
            .Items.Add(clsRestriction.CharacterEnum.HaveSeenObject.ToString, "have seen object")
            .Items.Add(clsRestriction.CharacterEnum.HaveProperty.ToString, "have property")
            .Items.Add(clsRestriction.CharacterEnum.BeOnObject.ToString, "be on object")
            .Items.Add(clsRestriction.CharacterEnum.BeInsideObject.ToString, "be inside object")
            .Items.Add(clsRestriction.CharacterEnum.BeInPosition.ToString, "be in position")
            .Items.Add(clsRestriction.CharacterEnum.BeOnCharacter.ToString, "be on character")
            .Items.Add(clsRestriction.CharacterEnum.Exist.ToString, "exist")
        End With

        With cmbWhatI
            .Items.Add(clsRestriction.ItemEnum.BeAtLocation.ToString, "be at location")
            .Items.Add(clsRestriction.ItemEnum.BeCharacter.ToString, "be character")
            .Items.Add(clsRestriction.ItemEnum.BeInSameLocationAsCharacter.ToString, "be same loc as character")
            .Items.Add(clsRestriction.ItemEnum.BeInSameLocationAsObject.ToString, "be same loc as object")
            .Items.Add(clsRestriction.ItemEnum.BeInsideObject.ToString, "be inside object")
            .Items.Add(clsRestriction.ItemEnum.BeLocation.ToString, "be location")
            .Items.Add(clsRestriction.ItemEnum.BeInGroup.ToString, "be member of group")
            .Items.Add(clsRestriction.ItemEnum.BeObject.ToString, "be object")
            .Items.Add(clsRestriction.ItemEnum.BeOnCharacter.ToString, "be on character")
            .Items.Add(clsRestriction.ItemEnum.BeOnObject.ToString, "be on object")
            .Items.Add(clsRestriction.ItemEnum.BeType.ToString, "be item type")
            .Items.Add(clsRestriction.ItemEnum.Exist.ToString, "exist")
            .Items.Add(clsRestriction.ItemEnum.HaveProperty.ToString, "have property")
        End With

        With cmbWhatV
            .Items.Add(clsRestriction.VariableEnum.LessThan.ToString, "less than")
            .Items.Add(clsRestriction.VariableEnum.LessThanOrEqualTo.ToString, "less than or equal to")
            .Items.Add(clsRestriction.VariableEnum.EqualTo.ToString, "equal to")
            .Items.Add(clsRestriction.VariableEnum.GreaterThanOrEqualTo.ToString, "greater than or equal to")
            .Items.Add(clsRestriction.VariableEnum.GreaterThan.ToString, "greater than")
            '.Items.Add(clsRestriction.VariableEnum.NotEqualTo.ToString, "not equal to")
        End With

        With cmbPropEqual
            .Items.Add(clsRestriction.VariableEnum.LessThan, "<")
            .Items.Add(clsRestriction.VariableEnum.LessThanOrEqualTo, "<=")
            .Items.Add(clsRestriction.VariableEnum.EqualTo, "=")
            .Items.Add(clsRestriction.VariableEnum.GreaterThanOrEqualTo, ">=")
            .Items.Add(clsRestriction.VariableEnum.GreaterThan, ">")
        End With

        tabsRestrictions.Tabs("Item").Visible = arlItemRefs.Count > 0
        tabsRestrictions.Tabs("Direction").Visible = arlDirectionRefs.Count > 0
        With cmbDirection
            .SortStyle = Infragistics.Win.ValueListSortStyle.None
            For Each d As DirectionsEnum In [Enum].GetValues(GetType(DirectionsEnum))
                .Items.Add(d.ToString, DirectionName(d))
            Next
        End With

    End Sub


    Private Sub cmbWhatL_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWhatL.ValueChanged

        If cmbWhatL.SelectedItem IsNot Nothing Then
            With cmbLocationExtra

                .Items.Clear()
                .SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
                .Enabled = True

                Select Case cmbWhatL.SelectedItem.DataValue.ToString
                    Case clsRestriction.LocationEnum.HaveBeenSeenByCharacter.ToString
                        .Items.Add(THEPLAYER, "[ The Player Character ]")
                        .Items.Add(ANYCHARACTER, "[ Any Character ]")
                        For Each c As String In arlCharacterRefs
                            .Items.Add(c, Adventure.GetNameFromKey(c, False))
                        Next
                        For Each chr As clsCharacter In Adventure.htblCharacters.Values
                            .Items.Add(chr.Key, chr.Name)
                        Next
                    Case clsRestriction.LocationEnum.BeInGroup.ToString
                        For Each g As clsGroup In Adventure.htblGroups.Values
                            If g.GroupType = clsGroup.GroupTypeEnum.Locations Then
                                .Items.Add(g.Key, g.Name)
                            End If
                        Next
                    Case clsRestriction.LocationEnum.HaveProperty.ToString
                        For Each p As clsProperty In Adventure.htblLocationProperties.Values
                            .Items.Add(p.Key, p.Description)
                        Next
                    Case clsRestriction.LocationEnum.BeLocation.ToString
                        For Each l As clsLocation In Adventure.htblLocations.Values
                            .Items.Add(l.Key, l.ShortDescription.ToString)
                        Next
                    Case clsRestriction.LocationEnum.Exist.ToString
                        .Enabled = False
                    Case Else
                        TODO("Location option " & cmbWhatL.SelectedItem.DataValue.ToString)
                End Select

            End With
        End If

    End Sub

    Private Sub cmbWhatI_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWhatI.ValueChanged

        With cmbItemExtra
            .Items.Clear()
            .SortStyle = Infragistics.Win.ValueListSortStyle.Ascending

            Select Case cmbWhatI.SelectedItem.DataValue.ToString
                Case clsRestriction.ItemEnum.BeAtLocation.ToString, clsRestriction.ItemEnum.BeLocation.ToString
                    For Each l As String In arlLocationRefs
                        .Items.Add(l, Adventure.GetNameFromKey(l, False))
                    Next
                    For Each loc As clsLocation In Adventure.htblLocations.Values
                        .Items.Add(loc.Key, loc.ShortDescription.ToString)
                    Next
                Case clsRestriction.ItemEnum.BeCharacter.ToString, clsRestriction.ItemEnum.BeInSameLocationAsCharacter.ToString, clsRestriction.ItemEnum.BeOnCharacter.ToString
                    .Items.Add(THEPLAYER, "[ The Player Character ]")
                    .Items.Add(ANYCHARACTER, "[ Any Character ]")
                    For Each c As String In arlCharacterRefs
                        .Items.Add(c, Adventure.GetNameFromKey(c, False))
                    Next
                    For Each chr As clsCharacter In Adventure.htblCharacters.Values
                        .Items.Add(chr.Key, chr.Name)
                    Next
                Case clsRestriction.ItemEnum.BeInGroup.ToString
                    For Each grp As clsGroup In Adventure.htblGroups.Values
                        .Items.Add(grp.Key, grp.Name)                        
                    Next
                Case clsRestriction.ItemEnum.BeInSameLocationAsObject.ToString, clsRestriction.ItemEnum.BeObject.ToString
                    .Items.Add(ANYOBJECT, "[ Any Object ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        .Items.Add(ob.Key, ob.FullName)
                    Next
                Case clsRestriction.ItemEnum.BeOnObject.ToString
                    .Items.Add(ANYOBJECT, "[ Any Object ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsStandable Then
                            .Items.Add(ob.Key, ob.FullName)
                        End If
                    Next
                Case clsRestriction.ItemEnum.BeInsideObject.ToString
                    .Items.Add(ANYOBJECT, "[ Any Object ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsContainer Then
                            .Items.Add(ob.Key, ob.FullName)
                        End If
                    Next
                Case clsRestriction.ItemEnum.BeType.ToString
                    .Items.Add("Character", "Character")
                    .Items.Add("Location", "Location")
                    .Items.Add("Object", "Object")
                Case clsRestriction.ItemEnum.Exist.ToString
                Case clsRestriction.ItemEnum.HaveProperty.ToString
                    For Each p As clsProperty In Adventure.htblAllProperties.Values
                        If p.PropertyOf = clsProperty.PropertyOfEnum.AnyItem Then .Items.Add(p.Key, p.Description)
                    Next
            End Select
        End With
    End Sub

    Private Sub cmbWhatC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWhatC.ValueChanged

        With cmbCharacterExtra

            .Items.Clear()
            .SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
            .Enabled = True

            Select Case cmbWhatC.SelectedItem.DataValue.ToString
                Case clsRestriction.CharacterEnum.BeInSameLocationAsCharacter.ToString, clsRestriction.CharacterEnum.HaveSeenCharacter.ToString, clsRestriction.CharacterEnum.BeInConversationWith.ToString, clsRestriction.CharacterEnum.BeOnCharacter.ToString, clsRestriction.CharacterEnum.BeAloneWith.ToString, clsRestriction.CharacterEnum.BeCharacter.ToString, clsRestriction.CharacterEnum.BeVisibleToCharacter.ToString
                    If cmbCharacter.SelectedItem IsNot Nothing AndAlso cmbCharacter.SelectedItem.DataValue.ToString <> THEPLAYER Then
                        .Items.Add(THEPLAYER, "[ The Player Character ]")
                    End If
                    .Items.Add(ANYCHARACTER, "[ Any Character ]")
                    For Each c As String In arlCharacterRefs
                        .Items.Add(c, Adventure.GetNameFromKey(c, False))
                    Next
                    For Each chr As clsCharacter In Adventure.htblCharacters.Values
                        .Items.Add(chr.Key, chr.Name)
                    Next
                Case clsRestriction.CharacterEnum.BeInSameLocationAsObject.ToString
                    ' Objects
                    .Items.Add(ANYOBJECT, "[ Any Object ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        .Items.Add(ob.Key, ob.FullName)
                    Next
                    ' Object Groups
                    For Each grp As clsGroup In Adventure.htblGroups.Values
                        If grp.GroupType = clsGroup.GroupTypeEnum.Objects Then .Items.Add(grp.Key, grp.Name)
                    Next
                Case clsRestriction.CharacterEnum.BeAlone.ToString, clsRestriction.CharacterEnum.Exist.ToString
                    ' Nothing to do
                    .Enabled = False

                Case clsRestriction.CharacterEnum.BeStandingOnObject.ToString
                    .Items.Add(ANYOBJECT, "[ Any Object ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsStandable Then
                            .Items.Add(ob.Key, ob.FullName)
                        End If
                    Next
                Case clsRestriction.CharacterEnum.BeSittingOnObject.ToString
                    .Items.Add(ANYOBJECT, "[ Any Object ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsSittable Then
                            .Items.Add(ob.Key, ob.FullName)
                        End If
                    Next

                Case clsRestriction.CharacterEnum.BeInPosition.ToString
                    If Adventure.htblCharacterProperties.ContainsKey("CharacterPosition") Then
                        For Each sPosition As String In Adventure.htblCharacterProperties("CharacterPosition").PossibleValues
                            .Items.Add(sPosition, sPosition)
                        Next
                    End If

                Case clsRestriction.CharacterEnum.BeInsideObject.ToString
                    .Items.Add(ANYOBJECT, "[ Any Object ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsContainer Then .Items.Add(ob.Key, ob.FullName)
                    Next

                Case clsRestriction.CharacterEnum.BeOnObject.ToString
                    .Items.Add(ANYOBJECT, "[ Any Object ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.HasSurface Then .Items.Add(ob.Key, ob.FullName)
                    Next

                Case clsRestriction.CharacterEnum.BeLyingOnObject.ToString
                    .Items.Add(ANYOBJECT, "[ Any Object ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsLieable Then
                            .Items.Add(ob.Key, ob.FullName)
                        End If
                    Next
                Case clsRestriction.CharacterEnum.BeHoldingObject.ToString
                    .Items.Add(ANYOBJECT, "[ Any Object ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If Not ob.IsStatic Then
                            .Items.Add(ob.Key, ob.FullName)
                        End If
                    Next
                Case clsRestriction.CharacterEnum.BeWearingObject.ToString
                    .Items.Add(ANYOBJECT, "[ Any Object ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsWearable Then
                            .Items.Add(ob.Key, ob.FullName)
                        End If
                    Next
                Case clsRestriction.CharacterEnum.HaveSeenObject.ToString
                    .Items.Add(ANYOBJECT, "[ Any Object ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        .Items.Add(ob.Key, ob.FullName)
                    Next
                Case clsRestriction.CharacterEnum.BeOfGender.ToString
                    For g As clsCharacter.GenderEnum = clsCharacter.GenderEnum.Male To clsCharacter.GenderEnum.Unknown
                        .Items.Add(g.ToString, g.ToString)
                    Next
                Case clsRestriction.CharacterEnum.HaveRouteInDirection.ToString
                    .SortStyle = Infragistics.Win.ValueListSortStyle.None
                    .Items.Add(ANYDIRECTION, "[ Any Direction ]")
                    For Each d As String In arlDirectionRefs
                        .Items.Add(d, Adventure.GetNameFromKey(d, False))
                    Next                    
                    For d As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest
                        .Items.Add(d.ToString, DirectionName(d))
                    Next
                Case clsRestriction.CharacterEnum.BeInGroup.ToString
                    For Each grp As clsGroup In Adventure.htblGroups.Values
                        If grp.GroupType = clsGroup.GroupTypeEnum.Characters Then
                            .Items.Add(grp.Key, grp.Name)
                        End If
                    Next
                Case clsRestriction.CharacterEnum.HaveSeenLocation.ToString, clsRestriction.CharacterEnum.BeAtLocation.ToString
                    For Each l As String In arlLocationRefs
                        .Items.Add(l, Adventure.GetNameFromKey(l, False))
                    Next
                    For Each loc As clsLocation In Adventure.htblLocations.Values
                        .Items.Add(loc.Key, loc.ShortDescription.ToString)
                    Next
                Case clsRestriction.CharacterEnum.BeWithinLocationGroup.ToString
                    For Each grp As clsGroup In Adventure.htblGroups.Values
                        If grp.GroupType = clsGroup.GroupTypeEnum.Locations Then
                            .Items.Add(grp.Key, grp.Name)
                        End If
                    Next
                Case clsRestriction.CharacterEnum.HaveProperty.ToString
                    For Each p As clsProperty In Adventure.htblCharacterProperties.Values
                        .Items.Add(p.Key, p.Description)
                    Next
            End Select

        End With

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        With Restriction
            If Me.tabsRestrictions.SelectedTab.Text = "Variable" Then
                If .sKey1 <> "" Then
                    If Adventure.htblVariables.ContainsKey(.sKey1) Then
                        Dim var As clsVariable = Adventure.htblVariables(.sKey1)
                        If isVariable.ListType = ItemSelector.ItemEnum.Expression Then
                            If var.Type = clsVariable.VariableTypeEnum.Numeric Then
                                If isVariable.Expression.DataTypeOfExpression = clsVariable.VariableTypeEnum.Text Then
                                    If MessageBox.Show("Warning - expression does not resolve to a numeric value.  Continue?", "Mismatching datatypes", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Cancel Then Exit Sub
                                End If
                            Else
                                If isVariable.Expression.DataTypeOfExpression = clsVariable.VariableTypeEnum.Numeric Then
                                    If MessageBox.Show("Warning - expression resolves to a numeric value, but variable """ & var.Name & """ is text.  Continue?", "Mismatching datatypes", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Cancel Then Exit Sub
                                End If
                            End If
                            If isVariable.Expression.DataTypeOfExpression = -1 Then
                                ErrMsg("Bad expression.")
                                Exit Sub
                            End If
                        Else
                            If Adventure.htblVariables.ContainsKey(.StringValue) Then
                                Dim var2 As clsVariable = Adventure.htblVariables(.StringValue)
                                If var.Type = clsVariable.VariableTypeEnum.Numeric AndAlso var2.Type = clsVariable.VariableTypeEnum.Text Then
                                    If MessageBox.Show("Warning - variable """ & var2.Name & """ is not a numeric variable.  Continue?", "Mismatching datatypes", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Cancel Then Exit Sub
                                End If
                                If var.Type = clsVariable.VariableTypeEnum.Text AndAlso var2.Type = clsVariable.VariableTypeEnum.Numeric Then
                                    If MessageBox.Show("Warning - variable """ & var2.Name & """ is not a text variable.  Continue?", "Mismatching datatypes", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Cancel Then Exit Sub
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End With

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub UltraTabControl1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabsRestrictions.SelectedTabChanged
        frmRestriction_Resize(Nothing, Nothing)
        SaveRestriction()
    End Sub

    Private Sub cmbIndexEdit_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbIndexEdit.SelectionChanged
        If cmbIndexEdit.SelectedIndex = 0 Then
            cmbIndexEdit.Visible = False
            cmbIndex.Visible = True
            cmbIndex.SelectedIndex = 1
            cmbIndex.Focus()
        End If
    End Sub


    Private Sub cmbVariable_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbVariable.SelectionChanged

        Dim v As clsVariable = Nothing
        If cmbVariable.SelectedItem IsNot Nothing AndAlso Not (cmbVariable.SelectedItem.ToString.StartsWith("[ Referenced ") OrElse cmbVariable.SelectedItem.DataValue.ToString.StartsWith("Parameter-")) Then v = Adventure.htblVariables(cmbVariable.SelectedItem.DataValue.ToString)
        Dim varType As clsVariable.VariableTypeEnum = clsVariable.VariableTypeEnum.Numeric

        If v IsNot Nothing Then varType = v.Type

        If v IsNot Nothing AndAlso v.Length > 1 Then
            If cmbIndexEdit.Text <> "0" Then
                cmbIndexEdit.Visible = True
                cmbIndex.Visible = False
            Else
                cmbIndex.Visible = True
                cmbIndexEdit.Visible = False
            End If
            lblLeft.Visible = True
            cmbVariable.Width = Me.lblLeft.Left - cmbVariable.Left - 1
            lblRight.Visible = True
        Else
            cmbIndex.Visible = False
            cmbIndexEdit.Visible = False
            lblLeft.Visible = False
            lblRight.Visible = False
            cmbVariable.Width = Me.cmbMustNotV.Left - cmbVariable.Left + 1

            If cmbVariable.SelectedItem IsNot Nothing AndAlso cmbVariable.SelectedItem.ToString = "[ Referenced Text ]" Then varType = clsVariable.VariableTypeEnum.Text
        End If

        Dim sItem As String = ""
        If cmbWhatV.SelectedItem IsNot Nothing Then sItem = cmbWhatV.SelectedItem.DataValue.ToString
        If varType = clsVariable.VariableTypeEnum.Numeric Then
            If cmbWhatV.Items.Count <> 5 Then
                cmbMustNotV.Items(0).DisplayText = "must be"
                cmbMustNotV.Items(1).DisplayText = "must not be"
                cmbWhatV.Items.Clear()
                cmbWhatV.Items.Add(clsRestriction.VariableEnum.LessThan.ToString, "less than")
                cmbWhatV.Items.Add(clsRestriction.VariableEnum.LessThanOrEqualTo.ToString, "less than or equal to")
                cmbWhatV.Items.Add(clsRestriction.VariableEnum.EqualTo.ToString, "equal to")
                cmbWhatV.Items.Add(clsRestriction.VariableEnum.GreaterThanOrEqualTo.ToString, "greater than or equal to")
                cmbWhatV.Items.Add(clsRestriction.VariableEnum.GreaterThan.ToString, "greater than")
            End If
        Else
            If cmbWhatV.Items.Count <> 2 Then
                cmbMustNotV.Items(0).DisplayText = "must "
                cmbMustNotV.Items(1).DisplayText = "must not "
                cmbWhatV.Items.Clear()
                cmbWhatV.Items.Add(clsRestriction.VariableEnum.EqualTo.ToString, "be equal to")
                cmbWhatV.Items.Add(clsRestriction.VariableEnum.Contain.ToString, "contain")
            End If
        End If
        If sItem <> "" Then SetCombo(cmbWhatV, sItem)

    End Sub


    Private Sub StuffChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLocation.ValueChanged, cmbLocationExtra.ValueChanged, cmbWhatL.ValueChanged, cmbMustNotL.ValueChanged, cmbObject.ValueChanged, cmbMustNotO.ValueChanged, cmbWhatO.ValueChanged, cmbObjectExtra.ValueChanged, cmbTask.ValueChanged, cmbMustNotT.ValueChanged, cmbCharacter.ValueChanged, cmbMustNotC.ValueChanged, cmbWhatC.ValueChanged, cmbCharacterExtra.ValueChanged, txtMessage.Changed, cmbProperty.ValueChanged, cmbPropertyOb.ValueChanged, cmbMustNotP.ValueChanged, cmbVariable.ValueChanged, cmbWhatV.ValueChanged, cmbMustNotV.ValueChanged, cmbMustNotD.ValueChanged, cmbDirection.ValueChanged, cmbPropertyValue.ValueChanged, cmbPropEqual.ValueChanged, cmbIndex.ValueChanged, cmbIndexEdit.ValueChanged, cmbItem.ValueChanged, cmbWhatI.ValueChanged, cmbMustNotI.ValueChanged, cmbItemExtra.ValueChanged
        SaveRestriction()
    End Sub


    Private Sub SaveRestriction()

        If bLoadingRestriction Then Exit Sub
        If tabsRestrictions.SelectedTab Is Nothing Then Exit Sub

        btnOK.Enabled = False

        With Restriction
            Select Case Me.tabsRestrictions.SelectedTab.Text
                Case "Location"
                    .eType = clsRestriction.RestrictionTypeEnum.Location
                    If Not cmbLocation.SelectedItem Is Nothing Then .sKey1 = CStr(cmbLocation.SelectedItem.DataValue)
                    If Not cmbMustNotL.SelectedItem Is Nothing Then
                        .eMust = EnumParseMust(CStr(cmbMustNotL.SelectedItem.DataValue))
                    End If
                    If Not cmbWhatL.SelectedItem Is Nothing Then
                        Select Case Me.cmbWhatL.SelectedItem.DisplayText
                            Case "be in group"
                                .eLocation = clsRestriction.LocationEnum.BeInGroup
                            Case "have been seen by"
                                .eLocation = clsRestriction.LocationEnum.HaveBeenSeenByCharacter
                            Case "have property"
                                .eLocation = clsRestriction.LocationEnum.HaveProperty
                            Case "be location"
                                .eLocation = clsRestriction.LocationEnum.BeLocation
                            Case "exist"
                                .eLocation = clsRestriction.LocationEnum.Exist
                        End Select
                    End If
                    If Not cmbLocationExtra.SelectedItem Is Nothing Then .sKey2 = CStr(cmbLocationExtra.SelectedItem.DataValue)

                    If cmbLocation.SelectedItem IsNot Nothing AndAlso cmbMustNotL.SelectedItem IsNot Nothing AndAlso cmbWhatL.SelectedItem IsNot Nothing AndAlso (cmbLocationExtra.SelectedItem IsNot Nothing OrElse .eLocation = clsRestriction.LocationEnum.Exist) Then
                        btnOK.Enabled = True
                    End If

                Case "Object"
                    .eType = clsRestriction.RestrictionTypeEnum.Object
                    If Not cmbObject.SelectedItem Is Nothing Then .sKey1 = CStr(cmbObject.SelectedItem.DataValue)
                    If Not cmbMustNotO.SelectedItem Is Nothing Then
                        .eMust = EnumParseMust(CStr(cmbMustNotO.SelectedItem.DataValue))
                    End If
                    If Not cmbWhatO.SelectedItem Is Nothing Then
                        .eObject = EnumParseObject(CStr(cmbWhatO.SelectedItem.DataValue))
                    End If
                    If Not cmbObjectExtra.SelectedItem Is Nothing Then
                        .sKey2 = CStr(cmbObjectExtra.SelectedItem.DataValue)
                    End If

                    If Not (cmbObject.SelectedItem Is Nothing OrElse cmbMustNotO.SelectedItem Is Nothing OrElse cmbWhatO.SelectedItem Is Nothing) Then
                        btnOK.Enabled = True
                        If cmbObjectExtra.SelectedItem Is Nothing AndAlso cmbWhatO.SelectedItem.DisplayText <> "exist" AndAlso cmbWhatO.SelectedItem.DisplayText <> "be hidden" Then btnOK.Enabled = False
                    End If

                Case "Task"
                    .eType = clsRestriction.RestrictionTypeEnum.Task
                    If Not cmbTask.SelectedItem Is Nothing Then .sKey1 = CStr(cmbTask.SelectedItem.DataValue)
                    If Not cmbMustNotT.SelectedItem Is Nothing Then
                        .eMust = EnumParseMust(CStr(cmbMustNotT.SelectedItem.DataValue))
                    End If
                    .eTask = clsRestriction.TaskEnum.Complete

                    If Not (cmbTask.SelectedItem Is Nothing OrElse cmbMustNotT.SelectedItem Is Nothing) Then
                        btnOK.Enabled = True
                    End If

                Case "Character"
                    .eType = clsRestriction.RestrictionTypeEnum.Character
                    If Not cmbCharacter.SelectedItem Is Nothing Then .sKey1 = CStr(cmbCharacter.SelectedItem.DataValue)
                    If Not cmbMustNotC.SelectedItem Is Nothing Then
                        .eMust = EnumParseMust(CStr(cmbMustNotC.SelectedItem.DataValue))
                    End If
                    If Not cmbWhatC.SelectedItem Is Nothing Then
                        .eCharacter = EnumParseCharacter(CStr(cmbWhatC.SelectedItem.DataValue))
                    End If
                    If Not cmbCharacterExtra.SelectedItem Is Nothing Then
                        .sKey2 = CStr(cmbCharacterExtra.SelectedItem.DataValue)
                    End If
                    If Not (cmbCharacter.SelectedItem Is Nothing OrElse cmbMustNotC.SelectedItem Is Nothing OrElse cmbWhatC.SelectedItem Is Nothing) Then
                        btnOK.Enabled = True
                        If cmbCharacterExtra.SelectedItem Is Nothing AndAlso cmbWhatC.SelectedItem.DisplayText <> "be alone" AndAlso cmbWhatC.SelectedItem.DisplayText <> "exist" Then btnOK.Enabled = False
                    End If

                Case "Item"
                    .eType = clsRestriction.RestrictionTypeEnum.Item
                    If cmbItem.SelectedItem IsNot Nothing Then .sKey1 = CStr(cmbItem.SelectedItem.DataValue)
                    If cmbMustNotI.SelectedItem IsNot Nothing Then
                        .eMust = EnumParseMust(CStr(cmbMustNotI.SelectedItem.DataValue))
                    End If
                    If cmbWhatI.SelectedItem IsNot Nothing Then
                        .eItem = EnumParseItem(CStr(cmbWhatI.SelectedItem.DataValue))
                    End If
                    If cmbItemExtra.SelectedItem IsNot Nothing Then
                        .sKey2 = CStr(cmbItemExtra.SelectedItem.DataValue)
                    End If

                    If Not (cmbItem.SelectedItem Is Nothing OrElse cmbMustNotI.SelectedItem Is Nothing OrElse cmbWhatI.SelectedItem Is Nothing) Then
                        btnOK.Enabled = True
                        If cmbItemExtra.SelectedItem Is Nothing AndAlso cmbWhatI.SelectedItem.DisplayText <> "exist" Then btnOK.Enabled = False
                    End If

                Case "Variable"
                    .eType = clsRestriction.RestrictionTypeEnum.Variable
                    If cmbVariable.SelectedItem IsNot Nothing Then .sKey1 = CStr(cmbVariable.SelectedItem.DataValue)
                    If Not cmbIndex.SelectedItem Is Nothing AndAlso cmbIndex.Visible Then .sKey2 = CStr(cmbIndex.SelectedItem.DataValue)
                    If cmbIndexEdit.Visible Then .sKey2 = CInt(Val(cmbIndexEdit.Text)).ToString
                    If cmbMustNotV.SelectedItem IsNot Nothing Then .eMust = EnumParseMust(CStr(cmbMustNotV.SelectedItem.DataValue))
                    If cmbWhatV.SelectedItem IsNot Nothing Then .eVariable = EnumParseVariable(CStr(cmbWhatV.SelectedItem.DataValue))
                    If isVariable.ListType = ItemSelector.ItemEnum.Variable Then
                        .IntValue = Integer.MinValue
                        .StringValue = isVariable.Key
                    ElseIf isVariable.ListType = ItemSelector.ItemEnum.Expression Then
                        .IntValue = SafeInt(isVariable.Expression.Value)
                        .StringValue = isVariable.Expression.Value
                    End If

                    If Not (cmbVariable.SelectedItem Is Nothing OrElse cmbMustNotV.SelectedItem Is Nothing OrElse cmbWhatV.SelectedItem Is Nothing OrElse (isVariable.ListType = ItemSelector.ItemEnum.Variable AndAlso .StringValue = "")) Then
                        btnOK.Enabled = True
                    End If
                    If isVariable.ListType = ItemSelector.ItemEnum.Expression AndAlso isVariable.Expression.DataTypeOfExpression = -1 Then btnOK.Enabled = False

                Case "Property"
                    .eType = clsRestriction.RestrictionTypeEnum.Property
                    If Not cmbProperty.SelectedItem Is Nothing Then .sKey1 = CStr(cmbProperty.SelectedItem.DataValue)
                    If Not cmbPropertyOb.SelectedItem Is Nothing Then .sKey2 = CStr(cmbPropertyOb.SelectedItem.DataValue)
                    If Not cmbMustNotP.SelectedItem Is Nothing Then .eMust = EnumParseMust(CStr(cmbMustNotP.SelectedItem.DataValue))
                    If cmbPropertyValue.Value IsNot Nothing Then .StringValue = cmbPropertyValue.Value
                    If cmbPropEqual.SelectedItem IsNot Nothing Then .IntValue = CInt(cmbPropEqual.SelectedItem.DataValue)
                    If Not cmbPropEqual.Visible Then .IntValue = -1

                    If Not (cmbProperty.SelectedItem Is Nothing OrElse cmbPropertyOb.SelectedItem Is Nothing OrElse cmbMustNotP.SelectedItem Is Nothing OrElse cmbPropertyValue.Value Is Nothing) Then
                        btnOK.Enabled = True
                    End If
                    If cmbPropertyValue.ExpressionOrVariable.Visible AndAlso cmbPropertyValue.ExpressionOrVariable.ListType = ItemSelector.ItemEnum.ValueList AndAlso cmbPropertyValue.ExpressionOrVariable.cmbList.SelectedIndex = 0 Then btnOK.Enabled = False ' No Value Selected

                Case "Direction"
                    .eType = clsRestriction.RestrictionTypeEnum.Direction
                    If cmbMustNotD.SelectedItem IsNot Nothing Then .eMust = EnumParseMust(CStr(cmbMustNotD.SelectedItem.DataValue))
                    If cmbDirection.SelectedItem IsNot Nothing Then .sKey1 = CType(EnumParseDirections(SafeString(cmbDirection.SelectedItem.DataValue)), DirectionsEnum).ToString

                    If Not (cmbMustNotD Is Nothing OrElse cmbDirection Is Nothing) Then
                        btnOK.Enabled = True
                    End If

                Case "Expression"
                    .eType = clsRestriction.RestrictionTypeEnum.Expression
                    .eMust = clsRestriction.MustEnum.Must
                    .StringValue = Expression.Value

                    btnOK.Enabled = Expression.Value <> ""

            End Select

            .oMessage = txtMessage.Description.Copy

        End With

    End Sub

    Private Sub cmbWhatO_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWhatO.ValueChanged

        cmbObjectExtra.Items.Clear()
        cmbObjectExtra.Enabled = True

        Select Case EnumParseObject(CStr(cmbWhatO.SelectedItem.DataValue))
            Case clsRestriction.ObjectEnum.BeAtLocation
                cmbObjectExtra.Items.Add(HIDDEN, "[ Hidden ]")
                For Each l As String In arlLocationRefs
                    cmbObjectExtra.Items.Add(l, Adventure.GetNameFromKey(l, False))
                Next
                For Each loc As clsLocation In Adventure.htblLocations.Values
                    cmbObjectExtra.Items.Add(loc.Key, loc.ShortDescription.ToString)
                Next

            Case clsRestriction.ObjectEnum.BeHeldByCharacter, clsRestriction.ObjectEnum.HaveBeenSeenByCharacter, clsRestriction.ObjectEnum.BePartOfCharacter, clsRestriction.ObjectEnum.BeVisibleToCharacter, clsRestriction.ObjectEnum.BeWornByCharacter
                cmbObjectExtra.Items.Add(THEPLAYER, "[ The Player Character ]")
                cmbObjectExtra.Items.Add(ANYCHARACTER, "[ Any Character ]")
                For Each d As String In arlCharacterRefs
                    cmbObjectExtra.Items.Add(d, Adventure.GetNameFromKey(d, False))
                Next
                For Each chr As clsCharacter In Adventure.htblCharacters.Values
                    cmbObjectExtra.Items.Add(chr.Key, chr.Name)
                Next

            Case clsRestriction.ObjectEnum.BeInGroup
                For Each grp As clsGroup In Adventure.htblGroups.Values
                    If grp.GroupType = clsGroup.GroupTypeEnum.Objects Then cmbObjectExtra.Items.Add(grp.Key, grp.Name)
                Next

            Case clsRestriction.ObjectEnum.BeInState
                If cmbObject.SelectedItem IsNot Nothing Then
                    If CStr(cmbObject.SelectedItem.DataValue).StartsWith("ReferencedObject") OrElse cmbObject.SelectedItem.DataValue.ToString = NOOBJECT OrElse cmbObject.SelectedItem.DataValue.ToString = ANYOBJECT Then
                        For Each prop As clsProperty In Adventure.htblObjectProperties.Values
                            If prop.Type = clsProperty.PropertyTypeEnum.StateList Then ' Suppress some obvious ones we don't want
                                If prop.Key <> "StaticLocation" AndAlso prop.Key <> "DynamicLocation" AndAlso prop.Key <> "StaticOrDynamic" Then
                                    For Each sState As String In prop.arlStates
                                        cmbObjectExtra.Items.Add(sState, sState)
                                    Next
                                End If
                            End If
                        Next
                    Else
                        For Each prop As clsProperty In Adventure.htblObjects(CStr(cmbObject.SelectedItem.DataValue)).htblProperties.Values
                            If prop.Type = clsProperty.PropertyTypeEnum.StateList Then ' Suppress some obvious ones we don't want
                                If prop.Key <> "StaticLocation" AndAlso prop.Key <> "DynamicLocation" AndAlso prop.Key <> "StaticOrDynamic" Then
                                    For Each sState As String In prop.arlStates
                                        cmbObjectExtra.Items.Add(sState, sState)
                                    Next
                                End If
                            End If
                        Next
                    End If
                End If

            Case clsRestriction.ObjectEnum.BeInsideObject
                cmbObjectExtra.Items.Add(ANYOBJECT, "[ Any Object ]")
                For Each o As String In arlObjectRefs
                    cmbObjectExtra.Items.Add(o, Adventure.GetNameFromKey(o, False))
                Next
                For Each ob As clsObject In Adventure.htblObjects.Values
                    If ob.IsContainer Then cmbObjectExtra.Items.Add(ob.Key, ob.FullName)
                Next

            Case clsRestriction.ObjectEnum.BeOnObject
                cmbObjectExtra.Items.Add(ANYOBJECT, "[ Any Object ]")
                For Each o As String In arlObjectRefs
                    cmbObjectExtra.Items.Add(o, Adventure.GetNameFromKey(o, False))
                Next
                For Each ob As clsObject In Adventure.htblObjects.Values
                    If ob.HasSurface Then cmbObjectExtra.Items.Add(ob.Key, ob.FullName)
                Next

            Case clsRestriction.ObjectEnum.BePartOfObject, clsRestriction.ObjectEnum.BeObject
                cmbObjectExtra.Items.Add(ANYOBJECT, "[ Any Object ]")
                For Each o As String In arlObjectRefs
                    cmbObjectExtra.Items.Add(o, Adventure.GetNameFromKey(o, False))
                Next
                For Each ob As clsObject In Adventure.htblObjects.Values
                    cmbObjectExtra.Items.Add(ob.Key, ob.FullName)
                Next

            Case clsRestriction.ObjectEnum.Exist, clsRestriction.ObjectEnum.BeHidden
                cmbObjectExtra.Enabled = False

            Case clsRestriction.ObjectEnum.HaveProperty
                For Each p As clsProperty In Adventure.htblObjectProperties.Values                    
                    cmbObjectExtra.Items.Add(p.Key, p.Description)
                Next

            Case clsRestriction.ObjectEnum.BeExactText
                cmbObjectExtra.Items.Add("All", "'All'")

        End Select

    End Sub


    Private Sub frmRestriction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetFormPosition(Me)
        tabsRestrictions.Tabs("Property").Visible = Not fGenerator.SimpleMode ' Properties
        tabsRestrictions.Tabs("Expression").Visible = Not fGenerator.SimpleMode ' Expressions
    End Sub


    Private Sub cmbObject_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbObject.ValueChanged

        If cmbObject.SelectedItem.DisplayText = "[ Referenced Objects ]" Then
            If Not cmbWhatO.IsItemInList("BeExactText") Then
                Dim vli As New Infragistics.Win.ValueListItem
                vli.DataValue = "BeExactText"
                vli.DisplayText = "be exact text"
                cmbWhatO.Items.Add(vli)
            End If
        Else
            If cmbWhatO.IsItemInList("BeExactText") Then
                For Each vli As Infragistics.Win.ValueListItem In cmbWhatO.Items
                    If vli.DataValue.ToString = "BeExactText" Then
                        cmbWhatO.Items.Remove(vli)
                        Exit For
                    End If
                Next
            End If
        End If

        If sInstr(cmbObject.SelectedItem.DisplayText, "[ Referenced ") > 0 Then
            If Not cmbWhatO.IsItemInList("Exist") Then
                'If cmbWhatO.Items.Count = 11 Then
                Dim vli As New Infragistics.Win.ValueListItem
                vli.DataValue = "Exist"
                vli.DisplayText = "exist"
                cmbWhatO.Items.Add(vli)
            End If
        Else
            'If cmbWhatO.Items.Count = 12 Then
            If cmbWhatO.IsItemInList("Exist") Then
                For Each vli As Infragistics.Win.ValueListItem In cmbWhatO.Items
                    If vli.DisplayText = "exist" Then
                        cmbWhatO.Items.Remove(vli)
                        Exit For
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub frmRestriction_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        SaveFormPosition(Me)
    End Sub

    Private Sub cmbProperty_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProperty.SelectionChanged

        Dim prop As clsProperty = Adventure.htblAllProperties(CStr(cmbProperty.SelectedItem.DataValue))

        ' Remember selected item if poss
        Dim sPropertyOb As String = Nothing
        If Not cmbPropertyOb.SelectedItem Is Nothing Then sPropertyOb = CStr(cmbPropertyOb.SelectedItem.DataValue)

        ' Is it an object or character?
        Select Case prop.PropertyOf
            Case clsProperty.PropertyOfEnum.Objects
                cmbPropertyOb.Items.Clear()
                For Each o As String In arlObjectRefs
                    cmbPropertyOb.Items.Add(o, Adventure.GetNameFromKey(o, False))
                Next
                For Each ob As clsObject In Adventure.htblObjects.Values
                    If ob.htblProperties.ContainsKey(prop.Key) Then
                        cmbPropertyOb.Items.Add(ob.Key, ob.FullName)
                    End If
                Next
            Case clsProperty.PropertyOfEnum.Characters
                cmbPropertyOb.Items.Clear()
                cmbPropertyOb.Items.Add(THEPLAYER, "[ The Player Character ]")
                'cmbPropertyValue.Items.Add(ANYCHARACTER, "[ Any Character ]")
                For Each ch As String In arlCharacterRefs
                    cmbPropertyOb.Items.Add(ch, Adventure.GetNameFromKey(ch, False))
                Next
                For Each ch As clsCharacter In Adventure.htblCharacters.Values
                    If ch.htblProperties.ContainsKey(prop.Key) Then
                        cmbPropertyOb.Items.Add(ch.Key, ch.Name)
                    End If
                Next
            Case clsProperty.PropertyOfEnum.Locations
                cmbPropertyOb.Items.Clear()
                For Each l As String In arlLocationRefs
                    cmbPropertyOb.Items.Add(l, Adventure.GetNameFromKey(l, False))
                Next
                For Each l As clsLocation In Adventure.htblLocations.Values
                    If l.htblProperties.ContainsKey(prop.Key) Then
                        cmbPropertyOb.Items.Add(l.Key, l.ShortDescription.ToString)
                    End If
                Next
        End Select
        SetCombo(cmbPropertyOb, sPropertyOb)

        cmbPropertyValue.PropertyKey = prop.Key

        Dim bCurrentlyVisible As Boolean = cmbPropEqual.Visible
        Select Case prop.Type
            Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                cmbPropEqual.Visible = True
            Case Else
                cmbPropEqual.Visible = False
        End Select
        If bCurrentlyVisible <> cmbPropEqual.Visible Then frmRestriction_Resize(Nothing, Nothing)

    End Sub



    Private Sub isVariable_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles isVariable.SelectionChanged
        SaveRestriction()
    End Sub


    Private Sub cmbIndex_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbIndex.SelectionChanged
        If cmbIndex.SelectedIndex = 0 Then
            cmbIndex.Visible = False
            cmbIndexEdit.Visible = True
            cmbIndexEdit.Text = "0"
            cmbIndexEdit.Focus()
        End If
    End Sub


    Private Sub Expression_ValueChanged(sender As Object, e As System.EventArgs) Handles Expression.ValueChanged
        SaveRestriction()
    End Sub

End Class
