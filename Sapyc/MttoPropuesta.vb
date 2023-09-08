Imports System.Data
Imports System.Data.SqlClient

Public Class MttoPropuesta
    Public Dedonde As Integer
    Public AltaCte As Boolean = False
    Private PasaGiro As Boolean = False
    Private PasaOficina As Boolean = False
    Private Factura As Boolean = False
    Private Ind As Boolean = False
    Public AnombrecteTem As String
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private dtColonias, dtPropuesta, dtPaises, dtCons, dtRfc, dtSubSectores, dtIndustrias, dtSubNiveles As DataTable
    Private Nom, Apat, Amat, CargoTemp, perMoralTemp, PorcTemp, Colonia, Municipio, Estado, SECTOR, Folio, CveDivision As String
    Private Referido, Tenedora As Integer
    Private Solicitado As Char
    Private drPaises As DataRow


    Public Sub LimpiaPan()

        listarIndustrias()
        CargaDatos()

        Cnombre.Text = ""
        Ccontactoinicial.Text = ""
        Ccargocompania.Text = ""
        Ctelefono.Text = ""
        Cemailcontacto.Text = ""
        Ctelefono.Text = ""
        Cextension.Text = ""
        AnombrecteTem = ""
        Crfc.Text = ""

        Ccalle.Text = ""
        Cnumext.Text = ""
        Cnumint.Text = ""
        cColonia.Text = ""
        cMunicipio.Text = ""
        Ccp.Text = ""
        Cpaginaweb.Text = ""

        sSQL = "SELECT CVE, DESCRIPCION,CVEDIVISION FROM DIVISION ORDER BY CVE"
        Carga_ComboSapyc(Cdivision, sSQL)

        sSQL = "SELECT SIAT,DESCRIPCION  FROM OFICINA"
        Carga_ComboSapyc(Coficinaasignada, sSQL)

        sSQL = "SELECT CVE, DESCRIPCION FROM ComoSeEntero ORDER BY CVE"
        Carga_ComboSapyc(Ccomoentero, sSQL)

        Ccomoenterootro.Text = ""

        sSQL = "SELECT CVE, DESCRIPCION FROM MedioDeContacto ORDER BY CVE"
        Carga_ComboSapyc(Cmediocontacto, sSQL)

        Cmediocontactootro.Text = ""

        sSQL = "SELECT CVE, DESCRIPCION FROM TIPODESERVICIO ORDER BY CVE"
        Carga_ComboSapyc(Ctiposervicio, sSQL)

        sSQL = "SELECT CVE, DESCRIPCION FROM PERIODODEREVISION ORDER BY CVE"
        Carga_ComboSapyc(Cayorevision, sSQL)

        sSQL = "SELECT CVE, DESCRIPCION FROM CICLOOPERATIVO ORDER BY CVE"
        Carga_ComboSapyc(Cciclooperativo, sSQL)

        sSQL = "SELECT CVE, DESCRIPCION FROM ESTATUSPROPUESTA ORDER BY CVE"
        Carga_ComboSapyc(Cestatuspropuesta, sSQL)

        sSQL = "SELECT CVE, DESCRIPCION FROM ESTATUSPROPUESTA ORDER BY CVE"
        Carga_ComboSapyc(Cestatuspropuesta, sSQL)

        sSQL = "SELECT CVE, DESCRIPCION FROM ESTATUSPROPUESTA ORDER BY CVE"
        Carga_ComboSapyc(Cestatuspropuesta, sSQL)

        sSQL = "SELECT idPais ,sPais FROM CAT_PAISES ORDER BY sCveTributacion DESC "
        Carga_ComboSapyc(cPais, sSQL)

        sSQL = "SELECT idEstado ,sEstado FROM CAT_ESTADOS"
        Carga_ComboSapyc(Cestado, sSQL)

        LimpiaGT()
        Cdescgpo.SelectedValue = "0099"

        PasaGiro = True
        PasaOficina = True

        ListaFuncionarios.Items.Clear()
        BbajaFun.Enabled = False

        ListaAccionistas.Items.Clear()
        BbajaAcc.Enabled = False


        Cestatuspropuesta.Enabled = False
        Cestatuspropuesta.SelectedValue = 2

    End Sub
    Private Sub Bcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcancelar.Click
        Me.Hide()
        Me.Dispose()
    End Sub
    Private Sub Cnombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cnombre.KeyPress _
              , Ccontactoinicial.KeyPress, Ccargocompania.KeyPress, Cemailcontacto.KeyPress, Ctelefono.KeyPress, Cextension.KeyPress _
              , Ccalle.KeyPress, Cnumext.KeyPress, Cnumint.KeyPress, Ccp.KeyPress, Cestado.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cnombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cnombre.TextChanged
        Aplicar_FiltroNombre()
    End Sub
    Private Sub Ccontactoinicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ccontactoinicial.TextChanged
        Ccontactoinicial.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Ccargocompania_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ccargocompania.TextChanged
        Ccargocompania.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Ccalle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ccalle.TextChanged
        Ccalle.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub txtColonia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtColonia.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub TxtMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtMunicipio.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Crfc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Crfc.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Coficinaasignada_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Coficinaasignada.SelectedValueChanged

        'If Coficinaasignada.SelectedIndex <> 0 Then
        '    sSQL = " SELECT CVEEMP,NOMBRE FROM EMPLEADOS "
        '    sSQL &= " WHERE  STATUS = 'A' and (CVEPUESTO = 'SO' OR CVEPUESTO LIKE 'ASOC%') AND CVEOFI = '" & Coficinaasignada.SelectedItem("SIAT").ToString() & "' AND CVEAREA = '" & Cdivision.SelectedItem("CVEDIVISION").ToString() & "'  "

        '    ' sSQL = "SELECT IdSocio,NombreSocio FROM CATSOCIOS WHERE IdDivision = " & Cdivision.SelectedValue & " ORDER BY NombreSocio "
        '    Carga_ComboSapycSiat(Csocioencargado, sSQL)

        '    sSQL = " SELECT CVEEMP,NOMBRE FROM EMPLEADOS "
        '    sSQL &= " WHERE  STATUS = 'A' and (CVEPUESTO LIKE 'GE%')  AND CVEOFI = '" & Coficinaasignada.SelectedItem("SIAT").ToString() & "' AND CVEAREA = '" & Cdivision.SelectedItem("CVEDIVISION").ToString() & "'  "

        '    'sSQL = "SELECT IdGerente,NombreGerente FROM CATGERENTES WHERE IdDivision = " & Cdivision.SelectedValue & " ORDER BY NombreGerente "
        '    Carga_ComboSapycSiat(Casociadoencargado, sSQL)
        'End If

    End Sub
    Private Sub Cdivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cdivision.SelectedIndexChanged

        If PasaOficina Then
            sSQL = "SELECT CVE, DESCRIPCION FROM TIPODESERVICIO WHERE CVEDIVISION = " & Cdivision.SelectedValue & " ORDER BY DESCRIPCION"
            Carga_ComboSapyc(Ctiposervicio, sSQL)


            Dim AREA As String = Cdivision.SelectedItem("CVEDIVISION").ToString()
            If AREA = "ATI" Or AREA = "CO" Or AREA = "SS" Then
                AREA = "AUD"
            End If

            Dim OFI As String = Coficinaasignada.SelectedItem("SIAT").ToString()
            sSQL = " SELECT CVEEMP, NOMBRE  FROM SOC_ENCARGADOS"
            sSQL &= " WHERE CVEOFI = '" & OFI & "' "
            If OFI = "MEX" Then
                sSQL &= " AND CVEAREA = '" & AREA & "' "
            End If
            Carga_ComboSapyc(Csocioencargado, sSQL)

            CveDivision = Cdivision.SelectedValue
            sSQL = " SELECT DISTINCT  S.CVE, S.DESCRIPCION FROM TIPODESERVICIO S "
            sSQL += " INNER JOIN DIVISION D ON D.CVE = S.CVEDIVISION "

            sSQL += " WHERE D.CVEDIVISION = '" & AREA & "' "

            Carga_ComboSapyc(Ctiposervicio, sSQL)



        End If

    End Sub
    Private Sub BaltaFun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaltaFun.Click
        Dim qop As Integer = 1
        Dim RenglonLista As ListViewItem

        MttoFuncionario.LimpiaPan()
        MttoFuncionario.ShowDialog()
        If MttoFuncionario.Vok Then
            RenglonLista = ListaFuncionarios.Items.Add(MttoFuncionario.Cnombre.Text)     '  0
            RenglonLista.SubItems.Add(MttoFuncionario.Capaterno.Text)     '  1
            RenglonLista.SubItems.Add(MttoFuncionario.Camaterno.Text)     '  2
            RenglonLista.SubItems.Add(MttoFuncionario.Ccargo.Text)        '  3
            BbajaFun.Enabled = True
        End If
        MttoFuncionario.Dispose()

    End Sub
    Private Sub BbajaFun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BbajaFun.Click
        Dim qren As Integer
        Dim qnom As String
        Dim qpat As String
        Dim qmat As String

        If ListaFuncionarios.SelectedItems.Count > 0 Then
            qren = ListaFuncionarios.SelectedIndices.Item(0)
            qnom = ListaFuncionarios.Items.Item(qren).SubItems(0).Text
            qpat = ListaFuncionarios.Items.Item(qren).SubItems(1).Text
            qmat = ListaFuncionarios.Items.Item(qren).SubItems(2).Text
            If MsgBox("Estas seguro de dar de baja a " & qnom & " " & qpat & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Baja funcionario") = MsgBoxResult.Yes Then
                ListaFuncionarios.Items.Item(qren).Remove()
                If ListaFuncionarios.Items.Count <= 0 Then
                    BbajaFun.Enabled = False
                End If
            End If
        End If

    End Sub
    Private Sub BaltaAcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaltaAcc.Click
        Dim RenglonLista As ListViewItem
        Dim qtipo As String
        Dim qnom As String


        SelOpcion.Opcion1.Text = "Persona Física"
        SelOpcion.Opcion2.Text = "Persona Moral"
        SelOpcion.Opcion3.Visible = False
        SelOpcion.Text = "Selección Tipo de Accionista"
        SelOpcion.ShowDialog()
        If SelOpcion.Opcion1.Checked Then
            qtipo = "PF"
        Else
            qtipo = "PM"
        End If
        SelOpcion.Dispose()

        If qtipo = "PF" Then
            MttoAccionistaPF.LimpiaPan()
            MttoAccionistaPF.ShowDialog()
            If MttoAccionistaPF.Vok Then
                qnom = MttoAccionistaPF.Cnombre.Text.Trim & " " & MttoAccionistaPF.Capaterno.Text.Trim & " " & MttoAccionistaPF.Camaterno.Text.Trim
                RenglonLista = ListaAccionistas.Items.Add(qtipo)             '  0
                RenglonLista.SubItems.Add(qnom)                              '  1
                RenglonLista.SubItems.Add(MttoAccionistaPF.Cnombre.Text)     '  2
                RenglonLista.SubItems.Add(MttoAccionistaPF.Capaterno.Text)   '  3
                RenglonLista.SubItems.Add(MttoAccionistaPF.Camaterno.Text)   '  4
                RenglonLista.SubItems.Add(MttoAccionistaPF.Cporcentaje.Text) '  5

                BbajaAcc.Enabled = True
            End If
            MttoAccionistaPF.Dispose()
        Else
            MttoAccionistaPM.LimpiaPan()
            MttoAccionistaPM.ShowDialog()
            If MttoAccionistaPM.Vok Then
                qnom = MttoAccionistaPM.Cnombre.Text.Trim
                RenglonLista = ListaAccionistas.Items.Add(qtipo)             '  0
                RenglonLista.SubItems.Add(qnom)                              '  1
                RenglonLista.SubItems.Add("")                                '  2
                RenglonLista.SubItems.Add("")                                '  3
                RenglonLista.SubItems.Add("")                                '  4
                RenglonLista.SubItems.Add(MttoAccionistaPM.Cporcentaje.Text) '  5
                BbajaAcc.Enabled = True
            End If
            MttoAccionistaPM.Dispose()
        End If

    End Sub
    Private Sub BbajaAcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BbajaAcc.Click
        Dim qren As Integer
        Dim qnom As String

        If ListaAccionistas.SelectedItems.Count > 0 Then
            qren = ListaAccionistas.SelectedIndices.Item(0)
            qnom = ListaAccionistas.Items.Item(qren).SubItems(0).Text
            If MsgBox("Estas seguro de dar de baja a " & qnom & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Baja Accionista") = MsgBoxResult.Yes Then
                ListaAccionistas.Items.Item(qren).Remove()
                If ListaAccionistas.Items.Count <= 0 Then
                    BbajaAcc.Enabled = False
                End If
            End If
        End If

    End Sub
    Private Sub Baceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Baceptar.Click

        Dim Valida As String = ValidaDatos()
        If Valida = "" Then

            InsertaPropuesta()

            If rbNo.Checked Then
                'ENVIA CORREO A SOCIO

                ConsultaEnviaCorreos()
            ElseIf rbYes.Checked Then
                'ENVIA CORREO A SOCIO E INDEPENDENCIA

                ConsultaEnviaCorreos()
                ConsultaEnviaCorreosInd()
            End If
            MsgBox("Se inserto el cliente prospecto de manera correcta!", MsgBoxStyle.Information, "Cliente prospecto")
            LimpiaPan()
            Lista.Visible = False
        Else
            MsgBox(Valida, MsgBoxStyle.Critical, "Dato no capturado")
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

                    sSQL = "SELECT idMunicipio,sMunicipio FROM CAT_MUNICIPIOS WHERE idEstado = " & CInt(dtColonias(0)("idEstado").ToString())
                    Carga_ComboSapyc(cMunicipio, sSQL)

                    sSQL = "SELECT idColonia,sColonia FROM CAT_COLONIAS WHERE idEstado = " & CInt(dtColonias(0)("idEstado").ToString()) & " AND idMunicipio = " & CInt(dtColonias(0)("idMunicipio").ToString())
                    Carga_ComboSapyc(cColonia, sSQL)

                    cColonia.SelectedValue = CInt(dtColonias(0)("idColonia").ToString())
                    Cestado.SelectedValue = CInt(dtColonias(0)("idEstado").ToString())
                    cMunicipio.SelectedValue = CInt(dtColonias(0)("idMunicipio").ToString())

                Else
                    MsgBox("Debes indicar un codigo postal valido", MsgBoxStyle.Information, "Codigo Postal")
                    Exit Sub
                End If


            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub Ccp_Leave(sender As Object, e As EventArgs) Handles Ccp.Leave
        listarColonias()
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
        If Cdivision.Text = "" Then
            Resp = "No se indico la División!"
        End If
        'If Cestado.Text = "" Then
        '    Resp = "No se indico el Estado!"
        'End If
        If Ccomoentero.Text = "" Then
            Resp = "No se indico Como se entero!"
        End If
        If Cmediocontacto.Text = "" Then
            Resp = "No se indico Medio de contacto!"
        End If
        If Ctiposervicio.Text = "" Then
            Resp = "No se indico Tipo de servicio!"
        End If
        If Cayorevision.Text = "" Then
            Resp = "No se indico Año de revisión!"
        End If
        If Coficinaasignada.Text = "" Then
            Resp = "No se indico Oficina asignada!"
        End If
        If Csocioencargado.Text = "" Then
            Resp = "No se indico Socio encargado de oficina!"
        End If
        If rbNo.Checked = False And rbYes.Checked = False Then
            Resp = "No se indico si iniciara proceso de conflick check:!"
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


        If rbYes.Checked Then
            If ListaFuncionarios.Items.Count <= 0 Or ListaAccionistas.Items.Count <= 0 Then
                Resp = "Debes agregar al menos un Funcionario y un accionista!"
            End If
        End If

        Return Resp
    End Function
    Private Sub InsertaPropuesta()

        'Mexico
        If cPais.SelectedIndex = 0 Then
            Colonia = cColonia.Text
            Municipio = cMunicipio.Text
            Estado = Cestado.Text
        Else
            Colonia = txtColonia.Text
            Municipio = txtMunicipio.Text
            Estado = txtEstado.Text
        End If

        If OpSi.Checked Then
            Referido = True
        ElseIf OpNo.Checked Then
            Referido = False
        End If

        If rdSiCompañia.Checked Then
            Tenedora = True
        ElseIf rdNoCompañia.Checked Then
            Tenedora = False
        End If

        If OpPublico.Checked Then
            SECTOR = "Público"
        ElseIf OpPrivado.Checked Then
            SECTOR = "Privado"
        ElseIf OpGobireno.Checked Then
            SECTOR = "Gobierno"
        ElseIf OpOtros.Checked Then
            SECTOR = "Otros"
        End If

        Folio = CreaFolioSapyc(Coficinaasignada.SelectedItem("SIAT").ToString())

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@CVEOFI", Coficinaasignada.SelectedItem("SIAT").ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CVEAREA", Cdivision.SelectedItem("CVEDIVISION").ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@GIRO", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@ACT", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@NOMBEMPRESA", fncQuitarAcentos(Cnombre.Text.ToUpper()), SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOMBCONTACTOINICIAL", Ccontactoinicial.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CARGOCIA", Ccargocompania.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@EMAILCONTA", Cemailcontacto.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@TELEFONO", Ctelefono.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@EXTTEL", Cextension.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@PAIS", CInt(cPais.SelectedValue), SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@CALLE", Ccalle.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOINT", Cnumint.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOEXT", Cnumext.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CP", Ccp.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@COLONIA", Colonia, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@ESTADO", Estado, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@MUNICIPIO", Municipio, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@PAGWEB", Cpaginaweb.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@RFC", Crfc.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@COMOSEENTERO", CInt(Ccomoentero.SelectedValue), SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@MEDIOCONTACTO", CInt(Cmediocontacto.SelectedValue), SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@OTROCOMOENTERO", Ccomoenterootro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@OTROMEDIOCONTACTO", Cmediocontactootro.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@SERVICIO", CInt(Ctiposervicio.SelectedValue), SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@REVISION", CInt(Cayorevision.SelectedValue), SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@CICLO", CInt(Cciclooperativo.SelectedValue), SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@ESTATUS", CInt(Cestatuspropuesta.SelectedValue), SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@OFIASIGNADA", Coficinaasignada.SelectedValue.ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@SOCIO", Csocioencargado.SelectedItem("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@ASOCIADO", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@REFERIDO", Referido, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@NOMREFERIDO", Csocioref.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@FACTURA", Factura, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@cTipo", "M", SqlDbType.Char, ParameterDirection.Input)
                    .subAddParameter("@OFIREFE", Coficinaref.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CVEGPO", Ccvegpo.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@SECTOR", SECTOR, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@TENEDORA", Tenedora, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@EMPTENEDORA", txtEmpresaTenedora.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@PAISTENEDORA", cboPaisResidencia.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@FOLIO", Folio, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@SERVICIOTROS", txtServOtros.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)

                    .subAddParameter("@INDUSTRIA", cboIndustria.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@SUBSECTOR", cboSubSector.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@SUBNIVEL", cboSubNivel.SelectedValue, SqlDbType.Int, ParameterDirection.Input)

                    If rbYes.Checked Then
                        Ind = 1
                        .subAddParameter("@FECHSOLIND", Date.Now, SqlDbType.Int, ParameterDirection.Input)
                    ElseIf rbNo.Checked Then
                        Ind = 0
                    End If
                    .subAddParameter("@CONFLICTOINDEPE", Ind, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@CONFLICTOCHECK", Ind, SqlDbType.Bit, ParameterDirection.Input)

                    If rbYes.Checked Then
                        Solicitado = "S"
                    ElseIf rbNo.Checked Then
                        Solicitado = "N"
                    End If
                    .subAddParameter("@SOLICITO", Solicitado, SqlDbType.Char, ParameterDirection.Input)

                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
                dtPropuesta = .Item("paEmpresaPropuesta")

                If dtPropuesta.Rows.Count > 0 Then
                    Dim IdProp As Integer = dtPropuesta(0)(0)
                    InsertaFuncionarios(IdProp)
                    InsertaAccionistas(IdProp)
                    InsertaBitacora(IdProp)
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub btnGrupos_Click(sender As Object, e As EventArgs)
        Grupos.Bandera = False
        Grupos.ShowDialog()
    End Sub
    Private Sub rdSiCompañia_CheckedChanged(sender As Object, e As EventArgs) Handles rdSiCompañia.CheckedChanged
        ' rbNo.Checked = False
        cboPaisResidencia.Enabled = True
        listarPaises()
    End Sub
    Private Sub rdNoCompañia_CheckedChanged(sender As Object, e As EventArgs) Handles rdNoCompañia.CheckedChanged
        ' rbNo.Checked = False
        cboPaisResidencia.Enabled = False
        Me.cboPaisResidencia.DataSource = New DataTable
    End Sub
    Private Sub OpSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpSi.CheckedChanged
        If OpSi.Checked Then
            CuadroTra.Enabled = True
            Ccvegpo.Text = "0025"
            Cdescgpo.SelectedValue = Ccvegpo.Text
            Cdescgpo.Enabled = False
        End If
    End Sub
    Private Sub Cdescgpo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cdescgpo.SelectedIndexChanged
        If PasaGiro Then
            Ccvegpo.Text = Cdescgpo.SelectedValue
        End If
    End Sub
    Private Sub OpNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpNo.CheckedChanged
        If OpNo.Checked Then
            CuadroTra.Enabled = False
            LimpiaGT()
            Cdescgpo.SelectedValue = "0099"
            Cdescgpo.Enabled = True
        End If
    End Sub
    Private Sub Ccomoentero_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Ccomoentero.SelectedIndexChanged

        If Ccomoentero.SelectedIndex <> 0 Then
            If Ccomoentero.SelectedValue = 12 Then
                Ccomoenterootro.Enabled = True
            Else
                Ccomoenterootro.Enabled = False
            End If
        Else
            Ccomoenterootro.Enabled = False
        End If
    End Sub
    Private Sub Cmediocontacto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmediocontacto.SelectedIndexChanged

        If Cmediocontacto.SelectedIndex <> 0 Then
            If Cmediocontacto.SelectedValue = 10 Then
                Cmediocontactootro.Enabled = True
            Else
                Cmediocontactootro.Enabled = False
            End If
        Else
            Cmediocontactootro.Enabled = False
        End If
    End Sub
    Private Sub InsertaFuncionarios(Emp As String)

        For I As Integer = 0 To ListaFuncionarios.Items.Count - 1

            Try
                With ds.Tables
                    With clsLocal
                        .subClearParameters()

                        .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@PROP", Emp.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                        .subAddParameter("@NOMBRE", ListaFuncionarios.Items.Item(I).SubItems(0).Text.ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                        .subAddParameter("@APAT", ListaFuncionarios.Items.Item(I).SubItems(1).Text.ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                        .subAddParameter("@AMAT", ListaFuncionarios.Items.Item(I).SubItems(2).Text.ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                        .subAddParameter("@CARGO", ListaFuncionarios.Items.Item(I).SubItems(3).Text.ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                    End With

                    If .Contains("paEmpresaPropuesta") Then
                        .Remove("paEmpresaPropuesta")
                    End If

                    .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))


                End With
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try

        Next

    End Sub

    Private Sub Crfc_Leave(sender As Object, e As EventArgs) Handles Crfc.Leave
        If ExisteRFC(Me.Crfc.Text) Then
            MsgBox("No se puede dar de alta un rfc, por que ya esta dado de alta", MsgBoxStyle.Exclamation, "Nombre Incorrecto")
            Crfc.Text = ""
        Else
            Crfc.CharacterCasing = CharacterCasing.Upper
        End If
    End Sub

    Private Sub InsertaAccionistas(Emp As String)

        For I As Integer = 0 To ListaAccionistas.Items.Count - 1
            Try
                With ds.Tables
                    With clsLocal

                        .subClearParameters()
                        .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@PROP", Emp, SqlDbType.VarChar, ParameterDirection.Input)
                        .subAddParameter("@NOMBRE", ListaAccionistas.Items.Item(I).SubItems(1).Text.ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                        .subAddParameter("@APAT", ListaAccionistas.Items.Item(I).SubItems(2).Text.ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                        .subAddParameter("@AMAT", ListaAccionistas.Items.Item(I).SubItems(3).Text.ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                        .subAddParameter("@PERM", ListaAccionistas.Items.Item(I).SubItems(0).Text.ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                        .subAddParameter("@PORC", CDec(ListaAccionistas.Items.Item(I).SubItems(5).Text), SqlDbType.Float, ParameterDirection.Input)
                    End With

                    If .Contains("paEmpresaPropuesta") Then
                        .Remove("paEmpresaPropuesta")
                    End If

                    .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))

                End With
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try

        Next

    End Sub
    Private Sub Aplicar_FiltroNombre()

        Lista.Visible = True
        ' filtrar por el campo Nombrecte
        Dim ret As Integer = Filtrar_DataGridView("NOMBRE", Cnombre.Text.Trim, BindingSource1, Lista)

        If ret > 0 Then
            ' si no hay registros cambiar el color del txtbox   
            'Cnombre.BackColor = Color.Red
            'If MsgBox("¿Este cliente se encuentra en las listas de clientes restringidos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta") = MsgBoxResult.Yes Then
            '    AltaCte = True
            'End If
        Else
            Cnombre.BackColor = Color.White
            Lista.Visible = False
        End If

    End Sub
    Function Filtrar_DataGridView(ByVal Columna As String, ByVal texto As String, ByVal BindingSource As BindingSource,
    ByVal DataGridView As DataGridView) As Integer

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
    Public Sub CargaDatos()
        Try

            sSQL = " SELECT DISTINCT Listado,NOMBRE FROM CLIENTERESTRINGIDO R "
            sSQL += " UNION ALL "
            sSQL += " SELECT DISTINCT 'SIAT',NOMBRECTE FROM BDINV2223.dbo.CLIENTES "
            sSQL += " ORDER BY Listado DESC "

            ' Inicializar la conexión y abrir   
            Using cn As SqlConnection = New SqlConnection(CadenaConexion)
                cn.Open()

                ' Inicializar DataAdapter indicando el sql para recuperar    
                'los registros de la tabla   
                '                sSQL = "SELECT CVEEMP, NOMBRE, CVEPUESTO FROM EMPLEADOS WHERE STATUS = 'A' ORDER BY CVEEMP ASC "
                Dim da As New SqlDataAdapter(sSQL, cn)
                Dim dt As New DataTable ' crear un DataTable   

                ' llenarlo   
                da.Fill(dt)

                ' enlazar el DataTable al BindingSource   
                BindingSource1.DataSource = dt
                Lista.DataSource = BindingSource1.DataSource

                ' Lista.Columns("CVECTE").HeaderText = "No"
                Lista.Columns("NOMBRE").HeaderText = "Nombre"
                Lista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                Lista.Columns(0).Width = 80
                Lista.Columns(1).Width = 300

            End Using
            ' errores   
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub Lista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lista.DoubleClick
        If Lista.SelectedRows.Count > 0 Then

            Lista.Visible = True
            ' filtrar por el campo Nombrecte
            Dim ret As Integer = Filtrar_DataGridView("NOMBRE", Cnombre.Text.Trim, BindingSource1, Lista)

            If ret > 0 Then
                ' si no hay registros cambiar el color del txtbox   
                Cnombre.BackColor = Color.Red
                If MsgBox("Este cliente se encuentra en las listas de clientes restringidos no podrás prestarle servicio !!!", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta") = MsgBoxResult.Yes Then
                    LimpiaPan()
                    AltaCte = True
                    Lista.Visible = False
                    Cnombre.Text = Lista.CurrentRow.Cells("NOMBRE").Value


                End If
            Else
                Cnombre.BackColor = Color.White
            End If

        End If
    End Sub
    Private Sub EnvioCorreoSocio(Correo As String, NombSocio As String)
        Dim sCorreo(), sCorreos, sMensaje As String
        Try
            ' sCorreos = sCorreoUsuario & "," & "Mario.Rodriguez@mx.gt.com" & "," & Correo
            sCorreo = {Correo, "Mario.Rodriguez@mx.gt.com", " sapyc@mx.gt.com"}
            sMensaje = "Estimado(a) " & NombSocio & ", " & vbNewLine & vbNewLine
            sMensaje &= "Se le ha asignado el Cliente Prospecto:  " & Cnombre.Text.ToUpper() & " solicitando servicios profesionales de su división u oficina, pedimos su apoyo para contactarlo y darle puntual seguimiento." & vbNewLine & vbNewLine
            sMensaje &= "Los datos de contacto los podrá revisar en SIAT y puede contactar a Mercadotecnia si tiene alguna duda acerca del origen de esta solicitud."
            sMensaje &= "Se requiere llevar a cabo la verificación de amenazas de independencia (interna y/o externa) así como la investigación de antecedentes."
            sMensaje &= "Este correo es generado de manera automática y no se requiere respuesta alguna."

            envioCorreos(sCorreo, sMensaje, "Propuestas Clientes - Sapyc")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub EnvioCorreoInd(Correo As String, NombSocio As String)
        Dim sCorreo(), sCorreos, sMensaje As String
        Try
            ' sCorreos = sCorreoUsuario & "," & "Mario.Rodriguez@mx.gt.com" & "," & Correo
            sCorreo = {Correo, "Mario.Rodriguez@mx.gt.com", "sapyc@mx.gt.com"}
            sMensaje = "Estimad(a)s, " & vbNewLine & vbNewLine
            sMensaje &= "Se ha generado una propuesta de cliente " & Cnombre.Text.ToUpper() & "  " & vbNewLine & vbNewLine
            sMensaje &= "A la cual podrás darle seguimiento en el sistema de Sapyc 2.0" & vbNewLine & vbNewLine
            envioCorreos(sCorreo, sMensaje, "Propuestas Clientes - Sapyc")
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
        Ccvegpo.Text = "0099"
        Cdescgpo.SelectedValue = CInt(Ccvegpo.Text)
    End Sub
    Private Function CreaFolioSapyc(CVEOFI As String) As String
        Dim Folio As String = ""

        Try

            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 14, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@CVEOFI", CVEOFI, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
                dtCons = .Item("paEmpresaPropuesta")

                If dtCons.Rows.Count > 0 Then
                    Dim OFI As String = dtCons(0)("CVEOFI").ToString
                    Dim Num As Integer = dtCons(0)("CONSECUTIVO")
                    Num = Num + 1
                    Folio = OFI + "0" + (Num).ToString()
                    ActualizaConsecutivo(OFI, Num)
                End If

            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return Folio
    End Function
    Private Sub ActualizaConsecutivo(CveOfi As String, Num As Integer)
        Try

            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 15, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@CVEOFI", CveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CONSECUTIVO", Num, SqlDbType.Int, ParameterDirection.Input)
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
                            EnvioCorreoInd(dr("CORREO").ToString(), dr("NOMBREUSR").ToString())
                        End If
                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub ConsultaEnviaCorreos()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 20, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@ASOCIADO", Csocioencargado.SelectedItem("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))

                dtCorreos = .Item("paEmpresaPropuesta")
                If dtCorreos.Rows.Count > 0 Then
                    For Each dr As DataRow In dtCorreos.Rows
                        If Not IsDBNull(dr("EMAIL")) Then
                            EnvioCorreoSocio(dr("EMAIL").ToString, dr("NOMBRE").ToString()) ''dr("EMAIL").ToString()
                        End If
                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function ExisteRFC(ByVal Rfc As String) As Boolean
        Dim Resp As Boolean = False
        Try
            With ds.Tables
                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iTipo", 3, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sRfc", Rfc, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paConsultaTrabajoRecurrente") Then
                    .Remove("paConsultaTrabajoRecurrente")
                End If

                .Add(clsDatosInv.funExecuteSPDataTable("paConsultaTrabajoRecurrente"))

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
    Private Sub Ctiposervicio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Ctiposervicio.SelectionChangeCommitted

        If Ctiposervicio.SelectedValue = 56 Or Ctiposervicio.SelectedValue = 68 Or Ctiposervicio.SelectedValue = 80 Or Ctiposervicio.SelectedValue = 90 Or Ctiposervicio.SelectedValue = 92 Or Ctiposervicio.SelectedValue = 102 Or Ctiposervicio.SelectedValue = 114 Then
            txtServOtros.Enabled = True
        Else
            txtServOtros.Text = ""
            txtServOtros.Enabled = False
        End If

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





End Class