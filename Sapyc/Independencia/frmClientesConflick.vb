Public Class frmClientesConflick
    Private bsSol As New BindingSource
    Private dtSolicitudes, DtDatos, dtColgados As DataTable
    Private ds As New DataSet
    Private drDat As DataRow
    Public IdProp, NivRiesgo As Integer
    Public IdTipo As Char

    Private Sub frmClientesConflick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridClaves.DataSource = bsSol
        crearTabla()
        ListaSolicitudes("C")
    End Sub
    Private Sub ListaSolicitudes(ByVal IdtIpo As Char)
        Try
            If DtDatos.Rows.Count > 0 Then
                DtDatos.Clear()
            End If

            With ds.Tables
                With clsLocal
                    .subClearParameters()


                    .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@cTipo", IdtIpo, SqlDbType.Char, ParameterDirection.Input)

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
                        drDat("SOCIO") = dr("SOCIO").ToString()
                        drDat("REGISTRADAEL") = CDate(dr("REGISTRADAEL")).ToShortDateString()
                        drDat("ESTATUS") = dr("ESTATUS").ToString()
                        'sCveCliente = dr("CVECTE").ToString()
                        drDat("CVECTE") = dr("CVECTE").ToString()
                        drDat("CVEOFI") = dr("CVEOFI").ToString()
                        drDat("CVEAREA") = dr("CVEAREA").ToString()
                        drDat("CVESOC") = dr("CVESOC").ToString()
                        drDat("CVEGER") = dr("CVEGER").ToString()
                        drDat("NOMGER") = dr("NOMGER").ToString()

                        If dr("SOLICITO").ToString() = "S" Then
                            drDat("INDEPENDENCIA") = IIf(dr("CONFLICTODEINDEPENDENCIA") = 1, 1, 0)
                            drDat("BACKGROUNDCHECK") = IIf(dr("NIVELRIESGO") = 0, 0, 1)
                        Else
                            drDat("INDEPENDENCIA") = 0
                            drDat("BACKGROUNDCHECK") = 0
                        End If
                        drDat("SOLICITO") = dr("SOLICITO").ToString()

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
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Not gridClaves.CurrentRow Is Nothing Then
            If gridClaves.Rows.Count > 0 Then

                IdProp = CInt(gridClaves.CurrentRow.Cells("FOLIO").Value)
                abrirPropuesta(IdProp)
            Else
                MsgBox("No existen propuestas registradas.", MsgBoxStyle.Exclamation, "SAPYC")
            End If
        Else
            MsgBox("Seleccione la propuesta que desea actualizar.", MsgBoxStyle.Exclamation, "SAPYC")
        End If
    End Sub
    Private Sub crearTabla()
        DtDatos = New DataTable
        DtDatos.Columns.Add("FOLIO", GetType(System.String))
        DtDatos.Columns.Add("NOMCONTINICIAL", GetType(System.String))
        DtDatos.Columns.Add("OFICINA", GetType(System.String))
        DtDatos.Columns.Add("DIVISION", GetType(System.String))
        DtDatos.Columns.Add("SOCIO", GetType(System.String))
        DtDatos.Columns.Add("REGISTRADAEL", GetType(System.String))
        DtDatos.Columns.Add("ESTATUS", GetType(System.String))

        DtDatos.Columns.Add("CVECTE", GetType(System.String))
        DtDatos.Columns.Add("CVEOFI", GetType(System.String))
        DtDatos.Columns.Add("CVEAREA", GetType(System.String))
        DtDatos.Columns.Add("CVESOC", GetType(System.String))
        DtDatos.Columns.Add("CVEGER", GetType(System.String))
        DtDatos.Columns.Add("NOMGER", GetType(System.String))

        DtDatos.Columns.Add("INDEPENDENCIA", GetType(Boolean))
        DtDatos.Columns.Add("BACKGROUNDCHECK", GetType(Boolean))
        DtDatos.Columns.Add("SOLICITO", GetType(System.String))


    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub formatoGrid()
        gridClaves.Columns("FOLIO").Visible = False
        gridClaves.Columns("SOLICITO").Visible = False
        gridClaves.Columns("SOCIO").Visible = False

        gridClaves.Columns("CVECTE").Visible = False
        gridClaves.Columns("CVEOFI").Visible = False
        gridClaves.Columns("CVEAREA").Visible = False
        gridClaves.Columns("CVESOC").Visible = False
        gridClaves.Columns("CVEGER").Visible = False
        gridClaves.Columns("NOMGER").Visible = False
        gridClaves.Columns("ESTATUS").Visible = False

        gridClaves.Columns("NOMCONTINICIAL").HeaderText = "CONTACTO INICIAL"
        gridClaves.Columns("NOMCONTINICIAL").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        gridClaves.Columns("OFICINA").HeaderText = "OFICINA"
        gridClaves.Columns("OFICINA").Width = 130

        gridClaves.Columns("DIVISION").HeaderText = "DIVISION"
        gridClaves.Columns("DIVISION").Width = 140

        'gridClaves.Columns("SOCIO").HeaderText = "SOCIO"
        'gridClaves.Columns("SOCIO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'gridClaves.Columns("ESTATUS").HeaderText = "STATUS"
        'gridClaves.Columns("ESTATUS").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        gridClaves.Columns("REGISTRADAEL").HeaderText = "REGISTRADA"
        gridClaves.Columns("REGISTRADAEL").Width = 85

        gridClaves.Columns("INDEPENDENCIA").HeaderText = "CONFLICT CHECK"
        gridClaves.Columns("INDEPENDENCIA").Width = 90

        gridClaves.Columns("BACKGROUNDCHECK").HeaderText = "BACKGROUND CHECK"
        gridClaves.Columns("BACKGROUNDCHECK").Width = 90
    End Sub
    Private Sub abrirPropuesta(IdPro As Integer)

        If IdPro <> 0 Then
            IdProp = CInt(gridClaves.Rows(0).Cells("FOLIO").Value)
        Else
            IdProp = IdPro
        End If

        Dim Prop As New frmAltaConflick
        Prop.IdProp = IdProp
        Prop.IdTipo = IdTipo

        If Prop.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ListaSolicitudes(IdTipo)
        End If
    End Sub
    Private Sub gridClaves_DoubleClick(sender As Object, e As EventArgs) Handles gridClaves.DoubleClick
        If Not gridClaves.CurrentRow Is Nothing Then
            If gridClaves.Rows.Count > 0 Then

                IdProp = CInt(gridClaves.CurrentRow.Cells("FOLIO").Value)
                abrirPropuesta(IdProp)
            Else
                MsgBox("No existen propuestas registradas.", MsgBoxStyle.Exclamation, "SAPYC")
            End If
        Else
            MsgBox("Seleccione la propuesta que desea actualizar.", MsgBoxStyle.Exclamation, "SAPYC")
        End If
    End Sub


End Class