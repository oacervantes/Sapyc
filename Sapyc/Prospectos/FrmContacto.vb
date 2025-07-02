Imports System.Data.SqlClient

Public Class FrmContacto

#Region "VARIABLES"

    Private ds As New DataSet
    Private bsPro, bsFun, bsAcc, BindingSource1 As New BindingSource

    Private sNameRpt As String = "Alta de Prospecto"

    Private Const DATOS_GENERALES As String = "DATOS GENERALES"
    Private Const CONTACTO_INICIAL As String = "CONTACTO INICIAL"
    Private Const ACERCAMIENTO As String = "ACERCAMIENTO"
    Private Const DOMICILIO As String = "DOMICILIO"

    Private dtCvesProspectos, dtProspectos As New DataTable
    Private dtDatosGenerales As New DataTable
    Private dtContactoInicial As New DataTable
    Private dtComoSeEntero, dtMedioContacto, dtAcercamiento As New DataTable
    Private dtDomicilio, dtPaisDomicilio, dtColoniasDomicilio, dtMunicipiosDomicilio, dtEstadosDomicilio As New DataTable
    Private dtFuncionarios, dtTipoPersonaAc, dtAccionistas As New DataTable
    Private dtDatGrals, dtBolsaValores, dtEntidadReg, dtNormatividad, dtPais, dtPaisGT, dtPaisResidencia, dtTipoEntidad, dtModalidades, dtIdiomas, dtServicios, dtOfGt As DataTable

    Private dtIndustria, dtSubSector, dtSubNivel As DataTable
    Private sInd, sSS, sGTI As String

    Private iOpcionFun, iOpcionAcc, idProspectos As Integer
    Private sCveInd, sCveSS, sCveGTI As String

    Private sMsgDatosGenerales, sMsgContacto, sMsgAcercamiento, sMsgDomicilio As String

    Public sCveProspecto, sCveArea As String
    Public iOrigen, idProspecto, iModifica As Integer

#End Region

#Region "EVENTOS"

    Private Sub FrmContacto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        panDatosGenerales.Visible = True

        If iOrigen = 1 Then
            ListarProspectos()
            InsertarNuevoProspecto()
            InsertarPropuestaProspecto()
        ElseIf iOrigen = 2 Then
            txtClaveProspecto.Text = sCveProspecto

            If sCveArea = "AUD" Then
                rdAuditoria.Checked = True
            ElseIf sCveArea = "IMP" Then
                rdImpuestos.Checked = True
            ElseIf sCveArea = "PT" Then
                rdPreciosTransferencia.Checked = True
            ElseIf sCveArea = "CEX" Then
                rdComercioExterior.Checked = True
            ElseIf sCveArea = "AUI" Then
                rdBAS.Checked = True
            ElseIf sCveArea = "CE" Then
                rdBPS.Checked = True
            ElseIf sCveArea = "PLD" Then
                rdPLD.Checked = True
            Else
                rdAuditoria.Checked = False
                rdImpuestos.Checked = False
                rdPreciosTransferencia.Checked = False
                rdComercioExterior.Checked = False
                rdBAS.Checked = False
                rdBPS.Checked = False
                rdPLD.Checked = False
            End If
        End If

        '============================== ACERCAMIENTO ==============================
        ListarComoSeEnteroAcerca()
        If dtComoSeEntero Is Nothing Then Exit Sub

        ListarMedioContactoAcerca()
        If dtMedioContacto Is Nothing Then Exit Sub

        ListarAcercamiento()
        If dtAcercamiento Is Nothing Then Exit Sub

        '============================== DOMICILIO ==============================
        ListarPaisDomicilio()
        If dtPaisDomicilio Is Nothing Then
            Exit Sub
        End If

        ListarEstadosDomicilio()
        If dtEstadosDomicilio Is Nothing Then
            Exit Sub
        End If

        ListarDomicilio()
        If dtDomicilio Is Nothing Then
            Exit Sub
        End If

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
        ListarIdiomas()

        ListarDatosGenerales()

        listarIndustrias()
        listarSubSector()
        listarSubNivel()

    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If iOrigen = 1 Then
            DialogResult = DialogResult.OK
        ElseIf iOrigen = 2 Then
            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub BtnInicioPropuesta_Click(sender As Object, e As EventArgs)
        If MsgBox("Se va a iniciar el registro de una propuesta. Antes de continuar, revise que la información capturada es correcta; si está seguro de esto, presione Sí.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Iniciar Propuesta") = MsgBoxResult.Yes Then
            'InsertarPropuesta
        End If
    End Sub

    Private Sub LnkSecciones(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDatosGenerales.LinkClicked, lnkContactoInicial.LinkClicked, lnkAcercamiento.LinkClicked, lnkDireccion.LinkClicked, lnkFuncionarios.LinkClicked, lnkAccionistas.LinkClicked
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
                ListarContactoInicial()

            Case 3
                panAcercamiento.Visible = True
                ListarAcercamiento()

            Case 4
                panDireccion.Visible = True
                ListarDomicilio()

                'Case 5
                '    panFuncionarios.Visible = True
                '    ListarFuncionarios()

                'Case 6
                '    panAccionistas.Visible = True
                '    ListarAccionistas()

        End Select
    End Sub
    Private Sub RdDivisiones_CheckedChanged(sender As Object, e As EventArgs) Handles rdAuditoria.CheckedChanged, rdImpuestos.CheckedChanged, rdPreciosTransferencia.CheckedChanged, rdComercioExterior.CheckedChanged, rdBAS.CheckedChanged, rdBPS.CheckedChanged, rdPLD.CheckedChanged
        ListarServicios()
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

    Private Sub rdEmpresaPublicaSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdEmpresaPublicaSi.CheckedChanged
        HabilitarCombo(cboBolsaValores, True)
    End Sub
    Private Sub rdEmpresaPublicaNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdEmpresaPublicaNo.CheckedChanged
        HabilitarCombo(cboBolsaValores, False)
        cboBolsaValores.SelectedIndex = 0

        txtBolsaValoresOtro.Enabled = False
        txtBolsaValoresOtro.Text = ""
    End Sub

    Private Sub cboBolsaValores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBolsaValores.SelectedIndexChanged
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

    Private Sub cboEntidadReguladora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntidadReguladora.SelectedIndexChanged
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

    Private Sub rdReferenciaGTISi_CheckedChanged(sender As Object, e As EventArgs) Handles rdReferenciaGTISi.CheckedChanged
        txtReferenciaGTISocio.Enabled = True
        cboReferenciaGTIPais.Enabled = True
        cboReferenciaGTIOficina.Enabled = True
    End Sub
    Private Sub rdReferenciaGTINo_CheckedChanged(sender As Object, e As EventArgs) Handles rdReferenciaGTINo.CheckedChanged
        txtReferenciaGTISocio.Enabled = False
        cboReferenciaGTIPais.Enabled = False
        cboReferenciaGTIOficina.Enabled = False
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
        If BindingSource1.DataSource Is Nothing Then
            Return 0
        End If

        Try

            Dim filtro As String = String.Empty

            'filtro = "like '" & texto.Trim & "%'"
            filtro = "like '%" & texto.Trim & "%'"

            ' Seleccionar la opción    
            '            Select Case Opcion_Filtro
            '               Case e_FILTER_OPTION.CADENA_QUE_COMIENCE_CON
            '                    filtro = "like '" & texto.Trim & "%'"
            '                 Case e_FILTER_OPTION.CADENA_QUE_NO_COMIENCE_CON
            '                    filtro = "Not like '" & texto.Trim & "%'"
            '                Case e_FILTER_OPTION.CADENA_QUE_NO_CONTENGA
            '                    filtro = "Not like '%" & texto.Trim & "%'"
            '                Case e_FILTER_OPTION.CADENA_QUE_CONTENGA
            '                    filtro = "like '%" & texto.Trim & "%'"
            '                Case e_FILTER_OPTION.CADENA_IGUAL
            '                    filtro = "='" & texto.Trim & "'"
            '            End Select

            ' Opción para no filtrar   
            '            If Opcion_Filtro = e_FILTER_OPTION.SIN_FILTRO Then
            ' filtro = String.Empty
            ' End If

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

    Private Sub cboReferenciaGTIPais_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboReferenciaGTIPais.SelectionChangeCommitted
        If cboReferenciaGTIPais.SelectedIndex <> 0 Then
            ListarOficinasGT(cboReferenciaGTIPais.SelectedValue)
        End If
    End Sub

    Private Sub BtnRegistroDatosGenerales_Click(sender As Object, e As EventArgs) Handles btnRegistroDatosGenerales.Click
        'lblMensaje.Text = ""
        'lblMensaje.Visible = False
        txtMensaje.Text = ""
        panMensajesError.Visible = False

        'General
        gpBoxDatosDG.Enabled = True
        gpBoxServicio.Enabled = True
        panDivisiones.Enabled = True
        btnGuardaGeneral.Enabled = True
        btnCancelaGeneral.Enabled = True
        btnRegistroDatosGenerales.Enabled = False
        txtRazonSocial.Focus()

        'Contacto Inicial
        panDatosContactoInicial.Enabled = True
        'btnGuardarContactoInicial.Enabled = True
        'btnCancelarContactoInicial.Enabled = True
        'btnRegistroContactoInicial.Enabled = False
        txtContactoInicialPrimerContacto.Focus()

        'Acercamiento
        gpBoxDatosAcercamiento.Enabled = True
        'btnGuardarAcercamiento.Enabled = True
        'btnCancelarAcercamiento.Enabled = True
        'btnRegistroAcercamiento.Enabled = False
        cboAcercamientoComoEntero.Focus()

        'Domicilio
        gpBoxDatosDomicilio.Enabled = True
        'btnGuardarDomicilio.Enabled = True
        'btnCancelarDomicilio.Enabled = True
        'btnRegistroDomicilio.Enabled = False
        cboDomicilioPais.Focus()
    End Sub
    Private Sub BtnGuardaGeneral_Click(sender As Object, e As EventArgs) Handles btnGuardaGeneral.Click
        sMsgDatosGenerales = ""
        sMsgContacto = ""
        sMsgAcercamiento = ""
        sMsgDomicilio = ""

        '================================ CONTACTO INICIAL ================================
        If ValidarContactoInicial() Then
            sMsgContacto = ""
        End If

        '================================ ACERCAMIENTO ====================================
        If ValidarAcercamiento() Then
            sMsgAcercamiento = ""
        End If

        '================================ DOMICILIO ====================================
        If ValidarDomicilio() Then
            sMsgDomicilio = ""
        End If

        If sMsgDatosGenerales <> "" Or sMsgContacto <> "" Or sMsgAcercamiento <> "" Or sMsgDomicilio <> "" Then
            panMensajesError.Visible = True
            txtMensaje.Text = sMsgDatosGenerales & vbCrLf & sMsgContacto & vbCrLf & sMsgAcercamiento & vbCrLf & sMsgDomicilio
            Exit Sub
        Else
            panMensajesError.Visible = False
            txtMensaje.Text = ""
        End If

        ''''''''''''''''''''''''''' DATOS GENERALES ''''''''''''''''''''''''''''''''''''
        'If txtRazonSocial.Text = "" Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque la razón social del prospecto."
        '    Exit Sub
        'End If
        'If txtNombreComercial.Text = "" Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el nombre comercial del prospecto."
        '    Exit Sub
        'End If
        'If txtRFC.Text = "" Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el RFC del prospecto."
        '    Exit Sub
        'End If
        'If txtDescripcionSolicitud.Text = "" Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque la descripción del servicio del prospecto."
        '    Exit Sub
        'End If
        'If rdAuditoria.Checked = False And rdImpuestos.Checked = False And rdPreciosTransferencia.Checked = False And rdComercioExterior.Checked = False And rdBAS.Checked = False And rdBPS.Checked = False And rdPLD.Checked = False Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el tipo de servicio solicitado por el prospecto."
        '    Exit Sub
        'End If

        'If sCveInd = "" Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque la industria del prospecto."

        '    Exit Sub
        'End If

        'If sCveSS = "" Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el subsector del prospecto."

        '    Exit Sub
        'End If

        'If sCveGTI = "" Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el subnivel del prospecto."

        '    Exit Sub
        'End If

        'If rdEmpresaPublicaSi.Checked = False And rdEmpresaPublicaNo.Checked = False Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque si el prospecto es una empresa pública."

        '    Exit Sub
        'End If

        'If rdEmpresaPublicaSi.Checked = True And cboBolsaValores.SelectedIndex = 0 Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque la bolsa de valores."

        '    Exit Sub
        'End If

        'If rdEmpresaPublicaSi.Checked = True And cboBolsaValores.SelectedIndex = 5 And Trim(txtBolsaValoresOtro.Text) = "" Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el nombre de la bolsa de valores."

        '    Exit Sub
        'End If

        'If rdSubsidiariaSi.Checked = False And rdSubsidiariaNo.Checked = False Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque si el prospecto es una subsidiaria."

        '    Exit Sub
        'End If

        'If rdSubsidiariaSi.Checked = True And (rdControladoraSi.Checked = False And rdControladoraNO.Checked = False) Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque si el prospecto reportará a su compañia controladora."

        '    Exit Sub
        'End If

        'If cboPais.SelectedIndex = 0 Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el país del prospecto."

        '    Exit Sub
        'End If

        'If rdEntidadReguladaSi.Checked = False And rdEntidadReguladaNo.Checked = False Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque si el prospecto es una entidad regulada."

        '    Exit Sub
        'End If

        'If rdEntidadReguladaSi.Checked = True And cboEntidadReguladora.SelectedIndex = 0 Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque la entidad reguladora para el prospecto."

        '    Exit Sub
        'End If

        'If rdEntidadReguladaSi.Checked = True And cboEntidadReguladora.SelectedIndex = 8 And Trim(txtEntidadReguladoraOtro.Text) = "" Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el nombre de la entidad reguladora para el prospecto."

        '    Exit Sub
        'End If

        'If rdEntidadSupervisadaSi.Checked = False And rdEntidadSupervisadaNo.Checked = False Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque si el prospecto es una entidad supervisada."

        '    Exit Sub
        'End If

        'If rdEntidadSupervisadaSi.Checked = True And cboEntidadSupervisada.SelectedIndex = 0 Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque la normatividad para el prospecto."

        '    Exit Sub
        'End If

        'If rdEntidadSupervisadaSi.Checked = True And cboEntidadSupervisada.SelectedIndex = 6 And Trim(txtEntidadSupervisadaOtro.Text) = "" Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el nombre de la normatividad para el prospecto."

        '    Exit Sub
        'End If

        'If rdReferenciaGTISi.Checked = False And rdReferenciaGTINo.Checked = False Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque si el prospecto es una referencia de GTI."

        '    Exit Sub
        'End If

        'If rdReferenciaGTISi.Checked = True And cboReferenciaGTIPais.SelectedIndex = 0 Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el país de referencia de GTI."

        '    Exit Sub
        'End If

        'If rdReferenciaGTISi.Checked = True And cboReferenciaGTIPais.SelectedIndex = 0 And cboReferenciaGTIOficina.SelectedIndex = 0 Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque la oficina de referencia de GTI."

        '    Exit Sub
        'End If

        'If rdEmpresaExtranjeroRepSi.Checked = False And rdEmpresaExtranjeroRepNo.Checked = False Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque si el prospecto reporta al extranjero."

        '    Exit Sub
        'End If

        'If rdEmpresaExtranjeroRepSi.Checked = True And cboPaisResidencia.SelectedIndex = 0 Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el país de residencia de la empresa tenedora."

        '    Exit Sub
        'End If

        'If rdEmpresaExtranjeroRepSi.Checked = True And Trim(txtEmpresaTenedora.Text) = "" Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el nombre de la empresa tenedora."

        '    Exit Sub
        'End If

        'If cboTipoEntidad.SelectedIndex = 0 Then
        '    lblMensaje.Visible = True
        '    lblMensaje.Text = "Especifíque el tipo de entidad del prospecto."

        '    Exit Sub
        'End If

        If MsgBox("¿Desea guardar los Datos del prospecto?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Agregar Accionista") = MsgBoxResult.Yes Then
            InsertaGeneral()
            InsertarAcercamiento()
            InsertarContactoInicial()
            InsertarDomicilio()

            MsgBox("Se registraron los datos del prospecto correctamente.", MsgBoxStyle.Information, "SIAT")

            gpBoxDatosDG.Enabled = False
            btnGuardaGeneral.Enabled = False
            btnCancelaGeneral.Enabled = False
            btnRegistroDatosGenerales.Enabled = True

            OcultarMensajesError()
            ListarProspectos()

            'DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub BtnCancelaGeneral_Click(sender As Object, e As EventArgs) Handles btnCancelaGeneral.Click
        txtMensaje.Text = ""
        panMensajesError.Visible = False

        'Datos Generales
        gpBoxDatosDG.Enabled = False
        btnGuardaGeneral.Enabled = False
        btnCancelaGeneral.Enabled = False
        btnRegistroDatosGenerales.Enabled = True

        'Contacto Inicial
        panDatosContactoInicial.Enabled = False

        'Acercamiento
        gpBoxDatosAcercamiento.Enabled = False
        'btnGuardarAcercamiento.Enabled = False
        'btnCancelarAcercamiento.Enabled = False
        'btnRegistroAcercamiento.Enabled = True

        'Domicilio
        gpBoxDatosDomicilio.Enabled = False
        'btnGuardarDomicilio.Enabled = False
        'btnCancelarDomicilio.Enabled = False
        'btnRegistroDomicilio.Enabled = True

        OcultarMensajesError()
        ListarDatosGenerales()
        ListarContactoInicial()
        ListarAcercamiento()
        ListarDomicilio()
    End Sub

#End Region

#Region "CONTACTO INICIAL"

    'Private Sub btnRegistroContactoInicial_Click(sender As Object, e As EventArgs) Handles btnRegistroContactoInicial.Click
    '    gpBoxDatosContactoInicial.Enabled = True
    '    btnGuardarContactoInicial.Enabled = True
    '    btnCancelarContactoInicial.Enabled = True
    '    btnRegistroContactoInicial.Enabled = False

    '    lblMensajeCargaContactoInicial.Visible = False

    '    txtContactoInicialNombre.Focus()
    'End Sub
    'Private Sub btnGuardarContactoInicial_Click(sender As Object, e As EventArgs)
    '    If txtContactoInicialNombre.Text = "" Then
    '        lblMensajeErrorContactoInicial.Visible = True
    '        lblMensajeErrorContactoInicial.Text = "Especifíque el nombre del contacto inicial del prospecto."

    '        Exit Sub
    '    End If

    '    If txtContactoInicialCargo.Text = "" Then
    '        lblMensajeErrorContactoInicial.Visible = True
    '        lblMensajeErrorContactoInicial.Text = "Especifíque el cargo del contacto inicial del prospecto."

    '        Exit Sub
    '    End If

    '    If txtContactoInicialCorreo.Text = "" Then
    '        lblMensajeErrorContactoInicial.Visible = True
    '        lblMensajeErrorContactoInicial.Text = "Especifíque el correo electrónico del contacto inicial del prospecto."

    '        Exit Sub
    '    End If

    '    lblMensajeErrorContactoInicial.Visible = False
    '    lblMensajeErrorContactoInicial.Text = ""

    '    If MsgBox("¿Desea registrar la información de Contacto Inicial?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Agregar Contacto Inicial") = MsgBoxResult.Yes Then
    '        InsertarContactoInicial()

    '        gpBoxDatosContactoInicial.Enabled = False
    '        btnGuardarContactoInicial.Enabled = False
    '        btnCancelarContactoInicial.Enabled = False
    '        btnRegistroContactoInicial.Enabled = True

    '        ListarContactoInicial()
    '    End If
    'End Sub
    'Private Sub btnCancelarContactoInicial_Click(sender As Object, e As EventArgs) Handles btnCancelarContactoInicial.Click
    '    gpBoxDatosContactoInicial.Enabled = False
    '    btnGuardarContactoInicial.Enabled = False
    '    btnCancelarContactoInicial.Enabled = False
    '    btnRegistroContactoInicial.Enabled = True

    '    OcultarMensajesError()
    '    ListarContactoInicial()
    'End Sub
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

    'Private Sub btnRegistroAcercamiento_Click(sender As Object, e As EventArgs) 'Handles btnRegistroAcercamiento.Click

    'End Sub
    'Private Sub btnGuardarAcercamiento_Click(sender As Object, e As EventArgs)
    '    If cboAcercamientoComoEntero.SelectedValue = 13 And txtAcercamientoEnteroOtro.Text = "" Then
    '        lblMensajeErrorAcercamiento.Visible = True
    '        lblMensajeErrorAcercamiento.Text = "Especifíque la forma en cómo se enteró el prospecto."

    '        Exit Sub
    '    End If

    '    If cboAcercamientoMedioContacto.SelectedValue = 10 And txtAcercamientoContactoOtro.Text = "" Then
    '        lblMensajeErrorAcercamiento.Visible = True
    '        lblMensajeErrorAcercamiento.Text = "Especifíque el medio de contacto utilizado por el prospecto."

    '        Exit Sub
    '    End If

    '    lblMensajeErrorAcercamiento.Visible = False
    '    lblMensajeErrorAcercamiento.Text = ""

    '    If MsgBox("¿Desea registrar la información de Acercamiento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Agregar Acercamiento") = MsgBoxResult.Yes Then
    '        InsertarAcercamiento()

    '        gpBoxDatosAcercamiento.Enabled = False
    '        'btnGuardarAcercamiento.Enabled = False
    '        'btnCancelarAcercamiento.Enabled = False
    '        'btnRegistroAcercamiento.Enabled = True

    '        ListarAcercamiento()
    '    End If
    'End Sub
    'Private Sub btnCancelarAcercamiento_Click(sender As Object, e As EventArgs) Handles btnCancelarAcercamiento.Click
    '    gpBoxDatosAcercamiento.Enabled = False
    '    btnGuardarAcercamiento.Enabled = False
    '    btnCancelarAcercamiento.Enabled = False
    '    btnRegistroAcercamiento.Enabled = True

    '    OcultarMensajesError()
    '    ListarAcercamiento()
    'End Sub

    Private Sub CboAcercamientoComoEntero_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAcercamientoComoEntero.SelectionChangeCommitted
        txtAcercamientoEnteroOtro.Text = ""

        Select Case cboAcercamientoComoEntero.SelectedValue
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

            Case Else
                txtAcercamientoEnteroOtro.Enabled = False
                lblAcercamientoOtro.Text = "Otro"

        End Select

    End Sub
    Private Sub cboAcercamientoMedioContacto_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAcercamientoMedioContacto.SelectionChangeCommitted
        If cboAcercamientoMedioContacto.SelectedValue = 10 Then
            txtAcercamientoContactoOtro.Enabled = True
        Else
            txtAcercamientoContactoOtro.Enabled = False
            txtAcercamientoContactoOtro.Text = ""
        End If
    End Sub

#End Region

#Region "DOMICILIO"

    'Private Sub BtnGuardarDomicilio_Click(sender As Object, e As EventArgs)
    '    'If MsgBox("¿Desea registrar la información del Domicilio?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Agregar Domicilio") = MsgBoxResult.Yes Then
    '    '    InsertarDomicilio()

    '    '    gpBoxDatosDomicilio.Enabled = False
    '    '    btnGuardarDomicilio.Enabled = False
    '    '    btnCancelarDomicilio.Enabled = False
    '    '    btnRegistroDomicilio.Enabled = True

    '    '    ListarDomicilio()
    '    'End If
    'End Sub

    Private Sub CboDomicilioPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDomicilioPais.SelectedIndexChanged
        If cboDomicilioPais.SelectedIndex = 151 Then
            panDomicilioNac.Visible = True
            panDomicilioExt.Visible = False
            'cboDomicilioColonia.Visible = True
            'cboDomicilioEstado.Visible = True
            'cboDomicilioMunicipio.Visible = True

            'txtDomicilioExtDireccion1.Visible = False
            'txtDomicilioExtEstado.Visible = False
            'txtDomicilioExtLocalidad.Visible = False
        Else
            panDomicilioNac.Visible = False
            panDomicilioExt.Visible = True
            'txtDomicilioExtDireccion1.Visible = True
            'txtDomicilioExtEstado.Visible = True
            'txtDomicilioExtLocalidad.Visible = True

            'cboDomicilioColonia.Visible = False
            'cboDomicilioEstado.Visible = False
            'cboDomicilioMunicipio.Visible = False
        End If
    End Sub
    Private Sub CboDomicilioColonia_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDomicilioColonia.SelectionChangeCommitted
        txtDomicilioCP.Text = cboDomicilioColonia.SelectedItem("sCP")
    End Sub
    Private Sub CboDomicilioMunicipio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDomicilioMunicipio.SelectionChangeCommitted
        txtDomicilioCP.Text = ""
        listarColoniasDomicilio(2, cboDomicilioMunicipio.SelectedValue, cboDomicilioEstado.SelectedValue)
    End Sub
    Private Sub CboDomicilioEstado_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDomicilioEstado.SelectionChangeCommitted
        ListarMunicipiosDomicilio(cboDomicilioEstado.SelectedValue)
        cboDomicilioMunicipio.SelectedIndex = 0
    End Sub

    Private Sub TxtDomicilioCP_Leave(sender As Object, e As EventArgs) Handles txtDomicilioCP.Leave
        If cboDomicilioPais.SelectedIndex = 151 Then
            listarColoniasDomicilio(1, txtDomicilioCP.Text)
        End If
    End Sub

    Private Sub TxtDomicilioColonia_TextChanged(sender As Object, e As EventArgs) Handles txtDomicilioExtDireccion1.TextChanged
        txtDomicilioExtDireccion1.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub TxtDomicilioMunicipio_TextChanged(sender As Object, e As EventArgs) Handles txtDomicilioExtLocalidad.TextChanged
        txtDomicilioExtLocalidad.CharacterCasing = CharacterCasing.Upper
    End Sub

#End Region

    '#Region "FUNCIONARIOS"

    '    Private Sub btnNuevoFuncionarios_Click(sender As Object, e As EventArgs) Handles btnNuevoFuncionarios.Click
    '        gpBoxDatosFuncionarios.Enabled = True
    '        btnGuardarFuncionarios.Enabled = True
    '        btnCancelarFuncionario.Enabled = True
    '        btnNuevoFuncionarios.Enabled = False
    '        btnActualizarFuncionario.Enabled = False
    '        gridFuncionarios.Enabled = False

    '        iOpcionFun = 1
    '        txtFuncionariosNombre.Focus()
    '    End Sub
    '    Private Sub btnActualizarFuncionario_Click(sender As Object, e As EventArgs) Handles btnActualizarFuncionario.Click
    '        gpBoxDatosFuncionarios.Enabled = True
    '        btnGuardarFuncionarios.Enabled = True
    '        btnCancelarFuncionario.Enabled = True
    '        btnNuevoFuncionarios.Enabled = False
    '        btnActualizarFuncionario.Enabled = False
    '        gridFuncionarios.Enabled = False

    '        iOpcionFun = 2
    '        txtFuncionariosNombre.Focus()

    '        If Not gridFuncionarios.CurrentRow Is Nothing Then
    '            txtFuncionariosNombre.Text = gridFuncionarios.CurrentRow.Cells("sNombre").Value
    '            txtFuncionariosApellidoPaterno.Text = gridFuncionarios.CurrentRow.Cells("sApellidoPaterno").Value
    '            txtFuncionariosApellidoMaterno.Text = gridFuncionarios.CurrentRow.Cells("sApellidoMaterno").Value
    '            txtFuncionariosCargo.Text = gridFuncionarios.CurrentRow.Cells("sCargo").Value
    '            txtFuncionariosTelefono.Text = gridFuncionarios.CurrentRow.Cells("sTelefono").Value
    '            txtFuncionariosCorreo.Text = gridFuncionarios.CurrentRow.Cells("sCorreo").Value
    '        End If
    '    End Sub
    '    Private Sub btnGuardarFuncionarios_Click(sender As Object, e As EventArgs) Handles btnGuardarFuncionarios.Click
    '        If MsgBox("¿Desea " & IIf(iOpcionFun = 1, "registrar", "actualizar") & " la información del Funcionario?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Agregar Funcionario") = MsgBoxResult.Yes Then
    '            If iOpcionFun = 1 Then
    '                InsertarFuncionario()
    '            Else
    '                ActualizarFuncionarios()
    '            End If

    '            gpBoxDatosFuncionarios.Enabled = False
    '            btnGuardarFuncionarios.Enabled = False
    '            btnCancelarFuncionario.Enabled = False
    '            btnNuevoFuncionarios.Enabled = True
    '            btnActualizarFuncionario.Enabled = True
    '            gridFuncionarios.Enabled = True

    '            ListarFuncionarios()
    '            LimpiarDatosFuncionarios()
    '        End If
    '    End Sub
    '    Private Sub btnCancelarFuncionario_Click(sender As Object, e As EventArgs) Handles btnCancelarFuncionario.Click
    '        gpBoxDatosFuncionarios.Enabled = False
    '        btnGuardarFuncionarios.Enabled = False
    '        btnCancelarFuncionario.Enabled = False
    '        btnNuevoFuncionarios.Enabled = True
    '        btnActualizarFuncionario.Enabled = True
    '        gridFuncionarios.Enabled = True

    '        LimpiarDatosFuncionarios()
    '    End Sub

    '    Private Sub gridFuncionarios_DoubleClick(sender As Object, e As EventArgs) Handles gridFuncionarios.DoubleClick
    '        gpBoxDatosFuncionarios.Enabled = True
    '        btnGuardarFuncionarios.Enabled = True
    '        btnCancelarFuncionario.Enabled = True
    '        btnNuevoFuncionarios.Enabled = False
    '        btnActualizarFuncionario.Enabled = False
    '        gridFuncionarios.Enabled = False

    '        iOpcionFun = 2
    '        txtFuncionariosNombre.Focus()

    '        If Not gridFuncionarios.CurrentRow Is Nothing Then
    '            txtFuncionariosNombre.Text = gridFuncionarios.CurrentRow.Cells("sNombre").Value
    '            txtFuncionariosApellidoPaterno.Text = gridFuncionarios.CurrentRow.Cells("sApellidoPaterno").Value
    '            txtFuncionariosApellidoMaterno.Text = gridFuncionarios.CurrentRow.Cells("sApellidoMaterno").Value
    '            txtFuncionariosCargo.Text = gridFuncionarios.CurrentRow.Cells("sCargo").Value
    '            txtFuncionariosTelefono.Text = gridFuncionarios.CurrentRow.Cells("sTelefono").Value
    '            txtFuncionariosCorreo.Text = gridFuncionarios.CurrentRow.Cells("sCorreo").Value
    '        End If
    '    End Sub

    '#End Region

    '#Region "ACCIONISTAS"

    '    Private Sub btnNuevoAccionista_Click(sender As Object, e As EventArgs) Handles btnNuevoAccionista.Click
    '        gpBoxDatosAccionistas.Enabled = True
    '        btnGuardarAccionistas.Enabled = True
    '        btnCancelarAccionistas.Enabled = True
    '        btnNuevoAccionista.Enabled = False
    '        btnActualizarAccionistas.Enabled = False
    '        gridAccionistas.Enabled = False

    '        iOpcionAcc = 1
    '        txtAccionistasNombre.Focus()
    '    End Sub
    '    Private Sub btnActualizarAccionistas_Click(sender As Object, e As EventArgs) Handles btnActualizarAccionistas.Click
    '        gpBoxDatosAccionistas.Enabled = True
    '        btnGuardarAccionistas.Enabled = True
    '        btnCancelarAccionistas.Enabled = True
    '        btnNuevoAccionista.Enabled = False
    '        btnActualizarAccionistas.Enabled = False
    '        gridAccionistas.Enabled = False

    '        iOpcionAcc = 2
    '        txtAccionistasNombre.Focus()

    '        If Not gridAccionistas.CurrentRow Is Nothing Then
    '            txtAccionistasNombre.Text = gridAccionistas.CurrentRow.Cells("sNombre").Value
    '            txtAccionistasApellidoPaterno.Text = gridAccionistas.CurrentRow.Cells("sApellidoPaterno").Value
    '            txtAccionistasApellidoMaterno.Text = gridAccionistas.CurrentRow.Cells("sApellidoMaterno").Value
    '            cboAccionistasTipoPersona.SelectedValue = CInt(gridAccionistas.CurrentRow.Cells("idTipoPersona").Value)
    '            txtAccionistasPorcentaje.Text = CDec(gridAccionistas.CurrentRow.Cells("dPorcentaje").Value)
    '        End If
    '    End Sub
    '    Private Sub btnGuardarAccionistas_Click(sender As Object, e As EventArgs) Handles btnGuardarAccionistas.Click
    '        If MsgBox("¿Desea " & IIf(iOpcionAcc = 1, "registrar", "actualizar") & " la información del Accionista?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Agregar Accionista") = MsgBoxResult.Yes Then
    '            If iOpcionAcc = 1 Then
    '                InsertarAccionista()
    '            Else
    '                ActualizarAccionista()
    '            End If

    '            gpBoxDatosAccionistas.Enabled = False
    '            btnGuardarAccionistas.Enabled = False
    '            btnCancelarAccionistas.Enabled = False
    '            btnNuevoAccionista.Enabled = True
    '            btnActualizarAccionistas.Enabled = True
    '            gridAccionistas.Enabled = True

    '            ListarAccionistas()
    '            LimpiarDatosAccionistas()
    '        End If
    '    End Sub
    '    Private Sub btnCancelarAccionistas_Click(sender As Object, e As EventArgs) Handles btnCancelarAccionistas.Click
    '        gpBoxDatosAccionistas.Enabled = False
    '        btnGuardarAccionistas.Enabled = False
    '        btnCancelarAccionistas.Enabled = False
    '        btnNuevoAccionista.Enabled = True
    '        btnActualizarAccionistas.Enabled = True
    '        gridAccionistas.Enabled = True

    '        LimpiarDatosAccionistas()
    '    End Sub

    '    Private Sub gridAccionistas_DoubleClick(sender As Object, e As EventArgs) Handles gridAccionistas.DoubleClick
    '        gpBoxDatosAccionistas.Enabled = True
    '        btnGuardarAccionistas.Enabled = True
    '        btnCancelarAccionistas.Enabled = True
    '        btnNuevoAccionista.Enabled = False
    '        btnActualizarAccionistas.Enabled = False
    '        gridAccionistas.Enabled = False

    '        iOpcionAcc = 2
    '        txtAccionistasNombre.Focus()

    '        If Not gridAccionistas.CurrentRow Is Nothing Then
    '            txtAccionistasNombre.Text = gridAccionistas.CurrentRow.Cells("sNombre").Value
    '            txtAccionistasApellidoPaterno.Text = gridAccionistas.CurrentRow.Cells("sApellidoPaterno").Value
    '            txtAccionistasApellidoMaterno.Text = gridAccionistas.CurrentRow.Cells("sApellidoMaterno").Value
    '            cboAccionistasTipoPersona.SelectedValue = CInt(gridAccionistas.CurrentRow.Cells("idTipoPersona").Value)
    '            txtAccionistasPorcentaje.Text = CDec(gridAccionistas.CurrentRow.Cells("dPorcentaje").Value)
    '        End If
    '    End Sub

    '#End Region

#End Region

#Region "SUBS"

    Private Sub HabilitarCombo(cbo As ComboBox, bValor As Boolean)
        If bValor Then
            cbo.Enabled = True
        Else
            cbo.Enabled = False
        End If
    End Sub
    'Private Sub HabilitarControles(bValor As Boolean)
    '    gpBoxDatosDG.Enabled = Not bValor
    '    gpBoxDatosAcercamiento.Enabled = Not bValor
    '    gpBoxDatosContactoInicial.Enabled = Not bValor
    '    gpBoxServicio.Enabled = Not bValor

    '    txtRazonSocial.ReadOnly = Not bValor
    '    txtNombreComercial.ReadOnly = Not bValor
    '    txtDescripcionSolicitud.ReadOnly = Not bValor

    '    txtContactoInicialNombre.ReadOnly = Not bValor
    '    txtContactoInicialCargo.ReadOnly = Not bValor
    '    txtContactoInicialCorreo.ReadOnly = Not bValor
    '    txtContactoInicialTelefono.ReadOnly = Not bValor
    '    txtContactoInicialExtension.ReadOnly = Not bValor

    '    cboAcercamientoComoEntero.Enabled = bValor
    '    cboAcercamientoMedioContacto.Enabled = bValor

    '    txtAcercamientoWebProspecto.ReadOnly = Not bValor
    '    txtAcercamientoEnteroOtro.ReadOnly = Not bValor
    '    txtAcercamientoContactoOtro.ReadOnly = Not bValor
    'End Sub

    Private Sub ListarProspectos()
        Try
            Dim sTabla As String = "tbProspectos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTProspectos", sTabla))

                dtProspectos = .Item(sTabla)
            End With

            If dtProspectos.Rows.Count > 0 Then
                idProspectos = CInt(dtProspectos.Rows(0).Item("idProspecto"))
            Else
                idProspectos = 0
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub
    Private Sub InsertarNuevoProspecto()
        Try
            sCveProspecto = GenerarNuevoProspecto(idProspectos)

            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCliente", "Prospecto " & sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveOfi", "", SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveArea", "", SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@bRecurrente", 0, SqlDbType.Bit, ParameterDirection.Input)
                .subAddParameter("@iStatus", 1, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paSSGTProspectos")
            End With

            txtClaveProspecto.Text = sCveProspecto
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarNuevoProspecto()")
            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub InsertarPropuestaProspecto()
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idServicio", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iConflictCheck", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iBackgroundCheck", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iNivRiesgo", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@bIndependencia", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sMotInd", "", SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@dHonorarios", 0, SqlDbType.Decimal, ParameterDirection.Input)

                .funExecuteSP("paSSGTPropuestasProspectos")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarPropuestaProspecto()")
            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub OcultarMensajesError()
        'lblMensajeErrorDatosGenerales.Visible = False
        'lblMensajeErrorContactoInicial.Visible = False
        'lblMensajeErrorAcercamiento.Visible = False
        'lblMensajeErrorDomicilio.Visible = False
    End Sub
    Private Sub listarIndustrias()
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
    Private Sub listarSubSector()
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
    Private Sub listarSubNivel()
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
                txtSubnivel.Text = dtSubNivel.Rows(0).Item("sDescripcion")
            Else
                txtSubnivel.Text = ""
            End If

        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub

#Region "DATOS GENERALES"

    Private Sub Aplicar_FiltroNombre()

        Lista.Visible = True
        ' filtrar por el campo Nombrecte
        Dim ret As Integer = Filtrar_DataGridView("NOMBRE", txtRazonSocial.Text.Trim, BindingSource1, Lista)

        If ret > 0 Then
            ' si no hay registros cambiar el color del txtbox   
            'Cnombre.BackColor = Color.Red
            'If MsgBox("¿Este cliente se encuentra en las listas de clientes restringidos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta") = MsgBoxResult.Yes Then
            '    AltaCte = True
            'End If
        Else
            txtRazonSocial.BackColor = Color.White
            Lista.Visible = False
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

                BindingSource1.DataSource = dtDatGrals
                Lista.DataSource = BindingSource1.DataSource

                ' Lista.Columns("CVECTE").HeaderText = "No"
                Lista.Columns("NOMBRE").HeaderText = "Nombre"
                Lista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                Lista.Columns(0).Width = 80
                Lista.Columns(1).Width = 300

            Else
                lblMensajeCargaContactoInicial.Visible = True
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "CargaClientesDatosGenerales()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
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
    Private Sub ListarServicios()
        Try
            Dim sTabla As String = "tbServicios"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 21, SqlDbType.Int, ParameterDirection.Input)

                    If rdAuditoria.Checked Then
                        .subAddParameter("@sCveArea", "AUD", SqlDbType.VarChar, ParameterDirection.Input)
                    ElseIf rdImpuestos.Checked Then
                        .subAddParameter("@sCveArea", "IMP", SqlDbType.VarChar, ParameterDirection.Input)
                    ElseIf rdPreciosTransferencia.Checked Then
                        .subAddParameter("@sCveArea", "PT", SqlDbType.VarChar, ParameterDirection.Input)
                    ElseIf rdComercioExterior.Checked Then
                        .subAddParameter("@sCveArea", "CEX", SqlDbType.VarChar, ParameterDirection.Input)
                    ElseIf rdBPS.Checked Then
                        .subAddParameter("@sCveArea", "CE", SqlDbType.VarChar, ParameterDirection.Input)
                    ElseIf rdBAS.Checked Then
                        .subAddParameter("@sCveArea", "AUI", SqlDbType.VarChar, ParameterDirection.Input)
                    ElseIf rdPLD.Checked Then
                        .subAddParameter("@sCveArea", "PLD", SqlDbType.VarChar, ParameterDirection.Input)
                    End If
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtServicios = .Item(sTabla)
            End With

            If dtServicios.Rows.Count > 0 Then
                cboDatosGeneralesServicio.DataSource = dtServicios

                cboDatosGeneralesServicio.ValueMember = "idServicio"
                cboDatosGeneralesServicio.DisplayMember = "sServicio"
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarServicios()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtServicios = Nothing
        End Try
    End Sub

    Private Sub ListarDatosGenerales()
        Try
            Dim sTabla As String = "tbDatosGenerales"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtDatosGenerales = .Item(sTabla)
            End With

            If dtDatosGenerales.Rows.Count > 0 Then
                lblMensajeCargaDatosGenerales.Visible = False

                txtRazonSocial.Text = dtDatosGenerales.Rows(0).Item("sRazonSocial").ToString
                txtNombreComercial.Text = dtDatosGenerales.Rows(0).Item("sNombreComercial").ToString

                txtDescripcionSolicitud.Text = dtDatosGenerales.Rows(0).Item("sDescripcionServicio").ToString

                txtRFC.Text = dtDatosGenerales.Rows(0).Item("sRFC").ToString
                txtIndustria.Text = dtDatosGenerales.Rows(0).Item("sIndustria").ToString

                sInd = dtDatosGenerales.Rows(0).Item("idInd").ToString
                sCveSS = dtDatosGenerales.Rows(0).Item("IdSubSec").ToString


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

                cboPais.SelectedValue = CInt(dtDatosGenerales.Rows(0).Item("idPais").ToString)

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
                cboReferenciaGTIPais.SelectedValue = CInt(dtDatosGenerales.Rows(0).Item("idPaisRefGTI").ToString)
                Call cboReferenciaGTIPais_SelectionChangeCommitted(Nothing, Nothing)

                cboReferenciaGTIOficina.Text = dtDatosGenerales.Rows(0).Item("sOficinaRefGTI").ToString

                If CBool(dtDatosGenerales.Rows(0).Item("bReportaExtranjero").ToString) = True Then
                    rdEmpresaExtranjeroRepSi.Checked = True
                Else
                    rdEmpresaExtranjeroRepNo.Checked = True
                End If

                txtEmpresaTenedora.Text = dtDatosGenerales.Rows(0).Item("sNombreTenedora").ToString
                cboPaisResidencia.SelectedValue = CInt(dtDatosGenerales.Rows(0).Item("idPaisTenedora").ToString)

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


            Else
                lblMensajeCargaDatosGenerales.Visible = True
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDatosGenerales()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtDatosGenerales = Nothing
        End Try
    End Sub
    Private Sub InsertaGeneral()
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sRazonSocial", txtRazonSocial.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sNombreComercial", txtNombreComercial.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sDescripcionServicio", txtDescripcionSolicitud.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sRFC", txtRFC.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)

                If rdAuditoria.Checked Then
                    .subAddParameter("@sCveArea", "AUD", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdImpuestos.Checked Then
                    .subAddParameter("@sCveArea", "IMP", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdPreciosTransferencia.Checked Then
                    .subAddParameter("@sCveArea", "PT", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdComercioExterior.Checked Then
                    .subAddParameter("@sCveArea", "CEX", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdBAS.Checked Then
                    .subAddParameter("@sCveArea", "AUI", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdBPS.Checked Then
                    .subAddParameter("@sCveArea", "CE", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdPLD.Checked Then
                    .subAddParameter("@sCveArea", "PLD", SqlDbType.VarChar, ParameterDirection.Input)
                End If

                If rdPersonalMoral.Checked Then
                    .subAddParameter("@sTipoNegocio", "M", SqlDbType.Char, ParameterDirection.Input)
                ElseIf rdPersonaFisica.Checked Then
                    .subAddParameter("@sTipoNegocio", "F", SqlDbType.Char, ParameterDirection.Input)
                End If
                .subAddParameter("@sCveInd", sCveInd, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveSS", sCveSS, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveGTI", sCveGTI, SqlDbType.VarChar, ParameterDirection.Input)

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
                .subAddParameter("@idPais", cboPais.SelectedValue, SqlDbType.Int, ParameterDirection.Input)

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
                    .subAddParameter("@IdPaisRefGTI", cboReferenciaGTIPais.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idOficinaRefGTI", cboReferenciaGTIOficina.Text, SqlDbType.VarChar, ParameterDirection.Input)
                Else
                    .subAddParameter("@bRefGTI", 0, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@sNombSocioRefGTI", 0, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@IdPaisRefGTI", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idOficinaRefGTI", "", SqlDbType.VarChar, ParameterDirection.Input)
                End If

                If rdEmpresaExtranjeroRepSi.Checked Then
                    .subAddParameter("@bReportaExtranjero", 1, SqlDbType.Bit, ParameterDirection.Input)
                Else
                    .subAddParameter("@bReportaExtranjero", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If

                .subAddParameter("@sNombTenedora", txtEmpresaTenedora.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idPaisTenedora", cboPaisResidencia.SelectedValue, SqlDbType.Int, ParameterDirection.Input)

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

                .funExecuteSP("paSSGTDatosGenerales")
            End With

            ' MsgBox("Se registraron los datos generales correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertaGeneral()")
            MsgBox("Hubo un problema al registrar la información de datos generales, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub


#End Region

#Region "CONTACTO INICIAL"

    Private Sub ListarContactoInicial()
        Try
            Dim sTabla As String = "tbContactoInicial"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTContactoInicial", sTabla))

                dtContactoInicial = .Item(sTabla)
            End With

            If dtContactoInicial.Rows.Count > 0 Then
                lblMensajeCargaContactoInicial.Visible = False

                txtContactoInicialNombre.Text = dtContactoInicial.Rows(0).Item("sNombre").ToString
                txtContactoInicialCargo.Text = dtContactoInicial.Rows(0).Item("sCargo").ToString
                txtContactoInicialCorreo.Text = dtContactoInicial.Rows(0).Item("sCorreo").ToString
                txtContactoInicialTelefono.Text = dtContactoInicial.Rows(0).Item("sTelefono").ToString
                txtContactoInicialExtension.Text = dtContactoInicial.Rows(0).Item("sExtension").ToString
            Else
                lblMensajeCargaContactoInicial.Visible = True
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarContactoInicial()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtContactoInicial = Nothing
        End Try
    End Sub

    Private Sub InsertarContactoInicial()
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sNombreContacto", txtContactoInicialNombre.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCargo", txtContactoInicialCargo.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCorreo", txtContactoInicialCorreo.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sTelefono", txtContactoInicialTelefono.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sExtension", txtContactoInicialExtension.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paSSGTContactoInicial")
            End With

            'MsgBox("Se registraron los datos del contacto inicial correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarContactoInicial()")
            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

#End Region

#Region "ACERCAMIENTO"

    Private Sub ListarComoSeEnteroAcerca()
        Try
            Dim sTabla As String = "tbComoSeEnteroAcerca"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 0, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTAcercamiento", sTabla))

                dtComoSeEntero = .Item(sTabla)
            End With

            If dtComoSeEntero.Rows.Count > 0 Then
                cboAcercamientoComoEntero.DataSource = dtComoSeEntero

                cboAcercamientoComoEntero.ValueMember = "idAcercamiento"
                cboAcercamientoComoEntero.DisplayMember = "sAcercamiento"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarComoSeEnteroAcerca()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtComoSeEntero = Nothing
        End Try
    End Sub

    Private Sub ListarMedioContactoAcerca()
        Try
            Dim sTabla As String = "tbMedioContactoAcerca"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTAcercamiento", sTabla))

                dtMedioContacto = .Item(sTabla)
            End With

            If dtMedioContacto.Rows.Count > 0 Then
                cboAcercamientoMedioContacto.DataSource = dtMedioContacto

                cboAcercamientoMedioContacto.ValueMember = "idMedio"
                cboAcercamientoMedioContacto.DisplayMember = "sMedio"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarMedioContactoAcerca()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtMedioContacto = Nothing
        End Try
    End Sub
    Private Sub ListarAcercamiento()
        Try
            Dim sTabla As String = "tbAcercamiento"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTAcercamiento", sTabla))

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
                txtAcercamientoWebProspecto.Text = dtAcercamiento.Rows(0).Item("sWeb").ToString
            Else
                lblMensajeCargaAcercamiento.Visible = True
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarAcercamiento()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtAcercamiento = Nothing
        End Try
    End Sub
    Private Sub InsertarAcercamiento()
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idAcercamiento", cboAcercamientoComoEntero.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sOtroAcercamiento", txtAcercamientoEnteroOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idMedio", cboAcercamientoMedioContacto.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sotroMedio", txtAcercamientoContactoOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sWeb", txtAcercamientoWebProspecto.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paSSGTAcercamiento")
            End With

            'MsgBox("Se registraron los datos del acercamiento correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarAcercamiento()")
            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
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

    Private Sub ListarPaisDomicilio()
        Try
            Dim sTabla As String = "tbPaisDom"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDomicilio", sTabla))

                dtPaisDomicilio = .Item(sTabla)
            End With

            If dtPaisDomicilio.Rows.Count > 0 Then
                cboDomicilioPais.DataSource = dtPaisDomicilio

                cboDomicilioPais.ValueMember = "idPais"
                cboDomicilioPais.DisplayMember = "sPais"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarPaisDomicilio()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtPaisDomicilio = Nothing
        End Try
    End Sub

    Private Sub listarColoniasDomicilio(id As Integer, sValor As String, Optional sValor2 As String = "")
        Try
            Dim sTabla As String = "tbColDom"

            dtColoniasDomicilio.Clear()

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                    If id = 1 Then
                        .subAddParameter("@sCP", sValor, SqlDbType.VarChar, ParameterDirection.Input)
                    Else
                        .subAddParameter("@idMunicipio", CInt(sValor), SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@idEstado", CInt(sValor2), SqlDbType.Int, ParameterDirection.Input)
                    End If
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDomicilio", sTabla))
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
                    'MsgBox("Debes indicar un codigo postal valido", MsgBoxStyle.Information, "Codigo Postal")
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "listarColoniasDomicilio()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtColoniasDomicilio = Nothing
        End Try

    End Sub
    Private Sub ListarMunicipiosDomicilio(idEstado As Integer)
        Try
            Dim sTabla As String = "tbMunDom"

            dtMunicipiosDomicilio.Clear()

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idEstado", idEstado, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDomicilio", sTabla))

                dtMunicipiosDomicilio = .Item(sTabla)
            End With

            If dtMunicipiosDomicilio.Rows.Count > 0 Then
                cboDomicilioMunicipio.DataSource = dtMunicipiosDomicilio

                cboDomicilioMunicipio.ValueMember = "idMunicipio"
                cboDomicilioMunicipio.DisplayMember = "sMunicipio"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarMunicipiosDomicilio()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtMunicipiosDomicilio = Nothing
        End Try
    End Sub
    Private Sub ListarEstadosDomicilio()
        Try
            Dim sTabla As String = "tbEdosDom"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDomicilio", sTabla))

                dtEstadosDomicilio = .Item(sTabla)
            End With

            If dtEstadosDomicilio.Rows.Count > 0 Then
                cboDomicilioEstado.DataSource = dtEstadosDomicilio

                cboDomicilioEstado.ValueMember = "idEstado"
                cboDomicilioEstado.DisplayMember = "sEstado"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarEstadosDomicilio()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtEstadosDomicilio = Nothing
        End Try
    End Sub

    Private Sub ListarDomicilio()
        Try
            Dim sTabla As String = "tbDomicilio"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDomicilio", sTabla))

                dtDomicilio = .Item(sTabla)
            End With

            If dtDomicilio.Rows.Count > 0 Then
                lblMensajeCargaDomicilio.Visible = False

                cboDomicilioPais.SelectedValue = CInt(dtDomicilio.Rows(0).Item("idPais").ToString)

                If CInt(dtDomicilio.Rows(0).Item("idPais").ToString) = 151 Then
                    txtDomicilioCalle.Text = dtDomicilio.Rows(0).Item("sCalle").ToString
                    txtDomicilioNoExt.Text = dtDomicilio.Rows(0).Item("sNumExt").ToString
                    txtDomicilioNoInt.Text = dtDomicilio.Rows(0).Item("sNumInt").ToString
                    txtDomicilioCP.Text = dtDomicilio.Rows(0).Item("sCP").ToString

                    listarColoniasDomicilio(1, txtDomicilioCP.Text)

                    cboDomicilioEstado.SelectedValue = CInt(dtDomicilio.Rows(0).Item("idEstado").ToString)
                    cboDomicilioMunicipio.SelectedValue = CInt(dtDomicilio.Rows(0).Item("idMunicipio").ToString)
                    cboDomicilioColonia.SelectedValue = CInt(dtDomicilio.Rows(0).Item("idColonia").ToString)

                    txtDomicilioExtDireccion1.Text = ""
                    txtDomicilioExtLocalidad.Text = ""
                    txtDomicilioExtEstado.Text = ""
                Else
                    txtDomicilioExtDireccion1.Text = dtDomicilio.Rows(0).Item("sColonia").ToString
                    txtDomicilioExtLocalidad.Text = dtDomicilio.Rows(0).Item("sMunicipio").ToString
                    txtDomicilioExtEstado.Text = dtDomicilio.Rows(0).Item("sEstado").ToString

                    txtDomicilioCalle.Text = dtDomicilio.Rows(0).Item("sCalle").ToString
                    txtDomicilioNoExt.Text = dtDomicilio.Rows(0).Item("sNumExt").ToString
                    txtDomicilioNoInt.Text = dtDomicilio.Rows(0).Item("sNumInt").ToString
                    txtDomicilioCP.Text = dtDomicilio.Rows(0).Item("sCP").ToString
                End If
            Else
                lblMensajeCargaDomicilio.Visible = True

                LimpiarDatosDomicilio()
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDomicilio()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtFuncionarios = Nothing
        End Try
    End Sub
    Private Sub InsertarDomicilio()
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idPais", cboDomicilioPais.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                If cboDomicilioPais.SelectedValue = 151 Then
                    .subAddParameter("@sCalle", txtDomicilioCalle.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sNumExt", txtDomicilioNoExt.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sNumInt", txtDomicilioNoInt.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCP", txtDomicilioCP.Text, SqlDbType.VarChar, ParameterDirection.Input)

                    .subAddParameter("@idColonia", cboDomicilioColonia.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idEstado", cboDomicilioEstado.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idMunicipio", cboDomicilioMunicipio.SelectedValue, SqlDbType.Int, ParameterDirection.Input)

                    .subAddParameter("@sColonia", cboDomicilioColonia.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sEstado", cboDomicilioEstado.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sMunicipio", cboDomicilioMunicipio.Text, SqlDbType.VarChar, ParameterDirection.Input)
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

                .funExecuteSP("paSSGTDomicilio")
            End With

            ' MsgBox("Se registraron los datos del domicilio correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarDomicilio()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

#End Region

    '#Region "FUNCIONARIOS"

    '    Private Sub FormatoGridFuncionarios()
    '        gridFuncionarios.Columns("sCveProspecto").Visible = False
    '        gridFuncionarios.Columns("sNombre").Visible = False
    '        gridFuncionarios.Columns("sApellidoPaterno").Visible = False
    '        gridFuncionarios.Columns("sApellidoMaterno").Visible = False

    '        gridFuncionarios.Columns("sNombreFuncionario").HeaderText = "FUNCIONARIO"
    '        gridFuncionarios.Columns("sNombreFuncionario").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    '        gridFuncionarios.Columns("sCargo").HeaderText = "CARGO"
    '        gridFuncionarios.Columns("sCargo").Width = 150

    '        gridFuncionarios.Columns("sTelefono").HeaderText = "TELÉFONO"
    '        gridFuncionarios.Columns("sTelefono").Width = 100

    '        gridFuncionarios.Columns("sCorreo").HeaderText = "CORREO ELECTRÓNICO"
    '        gridFuncionarios.Columns("sCorreo").Width = 150
    '    End Sub
    '    Private Sub LimpiarDatosFuncionarios()
    '        txtFuncionariosNombre.Text = ""
    '        txtFuncionariosApellidoPaterno.Text = ""
    '        txtFuncionariosApellidoMaterno.Text = ""
    '        txtFuncionariosCargo.Text = ""
    '        txtFuncionariosTelefono.Text = ""
    '        txtFuncionariosCorreo.Text = ""
    '    End Sub

    '    Private Sub ListarFuncionarios()
    '        Try
    '            Dim sTabla As String = "tbFuncionarios"

    '            With ds.Tables
    '                LimpiarConsultaTabla(ds.Tables, sTabla)

    '                With clsDatosProp
    '                    .subClearParameters()
    '                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
    '                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
    '                End With

    '                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTFuncionarios", sTabla))

    '                dtFuncionarios = .Item(sTabla)
    '            End With

    '            If dtFuncionarios.Rows.Count > 0 Then
    '                lblMensajeCargaFuncionarios.Visible = False

    '                bsFun.DataSource = dtFuncionarios
    '                FormatoGridFuncionarios()
    '            Else
    '                lblMensajeCargaFuncionarios.Visible = True
    '            End If
    '        Catch ex As Exception
    '            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarFuncionarios()")
    '            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
    '            dtFuncionarios = Nothing
    '        End Try
    '    End Sub

    '    Private Sub InsertarFuncionario()
    '        Try
    '            With clsDatosProp
    '                .subClearParameters()
    '                .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sNombre", txtFuncionariosNombre.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sApellidoPaterno", txtFuncionariosApellidoPaterno.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sApellidoMaterno", txtFuncionariosApellidoMaterno.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sCargo", txtFuncionariosCargo.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sTelefono", txtFuncionariosTelefono.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sCorreo", txtFuncionariosCorreo.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

    '                .funExecuteSP("paSSGTFuncionarios")
    '            End With

    '            MsgBox("Se registraron los datos del funcionario correctamente.", MsgBoxStyle.Information, "SIAT")
    '        Catch ex As Exception
    '            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarFuncionario()")
    '            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
    '        End Try
    '    End Sub
    '    Private Sub ActualizarFuncionarios()
    '        Try
    '            With clsDatosProp
    '                .subClearParameters()
    '                .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sNombre", txtFuncionariosNombre.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sApellidoPaterno", txtFuncionariosApellidoPaterno.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sApellidoMaterno", txtFuncionariosApellidoMaterno.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sCargo", txtFuncionariosCargo.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sTelefono", txtFuncionariosTelefono.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sCorreo", txtFuncionariosCorreo.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

    '                .funExecuteSP("paSSGTFuncionarios")
    '            End With

    '            MsgBox("Se actualizaron los datos del domicilio correctamente.", MsgBoxStyle.Information, "SIAT")
    '        Catch ex As Exception
    '            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizarFuncionarios()")
    '            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
    '        End Try
    '    End Sub

    '#End Region

    '#Region "ACCIONISTAS"

    '    Private Sub FormatoGridAccionistas()
    '        gridAccionistas.Columns("sCveProspecto").Visible = False
    '        gridAccionistas.Columns("idTipoPersona").Visible = False
    '        gridAccionistas.Columns("sNombre").Visible = False
    '        gridAccionistas.Columns("sApellidoPaterno").Visible = False
    '        gridAccionistas.Columns("sApellidoMaterno").Visible = False

    '        gridAccionistas.Columns("sNombreAccionista").HeaderText = "ACCIONISTA"
    '        gridAccionistas.Columns("sNombreAccionista").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '        gridAccionistas.Columns("sTipoPersona").HeaderText = "TIPO DE PERSONA"
    '        gridAccionistas.Columns("sTipoPersona").Width = 130
    '        gridAccionistas.Columns("dPorcentaje").HeaderText = "%"
    '        gridAccionistas.Columns("dPorcentaje").Width = 65
    '        gridAccionistas.Columns("dPorcentaje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    End Sub
    '    Private Sub LimpiarDatosAccionistas()
    '        txtAccionistasNombre.Text = ""
    '        txtAccionistasApellidoPaterno.Text = ""
    '        txtAccionistasApellidoMaterno.Text = ""
    '        txtAccionistasPorcentaje.Text = "0.00"
    '        cboAccionistasTipoPersona.SelectedIndex = 0
    '    End Sub

    '    Private Sub ListarTipoPersonaAc()
    '        Try
    '            Dim sTabla As String = "tbTipoPersonaAc"

    '            With ds.Tables
    '                LimpiarConsultaTabla(ds.Tables, sTabla)

    '                With clsDatosProp
    '                    .subClearParameters()
    '                    .subAddParameter("@iOpcion", 0, SqlDbType.Int, ParameterDirection.Input)
    '                End With

    '                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTAccionistas", sTabla))

    '                dtTipoPersonaAc = .Item(sTabla)
    '            End With

    '            If dtTipoPersonaAc.Rows.Count > 0 Then
    '                cboAccionistasTipoPersona.DataSource = dtTipoPersonaAc

    '                cboAccionistasTipoPersona.ValueMember = "idTipoPersona"
    '                cboAccionistasTipoPersona.DisplayMember = "sTipoPersona"
    '            End If
    '        Catch ex As Exception
    '            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarTipoPersonaAc()")
    '            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
    '            dtTipoPersonaAc = Nothing
    '        End Try
    '    End Sub
    '    Private Sub ListarAccionistas()
    '        Try
    '            Dim sTabla As String = "tbAccionistas"

    '            With ds.Tables
    '                LimpiarConsultaTabla(ds.Tables, sTabla)

    '                With clsDatosProp
    '                    .subClearParameters()
    '                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
    '                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
    '                End With

    '                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTAccionistas", sTabla))

    '                dtAccionistas = .Item(sTabla)
    '            End With

    '            If dtAccionistas.Rows.Count > 0 Then
    '                lblMensajeCargaAccionistas.Visible = False

    '                bsAcc.DataSource = dtAccionistas
    '                FormatoGridAccionistas()
    '            Else
    '                lblMensajeCargaAccionistas.Visible = True
    '            End If
    '        Catch ex As Exception
    '            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarAccionistas()")
    '            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
    '            dtAccionistas = Nothing
    '        End Try
    '    End Sub

    '    Private Sub InsertarAccionista()
    '        Try
    '            With clsDatosProp
    '                .subClearParameters()
    '                .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sNombre", txtAccionistasNombre.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sApellidoPaterno", txtAccionistasApellidoPaterno.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sApellidoMaterno", txtAccionistasApellidoMaterno.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@idTipoPersona", cboAccionistasTipoPersona.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@dPorcentaje", CDec(txtAccionistasPorcentaje.Text), SqlDbType.Decimal, ParameterDirection.Input)
    '                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

    '                .funExecuteSP("paSSGTAccionistas")
    '            End With

    '            MsgBox("Se registraron los datos del accionista correctamente.", MsgBoxStyle.Information, "SIAT")
    '        Catch ex As Exception
    '            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarAccionista()")
    '            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
    '        End Try
    '    End Sub
    '    Private Sub ActualizarAccionista()
    '        Try
    '            With clsDatosProp
    '                .subClearParameters()
    '                .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sNombre", txtAccionistasNombre.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sApellidoPaterno", txtAccionistasApellidoPaterno.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@sApellidoMaterno", txtAccionistasApellidoMaterno.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@idTipoPersona", cboAccionistasTipoPersona.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@dPorcentaje", CDec(txtAccionistasPorcentaje.Text), SqlDbType.Decimal, ParameterDirection.Input)
    '                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

    '                .funExecuteSP("paSSGTAccionistas")
    '            End With

    '            MsgBox("Se actualziaron los datos del accionista correctamente.", MsgBoxStyle.Information, "SIAT")
    '        Catch ex As Exception
    '            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizarAccionista()")
    '            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
    '        End Try
    '    End Sub

    '#End Region

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
            sMsgContacto &= "- Especifíque el nombre de la persona que tuvo el contacto inicial." & vbNewLine & vbNewLine

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

        If Trim(txtContactoInicialCelular.Text) = "" Then
            sMsgContacto &= "- Especifíque el número celular del contacto inicial." & vbNewLine & vbNewLine

            bValidacion = False
        End If

        If Trim(txtAcercamientoWebProspecto.Text) = "" Then
            sMsgContacto &= "- Especifíque la página web del prospecto." & vbNewLine & vbNewLine

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
            sMsgAcercamiento &= "- Seleccione la opción de como se enteró del prospecto sobre nosotros." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If cboAcercamientoComoEntero.SelectedIndex = 12 AndAlso Trim(txtAcercamientoEnteroOtro.Text) = "" Then
            sMsgAcercamiento &= "- Especifíque el medio de contacto que utilizó el prospecto para contactarnos." & vbNewLine & vbNewLine
            bValidacion = False
        ElseIf cboAcercamientoComoEntero.SelectedIndex = 7 AndAlso Trim(txtAcercamientoEnteroOtro.Text) = "" Then
            sMsgAcercamiento &= "- Especifíque el nombre del socio que referenció al prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        ElseIf cboAcercamientoComoEntero.SelectedIndex = 8 AndAlso Trim(txtAcercamientoEnteroOtro.Text) = "" Then
            sMsgAcercamiento &= "- Especifíque el nombre del gerente que referenció al prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        ElseIf cboAcercamientoComoEntero.SelectedIndex = 11 AndAlso Trim(txtAcercamientoEnteroOtro.Text) = "" Then
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

        If cboDomicilioPais.SelectedValue <= 0 Then
            sMsgDomicilio &= "- Seleccione el país del domicilio del prospecto." & vbNewLine & vbNewLine
            bValidacion = False
        End If

        If cboDomicilioPais.SelectedIndex <> 151 Then
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

#End Region

End Class