Public Class frmGroup
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public bModal As Boolean = False

    Public Sub New(ByVal RoomGroup As clsGroup, ByVal bShow As Boolean)
        MyBase.New()

        ' Check that this window isn't already open
        For Each w As Form In OpenForms
            If TypeOf w Is frmGroup Then
                If CType(w, frmGroup).cGroup.Key = RoomGroup.Key AndAlso RoomGroup.Key IsNot Nothing Then
                    w.BringToFront()
                    w.Focus()
                    Exit Sub
                End If
            End If
        Next

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        bModal = Not bShow
        LoadForm(RoomGroup)

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
    Friend WithEvents tabsMain As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents lvwItems As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDescription As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GroupProperties As ADRIFT.Properties
    Friend WithEvents cmbGroupType As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.cmbGroupType = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.lvwItems = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtDescription = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.GroupProperties = New ADRIFT.Properties()
        Me.btnApply = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.tabsMain = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.cmbGroupType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabsMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.cmbGroupType)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl1.Controls.Add(Me.lvwItems)
        Me.UltraTabPageControl1.Controls.Add(Me.txtDescription)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(308, 316)
        '
        'cmbGroupType
        '
        Me.cmbGroupType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem5.DataValue = "2"
        ValueListItem5.DisplayText = "Characters"
        ValueListItem3.DataValue = "0"
        ValueListItem3.DisplayText = "Locations"
        ValueListItem4.DataValue = "1"
        ValueListItem4.DisplayText = "Objects"
        Me.cmbGroupType.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem5, ValueListItem3, ValueListItem4})
        Me.cmbGroupType.Location = New System.Drawing.Point(82, 36)
        Me.cmbGroupType.Name = "cmbGroupType"
        Me.cmbGroupType.Size = New System.Drawing.Size(219, 21)
        Me.cmbGroupType.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbGroupType.TabIndex = 26
        '
        'UltraLabel2
        '
        Me.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraLabel2.Location = New System.Drawing.Point(11, 41)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(72, 16)
        Me.UltraLabel2.TabIndex = 25
        Me.UltraLabel2.Text = "Group Type:"
        '
        'lvwItems
        '
        Me.lvwItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwItems.CheckBoxes = True
        Me.lvwItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvwItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvwItems.Location = New System.Drawing.Point(7, 63)
        Me.lvwItems.MultiSelect = False
        Me.lvwItems.Name = "lvwItems"
        Me.lvwItems.Size = New System.Drawing.Size(294, 202)
        Me.lvwItems.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwItems.TabIndex = 20
        Me.lvwItems.UseCompatibleStateImageBehavior = False
        Me.lvwItems.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 300
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(82, 10)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(219, 21)
        Me.txtDescription.TabIndex = 3
        '
        'UltraLabel1
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance1
        Me.UltraLabel1.Location = New System.Drawing.Point(11, 13)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(64, 16)
        Me.UltraLabel1.TabIndex = 2
        Me.UltraLabel1.Text = "Description:"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.GroupProperties)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(308, 316)
        '
        'GroupProperties
        '
        Me.GroupProperties.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupProperties.BackColor = System.Drawing.Color.Transparent
        Me.GroupProperties.Location = New System.Drawing.Point(0, 0)
        Me.GroupProperties.Name = "GroupProperties"
        Me.GroupProperties.Size = New System.Drawing.Size(308, 270)
        Me.GroupProperties.TabIndex = 0
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(208, 304)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(88, 32)
        Me.btnApply.TabIndex = 18
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(112, 304)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(16, 304)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "OK"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 294)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(312, 48)
        Me.UltraStatusBar1.TabIndex = 15
        '
        'tabsMain
        '
        Me.tabsMain.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabsMain.Controls.Add(Me.UltraTabPageControl2)
        Me.tabsMain.Controls.Add(Me.UltraTabPageControl1)
        Me.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsMain.Location = New System.Drawing.Point(0, 0)
        Me.tabsMain.Name = "tabsMain"
        Me.tabsMain.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabsMain.Size = New System.Drawing.Size(312, 342)
        Me.tabsMain.TabIndex = 21
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Selections"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Properties"
        Me.tabsMain.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(308, 316)
        '
        'frmGroup
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(312, 342)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.Controls.Add(Me.tabsMain)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGroup"
        Me.Text = "Groups"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.cmbGroupType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabsMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private bChanged As Boolean
    Private cGroup As clsGroup
    Private arlMembers As StringArrayList

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


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ApplyGroup()
        DialogResult = Windows.Forms.DialogResult.OK
        CloseGroup(Me)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then ApplyGroup()
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        DialogResult = Windows.Forms.DialogResult.Cancel
        CloseGroup(Me)
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ApplyGroup()
        Changed = False
    End Sub

    Private Sub ApplyGroup()

        With cGroup

            .arlMembers.Clear()
            If .Key <> ALLROOMS AndAlso .Key <> NOROOMS Then
                For Each lvi As ListViewItem In lvwItems.Items
                    If lvi.Checked Then
                        .arlMembers.Add(CStr(lvi.Tag))
                    End If
                Next
            End If

            .Name = Me.txtDescription.Text
            .GroupType = CType(cmbGroupType.SelectedItem.DataValue, clsGroup.GroupTypeEnum)
            .htblProperties = GroupProperties.htblProperties.CopySelected(True)
            .LastUpdated = Now
            .IsLibrary = False

            If .Key = "" Then
                .Key = .GetNewKey ' Adventure.GetNewKey("Group")
                If Not bModal Then Adventure.htblGroups.Add(cGroup, .Key)
                Me.GroupProperties.OwnerKey = .Key
            End If

            If Not bModal Then UpdateListItem(.Key, .Name)

        End With

        Adventure.Changed = True

    End Sub


    Private Sub LoadList(ByVal eGroupType As clsGroup.GroupTypeEnum)

        If lvwItems.Tag IsNot Nothing AndAlso CType(lvwItems.Tag, clsGroup.GroupTypeEnum) = eGroupType Then Exit Sub

        lvwItems.Items.Clear()

        Select Case eGroupType
            Case clsGroup.GroupTypeEnum.Locations
                For Each loc As clsLocation In Adventure.htblLocations.Values
                    Dim lvi As New ListViewItem
                    lvi.Text = loc.ShortDescription.ToString
                    lvi.SubItems.Add(loc.ShortDescription.ToString)
                    lvi.Tag = loc.Key
                    lvi.ImageIndex = 0
                    Me.lvwItems.Items.Add(lvi)
                    If arlMembers.Contains(loc.Key) Then lvwItems.Items(lvi.Index).Checked = True
                Next
            Case clsGroup.GroupTypeEnum.Objects
                For Each ob As clsObject In Adventure.htblObjects.Values
                    Dim lvi As New ListViewItem
                    lvi.Text = ob.FullName
                    lvi.SubItems.Add(ob.FullName)
                    lvi.Tag = ob.Key
                    If ob.IsStatic Then
                        lvi.ImageIndex = 1
                    Else
                        lvi.ImageIndex = 2
                    End If
                    Me.lvwItems.Items.Add(lvi)
                    If arlMembers.Contains(ob.Key) Then lvwItems.Items(lvi.Index).Checked = True
                Next
            Case clsGroup.GroupTypeEnum.Characters
                For Each ch As clsCharacter In Adventure.htblCharacters.Values
                    Dim lvi As New ListViewItem
                    lvi.Text = ch.Name
                    lvi.SubItems.Add(ch.Name)
                    lvi.Tag = ch.Key
                    If ch Is Adventure.Player Then
                        lvi.ImageIndex = 3
                    Else
                        lvi.ImageIndex = 4
                    End If
                    Me.lvwItems.Items.Add(lvi)
                    If arlMembers.Contains(ch.Key) Then lvwItems.Items(lvi.Index).Checked = True
                Next
        End Select
        lvwItems.Tag = eGroupType

    End Sub


    Private Sub LoadForm(ByRef cRoomGroup As clsGroup)

        Me.cGroup = cRoomGroup

        With cRoomGroup
            Text = "Location Group - " & .Name
            If SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0")) Then Text &= "  [" & .Key & "]"
            'LoadList(.GroupType)
            If .Name = "" Then Text = "New Group"
            Me.txtDescription.Text = .Name
            arlMembers = .arlMembers.Clone
            GroupProperties.bGroup = True
            GroupProperties.OwnerKey = .Key

            'SetOptSet(optGroupType, .GroupType)
            SetCombo(cmbGroupType, CInt(.GroupType))
        End With

        If cRoomGroup.Key = NOROOMS OrElse cRoomGroup.Key = ALLROOMS Then lvwItems.Enabled = False ' Special cases
        Changed = False

        If Not bModal Then Me.Show()

        OpenForms.Add(Me)

    End Sub

    Private Sub frmGroup_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OpenForms.Remove(Me)
    End Sub


    Private Sub frmRoomGroup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = Icon.FromHandle(My.Resources.imgGroup16.GetHicon)
        GetFormPosition(Me)
        Dim il As New ImageList
        il.Images.Add("Location", My.Resources.imgLocation16)
        il.Images.Add("Static", My.Resources.imgObjectStatic16)
        il.Images.Add("Dynamic", My.Resources.imgObjectDynamic16)
        il.Images.Add("Player", My.Resources.imgPlayer16)
        il.Images.Add("Character", My.Resources.imgCharacter16)
        lvwItems.SmallImageList = il
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        Const WM_PAINT As Integer = &HF  ' 15

        Select Case m.Msg
            Case WM_PAINT
                If lvwItems.View = View.Details AndAlso lvwItems.Columns.Count > 0 Then
                    lvwItems.Columns(lvwItems.Columns.Count - 1).Width = -2
                End If
        End Select

        MyBase.WndProc(m)

    End Sub

    Private Sub lvwRooms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvwItems.SelectedItems.Count > 0 AndAlso lvwItems.SelectedItems(0).Index > -1 Then lvwItems.Items(lvwItems.SelectedItems(0).Index).Selected = False
    End Sub

    Private Sub cmbGroupType_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGroupType.SelectionChanged
        If Me.Visible Then cGroup.htblProperties.Clear()
        Select Case CType(cmbGroupType.Value, clsGroup.GroupTypeEnum)
            Case clsGroup.GroupTypeEnum.Objects
                GroupProperties.htblProperties = cGroup.htblProperties.Clone
                ' Pad out the local Object hashtable with unselected properties
                For Each prop As clsProperty In Adventure.htblObjectProperties.Values
                    If Not GroupProperties.htblProperties.ContainsKey(prop.Key) Then GroupProperties.htblProperties.Add(prop.Copy)
                Next
                GroupProperties.PropertyType = clsProperty.PropertyOfEnum.Objects
            Case clsGroup.GroupTypeEnum.Characters
                ' Pad out the local Object hashtable with unselected properties
                GroupProperties.htblProperties = cGroup.htblProperties.Clone
                For Each prop As clsProperty In Adventure.htblCharacterProperties.Values
                    If Not GroupProperties.htblProperties.ContainsKey(prop.Key) Then GroupProperties.htblProperties.Add(prop.Copy)
                Next                                
                GroupProperties.PropertyType = clsProperty.PropertyOfEnum.Characters
            Case clsGroup.GroupTypeEnum.Locations
                ' Pad out the local Object hashtable with unselected properties
                GroupProperties.htblProperties = cGroup.htblProperties.Clone
                For Each prop As clsProperty In Adventure.htblLocationProperties.Values
                    If Not GroupProperties.htblProperties.ContainsKey(prop.Key) Then GroupProperties.htblProperties.Add(prop.Copy)
                Next                
                GroupProperties.PropertyType = clsProperty.PropertyOfEnum.Locations
        End Select
        LoadList(CType(cmbGroupType.SelectedItem.DataValue, clsGroup.GroupTypeEnum))
    End Sub

    Private Sub lvwItems_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lvwItems.ItemCheck
        If e.NewValue = CheckState.Checked Then
            arlMembers.Add(SafeString(lvwItems.Items(e.Index).Tag))
        Else
            arlMembers.Remove(SafeString(lvwItems.Items(e.Index).Tag))
        End If
    End Sub

    Private Sub frmGroup_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If txtDescription.Text = "" Then
            txtDescription.Focus()
        Else
            ' Dunno...
        End If
    End Sub

    Private Sub StuffChanged(sender As Object, e As System.EventArgs) Handles txtDescription.TextChanged, GroupProperties.Changed
        Changed = True
    End Sub

    Private Sub frmGroup_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        ShowHelp(Me, "GroupsClasses")
    End Sub

End Class
