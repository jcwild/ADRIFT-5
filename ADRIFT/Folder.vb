Imports Infragistics.Win.UltraWinListView


Public Class Folder

    Private WithEvents tmrActivate As New Timer
    Public Event LoadedFolder(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ActiveChanged(ByVal sender As Object, ByVal bActive As Boolean)
    Public Event ViewTypeChanged(ByVal sender As Object, ByVal Type As UltraListViewStyle)
    Public Event MembersChanged(ByVal sender As Object, ByVal e As EventArgs)
    Public WithEvents folder As clsFolder
    Public sLastKey As String = ""
    Public dtLoaded As DateTime = Date.MinValue
    Public sParentKey As String

    Public SortColumn As Integer = -1
    Public SortDirection As Infragistics.Win.UltraWinListView.Sorting = Sorting.None

    Private bMouseInFolder As Boolean = False
    Private bRenaming As Boolean = False


    Public WriteOnly Property HideLibrary() As Boolean
        Set(ByVal value As Boolean)
            lstContents.BeginUpdate()
            For Each itm As UltraListViewItem In lstContents.Items
                If value Then
                    Dim itmGen As clsItem = Adventure.dictAllItems(itm.SubItems(3).Text)
                    If itmGen.IsLibrary AndAlso (TypeOf itmGen Is clsTask OrElse TypeOf itmGen Is clsProperty) Then
                        itm.Visible = False
                    End If
                Else
                    itm.Visible = True
                End If
            Next
            lstContents.EndUpdate()
        End Set
    End Property


    Public Sub AddSingleItem(ByVal sItemKey As String)
        If Not lstContents.Items.Exists(sItemKey) Then lstContents.Items.Add(CreateItem(sItemKey))
        If folder IsNot Nothing AndAlso Not folder.Members.Contains(sItemKey) Then folder.Members.Add(sItemKey)
    End Sub


    Public Sub RemoveCutItems(ByRef nodes As Generic.List(Of Infragistics.Win.UltraWinTree.UltraTreeNode))

        nodes = New Generic.List(Of Infragistics.Win.UltraWinTree.UltraTreeNode)

        For i As Integer = lstContents.Items.Count - 1 To 0 Step -1
            If lstContents.Items(i).Appearance.AlphaLevel = 128 Then
                Dim sItemKey As String = lstContents.Items(i).SubItems(3).Text
                Adventure.dictAllItems.Remove(sItemKey)
                folder.Members.Remove(sItemKey)
                lstContents.Items.RemoveAt(i)
                Dim treenode As Infragistics.Win.UltraWinTree.UltraTreeNode = fGenerator.FolderList1.treeFolders.GetNodeByKey(sItemKey)
                If treenode IsNot Nothing Then treenode.Parent.Nodes.Remove(treenode)
                nodes.Add(treenode)
            End If
        Next

    End Sub


    Public Sub UnCutItems()
        For Each item As UltraListViewItem In lstContents.Items
            item.Appearance.AlphaLevel = 255        
        Next
    End Sub


    Public Sub CutSingleItem(ByVal sItemKey As String)
        If folder.Members.Contains(sItemKey) Then
            For Each item As UltraListViewItem In lstContents.Items
                If item.SubItems(3).Text = sItemKey Then
                    item.Appearance.AlphaLevel = 128                    
                    Exit For
                End If
            Next
        End If
    End Sub


    Public Sub RemoveSingleItem(ByVal sItemKey As String)
        If folder.Members.Contains(sItemKey) Then
            For Each item As UltraListViewItem In lstContents.Items
                If item.SubItems(3).Text = sItemKey Then
                    lstContents.Items.Remove(item)
                    Exit For
                End If
            Next
            folder.Members.Remove(sItemKey)
        End If        
    End Sub


    Private Function CreateItem(ByVal sItemKey As String) As UltraListViewItem

        Dim itemGen As clsItem = Adventure.GetItemFromKey(sItemKey)
        If itemGen Is Nothing Then Return Nothing

        Dim subitems() As UltraListViewSubItem = {New UltraListViewSubItem, New UltraListViewSubItem, New UltraListViewSubItem, New UltraListViewSubItem, New UltraListViewSubItem}
        subitems(0).Value = itemGen.Created
        subitems(1).Value = itemGen.LastUpdated
        subitems(2).Value = Adventure.GetTypeFromKeyNice(itemGen.Key)
        subitems(3).Value = itemGen.Key
        subitems(4).Value = 0

        Return GetItem(itemGen, subitems)

    End Function


    Public Function GetItem(ByVal itemGen As clsItem, ByVal subitems() As UltraListViewSubItem) As UltraListViewItem

        Dim item As New UltraListViewItem(itemGen.CommonName, subitems)

        item.Key = itemGen.Key
        item.Visible = True ' by default (Tasks and Properties may not be)

        Select Case True
            Case TypeOf itemGen Is clsFolder
                item.Appearance.Image = My.Resources.imgFolderClosed16
            Case TypeOf itemGen Is clsLocation
                item.Appearance.Image = My.Resources.imgLocation16
            Case TypeOf itemGen Is clsObject
                If CType(itemGen, clsObject).IsStatic Then
                    item.Appearance.Image = My.Resources.imgObjectStatic16
                Else
                    item.Appearance.Image = My.Resources.imgObjectDynamic16
                End If
            Case TypeOf itemGen Is clsTask
                Select Case CType(itemGen, clsTask).TaskType
                    Case clsTask.TaskTypeEnum.General
                        item.Appearance.Image = My.Resources.imgTaskGeneral16
                    Case clsTask.TaskTypeEnum.Specific
                        item.Appearance.Image = My.Resources.imgTaskSpecific16
                    Case clsTask.TaskTypeEnum.System
                        item.Appearance.Image = My.Resources.imgTaskSystem16
                End Select
                If subitems.Length > 3 Then subitems(4).Value = CType(itemGen, clsTask).Priority
                item.Visible = Not (itemGen.IsLibrary AndAlso SafeBool(GetSetting("ADRIFT", "Generator", "HideLibraryItems", "1")))
            Case TypeOf itemGen Is clsEvent
                Select Case CType(itemGen, clsEvent).EventType
                    Case clsEvent.EventTypeEnum.TurnBased
                        item.Appearance.Image = My.Resources.imgEvent16
                    Case clsEvent.EventTypeEnum.TimeBased
                        item.Appearance.Image = My.Resources.imgTimeEvent16
                End Select
            Case TypeOf itemGen Is clsCharacter
                Select Case CType(itemGen, clsCharacter).CharacterType
                    Case clsCharacter.CharacterTypeEnum.Player
                        item.Appearance.Image = My.Resources.imgPlayer16
                    Case clsCharacter.CharacterTypeEnum.NonPlayer
                        item.Appearance.Image = My.Resources.imgCharacter16
                End Select
            Case TypeOf itemGen Is clsGroup
                item.Appearance.Image = My.Resources.imgGroup16
            Case TypeOf itemGen Is clsVariable
                item.Appearance.Image = My.Resources.imgVariable16
            Case TypeOf itemGen Is clsALR
                item.Appearance.Image = My.Resources.imgALR16
            Case TypeOf itemGen Is clsHint
                item.Appearance.Image = My.Resources.imgHint16
            Case TypeOf itemGen Is clsProperty
                item.Appearance.Image = My.Resources.imgProperty16
                item.Visible = Not (itemGen.IsLibrary AndAlso SafeBool(GetSetting("ADRIFT", "Generator", "HideLibraryItems", "1")))
            Case TypeOf itemGen Is clsUserFunction
                item.Appearance.Image = My.Resources.imgFunction16
            Case TypeOf itemGen Is clsSynonym
                item.Appearance.Image = My.Resources.imgSynonym16
        End Select

        Return item
    End Function

    Public Sub LoadFolder(ByVal sKey As String)
        Me.lstContents.Items.Clear()

        If Adventure.dictFolders.ContainsKey(sKey) Then

            If folder IsNot Nothing Then sLastKey = folder.Key

            If folder IsNot Nothing Then RemoveHandler folder.ColumnChanged, AddressOf folder_ColumnChanged
            folder = Adventure.dictFolders(sKey)
            AddHandler folder.ColumnChanged, AddressOf folder_ColumnChanged
            'lstContents.Visible = False
            lstContents.BeginUpdate()
            With folder
                Dim itemlist As New ArrayList

                For Each sMember As String In .Members
                    If Not lstContents.Items.Exists(sMember) Then
                        Dim itm As UltraListViewItem = CreateItem(sMember)
                        If itm IsNot Nothing Then itemlist.Add(itm)
                    End If
                Next

                Try
                    lstContents.Items.AddRange(CType(itemlist.ToArray(GetType(UltraListViewItem)), UltraListViewItem()))
                Catch ex As Exception
                    'ErrMsg("Error adding items to list " & folder.Name, ex)
                    ' Hmm, could be a Case Sensitive issue.  Check each one...
                    For Each sMember As String In .Members
                        If lstContents.Items.Exists(sMember) Then
                            If lstContents.Items(sMember).Key <> sMember Then
                                Dim itm As UltraListViewItem = CreateItem(sMember)
                                While lstContents.Items.Exists(itm.Key)
                                    itm.Key = itm.Key & "$"
                                End While
                                If itm IsNot Nothing Then lstContents.Items.Add(itm)
                            End If
                        Else
                            Dim itm As UltraListViewItem = CreateItem(sMember)                          
                            If itm IsNot Nothing Then lstContents.Items.Add(itm)
                        End If
                    Next
                End Try                

                lstContents.View = .ViewType
                Dim mi As ToolStripMenuItem = Nothing
                Select Case .SortColumn
                    Case 0
                        mi = miSortName
                    Case 1
                        mi = miSortCreationDate
                    Case 2
                        mi = miSortModifiedDate
                    Case 3
                        mi = miSortType
                    Case 5
                        mi = miSortTaskPriority
                End Select
                If mi IsNot Nothing Then miSortBy_Click(mi, Nothing)

                mi = Nothing
                Select Case .SortDirection
                    Case Sorting.Ascending
                        mi = miSortAscending
                    Case Sorting.Descending
                        mi = miSortDescending
                End Select
                If mi IsNot Nothing Then miSortDirection_Click(mi, Nothing)

                Select Case .GroupBy
                    Case 0
                        miGroupByNone_Click(Nothing, Nothing)
                    Case 1
                        miGroupByType_Click(Nothing, Nothing)
                End Select

                Select Case .GroupDirection
                    Case Sorting.Ascending
                        miGroupAscending_Click(Nothing, Nothing)
                    Case Sorting.Descending
                        miGroupDescending_Click(Nothing, Nothing)
                End Select

                .Visible = True
                dtLoaded = Now
            End With
            'lstContents.Visible = True
            lstContents.EndUpdate()

            folder_ColumnChanged(Me, 0, folder.ShowCreatedDate)
            folder_ColumnChanged(Me, 1, folder.ShowModifiedDate)
            folder_ColumnChanged(Me, 2, folder.ShowType)
            folder_ColumnChanged(Me, 3, folder.ShowKey)
            folder_ColumnChanged(Me, 4, folder.ShowPriority)

            If TypeOf Me.Parent Is Infragistics.Win.UltraWinDock.DockableWindow Then
                Dim parent As Infragistics.Win.UltraWinDock.DockableWindow = CType(Me.Parent, Infragistics.Win.UltraWinDock.DockableWindow)
                parent.Pane.Text = fGenerator.FolderList1.treeFolders.GetNodeByKey(sKey).FullPath
            End If

            RaiseEvent LoadedFolder(Me, New EventArgs)
        End If
    End Sub

    Private Sub lstContents_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstContents.DragLeave
        bMouseInFolder = False
    End Sub


    Private Sub Folder_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus, lstContents.GotFocus
        'fGenerator.ActiveFolder = Me
        'SetActive()
    End Sub


    Private bActive As Boolean = False
    Public Sub SetActive(Optional ByVal bActive As Boolean = True)

        Me.bActive = bActive
        If bActive Then
            For Each frm As Form In fGenerator.MdiChildren
                If TypeOf frm Is frmFolder Then
                    If CType(frm, frmFolder).Folder IsNot Me Then CType(frm, frmFolder).Folder.SetActive(False)
                End If
            Next
            'For Each child As frmFolder In fGenerator.MdiChildren
            '    If child.Folder IsNot Me Then child.Folder.SetActive(False)
            'Next
            fGenerator.ActiveFolder = Me
            SetNodeInTree()
        End If
        RaiseEvent ActiveChanged(Me, bActive)

    End Sub


    Private Sub SetNodeInTree()
        If fGenerator.FolderList1.treeFolders.SelectedNodes.Count <= 1 Then
            Dim sOldKey As String = ""
            If fGenerator.FolderList1.treeFolders.SelectedNodes.Count = 1 Then sOldKey = fGenerator.FolderList1.treeFolders.SelectedNodes(0).Key
            If folder IsNot Nothing AndAlso folder.Key <> sOldKey Then
                fGenerator.FolderList1.bSettingNode = True
                If sOldKey <> "" Then fGenerator.FolderList1.treeFolders.GetNodeByKey(sOldKey).Selected = False
                If fGenerator.FolderList1.treeFolders.GetNodeByKey(folder.Key) IsNot Nothing Then fGenerator.FolderList1.treeFolders.GetNodeByKey(folder.Key).Selected = True
                fGenerator.FolderList1.bSettingNode = False
            End If
        End If
    End Sub


    Private Class MenuItemComparer
        Implements IComparer

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Return CType(x, ToolStripMenuItem).Text.CompareTo(CType(y, ToolStripMenuItem).Text)
        End Function
    End Class


    Private Sub cmsFolder_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsFolder.Opening

        If folder Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If

        Dim p As Point = MousePosition
        Dim itemCursor As UltraListViewItem = lstContents.ItemFromPoint(lstContents.PointToClient(p))

        miAddItem.Text = "Add Item"
        Select Case True
            Case folder.Name.Contains("Location")
                miAddItem.Text = "Add Location"
                miAddItem.Image = My.Resources.imgLocation16
            Case folder.Name.Contains("Object")
                miAddItem.Text = "Add Object"
                miAddItem.Image = My.Resources.imgObjectDynamic16
            Case folder.Name.Contains("Task")
                miAddItem.Text = "Add Task"
                miAddItem.Image = My.Resources.imgTaskGeneral16
            Case folder.Name.Contains("Event")
                miAddItem.Text = "Add Event"
                miAddItem.Image = My.Resources.imgEvent16
            Case folder.Name.Contains("Character")
                miAddItem.Text = "Add Character"
                miAddItem.Image = My.Resources.imgCharacter16
            Case folder.Name.Contains("Propert")
                miAddItem.Text = "Add Property"
                miAddItem.Image = My.Resources.imgProperty16
            Case folder.Name.Contains("Text Override")
                miAddItem.Text = "Add Text Override"
                miAddItem.Image = My.Resources.imgALR16
            Case folder.Name.Contains("Group")
                miAddItem.Text = "Add Group"
                miAddItem.Image = My.Resources.imgGroup16
            Case folder.Name.Contains("Variable")
                miAddItem.Text = "Add Variable"
                miAddItem.Image = My.Resources.imgVariable16
            Case folder.Name.Contains("Hint")
                miAddItem.Text = "Add Hint"
                miAddItem.Image = My.Resources.imgHint16
            Case folder.Name.Contains("Synonym")
                miAddItem.Text = "Add Synonym"
                miAddItem.Image = My.Resources.imgSynonym16
            Case folder.Name.Contains("Function")
                miAddItem.Text = "Add User Function"
                miAddItem.Image = My.Resources.imgFunction16
        End Select
        miAddItem.Visible = (miAddItem.Text <> "Add Item")
        sep1.Visible = (miAddItem.Text <> "Add Item")

        If itemCursor IsNot Nothing AndAlso itemCursor.IsSelected Then
            miEdit.Visible = True
            Dim bAddSpecific As Boolean = False
            Dim bAddObject As Boolean = False
            Dim bAddSubObject As Boolean = False

            sep4.Visible = False
            miExportFolder.Visible = False

            If lstContents.SelectedItems.Count = 1 Then
                Dim sItemKey As String = ""
                If lstContents.SelectedItems(0).SubItems.Count > 3 Then sItemKey = lstContents.SelectedItems(0).SubItems(3).Text

                If Adventure.htblLocations.ContainsKey(sItemKey) Then
                    ' Add object to location
                    miAddSpecificTask.DropDownItems.Clear()
                    Dim arlMenuItems As New ArrayList
                    Dim loc As clsLocation = Adventure.htblLocations(sItemKey)
                    Dim miPEL As New ToolStripMenuItem("Player enters " & Adventure.GetNameFromKey(sItemKey), Nothing, AddressOf miAddSpecificTaskForLocation)
                    miPEL.Tag = "PlayerEntersLocation"
                    arlMenuItems.Add(miPEL)
                    For Each tas As clsTask In Adventure.Tasks(clsAdventure.TasksListEnum.GeneralAndOverrideableSpecificTasks).Values
                        If Not tas.PreventOverriding Then
                            For Each s As String In tas.References
                                If s = "%location%" Then
                                    Dim sDesc As String = tas.MakeNice.Replace("%location%", loc.ShortDescription.ToString)
                                    sDesc = sDesc.Replace("%object%", "an object").Replace("%object1%", "an object").Replace("%objects%", "an object").Replace("%character%", "a character").Replace("%character1%", "a character").Replace("%characters%", "a character").Replace("%item%", "an item")
                                    For i As Integer = 2 To 5
                                        sDesc = sDesc.Replace("%object" & i & "%", "another object")
                                        sDesc = sDesc.Replace("%character" & i & "%", "another character")
                                    Next
                                    sDesc = sDesc.Replace("%text%", "something")

                                    Dim mi As New ToolStripMenuItem(sDesc, Nothing, AddressOf miAddSpecificTaskForLocation)
                                    mi.Tag = tas.Key
                                    arlMenuItems.Add(mi)
                                End If
                            Next
                        End If
                    Next
                    arlMenuItems.Sort(New MenuItemComparer)
                    miAddSpecificTask.DropDownItems.AddRange(CType(arlMenuItems.ToArray(GetType(ToolStripMenuItem)), ToolStripMenuItem()))
                    bAddSpecific = miAddSpecificTask.DropDownItems.Count > 0
                    If loc IsNot Nothing Then bAddObject = True
                ElseIf Adventure.htblTasks.ContainsKey(sItemKey) Then
                    ' Add Specific task from General task
                    Dim tas As clsTask = Adventure.htblTasks(sItemKey)
                    If tas IsNot Nothing Then bAddSpecific = tas.TaskType = clsTask.TaskTypeEnum.General
                ElseIf Adventure.htblObjects.ContainsKey(sItemKey) Then
                    ' Add Specific tasks from Objects
                    miAddSpecificTask.DropDownItems.Clear()
                    Dim arlMenuItems As New ArrayList
                    Dim ob As clsObject = Adventure.htblObjects(sItemKey)
                    'For Each tas As clsTask In Adventure.htblTasks.Values
                    For Each tas As clsTask In Adventure.Tasks(clsAdventure.TasksListEnum.GeneralAndOverrideableSpecificTasks).Values
                        If Not tas.PreventOverriding Then ' tas.TaskType = clsTask.TaskTypeEnum.General AndAlso 
                            For Each s As String In tas.References
                                If s = "%object1%" OrElse s = "%object%" OrElse s = "%objects%" Then
                                    Dim refs As New Dictionary(Of String, clsItem)
                                    refs.Add(s.Replace("%object", "ReferencedObject").Replace("%", ""), ob)
                                    If PassRestrictions(tas.arlRestrictions, refs, tas) Then
                                        Dim sDesc As String = tas.MakeNice.Replace("%object1%", ob.FullName).Replace("%object%", ob.FullName).Replace("%objects%", ob.FullName)
                                        sDesc = sDesc.Replace("%character%", "a character").Replace("%character1%", "a character").Replace("%characters%", "a character").Replace("%location%", "a location")
                                        For i As Integer = 2 To 5
                                            sDesc = sDesc.Replace("%object" & i & "%", "another object")
                                            sDesc = sDesc.Replace("%character" & i & "%", "another character")
                                        Next
                                        sDesc = sDesc.Replace("%text%", "something")

                                        Dim mi As New ToolStripMenuItem(sDesc, Nothing, AddressOf miAddSpecificTaskForObject)
                                        mi.Tag = tas.Key
                                        arlMenuItems.Add(mi)
                                    End If
                                End If
                            Next
                        End If
                    Next
                    arlMenuItems.Sort(New MenuItemComparer)
                    miAddSpecificTask.DropDownItems.AddRange(CType(arlMenuItems.ToArray(GetType(ToolStripMenuItem)), ToolStripMenuItem()))
                    bAddSpecific = miAddSpecificTask.DropDownItems.Count > 0
                    If ob IsNot Nothing Then bAddSubObject = True
                ElseIf Adventure.htblCharacters.ContainsKey(sItemKey) Then
                    ' Add Specific tasks from Objects
                    miAddSpecificTask.DropDownItems.Clear()
                    Dim arlMenuItems As New ArrayList
                    Dim ch As clsCharacter = Adventure.htblCharacters(sItemKey)

                    For Each tas As clsTask In Adventure.Tasks(clsAdventure.TasksListEnum.GeneralAndOverrideableSpecificTasks).Values
                        If Not tas.PreventOverriding Then
                            For Each s As String In tas.References
                                If s = "%character1%" OrElse s = "%character%" OrElse s = "%characters%" Then
                                    Dim sDesc As String = tas.MakeNice.Replace("%character1%", ch.Name).Replace("%character%", ch.Name).Replace("%characters%", ch.Name)
                                    sDesc = sDesc.Replace("%object%", "an object").Replace("%object1%", "an object").Replace("%objects%", "an object").Replace("%location%", "a location")
                                    For i As Integer = 2 To 5
                                        sDesc = sDesc.Replace("%object" & i & "%", "another object")
                                        sDesc = sDesc.Replace("%character" & i & "%", "another character")
                                    Next
                                    sDesc = sDesc.Replace("%text%", "something")

                                    Dim mi As New ToolStripMenuItem(sDesc, Nothing, AddressOf miAddSpecificTaskForCharacter)
                                    mi.Tag = tas.Key
                                    arlMenuItems.Add(mi)
                                End If
                            Next
                        End If
                    Next
                    arlMenuItems.Sort(New MenuItemComparer)
                    miAddSpecificTask.DropDownItems.AddRange(CType(arlMenuItems.ToArray(GetType(ToolStripMenuItem)), ToolStripMenuItem()))
                    bAddSpecific = miAddSpecificTask.DropDownItems.Count > 0
                    If ch IsNot Nothing Then bAddSubObject = True
                ElseIf Adventure.dictFolders.ContainsKey(sItemKey) Then
                    Dim bExportVisible As Boolean = Not fGenerator.SimpleMode AndAlso Adventure.dictFolders.ContainsKey(sItemKey)
                    sep4.Visible = bExportVisible
                    miExportFolder.Visible = bExportVisible
                    miExportFolder.Tag = sItemKey
                End If
            End If
            miAddSpecificTask.Visible = bAddSpecific
            miAddObjectToLocation.Visible = bAddObject
            miAddSubObject.Visible = bAddSubObject
            sep1.Visible = True
            miEdit.Enabled = lstContents.SelectedItems.Count = 1
            miCut.Visible = True
            miCopy.Visible = True
            miDelete.Visible = True
            miRename.Visible = True
            miRename.Enabled = lstContents.SelectedItems.Count = 1 AndAlso lstContents.SelectedItems(0).SubItems(2).Text <> "Object"
            miView.Visible = False
            miSortBy.Visible = False
            miGroupBy.Visible = False
            sep2.Visible = False
            miPaste.Visible = False
            miNew.Visible = False            
        Else
            ' Display the list items            
            miEdit.Visible = False
            miAddSpecificTask.Visible = False
            If lstContents.SelectedItems.Count > 0 Then
                miCut.Visible = True
                miDelete.Visible = True
                miCopy.Visible = True
            Else
                miCut.Visible = False
                miDelete.Visible = False
                miCopy.Visible = False
            End If
            miRename.Visible = False
            miView.Visible = True
            miSortBy.Visible = True
            miGroupBy.Visible = True
            miPaste.Visible = True
            sep2.Visible = True
            miPaste.Enabled = CopiedItems IsNot Nothing AndAlso CopiedItems.Count > 0
            miNew.Visible = True
            miExportFolder.Visible = Not fGenerator.SimpleMode
            sep4.Visible = Not fGenerator.SimpleMode
            miExportFolder.Tag = ""
        End If
        'miDelete.Enabled = False ' for now

    End Sub


    Private Sub SetViewCheck(ByVal ViewType As Infragistics.Win.UltraWinListView.UltraListViewStyle)

        Select Case ViewType
            Case UltraListViewStyle.Details
                miViewType_Click(miDetails, Nothing)
            Case UltraListViewStyle.Icons
                miViewType_Click(miIcons, Nothing)
            Case UltraListViewStyle.List
                miViewType_Click(miList, Nothing)
                'Case UltraListViewStyle.Thumbnails
                '    miViewType_Click(miThumbnails, Nothing)
                'Case UltraListViewStyle.Tiles
                '    miViewType_Click(miTiles, Nothing)
        End Select

    End Sub

    Private Sub miViewType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miDetails.Click, miList.Click, miIcons.Click

        'miTiles.Checked = False
        miDetails.Checked = False
        miList.Checked = False
        'miThumbnails.Checked = False
        miIcons.Checked = False
        CType(sender, ToolStripMenuItem).Checked = True

        Dim View As Infragistics.Win.UltraWinListView.UltraListViewStyle = UltraListViewStyle.Icons
        Select Case True
            'Case sender Is miTiles
            '    View = UltraListViewStyle.Tiles
            Case sender Is miDetails
                View = UltraListViewStyle.Details
            Case sender Is miList
                View = UltraListViewStyle.List
                'Case sender Is miThumbnails
                '    View = UltraListViewStyle.Thumbnails
            Case sender Is miIcons
                View = UltraListViewStyle.Icons
        End Select

        folder.ViewType = View
        lstContents.View = View
        RaiseEvent ViewTypeChanged(Me, View)

    End Sub


    Public Sub RemoveSelectedItems()

        If MessageBox.Show("Are you sure you wish to remove th" & IIf(lstContents.SelectedItems.Count = 1, "is item", "ese items").ToString & "?", "Remove Items from Location", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For i As Integer = lstContents.Items.Count - 1 To 0 Step -1
                If lstContents.Items(i).IsSelected Then
                    Dim item As clsItem = Adventure.dictAllItems(lstContents.Items(i).SubItems(3).Text)

                    If TypeOf item Is clsObject Then
                        Dim ob As clsObject = CType(item, clsObject)
                        Dim loc As New clsObjectLocation
                        If ob.IsStatic Then
                            loc.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.NoRooms
                        Else
                            loc.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.Hidden
                        End If
                        loc.Key = ""
                        ob.Move(loc)
                    ElseIf TypeOf item Is clsCharacter Then
                        Dim ch As clsCharacter = CType(item, clsCharacter)
                        Dim loc As New clsCharacterLocation(ch)
                        loc.ExistWhere = clsCharacterLocation.ExistsWhereEnum.Hidden
                        loc.Key = ""
                        ch.Move(loc)
                    End If

                    lstContents.Items.RemoveAt(i)
                    Adventure.Changed = True
                End If
            Next
        End If

    End Sub


    Public Property View As UltraListViewStyle
        Get
            Return lstContents.View
        End Get
        Set(value As UltraListViewStyle)
            lstContents.View = value
            SortColumn = 0
            SortDirection = Sorting.Ascending
            lstContents.MainColumn.Sorting = SortDirection
            lstContents.Items.RefreshSort(True)
        End Set
    End Property


    Private Sub miEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEdit.Click, lstContents.ItemDoubleClick ', lstContents.DoubleClick
        Edit()
    End Sub


    Public Function SelectedKeys() As Generic.List(Of String)
        Dim sKeys As New Generic.List(Of String)
        For Each item As UltraListViewItem In lstContents.SelectedItems
            sKeys.Add(item.SubItems(3).Text)
        Next
        Return sKeys
    End Function

    Private Sub miCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCut.Click
        CutItems(SelectedKeys)
    End Sub

    Private Sub miCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCopy.Click
        CopyItems(SelectedKeys)
    End Sub

    Private Sub miDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDelete.Click
        DeleteItems(SelectedKeys)
    End Sub

    Private Sub miRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRename.Click
        If lstContents.ActiveItem IsNot Nothing Then Rename(lstContents.ActiveItem)
    End Sub

    Private Sub miPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPaste.Click
        PasteItems()
    End Sub

    Private Sub miSortBy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSortName.Click, miSortCreationDate.Click, miSortType.Click, miSortModifiedDate.Click, miSortTaskPriority.Click

        If SortDirection = Sorting.None Then
            SortDirection = Sorting.Ascending
            miSortAscending.Checked = True
        End If

        Select Case True
            Case sender Is miSortName
                lstContents.MainColumn.Sorting = SortDirection
                SortColumn = 0
            Case sender Is miSortCreationDate
                lstContents.SubItemColumns(0).Sorting = SortDirection
                SortColumn = 1
            Case sender Is miSortModifiedDate
                lstContents.SubItemColumns(1).Sorting = SortDirection
                SortColumn = 2
            Case sender Is miSortType
                lstContents.SubItemColumns(2).Sorting = SortDirection
                SortColumn = 3
            Case sender Is miSortTaskPriority
                lstContents.SubItemColumns(4).Sorting = SortDirection
                SortColumn = 5
        End Select
        lstContents.Items.RefreshSort(True)

        miSortByNone.Visible = True
        miSortByNone.Checked = False
        miSortAscending.Enabled = True
        miSortDescending.Enabled = True
        miSortName.Checked = False
        miSortCreationDate.Checked = False
        miSortModifiedDate.Checked = False
        miSortTaskPriority.Checked = False
        miSortType.Checked = False
        CType(sender, ToolStripMenuItem).Checked = True

        folder.SortColumn = SortColumn

    End Sub


    Private Sub miSortDirection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSortAscending.Click, miSortDescending.Click, miSortByNone.Click

        Select Case True
            Case sender Is miSortAscending
                SortDirection = Sorting.Ascending
                miSortByNone.Visible = True
            Case sender Is miSortDescending
                SortDirection = Sorting.Descending
                miSortByNone.Visible = True
            Case sender Is miSortByNone
                SortDirection = Sorting.None
                lstContents.MainColumn.Sorting = SortDirection
                SortColumn = -1
                miSortName.Checked = False
                miSortCreationDate.Checked = False
                miSortModifiedDate.Checked = False
                miSortTaskPriority.Checked = False
                miSortType.Checked = False
                miSortByNone.Visible = False
                miSortAscending.Enabled = False
                miSortDescending.Enabled = False
        End Select

        If SortColumn > -1 Then
            If SortColumn = 0 Then
                lstContents.MainColumn.Sorting = SortDirection
            Else
                lstContents.SubItemColumns(SortColumn - 1).Sorting = SortDirection
            End If
            lstContents.Items.RefreshSort(True)
        End If

        miSortAscending.Checked = False
        miSortDescending.Checked = False
        CType(sender, ToolStripMenuItem).Checked = True

        folder.SortDirection = SortDirection

    End Sub


    Private Sub Rename(ByVal lvi As UltraListViewItem)
        lvi.BeginEdit()
    End Sub


    Public Sub Edit(Optional ByVal sEditType As String = "", Optional ByVal tasGeneral As clsTask = Nothing, Optional ByVal sKey As String = "")

        If lstContents.ActiveItem Is Nothing AndAlso sEditType = "" Then Exit Sub

        If sEditType = "" Then
            sEditType = lstContents.ActiveItem.SubItems("sType").Text
            sKey = lstContents.ActiveItem.Key '.SubItems("sKey").Text
            While sKey.EndsWith("$")
                sKey = ChopLast(sKey)
            End While
        End If


        Select Case sEditType
            Case "Folder"
                'For Each child As frmFolder In fGenerator.MdiChildren
                '    If child.Folder.folder.Key = sKey Then
                '        child.Folder.SetActive()
                '        Exit Sub
                '    End If
                'Next
                'folder.Visible = False
                'LoadFolder(sKey)
                'SetNodeInTree()
                fGenerator.FolderList1.OpenNewFolder(sKey)
            Case "Location"
                Dim loc As clsLocation
                If sKey <> "" Then loc = Adventure.htblLocations(sKey) Else loc = New clsLocation
                loc.EditItem()
            Case "Object"
                Dim ob As clsObject
                If sKey <> "" Then ob = Adventure.htblObjects(sKey) Else ob = New clsObject
                ob.EditItem()
            Case "Task"
                Dim tas As clsTask
                If sKey <> "" Then tas = Adventure.htblTasks(sKey) Else tas = New clsTask
                If tasGeneral IsNot Nothing Then
                    tas.TaskType = clsTask.TaskTypeEnum.Specific
                    tas.GeneralKey = tasGeneral.Key
                    ReDim tas.Specifics(-1)
                End If
                tas.EditItem()
            Case "Event"
                Dim ev As clsEvent
                If sKey <> "" Then ev = Adventure.htblEvents(sKey) Else ev = New clsEvent
                ev.EditItem()
            Case "Character"
                Dim ch As clsCharacter
                If sKey <> "" Then ch = Adventure.htblCharacters(sKey) Else ch = New clsCharacter
                ch.EditItem()
            Case "Variable"
                Dim var As clsVariable
                If sKey <> "" Then var = Adventure.htblVariables(sKey) Else var = New clsVariable
                var.EditItem()
            Case "Hint"
                Dim hint As clsHint
                If sKey <> "" Then hint = Adventure.htblHints(sKey) Else hint = New clsHint
                hint.EditItem()
            Case "Group"
                Dim grp As clsGroup
                If sKey <> "" Then grp = Adventure.htblGroups(sKey) Else grp = New clsGroup
                grp.EditItem()
            Case "Property"
                Dim prop As clsProperty
                If sKey <> "" Then prop = Adventure.htblAllProperties(sKey) Else prop = New clsProperty
                prop.EditItem()
            Case "Text Override"
                Dim ALR As clsALR
                If sKey <> "" Then ALR = Adventure.htblALRs(sKey) Else ALR = New clsALR
                ALR.EditItem()
            Case "User Function"
                Dim UDF As clsUserFunction
                If sKey <> "" Then UDF = Adventure.htblUDFs(sKey) Else UDF = New clsUserFunction
                UDF.EditItem()
            Case "Synonym"
                Dim Synonym As clsSynonym
                If sKey <> "" Then Synonym = Adventure.htblSynonyms(sKey) Else Synonym = New clsSynonym
                Synonym.EditItem()
            Case Else
                TODO()
        End Select

    End Sub

    Private Sub miNewFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewFolder.Click

        Dim newFolder As New clsFolder
        newFolder.Key = newFolder.GetNewKey ' Adventure.GetNewKey("Folder")
        newFolder.Name = "New Folder"
        Adventure.dictFolders.Add(newFolder.Key, newFolder)

        Dim subitems() As UltraListViewSubItem = {New UltraListViewSubItem, New UltraListViewSubItem, New UltraListViewSubItem, New UltraListViewSubItem}
        subitems(0).Value = newFolder.Created
        subitems(1).Value = newFolder.LastUpdated
        subitems(2).Value = "Folder"
        subitems(3).Value = newFolder.Key

        Dim itmFolder As New UltraListViewItem(newFolder.Name, subitems)
        itmFolder.Key = newFolder.Key
        itmFolder.Appearance.Image = My.Resources.imgFolderClosed16
        lstContents.Items.Add(itmFolder)

        fGenerator.FolderList1.AddFolder(newFolder, fGenerator.FolderList1.treeFolders.GetNodeByKey(folder.Key))
        folder.Members.Add(newFolder.Key)

        Rename(itmFolder)

    End Sub

    Private Sub miNewLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewLocation.Click
        fGenerator.sDestinationList = folder.Name
        Dim fLocation As New frmLocation(New clsLocation, True)
    End Sub

    Private Sub miNewObject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewObject.Click
        fGenerator.sDestinationList = folder.Name
        Dim fObject As New frmObject(New clsObject, True)
    End Sub

    Private Sub miNewEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewEvent.Click
        fGenerator.sDestinationList = folder.Name
        Dim fEvent As New frmEvent(New clsEvent, True)
    End Sub

    Private Sub miNewTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewTask.Click
        fGenerator.sDestinationList = folder.Name
        Dim fTask As New frmTask(New clsTask, True)
    End Sub

    Private Sub miNewCharacter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewCharacter.Click
        fGenerator.sDestinationList = folder.Name
        Dim fCharacter As New frmCharacter(New clsCharacter, True)
    End Sub

    Private Sub miNewGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewGroup.Click
        fGenerator.sDestinationList = folder.Name
        Dim fGroup As New frmGroup(New clsGroup, True)
    End Sub

    Private Sub miNewHint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewHint.Click
        fGenerator.sDestinationList = folder.Name
        Dim fHint As New frmHint(New clsHint, True)
    End Sub

    Private Sub miNewVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewVariable.Click
        fGenerator.sDestinationList = folder.Name
        Dim fVariable As New frmVariable(New clsVariable, True)
    End Sub

    Private Sub miNewProperty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewProperty.Click
        fGenerator.sDestinationList = folder.Name
        Dim fProperty As New frmProperty(New clsProperty, True)
    End Sub

    Private Sub miNewALR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewALR.Click
        fGenerator.sDestinationList = folder.Name
        Dim fALR As New frmTextOverride(New clsALR)
    End Sub

    Private Sub miNewSynonym_Click(sender As Object, e As EventArgs) Handles miNewSynonym.Click
        fGenerator.sDestinationList = folder.Name
        Dim fSynonym As New frmSynonym(New clsSynonym)
    End Sub

    Private Sub miNewUserFunction_Click(sender As Object, e As EventArgs) Handles miNewUserFunction.Click
        fGenerator.sDestinationList = folder.Name
        Dim fFunction As New frmUserFunction(New clsUserFunction)
    End Sub

    Private Sub lstContents_ItemExitedEditMode(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinListView.ItemExitedEditModeEventArgs) Handles lstContents.ItemExitedEditMode

        Dim sKey As String = e.Item.Key
        Select Case Adventure.GetTypeFromKeyNice(sKey)
            Case "Folder"
                Adventure.dictFolders(sKey).Name = e.Item.Text
                fGenerator.FolderList1.treeFolders.GetNodeByKey(sKey).Text = e.Item.Text
            Case "Location"
                Adventure.htblLocations(sKey).ShortDescription = New Description(e.Item.Text)
                'Case "Object"
                '    Adventure.htblObjects(sKey).
            Case "Task"
                Adventure.htblTasks(sKey).Description = e.Item.Text
            Case "Event"
                Adventure.htblEvents(sKey).Description = e.Item.Text
            Case "Character"
                Adventure.htblCharacters(sKey).ProperName = e.Item.Text
            Case "Property"
                Adventure.htblAllProperties(sKey).Description = e.Item.Text
            Case "Variable"
                Adventure.htblVariables(sKey).Name = e.Item.Text
            Case "Hint"
                Adventure.htblHints(sKey).Question = e.Item.Text
            Case "Group"
                Adventure.htblGroups(sKey).Name = e.Item.Text
            Case "Text Override"
                Adventure.htblALRs(sKey).OldText = e.Item.Text
            Case Else
                TODO()
        End Select
        bRenaming = False

    End Sub

    Private Sub miGroupByType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miGroupByType.Click

        lstContents.Groups.Clear()
        For Each sType As String In New String() {"Folders", "Locations", "Objects - Static", "Objects - Dynamic", "Tasks - System", "Tasks - General", "Tasks - Specific", "Events", "Characters", "Groups", "Properties", "Variables", "Text Replacements"}
            Dim grp As New UltraListViewGroup
            grp.Text = sType
            lstContents.Groups.Add(grp)
            For Each itm As UltraListViewItem In lstContents.Items
                Select Case sType
                    Case "Folders", "Locations", "Events", "Characters", "Groups", "Variables"
                        If itm.SubItems(2).Text & "s" = sType Then itm.Group = grp
                    Case "Objects - Static"
                        If itm.SubItems(2).Text = "Object" AndAlso Adventure.htblObjects(itm.SubItems(3).Text).IsStatic Then itm.Group = grp
                    Case "Objects - Dynamic"
                        If itm.SubItems(2).Text = "Object" AndAlso Not Adventure.htblObjects(itm.SubItems(3).Text).IsStatic Then itm.Group = grp
                    Case "Tasks - System"
                        If itm.SubItems(2).Text = "Task" AndAlso Adventure.htblTasks(itm.SubItems(3).Text).TaskType = clsTask.TaskTypeEnum.System Then itm.Group = grp
                    Case "Tasks - General"
                        If itm.SubItems(2).Text = "Task" AndAlso Adventure.htblTasks(itm.SubItems(3).Text).TaskType = clsTask.TaskTypeEnum.General Then itm.Group = grp
                    Case "Tasks - Specific"
                        If itm.SubItems(2).Text = "Task" AndAlso Adventure.htblTasks(itm.SubItems(3).Text).TaskType = clsTask.TaskTypeEnum.Specific Then itm.Group = grp
                    Case "Properties"
                        If itm.SubItems(2).Text = "Property" Then itm.Group = grp
                    Case "Text Replacements"
                        If itm.SubItems(2).Text = "ALR" Then itm.Group = grp
                    Case Else
                        TODO("Group type " & sType)
                End Select

            Next
        Next
        miGroupByType.Checked = True
        miGroupByNone.Visible = True
        miGroupAscending.Enabled = True
        miGroupDescending.Enabled = True

        If Not folder.GroupDirection = Sorting.Descending Then miGroupAscending_Click(Nothing, Nothing)

        folder.GroupBy = 1
    End Sub


    Private Sub miGroupByNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miGroupByNone.Click
        lstContents.Groups.Clear()
        miGroupByType.Checked = False
        miGroupByNone.Visible = False
        miGroupAscending.Enabled = False
        miGroupDescending.Enabled = False
        folder.GroupBy = 0
    End Sub

    Private Sub miGroupAscending_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miGroupAscending.Click

        miGroupAscending.Checked = True
        miGroupDescending.Checked = False
        lstContents.Groups.Sort(Sorting.Ascending)
        folder.GroupDirection = Sorting.Ascending

    End Sub

    Private Sub miGroupDescending_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miGroupDescending.Click

        miGroupAscending.Checked = False
        miGroupDescending.Checked = True
        lstContents.Groups.Sort(Sorting.Descending)
        folder.GroupDirection = Sorting.Descending

    End Sub


    Private Sub folder_ColumnChanged(ByVal sender As Object, ByVal iCol As Integer, ByVal bVisible As Boolean) 'Handles folder.ColumnChanged
        If lstContents.SubItemColumns.Count = 5 Then
            If bVisible Then
                lstContents.SubItemColumns(iCol).VisibleInDetailsView = Infragistics.Win.DefaultableBoolean.True
            Else
                lstContents.SubItemColumns(iCol).VisibleInDetailsView = Infragistics.Win.DefaultableBoolean.False
            End If
        End If
    End Sub


#Region "Drag/Drop"

    Private SelectedItems As New Generic.List(Of UltraListViewItem)

    Private Sub lstContents_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstContents.MouseUp
        SelectedItems.Clear()
        For Each item As UltraListViewItem In lstContents.SelectedItems
            SelectedItems.Add(item)
        Next
    End Sub


    Private ptStart As Point
    Private bAllowedToDrag As Boolean = False
    Private Sub lstContents_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstContents.MouseDown

        'If e.Button = Windows.Forms.MouseButtons.Right Then
        SetActive()

        Dim itemCursor As UltraListViewItem = lstContents.ItemFromPoint(lstContents.PointToClient(MousePosition))
        bAllowedToDrag = (itemCursor IsNot Nothing) AndAlso folder IsNot Nothing ' AndAlso SelectedItems.Contains(itemCursor)) ' itemCursor.IsSelected) ' Only go into drag mode if we re-selected a selected line
        ptStart = lstContents.PointToClient(MousePosition)

        ' If user right-clicks on the text (rather than just the item), select the item
        'If itemCursor.UIElement IsNot Nothing Then
        '    itemCursor = itemCursor
        'End If
        If itemCursor IsNot Nothing AndAlso Not itemCursor.IsSelected AndAlso lstContents.PointToClient(MousePosition).X < lstContents.Width / 2 Then
            lstContents.SelectedItems.Clear()
            If lstContents.Items.Contains(itemCursor) Then
                lstContents.SelectedItems.Add(itemCursor)
                lstContents.ActiveItem = itemCursor
            End If            
        End If

        'End If

    End Sub


    Private Sub SetHotTrackColours()
        Dim itemCursor As UltraListViewItem = lstContents.ItemFromPoint(lstContents.PointToClient(MousePosition))
        If itemCursor IsNot Nothing AndAlso itemCursor.IsSelected Then
            ' Hot-tracking over a selected item            
            lstContents.ItemSettings.HotTrackingAppearance.BackColor = Color.FromArgb(229, 245, 253)
            lstContents.ItemSettings.HotTrackingAppearance.BackColor2 = Color.FromArgb(201, 234, 250)
        Else
            ' Normal hot-tracking            
            lstContents.ItemSettings.HotTrackingAppearance.BackColor = Color.FromArgb(247, 252, 254)
            lstContents.ItemSettings.HotTrackingAppearance.BackColor2 = Color.FromArgb(234, 246, 253)
        End If
    End Sub


    Private Sub lstContents_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstContents.MouseMove

        SetHotTrackColours()

        'Dim itemCursor As UltraListViewItem = lstContents.ItemFromPoint(lstContents.PointToClient(MousePosition))
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso bAllowedToDrag Then
            ' This line prevents the DoubleClick event from firing...
            Dim ptNow As Point = lstContents.PointToClient(MousePosition)
            ' Make sure mouse has moved at least 3 pixels before starting drag
            If Math.Abs(ptStart.X - ptNow.X) > 3 OrElse Math.Abs(ptStart.Y - ptNow.Y) > 3 Then
                lstContents.DoDragDrop(lstContents.SelectedItems, DragDropEffects.Move Or DragDropEffects.Scroll)
            End If
        End If

    End Sub


    Private Sub tmrActivate_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrActivate.Tick
        tmrActivate.Stop()
        ' Only activate the form if the mouse is still inside it
        'Dim ptCursor As Point = lstContents.PointToClient(MousePosition)
        If MouseButtons <> Windows.Forms.MouseButtons.None AndAlso bMouseInFolder Then
            'AndAlso ptCursor.X > 0 AndAlso ptCursor.X < lstContents.Width _
            'AndAlso ptCursor.Y > 0 AndAlso ptCursor.Y < lstContents.Height Then
            If TypeOf Me.Parent Is frmFolder Then CType(Me.Parent, frmFolder).Activate()
        End If

    End Sub


    Private Sub lstContents_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstContents.DragEnter

        If e.Data.GetDataPresent("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection") Then
            With CType(e.Data.GetData("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection"), UltraListViewSelectedItemsCollection)
                If .Count > 0 AndAlso .Item(0).Control Is lstContents Then
                    ' Don't allow dragging to same list if we have a sort defined
                    If SortDirection <> Sorting.None Then
                        e.Effect = DragDropEffects.None
                        Exit Sub
                    End If
                Else
                    ' Don't allow dragging a folder into itself, or any sub-folder thereof                 
                    For i As Integer = .Count - 1 To 0 Step -1
                        Dim sItemKey As String = .Item(i).SubItems(3).Text
                        If folder IsNot Nothing AndAlso folder.Key = sItemKey Then
                            e.Effect = DragDropEffects.None
                            Exit Sub
                        End If
                        If Adventure.dictFolders.ContainsKey(sItemKey) Then
                            If Adventure.dictFolders(sItemKey).ContainsKey(folder.Key) Then
                                e.Effect = DragDropEffects.None
                                Exit Sub
                            End If
                        End If
                    Next
                End If
            End With
            If folder IsNot Nothing OrElse sParentKey <> "" Then
                e.Effect = DragDropEffects.Move
                tmrActivate.Interval = 750
                tmrActivate.Start()
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
        bMouseInFolder = True

    End Sub


    Private Sub lstContents_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstContents.DragOver

        Dim itemCursor As UltraListViewItem = lstContents.ItemFromPoint(lstContents.PointToClient(MousePosition))
        If itemCursor Is Nothing Then Exit Sub

        itemCursor.Activate()

        ' Make sure we scroll the list if we're dragging off top or bottom
        Dim ptItem As New Point(e.X, e.Y)
        ptItem = lstContents.PointToClient(ptItem)

        If ptItem.Y < lstContents.ItemSizeResolved.Height * CInt(IIf(lstContents.View = UltraListViewStyle.Details, 2, 1)) AndAlso itemCursor.Index > 0 Then
            lstContents.Items(itemCursor.Index - 1).BringIntoView()
            Threading.Thread.Sleep(15)
        End If

        If ptItem.Y > lstContents.Height - lstContents.ItemSizeResolved.Height AndAlso itemCursor.Index < lstContents.Items.Count - 1 Then
            lstContents.Items(itemCursor.Index + 1).BringIntoView()
            Threading.Thread.Sleep(15)
        End If

    End Sub


    Dim lItems As New Generic.List(Of UltraListViewItem)
    Private WithEvents tmrDrop As New Timer

    Private Sub lstContents_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstContents.DragDrop

        Try
            Dim bShownError As Boolean = False

            If e.Data.GetDataPresent("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection") Then
                Dim items As UltraListViewSelectedItemsCollection = CType(e.Data.GetData("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection"), UltraListViewSelectedItemsCollection)
                If items.Count = 0 Then Exit Sub
                Dim lstSource As UltraListView = items.First.Control
                lstSource.BeginUpdate()
                lstContents.BeginUpdate()
                If lstSource IsNot lstContents Then lstContents.SelectedItems.Clear()
                lItems.Clear()
                For i As Integer = items.Count - 1 To 0 Step -1
                    Dim itm As UltraListViewItem = items(i)
                    Dim sItemKey As String = itm.SubItems(3).Text
                    Dim iOldIndex As Integer = itm.Index

                    If items.Count = 1 AndAlso lstContents.ActiveItem Is itm Then
                        lstSource.EndUpdate()
                        lstContents.EndUpdate()
                        Exit Sub
                    End If

                    If folder IsNot Nothing Then
                        Adventure.dictFolders(CType(itm.Control.Parent, Folder).folder.Key).Members.Remove(sItemKey)

                        Dim treenode As Infragistics.Win.UltraWinTree.UltraTreeNode = fGenerator.FolderList1.treeFolders.GetNodeByKey(sItemKey)
                        If treenode IsNot Nothing Then treenode.Parent.Nodes.Remove(treenode)

                        itm.Control.Items.Remove(itm)
                        Dim iDropIndex As Integer = 0

                        If lstContents.ActiveItem IsNot Nothing Then
                            iDropIndex = lstContents.ActiveItem.Index

                            ' If we are moving an item down in the same list, increase the index
                            ' by one, as we want to slot it in the item below what we're dropping on
                            If lstSource Is lstContents AndAlso iOldIndex <= iDropIndex Then iDropIndex += 1

                            ' If mouse is not over the active item, but is below it, 
                            ' and the active item is last in the list, add, don't insert
                            If iDropIndex = lstContents.Items.Count - 1 Then
                                Dim itemCursor As UltraListViewItem = lstContents.ItemFromPoint(lstContents.PointToClient(MousePosition))
                                If itemCursor Is Nothing Then iDropIndex += 1
                            End If
                        End If

                        folder.Members.Insert(iDropIndex, sItemKey)

                        'Debug.WriteLine("Inserting " & itm.Text & " at position " & iDropIndex)
                        lstContents.Items.Insert(iDropIndex, itm)
                        lItems.Add(itm)
                        If i = 0 Then
                            Try
                                If lstContents.Groups.Count > 0 Then miGroupByType_Click(Nothing, Nothing) ' Ensure it's grouped correctly
                                itm.Activate() ' Sometimes get an Object Ref error here, even when itm exists
                            Catch
                            End Try
                        End If

                        If treenode IsNot Nothing Then
                            ' Convert folder drop position to tree position (i.e. ignore non-folders)
                            Dim iTreeIndex As Integer = 0
                            For iFolder As Integer = 0 To iDropIndex - 1
                                If Adventure.dictFolders.ContainsKey(folder.Members(iFolder)) Then iTreeIndex += 1
                            Next
                            Dim treenodedest As Infragistics.Win.UltraWinTree.UltraTreeNode = fGenerator.FolderList1.treeFolders.GetNodeByKey(folder.Key)
                            If treenodedest IsNot Nothing Then treenodedest.Nodes.Insert(iTreeIndex, treenode) ' .Add(treenode)
                        End If
                    Else
                        Dim item As clsItem = Adventure.dictAllItems(itm.SubItems(3).Text)
                        If item IsNot Nothing Then
                            If TypeOf item Is clsObject OrElse TypeOf item Is clsCharacter Then
                                If Not lstContents.Items.Exists(itm.Key) Then
                                    Dim itmNew As UltraListViewItem = itm.Clone(True)
                                    lstContents.Items.Add(itmNew)
                                    If TypeOf item Is clsObject Then
                                        Dim ob As clsObject = CType(item, clsObject)
                                        Dim loc As New clsObjectLocation
                                        If ob.IsStatic Then
                                            loc.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.SingleLocation
                                        Else
                                            loc.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InLocation
                                        End If
                                        loc.Key = sParentKey
                                        ob.Move(loc)
                                    ElseIf TypeOf item Is clsCharacter Then
                                        Dim ch As clsCharacter = CType(item, clsCharacter)
                                        Dim loc As New clsCharacterLocation(ch)
                                        loc.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
                                        loc.Key = sParentKey
                                        ch.Move(loc)
                                    End If
                                    Adventure.Changed = True
                                Else
                                    ErrMsg("This location already contains item """ & item.CommonName & """")
                                End If
                            Else
                                If Not bShownError Then
                                    ErrMsg("Only Objects and Characters may be dragged into the Location Contents window")
                                    bShownError = True
                                End If
                            End If
                        End If
                    End If

                Next

                tmrDrop.Enabled = True
                tmrDrop.Interval = 1
                tmrDrop.Start()
                lstSource.EndUpdate()
                lstContents.EndUpdate()

            End If
        Catch ex As Exception
            ErrMsg("Folder drop error", ex)
        End Try

    End Sub

    Private Sub tmrDrop_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrDrop.Tick
        tmrDrop.Enabled = False
        For i As Integer = lItems.Count - 1 To 0 Step -1
            lstContents.SelectedItems.Add(lItems(i))
        Next
        'For Each itm As UltraListViewItem In lItems
        '    lstContents.SelectedItems.Add(itm)
        'Next
    End Sub

#End Region


    Private Sub lstContents_ItemSelectionChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinListView.ItemSelectionChangedEventArgs) Handles lstContents.ItemSelectionChanged
        'Debug.WriteLine("Selection changed")
        'SetHotTrackColours()
        fGenerator.UTMMain.Tools("Cut").SharedProps.Enabled = lstContents.SelectedItems.Count > 0
        fGenerator.UTMMain.Tools("Copy").SharedProps.Enabled = lstContents.SelectedItems.Count > 0
        fGenerator.UTMMain.Tools("Delete").SharedProps.Enabled = lstContents.SelectedItems.Count > 0

        For Each li As UltraListViewItem In lstContents.SelectedItems
            If li.SubItems.Count > 2 AndAlso li.SubItems(2).Text = "Location" Then
                fGenerator.Map1.SelectNode(li.SubItems(3).Text)
            End If
        Next

    End Sub

    Private Sub Folder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Infragistics.Win.AppStyling.StyleManager.Load("../../Windows7.isl")
    End Sub


    Private Sub miAddSpecificTaskForObject(ByVal sender As Object, ByVal e As System.EventArgs)

        If lstContents.SelectedItems.Count = 1 Then
            Dim sTaskKey As String = CType(sender, ToolStripMenuItem).Tag.ToString
            Dim sObKey As String = lstContents.SelectedItems(0).SubItems(3).Text
            Dim tasGeneral As clsTask = Adventure.htblTasks(sTaskKey)

            Dim tas As New clsTask
            If tasGeneral IsNot Nothing Then
                tas.TaskType = clsTask.TaskTypeEnum.Specific
                tas.GeneralKey = tasGeneral.Key

                Dim bAdded As Boolean = False
                ReDim tas.Specifics(tasGeneral.References.Count - 1)
                For i As Integer = 0 To tasGeneral.References.Count - 1
                    tas.Specifics(i) = New clsTask.Specific
                    With tas.Specifics(i)
                        Select Case tasGeneral.References(i)
                            Case "%object%", "%object1%", "%objects%"
                                If Not bAdded Then
                                    .Type = ReferencesType.Object
                                    .Multiple = False
                                    .Keys.Add(sObKey)
                                    bAdded = True
                                End If
                            Case Else
                                ' Leave bare bones
                        End Select
                    End With
                Next

                'ReDim tas.Specifics(0)
                'tas.Specifics(0) = New clsTask.Specific
                'With tas.Specifics(0)
                '    .Type = ReferencesType.Object
                '    .Multiple = False
                '    .Keys.Add(sObKey)
                'End With                
            End If
            tas.Description = CType(sender, ToolStripMenuItem).Text
            fGenerator.sDestinationList = folder.Name
            tas.EditItem()
        End If

    End Sub


    Private Sub miAddSpecificTaskForLocation(ByVal sender As Object, ByVal e As System.EventArgs)

        If lstContents.SelectedItems.Count = 1 Then
            Dim sTaskKey As String = CType(sender, ToolStripMenuItem).Tag.ToString
            Dim sLocKey As String = lstContents.SelectedItems(0).SubItems(3).Text
            Dim tasGeneral As clsTask = Adventure.htblTasks(sTaskKey)

            Dim tas As New clsTask
            If tasGeneral IsNot Nothing Then
                tas.TaskType = clsTask.TaskTypeEnum.Specific
                tas.GeneralKey = tasGeneral.Key

                Dim bAdded As Boolean = False
                ReDim tas.Specifics(tasGeneral.References.Count - 1)
                For i As Integer = 0 To tasGeneral.References.Count - 1
                    tas.Specifics(i) = New clsTask.Specific
                    With tas.Specifics(i)
                        Select Case tasGeneral.References(i)
                            Case "%location%"
                                If Not bAdded Then
                                    .Type = ReferencesType.Location
                                    .Multiple = False
                                    .Keys.Add(sLocKey)
                                    bAdded = True
                                End If
                            Case Else
                                ' Leave bare bones
                        End Select
                    End With
                Next
            ElseIf sTaskKey = "PlayerEntersLocation" Then
                tas.TaskType = clsTask.TaskTypeEnum.System
                tas.LocationTrigger = sLocKey
            End If

            tas.Description = CType(sender, ToolStripMenuItem).Text
            fGenerator.sDestinationList = folder.Name
            tas.EditItem()
        End If

    End Sub


    Private Sub miAddSpecificTaskForCharacter(ByVal sender As Object, ByVal e As System.EventArgs)

        If lstContents.SelectedItems.Count = 1 Then
            Dim sTaskKey As String = CType(sender, ToolStripMenuItem).Tag.ToString
            Dim sChKey As String = lstContents.SelectedItems(0).SubItems(3).Text
            Dim tasGeneral As clsTask = Adventure.htblTasks(sTaskKey)

            Dim tas As New clsTask
            If tasGeneral IsNot Nothing Then
                tas.TaskType = clsTask.TaskTypeEnum.Specific
                tas.GeneralKey = tasGeneral.Key

                Dim bAdded As Boolean = False
                ReDim tas.Specifics(tasGeneral.References.Count - 1)
                For i As Integer = 0 To tasGeneral.References.Count - 1
                    tas.Specifics(i) = New clsTask.Specific
                    With tas.Specifics(i)
                        Select Case tasGeneral.References(i)
                            Case "%character%", "%character1%", "%characters%"
                                If Not bAdded Then
                                    .Type = ReferencesType.Character
                                    .Multiple = False
                                    .Keys.Add(sChKey)
                                    bAdded = True
                                End If
                            Case Else
                                ' Leave bare bones
                        End Select
                    End With
                Next
            End If
            tas.Description = CType(sender, ToolStripMenuItem).Text
            fGenerator.sDestinationList = folder.Name
            tas.EditItem()
        End If

    End Sub


    Private Sub miAddSpecificTask_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miAddSpecificTask.Click
        If lstContents.SelectedItems.Count = 1 AndAlso miAddSpecificTask.DropDownItems.Count = 0 Then
            Dim tas As clsTask = Adventure.htblTasks(lstContents.SelectedItems(0).SubItems(3).Text)
            Edit("Task", tas)
        End If
    End Sub


    Private Sub miAddObjectToLocation_Click(sender As Object, e As System.EventArgs) Handles miAddObjectToLocation.Click
        If lstContents.SelectedItems.Count = 1 AndAlso miAddObjectToLocation.DropDownItems.Count = 0 Then
            Dim sParentKey As String = lstContents.SelectedItems(0).SubItems(3).Text
            Dim ob As New clsObject
            Dim obLoc As New clsObjectLocation
            Dim sod As New clsProperty
            sod = Adventure.htblAllProperties("StaticOrDynamic").Copy
            ob.htblActualProperties.Add(sod)
            Dim sl As New clsProperty
            sl = Adventure.htblAllProperties("StaticLocation").Copy
            'sl.Value = sParentKey
            ob.htblActualProperties.Add(sl)
            ob.IsStatic = True
            obLoc.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.SingleLocation
            obLoc.Key = sParentKey
            ob.Move(obLoc)
            fGenerator.sDestinationList = folder.Name
            ob.EditItem()
        End If
    End Sub


    Private Sub miAddSubObject_Click(sender As Object, e As System.EventArgs) Handles miAddSubObject.Click
        If lstContents.SelectedItems.Count = 1 AndAlso miAddObjectToLocation.DropDownItems.Count = 0 Then
            Dim sParentKey As String = lstContents.SelectedItems(0).SubItems(3).Text
            Dim ob As New clsObject
            Dim obLoc As New clsObjectLocation
            Dim sod As New clsProperty
            sod = Adventure.htblAllProperties("StaticOrDynamic").Copy
            ob.htblActualProperties.Add(sod)
            Dim sl As New clsProperty
            sl = Adventure.htblAllProperties("StaticLocation").Copy
            ob.htblActualProperties.Add(sl)
            ob.IsStatic = True
            If Adventure.htblObjects.ContainsKey(sParentKey) Then
                obLoc.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.PartOfObject
            ElseIf Adventure.htblCharacters.ContainsKey(sParentKey) Then
                obLoc.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.PartOfCharacter
            End If
            obLoc.Key = sParentKey
            ob.Move(obLoc)
            fGenerator.sDestinationList = folder.Name
            ob.EditItem()
        End If
    End Sub


    Private Sub miAddItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miAddItem.Click

        fGenerator.sDestinationList = folder.Name
        Select Case miAddItem.Text
            Case "Add Location"
                Dim fLocation As New frmLocation(New clsLocation, True)
            Case "Add Object"
                Dim fObject As New frmObject(New clsObject, True)
            Case "Add Task"
                Dim fTask As New frmTask(New clsTask, True)
            Case "Add Event"
                Dim fEvent As New frmEvent(New clsEvent, True)
            Case "Add Character"
                Dim fCharacter As New frmCharacter(New clsCharacter, True)
            Case "Add Property"
                Dim fProperty As New frmProperty(New clsProperty, True)
            Case "Add Variable"
                Dim fVariable As New frmVariable(New clsVariable, True)
            Case "Add Text Override"
                Dim fALR As New frmTextOverride(New clsALR)
            Case "Add Group"
                Dim fGroup As New frmGroup(New clsGroup, True)
            Case "Add Hint"
                Dim fHint As New frmHint(New clsHint, True)
            Case "Add Synonym"
                Dim fSynonym As New frmSynonym(New clsSynonym)   
            Case "Add User Function"               
                Dim fFunction As New frmUserFunction(New clsUserFunction)
        End Select
    End Sub


    Private Sub lstContents_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lstContents.KeyUp
        'If lstContents.ActiveItem IsNot Nothing AndAlso lstContents.ActiveItem.IsInEditMode Then Exit Sub ' Not working for some reason
        If bRenaming Then Exit Sub

        If e.KeyData = Keys.Delete Then
            DeleteItems(SelectedKeys)
        End If
    End Sub

    Private Sub lstContents_ItemEnteredEditMode(sender As Object, e As Infragistics.Win.UltraWinListView.ItemEnteredEditModeEventArgs) Handles lstContents.ItemEnteredEditMode
        bRenaming = True
    End Sub

    Private Sub folder_MembersChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles folder.MembersChanged
        RaiseEvent MembersChanged(sender, e)
    End Sub

    Private Sub miExportFolder_Click(sender As Object, e As EventArgs) Handles miExportFolder.Click
        If miExportFolder.Tag.ToString = "" Then
            fGenerator.ExportModule(Me.folder.Key)
        Else
            fGenerator.ExportModule(miExportFolder.Tag.ToString)
        End If
    End Sub

End Class
