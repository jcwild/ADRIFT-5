<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserFunction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserFunction))
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(0)
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.btnApply = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.txtName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblOutput = New Infragistics.Win.Misc.UltraLabel()
        Me.lblName = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.grdArguments = New System.Windows.Forms.DataGridView()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colType = New Infragistics.Win.UltraDataGridView.UltraComboEditorColumn(Me.components)
        Me.txtOutput = New ADRIFT.GenTextbox()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdArguments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 381)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(501, 48)
        Me.UltraStatusBar1.TabIndex = 13
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(401, 387)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(88, 32)
        Me.btnApply.TabIndex = 18
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(305, 387)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(209, 387)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "OK"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(57, 14)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(432, 24)
        Me.txtName.TabIndex = 22
        '
        'lblOutput
        '
        Me.lblOutput.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblOutput.Location = New System.Drawing.Point(12, 162)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(64, 16)
        Me.lblOutput.TabIndex = 21
        Me.lblOutput.Text = "Output:"
        '
        'lblName
        '
        Me.lblName.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblName.Location = New System.Drawing.Point(12, 20)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(56, 16)
        Me.lblName.TabIndex = 20
        Me.lblName.Text = "Name:"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 48)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(64, 16)
        Me.UltraLabel1.TabIndex = 23
        Me.UltraLabel1.Text = "Parameters:"
        '
        'grdArguments
        '
        Me.grdArguments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdArguments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdArguments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colName, Me.colType})
        Me.grdArguments.Location = New System.Drawing.Point(12, 66)
        Me.grdArguments.Name = "grdArguments"
        Me.grdArguments.RowHeadersVisible = False
        Me.grdArguments.Size = New System.Drawing.Size(477, 86)
        Me.grdArguments.TabIndex = 24
        '
        'colName
        '
        Me.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colName.HeaderText = "Name"
        Me.colName.Name = "colName"
        '
        'colType
        '
        Me.colType.DefaultNewRowValue = CType(resources.GetObject("colType.DefaultNewRowValue"), Object)
        Me.colType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.colType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.colType.FillWeight = 150.0!
        Me.colType.HeaderText = "Type"
        Me.colType.Name = "colType"
        Me.colType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colType.ValueList = ValueList1
        Me.colType.Width = 150
        '
        'txtOutput
        '
        Me.txtOutput.AllowAlternateDescriptions = True
        Me.txtOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutput.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtOutput.FirstTabHasRestrictions = False
        Me.txtOutput.Location = New System.Drawing.Point(12, 179)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.sCommand = Nothing
        Me.txtOutput.Size = New System.Drawing.Size(477, 192)
        Me.txtOutput.TabIndex = 19
        '
        'frmUserFunction
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(501, 429)
        Me.Controls.Add(Me.grdArguments)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblOutput)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(422, 394)
        Me.Name = "frmUserFunction"
        Me.Text = "User Defined Function"
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdArguments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents btnApply As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtOutput As ADRIFT.GenTextbox
    Friend WithEvents txtName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblOutput As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents grdArguments As System.Windows.Forms.DataGridView
    Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colType As Infragistics.Win.UltraDataGridView.UltraComboEditorColumn
End Class
