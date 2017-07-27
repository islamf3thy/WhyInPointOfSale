Public Class FrmDamagedItems

    Sub ShowRecordData(DCode As String)

        Dim sql = "select * from DamageList where DamageListcode=N'" & (DCode) & "'"
        Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            MsgBox("لم يتم العثور على سند الاتلاف يرجى التحقق من الرقم وإعادة المحاولة", MsgBoxStyle.Exclamation, "رسالة تنبيه")
        Else
            Dim dr = dt.Rows(0)
            On Error Resume Next
            '============================ البيانات الاساسية ========================
            DamageListcode.Text = dr!DamageListcode
            DamageListDate.Text = dr!DamageListDate
            TotalDamageList.Text = dr!TotalDamageList
            SupervisorName.Text = dr!SupervisorName
            Note.Text = dr!Note
            TotalDamageListArabic.Text = dr!TotalDamageListArabic
            
            adp.Dispose()
            ds.Dispose()
            dt.Dispose()
            '=========================================عرض تفاصيل سند التوريد
            adp = New SqlClient.SqlDataAdapter("select * from DamageListDetails where DamageListcode=N'" & (DCode) & "'", SQLconn)
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


                DataGridView1.Rows(i).Cells(3).Value = dt.Rows(i).Item("Quantity")
                


            Next
            BtnSave.Enabled = False
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True

        End If
    End Sub



    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click

        On Error Resume Next
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
        BtnSave.Enabled = True
        BtnEdit.Enabled = False
        BtnDelete.Enabled = False
        GroupBox5.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()

        DamageListcode.Text = Format(GET_LAST_RECORD("DamageList", "DamageId") + 1, "DAMG000000")


    End Sub


    Private Sub FrmDamagedItems_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BtnNew_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click


        'If Format(SupplierInvoiceDate.Value, "yyy/mm/dd") > Format(DateValue(VoucherDate.Text), "yyyy/mm/dd") Then
        '    MsgBox("تاريخ سند استلام المواد اكبر من تاريخ فاتورة المورد", MsgBoxStyle.Exclamation, "خطأ")
        '    Exit Sub
        'End If

        ''For k = 0 To DataGridView1.Rows.Count - 1
        ''    If DataGridView1.Rows(k).Cells(1).Value = Nothing Then
        ''        DataGridView1.Rows.Remove(DataGridView1.Rows(k))
        ''    End If

        ''Next

        For k = 0 To DataGridView1.Rows.Count - 1
            If Val(DataGridView1.Rows(k).Cells(3).Value) = 0 Then
                MsgBox("يرجى التاكد من من كميات الاصناف ", MsgBoxStyle.Exclamation, "تنبيه")
            End If

        Next

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("يجب إدخال صنف واحد على الاقل لاتمام عملية الحفظ", MsgBoxStyle.Critical, "تعليمات")
            Exit Sub
        End If

        If SupervisorName.Text.Trim = "" Then
            MsgBox("يرجى إدخال اسم المسئول عن عملية الاتلاف", MsgBoxStyle.Critical, "تعليمات")
            SupervisorName.Focus()

        End If

        If Val(TotalDamageList.Text) <= 0 Then
            MsgBox("يرجى إدخال اجمالى تكلفة المواد التالفة بشكل صحيح", MsgBoxStyle.Critical, "تعليمات")
            TotalDamageList.Focus()
        End If

        Try
            Dim str = "select * from DamageList where DamageListcode=N'" & DamageListcode.Text.Trim & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                DamageListcode.Text = Format(GET_LAST_RECORD("DamageList", "DamageId") + 1, "DAMG000000")
            Else
                Dim dr = dt.NewRow
                dr!DamageListcode = DamageListcode.Text
                dr!DamageListDate = DamageListDate.Value
                dr!TotalDamageList = Val(TotalDamageList.Text)
                dr!SupervisorName = SupervisorName.Text
                dr!Note = Note.Text
                dr!TotalDamageListArabic = TotalDamageListArabic.Text
                dr!status = True

                dt.Rows.Add(dr)
                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)

            End If
            '=========================================================================
            adp = New SqlClient.SqlDataAdapter("select * from DamageListDetails", SQLconn)
            ds = New DataSet
            adp.Fill(ds)
            dt = ds.Tables(0)
            For i = 0 To DataGridView1.Rows.Count - 1
                Dim dr = dt.NewRow
                dr!DamageListcode = DamageListcode.Text
                dr!ItemCode = DataGridView1.Rows(i).Cells(0).Value
                dr!ItemName = DataGridView1.Rows(i).Cells(1).Value
                dr!Unit = DataGridView1.Rows(i).Cells(2).Value
                dr!Quantity = DataGridView1.Rows(i).Cells(3).Value

                dt.Rows.Add(dr)
                Dim cmd_Builder1 As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
            Next

            BtnNew_Click(sender, e)
            MsgBox("تم حفظ بيانات سند الاتلاف فى قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            'End Try
            MsgBox("فشل فى عملية الحفظ ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        End Try
    End Sub

    Private Sub FrmDamagedItems_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            frmOp = 20

            Dim F As New FrmItems
            PuFillDataGridView(F.DataGridView2, "select * from Items  where status='true' order by itemName")
            F.ComboBox1.SelectedIndex = 4
            F.BtnSearch.Show()
            F.GroupBox9.Visible = True
            F.GroupBox1.Visible = False
            F.SearchExit.Visible = False
            F.BtnEx.Visible = True
            F.GroupBox9.BringToFront()
            F.ShowDialog()
        End If

        If e.KeyCode = Keys.F3 Then
            FrmDamagedItemsBarcode.ShowDialog()

        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        frmOp = 20
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

    Private Sub BtnBarCode_Click(sender As System.Object, e As System.EventArgs) Handles BtnBarCode.Click
        FrmDamagedItemsBarcode.ShowDialog()

    End Sub

    Private Sub DataGridView1_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        For I = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(I).Cells(4).Value = "ــ"
        Next
    End Sub

    Private Sub BtnSearch_Click(sender As System.Object, e As System.EventArgs) Handles BtnSearch.Click
        PuFillDataGridView(DataGridView2, " select * from DamageList where (status=1) order by DamageListDate DESC")
        TextBox1.Text = ""
        D1.Value = Now.Date
        D2.Value = Now.Date
        Panel1.Visible = False
        ComboBox1.SelectedIndex = -1
        GroupBox5.Visible = True
        GroupBox1.Visible = False
        GroupBox5.BringToFront()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = -1 Or DataGridView1.Rows.Count = 0 Then Exit Sub
        Dim ColName = CType(sender, DataGridView).Columns(e.ColumnIndex).Name

        '=============================================
        If ColName = "ColumnUndo" Then
            If DataGridView1.Rows.Count = 0 Then Exit Sub
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        End If
    End Sub

    Private Sub TotalDamageList_TextChanged(sender As System.Object, e As System.EventArgs) Handles TotalDamageList.TextChanged
        If Me.TotalDamageList.Text = "" Then Exit Sub
        Me.TotalDamageListArabic.Text = IsLaM(Val(Me.TotalDamageList.Text), "Egypt")
    End Sub

    Private Sub TotalDamageList_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TotalDamageList.KeyPress
        If Char.IsControl(e.KeyChar) = False Then
            If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Then
                If TotalDamageList.Text.Contains(".") Then
                    If TotalDamageList.Text.Split(".")(1).Length < 3 Then
                        If Char.IsDigit(e.KeyChar) = False Then e.Handled = True
                    Else
                        e.Handled = True
                    End If
                End If
            Else
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        For k = 0 To DataGridView1.Rows.Count - 1
            If Val(DataGridView1.Rows(k).Cells(3).Value) = 0 Then
                MsgBox("يرجى التاكد من من كميات الاصناف ", MsgBoxStyle.Exclamation, "تنبيه")
            End If

        Next

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("يجب إدخال صنف واحد على الاقل لاتمام عملية الحفظ", MsgBoxStyle.Critical, "تعليمات")
            Exit Sub
        End If

        If SupervisorName.Text.Trim = "" Then
            MsgBox("يرجى إدخال اسم المسئول عن عملية الاتلاف", MsgBoxStyle.Critical, "تعليمات")
            SupervisorName.Focus()

        End If

        If Val(TotalDamageList.Text) <= 0 Then
            MsgBox("يرجى إدخال اجمالى تكلفة المواد التالفة بشكل صحيح", MsgBoxStyle.Critical, "تعليمات")
            TotalDamageList.Focus()
        End If
        If MsgBox("سوف يتم تعديل بيانات سند الاتلاف الحالى , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub


        Try
            Dim str = "select * from DamageList  where DamageListcode=N'" & (DamageListcode.Text) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox("لم يتم العثور على السند يرجى التاكد من رقم السند", MsgBoxStyle.Exclamation, "رسالة تنبيه")

            Else

                Dim dr = dt.Rows(0)
                dr!DamageListcode = DamageListcode.Text
                dr!DamageListDate = DamageListDate.Value
                dr!TotalDamageList = Val(TotalDamageList.Text)
                dr!SupervisorName = SupervisorName.Text
                dr!Note = Note.Text
                dr!TotalDamageListArabic = TotalDamageListArabic.Text


                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)




                adp.Dispose()
                ds.Dispose()
                dt.Dispose()


                '========================================== حذف تفاصيل السند السابقة


                Dim cmdd As New SqlClient.SqlCommand
                cmdd.Connection = SQLconn
                cmdd.CommandText = "delete from DamageListDetails where DamageListcode=N'" & DamageListcode.Text & "'"
                cmdd.ExecuteNonQuery()

                '=========================================حفظ تفاصيل سند التوريد


                adp = New SqlClient.SqlDataAdapter("select * from DamageListDetails", SQLconn)
                ds = New DataSet
                adp.Fill(ds)
                dt = ds.Tables(0)
                For i = 0 To DataGridView1.Rows.Count - 1

                    dr = dt.NewRow

                    dr!DamageListcode = DamageListcode.Text
                    dr!ItemCode = DataGridView1.Rows(i).Cells(0).Value
                    dr!ItemName = DataGridView1.Rows(i).Cells(1).Value
                    dr!Unit = DataGridView1.Rows(i).Cells(2).Value
                    dr!Quantity = DataGridView1.Rows(i).Cells(3).Value

                    dt.Rows.Add(dr)

                    Dim cmd_Builder1 As New SqlClient.SqlCommandBuilder(adp)
                    adp.Update(dt)

                Next
                BtnNew_Click(sender, e)
                MsgBox("تمت عملية التعديل البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            'End Try
            'MsgBox("فشل فى عملية التعديل ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        End Try

    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If MsgBox("سوف يتم حذف سجل هذا السند ,وترحيلة للارشيف , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

        Try
            Dim str = "select * from DamageList where DamageListcode=N'" & DamageListcode.Text.Trim & "'"
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex < 3 Then
            Panel1.Visible = False
        Else
            Panel1.Visible = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

        'select * from DamageList where (status=1) order by DamageListDate DESC
        Dim sql As String = ""
        'If ComboBox1.SelectedIndex = -1 Then Exit Sub
        If TextBox1.Text.Length = 0 Then
            sql = "select * from DamageList where (status=1) order by DamageListDate DESC"
        Else
            Select Case ComboBox1.SelectedIndex
                'عرض الكل
                Case 0
                    sql = "select * from DamageList order by DamageListcode "
                    'رقم السند
                Case 1
                    sql = "select * from DamageList where (status=1) and DamageListcode like N'" & TextBox1.Text.Trim & "%" & "'" & " order by DamageListcode "
                    'اسم المسئول
                Case 2
                    sql = "select * from DamageList where (status=1) and SupervisorName like N'" & TextBox1.Text.Trim & "%" & "'" & " order by SupervisorName "

                    'تاريخ
                    'Case 2
                    '    sql = "select * from DamageList where (status=1) and DamageListDate like N'" & TextBox1.Text.Trim & "%" & "'" & " order by DamageListDate "


            End Select
            If Trim(sql) <> "" Then PuFillDataGridView(DataGridView2, sql)

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        PuFillDataGridView(DataGridView2, " select * from DamageList where (status=1) and DamageListDate>='" & Format(D1.Value, "yyy/MM/dd") & "' and DamageListDate<='" & Format(D2.Value, "yyyy/MM/dd") & "' order by DamageListDate ")

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
            DataGridView2.Rows(I).Cells(0).Value = "عرض"
            Dim row As DataGridViewRow = DataGridView2.Rows(I)
            row.Height = 23

        Next
    End Sub

    Private Sub SearchExit_Click(sender As System.Object, e As System.EventArgs) Handles SearchExit.Click
        GroupBox5.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
    End Sub

    Private Sub BtnExit_Click(sender As System.Object, e As System.EventArgs) Handles BtnExit.Click
        Me.Dispose()
    End Sub
End Class