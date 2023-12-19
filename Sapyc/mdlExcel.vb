Imports Microsoft.Office.Interop
Module mdlExcel


    Public objExcel As Excel.Application = Nothing

    Private objLibroExcel As Excel.Workbook = Nothing
    Private objHojaExcel As Excel.Worksheet = Nothing
    Private objCelda, objCelda2 As Excel.Range

    Private mDatosH(,) As String
    Private mCxC(,) As Object

    Private sEmpresa As String = "SALLES SAINZ, GRANT THORNTON S.C."

    Private iAux As Integer = 0


    Public Sub exportarTrabajos(ByVal objExcel As Excel.Application, ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Try
            If objExcel Is Nothing Then
                objExcel = New Excel.Application
                objLibroExcel = objExcel.Workbooks.Add()
            End If

            ReDim mDatosH(1, grid.Columns.Count)
            ReDim mCxC(grid.Rows.Count, grid.Columns.Count)

            objHojaExcel = objLibroExcel.Sheets(1)

            With objHojaExcel
                .Name = "Trabajos por cliente"

                .Application.ActiveWindow.SplitRow = 4
                .Application.ActiveWindow.FreezePanes = True

                .Shapes.AddPicture("\\GTMEXVTS32\APLICA\CON2012\IMG\header_RD.jpg", False, True, 40, 5, -1, -1)
                .Visible = Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
            End With

            objCelda = objHojaExcel.Range("A1:K2")
            objCelda.Rows.RowHeight = 30

            objCelda = objHojaExcel.Range("A4:K4")
            objCelda.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(79, 45, 127))
            objCelda.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255))
            objCelda.WrapText = True
            objCelda.Rows.RowHeight = 30
            objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            objCelda.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            For x As Integer = 0 To grid.Rows.Count - 1
                If x Mod 2 = 0 Then
                    objCelda = objHojaExcel.Range("A" & x + 5 & ":K" & x + 5)
                    objCelda.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Transparent)
                Else
                    objCelda = objHojaExcel.Range("A" & x + 5 & ":K" & x + 5)
                    objCelda.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(227, 231, 237))
                End If
            Next

            nombreReporte(objCelda, "CLIENTES POR TRABAJOS", "A3", grid.Columns.Count)
            objCelda = objHojaExcel.Range("A5")
            objCelda.Columns.ColumnWidth = 15
            objCelda = objHojaExcel.Range("B5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("C5")
            objCelda.Columns.ColumnWidth = 15
            objCelda = objHojaExcel.Range("D5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("E5")
            objCelda.Columns.ColumnWidth = 30
            objCelda = objHojaExcel.Range("F5")
            objCelda.Columns.ColumnWidth = 45
            objCelda = objHojaExcel.Range("G5")
            objCelda.Columns.ColumnWidth = 15
            objCelda = objHojaExcel.Range("H5")
            objCelda.Columns.ColumnWidth = 15
            objCelda = objHojaExcel.Range("I5")
            objCelda.Columns.ColumnWidth = 85

            objCelda = objHojaExcel.Range("J5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("K5")

            objCelda = objHojaExcel.Range("A1").Resize(2, grid.Columns.Count)
            contenidoReporte(objCelda, grid, 0, mDatosH, mCxC)

            objCelda.MergeCells = True
            objCelda.Value = sEmpresa
            objCelda.Font.Bold = True
            objCelda.Font.Size = 24
            objCelda.HorizontalAlignment = -4108
            objCelda.VerticalAlignment = -4108

            objLibroExcel.Worksheets(1).Activate()

            objHojaExcel.Range("A4", "K4").AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, True)

            objExcel.Cursor = Excel.XlMousePointer.xlDefault
            objExcel.ActiveWorkbook.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
            objHojaExcel = Nothing
            objLibroExcel.Close(False)
            objLibroExcel = Nothing

            objExcel.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
            objExcel = Nothing

            MsgBox("El reporte se guardó correctamente en " & sRutaArchivo & ".", MsgBoxStyle.Information, "Reporte Generado")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub exportarCtes(ByVal objExcel As Excel.Application, ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Try
            If objExcel Is Nothing Then
                objExcel = New Excel.Application
                objLibroExcel = objExcel.Workbooks.Add()
            End If

            ReDim mDatosH(1, grid.Columns.Count)
            ReDim mCxC(grid.Rows.Count, grid.Columns.Count)

            objHojaExcel = objLibroExcel.Sheets(1)

            With objHojaExcel
                .Name = "CLIENTES"

                .Application.ActiveWindow.SplitRow = 4
                .Application.ActiveWindow.FreezePanes = True

                .Shapes.AddPicture("\\GTMEXVTS32\APLICA\CON2012\IMG\header_RD.jpg", False, True, 40, 5, -1, -1)
                .Visible = Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
            End With

            objCelda = objHojaExcel.Range("A1:T2")
            objCelda.Rows.RowHeight = 30

            objCelda = objHojaExcel.Range("A4:T4")
            objCelda.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(79, 45, 127))
            objCelda.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255))
            objCelda.WrapText = True
            objCelda.Rows.RowHeight = 30
            objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            objCelda.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            For x As Integer = 0 To grid.Rows.Count - 1
                If x Mod 2 = 0 Then
                    objCelda = objHojaExcel.Range("A" & x + 5 & ":T" & x + 5)
                    objCelda.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Transparent)
                Else
                    objCelda = objHojaExcel.Range("A" & x + 5 & ":T" & x + 5)
                    objCelda.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(227, 231, 237))
                End If
            Next

            nombreReporte(objCelda, "LISTA DE CLIENTES", "A3", grid.Columns.Count)
            objCelda = objHojaExcel.Range("A5")
            objCelda.Columns.ColumnWidth = 15
            objCelda = objHojaExcel.Range("B5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("C5")
            objCelda.Columns.ColumnWidth = 15
            objCelda = objHojaExcel.Range("D5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("E5")
            objCelda.Columns.ColumnWidth = 30
            objCelda = objHojaExcel.Range("F5")
            objCelda.Columns.ColumnWidth = 45
            objCelda = objHojaExcel.Range("G5")
            objCelda.Columns.ColumnWidth = 15
            objCelda = objHojaExcel.Range("H5")
            objCelda.Columns.ColumnWidth = 15
            objCelda = objHojaExcel.Range("I5")
            objCelda.Columns.ColumnWidth = 85

            objCelda = objHojaExcel.Range("J5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("K5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("L5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("M5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("N5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("O5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("P5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("Q5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("R5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("S5")
            objCelda.Columns.ColumnWidth = 85
            objCelda = objHojaExcel.Range("T5")
            objCelda.Columns.ColumnWidth = 85




            objCelda = objHojaExcel.Range("A1").Resize(2, grid.Columns.Count)
            contenidoReporte(objCelda, grid, 0, mDatosH, mCxC)

            objCelda.MergeCells = True
            objCelda.Value = sEmpresa
            objCelda.Font.Bold = True
            objCelda.Font.Size = 24
            objCelda.HorizontalAlignment = -4108
            objCelda.VerticalAlignment = -4108

            objLibroExcel.Worksheets(1).Activate()

            objHojaExcel.Range("A4", "T4").AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, True)

            objExcel.Cursor = Excel.XlMousePointer.xlDefault
            objExcel.ActiveWorkbook.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
            objHojaExcel = Nothing
            objLibroExcel.Close(False)
            objLibroExcel = Nothing

            objExcel.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
            objExcel = Nothing

            MsgBox("El reporte se guardó correctamente en " & sRutaArchivo & ".", MsgBoxStyle.Information, "Reporte Generado")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub exportarFolios(ByVal objExcel As Excel.Application, ByVal grid As DataGridView, ByVal sRutaArchivo As String, ByVal sNombreArchivo As String)
        Try
            If objExcel Is Nothing Then
                objExcel = New Excel.Application
                objLibroExcel = objExcel.Workbooks.Add()
            End If

            ReDim mDatosH(1, grid.Columns.Count)
            ReDim mCxC(grid.Rows.Count, grid.Columns.Count)

            objHojaExcel = objLibroExcel.Sheets(1)

            With objHojaExcel
                .Name = "FOLIOS"

                .Application.ActiveWindow.SplitRow = 4
                .Application.ActiveWindow.FreezePanes = True

                .Shapes.AddPicture("\\GTMEXVTS32\APLICA\CON2012\IMG\header_RD.jpg", False, True, 40, 5, -1, -1)
                .Visible = Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
            End With

            objCelda = objHojaExcel.Range("A1:W2")
            objCelda.Rows.RowHeight = 30

            objCelda = objHojaExcel.Range("A4:W4")
            objCelda.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(79, 45, 127))
            objCelda.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255))
            objCelda.WrapText = True
            objCelda.Rows.RowHeight = 30
            objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            objCelda.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            For x As Integer = 0 To grid.Rows.Count - 1
                If x Mod 2 = 0 Then
                    objCelda = objHojaExcel.Range("A" & x + 23 & ":W" & x + 23)
                    objCelda.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Transparent)
                Else
                    objCelda = objHojaExcel.Range("A" & x + 23 & ":W" & x + 23)
                    objCelda.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(227, 231, 237))
                End If
            Next

            nombreReporte(objCelda, "FOLIOS", "A3", grid.Columns.Count)
            objCelda = objHojaExcel.Range("A5")
            objCelda.Columns.ColumnWidth = 25
            objCelda = objHojaExcel.Range("B5")
            objCelda.Columns.ColumnWidth = 100
            objCelda = objHojaExcel.Range("C5")
            objCelda.Columns.ColumnWidth = 45
            objCelda = objHojaExcel.Range("D5")
            objCelda.Columns.ColumnWidth = 45
            objCelda = objHojaExcel.Range("E5")
            objCelda.Columns.ColumnWidth = 40
            objCelda = objHojaExcel.Range("F5")
            objCelda.Columns.ColumnWidth = 40
            objCelda = objHojaExcel.Range("G5")
            objCelda.Columns.ColumnWidth = 40
            objCelda = objHojaExcel.Range("H5")
            objCelda.Columns.ColumnWidth = 60
            objCelda = objHojaExcel.Range("I5")
            objCelda.Columns.ColumnWidth = 40
            objCelda = objHojaExcel.Range("J5")
            objCelda.Columns.ColumnWidth = 60
            objCelda = objHojaExcel.Range("K5")
            objCelda.Columns.ColumnWidth = 40
            objCelda = objHojaExcel.Range("L5")
            objCelda.Columns.ColumnWidth = 60
            objCelda = objHojaExcel.Range("M5")
            objCelda.Columns.ColumnWidth = 40
            objCelda = objHojaExcel.Range("N5")
            objCelda.Columns.ColumnWidth = 40
            objCelda = objHojaExcel.Range("O5")
            objCelda.Columns.ColumnWidth = 25
            objCelda = objHojaExcel.Range("P5")
            objCelda.Columns.ColumnWidth = 25
            objCelda = objHojaExcel.Range("Q5")
            objCelda.Columns.ColumnWidth = 40
            objCelda = objHojaExcel.Range("R5")
            objCelda.Columns.ColumnWidth = 15
            objCelda = objHojaExcel.Range("S5")
            objCelda.Columns.ColumnWidth = 60
            objCelda = objHojaExcel.Range("T5")
            objCelda.Columns.ColumnWidth = 25
            objCelda = objHojaExcel.Range("U5")
            objCelda.Columns.ColumnWidth = 40
            objCelda = objHojaExcel.Range("V5")
            objCelda.Columns.ColumnWidth = 40
            objCelda = objHojaExcel.Range("W5")
            objCelda.Columns.ColumnWidth = 65


            objCelda = objHojaExcel.Range("A1").Resize(2, grid.Columns.Count)
            contenidoReporte(objCelda, grid, 0, mDatosH, mCxC)

            objCelda.MergeCells = True
            objCelda.Value = sEmpresa
            objCelda.Font.Bold = True
            objCelda.Font.Size = 24
            objCelda.HorizontalAlignment = -4108
            objCelda.VerticalAlignment = -4108

            objLibroExcel.Worksheets(1).Activate()

            objHojaExcel.Range("A4", "X4").AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, True)

            objExcel.Cursor = Excel.XlMousePointer.xlDefault
            objExcel.ActiveWorkbook.SaveAs(sRutaArchivo & sNombreArchivo & ".xlsx")
            objHojaExcel = Nothing
            objLibroExcel.Close(False)
            objLibroExcel = Nothing

            objExcel.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
            objExcel = Nothing

            MsgBox("El reporte se guardó correctamente en " & sRutaArchivo & ".", MsgBoxStyle.Information, "Reporte Generado")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub nombreReporte(ByVal obj As Excel.Range, ByVal sTitulo As String, ByVal sRango As String, ByVal iColumnas As Integer)
        Try
            obj = objHojaExcel.Range(sRango).Resize(1, iColumnas)
            With obj
                .MergeCells = True
                .Value = sTitulo
                .Font.Bold = True
                .Font.Size = 16
                .HorizontalAlignment = -4108
                .VerticalAlignment = -4108
                '.Borders(8).LineStyle = 1
                '.Borders(8).Weight = 4
                '.Borders(9).LineStyle = 1
                '.Borders(9).Weight = 2
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub contenidoReporte(ByVal obj As Excel.Range, ByVal grid As DataGridView, ByVal indice As Integer, ByVal mCabecera(,) As String, ByVal mDato(,) As Object)
        Try
            For Each c As DataGridViewColumn In grid.Columns
                If c.Index >= indice Then
                    If c.Visible Then
                        mCabecera(0, c.Index - indice) = c.HeaderText
                    End If
                End If
            Next

            For Each c As DataGridViewColumn In grid.Columns
                If c.Index >= indice Then
                    If c.Visible Then
                        For x As Integer = 0 To grid.Rows.Count - 1
                            If grid.Rows(x).Cells(c.Index).Value Is Nothing Then
                                mDato(x, c.Index - indice) = ""
                            Else
                                mDato(x, c.Index - indice) = grid.Rows(x).Cells(c.Index).Value.ToString
                            End If
                        Next
                    End If
                End If
            Next

            obj = objHojaExcel.Range("A4").Resize(1, grid.Columns.Count - indice)
            obj.Value = mCabecera
            obj.Font.Bold = True
            obj.Borders(8).LineStyle = 1
            obj.Borders(8).Weight = 2
            obj.Borders(9).LineStyle = 1
            obj.Borders(9).Weight = 2

            obj = objHojaExcel.Range("A5").Resize(grid.Rows.Count, grid.Columns.Count - indice)
            obj.Value = mDato
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub



End Module