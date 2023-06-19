
Imports System.Data
Imports System.Data.SqlClient


Public Class F_tgrer

    Dim sj_s As String = "select * from j_s"
    Dim adaj_s As New SqlDataAdapter(sj_s, cn)
    Dim dsaj_s As New DataSet()


    Dim sqlksf As String = "select * from ksf order by n_type"
    Dim apksf As New SqlDataAdapter(sqlksf, cn)
    Dim dsksf As New DataSet


    Dim sa As String = "select * from tgrer"
    Dim adsa As New SqlDataAdapter(sa, cn)
    Dim dssa As New DataSet()



    Dim saB_DATE As String = "select * from  B_DATE"
    Dim adB_DATE As New SqlDataAdapter(saB_DATE, cn)
    Dim dsB_DATE As New DataSet()

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Dim ds As New DataSet()
        ds.Clear()
        Me.TextBox1.Text = 0
        Me.TextBox2.Text = 0
        DataGridViewX1.DataMember = ""
        DataGridViewX1.DataSource = Nothing
        DataGridViewX3.DataMember = ""
        DataGridViewX3.DataSource = Nothing
        ComboBoxEx3.SelectedIndex = -1
        ComboBoxEx4.SelectedIndex = -1
        '====================================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim saa As String = "delete from tgrer"
        Dim cm11 As New SqlCommand(saa, cn)
        cm11.ExecuteNonQuery()
        '---------------------------
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        
        Dim date_1 As Date
        Dim date_2 As Date
        date_1 = Me.DateTimePicker1.Value.Date
        date_2 = Me.DateTimePicker2.Value.Date
        'Dim s As String = "select * from xxxxx where date_s>= '" & date_1 & "' and date_s>= '" & date_1 & "'"
        'Dim s As String = "select no_c as[رقم الصنف],name_snc as[اســـــــــم الصنف],n_type as[اسم الكشف],name_s as[الجهةالمصروف لها],tot as[الكمية],sal_s as[سعر الوحده],date_s as[تاريخ الصرف] ,no_ct1 as[رقم الصنـف للترتيب] from xxxxx  where ((date_s between ('" & date_1 & "') and ('" & date_2 & "')))"


        Dim s As String = "select no_c as[رقم الصنف],name_snc as[اســـــــــم الصنف],n_type as[اسم الكشف],name_s as[الجهةالمصروف لها],tot as[الكمية],sal_s as[سعر الوحده],date_s as[تاريخ الصرف] ,no_ct1 as[رقم الصنـف للترتيب]from xxxxx where((convert(varchar(10),date_s,111) between ('" & date_1.ToString("yyyy/MM/dd") & "') and ('" & date_2.ToString("yyyy/MM/dd") & "')))"
        Dim ad As New SqlDataAdapter(s, cn)
        ds.Clear()
        ad.Fill(ds, "xxxxx")
        Me.DataGridViewX3.DataSource = ds
        Me.DataGridViewX3.DataMember = "xxxxx"
        Me.DataGridViewX3.Refresh()

        Me.TextBox1.Text = Me.DataGridViewX3.RowCount
        cn.Close()
        '========================================
        'Dim da As New SQLiteDataAdapter("SELECT col1,col2 FROM `table1` ", con)
        'cn.Open()
        'da.Fill(ds, "table1")

        'Dim row As DataRow
        '' ثم رجعت ونقلتها إلى قاعدة أخرى بهذه الطريقة



        'Dim sql3 As String = "insert into tgrer(no_c,name_snc,n_type,name_s,tot,sal_s,date_s,no_ct1)values(@no_c,@name_snc,@n_type,@name_s,@tot,@sal_s,@date_s,@no_ct1)"
        'Dim cmd As New SqlCommand(sql3, cn)
        'For Each row In ds.Tables("tgrer").Rows



        '    cmd.Parameters.AddWithValue("@no_c", row("no_c"))
        '    cmd.Parameters.AddWithValue("@name_snc", row("name_snc"))
        '    cmd.Parameters.AddWithValue("@n_type", row("n_type"))
        '    cmd.Parameters.AddWithValue("@name_s", row("name_s"))
        '    cmd.Parameters.AddWithValue("@tot", row("tot"))
        '    cmd.Parameters.AddWithValue("@sal_s", row("sal_s"))
        '    cmd.Parameters.AddWithValue("@date_s", row("date_s"))
        '    cmd.Parameters.AddWithValue("@no_ct1", row("no_ct1"))
        '    cmd.Parameters.AddWithValue("@name_snc", row("name_snc"))




        '    cmd.ExecuteNonQuery()
        'Next
        cn.Close()
        ButtonX7_Click(sender, e)
        Me.GroupPanel1.Enabled = True
        Me.ButtonX4.Enabled = True
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click


        If Me.ComboBoxEx4.Text <> "" Then

        Else
            Exit Sub
        End If


        '----------------------------------------------
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim sa As String = "SELECT no_c as[رقم الصنف],name_snc as[اســـــــــم الصنف],n_type as[اسم الكشف],name_s as[الجهةالمصروف لها],Sumtot as[الكمية],sal_s as[سعر الوحده] from tg  where name_s =N'" + Me.ComboBoxEx4.Text + "'"

        Dim daa As New SqlDataAdapter(sa, cn)
        Dim dsa As New DataSet()
        dsa.Clear()
        daa.Fill(dsa, "tg")

        Me.DataGridViewX1.DataSource = dsa
        DataGridViewX1.DataMember = "tg"
        DataGridViewX1.Refresh()
        cn.Close()
        Me.TextBox2.Text = Me.DataGridViewX1.RowCount
        Me.ButtonX5.Visible = True
    End Sub

    Private Sub F_tgrer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim saa As String = "delete from tgrer"
        Dim cm11 As New SqlCommand(saa, cn)
        cm11.ExecuteNonQuery()
        cn.Close()
    End Sub




    Private Sub F_tgrer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Button1.Visible = False
        Me.GroupPanel1.Enabled = False
      
        adaj_s.Fill(dsaj_s, "j_s")
        ComboBoxEx4.DataSource = dsaj_s
        ComboBoxEx4.DisplayMember = "j_s.name_s"
        ComboBoxEx4.ValueMember = "n_s"


        apksf.Fill(dsksf, "ksf")
        Me.ComboBoxEx3.DataSource = dsksf
        ComboBoxEx3.DisplayMember = "ksf.n_type"
        ComboBoxEx3.ValueMember = "ksf.type_k"
        '=======================
        '====================================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim saa As String = "delete from tgrer"
        Dim cm11 As New SqlCommand(saa, cn)
        cm11.ExecuteNonQuery()
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click

        If RadioButton1.Checked And CheckBoxX1.Checked = True And CheckBoxX2.Checked = True Then

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim sa As String = "SELECT no_c as[رقم الصنف],name_snc as[اســـــــــم الصنف],n_type as[اسم الكشف],name_s as[الجهةالمصروف لها],Sumtot as[الكمية],sal_s as[سعر الوحده] from tg  where name_s =N'" + Me.ComboBoxEx4.Text + "'and n_type =N'" + Me.ComboBoxEx3.Text + "'"
            Dim daa As New SqlDataAdapter(sa, cn)
            Dim dsa As New DataSet()
            dsa.Clear()
            daa.Fill(dsa, "tg")

            Me.DataGridViewX1.DataSource = dsa
            DataGridViewX1.DataMember = "tg"
            DataGridViewX1.Refresh()
            cn.Close()
            Me.TextBox2.Text = Me.DataGridViewX1.RowCount
            Me.Button2.Visible = True
            Me.Button1.Visible = True
            Me.ButtonX5.Visible = False
            Me.ButtonX9.Visible = False

        ElseIf RadioButton1.Checked And CheckBoxX1.Checked = True Then

            ButtonX2_Click(sender, e)
            Me.ButtonX9.Visible = False
            Me.Button2.Visible = False
            Me.Button1.Visible = False

        ElseIf RadioButton1.Checked And CheckBoxX2.Checked = True Then

            ButtonX8_Click(sender, e)
            Me.ButtonX5.Visible = False
            Me.Button2.Visible = False
            Me.Button1.Visible = False
        End If

        '----------------------------------------------

    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        If RadioButton1.Checked = True Then

            '==================================================
            Dim adp As New SqlDataAdapter("select no_c,name_snc, n_type,cast([Stot] as nvarchar(50))as Stot, sal_s, no_ct1, siDATE, Stott from tgdd ", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("Stot")) = "int" Then
                    dt.Rows(i).Item("Stot") = myNo
                Else
                    dt.Rows(i).Item("Stot") = FormatNumber(CDec(dt.Rows(i).Item(3)), 3)
                End If

               

            Next

            Dim frm As New Form10
            Dim rpt1 As New CrystalReport15
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

            Dim Text23 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text23")
            Text23.Text = branch


            frm.ShowDialog()



        Else : Exit Sub
        End If



            '====================
          



    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click



        Dim adp As New SqlDataAdapter("SELECT no_c,name_snc,cast([Stot] as nvarchar(50)) as Stot,n_type,name_s,sal_s,no_ct1,stott from tg11 where name_s =N'" + Me.ComboBoxEx4.Text + "'", cn)
        Dim dt As New DataTable
        adp.Fill(dt)

        For i As Integer = 0 To dt.Rows.Count - 1
            If checkNum(dt.Rows(i).Item("Stot")) = "int" Then
                dt.Rows(i).Item("Stot") = myNo
            Else
                dt.Rows(i).Item("Stot") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
            End If

        Next

        Dim frm As New Form10
        Dim rpt1 As New CrystalReport18
        rpt1.SetDataSource(dt)
        frm.CrystalReportViewer1.ReportSource = rpt1
        Dim Text8 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text8")
        Dim Text7 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text7")

        Text7.Text = DateTimePicker1.Text
        Text8.Text = DateTimePicker2.Text
        Text7.Color = Color.Red
        Text7.ApplyFont(New Font("Times New Roman", 14, FontStyle.Bold))
        Text8.Color = Color.Red
        Text8.ApplyFont(New Font("Times New Roman", 14, FontStyle.Bold))
        frm.CrystalReportViewer1.ReportSource = rpt1
        Dim Text20 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text20")
        Text20.Text = branch
        Dim Text36 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section5.ReportObjects("Text36")
       
        If branch = "الادارة العامة" Then

            Text36.Text = "رئيس قسم المخازن والتكاليف"
        Else
            Text36.Text = "رئيس وحدة المخازن والتكاليف"

        End If


        frm.ShowDialog()
        '===================================================


    End Sub


    Private Sub ButtonX7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX7.Click


        Try

            
            For i As Integer = 0 To DataGridViewX3.RowCount - 1
                Dim sql As String = "insert into tgrer(no_c,name_snc,n_type,name_s,tot,sal_s,date_s,no_ct1)values(@no_c,@name_snc,@n_type,@name_s,@tot,@sal_s,@date_s,@no_ct1)"
                Dim cm As New SqlCommand(sql, cn)
                cm.Parameters.AddWithValue("@no_c", DataGridViewX3.Rows(i).Cells(0).Value).DbType = DbType.String
                cm.Parameters.AddWithValue("@name_snc", DataGridViewX3.Rows(i).Cells(1).Value).DbType = DbType.String
                cm.Parameters.AddWithValue("@n_type", DataGridViewX3.Rows(i).Cells(2).Value).DbType = DbType.String
                cm.Parameters.AddWithValue("@name_s", DataGridViewX3.Rows(i).Cells(3).Value).DbType = DbType.String
                cm.Parameters.AddWithValue("@tot", DataGridViewX3.Rows(i).Cells(4).Value).DbType = DbType.Decimal
                cm.Parameters.AddWithValue("@sal_s", DataGridViewX3.Rows(i).Cells(5).Value).DbType = DbType.Double
                cm.Parameters.AddWithValue("@date_s", DataGridViewX3.Rows(i).Cells(6).Value).DbType = DbType.Date
                cm.Parameters.AddWithValue("@no_ct1", DataGridViewX3.Rows(i).Cells(7).Value).DbType = DbType.String
                cn.Open()
                cm.ExecuteNonQuery()
                cn.Close()
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

  

    Private Sub ButtonX8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX8.Click

        If Me.ComboBoxEx3.Text <> "" Then

        Else
            Exit Sub
        End If

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim sa As String = "SELECT no_c as[رقم الصنف],name_snc as[اســـــــــم الصنف],n_type as[اسم الكشف],name_s as[الجهةالمصروف لها],Sumtot as[الكمية],sal_s as[سعر الوحده] from tg  where n_type =N'" + Me.ComboBoxEx3.Text + "'"

        Dim daa As New SqlDataAdapter(sa, cn)
        Dim dsa As New DataSet()
        dsa.Clear()
        daa.Fill(dsa, "tg")

        Me.DataGridViewX1.DataSource = dsa
        DataGridViewX1.DataMember = "tg"
        DataGridViewX1.Refresh()
        cn.Close()
        Me.TextBox2.Text = Me.DataGridViewX1.RowCount
        Me.ButtonX9.Visible = True
    End Sub

    Private Sub ButtonX9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX9.Click

        Dim adp As New SqlDataAdapter(" select no_c,name_snc, n_type,name_s, cast([Sumtot] as nvarchar(50)) as Sumtot,sal_s, no_ct1,gima from tgk where n_type =N'" + Me.ComboBoxEx3.Text + "'", cn)
        Dim dt As New DataTable
        adp.Fill(dt)

        For i As Integer = 0 To dt.Rows.Count - 1
            If checkNum(dt.Rows(i).Item("Sumtot")) = "int" Then
                dt.Rows(i).Item("Sumtot") = myNo
            Else
                dt.Rows(i).Item("Sumtot") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
            End If



        Next

        Dim frm As New Form10
        Dim rpt1 As New CrystalReport25
        rpt1.SetDataSource(dt)
        frm.CrystalReportViewer1.ReportSource = rpt1
        Dim Text18 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text18")
        Dim Text8 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text8")

        Text8.Text = Me.DateTimePicker1.Text
        Text18.Text = Me.DateTimePicker2.Text
        Text8.Color = Color.Red
        Text8.ApplyFont(New Font("Times New Roman", 14, FontStyle.Bold))
        Text18.Color = Color.Red
        Text18.ApplyFont(New Font("Times New Roman", 14, FontStyle.Bold))
        Dim Text20 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text20")
        Text20.Text = branch


        frm.ShowDialog()

        '==========================





    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If RadioButton1.Checked And CheckBoxX1.Checked = True And CheckBoxX2.Checked = True Then

            Dim adp As New SqlDataAdapter("SELECT no_c,name_snc,cast([Stot] as nvarchar(50)) as Stot,n_type,name_s,sal_s,no_ct1,stott FROM  tg11 WHERE  name_s =N'" + Me.ComboBoxEx4.Text + "'and n_type=N'" + ComboBoxEx3.Text + "'", cn)

            Dim dt As New DataTable

            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1

                If checkNum(dt.Rows(i).Item("Stot")) = "int" Then
                    dt.Rows(i).Item("Stot") = myNo
                Else
                    dt.Rows(i).Item("Stot") = FormatNumber(CDec(dt.Rows(i).Item(2)), 3)
                End If


            Next

            Dim frm As New Form10
            Dim rpt1 As New CopCrystalReport
            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1

            Dim Text18 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text18")
            Dim Text8 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text8")

            Text8.Text = Me.DateTimePicker1.Text
            Text18.Text = Me.DateTimePicker2.Text
            Text8.Color = Color.Red
            Text8.ApplyFont(New Font("Times New Roman", 14, FontStyle.Bold))
            Text18.Color = Color.Red
            Text18.ApplyFont(New Font("Times New Roman", 14, FontStyle.Bold))


            Dim Text21 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text21")
            Text21.Text = branch
            frm.ShowDialog()

            '====================

        Else

            MsgBox("اختار الجهة والكشف")
            Exit Sub

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        If RadioButton1.Checked And CheckBoxX1.Checked = True And CheckBoxX2.Checked = True Then

            Dim adp As New SqlDataAdapter("select no_c,name_snc, n_type,name_s,cast([Sumtot] as nvarchar(50)) as Sumtot, sal_s,no_ct1,date_s,stot  from tg WHERE  name_s =N'" + Me.ComboBoxEx4.Text + "'and n_type=N'" + ComboBoxEx3.Text + "'", cn)

            Dim dt As New DataTable

            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1

                If checkNum(dt.Rows(i).Item("Sumtot")) = "int" Then
                    dt.Rows(i).Item("Sumtot") = myNo
                Else
                    dt.Rows(i).Item("Sumtot") = FormatNumber(CDec(dt.Rows(i).Item(5)), 3)
                End If
            Next

            Dim frm As New Form10
            Dim rpt1 As New CrystalReport24()

            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1

            Dim Text18 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text18")
            Dim Text8 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text8")

            Text8.Text = Me.DateTimePicker1.Text
            Text18.Text = Me.DateTimePicker2.Text
            Text8.Color = Color.Red
            Text8.ApplyFont(New Font("Times New Roman", 14, FontStyle.Bold))
            Text18.Color = Color.Red
            Text18.ApplyFont(New Font("Times New Roman", 14, FontStyle.Bold))


            Dim Text21 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text21")
            Text21.Text = branch

            frm.ShowDialog()

            '====================

        Else

            MsgBox("اختار الجهة والكشف")
            Exit Sub

        End If
    End Sub


End Class