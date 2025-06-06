Public Class FrmProspectos

    '1- Solicitud pendiente.
    '2- Solicitud asignada a socio encargado.
    '3- Solicitud asignada a socio para trabajar.
    '4- Solicitud terminada.
    '5- Solicitud cancelada.
    '6- Solicitud sin status.

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Lista de Prospectos"

    Private dtProspectos, dtDatosProspecto As New DataTable

    Private sMensaje, sCveGerente, sNomGerente As String
    Private bDatos As Boolean = True

    Private Sub FrmProspectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridProspectos.DataSource = bs

        ListarProspectos()
        If dtProspectos Is Nothing Then
            Exit Sub
        End If
    End Sub
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim frm As New FrmContactoBasico With {
            .iOrigen = 1
        }

        If frm.ShowDialog = DialogResult.OK Then
            ListarProspectos()
        End If
    End Sub
    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim frm As New FrmContactoBasico

        If gridProspectos.CurrentRow IsNot Nothing Then
            If (gridProspectos.CurrentRow.Cells("iStatus").Value = 1 Or gridProspectos.CurrentRow.Cells("iStatus").Value = 3 Or gridProspectos.CurrentRow.Cells("iStatus").Value = 2) Then

                If gridProspectos.CurrentRow.Cells("iStatus").Value = 2 Then
                    frm.iModifica = 1
                Else
                    frm.iModifica = 0
                End If

                frm.iOrigen = 2
                frm.idProspecto = gridProspectos.CurrentRow.Cells("idProspecto").Value
                frm.sCveProspecto = gridProspectos.CurrentRow.Cells("sCveProspecto").Value
                frm.sCveArea = gridProspectos.CurrentRow.Cells("sCveArea").Value

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
            If gridProspectos.CurrentRow.Cells("iStatus").Value = 1 Then
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
    'Private Sub btnAsignarProspecto_Click(sender As Object, e As EventArgs) Handles btnAsignarProspecto.Click
    '    Dim dlg As New DlgRevisionPropuestaProspecto

    '    If gridProspectos.CurrentRow IsNot Nothing Then
    '        dlg.sCveProspecto = gridProspectos.CurrentRow.Cells("sCveProspecto").Value
    '        dlg.sCliente = gridProspectos.CurrentRow.Cells("sCliente").Value

    '        If dlg.ShowDialog = DialogResult.OK Then
    '            ListarProspectos()
    '        Else
    '            Exit Sub
    '        End If
    '    Else
    '        MsgBox("Seleccione a un prospecto para poder generar una propuesta.", MsgBoxStyle.Exclamation, "SIAT")
    '    End If
    'End Sub
    'Private Sub BtnGenerarPropuesta_Click(sender As Object, e As EventArgs) Handles btnGenerarPropuesta.Click
    '    Dim dlg As New DlgListaGerentes

    '    If gridProspectos.CurrentRow IsNot Nothing Then
    '        dlg.sCveArea = gridProspectos.CurrentRow.Cells("sCveArea").Value
    '        dlg.sCveOfi = gridProspectos.CurrentRow.Cells("sCveOfi").Value

    '        If dlg.ShowDialog = DialogResult.OK Then
    '            sCveGerente = dlg.sCveGer
    '            'ListarProspectos()

    '            If MsgBox("¿Desea generar la propuesta para el cliente prospecto " & gridProspectos.CurrentRow.Cells("sCliente").Value & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
    '                InsertarPropuesta(gridProspectos.CurrentRow.Cells("sCveProspecto").Value, gridProspectos.CurrentRow.Cells("sCveOfi").Value, gridProspectos.CurrentRow.Cells("sCveArea").Value)
    '                ActualizaGerenteSocio(gridProspectos.CurrentRow.Cells("sCveProspecto").Value)
    '                ListarProspectos()
    '            End If
    '        Else
    '            Exit Sub
    '        End If
    '    Else
    '        MsgBox("Seleccione a un prospecto para poder generar una propuesta.", MsgBoxStyle.Exclamation, "SIAT")
    '    End If

    'End Sub
    Private Sub btnAsignarSocio_Click(sender As Object, e As EventArgs) Handles btnAsignarSocio.Click
        Dim dlg As New DlgRevisionAsignaProspecto

        If gridProspectos.CurrentRow IsNot Nothing Then
            ConsultaDatosCompletos(gridProspectos.CurrentRow.Cells("sCveProspecto").Value)

            If bDatos = False Then
                MsgBox(sMensaje, MsgBoxStyle.Exclamation, "SIAT")
                Exit Sub
            End If

            dlg.sCveProspecto = gridProspectos.CurrentRow.Cells("sCveProspecto").Value
            dlg.sCliente = gridProspectos.CurrentRow.Cells("sCliente").Value

            If dlg.ShowDialog = DialogResult.OK Then
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

    Private Sub gridProspectos_SelectionChanged(sender As Object, e As EventArgs) Handles gridProspectos.SelectionChanged
        If gridProspectos.CurrentRow IsNot Nothing Then
            btnEditar.Text = "Editar"
            Select Case CInt(gridProspectos.CurrentRow.Cells("iStatus").Value)
                Case 1 'Solicitud pendiente
                    btnEditar.Enabled = True
                    btnEliminar.Enabled = True

                    'btnAsignarProspecto.Visible = False
                    btnAsignarSocio.Visible = True
                   ' btnGenerarPropuesta.Visible = False

                Case 2 'Solicitud asignada a socio encargado
                    btnEditar.Enabled = True
                    btnEditar.Text = "Revisar"
                    btnEliminar.Enabled = False

                    If CInt(gridProspectos.CurrentRow.Cells("iSocEnc").Value) = 1 Then
                        ' btnAsignarProspecto.Visible = True
                    Else
                        ' btnAsignarProspecto.Visible = True
                    End If
                    btnAsignarSocio.Visible = False
                   ' btnGenerarPropuesta.Visible = False

                Case 3 'Solicitud asignada a socio para trabajar
                    btnEditar.Enabled = True
                    btnEditar.Text = "Revisar"
                    btnEliminar.Enabled = False

                    '  btnAsignarProspecto.Visible = False
                    btnAsignarSocio.Visible = False
                    '  btnGenerarPropuesta.Visible = True

                Case Else 'Solicitud terminada, cancelada o sin status
                    btnEditar.Enabled = False
                    btnEliminar.Enabled = False

                    ' btnAsignarProspecto.Visible = False
                    btnAsignarSocio.Visible = False
                    '  btnGenerarPropuesta.Visible = False

            End Select
        End If
    End Sub
    Private Sub gridProspectos_DoubleClick(sender As Object, e As EventArgs) Handles gridProspectos.DoubleClick
        Dim frm As New FrmContactoBasico

        If gridProspectos.CurrentRow IsNot Nothing Then
            If (gridProspectos.CurrentRow.Cells("iStatus").Value = 1 Or gridProspectos.CurrentRow.Cells("iStatus").Value = 3) Then
                frm.iOrigen = 2
                frm.idProspecto = gridProspectos.CurrentRow.Cells("idProspecto").Value
                frm.sCveProspecto = gridProspectos.CurrentRow.Cells("sCveProspecto").Value
                frm.sCveArea = gridProspectos.CurrentRow.Cells("sCveArea").Value

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
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.Gainsboro
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = negro

            Case 2
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.FromArgb(250, 224, 60)
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = negro

            Case 3
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = naranja_Salles
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco

            Case 4
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.FromArgb(47, 158, 68)
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco

            Case 5
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = rojo_Salles
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco

            Case Else
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = blanco
                gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = negro
        End Select
    End Sub

    'Private Sub lblActualizar_Click(sender As Object, e As EventArgs) Handles lblActualizar.Click
    '    ListarProspectos()
    'End Sub

    Private Sub ListarProspectos()
        Try
            Dim sTabla As String = "tbProspectos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
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

                gridProspectos.Columns("sCveProspecto").HeaderText = "CVE."
                gridProspectos.Columns("sCveProspecto").Width = 85
                gridProspectos.Columns("sCveProspecto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                gridProspectos.Columns("sCliente").HeaderText = "NOMBRE"
                gridProspectos.Columns("sCliente").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                gridProspectos.Columns("sStatus").HeaderText = "STATUS"
                gridProspectos.Columns("sStatus").Width = 250

                gridProspectos.Columns("dFechaCaptura").HeaderText = "FECHA DE CREACIÓN"
                gridProspectos.Columns("dFechaCaptura").Width = 160
            Else
                bs.DataSource = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub
    Private Sub ConsultaDatosCompletos(sCveProspecto As String)
        Try
            Dim sTabla As String = "tbProspectos"

            bDatos = True

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasProspectos", sTabla))

                dtDatosProspecto = .Item(sTabla)
            End With

            If dtDatosProspecto.Rows.Count > 0 Then
                sMensaje = "Para asignar la solicitud de cliente prospecto a un socio encargado, debe capturar la siguiente información:" & vbNewLine

                For Each dr As DataRow In dtDatosProspecto.Rows

                    Select Case dr.Item("sDato")
                        Case "DG"
                            If CInt(dr.Item("iRegs")) = 0 Then
                                sMensaje &= vbNewLine & "- Datos generales."
                                bDatos = False
                            End If

                        Case "CI"
                            If CInt(dr.Item("iRegs")) = 0 Then
                                sMensaje &= vbNewLine & "- Contacto Inicial."
                                bDatos = False
                            End If

                    End Select
                Next
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ConsultaDatosCompletos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtDatosProspecto = Nothing
        End Try
    End Sub

    Private Sub btnAsignarSocio_Click_1(sender As Object, e As EventArgs) Handles btnAsignarSocio.Click
        Dim dlg As New DlgRevisionAsignaProspecto

        If gridProspectos.CurrentRow IsNot Nothing Then
            ConsultaDatosCompletos(gridProspectos.CurrentRow.Cells("sCveProspecto").Value)

            If bDatos = False Then
                MsgBox(sMensaje, MsgBoxStyle.Exclamation, "SIAT")
                Exit Sub
            End If

            dlg.sCveProspecto = gridProspectos.CurrentRow.Cells("sCveProspecto").Value
            dlg.sCliente = gridProspectos.CurrentRow.Cells("sCliente").Value

            If dlg.ShowDialog = DialogResult.OK Then
                ListarProspectos()
            Else
                Exit Sub
            End If
        Else
            MsgBox("Seleccione a un prospecto para poder generar una propuesta.", MsgBoxStyle.Exclamation, "SIAT")
        End If
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
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EliminarProspecto()")
            MsgBox("Hubo un problema al registrar la información del prospecto, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub InsertarPropuesta(sCveProspecto As String, sCveOfi As String, sCveArea As String)
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveSocio", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveGerente", sCveGerente, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveArea", sCveArea, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paPropuestasCtesProspectos")
            End With

            MsgBox("Se registró la propuesta correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarPropuesta()")
            MsgBox("Hubo un problema al registrar la información del domicilio, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub ActualizaGerenteSocio(CveProspecto As String)
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", CveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveSocio", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveGerente", sCveGerente, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paPropuestasDatosProspectos") Then
                    .Remove("paPropuestasDatosProspectos")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paPropuestasDatosProspectos"))
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

End Class