Imports System.Data.SqlClient

Public Class frmAltaConflick

    Public IdProp As Integer
    Public IdTipo As Char
    Private ds As New DataSet
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Public CveDivision, sNombreCte, sCveCliente, CveGerente, CveSocio, CveArea, CveOfi, sCveSocio, sCveGerente, sMailGent, sMailSoc As String
    Private dtRfc, dtPropuesta, DtDatos, dtFuncionarios, dtAccionistas, dtOfiArea, dtGerentes, dtSocios, dtTrabajos As DataTable
    Private Nom, Apat, Amat, CargoTemp, perMoralTemp, PorcTemp, Colonia, Municipio, Estado, UsrSistema, Respuesta, sCveSoc, CveCorreo As String
    Private PasaNomb As Boolean = False
    Public IdPropuesta As Integer
    Private bsFun As New BindingSource
    Private bsAcc As New BindingSource
    Private bsTra As New BindingSource
    Private OK As Integer

    Private Sub frmAltaConflick_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.dgvFuncionarios.DataSource = bsFun
        Me.dgvAccionistas.DataSource = bsAcc
        Me.dgTrabajos.DataSource = bsTra
        dtFuncionarios = New DataTable
        dtAccionistas = New DataTable

        UsrSistema = sTipo

        BaltaFun.Visible = False
        BbajaFun.Visible = False
        BaltaAcc.Visible = False
        BbajaAcc.Visible = False

        PasaNomb = True
        gridClaves.Visible = False
        CargaDatos()
        CargaCombos()
        txtMotivo.Text = ""
        CargaOficinaArea()

        If IdProp <> 0 Then
            ConsultaPropuesta()

            ConsultaSocio(sCveSocio)
            ConultaGerente(sCveGerente)

            ConsultaFuncionariosClientes()
            ConsultaAccionistasClientes()
            ConsultaTrabajos()

        End If

        If Usuario_Tipo = "S" Then
            txtSocio.Enabled = False
            txtNombreSocio.Enabled = False
            txtNombreSocio.Text = Usuario_Nombre
            txtSocio.Text = Usuario_Num
        ElseIf Usuario_Tipo = "G" Then
            txtGerente.Enabled = False
            txtNombreGerente.Enabled = False
            txtNombreGerente.Text = Usuario_Nombre
            txtGerente.Text = Usuario_Num
        End If

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
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
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

        'If sTipoUsuario = "S" Then

        '    sSQL = "SELECT DISTINCT E.sCveArea,A.DESCAREA FROM APERTURA_SOCIOS E "
        '    sSQL += "INNER JOIN AREAS A ON A.CVEAREA = E.sCveArea "
        '    sSQL += "WHERE  e.sCveSocio ='" & Usuario_Num & "' "
        '    Carga_ComboSapycSiat(cboDivision, sSQL)

        '    sSQL = "SELECT DISTINCT E.sCveOfi,O.DESCOFI FROM APERTURA_SOCIOS E  "
        '    sSQL += "INNER JOIN OFICINAS O ON O.CVEOFI = E.sCveOfi  "
        '    sSQL += " WHERE  e.sCveSocio  ='" & Usuario_Num & "' "
        '    Carga_ComboSapycSiat(cboOficina, sSQL)
        'Else
        '    sSQL = "SELECT DISTINCT E.CVEAREA,A.DESCAREA "
        '    sSQL += "FROM EMP_AREAS E "
        '    sSQL += "INNER JOIN AREAS A ON A.CVEAREA = E.CVEAREA "
        '    sSQL += "WHERE CVEEMP ='" & Usuario_Num & "' "
        '    Carga_ComboSapycSiat(cboDivision, sSQL)

        '    sSQL = "SELECT DISTINCT E.CVEOFI,O.DESCOFI "
        '    sSQL += "FROM EMP_AREAS E "
        '    sSQL += "INNER JOIN OFICINAS O ON O.CVEOFI = E.CVEOFI "
        '    sSQL += " WHERE CVEEMP ='" & Usuario_Num & "' "
        '    Carga_ComboSapycSiat(cboOficina, sSQL)
        'End If
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
    Private Sub CargaOficinaArea()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 9, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sUsuario", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            dtOfiArea = .Item("paSapyc")

            If dtOfiArea.Rows.Count > 0 Then
                CveArea = dtOfiArea(0)("CVEAREA").ToString
                CveOfi = dtOfiArea(0)("CVEOFI").ToString
            End If

        End With
    End Sub
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
                    .subAddParameter("@NOMBEMPRESA", txtNombreCte.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOMBCONTACTOINICIAL", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CARGOCIA", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@EMAILCONTA", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@TELEFONO", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@EXTTEL", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@PAIS", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@CALLE", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOINT", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOEXT", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@CP", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@COLONIA", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@ESTADO", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@MUNICIPIO", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@PAGWEB", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@RFC", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@COMOSEENTERO", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@MEDIOCONTACTO", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@OTROCOMOENTERO", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@OTROMEDIOCONTACTO", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@SERVICIO", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@REVISION", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@CICLO", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@ESTATUS", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@OFIASIGNADA", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@SOCIO", txtSocio.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@ASOCIADO", txtGerente.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@REFERIDO", 0, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@NOMREFERIDO", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@FACTURA", 0, SqlDbType.Bit, ParameterDirection.Input)
                    .subAddParameter("@cTipo", "C", SqlDbType.Char, ParameterDirection.Input)
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

                    .subAddParameter("@CVEREGIMEN", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOMBCOMERCIAL", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@NOMBCTE", txtNombreCte.Text, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@PAISFIS", "", SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sUsuario", Usuario_Num, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@FECHSOLIND", Date.Now, SqlDbType.Date, ParameterDirection.Input)
                    .subAddParameter("@MOTIVO", txtMotivo.Text, SqlDbType.VarChar, ParameterDirection.Input)


                End With

                If .Contains("paEmpresaPropuesta") Then
                    .Remove("paEmpresaPropuesta")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paEmpresaPropuesta"))
                dtPropuesta = .Item("paEmpresaPropuesta")

                If dtPropuesta.Rows.Count > 0 Then
                    Dim IdProp As Integer = dtPropuesta(0)(0)
                    'InsertaFuncionarios(IdProp)
                    'InsertaAccionistas(IdProp)
                    'InsertaBitacora(IdProp)
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function ValidaDatos() As String
        Dim Resp As String = ""


        If txtSocio.Text = "" Then
            Resp = "No se indico el Nombre del socio!"
        End If
        If txtGerente.Text = "" Then
            Resp = "No se indico el Nombre del gerente!"
        End If

        If txtNombreCte.Text = "" Then
            Resp = "No se indico el Nombre del Cliente!"
        End If
        If sCveCliente = "" Then
            Resp = "No se indico una clave de cliente!"
        End If
        If txtMotivo.Text = "" Then
            Resp = "No se indico el motivo de la solicitud del conflick!"
        End If
        If dtFuncionarios.Rows.Count <= 0 Then
            Resp = "Se debe especificar un funcionario."
        End If
        If dtAccionistas.Rows.Count <= 0 Then
            Resp = "Se debe especificar un accionista."
        End If


        Return Resp
    End Function
    Private Sub txtNombreCte_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtNombreCte.TextChanged

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
    Private Sub cboOficina_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboOficina.SelectionChangeCommitted
        CveOfi = cboOficina.SelectedValue
    End Sub
    Private Sub cboDivision_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDivision.SelectionChangeCommitted
        CveArea = cboDivision.SelectedValue
    End Sub
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

                BaltaFun.Visible = True
                BbajaFun.Visible = True
                BaltaAcc.Visible = True
                BbajaAcc.Visible = True
                ConsultaFuncionariosClientes()
                ConsultaAccionistasClientes()
                ConsultaTrabajos()
            Else
                txtNombreCte.BackColor = Color.White
            End If

        End If
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
    Private Sub EliminaAccionistasCliente(Nombre As String)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 22, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@NOMBRE", Nombre, SqlDbType.VarChar, ParameterDirection.Input)

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
    Private Sub EliminaFuncionariosCliente(Nombre As String)

        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()

                    .subAddParameter("@iOpcion", 21, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@NOMBRE", Nombre, SqlDbType.VarChar, ParameterDirection.Input)

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
                    txtNombreSocio.Text = dtSocios(0)("NOMBRE")
                    sMailSoc = dtSocios(0)("EMAIL")
                End If


            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Public Sub ConultaGerente(CveGerente As String)

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
                    txtNombreGerente.Text = dtGerentes(0)("NOMBRE")
                    sMailGent = dtGerentes(0)("EMAIL")
                End If


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

                    sCveSocio = DtDatos(0)("CVESOC").ToString()
                    sCveGerente = DtDatos(0)("CVEASOC").ToString()

                    txtGerente.Text = sCveGerente
                    txtSocio.Text = sCveSocio

                    txtNombreCte.Text = DtDatos(0)("NOMBCTE").ToString()
                    cboOficina.Text = DtDatos(0)("OFICINA").ToString()
                    cboDivision.Text = DtDatos(0)("DIVISION").ToString()

                    CveOfi = DtDatos(0)("CVEOFI").ToString()
                    CveArea = DtDatos(0)("CVEAREA").ToString()
                    sCveCliente = DtDatos(0)("CVECTE").ToString()
                    txtMotivo.Text = DtDatos(0)("MOTIVO").ToString()
                    txtServicio.Text = DtDatos(0)("NOMBCOMERCIAL").ToString()

                    cboOficina.SelectedValue = CveOfi
                    cboDivision.SelectedValue = CveArea

                    gridClaves.Visible = False


                    cboOficina.Enabled = False
                    cboDivision.Enabled = False

                    BaltaFun.Visible = False
                    BbajaFun.Visible = False
                    BaltaAcc.Visible = False
                    BbajaAcc.Visible = False


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
                    ListaCorreos = ListaCorreos + "independencia@mx.gt.com"
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
            sMensaje &= "Se ha realizado la investigación de antecedentes de la entidad para facturar " & txtNombreCte.Text.ToUpper() & "  , con la cual NO se identificó situación alguna que afecte nuestra independencia. "
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

            sMensaje &= "Se ha realizado la investigación de antecedentes de la entidad para facturar " & txtNombreCte.Text.ToUpper() & "  , con la cual " & Respuesta.ToString() & " se identificó situación alguna que afecte nuestra independencia. "
            sMensaje &= "Para cualquier aclaración sobre el tema contactar a cecilia.coronel@mx.gt.com y heidi.martinez@mx.gt.com"
            envioCorreos(sCorreo, sMensaje, "Propuestas Clientes - Sapyc")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub ConsultaTrabajos()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 12, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveCte", sCveCliente, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            dtTrabajos = .Item("paSapyc")

            If dtTrabajos.Rows.Count > 0 Then
                bsTra.DataSource = dtTrabajos
            End If


        End With
    End Sub
    Private Sub BtnInfoIncompleta_Click(sender As Object, e As EventArgs) Handles BtnInfoIncompleta.Click

        Dim Dlg As New dlgIncompletos

        Dlg.sCliente = txtNombreCte.Text
        Dlg.sCorreoSoc = sMailSoc
        Dlg.sCorreoGnt = sMailGent

        If Dlg.ShowDialog() = DialogResult.OK Then
            Me.Close()
        End If


    End Sub



End Class