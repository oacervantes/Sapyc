Public Class Solicitudes

    Private dtSolicitudes, DtDatos As New DataTable
    Private bsSol As New BindingSource
    Public IdProp As Integer
    Private drDat As DataRow

    Private Sub Solicitudes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtDatos = New DataTable()


        Lista.DataSource = bsSol

        crearTabla()
        ListaSolicitudes()
    End Sub
    Private Sub Bguardar_Click(sender As Object, e As EventArgs) Handles Bguardar.Click
        Dim dlg As New FrmPropuestasNvo

        Try
            If Me.Lista.Rows.Count > 0 Then
                If Not Me.Lista.CurrentRow Is Nothing Then

                    dlg.IdProp = Lista.CurrentRow.Cells("FOLIO").Value
                    'dlg.TpCon = "I"
                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.Lista.DataSource = bsSol
                        'crearTabla()
                        ListaSolicitudes()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        HabilitaMenu()
        Me.Hide()
        Me.Dispose()
    End Sub
    Private Sub Lista_DoubleClick(sender As Object, e As EventArgs) Handles Lista.DoubleClick

        Dim dlg As New FrmPropuestasNvo

        Try
            If Me.Lista.Rows.Count > 0 Then
                If Not Me.Lista.CurrentRow Is Nothing Then

                    dlg.IdProp = Lista.CurrentRow.Cells("FOLIO").Value
                    'dlg.TpCon = "I"
                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.Lista.DataSource = bsSol
                        'crearTabla()
                        ListaSolicitudes()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub


    Private Sub crearTabla()
        DtDatos.Columns.Add("FOLIO", GetType(System.String))
        DtDatos.Columns.Add("NOMCONTINICIAL", GetType(System.String))
        DtDatos.Columns.Add("CTEFISCAL", GetType(System.String))
        DtDatos.Columns.Add("OFICINA", GetType(System.String))
        DtDatos.Columns.Add("DIVISION", GetType(System.String))
        DtDatos.Columns.Add("REGISTRADAEL", GetType(System.String))
        DtDatos.Columns.Add("ESTATUS", GetType(System.String))
        DtDatos.Columns.Add("FECHSOLIND", GetType(System.String))
    End Sub
    Private Sub formatoGrid()
        For Each col As DataGridViewColumn In Lista.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        Lista.Columns("FOLIO").Visible = False

        Lista.Columns("NOMCONTINICIAL").HeaderText = "CONTACTO INICIAL"
        Lista.Columns("NOMCONTINICIAL").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Lista.Columns("CTEFISCAL").HeaderText = "CLIENTE FISCAL"
        Lista.Columns("CTEFISCAL").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Lista.Columns("OFICINA").HeaderText = "OFICINA"
        Lista.Columns("OFICINA").Width = 150

        Lista.Columns("DIVISION").HeaderText = "DIVISIÓN"
        Lista.Columns("DIVISION").Width = 150

        'Lista.Columns("SOCIO").HeaderText = "SOCIO"
        'Lista.Columns("SOCIO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Lista.Columns("ESTATUS").HeaderText = "STATUS"
        Lista.Columns("ESTATUS").Width = 150

        Lista.Columns("REGISTRADAEL").HeaderText = "FECHA DE PROPUESTA"
        Lista.Columns("REGISTRADAEL").Width = 100

        Lista.Columns("FECHSOLIND").HeaderText = "FECHA DE SOLICITUD"
        Lista.Columns("FECHSOLIND").Width = 100
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
                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paIndependencia", sTabla))
                dtSolicitudes = .Item(sTabla)

                If dtSolicitudes.Rows.Count > 0 Then

                    For Each dr As DataRow In dtSolicitudes.Rows

                        drDat = DtDatos.NewRow
                        drDat("FOLIO") = dr("IDPROP").ToString()
                        drDat("NOMCONTINICIAL") = dr("NOMEMPRESA").ToString()
                        drDat("CTEFISCAL") = dr("CTEFISCAL").ToString()
                        drDat("OFICINA") = dr("OFICINA").ToString()
                        drDat("DIVISION") = dr("DIVISION").ToString()
                        'drDat("SOCIO") = dr("SOCIO").ToString()
                        drDat("REGISTRADAEL") = CDate(dr("REGISTRADAEL")).ToShortDateString()

                        drDat("FECHSOLIND") = CDate(dr("FECHSOLIND")).ToShortDateString()
                        drDat("ESTATUS") = dr("ESTATUS").ToString()
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