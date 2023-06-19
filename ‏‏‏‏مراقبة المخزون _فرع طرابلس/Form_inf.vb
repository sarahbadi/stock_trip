
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Form_inf
    Dim g As String
    Dim f As Boolean
    Dim f1 As Boolean
    Dim move_no As String
    Dim sum_irct, sum_iiss, total_s As New Integer()
    Dim i, p, w, no As New Integer()
    '====================
    Dim ww1 As Boolean


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

    Dim s1 As String = "select * from f_ar"
    Dim ad1 As New SqlDataAdapter(s1, cn)
    Dim ds1 As New DataSet()
    '======================================
    Dim sm As String = "select * from matt"
    Dim adm As New SqlDataAdapter(sm, cn)
    Dim dsm As New DataSet()
    Dim TDm As DataTable
    '======================================

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
    Sub s_add()
        Dim s As String = "select * from f_ar where no_f=(select max(no_f) from f_ar)"
        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "f_ar")
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
    Private Sub Form_main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        langarabic()

        s_add()
        xl = l_p(TextBox1.Text)
        TextBox1.Text = Trim(xl)
        ListView1.View = View.Details

     


        '=======================
        adaj_s.Fill(dsaj_s, "j_s")
        ComboBoxEx4.DataSource = dsaj_s
        ComboBoxEx4.DisplayMember = "j_s.name_s"
        ComboBoxEx4.ValueMember = "n_s"
        '=================================

        adcl.Fill(dscl, "cls")
        ComboBoxEx1.DataSource = dscl
        ComboBoxEx1.DisplayMember = "cls.name_type"
        ComboBoxEx1.ValueMember = "no_type"


        ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("اسم الصنف", 350, HorizontalAlignment.Left)
        ListView1.Columns.Add("الكميه", 90, HorizontalAlignment.Center)
        ListView1.Columns.Add("الوحدة", 87, HorizontalAlignment.Center)
        ListView1.Columns.Add("رصيد المخزن", 150, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 0, HorizontalAlignment.Center)
        ComboBoxEx4.SelectedIndex = -1
        ComboBoxEx1.SelectedIndex = -1

        Me.ButtonX2.Enabled = False
        Me.ButtonX3.Enabled = False
    End Sub

    Sub clearing()
        Me.TextBoxX2.Clear()
        Me.TextBoxX3.Clear()
        Me.TextBoxX4.Clear()
        TextBoxX5.Clear()
        ComboBoxEx1.SelectedIndex = -1
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
                Me.LabelX2.Text = r!no_ct
                'ComboBoxEx4.Enabled = False
                'Me.DateTimePicker3.Enabled = False
                r.Close()
            Else
                r.Close()

                'ComboBoxEx4.Enabled = True
                'Me.DateTimePicker3.Enabled = True
                'MsgBox("هذا الصنف لم يتم تعريفة بعد", MsgBoxStyle.OkOnly, "تنبية")
                Me.clearing()
                r.Close()
            End If

        Catch
            MsgBox("يوجد خطاءفي بيانات المواد", MsgBoxStyle.Critical, "تنبية")
        End Try

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim dt2 As DataTable

        Dim sql1, n1 As String
        n1 = TextBox1.Text
        If n1 = "" Then

            Exit Sub
        Else

            'f_ar.date_f like  " + "'" + Me.DateTimePicker3.Value.Date + "%" + "' And 

            'sql1 = "SELECT * from f_ar WHERE f_ar.no_f= val(" & n1 & ")"

            sql1 = "SELECT * from f_ar WHERE f_ar.no_f='" + TextBox1.Text + "'"
            Dim da8 As New SqlDataAdapter(sql1, cn)
            Dim ds8 As New DataSet
            ds8.Clear()
            da8.Fill(ds8, "f_ar")
            dt2 = ds8.Tables("f_ar")
            If dt2.Rows.Count > 0 Then

            End If
            ListView1.Clear()
            Dim dr2 As DataRow


            ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
            ListView1.Columns.Add("اسم الصنف", 350, HorizontalAlignment.Left)
            ListView1.Columns.Add("الكميه", 90, HorizontalAlignment.Center)
            ListView1.Columns.Add("الوحدة", 87, HorizontalAlignment.Center)
            ListView1.Columns.Add("رصيد المخزن", 150, HorizontalAlignment.Center)
            ListView1.Columns.Add("", 0, HorizontalAlignment.Center)

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
                litem.Text = dt2.Rows(i).Item("no_ct")
                litem.SubItems.Add(dt2.Rows(i).Item("name_snc"))
                litem.SubItems.Add(dt2.Rows(i).Item("qun_s"))
                litem.SubItems.Add(dt2.Rows(i).Item("c_type"))
                litem.SubItems.Add(dt2.Rows(i).Item("balance"))
                litem.SubItems.Add(dt2.Rows(i).Item("no_c"))

                ListView1.Items.Add(litem)
            Next i

            ListView1.View = View.Details
            ListView1.Sorting = SortOrder.Ascending
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
        Dim s As String = "SELECT * from f_ar where no_f =@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add("@x1", TextBox1.Text)
        'cm.Parameters.Add("@x2", Me.DateTimePicker3.Value.Date)
        Try
            Dim r13 As SqlDataReader = cm.ExecuteReader
            If r13.Read = True Then
                ww1 = True
                ComboBoxEx4.Text = r13!j_s
                Me.DateTimePicker3.Value = r13!date_f
                'ComboBoxEx4.Enabled = False
                'Me.DateTimePicker3.Enabled = False
                Me.ButtonX5.Enabled = True
                Me.ButtonX6.Enabled = True

                Me.ButtonX2.Enabled = True
                Me.ButtonX3.Enabled = True
                r13.Close()

            Else
                ww1 = False
                Me.ButtonX2.Enabled = False
                Me.ButtonX3.Enabled = False

                Me.ButtonX5.Enabled = False
                Me.ButtonX6.Enabled = False
                'MsgBox("لم يتم ادخال هذا الصنف")
                'ComboBoxEx4.Enabled = True
                'Me.DateTimePicker3.Enabled = True

                r13.Close()
            End If

        Catch err As System.Exception
            MsgBox(err.Message)
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        ListView1.Items.Clear()

        Dim s As String = "delete from f_ar where no_f=@x1"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add("@x1", TextBox1.Text)
        'If MsgBox("هل أنت متأكد من عملية حدفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then

        Try
            cm.ExecuteNonQuery()
            ds1.Clear()
            ad1.Fill(ds1, "f_ar")
        Catch
            MsgBox("لايمـكـن الـحـذ ف", MsgBoxStyle.SystemModal, "تنبية")
        End Try
    End Sub

    Private Sub TextBoxX2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxX2.Leave
        Me.TextBoxX3.Clear()
        Me.TextBoxX4.Clear()
        TextBoxX5.Clear()
        'ComboBoxEx4.SelectedIndex = -1
        Me.DateTimePicker3.Value = Now
        'Me.LabelX2.Text = 0
        stouck()
    End Sub

    Private Sub TextBoxX2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX2.TextChanged

    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        Dim litem As ListViewItem
        Dim i As Integer
        For Each litem In ListView1.SelectedItems
            Me.LabelX2.Text = litem.SubItems(0).Text
            TextBoxX3.Text = litem.SubItems(1).Text
            TextBoxX4.Text = litem.SubItems(2).Text
            Me.ComboBoxEx1.Text = litem.SubItems(3).Text
            TextBoxX5.Text = litem.SubItems(4).Text
            TextBoxX2.Text = litem.SubItems(5).Text
        Next

        Me.ButtonX2.Enabled = True
        Me.ButtonX3.Enabled = True
    End Sub

    Private Sub TextBoxX1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text <> "" Then
                xl = l_p(Trim(TextBox1.Text))
                TextBox1.Text = Trim(xl)
                '==================================
                f_a()

                If ww1 = True Then

                    Button5_Click(sender, e)
                Else

                    MsgBox("لا يوجد طلب سحب اصناف بهذا الرقم")
                    Me.ListView1.Clear()
                    ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
                    ListView1.Columns.Add("اسم الصنف", 350, HorizontalAlignment.Left)
                    ListView1.Columns.Add("الكميه", 90, HorizontalAlignment.Center)
                    ListView1.Columns.Add("الوحدة", 87, HorizontalAlignment.Center)
                    ListView1.Columns.Add("رصيد المخزن", 150, HorizontalAlignment.Center)
                    ListView1.Columns.Add("", 0, HorizontalAlignment.Center)
                    clearing()
                    'clearingf()
                    TextBoxX2.Focus()
                End If
            Else : Exit Sub

            End If
        End If
    End Sub



    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        clearing()
        s_add()
        xl = l_p(TextBox1.Text)
        TextBox1.Text = xl

        TextBox1.Focus()
        Me.ListView1.Clear()
        ListView1.View = View.Details
        ComboBoxEx4.SelectedIndex = -1
        DateTimePicker3.Value = (Format(Date.Now, "yyyy/MM/dd"))

        ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("اسم الصنف", 350, HorizontalAlignment.Left)
        ListView1.Columns.Add("الكميه", 90, HorizontalAlignment.Center)
        ListView1.Columns.Add("الوحدة", 87, HorizontalAlignment.Center)
        ListView1.Columns.Add("العبوة", 87, HorizontalAlignment.Center)
        ListView1.Columns.Add("رصيد المخزن", 150, HorizontalAlignment.Center)


    End Sub



    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim litem As ListViewItem
        Dim i As Integer
        For Each litem In ListView1.SelectedItems
            Me.LabelX2.Text = litem.SubItems(0).Text
            TextBoxX3.Text = litem.SubItems(1).Text
            TextBoxX4.Text = litem.SubItems(2).Text
            Me.ComboBoxEx1.Text = litem.SubItems(3).Text
            TextBoxX5.Text = litem.SubItems(4).Text
            TextBoxX2.Text = litem.SubItems(5).Text
        Next

        Me.ButtonX2.Enabled = True
        Me.ButtonX3.Enabled = True
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If TextBox1.Text <> "" Then

            Dim f As New Form6

            Dim adp As New SqlDataAdapter("SELECT no_f, date_f, j_s, no_c, c_type,cast([qun_s]as nvarchar(50))as qun_s, name_snc, cast([balance]as nvarchar(50))as balance,no_ct1 FROM f_arr WHERE no_f = " & Me.TextBox1.Text & "", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_s")) = "int" Then
                    dt.Rows(i).Item("qun_s") = myNo
                Else

                    dt.Rows(i).Item("qun_s") = FormatNumber(CDec(dt.Rows(i).Item(5)), 3)
                End If

                If checkNum(dt.Rows(i).Item("balance")) = "int" Then
                    dt.Rows(i).Item("balance") = myNo
                Else

                    dt.Rows(i).Item("balance") = FormatNumber(CDec(dt.Rows(i).Item(7)), 3)
                End If
            Next

            Dim rpt1 As New CrystalReport16

            rpt1.SetDataSource(dt)
            f.CrystalReportViewer1.ReportSource = rpt1

            Dim Text2 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text2")
            Text2.Text = branch

            f.Text = "طباعة "
            f.ShowDialog()
            '=======================================
            
            'If branch = "الادارة العامة" Then

            '    Text36.Text = "رئيس قسم المخازن والتكاليف"
            'Else
            '    Text36.Text = "رئيس وحدة المخازن والتكاليف"

            'End If



        End If


    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()

        End If
        Dim s As String = "update  f_ar set no_f=@x1,date_f=@x2,j_s=@x3 where no_f=@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
        cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
        cm.Parameters.Add(New SqlParameter("@x3", Me.ComboBoxEx4.Text))

        Try

            cm.ExecuteNonQuery()

            ds1.Clear()
            ad1.Fill(ds1, " f_ar")

            MsgBox("تم التعديل", MsgBoxStyle.Information, "تنبية")
            Button5_Click(sender, e)
        Catch
            MsgBox("لايمكنك التعديل في رقم الصنف ورقم الفاتورة وتاريخ الفاتورة ", MsgBoxStyle.Information, "تنبية")
        End Try

    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click

        If cn.State = ConnectionState.Closed Then
            cn.Open()

        End If

        Dim s As String = "delete from f_ar where no_f=@x1"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
        If MsgBox("هل أنت متأكد من عملية حدفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then

            Try
                cm.ExecuteNonQuery()
                ds1.Clear()
                ad1.Fill(ds1, "f_ar")

            Catch
                MsgBox("لايمـكـن الـحـذ ف", MsgBoxStyle.SystemModal, "تنبية")
            End Try

            clearing()
            TextBox1.Clear()
            Me.ListView1.Clear()
            s_add()
            xl = l_p(TextBox1.Text)
            TextBox1.Text = xl

        Else
            Exit Sub
        End If
    End Sub

    Private Sub TextBoxX4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX4.KeyPress
        secu_num(e)
    End Sub

    Private Sub TextBoxX4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX4.TextChanged

    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click

        If TextBoxX2.Text = "" Then
            MsgBox("عفواً..يجب أن تدخل  رقم الصنف ", MsgBoxStyle.Information, "تنبيه")
            TextBoxX2.Focus()
            Exit Sub
        End If


        If TextBoxX4.Text = "" Then
            MsgBox("عفواً..يجب أن تدخل  الكمية ", MsgBoxStyle.Information, "تنبيه")
            TextBoxX4.Focus()
            Exit Sub
        End If
        If Me.ComboBoxEx4.Text = "" Or Me.ComboBoxEx4.SelectedIndex = -1 Then
            MsgBox("عفواً..يجب أن تختار الجهة الطالبه ", MsgBoxStyle.Information, "تنبيه")
            ComboBoxEx4.Focus()
            Exit Sub
        End If
      

        If cn.State = ConnectionState.Closed Then
            cn.Open()

        End If

        Dim s As String = "insert into f_ar(no_f,date_f,j_s,no_c,c_type,qun_s,name_snc,balance,no_ct) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"



        Dim cm As New SqlCommand(s, cn)



        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
        cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
        cm.Parameters.Add(New SqlParameter("@x3", Me.ComboBoxEx4.Text))
        cm.Parameters.Add(New SqlParameter("@x4", TextBoxX2.Text))
        cm.Parameters.Add(New SqlParameter("@x5", ComboBoxEx1.Text))
        cm.Parameters.Add(New SqlParameter("@x6", TextBoxX4.Text))
        cm.Parameters.Add(New SqlParameter("@x7", TextBoxX3.Text))
        cm.Parameters.Add(New SqlParameter("@x8", TextBoxX5.Text))
        cm.Parameters.Add(New SqlParameter("@x9", Me.LabelX2.Text))
        Try
            cm.ExecuteNonQuery()
            ds1.Clear()
            ad1.Fill(ds1, "f_ar")
            clearing()
            Me.ListView1.Clear()
            Button5_Click(sender, e)
            ListView1.Sorting = SortOrder.Ascending
        Catch
            MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
            Exit Sub
        End Try



    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If (ListView1.SelectedItems.Count = 0) Then

            MessageBox.Show("لاتوجد عناصر تم اختارها")

            Exit Sub

        Else



            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim s As String = "update  f_ar set no_f=@x1,no_c=@x2,qun_s=@x3 where no_f=@x1 and no_c=@x2"
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
            cm.Parameters.Add(New SqlParameter("@x2", TextBoxX2.Text))
            cm.Parameters.Add(New SqlParameter("@x3", TextBoxX4.Text))
            Try

                cm.ExecuteNonQuery()

                ds1.Clear()
                ad1.Fill(ds1, "f_ar")

                MsgBox("تم التعديل", MsgBoxStyle.Information, "تنبية")


                Button5_Click(sender, e)

                clearing()


            Catch
                MsgBox("لايمكنك التعديل في رقم الصنف ورقم الفاتورة وتاريخ الفاتورة ", MsgBoxStyle.Information, "تنبية")
            End Try

        End If
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()

        End If


        If (ListView1.SelectedItems.Count = 0) Then
            MessageBox.Show("لاتوجد عناصر تم اختارها")

            Exit Sub

        Else
            ListView1.Items.RemoveAt(ListView1.FocusedItem.Index)

            Dim s As String = "delete from f_ar where no_c=@x1"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add("@x1", TextBoxX2.Text)
            'If MsgBox("هل أنت متأكد من عملية حدفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then

            Try
                cm.ExecuteNonQuery()
                ds1.Clear()
                ad1.Fill(ds1, "f_ar")
                TextBoxX2_Leave(sender, e)
                Button5_Click(sender, e)

            Catch
                MsgBox("لايمـكـن الـحذ ف", MsgBoxStyle.SystemModal, "تنبية")
            End Try
        End If
        Me.ButtonX3.Enabled = False
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text <> "" Then
                xl = l_p(Trim(TextBox1.Text))
                TextBox1.Text = Trim(xl)
                '==================================
                f_a()

                If ww1 = True Then

                    Button5_Click(sender, e)
                Else

                    MsgBox("لا يوجد طلب سحب اصناف بهذا الرقم")
                    Me.ListView1.Clear()
                    ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
                    ListView1.Columns.Add("اسم الصنف", 350, HorizontalAlignment.Left)
                    ListView1.Columns.Add("الكميه", 90, HorizontalAlignment.Center)
                    ListView1.Columns.Add("الوحدة", 87, HorizontalAlignment.Center)
                    ListView1.Columns.Add("العبوة", 87, HorizontalAlignment.Center)
                    ListView1.Columns.Add("رصيد المخزن", 150, HorizontalAlignment.Center)
                    ListView1.Columns.Add("", 0, HorizontalAlignment.Center)
                    clearing()
                    'clearingf()
                    TextBoxX2.Focus()

                    Me.ButtonX2.Enabled = False
                    Me.ButtonX3.Enabled = False
                End If
            Else : Exit Sub

            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        secu_num(e)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class