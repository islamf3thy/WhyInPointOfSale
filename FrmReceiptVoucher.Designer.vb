﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReceiptVoucher
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
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.SupplierName = New System.Windows.Forms.ComboBox()
        Me.VoucherDate = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SupplierInvoiceCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.statement = New System.Windows.Forms.TextBox()
        Me.SupplierCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.AmountArabic = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Amount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.VoucherCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnExit)
        Me.GroupBox1.Controls.Add(Me.BtnSave)
        Me.GroupBox1.Controls.Add(Me.BtnNew)
        Me.GroupBox1.Controls.Add(Me.SupplierName)
        Me.GroupBox1.Controls.Add(Me.VoucherDate)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.SupplierInvoiceCode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.statement)
        Me.GroupBox1.Controls.Add(Me.SupplierCode)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.AmountArabic)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Amount)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.VoucherCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(749, 375)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "شاشة سند قبض مالى"
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnExit.Location = New System.Drawing.Point(214, 309)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(99, 47)
        Me.BtnExit.TabIndex = 10
        Me.BtnExit.Text = "إغلاق"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnSave.Location = New System.Drawing.Point(319, 309)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(99, 49)
        Me.BtnSave.TabIndex = 9
        Me.BtnSave.Text = "حفظ"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNew.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnNew.Location = New System.Drawing.Point(424, 309)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(99, 49)
        Me.BtnNew.TabIndex = 8
        Me.BtnNew.Text = "جديد"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'SupplierName
        '
        Me.SupplierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.SupplierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SupplierName.FormattingEnabled = True
        Me.SupplierName.Location = New System.Drawing.Point(36, 108)
        Me.SupplierName.Name = "SupplierName"
        Me.SupplierName.Size = New System.Drawing.Size(481, 21)
        Me.SupplierName.TabIndex = 6
        '
        'VoucherDate
        '
        Me.VoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.VoucherDate.Location = New System.Drawing.Point(55, 30)
        Me.VoucherDate.Name = "VoucherDate"
        Me.VoucherDate.Size = New System.Drawing.Size(122, 20)
        Me.VoucherDate.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(183, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "تاريخ السند :"
        '
        'SupplierInvoiceCode
        '
        Me.SupplierInvoiceCode.Location = New System.Drawing.Point(282, 30)
        Me.SupplierInvoiceCode.Name = "SupplierInvoiceCode"
        Me.SupplierInvoiceCode.Size = New System.Drawing.Size(111, 20)
        Me.SupplierInvoiceCode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(399, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "رقم سند الاستلام :"
        '
        'statement
        '
        Me.statement.Location = New System.Drawing.Point(36, 149)
        Me.statement.Multiline = True
        Me.statement.Name = "statement"
        Me.statement.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.statement.Size = New System.Drawing.Size(598, 141)
        Me.statement.TabIndex = 7
        '
        'SupplierCode
        '
        Me.SupplierCode.Location = New System.Drawing.Point(523, 109)
        Me.SupplierCode.Name = "SupplierCode"
        Me.SupplierCode.Size = New System.Drawing.Size(111, 20)
        Me.SupplierCode.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(640, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "البيان :"
        '
        'AmountArabic
        '
        Me.AmountArabic.ForeColor = System.Drawing.Color.Maroon
        Me.AmountArabic.Location = New System.Drawing.Point(36, 82)
        Me.AmountArabic.Name = "AmountArabic"
        Me.AmountArabic.Size = New System.Drawing.Size(481, 20)
        Me.AmountArabic.TabIndex = 4
        Me.AmountArabic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(640, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "قبض من :"
        '
        'Amount
        '
        Me.Amount.Location = New System.Drawing.Point(523, 82)
        Me.Amount.Name = "Amount"
        Me.Amount.Size = New System.Drawing.Size(111, 20)
        Me.Amount.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(640, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "قيمة السند :"
        '
        'VoucherCode
        '
        Me.VoucherCode.Location = New System.Drawing.Point(523, 30)
        Me.VoucherCode.Name = "VoucherCode"
        Me.VoucherCode.Size = New System.Drawing.Size(111, 20)
        Me.VoucherCode.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(640, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "رقم السند :"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmReceiptVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 375)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmReceiptVoucher"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "واى إن للبرمجيات"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SupplierInvoiceCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents VoucherCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SupplierName As System.Windows.Forms.ComboBox
    Friend WithEvents VoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents statement As System.Windows.Forms.TextBox
    Friend WithEvents SupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents AmountArabic As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Amount As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
