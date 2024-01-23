Public Class frmConsultaFolios

    Private dtFolios As DataTable
    Private bsFolios As New BindingSource

    Private Sub frmConsultaFolios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgFolios.DataSource = bsFolios
        ListarFolios()

    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim dlg As New dlgExcel

        Try
            If MsgBox("¿Desea exportar la información a Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Envío Excel") = MsgBoxResult.Yes Then
                dlg.txtArchivo.Focus()
                dlg.txtArchivo.Text = "Folios"
                If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

                    exportarFolios(objExcel, dgFolios, dlg.txtDirectorio.Text, dlg.txtArchivo.Text)

                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ListarFolios()
        Try
            Dim sTabla As String = "tbFolios"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)

                End With

                .Add(clsDatosInv.funExecuteSPDataTable("paFoliosInforme", sTabla))
                dtFolios = .Item(sTabla)

                If dtFolios.Rows.Count > 0 Then
                    bsFolios.DataSource = dtFolios
                    FormatoGrid()
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub FormatoGrid()
        dgFolios.Columns("OPINION").Frozen = True
        dgFolios.Columns("PRINCIPAL").Frozen = True
        dgFolios.Columns("OPINION").Width = 150
        dgFolios.Columns("OPINION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgFolios.Columns("PRINCIPAL").Width = 300
        dgFolios.Columns("CTE. RELACIONADO").Width = 300
        dgFolios.Columns("SOCIO").Width = 250
        dgFolios.Columns("ASOCIADO").Width = 250
        dgFolios.Columns("OFICINA").Width = 140
        dgFolios.Columns("DIVISION").Width = 150
        dgFolios.Columns("INFORME").Width = 220
        dgFolios.Columns("INFORME RELATIVO").Width = 270
        dgFolios.Columns("TIPO OPINION").Width = 220
        dgFolios.Columns("DETALLE OPINION").Width = 270
        dgFolios.Columns("BASADO EN").Width = 220
        dgFolios.Columns("DETALLE BASADO EN").Width = 270
        dgFolios.Columns("IDIOMA").Width = 220
        dgFolios.Columns("OTRO IDIOMA").Width = 270
        dgFolios.Columns("FECHA OPINION").Width = 95
        dgFolios.Columns("FECHA OPINION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgFolios.Columns("FECHA DEL PERIODO").Width = 95
        dgFolios.Columns("FECHA DEL PERIODO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgFolios.Columns("CLAVE TRABAJO").Width = 145
        dgFolios.Columns("CLAVE TRABAJO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgFolios.Columns("ESTATUS").Width = 60
        dgFolios.Columns("ESTATUS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgFolios.Columns("MOTIVO CANCELACION").Width = 300
        dgFolios.Columns("REGISTRADA").Width = 95
        dgFolios.Columns("REGISTRADA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgFolios.Columns("REGISTRADO POR").Width = 250
        dgFolios.Columns("TIENE LEAP | VOYAGER").Width = 100
        dgFolios.Columns("TIENE LEAP | VOYAGER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgFolios.Columns("ARCHIVO LEAP | VOYAGER").Width = 250
    End Sub


End Class