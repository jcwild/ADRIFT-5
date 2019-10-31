Imports Infragistics.Win.UltraWinTree


Public Class FolderList

    Private Const DESKTOP As String = "Desktop"

    Public WriteOnly Property HideLibrary() As Boolean
        Set(ByVal value As Boolean)
            treeFolders.BeginUpdate()
            ' Hide a folder if it is NOT empty, but only contains hidden items
            For Each node As UltraTreeNode In treeFolders.Nodes
                SetNodeVisible(node, Not value)
            Next          
            treeFolders.EndUpdate()
        End Set
    End Property


    Private Function SetNodeVisible(ByVal node As UltraTreeNode, ByVal bVisible As Boolean) As Boolean

        ' If all subnodes are folders and they're all hidden, hide the parent folder
        Dim bAllNodesHidden As Boolean = node.Nodes.Count > 0
        For Each subnode As UltraTreeNode In node.Nodes
            If SetNodeVisible(subnode, bVisible) Then bAllNodesHidden = False
        Next

        If Not bVisible Then
            Dim bAllHidden As Boolean = False
            If Adventure.dictFolders(node.Key).Members.Count > 0 Then
                bAllHidden = True
                If bAllNodesHidden Then
                    bAllHidden = True
                Else
                    For Each sKey As String In Adventure.dictFolders(node.Key).Members
                        Dim itmGen As clsItem = Adventure.dictAllItems(sKey)
                        If itmGen IsNot Nothing AndAlso Not (itmGen.IsLibrary AndAlso (TypeOf itmGen Is clsTask OrElse TypeOf itmGen Is clsProperty)) Then
                            bAllHidden = False
                            Exit For
                        End If
                    Next
                End If
            End If
            node.Visible = Not bAllHidden
        Else
            node.Visible = True
        End If

        Return node.Visible

    End Function


    Private Sub miLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLocation.Click        
        Dim fLocation As New frmLocation(New clsLocation, True)
    End Sub

    Private Sub miObject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miObject.Click
        Dim fObject As New frmObject(New clsObject, True)
    End Sub

    Private Sub miTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTask.Click
        Dim fTask As New frmTask(New clsTask, True)
    End Sub

    Private Sub miEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEvent.Click
        Dim fEvent As New frmEvent(New clsEvent, True)
    End Sub

    Private Sub miCharacter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCharacter.Click
        Dim fCharacter As New frmCharacter(New clsCharacter, True)
    End Sub

    Private Sub miGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miGroup.Click
        Dim fGroup As New frmGroup(New clsGroup, True)
    End Sub

    Private Sub miVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miVariable.Click
        Dim fVariable As New frmVariable(New clsVariable, True)
    End Sub

    Private Sub miTextOverride_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTextOverride.Click
        Dim fALR As New frmTextOverride(New clsALR)
    End Sub

    Private Sub miHint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miHint.Click
        Dim fHint As New frmHint(New clsHint, True)
    End Sub

    Private Sub miNewFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewFolder.Click
        AddNewFolder()
    End Sub

    Private Sub miRenameFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRenameFolder.Click
        If treeFolders.ActiveNode IsNot Nothing Then RenameFolder(treeFolders.ActiveNode)
    End Sub

    Private Sub miOpenInNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miOpenInNew.Click
        If treeFolders.ActiveNode IsNot Nothing Then OpenNewFolder(treeFolders.ActiveNode.Tag.ToString)
    End Sub

    Public Function AddFolder(ByVal folder As clsFolder, Optional ByVal nodeParent As UltraTreeNode = Nothing) As UltraTreeNode

        Dim nodeNew As UltraTreeNode
        If nodeParent IsNot Nothing Then
            If treeFolders.GetNodeByKey(folder.Key) IsNot Nothing Then
                nodeNew = treeFolders.GetNodeByKey(folder.Key)
                nodeNew.Text = folder.Name
            Else
                nodeNew = nodeParent.Nodes.Add(folder.Key, folder.Name)
            End If
        Else
            If folder.Key = "ROOT" Then
                nodeNew = treeFolders.Nodes.Add(folder.Key, folder.Name)
            Else
                nodeNew = treeFolders.Nodes("ROOT").Nodes.Add(folder.Key, folder.Name)
            End If
        End If
        nodeNew.Tag = folder.Key
        nodeNew.Override.NodeAppearance.Image = My.Resources.imgFolderClosed16
        nodeNew.Expanded = folder.Expanded

        For Each sMember As String In folder.Members
            If Adventure.dictFolders.ContainsKey(sMember) Then
                AddFolder(Adventure.dictFolders(sMember), nodeNew)
            End If
        Next

        Return nodeNew

    End Function


    Private Function AddNewFolder(Optional ByVal nodeParent As UltraTreeNode = Nothing, Optional ByVal sName As String = "", Optional ByRef node As UltraTreeNode = Nothing, Optional ByVal sFolderKey As String = "") As clsFolder

        If nodeParent Is Nothing Then nodeParent = treeFolders.ActiveNode

        Dim oFolder As New clsFolder(sFolderKey)        
        If Adventure IsNot Nothing Then
            Adventure.dictFolders.Add(oFolder.Key, oFolder)
            If nodeParent IsNot Nothing Then Adventure.dictFolders(SafeString(nodeParent.Tag)).Members.Add(oFolder.Key)
        End If
        If sName <> "" Then oFolder.Name = sName
        Dim nodeNew As UltraTreeNode = AddFolder(oFolder, nodeParent)
        If sName = "" Then RenameFolder(nodeNew)
        node = nodeNew
        For Each folder As frmFolder In fGenerator.MDIFolders
            If folder.Folder.folder.Key = nodeParent.Key Then
                folder.Folder.AddSingleItem(oFolder.Key)
            End If
        Next
        'UpdateListItem(oFolder.Key, oFolder.Name)
        Return oFolder

    End Function


    Friend Sub RenameFolder(ByVal node As UltraTreeNode)
        node.BeginEdit()
    End Sub

    Private Sub treeFolders_AfterCollapse(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.NodeEventArgs) Handles treeFolders.AfterCollapse
        Adventure.dictFolders(e.TreeNode.Tag.ToString).Expanded = False
    End Sub

    Private Sub treeFolders_AfterExpand(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.NodeEventArgs) Handles treeFolders.AfterExpand
        Adventure.dictFolders(e.TreeNode.Tag.ToString).Expanded = True
    End Sub

    Private ptStart As Point
    Private bAllowedToDrag As Boolean = False
    Private Sub treeFolders_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles treeFolders.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If treeFolders.GetNodeFromPoint(e.Location) IsNot Nothing Then treeFolders.ActiveNode = treeFolders.GetNodeFromPoint(e.Location)
        End If
        Dim itemCursor As UltraTreeNode = treeFolders.GetNodeFromPoint(treeFolders.PointToClient(MousePosition))
        bAllowedToDrag = (itemCursor IsNot Nothing)
        ptStart = treeFolders.PointToClient(MousePosition)
    End Sub

    Public Sub InitialiseTree()

        treeFolders.Nodes.Clear()
        bAllowFolderScroll = False

        Dim nodeDesktop As UltraTreeNode = Nothing

        If Not Adventure.dictFolders.ContainsKey("ROOT") Then AddNewFolder(Nothing, DESKTOP, nodeDesktop, "ROOT")
        If Not treeFolders.Nodes.Exists("ROOT") Then AddFolder(Adventure.dictFolders("ROOT"))

        If Adventure.dictFolders.Count = 1 Then
            Dim folder As clsFolder
            folder = AddNewFolder(nodeDesktop, "Locations", , "Locations")
            folder.Size.Height = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subh1", "0")) / 15)
            folder.Size.Width = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subw1", "0")) / 15)
            folder.Location.X = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subx1", "0")) / 15)
            folder.Location.Y = CInt(CInt(GetSetting("ADRIFT", "Generator", "Suby1", "0")) / 15)
            'Adventure.dictFolders("ROOT").Members.Add("Locations")
            For Each sKey As String In Adventure.htblLocations.Keys
                folder.Members.Add(sKey)
            Next
            OpenNewFolder(folder.Key)
            folder = AddNewFolder(nodeDesktop, "Objects", , "Objects")
            folder.Size.Height = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subh2", "0")) / 15)
            folder.Size.Width = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subw2", "0")) / 15)
            folder.Location.X = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subx2", "0")) / 15)
            folder.Location.Y = CInt(CInt(GetSetting("ADRIFT", "Generator", "Suby2", "0")) / 15)
            'Adventure.dictFolders("ROOT").Members.Add("Objects")
            For Each sKey As String In Adventure.htblObjects.Keys
                folder.Members.Add(sKey)
            Next
            OpenNewFolder(folder.Key)
            folder = AddNewFolder(nodeDesktop, "Tasks", , "Tasks")
            folder.Size.Height = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subh3", "0")) / 15)
            folder.Size.Width = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subw3", "0")) / 15)
            folder.Location.X = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subx3", "0")) / 15)
            folder.Location.Y = CInt(CInt(GetSetting("ADRIFT", "Generator", "Suby3", "0")) / 15)
            'Adventure.dictFolders("ROOT").Members.Add("Tasks")
            For Each sKey As String In Adventure.htblTasks.Keys
                folder.Members.Add(sKey)
            Next
            OpenNewFolder(folder.Key)
            folder = AddNewFolder(nodeDesktop, "Events", , "Events")
            folder.Size.Height = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subh4", "0")) / 15)
            folder.Size.Width = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subw4", "0")) / 15)
            folder.Location.X = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subx4", "0")) / 15)
            folder.Location.Y = CInt(CInt(GetSetting("ADRIFT", "Generator", "Suby4", "0")) / 15)
            'Adventure.dictFolders("ROOT").Members.Add("Events")
            For Each sKey As String In Adventure.htblEvents.Keys
                folder.Members.Add(sKey)
            Next
            OpenNewFolder(folder.Key)
            folder = AddNewFolder(nodeDesktop, "Characters", , "Characters")
            folder.Size.Height = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subh0", "0")) / 15)
            folder.Size.Width = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subw0", "0")) / 15)
            folder.Location.X = CInt(CInt(GetSetting("ADRIFT", "Generator", "Subx0", "0")) / 15)
            folder.Location.Y = CInt(CInt(GetSetting("ADRIFT", "Generator", "Suby0", "0")) / 15)
            'Adventure.dictFolders("ROOT").Members.Add("Characters")
            For Each sKey As String In Adventure.htblCharacters.Keys
                folder.Members.Add(sKey)
            Next
            OpenNewFolder(folder.Key)
            folder = AddNewFolder(nodeDesktop, "Groups", , "Groups")
            'Adventure.dictFolders("ROOT").Members.Add("Groups")
            For Each sKey As String In Adventure.htblGroups.Keys
                folder.Members.Add(sKey)
            Next
            folder = AddNewFolder(nodeDesktop, "Variables", , "Variables")
            'Adventure.dictFolders("ROOT").Members.Add("Variables")
            For Each sKey As String In Adventure.htblVariables.Keys
                folder.Members.Add(sKey)
            Next
            folder = AddNewFolder(nodeDesktop, "Text Overrides", , "Text Overrides")
            'Adventure.dictFolders("ROOT").Members.Add("Text Overrides")
            For Each sKey As String In Adventure.htblALRs.Keys
                folder.Members.Add(sKey)
            Next
            folder = AddNewFolder(nodeDesktop, "Hints", , "Hints")
            'Adventure.dictFolders("ROOT").Members.Add("Hints")
            For Each sKey As String In Adventure.htblHints.Keys
                folder.Members.Add(sKey)
            Next
            folder = AddNewFolder(nodeDesktop, "Properties", , "Properties")
            'Adventure.dictFolders("ROOT").Members.Add("Properties")
            For Each sKey As String In Adventure.htblAllProperties.Keys
                folder.Members.Add(sKey)
            Next
            folder = AddNewFolder(nodeDesktop, "Synonyms", , "Synonyms")
            'Adventure.dictFolders("ROOT").Members.Add("Properties")
            For Each sKey As String In Adventure.htblSynonyms.Keys
                folder.Members.Add(sKey)
            Next
            folder = AddNewFolder(nodeDesktop, "User Functions", , "User Functions")
            'Adventure.dictFolders("ROOT").Members.Add("Properties")
            For Each sKey As String In Adventure.htblUDFs.Keys
                folder.Members.Add(sKey)
            Next
        Else
            ' Load existing folders
            For Each folder As clsFolder In Adventure.dictFolders.Values
                If treeFolders.GetNodeByKey(folder.Key) Is Nothing Then AddFolder(folder)
                'If folder.Visible Then OpenNewFolder(folder.Key)
            Next

            ' Ensure all our items are in at least one folder
            For Each sKey As String In Adventure.htblLocations.Keys
                If Not ItemIsInFolder(sKey) Then
                    If Adventure.dictFolders.ContainsKey("Locations") Then
                        Adventure.dictFolders("Locations").Members.Add(sKey)
                    Else
                        Adventure.dictFolders("ROOT").Members.Add(sKey)
                    End If
                End If
            Next
            For Each sKey As String In Adventure.htblObjects.Keys
                If Not ItemIsInFolder(sKey) Then
                    If Adventure.dictFolders.ContainsKey("Objects") Then
                        Adventure.dictFolders("Objects").Members.Add(sKey)
                    Else
                        Adventure.dictFolders("ROOT").Members.Add(sKey)
                    End If
                End If
            Next
            For Each sKey As String In Adventure.htblTasks.Keys
                If Not ItemIsInFolder(sKey) Then
                    If Adventure.dictFolders.ContainsKey("Tasks") Then
                        Adventure.dictFolders("Tasks").Members.Add(sKey)
                    Else
                        Adventure.dictFolders("ROOT").Members.Add(sKey)
                    End If
                End If
            Next
            For Each sKey As String In Adventure.htblEvents.Keys
                If Not ItemIsInFolder(sKey) Then
                    If Adventure.dictFolders.ContainsKey("Events") Then
                        Adventure.dictFolders("Events").Members.Add(sKey)
                    Else
                        Adventure.dictFolders("ROOT").Members.Add(sKey)
                    End If
                End If
            Next
            For Each sKey As String In Adventure.htblCharacters.Keys
                If Not ItemIsInFolder(sKey) Then
                    If Adventure.dictFolders.ContainsKey("Characters") Then
                        Adventure.dictFolders("Characters").Members.Add(sKey)
                    Else
                        Adventure.dictFolders("ROOT").Members.Add(sKey)
                    End If
                End If
            Next
            For Each sKey As String In Adventure.htblAllProperties.Keys
                If Not ItemIsInFolder(sKey) Then
                    If Adventure.dictFolders.ContainsKey("Properties") Then
                        Adventure.dictFolders("Properties").Members.Add(sKey)
                    Else
                        Adventure.dictFolders("ROOT").Members.Add(sKey)
                    End If
                End If
            Next
            For Each sKey As String In Adventure.htblVariables.Keys
                If Not ItemIsInFolder(sKey) Then
                    If Adventure.dictFolders.ContainsKey("Variables") Then
                        Adventure.dictFolders("Variables").Members.Add(sKey)
                    Else
                        Adventure.dictFolders("ROOT").Members.Add(sKey)
                    End If
                End If
            Next
            For Each sKey As String In Adventure.htblGroups.Keys
                If Not ItemIsInFolder(sKey) Then
                    If Adventure.dictFolders.ContainsKey("Groups") Then
                        Adventure.dictFolders("Groups").Members.Add(sKey)
                    Else
                        Adventure.dictFolders("ROOT").Members.Add(sKey)
                    End If
                End If
            Next
            For Each sKey As String In Adventure.htblALRs.Keys
                If Not ItemIsInFolder(sKey) Then
                    If Adventure.dictFolders.ContainsKey("Text Overrides") Then
                        Adventure.dictFolders("Text Overrides").Members.Add(sKey)
                    Else
                        Adventure.dictFolders("ROOT").Members.Add(sKey)
                    End If
                End If
            Next
            For Each sKey As String In Adventure.htblHints.Keys
                If Not ItemIsInFolder(sKey) Then
                    If Adventure.dictFolders.ContainsKey("Hints") Then
                        Adventure.dictFolders("Hints").Members.Add(sKey)
                    Else
                        Adventure.dictFolders("ROOT").Members.Add(sKey)
                    End If
                End If
            Next
            For Each sKey As String In Adventure.htblUDFs.Keys
                If Not ItemIsInFolder(sKey) Then
                    If Adventure.dictFolders.ContainsKey("User Functions") Then
                        Adventure.dictFolders("User Functions").Members.Add(sKey)
                    Else
                        Adventure.dictFolders("ROOT").Members.Add(sKey)
                    End If
                End If
            Next
            For Each sKey As String In Adventure.htblSynonyms.Keys
                If Not ItemIsInFolder(sKey) Then
                    If Adventure.dictFolders.ContainsKey("Synonyms") Then
                        Adventure.dictFolders("Synonyms").Members.Add(sKey)
                    Else
                        Adventure.dictFolders("ROOT").Members.Add(sKey)
                    End If
                End If
            Next

            For Each folder As clsFolder In Adventure.dictFolders.Values
                If folder.Visible Then OpenNewFolder(folder.Key)
            Next

        End If

        bAllowFolderScroll = True

    End Sub


    Private Function ItemIsInFolder(ByVal sItemKey As String) As Boolean

        For Each folder As clsFolder In Adventure.dictFolders.Values
            If folder.Members.Contains(sItemKey) Then Return True
        Next
        Return False

    End Function


    Private Sub cmsFolders_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsFolders.Opening

        miExpand.Text = "Expand"
        If treeFolders.ActiveNode IsNot Nothing Then
            If treeFolders.ActiveNode.HasNodes Then
                miExpand.Enabled = True
                If treeFolders.ActiveNode.Expanded Then
                    miExpand.Text = "Collapse"
                Else
                    miExpand.Text = "Expand"
                End If
            Else
                miExpand.Enabled = False
            End If

            miOpenInNew.Enabled = True
            For Each child As frmFolder In fGenerator.MDIFolders
                If child.Folder.folder.Key = treeFolders.ActiveNode.Tag.ToString Then
                    miOpenInNew.Enabled = False
                    Exit For
                End If
            Next
            miDeleteFolder.Enabled = (treeFolders.ActiveNode IsNot treeFolders.Nodes("ROOT"))
            fGenerator.sDestinationList = treeFolders.ActiveNode.Key
        Else
            miExpand.Enabled = False
        End If

    End Sub


    Private Sub miExpand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miExpand.Click

        If treeFolders.ActiveNode IsNot Nothing Then
            If treeFolders.ActiveNode.HasNodes Then
                If treeFolders.ActiveNode.Expanded Then
                    treeFolders.ActiveNode.CollapseAll()
                Else
                    treeFolders.ActiveNode.ExpandAll()
                End If
            End If
        End If

    End Sub


    Public Sub OpenNewFolder(ByVal sFolder As String)
        For Each child As frmFolder In fGenerator.MDIFolders
            If child.Folder.folder.Key = sFolder Then
                If (Now.Subtract(child.Folder.dtLoaded).TotalMilliseconds < 500 AndAlso child.Folder.sLastKey <> "") _
                OrElse (child.Folder.lstContents.Items.Count <> child.Folder.folder.Members.Count) Then
                    child.Folder.LoadFolder(child.Folder.sLastKey)
                    Exit For
                Else
                    child.Folder.SetActive()
                    Exit Sub
                End If
            End If
        Next
        LoadFolder(sFolder)
    End Sub


    Private Sub treeFolders_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles treeFolders.DoubleClick
        If treeFolders.ActiveNode IsNot Nothing Then
            If Not treeFolders.ActiveNode.HasNodes Then OpenNewFolder(treeFolders.ActiveNode.Tag.ToString)
        End If
    End Sub


    Private Sub LoadFolder(ByVal sFolderKey As String, Optional ByVal sPaneKey As String = "")

        Dim frmFolder As New frmFolder
        'GetFormPosition(CType(frmFolder, Form))
        SetWindowStyle(frmFolder)
        frmFolder.Folder.LoadFolder(sFolderKey)
        If frmFolder.Folder.folder.Size.Width > 0 OrElse frmFolder.Folder.folder.Size.Height > 0 Then frmFolder.Size = New Size(frmFolder.Folder.folder.Size.Width, frmFolder.Folder.folder.Size.Height)
        'If frmFolder.Folder.folder.Size.Height > 0 Then frmFolder.Height = frmFolder.Folder.folder.Size.Height
        If frmFolder.Folder.folder.Location.X <> -100 AndAlso frmFolder.Folder.folder.Location.Y <> -100 Then
            frmFolder.StartPosition = FormStartPosition.Manual
            frmFolder.Location = New Point(frmFolder.Folder.folder.Location.X, frmFolder.Folder.folder.Location.Y)
        Else
            frmFolder.StartPosition = FormStartPosition.WindowsDefaultLocation
        End If
        frmFolder.MdiParent = fGenerator
        frmFolder.Show()
        Application.DoEvents()
        frmFolder.ScrollIntoView()

    End Sub


    Public bSettingNode As Boolean = False
    Private Sub treeFolders_AfterSelect(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.SelectEventArgs) Handles treeFolders.AfterSelect

        If bSettingNode Then Exit Sub

        If e.NewSelections IsNot Nothing AndAlso e.NewSelections.Count = 1 Then
            For Each child As frmFolder In fGenerator.MDIFolders
                If child.Folder.folder.Key = e.NewSelections(0).Tag.ToString Then
                    child.Folder.SetActive()
                    child.Folder.BringToFront()

                    'child.ScrollControlIntoView(
                    child.ScrollIntoView()

                    Exit Sub
                End If
            Next
            'If fGenerator.ActiveFolder IsNot Nothing Then
            '    fGenerator.ActiveFolder.LoadFolder(e.NewSelections(0).Tag.ToString)
            'End If
        End If
    End Sub

    Private Sub treeFolders_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles treeFolders.Click

    End Sub

    Private Sub treeFolders_AfterLabelEdit(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.NodeEventArgs) Handles treeFolders.AfterLabelEdit

        Dim sKey As String = e.TreeNode.Key
        Select Case Adventure.GetTypeFromKeyNice(sKey)
            Case "Folder"
                Adventure.dictFolders(sKey).Name = e.TreeNode.Text
                For Each child As frmFolder In fGenerator.MDIFolders
                    If child.Folder.folder.Key = sKey Then child.lblCaption.Text = e.TreeNode.Text
                    If child.Folder.lstContents.Items.Exists(sKey) Then
                        child.Folder.lstContents.Items(sKey).Value = e.TreeNode.Text
                    End If
                Next
            Case Else
                TODO()
        End Select

    End Sub


    Private Sub miDeleteFolder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miDeleteFolder.Click
        If treeFolders.ActiveNode IsNot Nothing Then
            If Not treeFolders.ActiveNode.HasNodes Then DeleteItems(treeFolders.ActiveNode.Tag.ToString)
        End If
    End Sub


    Private Sub treeFolders_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles treeFolders.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso bAllowedToDrag Then
            ' This line prevents the DoubleClick event from firing...
            Dim ptNow As Point = treeFolders.PointToClient(MousePosition)
            ' Make sure mouse has moved at least 3 pixels before starting drag
            If Math.Abs(ptStart.X - ptNow.X) > 3 OrElse Math.Abs(ptStart.Y - ptNow.Y) > 3 Then
                treeFolders.DoDragDrop(treeFolders.SelectedNodes, DragDropEffects.Move Or DragDropEffects.Scroll)
            End If
        End If
    End Sub


    Private Sub treeFolders_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles treeFolders.DragEnter

        If e.Data.GetDataPresent("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection") Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub


    Private Sub treeFolders_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles treeFolders.DragOver

        Dim nodeHover As UltraTreeNode = treeFolders.GetNodeFromPoint(treeFolders.PointToClient(MousePosition))

        If nodeHover IsNot Nothing Then
            treeFolders.HotTrackingNode = nodeHover
            If e.Data.GetDataPresent("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection") Then
                With CType(e.Data.GetData("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection"), Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection)
                    ' Don't allow dragging a folder into itself, or any sub-folder thereof                 
                    For i As Integer = .Count - 1 To 0 Step -1
                        Dim sItemKey As String = .Item(i).SubItems(3).Text
                        If nodeHover.Key = sItemKey Then
                            e.Effect = DragDropEffects.None
                            Exit Sub
                        End If
                        If Adventure.dictFolders.ContainsKey(sItemKey) Then
                            If Adventure.dictFolders(sItemKey).ContainsKey(nodeHover.Key) Then
                                e.Effect = DragDropEffects.None
                                Exit Sub
                            End If
                        End If
                    Next
                End With

                e.Effect = DragDropEffects.Move
            ElseIf e.Data.GetDataPresent("Infragistics.Win.UltraWinTree.SelectedNodesCollection") Then
                With CType(e.Data.GetData("Infragistics.Win.UltraWinTree.SelectedNodesCollection"), Infragistics.Win.UltraWinTree.SelectedNodesCollection)
                    ' Don't allow dragging a folder into itself, or any sub-folder thereof                 
                    For i As Integer = .Count - 1 To 0 Step -1
                        Dim sItemKey As String = .Item(i).Key
                        If nodeHover.Key = sItemKey Then
                            e.Effect = DragDropEffects.None
                            Exit Sub
                        End If
                        If Adventure.dictFolders.ContainsKey(sItemKey) Then
                            If Adventure.dictFolders(sItemKey).ContainsKey(nodeHover.Key) Then
                                e.Effect = DragDropEffects.None
                                Exit Sub
                            End If
                        End If
                    Next
                End With

                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub


    Private Sub treeFolders_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles treeFolders.DragDrop

        Try
            Dim nodeHover As UltraTreeNode = treeFolders.GetNodeFromPoint(treeFolders.PointToClient(MousePosition))

            If nodeHover IsNot Nothing Then
                Dim bShownError As Boolean = False
                Dim lItems As New List(Of Infragistics.Win.UltraWinListView.UltraListViewItem)

                If e.Data.GetDataPresent("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection") Then
                    Dim items As Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection = CType(e.Data.GetData("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection"), Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection)
                    If items.Count = 0 Then Exit Sub
                    Dim lstSource As Infragistics.Win.UltraWinListView.UltraListView = items.First.Control
                    lstSource.BeginUpdate()

                    For i As Integer = items.Count - 1 To 0 Step -1
                        Dim itm As Infragistics.Win.UltraWinListView.UltraListViewItem = items(i)
                        Dim sItemKey As String = itm.SubItems(3).Text
                        Dim iOldIndex As Integer = itm.Index


                        Adventure.dictFolders(CType(itm.Control.Parent, Folder).folder.Key).Members.Remove(sItemKey)

                        Dim treenode As Infragistics.Win.UltraWinTree.UltraTreeNode = fGenerator.FolderList1.treeFolders.GetNodeByKey(sItemKey)
                        If treenode IsNot Nothing Then treenode.Parent.Nodes.Remove(treenode)

                        itm.Control.Items.Remove(itm)

                        Dim folderDest As clsFolder = Nothing
                        Dim lstContents As Infragistics.Win.UltraWinListView.UltraListView = Nothing
                        For Each f As frmFolder In fGenerator.MDIFolders
                            If f.Folder IsNot Nothing AndAlso f.Folder.folder IsNot Nothing AndAlso f.Folder.folder.Key = nodeHover.Key Then
                                folderDest = f.Folder.folder
                                lstContents = f.Folder.lstContents
                                Exit For
                            End If
                        Next
                        If folderDest Is Nothing Then folderDest = Adventure.dictFolders(nodeHover.Key)

                        Dim nodeDest As UltraTreeNode = fGenerator.FolderList1.treeFolders.GetNodeByKey(folderDest.Key)
                        If nodeDest IsNot Nothing AndAlso treenode IsNot Nothing Then nodeDest.Nodes.Add(treenode)

                        folderDest.Members.Insert(folderDest.Members.Count, sItemKey)

                        If lstContents IsNot Nothing Then lstContents.Items.Insert(folderDest.Members.Count - 1, itm)

                        lItems.Add(itm)
                        If i = 0 Then itm.Activate()

                    Next

                    lstSource.EndUpdate()

                ElseIf e.Data.GetDataPresent("Infragistics.Win.UltraWinTree.SelectedNodesCollection") Then
                    With CType(e.Data.GetData("Infragistics.Win.UltraWinTree.SelectedNodesCollection"), Infragistics.Win.UltraWinTree.SelectedNodesCollection)
                        If .Count = 1 Then ' Should be - we only allow to drag a single folder in the tree
                            Dim node As UltraTreeNode = .Item(0)
                            Dim sItemKey As String = node.Key
                            Dim nodeParent As UltraTreeNode = node.Parent

                            If nodeParent IsNot Nothing Then
                                nodeParent.Nodes.Remove(node)

                                Dim folderDest As clsFolder = Nothing
                                'Dim lstContents As Infragistics.Win.UltraWinListView.UltraListView = Nothing
                                Dim VisibleSrcFolder As ADRIFT.Folder = Nothing
                                Dim VisibleDestFolder As ADRIFT.Folder = Nothing                                
                                For Each f As frmFolder In fGenerator.MDIFolders
                                    If f.Folder IsNot Nothing AndAlso f.Folder.folder IsNot Nothing Then
                                        If f.Folder.folder.Key = nodeHover.Key Then
                                            VisibleDestFolder = f.Folder
                                            folderDest = VisibleDestFolder.folder
                                        End If
                                        If f.Folder.folder.Key = nodeParent.Key Then VisibleSrcFolder = f.Folder
                                        ' lstContents = f.Folder.lstContents                                       
                                        If VisibleSrcFolder IsNot Nothing AndAlso VisibleDestFolder IsNot Nothing Then Exit For
                                    End If
                                Next
                                If folderDest Is Nothing Then folderDest = Adventure.dictFolders(nodeHover.Key)

                                folderDest.Members.Insert(folderDest.Members.Count, sItemKey)

                                If VisibleSrcFolder IsNot Nothing Then VisibleSrcFolder.RemoveSingleItem(sItemKey)
                                If VisibleDestFolder IsNot Nothing Then VisibleDestFolder.AddSingleItem(sItemKey)

                                Adventure.dictFolders(nodeParent.Key).Members.Remove(sItemKey)

                                'If lstContents IsNot Nothing Then  lstContents.Items.Insert(folderDest.Members.Count - 1, itm)
                                nodeHover.Nodes.Add(node)

                                'lItems.Add(itm)
                                'If i = 0 Then itm.Activate()

                            End If

                        End If
                    End With
                End If
            End If

        Catch ex As Exception
            ErrMsg("Folder drop error", ex)
        End Try

    End Sub


    Private Sub miExportFolder_Click(sender As Object, e As EventArgs) Handles miExportFolder.Click
        If treeFolders.ActiveNode IsNot Nothing Then
            fGenerator.ExportModule(treeFolders.ActiveNode.Tag.ToString)
        End If      
    End Sub

End Class
