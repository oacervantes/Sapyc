Public Class frmDetalleAutorizaSolicitudFolio

    Public sCvetra, sCliente, sSocioSol, sMotivoSolicitud, sMail, sNombreSol As String
    Public dImpest, dImpcob, dImppc As Decimal
    Private sNameRpt As String = "Autoriza folio de informe"

    Private Sub frmDetalleAutorizaSolicitudFolio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblCliente.Text = sCliente
        lblTrabajo.Text = sCvetra
        txtObservaciones.Text = sMotivoSolicitud

        lblUno.Text = Format(dImpest, sFmtDbl)
        lblDos.Text = Format(dImpcob, sFmtDbl)
        lblTres.Text = Format(dImppc, sFmtDbl)
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub btnAutoriza_Click(sender As Object, e As EventArgs) Handles btnAutoriza.Click
        If txtMotivo.Text = "" Then
            MsgBox("Debe especificar el motivo de autorización.", MsgBoxStyle.Exclamation, "SIAT")
            Exit Sub
        End If

        If MsgBox("¿Desea autorizar la solicitud de folio de informe seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
            AutorizaSolicitudFolio("A")
            MsgBox("Folio Actualizado correctamente.", MsgBoxStyle.Exclamation, "SIAT")
            EnviarCorreoAviso(sMail, sNombreSol, "AUTORIZACIÓN", lblCliente.Text.ToUpper())
            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        If txtMotivo.Text = "" Then
            MsgBox("Debe especificar el motivo de rechazo.", MsgBoxStyle.Exclamation, "SIAT")
            Exit Sub
        End If

        If MsgBox("¿Desea rechazar la solicitud de folio de informe seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
            AutorizaSolicitudFolio("R")
            MsgBox("Folio Actualizado correctamente.", MsgBoxStyle.Exclamation, "SIAT")
            EnviarCorreoAviso(sMail, sNombreSol, "RECHAZO", lblCliente.Text.ToUpper())
            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub AutorizaSolicitudFolio(cStatus As String)
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveSocioAut", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveTra", sCvetra, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sMotivo", txtMotivo.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@cStatus", cStatus, SqlDbType.Char, ParameterDirection.Input, 1)

                .funExecuteSP("paFoliosInforme")
            End With

            MsgBox("Se actualizó la solicitud correctamente.", MsgBoxStyle.Information, "SIAT")

        Catch ex As Exception
            ' insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "GenerarFolioInforme()")
            MsgBox("Hubo un inconveniente al registrar la información del folio de informe, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub EnvioCorreoAutorizacion(Correo As String, NombSocio As String, Autorizacion As String, Cliente As String)
        Dim sMensaje As String
        Dim sCorreo As String() = {Correo, "mario.rodriguez@mx.gt.com"}
        Try
            ' sCorreos = sCorreoUsuario & "," & "Mario.Rodriguez@mx.gt.com" & "," & Correo
            sMensaje = "Estimad@ " & NombSocio & " " & vbNewLine & vbNewLine
            sMensaje &= "El Folio de informe del cliente " & Cliente & " ha sido " & Autorizacion & "; Favor de ir al SIAT para continuar con su proceso." & vbNewLine & vbNewLine

            ' enviarCorreoCopia(sCorreo, "mario.rodriguez@mx.gt.com", sMensaje, "Folios de informe")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub EnviarCorreoAviso(Correo As String, NombSocio As String, Autorizacion As String, Cliente As String) 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            'sCorreos = "Octavio.A.Cervantes@mx.gt.com, Mario.Rodriguez@mx.gt.com"
            Dim sCorreo As String() = {Correo, "mario.rodriguez@mx.gt.com"}

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">AUTORIZACIÓN FOLIO DE INFORME</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado(a) " & NombSocio & ",</p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">El presente correo es para informarte que se ha generado una respuesta a la solicitud de la creación del folio de informe: </p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Tipo Autorización:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Autorizacion & "</b></td></tr>" & vbNewLine &
            "<tr><td>Cliente:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Cliente & "</b></td></tr>" & vbNewLine &
            "<tr><td>Motivo de autorización o rechazo:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtMotivo.Text & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para revisar y validar esta solicitud, ingresa al sistema SIAT, menú SAPYC > Folios de Informe." & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Solicitud de Autorización para Folio de Informe")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub

End Class