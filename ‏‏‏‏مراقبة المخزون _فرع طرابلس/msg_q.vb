Imports System.Data.SqlClient
Public Class msg_q

    Inherits System.Windows.Forms.Form
    Dim s As String = "select * from brnch"
    Dim ad1 As New SqlDataAdapter(s, cn)
    Dim ds1 As New DataSet
    Public namenat As String
    Dim f As New Form1

    Private Sub msg_q_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        langarabic()

    End Sub


    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        langarabic()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If Me.ComboBox1.Text = "" Or Me.ComboBox1.Text = "  " Then
            MsgBox("اختار اسم الفرع ", MsgBoxStyle.Information, "إجراء إضافة")
            Me.ComboBox1.Focus()
            Exit Sub
        End If
        Dim sql As String = "insert into brnch (المعرف,admm)values(@x1,@x2)"
        Dim cm As New SqlCommand(sql, cn)
        cm.Parameters.AddWithValue("@x1", "1")
        cm.Parameters.AddWithValue("@x2", Me.ComboBox1.Text)
        Try
            cm.ExecuteNonQuery()

            MessageBox.Show("تم الحفظ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            'Application.Run(FrmLogin)
            Dim k As New FrmLogin
            k.ShowDialog()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        End

    End Sub

   
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
End Class