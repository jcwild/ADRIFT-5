<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptionsRunner
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoadForm()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnApply As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents UltraStatusBar1 As Windows.Forms.StatusBar
    Friend WithEvents tabsOptions As Windows.Forms.TabControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudMargin As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkBlankLine As System.Windows.Forms.CheckBox    
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()       
        Me.btnSetFont = New System.Windows.Forms.Button()
        Me.txtFont = New System.Windows.Forms.TextBox()
        Me.chkUseMyFont = New System.Windows.Forms.CheckBox()
        Me.chkSound = New System.Windows.Forms.CheckBox()
        Me.chkGraphics = New System.Windows.Forms.CheckBox()
        Me.btnResetColours = New System.Windows.Forms.Button()
        Me.UltraGroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkAllowColours = New System.Windows.Forms.CheckBox()
        Me.lblLinkColour = New System.Windows.Forms.Label()
        Me.pnlLinkColour = New System.Windows.Forms.Panel()
        Me.lblBackgroundColour = New System.Windows.Forms.Label()
        Me.lblOutputColour = New System.Windows.Forms.Label()
        Me.pnlBackgroundColour = New System.Windows.Forms.Panel()
        Me.lblInputColour = New System.Windows.Forms.Label()
        Me.pnlOutputColour = New System.Windows.Forms.Panel()
        Me.pnlInputColour = New System.Windows.Forms.Panel()
        Me.chkLocationNames = New System.Windows.Forms.CheckBox()
        Me.chkBlankLine = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudMargin = New System.Windows.Forms.NumericUpDown()
        Me.fd = New System.Windows.Forms.FontDialog()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.UltraStatusBar1 = New System.Windows.Forms.StatusBar()
        Me.tabsOptions = New System.Windows.Forms.TabControl()
        Me.tabGeneral = New System.Windows.Forms.TabPage()
        Me.chkDisplayLinks = New System.Windows.Forms.CheckBox()
        Me.chkEnableMenu = New System.Windows.Forms.CheckBox()
        Me.chkAllowFonts = New System.Windows.Forms.CheckBox()
        Me.tabAdvanced = New System.Windows.Forms.TabPage()
        Me.UltraGroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkSoundSoundPlayer = New System.Windows.Forms.CheckBox()
        Me.chkSoundDirectX = New System.Windows.Forms.CheckBox()
        Me.chkSoundWinMM = New System.Windows.Forms.CheckBox()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.nudMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsOptions.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.tabAdvanced.SuspendLayout()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSetFont
        '
        Me.btnSetFont.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetFont.Enabled = False
        Me.btnSetFont.Location = New System.Drawing.Point(424, 285)
        Me.btnSetFont.Name = "btnSetFont"
        Me.btnSetFont.Size = New System.Drawing.Size(75, 23)
        Me.btnSetFont.TabIndex = 9
        Me.btnSetFont.Text = "Set Font"
        Me.btnSetFont.UseVisualStyleBackColor = True
        '
        'txtFont
        '
        Me.txtFont.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFont.Enabled = False
        Me.txtFont.Location = New System.Drawing.Point(172, 287)
        Me.txtFont.Name = "txtFont"
        Me.txtFont.Size = New System.Drawing.Size(252, 20)
        Me.txtFont.TabIndex = 8
        '
        'chkUseMyFont
        '
        Me.chkUseMyFont.AutoSize = True
        Me.chkUseMyFont.BackColor = System.Drawing.Color.Transparent
        Me.chkUseMyFont.Location = New System.Drawing.Point(35, 288)
        Me.chkUseMyFont.Name = "chkUseMyFont"
        Me.chkUseMyFont.Size = New System.Drawing.Size(116, 17)
        Me.chkUseMyFont.TabIndex = 6
        Me.chkUseMyFont.Text = "Always use my font"
        Me.chkUseMyFont.UseVisualStyleBackColor = False
        '
        'chkSound
        '
        Me.chkSound.AutoSize = True
        Me.chkSound.BackColor = System.Drawing.Color.Transparent
        Me.chkSound.Location = New System.Drawing.Point(35, 257)
        Me.chkSound.Name = "chkSound"
        Me.chkSound.Size = New System.Drawing.Size(93, 17)
        Me.chkSound.TabIndex = 5
        Me.chkSound.Text = "Enable Sound"
        Me.chkSound.UseVisualStyleBackColor = False
        '
        'chkGraphics
        '
        Me.chkGraphics.AutoSize = True
        Me.chkGraphics.BackColor = System.Drawing.Color.Transparent
        Me.chkGraphics.Location = New System.Drawing.Point(315, 257)
        Me.chkGraphics.Name = "chkGraphics"
        Me.chkGraphics.Size = New System.Drawing.Size(104, 17)
        Me.chkGraphics.TabIndex = 4
        Me.chkGraphics.Text = "Enable Graphics"
        Me.chkGraphics.UseVisualStyleBackColor = False
        '
        'btnResetColours
        '
        Me.btnResetColours.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnResetColours.Location = New System.Drawing.Point(35, 322)
        Me.btnResetColours.Name = "btnResetColours"
        Me.btnResetColours.Size = New System.Drawing.Size(106, 23)
        Me.btnResetColours.TabIndex = 0
        Me.btnResetColours.Text = "Reset to defaults"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.chkAllowColours)
        Me.UltraGroupBox1.Controls.Add(Me.lblLinkColour)
        Me.UltraGroupBox1.Controls.Add(Me.pnlLinkColour)
        Me.UltraGroupBox1.Controls.Add(Me.lblBackgroundColour)
        Me.UltraGroupBox1.Controls.Add(Me.lblOutputColour)
        Me.UltraGroupBox1.Controls.Add(Me.pnlBackgroundColour)
        Me.UltraGroupBox1.Controls.Add(Me.lblInputColour)
        Me.UltraGroupBox1.Controls.Add(Me.pnlOutputColour)
        Me.UltraGroupBox1.Controls.Add(Me.pnlInputColour)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(11, 15)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(308, 127)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.TabStop = False
        Me.UltraGroupBox1.Text = "Colours"
        '
        'chkAllowColours
        '
        Me.chkAllowColours.AutoSize = True
        Me.chkAllowColours.BackColor = System.Drawing.Color.Transparent
        Me.chkAllowColours.Location = New System.Drawing.Point(24, 98)
        Me.chkAllowColours.Name = "chkAllowColours"
        Me.chkAllowColours.Size = New System.Drawing.Size(225, 17)
        Me.chkAllowColours.TabIndex = 10
        Me.chkAllowColours.Text = "Allow text colours to be modified by games"
        Me.chkAllowColours.UseVisualStyleBackColor = False
        '
        'lblLinkColour
        '
        Me.lblLinkColour.BackColor = System.Drawing.Color.Transparent
        Me.lblLinkColour.Location = New System.Drawing.Point(18, 62)
        Me.lblLinkColour.Name = "lblLinkColour"
        Me.lblLinkColour.Size = New System.Drawing.Size(100, 19)
        Me.lblLinkColour.TabIndex = 26
        Me.lblLinkColour.Text = "Link colour"
        Me.lblLinkColour.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlLinkColour
        '
        Me.pnlLinkColour.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.pnlLinkColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLinkColour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlLinkColour.Location = New System.Drawing.Point(124, 56)
        Me.pnlLinkColour.Name = "pnlLinkColour"
        Me.pnlLinkColour.Size = New System.Drawing.Size(25, 25)
        Me.pnlLinkColour.TabIndex = 23
        '
        'lblBackgroundColour
        '
        Me.lblBackgroundColour.BackColor = System.Drawing.Color.Transparent
        Me.lblBackgroundColour.Location = New System.Drawing.Point(18, 31)
        Me.lblBackgroundColour.Name = "lblBackgroundColour"
        Me.lblBackgroundColour.Size = New System.Drawing.Size(100, 19)
        Me.lblBackgroundColour.TabIndex = 25
        Me.lblBackgroundColour.Text = "Background colour"
        Me.lblBackgroundColour.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOutputColour
        '
        Me.lblOutputColour.BackColor = System.Drawing.Color.Transparent
        Me.lblOutputColour.Location = New System.Drawing.Point(186, 62)
        Me.lblOutputColour.Name = "lblOutputColour"
        Me.lblOutputColour.Size = New System.Drawing.Size(100, 19)
        Me.lblOutputColour.TabIndex = 23
        Me.lblOutputColour.Text = "Output colour"
        '
        'pnlBackgroundColour
        '
        Me.pnlBackgroundColour.BackColor = System.Drawing.Color.Black
        Me.pnlBackgroundColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBackgroundColour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBackgroundColour.Location = New System.Drawing.Point(124, 25)
        Me.pnlBackgroundColour.Name = "pnlBackgroundColour"
        Me.pnlBackgroundColour.Size = New System.Drawing.Size(25, 25)
        Me.pnlBackgroundColour.TabIndex = 24
        '
        'lblInputColour
        '
        Me.lblInputColour.BackColor = System.Drawing.Color.Transparent
        Me.lblInputColour.Location = New System.Drawing.Point(186, 31)
        Me.lblInputColour.Name = "lblInputColour"
        Me.lblInputColour.Size = New System.Drawing.Size(100, 19)
        Me.lblInputColour.TabIndex = 21
        Me.lblInputColour.Text = "Input colour"
        '
        'pnlOutputColour
        '
        Me.pnlOutputColour.BackColor = System.Drawing.Color.SeaGreen
        Me.pnlOutputColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOutputColour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlOutputColour.Location = New System.Drawing.Point(155, 56)
        Me.pnlOutputColour.Name = "pnlOutputColour"
        Me.pnlOutputColour.Size = New System.Drawing.Size(25, 25)
        Me.pnlOutputColour.TabIndex = 22
        '
        'pnlInputColour
        '
        Me.pnlInputColour.BackColor = System.Drawing.Color.Red
        Me.pnlInputColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInputColour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlInputColour.Location = New System.Drawing.Point(155, 25)
        Me.pnlInputColour.Name = "pnlInputColour"
        Me.pnlInputColour.Size = New System.Drawing.Size(25, 25)
        Me.pnlInputColour.TabIndex = 20
        '
        'chkLocationNames
        '
        Me.chkLocationNames.AutoSize = True
        Me.chkLocationNames.BackColor = System.Drawing.Color.Transparent
        Me.chkLocationNames.Location = New System.Drawing.Point(35, 226)
        Me.chkLocationNames.Name = "chkLocationNames"
        Me.chkLocationNames.Size = New System.Drawing.Size(346, 17)
        Me.chkLocationNames.TabIndex = 3
        Me.chkLocationNames.Text = "Additionally display the Short Location name when viewing locations"
        Me.chkLocationNames.UseVisualStyleBackColor = False
        '
        'chkBlankLine
        '
        Me.chkBlankLine.AutoSize = True
        Me.chkBlankLine.BackColor = System.Drawing.Color.Transparent
        Me.chkBlankLine.Location = New System.Drawing.Point(35, 195)
        Me.chkBlankLine.Name = "chkBlankLine"
        Me.chkBlankLine.Size = New System.Drawing.Size(204, 17)
        Me.chkBlankLine.TabIndex = 2
        Me.chkBlankLine.Text = "Add a blank line after every command"
        Me.chkBlankLine.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(376, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Margin:"
        '
        'nudMargin
        '
        Me.nudMargin.Location = New System.Drawing.Point(424, 40)
        Me.nudMargin.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudMargin.Name = "nudMargin"
        Me.nudMargin.Size = New System.Drawing.Size(57, 20)
        Me.nudMargin.TabIndex = 0
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(424, 402)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(88, 32)
        Me.btnApply.TabIndex = 18
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(328, 402)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(232, 402)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "OK"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 394)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(528, 48)
        Me.UltraStatusBar1.TabIndex = 15
        '
        'tabsOptions
        '
        Me.tabsOptions.Controls.Add(Me.tabGeneral)
        Me.tabsOptions.Controls.Add(Me.tabAdvanced)
        Me.tabsOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsOptions.Location = New System.Drawing.Point(0, 0)
        Me.tabsOptions.Name = "tabsOptions"
        Me.tabsOptions.SelectedIndex = 0
        Me.tabsOptions.Size = New System.Drawing.Size(528, 394)
        Me.tabsOptions.TabIndex = 19
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.chkDisplayLinks)
        Me.tabGeneral.Controls.Add(Me.chkEnableMenu)
        Me.tabGeneral.Controls.Add(Me.chkAllowFonts)
        Me.tabGeneral.Controls.Add(Me.btnSetFont)
        Me.tabGeneral.Controls.Add(Me.txtFont)
        Me.tabGeneral.Controls.Add(Me.chkUseMyFont)
        Me.tabGeneral.Controls.Add(Me.chkSound)
        Me.tabGeneral.Controls.Add(Me.chkGraphics)
        Me.tabGeneral.Controls.Add(Me.btnResetColours)
        Me.tabGeneral.Controls.Add(Me.UltraGroupBox1)
        Me.tabGeneral.Controls.Add(Me.chkLocationNames)
        Me.tabGeneral.Controls.Add(Me.chkBlankLine)
        Me.tabGeneral.Controls.Add(Me.Label1)
        Me.tabGeneral.Controls.Add(Me.nudMargin)
        Me.tabGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Size = New System.Drawing.Size(520, 368)
        Me.tabGeneral.TabIndex = 0
        Me.tabGeneral.Text = "General"
        '
        'chkDisplayLinks
        '
        Me.chkDisplayLinks.AutoSize = True
        Me.chkDisplayLinks.BackColor = System.Drawing.Color.Transparent
        Me.chkDisplayLinks.Enabled = False
        Me.chkDisplayLinks.Location = New System.Drawing.Point(315, 195)
        Me.chkDisplayLinks.Name = "chkDisplayLinks"
        Me.chkDisplayLinks.Size = New System.Drawing.Size(171, 17)
        Me.chkDisplayLinks.TabIndex = 29
        Me.chkDisplayLinks.Text = "Display links on clickable items"
        Me.chkDisplayLinks.UseVisualStyleBackColor = False
        '
        'chkEnableMenu
        '
        Me.chkEnableMenu.AutoSize = True
        Me.chkEnableMenu.BackColor = System.Drawing.Color.Transparent
        Me.chkEnableMenu.Location = New System.Drawing.Point(315, 163)
        Me.chkEnableMenu.Name = "chkEnableMenu"
        Me.chkEnableMenu.Size = New System.Drawing.Size(181, 17)
        Me.chkEnableMenu.TabIndex = 28
        Me.chkEnableMenu.Text = "Enable right-click menu in games"
        Me.chkEnableMenu.UseVisualStyleBackColor = False
        '
        'chkAllowFonts
        '
        Me.chkAllowFonts.AutoSize = True
        Me.chkAllowFonts.BackColor = System.Drawing.Color.Transparent
        Me.chkAllowFonts.Location = New System.Drawing.Point(35, 163)
        Me.chkAllowFonts.Name = "chkAllowFonts"
        Me.chkAllowFonts.Size = New System.Drawing.Size(214, 17)
        Me.chkAllowFonts.TabIndex = 27
        Me.chkAllowFonts.Text = "Allow text fonts to be modified by games"
        Me.chkAllowFonts.UseVisualStyleBackColor = False
        '
        'tabAdvanced
        '
        Me.tabAdvanced.BackColor = System.Drawing.SystemColors.Control
        Me.tabAdvanced.Controls.Add(Me.UltraGroupBox2)
        Me.tabAdvanced.Location = New System.Drawing.Point(4, 22)
        Me.tabAdvanced.Name = "tabAdvanced"
        Me.tabAdvanced.Size = New System.Drawing.Size(520, 368)
        Me.tabAdvanced.TabIndex = 1
        Me.tabAdvanced.Text = "Advanced"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.chkSoundSoundPlayer)
        Me.UltraGroupBox2.Controls.Add(Me.chkSoundDirectX)
        Me.UltraGroupBox2.Controls.Add(Me.chkSoundWinMM)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(11, 12)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(158, 108)
        Me.UltraGroupBox2.TabIndex = 1
        Me.UltraGroupBox2.TabStop = False
        Me.UltraGroupBox2.Text = "Enabled Sound Interfaces"
        '
        'chkSoundSoundPlayer
        '
        Me.chkSoundSoundPlayer.AutoSize = True
        Me.chkSoundSoundPlayer.BackColor = System.Drawing.Color.Transparent
        Me.chkSoundSoundPlayer.Location = New System.Drawing.Point(20, 76)
        Me.chkSoundSoundPlayer.Name = "chkSoundSoundPlayer"
        Me.chkSoundSoundPlayer.Size = New System.Drawing.Size(86, 17)
        Me.chkSoundSoundPlayer.TabIndex = 12
        Me.chkSoundSoundPlayer.Text = "SoundPlayer"
        Me.chkSoundSoundPlayer.UseVisualStyleBackColor = False
        '
        'chkSoundDirectX
        '
        Me.chkSoundDirectX.AutoSize = True
        Me.chkSoundDirectX.BackColor = System.Drawing.Color.Transparent
        Me.chkSoundDirectX.Location = New System.Drawing.Point(20, 53)
        Me.chkSoundDirectX.Name = "chkSoundDirectX"
        Me.chkSoundDirectX.Size = New System.Drawing.Size(61, 17)
        Me.chkSoundDirectX.TabIndex = 11
        Me.chkSoundDirectX.Text = "DirectX"
        Me.chkSoundDirectX.UseVisualStyleBackColor = False
        '
        'chkSoundWinMM
        '
        Me.chkSoundWinMM.AutoSize = True
        Me.chkSoundWinMM.BackColor = System.Drawing.Color.Transparent
        Me.chkSoundWinMM.Location = New System.Drawing.Point(20, 30)
        Me.chkSoundWinMM.Name = "chkSoundWinMM"
        Me.chkSoundWinMM.Size = New System.Drawing.Size(63, 17)
        Me.chkSoundWinMM.TabIndex = 10
        Me.chkSoundWinMM.Text = "WinMM"
        Me.chkSoundWinMM.UseVisualStyleBackColor = False
        '
        'frmOptionsRunner
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(528, 442)
        Me.Controls.Add(Me.tabsOptions)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.MinimumSize = New System.Drawing.Size(544, 458)
        Me.Name = "frmOptionsRunner"
        Me.ShowInTaskbar = False
        Me.Text = "Options"
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.nudMargin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsOptions.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        Me.tabGeneral.PerformLayout()
        Me.tabAdvanced.ResumeLayout(False)
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabGeneral As System.Windows.Forms.TabPage
    Friend WithEvents chkLocationNames As System.Windows.Forms.CheckBox
    Friend WithEvents UltraGroupBox1 As GroupBox
    Friend WithEvents lblInputColour As Label
    Friend WithEvents pnlInputColour As System.Windows.Forms.Panel
    Friend WithEvents lblBackgroundColour As Label
    Friend WithEvents lblOutputColour As Label
    Friend WithEvents pnlBackgroundColour As System.Windows.Forms.Panel
    Friend WithEvents pnlOutputColour As System.Windows.Forms.Panel
    Friend WithEvents btnResetColours As Button
    Friend WithEvents chkSound As System.Windows.Forms.CheckBox
    Friend WithEvents chkGraphics As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseMyFont As System.Windows.Forms.CheckBox
    Friend WithEvents btnSetFont As System.Windows.Forms.Button
    Private WithEvents txtFont As System.Windows.Forms.TextBox
    Friend WithEvents fd As System.Windows.Forms.FontDialog
    Friend WithEvents lblLinkColour As Label
    Friend WithEvents pnlLinkColour As System.Windows.Forms.Panel
    Friend WithEvents chkAllowColours As System.Windows.Forms.CheckBox
    Friend WithEvents chkDisplayLinks As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableMenu As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllowFonts As System.Windows.Forms.CheckBox
    Friend WithEvents tabAdvanced As System.Windows.Forms.TabPage
    Friend WithEvents UltraGroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSoundSoundPlayer As System.Windows.Forms.CheckBox
    Friend WithEvents chkSoundDirectX As System.Windows.Forms.CheckBox
    Friend WithEvents chkSoundWinMM As System.Windows.Forms.CheckBox

End Class