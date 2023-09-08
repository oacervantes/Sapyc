Public Class frmPropuestas

    Private dtSolicitudes, DtDatos As DataTable
    Private bsSol As New BindingSource
    Public IdProp As Integer
    Private drDat As DataRow
    Private FechaSoli As Date

    Private Sub Bcancelar_Click(sender As Object, e As EventArgs) Handles Bcancelar.Click
        Me.Hide()
        Me.Dispose()
    End Sub
    Private Sub frmPropuestas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Lista.DataSource = bsSol
        crearTabla()
        ListaSolicitudes()
    End Sub
    Private Sub crearTabla()
        DtDatos = New DataTable

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
    Private Sub ListaSolicitudes()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 7, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paIndependencia") Then
                    .Remove("paIndependencia")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paIndependencia"))
                dtSolicitudes = .Item("paIndependencia")

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
                        drDat("HONORARIOS") = dr("HONORARIOS").ToString()
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


            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Lista_DoubleClick(sender As Object, e As EventArgs) Handles Lista.DoubleClick
        IdProp = CInt(Lista.CurrentRow.Cells("FOLIO").Value)

        Dim Prop As New frmPropuesta
        Prop.IdProp = IdProp

        If Prop.ShowDialog() = Windows.Forms.DialogResult.OK Then
        End If

    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        IdProp = CInt(Lista.CurrentRow.Cells("FOLIO").Value)

        Dim Prop As New frmPropuesta
        Prop.IdProp = IdProp

        If Prop.ShowDialog() = Windows.Forms.DialogResult.OK Then
        End If

    End Sub
    Private Sub formatoGrid()
        Try

            Me.Lista.Columns("FOLIO").Visible = False

            Me.Lista.Columns("NOMCONTINICIAL").HeaderText = "CONTACTO INICIAL"
            Me.Lista.Columns("NOMCONTINICIAL").Width = 250

            Me.Lista.Columns("OFICINA").HeaderText = "OFICINA"
            Me.Lista.Columns("OFICINA").Width = 100

            Me.Lista.Columns("DIVISION").HeaderText = "DIVISION"
            Me.Lista.Columns("DIVISION").Width = 100

            Me.Lista.Columns("ESTATUS").HeaderText = "ESTATUS"
            Me.Lista.Columns("ESTATUS").Width = 100

            Me.Lista.Columns("REGISTRADAEL").HeaderText = "FECHA DE CARGA"
            Me.Lista.Columns("REGISTRADAEL").Width = 100


            Me.Lista.Columns("TIPOPROP").HeaderText = "TIPO PROPUESTA"
            Me.Lista.Columns("TIPOPROP").Width = 200

            Me.Lista.Columns("SERVICIO").HeaderText = "SERVICIO"
            Me.Lista.Columns("SERVICIO").Width = 150

            Me.Lista.Columns("CVETRA").HeaderText = "CVE TRABAJO"
            Me.Lista.Columns("CVETRA").Width = 100

            Me.Lista.Columns("HONORARIOS").HeaderText = "HONORARIOS"
            Me.Lista.Columns("HONORARIOS").Width = 100

            Me.Lista.Columns("EMPFAC").HeaderText = "EMPRESA FACTURACIÓN"
            Me.Lista.Columns("EMPFAC").Width = 100


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub



End Class


