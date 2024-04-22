Public Class FrmProspectos

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Lista de Prospectos"

    Private dtProspectos As New DataTable

    Private Sub FrmProspectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridProspectos.DataSource = bs

        ListarProspectos()
        If dtProspectos Is Nothing Then
            Exit Sub
        End If
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim frm As New FrmContacto With {
            .iOrigen = 1
        }

        If frm.ShowDialog = DialogResult.OK Then
            ListarProspectos()
        End If
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim frm As New FrmContacto

        If gridProspectos.CurrentRow IsNot Nothing Then
            If gridProspectos.CurrentRow.Cells("iStatus").Value = 2 Then
                frm.iOrigen = 2
                frm.idProspecto = gridProspectos.CurrentRow.Cells("idProspecto").Value
                frm.sCveProspecto = gridProspectos.CurrentRow.Cells("sCveProspecto").Value

                If frm.ShowDialog = DialogResult.OK Then
                    ListarProspectos()
                End If
            Else
                MsgBox("Ya no es posible editar a este prospecto.", MsgBoxStyle.Exclamation, "SIAT")
            End If
        Else
                MsgBox("Seleccione un prospecto para poder editarlo.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If gridProspectos.CurrentRow IsNot Nothing Then
            If gridProspectos.CurrentRow.Cells("iStatus").Value = 2 Then
                If MsgBox("¿Desea eliminar al prospecto seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
                    EliminarProspecto(gridProspectos.CurrentRow.Cells("sCveProspecto").Value)
                    ListarProspectos()
                End If
            Else
                MsgBox("Ya no es posible eliminar este prospecto.", MsgBoxStyle.Exclamation, "SIAT")
            End If
        Else
            MsgBox("Seleccione al prospecto que desea eliminar.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub
    Private Sub btnInicioPropuesta_Click(sender As Object, e As EventArgs) Handles btnInicioPropuesta.Click
        Dim dlg As New DglRevisionDatosProspecto

        If gridProspectos.CurrentRow IsNot Nothing Then

            dlg.sCveProspecto = gridProspectos.CurrentRow.Cells("sCveProspecto").Value
            dlg.sCliente = gridProspectos.CurrentRow.Cells("sCliente").Value

            If dlg.ShowDialog = DialogResult.OK Then
                InsertarPropuesta(gridProspectos.CurrentRow.Cells("sCveProspecto").Value)
                ListarProspectos()
            Else
                Exit Sub
            End If
        Else
            MsgBox("Seleccione a un prospecto para poder generar una propuesta.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub gridProspectos_DoubleClick(sender As Object, e As EventArgs) Handles gridProspectos.DoubleClick
        Dim frm As New FrmContacto

        If gridProspectos.CurrentRow IsNot Nothing Then
            If gridProspectos.CurrentRow.Cells("iStatus").Value = 2 Then
                frm.iOrigen = 2
                frm.idProspecto = gridProspectos.CurrentRow.Cells("idProspecto").Value
                frm.sCveProspecto = gridProspectos.CurrentRow.Cells("sCveProspecto").Value

                If frm.ShowDialog = DialogResult.OK Then
                    ListarProspectos()
                End If
            Else
                MsgBox("Ya no es posible editar a este prospecto.", MsgBoxStyle.Exclamation, "SIAT")
            End If
        Else
                MsgBox("Seleccione un prospecto para poder editarlo.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub
    Private Sub gridProspectos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridProspectos.CellFormatting
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        Select Case CInt(gridProspectos.Rows(e.RowIndex).Cells("iStatus").Value)
            Case 1
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.FromArgb(47, 158, 68)
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco

            Case 2
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.FromArgb(250, 224, 60)
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = negro

            Case 3
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = rojo_Salles
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco

            Case Else
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.Gainsboro
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = negro
        End Select
    End Sub

    Private Sub ListarProspectos()
        Try
            Dim sTabla As String = "tbProspectos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
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

                gridProspectos.Columns("sCveProspecto").HeaderText = "CVE."
                gridProspectos.Columns("sCveProspecto").Width = 85
                gridProspectos.Columns("sCveProspecto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                gridProspectos.Columns("sCliente").HeaderText = "NOMBRE"
                gridProspectos.Columns("sCliente").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                gridProspectos.Columns("sStatus").HeaderText = "STATUS"
                gridProspectos.Columns("sStatus").Width = 200

                gridProspectos.Columns("dFechaCaptura").HeaderText = "FECHA DE CREACIÓN"
                gridProspectos.Columns("dFechaCaptura").Width = 160

                'Else
                '    lblMensajeCargaContactoInicial.Visible = True
            End If
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub

    Private Sub EliminarProspecto(sCveProspecto As String)
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paSSGTProspectos")
            End With

            MsgBox("Se ha eliminado al prospecto correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EliminarProspecto()")
            MsgBox("Hubo un problema al registrar la información del prospecto, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub InsertarPropuesta(sCveProspecto As String)
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paSSGTPropuestasProspectos")
            End With

            MsgBox("Se registró la propuesta correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            'insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarDomicilio()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

End Class