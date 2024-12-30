Public Class dlgIncompletos

    Public sCliente, sCorreoSoc, sCorreoGnt, sNombeSoc, sNombGen, CorreosSoc As String
    Public idProp As Integer


    Private Sub dlgIncompletos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If MsgBox("¿Desea rechazar la propuesta por datos incompletos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SAPYC") = MsgBoxResult.Yes Then
            If txtMotivo.Text = "" Then
                MsgBox("Debes indicar un motivo de rechazo por datos incompletos")
                Exit Sub
            Else
                EnviarCorreoRechazo()
                ActualizaPropuesta()
                MsgBox("Actualizacion enviada con éxito")
                DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        End If

    End Sub
    Private Sub ActualizaPropuesta()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 54, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPropuesta", idProp, SqlDbType.Int, ParameterDirection.Input)

                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub EnviarCorreoRechazo() 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            CorreosSoc = "Mario.Rodriguez@mx.gt.com" + ";"
            If sCorreoGnt <> "" Then
                CorreosSoc += sCorreoGnt + ";"
            End If
            If sCorreoSoc <> "" Then
                CorreosSoc += sCorreoSoc + ";"
            End If

            CorreosSoc = CorreosSoc.TrimEnd(";")
            Dim sCorreo As String() = CorreosSoc.Split(";")


            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">Rechazo propuesta, datos incompletos</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado Equipo: " & sNombeSoc & " , " & sNombGen & ", </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Por medio del presente se informa que su solicitud debera ser completada CON LA INFORMACION INDICADA EN EL MOTIVO DEL RECHAZO Y DEBERAN ENVIAR NUEVAMENTE LA SOLICTUD A REVISION UNA VEZ COMPLETADOS.</p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sCliente.ToUpper() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Motivo de rechazo:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtMotivo.Text.ToUpper() & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para cualquier aclaración sobre el tema contactar a cecilia.coronel@mx.gt.com y gabriela.feliciano@mx.gt.com" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Rechazo propuestas, datos incompletos")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub



End Class