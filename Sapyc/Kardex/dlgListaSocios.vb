Public Class dlgListaSocios

#Region "AUTOR"

    'AUTOR: OCTAVIO CERVANTES   
    'FECHA: 16 - MAYO - 2014

#End Region

#Region "VARIABLES"

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Lista de Socios"
    Private sStoredProc As String = "paKardexEncargados"

    Private dtSocios As DataTable
    Private sAreas As String

    Public sSocio, sNombre, sCveOfi, sCveArea, sCveSocio As String

#End Region

#Region "EVENTOS"

    Private Sub DlgListaSocios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridDatos.DataSource = bs
        DesplazamientoGrid(gridDatos)

        ListarSocios()
    End Sub
    Private Sub TxtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        bs.Filter = "NOMBRE LIKE '%" & txtNombre.Text & "%'"
    End Sub
    Private Sub GridDatos_DoubleClick(sender As Object, e As EventArgs) Handles gridDatos.DoubleClick
        If gridDatos.Rows.Count > 0 Then
            If Not gridDatos.CurrentRow Is Nothing Then
                sSocio = gridDatos.CurrentRow.Cells("CVEEMP").Value
                sNombre = gridDatos.CurrentRow.Cells("NOMBRE").Value
                DialogResult = DialogResult.OK
            End If
        Else
            MsgBox("No existen socios disponibles para reasignar el trabajo.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End If
    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridDatos.Rows.Count > 0 Then
            If gridDatos.CurrentRow IsNot Nothing Then
                sSocio = gridDatos.CurrentRow.Cells("CVEEMP").Value
                sNombre = gridDatos.CurrentRow.Cells("NOMBRE").Value
                DialogResult = DialogResult.OK
            End If
        Else
            MsgBox("No existen socios disponibles para reasignar el trabajo.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End If
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
    End Sub

#End Region

#Region "SUBS"

    'Private Sub listarSocios()
    '    Try
    '        sQuery = "SELECT E.CVEEMP, E.CVEPUESTO, E.NOMBRE, EA.CVEOFI, EA.CVEAREA "
    '        sQuery &= "FROM EMP_AREAS EA "
    '        sQuery &= "LEFT JOIN EMPLEADOS E ON E.CVEEMP = EA.CVEEMP "
    '        sQuery &= "WHERE EA.CVEOFI = '" & sCveOfi & "' AND EA.CVEAREA = '" & sCveArea & "' AND (E.CVEPUESTO = 'SO' OR E.CVEPUESTO LIKE 'ASOC%' OR ((E.CVEEMP = '1874' OR E.CVEEMP = '3010') AND e.CVEPUESTO = 'GES')) AND E.STATUS = 'A' "
    '        sQuery &= "AND (NOMBRE LIKE '%" & txtNombre.Text & "%' OR NOMBRE = '' OR NOMBRE IS NULL) AND (E.CVEEMP <> '" & sCveSocio & "') "
    '        sQuery &= "ORDER BY E.NOMBRE ASC"

    '        '=======Variables de conexión a bd
    '        SqlConection1 = New SqlConnection(CadenaConexion)
    '        SqlConection1.Open()
    '        SqlDataAdaptader1 = New SqlDataAdapter(sQuery, SqlConection1)
    '        dtDatos = New DataTable
    '        SqlDataAdaptader1.Fill(dtDatos)
    '        SqlConection1.Close()
    '        '=======Variables de conexión a bd

    '        bs.DataSource = dtDatos
    '        formatoGrid()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    Private Sub ListarSocios()
        Try
            Dim sTabla As String = "tbOficinas"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosSac
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveArea", sCveArea, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosSac.funExecuteSPDataTable(sStoredProc, sTabla))

                dtSocios = .Item(sTabla)
            End With

            bs.DataSource = dtSocios
            FormatoGrid()
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSocios()")
            MsgBox(My.Settings.MSG_REPS, MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtSocios = Nothing
        End Try
    End Sub

    Private Sub FormatoGrid()
        BloquearColumnas(gridDatos)

        gridDatos.Columns("CVEEMP").Visible = False
        gridDatos.Columns("CVEOFI").Visible = False
        gridDatos.Columns("CVEAREA").Visible = False

        gridDatos.Columns("CVEPUESTO").HeaderText = "Puesto"
        gridDatos.Columns("CVEPUESTO").Width = 65
        gridDatos.Columns("NOMBRE").HeaderText = "Nombre"
        gridDatos.Columns("NOMBRE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

#End Region

End Class