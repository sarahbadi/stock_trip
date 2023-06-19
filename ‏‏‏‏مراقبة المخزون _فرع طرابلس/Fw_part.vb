Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports CrystalDecisions.CrystalReports.Engine

Public Class Fw_part
    Dim ch As Char
    Dim x As Integer
    Dim s1 As String = "select * from  ksf"
    Dim ad As New SqlDataAdapter(s1, cn)
    Dim ff, fb, fb1, fk, fc As Boolean

    Dim s2 As String = "select * from  cls"
    Dim ad2 As New SqlDataAdapter(s2, cn)

    Dim s As String = "select * from matt_k"
    Dim ad1 As New SqlDataAdapter(s, cn)


    Sub clear()
        'اجراء مسح الشاشة
        TextBox2.Text = ""
        TextBox1.Text = ""
        TextBox2.Focus()
        Me.ButtonX2.Enabled = False

    End Sub
    Sub sersh()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim S As String = "select * from ksf where n_type=@x"
        Dim ad As New SqlDataAdapter(S, cn)
        ad.SelectCommand.Parameters.Add("@x", TextBox2.Text)
        Dim ds As New DataSet
        Dim tb As DataTable
        ad.Fill(ds, "ksf")
        tb = ds.Tables("ksf")
        If tb.Rows.Count > 0 Then
            'Me.TextBox1.Text = tb.Rows(0).Item("name_m")
            'Me.TextBox2.Text = tb.Rows(0).Item("no_dam")
            'Me.DateTimePicker1.Value = tb.Rows(0).Item("date_start")
            'ComboBox1.SelectedValue = tb.Rows(0).Item("no_msraf")
            'Me.TextBox3.Text = tb.Rows(0).Item("no_hsab")
            ff = True
            cn.Close()


        Else

            cn.Close()

            ff = False
        End If
        ds.Dispose()
        cn.Close()

    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click


        Dim xx As String 'متغير من نوع سلسله
        xx = Me.GroupPanel1.Text
        If Trim(TextBox2.Text) = "" Then
            MessageBoxEx.Show("ادخل  " + xx, "مراقبة المخزون", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If
        '==========================================================
        If (Mid(Me.TextBox1.Text, 1, 1) = "0") Then
            MsgBox("عفوا الرجاء عدم كتابة الصفر", MsgBoxStyle.Information, "تحذير ")

            Exit Sub
        End If




        Select Case xx 'جملة الحالة
            Case "الكشوفات"
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim s1 As String = "select * from  ksf where type_k=@p1 and n_type=@p2"
                Dim ad As New SqlDataAdapter(s1, cn)
                ad.SelectCommand.Parameters.Add("@p1", TextBox1.Text)
                ad.SelectCommand.Parameters.Add("@p2", TextBox2.Text)

                Dim ds As New DataSet
                Dim tb As DataTable
                ad.Fill(ds, "ksf")
                tb = ds.Tables("ksf")
                If tb.Rows.Count > 0 Then

                    MsgBox(" موجود", MsgBoxStyle.Information, "منظومة ")
                    Exit Sub
                    cn.Close()
                Else
                    cn.Close()

                End If
                ds.Dispose()
                cn.Close()
                '0000000000000000000000000
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim s As String = "insert into ksf (type_k,n_type) values (@p1,@p2) "
                Dim cm As New SqlCommand(s, cn)

                cm.Parameters.Add(New SqlParameter("@p1", TextBox1.Text))
                cm.Parameters.Add(New SqlParameter("@p2", TextBox2.Text))
                Try
                    cm.ExecuteNonQuery()
                Catch e1 As Exception
                    MsgBox("لم تتم عملية الاظافة", MsgBoxStyle.OkOnly, "عفوا")
                    Exit Sub
                End Try
                '***************************************************************************
                ListBox1.Items.Clear()
                Dim s14 As String = "select * from  ksf "
                Dim cm14 As New SqlCommand(s14, cn)
                Dim cr14 As SqlDataReader = cm14.ExecuteReader
                While cr14.Read
                    ListBox1.Items.Add(cr14!n_type)
                End While
                cr14.Close()
                cm14.Dispose()
                MsgBox("تم عملية الاظافة", MsgBoxStyle.OkOnly, "عفوا")
                clear()
                cn.Close()


                If MessageBox.Show("هل تريد ادخال اصناف لهذا المخزن", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Sub
                Else

                    Dim k As New Form1
                    k.ShowDialog()

                End If


            Case "الوحدات"
                '***************************************************************************
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim s1 As String = "select * from  cls where name_type=@p1"
                Dim ad As New SqlDataAdapter(s1, cn)
                ad.SelectCommand.Parameters.Add("@p1", TextBox2.Text)

                Dim ds As New DataSet
                Dim tb As DataTable
                ad.Fill(ds, "cls")
                tb = ds.Tables("cls")
                If tb.Rows.Count > 0 Then
                    MsgBox(" موجود", MsgBoxStyle.Information, "منظومة ")
                    Exit Sub
                    cn.Close()
                Else
                    cn.Close()
                End If
                ds.Dispose()
                cn.Close()
                '***************************************************************************
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim s As String = "insert into cls (name_type) values (@p1) "
                Dim cm As New SqlCommand(s, cn)
                'cm.Parameters.Add("@p1", TextBox2.Text)

                cm.Parameters.Add(New SqlParameter("@p1", TextBox2.Text))

                Try
                    cm.ExecuteNonQuery()
                Catch e1 As Exception
                    MsgBox("لم تتم عملية الاظافة", MsgBoxStyle.OkOnly, "عفوا")
                    Exit Sub
                End Try
                '***************************************************************************
                ListBox1.Items.Clear()
                Dim s14 As String = "select * from  cls "
                Dim cm14 As New SqlCommand(s14, cn)
                Dim cr14 As SqlDataReader = cm14.ExecuteReader
                While cr14.Read
                    ListBox1.Items.Add(cr14!name_type)
                End While
                cr14.Close()
                cm14.Dispose()
                MsgBox("تم عملية الاظافة", MsgBoxStyle.OkOnly, "عفوا")
                clear()
                cn.Close()
        End Select


    End Sub

    Private Sub F_part_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        langarabic()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        If Me.GroupPanel1.Text = "الكشوفات" Then
            ListBox1.Items.Clear()
            Dim s1 As String = "select *from ksf "
            Dim cd As New SqlCommand(s1, cn)
            Dim cr1 As SqlDataReader = cd.ExecuteReader
            While cr1.Read = True
                ListBox1.Items.Add(cr1!n_type)
            End While
            cr1.Close()
            cd.Dispose()
            cn.Close()
        End If
    

        '===============================
        If Me.GroupPanel1.Text = "الوحدات" Then


            ListBox1.Items.Clear()
            Dim s1 As String = "select *from cls "
            Dim cd As New SqlCommand(s1, cn)
            Dim cr1 As SqlDataReader = cd.ExecuteReader
            While cr1.Read = True
                ListBox1.Items.Add(cr1!name_type)
            End While
            cr1.Close()
            cd.Dispose()
            cn.Close()
        End If
        cn.Close()
    End Sub


    Sub serch_k()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s11 As String = "select * from  matt where type_k=@x1"
        Dim cm As New SqlCommand(s11, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))

        Dim r As SqlDataReader = cm.ExecuteReader

        If r.Read = True Then
          fk = True
            r.Close()
        Else
               fk = False
            r.Close()
        End If


    End Sub

    Sub serch_c()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        Dim s11 As String = "select * from  matt where c_type=@x1"
        Dim cm As New SqlCommand(s11, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBox3.Text))

        Dim r As SqlDataReader = cm.ExecuteReader

        If r.Read = True Then
            fc = True
            r.Close()
        Else
            fc = False
            r.Close()
        End If


    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click

        Dim xx As String 'متغير من نوع سلسله
        xx = Me.GroupPanel1.Text
        If Trim(TextBox2.Text) = "" Then
            MessageBoxEx.Show("ادخل  " + xx, "v1مخازن", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If



        '***************************************************************************
        If MessageBox.Show("هل تريد الحذف ؟؟؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            clear()
            Exit Sub
        End If
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Select Case xx 'جملة الحالة
            Case "الكشوفات"
                serch_k()
                If fk = True Then
                    MessageBoxEx.Show(" تم استخدام هذا الكشف ", "منظومة مراقبة المخزون", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else

                    Dim s As String = "delete from ksf where  n_type=@p1 "
                    Dim cm As New SqlCommand(s, cn)
                    cm.Parameters.Add(New SqlParameter("@p1", TextBox2.Text))
                    Try
                        cm.ExecuteNonQuery()
                    Catch e1 As Exception
                        MsgBox(e1.Message)
                    End Try
                    'كود تحديث البيانات في ليست
                    ListBox1.Items.Clear()
                    Dim s14 As String = "select * from  ksf  "
                    Dim cm14 As New SqlCommand(s14, cn)
                    Dim cr14 As SqlDataReader = cm14.ExecuteReader
                    While cr14.Read
                        ListBox1.Items.Add(cr14!n_type)
                    End While
                    cr14.Close()
                    cm14.Dispose()
                    MsgBox("تمت عملية الحذف بنجاح", MsgBoxStyle.OkOnly, "عفواً")
                    clear()
                End If
            Case "الوحدات"

                serch_c()
                If fc = True Then
                    MessageBoxEx.Show(" تم استخدام هذه الوحده  ", "منظومة مراقبه المخزون", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    Dim s As String = "delete from cls where  name_type=@p1 "
                    Dim cm As New SqlCommand(s, cn)
                    cm.Parameters.Add(New SqlParameter("@p1", TextBox2.Text))
                    Try
                        cm.ExecuteNonQuery()
                    Catch e1 As Exception
                        MsgBox(e1.Message)
                    End Try
                    'كود تحديث البيانات في ليست
                    ListBox1.Items.Clear()
                    Dim s14 As String = "select * from  cls  "
                    Dim cm14 As New SqlCommand(s14, cn)
                    Dim cr14 As SqlDataReader = cm14.ExecuteReader
                    While cr14.Read
                        ListBox1.Items.Add(cr14!name_type)
                    End While
                    cr14.Close()
                    cm14.Dispose()
                    MsgBox("تمت عملية الحذف بنجاح", MsgBoxStyle.OkOnly, "عفواً")
                    clear()
                End If
        End Select
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim d As String
        d = ListBox1.Text
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        If Me.GroupPanel1.Text = "الكشوفات" Then
            '***************************************************************************
            'هذه الجملة الغرض منها البحث عن عنصر
            Dim s1 As String = "select * from  ksf where n_type=@p1 "
            'تعريف هدف لكي يتم التعامل مع قاعدة البيانات
            Dim cm1 As New SqlCommand(s1, cn)
            'تعبيئة البارميتر بقيمة من مربع النص
            cm1.Parameters.Add(New SqlParameter("@p1", d))
            'امر قراء من قاعدة البيانات
            Dim cr As SqlDataReader = cm1.ExecuteReader
            If cr.Read Then
                TextBox2.Text = cr!n_type
                TextBox1.Text = cr!type_k
                ButtonX2.Enabled = True
                cr.Close()
                cm1.Dispose()
            End If
            cr.Close()
            cm1.Dispose()
        End If
        If Me.GroupPanel1.Text = "الوحدات" Then
            'هذه الجملة الغرض منها البحث عن عنصر
            Dim s1 As String = "select * from  cls where name_type=@p1 "
            'تعريف هدف لكي يتم التعامل مع قاعدة البيانات
            Dim cm1 As New SqlCommand(s1, cn)
            'تعبيئة البارميتر بقيمة من مربع النص
            cm1.Parameters.Add(New SqlParameter("@p1", d))
            'امر قراء من قاعدة البيانات
            Dim cr As SqlDataReader = cm1.ExecuteReader
            If cr.Read Then
                TextBox2.Text = cr!name_type
                Me.TextBox3.Text = cr!no_type
                ButtonX2.Enabled = True
                cr.Close()
                cm1.Dispose()
            End If
            cr.Close()
            cm1.Dispose()
        End If


    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        Me.Dispose()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        secu_text(e)
    End Sub


    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub GroupPanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPanel1.Click

    End Sub


    Sub up_mattk()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "update matt set type_k=@x1 where type_k=@x1"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add("@x1", TextBox1.Text)
        Try
            cm.ExecuteNonQuery()
        Catch e1 As Exception
            Exit Sub
        End Try

    End Sub

    Sub up_mattc()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s As String = "update matt set c_type=@x1 where c_type=@x1"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add("@x1", TextBox3.Text)
        Try
            cm.ExecuteNonQuery()
        Catch e1 As Exception
            Exit Sub
        End Try

    End Sub


    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        'sersh_k()

        Dim xx As String 'متغير من نوع سلسله
        xx = Me.GroupPanel1.Text
        If Trim(TextBox2.Text) = "" Then
            MessageBoxEx.Show("ادخل  " + xx, "v1مخازن", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If

        Select Case xx 'جملة الحالة
            Case "الكشوفات"
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim s1 As String = "select * from  ksf where type_k=@p1 and n_type=@p2"
                Dim ad As New SqlDataAdapter(s1, cn)
                ad.SelectCommand.Parameters.Add("@p1", TextBox1.Text)
                ad.SelectCommand.Parameters.Add("@p2", TextBox2.Text)
                Dim ds As New DataSet
                Dim tb As DataTable
                ad.Fill(ds, "ksf")
                tb = ds.Tables("ksf")
                If tb.Rows.Count > 0 Then

                    MsgBox(" موجود", MsgBoxStyle.Information, "منظومة ")
                    Exit Sub
                    cn.Close()
                Else
                    cn.Close()

                End If
                ds.Dispose()
                cn.Close()

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim s As String = "update ksf set type_k=@x1,n_type=@x2 where type_k=@x1"
                Dim cm As New SqlCommand(s, cn)
                'cm.Parameters.Add("@x1", TextBox1.Text)
                'cm.Parameters.Add("@x2", TextBox2.Text)

                cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
                cm.Parameters.Add(New SqlParameter("@x2", TextBox2.Text))
                Try
                    cm.ExecuteNonQuery()
                    up_mattk()

                Catch e1 As Exception
                    MsgBox("لم تتم عملية التعديل", MsgBoxStyle.OkOnly, "عفوا")
                    Exit Sub
                End Try

                '***************************************************************************
                ListBox1.Items.Clear()
                Dim s14 As String = "select * from  ksf "
                Dim cm14 As New SqlCommand(s14, cn)
                Dim cr14 As SqlDataReader = cm14.ExecuteReader
                While cr14.Read
                    ListBox1.Items.Add(cr14!n_type)
                End While
                cr14.Close()
                cm14.Dispose()
                MsgBox("تم عملية التعديل", MsgBoxStyle.OkOnly, "عفوا")
                clear()
                cn.Close()
            Case "الوحدات"


                '***************************************************************************
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim s1 As String = "select * from  cls where name_type=@p1"
                Dim ad As New SqlDataAdapter(s1, cn)
                ad.SelectCommand.Parameters.Add("@p1", TextBox2.Text)

                Dim ds As New DataSet
                Dim tb As DataTable
                ad.Fill(ds, "cls")
                tb = ds.Tables("cls")
                If tb.Rows.Count > 0 Then
                    MsgBox(" موجود", MsgBoxStyle.Information, "منظومة ")

                    Exit Sub
                    cn.Close()
                Else
                    cn.Close()
                End If
                ds.Dispose()
                cn.Close()
                '***************************************************************************
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                Dim s As String = "update cls set name_type=@p1 where no_type=@p2"
                Dim cm As New SqlCommand(s, cn)

                'cm.Parameters.Add("@p1", TextBox2.Text)
                ' cm.Parameters.Add("@p2", TextBox3.Text)



                cm.Parameters.Add(New SqlParameter("@p1", TextBox2.Text))
                cm.Parameters.Add(New SqlParameter("@p2", TextBox3.Text))
                Try
                    cm.ExecuteNonQuery()
                    up_mattc()
                Catch e1 As Exception
                    MsgBox("لم تتم عملية التعديل", MsgBoxStyle.OkOnly, "عفوا")
                    Exit Sub
                End Try
                Me.TextBox3.Clear()
                '***************************************************************************
                ListBox1.Items.Clear()
                Dim s14 As String = "select * from  cls "
                Dim cm14 As New SqlCommand(s14, cn)
                Dim cr14 As SqlDataReader = cm14.ExecuteReader
                While cr14.Read
                    ListBox1.Items.Add(cr14!name_type)
                End While
                cr14.Close()
                cm14.Dispose()
                MsgBox("تم عملية التعديل", MsgBoxStyle.OkOnly, "عفوا")
                clear()
                cn.Close()
        End Select

    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click


        Dim dss As New DataSet1
        dss.Clear()
        Dim f As New Form10
        Dim sad As SqlDataAdapter
        Dim t1 As DataTable

        Dim s As String = "SELECT * from matt_k "
        sad = New SqlDataAdapter(s, cn)
        sad.Fill(dss, s)
        t1 = dss.Tables(s)
        Dim rpt1 As New CrystalRk
        rpt1.SetDataSource(t1)
        f.CrystalReportViewer1.ReportSource = rpt1
        f.Text = "طباعة "
        Dim Text1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text1")
        Text1.Text = branch
        f.ShowDialog()
    End Sub
End Class