Public Class frmAutorizaNivelRiesgo

    Private sNameRpt As String = "Autoriza Nivel Riesgo"
    Private sEstatus As String

    Public idSac, sOficina, sDivision, sCliente, sServicio, sDescTrabajo As String
    Public idPropuesta As Integer
    Public dFechaAlta As Date

    Private Sub FrmAutorizaNivelRiesgo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIdSac.Text = idSac
        txtOficina.Text = sOficina
        txtDivision.Text = sDivision
        txtCliente.Text = sCliente
        txtServicio.Text = sDescTrabajo
    End Sub
    Private Sub BtnAutoriza_Click(sender As Object, e As EventArgs) Handles btnAutoriza.Click
        ActualizaNivelRiesgo()
        MsgBox("Se actualizo el nivel de riesgo de manera correcta", MsgBoxStyle.Information, "SAPYC")

        DialogResult = DialogResult.OK
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub ActualizaNivelRiesgo()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSac, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)

                If rbBajo.Checked Then
                    .subAddParameter("@iNivelRiesgo", 1, SqlDbType.Int, ParameterDirection.Input)
                ElseIf rbMedio.Checked Then
                    .subAddParameter("@iNivelRiesgo", 2, SqlDbType.Int, ParameterDirection.Input)
                ElseIf rbAlto.Checked Then
                    .subAddParameter("@iNivelRiesgo", 3, SqlDbType.Int, ParameterDirection.Input)
                End If
                .subAddParameter("@sMotivoNivel", txtComentarios.Text, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paDatosAsignacionSACPropuestas")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ActualizaNivelRiesgo()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

End Class