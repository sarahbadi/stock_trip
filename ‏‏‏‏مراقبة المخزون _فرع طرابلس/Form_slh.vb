Imports System.Data.SqlClient

Public Class Form_slh
    Dim date_1, date_2 As Date

    Private Sub Form_slh_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        date_1 = Date.Now
        date_2 = "1990/01/01"
        DataGridViewX2.DataMember = ""
        DataGridViewX2.DataSource = Nothing
        Dim ds As New DataSet()
        Dim ds1 As New DataSet()
        Dim s As String = " SELECT no_c AS [رقم الصنف],sal_s AS [سعر الوحدة],date_end AS [تاريخ انتهاء الصلاحية],mdh AS [المدة],mdh_a as [نوع المدة],date_mdh as [تاريخ التنبيه],no_i as [رقم اذن الاستلام],date_i as [تاريخ اذن الاستلام] FROM salahia where state_sal=0 and date_end <= '" & date_1.ToString("yyyy/MM/dd") & "' and date_end <> '" & date_2.ToString("yyyy/MM/dd") & "'"
        Dim ad As New SqlDataAdapter(s, cn)
        'ds.Clear()
        ad.Fill(ds, "salahia")
        Me.DataGridViewX2.DataSource = ds
        Me.DataGridViewX2.DataMember = "salahia"
        Me.DataGridViewX2.Refresh()

        Dim s1 As String = " SELECT no_c AS [رقم الصنف],sal_s AS [سعر الوحدة],date_end AS [تاريخ انتهاء الصلاحية],mdh AS [المدة],mdh_a as [نوع المدة],date_mdh as [تاريخ التنبيه],no_i as [رقم اذن الاستلام],date_i as [تاريخ اذن الاستلام] FROM salahia where state_sal=0 and date_mdh <= '" & date_1.ToString("yyyy/MM/dd") & "' and  date_end > '" & date_1.ToString("yyyy/MM/dd") & "' and date_end <> '" & date_2.ToString("yyyy/MM/dd") & "'"


        Dim ad1 As New SqlDataAdapter(s1, cn)

        ad1.Fill(ds1, "salahia")
        'ds.Clear()
        Me.DataGridViewX1.DataSource = ds1
        Me.DataGridViewX1.DataMember = "salahia"
        Me.DataGridViewX1.Refresh()
       
  
    End Sub




    


    'Sub FinishDate()
    '    'هذا  سيجلب كل المنتجات التي ستنتهي صلاحيتها بعد 3 ايام من اليوم'
    'Me.NotifyIcon1.Icon = Me.Icon

    '    Me.NotifyIcon1.ShowBalloonTip( _
    '        5000, _
    '        " منظومة مراقبة المخزون رسالة", _
    '        "يرجى الإنتباه" & vbNewLine & _
    '        "هناك اصناف ستنتهى صلاحيتها بعد مدة" _
    '        , ToolTipIcon.Info)


    '    Dim d, m As Date

    '    For i As Integer = 0 To Me.DataGridViewX2.Rows.Count - 1

    '        d = CDate(DataGridViewX2.Rows(i).Cells(3).Value).ToString("yyyy/MM/dd")
    '        m = Now.AddDays(1).ToString("yyyy/MM/dd")
    '        If (CDate(DataGridViewX2.Rows(i).Cells(3).Value).ToString("yyyy/MM/dd")) = Now.AddDays(3).ToString("yyyy/MM/dd") Then
    '            MsgBox("ثلاثه ايام")

    '            'Dim LI As New ListViewItem
    '            'LI.Text = DataGridViewX2.Rows(i).Cells(1).Value.ToString()
    '            'LI.SubItems.Add((DataGridViewX2.Rows(i).Cells(2).Value).ToString())
    '            'LI.SubItems.Add(CDate(DataGridViewX2.Rows(i).Cells(3).Value).ToString("dd/MM/yyyy"))
    '            'ListView1.Items.Add(LI)

    '        End If
    '    Next
    'End Sub

   

  

   

  

   
   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Im_talef = "فورم الصلاحيه"
        Dim k As New FT_P
        If DataGridViewX2.RowCount = 0 Then
            Exit Sub
        End If


        '***************************
        If cn.State = ConnectionState.Closed Then cn.Open()
        date_1 = Date.Now
        date_2 = "1990/01/01"
        k.DataGridViewX2.DataMember = ""
        k.DataGridViewX2.DataSource = Nothing
        Dim ds As New DataSet()
        Dim ds1 As New DataSet()
        Dim s As String = " SELECT no_c AS [رقم الصنف],sal_s AS [سعر الوحدة],date_end AS [تاريخ انتهاء الصلاحية],mdh AS [المدة],mdh_a as [نوع المدة],date_mdh as [تاريخ التنبيه],no_i as [رقم اذن الاستلام],date_i as [تاريخ اذن الاستلام] FROM salahia where state_sal=0 and date_end <= '" & date_1.ToString("yyyy/MM/dd") & "' and date_end <> '" & date_2.ToString("yyyy/MM/dd") & "'"
        Dim ad As New SqlDataAdapter(s, cn)
        'ds.Clear()
        ad.Fill(ds, "salahia")
        k.DataGridViewX2.DataSource = ds
        k.DataGridViewX2.DataMember = "salahia"
        k.DataGridViewX2.Refresh()
        k.RadioButton1.Checked = True
        k.auto_no()
        k.ShowDialog()

    End Sub

    Private Sub Form_slh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridViewX2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX2.CellContentClick

    End Sub
End Class