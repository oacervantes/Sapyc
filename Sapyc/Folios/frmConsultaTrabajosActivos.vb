Imports System.IO
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports DocumentFormat.OpenXml.Drawing

Public Class frmConsultaTrabajosActivos

    Private dtTrabajos, DtDatos, dtDocumentos, dtArchivosAdjuntos As New DataTable
    Private bsSol As New BindingSource
    Private IdProp As Integer
    Private sDocUno, sDocDos, sArchivoUno, sArchivoDos, sCveTra, sNombreCte As String
    Private drDat As DataRow
    Private ArchivoUno, ArchivoDos As Attachment
    Private sRutaTemp As String = "\\gtmexvts32\aplica\DesarrollosFinanzas\REPACEPTACION\"

    Private Sub frmConsultaTrabajosActivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtDatos = New DataTable()
        Lista.DataSource = bsSol
        crearTabla()
        ListaTrabajosActivos()
    End Sub

    Private Sub crearTabla()

        DtDatos.Columns.Add("AJUSTEPORCEN", GetType(System.String))
        DtDatos.Columns.Add("IDPROPUESTA", GetType(System.String))
        DtDatos.Columns.Add("DOCUMENTO01", GetType(System.String))
        DtDatos.Columns.Add("DOCUMENTO02", GetType(System.String))
        DtDatos.Columns.Add("STATUS", GetType(System.String))
        DtDatos.Columns.Add("CVECTE", GetType(System.String))
        DtDatos.Columns.Add("NOMBRECTE", GetType(System.String))
        DtDatos.Columns.Add("CVEOFI", GetType(System.String))
        DtDatos.Columns.Add("CVEAREA", GetType(System.String))

        DtDatos.Columns.Add("CVETRA", GetType(System.String))
        DtDatos.Columns.Add("OFICINA", GetType(System.String))
        DtDatos.Columns.Add("DIVISIÓN", GetType(System.String))
        DtDatos.Columns.Add("TIPO_STATUS", GetType(System.String))
        DtDatos.Columns.Add("DESCRIPCION", GetType(System.String))
        DtDatos.Columns.Add("FECHAALTA", GetType(System.String))
        DtDatos.Columns.Add("FECHABAJA", GetType(System.String))
        DtDatos.Columns.Add("SOCIO", GetType(System.String))
        DtDatos.Columns.Add("GERENTE", GetType(System.String))
        DtDatos.Columns.Add("TIPOCVETRA", GetType(System.String))



    End Sub
    Private Sub formatoGrid()
        For Each col As DataGridViewColumn In Lista.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        Lista.Columns("IDPROPUESTA").Visible = False
        Lista.Columns("DOCUMENTO01").Visible = False
        Lista.Columns("DOCUMENTO02").Visible = False
        Lista.Columns("AJUSTEPORCEN").Visible = False
        Lista.Columns("STATUS").Visible = False
        Lista.Columns("CVECTE").Visible = False
        Lista.Columns("NOMBRECTE").Visible = False
        Lista.Columns("CVEOFI").Visible = False
        Lista.Columns("CVEAREA").Visible = False


        Lista.Columns("CVETRA").HeaderText = "CLAVE TRABAJO"
        Lista.Columns("CVETRA").Width = 150

        Lista.Columns("DESCRIPCION").HeaderText = "DESCRIPCION"
        Lista.Columns("DESCRIPCION").Width = 250

        Lista.Columns("OFICINA").HeaderText = "OFICINA"
        Lista.Columns("OFICINA").Width = 70

        Lista.Columns("DIVISIÓN").HeaderText = "DIVISIÓN"
        Lista.Columns("DIVISIÓN").Width = 70

        Lista.Columns("TIPO_STATUS").HeaderText = "STATUS"
        Lista.Columns("TIPO_STATUS").Width = 80

        Lista.Columns("FECHAALTA").HeaderText = "FECHA DE ALTA TRABAJO"
        Lista.Columns("FECHAALTA").Width = 100

        Lista.Columns("FECHABAJA").HeaderText = "FECHA BAJA"
        Lista.Columns("FECHABAJA").Width = 100

        Lista.Columns("SOCIO").HeaderText = "SOCIO"
        Lista.Columns("SOCIO").Width = 250

        Lista.Columns("GERENTE").HeaderText = "GERENTE"
        Lista.Columns("GERENTE").Width = 250

        Lista.Columns("TIPOCVETRA").HeaderText = "TIPO TRABAJO"
        Lista.Columns("TIPOCVETRA").Width = 120

    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Me.Close()
    End Sub

    Private Sub btnRevisar_Click(sender As Object, e As EventArgs) Handles btnRevisar.Click


        If Not Lista.CurrentRow Is Nothing Then
            If Lista.Rows.Count > 0 Then

                IdProp = CInt(Lista.CurrentRow.Cells("IDPROPUESTA").Value)
                sDocUno = Lista.CurrentRow.Cells("DOCUMENTO01").Value.ToString()
                sDocDos = Lista.CurrentRow.Cells("DOCUMENTO02").Value.ToString()


                If sDocUno = "" Then
                    MsgBox("No existe documento carta de reaceptación.", MsgBoxStyle.Exclamation, "SAPYC")
                Else
                    If File.Exists("\\GTMEXVTS32\APLICA\DesarrollosFinanzas\REPACEPTACION\" & sDocUno & ".pdf") Then
                        Process.Start("\\GTMEXVTS32\APLICA\DesarrollosFinanzas\REPACEPTACION\" & sDocUno & ".pdf")
                    Else
                        Process.Start(sDocUno & ".pdf")
                    End If
                End If


                If sDocDos = "" Then
                    MsgBox("No existe documento de convenio de servicios", MsgBoxStyle.Exclamation, "SAPYC")
                Else
                    If File.Exists("\\GTMEXVTS32\APLICA\DesarrollosFinanzas\REPACEPTACION\" & sDocDos & ".pdf") Then
                        Process.Start("\\GTMEXVTS32\APLICA\DesarrollosFinanzas\REPACEPTACION\" & sDocDos & ".pdf")
                    Else
                        Process.Start(sDocDos & ".pdf")
                    End If
                End If

            End If

        Else
            MsgBox("Seleccione la propuesta que desea actualizar.", MsgBoxStyle.Exclamation, "SAPYC")
        End If

    End Sub

    Private Sub btnCarga_Click(sender As Object, e As EventArgs) Handles btnCarga.Click
        Dim dlg As New FrmCargaDocumentosAceptacion

        If Not Lista.CurrentRow Is Nothing Then

            If Lista.Rows.Count > 0 Then
                dlg.idPropuesta = CInt(Lista.CurrentRow.Cells("IDPROPUESTA").Value)
                dlg.sCveCte = Lista.CurrentRow.Cells("CVECTE").Value
                dlg.sCveTra = Lista.CurrentRow.Cells("CVETRA").Value
                dlg.sNombreCte = Lista.CurrentRow.Cells("NOMBRECTE").Value
                dlg.sCveOfi = Lista.CurrentRow.Cells("CVEOFI").Value
                dlg.sCveArea = Lista.CurrentRow.Cells("CVEAREA").Value
                dlg.sPppto = "SI"

                If dlg.ShowDialog = DialogResult.OK Then
                    MsgBox("Documentos actualizados correctamente.", MsgBoxStyle.Exclamation, "SAPYC")
                    ListaTrabajosActivos()
                End If

            End If
        Else
            MsgBox("Seleccione la clave de trabajo que actualizara los documentos.", MsgBoxStyle.Exclamation, "SAPYC")
        End If

    End Sub

    Private Sub btnEnvio_Click(sender As Object, e As EventArgs) Handles btnEnvio.Click
        If Not Lista.CurrentRow Is Nothing Then

            If Lista.Rows.Count > 0 Then
                Dim idPropuesta As Integer = CInt(Lista.CurrentRow.Cells("IDPROPUESTA").Value)
                sCveTra = Lista.CurrentRow.Cells("CVETRA").Value
                sNombreCte = Lista.CurrentRow.Cells("NOMBRECTE").Value
                sCveTra = Lista.CurrentRow.Cells("CVETRA").Value
                sNombreCte = Lista.CurrentRow.Cells("NOMBRECTE").Value



                ConsultaArchivosAdjuntos(idPropuesta)
                EnviarCorreoAvisoPracticaNacional("Practica.profesional@mx.gt.com", "Estimado Equipo de Práctica Profesional", ArchivoUno, ArchivoDos)

                MsgBox("Correo Electronico enviado con éxito.", MsgBoxStyle.Exclamation, "SAPYC")

            End If
        Else
            MsgBox("Seleccione la propuesta para enviar el correo electronico.", MsgBoxStyle.Exclamation, "SAPYC")
        End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim dlg As New dlgExcel

        Try
            If MsgBox("¿Desea exportar la información a Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Envío Excel") = MsgBoxResult.Yes Then
                dlg.txtArchivo.Focus()
                dlg.txtArchivo.Text = "Trabajos activos"
                If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

                    ExportaListaTrabajosPracticas(Lista, dlg.txtDirectorio.Text, dlg.txtArchivo.Text)

                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub ListaTrabajosActivos()
        Try
            Dim sTabla As String = "tbSol"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPeriodo", 12, SqlDbType.Int, ParameterDirection.Input)

                End With

                .Add(clsDatosInv.funExecuteSPDataTable("paPracticaProfesionalAuditoria", sTabla))
                dtTrabajos = .Item(sTabla)

                If dtTrabajos.Rows.Count > 0 Then

                    For Each dr As DataRow In dtTrabajos.Rows

                        drDat = DtDatos.NewRow
                        drDat("CVETRA") = dr("CVETRA").ToString()
                        drDat("DESCRIPCION") = dr("DESCRIPCION").ToString()
                        drDat("OFICINA") = dr("OFICINA").ToString()
                        drDat("DIVISIÓN") = dr("DIVISIÓN").ToString()
                        drDat("TIPO_STATUS") = dr("TIPO_STATUS").ToString()
                        drDat("FECHAALTA") = dr("FECHAALTA").ToString()
                        drDat("FECHABAJA") = dr("FECHABAJA").ToString()
                        drDat("SOCIO") = dr("SOCIO").ToString()
                        drDat("GERENTE") = dr("GERENTE").ToString()
                        drDat("TIPOCVETRA") = dr("TIPOCVETRA").ToString()
                        drDat("IDPROPUESTA") = dr("IDPROPUESTA").ToString()
                        drDat("DOCUMENTO01") = dr("DOCUMENTO01").ToString()
                        drDat("DOCUMENTO02") = dr("DOCUMENTO02").ToString()
                        drDat("CVECTE") = dr("CVECTE").ToString()
                        drDat("NOMBRECTE") = dr("NOMBRECTE").ToString()
                        drDat("CVEOFI") = dr("CVEOFI").ToString()
                        drDat("CVEAREA") = dr("CVEAREA").ToString()


                        DtDatos.Rows.InsertAt(drDat, DtDatos.Rows.Count)

                    Next

                    bsSol.DataSource = DtDatos
                    formatoGrid()
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ConsultaArchivosAdjuntos(idprop As Integer)

        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 55, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPropuesta", idprop, SqlDbType.VarChar, ParameterDirection.Input)

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
            "<tr><td>Fecha aprobación aceptación de riesgos:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Date.Now.ToShortDateString & "</b></td></tr>" & vbNewLine &
            "<tr><td>Fecha aprobación convenio de servicios:</td> <td></td> <td></td> <td style=""text-align: left;""><b>" & Date.Now.ToShortDateString & "</b></td></tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<p style=""margin-left: 20px; font-family: Arial; font-size: 16px;"">Se adjuntan los documentos insertados en el sistema SAPYC para revisión 			" & vbNewLine &
            "<hr>" &
            "<p style=""margin-left: 20px; font-style: italic; font-family: Arial; font-size: 12px;"">Este es un correo automático, favor de no responder a esta cuenta.</p>" & vbNewLine &
            "</body></html>"

            EnviarCorreosHTMLAdjuntos(sCorreo, sMensaje, "GENERACIÓN DE CLAVE DE TRABAJO", ArchivoUno, ArchivoDos)
        Catch ex As Exception
            InsertarErrorLog(300, "EnviarCorreoAvisoPracticaNacional", ex.Message, sCveUsuario, "CargaCartasAceptacion()")
            MsgBox("No ha sido posible enviar el correo debido a fallas con el servidor de correo.", MsgBoxStyle.Exclamation, "SIAT")
        End Try
    End Sub




End Class