Public Class SubEventGUI

    Public cse As clsEvent.SubEvent
    Public Event ValueChanged(ByVal o As Object, ByVal e As EventArgs)


    Private Function ParentEventForm() As frmEvent
        Return CType(Me.Parent.Parent.Parent.Parent.Parent, frmEvent)
    End Function


    Private Sub cmbAction_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAction.ValueChanged

        Select Case cmbAction.SelectedItem.DataValue.ToString
            Case Is = "ExecuteTask", "UnsetTask"
                SetHeight(68)
                txtDescription.Visible = False
                'TaskList1.Visible = True
                isTasks.Visible = True
                cse.sKey = isTasks.Key
                lblGroup.Visible = False
                isLocationGroup.Visible = False
            Case Else
                SetHeight(153)
                txtDescription.Visible = True
                'TaskList1.Visible = False
                isTasks.Visible = False
                lblGroup.Visible = True
                isLocationGroup.Visible = True
                cse.sKey = isLocationGroup.Key
        End Select

        Select Case cmbAction.SelectedItem.DataValue.ToString
            Case "DisplayMessage"
                cse.eWhat = clsEvent.SubEvent.WhatEnum.DisplayMessage
            Case "ChangeLook"
                cse.eWhat = clsEvent.SubEvent.WhatEnum.SetLook
            Case "ExecuteTask"
                cse.eWhat = clsEvent.SubEvent.WhatEnum.ExecuteTask
            Case "UnsetTask"
                cse.eWhat = clsEvent.SubEvent.WhatEnum.UnsetTask
        End Select

    End Sub



    Private Sub SetHeight(ByVal iHeight As Integer)

        If Me.Height <> iHeight Then
            Me.Height = iHeight
            If Not Me.Parent Is Nothing Then
                ParentEventForm.RedrawSubEvents()
            End If
        End If

    End Sub


    Public Sub LoadSubEvent(ByVal se As clsEvent.SubEvent)

        cse = se

        With cse
            Select Case .eWhen
                Case clsEvent.SubEvent.WhenEnum.BeforeEndOfEvent
                    SetCombo(cmbFromStart, "BeforeEnd")
                Case clsEvent.SubEvent.WhenEnum.FromLastSubEvent
                    SetCombo(cmbFromStart, "FromLast")
                Case clsEvent.SubEvent.WhenEnum.FromStartOfEvent
                    SetCombo(cmbFromStart, "FromStart")
            End Select

            XtoYturns1.SetValues(.ftTurns.iFrom, .ftTurns.iTo)

            Select Case .eWhat
                Case clsEvent.SubEvent.WhatEnum.DisplayMessage
                    isLocationGroup.Key = .sKey
                    SetCombo(cmbAction, "DisplayMessage")
                Case clsEvent.SubEvent.WhatEnum.ExecuteTask
                    SetCombo(isTasks.cmbList, .sKey)
                    SetCombo(cmbAction, "ExecuteTask")
                Case clsEvent.SubEvent.WhatEnum.SetLook
                    isLocationGroup.Key = .sKey
                    SetCombo(cmbAction, "ChangeLook")
                Case clsEvent.SubEvent.WhatEnum.UnsetTask
                    SetCombo(isTasks.cmbList, .sKey)
                    SetCombo(cmbAction, "UnsetTask")
            End Select
            Select Case .eMeasure
                Case clsEvent.SubEvent.MeasureEnum.Turns
                    SetCombo(cmbTurnsSeconds, "Turns")
                Case clsEvent.SubEvent.MeasureEnum.Seconds
                    SetCombo(cmbTurnsSeconds, "Seconds")
            End Select

            txtDescription.Description = .oDescription

        End With

    End Sub

    Public Overrides ReadOnly Property Focused() As Boolean
        Get
            Return Me.cmbAction.Focused OrElse Me.cmbFromStart.Focused OrElse Me.XtoYturns1.Focused OrElse Me.isLocationGroup.Focused OrElse Me.txtDescription.Focused OrElse Me.isTasks.Focused
        End Get
    End Property



    Private Sub SubEvent_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAction.GotFocus, cmbFromStart.GotFocus, XtoYturns1.GotFocus, isLocationGroup.GotFocus, txtDescription.GotFocus, isTasks.GotFocus
        Me.lblHighlight.Visible = True
        ParentEventForm.DoSubEventButtons()
    End Sub


    Private Sub cmbAction_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAction.LostFocus, cmbFromStart.LostFocus, XtoYturns1.LostFocus, isLocationGroup.LostFocus, txtDescription.LostFocus, isTasks.LostFocus
        If Not Me.Focused Then
            lblHighlight.Visible = False
            ParentEventForm.DoSubEventButtons()
        End If
    End Sub


    Private Sub cmbFromStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFromStart.ValueChanged
        SortDropdowns()
    End Sub


    Friend Sub SortDropdowns()

        Select Case cmbFromStart.SelectedItem.DataValue.ToString
            Case "FromStart"
                lblAfterWith.Text = "After"
                cse.eWhen = clsEvent.SubEvent.WhenEnum.FromStartOfEvent
                If cmbTurnsSeconds.Items.Count = 1 Then
                    cmbTurnsSeconds.Items.Add("Seconds", "seconds")
                End If
            Case "FromLast"
                lblAfterWith.Text = "After"
                cse.eWhen = clsEvent.SubEvent.WhenEnum.FromLastSubEvent
                If cmbTurnsSeconds.Items.Count = 1 Then
                    cmbTurnsSeconds.Items.Add("Seconds", "seconds")
                End If
            Case "BeforeEnd"
                lblAfterWith.Text = "With"
                cse.eWhen = clsEvent.SubEvent.WhenEnum.BeforeEndOfEvent
                If cmbTurnsSeconds.Items.Count = 2 AndAlso CInt(ParentEventForm.optEventType.Value) = 0 Then
                    cmbTurnsSeconds.SelectedIndex = 0
                    cmbTurnsSeconds.Items.Remove(1)
                End If
                If cmbTurnsSeconds.Items.Count = 1 AndAlso CInt(ParentEventForm.optEventType.Value) = 1 Then
                    cmbTurnsSeconds.Items.Add("Seconds", "seconds")
                End If
        End Select

    End Sub


    Public Sub New()

        cse = New clsEvent.SubEvent("")

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtDescription.Description = cse.oDescription
        If Adventure.htblGroups.ContainsKey(ALLROOMS) Then Me.isLocationGroup.Key = ALLROOMS

    End Sub

    Private Sub SubEvent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetControlStyle(Me)
    End Sub

    Private Sub SubEvent_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.lblHighlight.Height = Me.Height - 5
    End Sub


    Private Sub txtDescription_txtSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.Changed
        cse.oDescription = txtDescription.Description
    End Sub

    Private Sub isLocationGroup_SelectionChanged() Handles isLocationGroup.SelectionChanged
        cse.sKey = isLocationGroup.Key
    End Sub

    Private Sub isTasks_SelectionChanged() Handles isTasks.SelectionChanged
        cse.sKey = isTasks.Key
    End Sub

    Private Sub XtoYturns1_ValueChanged() Handles XtoYturns1.ValueChanged
        cse.ftTurns.iFrom = XtoYturns1.From
        cse.ftTurns.iTo = XtoYturns1.To

        RaiseEvent ValueChanged(Me, New EventArgs)
    End Sub

    Private Sub lblBorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGroupBox1.Click
        If Not Me.Focused Then Me.XtoYturns1.txtFrom.Focus()
    End Sub

    Private Sub lblGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblGroup.Click, lblAfterWith.Click
        If Not Me.Focused Then Me.txtDescription.rtxtSource.Focus()
    End Sub

    Private Sub cmbTurnsSeconds_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbTurnsSeconds.ValueChanged
        If cmbTurnsSeconds.SelectedItem.DataValue.ToString = "Turns" Then cse.eMeasure = clsEvent.SubEvent.MeasureEnum.Turns Else cse.eMeasure = clsEvent.SubEvent.MeasureEnum.Seconds
    End Sub

End Class
