Public Class DlgServiciosCte

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Seleccionar Servicios"

    Private dtServ, dtServicios As New DataTable
    Private drServicios As DataRow

    Public dtServCte, dtServiciosCte As New DataTable
    Public sCveArea, sFacInt As String

    Private Sub DlgServiciosCte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridDatos.DataSource = bs
        DesplazamientoGrid(gridDatos)

        CrearTabla()
        ListarServiciosDivision(sCveArea)
    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridDatos.Rows.Count > 0 Then
            If Not ValidarSeleccion() Then
                MsgBox("Seleccione al menos un servicio.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
                Exit Sub
            End If

            EnviarServiciosCte()
            DialogResult = DialogResult.OK
            Close()
        Else
            MsgBox("No hay servicios para seleccionar.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End If
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub GridDatos_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles gridDatos.CellBeginEdit
        If e.ColumnIndex <> 1 Then
            e.Cancel = True
        End If
    End Sub
    Private Sub GridDatos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridDatos.CurrentCellDirtyStateChanged
        If gridDatos.IsCurrentCellDirty Then gridDatos.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub
    Private Sub GridDatos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles gridDatos.CellValueChanged
        If e.RowIndex = -1 Then Exit Sub

        If sFacInt = "S" Then
            Dim bMarca As Boolean = gridDatos.Rows(e.RowIndex).Cells(1).Value

            Try
                RemoveHandler gridDatos.CellValueChanged, AddressOf GridDatos_CellValueChanged

                For Each row As DataGridViewRow In gridDatos.Rows
                    row.Cells(1).Value = False
                Next

                If bMarca Then
                    gridDatos.Rows(e.RowIndex).Cells(1).Value = True
                End If
            Finally
                AddHandler gridDatos.CellValueChanged, AddressOf GridDatos_CellValueChanged
            End Try
        End If
    End Sub

    Private Sub CrearTabla()
        dtServicios.Columns.Add("CVE", GetType(Integer))
        dtServicios.Columns.Add("ELEGIR", GetType(Boolean))
        dtServicios.Columns.Add("DESCRIPCION", GetType(String))

        dtServiciosCte.Columns.Add("CVE", GetType(Integer))
        dtServiciosCte.Columns.Add("CVEOTROS", GetType(Boolean))
        dtServiciosCte.Columns.Add("DESCRIPCION", GetType(String))
    End Sub

    Private Sub ListarServiciosDivision(sCveArea As String)
        Try
            Dim sTabla As String = "tbServDiv"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSAPYC
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 12, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveDiv", sCveArea, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosSAPYC.funExecuteSPDataTable("paTipoServicios", sTabla))

                dtServ = .Item(sTabla)
            End With

            If dtServ.Rows.Count > 0 Then
                For Each row As DataRow In dtServ.Rows
                    If row("CVE") = 0 Then
                        Continue For
                    End If

                    drServicios = dtServicios.NewRow
                    drServicios("CVE") = row.Field(Of Integer)("CVE")
                    drServicios("ELEGIR") = False
                    drServicios("DESCRIPCION") = row("DESCRIPCION").ToString().Trim()
                    dtServicios.Rows.InsertAt(drServicios, dtServicios.Rows.Count)
                Next
            End If

            bs.DataSource = dtServicios

            For Each row As DataRow In dtServCte.Rows
                For Each rowServ As DataRow In dtServicios.Rows
                    If row("CVE") = rowServ("CVE") Then
                        rowServ("ELEGIR") = True
                        Exit For
                    End If
                Next
            Next

            gridDatos.Columns("CVE").Visible = False
            ConfigurarColumnasGrid(gridDatos, "ELEGIR", "ELEGIR", 65, 3, False)
            ConfigurarColumnasGrid(gridDatos, "DESCRIPCION", "SERVICIO", 0, 1, False)
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarServiciosDivision()")
            MsgBox(My.Settings.MSG_REPS, MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtServ = Nothing
        End Try
    End Sub
    Private Sub EnviarServiciosCte()
        For Each row As DataRow In dtServicios.Rows
            If row("ELEGIR") = True Then
                Dim dr As DataRow = dtServiciosCte.NewRow()
                Dim cve As Integer = row.Field(Of Integer)("CVE")

                dr("CVE") = cve
                Select Case cve
                    Case 56, 80, 92, 114, 177
                        dr("CVEOTROS") = True
                    Case Else
                        dr("CVEOTROS") = False
                End Select
                dr("DESCRIPCION") = row("DESCRIPCION").ToString().Trim()
                dtServiciosCte.Rows.InsertAt(dr, dtServiciosCte.Rows.Count)
            End If
        Next
    End Sub

    Private Function ValidarSeleccion() As Boolean
        Dim bSeleccion As Boolean = False
        For Each row As DataRow In dtServicios.Rows
            If row("ELEGIR") = True Then
                bSeleccion = True
                Exit For
            End If
        Next
        Return bSeleccion
    End Function

End Class