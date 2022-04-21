Public Class frmUserFunction

    Private bChanged As Boolean
    Private cUDF As clsUserFunction


    Public Sub New(ByVal UDF As clsUserFunction)
        MyBase.New()

        ' Check that this window isn't already open
        For Each w As Form In OpenForms
            If TypeOf w Is frmUserFunction Then
                If CType(w, frmUserFunction).cUDF.Key = UDF.Key AndAlso UDF.Key IsNot Nothing Then
                    w.BringToFront()
                    w.Focus()
                    Exit Sub
                End If
            End If
        Next

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoadForm(UDF)

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

    Private Sub LoadForm(ByRef cUDF As clsUserFunction)

        Me.cUDF = cUDF

        With colType
            For Each typ As clsUserFunction.ArgumentType In [Enum].GetValues(GetType(clsUserFunction.ArgumentType))
                .ValueList.ValueListItems.Add(CInt(typ), typ.ToString)
            Next
            txtOutput.Arguments = cUDF.Arguments
        End With

        With cUDF
            Text = "User Function"
            If SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0")) Then Text &= " [" & .Key & "]"
            If .Name = "" Then Text = "New User Function"

            txtName.Text = .Name
            txtOutput.Description = .Output.Copy

            For Each arg As clsUserFunction.Argument In .Arguments
                grdArguments.Rows.Add(New Object() {arg.Name, CInt(arg.Type)})
            Next

        End With

        SetArgs()

        Me.Show()
        Changed = False

        OpenForms.Add(Me)

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ApplyUDF()
        CloseUDF(Me)
    End Sub


    Private Sub ApplyUDF()

        With cUDF
            .Name = txtName.Text
            .Output = txtOutput.Description.Copy

            .Arguments.Clear()
            For Each row As DataGridViewRow In grdArguments.Rows
                Dim arg As New clsUserFunction.Argument
                If row.Cells("colName").Value IsNot Nothing Then
                    arg.Name = row.Cells("colName").Value.ToString
                    arg.Type = CType([Enum].Parse(GetType(clsUserFunction.ArgumentType), row.Cells("colType").Value.ToString), clsUserFunction.ArgumentType)
                    .Arguments.Add(arg)
                End If                
            Next

            If .Key = "" Then
                .Key = .GetNewKey
                Adventure.htblUDFs.Add(cUDF, .Key)
            End If
            .LastUpdated = Now
            .IsLibrary = False

            UpdateListItem(.Key, .Name)
        End With

        Adventure.Changed = True

    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then ApplyUDF()
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        CloseUDF(Me)

    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ApplyUDF()
        Changed = False
    End Sub

    Private Sub StuffChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged, txtOutput.Changed
        Changed = True
    End Sub


    Private Sub frmTextOverride_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OpenForms.Remove(Me)
    End Sub


    Private Sub frmHint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = Icon.FromHandle(My.Resources.Resources.imgFunction16.GetHicon)
        GetFormPosition(Me)
    End Sub


    Private Sub frmTextOverride_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If txtName.Text = "" Then
            txtName.Focus()
        Else            
            txtOutput.rtxtSource.EditInfo.PerformAction(Infragistics.Win.FormattedLinkLabel.FormattedLinkEditorAction.DocumentEnd)
            txtOutput.rtxtSource.Focus()
        End If
    End Sub

    Private Sub frmTextOverride_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        ShowHelp(Me, "UserDefinedFunctions")
    End Sub

    Private Sub grdArguments_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdArguments.CellValueChanged
        SetArgs()
    End Sub


    Private Sub SetArgs()
        With txtOutput
            .Arguments = New List(Of clsUserFunction.Argument)
            For Each row As DataGridViewRow In grdArguments.Rows
                Dim arg As New clsUserFunction.Argument
                If row.Cells(0).Value IsNot Nothing Then
                    arg.Name = row.Cells("colName").Value.ToString
                    If row.Cells("colType").Value IsNot DBNull.Value Then arg.Type = CType([Enum].Parse(GetType(clsUserFunction.ArgumentType), row.Cells("colType").Value.ToString), clsUserFunction.ArgumentType)
                    .Arguments.Add(arg)
                End If
            Next
            .rtxtSource.Arguments = .Arguments
        End With
    End Sub

End Class