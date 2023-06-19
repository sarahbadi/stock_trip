Imports System.Data.SqlClient

Public Class Form_totalyear
    Dim i As Integer
    Dim sum_irct, sum_iiss, sum_return, total_s, sum_talf As New Decimal()
    Private Sub Form_totalyear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ds As New DataSet()
        ds.Clear()
        Dim s As String = " SELECT no_c AS [رقم الصنف], MAX(YEAR(date_i)) AS [السنه], qun_tot AS [كمية المتبقيه], sal_s AS [السعر] FROM     dbo.acthion_tran GROUP BY no_c, date_i, qun_tot, sal_s HAVING (qun_tot <> 0)AND (no_c = N'" + TextBox1.Text + "')"
        'Dim s As String = "SELECT no_c , MAX(YEAR(date_i)), date_i, qun_tot , sal_s  FROM acthion_tran GROUP BY no_c, date_i, qun_tot, sal_s HAVING (qun_tot <> 0) AND (no_c = N'" + TextBox1.Text + "')"
        'Dim s As String = "SELECT n_rs,date_s,no_c,quntity,price,tr_type,name_s,q_div,count1,Y_S FROM sub_it where no_c ='" + TextBoxX1.Text + "' and Y_S='" + Label6.Text + "'"
        'Dim s As String = " SELECT * from acthion_tran WHERE no_c ='" + TextBoxX1.Text + "' and year([date_i])< '" + TextBoxX2.Text + "' and [qun_tot]>0"

        Dim ad As New SqlDataAdapter(s, cn)
        ds.Clear()
        ad.Fill(ds, "acthion_tran")
        Me.DataGridView1.DataSource = ds
        Me.DataGridView1.DataMember = "acthion_tran"
        Me.DataGridView1.Refresh()
        cn.Close()

        '==========================================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sum_k As New Decimal()
        Dim sql As String = " SELECT * from acthion_tran WHERE no_c ='" + TextBox1.Text + "' and [qun_tot]>0"
        Dim ad1 As New SqlDataAdapter(sql, cn)
        Dim ds1 As New DataSet()
        Dim TD1 As DataTable
        Dim DROW1 As DataRow
        Dim y As Decimal
        y = 0.0
        sum_k = 0.0
        ad1.Fill(ds1, sql)
        TD1 = ds1.Tables(sql)

        For i = 0 To TD1.Rows.Count - 1
            DROW1 = TD1.Rows(i)
            If DROW1("no_c") = (TextBox1.Text) Then

                y = Val(DROW1("qun_tot"))
                sum_k = sum_k + y
            End If
        Next
        TextBox2.Text = sum_k
        '==========================================


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        TextBox2.Clear()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        '1111111111
        '(qun_tot <> 0)AND (no_c = N'" + TextBox1.Text + "')"

        Dim adp As New SqlDataAdapter("select no_c,maxdate,cast([qun_tot] as nvarchar(50)) as qun_tot,sal_s from View_stock where (qun_tot <> 0) AND[no_c]='" + TextBox1.Text + "'", cn)

        Dim dt As New DataTable
        adp.Fill(dt)

        For i As Integer = 0 To dt.Rows.Count - 1
            If checkNum(dt.Rows(i).Item("qun_tot")) = "int" Then
                dt.Rows(i).Item("qun_tot") = myNo
            Else
                dt.Rows(i).Item("qun_tot") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
            End If


        Next

        Dim frm As New Form19
        Dim rpt1 As New CrystalReport3
        rpt1.SetDataSource(dt)
        frm.CrystalReportViewer1.ReportSource = rpt1
        'Dim Text15 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text15")
        ' ''Text15.Text = branch
        frm.ShowDialog()

        frm.Text = "طباعة بطاقة الصنف"

        '11111111111111111111



    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class