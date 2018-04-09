<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpecificTask
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.txtSpecific = New System.Windows.Forms.RichTextBox
        Me.BlueBorder = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        CType(Me.BlueBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSpecific
        '
        Me.txtSpecific.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpecific.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSpecific.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSpecific.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSpecific.DetectUrls = False
        Me.txtSpecific.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpecific.Location = New System.Drawing.Point(2, 2)
        Me.txtSpecific.Multiline = False
        Me.txtSpecific.Name = "txtSpecific"
        Me.txtSpecific.ReadOnly = True
        Me.txtSpecific.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.txtSpecific.Size = New System.Drawing.Size(296, 20)
        Me.txtSpecific.TabIndex = 17
        Me.txtSpecific.Text = ""
        Me.txtSpecific.WordWrap = False
        '
        'BlueBorder
        '
        Me.BlueBorder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.BlueBorder.Appearance = Appearance2
        Me.BlueBorder.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueBorder.Location = New System.Drawing.Point(0, 0)
        Me.BlueBorder.Name = "BlueBorder"
        Me.BlueBorder.Size = New System.Drawing.Size(300, 24)
        Me.BlueBorder.TabIndex = 18
        Me.BlueBorder.Text = "UltraTextEditor1"
        '
        'SpecificTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtSpecific)
        Me.Controls.Add(Me.BlueBorder)
        Me.Name = "SpecificTask"
        Me.Size = New System.Drawing.Size(300, 24)
        CType(Me.BlueBorder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSpecific As System.Windows.Forms.RichTextBox
    Friend WithEvents BlueBorder As Infragistics.Win.UltraWinEditors.UltraTextEditor

End Class
