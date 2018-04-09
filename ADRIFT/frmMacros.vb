Option Strict On

Public Class frmMacros

    'Friend htblMacros As StringHashTable
    Friend ldictMacros As Generic.Dictionary(Of String, clsMacro)
    Private arlKeys As New StringArrayList
    Private bSetting As Boolean = False

    Private bChanged As Boolean = False
    Private Property Changed() As Boolean
        Get
            Return bChanged
        End Get
        Set(ByVal value As Boolean)
            bChanged = value
            btnApply.Enabled = bChanged
        End Set
    End Property


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim sTitle As String = InputBox("Enter menu title for macro:", "Create Macro", "")
        If sTitle <> "" Then
            Dim sKey As String = Guid.NewGuid.ToString
            Dim macro As New clsMacro(sKey)
            macro.Title = sTitle
            macro.IFID = Adventure.BabelTreatyInfo.Stories(0).Identification.IFID

            ldictMacros.Add(macro.Key, macro)
            lstMacros.Items.Add(sTitle)
            arlKeys.Add(macro.Key)
            lstMacros.SelectedIndex = lstMacros.Items.Count - 1
            Changed = True
            'htblMacros.Add(sTitle, "")
        End If
    End Sub


    Private Sub lstMacros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMacros.SelectedIndexChanged

        If lstMacros.SelectedItem IsNot Nothing Then
            Dim bTemp As Boolean = bChanged
            bSetting = True
            Dim sKey As String = arlKeys(lstMacros.SelectedIndex) ' GetKeyFromTitle(lstMacros.SelectedItem.ToString)
            If sKey <> "" Then
                With ldictMacros(sKey)
                    txtCommands.Text = .Commands
                    chkShared.Checked = .Shared
#If Mono Then
                    cmbShortcut.Text = .Shortcut.ToString
#Else
                    SetCombo(cmbShortcut, .Shortcut)
#End If

                End With
            End If
            btnUp.Enabled = lstMacros.SelectedIndex > 0
            btnDown.Enabled = lstMacros.SelectedIndex < lstMacros.Items.Count - 1
            chkShared.Enabled = True
            txtCommands.Enabled = True
            btnRemove.Enabled = True
            cmbShortcut.Enabled = True

            bSetting = False
            bChanged = bTemp
        End If

    End Sub


    'Private Sub LoadCommands(ByVal sTitle As String)

    '    If ldictMacros.ContainsKey(sTitle) Then
    '        txtCommands.Text = ldictMacros(sTitle).Commands
    '    Else
    '        txtCommands.Clear()
    '    End If
    '    txtCommands.Enabled = True

    'End Sub

    Private Sub txtCommands_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.SplitterMoved
        lblCommands.Left = SplitContainer1.SplitterDistance + SplitContainer1.Left + SplitContainer1.SplitterWidth
    End Sub

    Private Sub txtCommands_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCommands.GotFocus
        AcceptButton = Nothing
    End Sub

    Private Sub txtCommands_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCommands.LostFocus
        AcceptButton = btnOK
    End Sub

    Private Sub txtCommands_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCommands.TextChanged

        If bSetting Then Exit Sub

        If lstMacros.SelectedItem IsNot Nothing Then
            Dim sKey As String = arlKeys(lstMacros.SelectedIndex) ' GetKeyFromTitle(lstMacros.SelectedItem.ToString)
            If sKey <> "" Then ldictMacros(sKey).Commands = txtCommands.Text

            Changed = True
        End If

    End Sub


    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            If MessageBox.Show("Lose changes?", "Edit Macros", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Cancel Then
                DialogResult = Nothing
                Exit Sub
            End If
        End If

        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()

    End Sub


    'Private Function GetKeyFromTitle(ByVal sTitle As String) As String
    '    ' Find the key from the title
    '    Dim sKey As String = ""
    '    For Each macro As clsMacro In ldictMacros.Values
    '        If macro.Title = sTitle AndAlso (macro.Shared OrElse macro.IFID = Adventure.BabelTreatyInfo.Stories(0).Identification.IFID) Then
    '            Return macro.Key
    '        End If
    '    Next
    '    Return ""
    'End Function


    Private Sub Apply()

        With UserSession
            .dictMacros = New Generic.Dictionary(Of String, clsMacro)

            For i As Integer = 0 To lstMacros.Items.Count - 1 ' Each sTitle As String In lstMacros.Items
                Dim sKey As String = arlKeys(i) ' GetKeyFromTitle(sTitle)
                If sKey <> "" Then
                    If Not .dictMacros.ContainsKey(sKey) Then .dictMacros.Add(sKey, ldictMacros(sKey))
                End If
            Next
            For Each macro As clsMacro In ldictMacros.Values
                If Not .dictMacros.ContainsKey(macro.Key) Then
                    .dictMacros.Add(macro.Key, macro)
                End If
            Next
            'dictMacros = ldictMacros
            .SaveMacros()
            fRunner.ReloadMacros()
            Changed = False
        End With

    End Sub


    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Apply()
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub


    Private Sub frmMacros_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        GetFormPosition(Me)

#If Mono Then
        btnUp.Text = ChrW(&H25B2)
        btnUp.Font = New Font("OpenSymbol", btnUp.Font.Size)
        btnDown.Text = ChrW(&H25BC)
        btnDown.Font = New Font("OpenSymbol", btnUp.Font.Size)
#End If
        For Each key As Keys In New Keys() {Keys.None, Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12}
#If Mono Then
            cmbShortcut.Items.Add(New ComboBoxItem(key))
#Else
            cmbShortcut.Items.Add(key, key.ToString)
#End If
        Next

        For Each sKey As String In ldictMacros.Keys
            If ldictMacros.ContainsKey(sKey) Then
                With ldictMacros(sKey)
                    If .IFID = Adventure.BabelTreatyInfo.Stories(0).Identification.IFID OrElse .Shared Then
                        lstMacros.Items.Add(.Title)
                        arlKeys.Add(.Key)
                    End If
                End With
            End If
        Next

#If Mono Then
        cmbShortcut.Text = "None"
#Else
        SetCombo(cmbShortcut, Keys.None)
#End If

        Changed = False

    End Sub


    Private Sub chkShared_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShared.CheckedChanged

        If bSetting Then Exit Sub

        If lstMacros.SelectedItem IsNot Nothing Then
            Dim sKey As String = arlKeys(lstMacros.SelectedIndex) ' GetKeyFromTitle(lstMacros.SelectedItem.ToString)
            If sKey <> "" Then
                ldictMacros(sKey).Shared = chkShared.Checked

                Changed = True
            End If
        End If

    End Sub


#If Mono Then
    Private Sub cmbShortcut_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShortcut.SelectedIndexChanged
#Else
    Private Sub cmbShortcut_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShortcut.SelectionChanged
#End If

        If bSetting Then Exit Sub

        If lstMacros.SelectedItem IsNot Nothing Then
            Dim sKey As String = arlKeys(lstMacros.SelectedIndex) ' GetKeyFromTitle(lstMacros.SelectedItem.ToString)
            If sKey <> "" Then
#If Mono Then
                ldictMacros(sKey).Shortcut = CType(CType(cmbShortcut.SelectedItem, ComboBoxItem).KeyboardShortcut, Shortcut)
#Else
                ldictMacros(sKey).Shortcut = CType(cmbShortcut.SelectedItem.DataValue, Shortcut)
#End If

                Changed = True
            End If
        End If

    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Apply()
    End Sub

    Private Sub btnUpDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUp.Click, btnDown.Click

        Dim iUpDown As Integer = CInt(IIf(sender Is btnUp, -1, 1))

        If lstMacros.SelectedItem IsNot Nothing Then
            Dim sTmp As String = lstMacros.SelectedItem.ToString
            Dim sTmpKey As String = arlKeys(lstMacros.SelectedIndex)
            lstMacros.Items(lstMacros.SelectedIndex) = lstMacros.Items(lstMacros.SelectedIndex + iUpDown).ToString
            arlKeys(lstMacros.SelectedIndex) = arlKeys(lstMacros.SelectedIndex + iUpDown)
            lstMacros.Items(lstMacros.SelectedIndex + iUpDown) = sTmp
            arlKeys(lstMacros.SelectedIndex + iUpDown) = sTmpKey
            lstMacros.SelectedIndex = lstMacros.SelectedIndex + iUpDown
            Changed = True
        End If

    End Sub

    Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click

        If lstMacros.SelectedItem IsNot Nothing Then
            Dim sKey As String = arlKeys(lstMacros.SelectedIndex) ' GetKeyFromTitle(lstMacros.SelectedItem.ToString)
            If sKey <> "" Then
                ldictMacros.Remove(sKey)
                arlKeys.RemoveAt(lstMacros.SelectedIndex)
                lstMacros.Items.RemoveAt(lstMacros.SelectedIndex)
                bSetting = True
                txtCommands.Clear()
                bSetting = False
                btnUp.Enabled = False
                btnDown.Enabled = False
                cmbShortcut.Enabled = False
                btnRemove.Enabled = False
                chkShared.Enabled = False
                Changed = True
            End If
        End If

    End Sub

End Class