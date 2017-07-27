Public Class SearchUnit_Price
    Function GetDEf_Def_Price(vlan, unitlevel) As Decimal
        GetDEf_Def_Price = 0.0
        Dim str = "select * from ItemNormalPricess where itemCode=N'" & vlan & "'"
        Dim Adp As New SqlClient.SqlDataAdapter(str, SQLconn)
        Dim DS As New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        If dt.Rows.Count = 0 Then Exit Function
        Dim dr = dt.Rows(0)
        Dim arrPrice(6) As String

        Select Case unitlevel
            Case 1
                arrPrice(1) = dr!WholeSaleForFirstUnit
                arrPrice(2) = dr!HalfWholeSaleForFirstUnit
                arrPrice(3) = dr!DistributorForFirstUnit
                arrPrice(4) = dr!ExportForFirstUnit
                arrPrice(5) = dr!RetailForFirstUnit
                arrPrice(6) = dr!EndUserForFirstUnit
            Case 2
                arrPrice(1) = dr!WholeSaleForSecondUnit
                arrPrice(2) = dr!HalfWholeSaleForSecondUnit
                arrPrice(3) = dr!DistributorForSecondUnit
                arrPrice(4) = dr!ExportForSecondUnit
                arrPrice(5) = dr!RetailForSecondUnit
                arrPrice(6) = dr!EndUserForSecondUnit
            Case 3
                arrPrice(1) = dr!WholeSaleForThirdUnit
                arrPrice(2) = dr!HalfWholeSaleForThirdUnit
                arrPrice(3) = dr!DistributorForThirdUnit
                arrPrice(4) = dr!ExportForThirdUnit
                arrPrice(5) = dr!RetailForThirdUnit
                arrPrice(6) = dr!EndUserForThirdUnit

        End Select
        GetDEf_Def_Price = arrPrice(dr!PriceDefault)

    End Function
    Private Sub SearchUnit_Price_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim valn As String = ""

        If FrmSalesInvoice.DataGridView1.CurrentRow.Cells(0).Value = "" Then Exit Sub
        valn = FrmSalesInvoice.DataGridView1.CurrentRow.Cells(0).Value

        Dim str = "select * from Items where itemCode=N'" & valn & "'"
        Dim adp = New SqlClient.SqlDataAdapter(str, SQLconn)
        Dim DS = New DataSet
        adp.Fill(DS)
        Dim dt = DS.Tables(0)
        DataGridView1.Rows.Clear()
        If Trim(dt.Rows(0).Item("FirstUnit")) <> "" Then
            Dim i = DataGridView1.Rows.Add
            DataGridView1.Rows(i).Cells(1).Value = dt.Rows(0).Item("FirstUnit")
            DataGridView1.Rows(i).Cells(3).Value = 1
            DataGridView1.Rows(i).Cells(4).Value = GetDEf_Def_Price(valn, 1)
        End If

        If Trim(dt.Rows(0).Item("SecoundtUnit")) <> "" Then
            Dim i = DataGridView1.Rows.Add
            DataGridView1.Rows(i).Cells(1).Value = dt.Rows(0).Item("SecoundtUnit")
            DataGridView1.Rows(i).Cells(3).Value = 2
            DataGridView1.Rows(i).Cells(4).Value = GetDEf_Def_Price(valn, 2)
        End If

        If Trim(dt.Rows(0).Item("ThirdUnit")) <> "" Then
            Dim i = DataGridView1.Rows.Add
            DataGridView1.Rows(i).Cells(1).Value = dt.Rows(0).Item("ThirdUnit")
            DataGridView1.Rows(i).Cells(3).Value = 3
            DataGridView1.Rows(i).Cells(4).Value = GetDEf_Def_Price(valn, 3)
        End If
        Dim inQ As Integer = 0
        Dim outQ As Integer = 0
        Dim dmgQ As Integer = 0

        '========================================الكمية التى تم توريدها للمخزن
        For i = 0 To DataGridView1.Rows.Count - 1
            str = "select sum(Quantity) from ReceiptOfItemsDetails where ItemCode=N'" & valn & "' and Unit=N'" & DataGridView1.Rows(i).Cells(1).Value & "'"
            Dim cmd As New SqlClient.SqlCommand(str, SQLconn)
            Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(cmd)
            Dim dta As New DataTable("ReceiptOfItemsDetails")
            da.Fill(dta)
            If IsDBNull(dta.Rows(0).Item(0)) = False Then DataGridView1.Rows(i).Cells(2).Value = dta.Rows(0).Item(0) Else DataGridView1.Rows(i).Cells(2).Value = 0
        Next


        '========================================== الكمية التى تم اتلافها ف المخزن

        For i = 0 To DataGridView1.Rows.Count - 1
            str = "select sum(Quantity) from DamageListDetails where ItemCode=N'" & valn & "' and Unit=N'" & DataGridView1.Rows(i).Cells(1).Value & "'"
            Dim cmd As New SqlClient.SqlCommand(str, SQLconn)
            Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(cmd)
            Dim dta As New DataTable("DamageListDetails")
            da.Fill(dta)
            If IsDBNull(dta.Rows(0).Item(0)) = False Then dmgQ = dta.Rows(0).Item(0)
            DataGridView1.Rows(i).Cells(2).Value = DataGridView1.Rows(i).Cells(2).Value - dmgQ

        Next


        '========================================== الكمية التى تم صرفها من المخزن

        For i = 0 To DataGridView1.Rows.Count - 1
            str = "select sum(Quantity) from SalesInvoicesDetails where ItemCode=N'" & valn & "' and Unit=N'" & DataGridView1.Rows(i).Cells(1).Value & "'"
            Dim cmd As New SqlClient.SqlCommand(str, SQLconn)
            Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(cmd)
            Dim dta As New DataTable("SalesInvoicesDetails")
            da.Fill(dta)
            If IsDBNull(dta.Rows(0).Item(0)) = False Then dmgQ = dta.Rows(0).Item(0)
            DataGridView1.Rows(i).Cells(2).Value = DataGridView1.Rows(i).Cells(2).Value - outQ

        Next
    End Sub

    Private Sub DataGridView1_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        For I = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(I).Cells(0).Value = " عرض"
        Next
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = -1 Or DataGridView1.Rows.Count = 0 Then Exit Sub

        Dim colName = CType(sender, DataGridView).Columns(e.ColumnIndex).Name
        If colName = "Column1" Then
            BtnAdd_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As System.Object, e As System.EventArgs) Handles BtnAdd.Click

        FrmSalesInvoice.DataGridView1.CurrentRow.Cells(2).Value = DataGridView1.CurrentRow.Cells(1).Value
        FrmSalesInvoice.DataGridView1.CurrentRow.Cells(3).Value = DataGridView1.CurrentRow.Cells(4).Value
        FrmSalesInvoice.DataGridView1.CurrentRow.Cells(4).Value = 1
        FrmSalesInvoice.DataGridView1.CurrentRow.Cells(6).Value = Format(1 * DataGridView1.CurrentRow.Cells(4).Value, "0.000")
        FrmSalesInvoice.DataGridView1.CurrentRow.Cells(5).Value = "0.000"
        FrmSalesInvoice.DataGridView1.CurrentRow.Cells(9).Value = DataGridView1.CurrentRow.Cells(3).Value
        Me.Dispose()

    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Close()

    End Sub
End Class