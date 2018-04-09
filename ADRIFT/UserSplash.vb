Public Class frmUserSplash

    Private WithEvents tmrSplash As New Timer

    Private Sub UserSplash_Click(sender As Object, e As System.EventArgs) Handles Me.Click
        Me.Close()
    End Sub

    Private Sub UserSplash_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tmrSplash.Interval = 30000
        tmrSplash.Start()
        Cursor = Cursors.Hand
    End Sub

    Private Sub tmrSplash_Tick(sender As Object, e As System.EventArgs) Handles tmrSplash.Tick
        Me.Close()
    End Sub

End Class