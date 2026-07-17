Imports System.IO
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports PdfSharp.Drawing
Imports PdfSharp.Drawing.Layout
Imports PdfSharp.Fonts
Imports PdfSharp.Pdf

Public Class FrmContacto

#Region "VARIABLES"

    Private ds As New DataSet
    Private bsPro, bsFun, bsAcc, bsCli, bsSer As New BindingSource

    Private sNameRpt As String = "Alta de Prospecto"
    Private sNombreEncargadoGTI As String = "Sergio Arevalo"
    Private Const DATOS_GENERALES As String = "DATOS GENERALES"
    Private Const CONTACTO_INICIAL As String = "CONTACTO INICIAL"
    Private Const ACERCAMIENTO As String = "ACERCAMIENTO"
    Private Const DOMICILIO As String = "DOMICILIO"

    Private dtCvesProspectos, dtProspectos, dtRfc, dtIdSac, dtServicios, dtServiciosCarga As New DataTable
    Private dtDatosGenerales, dtServiciosDG, dtMercantilesRS, dtMercantilesNC, dtCorreosSolicitud As New DataTable
    Private dtContactoInicial As New DataTable
    Private dtComoSeEntero, dtMedioContacto, dtAcercamiento As New DataTable
    Private dtDomicilio, dtPaisDomicilio, dtColoniasDomicilio, dtMunicipiosDomicilio, dtEstadosDomicilio, dtAnexos As New DataTable
    Private dtDatGrals, dtBolsaValores, dtEntidadReg, dtNormatividad, dtPais, dtPaisGT, dtPaisResidencia, dtTipoEntidad, dtModalidades, dtIdiomas, dtOficinas, dtDivisiones, dtSocios, dtOfGt As DataTable
    Private dtIndustria, dtSubSector, dtSubNivel As DataTable

    Private drServicios As DataRow
    Private sInd, sSS, sGTI As String

    Private iOpcionFun, iOpcionAcc, idIdioma, idPais, idPaisTenedora, idPaisGT, idPaisDom As Integer
    Private sCveInd, sCveSS, sCveGTI, sPaisDom As String

    Private sCveSoc, sNomSoc, sCorreoSoc As String
    Private sMsgDatosGenerales, sMsgContacto, sMsgAcercamiento, sMsgDomicilio, sMsgAviso, sOtroServicios As String

    Private ArchivoAnexo As Byte()
    Private sRutaAnexo, ExtAnexo, NombAnexo As String

    Private bMarco = False, bOtros = False, bOtrosCarga = False, bRefGTI = False, bCargaInfo As Boolean = False
    Private CorreosSoc, sNombSocio, sMailSocio, sNombreEncargado, sCorreoEncargado As String
    Public sCveOfi, sCveArea, sOficina, sArea, sEstatusSolicitud As String
    Public iOrigen, iModifica, idSAC As Integer
    Private arPDF As Byte()

#End Region

#Region "EVENTOS"

    Private Sub FrmContacto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        panDatosGenerales.Visible = True

        'If GlobalFontSettings.FontResolver Is Nothing Then
        '    GlobalFontSettings.FontResolver = New FontsResolver()
        'End If

        gridServicios.DataSource = bsSer
        DesplazamientoGrid(gridServicios)

        gridClientesSAT.DataSource = bsCli
        DesplazamientoGrid(gridClientesSAT)

        txtClaveProspecto.Text &= idSAC

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

        CargaClientesDatosGenerales()

        '============================== DATOS GENERALES ==============================

        ListarBolsaValores()
        ListarEntidad()
        ListarNormatividad()
        ListarPais()
        ListarPaisGT()
        ListarPaisResidencia()
        ListarTipoEntidad()
        ListarModalidades()
        ListarEntidadesMercantilesRS()
        ListarEntidadesMercantilesNC()
        ListarOficinas()
        ListarDivisiones()
        ListarServiciosDatosGenerales()

        ListarDatosGenerales()

        ListarIndustrias()
        ListarSubSector()
        ListarSubNivel()

        '============================== CONSULTA DATOS ==============================
        ListarContactoInicial()
        '============================== CONSULTA CORREOS SOLICITUD ==============================
        ListarCorreosSolicitud()
        '============================== CONSULTA ARCHIVOS ANEXOS==============================
        ListarArchivosAnexos()

    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim dlg As New DlgServiciosCte With {
            .sCveArea = sCveArea,
            .sCveOfi = sCveOfi,
            .dtServCte = dtServiciosCarga
        }

        bOtros = False

        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then

            If dlg.dtServiciosCte.Rows.Count > 0 Then
                For Each dr As DataRow In dlg.dtServiciosCte.Rows
                    If dtServicios.Select($"CVE = '{dr("CVE")}' AND CVEOFI = '{sCveOfi}' AND CVEAREA = '{sCveArea}'").Count = 0 Then
                        drServicios = dtServicios.NewRow()
                        drServicios("CVE") = dr.Field(Of Integer)("CVE")
                        drServicios("CVEOTROS") = dr.Field(Of Boolean)("CVEOTROS")
                        drServicios("CVEOFI") = sCveOfi
                        drServicios("CVEAREA") = sCveArea
                        drServicios("DESCOFI") = sOficina
                        drServicios("DESCAREA") = sArea
                        drServicios("REVIND") = "S"
                        drServicios("DESCRIPCION") = dr.Field(Of String)("DESCRIPCION")
                        drServicios("DESCOTROS") = dr.Field(Of String)("DESCOTROS")
                        dtServicios.Rows.Add(drServicios)

                        drServicios = dtServiciosCarga.NewRow()
                        drServicios("CVE") = dr.Field(Of Integer)("CVE")
                        drServicios("CVEOTROS") = dr.Field(Of Boolean)("CVEOTROS")
                        drServicios("CVEOFI") = sCveOfi
                        drServicios("CVEAREA") = sCveArea
                        drServicios("DESCOFI") = sOficina
                        drServicios("DESCAREA") = sArea
                        drServicios("REVIND") = "S"
                        drServicios("DESCRIPCION") = dr.Field(Of String)("DESCRIPCION")
                        drServicios("DESCOTROS") = dr.Field(Of String)("DESCOTROS")
                        dtServiciosCarga.Rows.Add(drServicios)

                        If bOtrosCarga = False Then
                            bOtrosCarga = dr.Field(Of Boolean)("CVEOTROS")
                        End If

                        If bOtrosCarga Then
                            bOtros = True
                            sOtroServicios = dr.Field(Of String)("DESCOTROS")
                            bOtrosCarga = False
                        End If

                        InsertarServiciosDatosGenerales(dr.Field(Of Integer)("CVE"), dr.Field(Of Boolean)("CVEOTROS"), dr.Field(Of String)("DESCOTROS"), sCveOfi, sCveArea)
                    End If
                Next
            End If

            bOtros = dtServicios.AsEnumerable().Any(Function(dr) dr.Field(Of Boolean)("CVEOTROS"))
            ValidaNormatividad()

            bsSer.DataSource = dtServicios
            gridServicios.Columns("CVE").Visible = False
            gridServicios.Columns("CVEOTROS").Visible = False
            gridServicios.Columns("CVEOFI").Visible = False
            gridServicios.Columns("CVEAREA").Visible = False
            gridServicios.Columns("REVIND").Visible = False

            ConfigurarColumnasGrid(gridServicios, "DESCOFI", "OFICINA", 80, 3, False)
            ConfigurarColumnasGrid(gridServicios, "DESCAREA", "DIVISIÓN", 80, 3, False)
            ConfigurarColumnasGrid(gridServicios, "DESCRIPCION", "SERVICIO", 0, 1, False)
            ConfigurarColumnasGrid(gridServicios, "DESCOTROS", "DESCRIPCIÓN 'OTROS'", 0, 1, False)
        End If
    End Sub
    Private Sub BtnRegistroDatosGenerales_Click(sender As Object, e As EventArgs) Handles btnHabilitar.Click
        bCargaInfo = True
        txtMensaje.Text = ""
        panMensajesError.Visible = False

        'General
        gpBoxDatosDG.Enabled = True
        gpBoxServicio.Enabled = True
        btnGuardaGeneral.Enabled = True
        btnCancelaGeneral.Enabled = True
        btnEnviarAsiganacion.Enabled = True
        btnHabilitar.Enabled = False
        txtRazonSocial.Focus()

        'Contacto Inicial
        panDatosContactoInicial.Enabled = True
        txtContactoInicialPrimerContacto.Focus()

        'Acercamiento
        gpBoxDatosAcercamiento.Enabled = True
        cboAcercamientoComoEntero.Focus()

        'Domicilio
        gpBoxDatosDomicilio.Enabled = True
        cboDomicilioPais.Focus()
    End Sub
    Private Sub BtnGuardaGeneral_Click(sender As Object, e As EventArgs) Handles btnGuardaGeneral.Click
        Try
            sMsgDatosGenerales = ""
            sMsgContacto = ""
            sMsgAcercamiento = ""
            sMsgDomicilio = ""

            '================================ DATOS GENERALES ==============================
            If ValidarDatosGenerales() Then
                sMsgDatosGenerales = ""
                InsertarDatosGenerales()
            End If

            '================================ CONTACTO INICIAL ================================
            If ValidarContactoInicial() Then
                sMsgContacto = ""
                InsertarContactoInicial()
            End If

            '================================ ACERCAMIENTO ====================================
            If ValidarAcercamiento() Then
                sMsgAcercamiento = ""
                InsertarAcercamiento()
            End If

            '================================ DOMICILIO ====================================
            If ValidarDomicilio() Then
                sMsgDomicilio = ""
                InsertarDomicilio()
            End If

            If sMsgDatosGenerales <> "" Or sMsgContacto <> "" Or sMsgAcercamiento <> "" Or sMsgDomicilio <> "" Then
                panMensajesError.Visible = True
                txtMensaje.Text = sMsgDatosGenerales & vbCrLf & sMsgContacto & vbCrLf & sMsgAcercamiento & vbCrLf & sMsgDomicilio
                Exit Sub
            Else
                panMensajesError.Visible = False
                txtMensaje.Text = ""
            End If

            If bOtros Then
                sMsgAviso = "Se generará una solicitud para la revisión del servicio solicitado mediante la opción 'OTROS', así como la(s) solicitud(es) de asignación para su revisión. ¿Desea continuar?"
            Else
                sMsgAviso = "Se enviará la(s) solicitud(es) de asignación para su revisión. ¿Desea continuar?"
            End If

            If MsgBox(sMsgAviso, MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Settings.NOM_SYS) = MsgBoxResult.Yes Then
                For Each ser As DataRow In dtServicios.Rows
                    InsertarPropuesta(ser.Item("CVE"), ser.Item("CVEOTROS"), ser.Item("CVEOFI"), ser.Item("CVEAREA"))
                Next

                Dim Dr() As DataRow

                If dtCorreosSolicitud.Rows.Count > 0 Then
                    Dr = dtCorreosSolicitud.Select("sCvepersona = 'BC'")
                    sNombreEncargado = Dr(0).Item("sTipoPersona").ToString()
                    sCorreoEncargado = Dr(0).Item("sCorreoPersona").ToString()
                    EnvioCorreoBackGround(sCorreoEncargado)

                Else
                    MsgBox("Por el momento no es posible enviar el correo de notificación de asignación de socio.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
                End If

                '============= Enviar correo a Independencia si se seleccionó el servicio 'OTROS' ==============
                If bOtros Then
                    EnvioCorreoIndependencia()
                End If

                ActualizarSolicitudSAC(idSAC)

                gpBoxDatosDG.Enabled = False
                btnGuardaGeneral.Enabled = False
                btnCancelaGeneral.Enabled = False
                btnHabilitar.Enabled = True

                DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertaPropuesta()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub BtnCancelaGeneral_Click(sender As Object, e As EventArgs) Handles btnCancelaGeneral.Click
        bCargaInfo = False
        txtMensaje.Text = ""
        panMensajesError.Visible = False

        'Datos Generales
        gpBoxDatosDG.Enabled = False
        btnGuardaGeneral.Enabled = False
        btnCancelaGeneral.Enabled = False
        btnHabilitar.Enabled = True

        'Contacto Inicial
        panDatosContactoInicial.Enabled = False

        'Acercamiento
        gpBoxDatosAcercamiento.Enabled = False

        'Domicilio
        gpBoxDatosDomicilio.Enabled = False
        'ListarPaisDomicilio()
        ListarDatosGenerales()
        ListarContactoInicial()
        ListarAcercamiento()
        ListarDomicilio()
    End Sub
    Private Sub BtnGuardarAvance_Click(sender As Object, e As EventArgs) Handles btnGuardarAvance.Click
        GenerarPDFProvisional(txtRazonSocial.Text & ", " & cboEntidadMercantilRS.SelectedItem("sCveSociedad"), txtNombreComercial.Text & ", " & cboEntidadMercantilNC.SelectedItem("sCveSociedad"))
        'If MsgBox("¿Quieres guardar la información que has capturado hasta ahora? Ten en cuenta que, para poder asignar al prospecto al socio, es necesario que completes todos los datos.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then

        'End If
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If bCargaInfo Then
            If MsgBox("¿Está seguro de que desea salir sin guardar los cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        DialogResult = DialogResult.OK
        Close()
    End Sub
    Private Sub BtnInicioPropuesta_Click(sender As Object, e As EventArgs)
        If MsgBox("Se va a iniciar el registro de una propuesta. Antes de continuar, revise que la información capturada es correcta; si está seguro de esto, presione Sí.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Iniciar Propuesta") = MsgBoxResult.Yes Then
            'InsertarPropuesta
        End If
    End Sub
    Private Sub LnkSecciones(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDatosGenerales.LinkClicked, lnkContactoInicial.LinkClicked, lnkAcercamiento.LinkClicked, lnkDireccion.LinkClicked, lnkAnexos.LinkClicked
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
        '        ListarBolsaValores()
        '        ListarEntidad()
        '        ListarNormatividad()
        '        ListarPais()
        '        ListarPaisGT()
        '        ListarPaisResidencia()
        '        ListarTipoEntidad()
        '        ListarModalidades()
        '        ListarIdiomas()
        '        ListarOficinasUsuario()
        '        ListarDivisionesUsuario()

        '        ListarDatosGenerales()

        '        ListarIndustrias()
        '        ListarSubSector()
        '        ListarSubNivel()

            Case 2
                panContactoInicial.Visible = True
        '        ListarContactoInicial()

            Case 3
                panAcercamiento.Visible = True
        '        ListarAcercamiento()

            Case 4
                panDireccion.Visible = True
                '        ListarEstadosDomicilio()
            Case 5
                panAnexos.Visible = True
                '        ListarDomicilio()

        End Select
    End Sub

#Region "DATOS GENERALES"

    Private Sub btnIndustria_Click(sender As Object, e As EventArgs) Handles btnIndustria.Click
        Dim dlg As New dlgIndustria

        If dlg.ShowDialog = DialogResult.OK Then
            sCveInd = dlg.sCveIndustria
            txtIndustria.Text = dlg.sIndustria

            sCveSS = ""
            txtSubsector.Text = ""

            sCveGTI = ""
            txtSubnivel.Text = ""
        Else
            sCveInd = ""
            txtIndustria.Text = ""
        End If
    End Sub
    Private Sub btnSubsector_Click(sender As Object, e As EventArgs) Handles btnSubsector.Click
        Dim dlg As New dlgSubSector

        If sCveInd = "" Then
            MsgBox("Seleccione una industria.", MsgBoxStyle.Exclamation, "SIAT")

            Exit Sub
        End If

        dlg.sCveIndustria = sCveInd
        dlg.sIndustria = txtIndustria.Text

        If dlg.ShowDialog = DialogResult.OK Then
            sCveSS = dlg.sCveSS
            txtSubsector.Text = dlg.sSS
        Else
            sCveSS = ""
            txtSubsector.Text = ""
        End If
    End Sub
    Private Sub btnSubnivel_Click(sender As Object, e As EventArgs) Handles btnSubnivel.Click
        Dim dlg As New dlgSubNivel

        If sCveSS = "" Then
            MsgBox("Seleccione un subsector.", MsgBoxStyle.Exclamation, "SIAT")

            Exit Sub
        End If

        dlg.sCveSS = sCveSS
        dlg.sSS = txtSubsector.Text

        If dlg.ShowDialog = DialogResult.OK Then
            sCveGTI = dlg.sCveGTI
            txtSubnivel.Text = dlg.sSN
        Else
            sCveGTI = ""
            txtSubnivel.Text = ""
        End If
    End Sub

    Private Sub RdIdiomaSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdIdiomaSi.CheckedChanged
        If rdIdiomaSi.Checked Then
            txtIdioma.ReadOnly = True
            btnIdiomas.Enabled = True
        End If
    End Sub
    Private Sub RdIdiomaNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdIdiomaNo.CheckedChanged
        If rdIdiomaNo.Checked Then
            idIdioma = 0
            txtIdioma.Text = ""
            btnIdiomas.Enabled = False
        End If
    End Sub
    Private Sub BtnIdiomas_Click(sender As Object, e As EventArgs) Handles btnIdiomas.Click
        Dim dlg As New DlgIdiomas

        If dlg.ShowDialog = DialogResult.OK Then
            idIdioma = dlg.idIdioma
            txtIdioma.Text = dlg.sIdioma
        End If
    End Sub
    Private Sub BtnPaisProspecto_Click(sender As Object, e As EventArgs) Handles btnPaisProspecto.Click
        Dim dlg As New DlgPaises

        If dlg.ShowDialog = DialogResult.OK Then
            idPais = dlg.idPais
            txtPaisProspecto.Text = dlg.sPais
        End If
    End Sub
    Private Sub BtnPaisGTI_Click(sender As Object, e As EventArgs) Handles btnPaisGTI.Click
        Dim dlg As New DlgPaises

        If dlg.ShowDialog = DialogResult.OK Then
            idPaisGT = dlg.idPais
            txtPaisGTI.Text = dlg.sPais

            If idPaisGT <> 0 Then
                ListarOficinasGT(idPaisGT)
            End If
        End If
    End Sub
    Private Sub BtnPaisResidencia_Click(sender As Object, e As EventArgs) Handles btnPaisResidencia.Click
        Dim dlg As New DlgPaises

        If dlg.ShowDialog = DialogResult.OK Then
            idPaisTenedora = dlg.idPais
            txtPaisResidencia.Text = dlg.sPais
        End If
    End Sub
    Private Sub CboOficinas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOficina.SelectedIndexChanged
        If cboOficina.SelectedIndex = -1 Then
            Exit Sub
        End If

        If cboOficina.SelectedIndex <> 0 Then
            'cboDivision.SelectedIndex = 0
            cboDivision.Enabled = True

            Dim cbo As DataRowView = cboOficina.SelectedItem

            sCveOfi = cboOficina.SelectedValue.ToString()
            sOficina = cbo.Item("sAbreviatura").ToString()
            ListarDivisiones()
        Else
            cboDivision.DataSource = Nothing
            cboDivision.Enabled = False
            btnAgregar.Enabled = False
            LimpiarTabla(dtServicios)
        End If
    End Sub
    Private Sub CboDivisiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDivision.SelectedIndexChanged
        If cboDivision.SelectedIndex = -1 Then Exit Sub

        If cboDivision.SelectedIndex > 0 Then
            btnAgregar.Enabled = True

            Dim cbo As DataRowView = cboDivision.SelectedItem
            sCveArea = cboDivision.SelectedValue.ToString
            sArea = cbo.Item("sAbreviatura").ToString()

            If sCveArea = "SS" Or sCveArea = "CO" Or sCveArea = "ATI" Then
                sCveArea = "AUD"
            End If

        Else
            btnAgregar.Enabled = False
        End If
    End Sub
    Private Sub rdEmpresaPublicaSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdEmpresaPublicaSi.CheckedChanged
        HabilitarCombo(cboBolsaValores, True)
    End Sub
    Private Sub rdEmpresaPublicaNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdEmpresaPublicaNo.CheckedChanged
        HabilitarCombo(cboBolsaValores, False)
        cboBolsaValores.SelectedIndex = 0

        txtBolsaValoresOtro.Enabled = False
        txtBolsaValoresOtro.Text = ""
    End Sub
    Private Sub CboBolsaValores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBolsaValores.SelectedIndexChanged
        If cboBolsaValores.SelectedIndex = 5 Then
            txtBolsaValoresOtro.Enabled = True
        Else
            txtBolsaValoresOtro.Enabled = False
            txtBolsaValoresOtro.Text = ""
        End If
    End Sub
    Private Sub rdEntidadReguladaSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdEntidadReguladaSi.CheckedChanged
        HabilitarCombo(cboEntidadReguladora, True)
    End Sub
    Private Sub rdEntidadReguladaNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdEntidadReguladaNo.CheckedChanged
        HabilitarCombo(cboEntidadReguladora, False)
        cboEntidadReguladora.SelectedIndex = 0

        txtEntidadReguladoraOtro.Enabled = False
        txtEntidadReguladoraOtro.Text = ""
    End Sub
    Private Sub CboEntidadReguladora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntidadReguladora.SelectedIndexChanged
        If cboEntidadReguladora.SelectedIndex = 8 Then
            txtEntidadReguladoraOtro.Enabled = True
        Else
            txtEntidadReguladoraOtro.Enabled = False
            txtEntidadReguladoraOtro.Text = ""
        End If
    End Sub
    Private Sub rdEntidadSupervisadaSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdEntidadSupervisadaSi.CheckedChanged
        HabilitarCombo(cboEntidadSupervisada, True)
    End Sub
    Private Sub rdEntidadSupervisadaNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdEntidadSupervisadaNo.CheckedChanged
        HabilitarCombo(cboEntidadSupervisada, False)
    End Sub
    Private Sub cboEntidadSupervisada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntidadSupervisada.SelectedIndexChanged
        If cboEntidadSupervisada.SelectedIndex = 6 Then
            txtEntidadSupervisadaOtro.Enabled = True
        Else
            txtEntidadSupervisadaOtro.Enabled = False
            txtEntidadSupervisadaOtro.Text = ""
        End If
    End Sub
    Private Sub RdReferenciaGTISi_CheckedChanged(sender As Object, e As EventArgs) Handles rdReferenciaGTISi.CheckedChanged
        txtReferenciaGTISocio.Enabled = True
        txtCorreoSocioGTI.Enabled = True
        txtCorreoGerenteGTI.Enabled = True
        txtGerenteGTI.Enabled = True
        btnPaisGTI.Enabled = True
        cboReferenciaGTIOficina.Enabled = True
        txtEstadoGTI.Enabled = True
    End Sub
    Private Sub RdReferenciaGTINo_CheckedChanged(sender As Object, e As EventArgs) Handles rdReferenciaGTINo.CheckedChanged
        txtReferenciaGTISocio.Enabled = False
        txtCorreoSocioGTI.Enabled = False
        txtCorreoGerenteGTI.Enabled = False
        txtGerenteGTI.Enabled = False
        btnPaisGTI.Enabled = False
        cboReferenciaGTIOficina.Enabled = False
        txtEstadoGTI.Enabled = False
    End Sub
    Private Sub txtRazonSocial_TextChanged(sender As Object, e As EventArgs) Handles txtRazonSocial.TextChanged
        txtRazonSocial.CharacterCasing = CharacterCasing.Upper

        If txtRazonSocial.Text.Length > 0 Then
            Aplicar_FiltroNombre()
        End If
    End Sub
    Private Sub txtRazonSocial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRazonSocial.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Function Filtrar_DataGridView(Columna As String, texto As String, BindingSource As BindingSource, DataGridView As DataGridView) As Integer

        ' verificar que el DataSource no esté vacio   
        If bsCli.DataSource Is Nothing Then
            Return 0
        End If

        Try

            Dim filtro As String = String.Empty

            filtro = "like '%" & texto.Trim & "%'"

            ' armar el sql   
            If filtro <> String.Empty Then
                filtro = "[" & Columna & "]" & filtro
            End If

            ' asigar el criterio a la propiedad Filter del BindingSource   
            BindingSource.Filter = filtro
            ' enlzar el datagridview al BindingSource   
            DataGridView.DataSource = BindingSource.DataSource

            ' retornar la cantidad de registros encontrados   
            Return BindingSource.Count

            ' errores   
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try

        Return 0

    End Function
    Private Sub TxtRFC_Leave(sender As Object, e As EventArgs) Handles txtRFC.Leave
        If txtRFC.TextLength <> 12 And txtRFC.TextLength <> 13 Then
            MsgBox("El RFC es incorrecto, vuelva a escribirlo por favor.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            Exit Sub
        End If

        If txtRFC.Text.Contains("SSGS") OrElse txtRFC.Text.Contains("SSGS980506U65") Then
            MsgBox("El RFC es incorrecto, vuelva a escribirlo por favor.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            Exit Sub
        End If

        If ExisteRFC(txtRFC.Text) Then
            MsgBox("No se puede dar de alta un RFC, por que ya esta dado de alta", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            txtRFC.Text = ""
        Else
            txtRFC.CharacterCasing = CharacterCasing.Upper
        End If
    End Sub
    Private Sub GridServicios_DoubleClick(sender As Object, e As EventArgs) Handles gridServicios.DoubleClick
        If gridServicios.SelectedRows.Count > 0 Then
            If MsgBox("Se quitará el servicio seleccionado, ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Settings.NOM_SYS) = MsgBoxResult.Yes Then
                Dim dt As DataTable = CType(bsSer.DataSource, DataTable)

                If gridServicios.CurrentRow IsNot Nothing Then
                    Dim idServicio As Integer = gridServicios.CurrentRow.Cells("CVE").Value
                    Dim sCveOfi As String = gridServicios.CurrentRow.Cells("CVEOFI").Value
                    Dim sCveArea As String = gridServicios.CurrentRow.Cells("CVEAREA").Value

                    EliminarServiciosDatosGenerales(gridServicios.CurrentRow.Cells("CVE").Value)
                    dt.Rows.RemoveAt(gridServicios.CurrentRow.Index)

                    Dim dr() As DataRow = dtServiciosCarga.Select($"CVE = '{idServicio}' AND CVEOFI = '{sCveOfi}' AND CVEAREA = '{sCveArea}'")
                    If dr.Length > 0 Then
                        dtServiciosCarga.Rows.Remove(dr(0))
                    End If
                End If

                ValidaNormatividad()

            End If
        End If
    End Sub

    Private Sub TxtRazonSocial_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRazonSocial.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub TxtNombreComercial_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreComercial.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            e.SuppressKeyPress = True
        End If
    End Sub

#End Region

#Region "CONTACTO INICIAL"

    Private Sub rdEmpresaExtranjeroRepNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdEmpresaExtranjeroRepNo.CheckedChanged
        If rdEmpresaExtranjeroRepNo.Checked Then
            txtEmpresaTenedora.Enabled = False
            cboPaisResidencia.Enabled = False
        End If
    End Sub
    Private Sub rdEmpresaExtranjeroRepSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdEmpresaExtranjeroRepSi.CheckedChanged
        txtEmpresaTenedora.Enabled = True
        cboPaisResidencia.Enabled = True
    End Sub

#End Region

#Region "ACERCAMIENTO"

    Private Sub CboAcercamientoComoEntero_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAcercamientoComoEntero.SelectedIndexChanged
        If cboAcercamientoComoEntero.SelectedValue Is Nothing Then Exit Sub
        If cboAcercamientoComoEntero.SelectedValue Is DBNull.Value Then Exit Sub
        If TypeOf cboAcercamientoComoEntero.SelectedValue Is DataRowView Then Exit Sub

        SeleccionarMedioContacto(cboAcercamientoComoEntero.SelectedValue)
    End Sub
    Private Sub CboAcercamientoComoEntero_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAcercamientoComoEntero.SelectionChangeCommitted
        SeleccionarMedioContacto(cboAcercamientoComoEntero.SelectedValue)
    End Sub
    Private Sub CboAcercamientoMedioContacto_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAcercamientoMedioContacto.SelectionChangeCommitted
        If cboAcercamientoMedioContacto.SelectedValue = 10 Then
            txtAcercamientoContactoOtro.Enabled = True
        Else
            txtAcercamientoContactoOtro.Enabled = False
            txtAcercamientoContactoOtro.Text = ""
        End If
    End Sub

#End Region

#Region "DOMICILIO"

    Private Sub BtnPaisDomicilio_Click(sender As Object, e As EventArgs) Handles btnPaisDomicilio.Click
        Dim dlg As New DlgPaises

        If dlg.ShowDialog = DialogResult.OK Then
            idPaisDom = dlg.idPais
            sPaisDom = dlg.sPais
            txtPaisDomicilio.Text = sPaisDom
            lblMensajeBloqueoDomicilio.Visible = False

            If idPaisDom = 151 Then
                panDomicilioNac.Visible = True
                panDomicilioExt.Visible = False
            Else
                panDomicilioNac.Visible = False
                panDomicilioExt.Visible = True
            End If
        End If
    End Sub
    Private Sub CboDomicilioPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDomicilioPais.SelectedIndexChanged
        If cboDomicilioPais.SelectedIndex = 151 Then
            panDomicilioNac.Visible = True
            panDomicilioExt.Visible = False
        Else
            panDomicilioNac.Visible = False
            panDomicilioExt.Visible = True
        End If
    End Sub
    Private Sub CboDomicilioColonia_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDomicilioColonia.SelectionChangeCommitted
        txtDomicilioCP.Text = cboDomicilioColonia.SelectedItem("sCP")
    End Sub
    Private Sub CboDomicilioMunicipio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDomicilioMunicipio.SelectionChangeCommitted
        txtDomicilioCP.Text = ""
        ListarColoniasDomicilio(2, cboDomicilioMunicipio.SelectedValue, cboDomicilioEstado.SelectedValue)
    End Sub
    Private Sub CboDomicilioEstado_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDomicilioEstado.SelectionChangeCommitted
        ListarMunicipiosDomicilio(cboDomicilioEstado.SelectedValue)
        cboDomicilioMunicipio.SelectedIndex = 0
    End Sub
    Private Sub TxtDomicilioCP_Leave(sender As Object, e As EventArgs) Handles txtDomicilioCP.Leave
        If idPaisDom = 151 Then
            If txtDomicilioCP.TextLength <> 5 And txtDomicilioCP.TextLength <> 0 Then
                MsgBox("El código postal debe contener 5 dígitos.", MsgBoxStyle.Exclamation, "SIAT")
                txtDomicilioCP.Focus()
                Exit Sub
            End If

            Dim esNumerico As Boolean = Regex.IsMatch(txtDomicilioCP.Text, "^\d+$")
            If esNumerico Then
                ListarColoniasDomicilio(1, txtDomicilioCP.Text)
            Else
                MsgBox("El código postal debe ser numerico.", MsgBoxStyle.Exclamation, "SIAT")
                txtDomicilioCP.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TxtDomicilioColonia_TextChanged(sender As Object, e As EventArgs) Handles txtDomicilioExtDireccion1.TextChanged
        txtDomicilioExtDireccion1.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub TxtDomicilioMunicipio_TextChanged(sender As Object, e As EventArgs) Handles txtDomicilioExtLocalidad.TextChanged
        txtDomicilioExtLocalidad.CharacterCasing = CharacterCasing.Upper
    End Sub

#End Region

#Region "ANEXOS"
    Private Sub btnCargaAnexo_Click(sender As Object, e As EventArgs) Handles btnCargaAnexo.Click
        Dim sFile As String = ""
        Dim limiteBytes As Integer = 10 * 1024 * 1024

        Dim Opd As New OpenFileDialog
        Opd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ToString
        ' Opd.Filter = "Archivos PDF (*.pdf)|*.pdf|All files (*.*)|*.*"
        Opd.Multiselect = True
        If (Opd.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Try

                ArchivoAnexo = convierte_archivo_a_bytes(Opd.FileName)
                sRutaAnexo = Opd.FileName
                sFile = Path.GetFileNameWithoutExtension(Opd.FileName)
                ExtAnexo = Path.GetExtension(Opd.FileName)
                NombAnexo = idSAC & "-" & sFile

                txtNombreAnexo.Text = sFile
                txtExtension.Text = ExtAnexo
                Dim Limite As New System.IO.FileInfo(Opd.FileName)


                If Limite.Length < limiteBytes Then


                    If Not File.Exists("\\GTMEXVTS32\APLICA\SAPYC\ANEXOS\" & NombAnexo & ExtAnexo & "") Then
                        File.Copy(Opd.FileName, "\\GTMEXVTS32\APLICA\SAPYC\ANEXOS\" & NombAnexo & ExtAnexo & "")
                    Else

                        If MessageBox.Show("Este archivo ya existe, desea reemplazarlo", "Titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                            File.Delete("\\GTMEXVTS32\APLICA\SAPYC\ANEXOS\" & NombAnexo & ExtAnexo & "")
                            File.Copy(Opd.FileName, "\\GTMEXVTS32\APLICA\SAPYC\ANEXOS\" & NombAnexo & ExtAnexo & "")
                        End If

                    End If
                    ''''INSERTA EL CONTROL DE LOS ANEXOS
                    InsertaControlAnexos(sFile, ExtAnexo)

                    MsgBox("El archivo se cargo con éxito", MsgBoxStyle.Exclamation, "archivo anexo")

                Else

                    txtNombreAnexo.Text = ""
                    txtExtension.Text = ""
                    MsgBox("El archivo es muy pesado, el limite es de 10 MB", MsgBoxStyle.Exclamation, "archivo anexo")
                End If


            Catch ex As Exception
                MsgBox("No se adjunto el archivo Anexo", MsgBoxStyle.Exclamation, "archivo anexo")
            End Try
        End If

    End Sub

    Private Sub btnVerAnexo_Click_1(sender As Object, e As EventArgs) Handles btnVerAnexo.Click
        Try

            If File.Exists("\\GTMEXVTS32\APLICA\SAPYC\ANEXOS\" & idSAC & "-" & txtNombreAnexo.Text & txtExtension.Text) Then
                Process.Start("\\GTMEXVTS32\APLICA\SAPYC\ANEXOS\" & idSAC & "-" & txtNombreAnexo.Text & txtExtension.Text & " ")
            Else
                Process.Start(idSAC & "-" & txtNombreAnexo.Text & txtExtension.Text)
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function convierte_archivo_a_bytes(ByVal nombreArchivo As String) As Byte()
        If (Not (File.Exists(nombreArchivo))) Then Return Nothing

        Try
            Using fs As New FileStream(nombreArchivo, FileMode.Open, FileAccess.Read)
                ' se usa un arreglo de bytes del tamaño del file stream -1, en el arreglo se guardará 
                ' la secuencia en bytes del archivo
                Dim length As Int32 = Convert.ToInt32(fs.Length - 1)
                Dim data() As Byte = New Byte(length) {}
                ' Al leer la secuencia, se rellenará la matriz.                
                fs.Read(data, 0, length)
                Return data
            End Using
        Catch ex As Exception
            MsgBox("Error al convertir el archivo", MsgBoxStyle.Exclamation, "Error")
            Throw
        End Try

    End Function
    Private Sub InsertaControlAnexos(sNombAnexo As String, sExtAnexo As String)
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 19, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sNombAnexo", sNombAnexo, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sExtAnexo", sExtAnexo, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paSolicitudesSAC")
            End With


        Catch ex As Exception
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "InsertaControlAnexosSac")
        End Try
    End Sub
    Private Sub ListarArchivosAnexos()

        Try
            Dim sTabla As String = "tbAnexos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 20, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idSAC", idSAC, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paSolicitudesSAC", sTabla))

                dtAnexos = .Item(sTabla)
            End With

            If dtAnexos.Rows.Count > 0 Then
                txtNombreAnexo.Text = dtAnexos.Rows(0).Item("sNombAnexo")
                txtExtension.Text = dtAnexos.Rows(0).Item("sExtAnexo")
            Else
                txtNombreAnexo.Text = ""
                txtExtension.Text = ""
            End If

        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub

#End Region



#End Region

#Region "SUBS"

    Private Sub HabilitarCombo(cbo As ComboBox, bValor As Boolean)
        If bValor Then
            cbo.Enabled = True
        Else
            cbo.Enabled = False
        End If
    End Sub
    Private Sub CrearTablas()
        dtServicios.Columns.Add("CVE", GetType(Integer))
        dtServicios.Columns.Add("CVEOTROS", GetType(Boolean))
        dtServicios.Columns.Add("CVEOFI", GetType(String))
        dtServicios.Columns.Add("CVEAREA", GetType(String))
        dtServicios.Columns.Add("DESCOFI", GetType(String))
        dtServicios.Columns.Add("DESCAREA", GetType(String))
        dtServicios.Columns.Add("REVIND", GetType(String))
        dtServicios.Columns.Add("DESCRIPCION", GetType(String))
        dtServicios.Columns.Add("DESCOTROS", GetType(String))

        dtServiciosCarga = dtServicios.Clone()
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
    Private Sub InsertarPropuesta(idServicio As Integer, bOtros As Boolean, sCveOfi As String, sCveArea As String)
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveArea", sCveArea, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idServicio", idServicio, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@bOtros", bOtros, SqlDbType.Bit, ParameterDirection.Input)

                If bOtros Then
                    .subAddParameter("@sStatus", "R", SqlDbType.Char, ParameterDirection.Input)
                Else
                    .subAddParameter("@sStatus", "J", SqlDbType.Char, ParameterDirection.Input)
                End If

                .funExecuteSP("paDatosAsignacionSACPropuestas")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarPropuesta()")
            MsgBox("Por el momento no es posible registrar las propuestas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub EnvioCorreoIndependencia()
        Try
            Dim Dr() As DataRow

            If dtCorreosSolicitud.Rows.Count > 0 Then
                Dr = dtCorreosSolicitud.Select("sCvepersona = 'GR'")
                sNombreEncargado = Dr(0).Item("sTipoPersona").ToString()
                sCorreoEncargado = Dr(0).Item("sCorreoPersona").ToString()
                sOtroServicios = ObtenerTextoServicioOtros()

                'Dim sCorreo As String() = sMailSocio.Split(";")
                EnvioCorreoGestionRiesgo(sCorreoEncargado)
            Else
                MsgBox("Por el momento no es posible enviar el correo de notificación de revisión de otros servicio.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub ActualizarSolicitudSAC(idSAC As Integer)
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@cStatus", "J", SqlDbType.Char, ParameterDirection.Input)

                .funExecuteSP("paSolicitudesSAC")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EliminarAsignacionSAC()")
            MsgBox("Hubo un problema al registrar la información del prospecto, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub ActualizarSolicitudBG(idSAC As Integer)
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@cStatus", "S", SqlDbType.Char, ParameterDirection.Input)

                .funExecuteSP("paSolicitudesSAC")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EliminarAsignacionSAC()")
            MsgBox("Hubo un problema al registrar la información del prospecto, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub ListarOficinas()
        Try
            Dim sTabla As String = "tbOficinas"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 22, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtOficinas = .Item(sTabla)
            End With

            If dtOficinas.Rows.Count > 0 Then
                cboOficina.DataSource = dtOficinas

                cboOficina.ValueMember = "sCveOficina"
                cboOficina.DisplayMember = "sOficina"
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarServicios()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtOficinas = Nothing
        End Try
    End Sub
    Private Sub ListarDivisiones()
        Try
            Dim sTabla As String = "tbDivision"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 23, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOfi", cboOficina.SelectedValue, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtDivisiones = .Item(sTabla)
            End With

            If dtDivisiones.Rows.Count > 0 Then
                cboDivision.DataSource = dtDivisiones

                cboDivision.ValueMember = "sCveDivision"
                cboDivision.DisplayMember = "sDivision"
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarServicios()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtDivisiones = Nothing
        End Try
    End Sub
    Private Sub ValidaNormatividad()

        ' Determina si existe el área AUD
        Dim bMarco As Boolean = dtServicios.AsEnumerable().Any(Function(dr) dr.Field(Of String)("CVEAREA") = "AUD")

        ' Determina si el usuario ya seleccionó una opción
        Dim bSupervisado As Boolean = rdEntidadSupervisadaSi.Checked OrElse rdEntidadSupervisadaNo.Checked

        ' Aplica reglas según el marco normativo
        If bMarco Then
            SeleccionarEntidadSupervisada(True, bloquear:=True)
        Else
            If bSupervisado Then
                SeleccionarEntidadSupervisada(False, bloquear:=True)
            Else
                LimpiarEntidadSupervisada()
            End If
        End If

    End Sub
    Private Sub SeleccionarEntidadSupervisada(esSupervisada As Boolean, bloquear As Boolean)

        rdEntidadSupervisadaSi.Checked = esSupervisada
        rdEntidadSupervisadaNo.Checked = Not esSupervisada
        cboEntidadSupervisada.SelectedIndex = 0

        rdEntidadSupervisadaSi.AutoCheck = Not bloquear
        rdEntidadSupervisadaNo.AutoCheck = Not bloquear

    End Sub
    Private Sub LimpiarEntidadSupervisada()

        rdEntidadSupervisadaSi.Checked = False
        rdEntidadSupervisadaNo.Checked = False
        cboEntidadSupervisada.SelectedIndex = 0

        rdEntidadSupervisadaSi.AutoCheck = True
        rdEntidadSupervisadaNo.AutoCheck = True

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
    Private Sub EnvioCorreoGestionRiesgo(sMail As String)
        Dim sMensaje As String

        Try
            'Dim sCorreos = "Octavio.A.Cervantes@mx.gt.com; Mario.Rodriguez@mx.gt.com"
            Dim sCorreos = sMail
            Dim sCorreo As String() = sCorreos.Split(";")


            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">SOLICITUD DE REVISIÓN DE OTROS SERVICIOS</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado equipo de " & sNombreEncargado.ToUpper() & ": </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Por medio del presente, les informo que hemos realizado el primer contacto con el cliente prospecto " & txtRazonSocial.Text.ToUpper.Trim() & " " & "," & " " & cboEntidadMercantilRS.SelectedItem("sCveSociedad") & ", quien ha mostrado interés en nuestros servicios y ha solicitado recibir una propuesta formal. </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Para continuar con este proceso, solicitamos de su apoyo para llevar a cabo la revisión de la viabilidad para prestar el servicio solicitado, el cual se encuentra clasificado como ""Otros"" y se detalla en la presente solicitud.</p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtRazonSocial.Text.ToUpper.Trim() & " " & "," & " " & cboEntidadMercantilRS.SelectedItem("sCveSociedad") & "</b></td></tr>" & vbNewLine &
            "<tr><td>Servicio:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sOtroServicios.ToUpper() & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
                "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para cualquier aclaración sobre el tema contactar a Tatiana.L.Lopez@mx.gt.com" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Solicitud de revisión de otros servicios")

        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub EnvioCorreoBackGround(sMail As String)
        Dim sMensaje As String

        Try
            ' Dim sCorreos = "Octavio.A.Cervantes@mx.gt.com; Mario.Rodriguez@mx.gt.com"
            Dim sCorreos = sMail
            Dim sCorreo As String() = sCorreos.Split(";")

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">NOTIFICACIÓN DE PRIMER CONTACTO CON CLIENTE PROSPECTO</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado equipo de " & sNombreEncargado.ToUpper() & ": </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Por medio del presente, les informo que hemos realizado el primer contacto con el cliente prospecto " & txtRazonSocial.Text.ToUpper.Trim() & " " & "," & " " & cboEntidadMercantilRS.SelectedItem("sCveSociedad") & ", quien ha mostrado interés en nuestros servicios y ha solicitado recibir una propuesta formal. </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Para continuar con este proceso, solicitamos de su apoyo para llevar a cabo la revisión del nivel de riesgo </p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtRazonSocial.Text.ToUpper.Trim() & " " & "," & " " & cboEntidadMercantilRS.SelectedItem("sCveSociedad") & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
                "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para cualquier aclaración sobre el tema contactar a Tatiana.L.Lopez@mx.gt.com" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Notificación de primer contacto con cliente prospecto")

        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub


#Region "DATOS GENERALES"

    Private Sub Aplicar_FiltroNombre()
        gridClientesSAT.Visible = True
        ' filtrar por el campo Nombrecte
        Dim ret As Integer = Filtrar_DataGridView("NOMBRE", txtRazonSocial.Text.Trim, bsCli, gridClientesSAT)

        If ret <= 0 Then
            txtRazonSocial.BackColor = Color.White
            gridClientesSAT.Visible = False
        End If
    End Sub
    Public Sub CargaClientesDatosGenerales()
        Try
            Dim sTabla As String = "tbDatosGrals"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtDatGrals = .Item(sTabla)
            End With

            If dtDatGrals.Rows.Count > 0 Then
                bsCli.DataSource = dtDatGrals

                ConfigurarColumnasGrid(gridClientesSAT, "LISTADO", "LISTA", 80, 3, False)
                ConfigurarColumnasGrid(gridClientesSAT, "NOMBRE", "NOMBRE", 0, 1, False)
            Else
                lblMensajeCargaContactoInicial.Visible = True
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "CargaClientesDatosGenerales()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtDatGrals = Nothing
        End Try

    End Sub
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

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable("paDatosGeneralesKardex", sTabla))

                dtNormatividad = .Item(sTabla)
            End With

            If dtNormatividad.Rows.Count > 0 Then
                cboEntidadSupervisada.DataSource = dtNormatividad

                cboEntidadSupervisada.ValueMember = "idNormatividad"
                cboEntidadSupervisada.DisplayMember = "sNormatividad"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarNormatividad()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtNormatividad = Nothing
        End Try
    End Sub
    Private Sub ListarPais()
        Try
            Dim sTabla As String = "tbPais"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtPais = .Item(sTabla)
            End With

            If dtPais.Rows.Count > 0 Then
                cboPais.DataSource = dtPais

                cboPais.ValueMember = "idPais"
                cboPais.DisplayMember = "sPais"
            End If

            cboPais.SelectedIndex = 0
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "listarOficinasPpto()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtPais = Nothing
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
                lblMensajeCargaDatosGenerales.Visible = False

                txtRazonSocial.Text = dtDatosGenerales.Rows(0).Item("sRazonSocial").ToString

                txtNombreComercial.Text = dtDatosGenerales.Rows(0).Item("sNombreComercial").ToString

                cboEntidadMercantilRS.Text = dtDatosGenerales.Rows(0).Item("sMercantil").ToString
                cboEntidadMercantilNC.Text = dtDatosGenerales.Rows(0).Item("sMercantil").ToString


                txtDescripcionSolicitud.Text = dtDatosGenerales.Rows(0).Item("sDescripcionServicio").ToString

                txtRFC.Text = dtDatosGenerales.Rows(0).Item("sRFC").ToString
                txtIndustria.Text = dtDatosGenerales.Rows(0).Item("sIndustria").ToString

                sInd = dtDatosGenerales.Rows(0).Item("idInd").ToString
                sCveInd = dtDatosGenerales.Rows(0).Item("idInd").ToString
                sCveSS = dtDatosGenerales.Rows(0).Item("IdSubSec").ToString
                sCveGTI = dtDatosGenerales.Rows(0).Item("sCveGti").ToString

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

                If bMarco Then
                    rdEntidadSupervisadaSi.Checked = True
                    rdEntidadSupervisadaNo.Checked = False

                    rdEntidadSupervisadaSi.AutoCheck = False
                    rdEntidadSupervisadaNo.AutoCheck = False
                Else
                    If CBool(dtDatosGenerales.Rows(0).Item("bEntidadSupervisada").ToString) = True Then
                        rdEntidadSupervisadaSi.Checked = True
                    Else
                        rdEntidadSupervisadaNo.Checked = True
                    End If

                    rdEntidadSupervisadaSi.AutoCheck = True
                    rdEntidadSupervisadaNo.AutoCheck = True
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
                txtOperacion.Text = dtDatosGenerales.Rows(0).Item("sOperacionEmpresa").ToString


            Else
                lblMensajeCargaDatosGenerales.Visible = True
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDatosGenerales()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtDatosGenerales = Nothing
        End Try
    End Sub
    Private Sub InsertarDatosGenerales()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idProspecto", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", "", SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sRazonSocial", txtRazonSocial.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sMercantiles", cboEntidadMercantilRS.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sNombreComercial", txtNombreComercial.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sDescripcionServicio", txtDescripcionSolicitud.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sRFC", txtRFC.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sIndustria", txtIndustria.Text, SqlDbType.VarChar, ParameterDirection.Input)
                If rdPersonalMoral.Checked Then
                    .subAddParameter("@sTipoNegocio", "M", SqlDbType.Char, ParameterDirection.Input)
                ElseIf rdPersonaFisica.Checked Then
                    .subAddParameter("@sTipoNegocio", "F", SqlDbType.Char, ParameterDirection.Input)
                End If

                If rdEmpresaPublicaSi.Checked Then
                    .subAddParameter("@bPublica", 1, SqlDbType.Bit, ParameterDirection.Input)
                Else
                    .subAddParameter("@bPublica", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If
                .subAddParameter("@idBolsaValores", cboBolsaValores.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sOtraBolsa", txtBolsaValoresOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)

                If rdSubsidiariaSi.Checked Then
                    .subAddParameter("@bSubsidiaria", 1, SqlDbType.Bit, ParameterDirection.Input)
                Else
                    .subAddParameter("@bSubsidiaria", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If

                If rdControladoraSi.Checked Then
                    .subAddParameter("@bControlador", 1, SqlDbType.Bit, ParameterDirection.Input)
                Else
                    .subAddParameter("@bControlador", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If

                If rdEntidadReguladaSi.Checked Then
                    .subAddParameter("@bReguladora", 1, SqlDbType.Bit, ParameterDirection.Input)
                Else
                    .subAddParameter("@bReguladora", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If
                .subAddParameter("@idEntidadReguladora", cboEntidadReguladora.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sOtraEntidad", txtEntidadReguladoraOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idPais", idPais, SqlDbType.Int, ParameterDirection.Input)

                If rdEntidadSupervisadaSi.Checked Then
                    .subAddParameter("@bEntidadSupervisada", 1, SqlDbType.Bit, ParameterDirection.Input)
                Else
                    .subAddParameter("@bEntidadSupervisada", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If

                .subAddParameter("@idNormatividad", cboEntidadSupervisada.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sOtraNormatividad", txtEntidadSupervisadaOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)

                If rdReferenciaGTISi.Checked Then
                    .subAddParameter("@bRefGTI", 1, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@sNombSocioRefGTI", txtReferenciaGTISocio.Text.ToUpper, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@IdPaisRefGTI", idPaisGT, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idOficinaRefGTI", cboReferenciaGTIOficina.Text, SqlDbType.VarChar, ParameterDirection.Input)
                Else
                    .subAddParameter("@bRefGTI", 0, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@sNombSocioRefGTI", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@IdPaisRefGTI", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idOficinaRefGTI", "", SqlDbType.VarChar, ParameterDirection.Input)
                End If

                If rdEmpresaExtranjeroRepSi.Checked Then
                    .subAddParameter("@bReportaExtranjero", 1, SqlDbType.Bit, ParameterDirection.Input)
                Else
                    .subAddParameter("@bReportaExtranjero", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If

                .subAddParameter("@sNombTenedora", txtEmpresaTenedora.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idPaisTenedora", idPaisTenedora, SqlDbType.Int, ParameterDirection.Input)

                If rdEmpresaExtranjeroDomSi.Checked Then
                    .subAddParameter("@bDomiciliadas", 1, SqlDbType.Bit, ParameterDirection.Input)
                Else
                    .subAddParameter("@bDomiciliadas", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If

                .subAddParameter("@idTipoEntidad", cboTipoEntidad.SelectedValue, SqlDbType.Int, ParameterDirection.Input)

                If rdEmpresaExtranjeroSubSi.Checked Then
                    .subAddParameter("@bSubsidiarias", 1, SqlDbType.Bit, ParameterDirection.Input)
                Else
                    .subAddParameter("@bSubsidiarias", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If

                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveInd", sCveInd, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveSS", sCveSS, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveGTI", sCveGTI, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@bRecurrente", 0, SqlDbType.Bit, ParameterDirection.Input)
                .subAddParameter("@sCveOfi", cboOficina.SelectedValue, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveArea", cboDivision.SelectedValue, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveSocio", "", SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idServicio", 0, SqlDbType.Int, ParameterDirection.Input)
                If rdIdiomaSi.Checked Then
                    .subAddParameter("@bIdioma", 1, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@idIdioma", idIdioma, SqlDbType.Int, ParameterDirection.Input)
                Else
                    .subAddParameter("@bIdioma", 0, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@idIdioma", 40, SqlDbType.Int, ParameterDirection.Input)
                End If
                .subAddParameter("@dFechaIni", txtPeriodoInicio.Value, SqlDbType.DateTime, ParameterDirection.Input)
                .subAddParameter("@dFechaFin", txtPeriodoFinal.Value, SqlDbType.DateTime, ParameterDirection.Input)
                .subAddParameter("@dFechaEntrega", txtFechaEntregaReporte.Value, SqlDbType.DateTime, ParameterDirection.Input)
                .subAddParameter("@dFechaPropuesta", txtFechaSolicitud.Value, SqlDbType.DateTime, ParameterDirection.Input)
                .subAddParameter("@idModalidad", cboModalidades.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCorreoSocRefGTI", txtCorreoSocioGTI.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sGerenteRefGTI", txtGerenteGTI.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCorreoGerRefGTI", txtCorreoGerenteGTI.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sEstadoRefGTI", txtEstadoGTI.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sOperacion", txtOperacion.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACDatosGenerales")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertaGeneral()")
            MsgBox("Por el momento no es posible registrar la información del prospecto, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub InsertarServiciosDatosGenerales(idServicio As Integer, bOtros As Boolean, sOtros As String, sCveOfi As String, sCveArea As String)
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idServicio", idServicio, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveArea", sCveArea, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@bOtros", bOtros, SqlDbType.Bit, ParameterDirection.Input)
                .subAddParameter("@sOtrosServicios", sOtros, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACDatosGenerales")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertaGeneral()")
            MsgBox("Por el momento no es posible registrar la información del prospecto, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub EliminarServiciosDatosGenerales(idServicio As Integer)
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idServicio", idServicio, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACDatosGenerales")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertaGeneral()")
            MsgBox("Por el momento no es posible registrar la información del prospecto, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub ListarServiciosDatosGenerales()
        Try
            Dim sTabla As String = "tbServDatosGenerales"
            Dim sOtroServicios As String = ""

            bOtros = False

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACDatosGenerales", sTabla))

                dtServiciosDG = .Item(sTabla)
            End With

            If dtServiciosDG.Rows.Count > 0 Then
                For Each row As DataRow In dtServiciosDG.Rows
                    drServicios = dtServicios.NewRow()
                    drServicios("CVE") = row.Item("idServicio")
                    drServicios("CVEOTROS") = row.Item("bOtros")
                    drServicios("CVEOFI") = row.Item("sCveOfi")
                    drServicios("CVEAREA") = row.Item("sCveArea")
                    drServicios("DESCOFI") = row.Item("DESCOFI")
                    drServicios("DESCAREA") = row.Item("DESCAREA")
                    drServicios("REVIND") = "S"
                    drServicios("DESCRIPCION") = row.Item("DESCRIPCION")
                    drServicios("DESCOTROS") = row.Item("sOtrosServicios")
                    dtServicios.Rows.InsertAt(drServicios, dtServicios.Rows.Count)

                    drServicios = dtServiciosCarga.NewRow()
                    drServicios("CVE") = row.Item("idServicio")
                    drServicios("CVEOTROS") = row.Item("bOtros")
                    drServicios("CVEOFI") = row.Item("sCveOfi")
                    drServicios("CVEAREA") = row.Item("sCveArea")
                    drServicios("DESCOFI") = row.Item("DESCOFI")
                    drServicios("DESCAREA") = row.Item("DESCAREA")
                    drServicios("REVIND") = "S"
                    drServicios("DESCRIPCION") = row.Item("DESCRIPCION")
                    drServicios("DESCOTROS") = row.Item("sOtrosServicios")
                    dtServiciosCarga.Rows.InsertAt(drServicios, dtServiciosCarga.Rows.Count)

                    If bOtrosCarga = False Then
                        bOtrosCarga = row.Item("bOtros")
                    End If

                    If bOtrosCarga Then
                        bOtros = True
                        sOtroServicios = row.Item("sOtrosServicios")
                        bOtrosCarga = False
                    End If
                Next

                bOtros = dtServicios.AsEnumerable().Any(Function(dr) dr.Field(Of Boolean)("CVEOTROS"))
                ValidaNormatividad()

                bsSer.DataSource = dtServicios
                gridServicios.Columns("CVE").Visible = False
                gridServicios.Columns("CVEOTROS").Visible = False
                gridServicios.Columns("CVEOFI").Visible = False
                gridServicios.Columns("CVEAREA").Visible = False
                gridServicios.Columns("REVIND").Visible = False

                ConfigurarColumnasGrid(gridServicios, "DESCOFI", "OFICINA", 80, 3, False)
                ConfigurarColumnasGrid(gridServicios, "DESCAREA", "DIVISIÓN", 80, 3, False)
                ConfigurarColumnasGrid(gridServicios, "DESCRIPCION", "SERVICIO", 0, 1, False)
                ConfigurarColumnasGrid(gridServicios, "DESCOTROS", "DESCRIPCIÓN 'OTROS'", 0, 1, False)
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarServiciosDatosGenerales()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtServiciosDG = Nothing
        End Try
    End Sub

    Private Sub ListarEntidadesMercantilesRS()
        Try
            Dim sTabla As String = "tbEntidadMercantilRS"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACDatosGenerales", sTabla))

                dtMercantilesRS = .Item(sTabla)
            End With

            If dtMercantilesRS.Rows.Count > 0 Then
                cboEntidadMercantilRS.DataSource = dtMercantilesRS

                cboEntidadMercantilRS.ValueMember = "idSociedad"
                cboEntidadMercantilRS.DisplayMember = "sCveSociedad"
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarModalidades()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtMercantilesRS = Nothing
        End Try
    End Sub
    Private Sub ListarEntidadesMercantilesNC()
        Try
            Dim sTabla As String = "tbEntidadMercantilNC"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACDatosGenerales", sTabla))

                dtMercantilesNC = .Item(sTabla)
            End With

            If dtMercantilesNC.Rows.Count > 0 Then
                cboEntidadMercantilNC.DataSource = dtMercantilesNC

                cboEntidadMercantilNC.ValueMember = "idSociedad"
                cboEntidadMercantilNC.DisplayMember = "sCveSociedad"
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarModalidades()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtMercantilesNC = Nothing
        End Try
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

                lblMensajeCargaContactoInicial.Visible = False

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
            Else
                lblMensajeCargaContactoInicial.Visible = True
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarContactoInicial()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtContactoInicial = Nothing
        End Try
    End Sub
    Private Sub InsertarContactoInicial()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sNombrePrimerContacto", txtContactoInicialPrimerContacto.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@dFechaContacto", txtContactoInicialFecha.Value, SqlDbType.Date, ParameterDirection.Input)
                .subAddParameter("@sNombreContacto", txtContactoInicialNombre.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCorreo", txtContactoInicialCorreo.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCargo", txtContactoInicialCargo.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sTelefono", txtContactoInicialTelefono.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sExtension", txtContactoInicialExtension.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sTelefonoCelular", txtContactoInicialCelular.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sWeb", txtAcercamientoWebProspecto.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACContactoInicial")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarContactoInicial()")
            MsgBox("Por el momento no es posible guardar la información del Contacto Inicial, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
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
                txtAcercamientoEnteroOtro.Enabled = False
                lblAcercamientoOtro.Text = "Otro"

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
                lblMensajeCargaAcercamiento.Visible = False

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

            Else
                lblMensajeCargaAcercamiento.Visible = True
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarAcercamiento()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtAcercamiento = Nothing
        End Try
    End Sub
    Private Sub InsertarAcercamiento()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idAcercamiento", cboAcercamientoComoEntero.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sOtroAcercamiento", txtAcercamientoEnteroOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idMedio", cboAcercamientoMedioContacto.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sotroMedio", txtAcercamientoContactoOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACAcercamiento")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarAcercamiento()")
            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
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

        cboDomicilioPais.SelectedValue = 0
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
                lblMensajeCargaDomicilio.Visible = False
                lblMensajeBloqueoDomicilio.Visible = False

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
                    cboDomicilioPais.SelectedValue = CInt(dtDomicilio.Rows(0).Item("idPais").ToString())
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
                lblMensajeCargaDomicilio.Visible = True
                lblMensajeBloqueoDomicilio.Visible = True

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
    Private Sub InsertarDomicilio()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPais", idPaisDom, SqlDbType.Int, ParameterDirection.Input)
                If idPaisDom = 151 Then
                    .subAddParameter("@sCalle", txtDomicilioCalle.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sNumExt", txtDomicilioNoExt.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sNumInt", txtDomicilioNoInt.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCP", txtDomicilioCP.Text, SqlDbType.VarChar, ParameterDirection.Input)

                    .subAddParameter("@idColonia", cboDomicilioColonia.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idEstado", cboDomicilioEstado.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idMunicipio", cboDomicilioMunicipio.SelectedValue, SqlDbType.Int, ParameterDirection.Input)

                    .subAddParameter("@sColonia", cboDomicilioColonia.SelectedText, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sEstado", cboDomicilioEstado.SelectedText, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sMunicipio", cboDomicilioMunicipio.SelectedText, SqlDbType.VarChar, ParameterDirection.Input)
                Else
                    .subAddParameter("@idColonia", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idEstado", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idMunicipio", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sNumExt", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sNumInt", "", SqlDbType.VarChar, ParameterDirection.Input)

                    .subAddParameter("@sCalle", txtDomicilioExtDireccion1.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sColonia", txtDomicilioExtDireccion2.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sMunicipio", txtDomicilioExtLocalidad.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sEstado", txtDomicilioExtEstado.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCP", txtDomicilioExtCP.Text, SqlDbType.VarChar, ParameterDirection.Input)
                End If
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACDomicilio")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarDomicilio()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub

#End Region

#End Region

#Region "FUNCIONES"

    Private Function GenerarNuevoProspecto(idProspecto As Integer) As String
        Dim sCve As String = "PRS"

        Select Case idProspecto
            Case 0 To 8
                sCve &= "00000" & (idProspecto + 1)

            Case 9
                sCve &= "0000" & (idProspecto + 1)

            Case 10 To 98
                sCve &= "0000" & (idProspecto + 1)

            Case 99
                sCve &= "000" & (idProspecto + 1)

            Case 100 To 998
                sCve &= "000" & (idProspecto + 1)

            Case 999
                sCve &= "00" & (idProspecto + 1)

            Case 1000 To 9998
                sCve &= "00" & (idProspecto + 1)

            Case 9999
                sCve &= "0" & (idProspecto + 1)

            Case 10000 To 99998
                sCve &= "0" & (idProspecto + 1)

            Case Else
                sCve &= (idProspecto + 1)
        End Select

        Return sCve
    End Function
    Private Function ValidarContactoInicial() As Boolean
        Dim bValidacion As Boolean = True

        sMsgContacto = vbNewLine & CONTACTO_INICIAL & vbNewLine
        sMsgContacto &= "===============================" & vbNewLine

        If Trim(txtContactoInicialPrimerContacto.Text) = "" Then
            sMsgContacto &= "- Especifíque el nombre de la persona que tuvo el primer contacto." & vbNewLine & vbNewLine

            bValidacion = False
        End If

        If Trim(txtContactoInicialNombre.Text) = "" Then
            sMsgContacto &= "- Especifíque el nombre del contacto inicial del prospecto." & vbNewLine & vbNewLine

            bValidacion = False
        End If

        If Trim(txtContactoInicialCorreo.Text) = "" Then
            sMsgContacto &= "- Especifíque el correo electrónico del contacto inicial del prospecto." & vbNewLine & vbNewLine

            bValidacion = False
        End If

        If Trim(txtContactoInicialCargo.Text) = "" Then
            sMsgContacto &= "- Especifíque el cargo del contacto inicial del prospecto." & vbNewLine & vbNewLine

            bValidacion = False
        End If

        If Trim(txtContactoInicialTelefono.Text) = "" Then
            sMsgContacto &= "- Especifíque el número de teléfono del contacto inicial." & vbNewLine & vbNewLine

            bValidacion = False
        End If

        sMsgContacto = sMsgContacto.Remove(sMsgContacto.Length - vbNewLine.Length * 2)
        sMsgContacto &= vbNewLine & "===============================" & vbNewLine

        Return bValidacion
    End Function
    Private Function ValidarAcercamiento() As Boolean
        Dim bValidacion As Boolean = True

        sMsgAcercamiento = vbNewLine & ACERCAMIENTO & vbNewLine
        sMsgAcercamiento &= "===============================" & vbNewLine

        If cboAcercamientoMedioContacto.SelectedIndex <= 0 Then
            sMsgAcercamiento &= "- Seleccione el medio de contacto que utilizó el prospecto para contactarnos." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If cboAcercamientoMedioContacto.SelectedIndex = 10 AndAlso Trim(txtAcercamientoContactoOtro.Text) = "" Then
            sMsgAcercamiento &= "- Especifíque cómo se enteró el prospecto sobre nosotros." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If cboAcercamientoComoEntero.SelectedIndex <= 0 Then
            sMsgAcercamiento &= "- Seleccione la opción de como se enteró el prospecto sobre nosotros." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If cboAcercamientoComoEntero.SelectedValue = 13 AndAlso Trim(txtAcercamientoEnteroOtro.Text) = "" Then
            sMsgAcercamiento &= "- Especifíque el medio de contacto que utilizó el prospecto para contactarnos." & vbNewLine & vbNewLine
            bValidacion = False
        ElseIf cboAcercamientoComoEntero.SelectedValue = 7 AndAlso Trim(txtAcercamientoEnteroOtro.Text) = "" Then
            sMsgAcercamiento &= "- Especifíque el nombre del socio que referenció al prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        ElseIf cboAcercamientoComoEntero.SelectedValue = 8 AndAlso Trim(txtAcercamientoEnteroOtro.Text) = "" Then
            sMsgAcercamiento &= "- Especifíque el nombre del gerente que referenció al prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        ElseIf cboAcercamientoComoEntero.SelectedValue = 12 AndAlso Trim(txtAcercamientoEnteroOtro.Text) = "" Then
            sMsgAcercamiento &= "- Especifíque el nombre del colaborador que referenció al prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        sMsgAcercamiento = sMsgAcercamiento.Remove(sMsgAcercamiento.Length - vbNewLine.Length * 2)
        sMsgAcercamiento &= vbNewLine & "===============================" & vbNewLine

        Return bValidacion
    End Function
    Private Function ValidarDomicilio() As Boolean
        Dim bValidacion As Boolean = True

        sMsgDomicilio = vbNewLine & DOMICILIO & vbNewLine
        sMsgDomicilio &= "===============================" & vbNewLine

        If idPaisDom <= 0 Then
            sMsgDomicilio &= "- Seleccione el país del domicilio del prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If idPaisDom <> 151 Then
            If Trim(txtDomicilioExtDireccion1.Text) = "" Then
                sMsgDomicilio &= "- Especifíque calle y número de la dirección del prospecto." & vbNewLine & vbNewLine
                bValidacion = False
            End If

            If Trim(txtDomicilioExtLocalidad.Text) = "" Then
                sMsgDomicilio &= "- Especifíque la Ciudad / Localidad de la dirección del prospecto." & vbNewLine & vbNewLine
                bValidacion = False
            End If

            If Trim(txtDomicilioExtEstado.Text) = "" Then
                sMsgDomicilio &= "- Especifíque el Estado / Provincia / Región de la dirección del prospecto." & vbNewLine & vbNewLine
                bValidacion = False
            End If

            If Trim(txtDomicilioExtCP.Text) = "" Then
                sMsgDomicilio &= "- Especifíque el Código Postal de la dirección del prospecto." & vbNewLine & vbNewLine
                bValidacion = False
            End If
        Else
            If Trim(txtDomicilioCalle.Text) = "" Then
                sMsgDomicilio &= "- Especifíque la calle de la dirección del prospecto." & vbNewLine & vbNewLine
                bValidacion = False
            End If

            If Trim(txtDomicilioNoExt.Text) = "" Then
                sMsgDomicilio &= "- Especifíque el número exterior de la dirección del prospecto." & vbNewLine & vbNewLine
                bValidacion = False
            End If

            If Trim(txtDomicilioCP.Text) = "" Then
                sMsgDomicilio &= "- Especifíque el código postal de la dirección del prospecto." & vbNewLine & vbNewLine
                bValidacion = False
            End If
        End If

        sMsgDomicilio = sMsgDomicilio.Remove(sMsgDomicilio.Length - vbNewLine.Length * 2)
        sMsgDomicilio &= vbNewLine & "===============================" & vbNewLine

        Return bValidacion
    End Function
    Private Function ValidarDatosGenerales() As Boolean
        Dim bValidacion As Boolean = True

        sMsgDatosGenerales = DATOS_GENERALES & vbNewLine
        sMsgDatosGenerales &= "===============================" & vbNewLine

        If Trim(txtRazonSocial.Text) = "" Then
            sMsgDatosGenerales &= "- Especifíque la razón social del prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If cboEntidadMercantilRS.SelectedValue = 0 Then
            sMsgDatosGenerales &= "- Especifíque la entidad mercantil de la razón social." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If Trim(txtNombreComercial.Text) = "" Then
            sMsgDatosGenerales &= "- Especifíque el nombre comercial del prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If cboEntidadMercantilNC.SelectedValue = 0 Then
            sMsgDatosGenerales &= "- Especifíque la entidad mercantil del nombre comercial." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If sCveInd = "" Then
            sMsgDatosGenerales &= "- Especifíque la industria del prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If cboOficina.SelectedValue = "" Then
            sMsgDatosGenerales &= "- Seleccione la oficina para generar la solicitud." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If cboDivision.SelectedValue = "" Then
            sMsgDatosGenerales &= "- Seleccione la división para generar la solicitud." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If dtServicios.Rows.Count <= 0 Then
            sMsgDatosGenerales &= "- Seleccione por lo menos un servicio para generar la solicitud." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdIdiomaSi.Checked = False And rdIdiomaNo.Checked = False Then
            sMsgDatosGenerales &= "- Especifíque si se requiere de personal bilingüe." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If Trim(txtDescripcionSolicitud.Text) = "" Then
            sMsgDatosGenerales &= "- Especifíque Información adicional del prospecto y/o del servicio." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If txtPeriodoInicio.Value > txtPeriodoFinal.Value Then
            sMsgDatosGenerales &= "- La fecha de inicio del periodo no puede ser igual o posterior a la fecha final del periodo de prestación del servicio." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If cboModalidades.SelectedValue <= 0 Then
            sMsgDatosGenerales &= "- Seleccione la modalidad del servicio solicitado por el prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If idPais <= 0 Then
            sMsgDatosGenerales &= "- Seleccione el país del prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdEmpresaPublicaSi.Checked = False And rdEmpresaPublicaNo.Checked = False Then
            sMsgDatosGenerales &= "- Especifíque si el prospecto es una empresa pública." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdEmpresaPublicaSi.Checked = True And cboBolsaValores.SelectedIndex = 0 Then
            sMsgDatosGenerales &= "- Especifíque la bolsa de valores." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdEmpresaPublicaSi.Checked = True And cboBolsaValores.SelectedIndex = 5 And Trim(txtBolsaValoresOtro.Text) = "" Then
            sMsgDatosGenerales &= "- Especifíque el nombre de la bolsa de valores." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdSubsidiariaSi.Checked = False And rdSubsidiariaNo.Checked = False Then
            sMsgDatosGenerales &= "- Especifíque si el prospecto es una subsidiaria." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdSubsidiariaSi.Checked = True And rdControladoraSi.Checked = False And rdControladoraNO.Checked = False Then
            sMsgDatosGenerales &= "- Especifíque si el prospecto reportará a su compañia controladora." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdEntidadReguladaSi.Checked = False And rdEntidadReguladaNo.Checked = False Then
            sMsgDatosGenerales &= "- Especifíque si el prospecto es una entidad regulada." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdEntidadReguladaSi.Checked = True And cboEntidadReguladora.SelectedIndex = 0 Then
            sMsgDatosGenerales &= "- Especifíque la entidad reguladora para el prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdEntidadReguladaSi.Checked = True And cboEntidadReguladora.SelectedIndex = 8 And Trim(txtEntidadReguladoraOtro.Text) = "" Then
            sMsgDatosGenerales &= "- Especifíque el nombre de la entidad reguladora para el prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdEntidadSupervisadaSi.Checked = False And rdEntidadSupervisadaNo.Checked = False Then
            sMsgDatosGenerales &= "- Especifíque si el prospecto es una entidad supervisada." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdEntidadSupervisadaSi.Checked = True And cboEntidadSupervisada.SelectedIndex = 0 Then
            sMsgDatosGenerales &= "- Especifíque la normatividad para el prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdEntidadSupervisadaSi.Checked = True And cboEntidadSupervisada.SelectedIndex = 6 And Trim(txtEntidadSupervisadaOtro.Text) = "" Then
            sMsgDatosGenerales &= "- Especifíque el nombre de la normatividad para el prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdReferenciaGTISi.Checked = False And rdReferenciaGTINo.Checked = False Then
            sMsgDatosGenerales &= "- Especifíque si el prospecto es una referencia de GTI." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If Trim(txtReferenciaGTISocio.Text) = "" And rdReferenciaGTISi.Checked = True Then
            sMsgDatosGenerales &= "- Especifíque el nombre del socio de GTI que referenció al prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If Trim(txtCorreoSocioGTI.Text) = "" And rdReferenciaGTISi.Checked = True Then
            sMsgDatosGenerales &= "- Especifíque el correo electrónico del socio de GTI que referenció al prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdReferenciaGTISi.Checked = True And idPaisGT <= 0 Then
            sMsgDatosGenerales &= "- Especifíque el país de referencia de GTI." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdReferenciaGTISi.Checked = True And cboReferenciaGTIPais.SelectedIndex > 0 And Trim(txtEstadoGTI.Text) = "" Then
            sMsgDatosGenerales &= "- Especifíque el Estado de la referencia de GTI." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdEmpresaExtranjeroRepSi.Checked = False And rdEmpresaExtranjeroRepNo.Checked = False Then
            sMsgDatosGenerales &= "- Especifíque si el prospecto reporta al extranjero." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdEmpresaExtranjeroRepSi.Checked = True And idPaisTenedora <= 0 Then
            sMsgDatosGenerales &= "- Especifíque el país de residencia de la empresa tenedora." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If rdEmpresaExtranjeroRepSi.Checked = True And Trim(txtEmpresaTenedora.Text) = "" Then
            sMsgDatosGenerales &= "- Especifíque el nombre de la empresa tenedora." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If cboEntidadMercantilRS.SelectedIndex <> cboEntidadMercantilNC.SelectedIndex Then
            sMsgDatosGenerales &= "- Especifíque la misma entidad mercantil de la razon social y el nombre comercial." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If cboTipoEntidad.SelectedIndex = 0 Then
            sMsgDatosGenerales &= "- Especifíque el tipo de entidad del prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If Trim(txtOperacion.Text) = "" Then
            sMsgDatosGenerales &= "- Especifíque la operación de la empresa." & vbNewLine & vbNewLine
            bValidacion = False
        End If



        sMsgDatosGenerales = sMsgDatosGenerales.Remove(sMsgDatosGenerales.Length - vbNewLine.Length * 2)
        sMsgDatosGenerales &= vbNewLine & "===============================" & vbNewLine

        Return bValidacion
    End Function
    Private Function ExisteRFC(Rfc As String) As Boolean
        Dim Resp As Boolean = False
        Try
            With ds.Tables
                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iTipo", 3, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sRfc", Rfc, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paConsultaTrabajoRecurrente") Then
                    .Remove("paConsultaTrabajoRecurrente")
                End If

                .Add(clsDatos.funExecuteSPDataTable("paConsultaTrabajoRecurrente"))

                dtRfc = .Item("paConsultaTrabajoRecurrente")
                If dtRfc.Rows.Count > 0 Then
                    Resp = True
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return Resp

    End Function
    Private Function ExisteIDSAC(idsac As String) As Boolean
        Dim Resp As Boolean = False
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 11, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@IdSac", idsac, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paControlSac") Then
                    .Remove("paControlSac")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paControlSac"))

                dtIdSac = .Item("paControlSac")
                If dtIdSac.Rows.Count > 0 Then
                    Resp = True
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return Resp

    End Function
    Private Function ObtenerTextoServicioOtros() As String
        Dim sTexto As String = ""

        sTexto = dtServicios.AsEnumerable().Where(Function(dr) dr.Field(Of Boolean)("CVEOTROS") = True).Select(Function(dr) dr.Field(Of String)("DESCOTROS")).FirstOrDefault()

        Return sTexto
    End Function

#End Region

    Private Sub AgregarTexto(gra As XGraphics, font As XFont, color As XSolidBrush, sTexto As String, x As Integer, y As Integer, ancho As Integer, alto As Integer, iAlinea As Integer)
        Select Case iAlinea
            Case 1
                gra.DrawString(sTexto, font, color, New XRect(x, y, ancho, alto), XStringFormats.CenterLeft)
            Case 2
                gra.DrawString(sTexto, font, color, New XRect(x, y, ancho, alto), XStringFormats.CenterRight)
            Case 3
                gra.DrawString(sTexto, font, color, New XRect(x, y, ancho, alto), XStringFormats.Center)
        End Select
    End Sub
    Private Function TextoCampo(sTexto As String) As String
        Dim sCadena As String = ""

        If sTexto.Trim = "" Then
            sCadena = "Sin dato"
        Else
            sCadena = sTexto
        End If

        Return sCadena
    End Function
    Private Sub GenerarPDFProvisional(sNomCte As String, sNomCom As String)
        Dim pdfDoc As New PdfDocument
        Dim pdfPage As PdfPage

        Dim fontHdr As New XFont("Calibri", 17, XFontStyleEx.Bold)
        Dim fontHdr2 As New XFont("Calibri", 14, XFontStyleEx.Bold)

        Dim fontTxt As New XFont("Calibri", 13.5, XFontStyleEx.Bold)
        Dim fontTxtCam As New XFont("Calibri", 10.5, XFontStyleEx.Bold)
        Dim fontTxtReg As New XFont("Calibri", 10.5, XFontStyleEx.Regular)
        Dim fontTxtSerHdr As New XFont("Calibri", 9.5, XFontStyleEx.Bold)
        Dim fontTxtSerReg As New XFont("Calibri", 9.5, XFontStyleEx.Regular)

        Dim image As XImage = XImage.FromFile("\\GTMEXVTS32\APLICA\CON2012\IMG\header_RD.jpg")

        Dim negro As New XSolidBrush(XColor.FromArgb(0, 0, 0))
        Dim blanco As New XSolidBrush(XColor.FromArgb(255, 255, 255))
        Dim back As New XSolidBrush(XColor.FromArgb(0, 167, 181))
        Dim backRes As New XSolidBrush(XColor.FromArgb(79, 45, 127))
        Dim backSom As New XSolidBrush(XColor.FromArgb(115, 115, 115))

        Dim iValX, iValY As Integer
        Dim iValXCam As Integer = 30

        Dim iValXDG As Integer = 215
        Dim iValXCI As Integer = 215
        Dim iValXAC As Integer = 215
        Dim iValXDO As Integer = 30

        Dim iValYDGS As Integer = 275
        Dim iValYDG As Integer = 120
        Dim iValYCI As Integer = 270
        Dim iValYAC As Integer = 420
        Dim iValYDO As Integer = 420
        Dim iValYFS As Integer = (15 * (dtServicios.Rows.Count + 2))

        'Comenzar con el llenado de información para el PDF
        pdfDoc.Info.Title = "SOLICITUD REGISTRO DE CLIENTE PROSPECTO - " & sNomCte
        pdfDoc.Info.Author = "SALLES-SAINZ, GRANT THORNTON, S.C."
        pdfDoc.Info.Subject = "Datos de cliente prospecto"
        pdfDoc.Info.Keywords = "CLIENTE, PROSPECTO, SOLICITUD"

        pdfPage = pdfDoc.AddPage()
        pdfPage.Size = PdfSharp.PageSize.Letter

        iValX = pdfPage.MediaBox.Width
        iValY = pdfPage.MediaBox.Height

        Dim gra As XGraphics = XGraphics.FromPdfPage(pdfPage)
        Dim tf As New XTextFormatter(gra)

        '================ CABECERA ================
        gra.DrawImage(image, 25, 20, image.PixelWidth * 0.7, image.PixelHeight * 0.7)
        gra.DrawString("SOLICITUD REGISTRO DE CLIENTE PROSPECTO", fontHdr, New XSolidBrush(XColor.FromArgb(79, 45, 127)), New XRect(iValX - 250, 23, 220, 25), XStringFormats.CenterRight)
        gra.DrawString("NO. SAC: " & idSAC, fontHdr2, XBrushes.Black, New XRect(iValX - 250, 43, 220, 25), XStringFormats.CenterRight)

        '================ DATOS GENERALES ================
        gra.DrawString("DATOS GENERALES", fontTxt, backRes, New XRect(iValXCam, 105, iValX - 60, 14), XStringFormats.CenterLeft)
        gra.DrawRectangle(backRes, New XRect(iValXCam, iValYDG, iValX - 60, 1.5))

        AgregarTexto(gra, fontTxtCam, negro, "Razón Social: ", iValXCam, 135, 85, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(sNomCte), iValXDG, 135, 85, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "Nombre Comercial: ", iValXCam, 150, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(sNomCom), iValXDG, 150, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "RFC: ", iValXCam, 165, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(txtRFC.Text), iValXDG, 165, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "Industria: ", iValXCam, 180, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(txtIndustria.Text), iValXDG, 180, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "Requiere personal bilingüe: ", iValXCam, 195, 105, 14, 1)
        If rdIdiomaSi.Checked Then
            AgregarTexto(gra, fontTxtReg, negro, "Sí", iValXDG, 195, 105, 14, 1)
        Else
            AgregarTexto(gra, fontTxtReg, negro, "No", iValXDG, 195, 105, 14, 1)
        End If

        AgregarTexto(gra, fontTxtCam, negro, "Fecha de presentación de propuesta: ", iValXCam, 210, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(txtFechaSolicitud.Value.ToShortDateString), iValXDG, 210, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "Modalidad del trabajo: ", iValXCam, 225, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(cboModalidades.SelectedItem("sModalidad")), iValXDG, 225, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "Normatividad: ", iValXCam, 240, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(cboEntidadSupervisada.SelectedItem("sNormatividad")), iValXDG, 240, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "Servicios solicitados: ", iValXCam, 260, 105, 14, 1)
        gra.DrawRectangle(back, New XRect(iValXDG, 260, 60, 14))
        gra.DrawRectangle(back, New XRect(iValXDG + 63, 260, 60, 14))
        gra.DrawRectangle(back, New XRect(iValXDG + 126, 260, 240, 14))
        AgregarTexto(gra, fontTxtSerHdr, blanco, "OFICINA", iValXDG, 260, 60, 14, 3)
        AgregarTexto(gra, fontTxtSerHdr, blanco, "DIVISIÓN", iValXDG + 63, 260, 60, 14, 3)
        AgregarTexto(gra, fontTxtSerHdr, blanco, "SERVICIO", iValXDG + 130, 260, 240, 14, 1)

        For Each ser As DataRow In dtServicios.Rows
            AgregarTexto(gra, fontTxtSerReg, negro, TextoCampo(ser("DESCOFI")), iValXDG, iValYDGS + (15 * dtServicios.Rows.IndexOf(ser)), 60, 14, 3)
            AgregarTexto(gra, fontTxtSerReg, negro, TextoCampo(ser("DESCAREA")), iValXDG + 63, iValYDGS + (15 * dtServicios.Rows.IndexOf(ser)), 60, 14, 3)
            AgregarTexto(gra, fontTxtSerReg, negro, TextoCampo(ser("DESCRIPCION")), iValXDG + 130, iValYDGS + (15 * dtServicios.Rows.IndexOf(ser)), 240, 14, 1)
        Next

        '================ CONTACTO INICIAL ================
        gra.DrawString("CONTACTO INICIAL", fontTxt, backRes, New XRect(iValXCam, 255 + iValYFS, iValX - 60, 14), XStringFormats.CenterLeft)
        gra.DrawRectangle(backRes, New XRect(iValXCam, iValYCI + iValYFS, iValX - 60, 1.5))

        AgregarTexto(gra, fontTxtCam, negro, "Fecha del contacto inicial: ", iValXCam, 285 + iValYFS, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(txtContactoInicialFecha.Value.ToShortDateString), iValXCI, 285 + iValYFS, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "Persona que tuvo el primer contacto: ", iValXCam, 300 + iValYFS, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(txtContactoInicialPrimerContacto.Text), iValXCI, 300 + iValYFS, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "Nombre del Contacto: ", iValXCam, 315 + iValYFS, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(txtContactoInicialNombre.Text), iValXCI, 315 + iValYFS, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "Correo electrónico del Contacto: ", iValXCam, 330 + iValYFS, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(txtContactoInicialCorreo.Text), iValXCI, 330 + iValYFS, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "Cargo del Contacto: ", iValXCam, 345 + iValYFS, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(txtContactoInicialCargo.Text), iValXCI, 345 + iValYFS, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "Teléfono del Contacto: ", iValXCam, 360 + iValYFS, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(txtContactoInicialTelefono.Text), iValXCI, 360 + iValYFS, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "Web del Contacto: ", iValXCam, 375 + iValYFS, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(txtAcercamientoWebProspecto.Text), iValXCI, 375 + iValYFS, 105, 14, 1)

        '================ ACERCAMIENTO ================
        gra.DrawString("ACERCAMIENTO", fontTxt, backRes, New XRect(iValXCam, 405 + iValYFS, iValX - 60, 14), XStringFormats.CenterLeft)
        gra.DrawRectangle(backRes, New XRect(iValXCam, iValYAC + iValYFS, iValX - 60, 1.5))

        AgregarTexto(gra, fontTxtCam, negro, "Medio de Contacto: ", iValXCam, 435 + iValYFS, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(cboAcercamientoMedioContacto.SelectedItem("sMedio")), iValXAC, 435 + iValYFS, 105, 14, 1)

        AgregarTexto(gra, fontTxtCam, negro, "¿Cómo se enteró de nosotros?: ", iValXCam, 450 + iValYFS, 105, 14, 1)
        AgregarTexto(gra, fontTxtReg, negro, TextoCampo(cboAcercamientoComoEntero.SelectedItem("sAcercamiento")), iValXAC, 450 + iValYFS, 105, 14, 1)

        '================ PIE DE PÁGINA ================
        'gra.DrawLine(linDet, 30, iValY - 35, iValX - 30, iValY - 35)
        gra.DrawRectangle(backRes, New XRect(0, iValY - 35, iValX, iValY - 35))
        gra.DrawEllipse(XBrushes.WhiteSmoke, New XRect(iValX - 40, iValY - 27, 20, 20))
        gra.DrawString("1", fontTxt, New XSolidBrush(XColor.FromArgb(79, 45, 127)), New XRect(iValX - 37, iValY - 24, 10, 14), XStringFormats.CenterRight)

        '================ GUARDAR ARCHIVO ================
        Dim filename As String = QuitarCaracteres(sNomCte) & ".pdf"

        If File.Exists(sRutaTemp & filename) Then
            If ArchivoEnUso(sRutaTemp & filename) Then
                MsgBox("Un archivo con el mismo nombre se encuentra abierto. Cierre este archivo e intente nuevamente.", MsgBoxStyle.Exclamation, "SIAT")
            Else
                pdfDoc.Save(sRutaTemp & filename)
                pdfDoc.Close()

                arPDF = ConvertirPDFBytes(sRutaTemp & filename)
            End If
        Else
            pdfDoc.Save(sRutaTemp & filename)
            pdfDoc.Close()

            arPDF = ConvertirPDFBytes(sRutaTemp & filename)

        End If
    End Sub
    Private Sub EnvioCorreoProspectoNuevo(sNombreCliente As String) 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String
        Dim archivos As Attachment
        Dim sArchivo As String = QuitarCaracteres(sNombreCliente) & ".pdf"

        Try
            ' Dim sCorreos = "Octavio.A.Cervantes@mx.gt.com; Mario.Rodriguez@mx.gt.com"
            Dim sCorreos = sCorreoEncargado
            Dim sCorreo As String() = sCorreos.Split(";")

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">NOTIFICACIÓN DE PRIMER CONTACTO CON CLIENTE PROSPECTO</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado " & sNombreEncargado.TrimEnd(";") & ": </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Por medio del presente, le informo que hemos realizado el primer contacto con el cliente prospecto " & txtRazonSocial.Text.ToUpper.Trim() & ", quien ha mostrado interés en nuestros servicios y ha solicitado recibir una propuesta formal. </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Para continuar con este proceso, solicitamos atentamente su apoyo para asignar al socio más idóneo para la elaboración y presentación de la propuesta de servicio, considerando la naturaleza del servicio solicitado, la experiencia técnica requerida y la disponibilidad del socio.</p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
                "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para cualquier aclaración sobre el tema, contactar a Tatiana.L.Lopez@mx.gt.com" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            sRutaTemp = "C:\TEMP\"

            If Not Directory.Exists(sRutaTemp) Then
                Directory.CreateDirectory(sRutaTemp)
            End If

            archivos = New Attachment(sRutaTemp & sArchivo)
            EnviarCorreosHTML(sCorreo, sMensaje, "Notificación de primer contacto con cliente prospecto", "N", archivos)

        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub

    Private Sub btnEnviarAsiganacion_Click(sender As Object, e As EventArgs) Handles btnEnviarAsiganacion.Click

        If sEstatusSolicitud = "V" Then

            ActualizarSolicitudBG(idSAC)

            Dim Dr() As DataRow
            If dtCorreosSolicitud.Rows.Count > 0 Then
                Dr = dtCorreosSolicitud.Select("sCvepersona = 'GD'")
                sNombreEncargado = Dr(0).Item("sTipoPersona").ToString()
                sCorreoEncargado = Dr(0).Item("sCorreoPersona").ToString()
                GenerarPDFProvisional(txtRazonSocial.Text & ", " & cboEntidadMercantilRS.SelectedItem("sCveSociedad"), txtNombreComercial.Text & ", " & cboEntidadMercantilNC.SelectedItem("sCveSociedad"))
                EnvioCorreoProspectoNuevo(txtRazonSocial.Text & ", " & cboEntidadMercantilRS.SelectedItem("sCveSociedad"))
            End If

        Else
            MsgBox("Ya no es posible asignar esta solicitud, hasta que la revise Back Ground", MsgBoxStyle.Exclamation, "SIAT")
        End If

        DialogResult = DialogResult.OK

    End Sub


End Class