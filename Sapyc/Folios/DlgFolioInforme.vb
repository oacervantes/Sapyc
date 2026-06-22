Public Class DlgFolioInforme

    Private ds As New DataSet

    Private sNameRpt As String = "Generar folio de informe"

    Private dtPreguntas, dtInf, dtOpi, dtBas, dtIdi, dtCob, dtHon, dtSolicitudes, dtValidaSol As New DataTable
    Private drInf, drOpi, drBas, drIdi As DataRow

    Private idFolio As Integer
    Private dFechaFinal, dFechaInicio As Date
    Private dCobranza, dHonorarios, dHonorariosMin As Double

    Public sCveOfi, sCveArea, sCveSocio, sCveGer, sCveTra As String
    Public iServicio, idsol As Integer

    Private Sub DlgFolioInforme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarPreguntas()
        If dtPreguntas Is Nothing Then
            Exit Sub
        End If

        'dFechaInicio = IIf(Now.Month >= 8, "01/06/" & Now.Year, "01/06/" & Now.Year - 1)
        dFechaInicio = ""
        dFechaFinal = CDate("")

        ListarCombo(cboInforme, 1)
        ListarCombo(cboOpinion, 2)
        ListarCombo(cboBasadoEn, 3)
        ListarCombo(cboIdioma, 4)
    End Sub
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ' Dim dlg As New DlgCvesTraFolios

        'If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        '    txtTrabajo.Text = dlg.sCveTra
        '    txtCliente.Text = dlg.sNombreCte
        '    txtServicio.Text = dlg.sDescripcion
        '    txtOficina.Text = dlg.sOficina
        '    txtDivision.Text = dlg.sArea
        '    sCveOfi = dlg.sCveOfi
        '    sCveArea = dlg.sCveArea
        '    sCveSocio = dlg.sCveSocio
        '    sCveGer = dlg.sCveGer
        '    sCveTra = dlg.sCveTra
        '    iServicio = dlg.iServicio

        '    ValidaExistanSolicitudes(sCveTra)

        '    If dtValidaSol.Rows.Count = 0 Then

        '        If (iServicio = 45 Or iServicio = 46) And sCveArea = "AUD" Then
        '            ListarCobranza(sCveTra)
        '            ListarHonorarios(sCveTra)
        '            ListarSolicitudes(sCveTra)

        '            sSQL = "SELECT dPorcentajeFolio FROM PARAMETROS_SIAT"
        '            dPorFolio = CInt(BuscaCampoTextoCon(sSQL))

        '            'Consultar el saldo de la cobranza.
        '            If dtCob.Rows.Count > 0 Then
        '                dCobranza = (CDbl(dtCob.Rows(0).Item("IMPORTEHON").ToString) + CDbl(dtCob.Rows(0).Item("IMPORTEGAS").ToString))
        '            Else
        '                dCobranza = 0
        '            End If

        '            'Consultar el saldo de los honorarios.
        '            If dtHon.Rows.Count > 0 Then
        '                dHonorarios = CDbl(dtHon.Rows(0).Item("TOTAL").ToString)
        '            Else
        '                dHonorarios = 0
        '            End If

        '            dHonorariosMin = Math.Round((dHonorarios * (dPorFolio / 100)))

        '            ' If ((dCobranza <> dHonorarios) And dCobranza < dHonorarios) Or dCobranza = 0 Or dHonorarios = 0 Then
        '            If dtSolicitudes.Rows.Count = 0 Then
        '                lblMsgError.Visible = True
        '                lblDetalle.Visible = True

        '                gpBoxDatosInforme.Enabled = False
        '                btnGenerarFolio.Enabled = False
        '                btnCopiarFolio.Enabled = False
        '                txtCteRelacionado.Enabled = False
        '            Else
        '                If dtSolicitudes.Rows(0).Item("STATUS").ToString = "A" Then
        '                    lblMsgError.Visible = False

        '                    gpBoxDatosInforme.Enabled = True
        '                    btnGenerarFolio.Enabled = True
        '                    btnCopiarFolio.Enabled = True
        '                    txtCteRelacionado.Enabled = True
        '                Else
        '                    lblMsgError.Visible = True
        '                    lblDetalle.Visible = True

        '                    gpBoxDatosInforme.Enabled = False
        '                    btnGenerarFolio.Enabled = False
        '                    btnCopiarFolio.Enabled = False
        '                    txtCteRelacionado.Enabled = False
        '                End If
        '            End If
        '        End If
        '    Else
        '        MsgBox("Existen solicitudes de folio pendientes para esta clave de trabajo, una vez que las atiendan podrá generar su folio", MsgBoxStyle.Exclamation, "SIAT")
        '        lblMsgError.Visible = True
        '        lblDetalle.Visible = True

        '        gpBoxDatosInforme.Enabled = False
        '        btnGenerarFolio.Enabled = False
        '        btnCopiarFolio.Enabled = False
        '        txtCteRelacionado.Enabled = False
        '    End If
        '    'Else
        '    '    lblMsgError.Visible = False

        '    '    gpBoxDatosInforme.Enabled = True
        '    '    btnGenerarFolio.Enabled = True
        '    '    btnCopiarFolio.Enabled = True
        '    '    txtCteRelacionado.Enabled = True
        '    'End If
        'End If
    End Sub
    Private Sub BtnGenerarFolio_Click(sender As Object, e As EventArgs) Handles btnGenerarFolio.Click
        If ValidarForma() = False Then
            Exit Sub
        End If

        If MsgBox("Se va a generar el folio de informe para la clave de trabajo seleccionada, ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
            GenerarFolioInforme()
            ActualizaSolcitudFolio()
            EnviarCorreoAviso()
        End If
    End Sub
    Private Sub BtnCopiarFolio_Click(sender As Object, e As EventArgs) Handles btnCopiarFolio.Click
        My.Computer.Clipboard.SetText(txtFolio.Text)
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = DialogResult.Cancel
    End Sub
    Private Sub LblDetalle_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblDetalle.LinkClicked
        'Dim dlg As New DlgDetalleCveFolio With {
        '    .sCveTra = txtTrabajo.Text,
        '    .sNombreCte = txtCliente.Text,
        '    .sCveOfi = sCveOfi,
        '    .sCveArea = sCveArea,
        '    .dHonorarios = dHonorarios,
        '    .dCobranza = dCobranza
        '}

        'dlg.ShowDialog()
    End Sub
    Private Sub CboInforme_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboInforme.SelectionChangeCommitted
        If cboInforme.SelectedValue = 3 Then

            txtInformeRelativo.Enabled = True
            txtInformeRelativo.ReadOnly = False
            txtInformeRelativo.Focus()

            cboOpinion.DataSource = LlenarCombo(2)
            cboOpinion.DisplayMember = "sOpcion"
            cboOpinion.ValueMember = "idOpcion"

            gpBoxRespuesta.Enabled = True
            txtArchivo.Enabled = True
            rdSi.Checked = True

        ElseIf cboInforme.SelectedValue = 4 Then
            cboOpinion.DataSource = LlenarComboPLD(2)
            cboOpinion.DisplayMember = "sOpcion"
            cboOpinion.ValueMember = "idOpcion"

            gpBoxRespuesta.Enabled = False
            txtArchivo.Enabled = False
            rdNo.Checked = True

        Else
            txtInformeRelativo.Enabled = False
            txtInformeRelativo.ReadOnly = True
            txtInformeRelativo.Text = ""

            cboOpinion.DataSource = LlenarCombo(2)
            cboOpinion.DisplayMember = "sOpcion"
            cboOpinion.ValueMember = "idOpcion"

            gpBoxRespuesta.Enabled = True
            txtArchivo.Enabled = True
            rdSi.Checked = True

        End If
    End Sub
    Private Sub CboOpinion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboOpinion.SelectionChangeCommitted
        If cboOpinion.SelectedValue = 2 Then
            txtOpinionDetalle.Enabled = True
            txtOpinionDetalle.ReadOnly = False
            txtOpinionDetalle.Focus()
        Else
            txtOpinionDetalle.Enabled = False
            txtOpinionDetalle.ReadOnly = True
            txtOpinionDetalle.Text = ""
        End If
    End Sub
    Private Sub CboBasadoEn_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboBasadoEn.SelectionChangeCommitted
        If cboBasadoEn.SelectedValue = 7 Then
            txtBasadoDetalle.Enabled = True
            txtBasadoDetalle.ReadOnly = False
            txtBasadoDetalle.Focus()
        Else
            txtBasadoDetalle.Enabled = False
            txtBasadoDetalle.ReadOnly = True
            txtBasadoDetalle.Text = ""
        End If
    End Sub
    Private Sub CboIdioma_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboIdioma.SelectionChangeCommitted
        If cboIdioma.SelectedValue = 4 Then
            txtIdiomaOtro.Enabled = True
            txtIdiomaOtro.ReadOnly = False
            txtIdiomaOtro.Focus()
        Else
            txtIdiomaOtro.Enabled = False
            txtIdiomaOtro.ReadOnly = True
            txtIdiomaOtro.Text = ""
        End If
    End Sub
    Private Sub RdSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdSi.CheckedChanged
        If rdSi.Checked Then
            txtArchivo.Enabled = False
            txtArchivo.ReadOnly = True

            If txtArchivo.TextLength > 0 Then
                txtArchivo.Text = ""
            End If
        End If
    End Sub
    Private Sub RdNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdNo.CheckedChanged
        If rdNo.Checked Then
            txtArchivo.Enabled = True
            txtArchivo.ReadOnly = False
        End If
    End Sub

    Private Sub ListarCombo(combo As ComboBox, id As Integer)
        combo.DataSource = LlenarCombo(id)
        combo.DisplayMember = "sOpcion"
        combo.ValueMember = "idOpcion"
    End Sub
    'Private Sub LlenarCombos()
    '    dt.Columns.Add("idOpcion", GetType(Integer))
    '    dt.Columns.Add("sOpcion", GetType(System.String))
    '    dt.Columns.Add("bHabilitar", GetType(Boolean))

    '    dtInf = dt.Clone
    '    dtOpi = dt.Clone
    '    dtBas = dt.Clone
    '    dtIdi = dt.Clone

    '    'Informes
    '    drInf = dtInf.NewRow
    '    drInf("idOpcion") = 1
    '    drInf("sOpcion") = "Opinión financiera"
    '    drInf("bHabilitar") = False
    '    dtInf.Rows.InsertAt(drInf, dtInf.Rows.Count)

    '    drInf = dtInf.NewRow
    '    drInf("idOpcion") = 2
    '    drInf("sOpcion") = "Opinión fiscal"
    '    drInf("bHabilitar") = False
    '    dtInf.Rows.InsertAt(drInf, dtInf.Rows.Count)

    '    drInf = dtInf.NewRow
    '    drInf("idOpcion") = 3
    '    drInf("sOpcion") = "Otras opiniones"
    '    drInf("bHabilitar") = True
    '    dtInf.Rows.InsertAt(drInf, dtInf.Rows.Count)

    '    'Opiniones
    '    drOpi = dtOpi.NewRow
    '    drOpi("idOpcion") = 1
    '    drOpi("sOpcion") = "Abstención"
    '    drOpi("bHabilitar") = False
    '    dtOpi.Rows.InsertAt(drOpi, dtOpi.Rows.Count)

    '    drOpi = dtOpi.NewRow
    '    drOpi("idOpcion") = 2
    '    drOpi("sOpcion") = "Con salvedad"
    '    drOpi("bHabilitar") = True
    '    dtOpi.Rows.InsertAt(drOpi, dtOpi.Rows.Count)

    '    drOpi = dtOpi.NewRow
    '    drOpi("idOpcion") = 3
    '    drOpi("sOpcion") = "Negativa"
    '    drOpi("bHabilitar") = False
    '    dtOpi.Rows.InsertAt(drOpi, dtOpi.Rows.Count)

    '    drOpi = dtOpi.NewRow
    '    drOpi("idOpcion") = 4
    '    drOpi("sOpcion") = "Sin salvedad"
    '    drOpi("bHabilitar") = False
    '    dtOpi.Rows.InsertAt(drOpi, dtOpi.Rows.Count)

    '    'Basado en
    '    drBas = dtBas.NewRow
    '    drBas("idOpcion") = 1
    '    drBas("sOpcion") = "Criterios de la CNBV"
    '    drBas("bHabilitar") = False
    '    dtBas.Rows.InsertAt(drBas, dtBas.Rows.Count)

    '    drBas = dtBas.NewRow
    '    drBas("idOpcion") = 2
    '    drBas("sOpcion") = "Criterios de la CNSF"
    '    drBas("bHabilitar") = False
    '    dtBas.Rows.InsertAt(drBas, dtBas.Rows.Count)

    '    drBas = dtBas.NewRow
    '    drBas("idOpcion") = 3
    '    drBas("sOpcion") = "LGSM / Comisario"
    '    drBas("bHabilitar") = False
    '    dtBas.Rows.InsertAt(drBas, dtBas.Rows.Count)

    '    drBas = dtBas.NewRow
    '    drBas("idOpcion") = 4
    '    drBas("sOpcion") = "Normas de información financiera mexicana (NIF)"
    '    drBas("bHabilitar") = False
    '    dtBas.Rows.InsertAt(drBas, dtBas.Rows.Count)

    '    drBas = dtBas.NewRow
    '    drBas("idOpcion") = 5
    '    drBas("sOpcion") = "Normas internacionales de información financiera (NIIF)"
    '    drBas("bHabilitar") = False
    '    dtBas.Rows.InsertAt(drBas, dtBas.Rows.Count)

    '    drBas = dtBas.NewRow
    '    drBas("idOpcion") = 6
    '    drBas("sOpcion") = "Normas gubernamentales"
    '    drBas("bHabilitar") = False
    '    dtBas.Rows.InsertAt(drBas, dtBas.Rows.Count)

    '    drBas = dtBas.NewRow
    '    drBas("idOpcion") = 7
    '    drBas("sOpcion") = "Otros"
    '    drBas("bHabilitar") = True
    '    dtBas.Rows.InsertAt(drBas, dtBas.Rows.Count)

    '    drBas = dtBas.NewRow
    '    drBas("idOpcion") = 8
    '    drBas("sOpcion") = "USGAAP"
    '    drBas("bHabilitar") = False
    '    dtBas.Rows.InsertAt(drBas, dtBas.Rows.Count)

    '    'Idiomas
    '    drIdi = dtIdi.NewRow
    '    drIdi("idOpcion") = 1
    '    drIdi("sOpcion") = "Español"
    '    drIdi("bHabilitar") = False
    '    dtIdi.Rows.InsertAt(drIdi, dtIdi.Rows.Count)

    '    drIdi = dtIdi.NewRow
    '    drIdi("idOpcion") = 2
    '    drIdi("sOpcion") = "Inglés"
    '    drIdi("bHabilitar") = False
    '    dtIdi.Rows.InsertAt(drIdi, dtIdi.Rows.Count)

    '    drIdi = dtIdi.NewRow
    '    drIdi("idOpcion") = 3
    '    drIdi("sOpcion") = "Francés"
    '    drIdi("bHabilitar") = False
    '    dtIdi.Rows.InsertAt(drIdi, dtIdi.Rows.Count)

    '    drIdi = dtIdi.NewRow
    '    drIdi("idOpcion") = 4
    '    drIdi("sOpcion") = "Otro"
    '    drIdi("bHabilitar") = True
    '    dtIdi.Rows.InsertAt(drIdi, dtIdi.Rows.Count)

    '    cboInforme.DataSource = dtInf
    '    cboInforme.ValueMember = "idOpcion"
    '    cboInforme.DisplayMember = "sOpcion"

    '    cboOpinion.DataSource = dtOpi
    '    cboOpinion.ValueMember = "idOpcion"
    '    cboOpinion.DisplayMember = "sOpcion"

    '    cboBasadoEn.DataSource = dtBas
    '    cboBasadoEn.ValueMember = "idOpcion"
    '    cboBasadoEn.DisplayMember = "sOpcion"

    '    cboIdioma.DataSource = dtIdi
    '    cboIdioma.ValueMember = "idOpcion"
    '    cboIdioma.DisplayMember = "sOpcion"
    'End Sub
    Private Sub ListarPreguntas()
        Try
            Dim sTabla As String = "tbPreguntas"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paFoliosInforme", sTabla))

                dtPreguntas = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarPreguntas()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtPreguntas = Nothing
        End Try
    End Sub
    Private Sub ListarCobranza(sCveTra As String)
        Try
            Dim sTabla As String = "tbCobranzaCve"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@dFechaInicio", dFechaInicio, SqlDbType.Date, ParameterDirection.Input)
                    .subAddParameter("@dFechaFinal", Date.Now.ToShortDateString, SqlDbType.Date, ParameterDirection.Input)
                    .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paFoliosInforme", sTabla))

                dtCob = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarCobranza()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtCob = Nothing
        End Try
    End Sub
    Private Sub ListarHonorarios(sCveTra As String)
        Try
            Dim sTabla As String = "tbHonorariosCve"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 10, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paFoliosInforme", sTabla))

                dtHon = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarHonorarios()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtHon = Nothing
        End Try
    End Sub
    Private Sub GenerarFolioInforme()
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@cStatus", "A", SqlDbType.Char, ParameterDirection.Input, 1)
                .subAddParameter("@sMotivoBaja", "", SqlDbType.VarChar, ParameterDirection.Input, 2000)
                .subAddParameter("@sCveSocio", sCveSocio, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sCveGerente", sCveGer, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sCveTra", txtTrabajo.Text, SqlDbType.VarChar, ParameterDirection.Input, 20)
                .subAddParameter("@sClienteRelacionado", txtCteRelacionado.Text, SqlDbType.VarChar, ParameterDirection.Input, 2000)
                .subAddParameter("@dFechaPeriodoInf", txtFechaPeriodo.Value, SqlDbType.Date, ParameterDirection.Input)
                .subAddParameter("@dFechaInforme", txtFechaInforme.Value, SqlDbType.Date, ParameterDirection.Input)
                .subAddParameter("@iInforme", cboInforme.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sInformeRelativo", txtInformeRelativo.Text, SqlDbType.VarChar, ParameterDirection.Input, 2000)
                .subAddParameter("@iOpinion", cboOpinion.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sOpinionDetalle", txtOpinionDetalle.Text, SqlDbType.VarChar, ParameterDirection.Input, 2000)
                .subAddParameter("@iBasadoEn", cboBasadoEn.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sBasadoDetalle", txtBasadoDetalle.Text, SqlDbType.VarChar, ParameterDirection.Input, 2000)
                .subAddParameter("@iIdioma", cboIdioma.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sIdiomaOtro", txtIdiomaOtro.Text, SqlDbType.VarChar, ParameterDirection.Input, 2000)
                If rdSi.Checked Then
                    .subAddParameter("@cArchivo", "S", SqlDbType.Char, ParameterDirection.Input, 1)
                ElseIf rdNo.Checked Then
                    .subAddParameter("@cArchivo", "N", SqlDbType.Char, ParameterDirection.Input, 1)
                End If
                .subAddParameter("@sArchivo", txtArchivo.Text, SqlDbType.VarChar, ParameterDirection.Input, 2000)
                .subAddParameter("@sUsuarioAlta", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@iFolio", 0, SqlDbType.Int, ParameterDirection.Output)

                .funExecuteSP("paFoliosInforme")
            End With

            idFolio = clsDatos.funGetParameterValue("@iFolio")
            txtFolio.Text = CrearFolio(idFolio)

            MsgBox("Se generó el folio de informe correctamente.", MsgBoxStyle.Information, "SIAT")

            gpBoxDatos.Enabled = False
            gpBoxDatosInforme.Enabled = False

            btnGenerarFolio.Enabled = False
            btnCopiarFolio.Enabled = True
            'DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "GenerarFolioInforme()")
            MsgBox("Hubo un inconveniente al registrar la información del folio de informe, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub

    Private Function CrearFolio(id As Integer) As String
        Dim sFolio As String

        ' sFolio = sCveOfi & "-" & sCveArea & "-" & iAñoActual.ToString.Substring(2, 2) & "-" & AgregarCeros(id)

        Return sFolio
    End Function
    Private Function AgregarCeros(id As Integer) As String
        Dim sFolio As String

        Select Case id.ToString.Length
            Case 1
                sFolio = "0000" & id
            Case 2
                sFolio = "000" & id
            Case 3
                sFolio = "00" & id
            Case 4
                sFolio = "0" & id
            Case Else
                sFolio = id.ToString
        End Select

        Return sFolio
    End Function
    Private Function ValidarForma() As Boolean
        Dim bValida As Boolean = True

        If txtTrabajo.TextLength = 0 Then
            MsgBox("Seleccione una clave de trabajo.", MsgBoxStyle.Exclamation, "SIAT")
            btnBuscar.Focus()
            Return False
        End If

        If cboInforme.SelectedItem("bHabilitar") And txtInformeRelativo.TextLength = 0 Then
            MsgBox("Escriba el motivo del concepto 'Relativo a'.", MsgBoxStyle.Exclamation, "SIAT")
            txtInformeRelativo.Focus()
            Return False
        End If

        If cboOpinion.SelectedItem("bHabilitar") And txtOpinionDetalle.TextLength = 0 Then
            MsgBox("Escriba el motivo del concepto 'Detalle' de 'Opinión'.", MsgBoxStyle.Exclamation, "SIAT")
            txtOpinionDetalle.Focus()
            Return False
        End If

        If cboBasadoEn.SelectedItem("bHabilitar") And txtBasadoDetalle.TextLength = 0 Then
            MsgBox("Escriba el motivo del concepto 'Detalle' de 'Basado en'.", MsgBoxStyle.Exclamation, "SIAT")
            txtBasadoDetalle.Focus()
            Return False
        End If

        If cboIdioma.SelectedItem("bHabilitar") And txtIdiomaOtro.TextLength = 0 Then
            MsgBox("Escriba el nombre del idioma.", MsgBoxStyle.Exclamation, "SIAT")
            txtIdiomaOtro.Focus()
            Return False
        End If

        If rdNo.Checked And txtArchivo.TextLength = 0 And sCveArea <> "PLD" Then
            MsgBox("Escriba el nombre del archivo Voyager.", MsgBoxStyle.Exclamation, "SIAT")
            txtArchivo.Focus()
            Return False
        End If

        If txtCteRelacionado.Text = "" Then
            MsgBox("Escriba del cliente relacionado ó el cliente relacionado al grupo.", MsgBoxStyle.Exclamation, "SIAT")
            txtArchivo.Focus()
            Return False
        End If

        Return bValida
    End Function
    Private Function LlenarCombo(id As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr(), drFila As DataRow

        Try
            dt.Columns.Add("idOpcion", GetType(String))
            dt.Columns.Add("sOpcion", GetType(String))
            dt.Columns.Add("bHabilitar", GetType(Boolean))

            dr = dtPreguntas.Select("idOpcion NOT IN (5,6,7,8,9) AND  iPregunta = " & id)

            If dr.Count > 0 Then
                For f As Integer = 0 To dr.Count - 1
                    drFila = dt.NewRow
                    drFila("idOpcion") = dr(f).Item("idOpcion")
                    drFila("sOpcion") = dr(f).Item("sOpcion")
                    drFila("bHabilitar") = IIf(dr(f).Item("bHabilitar") = "F", False, True)
                    dt.Rows.InsertAt(drFila, dt.Rows.Count)
                Next
            Else
                dt = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(201, sNameRpt, ex.Message, sCveUsuario, "LlenarCombo()")
        End Try

        Return dt
    End Function
    Private Function LlenarComboPLD(id As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr(), drFila As DataRow

        Try
            dt.Columns.Add("idOpcion", GetType(String))
            dt.Columns.Add("sOpcion", GetType(String))
            dt.Columns.Add("bHabilitar", GetType(Boolean))

            dr = dtPreguntas.Select("idOpcion IN (5,6,7,8,9) AND iPregunta = " & id)

            If dr.Count > 0 Then
                For f As Integer = 0 To dr.Count - 1
                    drFila = dt.NewRow
                    drFila("idOpcion") = dr(f).Item("idOpcion")
                    drFila("sOpcion") = dr(f).Item("sOpcion")
                    drFila("bHabilitar") = IIf(dr(f).Item("bHabilitar") = "F", False, True)
                    dt.Rows.InsertAt(drFila, dt.Rows.Count)
                Next
            Else
                dt = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(201, sNameRpt, ex.Message, sCveUsuario, "LlenarCombo()")
        End Try

        Return dt
    End Function
    'Private Sub linkAutoriza_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkAutoriza.LinkClicked

    '    If sCveTra <> "" Then
    '        GuardaSolicitudAutorizacion()
    '    Else
    '        MsgBox("Debes seleccionar una clave de trabajo.", MsgBoxStyle.Information, "SIAT")
    '    End If

    'End Sub

    Private Sub ListarSolicitudes(sCveTra As String)
        Try
            Dim sTabla As String = "tbSolicitudes"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 14, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paFoliosInforme", sTabla))

                dtSolicitudes = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSolicitudes()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtSolicitudes = Nothing
        End Try
    End Sub
    Private Sub ValidaExistanSolicitudes(sCveTra As String)
        Try
            Dim sTabla As String = "tbValida"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 18, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paFoliosInforme", sTabla))

                dtValidaSol = .Item(sTabla)

                If dtValidaSol.Rows.Count > 0 Then
                    idsol = dtValidaSol.Rows(0).Item("IDSOL").ToString
                End If

            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ValidaExistanSolicitudes()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtValidaSol = Nothing
        End Try
    End Sub
    Private Sub ActualizaSolcitudFolio()
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 19, SqlDbType.Int, ParameterDirection.Input)

                .subAddParameter("@sCveTra", txtTrabajo.Text, SqlDbType.VarChar, ParameterDirection.Input, 20)
                .subAddParameter("@iIdsol", idsol, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iIdFolio", idFolio, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paFoliosInforme")
            End With

        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizaSolcitudFolio()")
            MsgBox("Hubo un inconveniente al registrar la información del folio de informe, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub EnviarCorreoAviso() 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sCorreo(), sCorreos, sMensaje As String

        Try
            sCorreos = "pablo.c.chavez@mx.gt.com" & "," & "Julio.C.Xicotencatl@mx.gt.com" & "," & "Practica.Profesional@mx.gt.com"
            'sCorreos = "Octavio.A.Cervantes@mx.gt.com, Mario.Rodriguez@mx.gt.com"
            sCorreo = sCorreos.Split(",")

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">SOLICITUD PARA FOLIO DE INFORME</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado(a) equipo ,</p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">El presente correo es para informarte que se ha generado una solicitud para autorizar la creación de un folio de informe: </p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtCliente.Text.ToUpper.ToString & "</b></td></tr>" & vbNewLine &
            "<tr><td>Cliente relacionado:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtCteRelacionado.Text.ToUpper.ToString & "</b></td></tr>" & vbNewLine &
            "<tr><td>Registrado por:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sNombreUsuario & "</b></td></tr>" & vbNewLine &
            "<tr><td>Informe:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & cboInforme.SelectedText.ToUpper() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Fecha del periodo del informe:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtFechaPeriodo.Value & "</b></td></tr>" & vbNewLine &
            "<tr><td>Fecha del informe:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & txtFechaInforme.Value & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para revisar y validar esta solicitud, ingresa al sistema SIAT, menú SAPYC > Autorización de Folios de Informe." & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Solicitud de Autorización para Folio de Informe")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub

End Class