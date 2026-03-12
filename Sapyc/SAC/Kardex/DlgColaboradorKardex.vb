Public Class DlgColaboradorKardex

    Private ds As New DataSet

    Private sNameRpt As String = "Kardex de Socio/Gerente"
    Private sStoredProc As String = "paKardexEncargados"

    Private dtColaborador, dtOficinas, dtDivisiones As New DataTable

    Private sCveEmp, sMsg As String

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim dlgS As New dlgListaSocios
        Dim dlgG As New DlgListaGerentes

        If rdSocio.Checked = False And rdGerente.Checked = False Then
            sMsg = "Seleccione el tipo de colaborador."
            lblMensajeError.Text = sMsg
            lblMensajeError.Visible = True
            Exit Sub
        End If

        If cboOficina.SelectedValue = "XXX" Then
            sMsg = "Seleccione una oficina."
            lblMensajeError.Text = sMsg
            lblMensajeError.Visible = True
            Exit Sub
        End If

        If cboDivision.SelectedValue = "XXX" Then
            sMsg = "Seleccione una división."
            lblMensajeError.Text = sMsg
            lblMensajeError.Visible = True
            Exit Sub
        End If

        lblMensajeError.Text = ""
        lblMensajeError.Visible = False

        If rdSocio.Checked Then
            dlgS.sCveOfi = cboOficina.SelectedValue
            dlgS.sCveArea = cboDivision.SelectedValue

            If dlgS.ShowDialog() = Windows.Forms.DialogResult.OK Then
                sCveEmp = dlgS.sSocio
                txtColaborador.Text = dlgS.sNombre
            End If
        ElseIf rdGerente.Checked Then
            dlgG.sCveOfi = cboOficina.SelectedValue
            dlgG.sCveArea = cboDivision.SelectedValue
            If dlgG.ShowDialog() = Windows.Forms.DialogResult.OK Then
                sCveEmp = dlgG.sCveGer
                txtColaborador.Text = dlgG.sGerente
            End If
        End If
    End Sub

    Private Sub DlgColaboradorKardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarOficinas()
        ListarDivisiones()
    End Sub

    Private Sub ListarColaborador()
        Try
            Dim sTabla As String = "tbColaborador"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveEmp", sCveEmp, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtColaborador = .Item(sTabla)
            End With

            If dtColaborador.Rows.Count > 0 Then

            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarColaborador()")
            MsgBox(My.Settings.MSG_REPS, MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtColaborador = Nothing
        End Try
    End Sub
    Private Sub ListarOficinas()
        Try
            Dim sTabla As String = "tbOficinas"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtOficinas = .Item(sTabla)
            End With

            cboOficina.DataSource = dtOficinas
            cboOficina.DisplayMember = "DESCOFI"
            cboOficina.ValueMember = "CVEOFI"
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarOficinas()")
            MsgBox(My.Settings.MSG_REPS, MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtOficinas = Nothing
        End Try
    End Sub
    Private Sub ListarDivisiones()
        Try
            Dim sTabla As String = "tbDivisiones"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtDivisiones = .Item(sTabla)
            End With

            cboDivision.DataSource = dtDivisiones
            cboDivision.ValueMember = "CVEAREA"
            cboDivision.DisplayMember = "DESCAREA"
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDivisiones()")
            MsgBox(My.Settings.MSG_REPS, MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtDivisiones = Nothing
        End Try
    End Sub

End Class