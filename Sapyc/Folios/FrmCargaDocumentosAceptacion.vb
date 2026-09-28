Imports System.IO
Imports System.Net.Mail

Public Class FrmCargaDocumentosAceptacion

    Private bs As New BindingSource
    Private ds As New DataSet

    Private NombPDF, lblPdfs, sNombreDocUno, sNombreDocDos As String
    Private sNameRpt As String = "Carga de documentos de aceptación"
    Private dtArchivosAdjuntos As DataTable
    Public idPropuesta As Integer
    Public sCveCte, sCveTra, sNombreCte, sCveOfi, sCveArea, sArchivoUno, sArchivoDos, sRutaPdf, sPppto As String
    Private ArchivoUno, ArchivoDos As Attachment

    Private sRutaTemp As String = "\\gtmexvts32\aplica\DesarrollosFinanzas\REPACEPTACION\"
    Public dFechaRiesgos, dFechaServicios As String


    Private Sub FrmCargaDocumentosAceptacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If sCveTra = "" Then
            lblCliente.Text = sNombreCte.ToUpper()
        Else
            lblCliente.Text = sCveTra & " - " & sNombreCte.ToUpper()
        End If
        panDocumentos.Enabled = True
        panSolicitud.Enabled = False

    End Sub
    Private Sub BtnDocumentoUno_Click(sender As Object, e As EventArgs) Handles btnDocumentoUno.Click
        Dim sFile As String = ""

        Dim Opd As New OpenFileDialog With {
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ToString,
            .Filter = "Archivos PDF (*.pdf)|*.pdf",
            .Multiselect = True
        }

        If Opd.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Try
                sRutaPdf = Opd.FileName
                sFile = Path.GetFileNameWithoutExtension(Opd.FileName)
                NombPDF = idPropuesta & "-" & sFile
                txtDocumentoUno.Text = Opd.FileName
                sNombreDocUno = NombPDF

                Dim fi As New FileInfo(sRutaPdf)
                If fi.Exists Then
                    If (fi.Length / 10000000) < 10000000 Then
                        If txtDocumentoUno.Text <> "" Then
                            If Not File.Exists("\\Gtmexvts32\aplica\DesarrollosFinanzas\REPACEPTACION\" & NombPDF & ".pdf") Then
                                File.Copy(sRutaPdf, "\\Gtmexvts32\aplica\DesarrollosFinanzas\REPACEPTACION\" & NombPDF & ".pdf")
                            Else
                                File.Delete("\\Gtmexvts32\aplica\DesarrollosFinanzas\REPACEPTACION\" & NombPDF & ".pdf")
                                File.Copy(sRutaPdf, "\\Gtmexvts32\aplica\DesarrollosFinanzas\REPACEPTACION\" & NombPDF & ".pdf")
                            End If
                        End If
                    Else
                        MsgBox("Debe adjuntar un archivo PDF de máximo 10MB.", MsgBoxStyle.Exclamation, "SIAT")
                        txtDocumentoUno.Text = ""
                    End If
                Else
                    txtDocumentoUno.Text = ""
                End If
            Catch ex As Exception
                InsertarErrorLog(300, sNameRpt, ex.Message, sCveUsuario, "btnDocumentoUno_Click()")
                MsgBox("Hubo un inconveniente al adjuntar el archivo PDF, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            End Try
        End If
    End Sub
    Private Sub BtnDocumentoDos_Click(sender As Object, e As EventArgs) Handles btnDocumentoDos.Click
        Dim sFile As String = ""

        Dim Opd As New OpenFileDialog With {
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ToString,
            .Filter = "Archivos PDF (*.pdf)|*.pdf",
            .Multiselect = True
        }

        If Opd.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Try
                sRutaPdf = Opd.FileName
                sFile = Path.GetFileNameWithoutExtension(Opd.FileName)
                NombPDF = idPropuesta & "-" & sFile
                txtDocumentoDos.Text = Opd.FileName
                sNombreDocDos = NombPDF

                Dim fi As New FileInfo(sRutaPdf)
                If fi.Exists Then
                    If (fi.Length / 10000000) < 10000000 Then
                        If txtDocumentoDos.Text <> "" Then
                            If Not File.Exists("\\Gtmexvts32\aplica\DesarrollosFinanzas\REPACEPTACION\" & NombPDF & ".pdf") Then
                                File.Copy(sRutaPdf, "\\Gtmexvts32\aplica\DesarrollosFinanzas\REPACEPTACION\" & NombPDF & ".pdf")
                            Else
                                File.Delete("\\Gtmexvts32\aplica\DesarrollosFinanzas\REPACEPTACION\" & NombPDF & ".pdf")
                                File.Copy(sRutaPdf, "\\Gtmexvts32\aplica\DesarrollosFinanzas\REPACEPTACION\" & NombPDF & ".pdf")
                            End If
                        End If
                    Else
                        MsgBox("Debe adjuntar un archivo PDF de máximo 10MB.", MsgBoxStyle.Exclamation, "SIAT")
                        txtDocumentoDos.Text = ""
                    End If
                Else
                    txtDocumentoDos.Text = ""
                End If
            Catch ex As Exception
                InsertarErrorLog(300, sNameRpt, ex.Message, sCveUsuario, "btnDocumentoUno_Click()")
                MsgBox("Hubo un inconveniente al adjuntar el archivo PDF, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            End Try
        End If
    End Sub
    Private Sub btnRegistrarDocumentos_Click(sender As Object, e As EventArgs) Handles btnRegistrarDocumentos.Click
        Try
            If MsgBox("¿Al presionar aceptar confirmo que las fechas establecidas en estos campos son las fechas correctas de aprobación y coinciden con los documentos en este sistema?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then
                If txtDocumentoUno.Text <> "" And txtDocumentoDos.Text <> "" Then
                    GurdaCartaAceptacion()
                    'EnviarCorreoAviso()
                    dFechaRiesgos = dpRiesgos.Value.ToString("dd/MM/yyyy")
                    dFechaServicios = dpServicios.Value.ToString("dd/MM/yyyy")

                    If sPppto = "SI" Then
                        ConsultaArchivosAdjuntos()
                        EnviarCorreoAvisoPracticaNacional("Practica.profesional@mx.gt.com", "Estimado Equipo de Práctica Profesional", ArchivoUno, ArchivoDos)
                    End If

                    DialogResult = DialogResult.OK
                    MsgBox("Documentos guardados con éxito", MsgBoxStyle.Exclamation, "SIAT")
                Else
                    MsgBox("Debe adjuntar los dos documentos.", MsgBoxStyle.Exclamation, "SIAT")
                End If
            End If
        Catch ex As Exception
            InsertarErrorLog(300, sNameRpt, ex.Message, sCveUsuario, "CargaCartasAceptacion()")
            MsgBox("Solicitud generada con éxito", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub BtnSolicitud_Click(sender As Object, e As EventArgs) Handles btnSolicitud.Click
        Try
            If MsgBox("¿Desea registrar los documentos seleccionados para la apertura de clave de trabajo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIAT") = MsgBoxResult.Yes Then

                GurdaCartaAceptacion()
                DialogResult = DialogResult.Cancel
                MsgBox("Solicitud generada con éxito", MsgBoxStyle.Exclamation, "SIAT")
            End If
        Catch ex As Exception
            InsertarErrorLog(300, sNameRpt, ex.Message, sCveUsuario, "CargaCartasAceptacion()")
            MsgBox("Hubo un inconveniente al mostrar las claves de trabajo, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    Private Sub ChkSolicitud_CheckedChanged(sender As Object, e As EventArgs) Handles chkSolicitud.CheckedChanged
        If chkSolicitud.Checked Then
            panDocumentos.Enabled = False
            panSolicitud.Enabled = True

            txtDocumentoUno.Text = ""
            txtDocumentoDos.Text = ""

            sNombreDocUno = ""
            sNombreDocDos = ""

            txtMotivo.Focus()
        Else
            panDocumentos.Enabled = True
            panSolicitud.Enabled = False

            txtMotivo.Text = ""
        End If
    End Sub
    Private Sub GurdaCartaAceptacion()
        Try
            With clsLocal
                .subClearParameters()

                .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idProp", idPropuesta, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveCte", sCveCte, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sNombreCte", sNombreCte, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sDocUno", sNombreDocUno, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sDocDos", sNombreDocDos, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveArea", sCveArea, SqlDbType.VarChar, ParameterDirection.Input)

                If chkSolicitud.Checked Then
                    .subAddParameter("@sEstaus", "P", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@cTipoSol", "S", SqlDbType.Char, ParameterDirection.Input)
                Else
                    .subAddParameter("@sEstaus", "A", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@cTipoSol", "D", SqlDbType.Char, ParameterDirection.Input)
                End If
                .subAddParameter("@sUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sMotivo", txtMotivo.Text, SqlDbType.VarChar, ParameterDirection.Input)

                .funExecuteSP("paCartasAceptacion")
            End With
        Catch ex As Exception
            InsertarErrorLog(300, sNameRpt, ex.Message, sCveUsuario, "GurdaCartaAceptacion()")
            MsgBox("Hubo un inconveniente al adjuntar el archivo PDF, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub EnviarCorreoAviso() 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            'sCorreos = "Octavio.A.Cervantes@mx.gt.com, Mario.Rodriguez@mx.gt.com"
            Dim sCorreo As String() = {"practica.profesional@mx.gt.com"}

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">CARTA ACEPTACIÓN TRABAJO</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado " & "EQUIPO" & ",</p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">El presente correo es para informarles que se ha generado la carga de las cartas de aceptación: </p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sNombreCte.ToUpper() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Cve.Trabajo:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sCveTra.ToUpper() & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Carga documentos de aceptación" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTML(sCorreo, sMensaje, "Alta de cartas aceptación")
        Catch ex As Exception
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub
    Private Sub ConsultaArchivosAdjuntos()

        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 55, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPropuesta", idPropuesta, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paEmpresaPropuesta") Then
                .Remove("paEmpresaPropuesta")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            dtArchivosAdjuntos = .Item("paEmpresaPropuesta")

            If dtArchivosAdjuntos.Rows.Count > 0 Then
                sArchivoUno = dtArchivosAdjuntos(0)("DOCUMENTO01")
                sArchivoDos = dtArchivosAdjuntos(0)("DOCUMENTO02")
            End If
            If sArchivoUno <> "" Then
                ArchivoUno = New Attachment(sRutaTemp & sArchivoUno & ".pdf")
            End If
            If sArchivoDos <> "" Then
                ArchivoDos = New Attachment(sRutaTemp & sArchivoDos & ".pdf")
            End If
        End With

    End Sub
    Private Sub EnviarCorreoAvisoPracticaNacional(Correo As String, NombSocio As String, ArchivoUno As Attachment, ArchivoDos As Attachment) 'Este correo es para avisar al socio encargado de oficina, que se ha solicitado generar un folio con cobranza incompleta.
        Dim sMensaje As String

        Try
            'sCorreos = "Octavio.A.Cervantes@mx.gt.com, Mario.Rodriguez@mx.gt.com"
            Dim sCorreo As String() = {Correo, "cecilia.coronel@mx.gt.com"}
            ' Dim sCorreo As String() = {"Mario.Rodriguez@mx.gt.com"}

            sMensaje = "<html><head></head><body>" &
            "<img src='cid:imagen1' alt='Salles, Sainz - Grant Thornton' style='width:300px;height:auto;'>" &
            "<h1 style=""height: 50px; background: #4f2d7f; font-family: Calibri, Arial; color: #FFF; padding-right: 30px; text-align: center;"">GENERACIÓN DE CLAVE DE TRABAJO</h1>" & vbNewLine & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 20px; color: #4f2d7f; margin-left: 25px; margin-top: 20px; padding: 15px;"">Estimado Equipo de Práctica Profesional,</p> " & vbNewLine & vbNewLine &
            "<p style=""height: 40px; background: #FFF; font-family: Arial; font-size: 16px; margin-left: 25px; margin-top: 20px; padding: 15px;"">El presente correo es para informarte que se aceptó una clave de trabajo presupuestada: </p> " & vbNewLine & vbNewLine &
            "<table style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">" & vbNewLine &
            "<tr><td>Cliente:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sNombreCte.ToUpper() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Cve.Trabajo:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & sCveTra.ToUpper() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Fecha aprobación aceptación de riesgos:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & dFechaRiesgos.ToString() & "</b></td></tr>" & vbNewLine &
            "<tr><td>Fecha aprobación convenio de servicios:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & dFechaServicios.ToString() & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Se adjuntan los documentos insertados en el sistema SAPYC para revisión 			" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTMLAdjuntos(sCorreo, sMensaje, "GENERACIÓN DE CLAVE DE TRABAJO", ArchivoUno, ArchivoDos)
        Catch ex As Exception
            InsertarErrorLog(300, sNameRpt, ex.Message, sCveUsuario, "CargaCartasAceptacion()")
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub


End Class