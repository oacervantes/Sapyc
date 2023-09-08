Public Class MttoAccionistaPF
    Public Vok As Boolean

    Public Sub LimpiaPan()
        Cnombre.Text = ""
        Capaterno.Text = ""
        Camaterno.Text = ""
        Cporcentaje.Text = ""
    End Sub


    Private Sub Bcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcancelar.Click
        Vok = False
        Me.Hide()
        Me.Dispose()
    End Sub

    Private Sub Cnombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cnombre.KeyPress, Capaterno.KeyPress, Camaterno.KeyPress, Cporcentaje.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub Cnombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cnombre.TextChanged
        Cnombre.CharacterCasing = CharacterCasing.Upper
    End Sub


    Private Sub Capaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Capaterno.TextChanged
        Capaterno.CharacterCasing = CharacterCasing.Upper
    End Sub


    Private Sub Camaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Camaterno.TextChanged
        Camaterno.CharacterCasing = CharacterCasing.Upper
    End Sub



    Private Sub Baceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Baceptar.Click
        If Cnombre.Text = "" Then
            MsgBox("No se capturo el Nombre del Accionista", MsgBoxStyle.Critical, "Dato no Capturado")
            Exit Sub
        End If
        If Capaterno.Text = "" Then
            MsgBox("No se capturo el Apellido del Accionista", MsgBoxStyle.Critical, "Dato no Capturado")
            Exit Sub
        End If
        Vok = True
        Me.Hide()
    End Sub

End Class