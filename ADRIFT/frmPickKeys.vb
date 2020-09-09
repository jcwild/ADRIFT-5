Imports Infragistics.Win
Imports Infragistics.Win.UltraWinListView

Public Class frmPickKeys
    Inherits System.Windows.Forms.Form
    Implements Infragistics.Win.IUIElementDrawFilter

    Private P As Point
    Private bMultiple As Boolean
    Private bLoaded As Boolean = False
    Private bChanging As Boolean = False

#Region " Windows Form Designer generated code "

    Friend Sub New(ByVal P As Point, ByVal Multiple As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.P = P
        Me.bMultiple = Multiple

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lvwKeys As MyListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lvwKeys = New ADRIFT.frmPickKeys.MyListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.lvwKeys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvwKeys
        '
        Me.lvwKeys.AllowDrop = True
        Me.lvwKeys.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwKeys.Filter = Nothing
        Me.lvwKeys.MainColumn.Sorting = Sorting.Ascending
        Me.lvwKeys.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance1.BorderColor = System.Drawing.Color.Red
        Me.lvwKeys.ItemSettings.Appearance = Appearance1
        Me.lvwKeys.ItemSettings.HideSelection = False
        Me.lvwKeys.ItemSettings.HotTracking = True
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(254, Byte), Integer))
        Appearance2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(253, Byte), Integer))
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Appearance2.FontData.UnderlineAsString = "False"
        Appearance2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lvwKeys.ItemSettings.HotTrackingAppearance = Appearance2
        Me.lvwKeys.ItemSettings.LassoSelectMode = Infragistics.Win.UltraWinListView.LassoSelectMode.LeftMouseButton
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(253, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(252, Byte), Integer))
        Appearance3.BackColorDisabled = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer))
        Appearance3.BackColorDisabled2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.Color.Lime
        Appearance3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lvwKeys.ItemSettings.SelectedAppearance = Appearance3
        Me.lvwKeys.Location = New System.Drawing.Point(0, 0)
        Me.lvwKeys.MainColumn.DataType = GetType(String)
        Me.lvwKeys.Name = "lvwKeys"
        Me.lvwKeys.Size = New System.Drawing.Size(234, 98)
        Me.lvwKeys.TabIndex = 0
        Me.lvwKeys.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.Details
        Me.lvwKeys.ViewSettingsDetails.ColumnHeaderStyle = Infragistics.Win.HeaderStyle.XPThemed
        Me.lvwKeys.ViewSettingsDetails.ColumnHeadersVisible = False
        Me.lvwKeys.ViewSettingsDetails.ColumnsShowSortIndicators = False
        Me.lvwKeys.ViewSettingsDetails.FullRowSelect = True
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 184
        '
        'frmPickKeys
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(234, 98)
        Me.Controls.Add(Me.lvwKeys)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPickKeys"
        Me.ShowInTaskbar = False
        Me.Text = "PickKeys"
        CType(Me.lvwKeys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

    '    Const WM_PAINT As Integer = &HF  ' 15

    '    Select Case m.Msg
    '        Case WM_PAINT
    '            If lvwKeys.View = View.Details AndAlso lvwKeys.Columns.Count > 0 Then
    '                lvwKeys.Columns(lvwKeys.Columns.Count - 1).Width = Me.Width ' -2
    '            End If
    '    End Select

    '    MyBase.WndProc(m)

    'End Sub


    Private Sub frmPickKeys_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.LostFocus, MyBase.Deactivate
        Me.Visible = False
    End Sub

    Private Sub lvwKeys_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwKeys.ItemSelectionChanged '  .SelectedIndexChanged
        If bLoaded AndAlso Not bMultiple And Not bChanging Then Me.Visible = False
    End Sub

    Private Sub frmPickKeys_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        bLoaded = True
    End Sub

    Private Sub frmPickKeys_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged, lvwKeys.ListChanged

        If Me.Visible Then
            Me.Location = P
            If lvwKeys.Items.Count > 0 Then
                Dim scrn As Screen = Screen.FromControl(Me)
                If CInt(lvwKeys.VisibleCount * lvwKeys.ItemSizeResolved.Height) > scrn.WorkingArea.Height + scrn.Bounds.Y - Me.Top Then
                    Me.Height = scrn.WorkingArea.Height + scrn.Bounds.Y - Me.Top - 20
                    lvwKeys.MainColumn.Width = Me.Width - 20
                Else
                    Me.Height = (lvwKeys.VisibleCount * lvwKeys.ItemSizeResolved.Height) + 4 '.25)
                    lvwKeys.MainColumn.Width = Me.Width - 20
                End If
                If Me.Height > scrn.WorkingArea.Height / 2 Then Me.Height = CInt(scrn.WorkingArea.Height / 2)
            End If
        End If
    End Sub

    Public Sub AddItem(ByVal item As clsItem)

        Dim lvi As Infragistics.Win.UltraWinListView.UltraListViewItem = Folder.GetItem(item, Nothing)
        lvwKeys.Add(lvi)

    End Sub
    Public Sub AddItem(ByVal sName As String, ByVal sKey As String, ByVal img As Image)
        Dim lvi As New Infragistics.Win.UltraWinListView.UltraListViewItem(sKey)
        lvi.Value = sName
        lvi.Appearance.Image = img

        lvwKeys.Add(lvi)
    End Sub

    'Private Sub frmPickKeys_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    lvwKeys.OwnerDraw = True
    'End Sub

    Private Sub lvwKeys_ListChanging(sender As Object, e As EventArgs) Handles lvwKeys.ListChanging
        bChanging = True
    End Sub
    Private Sub lvwKeys_ListChanged(sender As Object, e As EventArgs) Handles lvwKeys.ListChanged
        bChanging = False
    End Sub

    Public Function GetPhasesToFilter(ByRef drawParams As UIElementDrawParams) As DrawPhase Implements IUIElementDrawFilter.GetPhasesToFilter
        'Throw New NotImplementedException()
        If TypeOf drawParams.Element Is Infragistics.Win.EditorWithTextDisplayTextUIElement Then
            Return DrawPhase.BeforeDrawForeground
        Else
            Return DrawPhase.None
        End If
    End Function

    Public Function DrawElement(drawPhase As DrawPhase, ByRef drawParams As UIElementDrawParams) As Boolean Implements IUIElementDrawFilter.DrawElement

        Dim el As EditorWithTextDisplayTextUIElement = CType(drawParams.Element, EditorWithTextDisplayTextUIElement)

        If el Is Nothing Then Return False

        Dim sText As String = el.Text

        If Not String.IsNullOrEmpty(lvwKeys.Filter) AndAlso sText.Contains(lvwKeys.Filter) Then

            Dim bBlack As New SolidBrush(SystemColors.MenuText)
            Dim bRed As New SolidBrush(Color.Red)
            Dim sPre As String = sText.Substring(0, sText.IndexOf(lvwKeys.Filter))
            Dim sPost As String = sText.Substring(sText.IndexOf(lvwKeys.Filter) + lvwKeys.Filter.Length)
            Dim r As Rectangle = el.RectInsidePadding ' el.Rect
            Dim iPreLength As Integer = 4

            If Not String.IsNullOrEmpty(sPre) Then
                drawParams.Graphics.DrawString(sPre, lvwKeys.Font, bBlack, New Point(r.X, r.Y + 1))
                iPreLength = CInt(drawParams.Graphics.MeasureString(sPre.Replace(" ", "."), lvwKeys.Font).Width)
            End If

            drawParams.Graphics.DrawString(lvwKeys.Filter, lvwKeys.Font, bRed, New Point(r.X + iPreLength - 4, r.Y + 1))

            If Not String.IsNullOrEmpty(sPost) Then
                Dim iFilterLen As Integer = CInt(drawParams.Graphics.MeasureString(lvwKeys.Filter.Replace(" ", "."), lvwKeys.Font).Width)
                drawParams.Graphics.DrawString(sPost, lvwKeys.Font, bBlack, New Point(r.X + iPreLength + iFilterLen - 8, r.Y + 1))
            End If

            Return True
        Else
            Return False
        End If

    End Function

    Private Sub frmPickKeys_Load(sender As Object, e As EventArgs) Handles Me.Load
        lvwKeys.DrawFilter = Me
    End Sub

    Friend Class MyListView
        Inherits Infragistics.Win.UltraWinListView.UltraListView

        Public Event ListChanging(ByVal sender As Object, ByVal e As EventArgs)
        Public Event ListChanged(ByVal sender As Object, ByVal e As EventArgs)

        Private _VisibleCount As Integer = 0
        Public ReadOnly Property VisibleCount As Integer
            Get
                If String.IsNullOrEmpty(Filter) Then
                    Return Items.Count
                Else
                    Return _VisibleCount
                End If
            End Get
        End Property

        Private _Filter As String
        Public Property Filter As String
            Get
                Return _Filter
            End Get
            Set(value As String)
                If value <> _Filter Then
                    RaiseEvent ListChanging(Me, New EventArgs)
                    Me.SuspendLayout()
                    _VisibleCount = 0
                    For Each lvi As Infragistics.Win.UltraWinListView.UltraListViewItem In Items
                        If lvi.Text.Contains(value) Then
                            If Not lvi.Visible Then lvi.Visible = True
                            _VisibleCount += 1
                        Else
                            If lvi.Visible Then lvi.Visible = False
                        End If
                    Next
                    Me.ResumeLayout()
                    _Filter = value
                    RaiseEvent ListChanged(Me, New EventArgs)
                End If
            End Set
        End Property

        Public Sub Add(ByVal lvi As Infragistics.Win.UltraWinListView.UltraListViewItem)
            Items.Add(lvi)
        End Sub

        Private Sub MyListView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

            If Not fGenerator?.AutoComplete Then Exit Sub

            Select Case e.KeyChar
                Case Convert.ToChar(Keys.Back)
                    If Filter?.Length > 0 Then Filter = Filter.Substring(0, Filter.Length - 1)
                    e.Handled = True
                Case Else
                    If IsInputChar(e.KeyChar) Then
                        Filter &= e.KeyChar
                        e.Handled = True
                    End If
            End Select
        End Sub

    End Class


    Friend Class MyListView2
        Inherits ListView

        Public Event ListChanging(ByVal sender As Object, ByVal e As EventArgs)
        Public Event ListChanged(ByVal sender As Object, ByVal e As EventArgs)

        Private _List As New List(Of ListViewItem)

        Private _Filter As String
        Public Property Filter As String
            Get
                Return _Filter
            End Get
            Set(value As String)
                If value <> _Filter Then
                    RaiseEvent ListChanging(Me, New EventArgs)
                    'For Each lvi As ListViewItem In _List

                    'Next
                    Debug.WriteLine(value)
                    Me.SuspendLayout()
                    For i As Integer = Items.Count - 1 To 0 Step -1
                        Dim lvi As ListViewItem = Items.Item(i)
                        If Not lvi.Text.Contains(value) Then
                            Items.RemoveAt(i)
                        End If
                    Next
                    Me.ResumeLayout()
                    _Filter = value
                    RaiseEvent ListChanged(Me, New EventArgs)
                End If
            End Set
        End Property

        Public Sub Add(ByVal lvi As ListViewItem)
            Items.Add(lvi)
            _List.Add(lvi)
        End Sub


        Protected Overrides Sub OnDrawItem(e As DrawListViewItemEventArgs)

            Dim bBlack As New SolidBrush(SystemColors.MenuText)
            Dim r As Rectangle = e.Item.GetBounds(ItemBoundsPortion.Label)


            If e.Item.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(SystemColors.MenuHighlight), e.Item.GetBounds(ItemBoundsPortion.Entire))
                'Dim p As New Pen(Color.Black)
                'P.DashStyle = Drawing2D.DashStyle.Dot
                'e.Graphics.DrawRectangle(p, e.Item.GetBounds(ItemBoundsPortion.Entire))
                bBlack = New SolidBrush(SystemColors.HighlightText)
            End If

            If Not String.IsNullOrEmpty(Filter) AndAlso e.Item.Text.Contains(Filter) Then

                Dim bRed As New SolidBrush(Color.Red)
                Dim sPre As String = e.Item.Text.Substring(0, e.Item.Text.IndexOf(Filter))
                Dim sPost As String = e.Item.Text.Substring(e.Item.Text.IndexOf(Filter) + Filter.Length)

                e.Graphics.DrawString(sPre, Me.Font, bBlack, r.Location)

                Dim iPreLength As Integer = CInt(e.Graphics.MeasureString(sPre.Replace(" ", "."), Me.Font).Width)
                e.Graphics.DrawString(Filter, Me.Font, bRed, New Point(r.X + iPreLength - 4, r.Y))

                If Not String.IsNullOrEmpty(sPost) Then
                    Dim iFilterLen As Integer = CInt(e.Graphics.MeasureString(Filter, Me.Font).Width)
                    e.Graphics.DrawString(sPost, Me.Font, bBlack, New Point(r.X + iPreLength + iFilterLen - 8, r.Y))
                End If

            Else
                e.Graphics.DrawString(e.Item.Text, Me.Font, bBlack, r.Location)
            End If

        End Sub



        Private Sub MyListView_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
            Select Case e.KeyCode
                Case Keys.Delete
                    If Filter.Length > 0 Then Filter = Filter.Substring(0, Filter.Length - 1)
            End Select
        End Sub

        Private Sub MyListView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

            Select Case e.KeyChar
                Case Convert.ToChar(Keys.Back)
                    If Filter?.Length > 0 Then Filter = Filter.Substring(0, Filter.Length - 1)
                Case Else
                    If IsInputChar(e.KeyChar) Then
                        Filter &= e.KeyChar
                        e.Handled = True
                    End If
            End Select
        End Sub
    End Class

End Class
