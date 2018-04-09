Public Class clsFolder
    Inherits clsItem

    Public Shared Event MembersChanged(ByVal sender As Object, ByVal e As EventArgs)

    Public Class MemberList
        Inherits Generic.List(Of String)

        Public Shared Event MembersChanged(ByVal sender As Object, ByVal e As EventArgs)

        Public Overloads Sub Add(ByVal item As String)
            MyBase.Add(item)
            If iLoading = 0 Then RaiseEvent MembersChanged(Me, New EventArgs)
        End Sub

        Public Overloads Sub Remove(ByVal item As String)
            MyBase.Remove(item)
            RaiseEvent MembersChanged(Me, New EventArgs)
        End Sub

        Public Overloads Sub RemoveAt(ByVal index As Integer)
            MyBase.RemoveAt(index)
            RaiseEvent MembersChanged(Me, New EventArgs)
        End Sub

        Public Overloads Sub Insert(ByVal index As Integer, ByVal item As String)
            MyBase.Insert(index, item)
            RaiseEvent MembersChanged(Me, New EventArgs)
        End Sub

    End Class

    Public Name As String
    Public WithEvents Members As New MemberList ' Generic.List(Of String)
    Public Expanded As Boolean = False
    Public ViewType As Infragistics.Win.UltraWinListView.UltraListViewStyle = Infragistics.Win.UltraWinListView.UltraListViewStyle.Details
    Public SortColumn As Integer = -1
    Public SortDirection As Infragistics.Win.UltraWinListView.Sorting = Infragistics.Win.UltraWinListView.Sorting.None
    Public GroupBy As Integer = 0
    Public GroupDirection As Infragistics.Win.UltraWinListView.Sorting = Infragistics.Win.UltraWinListView.Sorting.None
    Public Size As Size
    Public Location As Point = New Point(-100, -100)
    Public Event ColumnChanged(ByVal sender As Object, ByVal iCol As Integer, ByVal bVisible As Boolean)
    Public Visible As Boolean = False

    Public bShowCreatedDate As Boolean = False
    Public Property ShowCreatedDate() As Boolean
        Get
            Return bShowCreatedDate
        End Get
        Set(ByVal value As Boolean)
            bShowCreatedDate = value
            RaiseEvent ColumnChanged(Me, 0, value)
        End Set
    End Property
    Public bShowModifiedDate As Boolean = False
    Public Property ShowModifiedDate() As Boolean
        Get
            Return bShowModifiedDate
        End Get
        Set(ByVal value As Boolean)
            bShowModifiedDate = value
            RaiseEvent ColumnChanged(Me, 1, value)
        End Set
    End Property
    Public bShowType As Boolean = False
    Public Property ShowType() As Boolean
        Get
            Return bShowType
        End Get
        Set(ByVal value As Boolean)
            bShowType = value
            RaiseEvent ColumnChanged(Me, 2, value)
        End Set
    End Property
    Public bShowKey As Boolean = False
    Public Property ShowKey() As Boolean
        Get
            Return bShowKey
        End Get
        Set(ByVal value As Boolean)
            bShowKey = value
            RaiseEvent ColumnChanged(Me, 3, value)
        End Set
    End Property
    Public bShowPriority As Boolean = False
    Public Property ShowPriority() As Boolean
        Get
            Return bShowPriority
        End Get
        Set(ByVal value As Boolean)
            bShowPriority = value
            RaiseEvent ColumnChanged(Me, 4, value)
        End Set
    End Property

    Public Overrides Function DeleteKey(ByVal sKey As String) As Boolean
        If Members.Contains(sKey) Then Members.Remove(sKey)
        Return True
    End Function


    Friend Overrides ReadOnly Property AllDescriptions() As System.Collections.Generic.List(Of SharedModule.Description)
        Get
            Return New Generic.List(Of SharedModule.Description)
        End Get
    End Property


    Friend Overrides Function FindStringLocal(sSearchString As String, Optional sReplace As String = Nothing, Optional bFindAll As Boolean = True, Optional ByRef iReplacements As Integer = 0) As Object
        ' Name
    End Function

    Public Overrides ReadOnly Property CommonName() As String
        Get
            Return Name
        End Get
    End Property

    Public Overrides Sub EditItem()

    End Sub


    ' Is this folder sKey, or does it contain sKey in any subfolder
    Public Function ContainsKey(ByVal sKey As String, Optional ByVal bRecursive As Boolean = True) As Boolean
        If Key = sKey Then Return True
        If Members.Contains(sKey) Then Return True

        If bRecursive Then
            For Each sMember As String In Members
                If Adventure.dictFolders.ContainsKey(sMember) Then
                    If Adventure.dictFolders(sMember).ContainsKey(sKey) Then Return True
                End If
            Next
        End If

        Return False

    End Function


    Public Sub New(Optional ByVal sKey As String = "")
        If Adventure Is Nothing Then Exit Sub
        If sKey = "" Then
            Key = Me.GetNewKey ' Adventure.GetNewKey("Folder")
        Else
            Key = sKey
        End If

        Name = "New Folder"
        Expanded = True
    End Sub

    Public Overrides ReadOnly Property Clone() As clsItem
        Get
            Return CType(Me.MemberwiseClone, clsFolder)
        End Get
    End Property


    Public Overrides Function ReferencesKey(ByVal sKey As String) As Integer
        Return 0
    End Function

    Private Sub Members_MembersChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Members.MembersChanged
        RaiseEvent MembersChanged(Me, e)
    End Sub

End Class
