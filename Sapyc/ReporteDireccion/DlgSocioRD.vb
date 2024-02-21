Public Class DlgSocioRD

#Region "AUTOR"

    'AUTOR: OCTAVIO CERVANTES   
    'FECHA: 14 - ENERO - 2024

#End Region

#Region "VARIABLES"

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Buscar socio - Reporte de la Dirección"

    Private dtDatos, dtSocs As New DataTable
    Private drDatos As DataRow

    Public dtPermisos As New DataTable
    Public sSocio, sNombre, sCveOfi, sCveArea, sCveSocio, sTipo As String

#End Region

#Region "EVENTOS"

    Private Sub DlgSocioRD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gridDatos.DataSource = bs

        crearTabla()
        listarSocios()
    End Sub
    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        bs.Filter = "NOMBRE LIKE '%" & txtNombre.Text & "%'"
    End Sub
    Private Sub gridDatos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridDatos.DoubleClick
        If gridDatos.Rows.Count > 0 Then
            If Not gridDatos.CurrentRow Is Nothing Then
                sCveSocio = gridDatos.CurrentRow.Cells("CVEEMP").Value
                sNombre = gridDatos.CurrentRow.Cells("NOMBRE").Value
                sTipo = gridDatos.CurrentRow.Cells("TIPO").Value

                DialogResult = Windows.Forms.DialogResult.OK
                Close()
            End If
        Else
            MsgBox("No existen socios disponibles para reasignar el trabajo.", MsgBoxStyle.Exclamation, "Socio No Disponible")
        End If
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If gridDatos.Rows.Count > 0 Then
            If Not gridDatos.CurrentRow Is Nothing Then
                sCveSocio = gridDatos.CurrentRow.Cells("CVEEMP").Value
                sNombre = gridDatos.CurrentRow.Cells("NOMBRE").Value
                sTipo = gridDatos.CurrentRow.Cells("TIPO").Value

                DialogResult = Windows.Forms.DialogResult.OK
                Close()
            End If
        Else
            MsgBox("No se ha seleccionado a un socio para consultar.", MsgBoxStyle.Exclamation, "Socio No Disponible")
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

#End Region

#Region "SUBS"

    Private Sub crearTabla()
        dtDatos.Columns.Add("CVEEMP", GetType(System.String))
        dtDatos.Columns.Add("TIPO", GetType(System.String))
        dtDatos.Columns.Add("PUESTO", GetType(System.String))
        dtDatos.Columns.Add("NOMBRE", GetType(System.String))
    End Sub
    Private Sub listarSocios()
        Try
            Dim sTabla As String = "tbSocios"

            For Each dr As DataRow In dtPermisos.Rows

                With ds.Tables
                    LimpiarConsultaTabla(ds.Tables, sTabla)

                    With clsDatos
                        .subClearParameters()
                        .subAddParameter("@iOpcion", 100, SqlDbType.Int, ParameterDirection.Input)
                        .subAddParameter("@sCveSocio", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveOfi", dr("CVEOFI").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                        .subAddParameter("@sCveArea", dr("CVEAREA").ToString(), SqlDbType.VarChar, ParameterDirection.Input, 10)
                    End With

                    .Add(clsDatos.funExecuteSPDataTable("paReporteDireccion", sTabla))

                    dtSocs = .Item(sTabla)
                End With

                If dtSocs.Rows.Count > 0 Then
                    For Each r As DataRow In dtSocs.Rows
                        If sCveUsuario = r.Item("CVEEMP").ToString Then
                            Continue For
                        End If

                        If dtDatos.Select("CVEEMP = '" & r.Item("CVEEMP").ToString & "'").Count = 0 Then
                            drDatos = dtDatos.NewRow
                            drDatos("CVEEMP") = r.Item("CVEEMP").ToString
                            drDatos("TIPO") = r.Item("TIPO").ToString
                            drDatos("PUESTO") = r.Item("PUESTO").ToString
                            drDatos("NOMBRE") = r.Item("NOMBRE").ToString
                            dtDatos.Rows.InsertAt(drDatos, dtDatos.Rows.Count)
                        End If
                    Next
                End If
            Next

            bs.DataSource = dtDatos
            formatoGrid()
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "listarSocios()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dtSocs = Nothing
        End Try
    End Sub
    Private Sub formatoGrid()
        bloquearColumnas(gridDatos)

        gridDatos.Columns("CVEEMP").Visible = False
        gridDatos.Columns("TIPO").Visible = False
        'gridDatos.Columns("CVEOFI").Visible = False
        'gridDatos.Columns("CVEAREA").Visible = False

        gridDatos.Columns("PUESTO").HeaderText = "PUESTO"
        gridDatos.Columns("PUESTO").Width = 65
        gridDatos.Columns("NOMBRE").HeaderText = "NOMBRE"
        gridDatos.Columns("NOMBRE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

#End Region

End Class
