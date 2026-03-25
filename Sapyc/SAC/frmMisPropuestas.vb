Public Class frmMisPropuestas

    Private bs As New BindingSource
    Private dtSolicitudes As New DataTable
    Private sNameRpt As String = "Lista de Prospectos"
    Public idSac, sOficina, sDivision, sCliente, sServicio, sDescTrabajo As String
    Public dFechaAlta As DateTime


    Private Sub frmMisPropuestas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridProspectos.DataSource = bs
        DesplazamientoGrid(gridProspectos)

        ListarSolicitudes()
        If dtSolicitudes Is Nothing Then Exit Sub
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnRevisar_Click(sender As Object, e As EventArgs) Handles btnRevisar.Click
        Try
            Dim frm As New frmAutorizaOtroServicio

            If gridProspectos.CurrentRow IsNot Nothing Then
                frm.idSac = gridProspectos.CurrentRow.Cells("idSAC").Value
                frm.sOficina = gridProspectos.CurrentRow.Cells("sOficina").Value
                frm.sDivision = gridProspectos.CurrentRow.Cells("sDivision").Value
                frm.sCliente = gridProspectos.CurrentRow.Cells("sNombreCte").Value
                frm.sServicio = gridProspectos.CurrentRow.Cells("DescServ").Value
                frm.sDescTrabajo = gridProspectos.CurrentRow.Cells("OtraDesc").Value
                frm.idPropuesta = gridProspectos.CurrentRow.Cells("idProp").Value

                If frm.ShowDialog = DialogResult.OK Then
                    ListarSolicitudes()
                End If

            Else
                MsgBox("Seleccione a un prospecto para poder generar una propuesta.", MsgBoxStyle.Exclamation, "SAPYC")
            End If


        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSolicitudesSAC()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtSolicitudes = Nothing
        End Try

    End Sub

    Private Sub ListarSolicitudes()
        Try
            Dim sTabla As String = "tbSolicitudes"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paSolicitudesSAC", sTabla))

                dtSolicitudes = .Item(sTabla)
            End With

            If dtSolicitudes.Rows.Count > 0 Then
                bs.DataSource = dtSolicitudes

                gridProspectos.Columns("DescServ").Visible = False
                gridProspectos.Columns("OtraDesc").Visible = False
                gridProspectos.Columns("idProp").Visible = False

                ConfigurarColumnasGrid(gridProspectos, "idSAC", "CVE. SAC", 65, 3, False)
                ConfigurarColumnasGrid(gridProspectos, "sOficina", "OFICINA", 80, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "sDivision", "DIVISIÓN", 80, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "sNombreCte", "CLIENTE", 0, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "dFechaAlta", "FECHA DE CREACIÓN", 160, 3, False)

            Else
                bs.DataSource = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSolicitudesIndependencia()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtSolicitudes = Nothing
        End Try
    End Sub




End Class