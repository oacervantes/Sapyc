Public Class frmAutorizaNivelRiesgo

    Private sNameRpt As String = "Autoriza Nivel Riesgo"
    Private sEstatus As String

    Public idSac, sOficina, sDivision, sCliente, sServicio, sDescTrabajo, sCveUsr, sNombreSolicito, sMailSolicito As String
    Public idPropuesta As Integer
    Public dFechaAlta As Date



    Private dtCorreosSolicitud As DataTable
    Private sNombreEncargado, sCorreoEncargado, sNivelRiesgo As String


    Private Sub FrmAutorizaNivelRiesgo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIdSac.Text = idSac
        txtOficina.Text = sOficina
        txtDivision.Text = sDivision
        txtCliente.Text = sCliente
        txtServicio.Text = sDescTrabajo
    End Sub
    Private Sub BtnAutoriza_Click(sender As Object, e As EventArgs) Handles btnAutoriza.Click

        'If txtComentarios.Text = "" Then
        '    MsgBox("Debes escribir un comentario", MsgBoxStyle.Information, "SAPYC")
        '    Exit Sub
        'End If
        If rbMedio.Checked = False And rbBajo.Checked = False And rbAlto.Checked = False Then
            MsgBox("Debes seleccionar un nivel de riesgo", MsgBoxStyle.Information, "SAPYC")
            Exit Sub
        End If

        ActualizaNivelRiesgo()
        MsgBox("Se actualizo el nivel de riesgo de manera correcta", MsgBoxStyle.Information, "SAPYC")

        If rbAlto.Checked Then
            sNivelRiesgo = "ALTO"
        ElseIf rbMedio.Checked Then
            sNivelRiesgo = "MEDIO"
        ElseIf rbBajo.Checked Then
            sNivelRiesgo = "BAJO"
        End If

        ' EnvioCorreoNivelRiesgo()

        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnRechaza_Click(sender As Object, e As EventArgs) Handles btnRechaza.Click
        If txtComentarios.Text = "" Then
            MsgBox("Debes escribir un comentario", MsgBoxStyle.Information, "SAPYC")
            Exit Sub
        End If
        If rbMedio.Checked = False And rbBajo.Checked = False And rbAlto.Checked = False Then
            MsgBox("Debes seleccionar un nivel de riesgo", MsgBoxStyle.Information, "SAPYC")
            Exit Sub
        End If

        ActualizaNivelRiesgoCancela()
        MsgBox("Se actualizo el nivel de riesgo de manera correcta", MsgBoxStyle.Information, "SAPYC")

        If rbAlto.Checked Then
            sNivelRiesgo = "ALTO"
        ElseIf rbMedio.Checked Then
            sNivelRiesgo = "MEDIO"
        ElseIf rbBajo.Checked Then
            sNivelRiesgo = "BAJO"
        End If

        ' EnvioCorreoNivelRiesgo()

        DialogResult = DialogResult.OK
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub ActualizaNivelRiesgo()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSac, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)

                If rbBajo.Checked Then
                    .subAddParameter("@iNivelRiesgo", 1, SqlDbType.Int, ParameterDirection.Input)
                ElseIf rbMedio.Checked Then
                    .subAddParameter("@iNivelRiesgo", 2, SqlDbType.Int, ParameterDirection.Input)
                ElseIf rbAlto.Checked Then
                    .subAddParameter("@iNivelRiesgo", 3, SqlDbType.Int, ParameterDirection.Input)
                End If
                .subAddParameter("@sMotivoNivel", txtComentarios.Text, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACPropuestas")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizaNivelRiesgo()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub ActualizaNivelRiesgoCancela()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSac, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iNivelRiesgo", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sMotivoNivel", txtComentarios.Text, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACPropuestas")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizaNivelRiesgo()")
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
    Private Sub EnvioCorreoNivelRiesgo() 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            Dim sCorreos = "Octavio.A.Cervantes@mx.gt.com; Mario.Rodriguez@mx.gt.com"
            Dim sCorreo As String() = sCorreos.Split(";")

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">NOTIFICACIÓN EVALUACIÓN DE SERVICIO</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado : " & sNombreEncargado.TrimEnd(";") & ", </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Por medio del presente, le informo que el cliente prospecto " & txtCliente.Text.ToUpper.Trim() & ", ya fue revisado y se deberá continuar con los demás procesos establecidos por la Firma para concluir la aceptación del prospecto.</p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Nombre del Prospecto:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtCliente.Text.ToString() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Nivel de riesgo:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sNivelRiesgo.ToUpper.ToString() & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para cualquier aclaración sobre el tema contactar a Tatianal@mx.gt.com y yeritza@mx.gt.com" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Notificación de primer contacto con cliente prospecto")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try

    End Sub




End Class