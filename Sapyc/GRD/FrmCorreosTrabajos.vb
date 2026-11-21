Imports SpreadsheetLight

Public Class FrmCorreosTrabajos

    Private sNameRpt As String = "Cargar Correos Sustitución"
    Private bs As New BindingSource

    Private dtExcel As New DataTable

    Private drExcel As DataRow

    Private iFila As Integer
    Private sCveTra, sNombre, sApellido, sCorreo As String

    Private Sub FrmCorreosTrabajos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindGrid(gridTrabajos, bs)
        CrearTabla()
    End Sub
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If dlgExcel.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtRuta.Text = dlgExcel.FileName
                LeerArchivoCorreos()
            End If
        Catch ex As Exception
            MsgBox("Hubo un error al procesar la información del archivo de Excel, intente más tarde.", MsgBoxStyle.Critical, "Error al abrir archivo")
        End Try
    End Sub
    Private Sub BtnRevisar_Click(sender As Object, e As EventArgs) Handles btnRevisar.Click
        If MsgBox("Se registrará la información de los correos, ¿desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Settings.NOM_SYS) = MsgBoxResult.Yes Then
            InsertarCorreos()
        End If
    End Sub
    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Close()
    End Sub

    Private Sub CrearTabla()
        dtExcel.Columns.Add("CVETRA", GetType(String))
        dtExcel.Columns.Add("NOMBRE", GetType(String))
        dtExcel.Columns.Add("APE_PAT", GetType(String))
        dtExcel.Columns.Add("CORREO", GetType(String))
    End Sub
    Private Sub FormatoGrid()
        ConfigurarColumnasGrid(gridTrabajos, "CVETRA", "TRABAJO", 150, 1, False)
        ConfigurarColumnasGrid(gridTrabajos, "NOMBRE", "NOMBRE", 150, 1, False)
        ConfigurarColumnasGrid(gridTrabajos, "APE_PAT", "APELLIDO", 150, 1, False)
        ConfigurarColumnasGrid(gridTrabajos, "CORREO", "CORREO", 0, 1, False)
    End Sub

    Private Sub LeerArchivoCorreos()
        Dim gral As SLDocument = New SLDocument(txtRuta.Text, "Correos")

        Try
            If dtExcel.Rows.Count > 0 Then
                dtExcel.Clear()
            End If

            iFila = 2

            While gral.GetCellValueAsString("A" & iFila) <> String.Empty

                sCveTra = gral.GetCellValueAsString("A" & iFila)
                sNombre = gral.GetCellValueAsString("B" & iFila)
                sApellido = gral.GetCellValueAsString("C" & iFila)
                sCorreo = gral.GetCellValueAsString("D" & iFila)

                drExcel = dtExcel.NewRow
                drExcel("CVETRA") = sCveTra
                drExcel("NOMBRE") = sNombre
                drExcel("APE_PAT") = sApellido
                drExcel("CORREO") = sCorreo
                dtExcel.Rows.Add(drExcel)
                iFila += 1
            End While

            bs.DataSource = dtExcel
            FormatoGrid()

            gral.CloseWithoutSaving()
        Catch ex As Exception
            InsertarErrorLog(400, sNameRpt, ex.Message, "2210", "LeerArchivoCorreos()")
            MsgBox("No se puede leer el archivo de Excel, ya se encuentra en revisión. Intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error al abrir archivo")
        End Try
    End Sub

    Private Sub InsertarCorreos()
        For r As Integer = 0 To gridTrabajos.Rows.Count - 1

            With clsDatosInv
                .subClearParameters()
                .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveTra", gridTrabajos.Rows(r).Cells("CVETRA").Value, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sNombres", gridTrabajos.Rows(r).Cells("NOMBRE").Value, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sApellido", gridTrabajos.Rows(r).Cells("APE_PAT").Value, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCorreo", gridTrabajos.Rows(r).Cells("CORREO").Value, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paGRDReportes")
            End With
        Next

        MsgBox("La información de los correos se ha registrado correctamente.", MsgBoxStyle.Information, My.Settings.NOM_SYS)
    End Sub

End Class