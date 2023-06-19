Imports System.Data.SqlClient

Public Class Form2
    Inherits System.Windows.Forms.Form
    Dim s As String = "select * from cls"
    Dim ad1 As New SqlDataAdapter(s, cn)
    Dim ds1 As New DataSet
    Public namenat As String
    Dim f As New Form1

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        langarabic()
    End Sub





    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If Me.TextBox2.Text = "" Then
            MsgBox("أدخل وحدة الطلب ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox2.Focus()
            Exit Sub
        End If
        Dim sql As String = "insert into cls (name_type)values(@x2)"
        Dim cm As New SqlCommand(sql, cn)
        'cm.Parameters.AddWithValue("@x1", Me.TextBox1.Text)
        cm.Parameters.AddWithValue("@x2", TextBox2.Text)
        Try
            cm.ExecuteNonQuery()

            MessageBox.Show("تمت الأضافة", "الأضافة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'f.ComboBoxEx1.Refresh()
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        Me.Dispose()
    End Sub
End Class