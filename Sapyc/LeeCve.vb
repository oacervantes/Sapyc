Public Class LeeCve
    Public Dedonde As Integer

    Private Sub Baceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Baceptar.Click
        Me.Hide()
    End Sub

    Private Sub Ccve_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ccve.TextChanged
        Ccve.CharacterCasing = CharacterCasing.Upper
    End Sub

End Class