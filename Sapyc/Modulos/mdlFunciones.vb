Imports System.Net
Imports System.Net.Mail

Module mdlFunciones

    Public sServidorCorreo As String
    Public sCorreo As String
    Public sContraseña As String
    Public iPuerto As Integer
    Public bSSL As Boolean

    Public Sub bloquearColumnas(ByVal grid As DataGridView)
        For Each col As DataGridViewColumn In grid.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Public Sub limpiarFilasTabla(ByRef dt As DataTable)
        If dt.Rows.Count > 0 Then
            dt.Clear()
        End If
    End Sub

    Public Sub limpiarArreglosDbl(ByVal arr() As Double, ByVal iPos As Integer)

        Try
            For x As Integer = 0 To iPos
                arr(x) = 0
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub limpiarArreglosInt(ByVal arr() As Integer, ByVal iPos As Integer)

        Try
            For x As Integer = 0 To iPos
                arr(x) = 0
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function envioCorreos(ByVal sCtasDestino() As String, ByVal sMensajeCorreo As String, ByVal sTitulo As String) As Boolean
        Dim bEnviado As Boolean = False

        If sCtasDestino.Count <= 0 Then
            MsgBox("No se especificaron las cuentas de correo a las que se enviará el mensaje.", MsgBoxStyle.Exclamation, "Cuentas de correo faltantes")
            Return False
        End If

        Try
            Dim correo As New System.Net.Mail.MailMessage()
            correo.From = New System.Net.Mail.MailAddress("siat@mx.gt.com")
            correo.Subject = sTitulo
            For i = 0 To sCtasDestino.Count - 1
                If sCtasDestino(i) <> " " Then
                    correo.To.Add(sCtasDestino(i))
                End If
            Next
            correo.Bcc.Add("siat@mx.gt.com")
            correo.Body = sMensajeCorreo

            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.Host = "smtp.office365.com"
            Servidor.Port = 587
            Servidor.EnableSsl = True
            Servidor.DeliveryMethod = SmtpDeliveryMethod.Network
            System.Net.ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            Servidor.Credentials = New System.Net.NetworkCredential("siat@mx.gt.com", "mndwlbkdqkqdpbrk")

            Servidor.Send(correo)
            bEnviado = True
        Catch e As Exception
            MsgBox("Error al enviar mensaje: " & e.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return bEnviado
    End Function

    Public Function cantidadEnletra(ByVal dCantidad As Decimal) As String
        Dim sImporteLetra As String = String.Empty
        Dim dDecimal As Decimal
        Dim iCantidad, dDif, dUni, dDec, dCen, dMil, dDecM, dCenM, dMill, dDecMill, dCenMill, dMilMill As Long

        Try
            sImporteLetra = ""

            'Se trunca el valor de dCantidad, para obtener el valor entero; la parte decimal se obtiene restando el valor de dCantidad menos el valor entero.
            iCantidad = Math.Truncate(dCantidad)
            dDecimal = (dCantidad - iCantidad)

            'Revisar el valor de iCantidad para ubicar los pasos a seguir.
            Select Case iCantidad
                'En este caso se obtendrán las unidades, decenas y centenas de iCantidad.
                Case < 1000
                    dCen = Math.Truncate(iCantidad / 100)
                    dDif = iCantidad - (dCen * 100)
                    dDec = Math.Truncate(dDif / 10)
                    dUni = dDif - (dDec * 10)

                    'Una vez obtenidas las unidades, decenas y centenas, la función nombreCantidad() devolverá en letras, el número escrito por el usuario.
                    sImporteLetra &= nombreCantidad(dCen, dDec, dUni)

                'En este caso se obtendrán las unidades, decenas y centenas en miles de iCantidad.
                Case < 1000000
                    dCenM = Math.Truncate(iCantidad / 100000)
                    dDif = iCantidad - (dCenM * 100000)
                    dDecM = Math.Truncate(dDif / 10000)
                    dDif -= (dDecM * 10000)
                    dMil = Math.Truncate(dDif / 1000)
                    dDif -= (dMil * 1000)
                    dCen = Math.Truncate(dDif / 100)
                    dDif -= (dCen * 100)
                    dDec = Math.Truncate(dDif / 10)
                    dUni = dDif - (dDec * 10)

                    'Se revisan diferentes condiciones para ir concatenando los nombres de las unidades, decenas y centenas.
                    'Ej.: unidades, decenas y/o centenas de miles en 0, (7,000.67).
                    'Ej.: unidades, decenas y/o centenas en 0, (98,289.56).

                    sImporteLetra &= nombreCantidad(dCenM, dDecM, dMil) & " mil"

                    If dCen > 0 Or dDec > 0 Or dUni > 0 Then
                        sImporteLetra &= " " & nombreCantidad(dCen, dDec, dUni)
                    End If

               'En este caso se obtendrán las unidades, decenas y centenas en millones de iCantidad.
                Case < 1000000000
                    dCenMill = Math.Truncate(iCantidad / 100000000)
                    dDif = iCantidad - (dCenMill * 100000000)
                    dDecMill = Math.Truncate(dDif / 10000000)
                    dDif -= (dDecMill * 10000000)
                    dMill = Math.Truncate(dDif / 1000000)
                    dDif -= (dMill * 1000000)
                    dCenM = Math.Truncate(dDif / 100000)
                    dDif -= (dCenM * 100000)
                    dDecM = Math.Truncate(dDif / 10000)
                    dDif -= (dDecM * 10000)
                    dMil = Math.Truncate(dDif / 1000)
                    dDif -= (dMil * 1000)
                    dCen = Math.Truncate(dDif / 100)
                    dDif -= (dCen * 100)
                    dDec = Math.Truncate(dDif / 10)
                    dUni = dDif - (dDec * 10)

                    'Se revisan diferentes condiciones para ir concatenando los nombres de las unidades, decenas y centenas (simples y miles).
                    'Ej.: unidades, decenas y/o centenas de miles en 0, (45,000,345.67).
                    'Ej.: unidades, decenas y/o centenas en 0, (250,098,000.56).
                    If dMill = 1 Then
                        sImporteLetra &= nombreCantidad(dCenMill, dDecMill, dMill) & " millón"
                    Else
                        sImporteLetra &= nombreCantidad(dCenMill, dDecMill, dMill) & " millones"
                    End If

                    If dMil = 0 And dDecM = 0 And dCenM = 0 Then
                        If dCen > 0 Or dDec > 0 Or dUni > 0 Then
                            sImporteLetra &= " " & nombreCantidad(dCen, dDec, dUni)
                        End If
                    Else
                        If dCen > 0 Or dDec > 0 Or dUni > 0 Then
                            sImporteLetra &= " " & nombreCantidad(dCenM, dDecM, dMil) & " mil " & nombreCantidad(dCen, dDec, dUni)
                        Else
                            sImporteLetra &= " " & nombreCantidad(dCenM, dDecM, dMil) & " mil"
                        End If
                    End If

                'En este caso se obtendrán las unidades en miles de millones de iCantidad (si se diera el caso), hasta 9,999,999,999.
                Case < 10000000000
                    dMilMill = Math.Truncate(iCantidad / 1000000000)
                    dDif = iCantidad - (dMilMill * 1000000000)
                    dCenMill = Math.Truncate(dDif / 100000000)
                    dDif -= (dCenMill * 100000000)
                    dDecMill = Math.Truncate(dDif / 10000000)
                    dDif -= (dDecMill * 10000000)
                    dMill = Math.Truncate(dDif / 1000000)
                    dDif -= (dMill * 1000000)
                    dCenM = Math.Truncate(dDif / 100000)
                    dDif -= (dCenM * 100000)
                    dDecM = Math.Truncate(dDif / 10000)
                    dDif -= (dDecM * 10000)
                    dMil = Math.Truncate(dDif / 1000)
                    dDif -= (dMil * 1000)
                    dCen = Math.Truncate(dDif / 100)
                    dDif -= (dCen * 100)
                    dDec = Math.Truncate(dDif / 10)
                    dUni = dDif - (dDec * 10)

                    'Se revisan diferentes condiciones para ir concatenando los nombres de las unidades, decenas y centenas (simples, miles y millones).
                    'Ej.: unidades, decenas y/o centenas de miles en 0, (1,045,000,345.67).
                    'Ej.: unidades, decenas y/o centenas de millones en 0, (1,000,098,123.56).
                    'Ej.: unidades, decenas y/o centenas en 0, (2,450,098,000.56).

                    sImporteLetra &= nombreCantidad(0, 0, dMilMill) & " mil"

                    If dMill = 0 And dDecMill = 0 And dCenMill = 0 Then
                        If dMil = 0 And dDecM = 0 And dCenM = 0 Then
                            If dCen > 0 Or dDec > 0 Or dUni > 0 Then
                                sImporteLetra &= " millones " & nombreCantidad(dCen, dDec, dUni)
                            End If
                        Else
                            If dCen > 0 Or dDec > 0 Or dUni > 0 Then
                                sImporteLetra &= " millones " & nombreCantidad(dCenM, dDecM, dMil) & " mil " & nombreCantidad(dCen, dDec, dUni)
                            Else
                                sImporteLetra &= " millones " & nombreCantidad(dCenM, dDecM, dMil) & " mil"
                            End If
                        End If
                    Else
                        If dMill = 1 Then
                            sImporteLetra &= " " & nombreCantidad(dCenMill, dDecMill, dMill) & " millón"
                        Else
                            sImporteLetra &= " " & nombreCantidad(dCenMill, dDecMill, dMill) & " millones"
                        End If

                        If dMil = 0 And dDecM = 0 And dCenM = 0 Then
                            If dCen > 0 Or dDec > 0 Or dUni > 0 Then
                                sImporteLetra &= " " & nombreCantidad(dCen, dDec, dUni)
                            End If
                        Else
                            If dCen > 0 Or dDec > 0 Or dUni > 0 Then
                                sImporteLetra &= " " & nombreCantidad(dCenM, dDecM, dMil) & " mil " & nombreCantidad(dCen, dDec, dUni)
                            Else
                                sImporteLetra &= " " & nombreCantidad(dCenM, dDecM, dMil) & " mil"
                            End If
                        End If
                    End If
            End Select

            '=============== Fracción ===============
            'Si el valor de iCantidad es menor a 2 pesos, concatenar el resto del texto con la palabra 'peso'
            'Si el valor de iCantidad es mayor a 2 pesos, concatenar el resto del texto con la palabra 'pesos'
            If iCantidad = 1 Then
                'Si la variable dDecimal es mayor a 0, se multiplicará su valor por 100; si es menor a 10, se le concatena un 0 al resultado de la multiplicación y se concatena con /100 M.N..
                'si la variable dDecimal es igual a 0, se concatena el resto del texto con '00/100 M.N.'.
                If dDecimal > 0 Then
                    sImporteLetra &= " peso " & IIf(CInt(dDecimal * 100) < 10, "0" & CInt(dDecimal * 100), CInt(dDecimal * 100)) & "/100 M.N."
                Else
                    sImporteLetra &= " peso 00/100 M.N."
                End If
            Else
                If dDecimal > 0 Then
                    sImporteLetra &= " pesos " & IIf(CInt(dDecimal * 100) < 10, "0" & CInt(dDecimal * 100), CInt(dDecimal * 100)) & "/100 M.N."
                Else
                    sImporteLetra &= " pesos 00/100 M.N."
                End If
            End If
            '=============== Fracción ===============
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return sImporteLetra
    End Function

    Private Function letraUnidades(ByVal iDigito As Integer) As String
        Dim sLetras As String = String.Empty

        Try
            Select Case iDigito
                Case 1
                    sLetras = "un"

                Case 2
                    sLetras = "dos"

                Case 3
                    sLetras = "tres"

                Case 4
                    sLetras = "cuatro"

                Case 5
                    sLetras = "cinco"

                Case 6
                    sLetras = "seis"

                Case 7
                    sLetras = "siete"

                Case 8
                    sLetras = "ocho"

                Case 9
                    sLetras = "nueve"

                Case 0
                    sLetras = ""

            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return sLetras
    End Function
    Private Function letraDecenas(ByVal iDigito As Integer, iUni As Integer) As String
        Dim sLetras As String = String.Empty

        Try
            Select Case iDigito
                Case 1
                    If iUni = 0 Then
                        sLetras = "diez"
                    Else
                        Select Case iUni
                            Case 1
                                sLetras = "once"

                            Case 2
                                sLetras = "doce"

                            Case 3
                                sLetras = "trece"

                            Case 4
                                sLetras = "catorce"

                            Case 5
                                sLetras = "quince"

                            Case 6
                                sLetras = "dieciséis"

                            Case 7
                                sLetras = "diecisiete"

                            Case 8
                                sLetras = "dieciocho"

                            Case 9
                                sLetras = "diecinueve"

                            Case 0
                                sLetras = ""

                        End Select
                    End If

                Case 2
                    If iUni = 0 Then
                        sLetras = "veinte"
                    Else
                        Select Case iUni
                            Case 1
                                sLetras = "veintiún"

                            Case 2
                                sLetras = "veintidos"

                            Case 3
                                sLetras = "veintitres"

                            Case 4
                                sLetras = "veinticuatro"

                            Case 5
                                sLetras = "veinticinco"

                            Case 6
                                sLetras = "veintiséis"

                            Case 7
                                sLetras = "veintisiete"

                            Case 8
                                sLetras = "veintiocho"

                            Case 9
                                sLetras = "veintinueve"

                            Case 0
                                sLetras = ""

                        End Select
                    End If

                Case 3
                    If iUni = 0 Then
                        sLetras = "treinta"
                    Else
                        sLetras = "treinta y"
                    End If

                Case 4
                    If iUni = 0 Then
                        sLetras = "cuarenta"
                    Else
                        sLetras = "cuarenta y"
                    End If

                Case 5
                    If iUni = 0 Then
                        sLetras = "cincuenta"
                    Else
                        sLetras = "cincuenta y"
                    End If
                Case 6
                    If iUni = 0 Then
                        sLetras = "sesenta"
                    Else
                        sLetras = "sesenta y"
                    End If
                Case 7
                    If iUni = 0 Then
                        sLetras = "setenta"
                    Else
                        sLetras = "setenta y"
                    End If

                Case 8
                    If iUni = 0 Then
                        sLetras = "ochenta"
                    Else
                        sLetras = "ochenta y"
                    End If
                Case 9
                    If iUni = 0 Then
                        sLetras = "noventa"
                    Else
                        sLetras = "noventa y"
                    End If

                Case 0
                    sLetras = ""

            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return sLetras
    End Function
    Private Function letraCentenas(ByVal iDigito As Integer, iDec As Integer, iUni As Integer) As String
        Dim sLetras As String = String.Empty

        Try
            Select Case iDigito
                Case 1
                    If iDec = 0 And iUni = 0 Then
                        sLetras = "cien"
                    Else
                        sLetras = "ciento"
                    End If

                Case 2
                    sLetras = "doscientos"

                Case 3
                    sLetras = "trescientos"

                Case 4
                    sLetras = "cuatrocientos"

                Case 5
                    sLetras = "quinientos"

                Case 6
                    sLetras = "seiscientos"

                Case 7
                    sLetras = "setecientos"

                Case 8
                    sLetras = "ochocientos"

                Case 9
                    sLetras = "novecientos"

                Case 0
                    sLetras = ""
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return sLetras
    End Function
    Private Function nombreCantidad(ByVal iCen As Integer, ByVal iDec As Integer, ByVal iUni As Integer) As String
        Dim sCantidad As String = String.Empty

        Try
            If iCen = 0 Then
                If iDec = 0 Then
                    sCantidad &= letraUnidades(iUni)
                ElseIf iDec <= 2 Or (iDec > 2 And iUni = 0) Then
                    sCantidad &= letraDecenas(iDec, iUni)
                Else
                    sCantidad &= letraDecenas(iDec, iUni) & " " & letraUnidades(iUni)
                End If
            ElseIf iCen = 1 Then
                If iDec = 0 Then
                    If iUni = 0 Then
                        sCantidad &= letraCentenas(iCen, iDec, iUni)
                    Else
                        sCantidad &= letraCentenas(iCen, iDec, iUni) & " " & letraUnidades(iUni)
                    End If
                ElseIf iDec <= 2 Or (iDec > 2 And iUni = 0) Then
                    sCantidad &= letraCentenas(iCen, iDec, iUni) & " " & letraDecenas(iDec, iUni)
                Else
                    sCantidad &= letraCentenas(iCen, iDec, iUni) & " " & letraDecenas(iDec, iUni) & " " & letraUnidades(iUni)
                End If
            Else
                If iDec = 0 Then
                    If iUni = 0 Then
                        sCantidad &= letraCentenas(iCen, iDec, iUni)
                    Else
                        sCantidad &= letraCentenas(iCen, iDec, iUni) & " " & letraUnidades(iUni)
                    End If
                ElseIf iDec <= 2 Or (iDec > 2 And iUni = 0) Then
                    sCantidad &= letraCentenas(iCen, iDec, iUni) & " " & letraDecenas(iDec, iUni)
                Else
                    sCantidad &= letraCentenas(iCen, iDec, iUni) & " " & letraDecenas(iDec, iUni) & " " & letraUnidades(iUni)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return sCantidad
    End Function

    Public Function fncQuitarAcentos(ByVal strNombre As String) As String
        Const conAcentos = "áàäâÁÀÄÂéèëêÉÈËÊíìïîÍÌÏÎóòöôÓÒÖÔúùüûÚÙÜÛýÿÝ"
        Const sinAcentos = "aaaaAAAAeeeeEEEEiiiiIIIIooooOOOOuuuuUUUUyyY"
        Dim i As Integer
        For i = Len(conAcentos) To 1 Step -1
            strNombre = Replace(strNombre, Mid(conAcentos, i, 1), Mid(sinAcentos, i, 1))
        Next
        fncQuitarAcentos = strNombre
    End Function
    Public Function ListarPermisosUsuariosRD(ByVal sCveUsuario As String, ByVal sTipo As String) As DataTable
        Dim dt As New DataTable

        Try
            Dim sTabla As String = "tbPermisosRD"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveUsr", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
                    .subAddParameter("@sTipo", sTipo, SqlDbType.VarChar, ParameterDirection.Input, 1)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paPermisosRD", sTabla))

                dt = .Item(sTabla)
            End With
        Catch ex As Exception
            'insertarErrorLog(100, "Permisos Usuarios RD", ex.Message, sCveUsuario, "ListarPermisosUsuariosRD()")
            MsgBox("Hubo un inconveniente al consultar la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dt = Nothing
        End Try

        Return dt
    End Function

    Public Function obtenerIdBD(ByVal dFecha As Date) As Integer
        Dim idBD As Integer
        Dim dr() As DataRow

        Try
            dr = dtBasesDatos.Select("'" & dFecha.ToShortDateString & "' >= dFechaInicio AND " & "'" & dFecha.ToShortDateString & "' <= dFechaFinal")

            idBD = dr(0).Item("idBaseDatos").ToString
        Catch ex As Exception
            'insertarErrorLog(202, "Función global", ex.Message, Usuario_Num, "obtenerIdBD()")
        End Try

        Return idBD
    End Function
    Public Function obtenerActivoBD(ByVal id As Integer) As Boolean
        Dim bActivo As Boolean
        Dim dr() As DataRow

        Try
            dr = dtBasesDatos.Select("idBaseDatos = " & id)

            bActivo = CBool(dr(0).Item("bActivo").ToString)
        Catch ex As Exception
            'insertarErrorLog(202, "Función global", ex.Message, Usuario_Num, "obtenerActivoBD()")
        End Try

        Return bActivo
    End Function
    'Función para obtener el número de mes del ciclo operativo de la firma.
    'Ej. Septiembre (mes 9) => Mes 2.
    'Ej. Febrero (mes 2) => Mes 7.
    Public Function obtenerMes(ByVal dFecha As Date) As Integer
        Dim iMes As Integer

        Try
            Select Case Month(dFecha)
                Case 8 To 12
                    iMes = Month(dFecha) - 7

                Case 1 To 7
                    iMes = Month(dFecha) + 5
            End Select

            Return iMes
        Catch ex As Exception
            'insertarErrorLog(202, "Función global", ex.Message, Usuario_Num, "obtenerMes()")
        End Try

        Return iMes
    End Function
    Public Function obtenerNombreBD(ByVal id As Integer, ByVal iOpc As Integer) As String
        Dim sBaseDatos As String = String.Empty
        Dim dr() As DataRow

        Try
            dr = dtBasesDatos.Select("idBaseDatos = " & id)

            If iOpc = 1 Then
                sBaseDatos = dr(0).Item("sNombreBD").ToString
            Else
                sBaseDatos = dr(0).Item("sNombreBDSig").ToString
            End If
        Catch ex As Exception
            'insertarErrorLog(202, "Función global", ex.Message, Usuario_Num, "obtenerNombreBD()")
        End Try

        Return sBaseDatos
    End Function

End Module
