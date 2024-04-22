Imports System.Windows.Forms
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class dlgSubNivel

#Region "AUTOR"

    'AUTOR: OCTAVIO CERVANTES   
    'FECHA: 01 - MARZO - 2016

#End Region

#Region "VARIABLES"

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Catálogo de Subniveles"

    Private SqlConection1 As SqlConnection
    Private SqlDataAdaptader1 As SqlDataAdapter

    Private dtSubNiveles As New DataTable
    Private sQuery As String

    Public iFuente As Integer
    Public sCveSS, sSS, sCveSN, sSN, sCveGTI, sDescripcion As String

#End Region

#Region "EVENTOS"

    Private Sub dlgSubSector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSubSector.Text = reemplazarCaracter(sSS)

        If iFuente = 1 Then
            listarSubNiveles()
        Else
            gridDatos.DataSource = bs

            ListarSubNivelesProspectos()
        End If
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If gridDatos.RowCount > 0 Then
            If gridDatos.CurrentRow IsNot Nothing Then
                sCveSN = gridDatos.CurrentRow.Cells("CVESUBNIVEL").Value
                sSN = gridDatos.CurrentRow.Cells("CVESUBNIVEL").Value & " - " & gridDatos.CurrentRow.Cells("SUBNIVEL").Value
                sCveGTI = gridDatos.CurrentRow.Cells("CVEGTI").Value
                sDescripcion = gridDatos.CurrentRow.Cells("DESCRIPCION").Value
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            MsgBox("No hay sub-niveles por seleccionar.", MsgBoxStyle.Exclamation, "Información No Encontrada")
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub gridDatos_SelectionChanged(sender As Object, e As EventArgs) Handles gridDatos.SelectionChanged
        If gridDatos.CurrentRow IsNot Nothing Then
            txtDescripcion.Text = gridDatos.CurrentRow.Cells("DESCRIPCION").Value
        End If
    End Sub
    Private Sub gridDatos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridDatos.DoubleClick
        If gridDatos.RowCount > 0 Then
            If gridDatos.CurrentRow IsNot Nothing Then
                sCveSN = gridDatos.CurrentRow.Cells("CVESUBNIVEL").Value
                sSN = gridDatos.CurrentRow.Cells("CVESUBNIVEL").Value & " - " & gridDatos.CurrentRow.Cells("SUBNIVEL").Value
                sCveGTI = gridDatos.CurrentRow.Cells("CVEGTI").Value
                sDescripcion = gridDatos.CurrentRow.Cells("DESCRIPCION").Value
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            MsgBox("No hay subniveles por seleccionar.", MsgBoxStyle.Exclamation, "Información No Encontrada")
        End If
    End Sub
    Private Sub gridDatos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If gridDatos.RowCount > 0 Then
                If gridDatos.CurrentRow IsNot Nothing Then
                    sCveSN = gridDatos.CurrentRow.Cells("CVESUBNIVEL").Value
                    sSN = gridDatos.CurrentRow.Cells("CVESUBNIVEL").Value & " - " & gridDatos.CurrentRow.Cells("SUBNIVEL").Value
                    sCveGTI = gridDatos.CurrentRow.Cells("CVEGTI").Value
                    sDescripcion = gridDatos.CurrentRow.Cells("DESCRIPCION").Value
                    DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                MsgBox("No hay sub-niveles por seleccionar.", MsgBoxStyle.Exclamation, "Información No Encontrada")
            End If
        End If
    End Sub
    Private Sub txtSubNivel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubNivel.KeyDown
        If e.KeyCode = Keys.Enter Then
            If gridDatos.RowCount > 0 Then
                If gridDatos.CurrentRow IsNot Nothing Then
                    sCveSN = gridDatos.CurrentRow.Cells("CVESUBNIVEL").Value
                    sSN = gridDatos.CurrentRow.Cells("CVESUBNIVEL").Value & " - " & gridDatos.CurrentRow.Cells("SUBNIVEL").Value
                    sCveGTI = gridDatos.CurrentRow.Cells("CVEGTI").Value
                    sDescripcion = gridDatos.CurrentRow.Cells("DESCRIPCION").Value
                    DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                MsgBox("No hay sub-niveles por seleccionar.", MsgBoxStyle.Exclamation, "Información No Encontrada")
            End If
        End If
    End Sub
    Private Sub txtSubNivel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubNivel.TextChanged
        bs.Filter = "SUBNIVEL LIKE  '%" & txtSubNivel.Text & "%'"
    End Sub

#End Region

#Region "SUBS"

    Private Sub listarSubNiveles()
        sQuery = "SELECT * FROM SUBNIVELES "
        sQuery &= "WHERE SUBNIVEL LIKE '%" & txtSubNivel.Text & "%' AND CVESUBSECTOR='" & sCveSS & "'"
        '=======Variables de conexión a bd
        SqlConection1 = New SqlConnection(CadenaConexion())
        SqlConection1.Open()
        SqlDataAdaptader1 = New SqlDataAdapter(sQuery, SqlConection1)
        dtSubNiveles = New DataTable
        SqlDataAdaptader1.Fill(dtSubNiveles)
        SqlConection1.Close()
        '=======Variables de conexión a bd

        gridDatos.DataSource = dtSubNiveles

        gridDatos.Columns("CVESUBSECTOR").Visible = False
        gridDatos.Columns("CVESUBNIVEL").Visible = False
        gridDatos.Columns("CVEGTI").HeaderText = "CVE."
        gridDatos.Columns("CVEGTI").Width = 60
        gridDatos.Columns("SUBNIVEL").HeaderText = "SUB-NIVEL"
        gridDatos.Columns("SUBNIVEL").Width = 348
        gridDatos.Columns("DESCRIPCION").Visible = False

        If gridDatos.Rows.Count > 0 Then
            gridDatos.CurrentCell = gridDatos.Rows(0).Cells(2)
        End If
    End Sub

    Private Sub ListarSubNivelesProspectos()
        Try
            Dim sTabla As String = "tbSubniveles"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 12, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSS", sCveSS, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtSubNiveles = .Item(sTabla)
            End With

            If dtSubNiveles.Rows.Count > 0 Then
                bs.DataSource = dtSubNiveles

                gridDatos.Columns("CVESUBSECTOR").Visible = False
                gridDatos.Columns("CVESUBNIVEL").Visible = False
                gridDatos.Columns("DESCRIPCION").Visible = False

                gridDatos.Columns("CVEGTI").HeaderText = "CVE."
                gridDatos.Columns("CVEGTI").Width = 60
                gridDatos.Columns("SUBNIVEL").HeaderText = "SUBNIVEL"
                gridDatos.Columns("SUBNIVEL").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSubNivelesProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSubNiveles = Nothing
        End Try
    End Sub

#End Region

End Class