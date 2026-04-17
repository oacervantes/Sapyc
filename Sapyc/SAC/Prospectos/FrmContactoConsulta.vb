Public Class FrmContactoConsulta

    Private ds As New DataSet
    Private bsPro, bsFun, bsAcc, bsCli, bsSer As New BindingSource

    Private sNameRpt As String = "Alta de Prospecto"

    Private Const DATOS_GENERALES As String = "DATOS GENERALES"
    Private Const CONTACTO_INICIAL As String = "CONTACTO INICIAL"
    Private Const ACERCAMIENTO As String = "ACERCAMIENTO"
    Private Const DOMICILIO As String = "DOMICILIO"

    Private dtCvesProspectos, dtProspectos, dtRfc, dtIdSac, dtServicios As New DataTable
    Private dtDatosGenerales, dtServiciosDG As New DataTable
    Private dtContactoInicial As New DataTable
    Private dtComoSeEntero, dtMedioContacto, dtAcercamiento As New DataTable
    Private dtDomicilio, dtPaisDomicilio, dtColoniasDomicilio, dtMunicipiosDomicilio, dtEstadosDomicilio, dtEstatusProp As New DataTable
    Private dtDatGrals, dtBolsaValores, dtEntidadReg, dtNormatividad, dtPais, dtPaisGT, dtPaisResidencia, dtTipoEntidad, dtModalidades, dtIdiomas, dtOficinas, dtDivisiones, dtSocios, dtOfGt As DataTable
    Private dtIndustria, dtSubSector, dtSubNivel As DataTable

    Private drServicios As DataRow

    Private sInd, sSS, sGTI As String
    Private iOpcionFun, iOpcionAcc, idIdioma, idPais, idPaisTenedora, idPaisGT, idPaisDom As Integer
    Private sCveInd, sCveSS, sCveGTI, sPaisDom, sNombreCliente, sMsgContacto As String

    Private bOtros = False, bRefGTI = False, bCargaInfo As Boolean = False
    Private sCorreos(), sCuentaCorreo As String

    Public sCveOfi, sCveArea, sServicio, sNombreSocio, sCveSocio As String
    Public iOrigen, iModifica, idSAC, idServicio, idPropuesta As Integer

    Private Sub FrmContactoConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        panDatosGenerales.Visible = True
        txtClaveProspecto.Text &= idSAC

        BindGrid(gridServicios, bsSer)

        TipoConsultaPantalla(iOrigen)

        CrearTablas()
        '============================== ACERCAMIENTO ==============================
        ListarComoSeEnteroAcerca()
        If dtComoSeEntero Is Nothing Then Exit Sub

        ListarMedioContactoAcerca()
        If dtMedioContacto Is Nothing Then Exit Sub

        ListarAcercamiento()
        If dtAcercamiento Is Nothing Then Exit Sub

        '============================== DOMICILIO ==============================
        ListarEstadosDomicilio()
        If dtEstadosDomicilio Is Nothing Then Exit Sub

        ListarDomicilio()
        If dtDomicilio Is Nothing Then Exit Sub
        '============================== DATOS GENERALES ==============================

        ListarBolsaValores()
        ListarEntidad()
        ListarNormatividad()
        ListarPaisGT()
        ListarPaisResidencia()
        ListarTipoEntidad()
        ListarModalidades()
        ListarServiciosDatosGenerales()

        ListarDatosGenerales()

        ListarIndustrias()
        ListarSubSector()
        ListarSubNivel()

        '============================== CONSULTA DATOS ==============================
        ListarContactoInicial()

        ListarEstatusPropuestas()

    End Sub
    Private Sub BtnAutorizar_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub BtnRechazar_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = DialogResult.OK
    End Sub

    Private Sub LnkSecciones(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDatosGenerales.LinkClicked, lnkContactoInicial.LinkClicked, lnkAcercamiento.LinkClicked, lnkDireccion.LinkClicked
        For Each obj As Object In Controls
            If obj.GetType.Name = "Panel" Then
                If DirectCast(obj, Panel).Name = "panMenu" Then
                    Continue For
                Else
                    DirectCast(obj, Panel).Visible = False
                End If

            End If
        Next

        Select Case CInt(DirectCast(sender, LinkLabel).Tag)
            Case 1
                panDatosGenerales.Visible = True

            Case 2
                panContactoInicial.Visible = True

            Case 3
                panAcercamiento.Visible = True

            Case 4
                panDireccion.Visible = True

        End Select
    End Sub

    Private Sub CrearTablas()
        dtServicios.Columns.Add("CVE", GetType(Integer))
        dtServicios.Columns.Add("DESCRIPCION", GetType(String))
    End Sub

    Private Sub ListarIndustrias()
        Try
            Dim sTabla As String = "tbProspectos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sInd", sInd, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtIndustria = .Item(sTabla)
            End With

            If dtIndustria.Rows.Count > 0 Then
                txtIndustria.Text = dtIndustria.Rows(0).Item("sIndustria")
            Else
                txtIndustria.Text = ""
            End If

        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub
    Private Sub ListarSubSector()
        Try
            Dim sTabla As String = "tbProspectos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 17, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sSubSec", sCveSS, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtSubSector = .Item(sTabla)
            End With

            If dtSubSector.Rows.Count > 0 Then
                txtSubsector.Text = dtSubSector.Rows(0).Item("sSubsector")
            Else
                txtSubsector.Text = ""
            End If

        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub
    Private Sub ListarSubNivel()
        Try
            Dim sTabla As String = "tbProspectos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 18, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sSubSec", sCveSS, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtSubNivel = .Item(sTabla)
            End With

            If dtSubNivel.Rows.Count > 0 Then
                txtSubnivel.Text = dtSubNivel.Rows(0).Item("sSubnivel")
            Else
                txtSubnivel.Text = ""
            End If

        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub

    Private Sub AutorizarSolicitudSAC(idSAC As Integer, idPropuesta As Integer, sCveSocio As String)
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 12, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveSocio", sCveSocio, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@cStatus", "T", SqlDbType.Char, ParameterDirection.Input)

                .funExecuteSP("paSolicitudesSAC")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "AutorizarSolicitudSAC()")
            MsgBox("Hubo un problema al registrar la información del prospecto, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub RechazarSolicitudSAC(idSAC As Integer, idPropuesta As Integer, sMotivoRechazo As String)
        Try
            Dim sMensajeRechazo As String = "SOCIO PREVIO: " & sNombreSocio & vbNewLine & vbNewLine & sMotivoRechazo

            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 11, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sRechazo", sMensajeRechazo, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@cStatus", "D", SqlDbType.Char, ParameterDirection.Input)

                .funExecuteSP("paSolicitudesSAC")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "AutorizarSolicitudSAC()")
            MsgBox("Hubo un problema al registrar la información del prospecto, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub

    Private Sub EnviarCorreoAviso() 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            'Dim sCorreo As String() = sCorreos
            Dim sCorreo As String() = {"mario.rodriguez@mx.gt.com", "octavio.a.cervantes@mx.gt.com"}

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">SOLICITUD DE CLIENTE PROSPECTO PARA ASIGNACIÓN</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado equipo</p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">El presente correo es para informarte que se ha generado una solicitud de asignación de cliente prospecto: </p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente prospecto:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sNombreCliente & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para revisar y validar esta solicitud, ingresa al sistema SAPYC > Clientes Prospectos" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Solicitud de Asignación Cliente Prospecto")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub ConsultaEnviaCorreos()
        Try
            With ds.Tables
                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paSSGTPropuestasProspectos") Then
                    .Remove("paSSGTPropuestasProspectos")
                End If

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasProspectos"))

                dtCorreos = .Item("paSSGTPropuestasProspectos")

                If dtCorreos.Rows.Count > 0 Then
                    For Each dr As DataRow In dtCorreos.Rows
                        If Not IsDBNull(dr("sUsuario")) Then
                            sCuentaCorreo += dr("sUsuario").ToString & ","
                        End If
                    Next
                    sCuentaCorreo = sCuentaCorreo.TrimEnd(",")
                    sCorreos = sCuentaCorreo.Split(",")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub TipoConsultaPantalla(iOrigen As Integer)
        Select Case iOrigen
            Case 2 'Consulta para especificar fecha de presentación de Propuesta, Status de la Propuesta y honorarios de la Propuesta.
                lblTituloSocios.Text = "Seguimiento de propuesta"
                gpBoxSeguimiento.Visible = True
        End Select
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If ValidarSeguimiento() Then
                InsertarSeguimiento()
                MsgBox("Se actualizo el seguimiento a la propuesta de manera correcta", MsgBoxStyle.Information, "SAPYC")
                DialogResult = DialogResult.OK
            End If


        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSeguimiento()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Function ValidarSeguimiento() As Boolean
        Dim bValidacion As Boolean = True

        sMsgContacto = vbNewLine & CONTACTO_INICIAL & vbNewLine
        sMsgContacto &= "===============================" & vbNewLine

        If rdSiPresentacion.Checked = True And rdNoPresentacion.Checked = True Then
            sMsgContacto &= "- Debes elegir si presento una propuesta de servicio." & vbNewLine & vbNewLine

            bValidacion = False
        End If

        If Trim(txtHonorariosPropuesta.Text) = "" Then
            sMsgContacto &= "- Debes indicar un importe de honorarios." & vbNewLine & vbNewLine

            bValidacion = False
        End If

        If cboStatusPropuesta.SelectedValue = 0 Or cboStatusPropuesta.SelectedValue < 0 Then
            sMsgContacto &= "- Debes indicar un estatus de propuesta." & vbNewLine & vbNewLine

            bValidacion = False
        End If

        sMsgContacto = sMsgContacto.Remove(sMsgContacto.Length - vbNewLine.Length * 2)
        sMsgContacto &= vbNewLine & "===============================" & vbNewLine

        Return bValidacion
    End Function
    Private Sub InsertarSeguimiento()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@dHonorarios", txtHonorariosPropuesta.Text, SqlDbType.VarChar, ParameterDirection.Input)

                If rdSiPresentacion.Checked = True Then
                    .subAddParameter("@bPresento", 1, SqlDbType.Bit, ParameterDirection.Input)
                ElseIf rdNoPresentacion.Checked = True Then
                    .subAddParameter("@bPresento", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If
                .subAddParameter("@iEstatus", cboStatusPropuesta.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@dFechaPorpuesta", txtRegistroFechaPropuesta.Value, SqlDbType.DateTime, ParameterDirection.Input)


                .funExecuteSP("paDatosAsignacionSACPropuestas")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarDomicilio()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub

    Private Sub ListarEstatusPropuestas()
        Try
            Dim sTabla As String = "tbProspectos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACPropuestas", sTabla))

                dtEstatusProp = .Item(sTabla)
            End With

            If dtEstatusProp.Rows.Count > 0 Then
                cboStatusPropuesta.DataSource = dtEstatusProp

                cboStatusPropuesta.ValueMember = "CVE"
                cboStatusPropuesta.DisplayMember = "DESCRIPCION"
            End If

        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub
#Region "DATOS GENERALES"

    Private Sub ListarBolsaValores()
        Try
            Dim sTabla As String = "tbBolsaValores"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtBolsaValores = .Item(sTabla)
            End With

            If dtBolsaValores.Rows.Count > 0 Then
                cboBolsaValores.DataSource = dtBolsaValores

                cboBolsaValores.ValueMember = "idBolsaValores"
                cboBolsaValores.DisplayMember = "sBolsaValores"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarBolsaValores()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtBolsaValores = Nothing
        End Try
    End Sub
    Private Sub ListarEntidad()
        Try
            Dim sTabla As String = "tbEntidad"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtEntidadReg = .Item(sTabla)
            End With

            If dtEntidadReg.Rows.Count > 0 Then
                cboEntidadReguladora.DataSource = dtEntidadReg

                cboEntidadReguladora.ValueMember = "idEntidadReguladora"
                cboEntidadReguladora.DisplayMember = "sEntidad"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarEntidad()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtEntidadReg = Nothing
        End Try
    End Sub
    Private Sub ListarNormatividad()
        Try
            Dim sTabla As String = "tbNorma"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtNormatividad = .Item(sTabla)
            End With

            If dtNormatividad.Rows.Count > 0 Then
                cboEntidadSupervisada.DataSource = dtNormatividad

                cboEntidadSupervisada.ValueMember = "idNormatividad"
                cboEntidadSupervisada.DisplayMember = "sNormatividad"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarNormatividad()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtNormatividad = Nothing
        End Try
    End Sub

    Private Sub ListarPaisGT()
        Try
            Dim sTabla As String = "tbPais"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtPaisGT = .Item(sTabla)
            End With

            If dtPaisGT.Rows.Count > 0 Then
                cboReferenciaGTIPais.DataSource = dtPaisGT

                cboReferenciaGTIPais.ValueMember = "idPais"
                cboReferenciaGTIPais.DisplayMember = "sPais"
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "listarOficinasPpto()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtPaisGT = Nothing
        End Try
    End Sub
    Private Sub ListarOficinasGT(idPais As Integer)
        Try
            Dim sTabla As String = "tbPais"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPais", idPais, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtOfGt = .Item(sTabla)
            End With

            If dtOfGt.Rows.Count > 0 Then
                cboReferenciaGTIOficina.DataSource = dtOfGt

                cboReferenciaGTIOficina.ValueMember = "iPais"
                cboReferenciaGTIOficina.DisplayMember = "sOficina"
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "listarOficinasPpto()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtOfGt = Nothing
        End Try
    End Sub
    Private Sub ListarPaisResidencia()
        Try
            Dim sTabla As String = "tbResidencia"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtPaisResidencia = .Item(sTabla)
            End With

            If dtPaisResidencia.Rows.Count > 0 Then
                cboPaisResidencia.DataSource = dtPaisResidencia

                cboPaisResidencia.ValueMember = "idPais"
                cboPaisResidencia.DisplayMember = "sPais"
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "listarOficinasPpto()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtPaisResidencia = Nothing
        End Try
    End Sub
    Private Sub ListarTipoEntidad()
        Try
            Dim sTabla As String = "tbTipoEntidad"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtTipoEntidad = .Item(sTabla)
            End With

            If dtTipoEntidad.Rows.Count > 0 Then
                cboTipoEntidad.DataSource = dtTipoEntidad

                cboTipoEntidad.ValueMember = "idTipoEntidad"
                cboTipoEntidad.DisplayMember = "sEntidad"
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "listarOficinasPpto()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtTipoEntidad = Nothing
        End Try
    End Sub
    Private Sub ListarModalidades()
        Try
            Dim sTabla As String = "tbModalidad"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 19, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtModalidades = .Item(sTabla)
            End With

            If dtModalidades.Rows.Count > 0 Then
                cboModalidades.DataSource = dtModalidades

                cboModalidades.ValueMember = "idModalidad"
                cboModalidades.DisplayMember = "sModalidad"
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarModalidades()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtModalidades = Nothing
        End Try
    End Sub
    Private Sub ListarIdiomas()
        Try
            Dim sTabla As String = "tbIdioma"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 20, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtIdiomas = .Item(sTabla)
            End With

            If dtIdiomas.Rows.Count > 0 Then
                cboIdioma.DataSource = dtIdiomas

                cboIdioma.ValueMember = "idIdioma"
                cboIdioma.DisplayMember = "sIdioma"
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarIdiomas()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtIdiomas = Nothing
        End Try
    End Sub

    'Private Sub ListarOficinasUsuario()
    '    Try
    '        Dim sTabla As String = "tbOficinasUsr"

    '        With ds.Tables
    '            LimpiarConsultaTabla(ds.Tables, sTabla)

    '            With clsDatos
    '                .subClearParameters()
    '                .subAddParameter("@iTipo", 17, SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@sTipoUsuario", sTipoUsuario, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
    '            End With

    '            .Add(clsDatos.funExecuteSPDataTable("paConsultaTrabajoRecurrente", sTabla))

    '            dtOficinas = .Item(sTabla)
    '        End With

    '        cboOficina.DataSource = dtOficinas
    '        cboOficina.DisplayMember = "DESCOFI"
    '        cboOficina.ValueMember = "sCveOfi"
    '    Catch ex As Exception
    '        InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarOficinasUsuario()")
    '        MsgBox(My.Settings.MSG_REPS, MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
    '        dtOficinas = Nothing
    '    End Try
    'End Sub
    'Private Sub ListarDivisionesUsuario()
    '    Try
    '        Dim sTabla As String = "tbDivisionesUsr"

    '        With ds.Tables
    '            LimpiarConsultaTabla(ds.Tables, sTabla)

    '            With clsDatos
    '                .subClearParameters()
    '                .subAddParameter("@iTipo", 18, SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@sTipoUsuario", sTipoUsuario, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
    '            End With

    '            .Add(clsDatos.funExecuteSPDataTable("paConsultaTrabajoRecurrente", sTabla))

    '            dtDivisiones = .Item(sTabla)
    '        End With

    '        cboDivision.DataSource = dtDivisiones
    '        cboDivision.ValueMember = "sCveArea"
    '        cboDivision.DisplayMember = "DESCAREA"
    '    Catch ex As Exception
    '        InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDivisionesUsuario()")
    '        MsgBox(My.Settings.MSG_REPS, MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
    '        dtDivisiones = Nothing
    '    End Try
    'End Sub

    Private Sub ListarDatosGenerales()
        Try
            Dim sTabla As String = "tbDatosGenerales"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACDatosGenerales", sTabla))

                dtDatosGenerales = .Item(sTabla)
            End With

            If dtDatosGenerales.Rows.Count > 0 Then
                sNombreCliente = dtDatosGenerales.Rows(0).Item("sRazonSocial").ToString
                txtRazonSocial.Text = sNombreCliente
                txtNombreComercial.Text = dtDatosGenerales.Rows(0).Item("sNombreComercial").ToString

                txtDescripcionSolicitud.Text = dtDatosGenerales.Rows(0).Item("sDescripcionServicio").ToString

                txtRFC.Text = dtDatosGenerales.Rows(0).Item("sRFC").ToString
                txtIndustria.Text = dtDatosGenerales.Rows(0).Item("sIndustria").ToString

                sInd = dtDatosGenerales.Rows(0).Item("idInd").ToString
                sCveInd = dtDatosGenerales.Rows(0).Item("idInd").ToString
                sCveSS = dtDatosGenerales.Rows(0).Item("IdSubSec").ToString

                'txtIndustria.Text = dtDatosGenerales.Rows(0).Item("idInd").ToString

                If dtDatosGenerales.Rows(0).Item("sTipoNegocio").ToString = "F" Then
                    rdPersonaFisica.Checked = True
                ElseIf dtDatosGenerales.Rows(0).Item("sTipoNegocio").ToString = "M" Then
                    rdPersonalMoral.Checked = True
                End If

                If CBool(dtDatosGenerales.Rows(0).Item("bPublica").ToString) = True Then
                    rdEmpresaPublicaSi.Checked = True
                Else
                    rdEmpresaPublicaNo.Checked = True
                End If

                cboBolsaValores.SelectedValue = CInt(dtDatosGenerales.Rows(0).Item("idBolsaValores").ToString)
                txtBolsaValoresOtro.Text = dtDatosGenerales.Rows(0).Item("sOtraBolsa").ToString

                If CBool(dtDatosGenerales.Rows(0).Item("bSubsidiaria").ToString) = True Then
                    rdSubsidiariaSi.Checked = True
                Else
                    rdSubsidiariaNo.Checked = True
                End If

                If CBool(dtDatosGenerales.Rows(0).Item("bControladora").ToString) = True Then
                    rdControladoraSi.Checked = True
                Else
                    rdControladoraNO.Checked = True
                End If

                idPais = CInt(dtDatosGenerales.Rows(0).Item("idPais").ToString)
                txtPaisProspecto.Text = dtDatosGenerales.Rows(0).Item("sPais").ToString

                If CBool(dtDatosGenerales.Rows(0).Item("bEntidadReguladora").ToString) = True Then
                    rdEntidadReguladaSi.Checked = True
                Else
                    rdEntidadReguladaNo.Checked = True
                End If

                cboEntidadReguladora.SelectedValue = CInt(dtDatosGenerales.Rows(0).Item("idEntidadReguladora").ToString)
                txtEntidadReguladoraOtro.Text = dtDatosGenerales.Rows(0).Item("sOtraEntidad").ToString

                If CBool(dtDatosGenerales.Rows(0).Item("bEntidadSupervisada").ToString) = True Then
                    rdEntidadSupervisadaSi.Checked = True
                Else
                    rdEntidadSupervisadaNo.Checked = True
                End If

                cboEntidadSupervisada.SelectedValue = CInt(dtDatosGenerales.Rows(0).Item("idNormatividad").ToString)
                txtEntidadSupervisadaOtro.Text = dtDatosGenerales.Rows(0).Item("sOtraNormatividad").ToString

                If CBool(dtDatosGenerales.Rows(0).Item("bReferenciaGTI").ToString) = True Then
                    rdReferenciaGTISi.Checked = True
                Else
                    rdReferenciaGTINo.Checked = True
                End If

                txtReferenciaGTISocio.Text = dtDatosGenerales.Rows(0).Item("sSocioRefGTI").ToString
                idPaisGT = CInt(dtDatosGenerales.Rows(0).Item("idPaisRefGTI").ToString)
                txtPaisGTI.Text = dtDatosGenerales.Rows(0).Item("sPaisGTI").ToString
                ListarOficinasGT(idPaisGT)
                cboReferenciaGTIOficina.Text = dtDatosGenerales.Rows(0).Item("sOficinaRefGTI").ToString

                If CBool(dtDatosGenerales.Rows(0).Item("bReportaExtranjero").ToString) = True Then
                    rdEmpresaExtranjeroRepSi.Checked = True
                Else
                    rdEmpresaExtranjeroRepNo.Checked = True
                End If

                txtEmpresaTenedora.Text = dtDatosGenerales.Rows(0).Item("sNombreTenedora").ToString
                idPaisTenedora = CInt(dtDatosGenerales.Rows(0).Item("idPaisTenedora").ToString)
                txtPaisResidencia.Text = dtDatosGenerales.Rows(0).Item("sPaisTenedora").ToString

                If CBool(dtDatosGenerales.Rows(0).Item("bDomiciliadasExt").ToString) = True Then
                    rdEmpresaExtranjeroDomSi.Checked = True
                Else
                    rdEmpresaExtranjeroDomNo.Checked = True
                End If

                If CBool(dtDatosGenerales.Rows(0).Item("bSubsidiariasExt").ToString) = True Then
                    rdEmpresaExtranjeroSubSi.Checked = True
                Else
                    rdEmpresaExtranjeroSubNo.Checked = True
                End If

                cboTipoEntidad.SelectedValue = CInt(dtDatosGenerales.Rows(0).Item("idTipoEntidad").ToString)

                txtIdSAC.Text = dtDatosGenerales.Rows(0).Item("idSac").ToString
                cboOficina.SelectedValue = dtDatosGenerales.Rows(0).Item("sCveOfi").ToString
                cboDivision.SelectedValue = dtDatosGenerales.Rows(0).Item("sCveArea").ToString

                If dtDatosGenerales.Rows(0).Item("bIdioma").ToString Then
                    rdIdiomaSi.Checked = True

                    idIdioma = dtDatosGenerales.Rows(0).Item("idIdioma").ToString
                    'cboIdioma.SelectedValue = dtDatosGenerales.Rows(0).Item("idIdioma").ToString
                    txtIdioma.Text = dtDatosGenerales.Rows(0).Item("sIdioma").ToString
                Else
                    rdIdiomaNo.Checked = True
                    idIdioma = 0
                    txtIdioma.Text = ""
                End If

                'txtContactoInicialFecha.Value = dtDatosGenerales.Rows(0).Item("dFechaIni").ToString
                txtPeriodoInicio.Value = dtDatosGenerales.Rows(0).Item("dFechaIni").ToString
                txtPeriodoFinal.Value = dtDatosGenerales.Rows(0).Item("dFechaFin").ToString
                txtFechaEntregaReporte.Value = dtDatosGenerales.Rows(0).Item("dFechaEntrega").ToString
                txtFechaSolicitud.Value = dtDatosGenerales.Rows(0).Item("dFechaPropuesta").ToString
                cboModalidades.SelectedValue = dtDatosGenerales.Rows(0).Item("idModalidad").ToString

                txtCorreoSocioGTI.Text = dtDatosGenerales.Rows(0).Item("sCorreoSocRefGTI").ToString
                txtGerenteGTI.Text = dtDatosGenerales.Rows(0).Item("sGerenteRefGTI").ToString
                txtCorreoGerenteGTI.Text = dtDatosGenerales.Rows(0).Item("sCorreoGerenteRefGTI").ToString
                txtEstadoGTI.Text = dtDatosGenerales.Rows(0).Item("sEstadoRefGTI").ToString
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDatosGenerales()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtDatosGenerales = Nothing
        End Try
    End Sub
    Private Sub ListarServiciosDatosGenerales()
        drServicios = dtServicios.NewRow()
        drServicios("CVE") = idServicio
        drServicios("DESCRIPCION") = sServicio
        dtServicios.Rows.InsertAt(drServicios, dtServicios.Rows.Count)

        bsSer.DataSource = dtServicios
        gridServicios.Columns("CVE").Visible = False

        ConfigurarColumnasGrid(gridServicios, "DESCRIPCION", "SERVICIO", 0, 1, False)
    End Sub

#End Region

#Region "CONTACTO INICIAL"

    Private Sub ListarContactoInicial()
        Try
            Dim sTabla As String = "tbContactoInicial"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idSAC", idSAC, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACContactoInicial", sTabla))

                dtContactoInicial = .Item(sTabla)
            End With

            If dtContactoInicial.Rows.Count > 0 Then
                Dim dFechaCon As Date = dtContactoInicial.Rows(0).Item("dFechaContacto")

                If IsDBNull(dFechaCon) OrElse String.IsNullOrWhiteSpace(dFechaCon.ToString()) Then
                    txtContactoInicialFecha.Value = Date.Now
                Else
                    txtContactoInicialFecha.Value = dFechaCon
                End If

                txtContactoInicialPrimerContacto.Text = dtContactoInicial.Rows(0).Item("sNombrePrimerContacto").ToString
                txtContactoInicialNombre.Text = dtContactoInicial.Rows(0).Item("sNombreContacto").ToString
                txtContactoInicialCorreo.Text = dtContactoInicial.Rows(0).Item("sCorreo").ToString
                txtContactoInicialCargo.Text = dtContactoInicial.Rows(0).Item("sCargo").ToString
                txtContactoInicialTelefono.Text = dtContactoInicial.Rows(0).Item("sTelefono").ToString
                txtContactoInicialExtension.Text = dtContactoInicial.Rows(0).Item("sExtension").ToString
                txtContactoInicialCelular.Text = dtContactoInicial.Rows(0).Item("sTelefonoCelular").ToString
                txtAcercamientoWebProspecto.Text = dtContactoInicial.Rows(0).Item("sPaginaWeb").ToString
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarContactoInicial()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtContactoInicial = Nothing
        End Try
    End Sub

#End Region

#Region "ACERCAMIENTO"

    Private Sub SeleccionarMedioContacto(idMedio As Integer)
        txtAcercamientoEnteroOtro.Text = ""

        rdReferenciaGTINo.Enabled = True
        rdReferenciaGTISi.Checked = False
        rdReferenciaGTINo.Checked = False

        Select Case idMedio
            Case 7
                txtAcercamientoEnteroOtro.Enabled = True
                lblAcercamientoOtro.Text = "Socio"

            Case 8
                txtAcercamientoEnteroOtro.Enabled = True
                lblAcercamientoOtro.Text = "Gerente"

            Case 12
                txtAcercamientoEnteroOtro.Enabled = True
                lblAcercamientoOtro.Text = "Colaborador"

            Case 13
                txtAcercamientoEnteroOtro.Enabled = True
                lblAcercamientoOtro.Text = "Otro"

            Case 9
                rdReferenciaGTISi.Checked = True
                rdReferenciaGTINo.Enabled = False

            Case Else
                txtAcercamientoEnteroOtro.Enabled = False
                lblAcercamientoOtro.Text = "Otro"

        End Select
    End Sub
    Private Sub ListarComoSeEnteroAcerca()
        Try
            Dim sTabla As String = "tbComoSeEnteroAcerca"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 0, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACAcercamiento", sTabla))

                dtComoSeEntero = .Item(sTabla)
            End With

            If dtComoSeEntero.Rows.Count > 0 Then
                cboAcercamientoComoEntero.DataSource = dtComoSeEntero

                cboAcercamientoComoEntero.DisplayMember = "sAcercamiento"
                cboAcercamientoComoEntero.ValueMember = "idAcercamiento"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarComoSeEnteroAcerca()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtComoSeEntero = Nothing
        End Try
    End Sub
    Private Sub ListarMedioContactoAcerca()
        Try
            Dim sTabla As String = "tbMedioContactoAcerca"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACAcercamiento", sTabla))

                dtMedioContacto = .Item(sTabla)
            End With

            If dtMedioContacto.Rows.Count > 0 Then
                cboAcercamientoMedioContacto.DataSource = dtMedioContacto

                cboAcercamientoMedioContacto.ValueMember = "idMedio"
                cboAcercamientoMedioContacto.DisplayMember = "sMedio"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarMedioContactoAcerca()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtMedioContacto = Nothing
        End Try
    End Sub
    Private Sub ListarAcercamiento()
        Try
            Dim sTabla As String = "tbAcercamiento"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idSAC", idSAC, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACAcercamiento", sTabla))

                dtAcercamiento = .Item(sTabla)
            End With

            If dtAcercamiento.Rows.Count > 0 Then
                cboAcercamientoComoEntero.SelectedValue = CInt(dtAcercamiento.Rows(0).Item("idAcercamiento").ToString)
                If CInt(dtAcercamiento.Rows(0).Item("idAcercamiento").ToString) = 13 Then
                    txtAcercamientoEnteroOtro.Enabled = True
                End If
                txtAcercamientoEnteroOtro.Text = dtAcercamiento.Rows(0).Item("sOtroAcercamiento").ToString

                cboAcercamientoMedioContacto.SelectedValue = CInt(dtAcercamiento.Rows(0).Item("idMedio").ToString)
                If CInt(dtAcercamiento.Rows(0).Item("idMedio").ToString) = 10 Then
                    txtAcercamientoContactoOtro.Enabled = True
                End If
                txtAcercamientoContactoOtro.Text = dtAcercamiento.Rows(0).Item("sOtroMedio").ToString
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarAcercamiento()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtAcercamiento = Nothing
        End Try
    End Sub

#End Region

#Region "DOMICILIO"

    Private Sub LimpiarDatosDomicilio()
        txtDomicilioCalle.Text = ""
        txtDomicilioNoExt.Text = ""
        txtDomicilioNoInt.Text = ""
        txtDomicilioCP.Text = ""

        txtDomicilioExtDireccion1.Text = ""
        txtDomicilioExtLocalidad.Text = ""
        txtDomicilioExtEstado.Text = ""

        cboDomicilioColonia.SelectedIndex = -1
        cboDomicilioMunicipio.SelectedIndex = -1
        cboDomicilioEstado.SelectedIndex = -1
    End Sub
    Private Sub ListarEstadosDomicilio()
        Try
            Dim sTabla As String = "tbEdosDom"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACDomicilio", sTabla))

                dtEstadosDomicilio = .Item(sTabla)
            End With

            If dtEstadosDomicilio.Rows.Count > 0 Then
                cboDomicilioEstado.DataSource = dtEstadosDomicilio

                cboDomicilioEstado.ValueMember = "idEstado"
                cboDomicilioEstado.DisplayMember = "sEstado"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarEstadosDomicilio()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtEstadosDomicilio = Nothing
        End Try
    End Sub
    Private Sub ListarMunicipiosDomicilio(idEstado As Integer)
        Try
            Dim sTabla As String = "tbMunDom"

            dtMunicipiosDomicilio.Clear()

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idEstado", idEstado, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACDomicilio", sTabla))

                dtMunicipiosDomicilio = .Item(sTabla)
            End With

            If dtMunicipiosDomicilio.Rows.Count > 0 Then
                cboDomicilioMunicipio.DataSource = dtMunicipiosDomicilio

                cboDomicilioMunicipio.ValueMember = "idMunicipio"
                cboDomicilioMunicipio.DisplayMember = "sMunicipio"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarMunicipiosDomicilio()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtMunicipiosDomicilio = Nothing
        End Try
    End Sub
    Private Sub ListarColoniasDomicilio(id As Integer, sValor As String, Optional sValor2 As String = "")
        Try
            Dim sTabla As String = "tbColDom"

            dtColoniasDomicilio.Clear()

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                    If id = 1 Then
                        .subAddParameter("@sCP", sValor, SqlDbType.VarChar, ParameterDirection.Input)
                    Else
                        .subAddParameter("@idMunicipio", CInt(sValor), SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@idEstado", CInt(sValor2), SqlDbType.Int, ParameterDirection.Input)
                    End If
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACDomicilio", sTabla))
                dtColoniasDomicilio = .Item(sTabla)

                If dtColoniasDomicilio.Rows.Count > 0 Then
                    cboDomicilioColonia.DataSource = dtColoniasDomicilio

                    cboDomicilioColonia.ValueMember = "idColonia"
                    cboDomicilioColonia.DisplayMember = "sColonia"

                    cboDomicilioColonia.SelectedValue = CInt(dtColoniasDomicilio(0)("idColonia").ToString())

                    ListarMunicipiosDomicilio(CInt(dtColoniasDomicilio(0)("idEstado").ToString()))
                    cboDomicilioMunicipio.SelectedValue = CInt(dtColoniasDomicilio(0)("idMunicipio").ToString())

                    cboDomicilioEstado.SelectedValue = CInt(dtColoniasDomicilio(0)("idEstado").ToString())
                Else
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "listarColoniasDomicilio()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtColoniasDomicilio = Nothing
        End Try

    End Sub

    Private Sub ListarDomicilio()
        Try
            Dim sTabla As String = "tbDomicilio"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idSAC", idSAC, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACDomicilio", sTabla))

                dtDomicilio = .Item(sTabla)
            End With

            If dtDomicilio.Rows.Count > 0 Then
                idPaisDom = CInt(dtDomicilio.Rows(0).Item("idPais").ToString)
                sPaisDom = dtDomicilio.Rows(0).Item("sPais").ToString
                txtPaisDomicilio.Text = sPaisDom

                If idPaisDom = 151 Then
                    panDomicilioNac.Visible = True
                    panDomicilioExt.Visible = False

                Else
                    panDomicilioNac.Visible = False
                    panDomicilioExt.Visible = True
                End If

                If idPaisDom = 151 Then
                    txtDomicilioCalle.Text = dtDomicilio.Rows(0).Item("sCalle").ToString
                    txtDomicilioNoExt.Text = dtDomicilio.Rows(0).Item("sNumExt").ToString
                    txtDomicilioNoInt.Text = dtDomicilio.Rows(0).Item("sNumInt").ToString
                    txtDomicilioCP.Text = dtDomicilio.Rows(0).Item("sCP").ToString

                    ListarColoniasDomicilio(1, txtDomicilioCP.Text)

                    cboDomicilioEstado.SelectedValue = CInt(dtDomicilio.Rows(0).Item("idEstado").ToString)
                    cboDomicilioMunicipio.SelectedValue = CInt(dtDomicilio.Rows(0).Item("idMunicipio").ToString)
                    cboDomicilioColonia.SelectedValue = CInt(dtDomicilio.Rows(0).Item("idColonia").ToString)

                    txtDomicilioExtDireccion1.Text = ""
                    txtDomicilioExtDireccion2.Text = ""
                    txtDomicilioExtLocalidad.Text = ""
                    txtDomicilioExtEstado.Text = ""
                    txtDomicilioExtCP.Text = ""
                Else
                    txtDomicilioExtDireccion1.Text = dtDomicilio.Rows(0).Item("sCalle").ToString
                    txtDomicilioExtDireccion2.Text = dtDomicilio.Rows(0).Item("sColonia").ToString
                    txtDomicilioExtLocalidad.Text = dtDomicilio.Rows(0).Item("sMunicipio").ToString
                    txtDomicilioExtEstado.Text = dtDomicilio.Rows(0).Item("sEstado").ToString
                    txtDomicilioExtCP.Text = dtDomicilio.Rows(0).Item("sCP").ToString
                End If
            Else
                panDomicilioNac.Visible = False
                panDomicilioExt.Visible = False

                LimpiarDatosDomicilio()
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDomicilio()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtDomicilio = Nothing
        End Try
    End Sub

#End Region

End Class