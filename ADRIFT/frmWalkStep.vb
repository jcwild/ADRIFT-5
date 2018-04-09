Public Class frmWalkStep

    Public [step] As clsWalk.clsStep

    Public Sub New(ByVal [step] As clsWalk.clsStep)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ItemSelector1.Key = [step].sLocation
        Me.XtoYturns1.SetValues([step].ftTurns.iFrom, [step].ftTurns.iTo)

        Me.step = [step]

        Me.ShowDialog()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        [step].sLocation = ItemSelector1.Key
        [step].ftTurns.iFrom = XtoYturns1.From
        [step].ftTurns.iTo = XtoYturns1.To

        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmWalkStep_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetFormPosition(Me)
    End Sub

End Class