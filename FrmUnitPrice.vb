Public Class FrmUnitPrice

    Private Sub BtnAdd_Click(sender As System.Object, e As System.EventArgs) Handles BtnAdd.Click


        FrmSalesInvoice.DataGridView1.CurrentRow.Cells(3).Value = DataGridView1.CurrentRow.Cells(2).Value

        FrmSalesInvoice.DataGridView1.CurrentRow.Cells(6).Value = Format(DataGridView1.CurrentRow.Cells(2).Value * FrmSalesInvoice.DataGridView1.CurrentRow.Cells(4).Value, "0.000")

        'Dim x = FrmSalesInvoice.DataGridView1.CurrentRow.Index
        'Dim y = FrmSalesInvoice.DataGridView1.CurrentCell.ColumnIndex
        'FrmSalesInvoice.DataGridView1.CurrentCell = FrmSalesInvoice.DataGridView1.Item(y + 1, x)
        'FrmSalesInvoice.DataGridView1.SelectAll()
        Me.Dispose()

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

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Dispose()
    End Sub
End Class