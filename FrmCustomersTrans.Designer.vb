<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomersTrans
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtNetPurchase = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.totalarabic = New System.Windows.Forms.TextBox()
        Me.txtperoid = New System.Windows.Forms.TextBox()
        Me.totaldebit = New System.Windows.Forms.TextBox()
        Me.totalcredit = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnView = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CustomerCode = New System.Windows.Forms.TextBox()
        Me.CustomerName = New System.Windows.Forms.ComboBox()
        Me.DateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.c2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.a1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.a2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.a3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNetPurchase
        '
        Me.txtNetPurchase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNetPurchase.Location = New System.Drawing.Point(48, 35)
        Me.txtNetPurchase.Name = "txtNetPurchase"
        Me.txtNetPurchase.Size = New System.Drawing.Size(275, 20)
        Me.txtNetPurchase.TabIndex = 4
        Me.txtNetPurchase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtNetPurchase)
        Me.GroupBox3.Controls.Add(Me.totalarabic)
        Me.GroupBox3.Controls.Add(Me.txtperoid)
        Me.GroupBox3.Controls.Add(Me.totaldebit)
        Me.GroupBox3.Controls.Add(Me.totalcredit)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(3, 559)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1010, 100)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "الاجماليات"
        '
        'totalarabic
        '
        Me.totalarabic.ForeColor = System.Drawing.Color.Maroon
        Me.totalarabic.Location = New System.Drawing.Point(49, 64)
        Me.totalarabic.Name = "totalarabic"
        Me.totalarabic.Size = New System.Drawing.Size(643, 20)
        Me.totalarabic.TabIndex = 3
        Me.totalarabic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtperoid
        '
        Me.txtperoid.Location = New System.Drawing.Point(698, 67)
        Me.txtperoid.Name = "txtperoid"
        Me.txtperoid.Size = New System.Drawing.Size(167, 20)
        Me.txtperoid.TabIndex = 1
        Me.txtperoid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'totaldebit
        '
        Me.totaldebit.ForeColor = System.Drawing.Color.Red
        Me.totaldebit.Location = New System.Drawing.Point(703, 35)
        Me.totaldebit.Name = "totaldebit"
        Me.totaldebit.Size = New System.Drawing.Size(162, 20)
        Me.totaldebit.TabIndex = 0
        Me.totaldebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'totalcredit
        '
        Me.totalcredit.ForeColor = System.Drawing.Color.Green
        Me.totalcredit.Location = New System.Drawing.Point(525, 35)
        Me.totalcredit.Name = "totalcredit"
        Me.totalcredit.Size = New System.Drawing.Size(167, 20)
        Me.totalcredit.TabIndex = 2
        Me.totalcredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(329, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "صافى مبيعات العميل خلال الفترة :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(882, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "رصيد كشف العميل :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(882, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = " اجمالى حركات العميل:"
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnClose.Location = New System.Drawing.Point(86, 41)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(99, 39)
        Me.BtnClose.TabIndex = 6
        Me.BtnClose.Text = "إغلاق"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnClose)
        Me.GroupBox2.Controls.Add(Me.BtnPrint)
        Me.GroupBox2.Controls.Add(Me.BtnView)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.CustomerCode)
        Me.GroupBox2.Controls.Add(Me.CustomerName)
        Me.GroupBox2.Controls.Add(Me.DateTo)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.DateFrom)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1010, 100)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnPrint.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnPrint.Location = New System.Drawing.Point(203, 42)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(99, 36)
        Me.BtnPrint.TabIndex = 5
        Me.BtnPrint.Text = "طباعة"
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'BtnView
        '
        Me.BtnView.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnView.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnView.Location = New System.Drawing.Point(327, 40)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(99, 41)
        Me.BtnView.TabIndex = 4
        Me.BtnView.Text = "عرض"
        Me.BtnView.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(940, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "رمز العميل :"
        '
        'CustomerCode
        '
        Me.CustomerCode.Location = New System.Drawing.Point(834, 31)
        Me.CustomerCode.Name = "CustomerCode"
        Me.CustomerCode.Size = New System.Drawing.Size(100, 20)
        Me.CustomerCode.TabIndex = 0
        '
        'CustomerName
        '
        Me.CustomerName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CustomerName.FormattingEnabled = True
        Me.CustomerName.Location = New System.Drawing.Point(557, 31)
        Me.CustomerName.Name = "CustomerName"
        Me.CustomerName.Size = New System.Drawing.Size(270, 21)
        Me.CustomerName.TabIndex = 1
        '
        'DateTo
        '
        Me.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTo.Location = New System.Drawing.Point(557, 60)
        Me.DateTo.Name = "DateTo"
        Me.DateTo.Size = New System.Drawing.Size(122, 20)
        Me.DateTo.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(685, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "الى تاريخ :"
        '
        'DateFrom
        '
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFrom.Location = New System.Drawing.Point(812, 60)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.Size = New System.Drawing.Size(122, 20)
        Me.DateFrom.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(940, 63)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "من تاريخ :"
        '
        'c2
        '
        Me.c2.DataPropertyName = "ItemName"
        Me.c2.FillWeight = 50.0!
        Me.c2.HeaderText = "رقم السند"
        Me.c2.Name = "c2"
        '
        'Column10
        '
        Me.Column10.HeaderText = "flg"
        Me.Column10.Name = "Column10"
        Me.Column10.Visible = False
        '
        'c1
        '
        Me.c1.DataPropertyName = "ItemCode"
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = "now"
        Me.c1.DefaultCellStyle = DataGridViewCellStyle1
        Me.c1.FillWeight = 50.0!
        Me.c1.HeaderText = "نوع الحركة"
        Me.c1.Name = "c1"
        '
        'a1
        '
        Me.a1.FillWeight = 60.0!
        Me.a1.HeaderText = "تاريخ السند"
        Me.a1.Name = "a1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1016, 662)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "شاشة كشف تفصيلى للعميل"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DataGridView1)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(3, 116)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1010, 443)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "التفاصيل"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c1, Me.c2, Me.a1, Me.a2, Me.a3, Me.Column5, Me.Column8, Me.Column10})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1004, 424)
        Me.DataGridView1.TabIndex = 0
        '
        'a2
        '
        Me.a2.FillWeight = 108.5566!
        Me.a2.HeaderText = "البيان"
        Me.a2.Name = "a2"
        '
        'a3
        '
        Me.a3.FillWeight = 50.0!
        Me.a3.HeaderText = "عليه/مدين"
        Me.a3.Name = "a3"
        '
        'Column5
        '
        Me.Column5.FillWeight = 50.0!
        Me.Column5.HeaderText = "له/دائن"
        Me.Column5.Name = "Column5"
        '
        'Column8
        '
        Me.Column8.HeaderText = "BarCode"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'FrmCustomersTrans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 662)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "FrmCustomersTrans"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "واى إن للبرمجيات"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtNetPurchase As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents totalarabic As System.Windows.Forms.TextBox
    Friend WithEvents txtperoid As System.Windows.Forms.TextBox
    Friend WithEvents totaldebit As System.Windows.Forms.TextBox
    Friend WithEvents totalcredit As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnView As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents CustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents DateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents c2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents a1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents a2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents a3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
