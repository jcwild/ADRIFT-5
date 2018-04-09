Public Class clsHint
    Inherits clsItem

    'Private sKey As String
    Private sQuestion As String
    Private oSubtleHint As Description
    Private oSledgeHammerHint As Description
    Friend arlRestrictions As New RestrictionArrayList


    Public Sub New()
        oSubtleHint = New Description
        oSledgeHammerHint = New Description
    End Sub


    'Public Property Key() As String
    '    Get
    '        Return sKey
    '    End Get
    '    Set(ByVal Value As String)
    '        If Not KeyExists(Value) Then
    '            sKey = Value
    '        Else
    '            Throw New Exception("Key " & sKey & " already exists")
    '        End If
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
    Public Overrides Function DeleteKey(ByVal sKey As String) As Boolean

        For Each d As Description In AllDescriptions
            If Not d.DeleteKey(sKey) Then Return False
        Next
        If Not arlRestrictions.DeleteKey(sKey) Then Return False

        Return (True)

    End Function


    Public Property Question() As String
        Get
            Return sQuestion
        End Get
        Set(ByVal Value As String)
            sQuestion = Value
        End Set
    End Property

    Friend Property SubtleHint() As Description
        Get
            Return oSubtleHint
        End Get
        Set(ByVal Value As Description)
            oSubtleHint = Value
        End Set
    End Property

    Friend Property SledgeHammerHint() As Description
        Get
            Return oSledgeHammerHint
        End Get
        Set(ByVal Value As Description)
            oSledgeHammerHint = Value
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

    Public Overrides ReadOnly Property Clone() As clsItem
        Get
            Return CType(Me.MemberwiseClone, clsHint)
        End Get
    End Property

    Public Overrides ReadOnly Property CommonName() As String
        Get
            Return Question
        End Get
    End Property


    Friend Overrides ReadOnly Property AllDescriptions() As System.Collections.Generic.List(Of SharedModule.Description)
        Get
            Dim all As New Generic.List(Of Description)
            all.Add(SledgeHammerHint)
            all.Add(SubtleHint)
            Return all
        End Get
    End Property


    Friend Overrides Function FindStringLocal(sSearchString As String, Optional sReplace As String = Nothing, Optional bFindAll As Boolean = True, Optional ByRef iReplacements As Integer = 0) As Object
        Dim iCount As Integer = iReplacements
        iReplacements += MyBase.FindStringInStringProperty(Me.sQuestion, sSearchString, sReplace, bFindAll)
        Return iReplacements - iCount
    End Function


    Public Overrides Sub EditItem()
#If Generator Then
        Dim fHint As New frmHint(Me, True)
#End If
    End Sub

    Public Overrides Function ReferencesKey(ByVal sKey As String) As Integer

    End Function

End Class
