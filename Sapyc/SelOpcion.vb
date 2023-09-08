Public Class SelOpcion

    Private Sub Baceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Baceptar.Click
        If Not Opcion1.Checked And Not Opcion2.Checked And Not Opcion3.Checked Then
            MsgBox("No se selecciono ningún valor", MsgBoxStyle.Critical, "Dato no seleccionado")
            Exit Sub
        End If
        Me.Hide()
    End Sub
End Class