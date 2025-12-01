Public Class Principal

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim frm As New frmLogin

        Try
            iPeriodoFirma = 11
            clsLocal = New clsAccesoDatos("gtmexvts27\sql2016", "SAPYC2", "Contabilidad", "Control2025%Porfis")
            clsDatos = New clsAccesoDatos("gtmexvts27\sql2016", "BDINV2526", "Contabilidad", "Control2025%Porfis")
            clsDatosInv = New clsAccesoDatos("gtmexvts27\sql2016", "BDINV2526", "Contabilidad", "Control2025%Porfis")
            clsDatosConINV = New clsAccesoDatos("gtmexvts27\sql2016", "CONTROLINV", "Contabilidad", "Control2025%Porfis")
            clsDatosProp = New clsAccesoDatos("gtmexvts27\sql2016", "BDCTRL_PROPS", "Contabilidad", "Control2025%Porfis")
            clsDatosSac = New clsAccesoDatos("gtmexvts27\sql2016", "BDCTRL_SAC", "Contabilidad", "Control2025%Porfis")

            Hide()

            listarBasesDatos()

            If frm.ShowDialog = DialogResult.OK Then
                ''sTipo = "Mercadotecnia"
                ''sTipo = "Independencia 1"
                ''sTipo = "Independencia 2"
                ListarColumnasExcel()

                sNombre = frm.sNombre
                sTipo = frm.sTipo

                OcultarMenu(sTipo)

                Text = "Clientes Prospectos - Bienvenido(a): " & sNombre
                WindowState = FormWindowState.Maximized
                Show()
            Else
                End
            End If
        Catch ex As Exception
            MsgBox("Error al iniciar la aplicación.", MsgBoxStyle.Critical, "Error")
            End
        End Try

        ListarCarpetas()

    End Sub

    Private Sub ListarCarpetas()
        Try
            With ds.Tables
                With clsDatosConINV
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                End With

                If .Contains("paCarpetasSIAT") Then
                    .Remove("paCarpetasSIAT")
                End If

                .Add(clsDatosConINV.funExecuteSPDataTable("paCarpetasSIAT"))

                dtCarpetas = .Item("paCarpetasSIAT")
            End With

            sRutaReportes = dtCarpetas.Rows(0).Item("sCarpetaCR").ToString
            sFolderUserPrincipal = dtCarpetas.Rows(0).Item("sCarpetaUsuarioPrincipal").ToString
            sFolderReportes = dtCarpetas.Rows(0).Item("sCarpetaUsuarioReportes").ToString
            sFolderUserExcel = dtCarpetas.Rows(0).Item("sCarpetaUsuarioExcel").ToString
            sFolderExcel = dtCarpetas.Rows(0).Item("sCarpetaExcel").ToString

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub OcultarMenu(sTipo As String)
        For Each men As ToolStripMenuItem In MenuStrip1.Items
            men.Visible = False
        Next
        ArchivoToolStripMenuItem.Visible = True
        mnuReportes.Visible = True

        Select Case sTipo
            Case "1"
                'MnPropuestas.Visible = True
                mnuProspectos.Visible = True
                mnuReportes.Visible = False
            Case "2"
                MnuInde.Visible = True
                mnuReportes.Visible = False
                MnTablas.Visible = True
            Case "3"
                MnuInde.Visible = True
                mnuReportes.Visible = False
                MnTablas.Visible = True
                'mnuSAC.Visible = True

            Case "4"
                mnuReportes.Visible = True
                mnuProspectos.Visible = True

            Case "5"
                mnuReportes.Visible = True
                MnPropuestas.Visible = False
            Case "6"
                menuFolios.Visible = True
                MnPropuestas.Visible = False
                mnuProspectos.Visible = False
                mnuReportes.Visible = False
        End Select

        MenuStrip1.Visible = True

    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click, BotonSalir.Click

        If MsgBox("¿Estas seguro de salir?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir del Sistema") = MsgBoxResult.Yes Then
            End
        End If
    End Sub
    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("¿Estas seguro de salir?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir del Sistema") = MsgBoxResult.No Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub
    Private Sub TablasDelSistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TablasDelSistemaToolStripMenuItem.Click

    End Sub
    Private Sub BotonAltaPropuesta_Click(sender As Object, e As EventArgs) Handles BotonAltaPropuesta.Click
        If MsgBox("¿Estas seguro de dar de alta una nueva propuesta?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta de Propuesta") = MsgBoxResult.No Then
            Exit Sub
        End If
        MttoPropuesta.LimpiaPan()
        MttoPropuesta.ShowDialog()

    End Sub
    Private Sub GirosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GirosToolStripMenuItem.Click
        'Giros.LimpiaPan()
        Giros.ShowDialog()

    End Sub
    Private Sub ComoSeEnteroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComoSeEnteroToolStripMenuItem.Click
        ComoSeEntero.ShowDialog()

    End Sub
    Private Sub MedioDeContactoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MedioDeContactoToolStripMenuItem.Click
        MedioContacto.ShowDialog()

    End Sub
    Private Sub ActividadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActividadToolStripMenuItem.Click
        Actividades.ShowDialog()
    End Sub
    Private Sub DivisionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DivisionesToolStripMenuItem.Click
        Divisiones.ShowDialog()

    End Sub
    Private Sub TiposDeServicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposDeServicioToolStripMenuItem.Click
        TipoServicio.ShowDialog()

    End Sub
    Private Sub CargarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarToolStripMenuItem.Click
        ClientesRestringidos.ShowDialog()
    End Sub
    Private Sub SolicitudesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SolicitudesToolStripMenuItem1.Click
        Solicitudes.ShowDialog()
    End Sub
    Private Sub PToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PToolStripMenuItem.Click
        frmPropuestas.ShowDialog()

    End Sub
    Private Sub mnuAltaDePropuesta_Click(sender As Object, e As EventArgs) Handles mnuAltaDePropuesta.Click
        MttoPropuesta.LimpiaPan()
        MttoPropuesta.ShowDialog()
    End Sub
    Private Sub CargarListasNegrasSSGTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarListasNegrasSSGTToolStripMenuItem.Click
        ClientesRestringidosSSGT.ShowDialog()

    End Sub
    Private Sub PartesRelacionadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartesRelacionadasToolStripMenuItem.Click
        frmSolRelacionadas.ShowDialog()
    End Sub
    Private Sub EnvioCorreosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvioCorreosToolStripMenuItem.Click
        frmenviocorreos.ShowDialog()
    End Sub
    Private Sub ClientesFacturaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesFacturaciónToolStripMenuItem.Click
        frmSAPYCClientesFiscales.ShowDialog()
    End Sub
    Private Sub ConsultaPropuestasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaPropuestasToolStripMenuItem.Click
        Dim frm As New frmPropuestas

        AbrirPantalla(frm, "frmPropuestas")
    End Sub
    Private Sub ConsultaFoliosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaFoliosToolStripMenuItem.Click
        Dim frm As New frmConsultaFolios

        AbrirPantalla(frm, "frmConsultaFolios")
    End Sub
    Private Sub ClientesConflickToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesConflickToolStripMenuItem.Click
        Dim frm As New frmClientesConflick

        AbrirPantalla(frm, "frmClientesConflick")
    End Sub
    Private Sub ClientesRelacionadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesRelacionadosToolStripMenuItem.Click
        Dim frm As New frmRelacionCtes

        If Not Application.OpenForms("frmRelacionCtes") Is Nothing Then
            Application.OpenForms("frmRelacionCtes").Activate()
        Else
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub
    Private Sub TodasLasSolicitudesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TodasLasSolicitudesToolStripMenuItem.Click
        Dim frm As New frmTodasSolicitudes

        If Not Application.OpenForms("frmTodasSolicitudes") Is Nothing Then
            Application.OpenForms("frmTodasSolicitudes").Activate()
        Else
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub
    Private Sub ClientesPorClaveDeTrabajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesPorClaveDeTrabajoToolStripMenuItem.Click
        Dim frm As New frmReportePorClaves

        AbrirPantalla(frm, "frmReportePorClaves")
    End Sub
    Private Sub AbrirPantalla(frm As Form, sNombre As String)
        If Not Application.OpenForms(sNombre) Is Nothing Then
            Application.OpenForms(sNombre).Activate()
        Else
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub
    Private Sub itmReporteDireccion_Click(sender As Object, e As EventArgs) Handles itmReporteDireccion.Click
        Dim frm As New FrmSAPYCReporteDireccion

        AbrirPantalla(frm, "FrmSAPYCReporteDireccion")
    End Sub
    Private Sub itmClientesReferenciados_Click(sender As Object, e As EventArgs) Handles itmClientesReferenciados.Click
        Dim frm As New frmClientesReferenciados

        AbrirPantalla(frm, "frmClientesReferenciados")
    End Sub
    Private Sub RegistrarProspectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarProspectoToolStripMenuItem.Click
        Dim frm As New FrmProspectos

        AbrirPantalla(frm, "FrmProspectos")
    End Sub
    Private Sub ClientesDelPeriodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesDelPeriodoToolStripMenuItem.Click
        Dim frm As New frmCtesDelPeriodo

        AbrirPantalla(frm, "frmCtesDelPeriodo")
    End Sub
    Private Sub ClientesRechazadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesRechazadosToolStripMenuItem.Click
        Dim frm As New frmClientesRechazados

        AbrirPantalla(frm, "frmClientesRechazados")
    End Sub
    Private Sub AutorizaFoliosDeInformeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorizaFoliosDeInformeToolStripMenuItem.Click
        Dim frm As New frmAutorizaSolicitudFolios

        AbrirPantalla(frm, "frmAutorizaSolicitudFolios")
    End Sub
    Private Sub ConsultaDeFoliosDeInformeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeFoliosDeInformeToolStripMenuItem.Click
        Dim frm As New frmConsultaFolios

        AbrirPantalla(frm, "frmConsultaFolios")
    End Sub
    Private Sub ClientesSacToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesSacToolStripMenuItem.Click
        Dim frm As New frmListaNumSac

        AbrirPantalla(frm, "frmListaNumSac")
    End Sub
    Private Sub GestiónServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles itmTipoServicios.Click
        Dim frm As New FrmTipoServicios

        If Not Application.OpenForms("FrmTipoServicios") Is Nothing Then
            Application.OpenForms("FrmTipoServicios").Activate()
        Else
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub
    Private Sub itmReportesGRD_Click(sender As Object, e As EventArgs) Handles itmReportesGRD.Click
        Dim frm As New FrmReportesGRD

        AbrirPantalla(frm, "FrmReportesGRD")
    End Sub

    Private Sub ItmKardex_Click(sender As Object, e As EventArgs) Handles itmKardex.Click
        Dim frm As New FrmKardex

        AbrirPantalla(frm, "FrmKardex")
    End Sub
End Class