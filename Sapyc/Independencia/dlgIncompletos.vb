Public Class dlgIncompletos

    Public sCliente, sCorreoSoc, sCorreoGnt As String


    Private Sub dlgIncompletos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If MsgBox("¿Desea rechazar la propuesta por datos incompletos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SAPYC") = MsgBoxResult.Yes Then
            If txtMotivo.Text = "" Then
                MsgBox("Debes indicar un motivo de rechazo por datos incompletos")
                Exit Sub
            End If



        End If

    End Sub

End Class