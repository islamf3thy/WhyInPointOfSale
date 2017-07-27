<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOS
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.POSInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.POSTotalInvoice = New System.Windows.Forms.TextBox()
        Me.POSADDPayment = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.POSTotalDiscount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.POSInvoicetype = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.POSInvoiceCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PicBarCode = New System.Windows.Forms.PictureBox()
        Me.TxtBarCode = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.POSRemainInvoiceArabic = New System.Windows.Forms.TextBox()
        Me.POSPaidPaymenArabic = New System.Windows.Forms.TextBox()
        Me.POSPaidPayment = New System.Windows.Forms.TextBox()
        Me.POSRemainInvoice = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.a2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.a1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnUndo = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnBarCode = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.itemprice = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.itemName = New System.Windows.Forms.TextBox()
        Me.itemquantity = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.itemUnit = New System.Windows.Forms.ComboBox()
        Me.CmbItems = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.itemCode = New System.Windows.Forms.TextBox()
        Me.GetItemsUnit = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PicBarCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.POSInvoiceDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.POSTotalInvoice)
        Me.GroupBox1.Controls.Add(Me.POSADDPayment)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.POSTotalDiscount)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.POSInvoicetype)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.POSInvoiceCode)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(476, 124)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "بيانات الفاتورة"
        '
        'POSInvoiceDate
        '
        Me.POSInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.POSInvoiceDate.Location = New System.Drawing.Point(276, 54)
        Me.POSInvoiceDate.Name = "POSInvoiceDate"
        Me.POSInvoiceDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.POSInvoiceDate.Size = New System.Drawing.Size(118, 20)
        Me.POSInvoiceDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(400, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "رقم الفاتورة :"
        '
        'POSTotalInvoice
        '
        Me.POSTotalInvoice.Location = New System.Drawing.Point(24, 80)
        Me.POSTotalInvoice.Name = "POSTotalInvoice"
        Me.POSTotalInvoice.Size = New System.Drawing.Size(118, 20)
        Me.POSTotalInvoice.TabIndex = 5
        '
        'POSADDPayment
        '
        Me.POSADDPayment.Location = New System.Drawing.Point(24, 54)
        Me.POSADDPayment.Name = "POSADDPayment"
        Me.POSADDPayment.Size = New System.Drawing.Size(118, 20)
        Me.POSADDPayment.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(148, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "إجمالى الفاتورة :"
        '
        'POSTotalDiscount
        '
        Me.POSTotalDiscount.Location = New System.Drawing.Point(24, 28)
        Me.POSTotalDiscount.Name = "POSTotalDiscount"
        Me.POSTotalDiscount.Size = New System.Drawing.Size(118, 20)
        Me.POSTotalDiscount.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(148, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "إضافة نقدية :"
        '
        'POSInvoicetype
        '
        Me.POSInvoicetype.ForeColor = System.Drawing.Color.Red
        Me.POSInvoicetype.Location = New System.Drawing.Point(276, 80)
        Me.POSInvoicetype.Name = "POSInvoicetype"
        Me.POSInvoicetype.Size = New System.Drawing.Size(118, 20)
        Me.POSInvoicetype.TabIndex = 2
        Me.POSInvoicetype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(148, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "خصم نقدى :"
        '
        'POSInvoiceCode
        '
        Me.POSInvoiceCode.Location = New System.Drawing.Point(276, 28)
        Me.POSInvoiceCode.Name = "POSInvoiceCode"
        Me.POSInvoiceCode.Size = New System.Drawing.Size(118, 20)
        Me.POSInvoiceCode.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(400, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "نوع الفاتورة :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(400, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "تاريخ الفاتورة :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PicBarCode)
        Me.GroupBox2.Controls.Add(Me.TxtBarCode)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(520, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(480, 124)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'PicBarCode
        '
        Me.PicBarCode.BackColor = System.Drawing.Color.White
        Me.PicBarCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicBarCode.Location = New System.Drawing.Point(6, 45)
        Me.PicBarCode.Name = "PicBarCode"
        Me.PicBarCode.Size = New System.Drawing.Size(457, 68)
        Me.PicBarCode.TabIndex = 32
        Me.PicBarCode.TabStop = False
        '
        'TxtBarCode
        '
        Me.TxtBarCode.BackColor = System.Drawing.SystemColors.Info
        Me.TxtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBarCode.Location = New System.Drawing.Point(6, 26)
        Me.TxtBarCode.Multiline = True
        Me.TxtBarCode.Name = "TxtBarCode"
        Me.TxtBarCode.Size = New System.Drawing.Size(457, 22)
        Me.TxtBarCode.TabIndex = 0
        Me.TxtBarCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(235, 0)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(228, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "تعطيل نظام الباركود واستخدام النظام اليدوى"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.POSRemainInvoiceArabic)
        Me.GroupBox5.Controls.Add(Me.POSPaidPaymenArabic)
        Me.GroupBox5.Controls.Add(Me.POSPaidPayment)
        Me.GroupBox5.Controls.Add(Me.POSRemainInvoice)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 499)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(988, 89)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "الاجماليات"
        '
        'POSRemainInvoiceArabic
        '
        Me.POSRemainInvoiceArabic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.POSRemainInvoiceArabic.Location = New System.Drawing.Point(61, 45)
        Me.POSRemainInvoiceArabic.Name = "POSRemainInvoiceArabic"
        Me.POSRemainInvoiceArabic.Size = New System.Drawing.Size(561, 20)
        Me.POSRemainInvoiceArabic.TabIndex = 3
        Me.POSRemainInvoiceArabic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'POSPaidPaymenArabic
        '
        Me.POSPaidPaymenArabic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.POSPaidPaymenArabic.Location = New System.Drawing.Point(61, 19)
        Me.POSPaidPaymenArabic.Name = "POSPaidPaymenArabic"
        Me.POSPaidPaymenArabic.Size = New System.Drawing.Size(561, 20)
        Me.POSPaidPaymenArabic.TabIndex = 2
        Me.POSPaidPaymenArabic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'POSPaidPayment
        '
        Me.POSPaidPayment.Location = New System.Drawing.Point(688, 19)
        Me.POSPaidPayment.Name = "POSPaidPayment"
        Me.POSPaidPayment.Size = New System.Drawing.Size(176, 20)
        Me.POSPaidPayment.TabIndex = 0
        Me.POSPaidPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'POSRemainInvoice
        '
        Me.POSRemainInvoice.ForeColor = System.Drawing.Color.Green
        Me.POSRemainInvoice.Location = New System.Drawing.Point(688, 45)
        Me.POSRemainInvoice.Name = "POSRemainInvoice"
        Me.POSRemainInvoice.Size = New System.Drawing.Size(176, 20)
        Me.POSRemainInvoice.TabIndex = 1
        Me.POSRemainInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(870, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "المبلغ المتبقى :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(870, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "المبلغ المسدد :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DataGridView1)
        Me.GroupBox4.Location = New System.Drawing.Point(277, 142)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(618, 324)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "تفاصيل الاصناف"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.a2, Me.a1, Me.Column7, Me.ColumnUndo, Me.Column8, Me.Column10, Me.Column1})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGreen
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SpringGreen
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(612, 305)
        Me.DataGridView1.TabIndex = 0
        '
        'Column2
        '
        Me.Column2.FillWeight = 108.5566!
        Me.Column2.HeaderText = "إسم الصنف"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.FillWeight = 108.5566!
        Me.Column3.HeaderText = "الوحدة"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'a2
        '
        Me.a2.FillWeight = 108.5566!
        Me.a2.HeaderText = "الكمية"
        Me.a2.Name = "a2"
        Me.a2.ReadOnly = True
        '
        'a1
        '
        Me.a1.FillWeight = 108.5566!
        Me.a1.HeaderText = "سعر الوحدة"
        Me.a1.Name = "a1"
        Me.a1.ReadOnly = True
        Me.a1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Column7
        '
        Me.Column7.FillWeight = 108.5566!
        Me.Column7.HeaderText = "إجمالى السعر"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'ColumnUndo
        '
        Me.ColumnUndo.FillWeight = 50.0!
        Me.ColumnUndo.HeaderText = "حذف"
        Me.ColumnUndo.Name = "ColumnUndo"
        Me.ColumnUndo.ReadOnly = True
        Me.ColumnUndo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnUndo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column8
        '
        Me.Column8.HeaderText = "itemcode"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'Column10
        '
        Me.Column10.HeaderText = "itemserial"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "GetItemsUnit"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'BtnBarCode
        '
        Me.BtnBarCode.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnBarCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnBarCode.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnBarCode.Location = New System.Drawing.Point(901, 205)
        Me.BtnBarCode.Name = "BtnBarCode"
        Me.BtnBarCode.Size = New System.Drawing.Size(99, 39)
        Me.BtnBarCode.TabIndex = 10
        Me.BtnBarCode.Text = "فتح الدرج"
        Me.BtnBarCode.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnExit.Location = New System.Drawing.Point(901, 465)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(99, 34)
        Me.BtnExit.TabIndex = 1
        Me.BtnExit.Text = "إغلاق"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnHelp
        '
        Me.BtnHelp.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnHelp.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnHelp.Location = New System.Drawing.Point(901, 423)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(99, 36)
        Me.BtnHelp.TabIndex = 0
        Me.BtnHelp.Text = "تعليمات"
        Me.BtnHelp.UseVisualStyleBackColor = False
        '
        'BtnSearch
        '
        Me.BtnSearch.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnSearch.Location = New System.Drawing.Point(901, 380)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(99, 37)
        Me.BtnSearch.TabIndex = 14
        Me.BtnSearch.Text = "بحث"
        Me.BtnSearch.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnDelete.Location = New System.Drawing.Point(901, 335)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(99, 39)
        Me.BtnDelete.TabIndex = 13
        Me.BtnDelete.Text = "حذف"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnEdit.Location = New System.Drawing.Point(901, 292)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(99, 37)
        Me.BtnEdit.TabIndex = 12
        Me.BtnEdit.Text = "تعديل"
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnSave.Location = New System.Drawing.Point(901, 250)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(99, 36)
        Me.BtnSave.TabIndex = 11
        Me.BtnSave.Text = "حفظ"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNew.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnNew.Location = New System.Drawing.Point(901, 158)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(99, 41)
        Me.BtnNew.TabIndex = 9
        Me.BtnNew.Text = "جديد"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.itemprice)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.itemName)
        Me.GroupBox3.Controls.Add(Me.itemquantity)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.itemUnit)
        Me.GroupBox3.Controls.Add(Me.CmbItems)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 158)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(256, 216)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "البحث السريع"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Traditional Arabic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Button2.Location = New System.Drawing.Point(131, 164)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 37)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "إدراج"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Traditional Arabic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Button4.Location = New System.Drawing.Point(20, 164)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(102, 37)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "إلغاء"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'itemprice
        '
        Me.itemprice.Location = New System.Drawing.Point(6, 130)
        Me.itemprice.Name = "itemprice"
        Me.itemprice.Size = New System.Drawing.Size(167, 20)
        Me.itemprice.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(179, 133)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "السعر :"
        '
        'itemName
        '
        Me.itemName.Location = New System.Drawing.Point(6, 51)
        Me.itemName.Name = "itemName"
        Me.itemName.Size = New System.Drawing.Size(167, 20)
        Me.itemName.TabIndex = 1
        '
        'itemquantity
        '
        Me.itemquantity.Location = New System.Drawing.Point(6, 104)
        Me.itemquantity.Name = "itemquantity"
        Me.itemquantity.Size = New System.Drawing.Size(167, 20)
        Me.itemquantity.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(179, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "الكمية :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(179, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "الوحدة :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(179, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "إسم الصنف :"
        '
        'itemUnit
        '
        Me.itemUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.itemUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.itemUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.itemUnit.FormattingEnabled = True
        Me.itemUnit.Location = New System.Drawing.Point(6, 77)
        Me.itemUnit.Name = "itemUnit"
        Me.itemUnit.Size = New System.Drawing.Size(167, 21)
        Me.itemUnit.TabIndex = 2
        '
        'CmbItems
        '
        Me.CmbItems.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbItems.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItems.FormattingEnabled = True
        Me.CmbItems.Location = New System.Drawing.Point(7, 20)
        Me.CmbItems.Name = "CmbItems"
        Me.CmbItems.Size = New System.Drawing.Size(234, 21)
        Me.CmbItems.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Traditional Arabic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.Location = New System.Drawing.Point(34, 380)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(213, 55)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "تعطيل قراءة الباركود -F2"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'itemCode
        '
        Me.itemCode.Location = New System.Drawing.Point(37, 441)
        Me.itemCode.Name = "itemCode"
        Me.itemCode.Size = New System.Drawing.Size(93, 20)
        Me.itemCode.TabIndex = 6
        '
        'GetItemsUnit
        '
        Me.GetItemsUnit.Location = New System.Drawing.Point(136, 443)
        Me.GetItemsUnit.Name = "GetItemsUnit"
        Me.GetItemsUnit.Size = New System.Drawing.Size(81, 20)
        Me.GetItemsUnit.TabIndex = 6
        '
        'FrmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 605)
        Me.ControlBox = False
        Me.Controls.Add(Me.GetItemsUnit)
        Me.Controls.Add(Me.itemCode)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BtnBarCode)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnHelp)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "FrmPOS"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "واى إن للبرمجيات"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PicBarCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents POSInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents POSTotalInvoice As System.Windows.Forms.TextBox
    Friend WithEvents POSADDPayment As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents POSTotalDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents POSInvoicetype As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents POSInvoiceCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents POSRemainInvoiceArabic As System.Windows.Forms.TextBox
    Friend WithEvents POSPaidPaymenArabic As System.Windows.Forms.TextBox
    Friend WithEvents POSPaidPayment As System.Windows.Forms.TextBox
    Friend WithEvents POSRemainInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BtnBarCode As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbItems As System.Windows.Forms.ComboBox
    Friend WithEvents itemprice As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents itemquantity As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents itemUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents itemName As System.Windows.Forms.TextBox
    Friend WithEvents itemCode As System.Windows.Forms.TextBox
    Friend WithEvents PicBarCode As System.Windows.Forms.PictureBox
    Friend WithEvents TxtBarCode As System.Windows.Forms.TextBox
    Friend WithEvents GetItemsUnit As System.Windows.Forms.TextBox
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents a2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents a1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnUndo As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
