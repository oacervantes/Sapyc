Public Class frmenviocorreos
    Private Sub frmenviocorreos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ConsultaEmpresas()

    End Sub


    Public Sub ConsultaEnviaCorreosInd(Empresa As String)
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@TPOUSR", 2, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))

                dtCorreos = .Item("paEmpresaPropuesta")
                If dtCorreos.Rows.Count > 0 Then
                    For Each dr As DataRow In dtCorreos.Rows
                        If Not IsDBNull(dr("CORREO")) Then
                            EnvioCorreoInd(dr("CORREO").ToString(), dr("NOMBREUSR").ToString(), Empresa)
                        End If
                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub EnvioCorreoInd(ByVal Correo As String, ByVal NombSocio As String, Empresa As String)
        Dim sMensaje As String
        Dim sCorreo As String() = {Correo}
        Try
            ' sCorreos = sCorreoUsuario & "," & "Mario.Rodriguez@mx.gt.com" & "," & Correo
            sMensaje = "Estimad(a)s Independencia y BackGround, " & vbNewLine & vbNewLine
            sMensaje &= "Se ha generado una propuesta de cliente Fiscal " & Empresa.ToUpper() & "  " & vbNewLine & vbNewLine
            sMensaje &= "A la cual podrás darle seguimiento en el sistema de Sapyc 2.0" & vbNewLine & vbNewLine
            envioCorreos(sCorreo, sMensaje, "Propuestas Clientes - Sapyc")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ConsultaEmpresas()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paIndependencia") Then
                    .Remove("paIndependencia")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paIndependencia"))

                dtCorreos = .Item("paIndependencia")
                If dtCorreos.Rows.Count > 0 Then
                    For Each dr As DataRow In dtCorreos.Rows
                        If Not IsDBNull(dr("NOMEMPRESA")) Then
                            ConsultaEnviaCorreosInd(dr("NOMEMPRESA").ToString())
                        End If
                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class