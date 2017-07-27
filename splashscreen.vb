Public Class splashscreen


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

        Form2.Show()
        Me.Close()
    End Sub

   
    Private Sub splashscreen_Leave(sender As System.Object, e As System.EventArgs) Handles MyBase.Leave
        'If My.Settings.sern = "" And My.Settings.datan = "" And My.Settings.un = "" And My.Settings.pn = "" And My.Settings.tn = "" Then ConnectionMode.ShowDialog()

        'If My.Settings.sern = "" Then
        '    ConnectionMode.ShowDialog()
        'Else
        '    ConnectionMode.Hide()
        'End If
    End Sub
End Class