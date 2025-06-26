Imports System.Windows.Forms
Imports PdfSharp.Pdf.Content.Objects

Public Class DlgRevisionAsignaProspecto

    Private ds As New DataSet
    Private sNameRpt As String = "Dialog asignar cliente prospecto a encargado"

    Private dtProspectos, dtSocios, dtOficinas, dtDivisiones, dtServicios As DataTable

    Public sCliente, sCveProspecto, sCveArea, sCveSocio As String

    Private sNombreSocio, sMailSocio As String
    Private Resp As Boolean = True

    Private Sub DglRevisionDatosProspecto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarOficinas()
        ListarDivisiones()
        ListarServicio()
        cboDivisiones.SelectedValue = sCveArea
        cboDivisiones.Enabled = False

        lblCliente.Text = sCliente
    End Sub
    Private Sub btnGenerarPropuesta_Click(sender As Object, e As EventArgs) Handles btnGenerarPropuesta.Click
        If cboOficinas.SelectedIndex = 0 Then
            lblMensajeError.Text = "Seleccione una oficina."
            lblMensajeError.Visible = True
            Exit Sub
        End If

        If cboOficinas.SelectedValue = "MEX" And cboDivisiones.SelectedIndex = 0 Then
            lblMensajeError.Text = "Seleccione una división."
            lblMensajeError.Visible = True
            Exit Sub
        End If

        If cboSocio.SelectedIndex = 0 Then
            lblMensajeError.Text = "Seleccione a un socio encargado."
            lblMensajeError.Visible = True
            Exit Sub
        End If

        lblMensajeError.Text = ""
        lblMensajeError.Visible = False

        If MsgBox("¿Desea asignar el cliente prospecto al socio encargado " & sNombreSocio & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
            AsignarProspecto()
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    Private Sub ConsultaDatosCompletos()
        Try
            Dim sTabla As String = "tbProspectos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasProspectos", sTabla))

                dtProspectos = .Item(sTabla)
            End With

            If dtProspectos.Rows.Count > 0 Then

            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ConsultaDatosCompletos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub
    Private Sub cboOficinas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOficinas.SelectedIndexChanged
        If cboOficinas.SelectedIndex = -1 Then
            Exit Sub
        End If

        If cboOficinas.SelectedIndex <> 0 Then
            If cboOficinas.SelectedValue = "MEX" Then
                'cboDivisiones.Enabled = True
                'cboDivisiones.SelectedIndex = 0

                ListarSocios()
                'cboSocio.DataSource = Nothing
                'cboSocio.Enabled = False
            Else
                'cboDivisiones.Enabled = False
                'cboDivisiones.SelectedIndex = 0

                ListarSocios()
                'cboSocio.Enabled = True
            End If
        Else
            ' cboDivisiones.Enabled = False
            'cboSocio.DataSource = Nothing
            'cboSocio.Enabled = False
        End If

    End Sub
    Private Sub cboDivisiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDivisiones.SelectedIndexChanged
        'If cboDivisiones.SelectedIndex = -1 Then
        '    Exit Sub
        'End If

        'If cboDivisiones.SelectedIndex <> 0 Then
        '    cboSocio.Enabled = True

        '    If cboOficinas.SelectedValue = "MEX" Then
        '        ListarSociosEncargados()
        '    End If
        'Else
        '    cboSocio.DataSource = Nothing
        '    cboSocio.Enabled = False
        'End If
    End Sub

    Private Sub cboSocio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboSocio.SelectionChangeCommitted
        sCveSocio = cboSocio.SelectedValue
        sNombreSocio = cboSocio.SelectedItem("sNombre").ToString
        sMailSocio = cboSocio.SelectedItem("EMAIL").ToString
    End Sub

    Private Sub ListarOficinas()
        Try
            Dim sTabla As String = "tbOficinas"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasProspectos", sTabla))

                dtOficinas = .Item(sTabla)
            End With

            If dtOficinas.Rows.Count > 0 Then
                cboOficinas.DataSource = dtOficinas
                cboOficinas.DisplayMember = "sOficina"
                cboOficinas.ValueMember = "sCveOficina"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarOficinas()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtOficinas = Nothing
        End Try
    End Sub
    Private Sub ListarDivisiones()
        Try
            Dim sTabla As String = "tbDivisiones"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 10, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasProspectos", sTabla))

                dtDivisiones = .Item(sTabla)
            End With

            If dtDivisiones.Rows.Count > 0 Then
                cboDivisiones.DataSource = dtDivisiones
                cboDivisiones.DisplayMember = "sDivision"
                cboDivisiones.ValueMember = "sCveDivision"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDivisiones()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtDivisiones = Nothing
        End Try
    End Sub
    Private Sub ListarSociosEncargados()
        Try
            Dim sTabla As String = "tbSocios"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOficina", cboOficinas.SelectedValue, SqlDbType.VarChar, ParameterDirection.Input)

                    If cboOficinas.SelectedIndex <> 0 Then
                        .subAddParameter("@sCveDivision", cboDivisiones.SelectedValue, SqlDbType.VarChar, ParameterDirection.Input)
                    End If
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasProspectos", sTabla))

                dtSocios = .Item(sTabla)
            End With

            If dtSocios.Rows.Count > 0 Then
                cboSocio.DataSource = dtSocios
                cboSocio.DisplayMember = "sNombre"
                cboSocio.ValueMember = "sCveSocio"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSociosEncargados()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSocios = Nothing
        End Try
    End Sub
    Private Sub ListarSocios()
        Try
            Dim sTabla As String = "tbSocios"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 13, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOficina", cboOficinas.SelectedValue, SqlDbType.VarChar, ParameterDirection.Input)

                    If cboOficinas.SelectedIndex <> 0 Then
                        .subAddParameter("@sCveDivision", cboDivisiones.SelectedValue, SqlDbType.VarChar, ParameterDirection.Input)
                    End If
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasProspectos", sTabla))

                dtSocios = .Item(sTabla)
            End With

            If dtSocios.Rows.Count > 0 Then
                cboSocio.DataSource = dtSocios
                cboSocio.DisplayMember = "sNombre"
                cboSocio.ValueMember = "sCveSocio"
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSociosEncargados()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSocios = Nothing
        End Try
    End Sub
    Private Sub ListarServicio()
        Try
            Dim sTabla As String = "tbServ"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 15, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasProspectos", sTabla))

                dtServicios = .Item(sTabla)
            End With

            If dtServicios.Rows.Count > 0 Then
                txtServicio.Text = dtServicios(0)("sDescripcionServicio")
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDivisiones()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtDivisiones = Nothing
        End Try
    End Sub
    Private Sub AsignarProspecto()
        Try
            With clsDatosProp
                .subClearParameters()
                .subAddParameter("@iOpcion", 14, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@iStatus", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveEmp", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveSocEnc", sCveSocio, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveOficina", cboOficinas.SelectedValue, SqlDbType.VarChar, ParameterDirection.Input)
                If cboOficinas.SelectedValue = "MEX" Then
                    .subAddParameter("@sCveDivision", cboDivisiones.SelectedValue, SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf cboOficinas.SelectedValue = "PLD" Then
                    .subAddParameter("@sCveDivision", "PLD", SqlDbType.VarChar, ParameterDirection.Input)
                ElseIf cboOficinas.SelectedValue = "PTN" Then
                    .subAddParameter("@sCveDivision", "PT", SqlDbType.VarChar, ParameterDirection.Input)
                Else
                    .subAddParameter("@sCveDivision", cboDivisiones.SelectedValue, SqlDbType.VarChar, ParameterDirection.Input)
                End If

                .funExecuteSP("paSSGTPropuestasProspectos")
            End With

            EnviarCorreoAviso(sMailSocio, sNombreSocio)

            MsgBox("Se asignó al cliente prospecto correctamente.", MsgBoxStyle.Information, "SIAT")
            DialogResult = DialogResult.OK
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertaGeneral()")
            MsgBox("Hubo un problema al registrar la información de datos generales, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    Private Sub EnviarCorreoAviso(Correo As String, NombSocio As String) 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try

            ' Dim sCorreo As String() = {Correo, "mario.rodriguez@mx.gt.com", "octavio.a.cervantes@mx.gt.com"}
            Dim sCorreo As String() = {"mario.rodriguez@mx.gt.com", "octavio.a.cervantes@mx.gt.com"}

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">ASIGNACIÓN CLIENTE PROSPECTO</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado " & NombSocio & ",</p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">El presente correo es para informarte que se ha generado una solicitud de asignación de cliente: </p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sCliente & "</b></td></tr>" & vbNewLine &
            "<tr><td>Socio:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & NombSocio & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para revisar y validar esta solicitud, ingresa al sistema SIAT/Clientes Prospectos" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Asignación cliente prospecto")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub

End Class