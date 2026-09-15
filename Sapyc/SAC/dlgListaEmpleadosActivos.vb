Public Class dlgListaEmpleadosActivos

#Region "VARIABLES"

    Private bs As New BindingSource
    Private ds As New DataSet

    Private dtDatos As DataTable
    Private sQuery, sAreas As String

    Public sSocio, sNombre, sCveOfi, sCveArea, sCveSocio, sCveGpo As String
    Public iSocioEnc, iTipoSocio As Integer

#End Region


#Region "EVENTOS"
    Private Sub dlgListaEmpleadosActivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridDatos.DataSource = bs
        listarEmpleados()

    End Sub


    Private Sub txtNombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombre.TextChanged
        'listarGerentes()
        bs.Filter = "NOMBRE LIKE '%" & txtNombre.Text & "%'"
    End Sub
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If gridDatos.Rows.Count > 0 Then
            If Not gridDatos.CurrentRow Is Nothing Then
                sSocio = gridDatos.CurrentRow.Cells("CVEEMP").Value
                sNombre = gridDatos.CurrentRow.Cells("NOMBRE").Value
                sCveOfi = gridDatos.CurrentRow.Cells("CVEOFI").Value
                sCveArea = gridDatos.CurrentRow.Cells("CVEAREA").Value
                sCveGpo = gridDatos.CurrentRow.Cells("CVEGPO").Value
                'Me.gridDatos.CurrentRow.Cells("iTipoSocio").Value
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            MsgBox("No existen socios disponibles para reasignar el trabajo.", MsgBoxStyle.Exclamation, "Socio No Disponible")
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub gridDatos_DoubleClick(sender As System.Object, e As System.EventArgs) Handles gridDatos.DoubleClick
        If Not gridDatos.CurrentRow Is Nothing Then
            sSocio = gridDatos.CurrentRow.Cells("CVEEMP").Value
            sNombre = gridDatos.CurrentRow.Cells("NOMBRE").Value
            sCveOfi = gridDatos.CurrentRow.Cells("CVEOFI").Value
            sCveArea = gridDatos.CurrentRow.Cells("CVEAREA").Value
            sCveGpo = gridDatos.CurrentRow.Cells("GPO").Value
            'Me.gridDatos.CurrentRow.Cells("iTipoSocio").Value
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

#End Region

#Region "SUBS"

    Private Sub listarEmpleados()
        Try
            Dim sTabla As String = "tbEmpleadosBusqueda"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    '.subAddParameter("@iTipoSocio", iTipoSocioObj, SqlDbType.Int, ParameterDirection.Input)
                    '.subAddParameter("@sCveSocio", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input, 10)
                    '.subAddParameter("@sCveOfi", sCveOfiObj, SqlDbType.VarChar, ParameterDirection.Input, 10)
                    '.subAddParameter("@sCveArea", sCveAreaObj, SqlDbType.VarChar, ParameterDirection.Input, 10)
                    '.subAddParameter("@sCveGpo", sCveGpoObj, SqlDbType.VarChar, ParameterDirection.Input, 10)
                    '.subAddParameter("@sNombre", txtNombre.Text, SqlDbType.VarChar, ParameterDirection.Input, 500)
                End With

                .Add(clsDatosInv.funExecuteSPDataTable("paListarEmpleadosActivos", sTabla))

                dtDatos = .Item(sTabla)
            End With

            bs.DataSource = dtDatos
            formatoGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub formatoGrid()
        BloquearColumnas(gridDatos)

        gridDatos.Columns("CVEEMP").Visible = False
        gridDatos.Columns("CVEOFI").Visible = False
        gridDatos.Columns("CVEAREA").Visible = False

        gridDatos.Columns("NOMBRE").HeaderText = "Nombre"
        gridDatos.Columns("NOMBRE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        gridDatos.Columns("DESCOFI").HeaderText = "Oficina"
        gridDatos.Columns("DESCOFI").Width = 65
        gridDatos.Columns("DESCAREA").HeaderText = "Área"
        gridDatos.Columns("DESCAREA").Width = 65
        gridDatos.Columns("GPO").HeaderText = "Grupo"
        gridDatos.Columns("GPO").Width = 65
    End Sub

#End Region





End Class