Imports DocumentFormat.OpenXml.Drawing.Wordprocessing
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

        mostrarTotal(exc, grid, ind)

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
        mostrarTotal(exc, grid, 3)

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
        mostrarTotal(exc, grid, 6)

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
        mostrarTotal(exc, grid, 2)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)
        exc.SetColumnWidth("E", "F", 49)
        exc.SetColumnWidth("G", "H", 20)

        '==================== NUEVOS GANADOS ====================
        ObtenerGridTab(tabs, 5)
        exc.AddWorksheet("Nuevos Ganados")

        nombreEmpresa(exc, "A1", "H2")
        nombreReporte(exc, "A3", "H3", "REPORTE DE LA DIRECCIÓN - TRABAJOS NUEVOS GANADOS")
        nombreColumnas(exc, grid, 3)
        llenarReporteCols(exc, grid, 3, 11)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)
        exc.SetColumnWidth("E", "G", 49)
        exc.SetColumnWidth("H", 20)

        '==================== RECURRENTES ====================
        ObtenerGridTab(tabs, 6)
        exc.AddWorksheet("Recurrentes Arreglados")

        nombreEmpresa(exc, "A1", "L2")
        nombreReporte(exc, "A3", "L3", "REPORTE DE LA DIRECCIÓN - TRABAJOS RECURRENTES ARREGLADOS")
        nombreColumnas(exc, grid, 6)
        llenarReporteCols(exc, grid, 6, 15)
        mostrarTotal(exc, grid, 6)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)
        exc.SetColumnWidth("E", "G", 49)
        exc.SetColumnWidth("H", "L", 20)

        '==================== PROPUESTAS POR RESOLVER ====================
        ObtenerGridTab(tabs, 7)
        exc.AddWorksheet("Propuestas por Resolver")

        nombreEmpresa(exc, "A1", "G2")
        nombreReporte(exc, "A3", "G3", "REPORTE DE LA DIRECCIÓN - PROPUESTAS POR RESOLVER")
        nombreColumnas(exc, grid, 3)
        llenarReporte(exc, grid, 3, 9)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "C", 20)
        exc.SetColumnWidth("D", "E", 49)
        exc.SetColumnWidth("F", 20)
        exc.SetColumnWidth("G", 54)

        '==================== PROPUESTAS RECHAZADAS ====================
        ObtenerGridTab(tabs, 8)
        exc.AddWorksheet("Propuestas Rechazadas")

        nombreEmpresa(exc, "A1", "G2")
        nombreReporte(exc, "A3", "G3", "REPORTE DE LA DIRECCIÓN - PROPUESTAS RECHAZADAS")
        nombreColumnas(exc, grid, 3)
        llenarReporte(exc, grid, 3, 9)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "C", 20)
        exc.SetColumnWidth("D", "E", 49)
        exc.SetColumnWidth("F", 20)
        exc.SetColumnWidth("G", 54)

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

    Private Sub mostrarTotal(exc As SLDocument, grid As DataGridView, indice As Integer)
        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= indice Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If row.Cells("TIPO").Value = "T" Then
                            formatoTotal(exc, row.Index + 5, col.Index - indice)
                        ElseIf row.Cells("TIPO").Value = "TO" Or row.Cells("TIPO").Value = "TD" Or row.Cells("TIPO").Value = "TA" Or row.Cells("TIPO").Value = "TS" Or row.Cells("TIPO").Value.ToString.Contains("TS") Then
                            formatoTotalGpo(exc, row.Index + 5, col.Index - indice)
                        End If
                    Next
                End If
            End If
        Next
    End Sub

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

End Module