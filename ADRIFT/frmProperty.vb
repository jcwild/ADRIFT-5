Public Class frmProperty
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public bKeepOpen As Boolean = False

    Public Sub New(ByRef prop As clsProperty, ByVal bShow As Boolean)
        MyBase.New()

        ' Check that this window isn't already open
        For Each w As Form In OpenForms
            If TypeOf w Is frmProperty Then
                If CType(w, frmProperty).cProperty.Key = prop.Key AndAlso prop.Key IsNot Nothing Then
                    w.BringToFront()
                    w.Focus()
                    Exit Sub
                End If
            End If
        Next

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoadForm(prop, bShow)
        bKeepOpen = Not bShow

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
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents btnApply As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtDescription As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents grpStateList As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grpDependencies As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents lblProperty As System.Windows.Forms.Label
    Friend WithEvents cmbProperty As AutoCompleteCombo
    Friend WithEvents cmbValue As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents grpType As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkMandatory As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents cmbType As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblRestrictProperty As System.Windows.Forms.Label
    Friend WithEvents cmbRestrictProperty As AutoCompleteCombo
    Friend WithEvents cmbRestrictValue As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmbPropertyOf As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAppendToProperty As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStateList As System.Windows.Forms.TextBox
    Friend WithEvents grdValueList As System.Windows.Forms.DataGridView
    Friend WithEvents NumericValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkPrivate As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage3 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents txtPopupDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRestrictValue As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem27 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem19 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem20 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem22 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem21 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem23 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem24 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem25 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem26 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.grpType = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbRestrictProperty = New AutoCompleteCombo
        Me.cmbRestrictValue = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbPropertyOf = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblRestrictValue = New System.Windows.Forms.Label()
        Me.lblRestrictProperty = New System.Windows.Forms.Label()
        Me.chkMandatory = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.lblType = New System.Windows.Forms.Label()
        Me.cmbType = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.chkPrivate = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.grpDependencies = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.cmbValue = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblProperty = New System.Windows.Forms.Label()
        Me.cmbProperty = New AutoCompleteCombo
        Me.grpStateList = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbAppendToProperty = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtStateList = New System.Windows.Forms.TextBox()
        Me.grdValueList = New System.Windows.Forms.DataGridView()
        Me.NumericValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.txtPopupDescription = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.btnApply = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage3 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.grpType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpType.SuspendLayout()
        CType(Me.cmbRestrictProperty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbRestrictValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPropertyOf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMandatory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrivate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpDependencies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDependencies.SuspendLayout()
        CType(Me.cmbValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbProperty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpStateList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStateList.SuspendLayout()
        CType(Me.cmbAppendToProperty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdValueList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.grpType)
        Me.UltraTabPageControl1.Controls.Add(Me.chkPrivate)
        Me.UltraTabPageControl1.Controls.Add(Me.grpDependencies)
        Me.UltraTabPageControl1.Controls.Add(Me.grpStateList)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(448, 477)
        '
        'grpType
        '
        Me.grpType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpType.Controls.Add(Me.cmbRestrictProperty)
        Me.grpType.Controls.Add(Me.cmbRestrictValue)
        Me.grpType.Controls.Add(Me.cmbPropertyOf)
        Me.grpType.Controls.Add(Me.Label1)
        Me.grpType.Controls.Add(Me.lblRestrictValue)
        Me.grpType.Controls.Add(Me.lblRestrictProperty)
        Me.grpType.Controls.Add(Me.chkMandatory)
        Me.grpType.Controls.Add(Me.lblType)
        Me.grpType.Controls.Add(Me.cmbType)
        Me.grpType.Location = New System.Drawing.Point(14, 11)
        Me.grpType.Name = "grpType"
        Me.grpType.Size = New System.Drawing.Size(421, 152)
        Me.grpType.TabIndex = 1
        Me.grpType.Text = "Property Type:"
        '
        'cmbRestrictProperty
        '
        Me.cmbRestrictProperty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRestrictProperty.Enabled = False
        Me.cmbRestrictProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRestrictProperty.Location = New System.Drawing.Point(72, 83)
        Me.cmbRestrictProperty.Name = "cmbRestrictProperty"
        Me.cmbRestrictProperty.Size = New System.Drawing.Size(333, 23)
        Me.cmbRestrictProperty.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbRestrictProperty.TabIndex = 3
        '
        'cmbRestrictValue
        '
        Me.cmbRestrictValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRestrictValue.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbRestrictValue.Enabled = False
        Me.cmbRestrictValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ValueListItem3.DataValue = "CharacterKey"
        ValueListItem3.DisplayText = "Character Key"
        ValueListItem4.DataValue = "Integer"
        ValueListItem4.DisplayText = "Integer"
        ValueListItem5.DataValue = "LocationGroupKey"
        ValueListItem5.DisplayText = "Location Group Key"
        ValueListItem6.DataValue = "LocationKey"
        ValueListItem6.DisplayText = "Location Key"
        ValueListItem7.DataValue = "ObjectKey"
        ValueListItem7.DisplayText = "Object Key"
        ValueListItem8.DataValue = "SelectionOnly"
        ValueListItem8.DisplayText = "Selection Only"
        ValueListItem9.DataValue = "StateList"
        ValueListItem9.DisplayText = "State List"
        ValueListItem10.DataValue = "Text"
        ValueListItem10.DisplayText = "Text"
        Me.cmbRestrictValue.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4, ValueListItem5, ValueListItem6, ValueListItem7, ValueListItem8, ValueListItem9, ValueListItem10})
        Me.cmbRestrictValue.Location = New System.Drawing.Point(72, 115)
        Me.cmbRestrictValue.Name = "cmbRestrictValue"
        Me.cmbRestrictValue.Size = New System.Drawing.Size(333, 23)
        Me.cmbRestrictValue.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbRestrictValue.TabIndex = 4
        '
        'cmbPropertyOf
        '
        Me.cmbPropertyOf.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPropertyOf.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbPropertyOf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ValueListItem12.DataValue = "AnyItem"
        ValueListItem12.DisplayText = "Any Item"
        ValueListItem1.DataValue = "Characters"
        ValueListItem1.DisplayText = "Characters"
        ValueListItem27.DataValue = "Locations"
        ValueListItem27.DisplayText = "Locations"
        ValueListItem2.DataValue = "Objects"
        ValueListItem2.DisplayText = "Objects"
        Me.cmbPropertyOf.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem12, ValueListItem1, ValueListItem27, ValueListItem2})
        Me.cmbPropertyOf.Location = New System.Drawing.Point(72, 20)
        Me.cmbPropertyOf.Name = "cmbPropertyOf"
        Me.cmbPropertyOf.Size = New System.Drawing.Size(245, 23)
        Me.cmbPropertyOf.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbPropertyOf.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(11, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 21)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Property of:"
        '
        'lblRestrictValue
        '
        Me.lblRestrictValue.BackColor = System.Drawing.Color.Transparent
        Me.lblRestrictValue.Location = New System.Drawing.Point(11, 112)
        Me.lblRestrictValue.Name = "lblRestrictValue"
        Me.lblRestrictValue.Size = New System.Drawing.Size(64, 32)
        Me.lblRestrictValue.TabIndex = 30
        Me.lblRestrictValue.Text = "Refine by Value:"
        '
        'lblRestrictProperty
        '
        Me.lblRestrictProperty.BackColor = System.Drawing.Color.Transparent
        Me.lblRestrictProperty.Location = New System.Drawing.Point(11, 80)
        Me.lblRestrictProperty.Name = "lblRestrictProperty"
        Me.lblRestrictProperty.Size = New System.Drawing.Size(64, 32)
        Me.lblRestrictProperty.TabIndex = 28
        Me.lblRestrictProperty.Text = "Refine by Property:"
        '
        'chkMandatory
        '
        Me.chkMandatory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkMandatory.BackColor = System.Drawing.Color.Transparent
        Me.chkMandatory.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkMandatory.Location = New System.Drawing.Point(338, 53)
        Me.chkMandatory.Name = "chkMandatory"
        Me.chkMandatory.Size = New System.Drawing.Size(75, 20)
        Me.chkMandatory.TabIndex = 2
        Me.chkMandatory.Text = "Mandatory"
        '
        'lblType
        '
        Me.lblType.BackColor = System.Drawing.Color.Transparent
        Me.lblType.Location = New System.Drawing.Point(11, 56)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(48, 16)
        Me.lblType.TabIndex = 25
        Me.lblType.Text = "Type:"
        '
        'cmbType
        '
        Me.cmbType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ValueListItem19.DataValue = "CharacterKey"
        ValueListItem19.DisplayText = "Character"
        ValueListItem20.DataValue = "Integer"
        ValueListItem20.DisplayText = "Integer"
        ValueListItem22.DataValue = "LocationKey"
        ValueListItem22.DisplayText = "Location"
        ValueListItem21.DataValue = "LocationGroupKey"
        ValueListItem21.DisplayText = "Location Group"
        ValueListItem23.DataValue = "ObjectKey"
        ValueListItem23.DisplayText = "Object"
        ValueListItem24.DataValue = "SelectionOnly"
        ValueListItem24.DisplayText = "Selection Only"
        ValueListItem25.DataValue = "StateList"
        ValueListItem25.DisplayText = "State"
        ValueListItem26.DataValue = "Text"
        ValueListItem26.DisplayText = "Text"
        ValueListItem11.DataValue = "ValueList"
        ValueListItem11.DisplayText = "Value"
        Me.cmbType.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem19, ValueListItem20, ValueListItem22, ValueListItem21, ValueListItem23, ValueListItem24, ValueListItem25, ValueListItem26, ValueListItem11})
        Me.cmbType.Location = New System.Drawing.Point(72, 51)
        Me.cmbType.MaxDropDownItems = 9
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(245, 23)
        Me.cmbType.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbType.TabIndex = 1
        '
        'chkPrivate
        '
        Me.chkPrivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrivate.AutoSize = True
        Me.chkPrivate.BackColor = System.Drawing.Color.Transparent
        Me.chkPrivate.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkPrivate.Location = New System.Drawing.Point(29, 452)
        Me.chkPrivate.Name = "chkPrivate"
        Me.chkPrivate.Size = New System.Drawing.Size(93, 17)
        Me.chkPrivate.TabIndex = 16
        Me.chkPrivate.Text = "Private to item"
        Me.chkPrivate.Visible = False
        '
        'grpDependencies
        '
        Me.grpDependencies.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDependencies.Controls.Add(Me.lblValue)
        Me.grpDependencies.Controls.Add(Me.cmbValue)
        Me.grpDependencies.Controls.Add(Me.lblProperty)
        Me.grpDependencies.Controls.Add(Me.cmbProperty)
        Me.grpDependencies.Location = New System.Drawing.Point(15, 170)
        Me.grpDependencies.Name = "grpDependencies"
        Me.grpDependencies.Size = New System.Drawing.Size(420, 91)
        Me.grpDependencies.TabIndex = 2
        Me.grpDependencies.Text = "This Property will only appear if the following are true:"
        '
        'lblValue
        '
        Me.lblValue.BackColor = System.Drawing.Color.Transparent
        Me.lblValue.Location = New System.Drawing.Point(11, 61)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(40, 16)
        Me.lblValue.TabIndex = 22
        Me.lblValue.Text = "Value:"
        '
        'cmbValue
        '
        Me.cmbValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbValue.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbValue.Location = New System.Drawing.Point(72, 56)
        Me.cmbValue.Name = "cmbValue"
        Me.cmbValue.Size = New System.Drawing.Size(332, 23)
        Me.cmbValue.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbValue.TabIndex = 1
        '
        'lblProperty
        '
        Me.lblProperty.BackColor = System.Drawing.Color.Transparent
        Me.lblProperty.Location = New System.Drawing.Point(11, 29)
        Me.lblProperty.Name = "lblProperty"
        Me.lblProperty.Size = New System.Drawing.Size(56, 16)
        Me.lblProperty.TabIndex = 20
        Me.lblProperty.Text = "Property:"
        '
        'cmbProperty
        '
        Me.cmbProperty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbProperty.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProperty.Location = New System.Drawing.Point(72, 24)
        Me.cmbProperty.Name = "cmbProperty"
        Me.cmbProperty.Size = New System.Drawing.Size(332, 23)
        Me.cmbProperty.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbProperty.TabIndex = 0
        '
        'grpStateList
        '
        Me.grpStateList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpStateList.Controls.Add(Me.cmbAppendToProperty)
        Me.grpStateList.Controls.Add(Me.Label2)
        Me.grpStateList.Controls.Add(Me.txtStateList)
        Me.grpStateList.Controls.Add(Me.grdValueList)
        Me.grpStateList.Enabled = False
        Me.grpStateList.Location = New System.Drawing.Point(15, 269)
        Me.grpStateList.Name = "grpStateList"
        Me.grpStateList.Size = New System.Drawing.Size(420, 182)
        Me.grpStateList.TabIndex = 3
        Me.grpStateList.Text = "State List"
        '
        'cmbAppendToProperty
        '
        Me.cmbAppendToProperty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAppendToProperty.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbAppendToProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAppendToProperty.Location = New System.Drawing.Point(72, 147)
        Me.cmbAppendToProperty.Name = "cmbAppendToProperty"
        Me.cmbAppendToProperty.Size = New System.Drawing.Size(332, 23)
        Me.cmbAppendToProperty.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbAppendToProperty.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(11, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Append to:"
        '
        'txtStateList
        '
        Me.txtStateList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStateList.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStateList.Location = New System.Drawing.Point(14, 22)
        Me.txtStateList.Multiline = True
        Me.txtStateList.Name = "txtStateList"
        Me.txtStateList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStateList.Size = New System.Drawing.Size(390, 117)
        Me.txtStateList.TabIndex = 0
        '
        'grdValueList
        '
        Me.grdValueList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdValueList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdValueList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdValueList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumericValue, Me.TextValue})
        Me.grdValueList.Location = New System.Drawing.Point(14, 22)
        Me.grdValueList.Name = "grdValueList"
        Me.grdValueList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdValueList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdValueList.Size = New System.Drawing.Size(390, 117)
        Me.grdValueList.TabIndex = 23
        '
        'NumericValue
        '
        Me.NumericValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.NumericValue.DefaultCellStyle = DataGridViewCellStyle1
        Me.NumericValue.FillWeight = 101.5228!
        Me.NumericValue.HeaderText = "Numeric Value"
        Me.NumericValue.Name = "NumericValue"
        Me.NumericValue.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NumericValue.Width = 101
        '
        'TextValue
        '
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TextValue.DefaultCellStyle = DataGridViewCellStyle2
        Me.TextValue.FillWeight = 98.47716!
        Me.TextValue.HeaderText = "Text Value"
        Me.TextValue.Name = "TextValue"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.txtPopupDescription)
        Me.UltraTabPageControl2.Controls.Add(Me.Label3)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(448, 477)
        '
        'txtPopupDescription
        '
        Me.txtPopupDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPopupDescription.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPopupDescription.Location = New System.Drawing.Point(11, 51)
        Me.txtPopupDescription.Multiline = True
        Me.txtPopupDescription.Name = "txtPopupDescription"
        Me.txtPopupDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPopupDescription.Size = New System.Drawing.Size(426, 415)
        Me.txtPopupDescription.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(16, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(421, 32)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Enter a description that will appear as pop-up help when this property is display" & _
    "ed"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 545)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(450, 48)
        Me.UltraStatusBar1.TabIndex = 5
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(346, 555)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(88, 32)
        Me.btnApply.TabIndex = 6
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(250, 555)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(154, 555)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(10, 17)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(64, 16)
        Me.lblDescription.TabIndex = 15
        Me.lblDescription.Text = "Name:"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(60, 12)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(374, 24)
        Me.txtDescription.TabIndex = 0
        Me.txtDescription.Text = "Location of the object"
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(357, 377)
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage3)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 46)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage3
        Me.UltraTabControl1.Size = New System.Drawing.Size(450, 500)
        Me.UltraTabControl1.TabIndex = 2
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "Definition"
        UltraTab4.TabPage = Me.UltraTabPageControl2
        UltraTab4.Text = "Description"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3, UltraTab4})
        Me.UltraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage3
        '
        Me.UltraTabSharedControlsPage3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage3.Name = "UltraTabSharedControlsPage3"
        Me.UltraTabSharedControlsPage3.Size = New System.Drawing.Size(448, 477)
        '
        'frmProperty
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(450, 593)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProperty"
        Me.ShowInTaskbar = False
        Me.Text = "Property - "
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.grpType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpType.ResumeLayout(False)
        Me.grpType.PerformLayout()
        CType(Me.cmbRestrictProperty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbRestrictValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPropertyOf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMandatory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrivate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpDependencies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDependencies.ResumeLayout(False)
        Me.grpDependencies.PerformLayout()
        CType(Me.cmbValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbProperty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpStateList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStateList.ResumeLayout(False)
        Me.grpStateList.PerformLayout()
        CType(Me.cmbAppendToProperty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdValueList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private cProperty As clsProperty
    Private bChanged As Boolean
    Private iSelectedIndex As Integer = -1    
    'Private dtValueList As New System.Data.DataTable


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


    Private _OwnerKey As String
    Public Property OwnerKey As String
        Get
            Return _OwnerKey
        End Get
        Set(value As String)
            If value Is Nothing Then
                chkPrivate.Text = "Parent must be applied before properties can be made Private"
                chkPrivate.Enabled = False
            Else
                chkPrivate.Text = "Private to " & Adventure.GetNameFromKey(value)
                chkPrivate.Enabled = True
            End If
            _OwnerKey = value
        End Set
    End Property


    Private Sub LoadForm(ByRef cProperty As clsProperty, ByVal bShow As Boolean)

        Me.cProperty = cProperty

        'grdValueList.DataSource = dtValueList

        With cProperty
            Text = "Property - " & .Description
            If SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0")) Then Text &= "  [" & .Key & "]"
            If .Description = "" Then Text = "New Property"
            chkMandatory.Checked = .Mandatory

            txtDescription.Text = .Description
            SetCombo(cmbPropertyOf, .PropertyOf.ToString)
            SetCombo(cmbType, .Type.ToString)

            'cmbAppendToProperty.Items.Add(Nothing, "<Do not append>")
            SetCombo(cmbProperty, .DependentKey)
            'cmbValue.Items.Add(Nothing, "<No dependent value>")
            SetCombo(cmbValue, .DependentValue)
            If cmbValue.SelectedItem Is Nothing AndAlso cmbValue.Items.Count > 0 Then cmbValue.SelectedIndex = 0
            SetCombo(cmbRestrictProperty, .RestrictProperty)
            If cmbRestrictProperty.Items.Count = 0 Then cmbRestrictProperty.Items.Add(Nothing, "<No restriction property>")
            If cmbRestrictProperty.SelectedItem Is Nothing Then cmbRestrictProperty.SelectedIndex = 0
            'cmbRestrictValue.Items.Add(Nothing, "<No restriction value>")
            SetCombo(cmbRestrictValue, .RestrictValue)
            If cmbRestrictValue.SelectedItem Is Nothing AndAlso cmbRestrictValue.Items.Count > 0 Then cmbRestrictValue.SelectedIndex = 0
            SetCombo(cmbAppendToProperty, .AppendToProperty)
            txtPopupDescription.Text = .PopupDescription

            Select Case .Type
                Case clsProperty.PropertyTypeEnum.StateList
                    txtStateList.Clear()
                    For Each sState As String In .arlStates
                        If txtStateList.Text <> "" Then txtStateList.AppendText(vbCrLf)
                        txtStateList.AppendText(sState)
                    Next
                    grpStateList.Enabled = True
                Case clsProperty.PropertyTypeEnum.ValueList
                    For Each sKey As String In .ValueList.Keys
                        grdValueList.Rows.Add(New Object() {.ValueList(sKey), sKey})
                    Next
                    grpStateList.Enabled = True
                Case Else
                    grpStateList.Enabled = False
            End Select

            ' If the property is only used on a single item, display the Private checkbox
            If .PrivateTo <> "" Then
                OwnerKey = .PrivateTo
                chkPrivate.Visible = True
            Else
                If cProperty.Key <> "" AndAlso Not chkPrivate.Visible Then
                    Dim iCount As Integer = 0
                    Dim sOwner As String = ""
                    For Each itm As clsItem In Adventure.dictAllItems.Values
                        If TypeOf itm Is clsItemWithProperties Then
                            If CType(itm, clsItemWithProperties).HasProperty(cProperty.Key) Then
                                iCount += 1
                                sOwner = itm.Key
                                If iCount > 1 Then Exit For
                            End If
                        End If
                    Next
                    If iCount = 1 Then
                        chkPrivate.Visible = True
                        OwnerKey = sOwner
                    End If
                End If
            End If
            If .PrivateTo = OwnerKey AndAlso OwnerKey <> "" Then chkPrivate.Checked = True

            Changed = False
        End With

        If bShow Then Me.Show()

        OpenForms.Add(Me)

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not ApplyProperty() Then Exit Sub
        CloseProperty(Me)
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If Not ApplyProperty() Then Exit Sub
        Changed = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then ApplyProperty()
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        CloseProperty(Me)
    End Sub


    Private Function States() As StringArrayList

        Dim arlStates As New StringArrayList

        If txtStateList.Text <> "" Then
            For Each sLine As String In txtStateList.Text.Split(Chr(10))
                If sLine.EndsWith(Chr(13)) Then sLine = sLeft(sLine, sLine.Length - 1)
                If sLine <> "" Then arlStates.Add(sLine)
            Next
        End If

        Return arlStates

    End Function


    Private Function ValidateProperty() As Boolean

        ' Ensure no duplicate values in valuelist
        If cmbType.SelectedItem IsNot Nothing AndAlso cmbType.SelectedItem.DataValue.ToString = "ValueList" Then
            Dim lValues As New List(Of String)
            For Each row As DataGridViewRow In grdValueList.Rows
                If row.Cells(1).Value IsNot Nothing Then
                    If lValues.Contains(row.Cells(1).Value.ToString) Then
                        MessageBox.Show("You must not have duplicate text values in a valuelist", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        grdValueList.Focus()
                        grdValueList.CurrentCell = row.Cells(1)
                        grdValueList.BeginEdit(True)
                        Return False
                    Else
                        lValues.Add(row.Cells(1).Value.ToString)
                    End If
                End If
            Next
        End If

        Return True
    End Function


    Private Function ApplyProperty() As Boolean

        If Not ValidateProperty() Then Return False

        With cProperty
            .Description = txtDescription.Text
            If .Description = "" Then .Description = "Unnamed Property"
            .Mandatory = chkMandatory.Checked
            If cmbProperty.SelectedItem IsNot Nothing AndAlso cmbProperty.SelectedItem.DataValue IsNot Nothing Then .DependentKey = CStr(cmbProperty.SelectedItem.DataValue) Else .DependentKey = Nothing
            If cmbValue.SelectedItem IsNot Nothing AndAlso cmbValue.SelectedItem.DataValue IsNot Nothing Then .DependentValue = CStr(cmbValue.SelectedItem.DataValue) Else .DependentValue = Nothing
            If cmbRestrictProperty.Enabled AndAlso cmbRestrictProperty.SelectedItem IsNot Nothing AndAlso cmbRestrictProperty.SelectedItem.DataValue IsNot Nothing Then .RestrictProperty = CStr(cmbRestrictProperty.SelectedItem.DataValue) Else .RestrictProperty = Nothing
            If cmbRestrictValue.Enabled AndAlso cmbRestrictValue.SelectedItem.DataValue IsNot Nothing Then .RestrictValue = CStr(cmbRestrictValue.SelectedItem.DataValue) Else .RestrictValue = Nothing
            If cmbAppendToProperty.SelectedItem IsNot Nothing AndAlso cmbAppendToProperty.SelectedItem.DataValue IsNot Nothing Then .AppendToProperty = CStr(cmbAppendToProperty.SelectedItem.DataValue) Else .AppendToProperty = Nothing
            .PropertyOf = EnumParsePropertyPropertyOf(CStr(cmbPropertyOf.SelectedItem.DataValue))
            .Type = EnumParsePropertyType(CStr(cmbType.SelectedItem.DataValue))
            .arlStates.Clear()
            .ValueList.Clear()
            Select Case .Type
                Case clsProperty.PropertyTypeEnum.StateList
                    .arlStates = States()
                    If States.Count > 0 Then .Value = States(0)
                Case clsProperty.PropertyTypeEnum.ValueList
                    For Each row As DataGridViewRow In grdValueList.Rows
                        If row.Cells(1).Value IsNot Nothing Then .ValueList.Add(row.Cells(1).Value.ToString, CInt(row.Cells(0).Value))
                    Next
            End Select

            .LastUpdated = Now
            .IsLibrary = False

            If .Key = "" Then
                .Key = .GetNewKey ' Adventure.GetNewKey("Property")
                Adventure.htblAllProperties.Add(cProperty)
            End If

            UpdateListItem(.Key, .Description)
            If chkPrivate.Checked Then .PrivateTo = OwnerKey Else .PrivateTo = ""
            .PopupDescription = txtPopupDescription.Text

            ' Now go thru all items and update their properties if they contain this one
            If .PropertyOf = clsProperty.PropertyOfEnum.Locations OrElse .PropertyOf = clsProperty.PropertyOfEnum.AnyItem Then
                For Each l As clsLocation In Adventure.htblLocations.Values
                    If .Mandatory AndAlso Not l.htblActualProperties.ContainsKey(.Key) Then
                        l.htblActualProperties.Add(.Copy)
                    End If
                    If l.htblActualProperties.ContainsKey(.Key) Then
                        Dim p As clsProperty = l.htblActualProperties(.Key)
                        Dim StringData As Description = p.StringData
                        Dim IntData As Integer = p.IntData
                        p = .Copy
                        p.Selected = True
                        p.StringData = StringData
                        p.IntData = IntData
                        l.htblActualProperties(.Key) = p
                    End If
                Next
            End If
            If .PropertyOf = clsProperty.PropertyOfEnum.Objects OrElse .PropertyOf = clsProperty.PropertyOfEnum.AnyItem Then
                For Each o As clsObject In Adventure.htblObjects.Values
                    If .Mandatory AndAlso Not o.htblActualProperties.ContainsKey(.Key) Then
                        o.htblActualProperties.Add(.Copy)
                    End If
                    If o.htblActualProperties.ContainsKey(.Key) Then
                        Dim p As clsProperty = o.htblActualProperties(.Key)
                        Dim StringData As Description = p.StringData
                        Dim IntData As Integer = p.IntData
                        p = .Copy
                        p.Selected = True
                        p.StringData = StringData
                        p.IntData = IntData
                        o.htblActualProperties(.Key) = p
                    End If
                Next
            End If
            If .PropertyOf = clsProperty.PropertyOfEnum.Characters OrElse .PropertyOf = clsProperty.PropertyOfEnum.AnyItem Then
                For Each c As clsCharacter In Adventure.htblCharacters.Values
                    If .Mandatory AndAlso Not c.htblActualProperties.ContainsKey(.Key) Then
                        c.htblActualProperties.Add(.Copy)
                    End If
                    If c.htblActualProperties.ContainsKey(.Key) Then
                        Dim p As clsProperty = c.htblActualProperties(.Key)
                        Dim StringData As Description = p.StringData
                        Dim IntData As Integer = p.IntData
                        p = .Copy
                        p.Selected = True
                        p.StringData = StringData
                        p.IntData = IntData
                        c.htblActualProperties(.Key) = p
                    End If
                Next
            End If
        End With

        Adventure.Changed = True
        Return True

    End Function


    Private Sub frmProperty_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OpenForms.Remove(Me)
    End Sub


    Private Sub frmObject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = Icon.FromHandle(My.Resources.Resources.imgProperty16.GetHicon)
        GetFormPosition(Me)
        ResizeForm()
    End Sub


    Private Sub cmbProp_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProperty.SelectionChanged, cmbRestrictProperty.SelectionChanged

        'If cmbType.SelectedItem IsNot Nothing AndAlso CStr(cmbType.SelectedItem.DataValue) = "Integer" Then Exit Sub

        Dim cmbVal, cmbProp As Infragistics.Win.UltraWinEditors.UltraComboEditor
        Dim lblVal As System.Windows.Forms.Label

        If sender Is cmbProperty Then
            cmbVal = cmbValue
            lblVal = lblValue
            cmbProp = cmbProperty
        Else            
            cmbVal = cmbRestrictValue
            lblVal = lblRestrictValue
            cmbProp = cmbRestrictProperty
        End If

        cmbVal.Items.Clear()
        cmbVal.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList

        If sender Is cmbProperty Then
            cmbVal.Items.Add(Nothing, "<No dependent value>")
        Else
            cmbVal.Items.Add(Nothing, "<No restriction value>")
        End If

        If cmbProp.SelectedItem Is Nothing OrElse cmbProp.SelectedItem.DataValue Is Nothing Then
            cmbVal.Enabled = False
            lblVal.Enabled = False
            Exit Sub
        Else
            cmbVal.Enabled = True
            lblVal.Enabled = True
        End If

        Dim prop As clsProperty = Adventure.htblAllProperties(CStr(cmbProp.SelectedItem.DataValue))

        If prop IsNot Nothing Then
            Select Case prop.Type
                Case clsProperty.PropertyTypeEnum.CharacterKey
                    For Each c As clsCharacter In Adventure.htblCharacters.Values
                        cmbVal.Items.Add(c.Key, c.Name)
                    Next
                Case clsProperty.PropertyTypeEnum.Integer
                    cmbVal.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown
                    cmbVal.Text = "0"
                Case clsProperty.PropertyTypeEnum.LocationGroupKey
                    For Each lc As clsGroup In Adventure.htblGroups.Values
                        If lc.GroupType = clsGroup.GroupTypeEnum.Locations Then cmbVal.Items.Add(lc.Key, lc.Name)
                    Next
                Case clsProperty.PropertyTypeEnum.LocationKey
                    For Each l As clsLocation In Adventure.htblLocations.Values
                        cmbVal.Items.Add(l.Key, l.ShortDescription.ToString)
                    Next
                Case clsProperty.PropertyTypeEnum.ObjectKey
                    For Each o As clsObject In Adventure.htblObjects.Values
                        cmbVal.Items.Add(o.Key, o.FullName)
                    Next
                Case clsProperty.PropertyTypeEnum.SelectionOnly
                    'cmbVal.Enabled = False
                    'lblVal.Enabled = False
                    cmbVal.Items.Clear()
                    cmbVal.Items.Add("True", sSELECTED)
                    cmbVal.Items.Add("False", sUNSELECTED)
                Case clsProperty.PropertyTypeEnum.StateList
                    For Each sState As String In prop.arlStates
                        cmbVal.Items.Add(sState)
                    Next
                Case clsProperty.PropertyTypeEnum.Text
                    cmbVal.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown
                    cmbVal.Text = ""
                Case clsProperty.PropertyTypeEnum.ValueList
                    For Each sState As String In prop.ValueList.Keys
                        cmbVal.Items.Add(prop.ValueList(sState), sState)
                    Next
            End Select
        End If

        SetCombo(cmbVal, "")

    End Sub

    Private Sub cmbType_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectionChanged

        lblRestrictProperty.Enabled = False
        lblRestrictValue.Enabled = False
        cmbRestrictValue.Enabled = False
        Select Case CStr(cmbType.SelectedItem.DataValue)
            Case "StateList"
                grpStateList.Enabled = True
                grdValueList.SendToBack()
                cmbRestrictProperty.Enabled = False
                cmbAppendToProperty.Enabled = True
                grpStateList.Text = "State List"
            Case "ValueList"
                grpStateList.Enabled = True
                grdValueList.BringToFront()
                cmbRestrictProperty.Enabled = False
                cmbAppendToProperty.Enabled = False
                grpStateList.Text = "Value List"
            Case "ObjectKey", "CharacterKey", "LocationKey"
                cmbRestrictProperty.Items.Clear()
                cmbRestrictProperty.Items.Add(Nothing, "<No restriction property>")

                For Each prop As clsProperty In Adventure.htblAllProperties.Values
                    If (CStr(cmbType.SelectedItem.DataValue) = "ObjectKey" AndAlso (prop.PropertyOf = clsProperty.PropertyOfEnum.Objects OrElse prop.PropertyOf = clsProperty.PropertyOfEnum.AnyItem)) _
                        OrElse (CStr(cmbType.SelectedItem.DataValue) = "CharacterKey" AndAlso (prop.PropertyOf = clsProperty.PropertyOfEnum.Characters OrElse prop.PropertyOf = clsProperty.PropertyOfEnum.AnyItem)) _
                        OrElse (CStr(cmbType.SelectedItem.DataValue) = "LocationKey" AndAlso (prop.PropertyOf = clsProperty.PropertyOfEnum.Locations OrElse prop.PropertyOf = clsProperty.PropertyOfEnum.AnyItem)) Then
                        cmbRestrictProperty.Items.Add(prop.Key, prop.Description)
                    End If
                Next
                cmbProp_SelectionChanged(cmbRestrictProperty, Nothing)
                grpStateList.Enabled = False
                lblRestrictProperty.Enabled = True
                cmbRestrictProperty.Enabled = True
                lblRestrictProperty.Text = "Refine by Property:"
            Case "Integer"
                cmbRestrictProperty.Items.Clear()
                cmbRestrictProperty.Items.Add(Nothing, "<Normal Integer>")

                For Each prop As clsProperty In Adventure.htblAllProperties.Values
                    If prop.Type = clsProperty.PropertyTypeEnum.ValueList Then
                        cmbRestrictProperty.Items.Add(prop.Key, prop.Description)
                    End If
                Next
                grpStateList.Enabled = False
                cmbRestrictProperty.Enabled = True
                lblRestrictProperty.Enabled = True
                lblRestrictProperty.Text = "Integer Type:"
            Case Else
                grpStateList.Enabled = False
                cmbRestrictProperty.Enabled = False
        End Select

    End Sub

  
    Private Sub StuffChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.ValueChanged, cmbProperty.ValueChanged, cmbValue.ValueChanged, cmbType.ValueChanged, cmbRestrictProperty.ValueChanged, cmbRestrictValue.ValueChanged, chkPrivate.CheckedChanged
        Changed = True
        ResizeForm()
    End Sub


    Private Sub frmProperty_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtDescription.Focus()
    End Sub

    Private Sub txtStateList_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStateList.GotFocus
        Me.AcceptButton = Nothing
    End Sub

    Private Sub txtStateList_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStateList.LostFocus
        Me.AcceptButton = btnOK
    End Sub


    Private Sub cmbPropertyOf_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbPropertyOf.SelectionChanged

        cmbProperty.Items.Clear()
        cmbProperty.Items.Add(Nothing, "<No dependent property>")
        cmbAppendToProperty.Items.Clear()
        cmbAppendToProperty.Items.Add(Nothing, "<Do not append>")

        For Each prop As clsProperty In Adventure.htblAllProperties.Values
            If (cmbPropertyOf.SelectedItem.DataValue.ToString = "Objects" AndAlso (prop.PropertyOf = clsProperty.PropertyOfEnum.Objects OrElse prop.PropertyOf = clsProperty.PropertyOfEnum.AnyItem)) _
                OrElse (cmbPropertyOf.SelectedItem.DataValue.ToString = "Characters" AndAlso (prop.PropertyOf = clsProperty.PropertyOfEnum.Characters OrElse prop.PropertyOf = clsProperty.PropertyOfEnum.AnyItem)) _
                OrElse (cmbPropertyOf.SelectedItem.DataValue.ToString = "Locations" AndAlso (prop.PropertyOf = clsProperty.PropertyOfEnum.Locations OrElse prop.PropertyOf = clsProperty.PropertyOfEnum.AnyItem)) _
                OrElse cmbPropertyOf.SelectedItem.DataValue.ToString = "AnyItem" Then
                cmbProperty.Items.Add(prop.Key, prop.Description)
                If prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.Key <> cProperty.Key Then cmbAppendToProperty.Items.Add(prop.Key, prop.Description)
            End If
        Next
        cmbProp_SelectionChanged(cmbProperty, Nothing)

    End Sub


    Private cell As DataGridViewTextBoxEditingControl

    Private Sub CheckCell(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub grdValueList_CellLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdValueList.CellLeave
        If cell IsNot Nothing Then
            RemoveHandler cell.KeyPress, AddressOf CheckCell
            cell = Nothing
        End If
    End Sub

    Private Sub grdValueList_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdValueList.CellValueChanged
        Changed = True
    End Sub

    Private Sub grdValueList_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdValueList.EditingControlShowing
        If cell Is Nothing AndAlso e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
            cell = CType(e.Control, DataGridViewTextBoxEditingControl)
            AddHandler cell.KeyPress, AddressOf CheckCell
        End If
    End Sub


    Private Sub ResizeForm()

        Dim sType As String = ""
        If cmbType.SelectedItem IsNot Nothing Then sType = cmbType.SelectedItem.DataValue.ToString
        Select Case sType
            Case "CharacterKey", "Integer", "LocationKey", "ObjectKey"
                lblRestrictProperty.Visible = True
                cmbRestrictProperty.Visible = True
                lblRestrictValue.Visible = True
                cmbRestrictValue.Visible = True
                grpType.Height = 152
            Case Else
                lblRestrictProperty.Visible = False
                cmbRestrictProperty.Visible = False
                lblRestrictValue.Visible = False
                cmbRestrictValue.Visible = False
                grpType.Height = 85
        End Select
        grpDependencies.Top = grpType.Top + grpType.Height + 10
        Select Case sType
            Case "StateList", "ValueList"
                grpStateList.Visible = True
                If grpStateList.Height < 100 Then grpStateList.Height = 100
                If sType = "StateList" Then
                    txtStateList.Visible = True
                    cmbAppendToProperty.Visible = True
                    Label2.Visible = True
                    grdValueList.Visible = False
                Else
                    txtStateList.Visible = False
                    cmbAppendToProperty.Visible = False
                    Label2.Visible = False
                    grdValueList.Visible = True
                End If
            Case Else
                grpStateList.Visible = False
        End Select
        grpStateList.Top = grpDependencies.Top + grpDependencies.Height + 10

        Dim iHeight As Integer = 140 + grpType.Height
        If grpDependencies.Visible Then iHeight += grpDependencies.Height + 10
        If chkPrivate.Visible Then iHeight += 20

        Dim iPaddingHeight As Integer = Math.Max(Me.Height - Me.ClientSize.Height, 0)

        If grpStateList.Visible Then
            MinimumSize = New Size(432, iHeight + iPaddingHeight + 170)
            MaximumSize = New Size(1600, 1200)
            grpStateList.Height = iHeight - 164
            grdValueList.Height = grpStateList.Height - 34
            txtStateList.Height = grpStateList.Height - 64
            If chkPrivate.Visible Then
                grpStateList.Height -= 20
            End If
        Else
            MinimumSize = New Size(432, iHeight + iPaddingHeight)
            MaximumSize = New Size(1600, iHeight + iPaddingHeight)
        End If

    End Sub


    Private Sub frmProperty_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        ShowHelp(Me, "Properties")
    End Sub

End Class