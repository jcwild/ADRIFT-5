Public Class frmEvent

    Public bKeepOpen As Boolean = False

    Public Sub New(ByRef lEvent As clsEvent, ByVal bShow As Boolean)

        ' Check that this window isn't already open
        For Each w As Form In OpenForms
            If TypeOf w Is frmEvent Then
                If CType(w, frmEvent).cEvent.Key = lEvent.Key Then
                    w.BringToFront()
                    w.Focus()
                    Exit Sub
                End If
            End If
        Next

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Application.EnableVisualStyles()
        LoadForm(lEvent, bShow)
        bKeepOpen = Not bShow

    End Sub


    Private cEvent As clsEvent
    Private bChanged As Boolean
    Private WithEvents tmrButtons As New Timer
    Private LastSelectedSubEvent As SubEventGUI
    Private LastSelectedControl As EventControl
    Private TempSubEvents() As clsEvent.SubEvent
    Private TempControls() As EventOrWalkControl


    Public Property Changed() As Boolean
        Get
            Return bChanged
        End Get
        Set(ByVal Value As Boolean)
            bChanged = Value
            If bChanged Then
                btnApply.Enabled = True
            Else
                btnApply.Enabled = False
            End If
        End Set
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ApplyEvent()
        CloseEvent(Me)
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ApplyEvent()
        Changed = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then ApplyEvent()
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        CloseEvent(Me)
    End Sub


    Private Sub ApplyEvent()

        With cEvent
            .EventType = CType(optEventType.Value, clsEvent.EventTypeEnum)
            .Description = txtName.Text
            .Repeating = chkRepeat.Checked
            .RepeatCountdown = chkRepeatCountdown.Checked
            .Length.iFrom = x2yHowLong.From
            .Length.iTo = x2yHowLong.To

            Select Case optStart.CheckedIndex
                Case 0
                    .WhenStart = clsEvent.WhenStartEnum.AfterATask
                Case 1
                    .WhenStart = clsEvent.WhenStartEnum.BetweenXandYTurns
                    .StartDelay.iFrom = x2yStartWait.From
                    .StartDelay.iTo = x2yStartWait.To
                Case 2
                    .WhenStart = clsEvent.WhenStartEnum.Immediately
            End Select

            .SubEvents = TempSubEvents
            .EventControls = TempControls
            .LastUpdated = Now
            .IsLibrary = False

            If .Description = "" Then .Description = "Unnamed Event"

            If .Key = "" Then
                .Key = .GetNewKey ' Adventure.GetNewKey("Event")
                Adventure.htblEvents.Add(cEvent, .Key)
            End If

            UpdateListItem(.Key, .Description)
        End With

        Adventure.Changed = True

    End Sub


    Private Sub LoadForm(ByRef cEvent As clsEvent, ByVal bShow As Boolean)

        Me.cEvent = cEvent
        ReDim TempSubEvents(cEvent.SubEvents.Length - 1)
        For i As Integer = 0 To cEvent.SubEvents.Length - 1
            TempSubEvents(i) = cEvent.SubEvents(i).CloneMe
        Next
        ReDim TempControls(cEvent.EventControls.Length - 1)
        For i As Integer = 0 To cEvent.EventControls.Length - 1
            TempControls(i) = cEvent.EventControls(i).CloneMe
        Next



        With cEvent
            Text = "Event - " & .Description
            If SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0")) Then Text &= "  [" & .Key & "]"
            If .Description = "" Then Text = "New Event"

            optEventType.Value = CInt(.EventType)
            txtName.Text = .Description
            chkRepeat.Checked = .Repeating
            chkRepeatCountdown.Checked = .RepeatCountdown
            x2yHowLong.SetValues(.Length.iFrom, .Length.iTo)
            Select Case .WhenStart
                Case clsEvent.WhenStartEnum.AfterATask
                    optStart.CheckedIndex = 0
                Case clsEvent.WhenStartEnum.BetweenXandYTurns
                    optStart.CheckedIndex = 1
                    x2yStartWait.SetValues(.StartDelay.iFrom, .StartDelay.iTo)
                Case clsEvent.WhenStartEnum.Immediately
                    optStart.CheckedIndex = 2
            End Select

            For Each ec As EventOrWalkControl In TempControls ' .EventControls
                AddEventControl(ec)
            Next
            For Each se As clsEvent.SubEvent In TempSubEvents
                AddSubEvent(se)
            Next

        End With

        If bShow Then Me.Show()
        Changed = False

        OpenForms.Add(Me)

    End Sub


    Private Sub StuffChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged, optStart.ValueChanged
        Changed = True
    End Sub

    Private Sub frmEvent_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OpenForms.Remove(Me)
    End Sub

    Private Sub frmEvent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Icon = Icon.FromHandle(My.Resources.imgEvent16.GetHicon)
        GetFormPosition(Me)
    End Sub

    Private Sub optStart_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optStart.ValueChanged
        If optStart.CheckedIndex = 1 Then
            x2yStartWait.Enabled = True
            chkRepeatCountdown.Enabled = chkRepeat.Checked
        Else
            x2yStartWait.Enabled = False
            chkRepeatCountdown.Enabled = False
            chkRepeatCountdown.Checked = False
        End If

        Changed = True

    End Sub


    Private Sub btnAddControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddControl.Click
        AddEventControl()
    End Sub


    Private Sub AddEventControl(Optional ByVal cec As EventOrWalkControl = Nothing)

        Dim bAdding As Boolean = (cec Is Nothing)
        Dim ec As New EventControl
        ec.Parent = pnlTaskControlInner
        pnlTaskControlInner.Height = pnlTaskControlInner.Controls.Count * ec.Height
        ec.Left = 0
        ec.Top = (pnlTaskControlInner.Controls.Count - 1) * ec.Height
        ec.Width = pnlTaskControlInner.Width
        ec.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right

        If Not bAdding Then
            ec.LoadEventControl(cec)
        Else
            ReDim Preserve TempControls(TempControls.Length)
            TempControls(TempControls.Length - 1) = ec.cec
        End If

        Changed = True

    End Sub


    Private Sub btnAddSubEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSubEvent.Click
        AddSubEvent()
    End Sub


    Public Sub DoControlButtons()
        tmrButtons.Interval = 201 ' This gap needs to be enough to allow the click event on the Remove button to fire before we disable it
        tmrButtons.Enabled = True
    End Sub

    Private Sub ControlButtons()

        tmrButtons.Enabled = False

        Dim bRemoveControl As Boolean = False
        'Dim bUp As Boolean = False
        'Dim bDown As Boolean = False

        LastSelectedControl = Nothing
        For Each ctrl As EventControl In pnlTaskControlInner.Controls
            If ctrl.Focused Then
                'If Not sev Is pnlSubEventsInner.Controls(0) Then bUp = True
                'If Not sev Is pnlSubEventsInner.Controls(pnlSubEventsInner.Controls.Count - 1) Then bDown = True
                LastSelectedControl = ctrl
                bRemoveControl = True
            End If
        Next

        btnRemoveControl.Enabled = bRemoveControl
        'btnUp.Enabled = bUp
        'btnDown.Enabled = bDown

    End Sub


    Public Sub DoSubEventButtons()
        tmrButtons.Interval = 200 ' This gap needs to be enough to allow the click event on the Remove button to fire before we disable it
        tmrButtons.Enabled = True
    End Sub


    Private Sub SubEventButtons()

        tmrButtons.Enabled = False

        Dim bRemoveSubEvent As Boolean = False
        Dim bUp As Boolean = False
        Dim bDown As Boolean = False

        LastSelectedSubEvent = Nothing
        For Each sev As SubEventGUI In pnlSubEventsInner.Controls
            If sev.Focused Then
                If Not sev Is pnlSubEventsInner.Controls(0) Then bUp = True
                If Not sev Is pnlSubEventsInner.Controls(pnlSubEventsInner.Controls.Count - 1) Then bDown = True
                LastSelectedSubEvent = sev
                bRemoveSubEvent = True
            End If
        Next

        btnRemoveSubEvent.Enabled = bRemoveSubEvent
        btnUp.Enabled = bUp
        btnDown.Enabled = bDown

    End Sub


    Private Sub AddSubEvent(Optional ByVal cse As clsEvent.SubEvent = Nothing)

        Dim bAdding As Boolean = (cse Is Nothing)
        Dim iTop As Integer
        For Each sev As SubEventGUI In pnlSubEventsInner.Controls
            iTop += sev.Height
        Next

        Dim se As New SubEventGUI
        If CInt(optEventType.Value) = 0 Then
            se.cmbTurnsSeconds.Value = "Turns"
        Else
            se.cmbTurnsSeconds.Value = "Seconds"
        End If
        If pnlSubEventsInner.Controls.Count = 0 Then se.cmbFromStart.Value = "FromStart"
        se.Parent = pnlSubEventsInner
        pnlSubEventsInner.Height = iTop + se.Height
        se.Left = 0
        se.Top = iTop
        se.Width = pnlSubEventsInner.Width
        se.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        AddHandler se.ValueChanged, AddressOf Me.CheckEventLength

        ' Default location dropdown to same as all the rest, if the same
        Dim sKey As String = ""
        For Each ose As clsEvent.SubEvent In TempSubEvents
            If sKey = "" Then
                sKey = ose.sKey
            Else
                If sKey <> ose.sKey Then
                    sKey = "***"
                End If
            End If
        Next
        If sKey <> "" AndAlso sKey <> "***" Then
            se.cse.sKey = sKey
            se.isLocationGroup.Key = sKey
        End If

        'If Not cse Is Nothing Then se.LoadSubEvent(cse)
        'ReDim Preserve TempSubEvents(TempSubEvents.Length)
        'cse = se.cse
        'TempSubEvents(TempSubEvents.Length - 1) = cse
        If Not bAdding Then
            se.LoadSubEvent(cse)
        Else
            ReDim Preserve TempSubEvents(TempSubEvents.Length)
            TempSubEvents(TempSubEvents.Length - 1) = se.cse
        End If

        Changed = True

    End Sub


    Private Sub RemoveSubEvent(ByVal se As SubEventGUI)

        Dim bShuffle As Boolean = False

        RemoveHandler se.ValueChanged, AddressOf CheckEventLength

        For i As Integer = 0 To TempSubEvents.Length - 1
            If TempSubEvents(i) Is se.cse Then
                pnlSubEventsInner.Controls.RemoveAt(i)
                se.cse = Nothing
                bShuffle = True
            End If
            If bShuffle AndAlso i < TempSubEvents.Length - 1 Then TempSubEvents(i) = TempSubEvents(i + 1)
        Next
        'pnlSubEventsInner.Controls.Remove(se)
        ReDim Preserve TempSubEvents(TempSubEvents.Length - 2)
        RedrawSubEvents()

        Changed = True

    End Sub


    Private Sub RemoveControl(ByVal ctrl As EventControl)

        Dim bShuffle As Boolean = False

        For i As Integer = 0 To TempControls.Length - 1
            If TempControls(i) Is ctrl.cec Then
                pnlTaskControlInner.Controls.RemoveAt(i)
                ctrl.cec = Nothing
                bShuffle = True
            End If
            If bShuffle AndAlso i < TempControls.Length - 1 Then TempControls(i) = TempControls(i + 1)
        Next
        'pnlSubEventsInner.Controls.Remove(se)
        ReDim Preserve TempControls(TempControls.Length - 2)
        RedrawControls()

        Changed = True

    End Sub


    Public Sub RedrawSubEvents()

        'For Each se As SubEvent In pnlSubEventsInner.Controls
        Dim iHeight As Integer = 0
        If pnlSubEventsInner.Controls.Count > 0 Then
            pnlSubEventsInner.Controls(0).Top = 0
            iHeight = pnlSubEventsInner.Controls(0).Height
        End If

        For iSE As Integer = 1 To pnlSubEventsInner.Controls.Count - 1
            iHeight += pnlSubEventsInner.Controls(iSE).Height
            pnlSubEventsInner.Controls(iSE).Top = pnlSubEventsInner.Controls(iSE - 1).Top + pnlSubEventsInner.Controls(iSE - 1).Height
        Next
        pnlSubEventsInner.Height = iHeight
        SubEventButtons()

    End Sub


    Public Sub RedrawControls()

        'For Each se As SubEvent In pnlSubEventsInner.Controls
        Dim iHeight As Integer = 0
        If pnlTaskControlInner.Controls.Count > 0 Then
            pnlTaskControlInner.Controls(0).Top = 0
            iHeight = pnlTaskControlInner.Controls(0).Height
        End If

        For iSE As Integer = 1 To pnlTaskControlInner.Controls.Count - 1
            iHeight += pnlTaskControlInner.Controls(iSE).Height
            pnlTaskControlInner.Controls(iSE).Top = pnlTaskControlInner.Controls(iSE - 1).Top + pnlTaskControlInner.Controls(iSE - 1).Height
        Next
        pnlTaskControlInner.Height = iHeight
        ControlButtons()

    End Sub


    Private Sub MoveUpDown(ByVal bIsUp As Boolean)

        Dim se As clsEvent.SubEvent = LastSelectedSubEvent.cse
        Dim seSwap As clsEvent.SubEvent
        Dim iIndex As Integer

        For i As Integer = 0 To TempSubEvents.Length - 1
            If TempSubEvents(i) Is LastSelectedSubEvent.cse Then
                iIndex = i
                Exit For
            End If
        Next

        If bIsUp Then
            seSwap = TempSubEvents(iIndex - 1)
            LastSelectedSubEvent.LoadSubEvent(seSwap)
            CType(pnlSubEventsInner.Controls(iIndex - 1), SubEventGUI).LoadSubEvent(se)
            CType(pnlSubEventsInner.Controls(iIndex - 1), SubEventGUI).Focus()
        Else
            seSwap = TempSubEvents(iIndex + 1)
            LastSelectedSubEvent.LoadSubEvent(seSwap)
            CType(pnlSubEventsInner.Controls(iIndex + 1), SubEventGUI).LoadSubEvent(se)
            CType(pnlSubEventsInner.Controls(iIndex + 1), SubEventGUI).Focus()
        End If

        TempSubEvents(iIndex) = seSwap
        TempSubEvents(CInt(IIf(bIsUp, iIndex - 1, iIndex + 1))) = se

        RedrawSubEvents()


    End Sub


    Private Sub btnRemoveSubEvent_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRemoveSubEvent.MouseDown
        If Not LastSelectedSubEvent Is Nothing Then RemoveSubEvent(LastSelectedSubEvent)
    End Sub


    Private Sub btnUpDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUp.MouseDown, btnDown.MouseDown
        If Not LastSelectedSubEvent Is Nothing Then MoveUpDown(sender Is btnUp)
    End Sub

    Private Sub tmrButtons_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrButtons.Tick
        If tmrButtons.Interval = 200 Then
            SubEventButtons()
        Else
            ControlButtons()
        End If
    End Sub


    Private Sub btnRemoveControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveControl.MouseDown
        If Not LastSelectedControl Is Nothing Then RemoveControl(LastSelectedControl)
    End Sub

    Private Sub frmEvent_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown    
        If txtName.Text = "" Then
            txtName.Focus()
        Else
            ' Dunno...
        End If
    End Sub

    Private Sub chkRepeat_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkRepeat.CheckedChanged

        If optStart.CheckedIndex = 1 Then        
            chkRepeatCountdown.Enabled = chkRepeat.Checked
            If Not chkRepeatCountdown.Enabled Then chkRepeatCountdown.Checked = False
        Else            
            chkRepeatCountdown.Enabled = False
            chkRepeatCountdown.Checked = False
        End If
    End Sub

    Private Sub frmEvent_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        ShowHelp(Me, "Events")
    End Sub


    Private Sub optEventType_ValueChanged(sender As Object, e As EventArgs) Handles optEventType.ValueChanged

        Select Case CType(optEventType.Value, clsEvent.EventTypeEnum)
            Case clsEvent.EventTypeEnum.TurnBased
                Me.Icon = Icon.FromHandle(My.Resources.imgEvent16.GetHicon)
                lblTurns.Text = "turns"
                lblTurns2.Text = "turns"
            Case clsEvent.EventTypeEnum.TimeBased
                Me.Icon = Icon.FromHandle(My.Resources.imgTimeEvent16.GetHicon)
                lblTurns.Text = "seconds"
                lblTurns2.Text = "seconds"
        End Select

        For Each se As SubEventGUI In pnlSubEventsInner.Controls
            se.SortDropdowns()
        Next

        Changed = True

    End Sub


    Private Sub CheckEventLength(ByVal o As Object, ByVal e As EventArgs)

        Dim iLength As Integer = 0
        Dim iPrev As Integer = 0

        For Each se As SubEventGUI In pnlSubEventsInner.Controls
            Select Case SafeString(se.cmbFromStart.SelectedItem.DataValue)
                Case "FromStart"
                    iPrev = se.XtoYturns1.To
                    iLength = Math.Max(iLength, iPrev)                    
                Case "FromLast"
                    iPrev += se.XtoYturns1.To
                    iLength = Math.Max(iLength, iPrev)
                Case "BeforeEnd"
                    ' ignore
            End Select
        Next

        If x2yHowLong.To < iLength AndAlso iLength > 0 Then
            x2yHowLong.To = iLength
            If x2yHowLong.txtFrom.Width > x2yHowLong.txtTo.Width Then x2yHowLong.From = iLength
        End If

    End Sub

    Private Sub StuffChanged() Handles x2yHowLong.ValueChanged, x2yStartWait.ValueChanged, chkRepeat.CheckedChanged, chkRepeatCountdown.CheckedChanged
        Changed = True
    End Sub

End Class