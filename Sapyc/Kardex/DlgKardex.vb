Public Class DlgKardex

    Private bsDiv As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Kardex de Colaborador"
    Private sStoredProc As String = "paKardexEncargados"

    Private dtDivisiones As New DataTable

    Public idKardex As Integer
    Public sCveEmp, sNombre As String

    Private Sub DlgKardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitulo.Text = "KARDEX - " & sNombre.ToUpper
        gridDivisiones.DataSource = bsDiv

        ListarDivisionesColaborador()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub


    Private Sub ListarDivisionesColaborador()
        Try
            Dim sTabla As String = "tbDivisiones"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idKardex", idKardex, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtDivisiones = .Item(sTabla)
            End With

            If dtDivisiones.Rows.Count > 0 Then
                bsDiv.DataSource = dtDivisiones

                gridDivisiones.Columns("idKardex").Visible = False
                gridDivisiones.Columns("sCveOfi").Visible = False
                gridDivisiones.Columns("sCveArea").Visible = False
                gridDivisiones.Columns("sUsuario").Visible = False
                gridDivisiones.Columns("dFechaCap").Visible = False

                ConfigurarColumnasGrid(gridDivisiones, "DESCOFI", "OFICINA", 0, 1, False)
                ConfigurarColumnasGrid(gridDivisiones, "DESCAREA", "DIVISIÓN", 0, 1, False)
            Else
                bsDiv.DataSource = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDivisionesColaborador()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtDivisiones = Nothing
        End Try
    End Sub

End Class
