Public MustInherit Class clsItem

    Private sKey As String
    Public Property Key() As String
        Get
            Return sKey
        End Get
        Set(ByVal Value As String)
            'If Not KeyExists(Value) Then
            sKey = Value ' Need to be able to copy items, requires having 2 objects with same key
            'Else
            'Throw New Exception("Key " & Value & " already exists")
            '("Here")
            'End If
        End Set
    End Property


    Private bIsLibrary As Boolean
    Public Property IsLibrary() As Boolean
        Get
            Return bIsLibrary
        End Get
        Set(ByVal value As Boolean)
            bIsLibrary = value
        End Set
    End Property



    Public Function GetNewKey() As String

        Dim sType As String = ""
        Select Case True
            Case TypeOf Me Is clsLocation
                sType = "Location"
            Case TypeOf Me Is clsObject
                sType = "Object"
            Case TypeOf Me Is clsTask
                sType = "Task"
            Case TypeOf Me Is clsEvent
                sType = "Event"
            Case TypeOf Me Is clsCharacter
                sType = "Character"
            Case TypeOf Me Is clsVariable
                sType = "Variable"
            Case TypeOf Me Is clsALR
                sType = "ALR"
            Case TypeOf Me Is clsGroup
                sType = "Group"
            Case TypeOf Me Is clsHint
                sType = "Hint"
            Case TypeOf Me Is clsProperty
                sType = "Property"
            Case Else
                TODO("Other types")
        End Select

        If sType <> "" Then
            sKey = Adventure.GetNewKey(sType)
            Return sKey
        Else
            Return Nothing
        End If

    End Function


    Private dtCreated As Date = Date.MinValue
    Friend Property Created() As Date
        Get            
            If dtCreated = Date.MinValue Then
                If dtLastUpdated < Now AndAlso dtLastUpdated > Date.MinValue Then
                    dtCreated = dtLastUpdated
                Else
                    dtCreated = Now
                End If
            End If
            Return dtCreated
        End Get
        Set(ByVal value As Date)
            dtCreated = value
        End Set
    End Property


    Private dtLastUpdated As Date
    Friend Property LastUpdated() As Date
        Get
            If dtLastUpdated > Date.MinValue Then
                Return dtLastUpdated
            Else
                Return Now
            End If
        End Get
        Set(ByVal value As Date)
            dtLastUpdated = value
        End Set
    End Property


    Public MustOverride ReadOnly Property CommonName() As String
    Public MustOverride ReadOnly Property Clone() As clsItem
    Friend MustOverride ReadOnly Property AllDescriptions() As Generic.List(Of Description)

    Public MustOverride Sub EditItem()

    Public MustOverride Function ReferencesKey(ByVal sKey As String) As Integer
    Public MustOverride Function DeleteKey(ByVal sKey As String) As Boolean
    Friend MustOverride Function FindStringLocal(ByVal sSearchString As String, Optional ByVal sReplace As String = Nothing, Optional ByVal bFindAll As Boolean = True, Optional ByRef iReplacements As Integer = 0) As Object


    Public Function SearchFor(ByVal sSearchString As String) As Boolean
        Dim oSearch As Object = FindString(sSearchString, , False)
        If TypeOf oSearch Is SingleDescription Then
            Return True
        Else
            Return CInt(oSearch) > 0
        End If
        'Return FindString(sSearchString, , False) IsNot Nothing
    End Function


    Public Function FindString(ByVal sSearchString As String, Optional ByVal sReplace As String = Nothing, Optional ByVal bFindAll As Boolean = True, Optional ByRef iReplacements As Integer = 0) As Object

        Dim sCommonName As String = Me.CommonName
        Try
            For Each desc As Description In AllDescriptions
                Dim o As Object = FindStringInDescription(desc, sSearchString, sReplace, bFindAll, iReplacements)
                If o IsNot Nothing AndAlso Not bFindAll Then Return o
            Next
            Return FindStringLocal(sSearchString, sReplace, bFindAll, iReplacements)
#If False Then
            For Each p As System.Reflection.PropertyInfo In Me.GetType.GetProperties(Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.Instance)
                Select Case True
                    Case p.PropertyType Is GetType(String)
                        Try
                            If p.CanWrite Then
                                If Not p.Name.ToLower.Contains("key") Then
                                    Dim params() As System.Reflection.ParameterInfo = p.GetIndexParameters()
                                    If params.Length = 0 Then
                                        Dim sValue As String = SafeString(p.GetValue(Me, Nothing))
                                        If FindText(sValue, sSearchString) Then
                                            If sReplace IsNot Nothing Then p.SetValue(Me, ReplaceString(sValue, sSearchString, sReplace, iReplacements), Nothing)
                                            If Not bFindAll Then Return sValue
                                        End If
                                    End If
                                End If
                            End If
                        Catch
                        End Try
                    Case p.PropertyType Is GetType(StringArrayList)
                        Try
                            If p.CanWrite Then
                                Dim params() As System.Reflection.ParameterInfo = p.GetIndexParameters()
                                If params.Length = 0 Then
                                    Dim arlValue As StringArrayList = CType(p.GetValue(Me, Nothing), StringArrayList)
                                    For i As Integer = arlValue.Count - 1 To 0 Step -1
                                        Dim sValue As String = arlValue(i)
                                        If FindText(sValue, sSearchString) Then
                                            If sReplace IsNot Nothing Then arlValue(i) = ReplaceString(sValue, sSearchString, sReplace, iReplacements)
                                            If Not bFindAll Then Return sValue
                                        End If
                                    Next
                                End If
                            End If
                        Catch
                        End Try
                End Select
            Next
#End If
        Catch ex As Exception
            ErrMsg("Error finding string " & sSearchString & " in item " & CommonName, ex)
        Finally
#If Generator Then
            If sCommonName <> Me.CommonName Then UpdateListItem(Me.Key, Me.CommonName)
#End If
        End Try

        Return Nothing

    End Function


    Private Function FindText(ByVal sTextToSearch As String, ByVal sTextToFind As String) As Boolean

        If sTextToSearch Is Nothing Then Return False

        Dim re As System.Text.RegularExpressions.Regex
        Dim sWordBound As String = CStr(IIf(SearchOptions.bFindExactWord, "\b", ""))
        sTextToFind = sTextToFind.Replace("\", "\\").Replace("*", ".*").Replace("?", "\?").Replace("[", "\[").Replace("]", "\]").Replace("(", "\(").Replace(")", "\)").Replace(".", "\.")
        If SearchOptions.bSearchMatchCase Then
            re = New System.Text.RegularExpressions.Regex(sWordBound & sTextToFind & sWordBound)
        Else
            re = New System.Text.RegularExpressions.Regex(sWordBound & sTextToFind & sWordBound, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        End If

        Return re.IsMatch(sTextToSearch)

    End Function


    Friend Function FindStringInStringProperty(ByRef text As String, ByVal sSearchString As String, Optional ByVal sReplace As String = Nothing, Optional ByVal bFindAll As Boolean = True) As Integer

        If FindText(text, sSearchString) Then
            Dim iReplacements As Integer = 0
            If sReplace IsNot Nothing Then
                text = ReplaceString(text, sSearchString, sReplace, iReplacements)
            Else
                iReplacements = 1
            End If
            Return iReplacements
        End If

        Return Nothing

    End Function


    Friend Function FindStringInDescription(ByVal d As Description, ByVal sSearchString As String, Optional ByVal sReplace As String = Nothing, Optional ByVal bFindAll As Boolean = True, Optional ByRef iReplacements As Integer = 0) As SingleDescription

        For Each sd As SingleDescription In d
            If FindText(sd.Description, sSearchString) Then ' sd.Description.Contains(sSearchString) Then
                If sReplace IsNot Nothing Then sd.Description = ReplaceString(sd.Description, sSearchString, sReplace, iReplacements)
                If Not bFindAll Then Return sd
            End If
            For Each r As clsRestriction In sd.Restrictions
                If r.oMessage IsNot Nothing Then
                    Dim sdr As SingleDescription = FindStringInDescription(r.oMessage, sSearchString, sReplace, bFindAll, iReplacements)
                    If sdr IsNot Nothing AndAlso Not bFindAll Then Return sdr
                End If
            Next
        Next
        Return Nothing

    End Function


    Private Function ReplaceString(ByRef sText As String, ByVal sFind As String, ByVal sReplace As String, ByRef iReplacements As Integer) As String

        'Return re.IsMatch(sTextToSearch)

        'While sText.Contains(sFind)
        '    sText = Replace(sText, sFind, sReplace, , 1)
        '    iReplacements += 1
        'End While
        'Dim iStart As Integer = 0
        'Dim iLast As Integer = -1
        'Dim comp As System.StringComparison = StringComparison.CurrentCultureIgnoreCase
        'If SearchOptions.bSearchMatchCase Then comp = StringComparison.CurrentCulture
        'While iStart <> iLast AndAlso iStart > -1
        '    iLast = iStart
        '    iStart = sText.IndexOf(sFind, iStart, comp)
        '    If iStart > -1 AndAlso iStart <> iLast Then iReplacements += 1
        'End While

        'sText = sText.Replace(sFind, sReplace)
        Dim re As System.Text.RegularExpressions.Regex
        Dim sWordBound As String = CStr(IIf(SearchOptions.bFindExactWord, "\b", ""))
        sFind = sFind.Replace("\", "\\").Replace("*", ".*").Replace("?", "\?")
        If SearchOptions.bSearchMatchCase Then
            re = New System.Text.RegularExpressions.Regex(sWordBound & sFind & sWordBound)
        Else
            re = New System.Text.RegularExpressions.Regex(sWordBound & sFind & sWordBound, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        End If
        iReplacements += re.Matches(sText).Count
        sText = re.Replace(sText, sReplace)

        Return sText

    End Function


    Public Function SearchAndReplace(ByVal sFind As String, ByVal sReplace As String) As Integer

        Dim iReplacements As Integer = 0
        FindString(sFind, sReplace, True, iReplacements)
        Return iReplacements

    End Function

End Class


Public MustInherit Class clsItemWithProperties
    Inherits clsItem

    ' These are the properties that belong to the item
    Private _htblActualProperties As New PropertyHashTable
    Friend Property htblActualProperties As PropertyHashTable
        Get
            Return _htblActualProperties
        End Get
        Set(value As PropertyHashTable)
            _htblActualProperties = value
            'bCalculatedGroups = False
            _htblProperties = Nothing ' To Ensure any subsequent calls to htblProperties doesn't take stale values
        End Set
    End Property

    ' Any properties inherited from the group/class
    Private _htblInheritedProperties As PropertyHashTable
    Private Property htblInheritedProperties As PropertyHashTable
        Get
            If _htblInheritedProperties Is Nothing Then
                _htblInheritedProperties = New PropertyHashTable
                For Each grp As clsGroup In Adventure.htblGroups.Values
                    If grp.GroupType = PropertyGroupType Then
                        If grp.arlMembers.Contains(Key) Then
                            For Each prop As clsProperty In grp.htblProperties.Values
                                If Not _htblInheritedProperties.ContainsKey(prop.Key) Then _htblInheritedProperties.Add(prop.Copy)
                                With _htblInheritedProperties(prop.Key)
                                    .Value = prop.Value
                                    .StringData = prop.StringData.Copy
                                    .FromGroup = True
                                End With
                            Next
                        End If
                    End If
                Next
            End If
            Return _htblInheritedProperties
        End Get
        Set(value As PropertyHashTable)
            _htblInheritedProperties = value
            _htblProperties = Nothing
        End Set
    End Property

    Protected MustOverride ReadOnly Property PropertyGroupType() As clsGroup.GroupTypeEnum


    ' Set this to False whenever the groups change
    'Friend bCalculatedGroups As Boolean = False

   
    ' This is a view of Actual + Inherited properties for the item
    ' If both lists have the same property, inherited one should take precendence if it has a value
    ' If it doesn't have a value, item property should take precendence
    '
    ' We can cache a view of the properties.  But if we add/delete any we need to recalc
    ' 
    Private _htblProperties As PropertyHashTable
    Friend ReadOnly Property htblProperties As PropertyHashTable
        Get
            If _htblProperties Is Nothing Then
                ' Need a shallow clone of actual properties (so we have unique list of original properties)
                _htblProperties = New PropertyHashTable
                For Each prop As clsProperty In _htblActualProperties.Values
                    _htblProperties.Add(prop)
                Next

                ' Take all actual properties, then layer on the inherited ones
                For Each prop As clsProperty In htblInheritedProperties.Values
                    If Not HasProperty(prop.Key) Then
                        _htblProperties.Add(prop.Copy)
                    Else
                        ' We have property in both actual and inherited.  Check what we want to do here...
                        With _htblProperties(prop.Key)
                            .Value = prop.Value
                            .StringData = prop.StringData.Copy
                            .FromGroup = True
                        End With
                    End If
                Next
            End If
            Return _htblProperties
        End Get
    End Property


    ' Required if we do an action that changes the properties of the object, such as add/remove from a group
    Friend Sub ResetInherited()
        _htblInheritedProperties = Nothing
        _htblProperties = Nothing
    End Sub

    'Friend Function RecalculateProperties() As PropertyHashTable

    '    Dim htblProp As PropertyHashTable = htblActualProperties.Clone
    '    For Each grp As clsGroup In Adventure.htblGroups.Values
    '        If grp.GroupType = PropertyGroupType Then
    '            If grp.arlMembers.Contains(Key) Then
    '                For Each prop As clsProperty In grp.htblProperties.Values
    '                    If Not htblProp.ContainsKey(prop.Key) Then htblProp.Add(prop.Copy)
    '                    With htblProp(prop.Key)
    '                        .Value = prop.Value
    '                        .StringData = prop.StringData.Copy
    '                        .FromGroup = True
    '                    End With
    '                Next
    '            End If
    '        End If
    '    Next

    '    ' Copy existing values back
    '    If m_htblProperties IsNot Nothing Then
    '        For Each p As clsProperty In m_htblProperties.Values
    '            If htblProp.ContainsKey(p.Key) Then
    '                htblProp(p.Key).Value = p.Value(True)
    '                htblProp(p.Key).StringData = p.StringData.Copy
    '            End If
    '        Next
    '    End If

    '    Return htblProp

    'End Function

    Friend Function GetProperty(ByVal sPropertyKey As String) As clsProperty
        Return htblProperties(sPropertyKey)
    End Function


    Friend Function GetPropertyValue(ByVal sPropertyKey As String) As String
        If HasProperty(sPropertyKey) Then
            Return htblProperties(sPropertyKey).Value
        Else
            Return Nothing
        End If
        '        Dim lhtblProperties As PropertyHashTable
        '#If Runner Then
        '        lhtblProperties = htblProperties
        '#Else
        '        lhtblProperties = htblActualProperties
        '#End If
        '        If lHasProperty(sPropertyKey) Then
        '            Return lhtblProperties(sPropertyKey).Value
        '        Else
        '            Return Nothing
        '        End If
    End Function


    Friend Sub SetPropertyValue(ByVal sPropertyKey As String, ByVal StringData As Description)
        AddProperty(sPropertyKey)
        htblProperties(sPropertyKey).StringData = StringData
    End Sub


    Friend Sub SetPropertyValue(ByVal sPropertyKey As String, ByVal sValue As String)
        '        Dim lhtblProperties As PropertyHashTable
        '#If Runner Then
        '        If HasProperty(sPropertyKey) Then
        '            lhtblProperties = htblProperties
        '        Else
        '            lhtblProperties = htblActualProperties
        '            bCalculatedGroups = False
        '        End If
        '#Else
        '        lhtblProperties = htblActualProperties
        '#End If
        '        If Not lHasProperty(sPropertyKey) Then
        '            If Adventure.htblAllProperties.ContainsKey(sPropertyKey) Then
        '                Dim p As clsProperty = Adventure.htblAllProperties(sPropertyKey).Copy
        '                lhtblProperties.Add(p)
        '            End If
        '        End If

        '        lhtblProperties(sPropertyKey).Value = sValue
        'AddProperty(sPropertyKey)
        AddProperty(sPropertyKey)
        htblProperties(sPropertyKey).Value = sValue
    End Sub


    Friend Sub SetPropertyValue(ByVal sPropertyKey As String, ByVal bValue As Boolean)
        '        Dim lhtblProperties As PropertyHashTable
        '#If Runner Then
        '        If HasProperty(sPropertyKey) Then
        '            lhtblProperties = htblProperties
        '        Else
        '            lhtblProperties = htblActualProperties
        '            bCalculatedGroups = False
        '        End If
        '#Else
        '        lhtblProperties = htblActualProperties
        '#End If
        '        If bValue Then
        '            If Not lHasProperty(sPropertyKey) Then
        '                If Adventure.htblAllProperties.ContainsKey(sPropertyKey) Then
        '                    Dim p As clsProperty = Adventure.htblAllProperties(sPropertyKey).Copy
        '                    p.Selected = True
        '                    lhtblProperties.Add(p)
        '                End If
        '            End If
        '        Else
        '            If lHasProperty(sPropertyKey) Then lhtblProperties.Remove(sPropertyKey)
        '        End If

        ' Add/Remove the property from our collection
        If bValue Then
            AddProperty(sPropertyKey)
            htblProperties(sPropertyKey).Selected = True
        Else
            RemoveProperty(sPropertyKey)
        End If        

    End Sub


    Friend Function HasProperty(ByVal sPropertyKey As String) As Boolean
        Return htblProperties.ContainsKey(sPropertyKey)
        '        Dim lhtblProperties As PropertyHashTable
        '#If Runner Then
        '        lhtblProperties = htblProperties
        '#Else
        '        lhtblProperties = htblActualProperties
        '#End If
        '        Return lHasProperty(sPropertyKey)
    End Function


    '    Friend Function RemoveProperty(ByVal sPropertyKey As String) As Boolean
    '        Dim lhtblProperties As PropertyHashTable
    '#If Runner Then
    '        lhtblProperties = htblProperties
    '#Else
    '        lhtblProperties = htblActualProperties
    '#End If
    '        If lHasProperty(sPropertyKey) Then lhtblProperties.Remove(sPropertyKey)
    '    End Function
    Friend Sub RemoveProperty(ByVal sPropertyKey As String)
        If _htblActualProperties.ContainsKey(sPropertyKey) Then
            _htblActualProperties.Remove(sPropertyKey)
            _htblProperties = Nothing
        End If
    End Sub

    Friend Sub AddProperty(ByVal prop As clsProperty, Optional ByVal bActualProperties As Boolean = True)
        If HasProperty(prop.Key) Then RemoveProperty(prop.Key)
        'With htblProperties(prop.Key)
        '    .Value = prop.Value
        '    .StringData = prop.StringData.Copy                
        'End With            
        'Else
        If bActualProperties Then
            _htblActualProperties.Add(prop)
        Else
            _htblInheritedProperties.Add(prop)
        End If
        'End If
        _htblProperties = Nothing
    End Sub


    Friend Sub AddProperty(ByVal sPropertyKey As String, Optional ByVal bActualProperties As Boolean = True)
        If Not HasProperty(sPropertyKey) Then
            Dim p As clsProperty = Adventure.htblAllProperties(sPropertyKey).Copy
            If p Is Nothing Then Throw New Exception("Property " & sPropertyKey & " does not exist!")
            AddProperty(p, bActualProperties)
            'SetPropertyValue(sPropertyKey, sValue)
        End If
    End Sub

End Class