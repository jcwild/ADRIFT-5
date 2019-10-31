Public Class frmObject
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public bKeepOpen As Boolean = False

    Public Sub New(ByRef ob As clsObject, ByVal bShow As Boolean)
        MyBase.New()

        ' Check that this window isn't already open
        For Each w As Form In OpenForms
            If TypeOf w Is frmObject Then
                If CType(w, frmObject).cObject.Key = ob.Key AndAlso ob.Key IsNot Nothing Then
                    w.BringToFront()
                    w.Focus()
                    Exit Sub
                End If
            End If
        Next

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoadForm(ob, bShow)
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
    Friend WithEvents tabsObject As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Properties1 As ADRIFT.Properties
    Friend WithEvents txtDescription As ADRIFT.GenTextbox
    Friend WithEvents lblArticle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblPrefix As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblNouns As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtArticle As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtPrefix As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cmbNames As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents cmbLocation2 As ADRIFT.ItemSelector
    Friend WithEvents cmbInitialLocation As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkDynamic As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkStatic As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmObject))
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbInitialLocation = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbLocation2 = New ADRIFT.ItemSelector()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chkDynamic = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkStatic = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.txtDescription = New ADRIFT.GenTextbox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtPrefix = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtArticle = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.cmbNames = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblNouns = New Infragistics.Win.Misc.UltraLabel()
        Me.lblPrefix = New Infragistics.Win.Misc.UltraLabel()
        Me.lblArticle = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Properties1 = New ADRIFT.Properties()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.btnApply = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.tabsObject = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.cmbInitialLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.chkDynamic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkStatic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrefix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtArticle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbNames, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabsObject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsObject.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox1)
        Me.UltraTabPageControl1.Controls.Add(Me.txtDescription)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl1.Controls.Add(Me.txtPrefix)
        Me.UltraTabPageControl1.Controls.Add(Me.txtArticle)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbNames)
        Me.UltraTabPageControl1.Controls.Add(Me.lblNouns)
        Me.UltraTabPageControl1.Controls.Add(Me.lblPrefix)
        Me.UltraTabPageControl1.Controls.Add(Me.lblArticle)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(548, 396)
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.UltraGroupBox2.Appearance = Appearance1
        Me.UltraGroupBox2.Controls.Add(Me.cmbInitialLocation)
        Me.UltraGroupBox2.Controls.Add(Me.cmbLocation2)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(179, 60)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(363, 50)
        Me.UltraGroupBox2.TabIndex = 24
        Me.UltraGroupBox2.Text = "Initial Location:"
        '
        'cmbInitialLocation
        '
        Me.cmbInitialLocation.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem3.DataValue = "ValueListItem0"
        ValueListItem3.DisplayText = "Part of Character"
        Me.cmbInitialLocation.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3})
        Me.cmbInitialLocation.Location = New System.Drawing.Point(12, 19)
        Me.cmbInitialLocation.Name = "cmbInitialLocation"
        Me.cmbInitialLocation.Size = New System.Drawing.Size(129, 21)
        Me.cmbInitialLocation.TabIndex = 22
        Me.cmbInitialLocation.Text = "Part of Character"
        '
        'cmbLocation2
        '
        Me.cmbLocation2.AllowAddEdit = True
        Me.cmbLocation2.AllowedListType = ADRIFT.ItemSelector.ItemEnum.Character
        Me.cmbLocation2.AllowHidden = False
        Me.cmbLocation2.BackColor = System.Drawing.Color.Transparent
        Me.cmbLocation2.Key = Nothing
        Me.cmbLocation2.ListType = ADRIFT.ItemSelector.ItemEnum.Character
        Me.cmbLocation2.Location = New System.Drawing.Point(149, 19)
        Me.cmbLocation2.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbLocation2.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbLocation2.Name = "cmbLocation2"
        Me.cmbLocation2.Size = New System.Drawing.Size(202, 21)
        Me.cmbLocation2.TabIndex = 21
        '
        'UltraGroupBox1
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.UltraGroupBox1.Appearance = Appearance2
        Me.UltraGroupBox1.Controls.Add(Me.chkDynamic)
        Me.UltraGroupBox1.Controls.Add(Me.chkStatic)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(8, 60)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(153, 50)
        Me.UltraGroupBox1.TabIndex = 23
        Me.UltraGroupBox1.Text = "Object Type:"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP
        '
        'chkDynamic
        '
        Appearance5.Image = Global.ADRIFT.My.Resources.imgObjectDynamic16
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance5.TextHAlignAsString = "Center"
        Me.chkDynamic.Appearance = Appearance5
        Me.chkDynamic.BackColor = System.Drawing.Color.Transparent
        Me.chkDynamic.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkDynamic.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.chkDynamic.Location = New System.Drawing.Point(71, 17)
        Me.chkDynamic.Name = "chkDynamic"
        Me.chkDynamic.Size = New System.Drawing.Size(73, 26)
        Me.chkDynamic.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkDynamic.TabIndex = 30
        Me.chkDynamic.Text = "Dynamic"
        Me.chkDynamic.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'chkStatic
        '
        Appearance6.Image = Global.ADRIFT.My.Resources.imgObjectStatic16
        Appearance6.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance6.TextHAlignAsString = "Center"
        Me.chkStatic.Appearance = Appearance6
        Me.chkStatic.BackColor = System.Drawing.Color.Transparent
        Me.chkStatic.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkStatic.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.chkStatic.Location = New System.Drawing.Point(11, 17)
        Me.chkStatic.Name = "chkStatic"
        Me.chkStatic.Size = New System.Drawing.Size(56, 26)
        Me.chkStatic.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkStatic.TabIndex = 29
        Me.chkStatic.Text = "Static"
        Me.chkStatic.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'txtDescription
        '
        Me.txtDescription.AllowAlternateDescriptions = True
        Me.txtDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDescription.FirstTabHasRestrictions = False
        Me.txtDescription.Location = New System.Drawing.Point(8, 131)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.sCommand = Nothing
        Me.txtDescription.Size = New System.Drawing.Size(536, 250)
        Me.txtDescription.TabIndex = 3
        '
        'UltraLabel1
        '
        Me.UltraLabel1.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel1.Location = New System.Drawing.Point(8, 115)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel1.TabIndex = 19
        Me.UltraLabel1.Text = "Description:"
        '
        'txtPrefix
        '
        Me.txtPrefix.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProvider1.SetHelpString(Me.txtPrefix, resources.GetString("txtPrefix.HelpString"))
        Me.txtPrefix.Location = New System.Drawing.Point(112, 24)
        Me.txtPrefix.Name = "txtPrefix"
        Me.HelpProvider1.SetShowHelp(Me.txtPrefix, True)
        Me.txtPrefix.Size = New System.Drawing.Size(208, 26)
        Me.txtPrefix.TabIndex = 1
        Me.txtPrefix.Text = "orange"
        '
        'txtArticle
        '
        Me.txtArticle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProvider1.SetHelpString(Me.txtArticle, resources.GetString("txtArticle.HelpString"))
        Me.txtArticle.Location = New System.Drawing.Point(8, 24)
        Me.txtArticle.Name = "txtArticle"
        Me.HelpProvider1.SetShowHelp(Me.txtArticle, True)
        Me.txtArticle.Size = New System.Drawing.Size(96, 26)
        Me.txtArticle.TabIndex = 0
        Me.txtArticle.Text = "an"
        '
        'cmbNames
        '
        Me.cmbNames.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNames.Location = New System.Drawing.Point(328, 24)
        Me.cmbNames.Name = "cmbNames"
        Me.cmbNames.Size = New System.Drawing.Size(208, 26)
        Me.cmbNames.TabIndex = 2
        '
        'lblNouns
        '
        Me.lblNouns.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblNouns.Location = New System.Drawing.Point(328, 8)
        Me.lblNouns.Name = "lblNouns"
        Me.lblNouns.Size = New System.Drawing.Size(88, 16)
        Me.lblNouns.TabIndex = 18
        Me.lblNouns.Text = "Name/Noun(s):"
        '
        'lblPrefix
        '
        Me.lblPrefix.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblPrefix.Location = New System.Drawing.Point(112, 8)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(88, 16)
        Me.lblPrefix.TabIndex = 17
        Me.lblPrefix.Text = "Prefix/Adjective:"
        '
        'lblArticle
        '
        Me.lblArticle.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblArticle.Location = New System.Drawing.Point(8, 8)
        Me.lblArticle.Name = "lblArticle"
        Me.lblArticle.Size = New System.Drawing.Size(100, 23)
        Me.lblArticle.TabIndex = 16
        Me.lblArticle.Text = "Article:"
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
        Me.btnApply.TabIndex = 14
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(352, 432)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(256, 432)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "OK"
        '
        'tabsObject
        '
        Me.tabsObject.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabsObject.Controls.Add(Me.UltraTabPageControl1)
        Me.tabsObject.Controls.Add(Me.UltraTabPageControl2)
        Me.tabsObject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsObject.Location = New System.Drawing.Point(0, 0)
        Me.tabsObject.Name = "tabsObject"
        Me.tabsObject.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabsObject.Size = New System.Drawing.Size(552, 422)
        Me.tabsObject.TabIndex = 15
        UltraTab1.Key = "Description"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Description"
        UltraTab2.Key = "Properties"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Properties"
        Me.tabsObject.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(548, 396)
        '
        'frmObject
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(552, 470)
        Me.Controls.Add(Me.tabsObject)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(568, 508)
        Me.Name = "frmObject"
        Me.ShowInTaskbar = False
        Me.Text = "Object - "
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.cmbInitialLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.chkDynamic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkStatic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrefix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtArticle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbNames, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabsObject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsObject.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private cObject As clsObject
    Private bChanged As Boolean
    Private iSelectedIndex As Integer = 0
    Private bAllowChangeValue As Boolean = True


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


    Private Sub StuffChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.Changed, Properties1.Changed
        Changed = True

        If Properties1.htblProperties.ContainsKey("StaticOrDynamic") Then
            If Properties1.htblProperties("StaticOrDynamic").StringData.ToString = "Dynamic" Then
                Me.Icon = Icon.FromHandle(My.Resources.imgObjectDynamic16.GetHicon)
            Else
                Me.Icon = Icon.FromHandle(My.Resources.imgObjectStatic16.GetHicon)
            End If
        End If
    End Sub


    Private Sub SetName()
        With cObject
            Text = "Object - " & .FullName
            If SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0")) Then Text &= "  [" & .Key & "]"
            If .FullName = "Undefined Object" Then Text = "New Object"
        End With
    End Sub

    Private Sub LoadForm(ByRef cObject As clsObject, ByVal bShow As Boolean)

        Me.cObject = cObject


        With cObject
           
            SetName()

            txtDescription.Description = .Description.Copy
            txtArticle.Text = .Article
            txtPrefix.Text = .Prefix
            For Each sName As String In .arlNames
                cmbNames.Items.Add(sName)
            Next
            If cmbNames.Items.Count > 0 Then
                iSelectedIndex = 0
                cmbNames.SelectedIndex = 0
            Else
                cmbNames.Items.Add("")
            End If

            Dim sLocation2Property As String = ""
            If .IsStatic Then
                chkStatic.Checked = True
                If .htblProperties.ContainsKey("StaticLocation") Then
                    cmbInitialLocation.Text = .htblProperties("StaticLocation").Value
                    'SetCombo(cmbInitialLocation, .htblProperties("StaticLocation").Value)
                    Select Case .htblProperties("StaticLocation").Value
                        Case "Nowhere", "Hidden"
                            ' Nothing to do
                        Case "Single Location"
                            sLocation2Property = "AtLocation"
                        Case "Location Group"
                            sLocation2Property = "AtLocationGroup"
                        Case "Everywhere"
                            ' Nothing to do
                        Case "Part of Character"
                            sLocation2Property = "PartOfWho"
                        Case "Part of Object"
                            sLocation2Property = "PartOfWhat"
                        Case Else
                            TODO("Additional Static Location property")
                    End Select
                End If
            Else
                chkDynamic.Checked = True
                If .htblProperties.ContainsKey("DynamicLocation") Then
                    cmbInitialLocation.Text = .htblProperties("DynamicLocation").Value
                    'SetCombo(cmbInitialLocation, .htblProperties("DynamicLocation").Value)
                    Select Case .htblProperties("DynamicLocation").Value
                        Case "Held By Character"
                            sLocation2Property = "HeldByWho"
                        Case "Hidden"
                            ' Nothing to do 
                        Case "In Location"
                            sLocation2Property = "InLocation"
                        Case "Inside Object"
                            sLocation2Property = "InsideWhat"
                        Case "On Object"
                            sLocation2Property = "OnWhat"
                        Case "Worn By Character"
                            sLocation2Property = "WornByWho"
                        Case Else
                            TODO("Additional Static Location property")
                    End Select
                End If
            End If

            If sLocation2Property <> "" AndAlso .htblProperties.ContainsKey(sLocation2Property) Then
                cmbLocation2.Key = .htblProperties(sLocation2Property).Value
            End If

            ' Pad out the local Object hashtable with unselected properties
            '.bCalculatedGroups = False
            .ResetInherited()
            Dim htblProperties As PropertyHashTable = .htblProperties.Clone ' .GetPropertiesIncludingGroups.Clone ' .htblProperties.Clone
            For Each prop As clsProperty In Adventure.htblObjectProperties.Values
                If Not htblProperties.ContainsKey(prop.Key) Then htblProperties.Add(prop.Copy)
            Next
            Me.Properties1.htblProperties = htblProperties
            Me.Properties1.OwnerKey = .Key
            Changed = False
        End With

        GetFormPosition(Me)
        UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP
        UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP

        If bShow Then Me.Show()

        OpenForms.Add(Me)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If ApplyObject() Then CloseObject(Me)
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If ApplyObject() Then Changed = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then
                If Not ApplyObject() Then Exit Sub
            End If
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        CloseObject(Me)
    End Sub


    Private Function ValidateObject() As Boolean

        Dim sFailingProperty As String = Nothing
        If Not Properties1.ValidateProperties(sFailingProperty) Then
            Select Case sFailingProperty
                Case "InLocation"
                    tabsObject.SelectedTab = tabsObject.Tabs("Description")
                Case Else
                    tabsObject.SelectedTab = tabsObject.Tabs("Properties")
            End Select
            Return False
        End If

        ' Make sure a recursive location hasn't been created
        Select Case cmbInitialLocation.Text
            Case "Inside Object", "On Object"
                If cObject.Key <> "" AndAlso (cObject.Key = cmbLocation2.Key OrElse Adventure.htblObjects(cObject.Key).Children(clsObject.WhereChildrenEnum.InsideOrOnObject, True).ContainsKey(cmbLocation2.Key)) Then
                    ErrMsg("Error - This would create a recursive location for the object.")
                    tabsObject.SelectedTab = tabsObject.Tabs("Description")
                    Return False
                End If
        End Select

        'If txtArticle.Text = "the" Then
        '    MessageBox.Show("ADRIFT expects an indefinite article (for example ""a"", ""an"" etc) rather than a definite one (i.e. ""the"").", "Incorrect Article", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    tabsObject.SelectedTab = tabsObject.Tabs("Description")
        '    txtArticle.Focus()
        '    Return False
        'End If
        Return True
    End Function


    Private Function ApplyObject() As Boolean

        If Not ValidateObject() Then Return False

        ' remember to strip off the unselected properties
        With cObject
            '.Description = txtName.Text
            '.CompletionMessage = txtCompletion.txtSource
            .Article = txtArticle.Text.Trim
            .Prefix = txtPrefix.Text.Trim
            .arlNames.Clear()
            For Each vli As Infragistics.Win.ValueListItem In cmbNames.Items
                If vli.DisplayText <> "" AndAlso Not .arlNames.Contains(vli.DisplayText.Trim) Then .arlNames.Add(vli.DisplayText.Trim)
            Next
            .Description = txtDescription.Description.Copy
            .LastUpdated = Now
            .IsLibrary = False

            .htblActualProperties = Me.Properties1.htblProperties.CopySelected

            If chkStatic.Checked Then
                .IsStatic = True
                .SetPropertyValue("StaticLocation", cmbInitialLocation.Text)                
                Dim sStaticLocation As String = String.Empty
                If cmbInitialLocation.SelectedItem IsNot Nothing Then sStaticLocation = SafeString(cmbInitialLocation.SelectedItem.DataValue)              
                If cmbLocation2.Enabled AndAlso cmbLocation2.Key <> "" Then .SetPropertyValue(sStaticLocation, cmbLocation2.Key)
            ElseIf chkDynamic.Checked Then
                .IsStatic = False
                .SetPropertyValue("DynamicLocation", cmbInitialLocation.Text)                
                Dim sDynamicLocation As String = String.Empty
                If cmbInitialLocation.SelectedItem IsNot Nothing Then sDynamicLocation = SafeString(cmbInitialLocation.SelectedItem.DataValue)
                If cmbLocation2.Enabled AndAlso cmbLocation2.Key <> "" Then .SetPropertyValue(sDynamicLocation, cmbLocation2.Key)
            End If

            If .Key = "" Then
                .Key = .GetNewKey ' Adventure.GetNewKey("Object")
                Adventure.htblObjects.Add(cObject, .Key)
                Me.Properties1.OwnerKey = .Key
            End If

            SetName()

            UpdateListItem(.Key, .FullName)

            For Each w As Form In OpenForms
                If TypeOf w Is frmLocation Then
                    Dim sLocKey As String = CType(w, frmLocation).Folder1.sParentKey
                    If (Not .IsStatic AndAlso .Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InLocation AndAlso .Location.Key = sLocKey) _
                     OrElse (.IsStatic AndAlso (.Location.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.AllRooms OrElse (.Location.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.SingleLocation AndAlso .LocationRoots.ContainsKey(sLocKey)))) Then
                        CType(w, frmLocation).Folder1.AddSingleItem(.Key)
                    End If
                End If
            Next

        End With

        Adventure.Changed = True

        Return True

    End Function


    Private Sub frmObject_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OpenForms.Remove(Me)
    End Sub


    Private Sub frmObject_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        Me.txtPrefix.Width = CInt(Me.Width / 2) - 72
        Me.cmbNames.Width = CInt(Me.Width / 2) - 72
        Me.cmbNames.Left = CInt(Me.Width / 2) + 48
        Me.lblNouns.Left = Me.cmbNames.Left
        cmbInitialLocation.Width = cmbNames.Left - UltraGroupBox2.Left - 24
        cmbLocation2.Left = cmbInitialLocation.Width + 24
        cmbLocation2.Width = cmbNames.Width - 5

    End Sub


    Private Sub cmbNames_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNames.Enter
        Me.AcceptButton = Nothing
    End Sub



    Private Sub txtPrefix_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrefix.TextChanged, cmbNames.TextChanged

        If txtArticle.Text = "" Then
            If txtPrefix.Text <> "" Then
                Select Case sLeft(txtPrefix.Text, 1).ToLower
                    Case "a", "e", "i", "o", "u"
                        txtArticle.Text = "an"
                    Case Else
                        txtArticle.Text = "a"
                End Select
            ElseIf txtPrefix.Text = "" AndAlso cmbNames.Text <> "" Then
                Select Case sLeft(cmbNames.Text, 1).ToLower
                    Case "a", "e", "i", "o", "u"
                        txtArticle.Text = "an"
                    Case Else
                        txtArticle.Text = "a"
                End Select
            End If
        End If
        Changed = True

    End Sub


    Private Sub cmbNames_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNames.Leave
        'AddName(True)
        For i As Integer = cmbNames.Items.Count - 1 To 0 Step -1
            If cmbNames.Items(i).DisplayText = "" Then
                If iSelectedIndex = i Then iSelectedIndex = 0
                If iSelectedIndex > i Then iSelectedIndex -= 1
                If cmbNames.Items.Count > 1 Then cmbNames.Items.RemoveAt(i)
            End If
        Next
        Me.AcceptButton = btnOK
    End Sub

    'Private Sub frmObject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    GetFormPosition(Me)
    'End Sub


    Private Sub cmbNames_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbNames.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                If iSelectedIndex = cmbNames.Items.Count - 1 Then
                    iSelectedIndex += 1
                    cmbNames.Items.Add("")
                    bAllowChangeValue = False
                    cmbNames.Clear()
                    bAllowChangeValue = True
                Else
                    iSelectedIndex += 1
                    If cmbNames.Items.Count > iSelectedIndex Then cmbNames.SelectedItem = cmbNames.Items(iSelectedIndex)
                    If cmbNames.SelectedItem IsNot Nothing Then cmbNames.SelectedText = cmbNames.SelectedItem.DisplayText
                    cmbNames.SelectionStart = 0
                    cmbNames.SelectionLength = cmbNames.Text.Length
                End If
                'NamesDebug()
            Case Keys.Up
                If iSelectedIndex > 0 Then iSelectedIndex -= 1
            Case Keys.Down
                If iSelectedIndex < cmbNames.Items.Count - 1 Then iSelectedIndex += 1
            Case Keys.Delete
                If cmbNames.SelectedText = cmbNames.Text AndAlso iSelectedIndex > -1 Then cmbNames.Items(iSelectedIndex).DataValue = ""
        End Select

        'If cmbNames.Text = "" Then
        '    Debug.WriteLine("Text cleared on item " & iSelectedIndex)
        'End If
        'cmbNames.Items(iSelectedIndex).DisplayText = cmbNames.Text
        'NamesDebug()

    End Sub



    Private Sub cmbNames_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbNames.KeyUp
        If cmbNames.Items.Count > iSelectedIndex Then cmbNames.Items(iSelectedIndex).DisplayText = cmbNames.Text
        'NamesDebug()
    End Sub


    Private Sub cmbNames_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNames.SelectionChanged
        If bAllowChangeValue AndAlso cmbNames.SelectedIndex > -1 AndAlso Not (cmbNames.Text = "" AndAlso cmbNames.Items(cmbNames.SelectedIndex).DisplayText <> "") Then
            ' text won't match item when we change selection with mouse
            iSelectedIndex = cmbNames.SelectedIndex
            '            Debug.WriteLine("Selected entry " & iSelectedIndex)
            'NamesDebug()
        Else
            If cmbNames.SelectedIndex > -1 Then Debug.WriteLine("text: " & cmbNames.Text & ", item: " & cmbNames.Items(cmbNames.SelectedIndex).DisplayText)
        End If
    End Sub


    'Private Sub NamesDebug()
    '    For i As Integer = 0 To cmbNames.Items.Count - 1
    '        Debug.WriteLine("Name " & i & ": " & cmbNames.Items(i).DisplayText)
    '    Next
    'End Sub

    Private Sub frmObject_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtPrefix.Focus()
    End Sub

    Private Sub frmObject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Properties1.PropertyType = clsProperty.PropertyOfEnum.Objects
        'Me.Icon = Icon.FromHandle(My.Resources.imgObjectStatic32.GetHicon)
        If Properties1.htblProperties.ContainsKey("StaticOrDynamic") Then
            If Properties1.htblProperties("StaticOrDynamic").StringData.ToString = "Dynamic" Then
                Me.Icon = Icon.FromHandle(My.Resources.imgObjectDynamic16.GetHicon)
            Else
                Me.Icon = Icon.FromHandle(My.Resources.imgObjectStatic16.GetHicon)
            End If
        End If
    End Sub


    Private bChangingCheck As Boolean = False
    Private Sub chkStatic_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkStatic.CheckedChanged, chkDynamic.CheckedChanged

        If bChangingCheck Then Exit Sub
        bChangingCheck = True

        For Each chk As Infragistics.Win.UltraWinEditors.UltraCheckEditor In New Infragistics.Win.UltraWinEditors.UltraCheckEditor() {chkStatic, chkDynamic}
            If chk IsNot sender Then chk.Checked = Not CType(sender, Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked
        Next

        Dim sOldWhere As String = ""
        If cmbInitialLocation.SelectedItem IsNot Nothing Then sOldWhere = cmbInitialLocation.SelectedItem.DataValue.ToString
        Dim sOldKey As String = cmbLocation2.Key

        cmbInitialLocation.SuspendLayout()
        cmbLocation2.SuspendLayout()

        cmbInitialLocation.Items.Clear()
        Select Case True
            Case sender Is chkStatic
                Me.Icon = Icon.FromHandle(My.Resources.imgObjectStatic16.GetHicon)
                cmbInitialLocation.Items.Add("Hidden", "Hidden")
                cmbInitialLocation.Items.Add("AtLocation", "Single Location")
                cmbInitialLocation.Items.Add("AtLocationGroup", "Location Group")
                cmbInitialLocation.Items.Add("Everywhere", "Everywhere")                
                cmbInitialLocation.Items.Add("PartOfWhat", "Part of Object")
                cmbInitialLocation.Items.Add("PartOfWho", "Part of Character")
                If Properties1.htblProperties IsNot Nothing AndAlso Properties1.htblProperties.ContainsKey("StaticOrDynamic") Then Properties1.htblProperties("StaticOrDynamic").Value = "Static"
                Select Case sOldWhere
                    Case "InLocation"
                        SetCombo(cmbInitialLocation, "AtLocation")
                        cmbLocation2.Key = sOldKey
                    Case "InsideWhat", "OnWhat"
                        SetCombo(cmbInitialLocation, "PartOfWhat")
                        cmbLocation2.Key = sOldKey
                    Case "HeldByWho", "WornByWho"
                        SetCombo(cmbInitialLocation, "PartOfWho")
                        cmbLocation2.Key = sOldKey
                End Select
            Case sender Is chkDynamic
                Me.Icon = Icon.FromHandle(My.Resources.imgObjectDynamic16.GetHicon)
                'For Each sState As String In Adventure.htblObjectProperties("DynamicLocation").arlStates
                '    cmbInitialLocation.Items.Add(sState)
                'Next
                cmbInitialLocation.Items.Add("Hidden", "Hidden")
                cmbInitialLocation.Items.Add("HeldByWho", "Held By Character")
                cmbInitialLocation.Items.Add("WornByWho", "Worn By Character")
                cmbInitialLocation.Items.Add("InLocation", "In Location")
                cmbInitialLocation.Items.Add("InsideWhat", "Inside Object")
                cmbInitialLocation.Items.Add("OnWhat", "On Object")
                If Properties1.htblProperties IsNot Nothing AndAlso Properties1.htblProperties.ContainsKey("StaticOrDynamic") Then Properties1.htblProperties("StaticOrDynamic").Value = "Dynamic"
                Select Case sOldWhere
                    Case "AtLocation"
                        SetCombo(cmbInitialLocation, "InLocation")
                        cmbLocation2.Key = sOldKey
                    Case "PartOfWhat"
                        Dim ob As clsObject = Adventure.htblObjects(sOldKey)
                        If ob IsNot Nothing Then
                            If ob.HasSurface Then
                                SetCombo(cmbInitialLocation, "OnWhat")
                                cmbLocation2.Key = sOldKey
                            ElseIf ob.IsContainer Then
                                SetCombo(cmbInitialLocation, "InsideWhat")
                                cmbLocation2.Key = sOldKey
                            End If
                        End If
                    Case "PartOfWho"
                        SetCombo(cmbInitialLocation, "HeldByWho")
                        cmbLocation2.Key = sOldKey
                End Select
        End Select
        If cmbInitialLocation.SelectedItem Is Nothing Then cmbInitialLocation.Text = "Hidden"
        If cmbInitialLocation.SelectedItem Is Nothing Then cmbInitialLocation.SelectedIndex = 0

        cmbInitialLocation.ResumeLayout()
        cmbLocation2.ResumeLayout()

        Properties1.RefreshProperties()

        bChangingCheck = False
        Changed = True

    End Sub


    Private Sub cmbInitialLocation_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbInitialLocation.SelectionChanged

        Dim bEnabled As Boolean = False

        cmbLocation2.SuspendLayout()

        'cmbLocation2.Enabled = False
        For Each prop As clsProperty In Adventure.htblObjectProperties.Values
            If prop.Mandatory AndAlso ((chkStatic.Checked AndAlso prop.DependentKey = "StaticLocation") OrElse (chkDynamic.Checked AndAlso prop.DependentKey = "DynamicLocation")) _
                AndAlso prop.DependentValue = SafeString(cmbInitialLocation.SelectedItem.DisplayText) Then
                Select Case prop.Type
                    Case clsProperty.PropertyTypeEnum.CharacterKey
                        cmbLocation2.AllowedListType = ItemSelector.ItemEnum.Character
                    Case clsProperty.PropertyTypeEnum.LocationGroupKey
                        cmbLocation2.AllowedListType = ItemSelector.ItemEnum.LocationGroup
                    Case clsProperty.PropertyTypeEnum.LocationKey
                        cmbLocation2.AllowedListType = ItemSelector.ItemEnum.Location
                    Case clsProperty.PropertyTypeEnum.ObjectKey
                        cmbLocation2.AllowedListType = ItemSelector.ItemEnum.Object
                    Case Else
                        TODO()
                End Select
                cmbLocation2.RestrictProperty = prop.RestrictProperty
                ' TODO - cmbLocation2.RestrictValue = prop.RestrictValue 
                'cmbLocation2.Enabled = True
                bEnabled = True
            End If
        Next

        cmbLocation2.Enabled = bEnabled

        Dim sProperty As String = ""
        If chkStatic.Checked Then
            sProperty = "StaticLocation"
        ElseIf chkDynamic.Checked Then
            sProperty = "DynamicLocation"
        End If
        If Properties1.htblProperties IsNot Nothing AndAlso Properties1.htblProperties.ContainsKey(sProperty) Then
            Properties1.htblProperties(sProperty).Value = cmbInitialLocation.Text
            Properties1.RefreshProperties()
        End If
        Changed = True

        cmbLocation2.ResumeLayout()

    End Sub


    Private Sub cmbLocation2_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbLocation2.SelectionChanged

        Dim sLocation As String = String.Empty
        If cmbInitialLocation.SelectedItem IsNot Nothing Then sLocation = SafeString(cmbInitialLocation.SelectedItem.DataValue)
        If Properties1.htblProperties IsNot Nothing AndAlso Properties1.htblProperties.ContainsKey(sLocation) Then
            Properties1.htblProperties(sLocation).Value = cmbLocation2.Key
            Properties1.RefreshProperties()
        End If        
        Changed = True

    End Sub


    Private Sub frmObject_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        ShowHelp(Me, "Objects")
    End Sub

End Class
