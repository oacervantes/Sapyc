Public Class DlgSolicitudAsignacion

    Private ds As New DataSet()
    Private sNameRpt As String = "Selección de socios para asignar propuesta"

    Private dtSocios, dtCISocios, dtPptoSocios, dtSocioEnc As New DataTable
    Private tarjetaSeleccionada As TarjetaSocio2 = Nothing
    Private iPuntuacion = 0, iPosY = 10, iValorY As Integer = 340

    Private sCveSocio, sNombreSocio, sCorreoSocio As String
    Private sNombreSocioEnc, sCorreoSocioEnc, sCveOfiEnc, sCveAreaEnc As String
    Private dIngreso, dMeta, dRecurrente As Decimal

    Public idSac, idPropuesta, idServicio, idIdioma, idMarco As Integer
    Public sCveOfi, sCveArea, sOficinaEnc, sDivisionEnc, sNombreCte, sCveInd, sServicio, sCveSocioEnc, sSocioEncargado, sCorreoEncargado, sUsuario, sNombre, sCorreo As String

    Private Sub DlgSolicitudAsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProspecto.Text = $"{sNombreCte}"
        lblServicio.Text = $"{sServicio}"
        ' txtSocioEncargado.Text = $"{sSocioEncargado}"
        txtOficina.Text = $"{sOficinaEnc}"
        txtDivision.Text = $"{sDivisionEnc}"
        txtIdSac.Text = $"{idSac}"
        txtColaborador.Text = $"{sNombre}"

        If sCveArea = "AUD" Then
            ListarSociosAuditoria()
        Else
            ListarSociosOficinas()
        End If
        ListarCISocios()
        ListarPptoSocios()

        LlenarTarjetas()
    End Sub

    Private Sub BtnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        Dim dlg As New FrmContactoConsulta With {
            .idSAC = idSac,
            .idPropuesta = idPropuesta,
            .iConsulta = True,
            .sOficina = sOficinaEnc,
            .sDivision = sDivisionEnc,
            .idServicio = idServicio,
            .sServicio = sServicio,
            .sCveSocioEnc = sCveSocioEnc
        }

        dlg.ShowDialog()
    End Sub
    Private Sub BtnEnviarAsignacion_Click(sender As Object, e As EventArgs) Handles btnEnviarAsignacion.Click
        If sCveSocio = "" Then
            MsgBox("No se ha seleccionado a uno socio(a) para su asignación.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            Exit Sub
        End If

        Dim dlg As New DlgEnvioPropuesta With {
            .idSac = idSac,
            .sSocioEncargado = sSocioEncargado,
            .idPropuesta = idPropuesta
        }

        If iPuntuacion <> 4 Then
            If dlg.ShowDialog() = DialogResult.OK Then
                EnviarAsignacion()
                EnviarCorreoAviso()
                DialogResult = DialogResult.OK
            End If
        Else
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

            If row("iPuntuacion") = 4 Then
                Dim card As New TarjetaSocio2() With {
                    .SocioId = row("CVEEMP").ToString(),
                    .Correo = row("CORREO").ToString(),
                    .Nombre = row("NOMBRE").ToString(),
                    .CveOficina = row("sCveOfi").ToString(),
                    .CveDivision = row("sCveArea").ToString(),
                    .Puntuacion = row("iPuntuacion").ToString(),
                    .Oficina = row("OFICINA").ToString(),
                    .Division = row("DIVISION").ToString(),
                    .Idiomas = row("sIdioma").ToString(),
                    .Servicio = row("sServicio").ToString(),
                    .Industrias = row("sIndustria").ToString(),
                    .Marcos = row("sNormatividad").ToString(),
                    .Presupuesto = Presupuesto(row("CVEEMP").ToString()),
                    .Ingreso = dIngreso,
                    .Meta = dMeta,
                    .Recurrente = dRecurrente,
                    .CapacidadInstalada = CapacidadInstalada(row("CVEEMP").ToString())
                }

                AddHandler card.CardClick, AddressOf OnSocioCardClick
                card.Location = New Point(10, iPosY)
                panSocios.Controls.Add(card)
                iPosY += iValorY + 10
            End If

        Next

        Dim separador As New SeparadorSocio With {
            .Location = New Point(10, iPosY + 15)
        }
        panSocios.Controls.Add(separador)
        iPosY += 33 + 35

        For Each row As DataRow In dtSocios.Rows

            If row("iPuntuacion") <> 4 Then
                Dim card As New TarjetaSocio2() With {
                    .SocioId = row("CVEEMP").ToString(),
                    .Correo = row("CORREO").ToString(),
                    .Nombre = row("NOMBRE").ToString(),
                    .CveOficina = row("sCveOfi").ToString(),
                    .CveDivision = row("sCveArea").ToString(),
                    .Puntuacion = row("iPuntuacion").ToString(),
                    .Oficina = row("OFICINA").ToString(),
                    .Division = row("DIVISION").ToString(),
                    .Idiomas = row("sIdioma").ToString(),
                    .Servicio = row("sServicio").ToString(),
                    .Industrias = row("sIndustria").ToString(),
                    .Marcos = row("sNormatividad").ToString(),
                    .Presupuesto = Presupuesto(row("CVEEMP").ToString()),
                    .Ingreso = dIngreso,
                    .Meta = dMeta,
                    .Recurrente = dRecurrente,
                    .CapacidadInstalada = CapacidadInstalada(row("CVEEMP").ToString())
                }

                AddHandler card.CardClick, AddressOf OnSocioCardClick
                card.Location = New Point(10, iPosY)
                panSocios.Controls.Add(card)
                iPosY += iValorY + 10
            End If

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

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveArea", sCveArea, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idIdioma", idIdioma, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idServicio", idServicio, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idIndustria", sCveInd, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idMarcoNormativo", idMarco, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paSACAsignaciones", sTabla))

                dtSocios = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
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

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveArea", sCveArea, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idIdioma", idIdioma, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idServicio", idServicio, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idIndustria", sCveInd, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idMarcoNormativo", idMarco, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paSACAsignaciones", sTabla))

                dtSocios = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
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

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paSACAsignaciones", sTabla))

                dtCISocios = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarCISocios()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtCISocios = Nothing
        End Try
    End Sub
    Private Sub ListarPptoSocios()
        ' Aquí iría la lógica para listar los socios, por ejemplo, desde una base de datos
        ' Por ahora, se simula con datos estáticos en el método LlenarTarjetas()
        Try
            Dim sTabla As String = "tbPptoSocios"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paSACAsignaciones", sTabla))

                dtPptoSocios = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarCISocios()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtPptoSocios = Nothing
        End Try
    End Sub
    Private Sub ListarSocioEncargado(sCveOfi As String, sCveArea As String)
        ' Aquí iría la lógica para listar los socios, por ejemplo, desde una base de datos
        ' Por ahora, se simula con datos estáticos en el método LlenarTarjetas()
        Try
            Dim sTabla As String = "tbSocioEnc"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 15, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveArea", sCveArea, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paSolicitudesSAC", sTabla))

                dtSocioEnc = .Item(sTabla)
            End With

            If dtSocioEnc.Rows.Count > 0 Then
                sCveSocioEnc = dtSocioEnc.Rows(0)("CVEEMP").ToString()
                sNombreSocioEnc = dtSocioEnc.Rows(0)("NOMBRE").ToString()
                sCorreoSocioEnc = dtSocioEnc.Rows(0)("CORREOENC").ToString()
                txtSocioEncargado.Text = $"{sNombreSocioEnc}"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSocioEncargado()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtSocioEnc = Nothing
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
                .subAddParameter("@sCveSocio", sCveSocio, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveSocioEnc", sCveSocioEnc, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveOfi", sCveOfiEnc, SqlDbType.VarChar, ParameterDirection.Input)

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
            'Dim sCorreo As String() = {"Octavio.A.Cervantes@mx.gt.com", "Mario.Rodriguez@mx.gt.com"}
            Dim sCorreo As String() = {sCorreoSocioEnc}

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">VALIDACIÓN DE SOCIO ASIGNADO</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimada/o: " & sNombreSocioEnc & ", </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Queremos informarle que se ha sido asignado el socio para ofrecer el servicio solicitado por el prospecto para su validación.</p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Socio asignado:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sNombreSocio & "</b></td></tr>" & vbNewLine &
            "<tr><td>Nombre del Prospecto:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sNombreCte & "</b></td></tr>" & vbNewLine &
            "<tr><td>Servicio solicitado:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sServicio & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Por favor, revise la información dentro de SIAT > SAPYC > SAC > Validación de Asignaciones de Socio." & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Validación de socio asignado")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub

    Private Sub OnSocioCardClick(tarjetaActual As TarjetaSocio2)

        If CBool(tarjetaActual.txtValida.Text) = False Then
            If MsgBox("El socio seleccionado no cumple con todos los requerimientos solicitados por el Cliente Prospecto, ¿Desea elegirlo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Settings.NOM_SYS) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        ' Oculta la anterior
        If tarjetaSeleccionada IsNot Nothing AndAlso tarjetaSeleccionada IsNot tarjetaActual Then
            tarjetaSeleccionada.OcultarSeleccion()
        End If

        ' Muestra la actual
        tarjetaActual.MostrarSeleccion()

        ' Guarda referencia
        tarjetaSeleccionada = tarjetaActual

        ' Obtener los datos del socio seleccionado
        sCveSocio = tarjetaActual.SocioId
        sNombreSocio = tarjetaActual.Nombre
        sCorreoSocio = tarjetaActual.Correo
        iPuntuacion = tarjetaActual.Puntuacion
        sCveOfiEnc = tarjetaActual.CveOficina
        sCveAreaEnc = tarjetaActual.CveDivision
        sOficinaEnc = tarjetaActual.Oficina
        sDivisionEnc = tarjetaActual.Division

        ' Obtener los datos del socio encargado de la oficina y área del socio seleccionado.
        ListarSocioEncargado(tarjetaActual.CveOficina, tarjetaActual.CveDivision)

        panSocios.SuspendLayout()

        panSocios.Controls.SetChildIndex(tarjetaSeleccionada, panSocios.Controls.Count - 1)

        panSocios.ResumeLayout()

    End Sub

    Private Function CapacidadInstalada(sCveSocio As String) As Decimal
        Dim filas() As DataRow = dtCISocios.Select($"CVEEMP = '{sCveSocio}'")

        If filas.Length = 0 Then Return 0D

        Dim horas As Decimal = Convert.ToDecimal(filas(0)("TIEMPO"))
        Dim porcentaje As Decimal = Math.Round(horas / 700D, 2) * 100

        Return porcentaje
    End Function
    Private Function Presupuesto(sCveSocio As String) As Decimal
        Dim filas() As DataRow = dtPptoSocios.Select($"SOCIO = '{sCveSocio}'")

        If filas.Length = 0 Then Return 0D

        Dim porcentaje As Decimal = Convert.ToDecimal(filas(0)("PORCENTAJE_ACTIVOS"))
        dIngreso = Convert.ToDecimal(filas(0)("ARREGLADO"))
        dMeta = Convert.ToDecimal(filas(0)("META"))
        dRecurrente = Convert.ToDecimal(filas(0)("RECURRENTE"))

        Return porcentaje
    End Function


End Class