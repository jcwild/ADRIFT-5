Public Class frmLocation
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public bKeepOpen As Boolean = False

    Public Sub New(ByRef Location As clsLocation, ByVal bShow As Boolean)
        MyBase.New()

        ' Check that this window isn't already open
        For Each w As Form In OpenForms
            If TypeOf w Is frmLocation Then
                If CType(w, frmLocation).cLocation.Key = Location.Key AndAlso Location.Key IsNot Nothing Then
                    w.BringToFront()
                    w.Focus()
                    Exit Sub
                End If
            End If
        Next

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoadForm(Location, bShow)
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
    Friend WithEvents tabsLocation As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents lblShortDesc As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblLongDesc As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtLongDesc As ADRIFT.GenTextbox
    Friend WithEvents lblRestrictions As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lblDirection As System.Windows.Forms.Label
    Friend WithEvents RestrictNorth As ADRIFT.RestrictSummary
    Friend WithEvents RestrictNorthEast As ADRIFT.RestrictSummary
    Friend WithEvents RestrictEast As ADRIFT.RestrictSummary
    Friend WithEvents RestrictSouthEast As ADRIFT.RestrictSummary
    Friend WithEvents RestrictSouth As ADRIFT.RestrictSummary
    Friend WithEvents RestrictSouthWest As ADRIFT.RestrictSummary
    Friend WithEvents RestrictWest As ADRIFT.RestrictSummary
    Friend WithEvents RestrictNorthWest As ADRIFT.RestrictSummary
    Friend WithEvents RestrictUp As ADRIFT.RestrictSummary
    Friend WithEvents RestrictDown As ADRIFT.RestrictSummary
    Friend WithEvents RestrictIn As ADRIFT.RestrictSummary
    Friend WithEvents RestrictOut As ADRIFT.RestrictSummary
    Friend WithEvents pgDescription As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents btnAddObject As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbNorth As ADRIFT.ItemSelector
    Friend WithEvents cmbOut As ADRIFT.ItemSelector
    Friend WithEvents cmbIn As ADRIFT.ItemSelector
    Friend WithEvents cmbDown As ADRIFT.ItemSelector
    Friend WithEvents cmbUp As ADRIFT.ItemSelector
    Friend WithEvents cmbNorthWest As ADRIFT.ItemSelector
    Friend WithEvents cmbWest As ADRIFT.ItemSelector
    Friend WithEvents cmbSouthWest As ADRIFT.ItemSelector
    Friend WithEvents cmbSouth As ADRIFT.ItemSelector
    Friend WithEvents cmbSouthEast As ADRIFT.ItemSelector
    Friend WithEvents cmbEast As ADRIFT.ItemSelector
    Friend WithEvents cmbNorthEast As ADRIFT.ItemSelector
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Properties1 As ADRIFT.Properties
    Friend WithEvents txtShortDesc As ADRIFT.ExpandableDescription
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Folder1 As ADRIFT.Folder
    Friend WithEvents btnRemoveItem As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblNorth As System.Windows.Forms.LinkLabel
    Friend WithEvents lblOut As System.Windows.Forms.LinkLabel
    Friend WithEvents lblIn As System.Windows.Forms.LinkLabel
    Friend WithEvents lblDown As System.Windows.Forms.LinkLabel
    Friend WithEvents lblUp As System.Windows.Forms.LinkLabel
    Friend WithEvents lblNorthWest As System.Windows.Forms.LinkLabel
    Friend WithEvents lblWest As System.Windows.Forms.LinkLabel
    Friend WithEvents lblSouthWest As System.Windows.Forms.LinkLabel
    Friend WithEvents lblSouth As System.Windows.Forms.LinkLabel
    Friend WithEvents lblSouthEast As System.Windows.Forms.LinkLabel
    Friend WithEvents lblEast As System.Windows.Forms.LinkLabel
    Friend WithEvents lblNorthEast As System.Windows.Forms.LinkLabel
    Friend WithEvents btnApply As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents chkHideOnMap As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddCharacter As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddDynamicOb As Infragistics.Win.Misc.UltraButton
    Friend WithEvents pgDirections As Infragistics.Win.UltraWinTabControl.UltraTabPageControl

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Me.pgDescription = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.txtShortDesc = New ADRIFT.ExpandableDescription()
        Me.txtLongDesc = New ADRIFT.GenTextbox()
        Me.lblLongDesc = New Infragistics.Win.Misc.UltraLabel()
        Me.lblShortDesc = New Infragistics.Win.Misc.UltraLabel()
        Me.pgDirections = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.lblOut = New System.Windows.Forms.LinkLabel()
        Me.lblIn = New System.Windows.Forms.LinkLabel()
        Me.lblDown = New System.Windows.Forms.LinkLabel()
        Me.lblUp = New System.Windows.Forms.LinkLabel()
        Me.lblNorthWest = New System.Windows.Forms.LinkLabel()
        Me.lblWest = New System.Windows.Forms.LinkLabel()
        Me.lblSouthWest = New System.Windows.Forms.LinkLabel()
        Me.lblSouth = New System.Windows.Forms.LinkLabel()
        Me.lblSouthEast = New System.Windows.Forms.LinkLabel()
        Me.lblEast = New System.Windows.Forms.LinkLabel()
        Me.lblNorthEast = New System.Windows.Forms.LinkLabel()
        Me.lblNorth = New System.Windows.Forms.LinkLabel()
        Me.RestrictOut = New ADRIFT.RestrictSummary()
        Me.RestrictIn = New ADRIFT.RestrictSummary()
        Me.RestrictDown = New ADRIFT.RestrictSummary()
        Me.RestrictUp = New ADRIFT.RestrictSummary()
        Me.RestrictNorthWest = New ADRIFT.RestrictSummary()
        Me.RestrictWest = New ADRIFT.RestrictSummary()
        Me.RestrictSouthWest = New ADRIFT.RestrictSummary()
        Me.RestrictSouth = New ADRIFT.RestrictSummary()
        Me.RestrictSouthEast = New ADRIFT.RestrictSummary()
        Me.RestrictEast = New ADRIFT.RestrictSummary()
        Me.RestrictNorthEast = New ADRIFT.RestrictSummary()
        Me.RestrictNorth = New ADRIFT.RestrictSummary()
        Me.cmbOut = New ADRIFT.ItemSelector()
        Me.cmbIn = New ADRIFT.ItemSelector()
        Me.cmbDown = New ADRIFT.ItemSelector()
        Me.cmbUp = New ADRIFT.ItemSelector()
        Me.cmbNorthWest = New ADRIFT.ItemSelector()
        Me.cmbWest = New ADRIFT.ItemSelector()
        Me.cmbSouthWest = New ADRIFT.ItemSelector()
        Me.cmbSouth = New ADRIFT.ItemSelector()
        Me.cmbSouthEast = New ADRIFT.ItemSelector()
        Me.cmbEast = New ADRIFT.ItemSelector()
        Me.cmbNorthEast = New ADRIFT.ItemSelector()
        Me.cmbNorth = New ADRIFT.ItemSelector()
        Me.lblRestrictions = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblDirection = New System.Windows.Forms.Label()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Properties1 = New ADRIFT.Properties()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btnAddCharacter = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddDynamicOb = New Infragistics.Win.Misc.UltraButton()
        Me.btnRemoveItem = New Infragistics.Win.Misc.UltraButton()
        Me.Folder1 = New ADRIFT.Folder()
        Me.btnAddObject = New Infragistics.Win.Misc.UltraButton()
        Me.chkHideOnMap = New System.Windows.Forms.CheckBox()
        Me.tabsLocation = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnApply = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.pgDescription.SuspendLayout()
        Me.pgDirections.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.tabsLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsLocation.SuspendLayout()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraStatusBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pgDescription
        '
        Me.pgDescription.Controls.Add(Me.txtShortDesc)
        Me.pgDescription.Controls.Add(Me.txtLongDesc)
        Me.pgDescription.Controls.Add(Me.lblLongDesc)
        Me.pgDescription.Controls.Add(Me.lblShortDesc)
        Me.pgDescription.Location = New System.Drawing.Point(-10000, -10000)
        Me.pgDescription.Name = "pgDescription"
        Me.pgDescription.Size = New System.Drawing.Size(566, 445)
        '
        'txtShortDesc
        '
        Me.txtShortDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShortDesc.Location = New System.Drawing.Point(118, 16)
        Me.txtShortDesc.Name = "txtShortDesc"
        Me.txtShortDesc.Size = New System.Drawing.Size(428, 22)
        Me.txtShortDesc.TabIndex = 1
        '
        'txtLongDesc
        '
        Me.txtLongDesc.AllowAlternateDescriptions = True
        Me.txtLongDesc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLongDesc.BackColor = System.Drawing.Color.Transparent
        Me.txtLongDesc.FirstTabHasRestrictions = False
        Me.txtLongDesc.Location = New System.Drawing.Point(16, 72)
        Me.txtLongDesc.Name = "txtLongDesc"
        Me.txtLongDesc.sCommand = Nothing
        Me.txtLongDesc.Size = New System.Drawing.Size(530, 363)
        Me.txtLongDesc.TabIndex = 2
        '
        'lblLongDesc
        '
        Me.lblLongDesc.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblLongDesc.Location = New System.Drawing.Point(16, 51)
        Me.lblLongDesc.Name = "lblLongDesc"
        Me.lblLongDesc.Size = New System.Drawing.Size(128, 16)
        Me.lblLongDesc.TabIndex = 2
        Me.lblLongDesc.Text = "Long description:"
        '
        'lblShortDesc
        '
        Me.lblShortDesc.BackColorInternal = System.Drawing.Color.Transparent
        Me.lblShortDesc.Location = New System.Drawing.Point(16, 19)
        Me.lblShortDesc.Name = "lblShortDesc"
        Me.lblShortDesc.Size = New System.Drawing.Size(128, 16)
        Me.lblShortDesc.TabIndex = 0
        Me.lblShortDesc.Text = "Short description:"
        '
        'pgDirections
        '
        Me.pgDirections.Controls.Add(Me.lblOut)
        Me.pgDirections.Controls.Add(Me.lblIn)
        Me.pgDirections.Controls.Add(Me.lblDown)
        Me.pgDirections.Controls.Add(Me.lblUp)
        Me.pgDirections.Controls.Add(Me.lblNorthWest)
        Me.pgDirections.Controls.Add(Me.lblWest)
        Me.pgDirections.Controls.Add(Me.lblSouthWest)
        Me.pgDirections.Controls.Add(Me.lblSouth)
        Me.pgDirections.Controls.Add(Me.lblSouthEast)
        Me.pgDirections.Controls.Add(Me.lblEast)
        Me.pgDirections.Controls.Add(Me.lblNorthEast)
        Me.pgDirections.Controls.Add(Me.lblNorth)
        Me.pgDirections.Controls.Add(Me.RestrictOut)
        Me.pgDirections.Controls.Add(Me.RestrictIn)
        Me.pgDirections.Controls.Add(Me.RestrictDown)
        Me.pgDirections.Controls.Add(Me.RestrictUp)
        Me.pgDirections.Controls.Add(Me.RestrictNorthWest)
        Me.pgDirections.Controls.Add(Me.RestrictWest)
        Me.pgDirections.Controls.Add(Me.RestrictSouthWest)
        Me.pgDirections.Controls.Add(Me.RestrictSouth)
        Me.pgDirections.Controls.Add(Me.RestrictSouthEast)
        Me.pgDirections.Controls.Add(Me.RestrictEast)
        Me.pgDirections.Controls.Add(Me.RestrictNorthEast)
        Me.pgDirections.Controls.Add(Me.RestrictNorth)
        Me.pgDirections.Controls.Add(Me.cmbOut)
        Me.pgDirections.Controls.Add(Me.cmbIn)
        Me.pgDirections.Controls.Add(Me.cmbDown)
        Me.pgDirections.Controls.Add(Me.cmbUp)
        Me.pgDirections.Controls.Add(Me.cmbNorthWest)
        Me.pgDirections.Controls.Add(Me.cmbWest)
        Me.pgDirections.Controls.Add(Me.cmbSouthWest)
        Me.pgDirections.Controls.Add(Me.cmbSouth)
        Me.pgDirections.Controls.Add(Me.cmbSouthEast)
        Me.pgDirections.Controls.Add(Me.cmbEast)
        Me.pgDirections.Controls.Add(Me.cmbNorthEast)
        Me.pgDirections.Controls.Add(Me.cmbNorth)
        Me.pgDirections.Controls.Add(Me.lblRestrictions)
        Me.pgDirections.Controls.Add(Me.lblLocation)
        Me.pgDirections.Controls.Add(Me.lblDirection)
        Me.pgDirections.Location = New System.Drawing.Point(-10000, -10000)
        Me.pgDirections.Name = "pgDirections"
        Me.pgDirections.Size = New System.Drawing.Size(566, 445)
        '
        'lblOut
        '
        Me.lblOut.AutoSize = True
        Me.lblOut.BackColor = System.Drawing.Color.Transparent
        Me.lblOut.LinkArea = New System.Windows.Forms.LinkArea(5, 3)
        Me.lblOut.LinkColor = System.Drawing.Color.DarkBlue
        Me.lblOut.Location = New System.Drawing.Point(11, 412)
        Me.lblOut.Name = "lblOut"
        Me.lblOut.Size = New System.Drawing.Size(66, 17)
        Me.lblOut.TabIndex = 63
        Me.lblOut.TabStop = True
        Me.lblOut.Text = "Move Out to"
        Me.lblOut.UseCompatibleTextRendering = True
        '
        'lblIn
        '
        Me.lblIn.AutoSize = True
        Me.lblIn.BackColor = System.Drawing.Color.Transparent
        Me.lblIn.LinkArea = New System.Windows.Forms.LinkArea(5, 2)
        Me.lblIn.LinkColor = System.Drawing.Color.DarkBlue
        Me.lblIn.Location = New System.Drawing.Point(11, 380)
        Me.lblIn.Name = "lblIn"
        Me.lblIn.Size = New System.Drawing.Size(57, 17)
        Me.lblIn.TabIndex = 62
        Me.lblIn.TabStop = True
        Me.lblIn.Text = "Move In to"
        Me.lblIn.UseCompatibleTextRendering = True
        '
        'lblDown
        '
        Me.lblDown.AutoSize = True
        Me.lblDown.BackColor = System.Drawing.Color.Transparent
        Me.lblDown.LinkArea = New System.Windows.Forms.LinkArea(5, 4)
        Me.lblDown.LinkColor = System.Drawing.Color.DarkBlue
        Me.lblDown.Location = New System.Drawing.Point(11, 348)
        Me.lblDown.Name = "lblDown"
        Me.lblDown.Size = New System.Drawing.Size(76, 17)
        Me.lblDown.TabIndex = 61
        Me.lblDown.TabStop = True
        Me.lblDown.Text = "Move Down to"
        Me.lblDown.UseCompatibleTextRendering = True
        '
        'lblUp
        '
        Me.lblUp.AutoSize = True
        Me.lblUp.BackColor = System.Drawing.Color.Transparent
        Me.lblUp.LinkArea = New System.Windows.Forms.LinkArea(5, 2)
        Me.lblUp.LinkColor = System.Drawing.Color.DarkBlue
        Me.lblUp.Location = New System.Drawing.Point(11, 316)
        Me.lblUp.Name = "lblUp"
        Me.lblUp.Size = New System.Drawing.Size(62, 17)
        Me.lblUp.TabIndex = 60
        Me.lblUp.TabStop = True
        Me.lblUp.Text = "Move Up to"
        Me.lblUp.UseCompatibleTextRendering = True
        '
        'lblNorthWest
        '
        Me.lblNorthWest.AutoSize = True
        Me.lblNorthWest.BackColor = System.Drawing.Color.Transparent
        Me.lblNorthWest.LinkArea = New System.Windows.Forms.LinkArea(5, 9)
        Me.lblNorthWest.LinkColor = System.Drawing.Color.DarkBlue
        Me.lblNorthWest.Location = New System.Drawing.Point(11, 284)
        Me.lblNorthWest.Name = "lblNorthWest"
        Me.lblNorthWest.Size = New System.Drawing.Size(101, 17)
        Me.lblNorthWest.TabIndex = 59
        Me.lblNorthWest.TabStop = True
        Me.lblNorthWest.Text = "Move NorthWest to"
        Me.lblNorthWest.UseCompatibleTextRendering = True
        '
        'lblWest
        '
        Me.lblWest.AutoSize = True
        Me.lblWest.BackColor = System.Drawing.Color.Transparent
        Me.lblWest.LinkArea = New System.Windows.Forms.LinkArea(5, 4)
        Me.lblWest.LinkColor = System.Drawing.Color.DarkBlue
        Me.lblWest.Location = New System.Drawing.Point(11, 252)
        Me.lblWest.Name = "lblWest"
        Me.lblWest.Size = New System.Drawing.Size(73, 17)
        Me.lblWest.TabIndex = 58
        Me.lblWest.TabStop = True
        Me.lblWest.Text = "Move West to"
        Me.lblWest.UseCompatibleTextRendering = True
        '
        'lblSouthWest
        '
        Me.lblSouthWest.AutoSize = True
        Me.lblSouthWest.BackColor = System.Drawing.Color.Transparent
        Me.lblSouthWest.LinkArea = New System.Windows.Forms.LinkArea(5, 9)
        Me.lblSouthWest.LinkColor = System.Drawing.Color.DarkBlue
        Me.lblSouthWest.Location = New System.Drawing.Point(11, 220)
        Me.lblSouthWest.Name = "lblSouthWest"
        Me.lblSouthWest.Size = New System.Drawing.Size(103, 17)
        Me.lblSouthWest.TabIndex = 57
        Me.lblSouthWest.TabStop = True
        Me.lblSouthWest.Text = "Move SouthWest to"
        Me.lblSouthWest.UseCompatibleTextRendering = True
        '
        'lblSouth
        '
        Me.lblSouth.AutoSize = True
        Me.lblSouth.BackColor = System.Drawing.Color.Transparent
        Me.lblSouth.LinkArea = New System.Windows.Forms.LinkArea(5, 5)
        Me.lblSouth.LinkColor = System.Drawing.Color.DarkBlue
        Me.lblSouth.Location = New System.Drawing.Point(11, 188)
        Me.lblSouth.Name = "lblSouth"
        Me.lblSouth.Size = New System.Drawing.Size(77, 17)
        Me.lblSouth.TabIndex = 56
        Me.lblSouth.TabStop = True
        Me.lblSouth.Text = "Move South to"
        Me.lblSouth.UseCompatibleTextRendering = True
        '
        'lblSouthEast
        '
        Me.lblSouthEast.AutoSize = True
        Me.lblSouthEast.BackColor = System.Drawing.Color.Transparent
        Me.lblSouthEast.LinkArea = New System.Windows.Forms.LinkArea(5, 9)
        Me.lblSouthEast.LinkColor = System.Drawing.Color.DarkBlue
        Me.lblSouthEast.Location = New System.Drawing.Point(11, 156)
        Me.lblSouthEast.Name = "lblSouthEast"
        Me.lblSouthEast.Size = New System.Drawing.Size(100, 17)
        Me.lblSouthEast.TabIndex = 55
        Me.lblSouthEast.TabStop = True
        Me.lblSouthEast.Text = "Move SouthEast to"
        Me.lblSouthEast.UseCompatibleTextRendering = True
        '
        'lblEast
        '
        Me.lblEast.AutoSize = True
        Me.lblEast.BackColor = System.Drawing.Color.Transparent
        Me.lblEast.LinkArea = New System.Windows.Forms.LinkArea(5, 4)
        Me.lblEast.LinkColor = System.Drawing.Color.DarkBlue
        Me.lblEast.Location = New System.Drawing.Point(11, 124)
        Me.lblEast.Name = "lblEast"
        Me.lblEast.Size = New System.Drawing.Size(70, 17)
        Me.lblEast.TabIndex = 54
        Me.lblEast.TabStop = True
        Me.lblEast.Text = "Move East to"
        Me.lblEast.UseCompatibleTextRendering = True
        '
        'lblNorthEast
        '
        Me.lblNorthEast.AutoSize = True
        Me.lblNorthEast.BackColor = System.Drawing.Color.Transparent
        Me.lblNorthEast.LinkArea = New System.Windows.Forms.LinkArea(5, 9)
        Me.lblNorthEast.LinkColor = System.Drawing.Color.DarkBlue
        Me.lblNorthEast.Location = New System.Drawing.Point(11, 92)
        Me.lblNorthEast.Name = "lblNorthEast"
        Me.lblNorthEast.Size = New System.Drawing.Size(98, 17)
        Me.lblNorthEast.TabIndex = 53
        Me.lblNorthEast.TabStop = True
        Me.lblNorthEast.Text = "Move NorthEast to"
        Me.lblNorthEast.UseCompatibleTextRendering = True
        '
        'lblNorth
        '
        Me.lblNorth.AutoSize = True
        Me.lblNorth.BackColor = System.Drawing.Color.Transparent
        Me.lblNorth.LinkArea = New System.Windows.Forms.LinkArea(5, 5)
        Me.lblNorth.LinkColor = System.Drawing.Color.DarkBlue
        Me.lblNorth.Location = New System.Drawing.Point(11, 61)
        Me.lblNorth.Name = "lblNorth"
        Me.lblNorth.Size = New System.Drawing.Size(75, 17)
        Me.lblNorth.TabIndex = 52
        Me.lblNorth.TabStop = True
        Me.lblNorth.Text = "Move North to"
        Me.lblNorth.UseCompatibleTextRendering = True
        '
        'RestrictOut
        '
        Me.RestrictOut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictOut.BackColor = System.Drawing.Color.Transparent
        Me.RestrictOut.Location = New System.Drawing.Point(326, 408)
        Me.RestrictOut.Name = "RestrictOut"
        Me.RestrictOut.Size = New System.Drawing.Size(234, 21)
        Me.RestrictOut.TabIndex = 38
        '
        'RestrictIn
        '
        Me.RestrictIn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictIn.BackColor = System.Drawing.Color.Transparent
        Me.RestrictIn.Location = New System.Drawing.Point(326, 376)
        Me.RestrictIn.Name = "RestrictIn"
        Me.RestrictIn.Size = New System.Drawing.Size(234, 21)
        Me.RestrictIn.TabIndex = 35
        '
        'RestrictDown
        '
        Me.RestrictDown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictDown.BackColor = System.Drawing.Color.Transparent
        Me.RestrictDown.Location = New System.Drawing.Point(326, 344)
        Me.RestrictDown.Name = "RestrictDown"
        Me.RestrictDown.Size = New System.Drawing.Size(234, 21)
        Me.RestrictDown.TabIndex = 32
        '
        'RestrictUp
        '
        Me.RestrictUp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictUp.BackColor = System.Drawing.Color.Transparent
        Me.RestrictUp.Location = New System.Drawing.Point(326, 312)
        Me.RestrictUp.Name = "RestrictUp"
        Me.RestrictUp.Size = New System.Drawing.Size(234, 21)
        Me.RestrictUp.TabIndex = 29
        '
        'RestrictNorthWest
        '
        Me.RestrictNorthWest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictNorthWest.BackColor = System.Drawing.Color.Transparent
        Me.RestrictNorthWest.Location = New System.Drawing.Point(326, 280)
        Me.RestrictNorthWest.Name = "RestrictNorthWest"
        Me.RestrictNorthWest.Size = New System.Drawing.Size(234, 21)
        Me.RestrictNorthWest.TabIndex = 26
        '
        'RestrictWest
        '
        Me.RestrictWest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictWest.BackColor = System.Drawing.Color.Transparent
        Me.RestrictWest.Location = New System.Drawing.Point(326, 248)
        Me.RestrictWest.Name = "RestrictWest"
        Me.RestrictWest.Size = New System.Drawing.Size(234, 21)
        Me.RestrictWest.TabIndex = 23
        '
        'RestrictSouthWest
        '
        Me.RestrictSouthWest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictSouthWest.BackColor = System.Drawing.Color.Transparent
        Me.RestrictSouthWest.Location = New System.Drawing.Point(326, 216)
        Me.RestrictSouthWest.Name = "RestrictSouthWest"
        Me.RestrictSouthWest.Size = New System.Drawing.Size(234, 21)
        Me.RestrictSouthWest.TabIndex = 20
        '
        'RestrictSouth
        '
        Me.RestrictSouth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictSouth.BackColor = System.Drawing.Color.Transparent
        Me.RestrictSouth.Location = New System.Drawing.Point(326, 184)
        Me.RestrictSouth.Name = "RestrictSouth"
        Me.RestrictSouth.Size = New System.Drawing.Size(234, 21)
        Me.RestrictSouth.TabIndex = 17
        '
        'RestrictSouthEast
        '
        Me.RestrictSouthEast.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictSouthEast.BackColor = System.Drawing.Color.Transparent
        Me.RestrictSouthEast.Location = New System.Drawing.Point(326, 152)
        Me.RestrictSouthEast.Name = "RestrictSouthEast"
        Me.RestrictSouthEast.Size = New System.Drawing.Size(234, 21)
        Me.RestrictSouthEast.TabIndex = 14
        '
        'RestrictEast
        '
        Me.RestrictEast.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictEast.BackColor = System.Drawing.Color.Transparent
        Me.RestrictEast.Location = New System.Drawing.Point(326, 120)
        Me.RestrictEast.Name = "RestrictEast"
        Me.RestrictEast.Size = New System.Drawing.Size(234, 21)
        Me.RestrictEast.TabIndex = 11
        '
        'RestrictNorthEast
        '
        Me.RestrictNorthEast.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictNorthEast.BackColor = System.Drawing.Color.Transparent
        Me.RestrictNorthEast.Location = New System.Drawing.Point(326, 88)
        Me.RestrictNorthEast.Name = "RestrictNorthEast"
        Me.RestrictNorthEast.Size = New System.Drawing.Size(234, 21)
        Me.RestrictNorthEast.TabIndex = 8
        '
        'RestrictNorth
        '
        Me.RestrictNorth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RestrictNorth.BackColor = System.Drawing.Color.Transparent
        Me.RestrictNorth.Location = New System.Drawing.Point(326, 56)
        Me.RestrictNorth.Name = "RestrictNorth"
        Me.RestrictNorth.Size = New System.Drawing.Size(234, 21)
        Me.RestrictNorth.TabIndex = 5
        '
        'cmbOut
        '
        Me.cmbOut.AllowAddEdit = True
        Me.cmbOut.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.cmbOut.AllowHidden = False
        Me.cmbOut.BackColor = System.Drawing.Color.Transparent
        Me.cmbOut.Key = Nothing
        Me.cmbOut.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.cmbOut.Location = New System.Drawing.Point(111, 408)
        Me.cmbOut.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbOut.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbOut.Name = "cmbOut"
        Me.cmbOut.RestrictProperty = Nothing
        Me.cmbOut.Size = New System.Drawing.Size(207, 21)
        Me.cmbOut.TabIndex = 51
        '
        'cmbIn
        '
        Me.cmbIn.AllowAddEdit = True
        Me.cmbIn.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.cmbIn.AllowHidden = False
        Me.cmbIn.BackColor = System.Drawing.Color.Transparent
        Me.cmbIn.Key = Nothing
        Me.cmbIn.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.cmbIn.Location = New System.Drawing.Point(111, 376)
        Me.cmbIn.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbIn.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbIn.Name = "cmbIn"
        Me.cmbIn.RestrictProperty = Nothing
        Me.cmbIn.Size = New System.Drawing.Size(207, 21)
        Me.cmbIn.TabIndex = 50
        '
        'cmbDown
        '
        Me.cmbDown.AllowAddEdit = True
        Me.cmbDown.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.cmbDown.AllowHidden = False
        Me.cmbDown.BackColor = System.Drawing.Color.Transparent
        Me.cmbDown.Key = Nothing
        Me.cmbDown.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.cmbDown.Location = New System.Drawing.Point(111, 344)
        Me.cmbDown.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbDown.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbDown.Name = "cmbDown"
        Me.cmbDown.RestrictProperty = Nothing
        Me.cmbDown.Size = New System.Drawing.Size(207, 21)
        Me.cmbDown.TabIndex = 49
        '
        'cmbUp
        '
        Me.cmbUp.AllowAddEdit = True
        Me.cmbUp.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.cmbUp.AllowHidden = False
        Me.cmbUp.BackColor = System.Drawing.Color.Transparent
        Me.cmbUp.Key = Nothing
        Me.cmbUp.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.cmbUp.Location = New System.Drawing.Point(111, 312)
        Me.cmbUp.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbUp.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbUp.Name = "cmbUp"
        Me.cmbUp.RestrictProperty = Nothing
        Me.cmbUp.Size = New System.Drawing.Size(207, 21)
        Me.cmbUp.TabIndex = 48
        '
        'cmbNorthWest
        '
        Me.cmbNorthWest.AllowAddEdit = True
        Me.cmbNorthWest.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.cmbNorthWest.AllowHidden = False
        Me.cmbNorthWest.BackColor = System.Drawing.Color.Transparent
        Me.cmbNorthWest.Key = Nothing
        Me.cmbNorthWest.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.cmbNorthWest.Location = New System.Drawing.Point(111, 280)
        Me.cmbNorthWest.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbNorthWest.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbNorthWest.Name = "cmbNorthWest"
        Me.cmbNorthWest.RestrictProperty = Nothing
        Me.cmbNorthWest.Size = New System.Drawing.Size(207, 21)
        Me.cmbNorthWest.TabIndex = 47
        '
        'cmbWest
        '
        Me.cmbWest.AllowAddEdit = True
        Me.cmbWest.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.cmbWest.AllowHidden = False
        Me.cmbWest.BackColor = System.Drawing.Color.Transparent
        Me.cmbWest.Key = Nothing
        Me.cmbWest.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.cmbWest.Location = New System.Drawing.Point(111, 248)
        Me.cmbWest.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbWest.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbWest.Name = "cmbWest"
        Me.cmbWest.RestrictProperty = Nothing
        Me.cmbWest.Size = New System.Drawing.Size(207, 21)
        Me.cmbWest.TabIndex = 46
        '
        'cmbSouthWest
        '
        Me.cmbSouthWest.AllowAddEdit = True
        Me.cmbSouthWest.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.cmbSouthWest.AllowHidden = False
        Me.cmbSouthWest.BackColor = System.Drawing.Color.Transparent
        Me.cmbSouthWest.Key = Nothing
        Me.cmbSouthWest.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.cmbSouthWest.Location = New System.Drawing.Point(111, 216)
        Me.cmbSouthWest.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbSouthWest.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbSouthWest.Name = "cmbSouthWest"
        Me.cmbSouthWest.RestrictProperty = Nothing
        Me.cmbSouthWest.Size = New System.Drawing.Size(207, 21)
        Me.cmbSouthWest.TabIndex = 45
        '
        'cmbSouth
        '
        Me.cmbSouth.AllowAddEdit = True
        Me.cmbSouth.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.cmbSouth.AllowHidden = False
        Me.cmbSouth.BackColor = System.Drawing.Color.Transparent
        Me.cmbSouth.Key = Nothing
        Me.cmbSouth.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.cmbSouth.Location = New System.Drawing.Point(111, 184)
        Me.cmbSouth.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbSouth.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbSouth.Name = "cmbSouth"
        Me.cmbSouth.RestrictProperty = Nothing
        Me.cmbSouth.Size = New System.Drawing.Size(207, 21)
        Me.cmbSouth.TabIndex = 44
        '
        'cmbSouthEast
        '
        Me.cmbSouthEast.AllowAddEdit = True
        Me.cmbSouthEast.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.cmbSouthEast.AllowHidden = False
        Me.cmbSouthEast.BackColor = System.Drawing.Color.Transparent
        Me.cmbSouthEast.Key = Nothing
        Me.cmbSouthEast.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.cmbSouthEast.Location = New System.Drawing.Point(111, 152)
        Me.cmbSouthEast.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbSouthEast.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbSouthEast.Name = "cmbSouthEast"
        Me.cmbSouthEast.RestrictProperty = Nothing
        Me.cmbSouthEast.Size = New System.Drawing.Size(207, 21)
        Me.cmbSouthEast.TabIndex = 43
        '
        'cmbEast
        '
        Me.cmbEast.AllowAddEdit = True
        Me.cmbEast.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.cmbEast.AllowHidden = False
        Me.cmbEast.BackColor = System.Drawing.Color.Transparent
        Me.cmbEast.Key = Nothing
        Me.cmbEast.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.cmbEast.Location = New System.Drawing.Point(111, 120)
        Me.cmbEast.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbEast.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbEast.Name = "cmbEast"
        Me.cmbEast.RestrictProperty = Nothing
        Me.cmbEast.Size = New System.Drawing.Size(207, 21)
        Me.cmbEast.TabIndex = 42
        '
        'cmbNorthEast
        '
        Me.cmbNorthEast.AllowAddEdit = True
        Me.cmbNorthEast.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.cmbNorthEast.AllowHidden = False
        Me.cmbNorthEast.BackColor = System.Drawing.Color.Transparent
        Me.cmbNorthEast.Key = Nothing
        Me.cmbNorthEast.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.cmbNorthEast.Location = New System.Drawing.Point(111, 88)
        Me.cmbNorthEast.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbNorthEast.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbNorthEast.Name = "cmbNorthEast"
        Me.cmbNorthEast.RestrictProperty = Nothing
        Me.cmbNorthEast.Size = New System.Drawing.Size(207, 21)
        Me.cmbNorthEast.TabIndex = 41
        '
        'cmbNorth
        '
        Me.cmbNorth.AllowAddEdit = True
        Me.cmbNorth.AllowedListType = CType((ADRIFT.ItemSelector.ItemEnum.Location Or ADRIFT.ItemSelector.ItemEnum.LocationGroup), ADRIFT.ItemSelector.ItemEnum)
        Me.cmbNorth.AllowHidden = False
        Me.cmbNorth.BackColor = System.Drawing.Color.Transparent
        Me.cmbNorth.Key = Nothing
        Me.cmbNorth.ListType = ADRIFT.ItemSelector.ItemEnum.Location
        Me.cmbNorth.Location = New System.Drawing.Point(111, 56)
        Me.cmbNorth.MaximumSize = New System.Drawing.Size(1000, 21)
        Me.cmbNorth.MinimumSize = New System.Drawing.Size(10, 21)
        Me.cmbNorth.Name = "cmbNorth"
        Me.cmbNorth.RestrictProperty = Nothing
        Me.cmbNorth.Size = New System.Drawing.Size(207, 21)
        Me.cmbNorth.TabIndex = 40
        '
        'lblRestrictions
        '
        Me.lblRestrictions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRestrictions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRestrictions.Location = New System.Drawing.Point(326, 24)
        Me.lblRestrictions.Name = "lblRestrictions"
        Me.lblRestrictions.Size = New System.Drawing.Size(216, 20)
        Me.lblRestrictions.TabIndex = 4
        Me.lblRestrictions.Text = "Restrictions"
        Me.lblRestrictions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLocation
        '
        Me.lblLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLocation.Location = New System.Drawing.Point(133, 24)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(161, 20)
        Me.lblLocation.TabIndex = 3
        Me.lblLocation.Text = "Location"
        Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDirection
        '
        Me.lblDirection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDirection.Location = New System.Drawing.Point(11, 24)
        Me.lblDirection.Name = "lblDirection"
        Me.lblDirection.Size = New System.Drawing.Size(96, 20)
        Me.lblDirection.TabIndex = 2
        Me.lblDirection.Text = "Direction"
        Me.lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Properties1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(566, 445)
        '
        'Properties1
        '
        Me.Properties1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Properties1.BackColor = System.Drawing.Color.Transparent
        Me.Properties1.Location = New System.Drawing.Point(8, 8)
        Me.Properties1.Name = "Properties1"
        Me.Properties1.Size = New System.Drawing.Size(551, 434)
        Me.Properties1.TabIndex = 1
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.btnAddCharacter)
        Me.UltraTabPageControl2.Controls.Add(Me.btnAddDynamicOb)
        Me.UltraTabPageControl2.Controls.Add(Me.btnRemoveItem)
        Me.UltraTabPageControl2.Controls.Add(Me.Folder1)
        Me.UltraTabPageControl2.Controls.Add(Me.btnAddObject)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(566, 445)
        '
        'btnAddCharacter
        '
        Me.btnAddCharacter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.Image = Global.ADRIFT.My.Resources.imgCharacter16
        Me.btnAddCharacter.Appearance = Appearance1
        Me.btnAddCharacter.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Me.btnAddCharacter.Location = New System.Drawing.Point(297, 413)
        Me.btnAddCharacter.Name = "btnAddCharacter"
        Me.btnAddCharacter.Size = New System.Drawing.Size(122, 25)
        Me.btnAddCharacter.TabIndex = 10
        Me.btnAddCharacter.Text = "Add Character"
        Me.ToolTip1.SetToolTip(Me.btnAddCharacter, "Add Character to this Location")
        '
        'btnAddDynamicOb
        '
        Me.btnAddDynamicOb.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.Image = Global.ADRIFT.My.Resources.imgObjectDynamic16
        Me.btnAddDynamicOb.Appearance = Appearance2
        Me.btnAddDynamicOb.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Me.btnAddDynamicOb.Location = New System.Drawing.Point(148, 413)
        Me.btnAddDynamicOb.Name = "btnAddDynamicOb"
        Me.btnAddDynamicOb.Size = New System.Drawing.Size(143, 25)
        Me.btnAddDynamicOb.TabIndex = 9
        Me.btnAddDynamicOb.Text = "Add Dynamic Object"
        Me.ToolTip1.SetToolTip(Me.btnAddDynamicOb, "Add Dynamic Object to this Location")
        '
        'btnRemoveItem
        '
        Me.btnRemoveItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.Image = Global.ADRIFT.My.Resources.imgDelete
        Me.btnRemoveItem.Appearance = Appearance3
        Me.btnRemoveItem.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Me.btnRemoveItem.Location = New System.Drawing.Point(425, 413)
        Me.btnRemoveItem.Name = "btnRemoveItem"
        Me.btnRemoveItem.Size = New System.Drawing.Size(134, 25)
        Me.btnRemoveItem.TabIndex = 8
        Me.btnRemoveItem.Text = "Remove Item(s)"
        '
        'Folder1
        '
        Me.Folder1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Folder1.folder = Nothing
        Me.Folder1.Location = New System.Drawing.Point(8, 8)
        Me.Folder1.Name = "Folder1"
        Me.Folder1.Size = New System.Drawing.Size(551, 402)
        Me.Folder1.TabIndex = 7
        Me.Folder1.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List
        '
        'btnAddObject
        '
        Me.btnAddObject.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.Image = Global.ADRIFT.My.Resources.imgObjectStatic16
        Me.btnAddObject.Appearance = Appearance4
        Me.btnAddObject.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Me.btnAddObject.Location = New System.Drawing.Point(8, 413)
        Me.btnAddObject.Name = "btnAddObject"
        Me.btnAddObject.Size = New System.Drawing.Size(134, 25)
        Me.btnAddObject.TabIndex = 6
        Me.btnAddObject.Text = "Add Static Object"
        Me.ToolTip1.SetToolTip(Me.btnAddObject, "Add Static Object to this Location")
        '
        'chkHideOnMap
        '
        Me.chkHideOnMap.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkHideOnMap.AutoSize = True
        Me.chkHideOnMap.BackColor = System.Drawing.Color.Transparent
        Me.chkHideOnMap.Location = New System.Drawing.Point(13, 18)
        Me.chkHideOnMap.Name = "chkHideOnMap"
        Me.chkHideOnMap.Size = New System.Drawing.Size(131, 17)
        Me.chkHideOnMap.TabIndex = 34
        Me.chkHideOnMap.Text = "Hide Location on Map"
        Me.chkHideOnMap.UseVisualStyleBackColor = False
        '
        'tabsLocation
        '
        Me.tabsLocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabsLocation.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabsLocation.Controls.Add(Me.pgDescription)
        Me.tabsLocation.Controls.Add(Me.pgDirections)
        Me.tabsLocation.Controls.Add(Me.UltraTabPageControl1)
        Me.tabsLocation.Controls.Add(Me.UltraTabPageControl2)
        Me.tabsLocation.Location = New System.Drawing.Point(0, 0)
        Me.tabsLocation.Name = "tabsLocation"
        Me.tabsLocation.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabsLocation.Size = New System.Drawing.Size(568, 468)
        Me.tabsLocation.TabIndex = 0
        UltraTab1.Key = "tabDescription"
        UltraTab1.TabPage = Me.pgDescription
        UltraTab1.Text = "Description"
        UltraTab2.Key = "tabDirections"
        UltraTab2.TabPage = Me.pgDirections
        UltraTab2.Text = "Directions"
        UltraTab3.Key = "tabProperties"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "Properties"
        UltraTab4.Key = "tabContents"
        UltraTab4.TabPage = Me.UltraTabPageControl2
        UltraTab4.Text = "Contents"
        Me.tabsLocation.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3, UltraTab4})
        Me.tabsLocation.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(566, 445)
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(464, 472)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(88, 32)
        Me.btnApply.TabIndex = 15
        Me.btnApply.Text = "Apply"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(272, 472)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Controls.Add(Me.chkHideOnMap)
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 462)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        UltraStatusPanel1.Control = Me.chkHideOnMap
        UltraStatusPanel1.Padding = New System.Drawing.Size(12, 12)
        UltraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer
        UltraStatusPanel1.Width = 160
        Me.UltraStatusBar1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1})
        Me.UltraStatusBar1.Size = New System.Drawing.Size(568, 48)
        Me.UltraStatusBar1.TabIndex = 12
        Me.UltraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(368, 472)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'frmLocation
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(568, 510)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.UltraStatusBar1)
        Me.Controls.Add(Me.tabsLocation)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(576, 544)
        Me.Name = "frmLocation"
        Me.ShowInTaskbar = False
        Me.Text = "Location - "
        Me.pgDescription.ResumeLayout(False)
        Me.pgDirections.ResumeLayout(False)
        Me.pgDirections.PerformLayout()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.tabsLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsLocation.ResumeLayout(False)
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraStatusBar1.ResumeLayout(False)
        Me.UltraStatusBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private bChanged As Boolean
    Private cLocation As clsLocation
    Private arlCombos As New ArrayList
    Private arlRestrictions As New ArrayList


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


    ' Returns True if map ok, or False if we have created an overlap somewhere
    Private Function CheckMapValid() As Boolean

    End Function


    Private Function ValidateLocation() As Boolean
        If txtShortDesc.Text = "" Then
            MessageBox.Show("You must give the location a short description.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabsLocation.SelectedTab = tabsLocation.Tabs("tabDescription")
            txtShortDesc.Focus()
            Return False
        End If
        If Not Properties1.ValidateProperties Then
            tabsLocation.SelectedTab = tabsLocation.Tabs("tabProperties")
            Return False
        End If
        Return True
    End Function


    Public Function ApplyLocation() As Boolean

        If Not ValidateLocation() Then Return False

        With cLocation
            .ShortDescription = txtShortDesc.Description.Copy
            .LongDescription = txtLongDesc.Description.Copy

            For eDirection As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest
                Dim cmbDir As ADRIFT.ItemSelector = CType(arlCombos(eDirection), ADRIFT.ItemSelector)
                Dim Rest As ADRIFT.RestrictSummary = CType(arlRestrictions(eDirection), ADRIFT.RestrictSummary)
                If cmbDir.Key <> "" Then
                    .arlDirections(eDirection).LocationKey = cmbDir.Key
                Else
                    .arlDirections(eDirection).LocationKey = Nothing
                End If
                .arlDirections(eDirection).Restrictions = Rest.arlRestrictions
            Next

            .LastUpdated = Now
            .IsLibrary = False
            .htblActualProperties = Me.Properties1.htblProperties.CopySelected
            .HideOnMap = chkHideOnMap.Checked

            If .Key = "" Then
                .Key = .GetNewKey ' Adventure.GetNewKey("Location")
                Adventure.htblLocations.Add(cLocation, .Key)
                Folder1.sParentKey = .Key
                Me.Properties1.OwnerKey = .Key
            End If

            UpdateListItem(.Key, .ShortDescription.ToString)
            btnAddObject.Enabled = True
            btnAddDynamicOb.Enabled = True
            btnAddCharacter.Enabled = True

            ' Check reciprocal directions
            For eDirection As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest
                If .arlDirections(eDirection).LocationKey <> "" AndAlso Adventure.htblLocations.ContainsKey(.arlDirections(eDirection).LocationKey) Then
                    If Adventure.htblLocations(.arlDirections(eDirection).LocationKey).arlDirections(OppositeDirection(eDirection)).LocationKey = "" Then
                        Select Case YesNoCancel("Would you also like to move " & DirectionName(OppositeDirection(eDirection)) & " from " & Adventure.htblLocations(.arlDirections(eDirection).LocationKey).ShortDescription.ToString & " to " & .ShortDescription.ToString & "?", "Add reciprocal link", "ReciprocalLink")
                            Case Windows.Forms.DialogResult.Yes
                                Adventure.htblLocations(.arlDirections(eDirection).LocationKey).arlDirections(OppositeDirection(eDirection)).LocationKey = .Key
                            Case Windows.Forms.DialogResult.No
                                ' Leave as is
                            Case Windows.Forms.DialogResult.Cancel
                                Return False
                        End Select
                        'If MessageBox.Show("Would you also like to move " & OppositeDirection(eDirection).ToString & " from " & Adventure.htblLocations(.arlDirections(eDirection).LocationKey).ShortDescription & " to " & .ShortDescription & "?", "Add reciprocal link", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        '    Adventure.htblLocations(.arlDirections(eDirection).LocationKey).arlDirections(OppositeDirection(eDirection)).LocationKey = .Key
                        'End If
                    End If
                    If Adventure.htblLocations(.arlDirections(eDirection).LocationKey).arlDirections(OppositeDirection(eDirection)).LocationKey = .Key AndAlso .arlDirections(eDirection).Restrictions.Count > 0 AndAlso Adventure.htblLocations(.arlDirections(eDirection).LocationKey).arlDirections(OppositeDirection(eDirection)).Restrictions.Count = 0 Then
                        Select Case YesNoCancel("Would you like to copy the restrictions between " & Adventure.htblLocations(.arlDirections(eDirection).LocationKey).ShortDescription.ToString & " and " & .ShortDescription.ToString & " to " & Adventure.htblLocations(.arlDirections(eDirection).LocationKey).ShortDescription.ToString & "?", "Add reciprocal restriction", "ReciprocalRestriction")
                            Case Windows.Forms.DialogResult.Yes
                                Adventure.htblLocations(.arlDirections(eDirection).LocationKey).arlDirections(OppositeDirection(eDirection)).Restrictions = .arlDirections(eDirection).Restrictions.Copy
                            Case Windows.Forms.DialogResult.No
                                ' Leave as is   
                            Case Windows.Forms.DialogResult.Cancel
                                Return False
                        End Select
                        'If MessageBox.Show("Would you like to copy the restrictions between " & Adventure.htblLocations(.arlDirections(eDirection).LocationKey).ShortDescription & " and " & .ShortDescription & " to " & Adventure.htblLocations(.arlDirections(eDirection).LocationKey).ShortDescription & "?", "Add reciprocal restriction", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        '    Adventure.htblLocations(.arlDirections(eDirection).LocationKey).arlDirections(OppositeDirection(eDirection)).Restrictions = .arlDirections(eDirection).Restrictions.Copy
                        'End If
                    End If
                End If
            Next

        End With

        Adventure.Map.UpdateMap(cLocation)
        fGenerator.Map1.SelectNode(cLocation.Key)
        Me.Focus()

        Adventure.Changed = True
        Return True

    End Function


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not ApplyLocation() Then Exit Sub
        CloseLocation(Me)
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If Not ApplyLocation() Then Exit Sub
        Changed = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Developer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then ApplyLocation()
            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        CloseLocation(Me)
    End Sub



    Private Sub LoadForm(ByRef cLocation As clsLocation, ByVal bShow As Boolean)


        Me.cLocation = cLocation

        arlCombos.Add(cmbNorth)
        arlRestrictions.Add(RestrictNorth)
        arlCombos.Add(cmbEast)
        arlRestrictions.Add(RestrictEast)
        arlCombos.Add(cmbSouth)
        arlRestrictions.Add(RestrictSouth)
        arlCombos.Add(cmbWest)
        arlRestrictions.Add(RestrictWest)
        arlCombos.Add(cmbUp)
        arlRestrictions.Add(RestrictUp)
        arlCombos.Add(cmbDown)
        arlRestrictions.Add(RestrictDown)
        arlCombos.Add(cmbIn)
        arlRestrictions.Add(RestrictIn)
        arlCombos.Add(cmbOut)
        arlRestrictions.Add(RestrictOut)
        arlCombos.Add(cmbNorthEast)
        arlRestrictions.Add(RestrictNorthEast)
        arlCombos.Add(cmbSouthEast)
        arlRestrictions.Add(RestrictSouthEast)
        arlCombos.Add(cmbSouthWest)
        arlRestrictions.Add(RestrictSouthWest)
        arlCombos.Add(cmbNorthWest)
        arlRestrictions.Add(RestrictNorthWest)

        For Each ctrl As Control In tabsLocation.Tabs(1).TabPage.Controls
            If TypeOf ctrl Is LinkLabel Then
                Dim eDirection As DirectionsEnum = GetDirection(CType(ctrl, LinkLabel))
                Dim sFirst As String = Adventure.sDirectionsRE(eDirection)
                If sFirst.Contains("/") Then sFirst = sFirst.Substring(0, sFirst.IndexOf("/"))
                CType(ctrl, LinkLabel).Text = "Move " & sFirst & " to"
                CType(ctrl, LinkLabel).LinkArea = New LinkArea(5, sFirst.Length)
            End If
        Next
        'For Each cmb As Control In arlCombos
        '    FillComboWithLocations(CType(cmb, Infragistics.Win.UltraWinEditors.UltraComboEditor))
        'Next


        With cLocation
            Text = "Location - " & .ShortDescription.ToString
            tabsLocation.Tabs("tabProperties").Visible = Not fGenerator.SimpleMode
            If SafeBool(GetSetting("ADRIFT", "Generator", "ShowKeys", "0")) Then Text &= "  [" & .Key & "]"
            If .ShortDescription.ToString = "" Then Text = "New Location"
            txtShortDesc.Description = .ShortDescription.Copy
            txtLongDesc.Description = .LongDescription.Copy
            chkHideOnMap.Checked = .HideOnMap

            For eDirection As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest
                Dim cmbDir As ADRIFT.ItemSelector = CType(arlCombos(eDirection), ADRIFT.ItemSelector)
                Dim Rest As ADRIFT.RestrictSummary = CType(arlRestrictions(eDirection), ADRIFT.RestrictSummary)
                If .arlDirections(eDirection).LocationKey IsNot Nothing AndAlso (Adventure.htblLocations.ContainsKey(.arlDirections(eDirection).LocationKey) OrElse Adventure.htblGroups.ContainsKey(.arlDirections(eDirection).LocationKey)) Then
                    cmbDir.Key = .arlDirections(eDirection).LocationKey 'SetCombo(cmbDir, Adventure.htblLocations(.arlDirections(eDirection).LocationKey).Key, True)                                    
                Else
                    Rest.Enabled = False
                End If
                Rest.LoadRestrictions(.arlDirections(eDirection).Restrictions)
            Next

            If .Key = "" Then
                btnAddObject.Enabled = False
                btnAddDynamicOb.Enabled = False
                btnAddCharacter.Enabled = False
            Else
                btnAddObject.Enabled = True
                btnAddDynamicOb.Enabled = True
                btnAddCharacter.Enabled = True
            End If

            ' Pad out the local Location hashtable with unselected properties
            .ResetInherited()
            Dim htblProperties As PropertyHashTable = .htblProperties.Clone ' .GetPropertiesIncludingGroups.Clone ' .htblProperties.Clone
            For Each prop As clsProperty In Adventure.htblLocationProperties.Values
                If Not htblProperties.ContainsKey(prop.Key) Then htblProperties.Add(prop.Copy)
            Next
            Me.Properties1.htblProperties = htblProperties
            Me.Properties1.OwnerKey = .Key

            Changed = False
        End With

        Folder1.sParentKey = cLocation.Key
        If cLocation.Key <> "" Then
            For Each ob As clsObject In Adventure.htblObjects.Values
                If (Not ob.IsStatic AndAlso ob.Location.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InLocation AndAlso ob.Location.Key = cLocation.Key) _
                    OrElse (ob.IsStatic AndAlso (ob.Location.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.AllRooms OrElse (ob.Location.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.SingleLocation AndAlso ob.LocationRoots.ContainsKey(cLocation.Key)))) Then
                    Folder1.AddSingleItem(ob.Key)
                End If
            Next
            For Each ch As clsCharacter In Adventure.htblCharacters.Values
                If ch.Location.LocationKey = cLocation.Key Then ' ch.LocationRoot IsNot Nothing AndAlso ch.LocationRoot.Key = cLocation.Key Then ' ch.LocationRoots.ContainsKey(cLocation.Key) Then
                    Folder1.AddSingleItem(ch.Key)
                End If
            Next
        End If

        GetFormPosition(Me)

        If bShow Then Me.Show()

        OpenForms.Add(Me)

    End Sub


    Private Sub StuffChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShortDesc.Changed, txtLongDesc.Changed
        Changed = True
    End Sub

    Private Sub cmb_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmbNorth.SelectionChanged, cmbNorthEast.SelectionChanged, cmbEast.SelectionChanged, cmbSouthEast.SelectionChanged, cmbSouth.SelectionChanged, cmbSouthWest.SelectionChanged, cmbWest.SelectionChanged, cmbNorthWest.SelectionChanged, cmbUp.SelectionChanged, cmbDown.SelectionChanged, cmbIn.SelectionChanged, cmbOut.SelectionChanged

        If arlCombos.Count = 0 Then Exit Sub

        Dim cmb As ADRIFT.ItemSelector = CType(sender, ADRIFT.ItemSelector)
        Dim Rest As ADRIFT.RestrictSummary = Nothing

        For eDirection As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest
            If cmb Is arlCombos(eDirection) Then
                Rest = CType(arlRestrictions(eDirection), ADRIFT.RestrictSummary)
                Exit For
            End If
        Next
        If cmb.Key <> "" Then
            'cmb.Font = New Font(cmb.Font, FontStyle.Bold)
            Rest.Enabled = True
        Else
            'cmb.Font = New Font(cmb.Font, FontStyle.Regular)
            Rest.Enabled = False
        End If
        Changed = True

    End Sub

    'Private Sub frmLocation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    GetFormPosition(Me)
    'End Sub

    Private Sub btnAddObject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddObject.Click

        ' Create a new static object in the current location

        Dim obStatic As New clsObject
        With obStatic
            If Adventure.htblAllProperties.ContainsKey("StaticOrDynamic") Then
                Dim pSoD As New clsProperty
                pSoD = Adventure.htblAllProperties("StaticOrDynamic").Copy
                '.htblActualProperties.Add(pSoD)
                .AddProperty(pSoD)
                .IsStatic = True
            End If

            If Adventure.htblAllProperties.ContainsKey("StaticLocation") Then
                Dim sl As New clsProperty
                sl = Adventure.htblAllProperties("StaticLocation").Copy
                '.htblActualProperties.Add(sl)
                .AddProperty(sl)
            End If

            If Adventure.htblAllProperties.ContainsKey("AtLocation") Then
                Dim pLoc As New clsProperty
                pLoc = Adventure.htblAllProperties("AtLocation").Copy
                '.htblActualProperties.Add(pLoc)
                .AddProperty(pLoc)
            End If

            Dim StaticLoc As New clsObjectLocation
            StaticLoc.StaticExistWhere = clsObjectLocation.StaticExistsWhereEnum.SingleLocation
            StaticLoc.Key = cLocation.Key
            .Move(StaticLoc)

        End With

        Dim fObject As New frmObject(obStatic, True)

    End Sub

    Private Sub btnAddDynamicOb_Click(sender As Object, e As EventArgs) Handles btnAddDynamicOb.Click

        Dim obDynamic As New clsObject
        With obDynamic
            If Adventure.htblAllProperties.ContainsKey("StaticOrDynamic") Then
                Dim pSoD As New clsProperty
                pSoD = Adventure.htblAllProperties("StaticOrDynamic").Copy
                .AddProperty(pSoD)
                .IsStatic = False
            End If

            If Adventure.htblAllProperties.ContainsKey("DynamicLocation") Then
                Dim sl As New clsProperty
                sl = Adventure.htblAllProperties("DynamicLocation").Copy
                .AddProperty(sl)
            End If

            If Adventure.htblAllProperties.ContainsKey("AtLocation") Then
                Dim pLoc As New clsProperty
                pLoc = Adventure.htblAllProperties("AtLocation").Copy
                .AddProperty(pLoc)
            End If

            Dim DynamicLoc As New clsObjectLocation
            DynamicLoc.DynamicExistWhere = clsObjectLocation.DynamicExistsWhereEnum.InLocation
            DynamicLoc.Key = cLocation.Key
            .Move(DynamicLoc)

        End With

        Dim fObject As New frmObject(obDynamic, True)

    End Sub

    Private Sub btnAddCharacter_Click(sender As Object, e As EventArgs) Handles btnAddCharacter.Click

        Dim ch As New clsCharacter
        With ch
            'If Adventure.htblAllProperties.ContainsKey("StaticOrDynamic") Then
            '    Dim pSoD As New clsProperty
            '    pSoD = Adventure.htblAllProperties("StaticOrDynamic").Copy
            '    .AddProperty(pSoD)
            '    .IsStatic = False
            'End If

            'If Adventure.htblAllProperties.ContainsKey("DynamicLocation") Then
            '    Dim sl As New clsProperty
            '    sl = Adventure.htblAllProperties("DynamicLocation").Copy
            '    .AddProperty(sl)
            'End If

            'If Adventure.htblAllProperties.ContainsKey("AtLocation") Then
            '    Dim pLoc As New clsProperty
            '    pLoc = Adventure.htblAllProperties("AtLocation").Copy
            '    .AddProperty(pLoc)
            'End If

            Dim CharLoc As New clsCharacterLocation(ch)
            CharLoc.ExistWhere = clsCharacterLocation.ExistsWhereEnum.AtLocation
            CharLoc.Key = cLocation.Key
            .Move(CharLoc)

        End With

        Dim fCharacter As New frmCharacter(ch, True)

    End Sub


    Private Sub frmLocation_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OpenForms.Remove(Me)
    End Sub


    Private Sub frmLocation_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If txtShortDesc IsNot Nothing Then
            If txtShortDesc.Text = "" Then
                txtShortDesc.Focus()
            Else
                txtLongDesc.Focus()
                txtLongDesc.rtxtSource.SelectionStart = txtLongDesc.rtxtSource.TextLength
            End If
        End If
    End Sub

    Private Sub frmLocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Properties1.PropertyType = clsProperty.PropertyOfEnum.Locations
        Me.Icon = Icon.FromHandle(My.Resources.imgLocation16.GetHicon)

        If DarkInterface() Then
            chkHideOnMap.ForeColor = Color.White
        End If

    End Sub


    Private Sub btnRemoveItem_Click(sender As Object, e As System.EventArgs) Handles btnRemoveItem.Click
        Folder1.RemoveSelectedItems()
    End Sub


    Private Function GetDirection(ByVal label As LinkLabel) As DirectionsEnum

        Dim eDirection As DirectionsEnum

        Select Case True
            Case label Is lblNorth
                eDirection = DirectionsEnum.North
            Case label Is lblNorthEast
                eDirection = DirectionsEnum.NorthEast
            Case label Is lblEast
                eDirection = DirectionsEnum.East
            Case label Is lblSouthEast
                eDirection = DirectionsEnum.SouthEast
            Case label Is lblSouth
                eDirection = DirectionsEnum.South
            Case label Is lblSouthWest
                eDirection = DirectionsEnum.SouthWest
            Case label Is lblWest
                eDirection = DirectionsEnum.West
            Case label Is lblNorthWest
                eDirection = DirectionsEnum.NorthWest
            Case label Is lblUp
                eDirection = DirectionsEnum.Up
            Case label Is lblDown
                eDirection = DirectionsEnum.Down
            Case label Is lblIn
                eDirection = DirectionsEnum.In
            Case label Is lblOut
                eDirection = DirectionsEnum.Out
        End Select

        Return eDirection

    End Function



    Private Sub lblNorth_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblNorth.LinkClicked, lblNorthEast.LinkClicked, lblEast.LinkClicked, lblSouthEast.LinkClicked, lblSouth.LinkClicked, lblSouthWest.LinkClicked, lblWest.LinkClicked, lblNorthWest.LinkClicked, lblUp.LinkClicked, lblDown.LinkClicked, lblIn.LinkClicked, lblOut.LinkClicked

        Dim eDirection As DirectionsEnum = GetDirection(CType(sender, LinkLabel))
        Dim sText As String = Adventure.sDirectionsRE(eDirection)
        Dim sNewText As String = InputBox("Please enter alternative words for direction " & eDirection.ToString & ", separated by / character:", "Direction " & eDirection.ToString, sText)

        If sNewText <> "" AndAlso sNewText <> sText Then
            Adventure.sDirectionsRE(eDirection) = sNewText
            Dim sFirst As String = DirectionName(eDirection)
            'Dim sFirst As String = sNewText
            'If sNewText.Contains("/") Then sFirst = sNewText.Substring(0, sNewText.IndexOf("/"))
            CType(sender, LinkLabel).Text = "Move " & sFirst & " to"
            CType(sender, LinkLabel).LinkArea = New LinkArea(5, sFirst.Length)
        End If

    End Sub


    Private Sub frmLocation_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked                
        ShowHelp(Me, "Locations")
    End Sub

End Class
