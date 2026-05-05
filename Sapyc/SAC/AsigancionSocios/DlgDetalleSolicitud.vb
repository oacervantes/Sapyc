Public Class DlgDetalleSolicitud

    Private ds As New DataSet
    Private sNameRpt As String = "Detalle de Solicitud de Asignación"

    Private dtSolicitud As New DataTable

    Private cStatus As String
    Private iNivelRiesgo As Integer = 0
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
                iNivelRiesgo = CInt(dtSolicitud.Rows(0).Item("iNivelRiesgo"))
                txtNivelRiesgo.Text = dtSolicitud.Rows(0).Item("sNivelRiesgo").ToString()
                txtMarcoNormativo.Text = dtSolicitud.Rows(0).Item("sMarcoNormativo").ToString()
                cStatus = dtSolicitud.Rows(0).Item("cStatus").ToString()

                If cStatus = "D" Then
                    txtMotivoRechazo.Text = dtSolicitud.Rows(0).Item("sMotivoRechazo").ToString()
                Else
                    txtMotivoRechazo.Text = "N/A"
                End If

                Select Case iNivelRiesgo
                    Case 0
                        txtNivelRiesgo.BackColor = Color.Gainsboro

                    Case 1
                        txtNivelRiesgo.ForeColor = Color.White
                        txtNivelRiesgo.BackColor = Color.SeaGreen

                    Case 2
                        'txtNivelRiesgo.ForeColor = Color.Black
                        txtNivelRiesgo.BackColor = Color.Orange

                    Case 3
                        txtNivelRiesgo.ForeColor = Color.White
                        txtNivelRiesgo.BackColor = Color.FromArgb(233, 40, 65)
                End Select
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSolicitud = Nothing
        End Try
    End Sub

End Class