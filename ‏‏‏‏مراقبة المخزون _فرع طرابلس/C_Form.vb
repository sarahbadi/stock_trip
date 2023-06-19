Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports CrystalDecisions.CrystalReports.Engine

Public Class C_Form

    Dim s As String = "select * from IsuSub"
    Dim adIsuS As New SqlDataAdapter(s, cn)
    Dim dsIsuS As New DataSet()
    '==================================
    Dim ft, ft1 As Boolean
    Dim s1 As String = "select * from IsuMain"
    Dim adIsuM As New SqlDataAdapter(s1, cn)
    Dim dsIsuM As New DataSet()
    Function man14(ByVal Text1 As String) As String
        Dim a(100) As String
        Dim i, j As Integer
        'Dim nm As String
        Me.Label1.Text = Trim(Me.Label1.Text)
        Dim a1 As String
        a1 = Me.Label1.Text.ToString
        For i = 1 To Len(Text1)
            If (Mid(Me.Label1.Text, i, 1) = ".") Then
                Exit For
            End If
            If i = Len(Text1) Then
                If (Mid(Me.Label1.Text, i, 1) <> ".") Then
                    a1 = a1 + (".000")
                End If
            End If
        Next i
        j = Len(Text1)
        j = j - i
        If j = 1 Then
            a1 = a1 + ("00")
        End If
        If j = 2 Then
            a1 = a1 + ("0")
        End If
        Me.Label1.Text = Trim(a1)
        man14 = Me.Label1.Text
    End Function
    Sub ser_amr()

        If (Me.TextBox1.Text.ToString) <> "" Then
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If




            Dim s11 As String = "SELECT top 1 [no_s] , cast(SUBSTRING([no_s],1,4) as bigint), cast(SUBSTRING([no_s],5,len([no_s])) as bigint) FROM IsuMain where (ISNUMERIC(SUBSTRING([no_s],5,len([no_s])))=1 and cast(SUBSTRING([no_s],1,4) as bigint)=" & Me.dtYear.Value.Year & " and cast(SUBSTRING([no_s],5,len([no_s])) as bigint)=" & Me.TextBox1.Text.Trim() & ") "

            Dim cm As New SqlCommand(s11, cn)
            'cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader

                If r.Read = True Then

                    ft = True
                    TextBox2.Text = r!no_s
                    r.Close()
                Else

                    ft = False
                    Me.Label1.Text = "0.000"
                    Me.Label2.Text = "صفر دينار فقـط"
                    r.Close()
                End If
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try

        End If
        cn.Close()
        Dim ds2 As New DataSet()
        ds2.Clear()
        Dim sql1 As String
        'sql1 = "SELECT no_c as[رقم الصنف],name_snc as[اسم الصنف],qun_r as[الكمية], sal_s as[سعر الوحدة], gema as[القيمة], txt_s as[حاله الاضافه],mt as[ملاحظات],date_end as [تاريخ انتهاء الصلاحية],mdh as [المدة قبل انتهاء الصلاحية], mdh_a as [نوع المدة],date_mdh as [تاريخ التنبيه] from View_sl  WHERE no_i='" + TextBox1.Text + "'"

        sql1 = "SELECT [no_c]as [رقم الصنف],name_snc as[اسم الصنف],[qun_s] as [الكمية],[sal_s] as [سعر الوحدة],gema as [القيمة] from View_bay  WHERE no_s='" + TextBox2.Text + "'"
        Dim ad As New SqlDataAdapter(sql1, cn)
        ds2.Clear()
        ad.Fill(ds2, "View_bay")
        Me.DataGridViewX2.DataSource = ds2
        Me.DataGridViewX2.DataMember = "View_bay"
        Me.DataGridViewX2.Refresh()
        cn.Close()


        Dim inf_t, y As Decimal
        inf_t = 0.0
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sql As String = "select * from IsuSub where  no_s='" + TextBox2.Text + "'"
        Dim ad1 As New SqlDataAdapter(sql, cn)
        Dim ds1 As New DataSet()
        Dim TD1 As DataTable
        Dim DROW1 As DataRow
        Dim i As Integer
        y = 0.0
        ft1 = False
        ad1.Fill(ds1, sql)
        TD1 = ds1.Tables(sql)

        For i = 0 To TD1.Rows.Count - 1
            DROW1 = TD1.Rows(i)
            If DROW1("no_s") = (TextBox2.Text) Then
                ft1 = True
                y = CDbl(DROW1("gema"))
                inf_t = CDbl(inf_t) + CDbl(y)
            End If

        Next
        Me.Label1.Text = CDbl(inf_t)

        '=============================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim ss As String = "update IsuMain set no_s=@x1,total=@x2,tvg=@x3 where no_s=@x1"
        Dim cms As New SqlCommand(ss, cn)
        cms.Parameters.Add((New SqlParameter("@x1", TextBox2.Text)))
        cms.Parameters.Add(New SqlParameter("@x2", inf_t))
        cms.Parameters.Add(New SqlParameter("@x3", Label2.Text))
        Try
            cms.ExecuteNonQuery()
            dsIsuM.Clear()
            adIsuM.Fill(dsIsuM, "IsuMain")
            cn.Close()
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try

        cn.Close()

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        If TextBox1.Text <> "" Then
          
            ser_amr()
            '==================================
            If ft = True Then

                If ft1 = True Then

                    Me.Button2.Enabled = True
                Else
                    : MsgBox(" اذن الصرف فارغ ", MsgBoxStyle.Information, "معلومة")
                    Me.Button2.Enabled = True
                End If


            Else
                MsgBox(" اذن الصرف غير موجود ", MsgBoxStyle.Critical, "تنبية")
                Me.Button2.Enabled = False
                TextBox2.Text = ""
                DataGridViewX2.DataMember = ""
                DataGridViewX2.DataSource = Nothing
                Me.Label1.Text = "0.000"
                Me.Label2.Text = "صفر دينار فقـط"
            End If

        Else
            Exit Sub
        End If



    End Sub

    Private Sub C_Form_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ''If TextBox1.Text <> "" Then
        ''    ser_amr()

        ''End If
    End Sub

    Private Sub C_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label1.Text = "0.000"
        Me.Label2.Text = "صفر دينار فقـط"
        Me.dtYear.Value = dateNowDB
    End Sub


    Private Sub Label1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.TextChanged
        'Dim A As New NumberToWords
        'Me.Label2.Text = (A.getWords(Label1.Text))
        'Dim x As String
        'x = man14(Label1.Text)
        Try

            If IsNumeric(Me.Label1.Text) Then

                Me.Label1.Text = FormatNumber(CDec(Me.Label1.Text), 3)

                '------------------------------
                Dim ConvertValToChar As New ConvertValToString.ConvertValToString

                Me.Label2.Text = ConvertValToChar.ValToString(Label1.Text)

            End If

        Catch ex As Exception

        End Try
    End Sub







    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
           
            ser_amr()

            If ft = False Then
                MsgBox(" اذن الصرف غير موجود ", MsgBoxStyle.Critical, "تنبية")
                Me.Button2.Enabled = False
                Exit Sub
            Else
                Me.Button2.Enabled = True
            End If
            '=====================================================
          

        Else
            Exit Sub
        End If

        cn.Close()



    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        If TextBox2.Text <> "" Then
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            'Dim adp As New SqlDataAdapter("SELECT no_s,no_c,name_snc,name_type,cast([qun_ss] as nvarchar(50)) as qun_ss,sal_s, gemas,cast([balance] as nvarchar(50)) as balance,date_s ,name_s,u_name,no_ct1 ,tvg ,mt ,cast([q_div] as nvarchar(50)) as q_div from  msrofat WHERE no_s ='" + TextBoxX9.Text + "'", cn)
            Dim adp As New SqlDataAdapter("SELECT no_s,no_c,name_snc,name_type,cast([qun_ss] as nvarchar(50)) as qun_ss, sal_s, gemas,cast([balance] as nvarchar(50)) as balance,date_s ,name_s,u_name,no_ct1 ,tvg ,no_ct,mt ,cast([q_div] as nvarchar(50)) as q_div,name_stock,name1_stock from  msrofatt WHERE no_s ='" + TextBox2.Text + "'", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_ss")) = "int" Then
                    dt.Rows(i).Item("qun_ss") = myNo
                Else
                    dt.Rows(i).Item("qun_ss") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
                End If
                If checkNum(dt.Rows(i).Item("balance")) = "int" Then
                    dt.Rows(i).Item("balance") = myNo
                Else
                    dt.Rows(i).Item("balance") = FormatNumber(CDec(dt.Rows(i).Item(8)), 3)
                End If


                If checkNum(dt.Rows(i).Item("q_div")) = "int" Then
                    dt.Rows(i).Item("q_div") = myNo
                Else
                    dt.Rows(i).Item("q_div") = FormatNumber(CDec(dt.Rows(i).Item(15)), 3)
                End If


            Next

            Dim frm As New Form7
            '===============================================
            If branch = "الادارة العامة" Then
                Dim rpt1 As New CrystalReport14

                rpt1.SetDataSource(dt)
                frm.CrystalReportViewer1.ReportSource = rpt1
                Dim Text8 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text8")
                Text8.Text = branch

            Else
                Dim rpt2 As New CrystalReport14_froa

                rpt2.SetDataSource(dt)
                frm.CrystalReportViewer1.ReportSource = rpt2
                Dim Text8 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt2.Section1.ReportObjects("Text8")
                Text8.Text = branch
            End If


            frm.Text = "طباعة "
            frm.ShowDialog()
            cn.Close()
        Else
            Exit Sub
        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If TextBox2.Text <> "" Then
            Dim f_Form_Isu As New Form_Isu

            If Me.DataGridViewX2.Rows.Count > 0 Then

                '==================================
                Im_tadel_s = "تعديل"
                f_Form_Isu.TextBox8.Text = Trim(TextBox2.Text)
                f_Form_Isu.ShowDialog()

            Else
                MsgBox(" اذن الصرف غير موجود ", MsgBoxStyle.Critical, "تنبية")
                Exit Sub
            End If
        Else
            MsgBox("أدخل رقم اذن الصرف المراد البحث عنه ", MsgBoxStyle.Information, "إجراء بحث")
            Exit Sub
        End If

    End Sub




    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class