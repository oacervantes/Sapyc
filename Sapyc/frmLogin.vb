Public Class frmLogin

    Private dtUsuario As New DataTable
    Public sNombre, sTipo, sUsr As String

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        IniciarSesion()
    End Sub
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Close()
    End Sub

    Private Sub IniciarSesion()
        Try
            Dim sTabla As String = "tbUsuario"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sUsuario", UsernameTextBox.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sContraseña", PasswordTextBox.Text, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paSapyc", sTabla))
                dtUsuario = .Item(sTabla)
            End With

            If dtUsuario.Rows.Count > 0 Then
                sNombre = dtUsuario.Rows(0).Item("NOMBREUSR").ToString
                sTipo = dtUsuario.Rows(0).Item("TIPO").ToString
                Usuario_Num = dtUsuario.Rows(0).Item("IDUSR").ToString
                sCveUsuario = dtUsuario.Rows(0).Item("IDUSR").ToString
                sCorreoUsuario = dtUsuario.Rows(0).Item("CORREO").ToString

                DialogResult = DialogResult.OK
            Else
                MsgBox("El usuario o la contraseña son incorrectos.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            End If
        Catch ex As Exception
            MsgBox("Error al intentar iniciar sesión, intente más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub

End Class