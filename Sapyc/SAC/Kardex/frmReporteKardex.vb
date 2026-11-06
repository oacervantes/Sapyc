Public Class frmReporteKardex
    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Reportes Kardex"
    Private dtKardex As New DataTable

    Private Sub frmReporteKardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridKardex.DataSource = bs
        DesplazamientoGrid(gridKardex)

        ListarKardex()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub
    Private Sub ListarKardex()
        Try
            Dim sTabla As String = "tbKardex"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsDatosInv.funExecuteSPDataTable("paSACKardex", sTabla))

                dtKardex = .Item(sTabla)
            End With

            If dtKardex.Rows.Count > 0 Then
                bs.DataSource = dtKardex
                FormatoGrid()
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarKardex()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtKardex = Nothing
        End Try
    End Sub

    Private Sub FormatoGrid()
        gridKardex.Columns("sCveEmp").Visible = False

        ConfigurarColumnasGrid(gridKardex, "NOMBRE", "NOMBRE SOCIO", 300, 3, False)
        ConfigurarColumnasGrid(gridKardex, "sDictamen", "DICTAMEN FÍSCAL", 300, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sSFP", "REGISTRO ANTE SFP (Entidades de Gobierno)", 100, 3, False)
        ConfigurarColumnasGrid(gridKardex, "sExperienciaPub", "EXPERIENCIA EN EMPRESAS PÚBLICAS EN MÉXICO", 100, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sExperienciaPCAOB", "CUENTA CON EXPERIENCIA EN REGULACIÓN PCAOB", 100, 1, False)
        ConfigurarColumnasGrid(gridKardex, "iAñosExperienciaPCAOB", "AÑOS DE EXPERIENCIA EN TRABAJOS BAJO NORMAS PCAOB", 100, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sTrabajosPCAOBSEC", "TRABAJOS PCAOB/SEC", 100, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sCertificaciones", "CERTIFICACIONES, MAESTRÍAS Y ESPECIALIDADES", 150, 1, False)

        ConfigurarColumnasGrid(gridKardex, "sIdiomas", "IDIOMAS EN LOS QUE PUEDE MANTENER COMUNICACIÓN PROFESIONAL", 100, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sComitesFirma", "COMITÉS DE LA FIRMA", 150, 3, False)
        ConfigurarColumnasGrid(gridKardex, "sComitesColegio", "COMISIONES DEL COLEGIO O DEL IMCP", 150, 3, False)
        ConfigurarColumnasGrid(gridKardex, "sComitesGTI", "COMITÉS O GRUPOS DE TRABAJO DE GTI", 150, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sRolesEstructuraFirma", "ROLES DENTRO DE LA ESTRUCTURA ORGANIZACIONAL DE LA FIRMA", 150, 3, False)
        ConfigurarColumnasGrid(gridKardex, "sMiembroConsejo", "ES MIEMBRO DE UN CONSEJO DE ADMINISTRACIÓN", 150, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sConsejoAdmon", "CONSEJOS DE ADMINISTRACIÓN EN LOS QUE PARTICIPA", 150, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sIMCP", "CERTIFICACIÓN IMCP", 150, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sContribuciones", "CONTRIBUCIONES LOCALES", 150, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sIMSS", "IMSS", 100, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sInfonavit", "INFONAVIT", 100, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sMarcos", "MARCOS NORMATIVOS", 400, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sIndustrias", "INDUSTRIAS", 400, 1, False)
        ConfigurarColumnasGrid(gridKardex, "sServicios", "SERVICIOS", 400, 1, False)


    End Sub


End Class