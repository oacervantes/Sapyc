Public Class frmCtesDelPeriodo

    Private bsCtes As New BindingSource
    Private dtCtes As New DataTable
    Private Sub frmCtesDelPeriodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgCtes.DataSource = bsCtes

        ListarFolios()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim dlg As New dlgExcel

        Try
            If MsgBox("¿Desea exportar la información a Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Envío Excel") = MsgBoxResult.Yes Then
                dlg.txtArchivo.Focus()
                dlg.txtArchivo.Text = "Lista de Clientes del periodo"
                If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

                    exportarCtesPeriodo(objExcel, dgCtes, dlg.txtDirectorio.Text, dlg.txtArchivo.Text)

                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
        bsCtes.Filter = "CTE_PRINCIPAL LIKE '%" & txtCliente.Text & "%' "
    End Sub

    Private Sub ListarFolios()
        Try
            Dim sTabla As String = "tbCtes"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 20, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paIndependencia", sTabla))
                dtCtes = .Item(sTabla)

                If dtCtes.Rows.Count > 0 Then
                    bsCtes.DataSource = dtCtes
                    FormatoGrid()
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub FormatoGrid()
        'dgCtes.Columns("CVECTE_RELACION").Visible = False

        dgCtes.Columns("CVECTE").HeaderText = "CVE."
        dgCtes.Columns("CVECTE").Width = 80

        dgCtes.Columns("CTE_PRINCIPAL").HeaderText = "CLIENTE"
        dgCtes.Columns("CTE_PRINCIPAL").Width = 300

        dgCtes.Columns("CVECTE_RELACION").HeaderText = "CVE."
        dgCtes.Columns("CVECTE_RELACION").Width = 80

        dgCtes.Columns("CTE_RELACION").HeaderText = "CLIENTE RELACIONADO"
        dgCtes.Columns("CTE_RELACION").Width = 250

        dgCtes.Columns("CTE_REFERENCIA").HeaderText = "CLIENTE REFERENCIADO"
        dgCtes.Columns("CTE_REFERENCIA").Width = 250

        dgCtes.Columns("CVE_TRABAJO").HeaderText = "TRABAJO"
        dgCtes.Columns("CVE_TRABAJO").Width = 155
        dgCtes.Columns("CVE_TRABAJO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("SOCIO").HeaderText = "SOCIO"
        dgCtes.Columns("SOCIO").Width = 155
        dgCtes.Columns("SOCIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("GERENTE").HeaderText = "GERENTE"
        dgCtes.Columns("GERENTE").Width = 155
        dgCtes.Columns("GERENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("OFICINA").HeaderText = "OFICINA"
        dgCtes.Columns("OFICINA").Width = 90
        dgCtes.Columns("OFICINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("AREA").HeaderText = "DIVISIÓN"
        dgCtes.Columns("AREA").Width = 90
        dgCtes.Columns("AREA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("SERVICIO").HeaderText = "SERVICIO OFRECIDO"
        dgCtes.Columns("SERVICIO").Width = 300
        ''''''''''''''''''''''''''''''
        ''''''''SECCIÓN NUEVAS''''''''
        ''''''''''''''''''''''''''''''

        dgCtes.Columns("FECHAIND").HeaderText = "FECHA INDEPENDENCIA"
        dgCtes.Columns("FECHAIND").Width = 90
        dgCtes.Columns("FECHAIND").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("ESTATUS").HeaderText = "ESTATUS"
        dgCtes.Columns("ESTATUS").Width = 90
        dgCtes.Columns("ESTATUS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("TIPOPROPUESTA").HeaderText = "TIPOPROPUESTA"
        dgCtes.Columns("TIPOPROPUESTA").Width = 90
        dgCtes.Columns("TIPOPROPUESTA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("HONORARIOSPROP").HeaderText = "HONORARIOS PROPUESTA"
        dgCtes.Columns("HONORARIOSPROP").Width = 90
        dgCtes.Columns("HONORARIOSPROP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgCtes.Columns("HONORARIOSPROP").DefaultCellStyle.Format = "##,##0.00"

        dgCtes.Columns("HONORARIOS").HeaderText = "HONORARIOS"
        dgCtes.Columns("HONORARIOS").Width = 90
        dgCtes.Columns("HONORARIOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgCtes.Columns("HONORARIOS").DefaultCellStyle.Format = "##,##0.00"

        dgCtes.Columns("sPais").HeaderText = "PAÍS"
        dgCtes.Columns("sPais").Width = 90
        dgCtes.Columns("sPais").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("ESTADO").HeaderText = "ESTADO"
        dgCtes.Columns("ESTADO").Width = 90
        dgCtes.Columns("ESTADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("MUNICIPIO").HeaderText = "MUNICIPIO"
        dgCtes.Columns("MUNICIPIO").Width = 90
        dgCtes.Columns("MUNICIPIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("EMPTENEDORA").HeaderText = "EMPTENEDORA"
        dgCtes.Columns("EMPTENEDORA").Width = 90
        dgCtes.Columns("EMPTENEDORA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("BOLSAMEXICANA").HeaderText = "BOLSAMEXICANA"
        dgCtes.Columns("BOLSAMEXICANA").Width = 90
        dgCtes.Columns("BOLSAMEXICANA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("BOLSAEXTRANJERA").HeaderText = "BOLSAEXTRANJERA"
        dgCtes.Columns("BOLSAEXTRANJERA").Width = 90
        dgCtes.Columns("BOLSAEXTRANJERA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("HRSPROPUESTA").HeaderText = "HRS PROPUESTA"
        dgCtes.Columns("HRSPROPUESTA").Width = 45
        dgCtes.Columns("HRSPROPUESTA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("HRSTRABAJO").HeaderText = "HRS TRABAJO"
        dgCtes.Columns("HRSTRABAJO").Width = 45
        dgCtes.Columns("HRSTRABAJO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgCtes.Columns("CLASIFICACIONCTE").HeaderText = "CLASIFICACIÓN CLIENTE"
        dgCtes.Columns("CLASIFICACIONCTE").Width = 100
        dgCtes.Columns("CLASIFICACIONCTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


    End Sub

End Class