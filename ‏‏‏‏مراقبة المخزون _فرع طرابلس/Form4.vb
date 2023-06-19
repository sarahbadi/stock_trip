Imports System.Data.SqlClient
Public Class Form4
    Dim a_name, n_rs1 As String
    Dim a_datei As Date
    Dim a_qun As Decimal
    Dim a_sals As Decimal
    Dim sa As String = "select * from sara"
    Dim adsa As New SqlDataAdapter(sa, cn)
    Dim dssa As New DataSet()
    Dim i As Integer
    Dim sum_irct, sum_iiss, sum_return, total_s, sum_talf As New Decimal()
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TextBox9.Text = 0
        Me.TextBox3.Text = 0

        Me.Button2.Enabled = False
        Me.Button3.Enabled = False

    End Sub

    Private Sub TextBoxX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX1.KeyPress
        'secu_num(e)
    End Sub

    'Private Sub TextBoxX1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxX1.Leave


    '    'Dim sql1, sql2 As String
    '    'If Me.TextBoxX1.Text.ToString <> "" Then
    '    '    'sql1 = "select  j_r.name_r as[«·ÃÂ… «·„” ·„ „‰Â« «·Œÿ«»],osta.date_i as[ «—ÌŒ «·«” ·«„], osta.qun_r as[«·ﬂ„Ì…«·Ê«—œ…], osta.sal_s as[”⁄— «·ÊÕœ…] from osta where ([no_c] =" & Me.TextBoxX1.Text & ")"

    '    '    'sql1 = "SELECT j_r.name_r as[«·ÃÂ… «·„” ·„ „‰Â« «·Œÿ«»], RcvMain.date_i as[ «—ÌŒ «·«” ·«„], RcvSub.qun_r as[«·ﬂ„Ì…«·Ê«—œ…], RcvSub.sal_s as[”⁄— «·ÊÕœ…]  from osta where ([no_c] =" & Me.TextBoxX1.Text & ")"
    '    '    sql1 = "SELECT osta.j_r.name_r AS [«·ÃÂ… «·„” ·„ „‰Â« «·Œÿ«»], osta.RcvMain.date_i AS [ «—ÌŒ «·«” ·«„], osta.RcvSub.qun_r AS [«·ﬂ„Ì…«·Ê«—œ…], osta.RcvSub.sal_s AS [”⁄— «·ÊÕœ…] FROM(osta) where [no_c]= '" + TextBoxX1.Text + "'"

    '    '    Dim da1 As New SqlDataAdapter(sql1, cn)
    '    '    Dim ds1 As New DataSet()
    '    '    ds1.Clear()
    '    '    da1.Fill(ds1, "osta")
    '    '    Me.DataGridViewX1.DataSource = ds1
    '    '    DataGridViewX1.DataMember = "osta"
    '    '    DataGridViewX1.Refresh()


    '    '    sql2 = "select j_s.name_s as[’—› „‰Â« «·Ï], IsuSub.no_s as[—ﬁ„ «–‰ «·’—›],  IsuMain.date_s as[ «—ÌŒ «·’—›], IsuSub.qun_s as[«·ﬂ„Ì… «·„’—Ê›…], IsuSub.sal_s as[”⁄— «·ÊÕœÂ] from osta where no_c ='" + TextBoxX1.Text + "'"

    '    '    Dim da2 As New SqlDataAdapter(sql2, cn)
    '    '    Dim ds2 As New DataSet()
    '    '    ds2.Clear()
    '    '    da2.Fill(ds2, "osta")
    '    '    Me.DataGridViewX2.DataSource = ds2
    '    '    DataGridViewX2.DataMember = "osta"
    '    '    DataGridViewX2.Refresh()
    '    'Else
    '    '    MsgBox(" «œŒ· —ﬁ„ «·’‰› «Ê «·”‰…")
    '    'End If



    '    ' ''**************************************
    '    Dim sql1, sql2 As String
    '    If Me.TextBoxX1.Text.ToString <> "" And Me.TextBoxX2.Text.ToString <> "" Then


    '        Dim n1 As String

    '        n1 = TextBoxX2.Text
    '        'sql1 = "select  j_r.name_r as[«·ÃÂ… «·„” ·„ „‰Â« «·Œÿ«»],osta.date_i as[ «—ÌŒ «·«” ·«„], osta.qun_r as[«·ﬂ„Ì…«·Ê«—œ…], osta.sal_s as[”⁄— «·ÊÕœ…] from osta where ([no_c] =" & Me.TextBoxX1.Text & ")"

    '        'sql1 = "SELECT j_r.name_r as[«·ÃÂ… «·„” ·„ „‰Â« «·Œÿ«»], RcvMain.date_i as[ «—ÌŒ «·«” ·«„], RcvSub.qun_r as[«·ﬂ„Ì…«·Ê«—œ…], RcvSub.sal_s as[”⁄— «·ÊÕœ…]  from osta where ([no_c] =" & Me.TextBoxX1.Text & ")"
    '        sql1 = "SELECT osta.j_r.name_r AS [«·ÃÂ… «·„” ·„ „‰Â« «·Œÿ«»], osta.RcvMain.date_i AS [ «—ÌŒ «·«” ·«„], osta.RcvSub.qun_r AS [«·ﬂ„Ì…«·Ê«—œ…], osta.RcvSub.sal_s AS [”⁄— «·ÊÕœ…] FROM(osta) where [no_c]= '" + TextBoxX1.Text + "'and Ry='" + n1 + "'"




    '        Dim da1 As New SqlDataAdapter(sql1, cn)
    '        Dim ds1 As New DataSet()
    '        ds1.Clear()
    '        da1.Fill(ds1, "osta")
    '        Me.DataGridViewX1.DataSource = ds1
    '        DataGridViewX1.DataMember = "osta"
    '        DataGridViewX1.Refresh()



    '        sql2 = "select j_s.name_s as[’—› „‰Â« «·Ï], IsuSub.no_s as[—ﬁ„ «–‰ «·’—›],  IsuMain.date_s as[ «—ÌŒ «·’—›], IsuSub.qun_s as[«·ﬂ„Ì… «·„’—Ê›…], IsuSub.sal_s as[”⁄— «·ÊÕœÂ] from osta where no_c ='" + TextBoxX1.Text + "'and Ry='" + n1 + "'"

    '        Dim da2 As New SqlDataAdapter(sql2, cn)
    '        Dim ds2 As New DataSet()
    '        ds2.Clear()
    '        da2.Fill(ds2, "osta")
    '        Me.DataGridViewX2.DataSource = ds2
    '        DataGridViewX2.DataMember = "osta"
    '        DataGridViewX2.Refresh()
    '    Else
    '        MsgBox(" «œŒ· —ﬁ„ «·’‰› «Ê «·”‰…")
    '    End If

    '    ''
    'End Sub


    Sub stouck()
        If Me.TextBoxX1.Text <> "" Then



            Dim i, w As Integer
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim sql As String = "select no_c,qun_r from RcvSub where RcvSub.no_c ='" + TextBoxX1.Text + "'"
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
                If DROW1("no_c") = (TextBoxX1.Text) Then

                    y = Val(DROW1("qun_r"))
                    sum_irct = sum_irct + y
                End If
            Next

            cn.Close()
            '===============«Ã„«·Ì «·„’—Ê›==================

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
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
                If DROW3("no_c") = (TextBoxX1.Text) Then

                    y2 = Val(DROW3("qun_s"))
                    sum_iiss = sum_iiss + y2

                End If
            Next


            cn.Close()
            '===============«Ã„«·Ì „— Ã⁄Â==================


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

                If DROW4("no_c") = (TextBoxX1.Text) Then

                    y4 = Val(DROW4("qun_t"))
                    sum_return = sum_return + y4

                End If
            Next
            cn.Close()


            total_s = 0


            '=============== «·›==================
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim sq5 As String = "select * from sub_TALEF where sub_TALEF.[no_c] ='" + TextBoxX1.Text + "'"

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

                If DROW5("no_c") = (TextBoxX1.Text) Then

                    y5 = Val(DROW5("qun_T"))
                    sum_talf = sum_talf + y5

                End If
            Next

            'If Math.Floor(DROW5!total_s) = Math.Ceiling(DROW5!total_s) Then
            '    TextBox3.Text = CInt(DROW5!total_s)


            'Else
            '    TextBox3.Text = (DROW5!total_s)


            'End If


            cn.Close()
            Me.total_s = 0


            Me.total_s = ((sum_irct + sum_return) - sum_iiss) - sum_talf

            '=======================================================
            'Me.LabelX1.Text = 0
            'Me.TextBox3.Text = total_s
            TextBox3.Text = CInt(total_s)
            '=======================================================


        End If
        cn.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If Me.TextBoxX1.Text = "" And Me.TextBoxX2.Text = "" Then

        'del_kmgrd()
        DataGridViewX2.DataMember = ""
        DataGridViewX2.DataSource = Nothing
        Me.TextBox9.Text = 0
        Me.TextBox3.Text = 0
        Dim sql1 As String
        If Me.TextBoxX1.Text.ToString <> "" And Me.TextBoxX2.Text.ToString <> "" Then


            Dim n1 As String

            n1 = TextBoxX2.Text

            'sql1 = "SELECT * FROM View_osta  where [no_c]= '" + TextBoxX1.Text + "' and (tr_type=1  or tr_type=2)and year(date_i)=" & n1 & ""



            sql1 = "SELECT n_rs AS[—ﬁ„ «–‰ «·«” ·«„], no_c AS[—ﬁ„ «·’‰›], name_r AS[«·ÃÂ… «·„” ·„ „‰Â« «·Œÿ«»], date_i AS [ «—ÌŒ «·«” ·«„], quntity AS [«·ﬂ„Ì…«·Ê«—œ…], price AS [”⁄— «·ÊÕœ…] FROM View_osta  where [no_c]= '" + TextBoxX1.Text + "' and (tr_type=1  or tr_type=2)"
            Dim da1 As New SqlDataAdapter(sql1, cn)
            Dim ds1 As New DataSet()
            ds1.Clear()
            da1.Fill(ds1, "View_osta")
            Me.DataGridViewX1.DataSource = ds1
            DataGridViewX1.DataMember = "View_osta"

            DataGridViewX1.Refresh()


            stouck()
            km_ost()


            Me.Button2.Enabled = True
            Me.Button3.Enabled = True
        Else
            MsgBox(" «œŒ· —ﬁ„ «·’‰› «Ê «·”‰…")
        End If


        'Else
        '    MsgBox(" «œŒ· «·—ﬁ„ «Ê «·”‰Â «·Õﬁ· ›«—€")
        'End If
    End Sub

    'Private Sub DataGridViewX1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellClick
    '    Dim sql2 As String

    '    'Dim a_name, n_rs As String

    '    a_sals = 0
    '    n_rs1 = 0
    '    a_qun = 0
    '    a_name = ""
    '    Dim n1 As String

    '    n1 = TextBoxX2.Text

    '    If DataGridViewX1.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub
    '    '***************************
    '    'If (DataGridViewX1.SelectedRows.Count = 0) Then
    '    '    MessageBox.Show("·« ÊÃœ ⁄‰«’—  „ «Œ «—Â«")
    '    'End If

    '    'Me.TextBox2.Text = DataGridView1.SelectedCells.Item(0).Value.ToString
    '    If cn.State = ConnectionState.Closed Then cn.Open()

    '    For i = 0 To DataGridViewX1.RowCount - 1

    '        'where(id_rec = " & DGReciaver.Rows(i).Cells.Item(1).Value")
    '        'If Me.DataGridViewX2.Rows(i).Cells.Item(0).Value = True Then
    '        n_rs1 = DataGridViewX1.CurrentRow.Cells(0).Value.ToString
    '        'a_c = DataGridViewX1.CurrentRow.Cells(1).Value.ToString
    '        a_name = DataGridViewX1.CurrentRow.Cells(2).Value.ToString
    '        a_datei = DataGridViewX1.CurrentRow.Cells(3).Value.ToString
    '        a_qun = DataGridViewX1.CurrentRow.Cells(4).Value.ToString
    '        a_sals = DataGridViewX1.CurrentRow.Cells(5).Value.ToString
    '    Next

    '    'n_rs= and 
    '    sql2 = "SELECT name_s[’—› „‰Â« «·Ï],n_s as[—ﬁ„ «–‰ «·’—›],date_s as[ «—ÌŒ «·’—›] ,qs as[«·ﬂ„Ì… «·„’—Ê›…] FROM osta where n_rs= '" & n_rs1 & "' and  no_c ='" & TextBoxX1.Text & "'and name_r='" & a_name & "' and date_i ='" & a_datei & "' and quntity=" & a_qun & " and [price] =" & a_sals & ""



    '    'sql2 = "select name_s as[’—› „‰Â« «·Ï], no_s as[—ﬁ„ «–‰ «·’—›],date_s as[ «—ÌŒ «·’—›], qun_s as[«·ﬂ„Ì… «·„’—Ê›…], sal_s as[”⁄— «·ÊÕœÂ] from osta where  no_c ='" & TextBoxX1.Text & "' and date_i ='" & a_datei & "' and qun_r =" & a_qun & "and sal_s =" & a_sals & "and year(date_s)=" & n1 & ""
    '    'sql2 = "select name_s as[’—› „‰Â« «·Ï], no_I as[—ﬁ„ «–‰ «·’—›],date_I as[ «—ÌŒ «·’—›],qI as[«·ﬂ„Ì… «·„’—Ê›…] from osta where  no_c ='" & TextBoxX1.Text & "' and date_r ='" & a_datei & "' and qR =" & a_qun & "and sal_s =" & a_sals & "and year(date_I)=" & n1 & ""


    '    Dim da2 As New SqlDataAdapter(sql2, cn)
    '    Dim ds2 As New DataSet()
    '    ds2.Clear()
    '    da2.Fill(ds2, "osta")
    '    Me.DataGridViewX2.DataSource = ds2
    '    DataGridViewX2.DataMember = "osta"
    '    DataGridViewX2.Refresh()

    '    Dim coun_test As Integer = 0

    '    For Me.i = 0 To DataGridViewX2.RowCount - 1
    '        coun_test = coun_test + Me.DataGridViewX2.Rows(i).Cells.Item(3).Value
    '    Next
    '    Me.TextBox2.Text = coun_test
    'End Sub

 

   
    Private Sub DataGridViewX1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellClick

        Dim sql2 As String
        a_sals = 0
        n_rs1 = 0
        a_qun = 0
        a_name = ""
        Dim n1 As String
        DataGridViewX2.DataMember = ""
        DataGridViewX2.DataSource = Nothing
        n1 = TextBoxX2.Text

        If DataGridViewX1.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub
        '***************************
        'If (DataGridViewX1.SelectedRows.Count = 0) Then
        '    MessageBox.Show("·« ÊÃœ ⁄‰«’—  „ «Œ «—Â«")
        'End If

        'Me.TextBox2.Text = DataGridView1.SelectedCells.Item(0).Value.ToString
        If cn.State = ConnectionState.Closed Then cn.Open()

        For i = 0 To DataGridViewX1.RowCount - 1

            'where(id_rec = " & DGReciaver.Rows(i).Cells.Item(1).Value")
            'If Me.DataGridViewX2.Rows(i).Cells.Item(0).Value = True Then
            n_rs1 = DataGridViewX1.CurrentRow.Cells(0).Value.ToString
            ''a_c = DataGridViewX1.CurrentRow.Cells(1).Value.ToString
            a_name = DataGridViewX1.CurrentRow.Cells(2).Value.ToString
            a_datei = DataGridViewX1.CurrentRow.Cells(3).Value.ToString
            a_qun = DataGridViewX1.CurrentRow.Cells(4).Value.ToString
            a_sals = DataGridViewX1.CurrentRow.Cells(5).Value.ToString
        Next

        ''n_rs= and 
        sql2 = "SELECT no_c AS[—ﬁ„ «·’‰›],no_I as [—ﬁ„ «–‰ «·’—›],qI AS [«·ﬂ„Ì…«·„’—Ê›…],date_I AS [ «—ÌŒ «·’—›],name_s [’—› „‰Â« «·Ï] FROM osta where no_R= '" & n_rs1 & "' and  no_c ='" & TextBoxX1.Text & "' and sal_s =" & a_sals & " and qR =" & a_qun & ""

        'sql2 = "SELECT no_c AS[—ﬁ„ «·’‰›],n_rsi as [—ﬁ„ «–‰ «·’—›],quntityi AS [«·ﬂ„Ì…«·„’—Ê›…], date_s AS [ «—ÌŒ «·’—›],name_s [’—› „‰Â« «·Ï] , pricei AS [”⁄— «·ÊÕœ…]FROM ostaprint where no_c ='" + TextBoxX1.Text + "' and price =" & a_sals & " and Y_S='" + n1 + "'"
        'sql2 = "SELECT no_c AS[—ﬁ„ «·’‰›],no_I as [—ﬁ„ «–‰ «·’—›],qI AS [«·ﬂ„Ì…«·„’—Ê›…], date_I AS [ «—ÌŒ «·’—›],name_s [’—› „‰Â« «·Ï] ,sal_s AS [”⁄— «·ÊÕœ…]FROM osta where no_c ='" + TextBoxX1.Text + "' and sal_s =" & a_sals & " and Ry='" + n1 + "' and date_i='" & a_datei.ToString("yyyy/MM/dd") & "'"
        'sql2 = "SELECT no_c AS[—ﬁ„ «·’‰›],n_rs as [—ﬁ„ «–‰ «·’—›],qun_s AS [«·ﬂ„Ì…«·„’—Ê›…], date_s AS [ «—ÌŒ «·’—›],name_s [’—› „‰Â« «·Ï] , price AS [”⁄— «·ÊÕœ…]FROM V_TranRIosta where no_c ='" + TextBoxX1.Text + "' and price =" & a_sals & " and Y_S='" + n1 + "' and date_i='" & a_datei.ToString("yyyy/MM/dd") & "'"
        Dim da2 As New SqlDataAdapter(sql2, cn)
        Dim ds2 As New DataSet()
        ds2.Clear()
        da2.Fill(ds2, "osta")
        Me.DataGridViewX2.DataSource = ds2
        DataGridViewX2.DataMember = "osta"
        DataGridViewX2.Refresh()

        Dim coun_test As Integer = 0
        For Me.i = 0 To DataGridViewX2.RowCount - 1
            coun_test = coun_test + Me.DataGridViewX2.Rows(i).Cells.Item(2).Value
        Next
        Me.TextBox2.Text = coun_test

        'DataGridViewX2.DataMember = ""
        'DataGridViewX2.DataSource = Nothing


    End Sub

 
    Private Sub DataGridViewX1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick
      
        Dim sql2 As String
        a_sals = 0
        n_rs1 = 0
        a_qun = 0
        a_name = ""
        Dim n1 As String
        DataGridViewX2.DataMember = ""
        DataGridViewX2.DataSource = Nothing
        n1 = TextBoxX2.Text

        If DataGridViewX1.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub
        '***************************
        'If (DataGridViewX1.SelectedRows.Count = 0) Then
        '    MessageBox.Show("·« ÊÃœ ⁄‰«’—  „ «Œ «—Â«")
        'End If

        'Me.TextBox2.Text = DataGridView1.SelectedCells.Item(0).Value.ToString
        If cn.State = ConnectionState.Closed Then cn.Open()

        For i = 0 To DataGridViewX1.RowCount - 1

            'where(id_rec = " & DGReciaver.Rows(i).Cells.Item(1).Value")
            'If Me.DataGridViewX2.Rows(i).Cells.Item(0).Value = True Then
            n_rs1 = DataGridViewX1.CurrentRow.Cells(0).Value.ToString
            ''a_c = DataGridViewX1.CurrentRow.Cells(1).Value.ToString
            a_name = DataGridViewX1.CurrentRow.Cells(2).Value.ToString
            a_datei = DataGridViewX1.CurrentRow.Cells(3).Value.ToString
            a_qun = DataGridViewX1.CurrentRow.Cells(4).Value.ToString
            a_sals = DataGridViewX1.CurrentRow.Cells(5).Value.ToString
        Next
        sql2 = "SELECT no_c AS[—ﬁ„ «·’‰›],no_I as [—ﬁ„ «–‰ «·’—›],qI AS [«·ﬂ„Ì…«·„’—Ê›…],date_I AS [ «—ÌŒ «·’—›],name_s [’—› „‰Â« «·Ï] FROM osta where no_R= '" & n_rs1 & "' and  no_c ='" & TextBoxX1.Text & "' and sal_s =" & a_sals & " and qR =" & a_qun & ""
        ''n_rs= and 
        'sql2 = "SELECT no_c AS[—ﬁ„ «·’‰›],no_I as [—ﬁ„ «–‰ «·’—›],qI AS [«·ﬂ„Ì…«·„’—Ê›…],date_I AS [ «—ÌŒ «·’—›],name_s [’—› „‰Â« «·Ï] FROM osta where no_R= '" & n_rs1 & "' and  no_c ='" & TextBoxX1.Text & "' and date_r ='" & a_datei & "' and sal_s =" & a_sals & " and qR =" & a_qun & ""

        'sql2 = "SELECT no_c AS[—ﬁ„ «·’‰›],n_rsi as [—ﬁ„ «–‰ «·’—›],quntityi AS [«·ﬂ„Ì…«·„’—Ê›…], date_s AS [ «—ÌŒ «·’—›],name_s [’—› „‰Â« «·Ï] , pricei AS [”⁄— «·ÊÕœ…]FROM ostaprint where no_c ='" + TextBoxX1.Text + "' and price =" & a_sals & " and Y_S='" + n1 + "'"
        'sql2 = "SELECT no_c AS[—ﬁ„ «·’‰›],n_rs as [—ﬁ„ «–‰ «·’—›],qun_s AS [«·ﬂ„Ì…«·„’—Ê›…], date_s AS [ «—ÌŒ «·’—›],name_s [’—› „‰Â« «·Ï] , price AS [”⁄— «·ÊÕœ…]FROM V_TranRIosta where no_i= '" & n_rs1 & "' and no_c ='" + TextBoxX1.Text + "' and price =" & a_sals & " and Y_S='" + n1 + "' and date_i='" & a_datei.ToString("yyyy/MM/dd") & "'"
        Dim da2 As New SqlDataAdapter(sql2, cn)
        Dim ds2 As New DataSet()
        ds2.Clear()
        da2.Fill(ds2, "osta")
        Me.DataGridViewX2.DataSource = ds2
        DataGridViewX2.DataMember = "osta"
        DataGridViewX2.Refresh()

        Dim coun_test As Integer = 0
        For Me.i = 0 To DataGridViewX2.RowCount - 1
            coun_test = coun_test + Me.DataGridViewX2.Rows(i).Cells.Item(2).Value
        Next
        Me.TextBox2.Text = coun_test

        'DataGridViewX2.DataMember = ""
        'DataGridViewX2.DataSource = Nothing


    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim n1 As String

        n1 = TextBoxX2.Text
        If TextBoxX1.Text <> "" Then
        


            Dim adp As New SqlDataAdapter("select [no_c],[name_snc],[sal_s],cast([qun_r] as nvarchar(50)) as qun_r,[name_r],[date_i],[no_i],[n_rs] " & _
",[quntity],[price],[date_s],[name_s],cast([qun_s] as nvarchar(50)) as qun_s,[Y_S],cast([q_div] as nvarchar(50)) as q_div,[count1],[gimadiv],[gimar],[gimars] " & _
" from [V_TranRIosta] WHERE  no_i= N'" & n_rs1 & "' and no_c =N'" + TextBoxX1.Text + "'and name_r=N'" & a_name & "' and price =" & a_sals & " and qun_r=" & a_qun & " and Y_S=N'" + n1 + "' and date_i='" & a_datei.ToString("yyyy/MM/dd") & "'", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_r")) = "int" Then
                    dt.Rows(i).Item("qun_r") = myNo
                Else
                    dt.Rows(i).Item("qun_r") = FormatNumber(CDec(dt.Rows(i).Item(3)), 3)
                End If

                If checkNum(dt.Rows(i).Item("qun_s")) = "int" Then
                    dt.Rows(i).Item("qun_s") = myNo
                Else
                    dt.Rows(i).Item("qun_s") = FormatNumber(CDec(dt.Rows(i).Item(12)), 3)
                End If


                If checkNum(dt.Rows(i).Item("q_div")) = "int" Then
                    dt.Rows(i).Item("q_div") = myNo
                Else
                    dt.Rows(i).Item("q_div") = FormatNumber(CDec(dt.Rows(i).Item(14)), 3)
                End If

            Next

            Dim frm As New Form7
            Dim rpt1 As New CRepdtaso
            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1


            '===============================================
            Dim Text25 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text25")
            Text25.Text = branch
            'Dim Text59 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text59")
            'Text59.Text = TextBox1.Text

            Dim Text17 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text17")
            Text17.Text = Label9.Text + " " + "—’Ìœ Ã—œ ”‰Â"



            Dim Text8 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text8")
            Text8.Text = TextBox9.Text

            'If TextBox9.Text = 0 Then
            '    Dim Text9 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text9")
            '    Text9.Text = 0
            'Else
            Dim Text49 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text49")
            Text49.Text = TextBox3.Text
            'End If

            Dim Text41 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text41")
            Text41.Text = ww
            '===========================
            Dim Text36 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section5.ReportObjects("Text36")
            Dim Text59 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text59")

            Text59.Text = TextBox1.Text

            If branch = "«·«œ«—… «·⁄«„…" Then

                Text36.Text = "—∆Ì” ﬁ”„ «·„Œ«“‰ Ê«· ﬂ«·Ì›"
            Else
                Text36.Text = "—∆Ì” ÊÕœ… «·„Œ«“‰ Ê«· ﬂ«·Ì›"

            End If
            frm.Text = "ÿ»«⁄… "
            frm.ShowDialog()
            'ds.Clear()
            'cn.Close()

        Else
            Exit Sub
        End If
        Me.Button2.Enabled = False
    End Sub

    'Function checkNum(ByVal mytext As String) As String
    '    Try

    '        Dim NumAfterDot As String = ""

    '        For i As Integer = 0 To mytext.Length - 1

    '            If mytext(i) = "." Then

    '                For k As Integer = i + 1 To mytext.Length - 1

    '                    NumAfterDot = NumAfterDot & mytext(k)

    '                Next

    '            End If

    '        Next

    '        If NumAfterDot = "" Then
    '            Return "int"
    '        Else
    '            If CInt(NumAfterDot) = 0 Then
    '                Return "int"
    '            Else
    '                Return "decimal"
    '            End If
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
 
        Dim n1 As String

        n1 = TextBoxX2.Text
        If TextBoxX1.Text <> "" Then
  
            Dim adp As New SqlDataAdapter("select [no_c],[name_snc],[sal_s],cast([qun_r] as nvarchar(50)) as qun_r,[name_r],[date_i],[no_i],[n_rs] " & _
",[quntity],[price],[date_s],[name_s],cast([qun_s] as nvarchar(50)) as qun_s,[Y_S],cast([q_div] as nvarchar(50)) as q_div,[count1],[gimadiv] " & _
" from [V_TranRIosta] WHERE  no_c ='" & TextBoxX1.Text & "'and Y_S='" + n1 + "'", cn)
            Dim dt As New DataTable
            adp.Fill(dt)
           
            For i As Integer = 0 To dt.Rows.Count - 1
                If checkNum(dt.Rows(i).Item("qun_r")) = "int" Then
                    dt.Rows(i).Item("qun_r") = myNo
                Else
                    dt.Rows(i).Item("qun_r") = FormatNumber(CDec(dt.Rows(i).Item(3)), 3)
                End If

                If checkNum(dt.Rows(i).Item("qun_s")) = "int" Then
                    dt.Rows(i).Item("qun_s") = myNo
                Else
                    dt.Rows(i).Item("qun_s") = FormatNumber(CDec(dt.Rows(i).Item(12)), 3)
                End If


                If checkNum(dt.Rows(i).Item("q_div")) = "int" Then
                    dt.Rows(i).Item("q_div") = myNo
                Else
                    dt.Rows(i).Item("q_div") = FormatNumber(CDec(dt.Rows(i).Item(14)), 3)
                End If

            Next

            Dim frm As New Form7
            Dim rpt1 As New CrystalReost
            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

            rpt1.SetDataSource(dt)
            frm.CrystalReportViewer1.ReportSource = rpt1

            Dim Text11 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text11")
            Text11.Text = branch
            'Dim Text4 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text4")
            'Text4.Text = TextBox1.Text

            'Dim Text5 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text5")
            'Text5.Text = ww

            Dim Text29 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text29")
            Text29.Text = TextBox9.Text

            Dim Text35 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text35")
            Text35.Text = Label9.Text + " " + "—’Ìœ Ã—œ ”‰Â"

            Dim Text14 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text14")
            Text14.Text = TextBox3.Text

            '==========================
            Dim Text5 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text5")
            Text5.Text = ww
            '===========================
            Dim Text36 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section5.ReportObjects("Text36")
            Dim Text4 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section1.ReportObjects("Text4")

            Text4.Text = TextBox1.Text

            If branch = "«·«œ«—… «·⁄«„…" Then

                Text36.Text = "—∆Ì” ﬁ”„ «·„Œ«“‰ Ê«· ﬂ«·Ì›"
            Else
                Text36.Text = "—∆Ì” ÊÕœ… «·„Œ«“‰ Ê«· ﬂ«·Ì›"

            End If


            frm.Text = "ÿ»«⁄… "
            frm.ShowDialog()

        Else
            Exit Sub
        End If

        Me.Button3.Enabled = False
    End Sub
    Sub del_kmgrd()


        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        Dim saa As String = "delete from sara where no_c=@x1"
        Dim cm11 As New SqlCommand(saa, cn)
        cm11.Parameters.Add(New SqlParameter("@x1", (TextBoxX1.Text)))

        cm11.ExecuteNonQuery()
        dssa.Clear()
        adsa.Fill(dssa, "sara")
        cn.Close()
        dssa.Clear()


    End Sub
    Sub km_ost()

        Dim ds As New DataSet()
        ds.Clear()

        ''del_kmgrd()
        'TextBox9.Text = 0
        'TextBox3.Text = 0
        Label9.Text = 0


        'Label6.Text = TextBoxX2.Text - 1
        Label9.Text = TextBoxX2.Text - 1
        Dim s As String = "SELECT no_c, MAX(YEAR(date_i)) AS maxdate, date_i, qun_tot, sal_s FROM acthion_tran GROUP BY no_c, date_i, qun_tot, sal_s HAVING (qun_tot <> 0) AND (no_c = N'" + TextBoxX1.Text + "')"

        'Dim s As String = "SELECT no_c AS [—ﬁ„ «·’‰›], MAX(YEAR(date_i)) AS [«·”‰Â], date_i, qun_tot AS [ﬂ„Ì… «·„ »ﬁÌÂ], sal_s AS [«·”⁄—] FROM acthion_tran GROUP BY no_c, date_i, qun_tot, sal_s HAVING (qun_tot <> 0) AND (no_c = N'" + TextBox1.Text + "') AND (no_c = N'" + TextBox1.Text + "')"
        'Dim s As String = "SELECT n_rs,date_s,no_c,quntity,price,tr_type,name_s,q_div,count1,Y_S FROM sub_it where no_c ='" + TextBoxX1.Text + "' and Y_S='" + Label6.Text + "'"
        'Dim s As String = " SELECT * from acthion_tran WHERE no_c ='" + TextBoxX1.Text + "' and year([date_i])< '" + TextBoxX2.Text + "' and [qun_tot]>0"

        Dim ad As New SqlDataAdapter(s, cn)
        ds.Clear()
        ad.Fill(ds, "acthion_tran")
        Me.DataGridViewX5.DataSource = ds
        Me.DataGridViewX5.DataMember = "acthion_tran"
        Me.DataGridViewX5.Refresh()
        cn.Close()

        '==========================================
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sum_k As New Decimal()
        Dim sql As String = " SELECT * from acthion_tran WHERE no_c ='" + TextBoxX1.Text + "' and year([date_i])<'" + Label9.Text + "' and [qun_tot]>0"
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
            If DROW1("no_c") = (TextBoxX1.Text) Then

                y = Val(DROW1("qun_tot"))
                sum_k = sum_k + y
            End If
        Next
        TextBox9.Text = sum_k
        '==========================================
        'For i As Integer = 0 To DataGridViewX5.RowCount - 1
        '    Dim sql2 As String = "insert into sara(info_is,date_inf,no_c,qun_t,price,tr_no,j_h,qmt,cont_c,Y_RST)values(@info_is,@date_inf,@no_c,@qun_t,@price,@tr_no,@j_h,@qmt,@cont_c,@Y_RST)"
        '    Dim cm2 As New SqlCommand(sql2, cn)
        '    cm2.Parameters.AddWithValue("@info_is", DataGridViewX5.Rows(i).Cells(0).Value).DbType = DbType.String
        '    cm2.Parameters.AddWithValue("@date_inf", DataGridViewX5.Rows(i).Cells(1).Value).DbType = DbType.Date
        '    cm2.Parameters.AddWithValue("@no_c", DataGridViewX5.Rows(i).Cells(2).Value).DbType = DbType.String
        '    cm2.Parameters.AddWithValue("@qun_t", DataGridViewX5.Rows(i).Cells(3).Value).DbType = DbType.Decimal
        '    cm2.Parameters.AddWithValue("@price", DataGridViewX5.Rows(i).Cells(4).Value).DbType = DbType.Decimal
        '    cm2.Parameters.AddWithValue("@tr_no", DataGridViewX5.Rows(i).Cells(5).Value).DbType = DbType.Int32
        '    cm2.Parameters.AddWithValue("@j_h", DataGridViewX5.Rows(i).Cells(6).Value).DbType = DbType.String
        '    cm2.Parameters.AddWithValue("@qmt", DataGridViewX5.Rows(i).Cells(7).Value).DbType = DbType.Decimal
        '    cm2.Parameters.AddWithValue("@cont_c", DataGridViewX5.Rows(i).Cells(8).Value).DbType = DbType.Int32
        '    cm2.Parameters.AddWithValue("@Y_RST", DataGridViewX5.Rows(i).Cells(9).Value).DbType = DbType.Int32
        '    cn.Open()
        '    cm2.ExecuteNonQuery()
        '    cn.Close()
        'Next

        'DataGridViewX5.DataSource = Nothing
        'If cn.State = ConnectionState.Closed Then
        '    cn.Open()
        'End If
        'Dim sv As String = "select * from sara where sara.info_is=(select MAX(info_is) from sara)"

        'Dim adv As New SqlDataAdapter(sv, cn)
        'Dim dsv As New DataSet()
        'Dim TD As DataTable
        'adv.Fill(dsv, sv)
        'TD = dsv.Tables(sv)
        'Me.DataGridViewX5.DataSource = TD
        'For i As Integer = 0 To DataGridViewX5.Rows.Count - 1
        '    Me.TextBox9.Text = (DataGridViewX5.Rows(i).Cells(7).Value).ToString
        '    Me.TextBox3.Text = (DataGridViewX5.Rows(i).Cells(4).Value).ToString
        'Next


        ''del_kmgrd()

        'If Me.TextBox9.Text = 0 Then
        '    Me.TextBox3.Text = 0
        '    'rep_km_ost()

        'End If

        'del_kmgrd()
        ''If TextBoxX2.Text = 2017 Then
        ''    MsgBox("·«ÌÊÃœ ”Ã·«  «” «– «·„Œ“‰ ›Ï Â–Â «·”‰Â", MsgBoxStyle.MsgBoxHelp, " ‰»Ì…")

        ''End If




    End Sub
    Sub rep_km_ost()
        '»ÕÀ ·„« ﬂ„ÌÂ «·Ã—œ =0 ·”‰Â ”«»ﬁÂ '
        Dim ds As New DataSet()
        ds.Clear()

        del_kmgrd()
        TextBox9.Text = 0
        TextBox3.Text = 0
        Label6.Text = TextBoxX2.Text - 2
        Dim s As String = "SELECT n_rs,date_s,no_c,quntity,price,tr_type,name_s,q_div,count1,Y_S FROM sub_it where no_c ='" + TextBoxX1.Text + "' and Y_S='" + Label6.Text + "'"
        Dim ad As New SqlDataAdapter(s, cn)
        ds.Clear()
        ad.Fill(ds, "sub_it")
        Me.DataGridViewX5.DataSource = ds
        Me.DataGridViewX5.DataMember = "sub_it"
        Me.DataGridViewX5.Refresh()
        cn.Close()

        '==========================================

        '==========================================
        For i As Integer = 0 To DataGridViewX5.RowCount - 1
            Dim sql2 As String = "insert into sara(info_is,date_inf,no_c,qun_t,price,tr_no,j_h,qmt,cont_c,Y_RST)values(@info_is,@date_inf,@no_c,@qun_t,@price,@tr_no,@j_h,@qmt,@cont_c,@Y_RST)"
            Dim cm2 As New SqlCommand(sql2, cn)
            cm2.Parameters.AddWithValue("@info_is", DataGridViewX5.Rows(i).Cells(0).Value).DbType = DbType.String
            cm2.Parameters.AddWithValue("@date_inf", DataGridViewX5.Rows(i).Cells(1).Value).DbType = DbType.Date
            cm2.Parameters.AddWithValue("@no_c", DataGridViewX5.Rows(i).Cells(2).Value).DbType = DbType.String
            cm2.Parameters.AddWithValue("@qun_t", DataGridViewX5.Rows(i).Cells(3).Value).DbType = DbType.Decimal
            cm2.Parameters.AddWithValue("@price", DataGridViewX5.Rows(i).Cells(4).Value).DbType = DbType.Decimal
            cm2.Parameters.AddWithValue("@tr_no", DataGridViewX5.Rows(i).Cells(5).Value).DbType = DbType.Int32
            cm2.Parameters.AddWithValue("@j_h", DataGridViewX5.Rows(i).Cells(6).Value).DbType = DbType.String
            cm2.Parameters.AddWithValue("@qmt", DataGridViewX5.Rows(i).Cells(7).Value).DbType = DbType.Decimal
            cm2.Parameters.AddWithValue("@cont_c", DataGridViewX5.Rows(i).Cells(8).Value).DbType = DbType.Int32
            cm2.Parameters.AddWithValue("@Y_RST", DataGridViewX5.Rows(i).Cells(9).Value).DbType = DbType.Int32
            cn.Open()
            cm2.ExecuteNonQuery()
            cn.Close()
        Next

        DataGridViewX5.DataSource = Nothing
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sv As String = "select * from sara where sara.info_is=(select MAX(info_is) from sara)"

        Dim adv As New SqlDataAdapter(sv, cn)
        Dim dsv As New DataSet()
        Dim TD As DataTable
        adv.Fill(dsv, sv)
        TD = dsv.Tables(sv)
        Me.DataGridViewX5.DataSource = TD
        For i As Integer = 0 To DataGridViewX5.Rows.Count - 1
            Me.TextBox9.Text = (DataGridViewX5.Rows(i).Cells(7).Value).ToString
            Me.TextBox3.Text = (DataGridViewX5.Rows(i).Cells(4).Value).ToString
        Next
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGridViewX2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX2.CellContentClick

    End Sub
End Class