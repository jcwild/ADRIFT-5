<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropertyValue
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
        Me.ExpressionOrVariable = New ADRIFT.ItemSelector()
        Me.cmbList = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        CType(Me.cmbList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Expression
        '
        Me.ExpressionOrVariable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExpressionOrVariable.BackColor = System.Drawing.Color.Transparent
        Me.ExpressionOrVariable.Location = New System.Drawing.Point(0, 0)
        Me.ExpressionOrVariable.Name = "Expression"
        Me.ExpressionOrVariable.Size = New System.Drawing.Size(185, 21)
        Me.ExpressionOrVariable.TabIndex = 6
        Me.ExpressionOrVariable.Visible = False
        Me.ExpressionOrVariable.AllowedListType = ItemSelector.ItemEnum.Expression
        '
        'cmbList
        '
        Me.cmbList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbList.AutoSize = False
        Me.cmbList.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbList.Location = New System.Drawing.Point(0, 0)
        Me.cmbList.Name = "cmbList"
        Me.cmbList.Size = New System.Drawing.Size(187, 21)
        Me.cmbList.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbList.TabIndex = 7
        '
        'PropertyValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ExpressionOrVariable)
        Me.Controls.Add(Me.cmbList)
        Me.Name = "PropertyValue"
        Me.Size = New System.Drawing.Size(187, 21)
        CType(Me.cmbList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExpressionOrVariable As ADRIFT.ItemSelector
    Friend WithEvents cmbList As Infragistics.Win.UltraWinEditors.UltraComboEditor

End Class
