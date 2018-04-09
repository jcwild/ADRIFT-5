Public Class OOTextbox
    Inherits Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor ' RichTextBox

    Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)

    Friend WithEvents lstIntellisense As New Infragistics.Win.UltraWinListView.UltraListView
    Friend WithEvents popupList As New Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents ToolTip1 As New System.Windows.Forms.ToolTip
    Private WithEvents cmsDrop As New System.Windows.Forms.ContextMenuStrip
    Friend fte As New Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor
    Friend Property Arguments As List(Of clsUserFunction.Argument)

    Dim bLoaded As Boolean = False


    Public Overloads Property BorderStyle As Infragistics.Win.UIElementBorderStyle
        Get
            Return MyBase.BorderStyle
        End Get
        Set(value As Infragistics.Win.UIElementBorderStyle)
            MyBase.BorderStyle = value
            If value = Infragistics.Win.UIElementBorderStyle.None Then MyBase.UseOsThemes = Infragistics.Win.DefaultableBoolean.False
        End Set
    End Property


    Private Sub OOTextbox_Layout(sender As Object, e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout

        If bLoaded Then Exit Sub
        bLoaded = True

        'Me.UseOsThemes = Infragistics.Win.DefaultableBoolean.True
        Me.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI ' Stops font changing slightly when we format it
        'Me.TextSmoothingMode = Infragistics.Win.FormattedLinkLabel.TextSmoothingMode.AntiAlias

        Dim UltraListViewSubItemColumn1 As Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn = New Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("Help")
        Dim UltraListViewSubItemColumn2 As Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn = New Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("Title")
        '
        'lstIntellisense
        '
        Me.lstIntellisense.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstIntellisense.ItemSettings.HideSelection = False
        Me.lstIntellisense.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.[Single]
        Me.lstIntellisense.Location = New System.Drawing.Point(148, 46)
        Me.lstIntellisense.MainColumn.AutoSizeMode = Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.AllItems
        Me.lstIntellisense.MainColumn.DataType = GetType(String)
        Me.lstIntellisense.MainColumn.Sorting = Infragistics.Win.UltraWinListView.Sorting.Ascending
        Me.lstIntellisense.Name = "lstIntellisense"
        Me.lstIntellisense.Size = New System.Drawing.Size(162, 254)
        UltraListViewSubItemColumn1.Key = "Help"
        UltraListViewSubItemColumn2.Key = "Title"
        Me.lstIntellisense.SubItemColumns.AddRange(New Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn() {UltraListViewSubItemColumn1, UltraListViewSubItemColumn2})
        Me.lstIntellisense.TabIndex = 3
        Me.lstIntellisense.Text = "UltraListView1"
        Me.lstIntellisense.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List
        Me.lstIntellisense.ViewSettingsDetails.AllowColumnMoving = False
        Me.lstIntellisense.ViewSettingsDetails.AllowColumnSorting = False
        Me.lstIntellisense.ViewSettingsDetails.ColumnAutoSizeMode = Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.VisibleItems
        Me.lstIntellisense.ViewSettingsDetails.FullRowSelect = True
        Me.lstIntellisense.ViewSettingsList.MultiColumn = False
        Me.lstIntellisense.Visible = False
        '
        'popupList
        '
        Me.popupList.PopupControl = Me.lstIntellisense

        'Me.AutoWordSelection = False

        fte.WrapText = False
        fte.TreatValueAs = Me.TreatValueAs
        'Dim p As Control = Me
        'While p.Parent IsNot Nothing
        '    p = p.Parent
        'End While
        fte.Parent = Me.Parent ' p
        fte.Location = Me.Location ' New Point(p.Width, 0) '-1000, -1000)
        fte.Size = Me.Size ' New Size(40, 40) ' Me.Size      
        fte.ReadOnly = True
        fte.TabStop = False        
        fte.UseOsThemes = Infragistics.Win.DefaultableBoolean.False
        fte.ScrollBarDisplayStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarDisplayStyle.Never
        fte.Appearance.BackColor = Color.FromArgb(160, 160, 160) ' Border colour
        fte.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        fte.BringToFront()

    End Sub


    Private Sub rtxtSource_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter

        For Each sFormat As String In e.Data.GetFormats
            Select Case sFormat
                Case "Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection"
                    With CType(e.Data.GetData("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection"), Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection)
                        If .Count = 1 Then
                            Select Case .Item(0).SubItems(2).Text
                                Case "Location", "Object", "Task", "Character", "Property", "Variable", "Event"
                                    e.Effect = DragDropEffects.Move Or DragDropEffects.Copy ' For some reason, doesn't work without Move on UFTE
                                Case Else
                                    e.Effect = DragDropEffects.None
                            End Select
                        Else
                            e.Effect = DragDropEffects.None
                        End If
                    End With

                Case "System.String"
                    If (e.KeyState And 8) = 8 Then 'OrElse iHighlightLength = 0 Then ' Ctrl key
                        e.Effect = DragDropEffects.Copy
                    Else
                        e.Effect = DragDropEffects.Move
                    End If

                Case "DeviceIndependentBitmap"
                    e.Effect = DragDropEffects.None
                    Exit For

                Case Else
                    'e.Effect = DragDropEffects.None
            End Select
        Next

        If e.Effect <> DragDropEffects.None Then Me.Focus()

    End Sub


    Private bDragLeave As Boolean = False
    Private Sub OOTextbox_DragLeave(sender As Object, e As System.EventArgs) Handles Me.DragLeave
        bDragLeave = True
        Debug.WriteLine("DragLeave")
        If iHighlightLength > 0 Then
            EditInfo.SelectionStart = iHighlightStart
            EditInfo.SelectionLength = iHighlightLength
        End If
    End Sub
    Private Sub OOTextbox_MouseLeave(sender As Object, e As System.EventArgs) Handles Me.MouseLeave
        Debug.WriteLine("MouseLeave")
        bDragLeave = False
    End Sub
    Private Sub OOTextbox_MouseEnterElement(sender As Object, e As Infragistics.Win.UIElementEventArgs) Handles Me.MouseEnterElement
        'Debug.WriteLine("MouseEnterElement " & e.Element.Control.Name & e.Element.ToString)
        'If bDragLeave Then
        '    mouse_event(&H4, 0, 0, 0, 1) ' Release the mouse (not sure why it gets stuck down) 
        '    bDragLeave = False
        'End If
    End Sub
    Private Sub OOTextbox_Enter(sender As Object, e As System.EventArgs) Handles Me.Enter
        Debug.WriteLine("Enter")
    End Sub
    Private WithEvents tmrReselect As New Timer
    Private Sub OOTextbox_MouseEnter(sender As Object, e As System.EventArgs) Handles Me.MouseEnter
        Debug.WriteLine("MouseEnter")
        If bDragLeave Then
            If MouseButtons = Windows.Forms.MouseButtons.None Then
                Debug.WriteLine("Unstick mouse")
                'Application.DoEvents()
                EditInfo.SelectionLength = iHighlightLength
                EditInfo.SelectionStart = iHighlightStart
                mouse_event(&H4, 0, 0, 0, 1) ' Release the mouse (not sure why it gets stuck down)             
                tmrReselect.Interval = 1
                tmrReselect.Enabled = True
            ElseIf MouseButtons = Windows.Forms.MouseButtons.Left Then
                tmrReselect.Interval = 1
                tmrReselect.Enabled = True
            End If
        End If
    End Sub
    Private Sub tmrReselect_Tick(sender As Object, e As System.EventArgs) Handles tmrReselect.Tick

        'mouse_event(&H4, 0, 0, 0, 1) ' Release the mouse (not sure why it gets stuck down) 
        If iHighlightLength > 0 AndAlso (EditInfo.SelectionStart <> iHighlightStart OrElse EditInfo.SelectionLength <> iHighlightLength) Then
            EditInfo.SelectionLength = iHighlightLength
            EditInfo.SelectionStart = iHighlightStart
            Focus()
        Else
            tmrReselect.Enabled = False
            bDragLeave = False
            ClearHighlight()
        End If

    End Sub

    Private Sub rtxtSource_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragOver

        Try
            If e.Data.GetDataPresent("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection") OrElse e.Data.GetDataPresent("System.String") Then

                ' Set cursor to where we're pointing
                Dim iY As Integer = e.Y - Me.PointToScreen(New Point(0, 0)).Y
                Dim iX As Integer = e.X - Me.PointToScreen(New Point(0, 0)).X
                Dim iNewIndex As Integer

                SelectionLength = 0
                iNewIndex = GetCharIndexFromPosition(New Point(iX, iY))

                Dim iTextLength As Integer = Text.Replace(vbCrLf, "@").Length 'Text.Length - Math.Max(fte.EditInfo.GetLineCount - 1, 0)
                If iY > GetPositionFromCharIndex(iTextLength).Y + 14 _
                    OrElse (iY > GetPositionFromCharIndex(iTextLength).Y AndAlso iX > GetPositionFromCharIndex(iTextLength).X) _
                    Then iNewIndex = Text.Length
                Debug.WriteLine("HERE")
                SelectionStart = iNewIndex
                'Application.DoEvents()

                If e.Data.GetDataPresent("System.String") Then
                    If iHighlightLength > 0 AndAlso iNewIndex >= iHighlightStart AndAlso iNewIndex <= iHighlightStart + iHighlightLength Then
                        e.Effect = DragDropEffects.None
                    Else
                        If (e.KeyState And 8) = 8 Then 'OrElse iHighlightLength = 0 Then ' Ctrl key
                            e.Effect = DragDropEffects.Copy
                        Else
                            e.Effect = DragDropEffects.Move
                        End If
                    End If
                End If

            End If
        Catch
            ErrMsg("DragOver error")
        End Try

    End Sub


    Private Sub rtxtSource_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop

        Try
            'If UltraSpellChecker1 Is Nothing Then InitSpellCheck()

            If e.Data.GetDataPresent("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection") Then
                With CType(e.Data.GetData("Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection"), Infragistics.Win.UltraWinListView.UltraListViewSelectedItemsCollection)

                    If .Count = 0 Then Exit Sub

                    .Item(0).Activate()

                    Application.DoEvents()

                    cmsDrop.Items.Clear()
                    cmsDrop.Tag = .Item(0).Key

                    Select Case .Item(0).SubItems(2).Text
                        Case "Location"
                            cmsDrop.Items.Add("Location Name", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Location Key", My.Resources.imgLocation16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Display Location", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Exits from Location", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Objects at Location", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                        Case "Object"
                            cmsDrop.Items.Add("Object Name", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Object Key", My.Resources.imgObjectDynamic16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Object Description", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("List objects On", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("List objects Inside", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("List objects On and Inside", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Parent of Object", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                        Case "Task"
                            cmsDrop.Items.Add("Task Key", My.Resources.imgTaskGeneral16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Task Completed", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                        Case "Character"
                            cmsDrop.Items.Add("Character Name", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Character Key", My.Resources.imgCharacter16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Character Description", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("List objects held by Character", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("List objects worn by Character", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            'cmsDrop.Items.Add("List objects worn and held by Character", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Location of Character", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Parent of Character", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                        Case "Property"
                            cmsDrop.Items.Add("Property Value", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Property Key", My.Resources.imgProperty16, AddressOf SelectedMenuItem)
                        Case "Variable"
                            cmsDrop.Items.Add("Variable Value", My.Resources.imgALR16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Variable Key", My.Resources.imgVariable16, AddressOf SelectedMenuItem)
                        Case "Event"
                            cmsDrop.Items.Add("Event Length", My.Resources.imgVariable16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Event Position", My.Resources.imgVariable16, AddressOf SelectedMenuItem)
                            cmsDrop.Items.Add("Event Key", My.Resources.imgEvent16, AddressOf SelectedMenuItem)
                    End Select
                    cmsDrop.Show(MousePosition)

                End With
            ElseIf e.Data.GetDataPresent("System.String") Then
                With SafeString(e.Data.GetData("System.String"))
                    iSelTextStart = EditInfo.SelectionStart

                    mouse_event(&H4, 0, 0, 0, 1) ' Release the mouse (not sure why it gets stuck down)                    


                    If iHighlightLength > 0 AndAlso iSelTextStart >= iHighlightStart AndAlso iSelTextStart <= iHighlightStart + iHighlightLength Then
                        ClearHighlight()
                        Exit Sub
                    End If

                    SelectedText = .ToString
                    iSelTextLength = .ToString.Length

                    If (e.Effect And DragDropEffects.Move) = DragDropEffects.Move Then
                        If iSelTextStart > iHighlightStart Then
                            iSelTextStart -= iHighlightLength
                        Else
                            iHighlightStart += iHighlightLength
                        End If
                        EditInfo.SelectionStart = iHighlightStart
                        EditInfo.SelectionLength = iHighlightLength
                        Try
                            EditInfo.Cut()
                        Catch
                            Try
                                Threading.Thread.Sleep(1)
                                EditInfo.Cut()
                            Catch
                                ' Give up
                            End Try
                        End Try
                    End If

                    tmrSelectText.Interval = 1
                    tmrSelectText.Start()
                End With
            End If

        Catch ex As Exception
            MessageBox.Show("Drop Error: " & ex.Message, "ADRIFT Developer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private WithEvents tmrSelectText As New Timer
    Private iSelTextStart As Integer
    Private iSelTextLength As Integer
    Private Sub tmrSelectText_Tick(sender As Object, e As System.EventArgs) Handles tmrSelectText.Tick
        tmrSelectText.Enabled = False
        EditInfo.SelectionStart = iSelTextStart
        EditInfo.SelectionLength = iSelTextLength
    End Sub

    Private Sub SelectedMenuItem(ByVal sender As Object, ByVal e As EventArgs)

        Dim mnu As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim sKey As String = mnu.Owner.Tag.ToString
        Dim sResult As String = ""

        Select Case CType(sender, ToolStripMenuItem).Text
            Case "Location Name", "Object Name", "Character Name"
                sResult = sKey & ".Name"
            Case "Location Key", "Object Key", "Task Key", "Character Key", "Property Key", "Variable Key", "Event Key"
                sResult = sKey
            Case "Display Location"
                sResult = sKey & ".Description"
            Case "Exits from Location"
                sResult = sKey & ".Exits.List"
            Case "Objects at Location"
                sResult = sKey & ".Objects.List" '(Indefinite)"
            Case "Object Description"
                sResult = sKey & ".Description"
            Case "List objects On"
                sResult = sKey & ".Children(On).List"
            Case "List objects Inside"
                sResult = sKey & ".Contents.List"
            Case "List objects On and Inside"
                sResult = sKey & ".Children.List"
            Case "Parent of Object", "Parent of Character"
                sResult = sKey & ".Parent"
            Case "Task Completed"
                sResult = "%TaskCompleted[" & sKey & "]%"
            Case "Character Description"
                sResult = sKey & ".Description"
            Case "List objects held by Character"
                sResult = sKey & ".Held.List" '(Indefinite)"
            Case "List objects worn by Character"
                sResult = sKey & ".Worn.List" '(Indefinite)"
                'Case "List objects worn and held by Character"
                '    sResult = sKey & ".WornAndHeld.List(Indefinite)"
            Case "Location of Character"
                sResult = sKey & ".Location"
            Case "Property Value"
                sResult = "<Item Key>." & sKey
            Case "Variable Value"
                Dim var As clsVariable = Nothing
                If Adventure.htblVariables.TryGetValue(sKey, var) Then
                    sResult = "%" & var.Name & If(var.Length > 1, "[]", "").ToString & "%"
                End If            
            Case "Event Length"
                sResult = sKey & ".Length"
            Case "Event Position"
                sResult = sKey & ".Position"
        End Select

        If sResult <> "" Then
            SelectedText = sResult
        End If

    End Sub


    ' E.g. Player.Held(False).Readable.Count => Player, Held, Readable, Count
    Private Function GetKeywords(ByRef htblArgs As Dictionary(Of Integer, String)) As StringArrayList

        Dim arlKeywords As New StringArrayList
        htblArgs = New Dictionary(Of Integer, String)

        Dim sKeyword As String = ""
        Dim sArgs As String = ""
        Dim iLevel As Integer = 0
        Dim i As Integer = SelectionStart - 1
        While Text.Substring(i, 1) <> "(" AndAlso Text.Substring(i, 1) <> "."
            i -= 1
            If i < 1 Then Return arlKeywords
        End While
        i -= 1

        While i >= 0
            Select Case Text.Substring(i, 1)
                Case "a" To "z", "A" To "Z", "0" To "9", "_", "-"
                    If iLevel = 0 Then sKeyword = Text.Substring(i, 1) & sKeyword Else sArgs = Text.Substring(i, 1) & sArgs
                Case " ", ","
                    If iLevel = 0 Then Exit While
                Case "("
                    iLevel += 1
                Case ")"
                    iLevel -= 1
                Case "%"
                    If iLevel = 0 Then sKeyword = Text.Substring(i, 1) & sKeyword Else sArgs = Text.Substring(i, 1) & sArgs
                    If sKeyword.Length > 1 Then Exit While
                Case "."
                    arlKeywords.Add(sKeyword)
                    If sArgs <> "" Then htblArgs.Add(arlKeywords.Count - 1, sArgs.ToLower)
                    sKeyword = ""
                    sArgs = ""
                Case Else
                    Exit While
            End Select
            i -= 1
        End While

        arlKeywords.Add(sKeyword)
        Return arlKeywords

    End Function


    Private Sub GetKeywordType(ByVal arlKeywords As StringArrayList, ByVal htblArgs As Dictionary(Of Integer, String), ByRef bObject As Boolean, ByRef bObjectList As Boolean, ByRef oObject As clsObject, ByRef bChar As Boolean, ByRef bCharacterList As Boolean, ByRef oCharacter As clsCharacter, ByRef bLoc As Boolean, ByRef oLocation As clsLocation, ByRef bExitList As Boolean, ByRef bEvt As Boolean, ByRef oEvent As clsEvent, ByRef bLocationList As Boolean, ByRef bSummable As Boolean, ByRef bItem As Boolean, ByRef bDirection As Boolean)

        If arlKeywords.Count = 0 Then Exit Sub
        Dim i As Integer = 0
        Dim sKeyword As String
Start:
        sKeyword = arlKeywords(i)

        If Arguments IsNot Nothing Then
            For Each arg As clsUserFunction.Argument In Arguments
                If sKeyword = "%" & arg.Name & "%" Then
                    Select Case arg.Type
                        Case clsUserFunction.ArgumentType.Character
                            bChar = True
                        Case clsUserFunction.ArgumentType.Location
                            bLoc = True
                        Case clsUserFunction.ArgumentType.Object
                            bObject = True
                    End Select
                End If
            Next
        End If

        Select Case sKeyword
            Case "%objects%", "%object%", "%object1%", "%object2%", "%object3%", "%object4%", "%object5%"
                bObject = True
                If sKeyword = "%objects%" Then bObjectList = True
            Case "%characters%", "%character%", "%character1%", "%character2%", "%character3%", "%character4%", "%character5%", "%Player%", "%ConvCharacter%", "%AloneWithChar%"
                bChar = True
                If sKeyword = "%characters%" Then bCharacterList = True
            Case "%location%", "%location1%", "%location2%", "%location3%", "%location4%", "%location5%"
                bLoc = True
            Case "%item%", "%item1%", "%item2%", "%item3%", "%item4%", "%item5%"
                bObject = True
                bChar = True
                bLoc = True
                bItem = True
            Case "Parent"
                ' Could be object or character
                bObject = True
                bChar = True
            Case "Characters"
                If i < arlKeywords.Count - 1 Then
                    bCharacterList = True
                End If
            Case "Contents"
                If i < arlKeywords.Count - 1 Then
                    Dim sArgs As String = ""
                    If htblArgs.ContainsKey(i) Then sArgs = htblArgs(i)
                    If sArgs = "" OrElse sArgs = "all" OrElse sArgs = "objects" Then bObjectList = True
                    If sArgs = "" OrElse sArgs = "all" OrElse sArgs = "characters" Then bCharacterList = True
                End If
            Case "Held", "Worn", "Objects", "WornAndHeld"
                If i < arlKeywords.Count - 1 Then
                    bObjectList = True
                    'bCharacterList = True
                End If
            Case "Children"
                If i < arlKeywords.Count - 1 Then
                    Dim sArgs As String = ""
                    If htblArgs.ContainsKey(i) Then sArgs = htblArgs(i)
                    If sArgs = "" OrElse sArgs = "all" OrElse sArgs = "in" OrElse sArgs = "on" OrElse sArgs.Contains("objects") Then bObjectList = True
                    If sArgs = "" OrElse sArgs = "all" OrElse sArgs = "in" OrElse sArgs = "on" OrElse sArgs.Contains("characters") Then bCharacterList = True
                End If
            Case "Exits"
                If i < arlKeywords.Count - 1 Then bExitList = True
            Case "Location"
                bLoc = True
            Case "LocationTo"
                bLoc = True
            Case "%direction%", "%direction1%", "%direction2%", "%direction3%", "%direction4%", "%direction5%"
                bDirection = True
            Case Else
                If Adventure.htblObjects.ContainsKey(sKeyword) Then
                    bObject = True
                    oObject = Adventure.htblObjects(sKeyword)
                ElseIf Adventure.htblCharacters.ContainsKey(sKeyword) Then
                    bChar = True
                    oCharacter = Adventure.htblCharacters(sKeyword)
                ElseIf Adventure.htblLocations.ContainsKey(sKeyword) Then
                    bLoc = True
                    oLocation = Adventure.htblLocations(sKeyword)
                ElseIf Adventure.htblAllProperties.ContainsKey(sKeyword) Then
                    Select Case Adventure.htblAllProperties(sKeyword).Type
                        Case clsProperty.PropertyTypeEnum.ObjectKey
                            bObject = True
                        Case clsProperty.PropertyTypeEnum.CharacterKey
                            bChar = True
                        Case clsProperty.PropertyTypeEnum.LocationKey
                            bLoc = True
                        Case clsProperty.PropertyTypeEnum.SelectionOnly, clsProperty.PropertyTypeEnum.StateList
                            ' Check previous word
                            If i < arlKeywords.Count - 1 Then
                                i += 1
                                GoTo Start
                            End If
                        Case clsProperty.PropertyTypeEnum.ValueList, clsProperty.PropertyTypeEnum.Integer
                            ' Check previous word
                            bSummable = True
                            If i < arlKeywords.Count - 1 Then
                                i += 1
                                GoTo Start
                            End If
                    End Select
                ElseIf Adventure.htblEvents.ContainsKey(sKeyword) Then
                    bEvt = True
                    oEvent = Adventure.htblEvents(sKeyword)
                ElseIf Adventure.htblGroups.ContainsKey(sKeyword) Then
                    Dim grp As clsGroup = Adventure.htblGroups(sKeyword)
                    Select Case grp.GroupType
                        Case clsGroup.GroupTypeEnum.Characters
                            bCharacterList = True
                        Case clsGroup.GroupTypeEnum.Locations
                            bLocationList = True
                        Case clsGroup.GroupTypeEnum.Objects
                            bObjectList = True
                    End Select
                ElseIf Arguments IsNot Nothing Then
                    For Each arg As clsUserFunction.Argument In Arguments
                        If "%" & arg.Name & "%" = sKeyword Then
                            Select Case arg.Type
                                Case clsUserFunction.ArgumentType.Object
                                    bObject = True
                                Case clsUserFunction.ArgumentType.Location
                                    bLoc = True
                                Case clsUserFunction.ArgumentType.Character
                                    bChar = True
                            End Select
                        End If
                    Next
                End If
                For Each d As DirectionsEnum In [Enum].GetValues(GetType(DirectionsEnum))
                    If sKeyword = d.ToString Then
                        bDirection = True
                        Exit For
                    End If
                Next
        End Select

    End Sub


    Private sIntellisenseWord As String = ""
    Private ptDropdown As Point

    Private Sub Intellisense()

        Try
            If bIntellisenseWorking Or DesignMode Then Exit Sub
            With lstIntellisense

                If .Visible AndAlso SelectionStart > 0 AndAlso (Text.Substring(SelectionStart - 1, 1) = "." OrElse Text.Substring(SelectionStart - 1, 1) = "(" OrElse Text.Substring(SelectionStart - 1, 1) = ")" OrElse Text.Substring(SelectionStart - 1, 1) = " ") Then
                    ' Case-correct anything
                    If .Items.Exists(sIntellisenseWord) Then
                        SelectIntellisense()
                    End If
                    popupList.Close()
                End If

                If .Visible Then

                    sIntellisenseWord = ""
                    Dim iEnd As Integer = SelectionStart
                    Dim iStart As Integer = iEnd
                    While iStart > 0
                        If Text(iStart - 1) = "."c OrElse Text(iStart - 1) = "(" OrElse Text(iStart - 1) = "," Then Exit While
                        iStart -= 1
                    End While
                    If iStart > -1 Then sIntellisenseWord = Text.Substring(iStart, iEnd - iStart)

                    Dim iVisibleCount As Integer = 0
                    Dim iWidth As Integer = 0
                    For i As Integer = .Items.Count - 1 To 0 Step -1
                        If Not .Items(i).Text.ToLower.Contains(sIntellisenseWord.ToLower) AndAlso Not .Items(i).Key.ToLower.Contains(sIntellisenseWord.ToLower) Then
                            .Items(i).Visible = False
                            If .SelectedItems.Contains(.Items(i)) Then .SelectedItems.Remove(.Items(i))
                        Else
                            iVisibleCount += 1
                            .Items(i).Visible = True
                        End If
                    Next

                    If .Items.Exists(sIntellisenseWord) Then
                        .SelectedItems.Clear()
                        .SelectedItems.Add(.Items(sIntellisenseWord))
                    End If

                    If .SelectedItems.Count = 0 Then
                        For Each vli As Infragistics.Win.UltraWinListView.UltraListViewItem In .Items
                            If vli.Visible Then
                                .SelectedItems.Add(vli)
                                Exit For
                            End If
                        Next
                    End If

                    If iVisibleCount > 0 Then
                        .MainColumn.PerformAutoResize(Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.AllItems)
                        Dim sizeDropdown As New Size(.MainColumn.Width + 5, Math.Min(iVisibleCount, 16) * 18 + 2)
                        If popupList.PreferredDropDownSize <> sizeDropdown Then
                            popupList.PopupControl.Size = sizeDropdown
                            popupList.PreferredDropDownSize = sizeDropdown
                            popupList.Show(Me, ptDropdown)
                            IntellisenseHelp()
                        End If
                        Exit Sub
                    End If
                    popupList.Close()
                End If

                .Items.Clear()


                If SelectionStart > 0 AndAlso (Text.Substring(SelectionStart - 1, 1) = "(" OrElse Text.Substring(SelectionStart - 1, 1) = ",") Then
                    ' Grab proceeding word
                    Dim i As Integer = SelectionStart - 1
                    While Text.Substring(i, 1) <> "("
                        i -= 1
                        If i < 1 Then GoTo SkipArgs
                    End While
                    i -= 1
                    'Dim iBracketLevel As Integer = 0
                    Dim sKeyword As String = ""
                    While i >= 0
                        Select Case Text.Substring(i, 1)
                            Case "a" To "z", "A" To "Z", "0" To "9", "_", "-"
                                sKeyword = Text.Substring(i, 1) & sKeyword
                            Case "%"
                                sKeyword = Text.Substring(i, 1) & sKeyword
                                If sKeyword.Length > 1 Then Exit While
                            Case Else
                                Exit While
                        End Select
                        i -= 1
                    End While

                    ' Functions that have arguments
                    Select Case sKeyword
                        Case "Children"
                            AddTool("All", "All", My.Resources.imgProperty16, "Everything In and On this object.  This is the default.")
                            AddTool("Characters, In", "Characters, In", My.Resources.imgProperty16, "All Characters inside this object")
                            AddTool("Characters, On", "Characters, On", My.Resources.imgProperty16, "All Characters on this object")
                            AddTool("Characters", "Characters", My.Resources.imgProperty16, "All Characters on and inside this object")
                            AddTool("In", "In", My.Resources.imgProperty16, "Everything inside this object")
                            AddTool("Objects, In", "Objects, In", My.Resources.imgProperty16, "All Objects inside this object")
                            AddTool("Objects, On", "Objects, On", My.Resources.imgProperty16, "All Objects on this object")
                            AddTool("Objects", "Objects", My.Resources.imgProperty16, "All Objects on and inside this object")

                        Case "Contents"
                            AddTool("All", "All", My.Resources.imgProperty16, "Everything Inside this object.  This is the default.")
                            AddTool("Characters", "Characters", My.Resources.imgProperty16, "All Characters inside this object")
                            AddTool("Objects", "Objects", My.Resources.imgProperty16, "All Objects inside this object")

                        Case "Held"
                            AddTool("True", "True", My.Resources.imgProperty16, "Returns held items recursively (i.e. objects inside held items).  This is the default.")
                            AddTool("False", "False", My.Resources.imgProperty16, "Does not return items recursively (i.e. only directly held items)")

                        Case "List"
                            Dim htblArgs As Dictionary(Of Integer, String) = Nothing
                            Dim arlKeywords As StringArrayList = GetKeywords(htblArgs)
                            arlKeywords.RemoveAt(0)
                            Dim bChar As Boolean = False
                            Dim bObject As Boolean = False
                            Dim bCharList As Boolean = False
                            Dim bObjectList As Boolean = False
                            Dim bLocationList As Boolean = False
                            GetKeywordType(arlKeywords, htblArgs, bObject, bObjectList, Nothing, bChar, bCharList, Nothing, False, Nothing, False, False, Nothing, bLocationList, Nothing, Nothing, Nothing)
                            If bObject OrElse bObjectList Then
                                AddTool("Definite", "Definite", My.Resources.imgProperty16, "Use the Definite article in names (e.g. *the* box).  This is the default.")
                                AddTool("Indefinite", "Indefinite", My.Resources.imgProperty16, "Use the Indefinite article in names (e.g. *a* box)")
                                AddTool("True", "True", My.Resources.imgProperty16, "List everything in/on every item in the list.  This is the default.")
                                AddTool("False", "False", My.Resources.imgProperty16, "Do not list anything in/on every item in the list.")
                            End If
                            AddTool("And", "And", My.Resources.imgProperty16, "Use ""and"" as the list separator.  This is the default.")
                            AddTool("Or", "Or", My.Resources.imgProperty16, "Use ""or"" as the list separator.")
                            AddTool("Rows", "Rows", My.Resources.imgProperty16, "Display each item in the list on a separate row.")

                        Case "LocationTo"
                            For Each d As DirectionsEnum In [Enum].GetValues(GetType(DirectionsEnum))
                                AddTool(DirectionName(d), d.ToString, My.Resources.imgChildren, "Returns the location " & DirectionName(d) & " from here.")
                            Next
                            AddTool("%direction%", "%direction%", My.Resources.imgChildren, "Returns the location in the Referenced Direction from here.")

                        Case "Name"
                            Dim htblArgs As Dictionary(Of Integer, String) = Nothing
                            Dim arlKeywords As StringArrayList = GetKeywords(htblArgs)
                            arlKeywords.RemoveAt(0)
                            Dim bChar As Boolean = False
                            Dim bObject As Boolean = False
                            GetKeywordType(arlKeywords, htblArgs, bObject, False, Nothing, bChar, False, Nothing, False, Nothing, False, False, Nothing, Nothing, Nothing, Nothing, Nothing)
                            If bChar Then
                                AddTool("None", "None", My.Resources.imgProperty16, "Do not replace with a pronoun at any time.", "Pronouns")
                                AddTool("Force", "Force", My.Resources.imgProperty16, "Enforce the use of pronouns.", "Pronouns")
                                AddTool("Objective", "Objective", My.Resources.imgProperty16, "Replace with the objective pronoun (me, you, him, her, it) when referred to multiple times.", "Pronouns")
                                AddTool("Possessive", "Possessive", My.Resources.imgProperty16, "Replace with the possessive pronoun (my, your, his, her, its) when referred to multiple times.", "Pronouns")
                                AddTool("Reflective", "Reflective", My.Resources.imgProperty16, "Replace with the reflective pronoun (myself, yourself, himself, herself, itself) when referred to multiple times.", "Pronouns")
                                AddTool("Subjective", "Subjective", My.Resources.imgProperty16, "Replace with the subjective pronoun (I, you, he, she, it) when referred to multiple times.  This is the default", "Pronouns")
                            End If
                            If bObject OrElse bChar Then
                                AddTool("Definite", "Definite", My.Resources.imgProperty16, "Use the Definite article in names (e.g. *the* " & IIf(bObject, "box", "man").ToString & IIf(bObject, ").  This is the default.", ").").ToString)
                                AddTool("Indefinite", "Indefinite", My.Resources.imgProperty16, "Use the Indefinite article in names (e.g. *a* " & IIf(bObject, "box", "man").ToString & IIf(bChar, ").", ").").ToString)
                                AddTool("None", "None", My.Resources.imgProperty16, "Suppress the article in names (e.g. just " & IIf(bObject, "box", "man").ToString & IIf(bChar, ").", ").").ToString)
                            End If

                        Case "Worn"
                            AddTool("True", "True", My.Resources.imgProperty16, "Returns worn items recursively (i.e. objects inside worn items).  This is the default.")
                            AddTool("False", "False", My.Resources.imgProperty16, "Does not return items recursively (i.e. only directly worn items)")

                        Case "WornAndHeld"
                            AddTool("True", "True", My.Resources.imgProperty16, "Returns held and worn items recursively (i.e. objects inside worn/held items).  This is the default.")
                            AddTool("False", "False", My.Resources.imgProperty16, "Does not return items recursively (i.e. only directly worn or held items)")

                        Case Else
                            If Adventure.htblAllProperties.ContainsKey(sKeyword) Then
                                Dim prop As clsProperty = Adventure.htblAllProperties(sKeyword)
                                Select Case prop.Type
                                    Case clsProperty.PropertyTypeEnum.ValueList
                                        For Each val As String In prop.ValueList.Keys
                                            AddTool(val, val, My.Resources.imgVariable16, "")
                                        Next
                                    Case clsProperty.PropertyTypeEnum.StateList
                                        For Each state As String In prop.arlStates
                                            AddTool(state, state, My.Resources.imgALR16, "")
                                        Next
                                End Select
                            End If
                    End Select

                    If .Items.Count > 0 Then
                        ptDropdown = PointToScreen(GetPositionFromCharIndex(EditInfo.SelectionStart))
                        ptDropdown.Y += 18

                        .MainColumn.PerformAutoResize(Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.AllItems)
                        Dim sizeDropdown As New Size(.MainColumn.Width + 5, Math.Min(.Items.Count, 16) * 18 + 2)
                        popupList.PopupControl.Size = sizeDropdown
                        popupList.PreferredDropDownSize = sizeDropdown
                        popupList.Show(Me, ptDropdown)

                        If lstIntellisense.SelectedItems.Count = 0 Then lstIntellisense.SelectedItems.Add(lstIntellisense.Items(0))
                        IntellisenseHelp()
                        Exit Sub
                    End If
                End If
SkipArgs:

                sIntellisenseWord = ""
                If SelectionStart > 0 AndAlso Text.Substring(SelectionStart - 1, 1) = "." Then

                    Dim htblArgs As Dictionary(Of Integer, String) = Nothing
                    Dim arlKeywords As StringArrayList = GetKeywords(htblArgs)
                    Dim sKeyword As String = ""
                    If arlKeywords.Count > 0 Then sKeyword = arlKeywords(arlKeywords.Count - 1)

                    Debug.WriteLine(sKeyword)
                    Dim bSubKeyword As Boolean = arlKeywords.Count > 1 ' (i > 0 AndAlso Text.Substring(i, 1) = ".") OrElse sPreviousKeyword <> ""
                    Dim bObject As Boolean = False
                    Dim bChar As Boolean = False
                    Dim bLoc As Boolean = False
                    Dim bEvt As Boolean = False
                    Dim oObject As clsObject = Nothing
                    Dim oCharacter As clsCharacter = Nothing
                    Dim oLocation As clsLocation = Nothing
                    Dim oEvent As clsEvent = Nothing
                    Dim bObjectList As Boolean = False
                    Dim bCharacterList As Boolean = False
                    Dim bLocationList As Boolean = False
                    Dim bExitList As Boolean = False
                    Dim bSummable As Boolean = False
                    Dim bItem As Boolean = False
                    Dim bDirection As Boolean = False

                    GetKeywordType(arlKeywords, htblArgs, bObject, bObjectList, oObject, bChar, bCharacterList, oCharacter, bLoc, oLocation, bExitList, bEvt, oEvent, bLocationList, bSummable, bItem, bDirection)

                    If bObjectList OrElse bCharacterList OrElse bExitList OrElse bLocationList Then
                        AddTool("List", "List", My.Resources.imgALR16, "This returns a comma separated list" & vbCrLf & "The List function can take various parameter to control how the list outputs.  Multiple parameters can be supplied.", "List")
                        AddTool("Count", "Count", My.Resources.imgVariable16, "This returns an integer value of the number of items in the list")
                    End If

                    If bSummable Then
                        AddTool("Sum", "Sum", My.Resources.imgVariable16, "This returns an integer value of the sum of the value of the items in the list")
                    End If

                    If bObjectList Then
                        For Each p As clsProperty In Adventure.htblObjectProperties.Values
                            Select Case p.Type
                                Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList, clsProperty.PropertyTypeEnum.StateList, clsProperty.PropertyTypeEnum.SelectionOnly
                                    AddTool(p.CommonName, p.Key, My.Resources.imgFilter, GetPropertyHelp(p, True))
                            End Select
                        Next
                    End If

                    If bObject Then
                        Dim sObject As String = If(bItem, "item", "object").ToString
                        AddTool(PCase(sObject) & " Name", "Name", My.Resources.imgALR16, "This returns the full " & sObject & " name")
                        AddTool("Description", "Description", My.Resources.imgALR16, "This returns the description of the " & sObject)
                        AddTool("Article", "Article", My.Resources.imgALR16, "The indefinite article of the " & sObject)
                        AddTool("Adjective", "Adjective", My.Resources.imgALR16, "The adjective (prefix) of the " & sObject)
                        AddTool("Noun", "Noun", My.Resources.imgALR16, "The primary noun of the " & sObject)
                        AddTool("Contents", "Contents", My.Resources.imgGroup16, "This returns a list of all objects/characters inside the " & sObject, "Contents([Objects/Characters])")
                        AddTool("Children", "Children", My.Resources.imgGroup16, "This returns a list of all objects/characters in/on the " & sObject, "Children([Objects/Characters], [In/On/OnAndIn])")
                        AddTool("Location", "Location", My.Resources.imgLocation16, "This returns the location of the " & sObject & ", regardless whether the object is in/on something else")
                        AddTool("Parent", "Parent", My.Resources.imgObjectDynamic16, "This returns the parent object/character/location of the " & sObject)
                        For Each p As clsProperty In Adventure.htblObjectProperties.Values
                            Dim img As Image = My.Resources.imgProperty16
                            Select Case p.Type
                                Case clsProperty.PropertyTypeEnum.CharacterKey
                                    img = My.Resources.imgCharacter16
                                Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                                    img = My.Resources.imgVariable16
                                Case clsProperty.PropertyTypeEnum.LocationGroupKey
                                    img = My.Resources.imgGroup16
                                Case clsProperty.PropertyTypeEnum.LocationKey
                                    img = My.Resources.imgLocation16
                                Case clsProperty.PropertyTypeEnum.ObjectKey
                                    img = My.Resources.imgObjectDynamic16
                                Case clsProperty.PropertyTypeEnum.Text, clsProperty.PropertyTypeEnum.StateList
                                    img = My.Resources.imgALR16
                                Case clsProperty.PropertyTypeEnum.SelectionOnly
                                    If bObjectList Then
                                        img = My.Resources.imgFilter
                                    Else
                                        img = My.Resources.imgVariable16
                                    End If
                            End Select
                            'If p.Type <> clsProperty.PropertyTypeEnum.SelectionOnly Then
                            If oObject Is Nothing OrElse oObject.HasProperty(p.Key) Then AddTool(p.CommonName, p.Key, img, GetPropertyHelp(p))
                            'End If
                        Next
                    End If

                    If bCharacterList Then
                        For Each p As clsProperty In Adventure.htblCharacterProperties.Values
                            Select Case p.Type
                                Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList, clsProperty.PropertyTypeEnum.StateList, clsProperty.PropertyTypeEnum.SelectionOnly
                                    AddTool(p.CommonName, p.Key, My.Resources.imgFilter, GetPropertyHelp(p, True))
                            End Select
                        Next
                    End If

                    If bChar Then
                        AddTool("Proper Name", "ProperName", My.Resources.imgALR16, "This returns the Proper name of the character")
                        AddTool("Descriptor", "Descriptor", My.Resources.imgALR16, "This returns the descriptor of the character")
                        AddTool("Character Name", "Name", My.Resources.imgALR16, "This returns the proper name (if known) otherwise the descriptor, of the character.  This function can take parameters to specify the pronoun substitution.") ' Proper or Descriptor
                        AddTool("Description", "Description", My.Resources.imgALR16, "This returns the description of the character")
                        AddTool("Held", "Held", My.Resources.imgGroup16, "This returns a list of everything held by the character" & vbCrLf & "The Held function can take a Boolean parameter to specify whether the list should recursively list objects inside or on other objects.  The default is True.")
                        AddTool("Location", "Location", My.Resources.imgLocation16, "This returns the location of the character, regardless whether the character is in/on something else")
                        AddTool("Worn", "Worn", My.Resources.imgGroup16, "This returns a list of everything worn by the character" & vbCrLf & "The Worn function can take a Boolean parameter to specify whether the list should recursively list objects inside or on other objects.  The default is True.")
                        AddTool("WornAndHeld", "WornAndHeld", My.Resources.imgGroup16, "This returns a list of everything worn and held by the character" & vbCrLf & "The WornAndHeld function can take a Boolean parameter to specify whether the list should recursively list objects inside or on other objects.  The default is True.")
                        AddTool("Parent", "Parent", My.Resources.imgObjectStatic16, "This returns the parent object/character/location of the character")                        
                        For Each p As clsProperty In Adventure.htblCharacterProperties.Values
                            Dim img As Image = My.Resources.imgProperty16
                            Select Case p.Type
                                Case clsProperty.PropertyTypeEnum.CharacterKey
                                    img = My.Resources.imgCharacter16
                                Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                                    img = My.Resources.imgVariable16
                                Case clsProperty.PropertyTypeEnum.LocationGroupKey
                                    img = My.Resources.imgGroup16
                                Case clsProperty.PropertyTypeEnum.LocationKey
                                    img = My.Resources.imgLocation16
                                Case clsProperty.PropertyTypeEnum.ObjectKey
                                    img = My.Resources.imgObjectDynamic16
                                Case clsProperty.PropertyTypeEnum.Text, clsProperty.PropertyTypeEnum.StateList
                                    img = My.Resources.imgALR16
                                Case clsProperty.PropertyTypeEnum.SelectionOnly
                                    If bCharacterList Then
                                        img = My.Resources.imgFilter
                                    Else
                                        img = My.Resources.imgVariable16
                                    End If
                            End Select
                            'If p.Type <> clsProperty.PropertyTypeEnum.SelectionOnly Then
                            If oCharacter Is Nothing OrElse oCharacter.HasProperty(p.Key) Then AddTool(p.CommonName, p.Key, img, GetPropertyHelp(p))
                            'End If
                        Next
                    End If

                    If bLocationList Then
                        For Each p As clsProperty In Adventure.htblLocationProperties.Values
                            Select Case p.Type
                                Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList, clsProperty.PropertyTypeEnum.StateList, clsProperty.PropertyTypeEnum.SelectionOnly
                                    AddTool(p.CommonName, p.Key, My.Resources.imgFilter, GetPropertyHelp(p, True))
                            End Select
                        Next
                    End If

                    If bLoc Then
                        AddTool("Short Description", "Name", My.Resources.imgALR16, "This returns the short description of the location")
                        AddTool("Long Description", "Description", My.Resources.imgALR16, "This returns the long description of the location")
                        AddTool("LocationTo", "LocationTo", My.Resources.imgLocation16, "This returns a location relative to this one.  Requires direction parameter.")
                        AddTool("Objects", "Objects", My.Resources.imgGroup16, "This returns a list of the objects in the location")
                        AddTool("Characters", "Characters", My.Resources.imgGroup16, "This returns a list of the characters at the location")
                        AddTool("Exits", "Exits", My.Resources.imgGroup16, "This returns a list of the exits in the location")                        
                        For Each p As clsProperty In Adventure.htblLocationProperties.Values
                            Dim img As Image = My.Resources.imgProperty16
                            Select Case p.Type
                                Case clsProperty.PropertyTypeEnum.CharacterKey
                                    img = My.Resources.imgCharacter16
                                Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                                    img = My.Resources.imgVariable16
                                Case clsProperty.PropertyTypeEnum.LocationGroupKey
                                    img = My.Resources.imgGroup16
                                Case clsProperty.PropertyTypeEnum.LocationKey
                                    img = My.Resources.imgLocation16
                                Case clsProperty.PropertyTypeEnum.ObjectKey
                                    img = My.Resources.imgObjectDynamic16
                                Case clsProperty.PropertyTypeEnum.Text, clsProperty.PropertyTypeEnum.StateList
                                    img = My.Resources.imgALR16
                                Case clsProperty.PropertyTypeEnum.SelectionOnly
                                    If bLocationList Then
                                        img = My.Resources.imgFilter
                                    Else
                                        img = My.Resources.imgVariable16
                                    End If
                            End Select
                            'If p.Type <> clsProperty.PropertyTypeEnum.SelectionOnly Then
                            If p.Key <> "LongLocationDescription" AndAlso p.Key <> "ShortLocationDescription" Then ' Duplicates with our shorthand versions
                                If oLocation Is Nothing OrElse oLocation.HasProperty(p.Key) Then AddTool(p.CommonName, p.Key, img, GetPropertyHelp(p))
                            End If
                        Next
                    End If

                    If bEvt Then
                        AddTool("Length", "Length", My.Resources.imgVariable16, "This returns the number of turns the event will run for")
                        AddTool("Position", "Position", My.Resources.imgVariable16, "This returns the current position within the event")
                    End If

                    If bDirection Then
                        AddTool("Name", "Name", My.Resources.imgALR16, "This returns the custom name for this direction")
                    End If

                    If .Items.Count > 0 Then
                        ptDropdown = PointToScreen(GetPositionFromCharIndex(EditInfo.SelectionStart)) ' SelectionStart))
                        ptDropdown.Y += 18

                        .MainColumn.PerformAutoResize(Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.AllItems)
                        Dim sizeDropdown As New Size(.MainColumn.Width + 5, Math.Min(.Items.Count, 16) * 18 + 2)
                        popupList.PopupControl.Size = sizeDropdown
                        popupList.PreferredDropDownSize = sizeDropdown
                        popupList.Show(Me, ptDropdown)
                        IntellisenseHelp()
                    End If

                Else
                    If sIntellisenseWord = "" Then popupList.Close()
                End If
            End With

        Catch ex As Exception
            ErrMsg("Error building intellisense menu", ex)
        End Try

    End Sub


    Private Sub OOTextbox_TextChanged(sender As Object, e As System.EventArgs) Handles Me.TextChanged
        If bHighlighting Then Exit Sub
        fte.Text = Text
        Intellisense()
    End Sub


    Private Sub AddTool(ByVal sName As String, ByVal sKey As String, ByVal img As Image, ByVal sHelp As String, Optional ByVal sTitle As String = "")

        If Not lstIntellisense.Items.Exists(sKey) Then
            Dim lvi As New Infragistics.Win.UltraWinListView.UltraListViewItem(sName, New Object() {sHelp, sTitle})
            lvi.Key = sKey
            lvi.Appearance.Image = img

            lstIntellisense.Items.Add(lvi)
        End If

    End Sub


    Private Function GetPropertyHelp(ByVal p As clsProperty, Optional ByVal bFilter As Boolean = False) As String

        Dim sHelp As String = ""

        If bFilter OrElse p.Type = clsProperty.PropertyTypeEnum.SelectionOnly Then
            sHelp = "This will restrict the "
            If Adventure.htblObjectProperties.ContainsKey(p.Key) Then
                sHelp &= "object"
            ElseIf Adventure.htblCharacterProperties.ContainsKey(p.Key) Then
                sHelp &= "character"
            ElseIf Adventure.htblLocationProperties.ContainsKey(p.Key) Then
                sHelp &= "location"
            End If
            sHelp &= " list to those containing this property"
        Else
            If Adventure.htblObjectProperties.ContainsKey(p.Key) Then
                sHelp = "This is an object property"
            ElseIf Adventure.htblCharacterProperties.ContainsKey(p.Key) Then
                sHelp = "This is a character property"
            ElseIf Adventure.htblLocationProperties.ContainsKey(p.Key) Then
                sHelp = "This is a location property"
            End If
            sHelp &= " that will return "
            Select Case p.Type
                Case clsProperty.PropertyTypeEnum.CharacterKey
                    sHelp &= "the key of a character"
                Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                    sHelp &= "an integer value"
                Case clsProperty.PropertyTypeEnum.LocationGroupKey
                    sHelp &= "the key of a location group"
                Case clsProperty.PropertyTypeEnum.LocationKey
                    sHelp &= "the key of a location"
                Case clsProperty.PropertyTypeEnum.ObjectKey
                    sHelp &= "the key of an object"
                Case clsProperty.PropertyTypeEnum.StateList, clsProperty.PropertyTypeEnum.Text
                    sHelp &= "a text value"
            End Select
        End If

        Return sHelp

    End Function


    Private Sub OOTextbox_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown
        If lstIntellisense.Visible Then
            Select Case e.KeyData
                Case Keys.Tab, Keys.Space
                    If lstIntellisense.SelectedItems.Count = 1 Then
                        e.IsInputKey = True
                        SelectIntellisense()
                    End If
                Case Keys.Escape
                    If lstIntellisense.Visible Then e.IsInputKey = True              
            End Select
        End If        
    End Sub


    Private Sub OOTextbox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyData
            Case Keys.Escape
                If lstIntellisense.Visible Then
                    popupList.Close()
                    e.SuppressKeyPress = True
                End If
            Case Keys.Down
                If lstIntellisense.Visible Then
                    If lstIntellisense.SelectedItems.Count = 1 Then
                        lstIntellisense.PerformAction(Infragistics.Win.UltraWinListView.UltraListViewAction.ActivateBelow)
                    Else
                        lstIntellisense.PerformAction(Infragistics.Win.UltraWinListView.UltraListViewAction.ActivateFirst)
                    End If
                    e.SuppressKeyPress = True
                End If
            Case Keys.Up
                If lstIntellisense.Visible Then
                    lstIntellisense.PerformAction(Infragistics.Win.UltraWinListView.UltraListViewAction.ActivateAbove)
                    e.SuppressKeyPress = True
                End If
            Case Keys.Enter
                If lstIntellisense.Visible Then
                    SelectIntellisense()
                    e.SuppressKeyPress = True
                End If
                If Not Multiline Then e.SuppressKeyPress = True
            Case Keys.PageDown
                If lstIntellisense.Visible Then
                    lstIntellisense.PerformAction(Infragistics.Win.UltraWinListView.UltraListViewAction.PageDown)
                    e.SuppressKeyPress = True
                End If
            Case Keys.PageUp
                If lstIntellisense.Visible Then
                    lstIntellisense.PerformAction(Infragistics.Win.UltraWinListView.UltraListViewAction.PageUp)
                    e.SuppressKeyPress = True
                End If
            Case Keys.Tab
                e.SuppressKeyPress = True
                e.Handled = True
            Case Keys.Control Or Keys.Z
                Undo() ' VB bug: http://support.microsoft.com/default.aspx?scid=kb;en-us;812943
            Case Keys.Shift Or Keys.Alt Or Keys.Back
                Redo()
        End Select
    End Sub


    Private bIntellisenseWorking As Boolean = False
    Private Sub SelectIntellisense()
        If lstIntellisense.SelectedItems.Count = 1 Then
            Debug.WriteLine("Selected " & lstIntellisense.SelectedItems(0).Key)
            Dim iSelStart As Integer = SelectionStart
            If iSelStart >= sIntellisenseWord.Length AndAlso Text.Substring(iSelStart - sIntellisenseWord.Length, sIntellisenseWord.Length) = sIntellisenseWord Then
                bIntellisenseWorking = True
                Text = Text.Substring(0, iSelStart - sIntellisenseWord.Length) & lstIntellisense.SelectedItems(0).Key & Text.Substring(iSelStart)
                bIntellisenseWorking = False
                SelectionLength = 0
                SelectionStart = iSelStart - sIntellisenseWord.Length + lstIntellisense.SelectedItems(0).Key.Length
                If Text.Substring(SelectionStart - lstIntellisense.SelectedItems(0).Key.Length - 1, 1) = "(" Then
                    iSelStart = SelectionStart
                    Text = Text.Substring(0, SelectionStart) & ")" & Text.Substring(SelectionStart)
                    SelectionStart = iSelStart + 1
                End If
                sIntellisenseWord = ""
            ElseIf iSelStart >= sIntellisenseWord.Length - 1 AndAlso Text.Substring(iSelStart - sIntellisenseWord.Length - 1, sIntellisenseWord.Length) = sIntellisenseWord Then
                bIntellisenseWorking = True
                Text = Text.Substring(0, iSelStart - sIntellisenseWord.Length - 1) & lstIntellisense.SelectedItems(0).Key & Text.Substring(iSelStart - 1)
                bIntellisenseWorking = False
                SelectionLength = 0
                SelectionStart = iSelStart - sIntellisenseWord.Length + lstIntellisense.SelectedItems(0).Key.Length
                sIntellisenseWord = ""
            End If
            bIntellisenseWorking = True
            popupList.Close()
            bIntellisenseWorking = False
        End If

    End Sub


    Private iToolTipLeft As Integer
    Private Sub IntellisenseHelp()

        If lstIntellisense.SelectedItems.Count = 1 Then
            Dim oItem As clsItem = Nothing
            Adventure.dictAllItems.TryGetValue(lstIntellisense.SelectedItems(0).Key, oItem)

            With ToolTip1
                Dim sHelp As String = lstIntellisense.SelectedItems(0).SubItems(0).Text
                Dim sTitle As String = lstIntellisense.SelectedItems(0).SubItems(1).Text
                If sTitle = "" Then
                    sTitle = lstIntellisense.SelectedItems(0).Text
                    If lstIntellisense.SelectedItems(0).Text <> lstIntellisense.SelectedItems(0).Key Then sTitle &= " (" & lstIntellisense.SelectedItems(0).Key & ")"
                End If
                .ToolTipTitle = sTitle
                iToolTipLeft = ptDropdown.X + lstIntellisense.Width '- 1
                Dim iToolTipTop As Integer = ptDropdown.Y

                If Screen.FromControl(Me).WorkingArea.Width - iToolTipLeft < 300 Then
                    iToolTipLeft = ptDropdown.X
                    iToolTipTop = ptDropdown.Y + lstIntellisense.Height '- 1
                End If
                .Show(sHelp, Me, PointToClient(New Point(iToolTipLeft, iToolTipTop)))

            End With
        End If

    End Sub


    Private Sub ToolTip1_Popup(sender As Object, e As System.Windows.Forms.PopupEventArgs) Handles ToolTip1.Popup
        If Screen.FromControl(Me).WorkingArea.Width - e.ToolTipSize.Width < iToolTipLeft Then
            ' Ok, the tooltip has been moved to fit onto the screen
            iToolTipLeft = ptDropdown.X
            ToolTip1.Show(lstIntellisense.SelectedItems(0).SubItems(0).Text, Me, PointToClient(New Point(iToolTipLeft, ptDropdown.Y + lstIntellisense.Height)))
        End If
    End Sub


    Private Sub lstIntellisense_ItemSelectionChanged(sender As Object, e As Infragistics.Win.UltraWinListView.ItemSelectionChangedEventArgs) Handles lstIntellisense.ItemSelectionChanged
        IntellisenseHelp()
    End Sub


    Private Sub lstIntellisense_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstIntellisense.MouseClick
        SelectIntellisense()
    End Sub


    Private Sub popupList_Closed(sender As Object, e As System.EventArgs) Handles popupList.Closed
        ToolTip1.Hide(Me)
    End Sub








    ' Need to convert SelectionStart counting vbCrLf as 1 into count vbCrLf as 2...
    Dim iSelectionStart As Integer = -1
    Public Property SelectionStart As Integer
        Get
            'If fte.Text <> Text Then fte.Text = Text  
            If DesignMode Then Return -1
            'Debug.WriteLine("Get: " & Math.Min(EditInfo.SelectionStart + Math.Max(fte.EditInfo.GetLineNumber(EditInfo.SelectionStart) - 1, 0), Text.Length))
            Return Math.Min(EditInfo.SelectionStart + Math.Max(fte.EditInfo.GetLineNumber(EditInfo.SelectionStart) - 1, 0), Text.Length)
            'Debug.WriteLine("Get: " & EditInfo.SelectionStart)
            'Return EditInfo.SelectionStart
            'If iSelectionStart > -1 Then Return iSelectionStart

            'Dim iSS As Integer = EditInfo.SelectionStart
            'If iSS >= Text.Length Then Return Text.Length '- 1
            'Dim x As Integer = New System.Text.RegularExpressions.Regex(vbCrLf).Matches(Text.Substring(0, iSS)).Count
            'Dim iPos As Integer = iSS '+ x '0
            'iSS += x
            'While iPos < iSS AndAlso iPos < Text.Length
            '    If Text(iPos) = vbCr Then iSS += 1
            '    iPos += 1
            'End While
            'iSelectionStart = iSS
            'Return iSS ' EditInfo.SelectionStart
        End Get
        Set(value As Integer)
            If DesignMode Then Exit Property
            'Debug.WriteLine("Set: " & value)
            Dim iNewValue As Integer = value - Math.Max(fte.EditInfo.GetLineNumber(EditInfo.SelectionStart) - 1, 0)
            EditInfo.SelectionStart = iNewValue
            iPreviousSelectionStart = iNewValue
        End Set
    End Property
    Public Property SelectionLength As Integer
        Get
            If EditInfo Is Nothing Then Return 0
            Return EditInfo.SelectionLength
        End Get
        Set(value As Integer)
            If EditInfo IsNot Nothing Then EditInfo.SelectionLength = value
        End Set
    End Property


    Public Property Multiline As Boolean
        Get
            Return MyBase.WrapText
        End Get
        Set(value As Boolean)            
            MyBase.WrapText = value
        End Set
    End Property
   
    <Obsolete("No longer required")> _
    Public Property AutoWordSelection As Boolean

    Public Property DetectUrls As Boolean
    Public Property SelectedText As String
        Get
            If EditInfo Is Nothing Then Return Nothing
            Return EditInfo.GetSelectedValueAsString(False)
        End Get
        Set(value As String)
            Try
                If value <> "" Then EditInfo.InsertValue(value.Replace("<", "&lt;").Replace(">", "&gt;"))
            Catch
            End Try
        End Set
    End Property
    Public Property EnableAutoDragDrop As Boolean

    Public Shadows Property WrapText As Boolean
        Get
            Return MyBase.WrapText
        End Get
        Set(value As Boolean)
            MyBase.WrapText = value
            If Not value Then
                MyBase.ScrollBarDisplayStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarDisplayStyle.Never
            End If
        End Set
    End Property
    Public ReadOnly Property GetCharIndexFromPosition(ByVal pt As Point) As Integer
        Get
            Return EditInfo.GetCaretPositionFromMouseLocation(pt)
        End Get
    End Property
    Public ReadOnly Property GetPositionFromCharIndex(ByVal pos As Integer) As Point
        Get
            Return EditInfo.GetCaretLocation(pos).Location
        End Get
    End Property
    Public ReadOnly Property TextLength As Integer
        Get            
            Return MyBase.Text.Length
        End Get
    End Property
    Public Sub Undo()
        EditInfo.PerformAction(Infragistics.Win.FormattedLinkLabel.FormattedLinkEditorAction.Undo)
    End Sub
    Public Sub Redo()
        EditInfo.PerformAction(Infragistics.Win.FormattedLinkLabel.FormattedLinkEditorAction.Redo)
    End Sub


    Private Sub OOTextbox_EditStateChanged(sender As Object, e As Infragistics.Win.FormattedLinkLabel.EditStateChangedEventArgs) Handles Me.EditStateChanged
        'Debug.WriteLine(Now.ToString & " EditStateChanged " & EditInfo.SelectionStart & ", " & EditInfo.SelectionLength)

        If bResetPrevious OrElse EditInfo.SelectionLength > 0 Then
            iPreviousSelectionLength = EditInfo.SelectionLength
            iPreviousSelectionStart = EditInfo.SelectionStart
            bResetPrevious = False
        End If
        If EditInfo.SelectionLength = 0 Then
            bResetPrevious = True
        End If

    End Sub

    Private bResetPrevious As Boolean = False
    Private Property _iPreviousSelectionLength As Integer = 0
    Private Property iPreviousSelectionLength As Integer
        Get
            Return _iPreviousSelectionLength
        End Get
        Set(value As Integer)
            If value > 0 Then
                value = value
            End If
            _iPreviousSelectionLength = value
        End Set
    End Property
    Private Property iPreviousSelectionStart As Integer = 0
    Private iHighlightStart As Integer = 0
    Private iHighlightLength As Integer = 0
    Private bHighlighting As Boolean = False
    Private bAllowDragDrop As Boolean = False
    Private Sub OOTextbox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Debug.WriteLine("Down: SelectionLength: " & SelectionLength & ", SelectionStart: " & SelectionStart)
        bAllowDragDrop = False
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso iPreviousSelectionLength > 0 Then ' SelectionLength > 0 Then
            Dim iMousePosition As Integer = EditInfo.GetCaretPositionFromMouseLocation(e.Location)

            If iMousePosition >= iPreviousSelectionStart AndAlso iMousePosition <= iPreviousSelectionStart + iPreviousSelectionLength Then

                'If iPreviousSelectionLength > 2000 Then iPreviousSelectionLength = 50 ' Without this we hang on the ApplyStyle line :-(

                Dim iCursor As Integer = EditInfo.SelectionStart
                Dim gtb As GenTextbox = ParentGenTextBox()

                iHighlightStart = iPreviousSelectionStart
                iHighlightLength = iPreviousSelectionLength

                bHighlighting = True
                fte.ReadOnly = False
                fte.TreatValueAs = Infragistics.Win.FormattedLinkLabel.TreatValueAs.FormattedText
                Dim sOldValue As String = Me.Value.ToString
                fte.Value = Me.Value
                fte.EditInfo.SelectionStart = iPreviousSelectionStart
                fte.EditInfo.SelectionLength = iPreviousSelectionLength                

                'fte.BringToFront()
                'fte.Location = Me.Location
                'fte.Size = Me.Size
                'Application.DoEvents()

                fte.EditInfo.ApplyStyle("Background-color:#" & Hex(SystemColors.Highlight.ToArgb) & ";color:#" & Hex(SystemColors.HighlightText.ToArgb) & ";", False)
                'fte.EditInfo.ApplyStyle("Background-color:#FF0000;color:#" & Hex(SystemColors.HighlightText.ToArgb) & ";", False)
                If gtb IsNot Nothing Then gtb.bTextChanging = True
                If Value.ToString <> fte.Value.ToString Then Value = fte.Value
                If gtb IsNot Nothing Then
                    Dim iLen As Integer = Text.Length
                    gtb.FormatTextbox()
                    If Text.Length <> iLen Then Value = sOldValue
                    gtb.bTextChanging = False
                End If
                'fte.EditInfo.ApplyStyle("Background-color:#" & Hex(SystemColors.Highlight.ToArgb) & ";color:#" & Hex(SystemColors.HighlightText.ToArgb) & ";", False)
                fte.ReadOnly = True
                bHighlighting = False
                bAllowDragDrop = True
                iPreviousSelectionStart = 0
                iPreviousSelectionLength = 0
            End If
        End If

    End Sub

    Private Function ParentGenTextBox() As GenTextbox

        Dim gtb As Control = Nothing

        gtb = Me
        While gtb.Parent IsNot Nothing
            gtb = gtb.Parent
            If TypeOf gtb Is GenTextbox Then Return CType(gtb, GenTextbox)
        End While

        Return Nothing

    End Function


    Private Sub OOTextbox_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Debug.WriteLine("Click: SelectionLength: " & SelectionLength & ", SelectionStart: " & SelectionStart)
    End Sub


    Private Sub OOTextbox_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

        If bAllowDragDrop AndAlso e.Button = Windows.Forms.MouseButtons.Left AndAlso iHighlightLength > 0 Then
            Dim iMousePosition As Integer = EditInfo.GetCaretPositionFromMouseLocation(e.Location)
            bAllowDragDrop = False

            If iMousePosition >= iHighlightStart AndAlso iMousePosition <= iHighlightStart + iHighlightLength AndAlso Text.Length >= iHighlightStart + iHighlightLength Then
                DoDragDrop(Text.Replace(vbCrLf, vbCr).Substring(iHighlightStart, iHighlightLength), DragDropEffects.Move Or DragDropEffects.Copy)
            End If
        End If

    End Sub


    Private Sub OOTextbox_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If iHighlightLength > 0 AndAlso Not bDragLeave Then ClearHighlight()
    End Sub


    Private Sub ClearHighlight()
        iHighlightStart = 0
        iHighlightLength = 0
        Dim gtb As GenTextbox = ParentGenTextBox()
        If gtb IsNot Nothing Then gtb.bTextChanging = True
        fte.Text = Text
        If gtb IsNot Nothing Then
            gtb.FormatTextbox()
            gtb.bTextChanging = False
        End If
    End Sub


    ' Ensure fte is visible (so selection etc works), yet not actually visible
    Private Sub OOTextbox_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        fte.Location = New Point(Me.Location.X + Me.Size.Width - 3000, Me.Location.Y + Me.Size.Height - 3000)
    End Sub

End Class
