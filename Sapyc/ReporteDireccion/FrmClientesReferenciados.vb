Public Class frmClientesReferenciados

#Region "VARIABLES"

    Private bsN, bsR As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "CLIENTES RECURRENTES"

    Private dtCtesNuevos, dtCtesRecu As New DataTable
    Private dtPermisosSoc, dtPermisosEnc, dtConcilSoc, dtConcilIni, dtConcilEnc As New DataTable
    Private dtFacturaNormal, dtCan, dtCanRes, dtCancelaciones, dtDiferencias, dtAjustesGastos, dtTrabajos, dtCtesNueFacturacion, dtCtesRecFacturacion As New DataTable
    Private dtFIDe, dtFIA, dtTFDe, dtTFA As New DataTable
    Private drN, drR As DataRow

    Private sNameBD As String
    Private bBDActivo As Boolean
    Private idBD As Integer
    Public dFechaInicio, dFechaFinal As Date

    Private dFacturacion, dFacturaNormal, dCancelacion, dDiferencias, dFacturaInterna, dTraspasoFactura, dAjustesGastos As Double

#End Region

#Region "EVENTOS"
    Private Sub frmClientesReferenciados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Creartablas()

        dgCteNuevo.DataSource = bsN
        dgCteRef.DataSource = bsR

        If Now.Date >= "01/08/" & iAñoActAn Then
            txtFechaDe.Value = "01/08/" & iAñoActAn
        Else
            txtFechaDe.Value = "01/08/" & iAñoActAn - 1
        End If

        dtPermisosEnc = ListarPermisosUsuariosRD(sCveUsuario, "A")
        dtPermisosSoc = ListarPermisosUsuariosRD(sCveUsuario, "S")

        crearTablasEncargado()
        crearTablaSocio()
        crearTablaConciliacionIni()

        rdSocioEncargado.Checked = True
        gpBoxTipoReporte.Enabled = True
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        If txtFechaDe.Value > txtFechaA.Value Then
            MsgBox("El rango de fechas seleccionado no mostrará información, por favor verifique las fechas.", MsgBoxStyle.Exclamation, "Fechas incorrectas")
            Exit Sub
        End If

        dFechaInicio = txtFechaDe.Value
        dFechaFinal = txtFechaA.Value

        idBD = obtenerIdBD(dFechaFinal)
        bBDActivo = obtenerActivoBD(idBD)
        If obtenerMes(dFechaFinal) <= 5 Then
            sNameBD = obtenerNombreBD(idBD, 1)
        Else
            sNameBD = obtenerNombreBD(idBD, 2)
        End If
        If bBDActivo Then
            actualizarFacturacionSocio(sNameBD, dFechaFinal.Year, dFechaFinal.Month, idBD)
            actualizarRSNMovtosFactura(sNameBD, dFechaFinal.Year, dFechaFinal.Month, idBD)
            actualizarDiferenciasTC(dFechaFinal.Year, dFechaFinal.Month, idBD)
            actualizarMovtos(dFechaInicio, dFechaFinal, idBD)
            actualizarAjustesGastos(dFechaFinal.Year, dFechaFinal.Month, idBD)
        End If
        ListarFacturacionNormal()
        If dtFacturaNormal Is Nothing Then
            Exit Sub
        End If
        ListarCancelaciones()
        If dtCan Is Nothing Then
            Exit Sub
        End If
        ListarCancelacionesReserva()
        If dtCanRes Is Nothing Then
            Exit Sub
        End If
        ListarDiferencias()
        If dtDiferencias Is Nothing Then
            Exit Sub
        End If

        dtFIDe = ObtenerMovtos("FI", 2)
        dtFIA = ObtenerMovtos("FI", 1)
        dtTFDe = ObtenerMovtos("FT", 1)
        dtTFA = ObtenerMovtos("FT", 2)

        ListarAjustesGastos()
        If dtAjustesGastos Is Nothing Then
            Exit Sub
        End If

        ListarCteNuevos()
        ListarCteRecurrentes()
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim dlg As New dlgExcel
        Try
            If MsgBox("¿Desea exportar la información a Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Envío Excel") = MsgBoxResult.Yes Then
                dlg.txtArchivo.Focus()
                dlg.txtArchivo.Text = "Clientes Referenciados"
                If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                    exportarClientesReferenciados(Cuadro, dlg.txtDirectorio.Text, dlg.txtArchivo.Text)
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

#End Region

#Region "METODOS"

    Private Sub Creartablas()
        dtCtesNueFacturacion.Columns.Add("TIPO", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("IDPROP", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("SOCIO", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("GERENTE", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("IDSTATUS", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("CVEEMPREF", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("TIPOPROPUESTA", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("IDCOMOSE", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("CVETRA", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("NOMEMPRESA", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("NOMSOCIO", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("NOMGERENTE", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("HONORARIOS", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("IMPFACT", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("STATUS", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("COMOSEENTERO", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("REGISTRADAEL", GetType(System.String))
        dtCtesNueFacturacion.Columns.Add("NOMBEMPREF", GetType(System.String))

        dtCtesRecFacturacion.Columns.Add("TIPO", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("IDPROP", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("SOCIO", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("GERENTE", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("TIPOPROPUESTA", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("IDSTATUS", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("IDCOMOSE", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("CVEEMPREF", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("CVETRA", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("NOMEMPRESA", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("NOMSOCIO", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("NOMGERENTE", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("HONORARIOS", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("IMPFACT", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("STATUS", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("COMOSEENTERO", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("REGISTRADAEL", GetType(System.String))
        dtCtesRecFacturacion.Columns.Add("NOMBEMPREF", GetType(System.String))
    End Sub

    Private Sub crearTablaSocio()
        dtConcilSoc.Columns.Add("TIPO", GetType(System.String))
        dtConcilSoc.Columns.Add("ID", GetType(System.String))
        dtConcilSoc.Columns.Add("CONCEPTO", GetType(System.String))
        For Each row As DataRow In dtPermisosSoc.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                Continue For
            End If

            dtConcilSoc.Columns.Add(row.Item("CVEOFI") & "-" & row.Item("CVEAREA"), GetType(System.String))
        Next
        dtConcilSoc.Columns.Add("TOTAL", GetType(System.String))
    End Sub
    Private Sub crearTablaConciliacionIni()
        dtConcilIni.Columns.Add("TIPO", GetType(System.String))
        dtConcilIni.Columns.Add("IDCLAS", GetType(System.String))
        dtConcilIni.Columns.Add("TIPOTRA", GetType(System.String))
        dtConcilIni.Columns.Add("CVEOFI", GetType(System.String))
        dtConcilIni.Columns.Add("CVEAREA", GetType(System.String))
        dtConcilIni.Columns.Add("CVECTE", GetType(System.String))
        dtConcilIni.Columns.Add("SOCIO", GetType(System.String))
        dtConcilIni.Columns.Add("NOMBRESOC", GetType(System.String))
        dtConcilIni.Columns.Add("CVETRA", GetType(System.String))
        dtConcilIni.Columns.Add("NOMBRECTE", GetType(System.String))
        dtConcilIni.Columns.Add("DESCRIPCION", GetType(System.String))
        dtConcilIni.Columns.Add("TIPOCTE", GetType(System.String))
        dtConcilIni.Columns.Add("DESCOFI", GetType(System.String))
        dtConcilIni.Columns.Add("DESCAREA", GetType(System.String))
        dtConcilIni.Columns.Add("STATUS", GetType(System.String))
        dtConcilIni.Columns.Add("FECHA", GetType(System.String))

        dtConcilIni.Columns.Add("SEPUNO", GetType(System.String))

        'Facturación real del socio.
        dtConcilIni.Columns.Add("IMPFAC", GetType(System.String))
        dtConcilIni.Columns.Add("PPTOFACTER", GetType(System.String))
        dtConcilIni.Columns.Add("PPTOFACINT", GetType(System.String))
        dtConcilIni.Columns.Add("PPTOFACTRA", GetType(System.String))
        dtConcilIni.Columns.Add("PPTOFACNET", GetType(System.String))
        dtConcilIni.Columns.Add("PORWO", GetType(System.String))
        dtConcilIni.Columns.Add("PPTOWO", GetType(System.String))
        dtConcilIni.Columns.Add("IMPNETO", GetType(System.String))
        dtConcilIni.Columns.Add("IMPVAR", GetType(System.String))

        dtConcilIni.Columns.Add("SEPDOS", GetType(System.String))

        dtConcilIni.Columns.Add("IMPGAN", GetType(System.String))
        dtConcilIni.Columns.Add("IMPGANTRANS", GetType(System.String))
        dtConcilIni.Columns.Add("SOCIOTRANSDE", GetType(System.String))
        dtConcilIni.Columns.Add("IMPCAN", GetType(System.String))
        dtConcilIni.Columns.Add("IMPINC", GetType(System.String))

        dtConcilIni.Columns.Add("SEPTRES", GetType(System.String))

        dtConcilIni.Columns.Add("IMPDEC", GetType(System.String))
        dtConcilIni.Columns.Add("IMPPER", GetType(System.String))
        dtConcilIni.Columns.Add("MOTIVOPER", GetType(System.String))
        dtConcilIni.Columns.Add("IMPPERTRANS", GetType(System.String))
        dtConcilIni.Columns.Add("SOCIOTRANSA", GetType(System.String))
        dtConcilIni.Columns.Add("MOTIVOTRANSA", GetType(System.String))
        dtConcilIni.Columns.Add("TOTAL", GetType(System.String))
        dtConcilIni.Columns.Add("CVESOCTRANSDE", GetType(System.String))
        dtConcilIni.Columns.Add("CVESOCTRANSA", GetType(System.String))

        dtConcilIni.Columns.Add("IMPFNPPTO", GetType(System.String))
    End Sub
    Private Sub crearTablasEncargado()
        dtConcilEnc.Columns.Add("TIPO", GetType(System.String))
        dtConcilEnc.Columns.Add("ID", GetType(System.String))
        dtConcilEnc.Columns.Add("CONCEPTO", GetType(System.String))
        For Each row As DataRow In dtPermisosEnc.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                Continue For
            End If

            dtConcilEnc.Columns.Add(row.Item("CVEOFI") & "-" & row.Item("CVEAREA"), GetType(System.String))
        Next
        dtConcilEnc.Columns.Add("TOTAL", GetType(System.String))
    End Sub

    Private Sub formatoNuevas()
        dgCteNuevo.Columns("TIPO").Visible = False
        dgCteNuevo.Columns("IDPROP").Visible = False
        dgCteNuevo.Columns("SOCIO").Visible = False
        dgCteNuevo.Columns("GERENTE").Visible = False
        dgCteNuevo.Columns("IDSTATUS").Visible = False
        dgCteNuevo.Columns("IDCOMOSE").Visible = False
        dgCteNuevo.Columns("CVEEMPREF").Visible = False
        dgCteNuevo.Columns("TIPOPROPUESTA").Visible = False

        dgCteNuevo.Columns("CVETRA").HeaderText = "CVE."
        dgCteNuevo.Columns("CVETRA").Width = 150
        dgCteNuevo.Columns("NOMEMPRESA").HeaderText = "CLIENTE"
        dgCteNuevo.Columns("NOMEMPRESA").Width = 200
        dgCteNuevo.Columns("NOMSOCIO").HeaderText = "SOCIO"
        dgCteNuevo.Columns("NOMSOCIO").Width = 250
        dgCteNuevo.Columns("NOMGERENTE").HeaderText = "GERENTE"
        dgCteNuevo.Columns("NOMGERENTE").Width = 250
        dgCteNuevo.Columns("HONORARIOS").HeaderText = "HONORARIOS"
        dgCteNuevo.Columns("HONORARIOS").Width = 120
        dgCteNuevo.Columns("HONORARIOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgCteNuevo.Columns("IMPFACT").HeaderText = "IMP. FACTURACIÓN"
        dgCteNuevo.Columns("IMPFACT").Width = 120
        dgCteNuevo.Columns("IMPFACT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgCteNuevo.Columns("STATUS").HeaderText = "STATUS"
        dgCteNuevo.Columns("STATUS").Width = 180
        dgCteNuevo.Columns("COMOSEENTERO").HeaderText = "¿CÓMO SE ENTERÓ?"
        dgCteNuevo.Columns("COMOSEENTERO").Width = 250
        dgCteNuevo.Columns("REGISTRADAEL").HeaderText = "FECHA ALTA"
        dgCteNuevo.Columns("REGISTRADAEL").Width = 120
        dgCteNuevo.Columns("NOMBEMPREF").HeaderText = "SOCIO QUE REFERENCIÓ"
        dgCteNuevo.Columns("NOMBEMPREF").Width = 250
    End Sub
    Private Sub formatoRecurrentes()
        dgCteRef.Columns("TIPO").Visible = False
        dgCteRef.Columns("IDPROP").Visible = False
        dgCteRef.Columns("SOCIO").Visible = False
        dgCteRef.Columns("GERENTE").Visible = False
        dgCteRef.Columns("IDSTATUS").Visible = False
        dgCteRef.Columns("IDCOMOSE").Visible = False
        dgCteRef.Columns("CVEEMPREF").Visible = False
        dgCteRef.Columns("TIPOPROPUESTA").Visible = False

        dgCteRef.Columns("CVETRA").HeaderText = "CVE."
        dgCteRef.Columns("CVETRA").Width = 150
        dgCteRef.Columns("NOMEMPRESA").HeaderText = "CLIENTE"
        dgCteRef.Columns("NOMEMPRESA").Width = 200
        dgCteRef.Columns("NOMSOCIO").HeaderText = "SOCIO"
        dgCteRef.Columns("NOMSOCIO").Width = 250
        dgCteRef.Columns("NOMGERENTE").HeaderText = "GERENTE"
        dgCteRef.Columns("NOMGERENTE").Width = 250
        dgCteRef.Columns("HONORARIOS").HeaderText = "HONORARIOS"
        dgCteRef.Columns("HONORARIOS").Width = 120
        dgCteRef.Columns("HONORARIOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgCteRef.Columns("IMPFACT").HeaderText = "IMP. FACTURACIÓN"
        dgCteRef.Columns("IMPFACT").Width = 120
        dgCteRef.Columns("IMPFACT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgCteRef.Columns("STATUS").HeaderText = "STATUS"
        dgCteRef.Columns("STATUS").Width = 180
        dgCteRef.Columns("COMOSEENTERO").HeaderText = "¿CÓMO SE ENTERÓ?"
        dgCteRef.Columns("COMOSEENTERO").Width = 250
        dgCteRef.Columns("REGISTRADAEL").HeaderText = "FECHA ALTA"
        dgCteRef.Columns("REGISTRADAEL").Width = 120
        dgCteRef.Columns("NOMBEMPREF").HeaderText = "SOCIO QUE REFERENCIÓ"
        dgCteRef.Columns("NOMBEMPREF").Width = 250
    End Sub

    Private Sub ListarCteNuevos()
        Try
            LimpiarTabla(dtCtesNueFacturacion)

            Dim sTabla As String = "tbCteNuevos"

            For Each Dr As DataRow In dtPermisosEnc.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With ds.Tables
                        If .Contains(sTabla) Then
                            .Remove(sTabla)
                        End If

                        With clsDatos
                            .subClearParameters()
                            .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                            '.subAddParameter("@sCveSocio", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                            .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                            .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                            '.subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)

                        End With

                        .Add(clsDatos.funExecuteSPDataTable("paSAPYCClientesReferenciados", sTabla))

                        dtCtesNuevos = .Item(sTabla)

                        If dtCtesNuevos.Rows.Count > 0 Then
                            For Each r As DataRow In dtCtesNuevos.Rows
                                If r.Item("CVETRA").ToString = "" Then
                                    dFacturacion = 0.0
                                Else
                                    dFacturacion = ObtenerFacturacionCve(r.Item("CVETRA").ToString)
                                End If

                                drN = dtCtesNueFacturacion.NewRow
                                drN("TIPO") = "S"
                                drN("IDPROP") = r.Item("IDPROP").ToString
                                drN("CVETRA") = r.Item("CVETRA").ToString
                                drN("NOMEMPRESA") = r.Item("NOMEMPRESA").ToString
                                drN("SOCIO") = r.Item("SOCIO").ToString
                                drN("NOMSOCIO") = r.Item("NOMSOCIO").ToString
                                drN("SOCIO") = r.Item("SOCIO").ToString
                                drN("GERENTE") = r.Item("GERENTE").ToString
                                drN("NOMGERENTE") = r.Item("NOMGERENTE").ToString
                                drN("HONORARIOS") = Format(CDbl(r.Item("HONORARIOS").ToString), sFmtDbl)
                                drN("IMPFACT") = Format(dFacturacion, sFmtDbl)
                                drN("IDSTATUS") = r.Item("IDSTATUS").ToString
                                drN("STATUS") = r.Item("STATUS").ToString
                                drN("IDCOMOSE") = r.Item("IDCOMOSE").ToString
                                drN("COMOSEENTERO") = r.Item("COMOSEENTERO")
                                drN("REGISTRADAEL") = r.Item("REGISTRADAEL").ToString
                                drN("CVEEMPREF") = r.Item("CVEEMPREF").ToString
                                drN("NOMBEMPREF") = r.Item("NOMBEMPREF").ToString
                                dtCtesNueFacturacion.Rows.InsertAt(drN, dtCtesNueFacturacion.Rows.Count)


                            Next
                        End If
                    End With

                End With
            Next
            dgCteNuevo.DataSource = dtCtesNueFacturacion
            formatoNuevas()

        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "tbCteNuevos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtCtesNuevos = Nothing
        End Try
    End Sub
    Private Sub ListarCteRecurrentes()
        Try
            LimpiarTabla(dtCtesRecFacturacion)

            Dim sTabla As String = "tbCteRecu"

            For Each Dr As DataRow In dtPermisosEnc.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If


                    With ds.Tables
                        If .Contains(sTabla) Then
                            .Remove(sTabla)
                        End If

                        With clsDatos
                            .subClearParameters()
                            .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                            '.subAddParameter("@sCveSocio", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                            .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                            .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                            '.subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)

                        End With

                        .Add(clsDatos.funExecuteSPDataTable("paSAPYCClientesReferenciados", sTabla))

                        dtCtesRecu = .Item(sTabla)

                        If dtCtesRecu.Rows.Count > 0 Then
                            For Each r As DataRow In dtCtesRecu.Rows
                                If r.Item("CVETRA").ToString = "" Then
                                    dFacturacion = 0.0
                                Else
                                    dFacturacion = ObtenerFacturacionCve(r.Item("CVETRA").ToString)
                                End If

                                drR = dtCtesRecFacturacion.NewRow
                                drR("TIPO") = "S"
                                drR("IDPROP") = r.Item("IDPROP").ToString
                                drR("CVETRA") = r.Item("CVETRA").ToString
                                drR("NOMEMPRESA") = r.Item("NOMEMPRESA").ToString
                                drR("SOCIO") = r.Item("SOCIO").ToString
                                drR("NOMSOCIO") = r.Item("NOMSOCIO").ToString
                                drR("SOCIO") = r.Item("SOCIO").ToString
                                drR("GERENTE") = r.Item("GERENTE").ToString
                                drR("NOMGERENTE") = r.Item("NOMGERENTE").ToString
                                drR("HONORARIOS") = Format(CDbl(r.Item("HONORARIOS").ToString), sFmtDbl)
                                drR("IMPFACT") = Format(dFacturacion, sFmtDbl)
                                drR("IDSTATUS") = r.Item("IDSTATUS").ToString
                                drR("STATUS") = r.Item("STATUS").ToString
                                drR("IDCOMOSE") = r.Item("IDCOMOSE").ToString
                                drR("COMOSEENTERO") = r.Item("COMOSEENTERO")
                                drR("REGISTRADAEL") = r.Item("REGISTRADAEL").ToString
                                drR("CVEEMPREF") = r.Item("CVEEMPREF").ToString
                                drR("NOMBEMPREF") = r.Item("NOMBEMPREF").ToString
                                dtCtesRecFacturacion.Rows.InsertAt(drR, dtCtesRecFacturacion.Rows.Count)


                            Next
                        End If
                    End With
                End With
            Next
            dgCteRef.DataSource = dtCtesRecFacturacion
            formatoRecurrentes()


        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarCteRecurrentes()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtCtesRecu = Nothing
        End Try
    End Sub
    Private Sub ListarCteNuevosSocio()
        Try
            LimpiarTabla(dtCtesNueFacturacion)

            Dim sTabla As String = "tbCteNuevos"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSocio", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paSAPYCClientesReferenciados", sTabla))

                dtCtesNuevos = .Item(sTabla)

                If dtCtesNuevos.Rows.Count > 0 Then
                    For Each r As DataRow In dtCtesNuevos.Rows
                        If r.Item("CVETRA").ToString = "" Then
                            dFacturacion = 0.0
                        Else
                            dFacturacion = ObtenerFacturacionCve(r.Item("CVETRA").ToString)
                        End If

                        drN = dtCtesNueFacturacion.NewRow
                        drN("TIPO") = "S"
                        drN("IDPROP") = r.Item("IDPROP").ToString
                        drN("CVETRA") = r.Item("CVETRA").ToString
                        drN("NOMEMPRESA") = r.Item("NOMEMPRESA").ToString
                        drN("SOCIO") = r.Item("SOCIO").ToString
                        drN("NOMSOCIO") = r.Item("NOMSOCIO").ToString
                        drN("SOCIO") = r.Item("SOCIO").ToString
                        drN("GERENTE") = r.Item("GERENTE").ToString
                        drN("NOMGERENTE") = r.Item("NOMGERENTE").ToString
                        drN("HONORARIOS") = Format(CDbl(r.Item("HONORARIOS").ToString), sFmtDbl)
                        drN("IMPFACT") = Format(dFacturacion, sFmtDbl)
                        drN("IDSTATUS") = r.Item("IDSTATUS").ToString
                        drN("STATUS") = r.Item("STATUS").ToString
                        drN("IDCOMOSE") = r.Item("IDCOMOSE").ToString
                        drN("COMOSEENTERO") = r.Item("COMOSEENTERO")
                        drN("REGISTRADAEL") = r.Item("REGISTRADAEL").ToString
                        drN("CVEEMPREF") = r.Item("CVEEMPREF").ToString
                        drN("NOMBEMPREF") = r.Item("NOMBEMPREF").ToString
                        dtCtesNueFacturacion.Rows.InsertAt(drN, dtCtesNueFacturacion.Rows.Count)


                    Next
                End If

                dgCteNuevo.DataSource = dtCtesNueFacturacion
                formatoNuevas()

            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "tbCteNuevos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtCtesNuevos = Nothing
        End Try
    End Sub
    Private Sub ListarCteRecurrentesSocio()
        Try
            LimpiarTabla(dtCtesRecFacturacion)

            Dim sTabla As String = "tbCteRecu"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 10, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSocio", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paSAPYCClientesReferenciados", sTabla))

                dtCtesRecu = .Item(sTabla)

                If dtCtesRecu.Rows.Count > 0 Then
                    For Each r As DataRow In dtCtesRecu.Rows
                        If r.Item("CVETRA").ToString = "" Then
                            dFacturacion = 0.0
                        Else
                            dFacturacion = ObtenerFacturacionCve(r.Item("CVETRA").ToString)
                        End If

                        drR = dtCtesRecFacturacion.NewRow
                        drR("TIPO") = "S"
                        drR("IDPROP") = r.Item("IDPROP").ToString
                        drR("CVETRA") = r.Item("CVETRA").ToString
                        drR("NOMEMPRESA") = r.Item("NOMEMPRESA").ToString
                        drR("SOCIO") = r.Item("SOCIO").ToString
                        drR("NOMSOCIO") = r.Item("NOMSOCIO").ToString
                        drR("SOCIO") = r.Item("SOCIO").ToString
                        drR("GERENTE") = r.Item("GERENTE").ToString
                        drR("NOMGERENTE") = r.Item("NOMGERENTE").ToString
                        drR("HONORARIOS") = Format(CDbl(r.Item("HONORARIOS").ToString), sFmtDbl)
                        drR("IMPFACT") = Format(dFacturacion, sFmtDbl)
                        drR("IDSTATUS") = r.Item("IDSTATUS").ToString
                        drR("STATUS") = r.Item("STATUS").ToString
                        drR("IDCOMOSE") = r.Item("IDCOMOSE").ToString
                        drR("COMOSEENTERO") = r.Item("COMOSEENTERO")
                        drR("REGISTRADAEL") = r.Item("REGISTRADAEL").ToString
                        drR("CVEEMPREF") = r.Item("CVEEMPREF").ToString
                        drR("NOMBEMPREF") = r.Item("NOMBEMPREF").ToString
                        dtCtesRecFacturacion.Rows.InsertAt(drR, dtCtesRecFacturacion.Rows.Count)


                    Next
                End If

                dgCteRef.DataSource = dtCtesRecFacturacion
                formatoRecurrentes()

            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarCteRecurrentes()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtCtesRecu = Nothing
        End Try
    End Sub

    Private Sub ListarFacturacionNormal()
        Try
            Dim sTabla As String = "tbFacturacion"
            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If
                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@dFechaInicio", dFechaInicio, SqlDbType.Date, ParameterDirection.Input)
                    .subAddParameter("@dFechaFinal", dFechaFinal, SqlDbType.Date, ParameterDirection.Input)
                End With
                .Add(clsDatos.funExecuteSPDataTable("paSAPYCClientesReferenciados", sTabla))
                dtFacturaNormal = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarFacturacionNormal()")
            MsgBox("Hubo un inconveniente al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtFacturaNormal = Nothing
        End Try
    End Sub
    Private Sub ListarCancelaciones()
        Try
            Dim sTabla As String = "tbCan"
            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If
                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@dFechaInicio", dFechaInicio, SqlDbType.Date, ParameterDirection.Input)
                    .subAddParameter("@dFechaFinal", dFechaFinal, SqlDbType.Date, ParameterDirection.Input)
                End With
                .Add(clsDatos.funExecuteSPDataTable("paSAPYCClientesReferenciados", sTabla))
                dtCan = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarCancelaciones()")
            MsgBox("Hubo un inconveniente al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtCan = Nothing
        End Try
    End Sub
    Private Sub ListarCancelacionesReserva()
        Try
            Dim sTabla As String = "tbCanRes"
            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If
                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@dFechaInicio", dFechaInicio, SqlDbType.Date, ParameterDirection.Input)
                    .subAddParameter("@dFechaFinal", dFechaFinal, SqlDbType.Date, ParameterDirection.Input)
                End With
                .Add(clsDatos.funExecuteSPDataTable("paSAPYCClientesReferenciados", sTabla))
                dtCanRes = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarCancelacionesReserva()")
            MsgBox("Hubo un inconveniente al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtCanRes = Nothing
        End Try
    End Sub
    Private Sub ListarDiferencias()
        Try
            Dim sTabla As String = "tbDiferencias"
            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If



                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@dFechaInicio", dFechaInicio, SqlDbType.Date, ParameterDirection.Input)
                    .subAddParameter("@dFechaFinal", dFechaFinal, SqlDbType.Date, ParameterDirection.Input)
                End With
                .Add(clsDatos.funExecuteSPDataTable("paSAPYCClientesReferenciados", sTabla))
                dtDiferencias = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDiferencias()")
            MsgBox("Hubo un inconveniente al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtDiferencias = Nothing
        End Try
    End Sub
    Private Sub ListarAjustesGastos()
        Try
            Dim sTabla As String = "tbAjustes"
            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If
                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                    If dFechaFinal.Month < 10 Then
                        .subAddParameter("@dFechaInicio", "01/0" & dFechaFinal.Month & "/" & dFechaFinal.Year, SqlDbType.Date, ParameterDirection.Input)
                    Else
                        .subAddParameter("@dFechaInicio", "01/" & dFechaFinal.Month & "/" & dFechaFinal.Year, SqlDbType.Date, ParameterDirection.Input)
                    End If
                    .subAddParameter("@dFechaFinal", dFechaFinal, SqlDbType.Date, ParameterDirection.Input)
                End With
                .Add(clsDatos.funExecuteSPDataTable("paSAPYCClientesReferenciados", sTabla))
                dtAjustesGastos = .Item(sTabla)

            End With

        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarAjustesGastos()")
            MsgBox("Hubo un inconveniente al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtAjustesGastos = Nothing
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function ObtenerMovtos(ByVal sTipo As String, ByVal iTipo As Integer) As DataTable
        Dim dt As New DataTable
        Try
            With ds.Tables
                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sTipo", sTipo, SqlDbType.VarChar, ParameterDirection.Input, 10)
                    .subAddParameter("@iTipo", iTipo, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@dFechaInicio", dFechaInicio, SqlDbType.Date, ParameterDirection.Input)
                    .subAddParameter("@dFechaFinal", dFechaFinal, SqlDbType.Date, ParameterDirection.Input)
                End With
                If .Contains("paSAPYCClientesReferenciados") Then
                    .Remove("paSAPYCClientesReferenciados")
                End If
                .Add(clsDatos.funExecuteSPDataTable("paSAPYCClientesReferenciados"))
                dt = .Item("paSAPYCClientesReferenciados")
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ObtenerMovtos()")
            MsgBox("Hubo un inconveniente al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dt = Nothing
        End Try
        Return dt
    End Function
    Private Function ObtenerNotasCanceladas(ByVal sCveSocio As String, Optional ByVal sCveOfi As String = "", Optional ByVal sCveArea As String = "", Optional ByVal sGpo As String = "") As DataTable
        Dim dt As New DataTable
        Dim dr(), drFila As DataRow
        Try
            dt = New DataTable
            dt.Columns.Add("SOCIO", GetType(System.String))
            dt.Columns.Add("CVEOFI", GetType(System.String))
            dt.Columns.Add("CVEAREA", GetType(System.String))
            dt.Columns.Add("GPO", GetType(System.String))
            dt.Columns.Add("CVETRA", GetType(System.String))
            dt.Columns.Add("DOCTO", GetType(System.String))
            dt.Columns.Add("NODOCTO", GetType(System.String))
            dt.Columns.Add("IMPHON", GetType(System.String))
            dt.Columns.Add("TIPOCTE", GetType(System.String))

            dr = dtCanRes.Select()
            For c As Integer = 0 To dr.Count - 1
                drFila = dt.NewRow
                drFila("SOCIO") = dr(c).Item("SOCIO").ToString
                drFila("CVEOFI") = dr(c).Item("CVEOFI").ToString
                drFila("CVEAREA") = dr(c).Item("CVEAREA").ToString
                drFila("GPO") = dr(c).Item("GPO").ToString
                drFila("CVETRA") = dr(c).Item("CVETRA").ToString
                drFila("DOCTO") = dr(c).Item("DOCTO").ToString
                drFila("NODOCTO") = dr(c).Item("NODOCTO").ToString
                drFila("IMPHON") = dr(c).Item("IMPHON").ToString
                drFila("TIPOCTE") = dr(c).Item("TIPOCTE").ToString
                dt.Rows.InsertAt(drFila, dt.Rows.Count)
            Next

            dr = dtCan.Select()
            For c As Integer = 0 To dr.Count - 1
                'If dt.Select("CVETRA = '" & dr(c).Item("CVETRA").ToString & "'").Count = 0 Then
                If dt.Select("DOCTO = '" & dr(c).Item("DOCTO").ToString & "' AND NODOCTO = '" & dr(c).Item("NODOCTO").ToString & "'").Count = 0 Then
                    drFila = dt.NewRow
                    drFila("SOCIO") = dr(c).Item("SOCIO").ToString
                    drFila("CVEOFI") = dr(c).Item("CVEOFI").ToString
                    drFila("CVEAREA") = dr(c).Item("CVEAREA").ToString
                    drFila("GPO") = dr(c).Item("GPO").ToString
                    drFila("CVETRA") = dr(c).Item("CVETRA").ToString
                    drFila("DOCTO") = dr(c).Item("DOCTO").ToString
                    drFila("NODOCTO") = dr(c).Item("NODOCTO").ToString
                    'drFila("FECHA") = dr(c).Item("FECHA").ToString
                    'drFila("AÑO") = dr(c).Item("AÑO").ToString
                    'drFila("MES") = dr(c).Item("MES").ToString
                    drFila("IMPHON") = dr(c).Item("IMPHON").ToString
                    drFila("TIPOCTE") = dr(c).Item("TIPOCTE").ToString
                    dt.Rows.InsertAt(drFila, dt.Rows.Count)
                End If
            Next
        Catch ex As Exception
            'insertarErrorLog(201, sNameRpt, ex.Message, sCveUsuario, "ObtenerNotasCanceladas()")
        End Try

        Return dt
    End Function
    Private Function ObtenerFacturacionInicial(ByVal sCveTra As String, Optional ByVal sCveSocio As String = "", Optional ByVal sCveOfi As String = "", Optional ByVal sCveArea As String = "", Optional ByVal sGpo As String = "") As Double
        Dim dCantidad As Double
        Dim drFact() As DataRow
        Try
            If dtFacturaNormal.Rows.Count > 0 Then
                drFact = dtFacturaNormal.Select("CVETRA = '" & sCveTra & "'")
                For d As Integer = 0 To drFact.Count - 1
                    dCantidad += CDbl(drFact(d).Item("IMPHON").ToString)
                Next
            Else
                dCantidad = 0
            End If
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerFacturacionInicial()")
        End Try
        Return dCantidad
    End Function
    Private Function ObtenerCancelaciones(ByVal sCveTra As String, Optional ByVal sCveSocio As String = "", Optional ByVal sCveOfi As String = "", Optional ByVal sCveArea As String = "", Optional ByVal sGpo As String = "") As Double
        Dim dCantidad As Double
        Dim drCanc() As DataRow
        Try
            dCantidad = 0
            If dtCancelaciones.Rows.Count > 0 Then
                drCanc = dtCancelaciones.Select("CVETRA = '" & sCveTra & "'")
                For d As Integer = 0 To drCanc.Count - 1
                    dCantidad += CDbl(drCanc(d).Item("IMPHON").ToString)
                Next
            Else
                dCantidad = 0
            End If
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerCancelaciones()")
        End Try
        Return dCantidad
    End Function
    Private Function ObtenerFacturacionTraspaso(ByVal sCveTra As String, Optional ByVal sCveSocio As String = "", Optional ByVal sCveOfi As String = "", Optional ByVal sCveArea As String = "", Optional ByVal sGpo As String = "") As Double
        Dim dCantidad As Double
        Dim drTraspasoDe() As DataRow = Nothing
        Dim drTraspasoA() As DataRow = Nothing
        Try
            dCantidad = 0

            drTraspasoDe = dtTFDe.Select("CVETRA = '" & sCveTra & "'")
            drTraspasoA = dtTFA.Select("CVETRA = '" & sCveTra & "'")
            If Not drTraspasoDe Is Nothing Then
                For d As Integer = 0 To drTraspasoDe.Count - 1
                    dCantidad -= CDbl(drTraspasoDe(d).Item("IMPHON").ToString)
                Next
            End If
            If Not drTraspasoA Is Nothing Then
                For n As Integer = 0 To drTraspasoA.Count - 1
                    dCantidad += CDbl(drTraspasoA(n).Item("IMPHON").ToString)
                Next
            End If
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerFacturacionTraspaso()")
        End Try
        Return dCantidad
    End Function
    Private Function ObtenerDiferenciasTC(ByVal sCveTra As String, Optional ByVal sCveSocio As String = "", Optional ByVal sCveOfi As String = "", Optional ByVal sCveArea As String = "", Optional ByVal sGpo As String = "") As Double
        Dim dCantidad As Double
        Dim drDif() As DataRow
        Try
            If dtDiferencias.Rows.Count > 0 Then
                drDif = dtDiferencias.Select("CVETRA = '" & sCveTra & "'")
                For d As Integer = 0 To drDif.Count - 1
                    dCantidad += CDbl(drDif(d).Item("TOTAL").ToString)
                Next
            Else
                dCantidad = 0
            End If
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerDiferenciasTC()")
        End Try
        Return dCantidad
    End Function
    Private Function ObtenerFacturacionInterna(ByVal sCveTra As String, Optional ByVal sCveSocio As String = "", Optional ByVal sCveOfi As String = "", Optional ByVal sCveArea As String = "", Optional ByVal sGpo As String = "") As Double
        Dim dCantidad As Double
        Dim drFacturaInternaDe() As DataRow = Nothing
        Dim drFacturaInternaA() As DataRow = Nothing
        Try
            drFacturaInternaDe = dtFIDe.Select("CVETRA = '" & sCveTra & "'")
            drFacturaInternaA = dtFIA.Select("CVETRA = '" & sCveTra & "'")
            If Not drFacturaInternaDe Is Nothing Then
                For d As Integer = 0 To drFacturaInternaDe.Count - 1
                    dCantidad -= CDbl(drFacturaInternaDe(d).Item("IMPHON").ToString)
                Next
            End If
            If Not drFacturaInternaA Is Nothing Then
                For n As Integer = 0 To drFacturaInternaA.Count - 1
                    dCantidad += CDbl(drFacturaInternaA(n).Item("IMPHON").ToString)
                Next
            End If
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerFacturacionInterna()")
        End Try
        Return dCantidad
    End Function
    Private Function ObtenerAjustesGastos(ByVal sCveTra As String, Optional ByVal sCveSocio As String = "", Optional ByVal sCveOfi As String = "", Optional ByVal sCveArea As String = "", Optional ByVal sGpo As String = "") As Double
        Dim dCantidad As Double
        Dim drGast() As DataRow
        Try
            If dtAjustesGastos.Rows.Count > 0 Then
                drGast = dtAjustesGastos.Select("CVETRA = '" & sCveTra & "'")
                For d As Integer = 0 To drGast.Count - 1
                    dCantidad += CDbl(drGast(d).Item("IMPGAS").ToString)
                Next
            Else
                dCantidad = 0
            End If
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerAjustesGastos()")
        End Try
        Return dCantidad
    End Function
    Private Function ObtenerFacturacionCve(ByVal sCveTra As String, Optional ByVal sCveSocio As String = "", Optional ByVal sCveOfi As String = "", Optional ByVal sCveArea As String = "", Optional ByVal sGpo As String = "") As Double
        Dim dCantidad As Double
        Try
            dFacturacion = 0
            dFacturaNormal = 0
            dCancelacion = 0
            dDiferencias = 0
            dFacturaInterna = 0
            dTraspasoFactura = 0
            dAjustesGastos = 0
            dtCancelaciones = ObtenerNotasCanceladas(sCveTra)
            dFacturaNormal = ObtenerFacturacionInicial(sCveTra)
            dCancelacion = ObtenerCancelaciones(sCveTra)
            dFacturaInterna = ObtenerFacturacionInterna(sCveTra)
            dTraspasoFactura = ObtenerFacturacionTraspaso(sCveTra)
            dAjustesGastos = ObtenerAjustesGastos(sCveTra)
            dDiferencias = ObtenerDiferenciasTC(sCveTra)
            dCantidad = (dFacturaNormal + dCancelacion) + dDiferencias + dTraspasoFactura + dFacturaInterna + dAjustesGastos
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerFacturacionCve()")
        End Try
        Return dCantidad
    End Function

#End Region

End Class