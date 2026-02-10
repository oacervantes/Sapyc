Imports System.IO
Imports System.Text

Public Class FrmReportesGRD

    Private bsEnt, bsServ, bsProv, bsRol As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Reportes GRD"
    Private sStoredProc As String = "paGRDReportes"

    Private dtBases, dtCiclos, dtReportes, dtEnt, dtEntidades, dtServ, dtServicios, dtProv, dtProveedores, dtRolEnt, dtRolesEntidad As New DataTable
    Private drEnt, drServ, drProv, drRol, drCiclos As DataRow
    Private idCiclo As Integer

    Private Sub FrmReportesGRD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridClientes.DataSource = bsEnt
        DesplazamientoGrid(gridClientes)

        gridServicios.DataSource = bsServ
        DesplazamientoGrid(gridServicios)

        gridProveedores.DataSource = bsProv
        DesplazamientoGrid(gridProveedores)

        gridRolesEntidad.DataSource = bsRol
        DesplazamientoGrid(gridRolesEntidad)

        CrearTablas()
        ListarCiclos()

        idCiclo = iPeriodoFirma

        ListarReportes()
        ListarCampos()
    End Sub
    Private Sub BtnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        ListarEntidades()
        ListarServicios()
        ListarProveedores()
        ListarRolesEntidad()
    End Sub
    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim dlg As New dlgExcel

        Try
            If MsgBox("¿Desea exportar la información a Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Envío Excel") = MsgBoxResult.Yes Then
                dlg.txtArchivo.Focus()
                dlg.txtArchivo.Text = "Reportes GRD"
                If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

                    'Clientes.
                    CrearCsv(gridClientes, dlg.txtDirectorio.Text, "Entity information " & Now.Day & "-" & Now.Month & "-" & Now.Year & " GT Mexico.csv")

                    'Servicios.
                    CrearCsv(gridServicios, dlg.txtDirectorio.Text, "Client relationship " & Now.Day & "-" & Now.Month & "-" & Now.Year & " GT Mexico.csv")

                    'Proveedores.
                    CrearCsv(gridProveedores, dlg.txtDirectorio.Text, "Business relationship " & Now.Day & "-" & Now.Month & "-" & Now.Year & " GT Mexico.csv")

                    'Roles en la Entidad.
                    CrearCsv(gridRolesEntidad, dlg.txtDirectorio.Text, "Personnel relationship " & Now.Day & "-" & Now.Month & "-" & Now.Year & " GT Mexico.csv")
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub CboCiclo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCiclo.SelectionChangeCommitted
        idCiclo = CInt(cboCiclo.SelectedValue)
    End Sub

    Private Sub CrearTablas()
        dtCiclos.Columns.Add("idCiclo", GetType(String))
        dtCiclos.Columns.Add("sCiclo", GetType(String))
    End Sub
    Private Sub FormatoGrid(id As Integer, grid As DataGridView)
        Dim dr() As DataRow

        dr = dtReportes.Select("IDREP = " & id)

        grid.Columns("TIPO").Visible = False

        For Each d As DataRow In dr
            ConfigurarColumnasGrid(grid, d("REP_COL").ToString(), d("REP_COL").ToString(), 150, 1, False)
        Next

    End Sub

    Private Sub ListarCiclos()
        Try
            Dim sTabla As String = "tbCiclos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosConINV
                    .subClearParameters()
                End With

                .Add(clsDatosConINV.funExecuteSPDataTable("paBasesDatos", sTabla))
                dtBases = .Item(sTabla)
            End With

            For Each dr As DataRow In dtBases.Rows
                If dr.Item("idBaseDatos") >= 8 Then
                    drCiclos = dtCiclos.NewRow
                    drCiclos("idCiclo") = dr.Item("idBaseDatos")
                    drCiclos("sCiclo") = dr.Item("sPeriodo")
                    dtCiclos.Rows.InsertAt(drCiclos, dtCiclos.Rows.Count)
                End If
            Next

            cboCiclo.DataSource = dtCiclos
            cboCiclo.ValueMember = "idCiclo"
            cboCiclo.DisplayMember = "sCiclo"
        Catch ex As Exception
            MsgBox("Por el momento no es posible acceder a la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtBases = Nothing
        End Try
    End Sub

    Private Sub ListarReportes()
        Try
            Dim sTabla As String = "tbReportes"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable(sStoredProc, sTabla))
                dtReportes = .Item(sTabla)
            End With
        Catch ex As Exception
            MsgBox("Por el momento no es posible acceder a la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtReportes = Nothing
        End Try
    End Sub
    Private Sub ListarCampos()
        Dim dr() As DataRow

        'Crear tabla de entidades.
        dr = dtReportes.Select("IDREP = 1")

        If dr.Count > 0 Then
            dtEntidades.Columns.Add("TIPO", GetType(String))

            For Each d As DataRow In dr
                dtEntidades.Columns.Add(d("REP_COL").ToString(), GetType(String))
            Next
        End If

        'Crear tabla de Servicios.
        dr = dtReportes.Select("IDREP = 2")

        If dr.Count > 0 Then
            dtServicios.Columns.Add("TIPO", GetType(String))

            For Each d As DataRow In dr
                dtServicios.Columns.Add(d("REP_COL").ToString(), GetType(String))
            Next
        End If

        'Crear tabla de Proveedores.
        dr = dtReportes.Select("IDREP = 3")

        If dr.Count > 0 Then
            dtProveedores.Columns.Add("TIPO", GetType(String))

            For Each d As DataRow In dr
                dtProveedores.Columns.Add(d("REP_COL").ToString(), GetType(String))
            Next
        End If

        'Crear tabla de Roles de Entidad.
        dr = dtReportes.Select("IDREP = 4")

        If dr.Count > 0 Then
            dtRolesEntidad.Columns.Add("TIPO", GetType(String))

            For Each d As DataRow In dr
                dtRolesEntidad.Columns.Add(d("REP_COL").ToString(), GetType(String))
            Next
        End If
    End Sub

    Private Sub ListarEntidades()
        Try
            Dim drRep() As DataRow
            Dim sTabla As String = "tbEntidades"

            LimpiarTabla(dtEntidades)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPeriodo", idCiclo, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable(sStoredProc, sTabla))
                dtEnt = .Item(sTabla)

                If dtEnt.Rows.Count > 0 Then

                    For Each dr As DataRow In dtEnt.Rows
                        drEnt = dtEntidades.NewRow
                        drEnt("TIPO") = "S"

                        drRep = dtReportes.Select("IDREP = 1")
                        For Each d As DataRow In drRep
                            drEnt(d("REP_COL").ToString()) = ReemplazarCaracter(dr(d("REP_COL").ToString()).ToString())
                        Next

                        dtEntidades.Rows.InsertAt(drEnt, dtEntidades.Rows.Count)
                    Next

                    bsEnt.DataSource = dtEntidades
                    FormatoGrid(1, gridClientes)
                End If
            End With
        Catch ex As Exception
            MsgBox("Por el momento no es posible mostrar el reporte, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtEnt = Nothing
        End Try
    End Sub
    Private Sub ListarServicios()
        Try
            Dim drRep() As DataRow
            Dim sTabla As String = "tbServicios"

            LimpiarTabla(dtServicios)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPeriodo", idCiclo, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable(sStoredProc, sTabla))
                dtServ = .Item(sTabla)

                If dtServ.Rows.Count > 0 Then

                    For Each dr As DataRow In dtServ.Rows
                        drServ = dtServicios.NewRow
                        drServ("TIPO") = "S"

                        drRep = dtReportes.Select("IDREP = 2")
                        For Each d As DataRow In drRep
                            drServ(d("REP_COL").ToString()) = ReemplazarCaracter(dr(d("REP_COL").ToString()).ToString())
                        Next

                        dtServicios.Rows.InsertAt(drServ, dtServicios.Rows.Count)
                    Next

                    bsServ.DataSource = dtServicios
                    FormatoGrid(2, gridServicios)
                End If
            End With
        Catch ex As Exception
            MsgBox("Por el momento no es posible mostrar el reporte, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtServ = Nothing
        End Try
    End Sub
    Private Sub ListarProveedores()
        Try
            Dim drRep() As DataRow
            Dim sTabla As String = "tbProveedores"

            LimpiarTabla(dtProveedores)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable(sStoredProc, sTabla))
                dtProv = .Item(sTabla)

                If dtProv.Rows.Count > 0 Then

                    For Each dr As DataRow In dtProv.Rows
                        drProv = dtProveedores.NewRow
                        drProv("TIPO") = "S"

                        drRep = dtReportes.Select("IDREP = 3")
                        For Each d As DataRow In drRep
                            drProv(d("REP_COL").ToString()) = ReemplazarCaracter(dr(d("REP_COL").ToString()).ToString())
                        Next

                        dtProveedores.Rows.InsertAt(drProv, dtProveedores.Rows.Count)
                    Next

                    bsProv.DataSource = dtProveedores
                    FormatoGrid(3, gridProveedores)
                End If
            End With
        Catch ex As Exception
            MsgBox("Por el momento no es posible mostrar el reporte, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtProv = Nothing
        End Try
    End Sub
    Private Sub ListarRolesEntidad()
        Try
            Dim drRep() As DataRow
            Dim sTabla As String = "tbRolEntidad"

            LimpiarTabla(dtRolesEntidad)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable(sStoredProc, sTabla))
                dtRolEnt = .Item(sTabla)

                If dtRolEnt.Rows.Count > 0 Then

                    For Each dr As DataRow In dtRolEnt.Rows
                        drRol = dtRolesEntidad.NewRow
                        drRol("TIPO") = "S"

                        drRep = dtReportes.Select("IDREP = 4")
                        For Each d As DataRow In drRep
                            drRol(d("REP_COL").ToString()) = ReemplazarCaracter(dr(d("REP_COL").ToString()).ToString())
                        Next

                        dtRolesEntidad.Rows.InsertAt(drRol, dtRolesEntidad.Rows.Count)
                    Next

                    bsRol.DataSource = dtRolesEntidad
                    FormatoGrid(4, gridRolesEntidad)
                End If
            End With
        Catch ex As Exception
            MsgBox("Por el momento no es posible mostrar el reporte, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtRolEnt = Nothing
        End Try
    End Sub

    Private Sub CrearCsv(grid As DataGridView, sRuta As String, sArchivo As String)
        Using sw As New StreamWriter(Path.Combine(sRuta, sArchivo), False, Encoding.UTF8)
            ' Escribir encabezados
            Dim headerCols As New List(Of String)
            For Each col As DataGridViewColumn In grid.Columns
                If col.Visible Then
                    headerCols.Add(col.HeaderText)
                End If
            Next
            sw.WriteLine(String.Join(",", headerCols))

            ' Escribir filas
            For Each row As DataGridViewRow In grid.Rows
                If Not row.IsNewRow Then
                    Dim cellValues As New List(Of String)
                    For Each cell As DataGridViewCell In row.Cells
                        If cell.Visible Then
                            If cell.Value Is Nothing OrElse String.IsNullOrEmpty(cell.Value.ToString()) Then
                                cellValues.Add("""""")
                            Else
                                Dim valor As String = cell.Value.ToString()

                                ' Verificar si es fecha
                                If IsDate(valor) Then
                                    ' Insertar carácter invisible entre los guiones
                                    valor = valor.Replace(ChrW(&H200C) & "-", "-")
                                End If

                                ' Envolver en comillas dobles
                                cellValues.Add("""" & valor & """")
                            End If
                        End If
                    Next
                    sw.WriteLine(String.Join(",", cellValues))
                End If
            Next
        End Using

        MsgBox("Archivo " & sArchivo & " creado exitosamente ", MsgBoxStyle.Information, "SIAT")
    End Sub

End Class