Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Security.Permissions

Imports System.Security
Imports System.Security.Principal
Imports System.Security.AccessControl
Imports Microsoft.Win32

Imports System.IO
Imports System.Text


Module Module1

    Public dateNowDB As Date

    Public Im_talef As String
    Public Im_tadel As String
    Public Im_tadel_s As String
    Public ImportersDT As New DataTable
    Public ImportersDA As New SqlDataAdapter
    Public mynewIDImporters As New Integer


    Public coun_test, u As Integer
    Public xl As String
    Public colors As Integer
    'Public cn As New SqlConnection("Data Source=.;Initial Catalog=dbm;Integrated Security=True")
    Dim kmsg_q As New msg_q
    Public fForm13 As FrmLogin
    Public branch As String
    Public v1, v2, v3, slahia_t, slahia_ts As Boolean
    'Public f_Form_1 As New Form_1
    'Public f_Form_ins As New Form_ins
    Public ww, pp, sefa, admin_sec As String
    Public m, y1 As Integer
    Public sal_st, trn_st As Integer
    Dim x As Integer
    Public saction_user As String = "select * from action_user"
    Public adsaction_user As New SqlDataAdapter(saction_user, cn)
    Public dssaction_user As New DataSet()
    Public ts, t_doc, t_event As String
    'Public k As New matt_return
    Public NameServer As String = ""

    Public no_contract As String
    Public No_project As Integer

    Public cn As New SqlConnection

    Public NameBrch, AdminDBNameUser, AdminDBPassword As String
    Public myNo As String

    Public Function getNewNo(ByVal YearEnter As Integer, ByVal ProName As String) As String
        '--------------------------

        Dim Cmd As New SqlCommand(ProName, cn)

        Cmd.CommandType = CommandType.StoredProcedure

        Dim param As New SqlParameter()
        param.ParameterName = "@NewNo"
        param.SqlDbType = SqlDbType.VarChar

        param.Size = 10

        param.Direction = ParameterDirection.Output
        Cmd.Parameters.Add(param)

        With Cmd.Parameters

            .Add("@Year", SqlDbType.Int).Value = YearEnter

        End With

        Try

            If cn.State = ConnectionState.Closed Then cn.Open()

            Cmd.ExecuteNonQuery()

        Catch ex As Exception

        End Try

        Return Cmd.Parameters("@NewNo").Value.ToString()

    End Function
 
    Function checkNum(ByVal mytext As String) As String
        Try

            Dim NumAfterDot As String = ""

            For i As Integer = 0 To mytext.Length - 1

                If mytext(i) = "." Then

                    For k As Integer = i + 1 To mytext.Length - 1

                        NumAfterDot = NumAfterDot & mytext(k)

                    Next

                End If

            Next


            If NumAfterDot = "" Then
                myNo = mytext

                Return "int"
            Else
                myNo = NumAfterDot

                If CInt(NumAfterDot) = 0 Then
                    Return "int"
                Else
                    Return "decimal"
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function decrypt_admin(ByVal encryptpwd As String) As String
        Dim decryptpwd As String = String.Empty
        Dim encodepwd As New UTF8Encoding()
        Dim Decode As Decoder = encodepwd.GetDecoder()
        Dim todecode_byte As Byte() = Convert.FromBase64String(encryptpwd)
        Dim charCount As Integer = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)
        Dim decoded_char As Char() = New Char(charCount - 1) {}
        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)
        decryptpwd = New [String](decoded_char)
        Return decryptpwd
    End Function


    


    Function l_ps(ByVal mytext As String, ByVal datt As Date) As String
        ''Dim a As Integer
        'a = 0
        Dim datt1, a As Integer
        datt1 = (datt.Year)

        a = Len(mytext)
        If a = 1 Then
            mytext = (Str(datt1) + "000" + mytext)
        End If
        If a = 2 Then
            mytext = (Str(datt1) + "00" + mytext)
        End If
        If a = 3 Then
            mytext = (Str(datt1) + "0" + mytext)
        End If
        If a = 4 Then
            mytext = (Str(datt1) + "0" + mytext)
        End If
        'If a = 5 Then
        '    mytext = (Str(datt1) + "0" + mytext)
        'End If
        'If a = 6 Then
        '    mytext = (datt1 + mytext)

        'End If
        l_ps = mytext
    End Function

    Function l_p(ByVal mytext As String) As String


        Dim datt, a As Integer
        a = 0
        datt = Now.Year

        a = Len(mytext)
     
        If a = 1 Then
            mytext = (Str(datt) + "00000" + mytext)
        End If
        If a = 2 Then
            mytext = (Str(datt) + "0000" + mytext)
        End If
        If a = 3 Then
            mytext = (Str(datt) + "000" + mytext)
        End If
        If a = 4 Then
            mytext = (Str(datt) + "00" + mytext)
        End If
        If a = 5 Then
            mytext = (Str(datt) + "0" + mytext)
        End If
        If a = 6 Then
            mytext = (datt + mytext)

        End If
        l_p = mytext
    End Function
    Function creatConnection() As Boolean
        Try
        

            ' ''==========”«—…================

            Dim strconnect As String = "Data Source=" & NameServer & ";Integrated Security=True"

            cn.ConnectionString = strconnect


            ' '' ''=====··‘»ﬂ…==



            'Dim NameServe As String = NameServer & "User ID=" & AdminDBNameUser & ";Password=" & AdminDBPassword

            'cn.ConnectionString = NameServe
            'Try
            '    My.Settings.Item("dbm_CConnectionString") = NameServe


            'Catch ex As Exception

            'End Try
            '=======


            cn.Open()
            Return True
        Catch
            cn.Dispose()
            Return False
        End Try
    End Function
#Region "RTL Fuction "
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Const LVM_FIRST As Long = &H1000
    Const LVM_GETHEADER As Long = (LVM_FIRST + 31)
    Const ws As Integer = &H400000
    Const gw As Short = -20

    Public Sub RTL(ByVal Obj As Control)
        Dim O As Integer
        If TypeName(Obj) = "ListView" Then
            Dim hHeader As Long
            hHeader = SendMessage(Obj.Handle.ToInt32, LVM_GETHEADER, 0, 0&)
            O = GetWindowLong(hHeader, gw)
            SetWindowLong(hHeader, gw, O Or ws)
        End If
        O = GetWindowLong(Obj.Handle.ToInt32, gw)
        SetWindowLong(Obj.Handle.ToInt32, gw, O Or ws)
    End Sub
#End Region
    Public Sub langarabic()
        Dim lang As InputLanguage
        For Each lang In InputLanguage.InstalledInputLanguages
            If lang.Culture.EnglishName.ToUpper Like "arabic*".ToUpper Then
                InputLanguage.CurrentInputLanguage = lang
            End If
        Next
    End Sub

    Function GetOsBitness() As String
        Dim Bit As Integer
        Dim ProcessorSet As Object
        Dim CPU As Object
        ProcessorSet = GetObject("Winmgmts:").ExecQuery("SELECT * FROM Win32_Processor")
        For Each CPU In ProcessorSet
            Bit = CStr(CPU.AddressWidth)
        Next
        Return Bit
    End Function

    Sub checkUpRegApp()
        Try
            '---------------------------------------------------------------
            '«· Õﬁﬁ „‰ ﬁ«‰Ê‰Ì… «·„‰ŸÊ„…
            '----------------------------------------
            Dim AppNameReg As String = "sysstocks"

            ' Create the example key with registry security.
            Dim rkReadCodeRun As RegistryKey = Nothing
            rkReadCodeRun = Registry.LocalMachine

            ' Open the key with read access.
            rkReadCodeRun = rkReadCodeRun.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\scuresft\" & AppNameReg & "\CodeRun", False)

            If (rkReadCodeRun Is Nothing) Then

                Dim procStartInfo As New ProcessStartInfo
                Dim procExecuting As New Process

                With procStartInfo
                    .UseShellExecute = True

                    If GetOsBitness() = "X86" Then
                        .FileName = "RegisterProduct32.exe"
                    Else
                        .FileName = "RegisterProduct64.exe"
                    End If

                    .WindowStyle = ProcessWindowStyle.Normal
                    .Verb = "runas" 'add this to prompt for elevation
                End With

                procExecuting = Process.Start(procStartInfo)

                End
            End If

            Dim CodeRun As String = ""
            '«· Õﬁﬁ „‰  ”ÃÌ· «·„‰ŸÊ„…

            CodeRun = rkReadCodeRun.GetValue("CodeRun", 0.0)

            If CodeRun <> "90764299750094" Then

                Dim procStartInfo As New ProcessStartInfo
                Dim procExecuting As New Process

                With procStartInfo
                    .UseShellExecute = True

                    If GetOsBitness() = "X86" Then
                        .FileName = "RegisterProduct32.exe"
                    Else
                        .FileName = "RegisterProduct64.exe"
                    End If

                    .WindowStyle = ProcessWindowStyle.Normal
                    .Verb = "runas" 'add this to prompt for elevation
                End With

                procExecuting = Process.Start(procStartInfo)

                End

            End If

            rkReadCodeRun.Close()

            Dim rkReadName As RegistryKey = Nothing
            rkReadName = Registry.LocalMachine
            rkReadName = rkReadName.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\scuresft\" & AppNameReg & "\NameBrch", False)

            NameBrch = rkReadName.GetValue("NameBrch", 0.0)

            rkReadName.Close()

            Dim rkReadNameUser As RegistryKey = Nothing
            rkReadNameUser = Registry.LocalMachine
            rkReadNameUser = rkReadNameUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\scuresft\" & AppNameReg & "\NameUserSQL", False)

            If rkReadNameUser.GetValue("NameUserSQL", 0.0) = "" Then
                AdminDBNameUser = rkReadNameUser.GetValue("NameUserSQL", 0.0)
            Else
                AdminDBNameUser = decrypt_admin(rkReadNameUser.GetValue("NameUserSQL", 0.0))
            End If

            rkReadNameUser.Close()

            Dim rkReadPassUser As RegistryKey = Nothing
            rkReadPassUser = Registry.LocalMachine
            rkReadPassUser = rkReadPassUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\scuresft\" & AppNameReg & "\PassUserSQL", False)

            If rkReadPassUser.GetValue("PassUserSQL", 0.0) = "" Then
                AdminDBPassword = rkReadPassUser.GetValue("PassUserSQL", 0.0)
            Else
                AdminDBPassword = decrypt_admin(rkReadPassUser.GetValue("PassUserSQL", 0.0))
            End If

            rkReadPassUser.Close()

        Catch ex As Exception
            MsgBox("Œÿ√ ›Ì  ”ÃÌ· «·„‰ŸÊ„….")
            End
        End Try
    End Sub

    '""""""""""""""""""""""«·—ﬁ„Ì… «·»Ì«‰«  „⁄ ÊÃÊœ «·œÊ  #Õ„«Ì…#"""""""""""""""""""

    Public Sub secu_num1(ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Select Case Asc(e.KeyChar)
            Case 8, 48 To 57
                e.Handled = False
            Case 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select

    End Sub
    Public Sub seck_caps(ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Select Case Asc(e.KeyChar)
            Case 20
                e.Handled = False

            Case Else
                e.Handled = True
        End Select

    End Sub
    Public Sub secu_text(ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Select Case Asc(e.KeyChar)
            Case 48 To 57
                e.Handled = True
            Case 33 To 45, 47
                e.Handled = True
            Case 91 To 96
                e.Handled = True
            Case 58 To 64
                e.Handled = True
            Case 79 To 80
                e.Handled = True
            Case 73
                e.Handled = True
            Case 123 To 126
                e.Handled = True
            Case 46
                e.Handled = False
            Case 220
                e.Handled = False
            Case 161
                e.Handled = False
                'Case 32
                '    If x = 0 Then
                '        e.Handled = False
                '        x = 1
                '    Else
                '        e.Handled = True
                '    End If
            Case 20
                e.Handled = False
            Case Else
                e.Handled = False
                x = 0

        End Select
    End Sub
    Public Sub secu_num(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case Asc(e.KeyChar)
            Case 8, 48 To 57
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub
    Public Sub secu_zero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case Asc(e.KeyChar)
            Case 48
                e.Handled = True
            Case Else
                e.Handled = False
        End Select
    End Sub

    Sub main()

        Try
            checkUpRegApp()

            If File.Exists(Application.StartupPath & "\ConectionString") = False Then
                NameServer = File.ReadAllText(Application.StartupPath & "\ConectionString")
            Else
                NameServer = File.ReadAllText(Application.StartupPath & "\ConectionString")
            End If

            If Not creatConnection() Then
                'MsgBox("·« Ì„ﬂ‰ «·« ’«· »ﬁ«⁄œ… «·»Ì«‰« ", MsgBoxStyle.MsgBoxHelp)
                Exit Sub
            End If

            Application.EnableVisualStyles()
            Dim s As String = "select * from brnch "
            Dim ad As New SqlDataAdapter(s, cn)
            Dim tb As DataTable
            Dim ds As New DataSet
            ad.Fill(ds, "brnch")
            tb = ds.Tables(0)
            Dim dr As DataRow
            Try
                dr = tb.Rows(0)
                branch = dr(1)
            Catch ex As Exception
                branch = " "
            End Try
            ad.Dispose()
            ds.Dispose()




            If branch <> " " Then
                Application.Run(FrmLogin)

            Else
                Application.Run(msg_q)



            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Sub fillcbo(ByVal cbo As ComboBox, ByVal tabelname As String, ByVal fald1 As String, ByVal fald2 As String) '·„·∆ «·«œ«¡ ﬂÊ„»Ê
        cn.Close()
        cn.Open()
        Dim sql As String = "select * from " & tabelname
        Dim adp As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds, tabelname)
        cbo.DataSource = ds
        cbo.DisplayMember = fald1
        cbo.ValueMember = fald2
        cbo.SelectedIndex = -1
    End Sub

    Sub s_tran()
        Dim s As String = "select * from tran_IRT where tran_IRT.tr_nom=(select max(tr_nom) from tran_IRT)"
        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "tran_IRT")
        tb = ds.Tables(0)
        Dim dr As DataRow
        Try
            dr = tb.Rows(0)
            trn_st = dr(0) + 1
        Catch ex As Exception
            trn_st = "1"
        End Try
        ad.Dispose()
        ds.Dispose()
    End Sub

    'Sub veiw_list_slahia()


    '    Dim date_1 As Date

    '    date_1 = Date.Now

    '    Dim s As String = " select * from salahia where date_end <='" & date_1.ToString("yyyy/MM/dd") & "'"
    '    Dim ad As New SqlDataAdapter(s, cn)
    '    Dim tb As DataTable
    '    Dim ds As New DataSet
    '    ad.Fill(ds, "salahia")
    '    tb = ds.Tables(0)
    '    Dim dr As DataRow
    '    Try
    '        dr = tb.Rows(0)
    '        slahia_t = True
    '    Catch ex As Exception
    '        slahia_t = False
    '    End Try
    '    ad.Dispose()
    '    ds.Dispose()




    'End Sub
    Sub veiw_list_slahiat()
        coun_test = 0
        Dim date_1, date_2 As Date
        date_2 = "1990/01/01"
        date_1 = Date.Now
      


        Dim s As String = " SELECT * FROM salahia where state_sal=0 and date_end <> '" & date_2.ToString("yyyy/MM/dd") & "' and date_mdh <= '" & date_1.ToString("yyyy/MM/dd") & "'"
        Dim ad As New SqlDataAdapter(s, cn)
        Dim tb As DataTable
        Dim ds As New DataSet
        ad.Fill(ds, "salahia")
        tb = ds.Tables(0)
        Dim dr As DataRow
        Try
            dr = tb.Rows(0)
            slahia_t = True
            coun_test = ds.Tables(0).Rows.Count
        Catch ex As Exception
            slahia_t = False
        End Try
        ad.Dispose()
        ds.Dispose()



    End Sub
End Module

