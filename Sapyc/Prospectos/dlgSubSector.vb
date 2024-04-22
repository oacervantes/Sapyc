Imports System.Windows.Forms
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class dlgSubSector

#Region "AUTOR"

    'AUTOR: OCTAVIO CERVANTES   
    'FECHA: 01 - MARZO - 2016

#End Region

#Region "VARIABLES"

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Catálogo de Subsectores"

    Private SqlConection1 As SqlConnection
    Private SqlDataAdaptader1 As SqlDataAdapter

    Private dtSubSectores As New DataTable
    Private sQuery As String

    Public iFuente As Integer
    Public sCveIndustria, sIndustria, sCveSS, sSS As String

#End Region

#Region "EVENTOS"

    Private Sub dlgSubSector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblIndustria.Text = reemplazarCaracter(sIndustria)

        If iFuente = 1 Then
            listarSubSectores()
        Else
            gridDatos.DataSource = bs

            ListarSubSectoresProspectos()
        End If
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If gridDatos.RowCount > 0 Then
            If gridDatos.CurrentRow IsNot Nothing Then
                sCveSS = gridDatos.CurrentRow.Cells("CVESUBSECTOR").Value
                sSS = gridDatos.CurrentRow.Cells("CVESUBSECTOR").Value & " - " & gridDatos.CurrentRow.Cells("SUBSECTOR").Value
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            MsgBox("No hay sub-sectores por seleccionar.", MsgBoxStyle.Exclamation, "Información No Encontrada")
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
    Private Sub gridDatos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridDatos.DoubleClick
        If gridDatos.RowCount > 0 Then
            If gridDatos.CurrentRow IsNot Nothing Then
                sCveSS = gridDatos.CurrentRow.Cells("CVESUBSECTOR").Value
                sSS = gridDatos.CurrentRow.Cells("CVESUBSECTOR").Value & " - " & gridDatos.CurrentRow.Cells("SUBSECTOR").Value
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            MsgBox("No hay sub-sectores por seleccionar.", MsgBoxStyle.Exclamation, "Información No Encontrada")
        End If
    End Sub
    Private Sub gridDatos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If gridDatos.RowCount > 0 Then
                If gridDatos.CurrentRow IsNot Nothing Then
                    sCveSS = gridDatos.CurrentRow.Cells("CVESUBSECTOR").Value
                    sSS = gridDatos.CurrentRow.Cells("CVESUBSECTOR").Value & " - " & gridDatos.CurrentRow.Cells("SUBSECTOR").Value
                    DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                MsgBox("No hay sub-sectores por seleccionar.", MsgBoxStyle.Exclamation, "Información No Encontrada")
            End If
        End If
    End Sub
    Private Sub txtSubSector_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubSector.KeyDown
        If e.KeyCode = Keys.Enter Then
            If gridDatos.RowCount > 0 Then
                If gridDatos.CurrentRow IsNot Nothing Then
                    sCveSS = gridDatos.CurrentRow.Cells("CVESUBSECTOR").Value
                    sSS = gridDatos.CurrentRow.Cells("CVESUBSECTOR").Value & " - " & gridDatos.CurrentRow.Cells("SUBSECTOR").Value
                    DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                MsgBox("No hay sub-sectores por seleccionar.", MsgBoxStyle.Exclamation, "Información No Encontrada")
            End If
        End If
    End Sub
    Private Sub txtSubSector_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubSector.TextChanged
        bs.Filter = "SUBSECTOR LIKE  '%" & txtSubSector.Text & "%'"
    End Sub

#End Region

#Region "SUBS"

    Private Sub listarSubSectores()
        sQuery = "SELECT * FROM SUBSECTORES "
        sQuery &= "WHERE SUBSECTOR LIKE '%" & txtSubSector.Text & "%' AND CVEINDUSTRIA='" & sCveIndustria & "'"
        '=======Variables de conexión a bd
        SqlConection1 = New SqlConnection(CadenaConexion())
        SqlConection1.Open()
        SqlDataAdaptader1 = New SqlDataAdapter(sQuery, SqlConection1)
        dtSubSectores = New DataTable
        SqlDataAdaptader1.Fill(dtSubSectores)
        SqlConection1.Close()
        '=======Variables de conexión a bd

        gridDatos.DataSource = dtSubSectores

        gridDatos.Columns("CVEINDUSTRIA").Visible = False
        gridDatos.Columns("CVESUBSECTOR").HeaderText = "CVE."
        gridDatos.Columns("CVESUBSECTOR").Width = 60
        gridDatos.Columns("SUBSECTOR").HeaderText = "SUB-SECTOR"
        gridDatos.Columns("SUBSECTOR").Width = 348

        If gridDatos.Rows.Count > 0 Then
            gridDatos.CurrentCell = gridDatos.Rows(0).Cells(1)
        End If
    End Sub

    Private Sub ListarSubSectoresProspectos()
        Try
            Dim sTabla As String = "tbSubsectores"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 11, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveInd", sCveIndustria, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtSubSectores = .Item(sTabla)
            End With

            If dtSubSectores.Rows.Count > 0 Then
                bs.DataSource = dtSubSectores

                gridDatos.Columns("CVEINDUSTRIA").Visible = False
                gridDatos.Columns("CVESUBSECTOR").HeaderText = "CVE."
                gridDatos.Columns("CVESUBSECTOR").Width = 60
                gridDatos.Columns("SUBSECTOR").HeaderText = "SUBSECTOR"
                gridDatos.Columns("SUBSECTOR").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSubSectoresProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSubSectores = Nothing
        End Try
    End Sub

#End Region

End Class