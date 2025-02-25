Public Class frmAutorizaSolicitudFolios

    Private ds As New DataSet
    Private bs As New BindingSource

    Private sNameRpt As String = "autoriza folio de informe"

    Private dtSolicitudes, dtAutorizacion As New DataTable
    Public sCvetra, sCliente, sSocioSol, sMotivoSolicitud, sMail, sNombreSol As String
    Public dImpest, dImpcob, dImppc As Decimal

    Private Sub frmAutorizaSolicitudFolios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridDatos.DataSource = bs

        CreaTabla()
        ListaSolicitudes()
    End Sub
    Private Sub btnRevisar_Click(sender As Object, e As EventArgs) Handles btnRevisar.Click
        If gridDatos.SelectedRows.Count > 0 Then
            sSocioSol = gridDatos.CurrentRow.Cells("CVEEMPSOL").Value
            sCliente = gridDatos.CurrentRow.Cells("CLIENTE").Value
            sNombreSol = gridDatos.CurrentRow.Cells("SOLICITO").Value

            sCvetra = gridDatos.CurrentRow.Cells("CVETRA").Value
            sMail = gridDatos.CurrentRow.Cells("EMAIL").Value

            If IsDBNull(gridDatos.CurrentRow.Cells("MOTIVOSOLICITUD").Value) Then
                sMotivoSolicitud = ""
            Else
                sMotivoSolicitud = gridDatos.CurrentRow.Cells("MOTIVOSOLICITUD").Value
            End If



            dImpest = gridDatos.CurrentRow.Cells("IMPEST").Value
            dImpcob = gridDatos.CurrentRow.Cells("IMPCOB").Value
            dImppc = gridDatos.CurrentRow.Cells("IMPPC").Value

            Dim Dlg As New frmDetalleAutorizaSolicitudFolio

            Dlg.sMotivoSolicitud = sMotivoSolicitud
            Dlg.sSocioSol = sSocioSol
            Dlg.sCvetra = sCvetra
            Dlg.sCliente = sCliente
            Dlg.sNombreSol = sNombreSol
            Dlg.sMail = sMail
            Dlg.dImpest = dImpest
            Dlg.dImpcob = dImpcob
            Dlg.dImppc = dImppc

            If Dlg.ShowDialog() = DialogResult.OK Then
                ListaSolicitudes()
            End If
        End If
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub CreaTabla()
        dtSolicitudes.Columns.Add("CVEEMPSOL", GetType(System.String))
        dtSolicitudes.Columns.Add("SOLICITO", GetType(System.String))
        dtSolicitudes.Columns.Add("CVETRA", GetType(System.String))
        dtSolicitudes.Columns.Add("CLIENTE", GetType(System.String))
        dtSolicitudes.Columns.Add("IMPEST", GetType(System.Decimal))
        dtSolicitudes.Columns.Add("IMPCOB", GetType(System.Decimal))
        dtSolicitudes.Columns.Add("IMPPC", GetType(System.Decimal))
        dtSolicitudes.Columns.Add("FECHASOL", GetType(System.String))
        dtSolicitudes.Columns.Add("MOTIVOSOLICITUD", GetType(System.String))

    End Sub
    Private Sub ListaSolicitudes()
        Try
            Dim sTabla As String = "tbAutoriza"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 15, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveEmp", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosInv.funExecuteSPDataTable("paFoliosInforme", sTabla))

                dtAutorizacion = .Item(sTabla)

                bs.DataSource = dtAutorizacion
                FormatoGrid()
            End With
        Catch ex As Exception
            ' insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "AutorizaSolFolios()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtAutorizacion = Nothing
        End Try
    End Sub
    Private Sub FormatoGrid()
        bloquearColumnas(gridDatos)

        gridDatos.Columns("CVEEMPSOL").Visible = False
        gridDatos.Columns("MOTIVOSOLICITUD").Visible = False

        gridDatos.Columns("SOLICITO").HeaderText = "SOLICITO"
        gridDatos.Columns("SOLICITO").Width = 250

        gridDatos.Columns("CVETRA").HeaderText = "CVETRA"
        gridDatos.Columns("CVETRA").Width = 150

        gridDatos.Columns("CLIENTE").HeaderText = "CLIENTE"
        gridDatos.Columns("CLIENTE").Width = 250
        gridDatos.Columns("CLIENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        gridDatos.Columns("IMPEST").HeaderText = "HONORARIOS ESTIMADOS"
        gridDatos.Columns("IMPEST").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridDatos.Columns("IMPEST").Width = 110
        gridDatos.Columns("IMPEST").DefaultCellStyle.Format = sFmtDbl

        gridDatos.Columns("IMPCOB").HeaderText = "HONORARIOS COBRADOS"
        gridDatos.Columns("IMPCOB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridDatos.Columns("IMPCOB").Width = 110
        gridDatos.Columns("IMPCOB").DefaultCellStyle.Format = sFmtDbl

        gridDatos.Columns("IMPPC").HeaderText = "HONORARIOS POR COBRAR"
        gridDatos.Columns("IMPPC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridDatos.Columns("IMPPC").Width = 110
        gridDatos.Columns("IMPPC").DefaultCellStyle.Format = sFmtDbl

        gridDatos.Columns("FECHASOL").HeaderText = "FECHA SOLICITUD"
        gridDatos.Columns("FECHASOL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridDatos.Columns("FECHASOL").DefaultCellStyle.Format = "dd/MM/yyyy"
    End Sub

End Class