Public Class ExpandableDescription

    Public Event Changed(ByVal sender As Object, ByVal e As System.EventArgs)

    'Private Sub btnDropdown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDropdown.Click
    '    If GenTextbox1.tabsDescriptions.SelectedTab IsNot Nothing AndAlso GenTextbox1.tabsDescriptions.SelectedTab.VisibleIndex = 0 AndAlso txtShortDesc.IsInEditMode Then
    '        GenTextbox1.rtxtSource.SelectionStart = txtShortDesc.SelectionStart
    '        GenTextbox1.rtxtSource.SelectionLength = txtShortDesc.SelectionLength
    '    Else
    '        GenTextbox1.rtxtSource.SelectionStart = GenTextbox1.rtxtSource.TextLength
    '    End If
    '    UltraPopupControlContainer1.PopupControl.Width = txtShortDesc.Width
    '    Me.UltraPopupControlContainer1.Show(Me, PointToScreen(New Point(0, 0)))
    '    GenTextbox1.Focus()      
    'End Sub


    Private Sub txtShortDesc_EditorButtonClick(sender As Object, e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles txtShortDesc.EditorButtonClick
        If GenTextbox1.tabsDescriptions.SelectedTab IsNot Nothing AndAlso GenTextbox1.tabsDescriptions.SelectedTab.VisibleIndex = 0 AndAlso txtShortDesc.IsInEditMode Then
            GenTextbox1.rtxtSource.SelectionStart = txtShortDesc.SelectionStart
            GenTextbox1.rtxtSource.SelectionLength = txtShortDesc.SelectionLength
        Else
            GenTextbox1.rtxtSource.SelectionStart = GenTextbox1.rtxtSource.TextLength
        End If
        UltraPopupControlContainer1.PopupControl.Width = txtShortDesc.Width - txtShortDesc.ButtonsRight(0).WidthResolved - 3
        Me.UltraPopupControlContainer1.Show(Me, PointToScreen(New Point(0, 0)))
        GenTextbox1.Focus()
    End Sub


    Public Overrides Property Text() As String
        Get
            Return txtShortDesc.Text
        End Get
        Set(ByVal value As String)
            txtShortDesc.Text = value
        End Set
    End Property


    Friend Property Description() As Description
        Get
            Return GenTextbox1.Description
        End Get
        Set(ByVal value As Description)
            GenTextbox1.Description = value
            If value.Count > 0 Then
                txtShortDesc.Text = value.Item(0).Description
            Else
                txtShortDesc.Text = ""
            End If
        End Set
    End Property



    Private Sub txtShortDesc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShortDesc.TextChanged        
        Description.Item(0).Description = txtShortDesc.Text
        If GenTextbox1.tabsDescriptions.SelectedTab IsNot Nothing AndAlso GenTextbox1.tabsDescriptions.SelectedTab.VisibleIndex = 0 Then
            GenTextbox1.rtxtSource.Text = txtShortDesc.Text
        End If
        RaiseEvent Changed(Me, e)
    End Sub


    Private Sub UltraPopupControlContainer1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraPopupControlContainer1.Closed
        txtShortDesc.Text = Description.Item(0).Description        
        txtShortDesc.Focus()
        txtShortDesc.SelectionStart = txtShortDesc.TextLength
    End Sub


    Private Sub ExpandableDescription_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GenTextbox1.Tabs.Tabs("tabGraphics").Visible = False
        GenTextbox1.Visible = False
    End Sub


    Private Sub GenTextbox1_Changed(sender As Object, e As EventArgs) Handles GenTextbox1.Changed
        RaiseEvent Changed(Me, e)
    End Sub

End Class
