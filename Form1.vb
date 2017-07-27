Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Me.SkinEngine1.SkinFile = "Skins\office2007.ssk"
        OPENCONNECTION()
        FrmCustomers.Text = ""
        FrmSuppliers.Text = ""
        frmCountries.Text = ""
        FrmCategorizations.Text = ""
        FrmItems.Text = ""
        FrmReceiptOfItems.Text = ""
        FrmReceiptOfItemsBarCode.Text = ""
        FrmDamagedItems.Text = ""
        FrmDamagedItemsBarcode.Text = ""

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FrmCustomers.Show()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        FrmSuppliers.Show()

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        FrmItems.Show()

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        FrmReceiptOfItems.Show()

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Me.TextBox2.Text = IsLaM(Val(Me.TextBox1.Text), "Egypt")
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        FrmDamagedItems.Show()

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        FrmSupplierTrans.Show()

    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        FrmReceiptVoucher.Show()

    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        FrmSalesInvoice.Show()

    End Sub
End Class
