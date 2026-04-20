Public Class DlgRechazoPropuesta

    Private ds As New DataSet
    Private sNameRpt As String = "Detalle de Solicitud de Asignación"

    Private dtSolicitud As New DataTable

    Public idSac, idPropuesta As Integer

    Private Sub DlgRechazoPropuesta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarDatosSolicitud()
    End Sub
    Private Sub BtnGuadar_Click(sender As Object, e As EventArgs) Handles btnGuadar.Click
        If txtMotivoRechazo.Text.Trim() = "" Then
            MsgBox("Es necesario especificar el motivo del rechazo de la asignación.", MsgBoxStyle.Exclamation, "SAPYC")
            Exit Sub
        End If

        If MsgBox("¿Confirma que desea rechazar la asignación de esta propuesta?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SAPYC") = MsgBoxResult.Yes Then
            RechazarAsignacion()
            MsgBox("Se ha rechazado la asignación de la propuesta de manera correcta.", MsgBoxStyle.Information, "SAPYC")
            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub ListarDatosSolicitud()

        Try
            Dim sTabla As String = "tbSocios"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idSac", idSac, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paSolicitudesSAC", sTabla))

                dtSolicitud = .Item(sTabla)
            End With

            If dtSolicitud.Rows.Count > 0 Then
                txtIdSac.Text = idSac
                txtProspecto.Text = dtSolicitud.Rows(0).Item("sNombreCte").ToString()
                txtServicio.Text = dtSolicitud.Rows(0).Item("SERVICIO").ToString()
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSolicitud = Nothing
        End Try
    End Sub
    Private Sub RechazarAsignacion()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSac, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sStatus", "C", SqlDbType.Char, ParameterDirection.Input)
                .subAddParameter("@sMotivoRechazo", txtMotivoRechazo.Text, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACPropuestas")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "RechazarAsignacion()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

End Class
