Public Class FrmSalesInvoiceBarCode





    Dim ItmCoD As String
    Function GetFiledName(filedname) As Boolean
        GetFiledName = False
        Try
            Dim str = "select * from Items where " & filedname & "=N'" & TxtBarCode.Text.Trim & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then GetFiledName = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى اتمام قرأة الباركود", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Function
    Private Sub BtnAdd_Click(sender As System.Object, e As System.EventArgs) Handles BtnAdd.Click
        If Trim(TxtBarCode.Text) = "" Then Exit Sub
        For i = 0 To FrmSalesInvoice.DataGridView1.Rows.Count - 1
            If FrmSalesInvoice.DataGridView1.Rows(i).Cells(8).Value = TxtBarCode.Text.Trim Then
                FrmSalesInvoice.DataGridView1.Rows(i).Cells(4).Value += 1
                FrmSalesInvoice.DataGridView1.Rows(i).Cells(6).Value = Format(Val(FrmSalesInvoice.DataGridView1.Rows(i).Cells(4).Value) * Val(FrmSalesInvoice.DataGridView1.Rows(i).Cells(3).Value) - Val(FrmSalesInvoice.DataGridView1.Rows(i).Cells(5).Value), "0.000")
                GoTo EOS
            End If
        Next
        '==============================================



        Dim sql = ""
        Dim barc = ""

        If GetFiledName("FirstUnitBarcode") = True Then
            sql = "select * from Items where FirstUnitBarcode=N'" & TxtBarCode.Text.Trim & "'"
            barc = 1
        ElseIf GetFiledName("SecoundtUnitBarcode") = True Then
            sql = "select * from Items where SecoundtUnitBarcode=N'" & TxtBarCode.Text.Trim & "'"
            barc = 2
        ElseIf GetFiledName("ThirdtUnitBarcode") = True Then
            sql = "select * from Items where ThirdtUnitBarcode=N'" & TxtBarCode.Text.Trim & "'"
            barc = 3
        Else

            GoTo EOS
        End If




        Dim adp As New SqlClient.SqlDataAdapter(sql, SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            FrmSalesInvoice.DataGridView1.Rows.Add()
            Dim RowIndex = FrmSalesInvoice.DataGridView1.Rows.Count - 1
            Dim dr = dt.Rows(0)
            FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(0).Value = dr!itemCode
            FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(1).Value = dr!itemName
            'FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(2).Value =
            FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(8).Value = TxtBarCode.Text
            FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(4).Value = 1
            '===========================================================
            'Dim DGVCC
            'DGVCC = FrmReceiptOfItems.DataGridView1.Rows(RowIndex).Cells(2)

            Select Case barc
                Case 1
                    'FrmSalesInvoice.DataGridView1.Rows.Add(dt.Rows(0).Item("FirstUnit"))
                    'FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(0).Value = dt.Rows(0).Item("itemCode")
                    FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(2).Value = dt.Rows(0).Item("FirstUnit")
                Case 2
                    'FrmSalesInvoice.DataGridView1.Rows.Add(dt.Rows(0).Item("SecoundtUnit"))
                    FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(2).Value = dt.Rows(0).Item("SecoundtUnit")
                Case 3
                    'FrmSalesInvoice.DataGridView1.Rows.Add(dt.Rows(0).Item("ThirdUnit"))
                    FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(2).Value = dt.Rows(0).Item("ThirdUnit")
            End Select
            '===========================================================

            Dim x = Split(GetDEf_Unit_Price(dr!itemCode), "|")
            'FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Cells(2).Value = x(0)
            FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Cells(3).Value = x(1)
            FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Cells(4).Value = 1
            ' ''FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Cells(6).Value = Format(x(1) * 1, "0.000")
            FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Cells(9).Value = x(2)


            '=====================================================
            FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(5).Value = "0.000"
            FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(6).Value = Format(Val(FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(4).Value) * Val(FrmSalesInvoice.DataGridView1.Rows(RowIndex).Cells(3).Value), "0.000")
            FrmSalesInvoice.DataGridView1.ClearSelection()
            FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Selected = True
        End If

EOS:
        TxtBarCode.Text = ""
        TxtBarCode.Focus()
        TxtBarCode_TextChanged(Nothing, Nothing)
        FrmSalesInvoice.Calc_SalesTax()
    End Sub

    Private Sub TxtBarCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBarCode.TextChanged
        If TxtBarCode.Text.Length = 0 Then BtnAdd.Enabled = False Else BtnAdd.Enabled = True
        PicBarCode.BackgroundImage = Code128(TxtBarCode.Text, "A")
    End Sub

    Private Sub FrmSalesInvoiceBarCode_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TxtBarCode.Focus()
        TxtBarCode_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub FrmSalesInvoiceBarCode_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Dispose()
        If e.KeyCode = Keys.Enter Then BtnAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub FrmSalesInvoiceBarCode_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        BtnAdd_Click(Nothing, Nothing)
    End Sub
End Class