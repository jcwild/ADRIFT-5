Public Class frmDebugger

    Private sText As New System.Text.StringBuilder
    Private imgList As New ImageList
    Private DisabledColour As Color = SystemColors.InactiveCaptionText


    Friend ReadOnly Property HasText As Boolean
        Get
            Return sText.ToString.Length > 0
        End Get
    End Property


    Private Sub frmDebugger_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
#If Mono Then
#Else
        CType(fRunner.UTMMain.Tools("Debugger"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = False
#End If
        SaveFormPosition(Me)
        SaveSetting("ADRIFT", "Runner", "ShowTimes", CInt(chkShowTimes.Checked).ToString)
        For Each opt As RadioButton In New RadioButton() {optLow, optMedium, optHigh}
            If opt.Checked Then SaveSetting("ADRIFT", "Runner", "DetailLevel", opt.Tag.ToString)
        Next
        'If optDetail.CheckedItem IsNot Nothing Then SaveSetting("ADRIFT", "Runner", "DetailLevel", optDetail.CheckedItem.DataValue.ToString)
        SaveSetting("ADRIFT", "Runner", "DebugSplit", Me.SplitContainer1.SplitterDistance.ToString)
    End Sub


    Private Sub frmDebugger_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetFormPosition(Me, Nothing, Nothing, True)
        chkShowTimes.Checked = SafeBool(GetSetting("ADRIFT", "Runner", "ShowTimes", "0"))
        For Each opt As RadioButton In New RadioButton() {optLow, optMedium, optHigh}
            If CInt(GetSetting("ADRIFT", "Runner", "DetailLevel", "1")) = CInt(opt.Tag) Then opt.Checked = True
        Next
        'SetOptSet(optDetail, Math.Min(CInt(GetSetting("ADRIFT", "Runner", "DetailLevel", "1")), 2))
        SplitContainer1.SplitterDistance = CInt(GetSetting("ADRIFT", "Runner", "DebugSplit", "200"))
        SplitContainer2.Panel2Collapsed = True
        With imgList.Images
            .Add("", New Bitmap(1, 1))
            .Add("imgLocation16", My.Resources.imgLocation16)
            .Add("imgObjectStatic16", My.Resources.imgObjectStatic16)
            .Add("imgObjectDynamic16", My.Resources.imgObjectDynamic16)
            .Add("imgTaskGeneral16", My.Resources.imgTaskGeneral16)
            .Add("imgTaskSpecific16", My.Resources.imgTaskSpecific16)
            .Add("imgTaskSystem16", My.Resources.imgTaskSystem16)
            .Add("imgEvent16", My.Resources.imgEvent16)
            .Add("imgCharacter16", My.Resources.imgCharacter16)
            .Add("imgVariable16", My.Resources.imgVariable16)
        End With
        treeItemBrowser.ImageList = imgList
        treeItemBrowser.TreeViewNodeSorter = New NodeSorter
        BuildTree()
    End Sub


    Private Class NodeSorter
        Implements IComparer

        Public Function Compare(x As Object, y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim tx As TreeNode = CType(x, TreeNode)
            Dim ty As TreeNode = CType(y, TreeNode)

            If tx.Parent IsNot Nothing Then Return tx.Text.CompareTo(ty.Text)
        End Function
    End Class


    Public Sub BuildTree()

        If Adventure Is Nothing Then Exit Sub
        Dim n As TreeNode

        treeItemBrowser.CheckBoxes = True
        treeItemBrowser.Nodes.Clear()
        n = treeItemBrowser.Nodes.Add("Locations", "Locations")
        n.ImageKey = "imgLocation16"
        n.SelectedImageKey = n.ImageKey
        n = treeItemBrowser.Nodes.Add("Objects", "Objects")
        n.ImageKey = "imgObjectStatic16"
        n.SelectedImageKey = n.ImageKey
        n = treeItemBrowser.Nodes.Add("Tasks", "Tasks")
        n.ImageKey = "imgTaskGeneral16"
        n.SelectedImageKey = n.ImageKey
        n = treeItemBrowser.Nodes.Add("Events", "Events")
        n.ImageKey = "imgEvent16"
        n.SelectedImageKey = n.ImageKey
        n = treeItemBrowser.Nodes.Add("Characters", "Characters")
        n.ImageKey = "imgCharacter16"
        n.SelectedImageKey = n.ImageKey
        n = treeItemBrowser.Nodes.Add("Variables", "Variables")
        n.ImageKey = "imgVariable16"
        n.SelectedImageKey = n.ImageKey

        For Each l As clsLocation In Adventure.htblLocations.Values
            'Dim n As Infragistics.Win.UltraWinTree.UltraTreeNode = treeItemBrowser.Nodes("Locations").Nodes.Add(l.Key, l.ShortDescription.ToString)
            n = treeItemBrowser.Nodes("Locations").Nodes.Add(l.Key, l.ShortDescription.ToString)
            'n.LeftImages.Add(My.Resources.imgLocation16)
            n.ImageKey = "imgLocation16"
            n.SelectedImageKey = n.ImageKey
        Next
        'treeItemBrowser.Nodes("Locations").Nodes.Override.Sort = Infragistics.Win.UltraWinTree.SortType.Ascending
        ' TODO
        'treeItemBrowser.Nodes("Locations").CheckedState = CheckState.Checked
        treeItemBrowser.Nodes("Locations").Checked = True

        For Each o As clsObject In Adventure.htblObjects.Values
            'Dim n As Infragistics.Win.UltraWinTree.UltraTreeNode = treeItemBrowser.Nodes("Objects").Nodes.Add(o.Key, o.FullName)
            n = treeItemBrowser.Nodes("Objects").Nodes.Add(o.Key, o.FullName)
            If o.IsStatic Then
                'n.LeftImages.Add(My.Resources.imgObjectStatic16)
                n.ImageKey = "imgObjectStatic16"
            Else
                'n.LeftImages.Add(My.Resources.imgObjectDynamic16)
                n.ImageKey = "imgObjectDynamic16"
            End If
            n.SelectedImageKey = n.ImageKey
        Next
        'treeItemBrowser.Nodes("Objects").Nodes.Override.Sort = Infragistics.Win.UltraWinTree.SortType.Ascending
        ' TODO
        'treeItemBrowser.Nodes("Objects").CheckedState = CheckState.Checked
        treeItemBrowser.Nodes("Objects").Checked = True

        For Each t As clsTask In Adventure.htblTasks.Values
            If t.TaskType <> clsTask.TaskTypeEnum.Specific Then
                n = treeItemBrowser.Nodes("Tasks").Nodes.Add(t.Key, t.Description)
                Select Case t.TaskType
                    Case clsTask.TaskTypeEnum.General
                        n.ImageKey = "imgTaskGeneral16"
                    Case clsTask.TaskTypeEnum.System
                        n.ImageKey = "imgTaskSystem16"
                End Select
                n.SelectedImageKey = n.ImageKey
            End If
        Next
        For Each t As clsTask In Adventure.htblTasks.Values
            If t.TaskType = clsTask.TaskTypeEnum.Specific Then
                Dim nParent() As TreeNode = treeItemBrowser.Nodes.Find(t.Parent, True)
                If nParent.Length = 1 Then
                    n = nParent(0).Nodes.Add(t.Key, t.Description)
                    n.ImageKey = "imgTaskSpecific16"
                    n.SelectedImageKey = n.ImageKey
                End If
            End If
        Next

        'treeItemBrowser.Nodes("Tasks").Nodes.Override.Sort = Infragistics.Win.UltraWinTree.SortType.Ascending
        ' TODO
        'treeItemBrowser.Nodes("Tasks").CheckedState = CheckState.Checked
        treeItemBrowser.Nodes("Tasks").Checked = True

        For Each e As clsEvent In Adventure.htblEvents.Values
            'Dim n As Infragistics.Win.UltraWinTree.UltraTreeNode = treeItemBrowser.Nodes("Events").Nodes.Add(e.Key, e.Description)
            n = treeItemBrowser.Nodes("Events").Nodes.Add(e.Key, e.Description)
            'n.LeftImages.Add(My.Resources.imgEvent16)
            If e.EventType = clsEvent.EventTypeEnum.TurnBased Then
                n.ImageKey = "imgEvent16"
            Else
                n.ImageKey = "imgTimeEvent16"
            End If
            n.SelectedImageKey = n.ImageKey
        Next
        'treeItemBrowser.Nodes("Events").Nodes.Override.Sort = Infragistics.Win.UltraWinTree.SortType.Ascending
        ' TODO
        'treeItemBrowser.Nodes("Events").CheckedState = CheckState.Checked
        treeItemBrowser.Nodes("Events").Checked = True

        For Each c As clsCharacter In Adventure.htblCharacters.Values
            'Dim n As Infragistics.Win.UltraWinTree.UltraTreeNode = treeItemBrowser.Nodes("Characters").Nodes.Add(c.Key, c.Name)
            n = treeItemBrowser.Nodes("Characters").Nodes.Add(c.Key, c.Name)
            'n.LeftImages.Add(My.Resources.imgCharacter16)
            n.ImageKey = "imgCharacter16"
            n.SelectedImageKey = n.ImageKey
        Next
        'treeItemBrowser.Nodes("Characters").Nodes.Override.Sort = Infragistics.Win.UltraWinTree.SortType.Ascending
        ' TODO
        'treeItemBrowser.Nodes("Characters").CheckedState = CheckState.Checked
        treeItemBrowser.Nodes("Characters").Checked = True

        For Each v As clsVariable In Adventure.htblVariables.Values
            'Dim n As Infragistics.Win.UltraWinTree.UltraTreeNode = treeItemBrowser.Nodes("Variables").Nodes.Add(v.Key, v.Name)
            n = treeItemBrowser.Nodes("Variables").Nodes.Add(v.Key, v.Name)
            'n.LeftImages.Add(My.Resources.imgVariable16)
            n.ImageKey = "imgVariable16"
            n.SelectedImageKey = n.ImageKey
        Next
        'treeItemBrowser.Nodes("Variables").Nodes.Override.Sort = Infragistics.Win.UltraWinTree.SortType.Ascending
        ' TODO
        'treeItemBrowser.Nodes("Variables").CheckedState = CheckState.Checked
        treeItemBrowser.Nodes("Variables").Checked = True

    End Sub


    Private Sub treeItemBrowser_AfterCheck(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles treeItemBrowser.AfterCheck

        If e.Node.GetNodeCount(False) > 0 Then ' e.TreeNode.HasNodes Then
            For Each n As TreeNode In e.Node.Nodes ' e.TreeNode.Nodes
                n.Checked = e.Node.Checked ' e.TreeNode.CheckedState
            Next
        End If

    End Sub
    

    Friend Sub Print(ByVal eItemType As ItemEnum, ByVal sKey As String, ByVal eDetailLevel As DebugDetailLevelEnum, ByVal sMessage As String, ByVal bNewLine As Boolean)

        'Dim bEndOfTurn As Boolean = False
        Static bLastHadNewLine As Boolean = True

        'If bNewLine Then
        '    Debug.WriteLine(sMessage)
        'Else
        '    Debug.Write(sMessage)
        'End If
        sMessage = sMessage.Replace(">", "&gt;").Replace("<", "&lt;")

        'If optDetail.CheckedItem Is Nothing Then Exit Sub
        If sMessage <> "ENDOFTURN" Then
            If eDetailLevel = DebugDetailLevelEnum.Error OrElse eDetailLevel = DebugDetailLevelEnum.Low OrElse (eDetailLevel = DebugDetailLevelEnum.Medium AndAlso (optMedium.Checked OrElse optHigh.Checked)) OrElse (eDetailLevel = DebugDetailLevelEnum.High AndAlso optHigh.Checked) Then
                Dim Nodes As TreeNode() = treeItemBrowser.Nodes.Find(sKey, True) '   treeItemBrowser.GetNodeByKey(sKey)
                If (sKey = "" AndAlso treeItemBrowser.Nodes.ContainsKey("Tasks") AndAlso treeItemBrowser.Nodes("Tasks").Checked) OrElse Nodes.Length = 1 Then
                    Dim Node As TreeNode = Nothing
                    If Nodes.Length = 1 Then Node = Nodes(0)
                    If sKey = "" OrElse (Node IsNot Nothing AndAlso Node.Checked) Then
                        Select Case eDetailLevel
                            Case DebugDetailLevelEnum.Error
                                sMessage = "<c><b>ERROR: " & sMessage & "</b></c>"
                            Case DebugDetailLevelEnum.High
                                sMessage = "<i>" & sMessage & "</i>"
                            Case DebugDetailLevelEnum.Medium
                                ' Leave
                            Case DebugDetailLevelEnum.Low
                                sMessage = "<b>" & sMessage & "</b>"
                        End Select
                        If Me.chkShowTimes.Checked AndAlso bLastHadNewLine Then sMessage = "[" & Mid(Now.Subtract(UserSession.dtDebug).ToString, 7, 5) & "]  " & Space(Math.Max(UserSession.iDebugIndent, 0) * 4) & sMessage
                        'sMessage = "<font face=""courier new"">" & sMessage & "</font>"
                        Select Case eItemType
                            Case ItemEnum.Task
                                sMessage = "<font size=10 color=#005500>" & sMessage & "</font>"
                            Case ItemEnum.Event
                                sMessage = "<font size=10 color=#000055>" & sMessage & "</font>"
                            Case ItemEnum.Character
                                sMessage = "<font size=10 color=#550000>" & sMessage & "</font>"
                            Case Else
                                sMessage = "<font size=10 color=#000000>" & sMessage & "</font>"
                        End Select
                        If bNewLine Then sMessage &= "<br>"
                        'If sMessage.Contains("ENDOFTURN") Then
                        '    sMessage = "<center><font color=#BBBBBB size=-2>...............................................</font><br></center>"
                        '    bEndOfTurn = True
                        'End If

                        'Source2HTML(sMessage, Me.rtxtDebug, False)
                        'Me.rtxtDebug.AppendText(sMessage)
                        sText.Append(sMessage)
                    End If
                End If
            End If
        Else
            sText.Append("<center><font color=#BBBBBB size=-2>...............................................</font><br></center>")
            Source2HTML(sText.ToString, rtxtDebug, False, True)
            sText = New System.Text.StringBuilder
            RefreshValues()
        End If

        'If bEndOfTurn Then
        '    'rtxtDebug.AppendText(sText.ToString)
        '    Source2HTML(sText.ToString, rtxtDebug, False)
        '    sText = New System.Text.StringBuilder
        'End If

        bLastHadNewLine = bNewLine

        'If treeItemBrowser.SelectedNode IsNot Nothing Then '     .SelectedNode.Count = 1 Then
        '    Dim nod As TreeNode = treeItemBrowser.SelectedNode '  .SelectedNodes(0)
        '    nod.Selected = False
        '    nod.Selected = True
        'End If

    End Sub


    Public Sub RefreshValues()
        If treeItemBrowser.SelectedNode IsNot Nothing Then RefreshFromKey(treeItemBrowser.SelectedNode.Name)
    End Sub


    Private Enum ColumnType
        Combo
        Text
        Number
    End Enum

    Private Sub AddProperty(ByVal p As clsProperty)

        Select Case p.Type
            Case clsProperty.PropertyTypeEnum.CharacterKey
                Dim dictCharacters As New List(Of KeyValue)
                For Each c As clsCharacter In Adventure.htblCharacters.Values
                    'listCharacters.Add(c.Key) 'c.Name & "~" & c.Key)
                    dictCharacters.Add(New KeyValue(c.Key, c.Name))
                Next
                AddProperty(p.Key, p.Description, p.Value, ColumnType.Combo, dictCharacters)
            Case clsProperty.PropertyTypeEnum.Integer
                AddProperty(p.Key, p.Description, p.Value, ColumnType.Number)
            Case clsProperty.PropertyTypeEnum.LocationGroupKey
                Dim dictKeys As New List(Of KeyValue)
                For Each g As clsGroup In Adventure.htblGroups.Values
                    If g.GroupType = clsGroup.GroupTypeEnum.Locations Then dictKeys.Add(New KeyValue(g.Key, g.Name))
                Next
                AddProperty(p.Key, p.Description, p.Value, ColumnType.Combo, dictKeys)
            Case clsProperty.PropertyTypeEnum.LocationKey
                Dim dictLocations As New List(Of KeyValue)
                For Each l As clsLocation In Adventure.htblLocations.Values
                    dictLocations.Add(New KeyValue(l.Key, l.ShortDescription.ToString)) 'c.Name & "~" & c.Key)
                Next
                AddProperty(p.Key, p.Description, p.Value, ColumnType.Combo, dictLocations)
            Case clsProperty.PropertyTypeEnum.ObjectKey
                Dim dictObjects As New List(Of KeyValue)
                For Each o As clsObject In Adventure.htblObjects.Values
                    dictObjects.Add(New KeyValue(o.Key, o.FullName)) 'c.Name & "~" & c.Key)
                Next
                AddProperty(p.Key, p.Description, p.Value, ColumnType.Combo, dictObjects)
            Case clsProperty.PropertyTypeEnum.StateList
                Dim dictStates As New List(Of KeyValue)
                For Each s As String In p.arlStates
                    dictStates.Add(New KeyValue(s))
                Next
                AddProperty(p.Key, p.Description, p.Value, ColumnType.Combo, dictStates)
            Case clsProperty.PropertyTypeEnum.Text
                AddProperty(p.Key, p.Description, p.Value, ColumnType.Text)
            Case clsProperty.PropertyTypeEnum.ValueList
                AddProperty(p.Key, p.Description, p.Value, ColumnType.Combo)
        End Select
        If p.FromGroup Then
            With grdProperties.Rows(grdProperties.Rows.Count - 1)
                'grdProperties.Rows(grdProperties.Rows.Count - 1).Cells(1).Style.ForeColor = DisabledColour
                .Cells(1).Style.ForeColor = DisabledColour
                .Cells(1).ReadOnly = True
                'If .Cells(3) IsNot Nothing Then
                '    CType(.Cells(1), DataGridViewComboBoxCell).
                'End If
            End With


        End If

    End Sub


    <SmartAssembly.Attributes.DoNotObfuscateType, SmartAssembly.Attributes.DoNotObfuscate, SmartAssembly.Attributes.DoNotPrune, SmartAssembly.Attributes.DoNotPruneType> _
    Private Class KeyValue

        Public Property Value As Object
        Public Property Display As String

        Public Sub New(ByVal Value As Object, Optional ByVal Display As String = "")
            If Display = "" Then Display = Value.ToString
            Me.Display = Display
            Me.Value = Value
        End Sub

    End Class


    
    Private Sub AddProperty(ByVal sPropertyKey As String, ByVal sPropertyName As String, ByVal PropertyValue As Object, Optional ByVal ePropertyType As ColumnType = ColumnType.Text, Optional ByVal dictValidValues As List(Of KeyValue) = Nothing)

        If TypeOf PropertyValue Is Boolean Then
            'listValidValues = New List(Of String)
            dictValidValues = New List(Of KeyValue)
            dictValidValues.Add(New KeyValue(True))
            dictValidValues.Add(New KeyValue(False))
            'listValidValues.Add(True.ToString)
            'listValidValues.Add(False.ToString)
            ePropertyType = ColumnType.Combo
        End If

        'Dim sValidValues As String = ""
        'If listValidValues IsNot Nothing Then
        '    For Each sValue As String In listValidValues
        '        sValidValues &= sValue & "|"
        '    Next
        '    If sValidValues.EndsWith("|") Then sValidValues = sValidValues.Substring(0, sValidValues.Length - 1)
        'End If

        Dim iIndex As Integer = grdProperties.Rows.Add(sPropertyName, PropertyValue.ToString, CInt(ePropertyType), dictValidValues, sPropertyKey)
        Dim row As DataGridViewRow = Nothing

        If iIndex > -1 Then
            row = grdProperties.Rows(iIndex)
            If ePropertyType = ColumnType.Number Then
                row.Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        End If



        If row IsNot Nothing Then
            If dictValidValues IsNot Nothing Then
                Dim cellCombo As New DataGridViewComboBoxCell
                cellCombo.Value = PropertyValue
                cellCombo.DataSource = dictValidValues
                cellCombo.DisplayMember = "Display"
                cellCombo.ValueMember = "Value"
                row.Cells(1) = cellCombo
            End If

            row.Cells(0).Style.BackColor = SystemColors.Control
        End If

    End Sub


    Private Sub treeItemBrowser_AfterSelect(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles treeItemBrowser.AfterSelect
        RefreshFromKey(e.Node.Name)
    End Sub


    Private Sub RefreshFromKey(ByVal sKey As String)

        grdProperties.Rows.Clear()
        grdProperties.Tag = sKey

        Select Case Adventure.GetTypeFromKeyNice(sKey)
            Case "Location"
                With Adventure.htblLocations(sKey)
                    AddProperty("@SEEN", "Seen", .SeenBy(Adventure.Player.Key))
                    For Each p As clsProperty In .htblProperties.Values
                        AddProperty(p)
                    Next
                End With
                
            Case "Object"
                With Adventure.htblObjects(sKey)
                    AddProperty("@SEEN", "Seen", .SeenBy(Adventure.Player.Key))
                    For Each p As clsProperty In Adventure.htblObjects(sKey).htblProperties.Values
                        AddProperty(p)
                    Next
                End With

            Case "Task"
                With Adventure.htblTasks(sKey)
                    AddProperty("@TASKCOMPLETED", "Completed", .Completed)
                    AddProperty("@SCORED", "Scored", .Scored)
                End With                

            Case "Character"
                With Adventure.htblCharacters(sKey)
                    AddProperty("@SEEN", "Seen", .SeenBy(Adventure.Player.Key))
                    For Each p As clsProperty In .htblProperties.Values
                        AddProperty(p)
                    Next
                End With

            Case "Variable"
                With Adventure.htblVariables(sKey)
                    If .Length = 1 Then
                        Select Case .Type
                            Case clsVariable.VariableTypeEnum.Numeric
                                AddProperty("@VALUE", "Value", .IntValue, ColumnType.Number)
                                grdProperties.Rows(grdProperties.Rows.Count - 1).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                            Case clsVariable.VariableTypeEnum.Text
                                AddProperty("@VALUE", "Value", .StringValue, ColumnType.Text)
                        End Select
                    Else
                        For i As Integer = 0 To .Length - 1
                             Select .Type
                                Case clsVariable.VariableTypeEnum.Numeric
                                    AddProperty("@VALUE_" & i, "Value [" & i + 1 & "]", .IntValue(i + 1), ColumnType.Number)
                                    grdProperties.Rows(grdProperties.Rows.Count - 1).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                                Case clsVariable.VariableTypeEnum.Text
                                    AddProperty("@VALUE_" & i, "Value [" & i + 1 & "]", .StringValue(i + 1), ColumnType.Text)
                            End Select
                        Next
                    End If                    
                End With

            Case "Event"
                With Adventure.htblEvents(sKey)
                    Dim dictStatuses As New List(Of KeyValue)
                    dictStatuses.Add(New KeyValue(clsEvent.StatusEnum.CountingDownToStart, "Counting Down"))
                    dictStatuses.Add(New KeyValue(clsEvent.StatusEnum.Finished, "Finished"))
                    dictStatuses.Add(New KeyValue(clsEvent.StatusEnum.NotYetStarted, "Not Yet Started"))
                    dictStatuses.Add(New KeyValue(clsEvent.StatusEnum.Paused, "Paused"))
                    dictStatuses.Add(New KeyValue(clsEvent.StatusEnum.Running, "Running"))
                    AddProperty("@STATUS", "Status", .Status, ColumnType.Combo, dictStatuses)
                    AddProperty("@TIMER", "Timer", .TimerFromStartOfEvent, ColumnType.Number)
                End With
                
        End Select

        SplitContainer2.Panel2Collapsed = Not grdProperties.Rows.Count > 0

    End Sub

    Private Sub grdProperties_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles grdProperties.CellBeginEdit

        If e.ColumnIndex = 1 AndAlso e.RowIndex > -1 AndAlso e.RowIndex < grdProperties.Rows.Count Then
            If grdProperties.Rows(e.RowIndex).Cells(1).Style.ForeColor = DisabledColour Then e.Cancel = True
        End If
        
    End Sub


    Private Sub grdProperties_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grdProperties.CellEndEdit

        Try
            If grdProperties.Tag IsNot Nothing Then
                Dim sKey As String = SafeString(grdProperties.Tag)
                Dim row As DataGridViewRow = grdProperties.Rows(e.RowIndex)
                Dim sPropKey As String = row.Cells(4).Value.ToString

                Select Case Adventure.GetTypeFromKeyNice(sKey)
                    Case "Location"
                        With Adventure.htblLocations(sKey)
                            Select Case sPropKey
                                Case "@SEEN"
                                    .SeenBy(Adventure.Player.Key) = SafeBool(row.Cells(1).Value)
                                Case Else
                                    .htblProperties(sPropKey).Value = row.Cells(1).Value.ToString
                            End Select
                        End With

                    Case "Object"
                        With Adventure.htblObjects(sKey)
                            Select Case sPropKey
                                Case "@SEEN"
                                    .SeenBy(Adventure.Player.Key) = SafeBool(row.Cells(1).Value)
                                Case Else
                                    .htblProperties(sPropKey).Value = row.Cells(1).Value.ToString
                            End Select
                        End With

                    Case "Task"
                        With Adventure.htblTasks(sKey)
                            Select Case sPropKey
                                Case "@TASKCOMPLETED"
                                    .Completed = SafeBool(row.Cells(1).Value)
                                Case "@SCORED"
                                    .Scored = SafeBool(row.Cells(1).Value)
                                Case Else
                            End Select
                        End With

                    Case "Character"
                        With Adventure.htblCharacters(sKey)
                            Select Case sPropKey
                                Case "@SEEN"
                                    .SeenBy(Adventure.Player.Key) = SafeBool(row.Cells(1).Value)
                                Case Else
                                    .htblProperties(sPropKey).Value = row.Cells(1).Value.ToString
                                    Select Case sPropKey
                                        Case "CharacterAtLocation"
                                            Dim dest As New clsCharacterLocation(Adventure.htblCharacters(sKey))

                                            ' Default new destination to current location
                                            dest.ExistWhere = .Location.ExistWhere                                            
                                            dest.Position = .Location.Position                                            
                                            dest.Key = row.Cells(1).Value.ToString

                                            .Move(dest)
                                    End Select
                            End Select
                        End With

                    Case "Variable"
                        With Adventure.htblVariables(sKey)
                            Select Case sPropKey
                                Case "@VALUE"
                                    If row.Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleRight Then
                                        .IntValue = SafeInt(row.Cells(1).Value)
                                    Else
                                        .StringValue = SafeString(row.Cells(1).Value)
                                    End If
                                Case Else
                                    If sPropKey.StartsWith("@VALUE_") Then
                                        Dim iIndex As Integer = SafeInt(sPropKey.Replace("@VALUE_", "")) + 1
                                        If row.Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleRight Then
                                            .IntValue(iIndex) = SafeInt(row.Cells(1).Value)
                                        Else
                                            .StringValue(iIndex) = SafeString(row.Cells(1).Value)
                                        End If
                                    End If
                            End Select
                        End With

                    Case "Event"
                        With Adventure.htblEvents(sKey)
                            Select Case sPropKey
                                Case "@STATUS"
                                    .Status = CType(row.Cells(1).Value, clsEvent.StatusEnum)
                                Case "@TIMER"
                                    .TimerToEndOfEvent = Adventure.htblEvents(sKey).Length.Value - SafeInt(row.Cells(1).Value)
                                Case Else
                            End Select
                        End With

                End Select
            End If
        Catch ex As Exception
            ErrMsg("Error setting property value", ex)
        End Try
       
    End Sub


    Private Sub grdProperties_SelectionChanged(sender As Object, e As EventArgs) Handles grdProperties.SelectionChanged
        For Each cell As DataGridViewCell In grdProperties.SelectedCells
            If cell.ColumnIndex = 0 OrElse (cell.ColumnIndex = 1 AndAlso cell.Style.ForeColor = DisabledColour) Then cell.Selected = False
        Next
    End Sub


    Private Sub grdProperties_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles grdProperties.SortCompare
        If e.Column.Index = 1 Then
            e.SortResult = SafeString(e.CellValue1).CompareTo(SafeString(e.CellValue2))
            e.Handled = True
        End If
    End Sub

End Class