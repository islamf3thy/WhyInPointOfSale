Public Class Loginsystem
    Function GetUserId(UserId) As String
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Users  where UserName=N'" & UserId & "' ", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt As New DataTable
        dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then Return dt.Rows(0).Item("UserId") Else Return ""
    End Function

    Function GetUSerPassWord(UserPassWord) As String
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Users where UserName=N'" & UserPassWord & "' ", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt As New DataTable
        dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then Return dt.Rows(0).Item("UserPassword") Else Return ""
    End Function

    Private Sub Loginsystem_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Focus()
        txtPass.Text = ""
        ComboBox1.Items.Clear()
        FillComboList(ComboBox1, "Users", "UserName", True)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex < 0 Then ComboBox1.Focus() : Exit Sub
        If txtPass.Text = "" Then ComboBox1.Focus() : Exit Sub

        If Trim(Txt_Pass.Text) <> txtPass.Text Then
            MsgBox("كلمة المرور لهذا المستخدم غير صحيحة", MsgBoxStyle.Exclamation, "رسالة خطأ")
            Exit Sub
        End If



        Dim sql = "select * from Users  where UserId=" & Txt_ID.Text
        Dim Adp = New SqlClient.SqlDataAdapter(sql, SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = New DataTable
        dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow
            dr = dt.Rows(0)

            Form2.W1.Enabled = dr!W1
            Form2.W2.Enabled = dr!W2
            Form2.W3.Enabled = dr!W3
            Form2.W4.Enabled = dr!W4
            Form2.W5.Enabled = dr!W5
            Form2.W6.Enabled = dr!W6
            Form2.W7.Enabled = dr!W7
            Form2.W8.Enabled = dr!W8
            Form2.W10.Enabled = dr!W10
            Form2.W11.Enabled = dr!W11
            Form2.W12.Enabled = dr!W12
            Form2.W13.Enabled = dr!W13
            Form2.W14.Enabled = dr!W14
            Form2.W15.Enabled = dr!W15
            Form2.W16.Enabled = dr!W16
            Form2.W17.Enabled = dr!W17
            Form2.W18.Enabled = dr!W18
            Current_User = Txt_ID.Text
            Form2.ToolUserName.Text = "المستخدم الحالى : " & ComboBox1.Text
            Me.Close()
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Txt_ID.Text = GetUserId(ComboBox1.Text)
        Txt_Pass.Text = GetUSerPassWord(ComboBox1.Text)
    End Sub

    Private Sub txtPass_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then Button1_Click(sender, e)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        SQLconn.Dispose()
        SQLconn.Close()
        End
    End Sub
End Class