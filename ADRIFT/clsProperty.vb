Public Class clsProperty
    Inherits clsItem

    Friend Enum PropertyOfEnum
        Locations = 0
        Objects = 1
        Characters = 2
    End Enum

    Friend Enum PropertyTypeEnum
        SelectionOnly
        [Integer]
        Text
        ObjectKey
        StateList
        CharacterKey
        LocationKey
        LocationGroupKey
        ValueList
    End Enum

    'Private sKey As String
    Private eType As PropertyTypeEnum
    Private iIntData As Integer
    Private sStringData As Description
    Private bSelected As Boolean
    Private sDescription As String
    Private sDependentKey As String
    Private sDependentValue As String
    Private bMandatory As Boolean
    Private bFromGroup As Boolean
    Private sRestrictProperty As String
    Private sRestrictValue As String

    Friend arlStates As New StringArrayList
    Friend ValueList As New Dictionary(Of String, Integer)

    'Public Property Key() As String
    '    Get
    '        Return sKey
    '    End Get
    '    Set(ByVal Value As String)
    '        ' Can't do this check, as this property is not just member of Adventure.htblAllProperties
    '        'If Not KeyExists(Value) Then
    '        sKey = Value
    '        'Else
    '        '    Throw New Exception("Key " & sKey & " already exists")
    '        'End If
    '    End Set
    'End Property

    Private ePropertyOf As PropertyOfEnum
    Friend Property PropertyOf() As PropertyOfEnum
        Get
            Return ePropertyOf
        End Get
        Set(ByVal value As PropertyOfEnum)
            ePropertyOf = value
        End Set
    End Property



    'Private bIsLibrary As Boolean
    'Public Property IsLibrary() As Boolean
    '    Get
    '        Return bIsLibrary
    '    End Get
    '    Set(ByVal value As Boolean)
    '        bIsLibrary = value
    '    End Set
    'End Property

    'Private dtLastUpdated As Date
    'Friend Property LastUpdated() As Date
    '    Get
    '        If dtLastUpdated > Date.MinValue Then
    '            Return dtLastUpdated
    '        Else
    '            Return Now
    '        End If
    '    End Get
    '    Set(ByVal value As Date)
    '        dtLastUpdated = value
    '    End Set
    'End Property

    Public Property Mandatory() As Boolean
        Get
            Return bMandatory
        End Get
        Set(ByVal Value As Boolean)
            bMandatory = Value
        End Set
    End Property

    Public Property FromGroup() As Boolean
        Get
            Return bFromGroup
        End Get
        Set(ByVal value As Boolean)
            bFromGroup = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return sDescription
        End Get
        Set(ByVal Value As String)
            sDescription = Value
        End Set
    End Property

    Private sAppendToProperty As String
    Public Property AppendToProperty() As String
        Get
            Return sAppendToProperty
        End Get
        Set(ByVal value As String)
            sAppendToProperty = value
        End Set
    End Property

    Private bGroupOnly As Boolean
    Public Property GroupOnly As Boolean
        Get
            Return bGroupOnly
        End Get
        Set(value As Boolean)
            bGroupOnly = value
        End Set
    End Property

    Friend Property Type() As PropertyTypeEnum
        Get
            Return eType
        End Get
        Set(ByVal Value As PropertyTypeEnum)
            eType = Value
            Select Case eType
                Case PropertyTypeEnum.StateList
                    If Not arlStates.Contains(StringData.ToString) AndAlso arlStates.Count > 0 Then
                        StringData = New Description(arlStates(0)) ' Default the value to the first state
                    End If
                Case PropertyTypeEnum.ValueList
                    If Not ValueList.ContainsValue(iIntData) AndAlso ValueList.Count > 0 Then
                        'StringData = New Description(arlStates(0)) ' Default the value to the first state
                        For Each iValue As Integer In ValueList.Values
                            iIntData = iValue
                            Exit For
                        Next
                    End If
            End Select
        End Set
    End Property

    Public Property IntData() As Integer
        Get
            Return iIntData
        End Get
        Set(ByVal Value As Integer)
            iIntData = Value
        End Set
    End Property

    Friend Property StringData() As Description
        Get
            Return sStringData
        End Get
        Set(ByVal Value As Description)
            sStringData = Value
        End Set
    End Property

    Public Property Selected() As Boolean
        Get
            Return bSelected
        End Get
        Set(ByVal Value As Boolean)
            bSelected = Value
        End Set
    End Property

    Private _Indent As Integer = 0
    Public Property Indent As Integer
        Get
            Return _Indent
        End Get
        Set(value As Integer)
            _Indent = value
        End Set
    End Property

    Public Overrides ReadOnly Property Clone() As clsItem
        Get
            'Return CType(Me.MemberwiseClone, clsProperty)
            Return Copy()
        End Get
    End Property

    'Public Property BoolData() As Boolean
    '    Get
    '        If iIntData = 0 Then
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        If Value Then
    '            iIntData = 1
    '        Else
    '            iIntData = 0
    '        End If
    '    End Set
    'End Property

    Public Property DependentKey() As String
        Get
            Return sDependentKey
        End Get
        Set(ByVal Value As String)
            If iLoading > 0 OrElse Value Is Nothing OrElse KeyExists(Value) Then
                sDependentKey = Value
            Else
                Throw New Exception("Key " & Value & " doesn't exist")
            End If
        End Set
    End Property

    Public Property DependentValue() As String
        Get
            Return sDependentValue
        End Get
        Set(ByVal Value As String)
            ' TODO - check that it's a valid value
            sDependentValue = Value
        End Set
    End Property

    Public Property RestrictProperty() As String
        Get
            Return sRestrictProperty
        End Get
        Set(ByVal Value As String)
            sRestrictProperty = Value
        End Set
    End Property

    Public Property RestrictValue() As String
        Get
            Return sRestrictValue
        End Get
        Set(ByVal Value As String)
            sRestrictValue = Value
        End Set
    End Property


    Friend ReadOnly Property PossibleValues(Optional ByVal CurrentProperties As PropertyHashTable = Nothing) As StringArrayList
        Get
            Dim sValues As New StringArrayList

            Select Case Type
                Case clsProperty.PropertyTypeEnum.CharacterKey
                    For Each ch As clsCharacter In Adventure.htblCharacters.Values
                        If (RestrictProperty Is Nothing OrElse ch.HasProperty(RestrictProperty)) Then
                            If RestrictValue Is Nothing OrElse ch.GetPropertyValue(RestrictProperty) = RestrictValue Then
                                sValues.Add(ch.Key)
                            End If
                        End If
                    Next
                Case clsProperty.PropertyTypeEnum.Integer
                    TODO("Integer values")
                Case clsProperty.PropertyTypeEnum.LocationGroupKey
                    TODO("Location Group values")
                Case clsProperty.PropertyTypeEnum.LocationKey
                    For Each loc As clsLocation In Adventure.htblLocations.Values
                        If (RestrictProperty Is Nothing OrElse loc.HasProperty(RestrictProperty)) Then
                            If RestrictValue Is Nothing OrElse loc.GetPropertyValue(RestrictProperty) = RestrictValue Then
                                sValues.Add(loc.Key)
                            End If
                        End If
                    Next
                Case clsProperty.PropertyTypeEnum.ObjectKey
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If (RestrictProperty Is Nothing OrElse ob.HasProperty(RestrictProperty)) Then
                            If RestrictValue Is Nothing OrElse ob.GetPropertyValue(RestrictProperty) = RestrictValue Then
                                sValues.Add(ob.Key)
                            End If
                        End If
                    Next
                Case clsProperty.PropertyTypeEnum.SelectionOnly
                    sValues.Add(sSELECTED)
                    sValues.Add(sUNSELECTED) ' Not strictly a property value, but only way for action to remove the property
                Case clsProperty.PropertyTypeEnum.StateList
                    For Each sState As String In arlStates
                        sValues.Add(sState)
                    Next
                    If CurrentProperties Is Nothing Then CurrentProperties = Adventure.htblAllProperties
                    For Each prop As clsProperty In CurrentProperties.Values
                        If (CurrentProperties Is Adventure.htblAllProperties OrElse prop.Selected) AndAlso prop.Type = PropertyTypeEnum.StateList AndAlso prop.AppendToProperty = Me.Key Then
                            For Each sState As String In prop.arlStates
                                sValues.Add(sState)
                            Next
                        End If
                    Next
                    'End If
                Case clsProperty.PropertyTypeEnum.Text
                    TODO("Text values")
            End Select

            Return sValues
        End Get
    End Property

    Public Property Value(Optional ByVal bTesting As Boolean = False) As String
        Get
            Select Case eType
                Case PropertyTypeEnum.StateList, PropertyTypeEnum.ObjectKey, PropertyTypeEnum.CharacterKey, PropertyTypeEnum.LocationKey, PropertyTypeEnum.LocationGroupKey
                    Return sStringData.ToString
                Case PropertyTypeEnum.ValueList
                    Return iIntData.ToString 'SafeString(ValueList(sStringData.ToString))
                Case PropertyTypeEnum.Text
                    Return sStringData.ToString(bTesting)
                Case PropertyTypeEnum.Integer
                    Return iIntData.ToString
                Case PropertyTypeEnum.SelectionOnly
                    Return True.ToString
            End Select
            Return Nothing
        End Get
        Set(ByVal Value As String)
            Try
                Select Case eType
                    Case PropertyTypeEnum.StateList
                        If iLoading > 0 OrElse Value Is Nothing OrElse PossibleValues.Contains(Value) Then
                            sStringData = New Description(Value)
                        ElseIf PossibleValues.Count > 0 Then
                            ' Perhaps it's an expression that resolves to a valid state...
                            Dim v As New clsVariable
                            v.Type = clsVariable.VariableTypeEnum.Text
                            v.SetToExpression(Value)
                            If v.StringValue IsNot Nothing AndAlso PossibleValues.Contains(v.StringValue) Then
                                sStringData = New Description(v.StringValue)
                            Else
                                Throw New Exception("'" & Value & "' is not a valid state.")
                            End If
                        End If
                    Case PropertyTypeEnum.ValueList
                        If iLoading > 0 OrElse Value Is Nothing OrElse ValueList.ContainsKey(Value) OrElse ValueList.ContainsValue(SafeInt(Value)) Then
                            If ValueList.ContainsKey(Value) Then
                                iIntData = ValueList(Value)
                            Else
                                iIntData = SafeInt(Value)
                            End If
                        ElseIf ValueList.Count > 0 Then
                            ' Perhaps it's an expression that resolves to a valid state...
                            Dim v As New clsVariable
                            v.Type = clsVariable.VariableTypeEnum.Text
                            v.SetToExpression(Value)
                            If v.StringValue IsNot Nothing AndAlso ValueList.ContainsKey(v.StringValue) Then
                                iIntData = ValueList(v.StringValue)
                            Else
                                Throw New Exception("'" & Value & "' is not a valid state.")
                            End If
                        End If
                    Case PropertyTypeEnum.ObjectKey, PropertyTypeEnum.CharacterKey, PropertyTypeEnum.LocationKey, PropertyTypeEnum.LocationGroupKey
                        sStringData = New Description(Value)
                    Case PropertyTypeEnum.Text
                        sStringData = New Description(Value)
                    Case PropertyTypeEnum.Integer
                        If IsNumeric(Value) Then
                            iIntData = SafeInt(Value)
                        Else
                            Dim var As New clsVariable
                            var.Type = clsVariable.VariableTypeEnum.Numeric
                            var.SetToExpression(Value)
                            iIntData = var.IntValue
                        End If
                End Select
            Catch ex As Exception
                ErrMsg("Error Setting Property " & Description & " to """ & Value & """", ex)
            End Try
        End Set
    End Property

    Public Function Copy() As clsProperty

        Dim p As New clsProperty

        With p
            .arlStates = Me.arlStates.Clone
            .ValueList.Clear()
            For Each sLabel As String In Me.ValueList.Keys
                .ValueList.Add(sLabel, Me.ValueList(sLabel))
            Next
            .DependentKey = Me.DependentKey
            .DependentValue = Me.DependentValue
            .RestrictProperty = Me.RestrictProperty
            .RestrictValue = Me.RestrictValue
            .Description = Me.Description
            .IntData = Me.IntData
            .Key = Me.Key
            .Mandatory = Me.Mandatory
            .Selected = Me.Selected
            .StringData = Me.StringData.Copy
            .Type = Me.Type
            .PropertyOf = Me.PropertyOf
            .GroupOnly = Me.GroupOnly
            .FromGroup = Me.FromGroup
            Select Case .Type
                Case PropertyTypeEnum.ObjectKey, PropertyTypeEnum.CharacterKey, PropertyTypeEnum.LocationKey, PropertyTypeEnum.LocationGroupKey, PropertyTypeEnum.Text, PropertyTypeEnum.ValueList
                    ' These will all re-write StringData, so we can ignore
                Case Else
                    .Value = Me.Value
            End Select
            .AppendToProperty = Me.AppendToProperty
        End With

        Return p

    End Function


    Public Shadows Function ToString() As String
        Return Me.Description & " (" & Me.Value & ")"
    End Function

    Public Sub New()
        Me.StringData = New Description
    End Sub

    Public Overrides ReadOnly Property CommonName() As String
        Get
            Return Description
        End Get
    End Property


    Friend Overrides ReadOnly Property AllDescriptions() As System.Collections.Generic.List(Of SharedModule.Description)
        Get
            Dim all As New Generic.List(Of Description)
            all.Add(Me.StringData)
            Return all
        End Get
    End Property


    Friend Overrides Function FindStringLocal(sSearchString As String, Optional sReplace As String = Nothing, Optional bFindAll As Boolean = True, Optional ByRef iReplacements As Integer = 0) As Object
        Dim iCount As Integer = iReplacements
        iReplacements += MyBase.FindStringInStringProperty(Me.sDescription, sSearchString, sReplace, bFindAll)
        Return iReplacements - iCount
    End Function


    Public Overrides Sub EditItem()
#If Generator Then
        Dim fProperty As New frmProperty(Me, True)
#End If
    End Sub


    Public Overrides Function ReferencesKey(ByVal sKey As String) As Integer
        Dim iCount As Integer = 0
        If Me.DependentKey = sKey Then iCount += 1
        If Me.RestrictProperty = sKey Then iCount += 1
        Return iCount
    End Function


    Public Overrides Function DeleteKey(ByVal sKey As String) As Boolean
        If Me.DependentKey = sKey Then Me.DependentKey = Nothing
        If Me.RestrictProperty = sKey Then Me.RestrictProperty = Nothing
        Return True
    End Function

End Class
