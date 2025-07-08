Public Class DlgServicioGTI

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sStoredProc As String = "paTipoServicios"

    Private dtInfo, dtServicios As New DataTable
    Private drInfo As DataRow

    Public iOpcion, idCve, idCveDiv, idCveServ As Integer
    Public bHabilita As Boolean
    Public sTexto As String

    Private Sub DlgServicioGTI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridDatos.DataSource = bs
        DesplazamientoGrid(gridDatos)

        CrearTabla()

        Select Case iOpcion
            Case 1
                Text = "Líneas de Servicio - Nivel 1"
                lblTitulo.Text = "LÍNEAS DE SERVICIO - NIVEL 1"
                ListarServiciosNivelUno()

            Case 2
                Text = "Líneas de Servicio - Nivel 2"
                lblTitulo.Text = "LÍNEAS DE SERVICIO - NIVEL 2"
                ListarServiciosNivelDos()

            Case 3
                Text = "Líneas de Servicio - Nivel 3"
                lblTitulo.Text = "LÍNEAS DE SERVICIO - NIVEL 3"
                ListarServiciosNivelTres()
        End Select
    End Sub
    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridDatos.CurrentRow Is Nothing Then
            MsgBox("Seleccione la línea de servicio.", MsgBoxStyle.Exclamation, "SIAT")
            Return
        End If

        idCve = gridDatos.CurrentRow.Cells("CVE").Value
        sTexto = gridDatos.CurrentRow.Cells("DIVISION").Value.ToString().ToUpper()
        bHabilita = CBool(gridDatos.CurrentRow.Cells("VALOR").Value)

        DialogResult = DialogResult.OK
        Close()
    End Sub
    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    Private Sub GridDatos_DoubleClick(sender As Object, e As EventArgs) Handles gridDatos.DoubleClick
        If gridDatos.CurrentRow Is Nothing Then
            MsgBox("Seleccione la línea de servicio.", MsgBoxStyle.Exclamation, "SIAT")
            Return
        End If

        idCve = gridDatos.CurrentRow.Cells("CVE").Value
        sTexto = gridDatos.CurrentRow.Cells("DIVISION").Value.ToString().ToUpper()
        bHabilita = CBool(gridDatos.CurrentRow.Cells("VALOR").Value)

        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub CrearTabla()
        dtInfo.Columns.Add("TIPO", GetType(String))
        dtInfo.Columns.Add("CVE", GetType(String))
        dtInfo.Columns.Add("CVEDIVISION", GetType(String))
        dtInfo.Columns.Add("DIVISION", GetType(String))
        dtInfo.Columns.Add("VALOR", GetType(Boolean))
    End Sub
    Private Sub FormatoGrid()
        gridDatos.Columns("TIPO").Visible = False
        gridDatos.Columns("CVEDIVISION").Visible = False
        gridDatos.Columns("VALOR").Visible = False

        ConfigurarColumnasGrid(gridDatos, "CVE", "CVE.", 60, 3, False)
        ConfigurarColumnasGrid(gridDatos, "DIVISION", "DIVISIÓN", 0, 1, False)
    End Sub

    Private Sub ListarServiciosNivelUno()
        Try
            Dim sTabla As String = "tbNivelUno"

            LimpiarTabla(dtInfo)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable(sStoredProc, sTabla))
                dtServicios = .Item(sTabla)

                If dtServicios.Rows.Count > 0 Then

                    For Each dr As DataRow In dtServicios.Rows
                        drInfo = dtInfo.NewRow
                        drInfo("TIPO") = "S"
                        drInfo("CVE") = dr("ID").ToString()
                        drInfo("CVEDIVISION") = 0
                        drInfo("DIVISION") = dr("DIVISION").ToString().ToUpper
                        drInfo("VALOR") = False
                        dtInfo.Rows.InsertAt(drInfo, dtInfo.Rows.Count)
                    Next
                    bs.DataSource = dtInfo
                    FormatoGrid()
                End If
            End With
        Catch ex As Exception
            MsgBox("Por el momento no se posible mostrar el reporte, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub ListarServiciosNivelDos()
        Try
            Dim sTabla As String = "tbNivelDos"

            LimpiarTabla(dtInfo)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idCveDivision", idCveDiv, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable(sStoredProc, sTabla))
                dtServicios = .Item(sTabla)

                If dtServicios.Rows.Count > 0 Then

                    For Each dr As DataRow In dtServicios.Rows
                        drInfo = dtInfo.NewRow
                        drInfo("TIPO") = "S"
                        drInfo("CVE") = dr("ID").ToString()
                        drInfo("CVEDIVISION") = dr("IDDIVISION").ToString()
                        drInfo("DIVISION") = dr("SERVICIO").ToString().ToUpper
                        drInfo("VALOR") = CBool(dr("SUBSERVICIO").ToString())
                        dtInfo.Rows.InsertAt(drInfo, dtInfo.Rows.Count)
                    Next
                    bs.DataSource = dtInfo
                    FormatoGrid()
                End If
            End With
        Catch ex As Exception
            MsgBox("Por el momento no se posible mostrar el reporte, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub ListarServiciosNivelTres()
        Try
            Dim sTabla As String = "tbNivelTres"

            LimpiarTabla(dtInfo)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idClave", idCveServ, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable(sStoredProc, sTabla))
                dtServicios = .Item(sTabla)

                If dtServicios.Rows.Count > 0 Then

                    For Each dr As DataRow In dtServicios.Rows
                        drInfo = dtInfo.NewRow
                        drInfo("TIPO") = "S"
                        drInfo("CVE") = dr("CVE").ToString()
                        drInfo("CVEDIVISION") = dr("CVESERV").ToString()
                        drInfo("DIVISION") = dr("SUBSERVICIO").ToString().ToUpper
                        drInfo("VALOR") = False
                        dtInfo.Rows.InsertAt(drInfo, dtInfo.Rows.Count)
                    Next
                    bs.DataSource = dtInfo
                    FormatoGrid()
                End If
            End With
        Catch ex As Exception
            MsgBox("Por el momento no se posible mostrar el reporte, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub

End Class