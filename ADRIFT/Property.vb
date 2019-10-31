Public Class GenericProperty
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Friend Sub New(ByVal prop As clsProperty, ByRef fOwner As Properties, ByVal htblCurrentProperties As PropertyHashTable, ByVal bGroup As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.fOwner = fOwner
        LoadProperty(prop, htblCurrentProperties, bGroup)

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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmbStates As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkSelected As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents GenTextbox1 As ADRIFT.GenTextbox
    Friend WithEvents optSet As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtNumber As Infragistics.Win.UltraWinEditors.UltraTextEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmbStates = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.txtNumber = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.optSet = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.GenTextbox1 = New ADRIFT.GenTextbox()
        Me.chkSelected = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.cmbStates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.optSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'cmbStates
        '
        Me.cmbStates.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbStates.Enabled = False
        Me.cmbStates.Location = New System.Drawing.Point(216, 5)
        Me.cmbStates.Name = "cmbStates"
        Me.cmbStates.Size = New System.Drawing.Size(208, 21)
        Me.cmbStates.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.cmbStates.TabIndex = 5
        Me.cmbStates.Visible = False
        '
        'txtNumber
        '
        Appearance1.TextHAlignAsString = "Right"
        Me.txtNumber.Appearance = Appearance1
        Me.txtNumber.Enabled = False
        Me.txtNumber.Location = New System.Drawing.Point(216, 5)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(48, 21)
        Me.txtNumber.TabIndex = 6
        Me.txtNumber.Visible = False
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.optSet)
        Me.UltraGroupBox1.Controls.Add(Me.GenTextbox1)
        Me.UltraGroupBox1.Controls.Add(Me.chkSelected)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(440, 160)
        Me.UltraGroupBox1.TabIndex = 7
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'optSet
        '
        Appearance2.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance2.TextHAlignAsString = "Center"
        Me.optSet.Appearance = Appearance2
        Me.optSet.BackColor = System.Drawing.Color.Transparent
        Me.optSet.BackColorInternal = System.Drawing.Color.Transparent
        Me.optSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.optSet.Enabled = False
        Appearance3.TextHAlignAsString = "Center"
        Me.optSet.ItemAppearance = Appearance3
        Me.optSet.ItemOrigin = New System.Drawing.Point(30, 0)
        ValueListItem1.DataValue = "Default Item"
        ValueListItem1.DisplayText = "Static"
        ValueListItem2.DataValue = "ValueListItem1"
        ValueListItem2.DisplayText = "Dynamic"
        Me.optSet.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optSet.ItemSpacingHorizontal = 10
        Me.optSet.Location = New System.Drawing.Point(216, 8)
        Me.optSet.Name = "optSet"
        Me.optSet.Size = New System.Drawing.Size(312, 16)
        Me.optSet.TabIndex = 4
        Me.optSet.Visible = False
        '
        'GenTextbox1
        '
        Me.GenTextbox1.AllowAlternateDescriptions = True
        Me.GenTextbox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GenTextbox1.BackColor = System.Drawing.Color.Transparent
        Me.GenTextbox1.Enabled = False
        Me.GenTextbox1.FirstTabHasRestrictions = False
        Me.GenTextbox1.Location = New System.Drawing.Point(8, 29)
        Me.GenTextbox1.Name = "GenTextbox1"
        Me.GenTextbox1.sCommand = Nothing
        Me.GenTextbox1.Size = New System.Drawing.Size(424, 123)
        Me.GenTextbox1.TabIndex = 1
        '
        'chkSelected
        '
        Me.chkSelected.BackColor = System.Drawing.Color.Transparent
        Me.chkSelected.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkSelected.Location = New System.Drawing.Point(8, 3)
        Me.chkSelected.Name = "chkSelected"
        Me.chkSelected.Size = New System.Drawing.Size(192, 26)
        Me.chkSelected.TabIndex = 0
        Me.chkSelected.Text = "UltraCheckEditor1"
        '
        'GenericProperty
        '
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.cmbStates)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "GenericProperty"
        Me.Size = New System.Drawing.Size(440, 160)
        CType(Me.cmbStates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.optSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public fOwner As Properties
    Private [Property] As clsProperty
    Private bLoading As Boolean

    Public Event Changed(ByVal sender As Object, ByVal e As System.EventArgs)


    Private Sub LoadProperty(ByRef prop As clsProperty, ByVal htblCurrentProperties As PropertyHashTable, ByVal bGroup As Boolean)

        bLoading = True

        Me.[Property] = prop

        Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right

        With prop
            chkSelected.Checked = .Selected

            If (.Mandatory OrElse .FromGroup) AndAlso Not bGroup Then
                chkSelected.Checked = True
                chkSelected.Enabled = False
            End If
            If Not (.Selected OrElse .Mandatory) Then
                optSet.Enabled = False
            End If

            chkSelected.Text = .Description
            Height = 30
            cmbStates.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending

            Select Case .Type

                Case clsProperty.PropertyTypeEnum.StateList
                    cmbStates.Items.Clear()
                    cmbStates.SortStyle = Infragistics.Win.ValueListSortStyle.None
                    For Each sState As String In .PossibleValues(htblCurrentProperties)
                        cmbStates.Items.Add(sState, sState)
                    Next
                    If .PossibleValues(htblCurrentProperties).Count = 2 Then
                        optSet.Items(0).DisplayText = .PossibleValues.Item(0)
                        optSet.Items(1).DisplayText = .PossibleValues.Item(1)

                        If .Value = .PossibleValues.Item(1) Then
                            optSet.CheckedItem = optSet.Items(1)
                        Else
                            optSet.CheckedItem = optSet.Items(0)
                        End If
                        optSet.Visible = True
                    Else
                        SetCombo(cmbStates, .Value)
                        If cmbStates.SelectedIndex = -1 Then cmbStates.SelectedIndex = 0
                        cmbStates.Visible = True
                    End If

                Case clsProperty.PropertyTypeEnum.ValueList
                    cmbStates.Items.Clear()
                    cmbStates.SortStyle = Infragistics.Win.ValueListSortStyle.None
                    For Each sLabel As String In .ValueList.Keys
                        cmbStates.Items.Add(.ValueList(sLabel), sLabel)
                    Next
                    If .ValueList.Count = 2 Then
                        Dim i As Integer = 0
                        For Each sLabel As String In .ValueList.Keys
                            optSet.Items(i).DisplayText = sLabel
                            optSet.Items(i).DataValue = .ValueList(sLabel)
                            i += 1
                        Next

                        If .Value = SafeString(optSet.Items(1).DataValue) Then
                            optSet.CheckedItem = optSet.Items(1)
                        Else
                            optSet.CheckedItem = optSet.Items(0)
                        End If
                        optSet.Visible = True
                    Else
                        SetCombo(cmbStates, .Value)
                        If cmbStates.SelectedIndex = -1 Then cmbStates.SelectedIndex = 0
                        cmbStates.Visible = True
                    End If

                Case clsProperty.PropertyTypeEnum.Text
                    GenTextbox1.Description = .StringData.Copy ' New Description(.Value)
                    If .GroupOnly Then GenTextbox1.FirstTabHasRestrictions = True
                    GenTextbox1.Visible = True
                    Height = 160

                Case clsProperty.PropertyTypeEnum.ObjectKey
                    cmbStates.Items.Clear()
                    'For Each ob As clsObject In Adventure.Objects("StaticOrDynamic", "Dynamic").Values
                    For Each ob As clsObject In Adventure.htblObjects.Values
                        If Me.fOwner.OwnerKey <> ob.Key AndAlso (prop.RestrictProperty Is Nothing OrElse ob.htblProperties.ContainsKey(prop.RestrictProperty)) Then
                            If prop.RestrictValue Is Nothing OrElse ob.htblProperties(prop.RestrictProperty).Value = prop.RestrictValue Then
                                cmbStates.Items.Add(ob.Key, ob.FullName)
                            End If
                        End If
                    Next
                    SetCombo(cmbStates, .Value)
                    cmbStates.Visible = True

                Case clsProperty.PropertyTypeEnum.Integer

                    If .RestrictProperty <> "" AndAlso Adventure.htblAllProperties.ContainsKey(.RestrictProperty) Then
                        Dim prop2 As clsProperty = Adventure.htblAllProperties(.RestrictProperty)
                        Dim lValues As New List(Of Integer)

                        cmbStates.Items.Clear()
                        cmbStates.SortStyle = Infragistics.Win.ValueListSortStyle.None

                        For Each sLabel As String In prop2.ValueList.Keys
                            cmbStates.Items.Add(prop2.ValueList(sLabel), sLabel)
                            lValues.Add(prop2.ValueList(sLabel))
                        Next

                        ' Find the highest number <= our value
                        lValues.Sort(Function(i1 As Integer, i2 As Integer)
                                         Return i2.CompareTo(i1)
                                     End Function)

                        ' Then see if that's a multiple of the value
                        For Each iValue As Integer In lValues
                            If iValue <= SafeInt(.Value) Then
                                If SafeInt(.Value) / iValue Mod 1 > -0.01 AndAlso SafeInt(.Value) / iValue Mod 1 < 0.01 Then
                                    SetCombo(cmbStates, iValue)
                                    txtNumber.Text = SafeInt(SafeInt(.Value) / iValue).ToString
                                    Exit For
                                End If
                            End If
                        Next
                        If txtNumber.Text = "" Then
                            txtNumber.Text = .Value
                        End If

                        cmbStates.Visible = True
                    Else
                        txtNumber.Text = .Value
                    End If
                    txtNumber.Visible = True

                Case clsProperty.PropertyTypeEnum.CharacterKey
                    cmbStates.Items.Clear()
                    ' Don't allow to pick same key from list, otherwise you can put player on himself etc
                    If Me.fOwner.OwnerKey <> Adventure.Player.Key Then cmbStates.Items.Add(THEPLAYER, "[ The Player Character ]")
                    For Each ch As clsCharacter In Adventure.htblCharacters.Values
                        If Me.fOwner.OwnerKey <> ch.Key AndAlso (prop.RestrictProperty Is Nothing OrElse ch.htblProperties.ContainsKey(prop.RestrictProperty)) Then
                            If prop.RestrictValue Is Nothing OrElse ch.htblProperties(prop.RestrictProperty).Value = prop.RestrictValue Then
                                cmbStates.Items.Add(ch.Key, ch.ProperName)
                            End If
                        End If
                    Next
                    SetCombo(cmbStates, .Value)
                    cmbStates.Visible = True

                Case clsProperty.PropertyTypeEnum.LocationKey
                    cmbStates.Items.Clear()
                    For Each l As clsLocation In Adventure.htblLocations.Values
                        cmbStates.Items.Add(l.Key, l.ShortDescription.ToString)
                    Next
                    SetCombo(cmbStates, .Value)
                    cmbStates.Visible = True

                Case clsProperty.PropertyTypeEnum.LocationGroupKey
                    cmbStates.Items.Clear()
                    For Each g As clsGroup In Adventure.htblGroups.Values
                        If g.GroupType = clsGroup.GroupTypeEnum.Locations Then
                            cmbStates.Items.Add(g.Key, g.Name)
                        End If
                    Next
                    SetCombo(cmbStates, .Value)
                    cmbStates.Visible = True

            End Select

            If .PopupDescription <> "" Then SetTooltip(Me, .PopupDescription)
            
        End With

        Visible = True

        bLoading = False

    End Sub


    Private Sub SetTooltip(ByVal ctrl As Control, ByVal sDescription As String)

        For Each ctrlSub As Control In ctrl.Controls
            SetTooltip(ctrlSub, sDescription)
        Next
        ToolTip1.SetToolTip(ctrl, sDescription)

    End Sub


    Private Sub chkSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelected.CheckedChanged

        Select Case chkSelected.Checked
            Case True
                Me.optSet.Enabled = True
                Me.GenTextbox1.Enabled = True
                Me.txtNumber.Enabled = True
                Me.cmbStates.Enabled = True
            Case False
                Me.optSet.Enabled = False
                Me.GenTextbox1.Enabled = False
                Me.txtNumber.Enabled = False
                Me.cmbStates.Enabled = False
        End Select

        [Property].Selected = chkSelected.Checked
        If Not bLoading Then fOwner.RefreshProperties()
        RaiseEvent Changed(Me, e)

    End Sub

    Private Sub GenericProperty_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetControlStyle(Me)
    End Sub

    Private Sub GenericProperty_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.chkSelected.Width = CInt(Me.Width / 2)
        Me.optSet.Left = CInt(Me.Width / 2) - 10
        Me.optSet.Width = CInt(Me.Width / 2)
        Me.optSet.ItemOrigin = New Point(CInt(Me.Width / 12), 0)        
        Me.txtNumber.Left = CInt(Me.Width / 2)
        If Me.Property IsNot Nothing AndAlso Me.Property.Type = clsProperty.PropertyTypeEnum.Integer AndAlso Me.Property.RestrictProperty <> "" AndAlso Adventure.htblAllProperties.ContainsKey(Me.Property.RestrictProperty) Then
            Me.cmbStates.Left = txtNumber.Left + txtNumber.Width + 10
            Me.cmbStates.Width = CInt(Me.Width / 2) - 20 - txtNumber.Width
        Else
            Me.cmbStates.Left = CInt(Me.Width / 2)
            Me.cmbStates.Width = CInt(Me.Width / 2) - 10
        End If

    End Sub

    Private Sub optSet_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSet.ValueChanged
        [Property].Value = optSet.Text
        Timer1.Interval = 1
        If Not bLoading Then Timer1.Start()
        RaiseEvent Changed(Me, e)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        fOwner.RefreshProperties()
    End Sub

    Private Sub txtNumber_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumber.ValueChanged

        If bLoading Then Exit Sub

        If cmbStates.Visible AndAlso cmbStates.SelectedItem IsNot Nothing Then
            [Property].Value = (Val(txtNumber.Text) * Val(cmbStates.SelectedItem.DataValue)).ToString
        Else
            [Property].Value = Val(txtNumber.Text).ToString
        End If
        RaiseEvent Changed(Me, e)
    End Sub


    Private Sub txtNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumber.KeyPress

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And Asc(e.KeyChar) <> 8 And (e.KeyChar <> "-"c OrElse txtNumber.Text.Contains("-")) Then
            e.Handled = True
        End If

    End Sub

    Private Sub GenTextbox1_txtSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenTextbox1.Changed
        If Not [Property] Is Nothing Then
            '[Property].Value = GenTextbox1.Description.ToString
            [Property].StringData = GenTextbox1.Description
            RaiseEvent Changed(Me, e)
        End If
    End Sub

    Private Sub cmbStates_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStates.SelectionChanged

        If bLoading Then Exit Sub

        If [Property].Type = clsProperty.PropertyTypeEnum.ValueList Then
            [Property].Value = CStr(cmbStates.SelectedItem.DisplayText)
        ElseIf [Property].Type = clsProperty.PropertyTypeEnum.Integer Then
            [Property].Value = (Val(txtNumber.Text) * Val(cmbStates.SelectedItem.DataValue)).ToString
        Else
            [Property].Value = CStr(cmbStates.SelectedItem.DataValue)
        End If

        Timer1.Interval = 1
        If Not bLoading Then Timer1.Start()
        RaiseEvent Changed(Me, e)
    End Sub

End Class
