<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox
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

    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    'Friend WithEvents lblProductName As Windows.Forms.Label
    Friend WithEvents LabelVersion As Windows.Forms.Label
    Friend WithEvents lblRegistered As Windows.Forms.Label
    Friend WithEvents OKButton As Windows.Forms.Button
    Friend WithEvents LabelCopyright As Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()       
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        'Me.lblProductName = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.lblRegistered = New System.Windows.Forms.Label()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.UltraGroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogoPictureBox.Image = Global.ADRIFT.My.Resources.Resources.Adrift
        Me.LogoPictureBox.Location = New System.Drawing.Point(9, 13)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(337, 252)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        ''
        ''lblProductName
        ''
        'Me.lblProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Me.lblProductName.Location = New System.Drawing.Point(354, 13)
        'Me.lblProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        'Me.lblProductName.Name = "lblProductName"
        'Me.lblProductName.Size = New System.Drawing.Size(314, 21)
        'Me.lblProductName.TabIndex = 0
        'Me.lblProductName.Text = "ADRIFT Developer"
        '
        'LabelVersion
        '
        Me.LabelVersion.Location = New System.Drawing.Point(356, 38)
        Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(314, 17)
        Me.LabelVersion.TabIndex = 0
        Me.LabelVersion.Text = "Version 5.0.13"
        '
        'LabelCopyright
        '
        Me.LabelCopyright.Location = New System.Drawing.Point(356, 55)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(314, 17)
        Me.LabelCopyright.TabIndex = 0
        Me.LabelCopyright.Text = "Copyright"
        '
        'lblRegistered
        '
        Me.lblRegistered.Location = New System.Drawing.Point(356, 84)
        Me.lblRegistered.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.lblRegistered.Name = "lblRegistered"
        Me.lblRegistered.Size = New System.Drawing.Size(314, 17)
        Me.lblRegistered.TabIndex = 0
        Me.lblRegistered.Text = "Unregistered"
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(569, 238)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(101, 27)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "OK"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.UltraGroupBox1.Controls.Add(Me.lblInfo)
        Me.UltraGroupBox1.Controls.Add(Me.OKButton)
        Me.UltraGroupBox1.Controls.Add(Me.LabelCopyright)
        Me.UltraGroupBox1.Controls.Add(Me.LabelVersion)
        Me.UltraGroupBox1.Controls.Add(Me.lblRegistered)
        'Me.UltraGroupBox1.Controls.Add(Me.lblProductName)
        Me.UltraGroupBox1.Controls.Add(Me.LogoPictureBox)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(682, 276)
        Me.UltraGroupBox1.TabIndex = 1
        Me.UltraGroupBox1.TabStop = False
        '
        'lblInfo
        '
        Me.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInfo.Location = New System.Drawing.Point(355, 106)
        Me.lblInfo.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(314, 123)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "Unregistered"
        '
        'AboutBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(682, 276)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutBox"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About ADRIFT"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents lblInfo As Windows.Forms.Label

End Class
