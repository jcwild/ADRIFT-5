<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFolder
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
        Me.components = New System.ComponentModel.Container()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.btnColumns = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.lstColumns = New System.Windows.Forms.CheckedListBox()
        Me.lblCaption = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.Folder = New ADRIFT.Folder()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.btnClose)
        Me.UltraGroupBox1.Controls.Add(Me.btnColumns)
        Me.UltraGroupBox1.Controls.Add(Me.lblCaption)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(284, 24)
        Me.UltraGroupBox1.TabIndex = 1
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.Image = Global.ADRIFT.My.Resources.imgCancel16
        Me.btnClose.Appearance = Appearance2
        Me.btnClose.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(263, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.ShowFocusRect = False
        Me.btnClose.ShowOutline = False
        Me.btnClose.Size = New System.Drawing.Size(19, 18)
        Me.btnClose.TabIndex = 1
        Me.btnClose.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnClose.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnClose.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnColumns
        '
        Me.btnColumns.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.BorderColor = System.Drawing.Color.Transparent
        Appearance3.Image = Global.ADRIFT.My.Resources.imgFilter
        Me.btnColumns.Appearance = Appearance3
        Me.btnColumns.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Me.btnColumns.Location = New System.Drawing.Point(234, 2)
        Me.btnColumns.Name = "btnColumns"
        Me.btnColumns.PopupItemKey = "lstColumns"
        Me.btnColumns.PopupItemProvider = Me.UltraPopupControlContainer1
        Me.btnColumns.ShowFocusRect = False
        Me.btnColumns.ShowOutline = False
        Me.btnColumns.Size = New System.Drawing.Size(31, 21)
        Me.btnColumns.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.btnColumns.TabIndex = 3
        Me.btnColumns.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        Me.btnColumns.Visible = False
        '
        'UltraPopupControlContainer1
        '
        Me.UltraPopupControlContainer1.PopupControl = Me.lstColumns
        '
        'lstColumns
        '
        Me.lstColumns.CheckOnClick = True
        Me.lstColumns.FormattingEnabled = True
        Me.lstColumns.Items.AddRange(New Object() {"Date created", "Date modified", "Type", "Key", "Priority"})
        Me.lstColumns.Location = New System.Drawing.Point(184, 47)
        Me.lstColumns.Name = "lstColumns"
        Me.lstColumns.Size = New System.Drawing.Size(97, 79)
        Me.lstColumns.TabIndex = 5
        Me.lstColumns.Visible = False
        '
        'lblCaption
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextVAlignAsString = "Bottom"
        Me.lblCaption.Appearance = Appearance1
        Me.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCaption.Location = New System.Drawing.Point(3, 0)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(278, 21)
        Me.lblCaption.TabIndex = 2
        Me.lblCaption.Text = "UltraLabel1"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 239)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(284, 23)
        Me.UltraStatusBar1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.[True]
        Me.UltraStatusBar1.TabIndex = 2
        Me.UltraStatusBar1.Text = "UltraStatusBar1"
        Me.UltraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'Folder
        '
        Me.Folder.AllowDrop = True
        Me.Folder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Folder.Location = New System.Drawing.Point(0, 24)
        Me.Folder.Name = "Folder"
        Me.Folder.Size = New System.Drawing.Size(284, 215)
        Me.Folder.TabIndex = 0
        '
        'frmFolder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.ControlBox = False
        Me.Controls.Add(Me.lstColumns)
        Me.Controls.Add(Me.Folder)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(100, 70)
        Me.Name = "frmFolder"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Folder As ADRIFT.Folder
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblCaption As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents btnColumns As Infragistics.Win.Misc.UltraDropDownButton
    Friend WithEvents lstColumns As System.Windows.Forms.CheckedListBox
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
End Class
