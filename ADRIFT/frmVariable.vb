Public Class frmVariable
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public bKeepOpen As Boolean = False

    Public Sub New(ByRef var As clsVariable, ByVal bShow As Boolean)
        MyBase.New()

        ' Check that this window isn't already open
        For Each w As Form In OpenForms
            If TypeOf w Is frmVariable Then
                If CType(w, frmVariable).cVariable.Key = var.Key AndAlso var.Key IsNot Nothing Then
                    w.BringToFront()
                    w.Focus()
                    Exit Sub
                End If
            End If
        Next

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Application.EnableVisualStyles()
        LoadForm(var, bShow)
        bKeepOpen = Not bShow

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
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents btnApply As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents optInteger As System.Windows.Forms.RadioButton
    Friend WithEvents grpType As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents optText As System.Windows.Forms.RadioButton
    Friend WithEvents txtNumericValue As System.Windows.Forms.TextBox
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents txtLength As System.Windows.Forms.TextBox
    Friend WithEvents lblLength As System.Windows.Forms.Label
    Friend WithEvents chkArray As System.Windows.Forms.CheckBox
    Friend WithEvents txtTextValue As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVariable))
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.btnApply = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.grpType = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lblLength = New System.Windows.Forms.Label()
        Me.txtLength = New System.Windows.Forms.TextBox()
        Me.optText = New System.Windows.Forms.RadioButton()
        Me.optInteger = New System.Windows.Forms.RadioButton()
        Me.chkArray = New System.Windows.Forms.CheckBox()
        Me.txtNumericValue = New System.Windows.Forms.TextBox()
        Me.txtTextValue = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblValue = New System.Windows.Forms.Label()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpType.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 325)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        Me.UltraStatusBar1.Size = New System.Drawing.Size(315, 48)
        Me.UltraStatusBar1.TabIndex = 5
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(211, 335)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(88, 32)
        Me.btnApply.TabIndex = 14
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(115, 335)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(19, 335)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "OK"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HelpProvider1.SetHelpString(Me.txtName, "This is the name you want to refer to your variable as.  If you call it ""HitCount" & _
        """, you would refer to it as %HitCount% within text boxes.")
        Me.txtName.Location = New System.Drawing.Point(62, 17)
        Me.txtName.Name = "txtName"
        Me.HelpProvider1.SetShowHelp(Me.txtName, True)
        Me.txtName.Size = New System.Drawing.Size(237, 20)
        Me.txtName.TabIndex = 16
        '
        'grpType
        '
        Me.grpType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpType.Controls.Add(Me.lblLength)
        Me.grpType.Controls.Add(Me.txtLength)
        Me.grpType.Controls.Add(Me.optText)
        Me.grpType.Controls.Add(Me.optInteger)
        Me.grpType.Controls.Add(Me.chkArray)
        Me.HelpProvider1.SetHelpString(Me.grpType, "Select whether you want your variable to store numbers, or text")
        Me.grpType.Location = New System.Drawing.Point(19, 51)
        Me.grpType.Name = "grpType"
        Me.HelpProvider1.SetShowHelp(Me.grpType, True)
        Me.grpType.Size = New System.Drawing.Size(280, 89)
        Me.grpType.TabIndex = 18
        Me.grpType.Text = "Variable Type"
        Me.grpType.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'lblLength
        '
        Me.lblLength.AutoSize = True
        Me.lblLength.BackColor = System.Drawing.Color.Transparent
        Me.lblLength.Enabled = False
        Me.lblLength.Location = New System.Drawing.Point(127, 57)
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(63, 13)
        Me.lblLength.TabIndex = 16
        Me.lblLength.Text = "... of length:"
        '
        'txtLength
        '
        Me.txtLength.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLength.Enabled = False
        Me.HelpProvider1.SetHelpString(Me.txtLength, "This is the length of the array (the number of unique values stored in the array)" & _
        "")
        Me.txtLength.Location = New System.Drawing.Point(192, 54)
        Me.txtLength.Name = "txtLength"
        Me.HelpProvider1.SetShowHelp(Me.txtLength, True)
        Me.txtLength.Size = New System.Drawing.Size(56, 20)
        Me.txtLength.TabIndex = 22
        Me.txtLength.Text = "0"
        Me.txtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'optText
        '
        Me.optText.AutoSize = True
        Me.optText.BackColor = System.Drawing.Color.Transparent
        Me.optText.Location = New System.Drawing.Point(20, 53)
        Me.optText.Name = "optText"
        Me.optText.Size = New System.Drawing.Size(46, 17)
        Me.optText.TabIndex = 18
        Me.optText.Text = "&Text"
        Me.optText.UseVisualStyleBackColor = False
        '
        'optInteger
        '
        Me.optInteger.AutoSize = True
        Me.optInteger.BackColor = System.Drawing.Color.Transparent
        Me.optInteger.Checked = True
        Me.optInteger.Location = New System.Drawing.Point(20, 30)
        Me.optInteger.Name = "optInteger"
        Me.optInteger.Size = New System.Drawing.Size(62, 17)
        Me.optInteger.TabIndex = 17
        Me.optInteger.TabStop = True
        Me.optInteger.Text = "&Number"
        Me.optInteger.UseVisualStyleBackColor = False
        '
        'chkArray
        '
        Me.chkArray.AutoSize = True
        Me.chkArray.BackColor = System.Drawing.Color.Transparent
        Me.HelpProvider1.SetHelpString(Me.chkArray, "Check this checkbox to define the variable as an array (a list of variables, each" & _
        " with their own value)")
        Me.chkArray.Location = New System.Drawing.Point(115, 31)
        Me.chkArray.Name = "chkArray"
        Me.HelpProvider1.SetShowHelp(Me.chkArray, True)
        Me.chkArray.Size = New System.Drawing.Size(116, 17)
        Me.chkArray.TabIndex = 0
        Me.chkArray.Text = "Variable is an &Array"
        Me.chkArray.UseVisualStyleBackColor = False
        '
        'txtNumericValue
        '
        Me.txtNumericValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumericValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProvider1.SetHelpString(Me.txtNumericValue, resources.GetString("txtNumericValue.HelpString"))
        Me.txtNumericValue.Location = New System.Drawing.Point(91, 149)
        Me.txtNumericValue.Name = "txtNumericValue"
        Me.HelpProvider1.SetShowHelp(Me.txtNumericValue, True)
        Me.txtNumericValue.Size = New System.Drawing.Size(208, 22)
        Me.txtNumericValue.TabIndex = 20
        Me.txtNumericValue.Text = "0"
        Me.txtNumericValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTextValue
        '
        Me.txtTextValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTextValue.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProvider1.SetHelpString(Me.txtTextValue, resources.GetString("txtTextValue.HelpString"))
        Me.txtTextValue.Location = New System.Drawing.Point(21, 173)
        Me.txtTextValue.Multiline = True
        Me.txtTextValue.Name = "txtTextValue"
        Me.txtTextValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.HelpProvider1.SetShowHelp(Me.txtTextValue, True)
        Me.txtTextValue.Size = New System.Drawing.Size(278, 142)
        Me.txtTextValue.TabIndex = 22
        Me.txtTextValue.Text = "Blah blah..."
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(18, 20)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(38, 13)
        Me.lblName.TabIndex = 15
        Me.lblName.Text = "&Name:"
        '
        'lblValue
        '
        Me.lblValue.Location = New System.Drawing.Point(18, 153)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(80, 17)
        Me.lblValue.TabIndex = 19
        Me.lblValue.Text = "Initial &Value:"
        '
        'frmVariable
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(315, 373)
        Me.Controls.Add(Me.txtTextValue)
        Me.Controls.Add(Me.txtNumericValue)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.grpType)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVariable"
        Me.ShowInTaskbar = False
        Me.Text = "Variable -"
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpType.ResumeLayout(False)
        Me.grpType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private cVariable As clsVariable
    Private bChanged As Boolean
    Private iSelectedIndex As Integer = -1
    Private bUpdating As Boolean = False


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


    Private Sub LoadForm(ByRef cVariable As clsVariable, ByVal bShow As Boolean)

        Me.cVariable = cVariable

        Dim iHeight As Integer

        With cVariable
            Text = "Variable - " & .Name
            If SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0")) Then Text &= "  [" & .Key & "]"
            If .Name = "" Then Text = "New Variable"

            txtName.Text = .Name

            If .Type = clsVariable.VariableTypeEnum.Numeric Then
                optInteger.Checked = True
                If .Length > 1 AndAlso .StringValue.Length > 0 Then
                    txtTextValue.Text = .StringValue.Replace(", ", vbCrLf)
                Else
                    txtNumericValue.Text = .IntValue.ToString
                    txtTextValue.Text = ""
                End If                
                iHeight = 370
            Else
                optText.Checked = True
                txtTextValue.Text = .StringValue
                iHeight = 435
            End If

            If .Length > 1 Then
                txtLength.Text = .Length.ToString
                txtLength.Enabled = True
                lblLength.Enabled = True
                bUpdating = True
                chkArray.Checked = True
                bUpdating = False
            Else
                txtLength.Text = "1"
                txtLength.Enabled = False
                lblLength.Enabled = False
                chkArray.Checked = False
            End If

            Changed = False

            If .Key = "Score" OrElse .Key = "MaxScore" Then
                grpType.Enabled = False
            End If
        End With

        If bShow Then Me.Show()
        Me.Height = iHeight

        OpenForms.Add(Me)

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If ApplyVariable() Then
            CloseVariable(Me)
        End If
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If ApplyVariable() Then
            Changed = False
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then
                If Not ApplyVariable() Then Exit Sub
            End If
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        CloseVariable(Me)
    End Sub


    Private Function ApplyVariable() As Boolean

        ' remember to strip off the unselected properties

        With cVariable

            .Name = txtName.Text.Replace(" ", "")
            If .Name = "" Then .Name = "UnnamedVariable"
            .LastUpdated = Now
            .IsLibrary = False

            If chkArray.Checked Then
                .Length = CInt(Val(txtLength.Text))
            Else
                .Length = 1
            End If

            If Me.optInteger.Checked Then
                .Type = clsVariable.VariableTypeEnum.Numeric
                If chkArray.Checked Then
                    If Int(Val(txtLength.Text)) < 2 Then
                        ErrMsg("Arrays must be at least 2 in length")
                        Return False
                    End If
                    'If sInstr(txtNumericValue.Text, ",") > 0 Then
                    '    ' Each array entry set to it's own value separated by a comma
                    '    If InstrCount(txtNumericValue.Text, ",") = CInt(Val(txtLength.Text)) - 1 Then
                    '        .StringValue = txtNumericValue.Text
                    '        .IntValue = 0
                    '    Else
                    '        ErrMsg("You have not defined a value for each array entry")
                    '        Return False
                    '    End If
                    'Else
                    '    ' All array entries set to same value
                    '    .IntValue = CInt(Val(txtNumericValue.Text))
                    '    .StringValue = ""
                    'End If                    
                    .StringValue = txtTextValue.Text.Replace(vbCrLf, ", ")
                    While .StringValue.EndsWith(", ")
                        .StringValue = sLeft(.StringValue, .StringValue.Length - 2)
                    End While
                    While .StringValue.Contains(", , ")
                        .StringValue = .StringValue.Replace(", , ", ", ")
                    End While
                Else
                    .IntValue = CInt(Val(txtNumericValue.Text))
                    .StringValue = ""
                End If
            Else
                .Type = clsVariable.VariableTypeEnum.Text
                .StringValue = txtTextValue.Text
            End If

            If .Key = "" Then
                .Key = .GetNewKey ' Adventure.GetNewKey("Variable")
                Adventure.htblVariables.Add(cVariable, .Key)
            End If

            UpdateListItem(.Key, .Name)

            If .Key = "MaxScore" Then Adventure.MaxScore = .IntValue

        End With

        Adventure.Changed = True
        Return True

    End Function


    Private Sub frmVariable_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OpenForms.Remove(Me)
    End Sub

   

    Private Sub frmVariable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = Icon.FromHandle(My.Resources.imgVariable16.GetHicon)
        GetFormPosition(Me)
    End Sub


    Private Sub optInteger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optInteger.CheckedChanged

        If optInteger.Checked Then            
            If Not chkArray.Checked Then
                Height = 271
                MinimumSize = New Size(331, 271)
                MaximumSize = New Size(400, 271)
                txtNumericValue.Text = SafeInt(txtTextValue.Text).ToString
                txtNumericValue.Visible = True
                txtTextValue.Visible = False
            Else
                If Height < 435 Then Height = 435
                MinimumSize = New Size(331, 400)
                MaximumSize = New Size(800, 800)
                Dim sNewText As String = ""
                For Each sVal As String In txtTextValue.Text.Split(Chr(10))
                    sNewText &= SafeInt(sVal) & vbCrLf
                Next
                txtTextValue.Text = sLeft(sNewText, sNewText.Length - 1)
                txtTextValue.TextAlign = HorizontalAlignment.Right
                txtNumericValue.Visible = False
                txtTextValue.Visible = True
            End If        
        End If

    End Sub


    Private Sub optText_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optText.CheckedChanged

        If optText.Checked Then
            If Height < 435 Then Height = 435
            MinimumSize = New Size(331, 400)
            MaximumSize = New Size(800, 800)
            txtTextValue.TextAlign = HorizontalAlignment.Left
            txtNumericValue.Visible = False
            txtTextValue.Visible = True
        End If

    End Sub


    Private Sub txtLength_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLength.KeyDown, txtTextValue.KeyDown

        If sender Is txtLength OrElse optInteger.Checked Then
            Select Case e.KeyCode
                Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Enter, Keys.Delete, Keys.Back, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9
                    ' Ok
                Case Else
                    e.SuppressKeyPress = True
                    e.Handled = True
            End Select
        End If

    End Sub



    Private Sub txtLength_Leave(sender As Object, e As System.EventArgs) Handles txtLength.Leave

        Dim iCurrentLength As Integer = CharacterCount(txtTextValue.Text, Chr(10)) + 1
        If iCurrentLength > SafeInt(txtLength.Text) Then
            Dim iOffset As Integer = 0
            For i As Integer = 0 To SafeInt(txtLength.Text) - 1
                iOffset = txtTextValue.Text.IndexOf(vbCrLf, iOffset + 1)
            Next
            txtTextValue.Text = sLeft(txtTextValue.Text, iOffset)
        End If

    End Sub


    Private Sub txtLength_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLength.TextChanged

        If bUpdating Then Exit Sub

        Dim iCurrentLength As Integer = CharacterCount(txtTextValue.Text, Chr(10)) + 1
        If iCurrentLength < SafeInt(txtLength.Text) Then
            Dim sInitialValue As String = ""
            If optInteger.Checked AndAlso txtTextValue.Text = "" Then
                sInitialValue = "0"
            Else
                sInitialValue = txtTextValue.Text
                If sInitialValue.Contains(vbCrLf) Then
                    sInitialValue = sLeft(sInitialValue, sInitialValue.IndexOf(vbCrLf))
                End If
            End If
            For i As Integer = iCurrentLength To SafeInt(txtLength.Text) - 1
                txtTextValue.Text &= vbCrLf & sInitialValue
            Next
        End If

    End Sub


    Private Sub txtName_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Space Then e.SuppressKeyPress = True        
    End Sub


    Private Sub Stuff_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLength.TextChanged, txtName.TextChanged, txtName.TextChanged, optInteger.CheckedChanged, optText.CheckedChanged, txtNumericValue.TextChanged
        Changed = True
    End Sub


    Private Sub chkArray_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkArray.CheckedChanged

        If chkArray.Checked Then
            lblLength.Enabled = True
            txtLength.Enabled = True
            lblValue.Text = "Initial &Values:"
            txtNumericValue.Visible = False
            txtTextValue.Visible = True
            Dim sInitialValue As String
            If optInteger.Checked Then
                txtTextValue.TextAlign = HorizontalAlignment.Right
                sInitialValue = txtNumericValue.Text
            Else
                txtTextValue.TextAlign = HorizontalAlignment.Left
                sInitialValue = txtTextValue.Text.Replace(vbCrLf, "<br>")
            End If
            If Height < 435 Then Height = 435
            MinimumSize = New Size(331, 400)
            MaximumSize = New Size(800, 800)
            If Not bUpdating Then
                If CharacterCount(txtTextValue.Text, Chr(10)) - 1 <> SafeInt(txtLength.Text) Then
                    txtTextValue.Text = ""
                    For i As Integer = 0 To SafeInt(txtLength.Text) - 2
                        txtTextValue.Text &= sInitialValue & vbCrLf
                    Next
                    txtTextValue.Text &= sInitialValue
                End If
            End If
        Else
            lblLength.Enabled = False
            txtLength.Enabled = False
            lblValue.Text = "Initial &Value:"
            txtTextValue.TextAlign = HorizontalAlignment.Left
            Dim sInitialValue As String = txtTextValue.Text
            If sInitialValue.Contains(vbCrLf) Then
                sInitialValue = sLeft(sInitialValue, sInitialValue.IndexOf(vbCrLf))
            End If
            txtTextValue.Text = sInitialValue.Replace("<br>", vbCrLf)
            txtNumericValue.Text = SafeInt(sInitialValue).ToString
            If optInteger.Checked Then
                Height = 271
                MinimumSize = New Size(331, 271)
                MaximumSize = New Size(400, 271)
                txtNumericValue.Visible = True
                txtTextValue.Visible = False
            End If
        End If
        Changed = True

    End Sub

    Private Sub frmVariable_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If txtName.Text = "" Then
            txtName.Focus()
        Else
            If txtNumericValue.Visible Then
                txtNumericValue.Focus()
            ElseIf txtTextValue.Visible Then
                txtTextValue.SelectionStart = txtTextValue.TextLength
                txtTextValue.Focus()
            End If
        End If
    End Sub


    Private Sub txtTextValue_GotFocus(sender As Object, e As System.EventArgs) Handles txtTextValue.GotFocus
        Me.AcceptButton = Nothing
    End Sub

    Private Sub txtTextValue_LostFocus(sender As Object, e As System.EventArgs) Handles txtTextValue.LostFocus
        Me.AcceptButton = btnOK
    End Sub

    Private Sub txtTextValue_TextChanged(sender As Object, e As System.EventArgs) Handles txtTextValue.TextChanged

        If chkArray.Checked Then
            Dim iCount As Integer = 0
            For Each sVal As String In txtTextValue.Text.Split(Chr(10))
                If optText.Checked OrElse sVal.Replace(Chr(13), "") <> "" Then iCount += 1
            Next
            txtLength.Text = iCount.ToString ' (CharacterCount(txtTextValue.Text, Chr(10)) + 1).ToString
            'If optInteger.Checked AndAlso txtTextValue.Text.EndsWith(Chr(10)) Then txtLength.Text = (CharacterCount(txtTextValue.Text, Chr(10))).ToString
        End If

    End Sub

    Private Sub frmVariable_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        ShowHelp(Me, "Variables")
    End Sub

End Class
