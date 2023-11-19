Imports System.Data.SqlClient
Imports mdobler.XPCommonControls


Class Form14
    'Dim s1 As String = "select * from estmonth"
    'Dim ad1 As New SqlDataAdapter(s1, cn)
    'Dim ds1 As New DataSet
    'Dim s2 As String = "select * from msrfmonth"
    'Dim da2 As New SqlDataAdapter(s2, cn)
    'Dim ds2 As New DataSet
    Dim n1, sh1, sn1 As String
    Dim i As Integer
    Private Sub Form14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds1 As DataSet
        ds1 = New DataSet
        ds1.Clear()
        Dim s1 As String = "select * from estmonth"
        Dim ad1 As New SqlDataAdapter(s1, cn)
        ad1.Fill(ds1, "estmonth")
        Me.DataGridView1.DataSource = ds1
        Me.DataGridView1.DataMember = "estmonth"
        DataGridView1.Refresh()
        cn.Close()

        'Dim s2 As String = "select * from msrfmonth"
        'Dim da2 As New SqlDataAdapter(s2, cn)
        'da2.Fill(ds2, "msrfmonth")
        'Me.DataGridView2.DataSource = ds2
        'Me.DataGridView2.DataMember = "msrfmonth"
        'DataGridView2.Refresh()
        'cn.Close()

        'Dim ds3 As DataSet
        'ds3 = New DataSet
        'ds3.Clear()
        'Dim s3 As String = "select * from RUtmonth"
        'Dim da3 As New SqlDataAdapter(s3, cn)
        'da3.Fill(ds3, "RUtmonth")
        'Me.DataGridView3.DataSource = ds3
        'Me.DataGridView3.DataMember = "RUtmonth"
        'DataGridView3.Refresh()
        'cn.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            Dim ds1 As DataSet
            ds1 = New DataSet
            ds1.Clear()
            Dim s1 As String = "select * from estmonth where RSDATEy ='" + Me.TextBox12.Text + "'"
            Dim ad1 As New SqlDataAdapter(s1, cn)
            ad1.Fill(ds1, "estmonth")
            Me.DataGridView1.DataSource = ds1
            Me.DataGridView1.DataMember = "estmonth"
            DataGridView1.Refresh()
            cn.Close()

            Dim ds2 As DataSet
            ds2 = New DataSet
            ds2.Clear()
            '--------------------------------------------

            Dim s2 As String = "select * from msrfmonth where ISDATEy ='" + Me.TextBox12.Text + "'"
            Dim da2 As New SqlDataAdapter(s2, cn)
            da2.Fill(ds2, "msrfmonth")
            Me.DataGridView2.DataSource = ds2
            Me.DataGridView2.DataMember = "msrfmonth"
            DataGridView2.Refresh()
            cn.Close()
            '---------------------------
            Dim ds3 As DataSet
            ds3 = New DataSet
            ds3.Clear()
            Dim s3 As String = "select * from RUtmonth where REDATEy ='" + Me.TextBox12.Text + "'"
            Dim da3 As New SqlDataAdapter(s3, cn)
            da3.Fill(ds3, "RUtmonth")
            Me.DataGridView3.DataSource = ds3
            Me.DataGridView3.DataMember = "RUtmonth"
            DataGridView3.Refresh()
            cn.Close()


        End If
        If RadioButton6.Checked = True Then

            Me.TextBox2.Text = 0

            sh1 = Val(Me.ComboBox3.SelectedItem)
            sn1 = TextBox1.Text

            If sh1 = 12 Or sh1 = 11 Or sh1 = 10 Then
                n1 = sn1 + ("/") + sh1
            End If


            If sh1 = 1 Or sh1 = 2 Or sh1 = 3 Or sh1 = 4 Or sh1 = 5 Or sh1 = 6 Or sh1 = 7 Or sh1 = 8 Or sh1 = 9 Then
                n1 = sn1 + ("/0") + sh1
            End If


            Me.TextBox2.Text = n1


            Dim ds1 As DataSet
            ds1 = New DataSet
            ds1.Clear()
            Dim s1 As String = "select * from estmonth where RSDATE ='" + n1 + "'"
            Dim ad1 As New SqlDataAdapter(s1, cn)
            ad1.Fill(ds1, "estmonth")
            Me.DataGridView1.DataSource = ds1
            Me.DataGridView1.DataMember = "estmonth"
            DataGridView1.Refresh()
            cn.Close()


            Dim ds2 As DataSet
            ds2 = New DataSet
            ds2.Clear()
            Dim s2 As String = "select * from msrfmonth where ISDATE ='" + n1 + "'"
            Dim da2 As New SqlDataAdapter(s2, cn)
            da2.Fill(ds2, "msrfmonth")
            Me.DataGridView2.DataSource = ds2
            Me.DataGridView2.DataMember = "msrfmonth"
            DataGridView2.Refresh()
            cn.Close()
            '---------------------------
            Dim ds3 As DataSet
            ds3 = New DataSet
            ds3.Clear()
            Dim s3 As String = "select * from RUtmonth where REDATE ='" + n1 + "'"
            Dim da3 As New SqlDataAdapter(s3, cn)
            da3.Fill(ds3, "RUtmonth")
            Me.DataGridView3.DataSource = ds3
            Me.DataGridView3.DataMember = "RUtmonth"
            DataGridView3.Refresh()
            cn.Close()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub
        '***************************
        If (DataGridView1.SelectedRows.Count = 0) Then
            MessageBox.Show("لاتوجد عناصر تم اختارها")
        End If

        'Me.TextBox2.Text = DataGridView1.SelectedCells.Item(0).Value.ToString
        If cn.State = ConnectionState.Closed Then cn.Open()

        For i = 0 To DataGridView1.RowCount - 1

            'where(id_rec = " & DGReciaver.Rows(i).Cells.Item(1).Value")
            'If Me.DataGridViewX2.Rows(i).Cells.Item(0).Value = True Then
            TextBox2.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString

        Next


        If RadioButton1.Checked = True Then
            Dim ds2 As DataSet
            ds2 = New DataSet
            ds2.Clear()
            '--------------------------------------------

            Dim s2 As String = "select * from msrfmonth  where no_c ='" + TextBox2.Text + "' and ISDATEy='" + TextBox12.Text + "'"
            Dim da2 As New SqlDataAdapter(s2, cn)
            da2.Fill(ds2, "msrfmonth")
            Me.DataGridView2.DataSource = ds2
            Me.DataGridView2.DataMember = "msrfmonth"
            DataGridView2.Refresh()
            cn.Close()
            '---------------------------
            Dim ds3 As DataSet
            ds3 = New DataSet
            ds3.Clear()
            Dim s3 As String = "select * from RUtmonth where no_c ='" + TextBox2.Text + "' and REDATEy ='" + Me.TextBox12.Text + "'"
            Dim da3 As New SqlDataAdapter(s3, cn)
            da3.Fill(ds3, "RUtmonth")
            Me.DataGridView3.DataSource = ds3
            Me.DataGridView3.DataMember = "RUtmonth"
            DataGridView3.Refresh()
            cn.Close()
        End If
        If RadioButton6.Checked = True Then

            sh1 = Val(Me.ComboBox3.SelectedItem)
            sn1 = TextBox1.Text

            If sh1 = 12 Or sh1 = 11 Or sh1 = 10 Then
                n1 = sn1 + ("/") + sh1
            End If


            If sh1 = 1 Or sh1 = 2 Or sh1 = 3 Or sh1 = 4 Or sh1 = 5 Or sh1 = 6 Or sh1 = 7 Or sh1 = 8 Or sh1 = 9 Then
                n1 = sn1 + ("/0") + sh1
            End If


            Me.TextBox2.Text = n1
            Dim ds2 As DataSet
            ds2 = New DataSet
            ds2.Clear()
            '--------------------------------------------

            Dim s2 As String = "select * from msrfmonth where no_c ='" + TextBox2.Text + "' and ISDATE ='" + n1 + "'"
            Dim da2 As New SqlDataAdapter(s2, cn)
            da2.Fill(ds2, "msrfmonth")
            Me.DataGridView2.DataSource = ds2
            Me.DataGridView2.DataMember = "msrfmonth"
            DataGridView2.Refresh()
            cn.Close()
            '---------------------------
            Dim ds3 As DataSet
            ds3 = New DataSet
            ds3.Clear()
            Dim s3 As String = "select * from RUtmonth where no_c ='" + TextBox2.Text + "' and REDATE ='" + n1 + "'"
            Dim da3 As New SqlDataAdapter(s3, cn)
            da3.Fill(ds3, "RUtmonth")
            Me.DataGridView3.DataSource = ds3
            Me.DataGridView3.DataMember = "RUtmonth"
            DataGridView3.Refresh()
            cn.Close()
        End If
    End Sub

    Private Sub DataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click
        If DataGridView1.CurrentRow.Cells(0).Value Is DBNull.Value Then Exit Sub

        If cn.State = ConnectionState.Closed Then cn.Open()

        For i = 0 To DataGridView1.RowCount - 1


            'If Me.DataGridViewX2.Rows(i).Cells.Item(0).Value = True Then
            TextBox2.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString

        Next


        If RadioButton1.Checked = True Then
            Dim ds2 As DataSet
            ds2 = New DataSet
            ds2.Clear()
            '--------------------------------------------

            Dim s2 As String = "select * from msrfmonth  where no_c ='" + TextBox2.Text + "' and ISDATEy='" + TextBox12.Text + "'"
            Dim da2 As New SqlDataAdapter(s2, cn)
            da2.Fill(ds2, "msrfmonth")
            Me.DataGridView2.DataSource = ds2
            Me.DataGridView2.DataMember = "msrfmonth"
            DataGridView2.Refresh()
            cn.Close()
            '---------------------------
            Dim ds3 As DataSet
            ds3 = New DataSet
            ds3.Clear()
            Dim s3 As String = "select * from RUtmonth where no_c ='" + TextBox2.Text + "' and REDATEy ='" + Me.TextBox12.Text + "'"
            Dim da3 As New SqlDataAdapter(s3, cn)
            da3.Fill(ds3, "RUtmonth")
            Me.DataGridView3.DataSource = ds3
            Me.DataGridView3.DataMember = "RUtmonth"
            DataGridView3.Refresh()
            cn.Close()
        End If
        If RadioButton6.Checked = True Then

            sh1 = Val(Me.ComboBox3.SelectedItem)
            sn1 = TextBox1.Text

            If sh1 = 12 Or sh1 = 11 Or sh1 = 10 Then
                n1 = sn1 + ("/") + sh1
            End If


            If sh1 = 1 Or sh1 = 2 Or sh1 = 3 Or sh1 = 4 Or sh1 = 5 Or sh1 = 6 Or sh1 = 7 Or sh1 = 8 Or sh1 = 9 Then
                n1 = sn1 + ("/0") + sh1
            End If


            Me.TextBox2.Text = n1
            Dim ds2 As DataSet
            ds2 = New DataSet
            ds2.Clear()
            '--------------------------------------------

            Dim s2 As String = "select * from msrfmonth where no_c ='" + TextBox2.Text + "' and ISDATE ='" + n1 + "'"
            Dim da2 As New SqlDataAdapter(s2, cn)
            da2.Fill(ds2, "msrfmonth")
            Me.DataGridView2.DataSource = ds2
            Me.DataGridView2.DataMember = "msrfmonth"
            DataGridView2.Refresh()
            cn.Close()
            '---------------------------
            Dim ds3 As DataSet
            ds3 = New DataSet
            ds3.Clear()
            Dim s3 As String = "select * from RUtmonth where no_c ='" + TextBox2.Text + "' and REDATE ='" + n1 + "'"
            Dim da3 As New SqlDataAdapter(s3, cn)
            da3.Fill(ds3, "RUtmonth")
            Me.DataGridView3.DataSource = ds3
            Me.DataGridView3.DataMember = "RUtmonth"
            DataGridView3.Refresh()
            cn.Close()
        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub LabelX28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX28.Click

    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

    End Sub
End Class