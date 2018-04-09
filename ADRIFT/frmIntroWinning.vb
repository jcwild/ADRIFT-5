Public Class frmIntroWinning

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadForm()
        Me.Show()

    End Sub


    Private bChanged As Boolean
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


    Private Sub LoadForm()

        txtIntro.Description = Adventure.Introduction
        chkDisplayFirstRoom.Checked = Adventure.ShowFirstRoom
        If Adventure.Player IsNot Nothing Then cmbStartLocation.Key = Adventure.Player.Location.Key
        txtWinning.Description = Adventure.WinningText
        Changed = False

    End Sub



    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ApplyIntroWinning()
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then ApplyIntroWinning()
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub ApplyIntroWinning()

        Adventure.Introduction = txtIntro.Description.Copy
        Adventure.ShowFirstRoom = chkDisplayFirstRoom.Checked
        If Adventure.Player IsNot Nothing Then
            Dim loc As clsCharacterLocation = Adventure.Player.Location
            loc.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
            loc.Key = cmbStartLocation.Key
            Adventure.Player.Move(loc)
        End If
        Adventure.WinningText = txtWinning.Description.Copy

        Adventure.Changed = True

    End Sub



    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ApplyIntroWinning()
        Changed = False
    End Sub


    Private Sub txtIntro_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIntro.Changed, txtWinning.Changed, chkDisplayFirstRoom.CheckedChanged
        Changed = True
    End Sub
    Private Sub cmbStartLocation_SelectionChanged() Handles cmbStartLocation.SelectionChanged
        Changed = True
    End Sub


    Private Sub frmIntroWinning_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveFormPosition(Me)
    End Sub


    Private Sub frmIntroWinning_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetFormPosition(Me)
        cmbStartLocation.BackColor = Color.Transparent
    End Sub

End Class