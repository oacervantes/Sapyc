Public Class frmListaNumSac

    Private bsSol As New BindingSource

    Private dtSolicitudes, DtDatos As New DataTable
    Private drDat As DataRow

    Private Sub FrmListaNumSac_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridDatos.DataSource = bsSol
        DesplazamientoGrid(gridDatos)

        CrearTabla()
        ListaSolicitudes()
    End Sub
    Private Sub BtnExporta_Click(sender As Object, e As EventArgs) Handles btnExporta.Click
        Dim dlg As New dlgExcel

        Try
            If MsgBox("¿Desea exportar la información a Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Envío Excel") = MsgBoxResult.Yes Then
                dlg.txtArchivo.Focus()
                dlg.txtArchivo.Text = "Revisión de prospectos"
                If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

                    ExportarProspectosSAC(gridDatos, dlg.txtDirectorio.Text, dlg.txtArchivo.Text)
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub CrearTabla()
        DtDatos.Columns.Add("TIPO", GetType(String))
        DtDatos.Columns.Add("IDPROP", GetType(String))
        DtDatos.Columns.Add("sSacDesc", GetType(String))
        DtDatos.Columns.Add("NOMEMPRESA", GetType(String))
        DtDatos.Columns.Add("OFICINA", GetType(String))
        DtDatos.Columns.Add("AREA", GetType(String))
        DtDatos.Columns.Add("SOCIO", GetType(String))
        DtDatos.Columns.Add("GERENTE", GetType(String))
        DtDatos.Columns.Add("FECHA", GetType(String))
    End Sub
    Private Sub FormatoGrid()
        BloquearColumnas(gridDatos)

        gridDatos.Columns("TIPO").Visible = False
        gridDatos.Columns("IDPROP").Visible = False

        ConfigurarColumnasGrid(gridDatos, "NOMEMPRESA", "EMPRESA", 270, 1, False)
        ConfigurarColumnasGrid(gridDatos, "OFICINA", "OFICINA", 90, 3, False)
        ConfigurarColumnasGrid(gridDatos, "AREA", "DIVISIÓN", 90, 3, False)
        ConfigurarColumnasGrid(gridDatos, "SOCIO", "SOCIO", 250, 1, False)
        ConfigurarColumnasGrid(gridDatos, "GERENTE", "GERENTE", 250, 1, False)
        ConfigurarColumnasGrid(gridDatos, "sSacDesc", "ID ASIGNACIÓN SAC", 120, 1, False)
        ConfigurarColumnasGrid(gridDatos, "FECHA", "FECHA ALTA", 100, 3, False)
    End Sub

    Private Sub ListaSolicitudes()
        Try
            Dim sTabla As String = "tbSol"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paControlSac", sTabla))
                dtSolicitudes = .Item(sTabla)

                If dtSolicitudes.Rows.Count > 0 Then

                    For Each dr As DataRow In dtSolicitudes.Rows

                        drDat = DtDatos.NewRow
                        drDat("TIPO") = "S"
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
                    FormatoGrid()
                End If
            End With
        Catch ex As Exception
            MsgBox("Por el momento no se posible mostrar el reporte, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub

End Class