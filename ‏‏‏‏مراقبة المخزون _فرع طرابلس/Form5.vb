Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar

Public Class Form5
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ser_tr()
    End Sub
    '========================«⁄«œÂ «·ÿ·»========
    Sub ser_tr()

        Dim m, p As Integer
        cn.Close()
        Dim TD1 As DataTable
        Dim DROW1 As DataRow
        Dim i, c As Integer
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sql1 = " select * from pointt "
        Dim da8 As New SqlDataAdapter(sql1, cn)
        Dim ds8 As New DataSet
        ds8.Clear()
        da8.Fill(ds8, "pointt")
        TD1 = ds8.Tables("pointt")
        If TD1.Rows.Count > 0 Then
            DROW1 = TD1.Rows(i)
            Me.XpListView2.Clear()
            XpListView2.Columns.Add("—ﬁ„ «·’‰›", 100, HorizontalAlignment.Center)
            XpListView2.Columns.Add("«”„ «·’‰›", 350, HorizontalAlignment.Center)
            XpListView2.Columns.Add("‰ﬁÿ… «⁄«œ… «·ÿ·»", 195, HorizontalAlignment.Center)
            XpListView2.Columns.Add(" «·—’Ìœ", 100, HorizontalAlignment.Center)
            XpListView2.Columns.Add("0", 0, HorizontalAlignment.Center)

            Dim sdl As Short = 1
            XpListView2.Items.Clear()
            c = TD1.Rows.Count - 1

            For i = 0 To c
                Dim litem As New XPListViewItem
                DROW1 = TD1.Rows.Item(i)
                litem.Text = TD1.Rows(i).Item("no_ct")
                litem.SubItems.Add(TD1.Rows(i).Item("name_snc"))
                p = TD1.Rows(i).Item(("point_t"))
                litem.SubItems.Add(p)
                m = TD1.Rows(i).Item(("balance"))
                litem.SubItems.Add(m)

                If m <= p Then
                    litem.BackColor = System.Drawing.Color.Yellow
                Else
                    litem.BackColor = System.Drawing.Color.AliceBlue
                End If
                litem.SubItems.Add(TD1.Rows(i).Item("no_c"))
                XpListView2.Items.Add(litem)

            Next i
        Else
            MsgBox("·«ÌÊÃœ «’‰«›  Ê’·  ·‰ﬁÿ… «⁄«œ… «·ÿ·»", MsgBoxStyle.OkOnly, "  ‰»ÌÂ")
        End If

        'Me.XpListView2.Sorting = SortOrder.Ascending
        cn.Close()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        'Dim a As New Form7
        Dim ds As DataSet3
        ds = New DataSet3
        ds.Clear()
        Dim f As New Form7
        'f.CrystalReportViewer1.ReportSource = f.crystalReport21
        Dim sad As SqlDataAdapter
        Dim t1 As DataTable
        Dim s As String = "select * from pointt"
        sad = New SqlDataAdapter(s, cn)
        sad.Fill(ds, s)
        t1 = ds.Tables(s)
        'f.crystalReport21.SetDataSource(t1)
        Dim rpt1 As New CrystalReport2
        Application.DoEvents()
        Dim Text2 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text2")
        Text2.Text = branch
        rpt1.SetDataSource(t1)
        f.CrystalReportViewer1.ReportSource = rpt1
        'f.CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.Password = "3573"


        f.ShowDialog()
        'ds.Clear()
    End Sub

    Private Sub XpListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XpListView2.SelectedIndexChanged

    End Sub
End Class