Imports System.ComponentModel


Public Class NumericTextbox
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        Me.New(2)
    End Sub
    Public Sub New(ByVal iMaxDecimalPlaces As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.iMaxDecimalPlaces = iMaxDecimalPlaces

        cDecimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.Chars(0)
        cGroupSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator.Chars(0)

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Private WithEvents txtNumeric As Infragistics.Win.UltraWinEditors.UltraTextEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.txtNumeric = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        CType(Me.txtNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNumeric
        '
        Appearance1.TextHAlign = Infragistics.Win.HAlign.Right
        Me.txtNumeric.Appearance = Appearance1
        Me.txtNumeric.AutoSize = False
        Me.txtNumeric.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNumeric.Location = New System.Drawing.Point(0, 0)
        Me.txtNumeric.Name = "txtNumeric"
        Me.txtNumeric.Size = New System.Drawing.Size(200, 22)
        Me.txtNumeric.TabIndex = 0
        Me.txtNumeric.Text = "0"
        '
        'NumericTextbox
        '
        Me.Controls.Add(Me.txtNumeric)
        Me.Name = "NumericTextbox"
        Me.Size = New System.Drawing.Size(200, 22)
        CType(Me.txtNumeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Shadows Event GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Shadows Event LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)


    Public Overrides ReadOnly Property Focused() As Boolean
        Get
            Return Me.txtNumeric.Focused
        End Get
    End Property


    Private Sub NumericTextbox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeric.GotFocus
        RaiseEvent GotFocus(Me, e)        ' This doesn't get called cos we do stuff below...
    End Sub

    Private Sub NumericTextbox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeric.LostFocus
        If Not Me.Focused Then RaiseEvent LostFocus(Me, e)
    End Sub


    Private iMaxDecimalPlaces As Integer
    Private iMinDecimalPlaces As Integer
    Private dNumericValue As Double
    Public MaxValue As Double = Double.MaxValue
    Public MinValue As Double = Double.MinValue
    Private cDecimalSeparator As Char
    Private cGroupSeparator As Char


    Public Event ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Shadows Event KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)


    Public Property MaxDecimalPlaces() As Integer
        Get
            Return iMaxDecimalPlaces
        End Get
        Set(ByVal Value As Integer)
            iMaxDecimalPlaces = Value
            FormatBox()
        End Set
    End Property


    Public Property MinDecimalPlaces() As Integer
        Get
            Return iMinDecimalPlaces
        End Get
        Set(ByVal Value As Integer)
            If Value < 0 Then Value = 0
            If Value > iMaxDecimalPlaces Then Throw New Exception("MinDecimalPlaces cannot be greater than MaxDecimalPlaces")
            iMinDecimalPlaces = Value
            FormatBox()
        End Set
    End Property

    Private Sub txtNumeric_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeric.KeyDown
        RaiseEvent KeyDown(Me, e) ' Re-raise event, so outside can deal with
    End Sub


    Private Sub txtNumeric_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeric.KeyPress

        Select Case e.KeyChar
            Case "0"c To "9"c
                If txtNumeric.SelectionStart = txtNumeric.Text.Length AndAlso txtNumeric.Text.Length > iMaxDecimalPlaces AndAlso txtNumeric.Text.Substring(txtNumeric.Text.Length - (iMaxDecimalPlaces + 1), 1) = cDecimalSeparator Then
                    e.Handled = True ' Don't let user type if they're trying to add too many decimal places
                End If
                ' Allow
            Case cDecimalSeparator
                If iMaxDecimalPlaces > 0 AndAlso sInstr(txtNumeric.Text, cDecimalSeparator) = 0 Then
                    ' Allow
                Else
                    e.Handled = True
                End If
            Case "M"c, "m"c
                Value *= 1000000
                e.Handled = True
            Case "K"c, "k"c
                Value *= 1000
                e.Handled = True
            Case "+"c
                Value += 1000
                e.Handled = True
            Case "-"c
                If Me.MaxValue >= 0 Then
                    e.Handled = True
                Else
                    If txtNumeric.Text = "0" OrElse txtNumeric.Text = ("0" & cDecimalSeparator).PadRight(Me.iMaxDecimalPlaces + 2, "0"c) Then
                        ' Allow, as they're presumably starting to type a negative number
                    Else
                        Value = -Value
                        e.Handled = True
                    End If
                End If
            Case Chr(8)
                ' Allow
            Case Else
                e.Handled = True
                Debug.WriteLine(e.KeyChar)                
        End Select

    End Sub


    Public Property Value() As Double
        Get
            Value = dNumericValue
        End Get
        Set(ByVal dValue As Double)
            dNumericValue = Math.Max(Math.Min(dValue, MaxValue), MinValue)
            FormatBox()
        End Set
    End Property


    Public Shadows Sub Focus()
        Me.txtNumeric.Focus()
    End Sub


    Private Sub FormatBox()

                Dim sFormat As String = "#,##0" ' This is interpreted into correct format by Culture Info
        Dim iFromRight As Integer
        If txtNumeric.IsInEditMode Then iFromRight = Len(txtNumeric.Text) - txtNumeric.SelectionStart

        If iMaxDecimalPlaces > 0 Then
            If txtNumeric.IsInEditMode Then
                sFormat &= ".".PadRight(iMaxDecimalPlaces + 1, "#"c)
            Else
                sFormat &= ".".PadRight(iMinDecimalPlaces + 1, "0"c).PadRight(iMaxDecimalPlaces + 1, "#"c)
            End If
        End If

        Dim bSkipFormat As Boolean = False
        If txtNumeric.IsInEditMode Then
            For i As Integer = 0 To iMaxDecimalPlaces - 1
                If txtNumeric.Text.Contains(cDecimalSeparator) AndAlso iFromRight = 0 AndAlso (sRight(txtNumeric.Text, 1) = "0" OrElse sRight(txtNumeric.Text, 1) = cDecimalSeparator) Then
                    'If sRight(txtNumeric.Text, i + 1) = ".".PadRight(i + 1, "0"c) AndAlso iFromRight = 0 Then
                    'If sRight(txtNumeric.Text, i + 1) = cDecimalSeparator.ToString.PadRight(i + 1, "0"c) AndAlso iFromRight = 0 Then
                    bSkipFormat = True
                    Exit For
                End If
            Next
        End If
        If Not bSkipFormat AndAlso txtNumeric.Text <> "-" Then  ' Format function removes trailing dot if no numerics after it
            txtNumeric.Text = Format(Value, sFormat)
        End If

        If txtNumeric.IsInEditMode Then txtNumeric.SelectionStart = Len(txtNumeric.Text) - iFromRight

    End Sub


    Private Sub txtNumeric_AfterEnterEditMode(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeric.AfterEnterEditMode

        txtNumeric.SelectionStart = 0
        txtNumeric.SelectionLength = txtNumeric.Text.Length
        RaiseEvent GotFocus(Me, Nothing)

    End Sub


    Private Sub txtNumeric_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeric.TextChanged

        Value = Val(txtNumeric.Text.Replace(cGroupSeparator, "").Replace(cDecimalSeparator, "."))        
        FormatBox()

        If txtNumeric.IsInEditMode AndAlso (txtNumeric.Text = "0" OrElse txtNumeric.Text = ("0" & cDecimalSeparator).PadRight(Me.iMaxDecimalPlaces + 2, "0"c)) Then            
            txtNumeric.SelectionStart = 0
            txtNumeric.SelectionLength = txtNumeric.Text.Length
        End If

        RaiseEvent ValueChanged(sender, e)

    End Sub

    Private Sub NumericTextbox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        txtNumeric.Size = Me.Size
    End Sub

    Private Sub NumericTextbox_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ForeColorChanged
        txtNumeric.ForeColor = Me.ForeColor
    End Sub

    Private Sub txtNumeric_AfterExitEditMode(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeric.AfterExitEditMode
        FormatBox()
        If Not Me.Focused Then RaiseEvent LostFocus(Me, e)
    End Sub

    ' Hide the Text property
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), Obsolete("Text Property not in use", True)> _
    Public Overrides Property Text() As String
        Get
            Return Nothing
        End Get
        Set(ByVal Value As String)
            Value = Nothing
        End Set
    End Property

    Public Overrides Property BackColor() As System.Drawing.Color
        Get
            Return Me.txtNumeric.Appearance.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)            
            Me.txtNumeric.Appearance.BackColor = value
        End Set
    End Property

End Class