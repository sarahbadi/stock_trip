Public Class messagee

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Dispose()
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Label1.ForeColor = Color.Yellow Then
            Label1.ForeColor = Color.Red
        Else
            Label1.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub messagee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Interval = 500 'سرعة التبدل
        'Me.BackColor = Color.Yellow
        Timer2.Enabled = True
        Timer2.Interval = 500 'سرعة التحرك
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class