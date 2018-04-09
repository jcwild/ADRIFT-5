Public Class XtoYturns

    Public Shadows Event GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Shadows Event LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event ValueChanged()
    Private bShowRange As Boolean = False


    Public Overrides ReadOnly Property Focused() As Boolean
        Get            
            Return txtFrom.Focused OrElse txtTo.Focused OrElse btnExpand.Focused
        End Get
    End Property


    Public Property MinValue() As Integer
        Get
            If txtFrom.MinValue = Double.MinValue Then
                Return Integer.MinValue
            Else
                Return CInt(txtFrom.MinValue)
            End If
        End Get
        Set(ByVal value As Integer)
            txtFrom.MinValue = value
            txtTo.MinValue = value
        End Set
    End Property

    Public Property MaxValue() As Integer
        Get
            If txtFrom.MaxValue = Double.MaxValue Then
                Return Integer.MaxValue
            Else
                Return CInt(txtFrom.MaxValue)
            End If
        End Get
        Set(ByVal value As Integer)
            txtFrom.MaxValue = value
            txtTo.MaxValue = value
        End Set
    End Property


    Private Sub XtoYturns_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrom.GotFocus, txtTo.GotFocus
        RaiseEvent GotFocus(Me, e)
    End Sub

    Private Sub XtoYturns_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrom.LostFocus, txtTo.LostFocus
        If Not Me.Focused Then RaiseEvent LostFocus(Me, e)
    End Sub


    Public Property From() As Integer
        Get
            Return CInt(txtFrom.Value)
        End Get
        Set(ByVal value As Integer)
            txtFrom.Value = value
        End Set
    End Property

    Public Property [To]() As Integer
        Get
            'If txtTo.Visible Then
            Return CInt(txtTo.Value)
            'Else
            'Return Nothing
            'End If
        End Get
        Set(ByVal value As Integer)
            txtTo.Value = value
        End Set
    End Property

    Private Sub btnExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpand.Click

        If Not bShowRange Then
            btnExpand.Appearance.Image = My.Resources.imgVariable16
            Me.ToolTip1.SetToolTip(Me.btnExpand, "Click here to set a single value")
            lblTo.Visible = True
            txtTo.Visible = True
            bShowRange = True
        Else
            btnExpand.Appearance.Image = My.Resources.imgOneToOne
            Me.ToolTip1.SetToolTip(Me.btnExpand, "Click here to set a range of values")
            lblTo.Visible = False
            txtTo.Visible = False
            bShowRange = False
        End If
        XtoYturns_Resize(Nothing, Nothing)

    End Sub


    Private Sub XtoYturns_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        bShowRange = Not bShowRange ' Because the Click below inverts it
        btnExpand_Click(Nothing, Nothing)
    End Sub


    Private Sub XtoYturns_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If Not bShowRange Then
            txtFrom.Width = Me.Width - 23
        Else
            txtFrom.Width = CInt(Me.Width / 2) - 22
            txtTo.Width = txtFrom.Width
            If txtTo.Left + txtTo.Width < Me.Width Then txtTo.Width += 1
            lblTo.Left = txtFrom.Left + txtFrom.Width + 4
            txtTo.Left = lblTo.Left + 17
        End If

    End Sub

    Private Sub txtFrom_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrom.ValueChanged
        If txtFrom.Value > txtTo.Value OrElse Not bShowRange Then txtTo.Value = txtFrom.Value
        RaiseEvent ValueChanged()
    End Sub

    Private Sub txtTo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTo.ValueChanged
        If txtTo.Value < txtFrom.Value Then txtFrom.Value = txtTo.Value
        RaiseEvent ValueChanged()
    End Sub


    Public Sub SetValues(ByVal iFrom As Integer, ByVal iTo As Integer)
        txtFrom.Value = iFrom
        txtTo.Value = iTo

        If (iFrom = iTo) = bShowRange Then
            btnExpand_Click(Nothing, Nothing)
        End If

        'If iFrom = iTo Then

        '    '    btnExpand.Text = "+"
        '    '    XtoYturns_Resize(Nothing, Nothing)
        '    '    lblTo.Visible = False
        '    '    txtTo.Visible = False
        'Else
        '    '    btnExpand.Text = "-"
        '    '    XtoYturns_Resize(Nothing, Nothing)
        '    '    lblTo.Visible = True
        '    '    txtTo.Visible = True
        'End If

    End Sub

End Class
