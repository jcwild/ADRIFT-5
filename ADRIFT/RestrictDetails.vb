Public Class RestrictDetails
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
    Friend WithEvents lstLB As System.Windows.Forms.ListBox
    Friend WithEvents lstSummary As System.Windows.Forms.ListBox
    Friend WithEvents lstRB As System.Windows.Forms.ListBox
    Friend WithEvents cmsMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstAndOr As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnAdd = New Infragistics.Win.Misc.UltraButton()
        Me.btnEdit = New Infragistics.Win.Misc.UltraButton()
        Me.btnDelete = New Infragistics.Win.Misc.UltraButton()
        Me.btnUp = New Infragistics.Win.Misc.UltraButton()
        Me.btnDown = New Infragistics.Win.Misc.UltraButton()
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.lstAndOr = New System.Windows.Forms.ListBox()
        Me.lstRB = New System.Windows.Forms.ListBox()
        Me.lstSummary = New System.Windows.Forms.ListBox()
        Me.lstLB = New System.Windows.Forms.ListBox()
        Me.pnlLines = New System.Windows.Forms.Panel()
        Me.cmsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.btnAdd.Text = "Add"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(88, 232)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(176, 232)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
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
        Me.pnlContainer.Controls.Add(Me.lstAndOr)
        Me.pnlContainer.Controls.Add(Me.lstRB)
        Me.pnlContainer.Controls.Add(Me.lstSummary)
        Me.pnlContainer.Controls.Add(Me.lstLB)
        Me.pnlContainer.Controls.Add(Me.pnlLines)
        Me.pnlContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(248, 224)
        Me.pnlContainer.TabIndex = 10
        '
        'lstAndOr
        '
        Me.lstAndOr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstAndOr.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstAndOr.ContextMenuStrip = Me.cmsMenu
        Me.lstAndOr.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lstAndOr.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAndOr.ItemHeight = 18
        Me.lstAndOr.Location = New System.Drawing.Point(206, 0)
        Me.lstAndOr.Name = "lstAndOr"
        Me.lstAndOr.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstAndOr.Size = New System.Drawing.Size(40, 18)
        Me.lstAndOr.TabIndex = 24
        Me.lstAndOr.Visible = False
        '
        'lstRB
        '
        Me.lstRB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstRB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lstRB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstRB.ContextMenuStrip = Me.cmsMenu
        Me.lstRB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstRB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstRB.ItemHeight = 18
        Me.lstRB.Location = New System.Drawing.Point(190, 0)
        Me.lstRB.Name = "lstRB"
        Me.lstRB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstRB.Size = New System.Drawing.Size(16, 18)
        Me.lstRB.TabIndex = 23
        Me.lstRB.Visible = False
        '
        'lstSummary
        '
        Me.lstSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSummary.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstSummary.ContextMenuStrip = Me.cmsMenu
        Me.lstSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSummary.ItemHeight = 18
        Me.lstSummary.Location = New System.Drawing.Point(16, 0)
        Me.lstSummary.Name = "lstSummary"
        Me.lstSummary.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstSummary.Size = New System.Drawing.Size(174, 18)
        Me.lstSummary.TabIndex = 22
        Me.lstSummary.Visible = False
        '
        'lstLB
        '
        Me.lstLB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lstLB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstLB.ContextMenuStrip = Me.cmsMenu
        Me.lstLB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstLB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLB.ItemHeight = 18
        Me.lstLB.Location = New System.Drawing.Point(0, 0)
        Me.lstLB.Name = "lstLB"
        Me.lstLB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstLB.Size = New System.Drawing.Size(16, 18)
        Me.lstLB.TabIndex = 21
        Me.lstLB.Visible = False
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
        Me.cmsMenu.Size = New System.Drawing.Size(153, 142)
        '
        'miAdd
        '
        Me.miAdd.Image = Global.ADRIFT.My.Resources.imgAdd16
        Me.miAdd.Name = "miAdd"
        Me.miAdd.Size = New System.Drawing.Size(152, 22)
        Me.miAdd.Text = "&Add"
        '
        'miEdit
        '
        Me.miEdit.Image = Global.ADRIFT.My.Resources.imgEdit16
        Me.miEdit.Name = "miEdit"
        Me.miEdit.Size = New System.Drawing.Size(152, 22)
        Me.miEdit.Text = "&Edit"
        '
        'miDelete
        '
        Me.miDelete.Image = Global.ADRIFT.My.Resources.imgDelete
        Me.miDelete.Name = "miDelete"
        Me.miDelete.Size = New System.Drawing.Size(152, 22)
        Me.miDelete.Text = "&Delete"
        '
        'miCopy
        '
        Me.miCopy.Image = Global.ADRIFT.My.Resources.imgCopy
        Me.miCopy.Name = "miCopy"
        Me.miCopy.Size = New System.Drawing.Size(152, 22)
        Me.miCopy.Text = "&Copy"
        '
        'miPaste
        '
        Me.miPaste.Image = Global.ADRIFT.My.Resources.imgPaste
        Me.miPaste.Name = "miPaste"
        Me.miPaste.Size = New System.Drawing.Size(152, 22)
        Me.miPaste.Text = "&Paste"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'RestrictDetails
        '
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Name = "RestrictDetails"
        Me.Size = New System.Drawing.Size(272, 256)
        Me.pnlContainer.ResumeLayout(False)
        Me.cmsMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Friend arlRestrictions As RestrictionArrayList
    'Private arlRestrictLines As ArrayList
    Private Const iHEIGHT As Integer = 18
    Public sCommand As String
    Friend Property Arguments As List(Of clsUserFunction.Argument)
    Public Event RestrictionsChanged()
    Public bNoElseText As Boolean = False


    Friend Sub LoadRestrictions(ByRef arlRest As RestrictionArrayList)
        Try
            'Me.arlRestrictions = arlRest
            arlRestrictions = New RestrictionArrayList
            LoadGrid(arlRest)
        Catch ex As Exception
            ErrMsg("Error loading restrictions", ex)
        End Try
    End Sub


    Private Sub LoadGrid(ByVal restrictions As RestrictionArrayList)

        Dim iRest As Integer = lstSummary.Items.Count

        If arlRestrictions.Count > 0 AndAlso restrictions.Count > 0 Then arlRestrictions.BracketSequence &= "A"
        For Each rest As clsRestriction In restrictions
            arlRestrictions.Add(rest)
            AddRest(rest)
        Next        
        arlRestrictions.BracketSequence &= restrictions.BracketSequence

        LoadBrackets(restrictions.BracketSequence, iRest)

        DoHeight()

    End Sub


    Private Sub LoadBrackets(ByVal sBrackTemp As String, Optional ByVal iRest As Integer = 0)

        While sBrackTemp <> ""
            If sLeft(sBrackTemp, 1) = "[" Then
                lstLB.Items(iRest) = "(("
                sBrackTemp = sRight(sBrackTemp, Len(sBrackTemp) - 1)
            End If
            If sLeft(sBrackTemp, 1) = "(" Then
                lstLB.Items(iRest) = " ("
                sBrackTemp = sRight(sBrackTemp, Len(sBrackTemp) - 1)
            End If
            sBrackTemp = sRight(sBrackTemp, Len(sBrackTemp) - 1)
            If sLeft(sBrackTemp, 1) = ")" Then
                lstRB.Items(iRest) = ") "
                sBrackTemp = sRight(sBrackTemp, Len(sBrackTemp) - 1)
            End If
            If sLeft(sBrackTemp, 1) = "]" Then
                lstRB.Items(iRest) = "))"
                sBrackTemp = sRight(sBrackTemp, Len(sBrackTemp) - 1)
            End If
            If sBrackTemp <> "" Then
                If sLeft(sBrackTemp, 1) = "O" Then lstAndOr.Items(iRest) = "OR"
                sBrackTemp = sRight(sBrackTemp, Len(sBrackTemp) - 1)
            End If
            iRest += 1
        End While

    End Sub


    Private Sub AddRest(ByVal rest As clsRestriction)

        lstLB.Items.Add("")
        lstSummary.Items.Add(rest)
        lstRB.Items.Add("")
        lstAndOr.Items.Add("")
        If lstAndOr.Items.Count > 1 AndAlso CStr(lstAndOr.Items(lstAndOr.Items.Count - 2)) = "" Then
            lstAndOr.Items(lstAndOr.Items.Count - 2) = "AND"
            lstAndOr.Cursor = Cursors.Hand
        End If

        DoButtons()

    End Sub


    Private Function EditRestriction(ByRef rest As clsRestriction) As DialogResult

        Dim fRestriction As New frmRestriction

        fRestriction.sCommand = Me.sCommand
        fRestriction.Arguments = Me.Arguments
        fRestriction.LoadRestriction(rest.Copy)
        fRestriction.txtMessage.Enabled = Not bNoElseText
        If fRestriction.ShowDialog = DialogResult.OK Then
            rest = fRestriction.Restriction
            RaiseEvent RestrictionsChanged()
        End If

        Return fRestriction.DialogResult

    End Function


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim rest As New clsRestriction
        rest.StringValue = "*NEW*"

        If EditRestriction(rest) = DialogResult.OK Then

            arlRestrictions.Add(rest)

            DoHeight()
            AddRest(rest)
            UpdateBracketSequence()
        End If

    End Sub


    Private Sub DoHeight()

        If arlRestrictions.Count > 0 Then
            lstLB.Visible = True
            lstSummary.Visible = True
            lstRB.Visible = True
            lstAndOr.Visible = True
        Else
            lstLB.Visible = False
            lstSummary.Visible = False
            lstRB.Visible = False
            lstAndOr.Visible = False
        End If

        lstLB.Height = arlRestrictions.Count * iHEIGHT
        lstSummary.Height = arlRestrictions.Count * iHEIGHT
        lstRB.Height = arlRestrictions.Count * iHEIGHT
        lstAndOr.Height = arlRestrictions.Count * iHEIGHT

    End Sub

    Private Sub lstLB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLB.Click, lstRB.Click

        Dim lst As ListBox = CType(sender, ListBox)
        Dim iSelectedIndex As Integer = lst.IndexFromPoint(lst.PointToClient(MousePosition))

        If iSelectedIndex > -1 Then
            bSyncing = True
            If CStr(lst.Items(iSelectedIndex)) = "" Then
                If (Windows.Forms.Control.ModifierKeys And Keys.Control) <> 0 Then
                    lst.Items(iSelectedIndex) = If(lst Is lstLB, "((", "))").ToString
                Else
                    lst.Items(iSelectedIndex) = If(lst Is lstLB, " (", ") ").ToString
                End If
            Else
                lst.Items(iSelectedIndex) = ""
            End If
            UpdateBracketSequence()
            bSyncing = False
        End If

    End Sub

    'Private Sub lstRB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstRB.Click
    '    If CStr(lstRB.SelectedItem) = "" Then
    '        If (Windows.Forms.Control.ModifierKeys And Keys.Control) <> 0 Then
    '            lstRB.Items(lstRB.SelectedIndex) = "))"
    '        Else
    '            lstRB.Items(lstRB.SelectedIndex) = ") "
    '        End If
    '    Else
    '        lstRB.Items(lstRB.SelectedIndex) = ""
    '    End If
    '    UpdateBracketSequence()
    'End Sub

    Private Sub lst_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSummary.MouseDown, lstLB.MouseDown, lstRB.MouseDown, lstAndOr.MouseDown

        Dim lst As ListBox = CType(sender, ListBox)
        Dim iSelectedIndex As Integer = lst.IndexFromPoint(e.X, e.Y)

        If sender Is lstLB OrElse sender Is lstRB OrElse sender Is lstAndOr Then
            bSyncing = True
            lst.ClearSelected()
            'lst.Refresh()
            For Each i As Integer In lstSummary.SelectedIndices
                lst.SetSelected(i, True)
            Next
            'If iSelectedIndex > -1 Then lst.SetSelected(iSelectedIndex, Not lst.GetSelected(iSelectedIndex))            
            bSyncing = False
            'SyncLists(lstSummary)
            bBlockMouseEvent = True
            Exit Sub
        End If

        If iSelectedIndex > -1 Then
            If ModifierKeys = Keys.Shift Then
                ' Range                
                For i As Integer = lst.SelectedIndex To iSelectedIndex Step CInt(If(iSelectedIndex > lst.SelectedIndex, 1, -1))
                    lst.SetSelected(i, True)
                Next
            ElseIf ModifierKeys = Keys.Control Then
                ' No intervention necessary, it would seem
                If sender Is lstLB OrElse sender Is lstRB Then
                    bSyncing = True
                    lst.SetSelected(iSelectedIndex, Not lst.GetSelected(iSelectedIndex))
                    bSyncing = False
                    Exit Sub ' Interferes with (( ))
                End If
            Else
                lst.SelectedIndex = iSelectedIndex
            End If
            SyncLists(lst)
        End If

    End Sub


    'Private Sub tmrMouse_Tick(sender As Object, e As EventArgs) Handles tmrMouse.Tick
    '    tmrMouse.Stop()
    '    Application.DoEvents()
    '    If tmrList IsNot Nothing Then SyncLists(tmrList)
    'End Sub


    Dim bSyncing As Boolean = False
    Private Sub SyncLists(ByVal lstSource As ListBox)

        If bSyncing Then Exit Sub
        bSyncing = True

        Dim lstUnselectedIndices As New List(Of Integer)
        For i As Integer = 0 To lstSource.Items.Count - 1
            lstUnselectedIndices.Add(i)
        Next
        For Each i As Integer In lstSource.SelectedIndices
            lstUnselectedIndices.Remove(i)
            If Not lstLB.GetSelected(i) Then lstLB.SetSelected(i, True)
            If Not lstSummary.GetSelected(i) Then lstSummary.SetSelected(i, True)
            If Not lstRB.GetSelected(i) Then lstRB.SetSelected(i, True)
            If Not lstAndOr.GetSelected(i) Then lstAndOr.SetSelected(i, True)
        Next
        For Each i As Integer In lstUnselectedIndices
            lstLB.SetSelected(i, False)
            lstSummary.SetSelected(i, False)
            lstRB.SetSelected(i, False)
            lstAndOr.SetSelected(i, False)
        Next

        bSyncing = False

        'For i As Integer = 0 To lstSource.Items.Count - 1
        '    lstLB.se()
        'Next
        'Dim iIndex As Integer = lstSource.SelectedIndex

        'lstLB.SelectedIndex = iIndex
        'lstSummary.SelectedIndex = iIndex
        'lstRB.SelectedIndex = iIndex
        'lstAndOr.SelectedIndex = iIndex

        DoButtons()

    End Sub



    Private Sub UpdateBracketSequence()

        Dim sBS As String = ""

        For i As Integer = 0 To lstSummary.Items.Count - 1
            sBS &= LineBracket(i)
        Next

        arlRestrictions.BracketSequence = sLeft(sBS, Len(sBS) - 1)

    End Sub


    Private Function LineBracket(ByVal iRow As Integer) As String
        LineBracket = ""
        If CStr(lstLB.Items(iRow)) = " (" Then LineBracket &= "("
        If CStr(lstLB.Items(iRow)) = "((" Then LineBracket &= "["
        LineBracket &= "#"
        If CStr(lstRB.Items(iRow)) = ") " Then LineBracket &= ")"
        If CStr(lstRB.Items(iRow)) = "))" Then LineBracket &= "]"
        If CStr(lstAndOr.Items(iRow)) = "AND" Then LineBracket &= "A" Else LineBracket &= "O"
    End Function

    Private Sub lstAndOr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAndOr.Click

        Dim iSelectedIndex As Integer = lstAndOr.IndexFromPoint(lstAndOr.PointToClient(MousePosition))

        If iSelectedIndex > -1 AndAlso iSelectedIndex < lstAndOr.Items.Count - 1 Then
            If CStr(lstAndOr.Items(iSelectedIndex)) = "OR" Then
                lstAndOr.Items(iSelectedIndex) = "AND"
            Else
                lstAndOr.Items(iSelectedIndex) = "OR"
            End If
            UpdateBracketSequence()
        End If

    End Sub


    Private Sub DoButtons()

        If lstSummary.SelectedItems.Count = 1 Then
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            If lstSummary.SelectedIndex < 1 Then btnUp.Enabled = False Else btnUp.Enabled = True
            If lstSummary.SelectedIndex < 0 OrElse lstSummary.SelectedIndex = lstSummary.Items.Count - 1 Then btnDown.Enabled = False Else btnDown.Enabled = True
            miCopy.Enabled = True
        ElseIf lstSummary.SelectedItems.Count > 1 Then
            btnEdit.Enabled = False
            btnDelete.Enabled = True
            btnUp.Enabled = False
            btnDown.Enabled = False
            If lstSummary.Items.Count > 0 AndAlso Not lstSummary.GetSelected(0) Then btnUp.Enabled = True Else btnUp.Enabled = False
            If lstSummary.Items.Count > 0 AndAlso Not lstSummary.GetSelected(lstSummary.Items.Count - 1) Then btnDown.Enabled = True Else btnDown.Enabled = False
            miCopy.Enabled = True
        Else
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnUp.Enabled = False
            btnDown.Enabled = False
            miCopy.Enabled = False
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        For iIndex As Integer = lstSummary.Items.Count - 1 To 0 Step -1
            If lstSummary.GetSelected(iIndex) Then
                arlRestrictions.Remove(CType(lstSummary.Items(iIndex), clsRestriction))

                lstLB.Items.RemoveAt(iIndex)
                lstSummary.Items.RemoveAt(iIndex)
                lstRB.Items.RemoveAt(iIndex)
                lstAndOr.Items.RemoveAt(iIndex)
            End If
        Next
        'Dim iIndex As Integer = lstSummary.SelectedIndex

        DoHeight()
        DoButtons()
        UpdateBracketSequence()

    End Sub



    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click, btnDown.Click

        Dim iUpDown As Integer = CInt(IIf(sender Is btnUp, -1, 1))

        bSyncing = True

        Dim lstSelected As New List(Of Integer)
        For Each i As Integer In lstSummary.SelectedIndices
            lstSelected.Add(i)
        Next

        For i As Integer = CInt(If(iUpDown = -1, 0, lstSummary.Items.Count - 1)) To CInt(If(iUpDown = -1, lstSummary.Items.Count - 1, 0)) Step -iUpDown
            If lstSummary.GetSelected(i) Then
                Dim temprest As clsRestriction

                temprest = CType(lstSummary.Items(i), clsRestriction)
                lstSummary.Items(i) = lstSummary.Items(i + iUpDown)
                lstSummary.Items(i + iUpDown) = temprest

                Dim sTempBrac As String = lstLB.Items(i).ToString
                lstLB.Items(i) = lstLB.Items(i + iUpDown)
                lstLB.Items(i + iUpDown) = sTempBrac
                sTempBrac = lstRB.Items(i).ToString
                lstRB.Items(i) = lstRB.Items(i + iUpDown)
                lstRB.Items(i + iUpDown) = sTempBrac

                If Not ((i = lstSummary.Items.Count - 2 AndAlso iUpDown = 1) OrElse (i = lstSummary.Items.Count - 1 AndAlso iUpDown = -1)) Then
                    Dim sTempAndOr As String = lstAndOr.Items(i).ToString
                    lstAndOr.Items(i) = lstAndOr.Items(i + iUpDown)
                    lstAndOr.Items(i + iUpDown) = sTempAndOr
                End If

                arlRestrictions(i) = CType(lstSummary.Items(i), clsRestriction)
                arlRestrictions(i + iUpDown) = CType(lstSummary.Items(i + iUpDown), clsRestriction)

            End If

            'If i - iUpDown > -1 AndAlso i - iUpDown < lstSummary.Items.Count Then
            '    lstSummary.SetSelected(i, lstSummary.GetSelected(i - iUpDown))
            'Else
            '    lstSummary.SetSelected(i, False)
            'End If
        Next

        lstLB.ClearSelected()
        lstSummary.ClearSelected()
        lstRB.ClearSelected()
        lstAndOr.ClearSelected()
        For Each i As Integer In lstSelected
            lstLB.SetSelected(i + iUpDown, True)
            lstSummary.SetSelected(i + iUpDown, True)
            lstRB.SetSelected(i + iUpDown, True)
            lstAndOr.SetSelected(i + iUpDown, True)
        Next
        'lstLB.SelectedIndex = i + iUpDown
        'lstSummary.SelectedIndex = i + iUpDown
        'lstRB.SelectedIndex = i + iUpDown
        'lstAndOr.SelectedIndex = i + iUpDown

        bSyncing = False

        DoButtons()
        UpdateBracketSequence()

    End Sub

    'Private Sub btnDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDown.Click

    '    Dim temprest As clsRestriction
    '    Dim i As Integer = lstSummary.SelectedIndex

    '    temprest = CType(lstSummary.Items(i), clsRestriction)
    '    lstSummary.Items(i) = lstSummary.Items(i + 1)
    '    lstSummary.Items(i + 1) = temprest

    '    Dim sTempBrac As String = lstLB.Items(i).ToString
    '    lstLB.Items(i) = lstLB.Items(i + 1)
    '    lstLB.Items(i + 1) = sTempBrac
    '    sTempBrac = lstRB.Items(i).ToString
    '    lstRB.Items(i) = lstRB.Items(i + 1)
    '    lstRB.Items(i + 1) = sTempBrac

    '    arlRestrictions(i) = CType(lstSummary.Items(i), clsRestriction)
    '    arlRestrictions(i + 1) = CType(lstSummary.Items(i + 1), clsRestriction)

    '    lstLB.SelectedIndex = i + 1
    '    lstSummary.SelectedIndex = i + 1
    '    lstRB.SelectedIndex = i + 1
    '    lstAndOr.SelectedIndex = i + 1
    '    DoButtons()
    '    UpdateBracketSequence()

    'End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Edit()
    End Sub

    Private Sub Edit()

        Dim rest As clsRestriction = arlRestrictions(Me.lstSummary.SelectedIndex).Copy

        If EditRestriction(rest) = DialogResult.OK Then

            arlRestrictions(lstSummary.SelectedIndex) = rest
            lstSummary.Items(lstSummary.SelectedIndex) = rest

            DoHeight()
            UpdateBracketSequence()
        End If

    End Sub


    Private Sub lstSummary_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSummary.DoubleClick
        If lstSummary.SelectedIndex > -1 Then Edit()
    End Sub


    Private bBlockMouseEvent As Boolean = False
    Private Sub lstSummary_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSummary.SelectedIndexChanged, lstAndOr.SelectedIndexChanged, lstLB.SelectedIndexChanged, lstRB.SelectedIndexChanged

        If bSyncing Then Exit Sub

        Dim listChanged As ListBox = CType(sender, ListBox)
        ''For Each ctrl As ListBox In New ListBox() {lstSummary, lstAndOr, lstLB, lstRB}
        ''    If ctrl IsNot listChanged Then ctrl.SelectedIndex = listChanged.SelectedIndex
        ''Next
        ''DoButtons()
        'If ModifierKeys = Keys.Control AndAlso

        If bBlockMouseEvent AndAlso (sender Is lstLB OrElse sender Is lstRB OrElse sender Is lstAndOr) Then
            bBlockMouseEvent = False
            Exit Sub
        End If

        SyncLists(listChanged)

    End Sub

    Private Sub cmsMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsMenu.Opening
        miCopy.Enabled = lstSummary.SelectedIndex > -1
        miPaste.Enabled = xmlRestrictions IsNot Nothing
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

        Dim copyRestrictions As New RestrictionArrayList
        Dim ms As New IO.MemoryStream
        Dim xml As New Xml.XmlTextWriter(ms, System.Text.Encoding.UTF8)
        xml.Formatting = System.Xml.Formatting.Indented
        xml.WriteStartDocument()
        xml.WriteStartElement("Restrictions")

        For i As Integer = 0 To lstSummary.Items.Count - 1
            If lstSummary.GetSelected(i) Then
                copyRestrictions.Add(CType(lstSummary.Items(i), clsRestriction).Copy)
                copyRestrictions.BracketSequence &= LineBracket(i)
            End If
        Next
        copyRestrictions.BracketSequence = sLeft(copyRestrictions.BracketSequence, copyRestrictions.BracketSequence.Length - 1)
        SaveRestrictions(xml, copyRestrictions)
        xml.WriteEndElement()
        xml.WriteEndDocument()
        xml.Flush()

        xmlRestrictions = ms.ToArray

    End Sub

    Private Sub miPaste_Click(sender As Object, e As EventArgs) Handles miPaste.Click

        Dim ms As New IO.MemoryStream(xmlRestrictions)
        Dim xmlDoc As New Xml.XmlDocument
        xmlDoc.Load(ms)
        Dim pasteRestrictions As RestrictionArrayList = FileIO.LoadRestrictions(xmlDoc.DocumentElement)
        Dim iStart As Integer = lstSummary.Items.Count
        LoadGrid(pasteRestrictions)

        lstSummary.SelectedItems.Clear()
        For i As Integer = iStart To lstSummary.Items.Count - 1
            lstSummary.SelectedIndices.Add(i)
        Next
        SyncLists(lstSummary)

    End Sub

End Class
