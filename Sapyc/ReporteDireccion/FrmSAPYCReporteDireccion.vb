Imports System.Globalization

Public Class FrmSAPYCReporteDireccion

#Region "VARIABLES"

    Private bs, bsConIni, bsNoR, bsPer, bsRNA, bsNvo, bsRec, bsPen, bsRch As New BindingSource
    Private ds As New DataSet
    Private sNameRpt As String = "SAPYC - Reporte de la Dirección"

    Private dtConcilEnc, dtConcilSoc, dtConcilIni, dtPermisosEnc, dtPermisosSoc, dtPermisosUsu, dtPermisosRep, dtAceptadosSin As New DataTable
    Private drConcilEnc, drConcilSoc, drConcilIni As DataRow
    Private dtConIni As New DataTable
    Private dtRecurrentes, dtNuevasGan, dtPendientes, dtRechazadas, dtNoArreglados, dtPerdidas, dtNoRecurrentes, dtPpto, dtIngresosAnt, dtIngresosSocAnt, dtHonCicloAnt, dtHonCicloAntNoRec, dtHonCicloAntNoRecPpto As New DataTable
    Private dtRecurrentesDatos, dtRechazadasDatos, dtPendientesDatos, dtNuevasGanDatos, dtNoArregladosDatos, dtPerdidasDatos, dtNoRecurrentesDatos, dtHonPptoAsoc As New DataTable
    Private drRec, drRecha, drPen, drGaN, drNoA, drPer, dtNoRec As DataRow
    Private dtHonPer, dtHonPerdatos As New DataTable
    Private drHonPer As DataRow
    Private dtHonRech, dtHonRechdatos As New DataTable
    Private drHonRech As DataRow
    Private dtHonResolver, dtHonResolverdatos As New DataTable
    Private drHonResolver As DataRow
    Private dtHonNuevas, dtHonNuevasDatos As New DataTable
    Private drHonNuevas As DataRow
    Private dtHonNoRec, dtHonNoRecDatos As New DataTable
    Private drHonNoRec As DataRow
    Private dtHonRecNoArr, dtHonRecNoArrDatos As New DataTable
    Private drHonRecNoArr As DataRow
    Private dtHonRec, dtHonRecDatos As New DataTable
    Private drHonRec As DataRow
    Private dtHonTotPro, HonTotProDatos As New DataTable
    Private drTotPro As DataRow
    Private dtFacturaNormal, dtCan, dtCanRes, dtCancelaciones, dtDiferencias, dtAjustesGastos, dtTrabajos As New DataTable
    Private dtFIDe, dtFIA, dtTFDe, dtTFA As New DataTable
    Private sCveOfi As String() = {"MEX", "GDL", "MTY", "CJ", "QRO", "VALL", "AGS", "TIJ", "PUE"}
    Private sCveDiv As String() = {"AUD", "IMP", "PT", "CEX", "CE", "AUI"}
    Private sOficinas As String() = {"Ciudad de México", "Guadalajara", "Monterrey", "Ciudad Juárez", "Querétaro", "Puerto Vallarta", "Aguascalientes", "Tijuana", "Puebla"}
    Private sDivisiones As String() = {"Aud.", "Imp.", "P.T.", "Com. Ext.", "BPS", "BAS"}
    Private dFechaInicio, dFechaFinal As Date
    Private sNumeroSocio, sTipoSocio As String

    Private dImporte, dImpDif, dTotal, dImpAud, dTotHonorarios, dIng, dImpNR, dImpPer, dImpNA, dImpGan, dImpRec, dSubtotal, dIngCon, dIngPpto, dIngPC, dImporteRec, dImporteAudRec, dDiferencia, dIngTransf As Double
    Private Bandera As Boolean
    Private bHabilitar = False, bHabilitarPer = False, bExiste = False, bBDActivo As Boolean = False
    Private idBD, iSocios, iMesDe, iMesA, iAñoPpto, iFila, iCol As Integer

    Private dtNoRecurrentesConcil, dtPeridosConcil, dtNoArregladosConcil, dtDiferenciaPptoDatos, dtDiferenciaPpto, dtTransfSoc, dtTransfSocDatos As New DataTable
    Private dtNoRecConcil, drPerdidosConcil, drNoArregladosConcil, drDiferenciaPpto, drTransfSoc As DataRow

    Private Usuario_Admin As String = "A"
    Private sTipoUsuario As String = "S"
#End Region

#Region "EVENTOS"

    Private Sub FrmSAPYCReporteDireccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gridConcilacionIni.DataSource = bsConIni
        DiseñoGrid(gridConcilacionIni)

        gridConciliacion.DataSource = bs
        DiseñoGrid(gridConciliacion)

        gridNoRecurrentes.DataSource = bsNoR
        DiseñoGrid(gridNoRecurrentes)

        gridPerdidos.DataSource = bsPer
        DiseñoGrid(gridPerdidos)

        gridRNA.DataSource = bsRNA
        DiseñoGrid(gridRNA)

        gridNuevos.DataSource = bsNvo
        DiseñoGrid(gridNuevos)

        gridRecurrentes.DataSource = bsRec
        DiseñoGrid(gridRecurrentes)

        gridPendientes.DataSource = bsPen
        DiseñoGrid(gridPendientes)

        gridRechazadas.DataSource = bsRch
        DiseñoGrid(gridRechazadas)

        dFechaInicio = "01/08/2022"
        dFechaFinal = "31/07/2023"

        lblTitulo.Text &= " - " & sNombreUsuario

        tabPaginas.SelectedIndex = 1

        If Trim(Usuario_Admin) = "E" Or Trim(Usuario_Admin) = "G" Or Trim(Usuario_Admin) = "D" Then
            dtPermisosUsu = ListarPermisosUsuariosRD(sCveUsuario, Trim(Usuario_Admin))

            rdIndividual.Checked = True
            panFiltro.Enabled = False
        Else
            dtPermisosEnc = ListarPermisosUsuariosRD(sCveUsuario, Trim(Usuario_Admin))
            dtPermisosUsu = ListarPermisosUsuariosRD(sCveUsuario, "S")

            rdSocioEncargado.Checked = True
            panFiltro.Enabled = True
        End If

        crearTablaConciliacionIni()
        CrearTablas()

    End Sub
    Private Sub btnGenerarRpt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGenerarRpt.Click
        If rdSocio.Checked And sNumeroSocio = "" Then
            MsgBox("Seleccione a un socio para consultar su Reporte de la Dirección.", MsgBoxStyle.Exclamation, "SAPYC")
            Exit Sub
        End If

        ListarPresupuesto()
        ListarHonorariosAnterior()
        ListarHonorariosCicloAnterior()
        ListarHonorariosCicloAnteriorNoRecurrentes()
        ListarHonorariosCicloAnteriorNoRecurrentesPpto()
        ListarHonorariosCicloAnteriorSocio()
        ListarHonorariosPptoClavesAsociadas()

        If rdIndividual.Checked Then
            Bandera = 1
            dtPermisosSoc = dtPermisosUsu
            crearTablaSocio()

            'CONCILIACIÓN INICIAL.
            ListarConciliacionInicial(dtPermisosSoc, Bandera)

            'NO RECURRENTES
            ListarNoRecurrentesConciliacion(dtPermisosSoc, Bandera)
            ListarHonorariosNoRecurrentes(dtPermisosSoc, Bandera)

            'PERDIDOS
            ListarPerdidosConciliacion(dtPermisosSoc, Bandera)
            ListarHonorariosPerdidos(dtPermisosSoc, Bandera)

            'RECURRENTES NO ARREGLADOS
            ListarNoArregladosConciliacion(dtPermisosSoc, Bandera)
            ListarHonorariosRecurrentesNoArreglados(dtPermisosSoc, Bandera)

            'NUEVOS GANADOS
            listarPropuestasNuevasGanadas(dtPermisosSoc, Bandera)
            ListarHonorariosNuevas(dtPermisosSoc, Bandera)

            'RECURRENTES
            ListarPropuestasRecurrentes(dtPermisosSoc, Bandera)
            ListarHonorariosRecurrentes(dtPermisosSoc, Bandera)

            'POR RESOLVER
            listarPropuestasPorResolver(dtPermisosSoc, Bandera)
            ListarHonorariosPorResolver(dtPermisosSoc, Bandera)

            'RECHAZADAS
            listarPropuestasRechazadas(dtPermisosSoc, Bandera)
            ListarHonorariosPropRechazadas(dtPermisosSoc, Bandera)

            'TRANSFERENCIAS ENTRE SOCIOS
            ListarHonorariosTransferenciasSocios(dtPermisosSoc, Bandera)

            'TOTAL PROPUESTAS
            ListarHonorariosTotalProp(dtPermisosSoc, Bandera)

            'LISTAR CONCILIACIÓN DE INGRESOS DEL SOCIO.
            listarReporteDireccionUsuario()
        ElseIf rdSocioEncargado.Checked Then
            'Si es socio encargada, seleccionará el tipo de reporte, Completo o de un socio.
            If rdCompleto.Checked Then
                Bandera = 0
                dtPermisosRep = dtPermisosEnc

                crearTablasEncargado()
            ElseIf rdSocio.Checked Then
                Bandera = 1
                dtPermisosSoc = ListarPermisosUsuariosRD(sNumeroSocio, Trim(sTipoSocio))
                dtPermisosRep = dtPermisosSoc

                crearTablaSocio()
            End If

            ListarConciliacionInicial(dtPermisosRep, Bandera)

            ''NO RECURRENTES
            ListarNoRecurrentesConciliacion(dtPermisosRep, Bandera)
            ListarHonorariosNoRecurrentes(dtPermisosRep, Bandera)

            ''PERDIDOS
            ListarPerdidosConciliacion(dtPermisosRep, Bandera)
            ListarHonorariosPerdidos(dtPermisosRep, Bandera)

            ''RECURRENTES NO ARREGLADOS
            ListarNoArregladosConciliacion(dtPermisosRep, Bandera)
            ListarHonorariosRecurrentesNoArreglados(dtPermisosRep, Bandera)

            ''NUEVOS GANADOS
            listarPropuestasNuevasGanadas(dtPermisosRep, Bandera)
            ListarHonorariosNuevas(dtPermisosRep, Bandera)

            ''RECURRENTES
            ListarPropuestasRecurrentes(dtPermisosRep, Bandera)
            ListarHonorariosRecurrentes(dtPermisosRep, Bandera)

            ''POR RESOLVER
            listarPropuestasPorResolver(dtPermisosRep, Bandera)
            ListarHonorariosPorResolver(dtPermisosRep, Bandera)

            ''RECHAZADAS
            listarPropuestasRechazadas(dtPermisosRep, Bandera)
            ListarHonorariosPropRechazadas(dtPermisosRep, Bandera)

            'TRANSFERENCIAS ENTRE SOCIOS
            ListarHonorariosTransferenciasSocios(dtPermisosRep, Bandera)

            ''TOTAL PROPUESTAS
            ListarHonorariosTotalProp(dtPermisosRep, Bandera)

            If rdIndividual.Checked Then
                listarReporteDireccionSocio()
            ElseIf rdSocioEncargado.Checked Then
                If rdCompleto.Checked Then
                    listarReporteDireccionEncargado()
                Else
                    listarReporteDireccionSocio()
                End If
            End If
        End If

        'tabPaginas.SelectedIndex = 1
    End Sub

    Private Sub btnHabilitarPer_Click(sender As Object, e As EventArgs) Handles btnHabilitarPer.Click
        If bHabilitarPer Then
            bHabilitarPer = False
            btnHabilitarPer.Text = "Habilitar"
            gridPerdidos.SelectionMode = DataGridViewSelectionMode.CellSelect
            gridPerdidos.EditMode = DataGridViewEditMode.EditProgrammatically
            gridPerdidos.CurrentCell = gridPerdidos(13, 0)
            gridPerdidos.FirstDisplayedScrollingColumnIndex = 13
            btnGuardarPer.Enabled = False
        Else
            bHabilitarPer = True
            btnHabilitarPer.Text = "Deshabilitar"
            gridPerdidos.SelectionMode = DataGridViewSelectionMode.CellSelect
            gridPerdidos.EditMode = DataGridViewEditMode.EditOnEnter
            gridPerdidos.CurrentCell = gridPerdidos(14, 0)
            gridPerdidos.FirstDisplayedScrollingColumnIndex = 14
            btnGuardarPer.Enabled = True
        End If
    End Sub
    Private Sub btnGuardarPer_Click(sender As Object, e As EventArgs) Handles btnGuardarPer.Click
        If MsgBox("¿Desea registrar los motivos de pérdida de las claves?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Registrar motivos") = MsgBoxResult.Yes Then
            ActualizarMotivosPerdida()

            If rdIndividual.Checked Then
                Bandera = 1
                ListarPerdidosConciliacion(dtPermisosSoc, Bandera)
            End If

            bHabilitarPer = False
            btnGuardarPer.Enabled = False
            btnHabilitarPer.Text = "Habilitar"
            gridPerdidos.SelectionMode = DataGridViewSelectionMode.CellSelect
            gridPerdidos.EditMode = DataGridViewEditMode.EditProgrammatically
            gridPerdidos.CurrentCell = gridPerdidos(13, 0)
            gridPerdidos.FirstDisplayedScrollingColumnIndex = 13
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim dlg As New DlgSocioRD

        sTipoSocio = ""
        sNumeroSocio = ""
        txtSocio.Text = ""

        dlg.dtPermisos = dtPermisosEnc

        If dlg.ShowDialog = DialogResult.OK Then
            sTipoSocio = dlg.sTipo
            sNumeroSocio = dlg.sCveSocio
            txtSocio.Text = dlg.sNombre
        End If
    End Sub
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim dlg As New dlgExcel

        Try
            If MsgBox("¿Desea exportar la información a Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Envio Excel") = MsgBoxResult.Yes Then
                dlg.txtArchivo.Focus()
                dlg.txtArchivo.Text = "Reporte de la Dirección"
                If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    exportarReporteDireccion(tabPaginas, dlg.txtDirectorio.Text, dlg.txtArchivo.Text)
                    Me.Cursor = Cursors.Default
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnHabilitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHabilitar.Click
        If bHabilitar Then
            bHabilitar = False
            btnHabilitar.Text = "Habilitar"
            gridConcilacionIni.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            gridConcilacionIni.EditMode = DataGridViewEditMode.EditProgrammatically
            gridConcilacionIni.CurrentCell = gridConcilacionIni(9, 0)
            gridConcilacionIni.FirstDisplayedScrollingColumnIndex = 9
            btnGuardar.Enabled = False

            RemoveHandler gridConcilacionIni.CellMouseDown, AddressOf gridConcilacionIni_CellMouseDown
            RemoveHandler gridConcilacionIni.DragOver, AddressOf gridConcilacionIni_DragOver
            RemoveHandler gridConcilacionIni.DragEnter, AddressOf gridConcilacionIni_DragEnter
            RemoveHandler gridConcilacionIni.DragDrop, AddressOf gridConcilacionIni_DragDrop
        Else
            bHabilitar = True
            gridConcilacionIni.SelectionMode = DataGridViewSelectionMode.CellSelect
            gridConcilacionIni.EditMode = DataGridViewEditMode.EditOnEnter
            btnHabilitar.Text = "Deshabilitar"
            gridConcilacionIni.CurrentCell = gridConcilacionIni(25, 0)
            gridConcilacionIni.FirstDisplayedScrollingColumnIndex = 25
            btnGuardar.Enabled = True

            AddHandler gridConcilacionIni.CellMouseDown, AddressOf gridConcilacionIni_CellMouseDown
            AddHandler gridConcilacionIni.DragOver, AddressOf gridConcilacionIni_DragOver
            AddHandler gridConcilacionIni.DragEnter, AddressOf gridConcilacionIni_DragEnter
            AddHandler gridConcilacionIni.DragDrop, AddressOf gridConcilacionIni_DragDrop
        End If
    End Sub
    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        If MsgBox("Al presionar este botón, se registrará como entregada su Conciliación de Ingresos, ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
            InsertarEntregaConciliacion()
        End If
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Desea registrar la información de la Conciliación de Ingresos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Registrar ingresos") = MsgBoxResult.Yes Then
            'InsertarClasificacionConciliacion()
            'InsertarDatosConciliacion()
            'InsertarEntregaConciliacion()
            ActualizarDatosConciliacion()

            If rdIndividual.Checked Then
                Bandera = 1
                ListarNoRecurrentesConciliacion(dtPermisosSoc, Bandera)
                ListarPerdidosConciliacion(dtPermisosSoc, Bandera)
                ListarNoArregladosConciliacion(dtPermisosSoc, Bandera)
            End If

            bHabilitar = False
            btnGuardar.Enabled = False
            btnHabilitar.Text = "Habilitar"
            gridConcilacionIni.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            gridConcilacionIni.EditMode = DataGridViewEditMode.EditProgrammatically
            gridConcilacionIni.CurrentCell = gridConcilacionIni(9, 0)
            gridConcilacionIni.FirstDisplayedScrollingColumnIndex = 9

            RemoveHandler gridConcilacionIni.CellMouseDown, AddressOf gridConcilacionIni_CellMouseDown
            RemoveHandler gridConcilacionIni.DragOver, AddressOf gridConcilacionIni_DragOver
            RemoveHandler gridConcilacionIni.DragEnter, AddressOf gridConcilacionIni_DragEnter
            RemoveHandler gridConcilacionIni.DragDrop, AddressOf gridConcilacionIni_DragDrop
        End If
    End Sub
    Private Sub gridConcilacionIni_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles gridConcilacionIni.CellBeginEdit
        If gridConcilacionIni.Rows(e.RowIndex).Cells("TIPO").Value = "S" Then
            If e.ColumnIndex <> 35 Then
                e.Cancel = True
                Exit Sub
            ElseIf CDbl(gridConcilacionIni.Rows(e.RowIndex).Cells("IMPPER").Value) = 0 Then
                e.Cancel = True
                Exit Sub
            End If
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub gridConcilacionIni_DragDrop(sender As Object, e As DragEventArgs)
        Dim cellvalue As String
        Dim cursorLocation As Point
        Dim hittest As DataGridView.HitTestInfo

        cellvalue = e.Data.GetData(GetType(String))
        cursorLocation = gridConcilacionIni.PointToClient(New Point(e.X, e.Y))
        hittest = gridConcilacionIni.HitTest(cursorLocation.X, cursorLocation.Y)

        If hittest.ColumnIndex <> -1 And (hittest.ColumnIndex = 33 Or hittest.ColumnIndex = 34) Then
            gridConcilacionIni.Rows(iFila).Cells("IMPPER").Value = Format(0, sFmtDbl)
            gridConcilacionIni.Rows(iFila).Cells("IMPDEC").Value = Format(0, sFmtDbl)
            gridConcilacionIni.Rows(iFila).Cells(hittest.ColumnIndex).Value = cellvalue

            If hittest.ColumnIndex = 33 Then
                gridConcilacionIni.Rows(iFila).Cells("IDCLAS").Value = 5
            ElseIf hittest.ColumnIndex = 34 Then
                gridConcilacionIni.Rows(iFila).Cells("IDCLAS").Value = 6
            End If

            SumarTotales()
        End If
    End Sub
    Private Sub gridConcilacionIni_DragEnter(sender As Object, e As DragEventArgs)
        e.Effect = DragDropEffects.Copy
    End Sub
    Private Sub gridConcilacionIni_DragOver(sender As Object, e As DragEventArgs)
        e.Effect = DragDropEffects.Copy

        If e.X <= gridConcilacionIni.PointToScreen(New Point(gridConcilacionIni.Location.X, gridConcilacionIni.Location.Y)).X + 18 Then
            gridConcilacionIni.FirstDisplayedScrollingColumnIndex -= 1
        End If

        If e.X >= gridConcilacionIni.PointToScreen(New Point(gridConcilacionIni.Location.X + gridConcilacionIni.Width, gridConcilacionIni.Location.Y)).X - 18 Then
            gridConcilacionIni.FirstDisplayedScrollingColumnIndex += 1
        End If
    End Sub
    Private Sub gridConcilacionIni_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs)
        If gridConcilacionIni.Rows(e.RowIndex).Cells("TIPO").Value = "S" Then
            'If e.ColumnIndex = 25 And gridConcilacionIni.Rows(e.RowIndex).Cells("TIPOTRA").Value = 1 And (gridConcilacionIni.Rows(e.RowIndex).Cells("IDCLAS").Value = 0 Or gridConcilacionIni.Rows(e.RowIndex).Cells("IDCLAS").Value = 5 Or gridConcilacionIni.Rows(e.RowIndex).Cells("IDCLAS").Value = 6) Then
            If e.ColumnIndex = 25 And (gridConcilacionIni.Rows(e.RowIndex).Cells("IDCLAS").Value = 0 Or gridConcilacionIni.Rows(e.RowIndex).Cells("IDCLAS").Value = 6) Then
                If e.Button = System.Windows.Forms.MouseButtons.Left Then
                    iFila = e.RowIndex
                    iCol = e.ColumnIndex
                    gridConcilacionIni.DoDragDrop(gridConcilacionIni.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue, DragDropEffects.Copy)
                End If
            End If
        End If
    End Sub
    Private Sub gridConcilacionIni_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles gridConcilacionIni.CellFormatting
        If gridConcilacionIni.Columns(e.ColumnIndex).Name.Contains("SEP") Then
            gridConcilacionIni.Columns(e.ColumnIndex).DefaultCellStyle.BackColor = Color.FromArgb(79, 45, 127)
        End If

        If gridConcilacionIni.Rows(e.RowIndex).Cells("TIPO").Value = "S" Then
            gridConcilacionIni.Rows(e.RowIndex).Cells("NOMBRESOC").Style.BackColor = Color.WhiteSmoke
            gridConcilacionIni.Rows(e.RowIndex).Cells("NOMBRESOC").Style.ForeColor = Color.Black
            gridConcilacionIni.Rows(e.RowIndex).Cells("NOMBRESOC").Style.Font = FuenteFila
            gridConcilacionIni.Rows(e.RowIndex).Cells("CVETRA").Style.BackColor = Color.FromArgb(0, 167, 181)
            gridConcilacionIni.Rows(e.RowIndex).Cells("CVETRA").Style.ForeColor = Color.White
            gridConcilacionIni.Rows(e.RowIndex).Cells("CVETRA").Style.Font = FuenteFila
            gridConcilacionIni.Rows(e.RowIndex).Cells("IMPFAC").Style.BackColor = Color.WhiteSmoke
            gridConcilacionIni.Rows(e.RowIndex).Cells("PPTOFACNET").Style.BackColor = Color.WhiteSmoke
            gridConcilacionIni.Rows(e.RowIndex).Cells("IMPNETO").Style.BackColor = Color.WhiteSmoke
            gridConcilacionIni.Rows(e.RowIndex).Cells("IMPVAR").Style.BackColor = Color.WhiteSmoke
            gridConcilacionIni.Rows(e.RowIndex).Cells("IMPVAR").Style.Font = FuenteFila
            gridConcilacionIni.Rows(e.RowIndex).Cells("TOTAL").Style.BackColor = Color.Gainsboro
            gridConcilacionIni.Rows(e.RowIndex).Cells("TOTAL").Style.Font = FuenteFila
        ElseIf gridConcilacionIni.Rows(e.RowIndex).Cells("TIPO").Value = "T" Then
            gridConcilacionIni.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gainsboro
            gridConcilacionIni.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
            gridConcilacionIni.Rows(e.RowIndex).DefaultCellStyle.Font = FuenteFila
        End If
    End Sub

    Private Sub gridPerdidos_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles gridPerdidos.CellBeginEdit
        If gridPerdidos.Rows(e.RowIndex).Cells("TIPO").Value = "S" Then
            If e.ColumnIndex <> 14 Then
                e.Cancel = True
                Exit Sub
            End If
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub gridPerdidos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles gridPerdidos.CellValueChanged
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If gridPerdidos.Rows(e.RowIndex).Cells("TIPO").Value = "S" Then
            If Not gridPerdidos.Rows(e.RowIndex).Cells("MOTIVO").Value Is DBNull.Value Then
                If (Trim(gridPerdidos.Rows(e.RowIndex).Cells("MOTIVO").Value) <> "") Then
                    gridPerdidos.Rows(e.RowIndex).Cells("CAMBIO").Value = "S"
                Else
                    gridPerdidos.Rows(e.RowIndex).Cells("CAMBIO").Value = "N"
                End If
            Else
                gridPerdidos.Rows(e.RowIndex).Cells("MOTIVO").Value = ""
                gridPerdidos.Rows(e.RowIndex).Cells("CAMBIO").Value = "N"
            End If
        End If
    End Sub

    Private Sub rdSocioEncargado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdSocioEncargado.CheckedChanged
        If rdSocioEncargado.Checked Then
            rdCompleto.Checked = True
            panTipoSocios.BackColor = azul_Salles

            For Each obj As Control In panTipoSocios.Controls
                obj.Visible = True
            Next

            btnHabilitar.Visible = False
            btnGuardar.Visible = False
        End If
    End Sub
    Private Sub rdIndividual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdIndividual.CheckedChanged
        If rdIndividual.Checked Then
            rdCompleto.Checked = True
            panTipoSocios.BackColor = Color.WhiteSmoke

            For Each obj As Control In panTipoSocios.Controls
                obj.Visible = False
            Next

            btnHabilitar.Visible = True
            btnGuardar.Visible = True
        End If
    End Sub
    Private Sub rdCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles rdCompleto.CheckedChanged
        If rdCompleto.Checked Then
            btnBuscar.Enabled = False
            txtSocio.BackColor = Color.LightGray
            sTipoSocio = ""
            sNumeroSocio = ""
            txtSocio.Text = ""
        End If
    End Sub
    Private Sub rdSocio_CheckedChanged(sender As Object, e As EventArgs) Handles rdSocio.CheckedChanged
        If rdSocio.Checked Then
            btnBuscar.Enabled = True
            txtSocio.BackColor = Color.WhiteSmoke
            sTipoSocio = ""
            sNumeroSocio = ""
            txtSocio.Text = ""
        End If
    End Sub

    Private Sub lblRegresar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRegresar.LinkClicked
        tabPaginas.SelectedIndex = 1
    End Sub

    Private Sub tabPaginas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabPaginas.SelectedIndexChanged
        If tabPaginas.SelectedIndex = 1 Then
            lblRegresar.Enabled = False
        Else
            lblRegresar.Enabled = True
        End If
    End Sub

    Private Sub gridConciliacion_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridConciliacion.CellFormatting
        gridConciliacion.Rows(e.RowIndex).Cells("CONCEPTO").Style.BackColor = Color.WhiteSmoke
        gridConciliacion.Rows(e.RowIndex).Cells("CONCEPTO").Style.ForeColor = Color.Black
        gridConciliacion.Rows(e.RowIndex).Cells("CONCEPTO").Style.Font = FuenteFila
    End Sub
    Private Sub gridPerdidos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridPerdidos.CellFormatting
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        formatoDiseñoGridTotales(gridPerdidos, e.RowIndex)

        If gridPerdidos.Rows(e.RowIndex).Cells("TIPO").Value = "S" Then
            If Trim(gridPerdidos.Rows(e.RowIndex).Cells("MOTIVO").Value) = "" Then
                gridPerdidos.Rows(e.RowIndex).Cells("CVETRABAJO").Style.BackColor = Color.LemonChiffon
            End If
        End If
    End Sub
    Private Sub gridNoRecurrentes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridNoRecurrentes.CellFormatting
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        formatoDiseñoGridTotales(gridNoRecurrentes, e.RowIndex)
    End Sub
    Private Sub gridRNA_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridRNA.CellFormatting
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        formatoDiseñoGridTotales(gridRNA, e.RowIndex)
    End Sub
    Private Sub gridPendientes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridPendientes.CellFormatting
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        formatoDiseñoGridTotales(gridPendientes, e.RowIndex)
    End Sub
    Private Sub gridRecurrentes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridRecurrentes.CellFormatting
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        formatoDiseñoGridTotales(gridRecurrentes, e.RowIndex)
    End Sub
    Private Sub gridNuevos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridNuevos.CellFormatting
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        formatoDiseñoGridTotales(gridNuevos, e.RowIndex)
    End Sub
    Private Sub gridRechazadas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridRechazadas.CellFormatting
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        formatoDiseñoGridTotales(gridRechazadas, e.RowIndex)
    End Sub

    Private Sub gridConciliacion_DoubleClick(sender As Object, e As EventArgs) Handles gridConciliacion.DoubleClick
        If Not gridConciliacion.CurrentRow Is Nothing Then
            If gridConciliacion.CurrentRow.Cells("TIPO").Value = "S" Then
                Select Case CInt(gridConciliacion.CurrentRow.Cells("ID").Value)
                    Case 0 'Conciliación inicial.
                        tabPaginas.SelectedIndex = 0

                    Case 2 'Trabajos No Recurrentes.
                        tabPaginas.SelectedIndex = 2
                        'tabPaginas.SelectTab(2)
                        gridNoRecurrentes.CurrentCell = gridNoRecurrentes(10, gridNoRecurrentes.Rows.Count - 1)
                        'gridNoRecurrentes.FirstDisplayedScrollingColumnIndex = 10

                    Case 3 'Trabajos Perdidos.
                        tabPaginas.SelectedIndex = 3
                        gridPerdidos.CurrentCell = gridPerdidos(10, gridPerdidos.Rows.Count - 1)
                        'gridPerdidos.FirstDisplayedScrollingColumnIndex = 10

                    Case 4 'Trabajos Recurrentes por Arreglar.
                        tabPaginas.SelectedIndex = 4
                        gridRNA.CurrentCell = gridRNA(9, gridRNA.Rows.Count - 1)
                        'gridRNA.FirstDisplayedScrollingColumnIndex = 9

                    Case 5 'Clientes Ganados.
                        tabPaginas.SelectedIndex = 5
                        gridNuevos.CurrentCell = gridNuevos(13, gridNuevos.Rows.Count - 1)
                        'gridNuevos.FirstDisplayedScrollingColumnIndex = 11

                    Case 6 'Recurrentes Arreglados.
                        tabPaginas.SelectedIndex = 6
                        gridRecurrentes.CurrentCell = gridRecurrentes(18, gridRecurrentes.Rows.Count - 1)
                       'gridRecurrentes.FirstDisplayedScrollingColumnIndex = 18

                    Case 13 'Propuestas por Resolver.
                        tabPaginas.SelectedIndex = 7
                        gridPendientes.CurrentCell = gridPendientes(11, gridPendientes.Rows.Count - 1)
                        'gridPendientes.FirstDisplayedScrollingColumnIndex = 9

                    Case 14 'Propuestas Rechazadas.
                        tabPaginas.SelectedIndex = 8
                        gridRechazadas.CurrentCell = gridRechazadas(11, gridRechazadas.Rows.Count - 1)
                        'gridRechazadas.FirstDisplayedScrollingColumnIndex = 9
                End Select
            End If
        End If
    End Sub
    Private Sub gridRecurrentes_DoubleClick(sender As Object, e As EventArgs) Handles gridRecurrentes.DoubleClick
        'If rdSocioEncargado.Checked Then
        '    Exit Sub
        'End If

        'If Not gridRecurrentes.CurrentRow Is Nothing Then
        '    If gridRecurrentes.CurrentRow.Cells("TIPO").Value = "S" And gridRecurrentes.CurrentRow.Cells("TIPOPROP").Value = "NVO. RECURRENTE" Then
        '        Dim dlg As New DlgClavesNoRecurrentes

        '        dlg.dtPermisos = dtPermisosSoc
        '        dlg.sCveCte = gridRecurrentes.CurrentRow.Cells("CVETRABAJO").Value.ToString.Substring(0, 8)
        '        dlg.sCveRec = gridRecurrentes.CurrentRow.Cells("CVETRABAJO").Value & " - " & gridRecurrentes.CurrentRow.Cells("EMPRESA").Value
        '        dlg.sCveTraNva = gridRecurrentes.CurrentRow.Cells("CVETRABAJO").Value

        '        If dlg.ShowDialog() = DialogResult.OK Then
        '            MsgBox("Para ver la información actualizada, genere nuevamente el reporte, por favor.", MsgBoxStyle.Information, "SIAT")
        '        End If
        '    ElseIf gridRecurrentes.CurrentRow.Cells("TIPO").Value = "S" And gridRecurrentes.CurrentRow.Cells("TIPOPROP").Value = "PRESUPUESTO" Then
        '        Dim dlg As New DlgClavesNoRecurrentesPpto

        '        dlg.dtPermisos = dtPermisosSoc
        '        dlg.sCveCte = gridRecurrentes.CurrentRow.Cells("CVETRABAJO").Value.ToString.Substring(0, 8)
        '        dlg.sCvePpto = gridRecurrentes.CurrentRow.Cells("CVETRABAJO").Value & " - " & gridRecurrentes.CurrentRow.Cells("EMPRESA").Value
        '        dlg.sCvePptoNva = gridRecurrentes.CurrentRow.Cells("CVETRABAJO").Value

        '        If dlg.ShowDialog() = DialogResult.OK Then
        '            MsgBox("Para ver la información actualizada, genere nuevamente el reporte, por favor.", MsgBoxStyle.Information, "SIAT")
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub gridPerdidos_DoubleClick(sender As Object, e As EventArgs) Handles gridPerdidos.DoubleClick
        'If rdSocioEncargado.Checked Then
        '    Exit Sub
        'End If

        'If Not gridPerdidos.CurrentRow Is Nothing Then
        '    If gridPerdidos.CurrentRow.Cells("TIPO").Value = "S" Then
        '        Dim dlg As New DlgPerdidosNoRec

        '        dlg.sCveTra = gridPerdidos.CurrentRow.Cells("CVETRABAJO").Value.ToString
        '        dlg.sNombreCte = gridPerdidos.CurrentRow.Cells("EMPRESA").Value
        '        dlg.dHonorarios = CDbl(gridPerdidos.CurrentRow.Cells("HONORARIOSACTUAL").Value)

        '        If dlg.ShowDialog() = DialogResult.OK Then
        '            MsgBox("Para ver la información actualizada, genere nuevamente el reporte, por favor.", MsgBoxStyle.Information, "SIAT")
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub gridNoRecurrentes_DoubleClick(sender As Object, e As EventArgs) Handles gridNoRecurrentes.DoubleClick
        'If rdSocioEncargado.Checked Then
        '    Exit Sub
        'End If

        'If Not gridNoRecurrentes.CurrentRow Is Nothing Then
        '    If gridNoRecurrentes.CurrentRow.Cells("TIPO").Value = "S" Then
        '        Dim dlg As New DlgNoRecPerdidos

        '        dlg.sCveTra = gridNoRecurrentes.CurrentRow.Cells("CVETRABAJO").Value.ToString
        '        dlg.sNombreCte = gridNoRecurrentes.CurrentRow.Cells("EMPRESA").Value
        '        dlg.dHonorarios = CDbl(gridNoRecurrentes.CurrentRow.Cells("HONORARIOSACTUAL").Value)

        '        If dlg.ShowDialog() = DialogResult.OK Then
        '            MsgBox("Para ver la información actualizada, genere nuevamente el reporte, por favor.", MsgBoxStyle.Information, "SIAT")
        '        End If
        '    End If
        'End If
    End Sub

#End Region

#Region "SUBS"

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
        dtConcilEnc = New DataTable
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
    Private Sub crearTablaSocio()
        dtConcilSoc = New DataTable
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

    'Private Sub CrearTablas()
    '    'NO RECURRENTES
    '    dtNoRecurrentesConcil.Columns.Add("TIPO", GetType(System.String))
    '    dtNoRecurrentesConcil.Columns.Add("PERIODO", GetType(System.String))
    '    dtNoRecurrentesConcil.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
    '    dtNoRecurrentesConcil.Columns.Add("MONEDA", GetType(System.String))
    '    dtNoRecurrentesConcil.Columns.Add("SOCIO", GetType(System.String))
    '    dtNoRecurrentesConcil.Columns.Add("OFICINA", GetType(System.String))
    '    dtNoRecurrentesConcil.Columns.Add("DIVISION", GetType(System.String))
    '    dtNoRecurrentesConcil.Columns.Add("CVETRABAJO", GetType(System.String))
    '    dtNoRecurrentesConcil.Columns.Add("EMPRESA", GetType(System.String))
    '    dtNoRecurrentesConcil.Columns.Add("SERVICIO", GetType(System.String))
    '    dtNoRecurrentesConcil.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))

    '    'PERDIDOS
    '    dtPeridosConcil.Columns.Add("TIPO", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("CAMBIO", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("CVEOFI", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("CVEAREA", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("PERIODO", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("MONEDA", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("SOCIO", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("OFICINA", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("DIVISION", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("CVETRABAJO", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("EMPRESA", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("SERVICIO", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))
    '    dtPeridosConcil.Columns.Add("MOTIVO", GetType(System.String))

    '    'NO ARREGLADOS
    '    dtNoArregladosConcil.Columns.Add("TIPO", GetType(System.String))
    '    dtNoArregladosConcil.Columns.Add("PERIODO", GetType(System.String))
    '    dtNoArregladosConcil.Columns.Add("MONEDA", GetType(System.String))
    '    dtNoArregladosConcil.Columns.Add("SOCIO", GetType(System.String))
    '    dtNoArregladosConcil.Columns.Add("OFICINA", GetType(System.String))
    '    dtNoArregladosConcil.Columns.Add("DIVISION", GetType(System.String))
    '    dtNoArregladosConcil.Columns.Add("CVETRABAJO", GetType(System.String))
    '    dtNoArregladosConcil.Columns.Add("EMPRESA", GetType(System.String))
    '    dtNoArregladosConcil.Columns.Add("SERVICIO", GetType(System.String))
    '    dtNoArregladosConcil.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
    '    dtNoArregladosConcil.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))

    '    'TRABAJOS NUEVOS GANADOS
    '    dtNuevasGan.Columns.Add("TIPO", GetType(System.String))
    '    dtNuevasGan.Columns.Add("PERIODO", GetType(System.String))
    '    dtNuevasGan.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
    '    dtNuevasGan.Columns.Add("MONEDA", GetType(System.String))
    '    dtNuevasGan.Columns.Add("SOCIO", GetType(System.String))
    '    dtNuevasGan.Columns.Add("OFICINA", GetType(System.String))
    '    dtNuevasGan.Columns.Add("DIVISION", GetType(System.String))
    '    dtNuevasGan.Columns.Add("CVETRABAJO", GetType(System.String))
    '    dtNuevasGan.Columns.Add("EMPRESA", GetType(System.String))
    '    dtNuevasGan.Columns.Add("DESCRIPCION", GetType(System.String))
    '    dtNuevasGan.Columns.Add("SERVICIO", GetType(System.String))
    '    dtNuevasGan.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))

    '    'TRABAJOS RECURRENTES
    '    dtRecurrentes.Columns.Add("TIPO", GetType(System.String))
    '    dtRecurrentes.Columns.Add("PERIODO", GetType(System.String))
    '    dtRecurrentes.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
    '    dtRecurrentes.Columns.Add("HONORARIOSANTERIOR", GetType(System.String))
    '    dtRecurrentes.Columns.Add("DIFERENCIA", GetType(System.String))
    '    dtRecurrentes.Columns.Add("VARIACION", GetType(System.String))
    '    dtRecurrentes.Columns.Add("MONEDA", GetType(System.String))
    '    dtRecurrentes.Columns.Add("SOCIO", GetType(System.String))
    '    dtRecurrentes.Columns.Add("OFICINA", GetType(System.String))
    '    dtRecurrentes.Columns.Add("DIVISION", GetType(System.String))
    '    dtRecurrentes.Columns.Add("CVETRABAJO", GetType(System.String))
    '    dtRecurrentes.Columns.Add("EMPRESA", GetType(System.String))
    '    dtRecurrentes.Columns.Add("DESCRIPCION", GetType(System.String))
    '    dtRecurrentes.Columns.Add("SERVICIO", GetType(System.String))
    '    dtRecurrentes.Columns.Add("TIPOPROP", GetType(System.String))
    '    dtRecurrentes.Columns.Add("HONORARIOSPPTO", GetType(System.String))
    '    dtRecurrentes.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))
    '    dtRecurrentes.Columns.Add("HONORARIOSANTERIORMN", GetType(System.String))
    '    dtRecurrentes.Columns.Add("DIFERENCIAMN", GetType(System.String))

    '    'POR RESOLVER
    '    dtPendientes.Columns.Add("TIPO", GetType(System.String))
    '    dtPendientes.Columns.Add("PERIODO", GetType(System.String))
    '    dtPendientes.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
    '    dtPendientes.Columns.Add("MONEDA", GetType(System.String))
    '    dtPendientes.Columns.Add("SOCIO", GetType(System.String))
    '    dtPendientes.Columns.Add("OFICINA", GetType(System.String))
    '    dtPendientes.Columns.Add("DIVISION", GetType(System.String))
    '    dtPendientes.Columns.Add("EMPRESA", GetType(System.String))
    '    dtPendientes.Columns.Add("SERVICIO", GetType(System.String))
    '    dtPendientes.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))
    '    dtPendientes.Columns.Add("FECHAPROPUESTA", GetType(System.String))

    '    'RECHAZADOS
    '    dtRechazadas.Columns.Add("TIPO", GetType(System.String))
    '    dtRechazadas.Columns.Add("PERIODO", GetType(System.String))
    '    dtRechazadas.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
    '    dtRechazadas.Columns.Add("MONEDA", GetType(System.String))
    '    dtRechazadas.Columns.Add("SOCIO", GetType(System.String))
    '    dtRechazadas.Columns.Add("OFICINA", GetType(System.String))
    '    dtRechazadas.Columns.Add("DIVISION", GetType(System.String))
    '    dtRechazadas.Columns.Add("EMPRESA", GetType(System.String))
    '    dtRechazadas.Columns.Add("SERVICIO", GetType(System.String))
    '    dtRechazadas.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))
    '    dtRechazadas.Columns.Add("DESCRECHAZO", GetType(System.String))

    '    dtHonNoRec = New DataTable
    '    dtHonNoRec.Columns.Add("HONORARIOS", GetType(System.String))
    '    dtHonNoRec.Columns.Add("OFICINA", GetType(System.String))
    '    dtHonNoRec.Columns.Add("DIVISION", GetType(System.String))

    '    dtHonPer = New DataTable
    '    dtHonPer.Columns.Add("HONORARIOS", GetType(System.String))
    '    dtHonPer.Columns.Add("OFICINA", GetType(System.String))
    '    dtHonPer.Columns.Add("DIVISION", GetType(System.String))

    '    dtHonRecNoArr = New DataTable
    '    dtHonRecNoArr.Columns.Add("HONORARIOS", GetType(System.String))
    '    dtHonRecNoArr.Columns.Add("OFICINA", GetType(System.String))
    '    dtHonRecNoArr.Columns.Add("DIVISION", GetType(System.String))

    '    dtHonNuevas = New DataTable
    '    dtHonNuevas.Columns.Add("HONORARIOS", GetType(System.String))
    '    dtHonNuevas.Columns.Add("OFICINA", GetType(System.String))
    '    dtHonNuevas.Columns.Add("DIVISION", GetType(System.String))

    '    dtHonResolver = New DataTable
    '    dtHonResolver.Columns.Add("HONORARIOS", GetType(System.String))
    '    dtHonResolver.Columns.Add("OFICINA", GetType(System.String))
    '    dtHonResolver.Columns.Add("DIVISION", GetType(System.String))

    '    dtHonRech = New DataTable
    '    dtHonRech.Columns.Add("HONORARIOS", GetType(System.String))
    '    dtHonRech.Columns.Add("OFICINA", GetType(System.String))
    '    dtHonRech.Columns.Add("DIVISION", GetType(System.String))

    '    dtHonRec = New DataTable
    '    dtHonRec.Columns.Add("CVETRA", GetType(System.String))
    '    dtHonRec.Columns.Add("CVEPPTO", GetType(System.String))
    '    dtHonRec.Columns.Add("HONORARIOS", GetType(System.String))
    '    dtHonRec.Columns.Add("OFICINA", GetType(System.String))
    '    dtHonRec.Columns.Add("DIVISION", GetType(System.String))
    '    dtHonRec.Columns.Add("TIPOPROP", GetType(System.String))

    '    dtHonTotPro = New DataTable
    '    dtHonTotPro.Columns.Add("HONORARIOS", GetType(System.String))
    '    dtHonTotPro.Columns.Add("OFICINA", GetType(System.String))
    '    dtHonTotPro.Columns.Add("DIVISION", GetType(System.String))

    '    dtDiferenciaPpto = New DataTable
    '    dtDiferenciaPpto.Columns.Add("SOCIO", GetType(System.String))
    '    dtDiferenciaPpto.Columns.Add("HONORARIOSPPTO", GetType(System.String))
    '    dtDiferenciaPpto.Columns.Add("HONORARIOSFAC", GetType(System.String))
    '    dtDiferenciaPpto.Columns.Add("OFICINA", GetType(System.String))
    '    dtDiferenciaPpto.Columns.Add("DIVISION", GetType(System.String))

    '    dtTransfSoc = New DataTable
    '    dtTransfSoc.Columns.Add("HONORARIOSFAC", GetType(System.String))
    '    dtTransfSoc.Columns.Add("OFICINA", GetType(System.String))
    '    dtTransfSoc.Columns.Add("DIVISION", GetType(System.String))

    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'End Sub

    Private Sub CrearTablas()
        'NO RECURRENTES
        dtNoRecurrentesConcil.Columns.Add("TIPO", GetType(System.String))
        dtNoRecurrentesConcil.Columns.Add("PERIODO", GetType(System.String))
        dtNoRecurrentesConcil.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
        dtNoRecurrentesConcil.Columns.Add("MONEDA", GetType(System.String))
        dtNoRecurrentesConcil.Columns.Add("SOCIO", GetType(System.String))
        dtNoRecurrentesConcil.Columns.Add("OFICINA", GetType(System.String))
        dtNoRecurrentesConcil.Columns.Add("DIVISION", GetType(System.String))
        dtNoRecurrentesConcil.Columns.Add("CVETRABAJO", GetType(System.String))
        dtNoRecurrentesConcil.Columns.Add("EMPRESA", GetType(System.String))
        dtNoRecurrentesConcil.Columns.Add("SERVICIO", GetType(System.String))
        dtNoRecurrentesConcil.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))

        'PERDIDOS
        dtPeridosConcil.Columns.Add("TIPO", GetType(System.String))
        dtPeridosConcil.Columns.Add("CAMBIO", GetType(System.String))
        dtPeridosConcil.Columns.Add("CVEOFI", GetType(System.String))
        dtPeridosConcil.Columns.Add("CVEAREA", GetType(System.String))
        dtPeridosConcil.Columns.Add("PERIODO", GetType(System.String))
        dtPeridosConcil.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
        dtPeridosConcil.Columns.Add("MONEDA", GetType(System.String))
        dtPeridosConcil.Columns.Add("SOCIO", GetType(System.String))
        dtPeridosConcil.Columns.Add("OFICINA", GetType(System.String))
        dtPeridosConcil.Columns.Add("DIVISION", GetType(System.String))
        dtPeridosConcil.Columns.Add("CVETRABAJO", GetType(System.String))
        dtPeridosConcil.Columns.Add("EMPRESA", GetType(System.String))
        dtPeridosConcil.Columns.Add("SERVICIO", GetType(System.String))
        dtPeridosConcil.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))
        dtPeridosConcil.Columns.Add("MOTIVO", GetType(System.String))

        'NO ARREGLADOS
        dtNoArregladosConcil.Columns.Add("TIPO", GetType(System.String))
        dtNoArregladosConcil.Columns.Add("PERIODO", GetType(System.String))
        dtNoArregladosConcil.Columns.Add("MONEDA", GetType(System.String))
        dtNoArregladosConcil.Columns.Add("SOCIO", GetType(System.String))
        dtNoArregladosConcil.Columns.Add("OFICINA", GetType(System.String))
        dtNoArregladosConcil.Columns.Add("DIVISION", GetType(System.String))
        dtNoArregladosConcil.Columns.Add("CVETRABAJO", GetType(System.String))
        dtNoArregladosConcil.Columns.Add("EMPRESA", GetType(System.String))
        dtNoArregladosConcil.Columns.Add("SERVICIO", GetType(System.String))
        dtNoArregladosConcil.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
        dtNoArregladosConcil.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))

        'TRABAJOS NUEVOS GANADOS
        dtNuevasGan.Columns.Add("TIPO", GetType(System.String))
        dtNuevasGan.Columns.Add("PERIODO", GetType(System.String))
        dtNuevasGan.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
        dtNuevasGan.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))
        dtNuevasGan.Columns.Add("MONEDA", GetType(System.String))
        dtNuevasGan.Columns.Add("SOCIO", GetType(System.String))
        dtNuevasGan.Columns.Add("OFICINA", GetType(System.String))
        dtNuevasGan.Columns.Add("DIVISION", GetType(System.String))
        dtNuevasGan.Columns.Add("CVETRABAJO", GetType(System.String))
        dtNuevasGan.Columns.Add("CICLO", GetType(System.String))
        dtNuevasGan.Columns.Add("EMPRESA", GetType(System.String))
        dtNuevasGan.Columns.Add("DESCRIPCION", GetType(System.String))
        dtNuevasGan.Columns.Add("SERVICIO", GetType(System.String))
        dtNuevasGan.Columns.Add("HONETOS", GetType(System.String))

        dtNuevasGan.Columns.Add("HORCOTIZADAS", GetType(System.String))
        dtNuevasGan.Columns.Add("CUOTA", GetType(System.String))
        dtNuevasGan.Columns.Add("WOFF", GetType(System.String))
        dtNuevasGan.Columns.Add("INDUSTRIA", GetType(System.String))
        dtNuevasGan.Columns.Add("SUBSECTOR", GetType(System.String))

        dtNuevasGan.Columns.Add("COMO", GetType(System.String))

        dtNuevasGan.Columns.Add("REFGTSOCIO", GetType(System.String))
        dtNuevasGan.Columns.Add("REFGTOFI", GetType(System.String))
        dtNuevasGan.Columns.Add("REFGTPAIS", GetType(System.String))

        dtNuevasGan.Columns.Add("MEDIO", GetType(System.String))

        dtNuevasGan.Columns.Add("REFNOMB", GetType(System.String))
        dtNuevasGan.Columns.Add("PUESTO", GetType(System.String))
        dtNuevasGan.Columns.Add("REFOFI", GetType(System.String))
        dtNuevasGan.Columns.Add("REFDIV", GetType(System.String))


        'TRABAJOS RECURRENTES
        dtRecurrentes.Columns.Add("TIPO", GetType(System.String))
        dtRecurrentes.Columns.Add("PERIODO", GetType(System.String))
        dtRecurrentes.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
        dtRecurrentes.Columns.Add("HONORARIOSANTERIOR", GetType(System.String))
        dtRecurrentes.Columns.Add("DIFERENCIA", GetType(System.String))
        dtRecurrentes.Columns.Add("VARIACION", GetType(System.String))
        dtRecurrentes.Columns.Add("MONEDA", GetType(System.String))
        dtRecurrentes.Columns.Add("SOCIO", GetType(System.String))
        dtRecurrentes.Columns.Add("OFICINA", GetType(System.String))
        dtRecurrentes.Columns.Add("DIVISION", GetType(System.String))
        dtRecurrentes.Columns.Add("CVETRABAJO", GetType(System.String))
        dtRecurrentes.Columns.Add("EMPRESA", GetType(System.String))
        dtRecurrentes.Columns.Add("DESCRIPCION", GetType(System.String))
        dtRecurrentes.Columns.Add("SERVICIO", GetType(System.String))
        dtRecurrentes.Columns.Add("TIPOPROP", GetType(System.String))
        dtRecurrentes.Columns.Add("HONORARIOSPPTO", GetType(System.String))
        dtRecurrentes.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))
        dtRecurrentes.Columns.Add("HONORARIOSANTERIORMN", GetType(System.String))
        dtRecurrentes.Columns.Add("DIFERENCIAMN", GetType(System.String))


        'POR RESOLVER
        dtPendientes.Columns.Add("TIPO", GetType(System.String))
        dtPendientes.Columns.Add("PERIODO", GetType(System.String))
        dtPendientes.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
        dtPendientes.Columns.Add("HONETOS", GetType(System.String))
        dtPendientes.Columns.Add("MONEDA", GetType(System.String))
        dtPendientes.Columns.Add("SOCIO", GetType(System.String))
        dtPendientes.Columns.Add("OFICINA", GetType(System.String))
        dtPendientes.Columns.Add("DIVISION", GetType(System.String))
        dtPendientes.Columns.Add("CICLO", GetType(System.String))
        dtPendientes.Columns.Add("EMPRESA", GetType(System.String))
        dtPendientes.Columns.Add("SERVICIO", GetType(System.String))
        dtPendientes.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))
        dtPendientes.Columns.Add("FECHAPROPUESTA", GetType(System.String))

        dtPendientes.Columns.Add("HORCOTIZADAS", GetType(System.String))
        dtPendientes.Columns.Add("CUOTA", GetType(System.String))
        dtPendientes.Columns.Add("WOFF", GetType(System.String))
        dtPendientes.Columns.Add("INDUSTRIA", GetType(System.String))
        dtPendientes.Columns.Add("SUBSECTOR", GetType(System.String))

        dtPendientes.Columns.Add("COMO", GetType(System.String))

        dtPendientes.Columns.Add("REFGTSOCIO", GetType(System.String))
        dtPendientes.Columns.Add("REFGTOFI", GetType(System.String))
        dtPendientes.Columns.Add("REFGTPAIS", GetType(System.String))

        dtPendientes.Columns.Add("MEDIO", GetType(System.String))

        dtPendientes.Columns.Add("REFNOMB", GetType(System.String))
        dtPendientes.Columns.Add("PUESTO", GetType(System.String))
        dtPendientes.Columns.Add("REFOFI", GetType(System.String))
        dtPendientes.Columns.Add("REFDIV", GetType(System.String))

        'RECHAZADOS
        dtRechazadas.Columns.Add("TIPO", GetType(System.String))
        dtRechazadas.Columns.Add("PERIODO", GetType(System.String))
        dtRechazadas.Columns.Add("HONORARIOSACTUAL", GetType(System.String))
        dtRechazadas.Columns.Add("HONETOS", GetType(System.String))
        dtRechazadas.Columns.Add("MONEDA", GetType(System.String))
        dtRechazadas.Columns.Add("SOCIO", GetType(System.String))
        dtRechazadas.Columns.Add("OFICINA", GetType(System.String))
        dtRechazadas.Columns.Add("DIVISION", GetType(System.String))
        dtRechazadas.Columns.Add("CICLO", GetType(System.String))
        dtRechazadas.Columns.Add("EMPRESA", GetType(System.String))
        dtRechazadas.Columns.Add("SERVICIO", GetType(System.String))
        dtRechazadas.Columns.Add("HONORARIOSARREGLADOMN", GetType(System.String))
        dtRechazadas.Columns.Add("DESCRECHAZO", GetType(System.String))


        dtRechazadas.Columns.Add("HORCOTIZADAS", GetType(System.String))
        dtRechazadas.Columns.Add("CUOTA", GetType(System.String))
        dtRechazadas.Columns.Add("WOFF", GetType(System.String))
        dtRechazadas.Columns.Add("INDUSTRIA", GetType(System.String))
        dtRechazadas.Columns.Add("SUBSECTOR", GetType(System.String))

        dtRechazadas.Columns.Add("COMO", GetType(System.String))

        dtRechazadas.Columns.Add("REFGTSOCIO", GetType(System.String))
        dtRechazadas.Columns.Add("REFGTOFI", GetType(System.String))
        dtRechazadas.Columns.Add("REFGTPAIS", GetType(System.String))

        dtRechazadas.Columns.Add("MEDIO", GetType(System.String))

        dtRechazadas.Columns.Add("REFNOMB", GetType(System.String))
        dtRechazadas.Columns.Add("PUESTO", GetType(System.String))
        dtRechazadas.Columns.Add("REFOFI", GetType(System.String))
        dtRechazadas.Columns.Add("REFDIV", GetType(System.String))

        dtHonNoRec = New DataTable
        dtHonNoRec.Columns.Add("HONORARIOS", GetType(System.String))
        dtHonNoRec.Columns.Add("OFICINA", GetType(System.String))
        dtHonNoRec.Columns.Add("DIVISION", GetType(System.String))

        dtHonPer = New DataTable
        dtHonPer.Columns.Add("HONORARIOS", GetType(System.String))
        dtHonPer.Columns.Add("OFICINA", GetType(System.String))
        dtHonPer.Columns.Add("DIVISION", GetType(System.String))

        dtHonRecNoArr = New DataTable
        dtHonRecNoArr.Columns.Add("HONORARIOS", GetType(System.String))
        dtHonRecNoArr.Columns.Add("OFICINA", GetType(System.String))
        dtHonRecNoArr.Columns.Add("DIVISION", GetType(System.String))

        dtHonNuevas = New DataTable
        dtHonNuevas.Columns.Add("HONORARIOS", GetType(System.String))
        dtHonNuevas.Columns.Add("OFICINA", GetType(System.String))
        dtHonNuevas.Columns.Add("DIVISION", GetType(System.String))

        dtHonResolver = New DataTable
        dtHonResolver.Columns.Add("HONORARIOS", GetType(System.String))
        dtHonResolver.Columns.Add("OFICINA", GetType(System.String))
        dtHonResolver.Columns.Add("DIVISION", GetType(System.String))

        dtHonRech = New DataTable
        dtHonRech.Columns.Add("HONORARIOS", GetType(System.String))
        dtHonRech.Columns.Add("OFICINA", GetType(System.String))
        dtHonRech.Columns.Add("DIVISION", GetType(System.String))

        dtHonRec = New DataTable
        dtHonRec.Columns.Add("CVETRA", GetType(System.String))
        dtHonRec.Columns.Add("CVEPPTO", GetType(System.String))
        dtHonRec.Columns.Add("HONORARIOS", GetType(System.String))
        dtHonRec.Columns.Add("OFICINA", GetType(System.String))
        dtHonRec.Columns.Add("DIVISION", GetType(System.String))
        dtHonRec.Columns.Add("TIPOPROP", GetType(System.String))

        dtHonTotPro = New DataTable
        dtHonTotPro.Columns.Add("HONORARIOS", GetType(System.String))
        dtHonTotPro.Columns.Add("OFICINA", GetType(System.String))
        dtHonTotPro.Columns.Add("DIVISION", GetType(System.String))

        dtDiferenciaPpto = New DataTable
        dtDiferenciaPpto.Columns.Add("SOCIO", GetType(System.String))
        dtDiferenciaPpto.Columns.Add("HONORARIOSPPTO", GetType(System.String))
        dtDiferenciaPpto.Columns.Add("HONORARIOSFAC", GetType(System.String))
        dtDiferenciaPpto.Columns.Add("OFICINA", GetType(System.String))
        dtDiferenciaPpto.Columns.Add("DIVISION", GetType(System.String))

        dtTransfSoc = New DataTable
        dtTransfSoc.Columns.Add("HONORARIOSFAC", GetType(System.String))
        dtTransfSoc.Columns.Add("OFICINA", GetType(System.String))
        dtTransfSoc.Columns.Add("DIVISION", GetType(System.String))

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub
    Private Sub FormatoGrid()
        bloquearColumnas(gridConciliacion)
        gridConciliacion.Columns("TIPO").Visible = False
        gridConciliacion.Columns("ID").Visible = False

        gridConciliacion.Columns("TIPO").Frozen = True
        gridConciliacion.Columns("ID").Frozen = True
        gridConciliacion.Columns("CONCEPTO").Frozen = True

        gridConciliacion.Columns("CONCEPTO").HeaderText = "CONCEPTO"
        gridConciliacion.Columns("CONCEPTO").Width = 400

        For Each row As DataRow In dtPermisosEnc.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                Continue For
            End If

            gridConciliacion.Columns(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")).HeaderText = nomOfi(row.Item("CVEOFI")) & " - " & nomDiv(row.Item("CVEAREA"))
            gridConciliacion.Columns(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")).Width = 110
            gridConciliacion.Columns(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridConciliacion.Columns(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")).DefaultCellStyle.Format = "c"
        Next

        gridConciliacion.Columns("TOTAL").HeaderText = "TOTAL"
        gridConciliacion.Columns("TOTAL").Width = 110
        gridConciliacion.Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub FormatoGridSocio()
        bloquearColumnas(gridConciliacion)
        gridConciliacion.Columns("TIPO").Visible = False
        gridConciliacion.Columns("ID").Visible = False

        gridConciliacion.Columns("TIPO").Frozen = True
        gridConciliacion.Columns("ID").Frozen = True
        gridConciliacion.Columns("CONCEPTO").Frozen = True

        gridConciliacion.Columns("CONCEPTO").HeaderText = "CONCEPTO"
        gridConciliacion.Columns("CONCEPTO").Width = 400

        For Each row As DataRow In dtPermisosSoc.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                Continue For
            End If

            gridConciliacion.Columns(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")).HeaderText = nomOfi(row.Item("CVEOFI")) & " - " & nomDiv(row.Item("CVEAREA"))
            gridConciliacion.Columns(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")).Width = 110
            gridConciliacion.Columns(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next

        gridConciliacion.Columns("TOTAL").HeaderText = "TOTAL"
        gridConciliacion.Columns("TOTAL").Width = 110
        gridConciliacion.Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub FormatoGridConcilIni()
        bloquearColumnas(gridConcilacionIni)

        gridConcilacionIni.Columns("TIPO").Visible = False
        gridConcilacionIni.Columns("IDCLAS").Visible = False
        gridConcilacionIni.Columns("TIPOTRA").Visible = False
        gridConcilacionIni.Columns("CVEOFI").Visible = False
        gridConcilacionIni.Columns("CVEAREA").Visible = False
        gridConcilacionIni.Columns("CVECTE").Visible = False
        gridConcilacionIni.Columns("SOCIO").Visible = False

        If rdIndividual.Checked Then
            gridConcilacionIni.Columns("NOMBRESOC").Visible = False
        Else
            gridConcilacionIni.Columns("NOMBRESOC").Visible = True
        End If

        gridConcilacionIni.Columns("CVESOCTRANSDE").Visible = False
        gridConcilacionIni.Columns("CVESOCTRANSA").Visible = False
        gridConcilacionIni.Columns("IMPFNPPTO").Visible = False

        'gridConcilacionIni.Columns("IMG").Frozen = True
        gridConcilacionIni.Columns("TIPO").Frozen = True
        gridConcilacionIni.Columns("IDCLAS").Frozen = True
        gridConcilacionIni.Columns("TIPOTRA").Frozen = True
        gridConcilacionIni.Columns("CVEOFI").Frozen = True
        gridConcilacionIni.Columns("CVEAREA").Frozen = True
        gridConcilacionIni.Columns("CVECTE").Frozen = True
        gridConcilacionIni.Columns("SOCIO").Frozen = True
        gridConcilacionIni.Columns("NOMBRESOC").Frozen = True
        gridConcilacionIni.Columns("CVETRA").Frozen = True

        'gridConcilacionIni.Columns("IMG").Width = 30

        If rdSocioEncargado.Checked Then
            gridConcilacionIni.Columns("NOMBRESOC").HeaderText = "SOCIO"
            gridConcilacionIni.Columns("NOMBRESOC").Width = 250
        End If

        gridConcilacionIni.Columns("CVETRA").HeaderText = "TRABAJO"
        gridConcilacionIni.Columns("CVETRA").Width = 150

        gridConcilacionIni.Columns("NOMBRECTE").HeaderText = "CLIENTE"
        gridConcilacionIni.Columns("NOMBRECTE").Width = 250

        gridConcilacionIni.Columns("DESCRIPCION").HeaderText = "DESCRIPCIÓN"
        gridConcilacionIni.Columns("DESCRIPCION").Width = 250

        gridConcilacionIni.Columns("TIPOCTE").HeaderText = "TIPO"
        gridConcilacionIni.Columns("TIPOCTE").Width = 50
        gridConcilacionIni.Columns("TIPOCTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridConcilacionIni.Columns("DESCOFI").HeaderText = "OFICINA"
        gridConcilacionIni.Columns("DESCOFI").Width = 140

        gridConcilacionIni.Columns("DESCAREA").HeaderText = "DIVISIÓN"
        gridConcilacionIni.Columns("DESCAREA").Width = 150

        gridConcilacionIni.Columns("STATUS").HeaderText = "STATUS"
        gridConcilacionIni.Columns("STATUS").Width = 50
        gridConcilacionIni.Columns("STATUS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridConcilacionIni.Columns("IMPFAC").HeaderText = "ING. FACTURADOS"
        gridConcilacionIni.Columns("IMPFAC").Width = 110
        gridConcilacionIni.Columns("IMPFAC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("PPTOFACTER").HeaderText = "PPTO. FACTURACIÓN A TERCEROS"
        gridConcilacionIni.Columns("PPTOFACTER").Width = 110
        gridConcilacionIni.Columns("PPTOFACTER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("PPTOFACINT").HeaderText = "PPTO. FACTURACIÓN INTERNA"
        gridConcilacionIni.Columns("PPTOFACINT").Width = 110
        gridConcilacionIni.Columns("PPTOFACINT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("PPTOFACTRA").HeaderText = "PPTO. TRASPASOS DE FACTURACIÓN"
        gridConcilacionIni.Columns("PPTOFACTRA").Width = 110
        gridConcilacionIni.Columns("PPTOFACTRA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("PPTOFACNET").HeaderText = "PPTO. FACTURACIÓN NETA"
        gridConcilacionIni.Columns("PPTOFACNET").Width = 110
        gridConcilacionIni.Columns("PPTOFACNET").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("PORWO").HeaderText = "% W/O"
        gridConcilacionIni.Columns("PORWO").Width = 70
        gridConcilacionIni.Columns("PORWO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridConcilacionIni.Columns("PPTOWO").HeaderText = "IMPORTE W/O"
        gridConcilacionIni.Columns("PPTOWO").Width = 110
        gridConcilacionIni.Columns("PPTOWO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("IMPNETO").HeaderText = "IMPORTE NETO"
        gridConcilacionIni.Columns("IMPNETO").Width = 110
        gridConcilacionIni.Columns("IMPNETO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("IMPVAR").HeaderText = "VARIACIÓN"
        gridConcilacionIni.Columns("IMPVAR").Width = 110
        gridConcilacionIni.Columns("IMPVAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("IMPGAN").HeaderText = "GANADO"
        gridConcilacionIni.Columns("IMPGAN").Width = 110
        gridConcilacionIni.Columns("IMPGAN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("IMPGANTRANS").HeaderText = "INCREMENTO POR TRANSFERENCIA"
        gridConcilacionIni.Columns("IMPGANTRANS").Width = 110
        gridConcilacionIni.Columns("IMPGANTRANS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("SOCIOTRANSDE").HeaderText = "SOCIO TRANSFERENCIA"
        gridConcilacionIni.Columns("SOCIOTRANSDE").Width = 300

        gridConcilacionIni.Columns("IMPCAN").HeaderText = "CANCELACIONES"
        gridConcilacionIni.Columns("IMPCAN").Width = 110
        gridConcilacionIni.Columns("IMPCAN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("IMPINC").HeaderText = "INCREMENTO"
        gridConcilacionIni.Columns("IMPINC").Width = 110
        gridConcilacionIni.Columns("IMPINC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("IMPDEC").HeaderText = "DECREMENTO" & vbNewLine & "(NO RECURRENTES)"
        gridConcilacionIni.Columns("IMPDEC").Width = 140
        gridConcilacionIni.Columns("IMPDEC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("IMPPER").HeaderText = "PÉRDIDA"
        gridConcilacionIni.Columns("IMPPER").Width = 110
        gridConcilacionIni.Columns("IMPPER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("MOTIVOPER").HeaderText = "MOTIVO PÉRDIDA"
        gridConcilacionIni.Columns("MOTIVOPER").Width = 350

        gridConcilacionIni.Columns("IMPPERTRANS").HeaderText = "DECREMENTO POR TRANSFERENCIA"
        gridConcilacionIni.Columns("IMPPERTRANS").Width = 110
        gridConcilacionIni.Columns("IMPPERTRANS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("SOCIOTRANSA").HeaderText = "SOCIO TRANSFERENCIA"
        gridConcilacionIni.Columns("SOCIOTRANSA").Width = 300

        gridConcilacionIni.Columns("MOTIVOTRANSA").HeaderText = "MOTIVO DE LA TRANSFERENCIA"
        gridConcilacionIni.Columns("MOTIVOTRANSA").Width = 350

        gridConcilacionIni.Columns("TOTAL").HeaderText = "INGRESO NETO ESTIMADO"
        gridConcilacionIni.Columns("TOTAL").Width = 110
        gridConcilacionIni.Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridConcilacionIni.Columns("SEPUNO").HeaderText = ""
        gridConcilacionIni.Columns("SEPUNO").Width = 15

        gridConcilacionIni.Columns("SEPDOS").HeaderText = ""
        gridConcilacionIni.Columns("SEPDOS").Width = 15

        gridConcilacionIni.Columns("SEPTRES").HeaderText = ""
        gridConcilacionIni.Columns("SEPTRES").Width = 15
    End Sub
    Private Sub FormatoGridNoRecurrentes()
        bloquearColumnas(gridNoRecurrentes)

        gridNoRecurrentes.Columns("TIPO").Visible = False
        gridNoRecurrentes.Columns("PERIODO").Visible = False
        gridNoRecurrentes.Columns("HONORARIOSACTUAL").Visible = False
        gridNoRecurrentes.Columns("MONEDA").Visible = False

        gridNoRecurrentes.Columns("TIPO").Frozen = True
        gridNoRecurrentes.Columns("PERIODO").Frozen = True
        gridNoRecurrentes.Columns("HONORARIOSACTUAL").Frozen = True
        gridNoRecurrentes.Columns("MONEDA").Frozen = True
        gridNoRecurrentes.Columns("SOCIO").Frozen = True
        gridNoRecurrentes.Columns("OFICINA").Frozen = True
        gridNoRecurrentes.Columns("DIVISION").Frozen = True
        gridNoRecurrentes.Columns("CVETRABAJO").Frozen = True

        gridNoRecurrentes.Columns("SOCIO").HeaderText = "SOCIO / ASOCIADO"
        gridNoRecurrentes.Columns("SOCIO").Width = 300

        gridNoRecurrentes.Columns("OFICINA").HeaderText = "OFICINA"
        gridNoRecurrentes.Columns("OFICINA").Width = 90
        gridNoRecurrentes.Columns("OFICINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridNoRecurrentes.Columns("DIVISION").HeaderText = "DIVISIÓN"
        gridNoRecurrentes.Columns("DIVISION").Width = 90
        gridNoRecurrentes.Columns("DIVISION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridNoRecurrentes.Columns("CVETRABAJO").HeaderText = "CLAVE TRABAJO"
        gridNoRecurrentes.Columns("CVETRABAJO").Width = 150

        gridNoRecurrentes.Columns("EMPRESA").HeaderText = "EMPRESA"
        gridNoRecurrentes.Columns("EMPRESA").Width = 450

        gridNoRecurrentes.Columns("SERVICIO").HeaderText = "SERVICIO"
        gridNoRecurrentes.Columns("SERVICIO").Width = 450

        gridNoRecurrentes.Columns("HONORARIOSARREGLADOMN").HeaderText = "HONORARIOS"
        gridNoRecurrentes.Columns("HONORARIOSARREGLADOMN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridNoRecurrentes.Columns("HONORARIOSARREGLADOMN").Width = 110
    End Sub
    Private Sub FormatoGridPerdidos()
        bloquearColumnas(gridPerdidos)

        gridPerdidos.Columns("TIPO").Visible = False
        gridPerdidos.Columns("PERIODO").Visible = False
        gridPerdidos.Columns("HONORARIOSACTUAL").Visible = False
        gridPerdidos.Columns("MONEDA").Visible = False
        gridPerdidos.Columns("CAMBIO").Visible = False
        gridPerdidos.Columns("CVEOFI").Visible = False
        gridPerdidos.Columns("CVEAREA").Visible = False

        gridPerdidos.Columns("TIPO").Frozen = True
        gridPerdidos.Columns("PERIODO").Frozen = True
        gridPerdidos.Columns("HONORARIOSACTUAL").Frozen = True
        gridPerdidos.Columns("MONEDA").Frozen = True
        gridPerdidos.Columns("SOCIO").Frozen = True
        gridPerdidos.Columns("OFICINA").Frozen = True
        gridPerdidos.Columns("DIVISION").Frozen = True
        gridPerdidos.Columns("CVETRABAJO").Frozen = True

        gridPerdidos.Columns("SOCIO").HeaderText = "SOCIO / ASOCIADO"
        gridPerdidos.Columns("SOCIO").Width = 300

        gridPerdidos.Columns("OFICINA").HeaderText = "OFICINA"
        gridPerdidos.Columns("OFICINA").Width = 90
        gridPerdidos.Columns("OFICINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridPerdidos.Columns("DIVISION").HeaderText = "DIVISIÓN"
        gridPerdidos.Columns("DIVISION").Width = 90
        gridPerdidos.Columns("DIVISION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridPerdidos.Columns("CVETRABAJO").HeaderText = "CLAVE DE TRABAJO"
        gridPerdidos.Columns("CVETRABAJO").Width = 150

        gridPerdidos.Columns("EMPRESA").HeaderText = "EMPRESA"
        gridPerdidos.Columns("EMPRESA").Width = 450

        gridPerdidos.Columns("SERVICIO").HeaderText = "SERVICIO"
        gridPerdidos.Columns("SERVICIO").Width = 450

        gridPerdidos.Columns("HONORARIOSARREGLADOMN").HeaderText = "HONORARIOS"
        gridPerdidos.Columns("HONORARIOSARREGLADOMN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridPerdidos.Columns("HONORARIOSARREGLADOMN").Width = 110

        gridPerdidos.Columns("MOTIVO").HeaderText = "MOTIVO DE PÉRDIDA"
        gridPerdidos.Columns("MOTIVO").Width = 450
    End Sub
    Private Sub formatoGridNoArreglados()
        bloquearColumnas(gridRNA)

        gridRNA.Columns("TIPO").Visible = False
        gridRNA.Columns("PERIODO").Visible = False
        gridRNA.Columns("MONEDA").Visible = False

        gridRNA.Columns("TIPO").Frozen = True
        gridRNA.Columns("PERIODO").Frozen = True
        gridRNA.Columns("MONEDA").Frozen = True
        gridRNA.Columns("SOCIO").Frozen = True
        gridRNA.Columns("OFICINA").Frozen = True
        gridRNA.Columns("DIVISION").Frozen = True
        gridRNA.Columns("CVETRABAJO").Frozen = True

        gridRNA.Columns("SOCIO").HeaderText = "SOCIO / ASOCIADO"
        gridRNA.Columns("SOCIO").Width = 300

        gridRNA.Columns("OFICINA").HeaderText = "OFICINA"
        gridRNA.Columns("OFICINA").Width = 90
        gridRNA.Columns("OFICINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridRNA.Columns("DIVISION").HeaderText = "DIVISIÓN"
        gridRNA.Columns("DIVISION").Width = 90
        gridRNA.Columns("DIVISION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridRNA.Columns("CVETRABAJO").HeaderText = "CVE. TRABAJO"
        gridRNA.Columns("CVETRABAJO").Width = 150

        gridRNA.Columns("EMPRESA").HeaderText = "EMPRESA"
        gridRNA.Columns("EMPRESA").Width = 450

        gridRNA.Columns("SERVICIO").HeaderText = "SERVICIO"
        gridRNA.Columns("SERVICIO").Width = 450

        gridRNA.Columns("HONORARIOSACTUAL").HeaderText = "HONORARIOS DEL CICLO ANTERIOR"
        gridRNA.Columns("HONORARIOSACTUAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridRNA.Columns("HONORARIOSACTUAL").Width = 110

        gridRNA.Columns("HONORARIOSARREGLADOMN").HeaderText = "HONORARIOS POR ARREGLAR"
        gridRNA.Columns("HONORARIOSARREGLADOMN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridRNA.Columns("HONORARIOSARREGLADOMN").Width = 110
    End Sub
    Private Sub formatoGridNuevosGanados()
        bloquearColumnas(gridNuevos)

        gridNuevos.Columns("TIPO").Visible = False
        gridNuevos.Columns("HONORARIOSACTUAL").Visible = False
        gridNuevos.Columns("HONORARIOSARREGLADOMN").Visible = False
        gridNuevos.Columns("MONEDA").Visible = False
        gridNuevos.Columns("PERIODO").Visible = False

        gridNuevos.Columns("TIPO").Frozen = True
        gridNuevos.Columns("HONORARIOSACTUAL").Frozen = True
        gridNuevos.Columns("MONEDA").Frozen = True
        gridNuevos.Columns("SOCIO").Frozen = True
        gridNuevos.Columns("OFICINA").Frozen = True
        gridNuevos.Columns("DIVISION").Frozen = True
        gridNuevos.Columns("CVETRABAJO").Frozen = True
        '  gridNuevos.Columns("CICLO").Frozen = True

        gridNuevos.Columns("SOCIO").HeaderText = "SOCIO / ASOCIADO"
        gridNuevos.Columns("SOCIO").Width = 300

        gridNuevos.Columns("OFICINA").HeaderText = "OFICINA"
        gridNuevos.Columns("OFICINA").Width = 90
        gridNuevos.Columns("OFICINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridNuevos.Columns("DIVISION").HeaderText = "DIVISIÓN"
        gridNuevos.Columns("DIVISION").Width = 90
        gridNuevos.Columns("DIVISION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridNuevos.Columns("CVETRABAJO").HeaderText = "CLAVE TRABAJO"
        gridNuevos.Columns("CVETRABAJO").Width = 150

        gridNuevos.Columns("CICLO").HeaderText = "AÑO REVISIÓN"
        gridNuevos.Columns("CICLO").Width = 100

        gridNuevos.Columns("EMPRESA").HeaderText = "EMPRESA"
        gridNuevos.Columns("EMPRESA").Width = 450

        gridNuevos.Columns("DESCRIPCION").HeaderText = "DESCRIPCIÓN"
        gridNuevos.Columns("DESCRIPCION").Width = 400

        gridNuevos.Columns("SERVICIO").HeaderText = "SERVICIO"
        gridNuevos.Columns("SERVICIO").Width = 400

        gridNuevos.Columns("HONETOS").HeaderText = "HONORARIOS NETOS"
        gridNuevos.Columns("HONETOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridNuevos.Columns("HONETOS").Width = 110

        gridNuevos.Columns("HORCOTIZADAS").HeaderText = "HORAS COTIZADAS"
        gridNuevos.Columns("HORCOTIZADAS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridNuevos.Columns("HORCOTIZADAS").Width = 110

        gridNuevos.Columns("CUOTA").HeaderText = "CUOTA HORA PROMEDIO"
        gridNuevos.Columns("CUOTA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridNuevos.Columns("CUOTA").Width = 110

        gridNuevos.Columns("WOFF").HeaderText = "% W/O"
        gridNuevos.Columns("WOFF").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridNuevos.Columns("WOFF").Width = 110

        gridNuevos.Columns("INDUSTRIA").HeaderText = "INDUSTRIA"
        gridNuevos.Columns("INDUSTRIA").Width = 200

        gridNuevos.Columns("SUBSECTOR").HeaderText = "SECTOR"
        gridNuevos.Columns("SUBSECTOR").Width = 200

        gridNuevos.Columns("REFGTSOCIO").HeaderText = "SOCIO REFERENCIA GTI"
        gridNuevos.Columns("REFGTSOCIO").Width = 300

        gridNuevos.Columns("REFGTOFI").HeaderText = "OFICINA REFRENCIA GTI"
        gridNuevos.Columns("REFGTOFI").Width = 300

        gridNuevos.Columns("REFGTPAIS").HeaderText = "PAÍS REFERENCIA GTI"
        gridNuevos.Columns("REFGTPAIS").Width = 300

        gridNuevos.Columns("COMO").HeaderText = "¿COMÓ SE ENTERÓ?"
        gridNuevos.Columns("COMO").Width = 250

        gridNuevos.Columns("MEDIO").HeaderText = "MEDIO DE CONTACTO"
        gridNuevos.Columns("MEDIO").Width = 250

        gridNuevos.Columns("PUESTO").HeaderText = "CATEGORÍA"
        gridNuevos.Columns("PUESTO").Width = 120

        gridNuevos.Columns("REFNOMB").HeaderText = "NOMBRE REFERENCIA"
        gridNuevos.Columns("REFNOMB").Width = 300

        gridNuevos.Columns("REFOFI").HeaderText = "OFICINA REFERENCIA"
        gridNuevos.Columns("REFOFI").Width = 90
        gridNuevos.Columns("REFOFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridNuevos.Columns("REFDIV").HeaderText = "ÁREA REFERENCIA"
        gridNuevos.Columns("REFDIV").Width = 90
        gridNuevos.Columns("REFDIV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub
    Private Sub formatoRecurrentes()
        bloquearColumnas(gridRecurrentes)

        gridRecurrentes.Columns("TIPO").Visible = False
        gridRecurrentes.Columns("PERIODO").Visible = False
        gridRecurrentes.Columns("VARIACION").Visible = False
        gridRecurrentes.Columns("HONORARIOSACTUAL").Visible = False
        gridRecurrentes.Columns("HONORARIOSANTERIOR").Visible = False
        gridRecurrentes.Columns("DIFERENCIA").Visible = False
        gridRecurrentes.Columns("MONEDA").Visible = False

        gridRecurrentes.Columns("TIPO").Frozen = True
        gridRecurrentes.Columns("PERIODO").Frozen = True
        gridRecurrentes.Columns("VARIACION").Frozen = True
        gridRecurrentes.Columns("HONORARIOSACTUAL").Frozen = True
        gridRecurrentes.Columns("HONORARIOSANTERIOR").Frozen = True
        gridRecurrentes.Columns("DIFERENCIA").Frozen = True
        gridRecurrentes.Columns("MONEDA").Frozen = True
        gridRecurrentes.Columns("SOCIO").Frozen = True
        gridRecurrentes.Columns("OFICINA").Frozen = True
        gridRecurrentes.Columns("DIVISION").Frozen = True
        gridRecurrentes.Columns("CVETRABAJO").Frozen = True

        gridRecurrentes.Columns("SOCIO").HeaderText = "SOCIO / ASOCIADO"
        gridRecurrentes.Columns("SOCIO").Width = 270

        gridRecurrentes.Columns("OFICINA").HeaderText = "OFICINA"
        gridRecurrentes.Columns("OFICINA").Width = 90
        gridRecurrentes.Columns("OFICINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridRecurrentes.Columns("DIVISION").HeaderText = "DIVISIÓN"
        gridRecurrentes.Columns("DIVISION").Width = 90
        gridRecurrentes.Columns("DIVISION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridRecurrentes.Columns("CVETRABAJO").HeaderText = "CLAVE DE TRABAJO"
        gridRecurrentes.Columns("CVETRABAJO").Width = 150

        gridRecurrentes.Columns("EMPRESA").HeaderText = "EMPRESA"
        gridRecurrentes.Columns("EMPRESA").Width = 400

        gridRecurrentes.Columns("DESCRIPCION").HeaderText = "DESCRIPCIÓN"
        gridRecurrentes.Columns("DESCRIPCION").Width = 400

        gridRecurrentes.Columns("SERVICIO").HeaderText = "SERVICIO"
        gridRecurrentes.Columns("SERVICIO").Width = 400

        gridRecurrentes.Columns("TIPOPROP").HeaderText = "TIPO PROPUESTA"
        gridRecurrentes.Columns("TIPOPROP").Width = 180

        gridRecurrentes.Columns("HONORARIOSPPTO").HeaderText = "HONORARIOS PRESUPUESTADOS"
        gridRecurrentes.Columns("HONORARIOSPPTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridRecurrentes.Columns("HONORARIOSPPTO").Width = 110

        gridRecurrentes.Columns("HONORARIOSARREGLADOMN").HeaderText = "HONORARIOS ARREGLADOS"
        gridRecurrentes.Columns("HONORARIOSARREGLADOMN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridRecurrentes.Columns("HONORARIOSARREGLADOMN").Width = 110

        gridRecurrentes.Columns("HONORARIOSANTERIORMN").HeaderText = "HONORARIOS CICLO ANTERIOR"
        gridRecurrentes.Columns("HONORARIOSANTERIORMN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridRecurrentes.Columns("HONORARIOSANTERIORMN").Width = 110

        gridRecurrentes.Columns("DIFERENCIAMN").HeaderText = "DIFERENCIA"
        gridRecurrentes.Columns("DIFERENCIAMN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridRecurrentes.Columns("DIFERENCIAMN").Width = 110
    End Sub
    Private Sub formatoGridPorResolver()
        bloquearColumnas(gridPendientes)

        gridPendientes.Columns("TIPO").Visible = False
        gridPendientes.Columns("PERIODO").Visible = False
        gridPendientes.Columns("HONORARIOSACTUAL").Visible = False
        gridPendientes.Columns("HONETOS").Visible = False
        gridPendientes.Columns("MONEDA").Visible = False

        gridPendientes.Columns("SOCIO").HeaderText = "SOCIO / ASOCIADO"
        gridPendientes.Columns("SOCIO").Width = 300

        gridPendientes.Columns("OFICINA").HeaderText = "OFICINA"
        gridPendientes.Columns("OFICINA").Width = 90
        gridPendientes.Columns("OFICINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridPendientes.Columns("DIVISION").HeaderText = "DIVISIÓN"
        gridPendientes.Columns("DIVISION").Width = 90
        gridPendientes.Columns("DIVISION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridPendientes.Columns("CICLO").HeaderText = "CICLO"
        gridPendientes.Columns("CICLO").Width = 100

        gridPendientes.Columns("EMPRESA").HeaderText = "EMPRESA"
        gridPendientes.Columns("EMPRESA").Width = 450

        gridPendientes.Columns("SERVICIO").HeaderText = "SERVICIO"
        gridPendientes.Columns("SERVICIO").Width = 450

        'gridPendientes.Columns("HONORARIOSARREGLADOMN").HeaderText = "HONORARIOS"
        'gridPendientes.Columns("HONORARIOSARREGLADOMN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'gridPendientes.Columns("HONORARIOSARREGLADOMN").Width = 110

        gridPendientes.Columns("FECHAPROPUESTA").HeaderText = "FECHA PROPUESTA"
        gridPendientes.Columns("FECHAPROPUESTA").Width = 90

        gridPendientes.Columns("HONORARIOSARREGLADOMN").HeaderText = "HONORARIOS NETOS"
        gridPendientes.Columns("HONORARIOSARREGLADOMN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridPendientes.Columns("HONORARIOSARREGLADOMN").Width = 110

        gridPendientes.Columns("HORCOTIZADAS").HeaderText = "HORAS COTIZADAS"
        gridPendientes.Columns("HORCOTIZADAS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridPendientes.Columns("HORCOTIZADAS").Width = 110

        gridPendientes.Columns("CUOTA").HeaderText = "CUOTA HORA PROMEDIO"
        gridPendientes.Columns("CUOTA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridPendientes.Columns("CUOTA").Width = 110

        gridPendientes.Columns("WOFF").HeaderText = "% W/O"
        gridPendientes.Columns("WOFF").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridPendientes.Columns("WOFF").Width = 110

        gridPendientes.Columns("INDUSTRIA").HeaderText = "INDUSTRIA"
        gridPendientes.Columns("INDUSTRIA").Width = 200

        gridPendientes.Columns("SUBSECTOR").HeaderText = "SECTOR"
        gridPendientes.Columns("SUBSECTOR").Width = 200

        gridPendientes.Columns("REFGTSOCIO").HeaderText = "SOCIO REFERENCIA GT"
        gridPendientes.Columns("REFGTSOCIO").Width = 300

        gridPendientes.Columns("REFGTOFI").HeaderText = "OFICINA REFRENCIA GT"
        gridPendientes.Columns("REFGTOFI").Width = 300

        gridPendientes.Columns("REFGTPAIS").HeaderText = "PAÍS REFERENCIA GT"
        gridPendientes.Columns("REFGTPAIS").Width = 300

        gridPendientes.Columns("COMO").HeaderText = "¿CÓMO SE ENTERÓ?"
        gridPendientes.Columns("COMO").Width = 250

        gridPendientes.Columns("MEDIO").HeaderText = "MEDIO DE CONTACTO"
        gridPendientes.Columns("MEDIO").Width = 250

        gridPendientes.Columns("PUESTO").HeaderText = "CATEGORÍA"
        gridPendientes.Columns("PUESTO").Width = 100

        gridPendientes.Columns("REFNOMB").HeaderText = "NOMBRE REFERENCIA"
        gridPendientes.Columns("REFNOMB").Width = 300

        gridPendientes.Columns("REFOFI").HeaderText = "OFICINA REFERENCIA"
        gridPendientes.Columns("REFOFI").Width = 90
        gridPendientes.Columns("REFOFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridPendientes.Columns("REFDIV").HeaderText = "ÁREA REFERENCIA"
        gridPendientes.Columns("REFDIV").Width = 90
        gridPendientes.Columns("REFDIV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub
    Private Sub formatoGridRechazado()
        bloquearColumnas(gridRechazadas)

        gridRechazadas.Columns("TIPO").Visible = False
        gridRechazadas.Columns("PERIODO").Visible = False
        gridRechazadas.Columns("HONORARIOSACTUAL").Visible = False
        gridRechazadas.Columns("HONETOS").Visible = False
        gridRechazadas.Columns("MONEDA").Visible = False

        gridRechazadas.Columns("SOCIO").HeaderText = "SOCIO / ASOCIADO"
        gridRechazadas.Columns("SOCIO").Width = 300

        gridRechazadas.Columns("OFICINA").HeaderText = "OFICINA"
        gridRechazadas.Columns("OFICINA").Width = 90
        gridRechazadas.Columns("OFICINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridRechazadas.Columns("DIVISION").HeaderText = "DIVISIÓN"
        gridRechazadas.Columns("DIVISION").Width = 90
        gridRechazadas.Columns("DIVISION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridRechazadas.Columns("EMPRESA").HeaderText = "EMPRESA"
        gridRechazadas.Columns("EMPRESA").Width = 450

        gridRechazadas.Columns("SERVICIO").HeaderText = "SERVICIO"
        gridRechazadas.Columns("SERVICIO").Width = 450

        gridRechazadas.Columns("HONORARIOSARREGLADOMN").HeaderText = "HONORARIOS"
        gridRechazadas.Columns("HONORARIOSARREGLADOMN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridRechazadas.Columns("HONORARIOSARREGLADOMN").Width = 110

        gridRechazadas.Columns("DESCRECHAZO").HeaderText = "MOTIVO DEL RECHAZO"
        gridRechazadas.Columns("DESCRECHAZO").Width = 450

        gridRechazadas.Columns("HORCOTIZADAS").HeaderText = "HORAS COTIZADAS"
        gridRechazadas.Columns("HORCOTIZADAS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridRechazadas.Columns("HORCOTIZADAS").Width = 110

        gridRechazadas.Columns("CUOTA").HeaderText = "CUOTA HORA PROMEDIO"
        gridRechazadas.Columns("CUOTA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridRechazadas.Columns("CUOTA").Width = 110

        gridRechazadas.Columns("WOFF").HeaderText = "% W/O"
        gridRechazadas.Columns("WOFF").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridRechazadas.Columns("WOFF").Width = 110

        gridRechazadas.Columns("INDUSTRIA").HeaderText = "INDUSTRIA"
        gridRechazadas.Columns("INDUSTRIA").Width = 200

        gridRechazadas.Columns("SUBSECTOR").HeaderText = "SECTOR"
        gridRechazadas.Columns("SUBSECTOR").Width = 200

        gridRechazadas.Columns("REFGTSOCIO").HeaderText = "SOCIO REFERENCIA GT"
        gridRechazadas.Columns("REFGTSOCIO").Width = 300

        gridRechazadas.Columns("REFGTOFI").HeaderText = "OFICINA REFRENCIA GT"
        gridRechazadas.Columns("REFGTOFI").Width = 300

        gridRechazadas.Columns("REFGTPAIS").HeaderText = "PAÍS REFERENCIA GT"
        gridRechazadas.Columns("REFGTPAIS").Width = 300

        gridRechazadas.Columns("COMO").HeaderText = "¿CÓMO SE ENTERÓ?"
        gridRechazadas.Columns("COMO").Width = 250

        gridRechazadas.Columns("MEDIO").HeaderText = "MEDIO DE CONTACTO"
        gridRechazadas.Columns("MEDIO").Width = 250

        gridRechazadas.Columns("PUESTO").HeaderText = "CATEGORÍA"
        gridRechazadas.Columns("PUESTO").Width = 100

        gridRechazadas.Columns("REFNOMB").HeaderText = "NOMBRE REFERENCIA"
        gridRechazadas.Columns("REFNOMB").Width = 250

        gridRechazadas.Columns("REFOFI").HeaderText = "OFICINA REFERENCIA"
        gridRechazadas.Columns("REFOFI").Width = 90
        gridRechazadas.Columns("REFOFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridRechazadas.Columns("REFDIV").HeaderText = "ÁREA REFERENCIA"
        gridRechazadas.Columns("REFDIV").Width = 90
        gridRechazadas.Columns("REFDIV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub ListarPresupuesto()
        Try
            Dim sTabla As String = "tbPpto"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 20, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                dtPpto = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarPresupuesto()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtPpto = Nothing
        End Try
    End Sub
    Private Sub ListarHonorariosAnterior()
        Try
            Dim sTabla As String = "tbHonorariosAnt"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 21, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                dtIngresosAnt = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosAnterior()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtIngresosAnt = Nothing
        End Try
    End Sub
    Private Sub ListarHonorariosCicloAnterior()
        Try
            Dim sTabla As String = "tbHonCicloAnt"

            LimpiarTabla(dtHonNoRec)

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 22, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                dtHonCicloAnt = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosCicloAnterior")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtHonCicloAnt = Nothing
        End Try
    End Sub
    Private Sub ListarHonorariosCicloAnteriorNoRecurrentes()
        Try
            Dim sTabla As String = "tbHonCicloAntNoRec"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 35, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                dtHonCicloAntNoRec = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarHonorariosCicloAnteriorNoRecurrentes")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtHonCicloAntNoRec = Nothing
        End Try
    End Sub
    Private Sub ListarHonorariosCicloAnteriorNoRecurrentesPpto()
        Try
            Dim sTabla As String = "tbHonCicloAntNoRecPpto"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 40, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                dtHonCicloAntNoRecPpto = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarHonorariosCicloAnteriorNoRecurrentesPpto")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtHonCicloAntNoRecPpto = Nothing
        End Try
    End Sub
    Private Sub ListarHonorariosCicloAnteriorSocio()
        Try
            Dim sTabla As String = "tbHonCicloAntSoc"

            LimpiarTabla(dtIngresosSocAnt)

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 23, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                dtIngresosSocAnt = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosCicloAnteriorSocio()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtIngresosSocAnt = Nothing
        End Try
    End Sub
    Private Sub ListarHonorariosPptoClavesAsociadas()
        Try
            Dim sTabla As String = "tbHonPptoCvesAsoc"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 45, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                dtHonPptoAsoc = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarHonorariosCicloAnteriorNoRecurrentes")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtHonPptoAsoc = Nothing
        End Try
    End Sub

    Private Sub ListarHonorariosTotalProp(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim sTabla As String = "tbTotalPropuestas"

            LimpiarTabla(dtHonTotPro)

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 24, SqlDbType.Int, ParameterDirection.Input)

                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If

                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)
                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    HonTotProDatos = .Item(sTabla)

                    For Each r As DataRow In HonTotProDatos.Rows
                        drTotPro = dtHonTotPro.NewRow
                        drTotPro("HONORARIOS") = r.Item("HONORARIOSPROPUESTA").ToString
                        drTotPro("OFICINA") = r.Item("CVEOFI").ToString
                        drTotPro("DIVISION") = r.Item("CVEAREA").ToString
                        dtHonTotPro.Rows.InsertAt(drTotPro, dtHonTotPro.Rows.Count)
                    Next
                End With
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosPropRechazadas()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtRechazadasDatos = Nothing
        End Try
    End Sub

#Region "CONCILIACIÓN INICIAL"

    Private Sub ListarConciliacionInicial(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim sTabla As String = "tbConcilIni"

            LimpiarTabla(dtConcilIni)

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 28, SqlDbType.Int, ParameterDirection.Input)
                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If
                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtConIni = .Item(sTabla)

                    For Each row As DataRow In dtConIni.Rows
                        drConcilIni = dtConcilIni.NewRow()
                        drConcilIni("TIPO") = "S"
                        drConcilIni("IDCLAS") = row.Item("iClasificacion").ToString
                        drConcilIni("TIPOTRA") = row.Item("iTipoTra").ToString
                        drConcilIni("CVEOFI") = Dr("CVEOFI").ToString()
                        drConcilIni("CVEAREA") = Dr("CVEAREA").ToString()
                        drConcilIni("CVECTE") = row.Item("sCveCte").ToString
                        drConcilIni("SOCIO") = Dr("CVEEMP").ToString()
                        drConcilIni("NOMBRESOC") = row.Item("NOMBRESOC").ToString
                        drConcilIni("CVETRA") = row.Item("sCveTra").ToString
                        drConcilIni("NOMBRECTE") = row.Item("sNombreCte").ToString
                        drConcilIni("DESCRIPCION") = row.Item("sDescripcion").ToString
                        drConcilIni("TIPOCTE") = row.Item("sTipoCte").ToString
                        drConcilIni("DESCOFI") = row.Item("DESCOFI").ToString
                        drConcilIni("DESCAREA") = row.Item("DESCAREA").ToString
                        drConcilIni("STATUS") = row.Item("cStatus").ToString
                        drConcilIni("FECHA") = row.Item("FECHA").ToString
                        drConcilIni("SEPUNO") = ""
                        drConcilIni("IMPFAC") = Format(CDbl(row.Item("dImpFac").ToString), sFmtDbl)
                        drConcilIni("PPTOFACTER") = Format(CDbl(row.Item("dImpPptoFacTer").ToString), sFmtDbl)
                        drConcilIni("PPTOFACINT") = Format(CDbl(row.Item("dImpPptoFacInt").ToString), sFmtDbl)
                        drConcilIni("PPTOFACTRA") = Format(CDbl(row.Item("dImpPptoFacTras").ToString), sFmtDbl)
                        drConcilIni("PPTOFACNET") = Format(CDbl(row.Item("dImpPptoFacNeta").ToString), sFmtDbl)
                        drConcilIni("PORWO") = Format(CDbl(row.Item("dPorWO").ToString), sFmtDbl)
                        drConcilIni("PPTOWO") = Format(CDbl(row.Item("dImpPptoWO").ToString), sFmtDbl)
                        drConcilIni("IMPNETO") = Format(CDbl(row.Item("dImpPptoNeto").ToString), sFmtDbl)
                        drConcilIni("IMPVAR") = Format(CDbl(row.Item("dImpVar").ToString), sFmtDbl)
                        drConcilIni("SEPDOS") = ""
                        drConcilIni("IMPGAN") = Format(CDbl(row.Item("dImpGan").ToString), sFmtDbl)
                        drConcilIni("IMPGANTRANS") = Format(CDbl(row.Item("dImpTransfDe").ToString), sFmtDbl)
                        drConcilIni("SOCIOTRANSDE") = row.Item("sSocioTransfDe").ToString
                        drConcilIni("IMPCAN") = Format(CDbl(row.Item("dImpCan").ToString), sFmtDbl)
                        drConcilIni("IMPINC") = Format(CDbl(row.Item("dImpInc").ToString), sFmtDbl)
                        drConcilIni("SEPTRES") = ""
                        drConcilIni("IMPDEC") = Format(CDbl(row.Item("dImpDec").ToString), sFmtDbl)
                        drConcilIni("IMPPER") = Format(CDbl(row.Item("dImpPer").ToString), sFmtDbl)
                        drConcilIni("MOTIVOPER") = row.Item("sMotivoPer").ToString
                        drConcilIni("IMPPERTRANS") = Format(CDbl(row.Item("dImpTransfA").ToString), sFmtDbl)
                        drConcilIni("SOCIOTRANSA") = row.Item("sSocioTransfA").ToString
                        drConcilIni("MOTIVOTRANSA") = row.Item("sMotivoTransf").ToString
                        drConcilIni("TOTAL") = Format(0, sFmtDbl)
                        drConcilIni("CVESOCTRANSDE") = row.Item("sCveSocTransfDe").ToString
                        drConcilIni("CVESOCTRANSA") = row.Item("sCveSocTransfA").ToString
                        dtConcilIni.Rows.InsertAt(drConcilIni, dtConcilIni.Rows.Count)
                    Next
                End With
            Next

            drConcilIni = dtConcilIni.NewRow()
            drConcilIni("TIPO") = "T"
            drConcilIni("IDCLAS") = ""
            drConcilIni("TIPOTRA") = ""
            drConcilIni("CVEOFI") = ""
            drConcilIni("CVEAREA") = ""
            drConcilIni("CVECTE") = ""
            drConcilIni("SOCIO") = ""
            drConcilIni("NOMBRESOC") = ""
            drConcilIni("CVETRA") = ""
            drConcilIni("NOMBRECTE") = "TOTAL"
            drConcilIni("DESCRIPCION") = ""
            drConcilIni("TIPOCTE") = ""
            drConcilIni("DESCOFI") = ""
            drConcilIni("DESCAREA") = ""
            drConcilIni("STATUS") = ""
            drConcilIni("SEPUNO") = ""
            drConcilIni("IMPFAC") = Format(0, sFmtDbl)
            drConcilIni("PPTOFACTER") = Format(0, sFmtDbl)
            drConcilIni("PPTOFACINT") = Format(0, sFmtDbl)
            drConcilIni("PPTOFACTRA") = Format(0, sFmtDbl)
            drConcilIni("PPTOFACNET") = Format(0, sFmtDbl)
            drConcilIni("PORWO") = Format(0, sFmtDbl)
            drConcilIni("PPTOWO") = Format(0, sFmtDbl)
            drConcilIni("IMPNETO") = Format(0, sFmtDbl)
            drConcilIni("IMPVAR") = Format(0, sFmtDbl)
            drConcilIni("SEPDOS") = ""
            drConcilIni("IMPGAN") = Format(0, sFmtDbl)
            drConcilIni("IMPGANTRANS") = Format(0, sFmtDbl)
            drConcilIni("SOCIOTRANSDE") = ""
            drConcilIni("IMPCAN") = Format(0, sFmtDbl)
            drConcilIni("IMPINC") = Format(0, sFmtDbl)
            drConcilIni("SEPTRES") = ""
            drConcilIni("IMPDEC") = Format(0, sFmtDbl)
            drConcilIni("IMPPER") = Format(0, sFmtDbl)
            drConcilIni("MOTIVOPER") = ""
            drConcilIni("IMPPERTRANS") = Format(0, sFmtDbl)
            drConcilIni("SOCIOTRANSA") = ""
            drConcilIni("MOTIVOTRANSA") = ""
            drConcilIni("TOTAL") = Format(0, sFmtDbl)
            drConcilIni("CVESOCTRANSDE") = ""
            drConcilIni("CVESOCTRANSA") = ""
            dtConcilIni.Rows.InsertAt(drConcilIni, dtConcilIni.Rows.Count)

            bsConIni.DataSource = dtConcilIni

            FormatoGridConcilIni()

            SumarTotalesConciliacionInicial()
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarConciliacionInicial")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtConIni = Nothing
        End Try
    End Sub

    Private Sub InsertarClasificacionConciliacion()
        Try
            For x As Integer = 0 To gridConcilacionIni.Rows.Count - 1
                If gridConcilacionIni.Rows(x).Cells("TIPO").Value = "S" Then
                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 15, SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@idClas", CDbl(gridConcilacionIni.Rows(x).Cells("IDCLAS").Value), SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@sCveTra", gridConcilacionIni.Rows(x).Cells("CVETRA").Value, SqlDbType.VarChar, ParameterDirection.Input, 20)
                        .subAddParameter("@sCveSocio", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveOfi", gridConcilacionIni.Rows(x).Cells("CVEOFI").Value, SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", gridConcilacionIni.Rows(x).Cells("CVEAREA").Value, SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@dImporte", CDbl(gridConcilacionIni.Rows(x).Cells("IMPVAR").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@sMotivoPer", gridConcilacionIni.Rows(x).Cells("MOTIVOPER").Value, SqlDbType.VarChar, ParameterDirection.Input, 2000)

                        .funExecuteSP("paConciliacionIngresos")
                    End With
                End If
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarDatosConciliacion()")
            MsgBox("Hubo un problema al registrar la información, ya se encuentra en revisión. Intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub InsertarDatosConciliacion()
        Try
            For x As Integer = 0 To gridConcilacionIni.Rows.Count - 1
                If gridConcilacionIni.Rows(x).Cells("TIPO").Value = "S" Then
                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 17, SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@sCveSocio", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveOfi", gridConcilacionIni.Rows(x).Cells("CVEOFI").Value, SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", gridConcilacionIni.Rows(x).Cells("CVEAREA").Value, SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@idClas", CInt(gridConcilacionIni.Rows(x).Cells("IDCLAS").Value), SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@iTipoTra", CInt(gridConcilacionIni.Rows(x).Cells("TIPOTRA").Value), SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@sTipoCte", gridConcilacionIni.Rows(x).Cells("TIPOCTE").Value, SqlDbType.Char, ParameterDirection.Input, 1)
                        .subAddParameter("@sCveTra", gridConcilacionIni.Rows(x).Cells("CVETRA").Value, SqlDbType.VarChar, ParameterDirection.Input, 20)
                        .subAddParameter("@sCveCte", gridConcilacionIni.Rows(x).Cells("CVECTE").Value, SqlDbType.VarChar, ParameterDirection.Input, 20)
                        .subAddParameter("@sNombreCte", gridConcilacionIni.Rows(x).Cells("NOMBRECTE").Value, SqlDbType.VarChar, ParameterDirection.Input, 2000)
                        .subAddParameter("@sDescripcion", gridConcilacionIni.Rows(x).Cells("DESCRIPCION").Value, SqlDbType.VarChar, ParameterDirection.Input, 2000)
                        .subAddParameter("@sStatus", gridConcilacionIni.Rows(x).Cells("STATUS").Value, SqlDbType.Char, ParameterDirection.Input, 1)
                        If gridConcilacionIni.Rows(x).Cells("FECHA").Value <> "" Then
                            .subAddParameter("@dFechaBaja", CDate(gridConcilacionIni.Rows(x).Cells("FECHA").Value), SqlDbType.Date, ParameterDirection.Input)
                        End If
                        .subAddParameter("@dImpFac", CDbl(gridConcilacionIni.Rows(x).Cells("IMPFAC").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@dImpPptoFacTer", CDbl(gridConcilacionIni.Rows(x).Cells("PPTOFACTER").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@dImpPptoFacInt", CDbl(gridConcilacionIni.Rows(x).Cells("PPTOFACINT").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@dImpPptoFacTras", CDbl(gridConcilacionIni.Rows(x).Cells("PPTOFACTRA").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@dImpPptoFacNeta", CDbl(gridConcilacionIni.Rows(x).Cells("PPTOFACNET").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@dPorWO", CDbl(gridConcilacionIni.Rows(x).Cells("PORWO").Value.ToString.Replace("%", "")), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@dImpPptoWO", CDbl(gridConcilacionIni.Rows(x).Cells("PPTOWO").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@dImpPptoNeto", CDbl(gridConcilacionIni.Rows(x).Cells("IMPNETO").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@dImpVar", CDbl(gridConcilacionIni.Rows(x).Cells("IMPVAR").Value), SqlDbType.Float, ParameterDirection.Input)

                        .subAddParameter("@dImpGan", CDbl(gridConcilacionIni.Rows(x).Cells("IMPGAN").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@dImpTransfDe", CDbl(gridConcilacionIni.Rows(x).Cells("IMPGANTRANS").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@sCveSocTransfDe", gridConcilacionIni.Rows(x).Cells("CVESOCTRANSDE").Value, SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@dImpCan", CDbl(gridConcilacionIni.Rows(x).Cells("IMPCAN").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@dImpInc", CDbl(gridConcilacionIni.Rows(x).Cells("IMPINC").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@dImpPer", CDbl(gridConcilacionIni.Rows(x).Cells("IMPPER").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@sMotivoPer", gridConcilacionIni.Rows(x).Cells("MOTIVOPER").Value, SqlDbType.VarChar, ParameterDirection.Input, 2000)
                        .subAddParameter("@dImpTransfA", CDbl(gridConcilacionIni.Rows(x).Cells("IMPPERTRANS").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@sMotivoTransf", gridConcilacionIni.Rows(x).Cells("MOTIVOTRANSA").Value, SqlDbType.VarChar, ParameterDirection.Input, 2000)
                        .subAddParameter("@sCveSocTransfA", gridConcilacionIni.Rows(x).Cells("CVESOCTRANSA").Value, SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@dImpDec", CDbl(gridConcilacionIni.Rows(x).Cells("IMPDEC").Value), SqlDbType.Float, ParameterDirection.Input)

                        .funExecuteSP("paConciliacionIngresos")
                    End With
                End If
            Next
            MsgBox("La información fue registrada correctamente.", MsgBoxStyle.Information, "Información registrada")
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarDatosConciliacion()")
            MsgBox("Hubo un problema al registrar la información, ya se encuentra en revisión. Intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub InsertarEntregaConciliacion()
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveSocio", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)

                .funExecuteSP("paConciliacionIngresos")
            End With
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarEntregaConciliacion()")
            MsgBox("Hubo un problema al registrar la información, ya se encuentra en revisión. Intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub ActualizarDatosConciliacion()
        Try
            For x As Integer = 0 To gridConcilacionIni.Rows.Count - 1
                If gridConcilacionIni.Rows(x).Cells("TIPO").Value = "S" Then
                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 20, SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@idClas", CDbl(gridConcilacionIni.Rows(x).Cells("IDCLAS").Value), SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@sCveTra", gridConcilacionIni.Rows(x).Cells("CVETRA").Value, SqlDbType.VarChar, ParameterDirection.Input, 20)
                        .subAddParameter("@sCveSocio", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveOfi", gridConcilacionIni.Rows(x).Cells("CVEOFI").Value, SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", gridConcilacionIni.Rows(x).Cells("CVEAREA").Value, SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@dImporte", CDbl(gridConcilacionIni.Rows(x).Cells("IMPVAR").Value), SqlDbType.Float, ParameterDirection.Input)
                        .subAddParameter("@sMotivoPer", gridConcilacionIni.Rows(x).Cells("MOTIVOPER").Value, SqlDbType.VarChar, ParameterDirection.Input, 2000)

                        .funExecuteSP("paConciliacionIngresos")
                    End With
                End If
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarDatosConciliacion()")
            MsgBox("Hubo un problema al registrar la información, ya se encuentra en revisión. Intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub ActualizarMotivosPerdida()
        Try
            For x As Integer = 0 To gridPerdidos.Rows.Count - 1
                If gridPerdidos.Rows(x).Cells("TIPO").Value = "S" Then
                    If gridPerdidos.Rows(x).Cells("CAMBIO").Value = "S" Then
                        With clsDatos
                            .subClearParameters()
                            .subAddParameter("@iOpcion", 44, SqlDbType.Int, ParameterDirection.Input)
                            .subAddParameter("@sCveTra", gridPerdidos.Rows(x).Cells("CVETRABAJO").Value, SqlDbType.VarChar, ParameterDirection.Input, 20)
                            .subAddParameter("@sCveSocio", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
                            .subAddParameter("@sCveOfi", gridPerdidos.Rows(x).Cells("CVEOFI").Value, SqlDbType.VarChar, ParameterDirection.Input, 10)
                            .subAddParameter("@sCveArea", gridPerdidos.Rows(x).Cells("CVEAREA").Value, SqlDbType.VarChar, ParameterDirection.Input, 10)
                            .subAddParameter("@sMotivoRechazo", gridPerdidos.Rows(x).Cells("MOTIVO").Value, SqlDbType.VarChar, ParameterDirection.Input, 1000)

                            .funExecuteSP("paReporteDireccion")
                        End With
                    End If
                End If
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizarMotivosPerdida()")
            MsgBox("Hubo un problema al registrar la información, ya se encuentra en revisión. Intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub SumarTotales()
        Dim dImpGan, dImpTransfGan, dImpCan, dImpInc, dImpPer, dImpTransfPer, dImpDec, dTotal As Double

        dImpGan = 0
        dImpTransfGan = 0
        dImpCan = 0
        dImpInc = 0
        dImpPer = 0
        dImpTransfPer = 0
        dImpDec = 0
        dTotal = 0

        If gridConcilacionIni.Rows.Count > 0 Then
            For Each row As DataGridViewRow In gridConcilacionIni.Rows
                If row.Cells("TIPO").Value = "S" Then
                    dImpGan += row.Cells("IMPGAN").Value
                    dImpTransfGan += row.Cells("IMPGANTRANS").Value
                    dImpCan += row.Cells("IMPCAN").Value
                    dImpInc += row.Cells("IMPINC").Value
                    dImpPer += row.Cells("IMPPER").Value
                    dImpTransfPer += row.Cells("IMPPERTRANS").Value
                    dImpDec += row.Cells("IMPDEC").Value

                    dTotal = (dImpGan + dImpTransfGan + dImpCan + dImpInc + dImpDec + dImpPer + dImpTransfPer)
                End If
            Next

            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPGAN").Value = Format(dImpGan, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPGANTRANS").Value = Format(dImpTransfGan, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPCAN").Value = Format(dImpCan, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPINC").Value = Format(dImpInc, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPPER").Value = Format(dImpPer, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPPERTRANS").Value = Format(dImpTransfPer, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPDEC").Value = Format(dImpDec, sFmtDbl)

            dImpGan = 0
            dImpTransfGan = 0
            dImpCan = 0
            dImpInc = 0
            dImpPer = 0
            dImpTransfPer = 0
            dImpDec = 0
            dTotal = 0

            For Each row As DataGridViewRow In gridConcilacionIni.Rows
                dImpGan = row.Cells("IMPGAN").Value
                dImpTransfGan = row.Cells("IMPGANTRANS").Value
                dImpCan = row.Cells("IMPCAN").Value
                dImpInc = row.Cells("IMPINC").Value
                dImpPer = row.Cells("IMPPER").Value
                dImpTransfPer = row.Cells("IMPPERTRANS").Value
                dImpDec = row.Cells("IMPDEC").Value
                dTotal = (dImpGan + dImpTransfGan + dImpCan + dImpInc + dImpDec + dImpPer + dImpTransfPer)

                row.Cells("TOTAL").Value = Format(dTotal, sFmtDbl)
            Next
        End If
    End Sub
    Private Sub SumarTotalesConciliacionInicial()
        Dim dImpFac, dImpPptoFT, dImpPptoFI, dImpPptoFTr, dImpPptoFN, dPorWO, dImpWO, dImpNeto, dImpVar As Double
        Dim dImpGan, dImpTransfGan, dImpCan, dImpInc, dImpPer, dImpTransfPer, dImpDec, dTotal As Double

        dImpFac = 0
        dImpPptoFT = 0
        dImpPptoFI = 0
        dImpPptoFTr = 0
        dImpPptoFN = 0
        dPorWO = 0
        dImpWO = 0
        dImpNeto = 0
        dImpVar = 0

        dImpGan = 0
        dImpTransfGan = 0
        dImpCan = 0
        dImpInc = 0
        dImpPer = 0
        dImpTransfPer = 0
        dImpDec = 0
        dTotal = 0

        If gridConcilacionIni.Rows.Count > 0 Then
            For Each row As DataGridViewRow In gridConcilacionIni.Rows
                If row.Cells("TIPO").Value = "S" Then
                    dImpFac += row.Cells("IMPFAC").Value
                    dImpPptoFT += row.Cells("PPTOFACTER").Value
                    dImpPptoFI += row.Cells("PPTOFACINT").Value
                    dImpPptoFTr += row.Cells("PPTOFACTRA").Value
                    dImpPptoFN += row.Cells("PPTOFACNET").Value
                    dImpWO += row.Cells("PPTOWO").Value
                    dImpNeto += row.Cells("IMPNETO").Value
                    dImpVar += row.Cells("IMPVAR").Value

                    dImpGan += row.Cells("IMPGAN").Value
                    dImpTransfGan += row.Cells("IMPGANTRANS").Value
                    dImpCan += row.Cells("IMPCAN").Value
                    dImpInc += row.Cells("IMPINC").Value
                    dImpPer += row.Cells("IMPPER").Value
                    dImpTransfPer += row.Cells("IMPPERTRANS").Value
                    dImpDec += row.Cells("IMPDEC").Value

                    'dTotal = (dImpGan + dImpTransfGan + dImpCan + dImpInc + dImpDec + dImpPer + dImpTransfPer)
                End If
            Next

            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPFAC").Value = Format(dImpFac, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("PPTOFACTER").Value = Format(dImpPptoFT, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("PPTOFACINT").Value = Format(dImpPptoFI, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("PPTOFACTRA").Value = Format(dImpPptoFTr, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("PPTOFACNET").Value = Format(dImpPptoFN, sFmtDbl)
            If dImpPptoFN <> 0 Then
                gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("PORWO").Value = Format((dImpWO / dImpPptoFN) * 100, sFmtDbl)
            Else
                gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("PORWO").Value = Format(0, sFmtDbl)
            End If
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("PPTOWO").Value = Format(dImpWO, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPNETO").Value = Format(dImpNeto, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPVAR").Value = Format(dImpVar, sFmtDbl)

            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPGAN").Value = Format(dImpGan, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPGANTRANS").Value = Format(dImpTransfGan, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPCAN").Value = Format(dImpCan, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPINC").Value = Format(dImpInc, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPPER").Value = Format(dImpPer, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPPERTRANS").Value = Format(dImpTransfPer, sFmtDbl)
            gridConcilacionIni.Rows(gridConcilacionIni.Rows.Count - 1).Cells("IMPDEC").Value = Format(dImpDec, sFmtDbl)

            dImpGan = 0
            dImpTransfGan = 0
            dImpCan = 0
            dImpInc = 0
            dImpPer = 0
            dImpTransfPer = 0
            dImpDec = 0
            dTotal = 0

            For Each row As DataGridViewRow In gridConcilacionIni.Rows
                dImpGan = row.Cells("IMPGAN").Value
                dImpTransfGan = row.Cells("IMPGANTRANS").Value
                dImpCan = row.Cells("IMPCAN").Value
                dImpInc = row.Cells("IMPINC").Value
                dImpPer = row.Cells("IMPPER").Value
                dImpTransfPer = row.Cells("IMPPERTRANS").Value
                dImpDec = row.Cells("IMPDEC").Value
                dTotal = (dImpGan + dImpTransfGan + dImpCan + dImpInc + dImpDec + dImpPer + dImpTransfPer)

                row.Cells("TOTAL").Value = Format(dTotal, sFmtDbl)
            Next
        End If
    End Sub

#End Region
#Region "CONCILIACIÓN"

    Private Sub listarReporteDireccionEncargado()
        LimpiarTabla(dtConcilEnc)
        bs.DataSource = Nothing

        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        '0 - Ingresos reales
        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "S"
        drConcilEnc("ID") = 0
        drConcilEnc("CONCEPTO") = "Ingresos reales del ciclo anterior"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosAnterior(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosAnterior(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilEnc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)


        '0.1 - Transferencias entre socios.

        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "N"
        drConcilEnc("ID") = 0.1
        drConcilEnc("CONCEPTO") = "Transferencias entre socios"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosTransferenciasSocios(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosTransferenciasSocios(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilEnc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)


        '1 - Vacío
        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "N"
        drConcilEnc("ID") = 1
        drConcilEnc("CONCEPTO") = ""
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = ""
            Else
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = ""
            End If
        Next
        drConcilEnc("TOTAL") = ""
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '2 - Ingresos No Recurrentes
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "S"
        drConcilEnc("ID") = 2
        drConcilEnc("CONCEPTO") = "    - Ingresos especiales no recurrentes"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosNoRecurrentes(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosNoRecurrentes(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilEnc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '3 - Trabajos perdidos.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "S"
        drConcilEnc("ID") = 3
        drConcilEnc("CONCEPTO") = "    - Clientes perdidos"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosPerdidos(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosPerdidos(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilEnc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '4 - Trabajos Recurrentes No Arreglados.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "S"
        drConcilEnc("ID") = 4
        drConcilEnc("CONCEPTO") = "    - Ingresos recurrentes por arreglar"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosRecurrentesNoArreglados(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosRecurrentesNoArreglados(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilEnc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '5 - Trabajos Nuevos Ganados.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "S"
        drConcilEnc("ID") = 5
        drConcilEnc("CONCEPTO") = "    + Clientes ganados"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosNuevas(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosNuevas(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilEnc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '6 - Trabajos Arreglados.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "S"
        drConcilEnc("ID") = 6
        drConcilEnc("CONCEPTO") = "    + Incremento/Decremento clientes recurrentes arreglados"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosRecurrentes(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosRecurrentes(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilEnc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '7 - Subtotal de conceptos anteriores (sin ingresos reales anteriores).
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "N"
        drConcilEnc("ID") = 7
        drConcilEnc("CONCEPTO") = "Subtotal"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = 0
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = 0
                dTotHonorarios += dImporte
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilEnc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '8 - Ingresos reales anteriores - Subtotal.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "N"
        drConcilEnc("ID") = 8
        drConcilEnc("CONCEPTO") = "Ingresos contratados a la fecha"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = 0
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = 0
                dTotHonorarios += dImporte
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilEnc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '9 - Ingresos Presupuestados del ciclo
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "N"
        drConcilEnc("ID") = 9
        drConcilEnc("CONCEPTO") = "Ingresos Presupuestados del ciclo"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosPresupuesto(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosPresupuesto(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilEnc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '10 - Vacío
        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "N"
        drConcilEnc("ID") = 10
        drConcilEnc("CONCEPTO") = ""
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = ""
            Else
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = ""
            End If
        Next
        drConcilEnc("TOTAL") = ""
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '11 - Ingresos faltantes por conseguir.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "N"
        drConcilEnc("ID") = 11
        drConcilEnc("CONCEPTO") = "Ingresos por conseguir"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = 0
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = 0
                dTotHonorarios += dImporte
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilEnc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '12 - Vacío
        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "N"
        drConcilEnc("ID") = 12
        drConcilEnc("CONCEPTO") = ""
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = ""
            Else
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = ""
            End If
        Next
        drConcilEnc("TOTAL") = ""
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '13 - Propuestas por resolver.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "S"
        drConcilEnc("ID") = 13
        drConcilEnc("CONCEPTO") = "Propuestas pendientes de resolver"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosPorResolver(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosPorResolver(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilEnc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        '14 - % de Bateo.
        dImpAud = 0
        dImporte = 0
        dImporteAudRec = 0
        dImporteRec = 0

        drConcilEnc = dtConcilEnc.NewRow
        drConcilEnc("TIPO") = "S"
        drConcilEnc("ID") = 14
        drConcilEnc("CONCEPTO") = "% de bateo"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosTotalProp(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporteAudRec = ObtenerHonorariosRechazadas(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dImporteRec += dImporteAudRec

                dTotHonorarios += dImpAud
                If dImporte = 0 Then
                    drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format(0, sFmtDbl)
                Else
                    drConcilEnc(row.Item("CVEOFI") & "-AUD") = Format((dImporteRec / dImporte) * 100, sFmtDbl)
                End If
            Else
                dImporte = ObtenerHonorariosTotalProp(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporteRec = ObtenerHonorariosRechazadas(row.Item("CVEOFI"), row.Item("CVEAREA"))

                dTotHonorarios += dImporte
                dTotHonorarios += dImporteRec
                If dImporte = 0 Then
                    drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(0, sFmtDbl)
                Else
                    drConcilEnc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format((dImporteRec / dImporte) * 100, sFmtDbl)
                End If
            End If
        Next

        drConcilEnc("TOTAL") = ""
        dtConcilEnc.Rows.InsertAt(drConcilEnc, dtConcilEnc.Rows.Count)

        bs.DataSource = dtConcilEnc
        FormatoGrid()

        SumaTotales()
    End Sub
    Private Sub listarReporteDireccionSocio()
        LimpiarTabla(dtConcilSoc)
        bs.DataSource = Nothing

        dImpAud = 0
        dImpDif = 0
        dImporte = 0
        dTotHonorarios = 0

        '0 - Ingresos reales
        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 0
        drConcilSoc("CONCEPTO") = "Ingresos reales del ciclo anterior"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosCicloAnteriorSocio(sNumeroSocio, row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosCicloAnteriorSocio(sNumeroSocio, row.Item("CVEOFI"), row.Item("CVEAREA"))
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
                dTotHonorarios += dImporte
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '0.1 - Transferencias entre socios.

        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 0.1
        drConcilSoc("CONCEPTO") = "Transferencias entre socios"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosTransferenciasSocios(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosTransferenciasSocios(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '1 - Vacío
        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 1
        drConcilSoc("CONCEPTO") = ""
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = ""
            Else
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = ""
            End If
        Next
        drConcilSoc("TOTAL") = ""
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '2 - Ingresos No Recurrentes
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 2
        drConcilSoc("CONCEPTO") = "    - Ingresos especiales no recurrentes"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosNoRecurrentes(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosNoRecurrentes(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '3 - Trabajos perdidos.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 3
        drConcilSoc("CONCEPTO") = "    - Clientes perdidos"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosPerdidos(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosPerdidos(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '4 - Trabajos Recurrentes No Arreglados.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 4
        drConcilSoc("CONCEPTO") = "    - Ingresos recurrentes por arreglar"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosRecurrentesNoArreglados(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosRecurrentesNoArreglados(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '5 - Trabajos Nuevos Ganados.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 5
        drConcilSoc("CONCEPTO") = "    + Clientes ganados"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosNuevas(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosNuevas(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '6 - Trabajos Arreglados.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 6
        drConcilSoc("CONCEPTO") = "    + Incremento/Decremento clientes recurrentes arreglados"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosRecurrentes(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosRecurrentes(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '7 - Subtotal de conceptos anteriores (sin ingresos reales anteriores).
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 7
        drConcilSoc("CONCEPTO") = "Subtotal"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = 0
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = 0
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '8 - Ingresos reales anteriores - Subtotal.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 8
        drConcilSoc("CONCEPTO") = "Ingresos contratados a la fecha"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = 0
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = 0
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '9 - Ingresos Presupuestados del ciclo
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 9
        drConcilSoc("CONCEPTO") = "Ingresos Presupuestados del ciclo"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosPresupuesto(row.Item("CVEOFI"), row.Item("CVEAREA"), sNumeroSocio)
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosPresupuesto(row.Item("CVEOFI"), row.Item("CVEAREA"), sNumeroSocio)
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '10 - Vacío
        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 10
        drConcilSoc("CONCEPTO") = ""
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = ""
            Else
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = ""
            End If
        Next
        drConcilSoc("TOTAL") = ""
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '11 - Ingresos faltantes por conseguir.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 11
        drConcilSoc("CONCEPTO") = "Ingresos por conseguir"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = 0
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = 0
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '12 - Vacío
        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 12
        drConcilSoc("CONCEPTO") = ""
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = ""
            Else
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = ""
            End If
        Next
        drConcilSoc("TOTAL") = ""
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '13 - Propuestas por resolver.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 13
        drConcilSoc("CONCEPTO") = "Propuestas pendientes de resolver"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosPorResolver(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosPorResolver(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '14 - % de Bateo.
        dImpAud = 0
        dImporte = 0
        dImporteAudRec = 0
        dImporteRec = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 14
        drConcilSoc("CONCEPTO") = "% de bateo"
        For Each row As DataRow In dtPermisosRep.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosTotalProp(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporteAudRec = ObtenerHonorariosRechazadas(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dImporteRec += dImporteAudRec

                dTotHonorarios += dImpAud
                If dImporte = 0 Then
                    drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(0, sFmtDbl)
                Else
                    drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format((dImporteRec / dImporte) * 100, sFmtDbl)
                End If
            Else
                dImporte = ObtenerHonorariosTotalProp(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporteRec = ObtenerHonorariosRechazadas(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                dTotHonorarios += dImporteRec
                If dImporte = 0 Then
                    drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(0, sFmtDbl)
                Else
                    drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format((dImporteRec / dImporte) * 100, sFmtDbl)
                End If
            End If
        Next
        drConcilSoc("TOTAL") = ""
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        bs.DataSource = dtConcilSoc
        FormatoGridSocio()

        SumaTotales()
    End Sub
    Private Sub listarReporteDireccionUsuario()
        LimpiarTabla(dtConcilSoc)
        bs.DataSource = Nothing

        dImpAud = 0
        dImpDif = 0
        dImporte = 0
        dTotHonorarios = 0

        '0 - Ingresos reales
        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 0
        drConcilSoc("CONCEPTO") = "Ingresos reales del ciclo anterior"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosCicloAnteriorSocio(sCveUsuario, row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosCicloAnteriorSocio(sCveUsuario, row.Item("CVEOFI"), row.Item("CVEAREA"))
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
                dTotHonorarios += dImporte
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '0.1 - Transferencias entre socios.

        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 0.1
        drConcilSoc("CONCEPTO") = "Transferencias entre socios"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosTransferenciasSocios(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosTransferenciasSocios(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '1 - Vacío
        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 1
        drConcilSoc("CONCEPTO") = ""
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = ""
            Else
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = ""
            End If
        Next
        drConcilSoc("TOTAL") = ""
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '2 - Ingresos No Recurrentes
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 2
        drConcilSoc("CONCEPTO") = "    - Ingresos especiales no recurrentes"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosNoRecurrentes(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosNoRecurrentes(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '3 - Trabajos perdidos.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 3
        drConcilSoc("CONCEPTO") = "    - Clientes perdidos"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosPerdidos(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosPerdidos(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '4 - Trabajos Recurrentes No Arreglados.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 4
        drConcilSoc("CONCEPTO") = "    - Ingresos recurrentes por arreglar"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosRecurrentesNoArreglados(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosRecurrentesNoArreglados(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '5 - Trabajos Nuevos Ganados.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 5
        drConcilSoc("CONCEPTO") = "    + Clientes ganados"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosNuevas(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosNuevas(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '6 - Trabajos Arreglados.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 6
        drConcilSoc("CONCEPTO") = "    + Incremento/Decremento clientes recurrentes arreglados"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosRecurrentes(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosRecurrentes(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '7 - Subtotal de conceptos anteriores (sin ingresos reales anteriores).
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 7
        drConcilSoc("CONCEPTO") = "Subtotal"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = 0
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = 0
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '8 - Ingresos reales anteriores - Subtotal.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 8
        drConcilSoc("CONCEPTO") = "Ingresos contratados a la fecha"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = 0
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = 0
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '9 - Ingresos Presupuestados del ciclo
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 9
        drConcilSoc("CONCEPTO") = "Ingresos Presupuestados del ciclo"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosPresupuesto(row.Item("CVEOFI"), row.Item("CVEAREA"), sCveUsuario)
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosPresupuesto(row.Item("CVEOFI"), row.Item("CVEAREA"), sCveUsuario)
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '10 - Vacío
        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 10
        drConcilSoc("CONCEPTO") = ""
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = ""
            Else
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = ""
            End If
        Next
        drConcilSoc("TOTAL") = ""
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '11 - Ingresos faltantes por conseguir.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 11
        drConcilSoc("CONCEPTO") = "Ingresos por conseguir"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = 0
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = 0
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '12 - Vacío
        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "N"
        drConcilSoc("ID") = 12
        drConcilSoc("CONCEPTO") = ""
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = ""
            Else
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = ""
            End If
        Next
        drConcilSoc("TOTAL") = ""
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '13 - Propuestas por resolver.
        dImpAud = 0
        dImporte = 0
        dTotHonorarios = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 13
        drConcilSoc("CONCEPTO") = "Propuestas pendientes de resolver"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosPorResolver(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dTotHonorarios += dImpAud
                drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(dImporte, sFmtDbl)
            Else
                dImporte = ObtenerHonorariosPorResolver(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(dImporte, sFmtDbl)
            End If
        Next
        drConcilSoc("TOTAL") = Format(dTotHonorarios, sFmtDbl)
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        '14 - % de Bateo.
        dImpAud = 0
        dImporte = 0
        dImporteAudRec = 0
        dImporteRec = 0

        drConcilSoc = dtConcilSoc.NewRow
        drConcilSoc("TIPO") = "S"
        drConcilSoc("ID") = 14
        drConcilSoc("CONCEPTO") = "% de bateo"
        For Each row As DataRow In dtPermisosUsu.Rows
            If row.Item("CVEOFI") = "MEX" And (row.Item("CVEAREA") = "AUD" Or row.Item("CVEAREA") = "CO" Or row.Item("CVEAREA") = "SS" Or row.Item("CVEAREA") = "ATI") Then
                dImpAud = ObtenerHonorariosTotalProp(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporteAudRec = ObtenerHonorariosRechazadas(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporte += dImpAud
                dImporteRec += dImporteAudRec

                dTotHonorarios += dImpAud
                If dImporte = 0 Then
                    drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format(0, sFmtDbl)
                Else
                    drConcilSoc(row.Item("CVEOFI") & "-AUD") = Format((dImporteRec / dImporte) * 100, sFmtDbl)
                End If
            Else
                dImporte = ObtenerHonorariosTotalProp(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dImporteRec = ObtenerHonorariosRechazadas(row.Item("CVEOFI"), row.Item("CVEAREA"))
                dTotHonorarios += dImporte
                dTotHonorarios += dImporteRec
                If dImporte = 0 Then
                    drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format(0, sFmtDbl)
                Else
                    drConcilSoc(row.Item("CVEOFI") & "-" & row.Item("CVEAREA")) = Format((dImporteRec / dImporte) * 100, sFmtDbl)
                End If
            End If
        Next
        drConcilSoc("TOTAL") = ""
        dtConcilSoc.Rows.InsertAt(drConcilSoc, dtConcilSoc.Rows.Count)

        bs.DataSource = dtConcilSoc
        FormatoGridSocio()

        SumaTotales()
    End Sub
    Private Sub SumaTotales()
        dIng = 0
        dImpNR = 0
        dImpPer = 0
        dImpNA = 0
        dImpGan = 0
        dImpRec = 0
        dIngPpto = 0
        dSubtotal = 0
        dIngCon = 0
        dIngPC = 0
        dSubtotal = 0
        dDiferencia = 0

        For c As Integer = 3 To gridConciliacion.Columns.Count - 1
            dIng = CDbl(gridConciliacion.Rows(0).Cells(c).Value)
            dIngTransf = CDbl(gridConciliacion.Rows(1).Cells(c).Value)
            'dDiferencia = CDbl(gridConciliacion.Rows(3).Cells(c).Value)

            dImpNR = CDbl(gridConciliacion.Rows(3).Cells(c).Value)
            dImpPer = CDbl(gridConciliacion.Rows(4).Cells(c).Value)
            dImpNA = CDbl(gridConciliacion.Rows(5).Cells(c).Value)
            dImpGan = CDbl(gridConciliacion.Rows(6).Cells(c).Value)
            dImpRec = CDbl(gridConciliacion.Rows(7).Cells(c).Value)
            dIngPpto = CDbl(gridConciliacion.Rows(10).Cells(c).Value)

            dSubtotal = (-dImpNR - dImpPer - dImpNA + dImpGan + dImpRec)

            gridConciliacion.Rows(8).Cells(c).Value = Format(dSubtotal, sFmtDbl)

            dIngCon = (dIng + dIngTransf + dSubtotal)
            gridConciliacion.Rows(9).Cells(c).Value = Format(dIngCon, sFmtDbl)

            dIngPC = (dIngPpto - dIngCon)
            gridConciliacion.Rows(12).Cells(c).Value = Format(dIngPC, sFmtDbl)
        Next
    End Sub

#End Region
#Region "TRABAJOS NO RECURRENTES"

    Private Sub ListarNoRecurrentesConciliacion(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim dTotHon As Double = 0
            Dim HonoAct As Double = 0

            Dim dTotHonArre As Double = 0
            Dim HonoActArre As Double = 0

            Dim sTabla As String = "tbNoRecurrentesConcil"
            LimpiarTabla(dtNoRecurrentesConcil)
            HonoAct = 0
            dTotHon = 0
            dTotHonArre = 0
            HonoActArre = 0

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If
                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 30, SqlDbType.Int, ParameterDirection.Input)
                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If
                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)
                    End With
                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtNoRecurrentesDatos = .Item(sTabla)
                    For Each r As DataRow In dtNoRecurrentesDatos.Rows
                        HonoAct = r.Item("HONORARIOSACTUAL").ToString
                        dTotHon += HonoAct

                        HonoActArre = r.Item("HONORARIOSARREGLADOMN").ToString
                        dTotHonArre += HonoActArre

                        dtNoRecConcil = dtNoRecurrentesConcil.NewRow
                        dtNoRecConcil("TIPO") = "S"
                        dtNoRecConcil("PERIODO") = r.Item("PERIODO").ToString
                        dtNoRecConcil("HONORARIOSACTUAL") = Format(CDbl(HonoAct), "$ " & sFmtDbl)
                        dtNoRecConcil("MONEDA") = "NO"
                        dtNoRecConcil("SOCIO") = r.Item("SOCIO").ToString
                        dtNoRecConcil("OFICINA") = r.Item("OFICINA").ToString
                        dtNoRecConcil("DIVISION") = r.Item("DIVISION").ToString
                        dtNoRecConcil("EMPRESA") = r.Item("EMPRESA").ToString
                        dtNoRecConcil("SERVICIO") = r.Item("SERVICIO").ToString
                        dtNoRecConcil("HONORARIOSARREGLADOMN") = Format(CDbl(HonoActArre), "$ " & sFmtDbl)
                        dtNoRecConcil("CVETRABAJO") = r.Item("CVETRABAJO").ToString
                        dtNoRecurrentesConcil.Rows.InsertAt(dtNoRecConcil, dtNoRecurrentesConcil.Rows.Count)
                    Next
                End With
            Next
            dtNoRecConcil = dtNoRecurrentesConcil.NewRow
            dtNoRecConcil("TIPO") = "T"
            dtNoRecConcil("PERIODO") = ""
            dtNoRecConcil("HONORARIOSACTUAL") = Format(dTotHon, "$ " & sFmtDbl)
            dtNoRecConcil("MONEDA") = ""
            dtNoRecConcil("SOCIO") = ""
            dtNoRecConcil("OFICINA") = ""
            dtNoRecConcil("DIVISION") = ""
            dtNoRecConcil("EMPRESA") = "TOTAL:"
            dtNoRecConcil("SERVICIO") = ""
            dtNoRecConcil("HONORARIOSARREGLADOMN") = Format(dTotHonArre, "$ " & sFmtDbl)
            dtNoRecConcil("CVETRABAJO") = ""
            dtNoRecurrentesConcil.Rows.InsertAt(dtNoRecConcil, dtNoRecurrentesConcil.Rows.Count)
            bsNoR.DataSource = dtNoRecurrentesConcil
            FormatoGridNoRecurrentes()
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarNoRecurrentesConciliacion")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtNoRecurrentesDatos = Nothing
        End Try
    End Sub
    Private Sub ListarHonorariosNoRecurrentes(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim sTabla As String = "tbHonNoRec"

            LimpiarTabla(dtHonNoRec)

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 14, SqlDbType.Int, ParameterDirection.Input)

                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If

                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)

                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtHonNoRecDatos = .Item(sTabla)

                    For Each r As DataRow In dtHonNoRecDatos.Rows
                        drHonNoRec = dtHonNoRec.NewRow
                        drHonNoRec("HONORARIOS") = r.Item("HONORARIOSPROPUESTA").ToString
                        drHonNoRec("OFICINA") = r.Item("CVEOFI").ToString
                        drHonNoRec("DIVISION") = r.Item("CVEAREA").ToString
                        dtHonNoRec.Rows.InsertAt(drHonNoRec, dtHonNoRec.Rows.Count)
                    Next
                End With
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosNoRecurrentes()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtHonNoRecDatos = Nothing
        End Try
    End Sub

#End Region
#Region "TRABAJOS PERDIDOS"

    Private Sub ListarPerdidosConciliacion(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim dTotHon As Double = 0
            Dim HonoAct As Double = 0
            Dim dTotHonArre As Double = 0
            Dim HonoActArre As Double = 0
            Dim iPerdidosSM As Integer = 0

            Dim sTabla As String = "tbPerdidosConcil"

            LimpiarTabla(dtPeridosConcil)
            HonoAct = 0
            dTotHon = 0
            dTotHonArre = 0
            HonoActArre = 0
            iPerdidosSM = 0

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 31, SqlDbType.Int, ParameterDirection.Input)
                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If
                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)

                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtPerdidasDatos = .Item(sTabla)

                    For Each r As DataRow In dtPerdidasDatos.Rows
                        HonoAct = r.Item("HONORARIOSACTUAL").ToString
                        dTotHon += HonoAct

                        HonoActArre = r.Item("HONORARIOSARREGLADOMN").ToString
                        dTotHonArre += HonoActArre

                        drPerdidosConcil = dtPeridosConcil.NewRow
                        drPerdidosConcil("TIPO") = "S"
                        drPerdidosConcil("CAMBIO") = "N"
                        drPerdidosConcil("CVEOFI") = r.Item("CVEOFI").ToString
                        drPerdidosConcil("CVEAREA") = r.Item("CVEAREA").ToString
                        drPerdidosConcil("PERIODO") = r.Item("PERIODO").ToString
                        drPerdidosConcil("HONORARIOSACTUAL") = Format(CDbl(HonoAct), "$ " & sFmtDbl)
                        drPerdidosConcil("MONEDA") = "NO"
                        drPerdidosConcil("SOCIO") = r.Item("SOCIO").ToString
                        drPerdidosConcil("OFICINA") = r.Item("OFICINA").ToString
                        drPerdidosConcil("DIVISION") = r.Item("DIVISION").ToString
                        drPerdidosConcil("EMPRESA") = r.Item("EMPRESA").ToString
                        drPerdidosConcil("SERVICIO") = r.Item("SERVICIO").ToString
                        drPerdidosConcil("HONORARIOSARREGLADOMN") = Format(CDbl(HonoActArre), "$ " & sFmtDbl)
                        drPerdidosConcil("CVETRABAJO") = r.Item("CVETRABAJO").ToString
                        drPerdidosConcil("MOTIVO") = r.Item("MOTIVO").ToString
                        dtPeridosConcil.Rows.InsertAt(drPerdidosConcil, dtPeridosConcil.Rows.Count)

                        If r.Item("MOTIVO").ToString = "" Then
                            iPerdidosSM += 1
                        End If
                    Next
                End With
            Next

            drPerdidosConcil = dtPeridosConcil.NewRow
            drPerdidosConcil("TIPO") = "T"
            drPerdidosConcil("CAMBIO") = ""
            drPerdidosConcil("CVEOFI") = ""
            drPerdidosConcil("CVEAREA") = ""
            drPerdidosConcil("PERIODO") = ""
            drPerdidosConcil("HONORARIOSACTUAL") = Format(dTotHon, "$ " & sFmtDbl)
            drPerdidosConcil("MONEDA") = ""
            drPerdidosConcil("SOCIO") = ""
            drPerdidosConcil("OFICINA") = ""
            drPerdidosConcil("DIVISION") = ""
            drPerdidosConcil("CVETRABAJO") = ""
            drPerdidosConcil("EMPRESA") = "TOTAL:"
            drPerdidosConcil("SERVICIO") = ""
            drPerdidosConcil("HONORARIOSARREGLADOMN") = Format(dTotHonArre, "$ " & sFmtDbl)
            drPerdidosConcil("MOTIVO") = ""
            dtPeridosConcil.Rows.InsertAt(drPerdidosConcil, dtPeridosConcil.Rows.Count)

            If dtPeridosConcil.Rows.Count = 1 Then
                lblMsgPer.Visible = False

                gridPerdidos.Dock = DockStyle.Fill
            End If

            If iPerdidosSM > 0 Then
                lblMsgPer.Visible = True

                gridPerdidos.Dock = DockStyle.None
                gridPerdidos.Location = New Point(0, 29)
                gridPerdidos.Size = New Point(tabPerdidos.Width, (tabPerdidos.Height - 66))
                gridPerdidos.Anchor = AnchorStyles.Right + AnchorStyles.Left + AnchorStyles.Top + AnchorStyles.Bottom
            ElseIf iPerdidosSM = 0 Then
                lblMsgPer.Visible = False

                gridPerdidos.Dock = DockStyle.Fill
            End If

            bsPer.DataSource = dtPeridosConcil
            FormatoGridPerdidos()
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarNoRecurrentesConciliacion")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtPerdidasDatos = Nothing
        End Try
    End Sub
    Private Sub ListarHonorariosPerdidos(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim sTabla As String = "tbHonPer"

            LimpiarTabla(dtHonPer)

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If
                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)
                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtHonPerdatos = .Item(sTabla)

                    For Each r As DataRow In dtHonPerdatos.Rows
                        drHonPer = dtHonPer.NewRow
                        drHonPer("HONORARIOS") = r.Item("HONORARIOSPROPUESTA").ToString
                        drHonPer("OFICINA") = r.Item("CVEOFI").ToString
                        drHonPer("DIVISION") = r.Item("CVEAREA").ToString
                        dtHonPer.Rows.InsertAt(drHonPer, dtHonPer.Rows.Count)
                    Next
                End With
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosPerdidos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtHonPerdatos = Nothing
        End Try
    End Sub

#End Region

#Region "OBTENER HONORARIOS DIFERENCIA PPTO REAL"

    Private Sub ListarHonorariosDiferenciaPptoReal(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim sTabla As String = "tbDifPptoReal"

            LimpiarTabla(dtDiferenciaPpto)

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 33, SqlDbType.Int, ParameterDirection.Input)

                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If

                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)

                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtDiferenciaPptoDatos = .Item(sTabla)

                    For Each r As DataRow In dtDiferenciaPptoDatos.Rows

                        drDiferenciaPpto = dtDiferenciaPpto.NewRow
                        drDiferenciaPpto("SOCIO") = r.Item("sCveSocio").ToString
                        drDiferenciaPpto("HONORARIOSPPTO") = r.Item("HONORARIOSPPTO").ToString
                        drDiferenciaPpto("HONORARIOSFAC") = r.Item("HONORARIOSFAC").ToString
                        drDiferenciaPpto("OFICINA") = r.Item("CVEOFI").ToString
                        drDiferenciaPpto("DIVISION") = r.Item("CVEAREA").ToString
                        dtDiferenciaPpto.Rows.InsertAt(drDiferenciaPpto, dtDiferenciaPpto.Rows.Count)
                    Next
                End With
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosRecurrentesNoArreglados")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtDiferenciaPptoDatos = Nothing
        End Try
    End Sub

#End Region
#Region "TRANSFERENCIAS ENTRE SOCIOS"

    Private Sub ListarHonorariosTransferenciasSocios(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim sTabla As String = "tbTransfSocios"

            LimpiarTabla(dtTransfSoc)

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 34, SqlDbType.Int, ParameterDirection.Input)

                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If

                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)

                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtTransfSocDatos = .Item(sTabla)

                    For Each r As DataRow In dtTransfSocDatos.Rows

                        drTransfSoc = dtTransfSoc.NewRow
                        drTransfSoc("HONORARIOSFAC") = r.Item("HONORARIOSFAC").ToString
                        drTransfSoc("OFICINA") = r.Item("CVEOFI").ToString
                        drTransfSoc("DIVISION") = r.Item("CVEAREA").ToString
                        dtTransfSoc.Rows.InsertAt(drTransfSoc, dtTransfSoc.Rows.Count)
                    Next
                End With
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosTransferenciasSocios")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtTransfSocDatos = Nothing
        End Try
    End Sub

#End Region


#Region "TRABAJOS RECURRENTES NO ARREGLADOS"

    Private Sub ListarNoArregladosConciliacion(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim dTotHon As Double = 0
            Dim HonoAct As Double = 0

            Dim dTotHonArre As Double = 0
            Dim HonoActArre As Double = 0

            Dim sTabla As String = "tbNoArregladosConcil"

            LimpiarTabla(dtNoArregladosConcil)
            HonoAct = 0
            dTotHon = 0

            dTotHonArre = 0
            HonoActArre = 0

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 32, SqlDbType.Int, ParameterDirection.Input)
                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If
                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)

                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtNoArregladosDatos = .Item(sTabla)

                    For Each r As DataRow In dtNoArregladosDatos.Rows
                        HonoAct = CDbl(r.Item("HONORARIOSACTUAL").ToString)
                        dTotHon += HonoAct

                        HonoActArre = CDbl(r.Item("HONORARIOSARREGLADOMN").ToString)
                        dTotHonArre += HonoActArre

                        drNoArregladosConcil = dtNoArregladosConcil.NewRow
                        drNoArregladosConcil("TIPO") = "S"
                        drNoArregladosConcil("PERIODO") = r.Item("PERIODO").ToString
                        drNoArregladosConcil("MONEDA") = ""
                        drNoArregladosConcil("SOCIO") = r.Item("SOCIO").ToString
                        drNoArregladosConcil("OFICINA") = r.Item("OFICINA").ToString
                        drNoArregladosConcil("DIVISION") = r.Item("DIVISION").ToString
                        drNoArregladosConcil("CVETRABAJO") = r.Item("CVETRABAJO").ToString
                        drNoArregladosConcil("EMPRESA") = r.Item("EMPRESA").ToString
                        drNoArregladosConcil("SERVICIO") = r.Item("SERVICIO").ToString
                        drNoArregladosConcil("HONORARIOSACTUAL") = Format(CDbl(HonoAct), "$ " & sFmtDbl)
                        drNoArregladosConcil("HONORARIOSARREGLADOMN") = Format(CDbl(HonoActArre), "$ " & sFmtDbl)
                        dtNoArregladosConcil.Rows.InsertAt(drNoArregladosConcil, dtNoArregladosConcil.Rows.Count)
                    Next
                End With
            Next

            drNoArregladosConcil = dtNoArregladosConcil.NewRow
            drNoArregladosConcil("TIPO") = "T"
            drNoArregladosConcil("PERIODO") = ""
            drNoArregladosConcil("MONEDA") = ""
            drNoArregladosConcil("SOCIO") = ""
            drNoArregladosConcil("OFICINA") = ""
            drNoArregladosConcil("DIVISION") = ""
            drNoArregladosConcil("CVETRABAJO") = ""
            drNoArregladosConcil("EMPRESA") = "TOTAL:"
            drNoArregladosConcil("SERVICIO") = ""
            drNoArregladosConcil("HONORARIOSACTUAL") = Format(dTotHon, "$ " & sFmtDbl)
            drNoArregladosConcil("HONORARIOSARREGLADOMN") = Format(dTotHonArre, "$ " & sFmtDbl)
            dtNoArregladosConcil.Rows.InsertAt(drNoArregladosConcil, dtNoArregladosConcil.Rows.Count)

            bsRNA.DataSource = dtNoArregladosConcil
            formatoGridNoArreglados()
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarNoRecurrentesConciliacion")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtRechazadas = Nothing
        End Try
    End Sub
    Private Sub ListarHonorariosRecurrentesNoArreglados(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim sTabla As String = "tbRecNoArr"

            LimpiarTabla(dtHonRecNoArr)

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)

                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If

                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)

                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtHonRecNoArrDatos = .Item(sTabla)

                    For Each r As DataRow In dtHonRecNoArrDatos.Rows

                        drHonRecNoArr = dtHonRecNoArr.NewRow
                        drHonRecNoArr("HONORARIOS") = r.Item("HONORARIOSPROPUESTA").ToString
                        drHonRecNoArr("OFICINA") = r.Item("CVEOFI").ToString
                        drHonRecNoArr("DIVISION") = r.Item("CVEAREA").ToString
                        dtHonRecNoArr.Rows.InsertAt(drHonRecNoArr, dtHonRecNoArr.Rows.Count)
                    Next
                End With
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosRecurrentesNoArreglados")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtHonRecNoArrDatos = Nothing
        End Try
    End Sub

#End Region
#Region "TRABAJOS NUEVOS GANADOS"

    Private Sub listarPropuestasNuevasGanadas(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim dTotHon As Double
            Dim HonoAct As Decimal = 0.0
            Dim HonoAnt As Decimal = 0.0

            Dim sTabla As String = "tbNuevas"

            LimpiarTabla(dtNuevasGan)
            dTotHon = 0

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If
                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)
                        .subAddParameter("@bCon", Bandera, SqlDbType.Bit, ParameterDirection.Input)
                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtNuevasGanDatos = .Item(sTabla)

                    For Each r As DataRow In dtNuevasGanDatos.Rows
                        HonoAct = r.Item("HONORARIOSPROPUESTA").ToString
                        HonoAnt = 0
                        dTotHon += HonoAct

                        drGaN = dtNuevasGan.NewRow
                        drGaN("TIPO") = "S"
                        drGaN("PERIODO") = r.Item("PERIODO").ToString
                        drGaN("HONORARIOSACTUAL") = Format(CDbl(HonoAct), "$ " & sFmtDbl)
                        drGaN("MONEDA") = "NO"
                        drGaN("SOCIO") = r.Item("NOMSOC").ToString
                        drGaN("OFICINA") = r.Item("OFICINA").ToString
                        drGaN("DIVISION") = r.Item("DIVISION").ToString
                        drGaN("CICLO") = r.Item("CICLO").ToString
                        drGaN("EMPRESA") = r.Item("EMPRESA").ToString
                        drGaN("DESCRIPCION") = r.Item("DESCRIPCION").ToString
                        drGaN("SERVICIO") = r.Item("SERVICIO").ToString
                        drGaN("HONORARIOSARREGLADOMN") = Format(CDbl(HonoAct), "$ " & sFmtDbl)
                        drGaN("CVETRABAJO") = r.Item("CVETRA").ToString

                        drGaN("HONETOS") = Format(CDbl(HonoAct), "$ " & sFmtDbl)
                        drGaN("HORCOTIZADAS") = r.Item("HORCOTIZADAS").ToString
                        drGaN("CUOTA") = r.Item("CUOTA").ToString
                        drGaN("WOFF") = r.Item("WOFF").ToString
                        drGaN("INDUSTRIA") = r.Item("INDUSTRIA").ToString
                        drGaN("SUBSECTOR") = r.Item("SUBSECTOR").ToString

                        drGaN("COMO") = r.Item("COMO").ToString
                        drGaN("MEDIO") = r.Item("MEDIO").ToString

                        drGaN("REFGTSOCIO") = r.Item("REFGTSOCIO").ToString
                        drGaN("REFGTOFI") = r.Item("REFGTOFI").ToString
                        drGaN("REFGTPAIS") = r.Item("REFGTPAIS").ToString

                        drGaN("PUESTO") = r.Item("PUESTO").ToString
                        drGaN("REFNOMB") = r.Item("REFNOMB").ToString
                        drGaN("REFOFI") = r.Item("REFOFI").ToString
                        drGaN("REFDIV") = r.Item("REFDIV").ToString


                        dtNuevasGan.Rows.InsertAt(drGaN, dtNuevasGan.Rows.Count)
                    Next
                End With
            Next

            drGaN = dtNuevasGan.NewRow
            drGaN("TIPO") = "T"
            drGaN("PERIODO") = ""
            drGaN("HONORARIOSACTUAL") = Format(dTotHon, "$ " & sFmtDbl)
            drGaN("MONEDA") = ""
            drGaN("SOCIO") = ""
            drGaN("OFICINA") = ""
            drGaN("DIVISION") = ""
            drGaN("CICLO") = ""
            drGaN("EMPRESA") = "TOTAL:"
            drGaN("DESCRIPCION") = ""
            drGaN("SERVICIO") = ""
            drGaN("HONORARIOSARREGLADOMN") = Format(dTotHon, "$ " & sFmtDbl)
            drGaN("CVETRABAJO") = ""
            drGaN("HONETOS") = Format(dTotHon, "$ " & sFmtDbl)
            drGaN("HORCOTIZADAS") = ""
            drGaN("CUOTA") = ""
            drGaN("WOFF") = ""
            drGaN("INDUSTRIA") = ""
            drGaN("SUBSECTOR") = ""
            drGaN("REFGTSOCIO") = ""
            drGaN("REFGTOFI") = ""
            drGaN("REFGTPAIS") = ""
            drGaN("PUESTO") = ""
            drGaN("REFNOMB") = ""
            drGaN("REFOFI") = ""
            drGaN("REFDIV") = ""
            drGaN("COMO") = ""
            drGaN("MEDIO") = ""

            dtNuevasGan.Rows.InsertAt(drGaN, dtNuevasGan.Rows.Count)

            bsNvo.DataSource = dtNuevasGan
            formatoGridNuevosGanados()
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "listarPropuestasNuevasGanadas()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtNuevasGanDatos = Nothing
        End Try
    End Sub
    Private Sub ListarHonorariosNuevas(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim sTabla As String = "tbHonNuevas"

            LimpiarTabla(dtHonNuevas)

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 12, SqlDbType.Int, ParameterDirection.Input)

                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If

                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)
                        .subAddParameter("@bCon", Bandera, SqlDbType.Bit, ParameterDirection.Input)
                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtHonNuevasDatos = .Item(sTabla)

                    For Each r As DataRow In dtHonNuevasDatos.Rows
                        drHonNuevas = dtHonNuevas.NewRow
                        drHonNuevas("HONORARIOS") = r.Item("HONORARIOSPROPUESTA").ToString
                        drHonNuevas("OFICINA") = r.Item("CVEOFI").ToString
                        drHonNuevas("DIVISION") = r.Item("CVEAREA").ToString
                        dtHonNuevas.Rows.InsertAt(drHonNuevas, dtHonNuevas.Rows.Count)
                    Next
                End With
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosNuevas")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtHonNuevasDatos = Nothing
        End Try
    End Sub

#End Region
#Region "TRABAJOS RECURRENTES"

    Private Sub ListarPropuestasRecurrentes(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim sTabla As String = "tbRecurrentes"
            Dim dTotHonAnt, dTotHonAct, HonoAnt, HonoAct, dHonoPpto, dTotHonoPpto As Double

            LimpiarTabla(dtRecurrentes)
            dTotHonAnt = 0
            dTotHonAct = 0
            HonoAnt = 0
            HonoAct = 0
            dHonoPpto = 0

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If
                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)
                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtRecurrentesDatos = .Item(sTabla)

                    For Each r As DataRow In dtRecurrentesDatos.Rows

                        If r.Item("TIPOPROPUESTA").ToString = "P" Then
                            dHonoPpto = r.Item("HONORARIOSPPTO")
                        Else
                            dHonoPpto = ObtenerHonorariosPptoAsoc(r.Item("CVETRA"))
                        End If

                        If r.Item("TIPOPROPUESTA").ToString = "P" Then
                            HonoAnt = ObtenerHonorariosCicloAnterior(r.Item("CVEPPTO").ToString, 2, r.Item("CVEEMP").ToString())
                            HonoAnt += ObtenerHonorariosCicloAnteriorNoRecurrentesPpto(r.Item("CVETRA").ToString)
                        Else
                            HonoAnt = ObtenerHonorariosCicloAnteriorNoRecurrentes(r.Item("CVETRA").ToString)
                        End If
                        dTotHonAnt += HonoAnt

                        HonoAct = r.Item("HONORARIOSPROPUESTA").ToString
                        dTotHonAct += HonoAct
                        dTotHonoPpto += dHonoPpto

                        drRec = dtRecurrentes.NewRow
                        drRec("TIPO") = "S"
                        drRec("PERIODO") = r.Item("PERIODO").ToString
                        drRec("HONORARIOSACTUAL") = Format(HonoAct, sFmtDbl)
                        drRec("HONORARIOSANTERIOR") = Format(HonoAnt, sFmtDbl)
                        drRec("DIFERENCIA") = Format(HonoAct - HonoAnt, sFmtDbl)
                        drRec("MONEDA") = "NO"
                        drRec("SOCIO") = r.Item("SOCIO").ToString
                        drRec("OFICINA") = r.Item("OFICINA").ToString
                        drRec("DIVISION") = r.Item("DIVISION").ToString
                        drRec("CVETRABAJO") = r.Item("CVETRA").ToString
                        drRec("EMPRESA") = r.Item("EMPRESA").ToString
                        drRec("DESCRIPCION") = r.Item("DESCRIPCION").ToString
                        drRec("SERVICIO") = r.Item("SERVICIO").ToString
                        drRec("TIPOPROP") = IIf(r.Item("TIPOPROPUESTA").ToString = "P", "PRESUPUESTO", "NVO. RECURRENTE")
                        drRec("HONORARIOSPPTO") = Format(dHonoPpto, sFmtDbl)
                        drRec("HONORARIOSARREGLADOMN") = Format(HonoAct, sFmtDbl)
                        drRec("HONORARIOSANTERIORMN") = Format(HonoAnt, sFmtDbl)
                        drRec("DIFERENCIAMN") = Format(HonoAct - HonoAnt, sFmtDbl)
                        dtRecurrentes.Rows.InsertAt(drRec, dtRecurrentes.Rows.Count)
                    Next
                End With
            Next

            drRec = dtRecurrentes.NewRow
            drRec("TIPO") = "T"
            drRec("PERIODO") = ""
            drRec("HONORARIOSACTUAL") = Format(dTotHonAct, sFmtDbl)
            drRec("HONORARIOSANTERIOR") = Format(dTotHonAnt, sFmtDbl)
            drRec("DIFERENCIA") = Format(dTotHonAct - dTotHonAnt, sFmtDbl)
            drRec("MONEDA") = ""
            drRec("SOCIO") = ""
            drRec("OFICINA") = ""
            drRec("DIVISION") = ""
            drRec("CVETRABAJO") = ""
            drRec("EMPRESA") = "TOTAL:"
            drRec("DESCRIPCION") = ""
            drRec("SERVICIO") = ""
            drRec("TIPOPROP") = ""
            drRec("HONORARIOSPPTO") = Format(dTotHonoPpto, sFmtDbl)
            drRec("HONORARIOSARREGLADOMN") = Format(dTotHonAct, sFmtDbl)
            drRec("HONORARIOSANTERIORMN") = Format(dTotHonAnt, sFmtDbl)
            drRec("DIFERENCIAMN") = Format(dTotHonAct - dTotHonAnt, sFmtDbl)
            dtRecurrentes.Rows.InsertAt(drRec, dtRecurrentes.Rows.Count)

            bsRec.DataSource = dtRecurrentes
            formatoRecurrentes()
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarPropuestasRecurrentes()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtRechazadas = Nothing
        End Try
    End Sub
    Private Sub ListarHonorariosRecurrentes(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim sTabla As String = "tbHonRecurrentes"

            LimpiarTabla(dtHonRec)

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 17, SqlDbType.Int, ParameterDirection.Input)

                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If

                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)

                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtHonRecDatos = .Item(sTabla)

                    For Each r As DataRow In dtHonRecDatos.Rows
                        drHonRec = dtHonRec.NewRow
                        drHonRec("CVETRA") = r.Item("CVETRA").ToString
                        drHonRec("CVEPPTO") = r.Item("CVEPPTO").ToString
                        drHonRec("HONORARIOS") = r.Item("HONORARIOSPROPUESTA").ToString
                        drHonRec("OFICINA") = r.Item("CVEOFI").ToString
                        drHonRec("DIVISION") = r.Item("CVEAREA").ToString
                        drHonRec("TIPOPROP") = r.Item("TIPOPROPUESTA").ToString
                        dtHonRec.Rows.InsertAt(drHonRec, dtHonRec.Rows.Count)
                    Next
                End With
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosRecurrentes")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtHonRecDatos = Nothing
        End Try
    End Sub

#End Region
#Region "PROPUESTAS POR RESOLVER"

    Private Sub listarPropuestasPorResolver(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim HonoAct As Decimal = 0.0
            Dim HonoAnt As Decimal = 0.0
            Dim dTotHon As Double
            Dim sTabla As String = "tbPorResolver"

            LimpiarTabla(dtPendientes)
            dTotHon = 0

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If
                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)
                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtPendientesDatos = .Item(sTabla)

                    For Each r As DataRow In dtPendientesDatos.Rows
                        HonoAct = CDbl(r.Item("HONORARIOSPROPUESTA").ToString)
                        HonoAnt = 0
                        dTotHon += HonoAct

                        drPen = dtPendientes.NewRow
                        drPen("TIPO") = "S"
                        drPen("PERIODO") = r.Item("PERIODO").ToString
                        drPen("OFICINA") = r.Item("OFICINA").ToString
                        drPen("DIVISION") = r.Item("DIVISION").ToString
                        drPen("CICLO") = r.Item("CICLO").ToString
                        drPen("EMPRESA") = r.Item("EMPRESA").ToString
                        drPen("SERVICIO") = r.Item("SERVICIO").ToString
                        drPen("HONORARIOSACTUAL") = Format(CDbl(HonoAct), "$ " & sFmtDbl)
                        drPen("MONEDA") = r.Item("POMONEDA").ToString
                        drPen("HONORARIOSARREGLADOMN") = Format(CDbl(HonoAct), "$ " & sFmtDbl)
                        drPen("SOCIO") = r.Item("NOMSOC").ToString
                        drPen("FECHAPROPUESTA") = r.Item("FECHAPROPUESTA").ToString

                        drPen("HONETOS") = r.Item("HONETOS").ToString
                        drPen("HORCOTIZADAS") = r.Item("HORCOTIZADAS").ToString
                        drPen("CUOTA") = r.Item("CUOTA").ToString
                        drPen("WOFF") = r.Item("WOFF").ToString
                        drPen("INDUSTRIA") = r.Item("INDUSTRIA").ToString
                        drPen("SUBSECTOR") = r.Item("SUBSECTOR").ToString

                        drPen("COMO") = r.Item("COMO").ToString
                        drPen("MEDIO") = r.Item("MEDIO").ToString

                        drPen("REFGTSOCIO") = r.Item("REFGTSOCIO").ToString
                        drPen("REFGTOFI") = r.Item("REFGTOFI").ToString
                        drPen("REFGTPAIS") = r.Item("REFGTPAIS").ToString

                        drPen("PUESTO") = r.Item("PUESTO").ToString
                        drPen("REFNOMB") = r.Item("REFNOMB").ToString
                        drPen("REFOFI") = r.Item("REFOFI").ToString
                        drPen("REFDIV") = r.Item("REFDIV").ToString

                        dtPendientes.Rows.InsertAt(drPen, dtPendientes.Rows.Count)
                    Next
                End With
            Next
            drPen = dtPendientes.NewRow
            drPen("TIPO") = "T"
            drPen("PERIODO") = ""
            drPen("OFICINA") = ""
            drPen("DIVISION") = ""
            drPen("EMPRESA") = "TOTAL:"
            drPen("SERVICIO") = ""
            drPen("HONORARIOSACTUAL") = Format(CDbl(dTotHon), "$ " & sFmtDbl)
            drPen("MONEDA") = ""
            drPen("HONORARIOSARREGLADOMN") = Format(CDbl(dTotHon), "$ " & sFmtDbl)
            drPen("SOCIO") = ""
            drPen("FECHAPROPUESTA") = ""
            drPen("HONETOS") = ""
            drPen("HORCOTIZADAS") = ""
            drPen("CUOTA") = ""
            drPen("WOFF") = ""
            drPen("INDUSTRIA") = ""
            drPen("SUBSECTOR") = ""
            drPen("REFGTSOCIO") = ""
            drPen("REFGTOFI") = ""
            drPen("REFGTPAIS") = ""
            drPen("PUESTO") = ""
            drPen("REFNOMB") = ""
            drPen("REFOFI") = ""
            drPen("REFDIV") = ""
            drPen("COMO") = ""
            drPen("MEDIO") = ""
            dtPendientes.Rows.InsertAt(drPen, dtPendientes.Rows.Count)

            bsPen.DataSource = dtPendientes
            formatoGridPorResolver()
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "listarPropuestasPorResolver")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
        End Try
    End Sub
    Private Sub ListarHonorariosPorResolver(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim sTabla As String = "tbHonPropPen"

            LimpiarTabla(dtHonResolver)

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 11, SqlDbType.Int, ParameterDirection.Input)

                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If

                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)
                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtHonResolverdatos = .Item(sTabla)

                    For Each r As DataRow In dtHonResolverdatos.Rows
                        drHonResolver = dtHonResolver.NewRow
                        drHonResolver("HONORARIOS") = r.Item("HONORARIOSPROPUESTA").ToString
                        drHonResolver("OFICINA") = r.Item("CVEOFI").ToString
                        drHonResolver("DIVISION") = r.Item("CVEAREA").ToString
                        dtHonResolver.Rows.InsertAt(drHonResolver, dtHonResolver.Rows.Count)
                    Next
                End With
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosPorResolver")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtHonResolverdatos = Nothing
        End Try
    End Sub

#End Region
#Region "PROPUESTAS RECHAZADAS"

    Private Sub listarPropuestasRechazadas(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim dTotHon As Double
            Dim sTabla As String = "tbRechazadas"

            LimpiarTabla(dtRechazadas)
            dTotHon = 0

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)

                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If
                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)


                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtRechazadasDatos = .Item(sTabla)

                    For Each r As DataRow In dtRechazadasDatos.Rows

                        drRecha = dtRechazadas.NewRow
                        drRecha("TIPO") = "S"
                        drRecha("PERIODO") = r.Item("PERIODO").ToString
                        drRecha("OFICINA") = r.Item("OFICINA").ToString
                        drRecha("DIVISION") = r.Item("DIVISION").ToString
                        drRecha("CICLO") = r.Item("CICLO").ToString
                        drRecha("EMPRESA") = r.Item("EMPRESA").ToString
                        drRecha("SERVICIO") = r.Item("SERVICIO").ToString
                        Dim HonoAct As Decimal = 0.0
                        Dim HonoAnt As Decimal = 0.0
                        HonoAct = r.Item("HONORARIOSPROPUESTA").ToString
                        HonoAnt = 0
                        dTotHon += HonoAct

                        drRecha("HONORARIOSACTUAL") = Format(CDbl(HonoAct), "$ " & sFmtDbl)
                        drRecha("MONEDA") = "PESOS"
                        drRecha("HONORARIOSARREGLADOMN") = Format(CDbl(HonoAct), "$ " & sFmtDbl)
                        drRecha("SOCIO") = r.Item("NOMSOC").ToString
                        drRecha("DESCRECHAZO") = r.Item("DESCRECHAZO").ToString

                        drRecha("HONETOS") = r.Item("HONETOS").ToString
                        drRecha("HORCOTIZADAS") = r.Item("HORCOTIZADAS").ToString
                        drRecha("CUOTA") = r.Item("CUOTA").ToString
                        drRecha("WOFF") = r.Item("WOFF").ToString
                        drRecha("INDUSTRIA") = r.Item("INDUSTRIA").ToString
                        drRecha("SUBSECTOR") = r.Item("SUBSECTOR").ToString

                        drRecha("COMO") = r.Item("COMO").ToString
                        drRecha("MEDIO") = r.Item("MEDIO").ToString

                        drRecha("REFGTSOCIO") = r.Item("REFGTSOCIO").ToString
                        drRecha("REFGTOFI") = r.Item("REFGTOFI").ToString
                        drRecha("REFGTPAIS") = r.Item("REFGTPAIS").ToString

                        drRecha("PUESTO") = r.Item("PUESTO").ToString
                        drRecha("REFNOMB") = r.Item("REFNOMB").ToString
                        drRecha("REFOFI") = r.Item("REFOFI").ToString
                        drRecha("REFDIV") = r.Item("REFDIV").ToString

                        dtRechazadas.Rows.InsertAt(drRecha, dtRechazadas.Rows.Count)

                    Next

                End With
            Next

            ' End If

            drRecha = dtRechazadas.NewRow
            drRecha("TIPO") = "T"
            drRecha("PERIODO") = ""
            drRecha("OFICINA") = ""
            drRecha("DIVISION") = ""
            drRecha("EMPRESA") = "TOTAL:"
            drRecha("SERVICIO") = ""
            drRecha("HONORARIOSACTUAL") = ""
            drRecha("MONEDA") = ""
            drRecha("HONORARIOSARREGLADOMN") = Format(dTotHon, "$ " & sFmtDbl)
            drRecha("SOCIO") = ""
            drRecha("DESCRECHAZO") = ""
            drRecha("HONETOS") = ""
            drRecha("HORCOTIZADAS") = ""
            drRecha("CUOTA") = ""
            drRecha("WOFF") = ""
            drRecha("INDUSTRIA") = ""
            drRecha("SUBSECTOR") = ""
            drRecha("REFGTSOCIO") = ""
            drRecha("REFGTOFI") = ""
            drRecha("REFGTPAIS") = ""
            drRecha("PUESTO") = ""
            drRecha("REFNOMB") = ""
            drRecha("REFOFI") = ""
            drRecha("REFDIV") = ""
            drRecha("COMO") = ""
            drRecha("MEDIO") = ""
            dtRechazadas.Rows.InsertAt(drRecha, dtRechazadas.Rows.Count)

            bsRch.DataSource = dtRechazadas
            formatoGridRechazado()


        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "listarPropuestasRechazadas()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtRechazadas = Nothing
        End Try
    End Sub
    Private Sub ListarHonorariosPropRechazadas(ByVal dtPermisos As DataTable, ByVal Bandera As Boolean)
        Try
            Dim sTabla As String = "tbHonPropRec"

            LimpiarTabla(dtHonRech)

            For Each Dr As DataRow In dtPermisos.Rows
                With ds.Tables
                    If .Contains(sTabla) Then
                        .Remove(sTabla)
                    End If

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 10, SqlDbType.Int, ParameterDirection.Input)

                        If Bandera Then
                            .subAddParameter("@sCveSocio", Dr("CVEEMP").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        End If

                        .subAddParameter("@sCveOfi", Dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", Dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@cTpoUsr", sTipoUsuario, SqlDbType.Char, ParameterDirection.Input, 1)
                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))
                    dtRechazadasDatos = .Item(sTabla)

                    For Each r As DataRow In dtRechazadasDatos.Rows
                        drHonRech = dtHonRech.NewRow
                        drHonRech("HONORARIOS") = r.Item("HONORARIOSPROPUESTA").ToString
                        drHonRech("OFICINA") = r.Item("CVEOFI").ToString
                        drHonRech("DIVISION") = r.Item("CVEAREA").ToString
                        dtHonRech.Rows.InsertAt(drHonRech, dtHonRech.Rows.Count)
                    Next
                End With
            Next
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, Usuario_Num, "ListarHonorariosPropRechazadas()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SAPYC")
            dtRechazadasDatos = Nothing
        End Try
    End Sub

#End Region

#End Region

#Region "FUNCIONES"

    Private Function nomOfi(ByVal sCve As String) As String
        Dim sOfi As String = ""

        Select Case sCve
            Case "MEX"
                sOfi = "Ciudad de México"
            Case "GDL"
                sOfi = "Guadalajara"
            Case "MTY"
                sOfi = "Monterrey"
            Case "CJ"
                sOfi = "Ciudad Juárez"
            Case "QRO"
                sOfi = "Querétaro"
            Case "VALL"
                sOfi = "Puerto Vallarta"
            Case "AGS"
                sOfi = "Aguascalientes"
            Case "TIJ"
                sOfi = "Tijuana"
            Case "PUE"
                sOfi = "Puebla"
            Case "PLD"
                sOfi = "P.L.D."
            Case "PTN"
                sOfi = "P.T.N."
        End Select

        Return sOfi
    End Function
    Private Function nomDiv(ByVal sCve As String) As String
        Dim sDiv As String = ""

        Select Case sCve
            Case "AUD"
                sDiv = "Aud."
            Case "IMP"
                sDiv = "Imp."
            Case "PT"
                sDiv = "P.T."
            Case "CEX"
                sDiv = "Com. Ext."
            Case "CE"
                sDiv = "BPS"
            Case "AUI"
                sDiv = "BAS"
            Case "PLD"
                sDiv = "P.L.D."
        End Select

        Return sDiv
    End Function
    Private Function ObtenerHonorariosNoRecurrentes(ByVal Cveofi As String, ByVal CveArea As String)

        Dim Hon As Double = 0.0
        Dim Dr() As DataRow
        Dr = dtHonNoRec.Select("OFICINA = '" & Cveofi & "' AND DIVISION = '" & CveArea & "'")

        For d As Integer = 0 To Dr.Count - 1
            Hon += CDbl(Dr(d).Item("HONORARIOS").ToString)
        Next
        Return Hon
    End Function
    Private Function ObtenerHonorariosPerdidos(ByVal Cveofi As String, ByVal CveArea As String)

        Dim Hon As Double = 0.0
        Dim Dr() As DataRow
        Dr = dtHonPer.Select("OFICINA = '" & Cveofi & "' AND DIVISION = '" & CveArea & "'")

        For d As Integer = 0 To Dr.Count - 1
            Hon += CDbl(Dr(d).Item("HONORARIOS").ToString)
        Next
        Return Hon

    End Function
    Private Function ObtenerHonorariosRecurrentesNoArreglados(ByVal Cveofi As String, ByVal CveArea As String)

        Dim Hon As Double = 0.0
        Dim Dr() As DataRow
        Dr = dtHonRecNoArr.Select("OFICINA = '" & Cveofi & "' AND DIVISION = '" & CveArea & "'")

        For d As Integer = 0 To Dr.Count - 1
            Hon += CDbl(Dr(d).Item("HONORARIOS").ToString)
        Next
        Return Hon
    End Function
    Private Function ObtenerHonorariosDiferenciaPptoReal(ByVal Cveofi As String, ByVal CveArea As String)

        Dim HonPpto As Double = 0.0
        Dim HonFac As Double = 0.0


        Dim Dr() As DataRow

        If Cveofi = "MEX" And (CveArea = "AUD" Or CveArea = "CO" Or CveArea = "SS" Or CveArea = "ATI") Then
            Dr = dtDiferenciaPpto.Select("OFICINA = '" & Cveofi & "' AND (DIVISION = 'AUD' OR DIVISION = 'CO' OR DIVISION = 'SS' OR DIVISION = 'ATI')")
        Else
            Dr = dtDiferenciaPpto.Select("OFICINA = '" & Cveofi & "' AND DIVISION = '" & CveArea & "'")
        End If


        'Dr = dtDiferenciaPpto.Select("SOCIO = '" & sCveUsuario & "'")

        For d As Integer = 0 To Dr.Count - 1
            HonPpto += CDbl(Dr(d).Item("HONORARIOSPPTO").ToString)
            HonFac += CDbl(Dr(d).Item("HONORARIOSFAC").ToString)
        Next

        'Return IIf((HonPpto - HonFac) >= 0, 0, (HonPpto - HonFac))
        Return (HonPpto - HonFac)

    End Function
    Private Function ObtenerHonorariosTransferenciasSocios(ByVal Cveofi As String, ByVal CveArea As String) As Double
        Dim HonFac As Double = 0.0
        Dim Dr() As DataRow
        Try
            Dr = dtTransfSoc.Select("OFICINA = '" & Cveofi & "' AND DIVISION = '" & CveArea & "'")

            For d As Integer = 0 To Dr.Count - 1
                HonFac += CDbl(Dr(d).Item("HONORARIOSFAC").ToString)
            Next
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerHonorariosTransferenciasSocios()")
        End Try

        Return HonFac
    End Function
    Private Function ObtenerHonorariosNuevas(ByVal Cveofi As String, ByVal CveArea As String)

        Dim Hon As Double = 0.0
        Dim Dr() As DataRow
        Dr = dtHonNuevas.Select("OFICINA = '" & Cveofi & "' AND DIVISION = '" & CveArea & "'")

        For d As Integer = 0 To Dr.Count - 1
            Hon += CDbl(Dr(d).Item("HONORARIOS").ToString)
        Next
        Return Hon

    End Function
    Private Function ObtenerHonorariosRecurrentes(ByVal Cveofi As String, ByVal CveArea As String) As Double
        Dim Hon, dHonAnt As Double
        Dim Dr() As DataRow

        Dr = dtHonRec.Select("OFICINA = '" & Cveofi & "' AND DIVISION = '" & CveArea & "'")

        For d As Integer = 0 To Dr.Count - 1
            If Dr(d).Item("TIPOPROP").ToString = "P" Then
                dHonAnt += ObtenerHonorariosCicloAnterior(Dr(d).Item("CVEPPTO").ToString, 1)
                dHonAnt += ObtenerHonorariosCicloAnteriorNoRecurrentesPpto(Dr(d).Item("CVETRA").ToString)
            Else
                dHonAnt += ObtenerHonorariosCicloAnteriorNoRecurrentes(Dr(d).Item("CVETRA").ToString)
            End If
            Hon += CDbl(Dr(d).Item("HONORARIOS").ToString)
        Next

        Return (Hon - dHonAnt)
    End Function
    Private Function ObtenerHonorariosPorResolver(ByVal Cveofi As String, ByVal CveArea As String)

        Dim Hon As Double = 0.0
        Dim Dr() As DataRow
        Dr = dtHonResolver.Select("OFICINA = '" & Cveofi & "' AND DIVISION = '" & CveArea & "'")

        For d As Integer = 0 To Dr.Count - 1
            Hon += CDbl(Dr(d).Item("HONORARIOS").ToString)
        Next
        Return Hon

    End Function
    Private Function ObtenerHonorariosRechazadas(ByVal Cveofi As String, ByVal CveArea As String)

        Dim Hon As Double = 0.0
        Dim Dr() As DataRow
        Dr = dtHonRech.Select("OFICINA = '" & Cveofi & "' AND DIVISION = '" & CveArea & "'")

        For d As Integer = 0 To Dr.Count - 1
            Hon += CDbl(Dr(d).Item("HONORARIOS").ToString)
        Next
        Return Hon

    End Function
    Private Function ObtenerHonorariosTotalProp(ByVal Cveofi As String, ByVal CveArea As String)

        Dim Hon As Double = 0.0
        Dim Dr() As DataRow
        Dr = dtHonTotPro.Select("OFICINA = '" & Cveofi & "' AND DIVISION = '" & CveArea & "'")

        For d As Integer = 0 To Dr.Count - 1
            Hon += CDbl(Dr(d).Item("HONORARIOS").ToString)
        Next
        Return Hon

    End Function
    Private Function ObtenerHonorariosPresupuesto(ByVal Cveofi As String, ByVal CveArea As String, Optional ByVal sCveSocio As String = "") As Double
        Dim Hon As Double = 0
        Dim Dr() As DataRow

        Try
            If sCveSocio = "" Then
                Dr = dtPpto.Select("sCveOfi = '" & Cveofi & "' AND sCveArea = '" & CveArea & "'")
            Else
                Dr = dtPpto.Select("sCveSocio = '" & sCveSocio & "' AND sCveOfi = '" & Cveofi & "' AND sCveArea = '" & CveArea & "'")
            End If

            For d As Integer = 0 To Dr.Count - 1
                Hon += CDbl(Dr(d).Item("dHonorarios").ToString)
            Next
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerHonorariosPresupuesto()")
        End Try

        Return Hon
    End Function
    Private Function ObtenerHonorariosAnterior(ByVal Cveofi As String, ByVal CveArea As String) As Double
        Dim Hon As Double = 0
        Dim Dr() As DataRow

        Try
            Dr = dtIngresosAnt.Select("sCveOfi = '" & Cveofi & "' AND sCveArea = '" & CveArea & "'")

            For d As Integer = 0 To Dr.Count - 1
                Hon += CDbl(Dr(d).Item("dHonorarios").ToString)
            Next
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerHonorariosPresupuesto()")
        End Try

        Return Hon
    End Function
    Private Function ObtenerHonorariosCicloAnterior(ByVal sCveTra As String, ByVal iTipo As Integer, Optional ByVal sCveSoc As String = "") As Double
        Dim Hon As Double = 0
        Dim Dr() As DataRow

        Try
            If iTipo = 1 Then
                Dr = dtHonCicloAnt.Select("sCveTra = '" & sCveTra & "' ")
            Else
                Dr = dtHonCicloAnt.Select("sCveTra = '" & sCveTra & "' AND sCveSocio = '" & sCveSoc & "'")
            End If

            For d As Integer = 0 To Dr.Count - 1
                Hon += CDbl(Dr(d).Item("dImporte").ToString)
            Next
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveSoc, "ObtenerHonorariosCicloAnterior()")
        End Try

        Return Hon
    End Function
    Private Function ObtenerHonorariosCicloAnteriorNoRecurrentes(ByVal sCveTra As String) As Double
        Dim Hon As Double = 0
        Dim Dr() As DataRow

        Try
            'If iTipo = 1 Then
            Dr = dtHonCicloAntNoRec.Select("sCveTraNvaRec = '" & sCveTra & "' ")
            'Else
            '    Dr = dtHonCicloAntNoRec.Select("sCveTra = '" & sCveTra & "' AND sCveSocio = '" & sCveSoc & "'")
            'End If

            For d As Integer = 0 To Dr.Count - 1
                Hon += CDbl(Dr(d).Item("dImporte").ToString)
            Next
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerHonorariosCicloAnterior()")
        End Try

        Return Hon
    End Function
    Private Function ObtenerHonorariosCicloAnteriorNoRecurrentesPpto(ByVal sCveTra As String) As Double
        Dim Hon As Double = 0
        Dim Dr() As DataRow

        Try
            Dr = dtHonCicloAntNoRecPpto.Select("sCveTraNvaRec = '" & sCveTra & "' ")

            For d As Integer = 0 To Dr.Count - 1
                Hon += CDbl(Dr(d).Item("dImporte").ToString)
            Next
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerHonorariosCicloAnterior()")
        End Try

        Return Hon
    End Function
    Private Function ObtenerHonorariosCicloAnteriorSocio(ByVal sCveSocio As String, ByVal sCveOfi As String, ByVal sCveArea As String) As Double
        Dim Hon As Double = 0
        Dim Dr() As DataRow

        Try
            Dr = dtIngresosSocAnt.Select("sCveSocio = '" & sCveSocio & "' AND sCveOfi = '" & sCveOfi & "' AND sCveArea = '" & sCveArea & "'")

            For d As Integer = 0 To Dr.Count - 1
                Hon += CDbl(Dr(d).Item("dImporte").ToString)
            Next
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerHonorariosCicloAnteriorSocio()")
        End Try

        Return Hon
    End Function
    Private Function ObtenerHonorariosPptoAsoc(ByVal sCveTra As String) As Double
        Dim Hon As Double = 0
        Dim Dr() As DataRow

        Try
            'If iTipo = 1 Then
            Dr = dtHonPptoAsoc.Select("sCveTraPptoAsoc = '" & sCveTra & "' ")
            'Else
            '    Dr = dtHonCicloAntNoRec.Select("sCveTra = '" & sCveTra & "' AND sCveSocio = '" & sCveSoc & "'")
            'End If

            For d As Integer = 0 To Dr.Count - 1
                Hon += CDbl(Dr(d).Item("dImporte").ToString)
            Next
        Catch ex As Exception
            'insertarErrorLog(202, sNameRpt, ex.Message, sCveUsuario, "ObtenerHonorariosCicloAnterior()")
        End Try

        Return Hon
    End Function

#End Region

End Class