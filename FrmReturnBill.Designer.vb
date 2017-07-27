<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReturnBill
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
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DataGridMain = New System.Windows.Forms.DataGridView()
        Me.colRet = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colDet = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DataGridDetailes = New System.Windows.Forms.DataGridView()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.D2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.D1 = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtNameSearch = New System.Windows.Forms.TextBox()
        Me.TxtInvSearch = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridDetailes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnExit)
        Me.GroupBox1.Controls.Add(Me.BtnNew)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1156, 751)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "إسترجاع فاتورة مبيعات"
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnExit.Location = New System.Drawing.Point(480, 698)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(127, 41)
        Me.BtnExit.TabIndex = 5
        Me.BtnExit.Text = "إغلاق"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNew.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnNew.Location = New System.Drawing.Point(630, 698)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(128, 41)
        Me.BtnNew.TabIndex = 6
        Me.BtnNew.Text = "جديد"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DataGridMain)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 99)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1153, 304)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "الفواتير"
        '
        'DataGridMain
        '
        Me.DataGridMain.AllowUserToAddRows = False
        Me.DataGridMain.AllowUserToDeleteRows = False
        Me.DataGridMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridMain.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRet, Me.colDet, Me.Column3, Me.Column16, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        Me.DataGridMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridMain.Location = New System.Drawing.Point(3, 16)
        Me.DataGridMain.Name = "DataGridMain"
        Me.DataGridMain.RowHeadersVisible = False
        Me.DataGridMain.Size = New System.Drawing.Size(1147, 285)
        Me.DataGridMain.TabIndex = 0
        '
        'colRet
        '
        Me.colRet.HeaderText = "إسترجاع الفاتورة"
        Me.colRet.Name = "colRet"
        Me.colRet.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colRet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colDet
        '
        Me.colDet.HeaderText = "عرض التفاصيل"
        Me.colDet.Name = "colDet"
        Me.colDet.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "InvoiceDate"
        Me.Column3.HeaderText = "تاريخ الفاتورة"
        Me.Column3.Name = "Column3"
        '
        'Column16
        '
        Me.Column16.DataPropertyName = "InvoiceCode"
        Me.Column16.HeaderText = "رقم الفاتورة"
        Me.Column16.Name = "Column16"
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "CustomerName"
        Me.Column4.HeaderText = "إسم العميل"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "TotalInvoice"
        Me.Column5.HeaderText = "إجمالى الفاتورة"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "Invoicetype"
        Me.Column6.HeaderText = "نوع الفاتورة"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "InvoiceDelayDays"
        Me.Column7.HeaderText = "فترة السماح"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "InvoiceDelayDate"
        Me.Column8.HeaderText = "تاريخ الاستحقاق"
        Me.Column8.Name = "Column8"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DataGridDetailes)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 409)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1150, 272)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "تفاصيل الفاتورة"
        '
        'DataGridDetailes
        '
        Me.DataGridDetailes.AllowUserToAddRows = False
        Me.DataGridDetailes.AllowUserToDeleteRows = False
        Me.DataGridDetailes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridDetailes.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridDetailes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridDetailes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15})
        Me.DataGridDetailes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridDetailes.Location = New System.Drawing.Point(3, 16)
        Me.DataGridDetailes.Name = "DataGridDetailes"
        Me.DataGridDetailes.RowHeadersVisible = False
        Me.DataGridDetailes.Size = New System.Drawing.Size(1144, 253)
        Me.DataGridDetailes.TabIndex = 1
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "ItemCode"
        Me.Column9.HeaderText = "رمز الصنف"
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.DataPropertyName = "ItemName"
        Me.Column10.HeaderText = "اسم الصنف"
        Me.Column10.Name = "Column10"
        '
        'Column11
        '
        Me.Column11.DataPropertyName = "Unit"
        Me.Column11.HeaderText = "الوحدة"
        Me.Column11.Name = "Column11"
        '
        'Column12
        '
        Me.Column12.DataPropertyName = "UnitPrice"
        Me.Column12.HeaderText = "سعر الوحدة"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        Me.Column13.DataPropertyName = "Quantity"
        Me.Column13.HeaderText = "الكمية"
        Me.Column13.Name = "Column13"
        '
        'Column14
        '
        Me.Column14.DataPropertyName = "Discount"
        Me.Column14.HeaderText = "الخصم"
        Me.Column14.Name = "Column14"
        '
        'Column15
        '
        Me.Column15.DataPropertyName = "TotalPrice"
        Me.Column15.HeaderText = "إجمالى السعر"
        Me.Column15.Name = "Column15"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.D2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.D1)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TxtNameSearch)
        Me.GroupBox2.Controls.Add(Me.TxtInvSearch)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1150, 77)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "البحث عن فاتورة عميل"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.Location = New System.Drawing.Point(39, 26)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(74, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "بحث"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'D2
        '
        Me.D2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.D2.Location = New System.Drawing.Point(154, 28)
        Me.D2.Name = "D2"
        Me.D2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.D2.Size = New System.Drawing.Size(118, 20)
        Me.D2.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(278, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "إلى :"
        '
        'D1
        '
        Me.D1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.D1.Location = New System.Drawing.Point(353, 29)
        Me.D1.Name = "D1"
        Me.D1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.D1.Size = New System.Drawing.Size(118, 20)
        Me.D1.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(477, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "تاريخ الفاتورة :"
        '
        'TxtNameSearch
        '
        Me.TxtNameSearch.Location = New System.Drawing.Point(573, 29)
        Me.TxtNameSearch.Name = "TxtNameSearch"
        Me.TxtNameSearch.Size = New System.Drawing.Size(182, 20)
        Me.TxtNameSearch.TabIndex = 3
        '
        'TxtInvSearch
        '
        Me.TxtInvSearch.Location = New System.Drawing.Point(847, 29)
        Me.TxtInvSearch.Name = "TxtInvSearch"
        Me.TxtInvSearch.Size = New System.Drawing.Size(161, 20)
        Me.TxtInvSearch.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(761, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "إسم العميل :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1014, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "رقم الفاتورة :"
        '
        'FrmReturnBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 751)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmReturnBill"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "واى إن للبرمجيات"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DataGridMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DataGridDetailes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNameSearch As System.Windows.Forms.TextBox
    Friend WithEvents TxtInvSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents D2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents D1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridMain As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DataGridDetailes As System.Windows.Forms.DataGridView
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRet As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colDet As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
