<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Folder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Folder))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraListViewSubItemColumn1 As Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn = New Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("dtCreated")
        Dim UltraListViewSubItemColumn2 As Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn = New Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("dtUpdated")
        Dim UltraListViewSubItemColumn3 As Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn = New Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("sType")
        Dim UltraListViewSubItemColumn4 As Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn = New Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("sKey")
        Dim UltraListViewSubItemColumn5 As Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn = New Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("iPriority")
        Me.cmsFolder = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAddItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAddObjectToLocation = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAddSubObject = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAddSpecificTask = New System.Windows.Forms.ToolStripMenuItem()
        Me.sep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miView = New System.Windows.Forms.ToolStripMenuItem()
        Me.miIcons = New System.Windows.Forms.ToolStripMenuItem()
        Me.miList = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.miContent = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSortBy = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSortName = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSortCreationDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSortModifiedDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSortType = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSortTaskPriority = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSortByNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.miSortAscending = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSortDescending = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGroupBy = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGroupByType = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGroupByNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.miGroupAscending = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGroupDescending = New System.Windows.Forms.ToolStripMenuItem()
        Me.sep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.sep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNewLocation = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewObject = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewTask = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewCharacter = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewEvent = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewVariable = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewProperty = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewALR = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewHint = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewSynonym = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewUserFunction = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRename = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstContents = New Infragistics.Win.UltraWinListView.UltraListView()
        Me.miExportFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.sep4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsFolder.SuspendLayout()
        CType(Me.lstContents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmsFolder
        '
        Me.cmsFolder.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEdit, Me.miAddItem, Me.miAddObjectToLocation, Me.miAddSubObject, Me.miAddSpecificTask, Me.sep1, Me.miView, Me.miSortBy, Me.miGroupBy, Me.sep2, Me.miCut, Me.miCopy, Me.miPaste, Me.miDelete, Me.sep3, Me.miNew, Me.miRename, Me.sep4, Me.miExportFolder})
        Me.cmsFolder.Name = "cmsFolder"
        Me.cmsFolder.Size = New System.Drawing.Size(198, 380)
        '
        'miEdit
        '
        Me.miEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.miEdit.Image = Global.ADRIFT.My.Resources.imgEdit16
        Me.miEdit.Name = "miEdit"
        Me.miEdit.Size = New System.Drawing.Size(197, 22)
        Me.miEdit.Text = "Edit"
        '
        'miAddItem
        '
        Me.miAddItem.Name = "miAddItem"
        Me.miAddItem.Size = New System.Drawing.Size(197, 22)
        Me.miAddItem.Text = "Add Item"
        Me.miAddItem.Visible = False
        '
        'miAddObjectToLocation
        '
        Me.miAddObjectToLocation.Image = Global.ADRIFT.My.Resources.imgObjectStatic16
        Me.miAddObjectToLocation.Name = "miAddObjectToLocation"
        Me.miAddObjectToLocation.Size = New System.Drawing.Size(197, 22)
        Me.miAddObjectToLocation.Text = "Add Object to Location"
        Me.miAddObjectToLocation.Visible = False
        '
        'miAddSubObject
        '
        Me.miAddSubObject.Image = Global.ADRIFT.My.Resources.imgObjectStatic16
        Me.miAddSubObject.Name = "miAddSubObject"
        Me.miAddSubObject.Size = New System.Drawing.Size(197, 22)
        Me.miAddSubObject.Text = "Add Sub-Object"
        Me.miAddSubObject.Visible = False
        '
        'miAddSpecificTask
        '
        Me.miAddSpecificTask.Image = Global.ADRIFT.My.Resources.imgTaskSpecific16
        Me.miAddSpecificTask.Name = "miAddSpecificTask"
        Me.miAddSpecificTask.Size = New System.Drawing.Size(197, 22)
        Me.miAddSpecificTask.Text = "Add Specific Task"
        Me.miAddSpecificTask.Visible = False
        '
        'sep1
        '
        Me.sep1.Name = "sep1"
        Me.sep1.Size = New System.Drawing.Size(194, 6)
        '
        'miView
        '
        Me.miView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miIcons, Me.miList, Me.miDetails, Me.miContent})
        Me.miView.Name = "miView"
        Me.miView.Size = New System.Drawing.Size(197, 22)
        Me.miView.Text = "View"
        '
        'miIcons
        '
        Me.miIcons.Name = "miIcons"
        Me.miIcons.Size = New System.Drawing.Size(117, 22)
        Me.miIcons.Text = "Icons"
        '
        'miList
        '
        Me.miList.Name = "miList"
        Me.miList.Size = New System.Drawing.Size(117, 22)
        Me.miList.Text = "List"
        '
        'miDetails
        '
        Me.miDetails.Name = "miDetails"
        Me.miDetails.Size = New System.Drawing.Size(117, 22)
        Me.miDetails.Text = "Details"
        '
        'miContent
        '
        Me.miContent.Enabled = False
        Me.miContent.Name = "miContent"
        Me.miContent.Size = New System.Drawing.Size(117, 22)
        Me.miContent.Text = "Content"
        '
        'miSortBy
        '
        Me.miSortBy.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSortName, Me.miSortCreationDate, Me.miSortModifiedDate, Me.miSortType, Me.miSortTaskPriority, Me.miSortByNone, Me.ToolStripSeparator5, Me.miSortAscending, Me.miSortDescending})
        Me.miSortBy.Name = "miSortBy"
        Me.miSortBy.Size = New System.Drawing.Size(197, 22)
        Me.miSortBy.Text = "Sort by"
        '
        'miSortName
        '
        Me.miSortName.Name = "miSortName"
        Me.miSortName.Size = New System.Drawing.Size(149, 22)
        Me.miSortName.Text = "Name"
        '
        'miSortCreationDate
        '
        Me.miSortCreationDate.Name = "miSortCreationDate"
        Me.miSortCreationDate.Size = New System.Drawing.Size(149, 22)
        Me.miSortCreationDate.Text = "Creation Date"
        '
        'miSortModifiedDate
        '
        Me.miSortModifiedDate.Name = "miSortModifiedDate"
        Me.miSortModifiedDate.Size = New System.Drawing.Size(149, 22)
        Me.miSortModifiedDate.Text = "Modified Date"
        '
        'miSortType
        '
        Me.miSortType.Name = "miSortType"
        Me.miSortType.Size = New System.Drawing.Size(149, 22)
        Me.miSortType.Text = "Type"
        '
        'miSortTaskPriority
        '
        Me.miSortTaskPriority.Name = "miSortTaskPriority"
        Me.miSortTaskPriority.Size = New System.Drawing.Size(149, 22)
        Me.miSortTaskPriority.Text = "Task Priority"
        '
        'miSortByNone
        '
        Me.miSortByNone.Name = "miSortByNone"
        Me.miSortByNone.Size = New System.Drawing.Size(149, 22)
        Me.miSortByNone.Text = "(None)"
        Me.miSortByNone.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(146, 6)
        '
        'miSortAscending
        '
        Me.miSortAscending.Name = "miSortAscending"
        Me.miSortAscending.Size = New System.Drawing.Size(149, 22)
        Me.miSortAscending.Text = "Ascending"
        '
        'miSortDescending
        '
        Me.miSortDescending.Name = "miSortDescending"
        Me.miSortDescending.Size = New System.Drawing.Size(149, 22)
        Me.miSortDescending.Text = "Descending"
        '
        'miGroupBy
        '
        Me.miGroupBy.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miGroupByType, Me.miGroupByNone, Me.ToolStripSeparator6, Me.miGroupAscending, Me.miGroupDescending})
        Me.miGroupBy.Name = "miGroupBy"
        Me.miGroupBy.Size = New System.Drawing.Size(197, 22)
        Me.miGroupBy.Text = "Group by"
        '
        'miGroupByType
        '
        Me.miGroupByType.Name = "miGroupByType"
        Me.miGroupByType.Size = New System.Drawing.Size(136, 22)
        Me.miGroupByType.Text = "Type"
        '
        'miGroupByNone
        '
        Me.miGroupByNone.Name = "miGroupByNone"
        Me.miGroupByNone.Size = New System.Drawing.Size(136, 22)
        Me.miGroupByNone.Text = "(None)"
        Me.miGroupByNone.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(133, 6)
        '
        'miGroupAscending
        '
        Me.miGroupAscending.Enabled = False
        Me.miGroupAscending.Name = "miGroupAscending"
        Me.miGroupAscending.Size = New System.Drawing.Size(136, 22)
        Me.miGroupAscending.Text = "Ascending"
        '
        'miGroupDescending
        '
        Me.miGroupDescending.Enabled = False
        Me.miGroupDescending.Name = "miGroupDescending"
        Me.miGroupDescending.Size = New System.Drawing.Size(136, 22)
        Me.miGroupDescending.Text = "Descending"
        '
        'sep2
        '
        Me.sep2.Name = "sep2"
        Me.sep2.Size = New System.Drawing.Size(194, 6)
        '
        'miCut
        '
        Me.miCut.Image = Global.ADRIFT.My.Resources.imgCut
        Me.miCut.Name = "miCut"
        Me.miCut.Size = New System.Drawing.Size(197, 22)
        Me.miCut.Text = "Cut"
        '
        'miCopy
        '
        Me.miCopy.Image = Global.ADRIFT.My.Resources.imgCopy
        Me.miCopy.Name = "miCopy"
        Me.miCopy.Size = New System.Drawing.Size(197, 22)
        Me.miCopy.Text = "Copy"
        '
        'miPaste
        '
        Me.miPaste.Image = Global.ADRIFT.My.Resources.imgPaste
        Me.miPaste.Name = "miPaste"
        Me.miPaste.Size = New System.Drawing.Size(197, 22)
        Me.miPaste.Text = "Paste"
        '
        'miDelete
        '
        Me.miDelete.Image = Global.ADRIFT.My.Resources.imgDelete
        Me.miDelete.Name = "miDelete"
        Me.miDelete.Size = New System.Drawing.Size(197, 22)
        Me.miDelete.Text = "Delete"
        '
        'sep3
        '
        Me.sep3.Name = "sep3"
        Me.sep3.Size = New System.Drawing.Size(194, 6)
        '
        'miNew
        '
        Me.miNew.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNewFolder, Me.ToolStripSeparator3, Me.miNewLocation, Me.miNewObject, Me.miNewTask, Me.miNewCharacter, Me.miNewEvent, Me.miNewVariable, Me.miNewGroup, Me.miNewProperty, Me.miNewALR, Me.miNewHint, Me.miNewSynonym, Me.miNewUserFunction})
        Me.miNew.Image = Global.ADRIFT.My.Resources.imgAdd16
        Me.miNew.Name = "miNew"
        Me.miNew.Size = New System.Drawing.Size(197, 22)
        Me.miNew.Text = "Add New"
        '
        'miNewFolder
        '
        Me.miNewFolder.Image = Global.ADRIFT.My.Resources.imgFolderClosed16
        Me.miNewFolder.Name = "miNewFolder"
        Me.miNewFolder.Size = New System.Drawing.Size(147, 22)
        Me.miNewFolder.Text = "Folder"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(144, 6)
        '
        'miNewLocation
        '
        Me.miNewLocation.Image = Global.ADRIFT.My.Resources.imgLocation16
        Me.miNewLocation.Name = "miNewLocation"
        Me.miNewLocation.Size = New System.Drawing.Size(147, 22)
        Me.miNewLocation.Text = "Location"
        '
        'miNewObject
        '
        Me.miNewObject.Image = Global.ADRIFT.My.Resources.imgObjectDynamic16
        Me.miNewObject.Name = "miNewObject"
        Me.miNewObject.Size = New System.Drawing.Size(147, 22)
        Me.miNewObject.Text = "Object"
        '
        'miNewTask
        '
        Me.miNewTask.Image = CType(resources.GetObject("miNewTask.Image"), System.Drawing.Image)
        Me.miNewTask.Name = "miNewTask"
        Me.miNewTask.Size = New System.Drawing.Size(147, 22)
        Me.miNewTask.Text = "Task"
        '
        'miNewCharacter
        '
        Me.miNewCharacter.Image = Global.ADRIFT.My.Resources.imgCharacter16
        Me.miNewCharacter.Name = "miNewCharacter"
        Me.miNewCharacter.Size = New System.Drawing.Size(147, 22)
        Me.miNewCharacter.Text = "Character"
        '
        'miNewEvent
        '
        Me.miNewEvent.Image = Global.ADRIFT.My.Resources.imgEvent16
        Me.miNewEvent.Name = "miNewEvent"
        Me.miNewEvent.Size = New System.Drawing.Size(147, 22)
        Me.miNewEvent.Text = "Event"
        '
        'miNewVariable
        '
        Me.miNewVariable.Image = Global.ADRIFT.My.Resources.imgVariable16
        Me.miNewVariable.Name = "miNewVariable"
        Me.miNewVariable.Size = New System.Drawing.Size(147, 22)
        Me.miNewVariable.Text = "Variable"
        '
        'miNewGroup
        '
        Me.miNewGroup.Image = Global.ADRIFT.My.Resources.imgGroup16
        Me.miNewGroup.Name = "miNewGroup"
        Me.miNewGroup.Size = New System.Drawing.Size(147, 22)
        Me.miNewGroup.Text = "Group"
        '
        'miNewProperty
        '
        Me.miNewProperty.Image = Global.ADRIFT.My.Resources.imgProperty16
        Me.miNewProperty.Name = "miNewProperty"
        Me.miNewProperty.Size = New System.Drawing.Size(147, 22)
        Me.miNewProperty.Text = "Property"
        '
        'miNewALR
        '
        Me.miNewALR.Image = Global.ADRIFT.My.Resources.imgALR16
        Me.miNewALR.Name = "miNewALR"
        Me.miNewALR.Size = New System.Drawing.Size(147, 22)
        Me.miNewALR.Text = "Text Override"
        '
        'miNewHint
        '
        Me.miNewHint.Image = Global.ADRIFT.My.Resources.imgHint16
        Me.miNewHint.Name = "miNewHint"
        Me.miNewHint.Size = New System.Drawing.Size(147, 22)
        Me.miNewHint.Text = "Hint"
        '
        'miNewSynonym
        '
        Me.miNewSynonym.Image = Global.ADRIFT.My.Resources.imgSynonym16
        Me.miNewSynonym.Name = "miNewSynonym"
        Me.miNewSynonym.Size = New System.Drawing.Size(147, 22)
        Me.miNewSynonym.Text = "Synonym"
        '
        'miNewUserFunction
        '
        Me.miNewUserFunction.Image = Global.ADRIFT.My.Resources.imgFunction16
        Me.miNewUserFunction.Name = "miNewUserFunction"
        Me.miNewUserFunction.Size = New System.Drawing.Size(147, 22)
        Me.miNewUserFunction.Text = "User Function"
        '
        'miRename
        '
        Me.miRename.Name = "miRename"
        Me.miRename.Size = New System.Drawing.Size(197, 22)
        Me.miRename.Text = "Rename"
        '
        'lstContents
        '
        Me.lstContents.AllowDrop = True
        Me.lstContents.ContextMenuStrip = Me.cmsFolder
        Me.lstContents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstContents.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance4.BorderColor = System.Drawing.Color.Red
        Me.lstContents.ItemSettings.Appearance = Appearance4
        Me.lstContents.ItemSettings.HideSelection = False
        Me.lstContents.ItemSettings.HotTracking = True
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(254, Byte), Integer))
        Appearance1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(253, Byte), Integer))
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Appearance1.FontData.UnderlineAsString = "False"
        Appearance1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lstContents.ItemSettings.HotTrackingAppearance = Appearance1
        Me.lstContents.ItemSettings.LassoSelectMode = Infragistics.Win.UltraWinListView.LassoSelectMode.LeftMouseButton
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(253, Byte), Integer))
        Appearance2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(252, Byte), Integer))
        Appearance2.BackColorDisabled = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer))
        Appearance2.BackColorDisabled2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer))
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.Color.Lime
        Appearance2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lstContents.ItemSettings.SelectedAppearance = Appearance2
        Me.lstContents.Location = New System.Drawing.Point(0, 0)
        Me.lstContents.MainColumn.DataType = GetType(String)
        Me.lstContents.MainColumn.Key = "sName"
        Me.lstContents.MainColumn.Text = "Name"
        Me.lstContents.Name = "lstContents"
        Me.lstContents.Size = New System.Drawing.Size(453, 172)
        UltraListViewSubItemColumn1.DataType = GetType(Date)
        UltraListViewSubItemColumn1.Key = "dtCreated"
        UltraListViewSubItemColumn1.Text = "Created"
        UltraListViewSubItemColumn2.DataType = GetType(Date)
        UltraListViewSubItemColumn2.Key = "dtUpdated"
        UltraListViewSubItemColumn2.Text = "Updated"
        UltraListViewSubItemColumn3.DataType = GetType(String)
        UltraListViewSubItemColumn3.Key = "sType"
        UltraListViewSubItemColumn3.Text = "Type"
        UltraListViewSubItemColumn4.DataType = GetType(String)
        UltraListViewSubItemColumn4.Key = "sKey"
        UltraListViewSubItemColumn4.Text = "Key"
        UltraListViewSubItemColumn5.DataType = GetType(Integer)
        UltraListViewSubItemColumn5.Key = "iPriority"
        UltraListViewSubItemColumn5.Text = "Priority"
        Me.lstContents.SubItemColumns.AddRange(New Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn() {UltraListViewSubItemColumn1, UltraListViewSubItemColumn2, UltraListViewSubItemColumn3, UltraListViewSubItemColumn4, UltraListViewSubItemColumn5})
        Me.lstContents.TabIndex = 0
        Me.lstContents.Text = "UltraListView1"
        Me.lstContents.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.Details
        Me.lstContents.ViewSettingsDetails.AutoFitColumns = Infragistics.Win.UltraWinListView.AutoFitColumns.ResizeAllColumns
        Me.lstContents.ViewSettingsDetails.ColumnAutoSizeMode = CType((Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.Header Or Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.VisibleItems), Infragistics.Win.UltraWinListView.ColumnAutoSizeMode)
        Me.lstContents.ViewSettingsDetails.ColumnHeaderStyle = Infragistics.Win.HeaderStyle.XPThemed
        Me.lstContents.ViewSettingsDetails.FullRowSelect = True
        '
        'miExportFolder
        '
        Me.miExportFolder.Image = Global.ADRIFT.My.Resources.imgExport16
        Me.miExportFolder.Name = "miExportFolder"
        Me.miExportFolder.Size = New System.Drawing.Size(197, 22)
        Me.miExportFolder.Text = "Export Folder"
        '
        'sep4
        '
        Me.sep4.Name = "sep4"
        Me.sep4.Size = New System.Drawing.Size(194, 6)
        '
        'Folder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lstContents)
        Me.Name = "Folder"
        Me.Size = New System.Drawing.Size(453, 172)
        Me.cmsFolder.ResumeLayout(False)
        CType(Me.lstContents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstContents As Infragistics.Win.UltraWinListView.UltraListView
    Friend WithEvents cmsFolder As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miIcons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miContent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSortBy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSortName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSortCreationDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSortType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSortAscending As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSortDescending As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miGroupBy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miGroupByType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miGroupByNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miGroupAscending As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miGroupDescending As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miRename As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewLocation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miNewObject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewTask As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewEvent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewCharacter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewVariable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewHint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewProperty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewALR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSortModifiedDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSortByNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAddSpecificTask As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAddItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miSortTaskPriority As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAddObjectToLocation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAddSubObject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewSynonym As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewUserFunction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miExportFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sep4 As System.Windows.Forms.ToolStripSeparator

End Class
