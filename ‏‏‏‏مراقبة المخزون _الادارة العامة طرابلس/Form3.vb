
Imports System.Data
Imports System.Data.SqlClient

Public Class Form3

    Dim n11, n22, sh11, sn11, sh21, sn21 As String

    
    Dim m1, y1, m1y1 As String
    Dim m2, y2, m2y2 As String
    Dim sj_s As String = "select * from j_s"
    Dim adaj_s As New SqlDataAdapter(sj_s, cn)
    Dim dsaj_s As New DataSet()
    '====================================
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TextBox12.Text = Now.Year
        Me.TextBox13.Text = Now.Year
        Me.Label9.Text = My.Application.Info.Copyright
        langarabic()
        '====================================
        'Dim s As String = "SELECT n_type FROM ksf"
        'Dim dsd As New DataSet
        'Dim add = New SqlDataAdapter(s, cn)
        ''Dim da As New Database(cmd)
        'add.Fill(dsd, "n_type") 'list can be any name u want
        'Dim col As New AutoCompleteStringCollection
        'Dim i As Integer
        'For i = 0 To dsd.Tables(0).Rows.Count - 1
        '    col.Add(dsd.Tables(0).Rows(i)("n_type").ToString())
        'Next
        'TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
        'TextBox1.AutoCompleteCustomSource = col
        'TextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        'cn.Close()
        Dim sql As String = "select * from ksf order by n_type"
        Dim ap As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        ap.Fill(ds, "ksf")
        Me.ComboBoxEx1.DataSource = ds
        ComboBoxEx1.DisplayMember = "ksf.n_type"
        ComboBoxEx1.ValueMember = "ksf.type_k"
        '=======================
        adaj_s.Fill(dsaj_s, "j_s")
        ComboBoxEx4.DataSource = dsaj_s
        ComboBoxEx4.DisplayMember = "j_s.name_s"
        ComboBoxEx4.ValueMember = "n_s"

        'adaj_s.Fill(dsaj_s, "j_s")
        ComboBoxEx2.DataSource = dsaj_s
        ComboBoxEx2.DisplayMember = "j_s.name_s"
        ComboBoxEx2.ValueMember = "n_s"
        '--------------------------------------
        Dim sql1 As String = "select * from ksf order by n_type"
        Dim ap1 As New SqlDataAdapter(sql, cn)
        Dim ds1 As New DataSet
        ap1.Fill(ds1, "ksf")
        Me.ComboBoxEx3.DataSource = ds1
        ComboBoxEx3.DisplayMember = "ksf.n_type"
        ComboBoxEx3.ValueMember = "ksf.type_k"
        '=======================

    End Sub

    Private Sub ButtonX16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX16.Click
        '2017/04

        Dim n1, sh1, sn1, n2, ss As String
        Dim n1s, sh1s, sn1s As String
        'Dim n1, sh1, sn1, n2 As String
        If RadioButton6.Checked = True Then
            Me.TextBoxX8.Text = 0

            sh1 = Val(Me.ComboBox3.SelectedItem)
            sn1 = TextBox12.Text

            If sh1 = 12 Or sh1 = 11 Or sh1 = 10 Then
                n1 = sn1 + ("/") + sh1
                n2 = sn1 + ("-") + sh1
            End If


            If sh1 = 1 Or sh1 = 2 Or sh1 = 3 Or sh1 = 4 Or sh1 = 5 Or sh1 = 6 Or sh1 = 7 Or sh1 = 8 Or sh1 = 9 Then
                n1 = sn1 + ("/0") + sh1
                n2 = sn1 + ("-0") + sh1
            End If


            'Me.TextBoxX8.Text = n1

            Dim dsk As DataSet
            dsk = New DataSet
            dsk.Clear()
            Dim s1 As String = "SELECT no_ct as[—ﬁ„ «·’‰›],name_snc as[«”‹‹‹‹‹‹‹‹‹„ «·’‰›],ISDATE as[ «—ÌŒ «·’—›],qun_s as[«·ﬂ„ÌÂ],sal_s as[”⁄— «·ÊÕœÂ],gema as[«·ﬁÌ„Â],n_type as[ «”‹‹‹‹‹‹‹‹‹„ «·ﬂ‘›] from ksf_sal where  (ksf_sal.ISDATE=N'" + n1 + "' or ksf_sal.ISDATE=N'" + n2 + "')"
            'Dim s1 As String = "SELECT * from ksf_sal"
            Dim dks As New SqlDataAdapter(s1, cn)
            dks.Fill(dsk, "ksf_sal")
            Me.DataGridViewX1.DataSource = dsk
            Me.DataGridViewX1.DataMember = "ksf_sal"
            DataGridViewX1.Refresh()
            cn.Close()
        End If
        If RadioButton7.Checked = True Then

            Me.TextBoxX8.Text = 0

            sh1s = Val(Me.ComboBox4.SelectedItem)
            sn1s = TextBox13.Text

            If sh1s = 12 Or sh1s = 11 Or sh1s = 10 Then
                n1s = sn1s + ("/") + sh1s
                ss = sn1s + ("-") + sh1s
                'Me.TextBoxX1.Text = n1s
            End If


            If sh1s = 1 Or sh1s = 2 Or sh1s = 3 Or sh1s = 4 Or sh1s = 5 Or sh1s = 6 Or sh1s = 7 Or sh1s = 8 Or sh1s = 9 Then
                n1s = sn1s + ("/0") + sh1s
                ss = sn1s + ("-0") + sh1s
                'Me.TextBoxX1.Text = n1s
            End If



            Dim dsk As DataSet
            dsk = New DataSet
            dsk.Clear()
            Dim s1 As String = "SELECT no_ct as[—ﬁ„ «·’‰›],name_snc as[«”‹‹‹‹‹‹‹‹‹„ «·’‰›],ISDATE as[ «—ÌŒ «·’—›],qun_s as[«·ﬂ„ÌÂ],sal_s as[”⁄— «·ÊÕœÂ],gema as[«·ﬁÌ„Â],n_type as[ «”‹‹‹‹‹‹‹‹‹„ «·ﬂ‘›] from ksf_sal where  ((ksf_sal.ISDATE='" + n1s + "' or ksf_sal.ISDATE=N'" + ss + "') and (n_type =N'" + ComboBoxEx1.Text + "' ))"
            'Dim s1 As String = "SELECT * from ksf_sal where  ((ksf_sal.ISDATE='" + n1s + "' or ksf_sal.ISDATE=N'" + ss + "') and (n_type =N'" + ComboBoxEx1.Text + "' ))"
            'Dim s1 As String = "SELECT no_c as[—ﬁ„ «·’‰›],name_snc as[«”‹‹‹‹‹‹‹‹‹„ «·’‰›],ISDATE as[ «—ÌŒ «·’—›],qun_s as[«·ﬂ„ÌÂ],sal_s as[”⁄— «·ÊÕœÂ],gema as[«·ﬁÌ„Â],n_type as[«·ﬂ‘›] from ksf_sal where  ksf_sal.[ISDATE]=" & Me.TextBoxX8.Text & ""
            ''Dim s1 As String = "SELECT * from ksf_sal"
            Dim dks As New SqlDataAdapter(s1, cn)
            dks.Fill(dsk, "ksf_sal")
            Me.DataGridViewX1.DataSource = dsk
            Me.DataGridViewX1.DataMember = "ksf_sal"
            DataGridViewX1.Refresh()
            cn.Close()
        End If
      


        If RadioButton2.Checked = True Then

            Me.TextBox1.Text = DateTimePicker2.Value
            Dim x1 As String
            Dim d As Date = CDate(TextBox1.Text)
            x1 = Format(d, "yyyy/MM/dd")

            Me.TextBox2.Text = DateTimePicker4.Value

            Dim x2 As String
            Dim d1 As Date = CDate(TextBox2.Text)
            x2 = Format(d1, "yyyy/MM/dd")



            'Dim s As String = "select * from ofice1  where ((date_s between (#" & DateTimePicker2.Value.ToString("yyyy/MM/dd") & "#) and (#" & DateTimePicker4.Value.ToString("yyyy/MM/dd") & "#)) and (j_s.name_s ='" + Me.ComboBoxEx4.Text + "'))"
            Dim s As String = "select * from xxxxx  where ((convert(varchar(10),date_s,111)between (#" & DateTimePicker2.Value.ToString("yyyy/MM/dd") & "#) and (#" & DateTimePicker4.Value.ToString("yyyy/MM/dd") & "#)) and (j_s.name_s =N'" + Me.ComboBoxEx4.Text + "'))"

            Dim da1 As New SqlDataAdapter(s, cn)
            Dim ds8 As New DataSet()
            ds8.Clear()
            da1.Fill(ds8, "xxxxx")

            Me.DataGridViewX1.DataSource = ds8
            DataGridViewX1.DataMember = "xxxxx"
            DataGridViewX1.Refresh()


        End If
        If RadioButton3.Checked = True Then
            Dim s As String = "SELECT [no_ct] as[—ﬁ„ «·’‰›],name_snc as[«”‹‹‹‹‹‹‹‹‹„ «·’‰›],Maxdate_s as[«Œ—  «—ÌŒ ’—›],[Sumqun_s] as[ «·ﬂ„Ì…«·„’—Ê›…],sal_s as[”⁄— «·ÊÕœÂ],Sumgema as[«·ﬁÌ„Â],n_type as[ «”‹‹‹‹‹‹‹‹‹„ «·ﬂ‘›] from «” ⁄·«„4 "
            Dim da1 As New SqlDataAdapter(s, cn)
            Dim ds8 As New DataSet()
            ds8.Clear()
            da1.Fill(ds8, "«” ⁄·«„4")

            Me.DataGridViewX1.DataSource = ds8
            DataGridViewX1.DataMember = "«” ⁄·«„4"
            DataGridViewX1.Refresh()


        End If
        If RadioButton4.Checked = True Then

            ''Me.TextBox1.Text = DateTimePicker2.Value
            'Dim x1 As String
            'Dim d As Date = CDate(TextBox1.Text)
            'x1 = Format(d, "yyyy/MM/dd")

            'Me.TextBox2.Text = DateTimePicker4.Value

            'Dim x2 As String
            'Dim d1 As Date = CDate(TextBox2.Text)
            'x2 = Format(d1, "yyyy/MM/dd")



            Dim sf As String = "select * from office_ksf  where ((convert(varchar(10),date_s,111) between (#" & DateTimePicker6.Value.ToString("yyyy/MM/dd") & "#) and (#" & DateTimePicker5.Value.ToString("yyyy/MM/dd") & "#)) and (j_s.name_s =N'" + Me.ComboBoxEx2.Text + "')and (ksf.n_type ='" + Me.ComboBoxEx3.Text + "'))"

            Dim daf As New SqlDataAdapter(sf, cn)
            Dim dsf As New DataSet()
            dsf.Clear()
            daf.Fill(dsf, "office_ksf")

            Me.DataGridViewX1.DataSource = dsf
            DataGridViewX1.DataMember = "office_ksf"
            DataGridViewX1.Refresh()


        End If
    End Sub

    Private Sub ButtonX17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX17.Click
        If RadioButton6.Checked = True Then
            Me.TextBoxX8.Text = 0

            Dim n1, sh1, sn1, n2 As String
            sh1 = Val(Me.ComboBox3.SelectedItem)
            sn1 = TextBox12.Text


            If sh1 = 12 Or sh1 = 11 Or sh1 = 10 Then
                n1 = sn1 + ("/") + sh1
                n2 = sn1 + ("-") + sh1
            End If


            If sh1 = 1 Or sh1 = 2 Or sh1 = 3 Or sh1 = 4 Or sh1 = 5 Or sh1 = 6 Or sh1 = 7 Or sh1 = 8 Or sh1 = 9 Then
                n1 = sn1 + ("/0") + sh1
                n2 = sn1 + ("-0") + sh1
            End If

            Dim f As New Form10


            'Dim s As String = "SELECT * from ksf_sal where (ksf_sal.ISDATE='" + n1 + "' or ksf_sal.ISDATE='" + n2 + "')"

            Dim adp As New SqlDataAdapter("SELECT [no_ct],[name_snc],cast([qun_s]as nvarchar(50))as qun_s,[sal_s],[gema],[n_type],[no_c],[ISDATE],[no_ct1] FROM [ksf_sal] where (ksf_sal.ISDATE=N'" + n1 + "' or ksf_sal.ISDATE=N'" + n2 + "')", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_s")) = "int" Then
                    dt.Rows(i).Item("qun_s") = myNo
                Else
                    dt.Rows(i).Item("qun_s") = FormatNumber(CDec(dt.Rows(i).Item(2)), 3)
                End If

            Next


            Dim rpt1 As New CCrystalRep
            rpt1.SetDataSource(dt)
            f.CrystalReportViewer1.ReportSource = rpt1



            Dim Text15 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text15")
            Text15.Text = branch
            Dim Text36 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section5.ReportObjects("Text36")
            If branch = "«·«œ«—… «·⁄«„…" Then

                Text36.Text = "—∆Ì” ﬁ”„ «·„Œ«“‰ Ê«· ﬂ«·Ì›"
            Else
                Text36.Text = "—∆Ì” ÊÕœ… «·„Œ«“‰ Ê«· ﬂ«·Ì›"

            End If



            f.ShowDialog()

        End If


        If RadioButton7.Checked = True Then

            Me.TextBoxX8.Text = 0
            Dim n1, sh1, sn1, n2 As String
            sh1 = Val(Me.ComboBox4.SelectedItem)
            sn1 = TextBox13.Text

            If sh1 = 12 Or sh1 = 11 Or sh1 = 10 Then
                n1 = sn1 + ("/") + sh1
                n2 = sn1 + ("-") + sh1
            End If


            If sh1 = 1 Or sh1 = 2 Or sh1 = 3 Or sh1 = 4 Or sh1 = 5 Or sh1 = 6 Or sh1 = 7 Or sh1 = 8 Or sh1 = 9 Then
                n1 = sn1 + ("/0") + sh1
                n2 = sn1 + ("-0") + sh1
            End If



            Me.TextBoxX8.Text = n1
            
            Dim f As New Form10

            'Dim s As String = "SELECT * from ksf_sal where  ((ksf_sal.ISDATE='" + n1 + "' or ksf_sal.ISDATE='" + n2 + "') and (n_type ='" + ComboBoxEx1.Text + "' ))"


            Dim adp As New SqlDataAdapter("SELECT [no_ct],[name_snc],cast([qun_s]as nvarchar(50))as qun_s,[sal_s],[gema],[n_type],[no_c],[ISDATE],[no_ct1]FROM [ksf_sal]where((ksf_sal.ISDATE=N'" + n1 + "' or ksf_sal.ISDATE=N'" + n2 + "') and (n_type =N'" + ComboBoxEx1.Text + "' ))", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_s")) = "int" Then
                    dt.Rows(i).Item("qun_s") = myNo
                Else
                    dt.Rows(i).Item("qun_s") = FormatNumber(CDec(dt.Rows(i).Item(2)), 3)
                End If

            Next


            Dim rpt1 As New CrystalReport13
            rpt1.SetDataSource(dt)
            f.CrystalReportViewer1.ReportSource = rpt1

            Dim Text16 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text16")
            Text16.Text = branch
            Dim Text36 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section5.ReportObjects("Text36")
            If branch = "«·«œ«—… «·⁄«„…" Then

                Text36.Text = "—∆Ì” ﬁ”„ «·„Œ«“‰ Ê«· ﬂ«·Ì›"
            Else
                Text36.Text = "—∆Ì” ÊÕœ… «·„Œ«“‰ Ê«· ﬂ«·Ì›"

            End If





            f.Text = "ÿ»«⁄… "
            f.ShowDialog()

        End If

     


        'Dim sql1 As String = "select * from xxxxx  where ((date_s between (#" & DateTimePicker2.Value.ToString("yyyy/MM/dd") & "#) and (#" & DateTimePicker4.Value.ToString("yyyy/MM/dd") & "#)) and (j_s.name_s ='" + Me.ComboBoxEx4.Text + "'))"



        If RadioButton3.Checked = True Then

            Dim frm As New Form10
            Dim adp As New SqlDataAdapter("select [no_ct],[name_snc],[Maxdate_s],cast([Sumqun_s]as nvarchar(50))as Sumqun_s,[sal_s],[Sumgema],cast([balance]as nvarchar(50))as balance,[n_type],[no_ct1]FROM «” ⁄·«„4 ", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("Sumqun_s")) = "int" Then
                    dt.Rows(i).Item("Sumqun_s") = myNo
                Else
                    dt.Rows(i).Item("Sumqun_s") = FormatNumber(CDec(dt.Rows(i).Item(3)), 3)
                End If


                If checkNum(dt.Rows(i).Item("balance")) = "int" Then
                    dt.Rows(i).Item("balance") = myNo
                Else
                    dt.Rows(i).Item("balance") = FormatNumber(CDec(dt.Rows(i).Item(3)), 3)
                End If
            Next


            Dim rpt1 As New CrystalReport19
            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1
            Dim Text8 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text8")
            Text8.Text = branch

            Dim Text36 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section5.ReportObjects("Text36")
            If branch = "«·«œ«—… «·⁄«„…" Then

                Text36.Text = "—∆Ì” ﬁ”„ «·„Œ«“‰ Ê«· ﬂ«·Ì›"
            Else
                Text36.Text = "—∆Ì” ÊÕœ… «·„Œ«“‰ Ê«· ﬂ«·Ì›"

            End If
            frm.ShowDialog()

        End If



    End Sub

    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress, TextBox12.KeyPress
        secu_num(e)
    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged

    End Sub


    Private Sub TextBoxX10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        secu_text(e)
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        Me.DataGridViewX1.DataMember = ""
        DataGridViewX1.DataSource = Nothing
    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        Me.DataGridViewX1.DataMember = ""
        DataGridViewX1.DataSource = Nothing
    End Sub
  
   

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Me.DataGridViewX1.DataMember = ""
        DataGridViewX1.DataSource = Nothing
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged

    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged

    End Sub
End Class