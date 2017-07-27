Public Class FrmCategorizations

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        GroupBox2.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()

        BtnEdit.Enabled = False
        BtnDelete.Enabled = False
        BtnSave.Enabled = True
        CategorizationName.Text = ""
        Note.Text = ""
        CategorizationCode.Text = Format(GET_LAST_RECORD("Categorizations", "CategorizationAutoNumber") + 1, "CTS000000")

    End Sub

    Private Sub FrmCategorizations_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BtnNew_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
               If CategorizationName.Text.Trim = "" Then
            MsgBox("يرجى ادخال اسم التصنيف", MsgBoxStyle.Critical, "خطأ")
            CategorizationName.Focus()

        Else
            Dim adp = New SqlClient.SqlDataAdapter("select * from Categorizations where CategorizationName=N'" & CategorizationName.Text & "'", SQLconn)
            Dim ds = New DataSet
            adp.Fill(ds)
            Dim DT As DataTable
            DT = ds.Tables(0)
            If DT.Rows.Count > 0 Then
                MsgBox("اسم التصنيف المدخل موجود تحت رقم : " & DT.Rows.Add(0).Item("CategorizationCode"), MsgBoxStyle.Information, "رسالة تنبية")

            Else

                Dim dr = DT.NewRow
                dr!CategorizationCode = CategorizationCode.Text
                dr!CategorizationName = CategorizationName.Text
                dr!Note = Note.Text
                DT.Rows.Add(dr)
                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(DT)
                BtnNew_Click(sender, e)
                MsgBox("تم حفظ بيانات التصنيق فى قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

            End If

        End If

    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        If CategorizationName.Text.Trim = "" Then
            MsgBox("يرجى ادخال اسم التصنيف", MsgBoxStyle.Critical, "خطأ")
            CategorizationName.Focus()

            Exit Sub
        End If
        If MsgBox(" سوف يتم تعديل هذه التعديلات ، هل تريد الاستمرار ؟", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة ") = MsgBoxResult.No Then Exit Sub
        Dim str = "select * from Categorizations where CategorizationCode=N'" & CategorizationCode.Text & "'"
        Dim adp = New SqlClient.SqlDataAdapter(str, SQLconn)
        Dim ds = New DataSet
        adp.Fill(ds)
        Dim DT As DataTable
        DT = ds.Tables(0)
        If DT.Rows.Count = 0 Then
            MsgBox("لم يتم العثور على البيانات .يرجى التاكد من الرمز", MsgBoxStyle.Information, "رسالة تنبية")

        Else

            Dim dr = DT.Rows(0)
            dr!CategorizationName = CategorizationName.Text
            dr!Note = Note.Text
            Dim cmd As New SqlClient.SqlCommandBuilder(adp)
            adp.Update(DT)
            BtnNew_Click(sender, e)
            MsgBox("تم تعديل بيانات التصنيق فى قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

        End If
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If CategorizationName.Text.Trim = "" Then
            MsgBox("يرجى ادخال اسم التصنيف", MsgBoxStyle.Critical, "خطأ")
            CategorizationName.Focus()

            Exit Sub
        End If
        If MsgBox(" سوف يتم حذف هذه التعديلات ، هل تريد الاستمرار ؟", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة ") = MsgBoxResult.No Then Exit Sub
        Dim str = "select * from Categorizations where CategorizationCode=N'" & CategorizationCode.Text & "'"
        Dim adp = New SqlClient.SqlDataAdapter(str, SQLconn)
        Dim ds = New DataSet
        adp.Fill(ds)
        Dim DT As DataTable
        DT = ds.Tables(0)
        If DT.Rows.Count = 0 Then
            MsgBox("لم يتم العثور على البيانات .يرجى التاكد من الرمز", MsgBoxStyle.Information, "رسالة تنبية")

        Else

            Dim dr = DT.Rows(0)

            dr.Delete()

            Dim cmd As New SqlClient.SqlCommandBuilder(adp)
            adp.Update(DT)
            BtnNew_Click(sender, e)
            MsgBox("تم حذف بيانات التصنيق فى قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim sql As String = ""

        If TextBox1.Text.Length = 0 Then

            sql = "select * from Categorizations order by CategorizationName"
        Else
            sql = "select * from Categorizations where CategorizationName like N'" & TextBox1.Text.Trim & "%" & "'" & " order by CategorizationName "
        End If
        If Trim(sql) <> "" Then PuFillDataGridView(DataGridView1, sql)
        
    End Sub

    Private Sub DataGridView1_Click(sender As System.Object, e As System.EventArgs) Handles DataGridView1.Click
        If DataGridView1.Rows.Count = 0 Then Exit Sub
        '=======================================
        With DataGridView1.CurrentRow
            CategorizationCode.Text = .Cells(1).Value
            CategorizationName.Text = .Cells(2).Value
            Note.Text = .Cells(3).Value
        End With
        BtnSave.Enabled = False
        BtnEdit.Enabled = True
        BtnDelete.Enabled = True
        CategorizationName.Focus()
        GroupBox2.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
    End Sub

    Private Sub DataGridView1_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        For I = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(I).Cells(0).Value = " عرض"
            Dim row As DataGridViewRow = DataGridView1.Rows(I)
            row.Height = 23
        Next

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        GroupBox2.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
    End Sub

    Private Sub BtnSearch_Click(sender As System.Object, e As System.EventArgs) Handles BtnSearch.Click
        PuFillDataGridView(DataGridView1, " select * from Categorizations order by CategorizationCode")
        GroupBox2.Visible = True
        GroupBox1.Visible = False
        GroupBox2.BringToFront()
    End Sub

    Private Sub BtnExit_Click(sender As System.Object, e As System.EventArgs) Handles BtnExit.Click
        Close()

    End Sub
End Class