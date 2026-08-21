Public Class DlgDetalleAusencia

    Private ds As New DataSet

    Private sNameRpt As String = "Detalle de ausencia"
    Private sStoredProcedure As String = "paAusencias"

    Private dtAusencia As New DataTable

    Public idAusencia As Integer
    Public sCveSocio As String

    Private Sub DlgDetalleAusencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarAusencia()
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub ListarAusencia()
        Try
            Dim sTabla As String = "tbAusencia"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idAusencia", idAusencia, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSocio", sCveSocio, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable(sStoredProcedure, sTabla))

                dtAusencia = .Item(sTabla)
            End With

            If dtAusencia.Rows.Count > 0 Then

                txtFechaDe.Value = dtAusencia.Rows(0).Item("dFechaInicio")
                txtFechaA.Value = dtAusencia.Rows(0).Item("dFechaFinal")

                txtMotivo.Text = dtAusencia.Rows(0).Item("sMotivo")
                txtDescOtros.Text = dtAusencia.Rows(0).Item("sMotivoOtros")

                Select Case dtAusencia.Rows(0).Item("idDisponibilidad")
                    Case 1
                        rdCompleta.Checked = True
                    Case 2
                        rdLimitada.Checked = True
                    Case 3
                        rdSinDisponibilidad.Checked = True
                    Case Else
                        rdCompleta.Checked = False
                        rdLimitada.Checked = False
                        rdSinDisponibilidad.Checked = False
                End Select

                txtInformacionAdicional.Text = dtAusencia.Rows(0).Item("sInformacionAdicional")
            End If

        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarAusencia()")
            MsgBox("Por el momento no es posible consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtAusencia = Nothing
        End Try
    End Sub

End Class
