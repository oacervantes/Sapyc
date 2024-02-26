Public Class frmReportePorClaves

    Private bsSol As New BindingSource
    Private ds As New DataSet

    Private dtSolicitudes, DtDatos, dtColgados As New DataTable
    Private drDat As DataRow

    Private Sub frmReportePorClaves_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridClaves.DataSource = bsSol

        crearTabla()
        ListaSolicitudes()
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim dlg As New dlgExcel

        Try
            If MsgBox("¿Desea exportar la información a Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Envío Excel") = MsgBoxResult.Yes Then
                dlg.txtArchivo.Focus()
                dlg.txtArchivo.Text = "Reporte Trabajos por cliente"
                If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

                    ' exportarTrabajos(objExcel, gridClaves, dlg.txtDirectorio.Text, dlg.txtArchivo.Text)

                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub crearTabla()
        DtDatos.Columns.Add("CLIENTE", GetType(System.String))
        DtDatos.Columns.Add("TRABAJO", GetType(System.String))
        DtDatos.Columns.Add("OFICINA", GetType(System.String))
        DtDatos.Columns.Add("DIVISION", GetType(System.String))
        DtDatos.Columns.Add("DESCRIPCION", GetType(System.String))
        DtDatos.Columns.Add("SERVICIO", GetType(System.String))
        DtDatos.Columns.Add("ALTA", GetType(System.String))
        DtDatos.Columns.Add("BAJA", GetType(System.String))
        DtDatos.Columns.Add("ESTATUS", GetType(System.String))
        DtDatos.Columns.Add("SOCIO", GetType(System.String))
        DtDatos.Columns.Add("HONORARIOS", GetType(System.String))
    End Sub
    Private Sub formatoGrid()
        gridClaves.Columns("CLIENTE").HeaderText = "CLIENTE"
        gridClaves.Columns("CLIENTE").Width = 250

        gridClaves.Columns("TRABAJO").HeaderText = "TRABAJO"
        gridClaves.Columns("TRABAJO").Width = 150

        gridClaves.Columns("OFICINA").HeaderText = "OFICINA"
        gridClaves.Columns("OFICINA").Width = 80

        gridClaves.Columns("DIVISION").HeaderText = "DIVISION"
        gridClaves.Columns("DIVISION").Width = 120

        gridClaves.Columns("DESCRIPCION").HeaderText = "DESCRIPCION"
        gridClaves.Columns("DESCRIPCION").Width = 200

        gridClaves.Columns("SERVICIO").HeaderText = "SERVICIO"
        gridClaves.Columns("SERVICIO").Width = 250

        gridClaves.Columns("ALTA").HeaderText = "ALTA"
        gridClaves.Columns("ALTA").Width = 100

        gridClaves.Columns("BAJA").HeaderText = "BAJA"
        gridClaves.Columns("BAJA").Width = 100

        gridClaves.Columns("ESTATUS").HeaderText = "ESTATUS"
        gridClaves.Columns("ESTATUS").Width = 80

        gridClaves.Columns("SOCIO").HeaderText = "SOCIO"
        gridClaves.Columns("SOCIO").Width = 200

        gridClaves.Columns("HONORARIOS").HeaderText = "HONORARIOS"
        gridClaves.Columns("HONORARIOS").Width = 150
        gridClaves.Columns("HONORARIOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub ListaSolicitudes()
        Try
            Dim sTabla As String = "tbClientes"
            limpiarFilasTabla(DtDatos)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 19, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paIndependencia", sTabla))
                dtSolicitudes = .Item(sTabla)
            End With

            If dtSolicitudes.Rows.Count > 0 Then

                For Each dr As DataRow In dtSolicitudes.Rows

                    drDat = DtDatos.NewRow
                    drDat("CLIENTE") = dr("NOMBRECTE").ToString()
                    drDat("TRABAJO") = dr("CVETRA").ToString()
                    drDat("OFICINA") = dr("DESCOFI").ToString()
                    drDat("DIVISION") = dr("DESCAREA").ToString()
                    drDat("DESCRIPCION") = dr("DESCRIPCION").ToString()
                    drDat("SERVICIO") = dr("SERVICIO").ToString()
                    drDat("ALTA") = CDate(dr("FECHAALTA")).ToShortDateString()
                    If dr("FECHABAJA") = "1900-01-01" Then
                        drDat("BAJA") = ""
                    Else
                        drDat("BAJA") = CDate(dr("FECHABAJA")).ToShortDateString()
                    End If
                    drDat("ESTATUS") = dr("STATUS").ToString()
                    drDat("SOCIO") = dr("NOMBRE").ToString()
                    drDat("HONORARIOS") = Format(CDec(dr("HONORARIOS").ToString()), sFmtDbl)

                    DtDatos.Rows.InsertAt(drDat, DtDatos.Rows.Count)

                Next

                bsSol.DataSource = DtDatos
                formatoGrid()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class