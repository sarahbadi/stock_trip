Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Form1
  
    '----------------------------

    Dim sum_irct, sum_iiss, sum_return, total_s, sum_talf As New Decimal()
    Dim i, p, w, no As New Integer()
    Dim siopb, iiopb As Decimal
    Dim n_rs As String
    Dim date_i As Date
    Dim ff As Boolean
    '======================================
    Dim sm As String = "select * from matt"
    Dim adm As New SqlDataAdapter(sm, cn)
    Dim dsm As New DataSet()
    Dim TDm As DataTable
    '================================
    Dim scl As String = "select * from cls"
    Dim adcl As New SqlDataAdapter(scl, cn)
    Dim dscl As New DataSet()
    '============================
    Dim sksf As String = "select * from ksf"
    Dim adksf As New SqlDataAdapter(sksf, cn)
    Dim dsksf As New DataSet()
    '======================================
    Dim stran As String = "select * from tran_IRT"
    Dim adtran As New SqlDataAdapter(stran, cn)
    Dim dstran As New DataSet()
    '======================================
    Dim sa As String = "select * from sara"
    Dim adsa As New SqlDataAdapter(sa, cn)
    Dim dssa As New DataSet()
    '======================================
    '=====================«·—’Ìœ===========

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text <> "" Then
                'serch_txt_s()
                ButtonX4_Click(sender, e)
            Else
                clearing()
            End If
        End If
    End Sub

    '=====================«·—’Ìœ===========
    Sub stouck()

        'If TextBox1.Text <> "" Then

        'End If

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "select * from matt where no_c=@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", (TextBox1.Text)))
        Try

            Dim r As SqlDataReader = cm.ExecuteReader

            If r.Read = True Then

                TextBox2.Text = r!name_snc
                Me.ComboBoxEx2.SelectedValue = r!type_k
                Me.ComboBoxEx1.SelectedValue = r!c_type
                TextBox3.Text = r!point_t
                TextBox15.Text = r!iopb
                TextBoxX1.Text = r!returns
                siopb = r!iopb
                Me.ButtonX2.Enabled = False
                Me.ButtonX3.Enabled = True
                Me.ButtonX6.Enabled = True
                r.Close()
            Else
                r.Close()
                ComboBoxEx1.SelectedIndex = -1
                ComboBoxEx2.SelectedIndex = -1
                MsgBox("Â–« «·’‰› ·„ Ì „  ⁄—Ì›… »⁄œ", MsgBoxStyle.OkOnly, " ‰»Ì…")

                ButtonX2.Enabled = True
                Me.ButtonX3.Enabled = False
                Me.ButtonX6.Enabled = False
                Me.clearing_1()
                r.Close()
            End If

        Catch
            MsgBox("ÌÊÃœ Œÿ«¡›Ì »Ì«‰«  «·„Ê«œ", MsgBoxStyle.Critical, " ‰»Ì…")
        End Try
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        'Dim sql As String = "select * from RcvSub where RcvSub.[no_c] LIKE " + "'" + TextBox1.Text + "%" + "' "
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
            If DROW1("no_c") = (TextBox1.Text).ToString Then

                y = Val(DROW1("qun_r"))
                sum_irct = sum_irct + y
            End If
            If DROW1("txt_s") = " „ «Ÿ«› Â ﬂ—’Ìœ „‰ﬁÊ·".ToString Then

                siopb = Val(DROW1("qun_r"))

            End If

        Next
        '===============«Ã„«·Ì «·„’—Ê›==================

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
            If DROW3("no_c") = (TextBox1.Text).ToString Then

                y2 = Val(DROW3("qun_s"))
                sum_iiss = sum_iiss + y2

            End If
        Next
        '===============«Ã„«·Ì „— Ã⁄Â==================

        Dim sq4 As String = "select * from matt_return where matt_return.[no_c] ='" + TextBox1.Text + "'"

        Dim ad4 As New SqlDataAdapter(sq4, cn)
        Dim ds4 As New DataSet()
        Dim TD4 As DataTable
        Dim DROW4 As DataRow
        Dim y4 As Decimal
        sum_return = 0.0
        y4 = 0.0
        ad4.Fill(ds4, sq4)
        TD4 = ds4.Tables(sq4)

        For w = 0 To TD4.Rows.Count - 1
            DROW4 = TD4.Rows(w)
            If DROW4("no_c") = (TextBox1.Text).ToString Then

                y4 = Val(DROW4("qun_t"))
                sum_return = sum_return + y4

            End If
        Next

        '=============== «·›==================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq5 As String = "select * from sub_TALEF where sub_TALEF.[no_c] ='" + TextBox1.Text + "'"

        Dim ad5 As New SqlDataAdapter(sq5, cn)
        Dim ds5 As New DataSet()
        Dim TD5 As DataTable
        Dim DROW5 As DataRow
        Dim y5 As Decimal
        sum_talf = 0.0
        y5 = 0.0
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
        Me.total_s = 0.0


        Me.total_s = ((sum_irct + sum_return) - sum_iiss) - sum_talf
        If sum_irct = 0 Then
            siopb = 0
        End If
        cn.Close()
        '=======================================================

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If


        Dim s1 As String = "update  matt set no_c=@x1,balance=@x2,iopb=@x,iiss=@x3,irct=@x4,returns=@x6 where no_c=@x1"
        Dim cm1 As New SqlCommand(s1, cn)
        cm1.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
        cm1.Parameters.Add(New SqlParameter("@x2", total_s))
        cm1.Parameters.Add(New SqlParameter("@x", siopb))
        cm1.Parameters.Add(New SqlParameter("@x3", sum_iiss))
        cm1.Parameters.Add(New SqlParameter("@x4", sum_irct))
        cm1.Parameters.Add(New SqlParameter("@x6", sum_return))
        Try

            cm1.ExecuteNonQuery()
            dsm.Clear()
            adm.Fill(dsm, " matt")
        Catch
        End Try

        TextBox7.Text = 0
        TextBox5.Text = 0
        TextBox18.Text = 0
        TextBoxX1.Text = 0
        TextBox15.Text = 0

        TextBox7.Text = total_s
        TextBox5.Text = sum_iiss
        TextBox18.Text = sum_irct
        TextBoxX1.Text = sum_return
        TextBox15.Text = siopb
        TextBox6.Text = sum_talf
        cn.Close()
    End Sub

    Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        stouck()
        Dim ds As New DataSet()
        ds.Clear()
        Dim s As String = " SELECT no_c AS [—ﬁ„ «·’‰›], MAX(YEAR(date_i)) AS [«·”‰Â], qun_tot AS [ﬂ„Ì… «·„ »ﬁÌÂ], sal_s AS [«·”⁄—] FROM     dbo.acthion_tran GROUP BY no_c, date_i, qun_tot, sal_s HAVING (qun_tot <> 0)AND (no_c = N'" + TextBox1.Text + "')"
        'Dim s As String = "SELECT no_c , MAX(YEAR(date_i)), date_i, qun_tot , sal_s  FROM acthion_tran GROUP BY no_c, date_i, qun_tot, sal_s HAVING (qun_tot <> 0) AND (no_c = N'" + TextBox1.Text + "')"
        'Dim s As String = "SELECT n_rs,date_s,no_c,quntity,price,tr_type,name_s,q_div,count1,Y_S FROM sub_it where no_c ='" + TextBoxX1.Text + "' and Y_S='" + Label6.Text + "'"
        'Dim s As String = " SELECT * from acthion_tran WHERE no_c ='" + TextBoxX1.Text + "' and year([date_i])< '" + TextBoxX2.Text + "' and [qun_tot]>0"

        Dim ad As New SqlDataAdapter(s, cn)
        ds.Clear()
        ad.Fill(ds, "acthion_tran")
        Me.DataGridView1.DataSource = ds
        Me.DataGridView1.DataMember = "acthion_tran"
        Me.DataGridView1.Refresh()
        cn.Close()

        '==========================================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sum_k As New Decimal()
        Dim sql As String = " SELECT * from acthion_tran WHERE no_c ='" + TextBox1.Text + "' and [qun_tot]>0"
        Dim ad1 As New SqlDataAdapter(sql, cn)
        Dim ds1 As New DataSet()
        Dim TD1 As DataTable
        Dim DROW1 As DataRow
        Dim y As Decimal
        y = 0.0
        sum_k = 0.0
        ad1.Fill(ds1, sql)
        TD1 = ds1.Tables(sql)

        For i = 0 To TD1.Rows.Count - 1
            DROW1 = TD1.Rows(i)
            If DROW1("no_c") = (TextBox1.Text) Then

                y = Val(DROW1("qun_tot"))
                sum_k = sum_k + y
            End If
        Next
        TextBox8.Text = sum_k
        '============================
    End Sub
    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'langarabic()
        adksf.Fill(dsksf, "ksf")
        ComboBoxEx2.DataSource = dsksf
        ComboBoxEx2.DisplayMember = "ksf.n_type"
        ComboBoxEx2.ValueMember = "type_k"

        '=================================
        adcl.Fill(dscl, "cls")
        ComboBoxEx1.DataSource = dscl
        ComboBoxEx1.DisplayMember = "cls.name_type"
        ComboBoxEx1.ValueMember = "no_type"


        '====================================
       

        TextBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
        
        AutocomplateCustomSource()
        Me.ButtonX2.Enabled = False
        Me.ButtonX3.Enabled = False
        Me.ButtonX6.Enabled = False
    End Sub
    Sub clearing()
        Me.TextBox2.Clear()
        Me.TextBox3.Text = 0
        'Me.TextBox1.Clear()
        TextBox7.Text = 0
        TextBox5.Text = 0
        TextBox15.Text = 0
        TextBox18.Text = 0
        ComboBoxEx1.SelectedIndex = -1
        ComboBoxEx2.SelectedIndex = -1
        Me.Label6.Text = 0
    End Sub
    Sub clearing_1()
        Me.TextBox2.Clear()
        Me.TextBox3.Text = 0
        TextBox7.Text = 0
        TextBox5.Text = 0
        TextBox15.Text = 0
        TextBox18.Text = 0
        ComboBoxEx1.SelectedIndex = -1
        ComboBoxEx2.SelectedIndex = -1
        Me.Label6.Text = 0
    End Sub
    'Sub cod_1()
    '    If Me.ComboBoxEx2.SelectedIndex <> -1 Then
    '        'Dim total As Double
    '        Dim a As String
    '        '====================‰Ê⁄ «·ﬂ‘›======
    '        a = ("0" + Me.TextBox1.Text)
    '        Me.TextBox1.Text = a
    '        Me.Label6.Text = a
    '        '==========================
    '        'If ComboBoxEx2.SelectedIndex = 0 Then
    '        '    b = 10000000
    '        '    b = (30 * b)
    '        'End If
    '        'If ComboBoxEx2.SelectedIndex = 1 Then
    '        '    b = 10000000
    '        '    b = (31 * b)
    '        'End If
    '        'If ComboBoxEx2.SelectedIndex = 2 Then
    '        '    b = 10000000
    '        '    b = (32 * b)
    '        'End If
    '        'If ComboBoxEx2.SelectedIndex = 3 Then
    '        '    b = 10000000
    '        '    b = (33 * b)
    '        'End If
    '        'If ComboBoxEx2.SelectedIndex = 4 Then
    '        '    b = 10000000
    '        '    b = (34 * b)
    '        'End If
    '        'If ComboBoxEx2.SelectedIndex = 5 Then
    '        '    b = 10000000
    '        '    b = (35 * b)
    '        'End If
    '        'If ComboBoxEx2.SelectedIndex = 6 Then
    '        '    b = 10000000
    '        '    b = (36 * b)
    '        'End If
    '        'If ComboBoxEx2.SelectedIndex = 7 Then
    '        '    b = 10000000
    '        '    b = (5 * b)
    '        'End If
    '        'If ComboBoxEx2.SelectedIndex = 8 Then
    '        '    b = 10000000
    '        '    b = (39 * b)
    '        'End If
    '        'z = a + b
    '        'total = z + Val(Me.TextBox1.Text)

    '        'Me.Label1.Text = total
    '    Else
    '        Exit Sub
    '    End If
    'End Sub
    '=========================«ﬂÊ«œ »ÿ«ﬁÂ «·’‰›================
    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click

        'cod_1()

        If Me.TextBox1.Text.ToString = "" Then
            MsgBox("√œŒ· —ﬁ„ «·’‰› ", MsgBoxStyle.Information, "≈Ã—«¡ ≈÷«›…")
            TextBox1.Focus()
            Exit Sub
        End If

        If Me.TextBox2.Text.ToString = "" Then
            MsgBox("√œŒ· «”„ «·’‰› ", MsgBoxStyle.Information, "≈Ã—«¡ ≈÷«›…")
            TextBox2.Focus()

            Exit Sub
        End If

        If Me.ComboBoxEx2.SelectedValue = -1 Or ComboBoxEx2.Text.ToString = "" Then
            MsgBox("«Œ «— ‰Ê⁄ «·ﬂ‘› ", MsgBoxStyle.Information, "≈Ã—«¡ ≈÷«›…")
            Exit Sub
        End If
        If Me.ComboBoxEx1.SelectedValue = -1 Or ComboBoxEx1.Text.ToString = "" Then
            MsgBox("«Œ «— ÊÕœ…«·’‰›  ", MsgBoxStyle.Information, "≈Ã—«¡ ≈÷«›…")
            Exit Sub
        End If

        If TextBox1.Text <> "" Then
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim s As String = "insert into matt(no_c,name_snc,type_k,c_type,point_t,balance,iopb,iiss,irct,returns,no_ct,no_ct1) values (@x1,@x2,@x3,@x4,@x5,@x7,@x8,@x9,@x10,@x11,@x12,@x13)"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
            cm.Parameters.Add(New SqlParameter("@x2", TextBox2.Text))
            cm.Parameters.Add(New SqlParameter("@x3", Me.ComboBoxEx2.SelectedValue))
            cm.Parameters.Add(New SqlParameter("@x4", Me.ComboBoxEx1.SelectedValue))
            cm.Parameters.Add(New SqlParameter("@x5", TextBox3.Text))

            If Me.TextBox7.Text <> " " Then
                cm.Parameters.Add(New SqlParameter("@x7", CDec(TextBox7.Text)))
            Else
                cm.Parameters.Add(New SqlParameter("@x7", 0))
            End If
            If Me.TextBox15.Text <> " " Then
                cm.Parameters.Add(New SqlParameter("@x8", CDec(TextBox15.Text)))
            Else
                cm.Parameters.Add(New SqlParameter("@x8", 0))
            End If
            If Me.TextBox5.Text <> " " Then
                cm.Parameters.Add(New SqlParameter("@x9", CDec(TextBox5.Text)))
            Else
                cm.Parameters.Add(New SqlParameter("@x9", 0))
            End If
            If Me.TextBox7.Text <> " " Then
                cm.Parameters.Add(New SqlParameter("@x10", CDec(TextBox18.Text)))
            Else
                cm.Parameters.Add(New SqlParameter("@x10", 0))
            End If
            cm.Parameters.Add(New SqlParameter("@x11", TextBoxX1.Text))
            cm.Parameters.Add(New SqlParameter("@x12", Me.Label6.Text))

            If IsNumeric(Me.TextBox1.Text) = True Then
                cm.Parameters.Add(New SqlParameter("@x13", TextBox1.Text))
            Else
                cm.Parameters.Add(New SqlParameter("@x13", 0))
            End If

            Try
                cm.ExecuteNonQuery()
                dsm.Clear()
                adm.Fill(dsm, "matt")

                MsgBox(" „ «·Õ›Ÿ ", MsgBoxStyle.Information, " ‰»Ì…")
                clearing()
                's_tran()
                'addvewi()
                'Me.Button1.Enabled = False
                'Me.Button3.Enabled = False
                'Me.Button4.Enabled = False
                'Me.TextBox1.Focus()
            Catch
                MsgBox("«·”Ã· «·„—«œ «÷«› Â  „ÊÃÊœ ", MsgBoxStyle.Information, " ‰»Ì…")

            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click

        If Me.TextBox1.Text.ToString = "" Then
            MsgBox("√œŒ· —ﬁ„ «·’‰› ", MsgBoxStyle.Information, "≈Ã—«¡  ⁄œÌ·")
            TextBox1.Focus()
            Exit Sub
        End If

        If Me.TextBox2.Text.ToString = "" Then
            MsgBox("√œŒ· «”„ «·’‰› ", MsgBoxStyle.Information, "≈Ã—«¡  ⁄œÌ·")
            TextBox2.Focus()

            Exit Sub
        End If

        If Me.ComboBoxEx2.SelectedValue = -1 Or ComboBoxEx2.Text.ToString = "" Then
            MsgBox("«Œ «— ‰Ê⁄ «·ﬂ‘› ", MsgBoxStyle.Information, "≈Ã—«¡  ⁄œÌ·")
            Exit Sub
        End If
        If Me.ComboBoxEx1.SelectedValue = -1 Or ComboBoxEx1.Text.ToString = "" Then
            MsgBox("«Œ «— ÊÕœ…«·’‰›  ", MsgBoxStyle.Information, "≈Ã—«¡  ⁄œÌ·")
            Exit Sub
        End If

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim s As String = "update  matt set no_c=@x1,name_snc=@x2,type_k=@x3,c_type=@x4,point_t=@x5,balance=@x6,iopb=@x7,iiss=@x8,irct=@x9,returns=@x10,no_ct=@x11 where no_c=@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
        cm.Parameters.Add(New SqlParameter("@x2", TextBox2.Text))
        cm.Parameters.Add(New SqlParameter("@x3", ComboBoxEx2.SelectedValue))
        cm.Parameters.Add(New SqlParameter("@x4", ComboBoxEx1.SelectedValue))
        cm.Parameters.Add(New SqlParameter("@x5", TextBox3.Text))
        cm.Parameters.Add(New SqlParameter("@x6", TextBox7.Text))
        cm.Parameters.Add(New SqlParameter("@x7", TextBox15.Text))
        cm.Parameters.Add(New SqlParameter("@x8", TextBox5.Text))
        cm.Parameters.Add(New SqlParameter("@x9", TextBox18.Text))
        cm.Parameters.Add(New SqlParameter("@x10", TextBoxX1.Text))
        cm.Parameters.Add(New SqlParameter("@x11", Me.Label6.Text))
        Try

            cm.ExecuteNonQuery()

            dsm.Clear()
            adm.Fill(dsm, " matt")

            MsgBox(" „ «· ⁄œÌ·", MsgBoxStyle.Information, " ‰»Ì…")
            TextBox1.Focus()
            clearing()

        Catch

        End Try
        cn.Close()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        ' ''secu_num(e)
        ' ''Select Case Asc(e.KeyChar)
        ' ''    Case 8, 48 To 57
        ' ''        e.Handled = False
        ' ''    Case Else
        ' ''        e.Handled = True
        ' ''End Select
        ''Dim valid_chr = ""
        ''valid_chr = valid_chr + "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        ''If valid_chr.Contains(e.KeyChar) Then
        ''    e.Handled = True
        ''End If
    End Sub





    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        If TextBox1.Text <> "" Then
            Me.clearing_1()
            'serch_txt_s()
            ButtonX4_Click(sender, e)
            'langarabic()
        Else
            clearing()
        End If


        If (Mid(Me.TextBox1.Text, 1, 1) = "0") Then
            MsgBox("⁄›Ê« «·—Ã«¡ ⁄œ„ ﬂ «»… «·’›—", MsgBoxStyle.Information, " Õ–Ì— ")

            Me.ButtonX2.Enabled = False
            Exit Sub
        Else
            Dim x As String
            x = manw(TextBox1.Text)

        End If
    End Sub


    Private Sub ComboBoxEx2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxEx2.Leave
        'cod_1()
    End Sub

    Private Sub ComboBoxEx2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxEx2.SelectedIndexChanged
        ComboBoxEx2.Refresh()
    End Sub



    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click


        'Dim com As Integer = ComboBoxEx1.SelectedValue
        'Dim fb As New Form2
        'fb.ShowDialog()
        'fillcbo(ComboBoxEx1, "cls", "cls.name_type", "cls.no_type")
        'ComboBoxEx1.SelectedValue = com
        '===================================
        Dim k As New Fw_part
        k.GroupPanel1.Text = "«·ÊÕœ« "
        k.Label1.Text = "«”„ «·ÊÕœ…"
        k.Label2.Visible = False
        k.TextBox1.Visible = False
        k.ShowDialog()
        '=================================
        dscl.Clear()
        ComboBoxEx1.Refresh()
        adcl.Fill(dscl, "cls")
        ComboBoxEx1.DataSource = dscl
        ComboBoxEx1.DisplayMember = "cls.name_type"
        ComboBoxEx1.ValueMember = "no_type"

    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxEx1.SelectedIndexChanged
        ComboBoxEx1.Refresh()
    End Sub







    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click

        Dim k As New Fw_part
        k.GroupPanel1.Text = "«·ﬂ‘Ê›« "
        k.Label1.Text = "«”„ «·ﬂ‘›"
        k.Label2.Visible = True
        k.TextBox1.Visible = True
        k.ButtonX5.Visible = True
        k.ShowDialog()
        '=========================
        'dsksf.Clear()
        ComboBoxEx1.Refresh()
        adksf.Fill(dsksf, "ksf")
        ComboBoxEx2.DataSource = dsksf
        ComboBoxEx2.DisplayMember = "ksf.n_type"
        ComboBoxEx2.ValueMember = "type_k"
        '================================
        'Dim com As Integer = ComboBoxEx2.SelectedValue
        'Dim fb As New msg_q
        'fb.ShowDialog()
        'fillcbo(ComboBoxEx2, "ksf", "ksf.n_type", "ksf.type_k")
        'ComboBoxEx2.SelectedValue = com
    End Sub



    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        del()
        Dim ds As New DataSet()
        ds.Clear()
        '
        'DataGridViewX1.DataMember = ""
        'DataGridViewX1.DataSource = Nothing
        Dim s As String = "SELECT n_rs,date_i,no_c,quntity,price,tr_type,name_r,Y_R FROM sub_st where no_c ='" + TextBox1.Text + "' And Y_R='" + TextBox4.Text + "'"
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
        'DataGridViewX2.DataMember = ""
        'DataGridViewX2.DataSource = Nothing
        Dim s1 As String = "SELECT n_rs,date_s,no_c,quntity,price,tr_type,name_s,q_div,count1,Y_S FROM sub_it where no_c ='" + TextBox1.Text + "' and Y_S='" + TextBox4.Text + "'"
        Dim ad1 As New SqlDataAdapter(s1, cn)
        ds1.Clear()
        ad1.Fill(ds1, "sub_it")
        Me.DataGridViewX2.DataSource = ds1
        Me.DataGridViewX2.DataMember = "sub_it"
        Me.DataGridViewX2.Refresh()
        cn.Close()
        'DataGridViewX2.Rows.Clear()


        '===================================
        '========================================-
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim dst As New DataSet()
        dst.Clear()
        'DataGridViewX3.DataMember = ""
        'DataGridViewX3.DataSource = Nothing
        Dim st As String = "SELECT n_rs,date_i,no_c,quntity,price,tr_type,n_txt,Y_T FROM sut_tt where no_c ='" + TextBox1.Text + "' and Y_T='" + TextBox4.Text + "'"
        Dim adt As New SqlDataAdapter(st, cn)
        dst.Clear()
        adt.Fill(dst, "sut_tt")
        Me.DataGridViewX3.DataSource = dst
        Me.DataGridViewX3.DataMember = "sut_tt"
        Me.DataGridViewX3.Refresh()
        cn.Close()
        'DataGridViewX3.Rows.Clear()

        '=============================== ''==============================„Ê«œ  «·›Â=================

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim dstt As New DataSet()
        dstt.Clear()
        'DataGridViewX3.DataMember = ""
        'DataGridViewX3.DataSource = Nothing
        Dim stt As String = "SELECT n_rs,date_T,no_c,quntity,price,tr_type,balance,YTT FROM sub_mattalef where no_c ='" + TextBox1.Text + "' and YTT='" + TextBox4.Text + "'"
        Dim adtt As New SqlDataAdapter(stt, cn)
        dstt.Clear()
        adtt.Fill(dstt, "sub_mattalef")
        Me.DataGridViewX4.DataSource = dstt
        Me.DataGridViewX4.DataMember = "sub_mattalef"
        Me.DataGridViewX4.Refresh()
        cn.Close()
        'DataGridViewX3.Rows.Clear()

        '==========================================

        For i As Integer = 0 To DataGridViewX1.RowCount - 1
            Dim sql As String = "insert into sara(info_is,date_inf,no_c,qun_t,price,tr_no,j_h,qmt,cont_c,Y_RST)values(@info_is,@date_inf,@no_c,@qun_t,@price,@tr_no,@j_h,@qmt,@cont_c,@Y_RST)"
            Dim cm As New SqlCommand(sql, cn)
            cm.Parameters.AddWithValue("@info_is", DataGridViewX1.Rows(i).Cells(0).Value).DbType = DbType.String
            cm.Parameters.AddWithValue("@date_inf", DataGridViewX1.Rows(i).Cells(1).Value).DbType = DbType.Date
            cm.Parameters.AddWithValue("@no_c", DataGridViewX1.Rows(i).Cells(2).Value).DbType = DbType.String
            cm.Parameters.AddWithValue("@qun_t", DataGridViewX1.Rows(i).Cells(3).Value).DbType = DbType.Decimal
            cm.Parameters.AddWithValue("@price", DataGridViewX1.Rows(i).Cells(4).Value).DbType = DbType.Decimal
            cm.Parameters.AddWithValue("@tr_no", DataGridViewX1.Rows(i).Cells(5).Value).DbType = DbType.Int32
            cm.Parameters.AddWithValue("@j_h", DataGridViewX1.Rows(i).Cells(6).Value).DbType = DbType.String
            cm.Parameters.AddWithValue("@qmt", 0).DbType = DbType.Int32
            cm.Parameters.AddWithValue("@cont_c", 0).DbType = DbType.Int32
            cm.Parameters.AddWithValue("@Y_RST", DataGridViewX1.Rows(i).Cells(7).Value).DbType = DbType.Int32
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next


        '==========================================
        For i As Integer = 0 To DataGridViewX2.RowCount - 1
            Dim sql2 As String = "insert into sara(info_is,date_inf,no_c,qun_t,price,tr_no,j_h,qmt,cont_c,Y_RST)values(@info_is,@date_inf,@no_c,@qun_t,@price,@tr_no,@j_h,@qmt,@cont_c,@Y_RST)"
            Dim cm2 As New SqlCommand(sql2, cn)
            cm2.Parameters.AddWithValue("@info_is", DataGridViewX2.Rows(i).Cells(0).Value).DbType = DbType.String
            cm2.Parameters.AddWithValue("@date_inf", DataGridViewX2.Rows(i).Cells(1).Value).DbType = DbType.Date
            cm2.Parameters.AddWithValue("@no_c", DataGridViewX2.Rows(i).Cells(2).Value).DbType = DbType.String
            cm2.Parameters.AddWithValue("@qun_t", DataGridViewX2.Rows(i).Cells(3).Value).DbType = DbType.Decimal
            cm2.Parameters.AddWithValue("@price", DataGridViewX2.Rows(i).Cells(4).Value).DbType = DbType.Decimal
            cm2.Parameters.AddWithValue("@tr_no", DataGridViewX2.Rows(i).Cells(5).Value).DbType = DbType.Int32
            cm2.Parameters.AddWithValue("@j_h", DataGridViewX2.Rows(i).Cells(6).Value).DbType = DbType.String
            cm2.Parameters.AddWithValue("@qmt", DataGridViewX2.Rows(i).Cells(7).Value).DbType = DbType.Decimal
            cm2.Parameters.AddWithValue("@cont_c", DataGridViewX2.Rows(i).Cells(8).Value).DbType = DbType.Int32
            cm2.Parameters.AddWithValue("@Y_RST", DataGridViewX2.Rows(i).Cells(9).Value).DbType = DbType.Int32
            cn.Open()
            cm2.ExecuteNonQuery()
            cn.Close()
        Next

        ''================================================
        '==========================================
     
        For i As Integer = 0 To DataGridViewX3.RowCount - 1
            Dim sql3 As String = "insert into sara(info_is,date_inf,no_c,qun_t,price,tr_no,j_h,qmt,cont_c,Y_RST)values(@info_is,@date_inf,@no_c,@qun_t,@price,@tr_no,@j_h,@qmt,@cont_c,@Y_RST)"
            Dim cm3 As New SqlCommand(sql3, cn)
            cm3.Parameters.AddWithValue("@info_is", DataGridViewX3.Rows(i).Cells(0).Value).DbType = DbType.String
            cm3.Parameters.AddWithValue("@date_inf", DataGridViewX3.Rows(i).Cells(1).Value).DbType = DbType.Date
            cm3.Parameters.AddWithValue("@no_c", DataGridViewX3.Rows(i).Cells(2).Value).DbType = DbType.String
            cm3.Parameters.AddWithValue("@qun_t", DataGridViewX3.Rows(i).Cells(3).Value).DbType = DbType.Decimal
            cm3.Parameters.AddWithValue("@price", DataGridViewX3.Rows(i).Cells(4).Value).DbType = DbType.Decimal
            cm3.Parameters.AddWithValue("@tr_no", DataGridViewX3.Rows(i).Cells(5).Value).DbType = DbType.Int32
            cm3.Parameters.AddWithValue("@j_h", DataGridViewX3.Rows(i).Cells(6).Value).DbType = DbType.String
            cm3.Parameters.AddWithValue("@qmt", 0).DbType = DbType.Int32
            cm3.Parameters.AddWithValue("@cont_c", 0).DbType = DbType.Int32
            cm3.Parameters.AddWithValue("@Y_RST", DataGridViewX3.Rows(i).Cells(7).Value).DbType = DbType.Int32
            cn.Open()
            cm3.ExecuteNonQuery()
            cn.Close()
        Next



        ''==============================„Ê«œ  «·›Â=================

        For i As Integer = 0 To DataGridViewX4.RowCount - 1
            Dim sql4 As String = "insert into sara(info_is,date_inf,no_c,qun_t,price,tr_no,j_h,qmt,cont_c,Y_RST)values(@info_is,@date_inf,@no_c,@qun_t,@price,@tr_no,@j_h,@qmt,@cont_c,@Y_RST)"
            Dim cm4 As New SqlCommand(sql4, cn)
            cm4.Parameters.AddWithValue("@info_is", DataGridViewX4.Rows(i).Cells(0).Value).DbType = DbType.String
            cm4.Parameters.AddWithValue("@date_inf", DataGridViewX4.Rows(i).Cells(1).Value).DbType = DbType.Date
            cm4.Parameters.AddWithValue("@no_c", DataGridViewX4.Rows(i).Cells(2).Value).DbType = DbType.String
            cm4.Parameters.AddWithValue("@qun_t", DataGridViewX4.Rows(i).Cells(3).Value).DbType = DbType.Decimal
            cm4.Parameters.AddWithValue("@price", DataGridViewX4.Rows(i).Cells(4).Value).DbType = DbType.Decimal
            cm4.Parameters.AddWithValue("@tr_no", DataGridViewX4.Rows(i).Cells(5).Value).DbType = DbType.Int32
            cm4.Parameters.AddWithValue("@j_h", "«·„Œ«“‰ «·⁄«„Â").DbType = DbType.String
            cm4.Parameters.AddWithValue("@qmt", 0).DbType = DbType.Int32
            cm4.Parameters.AddWithValue("@cont_c", 0).DbType = DbType.Int32
            cm4.Parameters.AddWithValue("@Y_RST", DataGridViewX4.Rows(i).Cells(7).Value).DbType = DbType.Int32
            cn.Open()
            cm4.ExecuteNonQuery()
            cn.Close()
        Next


        If TextBox1.ToString = "" Then
            MsgBox("«œŒ· —ﬁ„ «·’‰› ", MsgBoxStyle.Information, "ÿ»«⁄… ")
            Exit Sub

        Else



            '11111111111111111111
            Dim adp As New SqlDataAdapter("select date_inf,info_is,no_c,cast([qun_t] as nvarchar(50)) as qun_t,price,tr_no,n_type,name_snc,cast([balance] as nvarchar(50)) as balance,cast([iopb] as nvarchar(50)) as iopb,no_ct,j_h,qmt,cont_c,qun_tt from card_n where [no_c]='" + TextBox1.Text + "'", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_t")) = "int" Then
                    dt.Rows(i).Item("qun_t") = myNo
                Else
                    dt.Rows(i).Item("qun_t") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
                End If

                If checkNum(dt.Rows(i).Item("balance")) = "int" Then
                    dt.Rows(i).Item("balance") = myNo
                Else
                    dt.Rows(i).Item("balance") = FormatNumber(CDec(dt.Rows(i).Item(9)), 3)
                End If


                If checkNum(dt.Rows(i).Item("iopb")) = "int" Then
                    dt.Rows(i).Item("iopb") = myNo
                Else
                    dt.Rows(i).Item("iopb") = FormatNumber(CDec(dt.Rows(i).Item(10)), 3)
                End If

            Next

            Dim frm As New Form17
            Dim rpt1 As New Cryno
            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1
            Dim Text15 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text15")
            Text15.Text = branch

            frm.ShowDialog()

            frm.Text = "ÿ»«⁄… »ÿ«ﬁ… «·’‰›"
        
            '11111111111111111111

        End If



        del()
        If TextBox1.Text.ToString = "" Then
            MsgBox("«œŒ· —ﬁ„ «·’‰› ", MsgBoxStyle.Information, "ÿ»«⁄… ")
            Exit Sub

        Else

            '====================================
            del()
            '---------------------------------
        End If
        'del()
        'DataGridViewX1.DataSource = Nothing
        'DataGridViewX2.DataSource = Nothing
        'DataGridViewX3.DataSource = Nothing

    End Sub
    Sub del()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim saa As String = "delete from sara where no_c=@x1"
        Dim cm11 As New SqlCommand(saa, cn)
        cm11.Parameters.Add(New SqlParameter("@x1", (TextBox1.Text)))

        cm11.ExecuteNonQuery()
        dssa.Clear()
        adsa.Fill(dssa, "sara")
        cn.Close()
        dssa.Clear()

    End Sub


    Function manw(ByVal Text1 As String) As String
        Dim a(100) As String
        Dim i, j As Integer
        'Dim nm As String
        Me.TextBox1.Text = Trim(Me.TextBox1.Text)
        Dim a1 As String
        a1 = Me.TextBox1.Text.ToString
        For i = 1 To Len(Text1)
            If (Mid(Me.TextBox1.Text, i, 1) = "0") Then
                Exit For
            End If

            If i = Len(Text1) Then
                If (Mid(Me.TextBox1.Text, i, 1) <> "0") Then
                    a1 = ("0") + a1
                End If
            End If
        Next i
        j = Len(Text1)
        j = j - i
        If j = 1 Then
            a1 = ("0") + a1
        End If
        Me.Label6.Text = Trim(a1)
        manw = Me.Label6.Text
    End Function
    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        If (Mid(Me.TextBox1.Text, 1, 1) = "0") Then
            MsgBox("⁄›Ê« «·—Ã«¡ ⁄œ„ ﬂ «»… «·’›—", MsgBoxStyle.Information, " Õ–Ì— ")

            Me.ButtonX2.Enabled = False
            Exit Sub
        Else
            Dim x As String
            x = manw(TextBox1.Text)
            'Me.ButtonX2.Enabled = True
        End If


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        'If My.Computer.Keyboard.CapsLock Then
        '    MsgBox("CAPS LOCK on")
        '    TextBox1.Text = UCase(TextBox1.Text)
        'Else
        '    MsgBox("CAPS LOCK off")
        'End If

        TextBox1.Text = UCase(TextBox1.Text)

    End Sub



    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        If TextBoxX1.Text <> "" Then
            Dim s As String = "select * from RcvSub where no_c=@x1"
            Dim cm As New SqlCommand(s, cn)
            cm.Parameters.Add(New SqlParameter("@x1", (TextBox1.Text)))
            Try
                Dim r As SqlDataReader = cm.ExecuteReader
                If r.Read = True Then
                    ff = True

                    r.Close()
                Else
                    ff = False
                    r.Close()

                End If

            Catch
                'MsgBox("ÌÊÃœ Œÿ«¡›Ì »Ì«‰«  «·„Ê«œ", MsgBoxStyle.Critical, " ‰»Ì…")
            End Try
        End If


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        If ff = False Then
            Dim s1 As String = "delete from matt where no_c=@x1"
            Dim cm1 As New SqlCommand(s1, cn)
            cm1.Parameters.Add(New SqlParameter("@x1", (TextBox1.Text)))
            cm1.ExecuteNonQuery()
            dsm.Clear()
            adm.Fill(dsm, "matt")
            cn.Close()
            clearing()
            MsgBox(" „ Õ–› «·’‰›", MsgBoxStyle.Information, "  ‰»ÌÂ")
        Else
            MessageBoxEx.Show("·« ” ÿÌ⁄ «·Õ–› ·«‰ «·’‰›   „ «·«” ·«„ ﬂ„Ì… „‰Â", "v1„Œ«“‰", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TextBox1.ToString = "" Then
            MsgBox("«œŒ· —ﬁ„ «·’‰› ", MsgBoxStyle.Information, "ÿ»«⁄… ")
            Exit Sub

        Else

            Dim dss As DataSet
            dss = New DataSet
            dss.Clear()
            Dim f As New Form17
            f.CrystalReportViewer1.ReportSource = f.cryno1
            Dim sad As SqlDataAdapter
            Dim t1 As DataTable
            Dim ss As String = "select * from card_n where card_n.[no_c]='" + TextBox1.Text + "'"
            sad = New SqlDataAdapter(ss, cn)
            sad.Fill(dss, ss)
            t1 = dss.Tables(ss)
            f.cryno1.SetDataSource(dss)
            f.Text = "ÿ»«⁄… »ÿ«ﬁ… «·’‰›"
            f.ShowDialog()
            dss.Clear()

        End If

        If TextBox1.Text.ToString = "" Then
            MsgBox("«œŒ· —ﬁ„ «·’‰› ", MsgBoxStyle.Information, "ÿ»«⁄… ")
            Exit Sub

        Else

            '====================================
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim saa As String = "delete from sara where no_c=@x1"
            Dim cm11 As New SqlCommand(saa, cn)
            cm11.Parameters.Add(New SqlParameter("@x1", (TextBox1.Text)))

            cm11.ExecuteNonQuery()
            dssa.Clear()
            adsa.Fill(dssa, "sara")
            cn.Close()
            dssa.Clear()
            '    '---------------------------------
        End If
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub
    Private Sub AutocomplateCustomSource()
        On Error Resume Next
        Dim i As Integer
        'Dim str As String = My.Settings.dbm_CConnectionString
        'Dim con As New SqlConnection(str)
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim da As New SqlDataAdapter("Select name_snc From matt_t", cn)
        Dim ds As New DataSet
        da.Fill(ds)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            TextBox2.AutoCompleteCustomSource.Add(ds.Tables(0).Rows(i)(0))
        Next i
        cn.Close()
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        Dim ff As Boolean
        If e.KeyCode = Keys.Enter Then


            If (Me.TextBox2.Text) <> "" Then

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                Dim s As String = "select * from matt_t where name_snc=@x1"
                Dim cm As New SqlCommand(s, cn)

                cm.Parameters.Add(New SqlParameter("@x1", (TextBox2.Text)))
                Try
                    Dim r As SqlDataReader = cm.ExecuteReader
                    If r.Read = True Then

                        TextBox1.Text = r!no_c
                        ff = True
                        r.Close()
                    Else
                        ff = False
                        r.Close()
                    End If
                    r.Close()
                Catch
                    'MsgBox("ÌÊÃœ Œÿ«¡›Ì »Ì«‰«  «·„Ê«œ", MsgBoxStyle.Critical, " ‰»Ì…")
                End Try
                cn.Close()
            Else
                Me.TextBox1.Clear()
                clearing()
                Exit Sub
            End If

            If ff = True Then
                ButtonX4_Click(sender, e)
            End If

        End If
    End Sub

    
    'Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    '    If (Me.TextBox2.Text) <> "" Then

    '        If cn.State = ConnectionState.Closed Then
    '            cn.Open()
    '        End If

    '        Dim s As String = "select * from matt_t where name_snc=@x1"
    '        Dim cm As New SqlCommand(s, cn)

    '        cm.Parameters.Add(New SqlParameter("@x1", (TextBox2.Text)))
    '        Try
    '            Dim r As SqlDataReader = cm.ExecuteReader
    '            If r.Read = True Then

    '                TextBox1.Text = r!no_c
    '                ff = True
    '                r.Close()
    '            Else
    '                ff = False
    '                Exit Sub

    '                r.Close()
    '            End If
    '            r.Close()
    '        Catch
    '            'MsgBox("ÌÊÃœ Œÿ«¡›Ì »Ì«‰«  «·„Ê«œ", MsgBoxStyle.Critical, " ‰»Ì…")
    '        End Try
    '        cn.Close()
    '    Else
    '        Me.TextBox1.Clear()
    '        clearing()
    '        Exit Sub
    '    End If

    '    If ff = True Then
    '        ButtonX4_Click(sender, e)
    '    End If

    'End Sub

    Private Sub DataGridViewX3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX3.CellContentClick

    End Sub

    Private Sub TextBox18_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox18.TextChanged

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> " " Then


            Dim adp As New SqlDataAdapter("select no_c,maxdate,cast([qun_tot] as nvarchar(50)) as qun_tot,sal_s from View_stock where (qun_tot <> 0) AND[no_c]='" + TextBox1.Text + "'", cn)

            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_tot")) = "int" Then
                    dt.Rows(i).Item("qun_tot") = myNo
                Else
                    dt.Rows(i).Item("qun_tot") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
                End If


            Next

            Dim frm As New Form19
            Dim rpt1 As New CrystalReport3
            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1
            Dim Text15 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text15")
            Text15.Text = branch
            frm.Text = "ÿ»«⁄… "
            frm.ShowDialog()



            '11111111111111111111
        End If
    End Sub

    

    
End Class

