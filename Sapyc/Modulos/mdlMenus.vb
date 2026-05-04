Module mdlMenus

    Private ds As New DataSet

    Private sNameRpt As String = "Carga Inicial Menús"

    Public dtModulos, dtModulosSocio As New DataTable

    Public Sub ListarModulos()
        Try
            Dim sTabla As String = "tbModulos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paModulosMenus", sTabla))

                dtModulos = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarModulos()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtModulos = Nothing
        End Try
    End Sub
    Public Sub ListarModulosSocio(sCveSocio As String)
        Try
            Dim sTabla As String = "tbModulosSocio"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSocio", sCveSocio, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paModulosMenus", sTabla))

                dtModulosSocio = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarModulosSocio()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtModulosSocio = Nothing
        End Try
    End Sub

    Public Sub ListarPermisosMenus(menu As MenuStrip)
        ListarModulosSocio(sCveUsuario)

        For Each itm As Object In menu.Items
            Select Case itm.GetType.Name
                Case "ToolStripMenuItem"
                    For Each mdl As DataRow In dtModulosSocio.Rows
                        If CDbl(itm.Tag) = CDbl(mdl.Item("idModulo").ToString) Then
                            itm.Enabled = CBool(mdl.Item("bActivo").ToString)
                            itm.Visible = CBool(mdl.Item("bVisible").ToString)

                            Exit For
                        End If
                    Next

                Case "ToolStripSeparator"
                    For Each mdl As DataRow In dtModulosSocio.Rows
                        If CDbl(itm.Tag) = CDbl(mdl.Item("idModulo").ToString) Then
                            itm.Enabled = CBool(mdl.Item("bActivo").ToString)
                            itm.Visible = CBool(mdl.Item("bVisible").ToString)

                            Exit For
                        End If
                    Next
            End Select
        Next
    End Sub

End Module
