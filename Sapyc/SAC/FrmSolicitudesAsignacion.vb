Public Class FrmSolicitudesAsignacion
    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim dlg As New DlgSolicitudAsignacion()

        dlg.ShowDialog()
    End Sub
End Class