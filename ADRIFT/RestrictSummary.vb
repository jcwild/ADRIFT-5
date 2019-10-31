Public Class RestrictSummary
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents btnEdit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnAdd As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmbRestrictions As Infragistics.Win.UltraWinEditors.UltraComboEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.cmbRestrictions = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.btnEdit = New Infragistics.Win.Misc.UltraButton
        Me.btnAdd = New Infragistics.Win.Misc.UltraButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.cmbRestrictions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraPopupControlContainer1
        '
        Me.UltraPopupControlContainer1.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        '
        'cmbRestrictions
        '
        Me.cmbRestrictions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRestrictions.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbRestrictions.Location = New System.Drawing.Point(0, 0)
        Me.cmbRestrictions.Name = "cmbRestrictions"
        Me.cmbRestrictions.Size = New System.Drawing.Size(200, 21)
        Me.cmbRestrictions.TabIndex = 2
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.Image = Global.ADRIFT.My.Resources.imgEdit16
        Me.btnEdit.Appearance = Appearance3
        Me.btnEdit.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Borderless
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnEdit.Location = New System.Drawing.Point(198, -1)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(21, 22)
        Me.btnEdit.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btnEdit, "Edit restrictions")
        Me.btnEdit.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.Image = Global.ADRIFT.My.Resources.imgAdd16
        Me.btnAdd.Appearance = Appearance4
        Me.btnAdd.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Borderless
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnAdd.Location = New System.Drawing.Point(198, -1)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(21, 22)
        Me.btnAdd.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.btnAdd, "Add a new restriction")
        Me.btnAdd.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'RestrictSummary
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.cmbRestrictions)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Name = "RestrictSummary"
        Me.Size = New System.Drawing.Size(218, 21)
        CType(Me.cmbRestrictions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Event RestrictionsChanged()

    Friend Property Arguments As List(Of clsUserFunction.Argument)
    Friend arlRestrictions As New RestrictionArrayList
    Public sCommand As String

    Friend Sub LoadRestrictions(ByVal arlRest As RestrictionArrayList)
        Me.arlRestrictions = arlRest

        cmbRestrictions.Items.Clear()

        If arlRestrictions.Count = 0 Then
            btnEdit.Visible = False
            btnAdd.Visible = True
            cmbRestrictions.Items.Add("<No Restrictions Defined>")
        Else
            btnEdit.Visible = True
            btnAdd.Visible = False
            For Each rest As clsRestriction In arlRestrictions
                cmbRestrictions.Items.Add(rest.Summary)
            Next
        End If
        cmbRestrictions.SelectedIndex = 0
        If arlRestrictions.Count > 1 Then
            cmbRestrictions.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always            
        Else
            cmbRestrictions.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        End If

    End Sub


    Private Function EditRestriction(ByRef rest As clsRestriction) As DialogResult

        Dim fRestriction As New frmRestriction

        'fRestriction.Restriction = rest.Copy
        fRestriction.sCommand = Me.sCommand
        fRestriction.Arguments = Me.Arguments
        fRestriction.LoadRestriction(rest.Copy)
        If AreWeOnGenTextBox() Then fRestriction.txtMessage.Enabled = False
        If fRestriction.ShowDialog = DialogResult.OK Then rest = fRestriction.Restriction

        Return fRestriction.DialogResult

    End Function


    Private Function AreWeOnGenTextBox() As Boolean        
        If Me.Parent IsNot Nothing AndAlso Me.Parent.Parent IsNot Nothing AndAlso Me.Parent.Parent.Parent IsNot Nothing AndAlso Me.Parent.Parent.Parent.Parent IsNot Nothing AndAlso Me.Parent.Parent.Parent.Parent.Parent IsNot Nothing Then
            Return TypeOf Me.Parent.Parent.Parent.Parent.Parent Is GenTextbox OrElse TypeOf Me.Parent.Parent.Parent.Parent.Parent Is GenericProperty
        End If
        Return False
    End Function

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnEdit.Click

        If arlRestrictions.Count > 0 Then
            ' Show List
            Dim fRestrictions As New frmRestrictions(arlRestrictions.Copy)
            fRestrictions.RestrictDetails1.sCommand = Me.sCommand
            fRestrictions.RestrictDetails1.Arguments = Me.Arguments
            If AreWeOnGenTextBox() Then fRestrictions.RestrictDetails1.bNoElseText = True
            fRestrictions.ShowDialog()

            If fRestrictions.DialogResult = DialogResult.OK Then
                LoadRestrictions(fRestrictions.RestrictDetails1.arlRestrictions)
                If TypeOf Me.Parent.Parent.Parent Is frmLocation Then CType(Me.Parent.Parent.Parent, frmLocation).Changed = True
            End If
        Else
            ' Just simply add a restriction
            Dim rest As New clsRestriction

            If EditRestriction(rest) = DialogResult.OK Then
                arlRestrictions.Add(rest)
                arlRestrictions.BracketSequence = "#"
                LoadRestrictions(arlRestrictions)
                If TypeOf Me.Parent.Parent.Parent Is frmLocation Then CType(Me.Parent.Parent.Parent, frmLocation).Changed = True
            End If
        End If

        If arlRestrictions.Count > 1 Then
            cmbRestrictions.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always
        Else
            cmbRestrictions.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        End If

        RaiseEvent RestrictionsChanged()

    End Sub


    'Private Sub RestrictSummary_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    '    If cmbRestrictions.Width > 300 Then cmbRestrictions.DropDownListWidth = cmbRestrictions.Width Else cmbRestrictions.DropDownListWidth = 300
    'End Sub


    Private Sub cmbRestrictions_BeforeDropDown(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbRestrictions.BeforeDropDown

        Try
            If cmbRestrictions.Items.Count <= 1 Then
                e.Cancel = True
                Exit Sub
            End If

            Dim g As Graphics = CreateGraphics()
            Dim iMaxLength As Single

            For Each vli As Infragistics.Win.ValueListItem In cmbRestrictions.Items
                iMaxLength = Math.Max(iMaxLength, g.MeasureString(vli.DisplayText, cmbRestrictions.Font).Width)
            Next
            If iMaxLength > cmbRestrictions.Width Then cmbRestrictions.DropDownListWidth = CInt(iMaxLength) + 10 Else cmbRestrictions.DropDownListWidth = 0

        Catch ex As Exception
            ErrMsg("BeforeDropDown error", ex)
        End Try

    End Sub

End Class
