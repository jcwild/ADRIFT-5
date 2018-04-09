Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinListView

Public Class SearchReplace

    Private bLoaded As Boolean = False
    Private fFolder As Folder

    Private Sub btnSelectFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFind.Click
        If btnSelectFind.Checked Then Exit Sub
        btnSelectFind.Checked = True
        btnSelectReplace.Checked = False
        pnlReplace.Visible = False
        lvwFoundItems.Visible = False
        btnReplace.Visible = False
        btnReplaceAll.Visible = False
        btnFindAll.Visible = True
        btnFind.Left += 91
        FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        ResizeForm()
    End Sub

    Private Sub btnSelectReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectReplace.Click
        If btnSelectReplace.Checked Then Exit Sub
        btnSelectReplace.Checked = True
        btnSelectFind.Checked = False
        pnlReplace.Visible = True
        lvwFoundItems.Visible = False
        If bLoaded Then btnFind.Left -= 91
        btnFindAll.Visible = False
        btnReplace.Visible = True
        btnReplaceAll.Visible = True
        FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow

        ' Something cuckoo started happening with z-order
        pnlLookIn.SendToBack()
        pnlReplace.SendToBack()
        pnlFind.SendToBack()
        Me.toolsSearchReplace.SendToBack()
        btnReplace.BringToFront()
        btnReplaceAll.BringToFront()

        ResizeForm()
    End Sub


    Private Sub ResizeForm()
        Dim iListHeight As Integer = 0
        If lvwFoundItems.Visible Then iListHeight = lvwFoundItems.Height
        If btnSelectFind.Checked Then
            Me.ClientSize = New Size(350, toolsSearchReplace.Height + pnlFind.Height + pnlLookIn.Height + grpSearchOptions.Height + StatusBar.Height + iListHeight) ' + 22)
        Else
            Me.ClientSize = New Size(350, toolsSearchReplace.Height + pnlFind.Height + pnlReplace.Height + pnlLookIn.Height + grpSearchOptions.Height + StatusBar.Height + iListHeight) '+ 22)
        End If
    End Sub

    Public Sub SetFind()
        btnSelectFind_Click(btnSelectFind, Nothing)
    End Sub


    Public Sub SetReplace()
        btnSelectReplace_Click(btnSelectReplace, Nothing)
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click

        For Each vli As ValueListItem In cmbFind.Items
            If vli.DisplayText = cmbFind.Text Then
                cmbFind.Items.Remove(vli)
                Exit For
            End If
        Next
        cmbFind.Items.Add(cmbFind.Text)

        If cmbFind.Text <> "" Then
            If Search(cmbFind.Text) Then
                btnFind.Text = "&Find Next"
            Else
                btnFind.Text = "&Find"
            End If
        End If

    End Sub


    Private Sub cmbFind_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFind.ValueChanged
        btnFind.Enabled = cmbFind.Text.Length > 0
        btnFindAll.Enabled = cmbFind.Text.Length > 0
        btnReplaceAll.Enabled = cmbFind.Text.Length > 0
        btnFind.Text = "&Find"
    End Sub


    Private Sub grpSearchOptions_ExpandedStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grpSearchOptions.ExpandedStateChanged
        ResizeForm()
        SaveSetting("ADRIFT", "Generator", "ShowSearchOptions", CInt(grpSearchOptions.Expanded).ToString)
    End Sub


    Private Sub SearchReplace_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveFormPosition(Me)
    End Sub


    Private Sub SearchReplace_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fSearch = Me
        SetCombo(cmbLookIn, CInt(SearchOptions.SearchInWhat))
        grpSearchOptions.Expanded = CBool(GetSetting("ADRIFT", "Generator", "ShowSearchOptions", "0"))
        GetFormPosition(Me, , , False)

        lvwFoundItems.MainColumn.Key = "Item"
        lvwFoundItems.MainColumn.Text = "Item"
        lvwFoundItems.MainColumn.Width = CInt(lvwFoundItems.Width * 0.6)       
        Dim colFolder As New UltraListViewSubItemColumn
        colFolder.Key = "Folder"
        colFolder.Text = "Folder"
        colFolder.Width = lvwFoundItems.Width - CInt(lvwFoundItems.Width * 0.6)
        lvwFoundItems.SubItemColumns.Add(colFolder) '"Folder", lvwFoundItems.Width - CInt(lvwFoundItems.Width * 0.6))
        lvwFoundItems.SubItemColumns.Add("sFolderKey")
        lvwFoundItems.SubItemColumns("sFolderKey").VisibleInDetailsView = DefaultableBoolean.False
        'lvwFoundItems.FullRowSelect = True
        lvwFoundItems.View = UltraWinListView.UltraListViewStyle.Details
        
        bLoaded = True
    End Sub


    Private Sub SearchReplace_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        If lvwFoundItems.SubItemColumns.Count > 0 Then
            lvwFoundItems.SubItemColumns(0).Width = 180
            lvwFoundItems.MainColumn.Width = lvwFoundItems.Width - lvwFoundItems.SubItemColumns(0).Width - 2
        End If
    End Sub


    Private Sub SearchReplace_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        cmbFind.Focus()
    End Sub


    Private Sub btnReplaceAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReplaceAll.Click

        For Each vli As ValueListItem In cmbFind.Items
            If vli.DisplayText = cmbFind.Text Then
                cmbFind.Items.Remove(vli)
                Exit For
            End If
        Next
        cmbFind.Items.Add(cmbFind.Text)

        For Each vli As ValueListItem In cmbReplace.Items
            If vli.DisplayText = cmbFind.Text Then
                cmbReplace.Items.Remove(vli)
                Exit For
            End If
        Next
        cmbReplace.Items.Add(cmbReplace.Text)

        If cmbFind.Text <> "" Then SearchAndReplace(cmbFind.Text, cmbReplace.Text)

    End Sub


    Private Sub cmbLookIn_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLookIn.SelectionChanged
        If bLoaded Then SearchOptions.SearchInWhat = CType(cmbLookIn.SelectedItem.DataValue, clsSearchOptions.SearchInWhatEnum)
    End Sub

    Private Sub chkMatchCase_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMatchCase.CheckedChanged
        If bLoaded Then SearchOptions.bSearchMatchCase = chkMatchCase.Checked
    End Sub

    Private Sub chkMatchWholeWord_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMatchWholeWord.CheckedChanged
        If bLoaded Then SearchOptions.bFindExactWord = chkMatchWholeWord.Checked
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindAll_Click(sender As System.Object, e As System.EventArgs) Handles btnFindAll.Click

        If fFolder Is Nothing Then fFolder = New Folder

        For Each vli As ValueListItem In cmbFind.Items
            If vli.DisplayText = cmbFind.Text Then
                cmbFind.Items.Remove(vli)
                Exit For
            End If
        Next
        cmbFind.Items.Add(cmbFind.Text)

        If cmbFind.Text <> "" Then            
            lvwFoundItems.Items.Clear()
            For Each item As clsItem In FindAll(cmbFind.Text)

                Dim subitems() As UltraListViewSubItem = {New UltraListViewSubItem, New UltraListViewSubItem}

                Dim folder As clsFolder = GetFolder(item)
                If folder IsNot Nothing Then
                    subitems(0).Value = folder.Name
                    subitems(1).Value = folder.Key

                    ' Shouldn't already exist, but we've had issues with duplicate keys with different case
                    If Not lvwFoundItems.Items.Exists(item.Key) Then lvwFoundItems.Items.Add(fFolder.GetItem(item, subitems))
                End If

            Next
        End If

        FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
        lvwFoundItems.Visible = True
       
        If Me.Height < 500 Then Me.Height = 500

    End Sub

    Private Function GetFolder(ByVal item As clsItem) As clsFolder

        For Each Folder As clsFolder In Adventure.dictFolders.Values
            If Folder.ContainsKey(item.Key, False) Then Return Folder
        Next
        Return Nothing

    End Function


    Private Sub lvwFoundItems_ItemDoubleClick(sender As Object, e As ItemDoubleClickEventArgs) Handles lvwFoundItems.ItemDoubleClick
        EditItem(e.Item)
    End Sub


    Private Sub miEditItem_Click(sender As System.Object, e As System.EventArgs) Handles miEditItem.Click
        If lvwFoundItems.SelectedItems.Count = 1 Then EditItem(lvwFoundItems.SelectedItems(0))
    End Sub


    Private Sub EditItem(ByVal lvi As UltraListViewItem)
        Me.TopMost = False
        Dim sKey As String = lvi.Key
        fFolder.Edit(Adventure.GetTypeFromKeyNice(sKey), , sKey)
    End Sub


    Private Sub miOpenFolder_Click(sender As System.Object, e As System.EventArgs) Handles miOpenFolder.Click

        If lvwFoundItems.SelectedItems.Count = 1 Then
            Dim sFolderKey As String = lvwFoundItems.SelectedItems(0).SubItems(1).Value.ToString
            fGenerator.FolderList1.OpenNewFolder(sFolderKey)
            For Each child As frmFolder In fGenerator.MDIFolders
                If child.Folder.folder.Key = sFolderKey Then
                    For Each lvi As UltraListViewItem In child.Folder.lstContents.Items
                        If lvi.Key = lvwFoundItems.SelectedItems(0).Key Then
                            child.Folder.lstContents.SelectedItems.Clear()
                            child.Folder.lstContents.SelectedItems.Add(lvi)
                            lvi.Activate()
                            child.Focus()
                        End If
                    Next
                    Exit For
                End If
            Next
        End If             

    End Sub


    Private Sub lvwFoundItems_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvwFoundItems.MouseDown

        Dim itemCursor As UltraListViewItem = lvwFoundItems.ItemFromPoint(lvwFoundItems.PointToClient(MousePosition))                

        ' If user right-clicks on the text (rather than just the item), select the item
        If itemCursor IsNot Nothing AndAlso Not itemCursor.IsSelected AndAlso lvwFoundItems.PointToClient(MousePosition).X < lvwFoundItems.Width / 2 Then
            lvwFoundItems.SelectedItems.Clear()
            lvwFoundItems.SelectedItems.Add(itemCursor)
            lvwFoundItems.ActiveItem = itemCursor
        End If

    End Sub

End Class
