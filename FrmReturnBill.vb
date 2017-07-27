Public Class FrmReturnBill

    Private Sub TxtInvSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtInvSearch.TextChanged
        Dim sql As String = ""
        If TxtInvSearch.Text.Length = 0 Then
            sql = "select * from SalesInvoice where (status=1) order by InvoiceDate DESC"
        Else
            sql = "select * from SalesInvoice where (status=1) and CustomerName like N'" & Trim(TxtInvSearch.Text) & "%" & "'" & " order by  InvoiceCode "

        End If
        PuFillDataGridView(DataGridMain, sql)
    End Sub

    Private Sub TxtNameSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNameSearch.TextChanged
        Dim sql As String = ""
        If TxtNameSearch.Text.Length = 0 Then
            sql = "select * from SalesInvoice where (status=1) order by InvoiceDate DESC"
        Else
            sql = "select * from SalesInvoice where (status=1) and InvoiceCode like N'" & Trim(TxtNameSearch.Text) & "%" & "'" & " order by  CustomerName "

        End If
        PuFillDataGridView(DataGridMain, sql)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim sql = "select * from SalesInvoice where (status=1) and InvoiceDate>='" & Format(D1.Value, "yyy/MM/dd") & "' and InvoiceDate<='" & Format(D2.Value, "yyyy/MM/dd") & "' order by InvoiceDate "
        PuFillDataGridView(DataGridMain, sql)

    End Sub

    Private Sub DataGridMain_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridMain.CellContentClick
        If e.ColumnIndex = -1 Then Exit Sub
        Dim colName As String = CType(sender, DataGridView).Columns(e.ColumnIndex).Name
        '==============================================
        If colName = "colDet" Then
            GroupBox3.Text = "تفاصيل الفاتورة رقم :" & DataGridMain.CurrentRow.Cells(3).Value
            PuFillDataGridView(DataGridDetailes, "select * from SalesInvoicesDetails where InvoiceCode=N'" & DataGridMain.CurrentRow.Cells(3).Value & "'")

        End If

        If colName = "colRet" Then
            If MsgBox("سوف يتم استرجاع هذة الفاتورة من الارشيف .هل تريد الاستمرار", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

            Try
                Dim cmdd As New SqlClient.SqlCommand
                cmdd.Connection = SQLconn
                cmdd.CommandText = "UPDATE SalesInvoice set status= 0  where InvoiceCode=N '" & DataGridMain.CurrentRow.Cells(3).Value & "'"
                cmdd.ExecuteNonQuery()

                '=======================================================

                If DataGridMain.CurrentRow.Cells(6).Value = "نقدى" Then
                    Dim str = "إسترجاع فاتورة مبيعات رقم :" & DataGridMain.CurrentRow.Cells(3).Value
                    CustomerTrans(DataGridMain.CurrentRow.Cells(4).Value, "استرجاع فاتورة", DataGridMain.CurrentRow.Cells(3).Value, Now.Date, str, 0, DataGridMain.CurrentRow.Cells(5).Value)
                Else
                    Dim date1 As Date = DataGridMain.CurrentRow.Cells(8).Value
                    If DateDiff(DateInterval.Day, date1, Now.Date) > 0 Then
                        cmdd.Connection = SQLconn
                        cmdd.CommandText = "delete from CustomerTrans  where CustomerName=N '" & DataGridMain.CurrentRow.Cells(4).Value & "' and VoucherDescriotion like N '" & "%" & DataGridMain.CurrentRow.Cells(3).Value & "%" & "'"
                        cmdd.ExecuteNonQuery()
                    End If
                End If

                BtnNew_Click(Nothing, Nothing)
                MsgBox("تم استرجاع الفاتورة بنجاح وترحيل البيانات الى ملف الارشيف", MsgBoxStyle.Information, "رسالة تأكيد")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "فشل فى عملية الاسترجاع", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
                'End Try
                'MsgBox("فشل فى عملية الحفظ ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
            End Try
        End If
    End Sub

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        On Error Resume Next
        For i = 0 To GroupBox2.Controls.Count
            If TypeOf GroupBox2.Controls(i) Is TextBox Then GroupBox2.Controls(i).Text = ""
            If TypeOf GroupBox2.Controls(i) Is DateTimePicker Then GroupBox2.Controls(i).Text = Now.Date.Date
        Next

        DataGridMain.DataSource = Nothing
        DataGridMain.Rows.Clear()

        DataGridDetailes.DataSource = Nothing
        DataGridDetailes.Rows.Clear()

    End Sub

    Private Sub FrmReturnBill_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BtnNew_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnExit_Click(sender As System.Object, e As System.EventArgs) Handles BtnExit.Click
        Close()
    End Sub
End Class