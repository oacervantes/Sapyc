Imports System.Text
Imports DocumentFormat.OpenXml
Imports SpreadsheetLight

Module mdlExcelv2

    Private styleTitle, styleReport, styleCell, styleHeader, styleTotal, styleTotalGpo, styleCol, styleValor As New SLStyle
    Private Const sEmpresa As String = "SALLES, SAINZ-GRANT THORNTON"
    Dim grid As DataGridView = Nothing

#Region "SAPYC"

    Public Sub exportarReporteDireccion(ByVal tabs As TabControl, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== CONCILIACIÓN INICIAL ====================
        ObtenerGridTab(tabs, 0)

        If grid.Columns(7).Visible = False Then
            ind = 7

            nombreEmpresa(exc, "A1", "AF2")
            nombreReporte(exc, "A3", "AF3", "REPORTE DE LA DIRECCIÓN - CONCILIACIÓN INICIAL")
            nombreColumnas(exc, grid, ind)
        Else
            ind = 6

            nombreEmpresa(exc, "A1", "AG2")
            nombreReporte(exc, "A3", "AG3", "REPORTE DE LA DIRECCIÓN - CONCILIACIÓN INICIAL")
            nombreColumnas(exc, grid, ind)
        End If

        nombreHoja(exc, "Conciliación Inicial")

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= ind Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < 16 Then
                            exc.SetCellValue(row.Index + 5, col.Index - ind, Trim(row.Cells(col.Index).Value.ToString.Replace("""", "")))
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - ind)
                        ElseIf col.Index >= 16 And col.Index < 26 Then
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - ind, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - ind)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - ind, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - ind)
                            End If
                        ElseIf col.Index = 27 Or col.Index = 28 Then
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - ind, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - ind)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - ind, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - ind)
                            End If
                        ElseIf col.Index = 30 Or col.Index = 31 Then
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - ind, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - ind)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - ind, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - ind)
                            End If
                        ElseIf col.Index = 33 Or col.Index = 34 Or col.Index = 36 Or col.Index = 39 Then
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - ind, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - ind)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - ind, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - ind)
                            End If
                        Else
                            exc.SetCellValue(row.Index + 5, col.Index - ind, row.Cells(col.Index).Value.ToString)
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - ind)
                            '    End If
                        End If
                    Next
                End If
            End If
        Next

        MostrarTotal(exc, grid, ind)

        If grid.Columns(7).Visible = False Then
            exc.SetColumnWidth("A", 20)
            exc.SetColumnWidth("B", "C", 49)
            exc.SetColumnWidth("D", "H", 12)
            exc.SetColumnWidth("I", 3)
            exc.SetColumnWidth("J", "R", 20)
            exc.SetColumnWidth("S", 3)
            exc.SetColumnWidth("T", "U", 20)
            exc.SetColumnWidth("V", 49)
            exc.SetColumnWidth("W", "X", 20)
            exc.SetColumnWidth("Y", 3)
            exc.SetColumnWidth("Z", "AA", 20)
            exc.SetColumnWidth("AB", 49)
            exc.SetColumnWidth("AC", 20)
            exc.SetColumnWidth("AD", "AE", 20)
            exc.SetColumnWidth("AF", 20)
        Else
            exc.SetColumnWidth("A", 49)
            exc.SetColumnWidth("B", 20)
            exc.SetColumnWidth("C", "D", 49)
            exc.SetColumnWidth("E", "I", 12)
            exc.SetColumnWidth("J", 3)
            exc.SetColumnWidth("K", "S", 20)
            exc.SetColumnWidth("T", 3)
            exc.SetColumnWidth("U", "V", 20)
            exc.SetColumnWidth("W", 49)
            exc.SetColumnWidth("X", "Y", 20)
            exc.SetColumnWidth("Z", 3)
            exc.SetColumnWidth("AA", "AB", 20)
            exc.SetColumnWidth("AC", 49)
            exc.SetColumnWidth("AD", 20)
            exc.SetColumnWidth("AE", "AF", 20)
            exc.SetColumnWidth("AG", 20)
        End If

        '==================== CONCILIACIÓN DE INGRESOS ====================
        ObtenerGridTab(tabs, 1)

        exc.AddWorksheet("Conciliación Ingresos")
        'nombreEmpresa(exc, "A1", "BF2")
        nombreEmpresa(exc, 1, 1, 2, grid.Columns.Count - 2)
        'nombreReporte(exc, "A3", "BF3", "REPORTE DE LA DIRECCIÓN - CONCILIACIÓN DE INGRESOS")
        nombreReporte(exc, 3, 1, 3, grid.Columns.Count - 2, "REPORTE DE LA DIRECCIÓN - CONCILIACIÓN DE INGRESOS")
        nombreColumnasCI(exc, grid, -1)

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 0 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If row.Index = 15 Then
                            exc.SetCellValue(row.Index + 5, col.Index - 1, Trim(row.Cells(col.Index).Value.ToString))
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - 1)
                        Else
                            If col.Index = 2 Then
                                exc.SetCellValue(row.Index + 5, col.Index - 1, Trim(row.Cells(col.Index).Value.ToString))
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - 1)
                            Else
                                If row.Cells(col.Index).Value = "" Or row.Cells(col.Index).Value Is DBNull.Value Then
                                    exc.SetCellValue(row.Index + 5, col.Index - 1, row.Cells(col.Index).Value)
                                    formatoCeldasTexto(exc, row.Index + 5, col.Index - 1)
                                Else
                                    exc.SetCellValueNumeric(row.Index + 5, col.Index - 1, CDbl(row.Cells(col.Index).Value))
                                    formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - 1)
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        Next

        exc.SetColumnWidth("A", 54)
        exc.SetColumnWidth("B", "BF", 20)

        '==================== NO RECURRENTES ====================
        ObtenerGridTab(tabs, 2)
        exc.AddWorksheet("No Recurrentes")

        nombreEmpresa(exc, "A1", "G2")
        nombreReporte(exc, "A3", "G3", "REPORTE DE LA DIRECCIÓN - TRABAJOS NO RECURRENTES")
        nombreColumnas(exc, grid, 3)
        llenarReporte(exc, grid, 3, 10)
        MostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)
        exc.SetColumnWidth("E", "F", 49)
        exc.SetColumnWidth("G", 20)

        '==================== PERDIDOS ====================
        ObtenerGridTab(tabs, 3)
        exc.AddWorksheet("Perdidos")

        nombreEmpresa(exc, "A1", "H2")
        nombreReporte(exc, "A3", "H3", "REPORTE DE LA DIRECCIÓN - TRABAJOS PERDIDOS")
        nombreColumnas(exc, grid, 6)
        llenarReporte(exc, grid, 6, 13)
        MostrarTotal(exc, grid, 6)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)
        exc.SetColumnWidth("E", "F", 49)
        exc.SetColumnWidth("G", 20)
        exc.SetColumnWidth("H", 54)

        '==================== RECURRENTES POR ARREGLAR ====================
        ObtenerGridTab(tabs, 4)
        exc.AddWorksheet("Recurrentes Por Arreglar")

        nombreEmpresa(exc, "A1", "H2")
        nombreReporte(exc, "A3", "H3", "REPORTE DE LA DIRECCIÓN - TRABAJOS RECURRENTES POR ARREGLAR")
        nombreColumnas(exc, grid, 2)
        llenarReporteCols(exc, grid, 2, 9)
        MostrarTotal(exc, grid, 2)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)
        exc.SetColumnWidth("E", "F", 49)
        exc.SetColumnWidth("G", "H", 20)

        '==================== NUEVOS GANADOS ====================
        ObtenerGridTab(tabs, 5)
        exc.AddWorksheet("Nuevos Ganados")

        nombreEmpresa(exc, "A1", "W2")
        nombreReporte(exc, "A3", "W3", "REPORTE DE LA DIRECCIÓN - TRABAJOS NUEVOS GANADOS")
        nombreColumnas(exc, grid, 4)
        llenarReporte(exc, grid, 4, 13)
        MostrarTotal(exc, grid, 4)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)
        exc.SetColumnWidth("E", "G", 49)
        exc.SetColumnWidth("H", 20)
        exc.SetColumnWidth("I", "X", 49)

        '==================== RECURRENTES ====================
        ObtenerGridTab(tabs, 6)
        exc.AddWorksheet("Recurrentes Arreglados")

        nombreEmpresa(exc, "A1", "L2")
        nombreReporte(exc, "A3", "L3", "REPORTE DE LA DIRECCIÓN - TRABAJOS RECURRENTES ARREGLADOS")
        nombreColumnas(exc, grid, 6)
        llenarReporteCols(exc, grid, 6, 15)
        MostrarTotal(exc, grid, 6)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)
        exc.SetColumnWidth("E", "G", 49)
        exc.SetColumnWidth("H", "L", 20)

        '==================== PROPUESTAS POR RESOLVER ====================
        ObtenerGridTab(tabs, 7)
        exc.AddWorksheet("Propuestas por Resolver")

        nombreEmpresa(exc, "A1", "V2")
        nombreReporte(exc, "A3", "V3", "REPORTE DE LA DIRECCIÓN - PROPUESTAS POR RESOLVER")
        nombreColumnas(exc, grid, 4)
        llenarReporte(exc, grid, 4, 11)
        MostrarTotal(exc, grid, 4)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "C", 20)
        exc.SetColumnWidth("D", "E", 49)
        exc.SetColumnWidth("F", 20)
        exc.SetColumnWidth("G", 54)
        exc.SetColumnWidth("H", "W", 49)

        '==================== PROPUESTAS RECHAZADAS ====================
        ObtenerGridTab(tabs, 8)
        exc.AddWorksheet("Propuestas Rechazadas")

        nombreEmpresa(exc, "A1", "V2")
        nombreReporte(exc, "A3", "V3", "REPORTE DE LA DIRECCIÓN - PROPUESTAS RECHAZADAS")
        nombreColumnas(exc, grid, 4)
        llenarReporte(exc, grid, 4, 11)
        MostrarTotal(exc, grid, 4)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "C", 20)
        exc.SetColumnWidth("D", "E", 49)
        exc.SetColumnWidth("F", 20)
        exc.SetColumnWidth("G", 54)
        exc.SetColumnWidth("H", "W", 49)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarClientesReferenciados(ByVal tabs As TabControl, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== PROPUESTAS PPTO. ====================
        ObtenerGridTab(tabs, 0)

        nombreEmpresa(exc, "A1", "J2")
        nombreReporte(exc, "A3", "J3", "CLIENTES NUEVOS REFERENCIADOS")
        nombreColumnas(exc, grid, 7)
        llenarReporteDosCol(exc, grid, 7, 12, 13)
        MostrarTotal(exc, grid, 7)

        exc.SetColumnWidth("A", 20)
        exc.SetColumnWidth("B", 45)
        exc.SetColumnWidth("C", "D", 35)
        exc.SetColumnWidth("E", "F", 20)
        exc.SetColumnWidth("G", "J", 35)

        nombreHoja(exc, "Clientes nuevos")

        '==================== PROPUESTAS NUEVAS ====================
        ObtenerGridTab(tabs, 1)
        exc.AddWorksheet("Clientes recurrentes")

        nombreEmpresa(exc, "A1", "J2")
        nombreReporte(exc, "A3", "J3", "CLIENTES RECURRENTES REFERENCIADOS")
        nombreColumnas(exc, grid, 7)
        llenarReporteDosCol(exc, grid, 7, 12, 13)
        MostrarTotal(exc, grid, 7)

        exc.SetColumnWidth("A", 20)
        exc.SetColumnWidth("B", 45)
        exc.SetColumnWidth("C", "D", 35)
        exc.SetColumnWidth("E", "F", 20)
        exc.SetColumnWidth("G", "J", 35)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Private Sub ObtenerGridTab(tab As TabControl, id As Integer)
        For t As Integer = 0 To tab.TabPages(id).Controls.Count - 1
            If tab.TabPages(id).Controls(t).GetType.Name <> "DataGridView" Then
                Continue For
            Else
                grid = CType(tab.TabPages(id).Controls.Item(t), DataGridView)
            End If
        Next
    End Sub

    Public Sub ExportarProspectosSAC(grid As DataGridView, sRutaArchivo As String, sNombreArchivo As String)
        Dim exc As New SLDocument

        '==================== OFICINAS ====================
        nombreEmpresa(exc, "A1", "N2")
        nombreReporte(exc, "A3", "N3", "REVISIÓN DE PROSPECTOS")
        nombreColumnas(exc, grid, 1)

        nombreHoja(exc, "Prospectos")
        LlenarReporteTabla(exc, grid, 5, 1, {}, {})
        FormatoColumnasTexto(exc, 5, grid.Rows.Count + 4, {1, 2, 3, 4, 5, 6, 7})

        exc.SetColumnWidth("A", 20)
        exc.SetColumnWidth("B", 49)
        exc.SetColumnWidth("C", "D", 18)
        exc.SetColumnWidth("E", "F", 35)
        exc.SetColumnWidth("G", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub ExportarGRD(grid As DataGridView, sRutaArchivo As String, sNombreArchivo As String)
        Dim exc As New SLDocument

        '==================== RESUMEN ====================
        'nombreEmpresa(exc, "A1", "BA2")
        'nombreReporte(exc, "A3", "BA3", "GRD - CLIENTES")

        'nombreColumnas(exc, grid, 1)

        nombreHoja(exc, "GRD")
        LlenarReporteTabla(exc, grid, 5, 1, {}, {})
        'FormatoColumnasTexto(exc, 5, grid.Rows.Count + 4, {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12})
        'FormatoColumnasNumero(exc, 2, 5, grid.Rows.Count + 4, {13, 14, 15, 16, 17, 18, 19, 20, 21, 22,
        '                                                       23, 24, 25, 26, 27, 28, 29, 30, 31, 32,
        '                                                       33, 34, 35, 36, 37, 38, 39, 40, 41, 42,
        '                                                       43, 44, 45, 46, 47, 48, 49, 50, 51, 52,
        '                                                       53})
        'MostrarTotal(exc, grid, 1, "TIPO", "A", "BA")

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", 20)
        exc.SetColumnWidth("C", 49)
        exc.SetColumnWidth("D", "BA", 20)
        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".csv")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

#End Region

    Private Sub nombreEmpresa(exc As SLDocument, sRngIni As String, sRngFin As String)
        styleTitle.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleTitle.Fill.SetPatternForegroundColor(blanco)
        styleTitle.SetFontBold(True)
        styleTitle.SetFontColor(morado_Salles)
        styleTitle.SetFont("Calibri", 30)
        styleTitle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        styleTitle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        exc.MergeWorksheetCells(sRngIni, sRngFin)
        exc.SetCellValue(sRngIni, sEmpresa)
        exc.SetCellStyle(sRngIni, styleTitle)
    End Sub
    Private Sub nombreReporte(exc As SLDocument, sRngIni As String, sRngFin As String, sReporte As String)
        styleReport.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleReport.Fill.SetPatternForegroundColor(blanco)
        styleReport.SetFontBold(True)
        styleReport.SetFontColor(negro)
        styleReport.SetFont("Calibri", 18)
        styleReport.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        styleReport.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        exc.MergeWorksheetCells(sRngIni, sRngFin)
        exc.SetCellValue(sRngIni, sReporte)
        exc.SetCellStyle(sRngIni, styleReport)
    End Sub

    Private Sub nombreEmpresa(exc As SLDocument, iFilaIni As Integer, iColIni As Integer, iFilaFin As Integer, iColFin As Integer)
        styleTitle.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleTitle.Fill.SetPatternForegroundColor(blanco)
        styleTitle.SetFontBold(True)
        styleTitle.SetFontColor(morado_Salles)
        styleTitle.SetFont("Calibri", 30)
        styleTitle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        styleTitle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        exc.MergeWorksheetCells(iFilaIni, iColIni, iFilaFin, iColFin)
        exc.SetCellValue(iFilaIni, iColIni, sEmpresa)
        exc.SetCellStyle(iFilaIni, iColIni, styleTitle)
    End Sub
    Private Sub nombreReporte(exc As SLDocument, iFilaIni As Integer, iColIni As Integer, iFilaFin As Integer, iColFin As Integer, sReporte As String)
        styleReport.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleReport.Fill.SetPatternForegroundColor(blanco)
        styleReport.SetFontBold(True)
        styleReport.SetFontColor(negro)
        styleReport.SetFont("Calibri", 18)
        styleReport.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        styleReport.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        exc.MergeWorksheetCells(iFilaIni, iColIni, iFilaFin, iColFin)
        exc.SetCellValue(iFilaIni, iColIni, sReporte)
        exc.SetCellStyle(iFilaIni, iColIni, styleReport)
    End Sub

    Private Sub nombreColumnas(exc As SLDocument, grid As DataGridView, indice As Integer)
        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= indice Then
                If col.Visible Then
                    exc.SetCellValue(4, col.Index - indice, col.HeaderText)
                    formatoHeaders(exc, 4, col.Index - indice)
                End If
            End If
        Next
    End Sub
    Private Sub nombreColumnasTabla(exc As SLDocument, tabla As DataTable, indice As Integer)
        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= indice Then
                If col.Visible Then
                    exc.SetCellValue(4, col.Index - indice, col.HeaderText)
                    formatoHeaders(exc, 4, col.Index - indice)
                End If
            End If
        Next
    End Sub
    Private Sub nombreColumnasTP(exc As SLDocument, grid As DataGridView, indice As Integer)
        For Each row As DataGridViewRow In grid.Rows
            If row.Cells("TIPO").Value = "H" Then
                For Each col As DataGridViewColumn In grid.Columns
                    If col.Index >= indice Then
                        If col.Visible Then
                            'exc.SetCellValue(row.Index + 5, col.Index - indice, col.HeaderText)
                            formatoHeaders(exc, row.Index + 10, col.Index - indice)
                        End If
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub nombreColumnasCI(exc As SLDocument, grid As DataGridView, indice As Integer)
        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 0 Then
                If col.Visible Then
                    exc.SetCellValue(4, col.Index + indice, col.HeaderText)
                    formatoHeaders(exc, 4, col.Index + indice)
                End If
            End If
        Next
    End Sub
    Private Sub nombreHoja(exc As SLDocument, sNombre As String)
        exc.RenameWorksheet(exc.GetCurrentWorksheetName, sNombre)
    End Sub

    Private Sub LlenarReporteTabla(exc As SLDocument, grid As DataGridView, fila As Integer, columna As Integer, colsInt() As Integer, colsDbl() As Integer, Optional colsOcu() As Integer = Nothing)
        Dim dt As New DataTable

        For Each column As DataGridViewColumn In grid.Columns
            If colsOcu IsNot Nothing Then
                If Array.IndexOf(colsOcu, column.Index) <> -1 Then
                    Continue For
                End If
            End If

            If column.Visible = True And column.Index > 0 Then
                If Array.IndexOf(colsInt, column.Index) <> -1 Then
                    dt.Columns.Add(column.Name, GetType(Integer))
                ElseIf Array.IndexOf(colsDbl, column.Index) <> -1 Then
                    dt.Columns.Add(column.Name, GetType(Double))
                Else
                    dt.Columns.Add(column.Name, column.ValueType)
                End If
            End If
        Next

        For Each row As DataGridViewRow In grid.Rows
            If Not row.IsNewRow Then
                Dim dataRow As DataRow = dt.NewRow()
                For Each column As DataGridViewColumn In grid.Columns
                    If colsOcu IsNot Nothing Then
                        If Array.IndexOf(colsOcu, column.Index) <> -1 Then
                            Continue For
                        End If
                    End If

                    If column.Visible = True And column.Index > 0 Then
                        If Array.IndexOf(colsInt, column.Index) <> -1 Then
                            If row.Cells(column.Name).Value.ToString = "" Then
                                dataRow(column.Name) = DBNull.Value
                            Else
                                dataRow(column.Name) = CInt(row.Cells(column.Name).Value)
                            End If
                        ElseIf Array.IndexOf(colsDbl, column.Index) <> -1 Then
                            If row.Cells(column.Name).Value.ToString = "" Then
                                dataRow(column.Name) = DBNull.Value
                            Else
                                dataRow(column.Name) = CDbl(row.Cells(column.Name).Value)
                            End If
                        Else
                            dataRow(column.Name) = IIf(row.Cells(column.Name).Value = "", DBNull.Value, row.Cells(column.Name).Value)
                        End If
                    End If
                Next
                dt.Rows.Add(dataRow)
            End If
        Next

        exc.ImportDataTable(fila, columna, dt, False)
    End Sub
    Private Sub FormatoColumnasTexto(exc As SLDocument, iFilaIni As Integer, iFilaFin As Integer, iCols() As Integer)
        Dim sCol As String

        styleCell.Fill.SetPatternType(Spreadsheet.PatternValues.Solid)
        styleCell.Fill.SetPatternForegroundColor(blanco)
        styleCell.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Left)
        styleCell.SetVerticalAlignment(Spreadsheet.VerticalAlignmentValues.Center)

        For c As Integer = 0 To iCols.Count - 1
            sCol = ObtenerLetraColumna(iCols(c))
            exc.SetCellStyle(sCol & iFilaIni, sCol & iFilaFin, styleCell)
        Next
    End Sub
    Private Sub FormatoColumnasNumero(exc As SLDocument, iTipo As Integer, iFilaIni As Integer, iFilaFin As Integer, iCols() As Integer)
        Dim sCol As String

        Select Case iTipo
            Case 0
                styleCell.FormatCode = "###0_);[Red](###0)"
            Case 1 'Formato Entero
                styleCell.FormatCode = "#,##0_);[Red](#,##0)"
            Case 2 'Formato Doble
                styleCell.FormatCode = "#,##0.00_);[Red](#,##0.00)"
            Case 3 'Formato porcentaje
                styleCell.FormatCode = "0.00%_);[Red](0.00%)"
        End Select

        styleCell.Fill.SetPatternType(Spreadsheet.PatternValues.Solid)
        styleCell.Fill.SetPatternForegroundColor(blanco)
        styleCell.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Right)
        styleCell.SetVerticalAlignment(Spreadsheet.VerticalAlignmentValues.Center)

        For c As Integer = 0 To iCols.Count - 1
            sCol = ObtenerLetraColumna(iCols(c))
            exc.SetCellStyle(sCol & iFilaIni, sCol & iFilaFin, styleCell)
        Next
    End Sub

    Private Sub MostrarTotal(exc As SLDocument, grid As DataGridView, indice As Integer, Optional sCol As String = "TIPO", Optional sColIni As String = "", Optional sColFin As String = "")
        'For Each col As DataGridViewColumn In grid.Columns
        '    If col.Index >= indice Then
        '        If col.Visible Then
        For Each row As DataGridViewRow In grid.Rows
            If row.Cells(sCol).Value = "T" Then
                FormatoTotal(exc, row.Index + 5, 0, sColIni, sColFin)

            ElseIf row.Cells(sCol).Value = "TCN" Or row.Cells(sCol).Value.ToString.Contains("TS") Or row.Cells(sCol).Value.ToString.Contains("TG") Then
                FormatoTotalGpo(exc, row.Index + 5, 0, sColIni, sColFin)

            ElseIf row.Cells(sCol).Value = "TO" Or row.Cells(sCol).Value = "TD" Or row.Cells(sCol).Value = "TA" Or row.Cells(sCol).Value = "TR" Or row.Cells(sCol).Value = "TPC" Or row.Cells(sCol).Value = "TP" Then
                FormatoTotalDivision(exc, row.Index + 5, 0, sColIni, sColFin)

            ElseIf row.Cells(sCol).Value = "O" Or row.Cells(sCol).Value = "D" Or row.Cells(sCol).Value = "H" Or row.Cells(sCol).Value = "A" Or row.Cells(sCol).Value = "M" Then
                formatoHeadersPrincipal(exc, row.Index + 5, 0, sColIni, sColFin)

            End If
        Next
        '        End If
        '    End If
        'Next
    End Sub

    Private Sub FormatoTotal(exc As SLDocument, iRow As Integer, iCol As Integer, Optional sColIni As String = "", Optional sColFin As String = "")
        styleTotal.Fill.SetPatternType(Spreadsheet.PatternValues.Solid)
        styleTotal.Fill.SetPatternForegroundColor(total)
        styleTotal.SetTopBorder(Spreadsheet.BorderStyleValues.Thin, negro)
        styleTotal.SetBottomBorder(Spreadsheet.BorderStyleValues.Double, negro)
        styleTotal.SetFontBold(True)
        styleTotal.SetFontColor(negro)
        styleTotal.SetFont("Calibri", 11)
        styleTotal.SetVerticalAlignment(Spreadsheet.VerticalAlignmentValues.Center)

        'exc.SetCellStyle(iRow, iCol, styleTotal)
        exc.SetCellStyle(sColIni & iRow, sColFin & iRow, styleTotal)
    End Sub
    Private Sub FormatoTotalDivision(exc As SLDocument, iRow As Integer, iCol As Integer, Optional sColIni As String = "", Optional sColFin As String = "")
        styleTotalGpo.Fill.SetPatternType(Spreadsheet.PatternValues.Solid)
        styleTotalGpo.Fill.SetPatternForegroundColor(totalDivision)
        styleTotalGpo.SetTopBorder(Spreadsheet.BorderStyleValues.Thin, negro)
        styleTotalGpo.SetBottomBorder(Spreadsheet.BorderStyleValues.Double, negro)
        styleTotalGpo.SetFontBold(True)
        styleTotalGpo.SetFontColor(negro)
        styleTotalGpo.SetFont("Calibri", 11)
        styleTotalGpo.SetVerticalAlignment(Spreadsheet.VerticalAlignmentValues.Center)

        'exc.SetCellStyle(iRow, iCol, styleTotalGpo)
        exc.SetCellStyle(sColIni & iRow, sColFin & iRow, styleTotalGpo)
    End Sub
    Private Sub FormatoTotalGpo(exc As SLDocument, iRow As Integer, iCol As Integer, Optional sColIni As String = "", Optional sColFin As String = "")
        styleTotalGpo.Fill.SetPatternType(Spreadsheet.PatternValues.Solid)
        styleTotalGpo.Fill.SetPatternForegroundColor(totalGrupo)
        styleTotalGpo.SetTopBorder(Spreadsheet.BorderStyleValues.Thin, negro)
        styleTotalGpo.SetBottomBorder(Spreadsheet.BorderStyleValues.Double, negro)
        styleTotalGpo.SetFontBold(True)
        styleTotalGpo.SetFontColor(negro)
        styleTotalGpo.SetFont("Calibri", 11)
        styleTotalGpo.SetVerticalAlignment(Spreadsheet.VerticalAlignmentValues.Center)

        'exc.SetCellStyle(iRow, iCol, styleTotalGpo)
        exc.SetCellStyle(sColIni & iRow, sColFin & iRow, styleTotalGpo)
    End Sub
    Private Sub formatoHeadersPrincipal(exc As SLDocument, iRow As Integer, iCol As Integer, Optional sColIni As String = "", Optional sColFin As String = "")
        styleHeader.Fill.SetPatternType(Spreadsheet.PatternValues.Solid)
        styleHeader.Fill.SetPatternForegroundColor(blanco)
        styleHeader.SetWrapText(True)
        styleHeader.SetFontBold(True)
        styleHeader.SetFontColor(negro)
        styleHeader.SetFont("Calibri", 11)
        styleHeader.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Left)
        styleHeader.SetVerticalAlignment(Spreadsheet.VerticalAlignmentValues.Center)

        'exc.SetCellStyle(iRow, iCol, styleHeader)
        exc.SetCellStyle(sColIni & iRow, sColFin & iRow, styleHeader)
    End Sub
    'Private Sub mostrarTotal(exc As SLDocument, grid As DataGridView, indice As Integer)
    '    For Each col As DataGridViewColumn In grid.Columns
    '        If col.Index >= indice Then
    '            If col.Visible Then
    '                For Each row As DataGridViewRow In grid.Rows
    '                    If row.Cells("TIPO").Value = "T" Then
    '                        formatoTotal(exc, row.Index + 5, col.Index - indice)
    '                    ElseIf row.Cells("TIPO").Value = "TO" Or row.Cells("TIPO").Value = "TD" Or row.Cells("TIPO").Value = "TA" Or row.Cells("TIPO").Value = "TS" Or row.Cells("TIPO").Value.ToString.Contains("TS") Then
    '                        formatoTotalGpo(exc, row.Index + 5, col.Index - indice)
    '                    End If
    '                Next
    '            End If
    '        End If
    '    Next
    'End Sub

    Private Sub llenarReporte(exc As SLDocument, grid As DataGridView, indice As Integer, columna As Integer)
        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= indice Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index <> columna Then
                            exc.SetCellValue(row.Index + 5, col.Index - indice, Trim(row.Cells(col.Index).Value.ToString))
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                        Else
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - indice, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - indice, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - indice)
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub
    Private Sub llenarReporteDosCol(exc As SLDocument, grid As DataGridView, indice As Integer, col1 As Integer, col2 As Integer)
        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= indice Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index <> col1 And col.Index <> col2 Then
                            exc.SetCellValue(row.Index + 5, col.Index - indice, Trim(row.Cells(col.Index).Value.ToString))
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                        Else
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - indice, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - indice, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - indice)
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub
    Private Sub llenarReporteTresCol(exc As SLDocument, grid As DataGridView, indice As Integer, col1 As Integer, col2 As Integer)
        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= indice Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < col1 And col.Index <> col2 Then
                            exc.SetCellValue(row.Index + 5, col.Index - indice, Trim(row.Cells(col.Index).Value.ToString))
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                        Else
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - indice, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - indice, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - indice)
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub
    Private Sub llenarReporteCuatroCol(exc As SLDocument, grid As DataGridView, indice As Integer, col1 As Integer, col2 As Integer, col3 As Integer)
        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= indice Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < col1 Or col.Index = col2 Or col.Index = col3 Then
                            exc.SetCellValue(row.Index + 5, col.Index - indice, Trim(row.Cells(col.Index).Value.ToString))
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                        Else
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - indice, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - indice, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - indice)
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub
    Private Sub llenarReporteCols(exc As SLDocument, grid As DataGridView, indice As Integer, columna As Integer)
        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= indice Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < columna Then
                            If row.Cells(col.Index).Value = "" Or row.Cells(col.Index).Value Is DBNull.Value Then
                                exc.SetCellValue(row.Index + 5, col.Index - indice, row.Cells(col.Index).Value.ToString)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                            Else
                                exc.SetCellValue(row.Index + 5, col.Index - indice, Trim(row.Cells(col.Index).Value.ToString))
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                            End If
                        Else
                            If row.Cells(col.Index).Value = "" Or row.Cells(col.Index).Value Is DBNull.Value Then
                                exc.SetCellValue(row.Index + 5, col.Index - indice, row.Cells(col.Index).Value.ToString)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - indice, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - indice)
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub
    Private Sub llenarReportePpto(exc As SLDocument, grid As DataGridView, indice As Integer, columna As Integer, colPor As Integer)
        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= indice Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < columna Or col.Index = colPor Then
                            exc.SetCellValue(row.Index + 5, col.Index - indice, Trim(row.Cells(col.Index).Value.ToString))
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                        Else
                            If row.Cells(col.Index).Value = "" Or row.Cells(col.Index).Value Is DBNull.Value Then
                                exc.SetCellValue(row.Index + 5, col.Index - indice, row.Cells(col.Index).Value.ToString)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - indice, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - indice)
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub
    Private Sub llenarReporteDosColv2(exc As SLDocument, grid As DataGridView, indice As Integer, col1 As Integer, col2 As Integer)
        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= indice Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < col1 Or col.Index > col2 Then
                            exc.SetCellValue(row.Index + 5, col.Index - indice, Trim(row.Cells(col.Index).Value.ToString))
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                        Else
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - indice, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - indice)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - indice, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - indice)
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub formatoCeldasTexto(exc As SLDocument, iRow As Integer, iCol As Integer)
        styleCell.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleCell.Fill.SetPatternForegroundColor(blanco)
        styleCell.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        styleCell.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        exc.SetCellStyle(iRow, iCol, styleCell)
    End Sub
    Private Sub formatoCeldasNumero(exc As SLDocument, iTipo As Integer, iRow As Integer, iCol As Integer)
        Select Case iTipo
            Case 1 'Formato Entero
                styleCell.FormatCode = "#,##0"
            Case 2 'Formato Doble
                styleCell.FormatCode = "#,##0.00"
        End Select

        styleCell.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleCell.Fill.SetPatternForegroundColor(blanco)
        styleCell.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        styleCell.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        exc.SetCellStyle(iRow, iCol, styleCell)
    End Sub
    Private Sub formatoCeldasValor(exc As SLDocument, iRow As Integer, iCol As Integer, color As Color, colorLetra As Color)
        styleValor.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleValor.Fill.SetPatternForegroundColor(color)
        styleValor.SetWrapText(True)
        styleValor.SetFontBold(True)
        styleValor.SetFontColor(colorLetra)
        styleValor.SetFont("Calibri", 11)
        styleValor.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        styleValor.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        exc.SetCellStyle(iRow, iCol, styleValor)
    End Sub
    Private Sub formatoHeaders(exc As SLDocument, iRow As Integer, iCol As Integer)
        styleHeader.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleHeader.Fill.SetPatternForegroundColor(morado_Salles)
        styleHeader.SetWrapText(True)
        styleHeader.SetFontBold(True)
        styleHeader.SetFontColor(blanco)
        styleHeader.SetFont("Calibri", 11)
        styleHeader.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        styleHeader.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        exc.SetCellStyle(iRow, iCol, styleHeader)
    End Sub
    Private Sub formatoTotal(exc As SLDocument, iRow As Integer, iCol As Integer)
        styleTotal.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleTotal.Fill.SetPatternForegroundColor(total)
        styleTotal.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, negro)
        styleTotal.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Double, negro)
        styleTotal.SetFontBold(True)
        styleTotal.SetFontColor(negro)
        styleTotal.SetFont("Calibri", 11)
        styleTotal.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        exc.SetCellStyle(iRow, iCol, styleTotal)
    End Sub
    Private Sub formatoTotalGpo(exc As SLDocument, iRow As Integer, iCol As Integer)
        styleTotalGpo.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleTotalGpo.Fill.SetPatternForegroundColor(totalGrupo)
        styleTotalGpo.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, negro)
        styleTotalGpo.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Double, negro)
        styleTotalGpo.SetFontBold(True)
        styleTotalGpo.SetFontColor(negro)
        styleTotalGpo.SetFont("Calibri", 11)
        styleTotalGpo.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        exc.SetCellStyle(iRow, iCol, styleTotalGpo)
    End Sub

    Private Function ObtenerLetraColumna(iCol As Integer) As String
        Dim drF() As DataRow
        Dim sCol As String

        drF = dtColsExcel.Select("NUMERO = " & iCol)

        sCol = drF(0).Item("COLUMNA").ToString

        Return sCol
    End Function

End Module