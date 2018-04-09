Public Class frmFolder

    Dim pOrigSize As Size
    Dim pOrigLocation As Point
    Dim pOffsetInForm As Point
    Private Sub lblCaption_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCaption.MouseDown
        pOrigLocation = Me.Location
        pOffsetInForm = e.Location
        Me.BringToFront()
    End Sub

    Private Sub lblCaption_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCaption.MouseMove
        If MouseButtons = Windows.Forms.MouseButtons.Left Then
            Me.Location = New Point(pOrigLocation.X + e.Location.X - pOffsetInForm.X, pOrigLocation.Y + e.Location.Y - pOffsetInForm.Y)
            pOrigLocation = Me.Location
        End If
    End Sub


    Public Sub ScrollIntoView()

        If Not bAllowFolderScroll Then Exit Sub
        If Not CBool(SafeInt(GetSetting("ADRIFT", "Generator", "ScrollIntoView", "-1"))) Then Exit Sub ' No front end for this, but this gives us the ability to turn this feature off
        'fGenerator.ScrollControlIntoView(Me)
        'Exit Sub

        ' If the folder is visible but off screen, scroll it into view         
        Dim iMDIwidth As Integer = fGenerator.ClientSize.Width - 22
        Dim iMDIheight As Integer = fGenerator.ClientSize.Height - fGenerator.StatusBar1.Height - CInt(If(fGenerator.UTMMain.Ribbon.IsMinimized, 83, 186))

        ' TODO - Adjust h/w depending whether MDI scrollbars are visible

        For Each da As Infragistics.Win.UltraWinDock.DockAreaPane In fGenerator.UDMGenerator.DockAreas
            With da
                If Not .Closed AndAlso .DockedState = Infragistics.Win.UltraWinDock.DockedState.Docked Then
                    Select Case .DockedLocation
                        Case Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, Infragistics.Win.UltraWinDock.DockedLocation.DockedBottom
                            iMDIheight -= .Size.Height + 5
                        Case Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, Infragistics.Win.UltraWinDock.DockedLocation.DockedRight
                            iMDIwidth -= .Size.Width + 5
                    End Select
                End If
            End With
        Next

        Dim iMaxMove As Integer = 25
        While (Location.X + Width > iMDIwidth AndAlso Location.X > -1) OrElse (Location.Y + Height > iMDIheight AndAlso Location.Y > -1) OrElse Location.X < 0 OrElse Location.Y < 0
            Dim iX As Integer = 0
            If Location.X + Width > iMDIwidth AndAlso Location.X > 0 Then iX += Math.Min(Location.X + Width - iMDIwidth, iMaxMove)
            If Location.X < 0 Then iX += Math.Max(Location.X, -iMaxMove)
            Dim iY As Integer = 0
            If Location.Y + Height > iMDIheight AndAlso Location.Y > 0 Then iY += Math.Min(Location.Y + Height - iMDIheight, iMaxMove)
            If Location.Y < 0 Then iY += Math.Max(Location.Y, -iMaxMove)
            If iX = 0 AndAlso iY = 0 Then Exit While
            For Each c As frmFolder In fGenerator.MDIFolders
                c.Location = New Point(c.Location.X - iX, c.Location.Y - iY)
            Next
            Application.DoEvents()
            Threading.Thread.Sleep(1)
        End While

        ' TODO - Refresh the MDI scrollbars.  But how...?
        'fGenerator.PerformLayout()
        'Dim ptScroll As Point = fGenerator.AutoScrollOffset

    End Sub


    Private Sub Folder_ActiveChanged(ByVal sender As Object, ByVal bActive As Boolean) Handles Folder.ActiveChanged
        If bActive Then
            lblCaption.Font = New Font(lblCaption.Font, FontStyle.Bold)
            BringToFront()
            fGenerator.UTMMain.Tools("Cut").SharedProps.Enabled = Folder.lstContents.SelectedItems.Count > 0
            fGenerator.UTMMain.Tools("Copy").SharedProps.Enabled = Folder.lstContents.SelectedItems.Count > 0
            Folder.lstContents.ItemSettings.SelectedAppearance.BackColor = Color.FromArgb(238, 247, 253)
            Folder.lstContents.ItemSettings.SelectedAppearance.BackColor2 = Color.FromArgb(217, 240, 252)
        Else
            lblCaption.Font = New Font(lblCaption.Font, FontStyle.Regular)
            Folder.lstContents.ItemSettings.SelectedAppearance.BackColor = Color.FromArgb(247, 247, 247)
            Folder.lstContents.ItemSettings.SelectedAppearance.BackColor2 = Color.FromArgb(231, 231, 231)
        End If
    End Sub

    Private Sub Folder_LoadedFolder(ByVal sender As Object, ByVal e As System.EventArgs) Handles Folder.LoadedFolder
        lblCaption.Text = Folder.folder.Name
        UltraStatusBar1.Text = Folder.lstContents.Items.Count & " item" & IIf(Folder.lstContents.Items.Count <> 1, "s", "").ToString
        Select Case Folder.folder.ViewType
            Case Infragistics.Win.UltraWinListView.UltraListViewStyle.Details
                btnColumns.Visible = True
            Case Else
                btnColumns.Visible = False
        End Select
    End Sub

    Private Sub frmFolder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Folder.folder IsNot Nothing Then Folder.folder.Visible = False
    End Sub

    Private Sub frmFolder_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Folder.SetActive()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Folder.SetActive(False)
        Me.Close()
    End Sub

    Private Sub UltraStatusBar1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraStatusBar1.MouseDown
        pOrigSize = Me.Size
        pOffsetInForm = MousePosition ' e.Location        
    End Sub

    Private Sub UltraStatusBar1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraStatusBar1.MouseMove
        If MouseButtons = Windows.Forms.MouseButtons.Left AndAlso e.X > Width - 20 Then
            Dim pNewPos As Point = MousePosition
            Dim sizeNew As Size = New Size(pOrigSize.Width + pNewPos.X - pOffsetInForm.X, pOrigSize.Height + pNewPos.Y - pOffsetInForm.Y)
            Me.Size = sizeNew
            pOrigSize = Me.Size
            pOffsetInForm = pNewPos
            Me.Refresh()
            Folder.Refresh()
            btnClose.Refresh()
            'fGenerator.Refresh()            
        End If
    End Sub


    Private Sub frmFolder_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        If Folder.folder IsNot Nothing Then Folder.folder.Location = Me.Location
    End Sub

    Private Sub frmFolder_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Folder.folder IsNot Nothing Then Folder.folder.Size = Me.Size
    End Sub

    Private Sub Folder_MembersChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Folder.MembersChanged
        UltraStatusBar1.Text = Folder.folder.Members.Count & " item" & IIf(Folder.folder.Members.Count <> 1, "s", "").ToString
    End Sub

    Private Sub Folder_ViewTypeChanged(ByVal sender As Object, ByVal Type As Infragistics.Win.UltraWinListView.UltraListViewStyle) Handles Folder.ViewTypeChanged

        Select Case Type
            Case Infragistics.Win.UltraWinListView.UltraListViewStyle.Details
                btnColumns.Visible = True
            Case Else
                btnColumns.Visible = False
        End Select

    End Sub

    Private Sub btnColumns_DroppingDown(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles btnColumns.DroppingDown        
        lstColumns.SetItemChecked(0, Folder.folder.ShowCreatedDate)
        lstColumns.SetItemChecked(1, Folder.folder.ShowModifiedDate)
        lstColumns.SetItemChecked(2, Folder.folder.ShowType)
        lstColumns.SetItemChecked(3, Folder.folder.ShowKey)
        lstColumns.SetItemChecked(4, Folder.folder.ShowPriority)
    End Sub

    Private Sub lstColumns_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lstColumns.ItemCheck

        Select Case e.Index
            Case 0
                Folder.folder.ShowCreatedDate = e.NewValue = CheckState.Checked
            Case 1
                Folder.folder.ShowModifiedDate = e.NewValue = CheckState.Checked
            Case 2
                Folder.folder.ShowType = e.NewValue = CheckState.Checked
            Case 3
                Folder.folder.ShowKey = e.NewValue = CheckState.Checked
            Case 4
                Folder.folder.ShowPriority = e.NewValue = CheckState.Checked
        End Select

        'If lstColumns.CheckedItems.Count = 0 Then
        '    'Folder.lstContents.GroupHeadersVisible = Infragistics.Win.DefaultableBoolean.False
        '    '    Folder.lstContents.ViewSettingsDetails.SubItemColumnsVisibleByDefault = False            
        'Else
        '    'Folder.lstContents.GroupHeadersVisible = Infragistics.Win.DefaultableBoolean.True
        '    '   Folder.lstContents.ViewSettingsDetails.SubItemColumnsVisibleByDefault = True
        'End If

    End Sub



    Private Sub lstColumns_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstColumns.SelectedValueChanged        
        For i As Integer = 0 To 4
            If lstColumns.SelectedIndex = i Then lstColumns.SetSelected(i, False)
        Next
    End Sub

End Class