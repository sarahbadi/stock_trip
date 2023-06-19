Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports Microsoft.VisualBasic
Public Class F_T
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
    Dim i As Integer
    '================================
    Dim scl As String = "select * from cls"
    Dim adcl As New SqlDataAdapter(scl, cn)
    Dim dscl As New DataSet()
    '====================================
    Dim f As Boolean
    Dim no_fd As String
    Private Sub F_T_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtYear.Value = dateNowDB

        Me.DateTimePicker3.Value = dateNowDB

        TextBox1.Text = getNewNo(Me.dtYear.Value.Year, "GetNewNoTALEF")
        ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("اسم الصنف", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("الكميه", 75, HorizontalAlignment.Center)
        ListView1.Columns.Add("سعر الوحدة", 75, HorizontalAlignment.Center)
        ListView1.Columns.Add("رصيد المخزن", 100, HorizontalAlignment.Center)


        adcl.Fill(dscl, "cls")
        ComboBoxEx1.DataSource = dscl
        ComboBoxEx1.DisplayMember = "cls.name_type"
        ComboBoxEx1.ValueMember = "no_type"
        Me.ButtonX1.Enabled = False
        Me.ButtonX4.Enabled = False

    End Sub
    Sub clearing()

        Me.TextBoxX4.Clear()
        Me.TextBoxX5.Clear()
        Me.TextBoxX7.Clear()
        Me.TextBoxX3.Clear()
        Me.TextBoxX2.Clear()

    End Sub
    Sub clearing_T()

        Me.RadioButton1.Checked = False
        Me.RadioButton2.Checked = False
        Me.DateTimePicker3.Value = Now

    End Sub
    Sub add()
        Dim s As String = "select * from TALEF where TALEF.NO_T=(select max(NO_T) from TALEF)"
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBoxX10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked


        TextBox1.Text = getNewNo(Me.dtYear.Value.Year, "GetNewNoTALEF")
        'clearing_T()
        'clearing()
    End Sub

    Private Sub TextBoxX2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxX2.Leave

        Me.TextBoxX4.Clear()
        Me.TextBoxX5.Clear()
        Me.TextBoxX7.Clear()
        Me.TextBoxX3.Clear()

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


        Dim ds1 As DataSet
        ds1 = New DataSet
        ds1.Clear()
        Dim s1 As String = "select no_c as [رقم الصنف],sal_s as[سعر الوحدة],qss as[المخزون] from bal_no where no_c ='" + Me.TextBoxX2.Text + "'  and qss<>0"
        Dim ad1 As New SqlDataAdapter(s1, cn)
        ad1.Fill(ds1, "bal_no")
        Me.DataGridViewx1.DataSource = ds1
        Me.DataGridViewX1.DataMember = "bal_no"
        DataGridViewx1.Refresh()
        cn.Close()


    End Sub


    Private Sub TextBoxX2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX2.TextChanged

    End Sub

    Private Sub DataGridViewX1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick
        If DataGridViewX1.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub
        '***************************
        If (DataGridViewX1.SelectedRows.Count = 0) Then
            MessageBox.Show("لاتوجد عناصر تم اختارها")
        End If

        'Me.TextBox2.Text = DataGridView1.SelectedCells.Item(0).Value.ToString
        If cn.State = ConnectionState.Closed Then cn.Open()
        Me.TextBoxX2.Text = ""
        For i = 0 To DataGridViewX1.RowCount - 1


            'If Me.DataGridViewX2.Rows(i).Cells.Item(0).Value = True Then
            TextBoxX2.Text = DataGridViewX1.CurrentRow.Cells(0).Value.ToString
            TextBoxX7.Text = DataGridViewX1.CurrentRow.Cells(1).Value.ToString
            TextBoxX5.Text = DataGridViewX1.CurrentRow.Cells(2).Value.ToString
        Next

    End Sub

    Private Sub DataGridViewX1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewX1.Click
        If DataGridViewX1.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub

        If cn.State = ConnectionState.Closed Then cn.Open()

        For i = 0 To DataGridViewX1.RowCount - 1


            'If Me.DataGridViewX2.Rows(i).Cells.Item(0).Value = True Then
            TextBoxX2.Text = DataGridViewX1.CurrentRow.Cells(0).Value.ToString
            TextBoxX7.Text = DataGridViewX1.CurrentRow.Cells(1).Value.ToString
            TextBoxX5.Text = DataGridViewX1.CurrentRow.Cells(2).Value.ToString
        Next
    End Sub
    Sub sersch()


        If Me.TextBox1.Text <> " " Then

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s As String = "SELECT * from TALEF where NO_T =@x1 "
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add("@x1", TextBox1.Text)

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
    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        clearing()
        clearing_T()
        l()
        sersch()
        If f = False Then
            MsgBox(" محضرالمواد التالفه غير موجود ", MsgBoxStyle.Information, "تنبية")
        Else
            viwe()
            Exit Sub
        End If
    End Sub
    Sub viwe()


        If f = True Then
            Dim dt2 As DataTable
            Dim sql1, n1 As String
            n1 = TextBox1.Text
            If n1 = "" Then
                Exit Sub
            Else

                'Dim s As String = "select * from f_ar WHERE f_ar.date_f like  " + "'" + Me.DateTimePicker1.Value.Date + "%" + "' And f_ar.no_f = " & Me.TextBox6.Text & ""
                sql1 = "SELECT * from sub_TALEF WHERE  sub_TALEF.no_t='" + TextBox1.Text + "'"
                Dim da8 As New SqlDataAdapter(sql1, cn)
                Dim ds8 As New DataSet
                ds8.Clear()
                da8.Fill(ds8, "sub_TALEF")
                dt2 = ds8.Tables("sub_TALEF")
                If dt2.Rows.Count > 0 Then

                End If
                ListView1.Clear()
                Dim dr2 As DataRow

                ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
                ListView1.Columns.Add("اسم الصنف", 150, HorizontalAlignment.Left)
                ListView1.Columns.Add("الكميه", 75, HorizontalAlignment.Center)
                ListView1.Columns.Add("سعر الوحدة", 75, HorizontalAlignment.Center)
                ListView1.Columns.Add("رصيد المخزن", 100, HorizontalAlignment.Center)

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
                    litem.SubItems.Add(dt2.Rows(i).Item("praice"))
                    litem.SubItems.Add(dt2.Rows(i).Item("balance"))




                    ListView1.Items.Add(litem)
                Next i

                ListView1.View = View.Details
            End If
        Else
            Me.ListView1.Clear()
            ListView1.Columns.Add("رقم الصنف", 100, HorizontalAlignment.Center)
            ListView1.Columns.Add("اسم الصنف", 150, HorizontalAlignment.Left)
            ListView1.Columns.Add("الكميه", 75, HorizontalAlignment.Center)
            ListView1.Columns.Add("سعر الوحدة", 75, HorizontalAlignment.Center)
            ListView1.Columns.Add("رصيد المخزن", 100, HorizontalAlignment.Center)

            Exit Sub
        End If

    End Sub


    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        Dim litem As ListViewItem
        Dim i As Integer
        For Each litem In ListView1.SelectedItems
            Me.TextBoxX2.Text = litem.SubItems(0).Text
            TextBoxX3.Text = litem.SubItems(1).Text
            TextBoxX4.Text = litem.SubItems(2).Text
            Me.TextBoxX7.Text = litem.SubItems(3).Text
            TextBoxX5.Text = litem.SubItems(4).Text
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
            Me.TextBoxX2.Text = litem.SubItems(0).Text
            TextBoxX3.Text = litem.SubItems(1).Text
            TextBoxX4.Text = litem.SubItems(2).Text
            Me.TextBoxX7.Text = litem.SubItems(3).Text
            TextBoxX5.Text = litem.SubItems(4).Text

        Next
        Me.ButtonX5.Enabled = True
        Me.ButtonX6.Enabled = True
        Me.ButtonX1.Enabled = True
        Me.ButtonX3.Enabled = True
        Me.ButtonX4.Enabled = True


    End Sub

    Private Sub TextBoxX3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX3.TextChanged

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
        l()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        Dim s As String = "update  sub_TALEF set no_t=@x1,no_c=@x2,qun_T=@x4,praice=@x5,balance=@x6 where no_t=@x1 and no_c=@x2 "
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
        cm.Parameters.Add(New SqlParameter("@x2", TextBoxX2.Text))
        cm.Parameters.Add(New SqlParameter("@x4", TextBoxX4.Text))
        cm.Parameters.Add(New SqlParameter("@x5", TextBoxX7.Text))
        cm.Parameters.Add(New SqlParameter("@x6", TextBoxX5.Text))
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

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click


        sersch()


        If TextBoxX2.Text = "" Then
            MsgBox("عفواً..يجب أن تدخل  رقم الصنف ", MsgBoxStyle.Information, "تنبيه")
            TextBoxX2.Focus()
            Exit Sub
        End If
        If Me.RadioButton1.Checked = False And Me.RadioButton2.Checked = False Then
            MsgBox("عفواً..يجب أن تختار سبب التلف ", MsgBoxStyle.Information, "تنبيه")

            Exit Sub
        End If

        If TextBoxX5.Text = "" Or TextBoxX7.Text = "" Then
            MsgBox("انقر على المخزن لتحديد السعر ورصيد المخزن  ", MsgBoxStyle.Information, "إجراء إضافة")

            Exit Sub
        End If
        If TextBoxX4.Text = "" Then
            MsgBox("عفواً..يجب أن تدخل  الكمية ", MsgBoxStyle.Information, "تنبيه")
            TextBoxX4.Focus()
            Exit Sub
        End If



        If f = True Then

            If cn.State = ConnectionState.Closed Then
                cn.Open()

            End If

            Dim s As String = "insert into sub_TALEF(no_t,no_c,name_snc,qun_T,praice,balance) values (@x1,@x2,@x3,@x4,@x5,@x6)"
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
            cm.Parameters.Add(New SqlParameter("@x2", TextBoxX2.Text))
            cm.Parameters.Add(New SqlParameter("@x3", TextBoxX3.Text))
            cm.Parameters.Add(New SqlParameter("@x4", TextBoxX4.Text))
            cm.Parameters.Add(New SqlParameter("@x5", TextBoxX7.Text))
            cm.Parameters.Add(New SqlParameter("@x6", Me.TextBoxX5.Text))

            Try
                cm.ExecuteNonQuery()
                ds11.Clear()
                ad11.Fill(ds11, "sub_TALEF")
                viwe()
                clearing()
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

            cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
            cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
            cm.Parameters.Add(New SqlParameter("@x3", Me.RadioButton1.Checked))
            cm.Parameters.Add(New SqlParameter("@x4", Me.RadioButton2.Checked))

            Try
                cm.ExecuteNonQuery()
                ds1.Clear()
                ad1.Fill(ds1, "TALEF")

            Catch
                MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
                Exit Sub
            End Try


            Dim sm As String = "insert into sub_TALEF(no_t,no_c,name_snc,qun_T,praice,balance) values (@x1,@x2,@x3,@x4,@x5,@x6)"
            Dim cm1 As New SqlCommand(sm, cn)

            cm1.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
            cm1.Parameters.Add(New SqlParameter("@x2", TextBoxX2.Text))
            cm1.Parameters.Add(New SqlParameter("@x3", TextBoxX3.Text))
            cm1.Parameters.Add(New SqlParameter("@x4", TextBoxX4.Text))
            cm1.Parameters.Add(New SqlParameter("@x5", TextBoxX7.Text))
            cm1.Parameters.Add(New SqlParameter("@x6", Me.TextBoxX5.Text))



            Try
                cm1.ExecuteNonQuery()
                ds11.Clear()
                ad11.Fill(ds11, "sub_TALEF")
                viwe()
                clearing()
                Me.ListView1.Clear()

            Catch
                MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
                Exit Sub
            End Try


        End If
        'clearing()
        'Me.ListView1.Clear()

        viwe()

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
            cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
            cm.Parameters.Add(New SqlParameter("@x2", TextBoxX2.Text))
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
        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If TextBox1.Text <> "" Then

            Dim ds As DataSet3
            ds = New DataSet3
            ds.Clear()
            Dim f As New Form12
            Dim sad As SqlDataAdapter
            Dim t1 As DataTable
            Dim s As String = "select * from tt_talf WHERE tt_talf.no_t= '" + TextBox1.Text + "'"
            sad = New SqlDataAdapter(s, cn)
            sad.Fill(ds, s)
            t1 = ds.Tables(s)

            Dim rpt1 As New CrystalReport5
            Application.DoEvents()
            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
            f.CrystalReportViewer1.ReportSource = rpt1
            Dim Text16 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text16")
            Text16.Text = branch
            rpt1.SetDataSource(t1)
            f.CrystalReportViewer1.ReportSource = rpt1
            'f.CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.Password = "3573"


            f.ShowDialog()
            ds.Clear()
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
        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
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
            cmv.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
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
        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
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

    Private Sub TextBoxX4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX4.KeyPress
        secu_num(e)
    End Sub

    Private Sub TextBoxX4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX4.TextChanged

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class