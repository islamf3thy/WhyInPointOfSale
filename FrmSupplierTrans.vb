Public Class FrmSupplierTrans

    Sub fillDataGriedView(sql)
        'ط========عرض سندات استلام الاصناف من المورد
        DataGridView1.Rows.Clear()
        '=========================== الكمية التى تم توريدها الى المخزن
        Dim str = " select  sum(VoucherDebit) , sum(VoucherCredit) from SupplierTrans where  SupplierName=N'" & SupplierName.Text & "' and VoucherDate<'" & Format(DateFrom.Value, "yyy/MM/dd") & "'"
        Dim cmd As New SqlClient.SqlCommand(str, SQLconn)
        Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(cmd)
        Dim dta As New DataTable("SupplierTrans")
        da.Fill(dta)

        Dim SumDebit As Decimal = 0.0
        Dim SumCredit As Decimal = 0.0
        If IsDBNull(dta.Rows(0).Item(0)) = False Then SumDebit = (dta.Rows(0).Item(0))
        If IsDBNull(dta.Rows(0).Item(1)) = False Then SumCredit = (dta.Rows(0).Item(1))
        Dim i = DataGridView1.Rows.Add
        DataGridView1.Rows(i).Cells(0).Value = "رصيد سابق"
        DataGridView1.Rows(i).Cells(3).Value = "رصيد سابق"
        DataGridView1.Rows(i).Cells(4).Value = Format(Val(SumDebit), "#,0.000")
        DataGridView1.Rows(i).Cells(5).Value = Format(Val(SumCredit), "#,0.000")



        Dim Adp = New SqlClient.SqlDataAdapter(sql, SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        Dim g = dt.Rows.Count
        For i = 0 To dt.Rows.Count - 1
            Dim j = DataGridView1.Rows.Add
            DataGridView1.Rows(j).Cells(0).Value = dt.Rows(i).Item("VoucherType")
            DataGridView1.Rows(j).Cells(1).Value = dt.Rows(i).Item("VoucherCode")
            DataGridView1.Rows(j).Cells(2).Value = dt.Rows(i).Item("VoucherDate")
            DataGridView1.Rows(j).Cells(3).Value = dt.Rows(i).Item("VoucherDescriotion")
            DataGridView1.Rows(j).Cells(4).Value = dt.Rows(i).Item("VoucherDebit")
            DataGridView1.Rows(j).Cells(5).Value = dt.Rows(i).Item("VoucherCredit")

        Next

        'DataGridView1.AutoGenerateColumns = False
        'DataGridView1.DataSource = dt.DefaultView


        Dim x As New Decimal
        Dim y As New Decimal
        Dim z As New Decimal
        x = 0.0
        y = 0.0
        z = 0.0

        txtNetPurchase.Text = 0.0

        For i = 0 To DataGridView1.Rows.Count - 1
            x = Val(x) + (DataGridView1.Rows(i).Cells(4).Value)
            y = Val(y) + (DataGridView1.Rows(i).Cells(5).Value)

            If DataGridView1.Rows(i).Cells(0).Value = "سند إستلام اصناف" Then txtNetPurchase.Text = Val(txtNetPurchase.Text) + Val(DataGridView1.Rows(i).Cells(5).Value)


        Next
        'x = x * (-1)
        z = y + (x * -1)
        totaldebit.Text = Format(x, "#0.000")
        totalcredit.Text = Format(y, "#0.000")
        txtperoid.Text = Format(z, "#0.000")
        txtNetPurchase.Text = Format(Val(txtNetPurchase.Text), "#0.000")
        If Val(z) <> 0 Then
            If Val(z) < 0 Then z = z * -1
            totalarabic.Text = IsLaM(Val(txtperoid.Text), "Egypt")
        Else
            totalarabic.Text = ""
        End If



    End Sub
    Sub CLR()
        DateFrom.Value = Now.Date
        DateTo.Value = Now.Date
        FillSupplierCombo()
        SupplierCode.Text = "" : SupplierName.Text = ""
        totalarabic.Text = "" : txtNetPurchase.Text = ""
        totalcredit.Text = "" : totaldebit.Text = ""
        txtperoid.Text = ""
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()


    End Sub
    Function GetSupplierCODe(SupName) As String
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Suppliers where SupplierName=N'" & SupName & "' ", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt As New DataTable
        dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then Return dt.Rows(0).Item("SupplierCode") Else Return ""
    End Function
    Sub FillSupplierCombo()

        SupplierName.Items.Clear()
        Dim sql = "select * from Suppliers order by SupplierName"
        Dim Adp = New SqlClient.SqlDataAdapter(sql, SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt As New DataTable
        dt = DS.Tables(0)
        '--------------------------======================
        For I = 0 To dt.Rows.Count - 1
            On Error Resume Next
            SupplierName.Items.Add(dt.Rows(I).Item("SupplierName"))
            ', dt.Rows(I).Item("SuPInternal_ID"), dt.Rows(I).Item("SupplierCode")
        Next
    End Sub
    Private Sub FrmSupplierTrans_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CLR()
    End Sub

    Private Sub SupplierName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles SupplierName.SelectedIndexChanged
        SupplierCode.Text = GetSupplierCODe(SupplierName.Text)
    End Sub

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click
        fillDataGriedView("select * from SupplierTrans  where  SupplierName=N'" & SupplierName.Text & "' and VoucherDate>='" & Format(DateFrom.Value, "yyy/MM/dd") & "' and VoucherDate<='" & Format(DateTo.Value, "yyyy/MM/dd") & "' order by VoucherDate ")
    End Sub

    Private Sub FrmSupplierTrans_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnView_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()

        End If
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Dispose()
    End Sub

    Private Sub txtperoid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtperoid.TextChanged

    End Sub
End Class