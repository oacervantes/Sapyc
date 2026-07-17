Public Class FrmSeguimientoSolicitudesSAC

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Seguimiento de Solicitudes de Prospectos"

    Private dtSolicitudes As New DataTable

    Private Sub FrmSolicitudesAsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridProspectos.DataSource = bs
        DesplazamientoGrid(gridProspectos)

        ListarSolicitudes()
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub TxtProspecto_TextChanged(sender As Object, e As EventArgs) Handles txtProspecto.TextChanged
        If txtProspecto.TextLength > 0 And Not txtProspecto.Text.Contains("Nombre...") Then
            bs.Filter = "sNombreCte LIKE '%" & txtProspecto.Text & "%'"
        Else
            If bs.Filter IsNot Nothing Then
                If txtProspecto.TextLength > 0 And txtProspecto.Text.Contains("Nombre...") Then
                    bs.Filter = ""
                End If
            End If
        End If
    End Sub

    Private Sub TxtProspecto_Enter(sender As Object, e As EventArgs) Handles txtProspecto.Enter
        If txtProspecto.Text <> "" And txtProspecto.Text = "Nombre..." Then
            txtProspecto.Text = ""
            txtProspecto.ForeColor = Color.Black
        End If
    End Sub
    Private Sub TxtProspecto_Leave(sender As Object, e As EventArgs) Handles txtProspecto.Leave
        If DirectCast(sender, TextBox).Text = "" Then
            DirectCast(sender, TextBox).Text = "Nombre..."
            DirectCast(sender, TextBox).ForeColor = Color.Silver
        End If
    End Sub

    Private Sub RdSolicitudTodo_CheckedChanged(sender As Object, e As EventArgs) Handles rdSolicitudTodo.CheckedChanged
        If rdSolicitudTodo.Checked Then
            bs.RemoveFilter()
        End If
    End Sub
    Private Sub RdSolicitudAsigna_CheckedChanged(sender As Object, e As EventArgs) Handles rdSolicitudAsigna.CheckedChanged
        If rdSolicitudAsigna.Checked Then
            bs.Filter = "cStatus = 'S'"
        End If
    End Sub
    Private Sub RdSolicitudReasigna_CheckedChanged(sender As Object, e As EventArgs) Handles rdSolicitudReasigna.CheckedChanged
        If rdSolicitudReasigna.Checked Then
            bs.Filter = "cStatus = 'D'"
        End If
    End Sub
    Private Sub RdSolicitudOtros_CheckedChanged(sender As Object, e As EventArgs) Handles rdSolicitudOtros.CheckedChanged
        If rdSolicitudOtros.Checked Then
            bs.Filter = "cStatus = 'R'"
        End If
    End Sub
    Private Sub RdSolicitudBG_CheckedChanged(sender As Object, e As EventArgs) Handles rdSolicitudBG.CheckedChanged
        If rdSolicitudBG.Checked Then
            bs.Filter = "cStatus = 'J'"
        End If
    End Sub
    Private Sub RdSolicitudValidar_CheckedChanged(sender As Object, e As EventArgs) Handles rdSolicitudValidar.CheckedChanged
        If rdSolicitudValidar.Checked Then
            bs.Filter = "cStatus = 'A'"
        End If
    End Sub
    Private Sub RdSolicitudCancelada_CheckedChanged(sender As Object, e As EventArgs) Handles rdSolicitudCancelada.CheckedChanged
        If rdSolicitudCancelada.Checked Then
            bs.Filter = "cStatus = 'C'"
        End If
    End Sub
    Private Sub RdSolicitudCompleta_CheckedChanged(sender As Object, e As EventArgs) Handles rdSolicitudCompleta.CheckedChanged
        If rdSolicitudCompleta.Checked Then
            bs.Filter = "cStatus = 'T'"
        End If
    End Sub

    Private Sub ListarSolicitudes()
        Try
            Dim sTabla As String = "tbSolicitudes"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 17, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paSolicitudesSAC", sTabla))

                dtSolicitudes = .Item(sTabla)
            End With

            If dtSolicitudes.Rows.Count > 0 Then
                bs.DataSource = dtSolicitudes
                FormatoGrid()
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSolicitudes()")
            MsgBox("Por el momento no es posible consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtSolicitudes = Nothing
        End Try
    End Sub
    Private Sub FormatoGrid()
        gridProspectos.Columns("idPropuesta").Visible = False
        gridProspectos.Columns("sCveOfi").Visible = False
        gridProspectos.Columns("sCveArea").Visible = False
        gridProspectos.Columns("cStatus").Visible = False
        gridProspectos.Columns("bStatus").Visible = False
        gridProspectos.Columns("IdServicio").Visible = False
        gridProspectos.Columns("idIdioma").Visible = False
        gridProspectos.Columns("CVEENC").Visible = False
        gridProspectos.Columns("SOCENC").Visible = False
        gridProspectos.Columns("CORENC").Visible = False
        gridProspectos.Columns("sCveInd").Visible = False
        gridProspectos.Columns("sUsuario").Visible = False
        gridProspectos.Columns("NOMBRE").Visible = False
        gridProspectos.Columns("EMAIL").Visible = False
        gridProspectos.Columns("IdNormatividad").Visible = False
        gridProspectos.Columns("sCveSoc").Visible = False
        gridProspectos.Columns("sUsuarioEnvioAsigna").Visible = False
        gridProspectos.Columns("sUsuarioValidaAsigna").Visible = False
        gridProspectos.Columns("sUsuarioIngresoAsigna").Visible = False
        gridProspectos.Columns("sUsuarioSolicitoInd").Visible = False

        ConfigurarColumnasGrid(gridProspectos, "idSac", "ID. SAC", 65, 3, False)
        ConfigurarColumnasGrid(gridProspectos, "sNombreCte", "PROSPECTO", 300, 1, False)
        ConfigurarColumnasGrid(gridProspectos, "DESCOFI", "OFICINA", 90, 3, False)
        ConfigurarColumnasGrid(gridProspectos, "DESCAREA", "DIVISIÓN", 90, 3, False)
        ConfigurarColumnasGrid(gridProspectos, "SERVICIO", "SERVICIO", 300, 1, False)
        ConfigurarColumnasGrid(gridProspectos, "sStatus", "STATUS DE LA SOLICITUD", 250, 1, False)

        ConfigurarColumnasGrid(gridProspectos, "sNombreUsuario", "GENERÓ LA SOLICITUD", 250, 1, False)
        ConfigurarColumnasGrid(gridProspectos, "dFechaAlta", "FECHA DE ALTA", 150, 1, False)

        ConfigurarColumnasGrid(gridProspectos, "sSocioAsignado", "SOCIO ASIGNADO", 250, 1, False)
        ConfigurarColumnasGrid(gridProspectos, "dFechaEnvioAsigna", "FECHA DE ASIGNACIÓN", 150, 1, False)

        ConfigurarColumnasGrid(gridProspectos, "sEncargado", "ENCARGADO QUE VALIDÓ", 250, 1, False)
        ConfigurarColumnasGrid(gridProspectos, "dFechaValidaAsigna", "FECHA DE VALIDACIÓN", 150, 1, False)

        ConfigurarColumnasGrid(gridProspectos, "sSocioIngreso", "INGRESO A SOLICITUD ASIGNADA", 250, 1, False)
        ConfigurarColumnasGrid(gridProspectos, "dFechaIngresoAsigna", "FECHA DE INGRESO A SOL. ASIGNADA", 150, 1, False)

        ConfigurarColumnasGrid(gridProspectos, "sSocioSolicitoInd", "SOLICITÓ REVISIÓN IND.", 250, 1, False)
        ConfigurarColumnasGrid(gridProspectos, "dFechaSolicitudInd", "FECHA DE SOLICITUD DE REVISIÓN IND.", 150, 1, False)

        ConfigurarColumnasGrid(gridProspectos, "sStatusPropuesta", "STATUS DE LA PROPUESTA", 250, 1, False)
        ConfigurarColumnasGrid(gridProspectos, "DESCRECHAZO", "MOTIVO DE RECHAZO", 250, 1, False)

        ConfigurarColumnasGrid(gridProspectos, "CVETRA", "CVE. TRABAJO", 150, 1, False)
        ConfigurarColumnasGrid(gridProspectos, "TIPOPROPUESTA", "TIPO DE SOLICITUD", 95, 1, False)
    End Sub

End Class