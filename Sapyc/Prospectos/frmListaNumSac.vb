Public Class frmListaNumSac
    Private dtSolicitudes, DtDatos As New DataTable
    Private bsSol As New BindingSource
    Private drDat As DataRow

    Private Sub frmListaNumSac_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lista.DataSource = bsSol

        crearTabla()
        ListaSolicitudes()

    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Hide()
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub btnExporta_Click(sender As Object, e As EventArgs) Handles btnExporta.Click
        Dim dlg As New dlgExcel

        Try
            If MsgBox("¿Desea exportar la información a Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Envío Excel") = MsgBoxResult.Yes Then
                dlg.txtArchivo.Focus()
                dlg.txtArchivo.Text = "Prospectos SAC"
                If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

                    exportarProspectosSac(objExcel, Lista, dlg.txtDirectorio.Text, dlg.txtArchivo.Text)

                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub crearTabla()
        DtDatos.Columns.Add("IDPROP", GetType(System.String))
        DtDatos.Columns.Add("NOMEMPRESA", GetType(System.String))
        DtDatos.Columns.Add("OFICINA", GetType(System.String))
        DtDatos.Columns.Add("AREA", GetType(System.String))
        DtDatos.Columns.Add("SOCIO", GetType(System.String))
        DtDatos.Columns.Add("GERENTE", GetType(System.String))
        DtDatos.Columns.Add("sSacDesc", GetType(System.String))
        DtDatos.Columns.Add("FECHA", GetType(System.String))
    End Sub
    Private Sub formatoGrid()
        For Each col As DataGridViewColumn In Lista.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        Lista.Columns("IDPROP").Visible = False

        Lista.Columns("NOMEMPRESA").HeaderText = "EMPRESA"
        Lista.Columns("NOMEMPRESA").Width = 250

        Lista.Columns("OFICINA").HeaderText = "OFICINA"
        Lista.Columns("OFICINA").Width = 150

        Lista.Columns("AREA").HeaderText = "DIVISIÓN"
        Lista.Columns("AREA").Width = 150

        Lista.Columns("SOCIO").HeaderText = "SOCIO"
        Lista.Columns("SOCIO").Width = 180

        Lista.Columns("GERENTE").HeaderText = "GERENTE"
        Lista.Columns("GERENTE").Width = 180

        Lista.Columns("sSacDesc").HeaderText = "NÚMERO SAC"
        Lista.Columns("sSacDesc").Width = 100

        Lista.Columns("FECHA").HeaderText = "FECHA ALTA"
        Lista.Columns("FECHA").Width = 100

    End Sub
    Private Sub ListaSolicitudes()
        Try
            Dim sTabla As String = "tbSol"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paControlSac", sTabla))
                dtSolicitudes = .Item(sTabla)

                If dtSolicitudes.Rows.Count > 0 Then

                    For Each dr As DataRow In dtSolicitudes.Rows

                        drDat = DtDatos.NewRow
                        drDat("IDPROP") = dr("IDPROP").ToString()
                        drDat("NOMEMPRESA") = dr("NOMEMPRESA").ToString()
                        drDat("OFICINA") = dr("OFICINA").ToString()
                        drDat("AREA") = dr("AREA").ToString()
                        drDat("SOCIO") = dr("SOCIO").ToString()
                        drDat("GERENTE") = dr("GERENTE").ToString()
                        drDat("sSacDesc") = dr("sSacDesc").ToString()
                        drDat("FECHA") = dr("FECHA").ToString()

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