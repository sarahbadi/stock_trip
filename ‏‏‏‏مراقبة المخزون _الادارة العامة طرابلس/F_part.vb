Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Public Class F_part
    Dim ch As Char
    Dim x As Integer
    Dim s1 As String = "select * from  j_s"
    Dim ad As New SqlDataAdapter(s1, cn)
    Dim fm, fs As Boolean

    Dim s2 As String = "select * from  j_r"
    Dim ad2 As New SqlDataAdapter(s2, cn)

    Sub clear()
        'اجراء مسح الشاشة
        TextBox2.Text = ""
        TextBox2.Focus()
        Me.ButtonX2.Enabled = False



    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Dim xx As String 'متغير من نوع سلسله
        xx = Me.GroupPanel1.Text
        If Trim(TextBox2.Text) = "" Then
            MessageBoxEx.Show("ادخل  " + xx, "مراقبة المخزون", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If

        Select Case xx 'جملة الحالة
            Case "الاقسام والوحدات"

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim s1 As String = "select * from j_s where name_s=@p1 "
                Dim ad As New SqlDataAdapter(s1, cn)
                ad.SelectCommand.Parameters.Add("@p1", TextBox2.Text)

                Dim ds As New DataSet
                Dim tb As DataTable
                ad.Fill(ds, "j_s")
                tb = ds.Tables("j_s")
                If tb.Rows.Count > 0 Then

                    MsgBox(" موجود", MsgBoxStyle.Information, "مراقبة المخزون ")
                    Exit Sub
                    cn.Close()
                Else
                    cn.Close()
                End If
                ds.Dispose()
                cn.Close()

                '***************************************************************************
                '***************************************************************************
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                '***************************************************************************
                Dim s As String = "insert into j_s (name_s) values (@p1)"
                Dim cm As New SqlCommand(s, cn)
                cm.Parameters.Add("@p1", TextBox2.Text)
                Try
                    cm.ExecuteNonQuery()
                Catch e1 As Exception
                    MsgBox("لم تتم عملية الاظافة", MsgBoxStyle.OkOnly, "مراقبة المخزون")
                    Exit Sub
                End Try
                '***************************************************************************
                ListBox1.Items.Clear()
                Dim s14 As String = "select * from  j_s "
                Dim cm14 As New SqlCommand(s14, cn)
                Dim cr14 As SqlDataReader = cm14.ExecuteReader
                While cr14.Read
                    ListBox1.Items.Add(cr14!name_s)
                End While
                cr14.Close()
                cm14.Dispose()
                MsgBox("تم عملية الاظافة", MsgBoxStyle.OkOnly, "مراقبة المخزون")
                clear()
            Case "الجهات الموردة"
                '***************************************************************************
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If


                Dim s1 As String = "select * from  j_r where name_r=@p1 "
                Dim ad As New SqlDataAdapter(s1, cn)
                ad.SelectCommand.Parameters.Add("@p1", TextBox2.Text)

                Dim ds As New DataSet
                Dim tb As DataTable
                ad.Fill(ds, "j_r")
                tb = ds.Tables("j_r")
                If tb.Rows.Count > 0 Then

                    MsgBox(" موجود", MsgBoxStyle.Information, "مراقبة المخزون ")
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
                Dim s2 As String = "insert into j_r (name_r) values (@p1)"
                Dim cm2 As New SqlCommand(s2, cn)
                cm2.Parameters.Add("@p1", TextBox2.Text)
                Try
                    cm2.ExecuteNonQuery()
                Catch e1 As Exception
                    MsgBox("لم تتم عملية الاظافة", MsgBoxStyle.OkOnly, "مراقبة المخزون")
                    Exit Sub
                End Try
                '***************************************************************************
                ListBox1.Items.Clear()
                Dim s14 As String = "select * from  j_r "
                Dim cm14 As New SqlCommand(s14, cn)
                Dim cr14 As SqlDataReader = cm14.ExecuteReader
                While cr14.Read
                    ListBox1.Items.Add(cr14!name_r)
                End While
                cr14.Close()
                cm14.Dispose()
                MsgBox("تم عملية الاظافة", MsgBoxStyle.OkOnly, "مراقبة المخزون")
                clear()

        End Select


    End Sub

    Private Sub F_part_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        langarabic()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        If Me.GroupPanel1.Text = "الاقسام والوحدات" Then
            ListBox1.Items.Clear()
            Dim s1 As String = "select *from j_s "
            Dim cd As New SqlCommand(s1, cn)
            Dim cr1 As SqlDataReader = cd.ExecuteReader
            While cr1.Read = True
                ListBox1.Items.Add(cr1!name_s)
            End While
            cr1.Close()
            cd.Dispose()
            cn.Close()
        End If
        '===============================
        If Me.GroupPanel1.Text = "الجهات الموردة" Then


            ListBox1.Items.Clear()
            Dim s1 As String = "select *from j_r "
            Dim cd As New SqlCommand(s1, cn)
            Dim cr1 As SqlDataReader = cd.ExecuteReader
            While cr1.Read = True
                ListBox1.Items.Add(cr1!name_r)
            End While
            cr1.Close()
            cd.Dispose()
            cn.Close()
        End If
        cn.Close()
    End Sub

    Sub serch_mord()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        Dim s11 As String = "select * from  RcvMain where j_r=@x1"
        Dim cm As New SqlCommand(s11, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBox3.Text))

        Dim r As SqlDataReader = cm.ExecuteReader

        If r.Read = True Then
            fm = True
            r.Close()
        Else
            fm = False
            r.Close()
        End If


    End Sub

    Sub serch_jehat()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        Dim s11 As String = "select * from  IsuMain where j_s=@x1"
        Dim cm As New SqlCommand(s11, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBox3.Text))

        Dim r As SqlDataReader = cm.ExecuteReader

        If r.Read = True Then
            fs = True
            r.Close()
        Else
            fs = False
            r.Close()
        End If


    End Sub
    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click

        Dim xx As String 'متغير من نوع سلسله
        xx = Me.GroupPanel1.Text
        If Trim(TextBox2.Text) = "" Then
            MessageBoxEx.Show("ادخل   " + xx, "مراقبة المخزون", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Case "الاقسام والوحدات"

                serch_jehat()

                If fs = True Then
                    MessageBoxEx.Show("  تم استخدام هذا القسم اوالوحدة  ", "مراقبة المخزون", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    Dim s As String = "delete from j_s where  name_s=@p1 "
                    Dim cm As New SqlCommand(s, cn)
                    cm.Parameters.Add(New SqlParameter("@p1", TextBox2.Text))
                    Try
                        cm.ExecuteNonQuery()
                    Catch e1 As Exception
                        MsgBox(e1.Message)
                    End Try
                    'كود تحديث البيانات في ليست
                    ListBox1.Items.Clear()
                    Dim s14 As String = "select * from  j_s  "
                    Dim cm14 As New SqlCommand(s14, cn)
                    Dim cr14 As SqlDataReader = cm14.ExecuteReader
                    While cr14.Read
                        ListBox1.Items.Add(cr14!name_s)
                    End While
                    cr14.Close()
                    cm14.Dispose()
                    MsgBox("تمت عملية الحذف بنجاح", MsgBoxStyle.OkOnly, "مراقبة المخزونً")
                    clear()
                End If
            Case "الجهات الموردة"

                serch_mord()
                If fm = True Then

                    MessageBoxEx.Show(" تم استخدام هذه الجهة ", "مراقبة المخزون", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    Dim s As String = "delete from j_r where  name_r=@p1 "
                    Dim cm As New SqlCommand(s, cn)
                    cm.Parameters.Add(New SqlParameter("@p1", TextBox2.Text))
                    Try
                        cm.ExecuteNonQuery()
                    Catch e1 As Exception
                        MsgBox(e1.Message)
                    End Try
                    'كود تحديث البيانات في ليست
                    ListBox1.Items.Clear()
                    Dim s14 As String = "select * from  j_r  "
                    Dim cm14 As New SqlCommand(s14, cn)
                    Dim cr14 As SqlDataReader = cm14.ExecuteReader
                    While cr14.Read
                        ListBox1.Items.Add(cr14!name_r)
                    End While
                    cr14.Close()
                    cm14.Dispose()
                    MsgBox("تمت عملية الحذف بنجاح", MsgBoxStyle.OkOnly, "مراقبة المخزون")
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

        If Me.GroupPanel1.Text = "الاقسام والوحدات" Then
            '***************************************************************************
            'هذه الجملة الغرض منها البحث عن عنصر
            Dim s1 As String = "select * from  j_s where name_s=@p1 "
            'تعريف هدف لكي يتم التعامل مع قاعدة البيانات
            Dim cm1 As New SqlCommand(s1, cn)
            'تعبيئة البارميتر بقيمة من مربع النص
            cm1.Parameters.Add(New SqlParameter("@p1", d))
            'امر قراء من قاعدة البيانات
            Dim cr As SqlDataReader = cm1.ExecuteReader
            If cr.Read Then
                TextBox2.Text = cr!name_s
                TextBox3.Text = cr!n_s
                ButtonX2.Enabled = True
                cr.Close()
                cm1.Dispose()
            End If
            cr.Close()
            cm1.Dispose()
        End If
        If Me.GroupPanel1.Text = "الجهات الموردة" Then
            'هذه الجملة الغرض منها البحث عن عنصر
            Dim s1 As String = "select * from  j_r where name_r=@p1 "
            'تعريف هدف لكي يتم التعامل مع قاعدة البيانات
            Dim cm1 As New SqlCommand(s1, cn)
            'تعبيئة البارميتر بقيمة من مربع النص
            cm1.Parameters.Add(New SqlParameter("@p1", d))
            'امر قراء من قاعدة البيانات
            Dim cr As SqlDataReader = cm1.ExecuteReader
            If cr.Read Then
                TextBox2.Text = cr!name_r
                TextBox3.Text = cr!no_r
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

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        Dim xx As String 'متغير من نوع سلسله
        xx = Me.GroupPanel1.Text
        If Trim(TextBox2.Text) = "" Then
            MessageBoxEx.Show("ادخل  " + xx, "مراقبة المخزون", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If



        Select Case xx 'جملة الحالة
            Case "الاقسام والوحدات"

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim s1 As String = "select * from j_s where name_s=@p1 "
                Dim ad As New SqlDataAdapter(s1, cn)
                ad.SelectCommand.Parameters.Add("@p1", TextBox2.Text)

                Dim ds As New DataSet
                Dim tb As DataTable
                ad.Fill(ds, "j_s")
                tb = ds.Tables("j_s")
                If tb.Rows.Count > 0 Then

                    MsgBox(" موجود", MsgBoxStyle.Information, "مراقبة المخزون ")
                    Exit Sub
                    cn.Close()
                Else
                    cn.Close()
                End If
                ds.Dispose()
                cn.Close()

                '***************************************************************************
                '***************************************************************************
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                '***************************************************************************
                Dim s As String = "update j_s set name_s=@p1 where n_s=@p2"
                Dim cm As New SqlCommand(s, cn)
                cm.Parameters.Add("@p1", TextBox2.Text)
                cm.Parameters.Add("@p2", TextBox3.Text)
                Try
                    cm.ExecuteNonQuery()
                Catch e1 As Exception
                    MsgBox("لم تتم عملية التعديل", MsgBoxStyle.OkOnly, "مراقبة المخزون")
                    Exit Sub
                End Try
                Me.TextBox3.Clear()
                '***************************************************************************
                ListBox1.Items.Clear()
                Dim s14 As String = "select * from  j_s "
                Dim cm14 As New SqlCommand(s14, cn)
                Dim cr14 As SqlDataReader = cm14.ExecuteReader
                While cr14.Read
                    ListBox1.Items.Add(cr14!name_s)
                End While
                cr14.Close()
                cm14.Dispose()
                MsgBox("تم عملية التعديل", MsgBoxStyle.OkOnly, "مراقبة المخزون")
                clear()
            Case "الجهات الموردة"
                '***************************************************************************
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If


                Dim s1 As String = "select * from  j_r where name_r=@p1 "
                Dim ad As New SqlDataAdapter(s1, cn)
                ad.SelectCommand.Parameters.Add("@p1", TextBox2.Text)

                Dim ds As New DataSet
                Dim tb As DataTable
                ad.Fill(ds, "j_r")
                tb = ds.Tables("j_r")
                If tb.Rows.Count > 0 Then

                    MsgBox(" موجود", MsgBoxStyle.Information, "مراقبة المخزون ")
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
                Dim s2 As String = "update j_r set name_r=@p1 where no_r=@p2"
                Dim cm2 As New SqlCommand(s2, cn)
                cm2.Parameters.Add("@p1", TextBox2.Text)
                cm2.Parameters.Add("@p2", TextBox3.Text)
                Try
                    cm2.ExecuteNonQuery()
                Catch e1 As Exception
                    MsgBox("لم تتم عملية التعديل", MsgBoxStyle.OkOnly, "مراقبة المخزون")
                    Exit Sub
                End Try
                Me.TextBox3.Clear()
                '***************************************************************************
                ListBox1.Items.Clear()
                Dim s14 As String = "select * from  j_r "
                Dim cm14 As New SqlCommand(s14, cn)
                Dim cr14 As SqlDataReader = cm14.ExecuteReader
                While cr14.Read
                    ListBox1.Items.Add(cr14!name_r)
                End While
                cr14.Close()
                cm14.Dispose()
                MsgBox("تم عملية التعديل", MsgBoxStyle.OkOnly, "مراقبة المخزون")
                clear()

        End Select


    End Sub




    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub
End Class