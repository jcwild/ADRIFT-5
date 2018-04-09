<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubEventGUI
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
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.cmbFromStart = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbAction = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblHighlight = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbTurnsSeconds = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblAfterWith = New Infragistics.Win.Misc.UltraLabel()
        Me.lblGroup = New Infragistics.Win.Misc.UltraLabel()
        Me.XtoYturns1 = New ADRIFT.XtoYturns()
        Me.isTasks = New ADRIFT.ItemSelector()
        Me.isLocationGroup = New ADRIFT.ItemSelector()
        Me.txtDescription = New ADRIFT.GenTextbox()
        CType(Me.cmbFromStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.cmbTurnsSeconds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbFromStart
        '
        Me.cmbFromStart.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "FromStart"
        ValueListItem1.DisplayText = "from Start of Event"
        ValueListItem2.DataValue = "FromLast"
        ValueListItem2.DisplayText = "from Last Sub Event"
        ValueListItem10.DataValue = "BeforeEnd"
        ValueListItem10.DisplayText = "before End of Event"
        Me.cmbFromStart.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem10})
        Me.cmbFromStart.Location = New System.Drawing.Point(245, 10)
        Me.cmbFromStart.Name = "cmbFromStart"
        Me.cmbFromStart.Size = New System.Drawing.Size(134, 21)
        Me.cmbFromStart.TabIndex = 3
        Me.cmbFromStart.Text = "from Last Sub Event"
        '
        'cmbAction
        '
        Me.cmbAction.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem4.DataValue = "DisplayMessage"
        ValueListItem4.DisplayText = "Display message"
        ValueListItem5.DataValue = "ChangeLook"
        ValueListItem5.DisplayText = "Change Look description to"
        ValueListItem6.DataValue = "ExecuteTask"
        ValueListItem6.DisplayText = "Run Task"
        ValueListItem7.DataValue = "UnsetTask"
        ValueListItem7.DisplayText = "Unset Task"
        Me.cmbAction.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem4, ValueListItem5, ValueListItem6, ValueListItem7})
        Me.cmbAction.Location = New System.Drawing.Point(378, 10)
        Me.cmbAction.Name = "cmbAction"
        Me.cmbAction.Size = New System.Drawing.Size(163, 21)
        Me.cmbAction.TabIndex = 4
        Me.cmbAction.Text = "Display message"
        '
        'lblHighlight
        '
        Appearance5.BackColor = System.Drawing.SystemColors.Highlight
        Appearance5.BackColor2 = System.Drawing.Color.Transparent
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Me.lblHighlight.Appearance = Appearance5
        Me.lblHighlight.Location = New System.Drawing.Point(2, 3)
        Me.lblHighlight.Name = "lblHighlight"
        Me.lblHighlight.Size = New System.Drawing.Size(6, 148)
        Me.lblHighlight.TabIndex = 12
        Me.lblHighlight.Visible = False
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.cmbTurnsSeconds)
        Me.UltraGroupBox1.Controls.Add(Me.XtoYturns1)
        Me.UltraGroupBox1.Controls.Add(Me.cmbFromStart)
        Me.UltraGroupBox1.Controls.Add(Me.isTasks)
        Me.UltraGroupBox1.Controls.Add(Me.lblAfterWith)
        Me.UltraGroupBox1.Controls.Add(Me.isLocationGroup)
        Me.UltraGroupBox1.Controls.Add(Me.lblGroup)
        Me.UltraGroupBox1.Controls.Add(Me.txtDescription)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(549, 153)
        Me.UltraGroupBox1.TabIndex = 14
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'cmbTurnsSeconds
        '
        Me.cmbTurnsSeconds.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem9.DataValue = "Turns"
        ValueListItem9.DisplayText = "turns"
        ValueListItem3.DataValue = "Seconds"
        ValueListItem3.DisplayText = "seconds"
        Me.cmbTurnsSeconds.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem9, ValueListItem3})
        Me.cmbTurnsSeconds.Location = New System.Drawing.Point(175, 10)
        Me.cmbTurnsSeconds.Name = "cmbTurnsSeconds"
        Me.cmbTurnsSeconds.Size = New System.Drawing.Size(71, 21)
        Me.cmbTurnsSeconds.TabIndex = 15
        Me.cmbTurnsSeconds.Text = "turns"
        '
        'lblAfterWith
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.lblAfterWith.Appearance = Appearance1
        Me.lblAfterWith.Location = New System.Drawing.Point(9, 14)
        Me.lblAfterWith.Name = "lblAfterWith"
        Me.lblAfterWith.Size = New System.Drawing.Size(34, 23)
        Me.lblAfterWith.TabIndex = 14
        Me.lblAfterWith.Tag = "bg"
        Me.lblAfterWith.Text = "After"
        '
        'lblGroup
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.Appearance = Appearance7
        Me.lblGroup.Location = New System.Drawing.Point(8, 127)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(252, 17)
        Me.lblGroup.TabIndex = 8
        Me.lblGroup.Tag = "bg"
        Me.lblGroup.Text = "This will only apply when the Player is at location:"
        '
        'XtoYturns1
        '
        Me.XtoYturns1.BackColor = System.Drawing.Color.Transparent
        Me.XtoYturns1.From = 0
        Me.XtoYturns1.Location = New System.Drawing.Point(39, 10)
        Me.XtoYturns1.MaxValue = 2147483647
        Me.XtoYturns1.MinValue = -2147483648
        Me.XtoYturns1.Name = "XtoYturns1"
        Me.XtoYturns1.Size = New System.Drawing.Size(137, 21)
        Me.XtoYturns1.TabIndex = 17
        Me.XtoYturns1.To = 0
        '
        'isTasks
        '
        Me.isTasks.AllowAddEdit = True
        Me.isTasks.AllowedListType = ADRIFT.ItemSelector.ItemEnum.Task
        Me.isTasks.AllowHidden = False
        Me.isTasks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.isTasks.BackColor = System.Drawing.Color.Transparent
        Me.isTasks.Key = Nothing
        Me.isTasks.ListType = ADRIFT.ItemSelector.ItemEnum.Task
        Me.isTasks.Location = New System.Drawing.Point(215, 37)
        Me.isTasks.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.isTasks.MinimumSize = New System.Drawing.Size(10, 21)
        Me.isTasks.Name = "isTasks"
        Me.isTasks.Size = New System.Drawing.Size(320, 21)
        Me.isTasks.TabIndex = 16
        '
        'isLocationGroup
        '
        Me.isLocationGroup.AllowAddEdit = True
        Me.isLocationGroup.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.isLocationGroup.AllowHidden = False
        Me.isLocationGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.isLocationGroup.BackColor = System.Drawing.Color.Transparent
        Me.isLocationGroup.Key = Nothing
        Me.isLocationGroup.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.isLocationGroup.Location = New System.Drawing.Point(256, 123)
        Me.isLocationGroup.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.isLocationGroup.MinimumSize = New System.Drawing.Size(10, 21)
        Me.isLocationGroup.Name = "isLocationGroup"
        Me.isLocationGroup.Size = New System.Drawing.Size(279, 21)
        Me.isLocationGroup.TabIndex = 13
        '
        'txtDescription
        '
        Me.txtDescription.AllowAlternateDescriptions = True
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.BackColor = System.Drawing.Color.Transparent
        Me.txtDescription.FirstTabHasRestrictions = False
        Me.txtDescription.Location = New System.Drawing.Point(8, 37)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.sCommand = Nothing
        Me.txtDescription.Size = New System.Drawing.Size(535, 84)
        Me.txtDescription.TabIndex = 7
        '
        'SubEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblHighlight)
        Me.Controls.Add(Me.cmbAction)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "SubEvent"
        Me.Size = New System.Drawing.Size(549, 153)
        CType(Me.cmbFromStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.cmbTurnsSeconds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbFromStart As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmbAction As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblHighlight As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblGroup As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtDescription As ADRIFT.GenTextbox
    Friend WithEvents lblAfterWith As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents isLocationGroup As ADRIFT.ItemSelector
    Friend WithEvents isTasks As ADRIFT.ItemSelector
    Friend WithEvents XtoYturns1 As ADRIFT.XtoYturns
    Friend WithEvents cmbTurnsSeconds As Infragistics.Win.UltraWinEditors.UltraComboEditor

End Class
