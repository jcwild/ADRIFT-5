<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMacros
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
        'Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMacros))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lstMacros = New System.Windows.Forms.ListBox
        Me.txtCommands = New System.Windows.Forms.TextBox
        Me.lblCommands = New Windows.Forms.Label ' Infragistics.Win.Misc.UltraLabel
        Me.UltraStatusBar1 = New Windows.Forms.StatusBar ' Infragistics.Win.UltraWinStatusBar.UltraStatusBar
        Me.btnCancel = New Windows.Forms.Button 'Infragistics.Win.Misc.UltraButton
        Me.btnOK = New Windows.Forms.Button 'Infragistics.Win.Misc.UltraButton
        Me.btnAdd = New Windows.Forms.Button 'Infragistics.Win.Misc.UltraButton
        Me.btnRemove = New Windows.Forms.Button ' Infragistics.Win.Misc.UltraButton
        Me.UltraLabel2 = New Windows.Forms.Label 'Infragistics.Win.Misc.UltraLabel
        Me.chkShared = New Windows.Forms.CheckBox  'Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.cmbShortcut = New Windows.Forms.ComboBox  'Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel3 = New Windows.Forms.Label 'Infragistics.Win.Misc.UltraLabel
        Me.btnDown = New Windows.Forms.Button 'Infragistics.Win.Misc.UltraButton
        Me.btnUp = New Windows.Forms.Button 'Infragistics.Win.Misc.UltraButton
        Me.btnApply = New Windows.Forms.Button 'Infragistics.Win.Misc.UltraButton
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        'CType(Me.cmbShortcut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(31, 31)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstMacros)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtCommands)
        Me.SplitContainer1.Size = New System.Drawing.Size(569, 374)
        Me.SplitContainer1.SplitterDistance = 188
        Me.SplitContainer1.TabIndex = 0
        '
        'lstMacros
        '
        Me.lstMacros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstMacros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstMacros.FormattingEnabled = True
        Me.lstMacros.IntegralHeight = False
        Me.lstMacros.ItemHeight = 16
        Me.lstMacros.Location = New System.Drawing.Point(0, 0)
        Me.lstMacros.Name = "lstMacros"
        Me.lstMacros.Size = New System.Drawing.Size(188, 374)
        Me.lstMacros.TabIndex = 0
        '
        'txtCommands
        '
        Me.txtCommands.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCommands.Enabled = False
        Me.txtCommands.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommands.Location = New System.Drawing.Point(0, 0)
        Me.txtCommands.Multiline = True
        Me.txtCommands.Name = "txtCommands"
        Me.txtCommands.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCommands.Size = New System.Drawing.Size(377, 374)
        Me.txtCommands.TabIndex = 0
        '
        'lblCommands
        '
        Me.lblCommands.Location = New System.Drawing.Point(221, 12)
        Me.lblCommands.Name = "lblCommands"
        Me.lblCommands.Size = New System.Drawing.Size(358, 18)
        Me.lblCommands.TabIndex = 0
        Me.lblCommands.Text = "Enter commands for this adventure, each on a separate line"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 442)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(612, 42)
        Me.UltraStatusBar1.TabIndex = 16
        'Me.UltraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(418, 447)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        'Appearance1.BackColor = System.Drawing.Color.Transparent
        'Me.btnOK.Appearance = Appearance1
        Me.btnOK.Location = New System.Drawing.Point(324, 447)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 18
        Me.btnOK.Text = "OK"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(29, 411)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(88, 25)
        Me.btnAdd.TabIndex = 20
        Me.btnAdd.Text = "Add"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(123, 411)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(88, 25)
        Me.btnRemove.TabIndex = 21
        Me.btnRemove.Text = "Remove"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(29, 12)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(71, 18)
        Me.UltraLabel2.TabIndex = 22
        Me.UltraLabel2.Text = "Macros"
        '
        'chkShared
        '
        Me.chkShared.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShared.Location = New System.Drawing.Point(416, 413)
        Me.chkShared.Name = "chkShared"
        Me.chkShared.Size = New System.Drawing.Size(179, 20)
        Me.chkShared.TabIndex = 23
        Me.chkShared.Text = "Macro applies to all adventures"
        '
        'cmbShortcut
        '
        Me.cmbShortcut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbShortcut.DropDownStyle = ComboBoxStyle.DropDownList ' Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbShortcut.Location = New System.Drawing.Point(308, 412)
        Me.cmbShortcut.Name = "cmbShortcut"
        Me.cmbShortcut.Size = New System.Drawing.Size(78, 21)
        Me.cmbShortcut.TabIndex = 1
        Me.cmbShortcut.DisplayMember = "ToString"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel3.Location = New System.Drawing.Point(255, 416)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(60, 18)
        Me.UltraLabel3.TabIndex = 24
        Me.UltraLabel3.Text = "Shortcut"
        '
        'btnDown
        '
        Me.btnDown.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnDown.Enabled = False
        Me.btnDown.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnDown.Location = New System.Drawing.Point(4, 218)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(24, 23)
        Me.btnDown.TabIndex = 26
        Me.btnDown.Text = "6"
        '
        'btnUp
        '
        Me.btnUp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnUp.Enabled = False
        Me.btnUp.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnUp.Location = New System.Drawing.Point(4, 186)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(24, 23)
        Me.btnUp.TabIndex = 25
        Me.btnUp.Text = "5"
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Location = New System.Drawing.Point(512, 447)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(88, 32)
        Me.btnApply.TabIndex = 27
        Me.btnApply.Text = "Apply"
        '
        'frmMacros
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(612, 484)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.cmbShortcut)
        Me.Controls.Add(Me.UltraLabel3)
        Me.Controls.Add(Me.chkShared)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.lblCommands)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(591, 370)
        Me.Name = "frmMacros"
        Me.Text = "Form1"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        'CType(Me.cmbShortcut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lstMacros As System.Windows.Forms.ListBox
    Friend WithEvents txtCommands As System.Windows.Forms.TextBox
    Friend WithEvents UltraStatusBar1 As Windows.Forms.StatusBar ' Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents btnCancel As Windows.Forms.Button ' Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Windows.Forms.Button 'Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblCommands As Windows.Forms.Label 'Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnAdd As Windows.Forms.Button 'Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnRemove As Windows.Forms.Button 'Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel2 As Windows.Forms.Label 'Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkShared As Windows.Forms.CheckBox ' Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents cmbShortcut As Windows.Forms.ComboBox ' Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel3 As Windows.Forms.Label ' Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnDown As Windows.Forms.Button 'Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnUp As Windows.Forms.Button 'Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnApply As Windows.Forms.Button 'Infragistics.Win.Misc.UltraButton
End Class
