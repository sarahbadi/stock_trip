Imports System.Data.SqlClient
Public Class Form20
    Dim siopb As Integer
    Dim i As New Integer()
    Dim tot, tot1, eror_m As Boolean
    Dim s2 As String = "select * from RcvMain"
    Dim adRcvM As New SqlDataAdapter(s2, cn)
    Dim dsRcvM As New DataSet()
    Sub total_inf()
        'no_kshf

        If (Me.TextBox1.Text.ToString) <> " " Then
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s11 As String = "SELECT top 1 [no_i] , cast(SUBSTRING([no_i],1,4) as bigint), cast(SUBSTRING([no_i],5,len([no_i])) as bigint) FROM RcvMain where (ISNUMERIC(SUBSTRING([no_i],5,len([no_i])))=1 and cast(SUBSTRING([no_i],1,4) as bigint)=" & Me.dtYear.Value.Year & " and no_kshf =" & ssf_t & " and cast(SUBSTRING([no_i],5,len([no_i])) as bigint)=" & Me.TextBox1.Text.Trim() & ")"


            Dim cm As New SqlCommand(s11, cn)
            Try
                Dim r As SqlDataReader = cm.ExecuteReader

                If r.Read = True Then

                    tot = True
                    TextBox2.Text = r!no_i
                    r.Close()
                    cn.Close()

                Else

                    tot = False

                    Me.Label1.Text = "0.000"
                    Me.Label2.Text = "صفر دينار فقـط"

                    r.Close()
                    cn.Close()
                End If
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try
            cn.Close()
            '============================

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If


            Dim ds2 As New DataSet()
            ds2.Clear()
            Dim sql1 As String
            sql1 = "SELECT no_c as[رقم الصنف],name_snc as[اسم الصنف],qun_r as[الكمية], sal_s as[سعر الوحدة], gema as[القيمة]from View_sl  WHERE no_i='" + TextBox2.Text + "' and no_kshf =" & ssf_t & " ORDER BY no_ct1 "
            Dim ad As New SqlDataAdapter(sql1, cn)
            ds2.Clear()
            ad.Fill(ds2, "View_sl")
            Me.DataGridViewX2.DataSource = ds2
            Me.DataGridViewX2.DataMember = "View_sl"
            Me.DataGridViewX2.Refresh()
            cn.Close()
            '==================================
            Dim inf_t, y As Decimal
            inf_t = 0.0
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim sql As String = "select * from RcvSub where no_i ='" + TextBox2.Text + "' and no_kshf=" & ssf_t & ""
            Dim ad1 As New SqlDataAdapter(sql, cn)
            Dim ds1 As New DataSet()
            Dim TD1 As DataTable
            Dim DROW1 As DataRow
            tot1 = False
            y = 0.0

            ad1.Fill(ds1, sql)
            TD1 = ds1.Tables(sql)

            For i = 0 To TD1.Rows.Count - 1
                DROW1 = TD1.Rows(i)
                If DROW1("no_i") = (TextBox2.Text) Then
                    tot1 = True
                    y = CDbl(DROW1("gema"))
                    inf_t = CDbl(inf_t) + CDbl(y)
                End If

            Next
            Me.Label1.Text = CDbl(inf_t)
            cn.Close()

        End If
        '===========================================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim ss As String = "update RcvMain set no_i=@x1,g_b=@x2,tvg=@x3 where no_i=@x1 and no_kshf=" & ssf_t & ""
        Dim cms As New SqlCommand(ss, cn)
        cms.Parameters.Add((New SqlParameter("@x1", Trim(TextBox2.Text))))
        cms.Parameters.Add(New SqlParameter("@x2", CDec(Label1.Text)))
        cms.Parameters.Add(New SqlParameter("@x3", Me.Label2.Text))
        Try
            cms.ExecuteNonQuery()
            dsRcvM.Clear()
            adRcvM.Fill(dsRcvM, "RcvMain")
            cn.Close()
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try
        cn.Close()
    End Sub







  


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      

        If TextBox1.Text <> "" Then



            total_inf()
            '==================================
            If tot = True Then

                If tot1 = True Then

                    Me.Button3.Enabled = True
                Else
                    : MsgBox(" اذن الاستلام فارغ ", MsgBoxStyle.Information, "معلومة")
                    Me.Button3.Enabled = True
                End If


            Else
                : MsgBox(" اذن الاستلام غير موجود ", MsgBoxStyle.Critical, "تنبية")
                Me.Button3.Enabled = False
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





    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        If TextBox1.Text <> "" Then


            Dim adp As New SqlDataAdapter("SELECT no_i, no_c,name_snc,name_type,date_i,name_r,cast([qun_r] as nvarchar(50)) as qun_r, sal_s, gema, no_ct, n_txt,g_b,tvg, u_name, no_ct1, mt, n1_txt,name_stock FROM [estelam]  WHERE no_i ='" + TextBox1.Text + "'", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_r")) = "int" Then
                    dt.Rows(i).Item("qun_r") = myNo
                Else
                    dt.Rows(i).Item("qun_r") = FormatNumber(CDec(dt.Rows(i).Item(6)), 3)
                End If


            Next

            Dim frm As New Form12
            Dim rpt1 As New CrystalReport20
            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1

            Dim Text20 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text20")
            Text20.Text = branch

            '===============================================



            frm.Text = "طباعة "
            frm.ShowDialog()


        Else
            Exit Sub
        End If

    End Sub



    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            'xl = l_p(Trim(TextBox1.Text))
            'TextBox1.Text = Trim(xl)
            total_inf()

            If tot = False Then
                MsgBox(" اذن الاستلام غير موجود ", MsgBoxStyle.Critical, "تنبية")
                Me.Button3.Enabled = False
                Exit Sub
            Else
                Me.Button3.Enabled = True

            End If

            '=====================================================
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If


            Dim rds As Boolean
            ''======= شرط لو الاذن قعد فارغ ========'================

            Dim stR As String = "select * from RcvSub where no_i=@x1"
            Dim cmR As New SqlCommand(stR, cn)
            cmR.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))


            Try
                Dim r1 As SqlDataReader = cmR.ExecuteReader
                If r1.Read = True Then
                    r1.Close()
                    rds = True
                    cn.Close()
                Else
                    r1.Close()
                    cn.Close()
                    rds = False
                    MessageBox.Show("اذن الاستلام فارغ  ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            Catch

            End Try
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

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

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

    Private Sub Form20_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'If TextBox1.Text <> "" Then
        '    total_inf()
        'End If
    End Sub
   
    Private Sub Form20_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label1.Text = "0.000"
        Me.Label2.Text = "صفر دينار فقـط"
        Me.dtYear.Value = dateNowDB



    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.TextChanged
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox2.Text <> "" Then

           
            Dim f_Form_s As New Form_s
            '==================================
            Im_tadel = "تعديل"

            f_Form_s.TextBox17.Text = Trim(TextBox2.Text)

            f_Form_s.ShowDialog()


        Else
            MsgBox("أدخل رقم اذن الاستلام المراد البحث عنه ", MsgBoxStyle.Information, "إجراء بحث")
            TextBox1.Focus()
            Exit Sub
        End If


     
    End Sub

 

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        If TextBox2.Text <> "" Then


            Dim adp As New SqlDataAdapter("SELECT no_i, no_c,name_snc,name_type,date_i,name_r,cast([qun_r] as nvarchar(50)) as qun_r, sal_s, gema, no_ct, n_txt,g_b,tvg, u_name, no_ct1, mt, n1_txt,name_stock FROM [estelam]  WHERE no_i ='" + TextBox2.Text + "'", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_r")) = "int" Then
                    dt.Rows(i).Item("qun_r") = myNo
                Else
                    dt.Rows(i).Item("qun_r") = FormatNumber(CDec(dt.Rows(i).Item(6)), 3)
                End If


            Next

            Dim frm As New Form12

            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo


            '===============================================
            If branch = "الادارة العامة" Then
                Dim rpt1 As New CrystalReport20

                rpt1.SetDataSource(dt)
                frm.CrystalReportViewer1.ReportSource = rpt1

                Dim Text20 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text20")
                Text20.Text = branch
            Else
                Dim rpt2 As New CrystalReport20_froa

                rpt2.SetDataSource(dt)
                frm.CrystalReportViewer1.ReportSource = rpt2

                Dim Text20 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt2.Section1.ReportObjects("Text20")
                Text20.Text = branch
            End If

            frm.Text = "طباعة "
            frm.ShowDialog()


        Else
            Exit Sub
        End If
    End Sub

    Private Sub dtYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtYear.ValueChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DataGridViewX2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX2.CellContentClick

    End Sub
End Class