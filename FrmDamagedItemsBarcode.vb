Public Class FrmDamagedItemsBarcode
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
    Private Sub FrmDamagedItemsBarcode_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Dispose()
        If e.KeyCode = Keys.Enter Then BtnAdd_Click(Nothing, Nothing)
    End Sub
    Private Sub FrmDamagedItemsBarcode_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TxtBarCode.Focus()
        TxtBarCode_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub TxtBarCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBarCode.TextChanged
        If TxtBarCode.Text.Length = 0 Then BtnAdd.Enabled = False Else BtnAdd.Enabled = True
        'كتابة اسم المنتج على ملصق الباركود
        PicBarCode.BackgroundImage = Code128(TxtBarCode.Text, "A")
       
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Dispose()

    End Sub

    Private Sub BtnAdd_Click(sender As System.Object, e As System.EventArgs) Handles BtnAdd.Click
        If Trim(TxtBarCode.Text) = "" Then Exit Sub
        For i = 0 To FrmDamagedItems.DataGridView1.Rows.Count - 1
            If FrmDamagedItems.DataGridView1.Rows(i).Cells(5).Value = TxtBarCode.Text.Trim Then
                FrmDamagedItems.DataGridView1.Rows(i).Cells(3).Value += 1
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

        Dim adp As New SqlClient.SqlDataAdapter(Sql, SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)

        If dt.Rows.Count > 0 Then
            FrmDamagedItems.DataGridView1.Rows.Add()
            Dim RowIndex = FrmDamagedItems.DataGridView1.Rows.Count - 1
            FrmDamagedItems.DataGridView1.Rows(RowIndex).Cells(0).Value = dt.Rows(0).Item("itemCode")
            FrmDamagedItems.DataGridView1.Rows(RowIndex).Cells(1).Value = dt.Rows(0).Item("itemName")
            FrmDamagedItems.DataGridView1.Rows(RowIndex).Cells(5).Value = TxtBarCode.Text
            FrmDamagedItems.DataGridView1.Rows(RowIndex).Cells(3).Value = 1


            Dim DGVCC As DataGridViewComboBoxCell
            DGVCC = FrmDamagedItems.DataGridView1.Rows(RowIndex).Cells(2)

            Select Case barc
                Case 1
                    DGVCC.Items.Add(dt.Rows(0).Item("FirstUnit"))
                    DGVCC.Value = dt.Rows(0).Item("FirstUnit")
                Case 2
                    DGVCC.Items.Add(dt.Rows(0).Item("SecoundtUnit"))
                    DGVCC.Value = dt.Rows(0).Item("SecoundtUnit")
                Case 3
                    DGVCC.Items.Add(dt.Rows(0).Item("ThirdUnit"))
                    DGVCC.Value = dt.Rows(0).Item("ThirdUnit")
            End Select


            FrmDamagedItems.DataGridView1.ClearSelection()
            FrmDamagedItems.DataGridView1.Rows(RowIndex).Selected = True
EOS:
        End If
        TxtBarCode.Text = ""
        TxtBarCode.Focus()
        TxtBarCode_TextChanged(Nothing, Nothing)
    End Sub



End Class