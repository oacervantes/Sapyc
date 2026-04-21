Public Class frmAutorizaOtroServicio

    Private sNameRpt As String = "Autoriza Otros Servicios"
    Private sEstatus As String

    Public idSac, sOficina, sDivision, sCliente, sServicio, sDescTrabajo As String
    Public idPropuesta As Integer
    Public dFechaAlta As Date

    Private Sub FrmAutorizaOtroServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIdSac.Text = idSac
        txtOficina.Text = sOficina
        txtDivision.Text = sDivision
        txtCliente.Text = sCliente
        txtServicio.Text = "OTROS"
        txtDescripcionTrabajo.Text = sDescTrabajo
    End Sub
    Private Sub BtnAutoriza_Click(sender As Object, e As EventArgs) Handles btnAutoriza.Click
        sEstatus = "S"
        ActualizaEstatusServiciosOtros()
        MsgBox("Se autorizó la solicitud de servicio de manera correcta.", MsgBoxStyle.Information, "SAPYC")

        DialogResult = DialogResult.OK
    End Sub
    Private Sub BtnRechaza_Click(sender As Object, e As EventArgs) Handles btnRechaza.Click
        If txtRechazo.Text.Trim <> "" Then
            sEstatus = "C"

            ActualizaEstatusServiciosOtros()
            ActualizaDescRechazo()
            MsgBox("Se rechazó la solicitud de servicio de manera correcta.", MsgBoxStyle.Information, "SAPYC")

            DialogResult = DialogResult.OK
        Else
            MsgBox("Indique el motivo del rechazo de la solicitud.", MsgBoxStyle.Exclamation, "SAPYC")
        End If
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub ActualizaEstatusServiciosOtros()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSac, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@cStatus", sEstatus, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paSolicitudesSAC")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizaEstatusServiciosOtros()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub ActualizaDescRechazo()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSac, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sRechazo", txtRechazo.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paSolicitudesSAC")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizaEstatusServiciosOtros()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub ListarCorreoSolicitante(sStatus As String)

    End Sub

    Private Sub EnviarCorreo()

    End Sub

End Class