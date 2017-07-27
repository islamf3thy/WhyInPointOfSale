Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Win32

Public Class ConnectionMode

    Private Sub cs_DropDown(sender As System.Object, e As System.EventArgs) Handles cs.DropDown
        Dim SQL2 As New SqlConnection("Data Source=" & cs.Text & ";Initial Catalog=master;integrated security=true")
        Dim dss As New DataSet
        Dim da As New SqlDataAdapter("select name from sys.servers", SQL2)
        cs.Items.Clear()
        da.Fill(dss, 0)
        For i As Integer = 0 To Me.BindingContext(dss, 0).Count - 1
            cs.Items.Add(Me.BindingContext(dss, 0).Current("name"))
            Me.BindingContext(dss, 0).Position += 1
        Next
    End Sub

    Private Sub cd_DropDown(sender As System.Object, e As System.EventArgs) Handles cd.DropDown
        If cs.Text = "" Then
            MessageBox.Show("يجب أختيار أسم السيرفر اولاً ")
            cs.Focus()
            cd.Items.Clear()
            Return
        End If
        Dim SQL22 As New SqlConnection("Data Source=" & cs.Text & ";Initial Catalog=master;integrated security=true")
        Dim dss As New DataSet
        Dim da As New SqlDataAdapter("select name from sys.databases", SQL22)
        cd.Items.Clear()
        da.Fill(dss, 0)
        For i As Integer = 0 To Me.BindingContext(dss, 0).Count - 1
            cd.Items.Add(Me.BindingContext(dss, 0).Current("name"))
            Me.BindingContext(dss, 0).Position += 1
        Next
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        Dim serv1 As String = cs.Text
        Dim dat2 As String = cd.Text
        Dim uu As String = tu.Text
        Dim pp As String = tp.Text
        Dim tt As String = tet.Text
        My.Settings.sern = serv1
        My.Settings.datan = dat2
        My.Settings.un = uu
        My.Settings.pn = pp
        My.Settings.tn = tt
        My.Settings.Save()
        MessageBox.Show("سوف يتم إعادة تشغيل البرنامج من أجل حفظ الإعدادات ")
        Me.Close()
    End Sub

    Private Sub ConnectionMode_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
       





        cs.Text = My.Settings.sern
        cd.Text = My.Settings.datan
        tu.Text = My.Settings.un
        tp.Text = My.Settings.pn
        tet.Text = My.Settings.tn
        If tet.Text <> "" Then
            rt.Checked = True
        ElseIf tu.Text <> "" And tp.Text <> "" And cs.Text <> "" And cd.Text <> "" Then
            rsql.Checked = True
        ElseIf cs.Text <> "" And cd.Text <> "" Then
            rw.Checked = True
        End If
    End Sub

    Private Sub rw_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rw.CheckedChanged
        If rw.Checked = True Then
            tu.Enabled = False
            tp.Enabled = False
            cs.Enabled = True : cd.Enabled = True : tet.Text = Nothing : btnsave.Enabled = True : Button2.Enabled = False : tu.Text = ""
            tp.Text = ""
        End If
    End Sub

    Private Sub rsql_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rsql.CheckedChanged
        If rsql.Checked = True Then
            tu.Enabled = True
            tp.Enabled = True
            cs.Enabled = True : cd.Enabled = True : tet.Text = Nothing : btnsave.Enabled = True : Button2.Enabled = False
        End If
    End Sub

    Private Sub tu_TextChanged(sender As System.Object, e As System.EventArgs) Handles tu.TextChanged
        If cs.Text = "" And cd.Text = "" Then
            MessageBox.Show(" قم بأختيار السيرفر والقاعدة", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cs.Focus() : tu.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub tp_TextChanged(sender As System.Object, e As System.EventArgs) Handles tp.TextChanged
        If cs.Text = "" Or cd.Text = "" Or tu.Text = "" Then
            MessageBox.Show(" قم بأختيار السيرفر والقاعدةواسم المستخدم", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cs.Focus() : tp.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim op As New OpenFileDialog
        op.Title = "اضافة الملفات"
        op.Filter = "All Files|*.*"
        If op.ShowDialog = Windows.Forms.DialogResult.OK Then
            If String.IsNullOrEmpty(op.FileName) Then
                Return
            End If

            tet.Text = op.FileName

        End If
    End Sub

    Private Sub rt_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rt.CheckedChanged
        If rt.Checked = True Then
            cs.Text = "" : cd.Text = "" : tu.Text = "" : tp.Text = "" : cs.Enabled = False
            cd.Enabled = False : tu.Enabled = False
            tp.Enabled = False : tet.Enabled = True : Button1.Enabled = True : btnsave.Enabled = True : Button2.Enabled = False
        Else
            tet.Enabled = False
            Button1.Enabled = False
        End If
    End Sub

    Private Sub rpnd_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rpnd.CheckedChanged
        If rpnd.Checked = True Then
            cd.Text = "" : tu.Text = "" : tp.Text = "" : tet.Text = ""

            cs.Enabled = True : cd.Enabled = False : tu.Enabled = False
            tp.Enabled = False : tet.Enabled = False : Button1.Enabled = False : btnsave.Enabled = False : Button2.Enabled = True
            tnd.Enabled = True
        Else
            tnd.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim SQL2 As New SqlConnection("Data Source=" & cs.Text & ";Initial Catalog=master;integrated security=true;Pooling=False")
        Dim myCommand As String
        myCommand = "CREATE database " & tnd.Text & ""
        Dim cmd As SqlCommand = New SqlCommand(myCommand, SQL2)
        Try
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
        Catch ex As Exception
            MsgBox(" يوجد مشكلة في إنشاء القاعدة", MsgBoxStyle.Critical, " تنبية")
            Exit Sub
        End Try
        Try
            Dim cn As SqlConnection = New SqlConnection("Data Source=" & cs.Text & ";Initial Catalog=" & tnd.Text & ";Integrated Security=True;Pooling=False")
            Dim sql As String
            sql = "CREATE TABLE " & My.Settings.ta & "(salary float null )"
            cmd = New SqlCommand(sql, cn)
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            If MsgBox("تم إنشاء قاعدة البيانات بنجاح ... هل تريد فتح نافذة النسخ والاسترجاع ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then
                Exit Sub
            Else
                BackUpAndRestore.ShowDialog()

            End If

            tnd.Text = Nothing : tnd.Enabled = False : rw.Checked = True
        Catch
            MsgBox(" يوجد مشكلة في إنشاء الجدول", MsgBoxStyle.Critical, " تنبية")
            Exit Sub
        End Try
    End Sub

    Private Sub tnd_TextChanged(sender As System.Object, e As System.EventArgs) Handles tnd.TextChanged
        If cs.Text = "" Then
            MessageBox.Show(" قم بأختيار السيرفر المطلوب أولاً", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cs.Focus() : tnd.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub ConnectionMode_Leave(sender As System.Object, e As System.EventArgs) Handles MyBase.Leave

       
    End Sub

    Private Sub btnext_Click(sender As System.Object, e As System.EventArgs) Handles btnext.Click
        Close()
    End Sub
End Class