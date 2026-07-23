Public Class DlgEnvioPropuesta

    Private ds As New DataSet

    Private sNameRpt As String = "Detalle de Solicitud de Asignación"
    Private dtSolicitud, dtCorreosSolicitud As New DataTable

    Private sNombreSolicita, sCorreoSolicita, sCorreoSolicito As String

    Public idSac, idPropuesta As Integer
    Public sCveSocio, sNombreSocio, sCorreoSocio, sSocioEncargado As String

    Private Sub DlgEnvioPropuesta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarCorreosSolicitud()
        ListarDatosSolicitud()
    End Sub

    Private Sub BtnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If txtMotivo.Text.Trim() = "" Then
            MsgBox("Es necesario especificar el motivo de la asignación.", MsgBoxStyle.Exclamation, "SAPYC")
            Exit Sub
        End If

        If MsgBox($"Se enviará una notificación a {sSocioEncargado} para validar la asignación del socio seleccionado en la propuesta {txtProspecto.Text}. ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Settings.NOM_SYS) = MsgBoxResult.Yes Then

            If chkAvisoKardex.Checked Then
                Dim Dr() As DataRow
                If dtCorreosSolicitud.Rows.Count > 0 Then
                    Dr = dtCorreosSolicitud.Select("sCvepersona = 'GD'")
                    sCorreoSolicito &= "; " & Dr(0).Item("sCorreoPersona").ToString()

                    Dr = dtCorreosSolicitud.Select("sCvepersona = 'GR'")
                    sCorreoSolicito &= "; " & Dr(0).Item("sCorreoPersona").ToString()

                    EnvioCorreoAvisoKardex()
                Else
                    MsgBox("Por el momento no es posible enviar el correo de notificación de reasignación de socio.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
                End If
            End If

            InsertaMotivoAsignacion()
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
    Private Sub InsertaMotivoAsignacion()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 12, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSac, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sStatus", "C", SqlDbType.Char, ParameterDirection.Input)
                .subAddParameter("@sMotivoAsignacion", txtMotivo.Text, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACPropuestas")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "RechazarAsignacion()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub ListarCorreosSolicitud()
        Try
            Dim sTabla As String = "tbCorreosEncargados"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable("paCorreosSAC", sTabla))
                dtCorreosSolicitud = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarCorreosSolicitud()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtCorreosSolicitud = Nothing
        End Try
    End Sub

    Private Sub EnvioCorreoAvisoKardex()
        Dim sMensaje As String

        Try
            'Dim sCorreos = "Octavio.A.Cervantes@mx.gt.com; Mario.Rodriguez@mx.gt.com"
            Dim sCorreos = sCorreoSocio
            Dim sCorreo As String() = sCorreos.Split(";")
            Dim sCorreoCopia As String() = sCorreoSolicito.Split(";")

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">NOTIFICACIÓN PARA COMPLETAR KARDEX</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado " & sNombreSocio.ToUpper() & ", </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Por medio del presente, se le informa que su kardex se encuentra incompleto, por lo que le solicitamos completarlo a la brevedad. </p> " & vbNewLine & vbNewLine &
            "<p style=""margin-left: 25px; font-family: Arial; font-size: 16px;"">Para realizar este proceso, favor de ingresar  SIAT, menú SAPYC > SAC > Kardex." & vbNewLine &
            "<p style=""margin-left: 25px; font-family: Arial; font-size: 16px;"">Para cualquier comentario sobre el tema, favor de contactar a Tatiana.L.Lopez@mx.gt.com" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Notificación para completar Kardex")

        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub

End Class