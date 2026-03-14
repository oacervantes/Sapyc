Public Class FrmProspectosNvo
    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Lista de Prospectos"

    Private dtProspectos As New DataTable
    Private Sub FrmProspectosNvo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridProspectos.DataSource = bs

        ListarProspectos()
        If dtProspectos Is Nothing Then
            Exit Sub
        End If
    End Sub
    Private Sub ListarProspectos()
        Try
            Dim sTabla As String = "tbProspectos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)

                    If sCveUsuario = "0167" Then
                        .subAddParameter("@sUsuario", "0008", SqlDbType.VarChar, ParameterDirection.Input)
                    Else
                        .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                    End If


                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTProspectos", sTabla))

                dtProspectos = .Item(sTabla)
            End With

            If dtProspectos.Rows.Count > 0 Then
                bs.DataSource = dtProspectos

                gridProspectos.Columns("idProspecto").Visible = False
                gridProspectos.Columns("sUsuario").Visible = False
                gridProspectos.Columns("bActivo").Visible = False
                gridProspectos.Columns("iStatus").Visible = False
                gridProspectos.Columns("iSocEnc").Visible = False
                gridProspectos.Columns("sCveOfi").Visible = False
                gridProspectos.Columns("sCveArea").Visible = False

                ConfigurarColumnasGrid(gridProspectos, "sCveProspecto", "CVE.", 95, 3, False)
                ConfigurarColumnasGrid(gridProspectos, "sCliente", "NOMBRE", 0, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "sStatus", "STATUS", 250, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "dFechaCaptura", "FECHA DE CREACIÓN", 160, 3, False)

            Else
                bs.DataSource = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim frm As New frmContactoNvo With {
      .iOrigen = 1
  }

        If frm.ShowDialog = DialogResult.OK Then
            ListarProspectos()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

End Class