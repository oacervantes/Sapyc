Public Class frmAutorizaOtroServicio

    Private sNameRpt As String = "Autoriza Otros Servicios"
    Private sEstatus As String

    Public idSac, sOficina, sDivision, sCliente, sServicio, sDescTrabajo, sCveUsr, sNombreSolicito, sMailSolicito As String
    Public idPropuesta As Integer
    Public dFechaAlta As Date
    Private dtCorreosSolicitud As DataTable
    Private sNombreEncargado, sCorreoEncargado As String

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
        EnvioCorreoAutorizacionServicio()

        MsgBox("Se autorizó la solicitud de servicio de manera correcta.", MsgBoxStyle.Information, "SAPYC")

        DialogResult = DialogResult.OK
    End Sub
    Private Sub BtnRechaza_Click(sender As Object, e As EventArgs) Handles btnRechaza.Click
        If txtRechazo.Text.Trim <> "" Then
            sEstatus = "C"

            ActualizaEstatusServiciosOtros()
            ActualizaDescRechazo()
            EnvioCorreoRechazoServicio()


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
    Private Sub EnvioCorreoRechazoServicio() 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            'Dim sCorreos = "Octavio.A.Cervantes@mx.gt.com; Mario.Rodriguez@mx.gt.com"
            Dim sCorreos = sMailSolicito
            Dim sCorreo As String() = sCorreos.Split(";")

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">RECHAZO DE PRESTACIÓN DE OTRO SERVICIO.</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado " & sNombreSolicito.TrimEnd(";") & ": </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Por medio del presente, le informo que el cliente prospecto " & txtCliente.Text.ToUpper.Trim() & ", de quien se solicitó el servico denominado ""OTROS"", ha sido rechazado, de acuerdo con el motivo listado a continuación:</p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Nombre del Prospecto:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtCliente.Text.ToString() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Motivo del rechazo:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtRechazo.Text.ToString() & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para cualquier aclaración sobre el tema, contactar a Tatiana.L.Lopez@mx.gt.com" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Rechazo de prestación de otro servicio.")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try

    End Sub
    Private Sub EnvioCorreoAutorizacionServicio()
        Dim sMensaje As String

        Try
            ' Dim sCorreos = "Octavio.A.Cervantes@mx.gt.com; Mario.Rodriguez@mx.gt.com"
            Dim sCorreos = sMailSolicito
            Dim sCorreo As String() = sCorreos.Split(";")

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">AUTORIZACIÓN DE PRESTACIÓN DE OTRO SERVICIO.</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado : " & sNombreSolicito.TrimEnd(";") & ", </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Por medio del presente, le informo que el cliente prospecto " & txtCliente.Text.ToUpper.Trim() & ", de quien se solicitó el servico denominado como ""OTROS"", ha sido autorizado, y puede continuar con la asignación de socio para este servicio.</p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Nombre del Prospecto:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtCliente.Text.ToString() & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para cualquier aclaración sobre el tema, contactar a Tatiana.L.Lopez@mx.gt.com" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Autorización de prestación de otro servicio.")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try

    End Sub

End Class