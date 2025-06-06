Public Class FrmContactoBasico

#Region "VARIABLES"

    Private ds As New DataSet
    Private bsPro, BindingSource1 As New BindingSource

    Private sNameRpt As String = "Alta de Prospecto"

    Private dtCvesProspectos, dtProspectos, dtDatosGenerales, dtContactoInicial, dtAcercamiento, dtDatGrals, dtComoSeEntero, dtMedioContacto As New DataTable

    Private idProspectos As Integer

    Public sCveProspecto, sCveArea As String
    Public iOrigen, idProspecto, iModifica As Integer

#End Region

#Region "EVENTOS"

    Private Sub FrmContactoBasico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If iModifica = 1 Then
            btnRegistroDatosGenerales.Enabled = False
            btnGuardaGeneral.Enabled = False
            btnCancelaGeneral.Enabled = False

            HabilitarControles(False)
        End If

        panDatosGenerales.Visible = True
        panDivisiones.Enabled = True

        If iOrigen = 1 Then
            ListarProspectos()
            InsertarNuevoProspecto()
            InsertarPropuestaProspecto()
        ElseIf iOrigen = 2 Then
            txtClaveProspecto.Text = sCveProspecto

            If sCveArea = "AUD" Then
                rdAuditoria.Checked = True
            ElseIf sCveArea = "IMP" Then
                rdImpuestos.Checked = True
            ElseIf sCveArea = "PT" Then
                rdPreciosTransferencia.Checked = True
            ElseIf sCveArea = "CEX" Then
                rdComercioExterior.Checked = True
            ElseIf sCveArea = "AUI" Then
                rdBAS.Checked = True
            ElseIf sCveArea = "CE" Then
                rdBPS.Checked = True
            ElseIf sCveArea = "PLD" Then
                rdPLD.Checked = True
            Else
                rdAuditoria.Checked = False
                rdImpuestos.Checked = False
                rdPreciosTransferencia.Checked = False
                rdComercioExterior.Checked = False
                rdBAS.Checked = False
                rdBPS.Checked = False
                rdPLD.Checked = False
            End If


        End If

        '============================== ACERCAMIENTO ==============================
        ListarComoSeEnteroAcerca()
        If dtComoSeEntero Is Nothing Then
            Exit Sub
        End If

        ListarMedioContactoAcerca()
        If dtMedioContacto Is Nothing Then
            Exit Sub
        End If

        ListarAcercamiento()
        If dtAcercamiento Is Nothing Then
            Exit Sub
        End If

        ListarContactoInicial()
        If dtContactoInicial Is Nothing Then
            Exit Sub
        End If

        CargaClientesDatosGenerales()

        '============================== DATOS GENERALES ==============================
        ListarDatosGenerales()
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If iOrigen = 1 Then
            DialogResult = DialogResult.OK
        ElseIf iOrigen = 2 Then
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub LnkSecciones(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDatosGenerales.LinkClicked
        For Each obj As Object In Me.Controls
            If obj.GetType.Name = "Panel" Then
                If DirectCast(obj, Panel).Name = "panMenu" Then
                    Continue For
                Else
                    DirectCast(obj, Panel).Visible = False
                End If

            End If
        Next

        Select Case CInt(DirectCast(sender, LinkLabel).Tag)
            Case 1
                panDatosGenerales.Visible = True

        End Select
    End Sub

#Region "DATOS GENERALES"

    Private Sub TxtRazonSocial_TextChanged(sender As Object, e As EventArgs)
        txtRazonSocial.CharacterCasing = CharacterCasing.Upper

        If txtRazonSocial.Text.Length > 0 Then
            Aplicar_FiltroNombre()
        End If
    End Sub
    Private Sub TxtRazonSocial_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Function Filtrar_DataGridView(Columna As String, texto As String, BindingSource As BindingSource, DataGridView As DataGridView) As Integer
        ' verificar que el DataSource no esté vacio   
        If BindingSource1.DataSource Is Nothing Then
            Return 0
        End If

        Try
            Dim filtro As String = String.Empty

            filtro = "like '%" & texto.Trim & "%'"

            ' armar el sql   
            If filtro <> String.Empty Then
                filtro = "[" & Columna & "]" & filtro
            End If

            ' asigar el criterio a la propiedad Filter del BindingSource   
            BindingSource.Filter = filtro
            ' enlzar el datagridview al BindingSource   
            DataGridView.DataSource = BindingSource.DataSource

            ' retornar la cantidad de registros encontrados   
            Return BindingSource.Count
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try

        Return 0
    End Function

    Private Sub CboAcercamientoComoEntero_SelectionChangeCommitted(sender As Object, e As EventArgs)
        If cboAcercamientoComoEntero.SelectedValue = 13 Then
            txtAcercamientoEnteroOtro.Enabled = True
        Else
            txtAcercamientoEnteroOtro.Enabled = False
            txtAcercamientoEnteroOtro.Text = ""
        End If
    End Sub
    Private Sub CboAcercamientoMedioContacto_SelectionChangeCommitted(sender As Object, e As EventArgs)
        If cboAcercamientoMedioContacto.SelectedValue = 10 Then
            txtAcercamientoContactoOtro.Enabled = True
        Else
            txtAcercamientoContactoOtro.Enabled = False
            txtAcercamientoContactoOtro.Text = ""
        End If
    End Sub

    Private Sub BtnRegistroDatosGenerales_Click(sender As Object, e As EventArgs) Handles btnRegistroDatosGenerales.Click
        gpBoxDatosDG.Enabled = True
        gpBoxDatosContactoInicial.Enabled = True
        gpBoxDatosAcercamiento.Enabled = True
        gpBoxServicio.Enabled = True
        'panDivisiones.Enabled = True

        btnGuardaGeneral.Enabled = True
        btnCancelaGeneral.Enabled = True
        btnRegistroDatosGenerales.Enabled = False

        txtRazonSocial.Focus()
    End Sub
    Private Sub BtnGuardaGeneral_Click(sender As Object, e As EventArgs)
        If txtRazonSocial.Text = "" Then
            lblMensajeErrorDatosGenerales.Visible = True
            lblMensajeErrorDatosGenerales.Text = "Especifíque la razón social del prospecto."

            Exit Sub
        End If

        If txtContactoInicialNombre.Text = "" Then
            lblMensajeErrorDatosGenerales.Visible = True
            lblMensajeErrorDatosGenerales.Text = "Especifíque el nombre del contacto inicial del prospecto."

            Exit Sub
        End If

        If txtContactoInicialCargo.Text = "" Then
            lblMensajeErrorDatosGenerales.Visible = True
            lblMensajeErrorDatosGenerales.Text = "Especifíque el cargo del contacto inicial del prospecto."

            Exit Sub
        End If

        If txtContactoInicialCorreo.Text = "" Then
            lblMensajeErrorDatosGenerales.Visible = True
            lblMensajeErrorDatosGenerales.Text = "Especifíque el correo electrónico del contacto inicial del prospecto."

            Exit Sub
        End If

        If cboAcercamientoComoEntero.SelectedValue = 13 And txtAcercamientoEnteroOtro.Text = "" Then
            lblMensajeErrorDatosGenerales.Visible = True
            lblMensajeErrorDatosGenerales.Text = "Especifíque la forma en cómo se enteró el prospecto."

            Exit Sub
        End If

        If cboAcercamientoMedioContacto.SelectedValue = 10 And txtAcercamientoContactoOtro.Text = "" Then
            lblMensajeErrorDatosGenerales.Visible = True
            lblMensajeErrorDatosGenerales.Text = "Especifíque el medio de contacto utilizado por el prospecto."

            Exit Sub
        End If

        If rdAuditoria.Checked = False And rdImpuestos.Checked = False And rdPreciosTransferencia.Checked = False And rdComercioExterior.Checked = False And rdBAS.Checked = False And rdBPS.Checked = False And rdPLD.Checked = False Then
            lblMensajeErrorDatosGenerales.Visible = True
            lblMensajeErrorDatosGenerales.Text = "Especifíque el tipo de servicio solicitado por el prospecto."

            Exit Sub
        End If

        If txtDescripcionSolicitud.Text = "" Then
            lblMensajeErrorDatosGenerales.Visible = True
            lblMensajeErrorDatosGenerales.Text = "Por favor capture la descripción del servicio que se solicita."

            Exit Sub
        End If

        lblMensajeErrorDatosGenerales.Visible = False
        lblMensajeErrorDatosGenerales.Text = ""

        If MsgBox("¿Desea guardar los datos del cliente prospecto?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
            InsertaGeneral()
            InsertarAcercamiento()
            InsertarContactoInicial()

            MsgBox("Se registraron los datos del cliente prospecto correctamente.", MsgBoxStyle.Information, "SIAT")

            gpBoxDatosDG.Enabled = False
            btnGuardaGeneral.Enabled = False
            btnCancelaGeneral.Enabled = False
            btnRegistroDatosGenerales.Enabled = True

            OcultarMensajesError()
            ListarDatosGenerales()
            ListarContactoInicial()
            ListarAcercamiento()

            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub BtnCancelaGeneral_Click(sender As Object, e As EventArgs)
        gpBoxDatosDG.Enabled = False
        gpBoxDatosContactoInicial.Enabled = False
        gpBoxDatosAcercamiento.Enabled = False
        gpBoxServicio.Enabled = False

        btnGuardaGeneral.Enabled = False
        btnCancelaGeneral.Enabled = False
        btnRegistroDatosGenerales.Enabled = True

        OcultarMensajesError()
        ListarDatosGenerales()
    End Sub

#End Region

    '#Region "CONTACTO INICIAL"

    '    Private Sub btnRegistroContactoInicial_Click(sender As Object, e As EventArgs) Handles btnRegistroContactoInicial.Click
    '        gpBoxDatosContactoInicial.Enabled = True
    '        btnGuardarContactoInicial.Enabled = True
    '        btnCancelarContactoInicial.Enabled = True
    '        btnRegistroContactoInicial.Enabled = False

    '        lblMensajeCargaContactoInicial.Visible = False

    '        txtContactoInicialNombre.Focus()
    '    End Sub
    '    Private Sub btnGuardarContactoInicial_Click(sender As Object, e As EventArgs) Handles btnGuardarContactoInicial.Click
    '        lblMensajeErrorContactoInicial.Visible = False
    '        lblMensajeErrorContactoInicial.Text = ""

    '        If MsgBox("¿Desea registrar la información de Contacto Inicial?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Agregar Contacto Inicial") = MsgBoxResult.Yes Then
    '            gpBoxDatosContactoInicial.Enabled = False
    '            btnGuardarContactoInicial.Enabled = False
    '            btnCancelarContactoInicial.Enabled = False
    '            btnRegistroContactoInicial.Enabled = True

    '            ListarContactoInicial()
    '        End If
    '    End Sub
    '    Private Sub btnCancelarContactoInicial_Click(sender As Object, e As EventArgs) Handles btnCancelarContactoInicial.Click
    '        gpBoxDatosContactoInicial.Enabled = False
    '        btnGuardarContactoInicial.Enabled = False
    '        btnCancelarContactoInicial.Enabled = False
    '        btnRegistroContactoInicial.Enabled = True

    '        OcultarMensajesError()
    '        ListarContactoInicial()
    '    End Sub

    '#End Region

    '#Region "ACERCAMIENTO"

    '    Private Sub btnRegistroAcercamiento_Click(sender As Object, e As EventArgs) Handles btnRegistroAcercamiento.Click
    '        gpBoxDatosAcercamiento.Enabled = True
    '        btnGuardarAcercamiento.Enabled = True
    '        btnCancelarAcercamiento.Enabled = True
    '        btnRegistroAcercamiento.Enabled = False

    '        cboAcercamientoComoEntero.Focus()
    '    End Sub
    '    Private Sub btnGuardarAcercamiento_Click(sender As Object, e As EventArgs) Handles btnGuardarAcercamiento.Click
    '        lblMensajeErrorAcercamiento.Visible = False
    '        lblMensajeErrorAcercamiento.Text = ""

    '        If MsgBox("¿Desea registrar la información de Acercamiento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Agregar Acercamiento") = MsgBoxResult.Yes Then


    '            gpBoxDatosAcercamiento.Enabled = False
    '            btnGuardarAcercamiento.Enabled = False
    '            btnCancelarAcercamiento.Enabled = False
    '            btnRegistroAcercamiento.Enabled = True

    '            ListarAcercamiento()
    '        End If
    '    End Sub
    '    Private Sub btnCancelarAcercamiento_Click(sender As Object, e As EventArgs) Handles btnCancelarAcercamiento.Click
    '        gpBoxDatosAcercamiento.Enabled = False
    '        btnGuardarAcercamiento.Enabled = False
    '        btnCancelarAcercamiento.Enabled = False
    '        btnRegistroAcercamiento.Enabled = True

    '        OcultarMensajesError()
    '        ListarAcercamiento()
    '    End Sub

    '#End Region

#End Region

#Region "SUBS"

    Private Sub HabilitarCombo(cbo As ComboBox, bValor As Boolean)
        If bValor Then
            cbo.Enabled = True
        Else
            cbo.Enabled = False
        End If
    End Sub
    Private Sub HabilitarControles(bValor As Boolean)
        gpBoxDatosDG.Enabled = Not bValor
        gpBoxDatosAcercamiento.Enabled = Not bValor
        gpBoxDatosContactoInicial.Enabled = Not bValor
        gpBoxServicio.Enabled = Not bValor

        txtRazonSocial.ReadOnly = Not bValor
        txtNombreComercial.ReadOnly = Not bValor
        txtDescripcionSolicitud.ReadOnly = Not bValor

        txtContactoInicialNombre.ReadOnly = Not bValor
        txtContactoInicialCargo.ReadOnly = Not bValor
        txtContactoInicialCorreo.ReadOnly = Not bValor
        txtContactoInicialTelefono.ReadOnly = Not bValor
        txtContactoInicialExtension.ReadOnly = Not bValor

        cboAcercamientoComoEntero.Enabled = bValor
        cboAcercamientoMedioContacto.Enabled = bValor

        txtAcercamientoWebProspecto.ReadOnly = Not bValor
        txtAcercamientoEnteroOtro.ReadOnly = Not bValor
        txtAcercamientoContactoOtro.ReadOnly = Not bValor
    End Sub

    Private Sub ListarProspectos()
        Try
            Dim sTabla As String = "tbProspectos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTProspectos", sTabla))

                dtProspectos = .Item(sTabla)
            End With

            If dtProspectos.Rows.Count > 0 Then
                idProspectos = CInt(dtProspectos.Rows(0).Item("idProspecto"))
            Else
                idProspectos = 0
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub
    Private Sub InsertarNuevoProspecto()
        Try
            sCveProspecto = GenerarNuevoProspecto(idProspectos)

            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCliente", "Prospecto " & sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveOfi", "", SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveArea", "", SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@bRecurrente", 0, SqlDbType.Bit, ParameterDirection.Input)
                .subAddParameter("@iStatus", 1, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP("paSSGTProspectos")
            End With

            txtClaveProspecto.Text = sCveProspecto
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarNuevoProspecto()")
            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub InsertarPropuestaProspecto()
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idPropuesta", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idServicio", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iConflictCheck", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iBackgroundCheck", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iNivRiesgo", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@bIndependencia", 0, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sMotInd", "", SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@dHonorarios", 0, SqlDbType.Decimal, ParameterDirection.Input)

                .funExecuteSP("paSSGTPropuestasProspectos")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarPropuestaProspecto()")
            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub OcultarMensajesError()
        lblMensajeErrorDatosGenerales.Visible = False
    End Sub

#Region "DATOS GENERALES"

    Private Sub Aplicar_FiltroNombre()

        Lista.Visible = True
        ' filtrar por el campo Nombrecte
        Dim ret As Integer = Filtrar_DataGridView("NOMBRE", txtRazonSocial.Text.Trim, BindingSource1, Lista)

        If ret > 0 Then
            ' si no hay registros cambiar el color del txtbox   
            'Cnombre.BackColor = Color.Red
            'If MsgBox("¿Este cliente se encuentra en las listas de clientes restringidos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta") = MsgBoxResult.Yes Then
            '    AltaCte = True
            'End If
        Else
            txtRazonSocial.BackColor = Color.White
            Lista.Visible = False
        End If

    End Sub
    Public Sub CargaClientesDatosGenerales()
        Try
            Dim sTabla As String = "tbDatosGrals"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtDatGrals = .Item(sTabla)
            End With

            If dtDatGrals.Rows.Count > 0 Then

                BindingSource1.DataSource = dtDatGrals
                Lista.DataSource = BindingSource1.DataSource

                Lista.Columns("NOMBRE").HeaderText = "Nombre"
                Lista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                Lista.Columns(0).Width = 80
                Lista.Columns(1).Width = 300
            Else
                lblMensajeCargaDatosGenerales.Visible = True
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "CargaClientesDatosGenerales()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtDatGrals = Nothing
        End Try

    End Sub

    Private Sub ListarMedioContactoAcerca()
        Try
            Dim sTabla As String = "tbMedioContactoAcerca"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTAcercamiento", sTabla))

                dtMedioContacto = .Item(sTabla)
            End With

            If dtMedioContacto.Rows.Count > 0 Then
                cboAcercamientoMedioContacto.DataSource = dtMedioContacto

                cboAcercamientoMedioContacto.ValueMember = "idMedio"
                cboAcercamientoMedioContacto.DisplayMember = "sMedio"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarMedioContactoAcerca()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtMedioContacto = Nothing
        End Try
    End Sub
    Private Sub ListarAcercamiento()
        Try
            Dim sTabla As String = "tbAcercamiento"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTAcercamiento", sTabla))

                dtAcercamiento = .Item(sTabla)
            End With

            If dtAcercamiento.Rows.Count > 0 Then
                'lblMensajeErrorDatosGenerales.Visible = False

                cboAcercamientoComoEntero.SelectedValue = CInt(dtAcercamiento.Rows(0).Item("idAcercamiento").ToString)
                If CInt(dtAcercamiento.Rows(0).Item("idAcercamiento").ToString) = 13 Then
                    txtAcercamientoEnteroOtro.Enabled = True
                End If
                txtAcercamientoEnteroOtro.Text = dtAcercamiento.Rows(0).Item("sOtroAcercamiento").ToString

                cboAcercamientoMedioContacto.SelectedValue = CInt(dtAcercamiento.Rows(0).Item("idMedio").ToString)
                If CInt(dtAcercamiento.Rows(0).Item("idMedio").ToString) = 10 Then
                    txtAcercamientoContactoOtro.Enabled = True
                End If
                txtAcercamientoContactoOtro.Text = dtAcercamiento.Rows(0).Item("sOtroMedio").ToString
                txtAcercamientoWebProspecto.Text = dtAcercamiento.Rows(0).Item("sWeb").ToString

                txtCiudad.Text = dtAcercamiento.Rows(0).Item("sCiudad").ToString
                'Else
                '    lblMensajeErrorDatosGenerales.Visible = True
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarAcercamiento()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtAcercamiento = Nothing
        End Try
    End Sub

    Private Sub ListarDatosGenerales()
        Try
            Dim sTabla As String = "tbDatosGenerales"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTDatosGenerales", sTabla))

                dtDatosGenerales = .Item(sTabla)
            End With

            If dtDatosGenerales.Rows.Count > 0 Then
                lblMensajeCargaDatosGenerales.Visible = False

                txtRazonSocial.Text = dtDatosGenerales.Rows(0).Item("sRazonSocial").ToString
                txtNombreComercial.Text = dtDatosGenerales.Rows(0).Item("sNombreComercial").ToString
                txtDescripcionSolicitud.Text = dtDatosGenerales.Rows(0).Item("sDescripcionServicio").ToString

                txtRFC.Text = dtDatosGenerales.Rows(0).Item("sRFC").ToString
                txtIndustria.Text = dtDatosGenerales.Rows(0).Item("sIndustria").ToString

                If dtDatosGenerales.Rows(0).Item("sTipoNegocio").ToString = "F" Then
                    rdPersonaFisica.Checked = True
                ElseIf dtDatosGenerales.Rows(0).Item("sTipoNegocio").ToString = "M" Then
                    rdPersonalMoral.Checked = True
                End If
            Else
                lblMensajeCargaDatosGenerales.Visible = True
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDatosGenerales()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtDatosGenerales = Nothing
        End Try
    End Sub
    Private Sub ListarContactoInicial()
        Try
            Dim sTabla As String = "tbContactoInicial"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTContactoInicial", sTabla))

                dtContactoInicial = .Item(sTabla)
            End With

            If dtContactoInicial.Rows.Count > 0 Then
                'lblMensajeErrorDatosGenerales.Visible = False

                txtContactoInicialNombre.Text = dtContactoInicial.Rows(0).Item("sNombre").ToString
                txtContactoInicialCargo.Text = dtContactoInicial.Rows(0).Item("sCargo").ToString
                txtContactoInicialCorreo.Text = dtContactoInicial.Rows(0).Item("sCorreo").ToString
                txtContactoInicialTelefono.Text = dtContactoInicial.Rows(0).Item("sTelefono").ToString
                txtContactoInicialExtension.Text = dtContactoInicial.Rows(0).Item("sExtension").ToString
                'Else
                '    lblMensajeErrorDatosGenerales.Visible = True
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarContactoInicial()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtContactoInicial = Nothing
        End Try
    End Sub
    Private Sub ListarComoSeEnteroAcerca()
        Try
            Dim sTabla As String = "tbComoSeEnteroAcerca"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 0, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTAcercamiento", sTabla))

                dtComoSeEntero = .Item(sTabla)
            End With

            If dtComoSeEntero.Rows.Count > 0 Then
                cboAcercamientoComoEntero.DataSource = dtComoSeEntero

                cboAcercamientoComoEntero.ValueMember = "idAcercamiento"
                cboAcercamientoComoEntero.DisplayMember = "sAcercamiento"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarComoSeEnteroAcerca()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtComoSeEntero = Nothing
        End Try
    End Sub

    Private Sub InsertaGeneral()
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sRazonSocial", txtRazonSocial.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sNombreComercial", txtNombreComercial.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sDescripcionServicio", txtDescripcionSolicitud.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sRFC", txtRFC.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sIndustria", txtIndustria.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                If rdPersonalMoral.Checked Then
                    .subAddParameter("@sTipoNegocio", "M", SqlDbType.Char, ParameterDirection.Input)
                ElseIf rdPersonaFisica.Checked Then
                    .subAddParameter("@sTipoNegocio", "F", SqlDbType.Char, ParameterDirection.Input)
                End If

                If rdAuditoria.Checked Then
                    .subAddParameter("@sCveArea", "AUD", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdImpuestos.Checked Then
                    .subAddParameter("@sCveArea", "IMP", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdPreciosTransferencia.Checked Then
                    .subAddParameter("@sCveArea", "PT", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdComercioExterior.Checked Then
                    .subAddParameter("@sCveArea", "CEX", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdBAS.Checked Then
                    .subAddParameter("@sCveArea", "AUI", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdBPS.Checked Then
                    .subAddParameter("@sCveArea", "CE", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf rdPLD.Checked Then
                    .subAddParameter("@sCveArea", "PLD", SqlDbType.VarChar, ParameterDirection.Input)
                End If
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paSSGTDatosGenerales")
            End With

            'MsgBox("Se registraron los datos generales correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertaGeneral()")
            MsgBox("Hubo un problema al registrar la información de datos generales, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub
    Private Sub InsertarContactoInicial()
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sNombreContacto", txtContactoInicialNombre.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCargo", txtContactoInicialCargo.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCorreo", txtContactoInicialCorreo.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sTelefono", txtContactoInicialTelefono.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sExtension", txtContactoInicialExtension.Text, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paSSGTContactoInicial")
            End With

            'MsgBox("Se registraron los datos del contacto inicial correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarContactoInicial()")
            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub InsertarAcercamiento()
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idAcercamiento", cboAcercamientoComoEntero.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sOtroAcercamiento", txtAcercamientoEnteroOtro.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idMedio", cboAcercamientoMedioContacto.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sotroMedio", txtAcercamientoContactoOtro.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sWeb", txtAcercamientoWebProspecto.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCiudad", txtCiudad.Text.ToUpper(), SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paSSGTAcercamiento")
            End With

            'MsgBox("Se registraron los datos del acercamiento correctamente.", MsgBoxStyle.Information, "SIAT")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarAcercamiento()")
            MsgBox("Hubo un problema al registrar la información de accionistas, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

#End Region

#End Region

#Region "FUNCIONES"

    Private Function GenerarNuevoProspecto(idProspecto As Integer) As String
        Dim sCve As String = "PRS"

        Select Case idProspecto
            Case 0 To 8
                sCve &= "00000" & (idProspecto + 1)

            Case 9
                sCve &= "0000" & (idProspecto + 1)

            Case 10 To 98
                sCve &= "0000" & (idProspecto + 1)

            Case 99
                sCve &= "000" & (idProspecto + 1)

            Case 100 To 998
                sCve &= "000" & (idProspecto + 1)

            Case 999
                sCve &= "00" & (idProspecto + 1)

            Case 1000 To 9998
                sCve &= "00" & (idProspecto + 1)

            Case 9999
                sCve &= "0" & (idProspecto + 1)

            Case 10000 To 99998
                sCve &= "0" & (idProspecto + 1)

            Case Else
                sCve &= (idProspecto + 1)
        End Select

        Return sCve
    End Function

#End Region


End Class