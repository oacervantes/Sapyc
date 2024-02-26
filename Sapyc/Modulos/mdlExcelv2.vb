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

        nombreEmpresa(exc, "A1", "W2")
        nombreReporte(exc, "A3", "W3", "REPORTE DE LA DIRECCIÓN - TRABAJOS NUEVOS GANADOS")
        nombreColumnas(exc, grid, 4)
        llenarReporte(exc, grid, 4, 13)
        mostrarTotal(exc, grid, 4)

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
        mostrarTotal(exc, grid, 6)

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
        mostrarTotal(exc, grid, 4)

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
        mostrarTotal(exc, grid, 4)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "C", 20)
        exc.SetColumnWidth("D", "E", 49)
        exc.SetColumnWidth("F", 20)
        exc.SetColumnWidth("G", 54)
        exc.SetColumnWidth("H", "W", 49)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarProyeccionResultados(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument

        nombreEmpresa(exc, 1, 1, 2, grid.Columns.Count - 2)
        nombreReporte(exc, 3, 1, 3, grid.Columns.Count - 2, "PROYECCIÓN DE RESULTADOS")
        nombreColumnas(exc, grid, 1)

        nombreHoja(exc, "Proyección")

        llenarReporteCols(exc, grid, 1, 3)
        mostrarTotal(exc, grid, 1)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "GW", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub exportarClientesPresupuestados(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "F2")
        nombreReporte(exc, "A3", "F3", "CLIENTES PRESUPUESTADOS")
        nombreColumnas(exc, grid, 20)

        nombreHoja(exc, "Clientes Ppto.")

        llenarReporteDosCol(exc, grid, 20, 24, 25)
        mostrarTotal(exc, grid, 20)

        exc.SetColumnWidth("A", "B", 20)
        exc.SetColumnWidth("C", 49)
        exc.SetColumnWidth("D", "F", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub exportarRevisionPropuestas(ByVal tabs As TabControl, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== PROPUESTAS PPTO. ====================
        ObtenerGridTab(tabs, 0)

        nombreEmpresa(exc, "A1", "K2")
        nombreReporte(exc, "A3", "K3", "PROPUESTAS PRESUPUESTADAS")
        nombreColumnas(exc, grid, 3)
        llenarReporteDosCol(exc, grid, 3, 12, 13)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 10)
        exc.SetColumnWidth("B", "C", 30)
        exc.SetColumnWidth("D", "E", 15)
        exc.SetColumnWidth("F", "H", 49)
        exc.SetColumnWidth("I", "J", 20)
        exc.SetColumnWidth("K", 35)

        For Each r As DataGridViewRow In grid.Rows
            If r.Cells("TIPO").Value = "S" Then
                Select Case CInt(r.Cells("IDESTATUS").Value)
                    Case 1, 5
                        formatoCeldasValor(exc, r.Index + 5, grid.Columns.Count - 4, Color.FromArgb(47, 158, 68), Color.White)
                    Case 2, 3
                        formatoCeldasValor(exc, r.Index + 5, grid.Columns.Count - 4, Color.FromArgb(250, 224, 60), Color.Black)
                    Case 4, 6
                        formatoCeldasValor(exc, r.Index + 5, grid.Columns.Count - 4, Color.FromArgb(233, 40, 65), Color.White)
                    Case Else
                        formatoCeldasValor(exc, r.Index + 5, grid.Columns.Count - 4, Color.FromArgb(255, 125, 30), Color.White)
                End Select
            End If
        Next

        nombreHoja(exc, "Propuestas Ppto.")

        '==================== PROPUESTAS NUEVAS ====================
        ObtenerGridTab(tabs, 1)
        exc.AddWorksheet("Propuestas Nuevas")

        nombreEmpresa(exc, "A1", "J2")
        nombreReporte(exc, "A3", "J3", "PROPUESTAS NUEVAS")
        nombreColumnas(exc, grid, 5)
        llenarReporte(exc, grid, 5, 14)
        mostrarTotal(exc, grid, 5)

        exc.SetColumnWidth("A", 10)
        exc.SetColumnWidth("B", "D", 30)
        exc.SetColumnWidth("E", "F", 15)
        exc.SetColumnWidth("G", "H", 49)
        exc.SetColumnWidth("I", 20)
        exc.SetColumnWidth("J", 30)

        For Each r As DataGridViewRow In grid.Rows
            If r.Cells("TIPO").Value = "S" Then
                Select Case CInt(r.Cells("IDESTATUS").Value)
                    Case 1, 5
                        formatoCeldasValor(exc, r.Index + 5, grid.Columns.Count - 6, Color.FromArgb(47, 158, 68), Color.White)
                    Case 2, 3
                        formatoCeldasValor(exc, r.Index + 5, grid.Columns.Count - 6, Color.FromArgb(250, 224, 60), Color.Black)
                    Case 4, 6
                        formatoCeldasValor(exc, r.Index + 5, grid.Columns.Count - 6, Color.FromArgb(233, 40, 65), Color.White)
                    Case Else
                        formatoCeldasValor(exc, r.Index + 5, grid.Columns.Count - 6, Color.FromArgb(255, 125, 30), Color.White)
                End Select
            End If
        Next

        '==================== PROPUESTAS RECURRENTES ====================
        ObtenerGridTab(tabs, 2)
        exc.AddWorksheet("Propuestas Recurrentes")

        nombreEmpresa(exc, "A1", "J2")
        nombreReporte(exc, "A3", "J3", "PROPUESTAS RECURRENTES")
        nombreColumnas(exc, grid, 5)
        llenarReporte(exc, grid, 5, 14)
        mostrarTotal(exc, grid, 5)

        exc.SetColumnWidth("A", 10)
        exc.SetColumnWidth("B", "D", 30)
        exc.SetColumnWidth("E", "F", 15)
        exc.SetColumnWidth("G", "H", 49)
        exc.SetColumnWidth("I", 20)
        exc.SetColumnWidth("J", 30)

        For Each r As DataGridViewRow In grid.Rows
            If r.Cells("TIPO").Value = "S" Then
                Select Case CInt(r.Cells("IDESTATUS").Value)
                    Case 1, 5
                        formatoCeldasValor(exc, r.Index + 5, grid.Columns.Count - 6, Color.FromArgb(47, 158, 68), Color.White)
                    Case 2, 3
                        formatoCeldasValor(exc, r.Index + 5, grid.Columns.Count - 6, Color.FromArgb(250, 224, 60), Color.Black)
                    Case 4, 6
                        formatoCeldasValor(exc, r.Index + 5, grid.Columns.Count - 6, Color.FromArgb(233, 40, 65), Color.White)
                    Case Else
                        formatoCeldasValor(exc, r.Index + 5, grid.Columns.Count - 6, Color.FromArgb(255, 125, 30), Color.White)
                End Select
            End If
        Next

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

#Region "INVENTARIOS"

    Public Sub exportarTrabajoProceso(ByVal grid As DataGridView, sCveTra As String, sSocio As String, sGerente As String, sDescripcion As String, iHrs As Integer, dImpBruto As Double, dPor As Double, dImpNeto As Double, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim styleTra, styleDatos, styleTraDatos As New SLStyle

        nombreEmpresa(exc, "A1", "H2")
        nombreReporte(exc, "A3", "H3", "TRABAJO EN PROCESO AL " & dFecha.ToShortDateString)
        'nombreColumnas(exc, grid, 1)
        nombreHoja(exc, sCveTra)

        styleTra.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleTra.Fill.SetPatternForegroundColor(morado_Salles)
        styleTra.SetFontBold(True)
        styleTra.SetFontColor(blanco)
        styleTra.SetFont("Calibri", 14)
        styleTra.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        styleTra.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        styleDatos.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleDatos.Fill.SetPatternForegroundColor(blanco)
        styleDatos.SetFontBold(True)
        styleDatos.SetFontColor(negro)
        styleDatos.SetFont("Calibri", 12)
        styleDatos.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        styleDatos.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        styleTraDatos.Fill.SetPatternType(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid)
        styleTraDatos.Fill.SetPatternForegroundColor(blanco)
        styleTraDatos.SetFontColor(negro)
        styleTraDatos.SetFont("Calibri", 12)
        styleTraDatos.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        styleTraDatos.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)

        exc.MergeWorksheetCells("A4", "H5")
        exc.SetCellValue("A4", sCveTra)
        exc.SetCellStyle("A4", styleTra)

        exc.MergeWorksheetCells("A9", "H9")
        exc.SetCellValue("A9", "")
        exc.SetCellStyle("A9", styleTraDatos)

        exc.MergeWorksheetCells("E7", "H7")
        exc.SetCellValue("E7", "")
        exc.SetCellStyle("E7", styleTraDatos)

        exc.MergeWorksheetCells("B6", "D6")
        exc.MergeWorksheetCells("B7", "D7")
        exc.MergeWorksheetCells("B8", "D8")

        exc.SetCellValue("A6", "Socio / Asociado Coordinador:")
        exc.SetCellStyle("A6", styleDatos)
        exc.SetCellValue("A7", "Gerente:")
        exc.SetCellStyle("A7", styleDatos)
        exc.SetCellValue("A8", "Descripción:")
        exc.SetCellStyle("A8", styleDatos)
        exc.SetCellValue("A9", "")
        exc.SetCellStyle("A9", styleDatos)

        exc.SetCellValue("B6", sSocio)
        exc.SetCellStyle("B6", styleTraDatos)
        exc.SetCellValue("B7", sGerente)
        exc.SetCellStyle("B7", styleTraDatos)
        exc.SetCellValue("B8", sDescripcion)
        exc.SetCellStyle("B8", styleTraDatos)
        exc.SetCellValue("B9", "")
        exc.SetCellStyle("B9", styleTraDatos)

        exc.SetCellValue("E6", "Tiempo estimado:")
        exc.SetCellStyle("E6", styleDatos)
        exc.SetCellValue("G6", "Importe:")
        exc.SetCellStyle("G6", styleDatos)
        exc.SetCellValue("E8", "% Ajuste:")
        exc.SetCellStyle("E8", styleDatos)
        exc.SetCellValue("G8", "Importe Neto:")
        exc.SetCellStyle("G8", styleDatos)

        exc.SetCellValueNumeric("F6", iHrs)
        'exc.SetCellStyle("F6", styleTraDatos)
        formatoCeldasNumero(exc, 1, 6, 6)
        exc.SetCellValueNumeric("H6", dImpBruto)
        formatoCeldasNumero(exc, 2, 6, 8)
        exc.SetCellValue("F8", dPor)
        formatoCeldasNumero(exc, 2, 8, 6)
        exc.SetCellValueNumeric("H8", dImpNeto)
        formatoCeldasNumero(exc, 2, 8, 8)

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 1 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < 5 Then
                            exc.SetCellValue(row.Index + 10, col.Index - 1, row.Cells(col.Index).Value)
                            formatoCeldasTexto(exc, row.Index + 10, col.Index - 1)
                        ElseIf col.Index >= 5 Then
                            If row.Cells(col.Index).Value = "" Or row.Cells(col.Index).Value Is DBNull.Value Then
                                exc.SetCellValue(row.Index + 10, col.Index - 1, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 10, col.Index - 1)
                            Else
                                If row.Cells("TIPO").Value = "S" Or row.Cells("TIPO").Value = "T" Then
                                    If col.Index = 5 Or col.Index = 7 Then
                                        exc.SetCellValueNumeric(row.Index + 10, col.Index - 1, CDbl(row.Cells(col.Index).Value))
                                        formatoCeldasNumero(exc, 1, row.Index + 10, col.Index - 1)
                                    Else
                                        exc.SetCellValueNumeric(row.Index + 10, col.Index - 1, CDbl(row.Cells(col.Index).Value))
                                        formatoCeldasNumero(exc, 2, row.Index + 10, col.Index - 1)
                                    End If
                                Else
                                    exc.SetCellValue(row.Index + 10, col.Index - 1, row.Cells(col.Index).Value)
                                    formatoCeldasTexto(exc, row.Index + 10, col.Index - 1)
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        Next

        nombreColumnasTP(exc, grid, 1)
        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 1 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If row.Cells("TIPO").Value = "T" Then
                            formatoTotal(exc, row.Index + 10, col.Index - 1)
                        ElseIf row.Cells("TIPO").Value = "TO" Or row.Cells("TIPO").Value = "TD" Or row.Cells("TIPO").Value = "TA" Or row.Cells("TIPO").Value = "TS" Then
                            formatoTotalGpo(exc, row.Index + 10, col.Index - 1)
                        End If
                    Next
                End If
            End If
        Next

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", 17)
        exc.SetColumnWidth("C", "H", 22)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub exportarTPSocio(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "F2")
        nombreReporte(exc, "A3", "F3", "RESUMEN DE TRABAJO EN PROCESO AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 1)
        nombreHoja(exc, "Resumen Socio")

        llenarReporteCols(exc, grid, 1, 4)
        mostrarTotal(exc, grid, 1)

        exc.SetColumnWidth("A", 20)
        exc.SetColumnWidth("B", 49)
        exc.SetColumnWidth("C", "F", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarResumenTPSocio(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "E2")
        nombreReporte(exc, "A3", "E3", "RESUMEN DE TRABAJO EN PROCESO AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 5)
        nombreHoja(exc, "Resumen Socio")

        llenarReporteCols(exc, grid, 5, 7)
        mostrarTotal(exc, grid, 5)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "E", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarRevisionAjustesTPSocio(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFechaIni As Date, dFechaFin As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "H2")
        nombreReporte(exc, "A3", "H3", "REVISIÓN DE AJUSTES DE TRABAJO EN PROCESO DEL " & dFechaIni.ToShortDateString & " AL " & dFechaFin.ToShortDateString)
        nombreColumnas(exc, grid, 2)

        nombreHoja(exc, "Ajustes")

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 3 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < 9 Then
                            exc.SetCellValue(row.Index + 5, col.Index - 2, row.Cells(col.Index).Value)
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - 2)
                        ElseIf col.Index >= 9 Then
                            exc.SetCellValueNumeric(row.Index + 5, col.Index - 2, CDbl(row.Cells(col.Index).Value))
                            formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - 2)
                        End If
                    Next
                End If
            End If
        Next

        exc.SetColumnWidth("A", "E", 20)
        exc.SetColumnWidth("F", 49)
        exc.SetColumnWidth("G", "H", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub exportarTrabajos(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "H2")
        nombreReporte(exc, "A3", "H3", "RESUMEN DE CUENTAS POR COBRAR AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Resumen")

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 4 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < 5 Then
                            exc.SetCellValue(row.Index + 5, col.Index - 3, row.Cells(col.Index).Value)
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - 3)
                        ElseIf col.Index >= 5 Then
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - 3, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - 3)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - 3, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - 3)
                            End If
                        End If
                    Next
                End If
            End If
        Next

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "H", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

#End Region

#Region "FACTURACIÓN"

    Public Sub exportarResumenFacturacionv2(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "D2")
        nombreReporte(exc, "A3", "D3", "RESUMEN DE FACTURACIÓN AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Resumen")

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 4 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < 5 Then
                            exc.SetCellValue(row.Index + 5, col.Index - 3, row.Cells(col.Index).Value)
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - 3)
                        ElseIf col.Index >= 5 Then
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - 3, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - 3)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - 3, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - 3)
                            End If
                        End If
                    Next
                End If
            End If
        Next

        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

#End Region

#Region "CUENTAS POR COBRAR"

    Public Sub exportarResumenCuentasPorCobrarv2(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "H2")
        nombreReporte(exc, "A3", "H3", "RESUMEN DE CUENTAS POR COBRAR AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Resumen")

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 4 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < 5 Then
                            exc.SetCellValue(row.Index + 5, col.Index - 3, row.Cells(col.Index).Value)
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - 3)
                        ElseIf col.Index >= 5 Then
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - 3, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - 3)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - 3, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - 3)
                            End If
                        End If
                    Next
                End If
            End If
        Next

        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "H", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarCuentasPorCobrarSocio(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "L2")
        nombreReporte(exc, "A3", "L3", "CUENTAS POR COBRAR DE SOCIO AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 0)

        nombreHoja(exc, "Cuentas por Cobrar")

        exc.Filter("A4", "L4")

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 1 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < 6 Then
                            exc.SetCellValue(row.Index + 5, col.Index, row.Cells(col.Index).Value)
                            formatoCeldasTexto(exc, row.Index + 5, col.Index)
                        ElseIf col.Index >= 6 Then
                            exc.SetCellValueNumeric(row.Index + 5, col.Index, CDbl(row.Cells(col.Index).Value))
                            formatoCeldasNumero(exc, 2, row.Index + 5, col.Index)
                        End If
                    Next
                End If
            End If
        Next

        mostrarTotal(exc, grid, 0)

        exc.SetColumnWidth("A", "B", 10)
        exc.SetColumnWidth("C", 20)
        exc.SetColumnWidth("D", 49)
        exc.SetColumnWidth("E", "L", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub exportarCuentasPorCobrarTrabajo(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "K2")
        nombreReporte(exc, "A3", "K3", "RESUMEN DE CUENTAS POR COBRAR POR TRABAJO AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Cuentas por Cobrar")

        exc.Filter("A4", "K4")

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 3 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < 8 Then
                            exc.SetCellValue(row.Index + 5, col.Index - 3, row.Cells(col.Index).Value)
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - 3)
                        ElseIf col.Index >= 8 Then
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - 3, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - 3)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - 3, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - 3)
                            End If
                        End If
                    Next
                End If
            End If
        Next

        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)
        exc.SetColumnWidth("E", "K", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarCuentasPorCobrarAntiguedad(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "Q2")
        nombreReporte(exc, "A3", "Q3", "RESUMEN DE CUENTAS POR COBRAR POR ANTIGÜEDAD AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 1)

        nombreHoja(exc, "Cuentas por Cobrar")

        exc.Filter("A4", "K4")

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 1 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < 9 Or (col.Index > 16 And col.Index <> 18) Then
                            exc.SetCellValue(row.Index + 5, col.Index - 1, row.Cells(col.Index).Value)
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - 1)
                        ElseIf (col.Index >= 9 And col.Index <= 16) Or col.Index = 18 Then
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - 1, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - 1)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - 1, CDbl(row.Cells(col.Index).Value))
                                If col.Index = 18 Then
                                    formatoCeldasNumero(exc, 1, row.Index + 5, col.Index - 1)
                                Else
                                    formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - 1)
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        Next

        mostrarTotal(exc, grid, 1)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "C", 20)
        exc.SetColumnWidth("D", 49)
        exc.SetColumnWidth("E", "Q", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarCobranzaCuentasPorCobrarSocio(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "J2")
        nombreReporte(exc, "A3", "J3", "RESUMEN DE COBRANZA Y CUENTAS POR COBRAR POR SOCIO AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Cuentas por Cobrar")

        exc.Filter("A4", "K4")

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 3 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index = 4 Or col.Index = 6 Then
                            exc.SetCellValue(row.Index + 5, col.Index - 3, row.Cells(col.Index).Value)
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - 3)
                        ElseIf (col.Index = 5 Or col.Index >= 7) Then
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - 3, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - 3)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - 3, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - 3)
                            End If
                        End If
                    Next
                End If
            End If
        Next

        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", 20)
        exc.SetColumnWidth("C", 2)
        exc.SetColumnWidth("D", "J", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub exportarProgramaCobranzaInd(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== ANÁLISIS ====================
        nombreEmpresa(exc, "A1", "P2")
        nombreReporte(exc, "A3", "P3", "PROGRAMA DE COBRANZA AL DÍA")
        nombreColumnas(exc, grid, 10)

        nombreHoja(exc, "Programa Cobranza")

        llenarReporteTresCol(exc, grid, 10, 15, 26)
        mostrarTotal(exc, grid, 10)

        exc.SetColumnWidth("A", "C", 20)
        exc.SetColumnWidth("D", 49)
        exc.SetColumnWidth("E", "O", 20)
        exc.SetColumnWidth("P", 49)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub exportarResumenProgramaCobranzaDia(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== ANÁLISIS ====================
        nombreEmpresa(exc, "A1", "Y2")
        nombreReporte(exc, "A3", "Y3", "RESUMEN DE PROGRAMA DE COBRANZA AL DÍA")
        nombreColumnas(exc, grid, 5)

        nombreHoja(exc, "Resumen")

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 3 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        If col.Index < 10 Or col.Index > 27 Then
                            exc.SetCellValue(row.Index + 5, col.Index - 5, row.Cells(col.Index).Value)
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - 5)
                        Else
                            If row.Cells(col.Index).Value = "" Then
                                exc.SetCellValue(row.Index + 5, col.Index - 5, row.Cells(col.Index).Value)
                                formatoCeldasTexto(exc, row.Index + 5, col.Index - 5)
                            Else
                                exc.SetCellValueNumeric(row.Index + 5, col.Index - 5, CDbl(row.Cells(col.Index).Value))
                                formatoCeldasNumero(exc, 2, row.Index + 5, col.Index - 5)
                            End If
                        End If
                    Next
                End If
            End If
        Next

        mostrarTotal(exc, grid, 5)

        exc.SetColumnWidth("A", "C", 20)
        exc.SetColumnWidth("D", 49)
        exc.SetColumnWidth("E", "X", 20)
        exc.SetColumnWidth("Y", 49)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

#End Region

#Region "ASIGNACIONES"

    Public Sub exportarCuadroAsignacionesDetalle(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== ANÁLISIS ====================
        nombreEmpresa(exc, "A1", "G2")
        nombreReporte(exc, "A3", "G3", "CUADRO DE ASIGNACIONES - DETALLE")
        nombreColumnas(exc, grid, 1)

        nombreHoja(exc, "Detalle")
        llenarReporte(exc, grid, 1, 0)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "G", 35)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

#End Region

#Region "INDUSTRIAS"

    Public Sub exportarIngresosIndustria(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== RESUMEN ====================
        nombreEmpresa(exc, "A1", "Z2")
        nombreReporte(exc, "A3", "Z3", "INGRESOS POR INDUSTRIA AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 4)

        nombreHoja(exc, "Ingresos")
        llenarReporteCols(exc, grid, 4, 18)
        mostrarTotal(exc, grid, 4)

        exc.SetColumnWidth("A", 20)
        exc.SetColumnWidth("B", 49)
        exc.SetColumnWidth("C", 25)
        exc.SetColumnWidth("D", 49)
        exc.SetColumnWidth("E", "G", 25)
        exc.SetColumnWidth("H", 49)
        exc.SetColumnWidth("I", 20)
        exc.SetColumnWidth("J", 49)
        exc.SetColumnWidth("K", 20)
        exc.SetColumnWidth("L", "M", 49)
        exc.SetColumnWidth("N", "Z", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

#End Region

#Region "PRESUPUESTOS"

    Public Sub exportarPresupuestoIngresos(ByVal tabs As TabControl, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== OFICINAS ====================
        ObtenerGridTab(tabs, 0)

        nombreEmpresa(exc, "A1", "ES2")
        nombreReporte(exc, "A3", "ES3", "REVISIÓN DE PRESUPUESTO DE INGRESOS - OFICINAS")
        nombreColumnas(exc, grid, 0)

        nombreHoja(exc, "Oficinas")
        llenarReportePpto(exc, grid, 0, 2, 116)
        mostrarTotal(exc, grid, 0)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", 3)
        exc.SetColumnWidth("C", "AC", 20)
        exc.SetColumnWidth("AD", 3)
        exc.SetColumnWidth("AE", "BE", 20)
        exc.SetColumnWidth("BF", 3)
        exc.SetColumnWidth("BG", "CG", 20)
        exc.SetColumnWidth("CH", 3)
        exc.SetColumnWidth("CI", "DI", 20)
        exc.SetColumnWidth("DJ", 3)
        exc.SetColumnWidth("DK", "DN", 20)
        exc.SetColumnWidth("DO", 3)
        exc.SetColumnWidth("DP", "DQ", 20)
        exc.SetColumnWidth("DR", 3)
        exc.SetColumnWidth("DS", "ES", 20)

        '==================== DIVISIONES ====================
        ObtenerGridTab(tabs, 1)
        exc.AddWorksheet("Divisiones")

        nombreEmpresa(exc, "A1", "ES2")
        nombreReporte(exc, "A3", "ES3", "REVISIÓN DE PRESUPUESTO DE INGRESOS - DIVISIONES")
        nombreColumnas(exc, grid, 0)
        llenarReportePpto(exc, grid, 0, 2, 116)
        mostrarTotal(exc, grid, 0)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", 3)
        exc.SetColumnWidth("C", "AC", 20)
        exc.SetColumnWidth("AD", 3)
        exc.SetColumnWidth("AE", "BE", 20)
        exc.SetColumnWidth("BF", 3)
        exc.SetColumnWidth("BG", "CG", 20)
        exc.SetColumnWidth("CH", 3)
        exc.SetColumnWidth("CI", "DI", 20)
        exc.SetColumnWidth("DJ", 3)
        exc.SetColumnWidth("DK", "DN", 20)
        exc.SetColumnWidth("DO", 3)
        exc.SetColumnWidth("DP", "DQ", 20)
        exc.SetColumnWidth("DR", 3)
        exc.SetColumnWidth("DS", "ES", 20)

        '==================== SOCIOS ====================
        ObtenerGridTab(tabs, 2)
        exc.AddWorksheet("Socios")

        nombreEmpresa(exc, "A1", "ES2")
        nombreReporte(exc, "A3", "ES3", "REVISIÓN DE PRESUPUESTO DE INGRESOS - SOCIOS")
        nombreColumnas(exc, grid, 0)
        llenarReportePpto(exc, grid, 0, 2, 116)
        mostrarTotal(exc, grid, 0)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", 3)
        exc.SetColumnWidth("C", "AC", 20)
        exc.SetColumnWidth("AD", 3)
        exc.SetColumnWidth("AE", "BE", 20)
        exc.SetColumnWidth("BF", 3)
        exc.SetColumnWidth("BG", "CG", 20)
        exc.SetColumnWidth("CH", 3)
        exc.SetColumnWidth("CI", "DI", 20)
        exc.SetColumnWidth("DJ", 3)
        exc.SetColumnWidth("DK", "DN", 20)
        exc.SetColumnWidth("DO", 3)
        exc.SetColumnWidth("DP", "DQ", 20)
        exc.SetColumnWidth("DR", 3)
        exc.SetColumnWidth("DS", "ES", 20)

        '==================== TRABAJOS ====================
        ObtenerGridTab(tabs, 3)
        exc.AddWorksheet("Trabajos")

        nombreEmpresa(exc, "A1", "ET2")
        nombreReporte(exc, "A3", "ET3", "REVISIÓN DE PRESUPUESTO DE INGRESOS - TRABAJOS")
        nombreColumnas(exc, grid, 1)
        llenarReportePpto(exc, grid, 1, 4, 118)
        mostrarTotal(exc, grid, 1)

        exc.SetColumnWidth("A", 20)
        exc.SetColumnWidth("B", 49)
        exc.SetColumnWidth("C", 3)
        exc.SetColumnWidth("D", "AD", 20)
        exc.SetColumnWidth("AE", 3)
        exc.SetColumnWidth("AF", "BF", 20)
        exc.SetColumnWidth("BG", 3)
        exc.SetColumnWidth("BH", "CH", 20)
        exc.SetColumnWidth("CI", 3)
        exc.SetColumnWidth("CJ", "DJ", 20)
        exc.SetColumnWidth("DK", 3)
        exc.SetColumnWidth("DL", "DO", 20)
        exc.SetColumnWidth("DP", 3)
        exc.SetColumnWidth("DQ", "DR", 20)
        exc.SetColumnWidth("DS", 3)
        exc.SetColumnWidth("DT", "ET", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarGastosAdministracionAA(ByVal tabs As TabControl, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== RESUMEN ====================
        ObtenerGridTab(tabs, 0)

        nombreEmpresa(exc, "A1", "N2")
        nombreReporte(exc, "A3", "N3", "OTROS GASTOS DE ADMINISTRACIÓN - RESUMEN")
        nombreColumnas(exc, grid, 2)

        nombreHoja(exc, "Resumen")
        llenarReporteCols(exc, grid, 2, 4)
        mostrarTotal(exc, grid, 2)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "N", 20)

        '==================== CUENTAS ====================
        ObtenerGridTab(tabs, 1)
        exc.AddWorksheet("Cuentas")

        nombreEmpresa(exc, "A1", "P2")
        nombreReporte(exc, "A3", "P3", "OTROS GASTOS DE ADMINISTRACIÓN - CUENTAS")
        nombreColumnas(exc, grid, 3)
        llenarReporteCols(exc, grid, 3, 7)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", "B", 30)
        exc.SetColumnWidth("C", 49)
        exc.SetColumnWidth("D", "P", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarResumenGastosAdministracionAA(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== RESUMEN ====================
        nombreEmpresa(exc, "A1", "L2")
        nombreReporte(exc, "A3", "L3", "RESUMEN OTROS GASTOS DE ADMINISTRACIÓN")
        nombreColumnas(exc, grid, 1)

        nombreHoja(exc, "Resumen")
        llenarReporteCols(exc, grid, 1, 4)
        mostrarTotal(exc, grid, 1)

        exc.SetColumnWidth("A", 30)
        exc.SetColumnWidth("B", 49)
        exc.SetColumnWidth("C", "L", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

#End Region

#Region "REPORTES"

    Public Sub exportarResumenProgramaCobranzaDia(ByVal tabs As TabControl, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== OFICINAS ====================
        ObtenerGridTab(tabs, 0)

        nombreEmpresa(exc, "A1", "U2")
        nombreReporte(exc, "A3", "U3", "RESUMEN DE PROGRAMA DE COBRANZA AL DÍA - OFICINAS AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 1)

        nombreHoja(exc, "Oficinas")
        llenarReporteDosColv2(exc, grid, 1, 3, 20)
        mostrarTotal(exc, grid, 1)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "U", 20)

        '==================== DIVISIONES ====================
        ObtenerGridTab(tabs, 1)
        exc.AddWorksheet("Divisiones")

        nombreEmpresa(exc, "A1", "U2")
        nombreReporte(exc, "A3", "U3", "RESUMEN DE PROGRAMA DE COBRANZA AL DÍA - DIVISIONES AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 2)

        llenarReporteDosColv2(exc, grid, 2, 4, 21)
        mostrarTotal(exc, grid, 2)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "U", 20)

        '==================== SOCIOS ====================
        ObtenerGridTab(tabs, 2)
        exc.AddWorksheet("Socios")

        nombreEmpresa(exc, "A1", "U2")
        nombreReporte(exc, "A3", "U3", "RESUMEN DE PROGRAMA DE COBRANZA AL DÍA - SOCIOS AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 3)

        llenarReporteDosColv2(exc, grid, 3, 5, 22)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "U", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarResumenProgramaCobranzaDiaSocio(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, ByVal sNombre As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== RESUMEN ====================
        nombreEmpresa(exc, "A1", "AA2")
        nombreReporte(exc, "A3", "AA3", "RESUMEN DE PROGRAMA DE COBRANZA AL DÍA - " & sNombre)

        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Programa Cobranza")
        llenarReporteDosColv2(exc, grid, 3, 10, 27)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", "E", 20)
        exc.SetColumnWidth("F", 49)
        exc.SetColumnWidth("G", "Z", 20)
        exc.SetColumnWidth("AA", 49)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub exportarResumenHorasCategoria(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== RESUMEN ====================
        nombreEmpresa(exc, "A1", "AN2")
        nombreReporte(exc, "A3", "AN3", "RESUMEN DE HORAS POR CATEGORÍA AL " & dFecha.ToShortDateString)

        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Horas Categoría")
        llenarReporteCols(exc, grid, 3, 5)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "AN", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarTrabajosAperturadosSocio(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== RESUMEN ====================
        nombreEmpresa(exc, "A1", "X2")
        nombreReporte(exc, "A3", "X3", "TRABAJOS APERTURADOS POR SOCIO AL " & dFecha.ToShortDateString)

        nombreColumnas(exc, grid, 0)

        nombreHoja(exc, "Trabajos")
        llenarReporteCols(exc, grid, 0, 7)
        mostrarTotal(exc, grid, 0)

        exc.SetColumnWidth("A", 20)
        exc.SetColumnWidth("B", 20)
        exc.SetColumnWidth("C", "D", 49)
        exc.SetColumnWidth("E", 20)
        exc.SetColumnWidth("F", 40)
        exc.SetColumnWidth("G", "X", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

#End Region

#Region "REPORTES CONTROL DE GESTIÓN"

    Public Sub exportarIngresosPorConseguirv2(ByVal tabs As TabControl, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== RESUMEN ====================
        ObtenerGridTab(tabs, 0)

        nombreEmpresa(exc, "A1", "D2")
        nombreReporte(exc, "A3", "D3", "INGRESOS POR CONSEGUIR AL " & dFecha.ToShortDateString & " - RESUMEN")
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Resumen")
        llenarReporteCols(exc, grid, 3, 5)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)

        '==================== DETALLE ====================
        ObtenerGridTab(tabs, 1)
        exc.AddWorksheet("Detalle")

        nombreEmpresa(exc, "A1", "F2")
        nombreReporte(exc, "A3", "F3", "INGRESOS POR CONSEGUIR AL " & dFecha.ToShortDateString & " - DETALLE")
        nombreColumnas(exc, grid, 3)

        llenarReporteCols(exc, grid, 3, 7)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", 30)
        exc.SetColumnWidth("C", 49)
        exc.SetColumnWidth("D", "F", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarIngPptoIngFact(ByVal tabs As TabControl, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== RESUMEN ====================
        ObtenerGridTab(tabs, 0)

        nombreEmpresa(exc, 1, 1, 2, grid.Columns.Count - 4)
        nombreReporte(exc, 3, 1, 3, grid.Columns.Count - 4, "INGRESOS PPTO. VS INGRESOS FACTURADOS AL " & dFecha.ToShortDateString & " - RESUMEN")

        'nombreEmpresa(exc, "A1", "D2")
        'nombreReporte(exc, "A3", "D3", )
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Resumen")
        llenarReporteCols(exc, grid, 3, 5)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth(2, grid.Columns.Count - 3, 20)

        '==================== DETALLE ====================
        ObtenerGridTab(tabs, 1)
        exc.AddWorksheet("Detalle")

        nombreEmpresa(exc, 1, 1, 2, grid.Columns.Count - 4)
        nombreReporte(exc, 3, 1, 3, grid.Columns.Count - 4, "INGRESOS PPTO. VS INGRESOS FACTURADOS AL " & dFecha.ToShortDateString & " - DETALLE")

        'nombreEmpresa(exc, "A1", "F2")
        'nombreReporte(exc, "A3", "F3", )
        nombreColumnas(exc, grid, 3)

        llenarReporteCols(exc, grid, 3, 7)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", 30)
        exc.SetColumnWidth("C", 49)
        exc.SetColumnWidth(4, grid.Columns.Count - 3, 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarIngPptoIngIncurrido(ByVal tabs As TabControl, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== RESUMEN ====================
        ObtenerGridTab(tabs, 0)

        nombreEmpresa(exc, 1, 1, 2, grid.Columns.Count - 4)
        nombreReporte(exc, 3, 1, 3, grid.Columns.Count - 4, "INGRESOS PPTO. VS INGRESOS INCURRIDOS AL " & dFecha.ToShortDateString & " - RESUMEN")

        'nombreEmpresa(exc, "A1", "D2")
        'nombreReporte(exc, "A3", "D3", )
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Resumen")
        llenarReporteCols(exc, grid, 3, 5)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth(2, grid.Columns.Count - 3, 20)

        '==================== DETALLE ====================
        ObtenerGridTab(tabs, 1)
        exc.AddWorksheet("Detalle")

        nombreEmpresa(exc, 1, 1, 2, grid.Columns.Count - 4)
        nombreReporte(exc, 3, 1, 3, grid.Columns.Count - 4, "INGRESOS PPTO. VS INGRESOS INCURRIDOS AL " & dFecha.ToShortDateString & " - DETALLE")

        'nombreEmpresa(exc, "A1", "F2")
        'nombreReporte(exc, "A3", "F3", )
        nombreColumnas(exc, grid, 3)

        llenarReporteCols(exc, grid, 3, 7)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", 30)
        exc.SetColumnWidth("C", 49)
        exc.SetColumnWidth(4, grid.Columns.Count - 3, 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub exportarResumenIngPptoIngRealesInc(ByVal tabs As TabControl, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== RESUMEN ====================
        ObtenerGridTab(tabs, 0)

        nombreEmpresa(exc, "A1", "G2")
        nombreReporte(exc, "A3", "G3", "RESUMEN INGRESOS PRESUPUESTO VS INGRESOS REALES INCURRIDOS - RESUMEN")
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Resumen")
        llenarReporteCols(exc, grid, 3, 5)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "G", 20)

        '==================== DETALLE ====================
        ObtenerGridTab(tabs, 1)
        exc.AddWorksheet("Detalle")

        nombreEmpresa(exc, "A1", "I2")
        nombreReporte(exc, "A3", "I3", "RESUMEN INGRESOS PRESUPUESTO VS INGRESOS REALES INCURRIDOS - RESUMEN")
        nombreColumnas(exc, grid, 3)

        llenarReporteCols(exc, grid, 3, 7)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", 30)
        exc.SetColumnWidth("C", 49)
        exc.SetColumnWidth("D", "I", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarResumenHrsPptoHrsRealesInc(ByVal tabs As TabControl, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== RESUMEN ====================
        ObtenerGridTab(tabs, 0)

        nombreEmpresa(exc, "A1", "M2")
        nombreReporte(exc, "A3", "M3", "RESUMEN HORAS PRESUPUESTO VS HORAS REALES INCURRIDAS - RESUMEN")
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Resumen")
        llenarReporteCols(exc, grid, 3, 5)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "M", 20)

        '==================== DETALLE ====================
        ObtenerGridTab(tabs, 1)
        exc.AddWorksheet("Detalle")

        nombreEmpresa(exc, "A1", "O2")
        nombreReporte(exc, "A3", "O3", "RESUMEN HORAS PRESUPUESTO VS HORAS REALES INCURRIDAS - DETALLE")
        nombreColumnas(exc, grid, 3)

        llenarReporteCols(exc, grid, 3, 7)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", 30)
        exc.SetColumnWidth("C", 49)
        exc.SetColumnWidth("D", "O", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

#End Region

#Region "REPORTES DE LA DIRECCIÓN"

    Public Sub exportarIngresosPptoRealv2(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== ANÁLISIS ====================
        nombreEmpresa(exc, "A1", "J2")
        nombreReporte(exc, "A3", "J3", "INGRESOS PRESUPUESTADOS VS REALESS.")
        nombreColumnas(exc, grid, 1)

        nombreHoja(exc, "Ingresos")
        llenarReporteCols(exc, grid, 1, 3)
        mostrarTotal(exc, grid, 1)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "J", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarAnalisisHorasPpto(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== ANÁLISIS ====================
        nombreEmpresa(exc, "A1", "J2")
        nombreReporte(exc, "A3", "J3", "ANÁLISIS DE HORAS CARGABLES DE PPTO.")
        nombreColumnas(exc, grid, 2)

        nombreHoja(exc, "Horas Ppto.")
        llenarReporteCols(exc, grid, 2, 4)
        mostrarTotal(exc, grid, 2)

        exc.SetColumnWidth("A", 30)
        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "E", 20)
        exc.SetColumnWidth("F", 2)
        exc.SetColumnWidth("G", "J", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarCxcGrupo(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== ANÁLISIS ====================
        nombreEmpresa(exc, "A1", "J2")
        nombreReporte(exc, "A3", "J3", "CUENTAS POR COBRAR POR GRUPO AL " & dFecha)
        nombreColumnas(exc, grid, 1)

        nombreHoja(exc, "CxC Grupo")
        llenarReporteCols(exc, grid, 1, 5)
        mostrarTotal(exc, grid, 1)

        exc.SetColumnWidth("A", 25)
        exc.SetColumnWidth("B", "C", 49)
        exc.SetColumnWidth("D", "J", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarCxcClientes(ByVal tabs As TabControl, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== SOCIOS ====================
        ObtenerGridTab(tabs, 0)

        nombreEmpresa(exc, "A1", "I2")
        nombreReporte(exc, "A3", "I3", "CUENTAS POR COBRAR POR CLIENTE AL " & dFecha.ToShortDateString & " - SOCIOS")
        nombreColumnas(exc, grid, 1)
        llenarReporteCols(exc, grid, 1, 3)
        mostrarTotal(exc, grid, 1)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "I", 20)

        nombreHoja(exc, "Socios")

        '==================== CLIENTES ====================
        ObtenerGridTab(tabs, 1)
        exc.AddWorksheet("Clientes")

        nombreEmpresa(exc, "A1", "K2")
        nombreReporte(exc, "A3", "K3", "CUENTAS POR COBRAR POR CLIENTE AL " & dFecha.ToShortDateString & " - CLIENTES")
        nombreColumnas(exc, grid, 1)
        llenarReporteCols(exc, grid, 1, 5)
        mostrarTotal(exc, grid, 1)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", 30)
        exc.SetColumnWidth("C", 49)
        exc.SetColumnWidth("D", "K", 20)

        '==================== DETALLE ====================
        ObtenerGridTab(tabs, 2)
        exc.AddWorksheet("Detalle")

        nombreEmpresa(exc, "A1", "O2")
        nombreReporte(exc, "A3", "O3", "CUENTAS POR COBRAR POR CLIENTE AL " & dFecha.ToShortDateString & " - DETALLE")
        nombreColumnas(exc, grid, 0)
        llenarReporteCols(exc, grid, 0, 8)
        mostrarTotal(exc, grid, 0)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "C", 30)
        exc.SetColumnWidth("D", 49)
        exc.SetColumnWidth("E", "G", 25)
        exc.SetColumnWidth("H", "O", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarCxcGerente(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== ANÁLISIS ====================
        nombreEmpresa(exc, "A1", "H2")
        nombreReporte(exc, "A3", "H3", "CUENTAS POR COBRAR POR GERENTE AL " & dFecha)
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "CxC Gerente")
        llenarReporteCols(exc, grid, 3, 5)
        mostrarTotal(exc, grid, 3)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "H", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarClientesSociov2(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== ANÁLISIS ====================
        nombreEmpresa(exc, "A1", "I2")
        nombreReporte(exc, "A3", "I3", "CLIENTES POR SOCIO.")
        nombreColumnas(exc, grid, 6)

        nombreHoja(exc, "Clientes")
        llenarReporteCols(exc, grid, 6, 16)
        mostrarTotal(exc, grid, 6)

        exc.SetColumnWidth("A", "B", 15)
        exc.SetColumnWidth("C", 49)
        exc.SetColumnWidth("D", "E", 15)
        exc.SetColumnWidth("F", "I", 49)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub exportarDiasRotacion(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument
        Dim ind As Integer = 0

        '==================== RESUMEN ====================
        nombreEmpresa(exc, 1, 1, 2, grid.Columns.Count - 5)
        nombreReporte(exc, 3, 1, 3, grid.Columns.Count - 5, "DÍAS DE ROTACIÓN AL " & dFecha.ToShortDateString & " - RESUMEN")

        nombreColumnas(exc, grid, 4)

        nombreHoja(exc, "Días Rotación")
        llenarReportePpto(exc, grid, 4, 6, grid.Columns.Count - 3)
        mostrarTotal(exc, grid, 4)

        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth(2, grid.Columns.Count - 3, 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

#End Region

#Region "OBJETIVOS"

    Public Sub exportarObjetivosGerentesv2(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "Q2")
        nombreReporte(exc, "A3", "Q3", "OBJETIVOS GENERALES DE GERENTES AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Objetivos Gerentes")

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 3 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        'If col.Index < 9 Then
                        exc.SetCellValue(row.Index + 5, col.Index - 3, row.Cells(col.Index).Value)
                        formatoCeldasTexto(exc, row.Index + 5, col.Index - 3)
                        'End If
                    Next
                End If
            End If
        Next

        exc.SetRowHeight(4, 45)


        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "E", 20)
        exc.SetColumnWidth("F", "Q", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarObjetivosStaff(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "N2")
        nombreReporte(exc, "A3", "N3", "OBJETIVOS GENERALES DE STAFF AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 3)

        nombreHoja(exc, "Objetivos Staff")

        For Each col As DataGridViewColumn In grid.Columns
            If col.Index >= 3 Then
                If col.Visible Then
                    For Each row As DataGridViewRow In grid.Rows
                        'If col.Index < 9 Then
                        exc.SetCellValue(row.Index + 5, col.Index - 3, row.Cells(col.Index).Value)
                            formatoCeldasTexto(exc, row.Index + 5, col.Index - 3)
                        'End If
                    Next
                End If
            End If
        Next

        exc.SetRowHeight(4, 45)


        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "E", 20)
        exc.SetColumnWidth("F", "N", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

#End Region

#Region "EE.FF."

    Public Sub exportarEEFFPrestamos(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "D2")
        nombreReporte(exc, "A3", "D3", "PRÉSTAMOS AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 2)

        nombreHoja(exc, "Préstamos")
        llenarReporteCols(exc, grid, 2, 6)
        mostrarTotal(exc, grid, 2)

        exc.SetRowHeight(4, 25)
        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarEEFFAnticipos(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "D2")
        nombreReporte(exc, "A3", "D3", "ANTICIPOS AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 2)

        nombreHoja(exc, "Anticipos")
        llenarReporteCols(exc, grid, 2, 6)
        mostrarTotal(exc, grid, 2)

        exc.SetRowHeight(4, 25)
        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "D", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarEEFFGastosFirma(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "K2")
        nombreReporte(exc, "A3", "K3", "GASTOS DE LA FIRMA AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 0)

        nombreHoja(exc, "Gastos Firma")
        llenarReporteCols(exc, grid, 0, 3)
        mostrarTotal(exc, grid, 0)

        exc.SetRowHeight(4, 30)
        exc.SetColumnWidth("A", 30)
        exc.SetColumnWidth("B", 49)
        exc.SetColumnWidth("C", "K", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarEEFFHonorariosNetos(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "BI2")
        nombreReporte(exc, "A3", "BI3", "HONORARIOS NETOS AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 0)

        nombreHoja(exc, "Honorarios Netos")
        llenarReporteCols(exc, grid, 0, 2)
        mostrarTotal(exc, grid, 0)

        exc.SetRowHeight(4, 30)
        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "BI", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub exportarEEFFGastosSocios(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "BP2")
        nombreReporte(exc, "A3", "BP3", "GASTOS DE SOCIOS AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 1)

        nombreHoja(exc, "Gastos Socios")
        llenarReporteCols(exc, grid, 1, 3)
        mostrarTotal(exc, grid, 1)

        exc.SetRowHeight(4, 25)
        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "BP", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarEEFFAnalisisGastos(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "AZ2")
        nombreReporte(exc, "A3", "AZ3", "ANÁLISIS DE GASTOS AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 2)

        nombreHoja(exc, "Análisis Gastos")
        llenarReporteCols(exc, grid, 2, 4)
        mostrarTotal(exc, grid, 2)

        exc.SetRowHeight(4, 30)
        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "AZ", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub

    Public Sub exportarEEFFAreasAdministrativas(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, "A1", "J2")
        nombreReporte(exc, "A3", "J3", "OTROS GASTOS DE ADMINISTRACIÓN AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 1)

        nombreHoja(exc, "Gastos Socios")
        llenarReporteCuatroCol(exc, grid, 1, 3, 8, 11)
        mostrarTotal(exc, grid, 1)

        exc.SetRowHeight(4, 25)
        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth("B", "J", 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
        MsgBox("La información se ha exportado correctamente.", MsgBoxStyle.Information, "SIAT")
    End Sub
    Public Sub exportarEEFFIntereses(ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String, dFecha As Date)
        Dim exc As New SLDocument

        nombreEmpresa(exc, 1, 1, 2, grid.Columns.Count - 3)
        nombreReporte(exc, 3, 1, 3, grid.Columns.Count - 3, "INTERESES AL " & dFecha.ToShortDateString)
        nombreColumnas(exc, grid, 2)

        nombreHoja(exc, "Intereses")
        llenarReporteCols(exc, grid, 2, 4)
        mostrarTotal(exc, grid, 2)

        exc.SetRowHeight(4, 25)
        exc.SetColumnWidth("A", 49)
        exc.SetColumnWidth(2, grid.Columns.Count - 3, 20)

        exc.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
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