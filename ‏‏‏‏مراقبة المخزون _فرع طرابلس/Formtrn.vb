Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar

Public Class Formtrn

    Dim frm As New FIO
    Dim sum_irct, sum_iiss, sum_return, total_s As New Integer()
    Dim i, p, w, no As New Integer()
    Dim siopb, iiopb As Integer
    Dim n_rs As String
    Dim date_i As Date
    Dim n1, sh1, sn1, n2 As String
    '======================================
    Dim sa As String = "select * from moves_prodc"
    Dim adsa As New SqlDataAdapter(sa, cn)
    Dim dssa As New DataSet()
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.TextBoxX3.Text.ToString = "" Then
            MsgBox("أدخل رقم الصنف ", MsgBoxStyle.Information, "إجراء بحث")
            TextBoxX3.Focus()
            Exit Sub
        End If
        If Me.TextBoxX1.Text.ToString = "" Then
            MsgBox("أدخل السنة ", MsgBoxStyle.Information, "إجراء بحث")
            TextBoxX1.Focus()
            Exit Sub
        End If
        'and YSDATE='" & Me.TextBoxX1.Text & "'


        If RadioButton1.Checked = True Then

            ' and YSDATE='" + Me.TextBoxX1.Text + "'"
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim ds4 As New DataSet()
            ds4.Clear()
            DataGridViewX4.DataMember = ""
            DataGridViewX4.DataSource = Nothing
            Dim s4 As String = "SELECT  info_is AS[رقم الاذن], date_inf AS[تاريخ الحركة], no_c AS[رقم الصنف],qun_t AS[الكمية] ,price AS[سعر الوحدة],tr_name AS[نوع الحركة] ,YSDATE AS[بالسنة] FROM moves_prodcf where no_c =N'" + TextBoxX3.Text + "' and (YSDATE=N'" + TextBoxX1.Text + "' or YSDATE=N'" + TextBoxX1.Text + "')"
            Dim ad4 As New SqlDataAdapter(s4, cn)
            ds4.Clear()
            ad4.Fill(ds4, "moves_prodcf")
            Me.DataGridViewX4.DataSource = ds4
            Me.DataGridViewX4.DataMember = "moves_prodcf"
            Me.DataGridViewX4.Refresh()
            cn.Close()
            '========================================

        End If
    End Sub

    Private Sub Formtrn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim Result As MsgBoxResult
        'Result = MsgBox("هل تريد تأكيد الخروج", MsgBoxStyle.OkCancel)
        'If Result = MsgBoxResult.Cancel Then
        '    e.Cancel = True
        'End If
        '====================================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim saa As String = "delete from moves_prodc "
        Dim cm11 As New SqlCommand(saa, cn)
        'cm11.Parameters.Add(New SqlParameter("@x1", (TextBox1.Text)))

        cm11.ExecuteNonQuery()
        dssa.Clear()
        adsa.Fill(dssa, "moves_prodc")
        cn.Close()
        dssa.Clear()
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        If Me.TextBoxX3.Text.ToString = "" Then
            MsgBox("أدخل رقم الصنف ", MsgBoxStyle.Information, "إجراء بحث")
            TextBoxX3.Focus()
            Exit Sub
        End If
        If Me.TextBoxX2.Text.ToString = "" Then
            MsgBox("أدخل السنة ", MsgBoxStyle.Information, "إجراء بحث")
            TextBoxX2.Focus()
            Exit Sub
        End If
        If Me.ComboBox3.Text.ToString = "" Then
            MsgBox("أدخل الشهر ", MsgBoxStyle.Information, "إجراء بحث")
            ComboBox3.Focus()
            Exit Sub
        End If

        'Me.TextBox12.Text = 0

        sh1 = Val(Me.ComboBox3.SelectedItem)
        sn1 = TextBoxX2.Text

        If sh1 = 12 Or sh1 = 11 Or sh1 = 10 Then
            n1 = sn1 + ("/") + sh1
            n2 = sn1 + ("-") + sh1
        End If


        If sh1 = 1 Or sh1 = 2 Or sh1 = 3 Or sh1 = 4 Or sh1 = 5 Or sh1 = 6 Or sh1 = 7 Or sh1 = 8 Or sh1 = 9 Then
            n1 = sn1 + ("/0") + sh1
            n2 = sn1 + ("-0") + sh1

        End If

        '---------------------------------

        If RadioButton2.Checked = True Then


            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim ds4 As New DataSet()
            ds4.Clear()
            DataGridViewX4.DataMember = ""
            DataGridViewX4.DataSource = Nothing
            Dim s4 As String = "SELECT  info_is AS[رقم الاذن], date_inf AS[تاريخ الحركة], no_c AS[رقم الصنف],qun_t AS[الكمية] ,price AS[سعر الوحدة],tr_name AS[نوع الحركة] ,ISDATE AS[بالشهر والسنة] FROM moves_prodcf where no_c =N'" + TextBoxX3.Text + "' and (ISDATE=N'" + Me.n1 + "' or ISDATE=N'" + Me.n2 + "')"
            Dim ad4 As New SqlDataAdapter(s4, cn)
            ds4.Clear()
            ad4.Fill(ds4, "moves_prodcf")
            Me.DataGridViewX4.DataSource = ds4
            Me.DataGridViewX4.DataMember = "moves_prodcf"
            Me.DataGridViewX4.Refresh()
            cn.Close()
            '========================================
        End If
    End Sub

    Private Sub TextBoxX3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBoxX3.Validating
        If Me.TextBoxX3.Text.ToString = "" Then
            MsgBox("أدخل رقم الصنف ", MsgBoxStyle.Information, "إجراء بحث")
            TextBoxX3.Focus()
            Exit Sub
        End If



        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim ds As New DataSet()
        ds.Clear()
        DataGridViewX1.DataMember = ""
        DataGridViewX1.DataSource = Nothing
        Dim s As String = "SELECT n_rs,date_i,no_c,quntity,price,tr_type FROM sub_st where no_c =N'" + TextBoxX3.Text + "'"
        Dim ad As New SqlDataAdapter(s, cn)
        ds.Clear()
        ad.Fill(ds, "sub_st")
        Me.DataGridViewX1.DataSource = ds
        Me.DataGridViewX1.DataMember = "sub_st"
        Me.DataGridViewX1.Refresh()
        cn.Close()
        '========================================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim ds1 As New DataSet()
        ds1.Clear()
        DataGridViewX2.DataMember = ""
        DataGridViewX2.DataSource = Nothing
        Dim s1 As String = "SELECT n_rs,date_s,no_c,quntity,price,tr_type FROM sub_it where no_c =N'" + TextBoxX3.Text + "'"
        Dim ad1 As New SqlDataAdapter(s1, cn)
        ds1.Clear()
        ad1.Fill(ds1, "sub_it")
        Me.DataGridViewX2.DataSource = ds1
        Me.DataGridViewX2.DataMember = "sub_it"
        Me.DataGridViewX2.Refresh()
        cn.Close()
        'DataGridViewX2.Rows.Clear()


        '===================================
        '========================================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim dst As New DataSet()
        dst.Clear()
        DataGridViewX3.DataMember = ""
        DataGridViewX3.DataSource = Nothing
        Dim st As String = "SELECT n_rs,date_i,no_c,quntity,price,tr_type FROM sut_tt where no_c =N'" + TextBoxX3.Text + "'"
        Dim adt As New SqlDataAdapter(st, cn)
        dst.Clear()
        adt.Fill(dst, "sut_tt")
        Me.DataGridViewX3.DataSource = dst
        Me.DataGridViewX3.DataMember = "sut_tt"
        Me.DataGridViewX3.Refresh()
        cn.Close()
        'DataGridViewX2.Rows.Clear()

        '==========================================

        For i As Integer = 0 To DataGridViewX1.RowCount - 1
            Dim sql As String = "insert into moves_prodc(info_is,date_inf,no_c,qun_t,price,tr_no)values(@info_is,@date_inf,@no_c,@qun_t,@price,@tr_no)"
            Dim cm As New SqlCommand(sql, cn)
            cm.Parameters.AddWithValue("@info_is", DataGridViewX1.Rows(i).Cells(0).Value).DbType = DbType.String
            cm.Parameters.AddWithValue("@date_inf", DataGridViewX1.Rows(i).Cells(1).Value).DbType = DbType.Date
            cm.Parameters.AddWithValue("@no_c", DataGridViewX1.Rows(i).Cells(2).Value).DbType = DbType.String
            cm.Parameters.AddWithValue("@qun_t", DataGridViewX1.Rows(i).Cells(3).Value).DbType = DbType.Int32
            cm.Parameters.AddWithValue("@price", DataGridViewX1.Rows(i).Cells(4).Value).DbType = DbType.Double
            cm.Parameters.AddWithValue("@tr_no", DataGridViewX1.Rows(i).Cells(5).Value).DbType = DbType.Int32
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next
        'DataGridViewX1.DataMember = ""
        'DataGridViewX1.DataSource = Nothing

        '==========================================
        For i As Integer = 0 To DataGridViewX2.RowCount - 1
            Dim sql2 As String = "insert into moves_prodc(info_is,date_inf,no_c,qun_t,price,tr_no)values(@info_is,@date_inf,@no_c,@qun_t,@price,@tr_no)"
            Dim cm2 As New SqlCommand(sql2, cn)
            cm2.Parameters.AddWithValue("@info_is", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
            cm2.Parameters.AddWithValue("@date_inf", DataGridViewX2.Rows(i).Cells(1).Value).DbType = DbType.Date
            cm2.Parameters.AddWithValue("@no_c", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.String
            cm2.Parameters.AddWithValue("@qun_t", DataGridViewX2.Rows(i).Cells(3).Value).DbType = DbType.Int32
            cm2.Parameters.AddWithValue("@price", DataGridViewX2.Rows(i).Cells(4).Value).DbType = DbType.Double
            cm2.Parameters.AddWithValue("@tr_no", DataGridViewX2.Rows(i).Cells(5).Value).DbType = DbType.Int32
            cn.Open()
            cm2.ExecuteNonQuery()
            cn.Close()
        Next
        'DataGridViewX2.DataMember = ""
        'DataGridViewX2.DataSource = Nothing
        '================================================
        '==========================================

        For i As Integer = 0 To DataGridViewX3.RowCount - 1
            Dim sql3 As String = "insert into moves_prodc(info_is,date_inf,no_c,qun_t,price,tr_no)values(@info_is,@date_inf,@no_c,@qun_t,@price,@tr_no)"
            Dim cm3 As New SqlCommand(sql3, cn)
            cm3.Parameters.AddWithValue("@info_is", DataGridViewX3.Rows(i).Cells(0).Value).DbType = DbType.String
            cm3.Parameters.AddWithValue("@date_inf", DataGridViewX3.Rows(i).Cells(1).Value).DbType = DbType.Date
            cm3.Parameters.AddWithValue("@no_c", DataGridViewX3.Rows(i).Cells(2).Value).DbType = DbType.String
            cm3.Parameters.AddWithValue("@qun_t", DataGridViewX3.Rows(i).Cells(3).Value).DbType = DbType.Int32
            cm3.Parameters.AddWithValue("@price", DataGridViewX3.Rows(i).Cells(4).Value).DbType = DbType.Double
            cm3.Parameters.AddWithValue("@tr_no", DataGridViewX3.Rows(i).Cells(5).Value).DbType = DbType.Int32
            cn.Open()
            cm3.ExecuteNonQuery()
            cn.Close()
        Next
        '( ksf_sal.[ISDATE]='" + TextBoxX1.Text + "' and n_type ='" + Me.TextBoxX10.Text + "' )"
        DataGridViewX3.DataMember = ""
        DataGridViewX3.DataSource = Nothing


    End Sub





    Private Sub Formtrn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TextBoxX1.Text = Date.Now.Year
        Me.TextBoxX2.Text = Date.Now.Year
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        If Me.TextBoxX3.Text.ToString = "" Then
            MsgBox("أدخل رقم الصنف ", MsgBoxStyle.Information, "إجراء بحث")
            TextBoxX3.Focus()
            Exit Sub
        End If
        If Me.TextBoxX2.Text.ToString = "" Then
            MsgBox("أدخل السنة ", MsgBoxStyle.Information, "إجراء بحث")
            TextBoxX2.Focus()
            Exit Sub
        End If
        If Me.ComboBox3.Text.ToString = "" Then
            MsgBox("أدخل الشهر ", MsgBoxStyle.Information, "إجراء بحث")
            ComboBox3.Focus()
            Exit Sub
        End If

        'Me.TextBox12.Text = 0

        sh1 = Val(Me.ComboBox3.SelectedItem)
        sn1 = TextBoxX2.Text



        If sh1 = 12 Or sh1 = 11 Or sh1 = 10 Then
            n1 = sn1 + ("/") + sh1
            n2 = sn1 + ("-") + sh1
        End If


        If sh1 = 1 Or sh1 = 2 Or sh1 = 3 Or sh1 = 4 Or sh1 = 5 Or sh1 = 6 Or sh1 = 7 Or sh1 = 8 Or sh1 = 9 Then
            n1 = sn1 + ("/0") + sh1
            n2 = sn1 + ("-0") + sh1

        End If
        '---------------------------------

        If RadioButton2.Checked = True Then

            '========================================

            Dim adp As New SqlDataAdapter("SELECT [info_is],[date_inf],[no_c],cast([qun_t]as nvarchar(50))as qun_t,[price],[tr_name],[ISDATE],[ySDATE] FROM moves_prodcf where no_c =N'" + TextBoxX3.Text + "' and (ISDATE=N'" + Me.n1 + "' or ISDATE=N'" + Me.n2 + "')", cn)

            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_t")) = "int" Then
                    dt.Rows(i).Item("qun_t") = myNo
                Else
                    dt.Rows(i).Item("qun_t") = FormatNumber(CDec(dt.Rows(i).Item(3)), 3)
                End If

            Next


            Dim rpt1 As New CrystalReport22
            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1
            Dim Text7 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text7")
            Text7.Text = branch

            frm.ShowDialog()

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If RadioButton1.Checked = True Then

            '========================================
            If Me.TextBoxX3.Text.ToString = "" Then
                MsgBox("أدخل رقم الصنف ", MsgBoxStyle.Information, "إجراء بحث")
                TextBoxX3.Focus()
                Exit Sub
            End If
            If Me.TextBoxX1.Text.ToString = "" Then
                MsgBox("أدخل السنة ", MsgBoxStyle.Information, "إجراء بحث")
                TextBoxX1.Focus()
                Exit Sub
            End If

            'Dim ss As String = "SELECT * FROM moves_prodcf where no_c ='" + TextBoxX3.Text + "' and YSDATE='" + Me.TextBoxX1.Text + "'"


            Dim adp As New SqlDataAdapter("SELECT [info_is],[date_inf],[no_c],cast([qun_t]as nvarchar(50))as qun_t,[price],[tr_name],[ISDATE],[ySDATE] FROM moves_prodcf where no_c =N'" + TextBoxX3.Text + "' and YSDATE=N'" + Me.TextBoxX1.Text + "'", cn)

            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_t")) = "int" Then
                    dt.Rows(i).Item("qun_t") = myNo
                Else
                    dt.Rows(i).Item("qun_t") = FormatNumber(CDec(dt.Rows(i).Item(3)), 3)
                End If

            Next


            Dim rpt1 As New CrystalReport23
            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1

            Dim Text8 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text8")
            Text8.Text = branch



            frm.ShowDialog()

        End If
    End Sub

    Private Sub DataGridViewX4_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX4.CellContentClick

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class