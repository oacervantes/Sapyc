Module mdlMetodos

    Public Sub LimpiarConsultaTabla(dt As DataTableCollection, sTabla As String)
        If dt.Contains(sTabla) Then
            dt.Remove(sTabla)
        End If
    End Sub

    'Public Sub limpiarArreglosDbl(ByVal arr() As Double, ByVal iPos As Integer)
    '    For x As Integer = 0 To iPos
    '        arr(x) = 0
    '    Next
    'End Sub
    'Public Sub limpiarArreglosInt(ByVal arr() As Integer, ByVal iPos As Integer)
    '    For x As Integer = 0 To iPos
    '        arr(x) = 0
    '    Next
    'End Sub
    'Public Sub bloquearColumnas(ByVal grid As DataGridView)
    '    For Each col As DataGridViewColumn In grid.Columns
    '        col.SortMode = DataGridViewColumnSortMode.NotSortable
    '    Next
    'End Sub
    Public Sub LimpiarTabla(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            dt.Clear()
        End If
    End Sub
    Public Sub LimpiarTablaCols(ByVal dt As DataTable)
        If dt.Columns.Count > 0 Then
            dt.Columns.Clear()
        End If
    End Sub
    Public Sub DiseñoGrid(ByVal grid As DataGridView)
        With grid
            .DefaultCellStyle.Font = FuenteCelda
            .DefaultCellStyle.SelectionBackColor = Morado
            .RowTemplate.Height = filGrid
            .ColumnHeadersDefaultCellStyle.Font = FuenteHeader
            .ColumnHeadersHeight = colGrid
        End With
    End Sub
    Public Sub formatoDiseñoGridTotales(grid As DataGridView, iRow As Integer)
        If grid.Rows(iRow).Cells("TIPO").Value = "T" Then
            grid.Rows(iRow).DefaultCellStyle.BackColor = total
            grid.Rows(iRow).DefaultCellStyle.ForeColor = negro
            grid.Rows(iRow).DefaultCellStyle.Font = FuenteFila
        ElseIf grid.Rows(iRow).Cells("TIPO").Value = "TS" Or grid.Rows(iRow).Cells("TIPO").Value = "TD" Or grid.Rows(iRow).Cells("TIPO").Value = "TA" Or grid.Rows(iRow).Cells("TIPO").Value = "TO" Or grid.Rows(iRow).Cells("TIPO").Value.ToString.Contains("TS") Then
            grid.Rows(iRow).DefaultCellStyle.BackColor = totalGrupo
            grid.Rows(iRow).DefaultCellStyle.ForeColor = negro
            grid.Rows(iRow).DefaultCellStyle.Font = FuenteFila
        End If
    End Sub

    Public Sub listarBasesDatos()
        Try
            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, "tbBD")

                With clsDatosConINV
                    .subClearParameters()
                End With

                .Add(clsDatosConINV.funExecuteSPDataTable("paBasesDatos", "tbBD"))

                dtBasesDatos = .Item("tbBD")
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub actualizarFacturacionSocio(ByVal sBaseDatos As String, ByVal iAño As Integer, ByVal iMes As Integer, Optional ByVal iPeriodo As Integer = 0)
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iAño", iAño, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iMes", iMes, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sBaseDatos", sBaseDatos, SqlDbType.VarChar, ParameterDirection.Input, 200)
                .subAddParameter("@iPeriodo", iPeriodo, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paActualizarRSNFacturacionSocio")
            End With
        Catch ex As Exception
            'insertarErrorLog(101, "Actualizar Facturación Socio", ex.Message, Usuario_Num, "actualizarFacturacionSocio()")
        End Try
    End Sub
    Public Sub actualizarRSNMovtosFactura(ByVal sBaseDatos As String, ByVal iAño As Integer, ByVal iMes As Integer, Optional ByVal iPeriodo As Integer = 0)
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iAño", iAño, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iMes", iMes, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sBaseDatos", sBaseDatos, SqlDbType.VarChar, ParameterDirection.Input, 200)
                .subAddParameter("@iPeriodo", iPeriodo, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paActualizarRSNMovtosFactura")
            End With
        Catch ex As Exception
            'insertarErrorLog(101, "Actualizar Movtos Factura", ex.Message, Usuario_Num, "actualizarRSNMovtosFactura()")
        End Try
    End Sub
    Public Sub actualizarDiferenciasTC(ByVal iAño As Integer, ByVal iMes As Integer, Optional ByVal iPeriodo As Integer = 8)
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iAño", iAño, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iMes", iMes, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodo, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paActualizarDiferenciasTC")
            End With
        Catch ex As Exception
            'insertarErrorLog(101, "Actualizar Diferencias TC", ex.Message, Usuario_Num, "actualizarDiferenciasTC()")
        End Try
    End Sub

    Private Sub actualizarNotas(ByVal dFechaInicio As Date, ByVal dFechaFinal As Date, ByVal iPeriodo As Integer)
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@dFechaInicio", dFechaInicio, SqlDbType.Date, ParameterDirection.Input)
                .subAddParameter("@dFechaFinal", dFechaFinal, SqlDbType.Date, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodo, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paActualizarNotas")
            End With
        Catch ex As Exception
            'insertarErrorLog(100, "Actualizar Notas", ex.Message, sCveUsuario, "actualizarNotas()")
        End Try
    End Sub
    Private Sub actualizarPagos(ByVal dFechaInicio As Date, ByVal dFechaFinal As Date, ByVal iPeriodo As Integer)
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@dFechaInicio", dFechaInicio, SqlDbType.Date, ParameterDirection.Input)
                .subAddParameter("@dFechaFinal", dFechaFinal, SqlDbType.Date, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodo, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paActualizarPagos")
            End With
        Catch ex As Exception
            'insertarErrorLog(100, "Actualizar Pagos", ex.Message, sCveUsuario, "actualizarPagos()")
        End Try
    End Sub
    Private Sub actualizarMovtosFI(ByVal dFechaInicio As Date, ByVal dFechaFinal As Date, ByVal iPeriodo As Integer)
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@dFechaInicio", dFechaInicio, SqlDbType.Date, ParameterDirection.Input)
                .subAddParameter("@dFechaFinal", dFechaFinal, SqlDbType.Date, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodo, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paActualizarMovtosFI")
            End With
        Catch ex As Exception
            'insertarErrorLog(100, "Actualizar FI", ex.Message, sCveUsuario, "actualizarMovtosFI()")
        End Try
    End Sub
    Private Sub actualizarMovtosFT(ByVal dFechaInicio As Date, ByVal dFechaFinal As Date, ByVal iPeriodo As Integer)
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@dFechaInicio", dFechaInicio, SqlDbType.Date, ParameterDirection.Input)
                .subAddParameter("@dFechaFinal", dFechaFinal, SqlDbType.Date, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodo, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paActualizarMovtosFT")
            End With
        Catch ex As Exception
            'insertarErrorLog(100, "Actualizar FT", ex.Message, sCveUsuario, "actualizarMovtosFT()")
        End Try
    End Sub

    Public Sub actualizarMovtos(Optional ByVal dFechaInicio As Date = Nothing, Optional ByVal dFechaFinal As Date = Nothing, Optional ByVal iPeriodo As Integer = 0)
        actualizarNotas(dFechaInicio, dFechaFinal, iPeriodo)
        actualizarPagos(dFechaInicio, dFechaFinal, iPeriodo)
        actualizarMovtosFI(dFechaInicio, dFechaFinal, iPeriodo)
        actualizarMovtosFT(dFechaInicio, dFechaFinal, iPeriodo)
    End Sub
    Public Sub actualizarAjustesGastos(ByVal iAño As Integer, ByVal iMes As Integer, Optional ByVal iPeriodo As Integer = 0)
        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iAño", iAño, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iMes", iMes, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodo, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paActualizarRSNAjustesGastos")
            End With
        Catch ex As Exception
            'insertarErrorLog(101, "Actualizar Ajustes Gastos", ex.Message, Usuario_Num, "actualizarAjustesGastos()")
        End Try
    End Sub

End Module