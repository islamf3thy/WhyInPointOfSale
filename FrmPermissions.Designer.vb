<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPermissions
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.UserPassConfirm = New System.Windows.Forms.TextBox()
        Me.l3 = New System.Windows.Forms.Label()
        Me.UserPass = New System.Windows.Forms.TextBox()
        Me.l2 = New System.Windows.Forms.Label()
        Me.UserName = New System.Windows.Forms.TextBox()
        Me.l1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.W8 = New System.Windows.Forms.CheckBox()
        Me.W9 = New System.Windows.Forms.CheckBox()
        Me.W14 = New System.Windows.Forms.CheckBox()
        Me.W7 = New System.Windows.Forms.CheckBox()
        Me.W13 = New System.Windows.Forms.CheckBox()
        Me.W6 = New System.Windows.Forms.CheckBox()
        Me.W12 = New System.Windows.Forms.CheckBox()
        Me.W3 = New System.Windows.Forms.CheckBox()
        Me.W17 = New System.Windows.Forms.CheckBox()
        Me.W16 = New System.Windows.Forms.CheckBox()
        Me.W5 = New System.Windows.Forms.CheckBox()
        Me.W11 = New System.Windows.Forms.CheckBox()
        Me.W2 = New System.Windows.Forms.CheckBox()
        Me.W15 = New System.Windows.Forms.CheckBox()
        Me.W4 = New System.Windows.Forms.CheckBox()
        Me.W10 = New System.Windows.Forms.CheckBox()
        Me.W1 = New System.Windows.Forms.CheckBox()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Txt_ID = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.W18 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Font = New System.Drawing.Font("Traditional Arabic", 15.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(247, 434)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 31
        Me.ListBox1.Location = New System.Drawing.Point(3, 34)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(241, 397)
        Me.ListBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Traditional Arabic", 40.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(174, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(473, 83)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "شاشة صلاحيات المستخدمين"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(866, 89)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.UserPassConfirm)
        Me.GroupBox2.Controls.Add(Me.l3)
        Me.GroupBox2.Controls.Add(Me.UserPass)
        Me.GroupBox2.Controls.Add(Me.l2)
        Me.GroupBox2.Controls.Add(Me.UserName)
        Me.GroupBox2.Controls.Add(Me.l1)
        Me.GroupBox2.Font = New System.Drawing.Font("Traditional Arabic", 15.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(564, 212)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "بيانات المستخدم"
        '
        'UserPassConfirm
        '
        Me.UserPassConfirm.Location = New System.Drawing.Point(30, 141)
        Me.UserPassConfirm.Name = "UserPassConfirm"
        Me.UserPassConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.UserPassConfirm.Size = New System.Drawing.Size(379, 38)
        Me.UserPassConfirm.TabIndex = 2
        '
        'l3
        '
        Me.l3.AutoSize = True
        Me.l3.Location = New System.Drawing.Point(415, 144)
        Me.l3.Name = "l3"
        Me.l3.Size = New System.Drawing.Size(123, 31)
        Me.l3.TabIndex = 2
        Me.l3.Text = "تأكيد كلمة المرور :"
        '
        'UserPass
        '
        Me.UserPass.Location = New System.Drawing.Point(30, 97)
        Me.UserPass.Name = "UserPass"
        Me.UserPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.UserPass.Size = New System.Drawing.Size(379, 38)
        Me.UserPass.TabIndex = 1
        '
        'l2
        '
        Me.l2.AutoSize = True
        Me.l2.Location = New System.Drawing.Point(415, 100)
        Me.l2.Name = "l2"
        Me.l2.Size = New System.Drawing.Size(92, 31)
        Me.l2.TabIndex = 2
        Me.l2.Text = "كلمة المرور :"
        '
        'UserName
        '
        Me.UserName.Location = New System.Drawing.Point(30, 43)
        Me.UserName.Name = "UserName"
        Me.UserName.Size = New System.Drawing.Size(379, 38)
        Me.UserName.TabIndex = 0
        '
        'l1
        '
        Me.l1.AutoSize = True
        Me.l1.Location = New System.Drawing.Point(415, 46)
        Me.l1.Name = "l1"
        Me.l1.Size = New System.Drawing.Size(108, 31)
        Me.l1.TabIndex = 0
        Me.l1.Text = "إسم المستخدم :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.W8)
        Me.GroupBox3.Controls.Add(Me.W9)
        Me.GroupBox3.Controls.Add(Me.W14)
        Me.GroupBox3.Controls.Add(Me.W7)
        Me.GroupBox3.Controls.Add(Me.W13)
        Me.GroupBox3.Controls.Add(Me.W6)
        Me.GroupBox3.Controls.Add(Me.W12)
        Me.GroupBox3.Controls.Add(Me.W3)
        Me.GroupBox3.Controls.Add(Me.W18)
        Me.GroupBox3.Controls.Add(Me.W17)
        Me.GroupBox3.Controls.Add(Me.W16)
        Me.GroupBox3.Controls.Add(Me.W5)
        Me.GroupBox3.Controls.Add(Me.W11)
        Me.GroupBox3.Controls.Add(Me.W2)
        Me.GroupBox3.Controls.Add(Me.W15)
        Me.GroupBox3.Controls.Add(Me.W4)
        Me.GroupBox3.Controls.Add(Me.W10)
        Me.GroupBox3.Controls.Add(Me.W1)
        Me.GroupBox3.Font = New System.Drawing.Font("Traditional Arabic", 15.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(564, 383)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "صلاحيات المستخدم"
        '
        'W8
        '
        Me.W8.AutoSize = True
        Me.W8.Location = New System.Drawing.Point(360, 313)
        Me.W8.Name = "W8"
        Me.W8.Size = New System.Drawing.Size(162, 35)
        Me.W8.TabIndex = 7
        Me.W8.Tag = "A"
        Me.W8.Text = "صلاحيات المستخدمين"
        Me.W8.UseVisualStyleBackColor = True
        '
        'W9
        '
        Me.W9.AutoSize = True
        Me.W9.Location = New System.Drawing.Point(428, 342)
        Me.W9.Name = "W9"
        Me.W9.Size = New System.Drawing.Size(94, 35)
        Me.W9.TabIndex = 8
        Me.W9.Text = "مدير النظام"
        Me.W9.UseVisualStyleBackColor = True
        '
        'W14
        '
        Me.W14.AutoSize = True
        Me.W14.Location = New System.Drawing.Point(101, 175)
        Me.W14.Name = "W14"
        Me.W14.Size = New System.Drawing.Size(151, 35)
        Me.W14.TabIndex = 13
        Me.W14.Tag = "A"
        Me.W14.Text = "كشف تفصيلى لعميل"
        Me.W14.UseVisualStyleBackColor = True
        '
        'W7
        '
        Me.W7.AutoSize = True
        Me.W7.Location = New System.Drawing.Point(409, 252)
        Me.W7.Name = "W7"
        Me.W7.Size = New System.Drawing.Size(113, 35)
        Me.W7.TabIndex = 6
        Me.W7.Tag = "A"
        Me.W7.Text = "سندات القبض"
        Me.W7.UseVisualStyleBackColor = True
        '
        'W13
        '
        Me.W13.AutoSize = True
        Me.W13.Location = New System.Drawing.Point(116, 143)
        Me.W13.Name = "W13"
        Me.W13.Size = New System.Drawing.Size(136, 35)
        Me.W13.TabIndex = 12
        Me.W13.Tag = "A"
        Me.W13.Text = "شاشة بيانات عميل"
        Me.W13.UseVisualStyleBackColor = True
        '
        'W6
        '
        Me.W6.AutoSize = True
        Me.W6.Location = New System.Drawing.Point(414, 223)
        Me.W6.Name = "W6"
        Me.W6.Size = New System.Drawing.Size(108, 35)
        Me.W6.TabIndex = 5
        Me.W6.Tag = "A"
        Me.W6.Text = "سندات الدفع"
        Me.W6.UseVisualStyleBackColor = True
        '
        'W12
        '
        Me.W12.AutoSize = True
        Me.W12.Location = New System.Drawing.Point(64, 96)
        Me.W12.Name = "W12"
        Me.W12.Size = New System.Drawing.Size(188, 35)
        Me.W12.TabIndex = 11
        Me.W12.Tag = "A"
        Me.W12.Text = "نقطة البيع اليومية (الكاشير)"
        Me.W12.UseVisualStyleBackColor = True
        '
        'W3
        '
        Me.W3.AutoSize = True
        Me.W3.Location = New System.Drawing.Point(418, 96)
        Me.W3.Name = "W3"
        Me.W3.Size = New System.Drawing.Size(104, 35)
        Me.W3.TabIndex = 2
        Me.W3.Tag = "A"
        Me.W3.Text = "إتلاف المواد"
        Me.W3.UseVisualStyleBackColor = True
        '
        'W17
        '
        Me.W17.AutoSize = True
        Me.W17.Location = New System.Drawing.Point(135, 313)
        Me.W17.Name = "W17"
        Me.W17.Size = New System.Drawing.Size(117, 35)
        Me.W17.TabIndex = 16
        Me.W17.Tag = "A"
        Me.W17.Text = "التصفح السريع"
        Me.W17.UseVisualStyleBackColor = True
        '
        'W16
        '
        Me.W16.AutoSize = True
        Me.W16.Location = New System.Drawing.Point(119, 255)
        Me.W16.Name = "W16"
        Me.W16.Size = New System.Drawing.Size(133, 35)
        Me.W16.TabIndex = 15
        Me.W16.Tag = "A"
        Me.W16.Text = "النسخ والاسترجاع"
        Me.W16.UseVisualStyleBackColor = True
        '
        'W5
        '
        Me.W5.AutoSize = True
        Me.W5.Location = New System.Drawing.Point(372, 175)
        Me.W5.Name = "W5"
        Me.W5.Size = New System.Drawing.Size(150, 35)
        Me.W5.TabIndex = 4
        Me.W5.Tag = "A"
        Me.W5.Text = "كشف تفصيلى لمورد"
        Me.W5.UseVisualStyleBackColor = True
        '
        'W11
        '
        Me.W11.AutoSize = True
        Me.W11.Location = New System.Drawing.Point(105, 65)
        Me.W11.Name = "W11"
        Me.W11.Size = New System.Drawing.Size(147, 35)
        Me.W11.TabIndex = 10
        Me.W11.Tag = "A"
        Me.W11.Text = "إسترجاع فاتورة عميل"
        Me.W11.UseVisualStyleBackColor = True
        '
        'W2
        '
        Me.W2.AutoSize = True
        Me.W2.Location = New System.Drawing.Point(385, 65)
        Me.W2.Name = "W2"
        Me.W2.Size = New System.Drawing.Size(137, 35)
        Me.W2.TabIndex = 1
        Me.W2.Tag = "A"
        Me.W2.Text = "التوريد الى المخزن"
        Me.W2.UseVisualStyleBackColor = True
        '
        'W15
        '
        Me.W15.AutoSize = True
        Me.W15.Location = New System.Drawing.Point(98, 223)
        Me.W15.Name = "W15"
        Me.W15.Size = New System.Drawing.Size(154, 35)
        Me.W15.TabIndex = 14
        Me.W15.Tag = "A"
        Me.W15.Text = "الاستفسارات والتقارير"
        Me.W15.UseVisualStyleBackColor = True
        '
        'W4
        '
        Me.W4.AutoSize = True
        Me.W4.Location = New System.Drawing.Point(391, 143)
        Me.W4.Name = "W4"
        Me.W4.Size = New System.Drawing.Size(131, 35)
        Me.W4.TabIndex = 3
        Me.W4.Tag = "A"
        Me.W4.Text = "شاشة بيانات مورد"
        Me.W4.UseVisualStyleBackColor = True
        '
        'W10
        '
        Me.W10.AutoSize = True
        Me.W10.Location = New System.Drawing.Point(112, 37)
        Me.W10.Name = "W10"
        Me.W10.Size = New System.Drawing.Size(140, 35)
        Me.W10.TabIndex = 9
        Me.W10.Tag = "A"
        Me.W10.Text = "فاتورة مبيعات عميل"
        Me.W10.UseVisualStyleBackColor = True
        '
        'W1
        '
        Me.W1.AutoSize = True
        Me.W1.Location = New System.Drawing.Point(406, 37)
        Me.W1.Name = "W1"
        Me.W1.Size = New System.Drawing.Size(116, 35)
        Me.W1.TabIndex = 0
        Me.W1.Tag = "A"
        Me.W1.Text = "شاشة الاصناف"
        Me.W1.UseVisualStyleBackColor = True
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnExit.Location = New System.Drawing.Point(731, 535)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(119, 36)
        Me.BtnExit.TabIndex = 6
        Me.BtnExit.Text = "إغلاق"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnDelete.Location = New System.Drawing.Point(565, 536)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(160, 35)
        Me.BtnDelete.TabIndex = 5
        Me.BtnDelete.Text = "حذف"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnEdit.Location = New System.Drawing.Point(399, 535)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(160, 36)
        Me.BtnEdit.TabIndex = 4
        Me.BtnEdit.Text = "تعديل"
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnSave.Location = New System.Drawing.Point(233, 535)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(160, 36)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "حفظ"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNew.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnNew.Location = New System.Drawing.Point(15, 535)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(212, 36)
        Me.BtnNew.TabIndex = 2
        Me.BtnNew.Text = "جديد"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Txt_ID
        '
        Me.Txt_ID.Location = New System.Drawing.Point(343, 630)
        Me.Txt_ID.Name = "Txt_ID"
        Me.Txt_ID.Size = New System.Drawing.Size(197, 20)
        Me.Txt_ID.TabIndex = 47
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(576, 408)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "الصلاحيات"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(576, 408)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "بيانات المستخدمين"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(270, 95)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(584, 434)
        Me.TabControl1.TabIndex = 0
        '
        'W18
        '
        Me.W18.AutoSize = True
        Me.W18.Location = New System.Drawing.Point(49, 342)
        Me.W18.Name = "W18"
        Me.W18.Size = New System.Drawing.Size(203, 35)
        Me.W18.TabIndex = 16
        Me.W18.Tag = "A"
        Me.W18.Text = "القائمة الفرعية للشاشة الرئيسية"
        Me.W18.UseVisualStyleBackColor = True
        '
        'FrmPermissions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 585)
        Me.ControlBox = False
        Me.Controls.Add(Me.Txt_ID)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmPermissions"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "واى إن للبرمجيات"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents UserPassConfirm As System.Windows.Forms.TextBox
    Friend WithEvents l3 As System.Windows.Forms.Label
    Friend WithEvents UserPass As System.Windows.Forms.TextBox
    Friend WithEvents l2 As System.Windows.Forms.Label
    Friend WithEvents UserName As System.Windows.Forms.TextBox
    Friend WithEvents l1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents W9 As System.Windows.Forms.CheckBox
    Friend WithEvents W14 As System.Windows.Forms.CheckBox
    Friend WithEvents W7 As System.Windows.Forms.CheckBox
    Friend WithEvents W13 As System.Windows.Forms.CheckBox
    Friend WithEvents W6 As System.Windows.Forms.CheckBox
    Friend WithEvents W12 As System.Windows.Forms.CheckBox
    Friend WithEvents W3 As System.Windows.Forms.CheckBox
    Friend WithEvents W16 As System.Windows.Forms.CheckBox
    Friend WithEvents W5 As System.Windows.Forms.CheckBox
    Friend WithEvents W11 As System.Windows.Forms.CheckBox
    Friend WithEvents W2 As System.Windows.Forms.CheckBox
    Friend WithEvents W15 As System.Windows.Forms.CheckBox
    Friend WithEvents W4 As System.Windows.Forms.CheckBox
    Friend WithEvents W10 As System.Windows.Forms.CheckBox
    Friend WithEvents W1 As System.Windows.Forms.CheckBox
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents W8 As System.Windows.Forms.CheckBox
    Friend WithEvents W17 As System.Windows.Forms.CheckBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Txt_ID As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents W18 As System.Windows.Forms.CheckBox
End Class
