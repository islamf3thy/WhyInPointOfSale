
Public Class Form2



    Private Sub الموردينToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles W4.Click
        FrmSuppliers.Show()
    End Sub

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        
        If My.Settings.sern = "" And My.Settings.datan = "" And My.Settings.un = "" And My.Settings.pn = "" And My.Settings.tn = "" Then ConnectionMode.ShowDialog()

        If My.Settings.sern = "" Then
            ConnectionMode.ShowDialog()
        Else
            ConnectionMode.Hide()
        End If

        '================================================================================================================================

        OPENCONNECTION()

        'Loginsystem.ShowDialog()

        'If My.Settings.ComName = "" Then
        '    Dim result As Integer = MessageBox.Show("يرجى إدخال اسم المؤسسة ", "اشعار", MessageBoxButtons.OKCancel)
        '    If result = DialogResult.OK Then
        '        CompanyNameSYS.ShowDialog()
        '    ElseIf result = DialogResult.Cancel Then
        '    End If
        'End If
        'FrmCustomers.Text = My.Settings.ComName
        'FrmSuppliers.Text = My.Settings.ComName
        'frmCountries.Text = My.Settings.ComName
        'FrmCategorizations.Text = My.Settings.ComName
        'FrmItems.Text = My.Settings.ComName
        'FrmReceiptOfItems.Text = My.Settings.ComName
        'FrmReceiptOfItemsBarCode.Text = My.Settings.ComName
        'FrmDamagedItems.Text = My.Settings.ComName
        'FrmDamagedItemsBarcode.Text = My.Settings.ComName
        'FrmReceiptVoucher.Text = My.Settings.ComName
        'FrmSalesInvoice.Text = My.Settings.ComName
        'FrmSalesInvoiceBarCode.Text = My.Settings.ComName
        'FrmSupplierTrans.Text = My.Settings.ComName

        '===========================================



    End Sub

    Private Sub TabStrip1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub كشفتفصيلىToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles W5.Click
        FrmSupplierTrans.Show()
    End Sub



    Private Sub العملاءToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles W13.Click
        FrmCustomers.Show()
    End Sub

    Private Sub المبيعاتToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        FrmSalesInvoice.Show()
    End Sub

    Private Sub الاصنافToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles W1.Click
        FrmItems.Show()
    End Sub

    Private Sub التوريدToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles W2.Click
        FrmReceiptOfItems.Show()
    End Sub

    Private Sub إتلافالاصنافToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles W3.Click
        FrmDamagedItems.Show()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        FrmReceiptOfItems.Show()
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        FrmSalesInvoice.Show()
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        FrmSupplierTrans.Show()
    End Sub

    Private Sub معلوماتالمؤسسةToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles معلوماتالمؤسسةToolStripMenuItem.Click
        CompanyNameSYS.Show()

    End Sub

    Private Sub النسخالاحتياطىToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        BackUpAndRestore.ShowDialog()

    End Sub

    Private Sub التقاريرToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles التقاريرToolStripMenuItem.Click
        'MsgBox("نأسف هذا الاختيار غير متوافر ف النسخة المجانية يرجى شراء النسخة الاحترافية للاستفسار : 01022606162", MsgBoxStyle.Exclamation, "شركة واى إن للبرمجيات")

    End Sub

    Private Sub إعداداتالنظامToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles W9ww.Click

    End Sub

    Private Sub خروجمنالنظامToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles خروجمنالنظامToolStripMenuItem.Click
        SQLconn.Dispose()
        SQLconn.Close()
        End
    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        FrmPOS.ShowDialog()

    End Sub

    Private Sub سنداتالدفعToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles W6.Click
        FrmFinancialSupport.ShowDialog()

    End Sub

    Private Sub فاتورةمبيعاتToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        FrmSalesInvoice.ShowDialog()
    End Sub

    Private Sub نقطةالبيعاليومىToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        FrmPOS.ShowDialog()
    End Sub

    Private Sub W8_Click(sender As System.Object, e As System.EventArgs) Handles W8.Click
        FrmPermissions.ShowDialog()

    End Sub

    Private Sub إعادةـشغيلالنظامToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles إعادةـشغيلالنظامToolStripMenuItem.Click
        Loginsystem.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ToolTime.Text = Format(Now, "hh:mm:ss tt")
        toolDate.Text = Now.Date
    End Sub

    Private Sub W16_Click(sender As System.Object, e As System.EventArgs) Handles W16.Click
        BackUpAndRestore.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
       
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub إعدادالاتصالبالسيرفرToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles إعدادالاتصالبالسيرفرToolStripMenuItem.Click
        ConnectionMode.ShowDialog()
    End Sub

    Private Sub بحثعنتحديثToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles بحثعنتحديثToolStripMenuItem.Click
        UpdateSys.ShowDialog()
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        'SQLconn.Dispose()
        'SQLconn.Close()
        End
    End Sub

    Private Sub W7_Click(sender As System.Object, e As System.EventArgs) Handles W7.Click
        FrmReceiptVoucher.ShowDialog()
    End Sub

    Private Sub W11_Click(sender As System.Object, e As System.EventArgs) Handles W11.Click
        FrmReturnBill.ShowDialog()
    End Sub

    Private Sub W14_Click(sender As System.Object, e As System.EventArgs) Handles W14.Click
        FrmCustomersTrans.ShowDialog()
    End Sub

    Private Sub W10_Click(sender As System.Object, e As System.EventArgs) Handles W10.Click
        FrmSalesInvoice.ShowDialog()
    End Sub

    Private Sub W12_Click(sender As System.Object, e As System.EventArgs) Handles W12.Click
        FrmPOS.ShowDialog()
    End Sub

    Private Sub W15_Click(sender As System.Object, e As System.EventArgs) Handles W15.Click
        MsgBox("نأسف هذا الاختيار غير متوافر ف النسخة المجانية يرجى شراء النسخة الاحترافية للاستفسار : 01022606162", MsgBoxStyle.Exclamation, "شركة واى إن للبرمجيات")
    End Sub

    Private Sub TileItem9_ItemClick(sender As System.Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem9.ItemClick
        FrmPOS.ShowDialog()
    End Sub

   
End Class