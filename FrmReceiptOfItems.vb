
Public Class FrmReceiptOfItems
    Dim n = ""
    Dim p = ""
    Dim BARCODEVALUE = ""



    Sub ShowRecordData(VCode As String)

        Dim sql = "select * from ReceiptOfItems where VoucherCode=N'" & (VCode) & "'"
        Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            MsgBox("لم يتم العثور على بيانات السند يرجى التحقق من الرقم وإعادة المحاولة", MsgBoxStyle.Exclamation, "رسالة تنبيه")
        Else
            Dim dr = dt.Rows(0)
            On Error Resume Next
            '============================ البيانات الاساسية ========================
            VoucherCode.Text = dr!VoucherCode
            VoucherDate.Text = dr!VoucherDate
            SalesTax.Text = Val(dr!SalesTax)
            SupplierCode.Text = dr!SupplierCode
            Note.Text = dr!Note
            OrderCode.Text = dr!OrderCode
            SupplierName.Text = dr!SupplierName

            SupplierInvoicetype.Text = dr!SupplierInvoicetype
            SupplierInvoiceCode.Text = dr!SupplierInvoiceCode
            SupplierInvoiceDate.Text = dr!SupplierInvoiceDate

            TotalDiscount.Text = dr!TotalDiscount
            TotalVoucher.Text = dr!TotalVoucher
            TotalByArabic.Text = dr!TotalByArabic

            adp.Dispose()
            ds.Dispose()
            dt.Dispose()
            '=========================================عرض تفاصيل سند التوريد
            adp = New SqlClient.SqlDataAdapter("select * from ReceiptOfItemsDetails where VoucherCode=N'" & (VCode) & "'", SQLconn)
            ds = New DataSet
            adp.Fill(ds)
            dt = ds.Tables(0)
            For i = 0 To dt.Rows.Count - 1
                DataGridView1.Rows.Add()
                DataGridView1.Rows(i).Cells(0).Value = dt.Rows(i).Item("ItemCode")
                DataGridView1.Rows(i).Cells(1).Value = dt.Rows(i).Item("ItemName")
                '=========================================تعبئة كومبوبوكس الوحدات
                Dim dgvcc As DataGridViewComboBoxCell
                dgvcc = DataGridView1.Rows(i).Cells(2)
                dgvcc.Items.Add(dt.Rows(i).Item("Unit"))
                dgvcc.Value = dt.Rows(i).Item("Unit")
                '============================================================

                DataGridView1.Rows(i).Cells(3).Value = dt.Rows(i).Item("UnitPrice")
                DataGridView1.Rows(i).Cells(4).Value = dt.Rows(i).Item("Quantity")
                DataGridView1.Rows(i).Cells(5).Value = Convert.ToDecimal(dt.Rows(i).Item("Discount"))
                DataGridView1.Rows(i).Cells(6).Value = dt.Rows(i).Item("TotalPrice")

         
            Next
            BtnSave.Enabled = False
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True

        End If
    End Sub

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
        TotalVoucher.Text = Format(Val(t) + Val(sum) - Val(d), "0.000")
        '====================================عرض اجمالى الخصم 
        TotalDiscount.Text = Format(Val(d), "0.000")

        Me.TotalByArabic.Text = IsLaM(Val(Me.TotalVoucher.Text), "Egypt")
      

    End Sub
    Sub FillSupplierName()
        SupplierName.Items.Clear()
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Suppliers order by SupplierName", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        '--------------------------======================
        For I = 0 To dt.Rows.Count - 1
            SupplierName.Items.Add(dt.Rows(I).Item("SupplierName"))

        Next
    End Sub


    '============================================ جلب كود المورد==============================================================================================
    Sub FillSuppliercode()
        SupplierCode.Text = ""
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Suppliers where SupplierName=N'" & (SupplierName.Text) & "'  order by SupplierName", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        '--------------------------======================
        For I = 0 To dt.Rows.Count - 1
            SupplierCode.Text = (dt.Rows(I).Item("SupplierCode"))

        Next
    End Sub



    Sub GetItemUnits(ItemCode As String)
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Items where itemCode=N'" & ItemCode & "'", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then
            Dim DGVCC As DataGridViewComboBoxCell
            DGVCC = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(2)
            DGVCC.Items.Add(dt.Rows(0).Item("FirstUnit"))
            If dt.Rows(0).Item("SecoundtUnit").ToString <> "" Then DGVCC.Items.Add(dt.Rows(0).Item("SecoundtUnit"))
            If dt.Rows(0).Item("ThirdUnit").ToString <> "" Then DGVCC.Items.Add(dt.Rows(0).Item("ThirdUnit"))
            DataGridView1.ClearSelection()
            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(2).Selected = True

        End If
    End Sub
    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click

        On Error Resume Next
        For i = 0 To GroupBox1.Controls.Count
            If TypeOf GroupBox1.Controls(i) Is TextBox Then GroupBox1.Controls(i).Text = ""
        Next

        For i = 0 To GroupBox2.Controls.Count
            If TypeOf GroupBox2.Controls(i) Is TextBox Then GroupBox2.Controls(i).Text = ""
            If TypeOf GroupBox2.Controls(i) Is ComboBox Then GroupBox2.Controls(i).Text = ""
            If TypeOf GroupBox2.Controls(i) Is DateTimePicker Then GroupBox2.Controls(i).Text = Now.Date

        Next
        For i = 0 To GroupBox4.Controls.Count
            If TypeOf GroupBox4.Controls(i) Is TextBox Then GroupBox4.Controls(i).Text = ""
            If TypeOf GroupBox4.Controls(i) Is TextBox Then GroupBox4.Controls(i).Text = ""
            If TypeOf GroupBox4.Controls(i) Is TextBox Then GroupBox4.Controls(i).Text = ""
        Next

        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        TotalDiscount.Text = ""
        TotalVoucher.Text = ""
        TotalByArabic.Text = ""

        SupplierInvoicetype.SelectedIndex = 0

        VoucherCode.Text = Format(GET_LAST_RECORD("ReceiptOfItems", "Voucherid") + 1, "ROFI000000")
        FillSupplierName()

        GroupBox5.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
        If TextBox1.Text = "" Then Exit Sub
        DataGridView1.Rows.Clear()
        BtnSave.Enabled = True
        BtnEdit.Enabled = False
        BtnDelete.Enabled = False

    End Sub

    Private Sub FrmReceiptOfItems_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BtnNew_Click(Nothing, Nothing)
        BtnSave.Enabled = True
        BtnEdit.Enabled = False
        BtnDelete.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FrmSuppliers.ShowDialog()

    End Sub

    Private Sub SupplierName_DropDown(sender As System.Object, e As System.EventArgs)
        FillSupplierName()
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        If SupplierName.SelectedIndex < 0 Then
            MsgBox("أدخل اسم المورد", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(Label8, "يجب إختيار المورد من القائمة")
            SupplierName.Focus()
            Exit Sub
        End If

        If SupplierInvoicetype.SelectedIndex < 0 Then
            MsgBox("أدخل نوع الفاتورة", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(Label5, "يجب تحديد نوع فاتورة المورد من القائمة")
            SupplierInvoicetype.Focus()
            Exit Sub
        End If

        If Format(SupplierInvoiceDate.Value, "yyy/mm/dd") > Format(DateValue(VoucherDate.Text), "yyyy/mm/dd") Then
            MsgBox("تاريخ سند استلام المواد اكبر من تاريخ فاتورة المورد", MsgBoxStyle.Exclamation, "خطأ")
            Exit Sub
        End If

        'For k = 0 To DataGridView1.Rows.Count - 1
        '    If DataGridView1.Rows(k).Cells(1).Value = Nothing Then
        '        DataGridView1.Rows.Remove(DataGridView1.Rows(k))
        '    End If

        'Next

        For k = 0 To DataGridView1.Rows.Count - 1
            If Val(DataGridView1.Rows(k).Cells(4).Value) = 0 Then
                MsgBox("يرجى التاكد من من كميات الاصناف المستلمة", MsgBoxStyle.Exclamation, "تنبيه")
            End If

        Next

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("يجب إدخال صنف واحد على الاقل لاتمام عملية الحفظ", MsgBoxStyle.Critical, "تعليمات")
            Exit Sub
        End If

        Try
            Dim str = "select * from ReceiptOfItems where VoucherCode=N'" & VoucherCode.Text.Trim & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                VoucherCode.Text = Format(GET_LAST_RECORD("ReceiptOfItems", "Voucherid") + 1, "ROFI000000")

            Else

                Dim dr = dt.NewRow
                dr!VoucherCode = VoucherCode.Text
                dr!VoucherDate = VoucherDate.Value
                dr!SalesTax = Val(SalesTax.Text)
                dr!SupplierCode = SupplierCode.Text
                dr!Note = Note.Text
                dr!OrderCode = OrderCode.Text
                dr!SupplierName = SupplierName.Text

                dr!SupplierInvoicetype = SupplierInvoicetype.Text
                dr!SupplierInvoiceCode = SupplierInvoiceCode.Text
                dr!SupplierInvoiceDate = SupplierInvoiceDate.Value

                dr!TotalDiscount = Val(TotalDiscount.Text)
                dr!TotalVoucher = Val(SupplierInvoiceCode.Text)
                dr!TotalByArabic = TotalByArabic.Text
                dr!status = True
                dt.Rows.Add(dr)
                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)

            End If
            adp.Dispose()
            ds.Dispose()
            dt.Dispose()
           
            '=========================================حفظ تفاصيل سند التوريد
            adp = New SqlClient.SqlDataAdapter("select * from ReceiptOfItemsDetails", SQLconn)
            ds = New DataSet
            adp.Fill(ds)
            dt = ds.Tables(0)
            For i = 0 To DataGridView1.Rows.Count - 1
                Dim dr = dt.NewRow
                dr!VoucherCode = VoucherCode.Text
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
            '============================================إضافة الحركة المالية للمورد=================
            Dim sql = ""
            If SupplierInvoicetype.SelectedIndex = 0 Then
                sql = "سند استلام أصناف الفاتورة النقدية رقم :" & SupplierInvoiceCode.Text
            ElseIf SupplierInvoicetype.SelectedIndex = 1 Then
                sql = "سند استلام أصناف الفاتورة الآجلة رقم :" & SupplierInvoiceCode.Text
            End If
            SetSupplierTrans(SupplierName.Text, "سند إستلام اصناف", VoucherCode.Text, VoucherDate.Value, sql, 0, TotalVoucher.Text)

            BtnNew_Click(sender, e)
            MsgBox("تم حفظ بيانات سند التوريد ف قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            'End Try
            MsgBox("فشل فى عملية الحفظ ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        End Try

        
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        frmOp = 10
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

    Private Sub FrmReceiptOfItems_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            frmOp = 10

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
            FrmReceiptOfItemsBarCode.ShowDialog()

        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'If e.ColumnIndex = -1 Then Exit Sub
        'Dim colName As String = CType(sender, DataGridView).Columns(e.ColumnIndex).Name
        'If colName = "ColName" Then DataGridView1.CurrentRow.Cells(3).Selected = True
        Calc_SalesTax()
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        '==================================== حساب اجمالى سعر الصنف
        Dim x = DataGridView1.CurrentRow.Cells(3).Value * DataGridView1.CurrentRow.Cells(4).Value
        x = x - Val(DataGridView1.CurrentRow.Cells(5).Value)
        DataGridView1.CurrentRow.Cells(6).Value = Format(x, "0.000")
        '====================================حساب اجمالى الفاتورة
        'Dim SuMt As Double = 0.0
        'Dim SuMD As Double = 0.0
        'For i = 0 To DataGridView1.Rows.Count - 1
        '    SuMt = SuMt + DataGridView1.CurrentRow.Cells(6).Value
        '    SuMD = SuMD + DataGridView1.CurrentRow.Cells(5).Value
        'Next
        ''===============================================
        'TotalVoucher.Text = Format(SuMt, "0.000")
        'TotalDiscount.Text = Format(SuMD, "0.000")
        Calc_SalesTax()

    End Sub
    Private Sub DataGridView1_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

    End Sub

    Private Sub TotalVoucher_TextChanged(sender As System.Object, e As System.EventArgs) Handles TotalVoucher.TextChanged



        If Me.TotalVoucher.Text = "" Then Exit Sub
        Me.TotalByArabic.Text = IsLaM(Val(Me.TotalVoucher.Text), "Egypt")
      
    End Sub

    Private Sub BtnBarCode_Click(sender As System.Object, e As System.EventArgs) Handles BtnBarCode.Click
        FrmReceiptOfItemsBarCode.ShowDialog()

    End Sub
    

    Private Sub SalesTax_TextChanged(sender As System.Object, e As System.EventArgs) Handles SalesTax.TextChanged
        If Val(SalesTax.Text) > 0 Then Calc_SalesTax()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = -1 Or DataGridView1.Rows.Count = 0 Then Exit Sub
        Dim ColName = CType(sender, DataGridView).Columns(e.ColumnIndex).Name

        '=============================================
        If ColName = "ColumnUndo" Then
            If DataGridView1.Rows.Count = 0 Then Exit Sub
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            Calc_SalesTax()
            'TotalVoucher.Text = 0
            'Calc_SalesTax()
            'TotalDiscount.Text = 0
            'Dim t = 0
            'For i = 0 To DataGridView1.Rows.Count - 1
            '    t = (t) + (DataGridView1.Rows(i).Cells(5).Value)
            'Next
            'TotalDiscount.Text = Format((t), "0.000")
            'If DataGridView1.Rows.Count = 0 Then
            '    BtnSave.Enabled = False
            '    Button1.Enabled = True

            'End If

        End If

        If ColName = "Column3" Then
            Dim dgvcc As DataGridViewComboBoxCell
            dgvcc = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(1)
            Dim y = dgvcc.ValueMember
        End If

        'Calc_SalesTax()

    End Sub

    Private Sub DataGridView1_CellLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        Calc_SalesTax()
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        If SupplierName.SelectedIndex < 0 Then
            MsgBox("أدخل اسم المورد", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(Label8, "يجب إختيار المورد من القائمة")
            SupplierName.Focus()
            Exit Sub
        End If

        If SupplierInvoicetype.SelectedIndex < 0 Then
            MsgBox("أدخل نوع الفاتورة", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(Label5, "يجب تحديد نوع فاتورة المورد من القائمة")
            SupplierInvoicetype.Focus()
            Exit Sub
        End If

        If Format(SupplierInvoiceDate.Value, "yyy/mm/dd") > Format(DateValue(VoucherDate.Text), "yyyy/mm/dd") Then
            MsgBox("تاريخ سند استلام المواد اكبر من تاريخ فاتورة المورد", MsgBoxStyle.Exclamation, "خطأ")
            Exit Sub
        End If

        For k = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(k).Cells(1).Value = Nothing Then
                DataGridView1.Rows.Remove(DataGridView1.Rows(k))
            End If

        Next

        For k = 0 To DataGridView1.Rows.Count - 1
            If Val(DataGridView1.Rows(k).Cells(4).Value) = 0 Then
                MsgBox("يرجى التاكد من من كميات الاصناف المستلمة", MsgBoxStyle.Exclamation, "تنبيه")
            End If

        Next

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("يجب إدخال صنف واحد على الاقل لاتمام عملية الحفظ", MsgBoxStyle.Critical, "تعليمات")
            Exit Sub
        End If
        If MsgBox("سوف يتم تعديل بيانات سند التوريد الحالى , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

        Try
            Dim str = "select * from ReceiptOfItems where VoucherCode=N'" & VoucherCode.Text & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox("لم يتم العثور على السند يرجى التاكد من رقم السند", MsgBoxStyle.Exclamation, "رسالة تنبيه")

            Else

                Dim dr = dt.Rows(0)
                dr!VoucherCode = VoucherCode.Text
                dr!VoucherDate = VoucherDate.Value
                dr!SalesTax = Val(SalesTax.Text)
                dr!SupplierCode = SupplierCode.Text
                dr!Note = Note.Text
                dr!OrderCode = OrderCode.Text
                dr!SupplierName = SupplierName.Text

                dr!SupplierInvoicetype = SupplierInvoicetype.Text
                dr!SupplierInvoiceCode = SupplierInvoiceCode.Text
                dr!SupplierInvoiceDate = SupplierInvoiceDate.Value

                dr!TotalDiscount = Val(TotalDiscount.Text)
                dr!TotalVoucher = Val(SupplierInvoiceCode.Text)
                dr!TotalByArabic = TotalByArabic.Text



                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)

            End If


            adp.Dispose()
            ds.Dispose()
            dt.Dispose()


            '========================================== حذف تفاصيل السند السابقة


            Dim cmdd As New SqlClient.SqlCommand
            cmdd.Connection = SQLconn
            cmdd.CommandText = "delete  from ReceiptOfItemsDetails where VoucherCode=N'" & VoucherCode.Text & "'"
            cmdd.ExecuteNonQuery()


            '=========================================حفظ تفاصيل سند التوريد


            adp = New SqlClient.SqlDataAdapter("select * from ReceiptOfItemsDetails", SQLconn)
            ds = New DataSet
            adp.Fill(ds)
            dt = ds.Tables(0)
            For i = 0 To DataGridView1.Rows.Count - 1

                Dim dr = dt.NewRow

                dr!VoucherCode = VoucherCode.Text
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
            BtnSave.Enabled = True
            BtnEdit.Enabled = False
            BtnDelete.Enabled = False
            BtnNew_Click(Nothing, Nothing)
            MsgBox("تم تعديل بيانات سند التوريد ف قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            'End Try
            MsgBox("فشل فى عملية التعديل ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        End Try

    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If MsgBox("سوف يتم حذف سجل هذا السند , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

        Try
            Dim str = "select * from ReceiptOfItems where VoucherCode=N'" & VoucherCode.Text.Trim & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox(" لم يتم العثور على بيانات السجل ", MsgBoxStyle.Exclamation, "رسالة تنبيه")
            Else
                Dim dr = dt.Rows(0)
                'dr.Delete()
                dr!status = False
                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
                BtnNew_Click(Nothing, Nothing)
                MsgBox("تم حذف سجل هذا السند وحفظة ف الارشيف  بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
        'Catch
        '    MsgBox("فشل فى عملية الحذف ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        'End Try
    End Sub

    Private Sub BtnSearch_Click(sender As System.Object, e As System.EventArgs) Handles BtnSearch.Click
        PuFillDataGridView(DataGridView2, " select * from ReceiptOfItems where status='true' order by VoucherCode")
        TextBox1.Text = ""
        D1.Value = Now.Date
        D2.Value = Now.Date
        Panel1.Visible = False
        ComboBox1.SelectedIndex = -1
        GroupBox5.Visible = True
        GroupBox1.Visible = False
        GroupBox5.BringToFront()
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim sql As String = ""

        If TextBox1.Text.Length = 0 Then
            sql = "select * from ReceiptOfItems where (status=1) order by VoucherCode"
        Else
            Select Case ComboBox1.SelectedIndex
                Case 0
                    sql = "select * from ReceiptOfItems order by VoucherCode "
                    'البحث حسب رمز العميل
                Case 1
                    sql = "select * from ReceiptOfItems where (status=1) and VoucherCode like N'" & TextBox1.Text.Trim & "%" & "'" & " order by VoucherCode "
                    'البحث حسب اسم العميل
                Case 2
                    sql = "select * from ReceiptOfItems where (status=1) and SupplierName like N'" & TextBox1.Text.Trim & "%" & "'" & " order by SupplierName "
                    'البحث حسب رقم الهاتف


            End Select
            If Trim(sql) <> "" Then PuFillDataGridView(DataGridView2, sql)

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex < 3 Then
            Panel1.Visible = False
        Else
            Panel1.Visible = True
        End If
    End Sub


    Private Sub DataGridView2_Click(sender As System.Object, e As System.EventArgs) Handles DataGridView2.Click
        If DataGridView2.Rows.Count = Nothing Then Exit Sub
        ShowRecordData(DataGridView2.CurrentRow.Cells(1).Value)
        GroupBox5.Visible = False
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

    Private Sub SearchExit_Click(sender As System.Object, e As System.EventArgs) Handles SearchExit.Click
        BtnNew_Click(Nothing, Nothing)
        GroupBox5.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs)
        PuFillDataGridView(DataGridView2, " select * from ReceiptOfItems order by VoucherCode")

    End Sub

    Private Sub DataGridView1_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        For I = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(I).Cells(7).Value = "ــ"
        Next
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        PuFillDataGridView(DataGridView2, " select * from ReceiptOfItems where (status=1) and VoucherDate>='" & Format(D1.Value, "yyy/MM/dd") & "' and VoucherDate<='" & Format(D2.Value, "yyyy/MM/dd") & "' order by VoucherDate ")

    End Sub

    Private Sub BtnExit_Click(sender As System.Object, e As System.EventArgs) Handles BtnExit.Click
        Me.Dispose()

    End Sub

    Private Sub SupplierCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles SupplierCode.TextChanged

    End Sub

    Private Sub SupplierName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles SupplierName.SelectedIndexChanged
        FillSuppliercode()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        GroupBox1.Visible = True
        GroupBox5.Visible = False
        GroupBox1.BringToFront()
    End Sub
End Class