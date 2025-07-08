Public Class DlgTipoServicio

    Private ds As New DataSet
    Private dtDivisiones, dtEquivalencia As New DataTable

    Private sStoredProc As String = "paTipoServicios"

    Private idDiv, idServ, idSubServ As Integer
    Private sMsg As String
    Private bSubServ As Boolean

    Public idClave, idCveDivision As Integer ' ID de la división seleccionada
    Public sServicio As String ' Nombre del servicio ingresado
    Public bMostrar, bObligatorio As Boolean ' Visibilidad y obligatoriedad del servicio
    Public iOrigen As Integer ' 1: Nuevo, 2: Editar

    Private Sub DlgTipoServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarDivisiones()

        If iOrigen = 1 Then
            Text = "Registrar Servicio..."
        ElseIf iOrigen = 2 Then
            Text = "Editar Servicio..."
            ListarEquivalenciaGTI()

            cboDivision.SelectedValue = idCveDivision
            cboDivision.Enabled = False

            txtServicio.Text = sServicio

            If bObligatorio Then
                rdObligatorioSi.Checked = True
            Else
                rdObligatorioNo.Checked = True
            End If

            If bMostrar Then
                rdMostrarSi.Checked = True
            Else
                rdMostrarNo.Checked = True
            End If
        End If
    End Sub

    Private Sub BtnServicioUno_Click(sender As Object, e As EventArgs) Handles btnServicioUno.Click
        Dim dlg As New DlgServicioGTI With {
            .iOpcion = 1
        }

        If dlg.ShowDialog = DialogResult.OK Then
            idDiv = dlg.idCve
            txtServicioUno.Text = dlg.sTexto

            idServ = 0
            txtServicioDos.Text = ""
            bSubServ = False
            idSubServ = 0
            txtServicioTres.Text = ""
        End If
    End Sub
    Private Sub BtnServicioDos_Click(sender As Object, e As EventArgs) Handles btnServicioDos.Click
        Dim dlg As New DlgServicioGTI With {
            .iOpcion = 2,
            .idCveDiv = idDiv
        }

        If idDiv = 0 Then
            MsgBox("Seleccione la línea de servicio de nivel uno.", MsgBoxStyle.Exclamation, "SIAT")
            Exit Sub
        End If

        If dlg.ShowDialog = DialogResult.OK Then
            idServ = dlg.idCve
            txtServicioDos.Text = dlg.sTexto
            bSubServ = dlg.bHabilita

            If bSubServ = False Then
                btnServicioTres.Enabled = False
            Else
                btnServicioTres.Enabled = True
            End If

            idSubServ = 0
            txtServicioTres.Text = ""
        End If
    End Sub
    Private Sub BtnServicioTres_Click(sender As Object, e As EventArgs) Handles btnServicioTres.Click
        Dim dlg As New DlgServicioGTI With {
            .iOpcion = 3,
            .idCveServ = idServ
        }

        If bSubServ Then
            If idServ = 0 Then
                MsgBox("Seleccione la línea de servicio de nivel dos.", MsgBoxStyle.Exclamation, "SIAT")
                Exit Sub
            End If
        End If

        If dlg.ShowDialog = DialogResult.OK Then
            idSubServ = dlg.idCve
            txtServicioTres.Text = dlg.sTexto
        End If
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If ValidarDatos() = False Then
            lblMensajeError.Visible = True
            lblMensajeError.Text = sMsg

            Exit Sub
        End If

        lblMensajeError.Visible = False
        lblMensajeError.Text = ""

        If iOrigen = 1 Then
            If MsgBox("Se registrará el nuevo servicio. ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
                InsertarServicio()
                InsertarEquivalencia()

                DialogResult = DialogResult.OK
                Close()
            Else
                Exit Sub
            End If
        ElseIf iOrigen = 2 Then
            If MsgBox("Se actualizará la información del servicio. ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
                ActualizarServicio()
                ActualizarEquivalencia()

                DialogResult = DialogResult.OK
                Close()
            Else
                Exit Sub
            End If
        End If
    End Sub
    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub ListarDivisiones()
        Try
            Dim sTabla As String = "tbDivisiones"

            LimpiarTabla(dtDivisiones)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 8, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable(sStoredProc, sTabla))
                dtDivisiones = .Item(sTabla)

                If dtDivisiones.Rows.Count > 0 Then
                    cboDivision.DataSource = dtDivisiones
                    cboDivision.DisplayMember = "DESCRIPCION"
                    cboDivision.ValueMember = "CVE"
                End If
            End With
        Catch ex As Exception
            MsgBox("Por el momento no se posible mostrar el reporte, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub ListarEquivalenciaGTI()
        Try
            Dim sTabla As String = "tbEquivalenciaGTI"

            LimpiarTabla(dtEquivalencia)

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 11, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idClave", idClave, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable(sStoredProc, sTabla))
                dtEquivalencia = .Item(sTabla)

                If dtEquivalencia.Rows.Count > 0 Then
                    idDiv = dtEquivalencia.Rows(0)("IDLINEAUNO")
                    idServ = dtEquivalencia.Rows(0)("IDLINEADOS")
                    idSubServ = dtEquivalencia.Rows(0)("IDLINEATRES")

                    bSubServ = CBool(dtEquivalencia.Rows(0)("NIVEL_TRES"))

                    txtServicioUno.Text = dtEquivalencia.Rows(0)("DIVISION").ToString()
                    txtServicioDos.Text = dtEquivalencia.Rows(0)("SERVICIO").ToString()
                    txtServicioTres.Text = dtEquivalencia.Rows(0)("SUBSERVICIO").ToString()

                    If bSubServ Then
                        btnServicioTres.Enabled = True
                    Else
                        btnServicioTres.Enabled = False
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox("Por el momento no se posible mostrar el reporte, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub

    Private Sub InsertarServicio()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idCveDivision", cboDivision.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sServicio", txtServicio.Text, SqlDbType.VarChar, ParameterDirection.Input)

                If rdObligatorioSi.Checked Then
                    .subAddParameter("@bObligatorio", True, SqlDbType.Bit, ParameterDirection.Input)
                ElseIf rdObligatorioNo.Checked Then
                    .subAddParameter("@bObligatorio", False, SqlDbType.Bit, ParameterDirection.Input)
                End If

                If rdMostrarSi.Checked Then
                    .subAddParameter("@bMostrar", True, SqlDbType.Bit, ParameterDirection.Input)
                ElseIf rdMostrarNo.Checked Then
                    .subAddParameter("@bMostrar", False, SqlDbType.Bit, ParameterDirection.Input)
                End If

                .subAddParameter("@idServ", 0, SqlDbType.Int, ParameterDirection.Output)

                .funExecuteSP(sStoredProc)
                idClave = .funGetParameterValue("@idServ")
            End With
        Catch ex As Exception
            'InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "OcultarServicio()")
            MsgBox("Por el momento no es posible, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub InsertarEquivalencia()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idClave", idClave, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idCveDivision", idDiv, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idServicio", idServ, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSubservicio", idSubServ, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP(sStoredProc)
            End With
        Catch ex As Exception
            'InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "OcultarServicio()")
            MsgBox("Por el momento no es posible, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub ActualizarServicio()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idClave", idClave, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sServicio", txtServicio.Text, SqlDbType.VarChar, ParameterDirection.Input)

                If rdObligatorioSi.Checked Then
                    .subAddParameter("@bObligatorio", True, SqlDbType.Bit, ParameterDirection.Input)
                ElseIf rdObligatorioNo.Checked Then
                    .subAddParameter("@bObligatorio", False, SqlDbType.Bit, ParameterDirection.Input)
                End If

                If rdMostrarSi.Checked Then
                    .subAddParameter("@bMostrar", True, SqlDbType.Bit, ParameterDirection.Input)
                ElseIf rdMostrarNo.Checked Then
                    .subAddParameter("@bMostrar", False, SqlDbType.Bit, ParameterDirection.Input)
                End If

                .funExecuteSP(sStoredProc)
            End With
        Catch ex As Exception
            'InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "OcultarServicio()")
            MsgBox("Por el momento no es posible, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub ActualizarEquivalencia()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 10, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idClave", idClave, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idCveDivision", idDiv, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idServicio", idServ, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSubservicio", idSubServ, SqlDbType.Int, ParameterDirection.Input)

                .funExecuteSP(sStoredProc)
            End With
        Catch ex As Exception
            'InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "OcultarServicio()")
            MsgBox("Por el momento no es posible, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Function ValidarDatos() As Boolean
        Dim bValida As Boolean = True

        If idSubServ = 0 AndAlso idServ > 0 And bSubServ Then
            sMsg = "Seleccione la línea de servicio de nivel 3."
            bValida = False
        End If

        If idServ = 0 AndAlso idDiv > 0 Then
            sMsg = "Seleccione la línea de servicio de nivel 2."
            bValida = False
        End If

        If idDiv = 0 Then
            sMsg = "Seleccione la línea de servicio de nivel 1."
            bValida = False
        End If

        If rdMostrarSi.Checked = False AndAlso rdMostrarNo.Checked = False Then
            sMsg = "Seleccione si el servicio es visible."
            bValida = False
        End If

        If rdObligatorioSi.Checked = False AndAlso rdObligatorioNo.Checked = False Then
            sMsg = "Seleccione si se requiere más información sobre el servicio."
            bValida = False
        End If

        If Trim(txtServicio.Text) = "" Then
            sMsg = "Ingrese el nombre del servicio."
            bValida = False
        End If

        If cboDivision.SelectedValue = 0 Then
            sMsg = "Seleccione una división."
            bValida = False
        End If

        Return bValida
    End Function

End Class
