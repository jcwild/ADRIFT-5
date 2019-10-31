Public Class ItemSelector

    Public Shadows Event GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Shadows Event LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Private bNeedsReload As Boolean = False


    <Flags()> _
    Public Enum ItemEnum
        [Nothing] = 0
        Location = 1
        [Object] = 2
        Task = 4
        [Event] = 8
        Character = 16
        Hint = 32
        [Property] = 64
        LocationGroup = 128
        Variable = 256
        Expression = 512
        ValueList = 1024
    End Enum
    Private eAllowedListTypes As ItemEnum
    Private eCurrentListType As ItemEnum

    Public Event FilledList(ByVal sender As Object, ByVal e As EventArgs)

    'Public Overrides Property BackColor() As Color
    '    Get
    '        Return MyBase.BackColor
    '    End Get
    '    Set(ByVal value As Color)
    '        MyBase.BackColor = value
    '        btnItemType.Appearance.BackColor = value
    '        btnEdit.Appearance.BackColor = value
    '        btnNew.Appearance.BackColor = value
    '    End Set
    'End Property

    Private bAllowHidden As Boolean = False
    Public Property AllowHidden As Boolean
        Get
            Return bAllowHidden
        End Get
        Set(value As Boolean)
            bAllowHidden = value
        End Set
    End Property


    Private bAllowAddEdit As Boolean = True
    Public Property AllowAddEdit() As Boolean
        Get
            Return bAllowAddEdit
        End Get
        Set(ByVal value As Boolean)
            If value <> bAllowAddEdit Then
                If value Then
                    btnNew.Visible = True
                    btnEdit.Visible = True
                    cmbList.Width -= 20
                Else
                    btnNew.Visible = False
                    btnEdit.Visible = False
                    cmbList.Width += 20
                End If
            End If
            bAllowAddEdit = value
        End Set
    End Property

    Public Property AllowedListType() As ItemEnum
        Get
            Return eAllowedListTypes
        End Get
        Set(ByVal value As ItemEnum)
            eAllowedListTypes = value

            Try
                ' Default eCurrentListType to first one we find  
                Dim iCount As Integer = 0
                For Each e As ItemEnum In New ItemEnum() {ItemEnum.Location, ItemEnum.Object, ItemEnum.Task, ItemEnum.Event, ItemEnum.Character, ItemEnum.LocationGroup, ItemEnum.Hint, ItemEnum.Property, ItemEnum.Variable, ItemEnum.Expression, ItemEnum.ValueList}
                    If bIsItemInList(e) Then
                        If iCount = 0 Then ListType = e ' SetListType(e)
                        iCount += 1
                    End If
                Next
                If iCount = 1 Then
                    btnItemType.Visible = False
                    cmbList.Left = 0
                    cmbList.Width = Me.Width - CInt(IIf(bAllowAddEdit, btnNew.Width - 2, 0))
                Else
                    btnItemType.Visible = True
                    cmbList.Left = btnItemType.Width
                    cmbList.Width = Me.Width - CInt(IIf(bAllowAddEdit, btnNew.Width - 2, 0)) - btnItemType.Width
                End If
            Catch ex As Exception
                ErrMsg("AllowedListType error", ex)
            End Try
        End Set
    End Property


    Private _sRestrictProperty As String
    Public Property RestrictProperty As String
        Get
            Return _sRestrictProperty
        End Get
        Set(value As String)
            If value <> _sRestrictProperty Then
                _sRestrictProperty = value
                LoadList(ListType)
            End If
        End Set
    End Property

    Private _ValueListPropertyKey As String
    Public WriteOnly Property ValueListPropertyKey As String
        Set(value As String)
            _ValueListPropertyKey = value
            ListType = ItemEnum.ValueList
        End Set
    End Property


    Private bLoaded As Boolean = False
    Private sKey As String
    Private sLastValidKey As String
    Public Property Key() As String
        Get
            If Expression.Visible Then
                Return Expression.Value
            Else
                Return sKey
            End If
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then Exit Property ' Designer likes to give us a Key = Nothing, doh!            

            cmbList.SuspendLayout()

            Dim typKey As Type = Adventure.GetTypeFromKey(value)
            If typKey IsNot Nothing Then
                Select Case True
                    Case typKey Is GetType(clsLocation)
                        If bIsItemInList(ItemEnum.Location) Then ListType = ItemEnum.Location ' SetListType(ItemEnum.Location)
                    Case typKey Is GetType(clsObject)
                        If bIsItemInList(ItemEnum.Object) Then ListType = ItemEnum.Object ' SetListType(ItemEnum.Object)
                    Case typKey Is GetType(clsTask)
                        If bIsItemInList(ItemEnum.Task) Then ListType = ItemEnum.Task ' SetListType(ItemEnum.Task)
                    Case typKey Is GetType(clsEvent)
                        If bIsItemInList(ItemEnum.Event) Then ListType = ItemEnum.Event ' SetListType(ItemEnum.Event)
                    Case typKey Is GetType(clsCharacter)
                        If bIsItemInList(ItemEnum.Character) Then ListType = ItemEnum.Character ' SetListType(ItemEnum.Character)
                    Case typKey Is GetType(clsGroup)
                        If bIsItemInList(ItemEnum.LocationGroup) Then ListType = ItemEnum.LocationGroup ' SetListType(ItemEnum.LocationGroup)
                    Case typKey Is GetType(clsVariable)
                        If bIsItemInList(ItemEnum.Variable) Then ListType = ItemEnum.Variable ' SetListType(ItemEnum.Variable)
                        '... etc
                End Select
            End If

            sKey = value
            SetCombo(cmbList, sKey)

            cmbList.ResumeLayout()

            If ListType = ItemEnum.Expression Then Expression.Value = value

        End Set
    End Property


    Public Property ListType() As ItemEnum
        Get
            Return eCurrentListType
        End Get
        Set(ByVal value As ItemEnum)

            Select Case value
                Case ItemEnum.Character
                    btnItemType.Appearance.Image = Global.ADRIFT.My.Resources.imgCharacter16
                Case ItemEnum.Event
                    btnItemType.Appearance.Image = Global.ADRIFT.My.Resources.imgEvent16
                Case ItemEnum.Hint
                    btnItemType.Appearance.Image = Global.ADRIFT.My.Resources.imgHint16
                Case ItemEnum.Location
                    btnItemType.Appearance.Image = Global.ADRIFT.My.Resources.imgLocation16
                Case ItemEnum.LocationGroup
                    btnItemType.Appearance.Image = Global.ADRIFT.My.Resources.imgGroup16
                Case ItemEnum.Object
                    btnItemType.Appearance.Image = Global.ADRIFT.My.Resources.imgObjectDynamic16
                Case ItemEnum.Property
                    btnItemType.Appearance.Image = Global.ADRIFT.My.Resources.imgProperty16
                Case ItemEnum.Task
                    btnItemType.Appearance.Image = Global.ADRIFT.My.Resources.imgTaskGeneral16
                Case ItemEnum.Variable
                    btnItemType.Appearance.Image = Global.ADRIFT.My.Resources.imgVariable16
                Case ItemEnum.Expression
                    btnItemType.Appearance.Image = Global.ADRIFT.My.Resources.imgExpression
                Case ItemEnum.ValueList
                    btnItemType.Appearance.Image = Global.ADRIFT.My.Resources.imgVariable16
            End Select

            If DesignMode Then Exit Property

            If value = ItemEnum.Expression Then
                Select Case eCurrentListType
                    Case ItemEnum.Character, ItemEnum.Event, ItemEnum.Hint, ItemEnum.Location, ItemEnum.LocationGroup, ItemEnum.Object, ItemEnum.Task
                        Expression.Value = sLastValidKey
                    Case ItemEnum.Property
                        TODO()
                    Case ItemEnum.ValueList
                        If sLastValidKey <> "" Then Expression.Value = sLastValidKey
                    Case ItemEnum.Variable
                        If sLastValidKey <> "" Then Expression.Value = "%" & sLastValidKey & "%"
                End Select
            Else
                If eCurrentListType = ItemEnum.Expression Then
                    Select Case value
                        Case ItemEnum.Property
                            TODO()
                        Case ItemEnum.ValueList
                            If IsNumeric(Expression.Value) Then sLastValidKey = Expression.Value
                        Case ItemEnum.Variable
                            If Expression.Value.StartsWith("%") AndAlso Expression.Value.EndsWith("%") Then
                                sLastValidKey = Expression.Value.Substring(1, Expression.Value.Length - 2)
                            End If
                    End Select
                End If                
            End If

            eCurrentListType = value
            LoadList(value)

            If ComboContainsKey(cmbList, sLastValidKey) Then SetCombo(cmbList, sLastValidKey)

            RaiseEvent SelectionChanged(Me, New EventArgs)
        End Set
    End Property
   


    Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItemType.Click

        ' Got to cycle thru to the next allowed item type

        Dim eNewListType As ItemEnum = CType(IIf(eCurrentListType = ItemEnum.ValueList, ItemEnum.Location, eCurrentListType * 2), ItemEnum)
        If eNewListType = ItemEnum.Nothing Then
            ErrMsg("List Type of Nothing!")
            Exit Sub
        End If
        While Not bIsItemInList(eNewListType)
            eNewListType = CType(IIf(eNewListType = ItemEnum.ValueList, ItemEnum.Location, eNewListType * 2), ItemEnum)
        End While

        sKey = ""
        ListType = eNewListType ' SetListType(eNewListType)

    End Sub



    Private Function bIsItemInList(ByVal eItem As ItemEnum) As Boolean
        Return CBool(eItem And eAllowedListTypes)
    End Function



    Public Overrides ReadOnly Property Focused() As Boolean
        Get
            Return Me.cmbList.Focused OrElse Me.btnItemType.Focused OrElse Me.btnNew.Focused
        End Get
    End Property


    Private Sub cmbList_BeforeDropDown(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbList.BeforeDropDown
        If bNeedsReload Then LoadList(ListType) ' ItemEnum.LocationGroup) ' In case any names changed - can't do after edit because we're not modal
        bNeedsReload = False
    End Sub


    Private Sub cmbList_Click(sender As Object, e As System.EventArgs) Handles cmbList.Click
        If bNeedsReload Then LoadList(ListType) ' ItemEnum.LocationGroup) ' In case any names changed - can't do after edit because we're not modal
        bNeedsReload = False
    End Sub



    Private Sub LocationGroup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbList.GotFocus, btnItemType.GotFocus, btnNew.GotFocus
        RaiseEvent GotFocus(Me, e)
    End Sub

    Private Sub LocationGroup_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbList.LostFocus, btnItemType.LostFocus, btnNew.LostFocus
        If Not Me.Focused Then RaiseEvent LostFocus(Me, e)
    End Sub



    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Select Case eCurrentListType
            Case ItemEnum.Character
                Dim chNew As New clsCharacter
                Dim fCharacter As New frmCharacter(chNew, False)
                fCharacter.ShowDialog()
                sKey = chNew.Key
                LoadList(ItemEnum.Character)
                fCharacter.Dispose()

            Case ItemEnum.Event
            Case ItemEnum.Hint
            Case ItemEnum.Location
                Dim locNew As New clsLocation
                Dim fLocation As New frmLocation(locNew, False)
                fLocation.ShowDialog()
                fLocation.Dispose()
                sKey = locNew.Key
                LoadList(ItemEnum.Location)
                fLocation.Dispose()

            Case ItemEnum.LocationGroup
                ' Bring up rooms list
                ' If we create a group with same rooms as an existing group, ask if we want to use existing

                Dim grp As New clsGroup
                Dim fGroup As New frmGroup(grp, False)
                If fGroup.ShowDialog = DialogResult.OK Then
                    ' Check to see if we have an existing group with the same locations...
                    For Each g As clsGroup In Adventure.htblGroups.Values
                        If g.arlMembers.Count = grp.arlMembers.Count Then
                            For Each s As String In grp.arlMembers
                                If Not g.arlMembers.Contains(s) Then GoTo CheckNextGroup
                            Next
                            ' Ok, we have the same members as group g
                            If MessageBox.Show("You already have a group '" & g.Name & "' with the same Locations.  Would you like to use this instead?", "Existing group found", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                                sKey = g.Key
                                SetCombo(cmbList, sKey)
                                Exit Sub
                            End If
                        End If
CheckNextGroup:
                    Next
                    Adventure.htblGroups.Add(grp, grp.Key)
                    sKey = grp.Key
                    LoadList(ItemEnum.LocationGroup)
                End If
                fGroup.Dispose()

            Case ItemEnum.Object
                Dim obNew As New clsObject
                Dim fObject As New frmObject(obNew, False)
                fObject.ShowDialog()
                fObject.Dispose()
                sKey = obNew.Key
                LoadList(ItemEnum.Object)
                fObject.Dispose()

            Case ItemEnum.Property

            Case ItemEnum.Task
                Dim tasNew As New clsTask
                Dim fTask As New frmTask(tasNew, False)
                fTask.ShowDialog()
                fTask.Dispose()
                sKey = tasNew.Key
                LoadList(ItemEnum.Task)
                fTask.Dispose()

            Case ItemEnum.Variable
                Dim varNew As New clsVariable
                Dim fVar As New frmVariable(varNew, False)
                fVar.ShowDialog()
                fVar.Dispose()
                sKey = varNew.Key
                LoadList(ItemEnum.Variable)
                fVar.Dispose()

        End Select

    End Sub



    Private Sub LoadList(ByVal eListType As ItemEnum)

        ' cmbList.SuspendLayout()

        Dim bCmbVisible As Boolean = True
        cmbList.Items.Clear()
        cmbList.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending

        Select Case eListType
            Case ItemEnum.Character
                cmbList.Items.Add("", "[ No Character Selected ]")
                'Application.DoEvents()
                cmbList.Items.Add(THEPLAYER, "[ The Player Character ]")
                For Each ch As clsCharacter In Adventure.htblCharacters.Values
                    If RestrictProperty = "" OrElse ch.HasProperty(RestrictProperty) Then _
                    cmbList.Items.Add(ch.Key, ch.Name)
                Next
                ToolTip1.SetToolTip(btnItemType, "Change list type (currently set to characters)")
                ToolTip1.SetToolTip(btnNew, "Add new character")
                ToolTip1.SetToolTip(btnEdit, "Edit character")
            Case ItemEnum.Event
            Case ItemEnum.Hint
            Case ItemEnum.Location
                If bAllowHidden Then
                    cmbList.Items.Add("", "[  No Location Selected  ]")
                Else
                    cmbList.Items.Add("", "[ No Location Selected ]")
                End If
                'Application.DoEvents()
                If bAllowHidden Then cmbList.Items.Add(HIDDEN, "[ Hidden ]")
                For Each loc As clsLocation In Adventure.htblLocations.Values
                    If RestrictProperty = "" OrElse loc.HasProperty(RestrictProperty) Then _
                    cmbList.Items.Add(loc.Key, loc.ShortDescription.ToString)
                Next
                ToolTip1.SetToolTip(btnItemType, "Change list type (currently set to locations)")
                ToolTip1.SetToolTip(btnNew, "Add new location")
                ToolTip1.SetToolTip(btnEdit, "Edit location")
            Case ItemEnum.LocationGroup
                cmbList.Items.Add("", "[ No Group Selected ]")
                'Application.DoEvents()
                For Each grp As clsGroup In Adventure.htblGroups.Values
                    If grp.GroupType = clsGroup.GroupTypeEnum.Locations Then
                        cmbList.Items.Add(grp.Key, grp.Name)
                    End If
                Next
                ToolTip1.SetToolTip(btnItemType, "Change list type (currently set to groups)")
                ToolTip1.SetToolTip(btnNew, "Add new group")
                ToolTip1.SetToolTip(btnEdit, "Edit group")
            Case ItemEnum.Object
                cmbList.Items.Add("", "[ No Object Selected ]")
                'Application.DoEvents()
                For Each ob As clsObject In Adventure.htblObjects.Values
                    If RestrictProperty = "" OrElse ob.HasProperty(RestrictProperty) Then _
                    cmbList.Items.Add(ob.Key, ob.FullName)
                Next
                ToolTip1.SetToolTip(btnItemType, "Change list type (currently set to objects)")
                ToolTip1.SetToolTip(btnNew, "Add new object")
                ToolTip1.SetToolTip(btnEdit, "Edit object")
            Case ItemEnum.Property
            Case ItemEnum.Task
                cmbList.Items.Add("", "[ No Task Selected ]")
                'Application.DoEvents()
                For Each t As clsTask In Adventure.htblTasks.Values
                    cmbList.Items.Add(t.Key, t.Description)
                Next
                ToolTip1.SetToolTip(btnItemType, "Change list type (currently set to tasks)")
                ToolTip1.SetToolTip(btnNew, "Add new task")
                ToolTip1.SetToolTip(btnEdit, "Edit task")
            Case ItemEnum.Variable
                cmbList.Items.Add("", "[ No Variable Selected ]")
                'Application.DoEvents()
                For Each v As clsVariable In Adventure.htblVariables.Values
                    cmbList.Items.Add(v.Key, v.Name)
                Next
                ToolTip1.SetToolTip(btnItemType, "Change list type (currently set to variables)")
                ToolTip1.SetToolTip(btnNew, "Add new variable")
                ToolTip1.SetToolTip(btnEdit, "Edit variable")
            Case ItemEnum.Expression
                bCmbVisible = False
                ToolTip1.SetToolTip(btnItemType, "Change list type (currently set to expressions)")
                ToolTip1.SetToolTip(btnNew, "Add new variable")
                ToolTip1.SetToolTip(btnEdit, "Edit variable")
                'Expression.Value = sKey
            Case ItemEnum.ValueList
                cmbList.Items.Add("", "[ No Value Selected ]")
                'Application.DoEvents()
                Dim p As clsProperty = Nothing
                If Adventure.htblAllProperties.TryGetValue(_ValueListPropertyKey, p) Then
                    cmbList.SortStyle = Infragistics.Win.ValueListSortStyle.None
                    For Each sValue As String In p.ValueList.Keys
                        cmbList.Items.Add(p.ValueList(sValue), sValue)
                    Next
                End If
                ToolTip1.SetToolTip(btnItemType, "Change list type (currently set to valuelist)")
                ToolTip1.SetToolTip(btnEdit, "Edit valuelist")
                'Expression.Value = ""
        End Select

        cmbList.Visible = bCmbVisible
        btnNew.Visible = bCmbVisible
        btnEdit.Visible = bCmbVisible
        Expression.Visible = Not bCmbVisible
        If eListType = ItemEnum.ValueList Then btnNew.Visible = False

        SetCombo(cmbList, sKey)
        If cmbList.SelectedIndex = -1 Then cmbList.SelectedIndex = 0
        RaiseEvent FilledList(Me, New EventArgs)

        'cmbList.ResumeLayout()

    End Sub



    Private Sub cmbList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbList.SelectionChanged

        If Not cmbList.SelectedItem Is Nothing Then
            sKey = CStr(cmbList.SelectedItem.DataValue)

            If sKey <> "" Then
                sLastValidKey = sKey
                btnEdit.Visible = True
                btnNew.Visible = False
            Else
                btnEdit.Visible = False
                If ListType <> ItemEnum.ValueList Then btnNew.Visible = True
            End If
        End If
        RaiseEvent SelectionChanged(Me, New EventArgs)

    End Sub


    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Select Case eCurrentListType
            Case ItemEnum.Character
                If sKey = THEPLAYER Then sKey = Adventure.Player.Key
                Dim fCharacter As New frmCharacter(Adventure.htblCharacters(sKey), True)
            Case ItemEnum.Event
                Dim fEvent As New frmEvent(Adventure.htblEvents(sKey), True)
            Case ItemEnum.Hint
                Dim fHint As New frmHint(Adventure.htblHints(sKey), True)
            Case ItemEnum.Location
                Dim fLocation As New frmLocation(Adventure.htblLocations(sKey), True)
            Case ItemEnum.LocationGroup
                Dim fRoomGroup As New frmGroup(Adventure.htblGroups(sKey), True)
            Case ItemEnum.Object
                Dim fObject As New frmObject(Adventure.htblObjects(sKey), True)
            Case ItemEnum.Property
                Dim fProperty As New frmProperty(Adventure.htblAllProperties(sKey), True)
            Case ItemEnum.Task
                Dim fTask As New frmTask(Adventure.htblTasks(sKey), True)
            Case ItemEnum.Variable
                Dim fVar As New frmVariable(Adventure.htblVariables(sKey), True)
        End Select
        bNeedsReload = True

    End Sub


    Private Sub Expression_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Expression.ValueChanged
        'sKey = Expression.Value
        RaiseEvent SelectionChanged(sender, e)
    End Sub

End Class
