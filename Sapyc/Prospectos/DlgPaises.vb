Public Class DlgPaises

#Region "AUTOR"

    'AUTOR: OCTAVIO CERVANTES   
    'FECHA: 01 - MARZO - 2016

#End Region

#Region "VARIABLES"

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Catálogo de Paises"

    Private dtPaises As New DataTable

    Public idPais, sPais As String

#End Region

#Region "EVENTOS"

    Private Sub DlgPaises_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridDatos.DataSource = bs

        ListarPaises()
    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridDatos.RowCount > 0 Then
            If gridDatos.CurrentRow IsNot Nothing Then
                idPais = gridDatos.CurrentRow.Cells("idPais").Value
                sPais = gridDatos.CurrentRow.Cells("sPais").Value
                DialogResult = DialogResult.OK
            End If
        Else
            MsgBox("No hay paises por seleccionar.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    Private Sub GridDatos_DoubleClick(sender As Object, e As EventArgs) Handles gridDatos.DoubleClick
        If gridDatos.RowCount > 0 Then
            If gridDatos.CurrentRow IsNot Nothing Then
                idPais = gridDatos.CurrentRow.Cells("idPais").Value
                sPais = gridDatos.CurrentRow.Cells("sPais").Value
                DialogResult = DialogResult.OK
            End If
        Else
            MsgBox("No hay paises por seleccionar.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub
    Private Sub GridDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If gridDatos.RowCount > 0 Then
                If gridDatos.CurrentRow IsNot Nothing Then
                    idPais = gridDatos.CurrentRow.Cells("idPais").Value
                    sPais = gridDatos.CurrentRow.Cells("sPais").Value
                    DialogResult = DialogResult.OK
                End If
            Else
                MsgBox("No hay paises por seleccionar.", MsgBoxStyle.Exclamation, "SIAT")
            End If
        End If
    End Sub
    Private Sub TxtPais_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPais.KeyDown
        If e.KeyCode = Keys.Enter Then
            If gridDatos.RowCount > 0 Then
                If Not gridDatos.CurrentRow Is Nothing Then
                    idPais = gridDatos.CurrentRow.Cells("IDPAIS").Value
                    sPais = gridDatos.CurrentRow.Cells("PAIS").Value
                    DialogResult = DialogResult.OK
                End If
            Else
                MsgBox("No hay paises por seleccionar.", MsgBoxStyle.Exclamation, "SIAT")
            End If
        End If
    End Sub
    Private Sub TxtPais_TextChanged(sender As Object, e As EventArgs) Handles txtPais.TextChanged
        bs.Filter = "sPais LIKE  '%" & txtPais.Text & "%'"
    End Sub

#End Region

#Region "SUBS"

    Private Sub ListarPaises()
        Try
            Dim sTabla As String = "tbPaises"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paGrdEntidad", sTabla))

                dtPaises = .Item(sTabla)
            End With

            If dtPaises.Rows.Count > 0 Then
                bs.DataSource = dtPaises

                gridDatos.Columns("idPais").Visible = False
                ConfigurarColumnasGrid(gridDatos, "sPais", "PAÍS", 0, 1, False)
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarPaises()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtPaises = Nothing
        End Try
    End Sub

#End Region

End Class
