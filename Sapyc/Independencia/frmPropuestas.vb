Public Class frmPropuestas

    Private bsSol As New BindingSource
    Private dtSolicitudes, DtDatos As New DataTable
    Private drDat As DataRow

    Public IdProp As Integer
    Private FechaSoli As Date

    Private Sub frmPropuestas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lista.DataSource = bsSol

        crearTabla()
        ListaSolicitudes()
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        IdProp = CInt(Lista.CurrentRow.Cells("FOLIO").Value)

        Dim Prop As New FrmPropuestasNvo
        Prop.IdProp = IdProp

        If Prop.ShowDialog() = Windows.Forms.DialogResult.OK Then
        End If
    End Sub
    Private Sub Bcancelar_Click(sender As Object, e As EventArgs) Handles Bcancelar.Click
        Close()
    End Sub
    Private Sub Lista_DoubleClick(sender As Object, e As EventArgs) Handles Lista.DoubleClick
        IdProp = CInt(Lista.CurrentRow.Cells("FOLIO").Value)

        Dim Prop As New FrmPropuestasNvo
        Prop.IdProp = IdProp

        If Prop.ShowDialog() = Windows.Forms.DialogResult.OK Then
        End If
    End Sub

    Private Sub crearTabla()
        DtDatos.Columns.Add("FOLIO", GetType(System.String))
        DtDatos.Columns.Add("NOMCONTINICIAL", GetType(System.String))
        DtDatos.Columns.Add("OFICINA", GetType(System.String))
        DtDatos.Columns.Add("DIVISION", GetType(System.String))
        '  DtDatos.Columns.Add("SOCIO", GetType(System.String))
        DtDatos.Columns.Add("REGISTRADAEL", GetType(System.String))
        DtDatos.Columns.Add("ESTATUS", GetType(System.String))

        DtDatos.Columns.Add("TIPOPROP", GetType(System.String))
        DtDatos.Columns.Add("SERVICIO", GetType(System.String))
        DtDatos.Columns.Add("CVETRA", GetType(System.String))
        DtDatos.Columns.Add("HONORARIOS", GetType(System.String))
        DtDatos.Columns.Add("EMPFAC", GetType(System.String))

        DtDatos.Columns.Add("FECHSOLIND", GetType(System.String))
        DtDatos.Columns.Add("PAIS", GetType(System.String))
        DtDatos.Columns.Add("COLONIA", GetType(System.String))
        DtDatos.Columns.Add("ESTADO", GetType(System.String))
        DtDatos.Columns.Add("MUNICIPIO", GetType(System.String))
        DtDatos.Columns.Add("EMPTENEDORA", GetType(System.String))
    End Sub
    Private Sub formatoGrid()
        Lista.Columns("FOLIO").Visible = False

        Lista.Columns("NOMCONTINICIAL").HeaderText = "CONTACTO INICIAL"
        Lista.Columns("NOMCONTINICIAL").Width = 250

        Lista.Columns("OFICINA").HeaderText = "OFICINA"
        Lista.Columns("OFICINA").Width = 100

        Lista.Columns("DIVISION").HeaderText = "DIVISION"
        Lista.Columns("DIVISION").Width = 100

        Lista.Columns("ESTATUS").HeaderText = "ESTATUS"
        Lista.Columns("ESTATUS").Width = 100

        Lista.Columns("REGISTRADAEL").HeaderText = "FECHA DE CARGA"
        Lista.Columns("REGISTRADAEL").Width = 100


        Lista.Columns("TIPOPROP").HeaderText = "TIPO PROPUESTA"
        Lista.Columns("TIPOPROP").Width = 200

        Lista.Columns("SERVICIO").HeaderText = "SERVICIO"
        Lista.Columns("SERVICIO").Width = 150

        Lista.Columns("CVETRA").HeaderText = "CVE TRABAJO"
        Lista.Columns("CVETRA").Width = 100

        Lista.Columns("HONORARIOS").HeaderText = "HONORARIOS"
        Lista.Columns("HONORARIOS").Width = 100
        Lista.Columns("HONORARIOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Lista.Columns("EMPFAC").HeaderText = "EMPRESA FACTURACIÓN"
        Lista.Columns("EMPFAC").Width = 100
    End Sub

    Private Sub ListaSolicitudes()
        Try
            Dim sTabla As String = "tbPropuestas"
            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paIndependencia", sTabla))
                dtSolicitudes = .Item(sTabla)
            End With

            If dtSolicitudes.Rows.Count > 0 Then
                For Each dr As DataRow In dtSolicitudes.Rows

                    drDat = DtDatos.NewRow
                    drDat("FOLIO") = dr("IDPROP").ToString()
                    drDat("NOMCONTINICIAL") = dr("NOMEMPRESA").ToString()
                    drDat("OFICINA") = dr("OFICINA").ToString()
                    drDat("DIVISION") = dr("DIVISION").ToString()
                    ' drDat("SOCIO") = dr("SOCIO").ToString()
                    drDat("REGISTRADAEL") = CDate(dr("REGISTRADAEL")).ToShortDateString()
                    drDat("ESTATUS") = dr("ESTATUS").ToString()

                    drDat("TIPOPROP") = dr("TIPOPROP").ToString()
                    drDat("SERVICIO") = dr("SERVICIO").ToString()
                    drDat("CVETRA") = dr("CVETRA").ToString()
                    drDat("HONORARIOS") = Format(CDbl(dr("HONORARIOS").ToString()), sFmtDbl)
                    drDat("EMPFAC") = dr("EMPFAC").ToString()

                    If IsDBNull(dr("FECHSOLIND")) Then
                        FechaSoli = "1900/01/01"
                    Else
                        FechaSoli = CDate(dr("FECHSOLIND")).ToShortDateString()
                    End If

                    drDat("FECHSOLIND") = FechaSoli
                    drDat("PAIS") = dr("PAIS").ToString()
                    drDat("COLONIA") = dr("COLONIA").ToString()
                    drDat("ESTADO") = dr("ESTADO").ToString()
                    drDat("MUNICIPIO") = dr("MUNICIPIO").ToString()
                    drDat("EMPTENEDORA") = dr("EMPTENEDORA").ToString()

                    DtDatos.Rows.InsertAt(drDat, DtDatos.Rows.Count)
                Next

                bsSol.DataSource = DtDatos
                formatoGrid()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


End Class