
Imports System.Data
Imports System.Data.SqlClient

Public Class Form_t

    

    Private Sub Form_t_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBoxX1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxX1.KeyDown


        If e.KeyCode = Keys.Enter Then



            If TextBoxX1.Text <> "" Then

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim ds1 As DataSet
                ds1 = New DataSet
                ds1.Clear()
                Dim s As String = "select n_rs as [—ﬁ„ «·„” ‰œ],tr_name as[‰Ê⁄ «·Õ—ﬂÂ],quntity as[«·ﬂ„ÌÂ],price as[«·”⁄—],date_i as[ «—ÌŒ «·«” ·«„],date_s as[ «—ÌŒ «·’—›] from moves where moves.[no_c] ='" + TextBoxX1.Text + "'"
                Dim da1 As New SqlDataAdapter(s, cn)

                da1.Fill(ds1, "moves")
                Me.DataGridViewX2.DataSource = ds1
                Me.DataGridViewX2.DataMember = "moves"
                DataGridViewX2.Refresh()
                cn.Close()
            Else
                MsgBox("«œŒ· —ﬁ„ «·’‰›")
            End If
        End If

    End Sub

    'Private Sub TextBoxX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX1.KeyPress
    '    Select Case e.KeyChar
    '        Case "0" To "9", ControlChars.Back
    '            e.Handled = False
    '        Case Else
    '            e.Handled = True
    '    End Select
    'End Sub

    Private Sub TextBoxX1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX1.TextChanged

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        If (TextBoxX1.Text.ToString) <> " " Then

            Dim frm As New Form9
           
            Dim adp As New SqlDataAdapter("SELECT [no_c],[name_snc],[n_type],[name_type],cast([balance]as nvarchar(50))as balance,cast([iopb]as nvarchar(50))as iopb,cast([iiss]as nvarchar(50))as iiss,cast([irct]as nvarchar(50))as irct,cast([quntity]as nvarchar(50))as quntity,[price],[tr_name],[no_ct],cast([returns]as nvarchar(50))as returns FROM hrk where no_c ='" + TextBoxX1.Text + "'", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("balance")) = "int" Then
                    dt.Rows(i).Item("balance") = myNo
                Else
                    dt.Rows(i).Item("balance") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
                End If

                If checkNum(dt.Rows(i).Item("iopb")) = "int" Then
                    dt.Rows(i).Item("iopb") = myNo
                Else
                    dt.Rows(i).Item("iopb") = FormatNumber(CDec(dt.Rows(i).Item(5)), 3)
                End If


                If checkNum(dt.Rows(i).Item("iiss")) = "int" Then
                    dt.Rows(i).Item("iiss") = myNo
                Else
                    dt.Rows(i).Item("iiss") = FormatNumber(CDec(dt.Rows(i).Item(6)), 3)
                End If



                If checkNum(dt.Rows(i).Item("irct")) = "int" Then
                    dt.Rows(i).Item("irct") = myNo
                Else
                    dt.Rows(i).Item("irct") = FormatNumber(CDec(dt.Rows(i).Item(7)), 3)
                End If




                If checkNum(dt.Rows(i).Item("quntity")) = "int" Then
                    dt.Rows(i).Item("quntity") = myNo
                Else
                    dt.Rows(i).Item("quntity") = FormatNumber(CDec(dt.Rows(i).Item(8)), 3)
                End If



                If checkNum(dt.Rows(i).Item("returns")) = "int" Then
                    dt.Rows(i).Item("returns") = myNo
                Else
                    dt.Rows(i).Item("returns") = FormatNumber(CDec(dt.Rows(i).Item(12)), 3)
                End If
            Next


            Dim rpt1 As New CrystalReport4
            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1


            Dim Text7 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text7")
            Text7.Text = branch
            frm.ShowDialog()

        Else
            'MsgBox(" «œŒ· —ﬁ„ «·’‰› ")
            Exit Sub

        End If
    End Sub

    Private Sub DataGridViewX2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX2.CellContentClick

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

        If (TextBoxX1.Text.ToString) <> " " Then
            'cast([quntity]as nvarchar(50))as quntity
            Dim frm As New Form9

            Dim adp As New SqlDataAdapter("SELECT [n_rs],[tr_name],cast([quntity]as nvarchar(50))as quntity,[price],[date_i],[date_s],[no_c] FROM [dbo].[moves] where no_c ='" + TextBoxX1.Text + "'", cn)

            'Dim adp As New SqlDataAdapter("SELECT [n_rs],[tr_name],[quntity]as nvarchar(50))as quntity,[price],[date_i],[date_s],[no_c] moves where no_c ='" + TextBoxX1.Text + "'", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1

                If checkNum(dt.Rows(i).Item("quntity")) = "int" Then
                    dt.Rows(i).Item("quntity") = myNo
                Else
                    dt.Rows(i).Item("quntity") = FormatNumber(CDec(dt.Rows(i).Item(8)), 3)
                End If

            Next


            Dim rpt1 As New CrystalRepmoves
            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1


            Dim Text7 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text7")
            Text7.Text = branch
            frm.ShowDialog()

        Else
            'MsgBox(" «œŒ· —ﬁ„ «·’‰› ")
            Exit Sub

        End If
    End Sub
End Class