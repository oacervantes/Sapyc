Imports System.IO
Imports System.Security.Cryptography
Imports DocumentFormat.OpenXml.Drawing

Public Class frmConsultaTrabajosActivos

    Private dtTrabajos, DtDatos As New DataTable
    Private bsSol As New BindingSource
    Public IdProp As Integer
    Private sDocUno As String
    Private drDat As DataRow

    Private Sub frmConsultaTrabajosActivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtDatos = New DataTable()
        Lista.DataSource = bsSol
        crearTabla()
        ListaTrabajosActivos()
    End Sub

    Private Sub crearTabla()
        DtDatos.Columns.Add("CVETRA", GetType(System.String))
        DtDatos.Columns.Add("OFICINA", GetType(System.String))
        DtDatos.Columns.Add("DIVISIÓN", GetType(System.String))
        DtDatos.Columns.Add("STATUS", GetType(System.String))
        DtDatos.Columns.Add("TIPO_STATUS", GetType(System.String))
        DtDatos.Columns.Add("DESCRIPCION", GetType(System.String))
        DtDatos.Columns.Add("FECHAALTA", GetType(System.String))
        DtDatos.Columns.Add("FECHABAJA", GetType(System.String))
        DtDatos.Columns.Add("SOCIO", GetType(System.String))
        DtDatos.Columns.Add("GERENTE", GetType(System.String))
        DtDatos.Columns.Add("TIPOCVETRA", GetType(System.String))
        DtDatos.Columns.Add("AJUSTEPORCEN", GetType(System.String))
        DtDatos.Columns.Add("IDPROPUESTA", GetType(System.String))
        DtDatos.Columns.Add("DOCUMENTO01", GetType(System.String))
        DtDatos.Columns.Add("DOCUMENTO02", GetType(System.String))


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


        Lista.Columns("CVETRA").HeaderText = "CLAVE TRABAJO"
        Lista.Columns("CVETRA").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Lista.Columns("DESCRIPCION").HeaderText = "DESCRIPCION"
        Lista.Columns("DESCRIPCION").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Lista.Columns("OFICINA").HeaderText = "OFICINA"
        Lista.Columns("OFICINA").Width = 150

        Lista.Columns("DIVISIÓN").HeaderText = "DIVISIÓN"
        Lista.Columns("DIVISIÓN").Width = 150

        Lista.Columns("TIPO_STATUS").HeaderText = "STATUS"
        Lista.Columns("TIPO_STATUS").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Lista.Columns("FECHAALTA").HeaderText = "FECHA DE ALTA TRABAJO"
        Lista.Columns("FECHAALTA").Width = 100

        Lista.Columns("FECHABAJA").HeaderText = "FECHA BAJA"
        Lista.Columns("FECHABAJA").Width = 100

        Lista.Columns("SOCIO").HeaderText = "SOCIO"
        Lista.Columns("SOCIO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Lista.Columns("GERENTE").HeaderText = "GERENTE"
        Lista.Columns("GERENTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Lista.Columns("TIPOCVETRA").HeaderText = "TIPOCVETRA"
        Lista.Columns("TIPOCVETRA").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Me.Close()
    End Sub

    Private Sub btnRevisar_Click(sender As Object, e As EventArgs) Handles btnRevisar.Click


        If Not Lista.CurrentRow Is Nothing Then
            If Lista.Rows.Count > 0 Then

                IdProp = CInt(Lista.CurrentRow.Cells("IDPROPUESTA").Value)
                sDocUno = Lista.CurrentRow.Cells("DOCUMENTO01").Value.ToString()

                If File.Exists("\\GTMEXVTS32\APLICA\DesarrollosFinanzas\REPACEPTACION" & IdProp & "-" & sDocUno & ".pdf") Then
                    Process.Start("\\GTMEXVTS32\APLICA\DesarrollosFinanzas\REPACEPTACION" & IdProp & "-" & sDocUno & ".pdf")
                Else
                    Process.Start(IdProp & "-" & sDocUno & ".pdf")
                End If


            Else
                MsgBox("No existen propuestas registradas.", MsgBoxStyle.Exclamation, "SAPYC")
            End If
        Else
            MsgBox("Seleccione la propuesta que desea actualizar.", MsgBoxStyle.Exclamation, "SAPYC")
        End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim dlg As New dlgExcel

        Try
            If MsgBox("¿Desea exportar la información a Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Envío Excel") = MsgBoxResult.Yes Then
                dlg.txtArchivo.Focus()
                dlg.txtArchivo.Text = "Trabajos activos"
                If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

                    exportarTrabajos(objExcel, Lista, dlg.txtDirectorio.Text, dlg.txtArchivo.Text)

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
                        drDat("FECHAALTA") = CDate(dr("FECHAALTA")).ToShortDateString()
                        drDat("FECHABAJA") = CDate(dr("FECHABAJA")).ToShortDateString()
                        drDat("SOCIO") = dr("SOCIO").ToString()
                        drDat("GERENTE") = dr("GERENTE").ToString()
                        drDat("TIPOCVETRA") = dr("TIPOCVETRA").ToString()

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
End Class