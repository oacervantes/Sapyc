Public Class FrmReportesGRD

    Private bsEnt, bsServ, bsProv, bsRol As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Reportes GRD"
    Private sStoredProc As String = "paGRDReportes"

    Private dtReportes, dtEnt, dtEntidades, dtServ, dtServicios, dtProv, dtProveedores, dtRolEnt, dtRolesEntidad As New DataTable
    Private drEnt, drServ, drProv, drRol As DataRow

    Private Sub FrmReportesGRD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridClientes.DataSource = bsEnt
        DesplazamientoGrid(gridClientes)

        gridServicios.DataSource = bsServ
        DesplazamientoGrid(gridServicios)

        gridProveedores.DataSource = bsProv
        DesplazamientoGrid(gridProveedores)

        gridRolesEntidad.DataSource = bsRol
        DesplazamientoGrid(gridRolesEntidad)

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

    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
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
        dr = dtReportes.Select("IDERP = 1")

        If dr.Count > 0 Then
            dtEntidades.Columns.Add("TIPO", GetType(String))

            For Each d As DataRow In dr
                dtEntidades.Columns.Add(d("REP_COL").ToString(), GetType(String))
            Next
        End If

        'Crear tabla de Servicios.
        dr = dtReportes.Select("IDERP = 2")

        If dr.Count > 0 Then
            dtServicios.Columns.Add("TIPO", GetType(String))

            For Each d As DataRow In dr
                dtServicios.Columns.Add(d("REP_COL").ToString(), GetType(String))
            Next
        End If

        'Crear tabla de Proveedores.
        dr = dtReportes.Select("IDERP = 3")

        If dr.Count > 0 Then
            dtProveedores.Columns.Add("TIPO", GetType(String))

            For Each d As DataRow In dr
                dtProveedores.Columns.Add(d("REP_COL").ToString(), GetType(String))
            Next
        End If

        'Crear tabla de Roles de Entidad.
        dr = dtReportes.Select("IDERP = 4")

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

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable(sStoredProc, sTabla))
                dtEnt = .Item(sTabla)

                If dtEnt.Rows.Count > 0 Then

                    For Each dr As DataRow In dtEnt.Rows
                        drEnt = dtEntidades.NewRow
                        drEnt("TIPO") = "S"

                        drRep = dtReportes.Select("IDERP = 1")
                        For Each d As DataRow In drRep
                            drEnt(d("REP_COL").ToString()) = dr(d("REP_COL").ToString()).ToString()
                        Next

                        dtEntidades.Rows.InsertAt(drEnt, dtEntidades.Rows.Count)
                    Next

                    bsEnt.DataSource = dtEntidades
                    'FormatoGrid()
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

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable(sStoredProc, sTabla))
                dtServ = .Item(sTabla)

                If dtServ.Rows.Count > 0 Then

                    For Each dr As DataRow In dtServ.Rows
                        drServ = dtServicios.NewRow
                        drServ("TIPO") = "S"

                        drRep = dtReportes.Select("IDERP = 1")
                        For Each d As DataRow In drRep
                            drServ(d("REP_COL").ToString()) = dr(d("REP_COL").ToString()).ToString()
                        Next

                        dtServicios.Rows.InsertAt(drServ, dtServicios.Rows.Count)
                    Next

                    bsServ.DataSource = dtServicios
                    'FormatoGrid()
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

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable(sStoredProc, sTabla))
                dtProv = .Item(sTabla)

                If dtProv.Rows.Count > 0 Then

                    For Each dr As DataRow In dtProv.Rows
                        drProv = dtProveedores.NewRow
                        drProv("TIPO") = "S"

                        drRep = dtReportes.Select("IDERP = 1")
                        For Each d As DataRow In drRep
                            drProv(d("REP_COL").ToString()) = dr(d("REP_COL").ToString()).ToString()
                        Next

                        dtProveedores.Rows.InsertAt(drProv, dtProveedores.Rows.Count)
                    Next

                    bsProv.DataSource = dtProveedores
                    'FormatoGrid()
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

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable(sStoredProc, sTabla))
                dtRolEnt = .Item(sTabla)

                If dtRolEnt.Rows.Count > 0 Then

                    For Each dr As DataRow In dtRolEnt.Rows
                        drRol = dtRolesEntidad.NewRow
                        drRol("TIPO") = "S"

                        drRep = dtReportes.Select("IDERP = 1")
                        For Each d As DataRow In drRep
                            drRol(d("REP_COL").ToString()) = dr(d("REP_COL").ToString()).ToString()
                        Next

                        dtRolesEntidad.Rows.InsertAt(drRol, dtRolesEntidad.Rows.Count)
                    Next

                    bsRol.DataSource = dtRolesEntidad
                    'FormatoGrid()
                End If
            End With
        Catch ex As Exception
            MsgBox("Por el momento no es posible mostrar el reporte, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtRolEnt = Nothing
        End Try
    End Sub

End Class