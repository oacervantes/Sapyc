Public Class dlgConsultaAsignacionRecurrente

    Private ds As New DataSet
    Private sNameRpt As String = "Detalle de Solicitud de Asignación cliente recurrente"

    Private dtSolicitud As New DataTable
    Public idSac, idPropuesta As Integer

    Private Sub DlgConsultaAsignacionRecurrente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarDatosSolicitudRecurrente()
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = DialogResult.OK
    End Sub

    Private Sub ListarDatosSolicitudRecurrente()
        Try
            Dim sTabla As String = "tbDatos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 21, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idSac", idSac, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paSolicitudesSAC", sTabla))

                dtSolicitud = .Item(sTabla)
            End With

            If dtSolicitud.Rows.Count > 0 Then
                Dim dr As DataRow = dtSolicitud.Rows(0)

                txtIdSac.Text = idSac
                txtProspecto.Text = dr.Item("sNombreCte").ToString()
                txtServicio.Text = dr.Item("SERVICIO").ToString()
                txtOficina.Text = dr.Item("DESCOFI").ToString()
                txtDivision.Text = dr.Item("DESCAREA").ToString()
                txtSocioEncargado.Text = dr.Item("encargado").ToString()
                lblUsuarioSol.Text = dr.Item("sNombreUsuario").ToString()

            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDatosSolicitudRecurrente()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtSolicitud = Nothing
        End Try
    End Sub

End Class