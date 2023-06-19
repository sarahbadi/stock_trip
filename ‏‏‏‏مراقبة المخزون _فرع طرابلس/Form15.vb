Imports System.Data.SqlClient

Imports System.Globalization
Public Class Form15
    Dim s As String = "select * from stockm"
    Dim ad1 As New SqlDataAdapter(s, cn)
    Dim ds1 As New DataSet


    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click

        If Me.ComboBoxEx1.Text <> "" Then
            Dim adp As New SqlDataAdapter("select no_c,name_snc,cast([Sumqun_r] as nvarchar(50))as Sumqun_r,cast([Sumqun_s] as nvarchar(50))as Sumqun_s,sal_s,name_type,no_ct1,n_type, cast([balance] as nvarchar(50))as balance,REDATEy,cast([qss] as nvarchar(50))as qss from stockm where n_type =N'" + Me.ComboBoxEx1.Text + "' and REDATEy=N'" + Me.TextBoxX1.Text + "'", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("Sumqun_r")) = "int" Then
                    dt.Rows(i).Item("Sumqun_r") = myNo
                Else
                    dt.Rows(i).Item("Sumqun_r") = FormatNumber(CDec(dt.Rows(i).Item(2)), 3)
                End If


                If checkNum(dt.Rows(i).Item("Sumqun_s")) = "int" Then
                    dt.Rows(i).Item("Sumqun_s") = myNo
                Else

                    dt.Rows(i).Item("Sumqun_s") = FormatNumber(CDec(dt.Rows(i).Item(3)), 3)
                End If


                If checkNum(dt.Rows(i).Item("balance")) = "int" Then
                    dt.Rows(i).Item("balance") = myNo
                Else

                    dt.Rows(i).Item("balance") = FormatNumber(CDec(dt.Rows(i).Item(8)), 3)
                End If


                If checkNum(dt.Rows(i).Item("qss")) = "int" Then
                    dt.Rows(i).Item("qss") = myNo
                Else

                    dt.Rows(i).Item("qss") = FormatNumber(CDec(dt.Rows(i).Item(10)), 3)
                End If


            Next

            Dim frm As New Form10
            Dim rpt1 As New CrystalReport8

            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1





            Dim Text5 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text5")
            Text5.Text = branch
            frm.Text = "ØÈÇÚÉ "
            frm.ShowDialog()

        Else : Exit Sub
        End If


    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        Me.Dispose()
    End Sub

    Private Sub Form15_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "select * from ksf order by n_type"
        Dim ap As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        ap.Fill(ds, "ksf")
        Me.ComboBoxEx1.DataSource = ds
        ComboBoxEx1.DisplayMember = "ksf.n_type"
        ComboBoxEx1.ValueMember = "ksf.type_k"

        Me.TextBoxX1.Text = Now.Year
    End Sub

    Private Sub TextBoxX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX1.KeyPress
        secu_num(e)
    End Sub

    Private Sub TextBoxX1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX1.TextChanged

    End Sub
End Class