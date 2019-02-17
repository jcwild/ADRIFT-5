Imports Infragistics.Win


Public Class AutoCompleteCombo
    Inherits UltraWinEditors.UltraComboEditor


    Public Sub New()
        If fGenerator?.AutoComplete Then
            Me.AutoCompleteMode = AutoCompleteMode.Suggest
            Me.AutoSuggestFilterMode = AutoSuggestFilterMode.Contains
            Me.ValueList.AutoSuggestHighlightAppearance.ForeColor = Color.Red
        Else
            Me.AutoCompleteMode = AutoCompleteMode.None
            Me.AutoSuggestFilterMode = AutoSuggestFilterMode.Default
            Me.ValueList.AutoSuggestHighlightAppearance.ForeColor = Color.Red
        End If
        Me.TextRenderingMode = TextRenderingMode.GDI
    End Sub


    Public Overrides Property DropDownStyle As DropDownStyle
        Get
            If fGenerator?.AutoComplete Then
                Return DropDownStyle.DropDown
            Else
                Return DropDownStyle.DropDownList
            End If
        End Get
        Set(value As DropDownStyle)
            MyBase.DropDownStyle = value
        End Set
    End Property



    ' Drop down the list as soon as we click into the combobox
    Private Sub AutoCompleteCombo_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        Dim combo As AutoCompleteCombo = CType(sender, AutoCompleteCombo)
        Dim element As UIElement = combo.UIElement.LastElementEntered
        Dim editorWithTextUIElement As UIElement = element.GetAncestor(GetType(EditorWithTextUIElement))

        If editorWithTextUIElement IsNot Nothing Then combo.DropDown()
    End Sub
End Class
