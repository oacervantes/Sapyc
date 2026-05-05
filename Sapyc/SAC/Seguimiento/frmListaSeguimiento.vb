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
                If gridProspectos.CurrentRow.Cells("sStatus").Value <> "T" Then
                    MsgBox("La propuesta esta en proceso de asignación", MsgBoxStyle.Exclamation, "SAPYC")
                    Exit Sub
                End If

                frm.iOrigen = 2
                frm.idSAC = gridProspectos.CurrentRow.Cells("idSAC").Value
                frm.idPropuesta = gridProspectos.CurrentRow.Cells("idProp").Value
                frm.idServicio = gridProspectos.CurrentRow.Cells("IdServicio").Value
                frm.sCveOfi = gridProspectos.CurrentRow.Cells("sCveOficina").Value
                frm.sCveArea = gridProspectos.CurrentRow.Cells("sCveDivision").Value
                frm.sServicio = gridProspectos.CurrentRow.Cells("sServicio").Value
                frm.dHonorarios = gridProspectos.CurrentRow.Cells("HONORARIOS").Value
                frm.idEstatus = gridProspectos.CurrentRow.Cells("ESTATUS").Value
                frm.sNombreSocio = gridProspectos.CurrentRow.Cells("SOCIO").Value
                frm.sCorreoSocio = gridProspectos.CurrentRow.Cells("CORREO").Value

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
                gridProspectos.Columns("sStatus").Visible = False
                gridProspectos.Columns("ESTATUS").Visible = False
                gridProspectos.Columns("SOCIO").Visible = False
                gridProspectos.Columns("CORREO").Visible = False

                ConfigurarColumnasGrid(gridProspectos, "IdSac", "CVE. SAC", 65, 3, False)
                ConfigurarColumnasGrid(gridProspectos, "sOficina", "OFICINA", 150, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "sDivision", "DIVISIÓN", 200, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "sNombreCte", "CLIENTE", 270, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "sServicio", "SERVICIO", 270, 1, False)

                ConfigurarColumnasGrid(gridProspectos, "PRESENTO", "PROPUESTA" & vbNewLine & "PRESENTADA", 90, 3, False)
                ConfigurarColumnasGrid(gridProspectos, "FECHAALTASEG", "FECHA DE ALTA", 95, 3, False)
                ConfigurarColumnasGrid(gridProspectos, "sEstatusSeguimiento", "ESTATUS SEGUIMIENTO", 200, 1, False)

                ConfigurarColumnasGrid(gridProspectos, "sEstatusPropuesta", "ESTATUS DE LA" & vbNewLine & "PROPUESTA", 200, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "FECHAPROPUESTA", "FECHA DE LA" & vbNewLine & "PROPUESTA", 95, 3, False)
                ConfigurarColumnasGrid(gridProspectos, "HONORARIOS", "HONORARIOS ESTIMADOS", 110, 2, False)

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