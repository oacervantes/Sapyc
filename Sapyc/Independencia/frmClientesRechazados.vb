Public Class frmClientesRechazados
    Private bsSol As New BindingSource
    Private dtSolicitudes, DtDatos, dtCiclos, dtCiclosPeriodo As DataTable
    Private ds As New DataSet
    Private drDat As DataRow
    Private Sub frmClientesRechazados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridClaves.DataSource = bsSol
        crearTabla()
        ListaSolicitudes()
        listaCiclos()
    End Sub
    Private Sub ListaSolicitudes()
        Try
            If DtDatos.Rows.Count > 0 Then
                DtDatos.Clear()
            End If

            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 21, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paIndependencia") Then
                    .Remove("paIndependencia")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paIndependencia"))
                dtSolicitudes = .Item("paIndependencia")


                If dtSolicitudes.Rows.Count > 0 Then

                    For Each dr As DataRow In dtSolicitudes.Rows

                        drDat = DtDatos.NewRow
                        drDat("IDPROP") = dr("IDPROP").ToString()
                        drDat("NOMEMPRESA") = dr("NOMEMPRESA").ToString()
                        drDat("SOCIO") = dr("SOCIO").ToString()
                        drDat("GERENTE") = dr("GERENTE").ToString()
                        drDat("REGISTRADAEL") = CDate(dr("REGISTRADAEL").ToString()).ToShortDateString()
                        drDat("PERIODOSIAT") = dr("PERIODOSIAT").ToString()
                        drDat("MOTIVODELCONFLICTO") = dr("MOTIVODELCONFLICTO").ToString()
                        drDat("SERVICIO") = dr("SERVICIO").ToString()

                        DtDatos.Rows.InsertAt(drDat, DtDatos.Rows.Count)

                    Next

                    bsSol.DataSource = DtDatos
                    formatoGrid()
                End If


            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub crearTabla()
        DtDatos = New DataTable
        DtDatos.Columns.Add("IDPROP", GetType(System.String))
        DtDatos.Columns.Add("NOMEMPRESA", GetType(System.String))
        DtDatos.Columns.Add("SOCIO", GetType(System.String))
        DtDatos.Columns.Add("GERENTE", GetType(System.String))
        DtDatos.Columns.Add("REGISTRADAEL", GetType(System.String))
        DtDatos.Columns.Add("PERIODOSIAT", GetType(System.String))
        DtDatos.Columns.Add("MOTIVODELCONFLICTO", GetType(System.String))
        DtDatos.Columns.Add("SERVICIO", GetType(System.String))
    End Sub
    Private Sub rdTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdTodos.CheckedChanged
        cmbPeriodo.Enabled = False
        ListaSolicitudes()
    End Sub
    Private Sub rdPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles rdPeriodo.CheckedChanged
        cmbPeriodo.Enabled = True
    End Sub

    Private Sub cmbPeriodo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbPeriodo.SelectionChangeCommitted
        If cmbPeriodo.SelectedIndex <> -1 Then
            ListaSolicitudesCiclo()
        End If
    End Sub

    Private Sub formatoGrid()
        gridClaves.Columns("IDPROP").Visible = False

        gridClaves.Columns("NOMEMPRESA").HeaderText = "NOMBRE EMPRESA"
        gridClaves.Columns("NOMEMPRESA").Width = 300

        gridClaves.Columns("SOCIO").HeaderText = "SOCIO"
        gridClaves.Columns("SOCIO").Width = 200

        gridClaves.Columns("GERENTE").HeaderText = "GERENTE"
        gridClaves.Columns("GERENTE").Width = 200

        gridClaves.Columns("REGISTRADAEL").HeaderText = "FECHA ALTA"
        gridClaves.Columns("REGISTRADAEL").Width = 120

        gridClaves.Columns("PERIODOSIAT").HeaderText = "PERIODO"
        gridClaves.Columns("PERIODOSIAT").Width = 120


        gridClaves.Columns("MOTIVODELCONFLICTO").HeaderText = "MOTIVO DEL CONFLICTO"
        gridClaves.Columns("MOTIVODELCONFLICTO").Width = 500

        gridClaves.Columns("SERVICIO").HeaderText = "SERVICIO"
        gridClaves.Columns("SERVICIO").Width = 100


    End Sub
    Private Sub listaCiclos()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 22, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paIndependencia") Then
                    .Remove("paIndependencia")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paIndependencia"))

                dtCiclos = .Item("paIndependencia")
                If dtCiclos.Rows.Count > 0 Then
                    cmbPeriodo.DataSource = dtCiclos
                    cmbPeriodo.ValueMember = "Periodo"
                    cmbPeriodo.DisplayMember = "DESCRIPCION"
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub ListaSolicitudesCiclo()
        Try
            If DtDatos.Rows.Count > 0 Then
                DtDatos.Clear()
            End If

            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 23, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@Ciclo", cmbPeriodo.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paIndependencia") Then
                    .Remove("paIndependencia")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paIndependencia"))
                dtSolicitudes = .Item("paIndependencia")


                If dtSolicitudes.Rows.Count > 0 Then

                    For Each dr As DataRow In dtSolicitudes.Rows

                        drDat = DtDatos.NewRow
                        drDat("IDPROP") = dr("IDPROP").ToString()
                        drDat("NOMEMPRESA") = dr("NOMEMPRESA").ToString()
                        drDat("SOCIO") = dr("SOCIO").ToString()
                        drDat("GERENTE") = dr("GERENTE").ToString()
                        drDat("REGISTRADAEL") = CDate(dr("REGISTRADAEL").ToString()).ToShortDateString()
                        drDat("PERIODOSIAT") = dr("PERIODOSIAT").ToString()
                        drDat("MOTIVODELCONFLICTO") = dr("MOTIVODELCONFLICTO").ToString()
                        drDat("SERVICIO") = dr("SERVICIO").ToString()

                        DtDatos.Rows.InsertAt(drDat, DtDatos.Rows.Count)

                    Next

                    bsSol.DataSource = DtDatos
                    formatoGrid()
                End If


            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class