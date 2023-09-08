Imports System.Windows.Forms
Imports System.IO

Public Class dlgExcel

#Region "AUTOR"

    'AUTOR: OCTAVIO CERVANTES
    'FECHA: 19 - MARZO - 2014

#End Region

#Region "VARIABLES"

    Private sRuta As String


#End Region

#Region "EVENTOS"

    Private Sub dlgExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dlgCarpeta.SelectedPath = sFolderExcel
        Me.txtDirectorio.Text = sFolderExcel

        Me.txtArchivo.Focus()
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        sRuta = Me.txtDirectorio.Text & Me.txtArchivo.Text & ".xlsx"

        If Me.txtArchivo.TextLength > 0 Then
            If Not Directory.Exists(sFolderUserPrincipal) Then
                Directory.CreateDirectory(sFolderUserPrincipal)
            End If

            If Not Directory.Exists(sFolderExcel) Then
                Directory.CreateDirectory(sFolderExcel)
            End If

            If File.Exists(sRuta) Then
                If MsgBox("Ya existe un archivo con el mismo nombre, ¿desea reemplazar el archivo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Archivo existente") = MsgBoxResult.Yes Then
                    File.Delete(sRuta)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Escriba un nombre diferente para poder exportar la información a Excel.", MsgBoxStyle.Information, "Cambiar nombre")
                    Exit Sub
                End If
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Else
            MsgBox("Escriba el nombre con el que se guardará el archivo.", MsgBoxStyle.Exclamation, "Nombrar Archivo")
        End If
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub btnCarpeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCarpeta.Click
        If dlgCarpeta.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtDirectorio.Text = dlgCarpeta.SelectedPath & "\"
        End If
    End Sub

#End Region

End Class