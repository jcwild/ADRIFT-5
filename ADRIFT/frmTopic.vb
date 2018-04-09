Public Class frmTopic
    Inherits System.Windows.Forms.Form

    Private cTopic As clsTopic
    Private htblTopics As TopicHashTable
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Private bChanged As Boolean

    Public Property Changed() As Boolean
        Get
            Return bChanged
        End Get
        Set(ByVal Value As Boolean)
            bChanged = Value
            'If bChanged Then
            '    btnApply.Enabled = True
            'Else
            '    btnApply.Enabled = False
            'End If
        End Set
    End Property

#Region " Windows Form Designer generated code "

    Friend Sub New(ByVal Topic As clsTopic, ByVal htblTopics As TopicHashTable)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoadForm(Topic, htblTopics)

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

    'Me.RestrictDetails1 = New RestrictDetails
    'Me.Actions1 = New Actions

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents tabsMain As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents RestrictDetails1 As ADRIFT.RestrictDetails
    Friend WithEvents lblSummary As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblKeywords As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblConversation As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtConversation As ADRIFT.GenTextbox
    Friend WithEvents txtKeywords As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents grpType As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkIntro As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkFarewell As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkCommand As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkTell As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkAsk As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents Actions1 As ADRIFT.Actions
    Friend WithEvents chkStay As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents txtSummary As Infragistics.Win.UltraWinEditors.UltraTextEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTopic))
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.grpType = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chkIntro = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkFarewell = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkCommand = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkTell = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkAsk = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.txtKeywords = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtSummary = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtConversation = New ADRIFT.GenTextbox()
        Me.lblConversation = New Infragistics.Win.Misc.UltraLabel()
        Me.lblKeywords = New Infragistics.Win.Misc.UltraLabel()
        Me.lblSummary = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.RestrictDetails1 = New ADRIFT.RestrictDetails()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.chkStay = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.Actions1 = New ADRIFT.Actions()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.tabsMain = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.grpType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpType.SuspendLayout()
        CType(Me.chkIntro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFarewell, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCommand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTell, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAsk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKeywords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.chkStay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabsMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.grpType)
        Me.UltraTabPageControl1.Controls.Add(Me.txtKeywords)
        Me.UltraTabPageControl1.Controls.Add(Me.txtSummary)
        Me.UltraTabPageControl1.Controls.Add(Me.txtConversation)
        Me.UltraTabPageControl1.Controls.Add(Me.lblConversation)
        Me.UltraTabPageControl1.Controls.Add(Me.lblKeywords)
        Me.UltraTabPageControl1.Controls.Add(Me.lblSummary)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(516, 414)
        '
        'grpType
        '
        Me.grpType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpType.Controls.Add(Me.chkIntro)
        Me.grpType.Controls.Add(Me.chkFarewell)
        Me.grpType.Controls.Add(Me.chkCommand)
        Me.grpType.Controls.Add(Me.chkTell)
        Me.grpType.Controls.Add(Me.chkAsk)
        Me.grpType.Location = New System.Drawing.Point(8, 57)
        Me.grpType.Name = "grpType"
        Me.grpType.Size = New System.Drawing.Size(494, 52)
        Me.grpType.TabIndex = 13
        Me.grpType.Text = "Type of topic"
        Me.grpType.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'chkIntro
        '
        Me.chkIntro.BackColor = System.Drawing.Color.Transparent
        Me.chkIntro.BackColorInternal = System.Drawing.Color.Transparent
        Me.HelpProvider1.SetHelpString(Me.chkIntro, resources.GetString("chkIntro.HelpString"))
        Me.chkIntro.Location = New System.Drawing.Point(26, 25)
        Me.chkIntro.Name = "chkIntro"
        Me.HelpProvider1.SetShowHelp(Me.chkIntro, True)
        Me.chkIntro.Size = New System.Drawing.Size(89, 20)
        Me.chkIntro.TabIndex = 12
        Me.chkIntro.Text = "Introduction"
        '
        'chkFarewell
        '
        Me.chkFarewell.BackColor = System.Drawing.Color.Transparent
        Me.chkFarewell.BackColorInternal = System.Drawing.Color.Transparent
        Me.HelpProvider1.SetHelpString(Me.chkFarewell, resources.GetString("chkFarewell.HelpString"))
        Me.chkFarewell.Location = New System.Drawing.Point(404, 25)
        Me.chkFarewell.Name = "chkFarewell"
        Me.HelpProvider1.SetShowHelp(Me.chkFarewell, True)
        Me.chkFarewell.Size = New System.Drawing.Size(67, 20)
        Me.chkFarewell.TabIndex = 16
        Me.chkFarewell.Text = "Farewell"
        '
        'chkCommand
        '
        Me.chkCommand.BackColor = System.Drawing.Color.Transparent
        Me.chkCommand.BackColorInternal = System.Drawing.Color.Transparent
        Me.HelpProvider1.SetHelpString(Me.chkCommand, "If a topic has a general command, the command must be matched in the same way as " & _
        "normal task commands.")
        Me.chkCommand.Location = New System.Drawing.Point(262, 25)
        Me.chkCommand.Name = "chkCommand"
        Me.HelpProvider1.SetShowHelp(Me.chkCommand, True)
        Me.chkCommand.Size = New System.Drawing.Size(117, 20)
        Me.chkCommand.TabIndex = 15
        Me.chkCommand.Text = "General Command"
        '
        'chkTell
        '
        Me.chkTell.BackColor = System.Drawing.Color.Transparent
        Me.chkTell.BackColorInternal = System.Drawing.Color.Transparent
        Me.HelpProvider1.SetHelpString(Me.chkTell, "If a topic is marked as a Tell topic, you can execute Ask commands, matching on a" & _
        "ny of the given keywords.")
        Me.chkTell.Location = New System.Drawing.Point(196, 25)
        Me.chkTell.Name = "chkTell"
        Me.HelpProvider1.SetShowHelp(Me.chkTell, True)
        Me.chkTell.Size = New System.Drawing.Size(46, 20)
        Me.chkTell.TabIndex = 14
        Me.chkTell.Text = "Tell"
        '
        'chkAsk
        '
        Me.chkAsk.BackColor = System.Drawing.Color.Transparent
        Me.chkAsk.BackColorInternal = System.Drawing.Color.Transparent
        Me.HelpProvider1.SetHelpString(Me.chkAsk, "If a topic is marked as an Ask topic, you can execute Ask commands, matching on a" & _
        "ny of the given keywords.")
        Me.chkAsk.Location = New System.Drawing.Point(129, 25)
        Me.chkAsk.Name = "chkAsk"
        Me.HelpProvider1.SetShowHelp(Me.chkAsk, True)
        Me.chkAsk.Size = New System.Drawing.Size(46, 20)
        Me.chkAsk.TabIndex = 13
        Me.chkAsk.Text = "Ask"
        '
        'txtKeywords
        '
        Me.txtKeywords.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKeywords.Enabled = False
        Me.txtKeywords.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKeywords.Location = New System.Drawing.Point(8, 137)
        Me.txtKeywords.Name = "txtKeywords"
        Me.txtKeywords.Size = New System.Drawing.Size(494, 24)
        Me.txtKeywords.TabIndex = 6
        '
        'txtSummary
        '
        Me.txtSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSummary.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSummary.Location = New System.Drawing.Point(8, 24)
        Me.txtSummary.Name = "txtSummary"
        Me.txtSummary.Size = New System.Drawing.Size(494, 24)
        Me.txtSummary.TabIndex = 5
        '
        'txtConversation
        '
        Me.txtConversation.AllowAlternateDescriptions = True
        Me.txtConversation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConversation.BackColor = System.Drawing.Color.Transparent
        Me.txtConversation.FirstTabHasRestrictions = False
        Me.txtConversation.Location = New System.Drawing.Point(8, 188)
        Me.txtConversation.Name = "txtConversation"
        Me.txtConversation.sCommand = Nothing
        Me.txtConversation.Size = New System.Drawing.Size(496, 218)
        Me.txtConversation.TabIndex = 4
        '
        'lblConversation
        '
        Me.lblConversation.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblConversation.Location = New System.Drawing.Point(8, 169)
        Me.lblConversation.Name = "lblConversation"
        Me.lblConversation.Size = New System.Drawing.Size(82, 16)
        Me.lblConversation.TabIndex = 2
        Me.lblConversation.Text = "Conversation:"
        '
        'lblKeywords
        '
        Me.lblKeywords.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblKeywords.Location = New System.Drawing.Point(8, 119)
        Me.lblKeywords.Name = "lblKeywords"
        Me.lblKeywords.Size = New System.Drawing.Size(64, 16)
        Me.lblKeywords.TabIndex = 1
        Me.lblKeywords.Text = "Keywords:"
        '
        'lblSummary
        '
        Me.lblSummary.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblSummary.Location = New System.Drawing.Point(8, 8)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(56, 16)
        Me.lblSummary.TabIndex = 0
        Me.lblSummary.Text = "Summary:"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.RestrictDetails1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(516, 414)
        '
        'RestrictDetails1
        '
        Me.RestrictDetails1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictDetails1.BackColor = System.Drawing.Color.Transparent
        Me.RestrictDetails1.Location = New System.Drawing.Point(16, 8)
        Me.RestrictDetails1.Name = "RestrictDetails1"
        Me.RestrictDetails1.Size = New System.Drawing.Size(496, 398)
        Me.RestrictDetails1.TabIndex = 0
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.chkStay)
        Me.UltraTabPageControl3.Controls.Add(Me.Actions1)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(516, 414)
        '
        'chkStay
        '
        Me.chkStay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkStay.BackColor = System.Drawing.Color.Transparent
        Me.chkStay.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkStay.Enabled = False
        Me.chkStay.Location = New System.Drawing.Point(388, 377)
        Me.chkStay.Name = "chkStay"
        Me.chkStay.Size = New System.Drawing.Size(127, 33)
        Me.chkStay.TabIndex = 14
        Me.chkStay.Text = "Stay in this conversation node"
        '
        'Actions1
        '
        Me.Actions1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Actions1.BackColor = System.Drawing.Color.Transparent
        Me.Actions1.Location = New System.Drawing.Point(16, 8)
        Me.Actions1.Name = "Actions1"
        Me.Actions1.Size = New System.Drawing.Size(496, 398)
        Me.Actions1.TabIndex = 15
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(416, 443)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(320, 443)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "OK"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 437)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(520, 48)
        Me.UltraStatusBar1.TabIndex = 12
        '
        'tabsMain
        '
        Me.tabsMain.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabsMain.Controls.Add(Me.UltraTabPageControl1)
        Me.tabsMain.Controls.Add(Me.UltraTabPageControl2)
        Me.tabsMain.Controls.Add(Me.UltraTabPageControl3)
        Me.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsMain.Location = New System.Drawing.Point(0, 0)
        Me.tabsMain.Name = "tabsMain"
        Me.tabsMain.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabsMain.Size = New System.Drawing.Size(520, 437)
        Me.tabsMain.TabIndex = 16
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Descriptions"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Restrictions"
        UltraTab3.TabPage = Me.UltraTabPageControl3
        UltraTab3.Text = "Actions"
        Me.tabsMain.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3})
        Me.tabsMain.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.VisualStudio2005
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(516, 414)
        '
        'frmTopic
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(520, 485)
        Me.Controls.Add(Me.tabsMain)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(536, 521)
        Me.Name = "frmTopic"
        Me.Text = "Conversation Topic - "
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.grpType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpType.ResumeLayout(False)
        CType(Me.chkIntro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFarewell, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCommand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTell, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAsk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKeywords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl3.ResumeLayout(False)
        CType(Me.chkStay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabsMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub LoadForm(ByRef cTopic As clsTopic, ByRef htblTopics As TopicHashTable)

        Me.cTopic = cTopic
        Me.htblTopics = htblTopics

        With cTopic
            Text = "Conversation Topic - " & .Summary
            If SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0")) Then Text &= " [" & .Key & "]"
            If .Summary = "" Then Text = "New Conversation Topic"

            txtSummary.Text = .Summary
            txtKeywords.Text = .Keywords
            txtConversation.Description = .oConversation

            chkAsk.Checked = .bAsk
            chkCommand.Checked = .bCommand
            chkFarewell.Checked = .bFarewell
            chkIntro.Checked = .bIntroduction
            chkStay.Checked = .bStayInNode
            chkTell.Checked = .bTell

            RestrictDetails1.LoadRestrictions(.arlRestrictions.Copy)
            Actions1.LoadActions(.arlActions.Copy)

            chkStay.Enabled = .ParentKey <> ""
        End With

        Changed = False
        Me.ShowDialog()

    End Sub


    Private Function GetNewKey() As String

        Dim iNum As Integer = 1

        While htblTopics.ContainsKey("Topic" & iNum)
            iNum += 1
        End While

        Return "Topic" & iNum

    End Function


    Private Sub ApplyTopic()

        With cTopic
            .Summary = txtSummary.Text
            .Keywords = txtKeywords.Text
            .oConversation = txtConversation.Description.Copy

            .arlRestrictions = Me.RestrictDetails1.arlRestrictions.Copy
            .arlActions = Me.Actions1.arlActions.Copy

            .bAsk = chkAsk.Checked
            .bCommand = chkCommand.Checked
            .bFarewell = chkFarewell.Checked
            .bIntroduction = chkIntro.Checked
            .bStayInNode = chkStay.Checked
            .bTell = chkTell.Checked

            If txtSummary.Text = "" Then
                If .bAsk AndAlso .bTell Then
                    .Summary = "Ask or Tell about " & .Keywords
                ElseIf .bAsk Then
                    .Summary = "Ask about " & .Keywords
                ElseIf .bTell Then
                    .Summary = "Ask about " & .Keywords
                End If
                If .bIntroduction Then
                    If Not .bCommand Then
                        .Summary = "Implicit introduction"
                    Else
                        .Summary = "Explicit introduction"
                    End If
                End If
            End If

            If .Key = "" Then
                .Key = GetNewKey()
                'Adventure.htblHints.Add(cHint, .Key)
            End If

            'UpdateListItem(.Key, .Question)
        End With

    End Sub


    Private Sub frmTopic_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetFormPosition(Me)
    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ApplyTopic()
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub


    Private Enum BoolChange
        NoChange
        [False]
        [True]
    End Enum

    Private Sub chkAsk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAsk.CheckedChanged, chkCommand.CheckedChanged, chkFarewell.CheckedChanged, chkIntro.CheckedChanged, chkTell.CheckedChanged

        If chkCommand.Checked Then
            lblKeywords.Text = "Command:"
        Else
            lblKeywords.Text = "Keywords:"
        End If

        If chkAsk.Checked OrElse chkCommand.Checked OrElse chkTell.Checked Then
            lblKeywords.Enabled = True
            txtKeywords.Enabled = True
        Else
            lblKeywords.Enabled = False
            txtKeywords.Enabled = False
        End If

        Dim bAsk As BoolChange = BoolChange.NoChange
        Dim bCommand As BoolChange = BoolChange.NoChange
        Dim bFarewell As BoolChange = BoolChange.NoChange
        Dim bIntro As BoolChange = BoolChange.NoChange
        Dim bTell As BoolChange = BoolChange.NoChange
        Select Case True
            Case sender Is chkIntro
                If chkIntro.Checked Then
                    bFarewell = BoolChange.False
                    bAsk = BoolChange.False
                    bTell = BoolChange.False
                Else
                    If Not chkAsk.Checked AndAlso Not chkTell.Checked Then bFarewell = BoolChange.True
                    If Not chkCommand.Checked AndAlso Not chkFarewell.Checked Then
                        bAsk = BoolChange.True
                        bTell = BoolChange.True
                    End If
                End If
            Case sender Is chkAsk
                If chkAsk.Checked Then
                    bCommand = BoolChange.False
                    bIntro = BoolChange.False
                    bFarewell = BoolChange.False
                Else
                    If Not chkTell.Checked Then bCommand = BoolChange.True
                    If Not chkTell.Checked OrElse chkFarewell.Checked Then
                        bIntro = BoolChange.True
                        bFarewell = BoolChange.True
                    End If
                End If
            Case sender Is chkTell
                If chkTell.Checked Then
                    bCommand = BoolChange.False
                    bIntro = BoolChange.False
                    bFarewell = BoolChange.False
                Else
                    If Not chkAsk.Checked Then bCommand = BoolChange.True
                    If Not chkAsk.Checked OrElse chkFarewell.Checked Then
                        bIntro = BoolChange.True
                        bFarewell = BoolChange.True
                    End If
                End If
            Case sender Is chkCommand
                If chkCommand.Checked Then
                    bAsk = BoolChange.False
                    bTell = BoolChange.False
                Else
                    If Not chkIntro.Checked AndAlso Not chkFarewell.Checked Then
                        bAsk = BoolChange.True
                        bTell = BoolChange.True
                    End If
                End If
            Case sender Is chkFarewell
                If chkFarewell.Checked Then
                    bIntro = BoolChange.False
                    bAsk = BoolChange.False
                    bTell = BoolChange.False
                Else
                    If Not chkAsk.Checked OrElse chkTell.Checked Then bIntro = BoolChange.True
                    If Not chkIntro.Checked AndAlso Not chkCommand.Checked Then
                        bAsk = BoolChange.True
                        bTell = BoolChange.True
                    End If
                End If
        End Select


        If bAsk <> BoolChange.NoChange Then chkAsk.Enabled = CBool(IIf(bAsk = BoolChange.True, True, False))
        If bCommand <> BoolChange.NoChange Then chkCommand.Enabled = CBool(IIf(bCommand = BoolChange.True, True, False))
        If bFarewell <> BoolChange.NoChange Then chkFarewell.Enabled = CBool(IIf(bFarewell = BoolChange.True, True, False))
        If bIntro <> BoolChange.NoChange Then chkIntro.Enabled = CBool(IIf(bIntro = BoolChange.True, True, False))
        If bTell <> BoolChange.NoChange Then chkTell.Enabled = CBool(IIf(bTell = BoolChange.True, True, False))

    End Sub

    Private Sub frmTopic_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If txtSummary.Text = "" Then
            txtSummary.Focus()
        Else
            'txtConversation.rtxtSource.SelectionStart = txtConversation.rtxtSource.TextLength
            txtConversation.rtxtSource.EditInfo.PerformAction(Infragistics.Win.FormattedLinkLabel.FormattedLinkEditorAction.DocumentEnd)
            txtConversation.rtxtSource.Focus()
        End If
    End Sub

End Class
