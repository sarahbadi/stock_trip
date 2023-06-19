Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar

Public Class Form_sum
    Dim sum_irct, sum_iiss, sum_return, total_s As New Decimal()
    Private Sub Form_sum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        langarabic()
        'sql1 = "SELECT matt_buy.no_c AS [رقم الصنف], Sum(matt_buy.qun_r) AS [الكميةالمشتراه], matt_buy.sal_s AS [سعر الوحدة] FROM(matt_buy) GROUP BY matt_buy.no_c, matt_buy.sal_s"
        Dim dt2 As DataTable
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim sql1 As String
        sql1 = "select RcvSub.no_c,RcvSub.sal_s FROM RcvSub GROUP BY RcvSub.no_c, RcvSub.sal_s"
        Dim da8 As New SqlDataAdapter(sql1, cn)
        Dim ds8 As New DataSet
        ds8.Clear()
        da8.Fill(ds8, "RcvSub")
        dt2 = ds8.Tables("RcvSub")
        If dt2.Rows.Count > 0 Then

        End If
        ListView2.Clear()

        Dim dr2 As DataRow

        ListView2.Columns.Add("رقم الصنف ", 130, HorizontalAlignment.Center)
        ListView2.Columns.Add("السعر ", 120, HorizontalAlignment.Center)

        Dim sdl As Short = 1
        ListView2.Items.Clear()
        Dim i, c As Integer
        c = dt2.Rows.Count - 1
        For i = 0 To c
            Dim litem As New ListViewItem
            dr2 = dt2.Rows.Item(i)

            litem.Text = dt2.Rows(i).Item("no_c")
            litem.SubItems.Add(dt2.Rows(i).Item("sal_s"))
            ListView2.Items.Add(litem)
        Next i

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub
    Sub sersh()
        'Dim sql1 As String
        'sql1 = "SELECT matt_buy.no_c AS [رقم الصنف], Sum(matt_buy.qun_r) AS [الكميةالمشتراه], matt_buy.sal_s AS [سعر الوحدة] FROM(matt_buy) GROUP BY matt_buy.no_c, matt_buy.sal_s"
        'Dim da1 As New SqlDataAdapter(sql1, cn)
        'Dim ds1 As New DataSet()
        'ds1.Clear()
        'da1.Fill(ds1, "sql1")
        'Me.DataGridViewX1.DataSource = ds1
        'DataGridViewX1.DataMember = "sql1"
        'DataGridViewX1.Refresh()
        Dim i, w As Integer

        Dim sql As String = "select * from RcvSub where RcvSub.[no_c] ='" + TextBoxX1.Text + "'"
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
            If DROW1("no_c") = (TextBoxX1.Text) And DROW1("sal_s") = Val(TextBoxX2.Text) Then

                y = Val(DROW1("qun_r"))
                sum_irct = sum_irct + y
            End If

        Next
        '============


        '===============اجمالي المصروف==================

        Dim sq3 As String = "select * from IsuSub where IsuSub.[no_c] ='" + TextBoxX1.Text + "'"

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
            If DROW3("no_c") = (TextBoxX1.Text) And DROW3("sal_s") = Val(TextBoxX2.Text) Then
                y2 = Val(DROW3("qun_s"))
                sum_iiss = sum_iiss + y2

            End If
        Next
        '===============اجمالي مرتجعه==================


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sq4 As String = "select * from matt_return where matt_return.[no_c] ='" + TextBoxX1.Text + "'"


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

            If DROW4("no_c") = (TextBoxX1.Text) And DROW4("sal_s") = Val(TextBoxX2.Text) Then

                y4 = Val(DROW4("qun_t"))
                sum_return = sum_return + y4

            End If
        Next
        cn.Close()
        Me.total_s = 0
        TextBoxX3.Text = 0
        Me.total_s = (sum_irct + sum_return) - sum_iiss
        TextBoxX3.Text = Me.total_s
    End Sub


    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Dim litem As ListViewItem
        'Dim i As Integer
        For Each litem In ListView2.SelectedItems
            Me.TextBoxX1.Text = litem.SubItems(0).Text
            TextBoxX2.Text = litem.SubItems(1).Text
        Next
        sersh()
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        sersh()
    End Sub
End Class