Imports System.IO
Imports System.Net.Mail
Imports PdfSharp.Drawing
Imports PdfSharp.Drawing.Layout
Imports PdfSharp.Pdf

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

    Private dtSolicitudes, dtCorreos As New DataTable

    Private idSAC As Integer

    Private sMensaje, sNombreCliente As String
    Private bDatos As Boolean = True
    Dim sCorreos(), sCuentaCorreo As String

    Private Sub FrmProspectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridProspectos.DataSource = bs
        DesplazamientoGrid(gridProspectos)

        ListarSolicitudesSAC()
        If dtSolicitudes Is Nothing Then Exit Sub
    End Sub
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        InsertarSolicitudSAC()

        Dim frm As New FrmContacto With {
            .iOrigen = 1,
            .idSAC = idSAC
        }

        If frm.ShowDialog = DialogResult.OK Then
            ListarSolicitudesSAC()
        End If
    End Sub
    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim frm As New FrmContacto
        frm.sEstatusSolicitud = gridProspectos.CurrentRow.Cells("cStatus").Value

        If gridProspectos.CurrentRow IsNot Nothing Then
            If gridProspectos.CurrentRow.Cells("cStatus").Value = "P" Or gridProspectos.CurrentRow.Cells("cStatus").Value = "V" Then
                frm.iModifica = 1

                frm.iOrigen = 2
                frm.idSAC = gridProspectos.CurrentRow.Cells("idSAC").Value

                If frm.ShowDialog = DialogResult.OK Then
                    ListarSolicitudesSAC()
                End If
            Else
                MsgBox("Ya no es posible editar esta solicitud.", MsgBoxStyle.Exclamation, "SIAT")
            End If
        Else
            MsgBox("Seleccione una solicitud para editarla.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If gridProspectos.CurrentRow IsNot Nothing Then
            If gridProspectos.CurrentRow.Cells("iStatus").Value = 1 Then
                If MsgBox("¿Desea cancelar la solicitud generada para el prospecto seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Settings.NOM_SYS) = MsgBoxResult.Yes Then
                    EliminarSolicitudSAC(gridProspectos.CurrentRow.Cells("idSAC").Value)
                    MsgBox("Se ha eliminado la solicitud correctamente.", MsgBoxStyle.Information, My.Settings.NOM_SYS)
                    ListarSolicitudesSAC()
                End If
            Else
                MsgBox("No es posible eliminar esta solicitud, porque ya fue enviada para su solicitud.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            End If
        Else
            MsgBox("Seleccione la solicitud que desea eliminar.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End If
    End Sub
    Private Sub BtnEnviarSolicitud_Click(sender As Object, e As EventArgs)
        If gridProspectos.CurrentRow IsNot Nothing Then
            sNombreCliente = gridProspectos.CurrentRow.Cells("sCliente").Value

            If bDatos = False Then
                MsgBox(sMensaje, MsgBoxStyle.Exclamation, "SIAT")
                Exit Sub
            End If

            'ConsultaEnviaCorreos()
            ListarSolicitudesSAC()
        Else
            MsgBox("Seleccione a un prospecto para poder generar una propuesta.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub
    Private Sub GridProspectos_DoubleClick(sender As Object, e As EventArgs) Handles gridProspectos.DoubleClick
        'Dim frm As New FrmContactoBasico

        'If gridProspectos.CurrentRow IsNot Nothing Then
        '    If (gridProspectos.CurrentRow.Cells("iStatus").Value = 1 Or gridProspectos.CurrentRow.Cells("iStatus").Value = 3) Then
        '        frm.iOrigen = 2
        '        frm.idProspecto = gridProspectos.CurrentRow.Cells("idProspecto").Value
        '        frm.sCveProspecto = gridProspectos.CurrentRow.Cells("sCveProspecto").Value
        '        frm.sCveArea = gridProspectos.CurrentRow.Cells("sCveArea").Value

        '        If frm.ShowDialog = DialogResult.OK Then
        '            ListarProspectos()
        '        End If
        '    Else
        '        MsgBox("Ya no es posible editar a este prospecto.", MsgBoxStyle.Exclamation, "SIAT")
        '    End If
        'Else
        '    MsgBox("Seleccione un prospecto para poder editarlo.", MsgBoxStyle.Exclamation, "SIAT")
        'End If
    End Sub
    Private Sub GridProspectos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridProspectos.CellFormatting
        If e.RowIndex = -1 Then Exit Sub

        'Select Case gridProspectos.Rows(e.RowIndex).Cells("iStatus").Value
        '    Case 1
        '        gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.Gainsboro
        '        gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = negro

        '    Case 2
        '        gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.FromArgb(250, 224, 60)
        '        gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = negro

        '    Case 3
        '        gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = naranja_Salles
        '        gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco

        '    Case 4
        '        gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = Color.FromArgb(47, 158, 68)
        '        gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco

        '    Case 5
        '        gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = rojo_Salles
        '        gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = blanco

        '    Case Else
        '        gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.BackColor = blanco
        '        gridProspectos.Rows(e.RowIndex).Cells("sStatus").Style.ForeColor = negro
        'End Select
    End Sub
    Private Sub ListarSolicitudesSAC()
        Try
            Dim sTabla As String = "tbSolicitudes"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paSolicitudesSAC", sTabla))

                dtSolicitudes = .Item(sTabla)
            End With

            If dtSolicitudes.Rows.Count > 0 Then
                bs.DataSource = dtSolicitudes

                gridProspectos.Columns("sUsuario").Visible = False
                gridProspectos.Columns("bRevisarServicio").Visible = False
                gridProspectos.Columns("bDatosSol").Visible = False
                gridProspectos.Columns("cStatus").Visible = False

                ConfigurarColumnasGrid(gridProspectos, "idSAC", "CVE. SAC", 65, 3, False)
                ConfigurarColumnasGrid(gridProspectos, "sNombreCte", "NOMBRE", 0, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "sStatus", "STATUS", 250, 1, False)
                ConfigurarColumnasGrid(gridProspectos, "dFechaAlta", "FECHA DE CREACIÓN", 160, 3, False)
            Else
                bs.DataSource = Nothing
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarSolicitudesSAC()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
            dtSolicitudes = Nothing
        End Try
    End Sub
    Private Sub InsertarSolicitudSAC()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sUsuario", "1019", SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCorreoUsuario", "Tatiana.L.Lopez@mx.gt.com", SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sNombreUsuario", "LOPEZ LOZANO TATIANA LIZBETH", SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idAsignacion", 0, SqlDbType.Int, ParameterDirection.Output)

                .funExecuteSP("paSolicitudesSAC")

                idSAC = .funGetParameterValue("@idAsignacion")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarAsignacionSAC()")
            MsgBox("Por el momento no es posible generar la solicitud SAC, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub EliminarSolicitudSAC(idSAC As Integer)
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idSAC", idSAC, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@cStatus", "B", SqlDbType.Char, ParameterDirection.Input)

                .funExecuteSP("paSolicitudesSAC")
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EliminarAsignacionSAC()")
            MsgBox("Hubo un problema al registrar la información del prospecto, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub EnviarCorreoAviso() 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            'Dim sCorreo As String() = sCorreos
            Dim sCorreo As String() = {"mario.rodriguez@mx.gt.com", "octavio.a.cervantes@mx.gt.com"}

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">SOLICITUD DE CLIENTE PROSPECTO PARA ASIGNACIÓN</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado equipo</p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">El presente correo es para informarte que se ha generado una solicitud de asignación de cliente prospecto: </p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente prospecto:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sNombreCliente & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Para revisar y validar esta solicitud, ingresa al sistema SAPYC > Clientes Prospectos" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

                EnviarCorreosHTML(sCorreo, sMensaje, "Solicitud de Asignación Cliente Prospecto")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
        End Try
    End Sub
    Private Sub ConsultaEnviaCorreos()
        Try
            With ds.Tables
                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paSSGTPropuestasProspectos") Then
                    .Remove("paSSGTPropuestasProspectos")
                End If

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasProspectos"))

                dtCorreos = .Item("paSSGTPropuestasProspectos")

                If dtCorreos.Rows.Count > 0 Then
                    For Each dr As DataRow In dtCorreos.Rows
                        If Not IsDBNull(dr("sUsuario")) Then
                            sCuentaCorreo += dr("sUsuario").ToString & ","
                        End If
                    Next
                    sCuentaCorreo = sCuentaCorreo.TrimEnd(",")
                    sCorreos = sCuentaCorreo.Split(",")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


End Class