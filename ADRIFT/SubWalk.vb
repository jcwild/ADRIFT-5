Public Class SubWalk

    Public csw As clsWalk.SubWalk



    Private Sub cmbAction_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAction.ValueChanged

        Select Case cmbAction.SelectedItem.DataValue.ToString
            Case Is = "ExecuteTask", "UnsetTask"
                SetHeight(68)
                txtDescription.Visible = False
                'TaskList1.Visible = True
                isTasks.Visible = True
                lblGroup.Visible = False
                isLocationGroup.Visible = False
            Case Else
                SetHeight(153)
                txtDescription.Visible = True
                'TaskList1.Visible = False
                isTasks.Visible = False
                lblGroup.Visible = True
                isLocationGroup.Visible = True
        End Select

        Select Case cmbAction.SelectedItem.DataValue.ToString
            Case "DisplayMessage"
                csw.eWhat = clsWalk.SubWalk.WhatEnum.DisplayMessage            
            Case "ExecuteTask"
                csw.eWhat = clsWalk.SubWalk.WhatEnum.ExecuteTask
            Case "UnsetTask"
                csw.eWhat = clsWalk.SubWalk.WhatEnum.UnsetTask
        End Select

    End Sub



    Private Sub SetHeight(ByVal iHeight As Integer)

        If Me.Height <> iHeight Then
            Me.Height = iHeight
            If Not Me.Parent Is Nothing Then
                CType(Me.Parent.Parent.Parent.Parent.Parent, frmWalk).RedrawSubWalks()
            End If
        End If

    End Sub


    Public Sub LoadSubWalk(ByVal sw As clsWalk.SubWalk)

        csw = sw

        With csw
            XtoYturns1.SetValues(.ftTurns.iFrom, .ftTurns.iTo)

            Select Case .eWhen
                Case clsWalk.SubWalk.WhenEnum.BeforeEndOfWalk
                    SetCombo(cmbFromStart, "BeforeEnd")
                Case clsWalk.SubWalk.WhenEnum.FromLastSubWalk
                    SetCombo(cmbFromStart, "FromLast")
                Case clsWalk.SubWalk.WhenEnum.FromStartOfWalk
                    SetCombo(cmbFromStart, "FromStart")
                Case clsWalk.SubWalk.WhenEnum.ComesAcross
                    SetCombo(cmbFromStart, "ComesAcross")
                    isObjectChar.Key = .sKey
            End Select
            Select Case .eWhat
                Case clsWalk.SubWalk.WhatEnum.DisplayMessage
                    SetCombo(cmbAction, "DisplayMessage")
                Case clsWalk.SubWalk.WhatEnum.ExecuteTask
                    SetCombo(cmbAction, "ExecuteTask")
                    SetCombo(isTasks.cmbList, .sKey2)
                Case clsWalk.SubWalk.WhatEnum.UnsetTask
                    SetCombo(cmbAction, "UnsetTask")
                    SetCombo(isTasks.cmbList, .sKey2)
            End Select

            txtDescription.Description = .oDescription
            isLocationGroup.Key = .sKey3 ' Hmm, looks like we'll need sKey3

        End With

    End Sub

    Public Overrides ReadOnly Property Focused() As Boolean
        Get
            Return Me.cmbAction.Focused OrElse Me.cmbFromStart.Focused OrElse Me.XtoYturns1.Focused OrElse Me.isLocationGroup.Focused OrElse Me.txtDescription.Focused OrElse Me.isTasks.Focused
        End Get
    End Property



    Private Sub SubEvent_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAction.GotFocus, cmbFromStart.GotFocus, XtoYturns1.GotFocus, isLocationGroup.GotFocus, txtDescription.GotFocus, isTasks.GotFocus
        Me.lblHighlight.Visible = True
        CType(Me.Parent.Parent.Parent.Parent.Parent, frmWalk).DoSubEventButtons()
    End Sub


    Private Sub cmbAction_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAction.LostFocus, cmbFromStart.LostFocus, XtoYturns1.LostFocus, isLocationGroup.LostFocus, txtDescription.LostFocus, isTasks.LostFocus
        If Not Me.Focused Then
            lblHighlight.Visible = False
            CType(Me.Parent.Parent.Parent.Parent.Parent, frmWalk).DoSubEventButtons()
        End If
    End Sub


    Private Sub cmbFromStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFromStart.ValueChanged

        Select Case cmbFromStart.SelectedItem.DataValue.ToString
            Case "FromStart"
                lblAfterWith.Text = "After"
                csw.eWhen = clsWalk.SubWalk.WhenEnum.FromStartOfWalk
                isObjectChar.Visible = False
                XtoYturns1.Visible = True
                UltraLabel2.Visible = True
                cmbFromStart.Location = New Point(215, 10)
            Case "FromLast"
                lblAfterWith.Text = "After"
                csw.eWhen = clsWalk.SubWalk.WhenEnum.FromLastSubWalk
                isObjectChar.Visible = False
                XtoYturns1.Visible = True
                UltraLabel2.Visible = True
                cmbFromStart.Location = New Point(215, 10)
            Case "BeforeEnd"
                lblAfterWith.Text = "With"
                csw.eWhen = clsWalk.SubWalk.WhenEnum.BeforeEndOfWalk
                isObjectChar.Visible = False
                XtoYturns1.Visible = True
                UltraLabel2.Visible = True
                cmbFromStart.Location = New Point(215, 10)
            Case "ComesAcross"
                lblAfterWith.Text = "If"
                csw.eWhen = clsWalk.SubWalk.WhenEnum.ComesAcross
                isObjectChar.Visible = True
                XtoYturns1.Visible = False
                UltraLabel2.Visible = False
                cmbFromStart.Location = New Point(30, 10)
        End Select

    End Sub

    Public Sub New()

        csw = New clsWalk.SubWalk

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtDescription.Description = csw.oDescription

    End Sub

    Private Sub SubEvent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetControlStyle(Me)
    End Sub

    Private Sub SubEvent_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.lblHighlight.Height = Me.Height - 5
    End Sub


    Private Sub txtDescription_txtSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.Changed
        csw.oDescription = txtDescription.Description
    End Sub

    Private Sub isObjectChar_SelectionChanged() Handles isObjectChar.SelectionChanged
        csw.sKey = isObjectChar.Key
    End Sub

    Private Sub isTasks_SelectionChanged() Handles isTasks.SelectionChanged
        csw.sKey2 = isTasks.Key
    End Sub

    Private Sub isLocationGroup_SelectionChanged() Handles isLocationGroup.SelectionChanged
        csw.sKey3 = isLocationGroup.Key
    End Sub

    Private Sub XtoYturns1_ValueChanged() Handles XtoYturns1.ValueChanged
        csw.ftTurns.iFrom = XtoYturns1.From
        csw.ftTurns.iTo = XtoYturns1.To
    End Sub

    Private Sub lblBorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGroupBox1.Click
        If Not Me.Focused Then
            If XtoYturns1.Visible Then XtoYturns1.txtFrom.Focus() Else cmbFromStart.Focus()
        End If
    End Sub

    Private Sub lblGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblGroup.Click, lblAfterWith.Click
        If Not Me.Focused Then Me.txtDescription.rtxtSource.Focus()
    End Sub

End Class
