<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExpandableDescription
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
        Me.components = New System.ComponentModel.Container()
        Dim DropDownEditorButton1 As Infragistics.Win.UltraWinEditors.DropDownEditorButton = New Infragistics.Win.UltraWinEditors.DropDownEditorButton()
        Me.txtShortDesc = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.GenTextbox1 = New ADRIFT.GenTextbox()
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        CType(Me.txtShortDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtShortDesc
        '
        Me.txtShortDesc.AutoSize = False
        DropDownEditorButton1.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.txtShortDesc.ButtonsRight.Add(DropDownEditorButton1)
        Me.txtShortDesc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtShortDesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShortDesc.Location = New System.Drawing.Point(0, 0)
        Me.txtShortDesc.Name = "txtShortDesc"
        Me.txtShortDesc.Size = New System.Drawing.Size(537, 22)
        Me.txtShortDesc.TabIndex = 5
        '
        'GenTextbox1
        '
        Me.GenTextbox1.AllowAlternateDescriptions = True
        Me.GenTextbox1.BackColor = System.Drawing.Color.Transparent
        Me.GenTextbox1.Location = New System.Drawing.Point(54, 0)
        Me.GenTextbox1.Name = "GenTextbox1"
        Me.GenTextbox1.sCommand = Nothing
        Me.GenTextbox1.Size = New System.Drawing.Size(311, 266)
        Me.GenTextbox1.TabIndex = 8
        Me.GenTextbox1.Visible = False
        '
        'UltraPopupControlContainer1
        '
        Me.UltraPopupControlContainer1.PopupControl = Me.GenTextbox1
        Me.UltraPopupControlContainer1.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        '
        'ExpandableDescription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GenTextbox1)
        Me.Controls.Add(Me.txtShortDesc)
        Me.Name = "ExpandableDescription"
        Me.Size = New System.Drawing.Size(537, 22)
        CType(Me.txtShortDesc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtShortDesc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents GenTextbox1 As ADRIFT.GenTextbox

End Class
