Public Class DlgKardex

    Private bsDiv, bsSer, bsMar, bsInd As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Kardex de Colaborador"
    Private sStoredProc As String = "paKardexEncargados"

    Private dtOpciones, dtDivisiones, dtKardex, dtServ, dtServCol, dtServicios, dtMar, dtMarcos, dtMarcosCol, dtInd, dtIndustrias, dtIndustriasCol As New DataTable
    Private dtDatosGenerales, dtCertificaciones, dtComites, dtOtrosDatos As New DataTable
    Private drOpciones, drServicios, drMarcos, drIndustrias As DataRow

    Private sCveOfi, sCvearea, sFilas As String
    Private sTrabajosPCAOB, sCertificaciones, sIdiomas, sComites, sComisionesIMCP, sComitesGTI, sRolesEstructura, sConsejosAdmon As String
    Private iDictamenEfectos, iRegistroSFP, iExperienciaEmpresas, iRegulacionPCAOB, iAñosPCAOB, iMiembroConsejo, iCertificacionIMCP, iContribuciones, iIMSS, iInfonavit As Integer
    Private bCambiosCertificaciones As Boolean = False
    Public idKardex, sCveEmp, sNombre As String

    Private Sub DlgKardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitulo.Text = "KARDEX"
        gridDivisiones.DataSource = bsDiv
        DesplazamientoGrid(gridDivisiones)

        gridServicios.DataSource = bsSer
        DesplazamientoGrid(gridServicios)

        gridMarcoNorma.DataSource = bsMar
        DesplazamientoGrid(gridMarcoNorma)

        gridIndustrias.DataSource = bsInd
        DesplazamientoGrid(gridIndustrias)

        LimpiarVariables()
        CrearTablas()

        ListarOpciones()
        ListarKardex()
        ListarDivisionesColaborador()
        ListarMarcosNormativos()
        ListarMarcosNormativosColaborador()
        ListarIndustrias()
        ListarIndustriasColaborador()

        ListarDatosGenerales()
        ListarCertificaciones()
        ListarComites()
        ListarOtrosDatos()
    End Sub
    Private Sub BtnGuardarVoBo_Click(sender As Object, e As EventArgs) Handles btnGuardarVoBo.Click
        If MsgBox("Se cambiará el status del Kardex a 'Revisado', ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
            VoBoKardex(4, idKardex, 4)
            EnvioCorreoVoBo()
            DialogResult = DialogResult.OK
            Close()
        End If
    End Sub
    Private Sub BtnCorreccion_Click(sender As Object, e As EventArgs) Handles btnCorreccion.Click
        If MsgBox("Se enviará un correo al colaborador para solicitar la corrección de su Kardex, ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
            VoBoKardex(4, idKardex, 3)
            EnvioCorreoFaltante()
            DialogResult = DialogResult.OK
            Close()
        End If
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub GridDivisiones_SelectionChanged(sender As Object, e As EventArgs) Handles gridDivisiones.SelectionChanged
        If gridDivisiones.CurrentRow IsNot Nothing Then
            sCveOfi = gridDivisiones.CurrentRow.Cells("CVEOFI").Value.ToString()
            sCvearea = gridDivisiones.CurrentRow.Cells("CVEAREA").Value.ToString()

            ListarServiciosDivision()
            ListarServiciosColaborador()
        End If
    End Sub

    Private Sub LimpiarVariables()
        sTrabajosPCAOB = ""
        sCertificaciones = ""
        sIdiomas = ""
        sComites = ""
        sComisionesIMCP = ""
        sComitesGTI = ""
        sRolesEstructura = ""
        sConsejosAdmon = ""

        iDictamenEfectos = 0
        iRegistroSFP = 0
        iExperienciaEmpresas = 0
        iRegulacionPCAOB = 0
        iAñosPCAOB = 0
        iMiembroConsejo = 0
        iCertificacionIMCP = 0
        iContribuciones = 0
        iIMSS = 0
        iInfonavit = 0
    End Sub
    Private Sub CrearTablas()
        dtServicios.Columns.Add("bElegir", GetType(Boolean))
        dtServicios.Columns.Add("idServicio", GetType(String))
        dtServicios.Columns.Add("sDescripcion", GetType(String))

        dtMarcos.Columns.Add("bElegir", GetType(Boolean))
        dtMarcos.Columns.Add("idMarco", GetType(String))
        dtMarcos.Columns.Add("sMarcoNormativo", GetType(String))

        dtIndustrias.Columns.Add("bElegir", GetType(Boolean))
        dtIndustrias.Columns.Add("idIndustria", GetType(String))
        dtIndustrias.Columns.Add("sIndustria", GetType(String))
    End Sub
    Private Sub ListarOpciones()
        dtOpciones.Columns.Add("iOpcion", GetType(String))
        dtOpciones.Columns.Add("sDescripcion", GetType(String))

        drOpciones = dtOpciones.NewRow()
        drOpciones("iOpcion") = "0"
        drOpciones("sDescripcion") = "Seleccione..."
        dtOpciones.Rows.InsertAt(drOpciones, dtOpciones.Rows.Count)

        drOpciones = dtOpciones.NewRow()
        drOpciones("iOpcion") = "1"
        drOpciones("sDescripcion") = "Sí"
        dtOpciones.Rows.InsertAt(drOpciones, dtOpciones.Rows.Count)

        drOpciones = dtOpciones.NewRow()
        drOpciones("iOpcion") = "2"
        drOpciones("sDescripcion") = "No"
        dtOpciones.Rows.InsertAt(drOpciones, dtOpciones.Rows.Count)

        cboIMCP.DataSource = dtOpciones
        cboIMCP.DisplayMember = "sDescripcion"
        cboIMCP.ValueMember = "iOpcion"

        cboContribuciones.DataSource = dtOpciones.Copy
        cboContribuciones.DisplayMember = "sDescripcion"
        cboContribuciones.ValueMember = "iOpcion"

        cboIMSS.DataSource = dtOpciones.Copy
        cboIMSS.DisplayMember = "sDescripcion"
        cboIMSS.ValueMember = "iOpcion"

        cboInfonavit.DataSource = dtOpciones.Copy
        cboInfonavit.DisplayMember = "sDescripcion"
        cboInfonavit.ValueMember = "iOpcion"

        cboDictamenEfectos.DataSource = dtOpciones.Copy
        cboDictamenEfectos.DisplayMember = "sDescripcion"
        cboDictamenEfectos.ValueMember = "iOpcion"

        cboRegistroSFP.DataSource = dtOpciones.Copy
        cboRegistroSFP.DisplayMember = "sDescripcion"
        cboRegistroSFP.ValueMember = "iOpcion"

        cboExperienciaEmpresas.DataSource = dtOpciones.Copy
        cboExperienciaEmpresas.DisplayMember = "sDescripcion"
        cboExperienciaEmpresas.ValueMember = "iOpcion"

        cboRegulacionPCAOB.DataSource = dtOpciones.Copy
        cboRegulacionPCAOB.DisplayMember = "sDescripcion"
        cboRegulacionPCAOB.ValueMember = "iOpcion"

        cboConsejoAdmon.DataSource = dtOpciones.Copy
        cboConsejoAdmon.DisplayMember = "sDescripcion"
        cboConsejoAdmon.ValueMember = "iOpcion"
    End Sub

    Private Sub ListarDivisionesColaborador()
        Try
            Dim sTabla As String = "tbDivisiones"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveEmp", sCveEmp, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtDivisiones = .Item(sTabla)
            End With

            If dtDivisiones.Rows.Count > 0 Then
                bsDiv.DataSource = dtDivisiones

                gridDivisiones.Columns("CVEEMP").Visible = False
                gridDivisiones.Columns("CVEOFI").Visible = False
                gridDivisiones.Columns("CVEAREA").Visible = False

                ConfigurarColumnasGrid(gridDivisiones, "DESCOFI", "OFICINA", 65, 3, False)
                ConfigurarColumnasGrid(gridDivisiones, "DESCAREA", "DIVISIÓN", 0, 1, False)
            Else
                bsDiv.DataSource = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDivisionesColaborador()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtDivisiones = Nothing
        End Try
    End Sub

    Private Sub ListarKardex()
        Try
            Dim sTabla As String = "tbKardex"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 10, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idKardex", idKardex, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtKardex = .Item(sTabla)
            End With

            If dtKardex.Rows.Count > 0 Then
                lblNombre.Text = sNombre
                lblPuesto.Text = dtKardex.Rows(0).Item("sPuesto").ToString()
                txtEdad.Text = DiferenciaEnAños(dtKardex.Rows(0).Item("dEdad"), Now.Date()) & " AÑOS"
                txtAntiguo.Text = DiferenciaEnAños(dtKardex.Rows(0).Item("dAntiguo"), Now.Date()) & " AÑOS"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDivisionesColaborador()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtKardex = Nothing
        End Try
    End Sub

    Private Sub ListarServiciosDivision()
        Try
            Dim sTabla As String = "tbServiciosDiv"

            LimpiarTabla(dtServicios)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 11, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idKardex", idKardex, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveArea", sCvearea, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtServ = .Item(sTabla)
            End With

            If dtServ.Rows.Count > 0 Then
                For Each row As DataRow In dtServ.Rows
                    drServicios = dtServicios.NewRow()
                    drServicios("bElegir") = False
                    drServicios("idServicio") = row("idServicio")
                    drServicios("sDescripcion") = row("sDescripcion")
                    'drServicios("sOtrosServicios") = ""
                    dtServicios.Rows.InsertAt(drServicios, dtServicios.Rows.Count)
                Next

                bsSer.DataSource = dtServicios
                gridServicios.Columns("idServicio").Visible = False

                ConfigurarColumnasGrid(gridServicios, "bElegir", "ACTIVO", 60, 3, False)
                ConfigurarColumnasGrid(gridServicios, "sDescripcion", "SERVICIO", 0, 1, False)
                ' ConfigurarColumnasGrid(gridServicios, "sOtrosServicios", "OTROS", 0, 1, False)
            Else
                bsSer.DataSource = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarServiciosDivision()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtServicios = Nothing
        End Try
    End Sub
    Private Sub ListarServiciosColaborador()
        Try
            Dim sTabla As String = "tbServiciosCol"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idKardex", idKardex, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveArea", sCvearea, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtServCol = .Item(sTabla)
            End With

            If dtServCol.Rows.Count > 0 Then
                ' Crear un conjunto con los idServicio del colaborador (usar String para evitar errores de conversión)
                'Dim ids As New HashSet(Of String)
                Dim ids As New Dictionary(Of Integer, DataRow)()
                For Each dr As DataRow In dtServCol.Rows
                    If Not IsDBNull(dr("idServicio")) Then
                        ids(dr("idServicio")) = dr
                    End If
                Next

                ' Marcar/limpiar bElegir en una sola pasada
                For Each row As DataGridViewRow In gridServicios.Rows
                    If ids.ContainsKey(row.Cells("idServicio").Value) Then
                        Dim upd = ids(row.Cells("idServicio").Value)

                        row.Cells("bElegir").Value = True
                        'If Not IsDBNull(upd("OTROS")) Then row.Cells("sOtrosServicios").Value = upd("OTROS")
                    End If
                Next
            Else
                ' Si no hay servicios del colaborador, limpiar todas las marcas
                For Each row As DataGridViewRow In gridServicios.Rows
                    If Not row.IsNewRow Then
                        row.Cells("bElegir").Value = False
                    End If
                Next
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarServiciosColaborador()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtServCol = Nothing
        End Try
    End Sub
    Private Sub ListarMarcosNormativos()
        Try
            Dim sTabla As String = "tbMarcos"

            LimpiarTabla(dtMarcos)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 14, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtMar = .Item(sTabla)
            End With

            If dtMar.Rows.Count > 0 Then
                For Each row As DataRow In dtMar.Rows
                    drMarcos = dtMarcos.NewRow()
                    drMarcos("bElegir") = False
                    drMarcos("idMarco") = row("idMarco")
                    drMarcos("sMarcoNormativo") = row("sMarcoNormativo")
                    'drMarcos("sOtroMarco") = ""
                    dtMarcos.Rows.InsertAt(drMarcos, dtMarcos.Rows.Count)
                Next

                bsMar.DataSource = dtMarcos
                gridMarcoNorma.Columns("idMarco").Visible = False

                ConfigurarColumnasGrid(gridMarcoNorma, "bElegir", "ACTIVO", 60, 3, False)
                ConfigurarColumnasGrid(gridMarcoNorma, "sMarcoNormativo", "MARCO NORMATIVO", 0, 1, False)
                'ConfigurarColumnasGrid(gridMarcoNorma, "sOtroMarco", "OTROS", 0, 1, False)
            Else
                bsMar.DataSource = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarMarcosNormativos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtMar = Nothing
        End Try
    End Sub
    Private Sub ListarMarcosNormativosColaborador()
        Try
            Dim sTabla As String = "tbMarcosCol"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 15, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idKardex", idKardex, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtMarcosCol = .Item(sTabla)
            End With

            If dtMarcosCol.Rows.Count > 0 Then
                ' Crear un conjunto con los idServicio del colaborador (usar String para evitar errores de conversión)
                Dim ids As New Dictionary(Of Integer, DataRow)()
                For Each dr As DataRow In dtMarcosCol.Rows
                    If Not IsDBNull(dr("idMarcoNormativo")) Then
                        ids(dr("idMarcoNormativo")) = dr
                    End If
                Next

                ' Marcar/limpiar bElegir en una sola pasada
                For Each row As DataGridViewRow In gridMarcoNorma.Rows
                    If ids.ContainsKey(row.Cells("idMarco").Value) Then
                        Dim upd = ids(row.Cells("idMarco").Value)

                        row.Cells("bElegir").Value = True
                        'If Not IsDBNull(upd("sOtroMarcoNormativo")) Then row.Cells("sOtroMarco").Value = upd("sOtroMarcoNormativo")
                    End If
                Next
            Else
                ' Si no hay servicios del colaborador, limpiar todas las marcas
                For Each row As DataGridViewRow In gridMarcoNorma.Rows
                    If Not row.IsNewRow Then
                        row.Cells("bElegir").Value = False
                    End If
                Next
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarMarcosNormativosColaborador()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtMarcosCol = Nothing
        End Try
    End Sub
    Private Sub ListarIndustrias()
        Try
            Dim sTabla As String = "tbIndustrias"

            LimpiarTabla(dtIndustrias)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 18, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtInd = .Item(sTabla)
            End With

            If dtInd.Rows.Count > 0 Then
                For Each row As DataRow In dtInd.Rows
                    drIndustrias = dtIndustrias.NewRow()
                    drIndustrias("bElegir") = False
                    drIndustrias("idIndustria") = row("idIndustria")
                    drIndustrias("sIndustria") = row("sIndustria")
                    dtIndustrias.Rows.InsertAt(drIndustrias, dtIndustrias.Rows.Count)
                Next

                bsInd.DataSource = dtIndustrias
                gridIndustrias.Columns("idIndustria").Visible = False

                ConfigurarColumnasGrid(gridIndustrias, "bElegir", "ACTIVO", 60, 3, False)
                ConfigurarColumnasGrid(gridIndustrias, "sIndustria", "INDUSTRIA", 0, 1, False)
            Else
                bsInd.DataSource = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarIndustrias()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtInd = Nothing
        End Try
    End Sub
    Private Sub ListarIndustriasColaborador()
        Try
            Dim sTabla As String = "tbIndustriasCol"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 19, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idKardex", idKardex, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtIndustriasCol = .Item(sTabla)
            End With

            If dtIndustriasCol.Rows.Count > 0 Then
                ' Crear un conjunto con los idServicio del colaborador (usar String para evitar errores de conversión)
                Dim ids As New Dictionary(Of Integer, DataRow)()
                For Each dr As DataRow In dtIndustriasCol.Rows
                    If Not IsDBNull(dr("idIndustria")) Then
                        ids(dr("idIndustria")) = dr
                    End If
                Next

                ' Marcar/limpiar bElegir en una sola pasada
                For Each row As DataGridViewRow In gridIndustrias.Rows
                    If ids.ContainsKey(row.Cells("idIndustria").Value) Then
                        Dim upd = ids(row.Cells("idIndustria").Value)

                        row.Cells("bElegir").Value = True
                    End If
                Next
            Else
                ' Si no hay servicios del colaborador, limpiar todas las marcas
                For Each row As DataGridViewRow In gridIndustrias.Rows
                    If Not row.IsNewRow Then
                        row.Cells("bElegir").Value = False
                    End If
                Next
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarIndustriasColaborador()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtIndustriasCol = Nothing
        End Try
    End Sub

    Private Sub ListarDatosGenerales()
        Try
            Dim sTabla As String = "tbDatosGenerales"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idKardex", idKardex, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable("paDatosGeneralesKardex", sTabla))

                dtDatosGenerales = .Item(sTabla)
            End With

            If dtDatosGenerales.Rows.Count > 0 Then
                iDictamenEfectos = CInt(dtDatosGenerales.Rows(0).Item("iDictamenFiscal").ToString())
                iRegistroSFP = CInt(dtDatosGenerales.Rows(0).Item("iRegistroSFP").ToString())
                iExperienciaEmpresas = CInt(dtDatosGenerales.Rows(0).Item("iExperienciaPublica").ToString())
                iRegulacionPCAOB = CInt(dtDatosGenerales.Rows(0).Item("iExperienciaPCAOB").ToString())
                iAñosPCAOB = dtDatosGenerales.Rows(0).Item("iAñosExperienciaPCAOB").ToString()
                sTrabajosPCAOB = dtDatosGenerales.Rows(0).Item("sTrabajosPCAOBSEC").ToString()

                cboDictamenEfectos.SelectedValue = iDictamenEfectos
                cboRegistroSFP.SelectedValue = iRegistroSFP
                cboExperienciaEmpresas.SelectedValue = iExperienciaEmpresas
                cboRegulacionPCAOB.SelectedValue = iRegulacionPCAOB
                txtAñosPCAOB.Text = iAñosPCAOB
                txtTrabajosPCAOB.Text = sTrabajosPCAOB
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarCertificaciones()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtDatosGenerales = Nothing
        End Try
    End Sub
    Private Sub ListarCertificaciones()
        Try
            Dim sTabla As String = "tbCertificaciones"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idKardex", idKardex, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable("paCertificacionesKardex", sTabla))

                dtCertificaciones = .Item(sTabla)
            End With

            If dtCertificaciones.Rows.Count > 0 Then
                sCertificaciones = dtCertificaciones.Rows(0).Item("sCertificaciones").ToString()
                sIdiomas = dtCertificaciones.Rows(0).Item("sIdiomas").ToString()
                txtCertificaciones.Text = sCertificaciones
                txtIdiomas.Text = sIdiomas
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarCertificaciones()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtCertificaciones = Nothing
        End Try
    End Sub
    Private Sub ListarComites()
        Try
            Dim sTabla As String = "tbComites"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idKardex", idKardex, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable("paComitesKardex", sTabla))

                dtComites = .Item(sTabla)
            End With

            If dtComites.Rows.Count > 0 Then
                sComites = dtComites.Rows(0).Item("sComitesFirma").ToString()
                sComisionesIMCP = dtComites.Rows(0).Item("sComitesColegio").ToString()
                sComitesGTI = dtComites.Rows(0).Item("sComitesGTI").ToString()
                sRolesEstructura = dtComites.Rows(0).Item("sRolesEstructuraFirma").ToString()
                iMiembroConsejo = CInt(dtComites.Rows(0).Item("iMiembroConsejo").ToString())
                sConsejosAdmon = dtComites.Rows(0).Item("sConsejoAdmon").ToString()

                txtComitesFirma.Text = sComites
                txtComisionesIMCP.Text = sComisionesIMCP
                txtComitesGTI.Text = sComitesGTI
                txtRolesEstructura.Text = sRolesEstructura
                cboConsejoAdmon.SelectedValue = iMiembroConsejo
                txtConsejosAdmonParticipacion.Text = sConsejosAdmon
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarComites()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtComites = Nothing
        End Try
    End Sub
    Private Sub ListarOtrosDatos()
        Try
            Dim sTabla As String = "tbOtrosDatos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idKardex", idKardex, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable("paOtrosDatosKardex", sTabla))

                dtOtrosDatos = .Item(sTabla)
            End With

            If dtOtrosDatos.Rows.Count > 0 Then
                iCertificacionIMCP = dtOtrosDatos.Rows(0).Item("iCertificacionIMCP")
                iContribuciones = dtOtrosDatos.Rows(0).Item("iContribuciones")
                iIMSS = dtOtrosDatos.Rows(0).Item("iIMSS")
                iInfonavit = dtOtrosDatos.Rows(0).Item("iInfonavit")

                cboIMCP.SelectedValue = iCertificacionIMCP
                cboContribuciones.SelectedValue = iContribuciones
                cboIMSS.SelectedValue = iIMSS
                cboInfonavit.SelectedValue = iInfonavit
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarOtrosDatos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtOtrosDatos = Nothing
        End Try
    End Sub

    Private Sub VoBoKardex(iOpcion As Integer, idKardex As Integer, iStatusKardex As Integer)
        Try
            With clsDatosSac
                .subClearParameters()
                .subAddParameter("@iOpcion", iOpcion, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idKardex", idKardex, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iStatusKardex", iStatusKardex, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP(sStoredProc)
            End With

            MsgBox("Se ha actualizado el status del Kardex.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EliminarProspecto()")
            MsgBox("Por el momento no es posible dar de baja el kardex, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub

    Private Sub AgregarFilasHTML()
        If chkServicios.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Servicios que realiza.</td></tr>" & vbNewLine
        End If

        If chkMarco.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Marcos normativos en el que trabaja.</td></tr>" & vbNewLine
        End If

        If chkIndustrias.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Industrias en las que trabaja.</td></tr>" & vbNewLine
        End If

        sFilas &= "<tr><td style= ""height: 24px;""></td></tr>" & vbNewLine
        sFilas &= "<tr><td style=""text-align: left;""><b>DATOS GENERALES</b></td></tr>" & vbNewLine

        If chkDG1.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Dictamina para efectos fiscales.</td></tr>" & vbNewLine
        End If

        If chkDG2.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Registro en la SFP.</td></tr>" & vbNewLine
        End If

        If chkDG3.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Experiencia en empresas públicas.</td></tr>" & vbNewLine
        End If

        If chkDG4.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Experiencia en regulación PCAOB.</td></tr>" & vbNewLine
        End If

        If chkDG5.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Años de experiencia en PCAOB.</td></tr>" & vbNewLine
        End If

        If chkDG6.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Trabajos PCAOB SEC.</td></tr>" & vbNewLine
        End If

        sFilas &= "<tr><td style= ""height: 24px;""></td></tr>" & vbNewLine
        sFilas &= "<tr><td style=""text-align: left;""><b>CERTIFICACIONES E IDIOMAS</b></td></tr>" & vbNewLine

        If chkCER1.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Certificaciones, maestrías y especialidades.</td></tr>" & vbNewLine
        End If

        If chkCER2.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Idiomas en los que puede mantener comunicación profesional.</td></tr>" & vbNewLine
        End If

        sFilas &= "<tr><td style= ""height: 24px;""></td></tr>" & vbNewLine
        sFilas &= "<tr><td style=""text-align: left;""><b>PARTICIPACIONES EN COMITÉS, COMISIONES O GRUPOS DE TRABAJO</b></td></tr>" & vbNewLine

        If chkCOM1.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Comités de firma en los que participa.</td></tr>" & vbNewLine
        End If

        If chkCOM2.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Comisiones del IMCP en las que participa.</td></tr>" & vbNewLine
        End If

        If chkCOM3.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Comités de GTI en los que participa.</td></tr>" & vbNewLine
        End If

        If chkCOM4.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Roles en la estructura de firma.</td></tr>" & vbNewLine
        End If

        If chkCOM5.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Miembro del consejo de administración.</td></tr>" & vbNewLine
        End If

        If chkCOM6.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Consejos de administración en los que participa.</td></tr>" & vbNewLine
        End If

        sFilas &= "<tr><td style= ""height: 24px;""></td></tr>" & vbNewLine
        sFilas &= "<tr><td style=""text-align: left;""><b>OTROS DATOS</b></td></tr>" & vbNewLine

        If chkOD1.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Certificación del IMCP.</td></tr>" & vbNewLine
        End If

        If chkOD2.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Contribuciones al IMCP.</td></tr>" & vbNewLine
        End If

        If chkOD3.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• IMSS.</td></tr>" & vbNewLine
        End If

        If chkOD4.Checked = True Then
            sFilas &= "<tr><td style=""text-align: left;"">• Infonavit.</td></tr>" & vbNewLine
        End If
    End Sub

    Private Sub EnvioCorreoVoBo() 'Este correo es para avisar al socio o gerente que su Kardex está revisado y aprobado.
        Dim sMensaje As String
        'Dim sCorreos As String
        Try
            'sCorreos = "Octavio.A.Cervantes@mx.gt.com, Mario.Rodriguez@mx.gt.com"
            Dim sCorreo As String() = {"Octavio.A.Cervantes@mx.gt.com", "mario.rodriguez@mx.gt.com"}

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">REVISIÓN DE KARDEX</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado(a) " & sNombre & ",</p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Se ha realizado la revisión de su Kardex y toda la información es correcta. </p> " & vbNewLine & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Gracias por completar este requerimiento." & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Revisión de Kardex")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub EnvioCorreoFaltante() 'Este correo es para avisar al socio o gerente que su Kardex está revisado y aprobado.
        Dim sMensaje As String
        'Dim sCorreos As String
        Try
            'sCorreos = "Octavio.A.Cervantes@mx.gt.com, Mario.Rodriguez@mx.gt.com"
            Dim sCorreo As String() = {"Octavio.A.Cervantes@mx.gt.com"}

            AgregarFilasHTML()

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">REVISIÓN DE KARDEX</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado(a) " & sNombre & ",</p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">Se ha realizado la revisión de su Kardex y se identificaron los siguientes datos que requieren corrección:</p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            sFilas & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Por favor, realice los ajustes correspondientes en SIAT, SAPYC > Kardex." & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Revisión de Kardex")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
End Class