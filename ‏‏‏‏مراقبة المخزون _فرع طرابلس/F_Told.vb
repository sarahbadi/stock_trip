Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports Microsoft.VisualBasic



Public Class F_Told
    Dim date_1, date_2 As Date
    Dim qun, qt As Integer
    Dim i As New Integer()
    Dim totinf As Decimal
    Dim fal As Boolean
    Dim move_no As String
    Dim tot, ft As Boolean
    Dim sum_irct, sum_iiss, sum_return, total_s, sum_talf As New Integer()

    Dim s1 As String = "select * from TALEF"
    Dim ad1 As New SqlDataAdapter(s1, cn)
    Dim ds1 As New DataSet()

    Dim s11 As String = "select * from sub_TALEF"
    Dim ad11 As New SqlDataAdapter(s11, cn)
    Dim ds11 As New DataSet()

    Dim sm As String = "select * from matt"
    Dim adm As New SqlDataAdapter(sm, cn)
    Dim dsm As New DataSet()
    Dim TDm As DataTable
    'Dim i As Integer
    '================================
    Dim scl As String = "select * from cls"
    Dim adcl As New SqlDataAdapter(scl, cn)
    Dim dscl As New DataSet()
    '====================================


    Dim stran As String = "select * from tran_IRT"
    Dim adtran As New SqlDataAdapter(stran, cn)
    Dim dstran As New DataSet()
    '========================
    '===========================
    Dim s22 As String = "select * from acthion_tran"
    Dim adact As New SqlDataAdapter(s22, cn)
    Dim dsact As New DataSet()
    Dim f As Boolean
    Dim no_fd As String


    Dim sT As String = "select * from Table_OSTA"
    Dim adIsuT As New SqlDataAdapter(sT, cn)
    Dim dsIsuST As New DataSet()

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

    'Private Sub F_T_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    If Im_talef = "فورم الصلاحيه" Then
    '        Me.Button3.Visible = True
    '        Me.Button2.Visible = False
    '        Me.RadioButton1.Checked = True
    '        Me.RadioButton2.Checked = False


    '        TextBox5.Enabled = False
    '        TextBox6.Enabled = False
    '        TextBox8.Enabled = False

    '        auto_no()
    '        xl = l_p(TextBox1.Text)
    '        TextBox1.Text = xl
    '        Me.DateTimePicker3.Value = Format(Now.Date, "yyyy/MM/dd")


    '    Else
    '        Me.Button3.Visible = False
    '        Me.Button2.Visible = True
    '        Me.RadioButton1.Checked = False
    '        Me.RadioButton2.Checked = True
    '        auto_no()
    '        xl = l_p(TextBox1.Text)
    '        TextBox1.Text = xl
    '        Me.DateTimePicker3.Value = Format(Now.Date, "yyyy/MM/dd")

    '        TextBox5.Enabled = False
    '        TextBox6.Enabled = True
    '        TextBox8.Enabled = False
    '    End If

    'End Sub
    'Private Sub F_T_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load




    '    adcl.Fill(dscl, "cls")
    '    ComboBoxEx1.DataSource = dscl
    '    ComboBoxEx1.DisplayMember = "cls.name_type"
    '    ComboBoxEx1.ValueMember = "no_type"
    '    If Im_talef = "فورم الصلاحيه" Then
    '        Me.Button3.Visible = True
    '        Me.Button2.Visible = False
    '        Me.RadioButton1.Checked = True
    '        Me.RadioButton2.Checked = False


    '        TextBox5.Enabled = False
    '        TextBox6.Enabled = False
    '        TextBox8.Enabled = False

    '        auto_no()
    '        xl = l_p(TextBox1.Text)
    '        TextBox1.Text = xl
    '        Me.DateTimePicker3.Value = Format(Now.Date, "yyyy/MM/dd")
    '        Me.Button4_Click(sender, e)

    '    Else
    '        Me.Button3.Visible = False
    '        Me.Button2.Visible = True
    '        Me.RadioButton1.Checked = False
    '        Me.RadioButton2.Checked = True
    '        auto_no()
    '        xl = l_p(TextBox1.Text)
    '        TextBox1.Text = xl
    '        Me.DateTimePicker3.Value = Format(Now.Date, "yyyy/MM/dd")

    '        TextBox5.Enabled = False
    '        TextBox6.Enabled = True
    '        TextBox8.Enabled = False
    '    End If







    '    'Me.ButtonX1.Enabled = False
    '    'Me.ButtonX4.Enabled = False




    'End Sub
    Sub clearing()

        Me.TextBox6.Clear()
        Me.TextBox8.Clear()
        TextBox5.Clear()
        Me.TextBox7.Clear()
        Me.TextBox4.Clear()
        DataGridViewX1.DataSource = Nothing
    End Sub
    Sub clearing_T()

        Me.RadioButton1.Checked = False
        Me.RadioButton2.Checked = False
        Me.DateTimePicker3.Value = Now

    End Sub

    Sub smove_no_i()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i) values (@x1,@x2,@x3,@x4,@x5,@x6)"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox4.Text)))
        cm.Parameters.Add(New SqlParameter("@x2", TextBox6.Text))
        cm.Parameters.Add(New SqlParameter("@x3", CDec(TextBox5.Text)))
        cm.Parameters.Add(New SqlParameter("@x4", 4))
        cm.Parameters.Add(New SqlParameter("@x5", Trim(TextBox1.Text)))
        cm.Parameters.Add(New SqlParameter("@x6", CDate(TextBox2.Text)))
        Try
            cm.ExecuteNonQuery()
            dstran.Clear()
            adtran.Fill(dstran, "tran_IRT")

        Catch

        End Try

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
        cm1.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
        cm1.Parameters.Add(New SqlParameter("@x2", CDate(TextBox2.Text)))
        cm1.Parameters.Add(New SqlParameter("@x3", Trim(TextBox3.Text)))
        cm1.Parameters.Add(New SqlParameter("@x4", TextBox4.Text))
        cm1.Parameters.Add(New SqlParameter("@x5", TextBox5.Text))
        Try
            cm1.ExecuteNonQuery()
            dsact.Clear()
            adact.Fill(dsact, "acthion_tran")
        Catch
            ''MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
            'Exit Sub
        End Try

    End Sub
    Sub But_action_user()
        t_doc = "اذن مواد تالفه"
        ts = TimeOfDay

        If cn.State = ConnectionState.Closed Then
            cn.Open()

        End If

        Dim s As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cm.Parameters.Add(New SqlParameter("@x2", t_doc))
        cm.Parameters.Add(New SqlParameter("@x3", Trim(TextBox4.Text)))
        cm.Parameters.Add(New SqlParameter("@x4", TextBox6.Text))
        cm.Parameters.Add(New SqlParameter("@x5", CDec(TextBox5.Text)))
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


    Sub delet()


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "delete from tran_IRT where no_c=@x1 and n_rs=@x2 and price=@x3 and tr_type=4"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox4.Text)))
        cm.Parameters.Add(New SqlParameter("@x2", Trim(TextBox1.Text)))
        cm.Parameters.Add(New SqlParameter("@x3", CDec(TextBox5.Text)))
        Try
            cm.ExecuteNonQuery()
            dstran.Clear()
            adtran.Fill(dstran, "tran_IRT")
            cn.Close()
        Catch

        End Try
    End Sub
    'Sub delet_action()

    '    '============================================
    '    If cn.State = ConnectionState.Closed Then
    '        cn.Open()
    '    End If
    '    Dim s As String = "delete from acthion_tran where no_c=@x1 and info=@x2 and sal_s=@x3 and date_i=@x4"
    '    Dim cm As New SqlCommand(s, cn)
    '    cm.Parameters.Add(New SqlParameter("@x1", TextBoxX2.Text))
    '    cm.Parameters.Add(New SqlParameter("@x2", TextBox1.Text))
    '    cm.Parameters.Add(New SqlParameter("@x3", (Me.TextBoxX7.Text)))
    '    cm.Parameters.Add(New SqlParameter("@x4", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
    '    Try
    '        cm.ExecuteNonQuery()
    '        dsact.Clear()
    '        adact.Fill(dsact, "acthion_tran")
    '    Catch

    '    End Try

    'End Sub

    'Private Sub update_tran()
    '    If cn.State = ConnectionState.Closed Then
    '        cn.Open()
    '    End If

    '    Dim s1 As String = "update tran_IRT set n_rs='" & TextBox1.Text & "' ,no_c='" & TextBoxX2.Text & "' , quntity=" & Me.TextBoxX4.Text & "  where n_rs='" & TextBox1.Text & "' and no_c='" & TextBoxX2.Text & "' and price=" & TextBoxX7.Text & " and tr_type=4"
    '    Dim cm1 As New SqlCommand(s1, cn)
    '    cm1.ExecuteNonQuery()
    '    dstran.Clear()
    '    adtran.Fill(dstran, "tran_IRT")
    '    cn.Close()
    'End Sub
    'Sub update_actiontran()

    '    If cn.State = ConnectionState.Closed Then
    '        cn.Open()
    '    End If
    '    ''If sum_irct = 0 Then
    '    '    delet()
    '    'Else
    '    Dim s1 As String = "update acthion_tran set info=@x1,no_c=@x2,date_i=@x3,qun_tot=@x4,sal_s=@x5 where info=@x1 and no_c=@x2 and date_i=@x3 and sal_s=@x5"
    '    Dim cm1 As New SqlCommand(s1, cn)
    '    cm1.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
    '    cm1.Parameters.Add(New SqlParameter("@x2", Me.TextBoxX2.Text))
    '    cm1.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
    '    cm1.Parameters.Add(New SqlParameter("@x4", TextBoxX4.Text))
    '    cm1.Parameters.Add(New SqlParameter("@x5", CDec(TextBoxX7.Text)))
    '    Try
    '        cm1.ExecuteNonQuery()
    '        dsact.Clear()
    '        adact.Fill(dsact, "acthion_tran")
    '    Catch
    '        ''MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
    '        'Exit Sub
    '    End Try

    'End Sub

    'Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    '    'add()
    '    l()
    '    clearing_T()
    '    clearing()
    'End Sub





    Private Sub DataGridViewX1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick
        If DataGridViewX1.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub
        '***************************
        If (DataGridViewX1.SelectedRows.Count = 0) Then
            MessageBox.Show("لاتوجد عناصر تم اختارها")
        End If

        'Me.TextBox2.Text = DataGridView1.SelectedCells.Item(0).Value.ToString
        If cn.State = ConnectionState.Closed Then cn.Open()
        'TextBox4.Text = ""
        For i = 0 To DataGridViewX1.RowCount - 1


            TextBox3.Text = DataGridViewX1.CurrentRow.Cells(0).Value.ToString
            TextBox4.Text = DataGridViewX1.CurrentRow.Cells(1).Value.ToString
            TextBox2.Text = DataGridViewX1.CurrentRow.Cells(2).Value.ToString

            TextBox6.Text = DataGridViewX1.CurrentRow.Cells(3).Value.ToString
            TextBox8.Text = DataGridViewX1.CurrentRow.Cells(3).Value.ToString
            TextBox5.Text = DataGridViewX1.CurrentRow.Cells(4).Value.ToString


        Next

    End Sub

    Private Sub DataGridViewX1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewX1.Click
        If DataGridViewX1.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub

        If cn.State = ConnectionState.Closed Then cn.Open()

        For i = 0 To DataGridViewX1.RowCount - 1


            'If Me.DataGridViewX2.Rows(i).Cells.Item(0).Value = True Then
            TextBox3.Text = DataGridViewX1.CurrentRow.Cells(0).Value.ToString
            TextBox4.Text = DataGridViewX1.CurrentRow.Cells(1).Value.ToString
            TextBox2.Text = DataGridViewX1.CurrentRow.Cells(2).Value.ToString
            TextBox5.Text = DataGridViewX1.CurrentRow.Cells(4).Value.ToString
            TextBox6.Text = DataGridViewX1.CurrentRow.Cells(3).Value.ToString
            TextBox8.Text = DataGridViewX1.CurrentRow.Cells(3).Value.ToString
        Next
    End Sub
    Sub sersch()


        If Me.TextBox1.Text <> " " Then

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s As String = "SELECT * from TALEF where NO_T =@x1 "
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add("@x1", Trim(TextBox1.Text))

            Try
                Dim r13 As SqlDataReader = cm.ExecuteReader
                If r13.Read = True Then


                    Me.DateTimePicker3.Value = r13!date_T
                    Me.RadioButton1.Checked = r13!SBdate
                    Me.RadioButton2.Checked = r13!SBakry
                    'ComboBoxEx4.Enabled = False
                    'Me.DateTimePicker3.Enabled = False
                    f = True
                    r13.Close()

                Else
                    f = False

                    'ComboBoxEx4.Enabled = True
                    'Me.DateTimePicker3.Enabled = True

                    r13.Close()
                End If

            Catch err As System.Exception
                MsgBox(err.Message)
            End Try
        Else
            Exit Sub

        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text <> "" Then
                xl = l_p(Trim(TextBox1.Text))
                TextBox1.Text = Trim(xl)
                sersch()

            End If
        End If

        If f = True Then
            MsgBox(" محضرالمواد التالفه  موجود ", MsgBoxStyle.Information, "تنبية")
            viwe()
            Me.Button3.Enabled = True
            Me.Button2.Enabled = False
        Else
            MsgBox(" محضرالمواد التالفه غير موجود ", MsgBoxStyle.Information, "تنبية")
            Me.Button3.Enabled = False
            Me.Button2.Enabled = True

        End If
    End Sub

    Sub viwe()


        'If f = True Then
        Dim dt2 As DataTable
        Dim sql1, n1 As String
        n1 = TextBox1.Text
        'If n1 = "" Then
        '    Exit Sub
        'Else

        'Dim s As String = "select * from f_ar WHERE f_ar.date_f like  " + "'" + Me.DateTimePicker1.Value.Date + "%" + "' And f_ar.no_f = " & Me.TextBox6.Text & ""
        sql1 = "SELECT * from sub_TALEF WHERE  sub_TALEF.no_t='" + TextBox1.Text + "'"
        Dim da8 As New SqlDataAdapter(sql1, cn)
        Dim ds8 As New DataSet
        ds8.Clear()
        da8.Fill(ds8, "sub_TALEF")
        dt2 = ds8.Tables("sub_TALEF")
        If dt2.Rows.Count > 0 Then

        End If
        'ListView1.Clear()
        Dim dr2 As DataRow

        ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("اسم الصنف", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("الكميه", 75, HorizontalAlignment.Center)
        ListView1.Columns.Add("سعر الوحدة", 75, HorizontalAlignment.Center)
        ListView1.Columns.Add("رصيد المخزن", 100, HorizontalAlignment.Center)
        'ListView1.Columns.Add("رقم المحضر", 0, HorizontalAlignment.Center)
        Dim sdl As Short = 1
        ListView1.Items.Clear()
        Dim i, c As Integer
        c = dt2.Rows.Count - 1
        For i = 0 To c
            Dim litem As New ListViewItem

            dr2 = dt2.Rows.Item(i)
            litem.Text = dt2.Rows(i).Item("no_c")
            litem.SubItems.Add(dt2.Rows(i).Item("name_snc"))
            litem.SubItems.Add(dt2.Rows(i).Item("qun_T"))
            litem.SubItems.Add(dt2.Rows(i).Item("praice"))
            litem.SubItems.Add(dt2.Rows(i).Item("balance"))




            ListView1.Items.Add(litem)
        Next i

        ListView1.View = View.Details

        'Else
        'Me.ListView1.Clear()
        'ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
        'ListView1.Columns.Add("اسم الصنف", 150, HorizontalAlignment.Left)
        'ListView1.Columns.Add("الكميه", 75, HorizontalAlignment.Center)
        'ListView1.Columns.Add("سعر الوحدة", 75, HorizontalAlignment.Center)
        'ListView1.Columns.Add("رصيد المخزن", 100, HorizontalAlignment.Center)

        'Exit Sub


    End Sub


    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        Dim litem As ListViewItem
        Dim i As Integer
        For Each litem In ListView1.SelectedItems
            TextBox4.Text = litem.SubItems(0).Text
            TextBox7.Text = litem.SubItems(1).Text
            TextBox6.Text = litem.SubItems(2).Text
            TextBox5.Text = litem.SubItems(3).Text
            TextBox8.Text = litem.SubItems(4).Text
        Next

        Me.ButtonX5.Enabled = True
        Me.ButtonX6.Enabled = True
        Me.ButtonX1.Enabled = True
        Me.ButtonX3.Enabled = True
        Me.ButtonX4.Enabled = True
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim litem As ListViewItem
        Dim i As Integer
        For Each litem In ListView1.SelectedItems
            TextBox4.Text = litem.SubItems(0).Text
            TextBox7.Text = litem.SubItems(1).Text
            TextBox6.Text = litem.SubItems(2).Text
            TextBox5.Text = litem.SubItems(3).Text
            TextBox8.Text = litem.SubItems(4).Text

        Next
        Me.ButtonX5.Enabled = True
        Me.ButtonX6.Enabled = True
        Me.ButtonX1.Enabled = True
        Me.ButtonX3.Enabled = True
        Me.ButtonX4.Enabled = True


    End Sub


    Sub l()
        Dim a As Integer
        a = Len(TextBox1.Text)
        If a = 1 Then
            Me.TextBox1.Text = ("000000" + Me.TextBox1.Text)
        End If
        If a = 2 Then
            Me.TextBox1.Text = ("00000" + Me.TextBox1.Text)
        End If
        If a = 3 Then
            Me.TextBox1.Text = ("0000" + Me.TextBox1.Text)
        End If
        If a = 4 Then
            Me.TextBox1.Text = ("000" + Me.TextBox1.Text)
        End If
        If a = 5 Then
            Me.TextBox1.Text = ("00" + Me.TextBox1.Text)
        End If
        If a = 6 Then
            Me.TextBox1.Text = ("0" + Me.TextBox1.Text)
        End If
    End Sub
    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        'l()
        'sersch()
        'If f = True Then
        '    'MsgBox(" محضرالمواد التالفه  موجود ", MsgBoxStyle.Information, "تنبية")
        '    viwe()
        '    Me.Button3.Visible = True
        '    Me.Button2.Visible = False

        'Else
        '    'MsgBox(" محضرالمواد التالفه غير موجود ", MsgBoxStyle.Information, "تنبية")
        '    Me.Button3.Visible = False
        '    Me.Button2.Visible = True

        'End If
    End Sub


    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        Dim s As String = "update  sub_TALEF set no_t=@x1,no_c=@x2,qun_T=@x4,praice=@x5,balance=@x6 where no_t=@x1 and no_c=@x2 "
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cm.Parameters.Add(New SqlParameter("@x2", Trim(TextBox4.Text)))
        cm.Parameters.Add(New SqlParameter("@x4", TextBox6.Text))
        cm.Parameters.Add(New SqlParameter("@x5", CDec(TextBox5.Text)))
        cm.Parameters.Add(New SqlParameter("@x6", TextBox8.Text))
        Try

            cm.ExecuteNonQuery()
            ds11.Clear()
            ad11.Fill(ds11, "sub_TALEF")

            MsgBox("تم التعديل", MsgBoxStyle.Information, "تنبية")
            clearing()

            Me.ListView1.Clear()
            viwe()

        Catch
            MsgBox("لايمكنك التعديل في رقم الصنف ورقم الفاتورة وتاريخ الفاتورة ", MsgBoxStyle.Information, "تنبية")
        End Try

        Me.ButtonX1.Enabled = False
        Me.ButtonX4.Enabled = False

    End Sub



    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        If ListView1.Items.Count < 0 Then
            'If ListView1.FocusedItem.Index = DBNull.Value.ToString Then
            Exit Sub
            'End If
        Else

            ListView1.Items.RemoveAt(ListView1.FocusedItem.Index)


            Dim s As String = "delete from sub_TALEF where no_t=@x1 and no_c=@x2"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cm.Parameters.Add(New SqlParameter("@x2", Trim(TextBox4.Text)))
            If MsgBox("هل أنت متأكد من عملية حدفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then
                Try
                    cm.ExecuteNonQuery()
                    ds11.Clear()
                    ad11.Fill(ds11, "sub_TALEF")
                    clearing()
                    Me.ListView1.Clear()
                    viwe()
                Catch
                    MsgBox("لايمـكـن الـحـد ف", MsgBoxStyle.SystemModal, "تنبية")
                End Try
            Else
                Exit Sub
            End If
        End If
        Me.ButtonX1.Enabled = False
        Me.ButtonX4.Enabled = False
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        ListView1.Items.Clear()

        Dim s As String = "delete from sub_TALEF where no_t=@x1"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        If MsgBox("هل أنت متأكد من عملية حدفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then



            Try
                cm.ExecuteNonQuery()
                ds11.Clear()
                ad11.Fill(ds11, "sub_TALEF")
                clearing()
                Me.ListView1.Clear()
                viwe()
            Catch
                MsgBox("لايمـكـن الـحـذف", MsgBoxStyle.SystemModal, "تنبية")
            End Try
        Else
            Exit Sub
        End If
        clearing()
        Me.ButtonX4.Enabled = False
        Me.ButtonX3.Enabled = False
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        '777777777777777777777777

        If TextBox1.Text <> "" Then
            Dim adp As New SqlDataAdapter("select NO_T,date_T, SBdate,SBakry,no_c,name_snc,name_type, cast([qun_T] as nvarchar(50))as qun_T,praice,cast([balance ] as nvarchar(50))as balance , qun_Tt  from tt_talf where [no_t]='" + TextBox1.Text + "'", cn)
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
            Text16.Text = branch
            frm.ShowDialog()



        Else : Exit Sub
        End If



    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        ListView1.Items.Clear()

        Dim s As String = "delete from TALEF where NO_T=@x1"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        If MsgBox("هل أنت متأكد من عملية حدفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then



            Try
                cm.ExecuteNonQuery()
                ds1.Clear()
                ad1.Fill(ds1, "TALEF")
                clearing()
                Me.ListView1.Clear()

            Catch
                MsgBox("لايمـكـن الـحـذف", MsgBoxStyle.SystemModal, "تنبية")
            End Try



            '==============================================
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If



            Dim sv As String = "delete from sub_TALEF where no_t=@x1"
            Dim cmv As New SqlCommand(sv, cn)
            cmv.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            'If MsgBox("هل أنت متأكد من عملية حدفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then

            Try
                cmv.ExecuteNonQuery()
                ds11.Clear()
                ad11.Fill(ds11, "sub_TALEF")
                clearing()
                Me.ListView1.Clear()
            Catch
                MsgBox("لايمـكـن الـحـد ف", MsgBoxStyle.SystemModal, "تنبية")
            End Try

        Else
            Exit Sub
        End If
        viwe()
    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "update TALEF set NO_T=@x1,date_T=@x2,SBdate=@x3,SBakry=@x4 where NO_T=@x1"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
        cm.Parameters.Add(New SqlParameter("@x3", Me.RadioButton1.Checked))
        cm.Parameters.Add(New SqlParameter("@x4", Me.RadioButton2.Checked))

        Try
            cm.ExecuteNonQuery()
            ds1.Clear()
            ad1.Fill(ds1, "TALEF")

            MsgBox("تم التعديل", MsgBoxStyle.Information, "تنبية")
            clearing()

            Me.ListView1.Clear()
            viwe()

        Catch
            MsgBox("لايمكنك التعديل في رقم الفاتورة  ", MsgBoxStyle.Information, "تنبية")
        End Try
    End Sub

    Private Sub TextBoxX4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        secu_num(e)
    End Sub
    'Sub update_action_transrf()
    '    If cn.State = ConnectionState.Closed Then
    '        cn.Open()
    '    End If
    '    ''If sum_irct = 0 Then
    '    '    delet()
    '    'Else
    '    Dim s1 As String = "update acthion_tran set qun_tot=@x1,date_i=@x2,info=@x3 where info=@x3 and date_i=@x2 and no_c=@x4 and sal_s=@x5 "
    '    Dim cm1 As New SqlCommand(s1, cn)
    '    cm1.Parameters.Add(New SqlParameter("@x1", Val(qun)))
    '    cm1.Parameters.Add(New SqlParameter("@x2", CDate(TextBoxX5.Text)))
    '    cm1.Parameters.Add(New SqlParameter("@x3", TextBoxX7.Text))
    '    cm1.Parameters.Add(New SqlParameter("@x4", Me.TextBoxX3.Text))
    '    cm1.Parameters.Add(New SqlParameter("@x5", TextBoxX1.Text))
    '    Try
    '        cm1.ExecuteNonQuery()
    '        dsact.Clear()
    '        adact.Fill(dsact, "acthion_tran")
    '    Catch
    '        ''MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
    '        'Exit Sub
    '    End Try

    'End Sub
    '=============================المصروفات
    Sub stouck()
        If TextBox4.Text <> "" Then


            Dim i, w As Integer
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim sql As String = "select no_c,qun_r from RcvSub where RcvSub.no_c ='" + TextBox4.Text + "'"
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
                If DROW1("no_c") = (TextBox4.Text) Then

                    y = Val(DROW1("qun_r"))
                    sum_irct = sum_irct + y
                End If
            Next

            cn.Close()
            '===============اجمالي المصروف==================

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim sq3 As String = "select * from IsuSub where IsuSub.[no_c] ='" + TextBox4.Text + "'"

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
                If DROW3("no_c") = (TextBox4.Text) Then

                    y2 = Val(DROW3("qun_s"))
                    sum_iiss = sum_iiss + y2

                End If
            Next


            cn.Close()
            '===============اجمالي مرتجعه==================


            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim sq4 As String = "select * from matt_return where matt_return.[no_c] ='" + TextBox4.Text + "'"

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

                If DROW4("no_c") = (TextBox4.Text) Then

                    y4 = Val(DROW4("qun_t"))
                    sum_return = sum_return + y4

                End If
            Next
            cn.Close()


            total_s = 0


            '===============تالف==================
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim sq5 As String = "select * from sub_TALEF where sub_TALEF.[no_c] ='" + TextBox4.Text + "'"

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

                If DROW5("no_c") = (TextBox4.Text) Then

                    y5 = Val(DROW5("qun_T"))
                    sum_talf = sum_talf + y5

                End If
            Next
            cn.Close()

            total_s = 0
            Me.LabelX1.Text = 0

            Me.total_s = ((sum_irct + sum_return) - sum_iiss) - sum_talf



            '=======================================================
            Me.LabelX1.Text = 0
            Me.LabelX1.Text = total_s
            '=======================================================

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            i = 0
            Dim admt As New SqlDataAdapter
            Dim dsmt As New DataSet
            Dim s1 As String = "update  matt set no_c=@x1,balance=@x2,iiss=@x4 where no_c=@x1"
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", Trim(TextBox4.Text)))
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


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        move_no = "0"
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If TextBox4.Text = "" Then
            MsgBox("عفواً..يجب أن تدخل  رقم الصنف ", MsgBoxStyle.Information, "تنبيه")
            TextBox4.Focus()
            Exit Sub
        End If
        If Me.RadioButton1.Checked = False And Me.RadioButton2.Checked = False Then
            MsgBox("عفواً..يجب أن تختار سبب التلف ", MsgBoxStyle.Information, "تنبيه")

            Exit Sub
        End If

        If TextBox8.Text = "" Or TextBox5.Text = "" Then
            MsgBox("انقر على المخزن لتحديد السعر ورصيد المخزن  ", MsgBoxStyle.Information, "إجراء إضافة")

            Exit Sub
        End If

        If TextBox8.Text = 0 Or TextBox6.Text = 0 Then
            MsgBox("لاتسطيع اتلاف الصنف رصيد المخزن  ", MsgBoxStyle.Information, "إجراء إضافة")

            Exit Sub
        End If
        'If TextBoxX5.Text = 0 Then
        '    MsgBox("انقر على المخزن لتحديد السعر ورصيد المخزن  ", MsgBoxStyle.Information, "إجراء إضافة")

        '    Exit Sub
        'End If


        If TextBox6.Text = "" Then
            MsgBox("عفواً..يجب أن تدخل  الكمية ", MsgBoxStyle.Information, "تنبيه")
            TextBox6.Focus()
            Exit Sub
        End If



        If f = True Then

            If cn.State = ConnectionState.Closed Then
                cn.Open()

            End If
            TextBox8.Text = Val(TextBox8.Text) - Val(TextBox6.Text)



            Dim s As String = "insert into sub_TALEF(no_t,no_c,name_snc,qun_T,praice,balance) values (@x1,@x2,@x3,@x4,@x5,@x6)"
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cm.Parameters.Add(New SqlParameter("@x2", Trim(TextBox4.Text)))
            cm.Parameters.Add(New SqlParameter("@x3", Trim(TextBox7.Text)))
            cm.Parameters.Add(New SqlParameter("@x4", TextBox6.Text))
            cm.Parameters.Add(New SqlParameter("@x5", TextBox5.Text))
            cm.Parameters.Add(New SqlParameter("@x6", TextBox8.Text))

            Try
                cm.ExecuteNonQuery()
                ds11.Clear()
                ad11.Fill(ds11, "sub_TALEF")
                MessageBoxEx.Show("تم الحفظ", "v1مخازن", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cn.Close()
                smove_no_i()
                update_action_transrf()
                stouck()
                viwe()
                t_event = "حفظ صنف"
                But_action_user()
                Me.TextBox4.Text = ""

                'Me.ListView1.Clear()

            Catch
                MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
                Exit Sub
            End Try


        Else


            If cn.State = ConnectionState.Closed Then
                cn.Open()

            End If

            Dim s As String = "insert into TALEF(NO_T,date_T,SBdate,SBakry) values (@x1,@x2,@x3,@x4)"
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
            cm.Parameters.Add(New SqlParameter("@x3", Me.RadioButton1.Checked))
            cm.Parameters.Add(New SqlParameter("@x4", Me.RadioButton2.Checked))

            Try
                cm.ExecuteNonQuery()
                ds1.Clear()
                ad1.Fill(ds1, "TALEF")



            Catch err As System.Exception
                MsgBox(err.Message)
            End Try

        End If
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Try
            Dim s22 As String = "insert into Table_OSTA(no_I,no_c,date_I,qI,sal_s,date_r,no_R,qR) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8)"
            Dim cm22 As New SqlCommand(s22, cn)
            cm22.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
            cm22.Parameters.Add(New SqlParameter("@x2", TextBox4.Text))
            cm22.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
            cm22.Parameters.Add(New SqlParameter("@x4", TextBox6.Text))
            cm22.Parameters.Add(New SqlParameter("@x5", CDec(TextBox5.Text)))
            cm22.Parameters.Add(New SqlParameter("@x6", CDate(TextBox2.Text)))
            cm22.Parameters.Add(New SqlParameter("@x7", Me.TextBox3.Text))
            cm22.Parameters.Add(New SqlParameter("@x8", TextBox8.Text))
            cm22.ExecuteNonQuery()
            dsIsuST.Clear()
            adIsuT.Fill(dsIsuST, "Table_OSTA")
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try
        Me.LabelX1.Text = ""

        'clearing()

        ListView1.Sorting = SortOrder.Ascending
        viwe()
    End Sub

    Sub auto_n()
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

  


    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        'TextBox6.Clear()
        'Me.TextBoxX5.Clear()
        'Me.TextBox5.Clear()
        'Me.TextBoxX3.Clear()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "select * from matt where no_c=@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", (TextBox4.Text)))
        Try

            Dim r As SqlDataReader = cm.ExecuteReader

            If r.Read = True Then

                TextBox7.Text = r!name_snc
                Me.ComboBoxEx1.SelectedValue = r!c_type
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

        Dim date_2 As Date
        Dim ds1, dsش As DataSet
        ds1 = New DataSet
        ds1.Clear()
        dsش = New DataSet
        dsش.Clear()
        'date_2 = CDate(TextBox2.Text)
        If Im_talef = "فورم الصلاحيه" Then




            date_2 = CDate(TextBox2.Text)
            Dim sش As String = "select * from acthion_tran where no_c ='" + Me.TextBox4.Text + "' and info ='" + Me.TextBox3.Text + "' and date_i ='" & date_2.ToString("yyyy/MM/dd") & "'"
            Dim adش As New SqlDataAdapter(sش, cn)
            adش.Fill(dsش, "acthion_tran")
            Me.DataGridViewX1.DataSource = dsش
            Me.DataGridViewX1.DataMember = "acthion_tran"
            DataGridViewX1.Refresh()
            cn.Close()

        Else

            '================

            Dim s1 As String = "select * from acthion_tran where no_c ='" + Me.TextBox4.Text + "' and qun_tot<>0"
            Dim ad1 As New SqlDataAdapter(s1, cn)
            ad1.Fill(ds1, "acthion_tran")
            Me.DataGridViewX1.DataSource = ds1
            Me.DataGridViewX1.DataMember = "acthion_tran"
            DataGridViewX1.Refresh()
            cn.Close()



        End If

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If TextBox8.Text = "" Or TextBox5.Text = "" Then
            MsgBox("انقر على المخزن لتحديد السعر ورصيد المخزن  ", MsgBoxStyle.Information, "إجراء إضافة")

            Exit Sub
        End If

        If TextBox8.Text = 0 Or TextBox6.Text = 0 Then
            MsgBox("لاتستطيع اتلاف الصنف رصيد المخزن صفر  ", MsgBoxStyle.Information, "إجراء إضافة")

            Exit Sub
        End If
        TextBox8.Text = Val(TextBox8.Text) - Val(TextBox6.Text)

        Dim Trans As SqlTransaction = cn.BeginTransaction

        Try
            Dim s As String = "insert into TALEF(NO_T,date_T,SBdate,SBakry) values (@x1,@x2,@x3,@x4)"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
            cm.Parameters.Add(New SqlParameter("@x3", True))
            cm.Parameters.Add(New SqlParameter("@x4", False))
            cm.Transaction = Trans

            cm.ExecuteNonQuery()

            '=======================================


            Dim sq As String = "insert into sub_TALEF(no_t,no_c,name_snc,qun_T,praice,balance) values (@x1,@x2,@x3,@x4,@x5,@x6)"
            Dim cmq As New SqlCommand(sq, cn)

            cmq.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cmq.Parameters.Add(New SqlParameter("@x2", Trim(TextBox4.Text)))
            cmq.Parameters.Add(New SqlParameter("@x3", Trim(TextBox7.Text)))
            cmq.Parameters.Add(New SqlParameter("@x4", TextBox6.Text))
            cmq.Parameters.Add(New SqlParameter("@x5", TextBox5.Text))
            cmq.Parameters.Add(New SqlParameter("@x6", TextBox8.Text))

            cmq.Transaction = Trans
            cmq.ExecuteNonQuery()



            '==========smove_no_i===============
            Dim smov As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i,count1) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7)"
            Dim cmsmov As New SqlCommand(smov, cn)
            cmsmov.Parameters.AddWithValue("@x1", Trim(TextBox4.Text))
            cmsmov.Parameters.AddWithValue("@x2", CInt(TextBox6.Text))
            cmsmov.Parameters.AddWithValue("@x3", CDec(TextBox5.Text))
            cmsmov.Parameters.AddWithValue("@x4", 4)
            cmsmov.Parameters.AddWithValue("@x5", Trim(TextBox3.Text))
            cmsmov.Parameters.AddWithValue("@x6", CDate(TextBox2.Text))
            cmsmov.Parameters.AddWithValue("@x7", 0).DbType = DbType.Int32
            cmsmov.Transaction = Trans
            cmsmov.ExecuteNonQuery()

            '=====acthion_tran================



            Dim stran As String = "update acthion_tran set qun_tot=@x4,date_i=@x2,info=@x1 where info=@x1 and no_c=@x3 and date_i=@x2  and sal_s=@x5 "
            Dim cmtran As New SqlCommand(stran, cn)
            cmtran.Parameters.AddWithValue("@x1", Trim(TextBox3.Text))
            cmtran.Parameters.AddWithValue("@x2", CDate(TextBox2.Text))
            cmtran.Parameters.AddWithValue("@x3", Trim(TextBox4.Text))
            cmtran.Parameters.AddWithValue("@x4", CInt(TextBox8.Text))
            cmtran.Parameters.AddWithValue("@x5", CDec(TextBox5.Text))
            cmtran.Transaction = Trans
            cmtran.ExecuteNonQuery()

            '======up====salahia==========

            Dim sql As String = "update salahia set  state_sal=@x5 where no_c=@x1 and sal_s=@x2 and no_i=@x3 and date_i=@x4"
            Dim cms As New SqlCommand(sql, cn)
            cms.Parameters.AddWithValue("@x1", Trim(TextBox4.Text))
            cms.Parameters.AddWithValue("@x2", CDec(TextBox5.Text))
            cms.Parameters.AddWithValue("@x3", Trim(TextBox3.Text))
            cms.Parameters.AddWithValue("@x4", CDate(TextBox2.Text))
            cms.Parameters.AddWithValue("@x5", 1)
            cms.Transaction = Trans
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
            cmevent.Parameters.AddWithValue("@x3", Trim(TextBox4.Text))
            cmevent.Parameters.AddWithValue("@x4", CInt(TextBox6.Text))
            cmevent.Parameters.AddWithValue("@x5", CDec(TextBox5.Text))
            cmevent.Parameters.AddWithValue("@x6", Format(Now.Date, "yyyy/MM/dd")).DbType = DbType.Date
            cmevent.Parameters.AddWithValue("@x7", ts)
            cmevent.Parameters.AddWithValue("@x8", ww).DbType = DbType.String
            cmevent.Parameters.AddWithValue("@x9", t_event).DbType = DbType.String

            cmevent.Transaction = Trans
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
            Trans.Commit()
            MsgBox("حفظ اذن التالف", MsgBoxStyle.Information, " حفظ")
        Catch err As System.Exception

            Trans.Rollback()
            MsgBox("لم يتم حفظ اذن التالف", MsgBoxStyle.Information, " حفظ")
            MsgBox(err.Message)

        Finally
        End Try
        viwe()
        stouck()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If TextBox8.Text = "" Or TextBox5.Text = "" Then
            MsgBox("انقر على المخزن لتحديد السعر ورصيد المخزن  ", MsgBoxStyle.Information, "إجراء إضافة")

            Exit Sub
        End If

        If TextBox8.Text = 0 Or TextBox6.Text = 0 Then
            MsgBox("لاتستطيع اتلاف الصنف رصيد المخزن صفر  ", MsgBoxStyle.Information, "إجراء إضافة")

            Exit Sub
        End If
        TextBox8.Text = Val(TextBox8.Text) - Val(TextBox6.Text)
        Dim Trans As SqlTransaction = cn.BeginTransaction

        Try

            If f = True Then
                Dim s As String = "insert into TALEF(NO_T,date_T,SBdate,SBakry) values (@x1,@x2,@x3,@x4)"
                Dim cm As New SqlCommand(s, cn)
                cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
                cm.Parameters.Add(New SqlParameter("@x3", Me.RadioButton1.Checked))
                cm.Parameters.Add(New SqlParameter("@x4", Me.RadioButton2.Checked))
                cm.Transaction = Trans
                cm.ExecuteNonQuery()
            Else

                Dim s As String = "update TALEF set NO_T=@x1,date_T=@x2,SBdate=@x3,SBakry=@x4 where NO_T=@x1"
                Dim cm As New SqlCommand(s, cn)
                cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
                cm.Parameters.Add(New SqlParameter("@x3", Me.RadioButton1.Checked))
                cm.Parameters.Add(New SqlParameter("@x4", Me.RadioButton2.Checked))
            End If
            '=======================================


            Dim sq As String = "insert into sub_TALEF(no_t,no_c,name_snc,qun_T,praice,balance) values (@x1,@x2,@x3,@x4,@x5,@x6)"
            Dim cmq As New SqlCommand(sq, cn)

            cmq.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cmq.Parameters.Add(New SqlParameter("@x2", Trim(TextBox4.Text)))
            cmq.Parameters.Add(New SqlParameter("@x3", Trim(TextBox7.Text)))
            cmq.Parameters.Add(New SqlParameter("@x4", TextBox6.Text))
            cmq.Parameters.Add(New SqlParameter("@x5", TextBox5.Text))
            cmq.Parameters.Add(New SqlParameter("@x6", TextBox8.Text))

            cmq.Transaction = Trans
            cmq.ExecuteNonQuery()



            '==========smove_no_i===============
            Dim smov As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i,count1) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7)"
            Dim cmsmov As New SqlCommand(smov, cn)
            cmsmov.Parameters.AddWithValue("@x1", Trim(TextBox4.Text))
            cmsmov.Parameters.AddWithValue("@x2", CInt(TextBox6.Text))
            cmsmov.Parameters.AddWithValue("@x3", CDec(TextBox5.Text))
            cmsmov.Parameters.AddWithValue("@x4", 4)
            cmsmov.Parameters.AddWithValue("@x5", Trim(TextBox3.Text))
            cmsmov.Parameters.AddWithValue("@x6", CDate(TextBox2.Text))
            cmsmov.Parameters.AddWithValue("@x7", 0).DbType = DbType.Int32
            cmsmov.Transaction = Trans
            cmsmov.ExecuteNonQuery()








            '=====acthion_tran================


            Dim stran As String = "update acthion_tran set qun_tot=@x4,date_i=@x2,info=@x1 where info=@x1 and no_c=@x3 and date_i=@x2  and sal_s=@x5 "
            Dim cmtran As New SqlCommand(stran, cn)
            cmtran.Parameters.AddWithValue("@x1", Trim(TextBox3.Text))
            cmtran.Parameters.AddWithValue("@x2", CDate(TextBox2.Text))
            cmtran.Parameters.AddWithValue("@x3", Trim(TextBox4.Text))
            cmtran.Parameters.AddWithValue("@x4", CInt(TextBox6.Text))
            cmtran.Parameters.AddWithValue("@x5", CDec(TextBox5.Text))
            cmtran.Transaction = Trans
            cmtran.ExecuteNonQuery()


            '======up====salahia==========

            Dim sql As String = "update salahia set  state_sal=@x5 where no_c=@x1 and sal_s=@x2 and no_i=@x3 and date_i=@x4"
            Dim cms As New SqlCommand(sql, cn)
            cms.Parameters.AddWithValue("@x1", Trim(TextBox4.Text))
            cms.Parameters.AddWithValue("@x2", CDec(TextBox5.Text))
            cms.Parameters.AddWithValue("@x3", Trim(TextBox3.Text))
            cms.Parameters.AddWithValue("@x4", CDate(TextBox2.Text))
            cms.Parameters.AddWithValue("@x5", 1)
            cms.Transaction = Trans
            cms.ExecuteNonQuery()
            '=========================

            't_event = "حفظ صنف"
            't_doc = "اذن الاستلام"
            'ts = TimeOfDay

            'Dim sevent As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
            'Dim cmevent As New SqlCommand(sevent, cn)
            'cmevent.Parameters.AddWithValue("@x1", Trim(TextBox8.Text)).DbType = DbType.String
            'cmevent.Parameters.AddWithValue("@x2", t_doc).DbType = DbType.String
            'cmevent.Parameters.AddWithValue("@x3", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
            'cmevent.Parameters.AddWithValue("@x4", DataGridViewX2.Rows(i).Cells(1).Value).DbType = DbType.Int32
            'cmevent.Parameters.AddWithValue("@x5", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.Decimal
            'cmevent.Parameters.AddWithValue("@x6", Format(Now.Date, "yyyy/MM/dd")).DbType = DbType.Date
            'cmevent.Parameters.AddWithValue("@x7", ts)
            'cmevent.Parameters.AddWithValue("@x8", ww).DbType = DbType.String
            'cmevent.Parameters.AddWithValue("@x9", t_event).DbType = DbType.String

            'cmevent.Transaction = Trans
            'cmevent.ExecuteNonQuery()




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
            Trans.Commit()
            MsgBox("حفظ اذن التالف", MsgBoxStyle.Information, " حفظ")
        Catch err As System.Exception

            Trans.Rollback()
            MsgBox("لم يتم حفظ اذن التالف", MsgBoxStyle.Information, " حفظ")
            MsgBox(err.Message)

        Finally
        End Try
        viwe()
    End Sub

    'Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged



    '    'Dim qun_tot As Int64
    '    'Dim no_c As String
    '    'Dim info As String
    '    'Dim date_i As Date
    '    'Dim sal_s As Double
    '    'Dim name_sncc As String
    '    'name_sncc = ""


    '    ''If Im_talef = "فورم الصلاحيه" Then
    '    'Dim litem As ListViewItem
    '    'Dim ds As New DataSet
    '    'Dim Trans As SqlTransaction = cn.BeginTransaction
    '    'Try
    '    '    For Each litem In ListView2.SelectedItems
    '    '        no_c = litem.SubItems(0).Text
    '    '        info = litem.SubItems(6).Text
    '    '        date_i = litem.SubItems(7).Text
    '    '        sal_s = litem.SubItems(1).Text

    '    '        '2222222222222222222222222222
    '    '        Dim s1 As String = "select * from matt where no_c=@x1"
    '    '        Dim cm1 As New SqlCommand(s1, cn)

    '    '        cm1.Parameters.Add(New SqlParameter("@x1", no_c))
    '    '        Try

    '    '            Dim r1 As SqlDataReader = cm1.ExecuteReader

    '    '            If r1.Read = True Then

    '    '                name_sncc = r1!name_snc

    '    '                r1.Close()
    '    '            Else

    '    '                r1.Close()
    '    '            End If

    '    '        Catch

    '    '        End Try
    '    '        Dim s As String = "select * from acthion_tran where no_c=@x1 and info=@x2 and date_i=@x3 and sal_s=@x4"
    '    '        Dim cm As New SqlCommand(s, cn)
    '    '        cm.Parameters.Add(New SqlParameter("@x1", no_c))
    '    '        cm.Parameters.Add(New SqlParameter("@x2", info))
    '    '        cm.Parameters.Add(New SqlParameter("@x3", date_i))
    '    '        cm.Parameters.Add(New SqlParameter("@x4", sal_s))
    '    '        Try
    '    '            Dim r1 As SqlDataReader = cm.ExecuteReader
    '    '            If r1.Read = True Then

    '    '                qun_tot = r1!qun_tot

    '    '                r1.Close()

    '    '            Else
    '    '                r1.Close()
    '    '            End If
    '    '        Catch

    '    '        End Try




    '    '        Dim s2 As String = "insert into TALEF(NO_T,date_T,SBdate,SBakry) values (@x1,@x2,@x3,@x4)"
    '    '        Dim cm2 As New SqlCommand(s2, cn)
    '    '        cm2.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
    '    '        cm2.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
    '    '        cm2.Parameters.Add(New SqlParameter("@x3", True))
    '    '        cm2.Parameters.Add(New SqlParameter("@x4", False))
    '    '        cm2.Transaction = Trans

    '    '        cm2.ExecuteNonQuery()

    '    '        '=======================================


    '    '        Dim sq As String = "insert into sub_TALEF(no_t,no_c,name_snc,qun_T,praice,balance) values (@x1,@x2,@x3,@x4,@x5,@x6)"
    '    '        Dim cmq As New SqlCommand(sq, cn)

    '    '        cmq.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
    '    '        cmq.Parameters.Add(New SqlParameter("@x2", no_c))
    '    '        cmq.Parameters.Add(New SqlParameter("@x3", name_sncc))
    '    '        cmq.Parameters.Add(New SqlParameter("@x4", qun_tot))
    '    '        cmq.Parameters.Add(New SqlParameter("@x5", sal_s))
    '    '        cmq.Parameters.Add(New SqlParameter("@x6", 0))

    '    '        cmq.Transaction = Trans
    '    '        cmq.ExecuteNonQuery()


    '    '        '==========smove_no_i===============
    '    '        Dim smov As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i,count1) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7)"
    '    '        Dim cmsmov As New SqlCommand(smov, cn)
    '    '        cmsmov.Parameters.AddWithValue("@x1", no_c)
    '    '        cmsmov.Parameters.AddWithValue("@x2", qun_tot)
    '    '        cmsmov.Parameters.AddWithValue("@x3", sal_s)
    '    '        cmsmov.Parameters.AddWithValue("@x4", 4)
    '    '        cmsmov.Parameters.AddWithValue("@x5", Trim(TextBox1.Text))
    '    '        cmsmov.Parameters.AddWithValue("@x6", date_i)
    '    '        cmsmov.Parameters.AddWithValue("@x7", 0).DbType = DbType.Int32
    '    '        cmsmov.Transaction = Trans
    '    '        cmsmov.ExecuteNonQuery()

    '    '        '=====acthion_tran================



    '    '        Dim stran As String = "update acthion_tran set qun_tot=@x4,date_i=@x2,info=@x1 where info=@x1 and no_c=@x3 and date_i=@x2  and sal_s=@x5 "
    '    '        Dim cmtran As New SqlCommand(stran, cn)
    '    '        cmtran.Parameters.AddWithValue("@x1", info)
    '    '        cmtran.Parameters.AddWithValue("@x2", date_i)
    '    '        cmtran.Parameters.AddWithValue("@x3", no_c)
    '    '        cmtran.Parameters.AddWithValue("@x4", 0)
    '    '        cmtran.Parameters.AddWithValue("@x5", sal_s)
    '    '        cmtran.Transaction = Trans
    '    '        cmtran.ExecuteNonQuery()

    '    '        '======up====salahia==========

    '    '        Dim sql As String = "update salahia set  state_sal=@x5 where no_c=@x1 and sal_s=@x2 and no_i=@x3 and date_i=@x4"
    '    '        Dim cms As New SqlCommand(sql, cn)
    '    '        cms.Parameters.AddWithValue("@x1", no_c)
    '    '        cms.Parameters.AddWithValue("@x2", sal_s)
    '    '        cms.Parameters.AddWithValue("@x3", info)
    '    '        cms.Parameters.AddWithValue("@x4", date_i)
    '    '        cms.Parameters.AddWithValue("@x5", 1)
    '    '        cms.Transaction = Trans
    '    '        cms.ExecuteNonQuery()
    '    '        '=========================

    '    '        't_event = "حفظ صنف"
    '    '        't_doc = "اذن الاستلام"
    '    '        'ts = TimeOfDay

    '    '        t_event = "حفظ "
    '    '        t_doc = "اذن تالف"
    '    '        ts = TimeOfDay


    '    '        Dim sevent As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
    '    '        Dim cmevent As New SqlCommand(sevent, cn)
    '    '        cmevent.Parameters.AddWithValue("@x1", Trim(TextBox1.Text)).DbType = DbType.String
    '    '        cmevent.Parameters.AddWithValue("@x2", t_doc).DbType = DbType.String
    '    '        cmevent.Parameters.AddWithValue("@x3", no_c)
    '    '        cmevent.Parameters.AddWithValue("@x4", qun_tot)
    '    '        cmevent.Parameters.AddWithValue("@x5", sal_s)
    '    '        cmevent.Parameters.AddWithValue("@x6", Format(Now.Date, "yyyy/MM/dd")).DbType = DbType.Date
    '    '        cmevent.Parameters.AddWithValue("@x7", ts)
    '    '        cmevent.Parameters.AddWithValue("@x8", ww).DbType = DbType.String
    '    '        cmevent.Parameters.AddWithValue("@x9", t_event).DbType = DbType.String

    '    '        cmevent.Transaction = Trans
    '    '        cmevent.ExecuteNonQuery()






    '    '        '=======================تعديل المخزون========================

    '    '        'If DataGridViewX2.Rows(i).Cells(4).Value = "تم اظافته كرصيد منقول".ToString Then
    '    '        '    siopb = DataGridViewX2.Rows(i).Cells(1).Value

    '    '        '    Dim ss1 As String = "update  matt set no_c=@x1,balance=@x2,iopb=@x3,irct=@x5 where no_c=@x1"
    '    '        '    Dim cmst As New SqlCommand(ss1, cn)
    '    '        '    cmst.Parameters.AddWithValue("@x1", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
    '    '        '    cmst.Parameters.AddWithValue("@x2", total_s).DbType = DbType.Decimal
    '    '        '    cmst.Parameters.AddWithValue("@x3", Me.siopb).DbType = DbType.Decimal
    '    '        '    cmst.Parameters.AddWithValue("@x5", sum_irct).DbType = DbType.Decimal

    '    '        '    cmst.Transaction = Trans
    '    '        '    cmst.ExecuteNonQuery()


    '    '        'Else

    '    '        '    Dim sss1 As String = "update  matt set no_c=@x1,balance=@x2,irct=@x5 where no_c=@x1"
    '    '        '    Dim cmst1 As New SqlCommand(sss1, cn)
    '    '        '    cmst1.Parameters.AddWithValue("@x1", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
    '    '        '    cmst1.Parameters.Add(New SqlParameter("@x2", total_s)).DbType = DbType.Decimal
    '    '        '    cmst1.Parameters.Add(New SqlParameter("@x5", sum_irct)).DbType = DbType.Decimal

    '    '        '    cmst1.Transaction = Trans
    '    '        '    cmst1.ExecuteNonQuery()

    '    '        'End If


    '    '    Next


    '    '    '===============================
    '    '    Trans.Commit()
    '    '    MsgBox("حفظ اذن التالف", MsgBoxStyle.Information, " حفظ")

    '    'Catch err As System.Exception

    '    '    Trans.Rollback()
    '    '    MsgBox("لم يتم حفظ اذن التالف", MsgBoxStyle.Information, " حفظ")
    '    '    MsgBox(err.Message)

    '    'Finally
    '    'End Try











    '    ''End If

    '    'viwe()


    '    'Dim i, w As Integer
    '    ''Dim qt As Boolean

    '    'If cn.State = ConnectionState.Closed Then
    '    '    cn.Open()
    '    'End If
    '    'Dim sql As String = "select * from RcvSub where RcvSub.[no_c]='" + TextBox1.Text + "'"
    '    'Dim ad1 As New SqlDataAdapter(sql, cn)
    '    'Dim ds1 As New DataSet()
    '    'Dim TD1 As DataTable
    '    'Dim DROW1 As DataRow
    '    'Dim y As Decimal
    '    'y = 0.0
    '    'sum_irct = 0.0
    '    'ad1.Fill(ds1, sql)
    '    'TD1 = ds1.Tables(sql)

    '    'For i = 0 To TD1.Rows.Count - 1
    '    '    DROW1 = TD1.Rows(i)
    '    '    If DROW1("no_c") = (TextBox1.Text) Then

    '    '        y = Val(DROW1("qun_r"))
    '    '        sum_irct = sum_irct + y
    '    '    End If

    '    'Next
    '    'cn.Close()
    '    ''===============اجمالي المصروف==================

    '    'If cn.State = ConnectionState.Closed Then
    '    '    cn.Open()
    '    'End If
    '    'Dim sq3 As String = "select * from IsuSub where IsuSub.[no_c] ='" + TextBox1.Text + "'"

    '    'Dim ad3 As New SqlDataAdapter(sq3, cn)
    '    'Dim ds3 As New DataSet()
    '    'Dim TD3 As DataTable
    '    'Dim DROW3 As DataRow
    '    'Dim y2 As Decimal
    '    'Me.sum_iiss = 0.0
    '    'y2 = 0.0
    '    'ad3.Fill(ds3, sq3)
    '    'TD3 = ds3.Tables(sq3)

    '    'For w = 0 To TD3.Rows.Count - 1
    '    '    DROW3 = TD3.Rows(w)
    '    '    If DROW3("no_c") = (TextBox1.Text) Then

    '    '        y2 = Val(DROW3("qun_s"))
    '    '        sum_iiss = sum_iiss + y2

    '    '    End If
    '    'Next
    '    'cn.Close()
    '    ''===============اجمالي مرتجعه==================


    '    'If cn.State = ConnectionState.Closed Then
    '    '    cn.Open()
    '    'End If
    '    'Dim sq4 As String = "select * from matt_return where matt_return.[no_c] ='" + TextBox1.Text + "'"

    '    'Dim ad4 As New SqlDataAdapter(sq4, cn)
    '    'Dim ds4 As New DataSet()
    '    'Dim TD4 As DataTable
    '    'Dim DROW4 As DataRow
    '    'Dim y4 As Decimal
    '    ''Me.sum_iiss = 0
    '    'y4 = 0.0
    '    'ad4.Fill(ds4, sq4)
    '    'TD4 = ds4.Tables(sq4)

    '    'For w = 0 To TD4.Rows.Count - 1
    '    '    DROW4 = TD4.Rows(w)

    '    '    If DROW4("no_c") = (TextBox1.Text) Then

    '    '        y4 = Val(DROW4("qun_t"))
    '    '        sum_return = sum_return + y4

    '    '    End If
    '    'Next
    '    'cn.Close()
    '    ''===============تالف==================
    '    'If cn.State = ConnectionState.Closed Then
    '    '    cn.Open()
    '    'End If
    '    'Dim sq5 As String = "select * from sub_TALEF where sub_TALEF.[no_c] ='" + TextBox1.Text + "'"

    '    'Dim ad5 As New SqlDataAdapter(sq5, cn)
    '    'Dim ds5 As New DataSet()
    '    'Dim TD5 As DataTable
    '    'Dim DROW5 As DataRow
    '    'Dim y5 As Integer
    '    'sum_talf = 0
    '    'y5 = 0
    '    'ad5.Fill(ds5, sq5)
    '    'TD5 = ds5.Tables(sq5)

    '    'For w = 0 To TD5.Rows.Count - 1
    '    '    DROW5 = TD5.Rows(w)

    '    '    If DROW5("no_c") = (TextBox1.Text) Then

    '    '        y5 = Val(DROW5("qun_T"))
    '    '        sum_talf = sum_talf + y5

    '    '    End If
    '    'Next
    '    'cn.Close()
    '    'Me.total_s = 0


    '    'Me.total_s = ((sum_irct + sum_return) - sum_iiss) - sum_talf

    '    ''=======================================================
    '    ''stouck_matt()
    'End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        'date_1 = Date.Now
        'date_2 = "1990/01/01"
        'Dim dsm As New DataSet()

        'Dim sm As String = " SELECT no_c AS [رقم الصنف],sal_s AS [سعر الوحدة],date_end AS [تاريخ انتهاء الصلاحية],mdh AS [المدة],mdh_a as [نوع المدة],date_mdh as [تاريخ التنبيه],no_i as [رقم اذن الاستلام],date_i as [تاريخ اذن الاستلام] FROM salahia where state_sal=0 and date_end <= '" & date_1.ToString("yyyy/MM/dd") & "' and date_end <> '" & date_2.ToString("yyyy/MM/dd") & "'"
        'Dim adm As New SqlDataAdapter(sm, cn)
        ''ds.Clear()
        'adm.Fill(dsm, "salahia")
        'Me.DataGridViewX2.DataSource = dsm
        'Me.DataGridViewX2.DataMember = "salahia"
        'Me.DataGridViewX2.Refresh()

        '***************************
        If DataGridViewX2.RowCount = 0 Then
            MessageBox.Show("لاتوجد عناصر تم ادخالهاالي اذن الاستلام")
        End If


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
            MsgBox("حفظ اذن التالف", MsgBoxStyle.Information, " حفظ")
            sersch()
            viwe()





        Else

        End If
    End Sub

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

    Private Sub F_Told_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        auto_no()
        xl = l_p(Trim(TextBox1.Text))
        TextBox1.Text = xl
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub
End Class