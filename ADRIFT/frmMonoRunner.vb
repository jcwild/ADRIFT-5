Public Class frmRunner
    Inherits System.Windows.Forms.Form

    'Friend salCommands As New StringArrayList
    Private iCommand As Integer
    'Friend WithEvents Map As ADRIFT.Map

    'Friend WithEvents DockableWindow1 As Infragistics.Win.UltraWinDock.DockableWindow
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents SplitContainerInputOutput As System.Windows.Forms.SplitContainer
    'Friend WithEvents WindowDockingArea3 As Infragistics.Win.UltraWinDock.WindowDockingArea   
    Friend WithEvents btnMore As Windows.Forms.Button
    Friend WithEvents btnSubmit As Windows.Forms.Button
    Friend WithEvents ctxMenu As New ContextMenuStrip
    Private fSplash As Splash
    Private bEXE As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        UserSession = New RunnerSession

        'If Environment.GetCommandLineArgs.Length = 1 Then

        '    ' Work out whether we have a TAF appended on the end.  If so, run that in Executable mode
        '    ' Grab out the last 8 bytes, and see if it converts to a size
        '    Dim bData(5) As Byte
        '    Dim fStream As New IO.FileStream(Application.ExecutablePath, IO.FileMode.Open, IO.FileAccess.Read)
        '    fStream.Seek(fStream.Length - 6, IO.SeekOrigin.Begin)
        '    fStream.Read(bData, 0, 6)
        '    fStream.Close()

        '    Dim sFileSize As String = (New System.Text.ASCIIEncoding).GetString(bData).ToUpper
        '    If IsHex(sFileSize) Then
        '        Dim lFileSize As Long = CLng("&H" & sFileSize)
        '        If lFileSize > 0 Then
        '            ' Ok, check the offset to see that the appended data is really a TAF...
        '            fStream = New IO.FileStream(Application.ExecutablePath, IO.FileMode.Open, IO.FileAccess.Read)
        '            fStream.Seek(lFileSize, IO.SeekOrigin.Begin)
        '            ReDim bData(11)
        '            fStream.Read(bData, 0, 12)
        '            fStream.Close()
        '            Dim sVersion As String = System.Text.Encoding.Default.GetString(Dencode(System.Text.Encoding.Default.GetString(bData), 1))
        '            If sVersion = "Version 5.00" Then bEXE = True
        '        End If
        '    End If
        'End If

        If Not bEXE Then
            fSplash = New Splash
            fSplash.Show(Me)
            Application.DoEvents()
        End If

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        If bEXE Then
            miOpenAdventure.Visible = False
            miOpenGame.Visible = False
            miRecentAdventures.Visible = False
            miAboutADRIFT.Visible = False
            miDebugger.Visible = False
        End If

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
    'Friend WithEvents _frmRunnerUnpinnedTabAreaLeft As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    'Friend WithEvents _frmRunnerUnpinnedTabAreaRight As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    'Friend WithEvents _frmRunnerUnpinnedTabAreaTop As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    'Friend WithEvents _frmRunnerUnpinnedTabAreaBottom As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    'Friend WithEvents _frmRunner_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    'Friend WithEvents _frmRunner_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    'Friend WithEvents _frmRunner_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    'Friend WithEvents _frmRunner_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    'Friend WithEvents _frmRunnerAutoHideControl As Infragistics.Win.UltraWinDock.AutoHideControl
    'Friend WithEvents UTMMain As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    'Friend WithEvents UDMRunner As Infragistics.Win.UltraWinDock.UltraDockManager
    'Friend WithEvents StatusBar As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents StatusBar As StatusBar
    'Friend WithEvents DockableWindow2 As Infragistics.Win.UltraWinDock.DockableWindow
    'Friend WithEvents WindowDockingArea2 As Infragistics.Win.UltraWinDock.WindowDockingArea
    Friend WithEvents pbxGraphics As clsImage
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtInput As System.Windows.Forms.RichTextBox
    Friend WithEvents txtOutput As System.Windows.Forms.RichTextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRunner))
        Me.StatusBar = New System.Windows.Forms.StatusBar()
        Me.Description = New System.Windows.Forms.StatusBarPanel()
        Me.UserStatus = New System.Windows.Forms.StatusBarPanel()
        Me.Score = New System.Windows.Forms.StatusBarPanel()
        Me.txtInput = New System.Windows.Forms.RichTextBox()
        Me.txtOutput = New System.Windows.Forms.RichTextBox()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnMore = New System.Windows.Forms.Button()
        Me.SplitContainerInputOutput = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerTextOther = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerMapGraphics = New System.Windows.Forms.SplitContainer()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miOpenAdventure = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miOpenGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRestartGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miSaveGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSaveGameAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.miStartTranscript = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.miRecentAdventures = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.miExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAutoComplete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miFullScreen = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDebugger = New System.Windows.Forms.ToolStripMenuItem()
        Me.miOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMacros = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.miEditMacros = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miShowMap = New System.Windows.Forms.ToolStripMenuItem()
        Me.miShowGraphics = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAboutADRIFT = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAboutAdventure = New System.Windows.Forms.ToolStripMenuItem()

        Me.pbxGraphics = New ADRIFT.clsImage()
        Me.btnSubmit = New System.Windows.Forms.Button()
        CType(Me.Description, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Score, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SplitContainerInputOutput.Panel1.SuspendLayout()
        Me.SplitContainerInputOutput.Panel2.SuspendLayout()
        Me.SplitContainerInputOutput.SuspendLayout()
        Me.SplitContainerTextOther.Panel1.SuspendLayout()
        Me.SplitContainerTextOther.Panel2.SuspendLayout()
        Me.SplitContainerTextOther.SuspendLayout()
        Me.SplitContainerMapGraphics.Panel1.SuspendLayout()
        Me.SplitContainerMapGraphics.Panel2.SuspendLayout()
        Me.SplitContainerMapGraphics.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusBar
        '
        Me.StatusBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.StatusBar.Location = New System.Drawing.Point(0, 407)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Description, Me.UserStatus, Me.Score})
        Me.StatusBar.ShowPanels = True
        Me.StatusBar.Size = New System.Drawing.Size(611, 23)
        Me.StatusBar.TabIndex = 11
        Me.StatusBar.Tag = ""
        '
        'Description
        '
        Me.Description.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.Description.Name = "Description"
        Me.Description.Text = "Please open an adventure file"
        Me.Description.Width = 215
        '
        'UserStatus
        '
        Me.UserStatus.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.UserStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.UserStatus.Name = "UserStatus"
        Me.UserStatus.Width = 369
        '
        'Score
        '
        Me.Score.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.Score.Name = "Score"
        Me.Score.Width = 10
        '
        'txtInput
        '
        Me.txtInput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInput.BackColor = System.Drawing.Color.Black
        Me.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInput.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtInput.Location = New System.Drawing.Point(48, -2)
        Me.txtInput.Multiline = False
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(366, 24)
        Me.txtInput.TabIndex = 1
        Me.txtInput.Text = ""
        '
        'txtOutput
        '
        Me.txtOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutput.BackColor = System.Drawing.Color.Black
        Me.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutput.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtOutput.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtOutput.Location = New System.Drawing.Point(48, 0)
        Me.txtOutput.Margin = New System.Windows.Forms.Padding(0)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtOutput.Size = New System.Drawing.Size(367, 351)
        Me.txtOutput.TabIndex = 0
        Me.txtOutput.TabStop = False
        Me.txtOutput.Text = ""
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.Black
        Me.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlTop.Controls.Add(Me.txtOutput)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(418, 355)
        Me.pnlTop.TabIndex = 0
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.Black
        Me.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBottom.Controls.Add(Me.btnSubmit)
        Me.pnlBottom.Controls.Add(Me.btnMore)
        Me.pnlBottom.Controls.Add(Me.txtInput)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBottom.Location = New System.Drawing.Point(0, 0)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(418, 27)
        Me.pnlBottom.TabIndex = 0
        '
        'btnMore
        '
        Me.btnMore.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnMore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMore.Location = New System.Drawing.Point(104, -2)
        Me.btnMore.Name = "btnMore"
        Me.btnMore.Size = New System.Drawing.Size(273, 26)
        Me.btnMore.TabIndex = 12
        Me.btnMore.Text = "Press any key to continue"
        Me.btnMore.UseVisualStyleBackColor = False
        Me.btnMore.Visible = False
        '
        'SplitContainerInputOutput
        '
        Me.SplitContainerInputOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerInputOutput.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerInputOutput.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerInputOutput.Name = "SplitContainerInputOutput"
        Me.SplitContainerInputOutput.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerInputOutput.Panel1
        '
        Me.SplitContainerInputOutput.Panel1.Controls.Add(Me.pnlTop)
        '
        'SplitContainerInputOutput.Panel2
        '
        Me.SplitContainerInputOutput.Panel2.Controls.Add(Me.pnlBottom)
        Me.SplitContainerInputOutput.Size = New System.Drawing.Size(418, 383)
        Me.SplitContainerInputOutput.SplitterDistance = 355
        Me.SplitContainerInputOutput.SplitterWidth = 1
        Me.SplitContainerInputOutput.TabIndex = 1
        Me.SplitContainerInputOutput.TabStop = False
        '
        'SplitContainerTextOther
        '
        Me.SplitContainerTextOther.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerTextOther.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainerTextOther.Name = "SplitContainerTextOther"
        '
        'SplitContainerTextOther.Panel1
        '
        Me.SplitContainerTextOther.Panel1.Controls.Add(Me.SplitContainerInputOutput)
        '
        'SplitContainerTextOther.Panel2
        '
        Me.SplitContainerTextOther.Panel2.Controls.Add(Me.SplitContainerMapGraphics)
        Me.SplitContainerTextOther.Size = New System.Drawing.Size(611, 383)
        Me.SplitContainerTextOther.SplitterDistance = 418
        Me.SplitContainerTextOther.TabIndex = 12
        '
        'SplitContainerMapGraphics
        '
        Me.SplitContainerMapGraphics.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMapGraphics.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerMapGraphics.Name = "SplitContainerMapGraphics"
        Me.SplitContainerMapGraphics.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerMapGraphics.Panel1
        '
        Me.SplitContainerMapGraphics.Panel1.Controls.Add(UserSession.Map)
        '
        'SplitContainerMapGraphics.Panel2
        '
        Me.SplitContainerMapGraphics.Panel2.Controls.Add(Me.pbxGraphics)
        Me.SplitContainerMapGraphics.Size = New System.Drawing.Size(189, 383)
        Me.SplitContainerMapGraphics.SplitterDistance = 190
        Me.SplitContainerMapGraphics.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.miMacros, Me.WindowToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(611, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miOpenAdventure, Me.ToolStripSeparator1, Me.miOpenGame, Me.miRestartGame, Me.ToolStripSeparator2, Me.miSaveGame, Me.miSaveGameAs, Me.miStartTranscript, Me.ToolStripSeparator3, Me.miRecentAdventures, Me.ToolStripSeparator4, Me.miExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'miOpenAdventure
        '
        Me.miOpenAdventure.Name = "miOpenAdventure"
        Me.miOpenAdventure.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.miOpenAdventure.Size = New System.Drawing.Size(203, 22)
        Me.miOpenAdventure.Text = "Open Adventure"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(200, 6)
        '
        'miOpenGame
        '
        Me.miOpenGame.Enabled = False
        Me.miOpenGame.Name = "miOpenGame"
        Me.miOpenGame.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.miOpenGame.Size = New System.Drawing.Size(203, 22)
        Me.miOpenGame.Text = "Open Game..."
        '
        'miRestartGame
        '
        Me.miRestartGame.Enabled = False
        Me.miRestartGame.Name = "miRestartGame"
        Me.miRestartGame.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.miRestartGame.Size = New System.Drawing.Size(203, 22)
        Me.miRestartGame.Text = "Restart Game"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(200, 6)
        '
        'miSaveGame
        '
        Me.miSaveGame.Enabled = False
        Me.miSaveGame.Name = "miSaveGame"
        Me.miSaveGame.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.miSaveGame.Size = New System.Drawing.Size(203, 22)
        Me.miSaveGame.Text = "Save Game"
        '
        'miSaveGameAs
        '
        Me.miSaveGameAs.Enabled = False
        Me.miSaveGameAs.Name = "miSaveGameAs"
        Me.miSaveGameAs.Size = New System.Drawing.Size(203, 22)
        Me.miSaveGameAs.Text = "Save Game As..."
        '
        'miStartTranscript
        '
        Me.miStartTranscript.Name = "miStartTranscript"
        Me.miStartTranscript.Size = New System.Drawing.Size(203, 22)
        Me.miStartTranscript.Text = "Start Transcript..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(200, 6)
        '
        'miRecentAdventures
        '
        Me.miRecentAdventures.Name = "miRecentAdventures"
        Me.miRecentAdventures.Size = New System.Drawing.Size(203, 22)
        Me.miRecentAdventures.Text = "Recent Adventures"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(200, 6)
        '
        'miExit
        '
        Me.miExit.Name = "miExit"
        Me.miExit.Size = New System.Drawing.Size(203, 22)
        Me.miExit.Text = "E&xit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAutoComplete})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'miAutoComplete
        '
        Me.miAutoComplete.CheckOnClick = True
        Me.miAutoComplete.Name = "miAutoComplete"
        Me.miAutoComplete.Size = New System.Drawing.Size(155, 22)
        Me.miAutoComplete.Text = "Auto Complete"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miFullScreen, Me.miDebugger, Me.miOptions})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'miFullScreen
        '
        Me.miFullScreen.CheckOnClick = True
        Me.miFullScreen.Name = "miFullScreen"
        Me.miFullScreen.Size = New System.Drawing.Size(131, 22)
        Me.miFullScreen.Text = "Full Screen"
        '
        'miDebugger
        '
        Me.miDebugger.CheckOnClick = True
        Me.miDebugger.Name = "miDebugger"
        Me.miDebugger.Size = New System.Drawing.Size(131, 22)
        Me.miDebugger.Text = "Debugger"
        '
        'miOptions
        '
        Me.miOptions.Name = "miOptions"
        Me.miOptions.Size = New System.Drawing.Size(131, 22)
        Me.miOptions.Text = "Options"
        '
        'miMacros
        '
        Me.miMacros.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator5, Me.miEditMacros})
        Me.miMacros.Enabled = False
        Me.miMacros.Name = "miMacros"
        Me.miMacros.Size = New System.Drawing.Size(58, 20)
        Me.miMacros.Text = "&Macros"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(133, 6)
        '
        'miEditMacros
        '
        Me.miEditMacros.Name = "miEditMacros"
        Me.miEditMacros.Size = New System.Drawing.Size(136, 22)
        Me.miEditMacros.Text = "Edit Macros"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miShowMap, Me.miShowGraphics})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.WindowToolStripMenuItem.Text = "&Window"
        '
        'miShowMap
        '
        Me.miShowMap.Checked = True
        Me.miShowMap.CheckOnClick = True
        Me.miShowMap.CheckState = System.Windows.Forms.CheckState.Checked
        Me.miShowMap.Name = "miShowMap"
        Me.miShowMap.Size = New System.Drawing.Size(152, 22)
        Me.miShowMap.Text = "Show Map"
        '
        'miShowGraphics
        '
        Me.miShowGraphics.Checked = True
        Me.miShowGraphics.CheckOnClick = True
        Me.miShowGraphics.CheckState = System.Windows.Forms.CheckState.Checked
        Me.miShowGraphics.Name = "miShowGraphics"
        Me.miShowGraphics.Size = New System.Drawing.Size(152, 22)
        Me.miShowGraphics.Text = "Show Graphics"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAboutADRIFT, Me.miAboutAdventure})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'miAboutADRIFT
        '
        Me.miAboutADRIFT.Name = "miAboutADRIFT"
        Me.miAboutADRIFT.Size = New System.Drawing.Size(165, 22)
        Me.miAboutADRIFT.Text = "About ADRIFT"
        '
        'miAboutAdventure
        '
        Me.miAboutAdventure.Name = "miAboutAdventure"
        Me.miAboutAdventure.Size = New System.Drawing.Size(165, 22)
        Me.miAboutAdventure.Text = "About Adventure"
        '
        'Map
        '
        'Me.Map.Dock = System.Windows.Forms.DockStyle.Fill
        'Me.Map.Location = New System.Drawing.Point(0, 0)
        'Me.Map.Map = Nothing
        'Me.Map.Name = "Map"
        'Me.Map.ShowAxes = False
        'Me.Map.ShowGrid = False
        'Me.Map.Size = New System.Drawing.Size(189, 190)
        'Me.Map.TabIndex = 0
        '
        'pbxGraphics
        '
        Me.pbxGraphics.BackColor = System.Drawing.Color.Transparent
        Me.pbxGraphics.BackColour = System.Drawing.Color.Transparent
        Me.pbxGraphics.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbxGraphics.Image = Nothing
        Me.pbxGraphics.Location = New System.Drawing.Point(0, 0)
        Me.pbxGraphics.Name = "pbxGraphics"
        Me.pbxGraphics.Size = New System.Drawing.Size(189, 189)
        Me.pbxGraphics.SizeMode = ADRIFT.clsImage.SizeModeEnum.ActualSizeCentred
        Me.pbxGraphics.TabIndex = 0
        Me.pbxGraphics.TabStop = False
        '
        'btnSubmit
        '
        Me.btnSubmit.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSubmit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSubmit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSubmit.Location = New System.Drawing.Point(389, 0)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(49, 21)
        Me.btnSubmit.TabIndex = 13
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.Visible = False
        '
        'frmRunner
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(611, 430)
        Me.Controls.Add(Me.SplitContainerTextOther)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmRunner"
        Me.Text = "ADRIFT Runner"
        CType(Me.Description, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Score, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.SplitContainerInputOutput.Panel1.ResumeLayout(False)
        Me.SplitContainerInputOutput.Panel2.ResumeLayout(False)
        Me.SplitContainerInputOutput.ResumeLayout(False)
        Me.SplitContainerTextOther.Panel1.ResumeLayout(False)
        Me.SplitContainerTextOther.Panel2.ResumeLayout(False)
        Me.SplitContainerTextOther.ResumeLayout(False)
        Me.SplitContainerMapGraphics.Panel1.ResumeLayout(False)
        Me.SplitContainerMapGraphics.Panel2.ResumeLayout(False)
        Me.SplitContainerMapGraphics.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub FullScreen(ByVal bActivate As Boolean)
        If bActivate Then
            'Hide()           

            txtOutput.Visible = False
            pnlTop.BorderStyle = BorderStyle.None
            pnlBottom.BorderStyle = BorderStyle.None
            'Application.DoEvents()

            Me.Text = ""
            Me.ControlBox = False            
            FormBorderStyle = Windows.Forms.FormBorderStyle.None
            WindowState = FormWindowState.Maximized
            txtOutput.Visible = True
            'Me.txtOutput.BorderStyle = BorderStyle.None
            'Me.txtInput.BorderStyle = BorderStyle.None
            'Show()
        Else            
            WindowState = FormWindowState.Normal
            FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.ControlBox = True
            Me.Text = "ADRIFT Runner"
            'Hide()

            pnlTop.BorderStyle = BorderStyle.Fixed3D
            pnlBottom.BorderStyle = BorderStyle.Fixed3D

            'Show()
            'Me.txtOutput.BorderStyle = BorderStyle.Fixed3D
            'Me.txtInput.BorderStyle = BorderStyle.Fixed3D
            End If
        'Application.DoEvents()
        miFullScreen.Checked = bActivate
        SaveSetting("ADRIFT", "Runner", "FullScreen", bActivate.ToString)
    End Sub

    'Private Sub UTMMain_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UTMMain.ToolClick
    '    DoToolClick(e.Tool.Key, e.Tool.SharedProps.Caption, CStr(e.Tool.SharedProps.Tag))
    'End Sub



    'Private Sub DoToolClick(ByVal sKey As String, ByVal sCaption As String, ByVal sTag As String)

    '    Try
    '        If sTag = "_RECENT_" Then
    Friend Sub miRecentAdventures_Click(sender As System.Object, e As System.EventArgs)
        UserSession.OpenAdventure(SafeString(CType(sender, ToolStripItem).Tag))
    End Sub
    '        End If

    '        Select Case sKey
    '            Case "About"
    Private Sub miAboutADRIFT_Click(sender As System.Object, e As System.EventArgs) Handles miAboutADRIFT.Click
        Dim fAbout As New AboutBox
        Try
            fAbout.ShowDialog()
        Catch
        End Try
    End Sub

    '                'MessageBox.Show("ADRIFT Runner" & vbCrLf & "Version " & Application.ProductVersion & vbCrLf & "© Campbell Wild 2010" & vbCrLf & vbCrLf & "Alpha Release.  Registered users only." & vbCrLf & "Splash image ""Adrift"" © V. Milovic 2010 (www.brokentoyland.com)", "About ADRIFT Runner", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Case "AboutAdventure"
    Private Sub miAboutAdventure_Click(sender As System.Object, e As System.EventArgs) Handles miAboutAdventure.Click
        Dim sVersion As String = ""
        If Adventure IsNot Nothing AndAlso Adventure.BabelTreatyInfo IsNot Nothing Then
            If Adventure.BabelTreatyInfo.Stories.Length = 1 AndAlso Adventure.BabelTreatyInfo.Stories(0).Releases IsNot Nothing Then
                With Adventure.BabelTreatyInfo.Stories(0).Releases.Attached.Release
                    sVersion = vbCrLf & "Version: " & .Version
                    If .ReleaseDate > Date.MinValue Then sVersion &= vbCrLf & "Released: " & .ReleaseDate.ToLongDateString
                End With
            End If
        End If
        If Adventure IsNot Nothing Then MessageBox.Show(Adventure.Title & vbCrLf & "By " & Adventure.Author & sVersion, "About Adventure", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    '            Case "AutoComplete"
    Private Sub miAutoComplete_Click(sender As System.Object, e As System.EventArgs) Handles miAutoComplete.Click
        UserSession.bAutoComplete = miAutoComplete.Checked
        SaveSetting("ADRIFT", "Generator", "Auto Complete", UserSession.bAutoComplete.ToString)
    End Sub
    '            Case "Debugger"
    Private Sub miDebugger_Click(sender As System.Object, e As System.EventArgs) Handles miDebugger.Click
        If UserSession.Debugger Is Nothing OrElse UserSession.Debugger.IsDisposed Then UserSession.Debugger = New frmDebugger
        UserSession.Debugger.Visible = miDebugger.Checked ' CType(UTMMain.Tools("Debugger"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked
    End Sub
    '            Case "Exit"
    Private Sub miExit_Click(sender As System.Object, e As System.EventArgs) Handles miExit.Click
        UserSession.Quit()
    End Sub
    '            Case "mnuFullScreen"
    Private Sub miFullScreen_Click(sender As System.Object, e As System.EventArgs) Handles miFullScreen.Click
        FullScreen(miFullScreen.Checked)
    End Sub
    '            Case "mnuOpenAdv"
    Private Sub OpenAdventureToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles miOpenAdventure.Click
        OpenAdventureDialog(fRunner.ofd)
    End Sub
    '            Case "RestartGame"
    Private Sub miRestartGame_Click(sender As System.Object, e As System.EventArgs) Handles miRestartGame.Click
        UserSession.Restart()
    End Sub
    '            Case "OpenGame"
    Private Sub miOpenGame_Click(sender As System.Object, e As System.EventArgs) Handles miOpenGame.Click
        UserSession.Restore()
    End Sub
    '            Case "SaveGame", "SaveGameAs"
    Private Sub miSaveGame_Click(sender As System.Object, e As System.EventArgs) Handles miSaveGame.Click, miSaveGameAs.Click
        UserSession.SaveGame(sender Is miSaveGameAs)
    End Sub
    '            Case "ShowGraphics"
    Private Sub miShowGraphics_Click(sender As System.Object, e As System.EventArgs) Handles miShowGraphics.CheckedChanged
        If Not Me.Visible Then Exit Sub
        If miShowGraphics.Checked Then
            SplitContainerMapGraphics.Panel2Collapsed = False
            If Not miShowMap.Checked Then SplitContainerTextOther.Panel2Collapsed = False
        Else
            SplitContainerMapGraphics.Panel2Collapsed = True
            If Not miShowMap.Checked Then SplitContainerTextOther.Panel2Collapsed = True
        End If
        SaveSetting("ADRIFT", "Runner", "ShowGraphics", CInt(miShowGraphics.Checked).ToString)
        '                For Each cp As Infragistics.Win.UltraWinDock.DockableControlPane In UDMRunner.ControlPanes
        '                    If cp.Text = "Graphics" AndAlso Not cp.IsVisible Then
        '                        cp.Show()
        '                        UTMMain.Tools("ShowGraphics").SharedProps.Enabled = False
        '                        SetMargins()
        '                    End If
        '                Next
    End Sub

    '            Case "ShowMap"
    Private Sub miShowMap_Click(sender As System.Object, e As System.EventArgs) Handles miShowMap.CheckedChanged
        If Not Me.Visible Then Exit Sub
        If miShowMap.Checked Then
            SplitContainerMapGraphics.Panel1Collapsed = False
            If Not miShowGraphics.Checked Then SplitContainerTextOther.Panel2Collapsed = False
        Else
            SplitContainerMapGraphics.Panel1Collapsed = True
            If Not miShowGraphics.Checked Then SplitContainerTextOther.Panel2Collapsed = True
        End If
        SaveSetting("ADRIFT", "Runner", "ShowMap", CInt(miShowMap.Checked).ToString)
        '                For Each cp As Infragistics.Win.UltraWinDock.DockableControlPane In UDMRunner.ControlPanes
        '                    If cp.Text = "Map" AndAlso Not cp.IsVisible Then
        '                        cp.Show()
        '                        UTMMain.Tools("ShowMap").SharedProps.Enabled = False
        '                        SetMargins()
        '                    End If
        '                Next
        '                'If Not UDMRunner.ControlPanes.Exists("") Then Exit Sub
        '                'UDM.ControlPanes(sPane).Closed = False ' We're getting an Infragistics Stack overflow bug whenever we try to reopen a pane that was restored as closed...
        '                'UDM.ControlPanes(sPane).Activate()
        '                'CType(sender, ToolStripMenuItem).Visible = False
        '                'If Not arlOpenPanes.Contains(sPane) Then arlOpenPanes.Add(sPane)
    End Sub
    '            Case "miStartTranscript"
    Private Sub miStartTranscript_Click(sender As System.Object, e As System.EventArgs) Handles miStartTranscript.Click
        If miStartTranscript.Text = "Start Transcript..." Then
            StartTranscript()
        Else
            StopTranscript()
        End If
    End Sub

    '            Case "Options"
    Private Sub miOptions_Click(sender As System.Object, e As System.EventArgs) Handles miOptions.Click
        Dim frmOptions As New frmOptionsRunner
        frmOptions.ShowDialog()
    End Sub
    '            Case "Edit Macros"
    Private Sub miEditMacros_Click(sender As System.Object, e As System.EventArgs) Handles miEditMacros.Click
        Dim frmMacros As New frmMacros
        'frmMacros.dictMacros = CType(dictMacros.Clon, StringHashTable)
        frmMacros.ldictMacros = New Generic.Dictionary(Of String, clsMacro)
        For Each macro As clsMacro In UserSession.dictMacros.Values
            frmMacros.ldictMacros.Add(macro.Key, CType(macro.Clone, clsMacro))
        Next
        frmMacros.Text = "Edit Macros - " & Adventure.Title
        frmMacros.Show()
    End Sub


    '            Case "MapPlan"
    '                Map.PlanView()

    '            Case "MapCentre"
    '                Map.CentreMap()

    '            Case "MapZoomIn"
    '                Map.Zoom(True)

    '            Case "MapZoomOut"
    '                Map.Zoom(False)

    '            Case "CentreMapLock"
    '                Map.LockMapCentre = CType(UTMMain.Tools(sKey), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked

    '            Case "MapPlayerLock"
    '                Map.LockPlayerCentre = CType(UTMMain.Tools(sKey), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked

    '            Case Else
    '                'ErrMsg("Tool " & sKey & " not yet programmed!")

    '        End Select

    Private Sub miMacros_Click(sender As System.Object, e As System.EventArgs)
        If sLeft(CType(sender, ToolStripMenuItem).Name, 6) = "Macro-" Then
            RunMacro(CType(sender, ToolStripMenuItem).Name.Replace("Macro-", ""))
        End If
    End Sub


    '    Catch ex As Exception
    '        ErrMsg("Tool Click error", ex)
    '    End Try

    'End Sub

    Private Sub frmRunner_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, txtInput.KeyDown, txtOutput.KeyDown
        If e.KeyData = Keys.Escape Then
            bStopMacro = True
        End If
    End Sub

    Private bStopMacro As Boolean = False
    Private Sub RunMacro(ByVal sKey As String)

        bStopMacro = False

        If UserSession.dictMacros.ContainsKey(sKey) Then
            If UserSession.dictMacros(sKey).Commands IsNot Nothing Then
                Dim bAutoComplete As Boolean = UserSession.bAutoComplete
                UserSession.bAutoComplete = False
                For Each sCommand As String In UserSession.dictMacros(sKey).Commands.Split(Chr(10))
                    sCommand = ReplaceFunctions(sCommand)
                    If sCommand.Trim <> "" Then
                        If sLeft(sCommand, 1) = "#" AndAlso sCommand.Length > 1 Then
                            txtInput_KeyDown(Nothing, New KeyEventArgs(Keys.OemQuotes))
                            txtInput.Text = "@ " & sCommand.Substring(1).Trim
                        Else
                            txtInput.Text = "xx" & sCommand.Trim
                        End If

                        txtInput_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                        Application.DoEvents()
                        If bStopMacro Then Exit Sub
                    End If
                Next
                UserSession.bAutoComplete = bAutoComplete
            End If
        End If

    End Sub


    Public Sub UpdateStatusBar(sDescription As String, ByVal sScore As String, ByVal sUserStatus As String)
        With StatusBar
            .Panels("Description").Text = sDescription
            If sScore <> "" Then
                .Panels("Score").Text = sScore
                '.Panels("Score").Visible = True
            Else
                '.Panels("Score").Visible = False
            End If
            If sUserStatus <> "" Then
                .Panels("UserStatus").Text = ReplaceALRs(sUserStatus)
                '.Panels("UserStatus").Visible = True
                '.Panels("Description").SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
            Else
                '.Panels("UserStatus").Visible = False
                '.Panels("Description").SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring
            End If
        End With
    End Sub


    ' Reload the macros on the form
    Public Sub ReloadMacros()

        'Dim mnuMacros As PopupMenuTool = CType(UTMMain.Tools("Macros"), PopupMenuTool)

        For iTool As Integer = miMacros.DropDownItems.Count - 1 To 0 Step -1
            If miMacros.DropDownItems(iTool).Name <> "miEditMacros" AndAlso miMacros.DropDownItems(iTool).Name <> "ToolStripSeparator5" Then miMacros.DropDownItems.RemoveAt(iTool)
        Next

        'Dim arlKeys As New StringArrayList
        'For Each sTitle As String In dictMacros.Keys
        '    arlKeys.Add(sTitle)
        'Next
        'arlKeys.Sort()

        Dim i As Integer
        For Each macro As clsMacro In UserSession.dictMacros.Values
            i += 1
            With macro
                If Adventure IsNot Nothing AndAlso .IFID = Adventure.BabelTreatyInfo.Stories(0).Identification.IFID OrElse .Shared Then
                    Dim sToolKey As String = "Macro-" & .Key
                    If Not miMacros.DropDownItems.ContainsKey(sToolKey) Then
                        Dim newTool As New ToolStripMenuItem(.Title, Nothing, AddressOf miMacros_Click) ' ButtonTool(sToolKey)
                        newTool.Name = sToolKey
                        miMacros.DropDownItems.Insert(miMacros.DropDownItems.Count - 2, newTool)
                    End If

                    If .Shortcut <> Keys.None Then
                        CType(miMacros.DropDownItems(sToolKey), ToolStripMenuItem).ShortcutKeys = CType(.Shortcut, Keys)
                    End If
                End If
            End With
        Next

    End Sub



    Private bLocked As Boolean = False
    Public Property Locked() As Boolean
        Get
            Return bLocked
        End Get
        Set(ByVal value As Boolean)
            bLocked = value
            'txtInput.Enabled = Not bLocked            
            MenuStrip1.Enabled = Not bLocked
        End Set
    End Property


    Private bWaitKey As Boolean = False
    Public Sub WaitKey()
        bWaitKey = True
        Locked = True

        While bWaitKey AndAlso Visible
            Application.DoEvents()
            txtInput.Focus()
            Threading.Thread.Sleep(5)
        End While
        Locked = False
        If fRunner.txtOutput IsNot Nothing AndAlso Not fRunner.txtOutput.IsDisposed Then UserSession.iPreviousOffset = fRunner.txtOutput.TextLength
    End Sub


    Private bLoadedMargins As Boolean = False
    Public Sub SetMargins()

        With UserSession
            If Not bLoadedMargins Then
                .iMarginWidth = CInt(GetSetting("ADRIFT", "Runner", "Margin", "10"))
                bLoadedMargins = True
            End If
            txtOutput.Width = pnlTop.ClientSize.Width - .iMarginWidth '+ 10
            txtOutput.Left = .iMarginWidth
            txtOutput.RightMargin = Math.Max(txtOutput.ClientSize.Width - .iMarginWidth, 0)
            txtInput.Width = pnlBottom.ClientSize.Width - .iMarginWidth ' + 10
            txtInput.Left = .iMarginWidth
            txtInput.Top = -2
        End With

    End Sub


    Private Sub StartTranscript()

        With UserSession
            Dim sfd As New Windows.Forms.SaveFileDialog
            sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            If .sTranscriptFile = "" Then .sTranscriptFile = "ADRIFT_1.txt"
            Dim i As Integer = 1
            While IO.File.Exists(.sTranscriptFile)
                .sTranscriptFile = "ADRIFT_" & i & ".txt"
            End While
            sfd.FileName = .sTranscriptFile
            sfd.DefaultExt = "txt"
            If sfd.FileName.Length > 3 AndAlso Not sfd.FileName.ToLower.EndsWith("txt") Then sfd.FileName = ""
            If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'UTMMain.Tools("miStartTranscript").SharedProps.Caption = "Stop Transcript"
                .sTranscriptFile = sfd.FileName
            End If
        End With

    End Sub


    Private Sub StopTranscript()
        MessageBox.Show("Saving Transcript stopped." & vbCrLf & vbCrLf & "The file was saved as """ & UserSession.sTranscriptFile & """.", "ADRIFT Runner", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Sub txtInput_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInput.KeyDown

        Try
            With UserSession
                bIgnore = False

                If Locked Then
                    e.Handled = True
                    Exit Sub
                End If

                If UserSession.UserSplash IsNot Nothing AndAlso UserSession.UserSplash.Visible Then
                    e.Handled = True
                    UserSession.UserSplash.Hide()
                    Exit Sub
                End If

                If iCommand > .salCommands.Count - 1 Then iCommand = .salCommands.Count - 1

                Select Case e.KeyCode
                    'Case Keys.Escape
                    '    OpenAdventureDialog(Me.ofd)
                    Case Keys.Enter
                        e.Handled = True
                        e.SuppressKeyPress = True
                        bIgnore = True
                        'If txtInput.Text <> "" AndAlso .salCommands.Count > 0 Then
                        '    .salCommands.Add("")
                        '    iCommand = .salCommands.Count - 1
                        '    .salCommands(iCommand - 1) = txtInput.Text.Substring(2)
                        '    UserSession.ClearAutoCompletes()
                        '    UserSession.Process(txtInput.Text.Substring(2).Trim)
                        'End If
                        SubmitCommand()
                    Case Keys.Up
                        If iCommand > 0 Then
                            iCommand -= 1
                            'UserSession.InitialiseInputBox()
                            ''txtInput.SelectedText = salCommands(iCommand)
                            ''txtInput.SelectionStart = txtInput.Text.Length
                            'txtInput.AppendText(.salCommands(iCommand))
                            SetInput(.salCommands(iCommand))
                        End If
                        e.Handled = True
                    Case Keys.Down
                        If iCommand < .salCommands.Count - 1 Then
                            iCommand += 1
                            'UserSession.InitialiseInputBox()
                            ''txtInput.SelectedText = salCommands(iCommand)
                            ''txtInput.SelectionStart = txtInput.Text.Length
                            'txtInput.AppendText(.salCommands(iCommand))
                            SetInput(.salCommands(iCommand))
                        End If
                        e.Handled = True
                    Case Keys.Left
                        If txtInput.SelectionStart <= 2 Then e.Handled = True
                    Case Keys.Back
                        If txtInput.SelectionStart <= 2 Then
                            e.Handled = True
                            e.SuppressKeyPress = True
                        End If
                        ' Otherwise, let it flow...
                    Case Keys.OemQuotes
                        If txtInput.SelectionStart = 2 Then
                            UserSession.InitialiseInputBox("@")
                            e.SuppressKeyPress = True
                            e.Handled = True
                        End If
                    Case Else
                        Application.DoEvents()
                        If iCommand > -1 AndAlso .salCommands.Count > iCommand Then
                            If txtInput.Text.Length = 2 Then
                                ' Weird Mono bug
                                Dim cTyped As Char = ChrW(e.KeyValue)
                                If Char.IsLetterOrDigit(cTyped) Then
                                    If e.Shift Then
                                        cTyped = UCase(cTyped)
                                    Else
                                        cTyped = LCase(cTyped)
                                    End If
                                    txtInput.AppendText(cTyped)
                                End If
                            End If
                            .salCommands(iCommand) = txtInput.Text.Substring(2)
                        End If
                       
                        If Not .bAutoComplete OrElse (Adventure IsNot Nothing AndAlso Adventure.eGameState <> clsAction.EndGameEnum.Running) OrElse (txtInput.Tag IsNot Nothing AndAlso txtInput.Tag.ToString = "Comment") Then Exit Sub
                        If txtInput.Text.Length < 2 Then Exit Sub

                        .DoAutoComplete()
                End Select
            End With

        Catch ex As Exception
            ErrMsg("KeyDown error", ex)
        End Try

    End Sub


    Public Sub SetInput(ByVal sText As String)
        UserSession.InitialiseInputBox()
        txtInput.AppendText(sText)
    End Sub


    Public Sub SubmitCommand()

        With UserSession
            If txtInput.Text <> "" AndAlso .salCommands.Count > 0 Then                
                btnSubmit.Enabled = False
                .salCommands.Add("")
                iCommand = .salCommands.Count - 1
                .salCommands(iCommand - 1) = txtInput.Text.Substring(2)
                .ClearAutoCompletes()
                Adventure.Turns += 1
                .Process(txtInput.Text.Substring(2).Trim)
                btnSubmit.Visible = False
                btnSubmit.Enabled = True
            End If
        End With

    End Sub


    Friend Sub SetBackgroundColour(Optional ByVal colBackground As Color = Nothing)
        If colBackground = Nothing Then colBackground = GetBackgroundColour()
        fRunner.txtOutput.BackColor = colBackground
        fRunner.pnlTop.BackColor = colBackground
        fRunner.txtInput.BackColor = colBackground
        fRunner.pnlBottom.BackColor = colBackground
    End Sub

    Friend Sub SetInputColour(Optional ByVal colInput As Color = Nothing)
        If colInput = Nothing Then colInput = GetInputColour()
        fRunner.txtInput.ForeColor = colInput
    End Sub


    Private Sub frmRunner_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fRunner = Me
        GlobalStartup()
        SetBackgroundColour()
        SetInputColour()

        'Dim colBackground As Color = ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "Background", ColorTranslator.ToOle(Color.Black).ToString)))
        'fRunner.txtOutput.BackColor = colBackground
        'fRunner.pnlTop.BackColor = colBackground
        'fRunner.txtInput.BackColor = colBackground
        'fRunner.pnlBottom.BackColor = colBackground
        'colInput = ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "Text1", ColorTranslator.ToOle(Color.FromArgb(210, 37, 39)).ToString)))
        'colOutput = ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "Text2", ColorTranslator.ToOle(Color.FromArgb(25, 165, 138)).ToString)))

#If Not Mono Then
        RestoreLayout()
        eStyle = EnumParseViewStyle(GetSetting("ADRIFT", "Generator", "ViewStyle", "Standard"))
        eColour = EnumParseColourScheme(GetSetting("ADRIFT", "Generator", "ColourScheme", "Blue"))
        Infragistics.Win.Office2007ColorTable.ColorScheme = eColour
        CType(UTMMain.Tools("AutoComplete"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = CBool(GetSetting("ADRIFT", "Generator", "Auto Complete", "True"))
        GetFormPosition(Me, UTMMain, UDMRunner)
#Else
        miShowMap.Checked = CBool(GetSetting("ADRIFT", "Runner", "ShowMap", "1"))
        miShowGraphics.Checked = CBool(GetSetting("ADRIFT", "Runner", "ShowGraphics", "1"))
        miAutoComplete.Checked = CBool(GetSetting("ADRIFT", "Generator", "Auto Complete", "True"))
        If miAutoComplete.Checked Then UserSession.bAutoComplete = True ' Doesn't seem to fire on load       
        FullScreen(CBool(GetSetting("ADRIFT", "Runner", "FullScreen", "0")))
        GetFormPosition(Me)
#End If
        UserSession.Map.LockMapCentre = SafeBool(GetSetting("ADRIFT", "Runner", "CentreMapLock", "0"))
        UserSession.Map.LockPlayerCentre = SafeBool(GetSetting("ADRIFT", "Runner", "MapPlayerLock", "0"))
        AddPrevious()
        UserSession.LoadMacros()
        UserSession.RunnerStartup()
    End Sub

    Private Sub frmRunner_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        SaveFormPosition(Me)
        'SaveLayout()

        'If Me.WindowState = FormWindowState.Normal Then
        '    SaveSetting("ADRIFT", "Runner", "Window Height", (Me.Height * 15).ToString)
        '    SaveSetting("ADRIFT", "Runner", "Window Width", (Me.Width * 15).ToString)
        'End If

    End Sub

    Private Sub txtOutput_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutput.GotFocus
        txtInput.Focus()
    End Sub

    Private bIgnore As Boolean = False
    Private Sub txtInput_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInput.KeyPress

        If bIgnore Then
            bIgnore = False
            Exit Sub ' Avoid an oddity where KeyPress is firing as well as KeyDown.Enter
        End If

        If bWaitKey AndAlso Not btnMore.Visible Then
            Adventure.sReferencedText(0) = e.KeyChar
            e.Handled = True
            bWaitKey = False
            Exit Sub
        End If

        If btnMore.Visible Then
            btnMore_Click(Nothing, Nothing)
            e.Handled = True
            Exit Sub
        End If

        Select Case e.KeyChar
            Case " "c, "'"c ' keys when pressed skip the auto-complete highlighted word
                If txtInput.SelectionLength > 0 Then txtInput.SelectionStart = txtInput.Text.Length
        End Select

    End Sub


    Private bSettingSelection As Boolean = False
    Private Sub txtInput_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInput.SelectionChanged
        If bSettingSelection Then Exit Sub
        bSettingSelection = True
        If txtInput.SelectionStart < 2 AndAlso txtInput.Text.Length > 1 Then
            txtInput.SelectionStart = 2
            If Adventure IsNot Nothing Then
                txtInput.SelectionFont = Adventure.DefaultFont
            Else
                txtInput.SelectionFont = New Font("Arial", 12)
            End If
        End If
        bSettingSelection = False
    End Sub


    Private Sub txtInput_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInput.TextChanged

        'If txtInput.Text = "" Then 
        UserSession.BuildAutos()
    End Sub



    'Private Sub UDMRunner_AfterDockChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneEventArgs) Handles UDMRunner.AfterDockChange, UDMRunner.AfterToggleDockState
    '    If Map.ParentForm.Name = Me.Name Then
    '        SetMapButtons(True)
    '        Map.ToolStrip1.Visible = False
    '    Else
    '        SetMapButtons(False)
    '        Map.ToolStrip1.Visible = True
    '    End If
    'End Sub



    'Private Sub UDMRunner_AfterPaneButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneButtonEventArgs) Handles UDMRunner.AfterPaneButtonClick
    '    If e.Button = Infragistics.Win.UltraWinDock.PaneButton.Close Then
    '        If Not Map.Visible Then SetMapButtons(False)
    '    End If
    'End Sub


    'Private Sub UDMRunner_AfterSplitterDrag(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PanesEventArgs) Handles UDMRunner.AfterSplitterDrag
    '    SetMargins()
    'End Sub


    'Private Sub UDMRunner_PaneHidden(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneHiddenEventArgs) Handles UDMRunner.PaneHidden

    '    If e.Pane.Closed Then
    '        If e.Pane.Text = "Graphics" Then
    '            UTMMain.Tools("ShowGraphics").SharedProps.Enabled = True
    '        ElseIf e.Pane.Text = "Map" Then
    '            UTMMain.Tools("ShowMap").SharedProps.Enabled = True
    '            SetMapButtons(False)
    '        End If
    '    End If
    '    SetMargins()

    'End Sub


    Private Sub frmRunner_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        SetMargins()
    End Sub


    Private Function IsHex(ByVal sHex As String) As Boolean
        For i As Integer = 0 To sHex.Length - 1
            If "0123456789ABCDEF".IndexOf(sHex(i)) = -1 Then Return False
        Next
        Return True
    End Function


    Private WithEvents tmrSplash As New Timer

    Private Sub frmRunner_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        tmrSplash.Interval = 3000
        tmrSplash.Start()

        Try
            If Environment.GetCommandLineArgs.Length > 1 Then
                Dim sExecutable As String = ""
                For i As Integer = 1 To Environment.GetCommandLineArgs.Length - 1
                    If sExecutable <> "" Then sExecutable &= " "
                    sExecutable &= Environment.GetCommandLineArgs(i)
                Next
                If IO.File.Exists(sExecutable) Then
                    If UserSession.OpenAdventure(sExecutable) Then Exit Sub
                End If
            Else
                '' Work out whether we have a TAF appended on the end.  If so, run that in Executable mode
                '' Grab out the last 8 bytes, and see if it converts to a size
                'Dim bData(5) As Byte
                'Dim fStream As New IO.FileStream(Application.ExecutablePath, IO.FileMode.Open, IO.FileAccess.Read)
                'fStream.Seek(fStream.Length - 6, IO.SeekOrigin.Begin)
                'fStream.Read(bData, 0, 6)
                'fStream.Close()

                'Dim sFileSize As String = (New System.Text.ASCIIEncoding).GetString(bData).ToUpper
                'If IsHex(sFileSize) Then
                If bEXE AndAlso UserSession.OpenAdventure(Application.ExecutablePath, True) Then Exit Sub
                'End If
            End If

            UserSession.Display("ADRIFT Runner Version 5.0<br><>© Campbell Wild 1998-2019<br>Last build: 6th June 2016 (Release " & SafeInt(Application.ProductVersion.Replace("5.0.", "")).ToString("0") & ")", True) '©

        Catch ex As Exception
            ErrMsg("Startup Error", ex)
        End Try

    End Sub

    Private Sub btnMore_Click(sender As Object, e As System.EventArgs) Handles btnMore.Click
        With txtOutput
            btnMore.Visible = False
            UserSession.iPreviousOffset = .GetCharIndexFromPosition(New Point(.Width, .Height))
            ScrollToEnd(txtOutput)
        End With
    End Sub


    Private Sub pnlBottom_Resize(sender As Object, e As System.EventArgs) Handles pnlBottom.Resize
        If btnMore.Visible Then
            btnMore.Size = New Size(pnlBottom.Size.Width - 1, pnlBottom.Size.Height - 1)
        End If
    End Sub

    Private Sub tmrSplash_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrSplash.Tick
        tmrSplash.Stop()
        If fSplash IsNot Nothing Then fSplash.Close()
    End Sub

    Private Sub txtOutput_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtOutput.MouseClick
        OutputClicked(txtInput, txtOutput, ctxMenu, MousePosition, btnSubmit, e)
    End Sub

    Private Sub txtOutput_VScroll(sender As Object, e As System.EventArgs) Handles txtOutput.VScroll     
        ' If we have scrolled the screen right to the bottom, get rid of the button
        If btnMore.Visible Then
            If txtOutput.GetCharIndexFromPosition(New Point(txtOutput.Width, txtOutput.Height)) >= txtOutput.TextLength - 1 Then
                btnMore.Visible = False
            End If
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        btnSubmit.Enabled = False
        SubmitCommand()
        btnSubmit.Visible = False
        btnSubmit.Enabled = True
    End Sub


    Private Sub ctxMenu_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ctxMenu.ItemClicked
        If e.ClickedItem.Text.StartsWith("Type """) Then
            txtInput.SelectedText = e.ClickedItem.Text.Substring(6, e.ClickedItem.Text.Length - 7) & " "
            btnSubmit.Visible = True
        Else
            txtInput.Text = "XX" & e.ClickedItem.Text
            SubmitCommand()
        End If
    End Sub

    Friend WithEvents SplitContainerTextOther As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerMapGraphics As System.Windows.Forms.SplitContainer
    Friend WithEvents Description As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Score As System.Windows.Forms.StatusBarPanel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMacros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miOpenAdventure As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miOpenGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miRestartGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miSaveGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSaveGameAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miStartTranscript As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miRecentAdventures As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miFullScreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDebugger As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAutoComplete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEditMacros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miShowMap As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miShowGraphics As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAboutADRIFT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAboutAdventure As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UserStatus As System.Windows.Forms.StatusBarPanel

    'Private Sub UDMRunner_PaneDisplayed(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneDisplayedEventArgs) Handles UDMRunner.PaneDisplayed
    '    Select Case True
    '        Case e.Pane.Control Is Map
    '            SetMapButtons(True)
    '    End Select
    'End Sub

End Class

