Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar

Public Class matt_bay
    Dim i As New Integer()
    Dim srf_ch, tr_t As Boolean
    Dim move_no As String
    Dim sum_irct, sum_iiss, sum_return, total_s As New Integer()
    Dim siopb As Integer
    Dim s1 As String = "select * from matt_buy"
    Dim adm As New SqlDataAdapter(s1, cn)
    Dim dsm As New DataSet()
    '===========================

    Dim st As String = "select * from total_buy"
    Dim adt As New SqlDataAdapter(st, cn)
    Dim dst As New DataSet()
    '===========================
    Dim s2 As String = "select * from j_r"
    Dim ada As New SqlDataAdapter(s2, cn)
    Dim dsa As New DataSet()
    '======================================


    Dim smt As String = "select * from matt"
    Dim admt As New SqlDataAdapter(smt, cn)
    Dim dsmt As New DataSet()
    Dim TDmt As DataTable
    '======================================

    Dim stran As String = "select * from tran"
    Dim adtran As New SqlDataAdapter(stran, cn)
    Dim dstran As New DataSet()
    '========================
    Dim s As String = "select * from T_INF_SRF"
    Dim ads As New SqlDataAdapter(s, cn)
    Dim dss As New DataSet()
    Dim st_ins As String
    Dim chek_s As Boolean


    Dim tot As Boolean


    '===================»ÕÀ «·ﬂ„Ì«  Ì”«ÊÏ 0=================

    Sub view_lstn_i0()



        Dim ds1 As DataSet
        ds1 = New DataSet
        ds1.Clear()
        Dim s As String = "SELECT no_c as [—ﬁ„ «·’‰›],name_snc as[«”‹‹‹‹‹‹‹‹‹„ «·’‹‹‹‹‹‹‹‰‹‹‹‹‹‹‹‹‹‹›],Squn_r as[«·ﬂ„Ì… «·„‘ —«…],Squn_s as[«·ﬂ„Ì… «·„’—Ê›…],Squn_t as [«·ﬂ„Ì… «·„—Ã⁄…],sal_s as[”⁄— «·ÊÕœ…],qun_TT as [«·ﬂ„Ì… «· «·›…],qss as[«·„Œ“Ê‰] from bal_no1 ORDER BY no_ct1 "

        Dim da1 As New SqlDataAdapter(s, cn)

        da1.Fill(ds1, "bal_no1")
        Me.DataGridViewX1.DataSource = ds1
        Me.DataGridViewX1.DataMember = "bal_no1"
        DataGridViewX1.Refresh()
        cn.Close()
    End Sub


    '===========================»ÕÀ «·ﬂ„Ì«  ·«Ì”«ÊÏ 0============
    Sub view_lstn_i()



        Dim ds1 As DataSet
        ds1 = New DataSet
        ds1.Clear()
        Dim s As String = "SELECT no_c as [—ﬁ„ «·’‰›],name_snc as[«”‹‹‹‹‹‹‹‹‹„ «·’‹‹‹‹‹‹‹‰‹‹‹‹‹‹‹‹‹‹›],Squn_r as[«·ﬂ„Ì… «·„‘ —«…],Squn_s as[«·ﬂ„Ì… «·„’—Ê›…],Squn_t as [«·ﬂ„Ì… «·„—Ã⁄…],sal_s as[”⁄— «·ÊÕœ…],qun_TT as [«·ﬂ„Ì… «· «·›…],qss as[«·„Œ“Ê‰] from bal_no1  where qss<>0 ORDER BY no_ct1 "

        Dim da1 As New SqlDataAdapter(s, cn)

        da1.Fill(ds1, "bal_no1")
        Me.DataGridViewX1.DataSource = ds1
        Me.DataGridViewX1.DataMember = "bal_no1"
        DataGridViewX1.Refresh()
        'If DataGridViewX1.RowCount = 0 Then
        '    MessageBox.Show("«·«’‰«› «·„÷«›Â ··ﬂ‘› ﬂ„Ì« Â« ’›—")
        '    Exit Sub
        'End If
        cn.Close()
    End Sub


    '=====================«·—’Ìœ===========

    Private Sub matt_bay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_lstn_i()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      

        'where qss <> 0)

        Dim adp As New SqlDataAdapter("SELECT no_c,name_snc,cast([Squn_s] as nvarchar(50))as Squn_s,cast([Squn_r] as nvarchar(50))as Squn_r,cast([Squn_t] as nvarchar(50)) as Squn_t,sal_s,[n_type],cast([qun_TT] as nvarchar(50)) as qun_TT, cast([qss] as nvarchar(50)) as qss,no_ct1,gima FROM bal_no1 ", cn)
        Dim dt As New DataTable
        adp.Fill(dt)

        For i As Integer = 0 To dt.Rows.Count - 1
            If checkNum(dt.Rows(i).Item("Squn_s")) = "int" Then
                dt.Rows(i).Item("Squn_s") = myNo
            Else
                dt.Rows(i).Item("Squn_s") = FormatNumber(CDec(dt.Rows(i).Item(2)), 3)
            End If


            If checkNum(dt.Rows(i).Item("Squn_r")) = "int" Then
                dt.Rows(i).Item("Squn_r") = myNo
            Else
                dt.Rows(i).Item("Squn_r") = FormatNumber(CDec(dt.Rows(i).Item(3)), 3)
            End If
            If checkNum(dt.Rows(i).Item("Squn_t")) = "int" Then
                dt.Rows(i).Item("Squn_t") = myNo
            Else
                dt.Rows(i).Item("Squn_t") = FormatNumber(CDec(dt.Rows(i).Item(4)), 3)
            End If

            If checkNum(dt.Rows(i).Item("qun_TT")) = "int" Then
                dt.Rows(i).Item("qun_TT") = myNo
            Else
                dt.Rows(i).Item("qun_TT") = FormatNumber(CDec(dt.Rows(i).Item(7)), 3)
            End If



            If checkNum(dt.Rows(i).Item("qss")) = "int" Then
                dt.Rows(i).Item("qss") = myNo
            Else
                dt.Rows(i).Item("qss") = FormatNumber(CDec(dt.Rows(i).Item(8)), 3)
            End If
        Next

        Dim frm As New Form9
        Dim rpt1 As New CrystalReport26
        Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

        rpt1.SetDataSource(dt)
        frm.CrystalReportViewer1.ReportSource = rpt1
        Dim Text15 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text15")
        Text15.Text = branch

        '===============================================



        frm.Text = "ÿ»«⁄… "
        frm.ShowDialog()




        '*************************************


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        view_lstn_i()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        view_lstn_i0()
    End Sub
End Class