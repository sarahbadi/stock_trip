Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Public Class Form_infbuy
    Dim g As String
    Dim f As Boolean
    Dim f1 As Boolean
    Dim move_no As String
    Dim sum_irct, sum_iiss, total_s As New Decimal
    Dim i, p, w, no As New Integer()
    '====================
    Dim ww As Boolean

    Private a1 As Date
    Private a2 As Integer
    Private a3 As Decimal
    Dim chek, tr_t As Boolean
    Dim n1 As String

    '================================
    Dim scl As String = "select * from cls"
    Dim adcl As New SqlDataAdapter(scl, cn)
    Dim dscl As New DataSet()
    '====================================
    Dim sj_s As String = "select * from j_s"
    Dim adaj_s As New SqlDataAdapter(sj_s, cn)
    Dim dsaj_s As New DataSet()

    Dim s11 As String = "select * from   subi_nbay"
    Dim ad11 As New SqlDataAdapter(s11, cn)
    Dim ds11 As New DataSet()

    '======================================

    Dim s1 As String = "select * from in_bay"
    Dim ad1 As New SqlDataAdapter(s1, cn)
    Dim ds1 As New DataSet()

    Dim sm As String = "select * from matt"
    Dim adm As New SqlDataAdapter(sm, cn)
    Dim dsm As New DataSet()
    Dim TDm As DataTable
    '======================================

    Sub clearing()
        Me.TextBoxX2.Clear()
        Me.TextBoxX3.Clear()
        Me.TextBoxX4.Clear()
        Me.TextBoxX5.Clear()

        Me.TextBoxX7.Clear()


        Me.LabelX2.Text = 0
    End Sub
    Sub clearingf()

        Me.TextBoxX6.Clear()
        Me.TextBoxX8.Clear()
        Me.TextBoxX9.Clear()

        RadioButton1.Checked = False
        Me.RadioButton2.Checked = False
        Me.RadioButton3.Checked = False

        DateTimePicker3.Value = (Format(Date.Now, "yyyy/MM/dd"))
        Me.LabelX2.Text = 0
    End Sub
    '=====================الرصيد===========
    Sub stouck()



        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "select * from matt where no_c=@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", (TextBoxX2.Text)))
        Try

            Dim r As SqlDataReader = cm.ExecuteReader

            If r.Read = True Then

                TextBoxX3.Text = r!name_snc
                Me.ComboBoxEx1.SelectedValue = r!c_type
                TextBoxX5.Text = r!balance

                'ComboBoxEx4.Enabled = False
                'Me.DateTimePicker3.Enabled = False
                r.Close()
            Else
                r.Close()

                'ComboBoxEx4.Enabled = True
                'Me.DateTimePicker3.Enabled = True
                'MsgBox("هذا الصنف لم يتم تعريفة بعد", MsgBoxStyle.OkOnly, "تنبية")
                clearing()
                r.Close()
            End If

        Catch
            MsgBox("يوجد خطاءفي بيانات المواد", MsgBoxStyle.Critical, "تنبية")
        End Try

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Me.TextBox1.Text <> " " Then

            Dim dt2 As DataTable

            Dim sql1, n1 As String
            n1 = TextBox1.Text
            If n1 = "" Then

                Exit Sub
            Else


                'Dim s As String = "select * from f_ar WHERE f_ar.date_f like  " + "'" + Me.DateTimePicker1.Value.Date + "%" + "' And f_ar.no_f = " & Me.TextBox6.Text & ""
                sql1 = "SELECT * from inbay WHERE  inbay.n_t= " & Me.TextBox1.Text & ""
                Dim da8 As New SqlDataAdapter(sql1, cn)
                Dim ds8 As New DataSet
                ds8.Clear()
                da8.Fill(ds8, "inbay")
                dt2 = ds8.Tables("inbay")
                If dt2.Rows.Count > 0 Then

                End If
                ListView1.Clear()
                Dim dr2 As DataRow


                ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
                ListView1.Columns.Add("اسم الصنف", 350, HorizontalAlignment.Left)
                ListView1.Columns.Add("الكميه", 90, HorizontalAlignment.Center)
                ListView1.Columns.Add("الوحدة", 87, HorizontalAlignment.Center)
                ListView1.Columns.Add("العبوة", 87, HorizontalAlignment.Center)
                ListView1.Columns.Add("رصيد المخزن", 150, HorizontalAlignment.Center)
                Dim sdl As Short = 1
                ListView1.Items.Clear()
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
                    litem.SubItems.Add(dt2.Rows(i).Item("name_snc"))
                    litem.SubItems.Add(dt2.Rows(i).Item("qun_s"))
                    litem.SubItems.Add(dt2.Rows(i).Item("name_type"))
                    litem.SubItems.Add(dt2.Rows(i).Item("state"))
                    litem.SubItems.Add(dt2.Rows(i).Item("balance"))


                    ListView1.Items.Add(litem)
                Next i

                ListView1.View = View.Details
            End If

            stouck()
            'Me.Button1.Enabled = True
            'Me.Button2.Enabled = True
            ''Me.Button3.Enabled = True
        Else
            'Me.Button1.Enabled = False
            'Me.Button2.Enabled = False
            ''Me.Button3.Enabled = False
            Exit Sub
        End If



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub
    Sub f_a()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "SELECT * from in_bay where n_t=@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add("@x1", TextBox1.Text)

        Try
            Dim r13 As SqlDataReader = cm.ExecuteReader
            If r13.Read = True Then

                Me.TextBoxX6.Text = r13!name1
                Me.DateTimePicker3.Value = r13!date_f
                RadioButton1.Checked = r13!n
                Me.RadioButton2.Checked = r13!m
                Me.RadioButton3.Checked = r13!md
                Me.TextBoxX8.Text = r13!kart
                Me.TextBoxX9.Text = r13!mda
                ww = True


                r13.Close()

            Else
                ww = False


                r13.Close()
            End If

        Catch err As System.Exception
            MsgBox(err.Message)
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ListView1.Items.Clear()

        Dim s As String = "delete from in_bay where n_t=@x1"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add("@x1", TextBox1.Text)
        'If MsgBox("هل أنت متأكد من عملية حدفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then

        Try
            cm.ExecuteNonQuery()
            ds1.Clear()
            ad1.Fill(ds1, "in_bay")
        Catch
            MsgBox("لايمـكـن الـحـذ ف", MsgBoxStyle.SystemModal, "تنبية")
        End Try
    End Sub

    Private Sub TextBoxX2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxX2.Leave
        stouck()
    End Sub

    Private Sub TextBoxX2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX2.TextChanged

    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        Dim litem As ListViewItem
        Dim i As Integer
        For Each litem In ListView1.SelectedItems
            Me.TextBoxX2.Text = litem.SubItems(0).Text
            TextBoxX3.Text = litem.SubItems(1).Text
            TextBoxX4.Text = litem.SubItems(2).Text
            Me.ComboBoxEx1.Text = litem.SubItems(3).Text
            TextBoxX7.Text = litem.SubItems(4).Text
            TextBoxX5.Text = litem.SubItems(5).Text

        Next

        Me.ButtonX5.Enabled = True
        Me.ButtonX6.Enabled = True
        Me.ButtonX1.Enabled = True

        Me.ButtonX4.Enabled = True

    End Sub

  

    'Private Sub TextBoxX1_Leave(ByVal sender As Object, ByVal e As System.EventArgs)




    '    If Me.TextBoxX1.Text <> " " Then
    '        f_a()

    '        If ww = True Then
    '            Button5_Click(sender, e)
    '            'MsgBox("تم حفظ الفاتورة من قبل")
    '        Else

    '            'MsgBox("لم يتم حفظ الفاتورة")
    '            Me.ListView1.Clear()
    '            ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
    '            ListView1.Columns.Add("اسم الصنف", 350, HorizontalAlignment.Left)
    '            ListView1.Columns.Add("الكميه", 90, HorizontalAlignment.Center)
    '            ListView1.Columns.Add("الوحدة", 87, HorizontalAlignment.Center)
    '            ListView1.Columns.Add("العبوة", 87, HorizontalAlignment.Center)
    '            ListView1.Columns.Add("رصيد المخزن", 150, HorizontalAlignment.Center)
    '            ListView1.Columns.Add("", 0, HorizontalAlignment.Center)
    '            clearing()
    '            clearingf()
    '            TextBoxX2.Focus()
    '        End If


    '    Else
    '        Exit Sub
    '    End If




    'End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Sub s_add()
        Dim s As String = "select * from in_bay where n_t=(select max(n_t) from in_bay)"
        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "in_bay")
        tb = ds.Tables(0)
        Dim dr As DataRow
        Try
            dr = tb.Rows(0)
            Me.TextBox1.Text = dr(0) + 1
            'Me.TextBoxX1.Text = Me.TextBoxX1.Text
        Catch ex As Exception
            Me.TextBox1.Text = "1"
        End Try

        ad.Dispose()
        ds.Dispose()



    End Sub

    'Sub l()
    '    Dim a As Integer
    '    a = Len(TextBoxX1.Text)
    '    If a = 1 Then
    '        Me.TextBoxX1.Text = ("000000" + Me.TextBoxX1.Text)
    '    End If
    '    If a = 2 Then
    '        Me.TextBoxX1.Text = ("00000" + Me.TextBoxX1.Text)
    '    End If
    '    If a = 3 Then
    '        Me.TextBoxX1.Text = ("0000" + Me.TextBoxX1.Text)
    '    End If
    '    If a = 4 Then
    '        Me.TextBoxX1.Text = ("000" + Me.TextBoxX1.Text)
    '    End If
    '    If a = 5 Then
    '        Me.TextBoxX1.Text = ("00" + Me.TextBoxX1.Text)
    '    End If
    '    If a = 6 Then
    '        Me.TextBoxX1.Text = ("0" + Me.TextBoxX1.Text)
    '    End If
    'End Sub

    Private Sub Form_infbuy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        s_add()
        xl = l_p(TextBox1.Text)
        TextBox1.Text = xl

        'TextBox1.Focus()


        ListView1.View = View.Details
        langarabic()


        Me.TextBoxX7.Text = 0
        '=======================
        'adaj_s.Fill(dsaj_s, "j_s")
        'ComboBoxEx4.DataSource = dsaj_s
        'ComboBoxEx4.DisplayMember = "j_s.name_s"
        'ComboBoxEx4.ValueMember = "n_s"
        '=================================

        adcl.Fill(dscl, "cls")
        ComboBoxEx1.DataSource = dscl
        ComboBoxEx1.DisplayMember = "cls.name_type"
        ComboBoxEx1.ValueMember = "no_type"

        ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("اسم الصنف", 350, HorizontalAlignment.Left)
        ListView1.Columns.Add("الكميه", 90, HorizontalAlignment.Center)
        ListView1.Columns.Add("الوحدة", 87, HorizontalAlignment.Center)
        ListView1.Columns.Add("العبوة", 87, HorizontalAlignment.Center)
        ListView1.Columns.Add("رصيد المخزن", 150, HorizontalAlignment.Center)
        Me.ButtonX4.Enabled = False
        Me.ButtonX1.Enabled = False
        'ComboBoxEx4.SelectedIndex = -1
        'ComboBoxEx1.SelectedIndex = -1
    End Sub

   

    Private Sub TextBoxX4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX4.KeyPress
        secu_num(e)
    End Sub

  
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        '    If Me.RadioButton4.Checked = False And Me.RadioButton5.Checked = False And Me.RadioButton8.Checked = False Then
        '        MsgBox("عفواً..يجب أن تختار طريقة الدفع ", MsgBoxStyle.Information, "تنبيه")

        '        Exit Sub
        '    End If
        Dim s As String = "update  in_bay set n_t=@x1,date_f=@x2,kart=@x3,name1=@x4,mda=@x5,n=@x6,m=@x7,md=@x8 where n_t=@x1 and date_f=@x2"
        Dim cm As New SqlCommand(s, cn)

        Try



            cm.Parameters.Add("@x1", TextBox1.Text)
            cm.Parameters.Add("@x2", Me.DateTimePicker3.Value)
            cm.Parameters.Add("@x3", Me.TextBoxX8.Text)
            cm.Parameters.Add("@x4", Me.TextBoxX6.Text)
            cm.Parameters.Add("@x5", Me.TextBoxX9.Text)
            cm.Parameters.Add("@x6", RadioButton1.Checked)
            cm.Parameters.Add("@x7", Me.RadioButton2.Checked)
            cm.Parameters.Add("@x8", Me.RadioButton3.Checked)



            cm.ExecuteNonQuery()
            ds1.Clear()
            ad1.Fill(ds1, "in_bay")
            MsgBox("تم التعديل", MsgBoxStyle.Information, "تنبية")

        Catch err As System.Exception
            MsgBox(err.Message)
        End Try
        'Me.Dispose()

    End Sub

   

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim litem As ListViewItem
        Dim i As Integer
        For Each litem In ListView1.SelectedItems
            Me.TextBoxX2.Text = litem.SubItems(0).Text
            TextBoxX3.Text = litem.SubItems(1).Text
            TextBoxX4.Text = litem.SubItems(2).Text
            Me.ComboBoxEx1.Text = litem.SubItems(3).Text
            TextBoxX7.Text = litem.SubItems(4).Text
            TextBoxX5.Text = litem.SubItems(5).Text

        Next
        Me.ButtonX5.Enabled = True
        Me.ButtonX6.Enabled = True
        Me.ButtonX1.Enabled = True


        Me.ButtonX4.Enabled = True
        'Me.ButtonX1.Enabled = False
    End Sub

 

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "update  in_bay set n_t=@x1,date_f=@x2,kart=@x3,name1=@x4,mda=@x5,n=@x6,m=@x7,md=@x8 where n_t=@x1"
        Dim cm As New SqlCommand(s, cn)

        Try

            cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))

            cm.Parameters.Add(New SqlParameter("@x3", Me.TextBoxX8.Text))
            cm.Parameters.Add(New SqlParameter("@x4", Me.TextBoxX6.Text))
            cm.Parameters.Add(New SqlParameter("@x5", Me.TextBoxX9.Text))
            cm.Parameters.Add(New SqlParameter("@x6", RadioButton1.Checked))
            cm.Parameters.Add(New SqlParameter("@x7", Me.RadioButton2.Checked))
            cm.Parameters.Add(New SqlParameter("@x8", Me.RadioButton3.Checked))

            cm.ExecuteNonQuery()
            ds1.Clear()
            ad1.Fill(ds1, "in_bay")
            MsgBox("تم التعديل", MsgBoxStyle.Information, "تنبية")
            clearing()
            Me.ListView1.Clear()
            Button5_Click(sender, e)
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try

    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        ListView1.Items.Clear()

        Dim s As String = "delete from in_bay where n_t=@x1"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        If MsgBox("هل أنت متأكد من عملية حذفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then



            Try
                cm.ExecuteNonQuery()
                ds1.Clear()
                ad1.Fill(ds1, "in_bay")
                'clearingf()
                'Me.ListView1.Clear()
                'Button5_Click(sender, e)

            Catch
                'MsgBox("لايمـكـن الـحـذف", MsgBoxStyle.SystemModal, "تنبية")
            End Try

            cn.Close()

            '==============================================
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If



            Dim sv As String = "delete from subi_nbay where n_t=@x1"
            Dim cmv As New SqlCommand(sv, cn)
            cmv.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            'If MsgBox("هل أنت متأكد من عملية حدفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then

            Try
                cmv.ExecuteNonQuery()
                ds11.Clear()
                ad11.Fill(ds11, "subi_nbay")

            Catch
                'MsgBox("لايمـكـن الـحـد ف", MsgBoxStyle.SystemModal, "تنبية")
            End Try
            clearing()
            clearingf()
            TextBox1.Clear()
            Me.ListView1.Clear()
            s_add()
            xl = l_p(TextBox1.Text)
            TextBox1.Text = xl
        Else
            Exit Sub
        End If
        'Button5_Click(sender, e)
    End Sub

    Private Sub TextBoxX7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX7.KeyPress
        secu_num(e)
    End Sub

   

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click

        If Me.TextBox1.Text <> "" Then



            If TextBoxX2.Text = "" Then
                MsgBox("عفواً..يجب أن تدخل  رقم الصنف ", MsgBoxStyle.Information, "تنبيه")
                TextBoxX2.Focus()
                Exit Sub
            End If
            If Me.RadioButton1.Checked = False And Me.RadioButton2.Checked = False And Me.RadioButton3.Checked = False Then
                MsgBox("عفواً..يجب أن تختارحالة الطلب ", MsgBoxStyle.Information, "تنبيه")
                Exit Sub
            End If

            If TextBoxX7.Text = "" Then
                MsgBox(" عفواً..يجب أن تدخل العبوة ", MsgBoxStyle.Information, "إجراء إضافة")
                TextBoxX7.Focus()
                Exit Sub
            End If

            If TextBoxX9.Text = "" Then
                MsgBox(" عفواً..يجب أن تدخل  المدة ", MsgBoxStyle.Information, "إجراء إضافة")
                TextBoxX9.Focus()
                Exit Sub
            End If
            If TextBoxX4.Text = "" Then
                MsgBox("عفواً..يجب أن تدخل  الكمية ", MsgBoxStyle.Information, "تنبيه")
                TextBoxX4.Focus()
                Exit Sub
            End If


            If Me.TextBoxX6.Text = "" Then
                MsgBox("عفواً..يجب أن تدخل  اسم الاخ ", MsgBoxStyle.Information, "تنبيه")
                TextBoxX6.Focus()
                Exit Sub
            End If
            If Me.TextBoxX8.Text = "" Then
                MsgBox("عفواً..يجب أن تدخل  الغرض ", MsgBoxStyle.Information, "تنبيه")
                TextBoxX6.Focus()
                Exit Sub
            End If

            f_a()


            If ww = True Then

                If cn.State = ConnectionState.Closed Then
                    cn.Open()

                End If



                Dim sm As String = "insert into subi_nbay(n_t,no_c,qun_s,balance,state) values (@x1,@x2,@x3,@x4,@x5)"
                Dim cm1 As New SqlCommand(sm, cn)

                cm1.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cm1.Parameters.Add(New SqlParameter("@x2", TextBoxX2.Text))
                cm1.Parameters.Add(New SqlParameter("@x3", CDec(TextBoxX4.Text)))
                cm1.Parameters.Add(New SqlParameter("@x4", CDec(TextBoxX5.Text)))
                cm1.Parameters.Add(New SqlParameter("@x5", TextBoxX7.Text))

                Try
                    cm1.ExecuteNonQuery()
                    ds11.Clear()
                    ad11.Fill(ds11, "subi_nbay")
                    clearing()
                    Me.ListView1.Clear()
                    Button5_Click(sender, e)
                    cn.Close()
                Catch
                    MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
                    Exit Sub
                    cn.Close()
                End Try
                cn.Close()
            Else


                If cn.State = ConnectionState.Closed Then
                    cn.Open()

                End If

                Dim s As String = "insert into in_bay(n_t,date_f,kart,name1,mda,n,m,md) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8)"
                Dim cm As New SqlCommand(s, cn)
                cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
                cm.Parameters.Add(New SqlParameter("@x3", TextBoxX8.Text))
                cm.Parameters.Add(New SqlParameter("@x4", Me.TextBoxX6.Text))
                cm.Parameters.Add(New SqlParameter("@x5", TextBoxX9.Text))
                cm.Parameters.Add(New SqlParameter("@x6", Me.RadioButton1.Checked))
                cm.Parameters.Add(New SqlParameter("@x7", Me.RadioButton2.Checked))
                cm.Parameters.Add(New SqlParameter("@x8", Me.RadioButton3.Checked))
                Try
                    cm.ExecuteNonQuery()
                    ds1.Clear()
                    ad1.Fill(ds1, "in_bay")
                    'clearing()
                    Me.ListView1.Clear()
                    Button5_Click(sender, e)
                    cn.Close()
                Catch
                    MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
                    cn.Close()
                    Exit Sub
                End Try
                cn.Close()

                If cn.State = ConnectionState.Closed Then
                    cn.Open()

                End If


                Dim sm As String = "insert into subi_nbay(n_t,no_c,qun_s,balance,state) values (@x1,@x2,@x3,@x4,@x5)"
                Dim cm1 As New SqlCommand(sm, cn)

                cm1.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cm1.Parameters.Add(New SqlParameter("@x2", TextBoxX2.Text))
                cm1.Parameters.Add(New SqlParameter("@x3", CDec(TextBoxX4.Text)))
                cm1.Parameters.Add(New SqlParameter("@x4", CDec(TextBoxX5.Text)))
                cm1.Parameters.Add(New SqlParameter("@x5", TextBoxX7.Text))

                Try
                    cm1.ExecuteNonQuery()
                    ds11.Clear()
                    ad11.Fill(ds11, "subi_nbay")
                    clearing()
                    Me.ListView1.Clear()
                    Button5_Click(sender, e)
                    cn.Close()
                Catch
                    MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
                    cn.Close()
                    Exit Sub
                End Try


            End If
        Else
            cn.Close()
            Exit Sub
        End If

    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click


        If (ListView1.SelectedItems.Count = 0) Then

            MessageBox.Show("لاتوجد عناصر تم اختارها")

            Exit Sub

        Else

            If cn.State = ConnectionState.Closed Then
                cn.Open()

            End If


            Dim s As String = "update  subi_nbay set n_t=@x1,no_c=@x3,qun_s=@x4,state=@x5 where n_t=@x1 and no_c=@x3 "
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cm.Parameters.Add(New SqlParameter("@x3", TextBoxX2.Text))
            cm.Parameters.Add(New SqlParameter("@x4", CDec(TextBoxX4.Text)))
            cm.Parameters.Add(New SqlParameter("@x5", TextBoxX7.Text))
            Try

                cm.ExecuteNonQuery()

                ds11.Clear()
                ad11.Fill(ds11, " subi_nbay")

                MsgBox("تم التعديل", MsgBoxStyle.Information, "تنبية")
                Button5_Click(sender, e)
            Catch
                MsgBox("لايمكنك التعديل في رقم الصنف ورقم الاذن وتاريخ الاذن ", MsgBoxStyle.Information, "تنبية")
            End Try
        End If

        Me.ButtonX1.Enabled = False


    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click




        If cn.State = ConnectionState.Closed Then
            cn.Open()

        End If


        If (ListView1.SelectedItems.Count = 0) Then
            MessageBox.Show("لاتوجد عناصر تم اختارها")

            Exit Sub

        Else
            ListView1.Items.RemoveAt(ListView1.FocusedItem.Index)


            Dim s As String = "delete from subi_nbay where no_c=@x1"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add("@x1", TextBoxX2.Text)
            'If MsgBox("هل أنت متأكد من عملية حدفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then

            Try
                cm.ExecuteNonQuery()
                ds11.Clear()
                ad11.Fill(ds11, "subi_nbay")
                TextBoxX2_Leave(sender, e)
            Catch
                MsgBox("لايمـكـن الـحـذ ف", MsgBoxStyle.SystemModal, "تنبية")
            End Try
        End If
        'ListView1.Clear()
        'clearing()
        Me.ButtonX4.Enabled = False

    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click

        clearing()
        clearingf()
        s_add()
        Me.ListView1.Clear()


        TextBox1.Focus()
        Me.ListView1.Clear()
        ListView1.View = View.Details
        DateTimePicker3.Value = (Format(Date.Now, "yyyy/MM/dd"))
        ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("اسم الصنف", 350, HorizontalAlignment.Left)
        ListView1.Columns.Add("الكميه", 90, HorizontalAlignment.Center)
        ListView1.Columns.Add("الوحدة", 87, HorizontalAlignment.Center)
        ListView1.Columns.Add("العبوة", 87, HorizontalAlignment.Center)
        ListView1.Columns.Add("رصيد المخزن", 150, HorizontalAlignment.Center)

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
      
        If TextBox1.ToString = "" Then
            MsgBox("ادخل رقم الطلب ", MsgBoxStyle.Information, "طباعة ")
            Exit Sub

        Else
            Dim adp As New SqlDataAdapter("SELECT [n_t],[no_c],[name_snc],[name_type],[date_f],[kart],[name1],[mda],[n] ,[m] ,[md],cast([qun_s] as nvarchar(50))as qun_s,[balance],[state],[no_ct1] from inbay where inbay.[n_t]='" + TextBox1.Text + "'", cn)


            Dim dt As New DataTable

            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_s")) = "int" Then
                    dt.Rows(i).Item("qun_s") = myNo
                Else
                    dt.Rows(i).Item("qun_s") = FormatNumber(CDec(dt.Rows(i).Item(11)), 3)
                End If

            Next

            Dim frm As New Form12
            Dim rpt1 As New CrystalReport9
            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1
            Dim Text9 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text9")
            Dim Text36 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section5.ReportObjects("Text36")
            Dim Text31 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section5.ReportObjects("Text31")
            Text9.Text = branch
            'Text25.text=

            If branch = "الادارة العامة" Then

                Text31.Text = "رئيس قسم المخازن والتكاليف"
                Text36.Text = "مدير ادارة الشؤون المالية"
            Else
                : Text31.Text = "رئيس قسم الشؤون المالية"
                Text36.Text = "مدير الفــــرع"

            End If
            frm.Text = "طباعة "
            frm.ShowDialog()
            '===============================================


        End If



    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub TextBoxX3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX3.TextChanged

    End Sub

    Private Sub LabelX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX4.Click

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub TextBoxX5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX5.TextChanged

    End Sub

    Private Sub PictureBox2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LabelX17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX17.Click

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text <> "" Then
                xl = l_p(Trim(TextBox1.Text))
                TextBox1.Text = Trim(xl)
                '==================================
                f_a()

                If ww = True Then

                    Button5_Click(sender, e)
                Else

                    MsgBox("لا يوجد طلب شراء اصناف بهذا الرقم")
                    Me.ListView1.Clear()
                    ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
                    ListView1.Columns.Add("اسم الصنف", 350, HorizontalAlignment.Left)
                    ListView1.Columns.Add("الكميه", 90, HorizontalAlignment.Center)
                    ListView1.Columns.Add("الوحدة", 87, HorizontalAlignment.Center)
                    ListView1.Columns.Add("العبوة", 87, HorizontalAlignment.Center)
                    ListView1.Columns.Add("رصيد المخزن", 150, HorizontalAlignment.Center)
                    ListView1.Columns.Add("", 0, HorizontalAlignment.Center)
                    clearing()
                    clearingf()
                    TextBoxX2.Focus()
                End If
            Else : Exit Sub

            End If
        End If
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

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class