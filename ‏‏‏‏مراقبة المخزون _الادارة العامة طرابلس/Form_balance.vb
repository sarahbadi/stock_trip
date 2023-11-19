Imports System.Data.SqlClient

Public Class Form_balance


    Dim frm As New Form9
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        If RadioButton2.Checked = True Then

            Dim adp As New SqlDataAdapter("SELECT [no_c],[name_snc],[sal_s],[n_type],cast([qss] as nvarchar(50))as qss,[no_ct1],[gima] FROM [dbo].[bal_no1] where qss<>0", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qss")) = "int" Then
                    dt.Rows(i).Item("qss") = myNo
                Else
                    dt.Rows(i).Item("qss") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
                End If


            Next
            Dim rpt1 As New CrystalReport12

            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1


            Dim Text7 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text7")
            Text7.Text = branch

            frm.Text = "طباعة "

            frm.ShowDialog()

        End If

        If RadioButton1.Checked = True Then
            Dim adp As New SqlDataAdapter("SELECT [no_c],[name_snc],[sal_s],[n_type],cast([qss] as nvarchar(50))as qss,[no_ct1],[gima] FROM [bal_no1] where n_type =N'" + Me.ComboBoxEx1.Text + "' and qss<>0", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qss")) = "int" Then
                    dt.Rows(i).Item("qss") = myNo
                Else
                    dt.Rows(i).Item("qss") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
                End If


            Next



            Dim rpt1 As New CrystalReport11

            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1
            Dim Text5 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text5")
            Text5.Text = branch



            frm.ShowDialog()
        End If



    End Sub

    Private Sub Form_balance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        'TextBoxX1.AutoCompleteSource = AutoCompleteSource.CustomSource
        'TextBoxX1.AutoCompleteCustomSource = col
        'TextBoxX1.AutoCompleteMode = AutoCompleteMode.Suggest
        'cn.Close()

        Dim sql As String = "select * from ksf order by n_type"
        Dim ap As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        ap.Fill(ds, "ksf")
        Me.ComboBoxEx1.DataSource = ds
        ComboBoxEx1.DisplayMember = "ksf.n_type"
        ComboBoxEx1.ValueMember = "ksf.type_k"
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        Dispose()
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        If RadioButton1.Checked = True Then
            Dim ds1 As DataSet
            ds1 = New DataSet
            ds1.Clear()
            Dim s1 As String = "SELECT no_c as [رقـم الصـنـف],name_snc as[اســــم الصنف],sal_s as[سعر الوحدة],qss as [الرصــــيد] from bal_no where n_type =N'" + Me.ComboBoxEx1.Text + "' and qss<>0"
            Dim da1 As New SqlDataAdapter(s1, cn)
            da1.Fill(ds1, "bal_no")
            Me.DataGridViewX1.DataSource = ds1
            Me.DataGridViewX1.DataMember = "bal_no"
            DataGridViewX1.Refresh()
            'If DataGridViewX1.RowCount = 0 Then
            '    MessageBox.Show("الاصناف المضافه للكشف كمياتها صفر")
            '    Exit Sub
            'End If
            cn.Close()
        End If
        If RadioButton2.Checked = True Then

            Dim ds1 As DataSet
            ds1 = New DataSet
            ds1.Clear()
            Dim s1 As String = "SELECT no_c as [رقـم الصـنـف],name_snc as[اســــم الصنف],sal_s as[سعر الوحدة],qss as [الرصــــيد] from bal_no  where qss<>0"
            Dim da1 As New SqlDataAdapter(s1, cn)
            da1.Fill(ds1, "bal_no")
            Me.DataGridViewX1.DataSource = ds1
            Me.DataGridViewX1.DataMember = "bal_no"
            DataGridViewX1.Refresh()
            'If DataGridViewX1.RowCount = 0 Then
            '    MessageBox.Show("الاصناف المضافه للكشوفات كمياتها صفر")
            '    Exit Sub
            'End If
            cn.Close()
        End If
    End Sub

    Private Sub TextBoxX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        secu_text(e)
    End Sub

    Private Sub TextBoxX1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGridViewX1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

    End Sub
End Class