Imports PdfSharp.Fonts
Imports System.IO

Public Class FontsResolver
    Implements IFontResolver

    ' =========================
    ' === ARIAL ===============
    ' =========================
    Private Const ArialRegular = "C:\Windows\Fonts\arial.ttf"
    Private Const ArialBold = "C:\Windows\Fonts\arialbd.ttf"
    Private Const ArialItalic = "C:\Windows\Fonts\ariali.ttf"
    Private Const ArialBoldItalic = "C:\Windows\Fonts\arialbi.ttf"

    ' =========================
    ' === CALIBRI =============
    ' =========================
    Private Const CalibriRegular = "C:\Windows\Fonts\calibri.ttf"
    Private Const CalibriBold = "C:\Windows\Fonts\calibrib.ttf"
    Private Const CalibriItalic = "C:\Windows\Fonts\calibrii.ttf"
    Private Const CalibriBoldItalic = "C:\Windows\Fonts\calibriz.ttf"

    ' =========================
    ' === VERDANA =============
    ' =========================
    Private Const VerdanaRegular = "C:\Windows\Fonts\verdana.ttf"
    Private Const VerdanaBold = "C:\Windows\Fonts\verdanab.ttf"
    Private Const VerdanaItalic = "C:\Windows\Fonts\verdanai.ttf"
    Private Const VerdanaBoldItalic = "C:\Windows\Fonts\verdanaz.ttf"

    ' ==========================================================
    ' 1️⃣ Devuelve los bytes del archivo TTF correspondiente
    ' ==========================================================
    Public Function GetFont(faceName As String) As Byte() _
        Implements IFontResolver.GetFont

        Select Case faceName

            ' --- Arial ---
            Case "Arial#Regular" : Return File.ReadAllBytes(ArialRegular)
            Case "Arial#Bold" : Return File.ReadAllBytes(ArialBold)
            Case "Arial#Italic" : Return File.ReadAllBytes(ArialItalic)
            Case "Arial#BoldItalic" : Return File.ReadAllBytes(ArialBoldItalic)

            ' --- Calibri ---
            Case "Calibri#Regular" : Return File.ReadAllBytes(CalibriRegular)
            Case "Calibri#Bold" : Return File.ReadAllBytes(CalibriBold)
            Case "Calibri#Italic" : Return File.ReadAllBytes(CalibriItalic)
            Case "Calibri#BoldItalic" : Return File.ReadAllBytes(CalibriBoldItalic)

            ' --- Verdana ---
            Case "Verdana#Regular" : Return File.ReadAllBytes(VerdanaRegular)
            Case "Verdana#Bold" : Return File.ReadAllBytes(VerdanaBold)
            Case "Verdana#Italic" : Return File.ReadAllBytes(VerdanaItalic)
            Case "Verdana#BoldItalic" : Return File.ReadAllBytes(VerdanaBoldItalic)

        End Select

        Return Nothing
    End Function

    ' ==========================================================
    ' 2️⃣ Mapea familia + estilo al nombre interno
    ' ==========================================================
    Public Function ResolveTypeface(
        familyName As String,
        isBold As Boolean,
        isItalic As Boolean
    ) As FontResolverInfo _
        Implements IFontResolver.ResolveTypeface

        Select Case familyName.ToLowerInvariant()

            Case "arial"
                Return ResolverEstilo("Arial", isBold, isItalic)

            Case "calibri"
                Return ResolverEstilo("Calibri", isBold, isItalic)

            Case "verdana"
                Return ResolverEstilo("Verdana", isBold, isItalic)

        End Select

        Return Nothing
    End Function

    ' ==========================================================
    ' Helper común para Regular / Bold / Italic / BoldItalic
    ' ==========================================================
    Private Function ResolverEstilo(
        nombre As String,
        isBold As Boolean,
        isItalic As Boolean
    ) As FontResolverInfo

        If isBold AndAlso isItalic Then
            Return New FontResolverInfo($"{nombre}#BoldItalic")
        ElseIf isBold Then
            Return New FontResolverInfo($"{nombre}#Bold")
        ElseIf isItalic Then
            Return New FontResolverInfo($"{nombre}#Italic")
        Else
            Return New FontResolverInfo($"{nombre}#Regular")
        End If

    End Function

End Class