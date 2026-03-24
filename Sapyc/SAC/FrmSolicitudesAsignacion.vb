Public Class FrmSolicitudesAsignacion

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Asignación de Solicitudes"

    Private dtSolicitudes As New DataTable

    Private Sub FrmSolicitudesAsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridProspectos.DataSource = bs
        DesplazamientoGrid(gridProspectos)

        ListarSolicitudes()
    End Sub
    Private Sub BtnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim dlg As New DlgSolicitudAsignacion()

        If gridProspectos.CurrentRow IsNot Nothing Then
            Dim bActivo As Boolean = gridProspectos.CurrentRow.Cells("bStatus").Value
            Dim sStatus As String = gridProspectos.CurrentRow.Cells("cStatus").Value.ToString()
            Dim idSac As Integer = gridProspectos.CurrentRow.Cells("idSac").Value
            Dim idPropuesta As Integer = gridProspectos.CurrentRow.Cells("idPropuesta").Value
            Dim sCveOfi As String = gridProspectos.CurrentRow.Cells("sCveOfi").Value.ToString()
            Dim sCveArea As String = gridProspectos.CurrentRow.Cells("sCveArea").Value.ToString()

            If gridProspectos.CurrentRow.Cells("bStatus").Value IsNot Nothing AndAlso bActivo = False AndAlso sStatus = "R" Then
                MsgBox("La solicitud se encuentra en revisión por servicio y no es posible asignarla en este momento.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
                Exit Sub
            ElseIf gridProspectos.CurrentRow.Cells("bStatus").Value IsNot Nothing AndAlso bActivo = False AndAlso sStatus = "C" Then
                MsgBox("La solicitud ha sido cancelada y ya no es posible asignarla.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
                Exit Sub
            End If

            dlg.idSac = idSac
            dlg.idPropuesta = idPropuesta
            dlg.sCveOfi = sCveOfi
            dlg.sCvearea = sCveArea
            dlg.ShowDialog()
        End If
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

                .Add(clsLocal.funExecuteSPDataTable("paSolicitudesSAC", sTabla))

                dtSolicitudes = .Item(sTabla)
            End With

            If dtSolicitudes.Rows.Count > 0 Then
                bs.DataSource = dtSolicitudes
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSolicitudes = Nothing
        End Try
    End Sub

End Class