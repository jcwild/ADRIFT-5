Imports Infragistics.Win.UltraWinTree


Public Class frmCharacter
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public bKeepOpen As Boolean = False

    Public Sub New(ByRef ch As clsCharacter, ByVal bShow As Boolean)
        MyBase.New()

        ' Check that this window isn't already open
        For Each w As Form In OpenForms
            If TypeOf w Is frmCharacter Then
                If CType(w, frmCharacter).cCharacter.Key = ch.Key AndAlso ch.Key IsNot Nothing Then
                    w.BringToFront()
                    w.Focus()
                    Exit Sub
                End If
            End If
        Next

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoadForm(ch, bShow)
        bKeepOpen = Not bShow

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
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents btnApply As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents tabsCharacters As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Properties1 As ADRIFT.Properties
    Friend WithEvents txtDescription As ADRIFT.GenTextbox
    Friend WithEvents lblNouns As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents lstWalks As System.Windows.Forms.ListBox
    Friend WithEvents btnAddWalk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnRemoveWalk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnEditWalk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents treeTopics As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents btnAddTopic As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnRemoveTopic As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnEditTopic As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtPrefix As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtArticle As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cmbShortDescriptions As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblPrefix As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblArticle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtProperName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCharacter))
        Dim Override1 As Infragistics.Win.UltraWinTree.Override = New Infragistics.Win.UltraWinTree.Override()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.txtProperName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtPrefix = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtArticle = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.cmbShortDescriptions = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblPrefix = New Infragistics.Win.Misc.UltraLabel()
        Me.lblArticle = New Infragistics.Win.Misc.UltraLabel()
        Me.txtDescription = New ADRIFT.GenTextbox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblNouns = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Properties1 = New ADRIFT.Properties()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btnAddWalk = New Infragistics.Win.Misc.UltraButton()
        Me.btnRemoveWalk = New Infragistics.Win.Misc.UltraButton()
        Me.btnEditWalk = New Infragistics.Win.Misc.UltraButton()
        Me.lstWalks = New System.Windows.Forms.ListBox()
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btnAddTopic = New Infragistics.Win.Misc.UltraButton()
        Me.btnRemoveTopic = New Infragistics.Win.Misc.UltraButton()
        Me.btnEditTopic = New Infragistics.Win.Misc.UltraButton()
        Me.treeTopics = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.btnApply = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.tabsCharacters = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.txtProperName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrefix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtArticle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbShortDescriptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        Me.UltraTabPageControl5.SuspendLayout()
        CType(Me.treeTopics, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabsCharacters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsCharacters.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.txtProperName)
        Me.UltraTabPageControl1.Controls.Add(Me.txtPrefix)
        Me.UltraTabPageControl1.Controls.Add(Me.txtArticle)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbShortDescriptions)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl1.Controls.Add(Me.lblPrefix)
        Me.UltraTabPageControl1.Controls.Add(Me.lblArticle)
        Me.UltraTabPageControl1.Controls.Add(Me.txtDescription)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl1.Controls.Add(Me.lblNouns)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(548, 396)
        '
        'txtProperName
        '
        Me.txtProperName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProperName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProvider1.SetHelpString(Me.txtProperName, "This is the character's actual name")
        Me.txtProperName.Location = New System.Drawing.Point(9, 24)
        Me.txtProperName.Name = "txtProperName"
        Me.HelpProvider1.SetShowHelp(Me.txtProperName, True)
        Me.txtProperName.Size = New System.Drawing.Size(533, 26)
        Me.txtProperName.TabIndex = 0
        Me.txtProperName.Text = "old"
        '
        'txtPrefix
        '
        Me.txtPrefix.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProvider1.SetHelpString(Me.txtPrefix, resources.GetString("txtPrefix.HelpString"))
        Me.txtPrefix.Location = New System.Drawing.Point(111, 72)
        Me.txtPrefix.Name = "txtPrefix"
        Me.HelpProvider1.SetShowHelp(Me.txtPrefix, True)
        Me.txtPrefix.Size = New System.Drawing.Size(208, 26)
        Me.txtPrefix.TabIndex = 2
        Me.txtPrefix.Text = "old"
        '
        'txtArticle
        '
        Me.txtArticle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProvider1.SetHelpString(Me.txtArticle, resources.GetString("txtArticle.HelpString"))
        Me.txtArticle.Location = New System.Drawing.Point(9, 72)
        Me.txtArticle.Name = "txtArticle"
        Me.HelpProvider1.SetShowHelp(Me.txtArticle, True)
        Me.txtArticle.Size = New System.Drawing.Size(96, 26)
        Me.txtArticle.TabIndex = 1
        Me.txtArticle.Text = "an"
        '
        'cmbShortDescriptions
        '
        Me.cmbShortDescriptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbShortDescriptions.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbShortDescriptions.Location = New System.Drawing.Point(325, 72)
        Me.cmbShortDescriptions.Name = "cmbShortDescriptions"
        Me.cmbShortDescriptions.Size = New System.Drawing.Size(217, 26)
        Me.cmbShortDescriptions.TabIndex = 3
        '
        'UltraLabel2
        '
        Me.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent
        Me.HelpProvider1.SetHelpString(Me.UltraLabel2, "The short descriptor, or noun, is what the character is, for example, ""man"", ""lad" & _
        "y"", ""dog"" etc.")
        Me.UltraLabel2.Location = New System.Drawing.Point(325, 56)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.HelpProvider1.SetShowHelp(Me.UltraLabel2, True)
        Me.UltraLabel2.Size = New System.Drawing.Size(138, 16)
        Me.UltraLabel2.TabIndex = 25
        Me.UltraLabel2.Text = "Descriptor/Noun:"
        '
        'lblPrefix
        '
        Me.lblPrefix.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblPrefix.Location = New System.Drawing.Point(111, 56)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(88, 16)
        Me.lblPrefix.TabIndex = 24
        Me.lblPrefix.Text = "Prefix/Adjective:"
        '
        'lblArticle
        '
        Me.lblArticle.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblArticle.Location = New System.Drawing.Point(10, 56)
        Me.lblArticle.Name = "lblArticle"
        Me.lblArticle.Size = New System.Drawing.Size(100, 23)
        Me.lblArticle.TabIndex = 23
        Me.lblArticle.Text = "Article:"
        '
        'txtDescription
        '
        Me.txtDescription.AllowAlternateDescriptions = True
        Me.txtDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDescription.FirstTabHasRestrictions = False
        Me.txtDescription.Location = New System.Drawing.Point(8, 119)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.sCommand = Nothing
        Me.txtDescription.Size = New System.Drawing.Size(536, 262)
        Me.txtDescription.TabIndex = 4
        '
        'UltraLabel1
        '
        Me.UltraLabel1.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel1.Location = New System.Drawing.Point(8, 104)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel1.TabIndex = 19
        Me.UltraLabel1.Text = "Description:"
        '
        'lblNouns
        '
        Me.lblNouns.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblNouns.Location = New System.Drawing.Point(8, 8)
        Me.lblNouns.Name = "lblNouns"
        Me.lblNouns.Size = New System.Drawing.Size(88, 16)
        Me.lblNouns.TabIndex = 18
        Me.lblNouns.Text = "Proper Name:"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.Properties1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(548, 396)
        '
        'Properties1
        '
        Me.Properties1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Properties1.BackColor = System.Drawing.Color.Transparent
        Me.Properties1.Location = New System.Drawing.Point(8, 8)
        Me.Properties1.Name = "Properties1"
        Me.Properties1.Size = New System.Drawing.Size(536, 384)
        Me.Properties1.TabIndex = 0
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.btnAddWalk)
        Me.UltraTabPageControl3.Controls.Add(Me.btnRemoveWalk)
        Me.UltraTabPageControl3.Controls.Add(Me.btnEditWalk)
        Me.UltraTabPageControl3.Controls.Add(Me.lstWalks)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(548, 396)
        '
        'btnAddWalk
        '
        Me.btnAddWalk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddWalk.Location = New System.Drawing.Point(188, 358)
        Me.btnAddWalk.Name = "btnAddWalk"
        Me.btnAddWalk.Size = New System.Drawing.Size(112, 21)
        Me.btnAddWalk.TabIndex = 1
        Me.btnAddWalk.Text = "Add Walk"
        '
        'btnRemoveWalk
        '
        Me.btnRemoveWalk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveWalk.Enabled = False
        Me.btnRemoveWalk.Location = New System.Drawing.Point(424, 358)
        Me.btnRemoveWalk.Name = "btnRemoveWalk"
        Me.btnRemoveWalk.Size = New System.Drawing.Size(112, 21)
        Me.btnRemoveWalk.TabIndex = 3
        Me.btnRemoveWalk.Text = "Remove Walk"
        '
        'btnEditWalk
        '
        Me.btnEditWalk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditWalk.Enabled = False
        Me.btnEditWalk.Location = New System.Drawing.Point(306, 358)
        Me.btnEditWalk.Name = "btnEditWalk"
        Me.btnEditWalk.Size = New System.Drawing.Size(112, 21)
        Me.btnEditWalk.TabIndex = 2
        Me.btnEditWalk.Text = "Edit Walk"
        '
        'lstWalks
        '
        Me.lstWalks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstWalks.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstWalks.FormattingEnabled = True
        Me.lstWalks.IntegralHeight = False
        Me.lstWalks.ItemHeight = 18
        Me.lstWalks.Location = New System.Drawing.Point(11, 12)
        Me.lstWalks.Name = "lstWalks"
        Me.lstWalks.Size = New System.Drawing.Size(524, 340)
        Me.lstWalks.TabIndex = 0
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.btnAddTopic)
        Me.UltraTabPageControl5.Controls.Add(Me.btnRemoveTopic)
        Me.UltraTabPageControl5.Controls.Add(Me.btnEditTopic)
        Me.UltraTabPageControl5.Controls.Add(Me.treeTopics)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(548, 396)
        '
        'btnAddTopic
        '
        Me.btnAddTopic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddTopic.Location = New System.Drawing.Point(188, 358)
        Me.btnAddTopic.Name = "btnAddTopic"
        Me.btnAddTopic.Size = New System.Drawing.Size(112, 21)
        Me.btnAddTopic.TabIndex = 1
        Me.btnAddTopic.Text = "Add Topic"
        '
        'btnRemoveTopic
        '
        Me.btnRemoveTopic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveTopic.Enabled = False
        Me.btnRemoveTopic.Location = New System.Drawing.Point(424, 358)
        Me.btnRemoveTopic.Name = "btnRemoveTopic"
        Me.btnRemoveTopic.Size = New System.Drawing.Size(112, 21)
        Me.btnRemoveTopic.TabIndex = 3
        Me.btnRemoveTopic.Text = "Remove Topic"
        '
        'btnEditTopic
        '
        Me.btnEditTopic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditTopic.Enabled = False
        Me.btnEditTopic.Location = New System.Drawing.Point(306, 358)
        Me.btnEditTopic.Name = "btnEditTopic"
        Me.btnEditTopic.Size = New System.Drawing.Size(112, 21)
        Me.btnEditTopic.TabIndex = 2
        Me.btnEditTopic.Text = "Edit Topic"
        '
        'treeTopics
        '
        Me.treeTopics.AllowDrop = True
        Me.treeTopics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.treeTopics.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeTopics.Location = New System.Drawing.Point(11, 12)
        Me.treeTopics.Name = "treeTopics"
        Override1.NodeDoubleClickAction = Infragistics.Win.UltraWinTree.NodeDoubleClickAction.None
        Override1.Sort = Infragistics.Win.UltraWinTree.SortType.Ascending
        Me.treeTopics.Override = Override1
        Me.treeTopics.Size = New System.Drawing.Size(524, 340)
        Me.treeTopics.TabIndex = 0
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Enabled = False
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(548, 396)
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 422)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(552, 48)
        Me.UltraStatusBar1.TabIndex = 5
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(448, 432)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(88, 32)
        Me.btnApply.TabIndex = 3
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(352, 432)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(256, 432)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        '
        'tabsCharacters
        '
        Me.tabsCharacters.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabsCharacters.Controls.Add(Me.UltraTabPageControl1)
        Me.tabsCharacters.Controls.Add(Me.UltraTabPageControl2)
        Me.tabsCharacters.Controls.Add(Me.UltraTabPageControl3)
        Me.tabsCharacters.Controls.Add(Me.UltraTabPageControl5)
        Me.tabsCharacters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsCharacters.Location = New System.Drawing.Point(0, 0)
        Me.tabsCharacters.Name = "tabsCharacters"
        Me.tabsCharacters.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabsCharacters.Size = New System.Drawing.Size(552, 422)
        Me.tabsCharacters.TabIndex = 0
        UltraTab1.Key = "Description"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Description"
        UltraTab2.Key = "Properties"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Properties"
        UltraTab3.Key = "Movement"
        UltraTab3.TabPage = Me.UltraTabPageControl3
        UltraTab3.Text = "Movement"
        UltraTab5.Key = "Conversation"
        UltraTab5.TabPage = Me.UltraTabPageControl5
        UltraTab5.Text = "Conversation"
        Me.tabsCharacters.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3, UltraTab5})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(548, 396)
        '
        'frmCharacter
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(552, 470)
        Me.Controls.Add(Me.tabsCharacters)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(568, 506)
        Me.Name = "frmCharacter"
        Me.ShowInTaskbar = False
        Me.Text = "Character - "
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.txtProperName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrefix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtArticle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbShortDescriptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl5.ResumeLayout(False)
        CType(Me.treeTopics, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabsCharacters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsCharacters.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private cCharacter As clsCharacter
    Private bChanged As Boolean
    Private iSelectedIndex As Integer = 0
    Private bAllowChangeValue As Boolean = True
    Private htblTopics As TopicHashTable


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


    Private Sub LoadForm(ByRef cCharacter As clsCharacter, ByVal bShow As Boolean)

        Me.cCharacter = cCharacter


        With cCharacter
            Text = "Character - " & .Name
            If SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0")) Then Text &= "  [" & .Key & "]"
            If .Name = "" OrElse (.Name = "Anonymous" AndAlso .Key = "") Then Text = "New Character"

            If .CharacterType = clsCharacter.CharacterTypeEnum.Player Then
                Me.Icon = Icon.FromHandle(My.Resources.imgPlayer16.GetHicon)
            Else
                Me.Icon = Icon.FromHandle(My.Resources.imgCharacter16.GetHicon)
            End If

            txtDescription.Description = .Description.Copy
            txtArticle.Text = .Article
            txtPrefix.Text = .Prefix
            txtProperName.Text = .ProperName
            'cmbNames.Items.Add(.Name)
            For Each sName As String In .arlDescriptors
                cmbShortDescriptions.Items.Add(sName)
            Next
            If cmbShortDescriptions.Items.Count > 0 Then
                iSelectedIndex = 0
                cmbShortDescriptions.SelectedIndex = 0
            Else
                cmbShortDescriptions.Items.Add("")
            End If

            ' Pad out the local Object hashtable with unselected properties
            .ResetInherited()
            Dim htblProperties As PropertyHashTable = .htblProperties.Clone ' .GetPropertiesIncludingGroups.Clone
            For Each prop As clsProperty In Adventure.htblCharacterProperties.Values
                If Not htblProperties.ContainsKey(prop.Key) Then htblProperties.Add(prop.Copy)
            Next
            Me.Properties1.htblProperties = htblProperties
            Me.Properties1.OwnerKey = .Key
            Me.htblTopics = .htblTopics.Clone

            treeTopics.Nodes.Clear()
            For Each topic As clsTopic In htblTopics.Values
                Dim node As Infragistics.Win.UltraWinTree.UltraTreeNode = treeTopics.Nodes.Add(topic.Key, topic.Summary)
                TopicIcons(topic, node)
            Next
            For Each topic As clsTopic In htblTopics.Values
                If topic.ParentKey <> "" Then
                    treeTopics.GetNodeByKey(topic.Key).Reposition(treeTopics.GetNodeByKey(topic.ParentKey).Nodes)
                    treeTopics.GetNodeByKey(topic.ParentKey).ExpandAll()
                End If
            Next

            For Each walk As clsWalk In .arlWalks
                Dim lstItem As New ListBoxWalkObject(walk.Description, walk)

                lstWalks.Items.Add(lstItem) 'walk.Description)
            Next
            ' Grab the obfuscated name...
            For Each p As System.Reflection.PropertyInfo In GetType(ListBoxWalkObject).GetProperties
                lstWalks.DisplayMember = p.Name
                Exit For
            Next
            'lstWalks.DisplayMember = GetType( ListBoxWalkObject).GetProperties( "Description"

            Changed = False
        End With

        'treeTopics.DrawFilter = highlight
        treeTopics.Override.SelectionType = SelectType.ExtendedAutoDrag

        If bShow Then Me.Show()
        'txtPrefix.Focus()
        If Not OpenForms.Contains(Me) Then OpenForms.Add(Me)

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If ApplyCharacter() Then CloseCharacter(Me)
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If ApplyCharacter() Then Changed = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then
                If Not ApplyCharacter() Then Exit Sub
            End If
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        CloseCharacter(Me)
    End Sub


    Private Function ValidateCharacter() As Boolean

        If txtProperName.Text = "" AndAlso cmbShortDescriptions.Items.Count = 1 AndAlso cmbShortDescriptions.Text = "" Then
            MessageBox.Show("You must give the character either a name or descriptor.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.tabsCharacters.Tabs(0).Selected = True
            txtProperName.Focus()
            Return False
        End If

        If Not Properties1.ValidateProperties Then
            tabsCharacters.SelectedTab = tabsCharacters.Tabs("Properties")
            Return False
        End If

        Return True
    End Function


    Private Function ApplyCharacter() As Boolean

        If Not ValidateCharacter() Then Return False

        ' remember to strip off the unselected properties

        With cCharacter

            .arlDescriptors.Clear()
            .Article = txtArticle.Text.Trim
            .Prefix = txtPrefix.Text.Trim

            For Each vli As Infragistics.Win.ValueListItem In cmbShortDescriptions.Items                
                If vli.DisplayText <> "" AndAlso Not .arlDescriptors.Contains(vli.DisplayText.Trim) Then .arlDescriptors.Add(vli.DisplayText.Trim)
            Next
            .Description = txtDescription.Description.Copy
            .LastUpdated = Now
            .IsLibrary = False

            .arlWalks.Clear()
            For Each lbwo As ListBoxWalkObject In lstWalks.Items
                .arlWalks.Add(lbwo.Walk)
            Next

            .htblActualProperties = Me.Properties1.htblProperties.CopySelected
            .htblTopics = Me.htblTopics
            .ProperName = txtProperName.Text

            If .Key = "" Then
                .Key = .GetNewKey ' Adventure.GetNewKey("Character")
                Adventure.htblCharacters.Add(cCharacter, .Key)
                Me.Properties1.OwnerKey = .Key
            End If

            .ProperName = "" ' for now, whilst we search
            If txtProperName.Text <> "" AndAlso .SearchFor(txtProperName.Text) Then
                'Select Case MessageBox.Show("Would you like to replace all instances of """ & txtProperName.Text & """ with ""%CharacterName%""? (dialog to be improved)", "ADRIFT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Select Case YesNoCancel("Would you like to replace all instances of """ & txtProperName.Text & """ with ""%CharacterName%""?", "Save changes", "ReplaceCharacterNames", False)
                    Case Windows.Forms.DialogResult.Yes
                        For Each tc As Char In New Char() {" "c, "."c, ","c, "!"c, Chr(10), Chr(13)}
                            .SearchAndReplace(txtProperName.Text & tc, "%CharacterName%" & tc)
                        Next
                        'ApplyCharacter()
                        .ProperName = txtProperName.Text
                        LoadForm(cCharacter, True)
                    Case Windows.Forms.DialogResult.No
                        ' Leave as is                    
                End Select
            End If

            .ProperName = txtProperName.Text
            UpdateListItem(.Key, .Name)

            For Each w As Form In OpenForms
                If TypeOf w Is frmLocation Then
                    Dim sLocKey As String = CType(w, frmLocation).Folder1.sParentKey
                    If (.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation AndAlso .Location.Key = sLocKey)  Then
                        CType(w, frmLocation).Folder1.AddSingleItem(.Key)
                    End If
                End If
            Next

        End With

        Adventure.Changed = True

        Return True

    End Function


    Private Sub frmCharacter_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OpenForms.Remove(Me)
    End Sub

    Private Sub frmCharacter_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        'Me.txtPrefix.Width = CInt(Me.Width / 2) - 72
        'Me.cmbNames.Width = CInt(Me.Width / 2) - 72
        'Me.cmbNames.Left = CInt(Me.Width / 2) + 48
        'Me.lblNouns.Left = Me.cmbNames.Left

    End Sub


    Private Sub txtPrefix_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrefix.TextChanged

        If txtArticle.Text = "" AndAlso txtPrefix.Text <> "" Then
            Select Case sLeft(txtPrefix.Text, 1).ToLower
                Case "a", "e", "i", "o", "u"
                    txtArticle.Text = "an"
                Case Else
                    txtArticle.Text = "a"
            End Select
        End If

    End Sub



    Private Sub frmObject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Properties1.PropertyType = clsProperty.PropertyOfEnum.Characters
        GetFormPosition(Me)
    End Sub

    Private Sub cmbShortDescriptions_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShortDescriptions.Enter
        Me.AcceptButton = Nothing
    End Sub


    Private Sub cmbShortDescriptions_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbShortDescriptions.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                If iSelectedIndex = cmbShortDescriptions.Items.Count - 1 Then
                    iSelectedIndex += 1
                    cmbShortDescriptions.Items.Add("")
                    bAllowChangeValue = False
                    cmbShortDescriptions.Clear()
                    bAllowChangeValue = True
                Else
                    iSelectedIndex += 1
                    cmbShortDescriptions.SelectedItem = cmbShortDescriptions.Items(iSelectedIndex)
                    cmbShortDescriptions.SelectedText = cmbShortDescriptions.SelectedItem.DisplayText
                    cmbShortDescriptions.SelectionStart = 0
                    cmbShortDescriptions.SelectionLength = cmbShortDescriptions.Text.Length
                End If
        End Select

    End Sub



    Private Sub cmbShortDescriptions_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbShortDescriptions.KeyUp
        cmbShortDescriptions.Items(iSelectedIndex).DisplayText = cmbShortDescriptions.Text
        bChanged = True
    End Sub

    Private Sub cmbShortDescriptions_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShortDescriptions.Leave
        Me.AcceptButton = btnOK
    End Sub


    Private Sub cmbShortDescriptions_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShortDescriptions.SelectionChanged
        If bAllowChangeValue AndAlso cmbShortDescriptions.SelectedIndex > -1 Then iSelectedIndex = cmbShortDescriptions.SelectedIndex
    End Sub

    Private Sub StuffChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.Changed, Properties1.Changed, txtArticle.TextChanged, txtPrefix.TextChanged
        Changed = True
    End Sub

    Private Sub lstWalks_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstWalks.DoubleClick, btnEditWalk.Click

        If lstWalks.SelectedItem IsNot Nothing Then
            EditWalk(CType(lstWalks.SelectedItem, ListBoxWalkObject).Walk, CType(lstWalks.SelectedItem, ListBoxWalkObject))
        End If

    End Sub

    Private Sub lstWalks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstWalks.SelectedIndexChanged
        If lstWalks.SelectedItem IsNot Nothing Then
            btnEditWalk.Enabled = True
            btnRemoveWalk.Enabled = True
        Else
            btnEditWalk.Enabled = False
            btnRemoveWalk.Enabled = False
        End If
    End Sub


    Private Sub EditTopic(ByVal topic As clsTopic, Optional ByVal node As Infragistics.Win.UltraWinTree.UltraTreeNode = Nothing)

        Dim frmTopic As New frmTopic(topic, htblTopics)
        If frmTopic.DialogResult = Windows.Forms.DialogResult.OK Then
            If node Is Nothing Then
                node = treeTopics.Nodes.Add(topic.Key, topic.Summary)
                treeTopics.Refresh()
                htblTopics.Add(topic)
            Else
                node.Text = topic.Summary
            End If
            TopicIcons(topic, node)
        End If

    End Sub


    Private Sub TopicIcons(ByVal topic As clsTopic, ByVal node As Infragistics.Win.UltraWinTree.UltraTreeNode)
        If topic.bIntroduction Then
            node.Override.NodeAppearance.Image = Global.ADRIFT.My.Resources.imgRight
        ElseIf topic.bFarewell Then
            node.Override.NodeAppearance.Image = Global.ADRIFT.My.Resources.imgLeft
        End If
    End Sub


    Private Sub EditWalk(ByVal walk As clsWalk, Optional ByVal lbwo As ListBoxWalkObject = Nothing)

        Dim frmWalk As New frmWalk(walk)
        If frmWalk.DialogResult = Windows.Forms.DialogResult.OK Then
            If lbwo Is Nothing Then
                lstWalks.Items.Add(New ListBoxWalkObject(walk.Description, walk))
            Else
                lbwo.Description = walk.Description

                ' Force it to re-read the display member
                lstWalks.DisplayMember = "xxx"
                lstWalks.DisplayMember = "Description"
            End If
        End If

    End Sub

    Private Sub btnAddWalk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddWalk.Click
        Dim walk As New clsWalk
        EditWalk(walk)
    End Sub


    Private Sub btnRemoveWalk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveWalk.Click

        If lstWalks.SelectedItem Is Nothing Then Exit Sub

        Dim walk As clsWalk = CType(lstWalks.SelectedItem, ListBoxWalkObject).Walk

        If MessageBox.Show("Are you sure you wish to remove walk " & walk.Description & "?", "Remove walk", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            lstWalks.Items.Remove(lstWalks.SelectedItem)
        End If

    End Sub


    Private Sub btnAddTopic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTopic.Click
        Dim topic As New clsTopic
        EditTopic(topic)
    End Sub

    Private Sub treeTopics_AfterSelect(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.SelectEventArgs) Handles treeTopics.AfterSelect
        If treeTopics.SelectedNodes.Count = 1 Then
            btnEditTopic.Enabled = True
            btnRemoveTopic.Enabled = True
        Else
            btnEditTopic.Enabled = False
            btnRemoveTopic.Enabled = False
        End If
    End Sub

    Private Sub btnEditTopic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditTopic.Click
        If treeTopics.SelectedNodes.Count = 1 Then
            EditTopic(htblTopics(treeTopics.SelectedNodes(0).Key), treeTopics.SelectedNodes(0))
        End If
    End Sub
    Private Sub treeTopics_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles treeTopics.MouseDoubleClick
        If treeTopics.SelectedNodes.Count = 1 AndAlso treeTopics.GetNodeFromPoint(e.Location) IsNot Nothing Then
            EditTopic(htblTopics(treeTopics.SelectedNodes(0).Key), treeTopics.SelectedNodes(0))
        End If
    End Sub

#Region "Drag/Drop"

    'Private WithEvents highlight As New UltraTree_DropHightLight_DrawFilter_Class()

    Private Sub treeTopics_SelectionDragStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles treeTopics.SelectionDragStart
        'Start a DragDrop operation
        treeTopics.DoDragDrop(treeTopics.SelectedNodes, DragDropEffects.Move)
    End Sub

    Private Sub treeTopics_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles treeTopics.DragOver
        'A dummy node variable used to hold nodes for various things
        Dim node As UltraTreeNode
        'The Point that the mouse cursor is on, in Tree coords. 
        'This event passes X and Y in form coords.         

        'Get the node the mouse is over
        node = treeTopics.GetNodeFromPoint(treeTopics.PointToClient(New Point(e.X, e.Y)))

        'Make sure the mouse is over a node
        If node Is Nothing Then
            'The Mouse is not over a node
            'Do not allow dropping here
            e.Effect = DragDropEffects.Move
            'Erase any DropHighlight
            'highlight.ClearDropHighlight()
            treeTopics.ActiveNode = Nothing
            'Exit stage left
            Exit Sub
        End If



        'Check to see if we are dropping onto a node who's parent (grandparent, etc) is selected.
        'This is to prevent the user from dropping a node onto one of it's own descendents. 
        If IsAnyParentSelected(node) Then
            'Mouse is over a node whose parent is selected.  Do not allow the drop
            e.Effect = DragDropEffects.None
            'Clear the DropHighlight
            'highlight.ClearDropHighlight()
            treeTopics.ActiveNode = Nothing
            'Exit stage left
            Exit Sub
        End If

        'If we've reached this point, it's okay to drop on this node
        'Tell the DrawFilter where we are by calling SetDropHighlightNode
        'highlight.SetDropHighlightNode(node, PointInTree)
        treeTopics.ActiveNode = node

        'Allow Dropping here. 
        e.Effect = DragDropEffects.Move
    End Sub

    'Walks up the parent chain for a node to determine if any of it's parent nodes are selected
    Private Function IsAnyParentSelected(ByVal Node As UltraTreeNode) As Boolean
        Dim ParentNode As UltraTreeNode
        Dim ReturnValue As Boolean = False

        If Node.Selected Then Return True
        ParentNode = Node.Parent
        Do Until ParentNode Is Nothing
            If ParentNode.Selected Then
                ReturnValue = True
                Exit Do
            Else
                ParentNode = ParentNode.Parent
            End If
        Loop

        Return ReturnValue
    End Function


    'The DragDrop event. Here we respond to a Drop on the tree
    Private Sub UltraTree1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles treeTopics.DragDrop
        'A dummy node variable used for various things
        Dim node As UltraTreeNode

        'The Node to Drop On
        Dim DropNode As Infragistics.Win.UltraWinTree.UltraTreeNode
        'An integer used for loops
        Dim i As Integer

        'Set the DropNode
        'DropNode = highlight.DropHightLightNode
        DropNode = treeTopics.GetNodeFromPoint(treeTopics.PointToClient(New Point(e.X, e.Y)))

        'Get the Data and put it into a SelectedNodes collection, then clone it and work with the clone
        'These are the nodes that are being dragged and dropped
        Dim SelectedNodes As SelectedNodesCollection = CType(CType(e.Data.GetData(GetType(SelectedNodesCollection)), SelectedNodesCollection).Clone, SelectedNodesCollection)

        For Each node In SelectedNodes
            If node Is DropNode Then Exit Sub
        Next

        'Sort the selected nodes into their visible position.  This is done so that they stay in the same order when
        'they are repositioned. 
        SelectedNodes.SortByPosition()

        If DropNode Is Nothing Then
            For i = 0 To SelectedNodes.Count - 1
                node = SelectedNodes(i)
                node.Reposition(treeTopics.Nodes)
            Next
        Else
            For i = 0 To SelectedNodes.Count - 1
                node = SelectedNodes(i)
                node.Reposition(DropNode.Nodes)
                DropNode.ExpandAll(ExpandAllType.OnlyNodesWithChildren)
            Next
        End If

        For Each node In SelectedNodes
            If node.Parent IsNot Nothing Then
                htblTopics(node.Key).ParentKey = htblTopics(node.Parent.Key).Key
            Else
                htblTopics(node.Key).ParentKey = Nothing
            End If
        Next

        'After the drop is complete, erase the current drop
        'highlight. 
        'highlight.ClearDropHighlight()
        treeTopics.ActiveNode = SelectedNodes(0) ' Nothing
    End Sub

    ''This event is fired by the DrawFilter to let us determine
    ''what kinds of drops we want to allow on any particular node
    'Private Sub highlight_QueryStateAllowedForNode(ByVal sender As Object, ByVal e As UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventArgs) Handles highlight.QueryStateAllowedForNode

    '    If e.Node.Selected Then
    '        'This is a selected Continent node. 
    '        'Since it is selected, we don't want to allow
    '        'dropping ON this node. But we can allow the
    '        'the user to drop above or below it. 
    '        e.StatesAllowed = DropLinePositionEnum.None ' DropLinePositionEnum.AboveNode Or DropLinePositionEnum.BelowNode
    '        highlight.EdgeSensitivity = CInt(e.Node.Bounds.Height / 2)
    '    Else
    '        'This is a continent node and is not selected
    '        'We can allow dropping here above, below, or on this
    '        'node. Since the StatesAllow defaults to All, we don't 
    '        'need to change it. 
    '        'We set the EdgeSensitivity to 1/3 so that the 
    '        'Drawfilter will respond at the top, bottom, or 
    '        'middle of the node. 
    '        e.StatesAllowed = DropLinePositionEnum.OnNode
    '        highlight.EdgeSensitivity = CInt(e.Node.Bounds.Height / 3)
    '    End If

    'End Sub

    'Fires when the user drags outside the control. 
    Private Sub treeTopics_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles treeTopics.DragLeave
        'When the mouse goes outside the control, clear the drophighlight. 
        'Since the DropHighlight is cleared when the 
        'mouse is not over a node, anyway, 
        'this is probably not needed
        'But, just in case the user goes from a node directly
        'off the control...
        'highlight.ClearDropHighlight()
        treeTopics.ActiveNode = Nothing
    End Sub

    'Occassionally, the DrawFilter will let us know that the 
    'control needs to be invalidated. 
    'Private Sub highlight_Invalidate(ByVal sender As Object, ByVal e As System.EventArgs) Handles highlight.Invalidate
    '    'Any time the drophighlight changes, the control needs 
    '    'to know that it has to repaint. 
    '    'It would be more efficient to only invalidate the area
    '    'that needs it, but this works and is very clean.
    '    treeTopics.Invalidate()
    'End Sub

#End Region

    Private Sub frmCharacter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If txtProperName.Text = "" Then
            txtProperName.Focus()
        Else
            'txtDescription.rtxtSource.SelectionStart = txtDescription.rtxtSource.TextLength
            txtDescription.rtxtSource.EditInfo.PerformAction(Infragistics.Win.FormattedLinkLabel.FormattedLinkEditorAction.DocumentEnd)
            txtDescription.rtxtSource.Focus()
        End If
    End Sub


    Private Sub RemoveNode(ByVal node As UltraTreeNode)

        For Each nodeChild As UltraTreeNode In node.Nodes
            RemoveNode(nodeChild)
        Next
        htblTopics.Remove(node.Key)
        treeTopics.GetNodeByKey(node.Key).Remove()

    End Sub


    Private Sub btnRemoveTopic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveTopic.Click

        If treeTopics.SelectedNodes.Count > 0 Then
            Dim bMultiple As Boolean = treeTopics.SelectedNodes.Count > 1 OrElse treeTopics.SelectedNodes(0).HasNodes
            If MessageBox.Show("Are you sure you wish to delete the selected topic" & IIf(bMultiple, "s", "").ToString & "?", "Delete topic" & IIf(bMultiple, "s", "").ToString, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                For Each node As UltraTreeNode In treeTopics.SelectedNodes
                    RemoveNode(node)
                    Changed = True
                Next
            End If
        End If

    End Sub


    Dim sLastName As String = ""
    Private Sub txtProperName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProperName.TextChanged
        If sLastName = "" And txtProperName.Text.Length = 1 Then
            txtProperName.Text = UCase(txtProperName.Text)
            txtProperName.SelectionStart = 1
        End If
        sLastName = txtProperName.Text
    End Sub


    Private Sub frmCharacter_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        ShowHelp(Me, "Characters")
    End Sub

End Class


Public Class ListBoxWalkObject

    Dim sValue As String
    Dim oWalk As clsWalk

    Public Sub New(ByVal sValue As String, ByVal oWalk As clsWalk)
        Me.sValue = sValue
        Me.oWalk = oWalk
    End Sub

    Shadows Property Description() As String
        Get
            Return sValue
        End Get
        Set(ByVal value As String)
            sValue = value
        End Set
    End Property

    Public Property Walk() As clsWalk
        Get
            Return oWalk
        End Get
        Set(ByVal value As clsWalk)
            oWalk = value
        End Set
    End Property
End Class