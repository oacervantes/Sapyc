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

End Module