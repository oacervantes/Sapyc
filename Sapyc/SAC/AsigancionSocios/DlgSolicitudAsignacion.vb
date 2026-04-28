Public Class DlgSolicitudAsignacion

    Private ds As New DataSet()
    Private sNameRpt As String = "Selección de socios para asignar propuesta"

    Private dtSocios, dtCISocios As New DataTable
    Private tarjetaSeleccionada As TarjetaSocio2 = Nothing
    Private iPosY = 10, iValorY As Integer = 280

    Private sCveSocio, sNombreSocio, sCorreoSocio As String

    Public idSac, idPropuesta, idServicio, idIdioma, idMarco As Integer
    Public sCveOfi, sCvearea, sOficina, sArea, sNombreCte, sCveInd, sServicio, sSocioEncargado, sCorreoEncargado, sUsuario, sNombre, sCorreo As String

    Private Sub DlgSolicitudAsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProspecto.Text = $"{sNombreCte}"
        lblServicio.Text = $"{sServicio}"
        txtSocioEncargado.Text = $"{sSocioEncargado}"
        txtOficina.Text = $"{sOficina}"
        txtDivision.Text = $"{sArea}"
        txtIdSac.Text = $"{idSac}"

        If sCvearea = "AUD" Then
            ListarSociosAuditoria()
        Else
            ListarSociosOficinas()
        End If
        ListarCISocios()

        LlenarTarjetas()
    End Sub
    Private Sub BtnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        Dim dlg As New DlgDetalleSolicitud With {
            .idSac = idSac,
            .idPropuesta = idPropuesta
        }

        dlg.ShowDialog()
    End Sub
    Private Sub BtnEnviarAsignacion_Click(sender As Object, e As EventArgs) Handles btnEnviarAsignacion.Click
        If sCveSocio = "" Then
            MsgBox("No se ha seleccionado a uno socio(a) para su asignación.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            Exit Sub
        End If

        If MsgBox($"Se enviará una notificación a {sSocioEncargado} para autorizar la asignación del socio seleccionado en la propuesta {sNombreCte}. ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Settings.NOM_SYS) = MsgBoxResult.Yes Then
            EnviarAsignacion()
            EnviarCorreoAviso()
            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub BtnRechazarAsignacion_Click(sender As Object, e As EventArgs) Handles btnRechazarAsignacion.Click
        Dim dlg As New DlgRechazoPropuesta With {
            .idSac = idSac,
            .idPropuesta = idPropuesta
        }

        If dlg.ShowDialog() = DialogResult.OK Then
            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub LlenarTarjetas()
        panSocios.SuspendLayout()
        panSocios.Controls.Clear()

        For Each row As DataRow In dtSocios.Rows
            Dim card As New TarjetaSocio2() With {
                .SocioId = row("CVEEMP").ToString(),
                .Correo = row("CORREO").ToString(),
                .Nombre = row("NOMBRE").ToString(),
                .Idiomas = row("sIdioma").ToString(),
                .Servicio = row("sServicio").ToString(),
                .Industrias = row("sIndustria").ToString(),
                .CapacidadInstalada = CapacidadInstalada(row("CVEEMP").ToString()) & "%"
            }

            AddHandler card.CardClick, AddressOf OnSocioCardClick
            card.Location = New Point(10, iPosY)
            panSocios.Controls.Add(card)
            iPosY += iValorY + 10
        Next

        panSocios.ResumeLayout()
    End Sub
    Private Sub ListarSociosAuditoria()
        ' Aquí iría la lógica para listar los socios, por ejemplo, desde una base de datos
        ' Por ahora, se simula con datos estáticos en el método LlenarTarjetas()
        Try
            Dim sTabla As String = "tbSocios"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveArea", sCvearea, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idIdioma", idIdioma, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idServicio", idServicio, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idIndustria", sCveInd, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idMarcoNormativo", idMarco, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosInv.funExecuteSPDataTable("paSACAsignaciones", sTabla))

                dtSocios = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSocios = Nothing
        End Try
    End Sub
    Private Sub ListarSociosOficinas()
        ' Aquí iría la lógica para listar los socios, por ejemplo, desde una base de datos
        ' Por ahora, se simula con datos estáticos en el método LlenarTarjetas()
        Try
            Dim sTabla As String = "tbSocios"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveArea", sCvearea, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idIdioma", idIdioma, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idServicio", idServicio, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idIndustria", sCveInd, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosInv.funExecuteSPDataTable("paSACAsignaciones", sTabla))

                dtSocios = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSocios = Nothing
        End Try
    End Sub
    Private Sub ListarCISocios()
        ' Aquí iría la lógica para listar los socios, por ejemplo, desde una base de datos
        ' Por ahora, se simula con datos estáticos en el método LlenarTarjetas()
        Try
            Dim sTabla As String = "tbCISocios"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveArea", sCvearea, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosInv.funExecuteSPDataTable("paSACAsignaciones", sTabla))

                dtCISocios = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarCISocios()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtCISocios = Nothing
        End Try
    End Sub

    Private Sub EnviarAsignacion()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSac, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sStatus", "A", SqlDbType.Char, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACPropuestas")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EnviarAsignacion()")
            MsgBox("Por el momento no es posible , intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub EnviarCorreoAviso() 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            'sCorreos = "Octavio.A.Cervantes@mx.gt.com, Mario.Rodriguez@mx.gt.com"
            Dim sCorreo As String() = {"Octavio.A.Cervantes@mx.gt.com", "Mario.Rodriguez@mx.gt.com"}
            'Dim sCorreo As String() = {sMail}

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">AUTORIZACIÓN DE SOCIO ASIGNADO</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimada/o: " & sSocioEncargado & ", </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Queremos informarle que se ha sido asignado el socio para ofrecer el servicio solicitado por el prospecto para su autorización.</p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Socio asignado:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sNombreSocio & "</b></td></tr>" & vbNewLine &
            "<tr><td>Nombre del Prospecto:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sNombreCte & "</b></td></tr>" & vbNewLine &
            "<tr><td>Servicio solicitado:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sServicio & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Por favor, revise la información dentro de SIAT > SAPYC > SAC > Autorización de Asignaciones." & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Autorización de socio asignado")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub

    Private Sub OnSocioCardClick(tarjetaActual As TarjetaSocio2)

        ' Oculta la anterior
        If tarjetaSeleccionada IsNot Nothing AndAlso tarjetaSeleccionada IsNot tarjetaActual Then
            tarjetaSeleccionada.OcultarSeleccion()
        End If

        ' Muestra la actual
        tarjetaActual.MostrarSeleccion()

        ' Guarda referencia
        tarjetaSeleccionada = tarjetaActual

        sCveSocio = tarjetaActual.SocioId
        sNombreSocio = tarjetaActual.Nombre
        sCorreoSocio = tarjetaActual.Correo

    End Sub

    Private Function CapacidadInstalada(sCveSocio As String) As Decimal
        Dim filas() As DataRow = dtCISocios.Select($"CVEEMP = '{sCveSocio}'")

        If filas.Length > 0 Then
            Dim horas As Decimal = Convert.ToDecimal(filas(0)("TIEMPO"))
            Return Math.Round((700D - horas) / 700D, 2) * 100
        Else
            Return 0D
        End If

    End Function

End Class