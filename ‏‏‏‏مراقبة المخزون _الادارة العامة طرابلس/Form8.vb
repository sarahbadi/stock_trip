Imports System.Data.SqlClient

Public Class Form8


    Dim s22 As String = "select * from j_r"
    Dim ada2 As New SqlDataAdapter(s22, cn)
    Dim dsa2 As New DataSet()

    Dim s23 As String = "select * from j_s"
    Dim ada3 As New SqlDataAdapter(s23, cn)
    Dim dsa3 As New DataSet()


    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListView1.View = View.Details

        ada2.Fill(dsa2, "j_r")
        ComboBox1.DataSource = dsa2
        ComboBox1.DisplayMember = "j_r.name_r"
        ComboBox1.ValueMember = "no_r"


        ada3.Fill(dsa3, "j_s")
        ComboBox2.DataSource = dsa3
        ComboBox2.DisplayMember = "j_s.name_s"
        ComboBox2.ValueMember = "n_s"


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.RadioButton1.Checked = True Then
            If Me.ComboBox1.Text <> "" Then
                ListView1.Clear()

                cn.Close()

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If


                Dim TD1 As DataTable
                Dim DROW1 As DataRow
                Dim i, c As Integer
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                'Dim sql As String = "select * from mord where (mord.[name_r] =" & Me.ComboBox1.Text & ")"

                Dim sql As String = "SELECT * from mord WHERE mord.name_r=N'" + Me.ComboBox1.Text + "'"

                'SELECT * from mord where mord.name_r= " & Me.ComboBox1.Text & ""

                Dim da8 As New SqlDataAdapter(sql, cn)
                Dim ds8 As New DataSet
                ds8.Clear()
                da8.Fill(ds8, "mord")
                TD1 = ds8.Tables("mord")
                If TD1.Rows.Count > 0 Then




                    DROW1 = TD1.Rows(i)
                    ListView1.Clear()
                    ListView1.Columns.Add("—ﬁ„ «·’‰›", 100, HorizontalAlignment.Center)
                    ListView1.Columns.Add("«”„ «·’‰›", 350, HorizontalAlignment.Left)

                    ListView1.Columns.Add(" «—ÌŒ «·«” ·«„", 150, HorizontalAlignment.Center)
                    ListView1.Columns.Add("«·ﬂ„Ì… «·„” ·„… ", 150, HorizontalAlignment.Center)
                    ListView1.Columns.Add("«·”⁄— ", 130, HorizontalAlignment.Center)
                    ListView1.Columns.Add(" «·ﬁÌ„…", 130, HorizontalAlignment.Center)
                    ListView1.Columns.Add(" ", 0, HorizontalAlignment.Center)


                    Dim sdl As Short = 1
                    ListView1.Items.Clear()
                    c = TD1.Rows.Count - 1

                    For i = 0 To c
                        Dim litem As New ListViewItem
                        DROW1 = TD1.Rows.Item(i)
                        litem.Text = TD1.Rows(i).Item("no_ct")
                        litem.SubItems.Add(TD1.Rows(i).Item("name_snc"))
                        litem.SubItems.Add(TD1.Rows(i).Item("date_i"))
                        litem.SubItems.Add(TD1.Rows(i).Item("qun_r"))
                        litem.SubItems.Add(TD1.Rows(i).Item("sal_s"))
                        litem.SubItems.Add(TD1.Rows(i).Item("gema"))
                        litem.SubItems.Add(TD1.Rows(i).Item("no_c"))

                        ListView1.Items.Add(litem)

                    Next i

                End If

                ListView1.View = View.Details

            End If
        End If





        If Me.RadioButton2.Checked = True Then

            If Me.ComboBox2.Text <> "" Then
                ListView1.Clear()

                cn.Close()

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If


                Dim TD1 As DataTable
                Dim DROW1 As DataRow
                Dim i, c As Integer
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                'Dim sql As String = "select * from mord where (mord.[name_r] =" & Me.ComboBox1.Text & ")"

                Dim sql As String = "SELECT * from srf WHERE srf.name_s=N'" + Me.ComboBox2.Text + "'"

                'SELECT * from mord where mord.name_r= " & Me.ComboBox1.Text & ""

                Dim da8 As New SqlDataAdapter(sql, cn)
                Dim ds8 As New DataSet
                ds8.Clear()
                da8.Fill(ds8, "srf")
                TD1 = ds8.Tables("srf")
                If TD1.Rows.Count > 0 Then




                    DROW1 = TD1.Rows(i)
                    ListView1.Clear()
                    ListView1.Columns.Add("—ﬁ„ «·’‰›", 100, HorizontalAlignment.Center)
                    ListView1.Columns.Add("«”„ «·’‰›", 350, HorizontalAlignment.Left)

                    ListView1.Columns.Add(" «—ÌŒ «·’—›", 150, HorizontalAlignment.Center)
                    ListView1.Columns.Add("«·ﬂ„Ì… «·„’—Ê›… ", 150, HorizontalAlignment.Center)
                    ListView1.Columns.Add("«·”⁄— ", 130, HorizontalAlignment.Center)
                    ListView1.Columns.Add(" «·ﬁÌ„…", 130, HorizontalAlignment.Center)
                    ListView1.Columns.Add(" ", 0, HorizontalAlignment.Center)


                    Dim sdl As Short = 1
                    ListView1.Items.Clear()
                    c = TD1.Rows.Count - 1

                    For i = 0 To c
                        Dim litem As New ListViewItem
                        DROW1 = TD1.Rows.Item(i)
                        litem.Text = TD1.Rows(i).Item("no_ct")
                        litem.SubItems.Add(TD1.Rows(i).Item("name_snc"))
                        litem.SubItems.Add(TD1.Rows(i).Item("date_s"))
                        litem.SubItems.Add(TD1.Rows(i).Item("qun_s"))
                        litem.SubItems.Add(TD1.Rows(i).Item("sal_s"))
                        litem.SubItems.Add(TD1.Rows(i).Item("gema"))
                        litem.SubItems.Add(TD1.Rows(i).Item("no_c"))

                        ListView1.Items.Add(litem)

                    Next i

                End If

                ListView1.View = View.Details

            End If
        End If
        ListView1.View = View.Details


    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        ListView1.Clear()

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        ListView1.Clear()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New Form9

        If Me.RadioButton1.Checked = True Then
            If ComboBox1.Text <> "" Then

                Dim adp As New SqlDataAdapter("SELECT [no_c],[date_i],[name_r],cast([qun_r]as nvarchar(50))as qun_r,[sal_s],[gema],[no_ct],[name_snc]FROM mord WHERE name_r=N'" + Me.ComboBox1.Text + "'", cn)

                Dim dt As New DataTable
                adp.Fill(dt)

                For i As Integer = 0 To dt.Rows.Count - 1
                    If checkNum(dt.Rows(i).Item("qun_r")) = "int" Then
                        dt.Rows(i).Item("qun_r") = myNo
                    Else
                        dt.Rows(i).Item("qun_r") = FormatNumber(CDec(dt.Rows(i).Item(3)), 3)
                    End If
                Next

                Dim rpt1 As New CrystalReport6
                rpt1.SetDataSource(dt)
                frm.CrystalReportViewer1.ReportSource = rpt1
                Dim Text10 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text10")
                Text10.Text = branch
                frm.ShowDialog()
               
            Else
                MsgBox(" «Œ «— «”„ «·ÃÂ… «·„Ê—œ…")

            End If
        End If

        If Me.RadioButton2.Checked = True Then
            If ComboBox2.Text <> "" Then

                Dim adp As New SqlDataAdapter("SELECT [no_c],[date_s],[name_s],cast([qun_s]as nvarchar(50))as qun_s,[sal_s],[gema],[no_ct],[name_snc]FROM srf WHERE srf.name_s=N'" + Me.ComboBox2.Text + "'", cn)

                Dim dt As New DataTable
                adp.Fill(dt)

                For i As Integer = 0 To dt.Rows.Count - 1
                    If checkNum(dt.Rows(i).Item("qun_s")) = "int" Then
                        dt.Rows(i).Item("qun_s") = myNo
                    Else
                        dt.Rows(i).Item("qun_s") = FormatNumber(CDec(dt.Rows(i).Item(3)), 3)
                    End If
                Next

                Dim rpt1 As New CrystalReport7
                rpt1.SetDataSource(dt)
                frm.CrystalReportViewer1.ReportSource = rpt1


                Dim Text14 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text14")
                Text14.Text = branch
               
                frm.ShowDialog()

                'cn.Close()
            Else
                MsgBox(" «Œ «— «”„ «·ÃÂ… «·„’—Ê› ·Â«")

            End If
        End If
    End Sub


    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
End Class