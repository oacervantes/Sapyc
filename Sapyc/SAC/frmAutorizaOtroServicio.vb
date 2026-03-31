Public Class frmAutorizaOtroServicio

    Public idSac, sOficina, sDivision, sCliente, sServicio, sDescTrabajo As String
    Public idPropuesta As Integer
    Public dFechaAlta As DateTime
    Private sNameRpt As String = "Autoriza Otros Servicios"
    Private sEstatus As String
    Private Sub frmAutorizaOtroServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblSac.Text = idSac
        txtOficina.Text = sOficina
        txtDivision.Text = sDivision
        txtCliente.Text = sCliente
        txtServicio.Text = sServicio
        txtDescripcionTrabajo.Text = sDescTrabajo

    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub
    Private Sub btnRechaza_Click(sender As Object, e As EventArgs) Handles btnRechaza.Click
        If txtRechazo.Text <> "" Then
            sEstatus = "C"

            ActualizaEstatusServiciosOtros()
            ActualizaDescRechazo()
            MsgBox("Se Rechazo el prospecto de manera correcta el prospecto", MsgBoxStyle.Information, "SAPYC")

            DialogResult = DialogResult.OK
        Else
            MsgBox("Indique una descripción del rechazo", MsgBoxStyle.Exclamation, "SAPYC")
        End If
    End Sub

    Private Sub btnAutoriza_Click(sender As Object, e As EventArgs) Handles btnAutoriza.Click
        sEstatus = "S"
        ActualizaEstatusServiciosOtros()
        MsgBox("Se Rechazo el autorizo de manera correcta el prospecto", MsgBoxStyle.Information, "SAPYC")

        DialogResult = DialogResult.OK

    End Sub
    Private Sub ActualizaEstatusServiciosOtros()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", lblSac.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@cStatus", sEstatus, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paSolicitudesSAC")

            End With

            'MsgBox("Se registró la propuesta correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizaEstatusServiciosOtros()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub ActualizaDescRechazo()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", lblSac.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sRechazo", txtRechazo.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paSolicitudesSAC")

            End With

            'MsgBox("Se registró la propuesta correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizaEstatusServiciosOtros()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub


End Class