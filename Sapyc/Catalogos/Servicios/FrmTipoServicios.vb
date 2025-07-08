Public Class FrmTipoServicios

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Tipo de Servicios"
    Private sStoredProc As String = "paTipoServicios"

    Private dtInfo, dtServicios As New DataTable
    Private drInfo As DataRow

    Private idClave, idCveDivision As Integer

    Private Sub FrmTipoServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridDatos.DataSource = bs
        DesplazamientoGrid(gridDatos)

        CrearTabla()
        ListarTipoServicios()
    End Sub
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim dlg As New DlgTipoServicio With {
            .iOrigen = 1
        }

        If dlg.ShowDialog() = DialogResult.OK Then
            ListarTipoServicios()
        End If
    End Sub
    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim dlg As New DlgTipoServicio With {
            .iOrigen = 2
        }

        If gridDatos.CurrentRow IsNot Nothing Then
            dlg.idClave = gridDatos.CurrentRow.Cells("CVE").Value
            dlg.idCveDivision = gridDatos.CurrentRow.Cells("CVEDIVISION").Value
            dlg.sServicio = gridDatos.CurrentRow.Cells("SERVICIO").Value.ToString()
            dlg.bMostrar = CBool(gridDatos.CurrentRow.Cells("VISIBLE").Value)
            dlg.bObligatorio = CBool(gridDatos.CurrentRow.Cells("OBLIGATORIO").Value)

            If dlg.ShowDialog() = DialogResult.OK Then
                ListarTipoServicios()
            End If
        Else
            MsgBox("Seleccione el servicio que desea editar.", MsgBoxStyle.Exclamation, "SIAT")
            Exit Sub
        End If
    End Sub
    Private Sub BtnOcultar_Click(sender As Object, e As EventArgs) Handles btnOcultar.Click
        If gridDatos.CurrentRow IsNot Nothing Then
            idClave = gridDatos.CurrentRow.Cells("CVE").Value

            If MsgBox("Se ocultará el servicio seleccionado. ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
                OcultarServicio(idClave)

                ListarTipoServicios()
            End If
        Else
            MsgBox("Seleccione el servicio que desea ocultar.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub TxtServicio_TextChanged(sender As Object, e As EventArgs) Handles txtServicio.TextChanged
        bs.Filter = String.Format("SERVICIO LIKE '%{0}%'", txtServicio.Text.Trim().Replace("'", "''"))
    End Sub

    Private Sub CrearTabla()
        dtInfo.Columns.Add("TIPO", GetType(String))
        dtInfo.Columns.Add("CVE", GetType(String))
        dtInfo.Columns.Add("CVEDIVISION", GetType(String))
        dtInfo.Columns.Add("DIVISION", GetType(String))
        dtInfo.Columns.Add("SERVICIO", GetType(String))
        dtInfo.Columns.Add("OBLIGATORIO", GetType(String))
        dtInfo.Columns.Add("VISIBLE", GetType(Boolean))
    End Sub
    Private Sub FormatoGrid()
        gridDatos.Columns("TIPO").Visible = False
        gridDatos.Columns("CVE").Visible = False
        gridDatos.Columns("CVEDIVISION").Visible = False
        gridDatos.Columns("OBLIGATORIO").Visible = False

        ConfigurarColumnasGrid(gridDatos, "DIVISION", "DIVISIÓN", 250, 1, False)
        ConfigurarColumnasGrid(gridDatos, "SERVICIO", "SERVICIO", 0, 1, False)
        ConfigurarColumnasGrid(gridDatos, "VISIBLE", "VISIBLE", 80, 3, False)
    End Sub

    Private Sub ListarTipoServicios()
        Try
            Dim sTabla As String = "tbTipoServicio"

            LimpiarTabla(dtInfo)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable(sStoredProc, sTabla))
                dtServicios = .Item(sTabla)

                If dtServicios.Rows.Count > 0 Then

                    For Each dr As DataRow In dtServicios.Rows
                        drInfo = dtInfo.NewRow
                        drInfo("TIPO") = "S"
                        drInfo("CVE") = dr("CVE").ToString()
                        drInfo("CVEDIVISION") = dr("CVEDIVISION").ToString()
                        drInfo("DIVISION") = dr("DIVISION").ToString().ToUpper
                        drInfo("SERVICIO") = dr("SERVICIO").ToString().ToUpper
                        drInfo("OBLIGATORIO") = dr("OBLIGATORIO").ToString()
                        drInfo("VISIBLE") = CBool(dr("VISIBLE").ToString())
                        dtInfo.Rows.InsertAt(drInfo, dtInfo.Rows.Count)
                    Next

                    bs.DataSource = dtInfo
                    FormatoGrid()
                End If
            End With
        Catch ex As Exception
            MsgBox("Por el momento no se posible mostrar el reporte, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub OcultarServicio(idClave As Integer)
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idClave", idClave, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP(sStoredProc)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "OcultarServicio()")
            MsgBox("Por el momento no es posible, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

End Class