Public Class Actions
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
    Friend WithEvents btnAdd As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnEdit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDelete As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnUp As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDown As Infragistics.Win.Misc.UltraButton
    Friend WithEvents pnlContainer As System.Windows.Forms.Panel
    Friend WithEvents pnlLines As System.Windows.Forms.Panel
    Friend WithEvents cmsMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstSummary As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnAdd = New Infragistics.Win.Misc.UltraButton()
        Me.btnEdit = New Infragistics.Win.Misc.UltraButton()
        Me.btnDelete = New Infragistics.Win.Misc.UltraButton()
        Me.btnUp = New Infragistics.Win.Misc.UltraButton()
        Me.btnDown = New Infragistics.Win.Misc.UltraButton()
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.lstSummary = New System.Windows.Forms.ListBox()
        Me.pnlLines = New System.Windows.Forms.Panel()
        Me.cmsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlContainer.SuspendLayout()
        Me.cmsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAdd.Location = New System.Drawing.Point(0, 232)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "&Add"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(88, 232)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "&Edit"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(176, 232)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        '
        'btnUp
        '
        Me.btnUp.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnUp.Enabled = False
        Me.btnUp.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnUp.Location = New System.Drawing.Point(248, 88)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(24, 23)
        Me.btnUp.TabIndex = 5
        Me.btnUp.Text = "5"
        '
        'btnDown
        '
        Me.btnDown.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnDown.Enabled = False
        Me.btnDown.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnDown.Location = New System.Drawing.Point(248, 120)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(24, 23)
        Me.btnDown.TabIndex = 6
        Me.btnDown.Text = "6"
        '
        'pnlContainer
        '
        Me.pnlContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContainer.AutoScroll = True
        Me.pnlContainer.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlContainer.ContextMenuStrip = Me.cmsMenu
        Me.pnlContainer.Controls.Add(Me.lstSummary)
        Me.pnlContainer.Controls.Add(Me.pnlLines)
        Me.pnlContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(248, 224)
        Me.pnlContainer.TabIndex = 10
        '
        'lstSummary
        '
        Me.lstSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSummary.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSummary.ItemHeight = 18
        Me.lstSummary.Location = New System.Drawing.Point(0, 0)
        Me.lstSummary.Name = "lstSummary"
        Me.lstSummary.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstSummary.Size = New System.Drawing.Size(246, 18)
        Me.lstSummary.TabIndex = 22
        Me.lstSummary.Visible = False
        '
        'pnlLines
        '
        Me.pnlLines.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlLines.BackColor = System.Drawing.SystemColors.ControlDark
        Me.pnlLines.Location = New System.Drawing.Point(0, 0)
        Me.pnlLines.Name = "pnlLines"
        Me.pnlLines.Size = New System.Drawing.Size(242, 0)
        Me.pnlLines.TabIndex = 13
        '
        'cmsMenu
        '
        Me.cmsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAdd, Me.miEdit, Me.miDelete, Me.ToolStripSeparator1, Me.miCopy, Me.miPaste})
        Me.cmsMenu.Name = "cmsMenu"
        Me.cmsMenu.Size = New System.Drawing.Size(108, 120)
        '
        'miAdd
        '
        Me.miAdd.Image = Global.ADRIFT.My.Resources.imgAdd16
        Me.miAdd.Name = "miAdd"
        Me.miAdd.Size = New System.Drawing.Size(107, 22)
        Me.miAdd.Text = "&Add"
        '
        'miEdit
        '
        Me.miEdit.Image = Global.ADRIFT.My.Resources.imgEdit16
        Me.miEdit.Name = "miEdit"
        Me.miEdit.Size = New System.Drawing.Size(107, 22)
        Me.miEdit.Text = "&Edit"
        '
        'miDelete
        '
        Me.miDelete.Image = Global.ADRIFT.My.Resources.imgDelete
        Me.miDelete.Name = "miDelete"
        Me.miDelete.Size = New System.Drawing.Size(107, 22)
        Me.miDelete.Text = "&Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(104, 6)
        '
        'miCopy
        '
        Me.miCopy.Image = Global.ADRIFT.My.Resources.imgCopy
        Me.miCopy.Name = "miCopy"
        Me.miCopy.Size = New System.Drawing.Size(107, 22)
        Me.miCopy.Text = "&Copy"
        '
        'miPaste
        '
        Me.miPaste.Image = Global.ADRIFT.My.Resources.imgPaste
        Me.miPaste.Name = "miPaste"
        Me.miPaste.Size = New System.Drawing.Size(107, 22)
        Me.miPaste.Text = "&Paste"
        '
        'Actions
        '
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Name = "Actions"
        Me.Size = New System.Drawing.Size(272, 256)
        Me.pnlContainer.ResumeLayout(False)
        Me.cmsMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Friend arlActions As ActionArrayList
    Private Const iHEIGHT As Integer = 18
    Public sCommand As String


    Friend Sub LoadActions(ByRef arlAct As ActionArrayList)
        Try
            Me.arlActions = New ActionArrayList
            LoadGrid(arlAct)
        Catch ex As Exception
            ErrMsg("Error loading actions", ex)
        End Try
    End Sub


    Private Sub LoadGrid(ByVal actions As ActionArrayList)

        Dim iAct As Integer = lstSummary.Items.Count

        For Each act As clsAction In actions
            arlActions.Add(act)
            AddAct(act)
        Next

        DoHeight()

    End Sub

    Private Sub AddAct(ByVal act As clsAction)

        lstSummary.Items.Add(act)
        DoButtons()

    End Sub


    Private Function EditAction(ByRef act As clsAction) As DialogResult

        Dim fAction As New frmAction(Me.sCommand)

        fAction.LoadAction(act.Copy)
        If fAction.ShowDialog = DialogResult.OK Then act = fAction.Action

        Return fAction.DialogResult

    End Function


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim act As New clsAction

        If EditAction(act) = DialogResult.OK Then

            arlActions.Add(act)

            DoHeight()
            AddAct(act)
        End If

    End Sub


    Private Sub DoHeight()

        If arlActions.Count > 0 Then
            lstSummary.Visible = True
        Else
            lstSummary.Visible = False
        End If

        lstSummary.Height = arlActions.Count * iHEIGHT

    End Sub


    Private Sub lst_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSummary.MouseDown

        Dim lst As ListBox = CType(sender, ListBox)
        Dim iSelectedIndex As Integer = lst.IndexFromPoint(e.X, e.Y)
        If iSelectedIndex > -1 Then

            If ModifierKeys = Keys.Shift Then
                ' Range                
                For i As Integer = lst.SelectedIndex To iSelectedIndex Step CInt(If(iSelectedIndex > lst.SelectedIndex, 1, -1))
                    lst.SetSelected(i, True)
                Next
            ElseIf ModifierKeys = Keys.Control Then
                ' No intervention necessary, it would seem
            Else
                lst.SelectedIndex = iSelectedIndex
            End If
            SyncLists(lst)
        End If

    End Sub


    Private Sub SyncLists(ByVal lstSource As ListBox)

        'Dim iIndex As Integer = lstSource.SelectedIndex

        'lstSummary.SelectedIndex = iIndex

        DoButtons()

    End Sub


    Private Sub DoButtons()

        If lstSummary.SelectedItems.Count = 1 Then
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            If lstSummary.SelectedIndex < 1 Then btnUp.Enabled = False Else btnUp.Enabled = True
            If lstSummary.SelectedIndex < 0 OrElse lstSummary.SelectedIndex = lstSummary.Items.Count - 1 Then btnDown.Enabled = False Else btnDown.Enabled = True
        ElseIf lstSummary.SelectedItems.Count > 1 Then
            btnEdit.Enabled = False
            btnDelete.Enabled = True
            btnUp.Enabled = False
            btnDown.Enabled = False
            If lstSummary.Items.Count > 0 AndAlso Not lstSummary.GetSelected(0) Then btnUp.Enabled = True Else btnUp.Enabled = False
            If lstSummary.Items.Count > 0 AndAlso Not lstSummary.GetSelected(lstSummary.Items.Count - 1) Then btnDown.Enabled = True Else btnDown.Enabled = False
        Else
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnUp.Enabled = False
            btnDown.Enabled = False
        End If

    End Sub
    'Private Sub DoButtons()

    '    If lstSummary.SelectedIndex > -1 Then
    '        btnEdit.Enabled = True
    '        btnDelete.Enabled = True
    '    Else
    '        btnEdit.Enabled = False
    '        btnDelete.Enabled = False
    '    End If

    '    If lstSummary.SelectedIndex < 1 Then btnUp.Enabled = False Else btnUp.Enabled = True
    '    If lstSummary.SelectedIndex < 0 OrElse lstSummary.SelectedIndex = lstSummary.Items.Count - 1 Then btnDown.Enabled = False Else btnDown.Enabled = True

    'End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        For iIndex As Integer = lstSummary.Items.Count - 1 To 0 Step -1
            If lstSummary.GetSelected(iIndex) Then
                arlActions.Remove(CType(lstSummary.Items(iIndex), clsAction))

                lstSummary.Items.RemoveAt(iIndex)
            End If
        Next
        'Dim iIndex As Integer = lstSummary.SelectedIndex

        DoHeight()
        DoButtons()

    End Sub

    'Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

    '    Dim iIndex As Integer = lstSummary.SelectedIndex

    '    arlActions.Remove(CType(lstSummary.Items(iIndex), clsAction))

    '    lstSummary.Items.RemoveAt(iIndex)

    '    DoHeight()
    '    DoButtons()

    'End Sub

    Private Sub btnUpDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click, btnDown.Click

        Dim iUpDown As Integer = CInt(IIf(sender Is btnUp, -1, 1))

        Dim lstSelected As New List(Of Integer)
        For Each i As Integer In lstSummary.SelectedIndices
            lstSelected.Add(i)
        Next

        For i As Integer = CInt(If(iUpDown = -1, 0, lstSummary.Items.Count - 1)) To CInt(If(iUpDown = -1, lstSummary.Items.Count - 1, 0)) Step -iUpDown
            If lstSummary.GetSelected(i) Then
                Dim tempact As clsAction

                tempact = CType(lstSummary.Items(i), clsAction)
                lstSummary.Items(i) = lstSummary.Items(i + iUpDown)
                lstSummary.Items(i + iUpDown) = tempact

                arlActions(i) = CType(lstSummary.Items(i), clsAction)
                arlActions(i + iUpDown) = CType(lstSummary.Items(i + iUpDown), clsAction)
            End If

        Next

        lstSummary.ClearSelected()
        For Each i As Integer In lstSelected
            lstSummary.SetSelected(i + iUpDown, True)
        Next

        DoButtons()

    End Sub



    'Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click

    '    Dim tempact As clsAction
    '    Dim i As Integer = lstSummary.SelectedIndex

    '    tempact = CType(lstSummary.Items(i), clsAction)
    '    lstSummary.Items(i) = lstSummary.Items(i - 1)
    '    lstSummary.Items(i - 1) = tempact

    '    arlActions(i) = CType(lstSummary.Items(i), clsAction)
    '    arlActions(i - 1) = CType(lstSummary.Items(i - 1), clsAction)

    '    lstSummary.SelectedIndex = i - 1
    '    DoButtons()

    'End Sub

    'Private Sub btnDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDown.Click

    '    Dim tempact As clsAction
    '    Dim i As Integer = lstSummary.SelectedIndex

    '    tempact = CType(lstSummary.Items(i), clsAction)
    '    lstSummary.Items(i) = lstSummary.Items(i + 1)
    '    lstSummary.Items(i + 1) = tempact

    '    arlActions(i) = CType(lstSummary.Items(i), clsAction)
    '    arlActions(i + 1) = CType(lstSummary.Items(i + 1), clsAction)

    '    lstSummary.SelectedIndex = i + 1
    '    DoButtons()

    'End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Edit()
    End Sub

    Private Sub Edit()

        Dim act As clsAction = arlActions(Me.lstSummary.SelectedIndex).Copy

        If EditAction(act) = DialogResult.OK Then

            arlActions(lstSummary.SelectedIndex) = act
            lstSummary.Items(lstSummary.SelectedIndex) = act

            DoHeight()
        End If

    End Sub

    Private Sub lstSummary_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSummary.DoubleClick
        If lstSummary.SelectedIndex > -1 Then Edit()
    End Sub

    Private Sub cmsMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsMenu.Opening
        miCopy.Enabled = lstSummary.SelectedIndex > -1
        miPaste.Enabled = xmlActions IsNot Nothing
    End Sub

    Private Sub btnDelete_EnabledChanged(sender As Object, e As EventArgs) Handles btnDelete.EnabledChanged
        miDelete.Enabled = btnDelete.Enabled
    End Sub

    Private Sub btnEdit_EnabledChanged(sender As Object, e As EventArgs) Handles btnEdit.EnabledChanged
        miEdit.Enabled = btnEdit.Enabled
    End Sub

    Private Sub miAdd_Click(sender As Object, e As EventArgs) Handles miAdd.Click
        btnAdd_Click(sender, e)
    End Sub

    Private Sub miEdit_Click(sender As Object, e As EventArgs) Handles miEdit.Click
        btnEdit_Click(sender, e)
    End Sub

    Private Sub miDelete_Click(sender As Object, e As EventArgs) Handles miDelete.Click
        btnDelete_Click(sender, e)
    End Sub

    Private Sub miCopy_Click(sender As Object, e As EventArgs) Handles miCopy.Click

        Dim copyActions As New ActionArrayList
        Dim ms As New IO.MemoryStream
        Dim xml As New Xml.XmlTextWriter(ms, System.Text.Encoding.UTF8)
        xml.Formatting = System.Xml.Formatting.Indented
        xml.WriteStartDocument()
        xml.WriteStartElement("Actions")

        For i As Integer = 0 To lstSummary.Items.Count - 1
            If lstSummary.GetSelected(i) Then
                copyActions.Add(CType(lstSummary.Items(i), clsAction).Copy)
            End If
        Next
        SaveActions(xml, copyActions)
        xml.WriteEndElement()
        xml.WriteEndDocument()
        xml.Flush()

        xmlActions = ms.ToArray

    End Sub

    Private Sub miPaste_Click(sender As Object, e As EventArgs) Handles miPaste.Click

        Dim ms As New IO.MemoryStream(xmlActions)
        Dim xmlDoc As New Xml.XmlDocument
        xmlDoc.Load(ms)
        Dim pasteActions As ActionArrayList = FileIO.LoadActions(xmlDoc.DocumentElement)
        Dim iStart As Integer = lstSummary.Items.Count
        LoadGrid(pasteActions)

        lstSummary.SelectedItems.Clear()
        For i As Integer = iStart To lstSummary.Items.Count - 1
            lstSummary.SelectedIndices.Add(i)
        Next
        SyncLists(lstSummary)

    End Sub

End Class
