Public Class FrmPermissions
    Sub ShowData(UserId)

        Dim str = "select * from Users where UserId=" & Txt_ID.Text
        Dim adp = New SqlClient.SqlDataAdapter(str, SQLconn)
        Dim ds = New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)


        Dim dr = dt.Rows(0)

        UserName.Text = dr!UserName
        UserPass.Text = dr!UserPassword
        

        W1.Checked = dr!W1
        W2.Checked = dr!W2
        W3.Checked = dr!W3
        W4.Checked = dr!W4
        W5.Checked = dr!W5
        W6.Checked = dr!W6
        W7.Checked = dr!W7
        W8.Checked = dr!W8
        W10.Checked = dr!W10
        W11.Checked = dr!W11
        W12.Checked = dr!W12
        W13.Checked = dr!W13
        W14.Checked = dr!W14
        W15.Checked = dr!W15
        W16.Checked = dr!W16
        W17.Checked = dr!W17
        W18.Checked = dr!W18
        BtnSave.Enabled = False
        BtnEdit.Enabled = True
        BtnDelete.Enabled = True


    End Sub

    Function GetUserId(UserId) As String
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Users  where UserName=N'" & UserId & "' ", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt As New DataTable
        dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then Return dt.Rows(0).Item("UserId") Else Return ""
    End Function
    Private Sub W9_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles W9.CheckedChanged
        For Each c As Control In Me.GroupBox3.Controls
            If W9.Checked = True Then
                If TypeOf c Is CheckBox And c.Tag = "A" Then
                    DirectCast(c, CheckBox).Checked = True

                End If
            Else
                If TypeOf c Is CheckBox And c.Tag = "A" Then
                    DirectCast(c, CheckBox).Checked = False
                End If
            End If
        Next
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click

        If Trim(UserName.Text) = "" Then
            ErrorProvider1.SetError(l1, "أدخل اسم المستخدم")
            MsgBox("أدخل اسم المستخدم", MsgBoxStyle.Exclamation, "تنبيه")

            Exit Sub
        End If

        If Trim(UserPass.Text) = "" Then
            ErrorProvider1.SetError(l2, "أدخل كلمة المرور")
            MsgBox("كلمة المرور غير مطابقة", MsgBoxStyle.Exclamation, "تنبيه")

            Exit Sub
        End If

        If Trim(UserPass.Text) <> Trim(UserPassConfirm.Text) Then
            ErrorProvider1.SetError(l2, "كلمة المرور غير مطابقة")
            MsgBox("كلمة المرور غير مطابقة", MsgBoxStyle.Exclamation, "تنبيه")

            Exit Sub
        End If



        Dim adp As New SqlClient.SqlDataAdapter("select * from Users where UserName=N'" & UserName.Text & "'", SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            MsgBox("إسم المستخدم موجود مسبقا", MsgBoxStyle.Exclamation, "رسالة خطأ")
            UserName.Focus()
            Exit Sub
        End If

        Try
            Dim dr = dt.NewRow

            dr!UserName = UserName.Text
            dr!UserPassword = UserPass.Text

            dr!W1 = W1.Checked
            dr!W2 = W2.Checked
            dr!W3 = W3.Checked
            dr!W4 = W4.Checked
            dr!W5 = W5.Checked
            dr!W6 = W6.Checked
            dr!W7 = W7.Checked
            dr!W8 = W8.Checked
            dr!W10 = W10.Checked
            dr!W11 = W11.Checked
            dr!W12 = W12.Checked
            dr!W13 = W13.Checked
            dr!W14 = W14.Checked
            dr!W15 = W15.Checked
            dr!W16 = W16.Checked
            dr!W17 = W17.Checked
            dr!W18 = W18.Checked
            dr!status = True

            dt.Rows.Add(dr)
            Dim cmd_Builder1 As New SqlClient.SqlCommandBuilder(adp)
            adp.Update(dt)




            BtnNew_Click(Nothing, Nothing)
            MsgBox("تمت العملية بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)

        End Try
    End Sub

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        ErrorProvider1.SetError(l1, "")
        ErrorProvider1.SetError(l2, "")
        ErrorProvider1.SetError(l3, "")

        Txt_ID.Text = ""
        On Error Resume Next
        For i = 0 To GroupBox2.Controls.Count
            If TypeOf GroupBox2.Controls(i) Is TextBox Then GroupBox2.Controls(i).Text = ""
        Next

        For Each c As Control In Me.GroupBox3.Controls
            If TypeOf c Is CheckBox Then
                DirectCast(c, CheckBox).Checked = False
            End If
        Next

        BtnSave.Enabled = True
        BtnEdit.Enabled = False
        BtnDelete.Enabled = False

        FillList(ListBox1, "Users", "UserName", True)
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        If Current_User = Txt_ID.Text Then
            MsgBox("لايمكنك تعديل صلاحيتك يرجى الطلب من مدير آخر للنظام بتعديل البيانات", MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If

        If Trim(UserName.Text) = "" Then
            ErrorProvider1.SetError(l1, "أدخل اسم المستخدم")
            Exit Sub
        End If

        If Trim(UserPass.Text) = "" Then
            ErrorProvider1.SetError(l2, "أدخل كلمة المرور")
            Exit Sub
        End If

        If Trim(UserPass.Text) <> Trim(UserPassConfirm.Text) Then
            ErrorProvider1.SetError(l2, "كلمة المرور غير مطابقة")
            Exit Sub
        End If
        Try
            If MsgBox("سوف يتم حفظ هذة التعديلات , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub


            Dim adp As New SqlClient.SqlDataAdapter("select * from Users where UserId=" & Txt_ID.Text, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox("إسم المستخدم موجود مسبقا", MsgBoxStyle.Exclamation, "رسالة خطأ")
                UserName.Focus()
                Exit Sub
            End If


            Dim dr = dt.Rows(0)

            dr!UserName = UserName.Text
            dr!UserPassword = UserPass.Text

            dr!W1 = W1.Checked
            dr!W2 = W2.Checked
            dr!W3 = W3.Checked
            dr!W4 = W4.Checked
            dr!W5 = W5.Checked
            dr!W6 = W6.Checked
            dr!W7 = W7.Checked
            dr!W8 = W8.Checked
            dr!W10 = W10.Checked
            dr!W11 = W11.Checked
            dr!W12 = W12.Checked
            dr!W13 = W13.Checked
            dr!W14 = W14.Checked
            dr!W15 = W15.Checked
            dr!W16 = W16.Checked
            dr!W17 = W17.Checked
            dr!W18 = W18.Checked


            Dim cmd_Builder1 As New SqlClient.SqlCommandBuilder(adp)
            adp.Update(dt)




            BtnNew_Click(Nothing, Nothing)
            MsgBox("تمت عملية التعديل بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)

        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.Items.Count = 0 Then Exit Sub
        Txt_ID.Text = GetUserId(ListBox1.Text)
        ShowData(Txt_ID.Text)

    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click

        If Trim(UserName.Text) = "" Then
            ErrorProvider1.SetError(l1, "أدخل اسم المستخدم")
            Exit Sub
        End If

        If Trim(UserPass.Text) = "" Then
            ErrorProvider1.SetError(l2, "أدخل كلمة المرور")
            Exit Sub
        End If

        If Trim(UserPass.Text) <> Trim(UserPassConfirm.Text) Then
            ErrorProvider1.SetError(l2, "كلمة المرور غير مطابقة")
            Exit Sub
        End If

        If MsgBox("سوف يتم حفظ هذة التعديلات , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub


        Try
            Dim str = "select * from Users where UserId=" & Txt_ID.Text
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)

            Dim dr = dt.Rows(0)
            dr.Delete()
            'dr!status = False
            Dim cmd As New SqlClient.SqlCommandBuilder(adp)
            adp.Update(dt)
            BtnNew_Click(Nothing, Nothing)
            MsgBox("تمت عملية الحذف بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
        'Catch
        '    MsgBox("فشل فى عملية الحذف ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        'End Try
    End Sub

  
    Private Sub FrmPermissions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BtnNew_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnExit_Click(sender As System.Object, e As System.EventArgs) Handles BtnExit.Click
        Close()

    End Sub
End Class