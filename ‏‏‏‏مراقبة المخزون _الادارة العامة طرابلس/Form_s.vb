
Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports CrystalDecisions.CrystalReports.Engine


Public Class Form_s
    Dim i As New Integer

    Dim move_no, no_stock As String
    Dim tot, eror_m, s_n As Boolean
    Dim sum_irct, sum_iiss, sum_return, total_s, sum_talf As New Decimal()
    Dim siopb As Integer
    Dim smt As String = "select * from matt"
    Dim admt As New SqlDataAdapter(smt, cn)
    Dim dsmt As New DataSet()
    Dim TDmt As DataTable
    '======================================
    Dim s1 As String = "select * from RcvSub"
    Dim adRcvS As New SqlDataAdapter(s1, cn)
    Dim dsRcvS As New DataSet()
    '===========================
    Dim s2 As String = "select * from RcvMain"
    Dim adRcvM As New SqlDataAdapter(s2, cn)
    Dim dsRcvM As New DataSet()
    '===========================
    Dim s22 As String = "select * from acthion_tran"
    Dim adact As New SqlDataAdapter(s22, cn)
    Dim dsact As New DataSet()
    '======================================

    Dim stran As String = "select * from tran_IRT"
    Dim adtran As New SqlDataAdapter(stran, cn)
    Dim dstran As New DataSet()

    Dim strsalahia As String = "select * from salahia"
    Dim adsalahia As New SqlDataAdapter(strsalahia, cn)
    Dim dssalahia As New DataSet()
    '===============
    Dim txt_s As String
    Dim mt As String
    Dim date_end As Date
    Dim mdh_a As String
    Dim mdh As String
    Dim date_mdh As String
    Dim no_c As String
    Dim qun_r As Int32
    Dim sal_s As Decimal
    Dim gema As Decimal
    '===========================
    Dim dateS, dateN As Date


    Dim scl As String = "select * from cls"
    Dim adcl As New SqlDataAdapter(scl, cn)
    Dim dscl As New DataSet()

    '============================
    Dim sksf As String = "select * from ksf"
    Dim adksf As New SqlDataAdapter(sksf, cn)
    Dim dsksf As New DataSet()

    '===========================
    Dim s As String = "select * from j_r"
    Dim ada As New SqlDataAdapter(s, cn)
    Dim dsa As New DataSet()
    '======================================

    Private Sub Form_s_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'If cn.State = ConnectionState.Closed Then
        '    cn.Open()
        'End If
        'Dim s1 As String = "SELECT n_type FROM ksf"
        'Dim ds3 As New DataSet
        'Dim ad1 = New SqlDataAdapter(s1, cn)
        'ad1.Fill(ds3, "ksf") 'list can be any name u want
        'Dim col As New AutoCompleteStringCollection
        'Dim i As Integer
        'For i = 0 To ds3.Tables(0).Rows.Count - 1
        '    col.Add(ds3.Tables(0).Rows(i)("n_type").ToString())
        'Next
        'Me.ComboBox3.AutoCompleteSource = AutoCompleteSource.CustomSource
        'Me.ComboBox3.AutoCompleteCustomSource = col
        'Me.ComboBox3.AutoCompleteMode = AutoCompleteMode.Suggest
        'cn.Close()

    End Sub
    'Private Sub AutocomplateCustomSource()

    '    On Error Resume Next
    '    Dim i As Integer
    '    ' ''cn.Open()
    '    Dim da As New SqlDataAdapter("Select name_snc From matt", cn)
    '    Dim ds As New DataSet
    '    da.Fill(ds)
    '    For i = 0 To ds.Tables(0).Rows.Count - 1
    '        TextBox11.AutoCompleteCustomSource.Add(ds.Tables(0).Rows(i)(0))

    '    Next i
    '    cn.Close()
    'End Sub

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
            cn.Close()
        Catch ex As Exception
            Me.TextBox8.Text = "1"
            cn.Close()
        End Try

        ad.Dispose()
        ds.Dispose()


        cn.Close()

    End Sub

    Sub tot_ins()
        If Me.TextBox8.Text <> "" Then

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
            Me.Label1.Text = CDbl(inf_t)
            cn.Close()


            ''===========================================
            'If cn.State = ConnectionState.Closed Then
            '    cn.Open()
            'End If

            'Dim ss As String = "update RcvMain set no_i=@x1,g_b=@x2,tvg=@x3 where no_i=@x1"
            'Dim cms As New SqlCommand(ss, cn)
            'cms.Parameters.Add((New SqlParameter("@x1", Trim(TextBox8.Text))))
            'cms.Parameters.Add(New SqlParameter("@x2", Label1.Text))
            'cms.Parameters.Add(New SqlParameter("@x3", Me.Label2.Text))
            'Try
            '    cms.ExecuteNonQuery()
            '    dsRcvM.Clear()
            '    adRcvM.Fill(dsRcvM, "RcvMain")
            '    cn.Close()
            'Catch err As System.Exception
            '    MsgBox(err.Message)
            'End Try
            'cn.Close()
        End If
    End Sub
    Sub stouck()

        Dim i, w As Integer
        'Dim qt As Boolean

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sql As String = "select * from RcvSub where RcvSub.[no_c]='" + TextBox1.Text + "'"
        Dim ad1 As New SqlDataAdapter(sql, cn)
        Dim ds1 As New DataSet()
        Dim TD1 As DataTable
        Dim DROW1 As DataRow
        Dim y As Decimal
        y = 0.0
        sum_irct = 0.0
        ad1.Fill(ds1, sql)
        TD1 = ds1.Tables(sql)

        For i = 0 To TD1.Rows.Count - 1
            DROW1 = TD1.Rows(i)
            If DROW1("no_c") = (TextBox1.Text) Then

                y = Val(DROW1("qun_r"))
                sum_irct = sum_irct + y
            End If

        Next
        cn.Close()
        '===============اجمالي المصروف==================

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq3 As String = "select * from IsuSub where IsuSub.[no_c] ='" + TextBox1.Text + "'"

        Dim ad3 As New SqlDataAdapter(sq3, cn)
        Dim ds3 As New DataSet()
        Dim TD3 As DataTable
        Dim DROW3 As DataRow
        Dim y2 As Decimal
        Me.sum_iiss = 0.0
        y2 = 0.0
        ad3.Fill(ds3, sq3)
        TD3 = ds3.Tables(sq3)

        For w = 0 To TD3.Rows.Count - 1
            DROW3 = TD3.Rows(w)
            If DROW3("no_c") = (TextBox1.Text) Then

                y2 = Val(DROW3("qun_s"))
                sum_iiss = sum_iiss + y2

            End If
        Next
        cn.Close()
        '===============اجمالي مرتجعه==================


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq4 As String = "select * from matt_return where matt_return.[no_c] ='" + TextBox1.Text + "'"

        Dim ad4 As New SqlDataAdapter(sq4, cn)
        Dim ds4 As New DataSet()
        Dim TD4 As DataTable
        Dim DROW4 As DataRow
        Dim y4 As Decimal
        'Me.sum_iiss = 0
        y4 = 0.0
        ad4.Fill(ds4, sq4)
        TD4 = ds4.Tables(sq4)

        For w = 0 To TD4.Rows.Count - 1
            DROW4 = TD4.Rows(w)

            If DROW4("no_c") = (TextBox1.Text) Then

                y4 = Val(DROW4("qun_t"))
                sum_return = sum_return + y4

            End If
        Next
        cn.Close()
        '===============تالف==================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq5 As String = "select * from sub_TALEF where sub_TALEF.[no_c] ='" + TextBox1.Text + "'"

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

            If DROW5("no_c") = (TextBox1.Text) Then

                y5 = Val(DROW5("qun_T"))
                sum_talf = sum_talf + y5

            End If
        Next
        cn.Close()
        Me.total_s = 0


        Me.total_s = ((sum_irct + sum_return) - sum_iiss) - sum_talf

        '=======================================================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        If Me.RadioButton1.Checked = True Then
            siopb = TextBox6.Text
            Dim s1 As String = "update  matt set no_c=@x1,balance=@x2,iopb=@x3,irct=@x5 where no_c=@x1"
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cm1.Parameters.Add(New SqlParameter("@x2", total_s))
            cm1.Parameters.Add(New SqlParameter("@x3", Me.siopb))
            cm1.Parameters.Add(New SqlParameter("@x5", sum_irct))

            Try
                cm1.ExecuteNonQuery()
                dsmt.Clear()
                admt.Fill(dsmt, " matt")
            Catch
            End Try

        Else
            Dim s1 As String = "update  matt set no_c=@x1,balance=@x2,irct=@x5 where no_c=@x1"
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cm1.Parameters.Add(New SqlParameter("@x2", total_s))
            cm1.Parameters.Add(New SqlParameter("@x5", sum_irct))

            Try
                cm1.ExecuteNonQuery()
                dsmt.Clear()
                admt.Fill(dsmt, " matt")
            Catch
            End Try

        End If
        cn.Close()
    End Sub
    
    Sub zero_no()
        'تصفير=======
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "select no_i,no_i1 from View_maxdate where View_maxdate.no_i=(select max(no_i) from View_maxdate)"
        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "View_maxdate")
        tb = ds.Tables(0)
        Dim dr As DataRow
        Try
            dr = tb.Rows(0)


            If dr(1) < Year(Now) Then

                Me.TextBox8.Text = dr(0) + 1
            Else
                Me.TextBox8.Text = "1"
            End If
            cn.Close()
        Catch ex As Exception
            Me.TextBox8.Text = "1"
            cn.Close()
        End Try

        ad.Dispose()
        ds.Dispose()
        cn.Close()
    End Sub



    Private Sub Form_s_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load




        Label5.Text = ""
        Me.dtYear.Value = dateNowDB
        Me.DateTimePicker3.Value = dateNowDB

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        'Label11.Text = My.Application.Info.Copyright
        ComboBox2.Text = "لايوجد"
        TextBox13.Text = "0"
        Me.RadioButton6.Checked = True
        Me.Button6.Enabled = False
        Dim s As String = "select * from j_r"
        Dim ada As New SqlDataAdapter(s, cn)
        Dim dsa As New DataSet()
        ada.Fill(dsa, "j_r")
        ComboBox1.DataSource = dsa
        ComboBox1.DisplayMember = "j_r.name_r"
        ComboBox1.ValueMember = "no_r"
        '---------------------------
        ComboBox1.SelectedIndex = -1
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim s1 As String = "select 0 as type_k,'من دون تحديد' as n_type union all  select type_k,n_type from ksf"
        Dim ada1 As New SqlDataAdapter(s1, cn)
        Dim dsa1 As New DataSet()
        ada1.Fill(dsa1, "ksf")
        ComboBox3.DataSource = dsa1
        ComboBox3.DisplayMember = "ksf.n_type"
        ComboBox3.ValueMember = "type_k"
        ComboBox3.SelectedIndex = -1
        'ComboBox3.SelectedValue = 1
        ComboBox3.SelectedValue = ssf_t
        '-----------------------------
        If ssf_t = 0 Then
            ComboBox3.Enabled = True
        Else
            ComboBox3.Enabled = False

        End If



        cn.Close()
        langarabic()
        TextBox3.Text = ""
        'Label9.Text = sefa
        Me.Button2.Enabled = False
        'Me.Button8.Enabled = False

        If Im_tadel = "جديد" Then
            total_inf_new()
            Me.Panel2.Visible = False
            Me.dtYear.Visible = True
            Me.Label11.Visible = True
            'Me.Button8.Visible = False
            DateTimePicker3.Value = (Format(Date.Now, "yyyy/MM/dd"))
        End If

        If Im_tadel = "تعديل" Then
            Me.dtYear.Visible = False
            'Me.Button8.Visible = True
            Me.Label11.Visible = False
            total_inf_tadel()
            Me.Panel2.Visible = True
            If ssf_t = 0 Then
                ComboBox3.Enabled = True
            Else
                ComboBox3.Enabled = False

            End If
        End If
    End Sub
    Sub total_inf_new()
        'TextBox8.Text = CStr(TextBox17.Text)
        If (Me.TextBox8.Text.ToString) <> " " Then
            '------------------------------
            '===================================
            If Im_tadel = "جديد" And (sefa = "امين مخزن" Or sefa = "موظف") Then
                Me.DataGridViewX2.Rows.Clear()
                Me.Panel2.Enabled = False
                TextBox8.Text = getNewNo(Me.dtYear.Value.Year, ssf_t, "GetNewNoRcvMain")

                '----------------------------
                Me.Button3.Enabled = False
                Me.Button4.Enabled = False
                Me.Button5.Enabled = False
                Me.Button6.Enabled = False
                'Me.Button8.Enabled = False
                Me.Button2.Visible = True
                Me.Panel2.Enabled = False
            End If


            

            '============================

        End If
        cn.Close()





    End Sub
    Sub View_matt()
        Dim dt2 As DataTable
        Dim sql1 As String

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        sql1 = "SELECT * from View_matt where n_type =N'" + Me.ComboBox3.Text + "'ORDER BY no_ct1"
        Dim da8 As New SqlDataAdapter(sql1, cn)
        Dim ds8 As New DataSet
        ds8.Clear()
        da8.Fill(ds8, "View_matt")
        dt2 = ds8.Tables("View_matt")
        If dt2.Rows.Count > 0 Then

        End If
        ListView2.Clear()

        Dim dr2 As DataRow



        ListView2.Columns.Add("رقم الصنف ", 75, HorizontalAlignment.Center)
        ListView2.Columns.Add("اسم الصنف ", 270, HorizontalAlignment.Left)
        ListView2.Columns.Add("0 ", 0, HorizontalAlignment.Left)
        ListView2.Columns.Add("0 ", 0, HorizontalAlignment.Left)
        Dim sdl As Short = 1
        ListView2.Items.Clear()
        Dim i, c As Integer
        c = dt2.Rows.Count - 1
        For i = 0 To c
            Dim litem As New ListViewItem
            dr2 = dt2.Rows.Item(i)
            litem.Text = dt2.Rows(i).Item("no_c")
            litem.SubItems.Add(dt2.Rows(i).Item("name_snc"))
            litem.SubItems.Add(dt2.Rows(i).Item("name_type"))
            litem.SubItems.Add(dt2.Rows(i).Item("iopb"))
            ListView2.Items.Add(litem)
        Next i
        ListView2.Sorting = SortOrder.Ascending
        cn.Close()
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Me.clear_tool_1()
        Dim litem As ListViewItem
        'Dim i As Integer
        For Each litem In ListView2.SelectedItems
            Me.TextBox1.Text = litem.SubItems(0).Text
            Me.TextBox11.Text = litem.SubItems(1).Text
            Me.TextBox16.Text = litem.SubItems(2).Text
            Me.TextBox4.Text = litem.SubItems(3).Text
        Next
        Button2.Enabled = True


    End Sub





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim k As New Fw_part
        k.GroupPanel1.Text = "الكشوفات"
        k.Label1.Text = "اسم الكشف"
        k.Label2.Visible = True
        k.TextBox1.Visible = True
        k.ButtonX5.Visible = True
        k.ShowDialog()
        '============================
        dsksf.Clear()
        adksf.Fill(dsksf, "ksf")
        ComboBox3.DataSource = dsksf
        ComboBox3.DisplayMember = "ksf.n_type"
        ComboBox3.ValueMember = "type_k"
        '================================
        cn.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        Dim k As New F_part
        k.GroupPanel1.Text = "الجهات الموردة"
        k.Label1.Text = "جهة التوريد"
        k.TextBox3.Visible = False
        k.ShowDialog()


        dsa.Clear()
        ada.Fill(dsa, "j_r")
        ComboBox1.DataSource = dsa
        ComboBox1.DisplayMember = "j_r.name_r"
        ComboBox1.ValueMember = "no_r"
        cn.Close()
    End Sub

    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        If TextBox13.Text = "" Then
            MsgBox("ادخل بيانات الصلاحية ", MsgBoxStyle.Information, "تنبية")
            TextBox13.Text = 0
            Exit Sub
        End If
        If ComboBox2.Text = "لايوجد" Or TextBox13.Text = "0" Then
            TextBox12.Text = 0
            'MsgBox(" هذا الصنف لم تدخل له بيانات الصلاحية", MsgBoxStyle.Information, "تنبية")
            Exit Sub


        Else
            slhia(TextBox13.Text)
        End If



    End Sub
    Function slhia(ByVal mytext As Integer) As Integer
        'اقل من تاريخ اليوم

        Dim mdh As Integer
        Dim y, d As Date


        'mdh = mytext
        'd = DateTimePicker2.Value
        'y = Date.Now.AddDays(-mdh)
        'TextBox12.Text = y

        mdh = mytext
        d = Format(DateTimePicker2.Value.Date, "yyyy/MM/dd")

        If Me.ComboBox2.Text = "ايام" Then
            TextBox12.Text = d.AddDays(-mdh)
            'TextBox4.Text = mdh
        End If
        If ComboBox2.Text = "اسابيع" Then
            mdh = 7 * mdh
            TextBox12.Text = d.AddDays(-mdh)
            'TextBox4.Text = mdh
        End If
        If ComboBox2.Text = "اشهر" Then
            mdh = 31 * mdh
            TextBox12.Text = d.AddDays(-mdh)
        End If

        If ComboBox2.Text = "سنة" Then
            mdh = (12 * 30) * mdh
            TextBox12.Text = d.AddDays(-mdh)
        End If
        '===================================================


    End Function

    Sub clear_tool()
        TextBox5.Text = ""
        TextBox2.Text = "بلا"
        TextBox11.Text = ""
        TextBox1.Text = ""
        TextBox6.Text = 0
        TextBox9.Text = 0.0
        TextBox10.Text = 0.0
        ComboBox2.Text = "لايوجد"
        TextBox13.Text = "0"
        TextBox12.Text = 0
        RichTextBox1.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        DateTimePicker2.Value = (Format(Date.Now, "yyyy/MM/dd"))
        TextBox15.Text = "1990/01/01"
        'DateTimePicker3.Value = (Format(Date.Now, "yyyy/MM/dd"))
        TextBox16.Text = ""
    End Sub
    Sub clear_tool_1()

        TextBox11.Text = ""
        TextBox1.Text = ""
        TextBox6.Text = 0
        TextBox9.Text = 0.0
        TextBox10.Text = 0.0
        ComboBox2.Text = "لايوجد"
        TextBox13.Text = "0"
        TextBox12.Text = 0
        RichTextBox1.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        DateTimePicker2.Value = (Format(Date.Now, "yyyy/MM/dd"))

        TextBox16.Text = ""
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        If Me.TextBox8.Text.ToString = "" Then
            MsgBox("أدخل رقم اذن الاستلام ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox8.Focus()
            Exit Sub
        End If

        If Me.ComboBox1.SelectedIndex = -1 Then
            MsgBox(" اختار جهة التوريد", MsgBoxStyle.Information, "إجراء إضافة")
            ComboBox1.Focus()
            Exit Sub
        End If
        If Me.TextBox5.Text.ToString = "" Then
            MsgBox("ادخل الاصناف واردة بموجب:  ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox5.Focus()
            Exit Sub
        End If


        If Me.TextBox1.Text = "" Then
            MsgBox("أدخل رقم الصنف المرادإضافته ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox1.Focus()

            Exit Sub
        End If
        If Val(Me.TextBox6.Text).ToString = "" Or Val(Me.TextBox6.Text) = 0 Then
            MsgBox("أدخل الكمية المراد استلامها", MsgBoxStyle.Information, " إجراء إضافة")
            TextBox6.Focus()
            Exit Sub
        End If

        If Me.TextBox9.Text.ToString = "" Or Me.TextBox9.Text = "0.000" Or Me.TextBox9.Text = "0" Or Me.TextBox9.Text = "0.00" Then
            MsgBox("ادخل سعر الوحدة", MsgBoxStyle.Information, "إجراء إضافة ")
            TextBox9.Focus()
            Exit Sub
        End If
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MsgBox("اختار  اما رصيد منقول او اضافه", MsgBoxStyle.Information, "إجراء إضافة ")
            Exit Sub
        End If

        If (Me.TextBox13.Text.ToString <> 0) And (ComboBox2.Text = "لايوجد" Or ComboBox2.Text = "") Then
            MsgBox("راجع المدة ونوع المدة ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox13.Focus()
            Exit Sub
        End If


        If ComboBox2.Text <> "لايوجد" Or TextBox13.Text <> "0" Then
            slhia(TextBox13.Text)
        End If

        If Format(DateTimePicker2.Value.Date, "yyyy/MM/dd") <= Format(Date.Now, "yyyy/MM/dd") And (Me.TextBox13.Text.ToString <> 0) And ((ComboBox2.Text <> "لايوجد" Or ComboBox2.Text = "")) Then
            MsgBox("تاريخ انتهاء الصلاحية يساوي اليوم  ", MsgBoxStyle.Information, "إجراء إضافة")

            Exit Sub
        End If

        If Me.TextBox3.Text.ToString = "" Then
            MsgBox("أدخل اسم رئيس وحدة المخازن والتكاليف ", MsgBoxStyle.Information, "إجراء تعديل")
            TextBox3.Focus()
            Exit Sub
        End If

        no_c = Trim(TextBox1.Text)
        qun_r = (CInt(TextBox6.Text))
        sal_s = CDec(TextBox9.Text)
        gema = CDec(TextBox10.Text)



        If Me.TextBox13.Text <> 0 Then

            date_end = Format(DateTimePicker2.Value.Date, "yyyy/MM/dd")
            mdh_a = Trim(Me.ComboBox2.Text)
            mdh = Trim(TextBox13.Text)
            date_mdh = TextBox12.Text
        Else
            date_end = "1990/01/01"
            mdh_a = "لايوجد".ToString
            mdh = 0
            date_mdh = "1990/01/01"

        End If

        If Me.RadioButton1.Checked = True Then
            txt_s = "تم اظافته كرصيد منقول".ToString
            move_no = "1"
        Else

            move_no = "2"
            txt_s = "تم اظافته".ToString
        End If

        If Me.RichTextBox1.Text = "" Then
            mt = "لايوجد".ToString
        Else
            mt = Me.RichTextBox1.Text
        End If
        Me.DataGridViewX2.Rows.Add(no_c, qun_r, sal_s, gema, txt_s, mt, date_end, mdh, mdh_a, date_mdh, ssf_t)


        If Im_tadel = "تعديل" Then
            Button2.Enabled = False

            Me.Button3.Enabled = False
            tadel()
            clear_tool_1()
        Else
            'NEWS()
            Me.Button3.Enabled = True
            clear_tool_1()
        End If


        Button2.Enabled = False
    End Sub





    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Me.RadioButton1.Checked = True Then

            Me.TextBox4.Text = TextBox6.Text
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton1.Checked = True Then

            Me.TextBox4.Text = TextBox6.Text
        Else

            Me.TextBox4.Text = 0

        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        If ComboBox2.Text = "لايوجد" Or TextBox13.Text = "0" Then
            TextBox13.Text = 0
            Exit Sub
        Else
            slhia(TextBox13.Text)
        End If

    End Sub

    Sub total_inf_tadel()
        TextBox8.Text = CStr(TextBox17.Text)
        If (Me.TextBox8.Text) <> " " Then
            ''------------------------------

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s11 As String = "SELECT * FROM RcvMain WHERE no_i=@x1 and no_kshf=" & ssf_t & ""
            Dim cm As New SqlCommand(s11, cn)
            cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader

                If r.Read = True Then
                    tot = True
                    TextBox5.Text = r!n_txt.ToString
                    TextBox2.Text = r!n1_txt.ToString

                    TextBox15.Text = Format(r!date_i, "yyyy/MM/dd")
                    DateTimePicker3.Value = CDate(TextBox15.Text)

                    Me.ComboBox1.SelectedValue = r!j_r
                    TextBox3.Text = r!name_stock.ToString

                    Im_tadel = "تعديل"
                    'Me.Button3.Enabled = False
                    TextBox14.Text = r!dep_mt.ToString

                    If TextBox14.Text = "تم مراجعته ولايوجد اخطاء" Then
                        RadioButton7.Checked = r!dep_m

                    End If

                    If TextBox14.Text = "تم مراجعته ويوجد اخطاء" Then
                        Me.ComboBox3.Enabled = True
                        RadioButton8.Checked = r!dep_m

                    End If


                    If r!dep_nom = True Then

                        RadioButton6.Checked = True
                        Me.ComboBox3.Enabled = True
                    End If


                    r.Close()
                    cn.Close()

                Else

                    ': MsgBox(" اذن الاستلام غير موجود ", MsgBoxStyle.Critical, "تنبية")
                    Me.Button3.Enabled = False
                    tot = False
                    Me.Button3.Enabled = False
                    Me.Button4.Enabled = False
                    Me.Button5.Enabled = False
                    Me.clear_tool_1()
                    r.Close()
                    cn.Close()
                    'Exit Sub
                End If
                r.Close()
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try
            cn.Close()

            If tot = False Then
                : MsgBox(" اذن الاستلام غير موجود ", MsgBoxStyle.Critical, "تنبية")
                Me.Button3.Enabled = False
                Me.Button3.Enabled = False
                Me.Button4.Enabled = False
                Me.Button5.Enabled = False
                'Me.Button8.Enabled = False
                Me.clear_tool_1()
                clear_tool()
                TextBox8.Text = ""
                cn.Close()
                Exit Sub
            End If
            '=============================
            If Im_tadel = "تعديل" And (sefa = "امين مخزن" Or sefa = "موظف") Then
                Me.DataGridViewX2.Rows.Clear()

                If TextBox14.Text = "تم مراجعته ويوجد اخطاء" Or RadioButton6.Checked = True Then
                    Me.Button3.Visible = False
                    Me.Button4.Enabled = True
                    Me.Button5.Enabled = True
                    'Me.Button6.Enabled = True
                    'Me.Button8.Enabled = True
                    Me.Button2.Visible = True
                    Me.Panel2.Enabled = False
                Else
                    Me.Button2.Enabled = False
                    Me.Button3.Visible = False
                    Me.Button4.Enabled = False
                    Me.Button5.Enabled = False
                    Me.Button6.Enabled = False
                    'Me.Button8.Enabled = True
                    'Me.Button2.Visible = False
                    Me.ComboBox3.Enabled = False
                    Me.Panel2.Enabled = False
                End If
            End If





            If Im_tadel = "تعديل" And sefa = "مراقب المخزون" Then
                Me.DataGridViewX2.Rows.Clear()
            
                If TextBox14.Text = "تم مراجعته ويوجد اخطاء" Then
                    Me.Button3.Visible = False
                    Me.Button4.Enabled = True
                    Me.Button5.Enabled = True

                    'Me.Button8.Enabled = True
                    Me.Button2.Visible = True
                    Me.Panel2.Enabled = False
                    Me.ComboBox3.Enabled = False
                    '===============================
                ElseIf RadioButton6.Checked = True Then

                    Me.Button2.Enabled = False
                    Me.Button3.Visible = False
                    Me.Button4.Enabled = False
                    Me.Button5.Enabled = False
                    Me.Button6.Enabled = False
                    'Me.Button8.Enabled = True
                    Me.Button2.Visible = True
                    Me.Panel2.Enabled = False
                    Me.ComboBox3.Enabled = False

                End If

            End If



            If sefa = "مراجع" Then
                Me.DataGridViewX2.Rows.Clear()
               
                If TextBox14.Text = "تم مراجعته ويوجد اخطاء" Or RadioButton6.Checked = True Then

                    Me.Button2.Enabled = False
                    Me.Button3.Visible = False
                    Me.Button4.Enabled = False
                    Me.Button5.Enabled = False
                    'Me.Button6.Enabled = False
                    'Me.Button8.Enabled = True
                    Me.Button2.Visible = False
                    Me.Panel2.Enabled = True

                Else

                    Me.Button2.Enabled = False
                    Me.Button3.Visible = False
                    Me.Button4.Enabled = False
                    Me.Button5.Enabled = False
                    Me.Button6.Enabled = False
                    Me.Panel2.Enabled = False
                    Me.ComboBox3.Enabled = False
                End If

              



            End If


            '----------------------------

            '============================

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If


            Dim dt As New DataTable()
            dt.Clear()
            Dim sql1 As String

            sql1 = "SELECT no_c as[رقم الصنف],qun_r as[الكمية], sal_s as[سعر_الوحدة], gema as[القيمة], txt_s as[حاله_الاضافه],mt as[ملاحظات],date_end as [تاريخ_انتهاء_الصلاحية],mdh as [المدة_قبل_انتهاء_الصلاحية],mdh_a as [نوع_المدة],date_mdh as [تاريخ_التنبيه] from View_sl  WHERE no_i='" + TextBox8.Text + "' and no_kshf=" & ssf_t & " ORDER BY no_ct1 "
            Dim ad As New SqlDataAdapter(sql1, cn)
            dt.Clear()
            ad.Fill(dt)
            'Me.DataGridViewX2.DataSource = ds2
            'Me.DataGridViewX2.DataMember = "View_sl"
            'Me.DataGridViewX2.Refresh()
            'cn.Close()
            '==================================

            Me.DataGridViewX2.Rows.Clear()

            For i As Integer = 0 To dt.Rows.Count - 1

                With dt.Rows(i)

                    Me.DataGridViewX2.Rows.Add(.Item("رقم الصنف"), .Item("الكمية"), .Item("سعر_الوحدة"), .Item("القيمة"), .Item("حاله_الاضافه"), .Item("ملاحظات"), .Item("تاريخ_انتهاء_الصلاحية"), .Item("المدة_قبل_انتهاء_الصلاحية"), .Item("نوع_المدة"), .Item("تاريخ_التنبيه"))

                End With

            Next



        End If
        cn.Close()
        '============================


    End Sub
    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox17_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ''Me.clear_tool()
        'Me.DataGridViewX2.Rows.Clear()
        'If e.KeyCode = Keys.Enter Then
        'If TextBox17.Text <> "" Then
        '    xl = l_p(Trim(TextBox17.Text))
        '    TextBox17.Text = Trim(xl)
        '    TextBox8.Text = Trim(xl)
        '    'total_inf()
        'End If


        '    '    If tot = True Then

        '    '        '==================================
        '    '        Im_tadel = "تعديل"
        '    '        Me.Button3.Enabled = False

        '    '    Else
        '    '        MsgBox(" اذن الاستلام غير موجود ", MsgBoxStyle.Critical, "تنبية")

        '    '        'Im_tadel = "جديد"
        '    '        'Me.Button3.Enabled = True
        '    '        Me.clear_tool_1()
        '    End If


        'End If


    End Sub

    Private Sub TextBox17_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            Case "0" To "9", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub


    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        If Me.RadioButton1.Checked = True Then

            Me.TextBox4.Text = TextBox6.Text
        Else

            Me.TextBox4.Text = 0

        End If
    End Sub
    Function man9(ByVal Text1 As String) As String
        Dim a(100) As String
        Dim i, j As Integer
        'Dim nm As String
        Me.TextBox9.Text = Trim(Me.TextBox9.Text)
        Dim a1 As String
        a1 = Me.TextBox9.Text.ToString
        For i = 1 To Len(Text1)
            If (Mid(Me.TextBox9.Text, i, 1) = ".") Then
                Exit For
            End If
            If i = Len(Text1) Then
                If (Mid(Me.TextBox9.Text, i, 1) <> ".") Then
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
        Me.TextBox9.Text = Trim(a1)
        man9 = Me.TextBox9.Text
    End Function
    Function man10(ByVal Text1 As String) As String
        Dim a(100) As String
        Dim i, j As Integer
        'Dim nm As String
        Me.TextBox10.Text = Trim(Me.TextBox10.Text)
        Dim a1 As String
        a1 = Me.TextBox10.Text.ToString
        For i = 1 To Len(Text1)
            If (Mid(Me.TextBox10.Text, i, 1) = ".") Then
                Exit For
            End If
            If i = Len(Text1) Then
                If (Mid(Me.TextBox10.Text, i, 1) <> ".") Then
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
        Me.TextBox10.Text = Trim(a1)
        man10 = Me.TextBox10.Text
    End Function
    Private Sub TextBox10_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox10.Validating
        If Me.TextBox10.Text = "" Then
            Me.TextBox10.Text = "0.000"
        End If

    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", ".", ControlChars.Back
                e.Handled = False
            Case Else
                e.Handled = True
        End Select


    End Sub

    Private Sub TextBox9_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox9.Validating
        If Me.TextBox9.Text = "" Then
            Me.TextBox9.Text = "0.000"
        End If
        Dim x As String
        x = man9(TextBox9.Text)
        TextBox10.Text = Val(TextBox6.Text) * Val(TextBox9.Text)
        'Text1.Text = Format(Text1.Text, "###,###,##0.00")
    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged
        Dim x As String
        x = man10(TextBox10.Text)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim ss As String = "update RcvMain set no_i=@x1,dep_m=@x2,dep_mt=@x3,dep_nom=@x4 where no_i=@x1"
        Dim cms As New SqlCommand(ss, cn)
        cms.Parameters.Add((New SqlParameter("@x1", Trim(TextBox8.Text))))

        If Me.RadioButton7.Checked = True Or RadioButton8.Checked = True Then
            cms.Parameters.Add(New SqlParameter("@x2", True))
        Else
            cms.Parameters.Add(New SqlParameter("@x2", False))
        End If

        cms.Parameters.Add(New SqlParameter("@x3", Me.TextBox14.Text))
        cms.Parameters.Add(New SqlParameter("@x4", Me.RadioButton6.Checked))
        Try
            cms.ExecuteNonQuery()
            dsRcvM.Clear()
            adRcvM.Fill(dsRcvM, "RcvMain")
            '"تم مراجعته ويوجد اخطاء" 
            If RadioButton6.Checked = True Then
                MsgBox(" لم تتم مراجعته ", MsgBoxStyle.Critical, "تنبية")

            End If
            If RadioButton7.Checked = True Then
                MsgBox(" تم مراجعته ولايوجد اخطاء ", MsgBoxStyle.Critical, "تنبية")
                'Me.TextBox14.Text = " تم مراجعته ولايوجد اخطاء "
            End If
            If RadioButton8.Checked = True Then
                MsgBox("  تم مراجعته ويوجد اخطاء ", MsgBoxStyle.Critical, "تنبية")
                'Me.TextBox14.Text = "  تم مراجعته ويوجد اخطاء "
                Me.TextBox14.Clear()
            End If
            cn.Close()
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try

        Me.Button12.Enabled = False
        'Me.RadioButton4.Checked = False
        'Me.RadioButton5.Checked = False
        'Me.RadioButton3.Checked = False
        ''Me.TextBoxX11.Clear()
        cn.Close()
    End Sub
    Sub serch_no_c()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If TextBox1.Text <> "" Then
            Dim s As String = "select * from matt_t where no_c=@x1"
            Dim cm As New SqlCommand(s, cn)

            cm.Parameters.Add(New SqlParameter("@x1", (TextBox1.Text)))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader
                If r.Read = True Then
                    Me.TextBox11.Text = r!name_snc
                    Me.TextBox16.Text = r!name_type
                    Me.TextBox4.Text = r!iopb
                    r.Close()
                Else

                    r.Close()
                    cn.Close()

                    Exit Sub
                    r.Close()

                End If
                r.Close()
            Catch

            End Try


            cn.Close()

        End If
        cn.Close()


    End Sub
    Private Sub DataGridViewX2_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridViewX2.RowHeaderMouseClick


        If Me.DataGridViewX2.Rows.Count = 0 Then
            MsgBox(" اذن الاستلام فارغ ", MsgBoxStyle.Information, " إجراء تعديل")
            Exit Sub
        End If

        If DataGridViewX2.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub
        '***************************


        If cn.State = ConnectionState.Closed Then cn.Open()
        '***************************
        Dim coun_test As Integer = 0
        For Me.i = 0 To DataGridViewX2.RowCount - 1



            TextBox1.Text = DataGridViewX2.CurrentRow.Cells(0).Value
            TextBox6.Text = DataGridViewX2.CurrentRow.Cells(1).Value
            TextBox9.Text = DataGridViewX2.CurrentRow.Cells(2).Value
            TextBox7.Text = DataGridViewX2.CurrentRow.Cells(2).Value

            TextBox10.Text = DataGridViewX2.CurrentRow.Cells(3).Value


            If DataGridViewX2.CurrentRow.Cells(4).Value = "تم اظافته كرصيد منقول" Then
                Me.RadioButton1.Checked = True
            Else
                Me.RadioButton2.Checked = True
            End If


            Me.RichTextBox1.Text = DataGridViewX2.CurrentRow.Cells(5).Value

            '---------------------الصلاحيه
            Me.DateTimePicker2.Value = DataGridViewX2.CurrentRow.Cells(6).Value.ToString
            TextBox13.Text = Trim(DataGridViewX2.CurrentRow.Cells(7).Value)
            ComboBox2.Text = Trim(DataGridViewX2.CurrentRow.Cells(8).Value)

            TextBox12.Text = DataGridViewX2.CurrentRow.Cells(9).Value
        Next
        cn.Close()

        If (Im_tadel = "تعديل") And (sefa = "امين مخزن" Or sefa = "موظف") And (TextBox14.Text = "تم مراجعته ويوجد اخطاء" Or RadioButton6.Checked = True) Then
            Me.Button6.Enabled = True
        Else
            Me.Button6.Enabled = False
        End If


        If (Im_tadel = "تعديل") And (sefa = "مراقب المخزون") And (TextBox14.Text = "تم مراجعته ويوجد اخطاء") Then
            Me.Button6.Enabled = True
        End If

        serch_no_c()



    End Sub





    Private Sub DataGridViewX2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX2.CellContentClick

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click



        If Me.TextBox8.Text.ToString = "" Then
            MsgBox("أدخل رقم اذن الاستلام ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox8.Focus()
            Exit Sub
        End If

        If Me.ComboBox1.SelectedIndex = -1 Then
            MsgBox(" اختار جهة التوريد", MsgBoxStyle.Information, "إجراء إضافة")
            ComboBox1.Focus()
            Exit Sub
        End If
        If Me.TextBox5.Text.ToString = "" Then
            MsgBox("ادخل الاصناف واردة بموجب:  ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox5.Focus()
            Exit Sub
        End If

        If Me.TextBox3.Text.ToString = "" Then
            MsgBox("أدخل اسم رئيس وحدة المخازن والتكاليف ", MsgBoxStyle.Information, "إجراء إضافة")
            TextBox3.Focus()
            Exit Sub
        End If


        'If DataGridViewX2.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub
        '***************************
        If DataGridViewX2.RowCount = 0 Then
            MessageBox.Show("لاتوجد عناصر تم ادخالهاالي اذن الاستلام")
            Exit Sub
        End If

        If Me.DateTimePicker3.Value.Year <> Me.dtYear.Value.Year Then
            MessageBox.Show("تاريخ الاستلام غير متوافق مع سنة الادخال")
            Exit Sub
        End If
 
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        Dim Trans As SqlTransaction = cn.BeginTransaction

        Try
            Dim s As String = "insert into RcvMain(no_i,date_i,j_r,n_txt,n1_txt,g_b,tvg,u_name,dep_m,dep_mt,dep_nom,name_stock,no_kshf) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9,@x10,@x11,@x12,@x13)"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", CStr(Trim(TextBox8.Text))))
            cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
            cm.Parameters.Add(New SqlParameter("@x3", Me.ComboBox1.SelectedValue))
            cm.Parameters.Add(New SqlParameter("@x4", TextBox5.Text))
            cm.Parameters.Add(New SqlParameter("@x5", TextBox2.Text))
            cm.Parameters.Add(New SqlParameter("@x6", 0))
            cm.Parameters.Add(New SqlParameter("@x7", 0))
            cm.Parameters.Add(New SqlParameter("@x8", ww))
            cm.Parameters.Add(New SqlParameter("@x9", False))
            cm.Parameters.Add(New SqlParameter("@x10", ""))
            cm.Parameters.Add(New SqlParameter("@x11", True))
            'cm.Parameters.Add((New SqlParameter("@x12", TextBox3.Text)))
            cm.Parameters.Add((New SqlParameter("@x12", TextBox3.Text)))
            cm.Parameters.Add((New SqlParameter("@x13", ComboBox3.SelectedValue)))
            cm.Transaction = Trans

            cm.ExecuteNonQuery()

            '=======================================
            For i As Integer = 0 To DataGridViewX2.RowCount - 1





                Dim sqls As String = "insert into RcvSub(no_c,no_i,qun_r,sal_s,gema,txt_s,mt,no_kshf)values(@no_c,@no_i,@qun_r,@sal_s,@gema,@txt_s,@mt,@ssf_t)"
                Dim cm1 As New SqlCommand(sqls, cn)
                cm1.Parameters.AddWithValue("@no_c", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                cm1.Parameters.AddWithValue("@no_i", Trim(TextBox8.Text)).DbType = DbType.String
                cm1.Parameters.AddWithValue("@qun_r", DataGridViewX2.Rows(i).Cells(1).Value).DbType = DbType.Int32
                cm1.Parameters.AddWithValue("@sal_s", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.Decimal
                cm1.Parameters.AddWithValue("@gema", DataGridViewX2.Rows(i).Cells(3).Value).DbType = DbType.Decimal
                cm1.Parameters.AddWithValue("@txt_s", DataGridViewX2.Rows(i).Cells(4).Value).DbType = DbType.String
                cm1.Parameters.AddWithValue("@mt", DataGridViewX2.Rows(i).Cells(5).Value).DbType = DbType.String
                cm1.Parameters.AddWithValue("@ssf_t", ssf_t).DbType = DbType.Int32
                cm1.Transaction = Trans
                cm1.ExecuteNonQuery()


                Dim sql As String = "insert into salahia(no_c,date_end,mdh,mdh_a,date_mdh,sal_s,no_i,date_i,state_sal,no_kshf) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9,@x10)"
                Dim cms As New SqlCommand(sql, cn)
                cms.Parameters.AddWithValue("@x1", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                cms.Parameters.AddWithValue("@x2", DataGridViewX2.Rows(i).Cells(6).Value).DbType = DbType.Date
                cms.Parameters.AddWithValue("@x3", Trim(DataGridViewX2.Rows(i).Cells(7).Value)).DbType = DbType.String
                cms.Parameters.AddWithValue("@x4", DataGridViewX2.Rows(i).Cells(8).Value).DbType = DbType.String
                cms.Parameters.AddWithValue("@x5", DataGridViewX2.Rows(i).Cells(9).Value).DbType = DbType.Date
                cms.Parameters.AddWithValue("@x6", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.Decimal
                cms.Parameters.AddWithValue("@x7 ", Trim(TextBox8.Text)).DbType = DbType.String
                cms.Parameters.AddWithValue("@x8", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")).DbType = DbType.Date
                cms.Parameters.AddWithValue("@x9", 0).DbType = DbType.Int16
                cms.Parameters.AddWithValue("@x10", ssf_t).DbType = DbType.Int16
                cms.Transaction = Trans
                cms.ExecuteNonQuery()



                '==========smove_no_i===============


                Dim smov As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i,count1,no_kshf) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8)"
                Dim cmsmov As New SqlCommand(smov, cn)
                cmsmov.Parameters.AddWithValue("@x1", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                cmsmov.Parameters.AddWithValue("@x2", DataGridViewX2.Rows(i).Cells(1).Value).DbType = DbType.Int32
                cmsmov.Parameters.AddWithValue("@x3", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.Decimal
                cmsmov.Parameters.AddWithValue("@x4", Me.move_no).DbType = DbType.Int32
                cmsmov.Parameters.AddWithValue("@x5", Trim(TextBox8.Text)).DbType = DbType.String
                cmsmov.Parameters.AddWithValue("@x6", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")).DbType = DbType.Date
                cmsmov.Parameters.AddWithValue("@x7", 0).DbType = DbType.Int32
                cmsmov.Parameters.AddWithValue("@x8", ssf_t).DbType = DbType.Int32
                cmsmov.Transaction = Trans
                cmsmov.ExecuteNonQuery()


                '=====acthion_tran================



                Dim stran As String = "insert into acthion_tran(info,no_c,date_i,qun_tot,sal_s) values (@x1,@x2,@x3,@x4,@x5)"
                Dim cmtran As New SqlCommand(stran, cn)
                cmtran.Parameters.AddWithValue("@x1", Trim(TextBox8.Text)).DbType = DbType.String
                cmtran.Parameters.AddWithValue("@x2", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                cmtran.Parameters.AddWithValue("@x3", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")).DbType = DbType.Date
                cmtran.Parameters.AddWithValue("@x4", DataGridViewX2.Rows(i).Cells(1).Value).DbType = DbType.Int32
                cmtran.Parameters.AddWithValue("@x5", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.Decimal
                cmtran.Transaction = Trans
                cmtran.ExecuteNonQuery()



                '=========================

                t_event = "حفظ صنف"
                t_doc = "اذن الاستلام"
                ts = TimeOfDay


                Dim sevent As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim cmevent As New SqlCommand(sevent, cn)
                cmevent.Parameters.AddWithValue("@x1", Trim(TextBox8.Text)).DbType = DbType.String
                cmevent.Parameters.AddWithValue("@x2", t_doc).DbType = DbType.String
                cmevent.Parameters.AddWithValue("@x3", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                cmevent.Parameters.AddWithValue("@x4", DataGridViewX2.Rows(i).Cells(1).Value).DbType = DbType.Int32
                cmevent.Parameters.AddWithValue("@x5", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.Decimal
                cmevent.Parameters.AddWithValue("@x6", Format(Now.Date, "yyyy/MM/dd")).DbType = DbType.Date
                cmevent.Parameters.AddWithValue("@x7", ts)
                cmevent.Parameters.AddWithValue("@x8", ww).DbType = DbType.String
                cmevent.Parameters.AddWithValue("@x9", t_event).DbType = DbType.String

                cmevent.Transaction = Trans
                cmevent.ExecuteNonQuery()




                '=======================تعديل المخزون========================

                If DataGridViewX2.Rows(i).Cells(4).Value = "تم اظافته كرصيد منقول".ToString Then
                    siopb = DataGridViewX2.Rows(i).Cells(1).Value

                    Dim ss1 As String = "update  matt set no_c=@x1,balance=@x2,iopb=@x3,irct=@x5 where no_c=@x1"
                    Dim cmst As New SqlCommand(ss1, cn)
                    cmst.Parameters.AddWithValue("@x1", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                    cmst.Parameters.AddWithValue("@x2", total_s).DbType = DbType.Decimal
                    cmst.Parameters.AddWithValue("@x3", Me.siopb).DbType = DbType.Decimal
                    cmst.Parameters.AddWithValue("@x5", sum_irct).DbType = DbType.Decimal

                    cmst.Transaction = Trans
                    cmst.ExecuteNonQuery()


                Else

                    Dim sss1 As String = "update  matt set no_c=@x1,balance=@x2,irct=@x5 where no_c=@x1"
                    Dim cmst1 As New SqlCommand(sss1, cn)
                    cmst1.Parameters.AddWithValue("@x1", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
                    cmst1.Parameters.Add(New SqlParameter("@x2", total_s)).DbType = DbType.Decimal
                    cmst1.Parameters.Add(New SqlParameter("@x5", sum_irct)).DbType = DbType.Decimal

                    cmst1.Transaction = Trans
                    cmst1.ExecuteNonQuery()

                End If



            Next

            '===============================
            Trans.Commit()
            MsgBox("تم حفظ اذن الاستلام  ", MsgBoxStyle.Information, " حفظ")
            'total_inf_tadel()
            cn.Close()


            TextBox8.Text = getNewNo(Me.dtYear.Value.Year, ssf_t, "GetNewNoRcvMain")
            Me.clear_tool_1()
            clear_tool()
            TextBox5.Text = ""
            'Me.Button8.Enabled = False
            ComboBox1.SelectedIndex = -1
            Me.DataGridViewX2.Rows.Clear()
            Me.Button4.Enabled = False
            Me.Button5.Enabled = False
            Me.Button6.Enabled = False
        Catch err As System.Exception

            Trans.Rollback()
            MsgBox("لم يتم حفظ اذن الاستلام", MsgBoxStyle.Critical, " حفظ")
            MsgBox(err.Message)
            Me.Button4.Enabled = False
            Me.Button5.Enabled = False
            Me.Button6.Enabled = False
            ComboBox1.SelectedIndex = -1
        Finally
        End Try
        cn.Close()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        View_matt()
    End Sub

    Sub no_iup()


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim scn As String = "SELECT no_i, SUBSTRING(no_i, 1, 4) AS i_no FROM RcvMain where no_i=@x1 and date_i=@x3 "
        Dim cmcn As New SqlCommand(scn, cn)
        cmcn.Parameters.Add(New SqlParameter("@x1", CStr(TextBox8.Text)))
        cmcn.Parameters.Add(New SqlParameter("@x3", CDate(TextBox15.Text)))

        Try
            Dim r1cn As SqlDataReader = cmcn.ExecuteReader
            If r1cn.Read = True Then

                Label5.Text = r1cn!i_no.ToString
                r1cn.Close()
                cn.Close()
                Exit Sub

            Else
                r1cn.Close()
                cn.Close()
            End If
            r1cn.Close()
        Catch

        End Try
        cn.Close()
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Label5.Text = ""
        If Me.DataGridViewX2.Rows.Count = 0 Then
            MsgBox(" اذن الاستلام فارغ ", MsgBoxStyle.Information, " إجراء تعديل")

            Exit Sub
        End If

        '============================اختبار مهم 


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim scn As String = "select * from Table_OSTA where no_R=@x1 and date_r=@x3 and no_kshf=@x4"
        Dim cmcn As New SqlCommand(scn, cn)
        cmcn.Parameters.Add(New SqlParameter("@x1", CStr(TextBox8.Text)))
        cmcn.Parameters.Add(New SqlParameter("@x3", CDate(TextBox15.Text)))
        cmcn.Parameters.Add(New SqlParameter("@x4", ssf_t))
        Try
            Dim r1cn As SqlDataReader = cmcn.ExecuteReader
            If r1cn.Read = True Then
                r1cn.Close()
                MessageBoxEx.Show("لا تستطيع التعديل لان اذن  تم الصرف منه", "مراقبة المخزون", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
                cn.Close()
            Else
                r1cn.Close()
                cn.Close()
            End If
            r1cn.Close()
        Catch

        End Try
        cn.Close()

        If Me.ComboBox1.SelectedIndex = -1 Then
            MsgBox(" اختار جهة التوريد", MsgBoxStyle.Information, "إجراء تعديل")
            ComboBox1.Focus()
            Exit Sub
        End If
        If Me.TextBox5.Text.ToString = "" Then
            MsgBox(" ادخل التكليف الاشاري", MsgBoxStyle.Information, "إجراء تعديل")
            TextBox5.Focus()
            Exit Sub
        End If

        If Me.TextBox3.Text.ToString = "" Then
            MsgBox("أدخل اسم رئيس وحدة المخازن والتكاليف ", MsgBoxStyle.Information, "إجراء تعديل")
            TextBox3.Focus()
            Exit Sub
        End If

        '=====================================================
        'If cn.State = ConnectionState.Closed Then
        '    cn.Open()
        'End If



        slhia(TextBox13.Text)

        'End If
        'Me.ComboBox2.Text <> "ايام" Or Me.ComboBox2.Text <> "اسابيع" Or Me.ComboBox2.Text <> "اشهر" Or Me.ComboBox2.Text <> "سنة" Then
        ''MsgBox("اختار من القائمة لاتكتب ", MsgBoxStyle.Information, "تنبية")



        If Me.TextBox1.Text <> "" Then

            If Me.TextBox1.Text = "" Then
                MsgBox("أدخل رقم الصنف المرادإضافته ", MsgBoxStyle.Information, "إجراء تعديل")
                TextBox1.Focus()

                Exit Sub
            End If

            If Val(Me.TextBox6.Text).ToString = "" Or Val(Me.TextBox6.Text) = 0 Then
                MsgBox("أدخل الكمية المراد استلامها", MsgBoxStyle.Information, " إجراء تعديل")
                TextBox6.Focus()
                Exit Sub
            End If

            If Me.TextBox9.Text.ToString = "" Or Me.TextBox9.Text = "0.000" Or Me.TextBox9.Text = "0" Or Me.TextBox9.Text = "0.00" Then
                MsgBox("ادخل سعر الوحدة", MsgBoxStyle.Information, "إجراء تعديل ")
                TextBox9.Focus()
                Exit Sub
            End If
            If RadioButton1.Checked = False And RadioButton2.Checked = False Then
                MsgBox("اختار  اما رصيد منقول او اضافه", MsgBoxStyle.Information, "إجراء تعديل ")
                Exit Sub
            End If


            If (Me.TextBox13.Text.ToString <> 0) And (ComboBox2.Text = "لايوجد" Or ComboBox2.Text = "") Then
                MsgBox("راجع المدة ونوع المدة ", MsgBoxStyle.Information, "إجراء تعديل")
                TextBox13.Focus()
                Exit Sub
            End If

            If Format(DateTimePicker2.Value.Date, "yyyy/MM/dd") <= Date.Now And (Me.TextBox13.Text.ToString <> 0) And ((ComboBox2.Text <> "لايوجد" Or ComboBox2.Text = "")) Then
                MsgBox("تاريخ انتهاء الصلاحية اقل من او  يساوي تاريخ اليوم  ", MsgBoxStyle.Information, "إجراء تعديل")

                Exit Sub
            End If


            '======اختبار مهم===================
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            '=====================

            '=============اختبار الصرف والحذف والاتلاف============
            Dim s As String = "select * from tran_IRT where no_c=@x1 and date_i=@x3 and (tr_type=3 or  tr_type=4 or  tr_type=5) and price=@x5 no_kshf=@x4"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
            cm.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
            cm.Parameters.Add(New SqlParameter("@x5", CDec(TextBox7.Text)))
            cm.Parameters.Add(New SqlParameter("@x4", ssf_t))
            Try
                Dim r1 As SqlDataReader = cm.ExecuteReader
                If r1.Read = True Then
                    r1.Close()
                    MessageBox.Show(" لا تستطيع التعديل لان   تم الصرف منه اواتلاف كميات منه اوتم ارجاع كميات منه", "مراقبه المخزون", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    cn.Close()
                    Exit Sub
                Else
                    r1.Close()
                    cn.Close()
                End If
                r1.Close()
            Catch

            End Try

            cn.Close()

            '========================تعديل الصنف والاذن ===============
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If



            'If Me.TextBox3.Text.ToString = "" Then
            '    MsgBox("أدخل اسم رئيس وحدة المخازن والتكاليف ", MsgBoxStyle.Information, "إجراء تعديل")
            '    TextBox3.Focus()
            '    Exit Sub
            'End If

            Dim Trans As SqlTransaction = cn.BeginTransaction

            Try

                Dim sr As String = "update RcvMain set no_i=@x1,date_i=@x2,j_r=@x3,n_txt=@x4,n1_txt=@x5,name_stock=@x6 where no_i=@x1 and no_kshf=@x14"
                Dim cmr As New SqlCommand(sr, cn)

                cmr.Parameters.Add(New SqlParameter("@x1", CStr(TextBox8.Text)))
                cmr.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
                cmr.Parameters.Add(New SqlParameter("@x3", Me.ComboBox1.SelectedValue))
                cmr.Parameters.Add(New SqlParameter("@x4", TextBox5.Text))
                cmr.Parameters.Add(New SqlParameter("@x5", TextBox2.Text))
                cmr.Parameters.Add((New SqlParameter("@x6", TextBox3.Text)))
                cmr.Parameters.Add((New SqlParameter("@x14", ssf_t)))
                cmr.Transaction = Trans
                cmr.ExecuteNonQuery()

                '    '========================تعديل الاصناف===============

                Dim su As String = "update RcvSub set no_c=@x1,no_i=@x2,qun_r=@x3,sal_s=@x4,gema=@x5,txt_s=@x6,mt=@x7 where no_c=@x1 and no_i=@x2 and no_kshf=" & ssf_t & " and sal_s= " & Me.TextBox7.Text & ""
                Dim cmu As New SqlCommand(su, cn)

                cmu.Parameters.AddWithValue("@x1", Trim(TextBox1.Text)).DbType = DbType.String
                cmu.Parameters.AddWithValue("@x2", Trim(TextBox8.Text)).DbType = DbType.String
                cmu.Parameters.AddWithValue("@x3", Trim(TextBox6.Text)).DbType = DbType.Int32
                cmu.Parameters.AddWithValue("@x4", (TextBox9.Text)).DbType = DbType.Decimal
                cmu.Parameters.AddWithValue("@x5", (TextBox10.Text)).DbType = DbType.Decimal
                If Me.RadioButton1.Checked = True Then

                    cmu.Parameters.AddWithValue("@x6", "تم اظافته كرصيد منقول").DbType = DbType.String


                ElseIf Me.RadioButton2.Checked = True Then

                    cmu.Parameters.AddWithValue("@x6", "تم اظافته").DbType = DbType.String
                End If

                cmu.Parameters.AddWithValue("@x7", Me.RichTextBox1.Text).DbType = DbType.String

                cmu.Transaction = Trans
                cmu.ExecuteNonQuery()



                If Me.TextBox13.Text <> 0 Then

                    Dim sql As String = "update salahia set no_c=@x1,date_end=@x2,mdh=@x3,mdh_a=@x4,date_mdh=@x5,sal_s=@x6,no_i=@x7,date_i=@x8 where no_c=@x1 and no_kshf=" & ssf_t & " and no_i=@x7 and sal_s= " & Me.TextBox7.Text & ""
                    Dim cms As New SqlCommand(sql, cn)
                    cms.Parameters.AddWithValue("@x1", Trim(TextBox1.Text))
                    cms.Parameters.AddWithValue("@x2", Format(DateTimePicker2.Value.Date, "yyyy/MM/dd"))
                    cms.Parameters.AddWithValue("@x3", TextBox13.Text)
                    cms.Parameters.AddWithValue("@x4", Trim(Me.ComboBox2.Text))
                    cms.Parameters.AddWithValue("@x5", CDate(TextBox12.Text))
                    cms.Parameters.AddWithValue("@x6", CDec(TextBox9.Text))
                    cms.Parameters.AddWithValue("@x7", Trim(TextBox8.Text))
                    cms.Parameters.AddWithValue("@x8 ", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd"))

                    cms.Transaction = Trans
                    cms.ExecuteNonQuery()

                Else
                    Dim sql As String = "update salahia set no_c=@x1,date_end=@x2,mdh=@x3,mdh_a=@x4,date_mdh=@x5,sal_s=@x6,no_i=@x7,date_i=@x8 where no_c=@x1 and no_kshf=" & ssf_t & " and no_i=@x7 and sal_s= " & Me.TextBox7.Text & ""
                    Dim cms As New SqlCommand(sql, cn)
                    cms.Parameters.AddWithValue("@x1", Trim(TextBox1.Text)).DbType = DbType.String
                    cms.Parameters.AddWithValue("@x2", "1990/01/01")
                    cms.Parameters.AddWithValue("@x3", 0).DbType = DbType.String
                    cms.Parameters.AddWithValue("@x4", "لايوجد").DbType = DbType.String
                    cms.Parameters.AddWithValue("@x5", "1990/01/01").DbType = DbType.Date
                    cms.Parameters.AddWithValue("@x6", (TextBox9.Text)).DbType = DbType.Decimal
                    cms.Parameters.AddWithValue("@x7", Trim(TextBox8.Text)).DbType = DbType.String
                    cms.Parameters.AddWithValue("@x8 ", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")).DbType = DbType.Date
                    cms.Parameters.AddWithValue("@x9", 0).DbType = DbType.Int16
                    cms.Transaction = Trans
                    cms.ExecuteNonQuery()

                End If
                ''        '==========smove_no_i===============

                Dim ss As Integer

                If Me.RadioButton1.Checked = True Then

                    ss = 1
                    Dim sd As String = "update tran_IRT set n_rs='" & TextBox8.Text & "' ,price=" & TextBox9.Text & ", no_c='" + TextBox1.Text + "' , quntity=" & Me.TextBox6.Text & ", tr_type=" & ss & " where n_rs='" & TextBox8.Text & "' and no_c='" + TextBox1.Text + "' and no_kshf=" & ssf_t & " and price=" & TextBox7.Text & ""
                    Dim cmd As New SqlCommand(sd, cn)

                    cmd.Transaction = Trans
                    cmd.ExecuteNonQuery()


                ElseIf Me.RadioButton2.Checked = True Then

                    ss = 2

                    Dim sd As String = "update tran_IRT set n_rs='" & TextBox8.Text & "' ,price=" & TextBox9.Text & ", no_c='" & TextBox1.Text & "' , quntity=" & Me.TextBox6.Text & " , tr_type=" & ss & " where n_rs='" & TextBox8.Text & "' and no_c='" & TextBox1.Text & "' and no_kshf=" & ssf_t & " and price=" & TextBox7.Text & ""
                    Dim cmd As New SqlCommand(sd, cn)

                    cmd.Transaction = Trans
                    cmd.ExecuteNonQuery()

                End If


                '===== '=====acthion_tran================

                Dim s1 As String = "update acthion_tran set info=@x1,no_c=@x2,date_i=@x3,qun_tot=@x4,sal_s=@x5 where info=@x1 and date_i=@x3 and no_c=@x2 and sal_s= " & Me.TextBox7.Text & ""
                Dim cm1 As New SqlCommand(s1, cn)
                cm1.Parameters.Add(New SqlParameter("@x1", CStr(TextBox8.Text)))
                cm1.Parameters.Add(New SqlParameter("@x2", Trim(TextBox1.Text)))
                cm1.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
                cm1.Parameters.Add(New SqlParameter("@x4", TextBox6.Text))
                cm1.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
                cm1.Transaction = Trans
                cm1.ExecuteNonQuery()
                '========================

                '     

                t_event = "تعديل"
                t_doc = "صنف "
                ts = TimeOfDay

                Dim sy As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim cmy As New SqlCommand(sy, cn)
                cmy.Parameters.Add(New SqlParameter("@x1", CStr(TextBox8.Text)))
                cmy.Parameters.Add(New SqlParameter("@x2", t_doc))
                cmy.Parameters.Add(New SqlParameter("@x3", Trim(TextBox1.Text)))
                cmy.Parameters.Add(New SqlParameter("@x4", CInt(TextBox6.Text)))
                cmy.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
                cmy.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
                cmy.Parameters.Add(New SqlParameter("@x7", ts))
                cmy.Parameters.Add(New SqlParameter("@x8", ww))
                cmy.Parameters.Add(New SqlParameter("@x9", t_event))
                cmy.Transaction = Trans
                cmy.ExecuteNonQuery()

                '===============================
                Trans.Commit()
                MsgBox("تم تعديل الصنف ", MsgBoxStyle.Information, " تعديل")
                cn.Close()
                'total_inf()
            Catch err As System.Exception

                Trans.Rollback()
                MsgBox("لم يتم تعديل الصنف ", MsgBoxStyle.Information, " تعديل")
                MsgBox(err.Message)
                cn.Close()
            Finally
            End Try
            '=========================
            stouck()
            total_inf_tadel()


            cn.Close()

        Else

            no_iup()

            'If Me.TextBox3.Text.ToString = "" Then
            '    MsgBox("أدخل اسم رئيس وحدة المخازن والتكاليف ", MsgBoxStyle.Information, "إجراء إضافة")
            '    TextBox3.Focus()
            '    Exit Sub
            'End If



            If Me.DateTimePicker3.Value.Year <> Me.Label5.Text Then
                MessageBox.Show("تاريخ الاستلام غير متوافق مع سنة الادخال")
                Label5.Text = ""
                cn.Close()
                Exit Sub
            End If
            '=======تعديل اذن الاستلام===============
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim Trans1 As SqlTransaction = cn.BeginTransaction


            Try
                Dim sr As String = "update RcvMain set no_i=@x1,date_i=@x2,j_r=@x3,n_txt=@x4,n1_txt=@x5,name_stock=@x6 where no_i=@x1 and no_kshf=@x7"
                Dim cmr As New SqlCommand(sr, cn)

                cmr.Parameters.Add(New SqlParameter("@x1", CStr(TextBox8.Text)))
                cmr.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
                cmr.Parameters.Add(New SqlParameter("@x3", Me.ComboBox1.SelectedValue))
                cmr.Parameters.Add(New SqlParameter("@x4", TextBox5.Text))
                cmr.Parameters.Add(New SqlParameter("@x5", TextBox2.Text))
                cmr.Parameters.Add((New SqlParameter("@x6", TextBox3.Text)))
                cmr.Parameters.Add((New SqlParameter("@x7", ssf_t)))
                cmr.Transaction = Trans1
                cmr.ExecuteNonQuery()
                '======================================
                Dim srs As String = "update tran_IRT set date_i=@x2 where(tr_type=1 or  tr_type=2) and n_rs=@x1 and no_kshf=" & ssf_t & ""
                Dim cmrs As New SqlCommand(srs, cn)

                cmrs.Parameters.Add(New SqlParameter("@x1", CStr(TextBox8.Text)))
                cmrs.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
                cmrs.Transaction = Trans1
                cmrs.ExecuteNonQuery()
                ''======================================
                'Dim srw As String = "update Table_OSTA set date_r=@x2 where no_R=@x1"
                'Dim cmrw As New SqlCommand(srw, cn)

                'cmrw.Parameters.Add(New SqlParameter("@x1", CStr(TextBox8.Text)))
                'cmrw.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker1.Value.Date, "yyyy/MM/dd")))
                'cmrw.ExecuteNonQuery()


                '=====acthion_tran================

                Dim sz1 As String = "update acthion_tran set date_i=@x3 where info=@x1"
                Dim cmz1 As New SqlCommand(sz1, cn)
                cmz1.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
                cmz1.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
                cmz1.Transaction = Trans1
                cmz1.ExecuteNonQuery()
                '======================================
                t_event = "تعديل"
                t_doc = "اذن الاستلام"
                ts = TimeOfDay

                Dim sy As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim sycm As New SqlCommand(sy, cn)
                sycm.Parameters.Add(New SqlParameter("@x1", TextBox8.Text))
                sycm.Parameters.Add(New SqlParameter("@x2", t_doc))
                sycm.Parameters.Add(New SqlParameter("@x3", 0))
                sycm.Parameters.Add(New SqlParameter("@x4", 0))
                sycm.Parameters.Add(New SqlParameter("@x5", 0))
                sycm.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
                sycm.Parameters.Add(New SqlParameter("@x7", ts))
                sycm.Parameters.Add(New SqlParameter("@x8", ww))
                sycm.Parameters.Add(New SqlParameter("@x9", t_event))
                sycm.Transaction = Trans1
                sycm.ExecuteNonQuery()

                '===============================
                Trans1.Commit()
                MsgBox("تم تعديل اذن الاستلام", MsgBoxStyle.Information, " تعديل  ")
                total_inf_tadel()
                cn.Close()

                'total_inf()
            Catch err As System.Exception

                Trans1.Rollback()
                MsgBox("لم يتم تعديل اذن الاستلام ", MsgBoxStyle.Information, " تعديل")
                MsgBox(err.Message)
                cn.Close()
            Finally
            End Try
            '=========================



        End If

        cn.Close()
        'total_inf()



    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        If TextBox1.Text = "" And TextBox6.Text = "" And TextBox9.Text = "" And TextBox9.Text = "" Then
            MsgBox("انقر على المخزن  ", MsgBoxStyle.Information, "إجراءحذف")

            Exit Sub
        End If
        '============================اختبار مهم 


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim scn As String = "select * from Table_OSTA where no_c=@x1 and no_R=@x2 and date_r=@x3 and sal_s=@x4 and no_kshf=" & ssf_t & ""
        Dim cmcn As New SqlCommand(scn, cn)
        cmcn.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cmcn.Parameters.Add(New SqlParameter("@x2", CStr(TextBox8.Text)))
        cmcn.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
        cmcn.Parameters.Add(New SqlParameter("@x4", CDec(TextBox9.Text)))

        Try
            Dim r1cn As SqlDataReader = cmcn.ExecuteReader
            If r1cn.Read = True Then
                r1cn.Close()
                MessageBoxEx.Show("لا تستطيع حذف الصنف تم الصرف منه", "مراقبة المخزون", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
                cn.Close()
            Else
                r1cn.Close()
                cn.Close()
            End If
        Catch

        End Try
        cn.Close()


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        '=============اختبار الصرف والحذف والاتلاف============
        Dim s As String = "select * from tran_IRT where no_c=@x1 and date_i=@x3 and (tr_type=3 or  tr_type=4 or  tr_type=5) and price=@x5 and no_kshf=" & ssf_t & " "
        Dim cm As New SqlCommand(s, cn)
        cm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
        cm.Parameters.Add(New SqlParameter("@x3", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
        cm.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
        Try
            Dim r1 As SqlDataReader = cm.ExecuteReader
            If r1.Read = True Then
                r1.Close()
                MessageBox.Show(" لا تستطيع الحذف لان الصنف  تم الصرف منه اواتلاف كميات منه اوتم ارجاع كميات منه", "مراقبه المخزون", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cn.Close()
                Exit Sub
            Else
                r1.Close()
                cn.Close()
            End If
        Catch

        End Try
        cn.Close()
        '===========================

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim rds As Boolean
        ''======= شرط لو الاذن قعد فارغ نحذفه========'================

        Dim stR As String = "select * from RcvSub where no_i=@x1 and no_kshf=" & ssf_t & " "
        Dim cmR As New SqlCommand(stR, cn)
        cmR.Parameters.Add(New SqlParameter("@x1", CStr(TextBox8.Text)))


        Try
            Dim r1 As SqlDataReader = cmR.ExecuteReader
            If r1.Read = True Then
                r1.Close()
                rds = True
                cn.Close()
            Else
                r1.Close()
                rds = False
                MessageBoxEx.Show("اذن الاستلام فارغ  ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cn.Close()
                Exit Sub
            End If
        Catch

        End Try

        cn.Close()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        Dim Trans As SqlTransaction = cn.BeginTransaction

        Try

            If rds = True Then

                '====================الحذف======='===================='===========================

                Dim se As String = "delete from RcvSub where no_c=@x1 and no_i=@x2 and sal_s=@x3"
                Dim cme As New SqlCommand(se, cn)
                cme.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cme.Parameters.Add(New SqlParameter("@x2", CStr(TextBox8.Text)))
                cme.Parameters.Add(New SqlParameter("@x3", CDec(TextBox9.Text)))

                cme.Transaction = Trans
                cme.ExecuteNonQuery()

                '=======================================
                Dim sd As String = "delete from tran_IRT where no_c=@x1 and n_rs=@x2 and price=@x3 and date_i=@x4 and no_kshf=" & ssf_t & " "
                Dim cmd As New SqlCommand(sd, cn)
                cmd.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cmd.Parameters.Add(New SqlParameter("@x2", CStr(TextBox8.Text)))
                cmd.Parameters.Add(New SqlParameter("@x3", CDec(TextBox9.Text)))
                cmd.Parameters.Add(New SqlParameter("@x4", Format(DateTimePicker3.Value, "yyyy/MM/dd")))
                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

                '=================slahia======================


                Dim sss As String = "delete from salahia where no_c=@x1 and date_i=@x2 and no_i=@x3 and sal_s=@x4"
                Dim cmds As New SqlCommand(sss, cn)
                cmds.Parameters.Add(New SqlParameter("@x1", Trim(Me.TextBox1.Text)))
                cmds.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value, "yyyy/MM/dd")))
                cmds.Parameters.Add(New SqlParameter("@x3", CStr(Me.TextBox8.Text)))
                cmds.Parameters.AddWithValue("@x4", CDec(TextBox9.Text))
                cmds.Transaction = Trans
                cmds.ExecuteNonQuery()



                '=======================================
                Dim sw As String = "delete from acthion_tran where no_c=@x1 and info=@x2 and sal_s=@x3 and date_i=@x4"
                Dim cmw As New SqlCommand(sw, cn)
                cmw.Parameters.Add(New SqlParameter("@x1", Trim(TextBox1.Text)))
                cmw.Parameters.Add(New SqlParameter("@x2", CStr(TextBox8.Text)))
                cmw.Parameters.Add(New SqlParameter("@x3", CDec(TextBox9.Text)))
                cmw.Parameters.Add(New SqlParameter("@x4", Format(DateTimePicker3.Value, "yyyy/MM/dd")))
                cmw.Transaction = Trans
                cmw.ExecuteNonQuery()
                '=======================================


                t_event = "حذف صنف"
                t_doc = "اذن الاستلام"
                ts = TimeOfDay

                Dim sy As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim cmy As New SqlCommand(sy, cn)
                cmy.Parameters.Add(New SqlParameter("@x1", CStr(TextBox8.Text)))
                cmy.Parameters.Add(New SqlParameter("@x2", t_doc))
                cmy.Parameters.Add(New SqlParameter("@x3", Trim(TextBox1.Text)))
                cmy.Parameters.Add(New SqlParameter("@x4", CInt(TextBox6.Text)))
                cmy.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
                cmy.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
                cmy.Parameters.Add(New SqlParameter("@x7", ts))
                cmy.Parameters.Add(New SqlParameter("@x8", ww))
                cmy.Parameters.Add(New SqlParameter("@x9", t_event))
                cmy.Transaction = Trans
                cmy.ExecuteNonQuery()
                '=========================
            Else
                Dim srr As String = "delete from RcvMain where no_i=@x1 and date_i=@x2 and no_kshf=" & ssf_t & " "
                Dim cmrr As New SqlCommand(srr, cn)
                cmrr.Parameters.Add(New SqlParameter("@x1", CStr(TextBox8.Text)))
                cmrr.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value, "yyyy/MM/dd")))
                cmrr.Transaction = Trans
                cmrr.ExecuteNonQuery()

            End If


            Trans.Commit()
            MsgBox("تم الحذف", MsgBoxStyle.Information, " اجراء حذف")


        Catch err As System.Exception

            Trans.Rollback()
            MsgBox("لم يتم حذف  ", MsgBoxStyle.Information, " اجراء حذف")
            MsgBox(err.Message)

        Finally
        End Try
        'total_inf()
        stouck()
        Me.Button6.Enabled = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click



        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim stb As String = "select * from Table_OSTA where no_R=@x1 and date_r=@x2 and no_kshf=" & ssf_t & " "
        Dim cmtm As New SqlCommand(stb, cn)
        cmtm.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
        cmtm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))

        Try
            Dim r6 As SqlDataReader = cmtm.ExecuteReader
            If r6.Read = True Then
                r6.Close()
                MessageBoxEx.Show("لا تستطيع الحذف لان الاذن تم الصرف منه", "مراقبة المخزون", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cn.Close()
                Exit Sub
            Else
                r6.Close()
                cn.Close()
            End If
        Catch

        End Try
        cn.Close()
        '====================الحذف======='===================='===========================

        If MsgBox("هل أنت متأكد من عملية حذفك لهذا الامر ؟", MsgBoxStyle.YesNo, "تأكيد حذف") = MsgBoxResult.Yes Then


            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim Trans As SqlTransaction = cn.BeginTransaction
            Try
                Dim srr As String = "delete from RcvMain where no_i=@x1 and date_i=@x2 and no_kshf=" & ssf_t & " "
                Dim cmrr As New SqlCommand(srr, cn)
                cmrr.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
                cmrr.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value, "yyyy/MM/dd")))
                cmrr.Transaction = Trans
                cmrr.ExecuteNonQuery()
                '=======================================

                Dim sd As String = "delete from RcvSub where no_i=@x1"
                Dim cmd As New SqlCommand(sd, cn)
                cmd.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))

                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

                '=================slahia======================


                Dim ss As String = "delete from salahia where no_i=@x1 and date_i=@x2 "
                Dim cms As New SqlCommand(ss, cn)
                cms.Parameters.Add(New SqlParameter("@x1", Trim(Me.TextBox8.Text)))
                cms.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value, "yyyy/MM/dd")))
                cms.Transaction = Trans
                cms.ExecuteNonQuery()
                '===============================
                Dim stg As String = "delete from tran_IRT where n_rs=@x1 and date_i=@x2 and no_kshf=" & ssf_t & " "
                Dim cmtg As New SqlCommand(stg, cn)

                cmtg.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
                cmtg.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value, "yyyy/MM/dd")))
                cmtg.Transaction = Trans
                cmtg.ExecuteNonQuery()

                '=======================================
                Dim sa As String = "delete from acthion_tran where info=@x1 and date_i=@x2 "
                Dim cma As New SqlCommand(sa, cn)

                cma.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
                cma.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value, "yyyy/MM/dd")))
                cma.Transaction = Trans
                cma.ExecuteNonQuery()

                '=======================================
                t_event = "حذف "

                t_doc = "اذن الاستلام"
                ts = TimeOfDay


                Dim sc As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
                Dim cmwc As New SqlCommand(sc, cn)
                cmwc.Parameters.Add(New SqlParameter("@x1", Trim(TextBox8.Text)))
                cmwc.Parameters.Add(New SqlParameter("@x2", t_doc))
                cmwc.Parameters.Add(New SqlParameter("@x3", Trim(TextBox1.Text)))
                cmwc.Parameters.Add(New SqlParameter("@x4", CInt(TextBox6.Text)))
                cmwc.Parameters.Add(New SqlParameter("@x5", CDec(TextBox9.Text)))
                cmwc.Parameters.Add(New SqlParameter("@x6", Format(Now.Date, "yyyy/MM/dd")))
                cmwc.Parameters.Add(New SqlParameter("@x7", ts))
                cmwc.Parameters.Add(New SqlParameter("@x8", ww))
                cmwc.Parameters.Add(New SqlParameter("@x9", t_event))
                cmwc.Transaction = Trans
                cmwc.ExecuteNonQuery()

                '===============================
                Trans.Commit()

                clear_tool()
                clear_tool_1()
                Me.Button4.Enabled = False
                Me.Button5.Enabled = False
                ComboBox1.SelectedIndex = -1
                Me.DataGridViewX2.Rows.Clear()

                MsgBox("تم حذف  اذن الاستلام", MsgBoxStyle.Information, " مراقبة المخزون")



            Catch err As System.Exception


                Trans.Rollback()
                MsgBox("لم يتم حذف اذن الاستلام", MsgBoxStyle.Information, " مراقبة المخزون")
                MsgBox(err.Message)

            Finally
            End Try

        Else
            MsgBox("لم تتم عملية الحذف ؟", MsgBoxStyle.OkOnly, "تأكيد حذف")
            Exit Sub
        End If


        DataGridViewX2.DataMember = ""
        DataGridViewX2.DataSource = Nothing
        'total_inf()
    End Sub

    Sub tadel()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        Dim Trans As SqlTransaction = cn.BeginTransaction

        Try

            '=======================================

            Dim sqls As String = "insert into RcvSub(no_c,no_i,qun_r,sal_s,gema,txt_s,mt) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7)"
            Dim cm1 As New SqlCommand(sqls, cn)

            cm1.Parameters.Add((New SqlParameter("@x1", Me.no_c)))
            cm1.Parameters.Add(New SqlParameter("@x2", Trim(TextBox8.Text)))

            cm1.Parameters.Add((New SqlParameter("@x3", TextBox6.Text)))

            cm1.Parameters.Add(New SqlParameter("@x4", CDec(TextBox9.Text)))
            cm1.Parameters.Add(New SqlParameter("@x5", CDec(TextBox10.Text)))

            If Me.RadioButton1.Checked = True Then
                cm1.Parameters.Add(New SqlParameter("@x6", "تم اظافته كرصيد منقول"))
                move_no = "1"
                Me.TextBox4.Text = TextBox6.Text

            ElseIf Me.RadioButton2.Checked = True Then
                move_no = "2"
                cm1.Parameters.Add(New SqlParameter("@x6", "تم اظافته"))
            End If

            If Me.RichTextBox1.Text = "" Then
                cm1.Parameters.Add(New SqlParameter("@x7", "لايوجد"))
            Else
                cm1.Parameters.Add(New SqlParameter("@x7", Me.RichTextBox1.Text))
            End If

            cm1.Transaction = Trans
            cm1.ExecuteNonQuery()
            '===========================================

            Dim sql As String = "insert into salahia(no_c,date_end,mdh,mdh_a,date_mdh,sal_s,no_i,date_i,state_sal) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
            Dim cms As New SqlCommand(sql, cn)


            cms.Parameters.AddWithValue("@x1", Me.no_c).DbType = DbType.String
            cms.Parameters.AddWithValue("@x2", Me.date_end).DbType = DbType.Date
            cms.Parameters.AddWithValue("@x3", Me.mdh).DbType = DbType.String
            cms.Parameters.AddWithValue("@x4", Me.mdh_a).DbType = DbType.String
            cms.Parameters.AddWithValue("@x5", Me.date_mdh).DbType = DbType.Date
            cms.Parameters.AddWithValue("@x6", Me.sal_s).DbType = DbType.Decimal
            cms.Parameters.AddWithValue("@x7 ", Trim(TextBox8.Text)).DbType = DbType.String
            cms.Parameters.AddWithValue("@x8", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd"))
            cms.Parameters.AddWithValue("@x9", 0).DbType = DbType.Int16
            cms.Transaction = Trans
            cms.ExecuteNonQuery()





            ''==========smove_no_i===============


            Dim smov As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i,count1,no_kshf ) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8)"
            Dim cmsmov As New SqlCommand(smov, cn)
            cmsmov.Parameters.AddWithValue("@x1", Me.no_c).DbType = DbType.String
            cmsmov.Parameters.AddWithValue("@x2", Me.qun_r).DbType = DbType.Int32
            cmsmov.Parameters.AddWithValue("@x3", Me.sal_s).DbType = DbType.Decimal
            cmsmov.Parameters.AddWithValue("@x4", Me.move_no).DbType = DbType.Int32
            cmsmov.Parameters.AddWithValue("@x5", Trim(TextBox8.Text)).DbType = DbType.String
            cmsmov.Parameters.AddWithValue("@x6", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd"))
            cmsmov.Parameters.AddWithValue("@x7", 0).DbType = DbType.Int32
            cmsmov.Parameters.AddWithValue("@x8", ssf_t).DbType = DbType.Int32

            cmsmov.Transaction = Trans
            cmsmov.ExecuteNonQuery()


            ''=====acthion_tran================



            Dim stran As String = "insert into acthion_tran(info,no_c,date_i,qun_tot,sal_s) values (@x1,@x2,@x3,@x4,@x5)"
            Dim cmtran As New SqlCommand(stran, cn)
            cmtran.Parameters.AddWithValue("@x1", Trim(TextBox8.Text)).DbType = DbType.String
            cmtran.Parameters.AddWithValue("@x2", Me.no_c).DbType = DbType.String
            cmtran.Parameters.AddWithValue("@x3", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd"))
            cmtran.Parameters.AddWithValue("@x4", Me.qun_r).DbType = DbType.Int32
            cmtran.Parameters.AddWithValue("@x5", Me.sal_s).DbType = DbType.Decimal
            cmtran.Transaction = Trans
            cmtran.ExecuteNonQuery()



            ''=========================

            t_event = "حفظ صنف"
            t_doc = "اذن الاستلام"
            ts = TimeOfDay


            Dim sevent As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
            Dim cmevent As New SqlCommand(sevent, cn)
            cmevent.Parameters.AddWithValue("@x1", Trim(TextBox8.Text)).DbType = DbType.String
            cmevent.Parameters.AddWithValue("@x2", t_doc).DbType = DbType.String
            cmevent.Parameters.AddWithValue("@x3", Me.no_c).DbType = DbType.String
            cmevent.Parameters.AddWithValue("@x4", Me.qun_r).DbType = DbType.Int32
            cmevent.Parameters.AddWithValue("@x5", Me.sal_s).DbType = DbType.Decimal
            cmevent.Parameters.AddWithValue("@x6", Format(Now.Date, "yyyy/MM/dd"))
            cmevent.Parameters.AddWithValue("@x7", ts)
            cmevent.Parameters.AddWithValue("@x8", ww).DbType = DbType.String
            cmevent.Parameters.AddWithValue("@x9", t_event).DbType = DbType.String

            cmevent.Transaction = Trans
            cmevent.ExecuteNonQuery()




            ''=======================تعديل المخزون========================




            If Me.RadioButton1.Checked = True Then
                siopb = TextBox6.Text

                Dim ss1 As String = "update  matt set no_c=@x1,balance=@x2,iopb=@x3,irct=@x5 where no_c=@x1"
                Dim cmst As New SqlCommand(ss1, cn)
                cmst.Parameters.AddWithValue("@x1", Me.no_c).DbType = DbType.String
                cmst.Parameters.AddWithValue("@x2", total_s).DbType = DbType.Decimal
                cmst.Parameters.AddWithValue("@x3", Me.siopb).DbType = DbType.Decimal
                cmst.Parameters.AddWithValue("@x5", sum_irct).DbType = DbType.Decimal

                cmst.Transaction = Trans
                cmst.ExecuteNonQuery()


            Else

                Dim sss1 As String = "update  matt set no_c=@x1,balance=@x2,irct=@x5 where no_c=@x1"
                Dim cmst1 As New SqlCommand(sss1, cn)
                cmst1.Parameters.AddWithValue("@x1", Me.no_c).DbType = DbType.String
                cmst1.Parameters.Add(New SqlParameter("@x2", total_s)).DbType = DbType.Decimal
                cmst1.Parameters.Add(New SqlParameter("@x5", sum_irct)).DbType = DbType.Decimal

                cmst1.Transaction = Trans
                cmst1.ExecuteNonQuery()

            End If



            'Next

            ''===============================
            Trans.Commit()
            MsgBox("تم حفظ الاصناف في اذن الاستلام  ", MsgBoxStyle.Information, " حفظ")
            'total_inf()
            cn.Close()

        Catch err As System.Exception

            Trans.Rollback()
            MsgBox("لم يتم  حفظ الاصناف في اذن الاستلام", MsgBoxStyle.Critical, " حفظ")
            MsgBox(err.Message)

        Finally
        End Try



    End Sub
    Sub NEWS()




        'If DataGridViewX2.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub
        '***************************
        If DataGridViewX2.RowCount = 0 Then
            MessageBox.Show("لاتوجد عناصر تم ادخالهاالي اذن الاستلام")
            Exit Sub
        End If

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        Dim Trans As SqlTransaction = cn.BeginTransaction

        Try
            Dim s As String = "insert into RcvMain(no_i,date_i,j_r,n_txt,n1_txt,g_b,tvg,u_name,dep_m,dep_mt,dep_nom,name_stock,no_kshf) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9,@x10,@x11,@x12,@x13)"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", CStr(Trim(TextBox8.Text))))
            cm.Parameters.Add(New SqlParameter("@x2", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd")))
            cm.Parameters.Add(New SqlParameter("@x3", Me.ComboBox1.SelectedValue))
            cm.Parameters.Add(New SqlParameter("@x4", TextBox5.Text))
            cm.Parameters.Add(New SqlParameter("@x5", TextBox2.Text))
            cm.Parameters.Add(New SqlParameter("@x6", 0))
            cm.Parameters.Add(New SqlParameter("@x7", 0))
            cm.Parameters.Add(New SqlParameter("@x8", ww))
            cm.Parameters.Add(New SqlParameter("@x9", False))
            cm.Parameters.Add(New SqlParameter("@x10", ""))
            cm.Parameters.Add(New SqlParameter("@x11", True))
            'cm.Parameters.Add((New SqlParameter("@x12", TextBox3.Text)))
            cm.Parameters.Add((New SqlParameter("@x12", ww)))
            cm.Parameters.Add((New SqlParameter("@x13", ssf_t)))
            cm.Transaction = Trans

            cm.ExecuteNonQuery()






            '=======================================

            Dim sqls As String = "insert into RcvSub(no_c,no_i,qun_r,sal_s,gema,txt_s,mt) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7)"
            Dim cm1 As New SqlCommand(sqls, cn)

            cm1.Parameters.Add((New SqlParameter("@x1", Me.no_c)))
            cm1.Parameters.Add(New SqlParameter("@x2", Trim(TextBox8.Text)))

            cm1.Parameters.Add((New SqlParameter("@x3", TextBox6.Text)))

            cm1.Parameters.Add(New SqlParameter("@x4", CDec(TextBox9.Text)))
            cm1.Parameters.Add(New SqlParameter("@x5", CDec(TextBox10.Text)))

            If Me.RadioButton1.Checked = True Then
                cm1.Parameters.Add(New SqlParameter("@x6", "تم اظافته كرصيد منقول"))
                move_no = "1"
                Me.TextBox4.Text = TextBox6.Text

            ElseIf Me.RadioButton2.Checked = True Then
                move_no = "2"
                cm1.Parameters.Add(New SqlParameter("@x6", "تم اظافته"))
            End If

            If Me.RichTextBox1.Text = "" Then
                cm1.Parameters.Add(New SqlParameter("@x7", "لايوجد"))
            Else
                cm1.Parameters.Add(New SqlParameter("@x7", Me.RichTextBox1.Text))
            End If

            cm1.Transaction = Trans
            cm1.ExecuteNonQuery()
            '===========================================

            Dim sql As String = "insert into salahia(no_c,date_end,mdh,mdh_a,date_mdh,sal_s,no_i,date_i,state_sal) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
            Dim cms As New SqlCommand(sql, cn)


            cms.Parameters.AddWithValue("@x1", Me.no_c).DbType = DbType.String
            cms.Parameters.AddWithValue("@x2", Me.date_end).DbType = DbType.Date
            cms.Parameters.AddWithValue("@x3", Me.mdh).DbType = DbType.String
            cms.Parameters.AddWithValue("@x4", Me.mdh_a).DbType = DbType.String
            cms.Parameters.AddWithValue("@x5", Me.date_mdh)
            cms.Parameters.AddWithValue("@x6", Me.sal_s).DbType = DbType.Decimal
            cms.Parameters.AddWithValue("@x7 ", Trim(TextBox8.Text)).DbType = DbType.String
            cms.Parameters.AddWithValue("@x8", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd"))
            cms.Parameters.AddWithValue("@x9", 0).DbType = DbType.Int16
            cms.Transaction = Trans
            cms.ExecuteNonQuery()





            ''==========smove_no_i===============

            Dim smov As String = "insert into tran_IRT(no_c,quntity,price,tr_type,n_rs,date_i,count1,no_kshf) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8)"
            Dim cmsmov As New SqlCommand(smov, cn)
            cmsmov.Parameters.AddWithValue("@x1", Me.no_c).DbType = DbType.String
            cmsmov.Parameters.AddWithValue("@x2", Me.qun_r).DbType = DbType.Int32
            cmsmov.Parameters.AddWithValue("@x3", Me.sal_s).DbType = DbType.Decimal
            cmsmov.Parameters.AddWithValue("@x4", Me.move_no).DbType = DbType.Int32
            cmsmov.Parameters.AddWithValue("@x5", Trim(TextBox8.Text)).DbType = DbType.String
            cmsmov.Parameters.AddWithValue("@x6", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd"))
            cmsmov.Parameters.AddWithValue("@x7", 0).DbType = DbType.Int32
            cmsmov.Parameters.AddWithValue("@x8", ssf_t).DbType = DbType.Int32
            cmsmov.Transaction = Trans
            cmsmov.ExecuteNonQuery()


            ''=====acthion_tran================



            Dim stran As String = "insert into acthion_tran(info,no_c,date_i,qun_tot,sal_s) values (@x1,@x2,@x3,@x4,@x5)"
            Dim cmtran As New SqlCommand(stran, cn)
            cmtran.Parameters.AddWithValue("@x1", Trim(TextBox8.Text)).DbType = DbType.String
            cmtran.Parameters.AddWithValue("@x2", Me.no_c).DbType = DbType.String
            cmtran.Parameters.AddWithValue("@x3", Format(DateTimePicker3.Value.Date, "yyyy/MM/dd"))
            cmtran.Parameters.AddWithValue("@x4", Me.qun_r).DbType = DbType.Int32
            cmtran.Parameters.AddWithValue("@x5", Me.sal_s).DbType = DbType.Decimal
            cmtran.Transaction = Trans
            cmtran.ExecuteNonQuery()



            ''=========================

            t_event = "حفظ صنف"
            t_doc = "اذن الاستلام"
            ts = TimeOfDay


            Dim sevent As String = "insert into action_user(no_doc,type_doc,no_c,qun,price,tr_date,tr_time,name_entry,type_event) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8,@x9)"
            Dim cmevent As New SqlCommand(sevent, cn)
            cmevent.Parameters.AddWithValue("@x1", Trim(TextBox8.Text)).DbType = DbType.String
            cmevent.Parameters.AddWithValue("@x2", t_doc).DbType = DbType.String
            cmevent.Parameters.AddWithValue("@x3", Me.no_c).DbType = DbType.String
            cmevent.Parameters.AddWithValue("@x4", Me.qun_r).DbType = DbType.Int32
            cmevent.Parameters.AddWithValue("@x5", Me.sal_s).DbType = DbType.Decimal
            cmevent.Parameters.AddWithValue("@x6", Format(Now.Date, "yyyy/MM/dd"))
            cmevent.Parameters.AddWithValue("@x7", ts)
            cmevent.Parameters.AddWithValue("@x8", ww).DbType = DbType.String
            cmevent.Parameters.AddWithValue("@x9", t_event).DbType = DbType.String

            cmevent.Transaction = Trans
            cmevent.ExecuteNonQuery()




            ''=======================تعديل المخزون========================




            If Me.RadioButton1.Checked = True Then
                siopb = TextBox6.Text

                Dim ss1 As String = "update  matt set no_c=@x1,balance=@x2,iopb=@x3,irct=@x5 where no_c=@x1"
                Dim cmst As New SqlCommand(ss1, cn)
                cmst.Parameters.AddWithValue("@x1", Me.no_c).DbType = DbType.String
                cmst.Parameters.AddWithValue("@x2", total_s).DbType = DbType.Decimal
                cmst.Parameters.AddWithValue("@x3", Me.siopb).DbType = DbType.Decimal
                cmst.Parameters.AddWithValue("@x5", sum_irct).DbType = DbType.Decimal

                cmst.Transaction = Trans
                cmst.ExecuteNonQuery()


            Else

                Dim sss1 As String = "update  matt set no_c=@x1,balance=@x2,irct=@x5 where no_c=@x1"
                Dim cmst1 As New SqlCommand(sss1, cn)
                cmst1.Parameters.AddWithValue("@x1", Me.no_c).DbType = DbType.String
                cmst1.Parameters.Add(New SqlParameter("@x2", total_s)).DbType = DbType.Decimal
                cmst1.Parameters.Add(New SqlParameter("@x5", sum_irct)).DbType = DbType.Decimal

                cmst1.Transaction = Trans
                cmst1.ExecuteNonQuery()

            End If



            'Next

            '===============================
            Trans.Commit()
            MsgBox("تم حفظ اذن الاستلام  ", MsgBoxStyle.Information, " حفظ")
            'total_inf()
            cn.Close()
            auto_noc()
            xl = l_p(Trim(TextBox8.Text))
            TextBox8.Text = xl
            Me.clear_tool_1()

            Me.DataGridViewX2.Rows.Clear()
            Me.Button4.Enabled = True
            Me.Button5.Enabled = True
            Me.Button6.Enabled = True
        Catch err As System.Exception

            Trans.Rollback()
            MsgBox("لم يتم حفظ اذن الاستلام", MsgBoxStyle.Critical, " حفظ")
            MsgBox(err.Message)
            Me.Button4.Enabled = False
            Me.Button5.Enabled = False
            Me.Button6.Enabled = False
        Finally
        End Try



    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)




        If TextBox8.Text <> "" Then

            If Me.DataGridViewX2.Rows.Count > 0 Then


                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If


                Dim adp As New SqlDataAdapter("SELECT no_i, no_c,name_snc,name_type,date_i,name_r,cast([qun_r] as nvarchar(50)) as qun_r, sal_s, gema, no_ct, n_txt,g_b,tvg, u_name, no_ct1, mt, n1_txt,name_stock FROM [estelam]  WHERE no_i ='" + TextBox8.Text + "'", cn)
                Dim dt As New DataTable
                adp.Fill(dt)

                For i As Integer = 0 To dt.Rows.Count - 1
                    If checkNum(dt.Rows(i).Item("qun_r")) = "int" Then
                        dt.Rows(i).Item("qun_r") = myNo
                    Else
                        dt.Rows(i).Item("qun_r") = FormatNumber(CDec(dt.Rows(i).Item(6)), 3)
                    End If


                Next

                Dim frm As New Form12

                Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo


                '===============================================
                If branch = "الادارة العامة" Then
                    Dim rpt1 As New CrystalReport20

                    rpt1.SetDataSource(dt)
                    frm.CrystalReportViewer1.ReportSource = rpt1

                    Dim Text20 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text20")
                    Text20.Text = branch
                Else
                    Dim rpt2 As New CrystalReport20_froa

                    rpt2.SetDataSource(dt)
                    frm.CrystalReportViewer1.ReportSource = rpt2

                    Dim Text20 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt2.Section1.ReportObjects("Text20")
                    Text20.Text = branch
                End If




                frm.Text = "طباعة "

                frm.ShowDialog()
                cn.Close()
            End If

        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'تصفير=======
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "select no_i,no_i1 from View_maxdate where View_maxdate.no_i=(select max(no_i) from View_maxdate)"

        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "View_maxdate")
        tb = ds.Tables(0)
        Dim dr As DataRow
        Try
            dr = tb.Rows(0)
            Me.TextBox8.Text = dr(0) + 1

            If dr(1) < Year(Now) Then
                Me.TextBox8.Text = "1"
            End If
            cn.Close()
        Catch ex As Exception
            Me.TextBox8.Text = "1"
            cn.Close()
        End Try

        ad.Dispose()
        ds.Dispose()
        cn.Close()
    End Sub

    Private Sub RadioButton8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton8.CheckedChanged
        If RadioButton8.Checked = True Then
            Me.TextBox14.Text = "تم مراجعته ويوجد اخطاء"
        End If

    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        If RadioButton7.Checked = True Then


            Me.TextBox14.Text = "تم مراجعته ولايوجد اخطاء"
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked = True Then

            Me.TextBox14.Text = ""

        End If
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub



    Private Sub Form_s_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If Me.Button3.Enabled = True And Button3.Visible = True Then


            If Me.DataGridViewX2.Rows.Count > 0 Then

                If MsgBox("هل أنت متأكد من عـملية حفظ لهذا الاذن ؟", MsgBoxStyle.YesNo, "تأكيد حفظ") = MsgBoxResult.Yes Then

                    Button3_Click(sender, e)
                Else

                    Exit Sub
                End If

            End If

        End If


    End Sub

    Private Sub dtYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtYear.ValueChanged
        Try

            TextBox8.Text = getNewNo(Me.dtYear.Value.Year, ssf_t, "GetNewNoRcvMain")

        Catch ex As Exception

        End Try
    End Sub
End Class