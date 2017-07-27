Public Class FrmSalesInvoice
    Dim t As Decimal
    Sub ShowRecrd(vcode As String)

        Dim str = "select * from SalesInvoice where InvoiceCode=N'" & (vcode) & "'"
        Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            MsgBox("لم يتم العثور على السند يرجى التاكد من رقم الفاتورة", MsgBoxStyle.Exclamation, "رسالة تنبيه")
        Else

            Dim dr = dt.Rows(0)
            On Error Resume Next
            InvoiceCode.Text = dr!InvoiceCode
            Invoicetype.Text = dr!Invoicetype
            SalesTax.Text = Val(dr!SalesTax)
            InvoiceDate.Value = dr!InvoiceDate
            Note.Text = dr!Note
            CustomerName.Text = dr!CustomerName
            'Invoicetype.Text = dr!Invoicetype
            Invoicetype.SelectedIndex = dr!Invoicetype
            InvoiceDelayDays.Text = dr!InvoiceDelayDays
            InvoiceDelayDate.Text = dr!InvoiceDelayDate
            TotalInvoice.Text = dr!TotalInvoice
            TotalDiscount.Text = dr!TotalDiscount
            NetInvoice.Text = dr!NetInvoice
            PaidPayment.Text = dr!PaidPayment
            PaidPaymenArabic.Text = dr!PaidPaymenArabic
            RemainInvoice.Text = dr!RemainInvoice
            RemainInvoiceArabic.Text = dr!RemainInvoiceArabic

        End If
        adp.Dispose()
        ds.Dispose()
        dt.Dispose()

        '=========================================عرض تفاصيل سند المبيعات
        adp = New SqlClient.SqlDataAdapter("select * from SalesInvoicesDetails where InvoiceCode=N'" & (vcode) & "'", SQLconn)
        ds = New DataSet
        adp.Fill(ds)
        dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            DataGridView1.Rows.Add()
            'InvoiceCode.Text = dr!InvoiceCode
            DataGridView1.Rows(i).Cells(0).Value = dt.Rows(i).Item("ItemCode")
            DataGridView1.Rows(i).Cells(1).Value = dt.Rows(i).Item("ItemName")
            DataGridView1.Rows(i).Cells(2).Value = dt.Rows(i).Item("Unit")
            DataGridView1.Rows(i).Cells(3).Value = dt.Rows(i).Item("UnitPrice")
            DataGridView1.Rows(i).Cells(4).Value = dt.Rows(i).Item("Quantity")
            DataGridView1.Rows(i).Cells(5).Value = dt.Rows(i).Item("Discount")
            DataGridView1.Rows(i).Cells(6).Value = dt.Rows(i).Item("TotalPrice")



        Next

        BtnSave.Enabled = False
        BtnEdit.Enabled = True
        BtnDelete.Enabled = True

    End Sub
    Sub calctotals()
        On Error Resume Next
        Dim t As Decimal
        Dim td = Convert.ToDecimal(TotalDiscount.Text)
        Dim tdes = Convert.ToDecimal(TotalDiscount.Text)
        NetInvoice.Text = Format(Convert.ToDecimal(TotalInvoice.Text) - td, "#0.000")
        PaidPayment.Text = Format(Convert.ToDecimal(TotalInvoice.Text) - tdes, "#0.000")
        For I = 0 To DataGridView1.Rows.Count - 1
            t = (t) + Val(DataGridView1.Rows(I).Cells(5).Value)
        Next
        TotalDiscount.Text = Format(t, "#0.000")
    End Sub

    Function checkRows(x, y) As Boolean
        checkRows = True
        For k = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(k).Cells(2).Value = x And DataGridView1.Rows(k).Cells(0).Value = y Then
                MsgBox("لايمكن إضافة نفس الوحدة مرتين للصنف الواحد", MsgBoxStyle.Critical, "خطأ")
                checkRows = False
                Exit Function
            End If
        Next
    End Function
    Sub Calc_SalesTax()
        Dim t As Double = 0.0
        Dim d As Double = 0.0
        For i = 0 To DataGridView1.Rows.Count - 1
            '================================جمع عمود اجمالى الصنف
            t = (t) + Val(DataGridView1.Rows(i).Cells(6).Value)

            '================================جمع عمود اجمالى الخصم
            d = (d) + Val(DataGridView1.Rows(i).Cells(5).Value)

        Next
        '====================================احتساب قيمة الضريبة
        Dim s = (Val(SalesTax.Text) / 100)
        Dim sum = Format(Val(t) * Val(s), "0.000")
        '====================================إحتساب اجمالى الفاتورة
        TotalInvoice.Text = Format(Val(t) + Val(sum) - Val(d), "0.000")
        '====================================عرض اجمالى الخصم 
        TotalDiscount.Text = Format(Val(d), "0.000")

        Me.TotalInvoiceArabic.Text = IsLaM(Val(Me.TotalInvoice.Text), "Egypt")

        Me.PaidPaymenArabic.Text = IsLaM(Val(Me.PaidPayment.Text), "Egypt")

        Me.RemainInvoiceArabic.Text = IsLaM(Val(Me.RemainInvoice.Text), "Egypt")

    End Sub
    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        ErrorProvider1.SetError(CustomerName, "")
        ErrorProvider1.SetError(Label5, "")
        ErrorProvider1.SetError(InvoiceDelayDays, "")

        On Error Resume Next
        For i = 0 To GroupBox2.Controls.Count
            If TypeOf GroupBox2.Controls(i) Is TextBox Then GroupBox2.Controls(i).Text = ""
            If TypeOf GroupBox2.Controls(i) Is DateTimePicker Then GroupBox2.Controls(i).Text = Now.Date.Date
            If TypeOf GroupBox2.Controls(i) Is ComboBox Then GroupBox2.Controls(i).Text = ""
        Next

        On Error Resume Next
        For i = 0 To GroupBox3.Controls.Count
            If TypeOf GroupBox3.Controls(i) Is TextBox Then GroupBox3.Controls(i).Text = ""
        Next

        On Error Resume Next
        For i = 0 To GroupBox5.Controls.Count
            If TypeOf GroupBox5.Controls(i) Is TextBox Then GroupBox5.Controls(i).Text = 0.0
        Next

        InvoiceDelayDays.Text = "" : InvoiceDelayDate.Text = ""

        CustomerName.Text = ""

        FillComboList(CustomerName, "Customers", "CustomerName", True)

        Invoicetype.SelectedIndex = 0
        InvoiceDate.Value = Now.Date
        InvoiceDelayDays.Text = ""
        InvoiceDelayDate.Text = ""

        InvoiceCode.Text = Format(GET_LAST_RECORD("SalesInvoice", "InvoiceID") + 1, "INVC000000")

        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns(7).Visible = True
        'DataGridView1.Columns(8).Visible = True
        BtnSave.Enabled = True
        BtnEdit.Enabled = False
        BtnDelete.Enabled = False

        GroupBox6.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()

    End Sub

    Private Sub FrmSalesInvoice_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BtnNew_Click(Nothing, Nothing)

    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        If CustomerName.SelectedIndex < 0 Then
            MsgBox("أدخل اسم العميل", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(CustomerName, "يجب إختيار العميل من القائمة")
            CustomerName.Focus()
            Exit Sub
        End If

        If Invoicetype.SelectedIndex < 0 Then
            MsgBox("أدخل نوع الفاتورة", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(Label5, "يجب تحديد نوع الفاتورة من القائمة")
            Invoicetype.Focus()
            Exit Sub
        End If


        If Invoicetype.SelectedIndex = 1 And InvoiceDelayDays.Text = String.Empty Then
            MsgBox("يرجى تحديد عدد ايام تأجيل الاستحقاق", MsgBoxStyle.Critical, "تعليمات")
            Exit Sub
        End If

        If InvoiceDelayDate.Text.Trim <> "" Then
            If Format(InvoiceDate.Value, "yyyy/MM/dd") < Format(DateValue(InvoiceDelayDate.Text), "yyyy/MM/dd") Then
                MsgBox("تاريخ فاتورة العرض اكبر من تاريخ الفاتورة الحالية", MsgBoxStyle.Exclamation, "خطأ")
                Exit Sub
            End If
        End If

        For k = 0 To DataGridView1.Rows.Count - 1
            If Val(DataGridView1.Rows(k).Cells(1).Value) = Nothing Then
                DataGridView1.Rows.Remove(DataGridView1.Rows(k))
            End If
        Next


        For k = 0 To DataGridView1.Rows.Count - 1
            If Val(DataGridView1.Rows(k).Cells(4).Value) = 0 Then
                MsgBox("يرجى التاكد من من كميات الاصناف ", MsgBoxStyle.Exclamation, "تنبيه")
            End If

        Next

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("يجب إدخال صنف واحد على الاقل لاتمام عملية الحفظ", MsgBoxStyle.Critical, "تعليمات")
            Exit Sub
        End If

        Try
            Dim str = "select * from SalesInvoice where InvoiceCode=N'" & InvoiceCode.Text & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                InvoiceCode.Text = Format(GET_LAST_RECORD("SalesInvoice", "InvoiceID") + 1, "INVC000000")

            Else

                Dim dr = dt.NewRow
                dr!InvoiceCode = InvoiceCode.Text
                dr!Invoicetype = Invoicetype.Text
                dr!SalesTax = Val(SalesTax.Text)
                dr!InvoiceDate = InvoiceDate.Value
                dr!Note = Note.Text
                dr!CustomerName = CustomerName.Text
                If Invoicetype.SelectedIndex = 1 Then
                    dr!InvoiceDelayDays = InvoiceDelayDays.Text
                    dr!InvoiceDelayDate = InvoiceDelayDate.Text
                End If

                dr!TotalInvoice = Convert.ToDecimal(TotalInvoice.Text)
                dr!TotalDiscount = Convert.ToDecimal(TotalDiscount.Text)
                dr!NetInvoice = Convert.ToDecimal(NetInvoice.Text)
                dr!PaidPayment = Convert.ToDecimal(PaidPayment.Text)
                dr!PaidPaymenArabic = PaidPaymenArabic.Text
                dr!RemainInvoice = Convert.ToDecimal(RemainInvoice.Text)
                dr!RemainInvoiceArabic = RemainInvoiceArabic.Text
                dr!status = True

                dt.Rows.Add(dr)
                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)

            End If
            adp.Dispose()
            ds.Dispose()
            dt.Dispose()

            '=========================================حفظ تفاصيل سند المبيعات
            adp = New SqlClient.SqlDataAdapter("select * from SalesInvoicesDetails", SQLconn)
            ds = New DataSet
            adp.Fill(ds)
            dt = ds.Tables(0)
            For i = 0 To DataGridView1.Rows.Count - 1
                Dim dr = dt.NewRow
                dr!InvoiceCode = InvoiceCode.Text
                dr!ItemCode = DataGridView1.Rows(i).Cells(0).Value
                dr!ItemName = DataGridView1.Rows(i).Cells(1).Value
                dr!Unit = DataGridView1.Rows(i).Cells(2).Value
                dr!UnitPrice = DataGridView1.Rows(i).Cells(3).Value
                dr!Quantity = DataGridView1.Rows(i).Cells(4).Value
                dr!Discount = Convert.ToDecimal(DataGridView1.Rows(i).Cells(5).Value)
                dr!TotalPrice = DataGridView1.Rows(i).Cells(6).Value
                dt.Rows.Add(dr)
                Dim cmd_Builder1 As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)

            Next
            '============================================إضافة الحركة المالية للعميل=================
            Dim sql = ""
            If Invoicetype.SelectedIndex = 0 Then
                sql = "فاتورة المبيعات النقدية رقم :" & InvoiceCode.Text
            ElseIf Invoicetype.SelectedIndex = 1 Then
                sql = "فاتورة المبيعات الآجلة رقم :" & InvoiceCode.Text
            End If
            CustomerTrans(CustomerName.Text, "فاتورة مبيعات", InvoiceCode.Text, InvoiceDate.Value, sql, 0, TotalInvoice.Text)

            BtnNew_Click(sender, e)
            MsgBox("تم حفظ بيانات فاتورة المبيعات ف قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            'End Try
            'MsgBox("فشل فى عملية الحفظ ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        End Try


    End Sub

    Private Sub Invoicetype_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Invoicetype.SelectedIndexChanged
        ErrorProvider1.SetError(Invoicetype, "")
        If Invoicetype.SelectedIndex = 1 Then
            PaidPayment.Text = ""
            PaidPaymenArabic.Text = ""
            RemainInvoice.ReadOnly = True
            RemainInvoice.Text = NetInvoice.Text
            RemainInvoice_TextChanged(Nothing, Nothing)
            GroupBox3.Enabled = True
            InvoiceDelayDays.Text = ""
            InvoiceDelayDate.Text = ""
        Else
            PaidPayment.Text = NetInvoice.Text
            PaidPayment_TextChanged(Nothing, Nothing)
            RemainInvoice.ReadOnly = False
            RemainInvoice.Text = ""
            RemainInvoiceArabic.Text = ""
            GroupBox3.Enabled = False
        End If
    End Sub

    Private Sub InvoiceDelayDays_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles InvoiceDelayDays.KeyPress
        If InvoiceDelayDays.Text.Length > 11 Then
            e.Handled = True
            Return
        End If
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub InvoiceDelayDays_TextChanged(sender As System.Object, e As System.EventArgs) Handles InvoiceDelayDays.TextChanged
        ErrorProvider1.SetError(InvoiceDelayDays, "")
        If Val(InvoiceDelayDays.Text) > 0 Then
            InvoiceDelayDate.Text = DateAdd(DateInterval.Day, Val(InvoiceDelayDays.Text), CType(InvoiceDate.Text, Date))
        Else
            InvoiceDelayDate.Text = ""
        End If
    End Sub

    Private Sub CustomerName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CustomerName.SelectedIndexChanged
        If CustomerName.SelectedIndex >= 0 Then
            ErrorProvider1.SetError(CustomerName, "")

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FrmCustomers.Show()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        frmOp = 30
        Dim F As New FrmItems
        PuFillDataGridView(F.DataGridView2, "select * from Items  where status='true' order by itemName")
        F.ComboBox1.SelectedIndex = 4
        F.BtnSearch.Show()
        F.GroupBox9.Visible = True
        F.SearchExit.Visible = False
        F.BtnEx.Visible = True
        F.GroupBox1.Visible = False
        F.GroupBox9.BringToFront()
        F.ShowDialog()
    End Sub

    Private Sub FrmSalesInvoice_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            frmOp = 30

            Dim F As New FrmItems
            PuFillDataGridView(F.DataGridView2, "select * from Items  where status='true' order by itemName")
            F.ComboBox1.SelectedIndex = 4
            F.BtnSearch.Show()
            F.SearchExit.Visible = False
            F.BtnEx.Visible = True
            F.GroupBox9.Visible = True
            F.GroupBox1.Visible = False
            F.GroupBox9.BringToFront()
            F.ShowDialog()
        End If

        If e.KeyCode = Keys.F3 Then
            FrmSalesInvoiceBarCode.ShowDialog()

        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Calc_SalesTax()
        If e.ColumnIndex = -1 Then Exit Sub
        Dim colName As String = CType(sender, DataGridView).Columns(e.ColumnIndex).Name

        If colName = "Column3" Then
            SearchUnit_Price.ShowDialog()

        End If


        If colName = "a1" Then
            FillUnitPrice(FrmUnitPrice.DataGridView1, DataGridView1.CurrentRow.Cells(0).Value, DataGridView1.CurrentRow.Cells(9).Value)
            FrmUnitPrice.ShowDialog()

        End If
    End Sub

    Private Sub BtnExit_Click(sender As System.Object, e As System.EventArgs) Handles BtnExit.Click
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        For I = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(I).Cells(7).Value = " حذف"
        Next
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = -1 Or DataGridView1.Rows.Count = 0 Then Exit Sub
        Dim ColName = CType(sender, DataGridView).Columns(e.ColumnIndex).Name
        If ColName = "ColumnUndo" Then
            If DataGridView1.Rows.Count = 0 Then Exit Sub
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        End If
        If ColName = "Column1" Then DataGridView1.Rows.Add()

        If ColName = "Column2" Then
            If DataGridView1.Rows.Count = 0 Then Exit Sub
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)

            For k = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(k).Cells(1).Value = Nothing Then
                    DataGridView1.Rows.Remove(DataGridView1.Rows(k))
                Else
                    Exit Sub
                End If
            Next
            TotalInvoice.Text = 0
            Calc_SalesTax()
            TotalDiscount.Text = 0
            Dim t = 0
            For i = 0 To DataGridView1.Rows.Count - 1
                t = (t) + (DataGridView1.Rows(i).Cells(5).Value)
            Next

            TotalDiscount.Text = Format((t), "0.000")
            If DataGridView1.Rows.Count = 0 Then
                BtnSave.Enabled = False
                Button1.Enabled = True

            End If
        End If


    End Sub

    Private Sub BtnBarCode_Click(sender As System.Object, e As System.EventArgs) Handles BtnBarCode.Click
        On Error Resume Next
        For k = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(k).Cells(1).Value = Nothing Then
                DataGridView1.Rows.Remove(DataGridView1.Rows(k))
            End If
        Next
        DataGridView1.ClearSelection()
        'Dim i = DataGridView1.Rows.Add
        'DataGridView1.Rows(DataGridView1.Rows.Count - 1).Selected = True
        'RowIndex = i
        FrmSalesInvoiceBarCode.ShowDialog()

    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

        'SendKeys.Send("{up}")
        'SendKeys.Send("{right}")

        'If (e.ColumnIndex = 3) Then 'Checking numeric value for Column1 only
        '    If DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value <> Nothing Then
        '        Dim value As String = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        '        If Not Information.IsNumeric(value) Then
        '            MessageBox.Show("Please enter Numerc Value.")
        '            DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
        '            Exit Sub
        '        End If
        '    End If
        'End If
        'On Error Resume Next
        'Dim value As String = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        'If Char.IsDigit(value) Or value = "." Then


        '    If DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.Split(".")(1).Length < 2 Then
        '        If Char.IsDigit(value) = False Then DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty

        '    Else
        '        'e.Handled = True
        '    End If
        'Else
        '    'e.Handled = True
        'End If

        'If e.ColumnIndex = -1 Then Exit Sub

        Dim ColName = CType(sender, DataGridView).Columns(e.ColumnIndex).Name
        If ColName = "a1" Or ColName = "a2" Or ColName = "a3" Then
            Dim c, y, z, t As Decimal
            On Error Resume Next
            If IsDBNull(DataGridView1.CurrentRow.Cells(3).Value) = True Then c = 0 Else c = (DataGridView1.CurrentRow.Cells(3).Value)
            If IsDBNull(DataGridView1.CurrentRow.Cells(4).Value) = True Then y = 0 Else y = (DataGridView1.CurrentRow.Cells(4).Value)
            If IsDBNull(DataGridView1.CurrentRow.Cells(5).Value) = True Then z = 0 Else z = (DataGridView1.CurrentRow.Cells(5).Value)
            t = (c * y) - z
            DataGridView1.CurrentRow.Cells(6).Value = Format((t), "0.000")
            DataGridView1.CurrentRow.Cells(3).Value = Format((c), "0.000")
            DataGridView1.CurrentRow.Cells(4).Value = Format((y), "0")
            DataGridView1.CurrentRow.Cells(5).Value = Format((z), "0.000")

            '================================================
            TotalInvoice.Text = 0
            Calc_SalesTax()
            TotalDiscount.Text = 0
            t = 0
            For i = 0 To DataGridView1.Rows.Count - 1
                t = (t) + (DataGridView1.Rows(i).Cells(5).Value)

            Next
            TotalDiscount.Text = Format((t), "0.000")

            '==================================================
            ColName = CType(sender, DataGridView).Columns(e.ColumnIndex).Name

            If ColName = "a1" Then
                If Val(DataGridView1.CurrentRow.Cells(5).Value) > 0 And DataGridView1.CurrentRow.Cells(1).Value <> Nothing Then
                    For k = 0 To DataGridView1.Rows.Count - 1
                        If DataGridView1.Rows(k).Cells(1).Value = Nothing Then
                            DataGridView1.Rows.Remove(DataGridView1.Rows(k))
                        End If
                    Next
                    DataGridView1.ClearSelection()
                    Dim i = DataGridView1.Rows.Add
                    DataGridView1.Rows(DataGridView1.Rows.Count - 1).Selected = True
                    BtnSave.Enabled = True

                End If
                '===========================================================================

            End If
        End If



        '==================================== حساب اجمالى سعر الصنف
        'Dim x = DataGridView1.CurrentRow.Cells(3).Value * DataGridView1.CurrentRow.Cells(4).Value
        'x = x - Val(DataGridView1.CurrentRow.Cells(5).Value)
        'DataGridView1.CurrentRow.Cells(6).Value = Format(x, "0.000")

        'Calc_SalesTax()
    End Sub

    Private Sub PaidPaymenArabic_TextChanged(sender As System.Object, e As System.EventArgs) Handles PaidPaymenArabic.TextChanged


    End Sub

    Private Sub RemainInvoiceArabic_TextChanged(sender As System.Object, e As System.EventArgs) Handles RemainInvoiceArabic.TextChanged

    End Sub

    Private Sub PaidPayment_TextChanged(sender As System.Object, e As System.EventArgs) Handles PaidPayment.TextChanged
        On Error Resume Next
        RemainInvoice.Text = Format(Convert.ToDecimal(NetInvoice.Text) - Convert.ToDecimal(PaidPayment.Text), "#,0.000")

        If Val(PaidPayment.Text) > 0 Then
            If Val(t) > 0 Then
                Me.PaidPaymenArabic.Text = IsLaM(Val(Me.PaidPayment.Text), "Egypt")

            Else
                PaidPaymenArabic.Text = ""

            End If
        End If
    End Sub

    Private Sub RemainInvoice_TextChanged(sender As System.Object, e As System.EventArgs) Handles RemainInvoice.TextChanged


        If Val(RemainInvoice.Text) > 0 Then
            If Val(t) > 0 Then
                Me.RemainInvoiceArabic.Text = IsLaM(Val(Me.RemainInvoice.Text), "Egypt")

            Else
                RemainInvoiceArabic.Text = ""

            End If
        End If


    End Sub

    Private Sub TotalInvoice_TextChanged(sender As System.Object, e As System.EventArgs) Handles TotalInvoice.TextChanged
        On Error Resume Next
        NetInvoice.Text = Format(Convert.ToDecimal(TotalInvoice.Text) - Convert.ToDecimal(TotalDiscount.Text), "#0.000")
        PaidPayment.Text = Format(Convert.ToDecimal(TotalInvoice.Text) - Convert.ToDecimal(TotalDiscount.Text), "#0.000")
    End Sub

    Private Sub PaidPayment_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles PaidPayment.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            On Error Resume Next
            PaidPayment.Text = Format(Convert.ToDecimal(PaidPayment.Text), "#0.000")
        End If
    End Sub

    Private Sub PaidPayment_Leave(sender As System.Object, e As System.EventArgs) Handles PaidPayment.Leave
        On Error Resume Next
        PaidPayment.Text = Format(Convert.ToDecimal(PaidPayment.Text), "#0.000")
    End Sub

    Private Sub SalesTax_TextChanged(sender As System.Object, e As System.EventArgs) Handles SalesTax.TextChanged
        Calc_SalesTax()
    End Sub

    Private Sub SalesTax_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles SalesTax.KeyPress
        If Char.IsControl(e.KeyChar) = False Then
            If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Then
                If SalesTax.Text.Contains(".") Then
                    If SalesTax.Text.Split(".")(1).Length < 2 Then
                        If Char.IsDigit(e.KeyChar) = False Then e.Handled = True
                    Else
                        e.Handled = True
                    End If
                End If
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        On Error Resume Next
        Dim x = DataGridView1.CurrentRow.Index
        Dim ColName = CType(sender, DataGridView).Columns(e.ColumnIndex).Name
        DataGridView1.CurrentCell = DataGridView1.Item(ColName, x)
        DataGridView1.BeginEdit(True)
    End Sub

    Private Sub InvoiceDelayDate_TextChanged(sender As System.Object, e As System.EventArgs) Handles InvoiceDelayDate.TextChanged

    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        If CustomerName.SelectedIndex < 0 Then
            MsgBox("أدخل اسم العميل", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(CustomerName, "يجب إختيار العميل من القائمة")
            CustomerName.Focus()
            Exit Sub
        End If

        If Invoicetype.SelectedIndex < 0 Then
            MsgBox("أدخل نوع الفاتورة", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(Label5, "يجب تحديد نوع الفاتورة من القائمة")
            Invoicetype.Focus()
            Exit Sub
        End If


        If Invoicetype.SelectedIndex = 1 And InvoiceDelayDays.Text = String.Empty Then
            MsgBox("يرجى تحديد عدد ايام تأجيل الاستحقاق", MsgBoxStyle.Critical, "تعليمات")
            Exit Sub
        End If

        If InvoiceDelayDate.Text.Trim <> "" Then
            If Format(InvoiceDate.Value, "yyyy/MM/dd") < Format(DateValue(InvoiceDelayDate.Text), "yyyy/MM/dd") Then
                MsgBox("تاريخ فاتورة العرض اكبر من تاريخ الفاتورة الحالية", MsgBoxStyle.Exclamation, "خطأ")
                Exit Sub
            End If
        End If

        For k = 0 To DataGridView1.Rows.Count - 1
            If Val(DataGridView1.Rows(k).Cells(1).Value) = Nothing Then
                DataGridView1.Rows.Remove(DataGridView1.Rows(k))
            End If
        Next


        For k = 0 To DataGridView1.Rows.Count - 1
            If Val(DataGridView1.Rows(k).Cells(4).Value) = 0 Then
                MsgBox("يرجى التاكد من من كميات الاصناف ", MsgBoxStyle.Exclamation, "تنبيه")
            End If

        Next

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("يجب إدخال صنف واحد على الاقل لاتمام عملية الحفظ", MsgBoxStyle.Critical, "تعليمات")
            Exit Sub
        End If

        Try
            Dim str = "select * from SalesInvoice where InvoiceCode=N'" & InvoiceCode.Text.Trim & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt As DataTable
            dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox("لم يتم العثور على السند يرجى التاكد من رقم الفاتورة", MsgBoxStyle.Exclamation, "رسالة تنبيه")
            Else

                Dim dr = dt.Rows(0)
                dr!InvoiceCode = InvoiceCode.Text
                dr!Invoicetype = Invoicetype.Text
                dr!SalesTax = Val(SalesTax.Text)
                dr!InvoiceDate = InvoiceDate.Value
                dr!Note = Note.Text
                dr!CustomerName = CustomerName.Text
                If Invoicetype.SelectedIndex = 1 Then
                    dr!InvoiceDelayDays = InvoiceDelayDays.Text
                    dr!InvoiceDelayDate = InvoiceDelayDate.Text
                End If

                dr!TotalInvoice = Convert.ToDecimal(TotalInvoice.Text)
                dr!TotalDiscount = Convert.ToDecimal(TotalDiscount.Text)
                dr!NetInvoice = Convert.ToDecimal(NetInvoice.Text)
                dr!PaidPayment = Convert.ToDecimal(PaidPayment.Text)
                dr!PaidPaymenArabic = PaidPaymenArabic.Text
                dr!RemainInvoice = Convert.ToDecimal(RemainInvoice.Text)
                dr!RemainInvoiceArabic = RemainInvoiceArabic.Text
                dr!status = True

                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)

            End If
            adp.Dispose()
            ds.Dispose()
            dt.Dispose()
            '========================================== حذف تفاصيل السند السابقة


            Dim cmdd As New SqlClient.SqlCommand
            cmdd.Connection = SQLconn
            cmdd.CommandText = "delete  from SalesInvoicesDetails where InvoiceCode=N'" & InvoiceCode.Text & "'"
            cmdd.ExecuteNonQuery()

            '=========================================حفظ تفاصيل سند المبيعات
            adp = New SqlClient.SqlDataAdapter("select * from SalesInvoicesDetails", SQLconn)
            ds = New DataSet
            adp.Fill(ds)
            dt = ds.Tables(0)
            For i = 0 To DataGridView1.Rows.Count - 1

                Dim dr = dt.NewRow

                dr!InvoiceCode = InvoiceCode.Text
                dr!ItemCode = DataGridView1.Rows(i).Cells(0).Value
                dr!ItemName = DataGridView1.Rows(i).Cells(1).Value
                dr!Unit = DataGridView1.Rows(i).Cells(2).Value
                dr!UnitPrice = DataGridView1.Rows(i).Cells(3).Value
                dr!Quantity = DataGridView1.Rows(i).Cells(4).Value
                dr!Discount = Convert.ToDecimal(DataGridView1.Rows(i).Cells(5).Value)
                dr!TotalPrice = DataGridView1.Rows(i).Cells(6).Value
                dt.Rows.Add(dr)
                Dim cmd_Builder1 As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)

            Next
            '============================================إضافة الحركة المالية للعميل=================
            'Dim sql = ""
            'If SupplierInvoicetype.SelectedIndex = 0 Then
            '    sql = "سند استلام أصناف الفاتورة النقدية رقم :" & SupplierInvoiceCode.Text
            'ElseIf SupplierInvoicetype.SelectedIndex = 1 Then
            '    sql = "سند استلام أصناف الفاتورة الآجلة رقم :" & SupplierInvoiceCode.Text
            'End If
            'SetSupplierTrans(SupplierName.Text, "سند إستلام اصناف", VoucherCode.Text, VoucherDate.Value, sql, 0, TotalVoucher.Text)

            BtnNew_Click(sender, e)
            MsgBox("تم تعديل بيانات فاتورة المبيعات ف قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            'End Try
            'MsgBox("فشل فى عملية الحفظ ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        End Try

    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If MsgBox("سوف يتم حذف فاتورة المبيعات هذه , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

        Try
            Dim str = "select * from SalesInvoice where InvoiceCode=N'" & InvoiceCode.Text & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox(" لم يتم العثور على بيانات الفاتورة ", MsgBoxStyle.Exclamation, "رسالة تنبيه")
            Else
                Dim dr = dt.Rows(0)
                'dr.Delete()
                dr!status = False
                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
                BtnNew_Click(Nothing, Nothing)
                MsgBox("تم حذف الفاتورة وحفظة ف الارشيف  بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
        'Catch
        '    MsgBox("فشل فى عملية الحذف ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        'End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim sql As String = ""

        If TextBox1.Text.Length = 0 Then
            sql = "select * from SalesInvoice where (status=1) order by InvoiceCode"
        Else
            Select Case ComboBox1.SelectedIndex
                Case 0
                    sql = "select * from SalesInvoice order by InvoiceCode "

                Case 1
                    sql = "select * from SalesInvoice where (status=1) and InvoiceCode like N'" & TextBox1.Text.Trim & "%" & "'" & " order by InvoiceCode "

                Case 2
                    sql = "select * from SalesInvoice where (status=1) and CustomerName like N'" & TextBox1.Text.Trim & "%" & "'" & " order by CustomerName "



            End Select
            If Trim(sql) <> "" Then PuFillDataGridView(DataGridView2, sql)

        End If
    End Sub

    Private Sub DataGridView2_Click(sender As System.Object, e As System.EventArgs) Handles DataGridView2.Click
        If DataGridView2.Rows.Count = Nothing Then Exit Sub
        ShowRecrd(DataGridView2.CurrentRow.Cells(1).Value)
        GroupBox6.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
    End Sub

    Private Sub DataGridView2_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView2.RowsAdded
        For I = 0 To DataGridView2.Rows.Count - 1
            DataGridView2.Rows(I).Cells(0).Value = " عرض"
            Dim row As DataGridViewRow = DataGridView2.Rows(I)
            row.Height = 23
        Next
    End Sub

    Private Sub BtnSearch_Click(sender As System.Object, e As System.EventArgs) Handles BtnSearch.Click
        PuFillDataGridView(DataGridView2, " select * from SalesInvoice where (status=1) order by InvoiceCode")
        TextBox1.Text = ""
        'D1.Value = Now.Date
        'D2.Value = Now.Date
        'Panel1.Visible = False
        ComboBox1.SelectedIndex = -1
        GroupBox6.Visible = True
        GroupBox1.Visible = False
        GroupBox6.BringToFront()
    End Sub

    Private Sub SearchExit_Click(sender As System.Object, e As System.EventArgs) Handles SearchExit.Click
        Close()

    End Sub
End Class