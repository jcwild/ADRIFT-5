<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWalk
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWalk))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btnRemoveControl = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddControl = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.chkRepeat = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.pnlTaskControl = New System.Windows.Forms.Panel()
        Me.pnlTaskControlInner = New System.Windows.Forms.Panel()
        Me.lblName = New Infragistics.Win.Misc.UltraLabel()
        Me.txtDescription = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.grpStart = New Infragistics.Win.Misc.UltraGroupBox()
        Me.optStart = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btnAddStep = New Infragistics.Win.Misc.UltraButton()
        Me.btnRemoveStep = New Infragistics.Win.Misc.UltraButton()
        Me.btnEditStep = New Infragistics.Win.Misc.UltraButton()
        Me.lvwSteps = New System.Windows.Forms.ListView()
        Me.colLocation = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colWait = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btnDownActivity = New Infragistics.Win.Misc.UltraButton()
        Me.btnUpActivity = New Infragistics.Win.Misc.UltraButton()
        Me.btnRemoveActivity = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddActivity = New Infragistics.Win.Misc.UltraButton()
        Me.pnlSubWalks = New System.Windows.Forms.Panel()
        Me.pnlSubWalksInner = New System.Windows.Forms.Panel()
        Me.tabsEvent = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.btnDownStep = New Infragistics.Win.Misc.UltraButton()
        Me.btnUpStep = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.chkRepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTaskControl.SuspendLayout()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStart.SuspendLayout()
        CType(Me.optStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl3.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.pnlSubWalks.SuspendLayout()
        CType(Me.tabsEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsEvent.SuspendLayout()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.btnRemoveControl)
        Me.UltraTabPageControl1.Controls.Add(Me.btnAddControl)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl1.Controls.Add(Me.chkRepeat)
        Me.UltraTabPageControl1.Controls.Add(Me.pnlTaskControl)
        Me.UltraTabPageControl1.Controls.Add(Me.lblName)
        Me.UltraTabPageControl1.Controls.Add(Me.txtDescription)
        Me.UltraTabPageControl1.Controls.Add(Me.grpStart)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(559, 392)
        '
        'btnRemoveControl
        '
        Me.btnRemoveControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveControl.Enabled = False
        Me.btnRemoveControl.Location = New System.Drawing.Point(437, 363)
        Me.btnRemoveControl.Name = "btnRemoveControl"
        Me.btnRemoveControl.Size = New System.Drawing.Size(112, 21)
        Me.btnRemoveControl.TabIndex = 10
        Me.btnRemoveControl.Text = "Remove Control"
        '
        'btnAddControl
        '
        Me.btnAddControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddControl.Location = New System.Drawing.Point(319, 363)
        Me.btnAddControl.Name = "btnAddControl"
        Me.btnAddControl.Size = New System.Drawing.Size(112, 21)
        Me.btnAddControl.TabIndex = 9
        Me.btnAddControl.Text = "Add Control"
        '
        'UltraLabel2
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel2.Appearance = Appearance1
        Me.UltraLabel2.Location = New System.Drawing.Point(11, 104)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(87, 16)
        Me.UltraLabel2.TabIndex = 8
        Me.UltraLabel2.Text = "Walk Control..."
        '
        'chkRepeat
        '
        Me.chkRepeat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkRepeat.BackColor = System.Drawing.Color.Transparent
        Me.chkRepeat.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkRepeat.Location = New System.Drawing.Point(11, 364)
        Me.chkRepeat.Name = "chkRepeat"
        Me.chkRepeat.Size = New System.Drawing.Size(164, 23)
        Me.chkRepeat.TabIndex = 7
        Me.chkRepeat.Text = "Repeat walk on completion"
        '
        'pnlTaskControl
        '
        Me.pnlTaskControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTaskControl.AutoScroll = True
        Me.pnlTaskControl.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnlTaskControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlTaskControl.Controls.Add(Me.pnlTaskControlInner)
        Me.pnlTaskControl.Location = New System.Drawing.Point(11, 123)
        Me.pnlTaskControl.Name = "pnlTaskControl"
        Me.pnlTaskControl.Size = New System.Drawing.Size(538, 236)
        Me.pnlTaskControl.TabIndex = 6
        '
        'pnlTaskControlInner
        '
        Me.pnlTaskControlInner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTaskControlInner.Location = New System.Drawing.Point(-1, -1)
        Me.pnlTaskControlInner.Name = "pnlTaskControlInner"
        Me.pnlTaskControlInner.Size = New System.Drawing.Size(534, 46)
        Me.pnlTaskControlInner.TabIndex = 0
        '
        'lblName
        '
        Me.lblName.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblName.Location = New System.Drawing.Point(8, 12)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(72, 16)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "Description:"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(84, 8)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(465, 21)
        Me.txtDescription.TabIndex = 3
        '
        'grpStart
        '
        Me.grpStart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Me.grpStart.Appearance = Appearance3
        Me.grpStart.Controls.Add(Me.optStart)
        Me.grpStart.Location = New System.Drawing.Point(11, 41)
        Me.grpStart.Name = "grpStart"
        Me.grpStart.Size = New System.Drawing.Size(535, 50)
        Me.grpStart.TabIndex = 0
        Me.grpStart.Text = "This walk should start off..."
        '
        'optStart
        '
        Me.optStart.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        ValueListItem1.DataValue = "Default Item"
        ValueListItem1.DisplayText = "Inactive"
        ValueListItem2.DataValue = "ValueListItem1"
        ValueListItem2.DisplayText = "Active"
        Me.optStart.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optStart.ItemSpacingHorizontal = 50
        Me.optStart.ItemSpacingVertical = 8
        Me.optStart.Location = New System.Drawing.Point(50, 19)
        Me.optStart.Name = "optStart"
        Me.optStart.Size = New System.Drawing.Size(169, 22)
        Me.optStart.TabIndex = 0
        Me.optStart.TextIndentation = 3
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.btnDownStep)
        Me.UltraTabPageControl3.Controls.Add(Me.btnUpStep)
        Me.UltraTabPageControl3.Controls.Add(Me.btnAddStep)
        Me.UltraTabPageControl3.Controls.Add(Me.btnRemoveStep)
        Me.UltraTabPageControl3.Controls.Add(Me.btnEditStep)
        Me.UltraTabPageControl3.Controls.Add(Me.lvwSteps)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(559, 392)
        '
        'btnAddStep
        '
        Me.btnAddStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddStep.Location = New System.Drawing.Point(201, 363)
        Me.btnAddStep.Name = "btnAddStep"
        Me.btnAddStep.Size = New System.Drawing.Size(112, 21)
        Me.btnAddStep.TabIndex = 13
        Me.btnAddStep.Text = "Add Step"
        '
        'btnRemoveStep
        '
        Me.btnRemoveStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveStep.Enabled = False
        Me.btnRemoveStep.Location = New System.Drawing.Point(437, 363)
        Me.btnRemoveStep.Name = "btnRemoveStep"
        Me.btnRemoveStep.Size = New System.Drawing.Size(112, 21)
        Me.btnRemoveStep.TabIndex = 12
        Me.btnRemoveStep.Text = "Remove Step"
        '
        'btnEditStep
        '
        Me.btnEditStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditStep.Enabled = False
        Me.btnEditStep.Location = New System.Drawing.Point(319, 363)
        Me.btnEditStep.Name = "btnEditStep"
        Me.btnEditStep.Size = New System.Drawing.Size(112, 21)
        Me.btnEditStep.TabIndex = 11
        Me.btnEditStep.Text = "Edit Step"
        '
        'lvwSteps
        '
        Me.lvwSteps.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwSteps.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLocation, Me.colWait})
        Me.lvwSteps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwSteps.FullRowSelect = True
        Me.lvwSteps.Location = New System.Drawing.Point(11, 12)
        Me.lvwSteps.Name = "lvwSteps"
        Me.lvwSteps.Size = New System.Drawing.Size(535, 345)
        Me.lvwSteps.TabIndex = 0
        Me.lvwSteps.UseCompatibleStateImageBehavior = False
        Me.lvwSteps.View = System.Windows.Forms.View.Details
        '
        'colLocation
        '
        Me.colLocation.Text = "Location"
        Me.colLocation.Width = 421
        '
        'colWait
        '
        Me.colWait.Text = "Wait"
        Me.colWait.Width = 110
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.btnDownActivity)
        Me.UltraTabPageControl2.Controls.Add(Me.btnUpActivity)
        Me.UltraTabPageControl2.Controls.Add(Me.btnRemoveActivity)
        Me.UltraTabPageControl2.Controls.Add(Me.btnAddActivity)
        Me.UltraTabPageControl2.Controls.Add(Me.pnlSubWalks)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(559, 392)
        '
        'btnDownActivity
        '
        Me.btnDownActivity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDownActivity.Enabled = False
        Me.btnDownActivity.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnDownActivity.Location = New System.Drawing.Point(42, 363)
        Me.btnDownActivity.Name = "btnDownActivity"
        Me.btnDownActivity.Size = New System.Drawing.Size(24, 21)
        Me.btnDownActivity.TabIndex = 14
        Me.btnDownActivity.Text = "6"
        '
        'btnUpActivity
        '
        Me.btnUpActivity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpActivity.Enabled = False
        Me.btnUpActivity.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnUpActivity.Location = New System.Drawing.Point(12, 363)
        Me.btnUpActivity.Name = "btnUpActivity"
        Me.btnUpActivity.Size = New System.Drawing.Size(24, 21)
        Me.btnUpActivity.TabIndex = 13
        Me.btnUpActivity.Text = "5"
        '
        'btnRemoveActivity
        '
        Me.btnRemoveActivity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveActivity.Enabled = False
        Me.btnRemoveActivity.Location = New System.Drawing.Point(437, 363)
        Me.btnRemoveActivity.Name = "btnRemoveActivity"
        Me.btnRemoveActivity.Size = New System.Drawing.Size(112, 21)
        Me.btnRemoveActivity.TabIndex = 12
        Me.btnRemoveActivity.Text = "Remove Activity"
        '
        'btnAddActivity
        '
        Me.btnAddActivity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddActivity.Location = New System.Drawing.Point(319, 363)
        Me.btnAddActivity.Name = "btnAddActivity"
        Me.btnAddActivity.Size = New System.Drawing.Size(112, 21)
        Me.btnAddActivity.TabIndex = 11
        Me.btnAddActivity.Text = "Add Activity"
        '
        'pnlSubWalks
        '
        Me.pnlSubWalks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSubWalks.AutoScroll = True
        Me.pnlSubWalks.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnlSubWalks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSubWalks.Controls.Add(Me.pnlSubWalksInner)
        Me.pnlSubWalks.Location = New System.Drawing.Point(11, 12)
        Me.pnlSubWalks.Name = "pnlSubWalks"
        Me.pnlSubWalks.Size = New System.Drawing.Size(538, 347)
        Me.pnlSubWalks.TabIndex = 7
        '
        'pnlSubWalksInner
        '
        Me.pnlSubWalksInner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSubWalksInner.Location = New System.Drawing.Point(-1, -2)
        Me.pnlSubWalksInner.Name = "pnlSubWalksInner"
        Me.pnlSubWalksInner.Size = New System.Drawing.Size(534, 46)
        Me.pnlSubWalksInner.TabIndex = 1
        '
        'tabsEvent
        '
        Me.tabsEvent.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabsEvent.Controls.Add(Me.UltraTabPageControl1)
        Me.tabsEvent.Controls.Add(Me.UltraTabPageControl2)
        Me.tabsEvent.Controls.Add(Me.UltraTabPageControl3)
        Me.tabsEvent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsEvent.Location = New System.Drawing.Point(0, 0)
        Me.tabsEvent.Name = "tabsEvent"
        Me.tabsEvent.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabsEvent.Size = New System.Drawing.Size(563, 418)
        Me.tabsEvent.TabIndex = 20
        UltraTab1.Key = "tabWalkControl"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Control"
        UltraTab3.Key = "tabWalkSteps"
        UltraTab3.TabPage = Me.UltraTabPageControl3
        UltraTab3.Text = "Steps"
        UltraTab2.Key = "tabWalkActivities"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Activities"
        Me.tabsEvent.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab3, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(559, 392)
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 418)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(563, 48)
        Me.UltraStatusBar1.TabIndex = 16
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(459, 428)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(365, 428)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 21
        Me.btnOK.Text = "OK"
        '
        'btnDownStep
        '
        Me.btnDownStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDownStep.Enabled = False
        Me.btnDownStep.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnDownStep.Location = New System.Drawing.Point(42, 363)
        Me.btnDownStep.Name = "btnDownStep"
        Me.btnDownStep.Size = New System.Drawing.Size(24, 21)
        Me.btnDownStep.TabIndex = 16
        Me.btnDownStep.Text = "6"
        '
        'btnUpStep
        '
        Me.btnUpStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpStep.Enabled = False
        Me.btnUpStep.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnUpStep.Location = New System.Drawing.Point(12, 363)
        Me.btnUpStep.Name = "btnUpStep"
        Me.btnUpStep.Size = New System.Drawing.Size(24, 21)
        Me.btnUpStep.TabIndex = 15
        Me.btnUpStep.Text = "5"
        '
        'frmWalk
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(563, 466)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tabsEvent)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(571, 500)
        Me.Name = "frmWalk"
        Me.Text = "Edit Walk"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.chkRepeat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTaskControl.ResumeLayout(False)
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStart.ResumeLayout(False)
        CType(Me.optStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.pnlSubWalks.ResumeLayout(False)
        CType(Me.tabsEvent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsEvent.ResumeLayout(False)
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabsEvent As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grpStart As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents optStart As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents lblName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtDescription As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents chkRepeat As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents pnlTaskControl As System.Windows.Forms.Panel
    Friend WithEvents btnAddControl As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents pnlSubWalks As System.Windows.Forms.Panel
    Friend WithEvents btnRemoveControl As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnRemoveActivity As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddActivity As Infragistics.Win.Misc.UltraButton
    Friend WithEvents pnlTaskControlInner As System.Windows.Forms.Panel
    Friend WithEvents pnlSubWalksInner As System.Windows.Forms.Panel
    Friend WithEvents btnDownActivity As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnUpActivity As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents btnAddStep As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnRemoveStep As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnEditStep As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lvwSteps As System.Windows.Forms.ListView
    Friend WithEvents colLocation As System.Windows.Forms.ColumnHeader
    Friend WithEvents colWait As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnDownStep As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnUpStep As Infragistics.Win.Misc.UltraButton
End Class
