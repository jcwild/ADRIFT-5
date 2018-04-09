Public Class frmPickKeys
    Inherits System.Windows.Forms.Form

    Private P As Point
    Private bMultiple As Boolean
    Private bLoaded As Boolean = False

#Region " Windows Form Designer generated code "

    Friend Sub New(ByVal P As Point, ByVal Multiple As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.P = P
        Me.bMultiple = Multiple

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
    Friend WithEvents lvwKeys As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lvwKeys = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'lvwKeys
        '
        Me.lvwKeys.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lvwKeys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwKeys.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvwKeys.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwKeys.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwKeys.FullRowSelect = True
        Me.lvwKeys.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvwKeys.Location = New System.Drawing.Point(0, 0)
        Me.lvwKeys.Name = "lvwKeys"
        Me.lvwKeys.Size = New System.Drawing.Size(206, 10)
        Me.lvwKeys.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwKeys.TabIndex = 0
        Me.lvwKeys.UseCompatibleStateImageBehavior = False
        Me.lvwKeys.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 184
        '
        'frmPickKeys
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(206, 10)
        Me.Controls.Add(Me.lvwKeys)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPickKeys"
        Me.ShowInTaskbar = False
        Me.Text = "PickKeys"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        Const WM_PAINT As Integer = &HF  ' 15

        Select Case m.Msg
            Case WM_PAINT
                If lvwKeys.View = View.Details AndAlso lvwKeys.Columns.Count > 0 Then
                    lvwKeys.Columns(lvwKeys.Columns.Count - 1).Width = Me.Width ' -2
                End If
        End Select

        MyBase.WndProc(m)

    End Sub


    Private Sub frmPickKeys_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.LostFocus, MyBase.Deactivate
        Me.Visible = False
    End Sub

    Private Sub lvwKeys_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwKeys.SelectedIndexChanged
        If bLoaded AndAlso Not bMultiple Then Me.Visible = False
    End Sub

    Private Sub frmPickKeys_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated        
        bLoaded = True
    End Sub

    Private Sub frmPickKeys_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged

        If Me.Visible Then
            Me.Location = P            
            If lvwKeys.Items.Count > 0 Then
                If CInt(lvwKeys.Items.Count * lvwKeys.TopItem.Bounds.Height) > Screen.PrimaryScreen.WorkingArea.Height - Me.Top Then
                    Me.Height = Screen.PrimaryScreen.WorkingArea.Height - Me.Top - 20
                    lvwKeys.Columns(lvwKeys.Columns.Count - 1).Width = Me.Width - 20
                Else
                    Me.Height = CInt(lvwKeys.Items.Count * lvwKeys.TopItem.Bounds.Height) + 5 '.25)
                    lvwKeys.Columns(lvwKeys.Columns.Count - 1).Width = Me.Width - 5
                End If
            End If
        End If
    End Sub

End Class
