Imports System.Data.SqlClient
Imports System.Reflection

Public Class frmSAPYCAltaCteFiscales
    Private ds As New DataSet
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Public CveDivision, sNombreCte, sCveCliente, CveGerente, CveSocio As String
    Private PasaNomb As Boolean = False
    Public Permite As Boolean
    Private dtRfc, dtPropuesta, DtDatos, dtFuncionarios, dtAccionistas, dtGerentes, dtSocios, dtServicios As DataTable
    Public IdPropuesta As Integer
    Private Nom, Apat, Amat, CargoTemp, perMoralTemp, PorcTemp, Colonia, Municipio, Estado, UsrSistema, Respuesta, sCveGerente, sCveSoc, CveCorreo As String
    Public CveOfi, CveArea As String
    Public IdProp As Integer
    Public IdTipo As Char
    Private OK As Integer
    Private bsFun As New BindingSource
    Private bsAcc As New BindingSource

    Private Sub frmSAPYCAltaCteFiscales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.dgvFuncionarios.DataSource = bsFun
        Me.dgvAccionistas.DataSource = bsAcc

        LimpiaReg()
        If IdProp <> 0 Then
            UsrSistema = sTipo

            CargaCombos()
            ConsultaPropuesta()
            CargaDatos()
            gridClaves.Visible = False
            ConsultaCartaServicio(IdProp)

            PasaNomb = True

            If sCveCliente <> "" Then
                ConsultaFuncionariosClientes()
                ConsultaAccionistasClientes()
            Else
                ConsultaFuncionarios()
                ConsultaAccionistas()
            End If
        End If

    End Sub
    Public Sub CargaDatos()
        Try

            'sSQL = "SELECT DISTINCT MAX(CVECTENEW) CVECLIENTE,NOMBRECTE NOMBRE FROM CLIENTES "
            'sSQL += " WHERE CVECTENEW IS NOT NULL AND CVECTENEW <> '' GROUP BY NOMBRECTE ORDER BY NOMBRE"

            sSQL = " SELECT  CVECTE CVECLIENTE,NOMBRECTE NOMBRE FROM ( "
            sSQL += " SELECT  ROW_NUMBER() OVER ( "
            sSQL += " Partition BY REPLACE(REPLACE(NOMBRECTE,'.',''),',','') "
            sSQL += "      ORDER BY NOMBRECTE desc "
            sSQL += " ) AS rn, "
            sSQL += " MAX(CVECTE) CVECTE, REPLACE(REPLACE(NOMBRECTE,'.',''),',','') NOMBRECTE "
            sSQL += " From CLIENTES "
            sSQL += " Where STATUS = 'A' "
            sSQL += " GROUP BY  NOMBRECTE) T "
            sSQL += " WHERE T.rn = 1 "

            ' Inicializar la conexión y abrir   
            Using cn As SqlConnection = New SqlConnection(CadenaConexionSiat)
                cn.Open()

                ' Inicializar DataAdapter indicando el sql para recuperar    
                'los registros de la tabla   
                '                sSQL = "SELECT CVEEMP, NOMBRE, CVEPUESTO FROM EMPLEADOS WHERE STATUS = 'A' ORDER BY CVEEMP ASC "
                Dim da As New SqlDataAdapter(sSQL, cn)
                Dim dt As New DataTable ' crear un DataTable   

                ' llenarlo   
                da.Fill(dt)

                ' enlazar el DataTable al BindingSource   
                BindingSource1.DataSource = dt
                gridClaves.DataSource = BindingSource1.DataSource

                ' Lista.Columns("CVECTE").HeaderText = "No"
                gridClaves.Columns("NOMBRE").HeaderText = "Nombre"
                gridClaves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                gridClaves.Columns(0).Width = 80
                gridClaves.Columns(1).Width = 500

            End Using
            ' errores   
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub CargaCombos()

        sSQL = "SELECT DISTINCT E.CVEOFI,O.DESCOFI "
        sSQL += "FROM EMP_AREAS E "
        sSQL += "INNER JOIN OFICINAS O ON O.CVEOFI = E.CVEOFI "
        'sSQL += " WHERE CVEEMP ='" & sCveGerente & "' "
        Carga_ComboSapycSiat(cboOficina, sSQL)


        sSQL = "SELECT DISTINCT E.CVEAREA,A.DESCAREA "
        sSQL += "FROM EMP_AREAS E "
        sSQL += "INNER JOIN AREAS A ON A.CVEAREA = E.CVEAREA "
        'sSQL += "WHERE CVEEMP ='" & sCveGerente & "' "
        Carga_ComboSapycSiat(cboDivision, sSQL)

        sSQL = "SELECT IDNIVEL,NIVELRIESGO FROM NIVELRIESGO ORDER BY IDNIVEL"
        Carga_ComboSapyc(CmbNivel, sSQL)

    End Sub
    Private Sub txtNombreCte_TextChanged(sender As Object, e As EventArgs) Handles txtNombreCte.TextChanged

        If txtNombreCte.Text.Length = 0 Then
            PasaNomb = True
            gridClaves.Visible = False
        End If
        If PasaNomb Then
            If txtNombreCte.Text.Length > 0 Then
                Aplicar_FiltroNombre()
            End If
        End If
    End Sub
    Private Sub Aplicar_FiltroNombre()

        gridClaves.Visible = True
        ' filtrar por el campo Nombrecte
        Dim ret As Integer = Filtrar_DataGridView("NOMBRE", txtNombreCte.Text.Trim, BindingSource1, gridClaves)

        If ret > 0 Then
            ' si no hay registros cambiar el color del txtbox   
            'Cnombre.BackColor = Color.Red
            'If MsgBox("¿Este cliente se encuentra en las listas de clientes restringidos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta") = MsgBoxResult.Yes Then
            '    AltaCte = True
            'End If
        Else
            txtNombreCte.BackColor = Color.White
            gridClaves.Visible = False
        End If

    End Sub
    Function Filtrar_DataGridView(ByVal Columna As String, ByVal texto As String, ByVal BindingSource As BindingSource, ByVal DataGridView As DataGridView) As Integer

        ' verificar que el DataSource no esté vacio   
        If BindingSource1.DataSource Is Nothing Then
            Return 0
        End If

        Try

            Dim filtro As String = String.Empty

            'filtro = "like '" & texto.Trim & "%'"
            filtro = "like '%" & texto.Trim & "%'"

            ' Seleccionar la opción    
            '            Select Case Opcion_Filtro
            '               Case e_FILTER_OPTION.CADENA_QUE_COMIENCE_CON
            '                    filtro = "like '" & texto.Trim & "%'"
            '                 Case e_FILTER_OPTION.CADENA_QUE_NO_COMIENCE_CON
            '                    filtro = "Not like '" & texto.Trim & "%'"
            '                Case e_FILTER_OPTION.CADENA_QUE_NO_CONTENGA
            '                    filtro = "Not like '%" & texto.Trim & "%'"
            '                Case e_FILTER_OPTION.CADENA_QUE_CONTENGA
            '                    filtro = "like '%" & texto.Trim & "%'"
            '                Case e_FILTER_OPTION.CADENA_IGUAL
            '                    filtro = "='" & texto.Trim & "'"
            '            End Select

            ' Opción para no filtrar   
            '            If Opcion_Filtro = e_FILTER_OPTION.SIN_FILTRO Then
            ' filtro = String.Empty
            ' End If

            ' armar el sql   
            If filtro <> String.Empty Then
                filtro = "[" & Columna & "]" & filtro
            End If

            ' asigar el criterio a la propiedad Filter del BindingSource   
            BindingSource.Filter = filtro
            ' enlzar el datagridview al BindingSource   
            DataGridView.DataSource = BindingSource.DataSource

            ' retornar la cantidad de registros encontrados   
            Return BindingSource.Count

            ' errores   
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try

        Return 0

    End Function
    Private Sub Lista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridClaves.DoubleClick
        If gridClaves.SelectedRows.Count > 0 Then

            gridClaves.Visible = True
            ' filtrar por el campo Nombrecte
            Dim ret As Integer = Filtrar_DataGridView("NOMBRE", txtNombreCte.Text.Trim, BindingSource1, gridClaves)

            If ret > 0 Then
                ' si no hay registros cambiar el color del txtbox   
                'Cnombre.BackColor = Color.Red
                'If MsgBox("¿Este cliente se encuentra en las listas de clientes restringidos y no podras usarlo, si continuas se cerrara la pantalla?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta") = MsgBoxResult.Yes Then

                gridClaves.Visible = False
                PasaNomb = False
                txtNombreCte.Text = gridClaves.CurrentRow.Cells("NOMBRE").Value
                sNombreCte = gridClaves.CurrentRow.Cells("NOMBRE").Value
                'txtCveCLiente.Text = gridClaves.CurrentRow.Cells("CVECLIENTE").Value
                sCveCliente = gridClaves.CurrentRow.Cells("CVECLIENTE").Value

            Else
                txtNombreCte.BackColor = Color.White
            End If

        End If
    End Sub
    Public Sub LimpiaReg()

        Cnombrecte.Text = ""
        Cnombrecomercial.Text = ""
        Crfc.Text = ""
        Ccalle.Text = ""
        Cnumext.Text = ""
        Cnumint.Text = ""
        Ccolonia.Text = ""
        Cmunicipio.Text = ""
        Cestado.Text = ""
        Cpais.Text = ""
        Ccp.Text = ""
        Cemail.Text = ""
        Cregimen.Text = ""
        Permite = False
        sSQL = "SELECT CVEREGIMEN, DESCREGIMEN FROM REGIMEN ORDER BY CVEREGIMEN ASC "
        Carga_ComboSapycSat(CBregimen, sSQL)
        Permite = True

    End Sub
    Private Sub CBregimen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBregimen.SelectedIndexChanged
        If Permite Then
            Cregimen.Text = CBregimen.SelectedValue
        End If
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("Al realizar esta acción se perderá toda la información capturada, ¿desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.No Then
            Exit Sub
        End If
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If UsrSistema = "3" Then
                Dim Resp As String = Valida()
                If Resp = "" Then

                    If sCveSocio = "" Then
                        CveCorreo = sCveGerente
                    Else
                        CveCorreo = sCveSocio
                    End If
                    If sCveGerente = "" Then
                        CveCorreo = sCveSocio
                    Else
                        CveCorreo = sCveGerente
                    End If


                    ActualizaIndependencia()
                    ConsultaEnviaCorreos(sCveSocio, sCveGerente)
                Else
                    MsgBox(Resp, MsgBoxStyle.Information, "Error en captura")
                    Exit Sub
                End If
            ElseIf UsrSistema = "2" Then
                If CmbNivel.SelectedValue = 0 Then
                    MsgBox("Debes indicar un nivel de riesgo", MsgBoxStyle.Information, "Error en captura")
                    Exit Sub
                Else
                    If sCveSocio = "" Then
                        CveCorreo = sCveGerente
                    Else
                        CveCorreo = sCveSocio
                    End If
                    If sCveGerente = "" Then
                        CveCorreo = sCveSocio
                    Else
                        CveCorreo = sCveGerente
                    End If

                    ActualizaBackGC()
                    'ConsultaEnviaCorreosNivel(CveCorreo)
                End If
            Else
                Exit Sub
            End If

            MsgBox("Se actualizaron los datos con éxito", MsgBoxStyle.Information, "DATOS GUARDADOS")
            Me.Close()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub Crfc_Leave(sender As Object, e As EventArgs) Handles Crfc.Leave
        If Crfc.TextLength <> 12 And Crfc.TextLength <> 13 Then
            MsgBox("El RFC es incorrecto, vuelva a escribirlo por favor.", MsgBoxStyle.Exclamation, "Dato Incorrecto")
            Exit Sub
        End If

        If ExisteRFC(Me.Crfc.Text) Then
            MsgBox("No se puede dar de alta un RFC, por que ya esta dado de alta", MsgBoxStyle.Exclamation, "Nombre Incorrecto")
            Crfc.Text = ""
        Else
            Crfc.CharacterCasing = CharacterCasing.Upper
        End If

    End Sub
    Private Function ValidaDatos() As String
        Dim Resp As String = ""

        If txtNombreCte.Text = "" Then
            Resp = "No se indico el Nombre del Cliente!"
        End If
        If sCveCliente = "" Then
            Resp = "No se indico una clave de cliente!"
        End If
        If Cnombrecte.Text = "" Then
            Resp = "No se indico el Nombre del nuevo cliente físcal!"
        End If
        If Cnombrecomercial.Text = "" Then
            Resp = "No se indico el Nombre comercial del nuevo cliente!"
        End If
        If Crfc.Text = "" Then
            Resp = "No se ha especificado el RFC del cliente."
        End If
        If Ccalle.Text = "" Then
            Resp = "No se indico la calle!"
        End If
        If Cnumext.Text = "" Then
            Resp = "No se indico el número exterior!"
        End If
        If Ccolonia.Text = "" Then
            Resp = "No se indico la colonia."
        End If
        If Cmunicipio.Text = "" Then
            Resp = "No se indico la municipio."
        End If
        If Cestado.Text = "" Then
            Resp = "No se indico el estado."
        End If
        If Cpais.Text = "" Then
            Resp = "No se indico el pais."
        End If
        If Ccp.Text = "" Then
            Resp = "No se indico el codigo postal."
        End If
        If Cemail.Text = "" Then
            Resp = "No se indico el o los correos electronicos."
        End If
        If Cregimen.Text = "" Then
            Resp = "No se indico el regimen fiscal."
        End If

        Return Resp
    End Function
    Private Sub Cnombrecte_TextChanged(sender As Object, e As EventArgs) Handles Cnombrecte.TextChanged
        Cnombrecte.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Cnombrecomercial_TextChanged(sender As Object, e As EventArgs) Handles Cnombrecomercial.TextChanged
        Cnombrecomercial.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Crfc_TextChanged(sender As Object, e As EventArgs) Handles Crfc.TextChanged
        Crfc.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Ccalle_TextChanged(sender As Object, e As EventArgs) Handles Ccalle.TextChanged
        Ccalle.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Ccolonia_TextChanged(sender As Object, e As EventArgs) Handles Ccolonia.TextChanged
        Ccolonia.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Cmunicipio_TextChanged(sender As Object, e As EventArgs) Handles Cmunicipio.TextChanged
        Cmunicipio.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Cestado_TextChanged(sender As Object, e As EventArgs) Handles Cestado.TextChanged
        Cestado.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Cpais_TextChanged(sender As Object, e As EventArgs) Handles Cpais.TextChanged
        Cpais.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    Private Function ExisteRFC(ByVal Rfc As String) As Boolean
        Dim Resp As Boolean = False
        Try
            With ds.Tables
                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iTipo", 3, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sRfc", Rfc, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paConsultaTrabajoRecurrente") Then
                    .Remove("paConsultaTrabajoRecurrente")
                End If

                .Add(clsDatos.funExecuteSPDataTable("paConsultaTrabajoRecurrente"))

                dtRfc = .Item("paConsultaTrabajoRecurrente")
                If dtRfc.Rows.Count > 0 Then
                    Resp = True
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return Resp

    End Function
    Private Sub InsertaPropuesta()

        'Folio = CreaFolioSapyc(Coficinaasignada.SelectedValue)

        If Usuario_Tipo = "G" Then
            CveGerente = Usuario_Num
        ElseIf Usuario_Tipo = "S" Then
            CveSocio = Usuario_Num
        End If

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@CVEOFI", cboOficina.SelectedValue, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CVEAREA", cboDivision.SelectedValue, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@GIRO", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@ACT", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@NOMBEMPRESA", Cnombrecte.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOMBCONTACTOINICIAL", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CARGOCIA", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@EMAILCONTA", Cemail.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@TELEFONO", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@EXTTEL", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@PAIS", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@CALLE", Ccalle.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOINT", Cnumint.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOEXT", Cnumext.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CP", Ccp.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@COLONIA", Ccolonia.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@ESTADO", Cestado.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@MUNICIPIO", Cmunicipio.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@PAGWEB", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@RFC", Crfc.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@COMOSEENTERO", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@MEDIOCONTACTO", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@OTROCOMOENTERO", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@OTROMEDIOCONTACTO", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@SERVICIO", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@REVISION", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@CICLO", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@ESTATUS", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@OFIASIGNADA", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@SOCIO", CveSocio, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@ASOCIADO", CveGerente, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@REFERIDO", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@NOMREFERIDO", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@FACTURA", 0, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@cTipo", "F", SqlDbType.Char, ParameterDirection.Input)
                    .subAddParameter("@OFIREFE", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CVEGPO", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@SECTOR", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@TENEDORA", 0, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@EMPTENEDORA", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@PAISTENEDORA", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@FOLIO", "", SqlDbType.VarChar, ParameterDirection.Input)

                    .subAddParameter("@CONFLICTOINDEPE", 0, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@CONFLICTOCHECK", 0, SqlDbType.Bit, ParameterDirection.Input)


                    .subAddParameter("@ESREFERENCIA", 0, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@CVEOFIREF", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CVEAREAREF", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@SOCIOREF", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@HONOREF", "", SqlDbType.VarChar, ParameterDirection.Input)

                    .subAddParameter("@SOLICITO", "S", SqlDbType.Char, ParameterDirection.Input)
                    .subAddParameter("@CVECTE", sCveCliente, SqlDbType.VarChar, ParameterDirection.Input)

                    .subAddParameter("@CVEREGIMEN", Cregimen.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOMBCOMERCIAL", Cnombrecomercial.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOMBCTE", txtNombreCte.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@PAISFIS", Cpais.Text, SqlDbType.VarChar, ParameterDirection.Input)


                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
                dtPropuesta = .Item("paEmpresaPropuesta")

                If dtPropuesta.Rows.Count > 0 Then
                    Dim IdProp As Integer = dtPropuesta(0)(0)
                    InsertaBitacora(IdProp)
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    'Private Sub ActualizaPropuesta()

    '    If OpSi.Checked Then
    '        Referido = True
    '    ElseIf OpNo.Checked Then
    '        Referido = False
    '    End If

    '    If rdSiCompañia.Checked Then
    '        Tenedora = True
    '    ElseIf rdNoCompañia.Checked Then
    '        Tenedora = False
    '    End If

    '    If OpPublico.Checked Then
    '        SECTOR = "Público"
    '    ElseIf OpPrivado.Checked Then
    '        SECTOR = "Privado"
    '    ElseIf OpGobireno.Checked Then
    '        SECTOR = "Gobierno"
    '    ElseIf OpOtros.Checked Then
    '        SECTOR = "Otros"
    '    End If

    '    If rbPs.Checked Then
    '        tpoMoneda = "P"
    '    End If
    '    If rbDs.Checked Then
    '        tpoMoneda = "D"
    '    End If

    '    If CRechazo.SelectedValue <> 4 Or CRechazo.SelectedValue <> 6 Then
    '        tpoRechazo = 0
    '    Else
    '        tpoRechazo = CRechazo.SelectedValue
    '    End If


    '    Try
    '        With ds.Tables
    '            With clsLocal
    '                .subClearParameters()

    '                .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@iPropuesta", IdPropuesta, SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@sUsuario", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)

    '                .subAddParameter("@GIRO", CInt(Cgiro.SelectedValue), SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@ACT", CInt(Cactividad.SelectedValue), SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@NOMBCONTACTOINICIAL", Ccontactoinicial.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@CARGOCIA", Ccargocompania.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@EMAILCONTA", Cemailcontacto.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@TELEFONO", Ctelefono.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@EXTTEL", Cextension.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@PAIS", Cpais.SelectedValue, SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@CALLE", Ccalle.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@NOINT", Cnumint.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@NOEXT", Cnumext.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@CP", Ccp.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@COLONIA", txtColonia.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@ESTADO", txtEstado.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@MUNICIPIO", txtMunicipio.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@PAGWEB", Cpaginaweb.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@SERVICIO", CInt(Ctiposervicio.SelectedValue), SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@ESTATUS", CInt(Cestatuspropuesta.SelectedValue), SqlDbType.Int, ParameterDirection.Input)

    '                .subAddParameter("@SOCIO", CveSocio, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@ASOCIADO", CveGerente, SqlDbType.VarChar, ParameterDirection.Input)

    '                .subAddParameter("@REFERIDO", 1, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@NOMREFERIDO", Csocioref.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@OFIREFE", Coficinaref.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@CVEGPO", Ccvegpo.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@SECTOR", SECTOR, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@TENEDORA", Tenedora, SqlDbType.Bit, ParameterDirection.Input)
    '                .subAddParameter("@EMPTENEDORA", txtEmpresaTenedora.Text, SqlDbType.VarChar, ParameterDirection.Input)
    '                .subAddParameter("@PAISTENEDORA", cboPaisResidencia.Text, SqlDbType.VarChar, ParameterDirection.Input)


    '                .subAddParameter("@HONORARIOS", IIf(txtHonorarios.Text = "", 0, txtHonorarios.Text), SqlDbType.Decimal, ParameterDirection.Input)
    '                .subAddParameter("@TPOMONEDA", tpoMoneda, SqlDbType.Char, ParameterDirection.Input)
    '                .subAddParameter("@TPORECHAZO", tpoRechazo, SqlDbType.Int, ParameterDirection.Input)
    '                .subAddParameter("@DESCRECHAZO", txtDescRechazo.Text, SqlDbType.VarChar, ParameterDirection.Input)


    '            End With

    '            If .Contains("paEmpresaPropuesta") Then
    '                .Remove("paEmpresaPropuesta")
    '            End If

    '            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))


    '            If ListaFuncionarios.Items.Count > 0 Then
    '                EliminaFuncionarios()
    '                InsertaFuncionarios()
    '            End If
    '            If ListaAccionistas.Items.Count > 0 Then
    '                EliminaAccionistas()
    '                InsertaAccionistas()
    '            End If

    '        End With
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub
    Private Sub InsertaBitacora(ByVal idProp As Integer)
        Try
            With ds.Tables
                With clsLocal

                    .subClearParameters()
                    .subAddParameter("@iOpcion", 17, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iPropuesta", idProp, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sTipoReg", "F", SqlDbType.Char, ParameterDirection.Input)
                    .subAddParameter("@sValorUno", 0, SqlDbType.Int, ParameterDirection.Input)

                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))

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


                    CveOfi = DtDatos(0)("CVEOFI").ToString()
                    CveArea = DtDatos(0)("CVEAREA").ToString()

                    sCveSocio = DtDatos(0)("CVESOC").ToString()
                    sCveGerente = DtDatos(0)("CVEASOC").ToString()


                    txtNombreCte.Text = DtDatos(0)("NOMBCTE").ToString()
                    Cnombrecte.Text = DtDatos(0)("NOMEMPRESA").ToString()
                    Cnombrecomercial.Text = DtDatos(0)("NOMBCOMERCIAL").ToString()
                    Crfc.Text = DtDatos(0)("RFC").ToString()

                    Ccalle.Text = DtDatos(0)("CALLE").ToString()
                    Cnumint.Text = DtDatos(0)("NOINT").ToString()
                    Cnumext.Text = DtDatos(0)("NOEXT").ToString()
                    Ccp.Text = DtDatos(0)("CP").ToString()
                    Ccolonia.Text = DtDatos(0)("COLONIA").ToString()
                    Cestado.Text = DtDatos(0)("ESTADO").ToString()
                    Cmunicipio.Text = DtDatos(0)("MUNICIPIO").ToString()

                    cboOficina.SelectedValue = CveOfi 'DtDatos(0)("OFICINA").ToString()
                    cboDivision.SelectedValue = CveArea 'DtDatos(0)("DIVISION").ToString()

                    Cpais.Text = DtDatos(0)("PAISFIS").ToString()
                    Cemail.Text = DtDatos(0)("EMAILCONTACTO").ToString()
                    Cpais.Text = DtDatos(0)("PAISFIS").ToString()
                    Cregimen.Text = DtDatos(0)("CVEREGIMEN").ToString()
                    gridClaves.Visible = False

                    sCveSoc = DtDatos(0)("CVESOC").ToString()
                    sCveGerente = DtDatos(0)("CVEASOC").ToString()
                    sCveCliente = DtDatos(0)("CVECTE").ToString()

                    txtJustifica.Text = DtDatos(0)("JUSTIFICA").ToString()


                    If IsDBNull(DtDatos(0)("ANTERIOR")) Or DtDatos(0)("ANTERIOR") = 0 Then
                        rbPSno.Checked = True
                    Else
                        rbPSsi.Checked = True
                    End If

                    ConsultaSocio(sCveSoc)
                    ConsultaGerente(sCveGerente)

                    'btnGuardar.Visible = False
                    btnSalir.Visible = False
                    BtnCerrar.Visible = True

                    txtNombreCte.ReadOnly = True
                    Cnombrecte.ReadOnly = True
                    Cnombrecomercial.ReadOnly = True
                    Crfc.ReadOnly = True
                    Ccalle.ReadOnly = True
                    Cnumext.ReadOnly = True
                    Ccolonia.ReadOnly = True
                    Cmunicipio.ReadOnly = True
                    Cestado.ReadOnly = True
                    Cpais.ReadOnly = True
                    Cemail.ReadOnly = True
                    Ccp.ReadOnly = True
                    Cregimen.Enabled = True

                    CBregimen.Enabled = False
                    cboOficina.Enabled = False
                    cboDivision.Enabled = False

                    '''Visualiza paneles'''
                    If UsrSistema = "3" Then
                        gpBgc.Enabled = False
                        gpBgc.Visible = True
                        GBCC.Visible = True
                        'Cuadro.TabPages(4).Enabled = False
                    ElseIf UsrSistema = "2" Then
                        GBCC.Enabled = False
                        GBCC.Visible = True
                        gpBgc.Visible = True
                        ' Cuadro.TabPages(4).Enabled = False
                    ElseIf UsrSistema = "1" Then
                        gpBgc.Visible = True
                        GBCC.Visible = True
                        'Cuadro.TabPages(4).Enabled = False
                        gpBgc.Enabled = False
                        GBCC.Enabled = False
                    End If

                    CmbNivel.SelectedValue = DtDatos(0)("NIVELRIESGO").ToString()

                    If DtDatos(0)("NIVELRIESGO") > 0 Then
                        gpBgc.Enabled = False
                    End If
                    OK = DtDatos(0)("CONFLICTODEINDEPENDENCIA")

                    If OK > 0 Then
                        GBCC.Enabled = False
                    End If

                    If OK = 2 Then
                        rbSi.Checked = True
                        txtMotivoIndepen.Text = DtDatos(0)("MOTIVODELCONFLICTO").ToString()
                    ElseIf OK = 1 Then
                        rbNo.Checked = True
                    End If




                End If


            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function Valida() As String
        Dim Resp = ""

        If rbSi.Checked Then
            If txtMotivoIndepen.Text = "" Then
                Resp = "Debes indicar el motivo del conflicto"
            End If
        End If

        Return Resp


    End Function
    Private Sub ActualizaIndependencia()
        Dim IND As Integer

        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)

                If rbSi.Checked Then
                    IND = 2
                End If
                If rbNo.Checked Then
                    IND = 1
                End If

                .subAddParameter("@bIndependencia", IND, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sMotInd", txtMotivoIndepen.Text, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))

        End With
    End Sub
    Private Sub ActualizaBackGC()

        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iNivRiesgo", CmbNivel.SelectedValue, SqlDbType.Int, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))

        End With
    End Sub
    Public Sub ConsultaEnviaCorreos(CVESOC As String, CVEASOC As String)
        Dim ListaCorreos As String = ""
        Dim ListaNombres As String = ""
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 20, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@ASOCIADO", CVEASOC, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@SOCIO", CVESOC, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))

                dtCorreos = .Item("paEmpresaPropuesta")
                If dtCorreos.Rows.Count > 0 Then
                    For Each dr As DataRow In dtCorreos.Rows
                        If Not IsDBNull(dr("EMAIL")) Then
                            ListaCorreos += dr("EMAIL").ToString() + ","
                            ListaNombres += dr("NOMBRE").ToString() + ","
                        End If
                    Next
                    ListaCorreos = ListaCorreos + "backgroundcheck@mx.gt.com" + "," + "independencia@mx.gt.com"
                    EnvioCorreoSocio(ListaCorreos, ListaNombres.TrimEnd(","))
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub ConsultaEnviaCorreosNivel(CVESOC As String)
        Dim ListaCorreos As String = ""
        Dim ListaNombres As String = ""
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 20, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@ASOCIADO", CVESOC, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))

                dtCorreos = .Item("paEmpresaPropuesta")
                If dtCorreos.Rows.Count > 0 Then
                    For Each dr As DataRow In dtCorreos.Rows
                        If Not IsDBNull(dr("EMAIL")) Then
                            ListaCorreos += dr("EMAIL").ToString() + ","
                            ListaNombres += dr("NOMBRE").ToString() + ","
                        End If
                    Next

                    ListaCorreos = ListaCorreos + "backgroundcheck@mx.gt.com"
                    EnvioCorreoSocioNIVEL(ListaCorreos, ListaNombres.TrimEnd(","))
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub EnvioCorreoSocioNIVEL(Correo As String, NombSocio As String)
        Dim sCorreo(), sMensaje As String
        Try

            sCorreo = Correo.Split(",")
            sMensaje = "Estimado(a) " & NombSocio & ", " & vbNewLine & vbNewLine

            sMensaje &= "Se identifico el nivel de riesgo " & CmbNivel.Text & " "
            sMensaje &= "Se ha realizado la investigación de antecedentes de la entidad para facturar " & Cnombrecte.Text.ToUpper() & "  , con la cual NO se identificó situación alguna que afecte nuestra independencia. "
            sMensaje &= "Para cualquier aclaración sobre el tema contactar a cecilia.coronel@mx.gt.com y heidi.martinez@mx.gt.com"
            envioCorreos(sCorreo, sMensaje, "Propuestas Clientes - Sapyc")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub EnvioCorreoSocio(Correo As String, NombSocio As String)
        Dim sCorreo(), sMensaje As String
        Try

            sCorreo = Correo.Split(",")
            sMensaje = "Estimado(a) " & NombSocio & ", " & vbNewLine & vbNewLine

            If rbNo.Checked Then
                Respuesta = "NO"
            ElseIf rbSi.Checked Then
                Respuesta = "SI"
            End If

            sMensaje &= "Se ha realizado la investigación de antecedentes de la entidad para facturar " & Cnombrecte.Text.ToUpper() & "  , con la cual " & Respuesta.ToString() & " se identificó situación alguna que afecte nuestra independencia. "
            sMensaje &= "Para cualquier aclaración sobre el tema contactar a cecilia.coronel@mx.gt.com y heidi.martinez@mx.gt.com"
            envioCorreos(sCorreo, sMensaje, "Propuestas Clientes - Sapyc")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub rbSi_CheckedChanged(sender As Object, e As EventArgs) Handles rbSi.CheckedChanged
        rbNo.Checked = False
        lblMotivo.Visible = True
        txtMotivoIndepen.Visible = True
    End Sub
    Private Sub rbNo_CheckedChanged(sender As Object, e As EventArgs) Handles rbNo.CheckedChanged
        rbSi.Checked = False
        lblMotivo.Visible = False
        txtMotivoIndepen.Visible = False
    End Sub
    Public Sub ConsultaSocio(Cvesocio As String)

        Try

            With ds.Tables
                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iTipo", 7, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSoc", Cvesocio, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                If .Contains("paConsultaTrabajoRecurrente") Then
                    .Remove("paConsultaTrabajoRecurrente")
                End If

                .Add(clsDatosInv.funExecuteSPDataTable("paConsultaTrabajoRecurrente"))

                dtSocios = .Item("paConsultaTrabajoRecurrente")
                If dtSocios.Rows.Count > 0 Then
                    txtSoc.Text = dtSocios(0)("NOMBRE")
                End If


            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Public Sub ConsultaGerente(CveGerente As String)

        Try

            With ds.Tables
                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iTipo", 7, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveSoc", CveGerente, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paConsultaTrabajoRecurrente") Then
                    .Remove("paConsultaTrabajoRecurrente")
                End If

                .Add(clsDatosInv.funExecuteSPDataTable("paConsultaTrabajoRecurrente"))

                dtGerentes = .Item("paConsultaTrabajoRecurrente")
                If dtGerentes.Rows.Count > 0 Then
                    txtGerente.Text = dtGerentes(0)("NOMBRE")
                End If


            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub ConsultaFuncionariosClientes()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 27, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@CVECTE", sCveCliente, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paEmpresaPropuesta") Then
                .Remove("paEmpresaPropuesta")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            dtFuncionarios = .Item("paEmpresaPropuesta")

            If dtFuncionarios.Rows.Count > 0 Then
                bsFun.DataSource = dtFuncionarios
            End If


        End With
    End Sub
    Private Sub ConsultaAccionistasClientes()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 28, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@CVECTE", sCveCliente, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paEmpresaPropuesta") Then
                .Remove("paEmpresaPropuesta")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
            dtAccionistas = .Item("paEmpresaPropuesta")

            If dtAccionistas.Rows.Count > 0 Then

                If dtAccionistas.Rows.Count > 0 Then
                    bsAcc.DataSource = dtAccionistas
                End If

            End If

        End With
    End Sub
    Private Sub ConsultaFuncionarios()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            dtFuncionarios = .Item("paSapyc")

            If dtFuncionarios.Rows.Count > 0 Then
                bsFun.DataSource = dtFuncionarios
            End If


        End With
    End Sub
    Private Sub ConsultaAccionistas()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            dtAccionistas = .Item("paSapyc")

            If dtAccionistas.Rows.Count > 0 Then

                If dtAccionistas.Rows.Count > 0 Then
                    bsAcc.DataSource = dtAccionistas
                End If

            End If

        End With
    End Sub
    Private Sub ConsultaPROPUESTAS()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            dtAccionistas = .Item("paSapyc")

            If dtAccionistas.Rows.Count > 0 Then

                If dtAccionistas.Rows.Count > 0 Then
                    bsAcc.DataSource = dtAccionistas
                End If

            End If

        End With
    End Sub
    Public Sub ConsultaCartaServicio(IdProp As String)

        Try

            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 11, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idPropuesta", IdProp, SqlDbType.VarChar, ParameterDirection.Input)

                End With

                If .Contains("paStatusPropuestas") Then
                    .Remove("paStatusPropuestas")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paStatusPropuestas"))

                dtServicios = .Item("paStatusPropuestas")
                If dtServicios.Rows.Count > 0 Then
                    lblPdf.Text = "\\Gtmexvts32\aplica\DesarrollosFinanzas\PROPUESTASERVICIO\" & dtServicios(0)("sNombre") & ".pdf"

                End If


            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub


End Class