<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnTablas = New System.Windows.Forms.ToolStripMenuItem()
        Me.TablasDelSistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GirosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActividadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DivisionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TiposDeServicioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComoSeEnteroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedioDeContactoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProspectos = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarProspectoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnPropuestas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAltaDePropuesta = New System.Windows.Forms.ToolStripMenuItem()
        Me.PToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManejoDeClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtileriasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatosDeConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuInde = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargarListasNegrasSSGTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SolicitudesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartesRelacionadasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesFacturaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesConflickToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnvioCorreosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaPropuestasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaFoliosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesRelacionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodasLasSolicitudesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesPorClaveDeTrabajoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.itmReporteDireccion = New System.Windows.Forms.ToolStripMenuItem()
        Me.itmClientesReferenciados = New System.Windows.Forms.ToolStripMenuItem()
        Me.Barra = New System.Windows.Forms.ToolStrip()
        Me.BotonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BotonTablas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BotonAltaPropuesta = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClientesDelPeriodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.Barra.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.MnTablas, Me.mnuProspectos, Me.MnPropuestas, Me.ClientesToolStripMenuItem, Me.UtileriasToolStripMenuItem, Me.MnuInde, Me.mnuReportes})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1026, 24)
        Me.MenuStrip1.TabIndex = 1
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSalir})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'mnuSalir
        '
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Size = New System.Drawing.Size(98, 22)
        Me.mnuSalir.Text = "&Salir"
        '
        'MnTablas
        '
        Me.MnTablas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TablasDelSistemaToolStripMenuItem})
        Me.MnTablas.Name = "MnTablas"
        Me.MnTablas.Size = New System.Drawing.Size(52, 20)
        Me.MnTablas.Text = "&Tablas"
        Me.MnTablas.Visible = False
        '
        'TablasDelSistemaToolStripMenuItem
        '
        Me.TablasDelSistemaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GirosToolStripMenuItem, Me.ActividadToolStripMenuItem, Me.DivisionesToolStripMenuItem, Me.TiposDeServicioToolStripMenuItem, Me.ComoSeEnteroToolStripMenuItem, Me.MedioDeContactoToolStripMenuItem})
        Me.TablasDelSistemaToolStripMenuItem.Name = "TablasDelSistemaToolStripMenuItem"
        Me.TablasDelSistemaToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.TablasDelSistemaToolStripMenuItem.Text = "Tablas del Sistema"
        '
        'GirosToolStripMenuItem
        '
        Me.GirosToolStripMenuItem.Name = "GirosToolStripMenuItem"
        Me.GirosToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.GirosToolStripMenuItem.Text = "Giros"
        '
        'ActividadToolStripMenuItem
        '
        Me.ActividadToolStripMenuItem.Name = "ActividadToolStripMenuItem"
        Me.ActividadToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ActividadToolStripMenuItem.Text = "Actividades"
        '
        'DivisionesToolStripMenuItem
        '
        Me.DivisionesToolStripMenuItem.Name = "DivisionesToolStripMenuItem"
        Me.DivisionesToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.DivisionesToolStripMenuItem.Text = "Divisiones"
        '
        'TiposDeServicioToolStripMenuItem
        '
        Me.TiposDeServicioToolStripMenuItem.Name = "TiposDeServicioToolStripMenuItem"
        Me.TiposDeServicioToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.TiposDeServicioToolStripMenuItem.Text = "Tipos de servicio"
        '
        'ComoSeEnteroToolStripMenuItem
        '
        Me.ComoSeEnteroToolStripMenuItem.Name = "ComoSeEnteroToolStripMenuItem"
        Me.ComoSeEnteroToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ComoSeEnteroToolStripMenuItem.Text = "Como se entero"
        '
        'MedioDeContactoToolStripMenuItem
        '
        Me.MedioDeContactoToolStripMenuItem.Name = "MedioDeContactoToolStripMenuItem"
        Me.MedioDeContactoToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.MedioDeContactoToolStripMenuItem.Text = "Medio de contacto"
        '
        'mnuProspectos
        '
        Me.mnuProspectos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarProspectoToolStripMenuItem})
        Me.mnuProspectos.Name = "mnuProspectos"
        Me.mnuProspectos.Size = New System.Drawing.Size(80, 20)
        Me.mnuProspectos.Text = "Prospectos"
        Me.mnuProspectos.Visible = False
        '
        'RegistrarProspectoToolStripMenuItem
        '
        Me.RegistrarProspectoToolStripMenuItem.Name = "RegistrarProspectoToolStripMenuItem"
        Me.RegistrarProspectoToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.RegistrarProspectoToolStripMenuItem.Text = "Registrar prospecto"
        '
        'MnPropuestas
        '
        Me.MnPropuestas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAltaDePropuesta, Me.PToolStripMenuItem})
        Me.MnPropuestas.Name = "MnPropuestas"
        Me.MnPropuestas.Size = New System.Drawing.Size(80, 20)
        Me.MnPropuestas.Text = "&Propuestas"
        Me.MnPropuestas.Visible = False
        '
        'mnuAltaDePropuesta
        '
        Me.mnuAltaDePropuesta.Name = "mnuAltaDePropuesta"
        Me.mnuAltaDePropuesta.Size = New System.Drawing.Size(172, 22)
        Me.mnuAltaDePropuesta.Text = "Alta de Propuesta"
        '
        'PToolStripMenuItem
        '
        Me.PToolStripMenuItem.Name = "PToolStripMenuItem"
        Me.PToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.PToolStripMenuItem.Text = "Propuestas"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManejoDeClientesToolStripMenuItem})
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.ClientesToolStripMenuItem.Text = "&Clientes"
        Me.ClientesToolStripMenuItem.Visible = False
        '
        'ManejoDeClientesToolStripMenuItem
        '
        Me.ManejoDeClientesToolStripMenuItem.Name = "ManejoDeClientesToolStripMenuItem"
        Me.ManejoDeClientesToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ManejoDeClientesToolStripMenuItem.Text = "Manejo de Clientes"
        '
        'UtileriasToolStripMenuItem
        '
        Me.UtileriasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatosDeConfiguraciónToolStripMenuItem})
        Me.UtileriasToolStripMenuItem.Name = "UtileriasToolStripMenuItem"
        Me.UtileriasToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.UtileriasToolStripMenuItem.Text = "&Utilerias"
        Me.UtileriasToolStripMenuItem.Visible = False
        '
        'DatosDeConfiguraciónToolStripMenuItem
        '
        Me.DatosDeConfiguraciónToolStripMenuItem.Name = "DatosDeConfiguraciónToolStripMenuItem"
        Me.DatosDeConfiguraciónToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.DatosDeConfiguraciónToolStripMenuItem.Text = "Datos de Configuración"
        '
        'MnuInde
        '
        Me.MnuInde.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CargarListasNegrasSSGTToolStripMenuItem, Me.CargarToolStripMenuItem, Me.SolicitudesToolStripMenuItem1, Me.PartesRelacionadasToolStripMenuItem, Me.ClientesFacturaciónToolStripMenuItem, Me.ClientesConflickToolStripMenuItem, Me.EnvioCorreosToolStripMenuItem, Me.ConsultaPropuestasToolStripMenuItem, Me.ConsultaFoliosToolStripMenuItem, Me.ClientesRelacionadosToolStripMenuItem, Me.TodasLasSolicitudesToolStripMenuItem, Me.ClientesPorClaveDeTrabajoToolStripMenuItem, Me.ClientesDelPeriodoToolStripMenuItem})
        Me.MnuInde.Name = "MnuInde"
        Me.MnuInde.Size = New System.Drawing.Size(101, 20)
        Me.MnuInde.Text = "Independencia"
        Me.MnuInde.Visible = False
        '
        'CargarListasNegrasSSGTToolStripMenuItem
        '
        Me.CargarListasNegrasSSGTToolStripMenuItem.Name = "CargarListasNegrasSSGTToolStripMenuItem"
        Me.CargarListasNegrasSSGTToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.CargarListasNegrasSSGTToolStripMenuItem.Text = "Cargar Listas Negras SSGT"
        '
        'CargarToolStripMenuItem
        '
        Me.CargarToolStripMenuItem.Name = "CargarToolStripMenuItem"
        Me.CargarToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.CargarToolStripMenuItem.Text = "Cargar Listas Negras SAT"
        '
        'SolicitudesToolStripMenuItem1
        '
        Me.SolicitudesToolStripMenuItem1.Name = "SolicitudesToolStripMenuItem1"
        Me.SolicitudesToolStripMenuItem1.Size = New System.Drawing.Size(247, 22)
        Me.SolicitudesToolStripMenuItem1.Text = "Clientes Nuevos"
        '
        'PartesRelacionadasToolStripMenuItem
        '
        Me.PartesRelacionadasToolStripMenuItem.Name = "PartesRelacionadasToolStripMenuItem"
        Me.PartesRelacionadasToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.PartesRelacionadasToolStripMenuItem.Text = "Clientes Recurrentes"
        '
        'ClientesFacturaciónToolStripMenuItem
        '
        Me.ClientesFacturaciónToolStripMenuItem.Name = "ClientesFacturaciónToolStripMenuItem"
        Me.ClientesFacturaciónToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.ClientesFacturaciónToolStripMenuItem.Text = "Clientes Facturación"
        '
        'ClientesConflickToolStripMenuItem
        '
        Me.ClientesConflickToolStripMenuItem.Name = "ClientesConflickToolStripMenuItem"
        Me.ClientesConflickToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.ClientesConflickToolStripMenuItem.Text = "Actualización de Conflict Check"
        '
        'EnvioCorreosToolStripMenuItem
        '
        Me.EnvioCorreosToolStripMenuItem.Name = "EnvioCorreosToolStripMenuItem"
        Me.EnvioCorreosToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.EnvioCorreosToolStripMenuItem.Text = "EnvioCorreos"
        Me.EnvioCorreosToolStripMenuItem.Visible = False
        '
        'ConsultaPropuestasToolStripMenuItem
        '
        Me.ConsultaPropuestasToolStripMenuItem.Name = "ConsultaPropuestasToolStripMenuItem"
        Me.ConsultaPropuestasToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.ConsultaPropuestasToolStripMenuItem.Text = "Consulta de Propuestas"
        '
        'ConsultaFoliosToolStripMenuItem
        '
        Me.ConsultaFoliosToolStripMenuItem.Name = "ConsultaFoliosToolStripMenuItem"
        Me.ConsultaFoliosToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.ConsultaFoliosToolStripMenuItem.Text = "Consulta de Folios de Informe"
        '
        'ClientesRelacionadosToolStripMenuItem
        '
        Me.ClientesRelacionadosToolStripMenuItem.Name = "ClientesRelacionadosToolStripMenuItem"
        Me.ClientesRelacionadosToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.ClientesRelacionadosToolStripMenuItem.Text = "Clientes Relacionados"
        '
        'TodasLasSolicitudesToolStripMenuItem
        '
        Me.TodasLasSolicitudesToolStripMenuItem.Name = "TodasLasSolicitudesToolStripMenuItem"
        Me.TodasLasSolicitudesToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.TodasLasSolicitudesToolStripMenuItem.Text = "Todas las solicitudes"
        '
        'ClientesPorClaveDeTrabajoToolStripMenuItem
        '
        Me.ClientesPorClaveDeTrabajoToolStripMenuItem.Name = "ClientesPorClaveDeTrabajoToolStripMenuItem"
        Me.ClientesPorClaveDeTrabajoToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.ClientesPorClaveDeTrabajoToolStripMenuItem.Text = "Clientes por Clave de Trabajo"
        '
        'mnuReportes
        '
        Me.mnuReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itmReporteDireccion, Me.itmClientesReferenciados})
        Me.mnuReportes.Name = "mnuReportes"
        Me.mnuReportes.Size = New System.Drawing.Size(70, 20)
        Me.mnuReportes.Text = "Reportes"
        Me.mnuReportes.Visible = False
        '
        'itmReporteDireccion
        '
        Me.itmReporteDireccion.Name = "itmReporteDireccion"
        Me.itmReporteDireccion.Size = New System.Drawing.Size(205, 22)
        Me.itmReporteDireccion.Text = "Reporte de la Dirección"
        '
        'itmClientesReferenciados
        '
        Me.itmClientesReferenciados.Name = "itmClientesReferenciados"
        Me.itmClientesReferenciados.Size = New System.Drawing.Size(205, 22)
        Me.itmClientesReferenciados.Text = "Clientes Referenciados"
        '
        'Barra
        '
        Me.Barra.AutoSize = False
        Me.Barra.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.Barra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BotonSalir, Me.ToolStripSeparator1, Me.BotonTablas, Me.ToolStripSeparator2, Me.BotonAltaPropuesta, Me.ToolStripSeparator3})
        Me.Barra.Location = New System.Drawing.Point(0, 24)
        Me.Barra.Name = "Barra"
        Me.Barra.Size = New System.Drawing.Size(1026, 40)
        Me.Barra.TabIndex = 3
        Me.Barra.Text = "Barra"
        '
        'BotonSalir
        '
        Me.BotonSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BotonSalir.Image = CType(resources.GetObject("BotonSalir.Image"), System.Drawing.Image)
        Me.BotonSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BotonSalir.Name = "BotonSalir"
        Me.BotonSalir.Size = New System.Drawing.Size(34, 37)
        Me.BotonSalir.Text = "ToolStripButton1"
        Me.BotonSalir.ToolTipText = "Salir del Sistema"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'BotonTablas
        '
        Me.BotonTablas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BotonTablas.Image = CType(resources.GetObject("BotonTablas.Image"), System.Drawing.Image)
        Me.BotonTablas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BotonTablas.Name = "BotonTablas"
        Me.BotonTablas.Size = New System.Drawing.Size(34, 37)
        Me.BotonTablas.Text = "ToolStripButton1"
        Me.BotonTablas.ToolTipText = "Tablas del Sistema"
        Me.BotonTablas.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'BotonAltaPropuesta
        '
        Me.BotonAltaPropuesta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BotonAltaPropuesta.Image = CType(resources.GetObject("BotonAltaPropuesta.Image"), System.Drawing.Image)
        Me.BotonAltaPropuesta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BotonAltaPropuesta.Name = "BotonAltaPropuesta"
        Me.BotonAltaPropuesta.Size = New System.Drawing.Size(34, 37)
        Me.BotonAltaPropuesta.Text = "ToolStripButton1"
        Me.BotonAltaPropuesta.ToolTipText = "Alta de Propuesta"
        Me.BotonAltaPropuesta.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'ClientesDelPeriodoToolStripMenuItem
        '
        Me.ClientesDelPeriodoToolStripMenuItem.Name = "ClientesDelPeriodoToolStripMenuItem"
        Me.ClientesDelPeriodoToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.ClientesDelPeriodoToolStripMenuItem.Text = "Clientes del periodo"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackgroundImage = Global.Sapyc.My.Resources.Resources.fondo_3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1026, 577)
        Me.Controls.Add(Me.Barra)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Principal"
        Me.Text = "Sapyc 2.0"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Barra.ResumeLayout(False)
        Me.Barra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnTablas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TablasDelSistemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Barra As System.Windows.Forms.ToolStrip
    Friend WithEvents BotonSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BotonTablas As System.Windows.Forms.ToolStripButton
    Friend WithEvents MnPropuestas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAltaDePropuesta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BotonAltaPropuesta As System.Windows.Forms.ToolStripButton
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManejoDeClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UtileriasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatosDeConfiguraciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GirosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActividadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DivisionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TiposDeServicioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComoSeEnteroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MedioDeContactoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuInde As ToolStripMenuItem
    Friend WithEvents CargarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SolicitudesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CargarListasNegrasSSGTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PartesRelacionadasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnvioCorreosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesFacturaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultaPropuestasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultaFoliosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesConflickToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesRelacionadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TodasLasSolicitudesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesPorClaveDeTrabajoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuReportes As ToolStripMenuItem
    Friend WithEvents itmReporteDireccion As ToolStripMenuItem
    Friend WithEvents itmClientesReferenciados As ToolStripMenuItem
    Friend WithEvents mnuProspectos As ToolStripMenuItem
    Friend WithEvents RegistrarProspectoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesDelPeriodoToolStripMenuItem As ToolStripMenuItem
End Class
