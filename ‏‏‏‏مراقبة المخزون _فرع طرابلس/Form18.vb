Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Public Class Form18
    Sub s1()
        Dim dt1 As DataTable
        Dim sql1, n1 As String

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        sql1 = "SELECT no_i ,date_i,tvg FROM RcvMain Order by (no_i) ASC "
        Dim da1 As New SqlDataAdapter(sql1, cn)
        Dim ds1 As New DataSet
        ds1.Clear()
        da1.Fill(ds1, "RcvMain")
        dt1 = ds1.Tables("RcvMain")
        If dt1.Rows.Count > 0 Then

        End If
        ListView1.Clear()
        Dim dr1 As DataRow
        ListView1.Columns.Add("رقم المستند", 150, HorizontalAlignment.Center)
        ListView1.Columns.Add("تاريخ الاستلام", 150, HorizontalAlignment.Center)
        ListView1.Columns.Add("اجمالى المستند بالحروف", 700, HorizontalAlignment.Center)

        Dim sdl As Short = 1
        ListView1.Items.Clear()
        Dim i, c As Integer
        c = dt1.Rows.Count - 1
        For i = 0 To c
            Dim litem As New ListViewItem
            If sdl = 1 Then
                litem.BackColor = System.Drawing.Color.AliceBlue : sdl = 2
            Else
                litem.BackColor = System.Drawing.Color.White : sdl = 1
            End If
            dr1 = dt1.Rows.Item(i)

            litem.Text = dt1.Rows(i).Item("no_i")
            litem.SubItems.Add(dt1.Rows(i).Item("date_i"))
            litem.SubItems.Add(dt1.Rows(i).Item("tvg"))
            ListView1.Items.Add(litem)
        Next i

    End Sub
    Sub s2()
        Dim dt1 As DataTable
        Dim sql1, n1 As String

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        sql1 = "SELECT * FROM IsuMain Order by (no_s) ASC"
        Dim da1 As New SqlDataAdapter(sql1, cn)
        Dim ds1 As New DataSet
        ds1.Clear()
        da1.Fill(ds1, "IsuMain")
        dt1 = ds1.Tables("IsuMain")
        If dt1.Rows.Count > 0 Then

        End If
        ListView2.Clear()
        Dim dr1 As DataRow
        ListView2.Columns.Add("رقم المستند", 150, HorizontalAlignment.Center)
        ListView2.Columns.Add("تاريخ الصرف", 150, HorizontalAlignment.Center)
        ListView2.Columns.Add("اجمالى المستند بالحروف", 700, HorizontalAlignment.Center)

        Dim sdl As Short = 1
        ListView2.Items.Clear()
        Dim i, c As Integer
        c = dt1.Rows.Count - 1
        For i = 0 To c
            Dim litem As New ListViewItem
            If sdl = 1 Then
                litem.BackColor = System.Drawing.Color.AliceBlue : sdl = 2
            Else
                litem.BackColor = System.Drawing.Color.White : sdl = 1
            End If
            dr1 = dt1.Rows.Item(i)

            litem.Text = dt1.Rows(i).Item("no_s")
            litem.SubItems.Add(dt1.Rows(i).Item("date_s"))
            litem.SubItems.Add(dt1.Rows(i).Item("tvg"))
            ListView2.Items.Add(litem)
        Next i

    End Sub
    Private Sub Form18_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        s1()
        '===============================
        s2()
        '=============================================

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class