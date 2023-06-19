Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Public Class Form_TRET
    '================================
    Dim scl As String = "select * from cls"
    Dim adcl As New SqlDataAdapter(scl, cn)
    Dim dscl As New DataSet()
    '====================================
    Dim sj_s As String = "select * from j_s"
    Dim adaj_s As New SqlDataAdapter(sj_s, cn)
    Dim dsaj_s As New DataSet()

    Dim s1 As String = "select * from T_RET"
    Dim ad1 As New SqlDataAdapter(s1, cn)
    Dim ds1 As New DataSet()
    '======================================
    Dim sm As String = "select * from matt"
    Dim adm As New SqlDataAdapter(sm, cn)
    Dim dsm As New DataSet()
    Dim TDm As DataTable
    '======================================
    Dim a As Boolean
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

        If Me.ComboBoxEx4.Text = "" Then
            MsgBox("عفواً..يجب أن تختار الجهة الطالبه ", MsgBoxStyle.Information, "تنبيه")
            ComboBoxEx4.Focus()
            Exit Sub
        End If


        If cn.State = ConnectionState.Closed Then
            cn.Open()

        End If

        Dim s As String = "insert into T_RET(NO_T,date_T,j_s,no_c,qun_T,balance,state) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7)"



        Dim cm As New SqlCommand(s, cn)



        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cm.Parameters.Add(New SqlParameter("@x2", DateTimePicker3.Text))
        cm.Parameters.Add(New SqlParameter("@x3", Me.ComboBoxEx4.Text))
        cm.Parameters.Add(New SqlParameter("@x4", TextBoxX2.Text))
        cm.Parameters.Add(New SqlParameter("@x5", TextBoxX4.Text))
        cm.Parameters.Add(New SqlParameter("@x6", TextBoxX5.Text))
        cm.Parameters.Add(New SqlParameter("@x7", TextBoxX7.Text))



        Try

            cm.ExecuteNonQuery()
            ds1.Clear()
            ad1.Fill(ds1, "T_RET")
            ''TextBoxX1_Leave(sender, e)
            'ListView1.Items.Add(TextBoxX2.Text)
            'ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(TextBoxX3.Text)
            'ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Me.TextBoxX4.Text)
            'ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(ComboBoxEx1.Text)
            'ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(TextBoxX7.Text)
            'ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Me.TextBoxX5.Text)


            clearing()

        Catch
            MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
            Exit Sub
        End Try

        ser()
    End Sub

    'Sub l()
    '    Dim a As Integer
    '    a = Len(TextBox1.Text)
    '    If a = 1 Then
    '        Me.TextBox1.Text = ("00000" + Me.TextBox1.Text)
    '    End If
    '    If a = 2 Then
    '        Me.TextBox1.Text = ("0000" + Me.TextBox1.Text)
    '    End If
    '    If a = 3 Then
    '        Me.TextBox1.Text = ("000" + Me.TextBox1.Text)
    '    End If
    '    If a = 4 Then
    '        Me.TextBox1.Text = ("00" + Me.TextBox1.Text)
    '    End If
    '    If a = 5 Then
    '        Me.TextBox1.Text = ("0" + Me.TextBox1.Text)
    '    End If
    '    If a = 6 Then
    '        Me.TextBox1.Text = ("0" + Me.TextBox1.Text)
    '    End If

    '    If a = 6 Then
    '        mytext = (datt + mytext)

    '    End If
    'End Sub
    Sub add()
        Dim s As String = "select * from T_RET where T_RET.NO_T=(select max(NO_T) from T_RET)"
        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "T_RET")
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
    'Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
    '    add()
    '    l()
    '    clearing()
    'End Sub
    Sub ser()
        Dim dt2 As DataTable

        Dim sql1, n1 As String
        n1 = TextBox1.Text
        If n1 = "" Then

            Exit Sub
        Else

            'f_ar.date_f like  " + "'" + Me.DateTimePicker3.Value.Date + "%" + "' And 

            sql1 = "SELECT * from t_rett WHERE t_rett.NO_T='" + TextBox1.Text + "'"
            Dim da8 As New SqlDataAdapter(sql1, cn)
            Dim ds8 As New DataSet
            ds8.Clear()
            da8.Fill(ds8, "t_rett")
            dt2 = ds8.Tables("t_rett")
            If dt2.Rows.Count > 0 Then

            End If
            ListView1.Clear()
            Dim dr2 As DataRow





            ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
            ListView1.Columns.Add("اسم الصنف", 300, HorizontalAlignment.Left)
            ListView1.Columns.Add("الكميه", 75, HorizontalAlignment.Center)
            ListView1.Columns.Add("الوحدة", 75, HorizontalAlignment.Center)
            ListView1.Columns.Add("العبوة", 75, HorizontalAlignment.Center)
            ListView1.Columns.Add("رصيد المخزن", 200, HorizontalAlignment.Center)


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
                litem.SubItems.Add(dt2.Rows(i).Item("qun_T"))
                litem.SubItems.Add(dt2.Rows(i).Item("name_type"))
                litem.SubItems.Add(dt2.Rows(i).Item("state"))
                litem.SubItems.Add(dt2.Rows(i).Item("balance"))

                ListView1.Items.Add(litem)
            Next i

            ListView1.View = View.Details
        End If
    End Sub
    Sub f_a()


        If (Me.TextBox1.Text.ToString) <> "" Then
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s11 As String = "select * from T_RET where NO_T =@x1"
            Dim cm As New SqlCommand(s11, cn)
            cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader

                If r.Read = True Then

                    a = True

                    Me.DateTimePicker3.Value = r!date_T
                    ComboBoxEx4.Text = r!j_s

                    'Me.ButtonX5.Enabled = True
                    'Me.ButtonX6.Enabled = True

                    'Me.ButtonX2.Enabled = True
                    'Me.ButtonX3.Enabled = True

                    r.Close()
                Else


                    'Me.ButtonX5.Enabled = True
                    'Me.ButtonX6.Enabled = True

                    'Me.ButtonX2.Enabled = True
                    'Me.ButtonX3.Enabled = True
                    a = False

                    r.Close()
                End If
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try

        End If

        '=======================================================================


    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown



        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text <> "" Then
                xl = l_p(Trim(TextBox1.Text))
                TextBox1.Text = Trim(xl)
                f_a()
          
                If a = True Then
                    ser()

                    ButtonX2.Enabled = True
                    ButtonX3.Enabled = True
                    ButtonX5.Enabled = True
                    ButtonX6.Enabled = True
                Else
                    clearing()
                    Me.ListView1.Clear()

                    ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
                    ListView1.Columns.Add("اسم الصنف", 300, HorizontalAlignment.Left)
                    ListView1.Columns.Add("الكميه", 75, HorizontalAlignment.Center)
                    ListView1.Columns.Add("الوحدة", 75, HorizontalAlignment.Center)
                    ListView1.Columns.Add("العبوة", 75, HorizontalAlignment.Center)
                    ListView1.Columns.Add("رصيد المخزن", 200, HorizontalAlignment.Center)
                    Me.ListView1.Clear()
                    DateTimePicker3.Value = (Format(Date.Now, "yyyy/MM/dd"))
                    TextBoxX7.Text = 0
                    ButtonX2.Enabled = False
                    ButtonX3.Enabled = False
                    ButtonX5.Enabled = False
                    ButtonX6.Enabled = False
                    Me.ComboBoxEx4.SelectedIndex = -1
                    TextBoxX2.Focus()
                End If
        Else : Exit Sub

        End If
                End If
    End Sub


    Private Sub Form_TRET_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        add()
        xl = l_p(TextBox1.Text)
        TextBox1.Text = xl
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
        ListView1.Columns.Add("اسم الصنف", 300, HorizontalAlignment.Left)
        ListView1.Columns.Add("الكميه", 75, HorizontalAlignment.Center)
        ListView1.Columns.Add("الوحدة", 75, HorizontalAlignment.Center)
        ListView1.Columns.Add("العبوة", 75, HorizontalAlignment.Center)
        ListView1.Columns.Add("رصيد المخزن", 200, HorizontalAlignment.Center)
        Me.ListView1.Clear()
        DateTimePicker3.Value = (Format(Date.Now, "yyyy/MM/dd"))
        TextBoxX7.Text = 0
      
        ButtonX2.Enabled = False
        ButtonX3.Enabled = False
        ButtonX5.Enabled = False
        ButtonX6.Enabled = False
        Me.ComboBoxEx4.SelectedIndex = -1
    End Sub
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
                'Me.LabelX2.Text = r!no_ct
                'ComboBoxEx4.Enabled = False
                'Me.DateTimePicker3.Enabled = False
                r.Close()
            Else
                r.Close()

                'ComboBoxEx4.Enabled = True
                'Me.DateTimePicker3.Enabled = True
                'MsgBox("هذا الصنف لم يتم تعريفة بعد", MsgBoxStyle.OkOnly, "تنبية")
                'Me.clearing()
                r.Close()
            End If

        Catch
            MsgBox("يوجد خطاءفي بيانات المواد", MsgBoxStyle.Critical, "تنبية")
        End Try

    End Sub
    Private Sub TextBoxX2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxX2.Leave
        stouck()
    End Sub
    Sub clearing()
        Me.TextBoxX2.Clear()
        Me.TextBoxX3.Clear()
        Me.TextBoxX4.Clear()
        TextBoxX5.Clear()
        TextBoxX7.Clear()
        ComboBoxEx1.SelectedIndex = -1

    End Sub
    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "update  T_RET set NO_T=@x1,no_c=@x2,qun_T=@x3,state=@x4 where NO_T=@x1 and no_c=@x2"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
        cm.Parameters.Add(New SqlParameter("@x2", TextBoxX2.Text))
        cm.Parameters.Add(New SqlParameter("@x3", TextBoxX4.Text))
        cm.Parameters.Add(New SqlParameter("@x4", TextBoxX7.Text))
        Try
            cm.ExecuteNonQuery()
            ds1.Clear()
            ad1.Fill(ds1, "T_RET")
            MsgBox("تم التعديل", MsgBoxStyle.Information, "تنبية")
            ser()
            clearing()
            Me.ListView1.Clear()

        Catch
            MsgBox("لايمكنك التعديل في رقم الصنف ورقم الفاتورة  ", MsgBoxStyle.Information, "تنبية")
        End Try
        ButtonX2.Enabled = False
        ButtonX3.Enabled = False
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click

        Dim litem As ListViewItem
        Dim i As Integer
        For Each litem In ListView1.SelectedItems
            Me.TextBoxX2.Text = litem.SubItems(0).Text
            TextBoxX3.Text = litem.SubItems(1).Text
            TextBoxX4.Text = litem.SubItems(2).Text
            ComboBoxEx1.Text = litem.SubItems(3).Text
            Me.TextBoxX7.Text = litem.SubItems(4).Text
            TextBoxX5.Text = litem.SubItems(5).Text
        Next
        Me.ButtonX5.Enabled = True
        Me.ButtonX6.Enabled = True
        Me.ButtonX2.Enabled = True
        Me.ButtonX3.Enabled = True
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim litem As ListViewItem
        Dim i As Integer
        For Each litem In ListView1.SelectedItems
            Me.TextBoxX2.Text = litem.SubItems(0).Text
            TextBoxX3.Text = litem.SubItems(1).Text
            TextBoxX4.Text = litem.SubItems(2).Text
            ComboBoxEx1.Text = litem.SubItems(3).Text
            Me.TextBoxX7.Text = litem.SubItems(4).Text
            TextBoxX5.Text = litem.SubItems(5).Text

        Next
        Me.ButtonX5.Enabled = True
        Me.ButtonX6.Enabled = True
        Me.ButtonX2.Enabled = True
        Me.ButtonX3.Enabled = True


    End Sub



    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        If ListView1.Items.Count < 0 Then
            'If ListView1.FocusedItem.Index = DBNull.Value.ToString Then
            Exit Sub
            'End If
        Else
            ListView1.Items.RemoveAt(ListView1.FocusedItem.Index)


            Dim s As String = "delete from T_RET where NO_T=@x1 and no_c=@x2"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
            cm.Parameters.Add(New SqlParameter("@x2", TextBoxX2.Text))
            If MsgBox("هل أنت متأكد من عملية حدفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then
                Try
                    cm.ExecuteNonQuery()
                    ds1.Clear()
                    ad1.Fill(ds1, "T_RET")
                    MsgBox("تم الحذف", MsgBoxStyle.Information, "تنبية")

                    ser()
                    clearing()
                    Me.ListView1.Clear()

                Catch
                    MsgBox("لايمـكـن الـحـذف", MsgBoxStyle.SystemModal, "تنبية")
                End Try
            Else
                Exit Sub
            End If
        End If
        clearing()
        ButtonX2.Enabled = False
        ButtonX3.Enabled = False

    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "update T_RET set NO_T=@x1,date_T=@x2,j_s=@x3  where NO_T=@x1"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
        cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
        cm.Parameters.Add(New SqlParameter("@x3", Me.ComboBoxEx4.Text))

        Try
            cm.ExecuteNonQuery()
            ds1.Clear()
            ad1.Fill(ds1, "T_RET")

            MsgBox("تم التعديل", MsgBoxStyle.Information, "تنبية")
            clearing()

            Me.ListView1.Clear()
            ser()

        Catch
            MsgBox("لايمكنك التعديل في رقم الفاتورة  ", MsgBoxStyle.Information, "تنبية")
        End Try
    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click

        If cn.State = ConnectionState.Closed Then
            cn.Open()

        End If

        Dim s As String = "delete from T_RET where  NO_T=@x1"
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
        If MsgBox("هل أنت متأكد من عملية حدفك لهذا السجل؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then

            Try
                cm.ExecuteNonQuery()
                ds1.Clear()
                ad1.Fill(ds1, "T_RET")
                Me.ListView1.Clear()
                clearing()
                Me.ListView1.Clear()
                ser()

            Catch
                MsgBox("لايمـكـن الـحـذ ف", MsgBoxStyle.SystemModal, "تنبية")
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub TextBoxX4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX4.KeyPress, TextBoxX7.KeyPress
        secu_num(e)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If TextBox1.Text <> "" Then

            Dim adp As New SqlDataAdapter("SELECT NO_T,date_T, j_s,no_c, name_snc, cast([qun_T] as nvarchar(50)) as qun_T ,name_type,state,cast([balance] as nvarchar(50)) as balance, no_ct1 from t_rett WHERE t_rett.NO_T= '" + TextBox1.Text + "'", cn)

            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_T")) = "int" Then
                    dt.Rows(i).Item("qun_T") = myNo
                Else
                    dt.Rows(i).Item("qun_T") = FormatNumber(CDec(dt.Rows(i).Item(5)), 3)
                End If
                If checkNum(dt.Rows(i).Item("balance")) = "int" Then
                    dt.Rows(i).Item("balance") = myNo
                Else
                    dt.Rows(i).Item("balance") = FormatNumber(CDec(dt.Rows(i).Item(8)), 3)
                End If

            Next

            Dim frm As New Form12

            Dim rpt1 As New CrystalReport21

            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1




            Dim Text22 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text22")
            Text22.Text = branch



            frm.ShowDialog()

        Else : Exit Sub
        End If



    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        clearing()
        add()
        xl = l_p(TextBox1.Text)
        TextBox1.Text = xl

        ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("اسم الصنف", 300, HorizontalAlignment.Left)
        ListView1.Columns.Add("الكميه", 75, HorizontalAlignment.Center)
        ListView1.Columns.Add("الوحدة", 75, HorizontalAlignment.Center)
        ListView1.Columns.Add("العبوة", 75, HorizontalAlignment.Center)
        ListView1.Columns.Add("رصيد المخزن", 200, HorizontalAlignment.Center)

        Me.ListView1.Clear()
        DateTimePicker3.Value = (Format(Date.Now, "yyyy/MM/dd"))
        TextBoxX7.Text = 0
        ButtonX2.Enabled = False
        ButtonX3.Enabled = False
        ButtonX5.Enabled = False
        ButtonX6.Enabled = False
        Me.ComboBoxEx4.SelectedIndex = -1
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
End Class