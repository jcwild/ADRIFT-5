Public Class frmSynonym

    Private bChanged As Boolean
    Private cSyn As clsSynonym
    Private iSelectedIndex As Integer = 0
    Private bAllowChangeValue As Boolean = True


    Public Sub New(ByVal Syn As clsSynonym)
        MyBase.New()

        ' Check that this window isn't already open
        For Each w As Form In OpenForms
            If TypeOf w Is frmSynonym Then
                If CType(w, frmSynonym).cSyn.Key = Syn.Key AndAlso Syn.Key IsNot Nothing Then
                    w.BringToFront()
                    w.Focus()
                    Exit Sub
                End If
            End If
        Next

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoadForm(Syn)

    End Sub

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

    Private Sub LoadForm(ByRef cSyn As clsSynonym)

        Me.cSyn = cSyn

        With cSyn
            Text = "Synonym"
            If SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0")) Then Text &= " [" & .Key & "]"
            If .ChangeFrom.Count = 0 Then Text = "New Synonym"

            For Each sName As String In .ChangeFrom
                cmbFrom.Items.Add(sName)
            Next
            If cmbFrom.Items.Count > 0 Then
                iSelectedIndex = 0
                cmbFrom.SelectedIndex = 0
            Else
                cmbFrom.Items.Add("")
            End If
            
            txtTo.Text = .ChangeTo

        End With

        Me.Show()
        Changed = False

        OpenForms.Add(Me)

    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ApplySynonym()
        CloseSynonym(Me)
    End Sub


    Private Sub ApplySynonym()

        With cSyn
            .ChangeFrom.Clear()
            For Each vli As Infragistics.Win.ValueListItem In cmbFrom.Items
                If vli.DisplayText <> "" Then .ChangeFrom.Add(vli.DisplayText.Trim)
            Next
            .ChangeTo = txtTo.Text

            If .Key = "" Then
                .Key = .GetNewKey
                Adventure.htblSynonyms.Add(cSyn)
            End If
            .LastUpdated = Now
            .IsLibrary = False

            UpdateListItem(.Key, .CommonName)
        End With

        Adventure.Changed = True

    End Sub

    Private Sub cmbFrom_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFrom.Enter
        Me.AcceptButton = Nothing
    End Sub

    Private Sub cmbFrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbFrom.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                If iSelectedIndex = cmbFrom.Items.Count - 1 Then
                    iSelectedIndex += 1
                    cmbFrom.Items.Add("")
                    bAllowChangeValue = False
                    cmbFrom.Clear()
                    bAllowChangeValue = True
                Else
                    iSelectedIndex += 1
                    If cmbFrom.Items.Count > iSelectedIndex Then cmbFrom.SelectedItem = cmbFrom.Items(iSelectedIndex)
                    If cmbFrom.SelectedItem IsNot Nothing Then cmbFrom.SelectedText = cmbFrom.SelectedItem.DisplayText
                    cmbFrom.SelectionStart = 0
                    cmbFrom.SelectionLength = cmbFrom.Text.Length
                End If
                'NamesDebug()
            Case Keys.Up
                If iSelectedIndex > 0 Then iSelectedIndex -= 1
            Case Keys.Down
                If iSelectedIndex < cmbFrom.Items.Count - 1 Then iSelectedIndex += 1
            Case Keys.Delete
                If cmbFrom.SelectedText = cmbFrom.Text AndAlso iSelectedIndex > -1 Then cmbFrom.Items(iSelectedIndex).DataValue = ""
        End Select

        'If cmbFrom.Text = "" Then
        '    Debug.WriteLine("Text cleared on item " & iSelectedIndex)
        'End If
        'cmbFrom.Items(iSelectedIndex).DisplayText = cmbFrom.Text
        'NamesDebug()

    End Sub

    Private Sub cmbFrom_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbFrom.KeyUp
        If cmbFrom.Items.Count > iSelectedIndex Then cmbFrom.Items(iSelectedIndex).DisplayText = cmbFrom.Text
        'NamesDebug()
    End Sub

    Private Sub cmbFrom_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFrom.Leave
        'AddName(True)
        For i As Integer = cmbFrom.Items.Count - 1 To 0 Step -1
            If cmbFrom.Items(i).DisplayText = "" Then
                If iSelectedIndex = i Then iSelectedIndex = 0
                If iSelectedIndex > i Then iSelectedIndex -= 1
                If cmbFrom.Items.Count > 1 Then cmbFrom.Items.RemoveAt(i)
            End If
        Next
        Me.AcceptButton = btnOK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then ApplySynonym()
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        CloseSynonym(Me)

    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ApplySynonym()
        Changed = False
    End Sub

    Private Sub cmbFrom_SelectionChanged(sender As Object, e As System.EventArgs) Handles cmbFrom.SelectionChanged
        If bAllowChangeValue AndAlso cmbFrom.SelectedIndex > -1 AndAlso Not (cmbFrom.Text = "" AndAlso cmbFrom.Items(cmbFrom.SelectedIndex).DisplayText <> "") Then
            ' text won't match item when we change selection with mouse
            iSelectedIndex = cmbFrom.SelectedIndex            
        Else
            If cmbFrom.SelectedIndex > -1 Then Debug.WriteLine("text: " & cmbFrom.Text & ", item: " & cmbFrom.Items(cmbFrom.SelectedIndex).DisplayText)
        End If
    End Sub

    Private Sub StuffChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFrom.TextChanged, txtTo.TextChanged
        Changed = True
    End Sub


    Private Sub frmTextOverride_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OpenForms.Remove(Me)
    End Sub


    Private Sub frmHint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = Icon.FromHandle(My.Resources.Resources.imgSynonym16.GetHicon)
        GetFormPosition(Me)
    End Sub


    Private Sub frmTextOverride_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If cmbFrom.Text = "" Then
            cmbFrom.Focus()
        Else
            txtTo.Focus()
        End If
    End Sub

    Private Sub frmTextOverride_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        ShowHelp(Me, "Synonyms")
    End Sub

End Class