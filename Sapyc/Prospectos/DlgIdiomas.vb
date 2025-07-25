Public Class DlgIdiomas

#Region "AUTOR"

    'AUTOR: OCTAVIO CERVANTES   
    'FECHA: 22 - JULIO - 2025

#End Region

#Region "VARIABLES"

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Catálogo de Idiomas"

    Private dtIdiomas As New DataTable

    Public idIdioma, sIdioma As String

#End Region

#Region "EVENTOS"

    Private Sub DlgIdiomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridDatos.DataSource = bs

        ListarIdiomas()
    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridDatos.RowCount > 0 Then
            If gridDatos.CurrentRow IsNot Nothing Then
                idIdioma = gridDatos.CurrentRow.Cells("idIdioma").Value
                sIdioma = gridDatos.CurrentRow.Cells("sIdioma").Value
                DialogResult = DialogResult.OK
            End If
        Else
            MsgBox("No hay idiomas por seleccionar.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    Private Sub GridDatos_DoubleClick(sender As Object, e As EventArgs) Handles gridDatos.DoubleClick
        If gridDatos.RowCount > 0 Then
            If gridDatos.CurrentRow IsNot Nothing Then
                idIdioma = gridDatos.CurrentRow.Cells("idIdioma").Value
                sIdioma = gridDatos.CurrentRow.Cells("sIdioma").Value
                DialogResult = DialogResult.OK
            End If
        Else
            MsgBox("No hay idiomas por seleccionar.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub
    Private Sub GridDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If gridDatos.RowCount > 0 Then
                If gridDatos.CurrentRow IsNot Nothing Then
                    idIdioma = gridDatos.CurrentRow.Cells("idIdioma").Value
                    sIdioma = gridDatos.CurrentRow.Cells("sIdioma").Value
                    DialogResult = DialogResult.OK
                End If
            Else
                MsgBox("No hay idiomas por seleccionar.", MsgBoxStyle.Exclamation, "SIAT")
            End If
        End If
    End Sub
    Private Sub TxtIdioma_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdioma.KeyDown
        If e.KeyCode = Keys.Enter Then
            If gridDatos.RowCount > 0 Then
                If gridDatos.CurrentRow IsNot Nothing Then
                    idIdioma = gridDatos.CurrentRow.Cells("idIdioma").Value
                    sIdioma = gridDatos.CurrentRow.Cells("sIdioma").Value
                    DialogResult = DialogResult.OK
                End If
            Else
                MsgBox("No hay idiomas por seleccionar.", MsgBoxStyle.Exclamation, "SIAT")
            End If
        End If
    End Sub
    Private Sub TxtIdioma_TextChanged(sender As Object, e As EventArgs) Handles txtIdioma.TextChanged
        bs.Filter = "sIdioma LIKE  '%" & txtIdioma.Text & "%'"
    End Sub

#End Region

#Region "SUBS"

    Private Sub ListarIdiomas()
        Try
            Dim sTabla As String = "tbIdiomas"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 27, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtIdiomas = .Item(sTabla)
            End With

            If dtIdiomas.Rows.Count > 0 Then
                bs.DataSource = dtIdiomas

                gridDatos.Columns("idIdioma").Visible = False
                ConfigurarColumnasGrid(gridDatos, "sIdioma", "IDIOMA", 0, 1, False)
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarIdiomas()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtIdiomas = Nothing
        End Try
    End Sub

#End Region

End Class
