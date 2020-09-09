Imports System.Xml
Imports System.Drawing

Module mdlRunner

#If Not www Then
    Public fRunner As frmRunner
#End If

    Private _UserSession As RunnerSession
    Public Property UserSession As RunnerSession
        Get
#If www Then
            If HttpContext.Current.Session Is Nothing Then Return Nothing
            Return CType(HttpContext.Current.Session.Item("RunnerSession"), RunnerSession)
#Else
            Return _UserSession
#End If
        End Get
        Set(value As RunnerSession)
#If www Then
            HttpContext.Current.Session.Item("RunnerSession") = value
#Else
            _UserSession = value
#End If
        End Set
    End Property


    ' This is pretty cool - it gives us a Strongly Typed Arraylist, but the arraylist is
    ' actually hidden beneath a hashtable layer so we can index it any way we want.
    '
    Friend Class AutoCompleteSortedArrayList
        Inherits Generic.List(Of AutoComplete) ' ArrayList

        ' We want to store values by arbritray key, so need a hashtable to lookup the index in the arraylist
        Private htblIndexLookup As New Hashtable

        Public Shadows Sub Add(ByVal ac As AutoComplete)
            MyBase.Add(ac)
            htblIndexLookup.Add(ac.sWord, MyBase.Count - 1)
        End Sub

        Public Shadows Sub Remove(ByVal key As String)
            MyBase.RemoveAt(CInt(htblIndexLookup(key)))
            htblIndexLookup.Remove(key)
        End Sub

        Public Shadows Sub Clear()
            MyBase.Clear()
            htblIndexLookup.Clear()
        End Sub

        Public ReadOnly Property ItemByIndex(ByVal index As Integer) As AutoComplete
            Get
                Dim sKey As String = GetKeyFromIndex(index)
                Return Item(sKey)
            End Get
        End Property

        Default Public Shadows Property Item(ByVal key As String) As AutoComplete
            Get
                Return CType(MyBase.Item(CInt(htblIndexLookup(key))), AutoComplete)
            End Get
            Set(ByVal value As AutoComplete)
                MyBase.Item(CInt(htblIndexLookup(key))) = value
            End Set
        End Property

        Public Function ContainsKey(ByVal key As String) As Boolean
            Return htblIndexLookup.ContainsKey(key)
        End Function

        Public Function GetKeyFromIndex(ByVal index As Integer) As String
            Return CType(MyBase.Item(index), AutoComplete).sWord
        End Function

        Public Shadows Sub Sort()

            MyBase.Sort()
            htblIndexLookup.Clear()
            For i As Integer = 0 To MyBase.Count - 1
                htblIndexLookup.Add(CType(MyBase.Item(i), AutoComplete).sWord, i)
            Next

        End Sub

    End Class

    Friend Class AutoComplete
        'Implements IComparable
        Implements IComparable(Of AutoComplete)

        Public sWord As String
        Public iPriority As Integer = Integer.MaxValue
        Friend htblChildren As New AutoCompleteSortedArrayList ' Hashtable

        Public salTasks As New StringArrayList

        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal sWord As String)
            MyBase.New()
            Me.sWord = sWord
        End Sub

        ' Order these by:
        '   Auto-complete priority
        '   Most common (i.e. most children)
        '   Longest word (if same task)
        '   Name
        ' Order these by most children, so most common words appear first
        Public Function CompareTo(ByVal ac As AutoComplete) As Integer Implements System.IComparable(Of AutoComplete).CompareTo
            If iPriority <> ac.iPriority Then
                Return iPriority.CompareTo(ac.iPriority) ' ac.iPriority.CompareTo(iPriority)
            Else
                If salTasks.Count = ac.salTasks.Count Then
                    If sWord.Length = ac.sWord.Length Then
                        Return sWord.CompareTo(ac.sWord)
                    Else
                        Return ac.sWord.Length.CompareTo(sWord.Length)
                    End If
                Else
                    Return ac.salTasks.Count.CompareTo(salTasks.Count)
                End If
            End If
        End Function

    End Class

    Public Class clsSingleItem
        Public Sub New()
            Me.MatchingPossibilities = New StringArrayList
        End Sub
        Public Sub New(ByVal sKey As String)
            Me.new()
            MatchingPossibilities.Add(sKey)
        End Sub

        Public MatchingPossibilities As StringArrayList
        Public bExplicitlyMentioned As Boolean
        Public sCommandReference As String
    End Class

    Friend Class ItemArrayList
        Inherits Generic.List(Of clsSingleItem)

        Shadows Sub Add(ByVal itm As clsSingleItem)
            MyBase.Add(itm)
        End Sub

        'Shadows Sub Remove(ByVal itm As clsSingleItem)
        '    MyBase.Remove(itm)
        'End Sub

        'Default Shadows Property Item(ByVal idx As Integer) As clsSingleItem
        '    Get
        '        Return CType(MyBase.Item(idx), clsSingleItem)
        '    End Get
        '    Set(ByVal Value As clsSingleItem)
        '        MyBase.Item(idx) = Value
        '    End Set
        'End Property

        Shadows Function ContainsKey(ByVal sKey As String) As Boolean
            For iSR As Integer = 0 To MyBase.Count - 1
                If CType(MyBase.Item(iSR), clsSingleItem).MatchingPossibilities.Contains(sKey) Then Return True
            Next
            Return False
        End Function

    End Class

    Friend Class clsNewReference
        Implements ICloneable

        Public sParentTask As String

        Public Function ContainsKey(ByVal sKey As String) As Boolean
            Return Items.ContainsKey(sKey)
        End Function

        Public Sub New(ByRef ReferenceType As ReferencesType)
            Me.Items = New ItemArrayList
            Me.ReferenceType = ReferenceType
            Me.Index = -1
        End Sub

        Public Items As ItemArrayList ' clsSingleItem
        'Public Multiple As Boolean ' This is true if Items.Length > 1
        Public ReferenceType As ReferencesType
        Public Index As Integer
        Public ReferenceMatch As String ' i.e. "object2", "character3" etc.

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function

    End Class

    '		                Subjective Pronoun	Objective Pronoun	Reflective Pronoun	Possesive Pronoun
    '
    '		First Person	I (am)				Me			        Myself			    Mine
    '		Second Person	You (are)			You			        Yourself		    Yours
    '		Third Person	He/She (is)			Him/Her			    Himself/Herself		His/Hers
    '				        It (is)				It			        Itself			    Its
    '				        We (are)			Us			        Ourselves			Our
    '				        They (are)			Them			    Themselves		    Theirs


    Friend Enum PronounEnum As Integer
        None = -1
        Subjective = 0          ' I/You/He/She/It/We/They
        Objective = 1           ' Me/You/Him/Her/It/Us/Them
        Reflective = 2          ' Myself/Yourself/Himself/Herself/Itself/Ourselves/Themselves
        Possessive = 3          ' Mine/Yours/His/Hers/Its/Ours/Theirs
    End Enum


    Friend Enum eScope
        Applicable
        Visible
        Seen
    End Enum


    Friend Enum DebugDetailLevelEnum
        [Error]
        High
        Medium
        Low
    End Enum

    Friend Class PronounInfo
        Public Key As String ' What is the pronoun applying to?
        Public Pronoun As PronounEnum
        Public Offset As Integer ' Where in the command does this substitution take place
        Public Gender As clsCharacter.GenderEnum
    End Class
    Friend Class PronounInfoList
        Inherits List(Of PronounInfo)
        'Implements IComparer '(Of PronounInfo)


        Shadows Sub Add(ByVal sKey As String, ByVal ePronoun As PronounEnum, ByVal Gender As clsCharacter.GenderEnum, ByVal iOffset As Integer)
            Dim pi As New PronounInfo
            pi.Key = sKey
            pi.Pronoun = ePronoun
            pi.Offset = iOffset
            pi.Gender = Gender
            MyBase.Add(pi)

            ' Ensure the list is sorted by offset, for checking previous pronouns
            MyBase.Sort(Function(x, y) x.Offset.CompareTo(y.Offset))
        End Sub


        'Public Function Compare(x As PronounInfo, y As PronounInfo) As Integer Implements System.Collections.Generic.IComparer(Of PronounInfo).Compare
        '    Return x.Offset.CompareTo(y.Offset)
        'End Function

        'Public Function Compare(x As Object, y As Object) As Integer Implements System.Collections.IComparer.Compare
        '    Return CType(x, PronounInfo).Offset.CompareTo(CType(y, PronounInfo).Offset)
        'End Function

    End Class

    Public Function StripCarats(ByVal sText As String) As String
        If sText.Contains("<#") AndAlso sText.Contains("#>") Then
            sText = sText.Replace("<#", "[[==~~").Replace("#>", "~~==]]")
        End If
        Dim re As New System.Text.RegularExpressions.Regex("<(.|\n)*?>")
        Return re.Replace(sText, "").Replace("[[==~~", "<#").Replace("~~==]]", "#>")
    End Function


#If Not www Then
    Public Sub SaveFormPosition(ByVal frmForm As System.Windows.Forms.Form)

        ' Function to record the position and state of a form
        SaveSetting("ADRIFT", "Runner", frmForm.Name & "_State", Format(frmForm.WindowState))

        If frmForm.WindowState = FormWindowState.Normal Then
            SaveSetting("ADRIFT", "Runner", frmForm.Name & "_Top", Format(frmForm.Top))
            SaveSetting("ADRIFT", "Runner", frmForm.Name & "_Left", Format(frmForm.Left))
            SaveSetting("ADRIFT", "Runner", frmForm.Name & "_Height", Format(frmForm.Height))
            SaveSetting("ADRIFT", "Runner", frmForm.Name & "_Width", Format(frmForm.Width))
        End If

    End Sub


#If Mono Then
    Public Sub GetFormPosition(ByRef frmForm As System.Windows.Forms.Form, Optional ByVal utm As Object = Nothing, Optional ByVal udm As Object = Nothing, Optional ByVal bExactPosition As Boolean = False)
#Else
    Public Sub GetFormPosition(ByRef frmForm As System.Windows.Forms.Form, Optional ByVal utm As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager = Nothing, Optional ByVal udm As Infragistics.Win.UltraWinDock.UltraDockManager = Nothing, Optional ByVal bExactPosition As Boolean = False)
#End If

        Dim iState As FormWindowState

        'If rSession.SystemSettingInteger("SuppressWindowMemory", True) <> 0 Then Exit Sub

        ' Function to load the position of a form
        ' What state was it saved in?
        iState = CType(Val(GetSetting("ADRIFT", "Runner", frmForm.Name & "_State", System.Windows.Forms.FormWindowState.Normal.ToString)), FormWindowState)
        Select Case iState
            Case System.Windows.Forms.FormWindowState.Normal ' It was normal or unspecified - so carry on

                Dim iTop As Integer = CInt(GetSetting("ADRIFT", "Runner", frmForm.Name & "_Top", frmForm.Top.ToString))
                Dim iLeft As Integer = CInt(GetSetting("ADRIFT", "Runner", frmForm.Name & "_Left", frmForm.Left.ToString))
                Dim iHeight As Integer = CInt(GetSetting("ADRIFT", "Runner", frmForm.Name & "_Height", frmForm.Height.ToString))
                Dim iWidth As Integer = CInt(GetSetting("ADRIFT", "Runner", frmForm.Name & "_Width", frmForm.Width.ToString))

                If bExactPosition Then frmForm.Location = New Point(iLeft, iTop)
                frmForm.Size = New Size(iWidth, iHeight)

            Case System.Windows.Forms.FormWindowState.Minimized ' It was minimised - so rest of data is rubbish

            Case System.Windows.Forms.FormWindowState.Maximized ' It was maximised - so maximise!
                frmForm.WindowState = System.Windows.Forms.FormWindowState.Maximized

            Case Else ' Err, shouldn't get here
                ErrMsg("GetFormPosition Error")
        End Select

#If Mono Then
        SetWindowStyle(frmForm)
#Else
        SetWindowStyle(frmForm, utm, udm)
#End If

    End Sub
#End If


    Public Sub OutputClicked(ByVal txtInput As System.Windows.Forms.RichTextBox, txtOutput As System.Windows.Forms.RichTextBox, ctxMenu As System.Windows.Forms.ContextMenuStrip, MousePosition As Point, ByVal btnSubmit As System.Windows.Forms.Control, e As System.Windows.Forms.MouseEventArgs)

        Try

            If Not CBool(GetSetting("ADRIFT", "Runner", "EnableMenu", "1")) Then Exit Sub

            ' Grab word clicked on            
            Dim iPos As Integer = txtOutput.GetCharIndexFromPosition(txtOutput.PointToClient(MousePosition))
            Dim sWord As String = ""
            ctxMenu.Items.Clear()

            If iPos >= txtOutput.Text.Length Then iPos = txtOutput.Text.Length - 1 ' For Mono

            Select Case txtOutput.Text(iPos)
                Case "a"c To "z"c, "A"c To "Z"c
                    Dim iStart As Integer = iPos
                    Dim iEnd As Integer = iPos

                    While iStart > 0
                        iStart -= 1
                        Select Case txtOutput.Text(iStart)
                            Case " "c, Chr(13), Chr(10), """"c, "'"c
                                iStart += 1
                                Exit While
                        End Select
                    End While
                    While iEnd < txtOutput.TextLength - 1
                        iEnd += 1
                        Select Case txtOutput.Text(iEnd)
                            Case " "c, "."c, ","c, "!"c, ";"c, ":"c, Chr(13), Chr(10), """"c, "?"c, "'"c
                                Exit While
                        End Select
                    End While
                    If iEnd = txtOutput.TextLength - 1 Then iEnd += 1

                    sWord = txtOutput.Text.Substring(iStart, iEnd - iStart)
                Case Else
            End Select

            If sWord <> "" Then
                If Adventure IsNot Nothing AndAlso Adventure.EnableMenu Then
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If Adventure.Player.CanSeeObject(ob.Key) Then
                            For Each sNoun As String In ob.arlNames
                                If String.Compare(sWord, sNoun, True) = 0 Then
                                    ReDim UserSession.NewReferences(0)
                                    UserSession.NewReferences(0) = New clsNewReference(ReferencesType.Object)
                                    UserSession.NewReferences(0).Items.Add(New clsSingleItem(ob.Key))
                                    For Each t As clsTask In Adventure.htblTasks.Values
                                        If t.TaskType = clsTask.TaskTypeEnum.General AndAlso t.AutoFillPriority > 0 Then
                                            If t.References.Count = 1 AndAlso (t.References(0) = "%object1%" OrElse t.References(0) = "%objects%") Then
                                                If UserSession.PassRestrictions(t.arlRestrictions) Then
                                                    ctxMenu.Items.Add(t.MakeNice.Replace("%object1%", ob.FullName(ArticleTypeEnum.Definite)).Replace("%objects%", ob.FullName(ArticleTypeEnum.Definite)))
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                    For Each ch As clsCharacter In Adventure.htblCharacters.Values
                        If Adventure.Player.CanSeeCharacter(ch.Key) Then
                            Dim bMatch As Boolean = False
                            If String.Compare(sWord, ch.ProperName, True) = 0 Then
                                bMatch = True
                            Else
                                For Each sNoun As String In ch.arlDescriptors
                                    If String.Compare(sWord, sNoun, True) = 0 Then
                                        bMatch = True
                                    End If
                                Next
                            End If
                            If bMatch Then
                                ReDim UserSession.NewReferences(0)
                                UserSession.NewReferences(0) = New clsNewReference(ReferencesType.Character)
                                UserSession.NewReferences(0).Items.Add(New clsSingleItem(ch.Key))
                                For Each t As clsTask In Adventure.htblTasks.Values
                                    If t.TaskType = clsTask.TaskTypeEnum.General AndAlso t.AutoFillPriority > 0 Then
                                        If t.References.Count = 1 AndAlso (t.References(0) = "%character1%" OrElse t.References(0) = "%characters%") Then
                                            If UserSession.PassRestrictions(t.arlRestrictions) Then
                                                ctxMenu.Items.Add(t.MakeNice.Replace("%character1%", ch.Name(PronounEnum.Objective, , , ArticleTypeEnum.Definite)).Replace("%characters%", ch.Name(PronounEnum.Objective, , , ArticleTypeEnum.Definite)))
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Next
                    For Each d As DirectionsEnum In [Enum].GetValues(GetType(DirectionsEnum))
                        If String.Compare(sWord, DirectionName(d), True) = 0 Then
                            ReDim UserSession.NewReferences(0)
                            UserSession.NewReferences(0) = New clsNewReference(ReferencesType.Direction)
                            UserSession.NewReferences(0).Items.Add(New clsSingleItem(d.ToString))
                            For Each t As clsTask In Adventure.htblTasks.Values
                                If t.TaskType = clsTask.TaskTypeEnum.General AndAlso t.AutoFillPriority > 0 Then
                                    If t.References.Count = 1 AndAlso t.References(0) = "%direction%" Then
                                        If UserSession.PassRestrictions(t.arlRestrictions) Then
                                            ctxMenu.Items.Add(t.MakeNice.Replace("%direction%", DirectionName(d)))
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Next
                End If

            Else
                If e.Button = MouseButtons.Right Then
                    If Adventure.EnableMenu Then
                        ctxMenu.Items.Clear()
                        For Each t As clsTask In Adventure.htblTasks.Values
                            If t.TaskType = clsTask.TaskTypeEnum.General AndAlso t.AutoFillPriority > 0 Then
                                If t.References.Count = 0 Then
                                    If UserSession.PassRestrictions(t.arlRestrictions) Then
                                        ctxMenu.Items.Add(t.MakeNice)
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            End If

            If ctxMenu.Items.Count > 0 Then
                If sWord <> "" Then
                    ctxMenu.Items.Insert(0, New ToolStripMenuItem("Type """ & sWord & """"))
                    ctxMenu.Items.Insert(1, New ToolStripSeparator)
                End If
                ctxMenu.Show(MousePosition)
            ElseIf sWord <> "" Then
                txtInput.SelectedText = sWord & " "
                btnSubmit.Visible = True
            End If

        Catch ex As Exception
            ErrMsg("Error building menu", ex)
        End Try

    End Sub


#If False Then
    ' This is pretty cool - it gives us a Strongly Typed Arraylist, but the arraylist is
    ' actually hidden beneath a hashtable layer so we can index it any way we want.
    '
    Private Class AutoCompleteSortedArrayList
        Inherits Generic.List(Of AutoComplete) ' ArrayList

        ' We want to store values by arbritray key, so need a hashtable to lookup the index in the arraylist
        Private htblIndexLookup As New Hashtable

        Public Shadows Sub Add(ByVal ac As AutoComplete)
            MyBase.Add(ac)
            htblIndexLookup.Add(ac.sWord, MyBase.Count - 1)
        End Sub

        Public Shadows Sub Remove(ByVal key As String)
            MyBase.RemoveAt(CInt(htblIndexLookup(key)))
            htblIndexLookup.Remove(key)
        End Sub

        Public Shadows Sub Clear()
            MyBase.Clear()
            htblIndexLookup.Clear()
        End Sub

        Public ReadOnly Property ItemByIndex(ByVal index As Integer) As AutoComplete
            Get
                Dim sKey As String = GetKeyFromIndex(index)
                Return Item(sKey)
            End Get
        End Property

        Default Public Shadows Property Item(ByVal key As String) As AutoComplete
            Get
                Return CType(MyBase.Item(CInt(htblIndexLookup(key))), AutoComplete)
            End Get
            Set(ByVal value As AutoComplete)
                MyBase.Item(CInt(htblIndexLookup(key))) = value
            End Set
        End Property

        Public Function ContainsKey(ByVal key As String) As Boolean
            Return htblIndexLookup.ContainsKey(key)
        End Function

        Public Function GetKeyFromIndex(ByVal index As Integer) As String
            Return CType(MyBase.Item(index), AutoComplete).sWord
        End Function

        Public Shadows Sub Sort()

            MyBase.Sort()
            htblIndexLookup.Clear()
            For i As Integer = 0 To MyBase.Count - 1
                htblIndexLookup.Add(CType(MyBase.Item(i), AutoComplete).sWord, i)
            Next

        End Sub

    End Class


    Private Class AutoComplete
        'Implements IComparable
        Implements IComparable(Of AutoComplete)

        Public sWord As String
        Public iPriority As Integer = Integer.MaxValue
        Public htblChildren As New AutoCompleteSortedArrayList ' Hashtable

        Public salTasks As New StringArrayList

        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal sWord As String)
            MyBase.New()
            Me.sWord = sWord
        End Sub

        ' Order these by:
        '   Auto-complete priority
        '   Most common (i.e. most children)
        '   Longest word (if same task)
        '   Name
        ' Order these by most children, so most common words appear first
        Public Function CompareTo(ByVal ac As AutoComplete) As Integer Implements System.IComparable(Of AutoComplete).CompareTo
            If iPriority <> ac.iPriority Then
                Return iPriority.CompareTo(ac.iPriority) ' ac.iPriority.CompareTo(iPriority)
            Else
                If salTasks.Count = ac.salTasks.Count Then
                    If sWord.Length = ac.sWord.Length Then
                        Return sWord.CompareTo(ac.sWord)
                    Else
                        Return ac.sWord.Length.CompareTo(sWord.Length)
                    End If
                Else
                    Return ac.salTasks.Count.CompareTo(salTasks.Count)
                End If
            End If
        End Function

    End Class


    Public sIt, sHim, sHer, sThem As String
#If Not www Then
    Public Debugger As frmDebugger
#End If
    Public dtDebug As DateTime
    Public iDebugIndent As Integer
    Public bNoDebug As Boolean
    Public iPrepProgress As Integer
    Public States As New StateStack
    Public bAutoComplete As Boolean
    Friend sTranscriptFile As String
    Public iMarginWidth As Integer
    Public bEXE As Boolean = False
    Private listTaskKeys As New Generic.List(Of TaskKey)
    Friend iMatchedTaskCommand As Integer
    Friend dictMacros As New Generic.Dictionary(Of String, clsMacro)
    Friend bShowShortLocations As Boolean = True
    Friend bSystemTask As Boolean = False
    Private root, obroot, chroot As AutoComplete
    Friend salCommands As New StringArrayList
#If Not www Then
    Friend UserSplash As frmUserSplash
#End If
    Friend iPreviousOffset As Integer

    Friend Sub ClearAutoCompletes()
        obroot = Nothing
        chroot = Nothing
    End Sub

    Private Class TaskKey
        Implements IComparable

        Public sTaskKey As String
        Public iPriority As Integer

        Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
            Return Me.iPriority.CompareTo(CType(obj, TaskKey).iPriority)
        End Function
    End Class

    Public Class clsSingleItem
        Public Sub New()
            Me.MatchingPossibilities = New StringArrayList
        End Sub
        Public Sub New(ByVal sKey As String)
            Me.new()
            MatchingPossibilities.Add(sKey)
        End Sub

        Public MatchingPossibilities As StringArrayList
        Public bExplicitlyMentioned As Boolean
        Public sCommandReference As String
    End Class
    Friend Class ItemArrayList
        Inherits ArrayList

        Shadows Sub Add(ByVal itm As clsSingleItem)
            MyBase.Add(itm)
        End Sub

        Shadows Sub Remove(ByVal itm As clsSingleItem)
            MyBase.Remove(itm)
        End Sub

        Default Shadows Property Item(ByVal idx As Integer) As clsSingleItem
            Get
                Return CType(MyBase.Item(idx), clsSingleItem)
            End Get
            Set(ByVal Value As clsSingleItem)
                MyBase.Item(idx) = Value
            End Set
        End Property

        Shadows Function ContainsKey(ByVal sKey As String) As Boolean
            For iSR As Integer = 0 To MyBase.Count - 1
                If CType(MyBase.Item(iSR), clsSingleItem).MatchingPossibilities.Contains(sKey) Then Return True
            Next
            Return False
        End Function

    End Class
    Friend Class clsNewReference
        Implements ICloneable

        Public sParentTask As String

        Public Function ContainsKey(ByVal sKey As String) As Boolean
            Return Items.ContainsKey(sKey)
        End Function

        Public Sub New(ByRef ReferenceType As ReferencesType)
            Me.Items = New ItemArrayList
            Me.ReferenceType = ReferenceType
            Me.Index = -1
        End Sub

        Public Items As ItemArrayList ' clsSingleItem
        'Public Multiple As Boolean ' This is true if Items.Length > 1
        Public ReferenceType As ReferencesType
        Public Index As Integer

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function

    End Class


    Friend NewReferences() As clsNewReference ' We should really keep a NewReferences collection PER parent task.  So if we execute tasks within our actions, they have their own References set!!!

    Private htblResponsesPass As New OrderedHashTable
    Private htblResponsesFail As New OrderedHashTable
    Private bTaskHasOutput As Boolean = False

    'Public d As String
#If Not www Then
    Public fRunner As frmRunner
#End If
    Public htblCompleteableGeneralTasks As New TaskHashTable
    Public htblSecondChanceTasks As New TaskHashTable ' If we don't get a winner first time round, try again, matching against objects/characters that don't exist
    Public htblVisibleObjects As New ObjectHashTable
    Public htblSeenObjects As New ObjectHashTable
    Public sInput, sLastProperInput As String
    Friend iRestNum As Integer
    Private sAmbTask As String
    Public sOutputText As String
    Public sRestrictionText, sRestrictionTextMulti As String
    Private sRouteError As String

    Private ValidRefs As Hashtable
    'Private arlMentionedObs As New StringArrayList
    Private sMentionedObsPattern As String
    'Private bDisplayDebug As Boolean = False 'True

    'Friend Class PronounOffset
    '    Public Offset As Integer
    '    Public Perspective As PerspectiveEnum
    '    Public Key As String ' What is the pronoun applying to?
    '    Public Pronoun As PronounEnum

    '    Sub New(ByVal iOffset As Integer, ePerspective As PerspectiveEnum, sKey As String, Optional ePronoun As PronounEnum = PronounEnum.SubjectInitiator)
    '        Me.Offset = iOffset
    '        Me.Perspective = ePerspective
    '    End Sub
    'End Class
    'Friend Pronouns As New List(Of PronounOffset)
    Friend Class PronounInfo
        Public Key As String ' What is the pronoun applying to?
        Public Pronoun As PronounEnum
        Public Offset As Integer ' Where in the command does this substitution take place
    End Class
    Friend Class PronounInfoList
        Inherits List(Of PronounInfo)

        Shadows Sub Add(ByVal sKey As String, ByVal ePronoun As PronounEnum, ByVal iOffset As Integer)
            Dim pi As New PronounInfo
            pi.Key = sKey
            pi.Pronoun = ePronoun
            pi.Offset = iOffset
            MyBase.Add(pi)
        End Sub
    End Class
    Friend PronounKeys As New PronounInfoList


    '		                Subjective Pronoun	Objective Pronoun	Reflective Pronoun	Possesive Pronoun
    '
    '		First Person	I (am)				Me			        Myself			    Mine
    '		Second Person	You (are)			You			        Yourself		    Yours
    '		Third Person	He/She (is)			Him/Her			    Himself/Herself		His/Hers
    '				        It (is)				It			        Itself			    Its
    '				        We (are)			Us			        Ourselves			Our
    '				        They (are)			Them			    Themselves		    Theirs


    Public Enum PronounEnum
        Subjective = 0          ' I/You/He/She/It/We/They
        Objective = 1           ' Me/You/Him/Her/It/Us/Them
        Reflective = 2          ' Myself/Yourself/Himself/Herself/Itself/Ourselves/Themselves
        Possessive = 3          ' Mine/Yours/His/Hers/Its/Ours/Theirs
    End Enum


    Private Enum eScope
        Applicable
        Visible
        Seen
    End Enum

    Public Enum ReferencesType
        [Object]
        Character
        Number
        Text
        Direction
    End Enum


    Public Enum DebugDetailLevelEnum
        [Error]
        High
        Medium
        Low
    End Enum


    'Public Sub Main()

    '    Try
    '        bGenerator = False

    '        Dim s As New Size

    '        s.Height = CInt(CInt(GetSetting("ADRIFT", "Runner", "Window Height", (fRunner.Size.Height * 15).ToString)) / 15) '- 20 ' Add this back on when adding menu I think
    '        s.Width = CInt(CInt(GetSetting("ADRIFT", "Runner", "Window Width", (fRunner.Size.Width * 15).ToString)) / 15)

    '        IntroMessage()

    '        fRunner.Size = s
    '        Application.Run(fRunner)

    '    Catch ex As Exception
    '        ErrMsg("Critical Error", ex)
    '    End Try

    'End Sub
    Private Class SortByLength
        Inherits Generic.Comparer(Of String)

        Public Overrides Function Compare(ByVal x As String, ByVal y As String) As Integer
            Return y.Length.CompareTo(x.Length)
        End Function
    End Class


    Public Sub SaveMacros()

        Try
            Dim sMacrosFile As String = sLocalDataPath & "ADRIFTMacros.xml"

            If Not IO.Directory.Exists(sLocalDataPath) Then IO.Directory.CreateDirectory(sLocalDataPath)

            Dim xmlWriter As New System.Xml.XmlTextWriter(sMacrosFile, System.Text.Encoding.UTF8)
            With xmlWriter
                .Indentation = 4
                .IndentChar = " "c
                .Formatting = Formatting.Indented

                .WriteStartDocument()
                .WriteComment("File created by ADRIFT v" & Application.ProductVersion)

                .WriteStartElement("Macros")

                For Each sTitle As String In dictMacros.Keys
                    .WriteStartElement("Macro")

                    Dim m As clsMacro = dictMacros(sTitle)

                    .WriteElementString("Key", m.Key)
                    .WriteElementString("Title", m.Title)
                    .WriteElementString("Shared", m.Shared.ToString)
                    .WriteElementString("IFID", m.IFID)
                    If m.Shortcut <> Keys.None Then .WriteElementString("Shortcut", m.Shortcut.ToString)
                    .WriteElementString("Commands", m.Commands)

                    .WriteEndElement() ' Macro
                Next

                .WriteEndElement() ' Macros

                .WriteEndDocument()

                .Flush()
                .Close()

            End With
        Catch ex As Exception
            ErrMsg("Error saving macros", ex)
        End Try

    End Sub


    ' Load Macros from file
    Public Sub LoadMacros()

        Try
            Dim sMacrosFile As String = sLocalDataPath & "ADRIFTMacros.xml"
            dictMacros.Clear()

            If IO.File.Exists(sMacrosFile) Then
                Dim xmlDoc As New System.Xml.XmlDocument
                xmlDoc.Load(sMacrosFile)
                Dim bFirst As Boolean = True

                For Each nod As System.Xml.XmlNode In xmlDoc.SelectNodes("/Macros/Macro")

                    Dim sTitle As String = nod.SelectSingleNode("Title").InnerText
                    Dim sCommands As String = nod.SelectSingleNode("Commands").InnerText
                    Dim sKey As String = nod.SelectSingleNode("Key").InnerText

                    If sKey <> "" AndAlso sTitle <> "" AndAlso sCommands <> "" Then
                        Dim macro As New clsMacro(sKey)
                        macro.Title = sTitle
                        macro.Commands = sCommands

                        If nod.SelectSingleNode("Shared") IsNot Nothing Then macro.Shared = SafeBool(nod.SelectSingleNode("Shared").InnerText)
                        If nod.SelectSingleNode("IFID") IsNot Nothing Then macro.IFID = SafeString(nod.SelectSingleNode("IFID").InnerText)
                        If nod.SelectSingleNode("Shortcut") IsNot Nothing Then macro.Shortcut = CType([Enum].Parse(GetType(Shortcut), nod.SelectSingleNode("Shortcut").InnerText), Shortcut)

                        dictMacros.Add(macro.Key, macro)
                    End If
                Next
            End If

#If Not www Then
            fRunner.ReloadMacros()
#End If

        Catch ex As Exception
            ErrMsg("Error loading macros", ex)
        End Try

    End Sub


    Public Function OpenAdventure(ByVal sFilename As String, Optional ByVal bSilentError As Boolean = False) As Boolean

        Adventure = New clsAdventure

        States.Clear()
        salCommands.Clear()
        salCommands.Add(fRunner.txtInput.Text)

        'LoadDefaults()
        'CreatePlayer() ' For now   
        iPreviousOffset = 0
        Dim eFileType As FileIO.FileTypeEnum = FileTypeEnum.TextAdventure_TAF
        If sFilename.ToLower.EndsWith(".blorb") Then eFileType = FileTypeEnum.Blorb
        If sFilename.ToLower.EndsWith(".exe") Then eFileType = FileTypeEnum.Exe

        If LoadFile(sFilename, eFileType, LoadWhatEnum.All, False, , , , bSilentError) Then
#If Not www Then
            AddFileToList(Adventure.FullPath)
            If bEXE Then
                fRunner.Text = Adventure.Title
            Else
                fRunner.Text = Adventure.Title & " - ADRIFT Runner"
            End If
#Else
            fRunner.SetTitle(Adventure.Title & " - ADRIFT WebRunner")
#End If
#If Mono Then
            fRunner.miOpenGame.Enabled = True
            fRunner.miRestartGame.Enabled = True
            fRunner.miSaveGame.Enabled = True
            fRunner.miSaveGameAs.Enabled = True
            fRunner.miMacros.Enabled = True
#ElseIf Not www Then
            fRunner.UTMMain.Tools("OpenGame").SharedProps.Enabled = True
            fRunner.UTMMain.Tools("RestartGame").SharedProps.Enabled = True
            fRunner.UTMMain.Tools("SaveGame").SharedProps.Enabled = True
            fRunner.UTMMain.Tools("SaveGameAs").SharedProps.Enabled = True
            fRunner.UTMMain.Tools("Macros").SharedProps.Enabled = True
#End If

            'Sort tasks by priority
            listTaskKeys.Clear()
            For Each tas As clsTask In Adventure.htblTasks.Values
                Dim tk As New TaskKey
                tk.sTaskKey = tas.Key
                tk.iPriority = tas.Priority
                listTaskKeys.Add(tk)
            Next
            listTaskKeys.Sort()

            Adventure.eGameState = clsAction.EndGameEnum.Running

            ' Initialise any array values
            For Each v As clsVariable In Adventure.htblVariables.Values
                If v.Length > 1 Then
                    Dim sInitialValue() As String = v.StringValue.Split(Chr(10))
                    If sInitialValue.Length = v.Length Then
                        Dim i As Integer = 1
                        For Each sValue As String In sInitialValue
                            If v.Type = clsVariable.VariableTypeEnum.Numeric Then
                                v.IntValue(i) = SafeInt(sValue)
                            Else
                                v.StringValue(i) = sValue.Replace(Chr(13), "")
                            End If
                            i += 1
                        Next
                    End If
                End If
            Next

            For Each t As clsTask In Adventure.htblTasks.Values
                For i As Integer = 0 To t.arlCommands.Count - 1
                    t.arlCommands(i) = CorrectCommand(t.arlCommands(i))
                Next
                If t.TaskType = clsTask.TaskTypeEnum.System AndAlso t.RunImmediately Then
                    AttemptToExecuteTask(t.Key, True)
                End If
            Next

            For Each e As clsEvent In Adventure.htblEvents.Values
                Select Case e.WhenStart
                    Case clsEvent.WhenStartEnum.AfterATask
                        e.Status = clsEvent.StatusEnum.NotYetStarted
                    Case clsEvent.WhenStartEnum.BetweenXandYTurns
                        e.Status = clsEvent.StatusEnum.CountingDownToStart
                        e.TimerToEndOfEvent = e.StartDelay.Value + e.Length.Value
                    Case clsEvent.WhenStartEnum.Immediately
                        e.Start(True)
                End Select
                'e.IncrementTimer() ' .DoAnySubEvents()
                'e.DoAnySubEvents()
            Next

            For Each c As clsCharacter In Adventure.htblCharacters.Values
                For Each w As clsWalk In c.arlWalks
                    If w.StartActive Then w.Start()
                Next

                ' Sort our topics by descending length
                Dim topickeys As New Generic.SortedDictionary(Of String, Generic.List(Of String))(New SortByLength)
                For Each t As clsTopic In c.htblTopics.Values
                    If t.bCommand Then t.Keywords = CorrectCommand(t.Keywords)
                    If Not topickeys.ContainsKey(t.Keywords) Then topickeys.Add(t.Keywords, New Generic.List(Of String))
                    topickeys(t.Keywords).Add(t.Key)
                Next
                Dim htblTopicsNew As New TopicHashTable
                For Each sTopic As String In topickeys.Keys
                    For Each sKey As String In topickeys(sTopic)
                        htblTopicsNew.Add(c.htblTopics(sKey))
                    Next
                Next
                c.htblTopics = htblTopicsNew
            Next
            'For Each ob As clsObject In Adventure.htblObjects.Values ' for now
            '    ob.SeenBy(Player.Key) = True
            'Next

            UpdateStatusBar()
            InitialiseInputBox()

            Adventure.Player.HasSeenLocation(Adventure.Player.Location.LocationKey) = True
#If Not www Then
            fRunner.Map.RecalculateNode(Adventure.Map.FindNode(Adventure.Player.Location.LocationKey))
            fRunner.Map.SelectNode(Adventure.Player.Location.LocationKey)
#End If
            fRunner.txtOutput.Clear()
            Display("<c>" & Adventure.Title & "</c>" & vbCrLf, True)
            Display(Adventure.Introduction.ToString, True)

            If Adventure.ShowFirstRoom Then Display(vbCrLf & Adventure.htblLocations(Adventure.Player.Location.LocationKey).ViewLocation, True)
            Display(vbCrLf & vbCrLf, True)

            For Each task As clsTask In Adventure.htblTasks.Values
                ReDim task.NewReferences(task.References.Count - 1)
            Next

            If Adventure.htblLocations.Count = 0 Then
                ErrMsg("This adventure has no locations.  Cannot continue.")
                Return False
            End If

            'bSystemTask = True
            PrepareForNextTurn()
            'bSystemTask = False
#If Not www Then
            If Not Debugger Is Nothing AndAlso Not Debugger.IsDisposed Then Debugger.BuildTree()
            fRunner.ReloadMacros()
#End If

            Return True
        Else
            Return False
        End If

    End Function


    Public Sub InitialiseInputBox(Optional ByVal sCursor As String = "Ø")

#If Not www Then
        Try
            With fRunner.txtInput
                If sCursor = "@" Then
                    .Tag = "Comment"
                Else
                    .Tag = Nothing
                End If
                .Clear()                                
                .ForeColor = colInput
#If Mono Then
                Select Case sCursor
                    Case "Ø" ' 27A2
                        sCursor = ChrW(&H27A2).ToString
                    Case "@" ' 270D
                        sCursor = ChrW(&H270D).ToString
                End Select
                .SelectionFont = New Font("OpenSymbol", 14)
                'sCursor = ">"
                '.SelectionFont = New Font("Arial", 14)
'#ElseIf www Then                
'                sCursor = ""
#Else
                .SelectionFont = New Font("Wingdings", 14)
#End If
                '.SelectedText = sCursor
                If sCursor <> "" Then
                    .AppendText(sCursor)

                    .SelectionStart = 1
                    If Adventure IsNot Nothing Then
                        .SelectionFont = Adventure.DefaultFont
                    Else
                        .SelectionFont = New Font("Arial", 12)
                    End If
                    .AppendText(" ")

                    .SelectionStart = 2
                End If
                If Adventure IsNot Nothing Then
                    .SelectionFont = Adventure.DefaultFont
                Else
                    .SelectionFont = New Font("Arial", 12)
                End If
                .Focus()
                Debug.WriteLine("txtInput Focused")
            End With

        Catch exOD As ObjectDisposedException
            ' Fail silently - shutting down
        Catch ex As Exception
            ErrMsg("InitialiseInputBox error", ex)
        End Try
#End If

    End Sub



    '    Public Sub DisplayDebug(ByVal sText As String)
    '#If DEBUG Then
    '        If bDisplayDebug Then
    '#If False Then
    '            Debug.WriteLine(sText.Replace(vbCrLf, ""))
    '            sText = "<i><font color=""#3333FF"" size=11 face=""Courier New"">" & sText & "</font></i>"
    '            sText = ReplaceALRs(ReplaceFunctions(sText))
    '            'If sOutputText <> "" AndAlso Right(sOutputText, 2) <> "  " AndAlso Right(sOutputText, 2) <> vbCrLf Then sOutputText &= "  "
    '            'sOutputText &= stext
    '            Source2HTML(sText, fRunner.txtOutput, False)
    '#End If
    '        End If
    '#End If
    '    End Sub

    Public bDisplaying As Boolean = False ' In case any output is once only - don't want it to trigger when we're just testing the text
    Public Sub Display(ByVal sText As String, Optional ByVal bCommit As Boolean = False, Optional ByVal bAllowALR As Boolean = True)

        bDisplaying = True

        'If sText.Length > 0 Then sText = sText.Substring(0, 1).ToUpper & sText.Substring(1)
        If Adventure IsNot Nothing AndAlso bAllowALR Then sText = ReplaceALRs(sText) ' ReplaceALRs(ReplaceFunctions(sText))
        'If sOutputText <> "" AndAlso Right(sOutputText, 2) <> "  " AndAlso Right(sOutputText, 2) <> vbCrLf Then sOutputText &= "  "        
        sOutputText = pSpace(sOutputText) & sText ' &= sText

        If bCommit Then
            Source2HTML(sOutputText, fRunner.txtOutput, False)
#If Mono Then
            If fRunner.miStartTranscript.Text = "Stop Transcript" Then
#ElseIf Not www Then
            If fRunner.UTMMain.Tools("miStartTranscript").SharedProps.Caption = "Stop Transcript" Then
#Else            
            If False Then
#End If
                Dim stmWriter As New IO.StreamWriter(sTranscriptFile, True)
                stmWriter.Write(StripCarats(sOutputText).Replace("Ø", ">"))
                stmWriter.Close()
            End If

            sOutputText = ""
            'fRunner.txtOutput.ScrollToCaret()
        End If

        bDisplaying = False

    End Sub


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
            .Description = "Surface can hold"
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
            .Description = "Description when read"
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
            .Description = "Container can hold"
            .Type = clsProperty.PropertyTypeEnum.Integer
            .DependentKey = "Container"
        End With
        Adventure.htblAllProperties.Add(pContainerHold)

        Dim pOpenable As New clsProperty
        With pOpenable
            .Key = "Openable"
            .Description = "Object can be opened and closed"
            .Type = clsProperty.PropertyTypeEnum.StateList
            .arlStates.Add("Open")
            .arlStates.Add("Closed")
        End With
        Adventure.htblAllProperties.Add(pOpenable)

        Dim pLockable As New clsProperty
        With pLockable
            .Key = "Lockable"
            .Description = "And is lockable, with key"
            .Type = clsProperty.PropertyTypeEnum.ObjectKey
            .DependentKey = "Openable"
        End With
        Adventure.htblAllProperties.Add(pLockable)

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

    End Sub


    Public Sub Process(ByVal sCommand As String)

        If Not Adventure Is Nothing Then
#If Not www Then
            iPreviousOffset = fRunner.txtOutput.TextLength
#End If
            If iPrepProgress = 0 Then iPrepProgress = 1
            bNoDebug = False
            dtDebug = Now
            iDebugIndent = 0
            bSystemTask = False
            'htblResponses.Clear()
            While iPrepProgress <> 2 ' Wait for the other thread to finish
                Application.DoEvents()
            End While
            sInput = sCommand
            '#If www Then
            '            sInput = fRunner.txtInput.Text
            '#Else
            '            sInput = fRunner.txtInput.Text.Substring(2).Trim
            '#End If

            If EvaluateInput(0) = "***SYSTEM***" Then
                sOutputText = ""
                Exit Sub
            End If
            bNoDebug = True

            If Not Adventure.bDisplayedWinLose Then
                Select Case Adventure.eGameState
                    Case clsAction.EndGameEnum.Win
                        Display("<center><c><b>*** You have won ***</b></c></center>" & vbCrLf, True)
                    Case clsAction.EndGameEnum.Lose
                        Display("<center><c><b>*** You have lost ***</b></c></center>" & vbCrLf, True)
                    Case clsAction.EndGameEnum.Neutral
                        ' Don't display anything
                    Case clsAction.EndGameEnum.Running
                        ' Continue
                End Select
            End If
            If Adventure.eGameState <> clsAction.EndGameEnum.Running Then
                If Not Adventure.bDisplayedWinLose AndAlso Adventure.WinningText.ToString(True) <> "" Then
                    Display(Adventure.WinningText.ToString & vbCrLf)
                End If
                If Adventure.MaxScore > 0 AndAlso Not Adventure.bDisplayedWinLose Then
                    Display("In that game you scored " & Adventure.Score & " out of a possible " & Adventure.MaxScore & ", in " & Adventure.Turns & " turns." & vbCrLf & vbCrLf, True)
                End If
                Display("Would you like to <c>restart</c>, <c>restore</c> a saved game, <c>quit</c> or <c>undo</c> the last command?" & vbCrLf & vbCrLf, True)
                Adventure.bDisplayedWinLose = True
                Exit Sub
            End If

            iPrepProgress = 0
            PrepareForNextTurn()

        End If

    End Sub


    Private Function KeyListsMatch(ByVal salSpecifics As StringArrayList, ByVal salReferences As ArrayList, ByVal bMultiple As Boolean) As Boolean

        If salSpecifics.Count = salReferences.Count Then
            For Each sSpecific As String In salSpecifics
                Dim bFound As Boolean = False
                For Each salRef As StringArrayList In salReferences
                    If salRef(0) = sSpecific Then
                        bFound = True
                        Exit For
                    End If
                Next
                If Not bFound Then Return False
            Next
        Else
            Return False
        End If

        Return True

    End Function


    ' Ensures every Reference has at least one object assigned to it
    Private Function AllRefsHaveAtLeastOne() As Boolean

        If NewReferences Is Nothing Then Return False

        For iRef As Integer = 0 To NewReferences.Length - 1
            With NewReferences(iRef)
                If .Items.Count > 0 Then
                    For Each itm As clsSingleItem In .Items
                        If itm.MatchingPossibilities.Count = 0 Then Return False
                    Next
                Else
                    Return False
                End If
            End With
        Next

        Return True

    End Function


    ' Specifics are always defined in the order of the first command in the task
    ' We may be matching on a different command, in which case Specifics will be
    ' in a different order from the References
    '
    Private Function RefsMatchSpecifics(ByVal tasChild As clsTask) As Boolean

        Dim aSpecifics() As clsTask.Specific = tasChild.Specifics
        Dim alSpecs As New ArrayList
        Dim salRefs As New StringArrayList

        ' See if we have all the Specifics we need in the References
        If NewReferences IsNot Nothing AndAlso aSpecifics.Length = NewReferences.Length Then
            For iSpec As Integer = 0 To aSpecifics.Length - 1
                ' Make sure References contains all Specifics
                With aSpecifics(iSpec)
                    For Each sKey As String In .Keys ' We must find all of these in order for the task to match
                        Dim bKeyFoundInRefs As Boolean = False
                        If sKey = "" Then
                            bKeyFoundInRefs = True
                        Else
                            'If sKey = "%Player%" Then sKey = Adventure.Player.Key
                            If sKey.Contains("%") Then sKey = ReplaceFunctions(sKey)

                            ' Grab the correct Reference
                            Dim NewRef As clsNewReference = NewReferences(iSpec)
                            For Each Ref As clsNewReference In NewReferences
                                If Ref.Index = iSpec Then
                                    NewRef = Ref
                                    Exit For
                                End If
                            Next

                            For iRef As Integer = NewRef.Items.Count - 1 To 0 Step -1
                                If NewRef.Items(iRef).MatchingPossibilities(0).ToLower = sKey.ToLower Then
                                    bKeyFoundInRefs = True
                                    'If .Multiple Then
                                    alSpecs.Add(iSpec)
                                    salRefs.Add(sKey)
                                    'End If
                                    Exit For
                                End If
                            Next
                        End If
                        If Not bKeyFoundInRefs Then Return False
                    Next
                End With
            Next
        Else
            ' Not matching same amount
            Return False
        End If

        Return True

    End Function


    Private Function RefsMatchSpecificsOld(ByVal tasChild As clsTask) As Boolean

        Dim aSpecifics() As clsTask.Specific = tasChild.Specifics
        Dim alSpecs As New ArrayList
        Dim salRefs As New StringArrayList

        ' See if we have all the Specifics we need in the References
        If NewReferences IsNot Nothing AndAlso aSpecifics.Length = NewReferences.Length Then
            For iSpec As Integer = 0 To aSpecifics.Length - 1
                ' Make sure References contains all Specifics
                With aSpecifics(iSpec)
                    For Each sKey As String In .Keys ' We must find all of these in order for the task to match
                        Dim bKeyFoundInRefs As Boolean = False
                        If sKey = "" Then
                            bKeyFoundInRefs = True
                        Else
                            If sKey = "%Player%" Then sKey = Adventure.Player.Key
                            For iRef As Integer = NewReferences(iSpec).Items.Count - 1 To 0 Step -1
                                If NewReferences(iSpec).Items(iRef).MatchingPossibilities(0) = sKey Then
                                    bKeyFoundInRefs = True
                                    'If .Multiple Then
                                    alSpecs.Add(iSpec)
                                    salRefs.Add(sKey)
                                    'End If
                                    Exit For
                                End If
                            Next
                        End If
                        If Not bKeyFoundInRefs Then Return False
                    Next
                End With
            Next
        Else
            ' Not matching same amount
            Return False
        End If

        Return True

    End Function


    Friend Sub DebugPrint(ByVal eItemType As ItemEnum, ByVal sKey As String, ByVal eDetailLevel As DebugDetailLevelEnum, ByVal sMessage As String, Optional ByVal bNewLine As Boolean = True)
#If Not www Then
        'Debug.WriteLine(sMessage)
        If bNoDebug Then Exit Sub
        If Threading.Thread.CurrentThread.Name = "Background" Then Exit Sub
        If Debugger Is Nothing OrElse Debugger.IsDisposed Then Exit Sub
        Debugger.Print(eItemType, sKey, eDetailLevel, CStr(IIf(sMessage = "", "(no output)", sMessage)), bNewLine)
#End If
    End Sub


    Private Function ExecuteSubTasks(ByVal sTaskKey As String, ByVal bCalledFromEvent As Boolean, ByVal bChildTask As Boolean, ByVal InReferences() As clsNewReference, ByVal iRefIndex As Integer, ByVal sReferenceKeys() As String, ByVal sReferenceCommands() As String) As Boolean

        If iRefIndex < InReferences.Length Then
            If InReferences(iRefIndex) Is Nothing OrElse InReferences(iRefIndex).Items Is Nothing OrElse InReferences(iRefIndex).Items.Count = 0 Then
                sReferenceKeys(iRefIndex) = ""
                sReferenceCommands(iRefIndex) = ""
                If ExecuteSubTasks(sTaskKey, bCalledFromEvent, bChildTask, InReferences, iRefIndex + 1, sReferenceKeys, sReferenceCommands) Then Return True
            Else
                For iItem As Integer = 0 To InReferences(iRefIndex).Items.Count - 1
                    If InReferences(iRefIndex).Items(iItem).MatchingPossibilities.Count > 0 Then
                        sReferenceKeys(iRefIndex) = InReferences(iRefIndex).Items(iItem).MatchingPossibilities(0)
                    Else
                        TODO("Check that this is intended...") ' Assume it's ok to leave this reference key as Nothing as there was no match
                    End If
                    sReferenceCommands(iRefIndex) = InReferences(iRefIndex).Items(iItem).sCommandReference
                    If ExecuteSubTasks(sTaskKey, bCalledFromEvent, bChildTask, InReferences, iRefIndex + 1, sReferenceKeys, sReferenceCommands) Then ExecuteSubTasks = True
                Next
            End If
        Else
            ' Ok, let's execute 'em
            If AttemptToExecuteSubTask(sTaskKey, sReferenceKeys, bCalledFromEvent, bChildTask, sReferenceCommands) Then Return True
        End If

    End Function


    Public Function AttemptToExecuteTask(ByVal sTaskKey As String, Optional ByVal bCalledFromEvent As Boolean = False, Optional ByVal bSkipRestrictionsTest As Boolean = False, Optional ByVal bChildTask As Boolean = False, Optional ByRef bContinue As Boolean = False, Optional ByRef bTaskHadOutput As Boolean = False) As Boolean

        ' E.g. if our task is "get red ball and blue ball from box", then subtasks are
        ' "get red ball from box" and
        ' "get blue ball from box"

        Dim task As clsTask = Adventure.htblTasks(sTaskKey)

        If task.Completed AndAlso Not task.Repeatable Then Return False
        DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Low, "Attempting to execute task " & task.Description & "...")

        If Not bChildTask Then
            htblResponsesPass.Clear() ' Will this cause a problem, or do we just need to call it before events run tasks for example?
            htblResponsesFail.Clear()
            bTaskHasOutput = False
        End If
        Dim bTaskHasOutputTemp As Boolean = bTaskHasOutput
        bTaskHasOutput = False

        Dim bPass As Boolean = False
        Dim InReferences() As clsNewReference = task.CopyNewRefs(NewReferences)
        If InReferences Is Nothing Then ReDim InReferences(-1)

        ' If we mention any characters on the command line, add them to the mentioned characters list (so we get "the" char rather than "a" char)
        For Each ref As clsNewReference In InReferences
            If ref IsNot Nothing Then
                If ref.ReferenceType = ReferencesType.Character Then
                    For Each itm As clsSingleItem In ref.Items
                        If itm.MatchingPossibilities.Count = 1 Then
                            If Adventure.htblCharacters.ContainsKey(itm.MatchingPossibilities(0)) Then
                                Dim ch As clsCharacter = Adventure.htblCharacters(itm.MatchingPossibilities(0))
                                Adventure.lCharMentionedThisTurn(ch.Gender).Add(ch.Key)
                            End If
                        End If
                    Next
                End If
            End If
        Next

        Dim sReferenceKeys(InReferences.Length - 1) As String
        Dim sReferenceCommands(InReferences.Length - 1) As String
        bPass = ExecuteSubTasks(sTaskKey, bCalledFromEvent, bChildTask, InReferences, 0, sReferenceKeys, sReferenceCommands)

        '' ########################
        'If InReferences IsNot Nothing AndAlso InReferences.Length > 0 Then 'AndAlso InReferences(0) IsNot Nothing AndAlso InReferences(0).Items.Count > 0 Then
        '    If InReferences(0) IsNot Nothing AndAlso InReferences(0).Items.Count > 0 Then
        '        For iItem0 As Integer = 0 To InReferences(0).Items.Count - 1
        '            If InReferences.Length > 1 Then
        '                If InReferences(1) Is Nothing Then
        '                    ' Probably a non-existant reference
        '                End If
        '                If InReferences(1) IsNot Nothing AndAlso InReferences(1).Items.Count > 0 Then
        '                    For iItem1 As Integer = 0 To InReferences(1).Items.Count - 1
        '                        If InReferences.Length > 2 Then
        '                            TODO("3 or more refs")
        '                        Else
        '                            If AttemptToExecuteSubTask(sTaskKey, New String() {InReferences(0).Items(iItem0).MatchingPossibilities(0), InReferences(1).Items(iItem1).MatchingPossibilities(0)}, bCalledFromEvent, bChildTask, New String() {InReferences(0).Items(iItem0).sCommandReference, InReferences(1).Items(iItem1).sCommandReference}) Then bPass = True
        '                        End If
        '                    Next
        '                Else
        '                    'If AttemptToExecuteSubTask(sTaskKey, New String() {}, bCalledFromEvent, bChildTask, New String() {}) Then bPass = True
        '                    If AttemptToExecuteSubTask(sTaskKey, New String() {InReferences(0).Items(iItem0).MatchingPossibilities(0), ""}, bCalledFromEvent, bChildTask, New String() {InReferences(0).Items(iItem0).sCommandReference, ""}) Then bPass = True
        '                End If
        '            Else
        '                If InReferences(0).Items(iItem0).MatchingPossibilities.Count > 0 Then
        '                    If AttemptToExecuteSubTask(sTaskKey, New String() {InReferences(0).Items(iItem0).MatchingPossibilities(0)}, bCalledFromEvent, bChildTask, New String() {InReferences(0).Items(iItem0).sCommandReference}) Then bPass = True
        '                Else
        '                    If AttemptToExecuteSubTask(sTaskKey, New String() {}, bCalledFromEvent, bChildTask, New String() {}) Then bPass = True
        '                End If
        '            End If
        '        Next
        '    Else
        '        If AttemptToExecuteSubTask(sTaskKey, New String() {""}, bCalledFromEvent, bChildTask, New String() {""}) Then bPass = True
        '    End If
        'Else
        '    If AttemptToExecuteSubTask(sTaskKey, New String() {}, bCalledFromEvent, bChildTask, New String() {}) Then bPass = True
        'End If
        '' ########################

        If Not bChildTask Then
            ' Create htblResponses from everything in htblResponsesPass, plus anything from ResponsesFail that isn't in ResponsesPass
            Dim htblResponses As New OrderedHashTable
            For Each sKey As String In htblResponsesPass.OrderedKeys
                htblResponses.Add(sKey, htblResponsesPass(sKey))
            Next

            If htblResponsesPass.Count = 0 AndAlso htblResponsesFail.Count >= 0 AndAlso task.FailOverride.ToString <> "" AndAlso ContainsWord(sInput, "all") Then
                Display(task.FailOverride.ToString)
            Else

                ' Get A, B, C from D
                ' Pass: You pick up A, B from D
                ' Fail: You can't get A from D
                ' Fail: B, C is too heavy to pick up
                ' Need: You pick up A, B from D.  C is too heavy to pick up.

                ' TODO - We could have responses from different tasks here.  We need to only match references from the same parent task
                ' So, for example, if we have an action that executes a different task with a different number of references, the different
                ' tasks should not cancel each other out.
                ' E.g. Stand on current object.  Has no references, but executes task as action which has a parameter

                ' So look at every reference combination in each failure message.  If we don't have that combination in our pass set then add it
                For Each sFailMessage As String In htblResponsesFail.OrderedKeys
                    Dim refsFail() As clsNewReference = CType(htblResponsesFail(sFailMessage), clsNewReference())
                    Dim bAllMatch As Boolean = False

                    For Each sPassMessage As String In htblResponsesPass.OrderedKeys
                        Dim refsPass() As clsNewReference = CType(htblResponsesPass(sPassMessage), clsNewReference())
                        bAllMatch = True

                        For iRef As Integer = 0 To refsFail.Length - 1
                            Dim refFail As clsNewReference = refsFail(iRef)
                            If refFail Is Nothing Then ' I think this is where our task could be executing a different task, with different references...
                                bAllMatch = False
                            Else
                                For iItm As Integer = 0 To refFail.Items.Count - 1
                                    Dim itmFail As clsSingleItem = refFail.Items(iItm)
                                    ' There should only be one matching possibility here, so no need to iterate them

                                    ' resPass(iRef) Is Nothing - think this may also be different task/different refs issue...
                                    ' Should only do this if it is for the same parent task.  If we execute a sub-task, that should become the parent
                                    If refsPass.Length <= iRef OrElse refsPass(iRef) Is Nothing OrElse refsPass(iRef).Items.Count <= iItm OrElse refsPass(iRef).Items(iItm).MatchingPossibilities(0) <> itmFail.MatchingPossibilities(0) Then
                                        ' This fail is different from this pass
                                        bAllMatch = False
                                        GoTo NextPassMessage
                                    End If

                                Next iItm
                            End If
                        Next iRef
NextPassMessage:
                        If bAllMatch Then Exit For
                    Next sPassMessage

                    If Not bAllMatch Then
                        ' We've found a failure message that didn't match any pass messages
                        If htblResponses.ContainsKey(sFailMessage) Then
                            ' Need to add refs for this message into the message
                            ' TODO
                            sFailMessage = sFailMessage
                        Else
                            ' Need to add this message
                            htblResponses.Add(sFailMessage, htblResponsesFail(sFailMessage))
                        End If
                    End If

                Next sFailMessage

                'If task.eDisplayCompletion = clsTask.BeforeAfterEnum.Before Then states.SetLastState()

                For Each sMessage As String In htblResponses.OrderedKeys
                    Dim refs As clsNewReference() = CType(htblResponses(sMessage), clsNewReference())

                    NewReferences = refs
                    Display(sMessage)
                Next

                'If task.eDisplayCompletion = clsTask.BeforeAfterEnum.Before Then states.SetCurrentState()

            End If

        End If

        If bPass Then
            ' Need to remember htblResponses, as they'll be cleared out if events run tasks...
            'Dim htblResponsesPassCopy As OrderedHashTable = htblResponsesPass.Clone
            'Dim htblResponsesFailCopy As OrderedHashTable = htblResponsesFail.Clone
            'Dim bTaskHasOutputTemp2 As Boolean = bTaskHasOutput

            'If Not task.Completed Then
            ' Check any walks/events to see if anything triggers on this task completing
            For Each c As clsCharacter In Adventure.htblCharacters.Values
                For Each w As clsWalk In c.arlWalks
                    For Each ctrl As EventOrWalkControl In w.WalkControls
                        If ctrl.eCompleteOrNot = EventOrWalkControl.CompleteOrNotEnum.Completion AndAlso ctrl.sTaskKey = task.Key Then
                            ' If a child task of the current task has affected the walk control, ignore this as a trigger
                            If w.sTriggeringTask = "" OrElse Not task.Children(True).Contains(w.sTriggeringTask) Then
                                Select Case ctrl.eControl
                                    Case EventOrWalkControl.ControlEnum.Resume
                                        'If w.Status = clsWalk.StatusEnum.Paused Then                                     
                                        w.Resume()
                                    Case EventOrWalkControl.ControlEnum.Start
                                        'If w.Status <> clsWalk.StatusEnum.Running Then
                                        w.Start()
                                    Case EventOrWalkControl.ControlEnum.Stop
                                        'If w.Status = clsWalk.StatusEnum.Running Then 
                                        w.Stop()
                                    Case EventOrWalkControl.ControlEnum.Suspend
                                        'If w.Status = clsWalk.StatusEnum.Running Then 
                                        w.Pause()
                                End Select
                                w.sTriggeringTask = task.Key
                            End If
                        End If
                    Next
                Next
            Next
            For Each e As clsEvent In Adventure.htblEvents.Values
                For Each ctrl As EventOrWalkControl In e.EventControls
                    If ctrl.eCompleteOrNot = EventOrWalkControl.CompleteOrNotEnum.Completion AndAlso ctrl.sTaskKey = task.Key Then
                        ' If a child task of the current task has affected the walk control, ignore this as a trigger
                        If e.sTriggeringTask = "" OrElse Not task.Children(True).Contains(e.sTriggeringTask) Then
                            Select Case ctrl.eControl
                                Case EventOrWalkControl.ControlEnum.Resume
                                    'If e.Status = clsWalk.StatusEnum.Paused Then 
                                    e.Resume()
                                Case EventOrWalkControl.ControlEnum.Start
                                    'If e.Status <> clsWalk.StatusEnum.Running Then 
                                    e.Start()
                                Case EventOrWalkControl.ControlEnum.Stop
                                    'If e.Status = clsWalk.StatusEnum.Running Then 
                                    e.Stop()
                                Case EventOrWalkControl.ControlEnum.Suspend
                                    'If e.Status = clsWalk.StatusEnum.Running Then 
                                    e.Pause()
                            End Select
                            e.sTriggeringTask = task.Key
                        End If
                    End If
                Next
            Next
            'End If

            '' Now mark task as completed before executing actions, so any sub tasks that check this task's Completed status will work as per v4
            ''task.Completed = True

            'bTaskHasOutput = bTaskHasOutputTemp2
            'htblResponsesPass = htblResponsesPassCopy
            'htblResponsesFail = htblResponsesFailCopy

        End If


        'If task.ContinueToExecuteLowerPriority AndAlso Not bCalledFromEvent Then        
        If Not bCalledFromEvent Then
            Select Case task.ContinueToExecuteLowerPriority
                Case clsTask.ContinueEnum.ContinueNever
                    ' Nothing to do
                    DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, "Will not try to execute lower priority tasks")
                Case clsTask.ContinueEnum.ContinueOnFail
                    bContinue = Not bPass
                    If bContinue Then
                        DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, "Will try to execute lower priority tasks as this one failed")
                    Else
                        DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, "Will not try to execute lower priority tasks as this one passed")
                    End If
                Case clsTask.ContinueEnum.ContinueOnNoOutput
                    ' TODO - This check needs to only check the current task, not the overall turn.  E.g. get gloves and scarf (from wardrobe) - 2 tasks, 2nd will fail as should have no response
                    bContinue = Not bTaskHasOutput ' htblResponsesPass.Count + htblResponsesFail.Count = 0
                    If bContinue Then
                        DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, "Will try to execute lower priority tasks as this one had no output")
                    Else
                        DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, "Will not try to execute lower priority tasks as this one had output")
                    End If
                Case clsTask.ContinueEnum.ContinueAlways
                    bContinue = True
                    DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, "Continuing trying to execute lower priority tasks")
            End Select
            If bContinue AndAlso Not bChildTask Then
                'DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Medium, "Continuing trying to execute lower priority tasks")                
                EvaluateInput(task.Priority + 1)
            End If
        End If

        bTaskHadOutput = bTaskHasOutput
        bTaskHasOutput = bTaskHasOutputTemp
        Return bPass

    End Function


    ' Returns True if the SubTask was completed successfully
    Public Function AttemptToExecuteSubTask(ByVal sTaskKey As String, ByVal sReferences() As String, ByVal bCalledFromEvent As Boolean, ByVal bChildTask As Boolean, ByVal sReferenceCommands() As String) As Boolean

        Try
            AttemptToExecuteSubTask = False

            Dim task As clsTask = Adventure.htblTasks(sTaskKey)
            'NewReferences = task.CopyNewRefs(task.NewReferencesWorking)

            ReDim NewReferences(sReferences.Length - 1)

            If sReferences.Length = 0 Then
                DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Medium, "Checking reference free task " & task.Description)
            Else
                Dim sSubTask As String = ParentTaskCommand(task) '.arlCommands(0)
                For iRef As Integer = 0 To task.References.Count - 1
                    'If sReferences(iRef) <> "" Then
                    sSubTask = sSubTask.Replace(task.References(iRef), Adventure.GetNameFromKey(sReferences(iRef)))
                    ' Set References to be ones from this particular subtask
                    Dim r As clsNewReference = Nothing ' clsReferences
                    Select Case task.References(iRef)
                        Case "%object%", "%object1%", "%object2%", "%object3%", "%object4%", "%object5%", "%objects%"
                            r = New clsNewReference(ReferencesType.Object)
                        Case "%character%", "%character1%", "%character2%", "%character3%", "%character4%", "%character5%", "%characters%"
                            r = New clsNewReference(ReferencesType.Character)
                        Case "%direction%"
                            r = New clsNewReference(ReferencesType.Direction)
                        Case "%text%"
                            r = New clsNewReference(ReferencesType.Text)
                        Case "%number%"
                            r = New clsNewReference(ReferencesType.Number)
                        Case Else
                            ErrMsg("To do")
                    End Select
                    r.sParentTask = sTaskKey
                    If sReferences(iRef) <> "" Then
                        Dim itm As New clsSingleItem ' SingleRef
                        itm.MatchingPossibilities.Add(sReferences(iRef))
                        'ReDim r.Items(0)
                        'r.Items(0) = (itm)
                        'If task.NewReferencesWorking IsNot Nothing AndAlso task.NewReferencesWorking.Length >= iRef AndAlso task.NewReferencesWorking(iRef).Items.Count > 0 AndAlso task.NewReferencesWorking(iRef).Items(0).sCommandReference = "all" Then itm.sCommandReference = "all"
                        itm.sCommandReference = sReferenceCommands(iRef)
                        r.Items.Add(itm)
                        'r.bMultiple = True                    
                    End If
                    If task.arlCommands.Count > 0 Then
                        Dim sRefs As StringArrayList = task.RefsInCommand(task.arlCommands(0))
                        Select Case task.References(iRef)
                            Case "%objects%", "%object1%", "%object2%", "%object3%", "%object4%", "%object5%", "%characters%", "%character1%", "%character2%", "%character3%", "%character4%", "%character5%", "%direction%", "%number%", "%text%"
                                For iRef2 As Integer = 0 To sRefs.Count - 1
                                    If task.References(iRef) = sRefs(iRef2) Then
                                        r.Index = iRef2
                                        Exit For
                                    End If
                                Next
                        End Select
                    End If
                    NewReferences(iRef) = r
                Next
                DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Medium, "Checking " & CStr(IIf(sReferences.Length = 1, "single", IIf(sReferences.Length = 2, "double", "triple or more"))) & " reference task " & sSubTask)
            End If

            Dim sMessage As String = ""
            Dim bPass As Boolean = PassRestrictions(task.arlRestrictions)
            Dim bOutputMessages As Boolean = False

            If bPass Then
                DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Medium, "Passed Restrictions")

                ' Remove any failing refs if this ref passes
                For Each sFailMessage As String In htblResponsesFail.OrderedKeys
                    Dim refsFail() As clsNewReference = CType(htblResponsesFail(sFailMessage), clsNewReference())

                    For iRef As Integer = 0 To refsFail.Length - 1
                        Dim refFail As clsNewReference = refsFail(iRef)
                        For iItm As Integer = 0 To refFail.Items.Count - 1
                            Dim itmFail As clsSingleItem = refFail.Items(iItm)
                            ' There should only be one matching possibility here, so no need to iterate them
                            If NewReferences(iRef) Is Nothing OrElse NewReferences(iRef).Items(iItm).MatchingPossibilities(0) <> itmFail.MatchingPossibilities(0) Then
                                ' This fail is different from this pass                            
                                GoTo NextMessage
                            End If
                        Next iItm
                    Next iRef

                    ' Ok, lets remove the failed one
                    htblResponsesFail.Remove(sFailMessage)
                    Exit For ' There should only be one matching the refs, so bomb out so we don't cause problem iterating loop
NextMessage:
                Next sFailMessage

                ' If this task contains references, see if we have a specific task
                If task.Children.Count > 0 Then DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, "Checking whether any of our child tasks should override...")
                'Dim bOverridden As Boolean = False

                Dim bShouldParentOutputText As Boolean = True
                Dim bShouldParentExecuteTasks As Boolean = True
                'Dim bAnyMatchingChildTasks As Boolean = False
                Dim lAfterChildren As New List(Of String)


                For Each sChildTask As String In task.Children ' in order or priority...
                    Dim tasChild As clsTask = Adventure.htblTasks(sChildTask)
                    If task.TaskType = clsTask.TaskTypeEnum.Specific Then
                        ' If our parent is a Specific task, we may need to pad our Specifics out with any that have been dropped
                        If task.Specifics.Length <> tasChild.Specifics.Length Then
                            ' TODO - These may be in the wrong order if we're matching on a secondary command!
                            Dim newSpecs(task.Specifics.Length - 1) As clsTask.Specific
                            Dim iChild As Integer = 0
                            For i As Integer = 0 To task.Specifics.Length - 1
                                newSpecs(i) = task.Specifics(i)
                                If newSpecs(i).Keys.Count = 0 OrElse (newSpecs(i).Keys.Count = 1 AndAlso newSpecs(i).Keys(0) = "") Then
                                    newSpecs(i) = tasChild.Specifics(iChild)
                                    iChild += 1
                                End If
                            Next
                            tasChild.Specifics = newSpecs
                        End If
                    End If
                    Dim iMatchCount As Integer = 0

                    If RefsMatchSpecifics(tasChild) Then ' This should remove the ref so it doesn't get processed when we execute the main task      

                        'If Not bAnyMatchingChildTasks Then
                        '    bAnyMatchingChildTasks = True
                        '    bShouldParentOutputText = False ' Change the default to False if we have any child tasks 
                        '    bShouldParentExecuteTasks = False
                        'End If
                        DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Medium, "Overriding child task found: " & tasChild.Description)


                        Select Case tasChild.SpecificOverrideType
                            Case clsTask.SpecificOverrideTypeEnum.BeforeActionsOnly, clsTask.SpecificOverrideTypeEnum.BeforeTextAndActions, clsTask.SpecificOverrideTypeEnum.BeforeTextOnly, clsTask.SpecificOverrideTypeEnum.Override

                                iDebugIndent += 1
                                Dim bContinueExecutingTasks As Boolean = False

                                If tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.Override Then
                                    DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.High, "Override Parent")
                                Else
                                    DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.High, "Run Before Parent")
                                End If

                                ' Make a note of how many failing responses we have, so we know if this task has failing output
                                Dim iFailRefsBefore As Integer = 0
                                If task.References.Count = 0 Then
                                    iFailRefsBefore += htblResponsesFail.Count
                                Else
                                    For Each responses() As clsNewReference In htblResponsesFail.Values
                                        For Each response As clsNewReference In responses
                                            iFailRefsBefore += response.Items.Count
                                        Next
                                    Next
                                End If


                                Dim bChildTaskHasOutput As Boolean = False
                                If AttemptToExecuteTask(tasChild.Key, bCalledFromEvent, , True, bContinueExecutingTasks, bChildTaskHasOutput) Then
                                    DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.High, "Child task passes")
                                    'bOverridden = True
                                    If tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeActionsOnly OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextAndActions Then ' tasChild.ExecuteParentActions Then
                                        DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Execute Parent actions...")
                                        'bOverridden = False                
                                        'bShouldParentExecuteTasks = True
                                    Else
                                        bShouldParentExecuteTasks = False
                                    End If
                                    If tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextAndActions OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextOnly Then
                                        DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Output Parent text...")
                                        'bShouldParentOutputText = True
                                        ' If we don't continue on text output, we need to look at the parent text
                                        ' Hmm, this means any sibling child task with output after one with no output doesn't get run
                                        'If bContinueExecutingTasks Then
                                        '    Select Case tasChild.ContinueToExecuteLowerPriority
                                        '        Case clsTask.ContinueEnum.ContinueOnNoOutput
                                        '            bContinueExecutingTasks = False  ' We assume the parent has output
                                        '    End Select
                                        'End If
                                    Else
                                        bShouldParentOutputText = False
                                    End If
                                    AttemptToExecuteSubTask = True
                                Else
                                    DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.High, "Child task fails")
                                    'bShouldParentOutputText = True
                                    'bShouldParentExecuteTasks = True

                                    'If tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextAndActions OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextOnly Then
                                    'Else
                                    'If tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeActionsOnly OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.Override Then
                                    ' Ok, compare failing output vs what it was before - if we have failing output, this takes precedence over parent if set
                                    Dim iFailRefsAfter As Integer = 0
                                    If task.References.Count = 0 Then
                                        iFailRefsAfter += htblResponsesFail.Count
                                    Else
                                        For Each responses() As clsNewReference In htblResponsesFail.Values
                                            For Each response As clsNewReference In responses
                                                iFailRefsAfter += response.Items.Count
                                            Next
                                        Next
                                    End If

                                    If iFailRefsAfter > iFailRefsBefore Then
                                        'bOverridden = True
                                        If tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextAndActions OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextOnly OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.Override Then
                                            bShouldParentOutputText = False
                                        End If
                                        If tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextAndActions OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeActionsOnly OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.Override Then
                                            bShouldParentExecuteTasks = False
                                        End If
                                    End If
                                    'else                                    
                                    'bShouldParentOutputText = False
                                    'End If

                                End If


                                bTaskHasOutput = bTaskHasOutput OrElse bChildTaskHasOutput ' If the child task has output, ensure we are aware of it
                                iDebugIndent -= 1

                                If Not bContinueExecutingTasks Then
                                    DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Do not continue executing other child tasks.")
                                    Exit For
                                Else
                                    DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Continue executing other child tasks.")
                                End If

                            Case Else
                                lAfterChildren.Add(tasChild.Key)
                                'bShouldParentOutputText = True
                                'bShouldParentExecuteTasks = True
                                If tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.AfterActionsOnly OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.AfterTextOnly Then
                                    ' TODO - Need to check PassRestrictions to see if we need to suppress parent Text or Actions

                                End If

                        End Select


                        'iDebugIndent += 1
                        'Dim bContinueExecutingTasks As Boolean = False
                        'Dim iFailRefsBefore As Integer = 0
                        'If task.References.Count = 0 Then
                        '    iFailRefsBefore += htblResponsesFail.Count
                        'Else
                        '    For Each responses() As clsNewReference In htblResponsesFail.Values
                        '        For Each response As clsNewReference In responses
                        '            iFailRefsBefore += response.Items.Count
                        '        Next
                        '    Next
                        'End If
                        ''Dim iFailRefs As Integer = htblResponsesFail.Count
                        'Dim bChildTaskHasOutput As Boolean = False
                        'If AttemptToExecuteTask(tasChild.Key, bCalledFromEvent, , True, bContinueExecutingTasks, bChildTaskHasOutput) Then
                        '    DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.High, "Child task passes")
                        '    bOverridden = True
                        '    If tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeActionsOnly OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextAndActions Then ' tasChild.ExecuteParentActions Then
                        '        DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Execute Parent actions...")
                        '        bOverridden = False
                        '        'bShouldParentOutputText = (StripCarats(tasChild.CompletionMessage.ToString) = "")
                        '    End If
                        '    If tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextAndActions OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextOnly Then
                        '        DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Output Parent text...")
                        '        bShouldParentOutputText = True
                        '    End If
                        '    AttemptToExecuteSubTask = True
                        '    'iDebugIndent -= 1
                        '    'If Not bContinueExecutingTasks Then
                        '    '    DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Do not continue executing other child tasks.")
                        '    '    'bOverridden = True ' Not sure why I put this - we still want parent task to override if the child failed
                        '    '    Exit For
                        '    'End If
                        'Else
                        '    DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.High, "Child task fails")
                        '    Dim iFailRefsAfter As Integer = 0
                        '    If task.References.Count = 0 Then
                        '        iFailRefsAfter += htblResponsesFail.Count
                        '    Else
                        '        For Each responses() As clsNewReference In htblResponsesFail.Values
                        '            For Each response As clsNewReference In responses
                        '                iFailRefsAfter += response.Items.Count
                        '            Next
                        '        Next
                        '    End If
                        '    If iFailRefsAfter > iFailRefsBefore Then ' htblResponsesFail.Count > iFailRefs Then ' Failing child task has output
                        '        bOverridden = True
                        '        bShouldParentOutputText = False
                        '    End If
                        'End If
                        'bTaskHasOutput = bTaskHasOutput OrElse bChildTaskHasOutput ' If the child task has output, ensure we are aware of it
                        'iDebugIndent -= 1
                        'If Not bContinueExecutingTasks Then
                        '    DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Do not continue executing other child tasks.")
                        '    Exit For
                        'Else
                        '    DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Continue executing other child tasks.")
                        'End If
                    End If
                Next

                If task.eDisplayCompletion = clsTask.BeforeAfterEnum.Before AndAlso bShouldParentOutputText Then
                    ' We may have already printed these refs out in a child task, so only print them here if we haven't done that
                    If NewReferences.Length > 0 Then PrintOutReferences()
                    sMessage = task.CompletionMessage.ToString
                    If sMessage Is Nothing Then sMessage = ""
                    DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, sMessage)
                    ' Replace any functions that could be affected by our actions...                    ' Can't do this, because %TheObject[%objects%]% will interpret so we get multiple entries if do get all ' But then it means that %ParentOf[%objects%]% will be incorrect if action moves it
                    sMessage = sMessage.Replace("%ParentOf[", "%PrevParentOf[").Replace("%ListObjectsOn[", "%PrevListObjectsOn[")
                    AddResponse(bOutputMessages, sMessage, sReferences, True) ' Need to call ReplaceFunctions(sMessage) here so any references replace before actions are taken
                End If

                task.Completed = True
                If bShouldParentExecuteTasks Then ExecuteActions(task, bCalledFromEvent)

                If task.eDisplayCompletion = clsTask.BeforeAfterEnum.After AndAlso bShouldParentOutputText Then
                    sMessage = task.CompletionMessage.ToString
                    If sMessage Is Nothing Then sMessage = ""
                    DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, sMessage)
                    AddResponse(bOutputMessages, sMessage, sReferences, True)
                End If


                For Each sChildTask As String In lAfterChildren
                    iDebugIndent += 1

                    Dim tasChild As clsTask = Adventure.htblTasks(sChildTask)
                    DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.High, "Run After Parent")

                    Dim bChildTaskHasOutput As Boolean = False
                    Dim bContinueExecutingTasks As Boolean = False
                    If AttemptToExecuteTask(tasChild.Key, bCalledFromEvent, , True, bContinueExecutingTasks, bChildTaskHasOutput) Then
                        DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.High, "Child task passes")
                        AttemptToExecuteSubTask = True
                    Else
                        DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.High, "Child task fails")
                    End If


                    bTaskHasOutput = bTaskHasOutput OrElse bChildTaskHasOutput ' If the child task has output, ensure we are aware of it
                    iDebugIndent -= 1
                    If Not bContinueExecutingTasks Then
                        DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Do not continue executing other child tasks.")
                        Exit For
                    Else
                        DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Continue executing other child tasks.")
                    End If
                Next

                AttemptToExecuteSubTask = True

            Else
                DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Medium, "Failed Restrictions")
                sMessage = sRestrictionText

                If sMessage Is Nothing Then sMessage = ""
                DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, sMessage)
                If NewReferences.Length > 0 Then PrintOutReferences()
            End If

            AddResponse(bOutputMessages, sMessage, sReferences, bPass)

        Catch ex As Exception
            ErrMsg("Error executing subtask " & sTaskKey, ex)
        End Try

    End Function



    'Private Sub ExecuteChildTask(ByVal task As clsTask, ByVal tasChild As clsTask, ByVal bCalledFromEvent As Boolean, ByRef bShouldParentOutputText As Boolean, ByRef bShouldParentExecuteTasks As Boolean)

    '    iDebugIndent += 1
    '    Dim bContinueExecutingTasks As Boolean = False
    '    Dim iFailRefsBefore As Integer = 0
    '    If task.References.Count = 0 Then
    '        iFailRefsBefore += htblResponsesFail.Count
    '    Else
    '        For Each responses() As clsNewReference In htblResponsesFail.Values
    '            For Each response As clsNewReference In responses
    '                iFailRefsBefore += response.Items.Count
    '            Next
    '        Next
    '    End If


    '    Dim bChildTaskHasOutput As Boolean = False
    '    If AttemptToExecuteTask(tasChild.Key, bCalledFromEvent, , True, bContinueExecutingTasks, bChildTaskHasOutput) Then
    '        DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.High, "Child task passes")
    '        bOverridden = True
    '        If tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeActionsOnly OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextAndActions Then ' tasChild.ExecuteParentActions Then
    '            DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Execute Parent actions...")
    '            'bOverridden = False                
    '            bShouldParentExecuteTasks = True
    '        End If
    '        If tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextAndActions OrElse tasChild.SpecificOverrideType = clsTask.SpecificOverrideTypeEnum.BeforeTextOnly Then
    '            DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Output Parent text...")
    '            bShouldParentOutputText = True
    '        End If
    '        AttemptToExecuteSubTask = True          
    '    Else
    '        DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.High, "Child task fails")

    '        Dim iFailRefsAfter As Integer = 0
    '        If task.References.Count = 0 Then
    '            iFailRefsAfter += htblResponsesFail.Count
    '        Else
    '            For Each responses() As clsNewReference In htblResponsesFail.Values
    '                For Each response As clsNewReference In responses
    '                    iFailRefsAfter += response.Items.Count
    '                Next
    '            Next
    '        End If

    '        If iFailRefsAfter > iFailRefsBefore Then
    '            bOverridden = True
    '            bShouldParentOutputText = False
    '        End If

    '    End If


    '    bTaskHasOutput = bTaskHasOutput OrElse bChildTaskHasOutput ' If the child task has output, ensure we are aware of it
    '    iDebugIndent -= 1
    '    If Not bContinueExecutingTasks Then
    '        DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Do not continue executing other child tasks.")
    '        Exit For
    '    Else
    '        DebugPrint(ItemEnum.Task, tasChild.Key, DebugDetailLevelEnum.Medium, "Continue executing other child tasks.")
    '    End If

    'End Sub


    Private Class clsReponse
        Public sReferences() As String
        Public bPass As Boolean
    End Class

    'Private Function RefsMatch(ByVal refs1() As clsNewReference, ByVal refs2() As clsNewReference) As Boolean

    'End Function

    Private Sub AddResponse(ByRef bOutputMessages As Boolean, ByVal sMessage As String, ByVal sReferences() As String, ByVal bPass As Boolean)

        If bOutputMessages OrElse StripCarats(sMessage) = "" Then Exit Sub
        'If StripCarats(sMessage) = "" Then Exit Sub

        Dim htblResponses As OrderedHashTable = CType(IIf(bPass, htblResponsesPass, htblResponsesFail), OrderedHashTable)

        If htblResponses.ContainsKey(sMessage) Then
            ' Add our new references to the ones already there
            For iRef As Integer = 0 To sReferences.Length - 1
                If Not CType(htblResponses(sMessage), clsNewReference())(iRef).ContainsKey(sReferences(iRef)) Then
                    'CType(htblResponses(sMessage), clsNewReference())(iRef) IsNot Nothing AndAlso Not - could add this, but reference shouldn't be Nothing...
                    'If CType(htblResponses(sMessage), clsNewReference())(iRef).ContainsKey(sReferences(iRef)) Then
                    CType(htblResponses(sMessage), clsNewReference())(iRef).Items.Add(New clsSingleItem(sReferences(iRef)))
                    'CType(htblResponses(sMessage), clsTask.clsNewReference())(iRef).bMultiple = True
                End If
            Next
        Else
            ' Store our references
            htblResponses.Add(sMessage, NewReferences)
            'bTaskHasOutput = True
        End If
        bTaskHasOutput = True

        bOutputMessages = True

    End Sub


    'Public Sub AttemptToExecuteTaskOld(ByVal sTaskKey As String, Optional ByVal bCalledFromEvent As Boolean = False, Optional ByVal bSkipRestrictionsTest As Boolean = False) ', Optional ByVal bSubTask As Boolean = False)

    '    Dim task As clsTask = Adventure.htblTasks(sTaskKey)

    '    sRestrictionText = ""
    '    DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Low, "Attempting to execute task " & task.Description & "...")

    '    'If PassRestrictions(task.arlRestrictions) Then ' If we've got a restriction on having at least 1 ref, it will display message here
    '    ' TODO - sort this line
    '    'If True Then '((References Is Nothing OrElse bSubTask) AndAlso PassRestrictions(task.arlRestrictions)) OrElse (Not bSubTask AndAlso Not ReferencesPass Is Nothing AndAlso ReferencesPass.Length > 0) Then
    '    If bSkipRestrictionsTest OrElse PassRestrictions(task.arlRestrictions) Then

    '        If bSkipRestrictionsTest Then
    '            DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Medium, "Skipping restrictions test...")
    '        Else
    '            DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Medium, "Passed restrictions...")
    '        End If

    '        Dim salChildTasks As New StringArrayList
    '        Dim bContainsMultiple As Boolean = False

    '        ' If this task contains references, see if we have a specific task
    '        If task.Children.Count > 0 Then DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, "Checking whether any of our child tasks should override...")
    '        For Each sChildTask As String In task.Children
    '            Dim tasChild As clsTask = Adventure.htblTasks(sChildTask)
    '            Dim iMatchCount As Integer = 0
    '            If RefsMatchSpecifics(tasChild) Then ' This should remove the ref so it doesn't get processed when we execute the main task
    '                DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Medium, "Ooh, we've got a child task: " & tasChild.Description)
    '                salChildTasks.Add(tasChild.Key)
    '                For Each cSpec As clsTask.Specific In tasChild.Specifics
    '                    If cSpec.Multiple Then
    '                        bContainsMultiple = True
    '                        Exit For
    '                    End If
    '                Next
    '            End If
    '        Next

    '        Dim sDoChildTasksOutput As String = sOutputText

    '        If salChildTasks.Count = 0 OrElse (True AndAlso AllRefsHaveAtLeastOne()) Then ExecuteActions(task) ' bContainsMultiple

    '        For Each sKey As String In salChildTasks
    '            AttemptToExecuteTask(sKey, bCalledFromEvent) ', True)
    '        Next

    '        ' If there has been no output text, run the parent (overridden) task actions...
    '        If salChildTasks.Count > 0 AndAlso sOutputText = sDoChildTasksOutput Then
    '            ' We need to execute this task after all
    '            ExecuteActions(task)
    '        End If

    '        If task.ContinueToExecuteLowerPriority AndAlso Not bCalledFromEvent Then
    '            DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Medium, "Continuing trying to execute lower priority tasks")
    '            sOutputText &= EvaluateInput(task.Priority + 1)
    '        End If

    '        task.Completed = True

    '        For Each e As clsEvent In Adventure.htblEvents.Values
    '            For Each ec As clsEvent.EventControl In e.EventControls
    '                If ec.sTaskKey = task.Key AndAlso ec.eCompleteOrNot = clsEvent.EventControl.CompleteOrNotEnum.Completion Then
    '                    Select Case ec.eControl
    '                        Case clsEvent.EventControl.ControlEnum.Start
    '                            If e.Status = clsEvent.StatusEnum.NotYetStarted Then e.Start()
    '                        Case clsEvent.EventControl.ControlEnum.Stop
    '                            If e.Status = clsEvent.StatusEnum.Running Then e.Stop()
    '                        Case clsEvent.EventControl.ControlEnum.Suspend
    '                            If e.Status = clsEvent.StatusEnum.Running Then e.Pause()
    '                        Case clsEvent.EventControl.ControlEnum.Resume
    '                            If e.Status = clsEvent.StatusEnum.Paused Then e.Resume()
    '                    End Select
    '                End If
    '            Next
    '        Next

    '    Else
    '        'If AllRefsHaveAtLeastOne() Then ' this prevents fail message appearing if we get balls except blue, ball (leaving no refs)
    '        If task.FailOverride <> "" AndAlso ContainsWord(fRunner.txtInput.Text, "all") Then
    '            sOutputText &= task.FailOverride
    '            htblReferencesFail.Clear()
    '        Else
    '            AddFail(References)
    '        End If
    '    End If

    '    ' Don't want to display restriction failures if the task passed
    '    'If Not PassRestrictions(task.arlRestrictions) Then
    '    'If True Then '((References Is Nothing OrElse bSubTask) AndAlso Not PassRestrictions(task.arlRestrictions)) OrElse (Not bSubTask AndAlso Not ReferencesFail Is Nothing AndAlso ReferencesFail.Length > 0) Then
    '    '    '    If Not bSubTask AndAlso (((References Is Nothing OrElse Not AllRefsHaveAtLeastOne(ReferencesType.All)) AndAlso Not PassRestrictions(task.arlRestrictions)) OrElse (Not ReferencesFail Is Nothing AndAlso ReferencesFail.Length > 0)) Then
    '    '    DisplayDebug("Failed restrictions..." & vbCrLf)
    '    '    Display(sRestrictionText, False)
    '    'End If
    '    If htblReferencesFail.Count > 0 Then
    '        For Each sErrorMsg As String In htblReferencesFail.Keys
    '            References = CType(htblReferencesFail(sErrorMsg), clsReferences())
    '            DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.Medium, "Failed restrictions (new)...")
    '            Display(sErrorMsg)
    '        Next
    '        htblReferencesFail.Clear()
    '    End If

    'End Sub


    Public Sub UncompleteTask(ByVal sTaskKey As String)

        Adventure.htblTasks(sTaskKey).Completed = False
        For Each c As clsCharacter In Adventure.htblCharacters.Values
            For Each w As clsWalk In c.arlWalks
                For Each wc As EventOrWalkControl In w.WalkControls
                    If wc.sTaskKey = sTaskKey AndAlso wc.eCompleteOrNot = EventOrWalkControl.CompleteOrNotEnum.UnCompletion Then
                        Select Case wc.eControl
                            Case EventOrWalkControl.ControlEnum.Start
                                If w.Status = clsEvent.StatusEnum.NotYetStarted Then w.Start()
                            Case EventOrWalkControl.ControlEnum.Stop
                                If w.Status = clsEvent.StatusEnum.Running Then w.Stop()
                            Case EventOrWalkControl.ControlEnum.Suspend
                                If w.Status = clsEvent.StatusEnum.Running Then w.Pause()
                            Case EventOrWalkControl.ControlEnum.Resume
                                If w.Status = clsEvent.StatusEnum.Paused Then w.Resume()
                        End Select
                    End If
                Next
            Next
        Next
        For Each e As clsEvent In Adventure.htblEvents.Values
            For Each ec As EventOrWalkControl In e.EventControls
                If ec.sTaskKey = sTaskKey AndAlso ec.eCompleteOrNot = EventOrWalkControl.CompleteOrNotEnum.UnCompletion Then
                    Select Case ec.eControl
                        Case EventOrWalkControl.ControlEnum.Start
                            If e.Status = clsEvent.StatusEnum.NotYetStarted Then e.Start()
                        Case EventOrWalkControl.ControlEnum.Stop
                            If e.Status = clsEvent.StatusEnum.Running Then e.Stop()
                        Case EventOrWalkControl.ControlEnum.Suspend
                            If e.Status = clsEvent.StatusEnum.Running Then e.Pause()
                        Case EventOrWalkControl.ControlEnum.Resume
                            If e.Status = clsEvent.StatusEnum.Paused Then e.Resume()
                    End Select
                End If
            Next
        Next

    End Sub


    ' Return the token that the reference we're looking at is 
    Private Function GetReferenceKey(ByVal sTaskCommand As String, ByVal iRefNum As Integer) As String

        Dim sTokens() As String = sTaskCommand.Split(" "c)
        Dim iWhichRef As Integer = 0
        For Each sToken As String In sTokens
            Select Case sToken
                Case "%character1%", "%character2%", "%character3%", "%character4%", "%character5%", "%characters%", "%direction%", "%number%", "%numbers%", "%object1%", "%object2%", "%object3%", "%object4%", "%object5%", "%objects%", "%text%"
                    iWhichRef += 1
            End Select
            If iWhichRef = iRefNum Then
                Return sToken.Replace("%object", "ReferencedObject").Replace("%direction", "ReferencedDirection").Replace("%", "")
                Exit For
            End If
        Next

        Return ""

    End Function



    Private Sub ExecuteSingleAction(ByVal actx As clsAction, ByVal sTaskCommand As String, ByVal task As clsTask, Optional ByVal bCalledFromEvent As Boolean = False)

        Try

            Dim act As clsAction = actx.Copy

            ' Replace references
            Select Case act.sKey1
                Case "ReferencedObject", "ReferencedObject1", "ReferencedObject2", "ReferencedObject3", "ReferencedObject4", "ReferencedObject5"
                    act.sKey1 = GetReference(act.sKey1)
                Case "ReferencedObjects"
                    For iRef As Integer = 0 To NewReferences.Length - 1
                        With NewReferences(iRef)
                            If .Items.Count > 0 AndAlso .ReferenceType = ReferencesType.Object AndAlso GetReferenceKey(sTaskCommand, iRef + 1) = "ReferencedObjects" Then
                                For iOb As Integer = 0 To .Items.Count - 1 ' alRefs.Count - 1       
                                    If .Items(iOb).MatchingPossibilities.Count > 0 Then
                                        act.sKey1 = .Items(iOb).MatchingPossibilities(0)
                                        ExecuteSingleAction(act, sTaskCommand, task)
                                    End If
                                Next
                            End If
                        End With
                    Next
                    Exit Sub
                Case "ReferencedDirection"
                    act.sKey1 = GetReference(act.sKey1)
                Case "ReferencedCharacter", "ReferencedCharacter1", "ReferencedCharacter2", "ReferencedCharacter3", "ReferencedCharacter4", "ReferencedCharacter5"
                    act.sKey1 = GetReference(act.sKey1)
                Case "%Player%"
                    act.sKey1 = Adventure.Player.Key

            End Select
            Select Case act.sKey2
                Case "ReferencedObject", "ReferencedObject1", "ReferencedObject2", "ReferencedObject3", "ReferencedObject4", "ReferencedObject5"
                    act.sKey2 = GetReference(act.sKey2)
                Case "ReferencedObjects"
                    For iRef As Integer = 0 To NewReferences.Length - 1
                        With NewReferences(iRef)
                            If .Items.Count > 0 AndAlso .ReferenceType = ReferencesType.Object AndAlso GetReferenceKey(sTaskCommand, iRef) = "ReferencedObjects" Then
                                For iOb As Integer = 0 To .Items.Count - 1 ' alRefs.Count - 1       
                                    If .Items(iOb).MatchingPossibilities.Count > 0 Then
                                        act.sKey2 = .Items(iOb).MatchingPossibilities(0)
                                        ExecuteSingleAction(act, sTaskCommand, task)
                                    End If
                                Next
                            End If
                        End With
                    Next
                    Exit Sub
                Case "ReferencedDirection"
                    act.sKey2 = GetReference(act.sKey2)
                Case "ReferencedCharacter", "ReferencedCharacter1", "ReferencedCharacter2", "ReferencedCharacter3", "ReferencedCharacter4", "ReferencedCharacter5"
                    act.sKey2 = GetReference(act.sKey2)
                Case "%Player%"
                    act.sKey2 = Adventure.Player.Key

            End Select

            If act.eItem = clsAction.ItemEnum.Conversation AndAlso act.StringValue = "%text%" Then
                act.StringValue = Adventure.sReferencedText
            End If

            Dim bBadKeys As Boolean = False
            Select Case act.eItem
                Case clsAction.ItemEnum.EndGame
                Case clsAction.ItemEnum.Variables, clsAction.ItemEnum.SetTasks, clsAction.ItemEnum.Conversation
                    If act.sKey1 Is Nothing Then bBadKeys = True
                Case Else
                    If act.sKey1 Is Nothing OrElse act.sKey2 Is Nothing Then bBadKeys = True
            End Select
            If bBadKeys Then
                DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.High, "Bad key(s) for action ")
                Exit Sub
            End If

            Select Case act.eItem
                Case clsAction.ItemEnum.MoveObject, clsAction.ItemEnum.AddObjectToGroup, clsAction.ItemEnum.RemoveObjectFromGroup
                    Dim obs As ObjectHashTable = Nothing

                    Select Case act.eMoveObjectWhat
                        Case clsAction.MoveObjectWhatEnum.Object
                            obs = New ObjectHashTable
                            obs.Add(Adventure.htblObjects(act.sKey1), act.sKey1)
                        Case clsAction.MoveObjectWhatEnum.EverythingAtLocation
                            obs = New ObjectHashTable
                            For Each ob As clsObject In Adventure.htblObjects.Values
                                If Not ob.IsStatic AndAlso ob.Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InLocation AndAlso ob.Location.Key = act.sKey1 Then
                                    obs.Add(ob, ob.Key)
                                End If
                            Next
                        Case clsAction.MoveObjectWhatEnum.EverythingHeldBy
                            obs = Adventure.htblCharacters(act.sKey1).HeldObjects
                        Case clsAction.MoveObjectWhatEnum.EverythingInGroup
                            obs = New ObjectHashTable
                            For Each sKey As String In Adventure.htblGroups(act.sKey1).arlMembers
                                obs.Add(Adventure.htblObjects(sKey), sKey)
                            Next
                        Case clsAction.MoveObjectWhatEnum.EverythingInside
                            obs = Adventure.htblObjects(act.sKey1).Children(clsObject.WhereChildrenEnum.InsideObject)
                        Case clsAction.MoveObjectWhatEnum.EverythingOn
                            obs = Adventure.htblObjects(act.sKey1).Children(clsObject.WhereChildrenEnum.OnObject)
                        Case clsAction.MoveObjectWhatEnum.EverythingWithProperty
                            obs = New ObjectHashTable
                            Dim prop As clsProperty = Adventure.htblObjectProperties(act.sKey1)
                            For Each ob As clsObject In Adventure.htblObjects.Values
                                If ob.HasProperty(prop.Key) Then
                                    If prop.Type = clsProperty.PropertyTypeEnum.SelectionOnly Then
                                        obs.Add(ob, ob.Key)
                                    Else
                                        If ob.htblProperties(prop.Key).Value = act.sPropertyValue Then obs.Add(ob, ob.Key)
                                    End If
                                End If
                            Next
                        Case clsAction.MoveObjectWhatEnum.EverythingWornBy
                            obs = Adventure.htblCharacters(act.sKey1).WornObjects
                    End Select

                    'Select Case act.sKey1
                    '    Case ALLHELDOBJECTS
                    '        obs = Adventure.Player.HeldObjects
                    '    Case ALLWORNOBJECTS
                    '        obs = Adventure.Player.WornObjects
                    '    Case Else
                    '        obs = New ObjectHashTable
                    '        Dim ob As clsObject = Adventure.htblObjects(act.sKey1)
                    '        obs.Add(ob, ob.Key)
                    'End Select
                    If obs IsNot Nothing Then
                        For Each ob As clsObject In obs.Values

                            Select Case act.eItem
                                Case clsAction.ItemEnum.MoveObject
                                    Dim dest As New clsObjectLocation
                                    Select Case act.eMoveObjectTo
                                        Case clsAction.MoveObjectToEnum.InsideObject
                                            ' Make sure we're not moving inside and object inside ourselves
                                            If Adventure.htblObjects.ContainsKey(act.sKey2) Then
                                                If ob.Key = act.sKey2 OrElse ob.Children(clsObject.WhereChildrenEnum.InsideOrOnObject, True).ContainsKey(act.sKey2) Then ' Adventure.htblObjects(act.sKey2).ChildrenInside(True).ContainsKey(ob.Key) Then
                                                    DisplayError("Recursive object container relationship")
                                                Else
                                                    dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InObject
                                                    dest.Key = act.sKey2
                                                End If
                                            End If
                                        Case clsAction.MoveObjectToEnum.OntoObject
                                            If ob.Key = act.sKey2 OrElse ob.Children(clsObject.WhereChildrenEnum.InsideOrOnObject, True).ContainsKey(act.sKey2) Then
                                                DisplayError("Recursive object surface relationship")
                                            Else
                                                dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.OnObject
                                                dest.Key = act.sKey2
                                            End If

                                        Case clsAction.MoveObjectToEnum.ToCarriedBy
                                            dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.HeldByCharacter
                                            dest.Key = act.sKey2

                                        Case clsAction.MoveObjectToEnum.ToLocation
                                            If ob.IsStatic Then
                                                If act.sKey2 = "Hidden" Then ' i.e. Nowhere
                                                    dest.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.NoRooms
                                                Else
                                                    dest.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.SingleLocation
                                                    dest.Key = act.sKey2
                                                End If
                                            Else
                                                If act.sKey2 = "Hidden" Then
                                                    dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.Hidden
                                                Else
                                                    dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InLocation
                                                    dest.Key = act.sKey2
                                                End If
                                            End If


                                        Case clsAction.MoveObjectToEnum.ToPartOfCharacter
                                            dest.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.PartOfCharacter
                                            dest.Key = act.sKey2

                                        Case clsAction.MoveObjectToEnum.ToPartOfObject
                                            dest.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.PartOfObject
                                            dest.Key = act.sKey2

                                        Case clsAction.MoveObjectToEnum.ToLocationGroup
                                            If ob.IsStatic Then
                                                dest.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.LocationGroup
                                                dest.Key = act.sKey2
                                            Else
                                                ' Need to select one room at random                            
                                                Dim group As clsGroup = Adventure.htblGroups(act.sKey2)
                                                'Dim iLocation As Integer = CInt(Rnd() * group.arlMembers.Count)
                                                dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InLocation
                                                dest.Key = group.RandomKey ' group.arlMembers(iLocation)
                                            End If

                                        Case clsAction.MoveObjectToEnum.ToSameLocationAs
                                            If ob.IsStatic Then
                                                If Adventure.htblCharacters.ContainsKey(act.sKey2) Then
                                                    ' Move Static ob to same location as a character
                                                    Dim chDest As clsCharacter = Adventure.htblCharacters(act.sKey2)
                                                    If chDest.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation Then
                                                        dest.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.SingleLocation
                                                        dest.Key = chDest.Location.Key
                                                    ElseIf chDest.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.Hidden Then
                                                        dest.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.NoRooms
                                                    End If
                                                ElseIf Adventure.htblObjects.ContainsKey(act.sKey2) Then
                                                    ' Move Static ob to same location as an object
                                                    Dim obDest As clsObject = Adventure.htblObjects(act.sKey2)
                                                    If obDest.IsStatic Then
                                                        dest = obDest.Location.Copy
                                                    Else
                                                        If obDest.Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.Hidden Then
                                                            dest.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.NoRooms
                                                        Else
                                                            dest.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.SingleLocation
                                                            For Each loc As clsLocation In obDest.LocationRoots.Values
                                                                dest.Key = loc.Key
                                                                Exit For
                                                            Next
                                                        End If
                                                    End If
                                                Else
                                                    ErrMsg("Cannot move object to same location as " & act.sKey2 & " - key not found!")
                                                End If

                                            Else
                                                If Adventure.htblCharacters.ContainsKey(act.sKey2) Then
                                                    ' Move dynamic ob to same location as a character
                                                    Dim chDest As clsCharacter = Adventure.htblCharacters(act.sKey2)

                                                    Select Case chDest.Location.ExistWhere
                                                        Case clsCharacterLocation.ExistsWhereEnum.AtLocation
                                                            dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InLocation
                                                            dest.Key = chDest.Location.Key
                                                        Case clsCharacterLocation.ExistsWhereEnum.Hidden
                                                            dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.Hidden
                                                        Case clsCharacterLocation.ExistsWhereEnum.InObject
                                                            ' Move the object inside the object we're in - but only if it allows dynamic objects
                                                            Dim obDest As clsObject = Adventure.htblObjects(chDest.Location.Key)
                                                            If obDest.IsContainer Then
                                                                dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InObject
                                                                dest.Key = chDest.Location.Key
                                                            Else
                                                                dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InLocation
                                                                dest.Key = chDest.Location.LocationKey
                                                            End If
                                                        Case clsCharacterLocation.ExistsWhereEnum.OnCharacter
                                                            ' Move to the location that the character is at
                                                            dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InLocation
                                                            dest.Key = chDest.Location.LocationKey
                                                        Case clsCharacterLocation.ExistsWhereEnum.OnObject
                                                            ' Move the object onto the object we're on - but only if it allows dynamic objects
                                                            Dim obDest As clsObject = Adventure.htblObjects(chDest.Location.Key)
                                                            If obDest.HasSurface Then
                                                                dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.OnObject
                                                                dest.Key = chDest.Location.Key
                                                            Else
                                                                dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InLocation
                                                                dest.Key = chDest.Location.LocationKey
                                                            End If
                                                    End Select

                                                ElseIf Adventure.htblObjects.ContainsKey(act.sKey2) Then
                                                    Dim obDest As clsObject = Adventure.htblObjects(act.sKey2)

                                                    If obDest.IsStatic Then
                                                        ' If the static object exists in more than one place, pick a random location 
                                                        Select Case obDest.Location.StaticExistWhere
                                                            Case clsObjectLocation.StaticExistsWhereEnum.AllRooms
                                                                TODO("Move dynamic object to one of all rooms")
                                                            Case clsObjectLocation.StaticExistsWhereEnum.LocationGroup
                                                                TODO("Move dynamic object to one of a location group")
                                                            Case clsObjectLocation.StaticExistsWhereEnum.NoRooms
                                                                obDest.Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.Hidden
                                                            Case clsObjectLocation.StaticExistsWhereEnum.PartOfCharacter
                                                                TODO("Move dynamic object to same room as character")
                                                            Case clsObjectLocation.StaticExistsWhereEnum.PartOfObject
                                                                TODO("Move dynamic object to same room as part of object")
                                                            Case clsObjectLocation.StaticExistsWhereEnum.SingleLocation
                                                                dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InLocation
                                                                dest.Key = obDest.Location.Key
                                                        End Select
                                                    Else
                                                        If obDest.Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.Hidden Then
                                                            dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.Hidden
                                                        Else
                                                            dest = obDest.Location.Copy
                                                        End If
                                                    End If
                                                Else
                                                    ErrMsg("Cannot move object to same location as " & act.sKey2 & " - key not found!")
                                                End If

                                            End If

                                        Case clsAction.MoveObjectToEnum.ToWornBy
                                            dest.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.WornByCharacter
                                            dest.Key = act.sKey2

                                    End Select

                                    ob.Move(dest)

                                Case clsAction.ItemEnum.AddObjectToGroup
                                    If Not Adventure.htblGroups(act.sKey2).arlMembers.Contains(ob.Key) Then Adventure.htblGroups(act.sKey2).arlMembers.Add(ob.Key)
                                    ob.bCalculatedGroups = False

                                Case clsAction.ItemEnum.RemoveObjectFromGroup
                                    If Adventure.htblGroups(act.sKey2).arlMembers.Contains(ob.Key) Then Adventure.htblGroups(act.sKey2).arlMembers.Remove(ob.Key)
                                    ob.bCalculatedGroups = False

                            End Select

                        Next
                    End If

                Case clsAction.ItemEnum.MoveCharacter, clsAction.ItemEnum.AddCharacterToGroup, clsAction.ItemEnum.RemoveCharacterFromGroup
                    Dim chars As CharacterHashTable = Nothing

                    Select Case act.eMoveCharacterWho
                        Case clsAction.MoveCharacterWhoEnum.Character
                            chars = New CharacterHashTable
                            chars.Add(Adventure.htblCharacters(act.sKey1), act.sKey1)
                        Case clsAction.MoveCharacterWhoEnum.EveryoneAtLocation
                            chars = Adventure.htblLocations(act.sKey1).CharactersInLocation(True)
                        Case clsAction.MoveCharacterWhoEnum.EveryoneInGroup
                            chars = New CharacterHashTable
                            For Each sKey As String In Adventure.htblGroups(act.sKey1).arlMembers
                                chars.Add(Adventure.htblCharacters(sKey), sKey)
                            Next
                        Case clsAction.MoveCharacterWhoEnum.EveryoneInside
                            chars = Adventure.htblObjects(act.sKey1).ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject)
                        Case clsAction.MoveCharacterWhoEnum.EveryoneOn
                            chars = Adventure.htblObjects(act.sKey1).ChildrenCharacters(clsObject.WhereChildrenEnum.OnObject)
                        Case clsAction.MoveCharacterWhoEnum.EveryoneWithProperty
                            chars = New CharacterHashTable
                            Dim prop As clsProperty = Adventure.htblObjectProperties(act.sKey1)
                            For Each ch As clsCharacter In Adventure.htblCharacters.Values
                                If ch.HasProperty(prop.Key) Then
                                    If prop.Type = clsProperty.PropertyTypeEnum.SelectionOnly Then
                                        chars.Add(ch, ch.Key)
                                    Else
                                        If ch.htblProperties(prop.Key).Value = act.sPropertyValue Then chars.Add(ch, ch.Key)
                                    End If
                                End If
                            Next
                    End Select

                    If chars IsNot Nothing Then
                        For Each ch As clsCharacter In chars.Values

                            Select Case act.eItem
                                Case clsAction.ItemEnum.MoveCharacter
                                    Dim dest As New clsCharacterLocation(ch)

                                    ' Default new destination to current location
                                    dest.ExistWhere = ch.Location.ExistWhere
                                    dest.Key = ch.Location.Key
                                    dest.Position = ch.Location.Position

                                    Select Case act.eMoveCharacterTo
                                        Case clsAction.MoveCharacterToEnum.InDirection
                                            Dim d As DirectionsEnum = CType([Enum].Parse(GetType(DirectionsEnum), act.sKey2), DirectionsEnum)
                                            Dim dDetails As clsDirection = Nothing
                                            If Adventure.htblLocations.ContainsKey(ch.Location.LocationKey) Then dDetails = Adventure.htblLocations(ch.Location.LocationKey).arlDirections(d)
                                            Dim sRouteErrorTask As String = sRouteError ' because sRouteError gets overwritten by checking route restrictions
                                            Dim sRestrictionTextTemp As String = sRestrictionText
                                            sRestrictionText = ""

                                            If dDetails IsNot Nothing AndAlso ch.HasRouteInDirection(d, False) Then
                                                If Adventure.htblLocations.ContainsKey(dDetails.LocationKey) Then
                                                    dest.Key = dDetails.LocationKey
                                                ElseIf Adventure.htblGroups.ContainsKey(dDetails.LocationKey) Then
                                                    dest.Key = Adventure.htblGroups(dDetails.LocationKey).RandomKey
                                                End If
                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
                                                'ch.Location.Key = dDetails.LocationKey
                                                'Display("You move " & WriteEnum(d).ToLower & vbCrLf & vbCrLf & Adventure.htblLocations(dest.LocationKey).ViewLocation)
                                            Else
                                                If sRestrictionText <> "" Then
                                                    Display(sRestrictionText)
                                                Else
                                                    ' Need to grab out the restriction text from the movement task
                                                    If sRouteErrorTask <> "" Then Display(sRouteErrorTask)
                                                End If
                                                dest = Nothing
                                            End If
                                            sRestrictionText = sRestrictionText

                                        Case clsAction.MoveCharacterToEnum.ToLocation
                                            If act.sKey2 = "Hidden" Then
                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.Hidden
                                                dest.Key = ""
                                            Else
                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
                                                dest.Key = act.sKey2
                                            End If
                                        Case clsAction.MoveCharacterToEnum.ToLocationGroup
                                            dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
                                            dest.Key = Adventure.htblGroups(act.sKey2).RandomKey
                                        Case clsAction.MoveCharacterToEnum.ToLyingOn
                                            dest.Position = clsCharacterLocation.PositionEnum.Lying
                                            If act.sKey2 = THEFLOOR Then
                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
                                                For Each sKey As String In Adventure.Player.LocationRoots.Keys
                                                    dest.Key = sKey
                                                    Exit For
                                                Next
                                            Else
                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject
                                                dest.Key = act.sKey2
                                            End If
                                        Case clsAction.MoveCharacterToEnum.ToSameLocationAs
                                            If Adventure.htblCharacters.ContainsKey(act.sKey2) Then
                                                dest.ExistWhere = Adventure.htblCharacters(act.sKey2).Location.ExistWhere
                                                dest.Key = Adventure.htblCharacters(act.sKey2).Location.Key
                                            ElseIf Adventure.htblObjects.ContainsKey(act.sKey2) Then
                                                With Adventure.htblObjects(act.sKey2)
                                                    If .IsStatic Then
                                                        Select Case .Location.StaticExistWhere
                                                            Case clsObjectLocation.StaticExistsWhereEnum.AllRooms, clsObjectLocation.StaticExistsWhereEnum.LocationGroup
                                                                ' Doesn't make sense to map
                                                            Case clsObjectLocation.StaticExistsWhereEnum.NoRooms
                                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.Hidden
                                                            Case clsObjectLocation.StaticExistsWhereEnum.PartOfCharacter
                                                                TODO("Move Char to same location as object that is part of a character")
                                                            Case clsObjectLocation.StaticExistsWhereEnum.PartOfObject
                                                                TODO("Move Char to same location as object that is part of an object")
                                                            Case clsObjectLocation.StaticExistsWhereEnum.SingleLocation
                                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
                                                                dest.Key = .Location.Key
                                                        End Select
                                                    Else
                                                        Select Case .Location.DynamicExistWhere
                                                            Case clsObjectLocation.DynamicExistsWhereEnum.HeldByCharacter, clsObjectLocation.DynamicExistsWhereEnum.WornByCharacter
                                                                dest.ExistWhere = Adventure.htblCharacters(.Key).Location.ExistWhere
                                                                dest.Key = Adventure.htblCharacters(.Key).Location.Key
                                                            Case clsObjectLocation.DynamicExistsWhereEnum.Hidden
                                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.Hidden
                                                            Case clsObjectLocation.DynamicExistsWhereEnum.InLocation
                                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
                                                                dest.Key = .Location.Key
                                                            Case clsObjectLocation.DynamicExistsWhereEnum.InObject, clsObjectLocation.DynamicExistsWhereEnum.OnObject
                                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
                                                                For Each l As clsLocation In Adventure.htblObjects(.Key).LocationRoots.Values
                                                                    dest.Key = l.Key
                                                                    Exit For
                                                                Next
                                                        End Select
                                                    End If

                                                End With
                                            End If
                                        Case clsAction.MoveCharacterToEnum.ToSittingOn
                                            dest.Position = clsCharacterLocation.PositionEnum.Sitting
                                            If act.sKey2 = THEFLOOR Then
                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
                                                For Each sKey As String In Adventure.Player.LocationRoots.Keys
                                                    dest.Key = sKey
                                                    Exit For
                                                Next
                                            Else
                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject
                                                dest.Key = act.sKey2
                                            End If
                                        Case clsAction.MoveCharacterToEnum.ToStandingOn
                                            dest.Position = clsCharacterLocation.PositionEnum.Standing
                                            If act.sKey2 = THEFLOOR Then
                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
                                                For Each sKey As String In Adventure.Player.LocationRoots.Keys
                                                    dest.Key = sKey
                                                    Exit For
                                                Next
                                            Else
                                                dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject
                                                dest.Key = act.sKey2
                                            End If
                                        Case clsAction.MoveCharacterToEnum.ToSwitchWith
                                            If ch.Key = Adventure.Player.Key OrElse act.sKey2 = Adventure.Player.Key Then
                                                ' Don't move the characters, but change which one is the player
                                                Dim eCurrentPerspective As PerspectiveEnum = Adventure.Player.Perspective
                                                Dim sOldPlayerKey As String = Adventure.Player.Key
                                                Adventure.Player.CharacterType = clsCharacter.CharacterTypeEnum.NonPlayer
                                                If ch.Key = Adventure.Player.Key Then
                                                    Adventure.Player = Adventure.htblCharacters(act.sKey2)
                                                Else
                                                    Adventure.Player = Adventure.htblCharacters(ch.Key)
                                                End If
                                                Adventure.Player.CharacterType = clsCharacter.CharacterTypeEnum.Player
                                                Adventure.Player.Perspective = eCurrentPerspective
                                                ' If the old Player character has any descriptors that match any pronouns for the player perspective, move them to the new Player
                                                ' TODO - Change this to configurable pronouns
                                                With Adventure.htblCharacters(sOldPlayerKey)
                                                    For iDescriptor As Integer = .arlDescriptors.Count - 1 To 0 Step -1
                                                        Dim sDescriptor As String = .arlDescriptors(iDescriptor)
                                                        Dim sPronouns As String() = {}
                                                        Select Case eCurrentPerspective
                                                            Case PerspectiveEnum.FirstPerson
                                                                sPronouns = New String() {"I", "me", "myself"}
                                                            Case PerspectiveEnum.SecondPerson
                                                                sPronouns = New String() {"I", "me", "myself", "you", "yourself"} ' include 1st in 2nd
                                                            Case PerspectiveEnum.ThirdPerson

                                                        End Select
                                                        For Each sPronoun As String In sPronouns
                                                            If sPronoun.ToLower = sDescriptor.ToLower Then
                                                                .arlDescriptors.RemoveAt(iDescriptor)
                                                                If Not Adventure.Player.arlDescriptors.Contains(sPronoun) Then Adventure.Player.arlDescriptors.Add(sPronoun)
                                                            End If
                                                        Next
                                                    Next
                                                End With
                                            Else
                                                ' Move the characters about
                                                Dim loc As clsCharacterLocation = ch.Location
                                                ch.Location = Adventure.htblCharacters(act.sKey2).Location
                                                Adventure.htblCharacters(act.sKey2).Location = loc
                                            End If
                                        Case clsAction.MoveCharacterToEnum.InsideObject
                                            dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.InObject
                                            dest.Key = act.sKey2
                                        Case clsAction.MoveCharacterToEnum.OntoCharacter
                                            If Adventure.htblCharacters.ContainsKey(act.sKey2) Then
                                                If ch.Key = act.sKey2 OrElse ch.Children(True).ContainsKey(act.sKey2) Then
                                                    DisplayError("Recursive character relationship")
                                                Else
                                                    dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnCharacter
                                                    dest.Key = act.sKey2
                                                End If
                                            End If
                                        Case clsAction.MoveCharacterToEnum.ToParentLocation
                                            dest.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
                                            Dim sCurrent As String = ch.Location.Key
                                            If Adventure.htblObjects.ContainsKey(sCurrent) Then
                                                For Each sKey As String In Adventure.htblObjects(sCurrent).LocationRoots.Keys
                                                    dest.Key = sKey
                                                    Exit For
                                                Next
                                            ElseIf Adventure.htblCharacters.ContainsKey(sCurrent) Then
                                                dest.Key = Adventure.htblCharacters(sCurrent).Location.LocationKey
                                            End If
                                        Case Else
                                            TODO("Move Character to " & act.eMoveCharacterTo.ToString)
                                    End Select
                                    If dest IsNot Nothing Then ch.Move(dest)

                                Case clsAction.ItemEnum.AddCharacterToGroup
                                    If Not Adventure.htblGroups(act.sKey2).arlMembers.Contains(ch.Key) Then Adventure.htblGroups(act.sKey2).arlMembers.Add(ch.Key)
                                    ch.bCalculatedGroups = False

                                Case clsAction.ItemEnum.RemoveCharacterFromGroup
                                    If Adventure.htblGroups(act.sKey2).arlMembers.Contains(ch.Key) Then Adventure.htblGroups(act.sKey2).arlMembers.Remove(ch.Key)
                                    ch.bCalculatedGroups = False

                            End Select

                        Next
                    End If


                Case clsAction.ItemEnum.AddLocationToGroup, clsAction.ItemEnum.RemoveLocationFromGroup
                    Dim locs As LocationHashTable = Nothing

                    Select Case act.eMoveLocationWhat
                        Case clsAction.MoveLocationWhatEnum.Location
                            locs = New LocationHashTable
                            locs.Add(Adventure.htblLocations(act.sKey1), act.sKey1)
                        Case clsAction.MoveLocationWhatEnum.LocationOf
                            If Adventure.htblCharacters.ContainsKey(act.sKey1) Then
                                locs = Adventure.htblCharacters(act.sKey1).LocationRoots
                            ElseIf Adventure.htblObjects.ContainsKey(act.sKey1) Then
                                locs = Adventure.htblObjects(act.sKey1).LocationRoots
                            End If
                        Case clsAction.MoveLocationWhatEnum.EverywhereInGroup
                            locs = New LocationHashTable
                            For Each sKey As String In Adventure.htblGroups(act.sKey1).arlMembers
                                locs.Add(Adventure.htblLocations(sKey), sKey)
                            Next
                        Case clsAction.MoveLocationWhatEnum.EverywhereWithProperty
                            locs = New LocationHashTable
                            Dim prop As clsProperty = Adventure.htblLocationProperties(act.sKey1)
                            For Each loc As clsLocation In Adventure.htblLocations.Values
                                If loc.HasProperty(prop.Key) Then
                                    If prop.Type = clsProperty.PropertyTypeEnum.SelectionOnly Then
                                        locs.Add(loc, loc.Key)
                                    Else
                                        If loc.htblProperties(prop.Key).Value = act.sPropertyValue Then locs.Add(loc, loc.Key)
                                    End If
                                End If
                            Next
                    End Select

                    If locs IsNot Nothing Then
                        For Each loc As clsLocation In locs.Values

                            Select Case act.eItem
                                Case clsAction.ItemEnum.AddLocationToGroup
                                    If Not Adventure.htblGroups(act.sKey2).arlMembers.Contains(loc.Key) Then Adventure.htblGroups(act.sKey2).arlMembers.Add(loc.Key)
                                    loc.bCalculatedGroups = False

                                Case clsAction.ItemEnum.RemoveLocationFromGroup
                                    If Adventure.htblGroups(act.sKey2).arlMembers.Contains(loc.Key) Then Adventure.htblGroups(act.sKey2).arlMembers.Remove(loc.Key)
                                    loc.bCalculatedGroups = False

                            End Select

                        Next
                    End If


                Case clsAction.ItemEnum.SetProperties
                    If Adventure.htblObjects.ContainsKey(act.sKey1) Then
                        Dim prop As clsProperty = Nothing
                        If Adventure.htblObjects(act.sKey1).HasProperty(act.sKey2) Then prop = Adventure.htblObjects(act.sKey1).htblProperties(act.sKey2)

                        If prop Is Nothing Then
                            If act.StringValue = sSELECTED Then
                                ' We're trying to add this as a property
                                If Adventure.htblObjectProperties.ContainsKey(act.sKey2) Then
                                    prop = CType(Adventure.htblObjectProperties(act.sKey2).Clone, clsProperty)
                                    If prop.Type = clsProperty.PropertyTypeEnum.SelectionOnly Then
                                        prop.Selected = True
                                        Adventure.htblObjects(act.sKey1).htblActualProperties.Add(prop)
                                        Adventure.htblObjects(act.sKey1).bCalculatedGroups = False
                                    End If
                                Else
                                    DebugPrint(ItemEnum.Task, act.sKey1, DebugDetailLevelEnum.Error, "Property " & act.sKey2 & " not found.")
                                End If
                            Else
                                DebugPrint(ItemEnum.Task, act.sKey1, DebugDetailLevelEnum.Error, "Property " & act.sKey2 & " not found.")
                            End If
                        Else
                            If act.StringValue = sUNSELECTED Then
                                ' We're trying to remove this property
                                Adventure.htblObjects(act.sKey1).htblActualProperties.Remove(act.sKey2)
                                Adventure.htblObjects(act.sKey1).bCalculatedGroups = False
                            Else
                                prop.Value = act.StringValue
                            End If
                        End If
                    ElseIf Adventure.htblCharacters.ContainsKey(act.sKey1) Then
                        Dim prop As clsProperty = Nothing
                        If Adventure.htblCharacters(act.sKey1).HasProperty(act.sKey2) Then prop = Adventure.htblCharacters(act.sKey1).htblProperties(act.sKey2)

                        If prop Is Nothing Then
                            Select Case act.sKey2
                                Case CHARACTERPROPERNAME
                                    prop = New clsProperty
                                    prop.Key = act.sKey2
                                    prop.Type = clsProperty.PropertyTypeEnum.Text
                            End Select
                        End If

                        If prop Is Nothing Then
                            If act.StringValue = sSELECTED Then
                                ' We're trying to add this as a property
                                If Adventure.htblCharacterProperties.ContainsKey(act.sKey2) Then
                                    prop = CType(Adventure.htblCharacterProperties(act.sKey2).Clone, clsProperty)
                                    If prop.Type = clsProperty.PropertyTypeEnum.SelectionOnly Then
                                        prop.Selected = True
                                        Adventure.htblCharacters(act.sKey1).htblActualProperties.Add(prop)
                                        Adventure.htblCharacters(act.sKey1).bCalculatedGroups = False
                                    End If
                                Else
                                    DebugPrint(ItemEnum.Task, act.sKey1, DebugDetailLevelEnum.Error, "Property " & act.sKey2 & " not found.")
                                End If
                            Else
                                DebugPrint(ItemEnum.Task, act.sKey1, DebugDetailLevelEnum.Error, "Property " & act.sKey2 & " not found.")
                            End If
                        Else
                            If act.StringValue = sUNSELECTED Then
                                ' We're trying to remove this property
                                Adventure.htblCharacters(act.sKey1).htblActualProperties.Remove(act.sKey2)
                                Adventure.htblObjects(act.sKey1).bCalculatedGroups = False
                            Else
                                prop.Value = EvaluateExpression(act.StringValue)
                            End If
                        End If

                        If act.sKey2 = CHARACTERPROPERNAME Then
                            Adventure.htblCharacters(act.sKey1).ProperName = prop.Value
                        End If

                    ElseIf Adventure.htblLocations.ContainsKey(act.sKey1) Then
                        Dim prop As clsProperty = Nothing
                        If Adventure.htblLocations(act.sKey1).HasProperty(act.sKey2) Then prop = Adventure.htblLocations(act.sKey1).htblProperties(act.sKey2)

                        If prop Is Nothing Then
                            If act.StringValue = sSELECTED Then
                                ' We're trying to add this as a property
                                If Adventure.htblLocationProperties.ContainsKey(act.sKey2) Then
                                    prop = CType(Adventure.htblLocationProperties(act.sKey2).Clone, clsProperty)
                                    If prop.Type = clsProperty.PropertyTypeEnum.SelectionOnly Then
                                        prop.Selected = True
                                        Adventure.htblLocations(act.sKey1).htblProperties.Add(prop)
                                    End If
                                Else
                                    DebugPrint(ItemEnum.Task, act.sKey1, DebugDetailLevelEnum.Error, "Property " & act.sKey2 & " not found.")
                                End If
                            Else
                                DebugPrint(ItemEnum.Task, act.sKey1, DebugDetailLevelEnum.Error, "Property " & act.sKey2 & " not found.")
                            End If
                        Else
                            If act.StringValue = sUNSELECTED Then
                                ' We're trying to remove this property
                                Adventure.htblLocations(act.sKey1).htblProperties.Remove(act.sKey2)
                            Else
                                prop.Value = act.StringValue
                                If prop.Key = "CharacterPosition" Then Adventure.htblCharacters(act.sKey1).Location.ResetPosition()
                            End If
                        End If
                    End If

                Case clsAction.ItemEnum.Variables
                    Dim var As clsVariable = Adventure.htblVariables(act.sKey1)
                    If act.eVariables = clsAction.VariablesEnum.Assignment Then
                        Dim iIndex As Integer = 1
                        If var.Length > 1 AndAlso Not act.sKey2 Is Nothing Then
                            If IsNumeric(act.sKey2) Then
                                iIndex = CInt(Val(act.sKey2))
                            Else
                                iIndex = Adventure.htblVariables(act.sKey2).IntValue
                            End If
                        End If
                        If var.Key <> "Score" OrElse Not task.Scored Then 'OrElse act.IntValue < 0 Then
                            var.SetToExpression(act.StringValue, iIndex)
                            If var.Key = "Score" Then
                                task.Scored = True
                                Adventure.Score = var.IntValue
                            End If
                        End If
                    Else
                        For iLoop As Integer = act.IntValue To CInt(act.sKey2)
                            var.SetToExpression(act.StringValue, iLoop)
                        Next
                    End If

                    'Case clsAction.ItemEnum.Score
                    '        If Not task.Scored OrElse act.IntValue < 0 Then
                    '            task.Scored = True
                    '            Adventure.Score += act.IntValue
                    '        End If

                Case clsAction.ItemEnum.SetTasks
                    Dim tas2X As clsTask = Adventure.htblTasks(act.sKey1)

                    If act.eSetTasks = clsAction.SetTasksEnum.Execute Then
                        ' Store the existing refs
                        Dim oExistingRefs() As clsNewReference = NewReferences

                        DebugPrint(ItemEnum.Task, act.sKey1, DebugDetailLevelEnum.High, "Executing task '" & tas2X.Description & "'.")
                        If act.StringValue <> "" Then
                            ' Rewrite the references based on our parameters
                            Dim sParams() As String = act.StringValue.Split("|"c)
                            Dim iWhichNewRefAreWeLookingAt As Integer = -1
                            Dim ReferencesNew(sParams.Length - 1) As clsNewReference
                            For Each sParam As String In sParams
                                iWhichNewRefAreWeLookingAt += 1

                                ' Find each ref in the new task that our parameter corresponds to
                                Dim bFoundMatchingRef As Boolean = False
                                Dim iWhichOldRefAreWeLookingAt As Integer = -1
                                For Each sRef As String In tas2X.References
                                    iWhichOldRefAreWeLookingAt += 1
                                    ' Again, we may be looking outside NewRefs if we're looking at subtask with different refs... :-/
                                    If sParam = sRef AndAlso iWhichOldRefAreWeLookingAt < NewReferences.Length Then ' Ok, found same ref, so we just pass the ref thru
                                        ReferencesNew(iWhichNewRefAreWeLookingAt) = NewReferences(iWhichOldRefAreWeLookingAt)
                                        bFoundMatchingRef = True
                                    End If
                                Next
                                If Not bFoundMatchingRef Then
                                    ' Need to work this out on our own...
                                    Dim UserDefinedRef As clsNewReference

                                    ' Gotta guess the type of ref...
                                    Select Case sLeft(sParam, 6).ToLower
                                        Case "%convc"
                                            UserDefinedRef = New clsNewReference(ReferencesType.Character)
                                        Case "%paren"
                                            UserDefinedRef = New clsNewReference(ReferencesType.Object)
                                        Case "%text%"
                                            UserDefinedRef = New clsNewReference(ReferencesType.Text)
                                        Case Else
                                            UserDefinedRef = New clsNewReference(ReferencesType.Object)
                                    End Select
                                    UserDefinedRef.sParentTask = tas2X.Key

                                    ' Now work out, e.g. %ParentOf[%objects%]% ...
                                    Dim sFunctionRef As String = ReplaceFunctions(sParam)
                                    If Not sFunctionRef.Contains("***") Then
                                        Dim itm As New clsSingleItem
                                        itm.MatchingPossibilities.Add(sFunctionRef) 'ReplaceFunctions(sParam))
                                        UserDefinedRef.Items.Add(itm)
                                        If sParam.StartsWith("%ParentOf") Then
                                            UserDefinedRef.ReferenceType = ReferencesType.Object
                                        End If
                                    Else
                                        DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.High, "Error calculating parameter " & sParam)
                                    End If
                                    ReferencesNew(iWhichNewRefAreWeLookingAt) = UserDefinedRef
                                End If
                            Next
                            NewReferences = ReferencesNew
                            PrintOutReferences()
                        End If
                        ' was True in ChildTask.  But it's not a child, it's a seperate task call... 
                        ' was bCalledFromEvent in second param - but think this should be set if calling from task
                        ' Re the above, a reason why would be good.  Means later we don't do the continue? check
                        Dim bSubTaskHasOutput As Boolean = False
                        AttemptToExecuteTask(act.sKey1, bCalledFromEvent, , True, , bSubTaskHasOutput)
                        If bSubTaskHasOutput Then bTaskHasOutput = True
                        NewReferences = oExistingRefs
                    Else
                        If tas2X.Completed Then
                            DebugPrint(ItemEnum.Task, act.sKey1, DebugDetailLevelEnum.High, "Task '" & tas2X.Description & "' being uncompleted.")

                            If tas2X.Completed Then
                                ' Check any walks/events to see if anything triggers on this task completing
                                For Each c As clsCharacter In Adventure.htblCharacters.Values
                                    For Each w As clsWalk In c.arlWalks
                                        For Each ctrl As EventOrWalkControl In w.WalkControls
                                            If ctrl.eCompleteOrNot = EventOrWalkControl.CompleteOrNotEnum.UnCompletion AndAlso ctrl.sTaskKey = tas2X.Key Then
                                                Select Case ctrl.eControl
                                                    Case EventOrWalkControl.ControlEnum.Resume
                                                        If w.Status = clsWalk.StatusEnum.Paused Then w.Resume()
                                                    Case EventOrWalkControl.ControlEnum.Start
                                                        If w.Status <> clsWalk.StatusEnum.Running Then w.Start()
                                                    Case EventOrWalkControl.ControlEnum.Stop
                                                        If w.Status = clsWalk.StatusEnum.Running Then w.Stop()
                                                    Case EventOrWalkControl.ControlEnum.Suspend
                                                        If w.Status = clsWalk.StatusEnum.Running Then w.Pause()
                                                End Select
                                            End If
                                        Next
                                    Next
                                Next
                                For Each e As clsEvent In Adventure.htblEvents.Values
                                    For Each ctrl As EventOrWalkControl In e.EventControls
                                        If ctrl.eCompleteOrNot = EventOrWalkControl.CompleteOrNotEnum.UnCompletion AndAlso ctrl.sTaskKey = tas2X.Key Then
                                            Select Case ctrl.eControl
                                                Case EventOrWalkControl.ControlEnum.Resume
                                                    If e.Status = clsWalk.StatusEnum.Paused Then e.Resume()
                                                Case EventOrWalkControl.ControlEnum.Start
                                                    If e.Status <> clsWalk.StatusEnum.Running Then e.Start()
                                                Case EventOrWalkControl.ControlEnum.Stop
                                                    If e.Status = clsWalk.StatusEnum.Running Then e.Stop()
                                                Case EventOrWalkControl.ControlEnum.Suspend
                                                    If e.Status = clsWalk.StatusEnum.Running Then e.Pause()
                                            End Select
                                        End If
                                    Next
                                Next
                            End If

                            tas2X.Completed = False
                        End If
                    End If

                Case clsAction.ItemEnum.EndGame
                    Adventure.eGameState = act.eEndgame

                Case clsAction.ItemEnum.Conversation
                    Select Case act.eConversation
                        Case clsAction.ConversationEnum.EnterConversation
                            Adventure.sConversationCharKey = act.sKey1
                        Case clsAction.ConversationEnum.LeaveConversation
                            If Adventure.sConversationCharKey = act.sKey1 Then Adventure.sConversationCharKey = ""
                        Case Else
                            ExecuteConversation(act.sKey1, act.eConversation, act.StringValue)
                            bTaskHasOutput = True
                    End Select

            End Select

        Catch ex As Exception
            ErrMsg("Error executing action " & actx.Summary, ex)
        End Try

    End Sub


    Private Function EvaluateExpression(ByVal sExpression As String) As String

        If sExpression = "" Then Return ""

        Dim var As New clsVariable
        var.Type = clsVariable.VariableTypeEnum.Text
        var.SetToExpression(sExpression)
        If var.StringValue <> "" Then
            Return var.StringValue
        Else
            Return sExpression
        End If

    End Function


    Private Sub ExecuteConversation(ByVal sCharKey As String, ByVal ConvType As clsAction.ConversationEnum, ByVal sCommandOrSubject As String)

        DebugPrint(ItemEnum.Character, sCharKey, DebugDetailLevelEnum.Medium, "Execute Conversation " & ConvType.ToString & ": " & sCommandOrSubject)

        ' If currently in a conversation with a different character, search for an Implicit Farewell for other char
        If Adventure.sConversationCharKey <> "" AndAlso Adventure.sConversationCharKey <> sCharKey Then
            Dim farewell As clsTopic = FindConversationNode(Adventure.htblCharacters(Adventure.sConversationCharKey), ConvType, "")
            If farewell IsNot Nothing Then AddResponse(False, farewell.oConversation.ToString, New String() {}, True)
            Adventure.sConversationCharKey = ""
            Adventure.sConversationNode = ""
        End If


        Dim ConvChar As clsCharacter = Adventure.htblCharacters(sCharKey)

        ' If not currently in conversation and ConvType != Intro, then search for an Implicit Intro for that char

        If Adventure.sConversationCharKey = "" Then ' AndAlso ConvType <> clsAction.ConversationEnum.Greet Then     
            ' Try to find an explicit intro
            Dim intro As clsTopic = FindConversationNode(ConvChar, ConvType Or clsAction.ConversationEnum.Greet, sCommandOrSubject)
            ' If not, look for an implicit one
            If intro Is Nothing Then intro = FindConversationNode(ConvChar, clsAction.ConversationEnum.Greet, "")
            If intro IsNot Nothing Then
                AddResponse(False, intro.oConversation.ToString, New String() {}, True)
                'Display(intro.oConversation.ToString)
                If intro.bAsk OrElse intro.bTell OrElse intro.bCommand Then ' We matched an explicit intro, so no need to look further
                    Adventure.sConversationCharKey = sCharKey
                    If intro.arlActions.Count > 0 Then ExecuteActions(intro.arlActions)
                    Exit Sub
                End If
            End If
        End If


        ' Enter conversation with character
        Adventure.sConversationCharKey = sCharKey


        ' Find conversation node (try to match on Farewell commands first)
        Dim topic As clsTopic = Nothing
        If ConvType = clsAction.ConversationEnum.Command Then topic = FindConversationNode(ConvChar, ConvType Or clsAction.ConversationEnum.Farewell, sCommandOrSubject)
        If topic Is Nothing Then
            topic = FindConversationNode(ConvChar, ConvType, sCommandOrSubject)
        Else
            Adventure.sConversationCharKey = ""
            Adventure.sConversationNode = ""
        End If

        If topic IsNot Nothing Then
            AddResponse(False, topic.oConversation.ToString, New String() {}, True)
            'Display(topic.oConversation.ToString)
            ' If topic has children, set the conversation node
            If ConvChar.htblTopics.DoesTopicHaveChildren(topic.Key) Then
                Adventure.sConversationNode = topic.Key
            Else
                If Not topic.bStayInNode Then Adventure.sConversationNode = ""
            End If
            If topic.arlActions.Count > 0 Then ExecuteActions(topic.arlActions)
        Else
            ' Hmm, no conversation found.  Need to give a default response back...
            Adventure.sConversationNode = ""
            Dim sMessage As String = ""
            ' TODO: Need to make this configurable within Generator
            Select Case ConvType
                Case clsAction.ConversationEnum.Ask
                    sMessage = "%CharacterName[" & ConvChar.Key & "]% doesn't appear to understand you."
                Case clsAction.ConversationEnum.Farewell
                    sMessage = "%CharacterName[" & ConvChar.Key & "]% doesn't appear to understand you."
                Case clsAction.ConversationEnum.Greet
                    sMessage = "%CharacterName[" & ConvChar.Key & "]% doesn't appear to understand you."
                Case clsAction.ConversationEnum.Tell
                    sMessage = "%CharacterName[" & ConvChar.Key & "]% doesn't appear to understand you."
                Case clsAction.ConversationEnum.Command
                    sMessage = "%CharacterName[" & ConvChar.Key & "]% ignores you."
                    'AddResponse(bOutputMessages, ConvChar.Name & " ignores you.",  sReferences, bPass)
            End Select
            AddResponse(False, sMessage, New String() {}, True)
        End If

    End Sub


    Friend Function FindConversationNode(ByVal ConvChar As clsCharacter, ByVal ConvType As clsAction.ConversationEnum, ByVal sCommandOrSubject As String) As clsTopic

        Dim iConvType As Integer = CInt(ConvType)
        Dim bFarewell As Boolean = False
        If iConvType >= CInt(clsAction.ConversationEnum.Farewell) Then
            bFarewell = True
            iConvType -= CInt(clsAction.ConversationEnum.Farewell)
        End If
        Dim bCommand As Boolean = False
        If iConvType >= CInt(clsAction.ConversationEnum.Command) Then
            bCommand = True
            iConvType -= CInt(clsAction.ConversationEnum.Command)
        End If
        Dim bTell As Boolean = False
        If iConvType >= CInt(clsAction.ConversationEnum.Tell) Then
            bTell = True
            iConvType -= CInt(clsAction.ConversationEnum.Tell)
        End If
        Dim bAsk As Boolean = False
        If iConvType >= CInt(clsAction.ConversationEnum.Ask) Then
            bAsk = True
            iConvType -= CInt(clsAction.ConversationEnum.Ask)
        End If
        Dim bIntro As Boolean = False
        If iConvType >= CInt(clsAction.ConversationEnum.Greet) Then
            bIntro = True
            iConvType -= CInt(clsAction.ConversationEnum.Greet)
        End If

        ' Iterate thru all the leaves of the current node
        With ConvChar

            ' Should we sort our topics, perhaps by length?
            Dim dfHighestPercent As Double = 0
            Dim iMostMatches As Integer = 0
            Dim topicBest As clsTopic = Nothing

            For Each topic As clsTopic In .htblTopics.Values
                Dim iMatchedKeywords As Integer = 0

                If (topic.ParentKey = "" OrElse topic.ParentKey = Adventure.sConversationNode) AndAlso (Not bIntro OrElse topic.bIntroduction) AndAlso (Not bFarewell OrElse topic.bFarewell) AndAlso (bCommand = topic.bCommand) AndAlso (Not bAsk OrElse topic.bAsk) AndAlso (Not bTell OrElse topic.bTell) Then

                    If bAsk OrElse bTell Then
                        ' Keyword matching
                        ' Find the node that matches the most keywords
                        ' Then if there are more than one, pick the one that matches most as a percentage
                        Dim sKeywords As String() = topic.Keywords.Split(","c)
                        For Each sKeyword As String In sKeywords
                            If ContainsWord(sCommandOrSubject, sKeyword.ToLower.Trim) OrElse sKeyword = "*" Then
                                'If sTopic.Trim = sCommandOrSubject Then
                                If PassRestrictions(topic.arlRestrictions) Then iMatchedKeywords += 1 ' Return topic
                            End If
                        Next
                        Dim dfPercentMatched As Double = iMatchedKeywords / sKeywords.Length
                        'If dfPercentMatched = 1 Then Return topic
                        If iMatchedKeywords > iMostMatches OrElse (iMatchedKeywords = iMostMatches AndAlso dfPercentMatched > dfHighestPercent) Then
                            topicBest = topic
                            dfHighestPercent = dfPercentMatched
                            iMostMatches = iMatchedKeywords
                        End If
                    End If

                    If bCommand Then
                        ' RE matching
                        Dim re As System.Text.RegularExpressions.Regex = GetRegularExpression(topic.Keywords.Trim, sCommandOrSubject, False)
                        If re IsNot Nothing AndAlso re.IsMatch(sCommandOrSubject) Then
                            If PassRestrictions(topic.arlRestrictions) Then
                                If topic.Keywords.Contains("%text%") Then ' Needs full parsing really...
                                    Adventure.sReferencedText = re.Match(sCommandOrSubject).Groups("text").Value.Trim
                                End If
                                Return topic
                            End If
                        End If
                    End If

                    If Not bAsk AndAlso Not bTell AndAlso Not bCommand Then
                        ' No matching whatsoever
                        If PassRestrictions(topic.arlRestrictions) Then Return topic
                    End If

                End If
            Next

            If topicBest IsNot Nothing Then Return topicBest
        End With

        Return Nothing

    End Function


    Private Sub ExecuteActions(ByVal Actions As ActionArrayList)

        DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.High, "Executing Actions...")
        iDebugIndent += 1
        For Each act As clsAction In Actions
            ExecuteSingleAction(act, "", Nothing)
        Next
        iDebugIndent -= 1

    End Sub
    Private Sub ExecuteActions(ByVal task As clsTask, Optional ByVal bCalledFromEvent As Boolean = False) ' As String

        'If task.eDisplayCompletion = clsTask.BeforeAfterEnum.Before Then Display(task.CompletionMessage)
        'If task.eDisplayCompletion = clsTask.BeforeAfterEnum.Before AndAlso Not bOutputMessages Then AddResponse(bOutputMessages, sMessage, sReferences)

        DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, "Executing Actions...")
        iDebugIndent += 1
        For Each act As clsAction In task.arlActions
            'If act.eItem = clsAction.ItemEnum.SetTasks Then ' For now, whilst we work on the parser...
            ExecuteSingleAction(act, ParentTaskCommand(task), task, bCalledFromEvent)
            'End If
        Next
        iDebugIndent -= 1
        'If task.eDisplayCompletion = clsTask.BeforeAfterEnum.After Then Display(task.CompletionMessage)

    End Sub


    Public Sub ShowUserSplash()

        If clsBlorb.Frontispiece > -1 Then

            Dim imgSplash As Image = Blorb.GetImage(clsBlorb.Frontispiece)
            If imgSplash IsNot Nothing Then
#If Not www Then
                UserSplash = New frmUserSplash
                UserSplash.BackgroundImage = imgSplash
                UserSplash.ClientSize = imgSplash.Size
                If fRunner IsNot Nothing Then
                    UserSplash.StartPosition = FormStartPosition.Manual
                    UserSplash.Location = New Point(CInt(fRunner.Location.X + fRunner.Width / 2 - UserSplash.Width / 2), CInt(fRunner.Location.Y + fRunner.Height / 2 - UserSplash.Height / 2))
                Else
                    UserSplash.StartPosition = FormStartPosition.CenterScreen
                End If
                UserSplash.TopMost = True
                UserSplash.Show()
                Application.DoEvents()
#End If
            End If
        End If
    End Sub


    ' Returns the command from the parent task if we're a specific task.  Does this recursively in case we're specific of a specific etc.
    Public Function ParentTaskCommand(ByVal task As clsTask) As String

        While task.TaskType = clsTask.TaskTypeEnum.Specific
            task = Adventure.htblTasks(task.GeneralKey)
        End While
        If task.arlCommands.Count > 0 Then
            If task.arlCommands.Count > iMatchedTaskCommand Then
                Return task.arlCommands(iMatchedTaskCommand)
            Else
                Return task.arlCommands(0)
            End If
        Else
            Return ""
        End If

    End Function

    Private Function ToProper(ByVal sText As String, Optional ByVal bStrict As Boolean = False) As String

        Dim sReturn As String = Nothing

        If sText.Length > 0 Then sReturn = sText.Substring(0, 1).ToUpper
        If sText.Length > 1 Then
            If bStrict Then sReturn &= sText.Substring(1).ToLower Else sReturn &= sText.Substring(1)
        End If

        Return sReturn

    End Function


    Private Function AmbWord(ByVal sKeys As StringArrayList) As String

        Dim bFoundInAllItemsSoFar As Boolean
        Dim bFoundInThisItem As Boolean

        AmbWord = Nothing

        ' Work out a common word that's in all the object names, and is also in the input
        For Each sWord As String In Split(sLastProperInput, " ")
            bFoundInAllItemsSoFar = True
            For Each sKey As String In sKeys
                bFoundInThisItem = False
                If Adventure.htblObjects.ContainsKey(sKey) Then
                    For Each sName As String In Adventure.htblObjects(sKey).arlNames
                        If sWord = sName Then
                            bFoundInThisItem = True
                            GoTo NextItem
                        End If
                    Next sName
                End If
                If Adventure.htblCharacters.ContainsKey(sKey) Then
                    If sWord = Adventure.htblCharacters(sKey).ProperName Then
                        bFoundInThisItem = True
                        GoTo NextItem
                    End If
                    For Each sName As String In Adventure.htblCharacters(sKey).arlDescriptors
                        If sWord = sName Then
                            bFoundInThisItem = True
                            GoTo NextItem
                        End If
                    Next sName
                End If
                If Not bFoundInThisItem Then
                    bFoundInAllItemsSoFar = False
                    GoTo NextWord
                End If
NextItem:
            Next sKey
            If bFoundInAllItemsSoFar Then Return sWord
NextWord:
        Next sWord

    End Function


    Private Sub DisplayAmbiguityQuestion()

        NewReferences = Adventure.htblTasks(sAmbTask).NewReferencesWorking
        If NewReferences Is Nothing Then Exit Sub

        For iRef As Integer = 0 To NewReferences.Length - 1
            Debug.WriteLine("Reference " & iRef)
            With NewReferences(iRef)
                Debug.WriteLine("Number of Items in this Reference: " & .Items.Count)
                For Each itm As clsSingleItem In .Items
                    If itm.MatchingPossibilities.Count > 1 Then
                        Select Case .ReferenceType
                            Case ReferencesType.Object
                                Dim htblObs As New ObjectHashTable
                                For Each sKey As String In itm.MatchingPossibilities
                                    If Not htblObs.ContainsKey(sKey) Then htblObs.Add(Adventure.htblObjects(sKey), sKey)
                                Next
                                Dim bCanSeeAny As Boolean = False
                                For Each sKey As String In htblObs.Keys
                                    If Not bCanSeeAny AndAlso Adventure.Player.CanSeeObject(sKey) Then bCanSeeAny = True
                                Next
                                If Not bCanSeeAny Then     ' Want to try to move this into the library at some point, as we _may_ want to resolve ambiguous items that aren't visible to the player                               
                                    Dim bAnyPlural As Boolean = False
                                    For Each ob As clsObject In htblObs.Values
                                        If ob.IsPlural Then
                                            bAnyPlural = True
                                            Exit For
                                        End If
                                    Next
                                    If bAnyPlural Then
                                        Display("You can't see any " & AmbWord(itm.MatchingPossibilities) & "!" & vbCrLf)
                                    Else
                                        Display("You can't see any " & (New clsObject).GuessPluralFromNoun(AmbWord(itm.MatchingPossibilities)) & "!" & vbCrLf)
                                    End If
                                    sAmbTask = Nothing
                                Else
                                    Display("Which " & AmbWord(itm.MatchingPossibilities) & "?")
                                    Display(ToProper(htblObs.List("or")) & "." & vbCrLf)
                                End If
                                Exit Sub
                            Case ReferencesType.Character
                                Dim htblChars As New CharacterHashTable
                                For Each sKey As String In itm.MatchingPossibilities
                                    htblChars.Add(Adventure.htblCharacters(sKey), sKey)
                                Next
                                Dim bCanSeeAny As Boolean = False
                                For Each sKey As String In htblChars.Keys
                                    If Not bCanSeeAny AndAlso Adventure.Player.CanSeeCharacter(sKey) Then bCanSeeAny = True
                                Next
                                If Not bCanSeeAny Then
                                    Display("You can't see any " & AmbWord(itm.MatchingPossibilities) & "!")
                                    sAmbTask = Nothing
                                Else
                                    Display("Which " & AmbWord(itm.MatchingPossibilities) & "?")
                                    Display(ToProper(htblChars.List("or")) & "." & vbCrLf)
                                End If
                                Exit Sub
                        End Select
                    ElseIf itm.MatchingPossibilities.Count = 0 Then
                        Display("Sorry, that does not clarify the ambiguity." & vbCrLf)
                        sAmbTask = Nothing
                        Exit Sub
                    End If
                Next
            End With
        Next

    End Sub



    Private Sub PrintOutReferences()

        If NewReferences Is Nothing Then Exit Sub
        For iRef As Integer = 0 To NewReferences.Length - 1
            Select Case iRef
                Case 0
                    DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, "First Reference: ", False)
                Case 1
                    DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, "Second Reference: ", False)
                Case 2
                    DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, "Third Reference: ", False)
                Case 3
                    DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, "Fourth Reference: ", False)
                Case Else
                    DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, "Reference " & iRef & ": ", False)
            End Select

            Dim iCount As Integer = 0
            If NewReferences(iRef) IsNot Nothing Then
                For Each itm As clsSingleItem In NewReferences(iRef).Items
                    For Each sKey As String In itm.MatchingPossibilities
                        Select Case NewReferences(iRef).ReferenceType
                            Case ReferencesType.Object
                                If Adventure.htblObjects.ContainsKey(sKey) Then DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, Adventure.htblObjects(sKey).FullName, False) ' & " (" & sr.bExcept & ")")
                            Case ReferencesType.Direction
                                DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, sKey, False)
                            Case ReferencesType.Character
                                If Adventure.htblCharacters.ContainsKey(sKey) Then DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, Adventure.htblCharacters(sKey).ProperName, False) ' & " (" & sr.bExcept & ")")
                            Case ReferencesType.Number

                            Case ReferencesType.Text

                        End Select
                        iCount += 1
                        If iCount < NewReferences(iRef).Items.Count Then DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, ", ", False)
                    Next
                Next
            Else
                DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, "Nothing", False)
            End If
            DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, "")
        Next

    End Sub


    Private Sub GrabIt()

        Try
            Dim sNewIt As String = ""
            Dim sNewThem As String = ""
            Dim sNewHim As String = ""
            Dim sNewHer As String = ""
            Dim sWords() As String = sInput.Split(" "c) ' fRunner.txtInput.Text.Split(" "c)
            Dim PossibleItKeys As New StringArrayList
            Dim PossibleThemKeys As New StringArrayList
            Dim PossibleHimKeys As New StringArrayList
            Dim PossibleHerKeys As New StringArrayList


            ' First, look at anything visible, then seen
            For iScope As eScope = eScope.Visible To eScope.Seen
                For Each sWord As String In sWords

                    Dim htblObs As ObjectHashTable = Nothing
                    Dim htblChars As CharacterHashTable = Nothing
                    If iScope = eScope.Visible Then
                        htblObs = Adventure.htblObjects.VisibleTo(Adventure.Player.Key)
                        htblChars = Adventure.htblCharacters.VisibleTo(Adventure.Player.Key)
                    Else
                        htblObs = Adventure.htblObjects.SeenBy(Adventure.Player.Key)
                        htblChars = Adventure.htblCharacters.SeenBy(Adventure.Player.Key)
                    End If

                    If sNewIt = "" Then
                        For Each ob As clsObject In htblObs.Values
                            'If Not ob.IsPlural Then
                            For Each sName As String In ob.arlNames
                                If sWord = sName Then
                                    '                                    sNewIt = "the " & sWord
                                    If Not PossibleItKeys.Contains(ob.Key) Then PossibleItKeys.Add(ob.Key)
                                End If
                            Next
                            'End If
                        Next ob
                    End If
                    If sNewThem = "" Then
                        For Each ob As clsObject In htblObs.Values
                            If ob.IsPlural Then
                                For Each sName As String In ob.arlNames
                                    If sWord = sName Then
                                        If Not PossibleThemKeys.Contains(ob.Key) Then PossibleThemKeys.Add(ob.Key)
                                    End If
                                Next
                            End If
                        Next ob
                    End If
                    For Each ch As clsCharacter In htblChars.Values
                        Dim bMatch As Boolean = False
                        If sWord = ch.ProperName.ToLower Then bMatch = True
                        For Each sName As String In ch.arlDescriptors
                            If sWord = sName Then
                                bMatch = True
                                Exit For
                            End If
                        Next
                        If bMatch Then
                            Select Case ch.Gender
                                Case clsCharacter.GenderEnum.Male
                                    '                                   sNewHim = ch.Name
                                    If Not PossibleItKeys.Contains(ch.Key) Then PossibleHimKeys.Add(ch.Key)
                                Case clsCharacter.GenderEnum.Female
                                    '                                  sNewHer = ch.Name
                                    If Not PossibleItKeys.Contains(ch.Key) Then PossibleHerKeys.Add(ch.Key)
                                Case clsCharacter.GenderEnum.Unknown
                                    '                                 sNewIt = ch.Name
                                    If Not PossibleItKeys.Contains(ch.Key) Then PossibleItKeys.Add(ch.Key)
                            End Select
                        End If
                    Next
                Next sWord

                If sNewIt = "" Then
                    If PossibleItKeys.Count = 1 Then
                        If Adventure.htblObjects.ContainsKey(PossibleItKeys(0)) Then
                            sNewIt = Adventure.htblObjects(PossibleItKeys(0)).FullName(True)
                        Else
                            sNewIt = Adventure.htblCharacters(PossibleItKeys(0)).Name
                        End If
                    ElseIf PossibleItKeys.Count > 1 Then
                        Dim arlKeys As New StringArrayList

                        For Each sKey As String In PossibleItKeys
                            If Adventure.htblObjects.ContainsKey(sKey) Then
                                Dim ob As clsObject = Adventure.htblObjects(sKey)
                                For Each sPrefixWord As String In ob.Prefix.Split(" "c)
                                    For Each sWord As String In sWords
                                        If sPrefixWord = sWord Then
                                            arlKeys.Add(sKey)
                                            GoTo NextOb
                                        End If
                                    Next
                                Next
                            End If
NextOb:
                            If Adventure.htblCharacters.ContainsKey(sKey) Then
                                Dim ch As clsCharacter = Adventure.htblCharacters(sKey)
                                For Each sPrefixWord As String In ch.Prefix.Split(" "c)
                                    For Each sWord As String In sWords
                                        If sPrefixWord = sWord Then
                                            arlKeys.Add(sKey)
                                            GoTo NextChar
                                        End If
                                    Next
                                Next
                            End If
NextChar:
                        Next

                        If arlKeys.Count = 1 Then
                            If Adventure.htblObjects.ContainsKey(arlKeys(0)) Then
                                sNewIt = Adventure.htblObjects(arlKeys(0)).FullName(True)
                            ElseIf Adventure.htblCharacters.ContainsKey(arlKeys(0)) Then
                                sNewIt = Adventure.htblCharacters(arlKeys(0)).Name
                            End If
                        End If
                    End If
                End If

                If sNewThem = "" Then
                    If PossibleThemKeys.Count = 1 Then
                        If Adventure.htblObjects.ContainsKey(PossibleThemKeys(0)) Then
                            sNewThem = Adventure.htblObjects(PossibleThemKeys(0)).FullName(True)
                        Else
                            sNewThem = Adventure.htblCharacters(PossibleThemKeys(0)).Name
                        End If
                    ElseIf PossibleThemKeys.Count > 1 Then
                        Dim arlKeys As New StringArrayList

                        For Each sKey As String In PossibleThemKeys
                            If Adventure.htblObjects.ContainsKey(sKey) Then
                                Dim ob As clsObject = Adventure.htblObjects(sKey)
                                If ob.IsPlural Then
                                    For Each sPrefixWord As String In ob.Prefix.Split(" "c)
                                        For Each sWord As String In sWords
                                            If sPrefixWord = sWord Then
                                                arlKeys.Add(sKey)
                                                GoTo NextObT
                                            End If
                                        Next
                                    Next
                                End If
                            End If
NextObT:
                            If Adventure.htblCharacters.ContainsKey(sKey) Then
                                Dim ch As clsCharacter = Adventure.htblCharacters(sKey)
                                For Each sPrefixWord As String In ch.Prefix.Split(" "c)
                                    For Each sWord As String In sWords
                                        If sPrefixWord = sWord Then
                                            arlKeys.Add(sKey)
                                            GoTo NextCharT
                                        End If
                                    Next
                                Next
                            End If
NextCharT:
                        Next

                        If arlKeys.Count = 1 Then
                            If Adventure.htblObjects.ContainsKey(arlKeys(0)) Then
                                sNewThem = Adventure.htblObjects(arlKeys(0)).FullName(True)
                            ElseIf Adventure.htblCharacters.ContainsKey(arlKeys(0)) Then
                                sNewThem = Adventure.htblCharacters(arlKeys(0)).Name
                            End If
                        End If
                    End If
                End If

                If sNewHim = "" Then
                    If PossibleHimKeys.Count = 1 Then
                        If Adventure.htblCharacters.ContainsKey(PossibleHimKeys(0)) Then
                            sNewHim = Adventure.htblCharacters(PossibleHimKeys(0)).Name(, False, False, True)
                        End If
                    ElseIf PossibleHimKeys.Count > 1 Then
                        Dim arlKeys As New StringArrayList

                        For Each sKey As String In PossibleHimKeys
                            If Adventure.htblCharacters.ContainsKey(sKey) Then
                                Dim ch As clsCharacter = Adventure.htblCharacters(sKey)
                                For Each sPrefixWord As String In ch.Prefix.Split(" "c)
                                    For Each sWord As String In sWords
                                        If sPrefixWord = sWord Then
                                            arlKeys.Add(sKey)
                                            GoTo NextChar1
                                        End If
                                    Next
                                Next
                            End If
NextChar1:
                        Next

                        If arlKeys.Count = 1 Then
                            If Adventure.htblCharacters.ContainsKey(arlKeys(0)) Then
                                sNewHim = Adventure.htblCharacters(arlKeys(0)).Name(, False, False, True)
                            End If
                        End If
                    End If
                End If

                If sNewHer = "" Then
                    If PossibleHerKeys.Count = 1 Then
                        If Adventure.htblCharacters.ContainsKey(PossibleHerKeys(0)) Then
                            sNewHer = Adventure.htblCharacters(PossibleHerKeys(0)).Name(, False, False, True)
                        End If
                    ElseIf PossibleHerKeys.Count > 1 Then
                        Dim arlKeys As New StringArrayList

                        For Each sKey As String In PossibleHerKeys
                            If Adventure.htblCharacters.ContainsKey(sKey) Then
                                Dim ch As clsCharacter = Adventure.htblCharacters(sKey)
                                For Each sPrefixWord As String In ch.Prefix.Split(" "c)
                                    For Each sWord As String In sWords
                                        If sPrefixWord = sWord Then
                                            arlKeys.Add(sKey)
                                            GoTo NextChar2
                                        End If
                                    Next
                                Next
                            End If
NextChar2:
                        Next

                        If arlKeys.Count = 1 Then
                            If Adventure.htblCharacters.ContainsKey(arlKeys(0)) Then
                                sNewHer = Adventure.htblCharacters(arlKeys(0)).Name(, False, False, True)
                            End If
                        End If
                    End If
                End If

            Next

            If sNewIt <> "" Then sIt = sNewIt
            If sNewThem <> "" Then sThem = sNewThem
            If sNewHim <> "" Then sHim = sNewHim
            If sNewHer <> "" Then sHer = sNewHer

            If sIt = "" Then sIt = "Absolutely Nothing"
            If sThem = "" Then sThem = "Absolutely Nothing"
            If sHim = "" Then sHim = "No male"
            If sHer = "" Then sHer = "No female"

        Catch ex As Exception
            ErrMsg("Error grabbing ""it""", ex)
            sIt = "Absolutely Nothing"
        End Try

    End Sub


    'Private Sub GetMentionedObs()

    '    arlMentionedObs.Clear()
    '    sMentionedObsPattern = ""

    '    For Each ob As clsObject In Adventure.htblObjects.Values
    '        For Each sNoun As String In ob.arlNames
    '            If sInput.Contains(sNoun) Then
    '                arlMentionedObs.Add(ob.Key)
    '                Exit For ' sNoun
    '            End If
    '        Next
    '    Next

    '    Dim sb As New System.Text.StringBuilder("")
    '    For Each sKey As String In arlMentionedObs
    '        If sb.Length > 0 Then sb.Append("|")
    '        sb.Append(Adventure.htblObjects(sKey).sRegularExpressionString)
    '    Next
    '    sMentionedObsPattern = sb.ToString

    'End Sub

    Private Sub ReplaceWord(ByRef sText As String, ByVal sFind As String, ByVal sReplace As String)
        sText = sText.Replace(" " & sFind & " ", " " & sReplace & " ")
        If sText.StartsWith(sFind & " ") Then sText = sReplace & " " & sRight(sText, sText.Length - (sFind.Length + 1))
        If sText.EndsWith(" " & sFind) Then sText = sLeft(sText, sText.Length - (sFind.Length + 1)) & " " & sReplace
        If sText = sFind Then sText = sReplace
    End Sub


    Friend Sub Restart()
        OpenAdventure(Adventure.FullPath)
    End Sub


    Friend Function SaveGame(Optional ByVal bSaveAs As Boolean = False) As Boolean

        Try
#If www Then
            Display("Save function not currently available for online play.  Please <a href=""http://www.adrift.co/download"">download</a> Runner app for enhanced functionality.")
            Return False
#End If
            Dim sFilename As String = Adventure.sGameFilename
            If bSaveAs OrElse Adventure.sGameFilename = "" Then
                Dim sfd As New Windows.Forms.SaveFileDialog
                sfd.Filter = "ADRIFT Saved Games (*.tas)|*.tas|All Files (*.*)|*.*"
                sfd.FileName = sFilename
                sfd.DefaultExt = "tas"
                If sfd.FileName.Length > 3 AndAlso Not sfd.FileName.ToLower.EndsWith("tas") Then sfd.FileName = ""
                If sfd.ShowDialog() = DialogResult.Cancel Then
                    Display("Cancelled")
                    Return False
                End If
                sFilename = sfd.FileName
            End If

            If sFilename <> "" Then
                If Not sFilename.ToLower.EndsWith(".tas") Then sFilename &= ".tas"
                Adventure.sGameFilename = sFilename
                Dim ss As New StateStack
                If SaveState(ss.GetState, sFilename) Then
                    Display("Game saved")
                    Adventure.Changed = False
                    Return True
                Else
                    Display("Error saving game")
                    Return False
                End If
            End If

        Catch ex As Exception
            Display("Error saving game: " & ex.Message)
            Return False
        End Try

        Return False

    End Function


    Friend Sub Restore()

#If www Then
        Display("Restore function not currently available for online play.  Please <a href=""http://www.adrift.co/download"">download</a> Runner app for enhanced functionality."& vbCrLf & vbCrLf, True)
        Exit Sub
#End If

        Dim ofd As New Windows.Forms.OpenFileDialog
        ofd.Filter = "ADRIFT Saved Games (*.tas)|*.tas|All Files (*.*)|*.*"
        ofd.DefaultExt = "tas"
        If ofd.FileName.Length > 3 AndAlso Not ofd.FileName.ToLower.EndsWith("tas") Then ofd.FileName = ""
        ofd.ShowDialog()

        If ofd.FileName <> "" Then
            States.Clear()
            Dim ss As New StateStack
            ss.LoadState(ofd.FileName)
            Display("Game restored" & vbCrLf & vbCrLf, True)
            Adventure.eGameState = clsAction.EndGameEnum.Running
            UpdateStatusBar()
            Display(Adventure.htblLocations(Adventure.Player.Location.Key).ViewLocation & vbCrLf & vbCrLf, True)
            PrepareForNextTurn()
#If Not www Then
            fRunner.Map.RecalculateNode(Adventure.Map.FindNode(Adventure.Player.Location.LocationKey))
            fRunner.Map.SelectNode(Adventure.Player.Location.LocationKey)
#End If
        End If
    End Sub


    Friend bQuitting As Boolean = False
    Friend Function Quit(Optional ByVal bJustGame As Boolean = False) As Boolean
        If Adventure IsNot Nothing AndAlso Adventure.eGameState = clsAction.EndGameEnum.Running Then
            If Adventure.Changed Then
                Select Case MessageBox.Show("Would you like to save your current position?", "Quit Game", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        SaveGame(True)
                    Case DialogResult.No
                        ' Continue
                    Case DialogResult.Cancel
                        Return False
                End Select
            End If
        End If

        If bJustGame Then
            Adventure.eGameState = clsAction.EndGameEnum.Neutral
        Else
            If Not bQuitting Then fRunner.Close()
        End If

        Return True

    End Function


    Friend Sub Undo()
        If States.SetLastState Then
            Adventure.bDisplayedWinLose = False
#If Not www Then
            fRunner.Map.RecalculateNode(Adventure.Map.FindNode(Adventure.Player.Location.LocationKey))
            fRunner.Map.SelectNode(Adventure.Player.Location.LocationKey)
#End If
            UpdateStatusBar()
            'fRunner.Map.imgMap.Refresh()
            Display("Undone.")
        Else
            Display("Sorry, <c>undo</c> is not currently available.")
        End If
        bSystemTask = True
    End Sub


    Private Function GetBlock(ByVal sText As String) As String

        Dim cText() As Char = sText.ToCharArray
        Dim sOut As String = ""
        Dim iLevel As Integer = 0

        For Each c As Char In cText
            Select Case c
                Case "{"c, "["c
                    iLevel += 1
                Case "}"c, "]"c
                    iLevel -= 1
            End Select
            sOut &= c
            If iLevel = 0 Then Return sOut
        Next

        Return sText

    End Function


    Private Function MySplit(ByVal sText As String, ByRef iMinLength As Integer) As StringArrayList

        Dim sSplits() As String = Split(sText, "/")
        Dim sal As New StringArrayList
        Dim iLevel As Integer = 0
        Dim s As String = ""

        For Each sSplit As String In sSplits
            If iLevel > 0 Then s &= "/"
            s &= sSplit
            For i As Integer = 0 To sSplit.Length - 1
                Select Case sSplit(i)
                    Case "["c, "{"c
                        iLevel += 1
                    Case "]"c, "}"c
                        iLevel -= 1
                End Select
            Next
            If iLevel = 0 Then
                sal.Add(s)
                If s.Length < iMinLength Then iMinLength = s.Length
                s = ""
            End If
        Next

        Return sal

    End Function


    ' This should split any block, e.g. [examine/ex/x/look {at/in/under}] %object%
    ' into:
    ' examine %object%
    ' ex %object%
    ' x %object%
    ' look %object%
    ' look at %object%
    ' look in %object%
    ' look under %object%
    '
    ' [get/take/pick {up}] {the} hat {from Grandad}
    Private Function ExpandBlock(ByVal sBlock As String) As StringArrayList

        Dim sal As New StringArrayList

        If sBlock = "" Then
            sal.Add("")
            Return sal
        End If

        Dim sPre As String = System.Text.RegularExpressions.Regex.Replace(sBlock, "({|\[).*$", "")

        'If sPre.Length > txtInput.TextLength - 2 Then
        '    sal.Add(sPre)
        '    Return sal
        'End If

        Dim sMid As String = GetBlock(sRight(sBlock, sBlock.Length - sPre.Length))
        Dim salPost As StringArrayList = Nothing

        If sMid <> "" Then
            Dim bOptional As Boolean = False
            If sLeft(sMid, 1) = "{" Then
                salPost = ExpandBlock(sRight(sBlock, sBlock.Length - sMid.Length - sPre.Length))
                For Each sPost As String In salPost
                    sal.Add(sPre & sPost)
                Next
                bOptional = True
            End If
            sMid = Mid(sMid, 2, sMid.Length - 2)

            Dim iMinLength As Integer = Integer.MaxValue
            Dim sSplits As StringArrayList = MySplit(sMid, iMinLength)
            If salPost Is Nothing AndAlso sPre.Length + iMinLength <= fRunner.txtInput.TextLength - 2 Then
                salPost = ExpandBlock(sRight(sBlock, sBlock.Length - (sMid.Length + 2) - sPre.Length))
            End If

            For Each sSplit As String In sSplits
                Dim salSplit As StringArrayList = ExpandBlock(sSplit)
                For Each s As String In salSplit
                    If bOptional Then s = "@@@" & s
                    If salPost IsNot Nothing Then
                        For Each sPost As String In salPost
                            If s <> "" AndAlso sPost <> "" AndAlso Not s.EndsWith(" ") AndAlso Not sPost.StartsWith(" ") Then sPost = " " & sPost
                            sal.Add(sPre & s & sPost)
                            If sal.Count > 1000 Then Return sal ' PK Girl can return millions of possibilities - Yikes, need to redesign!
                        Next
                    Else
                        sal.Add(sPre & s)
                    End If
                Next
            Next
        Else
            salPost = ExpandBlock(sRight(sBlock, sBlock.Length - sMid.Length - sPre.Length))
            For Each sPost As String In salPost
                sal.Add(sPre & sPost)
                If sal.Count > 1000 Then Return sal
            Next
        End If

        Return sal

    End Function


    Friend Sub DoAutoComplete()

        Dim txtInput As RichTextBox = fRunner.txtInput
        Dim sWords() As String = txtInput.Text.Substring(2).Split(" "c)
        Dim node As AutoComplete = root
        'Dim obnode As AutoComplete = obroot

        ' i             is exact match, has longer word
        ' in            is exact match, no longer word for some tasks, longer word for other
        ' inv           is exact match, has longer word
        ' inve          no exact match, has longer word
        ' inventory     is exact match, no longer word

        Dim salAllowedTasks As New StringArrayList
        For Each sWord As String In sWords

            Dim bLongerWord As Boolean = False
            If Not node Is Nothing Then
                If node.htblChildren.ContainsKey(sWord) Then
                    ' Ok, we've got a complete word.  Let's see if a task exists with longer version of it...
                    Dim acNode As AutoComplete = node.htblChildren(sWord)
                    For Each sTask As String In acNode.salTasks
                        'If htblCompleteableGeneralTasks.ContainsKey(sTask) Then
                        For Each acChildNode As AutoComplete In node.htblChildren
                            If Not acChildNode Is acNode Then
                                If acChildNode.salTasks.Contains(sTask) Then
                                    If acChildNode.sWord.StartsWith(sWord) AndAlso acChildNode.sWord.Length > sWord.Length Then
                                        ' Ok, we've found a longer applicable word
                                        bLongerWord = True
                                        salAllowedTasks.Add(sTask)
                                        'GoTo AfterLongerWord
                                    End If
                                End If
                            End If
                        Next
                        'End If
                    Next
                End If
                'AfterLongerWord:                    

                ' We want it to select the word if it's a whole word in our list, and there's not a longer one available
                If node.htblChildren.ContainsKey(sWord) AndAlso (txtInput.Text.EndsWith(sWord & " ") OrElse Array.IndexOf(sWords, sWord) < sWords.Length - 1) Then
                    node = node.htblChildren(sWord)
                    ListChildren(node, False)
                Else

                    If sWord <> "" OrElse (node.htblChildren.Count = 1 AndAlso Not node.htblChildren.ItemByIndex(0).sWord.StartsWith("%")) Then
                        For Each sChild As AutoComplete In node.htblChildren
                            Dim bOk As Boolean = False
                            If salAllowedTasks.Count = 0 Then
                                bOk = True
                            Else
                                For Each sTask As String In salAllowedTasks
                                    If sChild.salTasks.Contains(sTask) Then
                                        bOk = True
                                        Exit For
                                    End If
                                Next
                            End If
                            If bOk Then
                                Select Case sChild.sWord
                                    Case "%direction%"
                                        For d As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest
                                            Dim sal As StringArrayList = ExpandBlock(DirectionRE(d))
                                            For Each sDir As String In sal
                                                If sDir = sWord Then
                                                    node = node.htblChildren(sChild.sWord)
                                                    ListChildren(node, False)
                                                    GoTo NextWord
                                                ElseIf sDir.StartsWith(sWord) Then
                                                    Dim sRemainder As String = sDir.Substring(sWord.Length)

                                                    txtInput.SelectedText = sRemainder
                                                    txtInput.SelectionStart = txtInput.Text.Length - sRemainder.Length
                                                    txtInput.SelectionLength = sRemainder.Length
                                                    Exit Sub
                                                End If
                                            Next
                                        Next

                                    Case "%object1%", "%object2%", "%object3%", "%object4%", "%object5%", "%objects%"
                                        ' for all completable tasks in node.saltasks
                                        ' loop thru all objects refs that could pass the task          
                                        ' Grab the text matching the actual object
                                        Dim sObName As String = ""
                                        For i As Integer = sWords.Length - 1 To 0 Step -1
                                            If sWords(i) = node.sWord Then
                                                For iOb As Integer = i + 1 To sWords.Length - 1
                                                    sObName &= sWords(iOb) & " "
                                                Next
                                            End If
                                        Next
                                        If sObName.Length > 1 Then sObName = sLeft(sObName, sObName.Length - 1)
                                        Dim sObWords As String() = sObName.Split(" "c)

                                        Dim obnode As AutoComplete = obroot

                                        If sChild.sWord = "%objects%" Then
                                            For Each sAllWord As String In New String() {"all", "everything"}
                                                If Not obnode.htblChildren.ContainsKey(sAllWord) Then
                                                    obnode.htblChildren.Add(New AutoComplete(sAllWord))
                                                End If
                                            Next
                                        End If
                                        For Each sObWord As String In sObWords
                                            If obnode.htblChildren.ContainsKey(sObWord) AndAlso (txtInput.Text.EndsWith(sObWord & " ") OrElse Array.IndexOf(sObWords, sObWord) < sObWords.Length) Then
                                                obnode = obnode.htblChildren(sObWord)
                                                ListChildren(obnode, True)
                                                If obnode.htblChildren.Count = 0 Then
                                                    node = node.htblChildren(sChild.sWord)
                                                    ListChildren(node, False)
                                                    GoTo NextObWord
                                                End If
                                            Else
                                                If sObWord <> "" OrElse obnode.htblChildren.Count = 1 Then
                                                    For Each sObChild As AutoComplete In obnode.htblChildren
                                                        If sObChild.sWord.StartsWith(sObWord) AndAlso (sObChild.sWord = "all" OrElse sObChild.sWord = "everything" OrElse PlayerSeeOb(sObChild.salTasks, sChild.salTasks)) Then
                                                            'Debug.WriteLine(sChild.sWord)
                                                            Dim sRemainder As String = sObChild.sWord.Substring(sObWord.Length)

                                                            txtInput.SelectedText = sRemainder
                                                            txtInput.SelectionStart = txtInput.Text.Length - sRemainder.Length
                                                            txtInput.SelectionLength = sRemainder.Length
                                                            Exit Sub ' For
                                                        End If
                                                    Next
                                                End If
                                            End If

NextObWord:
                                        Next

                                    Case "%character1%", "%character2%", "%character3%", "%character4%", "character5%", "%characters%"
                                        ' for all completable tasks in node.saltasks
                                        ' loop thru all objects refs that could pass the task          
                                        ' Grab the text matching the actual object
                                        Dim sChName As String = ""
                                        For i As Integer = sWords.Length - 1 To 0 Step -1
                                            If sWords(i) = node.sWord Then
                                                For iCh As Integer = i + 1 To sWords.Length - 1
                                                    sChName &= sWords(iCh) & " "
                                                Next
                                            End If
                                        Next
                                        If sChName.Length > 1 Then sChName = sLeft(sChName, sChName.Length - 1)
                                        Dim sChWords As String() = sChName.Split(" "c)

                                        Dim chnode As AutoComplete = chroot

                                        For Each sChWord As String In sChWords
                                            If chnode.htblChildren.ContainsKey(sChWord) AndAlso (txtInput.Text.EndsWith(sChWord & " ") OrElse Array.IndexOf(sChWords, sChWord) < sChWords.Length) Then
                                                chnode = chnode.htblChildren(sChWord)
                                                'ListChildren(chnode, True)
                                                If chnode.htblChildren.Count = 0 Then
                                                    node = node.htblChildren(sChild.sWord)
                                                    'ListChildren(node, False)
                                                    GoTo NextChWord
                                                End If
                                            Else
                                                If sChWord <> "" OrElse chnode.htblChildren.Count = 1 Then
                                                    For Each sObChild As AutoComplete In chnode.htblChildren
                                                        If sObChild.sWord.StartsWith(sChWord) AndAlso PlayerSeeCh(sObChild.salTasks, sChild.salTasks) Then
                                                            'Debug.WriteLine(sChild.sWord)
                                                            Dim sRemainder As String = sObChild.sWord.Substring(sChWord.Length)

                                                            txtInput.SelectedText = sRemainder
                                                            txtInput.SelectionStart = txtInput.Text.Length - sRemainder.Length
                                                            txtInput.SelectionLength = sRemainder.Length
                                                            Exit Sub ' For
                                                        End If
                                                    Next
                                                End If
                                            End If

NextChWord:
                                        Next

                                        'If obnode.htblChildren.ContainsKey(sWord) AndAlso (txtInput.Text.EndsWith(sWord & " ") OrElse Array.IndexOf(sWords, sWord) < sWords.Length) Then
                                        '    obnode = obnode.htblChildren(sWord)
                                        '    ListChildren(obnode, True)
                                        '    If obnode.htblChildren.Count = 0 Then
                                        '        node = node.htblChildren(sChild.sWord)
                                        '        ListChildren(node, False)
                                        '        GoTo NextWord
                                        '    End If
                                        'Else
                                        '    If sWord <> "" OrElse obnode.htblChildren.Count = 1 Then
                                        '        For Each sObChild As AutoComplete In obnode.htblChildren
                                        '            If sObChild.sWord.StartsWith(sWord) AndAlso PlayerSeeOb(sObChild.salTasks, sChild.salTasks) Then
                                        '                'Debug.WriteLine(sChild.sWord)
                                        '                Dim sRemainder As String = sObChild.sWord.Substring(sWord.Length)

                                        '                txtInput.SelectedText = sRemainder
                                        '                txtInput.SelectionStart = txtInput.Text.Length - sRemainder.Length
                                        '                txtInput.SelectionLength = sRemainder.Length
                                        '                Exit Sub ' For
                                        '            End If
                                        '        Next
                                        '    End If
                                        'End If

                                    Case Else
                                        If sChild.sWord.StartsWith(sWord) AndAlso PlayerCanExTask(sChild.salTasks) Then
                                            'Debug.WriteLine(sChild.sWord)
                                            Dim sRemainder As String = sChild.sWord.Substring(sWord.Length)

                                            txtInput.SelectedText = sRemainder
                                            txtInput.SelectionStart = txtInput.Text.Length - sRemainder.Length
                                            txtInput.SelectionLength = sRemainder.Length
                                            Exit Sub ' For
                                        End If
                                End Select
                            End If
                        Next
                    End If
                End If
            End If
NextWord:
        Next

    End Sub


    ' This function should return True if, for any Task in salTaskList
    ' any Object in salObList could pass all the task references specific to that reference
    Private Function PlayerSeeOb(ByVal salObList As StringArrayList, ByVal salTaskList As StringArrayList) As Boolean

        For Each sKey As String In salObList
            If Adventure.Player.CanSeeObject(sKey) Then Return True
        Next

        Return False

    End Function


    Private Function PlayerSeeCh(ByVal salChList As StringArrayList, ByVal salTaskList As StringArrayList) As Boolean

        For Each sKey As String In salChList
            If Adventure.Player.CanSeeCharacter(sKey) Then Return True
        Next

        Return False

    End Function


    ' This function should return True if, not including any references, the task
    ' could be completed
    Private Function PlayerCanExTask(ByVal salList As StringArrayList) As Boolean

        For Each sKey As String In salList
            'Display(sKey, True) ' Debugging...
            If Adventure.htblTasks(sKey).IsCompleteable Then Return True
        Next

        Return False

    End Function


    Private Sub ListChildren(ByVal node As AutoComplete, ByVal bObs As Boolean)

        If node.htblChildren.Count > 0 Then Debug.WriteLine("")
        For Each child As AutoComplete In node.htblChildren
            If Not bObs OrElse PlayerSeeOb(child.salTasks, node.salTasks) Then Debug.WriteLine(child.sWord)
        Next

    End Sub


    Private Sub SortNodes(ByVal nodes As AutoCompleteSortedArrayList)

        For Each node As AutoComplete In nodes
            If node.htblChildren.Count > 0 Then SortNodes(node.htblChildren)
        Next
        nodes.Sort()

        ''Exit Sub
        'For Each node As AutoComplete In nodes
        '    Debug.WriteLine(node.sWord)
        'Next
        'Debug.WriteLine("---")
    End Sub


    Private Sub PrintOutNodes(ByVal node As AutoComplete, ByVal iLevel As Integer)

        For i As Integer = 0 To iLevel - 1
            'DisplayDebug("   ")
            Debug.Write("   ")
        Next
        'DisplayDebug(node.sWord & vbCrLf)
        Debug.WriteLine(node.sWord & " [" & node.iPriority & "]")
        For Each n As AutoComplete In node.htblChildren
            PrintOutNodes(n, iLevel + 1)
        Next

    End Sub


    Public Sub BuildAutos()

        If Not bAutoComplete Then Exit Sub
        If fRunner.txtInput Is Nothing OrElse fRunner.txtInput.IsDisposed Then Exit Sub
        If fRunner.txtInput.TextLength < 2 Then Exit Sub

        Dim dtAutos As DateTime = Now
        Dim sInput As String = fRunner.txtInput.Text.Substring(2)
        sInput = sLeft(sInput, fRunner.txtInput.SelectionStart - 2)

        root = New AutoComplete
        root.sWord = Nothing

        For Each tas As clsTask In htblCompleteableGeneralTasks.Values
            If tas.AutoFillPriority > 0 Then
                For Each sCommand As String In tas.arlCommands
                    Dim salList As StringArrayList = ExpandBlock(sCommand)
                    For Each sList As String In salList
                        If sInput = "" OrElse sList.StartsWith(sInput) OrElse sList.Contains("%") Then
                            Dim iPriorityOffset As Integer = 0
                            sList = sList.Replace("*", "")
                            While sList.Contains("  ")
                                sList = sList.Replace("  ", " ")
                            End While
                            If sList.Contains("@@@") Then ' This prevents "{walk} west" from giving us w[alk] instead of w[est]
                                If sList.StartsWith("@@@") Then iPriorityOffset = 1
                                sList = sList.Replace("@@@", "")
                            End If
                            If sList.StartsWith(" ") Then sList = sRight(sList, sList.Length - 1)
                            'Debug.WriteLine(sList)
                            Dim node As AutoComplete = root
                            Dim sWords() As String = Split(sList, " ")
                            For Each sWord As String In sWords
                                If Not node.htblChildren.ContainsKey(sWord) Then
                                    Dim newnode As New AutoComplete
                                    newnode.sWord = sWord
                                    node.htblChildren.Add(newnode)
                                End If
                                node = node.htblChildren(sWord)
                                If Not node.salTasks.Contains(tas.Key) Then node.salTasks.Add(tas.Key)
                                If tas.AutoFillPriority < node.iPriority Then node.iPriority = tas.AutoFillPriority + iPriorityOffset
                            Next
                        End If
                    Next
                Next
            End If
        Next

        'PrintOutNodes(root, 0)

        If obroot Is Nothing Then
            obroot = New AutoComplete
            obroot.sWord = Nothing

            For Each ob As clsObject In Adventure.htblObjects.Values
                Dim salList As StringArrayList = ExpandBlock(ob.sRegularExpressionString(True))
                For Each sList As String In salList
                    Dim iPriorityOffset As Integer = 0
                    While sList.Contains("  ")
                        sList = sList.Replace("  ", " ")
                    End While
                    If sList.Contains("@@@") Then ' This prevents "{space} ship" from giving us s[pace] instead of s[hip]
                        If sList.StartsWith("@@@") Then iPriorityOffset = 1
                        sList = sList.Replace("@@@", "")
                    End If
                    If sList.StartsWith(" ") Then sList = sRight(sList, sList.Length - 1)
                    Dim node As AutoComplete = obroot
                    Dim sWords() As String = Split(sList, " ")
                    For Each sWord As String In sWords
                        If Not node.htblChildren.ContainsKey(sWord) Then
                            'Dim newnode As New AutoComplete(sWord)
                            'newnode.sWord = sWord
                            'node.htblChildren.Add(newnode)
                            node.htblChildren.Add(New AutoComplete(sWord))
                        End If
                        node = node.htblChildren(sWord)
                        If Not node.salTasks.Contains(ob.Key) Then node.salTasks.Add(ob.Key)
                        node.iPriority = iPriorityOffset
                    Next
                Next
            Next
            SortNodes(obroot.htblChildren)

            chroot = New AutoComplete
            chroot.sWord = Nothing

            For Each ch As clsCharacter In Adventure.htblCharacters.Values
                Dim salList As StringArrayList = ExpandBlock(ch.sRegularExpressionString(True))
                For Each sList As String In salList
                    While sList.Contains("  ")
                        sList = sList.Replace("  ", " ")
                    End While
                    If sList.StartsWith(" ") Then sList = sRight(sList, sList.Length - 1)
                    Dim node As AutoComplete = chroot
                    Dim sWords() As String = Split(sList, " ")
                    For Each sWord As String In sWords
                        If Not node.htblChildren.ContainsKey(sWord) Then
                            Dim newnode As New AutoComplete
                            newnode.sWord = sWord
                            node.htblChildren.Add(newnode)
                        End If
                        node = node.htblChildren(sWord)
                        If Not node.salTasks.Contains(ch.Key) Then node.salTasks.Add(ch.Key)
                    Next
                Next
            Next
        End If

        'root.htblChildren.Sort()
        SortNodes(root.htblChildren)
        'DebugPrint(ItemEnum.General, "", DebugDetailLevelEnum.High, "Built Autos")

        'Debug.WriteLine("-----------------------------")
        'PrintOutNodes(root, 0)

        Debug.WriteLine("Autos built in " & Now.Subtract(dtAutos).ToString)

    End Sub


    Private Function EvaluateInput(ByVal iMinimumPriority As Integer) As String

        Dim cCursor As Char = "Ø"c
        Dim cCommentCursor As Char = "@"c
        Dim sCursorFont As String = "Wingdings"

#If Mono Then
        cCursor = ChrW(&H27A2)
        cCommentCursor = ChrW(&H270D)
        sCursorFont = "OpenSymbol"
#End If

        Dim bComment As Boolean = False
#If Not www Then
        bComment = (fRunner.txtInput.Text.Length > 0 AndAlso fRunner.txtInput.Text(0) = cCommentCursor)
#End If

        InitialiseInputBox()

        If bComment Then
            Display("<c><font face=""" & sCursorFont & """ size=18>" & cCommentCursor & "</font> " & sInput & "</c>" & vbCrLf, True, False)
            Return ""
        End If

        If iMinimumPriority = 0 Then
            Display("<c><font face=""" & sCursorFont & """ size=14>" & cCursor & "</font> " & sInput & "</c>" & vbCrLf, True, False)
            sInput = sInput.ToLower
            If ContainsWord(sInput, "it") Then
                Display("<c>(" & sIt & ")</c>" & vbCrLf, True)
                ReplaceWord(sInput, "it", sIt)
                'sInput = sInput.Replace(" it ", " " & sIt & " ")
                'If sInput.StartsWith("it ") Then sInput = sIt & " " & sRight(sInput, sInput.Length - 3)
                'If sInput.EndsWith(" it") Then sInput = sLeft(sInput, sInput.Length - 3) & " " & sIt
                'If sInput = "it" Then sInput = sIt
            End If
            If ContainsWord(sInput, "them") Then
                Display("<c>(" & sThem & ")</c>" & vbCrLf, True)
                ReplaceWord(sInput, "them", sThem)
            End If
            If ContainsWord(sInput, "him") Then
                Display("<c>(" & sHim & ")</c>" & vbCrLf, True)
                ReplaceWord(sInput, "him", sHim)
            End If
            If ContainsWord(sInput, "her") Then
                Display("<c>(" & sHer & ")</c>" & vbCrLf, True)
                ReplaceWord(sInput, "her", sHer)
            End If
            If (sInput = "again" OrElse sInput = "g") AndAlso salCommands.Count > 3 Then
                Display("<c>(" & salCommands(salCommands.Count - 3) & ")</c>" & vbCrLf, True)
                sInput = salCommands(salCommands.Count - 3)
                salCommands.RemoveAt(salCommands.Count - 2) ' Don't store 'again'
            End If
            GrabIt()

            'If ContainsWord(sInput, "me") Then ReplaceWord(sInput, "me", Adventure.Player.Name)

            If CBool(GetSetting("ADRIFT", "Runner", "BlankLine", "0")) Then Display(vbCrLf)
        End If

        sInput = sInput.ToLower

        ' Don't actually respond to the tasks here, in case the user has created a task to override the system one.
        If Adventure.eGameState <> clsAction.EndGameEnum.Running Then
            Select Case sInput
                Case "restart"
                    Restart()
                Case "restore"
                    Restore()
                Case "quit"
                    Quit()
                Case "undo"
                    Undo()
                    Display(vbCrLf & vbCrLf, True)
                Case Else
                    Display("Please give one of the answers above." & vbCrLf)
            End Select
            Return ""
        End If

        Dim sTaskKey As String = Nothing

        If sAmbTask IsNot Nothing Then
            sTaskKey = ResolveAmbiguity(sInput)

            If Not sTaskKey Is Nothing Then
                sRestrictionTextMulti = ""
                sRestrictionText = sRestrictionTextMulti
            End If
        Else
            sLastProperInput = sInput
            Erase NewReferences
        End If

        ' only run this if we're not resolving an ambiguity or it left no tasks
        If sTaskKey Is Nothing Then
            Dim cRefCopy(-1) As clsNewReference
            Dim bCopied As Boolean = False
            Dim sRememberAmbTask As String = Nothing
            Adventure.sReferencedText = ""
            ' If Not sAmbTask Is Nothing Then remember References, so we can reapply them if we don't get a new command
            If Not sAmbTask Is Nothing Then
                ReDim cRefCopy(NewReferences.Length - 1)
                Array.Copy(NewReferences, cRefCopy, NewReferences.Length)
                bCopied = True
                sRememberAmbTask = sAmbTask
            End If
            'GetMentionedObs()
            sTaskKey = GetGeneralTask(sInput, iMinimumPriority, False)
            If Adventure.sReferencedText = "" Then Adventure.sReferencedText = sInput
            ' And If sTaskKey Is Nothing Then restore here
            If sTaskKey Is Nothing AndAlso sAmbTask Is Nothing AndAlso Not sRememberAmbTask Is Nothing Then sAmbTask = sRememberAmbTask
            If sTaskKey Is Nothing AndAlso Not sAmbTask Is Nothing AndAlso bCopied Then
                ReDim NewReferences(cRefCopy.Length - 1)
                Array.Copy(cRefCopy, NewReferences, cRefCopy.Length)
            End If

        End If

        If Not sAmbTask Is Nothing AndAlso sTaskKey Is Nothing Then
            ' Display ambiguity question
            DisplayAmbiguityQuestion()
        Else
            sAmbTask = Nothing
            If sTaskKey IsNot Nothing Then
                'RemoveExcepts()
                'htblReferencesFail.Clear()
                'CalcFailRefs(References, Adventure.htblTasks(sTaskKey).arlRestrictions)
                NewReferences = Adventure.htblTasks(sTaskKey).NewReferencesWorking
                AttemptToExecuteTask(sTaskKey)

                While Adventure.qTasksToRun.Count > 0
                    Dim sKey As String = Adventure.qTasksToRun.Dequeue
                    AttemptToExecuteTask(sKey, True)
                End While

                If sOutputText = "" Then
                    If iMinimumPriority = 0 Then Display(Adventure.NotUnderstood)
                Else
                    ' Ok, successful task.  So long as we didn't execute a system task
                    If Not bSystemTask Then TurnBasedStuff()
                    Adventure.Changed = True
                End If
            Else
                If iMinimumPriority = 0 Then
                    If Adventure.eGameState = clsAction.EndGameEnum.Running Then
                        Select Case sInput
                            Case "restart"
                                Restart()
                                sOutputText = "***SYSTEM***"
                            Case "restore"
                                Restore()
                                sOutputText = "***SYSTEM***"
                            Case "save"
                                SaveGame()
                            Case "save as", "saveas"
                                SaveGame(True)
                            Case "quit"
                                Quit(True)
                            Case "undo"
                                Undo()
                            Case "wait", "z"
                                sOutputText = "Time passes..."
                                For i As Integer = 0 To 2
                                    TurnBasedStuff()
                                Next
                            Case Else
                                Dim bDoneStuff As Boolean = False
                                If sInput.StartsWith("save ") AndAlso CharacterCount(sInput, " "c) = 1 Then
                                    Dim sFilename As String = sInput.Replace("save ", "")
                                    For Each c As Char In IO.Path.GetInvalidPathChars
                                        If sFilename.Contains(c) Then
                                            Display("Bad Filename")
                                            bDoneStuff = True
                                            Exit For
                                        End If
                                    Next
                                    If Not bDoneStuff Then
                                        If Not sFilename.Contains(IO.Path.DirectorySeparatorChar) Then
                                            If Adventure.sGameFilename <> "" Then
                                                Dim sPath As String = IO.Path.GetDirectoryName(Adventure.sGameFilename)
                                                sFilename = sPath & IO.Path.DirectorySeparatorChar & sFilename
                                            End If
                                        End If
                                        Adventure.sGameFilename = sFilename
                                        SaveGame()
                                        bDoneStuff = True
                                    End If
                                End If
                                If Not bDoneStuff Then Display(Adventure.NotUnderstood)
                        End Select
                    End If
                End If
            End If
            If iMinimumPriority = 0 AndAlso sOutputText <> "***SYSTEM***" Then Display(vbCrLf)
        End If

        If sOutputText <> "***SYSTEM***" Then
            If iMinimumPriority = 0 Then
                Display(vbCrLf, True)
                DebugPrint(ItemEnum.General, "", DebugDetailLevelEnum.Low, "ENDOFTURN")
            End If
            Debug.WriteLine(Now.Subtract(dtDebug).ToString())

            UpdateStatusBar()
        End If

        Return sOutputText

    End Function



    Public Function StripCarats(ByVal sText As String) As String
        Dim re As New System.Text.RegularExpressions.Regex("<(.|\n)+?>")
        Return re.Replace(sText, "")
    End Function



    Public Sub UpdateStatusBar()
        'fRunner.UltraStatusBar1.Text = Adventure.htblLocations(Adventure.Player.Location.Key).ShortDescription
        If Adventure Is Nothing Then Exit Sub

        Try
            Dim sDescription As String = ""
            Dim sScore As String = ""

            If Adventure.eGameState = clsAction.EndGameEnum.Running Then
                If Adventure.Player IsNot Nothing Then
                    If Adventure.Player.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.Hidden OrElse Adventure.Player.Location.LocationKey = "" Then
                        sDescription = "(Nowhere)"
                    Else
                        sDescription = StripCarats(ReplaceALRs(Adventure.htblLocations(Adventure.Player.Location.LocationKey).ShortDescription.ToString))
                        If Adventure.Player.Location.ExistWhere <> clsCharacterLocation.ExistsWhereEnum.AtLocation Then
                            sDescription &= " (" & Adventure.Player.Location.ToString & ")"
                        End If
                    End If
                End If
            Else
                sDescription = "Game Over"
            End If

            If Adventure.MaxScore > 0 Then sScore = "Score: " & Adventure.Score

            fRunner.UpdateStatusBar(sDescription, sScore)

#If Not www Then
            If fRunner.Map.Map IsNot Nothing Then
                Dim node As MapNode = fRunner.Map.Map.FindNode(Adventure.Player.Location.LocationKey)
                If node IsNot Nothing Then node.Text = sDescription
            End If
#End If
            '            With fRunner.StatusBar
            '                '#If Not www Then
            '                If Adventure.eGameState = clsAction.EndGameEnum.Running Then
            '                    If Adventure.Player IsNot Nothing Then
            '                        If Adventure.Player.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.Hidden OrElse Adventure.Player.Location.LocationKey = "" Then
            '                            .Panels("Description").Text = "(Nowhere)"
            '                        Else
            '                            .Panels("Description").Text = StripCarats(ReplaceALRs(Adventure.htblLocations(Adventure.Player.Location.LocationKey).ShortDescription.ToString))
            '#If Not www Then
            '                            If fRunner.Map.Map IsNot Nothing Then
            '                                Dim node As MapNode = fRunner.Map.Map.FindNode(Adventure.Player.Location.LocationKey)
            '                                If node IsNot Nothing Then node.Text = .Panels("Description").Text
            '                            End If
            '#End If
            '                            If Adventure.Player.Location.ExistWhere <> clsCharacterLocation.ExistsWhereEnum.AtLocation Then
            '                                .Panels("Description").Text &= " (" & Adventure.Player.Location.ToString & ")"
            '                            End If
            '                        End If
            '                    End If
            '                Else
            '                    .Panels("Description").Text = "Game Over"
            '                End If
            '                If Adventure.MaxScore > 0 Then
            '                    .Panels("Score").Text = "Score: " & Adventure.Score
            '#If Mono OrElse www Then
            '                Else
            '                    .Panels("Score").Text = ""
            '                    .Panels("Score").MinWidth = 1
            '                    .Panels("Score").Width = 1
            '#Else
            '                    .Panels("Score").Visible = True
            '                Else
            '                    .Panels("Score").Visible = False
            '#End If

            '                End If
            '                '#End If
            '            End With
        Catch exOD As ObjectDisposedException
            ' Fail silently
        Catch ex As Exception
            ErrMsg("UpdateStatusBar error", ex)
        End Try

    End Sub

    Friend bEventsRunning As Boolean = False
    Private Sub TurnBasedStuff()

        For Each c As clsCharacter In Adventure.htblCharacters.Values
            For Each w As clsWalk In c.arlWalks
                w.IncrementTimer()
            Next
        Next
        bEventsRunning = True
        For Each e As clsEvent In Adventure.htblEvents.Values
            e.IncrementTimer()
        Next
        bEventsRunning = False

    End Sub



    'Private Sub RemoveExcepts()

    '    If References Is Nothing Then Exit Sub

    '    ' First, remove any non-except refs where we have an except ref
    '    For iRef As Integer = 0 To References.Length - 1
    '        For Each srEx As SingleRef In References(iRef).alReferences
    '            If srEx.bExcept Then
    '                For Each srOk As SingleRef In References(iRef).alReferences
    '                    If Not srOk.bExcept Then
    '                        If srEx.salWhat(0) = srOk.salWhat(0) Then srOk.salWhat(0) = ""
    '                    End If
    '                Next srOk
    '            End If
    '        Next srEx
    '    Next
    '    ' Then remove the except refs
    '    For iRef As Integer = 0 To References.Length - 1
    '        For Each srEx As SingleRef In References(iRef).alReferences
    '            If srEx.bExcept Then srEx.salWhat(0) = ""
    '        Next srEx
    '    Next

    '    RemoveBlankRefs()

    'End Sub


    'Private Sub RemoveBlankRefs()

    '    For iRef As Integer = References.Length - 1 To 0 Step -1
    '        For irefSA As Integer = References(iRef).alReferences.Count - 1 To 0 Step -1
    '            If References(iRef).alReferences(irefSA).salWhat.Count > 0 Then
    '                'If References(iRef).alReferences(irefSA).salWhat(0) = "" Then
    '                '    References(iRef).alReferences.RemoveAt(irefSA)
    '                '    If References(iRef).alReferences(irefSA).salWhat.Count = 0 Then Exit For
    '                'End If
    '                For iSal As Integer = References(iRef).alReferences(irefSA).salWhat.Count - 1 To 0 Step -1
    '                    If References(iRef).alReferences(irefSA).salWhat(iSal) = "" Then
    '                        References(iRef).alReferences(irefSA).salWhat.RemoveAt(iSal)
    '                    End If
    '                Next
    '                If References(iRef).alReferences(irefSA).salWhat.Count = 0 Then
    '                    References(iRef).alReferences.RemoveAt(irefSA)
    '                End If
    '            End If
    '        Next
    '        If References(iRef).alReferences.Count = 0 Then
    '            If References.Length = 1 Then
    '                ReDim References(-1)
    '            Else
    '                For iR As Integer = iRef To References.Length - 2
    '                    References(iR) = References(iR + 1)
    '                Next
    '                ReDim Preserve References(References.Length - 1)
    '            End If
    '        End If
    '    Next

    'End Sub


    Private Sub PrepareForNextTurn()
#If Not www Then
        fRunner.Map.imgMap.Refresh()
#End If
        If Not bSystemTask AndAlso Adventure.eGameState = clsAction.EndGameEnum.Running Then States.RecordState()

        bTaskHasOutput = False

        ' Mark objects as seen for all the characters
        For Each ch As clsCharacter In Adventure.htblCharacters.Values
            For Each ob As clsObject In Adventure.htblObjects.Values
                If ch.CanSeeObject(ob.Key) Then ob.SeenBy(ch.Key) = True
            Next
            'For Each l As clsLocation In Adventure.htblLocations.Values
            '    If ch.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation Then
            '        l.SeenBy(ch.Key) = True
            '    End If
            'Next
            For Each sLocKey As String In ch.LocationRoots.Keys
                If sLocKey <> HIDDEN Then Adventure.htblLocations(sLocKey).SeenBy(ch.Key) = True
            Next
            For Each ch2 As clsCharacter In Adventure.htblCharacters.Values
                If Not ch.SeenBy(ch2.Key) AndAlso ch.CanSeeCharacter(ch2.Key) Then
                    ch.SeenBy(ch2.Key) = True
                End If
            Next
            'ch.bTurnMention = False
            ch.dictHasRouteCache.Clear()
            If ch.Introduced Then
                If ch IsNot Adventure.Player AndAlso Not Adventure.Player.CanSeeCharacter(ch.Key) Then
                    ch.Introduced = False
                End If
            End If
        Next
        For Each eGen As clsCharacter.GenderEnum In New clsCharacter.GenderEnum() {clsCharacter.GenderEnum.Male, clsCharacter.GenderEnum.Female, clsCharacter.GenderEnum.Unknown}
            Adventure.lCharMentionedThisTurn(eGen) = New Generic.List(Of String)
        Next

        'htblCompleteableGeneralTasks = Adventure.htblTasks
        ' Fill htblCompleteableGeneralTasks with tasks
        ' This is WAY too slow... 
        htblCompleteableGeneralTasks.Clear()
        For Each tas As clsTask In Adventure.Tasks(clsAdventure.TasksListEnum.GeneralTasks).Values
            If tas.TaskType = clsTask.TaskTypeEnum.General AndAlso (Not tas.Completed OrElse tas.Repeatable) Then
                htblCompleteableGeneralTasks.Add(tas, tas.Key)
            End If
        Next

        ' We can't do this, because we need failing restriction tasks also
        ' but we can if we only include any with text output...
        'Dim t As New Threading.Thread(AddressOf CalculateCompleteableTasks)
        't.IsBackground = True
        't.Name = "Background"
        't.Start()
        iPrepProgress = 2

        htblVisibleObjects.Clear()
        htblSeenObjects.Clear()
        For Each ob As clsObject In Adventure.htblObjects.Values
            If ob.SeenBy(Adventure.Player.Key) Then htblSeenObjects.Add(ob, ob.Key)
            If ob.IsVisibleTo(Adventure.Player.Key) Then htblVisibleObjects.Add(ob, ob.Key)
            ob.PrevParent = ob.Parent
        Next
        For Each ch As clsCharacter In Adventure.htblCharacters.Values
            ch.PrevParent = ch.Parent
        Next

        'Adventure.LastPerspective = clsCharacter.PerspectiveEnum.None
        'Perspectives.Clear()
        PronounKeys.Clear()
        'PronounKeys.Add(Adventure.Player.Key, PronounEnum.Subjective, 0) ' Because we are always the subject of any sentence

        BuildAutos()
        'CalcValidReferences()

    End Sub



    ' Runs this on a background thread so if user types a command we just resume where we are
    Private Sub CalculateCompleteableTasks()

        Dim htblTasks As New TaskHashTable

        Try
            ' TODO: This should only add if completeable in current room, i.e. pass all restrictions ignoring ones regarding references.
            For Each sKey As String In htblCompleteableGeneralTasks.Keys
                Dim task As clsTask = Adventure.htblTasks(sKey)
                If iPrepProgress = 1 OrElse task.HasReferences OrElse task.IsCompleteable Then htblTasks.Add(task, sKey)
            Next
        Catch
            htblTasks = htblCompleteableGeneralTasks
        End Try

        htblCompleteableGeneralTasks = htblTasks
        iPrepProgress = 2

    End Sub


    Private Function ResolveAmbiguity(ByVal sInput As String) As String

        Dim bResolved As Boolean = False

        ResolveAmbiguity = sAmbTask ' the default unless we're still ambiguous

        For iRef As Integer = 0 To NewReferences.Length - 1
            Debug.WriteLine("Reference " & iRef)
            If NewReferences(iRef) IsNot Nothing Then
                With NewReferences(iRef)
                    Debug.WriteLine("Number of Refs in this Reference: " & .Items.Count)
                    For i As Integer = 0 To .Items.Count - 1
                        Dim salRefs As StringArrayList = .Items(i).MatchingPossibilities
                        Debug.WriteLine("Number of matching references: " & salRefs.Count)
                        If salRefs.Count <> 1 Then
                            If Not bResolved Then
                                .Items(i).MatchingPossibilities = PossibleKeys(salRefs, sInput, .ReferenceType)
                            End If
                            If .Items(i).MatchingPossibilities.Count <> 1 Then Return Nothing
                            If .ReferenceType = ReferencesType.Object Then sIt = Adventure.htblObjects(.Items(i).MatchingPossibilities(0)).FullName(True)
                            If .ReferenceType = ReferencesType.Object AndAlso Adventure.htblObjects(.Items(i).MatchingPossibilities(0)).IsPlural Then sThem = Adventure.htblObjects(.Items(i).MatchingPossibilities(0)).FullName(True)
                            If .ReferenceType = ReferencesType.Character Then
                                With Adventure.htblCharacters(.Items(i).MatchingPossibilities(0))
                                    Select Case .Gender
                                        Case clsCharacter.GenderEnum.Male
                                            sHim = .Name
                                        Case clsCharacter.GenderEnum.Female
                                            sHer = .Name
                                        Case clsCharacter.GenderEnum.Unknown
                                            sIt = .Name
                                    End Select
                                End With
                            End If
                            bResolved = True
                        End If
                    Next
                End With
            End If
        Next

    End Function


    Private Function ContainsWord(ByVal sSentence As String, ByVal sCheckWord As String) As Boolean

        Dim sChecks() As String = Split(sCheckWord, " ")
        Dim sWords() As String = Split(sSentence.ToLower, " ")

        For Each sCheck As String In sChecks
            Dim bFound As Boolean = False
            For Each sWord As String In sWords
                If sWord = sCheck Then
                    bFound = True
                    Exit For
                End If
            Next
            If Not bFound Then Return False
        Next

        Return True

        'For Each sWord As String In sWords
        '    If sWord = sCheckWord Then Return True
        'Next

        'Return False

    End Function

    ' This takes a list of possible refs, then narrows the field (hopefully to 1) given the input
    Private Function PossibleKeys(ByVal salKeys As StringArrayList, ByVal sInput As String, ByVal sRefType As ReferencesType) As StringArrayList

        Dim salReturn As New StringArrayList
        ' Check each word in the refined text to ensure they all match

        Select Case sRefType
            Case ReferencesType.Object
                'For Each sKey As String In salKeys
                '    Dim ob As clsObject = Adventure.htblObjects(sKey)
                '    If ContainsWord(ob.Prefix, sInput) Then
                '        salReturn.Add(sKey)
                '    Else
                '        For Each sName As String In ob.arlNames
                '            If ContainsWord(sName, sInput) Then
                '                salReturn.Add(sKey)
                '                Exit For
                '            End If
                '        Next
                '    End If
                'Next
                For Each sKey As String In salKeys
                    Dim ob As clsObject = Adventure.htblObjects(sKey)
                    Dim bMatchAll As Boolean = True
                    For Each sWord As String In sInput.Split(" "c)
                        Dim bWordInObject As Boolean = False
                        If sWord = "the" OrElse sWord = ob.Article OrElse ContainsWord(ob.Prefix, sWord) Then
                            bWordInObject = True
                        Else
                            For Each sName As String In ob.arlNames
                                If ContainsWord(sName, sWord) Then
                                    bWordInObject = True
                                    Exit For
                                End If
                            Next
                        End If
                        If Not bWordInObject Then
                            bMatchAll = False
                            Exit For
                        End If
                    Next
                    If bMatchAll Then salReturn.Add(sKey)
                Next
            Case ReferencesType.Character
                'For Each sKey As String In salKeys
                '    Dim ch As clsCharacter = Adventure.htblCharacters(sKey)
                '    If ContainsWord(ch.Prefix, sInput) Then
                '        salReturn.Add(sKey)
                '    ElseIf ContainsWord(ch.ProperName, sInput) Then
                '        salReturn.Add(sKey)
                '    Else
                '        For Each sName As String In ch.arlDescriptors
                '            If ContainsWord(sName, sInput) Then
                '                salReturn.Add(sKey)
                '                Exit For
                '            End If
                '        Next
                '    End If
                'Next
                For Each sKey As String In salKeys
                    Dim ch As clsCharacter = Adventure.htblCharacters(sKey)
                    Dim bMatchAll As Boolean = True
                    For Each sWord As String In sInput.Split(" "c)
                        Dim bWordInChar As Boolean = False
                        If ContainsWord(ch.Prefix, sWord) OrElse ContainsWord(ch.ProperName, sWord) Then
                            bWordInChar = True
                        Else
                            For Each sName As String In ch.arlDescriptors
                                If ContainsWord(sName, sWord) Then
                                    bWordInChar = True
                                    Exit For
                                End If
                            Next
                        End If
                        If Not bWordInChar Then
                            bMatchAll = False
                            Exit For
                        End If
                    Next
                    If bMatchAll Then salReturn.Add(sKey)
                Next
        End Select

        Return salReturn

    End Function


    Private Function GetReference(ByVal sReference As String) As String

        Dim iObRefCount As Integer = 0
        Dim iChRefCount As Integer = 0

        If NewReferences Is Nothing Then Return Nothing

        For iRef As Integer = 0 To NewReferences.Length - 1
            With NewReferences(iRef)
                If NewReferences(iRef) IsNot Nothing AndAlso .Items IsNot Nothing AndAlso .Items.Count > 0 AndAlso .Items(0).MatchingPossibilities.Count > 0 Then

                    Select Case sReference
                        Case "ReferencedObject", "ReferencedObject1", "ReferencedObject2", "ReferencedObject3", "ReferencedObject4", "ReferencedObject5", "ReferencedObjects"
                            If .ReferenceType = ReferencesType.Object Then
                                iObRefCount += 1
                                If sReference = "ReferencedObjects" _
                                    OrElse (iObRefCount = 1 AndAlso (sReference = "ReferencedObject" OrElse sReference = "ReferencedObject1")) _
                                    OrElse (iObRefCount = 2 AndAlso sReference = "ReferencedObject2") _
                                    OrElse (iObRefCount = 3 AndAlso sReference = "ReferencedObject3") _
                                    OrElse (iObRefCount = 4 AndAlso sReference = "ReferencedObject4") _
                                    OrElse (iObRefCount = 5 AndAlso sReference = "ReferencedObject5") Then
                                    Return .Items(0).MatchingPossibilities(0)
                                End If
                            End If
                        Case "ReferencedDirection"
                            If .ReferenceType = ReferencesType.Direction Then Return .Items(0).MatchingPossibilities(0)
                        Case "ReferencedCharacter", "ReferencedCharacter1", "ReferencedCharacter2", "ReferencedCharacter3", "ReferencedCharacter4", "ReferencedCharacter5"
                            If .ReferenceType = ReferencesType.Character Then
                                iChRefCount += 1
                                If sReference = "ReferencedCharacters" _
                                    OrElse (iChRefCount = 1 AndAlso (sReference = "ReferencedCharacter" OrElse sReference = "ReferencedCharacter1")) _
                                    OrElse (iChRefCount = 2 AndAlso sReference = "ReferencedCharacter2") _
                                    OrElse (iChRefCount = 3 AndAlso sReference = "ReferencedCharacter3") _
                                    OrElse (iChRefCount = 4 AndAlso sReference = "ReferencedCharacter4") _
                                    OrElse (iChRefCount = 5 AndAlso sReference = "ReferencedCharacter5") Then
                                    Return .Items(0).MatchingPossibilities(0)
                                End If
                            End If
                    End Select

                End If
            End With
        Next

        Return Nothing

    End Function


    'Private Function GetReferenceOld(ByVal sReference As String) As String

    '    Dim iRefCount As Integer = 0

    '    If References Is Nothing Then Return Nothing

    '    For iRef As Integer = 0 To References.Length - 1
    '        With References(iRef)
    '            If References(iRef) IsNot Nothing AndAlso References(iRef).alReferences IsNot Nothing AndAlso .alReferences.Count > 0 AndAlso .alReferences(0).salWhat.Count > 0 Then

    '                Select Case sReference
    '                    Case "ReferencedObject", "ReferencedObject1", "ReferencedObject2", "ReferencedObject3", "ReferencedObject4", "ReferencedObject5", "ReferencedObjects"
    '                        If .sRefType = ReferencesType.Object Then
    '                            iRefCount += 1
    '                            If sReference = "ReferencedObjects" _
    '                                OrElse (iRefCount = 1 AndAlso (sReference = "ReferencedObject" OrElse sReference = "ReferencedObject1")) _
    '                                OrElse (iRefCount = 2 AndAlso sReference = "ReferencedObject2") _
    '                                OrElse (iRefCount = 3 AndAlso sReference = "ReferencedObject3") _
    '                                OrElse (iRefCount = 4 AndAlso sReference = "ReferencedObject4") _
    '                                OrElse (iRefCount = 5 AndAlso sReference = "ReferencedObject5") Then
    '                                Return .alReferences(0).salWhat(0)
    '                            End If
    '                        End If
    '                    Case "ReferencedDirection"
    '                        If .sRefType = ReferencesType.Direction Then Return .alReferences(0).salWhat(0)
    '                End Select

    '            End If
    '        End With
    '    Next

    '    Return Nothing

    'End Function


    Private Function PassSingleRestriction(ByVal restx As clsRestriction, Optional ByVal bIgnoreReferences As Boolean = False) As Boolean

        Try
            Dim rest As New clsRestriction
            rest = restx.Copy
            Dim r As Boolean = False

            'If rest.sKey1 = "ReferencedObjects" OrElse rest.sKey2 = "ReferencedObjects" Then
            '    Exit Function ' for now
            'End If
            Debug.WriteLine(rest.Summary)

            ' Replace references        
            Select Case rest.sKey1
                Case "ReferencedObject", "ReferencedObject1", "ReferencedObject2", "ReferencedObject3", "ReferencedObject4", "ReferencedObject5", "ReferencedObjects", "ReferencedDirection", "ReferencedCharacter", "ReferencedCharacter1", "ReferencedCharacter2", "ReferencedCharacter3", "ReferencedCharacter4", "ReferencedCharacter5"
                    rest.sKey1 = GetReference(rest.sKey1)
                    If bIgnoreReferences AndAlso rest.sKey1 Is Nothing Then Return True
            End Select
            Select Case rest.sKey2
                Case "ReferencedObject", "ReferencedObject1", "ReferencedObject2", "ReferencedObject3", "ReferencedObject4", "ReferencedObject5", "ReferencedObjects", "ReferencedDirection", "ReferencedCharacter", "ReferencedCharacter1", "ReferencedCharacter2", "ReferencedCharacter3", "ReferencedCharacter4", "ReferencedCharacter5"
                    rest.sKey2 = GetReference(rest.sKey2)
                    If bIgnoreReferences AndAlso rest.sKey2 Is Nothing Then Return True
            End Select
            If rest.sKey1 = "%Player%" AndAlso Adventure.Player IsNot Nothing Then rest.sKey1 = Adventure.Player.Key
            If rest.sKey2 = "%Player%" AndAlso Adventure.Player IsNot Nothing Then rest.sKey2 = Adventure.Player.Key

            If rest.sKey1 Is Nothing OrElse (rest.sKey2 Is Nothing AndAlso rest.eType <> clsRestriction.RestrictionTypeEnum.Task AndAlso rest.eType <> clsRestriction.RestrictionTypeEnum.Variable AndAlso rest.eType <> clsRestriction.RestrictionTypeEnum.Direction) Then
                r = False
                GoTo SkipTest
            End If

            Select Case rest.eType
                Case clsRestriction.RestrictionTypeEnum.Location
                    Dim loc As clsLocation = Nothing
                    Select Case rest.sKey1
                        Case PLAYERLOCATION
                            loc = Adventure.htblLocations(Adventure.Player.Location.LocationKey)
                        Case Else
                            If Adventure.htblLocations.ContainsKey(rest.sKey1) Then loc = Adventure.htblLocations(rest.sKey1)
                    End Select
                    If loc IsNot Nothing Then
                        Select Case rest.eLocation
                            Case clsRestriction.LocationEnum.HaveBeenSeenByCharacter
                                r = loc.SeenBy(rest.sKey2)
                            Case clsRestriction.LocationEnum.BeInGroup
                                TODO("Location must be in group")
                            Case clsRestriction.LocationEnum.HaveProperty
                                r = loc.HasProperty(rest.sKey2)
                        End Select
                    End If

                Case clsRestriction.RestrictionTypeEnum.Object
                    Select Case rest.eObject
                        Case clsRestriction.ObjectEnum.BeAtLocation
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    r = Adventure.htblLocations(rest.sKey2).ObjectsInLocation(clsLocation.WhichObjectsToListEnum.AllObjects, False).Count = 0
                                Case ANYOBJECT
                                    r = Adventure.htblLocations(rest.sKey2).ObjectsInLocation(clsLocation.WhichObjectsToListEnum.AllObjects, False).Count > 0
                                Case Else
                                    r = Adventure.htblObjects(rest.sKey1).ExistsAtLocation(rest.sKey2)
                            End Select
                        Case clsRestriction.ObjectEnum.BeHeldByCharacter
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    Select Case rest.sKey2
                                        Case ANYCHARACTER
                                            TODO("No object held by any character test")
                                        Case Else
                                            r = Adventure.htblCharacters(rest.sKey2).HeldObjects.Count = 0
                                    End Select
                                Case ANYOBJECT
                                    Select Case rest.sKey2
                                        Case ANYCHARACTER
                                            TODO("Any object held by any character test")
                                        Case Else
                                            r = Adventure.htblCharacters(rest.sKey2).HeldObjects.Count > 0
                                    End Select
                                Case Else
                                    Select Case rest.sKey2
                                        Case ANYCHARACTER
                                            'r = Adventure.htblObjects(rest.sKey1).Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.HeldByCharacter
                                            r = Adventure.htblObjects(rest.sKey1).IsHeldByAnyone
                                        Case Else
                                            r = Adventure.htblCharacters(rest.sKey2).IsHoldingObject(rest.sKey1)
                                    End Select
                            End Select
                        Case clsRestriction.ObjectEnum.BeInGroup
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    TODO("No object in group test")
                                Case ANYOBJECT
                                    TODO("Any object in group test")
                                Case Else
                                    r = Adventure.htblGroups(rest.sKey2).arlMembers.Contains(rest.sKey1)
                            End Select
                        Case clsRestriction.ObjectEnum.BeInsideObject
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    Select Case rest.sKey2
                                        Case NOOBJECT
                                            TODO("No object in no object test")
                                        Case ANYOBJECT
                                            TODO("No object in any object test")
                                        Case Else
                                            r = Adventure.htblObjects(rest.sKey2).Children(clsObject.WhereChildrenEnum.InsideObject).Count = 0
                                    End Select
                                Case ANYOBJECT
                                    Select Case rest.sKey2
                                        Case NOOBJECT
                                            TODO("Any object in no object test")
                                        Case ANYOBJECT
                                            TODO("Any object in any object test")
                                        Case Else
                                            r = Adventure.htblObjects(rest.sKey2).Children(clsObject.WhereChildrenEnum.InsideObject).Count > 0
                                    End Select
                                Case Else
                                    Select Case rest.sKey2
                                        Case NOOBJECT
                                            TODO("Object inside no object test")
                                        Case ANYOBJECT
                                            r = (Adventure.htblObjects(rest.sKey1).Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InObject)
                                        Case Else
                                            r = Adventure.htblObjects(rest.sKey1).IsInside(rest.sKey2)
                                    End Select
                            End Select
                            'If rest.sKey2 = ANYOBJECT Then
                            '    r = (Adventure.htblObjects(rest.sKey1).Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InObject)
                            'Else
                            '    If rest.sKey1 = ANYOBJECT Then
                            '        r = Adventure.htblObjects(rest.sKey2).Children(clsObject.WhereChildrenEnum.InsideObject).Count > 0
                            '    ElseIf rest.sKey1 = ANYCHARACTER Then
                            '        r = Adventure.htblObjects(rest.sKey2).ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Count > 0
                            '    Else
                            '        r = Adventure.htblObjects(rest.sKey1).IsInside(rest.sKey2)
                            '    End If
                            'End If
                        Case clsRestriction.ObjectEnum.BeInState
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    For Each ob As clsObject In Adventure.htblObjects.Values
                                        For Each prop As clsProperty In ob.htblProperties.Values
                                            If prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.Value = rest.sKey2 AndAlso prop.AppendToProperty = "" Then
                                                r = False
                                                GoTo SkipTest
                                            End If
                                        Next
                                    Next
                                    r = True
                                Case ANYOBJECT
                                    For Each ob As clsObject In Adventure.htblObjects.Values
                                        For Each prop As clsProperty In ob.htblProperties.Values
                                            If prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.Value = rest.sKey2 AndAlso prop.AppendToProperty = "" Then
                                                r = True
                                                GoTo SkipTest
                                            End If
                                        Next
                                    Next
                                Case Else
                                    ' Ok, this is a fudge option
                                    For Each prop As clsProperty In Adventure.htblObjects(rest.sKey1).htblProperties.Values
                                        If prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.Value = rest.sKey2 AndAlso prop.AppendToProperty = "" Then
                                            r = True
                                            GoTo SkipTest
                                        End If
                                    Next
                            End Select
                        Case clsRestriction.ObjectEnum.BeOnObject
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    Select Case rest.sKey2
                                        Case NOOBJECT
                                            TODO("No Object must be on No Object test")
                                        Case ANYOBJECT
                                            TODO("No Object must be on Any Object test")
                                        Case Else
                                            r = Adventure.htblObjects(rest.sKey2).Children(clsObject.WhereChildrenEnum.OnObject).Count = 0
                                    End Select
                                Case ANYOBJECT
                                    Select Case rest.sKey2
                                        Case NOOBJECT
                                            TODO("Any Object must be on No Object test")
                                        Case ANYOBJECT
                                            TODO("Any Object must be on Any Object test")
                                        Case Else
                                            r = Adventure.htblObjects(rest.sKey2).Children(clsObject.WhereChildrenEnum.OnObject).Count > 0
                                    End Select
                                Case Else
                                    Select Case rest.sKey2
                                        Case NOOBJECT
                                            TODO("Object must be on No Object test")
                                        Case ANYOBJECT
                                            r = (Adventure.htblObjects(rest.sKey1).Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.OnObject)
                                        Case Else
                                            r = Adventure.htblObjects(rest.sKey1).IsOn(rest.sKey2)
                                    End Select
                            End Select
                            'If rest.sKey2 = ANYOBJECT Then
                            '    r = (Adventure.htblObjects(rest.sKey1).Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.OnObject)
                            'Else
                            '    If rest.sKey1 = ANYOBJECT Then
                            '        r = Adventure.htblObjects(rest.sKey2).Children(clsObject.WhereChildrenEnum.OnObject).Count > 0
                            '    ElseIf rest.sKey1 = ANYCHARACTER Then
                            '        r = Adventure.htblObjects(rest.sKey2).ChildrenCharacters(clsObject.WhereChildrenEnum.OnObject).Count > 0
                            '    Else
                            '        r = Adventure.htblObjects(rest.sKey1).IsOn(rest.sKey2)
                            '    End If
                            'End If
                            'r = Adventure.htblObjects(rest.sKey1).Parent = rest.sKey2
                        Case clsRestriction.ObjectEnum.BePartOfCharacter
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    TODO("No Object is part of character test")
                                Case ANYOBJECT
                                    TODO("Any Object is part of character test")
                                Case Else
                                    Select Case rest.sKey2
                                        Case ANYCHARACTER
                                            TODO("Object is part of any character test")
                                        Case Else
                                            r = Adventure.htblObjects(rest.sKey1).Location.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.PartOfCharacter _
                                            AndAlso Adventure.htblObjects(rest.sKey1).Location.Key = rest.sKey2
                                    End Select
                            End Select
                            'If rest.sKey2 = ANYCHARACTER Then
                            '    TODO("Object is part of any character")
                            'Else
                            '    r = Adventure.htblObjects(rest.sKey1).Location.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.PartOfCharacter _
                            '    AndAlso Adventure.htblObjects(rest.sKey1).Location.Key = rest.sKey2
                            'End If
                        Case clsRestriction.ObjectEnum.BePartOfObject
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    TODO("No Object is part of object test")
                                Case ANYOBJECT
                                    TODO("Any Object is part of object test")
                                Case Else
                                    Select Case rest.sKey2
                                        Case NOOBJECT
                                            TODO("Object is part of No object test")
                                        Case ANYOBJECT
                                            r = Adventure.htblObjects(rest.sKey1).Location.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.PartOfObject
                                        Case Else
                                            r = Adventure.htblObjects(rest.sKey1).Location.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.PartOfObject _
                                             AndAlso Adventure.htblObjects(rest.sKey1).Location.Key = rest.sKey2
                                    End Select
                            End Select
                            'If rest.sKey2 = ANYOBJECT Then
                            '    r = Adventure.htblObjects(rest.sKey1).Location.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.PartOfObject
                            'Else
                            '    r = Adventure.htblObjects(rest.sKey1).Location.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.PartOfObject _
                            '    AndAlso Adventure.htblObjects(rest.sKey1).Location.Key = rest.sKey2
                            'End If
                        Case clsRestriction.ObjectEnum.HaveBeenSeenByCharacter
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    TODO("No Object has been seen by character test")
                                Case ANYOBJECT
                                    TODO("Any Object has been seen by character test")
                                Case Else
                                    Select Case rest.sKey2
                                        Case ANYCHARACTER
                                            TODO("Object has been seen by any character test")
                                        Case Else
                                            r = Adventure.htblCharacters(rest.sKey2).HasSeenObject(rest.sKey1)
                                    End Select
                            End Select
                            'If rest.sKey2 = ANYCHARACTER Then
                            '    TODO("Object has been seen by any character")
                            'Else
                            '    r = Adventure.htblCharacters(rest.sKey2).HasSeenObject(rest.sKey1)
                            'End If
                            'Case clsRestriction.ObjectEnum.StaticOrDynamic
                        Case clsRestriction.ObjectEnum.BeVisibleToCharacter
                            Dim ch As clsCharacter = Adventure.htblCharacters(rest.sKey2)
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    Select Case rest.sKey2
                                        Case ANYCHARACTER
                                            TODO("No Object visible to any character test")
                                        Case Else
                                            r = True
                                            For Each ob As clsObject In Adventure.htblObjects.Values
                                                If ch.CanSeeObject(ob.Key) Then
                                                    r = False
                                                    Exit For
                                                End If
                                            Next
                                    End Select
                                Case ANYOBJECT
                                    Select Case rest.sKey2
                                        Case ANYCHARACTER
                                            TODO("Any Object visible to any character test")
                                        Case Else
                                            r = False
                                            For Each ob As clsObject In Adventure.htblObjects.Values
                                                If ch.CanSeeObject(ob.Key) Then
                                                    r = True
                                                    Exit For
                                                End If
                                            Next
                                    End Select
                                Case Else
                                    Select Case rest.sKey2
                                        Case ANYCHARACTER
                                            TODO("Object visible to any character test")
                                        Case Else
                                            r = ch.CanSeeObject(rest.sKey1)
                                    End Select
                            End Select
                            'If rest.sKey2 = ANYCHARACTER Then
                            '    TODO("Object visible to any character")
                            'Else
                            '    r = Adventure.htblCharacters(rest.sKey2).CanSeeObject(rest.sKey1)
                            'End If
                        Case clsRestriction.ObjectEnum.BeWornByCharacter
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    Select Case rest.sKey2
                                        Case ANYCHARACTER
                                            TODO("No Object worn by any character test")
                                        Case Else
                                            r = Adventure.htblCharacters(rest.sKey2).WornObjects.Count = 0
                                    End Select
                                Case ANYOBJECT
                                    Select Case rest.sKey2
                                        Case ANYCHARACTER
                                            TODO("Any Object worn by any character test")
                                        Case Else
                                            r = Adventure.htblCharacters(rest.sKey2).WornObjects.Count > 0
                                    End Select
                                Case Else
                                    Select Case rest.sKey2
                                        Case ANYCHARACTER
                                            r = Adventure.htblObjects(rest.sKey1).Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.WornByCharacter
                                        Case Else
                                            r = Adventure.htblCharacters(rest.sKey2).IsWearingObject(rest.sKey1)
                                    End Select
                            End Select

                            'If rest.sKey2 = ANYCHARACTER Then
                            '    r = Adventure.htblObjects(rest.sKey1).Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.WornByCharacter
                            'Else
                            '    r = Adventure.htblCharacters(rest.sKey2).IsWearingObject(rest.sKey1)
                            'End If
                        Case clsRestriction.ObjectEnum.Exist
                            r = True
                        Case clsRestriction.ObjectEnum.HaveProperty
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    For Each ob As clsObject In Adventure.htblObjects.Values
                                        If ob.HasProperty(rest.sKey2) Then
                                            r = False
                                            GoTo SkipTest
                                        End If
                                    Next
                                    r = True
                                Case ANYOBJECT
                                    For Each ob As clsObject In Adventure.htblObjects.Values
                                        If ob.HasProperty(rest.sKey2) Then
                                            r = True
                                            GoTo SkipTest
                                        End If
                                    Next
                                Case Else
                                    r = Adventure.htblObjects.ContainsKey(rest.sKey1) AndAlso Adventure.htblObjects(rest.sKey1).GetPropertiesIncludingGroups.ContainsKey(rest.sKey2)
                            End Select
                        Case clsRestriction.ObjectEnum.BeExactText
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    TODO("No Object be exact text test")
                                Case ANYOBJECT
                                    TODO("Any Object be exact text test")
                                Case Else
                                    r = restx.sKey1 = "ReferencedObjects" AndAlso NewReferences IsNot Nothing AndAlso (NewReferences(0).Items(0).sCommandReference = "all" OrElse (NewReferences.Length > 1 AndAlso NewReferences(1).Items(0).sCommandReference = "all")) ' Should probably verify that %objects% was actually reference 0
                            End Select
                        Case clsRestriction.ObjectEnum.BeObject
                            Select Case rest.sKey1
                                Case NOOBJECT
                                    TODO("No Object be specific object test")
                                Case ANYOBJECT
                                    TODO("Any Object be specific object test")
                                Case Else
                                    r = (rest.sKey1 = rest.sKey2)
                            End Select
                    End Select

                Case clsRestriction.RestrictionTypeEnum.Task
                    Select Case rest.eTask
                        Case clsRestriction.TaskEnum.Complete
                            If Adventure.htblTasks.ContainsKey(rest.sKey1) Then r = Adventure.htblTasks(rest.sKey1).Completed
                    End Select

                Case clsRestriction.RestrictionTypeEnum.Variable
                    Dim var As clsVariable
                    Select Case rest.sKey1
                        Case "ReferencedNumber"
                            var = New clsVariable
                            var.Type = clsVariable.VariableTypeEnum.Numeric
                            var.IntValue = Adventure.iReferencedNumber
                        Case "ReferencedText"
                            var = New clsVariable
                            var.Type = clsVariable.VariableTypeEnum.Text
                            var.StringValue = Adventure.sReferencedText
                        Case Else
                            var = Adventure.htblVariables(rest.sKey1)
                            Dim iIndex As Integer = 1
                            If rest.sKey2 <> "" Then
                                If IsNumeric(rest.sKey2) Then
                                    iIndex = CInt(rest.sKey2)
                                Else
                                    iIndex = Adventure.htblVariables(rest.sKey2).IntValue
                                End If
                            End If
                    End Select

                    Dim iIntVal As Integer
                    Dim sStringVal As String = ""
                    If var.Type = clsVariable.VariableTypeEnum.Numeric Then
                        If rest.IntValue = Integer.MinValue AndAlso rest.StringValue <> "" Then
                            iIntVal = Adventure.htblVariables(rest.StringValue).IntValue ' Variable value
                        Else
                            If rest.StringValue <> "" AndAlso rest.StringValue <> rest.IntValue.ToString Then
                                iIntVal = SafeInt(ReplaceFunctions(rest.StringValue)) ' Expression
                            Else
                                iIntVal = rest.IntValue ' Integer value
                            End If
                        End If
                    Else
                        If rest.IntValue = Integer.MinValue AndAlso rest.StringValue <> "" Then
                            sStringVal = Adventure.htblVariables(rest.StringValue).StringValue
                        Else
                            'sStringVal = rest.StringValue
                            Dim varExp As New clsVariable
                            varExp.Type = clsVariable.VariableTypeEnum.Text
                            varExp.SetToExpression(rest.StringValue)
                            sStringVal = varExp.StringValue
                        End If
                    End If

                    Select Case rest.eVariable
                        Case clsRestriction.VariableEnum.EqualTo
                            If var.Type = clsVariable.VariableTypeEnum.Numeric Then
                                r = (var.IntValue = iIntVal)
                            Else
                                r = (var.StringValue = sStringVal)
                            End If
                        Case clsRestriction.VariableEnum.GreaterThan
                            If var.Type = clsVariable.VariableTypeEnum.Numeric Then
                                r = (var.IntValue > iIntVal)
                            Else
                                r = (var.StringValue > sStringVal)
                            End If
                        Case clsRestriction.VariableEnum.GreaterThanOrEqualTo
                            If var.Type = clsVariable.VariableTypeEnum.Numeric Then
                                r = (var.IntValue >= iIntVal)
                            Else
                                r = (var.StringValue >= sStringVal)
                            End If
                        Case clsRestriction.VariableEnum.LessThan
                            If var.Type = clsVariable.VariableTypeEnum.Numeric Then
                                r = (var.IntValue < iIntVal)
                            Else
                                r = (var.StringValue < sStringVal)
                            End If
                        Case clsRestriction.VariableEnum.LessThanOrEqualTo
                            If var.Type = clsVariable.VariableTypeEnum.Numeric Then
                                r = (var.IntValue <= iIntVal)
                            Else
                                r = (var.StringValue <= sStringVal)
                            End If
                            'Case clsRestriction.VariableEnum.NotEqualTo
                            '    If var.Type = clsVariable.VariableTypeEnum.Numeric Then
                            '        r = (var.IntValue <> iIntVal)
                            '    Else
                            '        r = (var.StringValue <> sStringVal)
                            '    End If
                    End Select

                Case clsRestriction.RestrictionTypeEnum.Character
                    'Select Case rest.sKey1
                    '    Case ANYCHARACTER                            
                    '        For Each ch As clsCharacter In Adventure.htblCharacters.Values
                    '            Dim restSub As clsRestriction = rest.Copy
                    '            restSub.sKey1 = ch.Key
                    '            If PassSingleRestriction(restSub) Then Return True
                    '        Next
                    '        Return False

                    '    Case Else
                    'Dim ch As clsCharacter = Adventure.htblCharacters(rest.sKey1)
                    Select Case rest.eCharacter
                        Case clsRestriction.CharacterEnum.BeAlone
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    For Each ch As clsCharacter In Adventure.htblCharacters.Values
                                        If ch.IsAlone Then
                                            r = True
                                            Exit For
                                        End If
                                    Next
                                    r = False
                                Case Else
                                    r = Adventure.htblCharacters(rest.sKey1).IsAlone
                            End Select

                        Case clsRestriction.CharacterEnum.BeAloneWith
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character be alone")
                                Case Else
                                    If rest.sKey2 = ANYCHARACTER Then
                                        r = Adventure.htblCharacters(rest.sKey1).AloneWithChar IsNot Nothing
                                    Else
                                        r = Adventure.htblCharacters(rest.sKey1).AloneWithChar = rest.sKey2
                                    End If
                            End Select

                        Case clsRestriction.CharacterEnum.BeAtLocation
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    r = False
                                    For Each c As clsCharacter In Adventure.htblCharacters.Values
                                        If c.LocationRoots.ContainsKey(rest.sKey2) Then
                                            r = True
                                            Exit For
                                        End If
                                    Next
                                Case Else
                                    r = Adventure.htblCharacters(rest.sKey1).LocationRoots.ContainsKey(rest.sKey2)
                            End Select

                        Case clsRestriction.CharacterEnum.BeCharacter
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    r = True ' Bit pointless
                                Case Else
                                    r = (rest.sKey1 = rest.sKey2)
                            End Select

                        Case clsRestriction.CharacterEnum.BeInConversationWith
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character be in conversation with")
                                Case Else
                                    If rest.sKey2 = ANYCHARACTER Then
                                        r = (Adventure.sConversationCharKey <> "")
                                    Else
                                        r = (Adventure.sConversationCharKey = rest.sKey2)
                                    End If
                            End Select

                        Case clsRestriction.CharacterEnum.Exist
                            r = True

                        Case clsRestriction.CharacterEnum.HaveRouteInDirection
                            sRouteError = rest.oMessage.ToString
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character have route in direction")
                                Case Else
                                    r = Adventure.htblCharacters(rest.sKey1).HasRouteInDirection(CType([Enum].Parse(GetType(DirectionsEnum), rest.sKey2), DirectionsEnum), False)
                            End Select

                        Case clsRestriction.CharacterEnum.HaveSeenCharacter
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character seen character")
                                Case Else
                                    r = Adventure.htblCharacters(rest.sKey1).HasSeenCharacter(rest.sKey2)
                            End Select

                        Case clsRestriction.CharacterEnum.HaveSeenLocation
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character seen location")
                                Case Else
                                    r = Adventure.htblCharacters(rest.sKey1).HasSeenLocation(rest.sKey2)
                            End Select

                        Case clsRestriction.CharacterEnum.HaveSeenObject
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character seen object")
                                Case Else
                                    r = Adventure.htblCharacters(rest.sKey1).HasSeenObject(rest.sKey2)
                            End Select

                        Case clsRestriction.CharacterEnum.BeHoldingObject
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    r = Adventure.htblObjects(rest.sKey2).IsHeldByAnyone
                                Case Else
                                    r = Adventure.htblCharacters(rest.sKey1).IsHoldingObject(rest.sKey2)
                            End Select

                        Case clsRestriction.CharacterEnum.BeInSameLocationAsCharacter
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    r = Not Adventure.htblCharacters(rest.sKey2).IsAlone
                                Case Else
                                    For Each loc As clsLocation In Adventure.htblCharacters(rest.sKey1).LocationRoots.Values
                                        r = Adventure.htblCharacters(rest.sKey2).LocationRoots.ContainsKey(loc.Key)
                                        Exit For
                                    Next
                            End Select

                            'r = (ch.Location.Key = Adventure.htblCharacters(rest.sKey2).Location.Key)
                        Case clsRestriction.CharacterEnum.BeInSameLocationAsObject
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character same location as object")
                                Case Else
                                    r = Adventure.htblCharacters(rest.sKey1).CanSeeObject(rest.sKey2)
                            End Select

                        Case clsRestriction.CharacterEnum.BeLyingOnObject
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character lying on object")
                                Case Else
                                    Dim ch As clsCharacter = Adventure.htblCharacters(rest.sKey1)
                                    If rest.sKey2 = ANYOBJECT Then
                                        r = ch.Location.Position = clsCharacterLocation.PositionEnum.Lying AndAlso ch.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject
                                    Else
                                        r = (ch.Location.Position = clsCharacterLocation.PositionEnum.Lying AndAlso ch.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject AndAlso ch.Location.Key = rest.sKey2)
                                    End If
                            End Select

                        Case clsRestriction.CharacterEnum.BeMemberOfGroup
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character member of group")
                                Case Else
                                    r = Adventure.htblGroups(rest.sKey2).arlMembers.Contains(rest.sKey1)
                            End Select

                        Case clsRestriction.CharacterEnum.BeOfGender
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character be of gender")
                                Case Else
                                    r = Adventure.htblCharacters(rest.sKey1).Gender = CType([Enum].Parse(GetType(clsCharacter.GenderEnum), rest.sKey2), clsCharacter.GenderEnum)
                            End Select

                        Case clsRestriction.CharacterEnum.BeSittingOnObject
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character sitting on object")
                                Case Else
                                    Dim ch As clsCharacter = Adventure.htblCharacters(rest.sKey1)
                                    If rest.sKey2 = ANYOBJECT Then
                                        r = ch.Location.Position = clsCharacterLocation.PositionEnum.Sitting AndAlso ch.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject
                                    Else
                                        r = (ch.Location.Position = clsCharacterLocation.PositionEnum.Sitting AndAlso ch.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject AndAlso ch.Location.Key = rest.sKey2)
                                    End If
                            End Select

                        Case clsRestriction.CharacterEnum.BeStandingOnObject
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character standing on object")
                                Case Else
                                    Dim ch As clsCharacter = Adventure.htblCharacters(rest.sKey1)
                                    If rest.sKey2 = ANYOBJECT Then
                                        r = ch.Location.Position = clsCharacterLocation.PositionEnum.Standing AndAlso ch.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject
                                    Else
                                        r = (ch.Location.Position = clsCharacterLocation.PositionEnum.Standing AndAlso ch.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject AndAlso ch.Location.Key = rest.sKey2)
                                    End If
                            End Select

                        Case clsRestriction.CharacterEnum.BeWearingObject
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    r = Adventure.htblObjects(rest.sKey2).IsWornByAnyone
                                Case Else
                                    r = Adventure.htblCharacters(rest.sKey1).IsWearingObject(rest.sKey2)
                            End Select

                        Case clsRestriction.CharacterEnum.BeWithinLocationGroup
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character in location group")
                                Case Else
                                    r = Adventure.htblGroups(rest.sKey2).arlMembers.Contains(Adventure.htblCharacters(rest.sKey1).Location.LocationKey)
                            End Select

                        Case clsRestriction.CharacterEnum.HaveProperty
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character have property")
                                Case Else
                                    r = Adventure.htblCharacters.ContainsKey(rest.sKey1) AndAlso Adventure.htblCharacters(rest.sKey1).HasProperty(rest.sKey2)
                            End Select

                        Case clsRestriction.CharacterEnum.BeInPosition
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character be in position")
                                Case Else
                                    If Adventure.htblCharacters(rest.sKey1).HasProperty("CharacterPosition") Then
                                        r = Adventure.htblCharacters(rest.sKey1).htblProperties("CharacterPosition").Value = rest.sKey2
                                    End If
                            End Select

                        Case clsRestriction.CharacterEnum.BeInsideObject
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    Select Case rest.sKey2
                                        Case ANYOBJECT
                                            TODO("Any Character be inside any object")
                                        Case Else
                                            r = Adventure.htblObjects(rest.sKey2).ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Count > 0
                                    End Select
                                Case Else
                                    If rest.sKey2 = ANYOBJECT Then
                                        r = (Adventure.htblCharacters(rest.sKey1).Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.InObject)
                                    Else
                                        If rest.sKey1 = ANYOBJECT Then
                                            r = Adventure.htblObjects(rest.sKey2).Children(clsObject.WhereChildrenEnum.InsideObject).Count > 0
                                        ElseIf rest.sKey1 = ANYCHARACTER Then
                                            r = Adventure.htblObjects(rest.sKey2).ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Count > 0
                                        Else
                                            r = Adventure.htblCharacters(rest.sKey1).Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.InObject AndAlso Adventure.htblCharacters(rest.sKey1).Location.Key = rest.sKey2
                                        End If
                                    End If
                            End Select

                        Case clsRestriction.CharacterEnum.BeOnObject
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    If rest.sKey2 = ANYOBJECT Then
                                        TODO("Any Character on Any Object")
                                    Else
                                        r = Adventure.htblObjects(rest.sKey2).ChildrenCharacters(clsObject.WhereChildrenEnum.OnObject).Count > 0
                                    End If
                                Case Else
                                    If rest.sKey2 = ANYOBJECT Then
                                        r = (Adventure.htblCharacters(rest.sKey1).Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject)
                                    Else
                                        Dim ch As clsCharacter = Adventure.htblCharacters(rest.sKey1)
                                        r = ch.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject AndAlso ch.Location.Key = rest.sKey2 ' Adventure.htblObjects(rest.sKey1).IsOn(rest.sKey2)                                        
                                    End If
                            End Select
                            'If rest.sKey2 = ANYOBJECT Then
                            '    r = (Adventure.htblCharacters(rest.sKey1).Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject)
                            '    'r = (Adventure.htblObjects(rest.sKey1).Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.OnObject)
                            'Else
                            '    If rest.sKey1 = ANYOBJECT Then
                            '        r = Adventure.htblObjects(rest.sKey2).Children(clsObject.WhereChildrenEnum.OnObject).Count > 0
                            '    ElseIf rest.sKey1 = ANYCHARACTER Then
                            '        r = Adventure.htblObjects(rest.sKey2).ChildrenCharacters(clsObject.WhereChildrenEnum.OnObject).Count > 0
                            '    Else
                            '        Dim ch As clsCharacter = Adventure.htblCharacters(rest.sKey1)
                            '        r = ch.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnObject AndAlso ch.Location.Key = rest.sKey2 ' Adventure.htblObjects(rest.sKey1).IsOn(rest.sKey2)
                            '    End If
                            'End If

                        Case clsRestriction.CharacterEnum.BeOnCharacter
                            Select Case rest.sKey1
                                Case ANYCHARACTER
                                    TODO("Any Character be on character")
                                Case Else
                                    Dim ch As clsCharacter = Adventure.htblCharacters(rest.sKey1)
                                    If rest.sKey2 = ANYCHARACTER Then
                                        r = (ch.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnCharacter)
                                    Else
                                        r = ch.Location.ExistWhere = clsCharacterLocation.ExistsWhereEnum.OnCharacter AndAlso ch.Location.Key = rest.sKey2
                                    End If
                            End Select

                            'End Select

                    End Select


                Case clsRestriction.RestrictionTypeEnum.Property
                    Dim item As clsItem = Nothing
                    Dim bItemContainsProperty As Boolean = False
                    If Adventure.htblObjects.ContainsKey(rest.sKey2) Then
                        item = Adventure.htblObjects(rest.sKey2)
                        bItemContainsProperty = CType(item, clsObject).HasProperty(rest.sKey1)
                    ElseIf Adventure.htblCharacters.ContainsKey(rest.sKey2) Then
                        item = Adventure.htblCharacters(rest.sKey2)
                        bItemContainsProperty = CType(item, clsCharacter).HasProperty(rest.sKey1)
                    End If

                    If Not bItemContainsProperty Then
                        r = False
                    Else
                        Dim prop As clsProperty
                        If TypeOf item Is clsObject Then
                            prop = CType(item, clsObject).htblProperties(rest.sKey1)
                        Else
                            prop = CType(item, clsCharacter).htblProperties(rest.sKey1)
                        End If

                        Select Case prop.Type
                            Case clsProperty.PropertyTypeEnum.CharacterKey, clsProperty.PropertyTypeEnum.LocationGroupKey, clsProperty.PropertyTypeEnum.LocationKey, clsProperty.PropertyTypeEnum.ObjectKey
                                Dim sKey As String = GetReference(rest.StringValue)
                                If sKey Is Nothing Then sKey = rest.StringValue
                                r = (prop.Value = sKey)
                            Case clsProperty.PropertyTypeEnum.Integer
                                Dim var As New clsVariable
                                var.Type = clsVariable.VariableTypeEnum.Numeric
                                var.SetToExpression(rest.StringValue)
                                r = (SafeInt(prop.Value) = var.IntValue)
                            Case clsProperty.PropertyTypeEnum.SelectionOnly
                                r = True
                            Case clsProperty.PropertyTypeEnum.StateList
                                r = prop.Value = rest.StringValue
                            Case clsProperty.PropertyTypeEnum.Text
                                Dim sStringVal As String = ReplaceFunctions(rest.StringValue)
                                r = (prop.Value = sStringVal)
                        End Select
                    End If

                Case clsRestriction.RestrictionTypeEnum.Direction
                    Dim sRefDirection As String = GetReference("ReferencedDirection")
                    r = rest.sKey1 = sRefDirection

            End Select

SkipTest:
            If r = (rest.eMust = clsRestriction.MustEnum.Must) Then
                sRestrictionText = ""
                DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, restx.Summary & ": Passed")
                Return True
            Else
                sRestrictionText = rest.oMessage.ToString
                DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, restx.Summary & ": Failed")
                'Try
                '    If Not References Is Nothing Then ' As it's only when we're testing autocomplete I think...
                '        ' This is a bit of a fudge, to make sure that if we've already removed the refs, we don't show the non-exist message
                '        If Not (References.Length = 0 AndAlso htblReferencesFail.Count > 0 AndAlso rest.sKey1 = Nothing AndAlso rest.sKey2 = "") Then
                '            sRestrictionText = rest.sMessage
                '            If sRestrictionText Is Nothing Then sRestrictionText = ""
                '            DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, restx.Summary & ": Failed")
                '        End If
                '    End If
                '    Return False
                'Catch ex As Exception
                '    ex = ex
                'End Try
            End If

        Catch ex As Exception
            ErrMsg("Error evaluating PassSingleRestriction for restriction """ & restx.ToString & """", ex)
        End Try

    End Function


    Private Function EvaluateRestrictionBlock(ByVal arlRestrictions As RestrictionArrayList, ByVal sBlock As String, Optional ByVal bIgnoreReferences As Boolean = False) As Boolean

        'Debug.WriteLine(sBlock)


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
                    Return EvaluateRestrictionBlock(arlRestrictions, sSubBlock, bIgnoreReferences)
                Else
                    Select Case sBlock.Substring(sSubBlock.Length + 2, 1) 'sBlock.Substring(1, 1)
                        Case "A"
                            Dim bFirst As Boolean = EvaluateRestrictionBlock(arlRestrictions, sSubBlock, bIgnoreReferences)
                            If Not bFirst Then
                                iRestNum += CharacterCount(sBlock.Substring(sSubBlock.Length + 3), "#"c)
                                Return False
                            Else
                                Return EvaluateRestrictionBlock(arlRestrictions, sBlock.Substring(sSubBlock.Length + 3), bIgnoreReferences)
                            End If
                            'Return EvaluateRestrictionBlock(arlRestrictions, sSubBlock) AndAlso EvaluateRestrictionBlock(arlRestrictions, sBlock.Substring(sSubBlock.Length + 3)) 'sBlock.Substring(2))
                        Case "O"
                            Dim bFirst As Boolean = EvaluateRestrictionBlock(arlRestrictions, sSubBlock, bIgnoreReferences)
                            If bFirst Then
                                iRestNum += CharacterCount(sBlock.Substring(sSubBlock.Length + 3), "#"c)
                                Return True
                            Else
                                Return EvaluateRestrictionBlock(arlRestrictions, sBlock.Substring(sSubBlock.Length + 3), bIgnoreReferences)
                            End If
                            'Return EvaluateRestrictionBlock(arlRestrictions, sSubBlock) OrElse EvaluateRestrictionBlock(arlRestrictions, sBlock.Substring(sSubBlock.Length + 3)) 'sBlock.Substring(2))
                        Case Else
                            ' Error
                    End Select
                End If
            Case "#"
                iRestNum += 1
                If sBlock.Length = 1 Then
                    Return PassSingleRestriction(arlRestrictions(iRestNum - 1), bIgnoreReferences)
                Else
                    Select Case sBlock.Substring(1, 1)
                        Case "A"
                            Dim bFirst As Boolean = PassSingleRestriction(arlRestrictions(iRestNum - 1), bIgnoreReferences)
                            If Not bFirst Then
                                iRestNum += CharacterCount(sBlock.Substring(2), "#"c)
                                Return False
                            Else
                                Return EvaluateRestrictionBlock(arlRestrictions, sBlock.Substring(2), bIgnoreReferences)
                            End If
                            'Return PassSingleRestriction(arlRestrictions(iRestNum - 1)) AndAlso EvaluateRestrictionBlock(arlRestrictions, sBlock.Substring(2))
                        Case "O"
                            Dim bFirst As Boolean = PassSingleRestriction(arlRestrictions(iRestNum - 1), bIgnoreReferences)
                            If bFirst Then
                                iRestNum += CharacterCount(sBlock.Substring(2), "#"c)
                                Return True
                            Else
                                Return EvaluateRestrictionBlock(arlRestrictions, sBlock.Substring(2), bIgnoreReferences)
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



    ' IgnoreReferences is for when we are evaluating whether the task is completable or not, but we don't have any refs yet
    Public Function PassRestrictions(ByVal arlRestrictions As RestrictionArrayList, Optional ByVal bIgnoreReferences As Boolean = False) As Boolean

        iRestNum = 0
        sRouteError = ""

        If arlRestrictions.Count = 0 Then
            Return True
        Else
            ' We have to check each combination of objects from our task
            ' e.g. "get %objects% from %object2%
            ' "get red ball and blue ball from box"
            ' get red ball from box
            ' get blue ball from box
            Return EvaluateRestrictionBlock(arlRestrictions, arlRestrictions.BracketSequence, bIgnoreReferences)
        End If

    End Function


    Private Function InputMatchesObjects(ByVal task As clsTask, ByVal sInput As String, ByVal iNewRef As Integer, Optional ByVal bExcepts As Boolean = False, Optional ByVal bPlural As Boolean = False, Optional ByVal bSecondChance As Boolean = False) As Boolean

        Dim re As System.Text.RegularExpressions.Regex

        If Not bPlural Then
            re = New System.Text.RegularExpressions.Regex("^((?<all>all( .+)?)|(?<objects1>.+))( (except|but|apart from) (?<objects2>.+))?$", System.Text.RegularExpressions.RegexOptions.RightToLeft Or System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            If re.IsMatch(sInput) Then
                For Each sGroupName As String In re.GetGroupNames
                    Select Case sGroupName

                        Case "all"
                            Dim sAll As String = re.Match(sInput).Groups(sGroupName).Value.Trim
                            If sAll <> "" Then
                                If sAll = "all" Then
                                    ' User isn't refining 'all', so we need to populate list with all objects
                                    Dim iItemNum As Integer = 0
                                    For Each ob As clsObject In Adventure.htblObjects.SeenBy.Values
                                        task.NewReferences(iNewRef).Items.Add(New clsSingleItem)
                                        task.NewReferences(iNewRef).Items(iItemNum).MatchingPossibilities.Add(ob.Key)
                                        task.NewReferences(iNewRef).Items(iItemNum).bExplicitlyMentioned = False
                                        task.NewReferences(iNewRef).Items(iItemNum).sCommandReference = "all"
                                        iItemNum += 1
                                    Next
                                Else
                                    ' i.e. all balls
                                    ' object1 should be plural here, in which case we want to match any object with that as the plural, i.e. balls, cactii, sheep                          
                                    If Not InputMatchesObjects(task, sAll.Substring(4), iNewRef, , True) Then GoTo NextCheck ' Return False
                                End If
                            End If

                        Case "objects1"
                            Dim sObs As String = re.Match(sInput).Groups(sGroupName).Value.Trim
                            If sObs <> "" AndAlso Not sObs.StartsWith("all ") Then
                                ' i.e. balls
                                ' object1 should be plural here, in which case we want to match any object with that as the plural, i.e. balls, cactii, sheep                          
                                If Not InputMatchesObjects(task, sObs, iNewRef, bExcepts, True) Then GoTo NextCheck
                            End If

                        Case "objects2"
                            Dim sExcepts As String = re.Match(sInput).Groups(sGroupName).Value.Trim
                            If sExcepts <> "" Then
                                ' Need to go thru and remove any matching ref
                                InputMatchesObjects(task, sExcepts, iNewRef, True)
                            End If

                    End Select
                Next
                Return True
            End If

NextCheck:
            re = New System.Text.RegularExpressions.Regex("^(?<commaseparatedobjects>(.+), )*(?<object2>.+) and (?<object3>.+)$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            If re.IsMatch(sInput) Then
                Dim m As System.Text.RegularExpressions.Match = re.Match(sInput)
                Dim iItemNum As Integer = 0
                If m.Groups("commaseparatedobjects").Length > 0 Then
                    For Each sObject As String In m.Groups("commaseparatedobjects").Value.TrimEnd(New Char() {","c, " "c}).Split(","c)
                        'If Not bExcepts Then task.NewReferences(iNewRef).Items.Add(New clsSingleItem)
                        sObject = sObject.Trim
                        If Not InputMatchesObject(task, sObject, iNewRef, iItemNum, bExcepts) Then Return False
                        iItemNum += 1
                    Next
                End If
                'If Not bExcepts Then task.NewReferences(iNewRef).Items.Add(New clsSingleItem)
                If Not InputMatchesObject(task, m.Groups("object2").Value, iNewRef, iItemNum, bExcepts) Then Return False
                iItemNum += 1
                'If Not bExcepts Then task.NewReferences(iNewRef).Items.Add(New clsSingleItem)
                If Not InputMatchesObject(task, m.Groups("object3").Value, iNewRef, iItemNum, bExcepts) Then Return False
                Return True
            End If

        End If

        ' Try to match on unique names before looking at plurals
        ' So if we have bar and bars, get bars tries to take the bars before taking the bar
        'If bPlural AndAlso InputMatchesObject(task, sInput, iNewRef, 0, bExcepts, False, bSecondChance) Then Return True            
        Return InputMatchesObject(task, sInput, iNewRef, 0, bExcepts, bPlural, bSecondChance)

    End Function


    Private Function InputMatchesObject(ByVal task As clsTask, ByVal sInput As String, ByVal iReferenceNum As Integer, ByVal iItemNum As Integer, Optional ByVal bExcepts As Boolean = False, Optional ByVal bPlural As Boolean = False, Optional ByVal bSecondChance As Boolean = False) As Boolean

        Dim bResult As Boolean = False
        Dim bAddedItem As Boolean = False

        If iItemNum = 0 AndAlso bPlural Then iItemNum = -1
        For Each ob As clsObject In Adventure.htblObjects.Values '.SeenBy.Values
            If System.Text.RegularExpressions.Regex.IsMatch(sInput, "^" & ob.sRegularExpressionString(, bPlural) & "$", System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then
                bResult = True
                If Not bExcepts Then
                    If bPlural Then iItemNum += 1
                    If bPlural OrElse Not bAddedItem Then task.NewReferences(iReferenceNum).Items.Add(New clsSingleItem)
                    bAddedItem = True

                    task.NewReferences(iReferenceNum).Items(iItemNum).MatchingPossibilities.Add(ob.Key)
                    task.NewReferences(iReferenceNum).Items(iItemNum).bExplicitlyMentioned = True
                    task.NewReferences(iReferenceNum).Items(iItemNum).sCommandReference = sInput
                Else
                    For iItem As Integer = task.NewReferences(iReferenceNum).Items.Count - 1 To 0 Step -1
                        Dim itm As clsSingleItem = task.NewReferences(iReferenceNum).Items(iItem)
                        If itm.MatchingPossibilities.Contains(ob.Key) Then itm.MatchingPossibilities.Remove(ob.Key)
                        If itm.MatchingPossibilities.Count = 0 Then task.NewReferences(iReferenceNum).Items.RemoveAt(iItem)
                    Next
                End If
            End If
        Next

        'If Not bAddedItem Then
        '    task.NewReferences(iReferenceNum).Items.Add(New clsSingleItem)
        '    task.NewReferences(iReferenceNum).Items(iItemNum).sCommandReference = sInput
        'End If

        If Not bResult AndAlso bSecondChance AndAlso task.HasObjectExistRestriction Then
            ' TODO - This needs to check that it is the correct 'must exist' check, rather than just any
            ' If our task has a check that objects should exist, return True as a match so the task can deal with that in it's restrictions
            'task.NewReferences(iReferenceNum).Items.Add(New clsSingleItem)
            'task.NewReferences(iReferenceNum).Items(0).MatchingPossibilities.Add("NonExistingObject")
            'task.NewReferences(iReferenceNum).Items(0).bExplicitlyMentioned = False
            'task.NewReferences(iReferenceNum).Items(0).sCommandReference = sInput
            Return True
        End If

        Return bResult

    End Function


    Private Function InputMatchesCharacters(ByVal task As clsTask, ByVal sInput As String, ByVal iNewRef As Integer, Optional ByVal bExcepts As Boolean = False, Optional ByVal bSecondChance As Boolean = False) As Boolean

        Dim re As System.Text.RegularExpressions.Regex

NextCheck:
        re = New System.Text.RegularExpressions.Regex("^(?<commaseparatedcharacters>(.+), )*(?<character2>.+) and (?<character3>.+)$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        If re.IsMatch(sInput) Then
            Dim m As System.Text.RegularExpressions.Match = re.Match(sInput)
            Dim iItemNum As Integer = 0
            If m.Groups("commaseparatedcharacters").Length > 0 Then
                For Each sCharacter As String In m.Groups("commaseparatedcharacters").Value.TrimEnd(New Char() {","c, " "c}).Split(","c)
                    'If Not bExcepts Then task.NewReferences(iNewRef).Items.Add(New clsSingleItem)
                    sCharacter = sCharacter.Trim
                    If Not InputMatchesCharacter(task, sCharacter, iNewRef, iItemNum, bExcepts) Then Return False
                    iItemNum += 1
                Next
            End If
            If Not InputMatchesCharacter(task, m.Groups("character2").Value, iNewRef, iItemNum, bExcepts) Then Return False
            iItemNum += 1
            If Not InputMatchesCharacter(task, m.Groups("character3").Value, iNewRef, iItemNum, bExcepts) Then Return False
            Return True
        End If

        Return InputMatchesCharacter(task, sInput, iNewRef, 0, bExcepts, bSecondChance)

    End Function


    Private Function InputMatchesCharacter(ByVal task As clsTask, ByVal sInput As String, ByVal iReferenceNum As Integer, ByVal iItemNum As Integer, Optional ByVal bExcepts As Boolean = False, Optional ByVal bSecondChance As Boolean = False) As Boolean

        Dim bResult As Boolean = False
        Dim bAddedChar As Boolean = False

        'If iItemNum = 0 AndAlso bPlural Then iItemNum = -1
        For Each ch As clsCharacter In Adventure.htblCharacters.Values '.SeenBy.Values
            If System.Text.RegularExpressions.Regex.IsMatch(sInput, "^" & ch.sRegularExpressionString() & "$", System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then
                bResult = True
                If Not bExcepts Then
                    'If bPlural Then iItemNum += 1
                    'If bPlural OrElse Not bAddedChar Then task.NewReferences(iReferenceNum).Items.Add(New clsSingleItem)
                    If Not bAddedChar Then task.NewReferences(iReferenceNum).Items.Add(New clsSingleItem)
                    bAddedChar = True

                    task.NewReferences(iReferenceNum).Items(iItemNum).MatchingPossibilities.Add(ch.Key)
                    task.NewReferences(iReferenceNum).Items(iItemNum).bExplicitlyMentioned = True
                    task.NewReferences(iReferenceNum).Items(iItemNum).sCommandReference = sInput
                Else
                    For iItem As Integer = task.NewReferences(iReferenceNum).Items.Count - 1 To 0 Step -1
                        Dim itm As clsSingleItem = task.NewReferences(iReferenceNum).Items(iItem)
                        If itm.MatchingPossibilities.Contains(ch.Key) Then itm.MatchingPossibilities.Remove(ch.Key)
                        If itm.MatchingPossibilities.Count = 0 Then task.NewReferences(iReferenceNum).Items.RemoveAt(iItem)
                    Next
                End If
            End If
        Next

        If Not bResult AndAlso bSecondChance AndAlso task.HasCharacterExistRestriction Then
            ' TODO - This needs to check that it is the correct 'must exist' check, rather than just any
            ' If our task has a check that objects should exist, return True as a match so the task can deal with that in it's restrictions
            'task.NewReferences(iReferenceNum).Items.Add(New clsSingleItem)
            'task.NewReferences(iReferenceNum).Items(0).MatchingPossibilities.Add("NonExistingObject")
            'task.NewReferences(iReferenceNum).Items(0).bExplicitlyMentioned = False
            'task.NewReferences(iReferenceNum).Items(0).sCommandReference = sInput
            Return True
        End If

        Return bResult

    End Function



    ' If the command contains asterixes, strip them out, then add them in one by one until we (possibly) get a match
    Private Function GetRegularExpression(ByVal sCommand As String, ByVal sInput As String, ByVal bRightToLeft As Boolean) As System.Text.RegularExpressions.Regex

        Try
            Dim options As System.Text.RegularExpressions.RegexOptions = System.Text.RegularExpressions.RegexOptions.IgnoreCase
            If bRightToLeft Then options = options Or System.Text.RegularExpressions.RegexOptions.RightToLeft

            If sCommand.Contains("*") Then
                Dim iAsterixCount As Integer = 0
                Dim sTestCommand As String = sCommand

                While sTestCommand.Contains("*")
                    sTestCommand = Replace(sTestCommand, "*", "", , 1)
                    iAsterixCount += 1
                End While

                For iAsterix As Integer = iAsterixCount - 1 To -1 Step -1
                    sTestCommand = sCommand
                    For i As Integer = 0 To iAsterix
                        sTestCommand = Replace(sTestCommand, "*", "", , 1)
                    Next
                    Dim sPattern As String = ConvertToRE(sTestCommand)
                    Dim re As New System.Text.RegularExpressions.Regex(sPattern, options)
                    If re.IsMatch(sInput) Then Return re
                Next

                Return Nothing
            Else
                Dim sPattern As String = ConvertToRE(sCommand)
                Return New System.Text.RegularExpressions.Regex(sPattern, options)
            End If
        Catch ex As Exception
            ErrMsg("Error in command """ & sCommand & """", ex)
            Return New System.Text.RegularExpressions.Regex("")
        End Try

    End Function


    'Public Function DirectionRE(ByVal d As DirectionsEnum) As String

    '    Select Case d
    '        Case [Global].DirectionsEnum.North
    '            Return "(north|n)"
    '        Case [Global].DirectionsEnum.East
    '            Return "(east|e)"
    '        Case [Global].DirectionsEnum.South
    '            Return "(south|s)"
    '        Case [Global].DirectionsEnum.West
    '            Return "(west|w)"
    '        Case [Global].DirectionsEnum.Up
    '            Return "(up|u)"
    '        Case [Global].DirectionsEnum.Down
    '            Return "(down|d)"
    '        Case [Global].DirectionsEnum.In
    '            Return "(inside|in)"
    '        Case [Global].DirectionsEnum.Out
    '            Return "(outside|out|o)"
    '        Case [Global].DirectionsEnum.NorthEast
    '            Return "(northeast|north-east|north_east|n-e|ne)"
    '        Case [Global].DirectionsEnum.SouthEast
    '            Return "(southeast|south-east|south_east|s-e|se)"
    '        Case [Global].DirectionsEnum.SouthWest
    '            Return "(southwest|south-west|south_west|s-w|sw)"
    '        Case [Global].DirectionsEnum.NorthWest
    '            Return "(northwest|north-west|north_west|n-w|nw)"
    '        Case Else
    '            Return ""
    '    End Select

    'End Function


    Private Function InputMatchesCommand(ByVal task As clsTask, ByVal sInput As String, ByVal sCommand As String, ByVal bSecondChance As Boolean, ByVal bRightToLeft As Boolean) As Boolean

        Dim re As System.Text.RegularExpressions.Regex = GetRegularExpression(sCommand, sInput, bRightToLeft)
        If re Is Nothing Then Return False

        'Dim sPattern As String = ConvertToRE(sCommand)
        'Dim re As New System.Text.RegularExpressions.Regex(sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        Dim iNewReferences As Integer = 0

        ' Clear the references
        If task.NewReferences IsNot Nothing Then
            For i As Integer = 0 To task.NewReferences.Length - 1
                task.NewReferences(i) = Nothing
            Next
        End If

        If Not re.IsMatch(sInput) Then Return False

        Dim sRefs As StringArrayList = task.References

        For Each sGroupName As String In re.GetGroupNames
            Select Case sGroupName
                Case "objects"
                    iNewReferences += 1
                    task.NewReferences(iNewReferences - 1) = New clsNewReference(ReferencesType.Object)
                    Dim sObjectsInput As String = re.Match(sInput).Groups(sGroupName).Value.Trim
                    If Not InputMatchesObjects(task, sObjectsInput, iNewReferences - 1, , , bSecondChance) Then GoTo DoesntMatch ' Return False

                Case "object1", "object2", "object3", "object4", "object5"
                    iNewReferences += 1
                    task.NewReferences(iNewReferences - 1) = New clsNewReference(ReferencesType.Object)

                    Dim sObjectInput As String = re.Match(sInput).Groups(sGroupName).Value.Trim
                    If Not InputMatchesObject(task, sObjectInput, iNewReferences - 1, 0, , , bSecondChance) Then GoTo DoesntMatch ' Return False

                Case "characters"
                    iNewReferences += 1
                    task.NewReferences(iNewReferences - 1) = New clsNewReference(ReferencesType.Character)
                    Dim sCharactersInput As String = re.Match(sInput).Groups(sGroupName).Value.Trim
                    If Not InputMatchesCharacters(task, sCharactersInput, iNewReferences - 1, , bSecondChance) Then GoTo DoesntMatch

                Case "character1", "character2", "character3", "character4", "character5"
                    iNewReferences += 1
                    task.NewReferences(iNewReferences - 1) = New clsNewReference(ReferencesType.Character)

                    Dim sCharacterInput As String = re.Match(sInput).Groups(sGroupName).Value.Trim
                    If Not InputMatchesCharacter(task, sCharacterInput, iNewReferences - 1, 0, , bSecondChance) Then GoTo DoesntMatch

                Case "direction"
                    iNewReferences += 1
                    task.NewReferences(iNewReferences - 1) = New clsNewReference(ReferencesType.Direction)
                    Dim sDirInput As String = re.Match(sInput).Groups(sGroupName).Value.Trim
                    With task.NewReferences(iNewReferences - 1)
                        '.ReferenceType = ReferencesType.Direction
                        Dim sDirTest As String = ""
                        For dr As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest
                            sDirTest = DirectionRE(dr, True, True)
                            If System.Text.RegularExpressions.Regex.IsMatch(sDirInput, "^" & sDirTest & "$") Then
                                .Items.Add(New clsSingleItem)
                                .Items(0).MatchingPossibilities.Add(dr.ToString)
                                .Items(0).sCommandReference = sDirInput
                                Exit For
                            End If
                        Next
                    End With

                Case "number"
                    iNewReferences += 1
                    task.NewReferences(iNewReferences - 1) = New clsNewReference(ReferencesType.Number)
                    Dim sNumber As String = re.Match(sInput).Groups(sGroupName).Value.Trim
                    With task.NewReferences(iNewReferences - 1)
                        If System.Text.RegularExpressions.Regex.IsMatch(sNumber, "^-?[0-9]+$") Then
                            .Items.Add(New clsSingleItem)
                            .Items(0).MatchingPossibilities.Add(sNumber)
                            .Items(0).sCommandReference = sNumber
                            Adventure.iReferencedNumber = CInt(sNumber)
                            'Exit For
                        End If
                    End With

                Case "text"
                    iNewReferences += 1
                    task.NewReferences(iNewReferences - 1) = New clsNewReference(ReferencesType.Text)
                    Dim sText As String = re.Match(sInput).Groups(sGroupName).Value.Trim
                    With task.NewReferences(iNewReferences - 1)
                        If System.Text.RegularExpressions.Regex.IsMatch(sText, "^.*$") Then
                            .Items.Add(New clsSingleItem)
                            .Items(0).MatchingPossibilities.Add(sText)
                            .Items(0).sCommandReference = sText
                            Adventure.sReferencedText = sText
                            'Exit For
                        End If
                    End With

            End Select

            'Select Case sGroupName
            '    Case "objects", "object1", "object2", "object3", "object4", "object5", "characters", "character1", "character2", "character3", "character4", "character5", "direction", "number", "text"
            '        For iRef As Integer = 0 To sRefs.Count - 1
            '            If "%" & sGroupName & "%" = sRefs(iRef) Then
            '                task.NewReferences(iNewReferences - 1).Index = iRef
            '                Exit For
            '            End If
            '        Next
            'End Select
        Next

        Return True

DoesntMatch:
        If sCommand.Contains("% %") AndAlso Not re.RightToLeft Then
            ' Ok, we have 2 references back to back.  Try a match from right to left
            Return InputMatchesCommand(task, sInput, sCommand, bSecondChance, True)
        End If
        If Not bSecondChance AndAlso task.HasObjectExistRestriction AndAlso Not htblSecondChanceTasks.ContainsKey(task.Key) Then htblSecondChanceTasks.Add(task, task.Key)
        Return False

    End Function


    Private Function CopyRef(ByVal ref As clsNewReference) As clsNewReference

        Dim nr As clsNewReference = Nothing

        If ref IsNot Nothing Then
            nr = New clsNewReference(ref.ReferenceType)
            For iItem As Integer = 0 To ref.Items.Count - 1
                Dim itm As New clsSingleItem
                itm.MatchingPossibilities = ref.Items(iItem).MatchingPossibilities.Clone
                itm.bExplicitlyMentioned = ref.Items(iItem).bExplicitlyMentioned
                itm.sCommandReference = ref.Items(iItem).sCommandReference
                nr.Items.Add(itm)
            Next
            nr.Index = ref.Index
        End If

        Return nr

    End Function


    Private Sub RefineMatchingPossibilitesUsingRestrictions(ByVal task As clsTask)

        DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, "Checking scope: Applicable")

        Dim NewRefs(task.NewReferencesWorking.Length - 1) As clsNewReference

        'Dim htblNotAdded(task.NewReferencesWorking.Length - 1) As Generic.Dictionary(Of String, ReferencesType) ' Hashtable
        'Dim htblAdded(task.NewReferencesWorking.Length - 1) As Generic.Dictionary(Of String, ReferencesType) 'Hashtable
        Dim lAdded(task.NewReferencesWorking.Length - 1) As Generic.List(Of String)

        For i As Integer = 0 To task.NewReferencesWorking.Length - 1
            'htblNotAdded(i) = New Generic.Dictionary(Of String, ReferencesType) 'Hashtable
            'htblAdded(i) = New Generic.Dictionary(Of String, ReferencesType) 'Hashtable
            lAdded(i) = New Generic.List(Of String)
            If task.NewReferencesWorking(i) IsNot Nothing Then
                NewRefs(i) = New clsNewReference(task.NewReferencesWorking(i).ReferenceType)
                NewRefs(i).Index = task.NewReferencesWorking(i).Index
            End If
        Next

        ' We have to try every combination of references against all the others to see if it is a successful combination      
        If task.NewReferencesWorking IsNot Nothing AndAlso task.NewReferencesWorking.Length > 0 AndAlso task.NewReferencesWorking(0) IsNot Nothing Then

            For Each itm0 As clsSingleItem In task.NewReferencesWorking(0).Items

                Dim bAddedItem0 As Boolean = False
                ReDim NewReferences(0)
                NewReferences(0) = New clsNewReference(task.NewReferencesWorking(0).ReferenceType)
                NewReferences(0).Index = task.NewReferencesWorking(0).Index
                Dim itmOut0 As New clsSingleItem
                itmOut0.sCommandReference = itm0.sCommandReference
                'NewRefs(0).Items.Add(itmOut0)

                For Each sKey0 As String In itm0.MatchingPossibilities

                    NewReferences(0).Items.Clear()
                    Dim itmSingle0 As New clsSingleItem
                    itmSingle0.MatchingPossibilities.Add(sKey0)
                    NewReferences(0).Items.Add(itmSingle0)

                    If task.NewReferencesWorking.Length > 1 Then

                        For Each itm1 As clsSingleItem In task.NewReferencesWorking(1).Items

                            Dim bAddedItem1 As Boolean = False
                            ReDim Preserve NewReferences(1)
                            NewReferences(1) = New clsNewReference(task.NewReferencesWorking(1).ReferenceType)
                            NewReferences(1).Index = task.NewReferencesWorking(1).Index
                            Dim itmOut1 As New clsSingleItem
                            itmOut1.sCommandReference = itm1.sCommandReference
                            'NewRefs(1).Items.Add(itmOut1)                            

                            For Each sKey1 As String In itm1.MatchingPossibilities

                                NewReferences(1).Items.Clear()
                                Dim itmSingle1 As New clsSingleItem
                                itmSingle1.MatchingPossibilities.Add(sKey1)
                                NewReferences(1).Items.Add(itmSingle1)

                                If task.NewReferencesWorking.Length > 2 Then
                                    ' TODO, when more than 2 refs...
                                Else
                                    If PassRestrictions(task.arlRestrictions) Then
                                        If Not bAddedItem0 AndAlso Not lAdded(0).Contains(sKey0) Then NewRefs(0).Items.Add(itmOut0)
                                        If Not bAddedItem1 AndAlso Not lAdded(1).Contains(sKey1) Then NewRefs(1).Items.Add(itmOut1)
                                        itmOut0.MatchingPossibilities.Add(sKey0)
                                        itmOut1.MatchingPossibilities.Add(sKey1)
                                        bAddedItem0 = True
                                        bAddedItem1 = True
                                        If Not lAdded(0).Contains(sKey0) Then lAdded(0).Add(sKey0)
                                        If Not lAdded(1).Contains(sKey1) Then lAdded(1).Add(sKey1)
                                    End If
                                End If
                            Next sKey1

                            ' Make a note whether we added the reference or not                            
                            'If bAddedItem1 Then
                            '    If Not htblAdded(1).ContainsKey(itm1.sCommandReference) AndAlso Not htblNotAdded(1).ContainsKey(itm1.sCommandReference) Then htblAdded(1).Add(itm1.sCommandReference, task.NewReferencesWorking(1).ReferenceType)
                            '    If htblNotAdded(1).ContainsKey(itm1.sCommandReference) Then htblNotAdded(1).Remove(itm1.sCommandReference)
                            'Else
                            '    If Not htblAdded(1).ContainsKey(itm1.sCommandReference) AndAlso Not htblNotAdded(1).ContainsKey(itm1.sCommandReference) Then htblNotAdded(1).Add(itm1.sCommandReference, task.NewReferencesWorking(1).ReferenceType)
                            'End If

                        Next itm1
                    Else
                        If PassRestrictions(task.arlRestrictions) Then
                            If Not bAddedItem0 AndAlso Not lAdded(0).Contains(sKey0) Then NewRefs(0).Items.Add(itmOut0)
                            itmOut0.MatchingPossibilities.Add(sKey0)
                            bAddedItem0 = True
                            If Not lAdded(0).Contains(sKey0) Then lAdded(0).Add(sKey0)
                        End If
                    End If

                Next sKey0

                ' Make a note whether we added the reference or not
                'If bAddedItem0 Then
                '    If Not htblAdded(0).ContainsKey(itm0.sCommandReference) Then htblAdded(0).Add(itm0.sCommandReference, task.NewReferencesWorking(0).ReferenceType)
                '    If htblNotAdded(0).ContainsKey(itm0.sCommandReference) Then htblNotAdded(0).Remove(itm0.sCommandReference)
                'Else
                '    If Not htblAdded(0).ContainsKey(itm0.sCommandReference) AndAlso Not htblNotAdded(0).ContainsKey(itm0.sCommandReference) Then htblNotAdded(0).Add(itm0.sCommandReference, task.NewReferencesWorking(0).ReferenceType)
                'End If
            Next itm0

        End If

        'If False Then ' Can't see why we need to do this...
        '    ' Make sure we still add any items referenced that don't actually match our task definition
        '    For iRef As Integer = 0 To task.NewReferencesWorking.Length - 1
        '        For Each sExplicitCommandNotAdded As String In htblNotAdded(iRef).Keys
        '            Dim itm As New clsSingleItem
        '            For scope As eScope = eScope.Visible To eScope.Seen
        '                Dim bAddedItem As Boolean = False
        '                Select Case CType(htblNotAdded(iRef)(sExplicitCommandNotAdded), ReferencesType)
        '                    Case ReferencesType.Object
        '                        For Each ob As clsObject In Adventure.htblObjects.Values '.SeenBy.Values
        '                            If System.Text.RegularExpressions.Regex.IsMatch(sExplicitCommandNotAdded, "^" & ob.sRegularExpressionString & "$") Then
        '                                itm.MatchingPossibilities.Add(ob.Key)
        '                                If NewRefs(iRef) Is Nothing Then NewRefs(iRef) = New clsNewReference(ReferencesType.Object)
        '                                NewRefs(iRef).Items.Add(itm)
        '                                bAddedItem = True
        '                            End If
        '                        Next ob
        '                    Case ReferencesType.Character
        '                        For Each ch As clsCharacter In Adventure.htblCharacters.Values '.SeenBy.Values
        '                            If System.Text.RegularExpressions.Regex.IsMatch(sExplicitCommandNotAdded, "^" & ch.sRegularExpressionString & "$") Then
        '                                itm.MatchingPossibilities.Add(ch.Key)
        '                                If NewRefs(iRef) Is Nothing Then NewRefs(iRef) = New clsNewReference(ReferencesType.Character)
        '                                NewRefs(iRef).Items.Add(itm)
        '                                bAddedItem = True
        '                            End If
        '                        Next ch
        '                    Case ReferencesType.Direction
        '                        Dim sDir As String = ""
        '                        For d As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest ' Adventure.iCompassPoints ' DirectionsEnum.NorthWest
        '                            sDir = DirectionRE(d, True, True)
        '                            If System.Text.RegularExpressions.Regex.IsMatch(sExplicitCommandNotAdded, "^" & sDir & "$") Then
        '                                itm.MatchingPossibilities.Add(d.ToString)
        '                                If NewRefs(iRef) Is Nothing Then NewRefs(iRef) = New clsNewReference(ReferencesType.Direction)
        '                                NewRefs(iRef).Items.Add(itm)
        '                                bAddedItem = True
        '                                Exit For
        '                            End If
        '                        Next

        '                    Case Else
        '                        'TODO("Refine matching possibilites for " & CType(htblNotAdded(iRef)(sExplicitCommandNotAdded), ReferencesType).ToString & " references")
        '                End Select
        '                If bAddedItem Then Exit For ' So we don't do the next scope
        '            Next scope
        '        Next sExplicitCommandNotAdded
        '    Next iRef
        'End If

        ' If this returns no items and we had items before, return all visible items


        ' Check to see if this refined our possibilities to unique items
        Dim bCheckNextScope As Boolean = False
        'Dim ApplicableRefs() As clsNewReference = Nothing ' Because even tho we may not resolve to a single item, it may well be a better result than Visible or Seen scopes
        'Dim bResetNewRefs(NewRefs.Length - 1) As Boolean

        For iNR As Integer = 0 To NewRefs.Length - 1 ' Each nr As clsNewReference In NewRefs
            Dim nr As clsNewReference = NewRefs(iNR)
            Dim bResetRef As Boolean = False
            If nr IsNot Nothing AndAlso nr.Items IsNot Nothing Then
                If nr.Items.Count = 0 Then
                    bCheckNextScope = True
                    bResetRef = True
                End If
                For iI As Integer = 0 To nr.Items.Count - 1 ' Each itm As clsSingleItem In nr.Items
                    Dim itm As clsSingleItem = nr.Items(iI)
                    If itm.MatchingPossibilities.Count = 0 Then
                        bCheckNextScope = True
                        ' Reset refs to original
                        itm.MatchingPossibilities = task.NewReferencesWorking(iNR).Items(iI).MatchingPossibilities.Clone
                        bResetRef = True
                    ElseIf itm.MatchingPossibilities.Count > 1 Then
                        bCheckNextScope = True
                        'ApplicableRefs = CType(NewRefs.Clone, clsNewReference())
                        ' Leave existing refs to further refine by visibility
                    End If
                Next
                If bResetRef Then NewRefs(iNR) = CopyRef(task.NewReferences(iNR))
            End If
        Next
        If bCheckNextScope Then
            DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, "Checking scope: Visible")

            'If bResetNewRefs Then NewRefs = task.CopyNewRefs(task.NewReferences) ' Think this is problem, as it is resetting NewRefs, refined above
            For Each nr As clsNewReference In NewRefs
                If nr IsNot Nothing Then
                    For Each itm As clsSingleItem In nr.Items
                        For i As Integer = itm.MatchingPossibilities.Count - 1 To 0 Step -1
                            Select Case nr.ReferenceType
                                Case ReferencesType.Object
                                    If Not Adventure.htblObjects(itm.MatchingPossibilities(i)).IsVisibleTo(Adventure.Player.Key) Then itm.MatchingPossibilities.RemoveAt(i)
                                Case ReferencesType.Character
                                    If Not Adventure.htblCharacters(itm.MatchingPossibilities(i)).CanSeeCharacter(Adventure.Player.Key) Then itm.MatchingPossibilities.RemoveAt(i)
                                Case ReferencesType.Direction, ReferencesType.Number, ReferencesType.Text
                                    ' Don't think these are applicable                                    
                                Case Else
                                    TODO("Refine visible possibilites for " & nr.ReferenceType.ToString & " references")
                            End Select
                        Next i
                    Next itm
                End If
            Next nr
        End If

        ' Check to see if this refined our possibilities to unique items
        bCheckNextScope = False

        For iNR As Integer = 0 To NewRefs.Length - 1 ' Each nr As clsNewReference In NewRefs
            Dim nr As clsNewReference = NewRefs(iNR)
            Dim bResetRef As Boolean = False
            If nr IsNot Nothing AndAlso nr.Items IsNot Nothing Then
                If nr.Items.Count = 0 Then
                    bCheckNextScope = True
                    bResetRef = True
                End If
                For iI As Integer = nr.Items.Count - 1 To 0 Step -1 ' Each itm As clsSingleItem In nr.Items
                    Dim itm As clsSingleItem = nr.Items(iI)
                    If itm.MatchingPossibilities.Count = 0 Then
                        nr.Items.RemoveAt(iI)
                        If nr.Items.Count = 0 Then
                            bCheckNextScope = True
                            ' Reset refs to original
                            itm.MatchingPossibilities = task.NewReferencesWorking(iNR).Items(iI).MatchingPossibilities.Clone
                            bResetRef = True
                        Else
                            ' We still have some items, so at least our Visible scope reduced from previous
                        End If
                    ElseIf itm.MatchingPossibilities.Count > 1 Then
                        ' bCheckNextScope = True - no point checking next scope as that will always be a superset of Visible
                        'If ApplicableRefs Is Nothing Then ApplicableRefs = CType(NewRefs.Clone, clsNewReference()) ' Only use this ambiguous set if the Applicable scope didn't return anything
                        ' Leave existing refs to further refine by visibility
                    End If
                Next
                If bResetRef Then NewRefs(iNR) = CopyRef(task.NewReferences(iNR))
            End If
        Next

        If bCheckNextScope Then
            DebugPrint(ItemEnum.Task, task.Key, DebugDetailLevelEnum.High, "Checking scope: Seen")

            ' Remove any unseen references from our set
            'If bResetNewRefs Then NewRefs = task.CopyNewRefs(task.NewReferences)
            For Each nr As clsNewReference In NewRefs
                If nr IsNot Nothing Then
                    For Each itm As clsSingleItem In nr.Items
                        For i As Integer = itm.MatchingPossibilities.Count - 1 To 0 Step -1
                            Select Case nr.ReferenceType
                                Case ReferencesType.Object
                                    If Not Adventure.htblObjects(itm.MatchingPossibilities(i)).SeenBy(Adventure.Player.Key) Then itm.MatchingPossibilities.RemoveAt(i)
                            End Select
                        Next i
                    Next itm
                End If
            Next nr
        End If

        bCheckNextScope = False

        ' Check to see if this refined our possibilities to unique items
        For iNR As Integer = 0 To NewRefs.Length - 1
            Dim nr As clsNewReference = NewRefs(iNR)
            Dim bResetRef As Boolean = False
            If nr IsNot Nothing AndAlso nr.Items IsNot Nothing Then
                If nr.Items.Count = 0 Then
                    bCheckNextScope = True
                    bResetRef = True
                End If
                For iI As Integer = 0 To nr.Items.Count - 1
                    Dim itm As clsSingleItem = nr.Items(iI)
                    If itm.MatchingPossibilities.Count = 0 Then
                        bCheckNextScope = True
                        bResetRef = True
                        ' Reset refs to original
                        'itm.MatchingPossibilities = task.NewReferencesWorking(iNR).Items(iI).MatchingPossibilities.Clone
                    ElseIf itm.MatchingPossibilities.Count > 1 Then
                        bCheckNextScope = True
                        ' Leave existing refs to further refine by visibility
                    End If
                Next
                If bResetRef Then NewRefs(iNR) = CopyRef(task.NewReferences(iNR))
            End If
        Next

        'If bCheckNextScope AndAlso ApplicableRefs IsNot Nothing Then
        '    task.NewReferencesWorking = ApplicableRefs
        'Else
        task.NewReferencesWorking = NewRefs
        'End If


    End Sub


    Private Function GetGeneralTask(ByVal sInput As String, ByVal iMinimumPriority As Integer, ByVal bSecondChance As Boolean) As String

        'Dim iPriorityPass As Integer = Integer.MaxValue ' Lowest priority task that matches input and passes restrictions
        Dim iPriorityFail As Integer = Integer.MaxValue ' Lowest priority task that matches input and has output
        'Dim bCurrentPassed As Boolean = False
        'Dim GeneralTaskRefs(-1) As clsReferences
        'Dim GeneralTaskReferencesFail As New Hashtable
        'Dim bWeHaveFailureOutput As Boolean = False
        'Dim bIsTaskLowPriority As Boolean = False

        Dim sNoRefTask As String = "" ' We may match on a task, but find no references.  If so, at least return this rather than no task at all

        GetGeneralTask = Nothing
        If Not bSecondChance Then htblSecondChanceTasks.Clear()

        Try
            sAmbTask = Nothing
            Dim htblTasks As TaskHashTable = CType(IIf(bSecondChance, htblSecondChanceTasks, htblCompleteableGeneralTasks), TaskHashTable)

            'For Each tas As clsTask In htblTasks.Values
            For Each tk As TaskKey In listTaskKeys
                If htblTasks.ContainsKey(tk.sTaskKey) Then
                    Dim tas As clsTask = htblTasks(tk.sTaskKey)

                    If tas.Priority >= iMinimumPriority AndAlso Not (tas.LowPriority AndAlso tas.Priority > iPriorityFail) Then
                        'For Each sCom As String In tas.arlCommands
                        For iCom As Integer = 0 To tas.arlCommands.Count - 1
                            Dim sCom As String = tas.arlCommands(iCom)

                            'If tas.Priority < iPriority OrElse bWeHaveFailureOutput Then ' was Not bWeHaveFailureOutput
                            'Dim sPattern As String = ConvertToRE(sCom) ' TODO: Cache the RegEx pattern rather than calculating it every turn!

                            If InputMatchesCommand(tas, sInput, sCom, bSecondChance, False) Then

                                DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.Medium, "Task '" & tas.Description & "' matches input.")
                                iMatchedTaskCommand = iCom

                                ' Now see if user typed unique references (or none at all) which allow us to run the task                                

                                Dim bOkToRun As Boolean = True

                                tas.NewReferencesWorking = tas.CopyNewRefs(tas.NewReferences)
                                ' If any refs are vague, refine using restrictions
                                Dim bMatchesPreRefine As Boolean = True
                                For Each nr As clsNewReference In tas.NewReferences
                                    If nr IsNot Nothing Then
                                        For Each itm As clsSingleItem In nr.Items
                                            If itm.MatchingPossibilities.Count <> 1 Then
                                                bMatchesPreRefine = False
                                                Exit For
                                            End If
                                        Next itm
                                    End If
                                Next nr

                                ' Remove any references that don't pass the restrictions from our set
                                RefineMatchingPossibilitesUsingRestrictions(tas)

                                ' If we still have at least one matching possibility in each reference item, then run this task, else we don't pass
                                For Each nr As clsNewReference In tas.NewReferencesWorking
                                    If nr IsNot Nothing Then
                                        For Each itm As clsSingleItem In nr.Items
                                            If itm.MatchingPossibilities.Count = 0 Then
                                                ' Can we fall back to previous refs?  We need to fire this task rather than fall thru to not understood...
                                                If bMatchesPreRefine Then
                                                    tas.NewReferencesWorking = tas.CopyNewRefs(tas.NewReferences)
                                                Else
                                                    DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "No matches found.")
                                                    ' Should we perhaps fall back anyway and prompt for disambiguity - unless a lower priority one matches.  Hmm.... may need
                                                    ' to run the whole thing again with a different parameter.
                                                    If sNoRefTask = "" Then sNoRefTask = tas.Key
                                                    bOkToRun = False
                                                End If
                                                Exit For
                                            End If
                                            If itm.MatchingPossibilities.Count > 1 Then
                                                ' We have an ambiguity that needs to be resolved
                                                DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "Multiple matches.  Prompt for ambiguity.")
                                                sAmbTask = tas.Key
                                                bOkToRun = False
                                            End If
                                        Next itm
                                    End If
                                Next nr

                                If bOkToRun OrElse tas.ContinueToExecuteLowerPriority = clsTask.ContinueEnum.ContinueNever Then
                                    ' Woo-hoo, we have a unique match!
                                    If tas.References.Count > 0 Then
                                        DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "Command matches without ambiguity.")
                                    Else
                                        DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "Command matches.")
                                    End If

                                    NewReferences = tas.NewReferencesWorking
                                    Dim bDoesThisPass As Boolean = PassRestrictions(tas.arlRestrictions)

                                    If Not bDoesThisPass AndAlso tas.FailOverride.ToString <> "" AndAlso sRestrictionText = "" AndAlso ContainsWord(sInput, "all") Then
                                        sRestrictionText = tas.FailOverride.ToString
                                    End If

                                    ' If we pass restrictions, or if we haven't yet passed but we have output

                                    If bDoesThisPass OrElse sRestrictionText <> "" Then
                                        'If (bDoesThisPass AndAlso (Not bCurrentPassed OrElse tas.Priority < iPriority)) _
                                        '   OrElse ((Not bCurrentPassed OrElse (bIsTaskLowPriority AndAlso Not tas.LowPriority)) AndAlso tas.Priority < iPriority AndAlso sRestrictionText <> "") Then

                                        If bDoesThisPass Then
                                            If tas.Priority > iPriorityFail Then
                                                DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.Medium, "Task passes restrictions and overrides previous failing task output")
                                            Else
                                                DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.Medium, "Task passes restrictions.")
                                            End If
                                            'If Not bCurrentPassed Then
                                            '    DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.Medium, "Task passes restrictions.")
                                            'ElseIf tas.Priority < iPriority Then
                                            '    DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.Medium, "Task passes restrictions and is higher priority than previous task that passed.")
                                            'End If
                                        ElseIf sRestrictionText <> "" Then ' AndAlso tas.Priority < iPriority Then
                                            'If Not bCurrentPassed Then
                                            '    DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.Medium, "Task doesn't pass restrictions, but is current highest priority failing task with restriction output.")
                                            'ElseIf bIsTaskLowPriority Then
                                            '    DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.Medium, "Task doesn't pass restrictions, but previous task could be overridden by other task restriction failures.")
                                            'End If
                                            DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.Medium, "Task doesn't pass restrictions, but is current highest priority failing task with restriction output.")
                                        End If

                                        GetGeneralTask = tas.Key
                                        'iPriority = tas.Priority
                                        If sRestrictionText <> "" Then iPriorityFail = tas.Priority
                                        'If bDoesThisPass Then iPriorityPass = tas.Priority
                                        DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "Task priority: " & tas.Priority)
                                        'If Not bCurrentPassed Then bCurrentPassed = bDoesThisPass
                                        'If bDoesThisPass Then bIsTaskLowPriority = tas.LowPriority
                                        'If sRestrictionText <> "" Then bWeHaveFailureOutput = True

                                        If bDoesThisPass Then GoTo FoundTask

                                        ' This section below was commented out.  But I think it needs to be here, because
                                        ' we're working out what task to run, and otherwise we would continue on and return
                                        ' a lower priority task if we just have a higher priority failing one here.
                                        '
                                        Select Case tas.ContinueToExecuteLowerPriority
                                            Case clsTask.ContinueEnum.ContinueAlways
                                                DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "Will continue checking lower priority tasks.") ' WHY?  SHOULD THIS BE REMOVED?
                                            Case clsTask.ContinueEnum.ContinueNever
                                                DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "Will not continue checking lower priority tasks as this one matched input.")
                                                GoTo FoundTask
                                            Case clsTask.ContinueEnum.ContinueOnFail
                                                If Not bDoesThisPass Then
                                                    DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "Will continue checking lower priority tasks as this one matched input but did not pass restrictions.")
                                                Else
                                                    DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "Will not continue checking lower priority tasks as this one passed restrictions.")
                                                    GoTo FoundTask
                                                End If
                                            Case clsTask.ContinueEnum.ContinueOnNoOutput
                                                If (Not bDoesThisPass AndAlso sRestrictionText <> "") OrElse (bDoesThisPass AndAlso tas.CompletionMessage.ToString <> "") Then
                                                    DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "Will not continue checking lower priority tasks as this one has text output.")
                                                    GoTo FoundTask
                                                Else
                                                    DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "Will continue checking lower priority tasks as this one matched input but did not have text output.")
                                                End If
                                        End Select

                                        'If tas.ContinueToExecuteLowerPriority = clsTask.ContinueEnum.ContinueNever Then
                                        '    'bWeHaveFailureOutput = False ' Stop testing any further tasks
                                        '    DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.Medium, "No more tasks will be checked, as this one matched.")
                                        'End If
                                        'sAmbTask = Nothing

                                    Else
                                        DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.Medium, "Task does not pass restrictions.")
                                    End If

                                    Exit For ' task

                                End If

                            End If

                            'End If
                        Next
                    End If
                End If
            Next
FoundTask:

            If GetGeneralTask Is Nothing AndAlso sNoRefTask <> "" Then GetGeneralTask = sNoRefTask

            'References = GeneralTaskRefs
            'htblReferencesFail = CType(GeneralTaskReferencesFail.Clone, Hashtable)
            If GetGeneralTask Is Nothing AndAlso sAmbTask Is Nothing AndAlso Not bSecondChance Then
                ' Ok, no luck.  Let's go back and see if one of our 'exist' tasks worked
                DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.Medium, "No matches found.  Checking again using existance.")
                Return GetGeneralTask(sInput, iMinimumPriority, True)
            End If

        Catch ex As Exception
            ErrMsg("GetGeneralTask Error", ex)
        End Try

    End Function


    Private Function IsNoun(ByVal sName As String) As Boolean

        Dim re As New System.Text.RegularExpressions.Regex("")

        For Each ob As clsObject In Adventure.htblObjects.Values
            Dim sOb As String = ob.sRegularExpressionString
            If System.Text.RegularExpressions.Regex.IsMatch(sName, "^" & sOb & "s?$") Then Return True
        Next ob

        Return False

    End Function



    '    ' Work out which objects were actually mentioned on the command line that we need in our task
    '    Private Function CalcRefs(ByVal cTask As clsTask, ByVal sCommand As String, ByVal sPattern As String, ByVal Scope As eScope) As Boolean

    '        Dim sBlocks() As String
    '        Dim iLength As Integer = 0
    '        'Dim bReference As Boolean
    '        Dim sOrigBlock As String
    '        Dim re As New System.Text.RegularExpressions.Regex("")
    '        Dim sReplace As String = Nothing
    '        Dim iRefCount As Integer = 0
    '        Dim iRefOb As Integer
    '        Dim sOrigPattern As String = sPattern
    '        'If Not References Is Nothing Then
    '        '    Return True
    '        'End If


    '        sBlocks = Split(sPattern, "%")
    '        Erase References
    '        'Erase StartReferences
    '        'Erase ReferencesPass
    '        'Erase ReferencesFail

    '        DebugPrint(ItemEnum.Task, cTask.Key, DebugDetailLevelEnum.High, "Calculating References for task " & cTask.Description & ", ", False)

    '        Select Case Scope
    '            Case eScope.Applicable
    '                DebugPrint(ItemEnum.Task, cTask.Key, DebugDetailLevelEnum.High, "scope: Applicable")
    '            Case eScope.Visible
    '                DebugPrint(ItemEnum.Task, cTask.Key, DebugDetailLevelEnum.High, "scope: Visible")
    '            Case eScope.Seen
    '                DebugPrint(ItemEnum.Task, cTask.Key, DebugDetailLevelEnum.High, "scope: Seen")
    '        End Select

    '        For Each sBlock As String In sBlocks

    '            'bReference = False
    '            sOrigBlock = sBlock

    '            Select Case sBlock.ToLower
    '                Case "character", "characters", "direction", "number", "numbers", "object1", "object2", "object3", "object4", "object5", "objects", "text"
    '                    If sOrigPattern.Substring(iLength - 1, 1) = "%" AndAlso sOrigPattern.Substring(iLength + sBlock.Length, 1) = "%" Then
    '                        'bReference = True
    '                        iRefCount += 1

    '                        Select Case sBlock.ToLower
    '                            Case "object1", "object2", "object3", "object4", "object5", "objects"
    '                                iRefOb += 1

    '                        End Select


    '                        ReDim Preserve References(iRefCount - 1)
    '                        References(iRefCount - 1) = New clsReferences
    '                        With References(iRefCount - 1)

    '                            '.alReferences.Add(New StringArrayList) ' List of all keys matching our input

    '                            'For Each salRefs As StringArrayList In .alReferences
    '                            '    .iTotalMatching += salRefs.Count
    '                            'Next

    '                            'Dim iAddCheck As Integer = salKeys.Count

    '                            Select Case sBlock.ToLower

    '                                Case "character"
    '                                    .sRefType = ReferencesType.Character
    '                                    .bMultiple = False

    '                                Case "characters"
    '                                    .sRefType = ReferencesType.Character
    '                                    .bMultiple = True

    '                                Case "direction"
    '                                    .sRefType = ReferencesType.Direction
    '                                    .bMultiple = False

    '                                    .alReferences.Add(New SingleRef)
    '                                    For dr As DirectionsEnum = DirectionsEnum.North To Adventure.iCompassPoints ' DirectionsEnum.NorthWest
    '                                        Select Case dr
    '                                            Case [Global].DirectionsEnum.North
    '                                                sReplace = "(north|n)"
    '                                            Case [Global].DirectionsEnum.East
    '                                                sReplace = "(east|e)"
    '                                            Case [Global].DirectionsEnum.South
    '                                                sReplace = "(south|s)"
    '                                            Case [Global].DirectionsEnum.West
    '                                                sReplace = "(west|w)"
    '                                            Case [Global].DirectionsEnum.Up
    '                                                sReplace = "(up|u)"
    '                                            Case [Global].DirectionsEnum.Down
    '                                                sReplace = "(down|d)"
    '                                            Case [Global].DirectionsEnum.In
    '                                                sReplace = "(in)"
    '                                            Case [Global].DirectionsEnum.Out
    '                                                sReplace = "(outside|out|o)"
    '                                            Case [Global].DirectionsEnum.NorthEast
    '                                                sReplace = "(northeast|north-east|north_east|n-e|ne)"
    '                                            Case [Global].DirectionsEnum.SouthEast
    '                                                sReplace = "(southeast|south-east|south_east|s-e|se)"
    '                                            Case [Global].DirectionsEnum.SouthWest
    '                                                sReplace = "(southwest|south-west|south_west|s-w|sw)"
    '                                            Case [Global].DirectionsEnum.NorthWest
    '                                                sReplace = "(northwest|north-west|north_west|n-w|nw)"
    '                                        End Select
    '                                        If System.Text.RegularExpressions.Regex.IsMatch(sCommand, ConvertToRE(Replace(sPattern, "%direction%", sReplace, 1, 1))) Then
    '                                            'salKeys.Add(dr.ToString)
    '                                            .alReferences(0).salWhat.Add(dr.ToString)
    '                                            Exit For
    '                                        End If
    '                                    Next

    '                                Case "number"
    '                                    .sRefType = ReferencesType.Number
    '                                    .bMultiple = False

    '                                Case "numbers"
    '                                    .sRefType = ReferencesType.Number
    '                                    .bMultiple = True

    '                                Case "object1", "object2", "object3", "object4", "object5"
    '                                    .sRefType = ReferencesType.Object
    '                                    .bMultiple = False

    '                                    .alReferences.Add(New SingleRef)

    '                                    Dim bFound As Boolean = False
    '                                    For iScope As eScope = eScope.Applicable To eScope.Seen
    '                                        'For Each ob As clsObject In ValidReferencedObjects(cTask, iRefOb, iScope).Values
    '                                        '    sReplace = ob.sRegularExpressionString
    '                                        '    If System.Text.RegularExpressions.Regex.IsMatch(sCommand, ConvertToRE(Replace(sPattern, "%object" & iRefOb & "%", sReplace, 1, 1))) Then
    '                                        '        .alReferences(0).salWhat.Add(ob.Key)
    '                                        '        bFound = True
    '                                        '    End If
    '                                        'Next
    '                                        For Each ob As clsObject In Adventure.htblObjects.Values
    '                                            sReplace = ob.sRegularExpressionString
    '                                            If System.Text.RegularExpressions.Regex.IsMatch(sCommand, ConvertToRE(Replace(sPattern, "%object" & iRefOb & "%", sReplace, 1, 1))) Then
    '                                                If ValidReferencedObjects(cTask, iRefOb, iScope).ContainsKey(ob.Key) Then
    '                                                    .alReferences(0).salWhat.Add(ob.Key)
    '                                                    bFound = True
    '                                                End If
    '                                            End If
    '                                        Next
    '                                        If bFound Then Exit For
    '                                    Next

    '                                Case "objects"
    '                                    .sRefType = ReferencesType.Object
    '                                    .bMultiple = True

    '                                    sPattern = ConvertToRE(sPattern, False, False)
    '                                    Dim sObjectList As String = System.Text.RegularExpressions.Regex.Replace(sCommand, "^" & Left(sPattern, sInstr(sPattern, "%objects%") - 1), "")
    '                                    Dim sEndPattern As String = Right(sPattern, sPattern.Length - sInstr(sPattern, "%objects%") - 8) & "$"
    '                                    ' Need to match off any references still in sEndPattern - just use wildcards for now (lazy!)
    '                                    sEndPattern = ConvertToRE(sEndPattern, True, False)
    '                                    sObjectList = " " & System.Text.RegularExpressions.Regex.Replace(sObjectList, sEndPattern, "")

    '                                    If sObjectList <> "" Then
    '                                        sObjectList = sObjectList.Replace(" and ", " , ").Replace(" all ", " ,all, ").Replace(" but ", " except ").Replace(" apart from ", " except ").Replace(" except ", " ,except, ")
    '                                        Dim sObjects() As String = Split(sObjectList, ",")
    '                                        ' remove any empty entries
    '                                        For i As Integer = sObjects.Length - 1 To 0 Step -1
    '                                            If Trim(sObjects(i)) = "" Then
    '                                                For j As Integer = i To sObjects.Length - 2
    '                                                    sObjects(j) = sObjects(j + 1)
    '                                                Next
    '                                                ReDim Preserve sObjects(sObjects.Length - 2)
    '                                            End If
    '                                        Next
    'InsertAll:
    '                                        DebugPrint(ItemEnum.Task, cTask.Key, DebugDetailLevelEnum.High, "Ok, we've got our list of requested objects: ", False)
    '                                        For Each sObject As String In sObjects
    '                                            DebugPrint(ItemEnum.Task, cTask.Key, DebugDetailLevelEnum.High, sObject & ", ", False)
    '                                        Next
    '                                        DebugPrint(ItemEnum.Task, cTask.Key, DebugDetailLevelEnum.High, "")

    '                                        Dim iRef As Integer = 0
    '                                        Dim bExcept As Boolean = False
    '                                        Dim iObNum As Integer = 0
    '                                        Dim iExceptApplyTo As Integer = 0
    '                                        Dim sAllReference As String = Nothing
    '                                        For Each sObject As String In sObjects
    '                                            If sObject <> "" Then ' We've swallowed it in our all check
    '                                                iObNum += 1
    '                                                sObject = Trim(sObject)
    '                                                'InsertAll:
    '                                                Select Case sObject
    '                                                    Case "and"
    '                                                        ' ignore
    '                                                    Case "all"
    '                                                        ' Check the next word(s).  If if's a noun, apply it to all, else get all in scope                                                        
    '                                                        If iObNum < sObjects.Length Then
    '                                                            sAllReference = Trim(sObjects(iObNum))
    '                                                            If IsNoun(sAllReference) Then
    '                                                                sObjects(iObNum) = ""
    '                                                                iObNum += 1
    '                                                                If Not bExcept Then iExceptApplyTo = .alReferences.Count
    '                                                            Else
    '                                                                sAllReference = Nothing
    '                                                            End If
    '                                                        End If

    '                                                        Dim bFound As Boolean = False
    '                                                        For iScope As eScope = eScope.Applicable To eScope.Seen
    '                                                            For Each ob As clsObject In ValidReferencedObjects(cTask, iRefOb, iScope).Values
    '                                                                If sAllReference Is Nothing OrElse System.Text.RegularExpressions.Regex.IsMatch(sAllReference, "^" & ob.sRegularExpressionString & "(s)?$") Then
    '                                                                    .alReferences.Add(New SingleRef)
    '                                                                    .alReferences(iRef).salWhat.Add(ob.Key)
    '                                                                    .alReferences(iRef).bExcept = bExcept
    '                                                                    iRef += 1
    '                                                                    bFound = True
    '                                                                End If
    '                                                            Next
    '                                                            If bFound Then Exit For
    '                                                        Next

    '                                                    Case "except"
    '                                                        bExcept = Not bExcept  ' True
    '                                                    Case Else
    '                                                        Dim bAdded As Boolean = False
    '                                                        Dim bDealtWith As Boolean = False
    '                                                        'If iRef > 0 Then
    '                                                        .alReferences.Add(New SingleRef)
    '                                                        Dim bFound As Boolean = False
    '                                                        For iScope As eScope = eScope.Applicable To eScope.Seen
    '                                                            For Each ob As clsObject In ValidReferencedObjects(cTask, iRefOb, iScope).Values
    '                                                                sReplace = ob.sRegularExpressionString
    '                                                                If System.Text.RegularExpressions.Regex.IsMatch(sObject, "^" & sReplace & "$") OrElse (Not sAllReference Is Nothing AndAlso System.Text.RegularExpressions.Regex.IsMatch(sObject & " " & sAllReference, "^" & sReplace & "(s)?$")) Then
    '                                                                    bDealtWith = True
    '                                                                    .alReferences(iRef).salWhat.Add(ob.Key)
    '                                                                    .alReferences(iRef).bExcept = bExcept
    '                                                                    bAdded = True
    '                                                                    bFound = True
    '                                                                Else
    '                                                                    If System.Text.RegularExpressions.Regex.IsMatch(sObject, "^" & sReplace & "s$") Then
    '                                                                        bDealtWith = True
    '                                                                        ' Check previous references to make sure they don't apply to this noun
    '                                                                        ' e.g. get red and blue balls.  This is a bit of a fudge
    '                                                                        For i As Integer = 0 To iObNum - 2
    '                                                                            If .alReferences(i).salWhat.Count = 0 Then
    '                                                                                sObjects(i) = (sObjects(i) & " " & ob.arlNames(0)).Replace("  ", " ")
    '                                                                            End If
    '                                                                        Next
    '                                                                        ' End of fudge

    '                                                                        ' Insert the implied 'all' before the subject
    '                                                                        '.alReferences.RemoveAt(.alReferences.Count - 1)
    '                                                                        .alReferences.Clear()
    '                                                                        ReDim Preserve sObjects(sObjects.Length)
    '                                                                        For i As Integer = sObjects.Length - 2 To iObNum - 1 Step -1
    '                                                                            sObjects(i + 1) = sObjects(i)
    '                                                                        Next
    '                                                                        sObjects(iObNum - 1) = "all" ' Try "get all except big balls"
    '                                                                        sObject = "all"

    '                                                                        GoTo InsertAll

    '                                                                    End If
    '                                                                End If
    '                                                            Next
    '                                                            If bFound Then Exit For
    '                                                        Next

    '                                                        If iRef > -1 AndAlso iRef < .alReferences.Count AndAlso .alReferences(iRef).salWhat.Count = 0 Then .alReferences.RemoveAt(iRef)
    '                                                        If bAdded Then iRef += 1
    '                                                End Select
    '                                            End If
    '                                        Next sObject
    '                                    End If
    '                                Case "text"
    '                            End Select

    '                            Dim iMatchCount As Integer = 0
    '                            For Each sr As SingleRef In .alReferences
    '                                iMatchCount += sr.salWhat.Count
    '                            Next
    '                            DebugPrint(ItemEnum.Task, cTask.Key, DebugDetailLevelEnum.High, "Found " & iMatchCount & " matching " & .sRefType.ToString & CStr(IIf(iMatchCount = 1, "", "s")))
    '                            'If salKeys.Count = iAddCheck Then Return False
    '                            If iMatchCount = 0 Then Return False ' We didn't find any new
    '                            PrintOutReferences()

    '                            ' Remove this pattern so we don't reprocess it
    '                            sPattern = Replace(sPattern, "%" & sBlock & "%", ".*", 1, 1)

    '                        End With

    '                    End If
    '                Case Else
    '                    ' Not a reference
    '            End Select

    '            iLength += sOrigBlock.Length + 1

    '        Next

    '        Return True

    '    End Function


    'Private Function DeepCopy(ByVal Refs() As clsReferences) As clsReferences()

    '    Dim NewRefs() As clsReferences

    '    If Refs Is Nothing Then
    '        ReDim NewRefs(-1)
    '        Return NewRefs
    '    End If
    '    ReDim NewRefs(Refs.Length - 1)

    '    For iRef As Integer = 0 To Refs.Length - 1
    '        NewRefs(iRef) = New clsReferences
    '        NewRefs(iRef).bMultiple = Refs(iRef).bMultiple
    '        NewRefs(iRef).sRefType = Refs(iRef).sRefType
    '        Dim ref As clsReferences = Refs(iRef)
    '        For Each sal As SingleRef In ref.alReferences
    '            NewRefs(iRef).alReferences.Add(sal)
    '        Next
    '    Next

    '    Return NewRefs

    'End Function


    'Private Function CalcFailRefs(ByVal Refs() As clsReferences, ByVal arlRestrictions As RestrictionArrayList) As Boolean

    '    ' First, we need to be in a state where every reference is individual, then we check if it passes

    '    Dim bMultiple As Boolean = False
    '    CalcFailRefs = True

    '    If Refs Is Nothing Then Exit Function

    '    ' If any refs are multiples, run CalcFailRefs on each one in turn, else evaluate
    '    For Each ref As clsReferences In Refs
    '        If ref.alReferences.Count > 1 Then
    '            bMultiple = True
    '            Exit For
    '        End If
    '    Next

    '    If bMultiple Then
    '        ' Create a new copy of the reference with each ref individually, in turn
    '        For Each ref As clsReferences In Refs
    '            If ref.alReferences.Count > 1 Then
    '                For iSal As Integer = ref.alReferences.Count - 1 To 0 Step -1
    '                    'For Each sal As StringArrayList In ref.alReferences
    '                    Dim sal As StringArrayList = ref.alReferences(iSal).salWhat
    '                    If sal.Count > 0 Then
    '                        Dim alRef As New RefArrayList
    '                        Dim sr As New SingleRef
    '                        sr.salWhat = sal
    '                        alRef.Add(sr)
    '                        Dim alOrigRefs As RefArrayList = ref.alReferences
    '                        ref.alReferences = alRef
    '                        If Not CalcFailRefs(Refs, arlRestrictions) Then
    '                            ' Remove this ref from References
    '                            alOrigRefs.RemoveAt(iSal)
    '                        End If
    '                        ref.alReferences = alOrigRefs
    '                    End If
    '                Next
    '            End If
    '        Next
    '    Else
    '        ' Ok, looking at single refs only
    '        bNoDebug = True
    '        If Not PassRestrictions(arlRestrictions) Then
    '            bNoDebug = False
    '            AddFail(Refs)
    '            Return False
    '        End If
    '        bNoDebug = False
    '    End If

    'End Function

    'Private Sub AddFail(ByRef Refs() As clsReferences)

    '    If Not Refs Is Nothing AndAlso Refs.Length > 0 AndAlso Refs(0).alReferences.Count = 0 Then
    '        DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.High, "Failed (no refs!)")
    '    ElseIf Not Refs Is Nothing AndAlso Refs.Length > 0 AndAlso Refs(0).alReferences(0).salWhat.Count > 0 Then
    '        DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.High, "Failed restriction for '" & Adventure.GetNameFromKey(Refs(0).alReferences(0).salWhat(0)) & "'")
    '    Else
    '        DebugPrint(ItemEnum.Task, "", DebugDetailLevelEnum.High, "Failed restriction for key NOTHING")
    '    End If

    '    If sRestrictionText Is Nothing Then sRestrictionText = ""
    '    If htblReferencesFail.ContainsKey(sRestrictionText) Then
    '        ' Add this key into the references in the hashtable
    '        Dim RefH() As clsReferences
    '        RefH = CType(htblReferencesFail(sRestrictionText), clsReferences())
    '        For i As Integer = 0 To RefH.Length - 1
    '            If Refs(i).alReferences.Count > 0 AndAlso Not RefH(i).alReferences.Contains(Refs(i).alReferences(0)) Then
    '                RefH(i).alReferences.Add(Refs(i).alReferences(0))
    '            End If
    '        Next
    '    Else
    '        ' Add a new entry into the hashtable with this reference
    '        htblReferencesFail.Add(sRestrictionText, DeepCopy(Refs))
    '    End If

    'End Sub



    'Private Function ValidReferencedObjects(ByVal cTask As clsTask, ByVal iReferenceNumber As Integer, ByVal Scope As eScope) As ObjectHashTable

    '    Select Case Scope
    '        Case eScope.Applicable

    '            Dim htblObs As New ObjectHashTable

    '            If References(iReferenceNumber - 1).sRefType <> ReferencesType.Object Then Return Nothing

    '            If ValidRefs Is Nothing Then CalcValidReferences(cTask)
    '            Dim salKeys As StringArrayList() = CType(ValidRefs(cTask.Key), StringArrayList())
    '            If Not salKeys Is Nothing Then
    '                For Each sKey As String In salKeys(iReferenceNumber - 1)
    '                    If Not htblObs.ContainsKey(sKey) Then htblObs.Add(Adventure.htblObjects(sKey), sKey)
    '                Next
    '            End If

    '            Return htblObs

    '        Case eScope.Visible
    '            Return htblVisibleObjects

    '        Case eScope.Seen
    '            Return htblSeenObjects

    '        Case Else
    '            Return Nothing

    '    End Select

    'End Function


    ''' <summary>
    ''' Converts a lazy Advanced Command to strict format, removing possibility for double spaces
    ''' </summary>
    ''' <param name="sCommand"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CorrectCommand(ByVal sCommand As String) As String
        Dim sNewCommand As String = ProcessBlock(sCommand)
        If sNewCommand <> sCommand Then
            Debug.WriteLine(String.Format("Converted ""{0}"" to ""{1}""", sCommand, sNewCommand))
            sCommand = sCommand
        End If
        Return sNewCommand
    End Function



    ' E.g. from "get {the} ball" > "get ", from "{the} ball" > "the", " ball" > "" 
    Private Function GetSubBlock(ByRef sBlock As String) As String

        Dim iDepth As Integer = 0
        Dim sNewBlock As String = ""

        For i As Integer = 0 To sBlock.Length - 1
            sNewBlock &= sBlock(i)
            Select Case sBlock(i)
                Case "{"c, "["c
                    If iDepth = 0 AndAlso sNewBlock <> sBlock(i) Then
                        sBlock = sRight(sBlock, sBlock.Length - sNewBlock.Length + 1)
                        Return sLeft(sNewBlock, i)
                    End If
                    iDepth += 1
                Case "]"c, "}"c
                    iDepth -= 1
                    If iDepth = 0 Then
                        sBlock = sRight(sBlock, sBlock.Length - sNewBlock.Length)
                        Return sNewBlock
                    End If
                Case "/"c
                    If iDepth = 0 Then
                        sBlock = sRight(sBlock, sBlock.Length - sNewBlock.Length)
                        Return sNewBlock
                    End If
            End Select
        Next

        sBlock = ""
        Return sNewBlock

    End Function


    ' A block should be the complete entry between two brackets, or between a bracket and a slash
    Private Function ProcessBlock(ByVal sBlock As String) As String

        Dim sAfter As String = sBlock
        Dim sNextBlock As String = ""
        Dim sBefore As String = ""

        Do
            sNextBlock = GetSubBlock(sAfter)
            If sNextBlock <> "" Then
                If sNextBlock.StartsWith("{") Then
                    ' */ "] {#} {" => "]{ #}{"
                    ' "] {#} [" => ?
                    ' "} {#} [" => ?
                    ' "} {#} {" => ? /*
                    ' "{#} " => "{# }" if block starts with open bracket
                    ' " {#} " => " {# }"
                    ' "}{#} " => "}{# }"        -- should this be " }{#} " => " }{# }" ?
                    If (sBefore = "" OrElse sRight(sBefore, 1) = " " OrElse sRight(sBefore, 1) = "}") AndAlso sAfter.StartsWith(" ") Then
                        If sNextBlock.Contains("/") Then
                            sNextBlock = "{[" & sLeft(sNextBlock.Substring(1), sNextBlock.Length - 2) & "] }"
                        Else
                            sNextBlock = sLeft(sNextBlock, sNextBlock.Length - 1) & " }"
                        End If
                        sAfter = sRight(sAfter, sAfter.Length - 1)
                        'If sBefore.EndsWith(" ") andalso Not sAfter.Contains(
                    End If
                    ' " {#}" => "{ #}" if block ends with close bracket - TODO
                    If sBefore.EndsWith(" ") AndAlso sAfter.StartsWith("{") AndAlso sAfter.EndsWith("}") AndAlso Not sAfter.Substring(1).Contains("{") AndAlso Not sAfter.Contains("[") Then
                        'If sAfter.Contains("/") Then
                        '    sAfter = "{ [" & sLeft(sAfter.Substring(1), sAfter.Length - 2) & "]}"
                        'Else
                        '    sAfter = "{ " & sLeft(sAfter.Substring(1), sAfter.Length - 1)
                        'End If
                        'If sNextBlock.Contains("/") Then
                        '    sNextBlock = "{ [" & sLeft(sNextBlock.Substring(1), sNextBlock.Length - 2) & "]}"
                        'Else
                        '    sNextBlock = "{ " & sLeft(sNextBlock.Substring(1), sNextBlock.Length - 1)
                        'End If
                        'sBefore = sLeft(sBefore, sBefore.Length - 1)
                    End If

                    ' End block
                    ' " {#}" => "{ #}" or "{ [#/#]}
                    If sBefore.EndsWith(" ") AndAlso sAfter = "" Then
                        If sNextBlock.Contains("/") Then
                            sNextBlock = "{ [" & sLeft(sNextBlock.Substring(1), sNextBlock.Length - 2) & "]}"
                        Else
                            sNextBlock = "{ " & sLeft(sNextBlock.Substring(1), sNextBlock.Length - 1)
                        End If
                        sBefore = sLeft(sBefore, sBefore.Length - 1)
                    End If
                    sBefore &= "{" & ProcessBlock(sMid(sNextBlock, 2, sNextBlock.Length - 2)) & "}"
                ElseIf sNextBlock.StartsWith("[") Then
                    sBefore &= "[" & ProcessBlock(sMid(sNextBlock, 2, sNextBlock.Length - 2)) & "]"
                ElseIf sNextBlock.EndsWith("/") Then
                    sBefore &= ProcessBlock(sLeft(sNextBlock, sNextBlock.Length - 1)) & "/"
                Else
                    sBefore &= sNextBlock
                End If
            End If
        Loop While sAfter <> ""

        Return sBefore

    End Function



    Public Function ConvertToRE(ByVal sCommand As String, Optional ByVal bReplaceRefs As Boolean = True, Optional ByVal bTerminate As Boolean = True) As String

        Dim sC As String = sCommand

        ' Convert wildcards
        sC = sC.Replace(" * ", " ([[#]] )?")
        sC = sC.Replace("* ", "([[#]] )?")
        sC = sC.Replace(" *", "( [[#]])?")
        sC = sC.Replace("*", "[[#]]")
        sC = sC.Replace("[[#]]", ".*?")
        'sC = sC.Replace("*", ".*")

        ' Convert any special RE characters
        'sC = sC.Replace("&", "\&")
        sC = sC.Replace("+", "\+")

        'sC = sC.Replace(" ", "( )?").Replace("( )?*( )?", "( .* | )").Replace("( )?*", "( .*| )").Replace("*( )?", "(.* | )")
        sC = sC.Replace("_", " ")

        ' Convert optional text and mandatory text
        sC = sC.Replace("{", "(").Replace("}", ")?").Replace("[", "(").Replace("]", ")").Replace("/", "|")

        If bReplaceRefs Then
            ' Replace references
            sC = sC.Replace("%direction%", "(?<direction>north|east|south|west|up|down|in|out|northeast|southeast|southwest|northwest|n|e|s|w|u|d|o|ne|se|sw|nw|north-east|south-east|south-west|north-west|n-e|s-e|s-w|n-w|outside|inside)")
            ' TODO - replace above with custom names if changed

            sC = sC.Replace("%objects%", "(?<objects>.+)")
            sC = sC.Replace("%characters%", "(?<characters>.+)")
            sC = sC.Replace("%text%", "(?<text>.+?)") ' ? after + makes this a non-greedy match
            sC = sC.Replace("%number%", "(?<number>-?[0-9]+)")

            For iref As Integer = 1 To 5
                sC = sC.Replace("%object" & iref & "%", "(?<object" & iref & ">.+)")
                sC = sC.Replace("%character" & iref & "%", "(?<character" & iref & ">.+)")
            Next
        End If

        'While sC.Contains("( )?( )?")
        '    sC = sC.Replace("( )?( )?", "( )?")
        'End While
        'sC = sC.Replace("( )?", " ")
        sC = sC.Trim

        If bTerminate Then
            Return "^" & sC & "$"
        Else
            Return sC
        End If

    End Function





    '' Calculate the possible valid references for each task prior to command execution
    'Private Sub CalcValidReferences(ByVal tas As clsTask)

    '    Try
    '        bNoDebug = True

    '        Dim tmpRefs() As clsReferences = References

    '        ValidRefs = New Hashtable
    '        ValidRefs.Clear()

    '        'For Each tas As clsTask In htblCompleteableGeneralTasks.Values

    '        Dim iNumRefs As Integer = NumberOfRefs(tas)
    '        Dim sRefs(iNumRefs - 1) As StringArrayList

    '        ReDim References(iNumRefs - 1)
    '        For iRef As Integer = 0 To iNumRefs - 1
    '            References(iRef) = New clsReferences
    '        Next

    '        If iNumRefs > 0 Then
    '            sRefs(0) = New StringArrayList
    '            ' i.e. if we have referenced objects, go thru all the objects and check if it passes restrictions
    '            For Each sKey0 As String In GetHtblKeys(GetReferenceKey(tas.arlCommands(0), 1), 0)

    '                If iNumRefs > 1 Then
    '                    sRefs(1) = New StringArrayList
    '                    For Each sKey1 As String In GetHtblKeys(GetReferenceKey(tas.arlCommands(0), 2), 1)

    '                        If iNumRefs > 2 Then
    '                            ' Do as and when I need more than 2 refs...
    '                        Else
    '                            If Check(tas, New String() {sKey0, sKey1}) Then
    '                                sRefs(0).Add(sKey0)
    '                                sRefs(1).Add(sKey1)
    '                                bNoDebug = False
    '                                DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "References " & Adventure.GetNameFromKey(sKey0) & " & " & Adventure.GetNameFromKey(sKey1) & " match.")
    '                                bNoDebug = True
    '                            End If
    '                        End If

    '                    Next
    '                Else
    '                    If Check(tas, New String() {sKey0}) Then
    '                        sRefs(0).Add(sKey0)
    '                        bNoDebug = False
    '                        DebugPrint(ItemEnum.Task, tas.Key, DebugDetailLevelEnum.High, "Reference " & Adventure.GetNameFromKey(sKey0) & " matches.")
    '                        bNoDebug = True
    '                    End If
    '                End If

    '            Next
    '        Else
    '            ' Nothing to check
    '        End If

    '        ValidRefs.Add(tas.Key, sRefs)

    '        'Next

    '        References = tmpRefs

    '        bNoDebug = False

    '    Catch ex As Exception
    '        ErrMsg("CalcCalidReferences error", ex)
    '    End Try

    'End Sub



    '' Try out different things in the references to see which one passes the restrictions
    'Private Function Check(ByVal cTask As clsTask, ByVal sRefs() As String) As Boolean

    '    ReDim References(sRefs.Length - 1)
    '    For iRef As Integer = 0 To sRefs.Length - 1
    '        References(iRef) = New clsReferences
    '        References(iRef).alReferences.Add(New SingleRef)
    '        Select Case GetReferenceKey(cTask.arlCommands(0), iRef + 1)
    '            Case "ReferencedObject1", "ReferencedObject2", "ReferencedObject3", "ReferencedObject4", "ReferencedObject5", "ReferencedObjects"
    '                References(iRef).sRefType = ReferencesType.Object
    '            Case "ReferencedDirection"
    '                References(iRef).sRefType = ReferencesType.Direction
    '            Case Else
    '                iRef = iRef
    '        End Select
    '        'References(iRef).sRefType = ReferencesType.Object
    '        References(iRef).alReferences(0).salWhat.Add(sRefs(iRef))
    '    Next

    '    Return PassRestrictions(cTask.arlRestrictions)
    '    'If PassRestrictions(cTask.arlRestrictions) Then

    '    'End If

    'End Function


    Private Function GetHtblKeys(ByVal sRefType As String, ByVal iRef As Integer) As System.Collections.ICollection

        Select Case sRefType
            Case "ReferencedObject1", "ReferencedObject2", "ReferencedObject3", "ReferencedObject4", "ReferencedObject5", "ReferencedObjects"
                Return Adventure.htblObjects.Keys
            Case "ReferencedDirection", "number", "character", "text"
                Return New Collection
            Case Else
                iRef = iRef
        End Select

        Return Nothing

    End Function

    Private Function GetHtblAtPos(ByVal htbl As Hashtable, ByVal iPos As Integer) As Object

        Dim iCounter As Integer = 0
        For Each item As Object In htbl.Values
            iCounter += 1
            If iCounter = iPos Then Return item
        Next

        Return Nothing

    End Function


    ' Returns the number of references in a task
    Private Function NumberOfRefs(ByVal cTask As clsTask) As Integer

        Dim sTokens() As String = cTask.arlCommands(0).Split(" "c)
        Dim iNoRefs As Integer = 0

        For Each sToken As String In sTokens
            Select Case sToken
                Case "%character%", "%characters", "%direction%", "%number%", "%numbers%", "%object1%", "%object2%", "%object3%", "%object4%", "%object5%", "%objects%", "%text%"
                    iNoRefs += 1
            End Select
        Next

        Return iNoRefs

    End Function


#If Not www Then
    Public Sub SaveFormPosition(ByVal frmForm As System.Windows.Forms.Form)

        ' Function to record the position and state of a form
        SaveSetting("ADRIFT", "Runner", frmForm.Name & "_State", Format(frmForm.WindowState))

        If frmForm.WindowState = FormWindowState.Normal Then
            SaveSetting("ADRIFT", "Runner", frmForm.Name & "_Top", Format(frmForm.Top))
            SaveSetting("ADRIFT", "Runner", frmForm.Name & "_Left", Format(frmForm.Left))
            SaveSetting("ADRIFT", "Runner", frmForm.Name & "_Height", Format(frmForm.Height))
            SaveSetting("ADRIFT", "Runner", frmForm.Name & "_Width", Format(frmForm.Width))
        End If

    End Sub


#If Mono Then
    Public Sub GetFormPosition(ByRef frmForm As System.Windows.Forms.Form, Optional ByVal utm As Object = Nothing, Optional ByVal udm As Object = Nothing, Optional ByVal bExactPosition As Boolean = False)
#Else
    Public Sub GetFormPosition(ByRef frmForm As System.Windows.Forms.Form, Optional ByVal utm As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager = Nothing, Optional ByVal udm As Infragistics.Win.UltraWinDock.UltraDockManager = Nothing, Optional ByVal bExactPosition As Boolean = False)
#End If

        Dim iState As FormWindowState

        'If rSession.SystemSettingInteger("SuppressWindowMemory", True) <> 0 Then Exit Sub

        ' Function to load the position of a form
        ' What state was it saved in?
        iState = CType(Val(GetSetting("ADRIFT", "Runner", frmForm.Name & "_State", System.Windows.Forms.FormWindowState.Normal.ToString)), FormWindowState)
        Select Case iState
            Case System.Windows.Forms.FormWindowState.Normal ' It was normal or unspecified - so carry on

                Dim iTop As Integer = CInt(GetSetting("ADRIFT", "Runner", frmForm.Name & "_Top", frmForm.Top.ToString))
                Dim iLeft As Integer = CInt(GetSetting("ADRIFT", "Runner", frmForm.Name & "_Left", frmForm.Left.ToString))
                Dim iHeight As Integer = CInt(GetSetting("ADRIFT", "Runner", frmForm.Name & "_Height", frmForm.Height.ToString))
                Dim iWidth As Integer = CInt(GetSetting("ADRIFT", "Runner", frmForm.Name & "_Width", frmForm.Width.ToString))

                If bExactPosition Then frmForm.Location = New Point(iLeft, iTop)
                frmForm.Size = New Size(iWidth, iHeight)

            Case System.Windows.Forms.FormWindowState.Minimized ' It was minimised - so rest of data is rubbish

            Case System.Windows.Forms.FormWindowState.Maximized ' It was maximised - so maximise!
                frmForm.WindowState = System.Windows.Forms.FormWindowState.Maximized

            Case Else ' Err, shouldn't get here
                ErrMsg("GetFormPosition Error")
        End Select

#If Mono Then
        SetWindowStyle(frmForm)
#Else
        SetWindowStyle(frmForm, utm, udm)
#End If

    End Sub
#End If

    Friend Sub RunnerStartup()
        bShowShortLocations = CBool(GetSetting("ADRIFT", "Runner", "showshortroom", "-1"))
    End Sub
#End If
End Module