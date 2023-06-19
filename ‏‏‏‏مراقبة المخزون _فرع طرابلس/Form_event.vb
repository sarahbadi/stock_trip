Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar

Public Class Form_event
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ser_tr()
    End Sub

    Sub ser_tr()

        cn.Close()
        Dim TD1 As DataTable
        Dim DROW1 As DataRow
        Dim i, c As Integer
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sql1 = " select * from action_user "
        Dim da8 As New SqlDataAdapter(sql1, cn)
        Dim ds8 As New DataSet
        ds8.Clear()
        da8.Fill(ds8, "action_user")
        TD1 = ds8.Tables("action_user")
        If TD1.Rows.Count > 0 Then
            DROW1 = TD1.Rows(i)
            Me.XpListView2.Clear()
            XpListView2.Columns.Add("—ﬁ„ «·„” ‰œ", 150, HorizontalAlignment.Center)
            XpListView2.Columns.Add("«”„ «·„” ‰œ", 150, HorizontalAlignment.Center)
            XpListView2.Columns.Add("—ﬁ„ «·’‰›", 100, HorizontalAlignment.Center)
            XpListView2.Columns.Add("«·ﬂ„ÌÂ", 100, HorizontalAlignment.Center)
            XpListView2.Columns.Add(" «·”⁄—", 100, HorizontalAlignment.Center)
            XpListView2.Columns.Add(" «—ÌŒ «·ÕœÀ", 200, HorizontalAlignment.Center)
            XpListView2.Columns.Add("”«⁄… «·ÕœÀ", 200, HorizontalAlignment.Center)
            XpListView2.Columns.Add("«”„ «·„” Œœ„", 150, HorizontalAlignment.Center)
            XpListView2.Columns.Add("‰Ê⁄ «·ÕœÀ", 200, HorizontalAlignment.Center)
            Dim sdl As Short = 1
            XpListView2.Items.Clear()
            c = TD1.Rows.Count - 1

            For i = 0 To c
                Dim litem As New XPListViewItem
                DROW1 = TD1.Rows.Item(i)
                litem.Text = TD1.Rows(i).Item("no_doc")
                litem.SubItems.Add(TD1.Rows(i).Item("type_doc"))
                litem.SubItems.Add(TD1.Rows(i).Item("no_c"))
                litem.SubItems.Add(TD1.Rows(i).Item("qun"))
                litem.SubItems.Add(TD1.Rows(i).Item("price"))
                litem.SubItems.Add(TD1.Rows(i).Item("tr_date"))
                litem.SubItems.Add(TD1.Rows(i).Item("tr_time"))
                litem.SubItems.Add(TD1.Rows(i).Item("name_entry"))
                litem.SubItems.Add(TD1.Rows(i).Item("type_event"))
                'p = TD1.Rows(i).Item(("point_t"))
                'litem.SubItems.Add(p)
                'm = TD1.Rows(i).Item(("balance"))
                'litem.SubItems.Add(m)

                'If m <= p Then
                '    litem.BackColor = System.Drawing.Color.Yellow
                'Else
                '    litem.BackColor = System.Drawing.Color.AliceBlue
                'End If
                'litem.SubItems.Add(TD1.Rows(i).Item("no_c"))
                XpListView2.Items.Add(litem)

            Next i
        Else
            'MsgBox("·«ÌÊÃœ «’‰«›  Ê’·  ·‰ﬁÿ… «⁄«œ… «·ÿ·»", MsgBoxStyle.OkOnly, "  ‰»ÌÂ")
        End If

        'Me.XpListView2.Sorting = SortOrder.Ascending
        cn.Close()
    End Sub

    Private Sub XpListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XpListView2.SelectedIndexChanged

    End Sub
End Class