Public Class Properties
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent

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
    Friend WithEvents pnlContainer As System.Windows.Forms.Panel
    Friend WithEvents btnAddProperty As Infragistics.Win.Misc.UltraButton
    Friend WithEvents pnlLines As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.pnlContainer = New System.Windows.Forms.Panel
        Me.pnlLines = New System.Windows.Forms.Panel
        Me.btnAddProperty = New Infragistics.Win.Misc.UltraButton
        Me.pnlContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContainer
        '
        Me.pnlContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContainer.AutoScroll = True
        Me.pnlContainer.BackColor = System.Drawing.SystemColors.Control
        Me.pnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlContainer.Controls.Add(Me.pnlLines)
        Me.pnlContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(312, 312)
        Me.pnlContainer.TabIndex = 0
        '
        'pnlLines
        '
        Me.pnlLines.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlLines.BackColor = System.Drawing.SystemColors.Control
        Me.pnlLines.Location = New System.Drawing.Point(0, 0)
        Me.pnlLines.Name = "pnlLines"
        Me.pnlLines.Size = New System.Drawing.Size(310, 56)
        Me.pnlLines.TabIndex = 0
        '
        'btnAddProperty
        '
        Me.btnAddProperty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.Image = Global.ADRIFT.My.Resources.imgAdd16
        Me.btnAddProperty.Appearance = Appearance1
        Me.btnAddProperty.Location = New System.Drawing.Point(9, 315)
        Me.btnAddProperty.Name = "btnAddProperty"
        Me.btnAddProperty.Size = New System.Drawing.Size(132, 25)
        Me.btnAddProperty.TabIndex = 1
        Me.btnAddProperty.Text = "Add New Property"
        '
        'Properties
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.btnAddProperty)
        Me.Controls.Add(Me.pnlContainer)
        Me.Name = "Properties"
        Me.Size = New System.Drawing.Size(312, 344)
        Me.pnlContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private bLoading As Boolean
    Private arlPropertyForms As New ArrayList
    Private iPropHeight As Integer
    Friend htblProperties As PropertyHashTable
    Public OwnerKey As String ' E.g. key of the object this property list is for
    Private arlProperties As New List(Of String)
    Public bGroup As Boolean = False
    Private lstPrivateKeys As List(Of String)

    Public Event Changed(ByVal sender As Object, ByVal e As System.EventArgs)

    Private ePropertyType As clsProperty.PropertyOfEnum = CType(-1, clsProperty.PropertyOfEnum) ' Uninitialised
    Friend Property PropertyType() As clsProperty.PropertyOfEnum
        Get
            Return ePropertyType
        End Get
        Set(ByVal value As clsProperty.PropertyOfEnum)
            If value <> ePropertyType Then
                ePropertyType = value
                For Each propGUI As GenericProperty In arlPropertyForms
                    propGUI.Dispose()
                    'RemoveProperty(propGUI)
                Next
                'For Each prop As clsProperty In htblProperties.Values
                '    RemoveProperty(prop)
                'Next
                arlPropertyForms.Clear()
                LoadProperties()
            End If
        End Set
    End Property

    Private Sub Properties_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        For Each prop As clsProperty In htblProperties.Values
            RemoveProperty(prop)
        Next
    End Sub



    Private Sub Properties_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'RefreshProperties()
    End Sub


    Private Sub PropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent Changed(Me, e)
    End Sub

    Private Sub AddProperty(ByVal prop As clsProperty, ByVal iOffset As Integer)

        With prop

            '' Don't show the hidden properties, i.e. ones that we have proper forms for
            'Select Case .Key
            '    Case LONGLOCATIONDESCRIPTION, SHORTLOCATIONDESCRIPTION, CHARACTERPROPERNAME
            '        Exit Sub
            'End Select

            If prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso .AppendToProperty <> "" Then
                If PropOnShow(.AppendToProperty) Then
                    Dim cmbStateList As Infragistics.Win.UltraWinEditors.UltraComboEditor = Nothing
                    Dim optStateList As Infragistics.Win.UltraWinEditors.UltraOptionSet = Nothing
                    For Each propGUI As GenericProperty In arlPropertyForms
                        If SafeString(propGUI.Tag) = .AppendToProperty Then
                            cmbStateList = propGUI.cmbStates
                            optStateList = propGUI.optSet
                            Exit For
                        End If
                    Next
                    If cmbStateList IsNot Nothing Then
                        Dim propOther As clsProperty = htblProperties(.AppendToProperty)
                        For Each sState As String In prop.arlStates
                            If Not ComboContainsKey(cmbStateList, sState) Then cmbStateList.Items.Add(sState)
                        Next
                        If cmbStateList.Items.Count = 2 Then
                            optStateList.Items(0).DisplayText = cmbStateList.Items(0).DisplayText
                            optStateList.Items(1).DisplayText = cmbStateList.Items(1).DisplayText
                            cmbStateList.Visible = False
                            If propOther.Value = optStateList.Items(1).DisplayText Then
                                optStateList.CheckedItem = optStateList.Items(1)
                            Else
                                optStateList.CheckedItem = optStateList.Items(0)
                            End If
                            optStateList.BringToFront()
                            optStateList.Visible = True
                        Else
                            optStateList.Visible = False
                            SetCombo(cmbStateList, propOther.Value)
                            cmbStateList.BringToFront()
                            cmbStateList.Visible = True
                        End If
                    End If
                End If
            Else
                If PropOnShow(.Key) Then
                    'DebugTimeRecord("Add Property " & prop.Description)
                    Dim fProperty As New GenericProperty(prop, Me, htblProperties, bGroup)
                    'DebugTimeFinish("Add Property " & prop.Description)
                    fProperty.Parent = Me.pnlLines
                    fProperty.Width = pnlLines.Width
                    fProperty.Tag = .Key
                    fProperty.Top = iOffset 'iPropHeight
                    iPropHeight += fProperty.Height
                    pnlLines.Height = iPropHeight
                    fProperty.chkSelected.Left = .Indent + 8

                    For Each p As GenericProperty In arlPropertyForms
                        If p.Top >= iOffset Then
                            p.Top += fProperty.Height
                        End If
                    Next
                    arlPropertyForms.Add(fProperty)

                    AddHandler fProperty.Changed, AddressOf PropertyChanged
                    Debug.WriteLine("AddHandler " & .Key)

                    If prop.FromGroup Then
                        fProperty.Enabled = False
                    End If
                Else
                    prop.Selected = False
                End If
            End If
        End With

    End Sub


    Private Sub RemoveProperty(ByVal sKey As String)
        Dim prop As clsProperty = htblProperties(sKey)
        RemoveProperty(prop)
    End Sub
    Private Sub RemoveProperty(ByVal prop As clsProperty)

        If prop Is Nothing Then Exit Sub

        prop.Selected = False
        If prop.Type = clsProperty.PropertyTypeEnum.StateList AndAlso prop.AppendToProperty <> "" Then
            ' Remove the states
            If PropOnShow(prop.AppendToProperty) Then
                Dim cmbStateList As Infragistics.Win.UltraWinEditors.UltraComboEditor = Nothing
                Dim optStateList As Infragistics.Win.UltraWinEditors.UltraOptionSet = Nothing
                For Each propGUI As GenericProperty In arlPropertyForms
                    If SafeString(propGUI.Tag) = prop.AppendToProperty Then
                        cmbStateList = propGUI.cmbStates
                        optStateList = propGUI.optSet
                        Exit For
                    End If
                Next
                If cmbStateList IsNot Nothing Then
                    Dim propOther As clsProperty = htblProperties(prop.AppendToProperty)
                    For Each sState As String In prop.arlStates
                        For Each vli As Infragistics.Win.ValueListItem In cmbStateList.Items
                            If vli.DisplayText = sState Then
                                cmbStateList.Items.Remove(vli)
                                Exit For
                            End If
                        Next
                    Next
                    If cmbStateList.Items.Count = 2 Then
                        optStateList.Items(0).DisplayText = cmbStateList.Items(0).DisplayText
                        optStateList.Items(1).DisplayText = cmbStateList.Items(1).DisplayText
                        cmbStateList.Visible = False
                        If propOther.Value = optStateList.Items(1).DisplayText Then
                            optStateList.CheckedItem = optStateList.Items(1)
                        Else
                            optStateList.CheckedItem = optStateList.Items(0)
                        End If
                        optStateList.BringToFront()
                        optStateList.Visible = True
                    Else
                        optStateList.Visible = False
                        SetCombo(cmbStateList, propOther.Value)
                        cmbStateList.BringToFront()
                        cmbStateList.Visible = True
                    End If
                End If
            End If
        Else
            For Each propGUI As GenericProperty In arlPropertyForms
                If propGUI.Tag.ToString = prop.Key Then
                    iPropHeight -= propGUI.Height
                    propGUI.Visible = False

                    For Each p As GenericProperty In arlPropertyForms
                        If p.Top > propGUI.Top Then
                            p.Top -= propGUI.Height
                        End If
                    Next
                    arlPropertyForms.Remove(propGUI)

                    RemoveHandler propGUI.Changed, AddressOf PropertyChanged
                    Debug.WriteLine("RemoveHandler " & prop.Key)

                    propGUI.Dispose()
                    Exit Sub
                End If
            Next
        End If

    End Sub


    Private Sub GetProperty(ByVal prop As clsProperty)

        With prop

            If PropOnShow(.Key) Then
                arlProperties.Add(.Key)
                GetProperties(.Key, prop.Selected, prop.Indent + 12)
            End If

        End With

    End Sub


    Private Sub GetProperties(ByVal sParentKey As String, ByVal bSelected As Boolean, Optional ByVal iIndent As Integer = 0)

        If bSelected Then

            ' Do all children that are Mandatory first
            For Each prop As clsProperty In htblProperties.Values
                With prop
                    If (.Mandatory OrElse .FromGroup) AndAlso .DependentKey = sParentKey AndAlso (.PrivateTo = "" OrElse .PrivateTo = OwnerKey OrElse lstPrivateKeys.Contains(.Key)) Then
                        If .DependentValue Is Nothing OrElse (htblProperties.ContainsKey(sParentKey) AndAlso .DependentValue = htblProperties(sParentKey).Value) Then
                            If Not bGroup Then prop.Selected = True
                            prop.Indent = iIndent
                            GetProperty(prop)
                        End If
                    End If
                End With
            Next

            ' Then add all other children
            For Each prop As clsProperty In htblProperties.Values
                With prop
                    If .DependentKey = sParentKey AndAlso Not (.Mandatory OrElse .FromGroup) AndAlso (.PrivateTo = "" OrElse .PrivateTo = OwnerKey OrElse lstPrivateKeys.Contains(.Key)) Then
                        If .DependentValue Is Nothing OrElse (htblProperties.ContainsKey(sParentKey) AndAlso .DependentValue = htblProperties(sParentKey).Value) Then
                            prop.Indent = iIndent
                            GetProperty(prop)
                        End If
                    End If
                End With
            Next

        Else

            ' Add any properties that depend on this one being there but NOT selected
            For Each prop As clsProperty In htblProperties.Values
                With prop
                    If .DependentKey = sParentKey AndAlso .DependentValue = "False" AndAlso (.PrivateTo = "" OrElse .PrivateTo = OwnerKey OrElse lstPrivateKeys.Contains(.Key)) Then
                        prop.Indent = iIndent
                        GetProperty(prop)
                    End If
                End With
            Next

        End If

    End Sub


    Private Sub LoadProperties()

        If bLoading Then Exit Sub
        bLoading = True

        Dim arlLastProperties As New ArrayList
        If arlPropertyForms.Count > 0 Then
            For Each sKey As String In arlProperties
                arlLastProperties.Add(sKey)
            Next
        End If
        'arlLastProperties = CType(arlProperties.Clon, ArrayList)
        arlProperties.Clear()

        ' Work out a list of all properties private to groups that this item is a member of
        lstPrivateKeys = New List(Of String)
        For Each grp As clsGroup In Adventure.htblGroups.Values
            If grp.arlMembers.Contains(OwnerKey) Then
                For Each prop As clsProperty In Adventure.htblAllProperties.Values
                    If prop.PrivateTo = grp.Key Then lstPrivateKeys.Add(prop.Key)
                Next
            End If
        Next

        GetProperties(Nothing, True)

        For Each sKey As String In arlLastProperties
            If Not arlProperties.Contains(sKey) Then
                ' Remove item
                Debug.WriteLine("Need to remove property " & sKey)
                RemoveProperty(sKey)
            End If
        Next
        Dim iOffset As Integer = 0
        Dim iCount As Integer = 0
        For Each sKey As String In arlProperties
            Dim prop As clsProperty = htblProperties(sKey)
            If Not prop.GroupOnly OrElse TypeOf Me.ParentForm Is frmGroup Then
                If Not arlLastProperties.Contains(sKey) Then
                    ' Add item
                    Debug.WriteLine("Need to add property " & sKey & " at index " & iCount)
                    AddProperty(prop, iOffset)
                End If
                iCount += 1
                If sKey IsNot Nothing AndAlso Adventure.htblAllProperties.ContainsKey(sKey) AndAlso Not Adventure.htblAllProperties(sKey).AppendToProperty <> "" Then
                    If Adventure.htblAllProperties(sKey).Type = clsProperty.PropertyTypeEnum.Text Then
                        iOffset += 160
                    Else
                        iOffset += 30
                    End If
                End If
            End If
        Next

        bLoading = False

    End Sub


    'Private Sub ClearPropertyForms()

    '    For Each frm As GenericProperty In arlPropertyForms
    '        frm.Visible = False
    '        frm.Dispose()
    '    Next

    '    arlPropertyForms.Clear()
    '    iPropHeight = 0

    'End Sub

    Private Function PropOnShow(ByVal sKey As String) As Boolean

        With htblProperties(sKey)
            If .DependentKey Is Nothing OrElse .DependentKey = "" Then
                Return True
            Else
                If htblProperties.ContainsKey(.DependentKey) Then                    
                    If Not htblProperties(.DependentKey).Selected AndAlso .DependentValue = "False" Then
                        Return True
                    ElseIf htblProperties(.DependentKey).Selected Then
                        If .DependentValue Is Nothing OrElse .DependentValue = htblProperties(.DependentKey).Value Then Return True
                    End If
                End If
                'If htblProperties.ContainsKey(.DependentKey) AndAlso htblProperties(.DependentKey).Selected Then
                '    If .DependentValue Is Nothing OrElse .DependentValue = htblProperties(.DependentKey).Value Then Return True
                'End If
            End If
        End With

    End Function

    Public Sub RefreshProperties()

        If htblProperties Is Nothing Then Exit Sub ' For when control is ran in design mode

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try
            Static salProps As New StringArrayList
            'Static iPropsOnShow As Integer = 0
            'Dim iNewPropsOnShow As Integer
            Dim salNewProps As New StringArrayList

            For Each prop As clsProperty In htblProperties.Values
                If PropOnShow(prop.Key) Then salNewProps.Add(prop.Key) ' iNewPropsOnShow += 1
            Next

            Dim bPropertiesChanged As Boolean
            If salNewProps.Count <> salProps.Count Then
                bPropertiesChanged = True
            Else
                For Each sKey As String In salProps
                    If Not salNewProps.Contains(sKey) Then
                        bPropertiesChanged = True
                        Exit For
                    End If
                Next
            End If

            If bPropertiesChanged Then
                'If iNewPropsOnShow <> iPropsOnShow Then
                Dim iTop As Integer = pnlLines.Top
                LoadProperties()
                'iPropsOnShow = iNewPropsOnShow
                salProps = salNewProps
                If pnlLines.Height > pnlContainer.Height Then pnlContainer.AutoScrollPosition = New Point(0, -Math.Max(iTop, pnlContainer.Height - pnlLines.Height))
            End If
        Catch ex As Exception
            ErrMsg("RefreshProperties error", ex)
        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub


    Public Function ValidateProperties(Optional ByRef FailingProperty As String = Nothing) As Boolean

        ' Check all properties that are checked are also populated
        For Each prop As clsProperty In htblProperties.Values
            If PropOnShow(prop.Key) AndAlso prop.Selected Then
                Select Case prop.Type
                    Case clsProperty.PropertyTypeEnum.CharacterKey, clsProperty.PropertyTypeEnum.LocationGroupKey, clsProperty.PropertyTypeEnum.LocationKey, clsProperty.PropertyTypeEnum.ObjectKey, clsProperty.PropertyTypeEnum.StateList
                        If prop.Value = "" Then
                            FailingProperty = prop.Key
                            ErrMsg("Property """ & prop.Description & """ cannot be blank")
                            Return False
                        End If
                End Select
            End If
        Next
        Return True

    End Function


    Private Sub btnAddProperty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProperty.Click

        Dim prop As New clsProperty
        prop.PropertyOf = PropertyType
        Dim frmProp As New frmProperty(prop, False)
        frmProp.chkPrivate.Visible = True
        frmProp.OwnerKey = OwnerKey
        frmProp.ShowDialog()
        frmProp.Dispose()
        Dim sKey As String = prop.Key
        If sKey IsNot Nothing Then            
            htblProperties.Add(prop.Copy)
            RefreshProperties()
        End If
        frmProp.Dispose()

    End Sub

End Class
