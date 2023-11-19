
Imports System.Data.SqlClient
Imports mdobler.XPCommonControls
Imports DevComponents.DotNetBar
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Public Class Formsalh
    Dim sf As String
    Dim s2 As String = "select * from RcvMain"
    Dim adRcvM As New SqlDataAdapter(s2, cn)
    Dim dsRcvM As New DataSet()
    Dim s As String = "select * from user_pass"
    Dim ad1 As New SqlDataAdapter(s, cn)
    Dim ds1 As New DataSet

    Dim sbrnch As String = "select * from brnch"
    Dim adbrnch As New SqlDataAdapter(sbrnch, cn)
    Dim dsbrnch As New DataSet
    Sub clear()
        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""

    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        If Me.TextBox2.Text.Length <= 3 Then
            MsgBox("يجب ادخال كلمة المرور اكثر من ثلاثة احرف")
            Exit Sub
        End If
        If Me.RadioButton2.Checked = True Then
            sf = "امين مخزن"

            v1 = True
            v2 = False
            v3 = False
        End If
        If Me.RadioButton1.Checked = True Then
            sf = "مراقب المخزون"
            v1 = False
            v2 = True
            v3 = False
        End If

        If Me.RadioButton3.Checked = True Then
            sf = "مراجع"
            v1 = False
            v2 = False
            v3 = True
        End If

        If TextBox1.Text <> "" Then
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim sm As String = "insert into user_pass(u_name,u_pass,val1,val2,val3,sefa,admin_sec,no_kshf) values (@x1,@x2,@x3,@x4,@x5,@x6,@x7,@x8)"
            Dim cm1 As New SqlCommand(sm, cn)

            cm1.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
            cm1.Parameters.Add(New SqlParameter("@x2", TextBox2.Text))
            cm1.Parameters.Add(New SqlParameter("@x3", v1))
            cm1.Parameters.Add(New SqlParameter("@x4", v2))
            cm1.Parameters.Add(New SqlParameter("@x5", v3))
            cm1.Parameters.Add(New SqlParameter("@x6", sf))
            cm1.Parameters.Add(New SqlParameter("@x7", False))
            cm1.Parameters.Add(New SqlParameter("@x8", Me.ComboBox3.SelectedValue))
            Try
                cm1.ExecuteNonQuery()
                ds1.Clear()
                ad1.Fill(ds1, "user_pass")
                clear()
                cn.Close()
            Catch
                MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
                Exit Sub
            End Try

        End If


        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        '1111111111111111111111111111111111111
        Dim s As String = "select * from user_pass where u_name=@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", (Me.TextBox1.Text)))
        Dim r As SqlDataReader = cm.ExecuteReader
        If r.Read = True Then
          
            Me.TextBox2.Text = r!u_pass
            Me.TextBox1.Text = r!u_name
            Me.ComboBox3.SelectedValue = r!no_kshf
            If r!sefa = "مراقب المخزون" Then
                RadioButton1.Checked = True
            End If

            If (r!sefa = "امين مخزن" Or r!sefa = "موظف") Then
                RadioButton2.Checked = True
            End If


            If r!sefa = "مراجع" Then
                RadioButton3.Checked = True
            End If

            'If r!sefa = "admin" Then
            '    RadioButton4.Checked = True
            'End If

            r.Close()
            ButtonX1.Enabled = False

            ButtonX3.Enabled = True
            ButtonX4.Enabled = True

        Else
            ButtonX1.Enabled = True

            ButtonX3.Enabled = False
            ButtonX4.Enabled = False
            r.Close()
            MsgBox("  الـمستخـد م غيـر موجود", MsgBoxStyle.Exclamation, "تنبية")
            Exit Sub
        End If

    End Sub

    Private Sub Formsalh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        langarabic()
        Me.RadioButton4.Enabled = False
        Dim s1 As String = "select 0 as type_k,'من دون تحديد' as n_type union all  select type_k,n_type from ksf"
        Dim ada1 As New SqlDataAdapter(s1, cn)
        Dim dsa1 As New DataSet()
        ada1.Fill(dsa1, "ksf")
        ComboBox3.DataSource = dsa1
        ComboBox3.DisplayMember = "ksf.n_type"
        ComboBox3.ValueMember = "type_k"
        ComboBox3.SelectedIndex = -1
        'ComboBox3.SelectedValue = 1


        ButtonX1.Enabled = False
        ButtonX2.Enabled = True
        ButtonX4.Enabled = False
        ButtonX3.Enabled = False
        TextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
        AutocomplateCustomSource()

    End Sub


    Private Sub AutocomplateCustomSource()

        On Error Resume Next
        Dim i As Integer
        ' ''cn.Open()
        Dim da As New SqlDataAdapter("Select u_name From user_pass", cn)
        Dim ds As New DataSet
        da.Fill(ds)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            TextBox1.AutoCompleteCustomSource.Add(ds.Tables(0).Rows(i)(0))
            'ComboBox1.AutoCompleteCustomSource.Add(ds.Tables(0).Rows(i)(0))
        Next i
        cn.Close()
    End Sub
    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        Dim f, f1 As Boolean

        If RadioButton4.Checked = True Then
            MsgBox("لاتستطيع حذف المستخدم ")
            Exit Sub
        Else

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim sa As String = "select * from RcvMain where u_name=@x1 "
            Dim cma As New SqlCommand(sa, cn)
            cma.Parameters.Add(New SqlParameter("@x1", (TextBox1.Text)))


            Dim r As SqlDataReader = cma.ExecuteReader
            If r.Read = True Then
                f = True
                r.Close()
            Else
                f = False
                r.Close()
            End If

            '2222222222222222222222222222

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim sa1 As String = "select * from IsuMain where u_name=@x1 "
            Dim cma1 As New SqlCommand(sa1, cn)
            cma1.Parameters.Add(New SqlParameter("@x1", (TextBox1.Text)))


            Dim r1 As SqlDataReader = cma1.ExecuteReader
            If r1.Read = True Then
                f1 = True
                r1.Close()
            Else
                f1 = False
                r1.Close()
            End If
            If f = True Or RadioButton1.Checked = True Then
                MsgBox("لاتستطيع حذف المستخدم ")
            Else

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim s As String = "delete from user_pass where u_name=@x1 "
                Dim cm As New SqlCommand(s, cn)
                cm.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))

                Try
                    cm.ExecuteNonQuery()
                    MsgBox("تم حذف المستخدم", MsgBoxStyle.Information, " تنبيه")
                    ds1.Clear()
                    ad1.Fill(ds1, "user_pass")
                    cn.Close()
                Catch

                End Try

            End If
        End If
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text <> "" Then

                ButtonX2_Click(sender, e)
                'clear_a()
            Else
                'clear_a()
                'Me.TextBoxX6.Text = ""
                'DataGridViewX2.DataMember = ""
                'DataGridViewX2.DataSource = Nothing

                MsgBox("ادخل اسم المستخدم المراد البحث عليه  ", MsgBoxStyle.SystemModal, "تنبية")
            End If
        End If

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress


    End Sub


    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        'Me.TextBox2.Clear()
        'RadioButton1.Checked = False
        'RadioButton2.Checked = False
        'RadioButton3.Checked = False
    End Sub


    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        'Me.TextBox2.Clear()
        'RadioButton1.Checked = False
        'RadioButton2.Checked = False
        'RadioButton3.Checked = False
    End Sub


    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        Dim s As String = "update  user_pass set u_pass=@x2,val1=@x3,val2=@x4,val3=@x5,sefa=@x6 where u_name=@x1 "
        Dim cm1 As New SqlCommand(s, cn)



        If Me.RadioButton2.Checked = True Then
            sf = "امين مخزن"

            v1 = True
            v2 = False
            v3 = False
        End If
        If Me.RadioButton1.Checked = True Then
            sf = "مراقب المخزون"
            v1 = False
            v2 = True
            v3 = False
        End If

        If Me.RadioButton3.Checked = True Then
            sf = "مراجع"
            v1 = False
            v2 = False
            v3 = True
        End If
        cm1.Parameters.Add(New SqlParameter("@x1", TextBox1.Text))
        cm1.Parameters.Add(New SqlParameter("@x2", TextBox2.Text))
        cm1.Parameters.Add(New SqlParameter("@x3", v1))
        cm1.Parameters.Add(New SqlParameter("@x4", v2))
        cm1.Parameters.Add(New SqlParameter("@x5", v3))
        cm1.Parameters.Add(New SqlParameter("@x6", sf))
        Try
            cm1.ExecuteNonQuery()
            ds1.Clear()
            ad1.Fill(ds1, "user_pass")


            MsgBox("تم التعديل", MsgBoxStyle.Information, "تنبية")
            clear()
            cn.Close()
        Catch
            MsgBox("لايمكنك الإضافة فالسجل موجود مسبقاً", MsgBoxStyle.Critical, "تنبية")
            Exit Sub
        End Try
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class