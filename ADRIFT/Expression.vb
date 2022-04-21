Public Class Expression

    Public Event ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Property Value() As String
        Get
            Return txtExpression.Text
        End Get
        Set(ByVal value As String)
            txtExpression.Text = value
            If value = "" Then
                btnEdit.Appearance.Image = My.Resources.Resources.imgAdd16
            Else
                btnEdit.Appearance.Image = My.Resources.Resources.imgEdit16
            End If
        End Set
    End Property


    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        MessageBox.Show("TODO: Expression Builder" & vbCrLf & vbCrLf _
               & "Some supported functions are: ABS(), EITHER(), IF(), sInstr(), LCASE(), LEFT(), LEN(), MAX(), MIN(), MOD(), sMid(), PCASE(), RAND(), RIGHT(), STR(), UCASE(), VAL()" & vbCrLf & vbCrLf _
               & "For example: IF(%variable1% = 1, %variable2% + 1, RAND(5, 7))", "Expression Builder", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Sub txtExpression_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExpression.TextChanged
        RaiseEvent ValueChanged(sender, e)
    End Sub


    ' Does this expression return a String or an Integer value?
    Public ReadOnly Property DataTypeOfExpression() As clsVariable.VariableTypeEnum
        Get
            Try
                If Trim(txtExpression.Text) = "" Then Return CType(-1, clsVariable.VariableTypeEnum)

                Dim var As New clsVariable
                var.SetToExpression(Trim(txtExpression.Text), , True)

                If (var.IntValue <> Integer.MinValue AndAlso var.IntValue <> 0) OrElse IsNumeric(var.StringValue) Then
                    Return clsVariable.VariableTypeEnum.Numeric
                Else
                    If Trim(txtExpression.Text) = "0" Then Return clsVariable.VariableTypeEnum.Numeric
                    Return clsVariable.VariableTypeEnum.Text
                End If
            Catch ex As Exception
                ' Bad expression
                Return CType(-1, clsVariable.VariableTypeEnum)
            End Try
        End Get
    End Property

End Class
