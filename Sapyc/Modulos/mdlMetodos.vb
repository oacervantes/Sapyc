Imports System.Reflection

Module mdlMetodos

    Public dtColsExcel As New DataTable
    Public drColsExcel As DataRow

    Public Sub LimpiarConsultaTabla(dt As DataTableCollection, sTabla As String)
        If dt.Contains(sTabla) Then
            dt.Remove(sTabla)
        End If
    End Sub

    Public Sub LimpiarArreglosDbl(arr() As Double, iPos As Integer)
        For x As Integer = 0 To iPos
            arr(x) = 0
        Next
    End Sub
    Public Sub LimpiarArreglosInt(arr() As Integer, iPos As Integer)
        For x As Integer = 0 To iPos
            arr(x) = 0
        Next
    End Sub
    Public Sub BloquearColumnas(grid As DataGridView)
        For Each col As DataGridViewColumn In grid.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Public Sub LimpiarTabla(dt As DataTable)
        If dt.Rows.Count > 0 Then
            dt.Clear()
        End If
    End Sub
    Public Sub LimpiarTablaCols(dt As DataTable)
        If dt.Columns.Count > 0 Then
            dt.Columns.Clear()
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

    Public Sub actualizarFacturacionSocio(sBaseDatos As String, iAño As Integer, iMes As Integer, Optional iPeriodo As Integer = 0)
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
    Public Sub actualizarRSNMovtosFactura(sBaseDatos As String, iAño As Integer, iMes As Integer, Optional iPeriodo As Integer = 0)
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
    Public Sub actualizarDiferenciasTC(iAño As Integer, iMes As Integer, Optional iPeriodo As Integer = 8)
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

    Private Sub actualizarNotas(dFechaInicio As Date, dFechaFinal As Date, iPeriodo As Integer)
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
    Private Sub actualizarPagos(dFechaInicio As Date, dFechaFinal As Date, iPeriodo As Integer)
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
    Private Sub actualizarMovtosFI(dFechaInicio As Date, dFechaFinal As Date, iPeriodo As Integer)
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
    Private Sub actualizarMovtosFT(dFechaInicio As Date, dFechaFinal As Date, iPeriodo As Integer)
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

    Public Sub actualizarMovtos(Optional dFechaInicio As Date = Nothing, Optional dFechaFinal As Date = Nothing, Optional iPeriodo As Integer = 0)
        actualizarNotas(dFechaInicio, dFechaFinal, iPeriodo)
        actualizarPagos(dFechaInicio, dFechaFinal, iPeriodo)
        actualizarMovtosFI(dFechaInicio, dFechaFinal, iPeriodo)
        actualizarMovtosFT(dFechaInicio, dFechaFinal, iPeriodo)
    End Sub
    Public Sub actualizarAjustesGastos(iAño As Integer, iMes As Integer, Optional iPeriodo As Integer = 0)
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
    Public Sub InsertarErrorLog(iError As Integer, sReporte As String, sDescripcion As String, sUsuario As String, Optional sBloqueCod As String = "")
        Try
            With clsDatosConINV
                .subClearParameters()
                .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iError", iError, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sReporte", sReporte, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sNomBloqCod", sBloqueCod, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sDescripcion", sDescripcion, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paLogSIAT")
            End With
        Catch ex As Exception
            MsgBox("Hubo un error al registrar la falla del log, intente de nuevo más tarde", MsgBoxStyle.Critical, "SIAT")
        End Try
    End Sub

    Public Sub FormatoDiseñoGridTotales(grid As DataGridView, iRow As Integer)
        If grid.Rows(iRow).Cells("TIPO").Value = "T" Then
            grid.Rows(iRow).DefaultCellStyle.BackColor = total
            grid.Rows(iRow).DefaultCellStyle.ForeColor = negro
            grid.Rows(iRow).DefaultCellStyle.Font = FuenteFila
        ElseIf grid.Rows(iRow).Cells("TIPO").Value = "TD" Or grid.Rows(iRow).Cells("TIPO").Value = "TA" Or grid.Rows(iRow).Cells("TIPO").Value = "TO" Then
            grid.Rows(iRow).DefaultCellStyle.BackColor = totalDivision
            grid.Rows(iRow).DefaultCellStyle.ForeColor = negro
            grid.Rows(iRow).DefaultCellStyle.Font = FuenteFila
        ElseIf grid.Rows(iRow).Cells("TIPO").Value = "TT" Or grid.Rows(iRow).Cells("TIPO").Value.ToString.Contains("TS") Then
            grid.Rows(iRow).DefaultCellStyle.BackColor = totalGrupo
            grid.Rows(iRow).DefaultCellStyle.ForeColor = negro
            grid.Rows(iRow).DefaultCellStyle.Font = FuenteFila
        ElseIf grid.Rows(iRow).Cells("TIPO").Value = "A" Then
            grid.Rows(iRow).DefaultCellStyle.BackColor = azul_Salles
            grid.Rows(iRow).DefaultCellStyle.ForeColor = blanco
            grid.Rows(iRow).DefaultCellStyle.Font = FuenteFila
        ElseIf grid.Rows(iRow).Cells("TIPO").Value = "M" Then
            grid.Rows(iRow).DefaultCellStyle.BackColor = morado_Salles
            grid.Rows(iRow).DefaultCellStyle.ForeColor = blanco
            grid.Rows(iRow).DefaultCellStyle.Font = FuenteFila
        ElseIf grid.Rows(iRow).Cells("TIPO").Value = "R" Then
            grid.Rows(iRow).DefaultCellStyle.BackColor = rojo_Salles
            grid.Rows(iRow).DefaultCellStyle.ForeColor = blanco
            grid.Rows(iRow).DefaultCellStyle.Font = FuenteFila
        End If
    End Sub
    Public Sub HabilitarCasillas(grid As DataGridView, sCol As String, bValor As Boolean)
        For Each row As DataGridViewRow In grid.Rows
            row.Cells(sCol).Value = bValor
        Next
    End Sub
    Public Sub DesplazamientoGrid(grid As DataGridView)
        grid.VirtualMode = True
        grid.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(grid, True, Nothing)
    End Sub
    Public Sub DiseñoGrid(grid As DataGridView)
        With grid
            .DefaultCellStyle.Font = FuenteCelda
            .DefaultCellStyle.SelectionBackColor = Morado
            .RowTemplate.Height = filGrid
            .ColumnHeadersDefaultCellStyle.Font = FuenteHeader
            .ColumnHeadersHeight = colGrid
        End With
    End Sub
    Public Sub ConfigurarColumnasGrid(grid As DataGridView, columnName As String, headerText As String, width As Integer, alignment As Integer, bloqueo As Boolean)
        grid.Columns(columnName).Frozen = bloqueo
        grid.Columns(columnName).HeaderText = headerText

        If width <> 0 Then
            grid.Columns(columnName).Width = width
        Else
            grid.Columns(columnName).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        Select Case alignment
            Case 1
                grid.Columns(columnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Case 2
                grid.Columns(columnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Case 3
                grid.Columns(columnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End Select
    End Sub


    Public Sub ListarColumnasExcel()
        Dim sCols As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Dim iColA, iColumna As Integer

        dtColsExcel.Columns.Add("COLUMNA", GetType(String))
        dtColsExcel.Columns.Add("NUMERO", GetType(Integer))

        LimpiarTabla(dtColsExcel)
        iColA = 0
        iColumna = 1

        For v As Integer = 0 To 7
            For c As Integer = 0 To sCols.Count - 1
                drColsExcel = dtColsExcel.NewRow()
                If v = 0 Then
                    drColsExcel("COLUMNA") = sCols(c)
                Else
                    drColsExcel("COLUMNA") = sCols(iColA) & sCols(c)
                End If
                drColsExcel("NUMERO") = iColumna
                dtColsExcel.Rows.InsertAt(drColsExcel, dtColsExcel.Rows.Count)

                iColumna += 1
            Next

            If v > 0 Then
                iColA += 1
            End If
        Next
    End Sub

End Module