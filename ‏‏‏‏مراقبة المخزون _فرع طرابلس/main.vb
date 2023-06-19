Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Public Class main
    Dim i, p, w, no As New Integer()

    Dim s As String = "select * from pointt"
    Dim adp As New SqlDataAdapter(s, cn)
    Dim dsp As New DataSet()
    Private Sub بياناتالاصنافToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form1
        k.ShowDialog()
    End Sub

    Private Sub اوامرالاستلامToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New FormRcsub
        k.ShowDialog()

    End Sub
   

    Private Sub main_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

       
        Timer1.Start()
        veiw_list_slahiat()


        If slahia_t = True Then
            Me.يوجدلديكاشعاراتToolStripMenuItem.Visible = True
            يوجدلديكاشعاراتToolStripMenuItem.Text = "لديك عدد من الاشعارات" + Str(coun_test)
            colors = 1

        Else
            Me.يوجدلديكاشعاراتToolStripMenuItem.Visible = False
        End If

    End Sub
    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (sefa = "امين مخزن") Then

            ToolStripMenuItem16.Enabled = True
            ToolStripMenuItem17.Enabled = True

            صرفToolStripMenuItem.Enabled = True
            تعديلToolStripMenuItem.Enabled = True

        End If
        If (sefa = "موظف") Then

            ToolStripMenuItem16.Enabled = True
            ToolStripMenuItem17.Enabled = True

            صرفToolStripMenuItem.Enabled = True
            تعديلToolStripMenuItem.Enabled = True

        End If
        If (sefa = "مراقب المخزون") Then
            ToolStripMenuItem16.Enabled = False
            ToolStripMenuItem17.Enabled = True

            صرفToolStripMenuItem.Enabled = False
            تعديلToolStripMenuItem.Enabled = True
        End If

        If sefa = "مراجع" Then
            ToolStripMenuItem16.Enabled = False
            ToolStripMenuItem17.Enabled = True

            صرفToolStripMenuItem.Enabled = False
            تعديلToolStripMenuItem.Enabled = True
        End If

       
        'SkinEngine1.SkinFile = "skins/ MidsummerColor1.ssk"

        If admin_sec = True Then
            ToolStripMenuItem3.Enabled = False
            بياناتالاصنافToolStripMenuItem.Enabled = False
            Me.استاذالمخزنToolStripMenuItem.Enabled = False
            Me.ToolStripMenuItem10.Enabled = False
            المصروفاتToolStripMenuItem.Enabled = False
            Me.حركهالصنفToolStripMenuItem.Enabled = False
            ToolStripMenuItem5.Enabled = False
            رصيدكلصنفToolStripMenuItem.Enabled = False
            ToolStripMenuItem1.Enabled = False
            كشوفاتالصرفToolStripMenuItem.Enabled = False
            ToolStripMenuItem4.Enabled = False
            الصلاحياتوالمستخدمينToolStripMenuItem.Enabled = True
        Else
            الصلاحياتوالمستخدمينToolStripMenuItem.Enabled = False
        End If
        Timer1.Start()


        'Me.Label1.Text = "/ فرع" + "" + branch
        'Me.ToolStripStatusLabel6.Text = branch
        Me.ToolStripStatusLabel6.Text = " برمجة المهندسة  / " + "" + " سـارة محـمود بــادى"
        Me.ToolStripStatusLabel7.Text = "..."
        Me.ToolStripStatusLabel8.Text = "اسم المستـخدم /"
        Me.ToolStripStatusLabel9.Text = ww
        Me.ToolStripStatusLabel10.Text = "..."
        Me.ToolStripStatusLabel11.Text = " الصفة /"
        Me.ToolStripStatusLabel12.Text = sefa
        Me.ToolStripStatusLabel13.Text = " ادارة تقنية المعلومات والاتصالات "


        'Me.ToolStripStatusLabel14.Text = Today.ToString("yyyy/MM/dd")

        ToolStripStatusLabel14.Text = System.String.Format(Me.ToolStripStatusLabel13.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        Me.ToolStripStatusLabel14.Text = My.Application.Info.Copyright


        'Me.LabelX1.Text = TimeOfDay
        'LabelX2.Text = DateString
        'Me.LabelX11.Text = TimeOfDay
        'LabelX12.Text = DateString
        'Me.LabelX3.Text = sefa
        'Dim culture As New Globalization.CultureInfo("ar-SA")
        'LabelX4.Text = Today.ToString("yyyy/MM/dd", culture)
       
        'LabelX9.Text = " عددالاصناف التى تكاد تنفذ " & con & " "
        'LabelX9.Visible = True

        'With NotifyIcon1
        '    ' النص الذي تريد كتابته
        '    .BalloonTipText = "هناك اصناف ستنتهى صلاحيتها "

        '    .BalloonTipTitle = "منظومة مراقبة المخزون"
        '    'الايقونه
        '    .BalloonTipIcon = ToolTipIcon.Info
        '    ' إظهار الرساله
        '    .ShowBalloonTip(2)

        'End With
        'veiw_list_slahia()
        'If slahia_t = True Then
        '    ser_tr()
        '    XpListView2.Visible = True
        '    Me.Label1.Visible = True
        'Else
        '    slahia_t = False
        '    XpListView2.Visible = False
        '    Me.Label1.Visible = False
        'End If
        'veiw_list_slahiat()
        'If slahia_ts = True Then

        '    Dim k As New Form_slh
        '    k.ShowDialog()

        'End If
        'If ww = True Then

        'End If

        Try

            Dim adp As New SqlDataAdapter("select getdate()", cn)
            Dim dt As New DataTable
            adp.Fill(dt)

            dateNowDB = dt.Rows(0).Item(0)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub الاقساموالفروعوالاداراتToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New F_part
        k.GroupPanel1.Text = "الاقسام والفروع والوحدة"
        k.Label1.Text = "اسم الفرع او القسم او الوحده"
        k.ShowDialog()
    End Sub

    Private Sub الموردينToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New F_part
        k.GroupPanel1.Text = "الجهات الموردة"
        k.Label1.Text = "جهة التوريد"
        k.ShowDialog()
    End Sub

    Private Sub اذوناتالصرفToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Formisu_sub
        k.ShowDialog()
    End Sub

    Private Sub طباعةالكشوفاتToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form15
        k.ShowDialog()
    End Sub

    Private Sub طباعةToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form8
        k.ShowDialog()
    End Sub

   
    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form_infbuy
        k.ShowDialog()

    End Sub

   
    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub اعادةالطلبToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form5
        k.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form_event
        k.ShowDialog()
    End Sub


    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form_sum
        k.ShowDialog()
    End Sub

    Private Sub صرفToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim k As New Form_Isu
        k.ShowDialog()
    End Sub

    Private Sub استلامToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Dim k As New Form_RCV
        ''k.ShowDialog()
    End Sub

    Private Sub حركهالصنفToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form_t
        k.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form_sum
        k.ShowDialog()
    End Sub

    Private Sub بياناتالاصنافToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form1
        k.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New matt_return
        k.ShowDialog()
    End Sub

    Private Sub استاذالمخزنToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form4
        k.ShowDialog()
    End Sub

    Private Sub كشوفاتالصرفToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form3
        k.ShowDialog()
    End Sub


    Private Sub كشفالارصدةToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form_balance
        k.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form15
        k.ShowDialog()
    End Sub


    Private Sub رصيدبالسعرToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form_sum
        k.ShowDialog()
    End Sub

    Private Sub رصيدالاصنافToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New matt_bay
        k.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form8
        k.ShowDialog()
    End Sub


    Private Sub كشوفاتالصرفToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles كشوفاتالصرفToolStripMenuItem.Click
        Dim k As New Form5
        k.ShowDialog()
    End Sub

    Private Sub رصيدالاصنافToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles رصيدالاصنافToolStripMenuItem.Click
        Dim k As New matt_bay
        k.ShowDialog()
    End Sub

    Private Sub رصيدبالسعرToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim k As New Form_sum
        'k.ShowDialog()
    End Sub

   

    Private Sub ToolStripMenuItem12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New matt_return
        k.ShowDialog()
    End Sub

    Private Sub المصروفاتToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles المصروفاتToolStripMenuItem.Click

    End Sub

    Private Sub اذوناتالصرفToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Formisu_sub
        k.ShowDialog()
    End Sub

    Private Sub صرفToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles صرفToolStripMenuItem.Click
     
        Dim k As New Form_Isu
        Im_tadel_s = "جديد"
        'k.GroupBox4.Visible = False
        k.ShowDialog()

    End Sub

  

    Private Sub بياناتالاصنافToolStripMenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles بياناتالاصنافToolStripMenuItem.Click
        Dim k As New Form1
        k.ShowDialog()
    End Sub


    Private Sub استاذالمخزنToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles استاذالمخزنToolStripMenuItem.Click
        Dim k As New Form4
        k.ShowDialog()
    End Sub

    Private Sub كشفالارصدةToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles كشفالارصدةToolStripMenuItem1.Click
        Dim k As New Form_balance
        k.ShowDialog()
    End Sub

  

    Private Sub كشوفاتالصرفToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles كشوفاتالصرفToolStripMenuItem1.Click
        Dim k As New Form3
        k.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Dim k As New Form8
        k.ShowDialog()
    End Sub

    

    Private Sub ToolStripMenuItem6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Dim k As New Form15
        k.ShowDialog()
    End Sub

  


    Private Sub الكشوفاتToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles الكشوفاتToolStripMenuItem.Click
        Dim k As New Fw_part
        k.GroupPanel1.Text = "الكشوفات"
        k.Label1.Text = "اسم الكشف"
        k.Label2.Visible = True
        k.TextBox1.Visible = True
        k.ButtonX5.Visible = True
        k.ShowDialog()
    End Sub

    Private Sub الوحداتToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles الوحداتToolStripMenuItem.Click
        Dim k As New Fw_part
        k.GroupPanel1.Text = "الوحدات"
        k.Label1.Text = "اسم الوحدة"
        k.Label2.Visible = False
        k.TextBox1.Visible = False
        k.ButtonX5.Visible = False
        k.ShowDialog()
    End Sub

    Private Sub الموردينToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles الموردينToolStripMenuItem1.Click
        Dim k As New F_part
        k.GroupPanel1.Text = "الجهات الموردة"
        k.Label1.Text = "جهة التوريد"
        k.TextBox3.Visible = False
        k.ShowDialog()
    End Sub

    Private Sub الاقساموالفروعوالوحدةToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles الاقساموالفروعوالوحدةToolStripMenuItem.Click
        Dim k As New F_part
        k.GroupPanel1.Text = "الاقسام والوحدات"
        k.Label1.Text = "اسم الفرع او الوحده"
        k.TextBox3.Visible = False
        k.ShowDialog()
    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    If Me.LabelX1.Left < Me.Width Then
    '        LabelX1.Left += 6
    '    Else
    '        LabelX1.Left = -LabelX1.Width
    '    End If
    'End Sub

    Private Sub MToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MToolStripMenuItem.Click
        Dim k As New Formtrn
        k.ShowDialog()
    End Sub

  

    Private Sub حركةالصنفToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form_t
        k.ShowDialog()
    End Sub

    Private Sub طلبشراءToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles طلبشراءToolStripMenuItem.Click
        Dim k As New Form_infbuy
        k.ShowDialog()
    End Sub

    'Private Sub مToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles مToolStripMenuItem.Click
    '    Dim k As New F_Tg

    '    Im_talef = "فورم الرئيسي"

    '    k.ShowDialog()
    'End Sub


    Private Sub استفساراتToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form14
        k.ShowDialog()
    End Sub

    Private Sub طلبترجيعToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form_TRET
        k.ShowDialog()
    End Sub

    Private Sub طلبسحبأصنافToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles طلبسحبأصنافToolStripMenuItem.Click

        Dim k As New Form_inf
        k.ShowDialog()
    End Sub

    Private Sub تقاريرToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles تقاريرToolStripMenuItem.Click
        Dim k As New F_tgrer
        k.ShowDialog()
    End Sub


    Private Sub عملياتالمستخدمينToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles عملياتالمستخدمينToolStripMenuItem.Click
        Dim k As New Form_event
        k.ShowDialog()
    End Sub

    Private Sub الصلاحياتوالمستخدمينToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles الصلاحياتوالمستخدمينToolStripMenuItem.Click
        Dim k As New Formsalh
        k.ShowDialog()
    End Sub


    Private Sub ToolStripMenuItem4_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Dim k As New Form18
        k.ShowDialog()
    End Sub




    Private Sub كشفاستلاماتToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles كشفاستلاماتToolStripMenuItem.Click
        Dim k As New Form_est
        k.ShowDialog()
    End Sub

    Private Sub دليلToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles دليلToolStripMenuItem.Click
        Try

            Process.Start(Application.StartupPath & "\مراقبة المخزون.docx")

        Catch ex As Exception

        End Try
    End Sub



    'Private Sub استلامToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles استلامToolStripMenuItem1.Click
    '    '    Dim k As New Form_totinf
    '    '    k.ShowDialog()
    'End Sub


    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Select Case colors 'جملة الحالة
            Case 1
                Me.يوجدلديكاشعاراتToolStripMenuItem.ForeColor = Color.Red
                colors += 1
            Case 2
                Me.يوجدلديكاشعاراتToolStripMenuItem.ForeColor = Color.White
                colors += 1
            Case 3
                Me.يوجدلديكاشعاراتToolStripMenuItem.ForeColor = Color.Red
                colors += 1
            Case 4
                Me.يوجدلديكاشعاراتToolStripMenuItem.ForeColor = Color.Yellow
                colors += 1
            Case 5
                Me.يوجدلديكاشعاراتToolStripMenuItem.ForeColor = Color.Red
                colors = 1
        End Select


    End Sub


    Private Sub اسToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New FormRcsub
        k.ShowDialog()
    End Sub

    Private Sub يوجدلديكاشعاراتToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles يوجدلديكاشعاراتToolStripMenuItem.Click
        Dim k As New Form_slh
        k.ShowDialog()
    End Sub



    Private Sub بحثToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As New Form20
        k.ShowDialog()
    End Sub
 
    Private Sub ToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem16.Click
        Dim k As New Form_s
        Im_tadel = "جديد"

        k.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        Dim k As New Form20
        Im_tadel = "تعديل"
        k.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        End
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click

    End Sub

    Private Sub مجToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub محضرتالفالصلاحيةToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles محضرتالفالصلاحيةToolStripMenuItem.Click

        Dim k As New FT_P
        Im_talef = "فورم الرئيسي"

        k.ShowDialog()

    End Sub


    Private Sub تعديلToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles تعديلToolStripMenuItem.Click

        Dim k As New C_Form
        Im_tadel_s = "تعديل"
        k.ShowDialog()

    End Sub

    Private Sub مToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripStatusLabel12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripStatusLabel7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel7.Click

    End Sub

    'Private Sub محضرتالفToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles محضرتالفToolStripMenuItem.Click
    '    Dim k As New FT_P1


    '    Im_talef = "فورم الرئيسي"

    '    k.ShowDialog()
    'End Sub

    'Private Sub ToolStripMenuItem12_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
    '    Dim k As New F_Tg


    '    'Im_talef = "فورم الرئيسي"

    '    k.ShowDialog()
    'End Sub
End Class