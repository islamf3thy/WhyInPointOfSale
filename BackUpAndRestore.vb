Imports System.Data.SqlClient
Public Class BackUpAndRestore
    Dim cmd As New SqlCommand
    Dim red As SqlDataReader
    Dim op As New OpenFileDialog
    Dim opf As New FolderBrowserDialog
    Private Sub redr()
        Try
            If SQLconn.State = ConnectionState.Open Then
                SQLconn.Close()
            End If
            Dim sle As String = "Select * From ba_t Where cod <> '" & False & "' AND tet <> '" & False & "' AND tete <> '" & False & "'"
            Dim data As New SqlDataAdapter(sle, SQLconn)
            Dim dats As New DataSet
            data.Fill(dats)
            If dats.Tables(0).Rows.Count >= 1 Then
                Dim id3 As Integer = 1
                cmd = New SqlCommand("SELECT * FROM ba_t WHERE id3= @id3", SQLconn)
                cmd.Parameters.Add(New SqlParameter("@id3", id3))
                SQLconn.Open()
                red = cmd.ExecuteReader()
                red.Read()
                cod.Text = red.GetString(0)
                tet.Text = red.GetString(1)
                tf.Text = red.GetString(2)
                red.Close()
                SQLconn.Close()
            ElseIf dats.Tables(0).Rows.Count < 1 Or dats.Tables(0).Rows.Count <> 1 Then
                SQLconn.Close()
                Return
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            SQLconn.Close()
        End Try
    End Sub
    Private Sub bac()
        Dim fln As String
        Dim back As String
        fln = tf.Text + "\\برنامج تجريبي" + DateTime.Now.ToString("yyyy_MM_dd", New System.Globalization.CultureInfo("en-US")) + "___" + DateTime.Now.ToString("hh__mm tt")
        back = "Backup Database SalesSystem_db to Disk='" + fln + ".bak'"
        cmd = New SqlCommand(back, SQLconn)
        If SQLconn.State = ConnectionState.Open Then
            SQLconn.Close()
        End If
        SQLconn.Open()
        cmd.ExecuteNonQuery()
        SQLconn.Close()
    End Sub
    Private Sub bac_nwe()
        Try
            If SQLconn.State = ConnectionState.Open Then
                SQLconn.Close()
            End If
            Dim sle As String = "Select * From ba_t Where cod = '" & Now.ToString("dddd") & "' AND tet = '" & Now.ToString("hh") & "' AND tete = '" & tf.Text & "'"
            Dim dataa As New SqlDataAdapter(sle, SQLconn)
            Dim dats As New DataSet
            dataa.Fill(dats)
            If dats.Tables(0).Rows.Count > 0 Then
                bac()
                Timer1.Stop()
            End If
            SQLconn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub INS_sit()
        Try
            SQLconn.Open()
            If cod.Text = "" Then MessageBox.Show("يجب تعبئة كافة الحقول قبل حفظ الإعدادات", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
            If tet.Text = "" Then MessageBox.Show("يجب تعبئة كافة الحقول قبل حفظ الإعدادات", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
            If tf.Text = "" Then MessageBox.Show("يجب تعبئة كافة الحقول قبل حفظ الإعدادات", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
            Dim sql As String = "insert into ba_t (cod,tet,tete,id3) values (@cod,@tet,@tete,@id3) "
            Dim cmd As SqlCommand = New SqlCommand(sql, SQLconn)
            Dim id3 As Integer = 1
            cmd.Parameters.Add(New SqlParameter("@cod", cod.Text))
            cmd.Parameters.Add(New SqlParameter("@tet", tet.Text))
            cmd.Parameters.Add(New SqlParameter("@tete", tf.Text))
            cmd.Parameters.Add(New SqlParameter("@id3", id3))
            cmd.ExecuteNonQuery()
            MessageBox.Show("تم حفظ الاعدادات بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        Finally
            SQLconn.Close()
        End Try
    End Sub

    Private Sub BackUpAndRestore_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        redr()
        OPENCONNECTION()
    End Sub

    Private Sub BCO_Click(sender As System.Object, e As System.EventArgs) Handles BCO.Click
        If opf.ShowDialog = DialogResult.OK Then
            t1.Text = opf.SelectedPath
        End If
    End Sub

    Private Sub BC_Click(sender As System.Object, e As System.EventArgs) Handles BC.Click
        Try
            If t1.Text = "" Then
                MessageBox.Show("يجب أختيار مسار حفظ النسخة الاحتياطية ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Me.Cursor = Cursors.WaitCursor
            Dim fln As String
            Dim back As String
            fln = t1.Text + "\\برنامج تجريبي" + DateTime.Now.ToString("yyyy_MM_dd", New System.Globalization.CultureInfo("en-US")) + "___" + DateTime.Now.ToString("hh__mm tt")
            back = "Backup Database SalesSystem_db to Disk='" + fln + ".bak'"
            cmd = New SqlCommand(back, SQLconn)
            If SQLconn.State = ConnectionState.Open Then
                SQLconn.Close()
            End If
            SQLconn.Open()
            cmd.ExecuteNonQuery()
            SQLconn.Close()
            t1.Text = ""
            Me.Cursor = Cursors.Default
            MessageBox.Show("تم حفظ النسخة الاحتياطية بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ch1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ch1.CheckedChanged
        If ch1.Checked = True Then
            If (MessageBox.Show("سوف يتم حذف الإعدادات السابقة هل ترغب في الإكمال", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim dle As String = ("Delete from [ba_t]")
                Dim cmd As New SqlCommand(dle, SQLconn)
                If SQLconn.State = ConnectionState.Open Then
                    SQLconn.Close()
                End If
                SQLconn.Open()
                cmd.ExecuteNonQuery()
                SQLconn.Close()
                GroupBox1.Enabled = True
                cod.Text = Nothing
                tet.Text = ""
                tf.Text = ""
            End If
        Else
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub dbr_Click(sender As System.Object, e As System.EventArgs) Handles dbr.Click
        If opf.ShowDialog = DialogResult.OK Then
            tf.Text = opf.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        INS_sit()
        GroupBox1.Enabled = False
    End Sub

    Private Sub BRO_Click(sender As System.Object, e As System.EventArgs) Handles BRO.Click
        If (op.ShowDialog() = DialogResult.OK) Then
            T2.Text = op.FileName
        End If
    End Sub

    Private Sub BR_Click(sender As System.Object, e As System.EventArgs) Handles BR.Click
        Try
            If T2.Text = "" Then
                MessageBox.Show("يجب أختيار مسارالنسخة الاحتياطية ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Me.Cursor = Cursors.WaitCursor
            Dim res As String

            res = "ALTER DATABASE SalesSystem_db SET OFFLINE WITH ROLLBACK IMMEDIATE; RESTORE DATABASE SalesSystem_db From Disk ='" + op.FileName + "' WITH REPLACE"

            'res = "ALTER DATABASE SalesSystem_db SET OFFLINE WITH ROLLBACK IMMEDIATE; RESTORE DATABASE SalesSystem_db From Disk ='" + op.FileName + "' ALTER DATABASE SalesSystem_db SET ONLINE WITH REPLACE"
            cmd = New SqlCommand(res, SQLconn)
            If SQLconn.State = ConnectionState.Open Then
                SQLconn.Close()
            End If
            SQLconn.Open()
            cmd.ExecuteNonQuery()
            SQLconn.Close()
            Me.Cursor = Cursors.Default
            T2.Text = ""
            MessageBox.Show("تم إستعادة النسخة الاحتياطية بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            T2.Text = ""
        End Try
    End Sub

    Private Sub BD_Click(sender As System.Object, e As System.EventArgs) Handles BD.Click
        If MsgBox("سوف يتم تفريغ قاعدة البيانات بشكل نهائي", vbYesNo + vbQuestion, "رسالة تأكيد") = MsgBoxResult.No Then
            If MsgBoxResult.Yes Then
                Return
            End If
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim dle As String = ("truncate table Categorizations   truncate table Cities   truncate table COUNTRIES   truncate table Customers truncate table DamageList   truncate table DamageListDetails   truncate table ItemNormalPricess   truncate table Items   truncate table ItemSeasonalPrices   truncate table ReceiptOfItems   truncate table ReceiptOfItemsDetails   truncate table ReceiptVoucher   truncate table SalesInvoice   truncate table SalesInvoicesDetails   truncate table Suppliers   truncate table SupplierTrans  truncate table TE  truncate table ba_t   truncate table Company   truncate table FinancialSupport   truncate table SupplierTrans  truncate table Users  ")
        Dim cmd As New SqlCommand(dle, SQLconn)
        If SQLconn.State = ConnectionState.Open Then
            SQLconn.Close()
        End If
        SQLconn.Open()
        cmd.ExecuteNonQuery()
        SQLconn.Close()
        Me.Cursor = Cursors.Default
        MessageBox.Show("تم تفريغ قاعدة البيانات بشكل نهائي ", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Close()

    End Sub
End Class