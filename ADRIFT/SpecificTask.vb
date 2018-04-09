Public Class SpecificTask

    Private tas As clsTask
    Private sGeneralKey As String
    Public Event Changed()



    Friend ReadOnly Property GetSpecifics As clsTask.Specific()
        Get
            If tas IsNot Nothing Then Return tas.Specifics Else Return Nothing
        End Get
    End Property


    Friend Sub LoadSpecific(ByVal sTaskGeneralKey As String, ByRef ParentTask As clsTask)

        Dim sBlocks() As String
        Dim iLength As Integer
        Dim bReference As Boolean
        Dim bLastBlock As Boolean
        Dim iNumSpecific As Integer = 0
        Dim sOrigBlock As String

        tas = ParentTask
        sGeneralKey = sTaskGeneralKey

        Dim sTaskText As String = Adventure.htblTasks(sGeneralKey).MakeNice

        With Me.txtSpecific
            .Text = ""

            sBlocks = Split(sTaskText, "%")

            For Each sBlock As String In sBlocks

                bReference = False
                sOrigBlock = sBlock

                Select Case sBlock.ToLower
                    Case "character", "character1", "character2", "character3", "character4", "character5", "characters", "direction", "direction1", "direction2", "direction3", "direction4", "direction5", "number", "number1", "number2", "number3", "number4", "number5", "numbers", "object", "object1", "object2", "object3", "object4", "object5", "objects", "text", "text1", "text2", "text3", "text4", "text5", "location", "location1", "location2", "location3", "location4", "location5", "item", "item1", "item2", "item3", "item4", "item5"
                        If sTaskText.Substring(iLength - 1, 1) = "%" AndAlso sTaskText.Substring(iLength + sBlock.Length, 1) = "%" Then
                            bReference = True
                            iNumSpecific += 1
                            If iNumSpecific > tas.Specifics.Length Then
                                ReDim Preserve tas.Specifics(iNumSpecific - 1)
                                tas.Specifics(iNumSpecific - 1) = New clsTask.Specific
                                tas.Specifics(iNumSpecific - 1).Keys.Add("")
                            End If
                            With tas.Specifics(iNumSpecific - 1)
                                Select Case sBlock.ToLower
                                    Case "character", "character1", "character2", "character3", "character4", "character5"
                                        .Type = ReferencesType.Character
                                        .Multiple = False
                                    Case "characters"
                                        .Type = ReferencesType.Character
                                        .Multiple = True
                                    Case "direction", "direction1", "direction2", "direction3", "direction4", "direction5"
                                        .Type = ReferencesType.Direction
                                        .Multiple = False
                                    Case "number", "number1", "number2", "number3", "number4", "number5"
                                        .Type = ReferencesType.Number
                                        .Multiple = False
                                    Case "numbers"
                                        .Type = ReferencesType.Number
                                        .Multiple = True
                                    Case "object", "object1", "object2", "object3", "object4", "object5"
                                        .Type = ReferencesType.Object
                                        .Multiple = False
                                    Case "objects"
                                        .Type = ReferencesType.Object
                                        .Multiple = True
                                    Case "text", "text1", "text2", "text3", "text4", "text5"
                                        .Type = ReferencesType.Text
                                        .Multiple = False
                                    Case "location", "location1", "location2", "location3", "location4", "location5"
                                        .Type = ReferencesType.Location
                                        .Multiple = False
                                    Case "item", "item1", "item2", "item3", "item4", "item5"
                                        .Type = ReferencesType.Item
                                        .Multiple = False
                                End Select

                                If Not .Keys Is Nothing AndAlso .Keys.Count > 0 Then
                                    sBlock = .List
                                    If sBlock = "" Then sBlock = sOrigBlock
                                    Select Case sBlock.ToLower
                                        Case "object1"
                                            sBlock = "first object"
                                        Case "object2"
                                            sBlock = "second object"
                                        Case "object3"
                                            sBlock = "third object"
                                        Case "object4"
                                            sBlock = "fourth object"
                                        Case "object5"
                                            sBlock = "fifth object"
                                        Case "character1"
                                            sBlock = "first character"
                                        Case "character2"
                                            sBlock = "second character"
                                        Case "character3"
                                            sBlock = "third character"
                                        Case "character4"
                                            sBlock = "fourth character"
                                        Case "character5"
                                            sBlock = "fifth character"
                                        Case "direction1"
                                            sBlock = "first direction"
                                        Case "direction1"
                                            sBlock = "second direction"
                                        Case "direction1"
                                            sBlock = "third direction"
                                        Case "direction1"
                                            sBlock = "fourth direction"
                                        Case "direction1"
                                            sBlock = "fifth direction"
                                        Case "number1"
                                            sBlock = "first number"
                                        Case "number2"
                                            sBlock = "second number"
                                        Case "number3"
                                            sBlock = "third number"
                                        Case "number4"
                                            sBlock = "fourth number"
                                        Case "number5"
                                            sBlock = "fifth number"
                                        Case "text1"
                                            sBlock = "first text"
                                        Case "text2"
                                            sBlock = "second text"
                                        Case "text3"
                                            sBlock = "third text"
                                        Case "text4"
                                            sBlock = "fourth text"
                                        Case "text5"
                                            sBlock = "fifth text"
                                        Case "item1"
                                            sBlock = "first item"
                                        Case "item2"
                                            sBlock = "second item"
                                        Case "item3"
                                            sBlock = "third item"
                                        Case "item4"
                                            sBlock = "fourth item"
                                        Case "item5"
                                            sBlock = "fifth item"
                                        Case "location1"
                                            sBlock = "first location"
                                        Case "location2"
                                            sBlock = "second location"
                                        Case "location3"
                                            sBlock = "third location"
                                        Case "location4"
                                            sBlock = "fourth location"
                                        Case "location5"
                                            sBlock = "fifth location"
                                    End Select
                                End If

                            End With
                        End If
                    Case Else
                End Select


                If bReference Then
                    'sBlock = "%" & sBlock & "%"
                    .SelectionFont = New Font(.SelectionFont, FontStyle.Underline)
                    .SelectionColor = Color.Blue
                Else
                    If Not bLastBlock AndAlso iLength > 0 Then sBlock = "%" & sBlock
                    .SelectionFont = New Font(.SelectionFont, FontStyle.Regular)
                    .SelectionColor = Color.Black
                End If

                If sBlock <> "" Then .SelectedText = sBlock
                .SelectionStart = .TextLength
                bLastBlock = bReference

                iLength += sOrigBlock.Length + 1

            Next

        End With

    End Sub



    Private Sub txtSpecific_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSpecific.GotFocus
        Me.BlueBorder.Focus()
    End Sub



    Private Sub txtSpecific_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecific.MouseDown

        Dim iCharPos As Integer = txtSpecific.GetCharIndexFromPosition(New Point(e.X, e.Y))
        Dim bLastPos As Boolean = False
        Dim bPos As Boolean = False
        Dim iSpecificCount As Integer = 0

        If iCharPos > -1 AndAlso e.X < txtSpecific.GetPositionFromCharIndex(txtSpecific.Text.Length).X Then
            txtSpecific.SelectionStart = iCharPos
            If txtSpecific.SelectionFont.Underline Then
                'txtSpecific.Cursor = Cursors.Hand            
                For iPos As Integer = 0 To iCharPos
                    txtSpecific.SelectionStart = iPos
                    bPos = txtSpecific.SelectionFont.Underline
                    If bPos AndAlso Not bLastPos Then
                        iSpecificCount += 1
                    End If
                    bLastPos = bPos
                Next
                tas.Specifics(iSpecificCount - 1).Keys = ChooseKey(iSpecificCount, txtSpecific.PointToScreen(New Point(e.X, e.Y)))
                LoadSpecific(sGeneralKey, tas)
                RaiseEvent Changed()
            End If
        End If

    End Sub



    Private Sub txtSpecific_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecific.MouseMove

        Dim iCharPos As Integer = txtSpecific.GetCharIndexFromPosition(New Point(e.X, e.Y))

        If iCharPos > -1 AndAlso e.X < txtSpecific.GetPositionFromCharIndex(txtSpecific.Text.Length).X Then
            txtSpecific.SelectionStart = iCharPos
            If txtSpecific.SelectionFont.Underline Then
                txtSpecific.Cursor = Cursors.Hand
            Else
                txtSpecific.Cursor = Cursors.Arrow
            End If
        Else
            txtSpecific.Cursor = Cursors.Arrow
        End If

    End Sub


    Private Function ChooseKey(ByVal iSpecific As Integer, ByVal P As Point) As StringArrayList

        Dim fPickKeys As New frmPickKeys(P, tas.Specifics(iSpecific - 1).Multiple)

        ChooseKey = Nothing

        With fPickKeys
            .Text = "Select "
            Select Case tas.Specifics(iSpecific - 1).Type
                Case ReferencesType.Object
                    .Text &= "Object"
                    AddLVI(fPickKeys, "[ Referenced Object ]", "")
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        AddLVI(fPickKeys, ob.FullName, ob.Key)
                    Next
                Case ReferencesType.Character
                    .Text &= "Character"
                    AddLVI(fPickKeys, "[ The Player Character ]", THEPLAYER)
                    AddLVI(fPickKeys, "[ Referenced Character ]", "")
                    For Each ch As clsCharacter In Adventure.htblCharacters.Values
                        AddLVI(fPickKeys, ch.Name, ch.Key)
                    Next
                Case ReferencesType.Location
                    .Text &= "Location"
                    AddLVI(fPickKeys, "[ Referenced Location ]", "")
                    For Each loc As clsLocation In Adventure.htblLocations.Values
                        AddLVI(fPickKeys, loc.ShortDescription.ToString, loc.Key)
                    Next
                Case ReferencesType.Direction
                    .Text &= "Direction"
                    AddLVI(fPickKeys, "[ Referenced Direction ]", "")
                    For Each eDir As DirectionsEnum In [Enum].GetValues(GetType(DirectionsEnum))
                        AddLVI(fPickKeys, DirectionName(eDir), eDir.ToString)
                    Next
                Case ReferencesType.Text
                    .Text &= "Text"
                    AddLVI(fPickKeys, "[ Referenced Text ]", "")
                    AddLVI(fPickKeys, "[ Specific Text ]", "SPECIFICTEXT")
                Case ReferencesType.Item
                    .Text &= "Item"
                    AddLVI(fPickKeys, "[ Referenced Item ]", "")
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        AddLVI(fPickKeys, ob.FullName, ob.Key)
                    Next
                    For Each ch As clsCharacter In Adventure.htblCharacters.Values
                        AddLVI(fPickKeys, ch.Name, ch.Key)
                    Next
                    For Each loc As clsLocation In Adventure.htblLocations.Values
                        AddLVI(fPickKeys, loc.ShortDescription.ToString, loc.Key)
                    Next
            End Select
            If tas.Specifics(iSpecific - 1).Multiple Then .Text &= "s"

            If tas.Specifics(iSpecific - 1).Type = ReferencesType.Text Then
                If tas.Specifics(iSpecific - 1).Keys IsNot Nothing AndAlso tas.Specifics(iSpecific - 1).Keys.Count = 1 Then
                    Dim sText As String = tas.Specifics(iSpecific - 1).Keys(0)
                    If sText = "" Then
                        SelectListItem(.lvwKeys, "")
                    Else
                        .lvwKeys.Items(1).SubItems(1).Text = sText
                        SelectListItem(.lvwKeys, sText)
                    End If
                End If
            Else
                If Not tas.Specifics(iSpecific - 1).Keys Is Nothing Then
                    For Each sKey As String In tas.Specifics(iSpecific - 1).Keys
                        SelectListItem(.lvwKeys, sKey)
                    Next
                Else
                    SelectListItem(.lvwKeys, "")
                End If
            End If

            .Show()
            While .Visible
                Application.DoEvents()
                Threading.Thread.Sleep(10)
            End While

            If .lvwKeys.SelectedItems.Count > 0 Then
                Dim sal As New StringArrayList

                For Each lvi As ListViewItem In .lvwKeys.SelectedItems
                    Dim sKey As String = lvi.SubItems(1).Text
                    If tas.Specifics(iSpecific - 1).Type = ReferencesType.Text AndAlso sKey <> "" Then
                        sKey = InputBox("Enter specific text:", "Specific text", IIf(sKey = "SPECIFICTEXT", "", sKey).ToString)
                    End If
                    sal.Add(sKey)
                Next
                Return sal
            End If

            .Dispose()

        End With

    End Function


    Private Sub SelectListItem(ByVal lvw As ListView, ByVal sKey As String)

        For Each lvi As ListViewItem In lvw.Items
            If lvi.SubItems(1).Text = sKey Then
                lvi.Selected = True
                Exit Sub
            End If
        Next

    End Sub


    Public Sub AddLVI(ByVal frm As frmPickKeys, ByVal sName As String, ByVal sKey As String)
        Dim lvi As New ListViewItem '(ob.FullName)
        lvi.SubItems(0).Text = sName
        lvi.SubItems.Add(sKey)
        frm.lvwKeys.Items.Add(lvi)
    End Sub

End Class

