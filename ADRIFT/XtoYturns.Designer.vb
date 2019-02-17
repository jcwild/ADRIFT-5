<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtoYturns
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lblTo = New Infragistics.Win.Misc.UltraLabel()
        Me.btnExpand = New Infragistics.Win.Misc.UltraButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtTo = New ADRIFT.NumericTextbox()
        Me.txtFrom = New ADRIFT.NumericTextbox()
        Me.SuspendLayout()
        '
        'lblTo
        '
        Me.lblTo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTo.Location = New System.Drawing.Point(94, 5)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(14, 20)
        Me.lblTo.TabIndex = 3
        Me.lblTo.Text = "to"
        Me.lblTo.Visible = False
        '
        'btnExpand
        '
        Me.btnExpand.Anchor = System.Windows.Forms.AnchorStyles.Left
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.Image = Global.ADRIFT.My.Resources.imgOneToOne
        Me.btnExpand.Appearance = Appearance3
        Me.btnExpand.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Borderless
        Me.btnExpand.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExpand.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnExpand.Location = New System.Drawing.Point(0, 0)
        Me.btnExpand.Name = "btnExpand"
        Me.btnExpand.Size = New System.Drawing.Size(22, 22)
        Me.btnExpand.TabIndex = 5
        Me.btnExpand.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'txtTo
        '
        Me.txtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTo.Location = New System.Drawing.Point(111, 0)
        Me.txtTo.MaxDecimalPlaces = 0
        Me.txtTo.MinDecimalPlaces = 0
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(67, 22)
        Me.txtTo.TabIndex = 1
        Me.txtTo.Value = 0.0R
        Me.txtTo.Visible = False
        '
        'txtFrom
        '
        Me.txtFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFrom.Location = New System.Drawing.Point(23, 0)
        Me.txtFrom.MaxDecimalPlaces = 0
        Me.txtFrom.MinDecimalPlaces = 0
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(67, 22)
        Me.txtFrom.TabIndex = 0
        Me.txtFrom.Value = 0.0R
        '
        'XtoYturns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.btnExpand)
        Me.Name = "XtoYturns"
        Me.Size = New System.Drawing.Size(178, 22)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtFrom As ADRIFT.NumericTextbox
    Friend WithEvents txtTo As ADRIFT.NumericTextbox
    Friend WithEvents lblTo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnExpand As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
