
Imports PdfSharp.Fonts
Imports System.IO

Public Class ArialFontResolver
    Implements IFontResolver

    ' Rutas reales de las fuentes
    Private Const ArialRegular As String = "C:\Windows\Fonts\arial.ttf"
    Private Const ArialBold As String = "C:\Windows\Fonts\arialbd.ttf"
    Private Const ArialItalic As String = "C:\Windows\Fonts\ariali.ttf"
    Private Const ArialBoldItalic As String = "C:\Windows\Fonts\arialbi.ttf"

    ' 1️⃣ Devuelve los bytes de la fuente solicitada
    Public Function GetFont(faceName As String) As Byte() _
        Implements IFontResolver.GetFont

        Select Case faceName
            Case "Arial#Regular"
                Return File.ReadAllBytes(ArialRegular)

            Case "Arial#Bold"
                Return File.ReadAllBytes(ArialBold)

            Case "Arial#Italic"
                Return File.ReadAllBytes(ArialItalic)

            Case "Arial#BoldItalic"
                Return File.ReadAllBytes(ArialBoldItalic)
        End Select

        Return Nothing
    End Function


    ' 2️⃣ Traduce familia + estilo → nombre interno
    Public Function ResolveTypeface(
        familyName As String,
        isBold As Boolean,
        isItalic As Boolean
    ) As FontResolverInfo _
        Implements IFontResolver.ResolveTypeface

        If familyName.Equals("Arial", StringComparison.OrdinalIgnoreCase) Then

            If isBold AndAlso isItalic Then
                Return New FontResolverInfo("Arial#BoldItalic")

            ElseIf isBold Then
                Return New FontResolverInfo("Arial#Bold")

            ElseIf isItalic Then
                Return New FontResolverInfo("Arial#Italic")

            Else
                Return New FontResolverInfo("Arial#Regular")
            End If

        End If

        Return Nothing
    End Function

End Class
