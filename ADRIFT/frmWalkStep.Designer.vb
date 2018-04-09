<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWalkStep
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
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ItemSelector1 = New ADRIFT.ItemSelector()
        Me.XtoYturns1 = New ADRIFT.XtoYturns()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 93)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(485, 48)
        Me.UltraStatusBar1.TabIndex = 17
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(381, 103)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 24
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(287, 103)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 23
        Me.btnOK.Text = "OK"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Where should character move to:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "How long should they stay there:"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None
        Me.UltraGroupBox1.Controls.Add(Me.ItemSelector1)
        Me.UltraGroupBox1.Controls.Add(Me.XtoYturns1)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(485, 93)
        Me.UltraGroupBox1.TabIndex = 29
        '
        'ItemSelector1
        '
        Me.ItemSelector1.AllowAddEdit = True
        Me.ItemSelector1.AllowedListType = CType(((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.Character) _
            Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.ItemSelector1.AllowHidden = True
        Me.ItemSelector1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ItemSelector1.BackColor = System.Drawing.Color.Transparent
        Me.ItemSelector1.Key = Nothing
        Me.ItemSelector1.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.ItemSelector1.Location = New System.Drawing.Point(183, 21)
        Me.ItemSelector1.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.ItemSelector1.MinimumSize = New System.Drawing.Size(10, 21)
        Me.ItemSelector1.Name = "ItemSelector1"
        Me.ItemSelector1.Size = New System.Drawing.Size(286, 21)
        Me.ItemSelector1.TabIndex = 27
        '
        'XtoYturns1
        '
        Me.XtoYturns1.BackColor = System.Drawing.Color.Transparent
        Me.XtoYturns1.From = 0
        Me.XtoYturns1.Location = New System.Drawing.Point(204, 53)
        Me.XtoYturns1.MaxValue = 2147483647
        Me.XtoYturns1.MinValue = 0
        Me.XtoYturns1.Name = "XtoYturns1"
        Me.XtoYturns1.Size = New System.Drawing.Size(99, 21)
        Me.XtoYturns1.TabIndex = 28
        Me.XtoYturns1.To = 0
        '
        'frmWalkStep
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(485, 141)
        Me.ControlBox = False
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.MaximumSize = New System.Drawing.Size(721, 179)
        Me.MinimumSize = New System.Drawing.Size(431, 179)
        Me.Name = "frmWalkStep"
        Me.Text = "Step of walk"
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ItemSelector1 As ADRIFT.ItemSelector
    Friend WithEvents XtoYturns1 As ADRIFT.XtoYturns
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox

End Class
