<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCountries
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Browers = New System.Windows.Forms.Button()
        Me.C_NAME = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnClose2 = New System.Windows.Forms.Button()
        Me.BtnDelete2 = New System.Windows.Forms.Button()
        Me.BtnEdit2 = New System.Windows.Forms.Button()
        Me.BtnSave2 = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.CT_Name = New System.Windows.Forms.TextBox()
        Me.Country = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnExit)
        Me.GroupBox1.Controls.Add(Me.BtnDelete)
        Me.GroupBox1.Controls.Add(Me.BtnEdit)
        Me.GroupBox1.Controls.Add(Me.BtnSave)
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Controls.Add(Me.Browers)
        Me.GroupBox1.Controls.Add(Me.C_NAME)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 486)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "قائمة الدول"
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnExit.Location = New System.Drawing.Point(121, 440)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(99, 34)
        Me.BtnExit.TabIndex = 5
        Me.BtnExit.Text = "إغلاق"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnDelete.Location = New System.Drawing.Point(16, 397)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(99, 36)
        Me.BtnDelete.TabIndex = 4
        Me.BtnDelete.Text = "حذف"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnEdit.Location = New System.Drawing.Point(121, 397)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(99, 36)
        Me.BtnEdit.TabIndex = 3
        Me.BtnEdit.Text = "تعديل"
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnSave.Location = New System.Drawing.Point(229, 397)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(99, 36)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.Text = "إضافة"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 65)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(316, 316)
        Me.ListBox1.TabIndex = 1
        '
        'Browers
        '
        Me.Browers.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Browers.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Browers.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Browers.Location = New System.Drawing.Point(12, 23)
        Me.Browers.Name = "Browers"
        Me.Browers.Size = New System.Drawing.Size(33, 23)
        Me.Browers.TabIndex = 7
        Me.Browers.Text = "..."
        Me.Browers.UseVisualStyleBackColor = False
        '
        'C_NAME
        '
        Me.C_NAME.Location = New System.Drawing.Point(51, 26)
        Me.C_NAME.Name = "C_NAME"
        Me.C_NAME.Size = New System.Drawing.Size(186, 20)
        Me.C_NAME.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(243, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "أدخل إسم الدولة :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnClose2)
        Me.GroupBox2.Controls.Add(Me.BtnDelete2)
        Me.GroupBox2.Controls.Add(Me.BtnEdit2)
        Me.GroupBox2.Controls.Add(Me.BtnSave2)
        Me.GroupBox2.Controls.Add(Me.ListBox2)
        Me.GroupBox2.Controls.Add(Me.CT_Name)
        Me.GroupBox2.Controls.Add(Me.Country)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(340, 486)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "قائمة المدن"
        '
        'BtnClose2
        '
        Me.BtnClose2.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnClose2.Location = New System.Drawing.Point(121, 438)
        Me.BtnClose2.Name = "BtnClose2"
        Me.BtnClose2.Size = New System.Drawing.Size(99, 34)
        Me.BtnClose2.TabIndex = 6
        Me.BtnClose2.Text = "إغلاق"
        Me.BtnClose2.UseVisualStyleBackColor = False
        '
        'BtnDelete2
        '
        Me.BtnDelete2.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnDelete2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnDelete2.Location = New System.Drawing.Point(16, 394)
        Me.BtnDelete2.Name = "BtnDelete2"
        Me.BtnDelete2.Size = New System.Drawing.Size(99, 37)
        Me.BtnDelete2.TabIndex = 5
        Me.BtnDelete2.Text = "حذف"
        Me.BtnDelete2.UseVisualStyleBackColor = False
        '
        'BtnEdit2
        '
        Me.BtnEdit2.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnEdit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnEdit2.Location = New System.Drawing.Point(121, 394)
        Me.BtnEdit2.Name = "BtnEdit2"
        Me.BtnEdit2.Size = New System.Drawing.Size(99, 37)
        Me.BtnEdit2.TabIndex = 4
        Me.BtnEdit2.Text = "تعديل"
        Me.BtnEdit2.UseVisualStyleBackColor = False
        '
        'BtnSave2
        '
        Me.BtnSave2.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnSave2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnSave2.Location = New System.Drawing.Point(229, 394)
        Me.BtnSave2.Name = "BtnSave2"
        Me.BtnSave2.Size = New System.Drawing.Size(99, 37)
        Me.BtnSave2.TabIndex = 3
        Me.BtnSave2.Text = "إضافة"
        Me.BtnSave2.UseVisualStyleBackColor = False
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(12, 85)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(316, 290)
        Me.ListBox2.TabIndex = 2
        '
        'CT_Name
        '
        Me.CT_Name.Location = New System.Drawing.Point(34, 46)
        Me.CT_Name.Name = "CT_Name"
        Me.CT_Name.Size = New System.Drawing.Size(181, 20)
        Me.CT_Name.TabIndex = 1
        '
        'Country
        '
        Me.Country.FormattingEnabled = True
        Me.Country.Location = New System.Drawing.Point(34, 20)
        Me.Country.Name = "Country"
        Me.Country.Size = New System.Drawing.Size(181, 21)
        Me.Country.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(221, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "أدخل إسم المدينة :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(221, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "اختار الدولة من القائمة :"
        '
        'frmCountries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 486)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmCountries"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "واى إن للبرمجيات"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents C_NAME As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Browers As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnClose2 As System.Windows.Forms.Button
    Friend WithEvents BtnDelete2 As System.Windows.Forms.Button
    Friend WithEvents BtnEdit2 As System.Windows.Forms.Button
    Friend WithEvents BtnSave2 As System.Windows.Forms.Button
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents CT_Name As System.Windows.Forms.TextBox
    Friend WithEvents Country As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
