Public Class PropertyValue

    Private prop As clsProperty
    Private arlDirectionRefs As New StringArrayList
    Private arlObjectRefs As New StringArrayList
    Private arlCharacterRefs As New StringArrayList
    Private sCommand As String = ""


    Public Event ValueChanged(sender As Object, e As System.EventArgs)
    

    Public Property PropertyKey As String
        Get
            If prop IsNot Nothing Then
                Return prop.Key
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            If prop Is Nothing OrElse value <> prop.Key Then
                If Adventure IsNot Nothing AndAlso Adventure.htblAllProperties.ContainsKey(value) Then
                    prop = Adventure.htblAllProperties(value)
                    LoadList()                
                End If
            End If
        End Set
    End Property


    Public WriteOnly Property Command As String        
        Set(value As String)
            If value <> sCommand Then
                sCommand = value
                arlDirectionRefs = GetReferences(ReferencesType.Direction, sCommand)
                arlObjectRefs = GetReferences(ReferencesType.Object, sCommand)
                arlCharacterRefs = GetReferences(ReferencesType.Character, sCommand)
            End If
        End Set
    End Property


    Private Sub LoadList()

        With cmbList
            .Items.Clear()

            Select Case prop.Type
                Case clsProperty.PropertyTypeEnum.CharacterKey
                    .Items.Add(THEPLAYER, "[ The Player Character ]")
                    .Items.Add(ANYCHARACTER, "[ Any Character ]")
                    For Each c As String In arlCharacterRefs
                        .Items.Add(c, Adventure.GetNameFromKey(c, False))
                    Next
                    For Each c As clsCharacter In Adventure.htblCharacters.Values
                        .Items.Add(c.Key, c.Name)
                    Next
                    ExpressionOrVariable.Visible = False
                    cmbList.Visible = True
                Case clsProperty.PropertyTypeEnum.Integer
                    ExpressionOrVariable.Visible = True
                    ExpressionOrVariable.AllowedListType = ItemSelector.ItemEnum.Expression Or ItemSelector.ItemEnum.Variable
                    ExpressionOrVariable.ListType = ItemSelector.ItemEnum.Expression
                    cmbList.Visible = False
                    ExpressionOrVariable.BringToFront()
                Case clsProperty.PropertyTypeEnum.LocationGroupKey
                    For Each g As clsGroup In Adventure.htblGroups.Values
                        If g.GroupType = clsGroup.GroupTypeEnum.Locations Then .Items.Add(g.Key, g.Name)
                    Next
                    ExpressionOrVariable.Visible = False
                    cmbList.Visible = True
                Case clsProperty.PropertyTypeEnum.LocationKey
                    For Each loc As clsLocation In Adventure.htblLocations.Values
                        .Items.Add(loc.Key, loc.ShortDescription.ToString)
                    Next
                    ExpressionOrVariable.Visible = False
                    cmbList.Visible = True
                Case clsProperty.PropertyTypeEnum.ObjectKey
                    For Each o As String In arlObjectRefs
                        .Items.Add(o, Adventure.GetNameFromKey(o, False))
                    Next
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        'If ob.HasSurface Then
                        .Items.Add(ob.Key, ob.FullName)
                    Next
                    ExpressionOrVariable.Visible = False
                    cmbList.Visible = True
                Case clsProperty.PropertyTypeEnum.SelectionOnly
                    .Items.Add(sSELECTED)
                    .Items.Add(sUNSELECTED)
                    ExpressionOrVariable.Visible = False
                    cmbList.Visible = True
                Case clsProperty.PropertyTypeEnum.StateList
                    For Each s As String In prop.PossibleValues
                        .Items.Add(s, s)
                    Next
                    ExpressionOrVariable.Visible = False
                    cmbList.Visible = True
                Case clsProperty.PropertyTypeEnum.Text
                    ExpressionOrVariable.Visible = True
                    ExpressionOrVariable.AllowedListType = ItemSelector.ItemEnum.Expression Or ItemSelector.ItemEnum.Variable
                    ExpressionOrVariable.ListType = ItemSelector.ItemEnum.Expression
                    cmbList.Visible = False
                    ExpressionOrVariable.BringToFront()
                Case clsProperty.PropertyTypeEnum.ValueList
                    ExpressionOrVariable.Visible = True
                    ExpressionOrVariable.ValueListPropertyKey = prop.Key
                    ExpressionOrVariable.AllowedListType = ItemSelector.ItemEnum.Expression Or ItemSelector.ItemEnum.ValueList
                    ExpressionOrVariable.ListType = ItemSelector.ItemEnum.ValueList
                    cmbList.Visible = False
                    ExpressionOrVariable.BringToFront()
            End Select

        End With

    End Sub


    Private Sub cmbList_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbList.ValueChanged, ExpressionOrVariable.SelectionChanged
        RaiseEvent ValueChanged(Me, e)
    End Sub


    Public Property Value As String
        Get
            If cmbList.Visible Then
                If cmbList.SelectedItem Is Nothing Then Return Nothing
                Return cmbList.SelectedItem.DataValue.ToString
            Else
                If ExpressionOrVariable.ListType = ItemSelector.ItemEnum.Variable AndAlso Adventure.htblVariables.ContainsKey(ExpressionOrVariable.Key) Then
                    Return "%" & Adventure.htblVariables(ExpressionOrVariable.Key).Name & "%"
                Else
                    Return ExpressionOrVariable.Key
                End If
            End If
        End Get
        Set(value As String)
            If prop IsNot Nothing Then
                Select Case prop.Type
                    Case clsProperty.PropertyTypeEnum.CharacterKey, clsProperty.PropertyTypeEnum.LocationGroupKey, clsProperty.PropertyTypeEnum.LocationKey, clsProperty.PropertyTypeEnum.ObjectKey, clsProperty.PropertyTypeEnum.StateList, clsProperty.PropertyTypeEnum.SelectionOnly
                        SetCombo(cmbList, value)
                        cmbList.Visible = True
                        ExpressionOrVariable.Visible = False
                    Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.StateList, clsProperty.PropertyTypeEnum.Text
                        Dim bSetVar As Boolean = False
                        If value.Length > 2 AndAlso value.StartsWith("%") AndAlso value.EndsWith("%") Then 'AndAlso Adventure.htblVariables.ContainsKey(value.Substring(1, value.Length - 2)) Then
                            For Each v As clsVariable In Adventure.htblVariables.Values
                                If value = "%" & v.Name & "%" Then
                                    ExpressionOrVariable.Key = v.Key
                                    bSetVar = True
                                    Exit For
                                End If
                            Next
                        End If
                        If Not bSetVar Then
                            ExpressionOrVariable.ListType = ItemSelector.ItemEnum.Expression
                            ExpressionOrVariable.Expression.Value = value                            
                        End If

                        cmbList.Visible = False
                        ExpressionOrVariable.Visible = True
                    Case clsProperty.PropertyTypeEnum.ValueList
                        Dim bSetVL As Boolean = False

                        If IsNumeric(value) Then
                            Dim iValue As Integer = SafeInt(value)

                            For Each sValue As String In prop.ValueList.Keys
                                If prop.ValueList(sValue) = iValue Then
                                    ExpressionOrVariable.Key = iValue.ToString
                                    bSetVL = True
                                End If
                            Next
                        End If
                        If Not bSetVL Then
                            ExpressionOrVariable.ListType = ItemSelector.ItemEnum.Expression
                            ExpressionOrVariable.Expression.Value = value
                        End If
                End Select
            End If
        End Set
    End Property


    Private Sub PropertyValue_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        cmbList.DropDownListWidth = Math.Max(cmbList.Width, 170)
    End Sub

End Class
