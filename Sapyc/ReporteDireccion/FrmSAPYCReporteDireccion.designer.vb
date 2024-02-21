<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSAPYCReporteDireccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSAPYCReporteDireccion))
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.panFiltro = New System.Windows.Forms.Panel()
        Me.rdSocioEncargado = New System.Windows.Forms.RadioButton()
        Me.panTipoSocios = New System.Windows.Forms.Panel()
        Me.txtSocio = New System.Windows.Forms.Label()
        Me.rdSocio = New System.Windows.Forms.RadioButton()
        Me.rdCompleto = New System.Windows.Forms.RadioButton()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.rdIndividual = New System.Windows.Forms.RadioButton()
        Me.btnGenerarRpt = New System.Windows.Forms.Button()
        Me.lblRegresar = New System.Windows.Forms.LinkLabel()
        Me.tabPaginas = New System.Windows.Forms.TabControl()
        Me.tabConciliacionInicial = New System.Windows.Forms.TabPage()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.btnHabilitar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gridConcilacionIni = New System.Windows.Forms.DataGridView()
        Me.tabConciliacion = New System.Windows.Forms.TabPage()
        Me.gridConciliacion = New System.Windows.Forms.DataGridView()
        Me.tabNoRecurrentes = New System.Windows.Forms.TabPage()
        Me.gridNoRecurrentes = New System.Windows.Forms.DataGridView()
        Me.tabPerdidos = New System.Windows.Forms.TabPage()
        Me.lblMsgPer = New System.Windows.Forms.Label()
        Me.gridPerdidos = New System.Windows.Forms.DataGridView()
        Me.btnHabilitarPer = New System.Windows.Forms.Button()
        Me.btnGuardarPer = New System.Windows.Forms.Button()
        Me.tabRecNoArreglados = New System.Windows.Forms.TabPage()
        Me.gridRNA = New System.Windows.Forms.DataGridView()
        Me.tabNvosGanados = New System.Windows.Forms.TabPage()
        Me.gridNuevos = New System.Windows.Forms.DataGridView()
        Me.tabRecurrentes = New System.Windows.Forms.TabPage()
        Me.gridRecurrentes = New System.Windows.Forms.DataGridView()
        Me.tabPropuestasPendientes = New System.Windows.Forms.TabPage()
        Me.gridPendientes = New System.Windows.Forms.DataGridView()
        Me.tabRechazadas = New System.Windows.Forms.TabPage()
        Me.gridRechazadas = New System.Windows.Forms.DataGridView()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.panFiltro.SuspendLayout()
        Me.panTipoSocios.SuspendLayout()
        Me.tabPaginas.SuspendLayout()
        Me.tabConciliacionInicial.SuspendLayout()
        CType(Me.gridConcilacionIni, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabConciliacion.SuspendLayout()
        CType(Me.gridConciliacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabNoRecurrentes.SuspendLayout()
        CType(Me.gridNoRecurrentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPerdidos.SuspendLayout()
        CType(Me.gridPerdidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRecNoArreglados.SuspendLayout()
        CType(Me.gridRNA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabNvosGanados.SuspendLayout()
        CType(Me.gridNuevos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRecurrentes.SuspendLayout()
        CType(Me.gridRecurrentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPropuestasPendientes.SuspendLayout()
        CType(Me.gridPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRechazadas.SuspendLayout()
        CType(Me.gridRechazadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(1043, 665)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(135, 25)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.panFiltro)
        Me.panPrincipal.Controls.Add(Me.btnGenerarRpt)
        Me.panPrincipal.Controls.Add(Me.lblRegresar)
        Me.panPrincipal.Controls.Add(Me.tabPaginas)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1190, 658)
        Me.panPrincipal.TabIndex = 0
        '
        'panFiltro
        '
        Me.panFiltro.BackColor = System.Drawing.Color.Transparent
        Me.panFiltro.Controls.Add(Me.rdSocioEncargado)
        Me.panFiltro.Controls.Add(Me.panTipoSocios)
        Me.panFiltro.Controls.Add(Me.rdIndividual)
        Me.panFiltro.Location = New System.Drawing.Point(5, 41)
        Me.panFiltro.Name = "panFiltro"
        Me.panFiltro.Size = New System.Drawing.Size(663, 72)
        Me.panFiltro.TabIndex = 2
        '
        'rdSocioEncargado
        '
        Me.rdSocioEncargado.Location = New System.Drawing.Point(17, 3)
        Me.rdSocioEncargado.Name = "rdSocioEncargado"
        Me.rdSocioEncargado.Size = New System.Drawing.Size(130, 22)
        Me.rdSocioEncargado.TabIndex = 0
        Me.rdSocioEncargado.TabStop = True
        Me.rdSocioEncargado.Text = "Socio Encargado"
        Me.rdSocioEncargado.UseVisualStyleBackColor = True
        '
        'panTipoSocios
        '
        Me.panTipoSocios.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.panTipoSocios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panTipoSocios.Controls.Add(Me.txtSocio)
        Me.panTipoSocios.Controls.Add(Me.rdSocio)
        Me.panTipoSocios.Controls.Add(Me.rdCompleto)
        Me.panTipoSocios.Controls.Add(Me.btnBuscar)
        Me.panTipoSocios.Location = New System.Drawing.Point(6, 30)
        Me.panTipoSocios.Name = "panTipoSocios"
        Me.panTipoSocios.Size = New System.Drawing.Size(649, 35)
        Me.panTipoSocios.TabIndex = 3
        '
        'txtSocio
        '
        Me.txtSocio.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSocio.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSocio.ForeColor = System.Drawing.Color.Black
        Me.txtSocio.Location = New System.Drawing.Point(176, 5)
        Me.txtSocio.Name = "txtSocio"
        Me.txtSocio.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.txtSocio.Size = New System.Drawing.Size(424, 23)
        Me.txtSocio.TabIndex = 5
        Me.txtSocio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdSocio
        '
        Me.rdSocio.ForeColor = System.Drawing.Color.White
        Me.rdSocio.Location = New System.Drawing.Point(107, 5)
        Me.rdSocio.Name = "rdSocio"
        Me.rdSocio.Size = New System.Drawing.Size(63, 22)
        Me.rdSocio.TabIndex = 1
        Me.rdSocio.Text = "Socio"
        Me.rdSocio.UseVisualStyleBackColor = True
        '
        'rdCompleto
        '
        Me.rdCompleto.Checked = True
        Me.rdCompleto.ForeColor = System.Drawing.Color.White
        Me.rdCompleto.Location = New System.Drawing.Point(10, 5)
        Me.rdCompleto.Name = "rdCompleto"
        Me.rdCompleto.Size = New System.Drawing.Size(91, 22)
        Me.rdCompleto.TabIndex = 0
        Me.rdCompleto.TabStop = True
        Me.rdCompleto.Text = "Completo"
        Me.rdCompleto.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(606, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(36, 24)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "..."
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'rdIndividual
        '
        Me.rdIndividual.Location = New System.Drawing.Point(153, 3)
        Me.rdIndividual.Name = "rdIndividual"
        Me.rdIndividual.Size = New System.Drawing.Size(130, 22)
        Me.rdIndividual.TabIndex = 1
        Me.rdIndividual.TabStop = True
        Me.rdIndividual.Text = "Individual"
        Me.rdIndividual.UseVisualStyleBackColor = True
        Me.rdIndividual.Visible = False
        '
        'btnGenerarRpt
        '
        Me.btnGenerarRpt.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerarRpt.Location = New System.Drawing.Point(674, 82)
        Me.btnGenerarRpt.Name = "btnGenerarRpt"
        Me.btnGenerarRpt.Size = New System.Drawing.Size(140, 25)
        Me.btnGenerarRpt.TabIndex = 4
        Me.btnGenerarRpt.Text = "Generar"
        Me.btnGenerarRpt.UseVisualStyleBackColor = True
        '
        'lblRegresar
        '
        Me.lblRegresar.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblRegresar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRegresar.AutoSize = True
        Me.lblRegresar.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblRegresar.LinkColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblRegresar.Location = New System.Drawing.Point(1123, 89)
        Me.lblRegresar.Name = "lblRegresar"
        Me.lblRegresar.Size = New System.Drawing.Size(62, 18)
        Me.lblRegresar.TabIndex = 5
        Me.lblRegresar.TabStop = True
        Me.lblRegresar.Text = "Regresar"
        Me.lblRegresar.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        '
        'tabPaginas
        '
        Me.tabPaginas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabPaginas.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabPaginas.Controls.Add(Me.tabConciliacionInicial)
        Me.tabPaginas.Controls.Add(Me.tabConciliacion)
        Me.tabPaginas.Controls.Add(Me.tabNoRecurrentes)
        Me.tabPaginas.Controls.Add(Me.tabPerdidos)
        Me.tabPaginas.Controls.Add(Me.tabRecNoArreglados)
        Me.tabPaginas.Controls.Add(Me.tabNvosGanados)
        Me.tabPaginas.Controls.Add(Me.tabRecurrentes)
        Me.tabPaginas.Controls.Add(Me.tabPropuestasPendientes)
        Me.tabPaginas.Controls.Add(Me.tabRechazadas)
        Me.tabPaginas.HotTrack = True
        Me.tabPaginas.ItemSize = New System.Drawing.Size(300, 30)
        Me.tabPaginas.Location = New System.Drawing.Point(1, 119)
        Me.tabPaginas.Name = "tabPaginas"
        Me.tabPaginas.SelectedIndex = 0
        Me.tabPaginas.ShowToolTips = True
        Me.tabPaginas.Size = New System.Drawing.Size(1188, 534)
        Me.tabPaginas.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabPaginas.TabIndex = 6
        '
        'tabConciliacionInicial
        '
        Me.tabConciliacionInicial.Controls.Add(Me.btnFinalizar)
        Me.tabConciliacionInicial.Controls.Add(Me.btnHabilitar)
        Me.tabConciliacionInicial.Controls.Add(Me.btnGuardar)
        Me.tabConciliacionInicial.Controls.Add(Me.gridConcilacionIni)
        Me.tabConciliacionInicial.Location = New System.Drawing.Point(4, 34)
        Me.tabConciliacionInicial.Margin = New System.Windows.Forms.Padding(0)
        Me.tabConciliacionInicial.Name = "tabConciliacionInicial"
        Me.tabConciliacionInicial.Size = New System.Drawing.Size(1180, 496)
        Me.tabConciliacionInicial.TabIndex = 8
        Me.tabConciliacionInicial.Text = "CONCILIACIÓN INICIAL"
        Me.tabConciliacionInicial.UseVisualStyleBackColor = True
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFinalizar.Enabled = False
        Me.btnFinalizar.Location = New System.Drawing.Point(1047, 468)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(130, 25)
        Me.btnFinalizar.TabIndex = 3
        Me.btnFinalizar.Text = "Finalizar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        Me.btnFinalizar.Visible = False
        '
        'btnHabilitar
        '
        Me.btnHabilitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnHabilitar.Location = New System.Drawing.Point(6, 468)
        Me.btnHabilitar.Name = "btnHabilitar"
        Me.btnHabilitar.Size = New System.Drawing.Size(130, 25)
        Me.btnHabilitar.TabIndex = 1
        Me.btnHabilitar.Text = "Habilitar"
        Me.btnHabilitar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Location = New System.Drawing.Point(142, 468)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(130, 25)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'gridConcilacionIni
        '
        Me.gridConcilacionIni.AllowDrop = True
        Me.gridConcilacionIni.AllowUserToAddRows = False
        Me.gridConcilacionIni.AllowUserToDeleteRows = False
        Me.gridConcilacionIni.AllowUserToResizeColumns = False
        Me.gridConcilacionIni.AllowUserToResizeRows = False
        Me.gridConcilacionIni.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridConcilacionIni.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridConcilacionIni.ColumnHeadersHeight = 40
        Me.gridConcilacionIni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridConcilacionIni.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridConcilacionIni.GridColor = System.Drawing.Color.Gainsboro
        Me.gridConcilacionIni.Location = New System.Drawing.Point(0, 0)
        Me.gridConcilacionIni.MultiSelect = False
        Me.gridConcilacionIni.Name = "gridConcilacionIni"
        Me.gridConcilacionIni.RowHeadersWidth = 25
        Me.gridConcilacionIni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridConcilacionIni.Size = New System.Drawing.Size(1180, 463)
        Me.gridConcilacionIni.TabIndex = 0
        '
        'tabConciliacion
        '
        Me.tabConciliacion.Controls.Add(Me.gridConciliacion)
        Me.tabConciliacion.Location = New System.Drawing.Point(4, 34)
        Me.tabConciliacion.Name = "tabConciliacion"
        Me.tabConciliacion.Size = New System.Drawing.Size(1180, 496)
        Me.tabConciliacion.TabIndex = 0
        Me.tabConciliacion.Text = "CONCILIACIÓN DE INGRESOS"
        Me.tabConciliacion.UseVisualStyleBackColor = True
        '
        'gridConciliacion
        '
        Me.gridConciliacion.AllowUserToAddRows = False
        Me.gridConciliacion.AllowUserToDeleteRows = False
        Me.gridConciliacion.AllowUserToResizeColumns = False
        Me.gridConciliacion.AllowUserToResizeRows = False
        Me.gridConciliacion.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridConciliacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridConciliacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridConciliacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridConciliacion.GridColor = System.Drawing.Color.Gainsboro
        Me.gridConciliacion.Location = New System.Drawing.Point(0, 0)
        Me.gridConciliacion.Name = "gridConciliacion"
        Me.gridConciliacion.RowHeadersWidth = 25
        Me.gridConciliacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridConciliacion.Size = New System.Drawing.Size(1180, 496)
        Me.gridConciliacion.TabIndex = 1
        '
        'tabNoRecurrentes
        '
        Me.tabNoRecurrentes.Controls.Add(Me.gridNoRecurrentes)
        Me.tabNoRecurrentes.Location = New System.Drawing.Point(4, 34)
        Me.tabNoRecurrentes.Name = "tabNoRecurrentes"
        Me.tabNoRecurrentes.Size = New System.Drawing.Size(1180, 496)
        Me.tabNoRecurrentes.TabIndex = 1
        Me.tabNoRecurrentes.Text = "TRABAJOS NO RECURRENTES"
        Me.tabNoRecurrentes.UseVisualStyleBackColor = True
        '
        'gridNoRecurrentes
        '
        Me.gridNoRecurrentes.AllowUserToAddRows = False
        Me.gridNoRecurrentes.AllowUserToDeleteRows = False
        Me.gridNoRecurrentes.AllowUserToResizeColumns = False
        Me.gridNoRecurrentes.AllowUserToResizeRows = False
        Me.gridNoRecurrentes.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridNoRecurrentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridNoRecurrentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridNoRecurrentes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridNoRecurrentes.GridColor = System.Drawing.Color.Gainsboro
        Me.gridNoRecurrentes.Location = New System.Drawing.Point(0, 0)
        Me.gridNoRecurrentes.Name = "gridNoRecurrentes"
        Me.gridNoRecurrentes.RowHeadersWidth = 25
        Me.gridNoRecurrentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridNoRecurrentes.Size = New System.Drawing.Size(1180, 496)
        Me.gridNoRecurrentes.TabIndex = 4
        '
        'tabPerdidos
        '
        Me.tabPerdidos.BackColor = System.Drawing.Color.White
        Me.tabPerdidos.Controls.Add(Me.lblMsgPer)
        Me.tabPerdidos.Controls.Add(Me.gridPerdidos)
        Me.tabPerdidos.Controls.Add(Me.btnHabilitarPer)
        Me.tabPerdidos.Controls.Add(Me.btnGuardarPer)
        Me.tabPerdidos.Location = New System.Drawing.Point(4, 34)
        Me.tabPerdidos.Name = "tabPerdidos"
        Me.tabPerdidos.Size = New System.Drawing.Size(1180, 496)
        Me.tabPerdidos.TabIndex = 2
        Me.tabPerdidos.Text = "TRABAJOS PERDIDOS"
        '
        'lblMsgPer
        '
        Me.lblMsgPer.BackColor = System.Drawing.Color.LemonChiffon
        Me.lblMsgPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMsgPer.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMsgPer.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgPer.Image = Global.Sapyc.My.Resources.Resources.advertencia
        Me.lblMsgPer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMsgPer.Location = New System.Drawing.Point(0, 0)
        Me.lblMsgPer.Name = "lblMsgPer"
        Me.lblMsgPer.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblMsgPer.Size = New System.Drawing.Size(1180, 26)
        Me.lblMsgPer.TabIndex = 0
        Me.lblMsgPer.Text = "Existen una o varias claves sin motivo de pérdida, por favor captúrelos a la brev" &
    "edad."
        Me.lblMsgPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMsgPer.Visible = False
        '
        'gridPerdidos
        '
        Me.gridPerdidos.AllowUserToAddRows = False
        Me.gridPerdidos.AllowUserToDeleteRows = False
        Me.gridPerdidos.AllowUserToResizeColumns = False
        Me.gridPerdidos.AllowUserToResizeRows = False
        Me.gridPerdidos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridPerdidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridPerdidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPerdidos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridPerdidos.GridColor = System.Drawing.Color.Gainsboro
        Me.gridPerdidos.Location = New System.Drawing.Point(0, 0)
        Me.gridPerdidos.Name = "gridPerdidos"
        Me.gridPerdidos.RowHeadersWidth = 25
        Me.gridPerdidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridPerdidos.Size = New System.Drawing.Size(1180, 496)
        Me.gridPerdidos.TabIndex = 1
        '
        'btnHabilitarPer
        '
        Me.btnHabilitarPer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnHabilitarPer.Location = New System.Drawing.Point(5, 466)
        Me.btnHabilitarPer.Name = "btnHabilitarPer"
        Me.btnHabilitarPer.Size = New System.Drawing.Size(130, 25)
        Me.btnHabilitarPer.TabIndex = 3
        Me.btnHabilitarPer.Text = "Habilitar"
        Me.btnHabilitarPer.UseVisualStyleBackColor = True
        '
        'btnGuardarPer
        '
        Me.btnGuardarPer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGuardarPer.Enabled = False
        Me.btnGuardarPer.Location = New System.Drawing.Point(141, 466)
        Me.btnGuardarPer.Name = "btnGuardarPer"
        Me.btnGuardarPer.Size = New System.Drawing.Size(130, 25)
        Me.btnGuardarPer.TabIndex = 4
        Me.btnGuardarPer.Text = "Guardar"
        Me.btnGuardarPer.UseVisualStyleBackColor = True
        '
        'tabRecNoArreglados
        '
        Me.tabRecNoArreglados.Controls.Add(Me.gridRNA)
        Me.tabRecNoArreglados.Location = New System.Drawing.Point(4, 34)
        Me.tabRecNoArreglados.Name = "tabRecNoArreglados"
        Me.tabRecNoArreglados.Size = New System.Drawing.Size(1180, 496)
        Me.tabRecNoArreglados.TabIndex = 3
        Me.tabRecNoArreglados.Text = "TRABAJOS RECURRENTES POR ARREGLAR"
        Me.tabRecNoArreglados.UseVisualStyleBackColor = True
        '
        'gridRNA
        '
        Me.gridRNA.AllowUserToAddRows = False
        Me.gridRNA.AllowUserToDeleteRows = False
        Me.gridRNA.AllowUserToResizeColumns = False
        Me.gridRNA.AllowUserToResizeRows = False
        Me.gridRNA.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridRNA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridRNA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridRNA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridRNA.GridColor = System.Drawing.Color.Gainsboro
        Me.gridRNA.Location = New System.Drawing.Point(0, 0)
        Me.gridRNA.Name = "gridRNA"
        Me.gridRNA.RowHeadersWidth = 25
        Me.gridRNA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridRNA.Size = New System.Drawing.Size(1180, 496)
        Me.gridRNA.TabIndex = 4
        '
        'tabNvosGanados
        '
        Me.tabNvosGanados.Controls.Add(Me.gridNuevos)
        Me.tabNvosGanados.Location = New System.Drawing.Point(4, 34)
        Me.tabNvosGanados.Name = "tabNvosGanados"
        Me.tabNvosGanados.Size = New System.Drawing.Size(1180, 496)
        Me.tabNvosGanados.TabIndex = 4
        Me.tabNvosGanados.Text = "TRABAJOS NUEVOS GANADOS"
        Me.tabNvosGanados.UseVisualStyleBackColor = True
        '
        'gridNuevos
        '
        Me.gridNuevos.AllowUserToAddRows = False
        Me.gridNuevos.AllowUserToDeleteRows = False
        Me.gridNuevos.AllowUserToResizeColumns = False
        Me.gridNuevos.AllowUserToResizeRows = False
        Me.gridNuevos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridNuevos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridNuevos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridNuevos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridNuevos.GridColor = System.Drawing.Color.Gainsboro
        Me.gridNuevos.Location = New System.Drawing.Point(0, 0)
        Me.gridNuevos.Name = "gridNuevos"
        Me.gridNuevos.RowHeadersWidth = 25
        Me.gridNuevos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridNuevos.Size = New System.Drawing.Size(1180, 496)
        Me.gridNuevos.TabIndex = 4
        '
        'tabRecurrentes
        '
        Me.tabRecurrentes.Controls.Add(Me.gridRecurrentes)
        Me.tabRecurrentes.Location = New System.Drawing.Point(4, 34)
        Me.tabRecurrentes.Name = "tabRecurrentes"
        Me.tabRecurrentes.Size = New System.Drawing.Size(1180, 496)
        Me.tabRecurrentes.TabIndex = 5
        Me.tabRecurrentes.Text = "TRABAJOS RECURRENTES ARREGLADOS"
        Me.tabRecurrentes.UseVisualStyleBackColor = True
        '
        'gridRecurrentes
        '
        Me.gridRecurrentes.AllowUserToAddRows = False
        Me.gridRecurrentes.AllowUserToDeleteRows = False
        Me.gridRecurrentes.AllowUserToResizeColumns = False
        Me.gridRecurrentes.AllowUserToResizeRows = False
        Me.gridRecurrentes.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridRecurrentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridRecurrentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridRecurrentes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridRecurrentes.GridColor = System.Drawing.Color.Gainsboro
        Me.gridRecurrentes.Location = New System.Drawing.Point(0, 0)
        Me.gridRecurrentes.Name = "gridRecurrentes"
        Me.gridRecurrentes.RowHeadersWidth = 25
        Me.gridRecurrentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridRecurrentes.Size = New System.Drawing.Size(1180, 496)
        Me.gridRecurrentes.TabIndex = 4
        '
        'tabPropuestasPendientes
        '
        Me.tabPropuestasPendientes.Controls.Add(Me.gridPendientes)
        Me.tabPropuestasPendientes.Location = New System.Drawing.Point(4, 34)
        Me.tabPropuestasPendientes.Name = "tabPropuestasPendientes"
        Me.tabPropuestasPendientes.Size = New System.Drawing.Size(1180, 496)
        Me.tabPropuestasPendientes.TabIndex = 6
        Me.tabPropuestasPendientes.Text = "PROPUESTAS POR RESOLVER"
        Me.tabPropuestasPendientes.UseVisualStyleBackColor = True
        '
        'gridPendientes
        '
        Me.gridPendientes.AllowUserToAddRows = False
        Me.gridPendientes.AllowUserToDeleteRows = False
        Me.gridPendientes.AllowUserToResizeColumns = False
        Me.gridPendientes.AllowUserToResizeRows = False
        Me.gridPendientes.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPendientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridPendientes.GridColor = System.Drawing.Color.Gainsboro
        Me.gridPendientes.Location = New System.Drawing.Point(0, 0)
        Me.gridPendientes.Name = "gridPendientes"
        Me.gridPendientes.RowHeadersWidth = 25
        Me.gridPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridPendientes.Size = New System.Drawing.Size(1180, 496)
        Me.gridPendientes.TabIndex = 3
        '
        'tabRechazadas
        '
        Me.tabRechazadas.Controls.Add(Me.gridRechazadas)
        Me.tabRechazadas.Location = New System.Drawing.Point(4, 34)
        Me.tabRechazadas.Name = "tabRechazadas"
        Me.tabRechazadas.Size = New System.Drawing.Size(1180, 496)
        Me.tabRechazadas.TabIndex = 7
        Me.tabRechazadas.Text = "PROPUESTAS RECHAZADAS"
        Me.tabRechazadas.UseVisualStyleBackColor = True
        '
        'gridRechazadas
        '
        Me.gridRechazadas.AllowUserToAddRows = False
        Me.gridRechazadas.AllowUserToDeleteRows = False
        Me.gridRechazadas.AllowUserToResizeColumns = False
        Me.gridRechazadas.AllowUserToResizeRows = False
        Me.gridRechazadas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridRechazadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridRechazadas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridRechazadas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridRechazadas.GridColor = System.Drawing.Color.Gainsboro
        Me.gridRechazadas.Location = New System.Drawing.Point(0, 0)
        Me.gridRechazadas.Name = "gridRechazadas"
        Me.gridRechazadas.RowHeadersWidth = 25
        Me.gridRechazadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridRechazadas.Size = New System.Drawing.Size(1180, 496)
        Me.gridRechazadas.TabIndex = 2
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 35)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(1190, 2)
        Me.panLinea.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(2, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(310, 32)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "REPORTE DE LA DIRECCIÓN"
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(12, 664)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(135, 25)
        Me.btnExportar.TabIndex = 1
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'FrmSAPYCReporteDireccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1190, 695)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1106, 665)
        Me.Name = "FrmSAPYCReporteDireccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de la Dirección"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.panFiltro.ResumeLayout(False)
        Me.panTipoSocios.ResumeLayout(False)
        Me.tabPaginas.ResumeLayout(False)
        Me.tabConciliacionInicial.ResumeLayout(False)
        CType(Me.gridConcilacionIni, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabConciliacion.ResumeLayout(False)
        CType(Me.gridConciliacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabNoRecurrentes.ResumeLayout(False)
        CType(Me.gridNoRecurrentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPerdidos.ResumeLayout(False)
        CType(Me.gridPerdidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRecNoArreglados.ResumeLayout(False)
        CType(Me.gridRNA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabNvosGanados.ResumeLayout(False)
        CType(Me.gridNuevos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRecurrentes.ResumeLayout(False)
        CType(Me.gridRecurrentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPropuestasPendientes.ResumeLayout(False)
        CType(Me.gridPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRechazadas.ResumeLayout(False)
        CType(Me.gridRechazadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents panPrincipal As System.Windows.Forms.Panel
    Friend WithEvents btnGenerarRpt As System.Windows.Forms.Button
    Friend WithEvents gridConciliacion As System.Windows.Forms.DataGridView
    Friend WithEvents rdIndividual As System.Windows.Forms.RadioButton
    Friend WithEvents rdSocioEncargado As System.Windows.Forms.RadioButton
    Friend WithEvents panLinea As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents tabPaginas As System.Windows.Forms.TabControl
    Friend WithEvents tabConciliacion As System.Windows.Forms.TabPage
    Friend WithEvents tabNoRecurrentes As System.Windows.Forms.TabPage
    Friend WithEvents tabPerdidos As System.Windows.Forms.TabPage
    Friend WithEvents tabRecNoArreglados As System.Windows.Forms.TabPage
    Friend WithEvents tabNvosGanados As System.Windows.Forms.TabPage
    Friend WithEvents tabRecurrentes As System.Windows.Forms.TabPage
    Friend WithEvents tabPropuestasPendientes As System.Windows.Forms.TabPage
    Friend WithEvents tabRechazadas As System.Windows.Forms.TabPage
    Friend WithEvents gridRechazadas As System.Windows.Forms.DataGridView
    Friend WithEvents gridPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents gridNoRecurrentes As System.Windows.Forms.DataGridView
    Friend WithEvents gridPerdidos As System.Windows.Forms.DataGridView
    Friend WithEvents gridRNA As System.Windows.Forms.DataGridView
    Friend WithEvents gridNuevos As System.Windows.Forms.DataGridView
    Friend WithEvents gridRecurrentes As System.Windows.Forms.DataGridView
    Friend WithEvents tabConciliacionInicial As System.Windows.Forms.TabPage
    Friend WithEvents gridConcilacionIni As System.Windows.Forms.DataGridView
    Friend WithEvents btnFinalizar As Button
    Friend WithEvents btnHabilitar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblRegresar As LinkLabel
    Friend WithEvents panFiltro As Panel
    Friend WithEvents btnBuscar As Button
    Friend WithEvents panTipoSocios As Panel
    Friend WithEvents rdSocio As RadioButton
    Friend WithEvents rdCompleto As RadioButton
    Friend WithEvents txtSocio As Label
    Friend WithEvents lblMsgPer As Label
    Friend WithEvents btnHabilitarPer As Button
    Friend WithEvents btnGuardarPer As Button
End Class
