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

    End Sub
    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

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

    Private Sub CrearTabla()
        dtInfo.Columns.Add("TIPO", GetType(String))
        dtInfo.Columns.Add("CVE", GetType(String))
        dtInfo.Columns.Add("CVEDIVISION", GetType(String))
        dtInfo.Columns.Add("DIVISION", GetType(String))
        dtInfo.Columns.Add("SERVICIO", GetType(String))
        dtInfo.Columns.Add("VISIBLE", GetType(String))
    End Sub
    Private Sub FormatoGrid()
        gridDatos.Columns("TIPO").Visible = False
        gridDatos.Columns("CVE").Visible = False
        gridDatos.Columns("CVEDIVISION").Visible = False

        ConfigurarColumnasGrid(gridDatos, "DIVISION", "DIVISIÓN", 150, 1, False)
        ConfigurarColumnasGrid(gridDatos, "SERVICIO", "SERVICIO", 0, 1, False)
        ConfigurarColumnasGrid(gridDatos, "VISIBLE", "VISIBLE", 80, 3, False)
    End Sub
    Private Sub ListarTipoServicios()
        Try
            Dim sTabla As String = "tbTipoServicio"

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
                        drInfo("DIVISION") = dr("DIVISION").ToString()
                        drInfo("SERVICIO") = dr("SERVICIO").ToString()
                        drInfo("VISIBLE") = dr("VISIBLE").ToString()
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
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idClave", idClave, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP(sStoredProc)
            End With

            'MsgBox("Se registraron los datos del acercamiento correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarAcercamiento()")
            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

End Class