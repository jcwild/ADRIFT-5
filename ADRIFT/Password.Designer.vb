<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Password
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.grpBackground = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtPassword = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton
        Me.btnOK = New Infragistics.Win.Misc.UltraButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblText = New Infragistics.Win.Misc.UltraLabel
        CType(Me.grpBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBackground.SuspendLayout()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBackground
        '
        Me.grpBackground.Controls.Add(Me.txtPassword)
        Me.grpBackground.Controls.Add(Me.btnCancel)
        Me.grpBackground.Controls.Add(Me.btnOK)
        Me.grpBackground.Controls.Add(Me.PictureBox1)
        Me.grpBackground.Controls.Add(Me.lblText)
        Me.grpBackground.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpBackground.Location = New System.Drawing.Point(0, 0)
        Me.grpBackground.Name = "grpBackground"
        Me.grpBackground.Size = New System.Drawing.Size(376, 118)
        Me.grpBackground.TabIndex = 0
        Me.grpBackground.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtPassword
        '
        Appearance2.TextVAlignAsString = "Middle"
        Me.txtPassword.Appearance = Appearance2
        Me.txtPassword.AutoSize = False
        Me.txtPassword.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(73, 45)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtPassword.Size = New System.Drawing.Size(291, 21)
        Me.txtPassword.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(277, 81)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 25)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(184, 81)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(87, 25)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.ADRIFT.My.Resources.imgUnlock32
        Me.PictureBox1.Location = New System.Drawing.Point(22, 29)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'lblText
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.lblText.Appearance = Appearance1
        Me.lblText.Location = New System.Drawing.Point(73, 23)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(291, 23)
        Me.lblText.TabIndex = 1
        Me.lblText.Text = "Please enter your password:"
        '
        'Password
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(376, 118)
        Me.Controls.Add(Me.grpBackground)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Password"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Password"
        CType(Me.grpBackground, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBackground.ResumeLayout(False)
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpBackground As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblText As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtPassword As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
End Class
