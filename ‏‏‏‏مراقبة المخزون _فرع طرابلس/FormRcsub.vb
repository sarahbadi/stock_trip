
Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar

Public Class FormRcsub
    Dim i As New Integer()
    Dim move_no As String
    Dim tor As Boolean
    '===========================
    Dim s As String = "select * from j_r"
    Dim ada As New SqlDataAdapter(s, cn)
    Dim dsa As New DataSet()
    '======================================
    '===========================
    Dim s22 As String = "select * from acthion_tran"
    Dim adact As New SqlDataAdapter(s22, cn)
    Dim dsact As New DataSet()
    '======================================

    Dim stran As String = "select * from tran_IRT"
    Dim adtran As New SqlDataAdapter(stran, cn)
    Dim dstran As New DataSet()
    '======================================

    '===========================
    Dim s2 As String = "select * from RcvMain"
    Dim adRcvM As New SqlDataAdapter(s2, cn)
    Dim dsRcvM As New DataSet()
    '===========================
    Sub update_tran()
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
            ''MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
            'Exit Sub
        End Try

    End Sub
    Sub update_action()
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
            ''MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
            'Exit Sub
        End Try

        'End If

    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If Me.TextBoxX1.Text = "" Then
            MsgBox(" ادخل التكليف الاشاري")
            Exit Sub
        Else
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            '=============  
            Dim s As String = "update RcvMain set no_i=@x1,date_i=@x2,j_r=@x3,n_txt=@x4,n1_txt=@x5,name_stock=@x6 where no_i=@x1"
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
            cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
            cm.Parameters.Add(New SqlParameter("@x3", Me.ComboBoxEx3.SelectedValue))
            cm.Parameters.Add(New SqlParameter("@x4", TextBoxX1.Text))
            cm.Parameters.Add(New SqlParameter("@x5", TextBoxX2.Text))
            cm.Parameters.Add((New SqlParameter("@x6", TextBox2.Text)))
            Try
                cm.ExecuteNonQuery()
                dsRcvM.Clear()
                adRcvM.Fill(dsRcvM, "RcvMain")
                MsgBox("تم تعديل اذن الاستلام ", MsgBoxStyle.Information, "تنبية")

                t_event = "تعديل"
                But_action_user()
                cn.Close()
                update_action()
                update_tran()
                clearing()
            Catch ex As Exception

            End Try
            Me.TextBox8.Clear()

            auto_noc()
            ''---------------------------------
            't_event = " تعديل اذن الاستلام"
            'But_action_user()
            ''----------------------------------
        End If
    End Sub
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

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        '---------------------------------

        '----------------------------------
        Dim sst As String
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim sa As String = "select * from RcvSub where no_i=@x1"
        Dim cma As New SqlCommand(sa, cn)

        cma.Parameters.Add(New SqlParameter("@x1", (TextBox8.Text)))

        Dim r As SqlDataReader = cma.ExecuteReader
        If r.Read = True Then

            sst = r!txt_s
            r.Close()
        Else
            sst = ""
            r.Close()
        End If
        If sst = "تم اظافته كرصيد منقول" Then
            MsgBox("لايمكن حذف رقم الاستلام كرصيد منقول  ", MsgBoxStyle.SystemModal, "تنبية")
            Exit Sub
        End If

        '=========================
        If Me.TextBox8.Text = "" Then
            MsgBox(" ادخل رقم إذن استلام")
            Exit Sub
        Else
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim tr_t As Boolean

            Dim s1 As String = "select * from tran_IRT where n_rs=@x1 and date_i=@x2 and tr_type=@x3"
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
            cm1.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value, "yyyy/MM/dd")))
            cm1.Parameters.Add(New SqlParameter("@x3", 3))
            Try

                Dim r1 As SqlDataReader = cm1.ExecuteReader

                If r1.Read = True Then

                    tr_t = True
                    r1.Close()
                Else
                    r1.Close()
                    tr_t = False
                End If
            Catch

            End Try
            '==========================================
            If tr_t = False Then
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim s As String = "delete from RcvMain where no_i=@x1"
                Dim cm As New SqlCommand(s, cn)
                cm.Parameters.Add(New SqlParameter("@x1", Me.TextBox8.Text))

                If MsgBox("هل أنت متأكد من عملية حذفك لهذا الامر ؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then
                    cm.ExecuteNonQuery()
                    dsRcvM.Clear()
                    adRcvM.Fill(dsRcvM, "RcvMain")
                    cn.Close()
                    delet_inf()
                    delet_inf_acthion_tran()
                    t_event = "حذف"
                    But_action_user()
                    clearing()
                    'clearing()
                Else
                    MsgBox("لم تتم عملية الحذف ؟", MsgBoxStyle.Information, "تأكيد حذف")
                    Exit Sub
                End If
            Else
                messagee.ShowDialog()
                Exit Sub
            End If
        End If
        '===========================
        Me.TextBox8.Clear()
        auto_noc()
    End Sub

    Sub But_action_user()

        t_doc = "اذن الاستلام"
        ts = TimeOfDay

        If cn.State = ConnectionState.Closed Then
            cn.Open()

        End If

        Dim s As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
        cm.Parameters.Add(New SqlParameter("@x2", t_doc))
        cm.Parameters.Add(New SqlParameter("@x3", 0))
        cm.Parameters.Add(New SqlParameter("@x4", 0))
        cm.Parameters.Add(New SqlParameter("@x5", 0))
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
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        If Me.TextBox8.Text.ToString = "" Then
            MsgBox("أدخل رقم اذن الاستلام ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox8.Focus()
            Exit Sub
        End If

        If Me.ComboBoxEx3.SelectedIndex = -1 Then
            MsgBox("إختار أسم الجهة المستلمة", MsgBoxStyle.Information, "إجراء إضافة")
            ComboBoxEx3.Focus()
            Exit Sub
        End If
        If Me.ComboBoxEx3.SelectedIndex = -1 Then
            MsgBox(" اختار جهة التوريد", MsgBoxStyle.Information, "إجراء إضافة")
            ComboBoxEx3.Focus()
            Exit Sub
        End If
        If Me.TextBoxX1.Text.ToString = "" Then
            MsgBox("ادخل الاصناف واردة بموجب:  ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBoxX1.Focus()
            Exit Sub
        End If
        If cn.State = ConnectionState.Closed Then cn.Open()

        '===========================
        Dim s As String = "insert into RcvMain(no_i,date_i,j_r,n_txt,n1_txt,g_b,tvg,u_name,dep_m,dep_mt,dep_nom,name_stock) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9,@x10,@x11,@x12)"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
        cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
        cm.Parameters.Add(New SqlParameter("@x3", Me.ComboBoxEx3.SelectedValue))
        cm.Parameters.Add(New SqlParameter("@x4", TextBoxX1.Text))
        cm.Parameters.Add(New SqlParameter("@x5", TextBoxX2.Text))
        cm.Parameters.Add(New SqlParameter("@x6", 0))
        cm.Parameters.Add(New SqlParameter("@x7", TextBoxX3.Text))
        cm.Parameters.Add(New SqlParameter("@x8", ww))
        cm.Parameters.Add(New SqlParameter("@x9", False))
        cm.Parameters.Add(New SqlParameter("@x10", ""))
        cm.Parameters.Add(New SqlParameter("@x11", True))
        cm.Parameters.Add((New SqlParameter("@x12", TextBox2.Text)))
        Try
            cm.ExecuteNonQuery()
            dsRcvM.Clear()
            adRcvM.Fill(dsRcvM, "RcvMain")
            MsgBox("تم حفظ اذن الاستلام", MsgBoxStyle.Information, " حفظ")
            '---------------------------------
            t_event = "حفظ"
            But_action_user()
            '---------------------------------
            cn.Close()
            clearing()
            Me.TextBox8.Clear()
            'Catch

            '    MsgBox(" اذن الاستلام موجود مسبقا", MsgBoxStyle.Critical, "تنبية")
            '    Exit Sub
            'End Try


        Catch err As System.Exception
            MsgBox(err.Message)
        End Try

        auto_noc()
    End Sub

    Sub auto_nof()
        '"فرع"
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "select * from addr2 "
        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "addr2")
        tb = ds.Tables(0)
        Dim dr As DataRow
        Try
            dr = tb.Rows(0)
            Me.TextBox8.Text = dr(0) + 1
        Catch ex As Exception
            Me.TextBox8.Text = "0"

        End Try
        ad.Dispose()
        ds.Dispose()



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
        Catch ex As Exception
            Me.TextBox8.Text = "1"
        End Try
        ad.Dispose()
        ds.Dispose()



    End Sub
    Private Sub FormRcsub_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        langarabic()

        Dim mytext, datt As String

        'If sefa = "ادمن" Then
        '    Me.Button1.Enabled = True
        '    Me.Button1.Visible = True
        'End If

        'If branch = "فرع غرب بنغازي" Then
        '    auto_nof()

        '    l()
        'Else

        auto_noc()
        datt = Now.Year
        mytext = ((datt) + "0001")

        If Me.TextBox8.Text = "0" Then
            Me.TextBox8.Text = ""
            TextBox8.Text = mytext
        End If

        'End If

        ada.Fill(dsa, "j_r")
        Me.ComboBoxEx3.DataSource = dsa
        ComboBoxEx3.DisplayMember = "j_r.name_r"
        ComboBoxEx3.ValueMember = "no_r"
        Dim s As String = "SELECT name_r FROM j_r"
        Dim dsd As New DataSet
        Dim add = New SqlDataAdapter(s, cn)

        add.Fill(dsd, "name_r")
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        For i = 0 To dsd.Tables(0).Rows.Count - 1
            col.Add(dsd.Tables(0).Rows(i)("name_r").ToString())
        Next

        ComboBoxEx3.AutoCompleteCustomSource = col

        Me.ComboBoxEx3.SelectedValue = -1
        Me.ButtonX1.Enabled = False
        Me.ButtonX2.Enabled = False
        Me.ButtonX3.Enabled = False


    End Sub
    Sub clearing()
        TextBoxX1.Text = ""
        TextBox4.Text = 0
        TextBoxX2.Text = ""
        TextBox2.Text = ""
        Me.DateTimePicker1.Value = Now
        Me.ComboBoxEx3.SelectedValue = -1
        Me.TextBox4.Text = "0.000"
        Me.TextBoxX3.Text = "صفر دينار فقـط"
    End Sub
    'Sub total_inf()

    '    If (Me.TextBox8.Text) <> " " Then


    '        cn.Close()
    '        If cn.State = ConnectionState.Closed Then
    '            cn.Open()
    '        End If

    '        Dim s11 As String = "SELECT * FROM RcvMain WHERE no_i=@x1"
    '        Dim cm As New SqlCommand(s11, cn)
    '        cm.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
    '        Try
    '            Dim r As SqlDataReader = cm.ExecuteReader

    '            If r.Read = True Then
    '                'clering_1()

    '                TextBoxX1.Text = r!n_txt.ToString
    '                TextBoxX2.Text = r!n1_txt.ToString
    '                Me.DateTimePicker1.Value = r!date_i
    '                Me.ComboBoxEx3.SelectedValue = r!j_r
    '                TextBox2.Text = r!name_stock.ToString
    '                'Me.Button2.Enabled = True
    '                'Me.DataGridViewX2.Enabled = True
    '                tor = True


    '                If sefa = "مراقب المخزون" Then

    '                    Me.ButtonX1.Enabled = False
    '                    Me.ButtonX2.Enabled = True
    '                    Me.ButtonX3.Enabled = True
    '                Else

    '                    Me.ButtonX1.Enabled = False
    '                    Me.ButtonX2.Enabled = True
    '                    Me.ButtonX3.Enabled = False
    '                End If

    '                r.Close()



    '            Else
    '                'Me.DateTimePicker1.Value = Now
    '                'Me.ComboBoxEx3.SelectedValue = -1
    '                'TextBoxX1.Text = ""
    '                'Me.Button1.Enabled = False
    '                'Me.Button2.Enabled = False
    '                'Me.TextBoxX6.Text = ""
    '                'Me.DataGridViewX2.Enabled = False
    '                MsgBox(" اذن الاستلام غير موجود ", MsgBoxStyle.Critical, "تنبية")

    '                Me.ButtonX1.Enabled = True
    '                Me.ButtonX2.Enabled = False
    '                Me.ButtonX3.Enabled = False



    '                tor = False
    '                clearing()
    '                r.Close()
    '            End If


    '        Catch err As System.Exception
    '            MsgBox(err.Message)
    '        End Try

    '        '============================

    '        If cn.State = ConnectionState.Closed Then
    '            cn.Open()
    '        End If


    '        '==================================
    '        Dim inf_t, y As Decimal
    '        inf_t = 0.0
    '        If cn.State = ConnectionState.Closed Then
    '            cn.Open()
    '        End If
    '        Dim sql As String = "select * from RcvSub where no_i ='" + TextBox8.Text + "'"
    '        Dim ad1 As New SqlDataAdapter(sql, cn)
    '        Dim ds1 As New DataSet()
    '        Dim TD1 As DataTable
    '        Dim DROW1 As DataRow

    '        y = 0.0

    '        ad1.Fill(ds1, sql)
    '        TD1 = ds1.Tables(sql)

    '        For i = 0 To TD1.Rows.Count - 1
    '            DROW1 = TD1.Rows(i)
    '            If DROW1("no_i") = (TextBox8.Text) Then

    '                y = CDbl(DROW1("gema"))
    '                inf_t = CDbl(inf_t) + CDbl(y)
    '            End If

    '        Next
    '        Me.TextBox4.Text = CDbl(inf_t)


    '        '=============================
    '        If cn.State = ConnectionState.Closed Then
    '            cn.Open()
    '        End If

    '        Dim ss As String = "update RcvMain set no_i=@x1,g_b=@x2,tvg=@x3 where no_i=@x1"
    '        Dim cms As New SqlCommand(ss, cn)
    '        cms.Parameters.Add((New SqlParameter("@x1", TextBox8.Text)))
    '        cms.Parameters.Add(New SqlParameter("@x2", TextBox4.Text))
    '        cms.Parameters.Add(New SqlParameter("@x3", TextBoxX3.Text))
    '        Try
    '            cms.ExecuteNonQuery()
    '            dsRcvM.Clear()
    '            adRcvM.Fill(dsRcvM, "RcvMain")
    '            cn.Close()
    '        Catch err As System.Exception
    '            MsgBox(err.Message)
    '        End Try
    '    End If
    '    '===========================================
    'End Sub
    Sub total_inf()

        If (Me.TextBox8.Text) <> " " Then



            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s11 As String = "SELECT * FROM RcvMain WHERE no_i=@x1"
            Dim cm As New SqlCommand(s11, cn)
            cm.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader

                If r.Read = True Then
                    'clering_1()

                    TextBoxX1.Text = r!n_txt.ToString
                    TextBoxX2.Text = r!n1_txt.ToString
                    Me.DateTimePicker1.Value = r!date_i
                    Me.ComboBoxEx3.SelectedValue = r!j_r
                    TextBox2.Text = r!name_stock.ToString
                  
                    tor = True


                    If sefa = "مراقب المخزون" Then

                        Me.ButtonX1.Enabled = False
                        Me.ButtonX2.Enabled = True
                        Me.ButtonX3.Enabled = True
                    Else

                        Me.ButtonX1.Enabled = False
                        Me.ButtonX2.Enabled = True
                        Me.ButtonX3.Enabled = False
                    End If

                    r.Close()



                Else
                    
                    MsgBox(" اذن الاستلام غير موجود ", MsgBoxStyle.Critical, "تنبية")
                    Me.TextBox4.Text = "0.000"
                    Me.TextBoxX3.Text = "صفر دينار فقـط"
                    Me.ButtonX1.Enabled = True
                    Me.ButtonX2.Enabled = False
                    Me.ButtonX3.Enabled = False



                    tor = False
                    clearing()
                    r.Close()
                End If


            Catch err As System.Exception
                MsgBox(err.Message)
            End Try

            '============================

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If


            '==================================
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
            Me.TextBox4.Text = CDbl(inf_t)


            '=============================
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim ss As String = "update RcvMain set no_i=@x1,g_b=@x2,tvg=@x3 where no_i=@x1"
            Dim cms As New SqlCommand(ss, cn)
            cms.Parameters.Add((New SqlParameter("@x1", TextBox8.Text)))
            cms.Parameters.Add(New SqlParameter("@x2", TextBox4.Text))
            cms.Parameters.Add(New SqlParameter("@x3", TextBoxX3.Text))
            Try
                cms.ExecuteNonQuery()
                dsRcvM.Clear()
                adRcvM.Fill(dsRcvM, "RcvMain")
                cn.Close()
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try
        End If
        '===========================================
    End Sub
    Private Sub TextBox8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox8.Text <> "" Then

                total_inf()

            Else
                clearing()
            End If
          
        End If
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        Me.Dispose()
    End Sub

    Function man14(ByVal Text1 As String) As String
        Dim a(100) As String
        Dim i, j As Integer
        'Dim nm As String
        Me.TextBox4.Text = Trim(Me.TextBox4.Text)
        Dim a1 As String
        a1 = Me.TextBox4.Text.ToString
        For i = 1 To Len(Text1)
            If (Mid(Me.TextBox4.Text, i, 1) = ".") Then
                Exit For
            End If
            If i = Len(Text1) Then
                If (Mid(Me.TextBox4.Text, i, 1) <> ".") Then
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
        Me.TextBox4.Text = Trim(a1)
        man14 = Me.TextBox4.Text
    End Function
    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Dim A As New NumberToWords
        Me.TextBoxX3.Text = (A.getWords(Me.TextBox4.Text))
        Dim x As String
        x = man14(TextBox4.Text)
    End Sub

    Private Sub TextBoxX1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX1.TextChanged

    End Sub


    Private Sub TextBox8_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox8.Validating

        If TextBox8.Text <> "" Then

            total_inf()

        Else
            clearing()
        End If

    End Sub
    Sub l()
        Dim a As Integer
        a = Len(TextBox8.Text)
        If a = 1 Then
            Me.TextBox8.Text = ("000000" + Me.TextBox8.Text)
        End If
        If a = 2 Then
            Me.TextBox8.Text = ("00000" + Me.TextBox8.Text)
        End If
        If a = 3 Then
            Me.TextBox8.Text = ("0000" + Me.TextBox8.Text)
        End If
        If a = 4 Then
            Me.TextBox8.Text = ("000" + Me.TextBox8.Text)
        End If
        If a = 5 Then
            Me.TextBox8.Text = ("00" + Me.TextBox8.Text)
        End If
        If a = 6 Then
            Me.TextBox8.Text = ("0" + Me.TextBox8.Text)
        End If
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

    Private Sub PanelEx1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBoxX3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX3.TextChanged

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub TextBoxX4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBoxX4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim FirstName, MiddleName, LastName, a As String

        Dim NameCopied As String = String.Copy(TextBoxX2.Text)

        'Clipboard.SetText(Label1.Text)
        'TextBoxX1.Text = Label1.Text + " " + TextBoxX2.Text + " " + Label2.Text + " " + TextBoxX4.Text
        FirstName = Label1.Text
        MiddleName = TextBoxX2.Text
        LastName = Label2.Text
        'a = TextBoxX4.Text
        Dim FullName As String = FirstName & " " & NameCopied & " " & LastName
        '= String.Concat(FirstName, " ", MiddleName, " ", LastName, " ", a)
        'MsgBox(FullName)
        TextBoxX1.Text = FullName
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim datt, mytext As String

        'y = Now.Year
        'es = (y + "" + "0001")

        datt = Now.Year
        mytext = ((datt) + "000001")
        TextBox8.Text = mytext


        Me.Button1.Enabled = False

        Me.Button1.Visible = False

     
    End Sub
End Class