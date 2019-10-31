Public Class frmTask
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public bKeepOpen As Boolean = False

    Public Sub New(ByRef Task As clsTask, ByVal bShow As Boolean)
        MyBase.New()

        ' Check that this window isn't already open
        For Each w As Form In OpenForms ' My.Application.OpenForms
            If TypeOf w Is frmTask Then
                If CType(w, frmTask).cTask.Key = Task.Key AndAlso Task.Key IsNot Nothing Then
                    w.BringToFront()
                    w.Focus()
                    Exit Sub
                End If
            End If
        Next

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Application.EnableVisualStyles()
        LoadForm(Task, bShow)
        bKeepOpen = Not bShow

        ' For some weird reason, it keeps removing these lines from below:
        'Me.Actions1 = New ADRIFT.Actions
        'Me.RestrictDetails1 = New ADRIFT.RestrictDetails

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
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents btnApply As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents RestrictDetails1 As ADRIFT.RestrictDetails
    Friend WithEvents txtName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbGeneralTask As AutoCompleteCombo
    Friend WithEvents lblSystem As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblComplete As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents tabsMain As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents txtCompletion As ADRIFT.GenTextbox
    Friend WithEvents BlueBorder As Infragistics.Win.UltraWinEditors.UltraTextEditor
    'Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnParent As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnChildren As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Actions1 As ADRIFT.Actions
    Friend WithEvents UltraTabPageControl7 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents udTaskPriority As System.Windows.Forms.NumericUpDown
    Friend WithEvents UltraTabPageControl8 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UTMPopup As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _frmTask_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmTask_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmTask_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmTask_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents udAutoFillPriority As System.Windows.Forms.NumericUpDown
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents lblAutoFillPriority As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFailOverride As ADRIFT.GenTextbox
    Friend WithEvents SpecificTask1 As ADRIFT.SpecificTask
    Friend WithEvents cmbBeforeAfter As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grpSpecific As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grpSystem As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grpGeneral As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    'Friend WithEvents optTaskType As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents txtCommands As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkExecuteParentActions As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkReplaceKey As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkPreventOverriding As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkSystem As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkGeneral As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkSpecific As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkRepeatable As System.Windows.Forms.CheckBox
    Friend WithEvents UltraCheckEditor1 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbSystemTrigger As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmbSystemTriggerLocation As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmbSpecificOverrideType As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkOutputParentText As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents lblAutofillDisabled As System.Windows.Forms.Label
    Friend WithEvents chkContinue As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkAggregate As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkLowPriority As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab7 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab8 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab9 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab10 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim PopupMenuTool1 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("ctxmPopup")
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.grpGeneral = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCommands = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.grpSystem = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbSystemTriggerLocation = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbSystemTrigger = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblSystem = New Infragistics.Win.Misc.UltraLabel()
        Me.grpSpecific = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbSpecificOverrideType = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.SpecificTask1 = New ADRIFT.SpecificTask()
        Me.chkExecuteParentActions = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.cmbGeneralTask = New AutoCompleteCombo
        Me.BlueBorder = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.chkOutputParentText = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkSpecific = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkGeneral = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkSystem = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnParent = New Infragistics.Win.Misc.UltraButton()
        Me.btnChildren = New Infragistics.Win.Misc.UltraButton()
        Me.lblComplete = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCompletion = New ADRIFT.GenTextbox()
        Me.lblName = New Infragistics.Win.Misc.UltraLabel()
        Me.txtName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.RestrictDetails1 = New ADRIFT.RestrictDetails()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Actions1 = New ADRIFT.Actions()
        Me.UltraTabPageControl8 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UltraTabPageControl7 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.txtFailOverride = New ADRIFT.GenTextbox()
        Me.chkContinue = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.lblAutofillDisabled = New System.Windows.Forms.Label()
        Me.chkPreventOverriding = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkReplaceKey = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.cmbBeforeAfter = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.udAutoFillPriority = New System.Windows.Forms.NumericUpDown()
        Me.lblAutoFillPriority = New System.Windows.Forms.Label()
        Me.chkLowPriority = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.udTaskPriority = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkRepeatable = New System.Windows.Forms.CheckBox()
        Me.UltraCheckEditor1 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.tabsMain = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.btnApply = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._frmTask_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UTMPopup = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._frmTask_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._frmTask_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._frmTask_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.chkAggregate = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.grpGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGeneral.SuspendLayout()
        CType(Me.txtCommands, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSystem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSystem.SuspendLayout()
        CType(Me.cmbSystemTriggerLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSystemTrigger, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSpecific, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSpecific.SuspendLayout()
        CType(Me.cmbSpecificOverrideType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExecuteParentActions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbGeneralTask, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BlueBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOutputParentText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSpecific, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSystem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        Me.UltraTabPageControl8.SuspendLayout()
        Me.UltraTabPageControl7.SuspendLayout()
        CType(Me.chkContinue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPreventOverriding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkReplaceKey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbBeforeAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udAutoFillPriority, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLowPriority, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udTaskPriority, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraCheckEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabsMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsMain.SuspendLayout()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraStatusBar1.SuspendLayout()
        CType(Me.UTMPopup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAggregate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.grpGeneral)
        Me.UltraTabPageControl1.Controls.Add(Me.grpSystem)
        Me.UltraTabPageControl1.Controls.Add(Me.grpSpecific)
        Me.UltraTabPageControl1.Controls.Add(Me.chkSpecific)
        Me.UltraTabPageControl1.Controls.Add(Me.chkGeneral)
        Me.UltraTabPageControl1.Controls.Add(Me.chkSystem)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl1.Controls.Add(Me.btnParent)
        Me.UltraTabPageControl1.Controls.Add(Me.btnChildren)
        Me.UltraTabPageControl1.Controls.Add(Me.lblComplete)
        Me.UltraTabPageControl1.Controls.Add(Me.txtCompletion)
        Me.UltraTabPageControl1.Controls.Add(Me.lblName)
        Me.UltraTabPageControl1.Controls.Add(Me.txtName)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(569, 432)
        '
        'grpGeneral
        '
        Me.grpGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.grpGeneral.Appearance = Appearance1
        Me.grpGeneral.Controls.Add(Me.UltraLabel3)
        Me.grpGeneral.Controls.Add(Me.txtCommands)
        Me.grpGeneral.Location = New System.Drawing.Point(8, 65)
        Me.grpGeneral.Name = "grpGeneral"
        Me.grpGeneral.Size = New System.Drawing.Size(555, 123)
        Me.grpGeneral.TabIndex = 2
        Me.grpGeneral.Text = "General Task"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(14, 22)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(446, 13)
        Me.UltraLabel3.TabIndex = 1
        Me.UltraLabel3.Text = "Enter any number of commands, using wildcards or advanced command construction"
        '
        'txtCommands
        '
        Me.txtCommands.AlwaysInEditMode = True
        Me.txtCommands.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommands.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommands.HideSelection = False
        Me.txtCommands.Location = New System.Drawing.Point(14, 39)
        Me.txtCommands.Multiline = True
        Me.txtCommands.Name = "txtCommands"
        Me.txtCommands.Scrollbars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCommands.Size = New System.Drawing.Size(527, 74)
        Me.txtCommands.TabIndex = 2
        '
        'grpSystem
        '
        Me.grpSystem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.grpSystem.Appearance = Appearance2
        Me.grpSystem.Controls.Add(Me.cmbSystemTriggerLocation)
        Me.grpSystem.Controls.Add(Me.cmbSystemTrigger)
        Me.grpSystem.Controls.Add(Me.UltraLabel4)
        Me.grpSystem.Controls.Add(Me.lblSystem)
        Me.grpSystem.Location = New System.Drawing.Point(8, 65)
        Me.grpSystem.Name = "grpSystem"
        Me.grpSystem.Size = New System.Drawing.Size(555, 123)
        Me.grpSystem.TabIndex = 21
        Me.grpSystem.Text = "System Task"
        '
        'cmbSystemTriggerLocation
        '
        Me.cmbSystemTriggerLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSystemTriggerLocation.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbSystemTriggerLocation.Location = New System.Drawing.Point(288, 69)
        Me.cmbSystemTriggerLocation.Name = "cmbSystemTriggerLocation"
        Me.cmbSystemTriggerLocation.Size = New System.Drawing.Size(253, 21)
        Me.cmbSystemTriggerLocation.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbSystemTriggerLocation.TabIndex = 23
        Me.cmbSystemTriggerLocation.Visible = False
        '
        'cmbSystemTrigger
        '
        Me.cmbSystemTrigger.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "Only if called by event/task"
        ValueListItem2.DataValue = "Immediately"
        ValueListItem3.DataValue = "Player enters location"
        Me.cmbSystemTrigger.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.cmbSystemTrigger.Location = New System.Drawing.Point(124, 69)
        Me.cmbSystemTrigger.Name = "cmbSystemTrigger"
        Me.cmbSystemTrigger.Size = New System.Drawing.Size(165, 21)
        Me.cmbSystemTrigger.TabIndex = 21
        Me.cmbSystemTrigger.Text = "Only if called by event/task"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel4.Location = New System.Drawing.Point(16, 73)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(154, 29)
        Me.UltraLabel4.TabIndex = 22
        Me.UltraLabel4.Text = "Run this task when:"
        '
        'lblSystem
        '
        Me.lblSystem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSystem.Location = New System.Drawing.Point(16, 33)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(527, 41)
        Me.lblSystem.TabIndex = 0
        Me.lblSystem.Text = "System tasks are not executed by matching player commands.  They can only be trig" & _
    "gered by other tasks, events, or by a scenario below. "
        '
        'grpSpecific
        '
        Me.grpSpecific.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Me.grpSpecific.Appearance = Appearance3
        Me.grpSpecific.Controls.Add(Me.cmbSpecificOverrideType)
        Me.grpSpecific.Controls.Add(Me.SpecificTask1)
        Me.grpSpecific.Controls.Add(Me.chkExecuteParentActions)
        Me.grpSpecific.Controls.Add(Me.cmbGeneralTask)
        Me.grpSpecific.Controls.Add(Me.BlueBorder)
        Me.grpSpecific.Controls.Add(Me.chkOutputParentText)
        Me.grpSpecific.Controls.Add(Me.Label3)
        Me.grpSpecific.Location = New System.Drawing.Point(8, 65)
        Me.grpSpecific.Name = "grpSpecific"
        Me.grpSpecific.Size = New System.Drawing.Size(555, 123)
        Me.grpSpecific.TabIndex = 20
        Me.grpSpecific.Text = "Specific Task"
        '
        'cmbSpecificOverrideType
        '
        Me.cmbSpecificOverrideType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem4.DataValue = "run before"
        ValueListItem5.DataValue = "override"
        ValueListItem6.DataValue = "run after"
        Me.cmbSpecificOverrideType.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem4, ValueListItem5, ValueListItem6})
        Me.cmbSpecificOverrideType.Location = New System.Drawing.Point(82, 33)
        Me.cmbSpecificOverrideType.Name = "cmbSpecificOverrideType"
        Me.cmbSpecificOverrideType.Size = New System.Drawing.Size(96, 21)
        Me.cmbSpecificOverrideType.TabIndex = 21
        Me.cmbSpecificOverrideType.Text = "run before"
        '
        'SpecificTask1
        '
        Me.SpecificTask1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SpecificTask1.Location = New System.Drawing.Point(13, 62)
        Me.SpecificTask1.Name = "SpecificTask1"
        Me.SpecificTask1.Size = New System.Drawing.Size(534, 24)
        Me.SpecificTask1.TabIndex = 17
        '
        'chkExecuteParentActions
        '
        Me.chkExecuteParentActions.BackColor = System.Drawing.Color.Transparent
        Me.chkExecuteParentActions.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkExecuteParentActions.Location = New System.Drawing.Point(360, 94)
        Me.chkExecuteParentActions.Name = "chkExecuteParentActions"
        Me.chkExecuteParentActions.Size = New System.Drawing.Size(170, 20)
        Me.chkExecuteParentActions.TabIndex = 17
        Me.chkExecuteParentActions.Text = "Execute parent actions"
        '
        'cmbGeneralTask
        '
        Me.cmbGeneralTask.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbGeneralTask.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbGeneralTask.Location = New System.Drawing.Point(177, 33)
        Me.cmbGeneralTask.Name = "cmbGeneralTask"
        Me.cmbGeneralTask.Size = New System.Drawing.Size(370, 21)
        Me.cmbGeneralTask.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbGeneralTask.TabIndex = 13
        '
        'BlueBorder
        '
        Me.BlueBorder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.BlueBorder.Appearance = Appearance4
        Me.BlueBorder.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BlueBorder.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueBorder.Location = New System.Drawing.Point(13, 62)
        Me.BlueBorder.Name = "BlueBorder"
        Me.BlueBorder.Size = New System.Drawing.Size(534, 24)
        Me.BlueBorder.TabIndex = 16
        Me.BlueBorder.Text = "UltraTextEditor1"
        '
        'chkOutputParentText
        '
        Me.chkOutputParentText.BackColor = System.Drawing.Color.Transparent
        Me.chkOutputParentText.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkOutputParentText.Location = New System.Drawing.Point(181, 94)
        Me.chkOutputParentText.Name = "chkOutputParentText"
        Me.chkOutputParentText.Size = New System.Drawing.Size(158, 20)
        Me.chkOutputParentText.TabIndex = 20
        Me.chkOutputParentText.Text = "Display parent message"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(13, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 21)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Task should"
        '
        'chkSpecific
        '
        Appearance5.Image = Global.ADRIFT.My.Resources.imgTaskSpecific16
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance5.TextHAlignAsString = "Center"
        Me.chkSpecific.Appearance = Appearance5
        Me.chkSpecific.BackColor = System.Drawing.Color.Transparent
        Me.chkSpecific.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkSpecific.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.chkSpecific.Checked = True
        Me.chkSpecific.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSpecific.Location = New System.Drawing.Point(163, 35)
        Me.chkSpecific.Name = "chkSpecific"
        Me.chkSpecific.Size = New System.Drawing.Size(73, 26)
        Me.chkSpecific.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkSpecific.TabIndex = 28
        Me.chkSpecific.Text = "Specific"
        Me.chkSpecific.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'chkGeneral
        '
        Appearance6.Image = Global.ADRIFT.My.Resources.imgTaskGeneral16
        Appearance6.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance6.TextHAlignAsString = "Center"
        Me.chkGeneral.Appearance = Appearance6
        Me.chkGeneral.BackColor = System.Drawing.Color.Transparent
        Me.chkGeneral.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkGeneral.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.chkGeneral.Location = New System.Drawing.Point(84, 35)
        Me.chkGeneral.Name = "chkGeneral"
        Me.chkGeneral.Size = New System.Drawing.Size(73, 26)
        Me.chkGeneral.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkGeneral.TabIndex = 27
        Me.chkGeneral.Text = "General"
        Me.chkGeneral.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'chkSystem
        '
        Appearance7.Image = Global.ADRIFT.My.Resources.imgTaskSystem16
        Appearance7.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance7.TextHAlignAsString = "Center"
        Me.chkSystem.Appearance = Appearance7
        Me.chkSystem.BackColor = System.Drawing.Color.Transparent
        Me.chkSystem.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkSystem.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.chkSystem.Location = New System.Drawing.Point(242, 35)
        Me.chkSystem.Name = "chkSystem"
        Me.chkSystem.Size = New System.Drawing.Size(73, 26)
        Me.chkSystem.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkSystem.TabIndex = 26
        Me.chkSystem.Text = "System"
        Me.chkSystem.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraLabel2
        '
        Me.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel2.Location = New System.Drawing.Point(9, 41)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(72, 16)
        Me.UltraLabel2.TabIndex = 23
        Me.UltraLabel2.Text = "Task Type:"
        '
        'btnParent
        '
        Me.btnParent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance8.Image = Global.ADRIFT.My.Resources.imgParent
        Me.btnParent.Appearance = Appearance8
        Me.btnParent.Enabled = False
        Me.btnParent.Location = New System.Drawing.Point(501, 6)
        Me.btnParent.Name = "btnParent"
        Me.btnParent.Size = New System.Drawing.Size(25, 25)
        Me.btnParent.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me.btnParent, "Edit Parent task")
        '
        'btnChildren
        '
        Me.btnChildren.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance9.Image = Global.ADRIFT.My.Resources.imgChildren
        Me.btnChildren.Appearance = Appearance9
        Me.UTMPopup.SetContextMenuUltra(Me.btnChildren, "ctxmPopup")
        Me.btnChildren.Enabled = False
        Me.btnChildren.Location = New System.Drawing.Point(533, 6)
        Me.btnChildren.Name = "btnChildren"
        Me.btnChildren.Size = New System.Drawing.Size(25, 25)
        Me.btnChildren.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.btnChildren, "Edit Child task")
        '
        'lblComplete
        '
        Me.lblComplete.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblComplete.Location = New System.Drawing.Point(7, 201)
        Me.lblComplete.Name = "lblComplete"
        Me.lblComplete.Size = New System.Drawing.Size(192, 16)
        Me.lblComplete.TabIndex = 14
        Me.lblComplete.Text = "Message to display on completion:"
        '
        'txtCompletion
        '
        Me.txtCompletion.AllowAlternateDescriptions = True
        Me.txtCompletion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCompletion.BackColor = System.Drawing.Color.Transparent
        Me.txtCompletion.FirstTabHasRestrictions = False
        Me.txtCompletion.Location = New System.Drawing.Point(8, 217)
        Me.txtCompletion.Name = "txtCompletion"
        Me.txtCompletion.sCommand = Nothing
        Me.txtCompletion.Size = New System.Drawing.Size(557, 205)
        Me.txtCompletion.TabIndex = 13
        '
        'lblName
        '
        Me.lblName.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblName.Location = New System.Drawing.Point(8, 12)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(72, 16)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Task Name:"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(84, 8)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(409, 21)
        Me.txtName.TabIndex = 1
        Me.txtName.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.RestrictDetails1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(569, 432)
        '
        'RestrictDetails1
        '
        Me.RestrictDetails1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictDetails1.BackColor = System.Drawing.Color.Transparent
        Me.RestrictDetails1.Location = New System.Drawing.Point(24, 8)
        Me.RestrictDetails1.Name = "RestrictDetails1"
        Me.RestrictDetails1.Size = New System.Drawing.Size(541, 416)
        Me.RestrictDetails1.TabIndex = 0
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.Actions1)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(569, 432)
        '
        'Actions1
        '
        Me.Actions1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Actions1.BackColor = System.Drawing.Color.Transparent
        Me.Actions1.Location = New System.Drawing.Point(24, 8)
        Me.Actions1.Name = "Actions1"
        Me.Actions1.Size = New System.Drawing.Size(541, 416)
        Me.Actions1.TabIndex = 0
        '
        'UltraTabPageControl8
        '
        Me.UltraTabPageControl8.Controls.Add(Me.Label2)
        Me.UltraTabPageControl8.Enabled = False
        Me.UltraTabPageControl8.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl8.Name = "UltraTabPageControl8"
        Me.UltraTabPageControl8.Size = New System.Drawing.Size(569, 432)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(48, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Show any hints applicable for this task"
        '
        'UltraTabPageControl7
        '
        Me.UltraTabPageControl7.Controls.Add(Me.chkAggregate)
        Me.UltraTabPageControl7.Controls.Add(Me.txtFailOverride)
        Me.UltraTabPageControl7.Controls.Add(Me.chkContinue)
        Me.UltraTabPageControl7.Controls.Add(Me.lblAutofillDisabled)
        Me.UltraTabPageControl7.Controls.Add(Me.chkPreventOverriding)
        Me.UltraTabPageControl7.Controls.Add(Me.chkReplaceKey)
        Me.UltraTabPageControl7.Controls.Add(Me.cmbBeforeAfter)
        Me.UltraTabPageControl7.Controls.Add(Me.Label10)
        Me.UltraTabPageControl7.Controls.Add(Me.Label9)
        Me.UltraTabPageControl7.Controls.Add(Me.Label8)
        Me.UltraTabPageControl7.Controls.Add(Me.udAutoFillPriority)
        Me.UltraTabPageControl7.Controls.Add(Me.lblAutoFillPriority)
        Me.UltraTabPageControl7.Controls.Add(Me.chkLowPriority)
        Me.UltraTabPageControl7.Controls.Add(Me.udTaskPriority)
        Me.UltraTabPageControl7.Controls.Add(Me.Label1)
        Me.UltraTabPageControl7.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl7.Name = "UltraTabPageControl7"
        Me.UltraTabPageControl7.Size = New System.Drawing.Size(569, 432)
        '
        'txtFailOverride
        '
        Me.txtFailOverride.AllowAlternateDescriptions = True
        Me.txtFailOverride.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFailOverride.BackColor = System.Drawing.Color.Transparent
        Me.txtFailOverride.FirstTabHasRestrictions = False
        Me.txtFailOverride.Location = New System.Drawing.Point(16, 259)
        Me.txtFailOverride.Name = "txtFailOverride"
        Me.txtFailOverride.sCommand = Nothing
        Me.txtFailOverride.Size = New System.Drawing.Size(540, 163)
        Me.txtFailOverride.TabIndex = 12
        '
        'chkContinue
        '
        Me.chkContinue.BackColor = System.Drawing.Color.Transparent
        Me.chkContinue.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkContinue.Location = New System.Drawing.Point(16, 136)
        Me.chkContinue.Name = "chkContinue"
        Me.chkContinue.Size = New System.Drawing.Size(381, 20)
        Me.chkContinue.TabIndex = 21
        Me.chkContinue.Text = "Continue executing matching lower priority tasks (multiple matching)"
        '
        'lblAutofillDisabled
        '
        Me.lblAutofillDisabled.BackColor = System.Drawing.Color.Transparent
        Me.lblAutofillDisabled.Location = New System.Drawing.Point(400, 22)
        Me.lblAutofillDisabled.Name = "lblAutofillDisabled"
        Me.lblAutofillDisabled.Size = New System.Drawing.Size(94, 21)
        Me.lblAutofillDisabled.TabIndex = 20
        Me.lblAutofillDisabled.Text = "(Auto-fill disabled)"
        Me.lblAutofillDisabled.Visible = False
        '
        'chkPreventOverriding
        '
        Me.chkPreventOverriding.BackColor = System.Drawing.Color.Transparent
        Me.chkPreventOverriding.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkPreventOverriding.Location = New System.Drawing.Point(16, 54)
        Me.chkPreventOverriding.Name = "chkPreventOverriding"
        Me.chkPreventOverriding.Size = New System.Drawing.Size(244, 25)
        Me.chkPreventOverriding.TabIndex = 19
        Me.chkPreventOverriding.Text = "Prevent this task from being inherited"
        '
        'chkReplaceKey
        '
        Me.chkReplaceKey.BackColor = System.Drawing.Color.Transparent
        Me.chkReplaceKey.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkReplaceKey.Location = New System.Drawing.Point(16, 84)
        Me.chkReplaceKey.Name = "chkReplaceKey"
        Me.chkReplaceKey.Size = New System.Drawing.Size(390, 20)
        Me.chkReplaceKey.TabIndex = 18
        Me.chkReplaceKey.Text = "On load, if another task exists with the same key, this should replace it"
        '
        'cmbBeforeAfter
        '
        Appearance10.TextHAlignAsString = "Left"
        Me.cmbBeforeAfter.Appearance = Appearance10
        Me.cmbBeforeAfter.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem7.DataValue = "Before"
        ValueListItem7.DisplayText = "before"
        ValueListItem8.DataValue = "After"
        ValueListItem8.DisplayText = "after"
        Me.cmbBeforeAfter.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem7, ValueListItem8})
        Me.cmbBeforeAfter.Location = New System.Drawing.Point(162, 200)
        Me.cmbBeforeAfter.Name = "cmbBeforeAfter"
        Me.cmbBeforeAfter.Size = New System.Drawing.Size(96, 21)
        Me.cmbBeforeAfter.TabIndex = 13
        Me.cmbBeforeAfter.Text = "before"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(270, 204)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 21)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "executing actions"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(15, 204)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(149, 21)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Display completion message"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(15, 243)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(382, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "If task fails and input references 'all', display this instead of restriction com" & _
    "ments:"
        '
        'udAutoFillPriority
        '
        Me.HelpProvider.SetHelpString(Me.udAutoFillPriority, "If ")
        Me.udAutoFillPriority.Location = New System.Drawing.Point(335, 19)
        Me.udAutoFillPriority.Name = "udAutoFillPriority"
        Me.HelpProvider.SetShowHelp(Me.udAutoFillPriority, True)
        Me.udAutoFillPriority.Size = New System.Drawing.Size(59, 20)
        Me.udAutoFillPriority.TabIndex = 9
        '
        'lblAutoFillPriority
        '
        Me.lblAutoFillPriority.BackColor = System.Drawing.Color.Transparent
        Me.lblAutoFillPriority.Location = New System.Drawing.Point(242, 22)
        Me.lblAutoFillPriority.Name = "lblAutoFillPriority"
        Me.lblAutoFillPriority.Size = New System.Drawing.Size(88, 16)
        Me.lblAutoFillPriority.TabIndex = 8
        Me.lblAutoFillPriority.Text = "Auto-fill Priority:"
        '
        'chkLowPriority
        '
        Me.chkLowPriority.BackColor = System.Drawing.Color.Transparent
        Me.chkLowPriority.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkLowPriority.Location = New System.Drawing.Point(16, 110)
        Me.chkLowPriority.Name = "chkLowPriority"
        Me.chkLowPriority.Size = New System.Drawing.Size(529, 20)
        Me.chkLowPriority.TabIndex = 7
        Me.chkLowPriority.Text = "This task can be overridden by other task restriction failures (apart from other " & _
    "tasks with this checked)"
        '
        'udTaskPriority
        '
        Me.HelpProvider.SetHelpString(Me.udTaskPriority, "If multiple tasks match the input from the player, the one with the highest prior" & _
        "ity will execute.")
        Me.udTaskPriority.Location = New System.Drawing.Point(93, 18)
        Me.udTaskPriority.Name = "udTaskPriority"
        Me.HelpProvider.SetShowHelp(Me.udTaskPriority, True)
        Me.udTaskPriority.Size = New System.Drawing.Size(59, 20)
        Me.udTaskPriority.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(13, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Task Priority:"
        '
        'chkRepeatable
        '
        Me.chkRepeatable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkRepeatable.AutoSize = True
        Me.chkRepeatable.BackColor = System.Drawing.Color.Transparent
        Me.chkRepeatable.Location = New System.Drawing.Point(13, 18)
        Me.chkRepeatable.Name = "chkRepeatable"
        Me.chkRepeatable.Size = New System.Drawing.Size(118, 17)
        Me.chkRepeatable.TabIndex = 34
        Me.chkRepeatable.Text = "Task is Repeatable"
        Me.chkRepeatable.UseVisualStyleBackColor = False
        '
        'UltraCheckEditor1
        '
        Me.UltraCheckEditor1.Location = New System.Drawing.Point(153, 3)
        Me.UltraCheckEditor1.Name = "UltraCheckEditor1"
        Me.UltraCheckEditor1.Size = New System.Drawing.Size(100, 44)
        Me.UltraCheckEditor1.TabIndex = 39
        Me.UltraCheckEditor1.Text = "UltraCheckEditor1"
        '
        'tabsMain
        '
        Me.tabsMain.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabsMain.Controls.Add(Me.UltraTabPageControl1)
        Me.tabsMain.Controls.Add(Me.UltraTabPageControl2)
        Me.tabsMain.Controls.Add(Me.UltraTabPageControl3)
        Me.tabsMain.Controls.Add(Me.UltraTabPageControl7)
        Me.tabsMain.Controls.Add(Me.UltraTabPageControl8)
        Me.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsMain.Location = New System.Drawing.Point(0, 0)
        Me.tabsMain.Name = "tabsMain"
        Me.tabsMain.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabsMain.Size = New System.Drawing.Size(573, 458)
        Me.tabsMain.TabIndex = 0
        UltraTab6.Key = "Description"
        UltraTab6.TabPage = Me.UltraTabPageControl1
        UltraTab6.Text = "Description"
        UltraTab7.Key = "Restrictions"
        UltraTab7.TabPage = Me.UltraTabPageControl2
        UltraTab7.Text = "Restrictions"
        UltraTab8.Key = "Actions"
        UltraTab8.TabPage = Me.UltraTabPageControl3
        UltraTab8.Text = "Actions"
        UltraTab9.Key = "Hints"
        UltraTab9.TabPage = Me.UltraTabPageControl8
        UltraTab9.Text = "Hints"
        UltraTab10.Key = "Advanced"
        UltraTab10.TabPage = Me.UltraTabPageControl7
        UltraTab10.Text = "Advanced"
        Me.tabsMain.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab6, UltraTab7, UltraTab8, UltraTab9, UltraTab10})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(569, 432)
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Controls.Add(Me.chkRepeatable)
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 458)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        UltraStatusPanel1.Control = Me.chkRepeatable
        UltraStatusPanel1.Padding = New System.Drawing.Size(12, 12)
        UltraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer
        UltraStatusPanel1.Width = 160
        Me.UltraStatusBar1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1})
        Me.UltraStatusBar1.Size = New System.Drawing.Size(573, 48)
        Me.UltraStatusBar1.TabIndex = 8
        Me.UltraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(469, 468)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(88, 32)
        Me.btnApply.TabIndex = 11
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(373, 468)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(277, 468)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "OK"
        '
        '_frmTask_Toolbars_Dock_Area_Left
        '
        Me._frmTask_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmTask_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control
        Me._frmTask_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._frmTask_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmTask_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 0)
        Me._frmTask_Toolbars_Dock_Area_Left.Name = "_frmTask_Toolbars_Dock_Area_Left"
        Me._frmTask_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 458)
        Me._frmTask_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UTMPopup
        '
        'UTMPopup
        '
        Me.UTMPopup.DesignerFlags = 1
        Me.UTMPopup.DockWithinContainer = Me
        Me.UTMPopup.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
        Me.UTMPopup.ShowFullMenusDelay = 500
        PopupMenuTool1.SharedPropsInternal.Caption = "ctxmPopup"
        Me.UTMPopup.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool1})
        '
        '_frmTask_Toolbars_Dock_Area_Right
        '
        Me._frmTask_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmTask_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control
        Me._frmTask_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._frmTask_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmTask_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(573, 0)
        Me._frmTask_Toolbars_Dock_Area_Right.Name = "_frmTask_Toolbars_Dock_Area_Right"
        Me._frmTask_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 458)
        Me._frmTask_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UTMPopup
        '
        '_frmTask_Toolbars_Dock_Area_Top
        '
        Me._frmTask_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmTask_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control
        Me._frmTask_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._frmTask_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmTask_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._frmTask_Toolbars_Dock_Area_Top.Name = "_frmTask_Toolbars_Dock_Area_Top"
        Me._frmTask_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(573, 0)
        Me._frmTask_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UTMPopup
        '
        '_frmTask_Toolbars_Dock_Area_Bottom
        '
        Me._frmTask_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmTask_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmTask_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmTask_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmTask_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 458)
        Me._frmTask_Toolbars_Dock_Area_Bottom.Name = "_frmTask_Toolbars_Dock_Area_Bottom"
        Me._frmTask_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(573, 0)
        Me._frmTask_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UTMPopup
        '
        'HelpProvider
        '
        Me.HelpProvider.HelpNamespace = "ADRIFT 5 Help.chm"
        '
        'chkAggregate
        '
        Me.chkAggregate.BackColor = System.Drawing.Color.Transparent
        Me.chkAggregate.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkAggregate.Location = New System.Drawing.Point(16, 162)
        Me.chkAggregate.Name = "chkAggregate"
        Me.chkAggregate.Size = New System.Drawing.Size(198, 20)
        Me.chkAggregate.TabIndex = 22
        Me.chkAggregate.Text = "Aggregate output, where possible"
        '
        'frmTask
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(573, 506)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tabsMain)
        Me.Controls.Add(Me.UltraCheckEditor1)
        Me.Controls.Add(Me._frmTask_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._frmTask_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._frmTask_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.Controls.Add(Me._frmTask_Toolbars_Dock_Area_Top)
        Me.HelpButton = True
        Me.HelpProvider.SetHelpKeyword(Me, "10")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TopicId)
        Me.HelpProvider.SetHelpString(Me, "")
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(568, 506)
        Me.Name = "frmTask"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Task - "
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.grpGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGeneral.ResumeLayout(False)
        Me.grpGeneral.PerformLayout()
        CType(Me.txtCommands, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSystem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSystem.ResumeLayout(False)
        Me.grpSystem.PerformLayout()
        CType(Me.cmbSystemTriggerLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSystemTrigger, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSpecific, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSpecific.ResumeLayout(False)
        Me.grpSpecific.PerformLayout()
        CType(Me.cmbSpecificOverrideType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExecuteParentActions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbGeneralTask, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BlueBorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOutputParentText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSpecific, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSystem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl8.ResumeLayout(False)
        Me.UltraTabPageControl7.ResumeLayout(False)
        Me.UltraTabPageControl7.PerformLayout()
        CType(Me.chkContinue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPreventOverriding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkReplaceKey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbBeforeAfter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udAutoFillPriority, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLowPriority, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udTaskPriority, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraCheckEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabsMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsMain.ResumeLayout(False)
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraStatusBar1.ResumeLayout(False)
        Me.UltraStatusBar1.PerformLayout()
        CType(Me.UTMPopup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAggregate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private cTask As clsTask
    Private bChanged As Boolean
    Private bLoaded As Boolean = False
    Private iInScore As Integer = 0


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



    Private Sub StuffChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged, txtCompletion.Changed, txtCommands.TextChanged, txtFailOverride.Changed, udTaskPriority.ValueChanged
        Changed = True
    End Sub
    'Private Sub tabsTaskType_SelectedTabChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs)
    '    Changed = True
    'End Sub

    Private Function NextPriority(Optional ByVal bIncludeLibrary As Boolean = False) As Integer

        Try
            Dim iPriority As Integer = 0

            For Each tas As clsTask In Adventure.htblTasks.Values
                If (bIncludeLibrary OrElse Not tas.IsLibrary) AndAlso tas.Priority > iPriority Then iPriority = tas.Priority
            Next

            Return iPriority + 1

        Catch ex As Exception
            ErrMsg("Error obtaining next priority", ex)
        End Try

    End Function


    Private Function ScoreAdjustment(ByVal actions As ActionArrayList) As Integer

        Dim iAdjustment As Integer = 0

        For Each action As clsAction In actions
            Select Case action.eItem
                Case clsAction.ItemEnum.SetVariable, clsAction.ItemEnum.IncreaseVariable
                    If action.eVariables = clsAction.VariablesEnum.Assignment Then
                        If action.sKey1 = "Score" Then
                            Dim iVal As Integer = EvaluateExpression(action.StringValue, True)
                            iAdjustment += iVal
                        End If
                    End If
            End Select
        Next

        Return iAdjustment

    End Function


    Private Sub LoadForm(ByRef cTask As clsTask, ByVal bShow As Boolean)

        Try
            Me.cTask = cTask

            With cTask
                Text = "Task - " & .Description
                tabsMain.Tabs("Advanced").Visible = Not fGenerator.SimpleMode
                If SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0")) Then Text &= "  [" & .Key & "]"
                If .Key = "" Then Text = "New Task"

                If .Priority = 0 Then .Priority = NextPriority()
                udTaskPriority.Minimum = 1
                udTaskPriority.Maximum = NextPriority(True)
                udTaskPriority.Value = .Priority

                udAutoFillPriority.Value = .AutoFillPriority

                txtName.Text = .Description
                txtCompletion.Description = .CompletionMessage.Copy
                chkRepeatable.Checked = .Repeatable
                chkContinue.Checked = .ContinueToExecuteLowerPriority

                'lvwCommands.Items.Clear()
                For Each sCommand As String In .arlCommands
                    '    lvwCommands.Items.Add(sCommand)
                    If txtCommands.Text <> "" Then txtCommands.Text &= vbCrLf
                    txtCommands.Text &= sCommand
                Next

                RestrictDetails1.LoadRestrictions(.arlRestrictions.Copy)
                Actions1.LoadActions(.arlActions.Copy)
                txtFailOverride.Description = .FailOverride.Copy
                If .Key = "" Then
                    .eDisplayCompletion = CType(SafeInt(GetSetting("ADRIFT", "Generator", "DefaultActions", "1")), clsTask.BeforeAfterEnum)
                End If
                SetCombo(Me.cmbBeforeAfter, WriteEnum(.eDisplayCompletion))

                cmbGeneralTask.Items.Clear()
                For Each Task As clsTask In Adventure.Tasks(clsAdventure.TasksListEnum.GeneralAndOverrideableSpecificTasks).Values
                    If (Not Task.PreventOverriding OrElse Task.Key = cTask.GeneralKey) AndAlso Task IsNot cTask Then cmbGeneralTask.Items.Add(Task.Key, Task.Description)
                Next

                For Each l As clsLocation In Adventure.htblLocations.Values
                    cmbSystemTriggerLocation.Items.Add(l.Key, l.ShortDescription.ToString)
                Next

                'SetOptSet(optTaskType, CInt(.TaskType))
                Select Case .TaskType
                    Case clsTask.TaskTypeEnum.General
                        chkGeneral.Checked = True
                        If Text = "New Task" Then chkRepeatable.Checked = True
                    Case clsTask.TaskTypeEnum.Specific
                        chkSpecific.Checked = True
                        SetCombo(cmbGeneralTask, .GeneralKey)

                        Select Case .SpecificOverrideType
                            Case clsTask.SpecificOverrideTypeEnum.AfterActionsOnly
                                SetCombo(cmbSpecificOverrideType, "run after")
                                chkOutputParentText.Checked = False
                                chkExecuteParentActions.Checked = True
                            Case clsTask.SpecificOverrideTypeEnum.AfterTextAndActions
                                SetCombo(cmbSpecificOverrideType, "run after")
                                chkOutputParentText.Checked = True
                                chkExecuteParentActions.Checked = True
                            Case clsTask.SpecificOverrideTypeEnum.AfterTextOnly
                                SetCombo(cmbSpecificOverrideType, "run after")
                                chkOutputParentText.Checked = True
                                chkExecuteParentActions.Checked = False
                            Case clsTask.SpecificOverrideTypeEnum.BeforeActionsOnly
                                SetCombo(cmbSpecificOverrideType, "run before")
                                chkOutputParentText.Checked = False
                                chkExecuteParentActions.Checked = True
                            Case clsTask.SpecificOverrideTypeEnum.BeforeTextAndActions
                                SetCombo(cmbSpecificOverrideType, "run before")
                                chkOutputParentText.Checked = True
                                chkExecuteParentActions.Checked = True
                            Case clsTask.SpecificOverrideTypeEnum.BeforeTextOnly
                                SetCombo(cmbSpecificOverrideType, "run before")
                                chkOutputParentText.Checked = True
                                chkExecuteParentActions.Checked = False
                            Case clsTask.SpecificOverrideTypeEnum.Override
                                SetCombo(cmbSpecificOverrideType, "override")
                                chkOutputParentText.Checked = False
                                chkExecuteParentActions.Checked = False
                        End Select

                    Case clsTask.TaskTypeEnum.System
                        chkSystem.Checked = True
                        If .RunImmediately Then
                            SetCombo(cmbSystemTrigger, "Immediately")
                        Else
                            If .LocationTrigger = "" Then
                                SetCombo(cmbSystemTrigger, "Only if called by event/task")
                            Else
                                SetCombo(cmbSystemTriggerLocation, .LocationTrigger)
                                SetCombo(cmbSystemTrigger, "Player enters location")
                                cmbSystemTriggerLocation.Visible = True
                            End If
                        End If
                End Select

                'DoCommandButtons()

                If Not .Parent Is Nothing Then btnParent.Enabled = True
                If .Children.Count > 0 Then btnChildren.Enabled = True

                chkLowPriority.Checked = .LowPriority
                chkReplaceKey.Checked = .ReplaceDuplicateKey
                chkPreventOverriding.Checked = .PreventOverriding
                chkReplaceKey.Enabled = .IsLibrary
                chkAggregate.Checked = .AggregateOutput

                iInScore = ScoreAdjustment(.arlActions)

            End With

            UpdateOverrideableCheckbox()

            RecalcRefs()

            If bShow Then Me.Show()
            Changed = False
            bLoaded = True

        Catch ex As Exception
            ErrMsg("Error loading Task form", ex)
        End Try

    End Sub


    Private Sub UpdateOverrideableCheckbox()

        Select Case True
            Case chkGeneral.Checked
                chkPreventOverriding.Enabled = True
            Case chkSpecific.Checked
                If cTask Is Nothing Then Exit Sub
                Dim specifics As clsTask.Specific() = SpecificTask1.GetSpecifics
                If specifics IsNot Nothing Then
                    For Each s As clsTask.Specific In specifics
                        If s.Keys IsNot Nothing AndAlso s.Keys.Count = 1 AndAlso s.Keys(0) = "" Then
                            chkPreventOverriding.Enabled = True
                            Exit Sub
                        End If
                    Next
                End If
                chkPreventOverriding.Enabled = False
            Case chkSystem.Checked
                chkPreventOverriding.Enabled = False
        End Select

    End Sub


    Private Function ValidateTask() As Boolean

        If chkSpecific.Checked Then ' CType(optTaskType.CheckedItem.DataValue, clsTask.TaskTypeEnum) = clsTask.TaskTypeEnum.Specific Then ' tabsTaskType.SelectedTab.Text = "Specific" Then
            If cmbGeneralTask.SelectedIndex = -1 Then
                ErrMsg("You must select a general task to base this specific task upon.")
                tabsMain.Tabs("Description").Selected = True
                cmbGeneralTask.Focus()
                Return False
            End If
            If cmbSpecificOverrideType.SelectedIndex = 0 AndAlso Not chkExecuteParentActions.Checked AndAlso Not chkOutputParentText.Checked Then
                If MessageBox.Show("Running before the parent task but not displaying the parent text or executing the parent actions is the same as overriding the parent task.  Ok to do change this to Override?", "Run before task", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Cancel Then Return False
                cmbSpecificOverrideType.SelectedIndex = 1
            End If
        End If

        If Not RestrictDetails1.arlRestrictions.IsBracketsValid Then
            ErrMsg("Invalid Bracket Sequence.")
            tabsMain.Tabs("Restrictions").Selected = True
            Return False
        End If

        If Commands.Count > 0 AndAlso Me.Text = "New Task" AndAlso chkGeneral.Checked AndAlso RestrictDetails1.arlRestrictions.Count = 0 Then
            For Each Ref As ReferencesType In New ReferencesType() {ReferencesType.Location, ReferencesType.Object, ReferencesType.Character, ReferencesType.Direction, ReferencesType.Number, ReferencesType.Text}
                For Each sReference As String In GetReferences(Ref, Commands(0))
                    Select Case sReference
                        Case "ReferencedObject", "ReferencedObject1", "ReferencedObject2", "ReferencedObject3", "ReferencedObject4", "ReferencedObject5", "ReferencedObjects", "ReferencedCharacter", "ReferencedCharacter1", "ReferencedCharacter2", "ReferencedCharacter3", "ReferencedCharacter4", "ReferencedCharacter5", "ReferencedCharacters"
                            If MessageBox.Show("You appear to have references, but no restrictions.  Would you like to automatically add these now?", "Auto-add restrictions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                AutoAddRestrictions()
                                GoTo EndCheckRefs
                            End If
                    End Select
                Next
            Next
        End If
EndCheckRefs:

        Return True

    End Function


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not ValidateTask() Then Exit Sub
        If ApplyTask() Then CloseTask(Me)
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If Not ValidateTask() Then Exit Sub
        If ApplyTask() Then Changed = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then
                If Not ApplyTask() Then Exit Sub
            End If
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        CloseTask(Me)
    End Sub


    Private Function ApplyTask() As Boolean

        If chkGeneral.Checked AndAlso Commands.Count = 0 Then
            ErrMsg("You must have at least one command for a General Task!")
            tabsMain.SelectedTab = tabsMain.Tabs("Description")
            Return False
        End If

        If Not CheckCommands() Then Return False

        With cTask
            .Description = txtName.Text
            .CompletionMessage = txtCompletion.Description.Copy ' Don't copy the object, else we'll get any future cancelled changes
            .Repeatable = chkRepeatable.Checked
            .ContinueToExecuteLowerPriority = chkContinue.Checked
            .LastUpdated = Now
            .IsLibrary = False

            Select Case True ' CType(optTaskType.CheckedItem.DataValue, clsTask.TaskTypeEnum) ' Me.tabsTaskType.SelectedTab.Text
                Case chkGeneral.Checked ' clsTask.TaskTypeEnum.General ' "General"
                    .TaskType = clsTask.TaskTypeEnum.General
                    .arlCommands.Clear()
                    .arlCommands = Commands()
                    'For Each lvi As ListViewItem In Me.lvwCommands.Items
                    '    .arlCommands.Add(lvi.Text)
                    'Next
                Case chkSpecific.Checked ' clsTask.TaskTypeEnum.Specific ' "Specific"
                    .TaskType = clsTask.TaskTypeEnum.Specific
                    If cmbGeneralTask.SelectedIndex > -1 Then
                        .GeneralKey = CStr(cmbGeneralTask.SelectedItem.DataValue)
                    Else
                        .GeneralKey = ""
                    End If
                    If .Description = "" Then .Description = Me.SpecificTask1.txtSpecific.Text ' Me.txtSpecific.Text
                    '.ExecuteParentActions = chkExecuteParentActions.Checked
                    Select Case cmbSpecificOverrideType.SelectedItem.DataValue.ToString
                        Case "run before"
                            If chkExecuteParentActions.Checked AndAlso chkOutputParentText.Checked Then
                                .SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextAndActions
                            ElseIf chkExecuteParentActions.Checked Then
                                .SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeActionsOnly
                            ElseIf chkOutputParentText.Checked Then
                                .SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextOnly
                            Else
                                .SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.Override
                            End If
                        Case "run after"
                            If chkExecuteParentActions.Checked AndAlso chkOutputParentText.Checked Then
                                .SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.AfterTextAndActions
                            ElseIf chkExecuteParentActions.Checked Then
                                .SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.AfterActionsOnly
                            ElseIf chkOutputParentText.Checked Then
                                .SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.AfterTextOnly
                            Else
                                .SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.Override
                            End If
                        Case "override"
                            .SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.Override
                    End Select
                Case chkSystem.Checked ' clsTask.TaskTypeEnum.System ' "System"
                    .TaskType = clsTask.TaskTypeEnum.System
                    Select Case cmbSystemTrigger.SelectedItem.ToString
                        Case "Only if called by event/task"
                            .LocationTrigger = ""
                            .RunImmediately = False
                        Case "Immediately"
                            .RunImmediately = True
                            .LocationTrigger = ""
                        Case "Player enters location"
                            If cmbSystemTriggerLocation.SelectedItem IsNot Nothing Then .LocationTrigger = cmbSystemTriggerLocation.SelectedItem.DataValue.ToString
                            .RunImmediately = False
                    End Select
            End Select

            .arlRestrictions = Me.RestrictDetails1.arlRestrictions.Copy
            .arlActions = Me.Actions1.arlActions.Copy
            .FailOverride = Me.txtFailOverride.Description.Copy
            .eDisplayCompletion = EnumParseBeforeAfter(cmbBeforeAfter.SelectedItem.DataValue.ToString)

            ' if a task exists with this priority, move all the rest up or down
            Dim iNewPriority As Integer = CInt(udTaskPriority.Value)
            If iNewPriority <> .Priority Then
                ' Reshuffle all the other priorities to accommodate this one
                For Each tas As clsTask In Adventure.htblTasks.Values
                    If tas.Priority > .Priority AndAlso tas.Priority <= iNewPriority Then tas.Priority -= 1
                    If tas.Priority >= iNewPriority AndAlso tas.Priority < .Priority Then tas.Priority += 1
                Next
                .Priority = iNewPriority
            End If

            .AutoFillPriority = CInt(udAutoFillPriority.Value)

            .LowPriority = chkLowPriority.Checked
            .ReplaceDuplicateKey = chkReplaceKey.Checked
            .PreventOverriding = chkPreventOverriding.Checked
            .AggregateOutput = chkAggregate.Checked

            .Specifics = SpecificTask1.GetSpecifics

            If .Key = "" Then
                .Key = .GetNewKey ' Adventure.GetNewKey("Task")
                Adventure.htblTasks.Add(cTask, .Key)
            End If

            Dim iOutScore As Integer = ScoreAdjustment(.arlActions)
            Adventure.MaxScore += iOutScore - iInScore
            iInScore = iOutScore

            UpdateListItem(.Key, .Description)
        End With

        Adventure.Changed = True
        Return True

    End Function



    Private Sub cmbGeneralTask_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGeneralTask.ValueChanged

        If cmbGeneralTask.SelectedItem IsNot Nothing Then
            If Me.Visible Then ReDim cTask.Specifics(-1)
            SpecificTask1.LoadSpecific(CStr(cmbGeneralTask.SelectedItem.DataValue), CType(cTask.Clone, clsTask))
            RecalcRefs()
            UpdateOverrideableCheckbox()
            Changed = True
        End If

    End Sub



    Private Sub SelectListItem(ByVal lvw As ListView, ByVal sKey As String)

        For Each lvi As ListViewItem In lvw.Items
            If lvi.SubItems(1).Text = sKey Then
                lvi.Selected = True
                Exit Sub
            End If
        Next

    End Sub


    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

    '    Const WM_PAINT As Integer = &HF  ' 15

    '    Select Case m.Msg
    '        Case WM_PAINT
    '            If lvwCommands.View = View.Details AndAlso lvwCommands.Columns.Count > 0 Then
    '                lvwCommands.Columns(lvwCommands.Columns.Count - 1).Width = -1
    '                lvwCommands.Columns(lvwCommands.Columns.Count - 1).Width -= 5
    '            End If
    '    End Select

    '    MyBase.WndProc(m)

    'End Sub


    'Private Sub cmbAddCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    With lvwCommands
    '        .Items.Add("")
    '        ResizeStuff()
    '        'If .Items.Count > 4 Then lvwCommands.Columns(0).Width = lvwCommands.Width - 40
    '        .Items(.Items.Count - 1).Selected = True
    '        .Items(.Items.Count - 1).BeginEdit()
    '    End With

    'End Sub

    'Private Sub btnEditCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If lvwCommands.SelectedItems.Count > 0 Then lvwCommands.SelectedItems(0).BeginEdit()
    'End Sub


    'Private Sub DoCommandButtons()

    '    If lvwCommands.SelectedItems.Count = 0 Then
    '        Me.btnEditCommand.Enabled = False
    '        Me.btnDeleteCommand.Enabled = False
    '    Else
    '        Me.btnEditCommand.Enabled = True
    '        Me.btnDeleteCommand.Enabled = True
    '    End If

    'End Sub

    'Private Sub btnDeleteCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    lvwCommands.SelectedItems(0).Remove()
    '    ResizeStuff()
    '    DoCommandButtons()

    'End Sub

    'Private Sub lvwCommands_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    DoCommandButtons()
    'End Sub

    Private Sub btnParent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParent.Click
        If Adventure.htblTasks.ContainsKey(cTask.Parent) Then
            Dim fTask As New frmTask(Adventure.htblTasks(cTask.Parent), True)
        Else
            ErrMsg("Parent task not found")
            btnParent.Enabled = False
        End If
    End Sub


    Private Function OccurencesOfIn(ByVal sText As String, ByVal sSearch As String) As Integer

        OccurencesOfIn = 0
        If sText Is Nothing Then Exit Function

        Dim iOffset As Integer = 0

        While sText.IndexOf(sSearch, iOffset) > -1
            iOffset = sText.IndexOf(sSearch, iOffset) + 1
            OccurencesOfIn += 1
        End While

    End Function


    Private Function Commands() As StringArrayList

        Dim arlCommands As New StringArrayList

        If txtCommands.Text <> "" Then
            For Each sLine As String In txtCommands.Text.Split(Chr(10))
                If sLine.EndsWith(Chr(13)) Then sLine = sLeft(sLine, sLine.Length - 1)
                If sLine <> "" Then arlCommands.Add(sLine)
            Next
        End If

        Return arlCommands

    End Function


    Private bChecking As Boolean = False
    ' Returns True if ok
    Private Function CheckCommands() As Boolean

        If bChecking Then Return True
        bChecking = True

        Dim iRow As Integer = 0
        Dim bResult As Boolean = True
        Dim sTokens() As String
        Dim sRefs As New StringArrayList

        For Each sText As String In Commands()
            iRow += 1

            If CharacterCount(sText, "{"c) <> CharacterCount(sText, "}"c) Then
                CommandError("You must have the same number of closing curly brackets as the number of opening ones", iRow, sText)
                bResult = False
                Exit For
            End If

            If CharacterCount(sText, "["c) <> CharacterCount(sText, "]"c) Then
                CommandError("You must have the same number of closing square brackets as the number of opening ones", iRow, sText)
                bResult = False
                Exit For
            End If

            If iRow = 1 Then
                ' Make sure the refs we have are valid, i.e. %object% OR %object1% and %object2%
                For Each sRef As String In ReferenceNames()
                    Dim iCount As Integer = OccurencesOfIn(sText, sRef)
                    If iCount > 1 Then
                        Select Case sRef
                            Case "%object%", "%character%"
                                CommandError("You must use " & Replace(sRef, "%", "1%", 2) & ", " & Replace(sRef, "%", "2%", 2) & " etc if you have more than one reference.", iRow, sText)
                            Case Else
                                CommandError("You have a duplicate reference for " & sRef & ".", iRow, sText)
                        End Select
                        bResult = False
                    End If
                Next

                sTokens = Commands(0).Split("%"c)
                For Each sToken As String In sTokens
                    For Each sRef As String In ReferenceNames()
                        If "%" & sToken & "%" = sRef Then
                            sRefs.Add(sToken)
                        End If
                    Next
                Next

                RecalcRefs(sText)
            Else
                ' Make sure the line being modified is consistent with the other lines

                ' Now make sure our new line has all the tokens above, and no more
                sTokens = sText.Split("%"c)
                Dim sError As String = ""

                For Each sToken As String In sTokens
                    For Each sRef As String In ReferenceNames()
                        If "%" & sToken & "%" = sRef Then
                            If Not sRefs.Contains(sToken) Then
                                sError = "New line contains an additional reference, %" & sToken & "%"
                                bResult = False
                                Exit For
                            End If
                        End If
                    Next
                Next

                If sError = "" Then
                    For Each sRef As String In sRefs
                        If sInstr(sText, "%" & sRef & "%") = 0 Then
                            sError = "New line does not contain the reference %" & sRef & "%"
                            bResult = False
                            Exit For
                        End If
                    Next
                End If

                If sError <> "" Then CommandError(sError, iRow, sText)

            End If

        Next sText

        bChecking = False
        Return bResult

    End Function


    Private Sub CommandError(ByVal sError As String, ByVal iRow As Integer, ByVal sRowText As String)
        If bMouseOverCancel Then Exit Sub ' Don't show error if we're cancelling the form
        ErrMsg(sError)
        'lvwCommands.Items(iRow).Text = sRowText
        'lvwCommands.Items(iRow).SubItems(0).Text = sRowText
        'lvwCommands.Items(iRow).BeginEdit()
        Dim iSelStart As Integer
        For i As Integer = 0 To iRow - 2
            iSelStart = txtCommands.Text.IndexOf(vbCrLf, iSelStart + 1)
        Next
        If iSelStart < 0 Then iSelStart = 0
        Dim iSelEnd As Integer = txtCommands.Text.IndexOf(vbCrLf, iSelStart + 1)
        If iSelEnd < 0 Then iSelEnd = txtCommands.Text.Length
        txtCommands.SelectionStart = iSelStart
        txtCommands.SelectionLength = iSelEnd - iSelStart
        Me.Focus()
        txtCommands.Editor.Focus()
        'txtCommands.Focus()        
        'txtCommands.AlwaysInEditMode = False

    End Sub


    Private Sub RecalcRefs(Optional ByVal sCommand As String = "")

        Try
            If sCommand = "" Then
                Select Case True
                    Case chkGeneral.Checked
                        If Commands.Count > 0 Then sCommand = Commands(0)
                    Case chkSpecific.Checked
                        ' TODO - this is wrong, cos we don't want to bring in refs if they've been selected already
                        If cmbGeneralTask.SelectedIndex > -1 Then _
                        sCommand = Adventure.htblTasks(CStr(cmbGeneralTask.SelectedItem.DataValue)).MakeNice
                    Case chkSystem.Checked
                End Select

                'Select Case cTask.TaskType
                '    Case clsTask.TaskTypeEnum.General
                '        'If lvwCommands.Items.Count > 0 Then sCommand = lvwCommands.Items(0).Text
                '        If Commands.Count > 0 Then sCommand = Commands(0)
                '    Case clsTask.TaskTypeEnum.Specific
                '        ' TODO - this is wrong, cos we don't want to bring in refs if they've been selected already
                '        If cmbGeneralTask.SelectedIndex > -1 Then _
                '        sCommand = Adventure.htblTasks(CStr(cmbGeneralTask.SelectedItem.DataValue)).MakeNice
                'End Select
            End If

            Me.RestrictDetails1.sCommand = sCommand
            Me.Actions1.sCommand = sCommand
            Me.txtCompletion.sCommand = sCommand

        Catch ex As Exception
            ErrMsg("Error recalculating refs", ex)
        End Try

    End Sub


    Private Sub frmTask_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OpenForms.Remove(Me)
    End Sub

    'Private Sub tabsMain_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabsMain.SelectedTabChanged

    '    Select Case Me.tabsTaskType.SelectedTab.Text
    '        Case "General"
    '            cTask.TaskType = clsTask.TaskTypeEnum.General
    '        Case "Specific"
    '            cTask.TaskType = clsTask.TaskTypeEnum.Specific
    '        Case "System"
    '            cTask.TaskType = clsTask.TaskTypeEnum.System
    '    End Select

    'End Sub

    Private Sub frmTask_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetFormPosition(Me)

        'If iStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.VisualStudio2005 Then
        '    Me.lblTaskType1.Location = New Point(213, 46)
        '    Me.lblTaskType2.Location = New Point(228, 45)
        'Else
        '    Me.lblTaskType1.Location = New Point(171, 46)
        '    Me.lblTaskType2.Location = New Point(184, 45)
        'End If

        Dim ctxmPopup As Infragistics.Win.UltraWinToolbars.PopupMenuTool = CType(UTMPopup.Tools(0), Infragistics.Win.UltraWinToolbars.PopupMenuTool)

        For Each tas As clsTask In Adventure.Tasks(clsAdventure.TasksListEnum.SpecificTasks).Values
            If tas.Parent = cTask.Key Then
                ' Create a new tool
                Dim btnChildKey As New Infragistics.Win.UltraWinToolbars.ButtonTool(tas.Key)
                ' Add tool to the UTM's root tools collection
                Me.UTMPopup.Tools.Add(btnChildKey)
                btnChildKey.SharedProps.Caption = tas.Description
                ctxmPopup.Tools.AddTool(tas.Key)
            End If
        Next

        If ctxmPopup.Tools.Count = 0 Then btnChildren.Enabled = False
        OpenForms.Add(Me)

        If DarkInterface() Then
            chkRepeatable.ForeColor = Color.White
        End If

    End Sub

    Private Sub btnChildren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChildren.Click
        btnChildren.ContextMenuStrip.Show(btnChildren, Windows.Forms.Cursor.Position)
    End Sub

    Private Sub UTMPopup_ToolClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UTMPopup.ToolClick
        Dim fTask As New frmTask(Adventure.htblTasks(e.Tool.Key), True)
    End Sub

    'Private Sub lvwCommands_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    lvwCommands.SelectedItems(0).BeginEdit()
    'End Sub

    'Private Sub frmTask_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    ResizeStuff()
    'End Sub

    'Private Sub ResizeStuff()
    '    lvwCommands.Columns(0).Width = -2
    '    lvwCommands.Columns(0).Width -= 5
    'End Sub

    'Private Sub optTaskType_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTaskType.ValueChanged

    '    Select Case True ' CType(optTaskType.CheckedItem.DataValue, clsTask.TaskTypeEnum)
    '        Case clsTask.TaskTypeEnum.General
    '            Me.Icon = Icon.FromHandle(My.Resources.imgTaskGeneral16.GetHicon)
    '            grpGeneral.BringToFront()
    '            chkExecuteParentActions.Enabled = False
    '            chkPreventOverriding.Enabled = True
    '            txtCommands.Focus()
    '            If bLoaded AndAlso txtCommands.Text = "" Then chkRepeatable.Checked = True
    '        Case clsTask.TaskTypeEnum.Specific
    '            Me.Icon = Icon.FromHandle(My.Resources.imgTaskSpecific16.GetHicon)
    '            grpSpecific.BringToFront()
    '            chkExecuteParentActions.Enabled = (cmbGeneralTask.SelectedIndex > -1)
    '            chkPreventOverriding.Enabled = Not (cTask.Key Is Nothing OrElse Not Adventure.Tasks(clsAdventure.TasksListEnum.GeneralAndOverrideableSpecificTasks).ContainsKey(cTask.Key))
    '            If bLoaded AndAlso cmbGeneralTask.SelectedIndex = -1 Then chkRepeatable.Checked = False
    '        Case clsTask.TaskTypeEnum.System
    '            Me.Icon = Icon.FromHandle(My.Resources.imgTaskSystem16.GetHicon)
    '            grpSystem.BringToFront()
    '            chkExecuteParentActions.Enabled = False
    '            chkPreventOverriding.Enabled = False
    '            If bLoaded AndAlso txtCompletion.rtxtSource.Text = "" Then chkRepeatable.Checked = False
    '    End Select

    'End Sub

    Private Sub txtCommands_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCommands.Enter
        Me.AcceptButton = Nothing
    End Sub

    'Private Sub txtCommands_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCommands.KeyPress
    '    If e.KeyChar = Chr(10) OrElse e.KeyChar = Chr(13) Then
    '        If Not CheckCommands() Then e.Handled = True
    '    End If
    'End Sub


    Private Sub txtCommands_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCommands.KeyDown
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Return OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down Then
            If Not CheckCommands() Then e.Handled = True
        End If
    End Sub


    Private Sub txtCommands_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCommands.KeyUp
        'If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Return Then
        '    CheckCommands()
        '    e.Handled = True
        'End If
    End Sub

    Private Sub txtCommands_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCommands.Leave
        Me.AcceptButton = btnOK
        CheckCommands()
    End Sub


    Dim bMouseOverCancel As Boolean = False
    Private Sub btnCancel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseEnter
        bMouseOverCancel = True
    End Sub

    Private Sub btnCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseLeave
        bMouseOverCancel = False
    End Sub

    Private Sub frmTask_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If txtName.Text = "" Then
            txtName.Focus()
        Else
            'txtCompletion.rtxtSource.SelectionStart = txtCompletion.rtxtSource.Text.Replace(vbCrLf, vbCr).Length ' .TextLength
            txtCompletion.rtxtSource.EditInfo.PerformAction(Infragistics.Win.FormattedLinkLabel.FormattedLinkEditorAction.DocumentEnd)
            txtCompletion.rtxtSource.Focus()
        End If
    End Sub

    Private Sub RestrictDetails1_RestrictionsChanged() Handles RestrictDetails1.RestrictionsChanged
        Changed = True
    End Sub


    Private bChangingCheck As Boolean = False
    Private Sub chkGeneral_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkGeneral.CheckedChanged, chkSpecific.CheckedChanged, chkSystem.CheckedChanged

        If bChangingCheck Then Exit Sub

        If Not CType(sender, Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked Then
            CType(sender, Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = True
            Exit Sub
        End If
        bChangingCheck = True

        'CType(sender, Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = True
        For Each chk As Infragistics.Win.UltraWinEditors.UltraCheckEditor In New Infragistics.Win.UltraWinEditors.UltraCheckEditor() {chkGeneral, chkSpecific, chkSystem}
            If chk IsNot sender Then chk.Checked = Not CType(sender, Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked
        Next

        Select Case True
            Case sender Is chkGeneral
                Me.Icon = Icon.FromHandle(My.Resources.imgTaskGeneral16.GetHicon)
                grpGeneral.BringToFront()
                'chkExecuteParentActions.Enabled = False            
                txtCommands.Focus()
                If bLoaded AndAlso txtCommands.Text = "" Then chkRepeatable.Checked = True
                udAutoFillPriority.Enabled = True
                lblAutoFillPriority.Enabled = True
                HelpProvider.SetHelpKeyword(Me, "24")
                txtFailOverride.Enabled = True
                Label8.Enabled = True
            Case sender Is chkSpecific
                Me.Icon = Icon.FromHandle(My.Resources.imgTaskSpecific16.GetHicon)
                grpSpecific.BringToFront()
                'chkExecuteParentActions.Enabled = (cmbGeneralTask.SelectedIndex > -1)                
                If bLoaded AndAlso cmbGeneralTask.SelectedIndex = -1 Then
                    chkRepeatable.Checked = False
                    SetCombo(cmbSpecificOverrideType, "override")
                End If
                udAutoFillPriority.Enabled = False
                lblAutoFillPriority.Enabled = False
                HelpProvider.SetHelpNavigator(Me, HelpNavigator.TopicId)
                HelpProvider.SetHelpKeyword(Me, "25")
                txtFailOverride.Enabled = False
                Label8.Enabled = False
            Case sender Is chkSystem
                Me.Icon = Icon.FromHandle(My.Resources.imgTaskSystem16.GetHicon)
                grpSystem.BringToFront()
                'chkExecuteParentActions.Enabled = False                
                If bLoaded AndAlso txtCompletion.rtxtSource.Text = "" Then chkRepeatable.Checked = True
                udAutoFillPriority.Enabled = False
                lblAutoFillPriority.Enabled = False
                HelpProvider.SetHelpKeyword(Me, "26")
                txtFailOverride.Enabled = False
                Label8.Enabled = False
        End Select

        UpdateOverrideableCheckbox()

        bChangingCheck = False

    End Sub

    Private Sub cmbSystemTrigger_ValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbSystemTrigger.ValueChanged

        Select Case cmbSystemTrigger.SelectedItem.DataValue.ToString
            Case "Only if called by event/task", "Immediately"
                cmbSystemTriggerLocation.Visible = False
            Case "Player enters location"
                cmbSystemTriggerLocation.Visible = True
        End Select

    End Sub


    Private Sub cmbSpecificOverrideType_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbSpecificOverrideType.SelectionChanged

        Select Case cmbSpecificOverrideType.SelectedItem.DataValue.ToString
            Case "run before"
                If Not chkOutputParentText.Enabled AndAlso Not chkExecuteParentActions.Enabled Then
                    ' We've changed from override, so set checkboxes to make it equivalent
                    chkOutputParentText.Checked = True
                    chkExecuteParentActions.Checked = True
                End If
                chkOutputParentText.Enabled = True
                chkExecuteParentActions.Enabled = True
            Case "override"
                chkOutputParentText.Checked = False
                chkExecuteParentActions.Checked = False
                chkOutputParentText.Enabled = False
                chkExecuteParentActions.Enabled = False
            Case "run after"
                chkOutputParentText.Checked = True
                chkExecuteParentActions.Checked = True
                chkOutputParentText.Enabled = False
                chkExecuteParentActions.Enabled = False
        End Select

    End Sub


    Private Sub udAutoFillPriority_ValueChanged(sender As System.Object, e As System.EventArgs) Handles udAutoFillPriority.ValueChanged
        lblAutofillDisabled.Visible = udAutoFillPriority.Value = 0
    End Sub


    Private Sub tabsMain_SelectedTabChanged(sender As Object, e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabsMain.SelectedTabChanged

        If e.Tab Is tabsMain.Tabs("Restrictions") AndAlso Me.Text = "New Task" AndAlso chkGeneral.Checked AndAlso RestrictDetails1.arlRestrictions.Count = 0 Then
            AutoAddRestrictions()
        End If

    End Sub


    Private Sub AutoAddRestrictions()

        ' Auto-create any restrictions for references
        Dim sCommand As String = ""
        If Commands.Count > 0 Then sCommand = Commands(0)
        ' Guess the verb
        Dim sVerb As String = sCommand.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "")
        If sVerb.Contains("%") Then sVerb = sVerb.Substring(0, sVerb.IndexOf("%")).Trim

        For Each Ref As ReferencesType In New ReferencesType() {ReferencesType.Location, ReferencesType.Object, ReferencesType.Character, ReferencesType.Direction, ReferencesType.Number, ReferencesType.Text}
            For Each sReference As String In GetReferences(Ref, sCommand)
                Select Case sReference
                    Case "ReferencedObject", "ReferencedObject1", "ReferencedObject2", "ReferencedObject3", "ReferencedObject4", "ReferencedObject5", "ReferencedObjects"
                        Dim rest As New clsRestriction
                        rest.eType = clsRestriction.RestrictionTypeEnum.Object
                        rest.sKey1 = sReference
                        rest.eMust = clsRestriction.MustEnum.Must
                        rest.eObject = clsRestriction.ObjectEnum.Exist
                        rest.oMessage = New Description("Sorry, I'm not sure which object you are trying to " & sVerb & ".")
                        RestrictDetails1.arlRestrictions.Add(rest)

                        rest = New clsRestriction
                        rest.eType = clsRestriction.RestrictionTypeEnum.Object
                        rest.sKey1 = sReference
                        rest.eMust = clsRestriction.MustEnum.Must
                        rest.eObject = clsRestriction.ObjectEnum.HaveBeenSeenByCharacter
                        rest.sKey2 = "%Player%"
                        rest.oMessage = New Description("Sorry, I'm not sure which object you are trying to " & sVerb & ".")
                        RestrictDetails1.arlRestrictions.Add(rest)

                        rest = New clsRestriction
                        rest.eType = clsRestriction.RestrictionTypeEnum.Object
                        rest.sKey1 = sReference
                        rest.eMust = clsRestriction.MustEnum.Must
                        rest.eObject = clsRestriction.ObjectEnum.BeVisibleToCharacter
                        rest.sKey2 = "%Player%"
                        rest.oMessage = New Description("%CharacterName% can't see " & sReference.Replace("ReferencedObject", "%object") & "%.Name!")
                        RestrictDetails1.arlRestrictions.Add(rest)

                        RestrictDetails1.arlRestrictions.BracketSequence = "#A#A#"

                    Case "ReferencedCharacter", "ReferencedCharacter1", "ReferencedCharacter2", "ReferencedCharacter3", "ReferencedCharacter4", "ReferencedCharacter5", "ReferencedCharacters"
                        Dim rest As New clsRestriction
                        rest.eType = clsRestriction.RestrictionTypeEnum.Character
                        rest.sKey1 = "%Player%"
                        rest.eMust = clsRestriction.MustEnum.Must
                        rest.eCharacter = clsRestriction.CharacterEnum.HaveSeenCharacter
                        rest.sKey2 = sReference
                        rest.oMessage = New Description("Sorry, I'm not sure which character you are referring to.")
                        RestrictDetails1.arlRestrictions.Add(rest)

                        rest = New clsRestriction
                        rest.eType = clsRestriction.RestrictionTypeEnum.Character
                        rest.sKey1 = "%Player%"
                        rest.eMust = clsRestriction.MustEnum.Must
                        rest.eCharacter = clsRestriction.CharacterEnum.BeVisibleToCharacter
                        rest.sKey2 = sReference
                        rest.oMessage = New Description("%CharacterName% can't see " & sReference.Replace("ReferencedCharacter", "%character") & "%.Name!")
                        RestrictDetails1.arlRestrictions.Add(rest)

                        RestrictDetails1.arlRestrictions.BracketSequence = "#A#"
                End Select
            Next
        Next
        RestrictDetails1.LoadRestrictions(RestrictDetails1.arlRestrictions.CloneMe)

    End Sub

    Private Sub frmTask_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        ShowHelp(Me, "Tasks")
    End Sub

    Private Sub SpecificTask1_Changed() Handles SpecificTask1.Changed
        UpdateOverrideableCheckbox()
    End Sub

End Class
