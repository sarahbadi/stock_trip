Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports CrystalDecisions.CrystalReports.Engine

Public Class matt_return
    Dim srf_ch As Boolean
    Dim move_no As String
    Dim sum_irct, sum_iiss, sum_return, sum_talf, total_s As New Integer()
    Dim siopb As Integer
    Dim s1 As String = "select * from matt_return"
    Dim adm As New SqlDataAdapter(s1, cn)
    Dim dsm As New DataSet()
    Dim tr_tt, sel As Boolean
    '===========================
    '======================================
    Dim smt As String = "select * from matt"
    Dim admt As New SqlDataAdapter(smt, cn)
    Dim dsmt As New DataSet()
    Dim TDmt As DataTable
    '======================================

    Dim stran As String = "select * from tran_IRT"
    Dim adtran As New SqlDataAdapter(stran, cn)
    Dim dstran As New DataSet()
    '========================
    '===========================
    Dim s22 As String = "select * from acthion_tran"
    Dim adact As New SqlDataAdapter(s22, cn)
    Dim dsact As New DataSet()
    '======================================
    Sub auto_no()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "select * from matt_return where matt_return.no_i=(select max(no_i) from matt_return)"
        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "matt_return")
        tb = ds.Tables(0)
        Dim dr As DataRow
        Try
            dr = tb.Rows(0)
            Me.TextBox8.Text = dr(1)
        Catch ex As Exception
            Me.TextBox8.Text = "1"
        End Try
        ad.Dispose()
        ds.Dispose()
    End Sub


    Sub smove_no_i()
     
  

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i,count1) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7)"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBoxX6.Text))
        cm.Parameters.Add(New SqlParameter("@x2", TextBox6.Text))
        cm.Parameters.Add(New SqlParameter("@x3", CDec(TextBox9.Text)))
        cm.Parameters.Add(New SqlParameter("@x4", 5))
        cm.Parameters.Add(New SqlParameter("@x5", TextBox8.Text))
        cm.Parameters.Add(New SqlParameter("@x6", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cm.Parameters.Add(New SqlParameter("@x7", 0))
        Try
            cm.ExecuteNonQuery()
            dstran.Clear()
            adtran.Fill(dstran, "tran_IRT")

        Catch

        End Try
    End Sub
    Sub ser_amr()

        If (Me.TextBox8.Text.ToString) <> " " Then
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s11 As String = "SELECT * FROM matt_return WHERE no_i=@x1"
            Dim cm As New SqlCommand(s11, cn)
            cm.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader

                If r.Read = True Then
                    'clering_1()
                    TextBoxX1.Text = r!n_txt
                    Me.DateTimePicker1.Value = r!date_i
                    TextBoxX3.Text = r!noot

                    r.Close()
                Else

                    MsgBox(" «–‰ «· —ÃÌ⁄ €Ì— „ÊÃÊœ ", MsgBoxStyle.Information, " ‰»Ì…")
                    r.Close()
                End If
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try

        End If
        cn.Close()
        view_lstn_i()
        'If v1 = True And v2 = True And v3 = True Then
        '    Me.ButtonX1.Visible = True
        '    Me.ButtonX2.Visible = True
        '    Me.DateTimePicker1.Enabled = True
        '    'Me.ComboBoxEx3.Enabled = True
        '    Me.TextBoxX1.ReadOnly = False
        '    Me.TextBoxX3.ReadOnly = False
        'Else
        '    Me.ButtonX1.Visible = False
        '    Me.ButtonX2.Visible = False
        '    Me.DateTimePicker1.Enabled = False
        '    'Me.ComboBoxEx3.Enabled = False
        '    'Me.ComboBoxEx3.BackColor = Color.White
        '    Me.TextBoxX1.ReadOnly = True
        '    Me.TextBoxX1.BackColor = Color.White
        '    Me.TextBoxX3.ReadOnly = True
        '    Me.TextBoxX3.BackColor = Color.White
        'End If
    End Sub
    '===========================»ÕÀ «–‰ «·«” ·«„============
    Sub view_lstn_i()

        Dim dt2 As DataTable
        Dim sql1, n1 As String
        n1 = TextBox8.Text
        If n1 = "" Then
            Exit Sub
        Else
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            sql1 = "SELECT * from matt_return WHERE no_i ='" + n1 + "'"
            Dim da8 As New SqlDataAdapter(sql1, cn)
            Dim ds8 As New DataSet
            ds8.Clear()
            da8.Fill(ds8, "matt_return")
            dt2 = ds8.Tables("matt_return")
            If dt2.Rows.Count > 0 Then

            End If
            ListView2.Clear()

            Dim dr2 As DataRow


            ListView2.Columns.Add("—ﬁ„ «·’‰› ", 95, HorizontalAlignment.Center)
            ListView2.Columns.Add("«·ﬂ„Ì…", 90, HorizontalAlignment.Center)
            ListView2.Columns.Add("«·”⁄— ", 90, HorizontalAlignment.Center)
            ListView2.Columns.Add("«·ﬁÌ„Â", 90, HorizontalAlignment.Center)
            ListView2.Columns.Add("0", 0, HorizontalAlignment.Center)
            'ListView2.Columns.Add("—ﬁ„ «·’‰› ", 130, HorizontalAlignment.Center)
            Dim sdl As Short = 1
            ListView2.Items.Clear()
            Dim i, c As Integer
            c = dt2.Rows.Count - 1
            For i = 0 To c
                Dim litem As New ListViewItem
                If sdl = 1 Then
                    litem.BackColor = System.Drawing.Color.AliceBlue : sdl = 2
                Else
                    litem.BackColor = System.Drawing.Color.White : sdl = 1
                End If
                dr2 = dt2.Rows.Item(i)

                litem.Text = dt2.Rows(i).Item("no_c")
                litem.SubItems.Add(dt2.Rows(i).Item("qun_t"))
                litem.SubItems.Add(dt2.Rows(i).Item("sal_s"))
                litem.SubItems.Add(dt2.Rows(i).Item("gema"))
                'litem.SubItems.Add(dt2.Rows(i).Item("txt_s"))
                litem.SubItems.Add(dt2.Rows(i).Item("n_txt"))
                litem.SubItems.Add(dt2.Rows(i).Item("n_ns"))
                ListView2.Items.Add(litem)
            Next i
        End If
    End Sub
    Sub clering_1()
        Me.TextBoxX6.Clear()
        Me.TextBoxX1.Clear()
        Me.TextBox6.Clear()
        Me.TextBox9.Clear()
        Me.TextBox11.Clear()
        Me.TextBox10.Clear()
        'ComboBoxEx3.SelectedIndex = -1
        Me.TextBoxX1.Clear()
        Me.DateTimePicker1.Value = Now
    End Sub
    Sub serch_no_c()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If TextBoxX6.Text <> "" Then
            Dim s As String = "select * from matt where no_c=@x1"
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add(New SqlParameter("@x1", (TextBoxX6.Text)))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader
                If r.Read = True Then
                    TextBox11.Text = r!name_snc
                    'Me.TextBoxX2.Text = r!iopb
                    r.Close()
                Else
                    r.Close()
                    'Me.clearing()
                    Me.TextBox11.Clear()
                    Me.TextBox6.Clear()
                    Me.TextBox9.Clear()
                    Me.TextBox10.Clear()
                    'MessageBoxEx.Show("Â–« «·’‰› ·„ Ì „  ⁄—Ì›Â", "v1„Œ«“‰", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub

                    r.Close()
                End If

            Catch
                MsgBox("ÌÊÃœ Œÿ«¡›Ì »Ì«‰«  «·„Ê«œ", MsgBoxStyle.Critical, " ‰»Ì…")
            End Try
        End If

        Me.TextBox6.Clear()
        Me.TextBox9.Clear()
        Me.TextBox10.Clear()
    End Sub

    Private Sub TextBoxX6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX6.KeyPress
        'Select Case e.KeyChar
        '    Case "0" To "9", ControlChars.Back
        '        e.Handled = False
        '    Case Else
        '        e.Handled = True
        'End Select
    End Sub
    Private Sub TextBoxX6_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBoxX6.Validating
        serch_no_c()
    End Sub
    Sub stouck()
        Dim i, w As Integer
        'Dim qt As Boolean

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sql As String = "select * from RcvSub where RcvSub.[no_c] ='" + TextBoxX6.Text + "'"
        Dim ad1 As New SqlDataAdapter(sql, cn)
        Dim ds1 As New DataSet()
        Dim TD1 As DataTable
        Dim DROW1 As DataRow
        Dim y As Integer
        y = 0
        sum_irct = 0
        ad1.Fill(ds1, sql)
        TD1 = ds1.Tables(sql)

        For i = 0 To TD1.Rows.Count - 1
            DROW1 = TD1.Rows(i)
            If DROW1("no_c") = (TextBoxX6.Text) Then

                y = Val(DROW1("qun_r"))
                sum_irct = sum_irct + y
            End If

        Next
        cn.Close()
        '===============«Ã„«·Ì «·„’—Ê›==================

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq3 As String = "select * from IsuSub where IsuSub.[no_c]='" + TextBoxX6.Text + "'"

        Dim ad3 As New SqlDataAdapter(sq3, cn)
        Dim ds3 As New DataSet()
        Dim TD3 As DataTable
        Dim DROW3 As DataRow
        Dim y2 As Integer
        Me.sum_iiss = 0
        y2 = 0
        ad3.Fill(ds3, sq3)
        TD3 = ds3.Tables(sq3)

        For w = 0 To TD3.Rows.Count - 1
            DROW3 = TD3.Rows(w)
            If DROW3("no_c") = (TextBoxX6.Text) Then

                y2 = Val(DROW3("qun_s"))
                sum_iiss = sum_iiss + y2

            End If
        Next
        cn.Close()
        '===============«Ã„«·Ì „— Ã⁄Â==================


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq4 As String = "select * from matt_return where matt_return.[no_c] ='" + TextBoxX6.Text + "'"

        Dim ad4 As New SqlDataAdapter(sq4, cn)
        Dim ds4 As New DataSet()
        Dim TD4 As DataTable
        Dim DROW4 As DataRow
        Dim y4 As Integer
        sum_return = 0
        y4 = 0
        ad4.Fill(ds4, sq4)
        TD4 = ds4.Tables(sq4)

        For w = 0 To TD4.Rows.Count - 1
            DROW4 = TD4.Rows(w)

            If DROW4("no_c") = (TextBoxX6.Text) Then

                y4 = Val(DROW4("qun_t"))
                sum_return = sum_return + y4

            End If
        Next
        cn.Close()
        '=============== «·›==================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq5 As String = "select * from sub_TALEF where sub_TALEF.[no_c] ='" + TextBoxX6.Text + "'"

        Dim ad5 As New SqlDataAdapter(sq5, cn)
        Dim ds5 As New DataSet()
        Dim TD5 As DataTable
        Dim DROW5 As DataRow
        Dim y5 As Integer
        sum_talf = 0
        y5 = 0
        ad5.Fill(ds5, sq5)
        TD5 = ds5.Tables(sq5)

        For w = 0 To TD5.Rows.Count - 1
            DROW5 = TD5.Rows(w)

            If DROW5("no_c") = (TextBoxX6.Text) Then

                y5 = Val(DROW5("qun_T"))
                sum_talf = sum_talf + y5

            End If
        Next
        cn.Close()
        Me.total_s = 0


        Me.total_s = ((sum_irct + sum_return) - sum_iiss) - sum_talf


        '=======================================================

        If cn.State = ConnectionState.Closed Then
            cn.Open()

            Dim s1 As String = "update  matt set no_c=@x1,balance=@x2,returns=@x5 where no_c=@x1"
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", TextBoxX6.Text))
            cm1.Parameters.Add(New SqlParameter("@x2", total_s))
            cm1.Parameters.Add(New SqlParameter("@x5", sum_return))

            Try
                cm1.ExecuteNonQuery()
                dsmt.Clear()
                admt.Fill(dsmt, " matt")
            Catch
            End Try

        End If
        cn.Close()
    End Sub

    Sub acthion_tran()


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "insert into acthion_tran(info,no_c,date_i,qun_tot,sal_s) values (@x1,@x2,@x3,@x4,@x5)"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
        cm.Parameters.Add(New SqlParameter("@x2", TextBoxX6.Text))
        cm.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cm.Parameters.Add(New SqlParameter("@x4", TextBox6.Text))
        cm.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))

        Try
            cm.ExecuteNonQuery()
            dsact.Clear()
            adact.Fill(dsact, "acthion_tran")
        Catch
            'MsgBox("·«Ì„ﬂ‰ﬂ «·≈÷«›… ›«·”Ã· „ÊÃÊœ „”»ﬁ«", MsgBoxStyle.Critical, " ‰»Ì…")
            'Exit Sub
        End Try
        'Else
        ''==================== „ÊÃÊœ===========================

    End Sub

    Sub clearing()
        Me.TextBoxX6.Clear()
        Me.TextBox11.Clear()
        TextBoxX4.Clear()
    End Sub
    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        move_no = "0"
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If Me.TextBoxX6.Text = "" Then
            MsgBox("√œŒ· —ﬁ„ «·’‰› «·„—«œ≈÷«› Â ", MsgBoxStyle.Information, "≈Ã—«¡ ≈÷«›…")
            TextBoxX6.Focus()

            Exit Sub
        End If

        If Me.TextBox8.Text = "" Then
            MsgBox("√œŒ· —ﬁ„ «–‰ «·«” ·«„ ", MsgBoxStyle.Information, "≈Ã—«¡ ≈÷«›…")
            TextBox8.Focus()
            Exit Sub
        End If
        'If Me.ComboBoxEx3.SelectedIndex = -1 Then
        '    MsgBox("≈Œ «— √”„ «·ÃÂ… «·„” ·„…", MsgBoxStyle.Information, "≈Ã—«¡ ≈÷«›…")
        '    ComboBoxEx3.Focus()
        '    Exit Sub
        'End If

        If Me.TextBox6.Text.ToString = "" Or Me.TextBox6.Text.ToString = 0 Then
            MsgBox("√œŒ· «·ﬂ„Ì… ", MsgBoxStyle.Information, "≈Ã—«¡ ≈÷«›…")
            TextBox6.Focus()
            Exit Sub
        End If

        If Me.TextBox9.Text.ToString = "" Or Me.TextBox9.Text.ToString = "0.000" Or Me.TextBox9.ToString = "0" Or Me.TextBox9.ToString = "0.00" Then
            MsgBox("«œŒ· ”⁄— «·ÊÕœ…", MsgBoxStyle.Information, "≈Ã—«¡ ≈÷«›… ")
            TextBox9.Focus()
            Exit Sub
        End If

        If Val(Me.TextBox6.Text) > Val(Me.TextBoxX4.Text) Then
            MessageBoxEx.Show("·« ” ÿÌ⁄ «· —ÃÌ⁄ ·«‰ «·ﬂ„Ì… «·„’—Ê›Â «ﬁ· „‰ «·ﬂ„ÌÂ «·„—Ã⁄…", "v1„Œ«“‰", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else

            Dim s As String = "insert into matt_return(no_c,no_i,date_i,qun_t,sal_s,gema,n_txt,noot,u_name,n_ns) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9,@x10)"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", TextBoxX6.Text))
            cm.Parameters.Add((New SqlParameter("@x2", TextBox8.Text)))
            cm.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
            cm.Parameters.Add(New SqlParameter("@x4", TextBox6.Text))
            cm.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
            cm.Parameters.Add(New SqlParameter("@x6", CDec(TextBox10.Text)))
            cm.Parameters.Add(New SqlParameter("@x7", TextBoxX1.Text))
            cm.Parameters.Add(New SqlParameter("@x8", TextBoxX3.Text))
            cm.Parameters.Add(New SqlParameter("@x9", ww))
            cm.Parameters.Add(New SqlParameter("@x10", TextBoxX5.Text))
            Try
                cm.ExecuteNonQuery()
                dsm.Clear()
                adm.Fill(dsm, "matt_return")
                MessageBoxEx.Show(" „ «·Õ›Ÿ", "v1„Œ«“‰", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cn.Close()
                smove_no_i()
                acthion_tran()
                stouck()

                t_event = "Õ›Ÿ ’‰›"
                But_action_user()


                Me.TextBox6.Clear()
                Me.TextBox9.Clear()
                Me.TextBox10.Clear()
                clearing()
                cn.Close()
                Me.ButtonX5.Enabled = False
                Me.ButtonX7.Enabled = False

            Catch
                MsgBox("·«Ì„ﬂ‰ﬂ «·≈÷«›… ›«·”Ã· „ÊÃÊœ „”»ﬁ«", MsgBoxStyle.Critical, " ‰»Ì…")
            End Try


        End If

        ListView2.Sorting = SortOrder.Ascending

        view_lstn_i()

    End Sub
    Private Sub ListView2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.Click

        Dim litem As ListViewItem
        'Dim i As Integer
        For Each litem In ListView2.SelectedItems
            Me.TextBoxX6.Text = litem.SubItems(0).Text
            TextBox6.Text = litem.SubItems(1).Text
            TextBox9.Text = litem.SubItems(2).Text
            TextBox10.Text = litem.SubItems(3).Text
            TextBoxX5.Text = litem.SubItems(5).Text
            'If litem.SubItems(4).Text = "" Then
            '    TextBoxX7.Text = 0
            'Else
            '    TextBoxX7.Text = litem.SubItems(4).Text
            'End If
        Next
        sel_srf()
        Me.ButtonX6.Enabled = False
        Me.ButtonX5.Enabled = True
        Me.ButtonX7.Enabled = True

    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", "/", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged



    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        If TextBox8.Text <> "" Then
            

            Dim f As New Form9
            Dim adp As New SqlDataAdapter("SELECT no_i, no_c, name_snc, name_type,date_i, cast([qun_t]as nvarchar(50))as qun_t, sal_s, no_ct, gema, n_txt, u_name, noot from returns  WHERE no_i ='" + TextBox8.Text + "'", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_t")) = "int" Then
                    dt.Rows(i).Item("qun_t") = myNo
                Else

                    dt.Rows(i).Item("qun_t") = FormatNumber(CDec(dt.Rows(i).Item(6)), 3)
                End If

              
            Next

            Dim rpt1 As New CrystalReport10

            rpt1.SetDataSource(dt)
            f.CrystalReportViewer1.ReportSource = rpt1


            f.Text = "ÿ»«⁄… "

            Dim Text20 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text20")
            Text20.Text = branch
            f.ShowDialog()




        Else
            Exit Sub
        End If


    End Sub
    Sub delet()


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "delete from tran_IRT where no_c=@x1 and n_rs=@x2 and price=@x3 and tr_type=5"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBoxX6.Text))
        cm.Parameters.Add(New SqlParameter("@x2", TextBox8.Text))
        cm.Parameters.Add(New SqlParameter("@x3", (Me.TextBox9.Text)))
        Try
            cm.ExecuteNonQuery()
            dstran.Clear()
            adtran.Fill(dstran, "tran_IRT")
            cn.Close()
        Catch

        End Try
    End Sub
    Sub delet_action()

        '============================================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "delete from acthion_tran where no_c=@x1 and info=@x2 and sal_s=@x3 and date_i=@x4"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBoxX6.Text))
        cm.Parameters.Add(New SqlParameter("@x2", TextBox8.Text))
        cm.Parameters.Add(New SqlParameter("@x3", (Me.TextBox9.Text)))
        cm.Parameters.Add(New SqlParameter("@x4", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        Try
            cm.ExecuteNonQuery()
            dsact.Clear()
            adact.Fill(dsact, "acthion_tran")
        Catch

        End Try

    End Sub

    Sub But_action_user()
        t_doc = "«–‰  —ÃÌ⁄"
        ts = TimeOfDay

        If cn.State = ConnectionState.Closed Then
            cn.Open()

        End If

        Dim s As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
        cm.Parameters.Add(New SqlParameter("@x2", t_doc))
        cm.Parameters.Add(New SqlParameter("@x3", TextBoxX6.Text))
        cm.Parameters.Add(New SqlParameter("@x4", Me.TextBox6.Text))
        cm.Parameters.Add(New SqlParameter("@x5", TextBox9.Text))
        cm.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
        cm.Parameters.Add(New SqlParameter("@x7", ts))
        cm.Parameters.Add(New SqlParameter("@x8", ww))
        cm.Parameters.Add(New SqlParameter("@x9", t_event))

        Try
            cm.ExecuteNonQuery()

            dssaction_user.Clear()
            adsaction_user.Fill(dssaction_user, "action _user")

        Catch

        End Try

    End Sub

    ''Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click

    ''    If Me.TextBoxX6.Text.ToString = "" Then
    ''        MsgBox(" «÷€ÿ ⁄·Ï —ﬁ„ «·’‰›   ", MsgBoxStyle.Information, "≈Ã—«¡ ≈÷«›…")
    ''        TextBoxX6.Focus()
    ''        Exit Sub
    ''    End If

    ''    If cn.State = ConnectionState.Closed Then
    ''        cn.Open()
    ''    End If

    ''    Dim s1 As String = "select * from tran where  n_rs=@x and no_c=@x1 and date_i=@x3 and tr_type=@x4 and price=@x5"
    ''    Dim cm1 As New SqlCommand(s1, cn)
    ''    cm1.Parameters.Add(New SqlParameter("@x", (TextBox8.Text)))
    ''    cm1.Parameters.Add(New SqlParameter("@x1", (TextBoxX6.Text)))
    ''    cm1.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
    ''    cm1.Parameters.Add(New SqlParameter("@x4", 3))
    ''    cm1.Parameters.Add(New SqlParameter("@x5", TextBox9.Text))
    ''    Try

    ''        Dim r1 As SqlDataReader = cm1.ExecuteReader

    ''        If r1.Read = True Then

    ''            tr_tt = True

    ''            r1.Close()
    ''        Else
    ''            r1.Close()
    ''            tr_tt = False
    ''        End If

    ''    Catch

    ''    End Try

    ''    '==========================================
    ''    If tr_tt = False Then

    ''        If cn.State = ConnectionState.Closed Then
    ''            cn.Open()
    ''        End If

    ''        Dim s As String = "delete from matt_return where no_c=@x1 and no_i=@x2 and sal_s=@x3"
    ''        Dim cm As New SqlCommand(s, cn)
    ''        cm.Parameters.Add(New SqlParameter("@x1", TextBoxX6.Text))
    ''        cm.Parameters.Add(New SqlParameter("@x2", Me.TextBox8.Text))
    ''        cm.Parameters.Add(New SqlParameter("@x3", TextBox9.Text))


    ''        If MsgBox("Â· √‰  „ √ﬂœ „‰ ⁄„·Ì… Õœ›ﬂ ·Â–« «·”Ã·ø", MsgBoxStyle.YesNo, " √ﬂÌœ Õ–›") = MsgBoxResult.Yes Then

    ''            Try
    ''                cm.ExecuteNonQuery()
    ''                dsm.Clear()
    ''                adm.Fill(dsm, "matt_return")
    ''                Me.ButtonX5.Enabled = False
    ''                Me.ButtonX7.Enabled = False
    ''            Catch

    ''            End Try
    ''            '---------------------------------
    ''            t_event = "Õ–›"
    ''            But_action_user()
    ''            '----------------------------------
    ''            delet()
    ''            delet_action()
    ''            stouck()
    ''            clearing()
    ''        Else
    ''            MsgBox("·„   „ ⁄„·Ì… «·Õ–› ø", MsgBoxStyle.OkOnly, " √ﬂÌœ Õ–›")
    ''            Exit Sub
    ''        End If
    ''    Else
    ''        'clear_a()
    ''        MessageBoxEx.Show("·« ” ÿÌ⁄ «·Õ–› ·«‰ «·’‰›   „ «·’—› „‰Â", "v1„Œ«“‰", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    ''        Exit Sub
    ''    End If
    ''    view_lstn_i()
    ''End Sub
    Private Sub update_tran()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s1 As String = "update tran_IRT set n_rs='" & TextBox8.Text & "' ,no_c='" & TextBoxX6.Text & "' , quntity=" & Me.TextBox6.Text & "  where n_rs='" & TextBox8.Text & "' and no_c='" & TextBoxX6.Text & "' and price=" & TextBox9.Text & " and tr_type=5"
        Dim cm1 As New SqlCommand(s1, cn)
        cm1.ExecuteNonQuery()
        dstran.Clear()
        adtran.Fill(dstran, "tran_IRT")
        cn.Close()
    End Sub
    Sub update_actiontran()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        ''If sum_irct = 0 Then
        '    delet()
        'Else
        Dim s1 As String = "update acthion_tran set info=@x1,no_c=@x2,date_i=@x3,qun_tot=@x4,sal_s=@x5 where info=@x1 and no_c=@x2 and date_i=@x3 and sal_s=@x5"
        Dim cm1 As New SqlCommand(s1, cn)
        cm1.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
        cm1.Parameters.Add(New SqlParameter("@x2", Me.TextBoxX6.Text))
        cm1.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cm1.Parameters.Add(New SqlParameter("@x4", TextBox6.Text))
        cm1.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
        Try
            cm1.ExecuteNonQuery()
            dsact.Clear()
            adact.Fill(dsact, "acthion_tran")
        Catch
            ''MsgBox("·«Ì„ﬂ‰ﬂ «·≈÷«›… ›«·”Ã· „ÊÃÊœ „”»ﬁ«", MsgBoxStyle.Critical, " ‰»Ì…")
            'Exit Sub
        End Try

    End Sub
    Sub sel_srf()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s1 As String = "select * from IsuSub  where no_s=@x1 and no_c=@x2 and sal_s=@x3"
        Dim cm1 As New SqlCommand(s1, cn)
        cm1.Parameters.Add(New SqlParameter("@x1", (TextBoxX5.Text)))
        cm1.Parameters.Add(New SqlParameter("@x2", (TextBoxX6.Text)))
        cm1.Parameters.Add(New SqlParameter("@x3", TextBox9.Text))
        Try

            Dim r1 As SqlDataReader = cm1.ExecuteReader

            If r1.Read = True Then

                'sel = True
                Me.TextBoxX4.Text = r1!qun_s
                r1.Close()
            Else
                r1.Close()
                Me.TextBoxX5.Text = 0
            End If

        Catch

        End Try
        cn.Close()
    End Sub
    Private Sub ButtonX7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX7.Click

        If Me.TextBoxX6.Text.ToString = "" Then
            MsgBox(" «÷€ÿ ⁄·Ï —ﬁ„ «·’‰›   ", MsgBoxStyle.Information, "≈Ã—«¡ ≈÷«›…")
            TextBoxX6.Focus()
            Exit Sub
        End If


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If Val(Me.TextBox6.Text) > Val(Me.TextBoxX4.Text) Then
            MessageBoxEx.Show("·« ” ÿÌ⁄ «· —ÃÌ⁄ ·«‰ «·ﬂ„Ì… «·„” ·„… «ﬁ· „‰ «·ﬂ„ÌÂ «·„—Ã⁄…", "v1„Œ«“‰", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Dim s1 As String = "select * from tran_IRT where n_rs=@x and no_c=@x1 and date_i=@x3 and tr_type=@x4 and price=@x5"
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x", (TextBox8.Text)))
            cm1.Parameters.Add(New SqlParameter("@x1", (TextBoxX6.Text)))
            cm1.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
            cm1.Parameters.Add(New SqlParameter("@x4", 3))
            cm1.Parameters.Add(New SqlParameter("@x5", TextBox9.Text))
            Try

                Dim r1 As SqlDataReader = cm1.ExecuteReader

                If r1.Read = True Then

                    tr_tt = True

                    r1.Close()
                Else
                    r1.Close()
                    tr_tt = False
                End If

            Catch

            End Try

            '==========================================
            If tr_tt = False Then

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If



                Dim s As String = "update matt_return set no_c=@x1,no_i=@x2,date_i=@x3,qun_t=@x4,sal_s=@x5,gema=@x6,n_txt=@x7,noot=@x8,u_name=@x9  where no_c=@x1 and no_i=@x2 and sal_s=@x5"
                Dim cm As New SqlCommand(s, cn)

                cm.Parameters.Add(New SqlParameter("@x1", Val(TextBoxX6.Text)))
                cm.Parameters.Add((New SqlParameter("@x2", TextBox8.Text)))
                cm.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))

                cm.Parameters.Add(New SqlParameter("@x4", TextBox6.Text))
                cm.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
                cm.Parameters.Add(New SqlParameter("@x6", CDec(TextBox10.Text)))
                cm.Parameters.Add(New SqlParameter("@x7", TextBoxX1.Text))
                cm.Parameters.Add(New SqlParameter("@x8", TextBoxX3.Text))
                cm.Parameters.Add(New SqlParameter("@x9", ww))


                Try
                    cm.ExecuteNonQuery()
                    dsm.Clear()
                    adm.Fill(dsm, "matt_return")
                    MsgBox(" „ «· ⁄œÌ· ", MsgBoxStyle.Information, " ‰»Ì…")
                    update_tran()
                    update_actiontran()
                    stouck()

                    t_event = " ⁄œÌ· ’‰›"
                    But_action_user()

                    ser_amr()
                    clearing()
                    Me.TextBox6.Clear()
                    Me.TextBox9.Clear()
                    Me.TextBox10.Clear()
                    Me.ButtonX5.Enabled = False
                    Me.ButtonX7.Enabled = False
                Catch
                    'MsgBox("«·”Ã· «·„—«œ «÷«› Â  „ÊÃÊœ ", MsgBoxStyle.Information, " ‰»Ì…")

                End Try
            Else
                MessageBoxEx.Show("·«  ” ÿÌ⁄ «· ⁄œÌ· ·«‰ «·’‰›   „ «·’—› „‰Â", "v1„Œ«“‰", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                clearing()
                Exit Sub
            End If

        End If

    End Sub

    Private Sub TextBoxX6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX6.TextChanged
        serch_no_c()
    End Sub

    'Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress, TextBox6.KeyPress
    '    Select Case e.KeyChar
    '        Case "0" To "9", ".", ControlChars.Back
    '            e.Handled = False
    '        Case Else
    '            e.Handled = True
    '    End Select
    'End Sub


    Function man9(ByVal Text1 As String) As String
        Dim a(100) As String
        Dim i, j As Integer
        'Dim nm As String
        Me.TextBox9.Text = Trim(Me.TextBox9.Text)
        Dim a1 As String
        a1 = Me.TextBox9.Text.ToString
        For i = 1 To Len(Text1)
            If (Mid(Me.TextBox9.Text, i, 1) = ".") Then
                Exit For
            End If
            If i = Len(Text1) Then
                If (Mid(Me.TextBox9.Text, i, 1) <> ".") Then
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
        Me.TextBox9.Text = Trim(a1)
        man9 = Me.TextBox9.Text
    End Function
    Function man10(ByVal Text1 As String) As String
        Dim a(100) As String
        Dim i, j As Integer
        'Dim nm As String
        Me.TextBox10.Text = Trim(Me.TextBox10.Text)
        Dim a1 As String
        a1 = Me.TextBox10.Text.ToString
        For i = 1 To Len(Text1)
            If (Mid(Me.TextBox10.Text, i, 1) = ".") Then
                Exit For
            End If
            If i = Len(Text1) Then
                If (Mid(Me.TextBox10.Text, i, 1) <> ".") Then
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
        Me.TextBox10.Text = Trim(a1)
        man10 = Me.TextBox10.Text
    End Function

    '************** ⁄œ»· ›Ì ≈”„ «·ÃÂ…************"

    Private Sub update_name_date_amr()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim cm As New SqlCommand("UPDATE matt_return SET matt_return.date_i= " + "# " + DateTimePicker1.Value.Date + " # WHERE (((matt_return.no_i)='" + Me.TextBox8.Text + "'));", cn)
        cm.ExecuteNonQuery()
        adm.Fill(dsm, "matt_return")
        cn.Close()

    End Sub

    '=============================================================
    '************** ⁄œ»· ›Ì «–‰ «·«” ·«„************"
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        If Me.TextBox8.Text = "" Then
            MsgBox(" «œŒ· —ﬁ„ ≈–‰ «” ·«„")
            Exit Sub
        Else

            update_name_date_amr()
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            '=============  
            Dim s As String = "update matt_return set n_txt=@x1 ,noot=@x3 where no_i=@x2"
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add(New SqlParameter("@x1", TextBoxX1.Text))
            cm.Parameters.Add(New SqlParameter("@x2", TextBox8.Text))
            cm.Parameters.Add(New SqlParameter("@x3", TextBoxX3.Text))

            cm.ExecuteNonQuery()
            dsm.Clear()
            adm.Fill(dsm, "matt_return")
            t_event = " ⁄œÌ·"
            But_action_user()
            MsgBox(" „ «· ⁄œÌ· ", MsgBoxStyle.Information, " ‰»Ì…")
            cn.Close()
            update_tran_ret()
            update_action_ret()
        End If
    End Sub
    ''============================== ⁄œÌ· «–‰ «· —ÃÌ⁄===============
    Sub update_tran_ret()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s1 As String = "update tran_IRT set date_i=@x2,n_rs=@x3 where n_rs=@x3"
        Dim cm1 As New SqlCommand(s1, cn)
        cm1.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cm1.Parameters.Add(New SqlParameter("@x3", TextBox8.Text))
        Try

            cm1.ExecuteNonQuery()
            dstran.Clear()
            adtran.Fill(dstran, "tran_IRT")
        Catch
            ''MsgBox("·«Ì„ﬂ‰ﬂ «·≈÷«›… ›«·”Ã· „ÊÃÊœ „”»ﬁ«", MsgBoxStyle.Critical, " ‰»Ì…")
            'Exit Sub
        End Try

    End Sub
    Sub update_action_ret()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        ''If sum_irct = 0 Then
        '    delet()
        'Else
        Dim s1 As String = "update acthion_tran set date_i=@x2,info=@x3 where info=@x3"
        Dim cm1 As New SqlCommand(s1, cn)
        cm1.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cm1.Parameters.Add(New SqlParameter("@x3", TextBox8.Text))
        Try
            cm1.ExecuteNonQuery()
            dsact.Clear()
            adact.Fill(dsact, "acthion_tran")
        Catch
            ''MsgBox("·«Ì„ﬂ‰ﬂ «·≈÷«›… ›«·”Ã· „ÊÃÊœ „”»ﬁ«", MsgBoxStyle.Critical, " ‰»Ì…")
            'Exit Sub
        End Try

        'End If

    End Sub
    ''======================================
    Sub delet_inf()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "delete from tran_IRT where n_rs=@x1 and date_i=@x2 "
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
        cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
        Try
            cm.ExecuteNonQuery()
            dstran.Clear()
            adtran.Fill(dstran, "tran_IRT")
            cn.Close()
        Catch

        End Try
    End Sub
    Sub delet_inf_acthion_tran()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "delete from acthion_tran where info=@x1 and date_i=@x2 "
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
        cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
        Try
            cm.ExecuteNonQuery()
            dstran.Clear()
            adtran.Fill(dstran, "acthion_tran")
            cn.Close()
        Catch

        End Try
    End Sub
    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If Me.TextBox8.Text.ToString = "" Then
            MsgBox(" «œŒ· —ﬁ„ ≈–‰ «” ·«„")
            Exit Sub
        Else

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If


            Dim s As String = "SELECT * FROM tran_IRT WHERE n_rs=@x1 and date_i=@x2 and tr_type=@x3"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
            cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
            cm.Parameters.Add(New SqlParameter("@x3", 3))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader

                If r.Read = True Then
                    MessageBoxEx.Show("·«Ì„ﬂ‰ «·Õ–› ·«‰Â  „ «·’—› „‰Â", "v1„Œ«“‰", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    clearing()
                    Exit Sub

                    r.Close()
                Else

                    ''MsgBox(" «–‰ «·’—› €Ì— „ÊÃÊœ ", MsgBoxStyle.Critical, " ‰»Ì…")
                    'Me.ButtonX1.Enabled = True
                    'Me.ButtonX2.Enabled = False

                    r.Close()
                End If
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try

            cn.Close()
            '=========================================
            Dim dd As Boolean
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s1 As String = "SELECT * FROM matt_return where no_i=@x1 and date_i=@x2"
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
            cm1.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
            Try
                Dim r As SqlDataReader = cm1.ExecuteReader

                If r.Read = True Then

                    dd = True
                    r.Close()
                Else

                    dd = False

                    r.Close()
                End If
                cn.Close()
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try

            If dd = True Then

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If


                Dim s2 As String = "delete from matt_return where no_i=@x1 and date_i=@x2"
                Dim cm2 As New SqlCommand(s2, cn)
                cm2.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
                cm2.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
                If MsgBox("Â· √‰  „ √ﬂœ „‰ ⁄„·Ì… Õ–›ﬂ ·Â–« «·«„— ø", MsgBoxStyle.YesNo, " √ﬂÌœ Õ–›") = MsgBoxResult.Yes Then
                    cm2.ExecuteNonQuery()
                    dsm.Clear()
                    adm.Fill(dsm, "matt_return")
                    delet_inf()
                    delet_inf_acthion_tran()
                    t_event = "Õ–›"
                    But_action_user()
                    clering_1()
                    view_lstn_i()
                    Me.TextBoxX3.Clear()
                    Me.TextBoxX1.Clear()
                Else
                    Exit Sub

                End If

                Try

                Catch
                    MsgBox("·«Ì„‹ﬂ‹‰ «·‹Õ‹–›", MsgBoxStyle.SystemModal, " ‰»Ì…")
                End Try
            Else
                Exit Sub
            End If
        End If

        view_lstn_i()
    End Sub

    Private Sub TextBox10_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox10.Validating
        If Me.TextBox10.Text = "" Then
            Me.TextBox10.Text = "0.000"
        End If
        Dim x As String
        x = man10(TextBox10.Text)
    End Sub

    Private Sub TextBox9_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox9.Validating
        If Me.TextBox9.Text = "" Then
            Me.TextBox9.Text = "0.000"
        End If
        Dim x As String
        x = man9(TextBox9.Text)
        TextBox10.Text = Val(TextBox6.Text) * Val(TextBox9.Text)
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Me.ButtonX5.Enabled = True
        Me.ButtonX7.Enabled = True
        Me.ButtonX6.Enabled = False
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'clearing()
        'Me.ButtonX6.Enabled = True
    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged
        If Me.TextBox10.Text = "" Then
            Me.TextBox10.Text = "0.000"
        End If
        Dim x As String
        x = man10(TextBox10.Text)
    End Sub


    'Sub l()
    '    Dim a As Integer
    '    a = Len(TextBox8.Text)
    '    If a = 1 Then
    '        Me.TextBox8.Text = ("000000" + Me.TextBox8.Text)
    '    End If
    '    If a = 2 Then
    '        Me.TextBox8.Text = ("00000" + Me.TextBox8.Text)
    '    End If
    '    If a = 3 Then
    '        Me.TextBox8.Text = ("0000" + Me.TextBox8.Text)
    '    End If
    '    If a = 4 Then
    '        Me.TextBox8.Text = ("000" + Me.TextBox8.Text)
    '    End If
    '    If a = 5 Then
    '        Me.TextBox8.Text = ("00" + Me.TextBox8.Text)
    '    End If
    '    If a = 6 Then
    '        Me.TextBox8.Text = ("0" + Me.TextBox8.Text)
    '    End If
    'End Sub

    Private Sub matt_return_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'l()
        auto_no()

        TextBoxX6.Text = Me.TextBox1.Text
        TextBoxX4.Text = Me.TextBox2.Text
        TextBox9.Text = Me.TextBox3.Text

        'xl = l_p(TextBox8.Text)
        'TextBox8.Text = xl
        'If sefa = "„—«ﬁ» «·„Œ“Ê‰" Or sefa = "«œ„‰" Then
        '    Me.ButtonX1.Visible = True
        '    Me.ButtonX2.Visible = True

        '    Me.ButtonX5.Enabled = False
        '    Me.ButtonX7.Enabled = False


        'Else
        '    Me.ButtonX1.Visible = False
        '    Me.ButtonX2.Visible = False

        '    Me.ButtonX5.Enabled = False
        '    Me.ButtonX7.Enabled = False

        'End If


        langarabic()
        Me.DateTimePicker1.Value = Now
        '======================
        'ada.Fill(dsa, "j_r")
        'Me.ComboBoxEx3.DataSource = dsa
        'ComboBoxEx3.DisplayMember = "j_r.name_r"
        'ComboBoxEx3.ValueMember = "no_r"

        If Me.TextBox10.Text = "" Then
            Me.TextBox10.Text = "0.000"
        End If
        'If Me.TextBox9.Text = "" Then
        '    Me.TextBox9.Text = "0.000"
        'End If
    End Sub

    Private Sub TextBox8_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox8.Validating
        If TextBox8.Text.ToString <> "" Then

            xl = l_p(TextBox8.Text)
            TextBox8.Text = xl
            ser_amr()
            view_lstn_i()
            'clearing()
        Else
            'clearing()
            Me.TextBoxX3.Clear()
            'TextBoxX1.Clear()
            'DataGridViewX2.DataMember = ""
            'DataGridViewX2.DataSource = Nothing
        End If
    End Sub

    Private Sub TextBox6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.Leave
        TextBox10.Text = Val(TextBox6.Text) * Val(TextBox9.Text)
    End Sub



    Private Sub TextBox6_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox6.Validating
        TextBox10.Text = Val(TextBox6.Text) * Val(TextBox9.Text)
    End Sub


    Private Sub TextBoxX1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX1.TextChanged

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim tr_tt As Boolean
        Dim s1 As String = "select * from tran_IRT where no_c=@x1 and date_i=@x3 and tr_type=@x4 and price=@x5 and tr_type=5"
        Dim cm1 As New SqlCommand(s1, cn)
        cm1.Parameters.Add(New SqlParameter("@x1", (TextBox8.Text)))
        cm1.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cm1.Parameters.Add(New SqlParameter("@x4", 3))
        cm1.Parameters.Add(New SqlParameter("@x5", TextBox9.Text))
        Try

            Dim r1 As SqlDataReader = cm1.ExecuteReader

            If r1.Read = True Then

                tr_tt = True

                r1.Close()
            Else
                r1.Close()
                tr_tt = False
            End If

        Catch

        End Try



        If tr_tt = False Then

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim s As String = "delete from matt_return where no_c=@x1 and no_i=@x2 and sal_s=@x3 and date_i=@x4"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", (TextBoxX6.Text)))
            cm.Parameters.Add(New SqlParameter("@x2", Me.TextBox8.Text))
            cm.Parameters.Add(New SqlParameter("@x3", TextBox9.Text))
            cm.Parameters.Add(New SqlParameter("@x4", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))

            If MsgBox("Â· √‰  „ √ﬂœ „‰ ⁄„·Ì… Õ–›ﬂ ·Â–« «·«„— ø", MsgBoxStyle.YesNo, " √ﬂÌœ Õ–›") = MsgBoxResult.Yes Then
                cm.ExecuteNonQuery()
                dsm.Clear()
                adm.Fill(dsm, "matt_return")
                Me.ButtonX5.Enabled = False
                Me.ButtonX7.Enabled = False
                '---------------------------------
                t_event = "Õ–› ’‰›"
                But_action_user()
                '----------------------------------
                delet()
                delet_action()
                stouck()
                clearing()
                Me.TextBox6.Clear()
                Me.TextBox9.Clear()
                Me.TextBox10.Clear()
                Me.TextBoxX1.Clear()
                Me.TextBoxX3.Clear()
                Me.TextBoxX5.Clear()

            Else
                MsgBox("·„   „ ⁄„·Ì… «·Õ–› ø", MsgBoxStyle.OkOnly, " √ﬂÌœ Õ–›")
                Exit Sub
            End If



        Else

            MessageBoxEx.Show("·« ” ÿÌ⁄ «·Õ–› ·«‰ «·’‰›   „ «·’—› „‰Â", "v1„Œ«“‰", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub
        End If


        view_lstn_i()
    End Sub

    Private Sub TextBoxX3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX3.TextChanged

    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged

    End Sub
End Class