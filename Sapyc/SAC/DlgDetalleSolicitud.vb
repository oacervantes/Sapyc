Public Class DlgDetalleSolicitud

    Private ds As New DataSet
    Private sNameRpt As String = "Detalle de Solicitud de Asignación"

    Private dtSolicitud As New DataTable

    Private cStatus As String
    Public idSac, idPropuesta As Integer

    Private Sub DlgDetalleSolicitud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarDatosSolicitud()
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = DialogResult.OK
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
                txtIdioma.Text = dtSolicitud.Rows(0).Item("sIdioma").ToString()
                txtOficina.Text = dtSolicitud.Rows(0).Item("DESCOFI").ToString()
                txtDivision.Text = dtSolicitud.Rows(0).Item("DESCAREA").ToString()
                txtSocioEncargado.Text = dtSolicitud.Rows(0).Item("SOCENC").ToString()
                txtIdioma.Text = dtSolicitud.Rows(0).Item("sIdioma").ToString()
                txtIndustria.Text = dtSolicitud.Rows(0).Item("INDUSTRIA").ToString()
                cStatus = dtSolicitud.Rows(0).Item("cStatus").ToString()

                If cStatus = "D" Then
                    txtMotivoRechazo.Text = dtSolicitud.Rows(0).Item("sMotivoRechazo").ToString()
                Else
                    txtMotivoRechazo.Text = "N/A"
                End If
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSolicitud = Nothing
        End Try
    End Sub

End Class