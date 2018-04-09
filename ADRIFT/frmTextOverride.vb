Public Class frmTextOverride
    Inherits System.Windows.Forms.Form

    Private cALR As clsALR
    Friend WithEvents txtNew As ADRIFT.GenTextbox
    Friend WithEvents txtOld As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Private bChanged As Boolean


    Public Property Changed() As Boolean
        Get
            Return bChanged
        End Get
        Set(ByVal Value As Boolean)
            bChanged = Value
            If bChanged Then
                btnApply.Enabled = True
            Else
                btnApply.Enabled = False
            End If
        End Set
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal ALR As clsALR)
        MyBase.New()

        ' Check that this window isn't already open
        For Each w As Form In OpenForms
            If TypeOf w Is frmTextOverride Then
                If CType(w, frmTextOverride).cALR.Key = ALR.Key AndAlso ALR.Key IsNot Nothing Then
                    w.BringToFront()
                    w.Focus()
                    Exit Sub
                End If
            End If
        Next

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoadForm(ALR)

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
    Friend WithEvents btnApply As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents lblNew As Infragistics.Win.Misc.UltraLabel
    Private WithEvents lblOriginal As Infragistics.Win.Misc.UltraLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnApply = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.lblNew = New Infragistics.Win.Misc.UltraLabel()
        Me.lblOriginal = New Infragistics.Win.Misc.UltraLabel()
        Me.txtOld = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtNew = New ADRIFT.GenTextbox()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOld, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(416, 324)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(88, 32)
        Me.btnApply.TabIndex = 15
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(320, 324)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(224, 324)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "OK"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 318)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(520, 48)
        Me.UltraStatusBar1.TabIndex = 12
        '
        'lblNew
        '
        Me.lblNew.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblNew.Location = New System.Drawing.Point(12, 152)
        Me.lblNew.Name = "lblNew"
        Me.lblNew.Size = New System.Drawing.Size(160, 16)
        Me.lblNew.TabIndex = 17
        Me.lblNew.Text = "Replacement text:"
        '
        'lblOriginal
        '
        Me.lblOriginal.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblOriginal.Location = New System.Drawing.Point(12, 8)
        Me.lblOriginal.Name = "lblOriginal"
        Me.lblOriginal.Size = New System.Drawing.Size(91, 16)
        Me.lblOriginal.TabIndex = 16
        Me.lblOriginal.Text = "Original text:"
        '
        'txtOld
        '
        Me.txtOld.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOld.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOld.Location = New System.Drawing.Point(12, 30)
        Me.txtOld.Multiline = True
        Me.txtOld.Name = "txtOld"
        Me.txtOld.Size = New System.Drawing.Size(496, 104)
        Me.txtOld.TabIndex = 19
        '
        'txtNew
        '
        Me.txtNew.AllowAlternateDescriptions = True
        Me.txtNew.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNew.BackColor = System.Drawing.Color.Transparent
        Me.txtNew.FirstTabHasRestrictions = False
        Me.txtNew.Location = New System.Drawing.Point(12, 174)
        Me.txtNew.Name = "txtNew"
        Me.txtNew.sCommand = Nothing
        Me.txtNew.Size = New System.Drawing.Size(496, 130)
        Me.txtNew.TabIndex = 18
        '
        'frmTextOverride
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(520, 366)
        Me.Controls.Add(Me.txtOld)
        Me.Controls.Add(Me.txtNew)
        Me.Controls.Add(Me.lblNew)
        Me.Controls.Add(Me.lblOriginal)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(536, 402)
        Me.Name = "frmTextOverride"
        Me.Text = "Text Override -"
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOld, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub LoadForm(ByRef cALR As clsALR)

        Me.cALR = cALR


        With cALR
            Text = "Text Override"
            If SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0")) Then Text &= " [" & .Key & "]"
            If .OldText = "" Then Text = "New Text Override"

            txtOld.Text = .OldText
            txtNew.Description = .NewText.Copy

        End With

        Me.Show()
        Changed = False

        OpenForms.Add(Me)

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ApplyALR()
        CloseALR(Me)
    End Sub


    Private Sub ApplyALR()

        With cALR            
            .OldText = txtOld.Text
            .NewText = txtNew.Description.Copy

            If .Key = "" Then
                .Key = .GetNewKey ' Adventure.GetNewKey("Override")
                Adventure.htblALRs.Add(cALR, .Key)
            End If
            .LastUpdated = Now
            .IsLibrary = False

            UpdateListItem(.Key, .OldText.ToString)
        End With

        Adventure.Changed = True

    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then ApplyALR()
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        CloseALR(Me)

    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ApplyALR()
        Changed = False
    End Sub

    Private Sub StuffChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOld.TextChanged, txtNew.Changed
        Changed = True
    End Sub


    Private Sub frmTextOverride_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OpenForms.Remove(Me)
    End Sub


    Private Sub frmHint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = Icon.FromHandle(My.Resources.imgALR16.GetHicon)
        GetFormPosition(Me)
    End Sub

    Private Sub frmTextOverride_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If txtOld.Text = "" Then
            txtOld.Focus()
        Else
            'txtNew.rtxtSource.SelectionStart = txtNew.rtxtSource.TextLength
            txtNew.rtxtSource.EditInfo.PerformAction(Infragistics.Win.FormattedLinkLabel.FormattedLinkEditorAction.DocumentEnd)
            txtNew.rtxtSource.Focus()
        End If
    End Sub

    Private Sub frmTextOverride_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        ShowHelp(Me, "TextOverrides")
    End Sub

End Class
