Public Class UpdateSys

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = 25
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        ProgressBar1.Value = 50
        Timer1.Stop()
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        ProgressBar1.Value = 75
        Timer2.Stop()
    End Sub

    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        ProgressBar1.Value = 100
        Timer3.Stop()
    End Sub

    Private Sub Timer5_Tick(sender As System.Object, e As System.EventArgs) Handles Timer5.Tick
        Label1.Text = ProgressBar1.Value%
    End Sub

    Private Sub Timer6_Tick(sender As System.Object, e As System.EventArgs) Handles Timer6.Tick
        Timer6.Stop()
        Try
            'استبدل الرقم المحدد بالاسفل برقم نسخة برنامجك مع مراعاة ترك فراغ بمقدار كلمة بعد وضع رقم النسخة كما هو موضح
            If Not TextBox1.Text = "1.0 " Then
                Dim result As Integer = MessageBox.Show("انت تستخدم نسخة قديمة للبرنامج هل ترغب بتحديث النسخة ؟", "اشعار", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    My.Computer.Network.DownloadFile(TextBox2.Text, ".\Setup2.exe")
                    MsgBox("تم التحديث بنجاح!", MsgBoxStyle.Information)
                    Me.Hide()
                    Process.Start(".\Setup2.exe")
                    End

                ElseIf result = DialogResult.No Then
                End If
            Else
                Dim result2 As Integer = MessageBox.Show("لايوجد تحديثات جديدة للنظام", "اشعار", MessageBoxButtons.OK)
                If result2 = DialogResult.OK Then
                    Me.Close()
                End If

            End If
        Catch ex As Exception
            MsgBox("حدث خطأ", MsgBoxStyle.Exclamation)
        End Try
        Me.Close()
    End Sub

    Private Sub UpdateSys_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("http://whyin4soft.yoo7.com/h1-page")
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As System.Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Try
            TextBox1.Text = WebBrowser1.Document.GetElementById("vi").OuterText
            TextBox2.Text = WebBrowser1.Document.GetElementById("linkDownload").OuterText
            Timer1.Start()
        Catch ex As Exception

        End Try

    End Sub
End Class