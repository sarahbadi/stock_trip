Imports System.Data.SqlClient


Public Class FT_P
    Dim f As Boolean
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridViewX2.RowCount = 0 Then
            Exit Sub
        End If
        Try


            If Im_talef = "فورم الصلاحيه" Then
                Dim s2 As String = "insert into TALEF(NO_T,date_T,SBdate,SBakry) values (@x1,@x2,@x3,@x4)"
                Dim cm2 As New SqlCommand(s2, cn)
                cm2.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cm2.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
                cm2.Parameters.Add(New SqlParameter("@x3", True))
                cm2.Parameters.Add(New SqlParameter("@x4", False))
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
                For i As Integer = 0 To DataGridViewX2.RowCount - 1

                    no_c = DataGridViewX2.Rows(i).Cells(0).Value
                    sal_s = DataGridViewX2.Rows(i).Cells(1).Value
                    info = DataGridViewX2.Rows(i).Cells(6).Value
                    date_i = DataGridViewX2.Rows(i).Cells(7).Value


                    Dim s1 As String = "select * from matt where no_c=@x1"
                    Dim cm1 As New SqlCommand(s1, cn)

                    cm1.Parameters.Add(New SqlParameter("@x1", no_c))


                    Dim r1 As SqlDataReader = cm1.ExecuteReader

                    If r1.Read = True Then

                        name_sncc = r1!name_snc

                        r1.Close()
                    Else

                        r1.Close()
                    End If


                    Dim s As String = "select * from acthion_tran where no_c=@x1 and info=@x2 and date_i=@x3 and sal_s=@x4"
                    Dim cm As New SqlCommand(s, cn)
                    cm.Parameters.Add(New SqlParameter("@x1", no_c))
                    cm.Parameters.Add(New SqlParameter("@x2", info))
                    cm.Parameters.Add(New SqlParameter("@x3", date_i))
                    cm.Parameters.Add(New SqlParameter("@x4", sal_s))

                    Dim r As SqlDataReader = cm.ExecuteReader
                    If r.Read = True Then

                        qun_tot = r!qun_tot

                        r.Close()

                    Else
                        r.Close()
                    End If



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
                    cmq.Parameters.Add(New SqlParameter("@x4", qun_tot))
                    cmq.Parameters.Add(New SqlParameter("@x5", sal_s))
                    cmq.Parameters.Add(New SqlParameter("@x6", 0))

                    'cmq.Transaction = Trans
                    cmq.ExecuteNonQuery()


                    '==========smove_no_i===============
                    Dim smov As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i,count1) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7)"
                    Dim cmsmov As New SqlCommand(smov, cn)
                    cmsmov.Parameters.AddWithValue("@x1", no_c)
                    cmsmov.Parameters.AddWithValue("@x2", qun_tot)
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
                    cms.Parameters.AddWithValue("@x5", 1)
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
                    cmevent.Parameters.AddWithValue("@x4", qun_tot)
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
                Next
                'MsgBox("حفظ اذن التالف", MsgBoxStyle.Information, " حفظ")


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

    Private Sub FT_P_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dtYear.Value = dateNowDB



        If Im_talef = "فورم الرئيسي" Then
            TextBox2.Visible = True
            TextBox1.Visible = False
            Me.DateTimePicker3.Visible = False
            Me.RadioButton1.Visible = False
            Label2.Visible = False

        Else

            Me.DateTimePicker3.Value = dateNowDB

            TextBox1.Text = getNewNo(Me.dtYear.Value.Year, "GetNewNoTALEF")

            Me.Button1_Click(sender, e)

            TextBox2.Visible = False
            TextBox1.Visible = True
            Me.DateTimePicker3.Visible = True
            Me.RadioButton1.Visible = True
            Label2.Visible = True
        End If



    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        '777777777777777777777777

        If TextBox2.Text <> "" Then
            Dim adp As New SqlDataAdapter("select NO_T,date_T, SBdate,SBakry,no_c,name_snc,name_type, cast([qun_T] as nvarchar(50))as qun_T,praice,cast([balance ] as nvarchar(50))as balance , qun_Tt  from tt_talf where [no_t]='" + TextBox3.Text + "'", cn)
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
            'viwe()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click



        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        If Me.TextBox2.Text <> "" Then

            'NO_T(date_T)
            'Me.RadioButton2.Checked = r13!SBakry


            Dim s11 As String = "SELECT top 1 [NO_T] , cast(SUBSTRING([NO_T],1,4) as bigint), cast(SUBSTRING([NO_T],5,len([NO_T])) as bigint) FROM TALEF where (ISNUMERIC(SUBSTRING([NO_T],5,len([NO_T])))=1 and cast(SUBSTRING([NO_T],1,4) as bigint)=" & Me.dtYear.Value.Year & " and cast(SUBSTRING([NO_T],5,len([NO_T])) as bigint)=" & Me.TextBox2.Text.Trim() & ") "
        Dim cm As New SqlCommand(s11, cn)
        Try
            Dim r As SqlDataReader = cm.ExecuteReader

            If r.Read = True Then

                    'tot = True
                    TextBox3.Text = r!NO_T
                    'Me.RadioButton1.Checked = r!SBakry
                r.Close()
                cn.Close()

            Else

                    'tot = False

                    'Me.Label1.Text = "0.000"
                    'Me.Label2.Text = "صفر دينار فقـط"

                r.Close()
                cn.Close()
            End If
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try

            Dim ds1 As New DataSet()
            Dim s1 As String = "SELECT no_c as [رقم الصنف],name_snc as [اسم الصنف],qun_T as [الكمية التالفة],praice as [سعر الوحدة], balance as [رصيد المخزن] from sub_TALEF WHERE  sub_TALEF.no_t='" + TextBox3.Text + "'"
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

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class