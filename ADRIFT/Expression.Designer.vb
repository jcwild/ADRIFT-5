<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Expression
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.txtExpression = New ADRIFT.OOTextbox()
        Me.btnEdit = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTextEditor1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtExpression
        '
        Me.txtExpression.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExpression.BorderStyle = Infragistics.Win.UIElementBorderStyle.None ' System.Windows.Forms.BorderStyle.None
        Me.txtExpression.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpression.Location = New System.Drawing.Point(3, 3)
        Me.txtExpression.Multiline = False
        Me.txtExpression.Name = "txtExpression"
        Me.txtExpression.Size = New System.Drawing.Size(202, 17)
        Me.txtExpression.TabIndex = 0
        Me.txtExpression.Text = ""
        Me.txtExpression.ScrollBarDisplayStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarDisplayStyle.Never
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.Image = Global.ADRIFT.My.Resources.imgAdd16
        Me.btnEdit.Appearance = Appearance3
        Me.btnEdit.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Borderless
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnEdit.Location = New System.Drawing.Point(210, 0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.ShowFocusRect = False
        Me.btnEdit.Size = New System.Drawing.Size(20, 22)
        Me.btnEdit.TabIndex = 5
        Me.btnEdit.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraTextEditor1
        '
        Me.UltraTextEditor1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColorDisabled = System.Drawing.SystemColors.Window
        Me.UltraTextEditor1.Appearance = Appearance1
        Me.UltraTextEditor1.AutoSize = False
        Me.UltraTextEditor1.Enabled = False
        Me.UltraTextEditor1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTextEditor1.Name = "UltraTextEditor1"
        Me.UltraTextEditor1.Size = New System.Drawing.Size(208, 21)
        Me.UltraTextEditor1.TabIndex = 6
        Me.UltraTextEditor1.Text = "UltraTextEditor1"
        '
        'Expression
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.txtExpression)
        Me.Controls.Add(Me.UltraTextEditor1)
        Me.Controls.Add(Me.btnEdit)        
        Me.Name = "Expression"
        Me.Size = New System.Drawing.Size(227, 21)
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtExpression As OOTextbox ' Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnEdit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTextEditor1 As Infragistics.Win.UltraWinEditors.UltraTextEditor

End Class
