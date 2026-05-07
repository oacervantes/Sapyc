Public Class DlgRechazoPropuesta

    Private ds As New DataSet
    Private sNameRpt As String = "Detalle de Solicitud de Asignación"

    Private dtSolicitud As New DataTable

    Private sNombreSolicita, sCorreoSolicita As String

    Public idSac, idPropuesta As Integer

    Private Sub DlgRechazoPropuesta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarDatosSolicitud()
    End Sub
    Private Sub BtnGuadar_Click(sender As Object, e As EventArgs) Handles btnGuadar.Click
        If txtMotivoRechazo.Text.Trim() = "" Then
            MsgBox("Es necesario especificar el motivo del rechazo de la asignación.", MsgBoxStyle.Exclamation, "SAPYC")
            Exit Sub
        End If

        If MsgBox("¿Confirma que desea rechazar la asignación de esta propuesta?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SAPYC") = MsgBoxResult.Yes Then
            RechazarAsignacion()
            EnvioCorreoRechazoServicio()
            MsgBox("Se ha rechazado la asignación de la propuesta de manera correcta.", MsgBoxStyle.Information, "SAPYC")
            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub ListarDatosSolicitud()

        Try
            Dim sTabla As String = "tbSocios"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idSac", idSac, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paSolicitudesSAC", sTabla))

                dtSolicitud = .Item(sTabla)
            End With

            If dtSolicitud.Rows.Count > 0 Then
                txtIdSac.Text = idSac
                txtProspecto.Text = dtSolicitud.Rows(0).Item("sNombreCte").ToString()
                txtServicio.Text = dtSolicitud.Rows(0).Item("SERVICIO").ToString()
                sNombreSolicita = dtSolicitud.Rows(0).Item("sNombreUsuario").ToString()
                sCorreoSolicita = dtSolicitud.Rows(0).Item("sCorreoUsuario").ToString()
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSolicitud = Nothing
        End Try
    End Sub
    Private Sub RechazarAsignacion()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSac, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sStatus", "C", SqlDbType.Char, ParameterDirection.Input)
                .subAddParameter("@sMotivoRechazo", txtMotivoRechazo.Text, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACPropuestas")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "RechazarAsignacion()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub EnvioCorreoRechazoServicio() 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            Dim sCorreos = "Octavio.A.Cervantes@mx.gt.com; Mario.Rodriguez@mx.gt.com"
            'Dim sCorreos = sMailSolicito
            Dim sCorreo As String() = sCorreos.Split(";")

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">RECHAZO DE PRESTACIÓN DE SERVICIO.</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado " & sNombreSolicita.TrimEnd(";") & ": </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Por medio del presente, le informo que el cliente prospecto " & txtProspecto.Text.ToUpper.Trim() & ", de quien se solicitó el servicio " & txtServicio.Text & ", ha sido rechazado, de acuerdo con el motivo listado a continuación:</p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Nombre del Prospecto:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtProspecto.Text.ToString() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Motivo del rechazo:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtMotivoRechazo.Text.ToString() & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para cualquier aclaración sobre el tema, contactar a Tatiana.L.Lopez@mx.gt.com" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Rechazo de prestación de servicio.")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try

    End Sub

End Class