
Imports PdfSharp.Fonts
Imports System.IO

Public Class CalibriFontResolver
    Implements IFontResolver

    Private Const Regular As String = "C:\Windows\Fonts\calibri.ttf"
    Private Const Bold As String = "C:\Windows\Fonts\calibrib.ttf"
    Private Const Italic As String = "C:\Windows\Fonts\calibrii.ttf"
    Private Const BoldItalic As String = "C:\Windows\Fonts\calibriz.ttf"

    Public Function GetFont(faceName As String) As Byte() _
        Implements IFontResolver.GetFont

        Select Case faceName
            Case "Calibri#Regular"
                Return File.ReadAllBytes(Regular)

            Case "Calibri#Bold"
                Return File.ReadAllBytes(Bold)

            Case "Calibri#Italic"
                Return File.ReadAllBytes(Italic)

            Case "Calibri#BoldItalic"
                Return File.ReadAllBytes(BoldItalic)
        End Select

        Return Nothing
    End Function

    Public Function ResolveTypeface(
        familyName As String,
        isBold As Boolean,
        isItalic As Boolean
    ) As FontResolverInfo _
        Implements IFontResolver.ResolveTypeface

        If familyName.Equals("Calibri", StringComparison.OrdinalIgnoreCase) Then

            If isBold AndAlso isItalic Then
                Return New FontResolverInfo("Calibri#BoldItalic")

            ElseIf isBold Then
                Return New FontResolverInfo("Calibri#Bold")

            ElseIf isItalic Then
                Return New FontResolverInfo("Calibri#Italic")

            Else
                Return New FontResolverInfo("Calibri#Regular")
            End If

        End If

        Return Nothing
    End Function

End Class