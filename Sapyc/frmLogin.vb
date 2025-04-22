Public Class frmLogin

    Private dtUsuario As New DataTable
    Public sNombre, sTipo, sUsr As String


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        iniciarSesion()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub iniciarSesion()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sUsuario", UsernameTextBox.Text, SqlDbType.VarChar, ParameterDirection.Input, 100)
                    .subAddParameter("@sContraseña", PasswordTextBox.Text, SqlDbType.VarChar, ParameterDirection.Input, 100)
                End With

                If .Contains("paSapyc") Then
                    .Remove("paSapyc")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
                dtUsuario = .Item("paSapyc")
            End With

            If dtUsuario.Rows.Count > 0 Then
                sNombre = dtUsuario.Rows(0).Item("NOMBREUSR").ToString
                sTipo = dtUsuario.Rows(0).Item("TIPO").ToString
                Usuario_Num = dtUsuario.Rows(0).Item("IDUSR").ToString


                DialogResult = DialogResult.OK
            Else
                MsgBox("El usuario o la contraseña son incorrectos.", MsgBoxStyle.Exclamation, "Error al iniciar sesión")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            MsgBox("Error al intentar iniciar sesión, intente más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

End Class
