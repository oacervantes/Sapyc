Imports System.Text.RegularExpressions
Imports System.Web.UI

Public Class frmSAPYCClientesFiscales

    Private bsSol As New BindingSource
    Private dtSolicitudes, DtDatos, dtColgados As DataTable

    Public IdProp, NivRiesgo As Integer
    Private drDat As DataRow
    Public IdTipo As Char
    Private Ind, CC As Boolean
    Private Estatus As String
    Private ds As New DataSet
    Public sRevInd, sCveCliente, sCveClienteNueva As String
    Public TpoProp, tpoMoneda As Char
    Private sNombCte, sNombComercial, sRfc, sCalle, sNumInt, sNumext, sCcp, sColonia, sEstado, sMunicipio, sPais, sMail, sRegimen As String

    Private Sub frmSAPYCClientesFiscales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DtDatos = New DataTable()

        gridClaves.DataSource = bsSol
        crearTabla()
        ListaSolicitudes("F")
    End Sub
    Private Sub btnNueva_Click(sender As Object, e As EventArgs) Handles btnNueva.Click
        If frmSAPYCAltaCteFiscales.ShowDialog() = DialogResult.OK Then
            ListaSolicitudes("F")
        End If
    End Sub
    Private Sub ListaSolicitudes(ByVal IdtIpo As Char)
        Try
            If DtDatos.Rows.Count > 0 Then
                DtDatos.Clear()
            End If

            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
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
                        sCveCliente = dr("CVECTE").ToString()
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

    Private Sub btnGeneraCte_Click(sender As Object, e As EventArgs) Handles btnGeneraCte.Click

        If gridClaves.Rows.Count > 0 Then

            IdProp = CInt(gridClaves.CurrentRow.Cells("FOLIO").Value)
            Estatus = gridClaves.CurrentRow.Cells("ESTATUS").Value.ToString()

            Ind = gridClaves.CurrentRow.Cells("INDEPENDENCIA").Value
            CC = gridClaves.CurrentRow.Cells("BACKGROUNDCHECK").Value

            If CC And Ind Then
                BusquedaCte()
                ActualizaPropuesta()

                crearTabla()
                ListaSolicitudes("F")

                MsgBox("Se inserto el cliente físcal de manera correcta!", MsgBoxStyle.Information, "Clientes fiscales")
            Else
                MsgBox("Para poder generar el cliente,los procesos de Conflick check y Back ground check deben de generarse !", MsgBoxStyle.Exclamation, "Cliente prospecto")
            End If

        End If


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
            IdProp = CInt(gridClaves.CurrentRow.Cells("FOLIO").Value)
        Else
            IdProp = IdPro
        End If

        Dim Prop As New frmSAPYCAltaCteFiscales
        Prop.IdProp = IdProp
        Prop.IdTipo = IdTipo

        If Prop.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ListaSolicitudes(IdTipo)
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
    Private Sub BusquedaCte()

        Dim obtenerLetra As String = ""
        Try
            If DtDatos.Rows.Count > 0 Then
                DtDatos.Clear()
            End If

            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 29, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@CVECTE", sCveCliente, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
                dtColgados = .Item("paEmpresaPropuesta")

                If dtColgados.Rows.Count > 0 Then

                    Dim CveCte As String = dtColgados(0)("CVECTE").ToString.Substring(0, 3)
                    Dim CveLtr As String = "6" 'dtColgados(0)("CVECTE").ToString.Substring(3, 1)
                    Dim CveNum As String = dtColgados(0)("CVECTE").ToString.Substring(4, 4)

                    If CveLtr = "Z" Then
                        obtenerLetra = 0
                    ElseIf Char.IsDigit(CChar(CveLtr)) Then
                        obtenerLetra = CInt(CveLtr) + 1
                    Else
                        obtenerLetra = Convert.ToChar(Convert.ToInt32(CChar(CveLtr)) + 1)
                    End If

                    sCveClienteNueva = CveCte + obtenerLetra + CveNum
                Else
                    sCveClienteNueva = sCveCliente.Replace("-", "A").ToString()
                End If

                ConsultaPropuesta()
                InsertaClienteFiscal()


            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try



    End Sub
    Private Sub ConsultaPropuesta()

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)

                End With

                If .Contains("paSapyc") Then
                    .Remove("paSapyc")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
                DtDatos = .Item("paSapyc")

                If DtDatos.Rows.Count > 0 Then

                    sNombCte = DtDatos(0)("NOMEMPRESA").ToString()
                    sNombComercial = DtDatos(0)("NOMBCOMERCIAL").ToString()
                    sRfc = DtDatos(0)("RFC").ToString()
                    sCalle = DtDatos(0)("CALLE").ToString()
                    sNumInt = DtDatos(0)("NOINT").ToString()
                    sNumext = DtDatos(0)("NOEXT").ToString()
                    sCcp = DtDatos(0)("CP").ToString()
                    sColonia = DtDatos(0)("COLONIA").ToString()
                    sEstado = DtDatos(0)("ESTADO").ToString()
                    sMunicipio = DtDatos(0)("MUNICIPIO").ToString()
                    sPais = DtDatos(0)("PAISFIS").ToString()
                    sMail = DtDatos(0)("EMAILCONTACTO").ToString()
                    sRegimen = DtDatos(0)("CVEREGIMEN").ToString()

                End If


            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub InsertaClienteFiscal()

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 30, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sUsuario", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CVECTE", sCveClienteNueva, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOMBCTE", sNombCte, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@RFC", sRfc, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CALLE", sCalle, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOEXT", sNumext, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOINT", sNumInt, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@COLONIA", sColonia, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@MUNICIPIO", sMunicipio, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@ESTADO", sEstado, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@PAISFIS", sPais, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CP", sCcp, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CVEREGIMEN", sRegimen, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@EMAILCONTA", sMail, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOMBCOMERCIAL", sNombComercial, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSP("paEmpresaPropuesta"))

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub ActualizaPropuesta()
        Try
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 31, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPropuesta", IdProp, SqlDbType.VarChar, ParameterDirection.Input)

            End With
            clsLocal.funExecuteSP("paEmpresaPropuesta")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub




End Class