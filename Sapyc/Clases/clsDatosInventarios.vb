Public Class clsDatosInventarios

    Private ds As New DataSet

    Public Function ListarGerentes(sNameRpt As String, sCveOfi As String, sCveArea As String) As DataTable
        Dim dt As New DataTable

        Try
            Dim sTabla As String = "tabGerentes"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveArea", sCveArea, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paEncargados", sTabla))

                dt = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(300, sNameRpt, ex.Message, sCveUsuario, "ListarGerentes()")
            MsgBox("Hubo un inconveniente al mostrar las claves de trabajo, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dt = Nothing

            Return dt
        End Try

        Return dt
    End Function

    Public Function ListarTrabajosSocio(sNameRpt As String, sCveUsuario As String, sTipoUsuario As String) As DataTable
        Dim dt As New DataTable

        Try
            Dim sTabla As String = "tabCvesSoc"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveEmp", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
                    .subAddParameter("@sTipoEmp", sTipoUsuario, SqlDbType.VarChar, ParameterDirection.Input, 1)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paClavesTrabajoSocio", sTabla))

                dt = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(300, sNameRpt, ex.Message, sCveUsuario, "listarTrabajosSocio()")
            MsgBox("Hubo un inconveniente al mostrar las claves de trabajo, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dt = Nothing

            Return dt
        End Try

        Return dt
    End Function
    Public Function ListarTrabajosGrupo(sNameRpt As String, sCveUsuario As String) As DataTable
        Dim dt As New DataTable

        Try
            Dim sTabla As String = "tabCvesSoc"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 19, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveEmp", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paClavesTrabajoSocio", sTabla))

                dt = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(300, sNameRpt, ex.Message, sCveUsuario, "listarTrabajosSocio()")
            MsgBox("Hubo un inconveniente al mostrar las claves de trabajo, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "SIAT")
            dt = Nothing

            Return dt
        End Try

        Return dt
    End Function
    Public Function ListarDatosCveTrabajo(sNameRpt As String, sCveTra As String, sCveOfi As String, sCveArea As String) As DataTable
        Dim dt As New DataTable

        Try
            Dim sTabla As String = "tabDatosCveTra"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input, 20)
                    .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input, 10)
                    .subAddParameter("@sCveArea", sCveArea, SqlDbType.VarChar, ParameterDirection.Input, 10)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paClavesTrabajoSocio", sTabla))

                dt = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDatosCveTrabajo()")
            MsgBox("Hubo un inconveniente al consultar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")
            dt = Nothing

            Return dt
        End Try

        Return dt
    End Function
    Public Function ListarMarcosRegulatoriosTrabajo(sNameRpt As String, sCveTra As String) As DataTable
        Dim dt As New DataTable

        Try
            Dim sTabla As String = "tbMarcosTra"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatos
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 17, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatos.funExecuteSPDataTable("paClavesTrabajoSocio", sTabla))

                dt = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarMarcosRegulatoriosTrabajo()")
            MsgBox("Hubo un inconveniente al consultar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")
            dt = Nothing

            Return dt
        End Try

        Return dt
    End Function

    Public Function EditarDatosCveTrabajo(sNameRpt As String, sInfoPpto As Char, sCveTra As String, sDescripcion As String, sCveGer As String, dPptoBruto As Double, dPorWO As Double, dImpWO As Double, dMeses() As Double, dPptoBrutoSig As Double, dPorWOSig As Double, dImpWOSig As Double, dMesesS() As Double, iHoras As Integer, iHorasSig As Integer, Optional iAñoRev As Integer = 0, Optional iDescTra As Integer = 0, Optional bBienal As Boolean = False) As Integer
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input, 20)
                .subAddParameter("@sDescripcion", sDescripcion, SqlDbType.VarChar, ParameterDirection.Input, 2000)
                .subAddParameter("@sCveGer", sCveGer, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sInfoPpto", sInfoPpto, SqlDbType.Char, ParameterDirection.Input, 1)

                .subAddParameter("@bBienal", bBienal, SqlDbType.Bit, ParameterDirection.Input)

                .subAddParameter("@iHoras", iHoras, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@dPptoBruto", dPptoBruto, SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dPorWO", dPorWO, SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpWO", dImpWO, SqlDbType.Float, ParameterDirection.Input)

                .subAddParameter("@iHorasSig", iHorasSig, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@dPptoBrutoSig", dPptoBrutoSig, SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dPorWOSig", dPorWOSig, SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpWOSig", dImpWOSig, SqlDbType.Float, ParameterDirection.Input)

                .subAddParameter("@dMes01", dMeses(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes02", dMeses(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes03", dMeses(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes04", dMeses(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes05", dMeses(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes06", dMeses(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes07", dMeses(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes08", dMeses(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes09", dMeses(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes10", dMeses(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes11", dMeses(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes12", dMeses(11), SqlDbType.Float, ParameterDirection.Input)

                .subAddParameter("@dMesS01", dMesesS(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMesS02", dMesesS(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMesS03", dMesesS(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMesS04", dMesesS(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMesS05", dMesesS(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMesS06", dMesesS(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMesS07", dMesesS(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMesS08", dMesesS(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMesS09", dMesesS(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMesS10", dMesesS(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMesS11", dMesesS(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMesS12", dMesesS(11), SqlDbType.Float, ParameterDirection.Input)

                .subAddParameter("@iAñoRev", iAñoRev, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iDescTra", iDescTra, SqlDbType.Int, ParameterDirection.Input)
            End With

            iReg = clsDatos.funExecuteSP("paClavesTrabajoSocio")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDatosCveTrabajo()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function
    Public Function EditarImportePropuesta(sNameRpt As String, sInfoPpto As Char, sCveTra As String, sDescripcion As String, sCveGer As String, dPptoBruto As Double, dPorWO As Double, dImpWO As Double, dMeses() As Double) As Integer
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sDescripcion", sDescripcion, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveGer", sCveGer, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sInfoPpto", sInfoPpto, SqlDbType.Char, ParameterDirection.Input)

                .subAddParameter("@dPptoBruto", dPptoBruto, SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dPorWO", dPorWO, SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpWO", dImpWO, SqlDbType.Float, ParameterDirection.Input)

                .subAddParameter("@dMes01", dMeses(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes02", dMeses(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes03", dMeses(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes04", dMeses(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes05", dMeses(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes06", dMeses(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes07", dMeses(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes08", dMeses(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes09", dMeses(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes10", dMeses(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes11", dMeses(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dMes12", dMeses(11), SqlDbType.Float, ParameterDirection.Input)
            End With

            iReg = clsDatos.funExecuteSP("paClavesTrabajoSocio")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarDatosCveTrabajo()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function
    Public Function InsertarMarcoRegulatorio(sNameRpt As String, sCveTra As String, idMarco As Integer, sMarcoOtro As String) As Integer
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 16, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idMarco", idMarco, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sMarcoOtro", sMarcoOtro, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
            End With

            iReg = clsDatos.funExecuteSP("paClavesTrabajoSocio")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarMarcoRegulatorio()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function
    Public Function EliminarMarcoRegulatorio(sNameRpt As String, sCveTra As String, idMarco As Integer) As Integer
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 20, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@idMarco", idMarco, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
            End With

            iReg = clsDatos.funExecuteSP("paClavesTrabajoSocio")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EliminarMarcoRegulatorio()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function

    Public Function EditarFacturacionTerceros(sNameRpt As String, sCveTra As String, dImportesAct() As Double, dImportesSig() As Double)
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input, 20)
                .subAddParameter("@dImpAct01", dImportesAct(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct02", dImportesAct(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct03", dImportesAct(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct04", dImportesAct(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct05", dImportesAct(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct06", dImportesAct(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct07", dImportesAct(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct08", dImportesAct(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct09", dImportesAct(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct10", dImportesAct(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct11", dImportesAct(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct12", dImportesAct(11), SqlDbType.Float, ParameterDirection.Input)

                .subAddParameter("@dImpSig01", dImportesSig(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig02", dImportesSig(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig03", dImportesSig(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig04", dImportesSig(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig05", dImportesSig(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig06", dImportesSig(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig07", dImportesSig(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig08", dImportesSig(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig09", dImportesSig(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig10", dImportesSig(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig11", dImportesSig(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig12", dImportesSig(11), SqlDbType.Float, ParameterDirection.Input)

                .subAddParameter("@dUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
            End With

            iReg = clsDatos.funExecuteSP("paFacturacionTerceros")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EditarFacturacionTerceros()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function

    Public Function InsertarFacturacionInterna(sNameRpt As String, sCveSocio As String, sCveTraDe As String, sCveTraA As String, sCveOfiDe As String, sCveOfiA As String, sCveAreaDe As String, sCveAreaA As String, dImportesAct() As Double, dImportesSig() As Double)
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@bStatus", 1, SqlDbType.Bit, ParameterDirection.Input)
                .subAddParameter("@sCveSocio", sCveSocio, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sCveTraOri", sCveTraDe, SqlDbType.VarChar, ParameterDirection.Input, 20)
                .subAddParameter("@sCveOfi", sCveOfiDe, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sCveArea", sCveAreaDe, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sCveTra", sCveTraA, SqlDbType.VarChar, ParameterDirection.Input, 20)
                .subAddParameter("@sCveOfiTra", sCveOfiA, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sCveAreaTra", sCveAreaA, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@dImpAct01", dImportesAct(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct02", dImportesAct(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct03", dImportesAct(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct04", dImportesAct(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct05", dImportesAct(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct06", dImportesAct(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct07", dImportesAct(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct08", dImportesAct(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct09", dImportesAct(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct10", dImportesAct(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct11", dImportesAct(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct12", dImportesAct(11), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig01", dImportesSig(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig02", dImportesSig(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig03", dImportesSig(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig04", dImportesSig(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig05", dImportesSig(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig06", dImportesSig(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig07", dImportesSig(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig08", dImportesSig(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig09", dImportesSig(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig10", dImportesSig(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig11", dImportesSig(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig12", dImportesSig(11), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
            End With

            iReg = clsDatos.funExecuteSP("paFacturacionInternaClave")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EditarFacturacionInterna()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function
    Public Function EditarFacturacionInterna(sNameRpt As String, idFactura As Integer, dImportesAct() As Double, dImportesSig() As Double)
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idFacturaInt", idFactura, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@dImpAct01", dImportesAct(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct02", dImportesAct(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct03", dImportesAct(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct04", dImportesAct(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct05", dImportesAct(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct06", dImportesAct(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct07", dImportesAct(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct08", dImportesAct(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct09", dImportesAct(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct10", dImportesAct(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct11", dImportesAct(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct12", dImportesAct(11), SqlDbType.Float, ParameterDirection.Input)

                .subAddParameter("@dImpSig01", dImportesSig(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig02", dImportesSig(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig03", dImportesSig(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig04", dImportesSig(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig05", dImportesSig(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig06", dImportesSig(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig07", dImportesSig(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig08", dImportesSig(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig09", dImportesSig(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig10", dImportesSig(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig11", dImportesSig(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig12", dImportesSig(11), SqlDbType.Float, ParameterDirection.Input)

                .subAddParameter("@dUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
            End With

            iReg = clsDatos.funExecuteSP("paFacturacionInternaClave")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EditarFacturacionInterna()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function
    Public Function EliminarFacturacionInterna(sNameRpt As String, idFactura As Integer)
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idFacturaInt", idFactura, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@bStatus", 0, SqlDbType.Bit, ParameterDirection.Input)
            End With

            iReg = clsDatos.funExecuteSP("paFacturacionInternaClave")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EliminarFacturacionInterna()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function

    Public Function InsertarTraspasos(sNameRpt As String, sCveSocio As String, sCveTraDe As String, sCveTraA As String, sCveOfiDe As String, sCveOfiA As String, sCveAreaDe As String, sCveAreaA As String, dImportesAct() As Double, dImportesSig() As Double)
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPeriodo", iPeriodoFirma, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@bStatus", 1, SqlDbType.Bit, ParameterDirection.Input)
                .subAddParameter("@sCveSocio", sCveSocio, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sCveTraOri", sCveTraDe, SqlDbType.VarChar, ParameterDirection.Input, 20)
                .subAddParameter("@sCveOfi", sCveOfiDe, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sCveArea", sCveAreaDe, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sCveTra", sCveTraA, SqlDbType.VarChar, ParameterDirection.Input, 20)
                .subAddParameter("@sCveOfiTra", sCveOfiA, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@sCveAreaTra", sCveAreaA, SqlDbType.VarChar, ParameterDirection.Input, 10)
                .subAddParameter("@dImpAct01", dImportesAct(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct02", dImportesAct(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct03", dImportesAct(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct04", dImportesAct(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct05", dImportesAct(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct06", dImportesAct(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct07", dImportesAct(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct08", dImportesAct(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct09", dImportesAct(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct10", dImportesAct(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct11", dImportesAct(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct12", dImportesAct(11), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig01", dImportesSig(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig02", dImportesSig(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig03", dImportesSig(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig04", dImportesSig(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig05", dImportesSig(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig06", dImportesSig(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig07", dImportesSig(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig08", dImportesSig(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig09", dImportesSig(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig10", dImportesSig(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig11", dImportesSig(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig12", dImportesSig(11), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
            End With

            iReg = clsDatos.funExecuteSP("paTraspasosClave")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "InsertarTraspasos()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function
    Public Function EditarTraspasos(sNameRpt As String, idFactura As Integer, dImportesAct() As Double, dImportesSig() As Double)
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idTraspaso", idFactura, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@dImpAct01", dImportesAct(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct02", dImportesAct(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct03", dImportesAct(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct04", dImportesAct(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct05", dImportesAct(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct06", dImportesAct(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct07", dImportesAct(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct08", dImportesAct(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct09", dImportesAct(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct10", dImportesAct(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct11", dImportesAct(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpAct12", dImportesAct(11), SqlDbType.Float, ParameterDirection.Input)

                .subAddParameter("@dImpSig01", dImportesSig(0), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig02", dImportesSig(1), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig03", dImportesSig(2), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig04", dImportesSig(3), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig05", dImportesSig(4), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig06", dImportesSig(5), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig07", dImportesSig(6), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig08", dImportesSig(7), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig09", dImportesSig(8), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig10", dImportesSig(9), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig11", dImportesSig(10), SqlDbType.Float, ParameterDirection.Input)
                .subAddParameter("@dImpSig12", dImportesSig(11), SqlDbType.Float, ParameterDirection.Input)

                .subAddParameter("@dUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input, 10)
            End With

            iReg = clsDatos.funExecuteSP("paTraspasosClave")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EditarTraspasos()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function
    Public Function EliminarTraspasos(sNameRpt As String, idFactura As Integer)
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 6, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@idTraspaso", idFactura, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@bStatus", 0, SqlDbType.Bit, ParameterDirection.Input)
            End With

            iReg = clsDatos.funExecuteSP("paTraspasosClave")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EliminarTraspasos()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function

    Public Function EliminarTrabajoCuadroAsignaciones(sNameRpt As String, sCveTra As String)
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 18, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@cStatus", "B", SqlDbType.VarChar, ParameterDirection.Input)
            End With

            iReg = clsDatos.funExecuteSP("paClavesTrabajoSocio")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EliminarTrabajoCuadroAsignaciones()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function

    Public Function EditarMotivoBajaTrabajo(sNameRpt As String, sCveTra As String, sMotivo As String, sTipo As String, idPropuesta As Integer)
        Dim iReg As Integer = 0

        Try
            With clsDatos
                .subClearParameters()
                .subAddParameter("@iOpcion", 4, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@iPropuesta", idPropuesta, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveUsuario", sCveUsuario, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sCveTra", sCveTra, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sMotivoCierre", sMotivo, SqlDbType.VarChar, ParameterDirection.Input)
                .subAddParameter("@sTipoCierre", sTipo, SqlDbType.Char, ParameterDirection.Input)
            End With

            iReg = clsDatos.funExecuteSP("paClavesTrabajoSocio")
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "EditarMotivoBajaTrabajo()")
            MsgBox("Hubo un inconveniente al guardar la información de base de datos, intente de nuevo más tarde por favor.", MsgBoxStyle.Exclamation, "SIAT")

            Return -1
        End Try

        Return iReg
    End Function

End Class