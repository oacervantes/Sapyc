Public Class frmListaSeguimiento

    Private bs As New BindingSource
    Private ds As New DataSet
    Private sNameRpt As String = "Lista de Prospectos nivel de riesgo"

    Private dtSolicitudes As New DataTable

    Public idSac, sOficina, sDivision, idServicio, sCliente, sServicio, sDescTrabajo As String
    Public dFechaAlta As Date

    Private Sub FrmListaSeguimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridProspectos.DataSource = bs
        DesplazamientoGrid(gridProspectos)

        ListarSolicitudes()
        If dtSolicitudes Is Nothing Then Exit Sub
    End Sub
    Private Sub BtnRevisar_Click(sender As Object, e As EventArgs) Handles btnRevisar.Click
        Try
            Dim frm As New FrmContactoConsulta

            If gridProspectos.CurrentRow IsNot Nothing Then
                frm.iOrigen = 2
                frm.idSAC = gridProspectos.CurrentRow.Cells("idSAC").Value
                frm.idPropuesta = gridProspectos.CurrentRow.Cells("idProp").Value
                frm.idServicio = gridProspectos.CurrentRow.Cells("IdServicio").Value
                frm.sCveOfi = gridProspectos.CurrentRow.Cells("sCveOficina").Value
                frm.sCveArea = gridProspectos.CurrentRow.Cells("sCveDivision").Value
                frm.sServicio = gridProspectos.CurrentRow.Cells("sServicio").Value

                If frm.ShowDialog = DialogResult.OK Then
                    ListarSolicitudes()
                End If
            Else
                MsgBox("Seleccione a un prospecto para poder generar una propuesta.", MsgBoxStyle.Exclamation, "SAPYC")
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSolicitudesnivelriesgo()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtSolicitudes = Nothing
        End Try
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub ListarSolicitudes()
        Try
            Dim sTabla As String = "tbSolicitudes"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paDatosAsignacionSACPropuestas", sTabla))

                dtSolicitudes = .Item(sTabla)
            End With

            If dtSolicitudes.Rows.Count > 0 Then
                bs.DataSource = dtSolicitudes

                gridProspectos.Columns("idProp").Visible = False
                gridProspectos.Columns("sCveOficina").Visible = False
                gridProspectos.Columns("sCveDivision").Visible = False
                gridProspectos.Columns("IdServicio").Visible = False

                ConfigurarColumnasGrid(gridProspectos, "IdSac", "CVE. SAC", 65, 3, False)
                ConfigurarColumnasGrid(gridProspectos, "sOficina", "OFICINA", 80, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "sDivision", "DIVISIÓN", 80, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "sNombreCte", "CLIENTE", 0, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "sServicio", "SERVICIO", 0, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "PRESENTO", "PRESENTO PROPUESTA", 0, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "ESTATUS", "ESTATUS", 0, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "FECHAALTA", "FECHA ALTA", 160, 3, False)
                ConfigurarColumnasGrid(gridProspectos, "FECHAPROPUESTA", "FECHA PROPUESTA", 160, 3, False)
            Else
                bs.DataSource = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSolicitudes()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtSolicitudes = Nothing
        End Try
    End Sub

End Class