Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports CrystalDecisions.CrystalReports.Engine

Public Class Form_ins
    Dim i As New Integer
    Dim move_no, no_stock As String
    Dim tot, eror_m, s_n As Boolean
    Dim sum_irct, sum_iiss, sum_return, total_s, sum_talf As New Decimal()
    Dim siopb As Integer

    '======================================
    Dim smt As String = "select * from matt"
    Dim admt As New SqlDataAdapter(smt, cn)
    Dim dsmt As New DataSet()
    Dim TDmt As DataTable
    '===========================
    Dim s As String = "select * from j_r"
    Dim ada As New SqlDataAdapter(s, cn)
    Dim dsa As New DataSet()
    '======================================
    Dim s1 As String = "select * from RcvSub"
    Dim adRcvS As New SqlDataAdapter(s1, cn)
    Dim dsRcvS As New DataSet()
    '===========================
    Dim s2 As String = "select * from RcvMain"
    Dim adRcvM As New SqlDataAdapter(s2, cn)
    Dim dsRcvM As New DataSet()
    '===========================
    Dim s22 As String = "select * from acthion_tran"
    Dim adact As New SqlDataAdapter(s22, cn)
    Dim dsact As New DataSet()
    '======================================

    Dim stran As String = "select * from tran_IRT"
    Dim adtran As New SqlDataAdapter(stran, cn)
    Dim dstran As New DataSet()

    Dim strsalahia As String = "select * from salahia"
    Dim adsalahia As New SqlDataAdapter(strsalahia, cn)
    Dim dssalahia As New DataSet()

    'Dim s11 As String = "select * from matt_buy"
    'Dim adm As New SqlDataAdapter(s11, cn)
    'Dim dsm As New DataSet()
    '===========================
    Dim dateS, dateN As Date
    'Dim d, m, y As Integer
 
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
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        Dim k As New F_part
        k.GroupPanel1.Text = "الجهات الموردة"
        k.Label1.Text = "جهة التوريد"
        k.TextBox3.Visible = False
        k.ShowDialog()


        dsa.Clear()
        ComboBox1.Refresh()
        ada.Fill(dsa, "j_r")
        ComboBox1.DataSource = dsa
        ComboBox1.DisplayMember = "j_r.name_r"
        ComboBox1.ValueMember = "no_r"

    End Sub

    Private Sub TextBox8_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles TextBox8.Invalidated

    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyDown

    End Sub


    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", "/", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub
    Sub auto_noc()
        '"اداره"
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "select * from RcvMain where RcvMain.no_i=(select max(no_i) from RcvMain)"

        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "RcvMain")
        tb = ds.Tables(0)
        Dim dr As DataRow
        Try
            dr = tb.Rows(0)
            Me.TextBox8.Text = dr(0) + 1
            cn.Close()
        Catch ex As Exception
            Me.TextBox8.Text = "1"
            cn.Close()
        End Try

        ad.Dispose()
        ds.Dispose()


        cn.Close()

    End Sub

    Private Sub AutocomplateCustomSource()

        On Error Resume Next
        Dim i As Integer
        ' ''cn.Open()
        Dim da As New SqlDataAdapter("Select name_snc From matt", cn)
        Dim ds As New DataSet
        da.Fill(ds)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            TextBox11.AutoCompleteCustomSource.Add(ds.Tables(0).Rows(i)(0))
            'ComboBox1.AutoCompleteCustomSource.Add(ds.Tables(0).Rows(i)(0))
        Next i
        cn.Close()
    End Sub



    Private Sub Form_ins_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

       

      


        'TextBox11.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        'TextBox11.AutoCompleteSource = AutoCompleteSource.CustomSource
        'AutocomplateCustomSource()

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
    Private Sub Form_ins_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ImportersDT.Rows.Count > 0 Then
            ImportersDT.Rows.Clear()
        End If
        ComboBox2.Text = "لايوجد"
        TextBox13.Text = "0"
        Me.RadioButton6.Checked = True

        Dim s As String = "select * from j_r"
        Dim ada As New SqlDataAdapter(s, cn)
        Dim dsa As New DataSet()
        ada.Fill(dsa, "j_r")
        ComboBox1.DataSource = dsa
        ComboBox1.DisplayMember = "j_r.name_r"
        ComboBox1.ValueMember = "no_r"

        'Me.ComboBox1.SelectedIndex = -1
        'Me.ComboBox1.Refresh()
        cn.Close()

        TextBox3.Text = ww
        Me.Button2.Enabled = False
        If Im_tadel = "تعديل" Then

            total_inf()
           
        Else

            Me.Panel2.Enabled = False
            auto_noc()
            xl = l_p(Trim(TextBox8.Text))
            TextBox8.Text = xl
            langarabic()


            'ImportersDA = New SqlDataAdapter
            'DataGridViewX2.DataMember = ""
            'DataGridViewX2.DataSource = Nothing


        End If

      


        If Im_tadel = "تعديل" And (sefa = "امين مخزن") Then
            Me.Button2.Visible = True
            Me.Button10.Visible = True


            Me.Button4.Visible = True
            Me.Button3.Visible = True
            Me.Button1.Visible = True
            Me.Panel2.Enabled = False
        End If


        If Im_tadel = "استلام" And (sefa = "امين مخزن") Then
            Me.Button2.Visible = True

            Me.Button10.Visible = True


            Me.Button4.Visible = False
            Me.Button3.Visible = False
            Me.Button1.Visible = False
            Me.Panel2.Enabled = False
        End If

        If (sefa = "مراقب المخزون") Then

            '===============================
            If TextBox14.Text = "تم مراجعته ويوجد اخطاء" Then
                Me.Button2.Visible = False

                Me.Button10.Visible = False
                '=============
                Me.Button4.Visible = True
                Me.Button3.Visible = True
                Me.Button1.Visible = True
                Me.Panel2.Enabled = False
            ElseIf RadioButton6.Checked = True Then

                Me.Button2.Visible = False

                Me.Button10.Visible = False
                '=============
                Me.Button4.Visible = False
                Me.Button3.Visible = False
                Me.Button1.Visible = False
                Me.Panel2.Enabled = False


            End If

        End If



        If sefa = "مراجع" Then



            Me.Panel2.Enabled = True
            If TextBox14.Text = "تم مراجعته ويوجد اخطاء" Then
                Me.Button2.Visible = False

                Me.Button10.Visible = False

                Me.Button1.Visible = False
                Me.Button4.Visible = False
                Me.Button3.Visible = False
                Me.Panel2.Enabled = True
            ElseIf RadioButton6.Checked = True Then
                Me.Button2.Visible = False

                Me.Button10.Visible = False

                Me.Button1.Visible = False
                Me.Button4.Visible = False
                Me.Button3.Visible = False
                Me.Panel2.Enabled = True

            End If





        End If


    End Sub

  


    Sub stouck(ByVal my_text As String)

        Dim i, w As Integer


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sql As String = "select * from RcvSub where RcvSub.[no_c]='" + my_text + "'"
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
            If DROW1("no_c") = (my_text) Then

                y = Val(DROW1("qun_r"))
                sum_irct = sum_irct + y
            End If

        Next
        cn.Close()
        '===============اجمالي المصروف==================

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq3 As String = "select * from IsuSub where IsuSub.[no_c] ='" + my_text + "'"

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
            If DROW3("no_c") = (my_text) Then

                y2 = Val(DROW3("qun_s"))
                sum_iiss = sum_iiss + y2

            End If
        Next
        cn.Close()
        '===============اجمالي مرتجعه==================


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq4 As String = "select * from matt_return where matt_return.[no_c] ='" + my_text + "'"

        Dim ad4 As New SqlDataAdapter(sq4, cn)
        Dim ds4 As New DataSet()
        Dim TD4 As DataTable
        Dim DROW4 As DataRow
        Dim y4 As Decimal
        'Me.sum_iiss = 0
        y4 = 0.0
        ad4.Fill(ds4, sq4)
        TD4 = ds4.Tables(sq4)

        For w = 0 To TD4.Rows.Count - 1
            DROW4 = TD4.Rows(w)

            If DROW4("no_c") = (my_text) Then

                y4 = Val(DROW4("qun_t"))
                sum_return = sum_return + y4

            End If
        Next
        cn.Close()
        '===============تالف==================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq5 As String = "select * from sub_TALEF where sub_TALEF.[no_c] ='" + my_text + "'"

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

            If DROW5("no_c") = (my_text) Then

                y5 = Val(DROW5("qun_T"))
                sum_talf = sum_talf + y5

            End If
        Next
        cn.Close()
        Me.total_s = 0


        Me.total_s = ((sum_irct + sum_return) - sum_iiss) - sum_talf

        '=======================================================
        'stouck_matt()
    End Sub
    Sub tot_ins()
        If Me.TextBox8.Text <> "" Then

            Dim inf_t, y As Decimal
            inf_t = 0.0
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim sql As String = "select * from RcvSub where no_i ='" + TextBox8.Text + "'"
            Dim ad1 As New SqlDataAdapter(sql, cn)
            Dim ds1 As New DataSet()
            Dim TD1 As DataTable
            Dim DROW1 As DataRow

            y = 0.0

            ad1.Fill(ds1, sql)
            TD1 = ds1.Tables(sql)

            For i = 0 To TD1.Rows.Count - 1
                DROW1 = TD1.Rows(i)
                If DROW1("no_i") = (TextBox8.Text) Then

                    y = CDbl(DROW1("gema"))
                    inf_t = CDbl(inf_t) + CDbl(y)
                End If

            Next
            Me.Label1.Text = CDbl(inf_t)
            cn.Close()


            '===========================================
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim ss As String = "update RcvMain set no_i=@x1,g_b=@x2,tvg=@x3 where no_i=@x1"
            Dim cms As New SqlCommand(ss, cn)
            cms.Parameters.Add((New SqlParameter("@x1", Trim(TextBox8.Text))))
            cms.Parameters.Add(New SqlParameter("@x2", Label1.Text))
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
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'If DataGridViewX2.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub
        '***************************
        If DataGridViewX2.RowCount = 0 Then
            MessageBox.Show("لاتوجد عناصر تم ادخالهاالي اذن الاستلام")
        End If

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        Dim Trans As SqlTransaction = cn.BeginTransaction

        Try
            Dim s As String = "insert into RcvMain(no_i,date_i,j_r,n_txt,n1_txt,g_b,tvg,u_name,dep_m,dep_mt,dep_nom,name_stock) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9,@x10,@x11,@x12)"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", CStr(Trim(TextBox8.Text))))
            cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
            cm.Parameters.Add(New SqlParameter("@x3", Me.ComboBox1.SelectedValue))
            cm.Parameters.Add(New SqlParameter("@x4", TextBox5.Text))
            cm.Parameters.Add(New SqlParameter("@x5", TextBox2.Text))
            cm.Parameters.Add(New SqlParameter("@x6", 0))
            cm.Parameters.Add(New SqlParameter("@x7", 0))
            cm.Parameters.Add(New SqlParameter("@x8", ww))
            cm.Parameters.Add(New SqlParameter("@x9", False))
            cm.Parameters.Add(New SqlParameter("@x10", ""))
            cm.Parameters.Add(New SqlParameter("@x11", True))
            'cm.Parameters.Add((New SqlParameter("@x12", TextBox3.Text)))
            cm.Parameters.Add((New SqlParameter("@x12", ww)))
            cm.Transaction = Trans

            cm.ExecuteNonQuery()

            '=======================================
            For i As Integer = 0 To DataGridViewX2.RowCount - 1



                Dim sqls As String = "insert into RcvSub(no_c,no_i,qun_r,sal_s,gema,txt_s,mt)values(@no_c,@no_i,@qun_r,@sal_s,@gema,@txt_s,@mt)"
                Dim cm1 As New SqlCommand(sqls, cn)
                cm1.Parameters.AddWithValue("@no_c", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                cm1.Parameters.AddWithValue("@no_i", Trim(TextBox8.Text)).DbType = DbType.String
                cm1.Parameters.AddWithValue("@qun_r", DataGridViewX2.Rows(i).Cells(1).Value).DbType = DbType.Int32
                cm1.Parameters.AddWithValue("@sal_s", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.Decimal
                cm1.Parameters.AddWithValue("@gema", DataGridViewX2.Rows(i).Cells(3).Value).DbType = DbType.Decimal
                cm1.Parameters.AddWithValue("@txt_s", DataGridViewX2.Rows(i).Cells(4).Value).DbType = DbType.String
                cm1.Parameters.AddWithValue("@mt", DataGridViewX2.Rows(i).Cells(5).Value).DbType = DbType.String

                cm1.Transaction = Trans
                cm1.ExecuteNonQuery()

         
                Dim sql As String = "insert into salahia(no_c,date_end,mdh,mdh_a,date_mdh,sal_s,no_i,date_i,state_sal) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim cms As New SqlCommand(sql, cn)
                cms.Parameters.AddWithValue("@x1", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                cms.Parameters.AddWithValue("@x2", DataGridViewX2.Rows(i).Cells(6).Value).DbType = DbType.Date
                cms.Parameters.AddWithValue("@x3", Trim(DataGridViewX2.Rows(i).Cells(7).Value)).DbType = DbType.String
                cms.Parameters.AddWithValue("@x4", DataGridViewX2.Rows(i).Cells(8).Value).DbType = DbType.String
                cms.Parameters.AddWithValue("@x5", DataGridViewX2.Rows(i).Cells(9).Value).DbType = DbType.Date
                cms.Parameters.AddWithValue("@x6", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.Decimal
                cms.Parameters.AddWithValue("@x7 ", Trim(TextBox8.Text)).DbType = DbType.String
                cms.Parameters.AddWithValue("@x8", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")).DbType = DbType.Date
                cms.Parameters.AddWithValue("@x9", 0).DbType = DbType.Int16
                cms.Transaction = Trans
                cms.ExecuteNonQuery()



                '==========smove_no_i===============


                Dim smov As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i,count1) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7)"
                Dim cmsmov As New SqlCommand(smov, cn)
                cmsmov.Parameters.AddWithValue("@x1", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                cmsmov.Parameters.AddWithValue("@x2", DataGridViewX2.Rows(i).Cells(1).Value).DbType = DbType.Int32
                cmsmov.Parameters.AddWithValue("@x3", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.Decimal
                cmsmov.Parameters.AddWithValue("@x4", Me.move_no).DbType = DbType.Int32
                cmsmov.Parameters.AddWithValue("@x5", Trim(TextBox8.Text)).DbType = DbType.String
                cmsmov.Parameters.AddWithValue("@x6", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")).DbType = DbType.Date
                cmsmov.Parameters.AddWithValue("@x7", 0).DbType = DbType.Int32

                cmsmov.Transaction = Trans
                cmsmov.ExecuteNonQuery()


                '=====acthion_tran================



                Dim stran As String = "insert into acthion_tran(info,no_c,date_i,qun_tot,sal_s) values (@x1,@x2,@x3,@x4,@x5)"
                Dim cmtran As New SqlCommand(stran, cn)
                cmtran.Parameters.AddWithValue("@x1", Trim(TextBox8.Text)).DbType = DbType.String
                cmtran.Parameters.AddWithValue("@x2", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                cmtran.Parameters.AddWithValue("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")).DbType = DbType.Date
                cmtran.Parameters.AddWithValue("@x4", DataGridViewX2.Rows(i).Cells(1).Value).DbType = DbType.Int32
                cmtran.Parameters.AddWithValue("@x5", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.Decimal
                cmtran.Transaction = Trans
                cmtran.ExecuteNonQuery()



                '=========================

                t_event = "حفظ صنف"
                t_doc = "اذن الاستلام"
                ts = TimeOfDay


                Dim sevent As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim cmevent As New SqlCommand(sevent, cn)
                cmevent.Parameters.AddWithValue("@x1", Trim(TextBox8.Text)).DbType = DbType.String
                cmevent.Parameters.AddWithValue("@x2", t_doc).DbType = DbType.String
                cmevent.Parameters.AddWithValue("@x3", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                cmevent.Parameters.AddWithValue("@x4", DataGridViewX2.Rows(i).Cells(1).Value).DbType = DbType.Int32
                cmevent.Parameters.AddWithValue("@x5", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.Decimal
                cmevent.Parameters.AddWithValue("@x6", Format(Now.Date, "yyyy/MM/dd")).DbType = DbType.Date
                cmevent.Parameters.AddWithValue("@x7", ts)
                cmevent.Parameters.AddWithValue("@x8", ww).DbType = DbType.String
                cmevent.Parameters.AddWithValue("@x9", t_event).DbType = DbType.String

                cmevent.Transaction = Trans
                cmevent.ExecuteNonQuery()




                '=======================تعديل المخزون========================

                If DataGridViewX2.Rows(i).Cells(4).Value = "تم اظافته كرصيد منقول".ToString Then
                    siopb = DataGridViewX2.Rows(i).Cells(1).Value

                    Dim ss1 As String = "update  matt set no_c=@x1,balance=@x2,iopb=@x3,irct=@x5 where no_c=@x1"
                    Dim cmst As New SqlCommand(ss1, cn)
                    cmst.Parameters.AddWithValue("@x1", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                    cmst.Parameters.AddWithValue("@x2", total_s).DbType = DbType.Decimal
                    cmst.Parameters.AddWithValue("@x3", Me.siopb).DbType = DbType.Decimal
                    cmst.Parameters.AddWithValue("@x5", sum_irct).DbType = DbType.Decimal

                    cmst.Transaction = Trans
                    cmst.ExecuteNonQuery()


                Else

                    Dim sss1 As String = "update  matt set no_c=@x1,balance=@x2,irct=@x5 where no_c=@x1"
                    Dim cmst1 As New SqlCommand(sss1, cn)
                    cmst1.Parameters.AddWithValue("@x1", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                    cmst1.Parameters.Add(New SqlParameter("@x2", total_s)).DbType = DbType.Decimal
                    cmst1.Parameters.Add(New SqlParameter("@x5", sum_irct)).DbType = DbType.Decimal

                    cmst1.Transaction = Trans
                    cmst1.ExecuteNonQuery()

                End If



            Next

            '===============================
            Trans.Commit()
            MsgBox("حفظ اذن الاستلام", MsgBoxStyle.Information, " حفظ")
            total_inf()
        Catch err As System.Exception

            Trans.Rollback()
            MsgBox("لم يتم حفظ اذن الاستلام", MsgBoxStyle.Information, " حفظ")
            MsgBox(err.Message)

        Finally
        End Try

        'ImportersDA = New SqlDataAdapter

        Me.Button2.Enabled = False
        Me.Button10.Enabled = False
        tot_ins()
        'DataGridViewX2.DataSource = Nothing
       
    End Sub
    Function slhia(ByVal mytext As Integer) As Integer
        'اقل من تاريخ اليوم

        Dim mdh As Integer
        Dim y, d As Date


        'mdh = mytext
        'd = DateTimePicker2.Value
        'y = Date.Now.AddDays(-mdh)
        'TextBox12.Text = y
     
        mdh = mytext
        d = Format(DateTimePicker2.Value.Date, "yyyy/MM/dd")

        If Me.ComboBox2.Text = "ايام" Then
            TextBox12.Text = d.AddDays(-mdh)
            'TextBox4.Text = mdh
        End If
        If ComboBox2.Text = "اسابيع" Then
            mdh = 7 * mdh
            TextBox12.Text = d.AddDays(-mdh)
            'TextBox4.Text = mdh
        End If
        If ComboBox2.Text = "اشهر" Then
            mdh = 31 * mdh
            TextBox12.Text = d.AddDays(-mdh)
        End If

        If ComboBox2.Text = "سنة" Then
            mdh = (12 * 30) * mdh
            TextBox12.Text = d.AddDays(-mdh)
        End If
        '===================================================
       

    End Function

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
       
        If ComboBox2.Text = "لايوجد" Or TextBox13.Text = "0" Then
            TextBox13.Text = 0
            Exit Sub
        Else
            slhia(TextBox13.Text)
        End If

    End Sub

    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        If TextBox13.Text = "" Then
            MsgBox("ادخل بيانات الصلاحية ", MsgBoxStyle.Information, "تنبية")
            TextBox13.Text = 0
            Exit Sub
        End If
        If ComboBox2.Text = "لايوجد" Or TextBox13.Text = "0" Then
            TextBox12.Text = 0
            'MsgBox(" هذا الصنف لم تدخل له بيانات الصلاحية", MsgBoxStyle.Information, "تنبية")
            Exit Sub


        Else
            slhia(TextBox13.Text)
        End If



    End Sub


    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
      
        If Me.TextBox8.Text.ToString = "" Then
            MsgBox("أدخل رقم اذن الاستلام ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox8.Focus()
            Exit Sub
        End If
        serch_no_c()
        If s_n = False Then
            MsgBox("الصنف لم يتم تعريفه ", MsgBoxStyle.Exclamation, "إجراء بحث")
            Exit Sub
        End If
        If Me.ComboBox1.SelectedIndex = -1 Then
            MsgBox(" اختار جهة التوريد", MsgBoxStyle.Information, "إجراء إضافة")
            ComboBox1.Focus()
            Exit Sub
        End If
        If Me.TextBox5.Text.ToString = "" Then
            MsgBox("ادخل الاصناف واردة بموجب:  ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox5.Focus()
            Exit Sub
        End If
        If Me.TextBox1.Text = "" Then
            MsgBox("أدخل رقم الصنف المرادإضافته ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox1.Focus()

            Exit Sub
        End If
        If Val(Me.TextBox6.Text).ToString = "" Or Val(Me.TextBox6.Text) = 0 Then
            MsgBox("أدخل الكمية المراد استلامها", MsgBoxStyle.Information, " إجراء إضافة")
            TextBox6.Focus()
            Exit Sub
        End If

        If Me.TextBox9.Text.ToString = "" Or Me.TextBox9.Text = "0.000" Or Me.TextBox9.Text = "0" Or Me.TextBox9.Text = "0.00" Then
            MsgBox("ادخل سعر الوحدة", MsgBoxStyle.Information, "إجراء إضافة ")
            TextBox9.Focus()
            Exit Sub
        End If
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MsgBox("اختار  اما رصيد منقول او اضافه", MsgBoxStyle.Information, "إجراء إضافة ")
            Exit Sub
        End If
        If Me.TextBox3.Text.ToString = "" Then
            MsgBox("أدخل اسم امين المخزن ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox3.Focus()
            Exit Sub
        End If
       
        If (Me.TextBox13.Text.ToString <> 0) And (ComboBox2.Text = "لايوجد" Or ComboBox2.Text = "") Then
            MsgBox("راجع المدة ونوع المدة ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox13.Focus()
            Exit Sub
        End If
        If ComboBox2.Text <> "لايوجد" Or TextBox13.Text <> "0" Then
            slhia(TextBox13.Text)
        End If

        If Format(DateTimePicker2.Value.Date, "yyyy/MM/dd") <= Format(Date.Now, "yyyy/MM/dd") And (Me.TextBox13.Text.ToString <> 0) And ((ComboBox2.Text <> "لايوجد" Or ComboBox2.Text = "")) Then
            MsgBox("تاريخ انتهاء الصلاحية يساوي اليوم  ", MsgBoxStyle.Information, "إجراء إضافة")

            Exit Sub
        End If
        ImportersDA = New SqlDataAdapter("SELECT no_c,qun_r , sal_s , gema , txt_s ,mt, date_end, mdh, mdh_a, date_mdh  from View_sl  WHERE no_i='" + TextBox8.Text + "'", cn)
        ImportersDA.Fill(ImportersDT)

        ImportersDT.Rows.Add()
        Dim last As Integer = ImportersDT.Rows.Count - 1
        ImportersDT.Rows(last).Item("no_c") = Trim(TextBox1.Text)
        ImportersDT.Rows(last).Item("qun_r") = CInt(TextBox6.Text)
        ImportersDT.Rows(last).Item("sal_s") = CDec(TextBox9.Text)
        ImportersDT.Rows(last).Item("gema") = CDec(TextBox10.Text)
        If Me.RadioButton1.Checked = True Then
            ImportersDT.Rows(last).Item("txt_s") = "تم اظافته كرصيد منقول".ToString
            move_no = "1"

        ElseIf Me.RadioButton2.Checked = True Then
            move_no = "2"
            ImportersDT.Rows(last).Item("txt_s") = "تم اظافته".ToString
        End If

        If Me.RichTextBox1.Text = "" Then
            ImportersDT.Rows(last).Item("mt") = "لايوجد".ToString
        Else
            ImportersDT.Rows(last).Item("mt") = Me.RichTextBox1.Text
        End If

        If Me.TextBox13.Text <> 0 Then


            ImportersDT.Rows(last).Item("date_end") = Format(DateTimePicker2.Value.Date, "yyyy/MM/dd")
            ImportersDT.Rows(last).Item("mdh_a") = Trim(Me.ComboBox2.Text)
            ImportersDT.Rows(last).Item("mdh") = Trim(TextBox13.Text)
            ImportersDT.Rows(last).Item("date_mdh") = TextBox12.Text
        Else
            ImportersDT.Rows(last).Item("date_end") = "1990/01/01"
            ImportersDT.Rows(last).Item("mdh_a") = "لايوجد".ToString
            ImportersDT.Rows(last).Item("mdh") = 0
            ImportersDT.Rows(last).Item("date_mdh") = "1990/01/01"

        End If
        Me.Button2.Enabled = True
        DataGridViewX2.DataSource = ImportersDT


        'ImportersDA = New SqlDataAdapter

        'DataGridViewX2.DataMember = ""
        'DataGridViewX2.DataSource = Nothing


        clear_tool()

    End Sub
    Sub clear_tool()
        TextBox11.Text = ""
        TextBox1.Text = ""
        TextBox6.Text = 0
        TextBox9.Text = 0.0
        TextBox10.Text = 0.0
        ComboBox2.Text = "لايوجد"
        TextBox13.Text = "0"
        TextBox12.Text = 0
        RichTextBox1.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False

    End Sub
  
    Sub serch_no_c()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If TextBox1.Text <> "" Then
            Dim s As String = "select * from matt_t where no_c=@x1"
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add(New SqlParameter("@x1", (TextBox1.Text)))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader
                If r.Read = True Then
                    TextBox11.Text = r!name_snc
                    Me.TextBox4.Text = r!iopb
                    Me.Label14.Text = r!name_type
                    s_n = True
                    'If r!iopb <> 0 Then
                    '    RadioButton1.Enabled = False
                    '    RadioButton2.Checked = True
                    '    'RadioButton2.Enabled = False

                    'Else
                    '    RadioButton1.Enabled = True
                    '    RadioButton2.Enabled = True
                    '    'RadioButton1.Enabled = True
                    '    'RadioButton2.Enabled = True
                    'End If
                    r.Close()
                Else
                    'MsgBox("هذا الصنف لم يتم تعريفة بعد", MsgBoxStyle.OkOnly, "تنبية")
                    'TextBox11.Clear()
                    'RadioButton1.Enabled = False
                    'RadioButton2.Enabled = False
                    r.Close()
                    cn.Close()
                    s_n = False
                    Exit Sub
                    r.Close()

                End If
                r.Close()
            Catch

            End Try


            cn.Close()

        End If
        cn.Close()


    End Sub
    Private Sub TextBox10_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox10.Validating
        If Me.TextBox10.Text = "" Then
            Me.TextBox10.Text = "0.000"
        End If

        'TextBox4.Text = (Me.TextBox4.Text) + CDec(TextBox10.Text)
        Dim x As String
        'x = man10(TextBox10.Text)
        'Me.up_tot()

    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", ".", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select


    End Sub

    Private Sub TextBox9_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox9.Validating
        If Me.TextBox9.Text = "" Then
            Me.TextBox9.Text = "0.000"
        End If
        Dim x As String
        x = man9(TextBox9.Text)
        TextBox10.Text = Val(TextBox6.Text) * Val(TextBox9.Text)
        'Text1.Text = Format(Text1.Text, "###,###,##0.00")
    End Sub

    Private Sub TextBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Enter
        If TextBox1.Text <> "" Then
            serch_no_c()
        Else
            TextBox11.Clear()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text <> "" Then
              serch_no_c()
            Else
                TextBox11.Clear()
            End If
        End If
    End Sub


    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        If TextBox1.Text <> "" Then
            serch_no_c()
            'If s_n = False Then
            '    MsgBox("الصنف لم يتم تعريفه ", MsgBoxStyle.Exclamation, "إجراء بحث")
            'End If
        Else
            TextBox11.Clear()
        End If

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            serch_no_c()
            'If s_n = False Then
            '    MsgBox("الصنف لم يتم تعريفه ", MsgBoxStyle.Exclamation, "إجراء بحث")
            'End If
        Else
            TextBox11.Clear() 'clear_a()
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Me.RadioButton1.Checked = True Then

            Me.TextBox4.Text = TextBox6.Text
        End If
    End Sub

    Private Sub RadioButton1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RadioButton1.Validating
        If Me.RadioButton1.Checked = True Then

            Me.TextBox4.Text = TextBox6.Text
        Else

            Me.TextBox4.Text = 0

        End If
    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged
        Dim x As String
        x = man10(TextBox10.Text)
    End Sub
    Sub total_inf()

        If (Me.TextBox8.Text.ToString) <> " " Then
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s11 As String = "SELECT * FROM RcvMain WHERE no_i=@x1"
            Dim cm As New SqlCommand(s11, cn)
            cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader

                If r.Read = True Then


                    TextBox5.Text = r!n_txt.ToString
                    TextBox2.Text = r!n1_txt.ToString
                    Me.DateTimePicker1.Value = r!date_i
                    Me.ComboBox1.SelectedValue = r!j_r
                    TextBox3.Text = r!name_stock.ToString

                    tot = True

                    TextBox14.Text = r!dep_mt.ToString

                    If TextBox14.Text = "تم مراجعته ولايوجد اخطاء" Then
                        RadioButton7.Checked = r!dep_m
                        Panel2.Enabled = False
                        Me.Button1.Enabled = False
                        Me.Button3.Enabled = False
                        Me.Button4.Enabled = False

                        Me.Button10.Enabled = False
                        Me.Button2.Enabled = False
                    End If

                    If TextBox14.Text = "تم مراجعته ويوجد اخطاء" Then

                        RadioButton8.Checked = r!dep_m

                    End If


                    RadioButton6.Checked = r!dep_nom
                    r.Close()
                    cn.Close()

                    'Panel1.Enabled = True

                    ''Me.TextBoxX6.ReadOnly = False

                    ''Me.TextBox6.ReadOnly = False
                    ''Me.TextBox9.ReadOnly = False
                    ''Me.TextBox10.ReadOnly = False

                    ''Me.TextBox11.ReadOnly = False

                    'Me.Button2.Enabled = False
                    'Me.Button3.Enabled = True
                    'Me.Button4.Enabled = True

                    'val_sefa()

                Else

                    'MsgBox(" اذن الاستلام غير موجود ", MsgBoxStyle.Critical, "تنبية")
                    'Me.LabelX1.Text = "0.000"
                    'Me.LabelX3.Text = "صفر دينار فقـط"


                    'Me.TextBoxX6.ReadOnly = True
                    'Me.TextBox11.ReadOnly = True

                    'Me.TextBox6.ReadOnly = True
                    'Me.TextBox9.ReadOnly = True
                    'Me.TextBox10.ReadOnly = True



                    'TextBox5.Text = ""
                    'TextBox2.Text = "بلا"
                    ''TextBoxX1.Text = ""
                    'Panel1.Enabled = False
                    'Me.DateTimePicker1.Value = Date.Now
                    'Me.ComboBox1.SelectedValue = -1
                    'TextBox3.Text = ""

                    'Me.Button2.Enabled = True
                    'Me.Button3.Enabled = False
                    'Me.Button4.Enabled = False

                    'Me.ButtonX1.Enabled = False
                    'Me.ButtonX2.Enabled = False
                    'Me.ButtonX3.Enabled = False

                    'Me.RadioButton1.Checked = False
                    'Me.RadioButton2.Checked = False
                    ''TextBox8.Clear()
                    tot = False

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

            Dim a As String
            a = Me.TextBox8.Text
            Dim ds2 As New DataSet()
            ds2.Clear()
            Dim sql1 As String
            'sql1 = " SELECT no_c,qun_r , sal_s , gema , txt_s ,mt, date_end, mdh, mdh_a, date_mdh  from View_sl WHERE no_i='" + TextBox8.Text + "'"

            sql1 = "SELECT no_c as[رقم الصنف],qun_r as[الكمية], sal_s as[سعر الوحدة], gema as[القيمة], txt_s as[حاله الاضافه],no_c,mt,date_end as [تاريخ انتهاء الصلاحية],mdh as [المدة قبل انتهاء الصلاحية],mdh_a as [نوع المدة],date_mdh as [تاريخ التنبيه] from View_sl  WHERE no_i='" + TextBox8.Text + "'"
            Dim ad As New SqlDataAdapter(sql1, cn)
            ds2.Clear()
            ad.Fill(ds2, "View_sl")
            Me.DataGridViewX2.DataSource = ds2
            Me.DataGridViewX2.DataMember = "View_sl"
            Me.DataGridViewX2.Refresh()
            cn.Close()
            '==================================


            'If tot = True Then

            '    '"اذن الاستلام  موجود"

            '    If RadioButton3.Checked = True Then
            '        'لم تتم مراجعته

            '        If (sefa = "امين مخزن") Then
            '            Me.Panel3.Enabled = False
            '            Me.ButtonX1.Enabled = True
            '            Me.Button2.Enabled = False
            '            Me.Button3.Enabled = False
            '            Me.ButtonX2.Enabled = False
            '            Me.ButtonX4.Enabled = False

            '            Me.ButtonX3.Enabled = False
            '            Me.Button4.Enabled = True
            '            'Me.ButtonX6.Enabled = True
            '            Me.Panel6.Enabled = False
            '            Panel1.Enabled = True
            '        End If

            '        If sefa = "مراجع" Then
            '            Me.Panel1.Enabled = False
            '            Me.Panel3.Enabled = True
            '            Me.Panel6.Enabled = False
            '            Me.Panel5.Enabled = False
            '        End If
            '    End If
            '    ' تتم مراجعته
            '    '"تم مراجعته ولايوجد اخطاء"
            '    If RadioButton4.Checked = True Then
            '        Me.Panel1.Enabled = False
            '        Me.Panel3.Enabled = False
            '        Me.Panel5.Enabled = False
            '        Me.Panel4.Enabled = False
            '        Me.GroupBox1.Enabled = False
            '        Me.Panel6.Enabled = False
            '        Me.Panel5.Enabled = False
            '        eror_m = False
            '    End If
            '    '"تم مراجعته ويوجد اخطاء" 
            '    If RadioButton5.Checked = True Then

            '        If (sefa = "مراقب المخزون") Then
            '            Me.Panel3.Enabled = False
            '            Me.ButtonX1.Enabled = False
            '            Me.Button2.Enabled = False
            '            Me.Panel1.Enabled = True
            '            Me.Panel6.Enabled = False
            '            Me.Button3.Enabled = True
            '            Me.ButtonX2.Enabled = False
            '            'Me.ButtonX4.Enabled = True
            '            eror_m = True

            '        End If
            '        If (sefa = "امين مخزن") Then
            '            Me.Panel3.Enabled = False
            '            Me.ButtonX1.Enabled = False
            '            Me.Button2.Enabled = False
            '            Me.Button3.Enabled = False
            '            Me.ButtonX2.Enabled = False
            '            Me.ButtonX4.Enabled = False
            '            eror_m = False
            '            Me.Panel1.Enabled = False
            '            Me.GroupBox1.Enabled = False
            '            Me.Panel5.Enabled = False
            '            Me.Panel6.Enabled = False
            '        End If
            '        If sefa = "مراجع" Then
            '            Me.Panel1.Enabled = False
            '            Me.Panel3.Enabled = True
            '            Me.Panel5.Enabled = False
            '            Me.Panel6.Enabled = False
            '            eror_m = False
            '        End If
            '    End If


            'Else
            '    '"اذن الاستلام غير موجود"
            '    If (sefa = "امين مخزن") Then
            '        Me.Panel3.Enabled = False
            '        Me.ButtonX1.Enabled = True
            '        Me.Button2.Enabled = True
            '        Me.Button3.Enabled = False
            '        Me.ButtonX2.Enabled = False
            '        Me.ButtonX4.Enabled = False

            '        Me.Panel1.Enabled = True
            '        Me.GroupBox1.Enabled = True
            '        Me.Panel5.Enabled = True
            '        Me.Panel6.Enabled = True
            '    End If
            '    If (sefa = "مراقب المخزون") Then
            '        Me.Panel3.Enabled = False
            '        Me.ButtonX1.Enabled = False
            '        Me.Button2.Enabled = False

            '        Me.Button3.Enabled = False
            '        Me.ButtonX2.Enabled = False
            '        Me.ButtonX4.Enabled = False
            '    End If

            '    If sefa = "مراجع" Then
            '        Me.Panel1.Enabled = False
            '        Me.Panel3.Enabled = False
            '        Me.Panel5.Enabled = False
            '        Me.Panel6.Enabled = False
            '    End If
        End If



    End Sub
    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        total_inf()
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        If Me.RadioButton1.Checked = True Then

            Me.TextBox4.Text = TextBox6.Text
        Else

            Me.TextBox4.Text = 0

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton1.Checked = True Then

            Me.TextBox4.Text = TextBox6.Text
        Else

            Me.TextBox4.Text = 0

        End If
    End Sub

    Private Sub DateTimePicker2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.TextChanged

    End Sub
  

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        ''If ComboBox2.Text = "لايوجد" Or TextBox13.Text = 0 Then
        ''    'MsgBox(" هذا الصنف لم تدخل له بيانات الصلاحية", MsgBoxStyle.Information, "تنبية")
        ''    DateTimePicker2.Value = Date.Now
        ''    Exit Sub
        ''End If
        'slhia(TextBox13.Text)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.TextBox8.Text.ToString = "" Then
            MsgBox("أدخل رقم اذن الاستلام ", MsgBoxStyle.Information, "إجراء تعديل")
            TextBox8.Focus()
            Exit Sub
        End If

        If Me.ComboBox1.SelectedIndex = -1 Then
            MsgBox(" اختار جهة التوريد", MsgBoxStyle.Information, "إجراء تعديل")
            ComboBox1.Focus()
            Exit Sub
        End If
        If Me.TextBox5.Text.ToString = "" Then
            MsgBox("ادخل الاصناف واردة بموجب:  ", MsgBoxStyle.Information, "إجراء تعديل")
            TextBox5.Focus()
            Exit Sub
        End If
        If Me.TextBox1.Text = "" Then
            MsgBox("أدخل رقم الصنف المرادإضافته ", MsgBoxStyle.Information, "إجراء تعديل")
            TextBox1.Focus()

            Exit Sub
        End If
        If Val(Me.TextBox6.Text).ToString = "" Or Val(Me.TextBox6.Text) = 0 Then
            MsgBox("أدخل الكمية المراد استلامها", MsgBoxStyle.Information, " إجراء تعديل")
            TextBox6.Focus()
            Exit Sub
        End If

        If Me.TextBox9.Text.ToString = "" Or Me.TextBox9.Text = "0.000" Or Me.TextBox9.Text = "0" Or Me.TextBox9.Text = "0.00" Then
            MsgBox("ادخل سعر الوحدة", MsgBoxStyle.Information, "إجراء تعديل ")
            TextBox9.Focus()
            Exit Sub
        End If
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MsgBox("اختار  اما رصيد منقول او اضافه", MsgBoxStyle.Information, "إجراء تعديل ")
            Exit Sub
        End If
        If Me.TextBox3.Text.ToString = "" Then
            MsgBox("أدخل اسم امين المخزن ", MsgBoxStyle.Information, "إجراء تعديل")
            TextBox3.Focus()
            Exit Sub
        End If

        If (Me.TextBox13.Text.ToString <> 0) And (ComboBox2.Text = "لايوجد" Or ComboBox2.Text = "") Then
            MsgBox("راجع المدة ونوع المدة ", MsgBoxStyle.Information, "إجراء تعديل")
            TextBox13.Focus()
            Exit Sub
        End If

        If Format(DateTimePicker2.Value.Date, "yyyy/MM/dd") <= Date.Now And (Me.TextBox13.Text.ToString <> 0) And ((ComboBox2.Text <> "لايوجد" Or ComboBox2.Text = "")) Then
            MsgBox("تاريخ انتهاء الصلاحية اقل من او  يساوي تاريخ اليوم  ", MsgBoxStyle.Information, "إجراء تعديل")

            Exit Sub
        End If
        If Trim(Me.TextBox13.Text) = "" Then
            'MsgBox("أدخل اسم امين المخزن ", MsgBoxStyle.Information, "إجراء تعديل")
            TextBox13.Focus()
            Exit Sub
        End If
        'If Me.ComboBox2.Text <> "ايام" Or Me.ComboBox2.Text <> "اسابيع" Or Me.ComboBox2.Text <> "اشهر" Or Me.ComboBox2.Text <> "سنة" Then
        '    'MsgBox("اختار من القائمة لاتكتب ", MsgBoxStyle.Information, "تنبية")
        '    Exit Sub
        'End If
        'If ComboBox2.Text = "ايام" Then
        slhia(TextBox13.Text)

        'End If
        'Me.ComboBox2.Text <> "ايام" Or Me.ComboBox2.Text <> "اسابيع" Or Me.ComboBox2.Text <> "اشهر" Or Me.ComboBox2.Text <> "سنة" Then
        ''MsgBox("اختار من القائمة لاتكتب ", MsgBoxStyle.Information, "تنبية")





        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        '=========================
        Dim s As String = "select * from tran_IRT where no_c=@x1 and date_i=@x3 and tr_type=@x4 and price=@x5"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cm.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cm.Parameters.Add(New SqlParameter("@x4", 3))
        cm.Parameters.Add(New SqlParameter("@x5", CDec(TextBox7.Text)))
        Try
            Dim r1 As SqlDataReader = cm.ExecuteReader
            If r1.Read = True Then
                r1.Close()
                MessageBoxEx.Show("لا تستطيع التعديل لان الصنف  تم الصرف منه", "مخازن", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                r1.Close()
            End If
        Catch

        End Try
        '===========================

        Dim st As String = "select * from tran_IRT where no_c=@x1 and date_i=@x3 and tr_type=@x4 and price=@x5"
        Dim cmt As New SqlCommand(st, cn)
        cmt.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cmt.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cmt.Parameters.Add(New SqlParameter("@x4", 4))
        cmt.Parameters.Add(New SqlParameter("@x5", CDec(TextBox7.Text)))
        Try
            Dim r1 As SqlDataReader = cmt.ExecuteReader
            If r1.Read = True Then
                r1.Close()
                MessageBoxEx.Show("لا تستطيع التعديل لان الصنف  تم اتلاف كميات منه", "اجراء تعديل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                r1.Close()
            End If
        Catch

        End Try
        Dim stm As String = "select * from tran_IRT where no_c=@x1 and date_i=@x3 and tr_type=@x4 and price=@x5"
        Dim cmtm As New SqlCommand(stm, cn)
        cmtm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cmtm.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cmtm.Parameters.Add(New SqlParameter("@x4", 5))
        cmtm.Parameters.Add(New SqlParameter("@x5", CDec(TextBox7.Text)))
        Try
            Dim r1 As SqlDataReader = cmtm.ExecuteReader
            If r1.Read = True Then
                r1.Close()
                MessageBoxEx.Show("لا تستطيع التعديل لان الصنف  تم ارجاع كميات منه", "اجراء تعديل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                r1.Close()
            End If
        Catch

        End Try

        '=======================================



        Dim Trans As SqlTransaction = cn.BeginTransaction

        Try

            Dim sr As String = "update RcvMain set no_i=@x1,date_i=@x2,j_r=@x3,n_txt=@x4,n1_txt=@x5,name_stock=@x6 where no_i=@x1"
            Dim cmr As New SqlCommand(sr, cn)

            cmr.Parameters.Add(New SqlParameter("@x1", CStr(TextBox8.Text)))
            cmr.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
            cmr.Parameters.Add(New SqlParameter("@x3", Me.ComboBox1.SelectedValue))
            cmr.Parameters.Add(New SqlParameter("@x4", TextBox5.Text))
            cmr.Parameters.Add(New SqlParameter("@x5", TextBox2.Text))
            cmr.Parameters.Add((New SqlParameter("@x6", TextBox3.Text)))
            cmr.Transaction = Trans
            cmr.ExecuteNonQuery()

            '    '========================تعديل الاصناف===============

            Dim su As String = "update RcvSub set no_c=@x1,no_i=@x2,qun_r=@x3,sal_s=@x4,gema=@x5,txt_s=@x6,mt=@x7 where no_c=@x1 and no_i=@x2 and sal_s= " & Me.TextBox7.Text & ""
            Dim cmu As New SqlCommand(su, cn)

            cmu.Parameters.AddWithValue("@x1", Trim(TextBox1.Text)).DbType = DbType.String
            cmu.Parameters.AddWithValue("@x2", Trim(TextBox8.Text)).DbType = DbType.String
            cmu.Parameters.AddWithValue("@x3", Trim(TextBox6.Text)).DbType = DbType.Int32
            cmu.Parameters.AddWithValue("@x4", (TextBox9.Text)).DbType = DbType.Decimal
            cmu.Parameters.AddWithValue("@x5", (TextBox10.Text)).DbType = DbType.Decimal
            If Me.RadioButton1.Checked = True Then

                cmu.Parameters.AddWithValue("@x6", "تم اظافته كرصيد منقول").DbType = DbType.String


            ElseIf Me.RadioButton2.Checked = True Then

                cmu.Parameters.AddWithValue("@x6", "تم اظافته").DbType = DbType.String
            End If

            cmu.Parameters.AddWithValue("@x7", Me.RichTextBox1.Text).DbType = DbType.String

            cmu.Transaction = Trans
            cmu.ExecuteNonQuery()



            If Me.TextBox13.Text <> 0 Then

                Dim sql As String = "update salahia set no_c=@x1,date_end=@x2,mdh=@x3,mdh_a=@x4,date_mdh=@x5,sal_s=@x6,no_i=@x7,date_i=@x8 where no_c=@x1 and no_i=@x7 and sal_s= " & Me.TextBox7.Text & ""
                Dim cms As New SqlCommand(sql, cn)
                cms.Parameters.AddWithValue("@x1", Trim(TextBox1.Text))
                cms.Parameters.AddWithValue("@x2", Format(DateTimePicker2.Value.Date, "yyyy/MM/dd"))
                cms.Parameters.AddWithValue("@x3", TextBox13.Text)
                cms.Parameters.AddWithValue("@x4", Trim(Me.ComboBox2.Text))
                cms.Parameters.AddWithValue("@x5", CDate(TextBox12.Text))
                cms.Parameters.AddWithValue("@x6", CDec(TextBox9.Text))
                cms.Parameters.AddWithValue("@x7", Trim(TextBox8.Text))
                cms.Parameters.AddWithValue("@x8 ", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd"))

                cms.Transaction = Trans
                cms.ExecuteNonQuery()

            Else
                Dim sql As String = "update salahia set no_c=@x1,date_end=@x2,mdh=@x3,mdh_a=@x4,date_mdh=@x5,sal_s=@x6,no_i=@x7,date_i=@x8 where no_c=@x1 and no_i=@x7 and sal_s= " & Me.TextBox7.Text & ""
                Dim cms As New SqlCommand(sql, cn)
                cms.Parameters.AddWithValue("@x1", Trim(TextBox1.Text)).DbType = DbType.String
                cms.Parameters.AddWithValue("@x2", "1990/01/01")
                cms.Parameters.AddWithValue("@x3", 0).DbType = DbType.String
                cms.Parameters.AddWithValue("@x4", "لايوجد").DbType = DbType.String
                cms.Parameters.AddWithValue("@x5", "1990/01/01").DbType = DbType.Date
                cms.Parameters.AddWithValue("@x6", (TextBox9.Text)).DbType = DbType.Decimal
                cms.Parameters.AddWithValue("@x7", Trim(TextBox8.Text)).DbType = DbType.String
                cms.Parameters.AddWithValue("@x8 ", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")).DbType = DbType.Date
                cms.Parameters.AddWithValue("@x9", 0).DbType = DbType.Int16
                cms.Transaction = Trans
                cms.ExecuteNonQuery()

            End If
            ''        '==========smove_no_i===============

            Dim ss As Integer

            If Me.RadioButton1.Checked = True Then

                ss = 1
                Dim sd As String = "update tran_IRT set n_rs='" & TextBox8.Text & "' ,price=" & TextBox9.Text & ", no_c='" + TextBox1.Text + "' , quntity=" & Me.TextBox6.Text & ", tr_type=" & ss & " where n_rs='" & TextBox8.Text & "' and no_c='" + TextBox1.Text + "' and price=" & TextBox7.Text & ""
                Dim cmd As New SqlCommand(sd, cn)

                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()


            ElseIf Me.RadioButton2.Checked = True Then

                ss = 2

                Dim sd As String = "update tran_IRT set n_rs='" & TextBox8.Text & "' ,price=" & TextBox9.Text & ", no_c='" & TextBox1.Text & "' , quntity=" & Me.TextBox6.Text & " , tr_type=" & ss & " where n_rs='" & TextBox8.Text & "' and no_c='" & TextBox1.Text & "' and price=" & TextBox7.Text & ""
                Dim cmd As New SqlCommand(sd, cn)

                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

            End If


            '===== '=====acthion_tran================

            Dim s1 As String = "update acthion_tran set info=@x1,no_c=@x2,date_i=@x3,qun_tot=@x4,sal_s=@x5 where info=@x1 and date_i=@x3 and no_c=@x2 and sal_s= " & Me.TextBox7.Text & ""
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
            cm1.Parameters.Add(New SqlParameter("@x2", Trim(TextBox1.Text)))
            cm1.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
            cm1.Parameters.Add(New SqlParameter("@x4", TextBox6.Text))
            cm1.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
            cm1.Transaction = Trans
            cm1.ExecuteNonQuery()
            '========================

            '     

            t_event = "تعديل"
            t_doc = "اذن الاستلام"
            ts = TimeOfDay

            Dim sy As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
            Dim cmy As New SqlCommand(sy, cn)
            cmy.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
            cmy.Parameters.Add(New SqlParameter("@x2", t_doc))
            cmy.Parameters.Add(New SqlParameter("@x3", Trim(TextBox1.Text)))
            cmy.Parameters.Add(New SqlParameter("@x4", CInt(TextBox6.Text)))
            cmy.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
            cmy.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
            cmy.Parameters.Add(New SqlParameter("@x7", ts))
            cmy.Parameters.Add(New SqlParameter("@x8", ww))
            cmy.Parameters.Add(New SqlParameter("@x9", t_event))
            cmy.Transaction = Trans
            cmy.ExecuteNonQuery()

            '===============================
            Trans.Commit()
            MsgBox("تعديل اذن الاستلام", MsgBoxStyle.Information, " حفظ")
            total_inf()
        Catch err As System.Exception

            Trans.Rollback()
            MsgBox("لم يتم تعديل اذن الاستلام", MsgBoxStyle.Information, " حفظ")
            MsgBox(err.Message)

        Finally
        End Try
        '=========================
        stouck()
        stouck_matt()

    End Sub
    Sub stouck_matt()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        If Me.RadioButton1.Checked = True Then
            siopb = TextBox6.Text
            Dim s1 As String = "update  matt set no_c=@x1,balance=@x2,iopb=@x3,irct=@x5 where no_c=@x1"
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cm1.Parameters.Add(New SqlParameter("@x2", total_s))
            cm1.Parameters.Add(New SqlParameter("@x3", Me.siopb))
            cm1.Parameters.Add(New SqlParameter("@x5", sum_irct))

            Try
                cm1.ExecuteNonQuery()
                dsmt.Clear()
                admt.Fill(dsmt, " matt")
            Catch
            End Try

        Else
            Dim s1 As String = "update  matt set no_c=@x1,balance=@x2,irct=@x5 where no_c=@x1"
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cm1.Parameters.Add(New SqlParameter("@x2", total_s))
            cm1.Parameters.Add(New SqlParameter("@x5", sum_irct))

            Try
                cm1.ExecuteNonQuery()
                dsmt.Clear()
                admt.Fill(dsmt, " matt")
            Catch
            End Try

        End If
        cn.Close()
    End Sub
    Private Sub DataGridViewX2_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridViewX2.RowHeaderMouseClick




        If DataGridViewX2.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub
        '***************************



        If cn.State = ConnectionState.Closed Then cn.Open()
        '***************************
        Dim coun_test As Integer = 0
        For Me.i = 0 To DataGridViewX2.RowCount - 1



            TextBox1.Text = DataGridViewX2.CurrentRow.Cells(0).Value
            TextBox6.Text = DataGridViewX2.CurrentRow.Cells(1).Value
            TextBox9.Text = DataGridViewX2.CurrentRow.Cells(2).Value
            TextBox7.Text = DataGridViewX2.CurrentRow.Cells(2).Value

            TextBox10.Text = DataGridViewX2.CurrentRow.Cells(3).Value


            If DataGridViewX2.CurrentRow.Cells(4).Value = "تم اظافته كرصيد منقول" Then
                Me.RadioButton1.Checked = True
            Else
                Me.RadioButton2.Checked = True
            End If


            Me.RichTextBox1.Text = DataGridViewX2.CurrentRow.Cells(5).Value

            '---------------------الصلاحيه
            Me.DateTimePicker2.Text = DataGridViewX2.CurrentRow.Cells(6).Value
            TextBox13.Text = Trim(DataGridViewX2.CurrentRow.Cells(7).Value)
            ComboBox2.Text = Trim(DataGridViewX2.CurrentRow.Cells(8).Value)
            TextBox12.Text = DataGridViewX2.CurrentRow.Cells(9).Value


        Next




        ''لم تتم مراجعته
        'If RadioButton3.Checked = True Then
        '    If (sefa = "امين مخزن") Then
        '        Me.Panel3.Enabled = False
        '        Me.ButtonX1.Enabled = True
        '        Me.Button2.Enabled = False
        '        Me.Button3.Enabled = False
        '        Me.ButtonX2.Enabled = False
        '        Me.ButtonX4.Enabled = False
        '        Me.Button4.Enabled = True
        '        Me.Panel6.Enabled = False
        '        Panel1.Enabled = True

        '        If TextBoxX3.Text = "تم اظافته كرصيد منقول" Then
        '            Me.RadioButton1.Checked = True
        '            Me.ButtonX6.Enabled = True
        '            Me.ButtonX3.Enabled = False
        '        End If
        '        If TextBoxX3.Text = "تم اظافته" Then
        '            Me.RadioButton2.Checked = True
        '            Me.ButtonX3.Enabled = True
        '            Me.ButtonX6.Enabled = False
        '        End If
        '    End If

        'End If
        'Me.ButtonX1.Enabled = False

        cn.Close()
        'serch_no_c()
        'serch_no_slahia()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
       
        If TextBox1.Text = "" And TextBox6.Text = "" And TextBox9.Text = "" And TextBox9.Text = "" Then
            MsgBox("انقر على المخزن  ", MsgBoxStyle.Information, "إجراءحذف")

            Exit Sub
        End If


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        '=========================
        Dim s As String = "select * from tran_IRT where no_c=@x1 and date_i=@x3 and tr_type=@x4 and price=@x5"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cm.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cm.Parameters.Add(New SqlParameter("@x4", 3))
        cm.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
        Try
            Dim r1 As SqlDataReader = cm.ExecuteReader
            If r1.Read = True Then
                r1.Close()
                MessageBox.Show("لا تستطيع الحذف لان الصنف  تم الصرف منه", "v1مخازن", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                r1.Close()
            End If
        Catch

        End Try
        '===========================

        Dim st As String = "select * from tran_IRT where no_c=@x1 and date_i=@x3 and tr_type=@x4 and price=@x5"
        Dim cmt As New SqlCommand(st, cn)
        cmt.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cmt.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cmt.Parameters.Add(New SqlParameter("@x4", 4))
        cmt.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
        Try
            Dim r1 As SqlDataReader = cmt.ExecuteReader
            If r1.Read = True Then
                r1.Close()
                MessageBoxEx.Show("لا تستطيع الحذف لان الصنف  تم اتلاف كميات منه", "v1مخازن", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                r1.Close()
            End If
        Catch

        End Try
        Dim stm As String = "select * from tran_IRT where no_c=@x1 and date_i=@x3 and tr_type=@x4 and price=@x5"
        Dim cmtm As New SqlCommand(stm, cn)
        cmtm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cmtm.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cmtm.Parameters.Add(New SqlParameter("@x4", 5))
        cmtm.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
        Try
            Dim r1 As SqlDataReader = cmtm.ExecuteReader
            If r1.Read = True Then
                r1.Close()
                MessageBoxEx.Show("لا تستطيع الحذف لان الصنف  تم ارجاع كميات منه", "v1مخازن", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                r1.Close()
            End If
        Catch

        End Try
        Dim rds As Boolean
        ''======= شرط لو الاذن قعد فارغ نحذفه========'================

        Dim stR As String = "select * from RcvSub where no_i=@x1"
        Dim cmR As New SqlCommand(stR, cn)
        cmR.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))


        Try
            Dim r1 As SqlDataReader = cmR.ExecuteReader
            If r1.Read = True Then
                r1.Close()
                rds = True


            Else
                rds = False

                MessageBoxEx.Show("اذن الاستلام فارغ  ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                Exit Sub
                r1.Close()
            End If
        Catch

        End Try
        Dim Trans As SqlTransaction = cn.BeginTransaction

        Try
            If rds = True Then


                '====================الحذف======='===================='===========================




                Dim se As String = "delete from RcvSub where no_c=@x1 and no_i=@x2 and sal_s=@x3"
                Dim cme As New SqlCommand(se, cn)
                cme.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cme.Parameters.Add(New SqlParameter("@x2", Trim(TextBox8.Text)))
                cme.Parameters.Add(New SqlParameter("@x3", CDec(TextBox9.Text)))

                cme.Transaction = Trans
                cme.ExecuteNonQuery()

                '=======================================
                Dim sd As String = "delete from tran_IRT where no_c=@x1 and n_rs=@x2 and price=@x3 and date_i=@x4"
                Dim cmd As New SqlCommand(sd, cn)
                cmd.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cmd.Parameters.Add(New SqlParameter("@x2", Trim(TextBox8.Text)))
                cmd.Parameters.Add(New SqlParameter("@x3", CDec(TextBox9.Text)))
                cmd.Parameters.Add(New SqlParameter("@x4", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

                '=================slahia======================


                Dim sss As String = "delete from salahia where no_c=@x1 and date_i=@x2 and no_i=@x3 and sal_s=@x4"
                Dim cmds As New SqlCommand(sss, cn)
                cmds.Parameters.Add(New SqlParameter("@x1", Trim(Me.TextBox1.Text)))
                cmds.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
                cmds.Parameters.Add(New SqlParameter("@x3", Trim(Me.TextBox8.Text)))
                cmds.Parameters.AddWithValue("@x4", CDec(TextBox9.Text))
                cmds.Transaction = Trans
                cmds.ExecuteNonQuery()



                '=======================================
                Dim sw As String = "delete from acthion_tran where no_c=@x1 and info=@x2 and sal_s=@x3 and date_i=@x4"
                Dim cmw As New SqlCommand(sw, cn)
                cmw.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cmw.Parameters.Add(New SqlParameter("@x2", Trim(TextBox8.Text)))
                cmw.Parameters.Add(New SqlParameter("@x3", CDec(TextBox9.Text)))
                cmw.Parameters.Add(New SqlParameter("@x4", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
                cmw.Transaction = Trans
                cmw.ExecuteNonQuery()
                '=======================================


                t_event = "حذف صنف"
                t_doc = "اذن الاستلام"
                ts = TimeOfDay

                Dim sy As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim cmy As New SqlCommand(sy, cn)
                cmy.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
                cmy.Parameters.Add(New SqlParameter("@x2", t_doc))
                cmy.Parameters.Add(New SqlParameter("@x3", Trim(TextBox1.Text)))
                cmy.Parameters.Add(New SqlParameter("@x4", CInt(TextBox6.Text)))
                cmy.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
                cmy.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
                cmy.Parameters.Add(New SqlParameter("@x7", ts))
                cmy.Parameters.Add(New SqlParameter("@x8", ww))
                cmy.Parameters.Add(New SqlParameter("@x9", t_event))
                cmy.Transaction = Trans
                cmy.ExecuteNonQuery()
                '=========================
                  Else
                Dim srr As String = "delete from RcvMain where no_i=@x1 and date_i=@x2"
                Dim cmrr As New SqlCommand(srr, cn)
                cmrr.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
                cmrr.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
                cmrr.Transaction = Trans
                cmrr.ExecuteNonQuery()

        End If


        Trans.Commit()
            MsgBox("تم الحذف", MsgBoxStyle.Information, " اجراء حذف")
            total_inf()
         
        Catch err As System.Exception

            Trans.Rollback()
            MsgBox("لم يتم حذف  ", MsgBoxStyle.Information, " اجراء حذف")
            MsgBox(err.Message)

        Finally
        End Try

        ImportersDA = New SqlDataAdapter

        stouck()
        stouck_matt()
      



    End Sub
    Sub stouck()

        Dim i, w As Integer
        'Dim qt As Boolean

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sql As String = "select * from RcvSub where RcvSub.[no_c]='" + TextBox1.Text + "'"
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
            If DROW1("no_c") = (TextBox1.Text) Then

                y = Val(DROW1("qun_r"))
                sum_irct = sum_irct + y
            End If

        Next
        cn.Close()
        '===============اجمالي المصروف==================

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq3 As String = "select * from IsuSub where IsuSub.[no_c] ='" + TextBox1.Text + "'"

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
            If DROW3("no_c") = (TextBox1.Text) Then

                y2 = Val(DROW3("qun_s"))
                sum_iiss = sum_iiss + y2

            End If
        Next
        cn.Close()
        '===============اجمالي مرتجعه==================


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq4 As String = "select * from matt_return where matt_return.[no_c] ='" + TextBox1.Text + "'"

        Dim ad4 As New SqlDataAdapter(sq4, cn)
        Dim ds4 As New DataSet()
        Dim TD4 As DataTable
        Dim DROW4 As DataRow
        Dim y4 As Decimal
        'Me.sum_iiss = 0
        y4 = 0.0
        ad4.Fill(ds4, sq4)
        TD4 = ds4.Tables(sq4)

        For w = 0 To TD4.Rows.Count - 1
            DROW4 = TD4.Rows(w)

            If DROW4("no_c") = (TextBox1.Text) Then

                y4 = Val(DROW4("qun_t"))
                sum_return = sum_return + y4

            End If
        Next
        cn.Close()
        '===============تالف==================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq5 As String = "select * from sub_TALEF where sub_TALEF.[no_c] ='" + TextBox1.Text + "'"

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

            If DROW5("no_c") = (TextBox1.Text) Then

                y5 = Val(DROW5("qun_T"))
                sum_talf = sum_talf + y5

            End If
        Next
        cn.Close()
        Me.total_s = 0


        Me.total_s = ((sum_irct + sum_return) - sum_iiss) - sum_talf

        '=======================================================
        stouck_matt()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MsgBox("هل أنت متأكد من عملية حذفك لاذن الاستلام بالكامل ؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then





            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            ''===no_i=@x1======================
            'Dim sct As String = "select * from tran_IRT where  date_i=@x3 and tr_type=@x4"
            'Dim cmct As New SqlCommand(sct, cn)
            ''cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
            'cmct.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
            'cmct.Parameters.Add(New SqlParameter("@x4", 3))

            'Try
            '    Dim r4 As SqlDataReader = cmct.ExecuteReader
            '    If r4.Read = True Then
            '        r4.Close()
            '        MessageBox.Show("لا تستطيع الحذف لان الاذن تم الصرف منه", "v1مخازن", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '        r4.Close()
            '    Else
            '        r4.Close()
            '    End If
            'Catch

            'End Try

            '========= where no_i=@x1 and==================
            'If cn.State = ConnectionState.Closed Then
            '    cn.Open()
            'End If
            'Dim st As String = "select * from tran_IRT where date_i=@x3 and tr_type=@x4"
            'Dim cmt As New SqlCommand(st, cn)
            ''cmt.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
            'cmt.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
            'cmt.Parameters.Add(New SqlParameter("@x4", 4))

            'Try
            '    Dim r5 As SqlDataReader = cmt.ExecuteReader
            '    If r5.Read = True Then
            '        r5.Close()
            '        MessageBoxEx.Show("لا تستطيع الحذف لان الاذن  تم اتلاف كميات منه", "v1مخازن", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '        r5.Close()
            '    Else
            '        r5.Close()
            '    End If
            'Catch

            'End Try
            'If cn.State = ConnectionState.Closed Then
            '    cn.Open()
            'End If
            ''no_i=@x1 and
            'Dim stb As String = "select * from tran_IRT where date_i=@x3 and tr_type=@x4"
            'Dim cmtm As New SqlCommand(stb, cn)
            ''cmt.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
            'cmtm.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
            'cmtm.Parameters.Add(New SqlParameter("@x4", 5))

            'Try
            '    Dim r6 As SqlDataReader = cmtm.ExecuteReader
            '    If r6.Read = True Then
            '        r6.Close()
            '        MessageBoxEx.Show("لا تستطيع الحذف لان الاذن  تم ارجاع كميات منه", "v1مخازن", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '    Else
            '        r6.Close()
            '    End If
            'Catch

            'End Try
            Dim stb As String = "select * from V_TranRIosta where no_i=@x1"
            Dim cmtm As New SqlCommand(stb, cn)
            cmtm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
            'cmtm.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
            'cmtm.Parameters.Add(New SqlParameter("@x4", 5))


            Try
                Dim r6 As SqlDataReader = cmtm.ExecuteReader
                If r6.Read = True Then
                    r6.Close()
                    MessageBoxEx.Show("لا تستطيع الحذف لان الاذن تم الصرف منه", "v1مخازن", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    r6.Close()
                End If
            Catch

            End Try
            '====================الحذف======='===================='===========================

            '====================الحذف======='===================='===========================

            Dim Trans As SqlTransaction = cn.BeginTransaction

            Try


                Dim srr As String = "delete from RcvMain where no_i=@x1 and date_i=@x2"
                Dim cmrr As New SqlCommand(srr, cn)
                cmrr.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
                cmrr.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
                cmrr.Transaction = Trans
                cmrr.ExecuteNonQuery()

                '=======================================


                Dim sd As String = "delete from RcvSub where no_i=@x1"
                Dim cmd As New SqlCommand(sd, cn)
                cmd.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))

                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

                '=================slahia======================


                Dim ss As String = "delete from salahia where no_i=@x1 and date_i=@x2 "
                Dim cms As New SqlCommand(ss, cn)
                cms.Parameters.Add(New SqlParameter("@x1", Trim(Me.TextBox8.Text)))
                cms.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
                cms.Transaction = Trans
                cms.ExecuteNonQuery()
                '===============================
                Dim stg As String = "delete from tran_IRT where n_rs=@x1 and date_i=@x2 "
                Dim cmtg As New SqlCommand(stg, cn)

                cmtg.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
                cmtg.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
                cmtg.Transaction = Trans
                cmtg.ExecuteNonQuery()

                '=======================================
                Dim sa As String = "delete from acthion_tran where info=@x1 and date_i=@x2 "
                Dim cma As New SqlCommand(sa, cn)

                cma.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
                cma.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
                cma.Transaction = Trans
                cma.ExecuteNonQuery()

                '=======================================
                t_event = "حذف "

                t_doc = "اذن الاستلام"
                ts = TimeOfDay


                Dim sc As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim cmwc As New SqlCommand(sc, cn)
                cmwc.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
                cmwc.Parameters.Add(New SqlParameter("@x2", t_doc))
                cmwc.Parameters.Add(New SqlParameter("@x3", Trim(TextBox1.Text)))
                cmwc.Parameters.Add(New SqlParameter("@x4", CInt(TextBox6.Text)))
                cmwc.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
                cmwc.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
                cmwc.Parameters.Add(New SqlParameter("@x7", ts))
                cmwc.Parameters.Add(New SqlParameter("@x8", ww))
                cmwc.Parameters.Add(New SqlParameter("@x9", t_event))
                cmwc.Transaction = Trans
                cmwc.ExecuteNonQuery()

                '===============================
                Trans.Commit()
                MsgBox("حذف  اذن الاستلام", MsgBoxStyle.Information, " مراقبة المخزون")
            Catch err As System.Exception

                Trans.Rollback()
                MsgBox("لم يتم حذف  اذن الاستلام", MsgBoxStyle.Information, " مراقبة المخزون")
                MsgBox(err.Message)

            Finally
            End Try

            ImportersDA = New SqlDataAdapter
        Else
            Exit Sub
        End If
        'stouck()
        ImportersDA = New SqlDataAdapter
        'Me.Button2.Enabled = False

        DataGridViewX2.DataMember = ""
        DataGridViewX2.DataSource = Nothing
        'Me.Button2.Enabled = False
        'Me.Button5.Visible = True
        'DataGridViewX2.DataMember = ""
        'DataGridViewX2.DataSource = Nothing
    End Sub
    Sub serch_no_name()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "select * from matt_t where name_snc=@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", (TextBox11.Text)))
        Try
            Dim r As SqlDataReader = cm.ExecuteReader
            If r.Read = True Then
                TextBox1.Text = r!no_c
                'Me.TextBoxX2.Text = r!iopb
                Me.Label14.Text = r!name_type
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
   
    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged
        'serch_no_name()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim k As New Form1
        k.TextBox1.Text = Trim(TextBox1.Text)

        k.ShowDialog()
        TextBox1.Text = k.TextBox1.Text
        serch_no_c()
    End Sub


    Private Sub RadioButton8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton8.CheckedChanged
        If RadioButton8.Checked = True Then

            Me.TextBox14.Text = "تم مراجعته ويوجد اخطاء"

        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim ss As String = "update RcvMain set no_i=@x1,dep_m=@x2,dep_mt=@x3,dep_nom=@x4 where no_i=@x1"
        Dim cms As New SqlCommand(ss, cn)
        cms.Parameters.Add((New SqlParameter("@x1", TextBox8.Text)))

        If Me.RadioButton7.Checked = True Or RadioButton8.Checked = True Then
            cms.Parameters.Add(New SqlParameter("@x2", True))
        Else
            cms.Parameters.Add(New SqlParameter("@x2", False))
        End If

        cms.Parameters.Add(New SqlParameter("@x3", Me.TextBox14.Text))
        cms.Parameters.Add(New SqlParameter("@x4", Me.RadioButton6.Checked))
        Try
            cms.ExecuteNonQuery()
            dsRcvM.Clear()
            adRcvM.Fill(dsRcvM, "RcvMain")
            '"تم مراجعته ويوجد اخطاء" 
            If RadioButton6.Checked = True Then
                MsgBox(" لم تتم مراجعته ", MsgBoxStyle.Critical, "تنبية")

            End If
            If RadioButton7.Checked = True Then
                MsgBox(" تم مراجعته ولايوجد اخطاء ", MsgBoxStyle.Critical, "تنبية")
            End If
            If RadioButton8.Checked = True Then
                MsgBox("  تم مراجعته ويوجد اخطاء ", MsgBoxStyle.Critical, "تنبية")
                Me.TextBox14.Clear()
            End If
            cn.Close()
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try


        'Me.RadioButton4.Checked = False
        'Me.RadioButton5.Checked = False
        'Me.RadioButton3.Checked = False
        ''Me.TextBoxX11.Clear()
        cn.Close()
    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        If RadioButton7.Checked = True Then
            Me.TextBox14.Text = "تم مراجعته ولايوجد اخطاء"
        End If
    End Sub

   
    Private Sub Label1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.TextChanged
        Dim A As New NumberToWords
        Me.Label2.Text = (A.getWords(Label1.Text))
        Dim x As String
        x = man14(Label1.Text)
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        If Me.TextBox1.Text <> "" Then
            serch_no_c()
        End If


    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If Me.TextBox1.Text <> "" Then
            serch_no_c()
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
   

        If TextBox8.Text <> "" Then


            Dim adp As New SqlDataAdapter("SELECT no_i, no_c,name_snc,name_type,date_i,name_r,cast([qun_r] as nvarchar(50)) as qun_r, sal_s, gema, no_ct, n_txt,g_b,tvg, u_name, no_ct1, mt, n1_txt,name_stock FROM [estelam]  WHERE no_i ='" + TextBox8.Text + "'", cn)
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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        'تعديل'===================='===========================

        Dim Trans As SqlTransaction = cn.BeginTransaction

        Try


            Dim srr As String = "delete from RcvMain where no_i=@x1 and date_i=@x2"
            Dim cmrr As New SqlCommand(srr, cn)
            cmrr.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
            cmrr.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
            cmrr.Transaction = Trans
            cmrr.ExecuteNonQuery()

            '=======================================


            Dim sd As String = "delete from RcvSub where no_i=@x1"
            Dim cmd As New SqlCommand(sd, cn)
            cmd.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))

            cmd.Transaction = Trans
            cmd.ExecuteNonQuery()

            '=================slahia======================


            Dim ss As String = "delete from salahia where no_i=@x1 and date_i=@x2 "
            Dim cms As New SqlCommand(ss, cn)
            cms.Parameters.Add(New SqlParameter("@x1", Trim(Me.TextBox8.Text)))
            cms.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
            cms.Transaction = Trans
            cms.ExecuteNonQuery()
            '===============================
            Dim stg As String = "delete from tran_IRT where n_rs=@x1 and date_i=@x2 "
            Dim cmtg As New SqlCommand(stg, cn)

            cmtg.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
            cmtg.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
            cmtg.Transaction = Trans
            cmtg.ExecuteNonQuery()

            '=======================================
            Dim sa As String = "delete from acthion_tran where info=@x1 and date_i=@x2 "
            Dim cma As New SqlCommand(sa, cn)

            cma.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
            cma.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
            cma.Transaction = Trans
            cma.ExecuteNonQuery()

            '=======================================
            t_event = "تعديل "

            t_doc = "اذن الاستلام"
            ts = TimeOfDay


            Dim sc As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
            Dim cmwc As New SqlCommand(sc, cn)
            cmwc.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
            cmwc.Parameters.Add(New SqlParameter("@x2", t_doc))
            cmwc.Parameters.Add(New SqlParameter("@x3", Trim(TextBox1.Text)))
            cmwc.Parameters.Add(New SqlParameter("@x4", CInt(TextBox6.Text)))
            cmwc.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
            cmwc.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
            cmwc.Parameters.Add(New SqlParameter("@x7", ts))
            cmwc.Parameters.Add(New SqlParameter("@x8", ww))
            cmwc.Parameters.Add(New SqlParameter("@x9", t_event))
            cmwc.Transaction = Trans
            cmwc.ExecuteNonQuery()

            '===============================
            Trans.Commit()
            'MsgBox("حذف  اذن الاستلام", MsgBoxStyle.Information, " مراقبة المخزون")
        Catch err As System.Exception

            Trans.Rollback()
            'MsgBox("لم يتم حذف  اذن الاستلام", MsgBoxStyle.Information, " مراقبة المخزون")
            MsgBox(err.Message)

        Finally
        End Try

        'ImportersDA = New SqlDataAdapter

        Button2_Click(sender, e)
    End Sub

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged

    End Sub

    Private Sub DataGridViewX2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX2.CellContentClick

    End Sub
End Class