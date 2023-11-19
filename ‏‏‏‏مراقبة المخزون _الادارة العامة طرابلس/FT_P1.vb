Imports System.Data.SqlClient


Public Class FT_P1
    Dim f As Boolean
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click



        'If DataGridViewX2.RowCount = 0 Then
        '    Exit Sub
        'End If


        Try


            If Im_talef = "فورم الرئيسي" Then
                Dim s2 As String = "insert into TALEF(NO_T,date_T,SBdate,SBakry) values (@x1,@x2,@x3,@x4)"
                Dim cm2 As New SqlCommand(s2, cn)
                cm2.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cm2.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
                cm2.Parameters.Add(New SqlParameter("@x3", False))
                cm2.Parameters.Add(New SqlParameter("@x4", True))
                cm2.ExecuteNonQuery()
                '============================================================
                Dim qun_tot As Int64
                Dim no_c As String
                Dim info As String
                Dim date_i As Date
                Dim sal_s As Double
                Dim name_sncc As String
                name_sncc = ""
                no_c = ""
                'For i As Integer = 0 To DataGridViewX2.RowCount - 1

                no_c = Me.TextBox6.Text
                sal_s = Me.TextBox3.Text
                info = Me.TextBox1.Text
                date_i = Me.TextBox9.Text
                name_sncc = Me.TextBox5.Text
                qun_tot = Me.TextBox7.Text

                qun_tot = qun_tot - Val(TextBox4.Text)
                'Dim s1 As String = "select * from matt where no_c=@x1"
                'Dim cm1 As New SqlCommand(s1, cn)

                'cm1.Parameters.Add(New SqlParameter("@x1", no_c))


                'Dim r1 As SqlDataReader = cm1.ExecuteReader

                'If r1.Read = True Then

                '    name_sncc = r1!name_snc

                '    r1.Close()
                'Else

                '    r1.Close()
                'End If


                'Dim s As String = "select * from acthion_tran where no_c=@x1 and info=@x2 and date_i=@x3 and sal_s=@x4"
                'Dim cm As New SqlCommand(s, cn)
                'cm.Parameters.Add(New SqlParameter("@x1", no_c))
                'cm.Parameters.Add(New SqlParameter("@x2", info))
                'cm.Parameters.Add(New SqlParameter("@x3", date_i))
                'cm.Parameters.Add(New SqlParameter("@x4", sal_s))

                'Dim r As SqlDataReader = cm.ExecuteReader
                'If r.Read = True Then

                '    qun_tot = r!qun_tot

                '    r.Close()

                'Else
                '    r.Close()
                'End If



                'Try

                'Dim s2 As String = "insert into TALEF(NO_T,date_T,SBdate,SBakry) values (@x1,@x2,@x3,@x4)"
                'Dim cm2 As New SqlCommand(s2, cn)
                'cm2.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                'cm2.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
                'cm2.Parameters.Add(New SqlParameter("@x3", True))
                'cm2.Parameters.Add(New SqlParameter("@x4", False))
                ''cm2.Transaction = Trans

                'cm2.ExecuteNonQuery()

                '=======================================
                'For i As Integer = 0 To DataGridViewX2.RowCount - 1

                Dim sq As String = "insert into sub_TALEF(no_t,no_c,name_snc,qun_T,praice,balance) values (@x1,@x2,@x3,@x4,@x5,@x6)"
                Dim cmq As New SqlCommand(sq, cn)

                cmq.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cmq.Parameters.Add(New SqlParameter("@x2", no_c))
                cmq.Parameters.Add(New SqlParameter("@x3", name_sncc))
                cmq.Parameters.Add(New SqlParameter("@x4", Me.TextBox7.Text))
                cmq.Parameters.Add(New SqlParameter("@x5", sal_s))
                cmq.Parameters.Add(New SqlParameter("@x6", 0))

                'cmq.Transaction = Trans
                cmq.ExecuteNonQuery()


                '==========smove_no_i===============
                Dim smov As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i,count1) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7)"
                Dim cmsmov As New SqlCommand(smov, cn)
                cmsmov.Parameters.AddWithValue("@x1", no_c)
                cmsmov.Parameters.AddWithValue("@x2", Me.TextBox7.Text)
                cmsmov.Parameters.AddWithValue("@x3", sal_s)
                cmsmov.Parameters.AddWithValue("@x4", 4)
                cmsmov.Parameters.AddWithValue("@x5", Trim(TextBox1.Text))
                cmsmov.Parameters.AddWithValue("@x6", date_i)
                cmsmov.Parameters.AddWithValue("@x7", 0).DbType = DbType.Int32
                'cmsmov.Transaction = Trans
                cmsmov.ExecuteNonQuery()

                '=====acthion_tran================



                Dim stran As String = "update acthion_tran set qun_tot=@x4,date_i=@x2,info=@x1 where info=@x1 and no_c=@x3 and date_i=@x2  and sal_s=@x5 "
                Dim cmtran As New SqlCommand(stran, cn)
                cmtran.Parameters.AddWithValue("@x1", info)
                cmtran.Parameters.AddWithValue("@x2", date_i)
                cmtran.Parameters.AddWithValue("@x3", no_c)
                cmtran.Parameters.AddWithValue("@x4", 0)
                cmtran.Parameters.AddWithValue("@x5", sal_s)
                'cmtran.Transaction = Trans
                cmtran.ExecuteNonQuery()

                '======up====salahia==========

                Dim sql As String = "update salahia set  state_sal=@x5 where no_c=@x1 and sal_s=@x2 and no_i=@x3 and date_i=@x4"
                Dim cms As New SqlCommand(sql, cn)
                cms.Parameters.AddWithValue("@x1", no_c)
                cms.Parameters.AddWithValue("@x2", sal_s)
                cms.Parameters.AddWithValue("@x3", info)
                cms.Parameters.AddWithValue("@x4", date_i)
                cms.Parameters.AddWithValue("@x5", 0)
                'cms.Transaction = Trans
                cms.ExecuteNonQuery()
                '=========================

                't_event = "حفظ صنف"
                't_doc = "اذن الاستلام"
                'ts = TimeOfDay

                t_event = "حفظ "
                t_doc = "اذن تالف"
                ts = TimeOfDay


                Dim sevent As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim cmevent As New SqlCommand(sevent, cn)
                cmevent.Parameters.AddWithValue("@x1", Trim(TextBox1.Text)).DbType = DbType.String
                cmevent.Parameters.AddWithValue("@x2", t_doc).DbType = DbType.String
                cmevent.Parameters.AddWithValue("@x3", no_c)
                cmevent.Parameters.AddWithValue("@x4", Me.TextBox7.Text)
                cmevent.Parameters.AddWithValue("@x5", sal_s)
                cmevent.Parameters.AddWithValue("@x6", Format(Now.Date, "yyyy/MM/dd")).DbType = DbType.Date
                cmevent.Parameters.AddWithValue("@x7", ts)
                cmevent.Parameters.AddWithValue("@x8", ww).DbType = DbType.String
                cmevent.Parameters.AddWithValue("@x9", t_event).DbType = DbType.String

                'cmevent.Transaction = Trans
                cmevent.ExecuteNonQuery()






                '=======================تعديل المخزون========================

                'If DataGridViewX2.Rows(i).Cells(4).Value = "تم اظافته كرصيد منقول".ToString Then
                '    siopb = DataGridViewX2.Rows(i).Cells(1).Value

                '    Dim ss1 As String = "update  matt set no_c=@x1,balance=@x2,iopb=@x3,irct=@x5 where no_c=@x1"
                '    Dim cmst As New SqlCommand(ss1, cn)
                '    cmst.Parameters.AddWithValue("@x1", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                '    cmst.Parameters.AddWithValue("@x2", total_s).DbType = DbType.Decimal
                '    cmst.Parameters.AddWithValue("@x3", Me.siopb).DbType = DbType.Decimal
                '    cmst.Parameters.AddWithValue("@x5", sum_irct).DbType = DbType.Decimal

                '    cmst.Transaction = Trans
                '    cmst.ExecuteNonQuery()


                'Else

                '    Dim sss1 As String = "update  matt set no_c=@x1,balance=@x2,irct=@x5 where no_c=@x1"
                '    Dim cmst1 As New SqlCommand(sss1, cn)
                '    cmst1.Parameters.AddWithValue("@x1", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                '    cmst1.Parameters.Add(New SqlParameter("@x2", total_s)).DbType = DbType.Decimal
                '    cmst1.Parameters.Add(New SqlParameter("@x5", sum_irct)).DbType = DbType.Decimal

                '    cmst1.Transaction = Trans
                '    cmst1.ExecuteNonQuery()

                'End If





                '===============================


                name_sncc = ""
                no_c = ""
                'Next
                MsgBox("حفظ اذن التالف", MsgBoxStyle.Information, " حفظ")


                TextBox2.Text = Trim(TextBox1.Text)
                viwe()


            Else
                Exit Sub
            End If


        Catch ex As Exception

        End Try

    End Sub
    Sub viwe()
        If Me.TextBox2.Text <> "" Then

            Dim ds1 As New DataSet()
            Dim s1 As String = "SELECT no_c as [رقم الصنف],name_snc as [اسم الصنف],qun_T as [الكمية التالفة],praice as [سعر الوحدة], balance as [رصيد المخزن] from sub_TALEF WHERE  sub_TALEF.no_t='" + TextBox2.Text + "'"
            Dim ad1 As New SqlDataAdapter(s1, cn)
            ad1.Fill(ds1, "sub_TALEF")
            'ds.Clear()
            Me.DataGridViewX1.DataSource = ds1
            Me.DataGridViewX1.DataMember = "sub_TALEF"
            Me.DataGridViewX1.Refresh()
        Else
            Exit Sub
        End If



    End Sub
    'Sub viwe2()
    '    If Me.TextBox2.Text <> "" Then

    '        Dim date_1 As Date
    '        date_1 = Me.DateTimePicker3.Value.Date
    '        Dim ds1 As New DataSet()
    '        Dim s1 As String = "SELECT no_c as [رقم الصنف],name_snc as [اسم الصنف],qun_T as [الكمية التالفة],praice as [سعر الوحدة], balance as [رصيد المخزن] from sub_TALEF WHERE  sub_TALEF.no_t='" + TextBox2.Text + "'and date_T <> '" & date_1.ToString("yyyy/MM/dd") & "'"
    '        Dim ad1 As New SqlDataAdapter(s1, cn)
    '        ad1.Fill(ds1, "sub_TALEF")
    '        'ds.Clear()
    '        Me.DataGridViewX1.DataSource = ds1
    '        Me.DataGridViewX1.DataMember = "sub_TALEF"
    '        Me.DataGridViewX1.Refresh()
    '    Else
    '        Exit Sub
    '    End If
    'End Sub

    Sub auto_no()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "select * from TALEF where TALEF.NO_T=(select max(NO_T) from TALEF)"
        'Dim s As String = "select LAST(no_i) from RcvMain"
        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "TALEF")
        tb = ds.Tables(0)
        Dim dr As DataRow
        Try
            dr = tb.Rows(0)
            Me.TextBox1.Text = dr(0) + 1
        Catch ex As Exception
            Me.TextBox1.Text = "1"
        End Try
        ad.Dispose()
        ds.Dispose()
    End Sub

    Private Sub FT_P1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dtYear.Value = dateNowDB



        'If Im_talef = "فورم الرئيسي" Then
        TextBox2.Visible = True
        TextBox1.Visible = False
        Me.DateTimePicker3.Visible = False
        Me.RadioButton1.Visible = False
        Label2.Visible = False
        TextBox1.Text = getNewNo(Me.dtYear.Value.Year, ssf_t, "GetNewNoTALEF")
        Me.DateTimePicker3.Value = dateNowDB

        'Me.Button1_Click(sender, e)

        TextBox2.Visible = False
        TextBox1.Visible = True
        Me.DateTimePicker3.Visible = True
        Me.RadioButton1.Visible = True
        Label2.Visible = True
        'End If



    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        '777777777777777777777777

        If TextBox2.Text <> "" Then
            Dim adp As New SqlDataAdapter("select NO_T,date_T, SBdate,SBakry,no_c,name_snc,name_type, cast([qun_T] as nvarchar(50))as qun_T,praice,cast([balance ] as nvarchar(50))as balance , qun_Tt  from tt_talf where [no_t]='" + TextBox2.Text + "'", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_T")) = "int" Then
                    dt.Rows(i).Item("qun_T") = myNo
                Else
                    dt.Rows(i).Item("qun_T") = FormatNumber(CDec(dt.Rows(i).Item(7)), 3)
                End If

                If checkNum(dt.Rows(i).Item("balance")) = "int" Then
                    dt.Rows(i).Item("balance") = myNo
                Else
                    dt.Rows(i).Item("balance") = FormatNumber(CDec(dt.Rows(i).Item(9)), 3)
                End If

            Next

            Dim frm As New Form12
            Dim rpt1 As New CrystalReport5
            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1
            Dim Text16 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text16")
            Dim Text19 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section5.ReportObjects("Text19")
            Text16.Text = branch
            If branch = "الادارة العامة" Then

                Text19.Text = "اعتماد مدير الادارة"
            Else
                Text19.Text = "اعتماد مدير الفرع"

            End If


            frm.ShowDialog()

        Else : Exit Sub
        End If




    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub




    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            'xl = l_p(Trim(TextBox2.Text))
            'TextBox2.Text = Trim(xl)
            DataGridViewX1.DataMember = ""
            DataGridViewX1.DataSource = Nothing
            viwe()
        End If
    End Sub
    Private Sub TextBox6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.Leave


        'Me.TextBoxX4.Clear()
        'Me.TextBoxX5.Clear()
        'Me.TextBoxX7.Clear()
        'Me.TextBox5.Clear()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "select * from matt where no_c=@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox6.Text)))
        Try

            Dim r As SqlDataReader = cm.ExecuteReader

            If r.Read = True Then

                TextBox5.Text = r!name_snc
                'Me.TextBox4.Text = r!c_type
                'TextBoxX5.Text = r!balance

                r.Close()
            Else
                r.Close()

                'ComboBoxEx4.Enabled = True
                'Me.DateTimePicker3.Enabled = True
                'MsgBox("هذا الصنف لم يتم تعريفة بعد", MsgBoxStyle.OkOnly, "تنبية")
                'clearing()
                r.Close()
            End If

        Catch
            MsgBox("يوجد خطاءفي بيانات المواد", MsgBoxStyle.Critical, "تنبية")
        End Try


        'Dim ds1 As DataSet
        'ds1 = New DataSet
        'ds1.Clear()

        'Dim s1 As String = "select * from acthion_tran where no_c ='" + Me.TextBoxX2.Text + "' and qun_tot<>0"
        'Dim ad1 As New SqlDataAdapter(s1, cn)
        'ad1.Fill(ds1, "acthion_tran")
        'Me.DataGridViewX1.DataSource = ds1
        'Me.DataGridViewX1.DataMember = "acthion_tran"
        'DataGridViewX1.Refresh()
        'cn.Close()


        Dim dt2 As DataTable
        Dim sql1, n1 As String
        n1 = TextBox1.Text
        If n1 = "" Then
            Exit Sub
        Else
            sql1 = "select * from acthion_tran where no_c ='" + Me.TextBox6.Text + "' and qun_tot<>0"
            'sql1 = "SELECT * from sub_TALEF WHERE  sub_TALEF.no_t='" + TextBox1.Text + "'"
            Dim da8 As New SqlDataAdapter(sql1, cn)
            Dim ds8 As New DataSet
            ds8.Clear()
            da8.Fill(ds8, "acthion_tran")
            dt2 = ds8.Tables("acthion_tran")
            If dt2.Rows.Count > 0 Then

            End If
            ListView2.Clear()
            Dim dr2 As DataRow
            ListView2.Columns.Add("رقم المحضر", 0, HorizontalAlignment.Center)
            ListView2.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
            ListView2.Columns.Add("تاريخ الاستلام", 150, HorizontalAlignment.Left)
            ListView2.Columns.Add("الكميه", 75, HorizontalAlignment.Center)
            ListView2.Columns.Add("سعر الوحدة", 75, HorizontalAlignment.Center)
            ListView2.Columns.Add("id", 0, HorizontalAlignment.Center)

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
                litem.Text = dt2.Rows(i).Item("info")
                litem.SubItems.Add(dt2.Rows(i).Item("no_c"))
                litem.SubItems.Add(dt2.Rows(i).Item("date_i"))
                litem.SubItems.Add(dt2.Rows(i).Item("qun_tot"))
                litem.SubItems.Add(dt2.Rows(i).Item("sal_s"))
                litem.SubItems.Add(dt2.Rows(i).Item("ID"))




                ListView2.Items.Add(litem)
            Next i

            ListView2.View = View.Details
        End If

    End Sub


    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Dim litem As ListViewItem
        Me.TextBox6.Text = ""
        For Each litem In ListView2.SelectedItems

            Me.TextBox8.Text = litem.SubItems(0).Text
            TextBox6.Text = litem.SubItems(1).Text
            TextBox9.Text = litem.SubItems(2).Text

            Me.TextBox7.Text = litem.SubItems(3).Text

            TextBox3.Text = litem.SubItems(4).Text

        Next

    End Sub

  
End Class