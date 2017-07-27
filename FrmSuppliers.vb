Imports System.IO
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Public Class FrmSuppliers
    Sub FillCOUNTRIES(SQL As String)
        Country.Items.Clear()


        Dim Adp = New SqlClient.SqlDataAdapter(SQL, SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        '--------------------------======================
        For I = 0 To dt.Rows.Count - 1
            Country.Items.Add(dt.Rows(I).Item("C_Name"))

        Next


    End Sub

    Private Sub Browers_Click(sender As System.Object, e As System.EventArgs) Handles Browers.Click
        frmCountries.Show()

    End Sub

    Private Sub Country_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Country.SelectedIndexChanged
        If Country.Items.Count = 0 Then Exit Sub

        City.Items.Clear()
        'Dim x = Country.SelectedValue
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Cities where C_name='" & Country.Text & "' order by CT_name", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        '--------------------------======================
        For I = 0 To dt.Rows.Count - 1
            City.Items.Add(dt.Rows(I).Item("CT_Name"))

        Next
    End Sub

    Private Sub Country_DropDown(sender As System.Object, e As System.EventArgs) Handles Country.DropDown
        FillCOUNTRIES("select * from COUNTRIES order by C_NAME")
    End Sub

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        OpenFileDialog1.FileName = ""
        On Error Resume Next
        For i = 0 To GroupBox2.Controls.Count
            If TypeOf GroupBox2.Controls(i) Is TextBox Then GroupBox2.Controls(i).Text = ""
            If TypeOf GroupBox2.Controls(i) Is ComboBox Then GroupBox2.Controls(i).Text = ""

        Next
        For i = 0 To GroupBox3.Controls.Count
            If TypeOf GroupBox3.Controls(i) Is TextBox Then GroupBox3.Controls(i).Text = ""

        Next
        'debit.ReadOnly = False
        'credit.ReadOnly = False
        Country.Text = ""
        Sup_image.Image = Nothing
        SupplierCode.Text = Format(GET_LAST_RECORD("Suppliers", "SuPInternal_ID") + 1, "SUPP000000")
        BtnSave.Enabled = True
        BtnEdit.Enabled = False
        BtnDelete.Enabled = False
        SupplierName.Focus()
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        If Trim(SupplierName.Text) = "" Then
            ErrorProvider1.SetError(SupplierName, "يرجى إدخال اسم المورد")
            MsgBox("يرجى إدخال اسم العميل ", MsgBoxStyle.Exclamation, "رسالة تنبيه")
            Label2.ForeColor = Color.Red

            Exit Sub
        End If
        '---============================================================================

        Try
            Dim sql = "select * from Suppliers where SupplierName=N'" & (SupplierName.Text) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                MsgBox("إسم العميل موجود مسبقا", MsgBoxStyle.Exclamation, "رسالة تنبيه")


            Else
                Dim dr = dt.NewRow
                dr!SupplierCode = SupplierCode.Text
                dr!SupplierName = SupplierName.Text
                dr!Address = Address.Text
                dr!City = City.Text
                dr!Country = Country.Text
                dr!Phone = Phone.Text
                dr!Company_Name = Company_Name.Text
                dr!facebook = facebook.Text
                dr!WebSite = WebSite.Text
                dr!Fax = Fax.Text
                dr!Email2 = Email2.Text
                dr!Email = Email.Text
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
                    Sup_image.Image.Save(stream, ImageFormat.Jpeg)
                    imgByteArrat = stream.ToArray()
                    stream.Close()
                    dr!Sup_image = imgByteArrat
                End If

                '==============================================

                dt.Rows.Add(dr)
                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
                BtnNew_Click(Nothing, Nothing)
                MsgBox("تم حفظ بيانات المورد فى قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
    End Sub

    Private Sub SupplierName_TextChanged(sender As System.Object, e As System.EventArgs) Handles SupplierName.TextChanged
        ErrorProvider1.SetError(SupplierName, "")
        Label2.ForeColor = Color.Black
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        If Trim(SupplierName.Text) = "" Then
            ErrorProvider1.SetError(SupplierName, "يرجى إدخال اسم العميل")
            MsgBox("يرجى إدخال اسم العميل ", MsgBoxStyle.Exclamation, "رسالة تنبيه")
            Label2.ForeColor = Color.Red

            Exit Sub
        End If
        '---============================================================================
        If MsgBox("سوف يتم حفظ هذة التعديلات , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

        Try
            Dim sql = "select * from Suppliers where SupplierCode=N'" & (SupplierCode.Text) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox(" لم يتم العثور على سجل عميل تحت هذا الرقم يرجى التاكد من الرقم ", MsgBoxStyle.Exclamation, "رسالة تنبيه")


            Else
                Dim dr = dt.Rows(0)
                dr!SupplierCode = SupplierCode.Text
                dr!SupplierName = SupplierName.Text
                dr!Address = Address.Text
                dr!City = City.Text
                dr!Country = Country.Text
                dr!Phone = Phone.Text
                dr!Company_Name = Company_Name.Text
                dr!facebook = facebook.Text
                dr!WebSite = WebSite.Text
                dr!Fax = Fax.Text
                dr!Email2 = Email2.Text
                dr!Email = Email.Text
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
                    Sup_image.Image.Save(stream, ImageFormat.Jpeg)
                    imgByteArrat = stream.ToArray()
                    stream.Close()
                    dr!Sup_image = imgByteArrat
                End If

                '==============================================


                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
                BtnNew_Click(Nothing, Nothing)
                MsgBox("تم تعديل بيانات المورد فى قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
    End Sub

    Private Sub Sup_image_Click(sender As System.Object, e As System.EventArgs) Handles Sup_image.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Jpeg|*.Jpg|Bitmap|*.Bmp|Gif|*.gif|Png|*.png"
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        'Label15.Visible = False
        Sup_image.Image = Image.FromFile(OpenFileDialog1.FileName)
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If MsgBox("سوف يتم حذف سجل هذا المورد وحفظه فى الارشيف , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

        Try
            Dim cmdd As New SqlClient.SqlCommand
            cmdd.Connection = SQLconn
            cmdd.CommandText = "UPDATE Suppliers set status='False' where SupplierCode=N'" & SupplierCode.Text & "'"
            cmdd.ExecuteNonQuery()


            'Dim sql = "select * from Customers where SupplierCode=N'" & (SupplierCode.Text.Trim) & "'"
            'Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
            'Dim ds As New DataSet
            'adp.Fill(ds)
            'Dim dt = ds.Tables(0)
            'If dt.Rows.Count = 0 Then
            '    MsgBox(" لم يتم العثور على سجل عميل تحت هذا الرقم يرجى التاكد من الرقم ", MsgBoxStyle.Exclamation, "رسالة تنبيه")


            'Else
            '    Dim dr = dt.Rows(0)

            '    dr!status = False

            '    Dim cmd As New SqlClient.SqlCommandBuilder(adp)
            '    adp.Update(dt)
            BtnNew_Click(Nothing, Nothing)
            MsgBox("تم ترحيل بيانات المورد الى الارشيف فى قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
    End Sub

    Private Sub FrmSuppliers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        ComboBox1.SelectedIndex = -1
        TextBox1_TextChanged(Nothing, Nothing)
        BtnNew_Click(Nothing, Nothing)
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim sql As String = ""
        If TextBox1.Text.Length = 0 Then
            sql = "select * from Suppliers order by SupplierName"
        Else
            Select Case ComboBox1.SelectedIndex
                'البحث حسب رمز المورد
                Case 0
                    sql = "select * from Suppliers where SupplierCode like N'" & TextBox1.Text.Trim & "%" & "'" & " order by SupplierCode "
                    'البحث حسب اسم المورد
                Case 1
                    sql = "select * from Suppliers where SupplierName like N'" & TextBox1.Text.Trim & "%" & "'" & " order by SupplierName "
                    'البحث حسب رقم الهاتف
                Case 2
                    sql = "select * from Suppliers where Phone like N'" & TextBox1.Text.Trim & "%" & "'" & " order by Phone "

            End Select
        
        End If

        If Trim(sql) <> "" Then PuFillDataGridView(DataGridView2, sql)
        '========================================
    End Sub
    Sub show_record_data(x)
        OpenFileDialog1.FileName = ""
        BtnNew_Click(Nothing, Nothing)
        Dim sql = "select * from Suppliers where SupplierCode=N'" & (x) & "'"
        Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            MsgBox("لم يتم العثور على بيانات السجل", MsgBoxStyle.Exclamation, "رسالة تنبيه")
        Else
            Dim dr = dt.Rows(0)
            On Error Resume Next
            SupplierCode.Text = dr!SupplierCode
            SupplierName.Text = dr!SupplierName
            Address.Text = dr!Address
            City.Text = dr!City
            Country.Text = dr!Country
            Phone.Text = dr!Phone
            Company_Name.Text = dr!Company_Name
            facebook.Text = dr!facebook
            WebSite.Text = dr!WebSite
            Fax.Text = dr!Fax
            Email2.Text = dr!Email2
            Email.Text = dr!Email
            twitter.Text = dr!twitter
            Note.Text = dr!Note
            debit.Text = dr!debit
            credit.Text = dr!credit
            balance.Text = dr!balance


            '===============================================
            'Dim s = Split(Get_balanceTrans("Supplier_Trans", "suppliercode", Val(SupplierCode.text)), ";")
            'debit.Text = Format(Val(s(0)), "0.000")
            'credit.Text = Format(Val(s(0)), "0.000")
            'balance.Text = Format(Val(s(0)), "0.000")
            'status.Text = Format(Val(s(0)), "0.000")

            '================ كود فك تشفير الصورة======================
            If IsDBNull(dr!Cust_image) = False Then
                Dim imgByteArray() As Byte
                imgByteArray = CType(dr!sup_image, Byte())
                Dim stream As New MemoryStream(imgByteArray)
                Dim bmp As New Bitmap(Stream)
                sup_image.Image = Image.FromStream(stream)
                Stream.Close()
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
            SupplierName.Focus()

        End If

    End Sub
    Private Sub DataGridView2_Click(sender As System.Object, e As System.EventArgs) Handles DataGridView2.Click
        If DataGridView2.Rows.Count = Nothing Then Exit Sub

        show_record_data(DataGridView2.CurrentRow.Cells(1).Value)
        GroupBoxSearch.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()

    End Sub

    Private Sub DataGridView2_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView2.RowsAdded
        For I = 0 To DataGridView2.Rows.Count - 1
            DataGridView2.Rows(I).Cells(0).Value = "عرض التفاصيل"
            Dim row As DataGridViewRow = DataGridView2.Rows(I)
            row.Height = 23

        Next
    End Sub

    Private Sub BtnSearch_Click(sender As System.Object, e As System.EventArgs) Handles BtnSearch.Click
        TextBox1_TextChanged(Nothing, Nothing)
        GroupBoxSearch.Visible = True
        GroupBox1.Visible = False
        GroupBoxSearch.BringToFront()
    End Sub

    Private Sub SearchExit_Click(sender As System.Object, e As System.EventArgs) Handles SearchExit.Click
        GroupBoxSearch.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()


    End Sub

    Private Sub BtnExit_Click(sender As System.Object, e As System.EventArgs) Handles BtnExit.Click
        Close()

    End Sub
End Class