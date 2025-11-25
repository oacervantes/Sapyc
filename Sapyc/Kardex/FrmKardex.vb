Public Class FrmKardex

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Kardex de Socio/Gerente"
    Private sStoredProc As String = "paKardexEncargados"

    Private dtKardex As New DataTable

    Private Sub FrmKardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridDatos.DataSource = bs
        DesplazamientoGrid(gridDatos)

        ListarKardex()
    End Sub
    Private Sub BtnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim dlg As New DlgColaboradorKardex

        dlg.ShowDialog()
    End Sub
    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

    End Sub
    Private Sub BtnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
        If gridDatos.CurrentRow IsNot Nothing Then
            Dim idKardex As Integer = CInt(gridDatos.CurrentRow.Cells("idKardex").Value)
            Dim sNombre As String = CStr(gridDatos.CurrentRow.Cells("sNombre").Value)

            If gridDatos.CurrentRow.Cells("bStatus").Value Then
                If MsgBox("Se dará de baja el kardex de " & sNombre & ", ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
                    BajaKardex(3, idKardex)
                    ListarKardex()
                End If
            Else
                If MsgBox("Se reactivará el kardex de " & sNombre & ", ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
                    BajaKardex(4, idKardex)
                    ListarKardex()
                End If
            End If
        End If
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub GridDatos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDatos.CellFormatting
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If gridDatos.Rows(e.RowIndex).Cells("iStatusKardex").Value = 1 Then
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.FromArgb(250, 224, 60)
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = negro
        ElseIf gridDatos.Rows(e.RowIndex).Cells("iStatusKardex").Value = 2 Then
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.FromArgb(47, 158, 68)
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco
        ElseIf gridDatos.Rows(e.RowIndex).Cells("iStatusKardex").Value = 3 Then
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = rojo_Salles
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco
        Else
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.WhiteSmoke
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = Color.Black
        End If

        gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.Font = FuenteFila
    End Sub
    Private Sub GridDatos_SelectionChanged(sender As Object, e As EventArgs) Handles gridDatos.SelectionChanged
        If gridDatos.CurrentRow IsNot Nothing Then
            If gridDatos.CurrentRow.Cells("bStatus").Value = 0 Then
                btnEditar.Enabled = False
                btnBaja.Text = "Reactivar"
            Else
                btnEditar.Enabled = True
                btnBaja.Text = "Baja"
            End If
        End If
    End Sub

    Private Sub ListarKardex()
        Try
            Dim sTabla As String = "tbKardex"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtKardex = .Item(sTabla)
            End With

            If dtKardex.Rows.Count > 0 Then
                bs.DataSource = dtKardex

                gridDatos.Columns("iStatusKardex").Visible = False
                gridDatos.Columns("sCveEmp").Visible = False
                gridDatos.Columns("sTipoEmp").Visible = False
                gridDatos.Columns("bStatus").Visible = False
                gridDatos.Columns("sUsuario").Visible = False
                gridDatos.Columns("sUSuarioMod").Visible = False
                gridDatos.Columns("dFechaMod").Visible = False

                ConfigurarColumnasGrid(gridDatos, "idKardex", "ID. KARDEX", 100, 3, False)
                ConfigurarColumnasGrid(gridDatos, "sNombre", "NOMBRE", 0, 1, False)
                ConfigurarColumnasGrid(gridDatos, "sTipo", "TIPO", 150, 1, False)
                ConfigurarColumnasGrid(gridDatos, "sStatus", "STATUS", 130, 3, False)
                ConfigurarColumnasGrid(gridDatos, "dFechaCap", "ALTA", 150, 3, False)
            Else
                bs.DataSource = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarKardex()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtKardex = Nothing
        End Try
    End Sub
    Private Sub BajaKardex(iOpcion As Integer, idKardex As Integer)
        Try
            With clsDatosSac
                .subClearParameters()
                .subAddParameter("@iOpcion", iOpcion, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idKardex", idKardex, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP(sStoredProc)
            End With

            MsgBox("Se ha dado de baja el kardex correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EliminarProspecto()")
            MsgBox("Por el momento no es posible dar de baja el kardex, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub

End Class