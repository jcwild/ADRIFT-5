Public Class frmAction
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Command As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        bLoadingAction = True
        Me.sCommand = Command
        InitializeComponent()
        bLoadingAction = False
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
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents cmbCharacterMoveTo As AutoCompleteCombo
    Friend WithEvents cmbCharacterKey2 As AutoCompleteCombo
    Friend WithEvents cmbCharacterKey1 As AutoCompleteCombo
    Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl7 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents tabsActions As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents cmbObjectKey2 As AutoCompleteCombo
    Friend WithEvents cmbObjectKey1 As AutoCompleteCombo
    Friend WithEvents cmbObjectMoveTo As AutoCompleteCombo
    Friend WithEvents lblSet As System.Windows.Forms.Label
    Friend WithEvents cmbPropertyKey2 As AutoCompleteCombo
    Friend WithEvents lblFor As System.Windows.Forms.Label
    Friend WithEvents lblLoop As System.Windows.Forms.Label
    Friend WithEvents cmbVariable As AutoCompleteCombo
    Friend WithEvents lblNext As System.Windows.Forms.Label
    Friend WithEvents lblTo2 As System.Windows.Forms.Label
    Friend WithEvents txtLoopTo As System.Windows.Forms.TextBox
    Friend WithEvents txtLoopFrom As System.Windows.Forms.TextBox
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents cmbIndex As AutoCompleteCombo
    Friend WithEvents cmbVariableArray As AutoCompleteCombo
    Friend WithEvents cmbIndexEdit As AutoCompleteCombo
    Friend WithEvents cmbTasks As AutoCompleteCombo
    Friend WithEvents cmbWhatT As AutoCompleteCombo
    Friend WithEvents btnParams As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Expression As ADRIFT.Expression
    Friend WithEvents isPropertyKey1 As ADRIFT.ItemSelector
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbEndGame As AutoCompleteCombo
    Friend WithEvents cmbObjectMoveWhat As AutoCompleteCombo
    Friend WithEvents cmbObjectWhat As AutoCompleteCombo
    Friend WithEvents lblObjectsWithValue As System.Windows.Forms.Label
    Friend WithEvents cmbObjectPropertyValue As ADRIFT.PropertyValue
    Friend WithEvents cmbCharacterPropertyValue As ADRIFT.PropertyValue
    Friend WithEvents lblCharactersWithValue As System.Windows.Forms.Label
    Friend WithEvents cmbCharacterMoveWho As AutoCompleteCombo
    Friend WithEvents cmbCharacterWhat As AutoCompleteCombo
    Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents cmbLocationKey2 As AutoCompleteCombo
    Friend WithEvents cmbLocationMoveWhat As AutoCompleteCombo
    Friend WithEvents cmbLocationWhat As AutoCompleteCombo
    Friend WithEvents cmbLocationMoveTo As AutoCompleteCombo
    Friend WithEvents cmbLocationKey1 As AutoCompleteCombo
    Friend WithEvents cmbLocationPropertyValue As ADRIFT.PropertyValue
    Friend WithEvents lblLocationsWithValue As System.Windows.Forms.Label
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents chkLoop As System.Windows.Forms.CheckBox
    Friend WithEvents cmbPropertyValue As ADRIFT.PropertyValue
    Friend WithEvents UltraTabPageControl8 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents lblConvAbout As System.Windows.Forms.Label
    Friend WithEvents cmbAskWho As AutoCompleteCombo
    Friend WithEvents cmbWhatConv As AutoCompleteCombo
    Friend WithEvents txtConvTopic As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cmbVariableSet As AutoCompleteCombo
    Friend WithEvents UltraTabPageControl9 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents expTurns As ADRIFT.Expression
    Friend WithEvents lblTo As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem17 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab7 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab9 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab8 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAction))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.lblObjectsWithValue = New System.Windows.Forms.Label()
        Me.cmbObjectMoveWhat = New AutoCompleteCombo()
        Me.cmbObjectWhat = New AutoCompleteCombo()
        Me.cmbObjectKey2 = New AutoCompleteCombo()
        Me.cmbObjectMoveTo = New AutoCompleteCombo()
        Me.cmbObjectKey1 = New AutoCompleteCombo()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.lblCharactersWithValue = New System.Windows.Forms.Label()
        Me.cmbCharacterMoveWho = New AutoCompleteCombo()
        Me.cmbCharacterWhat = New AutoCompleteCombo()
        Me.cmbCharacterMoveTo = New AutoCompleteCombo()
        Me.cmbCharacterKey2 = New AutoCompleteCombo()
        Me.cmbCharacterKey1 = New AutoCompleteCombo()
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.lblLocationsWithValue = New System.Windows.Forms.Label()
        Me.cmbLocationKey2 = New AutoCompleteCombo()
        Me.cmbLocationMoveWhat = New AutoCompleteCombo()
        Me.cmbLocationWhat = New AutoCompleteCombo()
        Me.cmbLocationMoveTo = New AutoCompleteCombo()
        Me.cmbLocationKey1 = New AutoCompleteCombo()
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btnParams = New Infragistics.Win.Misc.UltraButton()
        Me.cmbTasks = New AutoCompleteCombo()
        Me.cmbWhatT = New AutoCompleteCombo()
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.cmbVariableSet = New AutoCompleteCombo()
        Me.cmbIndexEdit = New AutoCompleteCombo()
        Me.cmbVariable = New AutoCompleteCombo()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.cmbIndex = New AutoCompleteCombo()
        Me.cmbVariableArray = New AutoCompleteCombo()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblLoop = New System.Windows.Forms.Label()
        Me.lblNext = New System.Windows.Forms.Label()
        Me.lblTo2 = New System.Windows.Forms.Label()
        Me.txtLoopTo = New System.Windows.Forms.TextBox()
        Me.txtLoopFrom = New System.Windows.Forms.TextBox()
        Me.lblFor = New System.Windows.Forms.Label()
        Me.UltraTabPageControl8 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.cmbAskWho = New AutoCompleteCombo()
        Me.txtConvTopic = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblConvAbout = New System.Windows.Forms.Label()
        Me.cmbWhatConv = New AutoCompleteCombo()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblSet = New System.Windows.Forms.Label()
        Me.cmbPropertyKey2 = New AutoCompleteCombo()
        Me.UltraTabPageControl7 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.cmbEndGame = New AutoCompleteCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkLoop = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.tabsActions = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.UltraTabPageControl9 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbObjectPropertyValue = New ADRIFT.PropertyValue()
        Me.cmbCharacterPropertyValue = New ADRIFT.PropertyValue()
        Me.cmbPropertyValue = New ADRIFT.PropertyValue()
        Me.isPropertyKey1 = New ADRIFT.ItemSelector()
        Me.Expression = New ADRIFT.Expression()
        Me.cmbLocationPropertyValue = New ADRIFT.PropertyValue()
        Me.expTurns = New ADRIFT.Expression()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.cmbObjectMoveWhat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbObjectWhat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbObjectKey2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbObjectMoveTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbObjectKey1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.cmbCharacterMoveWho, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCharacterWhat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCharacterMoveTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCharacterKey2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCharacterKey1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl5.SuspendLayout()
        CType(Me.cmbLocationKey2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLocationMoveWhat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLocationWhat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLocationMoveTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLocationKey1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl6.SuspendLayout()
        CType(Me.cmbTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbWhatT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl4.SuspendLayout()
        CType(Me.cmbVariableSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIndexEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbVariable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbVariableArray, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl8.SuspendLayout()
        CType(Me.cmbAskWho, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConvTopic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbWhatConv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.cmbPropertyKey2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl7.SuspendLayout()
        CType(Me.cmbEndGame, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabsActions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsActions.SuspendLayout()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraStatusBar1.SuspendLayout()
        Me.UltraTabPageControl9.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.cmbObjectPropertyValue)
        Me.UltraTabPageControl1.Controls.Add(Me.lblObjectsWithValue)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbObjectMoveWhat)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbObjectWhat)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbObjectKey2)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbObjectMoveTo)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbObjectKey1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(886, 38)
        '
        'lblObjectsWithValue
        '
        Me.lblObjectsWithValue.BackColor = System.Drawing.Color.Transparent
        Me.lblObjectsWithValue.Location = New System.Drawing.Point(525, 13)
        Me.lblObjectsWithValue.Name = "lblObjectsWithValue"
        Me.lblObjectsWithValue.Size = New System.Drawing.Size(59, 16)
        Me.lblObjectsWithValue.TabIndex = 11
        Me.lblObjectsWithValue.Text = "with value"
        Me.lblObjectsWithValue.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblObjectsWithValue.Visible = False
        '
        'cmbObjectMoveWhat
        '
        Me.cmbObjectMoveWhat.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbObjectMoveWhat.Location = New System.Drawing.Point(79, 9)
        Me.cmbObjectMoveWhat.Name = "cmbObjectMoveWhat"
        Me.cmbObjectMoveWhat.Size = New System.Drawing.Size(147, 21)
        Me.cmbObjectMoveWhat.TabIndex = 7
        '
        'cmbObjectWhat
        '
        Me.cmbObjectWhat.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbObjectWhat.Location = New System.Drawing.Point(11, 9)
        Me.cmbObjectWhat.Name = "cmbObjectWhat"
        Me.cmbObjectWhat.Size = New System.Drawing.Size(69, 21)
        Me.cmbObjectWhat.TabIndex = 6
        '
        'cmbObjectKey2
        '
        Me.cmbObjectKey2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbObjectKey2.Location = New System.Drawing.Point(936, 9)
        Me.cmbObjectKey2.Name = "cmbObjectKey2"
        Me.cmbObjectKey2.Size = New System.Drawing.Size(199, 21)
        Me.cmbObjectKey2.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbObjectKey2.TabIndex = 5
        '
        'cmbObjectMoveTo
        '
        Me.cmbObjectMoveTo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "InsideObject"
        ValueListItem1.DisplayText = "inside object"
        ValueListItem2.DataValue = "OntoObject"
        ValueListItem2.DisplayText = "onto object"
        ValueListItem3.DataValue = "ToCarriedBy"
        ValueListItem3.DisplayText = "to held by"
        ValueListItem4.DataValue = "ToLocation"
        ValueListItem4.DisplayText = "to location"
        ValueListItem5.DataValue = "ToLocationGroup"
        ValueListItem5.DisplayText = "to location group"
        ValueListItem6.DataValue = "ToSameLocationAs"
        ValueListItem6.DisplayText = "to same location as"
        ValueListItem7.DataValue = "ToWornBy"
        ValueListItem7.DisplayText = "to worn by"
        Me.cmbObjectMoveTo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3, ValueListItem4, ValueListItem5, ValueListItem6, ValueListItem7})
        Me.cmbObjectMoveTo.Location = New System.Drawing.Point(760, 9)
        Me.cmbObjectMoveTo.Name = "cmbObjectMoveTo"
        Me.cmbObjectMoveTo.Size = New System.Drawing.Size(170, 21)
        Me.cmbObjectMoveTo.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbObjectMoveTo.TabIndex = 3
        '
        'cmbObjectKey1
        '
        Me.cmbObjectKey1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbObjectKey1.Location = New System.Drawing.Point(225, 9)
        Me.cmbObjectKey1.Name = "cmbObjectKey1"
        Me.cmbObjectKey1.Size = New System.Drawing.Size(219, 21)
        Me.cmbObjectKey1.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbObjectKey1.TabIndex = 2
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.cmbCharacterPropertyValue)
        Me.UltraTabPageControl2.Controls.Add(Me.lblCharactersWithValue)
        Me.UltraTabPageControl2.Controls.Add(Me.cmbCharacterMoveWho)
        Me.UltraTabPageControl2.Controls.Add(Me.cmbCharacterWhat)
        Me.UltraTabPageControl2.Controls.Add(Me.cmbCharacterMoveTo)
        Me.UltraTabPageControl2.Controls.Add(Me.cmbCharacterKey2)
        Me.UltraTabPageControl2.Controls.Add(Me.cmbCharacterKey1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(886, 38)
        '
        'lblCharactersWithValue
        '
        Me.lblCharactersWithValue.BackColor = System.Drawing.Color.Transparent
        Me.lblCharactersWithValue.Location = New System.Drawing.Point(458, 13)
        Me.lblCharactersWithValue.Name = "lblCharactersWithValue"
        Me.lblCharactersWithValue.Size = New System.Drawing.Size(59, 16)
        Me.lblCharactersWithValue.TabIndex = 13
        Me.lblCharactersWithValue.Text = "with value"
        Me.lblCharactersWithValue.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblCharactersWithValue.Visible = False
        '
        'cmbCharacterMoveWho
        '
        Me.cmbCharacterMoveWho.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbCharacterMoveWho.Location = New System.Drawing.Point(79, 9)
        Me.cmbCharacterMoveWho.Name = "cmbCharacterMoveWho"
        Me.cmbCharacterMoveWho.Size = New System.Drawing.Size(147, 21)
        Me.cmbCharacterMoveWho.TabIndex = 11
        '
        'cmbCharacterWhat
        '
        Me.cmbCharacterWhat.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbCharacterWhat.Location = New System.Drawing.Point(11, 9)
        Me.cmbCharacterWhat.Name = "cmbCharacterWhat"
        Me.cmbCharacterWhat.Size = New System.Drawing.Size(69, 21)
        Me.cmbCharacterWhat.TabIndex = 10
        '
        'cmbCharacterMoveTo
        '
        Me.cmbCharacterMoveTo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbCharacterMoveTo.Location = New System.Drawing.Point(712, 9)
        Me.cmbCharacterMoveTo.Name = "cmbCharacterMoveTo"
        Me.cmbCharacterMoveTo.Size = New System.Drawing.Size(168, 21)
        Me.cmbCharacterMoveTo.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbCharacterMoveTo.TabIndex = 9
        '
        'cmbCharacterKey2
        '
        Me.cmbCharacterKey2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbCharacterKey2.Location = New System.Drawing.Point(900, 9)
        Me.cmbCharacterKey2.MaxDropDownItems = 12
        Me.cmbCharacterKey2.Name = "cmbCharacterKey2"
        Me.cmbCharacterKey2.Size = New System.Drawing.Size(122, 21)
        Me.cmbCharacterKey2.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbCharacterKey2.TabIndex = 8
        '
        'cmbCharacterKey1
        '
        Me.cmbCharacterKey1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbCharacterKey1.Location = New System.Drawing.Point(225, 9)
        Me.cmbCharacterKey1.Name = "cmbCharacterKey1"
        Me.cmbCharacterKey1.Size = New System.Drawing.Size(192, 21)
        Me.cmbCharacterKey1.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbCharacterKey1.TabIndex = 6
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.cmbLocationPropertyValue)
        Me.UltraTabPageControl5.Controls.Add(Me.lblLocationsWithValue)
        Me.UltraTabPageControl5.Controls.Add(Me.cmbLocationKey2)
        Me.UltraTabPageControl5.Controls.Add(Me.cmbLocationMoveWhat)
        Me.UltraTabPageControl5.Controls.Add(Me.cmbLocationWhat)
        Me.UltraTabPageControl5.Controls.Add(Me.cmbLocationMoveTo)
        Me.UltraTabPageControl5.Controls.Add(Me.cmbLocationKey1)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(886, 38)
        '
        'lblLocationsWithValue
        '
        Me.lblLocationsWithValue.BackColor = System.Drawing.Color.Transparent
        Me.lblLocationsWithValue.Location = New System.Drawing.Point(508, 13)
        Me.lblLocationsWithValue.Name = "lblLocationsWithValue"
        Me.lblLocationsWithValue.Size = New System.Drawing.Size(59, 16)
        Me.lblLocationsWithValue.TabIndex = 13
        Me.lblLocationsWithValue.Text = "with value"
        Me.lblLocationsWithValue.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblLocationsWithValue.Visible = False
        '
        'cmbLocationKey2
        '
        Me.cmbLocationKey2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbLocationKey2.Location = New System.Drawing.Point(936, 9)
        Me.cmbLocationKey2.Name = "cmbLocationKey2"
        Me.cmbLocationKey2.Size = New System.Drawing.Size(199, 21)
        Me.cmbLocationKey2.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbLocationKey2.TabIndex = 12
        '
        'cmbLocationMoveWhat
        '
        Me.cmbLocationMoveWhat.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbLocationMoveWhat.Location = New System.Drawing.Point(79, 9)
        Me.cmbLocationMoveWhat.Name = "cmbLocationMoveWhat"
        Me.cmbLocationMoveWhat.Size = New System.Drawing.Size(153, 21)
        Me.cmbLocationMoveWhat.TabIndex = 11
        '
        'cmbLocationWhat
        '
        Me.cmbLocationWhat.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbLocationWhat.Location = New System.Drawing.Point(11, 9)
        Me.cmbLocationWhat.Name = "cmbLocationWhat"
        Me.cmbLocationWhat.Size = New System.Drawing.Size(69, 21)
        Me.cmbLocationWhat.TabIndex = 10
        '
        'cmbLocationMoveTo
        '
        Me.cmbLocationMoveTo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem8.DataValue = "InsideObject"
        ValueListItem8.DisplayText = "inside object"
        ValueListItem9.DataValue = "OntoObject"
        ValueListItem9.DisplayText = "onto object"
        ValueListItem10.DataValue = "ToCarriedBy"
        ValueListItem10.DisplayText = "to held by"
        ValueListItem11.DataValue = "ToLocation"
        ValueListItem11.DisplayText = "to location"
        ValueListItem12.DataValue = "ToLocationGroup"
        ValueListItem12.DisplayText = "to location group"
        ValueListItem13.DataValue = "ToSameLocationAs"
        ValueListItem13.DisplayText = "to same location as"
        ValueListItem14.DataValue = "ToWornBy"
        ValueListItem14.DisplayText = "to worn by"
        Me.cmbLocationMoveTo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem8, ValueListItem9, ValueListItem10, ValueListItem11, ValueListItem12, ValueListItem13, ValueListItem14})
        Me.cmbLocationMoveTo.Location = New System.Drawing.Point(760, 9)
        Me.cmbLocationMoveTo.Name = "cmbLocationMoveTo"
        Me.cmbLocationMoveTo.Size = New System.Drawing.Size(170, 21)
        Me.cmbLocationMoveTo.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbLocationMoveTo.TabIndex = 9
        '
        'cmbLocationKey1
        '
        Me.cmbLocationKey1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbLocationKey1.Location = New System.Drawing.Point(231, 9)
        Me.cmbLocationKey1.Name = "cmbLocationKey1"
        Me.cmbLocationKey1.Size = New System.Drawing.Size(219, 21)
        Me.cmbLocationKey1.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbLocationKey1.TabIndex = 8
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.btnParams)
        Me.UltraTabPageControl6.Controls.Add(Me.cmbTasks)
        Me.UltraTabPageControl6.Controls.Add(Me.cmbWhatT)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(886, 38)
        '
        'btnParams
        '
        Me.btnParams.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnParams.Location = New System.Drawing.Point(801, 9)
        Me.btnParams.Name = "btnParams"
        Me.btnParams.Size = New System.Drawing.Size(76, 21)
        Me.btnParams.TabIndex = 11
        Me.btnParams.Text = "params"
        Me.btnParams.Visible = False
        '
        'cmbTasks
        '
        Me.cmbTasks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTasks.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbTasks.Location = New System.Drawing.Point(125, 9)
        Me.cmbTasks.MaxDropDownItems = 12
        Me.cmbTasks.Name = "cmbTasks"
        Me.cmbTasks.Size = New System.Drawing.Size(694, 21)
        Me.cmbTasks.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbTasks.TabIndex = 10
        '
        'cmbWhatT
        '
        Me.cmbWhatT.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem15.DataValue = "Execute"
        ValueListItem15.DisplayText = "Run Task"
        ValueListItem16.DataValue = "Unset"
        ValueListItem16.DisplayText = "Unset Task"
        Me.cmbWhatT.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem15, ValueListItem16})
        Me.cmbWhatT.Location = New System.Drawing.Point(11, 9)
        Me.cmbWhatT.Name = "cmbWhatT"
        Me.cmbWhatT.Size = New System.Drawing.Size(115, 21)
        Me.cmbWhatT.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbWhatT.TabIndex = 9
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.cmbVariableSet)
        Me.UltraTabPageControl4.Controls.Add(Me.Expression)
        Me.UltraTabPageControl4.Controls.Add(Me.cmbIndexEdit)
        Me.UltraTabPageControl4.Controls.Add(Me.cmbVariable)
        Me.UltraTabPageControl4.Controls.Add(Me.lblRight)
        Me.UltraTabPageControl4.Controls.Add(Me.cmbIndex)
        Me.UltraTabPageControl4.Controls.Add(Me.cmbVariableArray)
        Me.UltraTabPageControl4.Controls.Add(Me.lblLeft)
        Me.UltraTabPageControl4.Controls.Add(Me.lblLoop)
        Me.UltraTabPageControl4.Controls.Add(Me.lblNext)
        Me.UltraTabPageControl4.Controls.Add(Me.lblTo2)
        Me.UltraTabPageControl4.Controls.Add(Me.txtLoopTo)
        Me.UltraTabPageControl4.Controls.Add(Me.txtLoopFrom)
        Me.UltraTabPageControl4.Controls.Add(Me.lblFor)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(886, 38)
        '
        'cmbVariableSet
        '
        Me.cmbVariableSet.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbVariableSet.Location = New System.Drawing.Point(11, 9)
        Me.cmbVariableSet.Name = "cmbVariableSet"
        Me.cmbVariableSet.Size = New System.Drawing.Size(74, 21)
        Me.cmbVariableSet.TabIndex = 16
        '
        'cmbIndexEdit
        '
        Appearance1.TextHAlignAsString = "Right"
        Me.cmbIndexEdit.Appearance = Appearance1
        ValueListItem17.DataValue = "ValueListItem1"
        ValueListItem17.DisplayText = "Select a variable"
        Me.cmbIndexEdit.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem17})
        Me.cmbIndexEdit.Location = New System.Drawing.Point(621, 6)
        Me.cmbIndexEdit.Name = "cmbIndexEdit"
        Me.cmbIndexEdit.Size = New System.Drawing.Size(125, 21)
        Me.cmbIndexEdit.TabIndex = 14
        Me.cmbIndexEdit.Text = "0"
        Me.cmbIndexEdit.Visible = False
        '
        'cmbVariable
        '
        Me.cmbVariable.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbVariable.Location = New System.Drawing.Point(84, 9)
        Me.cmbVariable.Name = "cmbVariable"
        Me.cmbVariable.Size = New System.Drawing.Size(152, 21)
        Me.cmbVariable.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbVariable.TabIndex = 6
        '
        'lblRight
        '
        Me.lblRight.AutoSize = True
        Me.lblRight.BackColor = System.Drawing.Color.Transparent
        Me.lblRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRight.Location = New System.Drawing.Point(302, 11)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(15, 16)
        Me.lblRight.TabIndex = 11
        Me.lblRight.Text = "="
        '
        'cmbIndex
        '
        Me.cmbIndex.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbIndex.Location = New System.Drawing.Point(242, 9)
        Me.cmbIndex.Name = "cmbIndex"
        Me.cmbIndex.Size = New System.Drawing.Size(84, 21)
        Me.cmbIndex.TabIndex = 9
        Me.cmbIndex.Visible = False
        '
        'cmbVariableArray
        '
        Me.cmbVariableArray.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbVariableArray.Location = New System.Drawing.Point(108, 59)
        Me.cmbVariableArray.Name = "cmbVariableArray"
        Me.cmbVariableArray.Size = New System.Drawing.Size(125, 21)
        Me.cmbVariableArray.TabIndex = 12
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = True
        Me.lblLeft.BackColor = System.Drawing.Color.Transparent
        Me.lblLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeft.Location = New System.Drawing.Point(162, 11)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(12, 16)
        Me.lblLeft.TabIndex = 10
        Me.lblLeft.Text = "["
        Me.lblLeft.Visible = False
        '
        'lblLoop
        '
        Me.lblLoop.AutoSize = True
        Me.lblLoop.BackColor = System.Drawing.Color.Transparent
        Me.lblLoop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoop.Location = New System.Drawing.Point(263, 61)
        Me.lblLoop.Name = "lblLoop"
        Me.lblLoop.Size = New System.Drawing.Size(63, 16)
        Me.lblLoop.TabIndex = 7
        Me.lblLoop.Text = "[Loop]   ="
        Me.lblLoop.Visible = False
        '
        'lblNext
        '
        Me.lblNext.AutoSize = True
        Me.lblNext.BackColor = System.Drawing.Color.Transparent
        Me.lblNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNext.Location = New System.Drawing.Point(22, 98)
        Me.lblNext.Name = "lblNext"
        Me.lblNext.Size = New System.Drawing.Size(78, 16)
        Me.lblNext.TabIndex = 4
        Me.lblNext.Text = "NEXT Loop"
        Me.lblNext.Visible = False
        '
        'lblTo2
        '
        Me.lblTo2.AutoSize = True
        Me.lblTo2.BackColor = System.Drawing.Color.Transparent
        Me.lblTo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo2.Location = New System.Drawing.Point(190, 23)
        Me.lblTo2.Name = "lblTo2"
        Me.lblTo2.Size = New System.Drawing.Size(27, 16)
        Me.lblTo2.TabIndex = 3
        Me.lblTo2.Text = "TO"
        Me.lblTo2.Visible = False
        '
        'txtLoopTo
        '
        Me.txtLoopTo.Location = New System.Drawing.Point(225, 23)
        Me.txtLoopTo.Name = "txtLoopTo"
        Me.txtLoopTo.Size = New System.Drawing.Size(71, 20)
        Me.txtLoopTo.TabIndex = 2
        Me.txtLoopTo.Text = "0"
        Me.txtLoopTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLoopTo.Visible = False
        '
        'txtLoopFrom
        '
        Me.txtLoopFrom.Location = New System.Drawing.Point(108, 22)
        Me.txtLoopFrom.Name = "txtLoopFrom"
        Me.txtLoopFrom.Size = New System.Drawing.Size(71, 20)
        Me.txtLoopFrom.TabIndex = 1
        Me.txtLoopFrom.Text = "0"
        Me.txtLoopFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLoopFrom.Visible = False
        '
        'lblFor
        '
        Me.lblFor.AutoSize = True
        Me.lblFor.BackColor = System.Drawing.Color.Transparent
        Me.lblFor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFor.Location = New System.Drawing.Point(22, 23)
        Me.lblFor.Name = "lblFor"
        Me.lblFor.Size = New System.Drawing.Size(80, 16)
        Me.lblFor.TabIndex = 0
        Me.lblFor.Text = "FOR Loop ="
        Me.lblFor.Visible = False
        '
        'UltraTabPageControl8
        '
        Me.UltraTabPageControl8.Controls.Add(Me.cmbAskWho)
        Me.UltraTabPageControl8.Controls.Add(Me.txtConvTopic)
        Me.UltraTabPageControl8.Controls.Add(Me.lblConvAbout)
        Me.UltraTabPageControl8.Controls.Add(Me.cmbWhatConv)
        Me.UltraTabPageControl8.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl8.Name = "UltraTabPageControl8"
        Me.UltraTabPageControl8.Size = New System.Drawing.Size(886, 38)
        '
        'cmbAskWho
        '
        Me.cmbAskWho.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbAskWho.Location = New System.Drawing.Point(157, 9)
        Me.cmbAskWho.Name = "cmbAskWho"
        Me.cmbAskWho.Size = New System.Drawing.Size(147, 21)
        Me.cmbAskWho.TabIndex = 13
        '
        'txtConvTopic
        '
        Me.txtConvTopic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConvTopic.Location = New System.Drawing.Point(347, 9)
        Me.txtConvTopic.Name = "txtConvTopic"
        Me.txtConvTopic.Size = New System.Drawing.Size(527, 21)
        Me.txtConvTopic.TabIndex = 17
        '
        'lblConvAbout
        '
        Me.lblConvAbout.BackColor = System.Drawing.Color.Transparent
        Me.lblConvAbout.Location = New System.Drawing.Point(309, 13)
        Me.lblConvAbout.Name = "lblConvAbout"
        Me.lblConvAbout.Size = New System.Drawing.Size(45, 16)
        Me.lblConvAbout.TabIndex = 16
        Me.lblConvAbout.Text = "about"
        '
        'cmbWhatConv
        '
        Me.cmbWhatConv.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbWhatConv.Location = New System.Drawing.Point(11, 9)
        Me.cmbWhatConv.Name = "cmbWhatConv"
        Me.cmbWhatConv.Size = New System.Drawing.Size(147, 21)
        Me.cmbWhatConv.TabIndex = 12
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.cmbPropertyValue)
        Me.UltraTabPageControl3.Controls.Add(Me.isPropertyKey1)
        Me.UltraTabPageControl3.Controls.Add(Me.lblTo)
        Me.UltraTabPageControl3.Controls.Add(Me.lblSet)
        Me.UltraTabPageControl3.Controls.Add(Me.cmbPropertyKey2)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(886, 38)
        '
        'lblTo
        '
        Me.lblTo.BackColor = System.Drawing.Color.Transparent
        Me.lblTo.Location = New System.Drawing.Point(362, 13)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(16, 16)
        Me.lblTo.TabIndex = 15
        Me.lblTo.Text = "to"
        '
        'lblSet
        '
        Me.lblSet.BackColor = System.Drawing.Color.Transparent
        Me.lblSet.Location = New System.Drawing.Point(8, 13)
        Me.lblSet.Name = "lblSet"
        Me.lblSet.Size = New System.Drawing.Size(32, 16)
        Me.lblSet.TabIndex = 14
        Me.lblSet.Text = "Set"
        '
        'cmbPropertyKey2
        '
        Me.cmbPropertyKey2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbPropertyKey2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbPropertyKey2.Location = New System.Drawing.Point(228, 9)
        Me.cmbPropertyKey2.MaxDropDownItems = 12
        Me.cmbPropertyKey2.Name = "cmbPropertyKey2"
        Me.cmbPropertyKey2.Size = New System.Drawing.Size(122, 21)
        Me.cmbPropertyKey2.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbPropertyKey2.TabIndex = 12
        '
        'UltraTabPageControl7
        '
        Me.UltraTabPageControl7.Controls.Add(Me.cmbEndGame)
        Me.UltraTabPageControl7.Controls.Add(Me.Label2)
        Me.UltraTabPageControl7.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl7.Name = "UltraTabPageControl7"
        Me.UltraTabPageControl7.Size = New System.Drawing.Size(886, 38)
        '
        'cmbEndGame
        '
        Me.cmbEndGame.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbEndGame.Location = New System.Drawing.Point(89, 9)
        Me.cmbEndGame.Name = "cmbEndGame"
        Me.cmbEndGame.Size = New System.Drawing.Size(188, 21)
        Me.cmbEndGame.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(5, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "End the game:"
        '
        'chkLoop
        '
        Me.chkLoop.AutoSize = True
        Me.chkLoop.BackColor = System.Drawing.Color.Transparent
        Me.chkLoop.Location = New System.Drawing.Point(15, 17)
        Me.chkLoop.Name = "chkLoop"
        Me.chkLoop.Size = New System.Drawing.Size(88, 17)
        Me.chkLoop.TabIndex = 12
        Me.chkLoop.Text = "I need a loop"
        Me.chkLoop.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(788, 72)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(692, 72)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'tabsActions
        '
        Me.tabsActions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabsActions.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.tabsActions.Controls.Add(Me.UltraTabPageControl1)
        Me.tabsActions.Controls.Add(Me.UltraTabPageControl2)
        Me.tabsActions.Controls.Add(Me.UltraTabPageControl3)
        Me.tabsActions.Controls.Add(Me.UltraTabPageControl4)
        Me.tabsActions.Controls.Add(Me.UltraTabPageControl6)
        Me.tabsActions.Controls.Add(Me.UltraTabPageControl7)
        Me.tabsActions.Controls.Add(Me.UltraTabPageControl5)
        Me.tabsActions.Controls.Add(Me.UltraTabPageControl8)
        Me.tabsActions.Controls.Add(Me.UltraTabPageControl9)
        Me.tabsActions.Location = New System.Drawing.Point(0, 0)
        Me.tabsActions.Name = "tabsActions"
        Me.tabsActions.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.tabsActions.Size = New System.Drawing.Size(890, 64)
        Me.tabsActions.TabIndex = 8
        Appearance2.Image = Global.ADRIFT.My.Resources.imgObjectDynamic16
        UltraTab1.Appearance = Appearance2
        UltraTab1.Key = "MoveObjects"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Move Objects"
        Appearance3.Image = Global.ADRIFT.My.Resources.imgCharacter16
        UltraTab2.Appearance = Appearance3
        UltraTab2.Key = "MoveCharacters"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Move Characters"
        Appearance4.Image = Global.ADRIFT.My.Resources.imgLocation16
        UltraTab3.Appearance = Appearance4
        UltraTab3.Key = "Locations"
        UltraTab3.TabPage = Me.UltraTabPageControl5
        UltraTab3.Text = "Locations"
        Appearance5.Image = Global.ADRIFT.My.Resources.imgTaskSpecific16
        UltraTab4.Appearance = Appearance5
        UltraTab4.Key = "Tasks"
        UltraTab4.TabPage = Me.UltraTabPageControl6
        UltraTab4.Text = "Tasks"
        Appearance6.Image = Global.ADRIFT.My.Resources.imgVariable16
        UltraTab5.Appearance = Appearance6
        UltraTab5.Key = "Variables"
        UltraTab5.TabPage = Me.UltraTabPageControl4
        UltraTab5.Text = "Variables"
        Appearance7.Image = Global.ADRIFT.My.Resources.imgRefresh16
        UltraTab6.Appearance = Appearance7
        UltraTab6.Key = "Conversation"
        UltraTab6.TabPage = Me.UltraTabPageControl8
        UltraTab6.Text = "Conversation"
        Appearance8.Image = Global.ADRIFT.My.Resources.imgProperty16
        UltraTab7.Appearance = Appearance8
        UltraTab7.Key = "SetProperties"
        UltraTab7.TabPage = Me.UltraTabPageControl3
        UltraTab7.Text = "Set Properties"
        Appearance10.Image = Global.ADRIFT.My.Resources.imgEvent16
        UltraTab9.Appearance = Appearance10
        UltraTab9.Key = "Time"
        UltraTab9.TabPage = Me.UltraTabPageControl9
        UltraTab9.Text = "Time"
        Appearance9.Image = Global.ADRIFT.My.Resources.imgCancel16
        UltraTab8.Appearance = Appearance9
        UltraTab8.Key = "EndGame"
        UltraTab8.TabPage = Me.UltraTabPageControl7
        UltraTab8.Text = "End Game"
        Me.tabsActions.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3, UltraTab4, UltraTab5, UltraTab6, UltraTab7, UltraTab9, UltraTab8})
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(886, 38)
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Controls.Add(Me.chkLoop)
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 64)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        UltraStatusPanel1.Control = Me.chkLoop
        UltraStatusPanel1.Padding = New System.Drawing.Size(14, 14)
        UltraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer
        UltraStatusPanel1.Visible = False
        Me.UltraStatusBar1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1})
        Me.UltraStatusBar1.Size = New System.Drawing.Size(890, 48)
        Me.UltraStatusBar1.TabIndex = 10
        Me.UltraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'UltraTabPageControl9
        '
        Me.UltraTabPageControl9.Controls.Add(Me.Label3)
        Me.UltraTabPageControl9.Controls.Add(Me.Label1)
        Me.UltraTabPageControl9.Controls.Add(Me.expTurns)
        Me.UltraTabPageControl9.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl9.Name = "UltraTabPageControl9"
        Me.UltraTabPageControl9.Size = New System.Drawing.Size(886, 38)
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Skip"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(186, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "turns"
        '
        'cmbObjectPropertyValue
        '
        Me.cmbObjectPropertyValue.BackColor = System.Drawing.Color.Transparent
        Me.cmbObjectPropertyValue.Location = New System.Drawing.Point(583, 9)
        Me.cmbObjectPropertyValue.Name = "cmbObjectPropertyValue"
        Me.cmbObjectPropertyValue.PropertyKey = ""
        Me.cmbObjectPropertyValue.Size = New System.Drawing.Size(171, 21)
        Me.cmbObjectPropertyValue.TabIndex = 12
        Me.cmbObjectPropertyValue.Value = Nothing
        Me.cmbObjectPropertyValue.Visible = False
        '
        'cmbCharacterPropertyValue
        '
        Me.cmbCharacterPropertyValue.BackColor = System.Drawing.Color.Transparent
        Me.cmbCharacterPropertyValue.Location = New System.Drawing.Point(516, 9)
        Me.cmbCharacterPropertyValue.Name = "cmbCharacterPropertyValue"
        Me.cmbCharacterPropertyValue.PropertyKey = ""
        Me.cmbCharacterPropertyValue.Size = New System.Drawing.Size(171, 21)
        Me.cmbCharacterPropertyValue.TabIndex = 14
        Me.cmbCharacterPropertyValue.Value = Nothing
        Me.cmbCharacterPropertyValue.Visible = False
        '
        'cmbPropertyValue
        '
        Me.cmbPropertyValue.Location = New System.Drawing.Point(529, 9)
        Me.cmbPropertyValue.Name = "cmbPropertyValue"
        Me.cmbPropertyValue.PropertyKey = ""
        Me.cmbPropertyValue.Size = New System.Drawing.Size(187, 21)
        Me.cmbPropertyValue.TabIndex = 16
        Me.cmbPropertyValue.Value = Nothing
        '
        'isPropertyKey1
        '
        Me.isPropertyKey1.AllowAddEdit = False
        Me.isPropertyKey1.AllowedListType = CType(((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.[Object]) _
            Or ADRIFT.ItemSelector.ItemEnum.Character), ADRIFT.ItemSelector.ItemEnum)
        Me.isPropertyKey1.AllowHidden = False
        Me.isPropertyKey1.BackColor = System.Drawing.Color.Transparent
        Me.isPropertyKey1.Key = Nothing
        Me.isPropertyKey1.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.isPropertyKey1.Location = New System.Drawing.Point(30, 9)
        Me.isPropertyKey1.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.isPropertyKey1.MinimumSize = New System.Drawing.Size(10, 21)
        Me.isPropertyKey1.Name = "isPropertyKey1"
        Me.isPropertyKey1.RestrictProperty = Nothing
        Me.isPropertyKey1.Size = New System.Drawing.Size(192, 21)
        Me.isPropertyKey1.TabIndex = 10
        '
        'Expression
        '
        Me.Expression.BackColor = System.Drawing.Color.Transparent
        Me.Expression.Location = New System.Drawing.Point(391, 9)
        Me.Expression.Name = "Expression"
        Me.Expression.Size = New System.Drawing.Size(196, 21)
        Me.Expression.TabIndex = 15
        Me.Expression.Value = ""
        '
        'cmbLocationPropertyValue
        '
        Me.cmbLocationPropertyValue.BackColor = System.Drawing.Color.Transparent
        Me.cmbLocationPropertyValue.Location = New System.Drawing.Point(566, 9)
        Me.cmbLocationPropertyValue.Name = "cmbLocationPropertyValue"
        Me.cmbLocationPropertyValue.PropertyKey = ""
        Me.cmbLocationPropertyValue.Size = New System.Drawing.Size(171, 21)
        Me.cmbLocationPropertyValue.TabIndex = 14
        Me.cmbLocationPropertyValue.Value = Nothing
        Me.cmbLocationPropertyValue.Visible = False
        '
        'expTurns
        '
        Me.expTurns.BackColor = System.Drawing.Color.Transparent
        Me.expTurns.Location = New System.Drawing.Point(46, 8)
        Me.expTurns.Name = "expTurns"
        Me.expTurns.Size = New System.Drawing.Size(124, 21)
        Me.expTurns.TabIndex = 16
        Me.expTurns.Value = ""
        '
        'frmAction
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(890, 112)
        Me.Controls.Add(Me.tabsActions)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1600, 148)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(544, 148)
        Me.Name = "frmAction"
        Me.ShowInTaskbar = False
        Me.Text = "Action"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.cmbObjectMoveWhat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbObjectWhat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbObjectKey2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbObjectMoveTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbObjectKey1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.cmbCharacterMoveWho, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCharacterWhat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCharacterMoveTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCharacterKey2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCharacterKey1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl5.ResumeLayout(False)
        Me.UltraTabPageControl5.PerformLayout()
        CType(Me.cmbLocationKey2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLocationMoveWhat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLocationWhat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLocationMoveTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLocationKey1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl6.ResumeLayout(False)
        Me.UltraTabPageControl6.PerformLayout()
        CType(Me.cmbTasks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbWhatT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.UltraTabPageControl4.PerformLayout()
        CType(Me.cmbVariableSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIndexEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbVariable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIndex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbVariableArray, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl8.ResumeLayout(False)
        Me.UltraTabPageControl8.PerformLayout()
        CType(Me.cmbAskWho, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConvTopic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbWhatConv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        CType(Me.cmbPropertyKey2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl7.ResumeLayout(False)
        Me.UltraTabPageControl7.PerformLayout()
        CType(Me.cmbEndGame, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabsActions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsActions.ResumeLayout(False)
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraStatusBar1.ResumeLayout(False)
        Me.UltraStatusBar1.PerformLayout()
        Me.UltraTabPageControl9.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Action As clsAction
    Private sCommand As String

    Private arlDirectionRefs As New StringArrayList
    Private arlObjectRefs As New StringArrayList
    Private arlCharacterRefs As New StringArrayList
    Private arlLocationRefs As New StringArrayList
    Private arlNumberRefs As New StringArrayList
    Private arlTextRefs As New StringArrayList
    Private arlItemRefs As New StringArrayList

    Private bLoadingAction As Boolean


    Public Sub LoadAction(ByVal Action As clsAction)

        bLoadingAction = True

        LoadCombos()

        Me.Action = Action

        With Action
            Select Case .eItem
                Case clsAction.ItemEnum.MoveObject, clsAction.ItemEnum.AddObjectToGroup, clsAction.ItemEnum.RemoveObjectFromGroup
                    tabsActions.SelectedTab = tabsActions.Tabs("MoveObjects")
                    If .sKey1 IsNot Nothing Then ' To prevent loading combos on first load
                        SetCombo(cmbObjectWhat, .eItem.ToString)
                        SetCombo(cmbObjectMoveWhat, .eMoveObjectWhat.ToString)
                    End If
                    SetCombo(cmbObjectKey1, .sKey1)
                    If .sPropertyValue IsNot Nothing Then cmbObjectPropertyValue.Value = .sPropertyValue
                    If .sKey1 IsNot Nothing Then SetCombo(cmbObjectMoveTo, WriteEnum(.eMoveObjectTo))
                    SetCombo(cmbObjectKey2, .sKey2)

                Case clsAction.ItemEnum.MoveCharacter, clsAction.ItemEnum.AddCharacterToGroup, clsAction.ItemEnum.RemoveCharacterFromGroup
                    tabsActions.SelectedTab = tabsActions.Tabs("MoveCharacters")
                    SetCombo(cmbCharacterWhat, .eItem.ToString)
                    SetCombo(cmbCharacterMoveWho, .eMoveCharacterWho.ToString)
                    SetCombo(cmbCharacterKey1, .sKey1)
                    If .sPropertyValue IsNot Nothing Then cmbCharacterPropertyValue.Value = .sPropertyValue
                    SetCombo(cmbCharacterMoveTo, WriteEnum(.eMoveCharacterTo))
                    SetCombo(cmbCharacterKey2, .sKey2)

                Case clsAction.ItemEnum.AddLocationToGroup, clsAction.ItemEnum.RemoveLocationFromGroup
                    tabsActions.SelectedTab = tabsActions.Tabs("Locations")
                    SetCombo(cmbLocationWhat, .eItem.ToString)
                    SetCombo(cmbLocationMoveWhat, .eMoveLocationWhat.ToString)
                    SetCombo(cmbLocationKey1, .sKey1)
                    If .sPropertyValue IsNot Nothing Then cmbLocationPropertyValue.Value = .sPropertyValue
                    SetCombo(cmbLocationMoveTo, WriteEnum(.eMoveLocationTo))
                    SetCombo(cmbLocationKey2, .sKey2)

                Case clsAction.ItemEnum.SetProperties
                    tabsActions.SelectedTab = tabsActions.Tabs("SetProperties")
                    isPropertyKey1.Key = .sKey1 ' SetCombo(cmbProperty, .sKey1)
                    SetCombo(cmbPropertyKey2, .sKey2)
                    'SetCombo(cmbPropertyExtra, .StringValue)
                    If .sPropertyValue IsNot Nothing Then cmbPropertyValue.Value = .sPropertyValue

                Case clsAction.ItemEnum.SetVariable, clsAction.ItemEnum.IncreaseVariable, clsAction.ItemEnum.DecreaseVariable
                    ' Convert old actions
                    If .eItem = clsAction.ItemEnum.SetVariable AndAlso .sKey1 <> "" AndAlso Adventure.htblVariables(.sKey1).Type = clsVariable.VariableTypeEnum.Numeric Then
                        If .StringValue.Replace(" ", "").StartsWith("%" & Adventure.htblVariables(.sKey1).Name & "%+") Then
                            .eItem = clsAction.ItemEnum.IncreaseVariable
                            .StringValue = .StringValue.Substring(.StringValue.IndexOf("+") + 1)
                            If .StringValue.StartsWith(" ") Then .StringValue = .StringValue.Substring(1)
                        ElseIf .StringValue.Replace(" ", "").StartsWith("%" & Adventure.htblVariables(.sKey1).Name & "%-") Then
                            .eItem = clsAction.ItemEnum.DecreaseVariable
                            .StringValue = .StringValue.Substring(.StringValue.IndexOf("-") + 1)
                            If .StringValue.StartsWith(" ") Then .StringValue = .StringValue.Substring(1)
                        End If
                    End If

                    Select Case .eItem
                        Case clsAction.ItemEnum.SetVariable
                            SetCombo(cmbVariableSet, clsAction.ItemEnum.SetVariable.ToString)
                        Case clsAction.ItemEnum.IncreaseVariable
                            SetCombo(cmbVariableSet, clsAction.ItemEnum.IncreaseVariable.ToString)
                        Case clsAction.ItemEnum.DecreaseVariable
                            SetCombo(cmbVariableSet, clsAction.ItemEnum.DecreaseVariable.ToString)
                    End Select
                    tabsActions.SelectedTab = tabsActions.Tabs("Variables")
                    SetCombo(cmbVariable, .sKey1)
                    Expression.Value = .StringValue
                    'If Expression.Value.StartsWith("""") AndAlso Expression.Value.EndsWith("""") Then
                    '    Expression.Value = Expression.Value.Substring(1, Expression.Value.Length - 2)
                    'End If
                    If .eVariables = clsAction.VariablesEnum.Assignment Then
                        ' We're a normal assignment
                        If IsNumeric(.sKey2) Then
                            cmbIndexEdit.Visible = True
                            cmbIndexEdit.Text = .sKey2
                            cmbIndex.Visible = False
                        Else
                            'cmbIndex.Visible = True
                            SetCombo(cmbIndex, .sKey2)
                            cmbIndexEdit.Visible = False
                        End If
                    Else
                        ' We're a loop
                        chkLoop.Checked = True
                        txtLoopFrom.Text = .IntValue.ToString
                        txtLoopTo.Text = .sKey2
                    End If

                Case clsAction.ItemEnum.SetTasks
                    tabsActions.SelectedTab = tabsActions.Tabs("Tasks")
                    SetCombo(cmbWhatT, WriteEnum(.eSetTasks))
                    SetCombo(cmbTasks, .sKey1)
                    btnParams.Tag = .StringValue
                    If .IntValue <> 0 OrElse .sPropertyValue <> "" Then
                        chkLoop.Checked = True
                        txtLoopFrom.Text = .IntValue.ToString
                        txtLoopTo.Text = .sPropertyValue
                    End If

                Case clsAction.ItemEnum.Conversation
                    tabsActions.SelectedTab = tabsActions.Tabs("Conversation")
                    SetCombo(cmbWhatConv, CInt(.eConversation))
                    SetCombo(cmbAskWho, .sKey1)
                    txtConvTopic.Text = .StringValue

                Case clsAction.ItemEnum.Time
                    tabsActions.SelectedTab = tabsActions.Tabs("Time")
                    expTurns.Value = .StringValue

                Case clsAction.ItemEnum.EndGame
                    tabsActions.SelectedTab = tabsActions.Tabs("EndGame")
                    SetCombo(cmbEndGame, WriteEnum(.eEndgame))

            End Select
        End With

        bLoadingAction = False

    End Sub


    Private Sub cmbObjectWhat_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbObjectWhat.SelectionChanged
        LoadObjectMoveToCombo()
    End Sub


    Private Sub cmbObjectMoveWhat_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbObjectMoveWhat.SelectionChanged

        With cmbObjectKey1
            .Items.Clear()

            Select Case CType([Enum].Parse(GetType(clsAction.MoveObjectWhatEnum), cmbObjectMoveWhat.SelectedItem.DataValue.ToString), clsAction.MoveObjectWhatEnum)
                Case clsAction.MoveObjectWhatEnum.EverythingHeldBy, clsAction.MoveObjectWhatEnum.EverythingWornBy
                    .Items.Add(THEPLAYER, "[ The Player Character ]")
                    For Each c As String In arlCharacterRefs
                        .Items.Add(c, Adventure.GetNameFromKey(c, False))
                    Next
                    For Each c As clsCharacter In Adventure.htblCharacters.Values
                        .Items.Add(c.Key, c.Name)
                    Next
                Case clsAction.MoveObjectWhatEnum.EverythingInGroup
                    For Each g As clsGroup In Adventure.htblGroups.Values
                        If g.GroupType = clsGroup.GroupTypeEnum.Objects Then .Items.Add(g.Key, g.Name)
                    Next
                Case clsAction.MoveObjectWhatEnum.EverythingInside
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsContainer Then .Items.Add(ob.Key, ob.FullName)
                    Next
                Case clsAction.MoveObjectWhatEnum.EverythingOn
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.HasSurface Then .Items.Add(ob.Key, ob.FullName)
                    Next
                Case clsAction.MoveObjectWhatEnum.EverythingWithProperty
                    For Each p As clsProperty In Adventure.htblObjectProperties.Values
                        .Items.Add(p.Key, p.CommonName)
                    Next
                Case clsAction.MoveObjectWhatEnum.Object
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        .Items.Add(ob.Key, ob.FullName)
                    Next
                Case clsAction.MoveObjectWhatEnum.EverythingAtLocation
                    For Each l As String In arlLocationRefs
                        .Items.Add(l, Adventure.GetNameFromKey(l, False))
                    Next
                    For Each l As clsLocation In Adventure.htblLocations.Values
                        .Items.Add(l.Key, l.ShortDescription.ToString)
                    Next
            End Select

        End With

    End Sub


    Private Sub cmbCharacterMoveWho_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbCharacterMoveWho.SelectionChanged

        With cmbCharacterKey1
            .Items.Clear()

            Select Case CType([Enum].Parse(GetType(clsAction.MoveCharacterWhoEnum), cmbCharacterMoveWho.SelectedItem.DataValue.ToString), clsAction.MoveCharacterWhoEnum)
                Case clsAction.MoveCharacterWhoEnum.Character
                    .Items.Add(THEPLAYER, "[ The Player Character ]")
                    For Each c As String In arlCharacterRefs
                        .Items.Add(c, Adventure.GetNameFromKey(c, False))
                    Next
                    For Each c As clsCharacter In Adventure.htblCharacters.Values
                        .Items.Add(c.Key, c.Name)
                    Next
                Case clsAction.MoveCharacterWhoEnum.EveryoneAtLocation
                    For Each l As String In arlLocationRefs
                        .Items.Add(l, Adventure.GetNameFromKey(l, False))
                    Next
                    For Each l As clsLocation In Adventure.htblLocations.Values
                        .Items.Add(l.Key, l.ShortDescription.ToString)
                    Next
                Case clsAction.MoveCharacterWhoEnum.EveryoneInGroup
                    For Each g As clsGroup In Adventure.htblGroups.Values
                        If g.GroupType = clsGroup.GroupTypeEnum.Characters Then .Items.Add(g.Key, g.Name)
                    Next
                Case clsAction.MoveCharacterWhoEnum.EveryoneInside
                    For Each o As clsObject In Adventure.htblObjects.Values
                        If o.IsContainer Then .Items.Add(o.Key, o.FullName)
                    Next
                Case clsAction.MoveCharacterWhoEnum.EveryoneOn
                    For Each o As clsObject In Adventure.htblObjects.Values
                        If o.HasSurface Then .Items.Add(o.Key, o.FullName)
                    Next
                Case clsAction.MoveCharacterWhoEnum.EveryoneWithProperty
                    For Each p As clsProperty In Adventure.htblCharacterProperties.Values
                        .Items.Add(p.Key, p.CommonName)
                    Next
            End Select

        End With

    End Sub


    Private Sub cmbLocationMoveWhat_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbLocationMoveWhat.SelectionChanged

        With cmbLocationKey1
            .Items.Clear()

            Select Case CType([Enum].Parse(GetType(clsAction.MoveLocationWhatEnum), cmbLocationMoveWhat.SelectedItem.DataValue.ToString), clsAction.MoveLocationWhatEnum)
                Case clsAction.MoveLocationWhatEnum.Location
                    For Each l As String In arlLocationRefs
                        .Items.Add(l, Adventure.GetNameFromKey(l, False))
                    Next
                    For Each l As clsLocation In Adventure.htblLocations.Values
                        .Items.Add(l.Key, l.ShortDescription.ToString)
                    Next
                Case clsAction.MoveLocationWhatEnum.LocationOf
                    .Items.Add(THEPLAYER, "[ The Player Character ]")
                    For Each c As String In arlCharacterRefs
                        .Items.Add(c, Adventure.GetNameFromKey(c, False))
                    Next
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each c As clsCharacter In Adventure.htblCharacters.Values
                        .Items.Add(c.Key, c.Name)
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.HasSurface Then .Items.Add(ob.Key, ob.FullName)
                    Next
                Case clsAction.MoveLocationWhatEnum.EverywhereInGroup
                    For Each g As clsGroup In Adventure.htblGroups.Values
                        If g.GroupType = clsGroup.GroupTypeEnum.Locations Then .Items.Add(g.Key, g.Name)
                    Next
                Case clsAction.MoveLocationWhatEnum.EverywhereWithProperty
                    For Each p As clsProperty In Adventure.htblLocationProperties.Values
                        .Items.Add(p.Key, p.CommonName)
                    Next
            End Select

        End With

    End Sub


    Private Sub LoadCombos()

        arlDirectionRefs = GetReferences(ReferencesType.Direction, Me.sCommand)
        arlObjectRefs = GetReferences(ReferencesType.Object, Me.sCommand)
        arlCharacterRefs = GetReferences(ReferencesType.Character, Me.sCommand)
        arlLocationRefs = GetReferences(ReferencesType.Location, Me.sCommand)
        arlNumberRefs = GetReferences(ReferencesType.Number, Me.sCommand)
        arlTextRefs = GetReferences(ReferencesType.Text, Me.sCommand)
        arlItemRefs = GetReferences(ReferencesType.Item, Me.sCommand)
        cmbObjectPropertyValue.Command = Me.sCommand

        With cmbObjectWhat
            .Items.Clear()
            .Items.Add(clsAction.ItemEnum.MoveObject.ToString, "Move")
            .Items.Add(clsAction.ItemEnum.AddObjectToGroup.ToString, "Add")
            .Items.Add(clsAction.ItemEnum.RemoveObjectFromGroup.ToString, "Remove")
        End With
        '       SetCombo(cmbObjectWhat, clsAction.ItemEnum.MoveObject.ToString)

        With cmbObjectMoveWhat
            .Items.Clear()
            .Items.Add(clsAction.MoveObjectWhatEnum.Object.ToString, "Object")
            .Items.Add(clsAction.MoveObjectWhatEnum.EverythingAtLocation.ToString, "Everything at location")
            .Items.Add(clsAction.MoveObjectWhatEnum.EverythingHeldBy.ToString, "Everything held by")
            .Items.Add(clsAction.MoveObjectWhatEnum.EverythingInGroup.ToString, "Everything in group")
            .Items.Add(clsAction.MoveObjectWhatEnum.EverythingInside.ToString, "Everything inside object")
            .Items.Add(clsAction.MoveObjectWhatEnum.EverythingOn.ToString, "Everything on object")
            .Items.Add(clsAction.MoveObjectWhatEnum.EverythingWithProperty.ToString, "Everything with property")
            .Items.Add(clsAction.MoveObjectWhatEnum.EverythingWornBy.ToString, "Everything worn by")
        End With
        '        SetCombo(cmbObjectMoveWhat, clsAction.MoveObjectWhatEnum.Object.ToString)

        cmbObjectKey1.Items.Clear()
        'cmbObject.Items.Add(ALLHELDOBJECTS, "[ All Held Objects ]")
        'cmbObject.Items.Add(ALLWORNOBJECTS, "[ All Worn Objects ]")
        'For Each o As String In arlObjectRefs
        '    cmbObjectKey1.Items.Add(o, Adventure.GetNameFromKey(o, False)) ' o.Replace("ReferencedObject", " Referenced Object ").Replace("Referenced Object s", "Referenced Objects"))
        'Next
        'For Each ob As clsObject In Adventure.htblObjects.Values
        '    cmbObjectKey1.Items.Add(ob.Key, ob.FullName)
        'Next

        With cmbCharacterWhat
            .Items.Clear()
            .Items.Add(clsAction.ItemEnum.MoveCharacter.ToString, "Move")
            .Items.Add(clsAction.ItemEnum.AddCharacterToGroup.ToString, "Add")
            .Items.Add(clsAction.ItemEnum.RemoveCharacterFromGroup.ToString, "Remove")
        End With

        With cmbCharacterMoveWho
            .Items.Clear()
            .Items.Add(clsAction.MoveCharacterWhoEnum.Character.ToString, "Character")
            .Items.Add(clsAction.MoveCharacterWhoEnum.EveryoneAtLocation.ToString, "Everyone at location")
            .Items.Add(clsAction.MoveCharacterWhoEnum.EveryoneInGroup.ToString, "Everyone in group")
            .Items.Add(clsAction.MoveCharacterWhoEnum.EveryoneInside.ToString, "Everyone inside object")
            .Items.Add(clsAction.MoveCharacterWhoEnum.EveryoneOn.ToString, "Everyone on object")
            .Items.Add(clsAction.MoveCharacterWhoEnum.EveryoneWithProperty.ToString, "Everyone with property")
        End With

        cmbCharacterKey1.Items.Clear()

        With cmbLocationWhat
            .Items.Clear()
            .Items.Add(clsAction.ItemEnum.AddLocationToGroup.ToString, "Add")
            .Items.Add(clsAction.ItemEnum.RemoveLocationFromGroup.ToString, "Remove")
        End With

        With cmbLocationMoveWhat
            .Items.Clear()
            .Items.Add(clsAction.MoveLocationWhatEnum.Location.ToString, "Location")
            .Items.Add(clsAction.MoveLocationWhatEnum.LocationOf.ToString, "Location of")
            .Items.Add(clsAction.MoveLocationWhatEnum.EverywhereInGroup.ToString, "Everywhere in group")
            .Items.Add(clsAction.MoveLocationWhatEnum.EverywhereWithProperty.ToString, "Everywhere with property")
        End With

        cmbLocationKey1.Items.Clear()

        With cmbWhatConv
            .Items.Clear()
            .Items.Add(CInt(clsAction.ConversationEnum.Ask).ToString, "Ask")
            .Items.Add(CInt(clsAction.ConversationEnum.Tell).ToString, "Tell")
            .Items.Add(CInt(clsAction.ConversationEnum.Command).ToString, "Say")
            .Items.Add(CInt(clsAction.ConversationEnum.EnterConversation).ToString, "Enter conversation")
            .Items.Add(CInt(clsAction.ConversationEnum.LeaveConversation).ToString, "Leave conversation")
        End With

        With cmbAskWho
            .Items.Clear()
            .Items.Add(THEPLAYER, "[ The Player Character ]")
            For Each c As String In arlCharacterRefs
                .Items.Add(c, Adventure.GetNameFromKey(c, False))
            Next
            For Each ch As clsCharacter In Adventure.htblCharacters.Values
                .Items.Add(ch.Key, ch.Name)
            Next
        End With

        cmbPropertyValue.Command = Me.sCommand
        'cmbProperty.Items.Clear()
        'For Each o As String In arlObjectRefs
        '    cmbProperty.Items.Add(o, Adventure.GetNameFromKey(o, False))
        'Next
        'For Each ob As clsObject In Adventure.htblObjects.Values
        '    cmbProperty.Items.Add(ob.Key, ob.FullName)
        'Next

        With cmbVariableSet
            .Items.Clear()
            .Items.Add(clsAction.ItemEnum.SetVariable.ToString, "Set")
            .Items.Add(clsAction.ItemEnum.IncreaseVariable.ToString, "Increase")
            .Items.Add(clsAction.ItemEnum.DecreaseVariable.ToString, "Decrease")
        End With

        cmbVariable.Items.Clear()
        cmbIndex.Items.Clear()
        cmbIndex.Items.Add("<Enter own value>")
        For Each v As String In arlNumberRefs
            cmbIndex.Items.Add(v, Adventure.GetNameFromKey(v, False))
        Next
        For Each v As clsVariable In Adventure.htblVariables.Values
            cmbVariable.Items.Add(v.Key, v.Name)
            If v.Length < 2 AndAlso v.Type = clsVariable.VariableTypeEnum.Numeric Then cmbIndex.Items.Add(v.Key, v.Name)
            If v.Length > 1 Then cmbVariableArray.Items.Add(v.Key, v.Name)
        Next
        'cmbLocation.Items.Clear()
        'For Each loc As clsLocation In Adventure.htblLocations.Values
        '    cmbLocation.Items.Add(loc.Key, loc.ShortDescription)
        'Next

        'cmbObject.Items.Clear()
        'For Each ob As clsObject In Adventure.htblObjects.Values
        '    cmbObject.Items.Add(ob.Key, ob.FullName)
        'Next

        cmbTasks.Items.Clear()
        For Each tas As clsTask In Adventure.htblTasks.Values
            cmbTasks.Items.Add(tas.Key, tas.Description)
        Next

        With cmbEndGame.Items
            .Clear()
            .Add(clsAction.EndGameEnum.Win.ToString, "in Victory")
            .Add(clsAction.EndGameEnum.Lose.ToString, "in Defeat")
            .Add(clsAction.EndGameEnum.Neutral.ToString, "without a fuss")
        End With
        'cmbWhatC.Items.Clear()
        'cmbWhatC.Items.Add(clsAction.MoveCharacterEnum.InDirection.ToString, "in direction")
        'cmbWhatC.Items.Add(clsAction.MoveCharacterEnum.InsideObject.ToString, "inside object")
        'cmbWhatC.Items.Add(clsAction.MoveCharacterEnum.OntoCharacter.ToString, "onto character")
        'cmbWhatC.Items.Add(clsAction.MoveCharacterEnum.ToLocation.ToString, "to location")
        'cmbWhatC.Items.Add(clsAction.MoveCharacterEnum.ToLocationGroup.ToString, "to location group")
        'cmbWhatC.Items.Add(clsAction.MoveCharacterEnum.ToLyingOn.ToString, "to lying on")
        'cmbWhatC.Items.Add(clsAction.MoveCharacterEnum.ToParentLocation.ToString, "to parent location")
        'cmbWhatC.Items.Add(clsAction.MoveCharacterEnum.ToSameLocationAs.ToString, "to same location as")
        'cmbWhatC.Items.Add(clsAction.MoveCharacterEnum.ToSittingOn.ToString, "to sitting on")
        'cmbWhatC.Items.Add(clsAction.MoveCharacterEnum.ToStandingOn.ToString, "to standing on")
        'cmbWhatC.Items.Add(clsAction.MoveCharacterEnum.ToSwitchWith.ToString, "to switch places with")

    End Sub



    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub


    Private Sub cmbObjectMoveTo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbObjectMoveTo.ValueChanged

        With cmbObjectKey2
            Dim sCurrent As String = Nothing
            If .SelectedItem IsNot Nothing Then sCurrent = .SelectedItem.DataValue.ToString

            .Items.Clear()
            .SortStyle = Infragistics.Win.ValueListSortStyle.Ascending

            Select Case EnumParseMoveObject(cmbObjectMoveTo.SelectedItem.DataValue.ToString)
                Case clsAction.MoveObjectToEnum.InsideObject
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsContainer Then
                            .Items.Add(ob.Key, ob.FullName)
                        End If
                    Next
                Case clsAction.MoveObjectToEnum.OntoObject
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.HasSurface Then
                            .Items.Add(ob.Key, ob.FullName)
                        End If
                    Next
                Case clsAction.MoveObjectToEnum.ToCarriedBy, clsAction.MoveObjectToEnum.ToWornBy, clsAction.MoveObjectToEnum.ToPartOfCharacter
                    .Items.Add(THEPLAYER, "[ The Player Character ]")
                    For Each c As String In arlCharacterRefs
                        .Items.Add(c, Adventure.GetNameFromKey(c, False))
                    Next
                    For Each chr As clsCharacter In Adventure.htblCharacters.Values
                        .Items.Add(chr.Key, chr.Name)
                    Next
                Case clsAction.MoveObjectToEnum.ToSameLocationAs
                    .Items.Add(THEPLAYER, "[ The Player Character ]")
                    For Each c As String In arlCharacterRefs
                        .Items.Add(c, Adventure.GetNameFromKey(c, False))
                    Next
                    For Each chr As clsCharacter In Adventure.htblCharacters.Values
                        .Items.Add(chr.Key, chr.Name)
                    Next
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        .Items.Add(ob.Key, ob.FullName)
                    Next
                Case clsAction.MoveObjectToEnum.ToLocation
                    .Items.Add("Hidden", "[ Hidden ]")
                    For Each l As String In arlLocationRefs
                        .Items.Add(l, Adventure.GetNameFromKey(l, False))
                    Next
                    For Each loc As clsLocation In Adventure.htblLocations.Values
                        .Items.Add(loc.Key, loc.ShortDescription.ToString)
                    Next
                Case clsAction.MoveObjectToEnum.ToLocationGroup
                    For Each grp As clsGroup In Adventure.htblGroups.Values
                        If grp.GroupType = clsGroup.GroupTypeEnum.Locations Then .Items.Add(grp.Key, grp.Name)
                    Next
                Case clsAction.MoveObjectToEnum.ToPartOfObject
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        .Items.Add(ob.Key, ob.FullName)
                    Next
                Case clsAction.MoveObjectToEnum.ToGroup, clsAction.MoveObjectToEnum.FromGroup
                    For Each g As clsGroup In Adventure.htblGroups.Values
                        If g.GroupType = clsGroup.GroupTypeEnum.Objects Then
                            .Items.Add(g.Key, g.Name)
                        End If
                    Next
            End Select

            SetCombo(cmbObjectKey2, sCurrent)
        End With
    End Sub


    Private Sub cmbCharacterMoveTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCharacterMoveTo.ValueChanged

        With cmbCharacterKey2
            Dim sCurrent As String = Nothing
            If .SelectedItem IsNot Nothing Then sCurrent = .SelectedItem.DataValue.ToString

            .Items.Clear()
            .SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
            cmbCharacterKey2.Enabled = True
            Select Case EnumParseMoveCharacter(CStr(cmbCharacterMoveTo.SelectedItem.DataValue))
                Case clsAction.MoveCharacterToEnum.InDirection
                    .SortStyle = Infragistics.Win.ValueListSortStyle.None
                    For Each d As String In arlDirectionRefs
                        .Items.Add(d.ToString, d)
                    Next
                    For di As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest
                        .Items.Add(di.ToString, DirectionName(di))
                    Next

                Case clsAction.MoveCharacterToEnum.ToLocation
                    .Items.Add("Hidden", "[ Hidden ]")
                    For Each l As String In arlLocationRefs
                        .Items.Add(l, Adventure.GetNameFromKey(l, False))
                    Next
                    For Each loc As clsLocation In Adventure.htblLocations.Values
                        .Items.Add(loc.Key, loc.ShortDescription.ToString)
                    Next

                Case clsAction.MoveCharacterToEnum.ToLocationGroup
                    For Each grp As clsGroup In Adventure.htblGroups.Values
                        If grp.GroupType = clsGroup.GroupTypeEnum.Locations Then
                            .Items.Add(grp.Key, grp.Name)
                        End If
                    Next

                Case clsAction.MoveCharacterToEnum.ToSameLocationAs
                    .Items.Add(THEPLAYER, "[ The Player Character ]")
                    For Each c As String In arlCharacterRefs
                        .Items.Add(c, Adventure.GetNameFromKey(c, False))
                    Next
                    For Each chr As clsCharacter In Adventure.htblCharacters.Values
                        .Items.Add(chr.Key, chr.Name)
                    Next
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        .Items.Add(ob.Key, ob.FullName)
                    Next

                Case clsAction.MoveCharacterToEnum.ToSwitchWith
                    .Items.Add(THEPLAYER, "[ The Player Character ]")
                    For Each c As String In arlCharacterRefs
                        .Items.Add(c, Adventure.GetNameFromKey(c, False))
                    Next
                    For Each chr As clsCharacter In Adventure.htblCharacters.Values
                        .Items.Add(chr.Key, chr.Name)
                    Next

                Case clsAction.MoveCharacterToEnum.ToStandingOn
                    .Items.Add(THEFLOOR, "[ The Floor ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsStandable Then .Items.Add(ob.Key, ob.FullName)
                    Next

                Case clsAction.MoveCharacterToEnum.ToSittingOn
                    .Items.Add(THEFLOOR, "[ The Floor ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsSittable Then .Items.Add(ob.Key, ob.FullName)
                    Next

                Case clsAction.MoveCharacterToEnum.ToLyingOn
                    .Items.Add(THEFLOOR, "[ The Floor ]")
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsLieable Then .Items.Add(ob.Key, ob.FullName)
                    Next

                Case clsAction.MoveCharacterToEnum.InsideObject
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If ob.IsContainer Then .Items.Add(ob.Key, ob.FullName)
                    Next

                Case clsAction.MoveCharacterToEnum.OntoCharacter
                    ' TODO - don't allow character to move onto itself
                    .Items.Add(THEPLAYER, "[ The Player Character ]")
                    For Each c As String In arlCharacterRefs
                        .Items.Add(c, Adventure.GetNameFromKey(c, False))
                    Next
                    For Each chr As clsCharacter In Adventure.htblCharacters.Values
                        .Items.Add(chr.Key, chr.Name)
                    Next

                Case clsAction.MoveCharacterToEnum.ToParentLocation
                    cmbCharacterKey2.Enabled = False

                Case clsAction.MoveCharacterToEnum.ToGroup, clsAction.MoveCharacterToEnum.FromGroup
                    For Each g As clsGroup In Adventure.htblGroups.Values
                        If g.GroupType = clsGroup.GroupTypeEnum.Characters Then
                            .Items.Add(g.Key, g.Name)
                        End If
                    Next

            End Select

            SetCombo(cmbCharacterKey2, sCurrent)
        End With

    End Sub


    Private Sub cmbLocationMoveTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLocationMoveTo.ValueChanged

        With cmbLocationKey2
            Dim sCurrent As String = Nothing
            If .SelectedItem IsNot Nothing Then sCurrent = .SelectedItem.DataValue.ToString

            .Items.Clear()
            .SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
            cmbLocationMoveTo.Enabled = True
            Select Case EnumParseMoveLocation(CStr(cmbLocationMoveTo.SelectedItem.DataValue))

                Case clsAction.MoveLocationToEnum.FromGroup, clsAction.MoveLocationToEnum.ToGroup
                    For Each g As clsGroup In Adventure.htblGroups.Values
                        If g.GroupType = clsGroup.GroupTypeEnum.Locations Then
                            .Items.Add(g.Key, g.Name)
                        End If
                    Next

            End Select

            SetCombo(cmbLocationKey2, sCurrent)
        End With

    End Sub


    Private Sub UltraTabControl1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabsActions.SelectedTabChanged

        RepositionDropdowns()
       
        frmAction_Resize(Nothing, Nothing)
        SaveAction()
    End Sub

    Private Sub cmbIndex_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbIndex.SelectionChanged

        If cmbIndex.SelectedIndex = 0 Then
            cmbIndex.Visible = False
            cmbIndexEdit.Visible = True
            cmbIndexEdit.Text = "0"
            cmbIndexEdit.Focus()
        End If

    End Sub


    Private Sub LoadCharMoveToCombo()

        cmbCharacterPropertyValue.Visible = False
        lblCharactersWithValue.Visible = False

        If cmbCharacterMoveWho.SelectedItem IsNot Nothing Then
            Select Case CType([Enum].Parse(GetType(clsAction.MoveCharacterWhoEnum), SafeString(cmbCharacterMoveWho.SelectedItem.DataValue)), clsAction.MoveCharacterWhoEnum)
                Case clsAction.MoveCharacterWhoEnum.EveryoneWithProperty
                    If cmbCharacterKey1.SelectedItem IsNot Nothing Then
                        Dim prop As clsProperty = Adventure.htblCharacterProperties(cmbCharacterKey1.SelectedItem.DataValue.ToString)
                        If prop.Type <> clsProperty.PropertyTypeEnum.SelectionOnly Then
                            cmbCharacterPropertyValue.PropertyKey = cmbCharacterKey1.SelectedItem.DataValue.ToString
                            cmbCharacterPropertyValue.Visible = True
                            lblCharactersWithValue.Visible = True
                        End If
                    End If
            End Select
        End If

        frmAction_Resize(Nothing, Nothing)

        If cmbCharacterWhat.SelectedItem IsNot Nothing Then

            Select Case CType([Enum].Parse(GetType(clsAction.ItemEnum), cmbCharacterWhat.SelectedItem.DataValue.ToString), clsAction.ItemEnum)
                Case clsAction.ItemEnum.MoveCharacter
                    Dim sCurrent As String = Nothing
                    If cmbCharacterMoveTo.SelectedItem IsNot Nothing Then sCurrent = cmbCharacterMoveTo.SelectedItem.DataValue.ToString

                    cmbCharacterMoveTo.Items.Clear()
                    cmbCharacterMoveTo.Items.Add(clsAction.MoveCharacterToEnum.InDirection.ToString, "in direction")
                    cmbCharacterMoveTo.Items.Add(clsAction.MoveCharacterToEnum.InsideObject.ToString, "inside object")
                    cmbCharacterMoveTo.Items.Add(clsAction.MoveCharacterToEnum.OntoCharacter.ToString, "onto character")
                    cmbCharacterMoveTo.Items.Add(clsAction.MoveCharacterToEnum.ToLocation.ToString, "to location")
                    cmbCharacterMoveTo.Items.Add(clsAction.MoveCharacterToEnum.ToLocationGroup.ToString, "to location group")
                    cmbCharacterMoveTo.Items.Add(clsAction.MoveCharacterToEnum.ToLyingOn.ToString, "to lying on")
                    cmbCharacterMoveTo.Items.Add(clsAction.MoveCharacterToEnum.ToParentLocation.ToString, "to parent location")
                    cmbCharacterMoveTo.Items.Add(clsAction.MoveCharacterToEnum.ToSameLocationAs.ToString, "to same location as")
                    cmbCharacterMoveTo.Items.Add(clsAction.MoveCharacterToEnum.ToSittingOn.ToString, "to sitting on")
                    cmbCharacterMoveTo.Items.Add(clsAction.MoveCharacterToEnum.ToStandingOn.ToString, "to standing on")
                    cmbCharacterMoveTo.Items.Add(clsAction.MoveCharacterToEnum.ToSwitchWith.ToString, "to switch places with")
                    SetCombo(cmbCharacterMoveTo, sCurrent)

                Case clsAction.ItemEnum.AddCharacterToGroup
                    cmbCharacterMoveTo.Items.Clear()
                    cmbCharacterMoveTo.Items.Add("ToGroup", "to group")
                    SetCombo(cmbCharacterMoveTo, "ToGroup")

                Case clsAction.ItemEnum.RemoveCharacterFromGroup
                    cmbCharacterMoveTo.Items.Clear()
                    cmbCharacterMoveTo.Items.Add("FromGroup", "from group")
                    SetCombo(cmbCharacterMoveTo, "FromGroup")
            End Select
        End If

    End Sub


    Private Sub LoadObjectMoveToCombo()

        Dim bStatic As Boolean = False
        Dim bDynamic As Boolean = False

        cmbObjectPropertyValue.Visible = False
        lblObjectsWithValue.Visible = False

        If cmbObjectMoveWhat.SelectedItem IsNot Nothing Then
            Select Case CType([Enum].Parse(GetType(clsAction.MoveObjectWhatEnum), SafeString(cmbObjectMoveWhat.SelectedItem.DataValue)), clsAction.MoveObjectWhatEnum)
                Case clsAction.MoveObjectWhatEnum.Object
                    If cmbObjectKey1.SelectedItem IsNot Nothing AndAlso Adventure.htblObjects.ContainsKey(cmbObjectKey1.SelectedItem.DataValue.ToString) Then
                        bStatic = Adventure.htblObjects(cmbObjectKey1.SelectedItem.DataValue.ToString).IsStatic
                        bDynamic = Not bStatic
                    Else
                        bStatic = True
                        bDynamic = True
                    End If
                Case clsAction.MoveObjectWhatEnum.EverythingAtLocation
                    bDynamic = True
                Case clsAction.MoveObjectWhatEnum.EverythingHeldBy
                    bDynamic = True
                Case clsAction.MoveObjectWhatEnum.EverythingInGroup
                    bDynamic = True
                    bStatic = True
                Case clsAction.MoveObjectWhatEnum.EverythingInside
                    bDynamic = True
                Case clsAction.MoveObjectWhatEnum.EverythingOn
                    bDynamic = True
                Case clsAction.MoveObjectWhatEnum.EverythingWithProperty
                    If cmbObjectKey1.SelectedItem IsNot Nothing Then
                        Dim prop As clsProperty = Adventure.htblObjectProperties(cmbObjectKey1.SelectedItem.DataValue.ToString)
                        If prop.Type <> clsProperty.PropertyTypeEnum.SelectionOnly Then
                            cmbObjectPropertyValue.PropertyKey = cmbObjectKey1.SelectedItem.DataValue.ToString
                            cmbObjectPropertyValue.Visible = True
                            lblObjectsWithValue.Visible = True
                        End If
                    End If
                    bDynamic = True
                    bStatic = True
                Case clsAction.MoveObjectWhatEnum.EverythingWornBy
                    bDynamic = True
            End Select
        End If

        frmAction_Resize(Nothing, Nothing)

        If cmbObjectWhat.SelectedItem IsNot Nothing Then
            Select Case CType([Enum].Parse(GetType(clsAction.ItemEnum), cmbObjectWhat.SelectedItem.DataValue.ToString), clsAction.ItemEnum)
                Case clsAction.ItemEnum.MoveObject
                    Dim sCurrent As String = Nothing
                    If cmbObjectMoveTo.SelectedItem IsNot Nothing Then sCurrent = cmbObjectMoveTo.SelectedItem.DataValue.ToString
                    cmbObjectMoveTo.Items.Clear()
                    If bStatic AndAlso bDynamic Then
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.InsideObject.ToString, "inside object")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.OntoObject.ToString, "onto object")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToCarriedBy.ToString, "to held by")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToLocation.ToString, "to location")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToLocationGroup.ToString, "to somewhere/everywhere in group")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToSameLocationAs.ToString, "to same location as")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToWornBy.ToString, "to worn by")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToPartOfCharacter.ToString, "to part of character")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToPartOfObject.ToString, "to part of object")
                    ElseIf bStatic Then
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToLocation.ToString, "to location")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToLocationGroup.ToString, "to everywhere in group")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToPartOfCharacter.ToString, "to part of character")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToPartOfObject.ToString, "to part of object")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToSameLocationAs.ToString, "to same location as")
                    Else
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.InsideObject.ToString, "inside object")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.OntoObject.ToString, "onto object")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToCarriedBy.ToString, "to held by")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToLocation.ToString, "to location")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToLocationGroup.ToString, "to somewhere in group")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToSameLocationAs.ToString, "to same location as")
                        cmbObjectMoveTo.Items.Add(clsAction.MoveObjectToEnum.ToWornBy.ToString, "to worn by")
                    End If
                    SetCombo(cmbObjectMoveTo, sCurrent)

                Case clsAction.ItemEnum.AddObjectToGroup
                    cmbObjectMoveTo.Items.Clear()
                    cmbObjectMoveTo.Items.Add("ToGroup", "to group")
                    SetCombo(cmbObjectMoveTo, "ToGroup")

                Case clsAction.ItemEnum.RemoveObjectFromGroup
                    cmbObjectMoveTo.Items.Clear()
                    cmbObjectMoveTo.Items.Add("FromGroup", "from group")
                    SetCombo(cmbObjectMoveTo, "FromGroup")

            End Select
        End If

    End Sub


    Private Sub LoadLocationMoveToCombo()

        cmbLocationPropertyValue.Visible = False
        lblLocationsWithValue.Visible = False

        If cmbLocationMoveWhat.SelectedItem IsNot Nothing Then
            Select Case CType([Enum].Parse(GetType(clsAction.MoveLocationWhatEnum), SafeString(cmbLocationMoveWhat.SelectedItem.DataValue)), clsAction.MoveLocationWhatEnum)
                Case clsAction.MoveLocationWhatEnum.EverywhereWithProperty
                    If cmbLocationKey1.SelectedItem IsNot Nothing Then
                        Dim prop As clsProperty = Adventure.htblLocationProperties(cmbLocationKey1.SelectedItem.DataValue.ToString)
                        If prop.Type <> clsProperty.PropertyTypeEnum.SelectionOnly Then
                            cmbLocationPropertyValue.PropertyKey = cmbLocationKey1.SelectedItem.DataValue.ToString
                            cmbLocationPropertyValue.Visible = True
                            lblLocationsWithValue.Visible = True
                        End If
                    End If
            End Select
        End If

        frmAction_Resize(Nothing, Nothing)

        If cmbLocationWhat.SelectedItem IsNot Nothing Then

            Select Case CType([Enum].Parse(GetType(clsAction.ItemEnum), cmbLocationWhat.SelectedItem.DataValue.ToString), clsAction.ItemEnum)

                Case clsAction.ItemEnum.AddLocationToGroup
                    cmbLocationMoveTo.Items.Clear()
                    cmbLocationMoveTo.Items.Add("ToGroup", "to group")
                    SetCombo(cmbLocationMoveTo, "ToGroup")

                Case clsAction.ItemEnum.RemoveLocationFromGroup
                    cmbLocationMoveTo.Items.Clear()
                    cmbLocationMoveTo.Items.Add("FromGroup", "from group")
                    SetCombo(cmbLocationMoveTo, "FromGroup")
            End Select
        End If

    End Sub


    Private Sub cmbObjectKey1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbObjectKey1.SelectionChanged
        LoadObjectMoveToCombo()
    End Sub


    Private Sub cmbCharacterKey1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCharacterKey1.SelectionChanged
        LoadCharMoveToCombo()
    End Sub


    Private Sub cmbLocationKey1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLocationKey1.SelectionChanged
        LoadLocationMoveToCombo()
    End Sub


    Private Sub cmb_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCharacterWhat.ValueChanged, cmbCharacterMoveWho.ValueChanged, cmbCharacterKey1.ValueChanged, cmbCharacterPropertyValue.ValueChanged, cmbCharacterMoveTo.ValueChanged, cmbCharacterKey2.ValueChanged, cmbObjectWhat.ValueChanged, cmbObjectMoveWhat.ValueChanged, cmbObjectKey1.ValueChanged, cmbObjectPropertyValue.ValueChanged, cmbObjectMoveTo.ValueChanged, cmbObjectKey2.ValueChanged, isPropertyKey1.SelectionChanged, cmbPropertyKey2.ValueChanged, cmbPropertyValue.ValueChanged, cmbVariable.ValueChanged, cmbVariableArray.ValueChanged, cmbIndex.ValueChanged, cmbIndexEdit.TextChanged, txtLoopFrom.TextChanged, txtLoopTo.TextChanged, cmbWhatT.ValueChanged, cmbTasks.ValueChanged, btnParams.Click, cmbEndGame.ValueChanged, cmbLocationWhat.SelectionChanged, cmbLocationMoveWhat.SelectionChanged, cmbLocationKey1.SelectionChanged, cmbLocationMoveTo.SelectionChanged, cmbLocationKey2.SelectionChanged, cmbWhatConv.SelectionChanged, cmbAskWho.SelectionChanged, txtConvTopic.TextChanged, cmbVariableSet.SelectionChanged, chkLoop.CheckedChanged
        SaveAction()
    End Sub


    Private Sub SaveAction()

        If bLoadingAction Then Exit Sub

        btnOK.Enabled = False

        With Action
            Select Case Me.tabsActions.SelectedTab.Text

                Case "Move Objects"
                    If cmbObjectWhat.SelectedItem IsNot Nothing Then .eItem = CType([Enum].Parse(GetType(clsAction.ItemEnum), cmbObjectWhat.SelectedItem.DataValue.ToString), clsAction.ItemEnum)
                    If cmbObjectMoveWhat.SelectedItem IsNot Nothing Then .eMoveObjectWhat = CType([Enum].Parse(GetType(clsAction.MoveObjectWhatEnum), cmbObjectMoveWhat.SelectedItem.DataValue.ToString), clsAction.MoveObjectWhatEnum)
                    If cmbObjectKey1.SelectedItem IsNot Nothing Then .sKey1 = cmbObjectKey1.SelectedItem.DataValue.ToString
                    If cmbObjectPropertyValue IsNot Nothing Then .sPropertyValue = cmbObjectPropertyValue.Value
                    If cmbObjectMoveTo.SelectedItem IsNot Nothing Then .eMoveObjectTo = EnumParseMoveObject(cmbObjectMoveTo.SelectedItem.DataValue.ToString)
                    If cmbObjectKey2.SelectedItem IsNot Nothing Then .sKey2 = cmbObjectKey2.SelectedItem.DataValue.ToString

                    If cmbObjectWhat.SelectedItem IsNot Nothing AndAlso cmbObjectMoveWhat.SelectedItem IsNot Nothing _
                        AndAlso cmbObjectKey1.SelectedItem IsNot Nothing AndAlso (Not cmbObjectPropertyValue.Visible OrElse cmbObjectPropertyValue.Value IsNot Nothing) _
                        AndAlso cmbObjectMoveTo.SelectedItem IsNot Nothing AndAlso cmbObjectKey2.SelectedItem IsNot Nothing Then
                        btnOK.Enabled = True
                    End If

                Case "Move Characters"
                    If cmbCharacterWhat.SelectedItem IsNot Nothing Then .eItem = CType([Enum].Parse(GetType(clsAction.ItemEnum), cmbCharacterWhat.SelectedItem.DataValue.ToString), clsAction.ItemEnum)
                    If cmbCharacterMoveWho.SelectedItem IsNot Nothing Then .eMoveCharacterWho = CType([Enum].Parse(GetType(clsAction.MoveCharacterWhoEnum), cmbCharacterMoveWho.SelectedItem.DataValue.ToString), clsAction.MoveCharacterWhoEnum)
                    If Not cmbCharacterKey1.SelectedItem Is Nothing Then .sKey1 = CStr(cmbCharacterKey1.SelectedItem.DataValue)
                    If cmbCharacterPropertyValue IsNot Nothing Then .sPropertyValue = cmbCharacterPropertyValue.Value
                    If Not cmbCharacterMoveTo.SelectedItem Is Nothing Then .eMoveCharacterTo = EnumParseMoveCharacter(cmbCharacterMoveTo.SelectedItem.DataValue.ToString)
                    If Not cmbCharacterKey2.SelectedItem Is Nothing Then .sKey2 = CStr(cmbCharacterKey2.SelectedItem.DataValue)

                    If cmbCharacterWhat.SelectedItem IsNot Nothing AndAlso cmbCharacterMoveWho.SelectedItem IsNot Nothing _
                       AndAlso cmbCharacterKey1.SelectedItem IsNot Nothing AndAlso (Not cmbCharacterPropertyValue.Visible OrElse cmbCharacterPropertyValue.Value IsNot Nothing) _
                       AndAlso cmbCharacterMoveTo.SelectedItem IsNot Nothing AndAlso (cmbCharacterKey2.SelectedItem IsNot Nothing OrElse cmbCharacterMoveTo.SelectedItem.DataValue.ToString = clsAction.MoveCharacterToEnum.ToParentLocation.ToString) Then
                        btnOK.Enabled = True
                    End If

                    'If Not (cmbCharacterKey1.SelectedItem Is Nothing OrElse cmbCharacterKey2.SelectedItem Is Nothing OrElse (cmbCharacterKey2.SelectedIndex <> 6 AndAlso cmbCharacterMoveTo.SelectedItem Is Nothing)) Then
                    '    btnOK.Enabled = True
                    'End If

                Case "Locations"
                    If cmbLocationWhat.SelectedItem IsNot Nothing Then .eItem = CType([Enum].Parse(GetType(clsAction.ItemEnum), cmbLocationWhat.SelectedItem.DataValue.ToString), clsAction.ItemEnum)
                    If cmbLocationMoveWhat.SelectedItem IsNot Nothing Then .eMoveLocationWhat = CType([Enum].Parse(GetType(clsAction.MoveLocationWhatEnum), cmbLocationMoveWhat.SelectedItem.DataValue.ToString), clsAction.MoveLocationWhatEnum)
                    If Not cmbLocationKey1.SelectedItem Is Nothing Then .sKey1 = CStr(cmbLocationKey1.SelectedItem.DataValue)
                    If cmbLocationPropertyValue IsNot Nothing Then .sPropertyValue = cmbLocationPropertyValue.Value
                    If Not cmbLocationMoveTo.SelectedItem Is Nothing Then .eMoveLocationTo = EnumParseMoveLocation(cmbLocationMoveTo.SelectedItem.DataValue.ToString)
                    If Not cmbLocationKey2.SelectedItem Is Nothing Then .sKey2 = CStr(cmbLocationKey2.SelectedItem.DataValue)

                    If cmbLocationWhat.SelectedItem IsNot Nothing AndAlso cmbLocationMoveWhat.SelectedItem IsNot Nothing _
                       AndAlso cmbLocationKey1.SelectedItem IsNot Nothing _
                       AndAlso cmbLocationMoveTo.SelectedItem IsNot Nothing AndAlso cmbLocationKey2.SelectedItem IsNot Nothing Then
                        btnOK.Enabled = True
                    End If

                Case "Set Properties"
                    .eItem = clsAction.ItemEnum.SetProperties
                    'If Not cmbProperty.SelectedItem Is Nothing Then .sKey1 = CStr(cmbProperty.SelectedItem.DataValue)
                    If isPropertyKey1.Key <> "" Then .sKey1 = isPropertyKey1.Key
                    If Not cmbPropertyKey2.SelectedItem Is Nothing Then .sKey2 = CStr(cmbPropertyKey2.SelectedItem.DataValue)
                    'If Not cmbPropertyExtra.SelectedItem Is Nothing Then .StringValue = CStr(cmbPropertyExtra.SelectedItem.DataValue)
                    If cmbPropertyValue.Value IsNot Nothing Then .sPropertyValue = cmbPropertyValue.Value

                    If isPropertyKey1.Key <> "" AndAlso cmbPropertyKey2.SelectedItem IsNot Nothing AndAlso cmbPropertyValue.Value IsNot Nothing Then
                        btnOK.Enabled = True
                    End If
                    If cmbPropertyValue.ExpressionOrVariable.Visible AndAlso cmbPropertyValue.ExpressionOrVariable.ListType = ItemSelector.ItemEnum.ValueList AndAlso cmbPropertyValue.ExpressionOrVariable.cmbList.SelectedIndex = 0 Then btnOK.Enabled = False ' No Value Selected

                Case "Variables"
                    If cmbVariableSet.SelectedItem Is Nothing Then
                        .eItem = clsAction.ItemEnum.SetVariable
                    Else
                        Select Case cmbVariableSet.SelectedItem.DataValue.ToString
                            Case clsAction.ItemEnum.SetVariable.ToString
                                .eItem = clsAction.ItemEnum.SetVariable
                            Case clsAction.ItemEnum.IncreaseVariable.ToString
                                .eItem = clsAction.ItemEnum.IncreaseVariable
                            Case clsAction.ItemEnum.DecreaseVariable.ToString
                                .eItem = clsAction.ItemEnum.DecreaseVariable
                        End Select
                    End If

                    Dim bIndexRequired As Boolean = False
                    If chkLoop.Checked Then
                        .IntValue = CInt(Val(txtLoopFrom.Text))
                        .sKey2 = CInt(Val(txtLoopTo.Text)).ToString
                        If cmbVariableArray.SelectedItem IsNot Nothing Then .sKey1 = CStr(cmbVariableArray.SelectedItem.DataValue)
                        .eVariables = clsAction.VariablesEnum.Loop
                    Else
                        .IntValue = -1
                        If Not cmbIndex.SelectedItem Is Nothing AndAlso cmbIndex.Visible Then .sKey2 = CStr(cmbIndex.SelectedItem.DataValue)
                        If cmbIndexEdit.Visible Then .sKey2 = CInt(Math.Min(Val(cmbIndexEdit.Text), Integer.MaxValue)).ToString
                        If Not cmbVariable.SelectedItem Is Nothing Then
                            .sKey1 = CStr(cmbVariable.SelectedItem.DataValue)
                            If Adventure.htblVariables(.sKey1).Length > 1 Then bIndexRequired = True
                        End If
                        .eVariables = clsAction.VariablesEnum.Assignment
                    End If
                    .StringValue = Expression.Value

                    If ((chkLoop.Checked AndAlso Not cmbVariableArray.SelectedItem Is Nothing) _
                        OrElse (Not chkLoop.Checked AndAlso Not cmbVariable.SelectedItem Is Nothing AndAlso (Not bIndexRequired OrElse (cmbIndex.Visible AndAlso Not cmbIndex.SelectedItem Is Nothing) OrElse (cmbIndexEdit.Visible AndAlso IsNumeric(cmbIndexEdit.Text))))) _
                        AndAlso .StringValue <> "" Then
                        btnOK.Enabled = True
                    End If

                Case "Tasks"
                    ' TODO: if unset, should only show tasks that are not repeatable

                    If Not cmbWhatT.SelectedItem Is Nothing AndAlso cmbWhatT.SelectedItem.DataValue.ToString = "Execute" AndAlso Not cmbTasks.SelectedItem Is Nothing AndAlso Adventure.htblTasks.ContainsKey(cmbTasks.SelectedItem.DataValue.ToString) _
                        AndAlso Adventure.htblTasks(cmbTasks.SelectedItem.DataValue.ToString).TaskType = clsTask.TaskTypeEnum.General AndAlso Adventure.htblTasks(cmbTasks.SelectedItem.DataValue.ToString).HasReferences Then
                        btnParams.Visible = True
                    Else
                        btnParams.Visible = False
                    End If
                    RepositionDropdowns()

                    .eItem = clsAction.ItemEnum.SetTasks
                    If Not cmbWhatT.SelectedItem Is Nothing Then .eSetTasks = EnumParseSetTask(CStr(cmbWhatT.SelectedItem.DataValue))
                    If Not cmbTasks.SelectedItem Is Nothing Then .sKey1 = cmbTasks.SelectedItem.DataValue.ToString
                    If Not btnParams.Tag Is Nothing AndAlso btnParams.Visible Then .StringValue = btnParams.Tag.ToString Else .StringValue = ""
                    If chkLoop.Checked Then
                        .IntValue = CInt(Val(txtLoopFrom.Text))
                        .sPropertyValue = CInt(Val(txtLoopTo.Text)).ToString
                    Else
                        .IntValue = 0
                        .sPropertyValue = ""
                    End If

                    If Not (cmbWhatT.SelectedItem Is Nothing OrElse cmbTasks.SelectedItem Is Nothing OrElse (btnParams.Visible AndAlso CStr(btnParams.Tag) = "")) Then
                        btnOK.Enabled = True
                    End If

                Case "Conversation"
                    .eItem = clsAction.ItemEnum.Conversation
                    If cmbWhatConv.SelectedItem IsNot Nothing Then .eConversation = CType(cmbWhatConv.SelectedItem.DataValue, clsAction.ConversationEnum)
                    If cmbAskWho.SelectedItem IsNot Nothing Then .sKey1 = cmbAskWho.SelectedItem.DataValue.ToString
                    If txtConvTopic.Visible Then .StringValue = txtConvTopic.Text

                    If cmbWhatConv.SelectedItem IsNot Nothing AndAlso cmbAskWho.SelectedItem IsNot Nothing AndAlso (.eConversation = clsAction.ConversationEnum.EnterConversation OrElse .eConversation = clsAction.ConversationEnum.LeaveConversation OrElse txtConvTopic.Text <> "") Then
                        btnOK.Enabled = True
                    End If

                Case "Time"
                    .eItem = clsAction.ItemEnum.Time
                    .StringValue = expTurns.Value
                    btnOK.Enabled = expTurns.Value <> ""

                Case "End Game"
                    .eItem = clsAction.ItemEnum.EndGame
                    If cmbEndGame.SelectedItem IsNot Nothing Then
                        .eEndgame = EnumParseEndGame(cmbEndGame.SelectedItem.DataValue.ToString)
                        btnOK.Enabled = True
                    End If

            End Select
        End With

    End Sub

    Private Sub frmAction_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveFormPosition(Me)
    End Sub

    Private Sub frmAction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetFormPosition(Me)
        'cmbVariable_SelectionChanged(Nothing, Nothing)
        If DarkInterface() Then
            chkLoop.ForeColor = Color.White
        End If
    End Sub

    Private Sub frmAction_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        Dim iWidth As Integer

        'cmbObjectKey1.Width = cmbObjectMoveTo.Left - cmbObjectKey1.Left + 1
        'cmbObjectKey2.Left = cmbObjectMoveTo.Left + cmbObjectMoveTo.Width - 1
        'cmbObjectKey2.Width = Width - cmbObjectKey2.Left - 22 'CInt(Width / 2 - 130)
        If lblObjectsWithValue.Visible Then
            iWidth = Me.ClientSize.Width - cmbObjectWhat.Width - cmbObjectMoveWhat.Width - lblObjectsWithValue.Width - 30
            cmbObjectKey1.Width = CInt(iWidth / 4)
            lblObjectsWithValue.Left = cmbObjectKey1.Left + cmbObjectKey1.Width
            cmbObjectPropertyValue.Width = CInt(iWidth / 4)
            cmbObjectPropertyValue.Left = lblObjectsWithValue.Left + lblObjectsWithValue.Width
            cmbObjectMoveTo.Width = CInt(iWidth / 4)
            cmbObjectMoveTo.Left = cmbObjectPropertyValue.Left + cmbObjectPropertyValue.Width
            cmbObjectKey2.Left = cmbObjectMoveTo.Left + cmbObjectMoveTo.Width - 1
            cmbObjectKey2.Width = Me.ClientSize.Width - cmbObjectKey2.Left - 10 ' CInt(iWidth / 4)
        Else
            iWidth = Me.ClientSize.Width - cmbObjectWhat.Width - cmbObjectMoveWhat.Width - 30
            cmbObjectKey1.Width = CInt(iWidth / 3)
            cmbObjectMoveTo.Width = CInt(iWidth / 3)
            cmbObjectMoveTo.Left = cmbObjectKey1.Left + cmbObjectKey1.Width - 1
            cmbObjectKey2.Left = cmbObjectMoveTo.Left + cmbObjectMoveTo.Width - 1
            cmbObjectKey2.Width = Me.ClientSize.Width - cmbObjectKey2.Left - 10 ' CInt(iWidth / 4)
        End If
        cmbObjectKey1.DropDownListWidth = Math.Max(cmbObjectKey1.Width, 170)
        cmbObjectMoveTo.DropDownListWidth = Math.Max(cmbObjectMoveTo.Width, 130)
        cmbObjectKey2.DropDownListWidth = Math.Max(cmbObjectKey2.Width, 170)

        If lblCharactersWithValue.Visible Then
            iWidth = Me.ClientSize.Width - cmbCharacterWhat.Width - cmbCharacterMoveWho.Width - lblCharactersWithValue.Width - 30
            cmbCharacterKey1.Width = CInt(iWidth / 4)
            lblCharactersWithValue.Left = cmbCharacterKey1.Left + cmbCharacterKey1.Width
            cmbCharacterPropertyValue.Width = CInt(iWidth / 4)
            cmbCharacterPropertyValue.Left = lblCharactersWithValue.Left + lblCharactersWithValue.Width
            cmbCharacterMoveTo.Width = CInt(iWidth / 4)
            cmbCharacterMoveTo.Left = cmbCharacterPropertyValue.Left + cmbCharacterPropertyValue.Width
            cmbCharacterKey2.Left = cmbCharacterMoveTo.Left + cmbCharacterMoveTo.Width - 1
            cmbCharacterKey2.Width = Me.ClientSize.Width - cmbCharacterKey2.Left - 10 ' CInt(iWidth / 4)
        Else
            iWidth = Me.ClientSize.Width - cmbCharacterWhat.Width - cmbCharacterMoveWho.Width - 30
            cmbCharacterKey1.Width = CInt(iWidth / 3)
            cmbCharacterMoveTo.Width = CInt(iWidth / 3)
            cmbCharacterMoveTo.Left = cmbCharacterKey1.Left + cmbCharacterKey1.Width - 1
            cmbCharacterKey2.Left = cmbCharacterMoveTo.Left + cmbCharacterMoveTo.Width - 1
            cmbCharacterKey2.Width = Me.ClientSize.Width - cmbCharacterKey2.Left - 10 ' CInt(iWidth / 4)
        End If
        cmbCharacterKey1.DropDownListWidth = Math.Max(cmbCharacterKey1.Width, 170)
        cmbCharacterMoveTo.DropDownListWidth = Math.Max(cmbCharacterMoveTo.Width, 130)
        cmbCharacterKey2.DropDownListWidth = Math.Max(cmbCharacterKey2.Width, 170)

        If lblLocationsWithValue.Visible Then
            iWidth = Me.ClientSize.Width - cmbLocationWhat.Width - cmbLocationMoveWhat.Width - lblLocationsWithValue.Width - 30
            cmbLocationKey1.Width = CInt(iWidth / 4)
            lblLocationsWithValue.Left = cmbLocationKey1.Left + cmbLocationKey1.Width
            cmbLocationPropertyValue.Width = CInt(iWidth / 4)
            cmbLocationPropertyValue.Left = lblLocationsWithValue.Left + lblLocationsWithValue.Width
            cmbLocationMoveTo.Width = CInt(iWidth / 4)
            cmbLocationMoveTo.Left = cmbLocationPropertyValue.Left + cmbLocationPropertyValue.Width
            cmbLocationKey2.Left = cmbLocationMoveTo.Left + cmbLocationMoveTo.Width - 1
            cmbLocationKey2.Width = Me.ClientSize.Width - cmbLocationKey2.Left - 10 ' CInt(iWidth / 4)
        Else
            iWidth = Me.ClientSize.Width - cmbLocationWhat.Width - cmbLocationMoveWhat.Width - 30
            cmbLocationKey1.Width = CInt(iWidth / 3)
            cmbLocationMoveTo.Width = CInt(iWidth / 3)
            cmbLocationMoveTo.Left = cmbLocationKey1.Left + cmbLocationKey1.Width - 1
            cmbLocationKey2.Left = cmbLocationMoveTo.Left + cmbLocationMoveTo.Width - 1
            cmbLocationKey2.Width = Me.ClientSize.Width - cmbLocationKey2.Left - 10 ' CInt(iWidth / 4)
        End If
        cmbLocationKey1.DropDownListWidth = Math.Max(cmbLocationKey1.Width, 170)
        cmbLocationMoveTo.DropDownListWidth = Math.Max(cmbLocationMoveTo.Width, 130)
        cmbLocationKey2.DropDownListWidth = Math.Max(cmbLocationKey2.Width, 170)

        'cmbCharacterKey1.Width = cmbCharacterKey2.Left - cmbCharacterKey1.Left
        'cmbCharacterMoveTo.Left = cmbCharacterKey2.Left + cmbCharacterKey2.Width
        'cmbCharacterMoveTo.Width = Width - cmbCharacterMoveTo.Left - 20 ' CInt(Width / 2 - 100)

        iWidth = Me.ClientSize.Width - lblTo.Width - 30
        isPropertyKey1.Width = CInt(iWidth / 3) '- 40
        cmbPropertyKey2.Left = isPropertyKey1.Left + isPropertyKey1.Width
        cmbPropertyKey2.Width = CInt(iWidth / 3) '+ 9
        lblTo.Left = cmbPropertyKey2.Left + cmbPropertyKey2.Width + 3
        cmbPropertyValue.Left = cmbPropertyKey2.Left + cmbPropertyKey2.Width + 20
        cmbPropertyValue.Width = Me.ClientSize.Width - cmbPropertyValue.Left - 10

        If cmbVariable.SelectedItem IsNot Nothing Then
            'Dim v As clsVariable = Nothing
            'If cmbVariable.SelectedItem IsNot Nothing Then v = Adventure.htblVariables(cmbVariable.SelectedItem.DataValue.ToString)
            'If v IsNot Nothing AndAlso v.Length > 1 Then
            '    Expression.Width = Width - Expression.Left - 20 '44
            'Else
            '    Expression.Width = Width - Expression.Left - 25 '49
            'End If
            Expression.Width = Me.ClientSize.Width - Expression.Left - 10
        Else
            'Expression.Width = Width - Expression.Left - 25 '49
            Expression.Width = Me.ClientSize.Width - Expression.Left - 10
        End If

    End Sub

    Private Sub isPropertyKey1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles isPropertyKey1.SelectionChanged

        cmbPropertyKey2.Items.Clear()

        Select Case isPropertyKey1.ListType
            Case ItemSelector.ItemEnum.Object
                If CStr(isPropertyKey1.Key).StartsWith("ReferencedObject") Then
                    For Each prop As clsProperty In Adventure.htblObjectProperties.Values
                        'If prop.Type <> clsProperty.PropertyTypeEnum.SelectionOnly AndAlso Not (prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.AppendToProperty <> "") Then
                        ' Need to be able to check/uncheck SelectionOnly properties, e.g. set Purchased to Selected
                        If Not (prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.AppendToProperty <> "") Then
                            cmbPropertyKey2.Items.Add(prop.Key, prop.Description)
                        End If
                    Next
                Else
                    If Adventure.htblObjects.ContainsKey(isPropertyKey1.Key) Then
                        Dim ob As clsObject = Adventure.htblObjects(isPropertyKey1.Key)

                        If ob IsNot Nothing Then
                            For Each prop As clsProperty In Adventure.htblObjectProperties.Values
                                If ob.htblProperties.ContainsKey(prop.Key) OrElse prop.Type = clsProperty.PropertyTypeEnum.SelectionOnly OrElse prop.GroupOnly Then
                                    If Not (prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.AppendToProperty <> "") Then
                                        cmbPropertyKey2.Items.Add(prop.Key, prop.Description)
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If

            Case ItemSelector.ItemEnum.Character
                If isPropertyKey1.Key <> "" Then cmbPropertyKey2.Items.Add(CHARACTERPROPERNAME, "Name") ' A fake property, for access to name
                If CStr(isPropertyKey1.Key).StartsWith("ReferencedCharacter") Then
                    For Each prop As clsProperty In Adventure.htblCharacterProperties.Values
                        If Not (prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.AppendToProperty <> "") Then
                            cmbPropertyKey2.Items.Add(prop.Key, prop.Description)
                        End If
                    Next
                Else
                    Dim ch As clsCharacter = Nothing
                    If Adventure.htblCharacters.ContainsKey(isPropertyKey1.Key) Then ch = Adventure.htblCharacters(isPropertyKey1.Key)
                    If isPropertyKey1.Key = "%Player%" Then ch = Adventure.Player

                    If ch IsNot Nothing Then
                        For Each prop As clsProperty In ch.htblProperties.Values
                            If Not (prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.AppendToProperty <> "") Then
                                cmbPropertyKey2.Items.Add(prop.Key, prop.Description)
                            End If
                        Next
                        ' Add any selection properties that the character doesn't currently have, so they can be added during the game
                        For Each prop As clsProperty In Adventure.htblCharacterProperties.Values
                            If Not ch.htblProperties.ContainsKey(prop.Key) AndAlso prop.Type = clsProperty.PropertyTypeEnum.SelectionOnly OrElse prop.GroupOnly Then
                                cmbPropertyKey2.Items.Add(prop.Key, prop.Description)
                            End If
                        Next
                    End If

                End If

            Case ItemSelector.ItemEnum.Location
                'If isProperty.Key <> "" Then cmbWhatP.Items.Add(CHARACTERPROPERNAME, "Name") ' A fake property, for access to name
                If CStr(isPropertyKey1.Key).StartsWith("ReferencedLocation") Then
                    For Each prop As clsProperty In Adventure.htblLocationProperties.Values
                        If Not (prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.AppendToProperty <> "") Then
                            cmbPropertyKey2.Items.Add(prop.Key, prop.Description)
                        End If
                    Next
                Else
                    If Adventure.htblLocations.ContainsKey(isPropertyKey1.Key) Then
                        Dim loc As clsLocation = Adventure.htblLocations(isPropertyKey1.Key)

                        If loc IsNot Nothing Then
                            For Each prop As clsProperty In loc.htblProperties.Values
                                If Not (prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.AppendToProperty <> "") Then
                                    cmbPropertyKey2.Items.Add(prop.Key, prop.Description)
                                End If
                            Next
                            ' Add any selection properties that the character doesn't currently have, so they can be added during the game
                            For Each prop As clsProperty In Adventure.htblLocationProperties.Values
                                If Not loc.htblProperties.ContainsKey(prop.Key) AndAlso prop.Type = clsProperty.PropertyTypeEnum.SelectionOnly OrElse prop.GroupOnly Then
                                    cmbPropertyKey2.Items.Add(prop.Key, prop.Description)
                                End If
                            Next
                        End If
                    End If
                End If

        End Select

    End Sub

    Private Sub cmbPropertyKey2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPropertyKey2.SelectionChanged

        Dim sPropKey As String = CStr(cmbPropertyKey2.SelectedItem.DataValue)
        cmbPropertyValue.PropertyKey = sPropKey

    End Sub


    Private Sub chkLoop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLoop.CheckedChanged
        RepositionDropdowns()
    End Sub


    Private Sub cmbVariableSet_ValueChanged(sender As Object, e As EventArgs) Handles cmbVariableSet.ValueChanged

        Dim sPre As String = ""
        Dim v As clsVariable = Nothing
        If cmbVariable.SelectedItem IsNot Nothing Then v = Adventure.htblVariables(cmbVariable.SelectedItem.DataValue.ToString)
        If v IsNot Nothing AndAlso v.Length > 1 Then sPre = "]  "

        'bAllowPaint = False
        Select Case cmbVariableSet.SelectedItem.DataValue.ToString
            Case clsAction.ItemEnum.SetVariable.ToString
                lblRight.Text = sPre & "="
                lblLoop.Text = "[Loop]   ="
            Case clsAction.ItemEnum.IncreaseVariable.ToString, clsAction.ItemEnum.DecreaseVariable.ToString
                lblRight.Text = sPre & " by "
                lblLoop.Text = "[Loop]   by "
        End Select
        'Expression.Visible = False
        'Expression.Left = lblRight.Left + lblRight.Width
        'Expression.Width = Me.ClientSize.Width - Expression.Left - 10
        'Expression.Visible = True
        RepositionDropdowns()

    End Sub


    ' Clever function to suspend painting the form whilst we play around with it, to stop horrible flickers
    Private bAllowPaint As Boolean = True
    Protected Overrides Sub WndProc(ByRef m As Message)
        If bAllowPaint OrElse m.Msg <> &HF Then
            MyBase.WndProc(m)
        End If
    End Sub


    Private Sub RepositionDropdowns()

        Dim v As clsVariable = Nothing
        If cmbVariable.SelectedItem IsNot Nothing Then v = Adventure.htblVariables(cmbVariable.SelectedItem.DataValue.ToString)

        Expression.Visible = False
        If Me.chkLoop.Checked Then
            MaximumSize = New Size(1600, 243)
            MinimumSize = New Size(544, 243)
            Height = 243
            lblFor.Visible = True
            lblTo2.Visible = True
            txtLoopFrom.Visible = True
            txtLoopTo.Visible = True
            lblLoop.Visible = True
            lblNext.Visible = True
            cmbVariableArray.Visible = True
            cmbVariable.Visible = False
            Expression.Left = lblLoop.Left + lblLoop.Width
            Expression.Top = 59
            cmbVariableArray.Location = New Point(135, 59)
            cmbVariableSet.Location = New Point(54, 59)
            cmbWhatT.Location = New Point(54, 59)
            cmbTasks.Location = New Point(168, 59)
            btnParams.Location = New Point(Me.Width - 100, 59)
            cmbTasks.Width = btnParams.Left - cmbWhatT.Location.X - cmbWhatT.Width - 5 + CInt(If(btnParams.Visible, 0, 80))
            cmbIndex.Visible = False
            cmbIndexEdit.Visible = False
            lblLeft.Visible = False
            lblRight.Visible = False
            If Me.tabsActions.SelectedTab.Text = "Variables" AndAlso cmbVariableArray.SelectedItem IsNot Nothing Then SetCombo(cmbVariableArray, cmbVariable.SelectedItem.DataValue.ToString)
        Else
            MinimumSize = New Size(544, 148)
            MaximumSize = New Size(1600, 148)
            Height = 148
            lblFor.Visible = False
            lblTo2.Visible = False
            txtLoopFrom.Visible = False
            txtLoopTo.Visible = False
            lblLoop.Visible = False
            lblNext.Visible = False
            cmbVariableSet.Location = New Point(11, 9)
            cmbWhatT.Location = New Point(11, 9)
            cmbTasks.Location = New Point(125, 9)
            btnParams.Location = New Point(Me.Width - 100, 9)
            cmbTasks.Width = btnParams.Left - cmbWhatT.Location.X - cmbWhatT.Width - 5 + CInt(If(btnParams.Visible, 0, 80))            
            If cmbVariableArray.Visible Then
                cmbVariableArray.Visible = False
                cmbVariable.Visible = True
                If Me.tabsActions.SelectedTab.Text = "Variables" AndAlso cmbVariableArray.SelectedItem IsNot Nothing Then SetCombo(cmbVariable, cmbVariableArray.SelectedItem.DataValue.ToString)
            End If
            lblRight.Visible = True
            cmbVariable_SelectionChanged(Nothing, Nothing)
            Dim sPost As String = "="
            If cmbVariableSet.SelectedItem IsNot Nothing AndAlso cmbVariableSet.SelectedItem.DataValue.ToString <> "SetVariable" Then sPost = " by "
            If v IsNot Nothing AndAlso v.Length > 1 Then                
                cmbIndex.Visible = True
                lblLeft.Visible = True
                cmbVariable.Size = New Size(126, 21)
                lblLeft.Left = cmbVariable.Left + cmbVariable.Width
                cmbIndex.Left = lblLeft.Left + lblLeft.Width
                cmbIndexEdit.Location = cmbIndex.Location
                cmbIndexEdit.Size = cmbIndex.Size
                lblRight.Text = "]  " & sPost
                lblRight.Left = cmbIndex.Left + cmbIndex.Width
            Else
                chkLoop.Checked = False
                UltraStatusBar1.Panels(0).Visible = False ' Show loop checkbox
                cmbIndex.Visible = False
                cmbIndexEdit.Visible = False
                lblLeft.Visible = False
                cmbVariable.Size = New Size(200, 21)
                lblRight.Text = sPost
                lblRight.Left = cmbVariable.Left + cmbVariable.Width
            End If
            Expression.Left = lblRight.Left + lblRight.Width            
            Expression.Top = 9            
        End If
        Expression.Width = Me.ClientSize.Width - Expression.Left - 10
        Expression.Visible = True

        Dim page As Infragistics.Win.UltraWinTabControl.UltraTabPageControl = Nothing

        If tabsActions.SelectedTab IsNot Nothing Then
            Select Case tabsActions.SelectedTab.Text
                Case "Variables"
                    page = Me.UltraTabPageControl4
                    If cmbVariable.SelectedIndex > -1 AndAlso Adventure.htblVariables(cmbVariable.SelectedItem.DataValue.ToString).Length > 1 Then UltraStatusBar1.Panels(0).Visible = True

                Case "Tasks"
                    page = Me.UltraTabPageControl6
                    If chkLoop.Checked AndAlso cmbVariableArray.SelectedItem IsNot Nothing Then SetCombo(cmbVariableArray, cmbVariable.SelectedItem.DataValue.ToString)
                    UltraStatusBar1.Panels(0).Visible = True

                Case Else
                    UltraStatusBar1.Panels(0).Visible = False

            End Select
        End If

        If page IsNot Nothing Then
            lblFor.Parent = page
            lblTo2.Parent = page
            txtLoopFrom.Parent = page
            txtLoopTo.Parent = page
            lblNext.Parent = page
        End If

    End Sub


    Private Sub cmbVariable_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbVariable.SelectionChanged

        Dim v As clsVariable = Nothing
        If cmbVariable.SelectedItem IsNot Nothing Then v = Adventure.htblVariables(cmbVariable.SelectedItem.DataValue.ToString)

        Dim sPost As String = "="
        If cmbVariableSet.SelectedItem IsNot Nothing AndAlso cmbVariableSet.SelectedItem.DataValue.ToString <> "SetVariable" Then sPost = " by "

        If sender IsNot Nothing Then RepositionDropdowns()

        'If v IsNot Nothing AndAlso v.Length > 1 Then
        '    'chkLoop.Visible = True
        '    UltraStatusBar1.Panels(0).Visible = True ' Show loop checkbox
        '    If Not chkLoop.Checked Then
        '        cmbIndex.Visible = True
        '        lblLeft.Visible = True
        '        cmbVariable.Size = New Size(126, 21)
        '        lblLeft.Left = cmbVariable.Left + cmbVariable.Width
        '        cmbIndex.Left = lblLeft.Left + lblLeft.Width
        '        cmbIndexEdit.Location = cmbIndex.Location
        '        cmbIndexEdit.Size = cmbIndex.Size
        '        lblRight.Text = "]  " & sPost
        '        lblRight.Left = cmbIndex.Left + cmbIndex.Width
        '        Expression.Visible = False
        '        Expression.Left = lblRight.Left + lblRight.Width
        '        'Expression.Top = 50
        '        'Expression.Width = Width - Expression.Left - 20 '44
        '        'Expression.Width = UltraTabPageControl1.Width - Expression.Left - 10
        '        Expression.Width = Me.ClientSize.Width - Expression.Left - 10
        '        Expression.Visible = True
        '    End If
        'Else
        '    chkLoop.Checked = False
        '    UltraStatusBar1.Panels(0).Visible = False ' Show loop checkbox
        '    cmbIndex.Visible = False
        '    cmbIndexEdit.Visible = False
        '    lblLeft.Visible = False
        '    cmbVariable.Size = New Size(200, 21)
        '    lblRight.Text = sPost
        '    lblRight.Left = cmbVariable.Left + cmbVariable.Width
        '    Expression.Visible = False
        '    Expression.Left = lblRight.Left + lblRight.Width
        '    'Expression.Width = Width - Expression.Left - 25 '49
        '    'Expression.Width = UltraTabPageControl1.Width - Expression.Left - 10
        '    Expression.Width = Me.ClientSize.Width - Expression.Left - 10
        '    Expression.Visible = True
        'End If

        If v IsNot Nothing AndAlso v.Type = clsVariable.VariableTypeEnum.Text Then
            SetCombo(cmbVariableSet, clsAction.ItemEnum.SetVariable.ToString)
            cmbVariableSet.Enabled = False
            cmbVariableSet.Appearance.ForeColorDisabled = Color.Black
        Else
            cmbVariableSet.Enabled = True
        End If

        'RepositionDropdowns()

    End Sub


    Private Sub Expression_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Expression.ValueChanged
        SaveAction()
    End Sub

    Private Sub cmbIndexEdit_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbIndexEdit.SelectionChanged

        If cmbIndexEdit.SelectedIndex = 0 Then
            cmbIndexEdit.Visible = False
            cmbIndex.Visible = True
            cmbIndex.SelectedIndex = 1
        End If

    End Sub


    Private Sub cmbTasks_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTasks.ValueChanged

        Dim tasSelected As clsTask = Adventure.htblTasks(cmbTasks.SelectedItem.DataValue.ToString)
        Dim sParams As String = ""

        For Each sRef As String In tasSelected.References
            sParams &= sRef & "|"
        Next
        If sParams.Length > 0 Then sParams = sLeft(sParams, sParams.Length - 1)

        btnParams.Tag = sParams

    End Sub


    Private Sub btnParams_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParams.Click

        'TODO: Replace this with a nice form where you can click on the links again

        Dim iRef As Integer = 0
        Dim sNewRef As String
        Dim tasSelected As clsTask = Adventure.htblTasks(cmbTasks.SelectedItem.DataValue.ToString)
        Dim sNewParams As String = ""

        For Each sRef As String In Split(btnParams.Tag.ToString, "|")
            iRef += 1
            sNewRef = InputBox("Please enter parameter for reference " & iRef & "." & vbCrLf & vbCrLf & """" & tasSelected.MakeNice & """" & vbCrLf & vbCrLf & "This must either be an object/character key, direction, or a function that resolves to one, e.g. %ParentOf[%object3%]%", "Enter Parameter " & iRef, sRef)
            If sNewRef = "" Then Exit Sub
            sNewParams &= sNewRef & "|"
        Next
        If sNewParams.Length > 0 Then sNewParams = sLeft(sNewParams, sNewParams.Length - 1)

        btnParams.Tag = sNewParams
        SaveAction()

    End Sub


    Private Sub isProperty_FilledList(ByVal sender As Object, ByVal e As System.EventArgs) Handles isPropertyKey1.FilledList

        Select Case isPropertyKey1.ListType
            Case ItemSelector.ItemEnum.Object
                arlObjectRefs = GetReferences(ReferencesType.Object, Me.sCommand)

                For Each o As String In arlObjectRefs
                    isPropertyKey1.cmbList.Items.Add(o, Adventure.GetNameFromKey(o, False))
                Next

            Case ItemSelector.ItemEnum.Character
                arlCharacterRefs = GetReferences(ReferencesType.Character, Me.sCommand)

                For Each c As String In arlCharacterRefs
                    isPropertyKey1.cmbList.Items.Add(c, Adventure.GetNameFromKey(c, False))
                Next

            Case ItemSelector.ItemEnum.Location
                arlLocationRefs = GetReferences(ReferencesType.Location, Me.sCommand)

                For Each l As String In arlLocationRefs
                    isPropertyKey1.cmbList.Items.Add(l, Adventure.GetNameFromKey(l, False))
                Next

        End Select

    End Sub


    Private Sub frmAction_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        frmAction_Resize(Nothing, Nothing)
    End Sub


    Private Sub cmbCharacterWhat_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbCharacterWhat.SelectionChanged
        LoadCharMoveToCombo()
    End Sub

    Private Sub cmbLocationWhat_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbLocationWhat.SelectionChanged
        LoadLocationMoveToCombo()
    End Sub

    Private Sub cmbWhatConv_ValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbWhatConv.ValueChanged

        Dim eConversationEnum As clsAction.ConversationEnum
        If cmbWhatConv.SelectedItem Is Nothing Then
            eConversationEnum = clsAction.ConversationEnum.Ask
        Else
            eConversationEnum = CType(cmbWhatConv.SelectedItem.DataValue, clsAction.ConversationEnum)
        End If

        Select Case eConversationEnum
            Case clsAction.ConversationEnum.Ask, clsAction.ConversationEnum.Tell
                cmbAskWho.Left = cmbWhatConv.Left + cmbWhatConv.Width - 1
                lblConvAbout.Left = cmbAskWho.Left + cmbAskWho.Width + 5
                lblConvAbout.Text = "about"
                txtConvTopic.Left = lblConvAbout.Left + lblConvAbout.Width - 7
                txtConvTopic.Width = Me.Width - txtConvTopic.Left - 30
                txtConvTopic.Visible = True
                lblConvAbout.Anchor = AnchorStyles.Left Or AnchorStyles.Top
                cmbAskWho.Anchor = AnchorStyles.Left Or AnchorStyles.Top
            Case clsAction.ConversationEnum.Command
                txtConvTopic.Left = cmbWhatConv.Left + cmbWhatConv.Width - 1
                txtConvTopic.Width = Me.Width - txtConvTopic.Left - 205
                lblConvAbout.Text = "to"
                lblConvAbout.Left = txtConvTopic.Left + txtConvTopic.Width + 5
                cmbAskWho.Left = lblConvAbout.Left + lblConvAbout.Width - 22
                lblConvAbout.Anchor = AnchorStyles.Right Or AnchorStyles.Top
                cmbAskWho.Anchor = AnchorStyles.Right Or AnchorStyles.Top
                txtConvTopic.Visible = True

            Case clsAction.ConversationEnum.EnterConversation, clsAction.ConversationEnum.LeaveConversation
                txtConvTopic.Visible = False
                lblConvAbout.Left = cmbWhatConv.Left + cmbWhatConv.Width + 5
                lblConvAbout.Text = "with"
                cmbAskWho.Left = lblConvAbout.Left + lblConvAbout.Width - 15
                lblConvAbout.Anchor = AnchorStyles.Left Or AnchorStyles.Top
                cmbAskWho.Anchor = AnchorStyles.Left Or AnchorStyles.Top

            Case clsAction.ConversationEnum.Farewell, clsAction.ConversationEnum.Greet
                ' Not currently in use
        End Select
    End Sub


    Private Sub expTurns_ValueChanged(sender As Object, e As System.EventArgs) Handles expTurns.ValueChanged
        SaveAction()
    End Sub

End Class
