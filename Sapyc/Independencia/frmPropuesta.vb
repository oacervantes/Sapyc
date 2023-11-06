Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Office.Interop



Public Class frmPropuesta


#Region "VARIABLES"

    Private ds As New DataSet
    Private dtSolicitudes, DtDatos, dtFuncionarios, dtAccionistas, dtSocios, dtGerentes, dtRfc, dtRelacionadas, dtTrabajos, dtGrupos As DataTable
    Private bsSol As New BindingSource
    Private bsTra As New BindingSource
    Private bsGpo As New BindingSource
    Private bsFun As New BindingSource
    Private bsAcc As New BindingSource
    Private bsRel As New BindingSource
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
    Private dtColonias, dtPropuesta, dtPaises, dtCartas, dtCorreos, dtHis, dtCliente, dtGpos, dtSubNiveles, dtSubSectores, dtIndustrias As DataTable
    Private drPaises As DataRow

    Private Nom, Apat, Amat, CargoTemp, perMoralTemp, PorcTemp, Colonia, Municipio, Estado, SECTOR, sCveSocio, sCveGerente As String
    Private Referido, Tenedora, tpoRechazo, stProp, stPropH, RevInde, SubSec, SubNiv As Integer
    Public TpoProp, tpoMoneda As Char
    Public CveOfi, CveArea, CorreosSoc, NombSoc As String
    Private Cveofiref, Cvearearef, Cvesocref, Socio, CveSocio, CveGerente, CveCte, NomEmpresa, CveEmpRef, NombEmpRef, Indus As String
    Dim Msnj As String = ""

#End Region

#Region "EVENTOS"
    Private Sub frmPropuesta_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load


        Me.dgvFuncionarios.DataSource = bsFun
        Me.dgvAccionistas.DataSource = bsAcc
        Me.dgvRelacionadas.DataSource = bsRel
        Me.dgGrupos.DataSource = bsGpo
        Me.gbTrabajos.DataSource = bsTra

        IdProp = IdProp
        TpoProp = TpoProp

        CargaCombos()
        listarPaises()
        LimpiaGT()
        listarIndustrias()

        If IdProp <> 0 Then

            ConsultaPropuesta()

            ConsultaSocio(sCveSocio)
            ConultaGerente(sCveGerente)

            ConsultaCveCliente()
            ConsultaTrabajos()


            If CveCte <> "" Then
                ConsultaFuncionariosClientes()
                ConsultaAccionistasClientes()
            Else
                ConsultaFuncionarios()
                ConsultaAccionistas()
            End If
            ConsultaRelacionadas()

        End If
        Permite = True
        PasaNomb = True

        If sTipo = 2 Then
            gpBgc.Visible = True
            GBCC.Visible = True
            GBCC.Enabled = False
        ElseIf sTipo = 3 Then
            GBCC.Visible = True
            gpBgc.Visible = True
            gpBgc.Enabled = False

        End If



    End Sub
    Private Sub Bcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub Cnombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)



        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cnombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cnombre.CharacterCasing = CharacterCasing.Upper

        If PasaNomb Then
            If Cnombre.Text.Length > 0 Then
                CargaDatos()
                Aplicar_FiltroNombre()
            End If

        End If
    End Sub
    Private Sub Ccontactoinicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Ccontactoinicial.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Ccargocompania_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Ccargocompania.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Ccalle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Ccalle.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub txtColonia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtColonia.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub TxtMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtMunicipio.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Crfc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ExisteRFC(Me.Crfc.Text) Then
            MsgBox("No se puede dar de alta un rfc, por que ya esta dado de alta", MsgBoxStyle.Exclamation, "Nombre Incorrecto")
            Exit Sub
        Else
            Crfc.CharacterCasing = CharacterCasing.Upper
        End If
    End Sub
    Private Sub Baceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Baceptar.Click

        If sTipo = 2 Then
            Dim nivel As Integer = CmbNivel.SelectedValue
            ActualizaNivel(nivel)
            'ConsultaCorreosBack()

            DialogResult = Windows.Forms.DialogResult.OK
            MsgBox("Se actualizo la propuesta de manera correcta!", MsgBoxStyle.Information, "Cliente prospecto")

        ElseIf sTipo = 3 Then
            Dim Ind As Integer

            If rbNo.Checked Then
                Ind = 1
            ElseIf rbSi.Checked Then
                Ind = 2
            End If
            ActualizaConflict(Ind)
            ConsultaCorreos()
            EnvioCorreoSocios()
            DialogResult = Windows.Forms.DialogResult.OK
            MsgBox("Se actualizo la propuesta de manera correcta!", MsgBoxStyle.Information, "Cliente prospecto")
        End If


    End Sub
    Private Sub cPais_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        'If cPais.SelectedIndex = 0 Then
        '    cColonia.Visible = True
        '    Cestado.Visible = True
        '    cMunicipio.Visible = True

        '    txtColonia.Visible = False
        '    txtEstado.Visible = False
        '    txtMunicipio.Visible = False
        'Else
        '    txtColonia.Visible = True
        '    txtEstado.Visible = True
        '    txtMunicipio.Visible = True

        '    cColonia.Visible = False
        '    Cestado.Visible = False
        '    cMunicipio.Visible = False

        'End If

    End Sub
    Private Sub Ccp_Leave(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Private Sub btnGuardaDF_Click(ByVal sender As Object, ByVal e As EventArgs)

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
    Private Sub Ccomoentero_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

        'If Ccomoentero.SelectedIndex <> 0 Then
        '    If Ccomoentero.SelectedValue = 12 Then
        '        Ccomoenterootro.Enabled = True
        '    Else
        '        Ccomoenterootro.Enabled = False
        '    End If
        'Else
        '    Ccomoenterootro.Enabled = False
        'End If
    End Sub
    Private Sub Cmediocontacto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

        'If Cmediocontacto.SelectedIndex <> 0 Then
        '    If Cmediocontacto.SelectedValue = 10 Then
        '        Cmediocontactootro.Enabled = True
        '    Else
        '        Cmediocontactootro.Enabled = False
        '    End If
        'Else
        '    Cmediocontactootro.Enabled = False
        'End If
    End Sub
    Private Sub Lista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
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
    Private Sub rbSi_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbSi.CheckedChanged
        rbNo.Checked = False
        lblMotivo.Visible = True
        txtMotivoIndepen.Visible = True
    End Sub
    Private Sub rbNo_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbNo.CheckedChanged
        rbSi.Checked = False
        lblMotivo.Visible = False
        txtMotivoIndepen.Visible = False
    End Sub
    Private Sub OpSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OpSi.Checked Then
            CuadroTra.Enabled = True
            Ccvegpo.Text = "0025"
            Cdescgpo.SelectedValue = Ccvegpo.Text
            Cdescgpo.Enabled = False
        End If
    End Sub
    Private Sub OpNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OpNo.Checked Then
            CuadroTra.Enabled = False
            LimpiaGT()
            Ccvegpo.Text = "0099"
            Cdescgpo.SelectedValue = Ccvegpo.Text
            Cdescgpo.Enabled = True
            'Me.rdNoCompañia.Checked = True
        End If
    End Sub
    Private Sub Ctiposervicio_SelectionChangeCommitted(sender As Object, e As EventArgs)

        If Ctiposervicio.SelectedValue = 56 Or Ctiposervicio.SelectedValue = 68 Or Ctiposervicio.SelectedValue = 80 Or Ctiposervicio.SelectedValue = 90 Or Ctiposervicio.SelectedValue = 92 Or Ctiposervicio.SelectedValue = 102 Or Ctiposervicio.SelectedValue = 114 Then
            txtServOtros.Enabled = True
        Else
            txtServOtros.Enabled = False
        End If

    End Sub

#End Region
#Region "METODOS"
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


                    txtMedioContacto.Text = DtDatos(0)("MEDIOCON").ToString()
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

                    'OcultaControles(DtDatos(0)("CVEAREA").ToString())

                    'txtQuno.Text = DtDatos(0)("TRANSCOMERCIO").ToString()
                    'txtQdos.Text = DtDatos(0)("ESTUDIOSPT").ToString()

                    'If txtQuno.Text <> "" Then
                    '    rbtnQnoUno.Checked = True
                    'Else
                    '    rbtnQsiUno.Checked = True
                    'End If
                    'If txtQdos.Text <> "" Then
                    '    rbtnQnoDos.Checked = True
                    'Else
                    '    rbtnQsiDos.Checked = True
                    'End If

                    Ctiposervicio.Text = DtDatos(0)("SERVICIO").ToString()
                    txtAñoRevision.Text = DtDatos(0)("ANIOREV").ToString()
                    txtCiclo.Text = DtDatos(0)("CICLO").ToString()

                    Cestatuspropuesta.Text = DtDatos(0)("ESTATUS").ToString()

                    If DtDatos(0)("SOCIO").ToString() = "" Then
                        txtSoc.Text = "doble click para listar a los socios"
                    Else
                        txtSoc.Text = DtDatos(0)("SOCIO").ToString()
                    End If

                    txtCiaRef.Text = DtDatos(0)("CIAREFERIDA").ToString()
                    cPais.Text = DtDatos(0)("PAIS").ToString()
                    txtCalle.Text = DtDatos(0)("CALLE").ToString()
                    txtNumint.Text = DtDatos(0)("NOINT").ToString()
                    txtNumExt.Text = DtDatos(0)("NOEXT").ToString()
                    txtCp.Text = DtDatos(0)("CP").ToString()
                    txtColonia.Text = DtDatos(0)("COLONIA").ToString()
                    txtEstado.Text = DtDatos(0)("ESTADO").ToString()
                    txtMunicipio.Text = DtDatos(0)("MUNICIPIO").ToString()
                    txtPagWeb.Text = DtDatos(0)("PAGINAWEB").ToString()
                    CmbNivel.SelectedValue = DtDatos(0)("NIVELRIESGO")

                    txtHonorarios.Text = IIf(IsDBNull(DtDatos(0)("HONORARIOS").ToString()), "", DtDatos(0)("HONORARIOS").ToString())
                    txtDescRechazo.Text = IIf(IsDBNull(DtDatos(0)("DESCRECHAZO").ToString()), "", DtDatos(0)("DESCRECHAZO").ToString())
                    Dim TpoMon As Char = IIf(IsDBNull(DtDatos(0)("TPOMONEDA").ToString()), "", DtDatos(0)("TPOMONEDA").ToString())

                    If TpoMon = "P" Then
                        rbPs.Checked = True
                    ElseIf TpoMon = "D" Then
                        rbDs.Checked = True
                    End If
                    CRechazo.SelectedValue = DtDatos(0)("TPORECHAZO")

                    ConsultaSocioRef(DtDatos(0)("SOCIOREF"))

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

                    Coficinaref.Text = DtDatos(0)("OFIREFE")
                    Ccvegpo.Text = DtDatos(0)("CVEGPO")
                    Cdescgpo.SelectedValue = DtDatos(0)("CVEGPO")
                    txtEmpresaTenedora.Text = DtDatos(0)("EMPTENEDORA")

                    If DtDatos(0)("PAISTENEDORA") = "" Then
                        cboPaisResidencia.SelectedValue = -1
                    Else
                        cboPaisResidencia.Text = DtDatos(0)("PAISTENEDORA")
                    End If
                    Csocioref.Text = DtDatos(0)("NOMREFERIDO")
                    Ccvegpo.Text = Ccvegpo.Text
                    Cdescgpo.SelectedValue = Ccvegpo.Text

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

                End If

                ConsultaCotizacion()
                If dtCartas.Rows.Count > 0 Then
                    Dim Nomb As String = dtCartas(0)("SNOMBARCHIVO")
                    txtCarta.Text = Nomb
                    btnCarga.Enabled = False
                End If

                If DtDatos(0)("SOLICITO") = "N" Then
                ElseIf DtDatos(0)("SOLICITO") = "S" Then
                    SoloLectura()
                End If

                If Ccvegpo.Text <> "0099" And Ccvegpo.Text <> "0025" And Ccvegpo.Text <> "" And CveCte = "" And Ccvegpo.Text <> "0001" Then
                    'Cdescgpo.Text = DescGpo
                    'Ccvegpo.Text = Ccvegpo.Text

                    Cdescgpo.Enabled = False
                    Ccvegpo.Enabled = False

                    ConsultaAccionistasGrupo(Ccvegpo.Text)
                    ConsultaFuncionariosGrupo(Ccvegpo.Text)
                    ConsultaGrupos(Ccvegpo.Text)

                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaCombos()

        sSQL = "SELECT CVE, DESCRIPCION FROM ESTATUSPROPUESTA ORDER BY CVE"
        Carga_ComboSapyc(Cestatuspropuesta, sSQL)

        sSQL = "SELECT idPais ,sPais FROM CAT_PAISES ORDER BY sCveTributacion DESC "
        Carga_ComboSapyc(cPais, sSQL)

        sSQL = "SELECT IDNIVEL,NIVELRIESGO FROM NIVELRIESGO ORDER BY IDNIVEL"
        Carga_ComboSapyc(CmbNivel, sSQL)

        sSQL = "SELECT IDMOTIVO,MOTIVO FROM MOTIVODERECHAZO ORDER BY IDMOTIVO"
        Carga_ComboSapyc(CRechazo, sSQL)

        sSQL = "SELECT CVE, DESCRIPCION FROM ComoSeEntero ORDER BY CVE"
        Carga_ComboSapyc(Ccomoentero, sSQL)

    End Sub
    Private Function ValidaDatos() As String
        Dim Resp As String = ""

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

        If txtSoc.Text = "" Then
            Resp = "No se indico Socio!"
        End If
        If txtGerente.Text = "" Then
            Resp = "No se indico gerente!"
        End If

        If Crfc.Text = "" Then
            Resp = "No se ha especificado el RFC del cliente."
        End If

        If Cestatuspropuesta.SelectedValue = 4 Or Cestatuspropuesta.SelectedValue = 6 Then
            If txtDescRechazo.Text = "" Then
                Resp = "Debes indicar el motivo del rechazo !"
            End If
        End If

        Return Resp
    End Function
    Private Function ExisteRFC(ByVal Rfc As String) As Boolean
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
    Private Sub Cdescgpo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Permite Then
            Ccvegpo.Text = Cdescgpo.SelectedValue
        End If
    End Sub
    Private Sub dgGrupos_DoubleClick(sender As Object, e As EventArgs)
        Dim dlg As New frmTrabajosCliente
        Try

            If Not dgGrupos.CurrentRow Is Nothing Then
                If dgGrupos.Rows.Count > 0 Then

                    Dim CVECTE As String = dgGrupos.CurrentRow.Cells("CVECTE").Value
                    dlg.CveCtes = CVECTE
                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        ' ListaSolicitudes()
                    End If

                Else
                    MsgBox("No existen propuestas registradas.", MsgBoxStyle.Exclamation, "SAPYC")
                End If
            Else
                MsgBox("Seleccione la propuesta que desea actualizar.", MsgBoxStyle.Exclamation, "SAPYC")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Cestatuspropuesta_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Permite Then

            If Cestatuspropuesta.SelectedValue = 4 Or Cestatuspropuesta.SelectedValue = 6 Then
                lblMotiRecha.Visible = True
                lblDescRechazo.Visible = True
                CRechazo.Visible = True
                txtDescRechazo.Visible = True
            ElseIf Cestatuspropuesta.SelectedValue = 1 Or Cestatuspropuesta.SelectedValue = 5 Then
                If RevInde = 0 Or RevConf = False Then
                    MsgBox("No puede estar en estatus aceptada hasta que este revisada por independencia", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Sapyc")
                    Cestatuspropuesta.SelectedValue = 2
                    Exit Sub
                End If
            Else
                lblMotiRecha.Visible = False
                lblDescRechazo.Visible = False
                CRechazo.Visible = False
            End If

        End If
    End Sub
    Private Sub rbDs_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        If rbDs.Checked Then
            rbPs.Checked = False
        End If
    End Sub
    Private Sub txtHonorarios_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
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
    Private Sub rbPs_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
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
    Private Sub EliminaFuncionarios()

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPropuesta", IdProp, SqlDbType.Int, ParameterDirection.Input)

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
    Private Sub EliminaAccionistas()

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPropuesta", IdProp, SqlDbType.Int, ParameterDirection.Input)

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
    Private Sub listarPaises()
        Try
            dtPaises = New DataTable
            dtPaises.Columns.Add("CVEPAIS", GetType(System.String))
            dtPaises.Columns.Add("PAIS", GetType(System.String))

            drPaises = dtPaises.NewRow
            drPaises("CVEPAIS") = "US"
            drPaises("PAIS") = "EE.UU."
            dtPaises.Rows.InsertAt(drPaises, dtPaises.Rows.Count)

            drPaises = dtPaises.NewRow
            drPaises("CVEPAIS") = "CA"
            drPaises("PAIS") = "Canadá"
            dtPaises.Rows.InsertAt(drPaises, dtPaises.Rows.Count)

            drPaises = dtPaises.NewRow
            drPaises("CVEPAIS") = "UK"
            drPaises("PAIS") = "Reino Unido"
            dtPaises.Rows.InsertAt(drPaises, dtPaises.Rows.Count)

            drPaises = dtPaises.NewRow
            drPaises("CVEPAIS") = "GE"
            drPaises("PAIS") = "Alemania"
            dtPaises.Rows.InsertAt(drPaises, dtPaises.Rows.Count)

            drPaises = dtPaises.NewRow
            drPaises("CVEPAIS") = "FR"
            drPaises("PAIS") = "Francia"
            dtPaises.Rows.InsertAt(drPaises, dtPaises.Rows.Count)

            drPaises = dtPaises.NewRow
            drPaises("CVEPAIS") = "JP"
            drPaises("PAIS") = "Japón"
            dtPaises.Rows.InsertAt(drPaises, dtPaises.Rows.Count)

            drPaises = dtPaises.NewRow
            drPaises("CVEPAIS") = "OT"
            drPaises("PAIS") = "Otros"
            dtPaises.Rows.InsertAt(drPaises, dtPaises.Rows.Count)

            Me.cboPaisResidencia.DataSource = dtPaises
            Me.cboPaisResidencia.ValueMember = dtPaises.Columns("CVEPAIS").Caption.ToString
            Me.cboPaisResidencia.DisplayMember = dtPaises.Columns("PAIS").Caption.ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub LimpiaGT()
        sSQL = "SELECT CVEGPO, DESCGPO FROM GRUPOS "
        Carga_ComboSapycSiat(Cdescgpo, sSQL)
    End Sub
    Private Sub EnvioCorreo(ByVal Correo As String, ByVal NombSocio As String)
        Dim sCorreos, sMensaje As String
        Dim sCorreo As String() = {Correo, "Mario.Rodriguez@mx.gt.com", "Mario.Rodriguez@mx.gt.com"}

        Try
            ' sCorreos = sCorreoUsuario & "," & "Mario.Rodriguez@mx.gt.com" & "," & Correo
            sMensaje = "Estimado(a) " & NombSocio & ", " & vbNewLine & vbNewLine
            sMensaje &= "Se genero una solicitud de revison de cliente" & vbNewLine & vbNewLine
            'enviarCorreos(sCorreo, sMensaje, "Propuestas Clientes - Sapyc")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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
    Private Sub EnvioCorreoSocios()
        Dim sMensaje As String

        If rbSi.Checked Then
            Msnj = txtMotivoIndepen.Text.ToUpper + "    " + "SI" + " ;"
        ElseIf rbNo.Checked Then
            Msnj = "NO"
        End If

        Dim sCorreo As String() = CorreosSoc.Split(";")

        Try

            sMensaje = "Estimado Equipo:  " & NombSoc.TrimEnd(";") & " " & vbNewLine & vbNewLine
            sMensaje &= "Se ha realizado la verificación de conflictos de interes y/o amenazas de independencia "
            sMensaje &= "(interna y/o externa) al prospecto  " & NomEmpresa & "  " & vbNewLine & vbNewLine
            sMensaje &= "De las respuestas recibidas  " & Msnj.ToString() & " se identificó situación que afecta nuestra independencia. " & vbNewLine & vbNewLine
            sMensaje &= "Para cualquier aclaración sobre el tema contactar a cecilia.coronel@mx.gt.com y heidi.martinez@mx.gt.com " & vbNewLine & vbNewLine
            envioCorreos(sCorreo, sMensaje, "Propuestas Clientes - Sapyc")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub EnvioCorreoSociosBack()
        Dim sMensaje As String
        Dim Msnj As String = ""

        If rbSi.Checked Then
            Msnj = "SI"
        ElseIf rbNo.Checked Then
            Msnj = "NO"
        End If

        Dim sCorreo As String() = CorreosSoc.Split(";")

        Try

            sMensaje = "Estimado Equipo:  " & NombSoc.TrimEnd(";") & " " & vbNewLine & vbNewLine
            sMensaje &= "Se ha realizado la verificación de conflictos de interes y/o amenazas de independencia "
            sMensaje &= "(interna y/o externa) al prospecto  " & NomEmpresa & "  " & vbNewLine & vbNewLine
            sMensaje &= "De las respuestas recibidas  " & Msnj.ToString() & " se identificó situación que afecta nuestra independencia. " & vbNewLine & vbNewLine
            sMensaje &= "Para cualquier aclaración sobre el tema contactar a cecilia.coronel@mx.gt.com y heidi.martinez@mx.gt.com " & vbNewLine & vbNewLine
            envioCorreos(sCorreo, sMensaje, "Propuestas Clientes - Sapyc")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

#End Region
    Private Sub btnVer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVer.Click

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
    Private Sub btnCarga_Click(ByVal sender As Object, ByVal e As EventArgs)
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
    Public Sub convierte_bytes_a_archivo(ByVal aByte() As Byte, ByVal fileName As String)

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
            Dim tempFileName As String = Path.GetTempFileName()
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
    Public Sub GuardaCotizacion(ByVal Nomb As String, ByVal Ext As String, ByVal Archivo As Byte())
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

            CorreosSoc = CorreosSoc + "independencia@mx.gt.com"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub ConsultaCorreosBack()
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

            CorreosSoc = CorreosSoc + "backgroundcheck@mx.gt.com"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
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
    Private Sub InsertaBitacora(ByVal idProp As Integer)
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
                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iTipo", 7, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSoc", Cvesocio, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paConsultaTrabajoRecurrente") Then
                    .Remove("paConsultaTrabajoRecurrente")
                End If

                .Add(clsDatosInv.funExecuteSPDataTable("paConsultaTrabajoRecurrente"))

                dtSocios = .Item("paConsultaTrabajoRecurrente")
                If dtSocios.Rows.Count > 0 Then
                    txtSoc.Text = dtSocios(0)("NOMBRE")
                End If


            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Public Sub ConsultaSocioRef(Cvesocio As String)

        Try

            With ds.Tables
                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iTipo", 7, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSoc", Cvesocio, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paConsultaTrabajoRecurrente") Then
                    .Remove("paConsultaTrabajoRecurrente")
                End If

                .Add(clsDatosInv.funExecuteSPDataTable("paConsultaTrabajoRecurrente"))

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
                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iTipo", 7, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSoc", CveGerente, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paConsultaTrabajoRecurrente") Then
                    .Remove("paConsultaTrabajoRecurrente")
                End If

                .Add(clsDatosInv.funExecuteSPDataTable("paConsultaTrabajoRecurrente"))

                dtGerentes = .Item("paConsultaTrabajoRecurrente")
                If dtGerentes.Rows.Count > 0 Then
                    txtGerente.Text = dtGerentes(0)("NOMBRE")
                End If


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
    Private Sub Crfc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Crfc.TextLength <> 12 And Crfc.TextLength <> 13 Then
            MsgBox("El RFC es incorrecto, vuelva a escribirlo por favor.", MsgBoxStyle.Exclamation, "SAPYC")
            Exit Sub
        End If
    End Sub
    Public Sub SoloLectura()
        Cnombre.ReadOnly = True
        txtOfiAsignada.ReadOnly = True
        Ccontactoinicial.ReadOnly = True
        Cemailcontacto.ReadOnly = True
        Crfc.ReadOnly = True
        txtPagWeb.ReadOnly = True
        txtDivision.ReadOnly = True
        Ctelefono.ReadOnly = True
        Ccargocompania.ReadOnly = True

        Ccomoentero.Enabled = False
        txtComoOtro.ReadOnly = True
        'Ctiposervicio.Enabled = False
        txtSoc.ReadOnly = True
        txtGerente.ReadOnly = True
        txtMedioContacto.ReadOnly = True
        btnAltaRel.Visible = False
        btnBajaRel.Visible = False
        BaltaAcc.Visible = False
        BbajaAcc.Visible = False
        BaltaFun.Visible = False
        BbajaFun.Visible = False
        cPais.Enabled = False
        txtNumint.ReadOnly = True
        txtCp.ReadOnly = True
        txtEstado.ReadOnly = True
        txtCalle.ReadOnly = True
        txtNumExt.ReadOnly = True
        txtColonia.ReadOnly = True
        txtMunicipio.ReadOnly = True
        txtSocio.ReadOnly = True
        txtGnt.ReadOnly = True
        txtEmp.ReadOnly = True


    End Sub
    Private Sub Ccomoentero_SelectionChangeCommitted(sender As Object, e As EventArgs)

        'socio
        If Ccomoentero.SelectedValue = 7 Then
            txtSocio.Enabled = True
            txtSocio.Visible = True
            txtGnt.Visible = False
            txtEmp.Visible = False
            'gerente
        ElseIf Ccomoentero.SelectedValue = 8 Then
            txtGnt.Enabled = True
            txtGnt.Visible = True
            txtSocio.Visible = False
            txtEmp.Visible = False
            'empleado

        ElseIf Ccomoentero.SelectedValue = 13 Then
            txtEmp.Enabled = True
            txtEmp.Visible = True
            txtSocio.Visible = False
            txtGnt.Visible = False
        Else
            txtEmp.Enabled = False
            txtSocio.Enabled = False
            txtGnt.Enabled = False

        End If


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
    Private Sub ConsultaGrupos()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 13, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveCte", CveCte, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            dtGpos = .Item("paSapyc")

            If dtGpos.Rows.Count > 0 Then
                bsGpo.DataSource = dtGpos
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
    Private Sub cboIndustria_SelectionChangeCommitted(sender As Object, e As EventArgs)
        If cboIndustria.SelectedIndex <> -1 Then
            listarSubSectores1(Me.cboIndustria.SelectedValue)
        End If

    End Sub
    Private Sub cboSubSector_SelectionChangeCommitted(sender As Object, e As EventArgs)
        If cboSubSector.SelectedIndex <> -1 Then
            listarSubNiveles1(Me.cboSubSector.SelectedValue)
        End If
    End Sub
    Private Sub ConsultaFuncionariosGrupo(CveGpo As String)
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 35, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@CVEGPO", Ccvegpo.Text, SqlDbType.VarChar, ParameterDirection.Input)

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
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 13, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveCte", CveCte, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            dtGpos = .Item("paSapyc")

            If dtGpos.Rows.Count > 0 Then
                bsGpo.DataSource = dtGpos
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




End Class