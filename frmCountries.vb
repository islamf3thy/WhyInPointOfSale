Public Class frmCountries
    Sub FillCOUNTRIES(SQL As String)
        ListBox1.Items.Clear()
        C_NAME.Text = ""
        C_NAME.Focus()

        Dim Adp = New SqlClient.SqlDataAdapter(SQL, SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        '--------------------------======================
        For I = 0 To dt.Rows.Count - 1
            ListBox1.Items.Add(dt.Rows(I).Item("C_Name"))

        Next


    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        If C_NAME.Text.Trim = "" Then
            MsgBox("يجب إدخال اسم الدولة قبل اتمام عملية الاضافة", MsgBoxStyle.Critical, "خطأ")
            C_NAME.Focus()
            Exit Sub
        End If
        '=================================================
        Try
            Dim sql = "select * from COUNTRIES where C_NAME=N'" & (C_NAME.Text) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                MsgBox("إسم الدولة المدخلة موجود مسبقا", MsgBoxStyle.Exclamation, "رسالة تنبيه")

            Else
                Dim DR = dt.NewRow
                DR!C_NAME = C_NAME.Text
                dt.Rows.Add(DR)

            End If


            Dim cmd As New SqlClient.SqlCommandBuilder(adp)
            adp.Update(dt)
            FillCOUNTRIES("select * from COUNTRIES order by C_NAME")
        Catch ex As Exception
            MsgBox("تم حفظ بيانات الدولة ف قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
        End Try
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        If C_NAME.Text.Trim = "" Then
            MsgBox("يجب اختيار الدولة قبل اتمام عملية التعديل ", MsgBoxStyle.Critical, "خطأ")
            C_NAME.Focus()
            Exit Sub
        End If

        '=======================================================================
        Try
            Dim sql = "select * from COUNTRIES where C_NAME=N'" & (ListBox1.Text) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox("إسم الدولة التى تريد تعديلها غير موجود", MsgBoxStyle.Exclamation, "رسالة تنبيه")

            Else
                Dim DR = dt.Rows(0)

                DR!C_NAME = C_NAME.Text

                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
                '================================تعديل اسم الدولة الحالية ف جدول المدن=================================
                Dim cmdd As New SqlClient.SqlCommand
                cmdd.Connection = SQLconn
                cmdd.CommandText = "UPDATE Cities set C_name=N'" & C_NAME.Text & "' where C_name=N '" & ListBox1.Text & "'"
                cmdd.ExecuteNonQuery()
                '================================------=========================================================


                '=================== عرض سجلات الدول ف ليست بوكس =====================

                FillCOUNTRIES("select * from COUNTRIES order by C_NAME")
            End If
        Catch ex As Exception
            MsgBox("تم تعديل بيانات الدولة فى قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")


        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If C_NAME.Text.Trim = "" Then
            MsgBox("يجب اختيار الدولة قبل اتمام عملية الحذف ", MsgBoxStyle.Critical, "خطأ")
            C_NAME.Focus()
            Exit Sub
        End If

        '=======================================================================
        Try
            Dim sql = "select * from COUNTRIES where C_NAME=N'" & (ListBox1.Text) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox("إسم الدولة التى تريد حذفها غير موجود", MsgBoxStyle.Exclamation, "رسالة تنبيه")

            Else
                Dim DR = dt.Rows(0)

                DR.Delete()


                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
                '=================== عرض سجلات الدول ف ليست بوكس =====================

                FillCOUNTRIES("select * from COUNTRIES order by C_NAME")
            End If
                Catch ex As Exception
            MsgBox("تم حذف بيانات الدولة فى قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

        End Try


    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        C_NAME.Text = ListBox1.Text
    End Sub

    Private Sub frmCountries_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
        GroupBox2.Visible = False
        FillCOUNTRIES("select * from COUNTRIES order by C_NAME")
        Country.Items.Clear()
        CT_Name.Text = ""
        ListBox2.Text = ""
    End Sub
    '====================== المدن==========================

    Sub FillCOUNTRIES()
        Country.Items.Clear()
        Dim Adp As New SqlClient.SqlDataAdapter("select * from COUNTRIES order by C_NAME", SQLconn)
        Dim DS As New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        '--------------------------======================
        For I = 0 To dt.Rows.Count - 1
            Country.Items.Add(dt.Rows(I).Item("C_Name"))

        Next


    End Sub

    Private Sub Country_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Country.SelectedIndexChanged
        If Country.Items.Count = 0 Then Exit Sub
        CT_Name.Text = ""
        ListBox2.Items.Clear()
        'Dim x = Country.SelectedValue
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Cities where C_name='" & Country.Text & "' order by CT_name", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        '--------------------------======================
        For I = 0 To dt.Rows.Count - 1
            ListBox2.Items.Add(dt.Rows(I).Item("CT_Name"))

        Next

    End Sub

    Private Sub Country_DropDown(sender As System.Object, e As System.EventArgs) Handles Country.DropDown
        FillCOUNTRIES()
    End Sub

    Private Sub BtnSave2_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave2.Click
        '==============التاكد من اختيار الدولة قبل عملية الاضافة
        If Country.SelectedIndex < 0 Then
            MsgBox("يرجى اختيار الدولة من القائمة", MsgBoxStyle.Critical, "تنبيه")
            Country.Focus()
            Exit Sub
        End If
        '===============التاكد من ادخال اسم المدينة قبل عملية الحفظ

        If CT_Name.Text.Trim = "" Then
            MsgBox("يجب إدخال اسم المدينة قبل اتمام عملية الاضافة", MsgBoxStyle.Critical, "خطأ")
            CT_Name.Focus()
            Exit Sub
        End If
        '==================================================================
        Try
            Dim sql = "select * from Cities where CT_name=N'" & (CT_Name.Text) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                MsgBox("إسم المدينة المدخلة موجود مسبقا", MsgBoxStyle.Exclamation, "رسالة تنبيه")

            Else
                Dim DR = dt.NewRow
                DR!c_name = Country.Text
                DR!CT_Name = CT_Name.Text
                dt.Rows.Add(DR)

            End If


            Dim cmd As New SqlClient.SqlCommandBuilder(adp)
            adp.Update(dt)

            Country_SelectedIndexChanged(Nothing, Nothing)
        Catch ex As Exception
            MsgBox("تم حفظ بيانات المدينة ف قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
        End Try
    End Sub

    Private Sub BtnEdit2_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit2.Click
        '==============التاكد من اختيار الدولة قبل عملية التعديل
        If Country.SelectedIndex < 0 Then
            MsgBox("يرجى اختيار الدولة من القائمة", MsgBoxStyle.Critical, "تنبيه")
            Country.Focus()
            Exit Sub
        End If
        '===============التاكد من ادخال اسم المدينة قبل عملية التعديل

        If CT_Name.Text.Trim = "" Then
            MsgBox("يجب اختيار اسم المدينة قبل اتمام عملية التعديل", MsgBoxStyle.Critical, "خطأ")
            CT_Name.Focus()
            Exit Sub
        End If
        '==================================================================
        Try
            Dim sql = "select * from Cities where c_name=N'" & Country.Text & "' and  CT_name=N'" & (ListBox1.Text) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox("إسم المدينة التى تريد تعديلها غير موجود ", MsgBoxStyle.Exclamation, "رسالة تنبيه")

            Else
                Dim DR = dt.Rows(0)
                DR!c_name = Country.Text
                DR!CT_Name = CT_Name.Text

            End If


            Dim cmd As New SqlClient.SqlCommandBuilder(adp)
            adp.Update(dt)
            Country_SelectedIndexChanged(Nothing, Nothing)
        Catch ex As Exception
            MsgBox("تم تعديل بيانات المدينة ف قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
        End Try
    End Sub

    Private Sub BtnDelete2_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete2.Click
        '==============التاكد من اختيار الدولة قبل عملية الحذف
        If Country.SelectedIndex < 0 Then
            MsgBox("يرجى اختيار الدولة من القائمة", MsgBoxStyle.Critical, "تنبيه")
            Country.Focus()
            Exit Sub
        End If
        '===============التاكد من ادخال اسم المدينة قبل عملية الحذف

        If CT_Name.Text.Trim = "" Then
            MsgBox("يجب اختيار اسم المدينة قبل اتمام عملية الحذف", MsgBoxStyle.Critical, "خطأ")
            CT_Name.Focus()
            Exit Sub
        End If
        '==================================================================
        Try
            Dim sql = "select * from Cities where c_name=N'" & Country.Text & "' and  CT_name=N'" & (ListBox1.Text) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox("إسم المدينة التى تريد حذفها غير موجود ", MsgBoxStyle.Exclamation, "رسالة تنبيه")

            Else
                Dim DR = dt.Rows(0)
                DR.Delete()

            End If


            Dim cmd As New SqlClient.SqlCommandBuilder(adp)
            adp.Update(dt)
            Country_SelectedIndexChanged(Nothing, Nothing)
        Catch ex As Exception
            MsgBox("تم حذف بيانات المدينة ف قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
        End Try
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        CT_Name.Text = ListBox2.Text
    End Sub

    Private Sub BtnExit_Click(sender As System.Object, e As System.EventArgs) Handles BtnExit.Click
        Close()

    End Sub

    Private Sub Browers_Click(sender As System.Object, e As System.EventArgs) Handles Browers.Click
        GroupBox2.Visible = True
        GroupBox2.BringToFront()
        GroupBox1.Visible = False
        'GroupBox1.BringToFront()
    End Sub

    Private Sub BtnClose2_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose2.Click
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
        GroupBox2.Visible = False
        'GroupBox2.BringToFront()
    End Sub
End Class