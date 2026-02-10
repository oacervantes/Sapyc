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
    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim dlg As New DlgKardex

        If gridDatos.CurrentRow IsNot Nothing Then
            dlg.idKardex = gridDatos.CurrentRow.Cells("idKardex").Value
            dlg.sCveEmp = gridDatos.CurrentRow.Cells("sCveEmp").Value
            dlg.sNombre = gridDatos.CurrentRow.Cells("sNombre").Value

            If dlg.ShowDialog() = DialogResult.OK Then
                ListarKardex()
            End If
        Else
            MsgBox("Seleccione al colaborador para revisar su kardex.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
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
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = naranja_Salles
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco
        ElseIf gridDatos.Rows(e.RowIndex).Cells("iStatusKardex").Value = 3 Then
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = rojo_Salles
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco
        ElseIf gridDatos.Rows(e.RowIndex).Cells("iStatusKardex").Value = 4 Then
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.FromArgb(47, 158, 68)
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco
        Else
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.WhiteSmoke
            gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = Color.Black
        End If

        gridDatos.Rows(e.RowIndex).Cells("sStatus").Style.Font = FuenteFila
    End Sub
    Private Sub GridDatos_DoubleClick(sender As Object, e As EventArgs) Handles gridDatos.DoubleClick
        If gridDatos.CurrentRow IsNot Nothing Then
            Dim dlg As New DlgKardex

            If gridDatos.CurrentRow IsNot Nothing Then
                dlg.idKardex = gridDatos.CurrentRow.Cells("idKardex").Value
                dlg.sCveEmp = gridDatos.CurrentRow.Cells("sCveEmp").Value
                dlg.sNombre = gridDatos.CurrentRow.Cells("sNombre").Value

                If dlg.ShowDialog() = DialogResult.OK Then
                    ListarKardex()
                End If
            Else
                MsgBox("Seleccione al colaborador para revisar su kardex.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            End If
        End If
    End Sub

    Private Sub RdTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdTodos.CheckedChanged
        If rdTodos.Checked Then
            bs.Filter = ""
        End If
    End Sub
    Private Sub RdGerente_CheckedChanged(sender As Object, e As EventArgs) Handles rdGerente.CheckedChanged
        If rdGerente.Checked Then
            bs.Filter = "sTipoEmp IN ('GER')"
        End If
    End Sub
    Private Sub RdSocio_CheckedChanged(sender As Object, e As EventArgs) Handles rdSocio.CheckedChanged
        If rdSocio.Checked Then
            bs.Filter = "sTipoEmp IN ('SOC', 'ASO')"
        End If
    End Sub

    Private Sub TxtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        If rdSocio.Checked Then
            bs.Filter = "sNombre LIKE '%" & txtNombre.Text & "%' AND sTipoEmp IN ('SOC', 'ASO')"
        ElseIf rdGerente.Checked Then
            bs.Filter = "sNombre LIKE '%" & txtNombre.Text & "%' AND sTipoEmp IN ('GER')"
        ElseIf rdTodos.Checked Then
            bs.Filter = "sNombre LIKE '%" & txtNombre.Text & "%'"
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
                gridDatos.Columns("dEdad").Visible = False
                gridDatos.Columns("dAntiguo").Visible = False
                gridDatos.Columns("sPuesto").Visible = False
                gridDatos.Columns("dFechaCap").Visible = False

                ConfigurarColumnasGrid(gridDatos, "idKardex", "ID. KARDEX", 100, 3, False)
                ConfigurarColumnasGrid(gridDatos, "sNombre", "NOMBRE", 0, 1, False)
                ConfigurarColumnasGrid(gridDatos, "sTipo", "TIPO", 150, 1, False)
                ConfigurarColumnasGrid(gridDatos, "sStatus", "STATUS", 130, 3, False)
            Else
                bs.DataSource = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarKardex()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtKardex = Nothing
        End Try
    End Sub

End Class