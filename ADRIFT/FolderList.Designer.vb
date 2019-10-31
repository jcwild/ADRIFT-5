<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FolderList
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FolderList))
        Dim UltraTreeNode1 As Infragistics.Win.UltraWinTree.UltraTreeNode = New Infragistics.Win.UltraWinTree.UltraTreeNode()
        Dim UltraTreeNode2 As Infragistics.Win.UltraWinTree.UltraTreeNode = New Infragistics.Win.UltraWinTree.UltraTreeNode()
        Dim UltraTreeNode3 As Infragistics.Win.UltraWinTree.UltraTreeNode = New Infragistics.Win.UltraWinTree.UltraTreeNode()
        Dim UltraTreeNode4 As Infragistics.Win.UltraWinTree.UltraTreeNode = New Infragistics.Win.UltraWinTree.UltraTreeNode()
        Dim Override1 As Infragistics.Win.UltraWinTree.Override = New Infragistics.Win.UltraWinTree.Override()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.cmsFolders = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miExpand = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.miOpenInNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.miCopyFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miDeleteFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRenameFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.miLocation = New System.Windows.Forms.ToolStripMenuItem()
        Me.miObject = New System.Windows.Forms.ToolStripMenuItem()
        Me.miTask = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEvent = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCharacter = New System.Windows.Forms.ToolStripMenuItem()
        Me.miVariable = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.miTextOverride = New System.Windows.Forms.ToolStripMenuItem()
        Me.miHint = New System.Windows.Forms.ToolStripMenuItem()
        Me.miProperty = New System.Windows.Forms.ToolStripMenuItem()
        Me.sep4 = New System.Windows.Forms.ToolStripSeparator()
        Me.miExportFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.treeFolders = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.cmsFolders.SuspendLayout()
        CType(Me.treeFolders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmsFolders
        '
        Me.cmsFolders.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miExpand, Me.ToolStripSeparator3, Me.miOpenInNew, Me.ToolStripSeparator4, Me.miCopyFolder, Me.ToolStripSeparator2, Me.miDeleteFolder, Me.miRenameFolder, Me.ToolStripSeparator1, Me.miNew, Me.sep4, Me.miExportFolder})
        Me.cmsFolders.Name = "cmsFolders"
        Me.cmsFolders.Size = New System.Drawing.Size(187, 188)
        '
        'miExpand
        '
        Me.miExpand.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.miExpand.Name = "miExpand"
        Me.miExpand.Size = New System.Drawing.Size(186, 22)
        Me.miExpand.Text = "Expand"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(183, 6)
        '
        'miOpenInNew
        '
        Me.miOpenInNew.Name = "miOpenInNew"
        Me.miOpenInNew.Size = New System.Drawing.Size(186, 22)
        Me.miOpenInNew.Text = "Open in new window"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(183, 6)
        '
        'miCopyFolder
        '
        Me.miCopyFolder.Image = Global.ADRIFT.My.Resources.imgCopy
        Me.miCopyFolder.Name = "miCopyFolder"
        Me.miCopyFolder.Size = New System.Drawing.Size(186, 22)
        Me.miCopyFolder.Text = "Copy"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(183, 6)
        '
        'miDeleteFolder
        '
        Me.miDeleteFolder.Image = Global.ADRIFT.My.Resources.imgDelete
        Me.miDeleteFolder.Name = "miDeleteFolder"
        Me.miDeleteFolder.Size = New System.Drawing.Size(186, 22)
        Me.miDeleteFolder.Text = "Delete"
        '
        'miRenameFolder
        '
        Me.miRenameFolder.Name = "miRenameFolder"
        Me.miRenameFolder.Size = New System.Drawing.Size(186, 22)
        Me.miRenameFolder.Text = "Rename"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(183, 6)
        '
        'miNew
        '
        Me.miNew.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNewFolder, Me.ToolStripSeparator5, Me.miLocation, Me.miObject, Me.miTask, Me.miEvent, Me.miCharacter, Me.miVariable, Me.miGroup, Me.miTextOverride, Me.miHint, Me.miProperty})
        Me.miNew.Image = Global.ADRIFT.My.Resources.imgAdd16
        Me.miNew.Name = "miNew"
        Me.miNew.Size = New System.Drawing.Size(186, 22)
        Me.miNew.Text = "Add New"
        '
        'miNewFolder
        '
        Me.miNewFolder.Image = Global.ADRIFT.My.Resources.imgFolderClosed16
        Me.miNewFolder.Name = "miNewFolder"
        Me.miNewFolder.Size = New System.Drawing.Size(144, 22)
        Me.miNewFolder.Text = "Folder"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(141, 6)
        '
        'miLocation
        '
        Me.miLocation.Image = Global.ADRIFT.My.Resources.imgLocation16
        Me.miLocation.Name = "miLocation"
        Me.miLocation.Size = New System.Drawing.Size(144, 22)
        Me.miLocation.Text = "Location"
        '
        'miObject
        '
        Me.miObject.Image = CType(resources.GetObject("miObject.Image"), System.Drawing.Image)
        Me.miObject.Name = "miObject"
        Me.miObject.Size = New System.Drawing.Size(144, 22)
        Me.miObject.Text = "Object"
        '
        'miTask
        '
        Me.miTask.Image = CType(resources.GetObject("miTask.Image"), System.Drawing.Image)
        Me.miTask.Name = "miTask"
        Me.miTask.Size = New System.Drawing.Size(144, 22)
        Me.miTask.Text = "Task"
        '
        'miEvent
        '
        Me.miEvent.Image = CType(resources.GetObject("miEvent.Image"), System.Drawing.Image)
        Me.miEvent.Name = "miEvent"
        Me.miEvent.Size = New System.Drawing.Size(144, 22)
        Me.miEvent.Text = "Event"
        '
        'miCharacter
        '
        Me.miCharacter.Image = Global.ADRIFT.My.Resources.imgCharacter16
        Me.miCharacter.Name = "miCharacter"
        Me.miCharacter.Size = New System.Drawing.Size(144, 22)
        Me.miCharacter.Text = "Character"
        '
        'miVariable
        '
        Me.miVariable.Image = Global.ADRIFT.My.Resources.imgVariable16
        Me.miVariable.Name = "miVariable"
        Me.miVariable.Size = New System.Drawing.Size(144, 22)
        Me.miVariable.Text = "Variable"
        '
        'miGroup
        '
        Me.miGroup.Image = Global.ADRIFT.My.Resources.imgGroup16
        Me.miGroup.Name = "miGroup"
        Me.miGroup.Size = New System.Drawing.Size(144, 22)
        Me.miGroup.Text = "Group"
        '
        'miTextOverride
        '
        Me.miTextOverride.Image = Global.ADRIFT.My.Resources.imgALR16
        Me.miTextOverride.Name = "miTextOverride"
        Me.miTextOverride.Size = New System.Drawing.Size(144, 22)
        Me.miTextOverride.Text = "Text Override"
        '
        'miHint
        '
        Me.miHint.Image = Global.ADRIFT.My.Resources.imgHint16
        Me.miHint.Name = "miHint"
        Me.miHint.Size = New System.Drawing.Size(144, 22)
        Me.miHint.Text = "Hint"
        '
        'miProperty
        '
        Me.miProperty.Image = Global.ADRIFT.My.Resources.imgProperty16
        Me.miProperty.Name = "miProperty"
        Me.miProperty.Size = New System.Drawing.Size(144, 22)
        Me.miProperty.Text = "Property"
        '
        'sep4
        '
        Me.sep4.Name = "sep4"
        Me.sep4.Size = New System.Drawing.Size(183, 6)
        '
        'miExportFolder
        '
        Me.miExportFolder.Image = Global.ADRIFT.My.Resources.imgExport16
        Me.miExportFolder.Name = "miExportFolder"
        Me.miExportFolder.Size = New System.Drawing.Size(186, 22)
        Me.miExportFolder.Text = "Export Folder"
        '
        'treeFolders
        '
        Me.treeFolders.AllowDrop = True
        Me.treeFolders.ContextMenuStrip = Me.cmsFolders
        Me.treeFolders.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.WindowsVista
        Me.treeFolders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeFolders.DrawsFocusRect = Infragistics.Win.DefaultableBoolean.[False]
        Me.treeFolders.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeFolders.FullRowSelect = True
        Me.treeFolders.HideSelection = False
        Me.treeFolders.Location = New System.Drawing.Point(0, 0)
        Me.treeFolders.Name = "treeFolders"
        UltraTreeNode2.Text = "Locations"
        UltraTreeNode3.Text = "Objects"
        UltraTreeNode4.Text = "Tasks"
        UltraTreeNode1.Nodes.AddRange(New Infragistics.Win.UltraWinTree.UltraTreeNode() {UltraTreeNode2, UltraTreeNode3, UltraTreeNode4})
        UltraTreeNode1.Text = "Desktop"
        Me.treeFolders.Nodes.AddRange(New Infragistics.Win.UltraWinTree.UltraTreeNode() {UltraTreeNode1})
        Appearance1.Image = Global.ADRIFT.My.Resources.imgFolder16
        Override1.ExpandedNodeAppearance = Appearance1
        Override1.ItemHeight = 21
        Override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.SingleAutoDrag
        Me.treeFolders.Override = Override1
        Me.treeFolders.ShowLines = False
        Me.treeFolders.ShowRootLines = False
        Me.treeFolders.Size = New System.Drawing.Size(218, 347)
        Me.treeFolders.TabIndex = 0
        '
        'FolderList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.treeFolders)
        Me.Name = "FolderList"
        Me.Size = New System.Drawing.Size(218, 347)
        Me.cmsFolders.ResumeLayout(False)
        CType(Me.treeFolders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents treeFolders As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents cmsFolders As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miExpand As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miOpenInNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miCopyFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDeleteFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miRenameFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miLocation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miObject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miTask As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEvent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miCharacter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miVariable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miTextOverride As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miHint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miProperty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sep4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miExportFolder As System.Windows.Forms.ToolStripMenuItem

End Class
