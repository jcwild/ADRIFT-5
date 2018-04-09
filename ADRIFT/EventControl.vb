Public Class EventControl

    Friend cec As EventOrWalkControl


    Private Sub EventControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetControlStyle(Me)       
    End Sub


    Friend Sub LoadEventControl(ByVal ec As EventOrWalkControl)

        cec = ec

        With cec

            Select Case .eControl
                Case EventOrWalkControl.ControlEnum.Start
                    SetCombo(cmbStartStop, "Start")
                Case EventOrWalkControl.ControlEnum.Stop
                    SetCombo(cmbStartStop, "Stop")
                Case EventOrWalkControl.ControlEnum.Suspend
                    SetCombo(cmbStartStop, "Suspend")
                Case EventOrWalkControl.ControlEnum.Resume
                    SetCombo(cmbStartStop, "Resume")
            End Select

            Select Case .eCompleteOrNot
                Case EventOrWalkControl.CompleteOrNotEnum.Completion
                    SetCombo(cmbComplete, "completion")
                Case EventOrWalkControl.CompleteOrNotEnum.UnCompletion
                    SetCombo(cmbComplete, "uncompletion")
            End Select

            SetCombo(isTasks.cmbList, .sTaskKey)

        End With

    End Sub



    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cec = New EventOrWalkControl

    End Sub



    Private Sub EventControl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStartStop.GotFocus, cmbComplete.GotFocus, isTasks.GotFocus

        Me.lblHighlight.Visible = True
        Dim parent As Control = Me.Parent.Parent.Parent.Parent.Parent
        If TypeOf parent Is frmWalk Then
            CType(parent, frmWalk).DoControlButtons()
        ElseIf TypeOf parent Is frmEvent Then
            CType(parent, frmEvent).DoControlButtons()
        End If

    End Sub



    Private Sub EventControl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStartStop.LostFocus, cmbComplete.LostFocus, isTasks.LostFocus

        If Not Me.Focused Then
            lblHighlight.Visible = False
            Dim parent As Control = Me.Parent.Parent.Parent.Parent.Parent
            If TypeOf parent Is frmWalk Then
                CType(parent, frmWalk).DoControlButtons()
            ElseIf TypeOf parent Is frmEvent Then
                CType(parent, frmEvent).DoControlButtons()
            End If
        End If
    End Sub



    Private Sub UltraLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel1.Click, UltraLabel2.Click, UltraGroupBox1.Click
        cmbStartStop.Focus()
    End Sub



    Public Overrides ReadOnly Property Focused() As Boolean
        Get
            Return cmbStartStop.Focused OrElse cmbComplete.Focused OrElse isTasks.Focused
        End Get
    End Property



    Private Sub cmbStartStop_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStartStop.SelectionChanged

        If cmbStartStop.SelectedItem.DataValue IsNot Nothing AndAlso cec IsNot Nothing Then
            Select Case cmbStartStop.SelectedItem.DataValue.ToString
                Case "Start"
                    cec.eControl = EventOrWalkControl.ControlEnum.Start
                Case "Stop"
                    cec.eControl = EventOrWalkControl.ControlEnum.Stop
                Case "Suspend"
                    cec.eControl = EventOrWalkControl.ControlEnum.Suspend
                Case "Resume"
                    cec.eControl = EventOrWalkControl.ControlEnum.Resume
            End Select
        End If

    End Sub



    Private Sub cmbComplete_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbComplete.SelectionChanged

        If cmbComplete.SelectedItem.DataValue IsNot Nothing AndAlso cec IsNot Nothing Then
            Select Case cmbComplete.SelectedItem.DataValue.ToString
                Case "completion"
                    cec.eCompleteOrNot = EventOrWalkControl.CompleteOrNotEnum.Completion
                Case "uncompletion"
                    cec.eCompleteOrNot = EventOrWalkControl.CompleteOrNotEnum.UnCompletion
            End Select
        End If

    End Sub



    Private Sub isTasks_SelectionChanged() Handles isTasks.SelectionChanged
        If cec IsNot Nothing Then cec.sTaskKey = isTasks.Key
    End Sub

End Class
