Public Class CompanyNameSYS

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Trim(ComName.Text) = "" Then
            ErrorProvider1.SetError(ComName, "يرجى إدخال اسم المؤسسة")
            Label1.ForeColor = Color.Red
            MsgBox("يرجى إدخال اسم المؤسسة ", MsgBoxStyle.Exclamation, "رسالة تنبيه")

            Exit Sub
        End If

        If MsgBox("سوف يتم حفظ هذة التعديلات , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

        Try
            Dim serv1 As String = ComName.Text
            Dim dat2 As String = ComMob.Text
            Dim uu As String = ComPhone.Text
            Dim pp As String = ComFax.Text
            Dim tt As String = ComEmail.Text
            My.Settings.ComName = serv1
            My.Settings.ComMob = dat2
            My.Settings.ComPhone = uu
            My.Settings.ComFax = pp
            My.Settings.ComEmail = tt
            My.Settings.Save()
            MessageBox.Show("سوف يتم إعادة تشغيل البرنامج من أجل حفظ الإعدادات ")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("خطأ غير معروف يرجى الاتصال بالمهندس / 01022606122", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub ComName_TextChanged(sender As System.Object, e As System.EventArgs) Handles ComName.TextChanged
        ErrorProvider1.SetError(ComName, "")
        Label1.ForeColor = Color.Black
    End Sub
End Class