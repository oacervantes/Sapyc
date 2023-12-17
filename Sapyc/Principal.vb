Public Class Principal


    Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim frm As New frmLogin

        Try

            clsLocal = New clsAccesoDatos("gtmexvts27\sql2016", "SAPYC2", "Contabilidad", "Control2025%Porfis")
            clsDatosInv = New clsAccesoDatos("gtmexvts27\sql2016", "BDINV2324", "Contabilidad", "Control2025%Porfis")
            clsDatosConINV = New clsAccesoDatos("gtmexvts27\sql2016", "CONTROLINV", "Contabilidad", "Control2025%Porfis")

            Me.Hide()

            If frm.ShowDialog = DialogResult.OK Then
                ''sTipo = "Mercadotecnia"
                ''sTipo = "Independencia 1"
                ''sTipo = "Independencia 2"
                sNombre = frm.sNombre
                sTipo = frm.sTipo

                ocultarMenu(sTipo)

                Me.Text = "Clientes Prospectos - Bienvenido(a): " & sNombre
                Me.WindowState = FormWindowState.Maximized
                Me.Show()
            Else
                End
            End If
        Catch ex As Exception
            MsgBox("Error al iniciar la aplicación.", MsgBoxStyle.Critical, "Error")
            End
        End Try

        listarCarpetas()

    End Sub

    Private Sub listarCarpetas()
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
    Private Sub ocultarMenu(sTipo As String)
        For Each men As ToolStripMenuItem In MenuStrip1.Items
            men.Visible = False
        Next
        ArchivoToolStripMenuItem.Visible = True

        Select Case sTipo
            Case "1"
                MnPropuestas.Visible = True
            Case "2"
                MnuInde.Visible = True
            Case "3"
                MnuInde.Visible = True
        End Select

        MenuStrip1.Visible = True

    End Sub
    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalir.Click, BotonSalir.Click

        If MsgBox("¿Estas seguro de salir?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir del Sistema") = MsgBoxResult.Yes Then
            End
        End If
    End Sub

    Private Sub Principal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("¿Estas seguro de salir?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir del Sistema") = MsgBoxResult.No Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub TablasDelSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TablasDelSistemaToolStripMenuItem.Click

    End Sub

    Private Sub BotonAltaPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonAltaPropuesta.Click
        If MsgBox("¿Estas seguro de dar de alta una nueva propuesta?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta de Propuesta") = MsgBoxResult.No Then
            Exit Sub
        End If
        MttoPropuesta.LimpiaPan()
        MttoPropuesta.ShowDialog()

    End Sub

    Private Sub GirosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GirosToolStripMenuItem.Click
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
        frmPropuestas.ShowDialog()
    End Sub

    Private Sub ConsultaFoliosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaFoliosToolStripMenuItem.Click
        frmConsultaFolios.ShowDialog()
    End Sub

    Private Sub ClientesConflickToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesConflickToolStripMenuItem.Click
        frmClientesConflick.ShowDialog()
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

End Class