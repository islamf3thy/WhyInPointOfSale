Public Class FrmPOS
    Sub fillitemcombo(Str)
        CmbItems.Items.Clear()
        CmbItems.Text = ""
        Dim adp As New SqlClient.SqlDataAdapter(Str, SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                On Error Resume Next
                CmbItems.Items.Add(dt.Rows(i).Item("itemName"))
                CmbItems.Items.Add(dt.Rows(i).Item("itemInternal_ID"))
                CmbItems.Items.Add(dt.Rows(i).Item("itemCode"))
            Next
        End If
    End Sub
    Function GetFiledName(filedname) As Boolean
        GetFiledName = False
        Try
            Dim str = "select * from Items where " & filedname & "=N'" & TxtBarCode.Text.Trim & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then GetFiledName = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى اتمام قرأة الباركود", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Function

    Function GetFiledNam(filedname) As Boolean
        GetFiledNam = False
        Try
            Dim str = "select * from Items where " & filedname & "=N'" & itemCode.Text.Trim & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then GetFiledNam = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى اتمام قرأة الباركود", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Function
    

    


    Sub readbarcod()

        Dim sql = ""
        Dim barc As Integer = 0
        Dim unitlevel As Integer = 0
        'Dim VerifyQtyForItems = 0


        If GetFiledName("FirstUnitBarcode") = True Then
            sql = "select * from Items where FirstUnitBarcode=N'" & TxtBarCode.Text.Trim & "'"
            barc = 1

        ElseIf GetFiledName("SecoundtUnitBarcode") = True Then
            sql = "select * from Items where SecoundtUnitBarcode=N'" & TxtBarCode.Text.Trim & "'"
            barc = 2

        ElseIf GetFiledName("ThirdtUnitBarcode") = True Then
            sql = "select * from Items where ThirdtUnitBarcode=N'" & TxtBarCode.Text.Trim & "'"
            barc = 3

        Else

            GoTo EOS
        End If
        '===================================================================

        '===================================================================
        Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            DataGridView1.Rows.Add()
            Dim dr = dt.Rows(0)
            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0).Value = dr!itemName
            If barc = 1 Then DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(1).Value = dr!FirstUnit
            If barc = 2 Then DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(1).Value = dr!SecoundtUnit
            If barc = 3 Then DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(1).Value = dr!ThirdUnit
            
            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(2).Value = 1
            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(3).Value = Format(GetDEf_Def_Price(dr!itemCode, barc), "0.000")
            Dim Price_ = Val(DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(3).Value)
            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(4).Value = (Format(Price_, "0.000"))
            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(5).Value = "_"
            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(6).Value = dr!itemCode
            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(7).Value = TxtBarCode.Text.Trim
         

            itemCode.Text = GetItemsCODe(DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0).Value)

            '============================
            '=============================================================================

           
            'GetItemsUnit.Text = GetDEf_DefUnit(dr!itemCode, dr!UnitDefault)



            '=====================================
            DataGridView1.ClearSelection()
            'DataGridView1.Rows.Add()
            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Selected = True
            CalcTotal()

            'TxtBarCode.Text = ""
        End If


EOS:
    End Sub

    Sub CalcTotal()
        Dim x As Integer = 0
        Dim y As Integer = 0
        For i = 0 To DataGridView1.Rows.Count - 1
            x = x + Val(DataGridView1.Rows(i).Cells(4).Value)
        Next
        POSTotalInvoice.Text = Format(x, "0.000")
        x = 0.0
        x = (Val(POSADDPayment.Text) + Val(POSTotalInvoice.Text))
        x = x - Val(POSTotalDiscount.Text)
        POSPaidPayment.Text = Format(x, "0.000")

        POSRemainInvoice.Text = "0.000"

        If POSRemainInvoice.Text = "0.000" Then POSRemainInvoiceArabic.Text = "لايوجد مبلغ متبقى "
        If Val(POSTotalInvoice.Text) > 0 Then
            Me.POSPaidPaymenArabic.Text = IsLaM(Val(Me.POSPaidPayment.Text), "Egypt")
        Else
            Me.POSPaidPaymenArabic.Text = ""
        End If

        If Val(POSRemainInvoice.Text) > 0 Then
            Me.POSRemainInvoiceArabic.Text = IsLaM(Val(Me.POSRemainInvoice.Text), "Egypt")
        Else
            Me.POSRemainInvoice.Text = ""
        End If
    End Sub

    Function GetItemsUnitDefault(itemCode) As String
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Items where itemCode=N'" & itemCode & "' ", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt As New DataTable
        dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then Return dt.Rows(0).Item("UnitDefault") Else Return ""
    End Function

    Function GetItemsCODe(ItemsName) As String
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Items where itemName=N'" & ItemsName & "' ", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt As New DataTable
        dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then Return dt.Rows(0).Item("itemCode") Else Return ""
    End Function
    Function GetItemsCOD(ItemsBarCode, unitlevel, GetUnitCounter) As String
       
        Dim Adp = New SqlClient.SqlDataAdapter("select MaxLimitForFirstUnite, MaxLimitForSecoundUnite, MaxLimitForThirdUnite from Items  where UnitDefault=N'" & ItemsBarCode & "' ", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt As New DataTable
        dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then

            Return dt.Rows(0).Item("UnitDefault")
            If unitlevel = 1 Then GetUnitCounter = dt.Rows(0).Item("MaxLimitForFirstUnite")
            If unitlevel = 2 Then GetUnitCounter = dt.Rows(0).Item("MaxLimitForSecoundUnite")
            If unitlevel = 3 Then GetUnitCounter = dt.Rows(0).Item("MaxLimitForThirdUnite")

        Else : Return ""
        End If
    End Function
    Sub ShowRecordData(POSInvoice As String)

        Dim sql = "select * from POSInvoices where POSInvoiceCode=N'" & (POSInvoice) & "'"
        Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            MsgBox("لم يتم العثور على الفاتورة يرجى التحقق من الرقم وإعادة المحاولة", MsgBoxStyle.Exclamation, "رسالة تنبيه")
        Else
            Dim dr = dt.Rows(0)
            On Error Resume Next
            '============================ البيانات الاساسية ========================
            POSInvoiceCode.Text = dr!POSInvoiceCode
            POSInvoiceDate.Value = dr!POSInvoiceDate
            POSInvoicetype.Text = dr!POSInvoicetype
            POSTotalDiscount.Text = Convert.ToDecimal(dr!POSTotalDiscount)
            POSADDPayment.Text = Convert.ToDecimal(dr!POSADDPayment)
            POSTotalInvoice.Text = Convert.ToDecimal(dr!POSTotalInvoice)
            POSPaidPayment.Text = Convert.ToDecimal(dr!POSPaidPayment)
            POSRemainInvoice.Text = Convert.ToDecimal(dr!POSTotalInvoice) - Convert.ToDecimal(dr!POSPaidPayment)

            POSPaidPaymenArabic.Text = dr!POSPaidPaymenArabic
            POSRemainInvoiceArabic.Text = dr!POSRemainInvoiceArabic

            adp.Dispose()
            ds.Dispose()
            dt.Dispose()
            '=========================================عرض تفاصيل سند التوريد
            adp = New SqlClient.SqlDataAdapter("select * from POSInvoicesDetails where POSInvoiceCode=N'" & (POSInvoice) & "'", SQLconn)
            ds = New DataSet
            adp.Fill(ds)
            dt = ds.Tables(0)
            For i = 0 To dt.Rows.Count - 1
                DataGridView1.Rows.Add()
                DataGridView1.Rows(i).Cells(6).Value = dt.Rows(i).Item("ItemCode")
                DataGridView1.Rows(i).Cells(0).Value = dt.Rows(i).Item("ItemName")
                DataGridView1.Rows(i).Cells(1).Value = dt.Rows(i).Item("Unit")
                DataGridView1.Rows(i).Cells(3).Value = dt.Rows(i).Item("UnitPrice")
                DataGridView1.Rows(i).Cells(2).Value = dt.Rows(i).Item("Quantity")
                'DataGridView1.Rows(i).Cells(5).Value = Convert.ToDecimal(dt.Rows(i).Item("Discount"))
                DataGridView1.Rows(i).Cells(4).Value = dt.Rows(i).Item("TotalPrice")


            Next
            BtnSave.Enabled = False
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True

        End If
    End Sub
    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        On Error Resume Next
        For i = 0 To GroupBox1.Controls.Count
            If TypeOf GroupBox1.Controls(i) Is TextBox Then GroupBox1.Controls(i).Text = ""
        Next

        For i = 0 To GroupBox3.Controls.Count
            If TypeOf GroupBox3.Controls(i) Is TextBox Then GroupBox3.Controls(i).Text = ""
        Next
        For i = 0 To GroupBox5.Controls.Count
            If TypeOf GroupBox5.Controls(i) Is TextBox Then GroupBox5.Controls(i).Text = ""
        Next
        'POSRemainInvoice.Text = "0.000"
        '=================================================
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        CalcTotal()
        BtnSave.Enabled = True
        BtnEdit.Enabled = False
        BtnDelete.Enabled = False
        '=================================================
        POSInvoiceDate.Value = Now.Date

        POSInvoiceCode.Text = Format(GET_LAST_RECORD("POSInvoices", "POSInvoiceID") + 1, "POSI000000")

        itemCode.Text = ""
        TxtBarCode.Text = ""

        'If POSRemainInvoice.Text = "0.000" Then POSRemainInvoiceArabic.Text = "لايوجد مبلغ متبقى "


        'If itemCode.Text = "" Then itemCode.Text = POSInvoiceCode.Text


        FillComboList(CmbItems, "Items", "itemName", True)

        'fillitemcombo("select * from Items order by itemName")
        POSInvoicetype.Text = "زبون عام"

    End Sub

    Private Sub FrmPOS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BtnNew_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        If Convert.ToDecimal(POSTotalInvoice.Text) <= 0 Then
            MsgBox("يجب إدخال اصناف للفاتورة لاتمام عملية الحفظ", MsgBoxStyle.Exclamation, "تنبيه")
            Exit Sub
        End If

        If POSTotalDiscount.Text = "" Then POSTotalDiscount.Text = 0.0
        If POSADDPayment.Text = "" Then POSADDPayment.Text = 0.0
        If POSRemainInvoiceArabic.Text = "" Then POSRemainInvoiceArabic.Text = "لايوجد متبقى لهذة الفاتورة"
        Dim i As Integer = 0
        'Dim IDM As Integer = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(6).Value
        '=================================================
        Try

            Dim adp As New SqlClient.SqlDataAdapter("select * from POSInvoices where POSInvoiceCode=N'" & POSInvoiceCode.Text & "'", SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                POSInvoiceCode.Text = Format(GET_LAST_RECORD("POSInvoices", "POSInvoiceID") + 1, "POSI000000")
            Else

                Dim dr = dt.NewRow

                dr!POSInvoiceCode = POSInvoiceCode.Text
                dr!POSInvoiceDate = POSInvoiceDate.Value
                dr!POSInvoicetype = POSInvoicetype.Text
                dr!POSTotalDiscount = Convert.ToDecimal(POSTotalDiscount.Text)
                dr!POSADDPayment = Convert.ToDecimal(POSADDPayment.Text)
                dr!POSTotalInvoice = Convert.ToDecimal(POSTotalInvoice.Text)
                dr!POSPaidPayment = Convert.ToDecimal(POSPaidPayment.Text)
                dr!POSPaidPaymenArabic = POSPaidPaymenArabic.Text
                dr!POSRemainInvoice = Convert.ToDecimal(POSRemainInvoice.Text)
                dr!POSRemainInvoiceArabic = POSRemainInvoiceArabic.Text
                dr!status = True
                dt.Rows.Add(dr)
                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
            End If
            '=============================================================
           Dim cmdd As New SqlClient.SqlCommand
            cmdd.Connection = SQLconn
            cmdd.CommandText = "Update Items SET itemQuantity = 'itemQuantity - " & DataGridView1.Rows(i).Cells(2).Value & "' WHERE itemName=N '" & DataGridView1.Rows(i).Cells(0).Value & "'"
            cmdd.ExecuteNonQuery()

            '=========================================حفظ تفاصيل سند التوريد
            adp = New SqlClient.SqlDataAdapter("select * from POSInvoicesDetails", SQLconn)
            ds = New DataSet
            adp.Fill(ds)
            dt = ds.Tables(0)
            For i = 0 To DataGridView1.Rows.Count - 1
                Dim dr = dt.NewRow
                dr!POSInvoiceCode = POSInvoiceCode.Text
                dr!ItemCode = DataGridView1.Rows(i).Cells(6).Value
                dr!ItemName = DataGridView1.Rows(i).Cells(0).Value
                dr!Unit = DataGridView1.Rows(i).Cells(1).Value
                dr!UnitPrice = DataGridView1.Rows(i).Cells(3).Value
                dr!Quantity = DataGridView1.Rows(i).Cells(2).Value
                dr!TotalPrice = DataGridView1.Rows(i).Cells(4).Value

                dt.Rows.Add(dr)
                Dim cmd_Builder1 As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)

            Next

            'Dim cmdd As New SqlClient.SqlCommand
            'cmdd.Connection = SQLconn
            'cmdd.CommandText = "update  from POSInvoicesDetails where POSInvoiceCode=N'" & itemName.Text & "'"
            'cmdd.ExecuteNonQuery()
            
            ''Dim cmdd As New SqlClient.SqlCommand
            'cmdd.Connection = SQLconn
            'cmdd.CommandText = "Update Items SET itemQuantity = itemQuantity - '" & DataGridView1.Rows(i).Cells(2).Value & "' WHERE itemCode=N " & DataGridView1.Rows(i).Cells(0).Value & ""
            'cmdd.ExecuteNonQuery()

            BtnNew_Click(sender, e)
            MsgBox("تم حفظ بيانات الفاتورة ف قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            'End Try
            'MsgBox("فشل فى عملية الحفظ ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        End Try

    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        If Convert.ToDecimal(POSTotalInvoice.Text) <= 0 Then
            MsgBox("يجب إدخال اصناف للفاتورة لاتمام عملية التعديل", MsgBoxStyle.Exclamation, "تنبيه")

        End If

        If POSTotalDiscount.Text = "" Then POSTotalDiscount.Text = 0.0
        If POSADDPayment.Text = "" Then POSADDPayment.Text = 0.0
        If POSRemainInvoiceArabic.Text = "" Then POSRemainInvoiceArabic.Text = "لايوجد متبقى لهذة الفاتورة"

        '=================================================
        If MsgBox("سوف يتم تعديل بيانات فاتورة المبيعات الحالية , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

        Try

            Dim adp As New SqlClient.SqlDataAdapter("select * from POSInvoices where POSInvoiceCode=N'" & POSInvoiceCode.Text & "'", SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox("لم يتم العثور على الفاتورة يرجى التاكد من رقم الفاتورة", MsgBoxStyle.Exclamation, "رسالة تنبيه")
            Else

                Dim dr = dt.Rows(0)

                'dr!POSInvoiceCode = POSInvoiceCode.Text
                dr!POSInvoiceDate = POSInvoiceDate.Value
                dr!POSInvoicetype = POSInvoicetype.Text
                dr!POSTotalDiscount = Convert.ToDecimal(POSTotalDiscount.Text)
                dr!POSADDPayment = Convert.ToDecimal(POSADDPayment.Text)
                dr!POSTotalInvoice = Convert.ToDecimal(POSTotalInvoice.Text)
                dr!POSPaidPayment = Convert.ToDecimal(POSPaidPayment.Text)
                dr!POSPaidPaymenArabic = POSPaidPaymenArabic.Text
                dr!POSRemainInvoice = Convert.ToDecimal(POSRemainInvoice.Text)
                dr!POSRemainInvoiceArabic = POSRemainInvoiceArabic.Text
                dr!status = True

                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
            End If
            '=================================================
            adp.Dispose()
            ds.Dispose()
            dt.Dispose()


            '=================================================

            Dim cmdd As New SqlClient.SqlCommand
            cmdd.Connection = SQLconn
            cmdd.CommandText = "delete  from POSInvoicesDetails where POSInvoiceCode=N'" & POSInvoiceCode.Text & "'"
            cmdd.ExecuteNonQuery()
            '=========================================حفظ تفاصيل الفاتورة
            adp = New SqlClient.SqlDataAdapter("select * from POSInvoicesDetails", SQLconn)
            ds = New DataSet
            adp.Fill(ds)
            dt = ds.Tables(0)
            For i = 0 To DataGridView1.Rows.Count - 1
                Dim dr = dt.NewRow
                dr!POSInvoiceCode = POSInvoiceCode.Text
                dr!ItemCode = DataGridView1.Rows(i).Cells(6).Value
                dr!ItemName = DataGridView1.Rows(i).Cells(0).Value
                dr!Unit = DataGridView1.Rows(i).Cells(1).Value
                dr!UnitPrice = DataGridView1.Rows(i).Cells(3).Value
                dr!Quantity = DataGridView1.Rows(i).Cells(2).Value
                'dr!Discount = Convert.ToDecimal(DataGridView1.Rows(i).Cells(5).Value)
                dr!TotalPrice = DataGridView1.Rows(i).Cells(4).Value
                dt.Rows.Add(dr)
                Dim cmd_Builder1 As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)

            Next



            BtnNew_Click(Nothing, Nothing)
            MsgBox("تم تعديل فاتورة المبيعات الفورية فى قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            'End Try
            MsgBox("فشل فى عملية الحفظ ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        End Try

    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If MsgBox("سوف يتم حذف هذة الفاتورة وحفظها ف الارشيف , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

        Try
            Dim str = "select * from POSInvoices where POSInvoiceCode=N'" & POSInvoiceCode.Text & "'"
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
                MsgBox("تم حذف الفاتورة بنجاح وحفظها ف الارشيف  بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
        'Catch
        '    MsgBox("فشل فى عملية الحذف ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        'End Try
    End Sub

    Private Sub BtnExit_Click(sender As System.Object, e As System.EventArgs) Handles BtnExit.Click
        Close()

    End Sub

    Private Sub BtnSearch_Click(sender As System.Object, e As System.EventArgs) Handles BtnSearch.Click
        SearchPOSInvoice.ShowDialog()

    End Sub

    Private Sub POSPaidPayment_TextChanged(sender As System.Object, e As System.EventArgs) Handles POSPaidPayment.TextChanged
        'On Error Resume Next
        'POSRemainInvoice.Text = Format(Convert.ToDecimal(POSTotalInvoice.Text) - Convert.ToDecimal(POSPaidPayment.Text), "0.000")
        If POSRemainInvoice.Text = "" Then POSRemainInvoice.Text = "0.000"

        Me.POSRemainInvoiceArabic.Text = IsLaM(Val(Me.POSRemainInvoice.Text), "Egypt")
        '================================================================================
        If Me.POSPaidPayment.Text = "" Then Exit Sub
        Me.POSPaidPaymenArabic.Text = IsLaM(Val(Me.POSPaidPayment.Text), "Egypt")
    End Sub


    Private Sub POSRemainInvoice_TextChanged(sender As System.Object, e As System.EventArgs) Handles POSRemainInvoice.TextChanged

        If POSRemainInvoice.Text = "" Then POSRemainInvoice.Text = "0.000"

        Me.POSRemainInvoiceArabic.Text = IsLaM(Val(Me.POSRemainInvoice.Text), "Egypt")
    End Sub

    Private Sub CmbItems_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbItems.SelectedIndexChanged
        itemCode.Text = GetItemsCODe(CmbItems.Text)
        If CmbItems.SelectedIndex < 0 Then
            MsgBox("يرجى إختيار اسم الصنف من القائمة بشكل صحيح", MsgBoxStyle.Critical)
            Exit Sub
        End If


        itemName.Text = ""
        itemquantity.Text = ""
        itemprice.Text = ""
        itemUnit.Items.Clear()

        Dim adp As New SqlClient.SqlDataAdapter("select * from Items where itemCode=N'" & itemCode.Text & "'", SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        'itemUnit.Items.Clear()

        If dt.Rows.Count > 0 Then
            itemUnit.Items.Add(dt.Rows(0).Item("FirstUnit"))
            If dt.Rows(0).Item("SecoundtUnit").ToString <> "" Then itemUnit.Items.Add(dt.Rows(0).Item("SecoundtUnit"))
            If dt.Rows(0).Item("ThirdUnit").ToString <> "" Then itemUnit.Items.Add(dt.Rows(0).Item("ThirdUnit"))

            Dim x = Split(GetDEf_Unit_Price(itemCode.Text), "|")
            itemName.Text = CmbItems.Text
            itemprice.Text = Format(x(1))
            itemquantity.Text = 1
            itemUnit.Text = x(0)

        End If


    End Sub

    Private Sub itemUnit_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles itemUnit.SelectedIndexChanged
        Dim str = ""
        Dim unitlevel = 0

        Select Case itemUnit.SelectedIndex
            Case 0
                str = "select * from Items where itemCode=N'" & itemCode.Text & "' and FirstUnit=N'" & itemUnit.Text & "'"
                unitlevel = 1
            Case 1
                str = "select * from Items where itemCode=N'" & itemCode.Text & "' and SecoundtUnit=N'" & itemUnit.Text & "'"
                unitlevel = 2
            Case 2
                str = "select * from Items where itemCode=N'" & itemCode.Text & "' and ThirdUnit=N'" & itemUnit.Text & "'"
                unitlevel = 3
        End Select

        Dim Adp = New SqlClient.SqlDataAdapter(str, SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then
            itemprice.Text = Format(GetDEf_Def_Price(itemCode.Text, unitlevel), "0.000")

        Else
            MsgBox("يرجى مراجعة قائمة الاسعار لهذة الوحدة فى شاشة الاصناف", MsgBoxStyle.Critical)

        End If

        '=============================================================================

        Dim str1 = ""
        Dim unitlevel1 = 0

        Select Case itemUnit.SelectedIndex
            Case 0
                str = "select * from Items where itemCode=N'" & itemCode.Text & "' and MaxLimitForFirstUnite=N'" & itemUnit.Text & "'"
                unitlevel1 = 1
            Case 1
                str = "select * from Items where itemCode=N'" & itemCode.Text & "' and MaxLimitForSecoundUnite=N'" & itemUnit.Text & "'"
                unitlevel1 = 2
            Case 2
                str = "select * from Items where itemCode=N'" & itemCode.Text & "' and MaxLimitForThirdUnite=N'" & itemUnit.Text & "'"
                unitlevel1 = 3
        End Select

        Dim Adp1 = New SqlClient.SqlDataAdapter(str, SQLconn)
        Dim DS1 = New DataSet
        Adp.Fill(DS1)
        Dim dt1 = DS.Tables(0)
        If dt.Rows.Count > 0 Then
            GetItemsUnit.Text = GetDEf_DefUnit(itemCode.Text, unitlevel1)

        
        End If
    End Sub

    Function GetDEf_DefUnit(vlan, unitlevel) As Integer
        GetDEf_DefUnit = 0.0
        Dim str = "select * from Items where itemCode=N'" & vlan & "'"
        Dim Adp As New SqlClient.SqlDataAdapter(str, SQLconn)
        Dim DS As New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        If dt.Rows.Count = 0 Then Exit Function
        Dim dr = dt.Rows(0)
        Dim arrPrice(1) As String

        Select Case unitlevel
            Case 1
                arrPrice(1) = dr!MaxLimitForFirstUnite

            Case 2
                arrPrice(1) = dr!MaxLimitForSecoundUnite

            Case 3
                arrPrice(1) = dr!MaxLimitForThirdUnite


        End Select
        GetDEf_DefUnit = arrPrice(dr!UnitDefault)

    End Function

    Function GetDEf_Def_Price(vlan, unitlevel) As Decimal
        GetDEf_Def_Price = 0.0
        Dim str = "select * from ItemNormalPricess where itemCode=N'" & vlan & "'"
        Dim Adp As New SqlClient.SqlDataAdapter(str, SQLconn)
        Dim DS As New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        If dt.Rows.Count = 0 Then Exit Function
        Dim dr = dt.Rows(0)
        Dim arrPrice(6) As String

        Select Case unitlevel
            Case 1
                arrPrice(1) = dr!WholeSaleForFirstUnit
                arrPrice(2) = dr!HalfWholeSaleForFirstUnit
                arrPrice(3) = dr!DistributorForFirstUnit
                arrPrice(4) = dr!ExportForFirstUnit
                arrPrice(5) = dr!RetailForFirstUnit
                arrPrice(6) = dr!EndUserForFirstUnit
            Case 2
                arrPrice(1) = dr!WholeSaleForSecondUnit
                arrPrice(2) = dr!HalfWholeSaleForSecondUnit
                arrPrice(3) = dr!DistributorForSecondUnit
                arrPrice(4) = dr!ExportForSecondUnit
                arrPrice(5) = dr!RetailForSecondUnit
                arrPrice(6) = dr!EndUserForSecondUnit
            Case 3
                arrPrice(1) = dr!WholeSaleForThirdUnit
                arrPrice(2) = dr!HalfWholeSaleForThirdUnit
                arrPrice(3) = dr!DistributorForThirdUnit
                arrPrice(4) = dr!ExportForThirdUnit
                arrPrice(5) = dr!RetailForThirdUnit
                arrPrice(6) = dr!EndUserForThirdUnit

        End Select
        GetDEf_Def_Price = arrPrice(dr!PriceDefault)

    End Function

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If itemName.Text = String.Empty Then
            MsgBox("يجب اختيار الصنف اولا", MsgBoxStyle.Critical, "تعليمات")
            itemName.Focus()
            Exit Sub
        End If

        If Val(itemquantity.Text) <= 0 Then
            MsgBox("يجب ادخال الكمية اولا", MsgBoxStyle.Critical, "تعليمات")
            itemquantity.Focus()
            Exit Sub
        End If

        If Val(itemprice.Text) <= 0 Then
            MsgBox("يجب ادخال السعر اولا", MsgBoxStyle.Critical, "تعليمات")
            itemprice.Focus()
            Exit Sub
        End If



        Dim x = GetUnitBarcode(itemCode.Text, itemUnit.SelectedIndex + 1)
        'Dim m = GetItemsCOD(itemCode.Text, itemUnit.SelectedIndex + 1, itemName.Text)

        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(6).Value = itemCode.Text And DataGridView1.Rows(i).Cells(7).Value = x Then
                MsgBox("هذا الصنف سبق وتم ادخالة للفاتورة", MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
        Next

       


        DataGridView1.Rows.Add()
        With DataGridView1.Rows(DataGridView1.Rows.Count - 1)
            .Cells(0).Value = itemName.Text
            .Cells(1).Value = itemUnit.Text
            .Cells(2).Value = itemquantity.Text
            .Cells(3).Value = itemprice.Text
            .Cells(4).Value = Convert.ToDecimal(itemprice.Text) * Val(itemquantity.Text)
            .Cells(5).Value = "_"
            .Cells(6).Value = itemCode.Text
            .Cells(7).Value = GetUnitBarcode(itemCode.Text, itemUnit.SelectedIndex + 1)
            .Cells(8).Value = GetItemsUnit.Text
        End With

        '=========================================================================
        DataGridView1.ClearSelection()
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Selected = True
        '=========================================================================
        itemName.Text = ""
        itemCode.Text = ""
        GetItemsUnit.Text = ""
        itemUnit.Items.Clear()
        itemUnit.Text = ""
        itemquantity.Text = ""
        itemprice.Text = ""
        CmbItems.Text = ""
        CmbItems.Focus()
        CalcTotal()

    End Sub

    Private Sub POSTotalDiscount_TextChanged(sender As System.Object, e As System.EventArgs) Handles POSTotalDiscount.TextChanged
        CalcTotal()
    End Sub

    Private Sub POSADDPayment_TextChanged(sender As System.Object, e As System.EventArgs) Handles POSADDPayment.TextChanged
        CalcTotal()
    End Sub

    Private Sub TxtBarCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBarCode.TextChanged
        'itemCode.Text = ""
        'GetItemsUnit.Text = ""
        PicBarCode.BackgroundImage = Code128(TxtBarCode.Text, "A")
        If TxtBarCode.Text = "" Then Exit Sub
        If TxtBarCode.Text.Length = 0 Then
            PicBarCode.Image = Nothing
            PicBarCode.BackgroundImage = Nothing
        Else
            PicBarCode.BackgroundImage = Code128(TxtBarCode.Text, "A")

        End If
    End Sub

    Private Sub TxtBarCode_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBarCode.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            For i = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells(7).Value = TxtBarCode.Text Then

                    DataGridView1.Rows(i).Cells(2).Value += 1
                    DataGridView1.Rows(i).Cells(4).Value = Val(DataGridView1.Rows(i).Cells(2).Value) * Val(DataGridView1.Rows(i).Cells(3).Value)
                    'Dim y = VerifyQtyForItems(DataGridView1.Rows(i).Cells(7).Value, DataGridView1.Rows(i).Cells(1).Value + 1)
                    'DataGridView1.Rows(i).Cells(8).Value = y - Convert.ToInt32(itemquantity.Text)
                    TxtBarCode.Text = ""
                    PicBarCode.BackgroundImage = Nothing
                    TxtBarCode.Focus()
                    CalcTotal()
                    Exit Sub
                End If
            Next
            readbarcod()

            TxtBarCode.Text = ""
            'itemCode.Text = ""
            'GetItemsUnit.Text = ""
            If TxtBarCode.Text = "" Then Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "تفعيل قراءة الباركود -F2" Then
            CheckBox1.Checked = False
            Button1.Text = "تعطيل قراءة الباركود -F2"
        Else
            CheckBox1.Checked = True
            Button1.Text = "تفعيل قراءة الباركود -F2"
            CmbItems.Focus()
        End If
        CheckBox1_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TxtBarCode.Enabled = False
            PicBarCode.Enabled = False
            TxtBarCode.Text = ""
            TxtBarCode.BackColor = Color.LightSlateGray
            PicBarCode.BackColor = Color.LightSlateGray

        Else
            TxtBarCode.Enabled = True
            PicBarCode.Enabled = True
            TxtBarCode.Focus()
            TxtBarCode.BackColor = Color.LightYellow
            PicBarCode.BackColor = Color.White

        End If
        PicBarCode.Image = Nothing
        PicBarCode.BackgroundImage = Nothing
    End Sub

    Private Sub FrmPOS_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then Button1_Click(Nothing, Nothing)
        'If e.KeyCode = Keys.Enter Then Button2_Click(Nothing, Nothing)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = -1 Or DataGridView1.Rows.Count = 0 Then Exit Sub
        Dim ColName = CType(sender, DataGridView).Columns(e.ColumnIndex).Name

        If ColName = "ColumnUndo" Then
            If DataGridView1.Rows.Count = 0 Then Exit Sub
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        End If
        CalcTotal()

    End Sub


End Class