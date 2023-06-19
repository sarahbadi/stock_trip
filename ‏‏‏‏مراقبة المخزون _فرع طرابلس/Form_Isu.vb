
Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form_Isu
    Dim qun, qt As Decimal
    Dim k As New matt_return
    Dim i As New Integer()
    Dim totinf As Decimal
    Dim fal As Boolean
    Dim move_no As String
    Dim tot, ft As Boolean
    Dim sum_irct, sum_iiss, sum_return, total_s, sum_talf As New Decimal()
    Dim siopb As Decimal
    Dim s As String = "select * from IsuSub"
    Dim adIsuS As New SqlDataAdapter(s, cn)
    Dim dsIsuS As New DataSet()
    '==================================
    Dim sj_s As String = "select * from j_s"
    Dim adaj_s As New SqlDataAdapter(sj_s, cn)
    Dim dsaj_s As New DataSet()

    Dim s1 As String = "select * from IsuMain"
    Dim adIsuM As New SqlDataAdapter(s1, cn)
    Dim dsIsuM As New DataSet()
   
    '===========================
    Dim s22 As String = "select * from acthion_tran"
    Dim adact As New SqlDataAdapter(s22, cn)
    Dim dsact As New DataSet()
    '======================================
    '======================================
    Dim smt As String = "select * from matt"
    Dim admt As New SqlDataAdapter(smt, cn)
    Dim dsmt As New DataSet()
    Dim TDmt As DataTable
    '===========================
    '======================================

    Dim stran As String = "select * from tran_IRT"
    Dim adtran As New SqlDataAdapter(stran, cn)
    Dim dstran As New DataSet()
    '========================

    Dim sT As String = "select * from Table_OSTA"
    Dim adIsuT As New SqlDataAdapter(sT, cn)
    Dim dsIsuST As New DataSet()


    Sub informa()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If TextBoxX3.Text <> "" Then
            Dim s As String = "select * from matt where no_c=@x1  "
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", (TextBoxX3.Text)))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader
                If r.Read = True Then
                    Me.TextBoxX4.Text = r!name_snc
                    fal = True
                    r.Close()
                Else

                    fal = False
                    'clear_a()
                    'Me.XpListView3.Enabled = False
                    'Me.XpListView3.Clear()
                    'Me.ButtonX1.Enabled = False
                    'Me.ButtonX2.Enabled = False
                    'Me.ButtonX3.Enabled = False
                    Me.LabelX1.Text = ""
                    r.Close()
                End If
                r.Close()
            Catch

            End Try
            '===================================================
        End If
        cn.Close()

        TextBoxX5.Clear()
        TextBoxX6.Text = 0
        TextBoxX1.Text = "0.00"
        TextBoxX7.Clear()
        TextBoxX2.Text = 0
    End Sub
    Sub view_l()
        cn.Close()
        XpListView3.Clear()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Try
            XpListView3.Clear()
            Dim da2 As New SqlDataAdapter
            Dim dr2 As DataRow
            Dim dt2 As DataTable
            Dim dsc = New DataSet

            XpListView3.Columns.Add("تاريخ الاستلام", 100, HorizontalAlignment.Center)
            XpListView3.Columns.Add("الكمية", 120, HorizontalAlignment.Center)
            XpListView3.Columns.Add("السعر ", 100, HorizontalAlignment.Center)
            XpListView3.Columns.Add("اذن الاستلام", 0, HorizontalAlignment.Center)
            Dim sdl As Short = 1
            'and state_ins='" + n1 + "'
            Dim sql As String = "select * from acthion_tran where acthion_tran.[no_c] ='" + TextBoxX3.Text + "' and qun_tot<>0"
            da2 = New SqlDataAdapter(sql, cn)
            da2.Fill(dsc, "acthion_tran ")
            dt2 = dsc.Tables("acthion_tran ")
            Dim i As Integer
            For i = 0 To dt2.Rows.Count - 1
                Dim litem As New XPListViewItem
                dr2 = dt2.Rows.Item(i)
                litem.Text = dt2.Rows(i).Item("date_i")
                litem.SubItems.Add(dt2.Rows(i).Item("qun_tot"))
                litem.SubItems.Add(dt2.Rows(i).Item("sal_s"))
                litem.SubItems.Add(dt2.Rows(i).Item("info"))
                XpListView3.Items.Add(litem)
            Next
            XpListView3.View = Windows.Forms.View.Details
            Me.ListView2.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        cn.Close()
    End Sub
    Sub view_l_0()
        cn.Close()
        XpListView3.Clear()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Try
            XpListView3.Clear()
            Dim da2 As New SqlDataAdapter
            Dim dr2 As DataRow
            Dim dt2 As DataTable
            Dim dsc = New DataSet

            XpListView3.Columns.Add("تاريخ الاستلام", 120, HorizontalAlignment.Center)
            XpListView3.Columns.Add("الكمية", 130, HorizontalAlignment.Center)
            XpListView3.Columns.Add("السعر ", 100, HorizontalAlignment.Center)
            XpListView3.Columns.Add("اذن الاستلام", 0, HorizontalAlignment.Center)
            'XpListView3.Columns.Add("ملاحظات ", 0, HorizontalAlignment.Left)
            Dim sdl As Short = 1
            'and state_ins='" + n1 + "'
            Dim sql As String = "select * from acthion_tran where acthion_tran.[no_c] ='" + TextBoxX3.Text + "'"
            da2 = New SqlDataAdapter(sql, cn)
            da2.Fill(dsc, "acthion_tran ")
            dt2 = dsc.Tables("acthion_tran ")
            Dim i As Integer
            For i = 0 To dt2.Rows.Count - 1
                Dim litem As New XPListViewItem
                dr2 = dt2.Rows.Item(i)
                litem.Text = dt2.Rows(i).Item("date_i")
                litem.SubItems.Add(dt2.Rows(i).Item("qun_tot"))
                litem.SubItems.Add(dt2.Rows(i).Item("sal_s"))
                litem.SubItems.Add(dt2.Rows(i).Item("info"))
                ''litem.SubItems.Add(dt2.Rows(i).Item("mt"))
                XpListView3.Items.Add(litem)
            Next
            XpListView3.View = Windows.Forms.View.Details
            Me.ListView2.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        cn.Close()
    End Sub

    Private Sub XpListView3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XpListView3.SelectedIndexChanged
        Dim litem As XPListViewItem
        TextBox3.Clear()
        TextBox5.Clear()
        For Each litem In XpListView3.SelectedItems
            TextBoxX5.Text = litem.SubItems(0).Text
            TextBoxX6.Text = litem.SubItems(1).Text
            TextBoxX1.Text = litem.SubItems(2).Text
            TextBoxX7.Text = litem.SubItems(3).Text
        Next
        matt_on()
    End Sub



    Sub matt_on()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s11 As String = "SELECT * FROM cop_osta WHERE no_c=@x1 and  no_i=@x2 and date_i=@x3 and sal_s=@x4"
        Dim cm As New SqlCommand(s11, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBoxX3.Text))
        cm.Parameters.Add(New SqlParameter("@x2", TextBoxX7.Text))
        cm.Parameters.Add(New SqlParameter("@x3", CDate(TextBoxX5.Text)))
        cm.Parameters.Add(New SqlParameter("@x4", TextBoxX1.Text))
        Try



            Dim r As SqlDataReader = cm.ExecuteReader
            If r.Read = True Then
                TextBox3.Text = r!qun_r
                TextBox5.Text = r!name_r
                r.Close()
            Else
                r.Close()
            End If
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try
        cn.Close()
    End Sub

    Sub clearing()
        TextBoxX5.Clear()
        TextBoxX6.Text = 0
        TextBoxX1.Text = "0.00"
        TextBoxX7.Clear()
        TextBoxX2.Text = 0
        TextBoxX3.Clear()
        TextBoxX4.Clear()
    End Sub

    Sub update_action_transrf_up()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        ''If sum_irct = 0 Then
        '    delet()
        'Else
        Dim s1 As String = "update acthion_tran set qun_tot=@x1,date_i=@x2,info=@x3 where info=@x3 and date_i=@x2 and no_c=@x4 and sal_s=@x5 "
        Dim cm1 As New SqlCommand(s1, cn)
        cm1.Parameters.Add(New SqlParameter("@x1", CDec(qt)))
        cm1.Parameters.Add(New SqlParameter("@x2", CDate(TextBoxX5.Text)))
        cm1.Parameters.Add(New SqlParameter("@x3", TextBoxX7.Text))
        cm1.Parameters.Add(New SqlParameter("@x4", Me.TextBoxX3.Text))
        cm1.Parameters.Add(New SqlParameter("@x5", TextBoxX1.Text))
        Try
            cm1.ExecuteNonQuery()
            dsact.Clear()
            adact.Fill(dsact, "acthion_tran")
        Catch
            ''MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
            'Exit Sub
        End Try
        cn.Close()
    End Sub
    Sub update_action_transrf()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        ''If sum_irct = 0 Then
        '    delet()
        'Else
        Dim s1 As String = "update acthion_tran set qun_tot=@x1,date_i=@x2,info=@x3 where info=@x3 and date_i=@x2 and no_c=@x4 and sal_s=@x5 "
        Dim cm1 As New SqlCommand(s1, cn)
        cm1.Parameters.Add(New SqlParameter("@x1", CDec(qun)))
        cm1.Parameters.Add(New SqlParameter("@x2", CDate(TextBoxX5.Text)))
        cm1.Parameters.Add(New SqlParameter("@x3", TextBoxX7.Text))
        cm1.Parameters.Add(New SqlParameter("@x4", Me.TextBoxX3.Text))
        cm1.Parameters.Add(New SqlParameter("@x5", TextBoxX1.Text))
        Try
            cm1.ExecuteNonQuery()
            dsact.Clear()
            adact.Fill(dsact, "acthion_tran")
        Catch
            ''MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
            'Exit Sub
        End Try
        cn.Close()
    End Sub
    '=============================المصروفات
    Sub stouck()
        If Me.TextBoxX3.Text <> "" Then


            Dim i, w As Integer
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim sql As String = "select no_c,qun_r from RcvSub where RcvSub.no_c ='" + TextBoxX3.Text + "'"
            Dim ad1 As New SqlDataAdapter(sql, cn)
            Dim ds1 As New DataSet()
            Dim TD1 As DataTable
            Dim DROW1 As DataRow
            Dim y As Decimal
            y = 0.0
            sum_irct = 0.0
            ad1.Fill(ds1, sql)
            TD1 = ds1.Tables(sql)

            For i = 0 To TD1.Rows.Count - 1
                DROW1 = TD1.Rows(i)
                If DROW1("no_c") = (TextBoxX3.Text) Then

                    y = Val(DROW1("qun_r"))
                    sum_irct = sum_irct + y
                End If
            Next

            cn.Close()
            '===============اجمالي المصروف==================

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim sq3 As String = "select * from IsuSub where IsuSub.[no_c] ='" + TextBoxX3.Text + "'"

            Dim ad3 As New SqlDataAdapter(sq3, cn)
            Dim ds3 As New DataSet()
            Dim TD3 As DataTable
            Dim DROW3 As DataRow
            Dim y2 As Decimal
            Me.sum_iiss = 0.0
            y2 = 0.0
            ad3.Fill(ds3, sq3)
            TD3 = ds3.Tables(sq3)

            For w = 0 To TD3.Rows.Count - 1
                DROW3 = TD3.Rows(w)
                If DROW3("no_c") = (TextBoxX3.Text) Then

                    y2 = Val(DROW3("qun_s"))
                    sum_iiss = sum_iiss + y2

                End If
            Next


            cn.Close()
            '===============اجمالي مرتجعه==================


            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim sq4 As String = "select * from matt_return where matt_return.[no_c] ='" + TextBoxX3.Text + "'"

            Dim ad4 As New SqlDataAdapter(sq4, cn)
            Dim ds4 As New DataSet()
            Dim TD4 As DataTable
            Dim DROW4 As DataRow
            Dim y4 As Decimal
            sum_return = 0.0
            y4 = 0.0
            ad4.Fill(ds4, sq4)
            TD4 = ds4.Tables(sq4)

            For w = 0 To TD4.Rows.Count - 1
                DROW4 = TD4.Rows(w)

                If DROW4("no_c") = (TextBoxX3.Text) Then

                    y4 = Val(DROW4("qun_t"))
                    sum_return = sum_return + y4

                End If
            Next
            cn.Close()


            total_s = 0
            Me.LabelX1.Text = 0

            '===============تالف==================
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim sq5 As String = "select * from sub_TALEF where sub_TALEF.[no_c] ='" + TextBoxX3.Text + "'"

            Dim ad5 As New SqlDataAdapter(sq5, cn)
            Dim ds5 As New DataSet()
            Dim TD5 As DataTable
            Dim DROW5 As DataRow
            Dim y5 As Decimal
            sum_talf = 0.0
            y5 = 0.0
            ad5.Fill(ds5, sq5)
            TD5 = ds5.Tables(sq5)

            For w = 0 To TD5.Rows.Count - 1
                DROW5 = TD5.Rows(w)

                If DROW5("no_c") = (TextBoxX3.Text) Then

                    y5 = Val(DROW5("qun_T"))
                    sum_talf = sum_talf + y5

                End If
            Next
            cn.Close()
            Me.total_s = 0


            Me.total_s = ((sum_irct + sum_return) - sum_iiss) - sum_talf
          
            '=======================================================
            Me.LabelX1.Text = 0
            Me.LabelX1.Text = total_s
            '=======================================================

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            i = 0
            Dim s1 As String = "update  matt set no_c=@x1,balance=@x2,iiss=@x4 where no_c=@x1"
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", TextBoxX3.Text))
            cm1.Parameters.Add(New SqlParameter("@x2", total_s))
            cm1.Parameters.Add(New SqlParameter("@x4", sum_iiss))
            Try
                cm1.ExecuteNonQuery()
                dsmt.Clear()
                admt.Fill(dsmt, " matt")
            Catch
            End Try
        End If
        cn.Close()
    End Sub

    Sub couny_sal()
        Dim s As String = "select * from IsuSub where IsuSub.count1=(select max(count1) from IsuSub)"
        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "IsuSub")
        tb = ds.Tables(0)
        Dim dr As DataRow
        Try
            dr = tb.Rows(0)
            sal_st = dr(5) + 1
        Catch ex As Exception
            sal_st = "1"
        End Try
        ad.Dispose()
        ds.Dispose()
    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        If Me.TextBox6.Text.ToString <> "" Then
            ser_amr()
            If ft = False Then
                If Me.ComboBox1.SelectedValue = -1 Or ComboBox1.Text = "" Then
                    MsgBox("اختار جهة الصرف ", MsgBoxStyle.Information, "إجراء إضافة")
                    Exit Sub
                End If
                If Me.DateTimePicker1.Value.Year <> Me.dtYear.Value.Year Then
                    MessageBox.Show("تاريخ الصرف غير متوافق مع سنة الادخال")
                    Exit Sub
                End If
                If Me.TextBox7.Text.ToString = "" Then
                    MsgBox(" ادخل رئيس وحدة المخازن والتكاليف ", MsgBoxStyle.Information, "إجراء إضافة")
                    TextBoxX2.Focus()
                    Exit Sub
                End If
                If Me.TextBox4.Text.ToString = "" Then
                    MsgBox(" ادخل اسم المستلم ", MsgBoxStyle.Information, "إجراء إضافة")
                    TextBoxX2.Focus()
                    Exit Sub
                End If
                '============================
                Dim s5 As String = "insert into IsuMain(no_s,date_s,j_s,total,u_name,tvg,dep_m,dep_mt,dep_nom,name_stock,name1_stock) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9,@x10,@x11)"

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim cm5 As New SqlCommand(s5, cn)
                cm5.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
                cm5.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
                cm5.Parameters.Add(New SqlParameter("@x3", Me.ComboBox1.SelectedValue))
                cm5.Parameters.Add(New SqlParameter("@x4", 0))
                cm5.Parameters.Add(New SqlParameter("@x5", ww))
                cm5.Parameters.Add(New SqlParameter("@x6", 0))
                cm5.Parameters.Add(New SqlParameter("@x7", False))
                cm5.Parameters.Add(New SqlParameter("@x8", ""))
                cm5.Parameters.Add(New SqlParameter("@x9", True))
                cm5.Parameters.Add((New SqlParameter("@x10", TextBox7.Text)))
                cm5.Parameters.Add((New SqlParameter("@x11", TextBox4.Text)))

                Try
                    cm5.ExecuteNonQuery()
                    dsIsuM.Clear()
                    adIsuM.Fill(dsIsuM, "IsuMain")
                    cn.Close()
                Catch
                    ''MsgBox(" اذن الصرف موجود مسبقا", MsgBoxStyle.Critical, "تنبية")
                    Exit Sub
                End Try
            End If
            '===================

            If TextBox6.Text = "" Then
                MsgBox("أدخل أذن الصرف ", MsgBoxStyle.Information, "إجراء إضافة")
                TextBox6.Focus()
                Exit Sub
            End If
            If Me.TextBoxX3.Text = "" Then
                MsgBox("أدخل رقم الصنف ", MsgBoxStyle.Information, "إجراء إضافة")
                TextBoxX3.Focus()
                Exit Sub
            End If
            If Me.TextBoxX2.Text.ToString = "" Or Me.TextBoxX2.Text.ToString = 0 Then
                MsgBox("أدخل الكمية ", MsgBoxStyle.Information, "إجراء إضافة")
                TextBoxX2.Focus()
                Exit Sub
            End If

            If Me.TextBoxX1.Text.ToString = "" Or Me.TextBoxX1.Text.ToString = "0.00" Or "0.0" Or "0" Or Me.TextBoxX5.Text.ToString = "" Or Me.TextBoxX7.Text.ToString = "" Then
                MsgBox("انقر على المخزن لتحديد السعر  ", MsgBoxStyle.Information, "إجراء إضافة")
                Exit Sub
            End If
           


            If Me.TextBox7.Text.ToString = "" Then
                MsgBox(" ادخل رئيس وحدة المخازن والتكاليف ", MsgBoxStyle.Information, "إجراء إضافة")
                TextBoxX2.Focus()
                Exit Sub
            End If
            If Me.TextBox4.Text.ToString = "" Then
                MsgBox(" ادخل اسم المستلم ", MsgBoxStyle.Information, "إجراء إضافة")
                TextBoxX2.Focus()
                Exit Sub
            End If
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            qun = 0
            qun = (CDec(Me.TextBoxX6.Text) - CDec(Me.TextBoxX2.Text))
            If CDec(Me.TextBoxX2.Text) > CDec(Me.TextBoxX6.Text) Then
                MessageBoxEx.Show("لاتستطيع الصرف لان الكمية المستلمة اقل من الكميه المصروفة", "مراقبة المخزون", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                couny_sal()

                '===============
                Dim Trans As SqlTransaction = cn.BeginTransaction
                Try

                    Dim s As String = "insert into IsuSub(no_s,no_c,qun_s,sal_s,gema,count1,mt,q_div) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8)"
                    Dim cm As New SqlCommand(s, cn)
                    cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
                    cm.Parameters.Add(New SqlParameter("@x2", Trim(TextBoxX3.Text)))
                    cm.Parameters.Add(New SqlParameter("@x3", TextBoxX2.Text))

                    cm.Parameters.Add(New SqlParameter("@x4", CDec(TextBoxX1.Text)))
                    cm.Parameters.Add(New SqlParameter("@x5", CDec(Val(TextBoxX2.Text) * CDec(TextBoxX1.Text))))
                    cm.Parameters.Add(New SqlParameter("@x6", sal_st))
                    If Me.RichTextBox1.Text = "" Then
                        cm.Parameters.Add(New SqlParameter("@x7", "لايوجد"))
                    Else
                        cm.Parameters.Add(New SqlParameter("@x7", Me.RichTextBox1.Text))
                    End If
                    'cm.Parameters.Add(New SqlParameter("@x7", Me.RichTextBoxEx1.Text))

                    Me.TextBox1.Text = CDec(Me.TextBoxX6.Text) - CDec(Me.TextBoxX2.Text)
                    If TextBox1.Text = "" Then
                        cm.Parameters.Add(New SqlParameter("@x8", 0))
                    Else
                        cm.Parameters.Add(New SqlParameter("@x8", CDec(TextBox1.Text)))
                    End If
                    cm.Transaction = Trans
                    cm.ExecuteNonQuery()
                    '========update_action_transrf========================
                    Dim s1 As String = "update acthion_tran set qun_tot=@x1,date_i=@x2,info=@x3 where info=@x3 and date_i=@x2 and no_c=@x4 and sal_s=@x5 "
                    Dim cm1 As New SqlCommand(s1, cn)
                    cm1.Parameters.Add(New SqlParameter("@x1", CDec(qun)))
                    cm1.Parameters.Add(New SqlParameter("@x2", CDate(TextBoxX5.Text)))
                    cm1.Parameters.Add(New SqlParameter("@x3", Trim(TextBoxX7.Text)))
                    cm1.Parameters.Add(New SqlParameter("@x4", Trim(Me.TextBoxX3.Text)))
                    cm1.Parameters.Add(New SqlParameter("@x5", TextBoxX1.Text))
                    cm1.Transaction = Trans
                    cm1.ExecuteNonQuery()
                    '===============================smove_no_s==================
                    Dim sx As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i,count1) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7)"
                    Dim cmx As New SqlCommand(sx, cn)
                    cmx.Parameters.Add(New SqlParameter("@x1", Trim(TextBoxX3.Text)))
                    cmx.Parameters.Add(New SqlParameter("@x2", CDec(TextBoxX2.Text)))
                    cmx.Parameters.Add(New SqlParameter("@x3", CDec(TextBoxX1.Text)))
                    cmx.Parameters.Add(New SqlParameter("@x4", 3))
                    cmx.Parameters.Add(New SqlParameter("@x5", Trim(TextBox6.Text)))
                    cmx.Parameters.Add(New SqlParameter("@x6", CDate(TextBoxX5.Text)))
                    cmx.Parameters.Add(New SqlParameter("@x7", sal_st))
                    cmx.Transaction = Trans
                    cmx.ExecuteNonQuery()
                    '=================================action_user============

                    t_event = "حفظ صنف"
                    But_action_user()
                    t_doc = "اذن الصرف"
                    ts = TimeOfDay

                    Dim sc As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                    Dim cmc As New SqlCommand(sc, cn)
                    cmc.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
                    cmc.Parameters.Add(New SqlParameter("@x2", t_doc))
                    cmc.Parameters.Add(New SqlParameter("@x3", Trim(TextBoxX3.Text)))
                    cmc.Parameters.Add(New SqlParameter("@x4", CDec(Me.TextBoxX2.Text)))
                    cmc.Parameters.Add(New SqlParameter("@x5", TextBoxX1.Text))
                    cmc.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
                    cmc.Parameters.Add(New SqlParameter("@x7", ts))
                    cmc.Parameters.Add(New SqlParameter("@x8", ww))
                    cmc.Parameters.Add(New SqlParameter("@x9", t_event))
                    cmc.Transaction = Trans
                    cmc.ExecuteNonQuery()
                    '=====================
                    TextBox2.Text = Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")
                    '=====================================Table_OSTA==============
                    Dim s22 As String = "insert into Table_OSTA(no_I,no_c,date_I,qI,sal_s,date_r,no_R,qR) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8)"
                    Dim cm22 As New SqlCommand(s22, cn)
                    cm22.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
                    cm22.Parameters.Add(New SqlParameter("@x2", Trim(TextBoxX3.Text)))
                    cm22.Parameters.Add(New SqlParameter("@x3", CDate(TextBox2.Text)))
                    cm22.Parameters.Add(New SqlParameter("@x4", CDec(TextBoxX2.Text)))
                    cm22.Parameters.Add(New SqlParameter("@x5", CDec(TextBoxX1.Text)))
                    cm22.Parameters.Add(New SqlParameter("@x6", CDate(TextBoxX5.Text)))
                    cm22.Parameters.Add(New SqlParameter("@x7", Me.TextBoxX7.Text))
                    cm22.Parameters.Add(New SqlParameter("@x8", (TextBox3.Text)))
                    cm22.Transaction = Trans
                    cm22.ExecuteNonQuery()

                    '===================================================================

                    Trans.Commit()
                    MsgBox("تم صرف الكمية", MsgBoxStyle.Information, " مراقبة المخزون")
                    cn.Close()
                    clear_a()
                Catch err As System.Exception

                    Trans.Rollback()
                    MsgBox("لم يتم صرف الكمية", MsgBoxStyle.Information, " مراقبة المخزون")
                    MsgBox(err.Message)
                    cn.Close()
                Finally
                End Try


             
            End If


        Else

            clear_a()
            Me.ListView2.Clear()
        End If

        ListView2.Sorting = SortOrder.Ascending
        stouck()
        ser_amr()
        view_l()
    End Sub
    Sub But_action_user()
        t_event = "حذف صنف"
        t_doc = "اذن الصرف"
        ts = TimeOfDay

        If cn.State = ConnectionState.Closed Then
            cn.Open()

        End If

        Dim s As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
        cm.Parameters.Add(New SqlParameter("@x2", t_doc))
        cm.Parameters.Add(New SqlParameter("@x3", TextBoxX3.Text))
        cm.Parameters.Add(New SqlParameter("@x4", CDec(Me.TextBoxX2.Text)))
        cm.Parameters.Add(New SqlParameter("@x5", TextBoxX1.Text))
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
    Sub smove_no_s()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i,count1) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7)"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBoxX3.Text))
        cm.Parameters.Add(New SqlParameter("@x2", CDec(TextBoxX2.Text)))
        cm.Parameters.Add(New SqlParameter("@x3", CDec(TextBoxX1.Text)))
        cm.Parameters.Add(New SqlParameter("@x4", 3))
        cm.Parameters.Add(New SqlParameter("@x5", TextBox6.Text))
        cm.Parameters.Add(New SqlParameter("@x6", CDate(TextBoxX5.Text)))
        cm.Parameters.Add(New SqlParameter("@x7", sal_st))

        Try
            cm.ExecuteNonQuery()
            dstran.Clear()
            adtran.Fill(dstran, "tran_IRT")

        Catch

        End Try

    End Sub
    Private Sub update_tran()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s1 As String = "update tran_IRT set n_rs='" & TextBox6.Text & "' , no_c='" + TextBoxX3.Text + "' , quntity=" & Me.TextBoxX2.Text & "  where n_rs='" & TextBox6.Text & "' and no_c ='" + TextBoxX3.Text + "' And price = " & TextBoxX1.Text & " And count1= " & LabelX2.Text & " And tr_type = " & 3 & ""
        Dim cm1 As New SqlCommand(s1, cn)
        cm1.ExecuteNonQuery()
        dstran.Clear()
        adtran.Fill(dstran, "tran_IRT")
        cn.Close()
    End Sub

    Sub no_sup()


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim scn As String = "SELECT no_s, SUBSTRING(no_s, 1, 4) AS s_no FROM IsuMain where no_s=@x1 and date_s=@x3 "
        Dim cmcn As New SqlCommand(scn, cn)
        cmcn.Parameters.Add(New SqlParameter("@x1", CStr(TextBox6.Text)))
        cmcn.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker2.Value.Date, "yyyy/MM/dd")))

        Try
            Dim r1cn As SqlDataReader = cmcn.ExecuteReader
            If r1cn.Read = True Then

                Label20.Text = r1cn!s_no.ToString
                r1cn.Close()
                cn.Close()
                Exit Sub

            Else
                r1cn.Close()
                cn.Close()
            End If
            r1cn.Close()
        Catch

        End Try
        cn.Close()
    End Sub
    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click



        If (Me.ListView2.Items.Count = 0) Then
            MsgBox(" اذن الصرف فارغ ", MsgBoxStyle.Information, " إجراء تعديل")
            Exit Sub
        End If



        Label20.Text = ""
        If (Me.TextBoxX3.Text.ToString) <> "" Then

            qt = 0

            If Me.TextBoxX2.Text = "" Or Me.TextBoxX2.Text = 0 Then
                MsgBox("ادخل الكمية المصروفه ", MsgBoxStyle.Information, "إجراء تعديل")
                TextBoxX2.Focus()
                Exit Sub
            End If
            '==============qt الكمية الباقيه
            qt = CDec(Me.TextBoxX6.Text) + CDec(Me.TextBoxX8.Text)

            If CDec(Me.TextBoxX2.Text) > CDec(qt) Then
                MessageBoxEx.Show("لاتستطيع التعديل لان الكمية المستلمة اقل من الكميه المصروفة", "مراقبه المخزون", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                qt = CDec(qt) - CDec(Me.TextBoxX2.Text)

            End If

            If Me.TextBox7.Text.ToString = "" Then
                MsgBox(" ادخل رئيس وحدة المخازن والتكاليف ", MsgBoxStyle.Information, "إجراء تعديل")
                TextBoxX2.Focus()
                Exit Sub
            End If
            If Me.TextBox4.Text.ToString = "" Then
                MsgBox(" ادخل اسم المستلم ", MsgBoxStyle.Information, "إجراء تعديل")
                TextBoxX2.Focus()
                Exit Sub
            End If
            '======== =================================     
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If


            Dim Trans As SqlTransaction = cn.BeginTransaction


            Try



                Dim su As String = "update IsuMain set no_s=@x1,date_s=@x2,j_s=@x3,tvg=@x4,name_stock=@x5,name1_stock=@x6 where no_s=@x1"
                Dim cmu As New SqlCommand(su, cn)
                cmu.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
                cmu.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
                cmu.Parameters.Add(New SqlParameter("@x3", Me.ComboBox1.SelectedValue))
                cmu.Parameters.Add(New SqlParameter("@x4", 0))
                cmu.Parameters.Add(New SqlParameter("@x5", TextBox7.Text))
                cmu.Parameters.Add(New SqlParameter("@x6", TextBox4.Text))
                cmu.Transaction = Trans
                cmu.ExecuteNonQuery()
                '=====================

                Dim s As String = "update IsuSub set qun_s=" & Me.TextBoxX2.Text & ",gema=" & (TextBoxX2.Text) * CDec(TextBoxX1.Text) & ",q_div=" & Me.qt & ",mt='" & Me.RichTextBox1.Text & "' where no_s='" & TextBox6.Text & "' and no_c='" & Me.TextBoxX3.Text & "' and sal_s=" & Me.TextBoxX1.Text & " and count1 =" & Me.LabelX2.Text & ""

                Dim cm As New SqlCommand(s, cn)
                cm.Transaction = Trans
                cm.ExecuteNonQuery()

                '---------------------------------


                Dim s1 As String = "update acthion_tran set qun_tot=@x1,date_i=@x2,info=@x3 where info=@x3 and date_i=@x2 and no_c=@x4 and sal_s=@x5 "
                Dim cm1 As New SqlCommand(s1, cn)
                cm1.Parameters.Add(New SqlParameter("@x1", CDec(qt)))
                cm1.Parameters.Add(New SqlParameter("@x2", CDate(TextBoxX5.Text)))
                cm1.Parameters.Add(New SqlParameter("@x3", TextBoxX7.Text))
                cm1.Parameters.Add(New SqlParameter("@x4", Me.TextBoxX3.Text))
                cm1.Parameters.Add(New SqlParameter("@x5", TextBoxX1.Text))
                cm1.Transaction = Trans
                cm1.ExecuteNonQuery()

                '---------------------------------



                Dim sa As String = "update tran_IRT set n_rs='" & TextBox6.Text & "' , no_c='" + TextBoxX3.Text + "' , quntity=" & Me.TextBoxX2.Text & "  where n_rs='" & TextBox6.Text & "' and no_c ='" + TextBoxX3.Text + "' And price = " & TextBoxX1.Text & " And count1= " & LabelX2.Text & " And tr_type = " & 3 & ""
                Dim cma As New SqlCommand(sa, cn)
                cma.Transaction = Trans
                cma.ExecuteNonQuery()


                '---------------------------------
                t_event = "تعديل صنف"
                But_action_user()
                '----------------------------------

                Dim s22 As String = "update Table_OSTA set qI=@x4 where no_I=@x1 and no_c=@x2 and date_I=@x3 and qI=" & TextBoxX8.Text & " and sal_s=@x5 and date_r=@x6 and no_R=@x7"
                Dim cm22 As New SqlCommand(s22, cn)
                cm22.Parameters.Add(New SqlParameter("@x1", TextBox6.Text))
                cm22.Parameters.Add(New SqlParameter("@x2", TextBoxX3.Text))
                cm22.Parameters.Add(New SqlParameter("@x3", CDate(TextBox2.Text)))
                cm22.Parameters.Add(New SqlParameter("@x4", TextBoxX2.Text))
                cm22.Parameters.Add(New SqlParameter("@x5", CDec(TextBoxX1.Text)))
                cm22.Parameters.Add(New SqlParameter("@x6", CDate(TextBoxX5.Text)))
                cm22.Parameters.Add(New SqlParameter("@x7", Me.TextBoxX7.Text))
                cm22.Transaction = Trans
                cm22.ExecuteNonQuery()
                '===================================================================

                Trans.Commit()
                MsgBox("تم تعديل الكمية", MsgBoxStyle.Information, " مراقبة المخزون")
            Catch err As System.Exception

                Trans.Rollback()
                MsgBox("لم يتم تعديل الكمية", MsgBoxStyle.Information, " مراقبة المخزون")
                MsgBox(err.Message)

            Finally
            End Try

            clearing()
            Me.XpListView3.Clear()
            Me.LabelX1.Text = ""
            ListView2.Sorting = SortOrder.Ascending
            ser_amr()
            stouck()
            Me.TextBoxX8.Clear()
            cn.Close()
        Else

            no_sup()
            If Me.DateTimePicker1.Value.Year <> Me.Label20.Text Then
                MessageBox.Show("تاريخ الصرف غير متوافق مع سنة الادخال")
                Label20.Text = ""
                cn.Close()
                Exit Sub
            End If
            '======================================


            'If Me.TextBox7.Text.ToString = "" Then
            '    MsgBox(" ادخل رئيس وحدة المخازن والتكاليف ", MsgBoxStyle.Information, "إجراء تعديل")
            '    TextBoxX2.Focus()
            '    Exit Sub
            'End If
            'If Me.TextBox4.Text.ToString = "" Then
            '    MsgBox(" ادخل اسم المستلم ", MsgBoxStyle.Information, "إجراء تعديل")
            '    TextBoxX2.Focus()
            '    Exit Sub
            'End If


            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim Trans As SqlTransaction = cn.BeginTransaction


            Try

                Dim su As String = "update IsuMain set no_s=@x1,date_s=@x2,j_s=@x3,tvg=@x4,name_stock=@x5,name1_stock=@x6 where no_s=@x1"
                Dim cmu As New SqlCommand(su, cn)
                cmu.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
                cmu.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
                cmu.Parameters.Add(New SqlParameter("@x3", Me.ComboBox1.SelectedValue))
                cmu.Parameters.Add(New SqlParameter("@x4", 0))
                cmu.Parameters.Add(New SqlParameter("@x5", TextBox7.Text))
                cmu.Parameters.Add(New SqlParameter("@x6", TextBox4.Text))
                cmu.Transaction = Trans

                'Try

                cmu.ExecuteNonQuery()
                'MsgBox(" تم تعديل اذن الاستلام ", MsgBoxStyle.Information, " مراقبة المخزون")
                '    dsIsuM.Clear()
                '    adIsuM.Fill(dsIsuM, "IsuMain")
                '    cn.Close()
                'Catch ex As Exception

                'End Try
                'cn.Close()
                '---------------------------------
                'If cn.State = ConnectionState.Closed Then
                '    cn.Open()
                'End If

                'Dim srs As String = "update tran_IRT set date_i=@x2 where(tr_type=3) and n_rs=@x1"
                'Dim cmrs As New SqlCommand(srs, cn)

                'cmrs.Parameters.Add(New SqlParameter("@x1", CStr(TextBox6.Text)))
                'cmrs.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
                'cmrs.Transaction = Trans
                'cmrs.ExecuteNonQuery()
                'cn.Close()
                '---------------------------------
                'If cn.State = ConnectionState.Closed Then
                '    cn.Open()
                'End If

                Dim srw As String = "update Table_OSTA set date_I=@x2 where no_I=@x1"
                Dim cmrw As New SqlCommand(srw, cn)

                cmrw.Parameters.Add(New SqlParameter("@x1", CStr(TextBox6.Text)))
                cmrw.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
                cmrw.Transaction = Trans
                cmrw.ExecuteNonQuery()
                'cn.Close()


                '======================================
                'If cn.State = ConnectionState.Closed Then
                '    cn.Open()
                'End If
                t_doc = "اذن الصرف"
                ts = TimeOfDay
                t_event = "تعديل"

                Dim sf As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim cmf As New SqlCommand(sf, cn)
                cmf.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
                cmf.Parameters.Add(New SqlParameter("@x2", t_doc))
                cmf.Parameters.Add(New SqlParameter("@x3", 0))
                cmf.Parameters.Add(New SqlParameter("@x4", 0))
                cmf.Parameters.Add(New SqlParameter("@x5", 0))
                cmf.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
                cmf.Parameters.Add(New SqlParameter("@x7", ts))
                cmf.Parameters.Add(New SqlParameter("@x8", ww))
                cmf.Parameters.Add(New SqlParameter("@x9", t_event))
                cmf.Transaction = Trans
                cmf.ExecuteNonQuery()
                'cn.Close()
                'MsgBox("تم تعديل ", MsgBoxStyle.Information, "تم تعديل اذن الصرف ")

                '----------------------------------
                Trans.Commit()
                MsgBox(" تم تعديل اذن الصرف ", MsgBoxStyle.Information, " مراقبة المخزون")
                cn.Close()
            Catch err As System.Exception

                Trans.Rollback()
                MsgBox("لم يتم تعديل الكمية اذن الصرف", MsgBoxStyle.Information, " مراقبة المخزون")
                MsgBox(err.Message)
                cn.Close()

            Finally
            End Try
        End If
        ser_amr()
    End Sub
    Sub delet_tran()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "delete from tran_IRT where no_c=@x1 and date_i=@x2 and n_rs=@x3 and tr_type=@x4 and quntity=@x5 and price=@x6 and count1= " & LabelX2.Text & ""
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBoxX3.Text))
        cm.Parameters.Add(New SqlParameter("@x2", CDate(Me.TextBoxX5.Text)))
        cm.Parameters.Add(New SqlParameter("@x3", TextBox6.Text))
        cm.Parameters.Add(New SqlParameter("@x4", 3))
        cm.Parameters.Add(New SqlParameter("@x5", CDec(TextBoxX2.Text)))
        cm.Parameters.Add(New SqlParameter("@x6", TextBoxX1.Text))
        Try
            cm.ExecuteNonQuery()
            dstran.Clear()
            adtran.Fill(dstran, "tran_IRT")
        Catch

        End Try

    End Sub
    Sub delet_action_t()

        '============================================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "delete from acthion_tran where no_c=@x1 and info=@x2 and sal_s=@x3 and date_i=@x4 and date_i=@x5"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBoxX3.Text))
        cm.Parameters.Add(New SqlParameter("@x2", TextBoxX7.Text))
        cm.Parameters.Add(New SqlParameter("@x3", (Me.TextBoxX1.Text)))
        cm.Parameters.Add(New SqlParameter("@x4", CDate((Me.TextBoxX5.Text))))
        cm.Parameters.Add(New SqlParameter("@x5", (Me.TextBoxX2.Text)))
        Try
            cm.ExecuteNonQuery()
            dsact.Clear()
            adact.Fill(dsact, "acthion_tran")
        Catch

        End Try

    End Sub
    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        qt = 0
        '==============qt الكمية الباقيه
        Me.TextBoxX2.Text = CDec(Me.TextBoxX8.Text)
        qt = CDec(Me.TextBoxX6.Text) + CDec(Me.TextBoxX8.Text)

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If MsgBox("هل أنت متأكد من عملية حذفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then


            Dim Trans As SqlTransaction = cn.BeginTransaction
            Try
                '==========================================
                Dim s As String = "delete from IsuSub where  no_s=@x1 and no_c=@x2 and qun_s=@x3 and sal_s=@x4 And count1= " & LabelX2.Text & ""
                Dim cm As New SqlCommand(s, cn)
                cm.Parameters.Add((New SqlParameter("@x1", TextBox6.Text)))
                cm.Parameters.Add(New SqlParameter("@x2", TextBoxX3.Text))
                cm.Parameters.Add(New SqlParameter("@x3", CDec(TextBoxX2.Text)))
                cm.Parameters.Add(New SqlParameter("@x4", CDec(TextBoxX1.Text)))

                cm.Transaction = Trans
                cm.ExecuteNonQuery()


                '============================= But_action_user()
                'But_action_user()
                t_event = "حذف صنف"
                t_doc = "اذن الصرف"
                ts = TimeOfDay

                Dim sa As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim cma As New SqlCommand(sa, cn)
                cma.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
                cma.Parameters.Add(New SqlParameter("@x2", t_doc))
                cma.Parameters.Add(New SqlParameter("@x3", TextBoxX3.Text))
                cma.Parameters.Add(New SqlParameter("@x4", CDec(Me.TextBoxX2.Text)))
                cma.Parameters.Add(New SqlParameter("@x5", TextBoxX1.Text))
                cma.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
                cma.Parameters.Add(New SqlParameter("@x7", ts))
                cma.Parameters.Add(New SqlParameter("@x8", ww))
                cma.Parameters.Add(New SqlParameter("@x9", t_event))
                cma.Transaction = Trans
                cma.ExecuteNonQuery()

                '==============================update_action_transrf_up()
                'update_action_transrf_up()

                Dim s1 As String = "update acthion_tran set qun_tot=@x1,date_i=@x2,info=@x3 where info=@x3 and date_i=@x2 and no_c=@x4 and sal_s=@x5 "
                Dim cm1 As New SqlCommand(s1, cn)
                cm1.Parameters.Add(New SqlParameter("@x1", CDec(qt)))
                cm1.Parameters.Add(New SqlParameter("@x2", CDate(TextBoxX5.Text)))
                cm1.Parameters.Add(New SqlParameter("@x3", TextBoxX7.Text))
                cm1.Parameters.Add(New SqlParameter("@x4", Me.TextBoxX3.Text))
                cm1.Parameters.Add(New SqlParameter("@x5", TextBoxX1.Text))
                cm1.Transaction = Trans
                cm1.ExecuteNonQuery()

                '==================================delet_tran()
                'delet_tran()
                Dim s2 As String = "delete from tran_IRT where no_c=@x1 and date_i=@x2 and n_rs=@x3 and tr_type=@x4 and quntity=@x5 and price=@x6 and count1= " & LabelX2.Text & ""
                Dim cm2 As New SqlCommand(s2, cn)
                cm2.Parameters.Add(New SqlParameter("@x1", TextBoxX3.Text))
                cm2.Parameters.Add(New SqlParameter("@x2", CDate(Me.TextBoxX5.Text)))
                cm2.Parameters.Add(New SqlParameter("@x3", TextBox6.Text))
                cm2.Parameters.Add(New SqlParameter("@x4", 3))
                cm2.Parameters.Add(New SqlParameter("@x5", CDec(TextBoxX2.Text)))
                cm2.Parameters.Add(New SqlParameter("@x6", TextBoxX1.Text))
                cm2.Transaction = Trans
                cm2.ExecuteNonQuery()
                '================================================ delet_ost()
                'delet_ost()
                Dim s22 As String = "DELETE FROM Table_OSTA WHERE no_I=@x1 and no_c=@x2 and date_I=@x3 and qI=@x4 and sal_s=@x5 and date_r=@x6 and no_R=@x7"
                Dim cm22 As New SqlCommand(s22, cn)
                cm22.Parameters.Add(New SqlParameter("@x1", TextBox6.Text))
                cm22.Parameters.Add(New SqlParameter("@x2", TextBoxX3.Text))
                cm22.Parameters.Add(New SqlParameter("@x3", CDate(TextBox2.Text)))
                cm22.Parameters.Add(New SqlParameter("@x4", CDec(TextBoxX8.Text)))
                cm22.Parameters.Add(New SqlParameter("@x5", CDec(TextBoxX1.Text)))
                cm22.Parameters.Add(New SqlParameter("@x6", CDate(TextBoxX5.Text)))
                cm22.Parameters.Add(New SqlParameter("@x7", Me.TextBoxX7.Text))
                cm22.Transaction = Trans
                cm22.ExecuteNonQuery()
                '===========================================

                Trans.Commit()
                MsgBox("تم حذف صنف", MsgBoxStyle.Information, " مراقبة المخزون")
                Me.XpListView3.Clear()
                Me.LabelX1.Text = ""

            Catch err As System.Exception

                Trans.Rollback()
                MsgBox("لم يتم حذف صنف", MsgBoxStyle.Information, " مراقبة المخزون")
                MsgBox(err.Message)

            Finally
            End Try

        Else
            Exit Sub
        End If

        clearing()

        ListView2.Sorting = SortOrder.Ascending
        Me.TextBoxX8.Clear()
        stouck()
        ser_amr()
    End Sub
    Sub delet_ost()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Try


            Dim s22 As String = "DELETE FROM Table_OSTA WHERE no_I=@x1 and no_c=@x2 and date_I=@x3 and qI=@x4 and sal_s=@x5 and date_r=@x6 and no_R=@x7"
            Dim cm22 As New SqlCommand(s22, cn)
            cm22.Parameters.Add(New SqlParameter("@x1", TextBox6.Text))
            cm22.Parameters.Add(New SqlParameter("@x2", TextBoxX3.Text))
            cm22.Parameters.Add(New SqlParameter("@x3", CDate(TextBox2.Text)))
            cm22.Parameters.Add(New SqlParameter("@x4", CDec(TextBoxX8.Text)))
            cm22.Parameters.Add(New SqlParameter("@x5", CDec(TextBoxX1.Text)))
            cm22.Parameters.Add(New SqlParameter("@x6", CDate(TextBoxX5.Text)))
            cm22.Parameters.Add(New SqlParameter("@x7", Me.TextBoxX7.Text))
            cm22.ExecuteNonQuery()
            dsIsuST.Clear()
            adIsuT.Fill(dsIsuST, "Table_OSTA")

        Catch err As System.Exception
            MsgBox(err.Message)
        End Try

        cn.Close()


    End Sub
    Sub ser_amr()

        If (TextBox6.Text.ToString) <> "" Then
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s11 As String = "SELECT * FROM IsuMain WHERE no_s=@x1"
            Dim cm As New SqlCommand(s11, cn)
            cm.Parameters.Add(New SqlParameter("@x1", TextBox6.Text))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader

                If r.Read = True Then
                    'clering_1()
                    totinf = r!total
                    Me.TextBox2.Text = r!date_s

                    Me.DateTimePicker1.Value = r!date_s
                    Me.DateTimePicker2.Value = r!date_s
                    Me.ComboBox1.SelectedValue = r!j_s

                    TextBox7.Text = r!name_stock.ToString
                    TextBox4.Text = r!name1_stock.ToString


                    'Me.ButtonX1.Enabled = False
                    'Me.ButtonX2.Enabled = False
                    'Me.ButtonX3.Enabled = False
                    'Me.ButtonX5.Enabled = False
                    TextBox9.Text = r!dep_mt.ToString
                    If TextBox9.Text = "تم مراجعته ولايوجد اخطاء" Then
                        RadioButton1.Checked = r!dep_m

                        Me.ButtonX1.Visible = False
                        Me.ButtonX2.Enabled = False
                        Me.Button5.Enabled = False
                        Me.ButtonX3.Enabled = False


                        Me.Panel3.Enabled = False


                    End If

                    If TextBox9.Text = "تم مراجعته ويوجد اخطاء" Then

                        RadioButton2.Checked = r!dep_m

                        'Me.ButtonX1.Visible = False
                        'Me.ButtonX2.Enabled = True
                        'Me.Button5.Enabled = True
                        'Me.ButtonX3.Enabled = True
                        'Me.Button8.Enabled = True
                        'Me.Panel3.Enabled = False

                    End If


                    If r!dep_nom = True Then

                        RadioButton3.Checked = True

                    End If




                    ft = True
                    r.Close()
                Else
                    'MsgBox(" اذن الصرف غير موجود ", MsgBoxStyle.Information, "تنبية")
                    ft = False
                    'Me.ButtonX1.Enabled = False
                    'Me.ButtonX2.Enabled = False
                    'Me.ButtonX3.Enabled = False
                    'Me.ButtonX5.Enabled = False
                    'TextBox6.Clear()
                    r.Close()
                End If
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try

        End If
        cn.Close()



        'Dim inf_t, y As Decimal
        'inf_t = 0.0
        'If cn.State = ConnectionState.Closed Then
        '    cn.Open()
        'End If
        'Dim sql As String = "select * from IsuSub where  no_s='" + TextBox6.Text + "'"
        'Dim ad1 As New SqlDataAdapter(sql, cn)
        'Dim ds1 As New DataSet()
        'Dim TD1 As DataTable
        'Dim DROW1 As DataRow

        'y = 0.0

        'ad1.Fill(ds1, sql)
        'TD1 = ds1.Tables(sql)

        'For i = 0 To TD1.Rows.Count - 1
        '    DROW1 = TD1.Rows(i)
        '    If DROW1("no_s") = (TextBox6.Text) Then

        '        y = CDbl(DROW1("gema"))
        '        inf_t = CDbl(inf_t) + CDbl(y)
        '    End If

        'Next
        'Me.TextBox4.Text = CDbl(inf_t)

        '=============================
        'If cn.State = ConnectionState.Closed Then
        '    cn.Open()
        'End If
        'Dim ss As String = "update IsuMain set no_s=@x1,total=@x2,tvg=@x3 where no_s=@x1"
        'Dim cms As New SqlCommand(ss, cn)
        'cms.Parameters.Add((New SqlParameter("@x1", TextBox6.Text)))
        'cms.Parameters.Add(New SqlParameter("@x2", inf_t))
        ''cms.Parameters.Add(New SqlParameter("@x3", TextBoxX10.Text))
        'Try
        '    cms.ExecuteNonQuery()
        '    dsIsuM.Clear()
        '    adIsuM.Fill(dsIsuM, "IsuMain")
        '    cn.Close()
        'Catch err As System.Exception
        '    MsgBox(err.Message)
        'End Try


        cn.Close()

        view_lstn_s()
    End Sub
    Sub view_lstn_s()

        Dim dt2 As DataTable
        Dim sql1, n1 As String
        n1 = TextBox6.Text
        If n1 = "" Then
            Exit Sub
        Else
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            '" & TextBoxX1.Text & "'
            sql1 = "SELECT * from tran_IRT WHERE n_rs ='" & n1 & "' and tr_type=3"
            Dim da8 As New SqlDataAdapter(sql1, cn)
            Dim ds8 As New DataSet
            ds8.Clear()
            da8.Fill(ds8, "tran_IRT")
            dt2 = ds8.Tables("tran_IRT")
            If dt2.Rows.Count > 0 Then

            End If
            ListView2.Clear()

            Dim dr2 As DataRow


            ListView2.Columns.Add("رقم الصنف ", 130, HorizontalAlignment.Center)
            ListView2.Columns.Add("الكمية", 130, HorizontalAlignment.Center)
            ListView2.Columns.Add("السعر ", 120, HorizontalAlignment.Center)
            ListView2.Columns.Add("تاريخ الاستلام", 160, HorizontalAlignment.Center)
            ListView2.Columns.Add("العداد", 150, HorizontalAlignment.Center)
            'ListView2.Columns.Add(" ملاحظات ", 130, HorizontalAlignment.Center)
            Dim sdl As Short = 1
            ListView2.Items.Clear()
            Dim i, c As Integer
            c = dt2.Rows.Count - 1
            For i = 0 To c
                Dim litem As New ListViewItem

                dr2 = dt2.Rows.Item(i)

                litem.Text = dt2.Rows(i).Item("no_c")
                litem.SubItems.Add(dt2.Rows(i).Item("quntity"))
                litem.SubItems.Add(dt2.Rows(i).Item("price"))
                litem.SubItems.Add(dt2.Rows(i).Item("date_i"))
                litem.SubItems.Add(dt2.Rows(i).Item("count1"))
                'litem.SubItems.Add(dt2.Rows(i).Item("mt"))
                ListView2.Items.Add(litem)
            Next i

        End If
        cn.Close()


        ListView2.Sort()

    End Sub

    Sub clear_a()
        Me.TextBoxX3.Text = ""
        TextBoxX2.Clear()
        TextBoxX1.Text = "0.00"
        Me.TextBoxX2.Text = 0
    End Sub
  

    Private Sub TextBox6_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles TextBox6.Invalidated

    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
          
            ser_amr()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", "/", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub
 


    Private Sub AutocomplateCustomSource()

        On Error Resume Next
        Dim i As Integer
        ' ''cn.Open()
        Dim da As New SqlDataAdapter("Select name_snc From matt", cn)
        Dim ds As New DataSet
        da.Fill(ds)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            TextBoxX4.AutoCompleteCustomSource.Add(ds.Tables(0).Rows(i)(0))
            'ComboBox1.AutoCompleteCustomSource.Add(ds.Tables(0).Rows(i)(0))
        Next i
        cn.Close()
    End Sub
    
    Sub total_inf_new()
        'TextBox8.Text = CStr(TextBox17.Text)
        If (Me.TextBox6.Text.ToString) <> " " Then
            '------------------------------
            '===================================
            If Im_tadel_s = "جديد" And (sefa = "امين مخزن" Or sefa = "موظف") Then
                Me.ListView2.Clear()
                Me.Panel3.Enabled = False

                TextBox6.Text = getNewNo(Me.dtYear.Value.Year, "GetNewNoIsuMain")

                Me.ButtonX1.Enabled = False
                Me.ButtonX2.Enabled = False
                Me.Button5.Enabled = False
                Me.ButtonX5.Enabled = False
                Me.ButtonX3.Enabled = False
                'Me.Button8.Enabled = False
                Me.Panel3.Enabled = False
            End If


           


            '============================

        End If
        cn.Close()





    End Sub

    Private Sub Form_Isu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

  
    Private Sub Form_Isu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label20.Text = ""

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        langarabic()


        Me.dtYear.Value = dateNowDB
        Me.DateTimePicker1.Value = dateNowDB

        adaj_s.Fill(dsaj_s, "j_s")
        ComboBox1.DataSource = dsaj_s
        ComboBox1.DisplayMember = "j_s.name_s"
        ComboBox1.ValueMember = "n_s"
        ComboBox1.SelectedIndex = -1
        Me.ButtonX6.Visible = True
        langarabic()

        '====================
        If Im_tadel_s = "جديد" Then
            total_inf_new()
            'Me.Button8.Visible = False
            Me.Panel3.Visible = False
            Label19.Visible = True
            dtYear.Visible = True
            DateTimePicker1.Value = (Format(Date.Now, "yyyy/MM/dd"))
        End If
        If Im_tadel_s = "تعديل" Then
            'Me.Button8.Visible = True
            Label19.Visible = False
            dtYear.Visible = False
            total_inf_tadel()
            Me.Panel3.Visible = True
        End If
        '=============================


        Me.ButtonX6.Visible = False


    End Sub


    Sub total_inf_tadel()
        TextBox6.Text = CStr(TextBox8.Text)
        If (Me.TextBox6.Text.ToString) <> " " Then



            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            '===================================



            Dim s11 As String = "SELECT * FROM IsuMain WHERE no_s=@x1"
            Dim cm As New SqlCommand(s11, cn)
            cm.Parameters.Add(New SqlParameter("@x1", TextBox6.Text))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader

                If r.Read = True Then
                    'clering_1()
                    totinf = r!total
                    Me.TextBox2.Text = r!date_s

                    Me.DateTimePicker1.Value = r!date_s
                    Me.DateTimePicker2.Value = r!date_s
                    Me.ComboBox1.SelectedValue = r!j_s

                    TextBox7.Text = r!name_stock.ToString
                    TextBox4.Text = r!name1_stock.ToString
                    TextBox9.Text = r!dep_mt.ToString
                    If TextBox9.Text = "تم مراجعته ولايوجد اخطاء" Then
                        RadioButton1.Checked = r!dep_m

                    End If

                    If TextBox9.Text = "تم مراجعته ويوجد اخطاء" Then

                        RadioButton2.Checked = r!dep_m

                    End If
                    Im_tadel_s = "تعديل"

                    If r!dep_nom = True Then

                        RadioButton3.Checked = True

                    End If




                    ft = True


                    r.Close()
                    cn.Close()
                Else
                    'MsgBox(" اذن الصرف غير موجود ", MsgBoxStyle.Information, "تنبية")
                    ft = False
                    Me.ButtonX1.Enabled = False
                    Me.ButtonX2.Enabled = False
                    Me.ButtonX3.Enabled = False
                    'Me.ButtonX5.Enabled = False
                    Me.Button5.Enabled = False
                    clear_a()
                    clearing()
                    r.Close()
                    cn.Close()
                    'Exit Sub
                End If
                r.Close()
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try
            cn.Close()


            If ft = False Then
                : MsgBox(" اذن الصرف غير موجود ", MsgBoxStyle.Critical, "تنبية")

                Me.ButtonX1.Enabled = False
                Me.ButtonX2.Enabled = False
                Me.ButtonX3.Enabled = False
                'Me.ButtonX5.Enabled = False
                Me.Button5.Enabled = False
                clear_a()
                clearing()
                TextBox6.Text = ""
                cn.Close()
                Exit Sub
            End If

            '=============================
            If Im_tadel_s = "تعديل" And (sefa = "امين مخزن" Or sefa = "موظف") Then


                If TextBox9.Text = "تم مراجعته ولايوجد اخطاء" Then
                    Me.ButtonX1.Visible = False
                    Me.ButtonX2.Enabled = False
                    Me.Button5.Enabled = False

                    'Me.Button8.Enabled = True
                    Me.Panel3.Enabled = False
                    Me.ButtonX5.Enabled = False
                    Me.ButtonX3.Enabled = False
                End If
                If TextBox9.Text = "تم مراجعته ويوجد اخطاء" Then

                    Me.ButtonX1.Visible = False
                    Me.ButtonX2.Enabled = True
                    Me.Button5.Enabled = True
                    Me.ButtonX5.Enabled = False
                    Me.ButtonX3.Enabled = False
                    'Me.Button8.Enabled = True
                    Me.Panel3.Enabled = False

                End If

                If RadioButton3.Checked = True Then
                    Me.ButtonX1.Visible = True
                    Me.ButtonX2.Enabled = True
                    Me.Button5.Enabled = True

                    Me.ButtonX5.Enabled = False
                    Me.ButtonX3.Enabled = False

                    'Me.Button8.Enabled = True
                    Me.Panel3.Enabled = False
                End If
            End If

            


            If Im_tadel_s = "تعديل" And sefa = "مراقب المخزون" Then



                If TextBox9.Text = "تم مراجعته ويوجد اخطاء" Then


                    Me.ButtonX1.Visible = False
                    Me.ButtonX2.Enabled = True
                    Me.Button5.Enabled = True

                    'Me.Button8.Enabled = True
                    Me.Panel3.Enabled = False

                    Me.ButtonX5.Enabled = False
                    Me.ButtonX3.Enabled = False
                    '===============================
                ElseIf RadioButton3.Checked = True Then

                    Me.ButtonX1.Visible = False
                    Me.ButtonX2.Enabled = True
                    Me.Button5.Enabled = False
                    'Me.Button8.Enabled = True
                    Me.Panel3.Enabled = False
                    Me.ButtonX5.Enabled = False
                    Me.ButtonX3.Enabled = False

                End If

            End If



            If sefa = "مراجع" Then

                If TextBox9.Text = "تم مراجعته ويوجد اخطاء" Or RadioButton3.Checked = True Then


                    Me.ButtonX1.Visible = False
                    Me.ButtonX2.Enabled = False
                    Me.Button5.Enabled = False

                    'Me.Button8.Enabled = True
                    Me.ButtonX5.Enabled = False
                    Me.ButtonX3.Enabled = False
                    Me.Panel3.Enabled = True

                Else

                    Me.ButtonX1.Visible = False
                    Me.ButtonX2.Enabled = False
                    Me.Button5.Enabled = False
                    'Me.Button8.Enabled = True
                    Me.Panel3.Enabled = False
                    Me.ButtonX5.Enabled = False
                    Me.ButtonX3.Enabled = False
                End If



            End If

            '============================

        End If
        cn.Close()

        view_lstn_s()


    End Sub
    
    Private Sub ListView2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.Click
        Me.ButtonX1.Enabled = False
        Me.ButtonX2.Enabled = True
        Me.ButtonX3.Enabled = True
        Me.ButtonX5.Enabled = True
        Me.XpListView3.Enabled = False


        Dim litem As ListViewItem
        'Dim i As Integer
        For Each litem In ListView2.SelectedItems
            Me.TextBoxX3.Text = litem.SubItems(0).Text
            view_l_0()
            Me.TextBoxX8.Text = litem.SubItems(1).Text
            Me.TextBoxX1.Text = litem.SubItems(2).Text
            Me.TextBoxX5.Text = litem.SubItems(3).Text
            Me.LabelX2.Text = litem.SubItems(4).Text

        Next
        'total_inf()
        'view_l()
        'ButtonX6.Enabled = True
        ' ''Me.ButtonX5.Enabled = True
        'Me.ButtonX7.Enabled = True
        If Me.TextBoxX5.Text = "" Then
            Exit Sub
        Else
            selct_actiontran()
            show_note()
        End If
        Me.ButtonX1.Enabled = False
        Me.ButtonX2.Enabled = True
        Me.ButtonX3.Enabled = True
        Me.ButtonX5.Enabled = True
        Me.XpListView3.Enabled = False


    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged

        TextBoxX8.Text = 0

        'Is DBNull.Value


        '***************************
        'If (ListView2.SelectedItems.Count = 0) Then
        '    MessageBox.Show("لاتوجد عناصر تم اختارها")
        'End If

        Me.XpListView3.Enabled = False

        Dim litem As ListViewItem
        'Dim i As Integer
        For Each litem In ListView2.SelectedItems
            Me.TextBoxX3.Text = litem.SubItems(0).Text
            view_l_0()
            Me.TextBoxX8.Text = litem.SubItems(1).Text
            Me.TextBoxX1.Text = litem.SubItems(2).Text
            Me.TextBoxX5.Text = litem.SubItems(3).Text
            Me.LabelX2.Text = litem.SubItems(4).Text

        Next
        'total_inf()
        'view_l()
        'ButtonX6.Enabled = True
        ' ''Me.ButtonX5.Enabled = True
        'Me.ButtonX7.Enabled = True
        If Me.TextBoxX5.Text = "" Then
            Exit Sub
        Else
            selct_actiontran()
            show_note()
        End If
        Me.ButtonX1.Enabled = False
        Me.ButtonX2.Enabled = True
        Me.ButtonX3.Enabled = True
        Me.ButtonX5.Enabled = True
        Me.XpListView3.Enabled = False
    End Sub
    Sub show_note()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim sa As String = "select mt from IsuSub where no_s=@x1 and no_c=@x2 and qun_s=@x3 and sal_s=@x4 and count1=@x5"
        Dim cma As New SqlCommand(sa, cn)
        cma.Parameters.Add(New SqlParameter("@x1", (TextBox6.Text)))
        cma.Parameters.Add(New SqlParameter("@x2", (TextBoxX3.Text)))
        cma.Parameters.Add(New SqlParameter("@x3", CDec(TextBoxX8.Text)))

        cma.Parameters.Add(New SqlParameter("@x4", (TextBoxX1.Text)))
        cma.Parameters.Add(New SqlParameter("@x5", (LabelX2.Text)))

        Dim r As SqlDataReader = cma.ExecuteReader
        If r.Read = True Then
            Me.RichTextBox1.Text = r!mt

            r.Close()
        Else
            Me.TextBoxX6.Text = 0
            Me.TextBoxX7.Text = 0
            r.Close()
        End If

    End Sub
    Sub selct_actiontran()


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim sa As String = "select qun_tot,info from acthion_tran where no_c=@x1 and date_i=@x2 and sal_s=@x3"
        Dim cma As New SqlCommand(sa, cn)
        cma.Parameters.Add(New SqlParameter("@x1", Trim(TextBoxX3.Text)))
        cma.Parameters.Add(New SqlParameter("@x2", CDate(TextBoxX5.Text)))
        cma.Parameters.Add(New SqlParameter("@x3", (TextBoxX1.Text)))

        Dim r As SqlDataReader = cma.ExecuteReader
        If r.Read = True Then
            Me.TextBoxX6.Text = r!qun_tot
            Me.TextBoxX7.Text = r!info
            r.Close()
        Else
            Me.TextBoxX6.Text = 0
            Me.TextBoxX7.Text = 0
            r.Close()
        End If

    End Sub

    Private Sub TextBoxX3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxX3.KeyDown
        If e.KeyCode = Keys.Enter Then

            If Me.TextBoxX3.Text <> "" Then
                informa()
                If fal = False Then
                    clearing()
                    clear_a()
                    TextBox3.Clear()
                    TextBox5.Clear()
                    MsgBox("هذا الصنف لم يتم تعريفة بعد", MsgBoxStyle.OkOnly, "تنبية")
                    Me.ButtonX1.Enabled = False
                    XpListView3.Enabled = False
                    Me.ButtonX2.Enabled = True
                    Me.ButtonX3.Enabled = False
                    Me.ButtonX5.Enabled = False
                    Exit Sub
                Else

                    Me.XpListView3.Enabled = False
                    stouck()
                    TextBox3.Clear()
                    TextBox5.Clear()
                    Me.ButtonX1.Enabled = True
                    XpListView3.Enabled = True
                    Me.ButtonX2.Enabled = True
                    Me.ButtonX3.Enabled = False
                    Me.ButtonX5.Enabled = False
                    view_l()
                End If
            Else
                clearing()
                clear_a()
                TextBox3.Clear()
                TextBox5.Clear()
                Me.XpListView3.Enabled = False
                Me.ButtonX1.Enabled = False
                Me.ButtonX2.Enabled = False
                Me.ButtonX3.Enabled = False
                Me.ButtonX5.Enabled = False
            End If
        End If
    End Sub

    'Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    '    If TextBox6.Text <> "" Then

    '        'Dim adp As New SqlDataAdapter("SELECT no_s,no_c,name_snc,name_type,cast([qun_ss] as nvarchar(50)) as qun_ss,sal_s, gemas,cast([balance] as nvarchar(50)) as balance,date_s ,name_s,u_name,no_ct1 ,tvg ,mt ,cast([q_div] as nvarchar(50)) as q_div from  msrofat WHERE no_s ='" + TextBoxX9.Text + "'", cn)
    '        Dim adp As New SqlDataAdapter("SELECT no_s,no_c,name_snc,name_type,cast([qun_ss] as nvarchar(50)) as qun_ss, sal_s, gemas,cast([balance] as nvarchar(50)) as balance,date_s ,name_s,u_name,no_ct1 ,tvg ,no_ct,mt ,cast([q_div] as nvarchar(50)) as q_div,name_stock,name1_stock from  msrofatt WHERE no_s ='" + TextBox6.Text + "'", cn)
    '        Dim dt As New DataTable
    '        adp.Fill(dt)

    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            If checkNum(dt.Rows(i).Item("qun_ss")) = "int" Then
    '                dt.Rows(i).Item("qun_ss") = myNo
    '            Else
    '                dt.Rows(i).Item("qun_ss") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
    '            End If
    '            If checkNum(dt.Rows(i).Item("balance")) = "int" Then
    '                dt.Rows(i).Item("balance") = myNo
    '            Else
    '                dt.Rows(i).Item("balance") = FormatNumber(CDec(dt.Rows(i).Item(8)), 3)
    '            End If


    '            If checkNum(dt.Rows(i).Item("q_div")) = "int" Then
    '                dt.Rows(i).Item("q_div") = myNo
    '            Else
    '                dt.Rows(i).Item("q_div") = FormatNumber(CDec(dt.Rows(i).Item(15)), 3)
    '            End If


    '        Next

    '        Dim frm As New Form7
    '        Dim rpt1 As New CrystalReport14

    '        rpt1.SetDataSource(dt)
    '        frm.CrystalReportViewer1.ReportSource = rpt1
    '        Dim Text8 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text8")
    '        Text8.Text = branch

    '        '===============================================



    '        frm.Text = "طباعة "
    '        frm.ShowDialog()


    '    Else
    '        Exit Sub
    '    End If


    'End Sub

    Private Sub TextBoxX3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX3.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub


    Private Sub TextBoxX3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBoxX3.Validating
        'If Me.TextBoxX3.Text <> "" Then
        '    informa()
        '    If fal = False Then
        '        clearing()
        '        clear_a()

        '        Me.ButtonX1.Enabled = False
        '        XpListView3.Enabled = True
        '        Me.ButtonX2.Enabled = True
        '        Me.ButtonX3.Enabled = False
        '        Me.ButtonX5.Enabled = False
        '        Exit Sub
        '    Else

        '        Me.XpListView3.Enabled = False
        '        stouck()
        '        Me.ButtonX1.Enabled = True
        '        XpListView3.Enabled = True
        '        Me.ButtonX2.Enabled = True
        '        Me.ButtonX3.Enabled = False
        '        Me.ButtonX5.Enabled = False
        '        view_l()
        '    End If
        'Else
        '    clearing()
        '    clear_a()
        '    Me.XpListView3.Enabled = False
        '    Me.ButtonX1.Enabled = False
        '    Me.ButtonX2.Enabled = False
        '    Me.ButtonX3.Enabled = False
        '    Me.ButtonX5.Enabled = False

        'End If

    End Sub
    'Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
    '    If TextBox6.Text.ToString = "" Then
    '        clearing()
    '        clear_a()
    '        Me.TextBoxX11.Clear()
    '        Me.RadioButton1.Checked = False
    '        Me.RadioButton2.Checked = False
    '        Me.RadioButton3.Checked = False

    '        Me.XpListView3.Enabled = False
    '        Me.ListView2.Clear()
    '        Me.XpListView3.Clear()
    '        Me.ButtonX1.Enabled = False
    '        Me.ButtonX2.Enabled = False
    '        Me.ButtonX3.Enabled = False
    '        Me.ButtonX5.Enabled = False
    '        Me.LabelX1.Text = ""
    '        Me.TextBoxX8.Text = 0
    '    End If
    'End Sub

    Private Sub TextBoxX3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX3.TextChanged


        TextBoxX3.Text = UCase(TextBoxX3.Text)
        TextBoxX5.Clear()
        TextBoxX6.Text = 0
        TextBoxX1.Text = "0.00"
        TextBoxX7.Clear()
        TextBoxX2.Text = 0
        TextBoxX4.Clear()
        Me.TextBoxX8.Text = 0
        If Me.TextBoxX3.Text <> "" Then
            informa()
            If fal = True Then
                stouck()
3:
                view_l()

                Me.XpListView3.Enabled = False
                Me.ButtonX1.Enabled = True
                XpListView3.Enabled = True
                Me.ButtonX2.Enabled = False
                Me.ButtonX3.Enabled = False
                Me.ButtonX5.Enabled = False
            Else


                Me.LabelX1.Text = ""

            End If


        Else
            clearing()
            clear_a()
            Me.XpListView3.Enabled = False
            Me.XpListView3.Clear()
            Me.ButtonX1.Enabled = False
            Me.ButtonX2.Enabled = False
            Me.ButtonX3.Enabled = False
            Me.ButtonX5.Enabled = False
            Me.LabelX1.Text = ""

        End If
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox6.Clear()
        Dim k As New Formisu_sub
        k.ShowDialog()
        clearing()
        clear_a()

        Me.XpListView3.Enabled = False
        Me.XpListView3.Clear()
        Me.ButtonX1.Enabled = False
        Me.ButtonX2.Enabled = False
        Me.ButtonX3.Enabled = False
        Me.ButtonX5.Enabled = False
        Me.LabelX1.Text = ""
        Me.ListView2.Clear()
    End Sub


    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click

        k.TextBox1.Text = Me.TextBoxX3.Text
        'k.TextBox9.Text = Me.TextBoxX1.Text
        k.TextBox2.Text = TextBoxX8.Text
        k.TextBox3.Text = Me.TextBoxX1.Text
        k.ShowDialog()
        'k.TextBoxX4.Text = TextBoxX8.Text
        'k.TextBoxX5.Text = TextBoxX9.Text


    End Sub

    Private Sub PanelEx1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBoxX2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX2.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", ".", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBoxX2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX2.TextChanged

    End Sub

    Private Sub TextBoxX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX1.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", ".", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBoxX1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX1.TextChanged

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub LabelX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX2.Click

    End Sub

    Private Sub TextBoxX6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX6.TextChanged

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub RichTextBoxEx1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Sub serch_no_name()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "select * from matt_t where name_snc=@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", (TextBoxX4.Text)))
        Try
            Dim r As SqlDataReader = cm.ExecuteReader
            If r.Read = True Then
                TextBoxX3.Text = r!no_c
                'Me.TextBoxX2.Text = r!iopb
                'Me.Label1.Text = r!name_type
                r.Close()
            Else
                r.Close()
            End If
            r.Close()
        Catch
            'MsgBox("يوجد خطاءفي بيانات المواد", MsgBoxStyle.Critical, "تنبية")
        End Try
        cn.Close()


    End Sub
    Private Sub TextBoxX4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX4.TextChanged

        serch_no_name()


    End Sub




    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click


        If IsNumeric(Me.TextBox1.Text) = True Then


            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim ss As String = "update IsuSub set q_div=" & Me.TextBox1.Text & " where no_s='" & TextBox6.Text & "' and no_c='" & Me.TextBoxX3.Text & "' and sal_s=" & Me.TextBoxX1.Text & " and count1 =" & Me.LabelX2.Text & ""
            Dim cm As New SqlCommand(ss, cn)

            Try
                cm.ExecuteNonQuery()
                'dsIsuS.Clear()
                adIsuS.Fill(dsIsuS, "IsuSub")
                ''MsgBox("تم تعديل الكمية  ", MsgBoxStyle.Information, "تعديل")
            Catch ex As Exception
            End Try
            cn.Close()
            '==========================================
            '========update_action_transrf========================

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s1 As String = "update acthion_tran set qun_tot=@x1,date_i=@x2,info=@x3 where info=@x3 and date_i=@x2 and no_c=@x4 and sal_s=@x5 "
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", CDec(TextBox1.Text)))
            cm1.Parameters.Add(New SqlParameter("@x2", CDate(TextBoxX5.Text)))
            cm1.Parameters.Add(New SqlParameter("@x3", Trim(TextBoxX7.Text)))
            cm1.Parameters.Add(New SqlParameter("@x4", Trim(Me.TextBoxX3.Text)))
            cm1.Parameters.Add(New SqlParameter("@x5", CDec(TextBoxX1.Text)))

            cm1.ExecuteNonQuery()
            cn.Close()


        Else
            Exit Sub
        End If
        cn.Close()

        TextBox1.Text = ""
    End Sub
    ''Function man14(ByVal Text1 As String) As String
    '    Dim a(100) As String
    '    Dim i, j As Integer
    '    'Dim nm As String
    '    Me.TextBox4.Text = Trim(Me.TextBox4.Text)
    '    Dim a1 As String
    '    a1 = Me.TextBox4.Text.ToString
    '    For i = 1 To Len(Text1)
    '        If (Mid(Me.TextBox4.Text, i, 1) = ".") Then
    '            Exit For
    '        End If
    '        If i = Len(Text1) Then
    '            If (Mid(Me.TextBox4.Text, i, 1) <> ".") Then
    '                a1 = a1 + (".000")
    '            End If
    '        End If
    '    Next i
    '    j = Len(Text1)
    '    j = j - i
    '    If j = 1 Then
    '        a1 = a1 + ("00")
    '    End If
    '    If j = 2 Then
    '        a1 = a1 + ("0")
    '    End If
    '    Me.TextBox4.Text = Trim(a1)

    '    man14 = Me.TextBox4.Text
    'End Function
    'Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim A As New NumberToWords
    '    Me.TextBoxX10.Text = (A.getWords(TextBox4.Text))
    '    Dim x As String
    '    x = man14(TextBox4.Text)
    'End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet2
        ds = New DataSet2
        ds.Clear()
        Dim f As New Form7

        Dim sad As SqlDataAdapter
        Dim t1 As DataTable

        Dim s As String = "select * from  msrofat_1 WHERE no_s ='" + TextBox6.Text + "'"
        sad = New SqlDataAdapter(s, cn)
        sad.Fill(ds, s)
        t1 = ds.Tables(s)

        Dim rpt1 As New CrystalR6
        Application.DoEvents()
        Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
        'ConInfo.ConnectionInfo.ServerName = Application.StartupPath & "\dbm.mdb"
        'ConInfo.ConnectionInfo.DatabaseName = "dbm.mdb"
        'ConInfo.ConnectionInfo.UserID = "Admin"
        'ConInfo.ConnectionInfo.Password = "3573"
        'rpt1.Database.Tables(0).ApplyLogOnInfo(ConInfo)
        rpt1.SetDataSource(t1)
        f.CrystalReportViewer1.ReportSource = rpt1

        Dim Text1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text1")
        Text1.Text = branch
        'f.CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.Password = "3573"
        f.ShowDialog()
        ds.Clear()
        'cn.Close()


        '***************************

        cn.Close()
    End Sub



    Private Sub ButtonX8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX8.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim ss As String = "update IsuMain set no_s=@x1,dep_m=@x2,dep_mt=@x3,dep_nom=@x4 where no_s=@x1"
        Dim cms As New SqlCommand(ss, cn)

        cms.Parameters.Add((New SqlParameter("@x1", TextBox6.Text)))
        If Me.RadioButton1.Checked = True Or RadioButton2.Checked = True Then
            cms.Parameters.Add(New SqlParameter("@x2", True))
        Else
            cms.Parameters.Add(New SqlParameter("@x2", False))
        End If
        cms.Parameters.Add(New SqlParameter("@x3", Me.TextBox9.Text))
        cms.Parameters.Add(New SqlParameter("@x4", Me.RadioButton3.Checked))
        Try
            cms.ExecuteNonQuery()
            dsIsuM.Clear()
            adIsuM.Fill(dsIsuM, "IsuMain")
            cn.Close()
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try
        Me.RadioButton1.Checked = False
        Me.RadioButton2.Checked = False
        Me.RadioButton3.Checked = False
        Me.TextBox9.Clear()
        cn.Close()
        Me.ButtonX8.Enabled = False
    End Sub


    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Me.TextBox9.Text = "تم مراجعته ولايوجد اخطاء"
        End If


    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then

            Me.TextBox9.Text = "تم مراجعته ويوجد اخطاء"

        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then

            Me.TextBox9.Text = ""

        End If
    End Sub


    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        'If TextBox6.Text.ToString <> "" Then

        '    Me.TextBoxX11.Clear()
        '    Me.RadioButton1.Checked = False
        '    Me.RadioButton2.Checked = False
        '    Me.RadioButton3.Checked = False

        '    ser_amr()
        '    ''clear_a()

        '    If (sefa = "مراقب المخزون" Or sefa = "امين مخزن") Then

        '        If RadioButton1.Checked = True Then
        '            Me.Panel1.Enabled = False
        '            Me.Panel3.Enabled = False

        '        Else

        '            Me.Panel1.Enabled = True
        '            Me.Panel3.Enabled = False


        '        End If
        '    End If
        '    '///////////////////////////////////

        '    If sefa = "مراجع" And v1 = True Then


        '        If RadioButton1.Checked = True Then
        '            Me.Panel1.Enabled = False
        '            Me.Panel3.Enabled = False

        '        Else

        '            Me.Panel1.Enabled = False
        '            Me.Panel3.Enabled = True



        '        End If

        '    End If


        'Else

        '    clear_a()
        '    Me.ListView2.Clear()
        'End If








        'If TextBox6.Text.ToString = "" Then


        '    clearing()

        '    clear_a()
        '    Me.TextBoxX11.Clear()
        '    Me.RadioButton1.Checked = False
        '    Me.RadioButton2.Checked = False
        '    Me.RadioButton3.Checked = False

        '    Me.XpListView3.Enabled = False
        '    Me.ListView2.Clear()
        '    Me.XpListView3.Clear()
        '    Me.ButtonX1.Enabled = False
        '    Me.ButtonX2.Enabled = False
        '    Me.ButtonX3.Enabled = False
        '    Me.ButtonX5.Enabled = False
        '    Me.LabelX1.Text = ""
        '    Me.TextBoxX8.Text = 0
        'End If
    End Sub

    'Private Sub TextBox6_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox6.Validating
    '    If TextBox6.Text.ToString <> "" Then

    '        Me.TextBoxX11.Clear()
    '        Me.RadioButton1.Checked = False
    '        Me.RadioButton2.Checked = False
    '        Me.RadioButton3.Checked = False

    '        ser_amr()
    '        'clear_a()

    '        If (sefa = "مراقب المخزون" Or sefa = "امين مخزن") Then

    '            If RadioButton1.Checked = True Then
    '                Me.Panel1.Enabled = False
    '                Me.Panel3.Enabled = False

    '            Else

    '                Me.Panel1.Enabled = True
    '                Me.Panel3.Enabled = False


    '            End If
    '        End If
    '        '///////////////////////////////////

    '        If sefa = "مراجع" And v1 = True Then


    '            If RadioButton1.Checked = True Then
    '                Me.Panel1.Enabled = False
    '                Me.Panel3.Enabled = False

    '            Else

    '                Me.Panel1.Enabled = False
    '                Me.Panel3.Enabled = True



    '            End If

    '        End If


    '    Else

    '        clear_a()
    '        Me.ListView2.Clear()
    '    End If




    'End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        '====================الحذف======='===================='===========================



        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s11 As String = "SELECT * FROM tran_IRT WHERE n_rs=@x1 and tr_type=@x2"
        Dim cm As New SqlCommand(s11, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
        cm.Parameters.Add(New SqlParameter("@x2", 3))
        Try
            Dim r As SqlDataReader = cm.ExecuteReader

            If r.Read = True Then
                MessageBoxEx.Show("لايمكن الحذف لانه تم الصرف منه", "منظومة مراقبة المخزون", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                clearing()
                Me.TextBoxX3.Clear()
                Me.TextBox4.Clear()
                Me.TextBox7.Clear()

                r.Close()
                Exit Sub


            Else

                Me.ButtonX1.Enabled = False
                Me.ButtonX2.Enabled = False
                Me.ButtonX3.Enabled = False
                Me.TextBoxX3.Clear()

                Me.TextBox4.Clear()
                Me.TextBox7.Clear()

                r.Close()
            End If
        Catch err As System.Exception
            'MsgBox(err.Message)
        End Try


        If MsgBox("هل أنت متأكد من عملية حذفك لهذا الامر ؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then



            '====================الحذف======='===================='===========================

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim Trans As SqlTransaction = cn.BeginTransaction




            Try


                Dim sd As String = "delete from IsuMain where no_s=@x1 and date_s=@x2"
                Dim cmd As New SqlCommand(sd, cn)
                cmd.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
                cmd.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()
                '======================================================================

                Dim s2 As String = "delete from tran_IRT where n_rs=@x1 "
                Dim cm2 As New SqlCommand(s2, cn)

                cm2.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
                cm2.Transaction = Trans
                cm2.ExecuteNonQuery()

                '===================================================================

                Dim s3 As String = "delete from acthion_tran where info=@x1"
                Dim cm3 As New SqlCommand(s3, cn)

                cm3.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
                cm3.Transaction = Trans
                cm3.ExecuteNonQuery()

                '===================================================================

                t_doc = "اذن الصرف"
                ts = TimeOfDay
                t_event = "حذف "

                Dim s1 As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim cm1 As New SqlCommand(s1, cn)
                cm1.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
                cm1.Parameters.Add(New SqlParameter("@x2", t_doc))
                cm1.Parameters.Add(New SqlParameter("@x3", 0))
                cm1.Parameters.Add(New SqlParameter("@x4", 0))
                cm1.Parameters.Add(New SqlParameter("@x5", 0))
                cm1.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
                cm1.Parameters.Add(New SqlParameter("@x7", ts))
                cm1.Parameters.Add(New SqlParameter("@x8", ww))
                cm1.Parameters.Add(New SqlParameter("@x9", t_event))

                cm1.Transaction = Trans
                cm1.ExecuteNonQuery()

                '===================================================================

                Trans.Commit()
                MsgBox("تم حذف  اذن الصرف", MsgBoxStyle.Information, " مراقبة المخزون")

                Me.TextBox4.Clear()
                Me.TextBox7.Clear()
                ListView2.Items.Clear()
                Me.ButtonX1.Enabled = False
                Me.ButtonX2.Enabled = False
                Me.ButtonX3.Enabled = False
                cn.Close()
            Catch err As System.Exception

                Trans.Rollback()
                MsgBox("لم تم حذف  اذن الصرف", MsgBoxStyle.Information, " مراقبة المخزون")
                Me.ButtonX1.Enabled = False
                Me.ButtonX2.Enabled = False
                Me.ButtonX3.Enabled = False
                MsgBox(err.Message)
                cn.Close()
            Finally
            End Try
        Else
            MsgBox("لم تتم عملية الحذف ؟", MsgBoxStyle.OkOnly, "تأكيد حذف")
            Exit Sub
        End If
        cn.Close()

        'ser_amr()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TextBox6.Text <> "" Then
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            'Dim adp As New SqlDataAdapter("SELECT no_s,no_c,name_snc,name_type,cast([qun_ss] as nvarchar(50)) as qun_ss,sal_s, gemas,cast([balance] as nvarchar(50)) as balance,date_s ,name_s,u_name,no_ct1 ,tvg ,mt ,cast([q_div] as nvarchar(50)) as q_div from  msrofat WHERE no_s ='" + TextBoxX9.Text + "'", cn)
            Dim adp As New SqlDataAdapter("SELECT no_s,no_c,name_snc,name_type,cast([qun_ss] as nvarchar(50)) as qun_ss, sal_s, gemas,cast([balance] as nvarchar(50)) as balance,date_s ,name_s,u_name,no_ct1 ,tvg ,no_ct,mt ,cast([q_div] as nvarchar(50)) as q_div,name_stock,name1_stock from  msrofatt WHERE no_s ='" + TextBox6.Text + "'", cn)
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
            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo


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






        '===============================================




    End Sub

  

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub




    Private Sub dtYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtYear.ValueChanged
        Try

            TextBox6.Text = getNewNo(Me.dtYear.Value.Year, "GetNewNoIsuMain")

        Catch ex As Exception

        End Try
    End Sub
End Class