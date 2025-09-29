Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports DocumentFormat.OpenXml.Drawing

Public Class FrmPropuestasNvo

#Region "VARIABLES"

    Private ds As New DataSet
    Private dtSolicitudes, DtDatos, dtFuncionarios, dtAccionistas, dtSocios, dtGerentes, dtRfc, dtRelacionadas, dtGpos, dtGrupos, dtCiclo As DataTable
    Private drGrupos As DataRow

    Private bsSol As New BindingSource
    Private bsFun As New BindingSource
    Private bsAcc As New BindingSource
    Private bsRel As New BindingSource
    Private bsGpo As New BindingSource
    Private bsTra As New BindingSource
    Public IdProp As Integer
    Private drDat As DataRow
    Private PasaGiro As Boolean = False
    Private PasaOficina As Boolean = False
    Private PasaNomb As Boolean = False
    Public Permite, RevConf As Boolean
    Public AnombrecteTem As String
    Public Dedonde As Integer
    Public AltaCte As Boolean = False
    Private Factura As Boolean = False
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private dtColonias, dtPropuesta, dtPaises, dtCartas, dtCorreos, dtHis, dtCliente, dtIndustrias, dtSubSectores, dtSubNiveles, dtPaisGt, dtAutorizaGt, dtSocEncargado, dtProspecto As DataTable
    Private dtFactores, dtBolsaValores, dtEntidadReg, dtNormatividad, dtPaisResidencia, dtPaisOtro, dtTipoEntidad, dtClasificacionCte, dtTrabajos As DataTable
    Private dtEjeY, dtEjeX, dtMatriz, dtOtrosDatos As DataTable
    Private drPaises As DataRow
    Private sNameRpt As String = "Frm Propuesta."
    Private Nom, Apat, Amat, CargoTemp, perMoralTemp, PorcTemp, Colonia, Municipio, Estado, SECTOR, sCveSocio, sCveGerente, sSocRef, sNombGerente, sNomSocio As String
    Private Referido, Tenedora, tpoRechazo, stProp, stPropH, RevInde As Integer
    Public TpoProp, tpoMoneda As Char
    Public CveOfi, CveArea, sCveGpo, sGpoDesc, sEstatus, sMailGent, sMailSoc As String
    Private Cveofiref, Cvearearef, Cvesocref, Socio, CveSocio, CveGerente, CveCte, NomEmpresa, CveEmpRef, NombEmpRef, Indus, SubSec, SubNiv, sCveProspecto As String
    Private bHabilitar As Boolean = False
    Private iIngSoc, iLiqSoc, iRenSoc, iIma, iRep, iRie, iEsp, iFila, iCargable, iLiquidez, iIngresos, iRentabilidad As Integer
    Private sColSoc, sNombreCliente, sClasificacionCte, sTipoSolicitud, sCicloOperativo As String
    Private dtColoniasDomicilio, dtMunicipiosDomicilio, dtEstadosDomicilio As DataTable
    Private sFmtInt As String = "#,##0"
    Dim Msnj As String = ""
    Public CorreosSoc, NombSoc As String


#End Region

#Region "EVENTOS"
    Private Sub FrmPropuestasNvo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvFuncionarios.DataSource = bsFun
        dgvAccionistas.DataSource = bsAcc
        gbTrabajos.DataSource = bsTra

        dgvRelacionadas.DataSource = bsRel
        dgGrupos.DataSource = bsGpo

        IdProp = IdProp
        TpoProp = TpoProp

        CrearTablas()

        CargaCombos()
        ListarPaisResidencia()
        LimpiaGT()
        listarIndustrias()
        ListarBolsaValores()

        If IdProp <> 0 Then

            ConsultaPropuesta()

            ConsultaSocio(sCveSocio)
            ConultaGerente(sCveGerente)

            ConsultaCveCliente()


            ConsultaFuncionariosGrupo(sCveGpo)
            ConsultaFuncionariosGrupo(sCveGpo)

            If CveCte <> "" Then
                ConsultaFuncionariosClientes()
                ConsultaAccionistasClientes()
            Else
                ConsultaFuncionarios()
                ConsultaAccionistas()
            End If


            ConsultaRelacionadas()

            'If TpoProp = "R" Or TpoProp = "S" Then
            '    Ccvegpo.Text = sCveGpo
            '    Cdescgpo.Text = sGpoDesc

            '    ConsultaFuncionariosClientes()
            '    ConsultaAccionistasClientes()

            '    btnAsignar.Visible = False

            'Else
            '    Ccvegpo.Text = sCveGpo
            '    Cdescgpo.Text = sGpoDesc

            '    ConsultaFuncionarios()
            '    ConsultaAccionistas()

            'End If
            'ConsultaRelacionadas()


            Select Case sCveGpo
                Case "0099", "0025", "", "0001"
                Case CveCte = ""
                Case Else
                    Cdescgpo.Enabled = False
                    Ccvegpo.Enabled = False

                    Ccvegpo.Text = sCveGpo
                    Cdescgpo.Text = sGpoDesc
                    If dtAccionistas.Rows.Count = 0 Then
                        ConsultaAccionistasGrupo(sCveGpo)
                    End If
                    If dtFuncionarios.Rows.Count = 0 Then
                        ConsultaFuncionariosGrupo(sCveGpo)
                    End If
                    ConsultaGrupos(sCveGpo)
            End Select

            'Clasificacion Cte


            ListarFactores()
            If dtFactores Is Nothing Then
                Exit Sub
            End If

            ListarMatriz()
            If dtMatriz Is Nothing Then
                Exit Sub
            End If

            ListarEjeX()
            If dtEjeX Is Nothing Then
                Exit Sub
            End If

            ListarEjeY()
            If dtEjeY Is Nothing Then
                Exit Sub
            End If



            ListarCombo(cboIngreso, 1)
            ListarCombo(cboLiquidez, 2)
            ListarCombo(cboRentabilidad, 3)
            ListarCombo(cboImagen, 4)
            ListarCombo(cboReputacion, 5)
            ListarCombo(cboRiesgo, 6)
            ListarCombo(cboEspecializacion, 7)

            cboIngreso.SelectedIndex = 0
            cboLiquidez.SelectedIndex = 0
            cboRentabilidad.SelectedIndex = 0
            cboImagen.SelectedIndex = 0
            cboReputacion.SelectedIndex = 0
            cboRiesgo.SelectedIndex = 0
            cboEspecializacion.SelectedIndex = 0


            If CveCte <> "" Then
                ListarClasificacionClientes()
            Else
                If IdProp <> 0 Then
                    ListarClasificacionClientesPropuesta()
                End If
            End If

            ConsultaOtrosDatos()

        End If
        Permite = True
        PasaNomb = True


        If sTipo = 2 Then
            gpBoxCheck.Visible = True
            gpBoxConflict.Visible = True
            gpBoxConflict.Enabled = False
        ElseIf sTipo = 3 Then
            gpBoxConflict.Visible = True
            gpBoxCheck.Visible = True
            gpBoxCheck.Enabled = False

        End If

        ConsultaTrabajos()
        ConsultaAutorizacion()

    End Sub
    Private Sub Bcancelar_Click(sender As System.Object, e As System.EventArgs) Handles Bcancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    'Private Sub Cnombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)

    'End Sub
    'Private Sub Cnombre_TextChanged(sender As System.Object, e As System.EventArgs)
    '    Cnombre.CharacterCasing = CharacterCasing.Upper

    '    If PasaNomb Then
    '        If Cnombre.Text.Length > 0 Then
    '            CargaDatos()
    '            Aplicar_FiltroNombre()
    '        End If

    '    End If
    'End Sub
    Private Sub Ccontactoinicial_TextChanged(sender As System.Object, e As System.EventArgs)
        Ccontactoinicial.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Ccargocompania_TextChanged(sender As System.Object, e As System.EventArgs)
        Ccargocompania.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Ccalle_TextChanged(sender As System.Object, e As System.EventArgs)
        'Ccalle.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub txtColonia_TextChanged(sender As System.Object, e As System.EventArgs)
        txtColonia.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub TxtMunicipio_TextChanged(sender As System.Object, e As System.EventArgs)
        txtMunicipio.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Baceptar_Click(sender As System.Object, e As System.EventArgs) Handles Baceptar.Click

        If sTipo = 2 Then
            Dim nivel As Integer = ComboNivel.SelectedValue
            ActualizaNivel(nivel)
            ActualizaCalificacionConflick(nivel)
            'ConsultaCorreosBack()

            DialogResult = Windows.Forms.DialogResult.OK
            MsgBox("Se actualizo la propuesta de manera correcta!", MsgBoxStyle.Information, "Cliente prospecto")

        ElseIf sTipo = 3 Then
            Dim Ind As Integer

            If rbNOIndepen.Checked Then
                Ind = 1
            ElseIf rbSiIndepen.Checked Then
                Ind = 2
            End If
            ActualizaConflict(Ind)
            ActualizaCalificacionIndependencia(Ind)
            ConsultaCorreos()
            EnvioCorreoSocios()


            DialogResult = Windows.Forms.DialogResult.OK
            MsgBox("Se actualizo la propuesta de manera correcta!", MsgBoxStyle.Information, "Cliente prospecto")
        End If

    End Sub
    Private Sub cPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cPais.SelectedIndexChanged
        If cPais.SelectedIndex = 0 Then
            cColonia.Visible = True
            Cestado.Visible = True
            cMunicipio.Visible = True

            txtColonia.Visible = False
            txtEstado.Visible = False
            txtMunicipio.Visible = False
        Else
            txtColonia.Visible = True
            txtEstado.Visible = True
            txtMunicipio.Visible = True

            cColonia.Visible = False
            Cestado.Visible = False
            cMunicipio.Visible = False

        End If

    End Sub
    Private Sub Ccp_Leave(sender As Object, e As EventArgs) Handles Ccp.Leave
        listarColonias()
    End Sub
    Private Sub listarColonias()

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iCp", Ccp.Text.Trim, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
                dtColonias = .Item("paEmpresaPropuesta")

                If dtColonias.Rows.Count > 0 Then

                    sSQL = "SELECT idEstado,sEstado FROM CAT_ESTADOS WHERE idEstado = " & CInt(dtColonias(0)("idEstado").ToString())
                    Carga_ComboSapyc(Cestado, sSQL)

                    sSQL = "SELECT idMunicipio,sMunicipio FROM CAT_MUNICIPIOS WHERE idEstado = " & CInt(dtColonias(0)("idEstado").ToString())
                    Carga_ComboSapyc(cMunicipio, sSQL)

                    sSQL = "SELECT idColonia,sColonia FROM CAT_COLONIAS WHERE idEstado = " & CInt(dtColonias(0)("idEstado").ToString()) & " AND idMunicipio = " & CInt(dtColonias(0)("idMunicipio").ToString())
                    Carga_ComboSapyc(cColonia, sSQL)

                    cColonia.SelectedValue = CInt(dtColonias(0)("idColonia").ToString())
                    Cestado.SelectedValue = CInt(dtColonias(0)("idEstado").ToString())
                    cMunicipio.SelectedValue = CInt(dtColonias(0)("idMunicipio").ToString())

                Else
                    'MsgBox("Debes indicar un codigo postal valido", MsgBoxStyle.Information, "Codigo Postal")
                    Exit Sub
                End If


            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub btnGuardaDF_Click(sender As Object, e As EventArgs)

        'If Crfc.Text = "" Then
        '    MsgBox("No se capturo el RFC del cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error en captura")
        '    Exit Sub
        'End If
        'If Ccalle.Text = "" Then
        '    MsgBox("No se capturo la calle del domicilio del cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error en captura")
        '    Exit Sub
        'End If
        'If Cnumext.Text = "" Then
        '    MsgBox("No se capturo el numero exterior del domicilio del cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error en captura")
        '    Exit Sub
        'End If
        'If cColonia.Text = "" Then
        '    MsgBox("No se capturo la colonia del domicilio del cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error en captura")
        '    Exit Sub
        'End If
        'If cMunicipio.Text = "" Then
        '    MsgBox("No se capturo la delegación o municipio del domicilio del cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error en captura")
        '    Exit Sub
        'End If
        'If Cestado.Text = "" Then
        '    MsgBox("No se capturo el estado del domicilio del cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error en captura")
        '    Exit Sub
        'End If
        'If cPais.Text = "" Then
        '    MsgBox("No se capturo el pais del domicilio del cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error en captura")
        '    Exit Sub
        'End If
        'If Ccp.Text = "" Then
        '    MsgBox("No se capturo el CP del domicilio del cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error en captura")
        '    Exit Sub
        'End If



    End Sub
    Private Sub Lista_DoubleClick(sender As Object, e As System.EventArgs)
        'If Lista.SelectedRows.Count > 0 Then

        '    Lista.Visible = True
        '    ' filtrar por el campo Nombrecte
        '    Dim ret As Integer = Filtrar_DataGridView("NOMBRE", Cnombre.Text.Trim, BindingSource1, Lista)

        '    If ret > 0 Then
        '        ' si no hay registros cambiar el color del txtbox   
        '        Cnombre.BackColor = Color.Red
        '        If MsgBox("¿Este cliente se encuentra en las listas de clientes restringidos y no podras usarlo, si continuas se cerrara la pantalla?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta") = MsgBoxResult.Yes Then
        '            LimpiaPan()
        '            AltaCte = True
        '            Lista.Visible = False
        '            PasaNomb = False
        '            'Cnombre.Text = Lista.CurrentRow.Cells("NOMBRE").Value
        '            Cnombre.Text = ""
        '            Me.Close()


        '        End If
        '    Else
        '        Cnombre.BackColor = Color.White
        '    End If

        'End If
    End Sub
    Private Sub rbSi_CheckedChanged(sender As Object, e As EventArgs) Handles rbSi.CheckedChanged
        rbNo.Checked = False
        lblMotivo.Visible = True
        txtMotivoIndepen.Visible = True
    End Sub
    Private Sub rbNo_CheckedChanged(sender As Object, e As EventArgs) Handles rbNo.CheckedChanged
        rbSi.Checked = False
        lblMotivo.Visible = False
        txtMotivoIndepen.Visible = False
    End Sub
    Private Sub OpSi_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles OpSi.CheckedChanged
        If OpSi.Checked Then
            CuadroTra.Enabled = True
            'Ccvegpo.Text = "0025"
            'Cdescgpo.SelectedValue = Ccvegpo.Text
            'Cdescgpo.Enabled = False
        End If
    End Sub
    Private Sub OpNo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles OpNo.CheckedChanged
        If OpNo.Checked Then
            CuadroTra.Enabled = False
            LimpiaGT()
            'Ccvegpo.Text = "0099"
            'Cdescgpo.SelectedValue = Ccvegpo.Text
            'Cdescgpo.Enabled = True
            'Me.rdNoCompañia.Checked = True
        End If
    End Sub
    Private Sub cmbPaisGT_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbPaisGT.SelectionChangeCommitted
        If cmbPaisGT.SelectedIndex <> -1 Then
            sSQL = "SELECT iPais, sOficina FROM CATA_GT_OFICINAS WHERE iPais = '" & cmbPaisGT.SelectedValue & "' "
            Carga_ComboSapyc(cmbOfiGT, sSQL)
        End If
    End Sub
    Private Sub cboCalificacion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboRiesgo.SelectionChangeCommitted, cboReputacion.SelectionChangeCommitted, cboRentabilidad.SelectionChangeCommitted, cboLiquidez.SelectionChangeCommitted, cboIngreso.SelectionChangeCommitted, cboImagen.SelectionChangeCommitted, cboEspecializacion.SelectionChangeCommitted
        If DirectCast(sender, ComboBox).SelectedIndex = -1 Then
            Exit Sub
        End If

        Select Case DirectCast(sender, ComboBox).Name
            Case "cboIngreso"
                txtCalIngresoSocio.Text = Format(CInt(DirectCast(sender, ComboBox).SelectedValue), sFmtInt)
                SumarPuntosImpEco()

            Case "cboLiquidez"
                txtCalLiquidezSocio.Text = Format(CInt(DirectCast(sender, ComboBox).SelectedValue), sFmtInt)
                SumarPuntosImpEco()

            Case "cboRentabilidad"
                txtCalRentabilidadSocio.Text = Format(CInt(DirectCast(sender, ComboBox).SelectedValue), sFmtInt)
                SumarPuntosImpEco()

            Case "cboImagen"
                txtCalImagen.Text = Format(CInt(DirectCast(sender, ComboBox).SelectedValue), sFmtInt)
                SumarPuntosImpEst()

            Case "cboReputacion"
                txtCalReputacion.Text = Format(CInt(DirectCast(sender, ComboBox).SelectedValue), sFmtInt)
                SumarPuntosImpEst()

            Case "cboRiesgo"
                txtCalRiesgo.Text = Format(CInt(DirectCast(sender, ComboBox).SelectedValue), sFmtInt)
                SumarPuntosImpEst()

            Case "cboEspecializacion"
                txtCalEspecializacion.Text = Format(CInt(DirectCast(sender, ComboBox).SelectedValue), sFmtInt)
                SumarPuntosImpEst()

        End Select
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
    Private Sub rdEmpresaExtranjeroRepNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdEmpresaExtranjeroRepNo.CheckedChanged
        If rdEmpresaExtranjeroRepNo.Checked Then
            txtEmpresaTenedora.Enabled = False
            cmbPaisRes.Enabled = False
        End If
    End Sub
    Private Sub rdEmpresaExtranjeroRepSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdEmpresaExtranjeroRepSi.CheckedChanged
        txtEmpresaTenedora.Enabled = True
        cmbPaisRes.Enabled = True
    End Sub
    Private Sub rdEmpresaPublicaSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdEmpresaPublicaSi.CheckedChanged
        HabilitarCombo(cboBolsaValores, True)
    End Sub
    Private Sub rdEmpresaPublicaNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdEmpresaPublicaNo.CheckedChanged
        HabilitarCombo(cboBolsaValores, False)
        cboBolsaValores.SelectedIndex = 0

        txtBolsaValoresOtro.Enabled = False
        txtBolsaValoresOtro.Text = ""

        rbtNoMex.Checked = True
        rbtNoExt.Checked = True
        txtMexicana.Text = ""
        txtExtranjera.Text = ""
    End Sub
    Private Sub rbtSiMex_CheckedChanged(sender As Object, e As EventArgs) Handles rbtSiMex.CheckedChanged
        If rbtSiMex.Checked Then
            rbtNoMex.Checked = False
            txtMexicana.Enabled = True
        End If
    End Sub
    Private Sub rbtNoMex_CheckedChanged(sender As Object, e As EventArgs) Handles rbtNoMex.CheckedChanged
        If rbtNoMex.Checked Then
            rbtSiMex.Checked = False
            txtMexicana.Enabled = False
        End If
    End Sub
    Private Sub rbtSiExt_CheckedChanged(sender As Object, e As EventArgs) Handles rbtSiExt.CheckedChanged
        If rbtSiExt.Checked Then
            rbtNoExt.Checked = False
            txtExtranjera.Enabled = True
        End If
    End Sub
    Private Sub rbtNoExt_CheckedChanged(sender As Object, e As EventArgs) Handles rbtNoExt.CheckedChanged
        If rbtNoExt.Checked Then
            rbtSiExt.Checked = False
            txtExtranjera.Enabled = False
        End If
    End Sub
    Private Sub cboBolsaValores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBolsaValores.SelectedIndexChanged
        If cboBolsaValores.SelectedValue = 0 Then
            rbtSiMex.Checked = False
            rbtNoMex.Checked = False

            rbtSiExt.Checked = False
            rbtNoExt.Checked = False

            txtMexicana.Text = ""
            txtExtranjera.Text = ""

            txtMexicana.Enabled = False
            txtExtranjera.Enabled = False
        ElseIf cboBolsaValores.SelectedValue = 1 Then
            txtBolsaValoresOtro.Enabled = False

            rbtSiMex.Checked = True
            rbtNoMex.Checked = False
            txtMexicana.Text = cboBolsaValores.Text

            rbtSiExt.Checked = False
            rbtNoExt.Checked = True
            txtExtranjera.Text = ""
        ElseIf cboBolsaValores.SelectedValue = 5 Then
            txtBolsaValoresOtro.Enabled = True

            rbtSiMex.Checked = False
            rbtNoMex.Checked = True

            rbtSiExt.Checked = False
            rbtNoExt.Checked = True

            txtMexicana.Text = ""
            txtExtranjera.Text = ""
        Else
            txtBolsaValoresOtro.Enabled = False

            rbtSiMex.Checked = False
            rbtNoMex.Checked = True
            txtMexicana.Text = ""

            rbtSiExt.Checked = True
            txtExtranjera.Text = cboBolsaValores.Text
        End If
    End Sub


#End Region
#Region "METODOS"
    Private Sub ConsultaAutorizacion()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 46, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPropuesta", IdProp, SqlDbType.VarChar, ParameterDirection.Input)
            End With

            If .Contains("paEmpresaPropuesta") Then
                .Remove("paEmpresaPropuesta")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            DtDatos = .Item("paEmpresaPropuesta")

            If DtDatos.Rows.Count > 0 Then
                'txtProp.Text = DtDatos(0)("IDPROP").ToString()
                'txtFecha.Text = DtDatos(0)("FECHAREG").ToString()
                'txtProvedor.Text = DtDatos(0)("NOMEMPRESA").ToString()
                'txtEmpleado.Text = DtDatos(0)("NOMBRE").ToString()

                txtServicio.Text = DtDatos(0)("sServicioPropuesto").ToString()
                txtAcercamiento.Text = DtDatos(0)("sAcercamiento").ToString()
                txtIntegrante.Text = DtDatos(0)("sAutorizoPais").ToString()
                txtAutorizo.Text = DtDatos(0)("sNombreAutoriza").ToString()

            End If
        End With
    End Sub
    Private Sub ConsultaTrabajos()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 12, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveCte", CveCte, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            dtTrabajos = .Item("paSapyc")

            If dtTrabajos.Rows.Count > 0 Then
                bsTra.DataSource = dtTrabajos
            End If


        End With
    End Sub
    Private Sub InsertarClasificacion()
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 15, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveCte", CveCte, SqlDbType.VarChar, ParameterDirection.Input, 20)
                .subAddParameter("@sCveSocio", CveSocio, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sClasificacion", sClasificacionCte, SqlDbType.VarChar, ParameterDirection.Input, 100)
                .subAddParameter("@sClasificacionSocio", "SIN CLASIFICACIÓN", SqlDbType.VarChar, ParameterDirection.Input, 100)

                .funExecuteSP("paClasificacionCliente")
            End With

            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveCte", CveCte, SqlDbType.VarChar, ParameterDirection.Input, 20)
                .subAddParameter("@sCveSocio", CveSocio, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@iImpEcoSoc", CInt(txtImpactoEcoSocio.Text), SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iImpEco", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iImpEst", CInt(txtImpactoEst.Text), SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iNumFactorUnoSoc", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorUnoSoc", cboIngreso.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorUnoSoc", CDbl(txtHonorarios.Text), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@iNumFactorDosSoc", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorDosSoc", cboLiquidez.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iNumFactorTresSoc", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorTresSoc", cboRentabilidad.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorUno", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorUno", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorUno", 0, SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@iFactorDos", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorDos", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorTres", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorTres", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorCuatro", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorCuatro", cboImagen.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorCinco", 5, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorCinco", cboReputacion.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorSeis", 6, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorSeis", cboRiesgo.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorSiete", 7, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorSiete", cboEspecializacion.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorOcho", 8, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorOcho", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorNueve", 9, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorNueve", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorDiez", 10, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorDiez", 0, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paClasificacionCliente")
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarClasificacion()")
            MsgBox("Hubo un inconveniente al registrar la información de la clasificación, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub InsertarClasificacionProp()
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 22, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", IdProp, SqlDbType.VarChar, ParameterDirection.Input, 20)
                .subAddParameter("@sCveSocio", CveSocio, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sClasificacion", sClasificacionCte, SqlDbType.VarChar, ParameterDirection.Input, 100)
                .subAddParameter("@sClasificacionSocio", sClasificacionCte, SqlDbType.VarChar, ParameterDirection.Input, 100)

                .funExecuteSP("paClasificacionCliente")
            End With

            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 23, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", IdProp, SqlDbType.VarChar, ParameterDirection.Input, 20)
                .subAddParameter("@sCveSocio", CveSocio, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@iImpEcoSoc", CInt(txtImpactoEcoSocio.Text), SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iImpEco", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iImpEst", CInt(txtImpactoEst.Text), SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iNumFactorUnoSoc", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorUnoSoc", cboIngreso.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorUnoSoc", CDbl(txtHonorarios.Text), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@iNumFactorDosSoc", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorDosSoc", cboLiquidez.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iNumFactorTresSoc", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorTresSoc", cboRentabilidad.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorUno", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorUno", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorUno", 0, SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@iFactorDos", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorDos", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorTres", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorTres", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorCuatro", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorCuatro", cboImagen.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorCinco", 5, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorCinco", cboReputacion.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorSeis", 6, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorSeis", cboRiesgo.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorSiete", 7, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorSiete", cboEspecializacion.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorOcho", 8, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorOcho", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorNueve", 9, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorNueve", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iFactorDiez", 10, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iValorFactorDiez", 0, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paClasificacionCliente")
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarClasificacion()")
            MsgBox("Hubo un inconveniente al registrar la información de la clasificación, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub HabilitarCombo(cbo As ComboBox, bValor As Boolean)
        If bValor Then
            cbo.Enabled = True
        Else
            cbo.Enabled = False
        End If
    End Sub
    Private Sub ColorClasificacion()
        If sClasificacionCte = "BRONCE" Then
            txtClasificacionCte.BackColor = bronce_Salles
            txtClasificacionCte.ForeColor = bronce_letra_Salles
        ElseIf sClasificacionCte = "ORO" Then
            txtClasificacionCte.BackColor = oro_Salles
            txtClasificacionCte.ForeColor = oro_letra_Salles
        ElseIf sClasificacionCte = "PLATINUM" Then
            txtClasificacionCte.BackColor = platinum_Salles
            txtClasificacionCte.ForeColor = platinum_letra_Salles
        ElseIf sClasificacionCte = "DIAMANTE" Then
            txtClasificacionCte.BackColor = diamante_Salles
            txtClasificacionCte.ForeColor = diamante_letra_Salles
        End If
    End Sub
    Private Sub SumarPuntosImpEco()
        Try
            iIngSoc = 0
            iLiqSoc = 0
            iRenSoc = 0

            If txtCalIngresoSocio.Text <> "" Then
                iIngSoc = CInt(txtCalIngresoSocio.Text)
            End If

            If txtCalLiquidezSocio.Text <> "" Then
                iLiqSoc = CInt(txtCalLiquidezSocio.Text)
            End If

            If txtCalRentabilidadSocio.Text <> "" Then
                iRenSoc = CInt(txtCalRentabilidadSocio.Text)
            End If

            txtImpactoEcoSocio.Text = Format(iIngSoc + iLiqSoc + iRenSoc, sFmtInt)

            iFila = ObtenerFila(CInt(txtImpactoEst.Text))
            sColSoc = ObtenerColumna(CInt(txtImpactoEcoSocio.Text))

            'sNombreCliente = "PRUEBA OCTAVIO"

            If NomEmpresa.Contains("GRANT THORNTON") Then
                If ObtenerClasificacion(iFila, sColSoc) = "BRONCE" Then
                    sClasificacionCte = "ORO"
                Else
                    sClasificacionCte = ObtenerClasificacion(iFila, sColSoc)
                End If
            Else
                sClasificacionCte = ObtenerClasificacion(iFila, sColSoc)
            End If

            txtClasificacionCte.Text = sClasificacionCte
            ColorClasificacion()
        Catch ex As Exception
            'insertarErrorLog(400, sNameRpt, ex.Message, sCveUsuario, "SumarPuntosImpEco()")
        End Try
    End Sub
    Private Sub SumarPuntosImpEst()
        Try
            iIma = 0
            iRep = 0
            iRie = 0
            iEsp = 0

            If txtCalImagen.Text <> "" Then
                iIma = CInt(txtCalImagen.Text)
            End If

            If txtCalReputacion.Text <> "" Then
                iRep = CInt(txtCalReputacion.Text)
            End If

            If txtCalRiesgo.Text <> "" Then
                iRie = CInt(txtCalRiesgo.Text)
            End If

            If txtCalEspecializacion.Text <> "" Then
                iEsp = CInt(txtCalEspecializacion.Text)
            End If

            txtImpactoEst.Text = Format(iIma + iRep + iRie + iEsp, sFmtInt)

            iFila = ObtenerFila(CInt(txtImpactoEst.Text))
            sColSoc = ObtenerColumna(CInt(txtImpactoEcoSocio.Text))

            Select Case ObtenerClasificacion(iFila, sColSoc)
                Case "BRONCE"
                    If NomEmpresa.Contains("GRANT THORNTON") Then
                        sClasificacionCte = "ORO"
                    Else
                        sClasificacionCte = ObtenerClasificacion(iFila, sColSoc)
                    End If

                Case "ORO"
                    sClasificacionCte = ObtenerClasificacion(iFila, sColSoc)

                Case "PLATINUM"
                    sClasificacionCte = ObtenerClasificacion(iFila, sColSoc)

                Case "DIAMANTE"
                    sClasificacionCte = ObtenerClasificacion(iFila, sColSoc)

            End Select

            txtClasificacionCte.Text = sClasificacionCte
            ColorClasificacion()
        Catch ex As Exception
            'insertarErrorLog(400, sNameRpt, ex.Message, sCveUsuario, "SumarPuntosImpEst()")
        End Try
    End Sub
    Private Function ObtenerFila(dPonderacion As Double) As String
        Dim sFila As String = ""

        For y As Integer = 0 To dtEjeY.Rows.Count - 1
            If dPonderacion <= CDbl(dtEjeY.Rows(y).Item("dPonderacion")) Then
                sFila = dtEjeY.Rows(y).Item("iFila")
            End If
        Next

        Return sFila
    End Function
    Private Function ObtenerColumna(dPonderacion As Double) As String
        Dim sColumna As String = ""

        For x As Integer = 0 To dtEjeX.Rows.Count - 1
            If dPonderacion <= CDbl(dtEjeX.Rows(x).Item("dPonderacion")) Then
                sColumna = dtEjeX.Rows(x).Item("sColumna")
            End If
        Next

        Return sColumna
    End Function
    Private Sub ListarCombo(combo As ComboBox, id As Integer)
        combo.DataSource = LlenarCombo(id)
        combo.DisplayMember = "sValor"
        combo.ValueMember = "iValor"
    End Sub
    Private Function LlenarCombo(id As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr(), drFila As DataRow

        Try
            dt.Columns.Add("iValor", GetType(String))
            dt.Columns.Add("sValor", GetType(String))

            dr = dtFactores.Select("iFactor = " & id)

            If dr.Count > 0 Then
                For f As Integer = 0 To dr.Count - 1
                    drFila = dt.NewRow
                    drFila("iValor") = dr(f).Item("iValor")
                    drFila("sValor") = dr(f).Item("sValor")
                    dt.Rows.InsertAt(drFila, dt.Rows.Count)
                Next
            Else
                dt = Nothing
            End If
        Catch ex As Exception
            'insertarErrorLog(201, sNameRpt, ex.Message, sCveUsuario, "LlenarCombo()")
        End Try

        Return dt
    End Function
    Private Sub CargaCombos()

        sSQL = "SELECT CVE, DESCRIPCION FROM MedioDeContacto ORDER BY CVE"
        Carga_ComboSapyc(cboMedioContacto, sSQL)

        sSQL = "SELECT CVE, DESCRIPCION FROM ESTATUSPROPUESTA ORDER BY CVE"
        Carga_ComboSapyc(Cestatuspropuesta, sSQL)

        sSQL = "SELECT idPais ,sPais FROM CAT_PAISES ORDER BY sCveTributacion DESC "
        Carga_ComboSapyc(cPais, sSQL)

        sSQL = "SELECT IDNIVEL,NIVELRIESGO FROM NIVELRIESGO ORDER BY IDNIVEL"
        Carga_ComboSapyc(ComboNivel, sSQL)
        ComboNivel.SelectedIndex = -1

        sSQL = "SELECT IDMOTIVO,MOTIVO FROM MOTIVODERECHAZO ORDER BY IDMOTIVO"
        Carga_ComboSapyc(CRechazo, sSQL)

        sSQL = "SELECT CVE, DESCRIPCION FROM ComoSeEntero ORDER BY CVE"
        Carga_ComboSapyc(Ccomoentero, sSQL)

        sSQL = "SELECT CVE, DESCRIPCION FROM PERIODODEREVISION ORDER BY CVE"
        Carga_ComboSapyc(Cayorevision, sSQL)

        sSQL = "SELECT CVE, DESCRIPCION FROM CICLOOPERATIVO ORDER BY CVE"
        Carga_ComboSapyc(Cciclooperativo, sSQL)

        'Pais GT
        sSQL = "SELECT idPais, sPais FROM CAT_PAISES  ORDER BY sPais"
        Carga_ComboSapyc(cmbPaisGT, sSQL)
        cmbPaisGT.SelectedIndex = -1
        'Oficina GT
        sSQL = "SELECT iPais, sOficina FROM CATA_GT_OFICINAS  ORDER BY iPais"
        Carga_ComboSapyc(cmbOfiGT, sSQL)
        cmbOfiGT.SelectedIndex = -1

        sSQL = "SELECT idPais, sPais FROM CAT_PAISES ORDER BY idPais"
        Carga_ComboSapyc(cmbPaisRes, sSQL)
        cmbPaisRes.SelectedIndex = 0

        ListarEntidad()
        ListarNormatividad()
        ListarPaisResidencia()
        ListarTipoEntidad()

    End Sub
    Private Sub ConsultaFuncionarios()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            dtFuncionarios = .Item("paSapyc")

            If dtFuncionarios.Rows.Count > 0 Then
                bsFun.DataSource = dtFuncionarios
            End If


        End With
    End Sub
    Private Sub ConsultaAccionistas()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            dtAccionistas = .Item("paSapyc")

            If dtAccionistas.Rows.Count > 0 Then

                If dtAccionistas.Rows.Count > 0 Then
                    bsAcc.DataSource = dtAccionistas
                End If

            End If

        End With
    End Sub
    Private Sub ConsultaRelacionadas()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 10, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            dtRelacionadas = .Item("paSapyc")

            If dtRelacionadas.Rows.Count > 0 Then
                bsRel.DataSource = dtRelacionadas
            End If

        End With
    End Sub
    Public Sub LimpiaPan()
        'Cnombre.Text = ""
        'Ccontactoinicial.Text = ""
        'Ccargocompania.Text = ""
        'Ctelefono.Text = ""
        'Cemailcontacto.Text = ""
        'Ctelefono.Text = ""
        'Cextension.Text = ""
        'AnombrecteTem = ""
        'Crfc.Text = ""

        'Ccalle.Text = ""
        'Cnumext.Text = ""
        'Cnumint.Text = ""
        'cColonia.Text = ""
        'cMunicipio.Text = ""
        'Ccp.Text = ""
        'Cpaginaweb.Text = ""

        'sSQL = "SELECT CVE, DESCRIPCION  FROM GIROS ORDER BY CVE"
        'Carga_ComboSapyc(Cgiro, sSQL)

        'sSQL = "SELECT CVE, DESCRIPCION,CVEDIVISION FROM DIVISION ORDER BY CVE"
        'Carga_ComboSapyc(Cdivision, sSQL)

        'sSQL = "SELECT SIAT,DESCRIPCION  FROM OFICINA"
        'Carga_ComboSapyc(Coficinaasignada, sSQL)

        'sSQL = "SELECT CVE, DESCRIPCION FROM ComoSeEntero ORDER BY CVE"
        'Carga_ComboSapyc(Ccomoentero, sSQL)

        'Ccomoenterootro.Text = ""

        'sSQL = "SELECT CVE, DESCRIPCION FROM MedioDeContacto ORDER BY CVE"
        'Carga_ComboSapyc(Cmediocontacto, sSQL)

        'Cmediocontactootro.Text = ""

        'sSQL = "SELECT CVE, DESCRIPCION FROM TIPODESERVICIO ORDER BY CVE"
        'Carga_ComboSapyc(Ctiposervicio, sSQL)

        'sSQL = "SELECT CVE, DESCRIPCION FROM PERIODODEREVISION ORDER BY CVE"
        'Carga_ComboSapyc(Cayorevision, sSQL)

        'sSQL = "SELECT CVE, DESCRIPCION FROM CICLOOPERATIVO ORDER BY CVE"
        'Carga_ComboSapyc(Cciclooperativo, sSQL)

        ''sSQL = "SELECT CVE, DESCRIPCION  FROM OFICINA ORDER BY CVE"
        ''Carga_ComboSapyc(Coficinaasignada, sSQL)
        ''PasaOficina = True

        'sSQL = "SELECT CVE, DESCRIPCION FROM ESTATUSPROPUESTA ORDER BY CVE"
        'Carga_ComboSapyc(Cestatuspropuesta, sSQL)


        'sSQL = "SELECT CVE, DESCRIPCION FROM ESTATUSPROPUESTA ORDER BY CVE"
        'Carga_ComboSapyc(Cestatuspropuesta, sSQL)

        'sSQL = "SELECT CVE, DESCRIPCION FROM ESTATUSPROPUESTA ORDER BY CVE"
        'Carga_ComboSapyc(Cestatuspropuesta, sSQL)


        'sSQL = "SELECT idPais ,sPais FROM CAT_PAISES ORDER BY sCveTributacion DESC "
        'Carga_ComboSapyc(cPais, sSQL)
        'sSQL = "SELECT idEstado ,sEstado FROM CAT_ESTADOS"
        'Carga_ComboSapyc(Cestado, sSQL)

        'PasaGiro = True
        'PasaOficina = True

        'ListaFuncionarios.Items.Clear()
        'BbajaFun.Enabled = False

        'ListaAccionistas.Items.Clear()
        'BbajaAcc.Enabled = False

    End Sub
    Private Function ValidaDatos() As String
        Dim Resp As String = ""

        If txtHonorarios.Text = "0.00" Then
            Resp = "los honorarios no deben estar en ceros!"
        End If
        If txtHorasEstimadas.Text = "0" Then
            Resp = "las horas estimadas no deben estar en ceros!"
        End If
        'If txtPorWO.Text = "0" Then
        '    Resp = "las horas estimadas no deben estar en ceros!"
        'End If

        If Cnombre.Text = "" Then
            Resp = "No se indico el Nombre del Cliente!"
        End If
        If Ccontactoinicial.Text = "" Then
            Resp = "No se indico el Nombre del Contacto Inicial!"
        End If
        If Cemailcontacto.Text = "" Then
            Resp = "No se indico el Mail de contacto!"
        End If
        If Ctiposervicio.Text = "" Then
            Resp = "No se indico Tipo de servicio!"
        End If
        If Usuario_Tipo = "S" Then
            If txtGerente.Text = "" Then
                Resp = "No se ha seleccionado a un gerente."
            End If
        ElseIf Usuario_Tipo = "G" Then
            If txtSoc.Text = "" Then
                Resp = "No se ha seleccionado a un socio."
            End If
        End If

        If txtSoc.Text = "doble click para listar a los socios" Or txtSoc.Text = "" Then
            Resp = "No se indico Socio!"
        End If
        If txtGerente.Text = "" Or txtGerente.Text = "doble click para listar a los gerentes" Then
            Resp = "No se indico gerente!"
        End If

        If Crfc.Text = "" Then
            Resp = "No se ha especificado el RFC del cliente."
        End If


        If cboIndustria.SelectedValue <= 0 Then
            Resp = "Debes indicar una industria!"
        End If
        If cboSubNivel.SelectedValue <= 0 Then
            Resp = "Debes indicar un subnivel!"
        End If
        If cboSubSector.SelectedValue <= 0 Then
            Resp = "Debes indicar un subsector!"
        End If

        If Cestatuspropuesta.SelectedValue = 4 Or Cestatuspropuesta.SelectedValue = 6 Then
            If txtDescRechazo.Text = "" Then
                Resp = "Debes indicar el motivo del rechazo !"
            End If
        End If

        If Ccomoentero.SelectedValue = 7 Then
            'socio
            If txtSocio.Text = "" Or txtSocio.Text.Contains("doble click para listar a los socios") Then
                Resp = "Debes indicar un socio como referencia, dando doble click en el cuadro de texto 'Refenciado por'"
            End If
        ElseIf Ccomoentero.SelectedValue = 8 Then
            'gerente
            If txtGnt.Text = "" Or txtGnt.Text.Contains("doble click para listar a los gerentes") Then
                Resp = "Debes indicar un gerente como referencia, dando doble click en el cuadro de texto 'Refenciado por'"
            End If
        ElseIf Ccomoentero.SelectedValue = 13 Then
            'empleado
            If txtEmp.Text = "" Or txtEmp.Text.Contains("doble click para listar a los empleados") Then
                Resp = "Debes indicar un empleado como referencia, dando doble click en el cuadro de texto 'Refenciado por'"
            End If
        End If

        '==================== GRUPOS ====================
        If OpPublico.Checked = False And OpPrivado.Checked = False And OpGobireno.Checked = False And OpOtros.Checked = False Then
            Resp = "Especifique el sector del cliente."
        End If

        If rbtSiMex.Checked = False And rbtNoMex.Checked = False Then
            Resp = "Especifique si el cliente cotiza en la bolsa mexicana de valores."
        End If

        If rbtSiMex.Checked Then
            If txtMexicana.Text.Trim = "" Then
                Resp = "Especifique el nombre de la bolsa mexicana."
            End If
        End If

        If rbtSiExt.Checked = False And rbtNoExt.Checked = False Then
            Resp = "Especifique si el cliente cotiza en una bolsa extranjera de valores."
        End If

        If rbtSiExt.Checked Then
            If txtExtranjera.Text.Trim = "" Then
                Resp = "Especifique el nombre de la bolsa extranjera."
            End If
        End If

        If rdEmpresaExtranjeroRepSi.Checked = False And rdEmpresaExtranjeroRepNo.Checked = False Then
            Resp = "Especifique si el cliente tiene una compañia tenedora ubicada en el extranjero."
        End If

        If rdEmpresaExtranjeroRepSi.Checked Then
            If txtEmpresaTenedora.Text.Trim = "" Then
                Resp = "Especifique el nombre de la empresa tenedora."
            End If

            If cmbPaisRes.SelectedIndex = -1 Then
                Resp = "Especifique el país de residencia de la empresa tenedora."
            End If
        End If
        '==================== GRUPOS ====================

        '==================== REFERENCIA GTI ====================
        If OpSi.Checked = False And OpNo.Checked = False Then
            Resp = "Especifique si el cliente es referencia de GTI."
        End If

        If OpSi.Checked Then
            If Csocioref.Text.Trim = "" Then
                Resp = "Especifique el socio de referencia de GTI"
            End If

            If cmbOfiGT.SelectedIndex = -1 Then
                Resp = "Especifique la oficina de referencia de GTI"
            End If

            If cmbPaisGT.SelectedIndex = -1 Then
                Resp = "Especifique el país de referencia de GTI"
            End If
        End If
        '==================== REFERENCIA GTI ====================


        '============================== OTROS DATOS ==============================

        If rdSubsidiariaSi.Checked = False And rdSubsidiariaNo.Checked = False Then
            Resp = "OTROS DATOS: Especifíque si el prospecto es una subsidiaria."
        End If

        If rdSubsidiariaSi.Checked = True And (rdControladoraSi.Checked = False And rdControladoraNO.Checked = False) Then
            Resp = "OTROS DATOS: Especifíque si el prospecto reportará a su compañia controladora."
        End If

        'If cboPais.SelectedIndex = 0 Then
        '    lblMensajeErrorDatosGenerales.Visible = True
        '    lblMensajeErrorDatosGenerales.Text = "Especifíque el país del prospecto."

        '    Exit Sub
        'End If

        If rdEntidadReguladaSi.Checked = False And rdEntidadReguladaNo.Checked = False Then
            Resp = "OTROS DATOS: Especifíque si el prospecto es una entidad regulada."
        End If

        If rdEntidadReguladaSi.Checked = True And cboEntidadReguladora.SelectedIndex = 0 Then
            Resp = "OTROS DATOS: Especifíque la entidad reguladora para el prospecto."
        End If

        If rdEntidadReguladaSi.Checked = True And cboEntidadReguladora.SelectedIndex = 8 And Trim(txtEntidadReguladoraOtro.Text) = "" Then
            Resp = "OTROS DATOS: Especifíque el nombre de la entidad reguladora para el prospecto."
        End If

        If rdEntidadSupervisadaSi.Checked = False And rdEntidadSupervisadaNo.Checked = False Then
            Resp = "OTROS DATOS: Especifíque si el prospecto es una entidad supervisada."
        End If

        If rdEntidadSupervisadaSi.Checked = True And cboEntidadSupervisada.SelectedIndex = 0 Then
            Resp = "OTROS DATOS: Especifíque la normatividad para el prospecto."
        End If

        If rdEntidadSupervisadaSi.Checked = True And cboEntidadSupervisada.SelectedIndex = 6 And Trim(txtEntidadSupervisadaOtro.Text) = "" Then
            Resp = "OTROS DATOS: Especifíque el nombre de la normatividad para el prospecto."
        End If

        If rdEmpresaExtranjeroRepSi.Checked = False And rdEmpresaExtranjeroRepNo.Checked = False Then
            Resp = "OTROS DATOS: Especifíque si el prospecto reporta al extranjero."
        End If

        If rdEmpresaExtranjeroRepSi.Checked = True And cmbPaisRes.SelectedIndex = 0 Then
            Resp = "OTROS DATOS: Especifíque el país de residencia de la empresa tenedora."
        End If

        If rdEmpresaExtranjeroRepSi.Checked = True And Trim(txtEmpresaTenedora.Text) = "" Then
            Resp = "OTROS DATOS: Especifíque el nombre de la empresa tenedora."
        End If

        If cboTipoEntidad.SelectedIndex = 0 Then
            Resp = "OTROS DATOS: Especifíque el tipo de entidad del prospecto."
        End If
        '============================== OTROS DATOS ==============================
        '============================== CLASIFICACION CLIENTE ==============================

        If CveCte <> "" Then
            If cboIngreso.SelectedIndex = 0 Then
                Resp = "CLASIFICACIÓN CLIENTE: Especifíque el ingreso."
            End If
            If cboLiquidez.SelectedIndex = 0 Then
                Resp = "CLASIFICACIÓN CLIENTE: Especifíque la liquidez."
            End If
            If cboRentabilidad.SelectedIndex = 0 Then
                Resp = "CLASIFICACIÓN CLIENTE: Especifíque la rentabilidad."
            End If
            If cboImagen.SelectedIndex = 0 Then
                Resp = "CLASIFICACIÓN CLIENTE: Especifíque la imagen."
            End If
            If cboReputacion.SelectedIndex = 0 Then
                Resp = "CLASIFICACIÓN CLIENTE: Especifíque la reputacion."
            End If
            If cboRiesgo.SelectedIndex = 0 Then
                Resp = "CLASIFICACIÓN CLIENTE: Especifíque el riesgo."
            End If
            If cboEspecializacion.SelectedIndex = 0 Then
                Resp = "CLASIFICACIÓN CLIENTE: Especifíque la especialización."
            End If
        End If
        '============================== CLASIFICACION CLIENTE ==============================


        Return Resp
    End Function
    Private Sub Cdescgpo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cdescgpo.SelectedIndexChanged
        'If Permite Then
        Ccvegpo.Text = Cdescgpo.SelectedValue
        ConsultaGrupos(Ccvegpo.Text)
        ConsultaAccionistasGrupo(Ccvegpo.Text)
        ConsultaFuncionariosGrupo(Ccvegpo.Text)
        'End If
    End Sub
    Private Sub rbDs_CheckedChanged(sender As Object, e As EventArgs) Handles rbDs.CheckedChanged
        If rbDs.Checked Then
            rbPs.Checked = False
        End If
    End Sub
    Private Sub txtHonorarios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHonorarios.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtHonorarios.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub rbPs_CheckedChanged(sender As Object, e As EventArgs) Handles rbPs.CheckedChanged
        If rbPs.Checked Then
            rbDs.Checked = False
        End If
    End Sub
    Private Sub Aplicar_FiltroNombre()

        'Lista.Visible = True
        '' filtrar por el campo Nombrecte
        'Dim ret As Integer = Filtrar_DataGridView("NOMBRE", Cnombre.Text.Trim, BindingSource1, Lista)

        'If ret > 0 Then
        '    ' si no hay registros cambiar el color del txtbox   
        '    'Cnombre.BackColor = Color.Red
        '    'If MsgBox("¿Este cliente se encuentra en las listas de clientes restringidos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta") = MsgBoxResult.Yes Then
        '    '    AltaCte = True
        '    'End If
        'Else
        '    Cnombre.BackColor = Color.White
        '    Lista.Visible = False
        'End If

    End Sub
    Public Sub CargaDatos()
        'Try

        '    sSQL = "SELECT Listado,NOMBRE FROM CLIENTERESTRINGIDO ORDER BY NOMBRE"

        '    ' Inicializar la conexión y abrir   
        '    Using cn As SqlConnection = New SqlConnection(CadenaConexionLocal)
        '        cn.Open()

        '        ' Inicializar DataAdapter indicando el sql para recuperar    
        '        'los registros de la tabla   
        '        '                sSQL = "SELECT CVEEMP, NOMBRE, CVEPUESTO FROM EMPLEADOS WHERE STATUS = 'A' ORDER BY CVEEMP ASC "
        '        Dim da As New SqlDataAdapter(sSQL, cn)
        '        Dim dt As New DataTable ' crear un DataTable   

        '        ' llenarlo   
        '        da.Fill(dt)

        '        ' enlazar el DataTable al BindingSource   
        '        BindingSource1.DataSource = dt
        '        Lista.DataSource = BindingSource1.DataSource

        '        ' Lista.Columns("CVECTE").HeaderText = "No"
        '        Lista.Columns("NOMBRE").HeaderText = "Nombre"
        '        Lista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        '        Lista.Columns(0).Width = 80
        '        Lista.Columns(1).Width = 300

        '    End Using
        '    ' errores   
        'Catch ex As Exception
        '    MsgBox(ex.Message.ToString)
        'End Try

    End Sub
    Private Sub Contacto_Click(sender As Object, e As EventArgs) Handles Contacto.Click

    End Sub
    Private Sub EliminaAccionistas(Nombre As String)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@NOMBRE", Nombre, SqlDbType.VarChar, ParameterDirection.Input)
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
    Public Sub LimpiaGT()
        sSQL = "SELECT CVEGPO, DESCGPO FROM GRUPOS "
        Carga_ComboSapycSiat(Cdescgpo, sSQL)
    End Sub
    Private Sub SolicitaRevision()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 10, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPropuesta", IdProp, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sUsuario", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)

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
                cboEntidadReguladora.ValueMember = "idEntidadReguladora"
                cboEntidadReguladora.DisplayMember = "sEntidad"

                cboEntidadReguladora.DataSource = dtEntidadReg
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarEntidad()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
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
                cboEntidadSupervisada.ValueMember = "idNormatividad"
                cboEntidadSupervisada.DisplayMember = "sNormatividad"

                cboEntidadSupervisada.DataSource = dtNormatividad
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarNormatividad()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtNormatividad = Nothing
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
                dtPaisOtro = dtPaisResidencia.Copy

                cmbPaisRes.ValueMember = "idPais"
                cmbPaisRes.DisplayMember = "sPais"

                cmbPaisRes.DataSource = dtPaisResidencia

                cboPaisOtro.ValueMember = "idPais"
                cboPaisOtro.DisplayMember = "sPais"

                cboPaisOtro.DataSource = dtPaisOtro
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarPaisResidencia()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
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
                cboTipoEntidad.ValueMember = "idTipoEntidad"
                cboTipoEntidad.DisplayMember = "sEntidad"

                cboTipoEntidad.DataSource = dtTipoEntidad
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarTipoEntidad()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtTipoEntidad = Nothing
        End Try
    End Sub
    Private Sub ListarClasificacionClientes()
        Try
            Dim sTabla As String = "tbClasCte"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iTipo", 12, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveCliente", CveCte, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveSoc", sCveSocio, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosInv.funExecuteSPDataTable("paConsultaTrabajoRecurrente", sTabla))

                dtClasificacionCte = .Item(sTabla)
            End With

            If dtClasificacionCte.Rows.Count > 0 Then
                cboIngreso.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iIngreso").ToString)
                txtCalIngresoSocio.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iIngreso")), sFmtInt)
                SumarPuntosImpEco()
                cboLiquidez.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iLiquidez").ToString)
                txtCalLiquidezSocio.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iLiquidez")), sFmtInt)
                SumarPuntosImpEco()
                cboRentabilidad.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iRentabilidad").ToString)
                txtCalRentabilidadSocio.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iRentabilidad")), sFmtInt)
                SumarPuntosImpEco()

                cboImagen.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iImagen").ToString)
                txtCalImagen.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iImagen")), sFmtInt)
                SumarPuntosImpEst()
                cboReputacion.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iReputacion").ToString)
                txtCalReputacion.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iReputacion")), sFmtInt)
                SumarPuntosImpEst()
                cboRiesgo.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iRiesgo").ToString)
                txtCalRiesgo.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iRiesgo")), sFmtInt)
                SumarPuntosImpEst()
                cboEspecializacion.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iEspecializacion").ToString)
                txtCalEspecializacion.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iEspecializacion")), sFmtInt)
                SumarPuntosImpEst()

            Else
                cboIngreso.SelectedIndex = 0
                cboLiquidez.SelectedIndex = 0
                cboRentabilidad.SelectedIndex = 0
                cboImagen.SelectedIndex = 0
                cboReputacion.SelectedIndex = 0
                cboRiesgo.SelectedIndex = 0
                cboEspecializacion.SelectedIndex = 0
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarClasificacionClientes")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtClasificacionCte = Nothing
        End Try
    End Sub
    Private Sub ListarClasificacionClientesPropuesta()
        Try
            Dim sTabla As String = "tbClasCte"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iTipo", 13, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idPropuesta", IdProp, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveSoc", sCveSocio, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paConsultaTrabajoRecurrente", sTabla))

                dtClasificacionCte = .Item(sTabla)
            End With

            If dtClasificacionCte.Rows.Count > 0 Then
                cboIngreso.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iIngreso").ToString)
                txtCalIngresoSocio.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iIngreso")), sFmtInt)
                SumarPuntosImpEco()
                cboLiquidez.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iLiquidez").ToString)
                txtCalLiquidezSocio.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iLiquidez")), sFmtInt)
                SumarPuntosImpEco()
                cboRentabilidad.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iRentabilidad").ToString)
                txtCalRentabilidadSocio.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iRentabilidad")), sFmtInt)
                SumarPuntosImpEco()

                cboImagen.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iImagen").ToString)
                txtCalImagen.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iImagen")), sFmtInt)
                SumarPuntosImpEst()
                cboReputacion.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iReputacion").ToString)
                txtCalReputacion.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iReputacion")), sFmtInt)
                SumarPuntosImpEst()
                cboRiesgo.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iRiesgo").ToString)
                txtCalRiesgo.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iRiesgo")), sFmtInt)
                SumarPuntosImpEst()
                cboEspecializacion.SelectedValue = CInt(dtClasificacionCte.Rows(0).Item("iEspecializacion").ToString)
                txtCalEspecializacion.Text = Format(CInt(dtClasificacionCte.Rows(0).Item("iEspecializacion")), sFmtInt)
                SumarPuntosImpEst()

            Else
                cboIngreso.SelectedIndex = 0
                cboLiquidez.SelectedIndex = 0
                cboRentabilidad.SelectedIndex = 0
                cboImagen.SelectedIndex = 0
                cboReputacion.SelectedIndex = 0
                cboRiesgo.SelectedIndex = 0
                cboEspecializacion.SelectedIndex = 0
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarClasificacionClientes")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtClasificacionCte = Nothing
        End Try
    End Sub
    Private Sub ListarFactores()
        Try
            Dim sTabla As String = "tbFactores"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paClasificacionCliente", sTabla))

                dtFactores = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarFactores()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtFactores = Nothing
        End Try
    End Sub
    Private Sub ListarMatriz()
        Try
            Dim sTabla As String = "tbMatriz"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paClasificacionCliente", sTabla))

                dtMatriz = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarMatriz()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtMatriz = Nothing
        End Try
    End Sub
    Private Sub ListarEjeX()
        Try
            'Lista las ponderaciones del Impacto Económico.

            Dim sTabla As String = "tbEjeX"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paClasificacionCliente", sTabla))

                dtEjeX = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarEjeX()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtEjeX = Nothing
        End Try
    End Sub
    Private Sub ListarEjeY()
        Try
            'Lista las ponderaciones del Impacto Estratégico.

            Dim sTabla As String = "tbEjeY"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paClasificacionCliente", sTabla))

                dtEjeY = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarEjeY()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtEjeY = Nothing
        End Try
    End Sub
    Private Sub ActualizarDatosGralProspecto()
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sRazonSocial", Cnombre.Text.ToUpper, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sNombreComercial", Cnombre.Text.ToUpper, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveGpo", Ccvegpo.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idPais", cboPaisOtro.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveArea", CveArea, SqlDbType.VarChar, ParameterDirection.Input)


                If rdEmpresaPublicaSi.Checked Then
                    .subAddParameter("@bPublica", 1, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@idBolsaValores", cboBolsaValores.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sOtraBolsa", txtBolsaValoresOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdEmpresaPublicaNo.Checked Then
                    .subAddParameter("@bPublica", 0, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@idBolsaValores", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sOtraBolsa", "", SqlDbType.VarChar, ParameterDirection.Input)
                End If

                If rdSubsidiariaSi.Checked Then
                    .subAddParameter("@bSubsidiaria", 1, SqlDbType.Bit, ParameterDirection.Input)
                ElseIf rdSubsidiariaNo.Checked Then
                    .subAddParameter("@bSubsidiaria", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If

                If rdControladoraSi.Checked Then
                    .subAddParameter("@bControlador", 1, SqlDbType.Bit, ParameterDirection.Input)
                ElseIf rdControladoraNO.Checked Then
                    .subAddParameter("@bControlador", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If

                If rdEntidadReguladaSi.Checked Then
                    .subAddParameter("@bReguladora", 1, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@idEntidadReguladora", cboEntidadReguladora.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sOtraEntidad", txtEntidadReguladoraOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdEntidadReguladaNo.Checked Then
                    .subAddParameter("@bReguladora", 0, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@idEntidadReguladora", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sOtraEntidad", "", SqlDbType.VarChar, ParameterDirection.Input)
                End If

                If rdEntidadSupervisadaSi.Checked Then
                    .subAddParameter("@bEntidadSupervisada", 1, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@idNormatividad", cboEntidadSupervisada.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sOtraNormatividad", txtEntidadSupervisadaOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdEntidadSupervisadaNo.Checked Then
                    .subAddParameter("@bEntidadSupervisada", 0, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@idNormatividad", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sOtraNormatividad", "", SqlDbType.VarChar, ParameterDirection.Input)
                End If

                If OpSi.Checked Then
                    .subAddParameter("@bRefGTI", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sNombSocioRefGTI", Csocioref.Text.ToUpper, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@IdPaisRefGTI", CInt(cmbPaisGT.SelectedValue), SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idOficinaRefGTI", cmbOfiGT.Text, SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf OpNo.Checked Then
                    .subAddParameter("@bRefGTI", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sNombSocioRefGTI", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@IdPaisRefGTI", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idOficinaRefGTI", 0, SqlDbType.Int, ParameterDirection.Input)
                End If

                If rdEmpresaExtranjeroRepSi.Checked Then
                    .subAddParameter("@bReportaExtranjero", 1, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@sNombTenedora", txtEmpresaTenedora.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idPaisTenedora", cmbPaisRes.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                ElseIf rdEmpresaExtranjeroRepNo.Checked Then
                    .subAddParameter("@bReportaExtranjero", 0, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@sNombTenedora", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idPaisTenedora", 0, SqlDbType.Int, ParameterDirection.Input)
                End If

                If rdEmpresaExtranjeroDomSi.Checked Then
                    .subAddParameter("@bDomiciliadas", 1, SqlDbType.Bit, ParameterDirection.Input)
                ElseIf rdEmpresaExtranjeroDomNo.Checked Then
                    .subAddParameter("@bDomiciliadas", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If

                .subAddParameter("@idTipoEntidad", cboTipoEntidad.SelectedValue, SqlDbType.Int, ParameterDirection.Input)

                If rdEmpresaExtranjeroSubSi.Checked Then
                    .subAddParameter("@bSubsidiarias", 1, SqlDbType.Bit, ParameterDirection.Input)
                ElseIf rdEmpresaExtranjeroSubNo.Checked Then
                    .subAddParameter("@bSubsidiarias", 0, SqlDbType.Bit, ParameterDirection.Input)
                End If

                .subAddParameter("@sCveInd", Indus, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveSS", SubSec, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveGTI", SubNiv, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paSSGTDatosGenerales")
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizarDatosGralProspecto()")
            MsgBox("Hubo un inconveniente al eliminar el registro, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try

    End Sub
    Private Sub ActualizarContactoInicialProspecto()
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sNombreContacto", Ccontactoinicial.Text.ToUpper, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCargo", Ccargocompania.Text.ToUpper, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCorreo", Cemailcontacto.Text.ToUpper, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sTelefono", Ctelefono.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sExtension", Cextension.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paSSGTContactoInicial")
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizarContactoInicialProspecto()")
            MsgBox("Hubo un inconveniente al eliminar el registro, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
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
                cboBolsaValores.ValueMember = "idBolsaValores"
                cboBolsaValores.DisplayMember = "sBolsaValores"

                cboBolsaValores.DataSource = dtBolsaValores
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarBolsaValores()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtBolsaValores = Nothing
        End Try
    End Sub
    Private Sub ConsultaOtrosDatos()
        Try
            Dim sTabla As String = "tbOtrosDatos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 15, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", IdProp, SqlDbType.Int, ParameterDirection.Input)

                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))


                dtOtrosDatos = .Item(sTabla)
            End With

            If dtOtrosDatos.Rows.Count > 0 Then


                If dtOtrosDatos(0)("bSubsidiaria") = "0" Then
                    rdSubsidiariaNo.Checked = True
                Else
                    rdSubsidiariaSi.Checked = True
                End If

                If dtOtrosDatos(0)("bControladora") = "0" Then
                    rdControladoraNO.Checked = True
                Else
                    rdControladoraSi.Checked = True
                End If

                cboPaisOtro.SelectedValue = dtOtrosDatos(0)("idPais")

                If dtOtrosDatos(0)("bEntidadReguladora") = "0" Then
                    rdEntidadReguladaNo.Checked = True
                Else
                    rdEntidadReguladaSi.Checked = True
                End If

                cboEntidadReguladora.SelectedValue = dtOtrosDatos(0)("idEntidadReguladora")
                txtEntidadReguladoraOtro.Text = dtOtrosDatos(0)("sOtraEntidad")

                If dtOtrosDatos(0)("bEntidadSupervisada") = "0" Then
                    rdEntidadSupervisadaNo.Checked = True
                Else
                    rdEntidadSupervisadaSi.Checked = True
                End If

                cboEntidadSupervisada.SelectedValue = dtOtrosDatos(0)("idNormatividad")
                txtEntidadSupervisadaOtro.Text = dtOtrosDatos(0)("sOtraNormatividad")

                If dtOtrosDatos(0)("bReportaExtranjero") = "0" Then
                    rdEmpresaExtranjeroRepNo.Checked = True
                Else
                    rdEmpresaExtranjeroRepSi.Checked = True
                End If
                If dtOtrosDatos(0)("bDomiciliadasExt") = "0" Then
                    rdEmpresaExtranjeroDomNo.Checked = True
                Else
                    rdEmpresaExtranjeroDomSi.Checked = True
                End If

                If dtOtrosDatos(0)("bSubsidiariasExt") = "0" Then
                    rdEmpresaExtranjeroSubNo.Checked = True
                Else
                    rdEmpresaExtranjeroSubSi.Checked = True
                End If
                txtEmpresaTenedora.Text = dtOtrosDatos(0)("sNombreTenedora")
                cmbPaisRes.SelectedValue = dtOtrosDatos(0)("idPaisTenedora")
                cboTipoEntidad.SelectedValue = dtOtrosDatos(0)("idTipoEntidad")

            End If



        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarBolsaValores()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtOtrosDatos = Nothing
        End Try
    End Sub
    Private Sub EnviarCorreoAviso(Correo As String, NombSocio As String) 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            'sCorreos = "Octavio.A.Cervantes@mx.gt.com, Mario.Rodriguez@mx.gt.com"
            Dim sCorreo As String() = {Correo, "mario.rodriguez@mx.gt.com"}

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">GENERACIÓN DE PROPUESTAS</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado " & "Equipo" & ",</p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">El presente correo es para informarte que se ha generado una solicitud para la la revision del cliente: </p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Cnombre.Text.ToUpper() & "</b></td></tr>" & vbNewLine &
            "<tr><td>RFC:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Crfc.Text.ToUpper() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Servicio:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Ctiposervicio.Text.ToUpper() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Socio:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtSoc.Text.ToUpper() & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para revisar y validar esta solicitud, ingresa al sistema SAPYC." & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Solicitud alta de cliente " & " " & " " & sTipoSolicitud & " ")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub EnviarCorreoAvisoPracticaNacional(Correo As String, NombSocio As String) 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            'sCorreos = "Octavio.A.Cervantes@mx.gt.com, Mario.Rodriguez@mx.gt.com"
            Dim sCorreo As String() = {Correo, "mario.rodriguez@mx.gt.com"}

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">GENERACIÓN DE PROPUESTAS</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado " & NombSocio & ",</p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">El presente correo es para informarte que se ha generado una solicitud para la la revision del cliente: </p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Cnombre.Text.ToUpper() & "</b></td></tr>" & vbNewLine &
            "<tr><td>RFC:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Crfc.Text.ToUpper() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Servicio:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Ctiposervicio.Text.ToUpper() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Socio:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtSoc.Text.ToUpper() & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para revisar y validar esta solicitud, ingresa al sistema SAPYC." & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Solicitud alta de cliente")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub EnviarCorreoAvisoNoNacionales(Correo As String, NombSocio As String) 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            'sCorreos = "Octavio.A.Cervantes@mx.gt.com, Mario.Rodriguez@mx.gt.com"
            Dim sCorreo As String() = {Correo, "mario.rodriguez@mx.gt.com"}

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">GENERACIÓN DE PROPUESTAS</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado " & NombSocio & ",</p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">El presente correo es para informarte que se ha generado una solicitud para la revision de un cliente no nacional: </p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Cnombre.Text.ToUpper() & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para revisar y validar esta solicitud, SIAT/SAPYC/AUTORIZACIÓN DE REGISTRO DE PROPUESTAS NO NACIONALES" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Solicitud de Autorización para Folio de Informe")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub ActualizaNivel(IdNivel As Integer)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iNivRiesgo", IdNivel, SqlDbType.Int, ParameterDirection.Input)

                End With

                If .Contains("paSapyc") Then
                    .Remove("paSapyc")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub ActualizaConflict(Ind As Integer)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@bIndependencia", Ind, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sMotInd", txtMotivoIndepen.Text, SqlDbType.VarChar, ParameterDirection.Input)


                End With

                If .Contains("paSapyc") Then
                    .Remove("paSapyc")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Public Sub ConsultaCorreos()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 20, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@ASOCIADO", CveGerente, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@SOCIO", CveSocio, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))

                dtCorreos = .Item("paEmpresaPropuesta")
                If dtCorreos.Rows.Count > 0 Then
                    For Each dr As DataRow In dtCorreos.Rows
                        If Not IsDBNull(dr("EMAIL")) Then
                            CorreosSoc += dr("EMAIL").ToString() + ";"
                            NombSoc += dr("NOMBRE").ToString() + ";"
                        End If
                    Next
                End If
            End With

            CorreosSoc = CorreosSoc.TrimStart(";") + "independencia@mx.gt.com"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub EnvioCorreoSocios()
        Dim sMensaje As String

        If rbSiIndepen.Checked Then
            Msnj = txtMensaje.Text.ToUpper + "    " + "SI" + " ;"
        ElseIf rbNOIndepen.Checked Then
            Msnj = "NO"
        End If

        Dim sCorreo As String() = CorreosSoc.Split(";")

        Try

            'sMensaje = "Estimado Equipo:  " & NombSoc.TrimEnd(";") & " " & vbNewLine & vbNewLine
            'sMensaje &= "Se ha realizado la verificación de conflictos de interes y/o amenazas de independencia en el ciclo 23-24 "
            'sMensaje &= "(interna y/o externa) al prospecto  " & NomEmpresa & "  " & vbNewLine & vbNewLine
            'sMensaje &= "De las respuestas recibidas  " & Msnj.ToString() & " se identificó situación que afecta nuestra independencia. " & vbNewLine & vbNewLine
            'sMensaje &= "Para cualquier aclaración sobre el tema contactar a cecilia.coronel@mx.gt.com y heidi.martinez@mx.gt.com " & vbNewLine & vbNewLine
            'envioCorreos(sCorreo, sMensaje, "Propuestas Clientes - Sapyc")
            ConsultaCicloOperativo()
            EnviarCorreoAviso()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub EnviarCorreoAviso() 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            'sCorreos = "Octavio.A.Cervantes@mx.gt.com, Mario.Rodriguez@mx.gt.com"
            Dim sCorreo As String() = CorreosSoc.Split(";")

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">REVISIÓN DE PROPUESTAS</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado Equipo: " & NombSoc.TrimEnd(";") & ", </p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Se ha realizado la investigación de antecedentes y de la verificación de conflictos de interés y/o amenazas de independencia en el " & sCicloOperativo & " de la entidad </p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & NomEmpresa.ToString() & "</b></td></tr>" & vbNewLine &
            "<tr><td>De las respuestas recibidas :</td> <td></td> <td></td> <td style=""text-align: left;""><b> con la cual " & Msnj.ToString.ToUpper() & "  " & "se identificó situación alguna que afecte nuestra independencia,Se deberá continuar con los demás procesos establecidos por la Firma para concluir la aceptación/reaceptación del prospecto/cliente. ""</b></td></tr>" & vbNewLine &
            "<tr><td>RFC:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Crfc.Text.ToUpper() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Servicio:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Ctiposervicio.Text.ToUpper() & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para cualquier aclaración sobre el tema contactar a cecilia.coronel@mx.gt.com y heidi.martinez@mx.gt.com" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Propuestas Clientes - Sapyc" & " " & " " & sTipoSolicitud & " ")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub ConsultaPropuesta()

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)

                End With

                If .Contains("paSapyc") Then
                    .Remove("paSapyc")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
                DtDatos = .Item("paSapyc")

                If DtDatos.Rows.Count > 0 Then

                    CveOfi = DtDatos(0)("CVEOFI").ToString()
                    CveArea = DtDatos(0)("CVEAREA").ToString()

                    If CveArea <> "AUD" Then
                        Cestatuspropuesta.Enabled = True
                    End If

                    sCveSocio = DtDatos(0)("CVESOC").ToString()
                    sCveGerente = DtDatos(0)("CVEASOC").ToString()

                    CveSocio = DtDatos(0)("CVESOC").ToString()
                    CveGerente = DtDatos(0)("CVEASOC").ToString()

                    NomEmpresa = DtDatos(0)("NOMEMPRESA").ToString()

                    If InStr(1, NomEmpresa, "GRANT THORNTON") > 0 Or InStr(1, NomEmpresa, "UNIVERSIDAD NACIONAL AUTONOMA DE MEXICO") > 0 Then
                        txtCiaRef.Enabled = True
                        Cnombre.Enabled = True
                        Cuadro.TabPages.Remove(Funcionarios)
                        Cuadro.TabPages.Remove(Accionistas)
                    End If


                    Cnombre.Text = DtDatos(0)("NOMEMPRESA").ToString()
                    txtOfiAsignada.Text = DtDatos(0)("OFICINA").ToString()

                    Indus = DtDatos(0)("INDUSTRIA")
                    SubSec = DtDatos(0)("SUBSECTOR").ToString()
                    SubNiv = DtDatos(0)("SUBNIVEL").ToString()


                    listarSubSectores(SubSec)
                    listarSubNiveles(SubNiv)

                    If Indus.Length = 1 Then
                        Indus = "0" + Indus
                    End If


                    cboIndustria.SelectedValue = Indus
                    cboSubSector.SelectedItem = SubSec
                    cboSubNivel.SelectedItem = SubNiv

                    Ccontactoinicial.Text = DtDatos(0)("NOMCONTINICIAL").ToString()
                    Ccargocompania.Text = DtDatos(0)("CARGOCIA").ToString()
                    Cemailcontacto.Text = DtDatos(0)("EMAILCONTACTO").ToString()
                    Ctelefono.Text = DtDatos(0)("TELEFONO").ToString()
                    Cextension.Text = DtDatos(0)("EXTTEL").ToString()
                    Crfc.Text = DtDatos(0)("RFC").ToString()
                    txtDivision.Text = DtDatos(0)("DIVISION").ToString()

                    Ccomoentero.Text = DtDatos(0)("IDCOMO").ToString()
                    CveEmpRef = DtDatos(0)("CVEEMPREF").ToString()
                    NombEmpRef = DtDatos(0)("NOMBEMPREF").ToString()
                    txtServOtros.Text = DtDatos(0)("SERVICIOTROS").ToString()


                    'socio
                    If Ccomoentero.SelectedValue = 7 Then
                        txtSocio.Text = DtDatos(0)("NOMBEMPREF").ToString()
                        txtSocio.Visible = True
                        txtGnt.Visible = False
                        txtEmp.Visible = False
                        'gerente
                    ElseIf Ccomoentero.SelectedValue = 8 Then
                        txtGnt.Text = DtDatos(0)("NOMBEMPREF").ToString()
                        txtGnt.Visible = True
                        txtSocio.Visible = False
                        txtEmp.Visible = False
                        'empleado

                    ElseIf Ccomoentero.SelectedValue = 13 Then
                        txtEmp.Text = DtDatos(0)("NOMBEMPREF").ToString()
                        txtEmp.Visible = True
                        txtSocio.Visible = False
                        txtGnt.Visible = False
                    Else
                        txtEmp.Enabled = False
                        txtSocio.Enabled = False
                        txtGnt.Enabled = False

                    End If

                    Ccomoentero.Text = DtDatos(0)("COMOENTERO").ToString()
                    cboMedioContacto.Text = DtDatos(0)("MEDIOCON").ToString()
                    txtComoOtro.Text = DtDatos(0)("OTROCOMOSEENTERO").ToString()
                    txtMedioOtro.Text = DtDatos(0)("OTROMEDIODECONTACTO").ToString()

                    If DtDatos(0)("CVEAREA").ToString() = "SS" Or DtDatos(0)("CVEAREA").ToString() = "CO" Or DtDatos(0)("CVEAREA").ToString() = "ATI" Then
                        Dim CveDiv As String = "AUD"

                        sSQL = " SELECT CVE, DESCRIPCION FROM TIPODESERVICIO "
                        sSQL &= " WHERE CVEDIVISION = (SELECT CVE FROM DIVISION WHERE CVEDIVISION = '" & CveDiv & "' )"
                        Carga_ComboSapyc(Ctiposervicio, sSQL)
                    Else

                        sSQL = " SELECT CVE, DESCRIPCION FROM TIPODESERVICIO "
                        sSQL &= " WHERE CVEDIVISION = (SELECT CVE FROM DIVISION WHERE CVEDIVISION = '" & DtDatos(0)("CVEAREA").ToString() & "' )"
                        Carga_ComboSapyc(Ctiposervicio, sSQL)
                    End If

                    Ctiposervicio.Text = DtDatos(0)("SERVICIO").ToString()
                    txtServiciotexto.Text = DtDatos(0)("SERVICIO").ToString()
                    Cayorevision.Text = DtDatos(0)("ANIOREV").ToString()
                    Cciclooperativo.Text = DtDatos(0)("CICLO").ToString()

                    Cestatuspropuesta.Text = DtDatos(0)("ESTATUS").ToString()

                    If DtDatos(0)("SOCIO").ToString() = "" Then
                        txtSoc.Text = "doble click para listar a los socios"
                    Else
                        txtSoc.Text = DtDatos(0)("SOCIO").ToString()
                    End If

                    txtCiaRef.Text = DtDatos(0)("CIAREFERIDA").ToString()
                    cPais.Text = DtDatos(0)("PAIS").ToString()
                    Ccalle.Text = DtDatos(0)("CALLE").ToString()
                    Cnumint.Text = DtDatos(0)("NOINT").ToString()
                    Cnumext.Text = DtDatos(0)("NOEXT").ToString()
                    Ccp.Text = DtDatos(0)("CP").ToString()
                    txtPagWeb.Text = DtDatos(0)("PAGINAWEB").ToString()
                    ComboNivel.SelectedValue = DtDatos(0)("NIVELRIESGO")


                    txtColonia.Visible = True
                    txtEstado.Visible = True
                    txtMunicipio.Visible = True

                    cColonia.Visible = False
                    Cestado.Visible = False
                    cMunicipio.Visible = False

                    txtColonia.Text = DtDatos(0)("COLONIA").ToString()
                    txtEstado.Text = DtDatos(0)("ESTADO").ToString()
                    txtMunicipio.Text = DtDatos(0)("MUNICIPIO").ToString()


                    txtHonorarios.Text = IIf(IsDBNull(DtDatos(0)("HONORARIOS").ToString()), "", DtDatos(0)("HONORARIOS").ToString())
                    txtDescRechazo.Text = IIf(IsDBNull(DtDatos(0)("DESCRECHAZO").ToString()), "", DtDatos(0)("DESCRECHAZO").ToString())
                    Dim TpoMon As Char = IIf(IsDBNull(DtDatos(0)("TPOMONEDA").ToString()), "", DtDatos(0)("TPOMONEDA").ToString())

                    If TpoMon = "P" Then
                        rbPs.Checked = True
                    ElseIf TpoMon = "D" Then
                        rbDs.Checked = True
                    End If
                    CRechazo.SelectedValue = DtDatos(0)("TPORECHAZO")
                    sSocRef = DtDatos(0)("SOCIOREF").ToString
                    If sSocRef <> "" Then
                        ConsultaSocioRef(sSocRef)
                    End If
                    If DtDatos(0)("NIVELRIESGO") > 0 Then
                        gpBgc.Enabled = False
                    End If

                    RevInde = DtDatos(0)("CONFLICTODEINDEPENDENCIA")
                    RevConf = DtDatos(0)("SOLICITUDDECONFLICTCHECK")


                    Dim OK As Integer = DtDatos(0)("CONFLICTODEINDEPENDENCIA")
                    OK = DtDatos(0)("CONFLICTODEINDEPENDENCIA")

                    If OK = 2 Then
                        rbSi.Checked = True
                        txtMotivoIndepen.Text = DtDatos(0)("MOTIVODELCONFLICTO").ToString()
                    ElseIf OK = 1 Then
                        rbNo.Checked = True
                    End If


                    If IsDBNull(DtDatos(0)("MOTIVODELCONFLICTO")) Then
                        GBCC.Enabled = True
                    Else
                        GBCC.Enabled = False
                    End If

                    If DtDatos(0)("SOLICITUDDECONFLICTCHECK") Then
                        gpBgc.Enabled = False
                    Else
                        gpBgc.Enabled = True
                    End If


                    If DtDatos(0)("SECTOR") = "Público" Then
                        OpPublico.Checked = True
                    ElseIf DtDatos(0)("SECTOR") = "Privado" Then
                        OpPrivado.Checked = True
                    ElseIf DtDatos(0)("SECTOR") = "Gobierno" Then
                        OpGobireno.Checked = True
                    ElseIf DtDatos(0)("SECTOR") = "Otros" Then
                        OpOtros.Checked = True
                    End If

                    If DtDatos(0)("REFERIDO") = 0 Then
                        OpNo.Checked = True
                    Else
                        OpSi.Checked = True

                    End If

                    If DtDatos(0)("REFERIDO") = "1" Then
                        OpSi.Checked = True
                    Else
                        OpNo.Checked = True
                    End If

                    Csocioref.Text = DtDatos(0)("SOCREFGTI")
                    cmbPaisGT.SelectedValue = DtDatos(0)("PAISREF")
                    cmbOfiGT.Text = DtDatos(0)("OFIREFE")

                    If DtDatos(0)("CVEGPO") = "" Then
                        Ccvegpo.Text = "0099"
                        Cdescgpo.SelectedValue = "0099"
                        sCveGpo = "0099"
                        sGpoDesc = Cdescgpo.SelectedText
                    Else
                        Ccvegpo.Text = DtDatos(0)("CVEGPO")
                        Cdescgpo.Text = DtDatos(0)("DESCGPO")
                        sCveGpo = DtDatos(0)("CVEGPO")
                        sGpoDesc = DtDatos(0)("DESCGPO")
                    End If


                    CveCte = DtDatos(0)("CVECTE").ToString()

                    txtEmpresaTenedora.Text = DtDatos(0)("EMPTENEDORA")

                    If DtDatos(0)("PAISTENEDORA") = "" Then
                        cmbPaisRes.SelectedValue = -1
                    Else
                        cmbPaisRes.Text = DtDatos(0)("PAISTENEDORA")
                    End If

                    Dim Asig As Boolean
                    If IsDBNull(DtDatos(0)("ASIGNADA")) Then
                        Asig = False
                    Else
                        Asig = DtDatos(0)("ASIGNADA")
                    End If

                    If DtDatos(0)("BMEX") Then
                        rbtSiMex.Checked = True
                    Else
                        rbtNoMex.Checked = True
                    End If
                    If DtDatos(0)("BEXTR") Then
                        rbtSiExt.Checked = True
                    Else
                        rbtNoExt.Checked = True
                    End If

                    txtMexicana.Text = DtDatos(0)("BOLSAMEXICANA")
                    txtExtranjera.Text = DtDatos(0)("BOLSAEXTRANJERA")

                    txtHorasEstimadas.Text = DtDatos(0)("HRSESTIAMADAS")
                    txtPorWO.Text = DtDatos(0)("WOFF")

                End If

                ConsultaCotizacion()
                If dtCartas.Rows.Count > 0 Then
                    Dim Nomb As String = dtCartas(0)("SNOMBARCHIVO")
                    txtCarta.Text = Nomb
                    btnCarga.Enabled = False
                End If


            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub ActualizaCalificacionConflick(iCalif As Integer)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 32, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iNivRiesgo", iCalif, SqlDbType.Int, ParameterDirection.Input)


                End With

                If .Contains("paSapyc") Then
                    .Remove("paSapyc")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub ActualizaCalificacionIndependencia(iCalif As Integer)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 33, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@bIndependencia", iCalif, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sMotInd", txtMotivoIndepen.Text, SqlDbType.VarChar, ParameterDirection.Input)


                End With

                If .Contains("paSapyc") Then
                    .Remove("paSapyc")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

#End Region
    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click

        If IdProp <> 0 Then
            ConsultaCotizacion()
            If dtCartas.Rows.Count > 0 Then

                Dim Nomb As String = dtCartas(0)("SNOMBARCHIVO")
                Dim Ext As String = dtCartas(0)("SEXTENSION")
                Dim Archivo() As Byte = dtCartas(0)("SARCHIVO")

                convierte_bytes_a_archivo(Archivo, Nomb)

                txtCarta.Text = Nomb

            End If

        Else
            MsgBox("No hay datos que mostrar para esa solicitud", MsgBoxStyle.Exclamation, "solicitud de compra")
        End If

    End Sub
    'Private Sub Cnombre_Click(sender As Object, e As EventArgs) Handles Cnombre.Click
    '    Clipboard.Clear()
    'End Sub
    'Private Sub Cnombre_Enter(sender As Object, e As EventArgs) Handles Cnombre.Enter
    '    Clipboard.Clear()
    'End Sub
    Private Sub rdSiCompañia_CheckedChanged(sender As Object, e As EventArgs)
        If rdEmpresaExtranjeroRepSi.Checked Then
            rdEmpresaExtranjeroRepNo.Checked = False
        End If
    End Sub
    Private Sub rdNoCompañia_CheckedChanged(sender As Object, e As EventArgs)
        If rdEmpresaExtranjeroRepNo.Checked Then
            rdEmpresaExtranjeroRepSi.Checked = False
        End If
    End Sub
    Private Sub btnCarga_Click(sender As Object, e As EventArgs) Handles btnCarga.Click
        Try

            If IdProp <> 0 Then

                Dim Opd As New OpenFileDialog
                Opd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ToString
                Opd.Filter = "Archivos PDF (*.pdf)|*.pdf"
                Opd.Multiselect = True
                If (Opd.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                    Try
                        Dim Nomb As String = Opd.SafeFileName
                        Dim NombArch As String = Opd.FileName
                        Dim Ext As String = ".pdf"
                        Dim Archivo() As Byte = convierte_archivo_a_bytes(NombArch)

                        GuardaCotizacion(Nomb, Ext, Archivo)
                        txtCarta.Text = Opd.SafeFileName

                    Catch ex As Exception
                        MsgBox("No se adjunto el PDF", MsgBoxStyle.Exclamation, "solicitud de cheque")
                    End Try

                End If
            Else
                MsgBox("Debes Seleccionar una solicitud", MsgBoxStyle.Exclamation, "solicitud de cheque")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function convierte_archivo_a_bytes(nombreArchivo As String) As Byte()
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
    Public Sub convierte_bytes_a_archivo(aByte() As Byte, fileName As String)

        ' El procedimiento creará un archivo con la secuencia de bytes
        ' especificada en el argumento.

        If (aByte Is Nothing) Then _
            Throw New ArgumentNullException("aByte", "No se ha especificado ningún array de Bytes.")

        If (String.IsNullOrEmpty(fileName)) Then _
            Throw New ArgumentNullException("fileName", "No se ha especificado el archivo de destino.")

        Try
            If (File.Exists(fileName)) Then
                ' Elimino el archivo
                File.Delete(fileName)
            End If
            ' Número de bytes que se van a escribir
            Dim data As Integer = aByte.Length
            ' Obtengo el nombre de un archivo temporal, donde
            ' primeramente se guardará el documento.            
            Dim tempFileName As String = IO.Path.GetTempFileName()
            ' Abrimos o creamos el archivo.
            Using fs As New FileStream(tempFileName, FileMode.OpenOrCreate)
                ' Crea el escritor para los datos.
                Dim bw As New BinaryWriter(fs)
                ' Escribimos en el archivo los datos realmente leídos.
                bw.Write(aByte, 0, data)
                ' Borra todos los búferes del sistema de escritura actual y hace
                ' que todos los datos almacenados en el búfer se escriban en el
                ' dispositivo subyacente. 
                bw.Flush()
                bw = Nothing
            End Using
            ' Muevo el archivo a la ruta indicada.
            tempFileName = tempFileName.Trim
            File.Move(tempFileName, fileName)
            '            MsgBox("Archivo " & fileName & " guardado con éxito", MsgBoxStyle.Information, "Guardado")
            Process.Start(fileName)
        Catch ex As Exception
            ' Devolvemos la excepción al procedimiento llamador.            
            Throw
        End Try
    End Sub
    Public Sub GuardaCotizacion(Nomb As String, Ext As String, Archivo As Byte())
        Try

            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 11, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPropuesta", IdProp, SqlDbType.Int, ParameterDirection.Input)

                    .subAddParameter("@NOMBARCHIVO", Nomb, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@EXTENSION", Ext, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@ARCHIVO", Archivo, SqlDbType.VarBinary, ParameterDirection.Input)
                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))

                DtDatos = .Item("paEmpresaPropuesta")

            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Public Sub ConsultaCotizacion()
        If IdProp <> 0 Then
            Try

                With ds.Tables
                    With clsLocal
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 12, SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@iPropuesta", IdProp, SqlDbType.Int, ParameterDirection.Input)
                    End With

                    If .Contains("paEmpresaPropuesta") Then
                        .Remove("paEmpresaPropuesta")
                    End If

                    .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))

                    dtCartas = .Item("paEmpresaPropuesta")

                End With


            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try

        Else
            MsgBox("No hay datos que mostrar", MsgBoxStyle.Exclamation, "solicitud de compra")
        End If

    End Sub
    Public Sub ConsultaEnviaCorreosInd()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@TPOUSR", 2, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))

                dtCorreos = .Item("paEmpresaPropuesta")
                If dtCorreos.Rows.Count > 0 Then
                    For Each dr As DataRow In dtCorreos.Rows
                        If Not IsDBNull(dr("CORREO")) Then
                            ' EnvioCorreoInd(dr("CORREO").ToString(), dr("NOMBREUSR").ToString())
                            EnviarCorreoAviso(dr("CORREO").ToString(), dr("NOMBREUSR").ToString())
                        End If
                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub ConsultaEnviaCorreosGT()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@TPOUSR", 2, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))

                dtCorreos = .Item("paEmpresaPropuesta")
                If dtCorreos.Rows.Count > 0 Then
                    For Each dr As DataRow In dtCorreos.Rows
                        If Not IsDBNull(dr("CORREO")) Then
                            'EnvioCorreoGT("independencia@mx.gt.com", "Independencia")
                            EnviarCorreoAvisoNoNacionales("independencia@mx.gt.com", "Independencia")
                        End If
                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub ConsultaEnviaCorreosIndAud()
        Try

            ' EnvioCorreoIndPracticas("Practica.profesional@mx.gt.com", "Albino, Juan Manuel")
            EnviarCorreoAvisoPracticaNacional("Practica.profesional@mx.gt.com", "Albino, Juan Manuel")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function ObtenerClasificacion(row As String, col As String) As String
        Dim sValor As String

        If dtMatriz.Rows.Count > 0 Then
            sValor = dtMatriz.Rows(row - 1).Item(col).ToString
        Else
            sValor = "Sin clasificación"
        End If

        Return sValor
    End Function
    Public Sub ConsultaEstatusHistorico()

        Try

            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 19, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPropuesta", IdProp, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))

                dtHis = .Item("paEmpresaPropuesta")

                If dtHis.Rows.Count > 0 Then
                    stPropH = dtHis(0)("sValorUno")
                End If

            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try



    End Sub
    Private Sub InsertaBitacora(idProp As Integer)
        Try
            With ds.Tables
                With clsLocal

                    .subClearParameters()
                    .subAddParameter("@iOpcion", 17, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPropuesta", idProp, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sTipoReg", "S", SqlDbType.Char, ParameterDirection.Input)
                    .subAddParameter("@sValorUno", CInt(Cestatuspropuesta.SelectedValue), SqlDbType.Int, ParameterDirection.Input)

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
    Public Sub ConsultaSocio(Cvesocio As String)

        Try

            With ds.Tables
                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iTipo", 7, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSoc", Cvesocio, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paConsultaTrabajoRecurrente") Then
                    .Remove("paConsultaTrabajoRecurrente")
                End If

                .Add(clsDatos.funExecuteSPDataTable("paConsultaTrabajoRecurrente"))

                dtSocios = .Item("paConsultaTrabajoRecurrente")
                If dtSocios.Rows.Count > 0 Then
                    txtSoc.Text = dtSocios(0)("NOMBRE")
                    sMailSoc = dtSocios(0)("EMAIL")
                End If


            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Public Sub ConsultaSocioRef(Cvesocio As String)

        Try

            With ds.Tables
                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iTipo", 7, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSoc", Cvesocio, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paConsultaTrabajoRecurrente") Then
                    .Remove("paConsultaTrabajoRecurrente")
                End If

                .Add(clsDatos.funExecuteSPDataTable("paConsultaTrabajoRecurrente"))

                dtSocios = .Item("paConsultaTrabajoRecurrente")
                If dtSocios.Rows.Count > 0 Then
                    txtAsignado.Text = dtSocios(0)("NOMBRE")
                End If


            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Public Sub ConultaGerente(CveGerente As String)

        Try

            With ds.Tables
                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iTipo", 7, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSoc", CveGerente, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paConsultaTrabajoRecurrente") Then
                    .Remove("paConsultaTrabajoRecurrente")
                End If

                .Add(clsDatos.funExecuteSPDataTable("paConsultaTrabajoRecurrente"))

                dtGerentes = .Item("paConsultaTrabajoRecurrente")
                If dtGerentes.Rows.Count > 0 Then
                    txtGerente.Text = dtGerentes(0)("NOMBRE")
                    sMailGent = dtGerentes(0)("EMAIL")
                End If


            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub EliminaFuncionariosCliente(Nombre As String)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 21, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@NOMBRE", Nombre, SqlDbType.VarChar, ParameterDirection.Input)

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
    Private Sub EliminaAccionistasCliente(Nombre As String)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 22, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@NOMBRE", Nombre, SqlDbType.VarChar, ParameterDirection.Input)

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
    Private Sub ConsultaCveCliente()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 26, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@NOMBEMPRESA", NomEmpresa, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paEmpresaPropuesta") Then
                .Remove("paEmpresaPropuesta")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            dtCliente = .Item("paEmpresaPropuesta")

            If dtCliente.Rows.Count > 0 Then

                CveCte = dtCliente(0)("CVECTE").ToString()

            End If

        End With
    End Sub
    Private Sub ConsultaFuncionariosClientes()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 27, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@CVECTE", CveCte, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paEmpresaPropuesta") Then
                .Remove("paEmpresaPropuesta")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            dtFuncionarios = .Item("paEmpresaPropuesta")

            If dtFuncionarios.Rows.Count > 0 Then
                bsFun.DataSource = dtFuncionarios
            End If


        End With
    End Sub
    Private Sub ConsultaAccionistasClientes()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 28, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@CVECTE", CveCte, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paEmpresaPropuesta") Then
                .Remove("paEmpresaPropuesta")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            dtAccionistas = .Item("paEmpresaPropuesta")

            If dtAccionistas.Rows.Count > 0 Then

                If dtAccionistas.Rows.Count > 0 Then
                    bsAcc.DataSource = dtAccionistas
                End If

            End If

        End With
    End Sub
    Private Sub listarIndustrias()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 15, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paSapyc") Then
                    .Remove("paSapyc")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paSapyc"))

                dtIndustrias = .Item("paSapyc")
                If dtIndustrias.Rows.Count > 0 Then
                    cboIndustria.DataSource = dtIndustrias
                    cboIndustria.ValueMember = "CVEINDUSTRIA"
                    cboIndustria.DisplayMember = "INDUSTRIA"
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub listarSubSectores(Industria As String)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@INDUSTRIA", Industria, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paSapyc") Then
                    .Remove("paSapyc")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paSapyc"))

                dtSubSectores = .Item("paSapyc")
                If dtSubSectores.Rows.Count > 0 Then
                    cboSubSector.DataSource = dtSubSectores
                    cboSubSector.ValueMember = "CVESUBSECTOR"
                    cboSubSector.DisplayMember = "SUBSECTOR"
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub listarSubNiveles(SubSec As String)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 17, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@SUBSECTOR", SubSec, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paSapyc") Then
                    .Remove("paSapyc")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paSapyc"))

                dtSubNiveles = .Item("paSapyc")
                If dtSubNiveles.Rows.Count > 0 Then
                    cboSubNivel.DataSource = dtSubNiveles
                    cboSubNivel.ValueMember = "CVEGTI"
                    cboSubNivel.DisplayMember = "SUBNIVEL"
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub listarSubSectores1(Industria As String)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 18, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@INDUSTRIA", Industria, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paSapyc") Then
                    .Remove("paSapyc")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paSapyc"))

                dtSubSectores = .Item("paSapyc")
                If dtSubSectores.Rows.Count > 0 Then
                    cboSubSector.DataSource = dtSubSectores
                    cboSubSector.ValueMember = "CVESUBSECTOR"
                    cboSubSector.DisplayMember = "SUBSECTOR"
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub listarSubNiveles1(SubSec As String)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 19, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@SUBSECTOR", SubSec, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paSapyc") Then
                    .Remove("paSapyc")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paSapyc"))

                dtSubNiveles = .Item("paSapyc")
                If dtSubNiveles.Rows.Count > 0 Then
                    cboSubNivel.DataSource = dtSubNiveles
                    cboSubNivel.ValueMember = "CVEGTI"
                    cboSubNivel.DisplayMember = "SUBNIVEL"
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub cboIndustria_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboIndustria.SelectionChangeCommitted
        If cboIndustria.SelectedIndex <> -1 Then
            listarSubSectores1(Me.cboIndustria.SelectedValue)
        End If

    End Sub
    Private Sub cboSubSector_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboSubSector.SelectionChangeCommitted
        If cboSubSector.SelectedIndex <> -1 Then
            listarSubNiveles1(Me.cboSubSector.SelectedValue)
        End If
    End Sub
    Private Sub EliminaFuncionarios(Nombre As String)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@NOMBRE", Nombre, SqlDbType.VarChar, ParameterDirection.Input)

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
    Private Sub ConsultaFuncionariosGrupo(CveGpo As String)
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 35, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@CVEGPO", CveGpo, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paEmpresaPropuesta") Then
                .Remove("paEmpresaPropuesta")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            dtFuncionarios = .Item("paEmpresaPropuesta")

            If dtFuncionarios.Rows.Count > 0 Then
                bsFun.DataSource = dtFuncionarios
            Else
                bsFun.DataSource = New DataTable
            End If


        End With
    End Sub
    Private Sub ConsultaAccionistasGrupo(CveGpo As String)
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 39, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@CVEGPO", CveGpo, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paEmpresaPropuesta") Then
                .Remove("paEmpresaPropuesta")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            dtAccionistas = .Item("paEmpresaPropuesta")

            If dtAccionistas.Rows.Count > 0 Then

                If dtAccionistas.Rows.Count > 0 Then
                    bsAcc.DataSource = dtAccionistas
                End If

            End If

        End With
    End Sub
    Private Sub ConsultaGrupos(CveCte As String)
        Dim sTabla As String = "tbGrupos"

        LimpiarTabla(dtGrupos)
        dtGpos = New DataTable

        With ds.Tables
            LimpiarConsultaTabla(ds.Tables, sTabla)

            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 13, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveCte", CveCte, SqlDbType.VarChar, ParameterDirection.Input)
            End With

            .Add(clsLocal.funExecuteSPDataTable("paSapyc", sTabla))
            dtGpos = .Item(sTabla)

            If dtGpos.Rows.Count > 0 Then
                For Each row In dtGpos.Rows
                    drGrupos = dtGrupos.NewRow
                    drGrupos("CVECTE") = row.item("CVECTE").ToString
                    drGrupos("NOMBRECTE") = row.item("CLIENTE").ToString
                    dtGrupos.Rows.InsertAt(drGrupos, dtGrupos.Rows.Count)
                Next

                bsGpo.DataSource = dtGrupos

                dgGrupos.Columns("CVECTE").HeaderText = "CVE."
                dgGrupos.Columns("CVECTE").Width = 85

                dgGrupos.Columns("NOMBRECTE").HeaderText = "CLIENTE"
                dgGrupos.Columns("NOMBRECTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        End With
    End Sub
    Private Sub ConsultaPaisGT(sPais As Integer)

        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 40, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sPais", sPais, SqlDbType.Int, ParameterDirection.Input)

            End With

            If .Contains("paEmpresaPropuesta") Then
                .Remove("paEmpresaPropuesta")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            dtPaisGt = .Item("paEmpresaPropuesta")

        End With

    End Sub
    Private Sub ConsultaAutorización(idProp As Integer)

        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 42, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPropuesta", idProp, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paEmpresaPropuesta") Then
                .Remove("paEmpresaPropuesta")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            dtAutorizaGt = .Item("paEmpresaPropuesta")

        End With

    End Sub
    Private Sub InsertaAutorizacionGT(idProp As Integer, sCveSocio As String)
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 43, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPropuesta", idProp, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@SOCIO", sCveSocio, SqlDbType.VarChar, ParameterDirection.Input)

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
    Private Sub ConsultaSocioEncargado(sCveOfi As String, sCveArea As String)

        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 44, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@CVEOFI", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@CVEAREA", sCveArea, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paEmpresaPropuesta") Then
                .Remove("paEmpresaPropuesta")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            dtSocEncargado = .Item("paEmpresaPropuesta")

        End With

    End Sub
    Private Sub CrearTablas()
        dtGrupos = New DataTable()

        dtGrupos.Columns.Add("CVECTE", GetType(System.String))
        dtGrupos.Columns.Add("NOMBRECTE", GetType(System.String))
    End Sub
    Private Sub ConsultaCicloOperativo()
        Try
            Dim sTabla As String = "tbCiclo"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosConINV
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)

                End With

                .Add(clsDatosConINV.funExecuteSPDataTable("paModulosSapyc", sTabla))


                dtCiclo = .Item(sTabla)
            End With

            If dtCiclo.Rows.Count > 0 Then
                sCicloOperativo = dtCiclo(0)("sPeriodo").ToString()
            End If



        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarBolsaValores()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtOtrosDatos = Nothing
        End Try
    End Sub

    ''' ACTUALIZA DATOS DE PROSPECTOS SAPYC
    Private Sub ConsultaClaveProspecto(IdProp As Integer)

        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", IdProp, SqlDbType.Int, ParameterDirection.Input)

            End With

            If .Contains("paPropuestasDatosProspectos") Then
                .Remove("paPropuestasDatosProspectos")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paPropuestasDatosProspectos"))
            dtProspecto = .Item("paPropuestasDatosProspectos")

            If dtProspecto.Rows.Count > 0 Then
                sCveProspecto = dtProspecto(0)("sCveProspecto")
            End If

        End With

    End Sub
    Private Sub ActualizaDireccionProspecto(CveProspecto As String)
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", CveProspecto, SqlDbType.VarChar, ParameterDirection.Input)

                    .subAddParameter("@idPais", cPais.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCalle", Ccalle.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sNumExt", Cnumext.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sNumInt", Cnumint.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCp", Ccp.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    '.subAddParameter("@idColonia", txtColonia.Text, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sColonia", Colonia, SqlDbType.VarChar, ParameterDirection.Input)
                    '.subAddParameter("@idEstado", txtEstado.Text, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sEstado", Municipio, SqlDbType.VarChar, ParameterDirection.Input)
                    '.subAddParameter("@idMunicipio", txtMunicipio.Text, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sMunicipio", Municipio, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveUsr", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paPropuestasDatosProspectos") Then
                    .Remove("paPropuestasDatosProspectos")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paPropuestasDatosProspectos"))
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub ActualizaAcercamientoProspecto(CveProspecto As String)
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", CveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idAcerca", Ccomoentero.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sOtroAcercamiento", txtComoOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idMedio", cboMedioContacto.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sOtroMedio", txtMedioOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sWeb", txtPagWeb.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveUsr", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paPropuestasDatosProspectos") Then
                    .Remove("paPropuestasDatosProspectos")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paPropuestasDatosProspectos"))
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub ActualizaFuncionarioProspecto(CveProspecto As String)
        Try

            If dtFuncionarios.Rows.Count > 0 Then

                For Each dr As DataRow In dtFuncionarios.Rows

                    Dim Apellidos As String() = dr(0).Split(" ")


                    With ds.Tables
                        With clsLocal
                            .subClearParameters()
                            .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                            .subAddParameter("@sCveProspecto", CveProspecto, SqlDbType.VarChar, ParameterDirection.Input)

                            If Apellidos.Count >= 1 Then
                                .subAddParameter("@sNombFuncionario", Apellidos(0), SqlDbType.VarChar, ParameterDirection.Input)
                            End If
                            If Apellidos.Count >= 2 Then
                                .subAddParameter("@sApellidoPaternoF", Apellidos(1), SqlDbType.VarChar, ParameterDirection.Input)
                            End If
                            If Apellidos.Count >= 3 Then
                                .subAddParameter("@sApellidomaternoF", Apellidos(2), SqlDbType.VarChar, ParameterDirection.Input)
                            End If
                            .subAddParameter("@sCargo", dr(1), SqlDbType.VarChar, ParameterDirection.Input)
                            '.subAddParameter("@sTelefono", txtPagWeb.Text, SqlDbType.VarChar, ParameterDirection.Input)
                            '.subAddParameter("@sMailFuncionario", txtPagWeb.Text, SqlDbType.VarChar, ParameterDirection.Input)

                            .subAddParameter("@sCveUsr", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)

                        End With

                        If .Contains("paPropuestasDatosProspectos") Then
                            .Remove("paPropuestasDatosProspectos")
                        End If

                        .Add(clsLocal.funExecuteSPDataTable("paPropuestasDatosProspectos"))
                    End With

                Next
            End If



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub ActualizaServicioProspecto(CveProspecto As String)
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", CveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idServicio", Ctiposervicio.SelectedValue, SqlDbType.Int, ParameterDirection.Input)

                End With

                If .Contains("paPropuestasDatosProspectos") Then
                    .Remove("paPropuestasDatosProspectos")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paPropuestasDatosProspectos"))
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub ActualizaAccionistaProspecto(CveProspecto As String)
        Try

            If dtAccionistas.Rows.Count > 0 Then

                For Each dr As DataRow In dtAccionistas.Rows

                    Dim Apellidos As String() = dr(0).Split(" ")

                    With ds.Tables
                        With clsLocal
                            .subClearParameters()
                            .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                            .subAddParameter("@sCveProspecto", CveProspecto, SqlDbType.VarChar, ParameterDirection.Input)


                            If Apellidos.Count >= 1 Then
                                .subAddParameter("@sNombAccionista", Apellidos(0), SqlDbType.VarChar, ParameterDirection.Input)
                            End If
                            If Apellidos.Count >= 2 Then
                                .subAddParameter("@sApellidoPaternoA", Apellidos(1), SqlDbType.VarChar, ParameterDirection.Input)
                            End If
                            If Apellidos.Count >= 3 Then
                                .subAddParameter("@sApellidoMaternoA", Apellidos(2), SqlDbType.VarChar, ParameterDirection.Input)
                            End If

                            If dr(1) = "PF" Then
                                .subAddParameter("@idTipoPersona", 1, SqlDbType.VarChar, ParameterDirection.Input)
                            Else
                                .subAddParameter("@idTipoPersona", 2, SqlDbType.VarChar, ParameterDirection.Input)
                            End If

                            .subAddParameter("@dPorcentajeA", dr(2), SqlDbType.Decimal, ParameterDirection.Input)
                            .subAddParameter("@sCveUsr", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)

                        End With

                        If .Contains("paPropuestasDatosProspectos") Then
                            .Remove("paPropuestasDatosProspectos")
                        End If

                        .Add(clsLocal.funExecuteSPDataTable("paPropuestasDatosProspectos"))
                    End With

                Next
            End If



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub ActualizaGerenteSocio(CveProspecto As String)
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", CveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveSocio", CveSocio, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveGerente", CveGerente, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paPropuestasDatosProspectos") Then
                    .Remove("paPropuestasDatosProspectos")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paPropuestasDatosProspectos"))
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub


    ''' ACTUALIZA DATOS DE PROSPECTOS BDCTRL_PROPS
    Private Sub ConsultaClaveProspectoProps(IdProp As Integer)

        With ds.Tables
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", IdProp, SqlDbType.Int, ParameterDirection.Input)

            End With

            If .Contains("paSSGTPropuestasDatosProspectos") Then
                .Remove("paSSGTPropuestasDatosProspectos")
            End If

            .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasDatosProspectos"))
            dtProspecto = .Item("paSSGTPropuestasDatosProspectos")

            If dtProspecto.Rows.Count > 0 Then
                sCveProspecto = dtProspecto(0)("sCveProspecto")
            End If

        End With

    End Sub
    Private Sub ActualizaDireccionProspectoProps(CveProspecto As String)
        Try
            With ds.Tables
                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", CveProspecto, SqlDbType.VarChar, ParameterDirection.Input)

                    .subAddParameter("@idPais", cPais.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCalle", Ccalle.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sNumExt", Cnumext.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sNumInt", Cnumint.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCp", Ccp.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    '.subAddParameter("@idColonia", txtColonia.Text, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sColonia", Colonia, SqlDbType.VarChar, ParameterDirection.Input)
                    '.subAddParameter("@idEstado", txtEstado.Text, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sEstado", Estado, SqlDbType.VarChar, ParameterDirection.Input)
                    '.subAddParameter("@idMunicipio", txtMunicipio.Text, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sMunicipio", Municipio, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveUsr", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paSSGTPropuestasDatosProspectos") Then
                    .Remove("paSSGTPropuestasDatosProspectos")
                End If

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasDatosProspectos"))
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub ActualizaAcercamientoProspectoProps(CveProspecto As String)
        Try
            With ds.Tables
                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", CveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idAcerca", Ccomoentero.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sOtroAcercamiento", txtComoOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idMedio", cboMedioContacto.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sOtroMedio", txtMedioOtro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sWeb", txtPagWeb.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveUsr", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paSSGTPropuestasDatosProspectos") Then
                    .Remove("paSSGTPropuestasDatosProspectos")
                End If

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasDatosProspectos"))
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub ActualizaFuncionarioProspectoProps(CveProspecto As String)
        Try

            If dtFuncionarios.Rows.Count > 0 Then

                For Each dr As DataRow In dtFuncionarios.Rows

                    Dim Apellidos As String() = dr(0).Split(" ")


                    With ds.Tables
                        With clsDatosProp
                            .subClearParameters()
                            .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                            .subAddParameter("@sCveProspecto", CveProspecto, SqlDbType.VarChar, ParameterDirection.Input)

                            If Apellidos.Count >= 1 Then
                                .subAddParameter("@sNombFuncionario", Apellidos(0), SqlDbType.VarChar, ParameterDirection.Input)
                            End If
                            If Apellidos.Count >= 2 Then
                                .subAddParameter("@sApellidoPaternoF", Apellidos(1), SqlDbType.VarChar, ParameterDirection.Input)
                            End If
                            If Apellidos.Count >= 3 Then
                                .subAddParameter("@sApellidomaternoF", Apellidos(2), SqlDbType.VarChar, ParameterDirection.Input)
                            End If
                            .subAddParameter("@sCargo", dr(1), SqlDbType.VarChar, ParameterDirection.Input)
                            '.subAddParameter("@sTelefono", txtPagWeb.Text, SqlDbType.VarChar, ParameterDirection.Input)
                            '.subAddParameter("@sMailFuncionario", txtPagWeb.Text, SqlDbType.VarChar, ParameterDirection.Input)

                            .subAddParameter("@sCveUsr", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)

                        End With

                        If .Contains("paSSGTPropuestasDatosProspectos") Then
                            .Remove("paSSGTPropuestasDatosProspectos")
                        End If

                        .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasDatosProspectos"))
                    End With

                Next
            End If



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub ActualizaAccionistaProspectoProps(CveProspecto As String)
        Try

            If dtAccionistas.Rows.Count > 0 Then

                For Each dr As DataRow In dtAccionistas.Rows

                    Dim Apellidos As String() = dr(0).Split(" ")

                    With ds.Tables
                        With clsDatosProp
                            .subClearParameters()
                            .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                            .subAddParameter("@sCveProspecto", CveProspecto, SqlDbType.VarChar, ParameterDirection.Input)


                            If Apellidos.Count >= 1 Then
                                .subAddParameter("@sNombAccionista", Apellidos(0), SqlDbType.VarChar, ParameterDirection.Input)
                            End If
                            If Apellidos.Count >= 2 Then
                                .subAddParameter("@sApellidoPaternoA", Apellidos(1), SqlDbType.VarChar, ParameterDirection.Input)
                            End If
                            If Apellidos.Count >= 3 Then
                                .subAddParameter("@sApellidoMaternoA", Apellidos(2), SqlDbType.VarChar, ParameterDirection.Input)
                            End If

                            If dr(1) = "PF" Then
                                .subAddParameter("@idTipoPersona", 1, SqlDbType.VarChar, ParameterDirection.Input)
                            Else
                                .subAddParameter("@idTipoPersona", 2, SqlDbType.VarChar, ParameterDirection.Input)
                            End If

                            .subAddParameter("@dPorcentajeA", dr(2), SqlDbType.Decimal, ParameterDirection.Input)
                            .subAddParameter("@sCveUsr", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)

                        End With

                        If .Contains("paSSGTPropuestasDatosProspectos") Then
                            .Remove("paSSGTPropuestasDatosProspectos")
                        End If

                        .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasDatosProspectos"))
                    End With

                Next
            End If



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub


    '''RECHAZOS POR DATOS INCOMPLETOS
    Private Sub BtnInfoIncompleta_Click(sender As Object, e As EventArgs) Handles BtnInfoIncompleta.Click
        Dim Dlg As New dlgIncompletos

        Dlg.sCliente = Cnombre.Text.ToUpper
        Dlg.sCorreoSoc = sMailSoc
        Dlg.sCorreoGnt = sMailGent
        Dlg.idProp = IdProp
        Dlg.sNombeSoc = txtSoc.Text.ToUpper()
        Dlg.sNombGen = txtGerente.Text.ToUpper()

        If Dlg.ShowDialog() = DialogResult.OK Then
            Me.Close()
        End If
    End Sub


End Class