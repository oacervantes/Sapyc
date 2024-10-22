Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Net.Mail
Imports System.IO
Imports System.Xml
Imports System.Net
Module Util


    Public sNombre, sTipo As String

    Public NombreBaseDatos As String = "BDINV2012"
    Public NombreBaseDatosAnt As String = "BDINV2012"

    Public NombreTabla As String
    Public NombreBaseDatosRT As String = "BDREPORTE"
    Public NombreBDRep As String = "REPORTES"
    Public NombreBDPre As String = ""
    Public AyoPres As String = ""

    Public NombreBaseSAT As String = "BDSAT"

    Public NombreBaseDatosSapyc As String = "SAPYC2"
    Public NombreBaseDatosSapyc2 As String = "SAPYC2"

    Public NombreBaseDatosConta As String = "CON2013"

    Public DirBDREP As String = "C:\SALLES\REPINV"
    Public DirReportes As String = "C:\SALLES\REPINV\"
    Public NombreEmpresa As String = "SALLES, SAINZ GRANT THORNTON, S.C."
    Public Ayo_trabajo As String = "2011"
    Public NombreBDTraspaso As String = "BDTP"
    Public DirBDTraspaso As String = "C:\ADEOC\SALLES\DATOSOLD"

    Public DirExcel As String = "C:\SALLES\EXCEL"

    Public sSQL As String

    Public DirTPAnterior As String = "C:\SALLES\TP\"
    Public ArFteDbase As String = "TIEMPO.DBF"
    Public ArFteDbaseNC As String = "TRASFAC.DBF"
    Public DirDbase As String = "C:\SALLES\TP"

    Public Forma As System.Windows.Forms.Form

    Public Usuario_Num As String
    Public Usuario_Nombre As String
    Public Usuario_Tipo As String
    Public Usuario_Firma As String
    Public Usuario_Puesto As String
    Public Usuario_Dir As String
    Public Usuario_Instruccion1 As String
    Public Usuario_Instruccion2 As String
    Public Usuario_HabilitaPre As String
    Public Usuario_ResumenGpo As String
    Public Usuario_Gpo As String

    Public Usuario_Sapyc As String


    Public Function CadenaConexionSapyc() As String
        Dim lacadena As String
        '  ******************** Servidor local *************
        'lacadena = "Data Source=.\sqlexpress;Initial Catalog=" & NombreBaseDatosSapyc & ";Integrated Security=True" ' servidor local

        ' **************************** SERVIDOR NUEVO SSGTMEX
        lacadena = "data source = gtmexvts27\sql2016; initial catalog = SAPYC2; user id = Contabilidad; password = Control2025%Porfis"       ' nuevo servidor

        Return lacadena
    End Function
    Public Function CadenaConexionCon() As String
        Dim lacadena As String
        ' ******** SERVIDOR LOCAL
        'lacadena = "Data Source=.\sqlexpress;Initial Catalog=CONTROLINV;Integrated Security=True" ' servidor local


        ' ******** Nuevo Servidor de SALLES
        lacadena = "data source = gtmexvts27\sql2016; initial catalog = BDINV2223; user id = Contabilidad; password = Control2025%Porfis"           ' nuevo servidor

        Return lacadena
    End Function
    Public Function CadenaConexionSiat() As String
        Dim lacadena As String
        ' ******** SERVIDOR LOCAL
        'lacadena = "Data Source=.\sqlexpress;Initial Catalog=BDINV2022;Integrated Security=True" ' servidor local


        ' ******** Nuevo Servidor de SALLES
        lacadena = "data source = gtmexvts27\sql2016; initial catalog = BDINV2223; user id = Contabilidad; password = Control2025%Porfis"           ' nuevo servidor

        Return lacadena
    End Function
    Public Function CadenaConexionSat() As String
        Dim lacadena As String
        ' ******** SERVIDOR LOCAL
        'lacadena = "Data Source=.\sqlexpress;Initial Catalog=CONTROLINV;Integrated Security=True" ' servidor local


        ' ******** Nuevo Servidor de SALLES
        lacadena = "data source = gtmexvts27\sql2016; initial catalog = BDSAT; user id = Contabilidad; password = Control2025%Porfis"           ' nuevo servidor

        Return lacadena
    End Function
    Public Function CadenaConexion() As String
        Dim lacadena As String
        '  ******************** Servidor local *************
        'lacadena = "Data Source=.\sqlexpress;Initial Catalog=" & NombreBaseDatosSapyc & ";Integrated Security=True" ' servidor local

        ' **************************** SERVIDOR NUEVO SSGTMEX
        lacadena = "data source = gtmexvts27\sql2016; initial catalog = " & NombreBaseDatosSapyc & "; user id = Contabilidad; password = Control2025%Porfis"           ' nuevo servidor

        Return lacadena
    End Function
    Public Sub Carga_ComboSapyc(ByVal ComboBox As ComboBox, ByVal sql As String)
        ' nueva conexión indicando al SqlConnection la cadena de conexión   
        Dim cn As New SqlConnection
        cn.ConnectionString = CadenaConexionSapyc()

        Try

            ' Abrir la conexión a Sql   
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command    
            Dim cmd As New SqlCommand(sql, cn)

            ' Inicializar un nuevo SqlDataAdapter    
            Dim da As New SqlDataAdapter(cmd)

            'Crear y Llenar un Dataset   
            Dim ds As New DataSet
            da.Fill(ds)

            ' asignar el DataSource al combobox   
            ComboBox.DataSource = ds.Tables(0)

            ' Asignar el campo a la propiedad DisplayMember del combo    
            ComboBox.DisplayMember = ds.Tables(0).Columns(1).Caption.ToString
            ComboBox.ValueMember = ds.Tables(0).Columns(0).Caption.ToString

            ComboBox.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString,
                            "error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub
    Public Sub Carga_ComboSapycSiat(ByVal ComboBox As ComboBox, ByVal sql As String)
        ' nueva conexión indicando al SqlConnection la cadena de conexión   
        Dim cn As New SqlConnection
        cn.ConnectionString = CadenaConexionCon()

        Try

            ' Abrir la conexión a Sql   
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command    
            Dim cmd As New SqlCommand(sql, cn)

            ' Inicializar un nuevo SqlDataAdapter    
            Dim da As New SqlDataAdapter(cmd)

            'Crear y Llenar un Dataset   
            Dim ds As New DataSet
            da.Fill(ds)

            ' asignar el DataSource al combobox   
            ComboBox.DataSource = ds.Tables(0)

            ' Asignar el campo a la propiedad DisplayMember del combo    
            ComboBox.DisplayMember = ds.Tables(0).Columns(1).Caption.ToString
            ComboBox.ValueMember = ds.Tables(0).Columns(0).Caption.ToString

            ComboBox.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString,
                            "error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub
    Public Sub Carga_ComboSapycSat(ByVal ComboBox As ComboBox, ByVal sql As String)
        ' nueva conexión indicando al SqlConnection la cadena de conexión   
        Dim cn As New SqlConnection
        cn.ConnectionString = CadenaConexionSat()

        Try

            ' Abrir la conexión a Sql   
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command    
            Dim cmd As New SqlCommand(sql, cn)

            ' Inicializar un nuevo SqlDataAdapter    
            Dim da As New SqlDataAdapter(cmd)

            'Crear y Llenar un Dataset   
            Dim ds As New DataSet
            da.Fill(ds)

            ' asignar el DataSource al combobox   
            ComboBox.DataSource = ds.Tables(0)

            ' Asignar el campo a la propiedad DisplayMember del combo    
            ComboBox.DisplayMember = ds.Tables(0).Columns(1).Caption.ToString
            ComboBox.ValueMember = ds.Tables(0).Columns(0).Caption.ToString

            ComboBox.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString,
                            "error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub
    Public Sub DeshabilitaMenu()
        Principal.MenuStrip1.Enabled = False
        Principal.Barra.Enabled = False
    End Sub
    Public Sub HabilitaMenu()
        Principal.MenuStrip1.Enabled = True
        Principal.Barra.Enabled = True
    End Sub
    Public Sub BuscaProximo(ByVal Listado As DataGridView, ByVal qcol As Integer, ByVal lobuscado As String)
        Dim Sehayo As Boolean
        Dim ii As Integer
        Dim eltama As Integer
        Dim subcade As String

        Sehayo = False
        ii = 0
        eltama = lobuscado.Length
        Do While ii < Listado.RowCount And Not Sehayo
            If Listado.Rows(ii).Cells(qcol).Value().ToString.Length >= eltama Then
                subcade = Listado.Rows(ii).Cells(qcol).Value().ToString.Substring(0, eltama)
            Else
                subcade = Listado.Rows(ii).Cells(qcol).Value().ToString
            End If


            If subcade >= lobuscado Then
                '                If Listado.Rows(ii).Cells(qcol).Value() = lobuscado Then
                Listado.FirstDisplayedScrollingRowIndex = ii
                Listado.Rows(ii).Selected = True
                Listado.CurrentCell = Listado.Rows(ii).Cells(0)
                Sehayo = True
            Else
                ii = ii + 1
            End If
        Loop
        '        If Not Sehayo Then
        '        MsgBox("Dato: " & lobuscado & ", no encontrado!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Dato no encontrado")
        '        End If
    End Sub
    Public Function PonCeros4(ByVal elnum As Double) As String
        Dim lacad As String

        lacad = "0000"
        If elnum < 10 Then
            lacad = "000" & Trim(Str(elnum))
        ElseIf elnum > 9 And elnum < 100 Then
            lacad = "00" & Trim(Str(elnum))
        ElseIf elnum > 99 And elnum < 1000 Then
            lacad = "0" & Trim(Str(elnum))
        Else
            lacad = Trim(Str(elnum))
        End If

        Return lacad
    End Function
    Public Function EnviarCorreosHTML(sCtasDestino() As String, sMensajeCorreo As String, sTitulo As String, Optional cPrioridad As Char = "N") As Boolean
        Dim bEnviado As Boolean = False

        If sCtasDestino.Count <= 0 Then
            MsgBox("No se especificaron las cuentas de correo a las que se enviará el mensaje.", MsgBoxStyle.Exclamation, "Cuentas de correo faltantes")
            Return False
        End If

        Try
            Dim correo As New MailMessage With {
                .From = New MailAddress(sCorreo)
            }

            If cPrioridad = "A" Then
                correo.Priority = MailPriority.High
            ElseIf cPrioridad = "B" Then
                correo.Priority = MailPriority.Low
            Else
                correo.Priority = MailPriority.Normal
            End If

            correo.Subject = sTitulo
            For i = 0 To sCtasDestino.Count - 1
                If sCtasDestino(i) <> " " Then
                    correo.To.Add(sCtasDestino(i))
                End If
            Next
            correo.Bcc.Add("siat@mx.gt.com, Octavio.A.Cervantes@mx.gt.com, Mario.Rodriguez@mx.gt.com")

            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(sMensajeCorreo, Nothing, "text/html")
            Dim img As New LinkedResource("\\GTMEXVTS32\APLICA\CON2012\IMG\header_RD.jpg", "image/jpeg") With {
                .ContentId = "imagen1"
            }
            htmlView.LinkedResources.Add(img)

            'correo.Body = sMensajeCorreo
            correo.AlternateViews.Add(htmlView)

            'Configuracion del servidor
            Dim Servidor As New SmtpClient With {
                .Host = sServidor,
                .Port = iPuerto,
                .EnableSsl = bSSL,
                .UseDefaultCredentials = False,
                .DeliveryMethod = SmtpDeliveryMethod.Network
            }
            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            Servidor.Credentials = New NetworkCredential(sCorreo, sContraseña)
            Servidor.Send(correo)
            bEnviado = True
        Catch e As Exception
            MsgBox("Error al enviar mensaje: " & e.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return bEnviado
    End Function

End Module
