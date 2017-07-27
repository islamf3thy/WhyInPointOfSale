Imports System.IO
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class FrmCustomers

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        On Error Resume Next
        For i = 0 To GroupBox2.Controls.Count
            If TypeOf GroupBox2.Controls(i) Is TextBox Then GroupBox2.Controls(i).Text = ""
        Next
        For i = 0 To GroupBox3.Controls.Count
            If TypeOf GroupBox3.Controls(i) Is TextBox Then GroupBox3.Controls(i).Text = ""
        Next
        OpenFileDialog1.FileName = ""
        balance.Text = ""
        status.Text = ""
        'debit.ReadOnly = False
        'credit.ReadOnly = False
        Cust_image.Image = Nothing
        CustomerCode.Text = Format(GET_LAST_RECORD("Customers", "CusInternal_ID") + 1, "CUST000000")
        BtnSave.Enabled = True
        BtnEdit.Enabled = False
        BtnDelete.Enabled = False
        CustomerName.Focus()
    End Sub

    Private Sub CustomerName_TextChanged(sender As System.Object, e As System.EventArgs) Handles CustomerName.TextChanged
        ErrorProvider1.SetError(CustomerName, "")
        Label2.ForeColor = Color.Black
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        If Trim(CustomerName.Text) = "" Then
            ErrorProvider1.SetError(CustomerName, "يرجى إدخال اسم العميل")
            Label2.ForeColor = Color.Red
            MsgBox("يرجى إدخال اسم العميل ", MsgBoxStyle.Exclamation, "رسالة تنبيه")

            Exit Sub
        End If
        '---============================================================================

        Try
            Dim sql = "select * from Customers where CustomerName=N'" & (CustomerName.Text) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                MsgBox("إسم العميل موجود مسبقا", MsgBoxStyle.Exclamation, "رسالة تنبيه")


            Else

                Dim dr = dt.NewRow
                dr!CustomerCode = CustomerCode.Text
                dr!CustomerName = CustomerName.Text
                dr!Address = Address.Text
                dr!City = City.Text
                dr!Country = Country.Text
                dr!Fax = Fax.Text
                dr!Fax2 = Fax2.Text
                dr!Phone = Phone.Text
                dr!Phone2 = Phone2.Text
                dr!Email = Email.Text
                dr!Email2 = Email2.Text
                dr!facebook = facebook.Text
                dr!twitter = twitter.Text
                dr!Note = Note.Text
                dr!debit = Val(debit.Text)
                dr!credit = Val(credit.Text)
                dr!balance = Val(balance.Text)
                dr!status = True

                '========================= تشفير الصورة========================
                If OpenFileDialog1.FileName <> "" Then
                    Dim imgByteArrat() As Byte
                    Dim stream As New MemoryStream
                    'Dim bmp As New Bitmap(stream)
                    'sup_image.Image.Save(stream, ImageFormat.Jpeg)
                    Cust_image.Image.Save(stream, ImageFormat.Jpeg)
                    imgByteArrat = stream.ToArray()
                    stream.Close()
                    dr!Cust_image = imgByteArrat
                End If

                '==============================================

                dt.Rows.Add(dr)
                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
                'BtnNew_Click(Nothing, Nothing)
                MsgBox("تم حفظ بيانات العميل ف قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
    End Sub

    Private Sub FrmCustomers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PuFillDataGridView(DataGridView2, "select * from Customers order by CustomerName")
        BtnNew_Click(Nothing, Nothing)

    End Sub

    Private Sub Cust_image_Click(sender As System.Object, e As System.EventArgs) Handles Cust_image.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Jpeg|*.Jpg|Bitmap|*.Bmp|Gif|*.gif|Png|*.png"
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        'Label15.Visible = False
        Cust_image.Image = Image.FromFile(OpenFileDialog1.FileName)
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click

        If Trim(CustomerName.Text) = "" Then
            ErrorProvider1.SetError(CustomerName, "يرجى إدخال اسم العميل")
            MsgBox("يرجى إدخال اسم العميل ", MsgBoxStyle.Exclamation, "رسالة تنبيه")
            Label2.ForeColor = Color.Red

            Exit Sub
        End If
        '---============================================================================
        If MsgBox("سوف يتم حفظ هذة التعديلات , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

        Try
            Dim sql = "select * from Customers where CustomerCode=N'" & (CustomerCode.Text) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox(" لم يتم العثور على سجل عميل تحت هذا الرقم يرجى التاكد من الرقم ", MsgBoxStyle.Exclamation, "رسالة تنبيه")


            Else
                Dim dr = dt.Rows(0)
                dr!CustomerCode = CustomerCode.Text
                dr!CustomerName = CustomerName.Text
                dr!Address = Address.Text
                dr!City = City.Text
                dr!Country = Country.Text
                dr!Fax = Fax.Text
                dr!Fax2 = Fax2.Text
                dr!Phone = Phone.Text
                dr!Phone2 = Phone2.Text
                dr!Email = Email.Text
                dr!Email2 = Email2.Text
                dr!facebook = facebook.Text
                dr!twitter = twitter.Text
                dr!Note = Note.Text
                dr!debit = Val(debit.Text)
                dr!credit = Val(credit.Text)
                dr!balance = Val(balance.Text)
                dr!status = True

                '========================= تشفير الصورة========================
                If OpenFileDialog1.FileName <> "" Then
                    Dim imgByteArrat() As Byte
                    Dim stream As New MemoryStream
                    'Dim bmp As New Bitmap(stream)
                    'sup_image.Image.Save(stream, ImageFormat.Jpeg)
                    Cust_image.Image.Save(stream, ImageFormat.Jpeg)
                    imgByteArrat = stream.ToArray()
                    stream.Close()
                    dr!Cust_image = imgByteArrat
                End If

                '==============================================


                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
                BtnNew_Click(Nothing, Nothing)
                MsgBox("تم تعديل بيانات العميل فى قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If MsgBox("سوف يتم حذف سجل هذا العميل وحفظه فى الارشيف , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

        Try
            Dim sql = "select * from Customers where CustomerCode=N'" & (CustomerCode.Text.Trim) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox(" لم يتم العثور على سجل عميل تحت هذا الرقم يرجى التاكد من الرقم ", MsgBoxStyle.Exclamation, "رسالة تنبيه")

            Else
                Dim dr = dt.Rows(0)

                dr!status = False

                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
                BtnNew_Click(Nothing, Nothing)
                MsgBox("تم ترحيل بيانات العميل فى قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
    End Sub

  

    Private Sub BtnSearch_Click(sender As System.Object, e As System.EventArgs) Handles BtnSearch.Click
        PuFillDataGridView(DataGridView2, "select * from Customers order by CustomerName")
        TextBox1_TextChanged(Nothing, Nothing)
        GroupBoxSearch.Visible = True
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBoxSearch.BringToFront()
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim sql As String = ""
        If TextBox1.Text.Length = 0 Then
            sql = "select * from Customers order by CustomerName"
        Else
            Select Case ComboBox1.SelectedIndex
                'البحث حسب رمز العميل
                Case 0
                    sql = "select * from Customers where CustomerCode like N'" & TextBox1.Text.Trim & "%" & "'" & " order by CustomerCode "
                    'البحث حسب اسم العميل
                Case 1
                    sql = "select * from Customers where CustomerName like N'" & TextBox1.Text.Trim & "%" & "'" & " order by CustomerName "
                    'البحث حسب رقم الهاتف
                Case 2
                    sql = "select * from Customers where Mobile like N'" & TextBox1.Text.Trim & "%" & "'" & " order by Mobile "

            End Select
            '======================= طريقة للبحث ================================
            'If CboSearch.SelectedIndex = 0 Then
            '    'sql = "select * from Customers where  CustomerCode='" & TxtSearch.Text.Trim & "'"
            '    sql = "select * from Customers where CustomerCode like N'" & TxtSearch.Text.Trim & "%" & "'" & " order by CustomerCode "
            'ElseIf TxtSearch.Text.Length = 1 Then
            '    sql = "select * from Customers where CustomerName like N'" & TxtSearch.Text.Trim & "%" & "'" & " order by CustomerName "
            'ElseIf TxtSearch.Text.Length = 2 Then
            '    sql = "select * from Customers where Mobile like N'" & TxtSearch.Text.Trim & "%" & "'" & " order by Mobile "

            'End If
            '=======================================================================
        End If

        If Trim(sql) <> "" Then PuFillDataGridView(DataGridView2, sql)
    End Sub
    Sub show_record_data(x)
        OpenFileDialog1.FileName = ""
        BtnNew_Click(Nothing, Nothing)
        Dim sql = "select * from Customers where CustomerCode=N'" & (x) & "'"
        Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            MsgBox("لم يتم العثور على بيانات السجل", MsgBoxStyle.Exclamation, "رسالة تنبيه")
        Else
            Dim dr = dt.Rows(0)
            On Error Resume Next
            CustomerCode.Text = dr!CustomerCode
            CustomerName.Text = dr!CustomerName
            Address.Text = dr!Address
            City.Text = dr!City
            Country.Text = dr!Country
            Fax.Text = dr!Fax
            Fax2.Text = dr!Fax2
            Phone.Text = dr!Phone
            Phone2.Text = dr!Phone2
            Email.Text = dr!Email
            Email2.Text = dr!Email2
            facebook.Text = dr!facebook
            twitter.Text = dr!twitter
            Note.Text = dr!Note
            debit.Text = dr!debit
            credit.Text = dr!credit
            balance.Text = dr!balance

            '--------------------------

            '===============================================
            'Dim s = Split(Get_balanceTrans("Supplier_Trans", "suppliercode", Val(SupplierCode.text)), ";")
            'debit.Text = Format(Val(s(0)), "0.000")
            'credit.Text = Format(Val(s(0)), "0.000")
            'balance.Text = Format(Val(s(0)), "0.000")
            'status.Text = Format(Val(s(0)), "0.000")

            '================ كود فك تشفير الصورة======================
            If IsDBNull(dr!Cust_image) = False Then
                Dim imgByteArray() As Byte
                imgByteArray = CType(dr!Cust_image, Byte())
                Dim stream As New MemoryStream(imgByteArray)
                Dim bmp As New Bitmap(stream)
                Cust_image.Image = Image.FromStream(stream)
                stream.Close()
                Label15.Visible = False
            End If

            '===============================
            'SupplierCode.ReadOnly = True
            'debit.BackColor = Color.White
            'debit.ReadOnly = True

            'credit.BackColor = Color.White
            'credit.ReadOnly = True

            BtnSave.Enabled = False
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True
            CustomerName.Focus()

        End If
    End Sub
    Private Sub DataGridView2_Click(sender As System.Object, e As System.EventArgs) Handles DataGridView2.Click
        If DataGridView2.Rows.Count = Nothing Then Exit Sub
        show_record_data(DataGridView2.CurrentRow.Cells(1).Value)
        GroupBoxSearch.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
        GroupBox2.Visible = True
        GroupBox2.BringToFront()
    End Sub

    Private Sub DataGridView2_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView2.RowsAdded
        For I = 0 To DataGridView2.Rows.Count - 1
            DataGridView2.Rows(I).Cells(0).Value = "عرض التفاصيل"
            Dim row As DataGridViewRow = DataGridView2.Rows(I)
            row.Height = 23

        Next
    End Sub

    Private Sub SearchExit_Click(sender As System.Object, e As System.EventArgs) Handles SearchExit.Click
        GroupBoxSearch.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
        GroupBox2.Visible = True
        GroupBox2.BringToFront()
    End Sub

    Private Sub BtnExit_Click(sender As System.Object, e As System.EventArgs) Handles BtnExit.Click
        Close()

    End Sub
End Class