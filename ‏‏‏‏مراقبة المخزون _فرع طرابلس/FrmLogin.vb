Imports System.Data.SqlClient

Imports System.Globalization
Imports Microsoft.Win32


Public Class FrmLogin
    Dim s As String = "select * from user_pass"
    Dim ad1 As New SqlDataAdapter(s, cn)
    Dim ds1 As New DataSet

    Dim sbrnch As String = "select * from brnch"
    Dim adbrnch As New SqlDataAdapter(sbrnch, cn)
    Dim dsbrnch As New DataSet

    Dim z1 As Boolean


    Sub up()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim sbrnch As String = "update  brnch set admm= '" & Me.ComboBoxEx2.Text & "'"
        Dim cm As New SqlCommand(sbrnch, cn)

        Try

            cm.ExecuteNonQuery()

            dsbrnch.Clear()
            adbrnch.Fill(dsbrnch, " brnch")

        Catch

        End Try
        cn.Close()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        If ComboBoxEx1.Text = "" Then
            MsgBox("«œŒ· «”„ «·„” Œœ„", MsgBoxStyle.OkOnly, " ‰»Ì…")
            ComboBoxEx1.Focus()
            Exit Sub
        End If
        If TextBoxX1.Text = "" Then
            MsgBox("«œŒ· ﬂ·„… «·„—Ê—", MsgBoxStyle.OkOnly, " ‰»Ì…")
            TextBoxX1.Focus()
            Exit Sub
        End If
        cn.Close()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        '1111111111111111111111111111111111111
        Dim s As String = "select * from user_pass where u_name=@x1"
        Dim cm As New SqlCommand(s, cn)

        cm.Parameters.Add(New SqlParameter("@x1", (ComboBoxEx1.Text)))
        Dim r As SqlDataReader = cm.ExecuteReader
        If r.Read = True Then
            v1 = r!val1
            v2 = r!val2
            v3 = r!val3
            pp = r!u_pass
            ww = r!u_name
            sefa = r!sefa
            admin_sec = r!admin_sec
            r.Close()
            If pp = Trim(TextBoxX1.Text) Then

                'up()
                Dim k As New main
                k.ToolStripStatusLabel13.Text = Me.ComboBoxEx2.Text
                Me.Hide()
                k.ShowDialog()

                ComboBoxEx1.SelectedIndex = -1
                Me.TextBoxX1.Clear()


            Else
                MsgBox("ﬂ·„… «·„—Ê— Œ«ÿ∆…", MsgBoxStyle.Information, " ‰»Ì…")
                TextBoxX1.Focus()
                Exit Sub
            End If
        Else
            r.Close()
            MsgBox("  «·‹„” Œ‹œ „ €Ì‹— „ÊÃÊœ", MsgBoxStyle.Exclamation, " ‰»Ì…")
            Exit Sub
        End If
        Me.Dispose()


    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        End
    End Sub

    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.Label2.Text = System.String.Format(Me.Label2.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        Me.Label2.Text = My.Application.Info.Copyright


        Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")
        Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sLongDate", "dd/MM/yyyy")

        Me.ComboBoxEx1.Focus()

        TextBoxX1.Clear()
        'Dim ds1 As New DataSet
        ds1.Clear()
        ad1.Fill(ds1, "user_pass")
        ComboBoxEx1.DataSource = ds1
        Me.ComboBoxEx1.DisplayMember = "user_pass.u_name"
        Me.ComboBoxEx1.SelectedIndex = -1
        Me.ComboBoxEx1.Refresh()
        '=====================
        'Dim ds2 As New DataSet
        dsbrnch.Clear()
        adbrnch.Fill(dsbrnch, "brnch")
        ComboBoxEx2.DataSource = dsbrnch
        Me.ComboBoxEx2.DisplayMember = "brnch.admm"
        branch = ComboBoxEx2.Text
        Me.ComboBoxEx2.SelectedIndex = -1
        Me.ComboBoxEx2.Refresh()


    End Sub


    Private Sub TextBoxX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ButtonX1_Click(sender, e)
        End If

    End Sub



End Class