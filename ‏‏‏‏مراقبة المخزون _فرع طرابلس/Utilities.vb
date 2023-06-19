Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
'Imports System.Web
'Imports System.Web.Services
Imports Microsoft.VisualBasic
Module Utilities
    '<%@ WebService Language="VB" Class="NumberToWords" %>
    Public Class NumberToWords
        Const An As String = " � "
        Const Ab As String = " ����"

        'Inherits System.Web.Services.WebService
        '<WebMethod(Description:="Gets the words for a Number", EnableSession:=False)> _
        Public Function getWords(ByVal myNumber As String) As String
            getWords = SpellNumber(myNumber) & Ab
        End Function
        Private Function GetIndex(ByVal S As String) As Byte
            If Val(S) = 1 Then
                GetIndex = 1
            ElseIf Val(S) = 2 Then
                GetIndex = 2
            ElseIf Val(S) >= 3 And Val(S) <= 10 Then
                GetIndex = 3
            Else
                GetIndex = 1

            End If

        End Function
        'Main Function
        Private Function SpellNumber(ByVal MyNumber As String)
            Dim intPound, intPiaster, Temp
            Dim DecimalPlace, Count

            Dim Place(9, 3) As String
            Place(2, 1) = " ��� "
            Place(2, 2) = " ����� "
            Place(2, 3) = " ���� "

            Place(3, 1) = " ����� "
            Place(3, 2) = " ������� "
            Place(3, 3) = " ������ "

            Place(4, 1) = " ����� "
            Place(4, 2) = " ������� "
            Place(4, 3) = " ������ "

            Place(5, 1) = " ������� "
            Place(5, 2) = " ������� "
            Place(5, 3) = " ������� "

            ' String representation of amount
            MyNumber = Convert.ToString(MyNumber)

            ' Position of decimal place 0 if n����
            DecimalPlace = InStr(MyNumber, ".")
            'Convert intPiaster � set MyNumber to ���� amount
            If DecimalPlace > 0 Then
                intPiaster = GetTens(Left(Mid(MyNumber, DecimalPlace + 1) & "00", 2))
                MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
            End If

            Count = 1
            Do While MyNumber <> ""
                Temp = GetHundreds(Right(MyNumber, 3))
                Dim S As String = Right(MyNumber, 3)
                If Count = 1 Then
                    If Temp <> "" Then intPound = Temp & Place(Count, GetIndex(S)) & intPound
                Else
                    If Val(Right(MyNumber, 3)) <= 2 Then
                        If Temp <> "" Then intPound = Place(Count, GetIndex(S)) & An & intPound
                    Else
                        If Temp <> "" Then intPound = Temp & Place(Count, GetIndex(S)) & An & intPound
                    End If
                End If
                If Len(MyNumber) > 3 Then
                    MyNumber = Left(MyNumber, Len(MyNumber) - 3)
                Else
                    MyNumber = ""
                End If
                Count = Count + 1
            Loop
            If Right(intPound, 3) = An Then
                intPound = Left(intPound, Len(intPound) - 3)
            End If
            Select Case intPound
                Case ""
                    intPound = "��� �����"
                Case "����"
                    intPound = "����� ����"
                Case "�����"
                    intPound = "�������"
                Case "�����"
                    intPound = "����� �����"
                Case "�����"
                    intPound = "����� �����"
                Case "����"
                    intPound = "���� �����"
                Case "���"
                    intPound = "��� �����"
                Case "����"
                    intPound = "���� �����"
                Case "������"
                    intPound = "������ �����"
                Case "����"
                    intPound = "���� �����"
                Case "����"
                    intPound = "���� �����"
                Case Else
                    intPound = intPound & " �����"
            End Select

            Select Case intPiaster
                Case ""
                    intPiaster = ""
                Case "����"
                    intPiaster = " � ���� ������"
                Case Else
                    intPiaster = " � " & intPiaster & " ������"
            End Select

            SpellNumber = intPound & intPiaster
        End Function

        'Converts a number from 100-999 into text
        Private Function GetHundreds(ByVal MyNumber As String)
            Dim Result As String

            If Val(MyNumber) = 0 Then Exit Function
            MyNumber = Right("000" & MyNumber, 3)

            'Convert the hundreds place
            If Mid(MyNumber, 1, 1) <> "0" Then
                Dim T As String = GetDigit(Mid(MyNumber, 1, 1))
                If T = "����" Then
                    Result = " ��� "

                ElseIf T = "�����" Then
                    Result = " ���� "

                ElseIf T = "�����" Then
                    Result = " �������� "

                ElseIf T = "�����" Then
                    Result = " �������� "

                ElseIf T = "����" Then
                    Result = " ������� "

                ElseIf T = "���" Then
                    Result = " ������ "

                ElseIf T = "����" Then
                    Result = " ������� "

                ElseIf T = "������" Then
                    Result = " �������� "

                ElseIf T = "����" Then
                    Result = " ������� "
                Else
                    Result = T & " ��� "
                End If
            End If

            'Convert the tens � ����s place
            If Mid(MyNumber, 2, 1) <> "0" Then
                Dim T As String = GetTens(Mid(MyNumber, 2))
                If Result = "" Then
                    Result = T
                Else
                    Result = Result & "� " & T
                End If
            ElseIf Mid(MyNumber, 3, 1) <> "0" Then
                Dim T As String = GetDigit(Mid(MyNumber, 3))
                If Result = "" Then
                    Result = T
                Else
                    Result = Result & "� " & T
                End If
            End If

            GetHundreds = Result
        End Function

        'Converts a number from 10 to 99 into text
        Private Function GetTens(ByVal TensText As String) As String
            Dim Result As String

            Result = "" 'null out the temporary function value
            If Val(Left(TensText, 1)) = 1 Then ' If value between 10-19
                Select Case Val(TensText)
                    Case 10 : Result = "����"
                    Case 11 : Result = "��� ���"
                    Case 12 : Result = "���� ���"
                    Case 13 : Result = "����� ���"
                    Case 14 : Result = "����� ���"
                    Case 15 : Result = "���� ���"
                    Case 16 : Result = "��� ���"
                    Case 17 : Result = "���� ���"
                    Case 18 : Result = "������ ���"
                    Case 19 : Result = "���� ���"
                    Case Else
                        Result = ""
                End Select
            Else ' If value between 20-99
                Select Case Val(Left(TensText, 1))
                    Case 2 : Result = "����� "
                    Case 3 : Result = "������ "
                    Case 4 : Result = "������ "
                    Case 5 : Result = "����� "
                    Case 6 : Result = "���� "
                    Case 7 : Result = "����� "
                    Case 8 : Result = "������ "
                    Case 9 : Result = "����� "
                    Case Else
                End Select
                If GetDigit(Right(TensText, 1)) = "" Then
                    Result = GetDigit(Right(TensText, 1)) & Result
                Else
                    Result = GetDigit(Right(TensText, 1)) & " � " & Result

                End If
            End If
            GetTens = Result
        End Function

        'Converts a number from 1 to 9 into text
        Private Function GetDigit(ByVal Digit As String) As String
            Select Case Val(Digit)
                Case 1 : GetDigit = "����"
                Case 2 : GetDigit = "�����"
                Case 3 : GetDigit = "�����"
                Case 4 : GetDigit = "�����"
                Case 5 : GetDigit = "����"
                Case 6 : GetDigit = "���"
                Case 7 : GetDigit = "����"
                Case 8 : GetDigit = "������"
                Case 9 : GetDigit = "����"
                Case Else : GetDigit = ""
            End Select
        End Function
    End Class
End Module
