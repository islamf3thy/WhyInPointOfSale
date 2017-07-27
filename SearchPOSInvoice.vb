Public Class SearchPOSInvoice
    Private Function GetPosInvoiceItemsCount(POSInvoices) As Integer
        Dim adp As New SqlClient.SqlDataAdapter("SELECT COUNT (*) FROM  POSInvoicesDetails where POSInvoiceCode=N'" & POSInvoices & "'", SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        Return dt.Rows.Count
    End Function
    Private Sub SearchPOSInvoice_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        TextBox1.Focus()

        PuFillDataGridView(DataGridView2, " select * from POSInvoices order by POSInvoiceCode")
        For i = 0 To DataGridView2.Rows.Count - 1
            DataGridView2.Rows(i).Cells(4).Value = GetPosInvoiceItemsCount(DataGridView2.Rows(i).Cells(1).Value)
        Next
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If ComboBox1.SelectedIndex = 0 Then
            Dim sql = ""
            If Trim(TextBox1.Text) = "" Then
                sql = "select * from POSInvoices where (status=1) order by POSInvoiceCode"
            Else
                sql = "select * from POSInvoices where (status=1) and POSTotalInvoice like N'" & TextBox1.Text.Trim & "%" & "'" & " order by POSTotalInvoice "

            End If
            PuFillDataGridView(DataGridView2, sql)
        End If

       
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedIndex
            Case 0
                Panel1.Visible = False
                Panel2.Visible = False
                TextBox1.Text = ""
                TextBox1.Focus()
            Case 1, 2
                Panel1.Visible = False
                Panel2.Visible = True
                txtval1.Text = ""
                txtval2.Text = ""
                txtval1.Focus()
            Case 3
                Panel1.Visible = True
                Panel2.Visible = False
                D1.Value = Now.Date
                D2.Value = Now.Date
        End Select
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        PuFillDataGridView(DataGridView2, " select * from POSInvoices where (status=1) and POSInvoiceDate>='" & Format(D1.Value, "yyy/MM/dd") & "' and POSInvoiceDate<='" & Format(D2.Value, "yyyy/MM/dd") & "' order by POSInvoiceDate DESC ")

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        '================ البحث حسب اجمالى الفاتورة
        If Val(txtval1.Text) < 0 Then
            MsgBox("صيغة القيمة غير صحيحة", MsgBoxStyle.Critical, "خطأ")
            txtval1.Focus()
            Exit Sub
        End If

        If Val(txtval2.Text) < 0 Then
            MsgBox("صيغة القيمة غير صحيحة", MsgBoxStyle.Critical, "خطأ")
            txtval2.Focus()
            Exit Sub
        End If
        If Val(txtval1.Text) > Val(txtval2.Text) Then
            MsgBox("لايمكن للقيمة الاولى ان تكون اكبر من  القيمة الثانية", MsgBoxStyle.Critical, "خطأ")
            txtval2.Focus()
            Exit Sub
        End If
        '====================================================================================

        If ComboBox1.SelectedIndex = 1 Then
            PuFillDataGridView(DataGridView2, " select * from POSInvoices where (status=1) and POSTotalInvoice>=" & Val(txtval1.Text) & "' and POSTotalInvoice<=" & Val(txtval2.Text) & "' order by POSInvoiceCode ")
            '====================================================================================

        ElseIf ComboBox1.SelectedIndex = 2 Then
            PuFillDataGridView(DataGridView2, " select * from POSInvoices where (status=1) and POSPaidPayment>=" & Val(txtval1.Text) & "' and POSPaidPayment<=" & Val(txtval2.Text) & "' order by POSInvoiceCode ")

        End If


    End Sub

    Private Sub SearchExit_Click(sender As System.Object, e As System.EventArgs) Handles SearchExit.Click
        Close()

    End Sub

    Private Sub DataGridView2_Click(sender As System.Object, e As System.EventArgs) Handles DataGridView2.Click
        If DataGridView2.Rows.Count > 0 Then FrmPOS.ShowRecordData(DataGridView2.CurrentRow.Cells(1).Value)
        Close()

    End Sub


End Class