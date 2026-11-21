Imports System.Security.Cryptography

Public Class dlgClienteGRD
    Public sCveCte, sNombreCte, sCveGRD As String

    Private Sub dlgClienteGRD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txCveCte.Text = sCveCte
        txtNombCte.Text = sNombreCte
        txtCveGRD.Text = sCveGRD
    End Sub
    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If txtCveGRD.Text = "" Then
            MsgBox("Debe indicar una clave de cliente GRD.", MsgBoxStyle.Exclamation, "SAPYC")
            Exit Sub
        End If

        If MsgBox("Al realizar esta acción guardara la clave GRD, ¿desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            InsertarCveGRDCliente()
            DialogResult = DialogResult.OK

        End If


    End Sub
    Private Sub InsertarCveGRDCliente()
        Try
            With clsDatosInv
                .subClearParameters()
                .subAddParameter("@iOpcion", 42, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveCte", txCveCte.Text.Trim.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveGRD", txtCveGRD.Text.Trim.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paClientes")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, "InsertarCveGRDCliente", ex.Message, sCveUsuario, "InsertarCveGRDCliente()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub


End Class