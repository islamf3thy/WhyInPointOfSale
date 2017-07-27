Public Class FrmReceiptVoucher
    Sub FillSupplierCombo()

        SupplierName.Items.Clear()
        Dim sql = "select * from Suppliers where status='True' order by SupplierName"
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
    Function GetSupplierCODe(SupName) As String
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Suppliers where status='True' and SupplierName=N'" & SupName & "' ", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt As New DataTable
        dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then Return dt.Rows(0).Item("SupplierCode") Else Return ""
    End Function

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        ErrorProvider1.SetError(Label1, "")
        ErrorProvider1.SetError(Label3, "")
        ErrorProvider1.SetError(Label5, "")

        On Error Resume Next
        For i = 0 To GroupBox1.Controls.Count
            If TypeOf GroupBox1.Controls(i) Is TextBox Then GroupBox1.Controls(i).Text = ""
            If TypeOf GroupBox1.Controls(i) Is DateTimePicker Then GroupBox1.Controls(i).Text = Now.Date.Date

        Next
        SupplierInvoiceCode.Visible = False
        Label2.Visible = False
        FillSupplierCombo()
        SupplierName.Text = ""
        VoucherCode.Text = Format(GET_LAST_RECORD("ReceiptVoucher", "rec_id") + 1, "RMSS000000")

    End Sub

    Private Sub FrmReceiptVoucher_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BtnNew_Click(Nothing, Nothing)
    End Sub

    Private Sub Amount_TextChanged(sender As System.Object, e As System.EventArgs) Handles Amount.TextChanged
        ErrorProvider1.SetError(Label3, "")

        If Val(Amount.Text) > 0 Then

            AmountArabic.Text = IsLaM(Val(Amount.Text), "Egypt")
        Else
            AmountArabic.Text = ""
        End If
    End Sub

    Private Sub Amount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Amount.KeyPress
        If Char.IsControl(e.KeyChar) = False Then
            If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Then
                If Amount.Text.Contains(".") Then
                    If Amount.Text.Split(".")(1).Length < 3 Then
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

    Private Sub Amount_Leave(sender As System.Object, e As System.EventArgs) Handles Amount.Leave
        Amount.Text = Format(Val(Amount.Text), "0.000")
    End Sub

    Private Sub SupplierName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles SupplierName.SelectedIndexChanged
        SupplierCode.Text = GetSupplierCODe(SupplierName.Text)
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click

        If Amount.Text.Trim = "" Then
            ErrorProvider1.SetError(Label3, "يرجى إدخال قيمة السند بطريقة صحيحة")
            Exit Sub
        End If

        Try
            Dim str = "select * from ReceiptVoucher where VoucherCode=N'" & Val(VoucherCode.Text) & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                VoucherCode.Text = Format(GET_LAST_RECORD("ReceiptVoucher", "rec_id") + 1, "RMSS000000")

            Else

                Dim dr = dt.NewRow
                dr!VoucherCode = VoucherCode.Text
                dr!VoucherDate = VoucherDate.Value
                dr!SupplierCode = SupplierCode.Text
                dr!statement = statement.Text
                dr!SupplierName = SupplierName.Text
                dr!Amount = Amount.Text
                dr!AmountArabic = AmountArabic.Text

                dt.Rows.Add(dr)
                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)

                SetSupplierTrans(SupplierName.Text, "سند قبض مالى", VoucherCode.Text, VoucherDate.Text, statement.Text, Amount.Text, 0)

                BtnNew_Click(sender, e)
                MsgBox("تمت عملية الحفظ بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            'End Try
            MsgBox("فشل فى عملية الحفظ ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        End Try
    End Sub

    Private Sub BtnExit_Click(sender As System.Object, e As System.EventArgs) Handles BtnExit.Click
        Me.Dispose()
    End Sub
End Class