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
        Const An As String = " æ "
        Const Ab As String = " İŞÜØ"

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
            Place(2, 1) = " Ãáİ "
            Place(2, 2) = " Ãáİíä "
            Place(2, 3) = " ÂáÇİ "

            Place(3, 1) = " ãáíæä "
            Place(3, 2) = " ãáíæäíä "
            Place(3, 3) = " ãáÇííä "

            Place(4, 1) = " Èáíæä "
            Place(4, 2) = " Èáíæäíä "
            Place(4, 3) = " ÈáÇííä "

            Place(5, 1) = " ÊÑíáíæä "
            Place(5, 2) = " ÊÑíáíæä "
            Place(5, 3) = " ÊÑíáíæä "

            ' String representation of amount
            MyNumber = Convert.ToString(MyNumber)

            ' Position of decimal place 0 if næÇÍÏ
            DecimalPlace = InStr(MyNumber, ".")
            'Convert intPiaster æ set MyNumber to Ìäíå amount
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
                    intPound = "ÕİÑ ÏíäÇÑ"
                Case "æÇÍÏ"
                    intPound = "ÏíäÇÑ æÇÍÏ"
                Case "ÇËäíä"
                    intPound = "ÏíäÇÑÇä"
                Case "ËáÇËÉ"
                    intPound = "ËáÇËÉ ÏíäÇÑ"
                Case "ÇÑÈÚÉ"
                    intPound = "ÇÑÈÚÉ ÏíäÇÑ"
                Case "ÎãÓÉ"
                    intPound = "ÎãÓÉ ÏíäÇÑ"
                Case "ÓÊÉ"
                    intPound = "ÓÊÉ ÏíäÇÑ"
                Case "ÓÈÚÉ"
                    intPound = "ÓÈÚÉ ÏíäÇÑ"
                Case "ËãÇäíÉ"
                    intPound = "ËãÇäíÉ ÏíäÇÑ"
                Case "ÊÓÚÉ"
                    intPound = "ÊÓÚÉ ÏíäÇÑ"
                Case "ÚÔÑÉ"
                    intPound = "ÚÔÑÉ ÏíäÇÑ"
                Case Else
                    intPound = intPound & " ÏíäÇÑ"
            End Select

            Select Case intPiaster
                Case ""
                    intPiaster = ""
                Case "æÇÍÏ"
                    intPiaster = " æ æÇÍÏ ÏÑåãÇğ"
                Case Else
                    intPiaster = " æ " & intPiaster & " ÏÑåãÇğ"
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
                If T = "æÇÍÏ" Then
                    Result = " ãÆÉ "

                ElseIf T = "ÇËäíä" Then
                    Result = " ãÆÊÇ "

                ElseIf T = "ËáÇËÉ" Then
                    Result = " ËáÇËãÇÆÉ "

                ElseIf T = "ÇÑÈÚÉ" Then
                    Result = " ÇÑÈÚãÇÆÉ "

                ElseIf T = "ÎãÓÉ" Then
                    Result = " ÎãÓãÇÆÉ "

                ElseIf T = "ÓÊÉ" Then
                    Result = " ÓÊãÇÆÉ "

                ElseIf T = "ÓÈÚÉ" Then
                    Result = " ÓÈÚãÇÆÉ "

                ElseIf T = "ËãÇäíÉ" Then
                    Result = " ËãÇäãÇÆÉ "

                ElseIf T = "ÊÓÚÉ" Then
                    Result = " ÊÓÚãÇÆÉ "
                Else
                    Result = T & " ãÆÉ "
                End If
            End If

            'Convert the tens æ æÇÍÏs place
            If Mid(MyNumber, 2, 1) <> "0" Then
                Dim T As String = GetTens(Mid(MyNumber, 2))
                If Result = "" Then
                    Result = T
                Else
                    Result = Result & "æ " & T
                End If
            ElseIf Mid(MyNumber, 3, 1) <> "0" Then
                Dim T As String = GetDigit(Mid(MyNumber, 3))
                If Result = "" Then
                    Result = T
                Else
                    Result = Result & "æ " & T
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
                    Case 10 : Result = "ÚÔÑÉ"
                    Case 11 : Result = "ÇÍÏ ÚÔÑ"
                    Case 12 : Result = "ÇËäÇ ÚÔÑ"
                    Case 13 : Result = "ËáÇËÉ ÚÔÑ"
                    Case 14 : Result = "ÃÑÈÚÉ ÚÔÑ"
                    Case 15 : Result = "ÎãÓÉ ÚÔÑ"
                    Case 16 : Result = "ÓÊÉ ÚÔÑ"
                    Case 17 : Result = "ÓÈÚÉ ÚÔÑ"
                    Case 18 : Result = "ËãÇäíÉ ÚÔÑ"
                    Case 19 : Result = "ÊÓÚÉ ÚÔÑ"
                    Case Else
                        Result = ""
                End Select
            Else ' If value between 20-99
                Select Case Val(Left(TensText, 1))
                    Case 2 : Result = "ÚÔÑæä "
                    Case 3 : Result = "ËáÇËæä "
                    Case 4 : Result = "ÃÑÈÚæä "
                    Case 5 : Result = "ÎãÓæä "
                    Case 6 : Result = "ÓÊæä "
                    Case 7 : Result = "ÓÈÚæä "
                    Case 8 : Result = "ËãÇäæä "
                    Case 9 : Result = "ÊÓÚæä "
                    Case Else
                End Select
                If GetDigit(Right(TensText, 1)) = "" Then
                    Result = GetDigit(Right(TensText, 1)) & Result
                Else
                    Result = GetDigit(Right(TensText, 1)) & " æ " & Result

                End If
            End If
            GetTens = Result
        End Function

        'Converts a number from 1 to 9 into text
        Private Function GetDigit(ByVal Digit As String) As String
            Select Case Val(Digit)
                Case 1 : GetDigit = "æÇÍÏ"
                Case 2 : GetDigit = "ÇËäíä"
                Case 3 : GetDigit = "ËáÇËÉ"
                Case 4 : GetDigit = "ÇÑÈÚÉ"
                Case 5 : GetDigit = "ÎãÓÉ"
                Case 6 : GetDigit = "ÓÊÉ"
                Case 7 : GetDigit = "ÓÈÚÉ"
                Case 8 : GetDigit = "ËãÇäíÉ"
                Case 9 : GetDigit = "ÊÓÚÉ"
                Case Else : GetDigit = ""
            End Select
        End Function
    End Class
End Module
