Public Class frmSolRelacionadas

    Private dtSolicitudes, DtDatos As DataTable
    Private bsSol As New BindingSource
    Public IdProp As Integer
    Private drDat As DataRow

    Private Sub frmSolRelacionadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Lista.DataSource = bsSol
        crearTabla()
        ListaSolicitudes()
    End Sub
    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        HabilitaMenu()
        Me.Hide()
        Me.Dispose()
    End Sub
    Private Sub ListaSolicitudes()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)

                End With

                If .Contains("paIndependencia") Then
                    .Remove("paIndependencia")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paIndependencia"))
                dtSolicitudes = .Item("paIndependencia")

                If dtSolicitudes.Rows.Count > 0 Then

                    For Each dr As DataRow In dtSolicitudes.Rows

                        drDat = DtDatos.NewRow
                        drDat("FOLIO") = dr("IDPROP").ToString()
                        drDat("NOMCONTINICIAL") = dr("NOMEMPRESA").ToString()
                        drDat("OFICINA") = dr("OFICINA").ToString()
                        drDat("DIVISION") = dr("DIVISION").ToString()
                        'drDat("SOCIO") = dr("SOCIO").ToString()
                        drDat("REGISTRADAEL") = CDate(dr("REGISTRADAEL")).ToShortDateString()

                        drDat("FECHSOLIND") = CDate(dr("FECHSOLIND")).ToShortDateString()
                        drDat("ESTATUS") = dr("ESTATUS").ToString()
                        drDat("TIPO") = dr("TIPO").ToString()
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
    Private Sub formatoGrid()
        Try
            'For Each col As DataGridViewColumn In Me.Lista.Columns
            '    col.SortMode = DataGridViewColumnSortMode.NotSortable
            'Next

            Me.Lista.Columns("FOLIO").Visible = False

            Me.Lista.Columns("NOMCONTINICIAL").HeaderText = "CONTACTO INICIAL"
            Me.Lista.Columns("NOMCONTINICIAL").Width = 250

            Me.Lista.Columns("OFICINA").HeaderText = "OFICINA"
            Me.Lista.Columns("OFICINA").Width = 100

            Me.Lista.Columns("DIVISION").HeaderText = "DIVISION"
            Me.Lista.Columns("DIVISION").Width = 100

            'Me.Lista.Columns("SOCIO").HeaderText = "SOCIO"
            'Me.Lista.Columns("SOCIO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            Me.Lista.Columns("ESTATUS").HeaderText = "ESTATUS"
            Me.Lista.Columns("ESTATUS").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            Me.Lista.Columns("REGISTRADAEL").HeaderText = "FECHA PROPUESTA"
            Me.Lista.Columns("REGISTRADAEL").Width = 100

            Me.Lista.Columns("TIPO").HeaderText = "TIPO PROPUESTA"
            Me.Lista.Columns("TIPO").Width = 100

            Me.Lista.Columns("FECHSOLIND").HeaderText = "FECHA SOLICITÓ"
            Me.Lista.Columns("FECHSOLIND").Width = 100

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Lista_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Lista.CellBeginEdit
        If e.ColumnIndex < 7 Then
            e.Cancel = True
        End If
    End Sub
    Private Sub Lista_DoubleClick(sender As Object, e As EventArgs) Handles Lista.Click

        Dim dlg As New FrmPropuestasNvo

        Try
            If Me.Lista.Rows.Count > 0 Then
                If Not Me.Lista.CurrentRow Is Nothing Then

                    dlg.IdProp = Lista.CurrentRow.Cells("FOLIO").Value
                    'dlg.TpCon = "I"
                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

                        ListaSolicitudes()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub Bguardar_Click(sender As Object, e As EventArgs) Handles Bguardar.Click
        Dim dlg As New FrmPropuestasNvo

        Try
            If Me.Lista.Rows.Count > 0 Then
                If Not Me.Lista.CurrentRow Is Nothing Then

                    dlg.IdProp = Lista.CurrentRow.Cells("FOLIO").Value
                    ' dlg.TpCon = "I"
                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

                        ListaSolicitudes()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub crearTabla()
        DtDatos = New DataTable
        DtDatos.Columns.Add("FOLIO", GetType(System.String))
        DtDatos.Columns.Add("NOMCONTINICIAL", GetType(System.String))
        DtDatos.Columns.Add("OFICINA", GetType(System.String))
        DtDatos.Columns.Add("DIVISION", GetType(System.String))
        DtDatos.Columns.Add("REGISTRADAEL", GetType(System.String))
        DtDatos.Columns.Add("ESTATUS", GetType(System.String))
        DtDatos.Columns.Add("TIPO", GetType(System.String))
        DtDatos.Columns.Add("FECHSOLIND", GetType(System.String))

    End Sub

End Class