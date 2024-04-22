Imports System.Windows.Forms
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class dlgIndustria

#Region "AUTOR"

    'AUTOR: OCTAVIO CERVANTES   
    'FECHA: 01 - MARZO - 2016

#End Region

#Region "VARIABLES"

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Catálogo de Industrias"

    Private SqlConection1 As SqlConnection
    Private SqlDataAdaptader1 As SqlDataAdapter

    Private dtIndustrias As New DataTable
    Private sQuery As String

    Public iFuente As Integer
    Public sCveIndustria, sIndustria As String

#End Region

#Region "EVENTOS"

    Private Sub dlgIndustria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If iFuente = 1 Then
            listarIndustrias()
        Else
            gridDatos.DataSource = bs

            ListarIndustriasProspectos()
        End If
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If gridDatos.RowCount > 0 Then
            If gridDatos.CurrentRow IsNot Nothing Then
                sCveIndustria = gridDatos.CurrentRow.Cells("CVEINDUSTRIA").Value
                sIndustria = gridDatos.CurrentRow.Cells("CVEINDUSTRIA").Value & " - " & gridDatos.CurrentRow.Cells("INDUSTRIA").Value
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            MsgBox("No hay industrias por seleccionar.", MsgBoxStyle.Exclamation, "Información No Encontrada")
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
    Private Sub gridDatos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridDatos.DoubleClick
        If gridDatos.RowCount > 0 Then
            If gridDatos.CurrentRow IsNot Nothing Then
                sCveIndustria = gridDatos.CurrentRow.Cells("CVEINDUSTRIA").Value
                sIndustria = gridDatos.CurrentRow.Cells("CVEINDUSTRIA").Value & " - " & gridDatos.CurrentRow.Cells("INDUSTRIA").Value
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            MsgBox("No hay industrias por seleccionar.", MsgBoxStyle.Exclamation, "Información No Encontrada")
        End If
    End Sub
    Private Sub gridDatos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If gridDatos.RowCount > 0 Then
                If gridDatos.CurrentRow IsNot Nothing Then
                    sCveIndustria = gridDatos.CurrentRow.Cells("CVEINDUSTRIA").Value
                    sIndustria = gridDatos.CurrentRow.Cells("CVEINDUSTRIA").Value & " - " & gridDatos.CurrentRow.Cells("INDUSTRIA").Value
                    DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                MsgBox("No hay industrias por seleccionar.", MsgBoxStyle.Exclamation, "Información No Encontrada")
            End If
        End If
    End Sub
    Private Sub txtIndustria_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIndustria.KeyDown
        If e.KeyCode = Keys.Enter Then
            If gridDatos.RowCount > 0 Then
                If Not gridDatos.CurrentRow Is Nothing Then
                    sCveIndustria = gridDatos.CurrentRow.Cells("CVEINDUSTRIA").Value
                    sIndustria = gridDatos.CurrentRow.Cells("CVEINDUSTRIA").Value & " - " & gridDatos.CurrentRow.Cells("INDUSTRIA").Value
                    DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                MsgBox("No hay industrias por seleccionar.", MsgBoxStyle.Exclamation, "Información No Encontrada")
            End If
        End If
    End Sub
    Private Sub txtIndustria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIndustria.TextChanged
        bs.Filter = "INDUSTRIA LIKE  '%" & txtIndustria.Text & "%'"
    End Sub

#End Region

#Region "SUBS"

    Private Sub listarIndustrias()
        sQuery = "SELECT * FROM INDUSTRIAS "
        sQuery &= "WHERE INDUSTRIA LIKE '%" & txtIndustria.Text & "%'"
        '=======Variables de conexión a bd
        SqlConection1 = New SqlConnection(CadenaConexion())
        SqlConection1.Open()
        SqlDataAdaptader1 = New SqlDataAdapter(sQuery, SqlConection1)
        dtIndustrias = New DataTable
        SqlDataAdaptader1.Fill(dtIndustrias)
        SqlConection1.Close()
        '=======Variables de conexión a bd

        gridDatos.DataSource = dtIndustrias

        gridDatos.Columns("CVEINDUSTRIA").HeaderText = "CVE."
        gridDatos.Columns("CVEINDUSTRIA").Width = 60
        gridDatos.Columns("INDUSTRIA").HeaderText = "INDUSTRIA"
        gridDatos.Columns("INDUSTRIA").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub ListarIndustriasProspectos()
        Try
            Dim sTabla As String = "tbIndustrias"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 10, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtIndustrias = .Item(sTabla)
            End With

            If dtIndustrias.Rows.Count > 0 Then
                bs.DataSource = dtIndustrias

                gridDatos.Columns("CVEINDUSTRIA").HeaderText = "CVE."
                gridDatos.Columns("CVEINDUSTRIA").Width = 60
                gridDatos.Columns("INDUSTRIA").HeaderText = "INDUSTRIA"
                gridDatos.Columns("INDUSTRIA").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        Catch ex As Exception
            insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarIndustriasProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtIndustrias = Nothing
        End Try
    End Sub

#End Region

End Class