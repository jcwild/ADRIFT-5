Option Strict On
Option Explicit On


Imports System.Runtime.Serialization
Imports System.IO
Imports System.Xml
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars
Imports Microsoft.Win32


Module GeneratorGlobal

    Public Enum OverwriteLibrariesEnum
        PromptPerLibrary = 0
        PromptPerItem = 1
        Always = 2
        Never = 3
    End Enum

    Public oCopiedItem As Object
    Public fGenerator As frmGenerator ' New frmGenerator
    Public fSearch As SearchReplace
    Public eStyle As Infragistics.Win.UltraWinToolbars.ToolbarStyle
    'Public eStyle2 As Infragistics.Win.style
    Public eColour2007 As Infragistics.Win.Office2007ColorScheme
    Public eColour2010 As Infragistics.Win.Office2010ColorScheme
    Public eColour2013 As Infragistics.Win.Office2013ColorScheme
    Public colAllForms As New Collection
    Public eOverwriteLibraries As OverwriteLibrariesEnum = OverwriteLibrariesEnum.PromptPerLibrary
    Public bEnableAudio As Boolean = True
    Public bEnableGraphics As Boolean = True
    Public bEnablePreview As Boolean = True
    Public OpenForms As New List(Of Form) ' Because Application.OpenForms has a bug if you change the ShowInTaskbar property... :-(    
    Public bAllowFolderScroll As Boolean = True
    Public xmlRestrictions As Byte()
    Public xmlActions As Byte()

    Friend Const IMGREGEX As String = "<img src=""(https?:(//)[\w\d:#:%/;$()~_\?\+-=\\\.&]*?|[a-zA-Z]:(\\[\w_\. -~\[\]]+?)*?\.\w+?)"">" ' URL or Path
    Friend Const AUDREGEX As String = "<audio ((play )?src=(""(?<src>(https?:(//)[\w\d:#:%/;$()~_\?\+-=\\\.&]*?|[a-zA-Z]:(\\[\w_\. -~\[\]]+?)*?\.\w+?))"")?|pause|stop)( channel=(?<channel>\d))?( loop=(?<loop>(Y|N)))?>" ' URL or Path

    Friend iRegistered As Integer = 0 ' 0 = not checked, 1m-2m = no, 2m-4m = yes
    Public ReadOnly Property IsRegistered() As Boolean
        Get
            Return True
            '' If we run this in 64-bit mode, we check the 64-bit system32 folder instead of the syswow64 folder.  Hmm...
            '' This needs to always look in the 32-bit folder for builds registered with ADRIFT 4.0
            ''
            'If iRegistered = 0 Then
            '    If fGenerator.PartOne AndAlso fGenerator.PartTwo Then
            '        Dim sKeyValue As String = RegValue(RegistryHive.ClassesRoot, ".txt", "A" & "SCII".ToLower)
            '        If sKeyValue = "0x" & Chr(&H30) & 0 & "0" & "0000" & 3 Then
            '            iRegistered = Random(2000001, 4000000)
            '        Else
            '            iRegistered = Random(1000000, 2000000)
            '        End If
            '    Else
            '        iRegistered = Random(1000000, 2000000)
            '    End If
            'End If
            ''Return False
            'Return iRegistered >= 2000001
        End Get
    End Property

    Public Function RegValue(ByVal Hive As RegistryHive, ByVal Key As String, ByVal ValueName As String, Optional ByRef ErrInfo As String = "") As String

        'DEMO USAGE

        'Dim sAns As String
        'Dim sErr As String = ""

        'sAns = RegValue(RegistryHive.LocalMachine, _
        '  "SOFTWARE\Microsoft\Windows\CurrentVersion", _
        '  "ProgramFilesDir", sErr)
        'If sAns <> "" Then
        '    Debug.WriteLine("Value = " & sAns)
        'Else
        '    Debug.WriteLine("This error occurred: " & sErr)
        'End If

        Dim objParent As RegistryKey
        Dim objSubkey As RegistryKey
        Dim sAns As String = ""

        Select Case Hive
            Case RegistryHive.ClassesRoot
                objParent = Registry.ClassesRoot
            Case RegistryHive.CurrentConfig
                objParent = Registry.CurrentConfig
            Case RegistryHive.CurrentUser
                objParent = Registry.CurrentUser
            Case RegistryHive.DynData
                objParent = Registry.DynData
            Case RegistryHive.LocalMachine
                objParent = Registry.LocalMachine
            Case RegistryHive.PerformanceData
                objParent = Registry.PerformanceData
            Case RegistryHive.Users
                objParent = Registry.Users
            Case Else
                objParent = Nothing
        End Select

        Try
            objSubkey = objParent.OpenSubKey(Key)
            'if can't be found, object is not initialized
            If Not objSubkey Is Nothing Then
                sAns = SafeString(objSubkey.GetValue(ValueName))
            End If

        Catch ex As Exception
            ErrInfo = ex.Message
        Finally

            'if no error but value is empty, populate errinfo
            If ErrInfo = "" And sAns = "" Then
                ErrInfo = _
                   "No value found for requested registry key"
            End If
        End Try
        Return sAns
    End Function


    ' Developer doesn't strip carats, just Runner
    Public Function StripCarats(ByVal sText As String) As String
        Return sText
    End Function


    Public ReadOnly Property culOffice2007() As Color
        Get
            Select Case eColour2007
                Case Office2007ColorScheme.Black
                    Return Color.FromArgb(83, 83, 83)
                Case Office2007ColorScheme.Blue
                    Return Color.FromArgb(206, 223, 239)
                Case Office2007ColorScheme.Silver
                    Return Color.FromArgb(167, 173, 177)
            End Select
        End Get
    End Property
    Public ReadOnly Property culOffice2010() As Color
        Get
            Select Case eColour2010
                Case Office2010ColorScheme.Black
                    Return Color.FromArgb(83, 83, 83)
                Case Office2010ColorScheme.Blue
                    Return Color.FromArgb(206, 223, 239)
                Case Office2010ColorScheme.Silver
                    Return Color.FromArgb(167, 173, 177)
            End Select
        End Get
    End Property
    Public ReadOnly Property culOffice2013() As Color
        Get
            Select Case eColour2013
                Case Office2013ColorScheme.DarkGray
                    Return Color.FromArgb(83, 83, 83)
                Case Office2013ColorScheme.LightGray
                    Return Color.FromArgb(206, 223, 239)
                Case Office2013ColorScheme.White
                    Return Color.FromArgb(167, 173, 177)
            End Select
        End Get
    End Property
    Public sDictionary As String
    Public sMainDictionary, sUserDictionary As String

    Private lCopiedItems As Generic.List(Of clsItem)
    Public Property CopiedItems() As Generic.List(Of clsItem)
        Get
            Return lCopiedItems
        End Get
        Set(ByVal value As Generic.List(Of clsItem))
            lCopiedItems = value

            ' Set paste icon
            If value Is Nothing OrElse value.Count = 0 Then
                fGenerator.UTMMain.Tools("Paste").SharedProps.Enabled = False
            Else
                fGenerator.UTMMain.Tools("Paste").SharedProps.Enabled = True
            End If
        End Set
    End Property


    Public Property CopiedItem() As Object
        Get
            Return oCopiedItem
        End Get
        Set(ByVal value As Object)
            oCopiedItem = value

            ' Set paste icon
            If value Is Nothing Then
                fGenerator.UTMMain.Tools("Paste").SharedProps.Enabled = False
            Else
                fGenerator.UTMMain.Tools("Paste").SharedProps.Enabled = True
            End If
        End Set
    End Property


    Public Function YesNoCancel(ByVal sMessage As String, Optional ByVal sTitle As String = "ADRIFT Developer", Optional ByVal sSaveSetting As String = "", Optional bShowCancel As Boolean = True) As DialogResult

        If sSaveSetting <> "" Then
            Dim sResult As String = GetSetting("ADRIFT", "Generator", sSaveSetting)
            If sResult <> "" AndAlso SafeInt(sResult) > 0 Then Return CType(sResult, DialogResult)
        End If

        Dim ync As New frmYesNoCancel

        ync.lblText.Text = sMessage
        ync.Text = sTitle
        ync.btnCancel.Visible = bShowCancel

        Dim result As DialogResult = ync.ShowDialog

        If ync.chkRemember.Checked AndAlso sSaveSetting <> "" AndAlso result <> DialogResult.Cancel Then
            SaveSetting("ADRIFT", "Generator", sSaveSetting, CInt(result).ToString)
        End If

        Return result

    End Function


    'Public Sub Main()

    '    Try
    '        bGenerator = True

    '        Dim s As New Size
    '        Dim fGenerator As New frmGenerator

    '        s.Height = CInt(CInt(GetSetting("ADRIFT", "Generator", "Window Height", (fGenerator.Size.Height * 15).ToString)) / 15) '- 20 ' Add this back on when adding menu I think
    '        s.Width = CInt(CInt(GetSetting("ADRIFT", "Generator", "Window Width", (fGenerator.Size.Width * 15).ToString)) / 15)

    '        IntroMessage()
    '        GetSettings()

    '        fGenerator.Size = s
    '        Application.Run(fGenerator)

    '    Catch ex As Exception
    '        ErrMsg("Critical Error", ex)
    '    End Try

    'End Sub


    Public Sub GetSettings()

        sDictionary = CStr(GetSetting("ADRIFT", "Generator", "DictionaryLanguage", "English"))
        sUserDictionary = CStr(GetSetting("ADRIFT", "Generator", "UserDictionaryLocation", DataPath(True) & "userdictionary.dict"))
        sMainDictionary = CStr(GetSetting("ADRIFT", "Generator", "DictionaryLocation", ""))
        fGenerator.Map1.ShowAxes = CBool(GetSetting("ADRIFT", "Generator", "ShowAxes", "-1"))
        fGenerator.Map1.ShowGrid = CBool(GetSetting("ADRIFT", "Generator", "ShowGrid", "-1"))
        CType(fGenerator.UTMMain.Tools("Show Axes"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = fGenerator.Map1.ShowAxes
        CType(fGenerator.UTMMain.Tools("ShowGridLines"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = fGenerator.Map1.ShowGrid
        fGenerator.UTMMain.Ribbon.IsMinimized = CBool(GetSetting("ADRIFT", "Generator", "RibbonMinimized", "0"))

        fGenerator.PartTwo = CStr(GetSetting("ADRIFT", "Shared", "RegName")).Length > 0

    End Sub



    Public Function DeleteItems(ByVal sKeys As Generic.List(Of String)) As Boolean

        If sKeys.Count = 0 Then Return False

        Dim lReferencedKeys As New Generic.List(Of String)
        Dim iReferencedCount As Integer = 0

        ' First check to see if the item is referenced in anything other than in the set we're deleting
        For Each sKey As String In sKeys
            For Each itm As clsItem In Adventure.dictAllItems.Values
                If Not sKeys.Contains(itm.Key) Then
                    Dim iCount As Integer = itm.ReferencesKey(sKey)
                    If iCount > 0 Then
                        iReferencedCount += iCount
                        lReferencedKeys.Add(itm.Key)
                    End If
                End If
            Next
        Next

        ' If it is, pop up a question to verify the deletion, if not, just delete the sucker
        ' Generate a nice message
        Dim sType As String = ""
        Dim sCaption As String = ""
        Dim sThisThese As String = ""
        Dim sIsAre As String = ""
        Dim sItThem As String = ""
        Dim sList As String = ".  "

        For Each sKey As String In sKeys
            If sType = "" Then
                sType = Adventure.GetTypeFromKeyNice(sKey)
            Else
                If Adventure.GetTypeFromKeyNice(sKey) <> sType Then
                    sType = "items"
                    Exit For
                End If
            End If
        Next
        If sType <> "items" AndAlso sKeys.Count > 1 Then sType = Adventure.GetTypeFromKeyNice(sKeys(0), True)
        If sKeys.Count = 1 Then
            sCaption = "Delete " & Adventure.GetNameFromKey(sKeys(0), , , True)
            sThisThese = "This "
            sType = LCase(sType)
            sIsAre = " is"
            sItThem = " it"
        Else
            sCaption = "Delete " & sKeys.Count & " " & sType
            sThisThese = "These "
            sType = sKeys.Count & " " & LCase(sType)
            sIsAre = " are"
            sItThem = " them"
        End If
        If lReferencedKeys.Count < 30 Then
            sList = ":" & vbCrLf
            For Each sKey As String In lReferencedKeys
                sList &= vbCrLf & "   " & Adventure.GetNameFromKey(sKey, False, , True)
            Next
            sList &= vbCrLf & vbCrLf
        End If

        If (lReferencedKeys.Count = 0 AndAlso sKeys.Count = 1) _
            OrElse (iReferencedCount = 0 AndAlso MessageBox.Show("Are you sure you wish to delete these " & sType & "?", sCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes) _
            OrElse (iReferencedCount > 0 AndAlso MessageBox.Show(sThisThese & sType & sIsAre & " referenced" & (" " & iReferencedCount & " times in ").Replace(" 1 times", " once").Replace(" 2 times", " twice") & CStr(lReferencedKeys.Count & " other items").Replace(" 1 other items", " another item") & sList & "Are you sure you wish to delete" & sItThem & "?", sCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then

            For Each sKey As String In sKeys
                DeleteItem(sKey)
            Next
        End If

    End Function
    Public Function DeleteItems(ByVal sKey As String) As Boolean
        Dim lItems As New Generic.List(Of String)
        lItems.Add(sKey)
        Return DeleteItems(lItems)
    End Function


    Private Function DeleteItem(ByVal sKey As String) As Boolean

        ' Remove all references to the item
        For Each itm As clsItem In Adventure.dictAllItems.Values
            If Not TypeOf itm Is clsFolder Then
                If Not itm.DeleteKey(sKey) Then
                    ErrMsg("Error deleting " & Adventure.GetNameFromKey(sKey))
                    Return False
                End If
            End If
        Next

        ' If item is a folder, ask whether we want to delete it's contents (if it has any)
        ' If not, don't delete
        If Adventure.GetTypeFromKeyNice(sKey) = "Folder" Then
            If Adventure.dictFolders.ContainsKey(sKey) Then
                If Adventure.dictFolders(sKey).Members.Count > 0 Then
                    Select Case MessageBox.Show(Adventure.GetNameFromKey(sKey) & " contains " & Adventure.dictFolders(sKey).Members.Count & " items.  Would you like to also delete these?", "Delete folder contents?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                        Case DialogResult.Yes
                            ' Add all contents to delete list

                        Case DialogResult.No
                            ' Hmm, need to move the contents to our parent folder

                        Case DialogResult.Cancel
                            Return False
                    End Select
                End If
                Dim nodDeleting As Infragistics.Win.UltraWinTree.UltraTreeNode = fGenerator.FolderList1.treeFolders.GetNodeByKey(sKey)
                If nodDeleting IsNot Nothing Then
                    nodDeleting.Parent.Nodes.Remove(nodDeleting)
                End If
                For Each folder As frmFolder In fGenerator.MDIFolders
                    For Each lvi As Infragistics.Win.UltraWinListView.UltraListViewItem In folder.Folder.lstContents.Items
                        If lvi.Key = sKey Then
                            folder.Folder.lstContents.Items.Remove(lvi)
                            Exit For
                        End If
                    Next
                Next
                For Each folder As frmFolder In fGenerator.MDIFolders
                    If folder.Folder.folder.Key = sKey Then
                        folder.Close()
                        Exit For
                    End If
                Next
                For Each folder As clsFolder In Adventure.dictFolders.Values
                    folder.DeleteKey(sKey)
                Next
            End If
        End If

        ' Remove from any folders
        For Each child As frmFolder In fGenerator.MDIFolders
            If child.Folder.folder.Members.Contains(sKey) Then
                child.Folder.RemoveSingleItem(sKey)
            End If
        Next

        If Adventure.dictAllItems(sKey).IsLibrary Then Adventure.listExcludedItems.Add(sKey)

        ' Then get rid of the item itself
        Select Case Adventure.GetTypeFromKeyNice(sKey)
            Case "Location"
                Adventure.Map.DeleteNode(sKey) ' If we are a location, need to update the map                
                Adventure.htblLocations.Remove(sKey)
            Case "Object"
                Adventure.htblObjects.Remove(sKey)
            Case "Task"
                Adventure.htblTasks.Remove(sKey)
            Case "Event"
                Adventure.htblEvents.Remove(sKey)
            Case "Character"
                Adventure.htblCharacters.Remove(sKey)
            Case "Variable"
                Adventure.htblVariables.Remove(sKey)
            Case "Text Override"
                Adventure.htblALRs.Remove(sKey)
            Case "Hint"
                Adventure.htblHints.Remove(sKey)
            Case "Group"
                Adventure.htblGroups.Remove(sKey)
            Case "Property"
                Adventure.htblAllProperties.Remove(sKey)
            Case "Folder"
                Adventure.dictFolders.Remove(sKey)
            Case "Synonym"
                Adventure.htblSynonyms.Remove(sKey)
            Case "User Function"
                Adventure.htblUDFs.Remove(sKey)
            Case Else
                TODO("Delete item of type " & Adventure.GetTypeFromKeyNice(sKey))
                Return False
        End Select

        Adventure.Changed = True
        Return True

    End Function



    Public Function CutItems(ByVal sKeys As Generic.List(Of String)) As Boolean
        If CopyItems(sKeys) Then
            For Each sKey As String In sKeys
                'Adventure.dictAllItems.Remove(sKey)
                For Each child As frmFolder In fGenerator.MDIFolders
                    If child.Folder.folder.Members.Contains(sKey) Then
                        child.Folder.CutSingleItem(sKey)
                    End If
                Next
            Next
        Else
            Return False
        End If
    End Function


    Public Function CopyItems(ByVal sKeys As Generic.List(Of String), Optional ByVal bAppendToCollection As Boolean = False) As Boolean

        Try
            If Not bAppendToCollection Then CopiedItems = New Generic.List(Of clsItem)
            For Each child As frmFolder In fGenerator.MDIFolders
                child.Folder.UnCutItems()
            Next
            For Each sKey As String In sKeys
                Dim item As clsItem = Adventure.GetItemFromKey(sKey)
                If item IsNot Nothing Then
                    item = item.Clone
                    item.IsLibrary = False
                    If bAppendToCollection Then item.Tag = "INFOLDER"
                    CopiedItems.Add(item)

                    If TypeOf item Is clsFolder Then CopyItems(CType(item, clsFolder).Members, True)
                    '    'Dim FolderItems As New List(Of clsItem)
                    '    With CType(item, clsFolder)
                    '        CopyItems(.Members, True)
                    '        '.Members.Clear()
                    '        'For Each FolderItem As clsItem In FolderItems
                    '        '    'FolderItem.Key = FolderItem.GetNewKey()
                    '        '    CopiedItems.Add(FolderItem)
                    '        '    '.Members.Add(FolderItem.Key)
                    '        'Next
                    '    End With
                    'End If
                End If
            Next
            fGenerator.UTMMain.Tools("Paste").SharedProps.Enabled = (CopiedItems.Count > 0)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


    'Public Sub CopyItem(ByVal sKey As String)

    '    If Adventure.GetTypeFromKey(sKey) Is Nothing Then Exit Sub ' i.e. trying to copy an item that doesn't exist

    '    Select Case True
    '        Case Adventure.GetTypeFromKey(sKey) Is GetType(Generator.clsLocation)
    '            CopiedItem = Adventure.htblLocations(sKey).Clone
    '            CType(CopiedItem, Generator.clsLocation).IsLibrary = False
    '        Case Adventure.GetTypeFromKey(sKey) Is GetType(Generator.clsObject)
    '            CopiedItem = Adventure.htblObjects(sKey).Clone
    '            CType(CopiedItem, Generator.clsObject).IsLibrary = False
    '        Case Adventure.GetTypeFromKey(sKey) Is GetType(Generator.clsTask)
    '            CopiedItem = Adventure.htblTasks(sKey).Clone '.Copy
    '            CType(CopiedItem, Generator.clsTask).IsLibrary = False
    '        Case Adventure.GetTypeFromKey(sKey) Is GetType(Generator.clsEvent)
    '            CopiedItem = Adventure.htblEvents(sKey).Clone
    '            CType(CopiedItem, Generator.clsEvent).IsLibrary = False
    '        Case Adventure.GetTypeFromKey(sKey) Is GetType(Generator.clsCharacter)
    '            CopiedItem = Adventure.htblCharacters(sKey).Clone
    '            CType(CopiedItem, Generator.clsCharacter).CharacterType = clsCharacter.CharacterTypeEnum.NonPlayer
    '            CType(CopiedItem, Generator.clsCharacter).IsLibrary = False
    '        Case Adventure.GetTypeFromKey(sKey) Is GetType(Generator.clsALR)
    '            CopiedItem = Adventure.htblALRs(sKey).Clone
    '            CType(CopiedItem, Generator.clsALR).IsLibrary = False
    '        Case Adventure.GetTypeFromKey(sKey) Is GetType(Generator.clsGroup)
    '            CopiedItem = Adventure.htblGroups(sKey).Clone
    '            CType(CopiedItem, Generator.clsGroup).IsLibrary = False
    '        Case Adventure.GetTypeFromKey(sKey) Is GetType(Generator.clsHint)
    '            CopiedItem = Adventure.htblHints(sKey).Clone
    '            CType(CopiedItem, Generator.clsHint).IsLibrary = False
    '        Case Adventure.GetTypeFromKey(sKey) Is GetType(Generator.clsProperty)
    '            CopiedItem = Adventure.htblAllProperties(sKey).Clone
    '            CType(CopiedItem, Generator.clsProperty).IsLibrary = False
    '        Case Adventure.GetTypeFromKey(sKey) Is GetType(Generator.clsVariable)
    '            CopiedItem = Adventure.htblVariables(sKey).Clone
    '            CType(CopiedItem, Generator.clsVariable).IsLibrary = False
    '        Case True
    '            ErrMsg("Not created code to copy " & Adventure.GetTypeFromKey(sKey).ToString & " yet...")

    '    End Select

    'End Sub


    Public Sub PasteItems()

        If CopiedItems IsNot Nothing AndAlso CopiedItems.Count > 0 Then
            Dim nodes As Generic.List(Of Infragistics.Win.UltraWinTree.UltraTreeNode) = Nothing
            Dim dictKeyChanges As New Dictionary(Of String, String)
            Dim NewItems As New List(Of clsItem)

            ' If CutItems contains a folder, make sure we don't paste it into a child of itself
            If fGenerator.ActiveFolder IsNot Nothing Then
                For Each itm As clsItem In CopiedItems
                    If TypeOf itm Is clsFolder Then
                        If CType(itm, clsFolder).ContainsKey(fGenerator.ActiveFolder.folder.Key) Then
                            ErrMsg("Cannot move a folder into a subsidiary of itself!")
                            Exit Sub
                        End If
                    End If
                Next
            End If

            For Each child As frmFolder In fGenerator.MDIFolders
                child.Folder.RemoveCutItems(nodes)
            Next            
            For Each item As clsItem In CopiedItems
                item = item.Clone
                NewItems.Add(item)
                With item
                    .IsLibrary = False
                    If Adventure.AllKeys.Contains(.Key) Then
                        Dim sOldKey As String = .Key
                        .Key = .GetNewKey
                        If sOldKey <> "" Then dictKeyChanges.Add(sOldKey, .Key)
                        ' Get new priority too
                        If TypeOf item Is clsTask Then
                            CType(item, clsTask).Priority = CurrentMaxPriority(.IsLibrary) + 1
                        End If
                    End If
                    Adventure.dictAllItems.Add(item)
                    If fGenerator.ActiveFolder IsNot Nothing AndAlso SafeString(item.Tag) <> "INFOLDER" Then
                        fGenerator.ActiveFolder.AddSingleItem(.Key)

                        If nodes IsNot Nothing Then
                            Dim treenode As Infragistics.Win.UltraWinTree.UltraTreeNode = fGenerator.FolderList1.treeFolders.GetNodeByKey(fGenerator.ActiveFolder.folder.Key)
                            For Each node As Infragistics.Win.UltraWinTree.UltraTreeNode In nodes
                                If node IsNot Nothing Then treenode.Nodes.Add(node)
                            Next
                        End If

                    End If
                End With
            Next

            ' Sort out any folder members
            For Each item As clsItem In NewItems
                If TypeOf item Is clsFolder Then
                    Dim NewMembers As New clsFolder.MemberList
                    With CType(item, clsFolder)
                        For Each sOldMember As String In .Members
                            If dictKeyChanges.ContainsKey(sOldMember) Then
                                NewMembers.Add(dictKeyChanges(sOldMember))
                            Else
                                NewMembers.Add(sOldMember)
                            End If
                        Next
                        .Members = NewMembers
                    End With                    

                End If
            Next
        Else
            ErrMsg("There are no items in the clipboard!")
        End If

    End Sub


    'Public Sub PasteItem()

    'If Not CopiedItem Is Nothing Then

    '    Select Case True
    '        Case TypeOf CopiedItem Is clsLocation
    '            Dim cLocation As clsLocation = CType(CopiedItem, clsLocation).Clone
    '            With cLocation
    '                If Adventure.AllKeys.Contains(.Key) Then .Key = Adventure.GetNewKey("Location")
    '                Adventure.htblLocations.Add(cLocation, .Key)
    '                UpdateListItem(.Key, .ShortDescription)
    '            End With

    '        Case TypeOf CopiedItem Is clsObject
    '            Dim cObject As clsObject = CType(CopiedItem, clsObject).Clone
    '            With cObject
    '                If Adventure.AllKeys.Contains(.Key) Then .Key = Adventure.GetNewKey("Object")
    '                Adventure.htblObjects.Add(cObject, .Key)
    '                UpdateListItem(.Key, .FullName)
    '            End With

    '        Case TypeOf CopiedItem Is clsTask
    '            Dim cTask As clsTask = CType(CopiedItem, clsTask).Clone ' .Copy
    '            With cTask
    '                If Adventure.AllKeys.Contains(.Key) Then .Key = Adventure.GetNewKey("Task")
    '                Adventure.htblTasks.Add(cTask, .Key)
    '                UpdateListItem(.Key, .Description)
    '            End With

    '        Case TypeOf CopiedItem Is clsEvent
    '            Dim cEvent As clsEvent = CType(CopiedItem, clsEvent).Clone
    '            With cEvent
    '                If Adventure.AllKeys.Contains(.Key) Then .Key = Adventure.GetNewKey("Event")
    '                Adventure.htblEvents.Add(cEvent, .Key)
    '                UpdateListItem(.Key, .Description)
    '            End With

    '        Case TypeOf CopiedItem Is clsCharacter
    '            Dim cCharacter As clsCharacter = CType(CopiedItem, clsCharacter).Clone
    '            With cCharacter
    '                If Adventure.AllKeys.Contains(.Key) Then .Key = Adventure.GetNewKey("Character")
    '                Adventure.htblCharacters.Add(cCharacter, .Key)
    '                UpdateListItem(.Key, .ProperName)
    '            End With

    '        Case TypeOf CopiedItem Is clsALR
    '            Dim cALR As clsALR = CType(CopiedItem, clsALR).Clone
    '            With cALR
    '                If Adventure.AllKeys.Contains(.Key) Then .Key = Adventure.GetNewKey("ALR")
    '                Adventure.htblALRs.Add(cALR, .Key)
    '                UpdateListItem(.Key, .OldText.ToString)
    '            End With

    '        Case TypeOf CopiedItem Is clsGroup
    '            Dim cGroup As clsGroup = CType(CopiedItem, clsGroup).Clone
    '            With cGroup
    '                If Adventure.AllKeys.Contains(.Key) Then .Key = Adventure.GetNewKey("LocationGroup")
    '                Adventure.htblGroups.Add(cGroup, .Key)
    '                UpdateListItem(.Key, .Name)
    '            End With

    '        Case TypeOf CopiedItem Is clsHint
    '            Dim cHint As clsHint = CType(CopiedItem, clsHint).Clone
    '            With cHint
    '                If Adventure.AllKeys.Contains(.Key) Then .Key = Adventure.GetNewKey("Hint")
    '                Adventure.htblHints.Add(cHint, .Key)
    '                UpdateListItem(.Key, .Question)
    '            End With

    '        Case TypeOf CopiedItem Is clsProperty
    '            Dim cProperty As clsProperty = CType(CopiedItem, clsProperty).Clone
    '            With cProperty
    '                If Adventure.AllKeys.Contains(.Key) Then .Key = Adventure.GetNewKey("Property")
    '                Adventure.htblAllProperties.Add(cProperty, .Key)
    '                UpdateListItem(.Key, .Description)
    '            End With

    '        Case TypeOf CopiedItem Is clsVariable
    '            Dim cVariable As clsVariable = CType(CopiedItem, clsVariable).Clone
    '            With cVariable
    '                If Adventure.AllKeys.Contains(.Key) Then .Key = Adventure.GetNewKey("Variable")
    '                Adventure.htblVariables.Add(cVariable, .Key)
    '                UpdateListItem(.Key, .Name)
    '            End With

    '        Case Else
    '            ErrMsg("Not possible to paste items of type " & CopiedItem.GetType.ToString & "!")
    '    End Select

    'End If

    'End Sub


    'Public Class ListInfo

    '    Public sName As String
    '    'Public sAdventure As String ' "ALL" if global

    '    Public arlKeys As New Generic.List(Of String)

    '    Public s As Size
    '    Public p As Point
    '    Public bVisible As Boolean


    '    Public Sub New(ByVal Name As String, Optional ByVal bFirst As Boolean = False)
    '        sName = Name
    '        AddTool(fGenerator.UTMMain, "mnuView", "_LIST_" & sName, sName, "_LIST_", bFirst)
    '    End Sub

    '    Public Function GetForm() As frmList
    '        For Each frm As frmList In fGenerator.MdiChildren
    '            If frm.ListInfo Is Me Then Return frm
    '        Next
    '        Return Nothing
    '    End Function

    'End Class
    'Public colLists As New Collection



    'Private Sub GenerateDefaultLists()

    '    Dim LocationList As New ListInfo("Locations", True)
    '    With LocationList
    '        .bVisible = True
    '        .s = New Size(CInt(CInt(GetSetting("ADRIFT", "Generator", "Subw1", "3000")) / 15), CInt(CInt(GetSetting("ADRIFT", "Generator", "Subh1", "500")) / 15))
    '        .p = New Point(CInt(CInt(GetSetting("ADRIFT", "Generator", "Subx1", "0")) / 15), CInt(CInt(GetSetting("ADRIFT", "Generator", "Suby1", "0")) / 15))
    '    End With
    '    colLists.Add(LocationList, LocationList.sName)

    '    Dim ObjectList As New ListInfo("Objects")
    '    With ObjectList
    '        .bVisible = True
    '        .s = New Size(CInt(CInt(GetSetting("ADRIFT", "Generator", "Subw2", "200")) / 15), CInt(CInt(GetSetting("ADRIFT", "Generator", "Subh2", "500")) / 15))
    '        .p = New Point(CInt(CInt(GetSetting("ADRIFT", "Generator", "Subx2", "150")) / 15), CInt(CInt(GetSetting("ADRIFT", "Generator", "Suby2", "0")) / 15))
    '    End With
    '    colLists.Add(ObjectList, ObjectList.sName)

    '    Dim TaskList As New ListInfo("Tasks")
    '    With TaskList
    '        .bVisible = True
    '        .s = New Size(CInt(CInt(GetSetting("ADRIFT", "Generator", "Subw3", "200")) / 15), CInt(CInt(GetSetting("ADRIFT", "Generator", "Subh3", "500")) / 15))
    '        .p = New Point(CInt(CInt(GetSetting("ADRIFT", "Generator", "Subx3", "300")) / 15), CInt(CInt(GetSetting("ADRIFT", "Generator", "Suby3", "0")) / 15))
    '    End With
    '    colLists.Add(TaskList, TaskList.sName)

    '    Dim EventList As New ListInfo("Events")
    '    With EventList
    '        .bVisible = True
    '        .s = New Size(CInt(CInt(GetSetting("ADRIFT", "Generator", "Subw4", "200")) / 15), CInt(CInt(GetSetting("ADRIFT", "Generator", "Subh4", "500")) / 15))
    '        .p = New Point(CInt(CInt(GetSetting("ADRIFT", "Generator", "Subx4", "450")) / 15), CInt(CInt(GetSetting("ADRIFT", "Generator", "Suby4", "0")) / 15))
    '    End With
    '    colLists.Add(EventList, EventList.sName)

    '    Dim CharList As New ListInfo("Characters")
    '    With CharList
    '        .bVisible = True
    '        .s = New Size(CInt(CInt(GetSetting("ADRIFT", "Generator", "Subw0", "200")) / 15), CInt(CInt(GetSetting("ADRIFT", "Generator", "Subh0", "500")) / 15))
    '        .p = New Point(CInt(CInt(GetSetting("ADRIFT", "Generator", "Subx0", "600")) / 15), CInt(CInt(GetSetting("ADRIFT", "Generator", "Suby0", "0")) / 15))
    '    End With
    '    colLists.Add(CharList, CharList.sName)

    '    Dim VarList As New ListInfo("Variables")
    '    With VarList
    '        .bVisible = False
    '        .p = New Point(100, 100)
    '        .s = New Size(200, 400)
    '    End With
    '    colLists.Add(VarList, VarList.sName)

    '    Dim ALRList As New ListInfo("Text Overrides")
    '    With ALRList
    '        .bVisible = False
    '        .p = New Point(200, 100)
    '        .s = New Size(200, 400)
    '    End With
    '    colLists.Add(ALRList, ALRList.sName)

    '    Dim GroupList As New ListInfo("Groups")
    '    With GroupList
    '        .bVisible = False
    '        .p = New Point(300, 100)
    '        .s = New Size(200, 400)
    '    End With
    '    colLists.Add(GroupList, GroupList.sName)

    '    Dim HintList As New ListInfo("Hints")
    '    With HintList
    '        .bVisible = False
    '        .p = New Point(400, 100)
    '        .s = New Size(200, 400)
    '    End With
    '    colLists.Add(HintList, HintList.sName)

    '    Dim PropList As New ListInfo("Properties")
    '    With PropList
    '        .bVisible = False
    '        .p = New Point(500, 100)
    '        .s = New Size(200, 400)
    '    End With
    '    colLists.Add(PropList, PropList.sName)

    '    Dim bShowLibrary As Boolean = Not CBool(GetSetting("ADRIFT", "Generator", "HideLibraryItems", "True"))

    '    With Adventure
    '        Dim li As ListInfo = CType(colLists("Locations"), ListInfo)
    '        For Each loc As clsLocation In .htblLocations.Values
    '            'If bShowLibrary OrElse Not loc.IsLibrary Then
    '            li.arlKeys.Add(loc.Key)
    '        Next
    '        li = CType(colLists("Objects"), ListInfo)
    '        For Each obj As clsObject In .htblObjects.Values
    '            'If bShowLibrary OrElse Not obj.IsLibrary Then 
    '            li.arlKeys.Add(obj.Key)
    '        Next
    '        li = CType(colLists("Tasks"), ListInfo)
    '        For Each task As clsTask In .htblTasks.Values
    '            If bShowLibrary OrElse Not task.IsLibrary Then li.arlKeys.Add(task.Key)
    '        Next
    '        li = CType(colLists("Events"), ListInfo)
    '        For Each evnt As clsEvent In .htblEvents.Values
    '            'If bShowLibrary OrElse Not evnt.IsLibrary Then 
    '            li.arlKeys.Add(evnt.Key)
    '        Next
    '        li = CType(colLists("Characters"), ListInfo)
    '        For Each cha As clsCharacter In .htblCharacters.Values
    '            'If bShowLibrary OrElse Not cha.IsLibrary OrElse cha.Key = .Player.Key Then 
    '            li.arlKeys.Add(cha.Key)
    '        Next
    '        li = CType(colLists("Variables"), ListInfo)
    '        For Each var As clsVariable In .htblVariables.Values
    '            'If bShowLibrary OrElse Not var.IsLibrary Then 
    '            li.arlKeys.Add(var.Key)
    '        Next
    '        li = CType(colLists("Groups"), ListInfo)
    '        For Each grp As clsGroup In .htblGroups.Values
    '            'If bShowLibrary OrElse Not grp.IsLibrary Then 
    '            li.arlKeys.Add(grp.Key)
    '        Next
    '        li = CType(colLists("Text Overrides"), ListInfo)
    '        For Each alr As clsALR In .htblALRs.Values
    '            'If bShowLibrary OrElse Not alr.IsLibrary Then 
    '            li.arlKeys.Add(alr.Key)
    '        Next
    '        li = CType(colLists("Hints"), ListInfo)
    '        For Each hnt As clsHint In .htblHints.Values
    '            'If bShowLibrary OrElse Not hnt.IsLibrary Then 
    '            li.arlKeys.Add(hnt.Key)
    '        Next
    '        li = CType(colLists("Properties"), ListInfo)
    '        For Each prp As clsProperty In .htblAllProperties.Values
    '            If bShowLibrary OrElse Not prp.IsLibrary Then li.arlKeys.Add(prp.Key)
    '        Next

    '    End With

    'End Sub


    'Public Function FindList(ByVal sTitle As String) As frmList

    '    For Each frm As frmList In fGenerator.MdiChildren
    '        If frm.Text = sTitle Then
    '            Return frm
    '        End If
    '    Next

    '    Return Nothing

    'End Function



    'Public Sub ShowList(ByRef li As ListInfo)

    '    Dim frmList As frmList = FindList(li.sName)
    '    If frmList Is Nothing Then frmList = New frmList(li)
    '    frmList.Show() '.Visible = True
    '    frmList.Tag = ""

    'End Sub


    Public Sub OpenModule(ByVal sFilename As String)

        ' Just do same as open adventure for now
        'Dim OldAdventure As clsAdventure = Adventure

        'Adventure = New clsAdventure
        'LoadDefaults()
        '        If LoadFile(sFilename, FileIO.FileTypeEnum.TextAdventure_TAF) Then
        If LoadFile(sFilename, FileIO.FileTypeEnum.XMLModule_AMF, LoadWhatEnum.All, False) Then
            fGenerator.FolderList1.InitialiseTree()
        Else
            '    Adventure = OldAdventure
        End If

    End Sub


    Public Function GetFileSize(ByVal sfilename As String) As String

        If File.Exists(sfilename) Then
            Dim fi As New IO.FileInfo(sfilename)
            Dim lSize As Long = fi.Length
            If lSize < 1024 Then
                Return lSize & " bytes"
            ElseIf lSize < 10240 Then
                Return (lSize / 1024).ToString("#,##0.##") & " KB"
            ElseIf lSize < 1024 * 1024 Then
                Return (lSize / 1024).ToString("#,##0.#") & " KB"
            Else
                Return (lSize / 1024 / 1024).ToString("#,##0.##") & " MB"
            End If
        Else
            Return ""
        End If

    End Function


    Public Sub NotAvailable()
        ErrMsg("Sorry, this feature is not available in the unregistered version.")
    End Sub



    Public Sub OpenAdventure(ByVal sFilename As String)

        Dim OldAdventure As clsAdventure = Adventure

        'SaveListsToXML()

        Adventure = New clsAdventure

        For i As Integer = OpenForms.Count - 1 To 0 Step -1
            If OpenForms(i) IsNot fGenerator Then
                OpenForms(i).Close()
            End If
        Next

        Dim eType As FileIO.FileTypeEnum = FileTypeEnum.TextAdventure_TAF
        If sFilename.EndsWith("blorb") Then eType = FileTypeEnum.Blorb
#If DEBUG Then
        If sFilename.EndsWith("exe") Then
            ' Work out whether we have a TAF appended on the end.  If so, run that in Executable mode
            ' Grab out the last 8 bytes, and see if it converts to a size
            Dim bData(5) As Byte
            Dim fStream As New IO.FileStream(sFilename, IO.FileMode.Open, IO.FileAccess.Read)
            fStream.Seek(fStream.Length - 6, IO.SeekOrigin.Begin)
            fStream.Read(bData, 0, 6)
            'fStream.Close()

            Dim sFileSize As String = (New System.Text.ASCIIEncoding).GetString(bData).ToUpper
            If IsHex(sFileSize) Then
                Dim lFileSize As Long = CLng("&H" & sFileSize)
                If lFileSize > 0 Then
                    Blorb = New clsBlorb
                    fStream.Seek(lFileSize, IO.SeekOrigin.Begin)
                    clsBlorb.bEXE = True
                    If Not Blorb.LoadBlorb(fStream, sFilename, lFileSize) Then
                        ErrMsg("Error loading embedded Blorb")
                        Exit Sub
                    End If
                End If
            End If
            fStream.Close()
            eType = FileTypeEnum.Exe
        End If
#End If

        If LoadFile(sFilename, eType, LoadWhatEnum.All, False) Then
            'LoadLists(True)
            iLoading = 1
            fGenerator.FolderList1.InitialiseTree()
            iLoading = 0
            UpdateMainTitle()
            fGenerator.StatusBar1.Panels(0).Text = "File version: " & Adventure.Version
            fGenerator.StatusBar1.Panels(1).Text = "File size: " & GetFileSize(sFilename)
            fGenerator.StatusBar1.Panels(2).Text = "Maximum score: " & Adventure.MaxScore
            AddFileToList(Adventure.FullPath)
            If Adventure.Password <> "" Then
                fGenerator.UTMMain.Tools("ProtectAdventure").SharedProps.Caption = "Unprotect Adventure"
                fGenerator.UTMMain.Tools("ProtectAdventure").SharedProps.AppearancesLarge.Appearance.Image = My.Resources.Resources.imgLock32
            Else
                fGenerator.UTMMain.Tools("ProtectAdventure").SharedProps.Caption = "Protect Adventure"
                fGenerator.UTMMain.Tools("ProtectAdventure").SharedProps.AppearancesLarge.Appearance.Image = My.Resources.Resources.imgUnlock32
            End If
        Else
            Adventure = OldAdventure
        End If

    End Sub


    Public Sub UpdateMainTitle()

        If Adventure IsNot Nothing Then
            fGenerator.Text = Adventure.Title & " - ADRIFT Developer - [" & Adventure.Filename & "]"
        Else
            fGenerator.Text = "ADRIFT Developer"
        End If

        'If fGenerator.SimpleMode Then fGenerator.Text &= " - Simple Mode: On"

    End Sub

    '    Public Sub LoadLists(ByVal bNewAdventure As Boolean)

    '        Try

    '            If bNewAdventure Then
    '                Dim sListsFile As String = sLocalDataPath & Adventure.Filename.Replace(".taf", ".xml")


    '                ' Gets rid of all the configurable Lists from the menu
    '                For m As Integer = fGenerator.UTMMain.Tools.Count - 1 To 0 Step -1
    '                    If sLeft(fGenerator.UTMMain.Tools(m).Key, 6) = "_LIST_" Then
    '                        fGenerator.UTMMain.Tools.RemoveAt(m)
    '                    End If
    '                Next

    '                ' Clear any defined lists first
    '                For i As Integer = colLists.Count To 1 Step -1
    '                    colLists.Remove(i)
    '                Next

    '                If File.Exists(sListsFile) Then

    '                    Dim bShowLibrary As Boolean = Not CBool(GetSetting("ADRIFT", "Generator", "HideLibraryItems", "True"))

    '                    Try
    '                        Dim xmlDoc As New XmlDocument
    '                        xmlDoc.Load(sListsFile)
    '                        Dim bFirst As Boolean = True

    '                        For Each nod As XmlNode In xmlDoc.SelectNodes("/Lists/List")
    '                            Dim li As New ListInfo(nod.SelectSingleNode("Name").InnerText, bFirst)
    '                            bFirst = False

    '                            li.p.X = CInt(nod.SelectSingleNode("Position/X").InnerText)
    '                            li.p.Y = CInt(nod.SelectSingleNode("Position/Y").InnerText)

    '                            li.s.Height = CInt(nod.SelectSingleNode("Size/Height").InnerText)
    '                            li.s.Width = CInt(nod.SelectSingleNode("Size/Width").InnerText)

    '                            li.bVisible = CBool(nod.SelectSingleNode("Visible").InnerText)

    '                            For Each nodItem As XmlNode In nod.SelectNodes("Item")
    '                                Dim bAddToList As Boolean = False
    '                                Select Case Adventure.GetTypeFromKeyNice(nodItem.InnerText, True)
    '                                    Case "Tasks", "Properties"
    '                                        bAddToList = bShowLibrary OrElse Not Adventure.IsItemLibrary(nodItem.InnerText)
    '                                    Case ""
    '                                        bAddToList = False
    '                                    Case Else
    '                                        bAddToList = True
    '                                End Select
    '                                If bAddToList Then ' If Not Adventure.GetTypeFromKey(nodItem.InnerText) Is Nothing Then
    '                                    'If bShowLibrary OrElse Not Adventure.IsItemLibrary(nodItem.InnerText) Then
    '                                    If Not li.arlKeys.Contains(nodItem.InnerText) Then li.arlKeys.Add(nodItem.InnerText)
    '                                    'End If
    '                                End If
    '                            Next
    '                            colLists.Add(li, li.sName)

    '                        Next

    '                        ' Need to bung everything that isn't in a List into a default list

    '                        For Each sKey As String In Adventure.AllKeys
    '                            'IsItemLibrary                            ' If not library item then...
    '                            If bShowLibrary OrElse Not Adventure.IsItemLibrary(sKey) Then
    '                                For Each li As ListInfo In colLists
    '                                    If li.arlKeys.Contains(sKey) Then GoTo NextList
    '                                Next
    '                                ' Not found, so add to default list
    '                                AddToDefaultList(sKey)
    '                            End If
    'NextList:
    '                        Next

    '                    Catch ex As Exception
    '                        ErrMsg("Error loading Lists XML file", ex)
    '                    End Try
    '                Else
    '                    GenerateDefaultLists()
    '                End If


    '                ' Mark any existing forms in new selection as to stay
    '                For Each li As ListInfo In colLists
    '                    Dim frm As frmList = FindList(li.sName)
    '                    If Not frm Is Nothing Then frm.Tag = "KEEP"
    '                Next
    '                For Each frm As frmList In fGenerator.MdiChildren
    '                    If CStr(frm.Tag) <> "KEEP" Then
    '                        frm.Visible = False
    '                        frm.Dispose()
    '                    End If
    '                Next
    '            End If

    '            For Each li As ListInfo In colLists
    '                Dim frm As frmList = FindList(li.sName)
    '                If frm Is Nothing Then
    '                    frm = New frmList(li)
    '                Else
    '                    If li.bVisible Then frm.Show()
    '                    frm.PopulateList(li)
    '                End If
    '                frm.Tag = ""
    '                frm.DoSummary()
    '            Next

    '            Dim bCascade As Boolean = False
    '            For Each frm As frmList In fGenerator.MdiChildren
    '                If frm.Width < 50 OrElse frm.Height < 50 Then
    '                    bCascade = True
    '                End If
    '            Next
    '            If bCascade Then fGenerator.LayoutMdi(MdiLayout.Cascade)

    '        Catch ex As Exception
    '            ErrMsg("LoadLists error", ex)
    '        End Try

    '    End Sub



    'Public Sub AddToDefaultList(ByVal sKey As String)

    '    ' Should we add to list
    '    Dim bAddToList As Boolean = True
    '    If CBool(GetSetting("ADRIFT", "Generator", "HideLibraryItems", "True")) Then
    '        ' We only hide the task and property library items ... cos figure if someone adds the rest, the user would want to know about them
    '        Select Case Adventure.GetTypeFromKeyNice(sKey, True)
    '            Case "Tasks", "Properties"
    '                If Adventure.IsItemLibrary(sKey) Then Exit Sub
    '            Case Else
    '                ' Continue to add to list
    '        End Select
    '    End If


    '    '       If Not CBool(GetSetting("ADRIFT", "Generator", "HideLibraryItems", "True")) OrElse Not Adventure.IsItemLibrary(sKey) Then
    '    For Each li As ListInfo In colLists
    '        If Adventure.GetTypeFromKeyNice(sKey, True) = li.sName Then
    '            li.arlKeys.Add(sKey)
    '            If Not li.GetForm Is Nothing Then li.GetForm.ItemList.AddItemToList(sKey)
    '            Exit Sub
    '        End If
    '    Next

    '    ' Ok, we didn't find a nice list, just bung it in the first one
    '    If colLists.Count > 0 Then
    '        With CType(colLists(1), ListInfo)
    '            .arlKeys.Add(sKey)
    '            If Not .GetForm Is Nothing Then .GetForm.ItemList.AddItemToList(sKey)
    '        End With
    '    Else
    '        'ErrMsg("No defined lists!")
    '    End If
    '    '        End If

    'End Sub


    'Public Sub SaveListsToXML()

    '    If Adventure Is Nothing Then Exit Sub

    '    Dim xmlWriter As XmlTextWriter
    '    Dim sListsFile As String = sLocalDataPath & Adventure.Filename.Replace(".taf", ".xml")

    '    xmlWriter = New XmlTextWriter(sListsFile, System.Text.Encoding.UTF8)

    '    With xmlWriter
    '        .Indentation = 4
    '        .IndentChar = " "c
    '        .Formatting = Formatting.Indented

    '        .WriteStartDocument()
    '        .WriteComment("File created by ADRIFT v" & Application.ProductVersion)

    '        .WriteStartElement("Lists")

    '        For Each li As ListInfo In colLists

    '            .WriteStartElement("List")

    '            .WriteElementString("Name", li.sName)

    '            .WriteStartElement("Size")
    '            .WriteElementString("Height", li.s.Height.ToString)
    '            .WriteElementString("Width", li.s.Width.ToString)
    '            .WriteEndElement() ' Size

    '            .WriteStartElement("Position")
    '            .WriteElementString("X", li.p.X.ToString)
    '            .WriteElementString("Y", li.p.Y.ToString)
    '            .WriteEndElement() ' Position

    '            .WriteElementString("Visible", li.bVisible.ToString)
    '            '.WriteElementString("Adventure", li.sAdventure)

    '            For Each sKey As String In li.arlKeys
    '                .WriteElementString("Item", sKey)
    '            Next

    '            .WriteEndElement() ' List

    '        Next

    '        .WriteEndElement() ' Lists

    '        .WriteEndDocument()

    '        .Flush()
    '        .Close()

    '    End With

    'End Sub


    Public Function AddTool(ByRef UTMTarget As UltraToolbarsManager, ByVal sTargetTool As String, ByVal sKey As String, ByVal sCaption As String, Optional ByVal sTag As String = "", Optional ByVal bFirstInGroup As Boolean = False, Optional ByVal sToolTip As String = "") As ButtonTool

        Try
            If Not UTMTarget.Tools.Exists(sKey) Then
                Dim newTool As New ButtonTool(sKey)

                newTool.SharedProps.Caption = sCaption
                newTool.SharedProps.Tag = sTag
                If sToolTip <> "" Then newTool.SharedProps.ToolTipText = sToolTip
                UTMTarget.Tools.Add(newTool)

                Dim newinstance As ButtonTool = CType(CType(UTMTarget.Tools(sTargetTool), PopupMenuTool).Tools.AddTool(sKey), ButtonTool)
                newinstance.InstanceProps.IsFirstInGroup = bFirstInGroup
                Return newTool
            End If
        Catch ex As Exception
            ' Probably a duplicate key
        End Try
        Return Nothing

    End Function




    'Public Sub EditLocation(ByVal Location As clsLocation)

    '    Dim frmLocation As New frmLocation

    '    With frmLocation
    '        .Text = "Location - " & Location.ShortDescription
    '        .txtShortDesc.Text = Location.ShortDescription
    '        .txtLongDesc.txtSource = Location.LongDescription
    '        .Changed = False

    '        .Show()
    '    End With

    'End Sub



    Public Sub CloseLocation(ByVal frmLocation As frmLocation)

        SaveFormPosition(frmLocation)
        With frmLocation
            .Close()
            .Dispose()
        End With

    End Sub

    Public Sub CloseGroup(ByVal frmGroup As frmGroup)

        SaveFormPosition(frmGroup)
        With frmGroup
            .Close()
            If Not .bModal Then .Dispose()
        End With

    End Sub

    Public Sub CloseProperty(ByVal frmProperty As frmProperty)

        SaveFormPosition(frmProperty)
        With frmProperty
            .Close()
            .Dispose()
        End With

    End Sub


    Public Sub CloseObject(ByVal frmObject As frmObject)

        SaveFormPosition(frmObject)
        With frmObject
            .Close()
            .Dispose()
        End With

    End Sub


    Public Sub CloseCharacter(ByVal frmCharacter As frmCharacter)

        SaveFormPosition(frmCharacter)
        With frmCharacter
            .Close()
            .Dispose()
        End With

    End Sub


    Public Sub CloseVariable(ByVal frmVariable As frmVariable)

        SaveFormPosition(frmVariable)
        With frmVariable
            .Close()
            .Dispose()
        End With

    End Sub

    Public Sub CloseEvent(ByVal frmEvent As frmEvent)

        SaveFormPosition(frmEvent)
        With frmEvent
            .Close()
            .Dispose()
        End With

    End Sub

    Public Sub CloseTask(ByVal frmTask As frmTask)

        SaveFormPosition(frmTask)
        With frmTask
            .Close()
            '.Visible = False
            If Not .bKeepOpen Then .Dispose()
        End With

    End Sub

    Public Sub CloseHint(ByVal frmHint As frmHint)

        SaveFormPosition(frmHint)
        With frmHint
            .Close()
            .Dispose()
        End With

    End Sub

    Public Sub CloseALR(ByVal frmALR As frmTextOverride)

        SaveFormPosition(frmALR)
        With frmALR
            .Close()
            .Dispose()
        End With

    End Sub

    Public Sub CloseUDF(ByVal frmUDF As frmUserFunction)

        SaveFormPosition(frmUDF)
        With frmUDF
            .Close()
            .Dispose()
        End With

    End Sub

    Public Sub CloseSynonym(ByVal frmSyn As frmSynonym)

        SaveFormPosition(frmSyn)
        With frmSyn
            .Close()
            .Dispose()
        End With

    End Sub

    Public Sub CloseSettings(ByRef frmSettings As frmSettings)

        SaveFormPosition(frmSettings)
        With frmSettings
            .Close()
            .Dispose()
        End With
        fGenerator.fSettings = Nothing

    End Sub

    Public Sub CloseOptions(ByRef frmOptions As frmOptions)

        SaveFormPosition(frmOptions)
        With frmOptions
            .Close()
            .Dispose()
        End With
        fGenerator.fOptions = Nothing

    End Sub

    Public Sub SaveFormPosition(ByVal frmForm As System.Windows.Forms.Form)

        ' Function to record the position and state of a form
        SaveSetting("ADRIFT", "Generator", frmForm.Name & "_State", Format(frmForm.WindowState))

        If frmForm.WindowState = FormWindowState.Normal Then
            SaveSetting("ADRIFT", "Generator", frmForm.Name & "_Top", Format(frmForm.Top))
            SaveSetting("ADRIFT", "Generator", frmForm.Name & "_Left", Format(frmForm.Left))
            SaveSetting("ADRIFT", "Generator", frmForm.Name & "_Height", Format(frmForm.Height))
            SaveSetting("ADRIFT", "Generator", frmForm.Name & "_Width", Format(frmForm.Width))
        End If

        Try
            If colAllForms.Contains(frmForm.Handle.ToString) Then colAllForms.Remove(frmForm.Handle.ToString)
        Catch ex As Exception
            ErrMsg("SaveFormPosition", ex)
        End Try

    End Sub


    Public Sub GetFormPosition(ByRef frmForm As System.Windows.Forms.Form, Optional ByVal utm As UltraWinToolbars.UltraToolbarsManager = Nothing, Optional ByVal udm As UltraWinDock.UltraDockManager = Nothing, Optional ByVal bRestoreSize As Boolean = True, Optional ByVal bExactPosition As Boolean = False)

        Dim iState As FormWindowState
        colAllForms.Add(frmForm, frmForm.Handle.ToString)

        'If rSession.SystemSettingInteger("SuppressWindowMemory", True) <> 0 Then Exit Sub

        ' Function to load the position of a form
        ' What state was it saved in?
        frmForm.AutoScaleMode = AutoScaleMode.Font
        iState = CType(Val(GetSetting("ADRIFT", "Generator", frmForm.Name & "_State", System.Windows.Forms.FormWindowState.Normal.ToString)), FormWindowState)
        Select Case iState
            Case System.Windows.Forms.FormWindowState.Normal ' It was normal or unspecified - so carry on

                Dim iTop As Integer = CInt(GetSetting("ADRIFT", "Generator", frmForm.Name & "_Top", frmForm.Top.ToString))
                Dim iLeft As Integer = CInt(GetSetting("ADRIFT", "Generator", frmForm.Name & "_Left", frmForm.Left.ToString))
                Dim iHeight As Integer = CInt(GetSetting("ADRIFT", "Generator", frmForm.Name & "_Height", frmForm.Height.ToString))
                Dim iWidth As Integer = CInt(GetSetting("ADRIFT", "Generator", frmForm.Name & "_Width", frmForm.Width.ToString))

                If bExactPosition Then frmForm.Location = New Point(iLeft, iTop)
                If bRestoreSize Then frmForm.Size = New Size(iWidth, iHeight)

            Case System.Windows.Forms.FormWindowState.Minimized ' It was minimised - so rest of data is rubbish

            Case System.Windows.Forms.FormWindowState.Maximized ' It was maximised - so maximise!
                frmForm.WindowState = System.Windows.Forms.FormWindowState.Maximized

            Case Else ' Err, shouldn't get here
                ErrMsg("GetFormPosition Error")
        End Select
        If frmForm.Name <> "frmGenerator" AndAlso Not frmForm.Modal Then frmForm.ShowInTaskbar = SafeBool(GetSetting("ADRIFT", "Generator", "ShowInTaskBar", "0"))

        SetWindowStyle(frmForm, utm, udm)

    End Sub



    Public Sub SetWindowStyle(ByVal frmTarget As Form, Optional ByVal utm As UltraWinToolbars.UltraToolbarsManager = Nothing, Optional ByVal udm As UltraWinDock.UltraDockManager = Nothing)

        Try
            frmTarget.SuspendLayout()

            Select Case eStyle
                Case ToolbarStyle.Default
                    'If Not utm Is Nothing Then utm.Style = UltraWinToolbars.ToolbarStyle.Office2000
                    If udm IsNot Nothing Then udm.WindowStyle = UltraWinDock.WindowStyle.Default
                Case ToolbarStyle.Office2003
                    'If Not utm Is Nothing Then utm.Style = UltraWinToolbars.ToolbarStyle.Office2003
                    If udm IsNot Nothing Then udm.WindowStyle = UltraWinDock.WindowStyle.Office2003
                Case ToolbarStyle.Office2007
                    If Not utm Is Nothing Then utm.Style = UltraWinToolbars.ToolbarStyle.Office2007
                    If udm IsNot Nothing Then udm.WindowStyle = UltraWinDock.WindowStyle.Office2007
                Case ToolbarStyle.Office2010
                    If Not utm Is Nothing Then utm.Style = UltraWinToolbars.ToolbarStyle.Office2010
                    If udm IsNot Nothing Then udm.WindowStyle = UltraWinDock.WindowStyle.Office2007
                Case ToolbarStyle.Office2013
                    If Not utm Is Nothing Then utm.Style = UltraWinToolbars.ToolbarStyle.Office2013
                    If udm IsNot Nothing Then udm.WindowStyle = UltraWinDock.WindowStyle.Office2007
                Case ToolbarStyle.VisualStudio2005
                    'If Not utm Is Nothing Then utm.Style = UltraWinToolbars.ToolbarStyle.VisualStudio2005
                    If udm IsNot Nothing Then udm.WindowStyle = UltraWinDock.WindowStyle.VisualStudio2005
                Case Else
            End Select

            For Each c As Control In frmTarget.Controls
                SetControlStyle(c)
            Next

            frmTarget.ResumeLayout()
        Catch
        End Try

    End Sub



    Public Sub SetControlStyle(ByVal c As Control)

        'If TypeOf c Is UltraControlBase Then
        '    CType(c, UltraControlBase).StyleSetName = "c:\program files\Infragistics\NetAdvantage 2006 Volume 3 CLR 2.0\AppStylist\Styles\Office2007Blue.isl"
        'End If

        Dim dsElement As EmbeddableElementDisplayStyle = EmbeddableElementDisplayStyle.Default
        Dim vsTabs As UltraWinTabControl.ViewStyle = UltraWinTabControl.ViewStyle.Default
        Dim vsStatusBar As UltraWinStatusBar.ViewStyle = UltraWinStatusBar.ViewStyle.Default
        Dim vsGroupBox As Misc.GroupBoxViewStyle = Misc.GroupBoxViewStyle.Default
        Dim giCheck As GlyphInfoBase = UIElementDrawParams.StandardCheckBoxGlyphInfo ' UIElementDrawParams.Office2007CheckBoxGlyphInfo
        Dim culLabel As Color = SystemColors.Control
        Dim dsTree As Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle = UltraWinTree.UltraTreeDisplayStyle.Default
        Dim giRadio As GlyphInfoBase = UIElementDrawParams.StandardRadioButtonGlyphInfo

        Select Case eStyle
            Case ToolbarStyle.Default
                dsElement = EmbeddableElementDisplayStyle.Standard
                vsTabs = UltraWinTabControl.ViewStyle.Standard
                vsStatusBar = UltraWinStatusBar.ViewStyle.Standard
                vsGroupBox = Misc.GroupBoxViewStyle.Office2000
                'giCheck = UIElementDrawParams.StandardCheckBoxGlyphInfo
                dsTree = UltraWinTree.UltraTreeDisplayStyle.Standard
            Case ToolbarStyle.Office2003
                dsElement = EmbeddableElementDisplayStyle.Office2003
                vsTabs = UltraWinTabControl.ViewStyle.Office2003
                vsStatusBar = UltraWinStatusBar.ViewStyle.Office2003
                vsGroupBox = Misc.GroupBoxViewStyle.Office2003
                dsTree = UltraWinTree.UltraTreeDisplayStyle.Standard
            Case ToolbarStyle.Office2007
                dsElement = EmbeddableElementDisplayStyle.Office2007
                vsTabs = UltraWinTabControl.ViewStyle.Office2007
                vsStatusBar = UltraWinStatusBar.ViewStyle.Office2007
                vsGroupBox = Misc.GroupBoxViewStyle.Office2007
                'gsCheck = GlyphStyle.Office2007
                giCheck = UIElementDrawParams.Office2007CheckBoxGlyphInfo
                giRadio = UIElementDrawParams.Office2007RadioButtonGlyphInfo
                culLabel = culOffice2007
                dsTree = UltraWinTree.UltraTreeDisplayStyle.WindowsVista
            Case ToolbarStyle.Office2010
                dsElement = EmbeddableElementDisplayStyle.Office2010
                vsTabs = UltraWinTabControl.ViewStyle.Standard ' UltraWinTabControl.ViewStyle.Office2007
                vsStatusBar = UltraWinStatusBar.ViewStyle.Standard ' UltraWinStatusBar.ViewStyle.Office2007
                vsGroupBox = Misc.GroupBoxViewStyle.Default ' Misc.GroupBoxViewStyle.Office2007
                giCheck = UIElementDrawParams.Office2010CheckBoxGlyphInfo
                giRadio = UIElementDrawParams.Office2010RadioButtonGlyphInfo
                culLabel = culOffice2007
                dsTree = UltraWinTree.UltraTreeDisplayStyle.WindowsVista
            Case ToolbarStyle.Office2013
                dsElement = EmbeddableElementDisplayStyle.Office2013
                vsTabs = UltraWinTabControl.ViewStyle.Standard ' UltraWinTabControl.ViewStyle.Office2007
                vsStatusBar = UltraWinStatusBar.ViewStyle.Standard ' UltraWinStatusBar.ViewStyle.Office2007
                vsGroupBox = Misc.GroupBoxViewStyle.Default ' Misc.GroupBoxViewStyle.Office2007
                giCheck = UIElementDrawParams.Office2013CheckBoxGlyphInfo
                giRadio = UIElementDrawParams.Office2013RadioButtonGlyphInfo
                culLabel = culOffice2013
                dsTree = UltraWinTree.UltraTreeDisplayStyle.WindowsVista
            Case ToolbarStyle.VisualStudio2005
                dsElement = EmbeddableElementDisplayStyle.VisualStudio2005
                vsTabs = UltraWinTabControl.ViewStyle.VisualStudio2005
                vsStatusBar = UltraWinStatusBar.ViewStyle.VisualStudio2005
                vsGroupBox = Misc.GroupBoxViewStyle.VisualStudio2005
                dsTree = UltraWinTree.UltraTreeDisplayStyle.WindowsVista
        End Select

        Select Case True
            Case TypeOf c Is UltraWinEditors.UltraComboEditor
                CType(c, UltraWinEditors.UltraComboEditor).DisplayStyle = dsElement
            Case TypeOf c Is UltraWinEditors.UltraDateTimeEditor
                CType(c, UltraWinEditors.UltraDateTimeEditor).DisplayStyle = dsElement
            Case TypeOf c Is UltraWinTabControl.UltraTabControl
                Dim tabs As UltraWinTabControl.UltraTabControl = CType(c, UltraWinTabControl.UltraTabControl)
                tabs.ViewStyle = vsTabs
                'If rSession.bMultiRow Then
                'tabs.TabLayoutStyle = UltraWinTabs.TabLayoutStyle.MultiRowAutoSize
                'Else
                tabs.TabLayoutStyle = UltraWinTabs.TabLayoutStyle.SingleRowAutoSize
                'End If
            Case TypeOf c Is UltraWinTabControl.UltraTabStripControl
                Dim tabs As UltraWinTabControl.UltraTabStripControl = CType(c, UltraWinTabControl.UltraTabStripControl)
                tabs.ViewStyle = vsTabs
                'tabs.HotTrack = rSession.bHotTracking
                'If rSession.bMultiRow Then
                'tabs.TabLayoutStyle = UltraWinTabs.TabLayoutStyle.MultiRowAutoSize
                'Else
                tabs.TabLayoutStyle = UltraWinTabs.TabLayoutStyle.SingleRowAutoSize
                'End If
            Case TypeOf c Is UltraWinStatusBar.UltraStatusBar
                CType(c, UltraWinStatusBar.UltraStatusBar).ViewStyle = vsStatusBar
                'ElseIf TypeOf c Is Misc.UltraButton Then
                'CType(c, Misc.UltraButton).HotTracking = rSession.bHotTracking
                If DarkInterface() Then CType(c, UltraWinStatusBar.UltraStatusBar).Appearance.ForeColor = Color.White
            Case TypeOf c Is Misc.UltraGroupBox
                CType(c, Misc.UltraGroupBox).ViewStyle = vsGroupBox
            Case TypeOf c Is UltraWinProgressBar.UltraProgressBar
                CType(c, UltraWinProgressBar.UltraProgressBar).Style = UltraWinProgressBar.ProgressBarStyle.Default
            Case TypeOf c Is UltraWinEditors.UltraCheckEditor
                CType(c, UltraWinEditors.UltraCheckEditor).GlyphInfo = giCheck
            Case TypeOf c Is UltraWinEditors.UltraOptionSet
                CType(c, UltraWinEditors.UltraOptionSet).GlyphInfo = giRadio
            Case TypeOf c Is Infragistics.Win.Misc.UltraLabel
                'If CStr(CType(c, Infragistics.Win.Misc.UltraLabel).Tag) = "bg" Then
                '    CType(c, Infragistics.Win.Misc.UltraLabel).Appearance.BackColor = culLabel
                'End If
            Case TypeOf c Is Infragistics.Win.UltraWinTree.UltraTree
                CType(c, Infragistics.Win.UltraWinTree.UltraTree).DisplayStyle = dsTree
            Case TypeOf c Is ADRIFT.ItemSelector
                'If c.BackColor = SystemColors.Control Then
                '    CType(c, Generator.ItemSelector).BackColor = culLabel ' Color.Transparent ' culLabel
                'End If
            Case TypeOf c Is ADRIFT.XtoYturns
                'If c.BackColor = SystemColors.Control Then
                '    CType(c, Generator.XtoYturns).BackColor = culLabel
                'End If
            Case TypeOf c Is ADRIFT.GenericProperty
                'If c.BackColor = SystemColors.Control Then
                '    With CType(c, Generator.GenericProperty)
                '        '.Background.Appearance.BackColor = culLabel
                '        '.chkSelected.BackColor = culLabel
                '        '.optSet.BackColor = culLabel
                '        '.optSet.Appearance.BackColorDisabled = culLabel
                '        'If eStyle = UltraWinTabControl.ViewStyle.Office2007 AndAlso eColour = Office2007ColorScheme.Black Then
                '        '    .ForeColor = Color.White
                '        '    .chkSelected.ForeColor = Color.White
                '        'Else
                '        '    .ForeColor = Color.Black
                '        '    .chkSelected.ForeColor = Color.Black
                '        'End If
                '    End With
                'End If
        End Select

        If Not c.Controls Is Nothing Then
            For Each cChild As Control In c.Controls
                SetControlStyle(cChild)
            Next
        End If

    End Sub



    Public Sub FillComboWithLocations(ByRef cmb As UltraWinEditors.UltraComboEditor)

        cmb.Clear()
        cmb.Items.Add("", "<Not Selected>")
        For Each loc As clsLocation In Adventure.htblLocations.Values
            cmb.Items.Add(loc.Key, loc.ShortDescription.ToString)
        Next
        SetCombo(cmb, "")

    End Sub


    Public Function ComboContainsKey(ByVal cmb As Infragistics.Win.UltraWinEditors.UltraComboEditor, ByVal sKey As String) As Boolean

        ' We should be able to rewrite this to look at the underlying collection and use the key
        For Each vli As Infragistics.Win.ValueListItem In cmb.Items
            If CStr(vli.DataValue) = sKey Then Return True
        Next

        Return False
    End Function



    'Public Function SelectedListItem() As ListViewItem

    '    For Each fList As frmList In fGenerator.MdiChildren
    '        If fList.ItemList.lvwList.SelectedItems.Count > 0 Then Return fList.ItemList.lvwList.SelectedItems(0)
    '    Next
    '    Return Nothing

    'End Function


    'Public Sub RemoveListItem(ByVal sKey As String)

    '    For Each fList As frmList In fGenerator.MdiChildren
    '        For Each lvi As ListViewItem In fList.ItemList.lvwList.Items
    '            If CStr(lvi.SubItems(2).Text) = sKey Then
    '                fList.ItemList.lvwList.Items.Remove(lvi)
    '                fList.ListInfo.arlKeys.Remove(lvi.SubItems(2).Text)
    '                If SelectedListItem() Is Nothing Then
    '                    fGenerator.UTMMain.Tools("Cut").SharedProps.Enabled = False
    '                    fGenerator.UTMMain.Tools("Copy").SharedProps.Enabled = False
    '                End If
    '                Exit Sub
    '            End If
    '        Next lvi
    '    Next fList

    'End Sub


    Public Sub UpdateListItem(ByVal sKey As String, ByVal sName As String)

        If SafeBool(GetSetting("ADRIFT", "Generator", "HideLibraryItems", "-1")) AndAlso Adventure.IsItemLibrary(sKey) Then
            Select Case Adventure.GetTypeFromKeyNice(sKey)
                Case "Task", "Property"
                    Exit Sub
                Case Else
                    ' Fine
            End Select
        End If

        ' Update existing items on open lists
        For Each frm As frmFolder In fGenerator.MDIFolders            
            Dim child As frmFolder = CType(frm, frmFolder)            

            For Each lvi As Infragistics.Win.UltraWinListView.UltraListViewItem In child.Folder.lstContents.Items
                If lvi.SubItems.Count > 3 Then
                    If CStr(lvi.SubItems(3).Text) = sKey Then
                        lvi.Value = sName
                        Select Case Adventure.GetTypeFromKeyNice(sKey)
                            Case "Task"
                                Select Case Adventure.htblTasks(sKey).TaskType
                                    Case clsTask.TaskTypeEnum.General
                                        lvi.Appearance.Image = My.Resources.Resources.imgTaskGeneral16
                                    Case clsTask.TaskTypeEnum.Specific
                                        lvi.Appearance.Image = My.Resources.Resources.imgTaskSpecific16
                                    Case clsTask.TaskTypeEnum.System
                                        lvi.Appearance.Image = My.Resources.Resources.imgTaskSystem16
                                End Select
                            Case "Object"
                                If Adventure.htblObjects(sKey).IsStatic Then
                                    lvi.Appearance.Image = My.Resources.Resources.imgObjectStatic16
                                Else
                                    lvi.Appearance.Image = My.Resources.Resources.imgObjectDynamic16
                                End If
                        End Select
                        lvi.SubItems(1).Value = Now
                        Exit Sub
                    End If
                End If
            Next
        Next

        ' Is it in a closed list?  If so, just exit
        For Each folder As clsFolder In Adventure.dictFolders.Values
            For Each sMember As String In folder.Members
                If sKey = sMember Then Exit Sub
            Next
        Next

        ' Not on any list so must be new - just add to active list
        If fGenerator.sDestinationList <> "" Then
            ' First, see if we have an open folder to put it in
            For Each frmChild As frmFolder In fGenerator.MDIFolders
                If frmChild.Folder.folder.Key = fGenerator.sDestinationList Then
                    CType(frmChild, frmFolder).Folder.AddSingleItem(sKey)
                    Exit Sub
                End If
            Next
            ' Try to match a closed folder by key
            For Each folder As clsFolder In Adventure.dictFolders.Values
                If folder.Key = fGenerator.sDestinationList Then
                    folder.Members.Add(sKey)
                    Exit Sub
                End If
            Next
            ' Try to match an open folder by name
            For Each frmChild As frmFolder In fGenerator.MDIFolders
                If frmChild.Folder.folder.Name = fGenerator.sDestinationList Then
                    CType(frmChild, frmFolder).Folder.AddSingleItem(sKey)
                    Exit Sub
                End If
            Next
            ' Try to match a closed folder by name
            For Each folder As clsFolder In Adventure.dictFolders.Values
                If folder.Name = fGenerator.sDestinationList Then
                    folder.Members.Add(sKey)
                    Exit Sub
                End If
            Next
        End If

        ' If we find folder matching the type, bung it in there
        Dim sType As String = Adventure.GetTypeFromKeyNice(sKey, True)
        For Each frmChild As frmFolder In fGenerator.MDIFolders
            If frmChild.Folder.folder.Name = sType Then
                CType(frmChild, frmFolder).Folder.AddSingleItem(sKey)
                Exit Sub
            End If
        Next
        ' Try to match a closed folder by name
        For Each folder As clsFolder In Adventure.dictFolders.Values
            If folder.Name = sType Then
                folder.Members.Add(sKey)
                Exit Sub
            End If
        Next

        ' Finally, either stick it in the active folder, or the Root
        If fGenerator.ActiveFolder IsNot Nothing Then
            fGenerator.ActiveFolder.AddSingleItem(sKey)
        Else
            Adventure.dictFolders("ROOT").Members.Add(sKey)                     
        End If

    End Sub



    Public Function OpenBlorbDialog(ByVal ofd As System.Windows.Forms.OpenFileDialog) As clsBlorb


        ofd.Filter = "ADRIFT Blorb Files (*.blorb)|*.blorb|All Blorb Files (*.*blorb;*.blb;*.glb;*.zlb)|*.*blorb;*.blb;*.glb;*.zlb|All Files (*.*)|*.*"
        ofd.DefaultExt = "blorb"
        If ofd.FileName.Length > 5 AndAlso Not ofd.FileName.ToLower.EndsWith("blorb") Then ofd.FileName = ""
        If ofd.ShowDialog() = DialogResult.OK AndAlso ofd.FileName <> "" Then
            If IO.File.Exists(ofd.FileName) Then
#If DEBUG Then
                If ofd.FileName.EndsWith("exe") Then
                    ' Work out whether we have a TAF appended on the end.  If so, run that in Executable mode
                    ' Grab out the last 8 bytes, and see if it converts to a size
                    Dim bData(5) As Byte
                    Dim fStream As New IO.FileStream(ofd.FileName, IO.FileMode.Open, IO.FileAccess.Read)
                    fStream.Seek(fStream.Length - 6, IO.SeekOrigin.Begin)
                    fStream.Read(bData, 0, 6)
                    'fStream.Close()

                    Dim sFileSize As String = (New System.Text.ASCIIEncoding).GetString(bData).ToUpper

                    If IsHex(sFileSize) Then
                        Dim lFileSize As Long = CLng("&H" & sFileSize)
                        If lFileSize > 0 Then
                            Blorb = New clsBlorb
                            fStream.Seek(lFileSize, IO.SeekOrigin.Begin)
                            clsBlorb.bEXE = True
                            If Not Blorb.LoadBlorb(fStream, ofd.FileName, lFileSize) Then
                                ErrMsg("Error loading embedded Blorb")
                                Return Nothing
                            End If
                        End If
                    End If
                    fStream.Close()
                    Return Blorb
                End If
#End If
                Return LoadBlorb(ofd.FileName)
            Else
                ErrMsg("File not found!")
            End If
        End If

        Return Nothing

    End Function


    Public Sub OpenModuleDialog(ByVal ofd As System.Windows.Forms.OpenFileDialog)


        ofd.Filter = "ADRIFT Module Files (*.amf)|*.amf|All Files (*.*)|*.*"
        ofd.DefaultExt = "amf"
        If ofd.FileName.Length > 3 AndAlso Not ofd.FileName.ToLower.EndsWith("amf") Then ofd.FileName = ""
        If ofd.ShowDialog() = DialogResult.OK AndAlso ofd.FileName <> "" Then
            If IO.File.Exists(ofd.FileName) Then
                OpenModule(ofd.FileName)
            Else
                ErrMsg("File not found!")
            End If
        End If

    End Sub


    Public Sub OpenTrizbortDialog(ByVal ofd As System.Windows.Forms.OpenFileDialog)


        ofd.Filter = "Trizbort Map Files (*.trizbort)|*.trizbort|All Files (*.*)|*.*"
        ofd.DefaultExt = "trizbort"
        If ofd.FileName.Length > 3 AndAlso Not ofd.FileName.ToLower.EndsWith("trizbort") Then ofd.FileName = ""
        If ofd.ShowDialog() = DialogResult.OK AndAlso ofd.FileName <> "" Then
            If IO.File.Exists(ofd.FileName) Then
                ImportTrizbort(ofd.FileName)
            Else
                ErrMsg("File not found!")
            End If
        End If

    End Sub


    Private Function PassSingleRestriction(ByVal rest As clsRestriction, ByVal dictReferences As Dictionary(Of String, clsItem)) As Boolean

        Select Case rest.eType
            Case clsRestriction.RestrictionTypeEnum.Object
                For Each ref As String In dictReferences.Keys
                    If ref = rest.sKey1 Then
                        Dim ob As clsObject = CType(dictReferences(ref), clsObject)
                        Select Case rest.eObject
                            Case clsRestriction.ObjectEnum.HaveProperty
                                If rest.eMust = clsRestriction.MustEnum.Must Then
                                    If Not ob.HasProperty(rest.sKey2) Then Return False
                                Else
                                    If ob.HasProperty(rest.sKey2) Then Return False
                                End If
                            Case clsRestriction.ObjectEnum.BeHeldByCharacter
                                ' Must be dynamic - may not actually be specified
                                If rest.eMust = clsRestriction.MustEnum.Must Then
                                    If ob.IsStatic Then Return False
                                End If
                            Case clsRestriction.ObjectEnum.BeWornByCharacter
                                ' Must be wearable
                                If rest.eMust = clsRestriction.MustEnum.Must Then
                                    If Not ob.IsWearable Then Return False
                                End If
                        End Select
                    End If
                Next
            Case clsRestriction.RestrictionTypeEnum.Property
                For Each ref As String In dictReferences.Keys
                    If ref = rest.sKey2 Then
                        Dim ob As clsObject = CType(dictReferences(ref), clsObject)
                        If rest.eMust = clsRestriction.MustEnum.Must Then
                            If Not ob.HasProperty(rest.sKey1) Then Return False
                            If ob.GetPropertyValue(rest.sKey1) <> rest.StringValue Then Return False
                        End If
                    End If
                Next
            Case clsRestriction.RestrictionTypeEnum.Character
                If rest.eMust = clsRestriction.MustEnum.Must Then
                    Dim ob As clsObject = Nothing
                    Adventure.htblObjects.TryGetValue(rest.sKey2, ob)
                    If ob IsNot Nothing Then
                        Select Case rest.eCharacter
                            Case clsRestriction.CharacterEnum.BeHoldingObject
                                If ob.IsStatic Then Return False
                            Case clsRestriction.CharacterEnum.BeInsideObject
                                If Not ob.IsContainer Then Return False
                            Case clsRestriction.CharacterEnum.BeLyingOnObject
                                If Not ob.HasProperty("Lieable") Then Return False
                            Case clsRestriction.CharacterEnum.BeOnObject
                                If Not ob.HasSurface Then Return False
                            Case clsRestriction.CharacterEnum.BeSittingOnObject
                                If Not ob.HasProperty("Sittable") Then Return False
                            Case clsRestriction.CharacterEnum.BeStandingOnObject
                                If Not ob.HasProperty("Standable") Then Return False
                            Case clsRestriction.CharacterEnum.BeWearingObject
                                If Not ob.IsWearable Then Return False
                        End Select
                    End If
                End If
        End Select

        Return True

    End Function


    Public Function PassRestrictions(ByVal arlRestrictions As RestrictionArrayList, ByVal dictReferences As Dictionary(Of String, clsItem), Optional tas As clsTask = Nothing) As Boolean

        iRestNum = 0

        If tas IsNot Nothing AndAlso tas.Parent <> "" Then
            Dim tasParent As clsTask = Adventure.htblTasks(tas.Parent)
            If Not PassRestrictions(tasParent.arlRestrictions, dictReferences, tasParent) Then Return False
            iRestNum = 0
        End If

        If arlRestrictions.Count = 0 Then
            Return True
        Else           
            Return EvaluateRestrictionBlock(arlRestrictions, dictReferences, arlRestrictions.BracketSequence.Replace("[", "((").Replace("]", "))"), tas)
        End If

    End Function


    ' Returns whether a task could pass with a particular set of restrictions    
    Private iRestNum As Integer = 0
    Public Function EvaluateRestrictionBlock(ByVal arlRestrictions As RestrictionArrayList, ByVal dictReferences As Dictionary(Of String, clsItem), ByVal sBlock As String, Optional tas As clsTask = Nothing) As Boolean

        While sBlock.Contains("A#O")
            Dim i As Integer = sBlock.IndexOf("A#O")
            Dim j As Integer = sBlock.Substring(0, i).LastIndexOf("(") + 1
            sBlock = sLeft(sBlock, j) & "(" & sBlock.Substring(j, i - j) & "A#)O" & sBlock.Substring(i + 3)
        End While

        Select Case Left(sBlock, 1)
            Case "("
                ' Get block
                Dim iBrackDepth As Integer = 1
                Dim sSubBlock As String = "("
                Dim iOffset As Integer = 1
                While iBrackDepth > 0
                    Dim s As String = sBlock.Substring(iOffset, 1)
                    Select Case s
                        Case "("
                            iBrackDepth += 1
                        Case ")"
                            iBrackDepth -= 1
                        Case Else
                            ' Do nothing
                    End Select
                    sSubBlock &= s
                    iOffset += 1
                End While
                sSubBlock = sSubBlock.Substring(1, sSubBlock.Length - 2) 'Left(sSubBlock, sSubBlock.Length - 1)
                If sBlock.Length - 2 = sSubBlock.Length Then
                    Return EvaluateRestrictionBlock(arlRestrictions, dictReferences, sSubBlock)
                Else
                    Select Case sBlock.Substring(sSubBlock.Length + 2, 1) 'sBlock.Substring(1, 1)
                        Case "A"
                            Dim bFirst As Boolean = EvaluateRestrictionBlock(arlRestrictions, dictReferences, sSubBlock)
                            If Not bFirst Then
                                iRestNum += CharacterCount(sBlock.Substring(sSubBlock.Length + 3), "#"c)
                                Return False
                            Else
                                Return EvaluateRestrictionBlock(arlRestrictions, dictReferences, sBlock.Substring(sSubBlock.Length + 3))
                            End If
                            'Return EvaluateRestrictionBlock(arlRestrictions, sSubBlock) AndAlso EvaluateRestrictionBlock(arlRestrictions, sBlock.Substring(sSubBlock.Length + 3)) 'sBlock.Substring(2))
                        Case "O"
                            Dim bFirst As Boolean = EvaluateRestrictionBlock(arlRestrictions, dictReferences, sSubBlock)
                            If bFirst Then
                                iRestNum += CharacterCount(sBlock.Substring(sSubBlock.Length + 3), "#"c)
                                Return True
                            Else
                                Return EvaluateRestrictionBlock(arlRestrictions, dictReferences, sBlock.Substring(sSubBlock.Length + 3))
                            End If
                            'Return EvaluateRestrictionBlock(arlRestrictions, sSubBlock) OrElse EvaluateRestrictionBlock(arlRestrictions, sBlock.Substring(sSubBlock.Length + 3)) 'sBlock.Substring(2))
                        Case Else
                            ' Error
                    End Select
                End If
            Case "#"
                iRestNum += 1
                If sBlock.Length = 1 Then
                    Return PassSingleRestriction(arlRestrictions(iRestNum - 1), dictReferences)
                Else
                    Select Case sBlock.Substring(1, 1)
                        Case "A"
                            Dim bFirst As Boolean = PassSingleRestriction(arlRestrictions(iRestNum - 1), dictReferences)
                            If Not bFirst Then
                                iRestNum += CharacterCount(sBlock.Substring(2), "#"c)
                                Return False
                            Else
                                Return EvaluateRestrictionBlock(arlRestrictions, dictReferences, sBlock.Substring(2))
                            End If
                            'Return PassSingleRestriction(arlRestrictions(iRestNum - 1)) AndAlso EvaluateRestrictionBlock(arlRestrictions, sBlock.Substring(2))
                        Case "O"
                            Dim bFirst As Boolean = PassSingleRestriction(arlRestrictions(iRestNum - 1), dictReferences)
                            If bFirst Then
                                iRestNum += CharacterCount(sBlock.Substring(2), "#"c)
                                Return True
                            Else
                                Return EvaluateRestrictionBlock(arlRestrictions, dictReferences, sBlock.Substring(2))
                            End If
                            'Return PassSingleRestriction(arlRestrictions(iRestNum - 1)) OrElse EvaluateRestrictionBlock(arlRestrictions, sBlock.Substring(2))
                        Case Else
                            ' Error
                    End Select
                End If
            Case Else
                ErrMsg("Bad Bracket Sequence")

        End Select

    End Function


    Public Sub ShowHelp(ByVal form As Form, Optional ByVal sTopic As String = Nothing)

        Dim sHelpURL As String = fGenerator.HelpProvider1.HelpNamespace

        If IO.File.Exists(sHelpURL) Then
            If sTopic Is Nothing Then
                Help.ShowHelp(form, sHelpURL, HelpNavigator.TableOfContents)
            Else
                Help.ShowHelp(form, sHelpURL, HelpNavigator.Topic, sTopic & ".htm")
            End If
        Else
            sHelpURL = "http://help.adrift.co"
            If sTopic Is Nothing Then
                Help.ShowHelp(form, sHelpURL, HelpNavigator.TableOfContents)
            Else
                sHelpURL &= "/" & sTopic & ".html"
                Help.ShowHelp(form, sHelpURL, HelpNavigator.Topic, sTopic)
            End If
        End If

    End Sub


    Public Sub OpenALRDialog(ByVal ofd As System.Windows.Forms.OpenFileDialog)


        ofd.Filter = "Language Resource Files (*.alr)|*.alr|All Files (*.*)|*.*"
        ofd.DefaultExt = "alr"
        If ofd.FileName.Length > 3 AndAlso Not ofd.FileName.ToLower.EndsWith("alr") Then ofd.FileName = ""
        If ofd.ShowDialog() = DialogResult.OK AndAlso ofd.FileName <> "" Then
            If IO.File.Exists(ofd.FileName) Then
                ImportALR(ofd.FileName)
            Else
                ErrMsg("File not found!")
            End If
        End If

    End Sub


    Public Function GetReferences(ByVal reftype As ReferencesType, ByVal sCommand As String, Optional ByVal Arguments As List(Of clsUserFunction.Argument) = Nothing) As StringArrayList

        If sCommand Is Nothing AndAlso Arguments Is Nothing Then Return New StringArrayList

        Dim sal As New StringArrayList
        If sCommand IsNot Nothing Then sCommand = sCommand.ToLower

        Select Case reftype
            Case ReferencesType.Location
                If sInstr(sCommand, "%location%") > 0 Then sal.Add("ReferencedLocation")
                If Arguments IsNot Nothing Then
                    For Each arg As clsUserFunction.Argument In Arguments
                        If arg.Type = clsUserFunction.ArgumentType.Location Then
                            sal.Add("Parameter-" & arg.Name)
                        End If
                    Next
                End If
            Case ReferencesType.Object
                If sInstr(sCommand, "%objects%") > 0 Then
                    sal.Add("ReferencedObjects")
                End If
                If sInstr(sCommand, "%object%") > 0 Then sal.Add("ReferencedObject1")
                For iRef As Integer = 1 To 5
                    If sInstr(sCommand, "%object" & iRef & "%") > 0 Then
                        If Not sal.Contains("ReferencedObject" & iRef) Then sal.Add("ReferencedObject" & iRef)
                    End If
                Next
                If Arguments IsNot Nothing Then
                    For Each arg As clsUserFunction.Argument In Arguments
                        If arg.Type = clsUserFunction.ArgumentType.Object Then
                            sal.Add("Parameter-" & arg.Name)
                        End If
                    Next
                End If
            Case ReferencesType.Character
                If sInstr(sCommand, "%characters%") > 0 Then
                    sal.Add("ReferencedCharacters")
                End If
                If sInstr(sCommand, "%character%") > 0 Then sal.Add("ReferencedCharacter1")
                For iRef As Integer = 1 To 5
                    If sInstr(sCommand, "%character" & iRef & "%") > 0 Then
                        If Not sal.Contains("ReferencedCharacter" & iRef) Then sal.Add("ReferencedCharacter" & iRef)
                    End If
                Next
                If Arguments IsNot Nothing Then
                    For Each arg As clsUserFunction.Argument In Arguments
                        If arg.Type = clsUserFunction.ArgumentType.Character Then
                            sal.Add("Parameter-" & arg.Name)
                        End If
                    Next
                End If
            Case ReferencesType.Item
                If sInstr(sCommand, "%item%") > 0 Then sal.Add("ReferencedItem1")
                For iRef As Integer = 1 To 5
                    If sInstr(sCommand, "%item" & iRef & "%") > 0 Then
                        If Not sal.Contains("ReferencedItem" & iRef) Then sal.Add("ReferencedItem" & iRef)
                    End If
                Next
            Case ReferencesType.Direction
                If sInstr(sCommand, "%direction%") > 0 Then sal.Add("ReferencedDirection1")
                For iRef As Integer = 1 To 5
                    If sInstr(sCommand, "%direction" & iRef & "%") > 0 Then
                        If Not sal.Contains("ReferencedDirection" & iRef) Then sal.Add("ReferencedDirection" & iRef)
                    End If
                Next
            Case ReferencesType.Number
                If sInstr(sCommand, "%number%") > 0 Then sal.Add("ReferencedNumber1")
                For iRef As Integer = 1 To 5
                    If sInstr(sCommand, "%number" & iRef & "%") > 0 Then
                        If Not sal.Contains("ReferencedNumber" & iRef) Then sal.Add("ReferencedNumber" & iRef)
                    End If
                Next
                If sInstr(sCommand, "%t_number%") > 0 AndAlso Not sal.Contains("ReferencedNumber1") Then sal.Add("ReferencedNumber1")
                For iRef As Integer = 1 To 5
                    If sInstr(sCommand, "%t_number" & iRef & "%") > 0 Then
                        If Not sal.Contains("ReferencedNumber" & iRef) Then sal.Add("ReferencedNumber" & iRef)
                    End If
                Next
                If Arguments IsNot Nothing Then
                    For Each arg As clsUserFunction.Argument In Arguments
                        If arg.Type = clsUserFunction.ArgumentType.Number Then
                            sal.Add("Parameter-" & arg.Name)
                        End If
                    Next
                End If
            Case ReferencesType.Text
                If sInstr(sCommand, "%text%") > 0 Then sal.Add("ReferencedText1")
                For iRef As Integer = 1 To 5
                    If sInstr(sCommand, "%text" & iRef & "%") > 0 Then
                        If Not sal.Contains("ReferencedText" & iRef) Then sal.Add("ReferencedText" & iRef)
                    End If
                Next
                If Arguments IsNot Nothing Then
                    For Each arg As clsUserFunction.Argument In Arguments
                        If arg.Type = clsUserFunction.ArgumentType.Text Then
                            sal.Add("Parameter-" & arg.Name)
                        End If
                    Next
                End If
        End Select

        If sal.Contains("ReferencedObject1") AndAlso Not sal.Contains("ReferencedObject2") Then sal(sal.IndexOf("ReferencedObject1")) = "ReferencedObject"
        If sal.Contains("ReferencedCharacter1") AndAlso Not sal.Contains("ReferencedCharacter2") Then sal(sal.IndexOf("ReferencedCharacter1")) = "ReferencedCharacter"
        If sal.Contains("ReferencedDirection1") AndAlso Not sal.Contains("ReferencedDirection2") Then sal(sal.IndexOf("ReferencedDirection1")) = "ReferencedDirection"
        If sal.Contains("ReferencedNumber1") AndAlso Not sal.Contains("ReferencedNumber2") Then sal(sal.IndexOf("ReferencedNumber1")) = "ReferencedNumber"
        If sal.Contains("ReferencedText1") AndAlso Not sal.Contains("ReferencedText2") Then sal(sal.IndexOf("ReferencedText1")) = "ReferencedText"
        If sal.Contains("ReferencedLocation1") AndAlso Not sal.Contains("ReferencedLocation2") Then sal(sal.IndexOf("ReferencedLocation1")) = "ReferencedLocation"
        If sal.Contains("ReferencedItem1") AndAlso Not sal.Contains("ReferencedItem2") Then sal(sal.IndexOf("ReferencedItem1")) = "ReferencedItem"

        Return sal

    End Function

    Private Function CountInstr(ByVal sText As String, ByVal sFind As String) As Integer

        Dim iOffset As Integer
        CountInstr = 0

        While sText.IndexOf(sFind, iOffset) > -1
            CountInstr += 1
            iOffset = sText.IndexOf(sFind, iOffset) + 1
        End While

    End Function


    Public Sub LoadDefaults()
        CreatePlayer()
        CreateRequiredProperties()
    End Sub


    Private Sub CreatePlayer()
        Dim Player As New clsCharacter
        With Player
            .ProperName = "Player"
            .CharacterType = clsCharacter.CharacterTypeEnum.Player
            .Key = "Player"
        End With
        Adventure.htblCharacters.Add(Player, Player.Key)
    End Sub

    Private Sub CreateRequiredProperties()

        Dim pStaticDynamic As New clsProperty
        With pStaticDynamic
            .Key = "StaticOrDynamic"
            .Description = "Object type"
            .Type = clsProperty.PropertyTypeEnum.StateList
            .arlStates.Add("Static")
            .arlStates.Add("Dynamic")
            .Mandatory = True
        End With
        Adventure.htblAllProperties.Add(pStaticDynamic)

        Dim pSurface As New clsProperty
        With pSurface
            .Key = "Surface"
            .Description = "This object has a surface"
            .Type = clsProperty.PropertyTypeEnum.SelectionOnly
        End With
        Adventure.htblAllProperties.Add(pSurface)

        Dim pSurfaceHold As New clsProperty
        With pSurfaceHold
            .Key = "SurfaceHold"
            .Description = "... and the surface can hold"
            .Type = clsProperty.PropertyTypeEnum.Integer
            .DependentKey = "Surface"
        End With
        Adventure.htblAllProperties.Add(pSurfaceHold)

        Dim pReadable As New clsProperty
        With pReadable
            .Key = "Readable"
            .Description = "This object is readable"
            .Type = clsProperty.PropertyTypeEnum.SelectionOnly
        End With
        Adventure.htblAllProperties.Add(pReadable)

        Dim pReadText As New clsProperty
        With pReadText
            .Key = "ReadText"
            .Description = "... and description when read"
            .Type = clsProperty.PropertyTypeEnum.Text
            .DependentKey = "Readable"
        End With
        Adventure.htblAllProperties.Add(pReadText)

        Dim pWearable As New clsProperty
        With pWearable
            .Key = "Wearable"
            .Description = "Wearable"
            .Type = clsProperty.PropertyTypeEnum.SelectionOnly
            .DependentKey = "StaticOrDynamic"
            .DependentValue = "Dynamic"
        End With
        Adventure.htblAllProperties.Add(pWearable)

        Dim pContainer As New clsProperty
        With pContainer
            .Key = "Container"
            .Description = "This object is a container"
            .Type = clsProperty.PropertyTypeEnum.SelectionOnly
        End With
        Adventure.htblAllProperties.Add(pContainer)

        Dim pContainerHold As New clsProperty
        With pContainerHold
            .Key = "ContainerHold"
            .Description = "... and the container can hold"
            .Type = clsProperty.PropertyTypeEnum.Integer
            .DependentKey = "Container"
        End With
        Adventure.htblAllProperties.Add(pContainerHold)

        Dim pOpenable As New clsProperty
        With pOpenable
            .Key = "Openable"
            .Description = "Object can be opened and closed, starting off"
            .Type = clsProperty.PropertyTypeEnum.StateList
            .arlStates.Add("Open")
            .arlStates.Add("Closed")
        End With
        Adventure.htblAllProperties.Add(pOpenable)

        Dim pLockable As New clsProperty
        With pLockable
            .Key = "Lockable"
            .Description = "... and is lockable, with key"
            .Type = clsProperty.PropertyTypeEnum.ObjectKey
            .DependentKey = "Openable"
        End With
        Adventure.htblAllProperties.Add(pLockable)

        Dim pLocked As New clsProperty
        With pLocked
            .Key = "Locked"
            .Description = "... and starts off locked"
            .Type = clsProperty.PropertyTypeEnum.SelectionOnly
            .DependentKey = "Lockable"
        End With
        Adventure.htblAllProperties.Add(pLocked)

        Dim pSittable As New clsProperty
        With pSittable
            .Key = "Sittable"
            .Description = "Characters can sit on this object"
            .Type = clsProperty.PropertyTypeEnum.SelectionOnly
        End With
        Adventure.htblAllProperties.Add(pSittable)

        Dim pStandable As New clsProperty
        With pStandable
            .Key = "Standable"
            .Description = "Characters can stand on this object"
            .Type = clsProperty.PropertyTypeEnum.SelectionOnly
        End With
        Adventure.htblAllProperties.Add(pStandable)

        Dim pLieable As New clsProperty
        With pLieable
            .Key = "Lieable"
            .Description = "Characters can lie on this object"
            .Type = clsProperty.PropertyTypeEnum.SelectionOnly
        End With
        Adventure.htblAllProperties.Add(pLieable)

        Dim pEdible As New clsProperty
        With pEdible
            .Key = "Edible"
            .Description = "Object is edible"
            .Type = clsProperty.PropertyTypeEnum.SelectionOnly
            .DependentKey = "StaticOrDynamic"
            .DependentValue = "Dynamic"
        End With
        Adventure.htblAllProperties.Add(pEdible)

        Dim pDynamicLocation As New clsProperty
        With pDynamicLocation
            .Key = "DynamicLocation"
            .Description = "Location of the object"
            .Mandatory = True
            .Type = clsProperty.PropertyTypeEnum.StateList
            .arlStates.Add("Hidden")
            .arlStates.Add("Held By Character")
            .arlStates.Add("Worn By Character")
            .arlStates.Add("In Location")
            .arlStates.Add("Inside Object")
            .arlStates.Add("On Object")
            .DependentKey = "StaticOrDynamic"
            .DependentValue = "Dynamic"
        End With
        Adventure.htblAllProperties.Add(pDynamicLocation)

        Dim pHeldByWho As New clsProperty
        With pHeldByWho
            .Key = "HeldByWho"
            .Description = "Held by who"
            .Mandatory = True
            .Type = clsProperty.PropertyTypeEnum.CharacterKey
            .DependentKey = "DynamicLocation"
            .DependentValue = "Held By Character"
        End With
        Adventure.htblAllProperties.Add(pHeldByWho)

        Dim pInLocation As New clsProperty
        With pInLocation
            .Key = "InLocation"
            .Description = "In location"
            .Mandatory = True
            .Type = clsProperty.PropertyTypeEnum.LocationKey
            .DependentKey = "DynamicLocation"
            .DependentValue = "In Location"
        End With
        Adventure.htblAllProperties.Add(pInLocation)

        Dim pStaticLocation As New clsProperty
        With pStaticLocation
            .Key = "StaticLocation"
            .Description = "Location of the object"
            .Mandatory = True
            .Type = clsProperty.PropertyTypeEnum.StateList
            .arlStates.Add("Nowhere")
            .arlStates.Add("Single Location")
            .arlStates.Add("Multiple Locations")
            .arlStates.Add("All Locations")
            .arlStates.Add("Part Of Character")
            .arlStates.Add("Part Of Object")
            .DependentKey = "StaticOrDynamic"
            .DependentValue = "Static"
        End With
        Adventure.htblAllProperties.Add(pStaticLocation)

    End Sub


    'Public Function GetFunctionArgs(ByVal sText As String) As String

    '    If sInstr(sText, "[") = 0 OrElse sInstr(sText, "]") = 0 Then Return ""

    '    ' Work out this bracket chunk, then run ReplaceFunctions on it
    '    Dim iOffset As Integer = 1
    '    Dim iLevel As Integer = 1

    '    While iLevel > 0
    '        Select Case sText.Substring(iOffset, 1)
    '            Case "["
    '                iLevel += 1
    '            Case "]"
    '                iLevel -= 1
    '            Case Else
    '                ' Ignore
    '        End Select
    '        iOffset += 1
    '    End While

    '    Return sText.Substring(1, iOffset - 2)

    'End Function


    'Public Function ReplaceFunctions(ByVal sText As String) As String

    '    If sInstr(sText, "%") = 0 Then Return sText

    '    'sText = sText.Replace("%player%", Player.Key)
    '    sText = sText.Replace("%object%", "%object1%")


    '    For Each sFunction As String In FunctionNames()
    '        While sInstr(sText, "%" & sFunction & "[") > 0
    '            Dim sArgs As String = GetFunctionArgs(sText.Substring(InStr(sText, "%" & sFunction & "[") + sFunction.Length))
    '            Dim iArgsLength As Integer = sArgs.Length
    '            If iArgsLength > 0 Then
    '                sArgs = ReplaceFunctions(sArgs)
    '                If sInstr(sText, "%" & sFunction & "[" & sArgs & "]%") > 0 Then

    '                    Dim sResult As String = ""
    '                    Dim htblObjects As New ObjectHashTable

    '                    Select Case sArgs
    '                        Case "%objects%"

    '                        Case Else
    '                            If Adventure.htblObjects.ContainsKey(sArgs) Then htblObjects.Add(Adventure.htblObjects(sArgs), sArgs)
    '                    End Select

    '                    Select Case sFunction
    '                        Case "DisplayObject"
    '                            sResult = htblObjects(sArgs).Description
    '                        Case "TheObject", "TheObjects"
    '                            sResult = htblObjects.List
    '                        Case "DisplayLocation"
    '                            sResult = Adventure.htblLocations(sArgs).ViewLocation
    '                        Case "LocationOf"
    '                            sResult = Adventure.htblCharacters(sArgs).Location
    '                        Case "LCase"
    '                            sResult = sArgs.ToLower
    '                        Case "ListHeld"
    '                            'sResult = Adventure.htblCharacters(sArgs).HeldObjects.List("and", True, False)
    '                        Case "ListExits"
    '                            'sResult = Adventure.htblCharacters(sArgs).ListExits
    '                        Case "ListObjectsInLocation"
    '                            sResult = Adventure.htblLocations(sArgs).ObjectsInLocation.List("and", False, False)
    '                    End Select

    '                    If sResult = "" Then
    '                        sResult = "<c>*** Bad Function ***</c>"
    '                    End If

    '                    sText = Replace(sText, "%" & sFunction & "[" & sArgs & "]%", sResult)

    '                Else
    '                    sText = Replace(sText, "%" & sFunction & "[", "*** HERE ***")
    '                End If
    '            Else
    '                sText = Replace(sText, "%" & sFunction & "[]%", "")
    '                sText = Replace(sText, "%" & sFunction & "[", "")
    '            End If
    '        End While
    '    Next

    '    Return sText

    'End Function

End Module

