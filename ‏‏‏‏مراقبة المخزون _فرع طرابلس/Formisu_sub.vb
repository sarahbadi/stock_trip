Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar

Public Class Formisu_sub
    Dim i As New Integer()
    Dim s11 As String = "select * from IsuMain"
    Dim adIs As New SqlDataAdapter(s11, cn)
    Dim dsIs As New DataSet()
    '=======================================
    Dim sj_s As String = "select * from j_s"
    Dim adaj_s As New SqlDataAdapter(sj_s, cn)
    Dim dsaj_s As New DataSet()


    Dim s22 As String = "select * from acthion_tran"
    Dim adact As New SqlDataAdapter(s22, cn)
    Dim dsact As New DataSet()
    '======================================

    Dim stran As String = "select * from tran_IRT"
    Dim adtran As New SqlDataAdapter(stran, cn)
    Dim dstran As New DataSet()
    '======================================
    Sub But_action_user()
        t_doc = "اذن الصرف"
        ts = TimeOfDay

        If cn.State = ConnectionState.Closed Then
            cn.Open()

        End If

        Dim s As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
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

      
        If Me.TextBox1.Text.ToString = "" Then
            MsgBox("أدخل رقم أذن الصرف ", MsgBoxStyle.Information, "إجراء إضافة")
            Exit Sub
        End If
        If Me.ComboBoxEx4.SelectedValue = -1 Or ComboBoxEx4.Text = "" Then
            MsgBox("اختار جهة الصرف ", MsgBoxStyle.Information, "إجراء إضافة")
            Exit Sub
        End If

        Dim s As String = "insert into IsuMain(no_s,date_s,j_s,total,u_name,tvg,dep_m,dep_mt,dep_nom,name_stock,name1_stock) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9,@x10,@x11)"
   
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
        cm.Parameters.Add(New SqlParameter("@x3", Me.ComboBoxEx4.SelectedValue))
        cm.Parameters.Add(New SqlParameter("@x4", 0))
        cm.Parameters.Add(New SqlParameter("@x5", ww))
        cm.Parameters.Add(New SqlParameter("@x6", TextBoxX3.Text))
        cm.Parameters.Add(New SqlParameter("@x7", False))
        cm.Parameters.Add(New SqlParameter("@x8", ""))
        cm.Parameters.Add(New SqlParameter("@x9", True))
        cm.Parameters.Add((New SqlParameter("@x10", TextBox2.Text)))
        cm.Parameters.Add((New SqlParameter("@x11", TextBox3.Text)))

        Try
            cm.ExecuteNonQuery()
            dsIs.Clear()
            adIs.Fill(dsIs, "IsuMain")
            MsgBox(" تم حفظ اذن الصرف ", MsgBoxStyle.Information, "حفظ")
            t_event = "حفظ"
            But_action_user()
            clearing()

        Catch
            MsgBox(" اذن الصرف موجود مسبقا", MsgBoxStyle.Critical, "تنبية")
            Exit Sub
        End Try
        auto_no()
    End Sub
    Sub clearing()
        Me.TextBox1.Clear()
        Me.DateTimePicker3.Value = Now
        Me.ComboBoxEx4.SelectedValue = -1
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBoxX3.Text = ""

        Me.TextBox4.Text = "0.000"
        Me.TextBoxX3.Text = "صفر دينار فقـط"


    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        Me.Dispose()
    End Sub
    Sub auto_no()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "select * from IsuMain where IsuMain.no_s=(select max(no_s) from IsuMain)"
        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "IsuMain")
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
    Private Sub Formisu_sub_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim mytext, datt As String

        'If sefa = "ادمن" Then
        '    Me.Button1.Enabled = True
        '    Me.Button1.Visible = True
        'End If

        'langarabic()

        'If branch = "فرع غرب بنغازي" Then

        '    l()
        'Else
        'auto_no()
        'datt = Now.Year
        'mytext = ((datt) + "0001")

        'If Me.TextBox1.Text = "0" Then
        '    Me.TextBox1.Text = ""
        '    TextBox1.Text = mytext
        'End If

        'End If



        auto_no()
        xl = l_p(Trim(TextBox1.Text))
        TextBox1.Text = xl
        langarabic()
        '=======================
        adaj_s.Fill(dsaj_s, "j_s")
        ComboBoxEx4.DataSource = dsaj_s
        ComboBoxEx4.DisplayMember = "j_s.name_s"
        ComboBoxEx4.ValueMember = "n_s"
        Me.DateTimePicker3.Value = Now
        Me.ComboBoxEx4.SelectedValue = -1



    End Sub
    Sub ser_amr()

        If (Me.TextBox1.Text.ToString) <> " " Then
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s11 As String = "SELECT * FROM IsuMain WHERE no_s=@x1"
            Dim cm As New SqlCommand(s11, cn)
            cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader

                If r.Read = True Then

                    Me.DateTimePicker3.Value = r!date_s
                    Me.ComboBoxEx4.SelectedValue = r!j_s
                    Me.TextBox4.Text = r!total
                    TextBox2.Text = r!name_stock.ToString
                    TextBox3.Text = r!name1_stock.ToString
                    r.Close()

                    If sefa = "مراقب المخزون" Or sefa = "ادمن" Then

                        Me.ButtonX1.Enabled = False
                        Me.ButtonX2.Enabled = True
                        Me.ButtonX3.Enabled = True
                    Else

                        Me.ButtonX1.Enabled = False
                        Me.ButtonX2.Enabled = True
                        Me.ButtonX3.Enabled = False
                    End If


                Else
                    'MsgBox(" اذن الصرف غير موجود ", MsgBoxStyle.Information, "تنبية")
                    Me.TextBox4.Text = "0.000"
                    Me.TextBoxX3.Text = "صفر دينار فقـط"
                    Me.TextBox2.Clear()
                    Me.TextBox3.Clear()
                    Me.DateTimePicker3.Value = Now
                    Me.ComboBoxEx4.SelectedValue = -1
                    Me.ButtonX1.Enabled = True
                    Me.ButtonX2.Enabled = False
                    Me.ButtonX3.Enabled = False
                    'clering_1()
                    r.Close()
                End If
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try

        End If
        cn.Close()

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

        If e.KeyCode = Keys.Enter Then

            If TextBox1.Text <> "" Then

                'xl = l_p(TextBox1.Text)
                'TextBox1.Text = xl
                ser_amr()
            Else
                Me.DateTimePicker3.Value = Now
                Me.ComboBoxEx4.SelectedValue = -1
            End If
        End If
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
    Sub total_no_s()


        Dim inf_t, y As Decimal
        inf_t = 0.0
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sql As String = "select * from IsuSub where  no_s='" + TextBox1.Text + "'"
        Dim ad1 As New SqlDataAdapter(sql, cn)
        Dim ds1 As New DataSet()
        Dim TD1 As DataTable
        Dim DROW1 As DataRow

        y = 0.0

        ad1.Fill(ds1, sql)
        TD1 = ds1.Tables(sql)

        For i = 0 To TD1.Rows.Count - 1
            DROW1 = TD1.Rows(i)
            If DROW1("no_s") = (TextBox1.Text) Then

                y = CDbl(DROW1("gema"))
                inf_t = CDbl(inf_t) + CDbl(y)
            End If

        Next


        '=============================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim ss As String = "update IsuMain set no_s=@x1,total=@x2,tvg=@x3 where no_s=@x1"
        Dim cms As New SqlCommand(ss, cn)
        cms.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cms.Parameters.Add(New SqlParameter("@x2", inf_t))
        cms.Parameters.Add(New SqlParameter("@x3", Me.TextBoxX3.Text))
        Try
            cms.ExecuteNonQuery()
            dsIs.Clear()
            adIs.Fill(dsIs, "IsuMain")
            cn.Close()
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try

    End Sub
    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If Me.TextBox1.Text = "" Then
            MsgBox(" ادخل رقم إذن الصرف")
            Exit Sub
        Else
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            '=============  
            Dim s As String = "update IsuMain set no_s=@x1,date_s=@x2,j_s=@x3,tvg=@x4,name_stock=@x5,name1_stock=@x6 where no_s=@x1"
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
            cm.Parameters.Add(New SqlParameter("@x3", Me.ComboBoxEx4.SelectedValue))
            cm.Parameters.Add(New SqlParameter("@x4", TextBoxX3.Text))
            cm.Parameters.Add(New SqlParameter("@x5", TextBox2.Text))
            cm.Parameters.Add(New SqlParameter("@x6", TextBox3.Text))
            Try
                cm.ExecuteNonQuery()
                dsIs.Clear()
                adIs.Fill(dsIs, "IsuMain")
                MsgBox("تم تعديل اذن الصرف ", MsgBoxStyle.Information, "تنبية")

                t_event = "تعديل"
                But_action_user()
                cn.Close()
                clearing()
            Catch ex As Exception

            End Try
            '---------------------------------
            't_event = " تعديل اذن الاستلام"
            'But_action_user()
            '----------------------------------
        End If
        auto_no()
    End Sub
    Sub delet_inf()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "delete from tran_IRT where n_rs=@x1 "
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))

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
        Dim s As String = "delete from acthion_tran where info=@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))

        Try
            cm.ExecuteNonQuery()
            dstran.Clear()
            adtran.Fill(dstran, "acthion_tran")
            cn.Close()
        Catch

        End Try
    End Sub
    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        If (Me.TextBox1.Text.ToString) <> " " Then
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s11 As String = "SELECT * FROM tran_IRT WHERE n_rs=@x1 and tr_type=@x2"
            Dim cm As New SqlCommand(s11, cn)
            cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
            cm.Parameters.Add(New SqlParameter("@x2", 3))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader

                If r.Read = True Then
                    MessageBoxEx.Show("لايمكن الحذف لانه تم الصرف منه", "v1مخازن", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    clearing()
                    Me.TextBoxX3.Clear()
                    Me.TextBox4.Clear()

                    Exit Sub

                    r.Close()
                Else

                    'MsgBox(" اذن الصرف غير موجود ", MsgBoxStyle.Critical, "تنبية")
                    Me.ButtonX1.Enabled = True
                    Me.ButtonX2.Enabled = False
                    Me.ButtonX3.Enabled = False
                    Me.TextBoxX3.Clear()
                    Me.TextBox4.Clear()

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
            Dim s As String = "SELECT * FROM IsuMain WHERE no_s=@x1 and date_s=@x2"
            Dim cm1 As New SqlCommand(s, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
            cm1.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
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
                Dim sd As String = "delete from IsuMain where no_s=@x1 and date_s=@x2"
                Dim cmd As New SqlCommand(sd, cn)
                cmd.Parameters.Add(New SqlParameter("@x1", Me.TextBox1.Text))
                cmd.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
                Try
                    If MsgBox("هل أنت متأكد من عملية حذفك لهذا الامر ؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then
                        cmd.ExecuteNonQuery()
                        dsIs.Clear()
                        adIs.Fill(dsIs, "IsuMain")
                        t_event = "حذف"
                        But_action_user()

                        delet_inf()
                        delet_inf_acthion_tran()
                        cn.Close()
                        clearing()
                    Else
                        Exit Sub
                        cn.Close()
                        clearing()
                    End If

                Catch

                End Try
            End If
        End If
        auto_no()
    End Sub

  

    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating

        If TextBox1.Text <> "" Then

            'xl = l_p(TextBox1.Text)
            'TextBox1.Text = xl
            ser_amr()
            total_no_s()
        Else
            Me.DateTimePicker3.Value = Now
            Me.ComboBoxEx4.SelectedValue = -1
        End If

    End Sub

  

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", "/", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

  

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Dim A As New NumberToWords
        Me.TextBoxX3.Text = (A.getWords(TextBox4.Text))
        Dim x As String

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim datt, mytext As String

        'y = Now.Year
        'es = (y + "" + "0001")

        datt = Now.Year
        mytext = ((datt) + "0001")
        TextBox1.Text = mytext



        Me.Button1.Visible = False
        Me.Button1.Enabled = False
    End Sub
End Class