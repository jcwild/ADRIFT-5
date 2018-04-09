Public Class WhatsNew

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As System.EventArgs) Handles btnDownload.Click
        Cursor.Current = Cursors.WaitCursor
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class