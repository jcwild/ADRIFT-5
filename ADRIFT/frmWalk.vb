Public Class frmWalk

    Public Sub New(ByRef lWalk As clsWalk)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Application.EnableVisualStyles()
        LoadForm(lWalk)

    End Sub


    Private cWalk As clsWalk
    Private bChanged As Boolean
    Private WithEvents tmrButtons As New Timer
    Private LastSelectedSubWalk As SubWalk
    Private LastSelectedControl As EventControl
    Private TempSubWalks() As clsWalk.SubWalk
    Private TempControls() As EventOrWalkControl


    Public Property Changed() As Boolean
        Get
            Return bChanged
        End Get
        Set(ByVal Value As Boolean)
            bChanged = Value
            'If bChanged Then
            '    btnApply.Enabled = True
            'Else
            '    btnApply.Enabled = False
            'End If
        End Set
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ApplyWalk()
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    'Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ApplyWalk()
    '    Changed = False
    'End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes to this walk?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then ApplyWalk()
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub


    Private Sub ApplyWalk()

        With cWalk
            .Description = txtDescription.Text
            .SubWalks = TempSubWalks
            .WalkControls = TempControls

            .arlSteps.Clear()
            For Each lvi As ListViewItem In lvwSteps.Items
                .arlSteps.Add(GetStepInfo(lvi))
            Next

            If .Description = "" Then .Description = .GetDefaultDescription
            .Loops = chkRepeat.Checked
            .StartActive = (optStart.CheckedIndex = 1)

            '        If .Key = "" Then
            '            .Key = Adventure.GetNewKey("Walk")
            '            Adventure.htblEvents.Add(cEvent, .Key)
            '        End If

            'UpdateListItem(.Key, .Description)
        End With

    End Sub


    Private Sub LoadForm(ByRef cWalk As clsWalk)

        Me.cWalk = cWalk        
        ReDim TempSubWalks(cWalk.SubWalks.Length - 1)
        For i As Integer = 0 To cWalk.SubWalks.Length - 1
            TempSubWalks(i) = cWalk.SubWalks(i).CloneMe
        Next
        ReDim TempControls(cWalk.WalkControls.Length - 1)
        For i As Integer = 0 To cWalk.WalkControls.Length - 1
            TempControls(i) = cWalk.WalkControls(i).CloneMe
        Next

        With cWalk
            '    Text = "Event - " & .Description            
            '    If CBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "False")) Then Text &= "  [" & .Key & "]"
            If .Description = "" Then Text = "New Walk" Else Text = "Edit Walk"

            txtDescription.Text = .Description
            chkRepeat.Checked = .Loops
            If .StartActive Then optStart.CheckedIndex = 1 Else optStart.CheckedIndex = 0

            '    x2yHowLong.SetValues(.Length.iFrom, .Length.iTo)
            '    Select Case .WhenStart
            '        Case clsEvent.WhenStartEnum.AfterATask
            '            optStart.CheckedIndex = 0
            '        Case clsEvent.WhenStartEnum.BetweenXandXTurns
            '            optStart.CheckedIndex = 1
            '            x2yStartWait.SetValues(.StartDelay.iFrom, .StartDelay.iTo)
            '        Case clsEvent.WhenStartEnum.Immediately
            '            optStart.CheckedIndex = 2
            '    End Select

            For Each wc As EventOrWalkControl In TempControls
                AddWalkControl(wc)
            Next
            For Each sw As clsWalk.SubWalk In TempSubWalks
                AddSubWalk(sw)
            Next
            For Each stp As clsWalk.clsStep In .arlSteps
                Dim sDestination As String = ""
                Select Case stp.sLocation
                    Case "Hidden"
                        sDestination = "Hidden"
                        'Case "FollowPlayer"
                        '    sDestination = "Follow Player"
                    Case Else
                        If Adventure.htblCharacters.ContainsKey(stp.sLocation) Then sDestination = "Follow "
                        sDestination &= Adventure.GetNameFromKey(stp.sLocation)
                End Select
                Dim lvi As ListViewItem = lvwSteps.Items.Add(sDestination)
                'lvi.SubItems.Add(stp.iWaitTurns.ToString)
                If stp.ftTurns.iFrom = stp.ftTurns.iTo Then
                    lvi.SubItems.Add(stp.ftTurns.iFrom.ToString)
                Else
                    lvi.SubItems.Add(stp.ftTurns.iFrom.ToString & " - " & stp.ftTurns.iTo.ToString)
                End If
                lvi.SubItems.Add(stp.sLocation)
            Next

        End With

        Changed = False
        Me.ShowDialog()

    End Sub


    Private Sub StuffChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged, optStart.ValueChanged
        Changed = True
    End Sub

    Private Sub frmEvent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetFormPosition(Me)
    End Sub



    Private Sub btnAddControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddControl.Click
        AddWalkControl()
    End Sub


    Private Sub AddWalkControl(Optional ByVal cwc As EventOrWalkControl = Nothing)

        Dim bAdding As Boolean = (cwc Is Nothing)
        Dim wc As New EventControl
        wc.Parent = pnlTaskControlInner
        wc.UltraLabel1.Text = "this walk on"
        pnlTaskControlInner.Height = pnlTaskControlInner.Controls.Count * wc.Height
        wc.Left = 0
        wc.Top = (pnlTaskControlInner.Controls.Count - 1) * wc.Height
        wc.Width = pnlTaskControlInner.Width
        wc.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right

        'If Not cwc Is Nothing Then wc.LoadEventControl(cwc)
        'ReDim Preserve TempControls(TempControls.Length)
        'cwc = wc.cec
        'TempControls(TempControls.Length - 1) = cwc
        If Not bAdding Then
            wc.LoadEventControl(cwc)
        Else
            ReDim Preserve TempControls(TempControls.Length)
            TempControls(TempControls.Length - 1) = wc.cec
        End If

    End Sub


    Private Sub btnAddActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddActivity.Click
        AddSubWalk()
    End Sub


    Public Sub DoSubEventButtons()
        tmrButtons.Interval = 200 ' This gap needs to be enough to allow the click event on the Remove button to fire before we disable it
        tmrButtons.Enabled = True
    End Sub


    Private Sub SubEventButtons()

        tmrButtons.Enabled = False

        Dim bRemoveSubWalk As Boolean = False
        Dim bUp As Boolean = False
        Dim bDown As Boolean = False

        LastSelectedSubWalk = Nothing
        For Each swk As SubWalk In pnlSubWalksInner.Controls
            If swk.Focused Then
                If Not swk Is pnlSubWalksInner.Controls(0) Then bUp = True
                If Not swk Is pnlSubWalksInner.Controls(pnlSubWalksInner.Controls.Count - 1) Then bDown = True
                LastSelectedSubWalk = swk
                bRemoveSubWalk = True
            End If
        Next

        btnRemoveActivity.Enabled = bRemoveSubWalk
        btnUpActivity.Enabled = bUp
        btnDownActivity.Enabled = bDown

    End Sub


    Private Sub AddSubWalk(Optional ByVal csw As clsWalk.SubWalk = Nothing)

        Dim bAdding As Boolean = (csw Is Nothing)
        Dim iTop As Integer
        For Each swk As SubWalk In pnlSubWalksInner.Controls
            iTop += swk.Height
        Next

        Dim sw As New SubWalk
        sw.Parent = pnlSubWalksInner
        pnlSubWalksInner.Height = iTop + sw.Height
        sw.Left = 0
        sw.Top = iTop
        sw.Width = pnlSubWalksInner.Width
        sw.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right


        'If Not csw Is Nothing Then sw.LoadSubWalk(csw)
        'ReDim Preserve TempSubWalks(TempSubWalks.Length)
        'csw = sw.csw
        'TempSubWalks(TempSubWalks.Length - 1) = csw
        If Not bAdding Then
            sw.LoadSubWalk(csw)
        Else
            ReDim Preserve TempSubWalks(TempSubWalks.Length)
            TempSubWalks(TempSubWalks.Length - 1) = sw.csw
        End If

    End Sub


    Private Sub RemoveSubWalk(ByVal sw As SubWalk)

        Dim bShuffle As Boolean = False

        For i As Integer = 0 To TempSubWalks.Length - 1
            If TempSubWalks(i) Is sw.csw Then
                pnlSubWalksInner.Controls.RemoveAt(i)
                sw.csw = Nothing
                bShuffle = True
            End If
            If bShuffle AndAlso i < TempSubWalks.Length - 1 Then TempSubWalks(i) = TempSubWalks(i + 1)
        Next
        'pnlSubEventsInner.Controls.Remove(se)
        ReDim Preserve TempSubWalks(TempSubWalks.Length - 2)
        RedrawSubWalks()

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

    End Sub


    Public Sub RedrawSubWalks()

        'For Each se As SubEvent In pnlSubEventsInner.Controls
        Dim iHeight As Integer = 0
        If pnlSubWalksInner.Controls.Count > 0 Then
            pnlSubWalksInner.Controls(0).Top = 0
            iHeight = pnlSubWalksInner.Controls(0).Height
        End If

        For iSE As Integer = 1 To pnlSubWalksInner.Controls.Count - 1
            iHeight += pnlSubWalksInner.Controls(iSE).Height
            pnlSubWalksInner.Controls(iSE).Top = pnlSubWalksInner.Controls(iSE - 1).Top + pnlSubWalksInner.Controls(iSE - 1).Height
        Next
        pnlSubWalksInner.Height = iHeight
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

        Dim sw As clsWalk.SubWalk = LastSelectedSubWalk.csw
        Dim swSwap As clsWalk.SubWalk
        Dim iIndex As Integer

        For i As Integer = 0 To TempSubWalks.Length - 1
            If TempSubWalks(i) Is LastSelectedSubWalk.csw Then
                iIndex = i
                Exit For
            End If
        Next

        If bIsUp Then
            swSwap = TempSubWalks(iIndex - 1)
            LastSelectedSubWalk.LoadSubWalk(swSwap)
            CType(pnlSubWalksInner.Controls(iIndex - 1), SubWalk).LoadSubWalk(sw)
        Else
            swSwap = TempSubWalks(iIndex + 1)
            LastSelectedSubWalk.LoadSubWalk(swSwap)
            CType(pnlSubWalksInner.Controls(iIndex + 1), SubWalk).LoadSubWalk(sw)
        End If

        TempSubWalks(iIndex) = swSwap
        TempSubWalks(CInt(IIf(bIsUp, iIndex - 1, iIndex + 1))) = sw

        RedrawSubWalks()

    End Sub


    Private Sub btnRemoveSubEvent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveActivity.Click
        If Not LastSelectedSubWalk Is Nothing Then RemoveSubWalk(LastSelectedSubWalk)
    End Sub

    Private Sub btnUpDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpActivity.Click, btnDownActivity.Click
        If Not LastSelectedSubWalk Is Nothing Then MoveUpDown(sender Is btnUpActivity)
    End Sub

    Private Sub tmrButtons_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrButtons.Tick
        If tmrButtons.Interval = 200 Then
            SubEventButtons()
        Else
            ControlButtons()
        End If
    End Sub


    Private Sub WalkButtons()

        If lvwSteps.SelectedItems.Count <> 1 Then
            btnUpStep.Enabled = False
            btnDownStep.Enabled = False
        Else
            If lvwSteps.SelectedIndices(0) > 0 Then btnUpStep.Enabled = True
            If lvwSteps.SelectedIndices(0) < lvwSteps.Items.Count - 1 Then btnDownStep.Enabled = True
        End If

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

    Private Sub lvwSteps_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwSteps.DoubleClick, btnEditStep.Click
        If lvwSteps.SelectedItems.Count = 1 Then EditStep(lvwSteps.SelectedItems(0))
    End Sub


    Private Sub EditStep(ByVal lvi As ListViewItem)
        EditStep(GetStepInfo(lvi), lvi)
    End Sub


    Private Function GetStepInfo(ByVal lvi As ListViewItem) As clsWalk.clsStep

        If lvi Is Nothing Then Return Nothing

        Dim [step] As New clsWalk.clsStep
        [step].sLocation = lvi.SubItems(2).Text
        Dim ft As String = lvi.SubItems(1).Text
        If ft.Contains("-") Then
            [step].ftTurns.iFrom = CInt(ft.Split("-"c)(0))
            [step].ftTurns.iTo = CInt(ft.Split("-"c)(1))
        Else
            [step].ftTurns.iFrom = CInt(ft)
            [step].ftTurns.iTo = [step].ftTurns.iFrom
        End If

        Return [step]

    End Function


    Private Function EditStep(ByVal [step] As clsWalk.clsStep, Optional ByVal lvi As ListViewItem = Nothing) As Boolean

        Dim frmStep As New frmWalkStep([step])
        If frmStep.DialogResult = Windows.Forms.DialogResult.OK Then
            SaveLVI([step], lvi)
            Return True
        Else
            Return False
        End If

    End Function


    Private Sub SaveLVI(ByVal [step] As clsWalk.clsStep, ByVal lvi As ListViewItem)

        Dim sDestination As String = ""
        Select Case [step].sLocation
            Case "Hidden"
                sDestination = "Hidden"
            Case Else
                If Adventure.htblCharacters.ContainsKey([step].sLocation) Then sDestination = "Follow "
                sDestination &= Adventure.GetNameFromKey([step].sLocation)
        End Select

        If lvi Is Nothing Then
            lvi = New ListViewItem
            lvwSteps.Items.Add(lvi)
            lvi.SubItems.Add("")
            lvi.SubItems.Add("")
        End If

        lvi.Text = sDestination

        'lvi.SubItems.Add(stp.iWaitTurns.ToString)
        If [step].ftTurns.iFrom = [step].ftTurns.iTo Then
            lvi.SubItems(1).Text = [step].ftTurns.iFrom.ToString
        Else
            lvi.SubItems(1).Text = [step].ftTurns.iFrom.ToString & " - " & [step].ftTurns.iTo.ToString
        End If
        lvi.SubItems(2).Text = [step].sLocation
    End Sub


    Private Sub btnAddStep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddStep.Click
        Dim [step] As New clsWalk.clsStep
        If EditStep([step]) Then lvwSteps.Items(lvwSteps.Items.Count - 1).EnsureVisible()
    End Sub



    Private Sub lvwSteps_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwSteps.SelectedIndexChanged

        If lvwSteps.SelectedItems.Count > 0 Then
            btnEditStep.Enabled = True
            btnRemoveStep.Enabled = True
        Else
            btnEditStep.Enabled = False
            btnRemoveStep.Enabled = False
        End If
        WalkButtons()

    End Sub

    Private Sub btnRemoveStep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveStep.Click

        If lvwSteps.SelectedItems.Count = 0 Then Exit Sub
        lvwSteps.Items.Remove(lvwSteps.SelectedItems(0))

    End Sub

    Private Sub btnRemoveControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveControl.Click
        If LastSelectedControl IsNot Nothing Then RemoveControl(LastSelectedControl)
    End Sub


    Private Sub btnStep_Click(sender As Object, e As System.EventArgs) Handles btnUpStep.Click, btnDownStep.Click

        Dim iUpDown As Integer = CInt(IIf(sender Is btnUpStep, -1, 1))

        Dim lvi1 As ListViewItem = lvwSteps.SelectedItems(0)
        Dim lvi2 As ListViewItem = lvwSteps.Items(lvi1.Index + iUpDown)

        Dim step1 As clsWalk.clsStep = GetStepInfo(lvi1)
        Dim step2 As clsWalk.clsStep = GetStepInfo(lvi2)

        SaveLVI(step1, lvi2)
        SaveLVI(step2, lvi1)

        lvi1.Selected = False
        lvi2.Selected = True
        lvwSteps.Focus()

    End Sub

End Class