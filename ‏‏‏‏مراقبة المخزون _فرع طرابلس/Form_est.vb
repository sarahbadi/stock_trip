
Imports System.Data
Imports System.Data.SqlClient

Public Class Form_est
    Dim date_1 As Date
    Dim date_2 As Date

    Dim sqlksf As String = "select * from ksf order by n_type"
    Dim apksf As New SqlDataAdapter(sqlksf, cn)
    Dim dsksf As New DataSet
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As New DataSet()
        ds.Clear()
        '---------------------------
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


     
        date_1 = Me.DateTimePicker1.Value.Date
        date_2 = Me.DateTimePicker2.Value.Date

        'Dim s As String = "select [n_rs],[no_c],[name_snc],[n_type],[quntity],[price],[tr_type],[name_r],[date_i] from View_est where((date_i between ('" & date_1.ToString("yyyy/MM/dd") & "') and ('" & date_2.ToString("yyyy/MM/dd") & "')))and n_type ='" + Me.ComboBox1.Text + "'"
        'Dim s As String = "select [no_i] as[رقم المستند],[no_c]as[رقم الصنف],[name_snc]as[اسم المستند],[n_type]as[نوع الكشف],[qun_r]as[الكمية المستلمة],[sal_s]as[سعر الوحدة],[name_r]as[اسم الجهة الموردة],[date_i]as[تاريخ الاستلام] from View_est where((date_i between ('" & date_1.ToString("yyyy/MM/dd") & "') and ('" & date_2.ToString("yyyy/MM/dd") & "')))"
        Dim s As String = "select [no_i] as[رقم المستند],[no_c]as[رقم الصنف],[name_snc]as[اسم المستند],[n_type]as[نوع الكشف],[qun_r]as[الكمية المستلمة],[sal_s]as[سعر الوحدة],[name_r]as[اسم الجهة الموردة],[date_i]as[تاريخ الاستلام] from R_osta where((convert(varchar(10),date_i,111)between ('" & date_1.ToString("yyyy/MM/dd") & "') and ('" & date_2.ToString("yyyy/MM/dd") & "')))"
        Dim ad As New SqlDataAdapter(s, cn)
        ds.Clear()
        ad.Fill(ds, "R_osta")
        Me.DataGridViewX3.DataSource = ds
        Me.DataGridViewX3.DataMember = "R_osta"
        Me.DataGridViewX3.Refresh()

        'Me.TextBox1.Text = Me.DataGridViewX3.RowCount
        cn.Close()
    End Sub

    Private Sub Form_est_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        apksf.Fill(dsksf, "ksf")
        Me.ComboBox1.DataSource = dsksf
        ComboBox1.DisplayMember = "ksf.n_type"
        ComboBox1.ValueMember = "ksf.type_k"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim adp As New SqlDataAdapter("select [no_i],[no_c],[name_snc],[n_type],cast([qun_r] as nvarchar(50))as qun_r,[sal_s],[name_r],[date_i],gima from R_osta where((convert(varchar(10),date_i,111)between('" & date_1.ToString("yyyy/MM/dd") & "') and ('" & date_2.ToString("yyyy/MM/dd") & "')))", cn)
        Dim dt As New DataTable
        adp.Fill(dt)

        For i As Integer = 0 To dt.Rows.Count - 1
            If checkNum(dt.Rows(i).Item("qun_r")) = "int" Then
                dt.Rows(i).Item("qun_r") = myNo
            Else

                dt.Rows(i).Item("qun_r") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
            End If

        Next

        Dim frm As New Form10
        Dim rpt1 As New CrystalRepest
        Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

        rpt1.SetDataSource(dt)
        frm.CrystalReportViewer1.ReportSource = rpt1

        Dim Text21 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text21")
        Dim Text22 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text22")

        Text21.Text = Me.DateTimePicker1.Text
        Text22.Text = Me.DateTimePicker2.Text
        Text21.Color = Color.Red
        Text21.ApplyFont(New Font("Times New Roman", 14, FontStyle.Bold))
        Text22.Color = Color.Red
        Text22.ApplyFont(New Font("Times New Roman", 14, FontStyle.Bold))

        Dim Text18 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text18")
        Text18.Text = branch

        frm.Text = "طباعة "
        frm.ShowDialog()


        '===============================================




    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        Dim adp As New SqlDataAdapter("select [no_i],[no_c],[name_snc],[n_type],cast([qun_r] as nvarchar(50))as qun_r,[sal_s],[name_r],[date_i],gima from R_osta where((convert(varchar(10),date_i,111)between('" & date_1.ToString("yyyy/MM/dd") & "') and ('" & date_2.ToString("yyyy/MM/dd") & "')))", cn)
        Dim dt As New DataTable
        adp.Fill(dt)

        For i As Integer = 0 To dt.Rows.Count - 1
            If checkNum(dt.Rows(i).Item("qun_r")) = "int" Then
                dt.Rows(i).Item("qun_r") = myNo
            Else

                dt.Rows(i).Item("qun_r") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
            End If

        Next

        Dim frm As New Form10
        Dim rpt1 As New CrystalRepest
        Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

        rpt1.SetDataSource(dt)
        frm.CrystalReportViewer1.ReportSource = rpt1

        Dim Text21 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text21")
        Dim Text22 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text22")

        Text21.Text = Me.DateTimePicker1.Text
        Text22.Text = Me.DateTimePicker2.Text
        Text21.Color = Color.Red
        Text21.ApplyFont(New Font("Times New Roman", 14, FontStyle.Bold))
        Text22.Color = Color.Red
        Text22.ApplyFont(New Font("Times New Roman", 14, FontStyle.Bold))

        Dim Text18 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text18")
        Text18.Text = branch

        frm.Text = "طباعة "
        frm.ShowDialog()


        '===============================================




    End Sub
End Class