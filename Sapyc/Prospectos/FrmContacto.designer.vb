<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmContacto
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContacto))
        Me.panMenu = New System.Windows.Forms.Panel()
        Me.panMensajesError = New System.Windows.Forms.Panel()
        Me.btnGuardarAvance = New System.Windows.Forms.Button()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.lblTituloError = New System.Windows.Forms.Label()
        Me.txtClaveProspecto = New System.Windows.Forms.Label()
        Me.lnkDireccion = New System.Windows.Forms.LinkLabel()
        Me.lnkAcercamiento = New System.Windows.Forms.LinkLabel()
        Me.lnkContactoInicial = New System.Windows.Forms.LinkLabel()
        Me.lnkDatosGenerales = New System.Windows.Forms.LinkLabel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnCancelaGeneral = New System.Windows.Forms.Button()
        Me.btnGuardaGeneral = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.panDatosGenerales = New System.Windows.Forms.Panel()
        Me.gpBoxDatosDG = New System.Windows.Forms.GroupBox()
        Me.Lista = New System.Windows.Forms.DataGridView()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.lblIdSAC = New System.Windows.Forms.Label()
        Me.txtIdSAC = New System.Windows.Forms.TextBox()
        Me.gpBoxTipoNegocio = New System.Windows.Forms.GroupBox()
        Me.rdPersonaFisica = New System.Windows.Forms.RadioButton()
        Me.rdPersonalMoral = New System.Windows.Forms.RadioButton()
        Me.gpBoxServicio = New System.Windows.Forms.GroupBox()
        Me.cboSocio = New System.Windows.Forms.ComboBox()
        Me.lblDatosGeneralesSocio = New System.Windows.Forms.Label()
        Me.cboDivision = New System.Windows.Forms.ComboBox()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.cboOficina = New System.Windows.Forms.ComboBox()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.cboModalidades = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFechaSolicitud = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFechaEntregaReporte = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaEntregaReporte = New System.Windows.Forms.Label()
        Me.txtPeriodoFinal = New System.Windows.Forms.DateTimePicker()
        Me.lblPeriodoServicioA = New System.Windows.Forms.Label()
        Me.txtPeriodoInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblPeriodoServicio = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboIdioma = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rdIdiomaNo = New System.Windows.Forms.RadioButton()
        Me.rdIdiomaSi = New System.Windows.Forms.RadioButton()
        Me.cboDatosGeneralesServicio = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDescripcionSolicitud = New System.Windows.Forms.Label()
        Me.txtDescripcionSolicitud = New System.Windows.Forms.TextBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.btnSubnivel = New System.Windows.Forms.Button()
        Me.btnSubsector = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIndustria = New System.Windows.Forms.Label()
        Me.btnIndustria = New System.Windows.Forms.Button()
        Me.txtSubnivel = New System.Windows.Forms.TextBox()
        Me.gpBoxSubsidiaria = New System.Windows.Forms.GroupBox()
        Me.lblSubsidiaria = New System.Windows.Forms.Label()
        Me.lblControladora = New System.Windows.Forms.Label()
        Me.panRDSubsidiaria = New System.Windows.Forms.Panel()
        Me.rdSubsidiariaSi = New System.Windows.Forms.RadioButton()
        Me.rdSubsidiariaNo = New System.Windows.Forms.RadioButton()
        Me.panRDCompañiaControl = New System.Windows.Forms.Panel()
        Me.rdControladoraSi = New System.Windows.Forms.RadioButton()
        Me.rdControladoraNO = New System.Windows.Forms.RadioButton()
        Me.txtSubsector = New System.Windows.Forms.TextBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.lblNombreComercial = New System.Windows.Forms.Label()
        Me.txtNombreComercial = New System.Windows.Forms.TextBox()
        Me.txtIndustria = New System.Windows.Forms.TextBox()
        Me.gpBoxEmpresaPublica = New System.Windows.Forms.GroupBox()
        Me.lblBolsaValoresOtra = New System.Windows.Forms.Label()
        Me.lblBolsaValores = New System.Windows.Forms.Label()
        Me.rdEmpresaPublicaNo = New System.Windows.Forms.RadioButton()
        Me.rdEmpresaPublicaSi = New System.Windows.Forms.RadioButton()
        Me.txtBolsaValoresOtro = New System.Windows.Forms.TextBox()
        Me.cboBolsaValores = New System.Windows.Forms.ComboBox()
        Me.gpBoxEntidadReguladora = New System.Windows.Forms.GroupBox()
        Me.lblEntidadReguladoraOtra = New System.Windows.Forms.Label()
        Me.lblEntidadReguladora = New System.Windows.Forms.Label()
        Me.txtEntidadReguladoraOtro = New System.Windows.Forms.TextBox()
        Me.cboEntidadReguladora = New System.Windows.Forms.ComboBox()
        Me.rdEntidadReguladaNo = New System.Windows.Forms.RadioButton()
        Me.rdEntidadReguladaSi = New System.Windows.Forms.RadioButton()
        Me.gpBoxEntidadSupervisada = New System.Windows.Forms.GroupBox()
        Me.lblEntidadSupervisadaOtra = New System.Windows.Forms.Label()
        Me.lblEntidadSupervisada = New System.Windows.Forms.Label()
        Me.txtEntidadSupervisadaOtro = New System.Windows.Forms.TextBox()
        Me.cboEntidadSupervisada = New System.Windows.Forms.ComboBox()
        Me.rdEntidadSupervisadaNo = New System.Windows.Forms.RadioButton()
        Me.rdEntidadSupervisadaSi = New System.Windows.Forms.RadioButton()
        Me.cboPais = New System.Windows.Forms.ComboBox()
        Me.gpBoxReferenciaGTI = New System.Windows.Forms.GroupBox()
        Me.txtEstadoGTI = New System.Windows.Forms.TextBox()
        Me.lblEstadoGTI = New System.Windows.Forms.Label()
        Me.txtCorreoGerenteGTI = New System.Windows.Forms.TextBox()
        Me.lblCorreoGerenteGTI = New System.Windows.Forms.Label()
        Me.txtGerenteGTI = New System.Windows.Forms.TextBox()
        Me.lblGerenteGTI = New System.Windows.Forms.Label()
        Me.txtCorreoSocioGTI = New System.Windows.Forms.TextBox()
        Me.lblCorreoSocioGTI = New System.Windows.Forms.Label()
        Me.cboReferenciaGTIOficina = New System.Windows.Forms.ComboBox()
        Me.cboReferenciaGTIPais = New System.Windows.Forms.ComboBox()
        Me.lblReferenciaGTIPais = New System.Windows.Forms.Label()
        Me.lblRefGTIOficina = New System.Windows.Forms.Label()
        Me.txtReferenciaGTISocio = New System.Windows.Forms.TextBox()
        Me.lbRefGTISocio = New System.Windows.Forms.Label()
        Me.rdReferenciaGTINo = New System.Windows.Forms.RadioButton()
        Me.rdReferenciaGTISi = New System.Windows.Forms.RadioButton()
        Me.lblPais = New System.Windows.Forms.Label()
        Me.gpBoxEmpresaExtranjero = New System.Windows.Forms.GroupBox()
        Me.panRDDomExt = New System.Windows.Forms.Panel()
        Me.rdEmpresaExtranjeroDomSi = New System.Windows.Forms.RadioButton()
        Me.rdEmpresaExtranjeroDomNo = New System.Windows.Forms.RadioButton()
        Me.panRDSubExt = New System.Windows.Forms.Panel()
        Me.rdEmpresaExtranjeroSubSi = New System.Windows.Forms.RadioButton()
        Me.rdEmpresaExtranjeroSubNo = New System.Windows.Forms.RadioButton()
        Me.lblDomicilioExtranjero = New System.Windows.Forms.Label()
        Me.cboTipoEntidad = New System.Windows.Forms.ComboBox()
        Me.lblTipoEntidad = New System.Windows.Forms.Label()
        Me.lblCompañiaSubsidiaria = New System.Windows.Forms.Label()
        Me.cboPaisResidencia = New System.Windows.Forms.ComboBox()
        Me.lblReporteExtranjero = New System.Windows.Forms.Label()
        Me.lblPaisResidencia = New System.Windows.Forms.Label()
        Me.txtEmpresaTenedora = New System.Windows.Forms.TextBox()
        Me.lblEmpresaTenedora = New System.Windows.Forms.Label()
        Me.panRDRepExt = New System.Windows.Forms.Panel()
        Me.rdEmpresaExtranjeroRepSi = New System.Windows.Forms.RadioButton()
        Me.rdEmpresaExtranjeroRepNo = New System.Windows.Forms.RadioButton()
        Me.lblMensajeCargaDatosGenerales = New System.Windows.Forms.Label()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTituloDatosGenerales = New System.Windows.Forms.Label()
        Me.btnRegistroDatosGenerales = New System.Windows.Forms.Button()
        Me.panContactoInicial = New System.Windows.Forms.Panel()
        Me.lblMensajeCargaContactoInicial = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTituloCI = New System.Windows.Forms.Label()
        Me.panDatosContactoInicial = New System.Windows.Forms.Panel()
        Me.lblContactoInicialObligatorios = New System.Windows.Forms.Label()
        Me.lblTituloDatosContacto = New System.Windows.Forms.Label()
        Me.txtContactoInicialFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblContactoInicialFecha = New System.Windows.Forms.Label()
        Me.lblContactoInicialPrimeraPersona = New System.Windows.Forms.Label()
        Me.txtContactoInicialPrimerContacto = New System.Windows.Forms.TextBox()
        Me.gpBoxDatosContactoInicial = New System.Windows.Forms.GroupBox()
        Me.txtContactoInicialCelular = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblAcercamientoWebProspecto = New System.Windows.Forms.Label()
        Me.lblContactoInicialNombre = New System.Windows.Forms.Label()
        Me.txtAcercamientoWebProspecto = New System.Windows.Forms.TextBox()
        Me.txtContactoInicialExtension = New System.Windows.Forms.TextBox()
        Me.txtContactoInicialNombre = New System.Windows.Forms.TextBox()
        Me.lblContactoInicialExtension = New System.Windows.Forms.Label()
        Me.lblContactoInicialCargo = New System.Windows.Forms.Label()
        Me.txtContactoInicialTelefono = New System.Windows.Forms.TextBox()
        Me.txtContactoInicialCargo = New System.Windows.Forms.TextBox()
        Me.lblContactoInicialTelefono = New System.Windows.Forms.Label()
        Me.lblContactoInicialCorreo = New System.Windows.Forms.Label()
        Me.txtContactoInicialCorreo = New System.Windows.Forms.TextBox()
        Me.panAcercamiento = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblMensajeCargaAcercamiento = New System.Windows.Forms.Label()
        Me.lblMensajeErrorAcercamiento = New System.Windows.Forms.Label()
        Me.gpBoxDatosAcercamiento = New System.Windows.Forms.GroupBox()
        Me.lblMedioContactoOtro = New System.Windows.Forms.Label()
        Me.lblAcercamientoOtro = New System.Windows.Forms.Label()
        Me.cboAcercamientoMedioContacto = New System.Windows.Forms.ComboBox()
        Me.lblAcercamientoComoEntero = New System.Windows.Forms.Label()
        Me.txtAcercamientoEnteroOtro = New System.Windows.Forms.TextBox()
        Me.cboAcercamientoComoEntero = New System.Windows.Forms.ComboBox()
        Me.lblAcercamientoMedioContacto = New System.Windows.Forms.Label()
        Me.txtAcercamientoContactoOtro = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTituloAcercamiento = New System.Windows.Forms.Label()
        Me.panDireccion = New System.Windows.Forms.Panel()
        Me.lblMensajeCargaDomicilio = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblTituloDomicilio = New System.Windows.Forms.Label()
        Me.gpBoxDatosDomicilio = New System.Windows.Forms.GroupBox()
        Me.lblCamposDomicilio = New System.Windows.Forms.Label()
        Me.lblDomicilioPais = New System.Windows.Forms.Label()
        Me.cboDomicilioPais = New System.Windows.Forms.ComboBox()
        Me.panDomicilioExt = New System.Windows.Forms.Panel()
        Me.txtDomicilioExtCP = New System.Windows.Forms.TextBox()
        Me.lblDomicilioExtCP = New System.Windows.Forms.Label()
        Me.lblDomicilioExtDireccion2 = New System.Windows.Forms.Label()
        Me.txtDomicilioExtDireccion2 = New System.Windows.Forms.TextBox()
        Me.lblDomicilioExtDireccion1 = New System.Windows.Forms.Label()
        Me.lblDomicilioExtEstado = New System.Windows.Forms.Label()
        Me.lblDomicilioExtLocalidad = New System.Windows.Forms.Label()
        Me.txtDomicilioExtLocalidad = New System.Windows.Forms.TextBox()
        Me.txtDomicilioExtDireccion1 = New System.Windows.Forms.TextBox()
        Me.txtDomicilioExtEstado = New System.Windows.Forms.TextBox()
        Me.panDomicilioNac = New System.Windows.Forms.Panel()
        Me.lblDomicilioCalle = New System.Windows.Forms.Label()
        Me.cboDomicilioEstado = New System.Windows.Forms.ComboBox()
        Me.txtDomicilioNoInt = New System.Windows.Forms.TextBox()
        Me.cboDomicilioMunicipio = New System.Windows.Forms.ComboBox()
        Me.txtDomicilioCalle = New System.Windows.Forms.TextBox()
        Me.cboDomicilioColonia = New System.Windows.Forms.ComboBox()
        Me.txtDomicilioNoExt = New System.Windows.Forms.TextBox()
        Me.lblDomicilioEstado = New System.Windows.Forms.Label()
        Me.lblDomicilioNoInt = New System.Windows.Forms.Label()
        Me.lblDomicilioMunicipio = New System.Windows.Forms.Label()
        Me.lblDomicilioNoExt = New System.Windows.Forms.Label()
        Me.lblDomicilioColonia = New System.Windows.Forms.Label()
        Me.txtDomicilioCP = New System.Windows.Forms.TextBox()
        Me.lblDomicilioCP = New System.Windows.Forms.Label()
        Me.panMenu.SuspendLayout()
        Me.panMensajesError.SuspendLayout()
        Me.panDatosGenerales.SuspendLayout()
        Me.gpBoxDatosDG.SuspendLayout()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpBoxTipoNegocio.SuspendLayout()
        Me.gpBoxServicio.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpBoxSubsidiaria.SuspendLayout()
        Me.panRDSubsidiaria.SuspendLayout()
        Me.panRDCompañiaControl.SuspendLayout()
        Me.gpBoxEmpresaPublica.SuspendLayout()
        Me.gpBoxEntidadReguladora.SuspendLayout()
        Me.gpBoxEntidadSupervisada.SuspendLayout()
        Me.gpBoxReferenciaGTI.SuspendLayout()
        Me.gpBoxEmpresaExtranjero.SuspendLayout()
        Me.panRDDomExt.SuspendLayout()
        Me.panRDSubExt.SuspendLayout()
        Me.panRDRepExt.SuspendLayout()
        Me.panContactoInicial.SuspendLayout()
        Me.panDatosContactoInicial.SuspendLayout()
        Me.gpBoxDatosContactoInicial.SuspendLayout()
        Me.panAcercamiento.SuspendLayout()
        Me.gpBoxDatosAcercamiento.SuspendLayout()
        Me.panDireccion.SuspendLayout()
        Me.gpBoxDatosDomicilio.SuspendLayout()
        Me.panDomicilioExt.SuspendLayout()
        Me.panDomicilioNac.SuspendLayout()
        Me.SuspendLayout()
        '
        'panMenu
        '
        Me.panMenu.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panMenu.Controls.Add(Me.panMensajesError)
        Me.panMenu.Controls.Add(Me.txtClaveProspecto)
        Me.panMenu.Controls.Add(Me.lnkDireccion)
        Me.panMenu.Controls.Add(Me.lnkAcercamiento)
        Me.panMenu.Controls.Add(Me.lnkContactoInicial)
        Me.panMenu.Controls.Add(Me.lnkDatosGenerales)
        Me.panMenu.Controls.Add(Me.lblTitulo)
        Me.panMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.panMenu.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.panMenu.Location = New System.Drawing.Point(0, 0)
        Me.panMenu.Name = "panMenu"
        Me.panMenu.Size = New System.Drawing.Size(212, 700)
        Me.panMenu.TabIndex = 0
        '
        'panMensajesError
        '
        Me.panMensajesError.Controls.Add(Me.btnGuardarAvance)
        Me.panMensajesError.Controls.Add(Me.txtMensaje)
        Me.panMensajesError.Controls.Add(Me.lblTituloError)
        Me.panMensajesError.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panMensajesError.Location = New System.Drawing.Point(0, 290)
        Me.panMensajesError.Name = "panMensajesError"
        Me.panMensajesError.Size = New System.Drawing.Size(210, 408)
        Me.panMensajesError.TabIndex = 28
        Me.panMensajesError.Visible = False
        '
        'btnGuardarAvance
        '
        Me.btnGuardarAvance.Enabled = False
        Me.btnGuardarAvance.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarAvance.Location = New System.Drawing.Point(40, 375)
        Me.btnGuardarAvance.Name = "btnGuardarAvance"
        Me.btnGuardarAvance.Size = New System.Drawing.Size(130, 25)
        Me.btnGuardarAvance.TabIndex = 2
        Me.btnGuardarAvance.Text = "Guardar avance"
        Me.btnGuardarAvance.UseVisualStyleBackColor = True
        '
        'txtMensaje
        '
        Me.txtMensaje.BackColor = System.Drawing.Color.White
        Me.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMensaje.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtMensaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.txtMensaje.Location = New System.Drawing.Point(0, 30)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.ReadOnly = True
        Me.txtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMensaje.Size = New System.Drawing.Size(210, 338)
        Me.txtMensaje.TabIndex = 1
        '
        'lblTituloError
        '
        Me.lblTituloError.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lblTituloError.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloError.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloError.ForeColor = System.Drawing.Color.White
        Me.lblTituloError.Location = New System.Drawing.Point(0, 0)
        Me.lblTituloError.Name = "lblTituloError"
        Me.lblTituloError.Size = New System.Drawing.Size(210, 28)
        Me.lblTituloError.TabIndex = 0
        Me.lblTituloError.Text = "INFORMACIÓN FALTANTE"
        Me.lblTituloError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtClaveProspecto
        '
        Me.txtClaveProspecto.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.txtClaveProspecto.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold)
        Me.txtClaveProspecto.ForeColor = System.Drawing.Color.White
        Me.txtClaveProspecto.Location = New System.Drawing.Point(0, 44)
        Me.txtClaveProspecto.Name = "txtClaveProspecto"
        Me.txtClaveProspecto.Size = New System.Drawing.Size(212, 45)
        Me.txtClaveProspecto.TabIndex = 11
        Me.txtClaveProspecto.Text = "PRS000000"
        Me.txtClaveProspecto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lnkDireccion
        '
        Me.lnkDireccion.ActiveLinkColor = System.Drawing.Color.White
        Me.lnkDireccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lnkDireccion.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkDireccion.ForeColor = System.Drawing.Color.White
        Me.lnkDireccion.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkDireccion.LinkColor = System.Drawing.Color.White
        Me.lnkDireccion.Location = New System.Drawing.Point(0, 237)
        Me.lnkDireccion.Name = "lnkDireccion"
        Me.lnkDireccion.Padding = New System.Windows.Forms.Padding(13, 0, 0, 0)
        Me.lnkDireccion.Size = New System.Drawing.Size(212, 34)
        Me.lnkDireccion.TabIndex = 7
        Me.lnkDireccion.TabStop = True
        Me.lnkDireccion.Tag = "4"
        Me.lnkDireccion.Text = "Domicilio"
        Me.lnkDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDireccion.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        '
        'lnkAcercamiento
        '
        Me.lnkAcercamiento.ActiveLinkColor = System.Drawing.Color.White
        Me.lnkAcercamiento.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lnkAcercamiento.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkAcercamiento.ForeColor = System.Drawing.Color.White
        Me.lnkAcercamiento.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkAcercamiento.LinkColor = System.Drawing.Color.White
        Me.lnkAcercamiento.Location = New System.Drawing.Point(0, 193)
        Me.lnkAcercamiento.Name = "lnkAcercamiento"
        Me.lnkAcercamiento.Padding = New System.Windows.Forms.Padding(13, 0, 0, 0)
        Me.lnkAcercamiento.Size = New System.Drawing.Size(212, 34)
        Me.lnkAcercamiento.TabIndex = 6
        Me.lnkAcercamiento.TabStop = True
        Me.lnkAcercamiento.Tag = "3"
        Me.lnkAcercamiento.Text = "Acercamiento"
        Me.lnkAcercamiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAcercamiento.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        '
        'lnkContactoInicial
        '
        Me.lnkContactoInicial.ActiveLinkColor = System.Drawing.Color.White
        Me.lnkContactoInicial.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lnkContactoInicial.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkContactoInicial.ForeColor = System.Drawing.Color.White
        Me.lnkContactoInicial.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkContactoInicial.LinkColor = System.Drawing.Color.White
        Me.lnkContactoInicial.Location = New System.Drawing.Point(0, 149)
        Me.lnkContactoInicial.Name = "lnkContactoInicial"
        Me.lnkContactoInicial.Padding = New System.Windows.Forms.Padding(13, 0, 0, 0)
        Me.lnkContactoInicial.Size = New System.Drawing.Size(212, 34)
        Me.lnkContactoInicial.TabIndex = 5
        Me.lnkContactoInicial.TabStop = True
        Me.lnkContactoInicial.Tag = "2"
        Me.lnkContactoInicial.Text = "Contacto Inicial"
        Me.lnkContactoInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkContactoInicial.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        '
        'lnkDatosGenerales
        '
        Me.lnkDatosGenerales.ActiveLinkColor = System.Drawing.Color.White
        Me.lnkDatosGenerales.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lnkDatosGenerales.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkDatosGenerales.ForeColor = System.Drawing.Color.White
        Me.lnkDatosGenerales.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkDatosGenerales.LinkColor = System.Drawing.Color.White
        Me.lnkDatosGenerales.Location = New System.Drawing.Point(0, 105)
        Me.lnkDatosGenerales.Name = "lnkDatosGenerales"
        Me.lnkDatosGenerales.Padding = New System.Windows.Forms.Padding(13, 0, 0, 0)
        Me.lnkDatosGenerales.Size = New System.Drawing.Size(212, 34)
        Me.lnkDatosGenerales.TabIndex = 0
        Me.lnkDatosGenerales.TabStop = True
        Me.lnkDatosGenerales.Tag = "1"
        Me.lnkDatosGenerales.Text = "Datos Generales"
        Me.lnkDatosGenerales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDatosGenerales.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(6, 4)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(199, 33)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "CTE. PROSPECTO"
        '
        'btnCancelaGeneral
        '
        Me.btnCancelaGeneral.Enabled = False
        Me.btnCancelaGeneral.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelaGeneral.Location = New System.Drawing.Point(499, 668)
        Me.btnCancelaGeneral.Name = "btnCancelaGeneral"
        Me.btnCancelaGeneral.Size = New System.Drawing.Size(130, 25)
        Me.btnCancelaGeneral.TabIndex = 4
        Me.btnCancelaGeneral.Text = "Cancelar"
        Me.btnCancelaGeneral.UseVisualStyleBackColor = True
        '
        'btnGuardaGeneral
        '
        Me.btnGuardaGeneral.Enabled = False
        Me.btnGuardaGeneral.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardaGeneral.Location = New System.Drawing.Point(363, 668)
        Me.btnGuardaGeneral.Name = "btnGuardaGeneral"
        Me.btnGuardaGeneral.Size = New System.Drawing.Size(130, 25)
        Me.btnGuardaGeneral.TabIndex = 3
        Me.btnGuardaGeneral.Text = "Guardar"
        Me.btnGuardaGeneral.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(1176, 668)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(130, 25)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'panDatosGenerales
        '
        Me.panDatosGenerales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panDatosGenerales.AutoScroll = True
        Me.panDatosGenerales.AutoScrollMargin = New System.Drawing.Size(0, 15)
        Me.panDatosGenerales.BackColor = System.Drawing.Color.White
        Me.panDatosGenerales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panDatosGenerales.Controls.Add(Me.gpBoxDatosDG)
        Me.panDatosGenerales.Controls.Add(Me.lblMensajeCargaDatosGenerales)
        Me.panDatosGenerales.Controls.Add(Me.panLinea)
        Me.panDatosGenerales.Controls.Add(Me.lblTituloDatosGenerales)
        Me.panDatosGenerales.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.panDatosGenerales.Location = New System.Drawing.Point(212, 0)
        Me.panDatosGenerales.Name = "panDatosGenerales"
        Me.panDatosGenerales.Size = New System.Drawing.Size(1106, 660)
        Me.panDatosGenerales.TabIndex = 0
        Me.panDatosGenerales.Tag = "1"
        Me.panDatosGenerales.Visible = False
        '
        'gpBoxDatosDG
        '
        Me.gpBoxDatosDG.Controls.Add(Me.Lista)
        Me.gpBoxDatosDG.Controls.Add(Me.txtRazonSocial)
        Me.gpBoxDatosDG.Controls.Add(Me.lblIdSAC)
        Me.gpBoxDatosDG.Controls.Add(Me.txtIdSAC)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxTipoNegocio)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxServicio)
        Me.gpBoxDatosDG.Controls.Add(Me.lblRFC)
        Me.gpBoxDatosDG.Controls.Add(Me.txtRFC)
        Me.gpBoxDatosDG.Controls.Add(Me.btnSubnivel)
        Me.gpBoxDatosDG.Controls.Add(Me.btnSubsector)
        Me.gpBoxDatosDG.Controls.Add(Me.Label2)
        Me.gpBoxDatosDG.Controls.Add(Me.Label1)
        Me.gpBoxDatosDG.Controls.Add(Me.lblIndustria)
        Me.gpBoxDatosDG.Controls.Add(Me.btnIndustria)
        Me.gpBoxDatosDG.Controls.Add(Me.txtSubnivel)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxSubsidiaria)
        Me.gpBoxDatosDG.Controls.Add(Me.txtSubsector)
        Me.gpBoxDatosDG.Controls.Add(Me.lblRazonSocial)
        Me.gpBoxDatosDG.Controls.Add(Me.lblNombreComercial)
        Me.gpBoxDatosDG.Controls.Add(Me.txtNombreComercial)
        Me.gpBoxDatosDG.Controls.Add(Me.txtIndustria)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxEmpresaPublica)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxEntidadReguladora)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxEntidadSupervisada)
        Me.gpBoxDatosDG.Controls.Add(Me.cboPais)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxReferenciaGTI)
        Me.gpBoxDatosDG.Controls.Add(Me.lblPais)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxEmpresaExtranjero)
        Me.gpBoxDatosDG.Enabled = False
        Me.gpBoxDatosDG.Location = New System.Drawing.Point(14, 80)
        Me.gpBoxDatosDG.Name = "gpBoxDatosDG"
        Me.gpBoxDatosDG.Size = New System.Drawing.Size(1060, 1534)
        Me.gpBoxDatosDG.TabIndex = 3
        Me.gpBoxDatosDG.TabStop = False
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = False
        Me.Lista.AllowUserToDeleteRows = False
        Me.Lista.AllowUserToResizeColumns = False
        Me.Lista.AllowUserToResizeRows = False
        Me.Lista.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.Lista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Lista.GridColor = System.Drawing.Color.Gainsboro
        Me.Lista.Location = New System.Drawing.Point(153, 84)
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = True
        Me.Lista.RowHeadersWidth = 25
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.Lista.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Lista.RowTemplate.Height = 26
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(771, 270)
        Me.Lista.TabIndex = 4
        Me.Lista.Visible = False
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Location = New System.Drawing.Point(153, 60)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(771, 25)
        Me.txtRazonSocial.TabIndex = 3
        '
        'lblIdSAC
        '
        Me.lblIdSAC.AutoSize = True
        Me.lblIdSAC.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSAC.Location = New System.Drawing.Point(19, 26)
        Me.lblIdSAC.Name = "lblIdSAC"
        Me.lblIdSAC.Size = New System.Drawing.Size(129, 18)
        Me.lblIdSAC.TabIndex = 0
        Me.lblIdSAC.Text = "ID Asignación SAC*:"
        '
        'txtIdSAC
        '
        Me.txtIdSAC.Location = New System.Drawing.Point(153, 23)
        Me.txtIdSAC.Name = "txtIdSAC"
        Me.txtIdSAC.Size = New System.Drawing.Size(114, 25)
        Me.txtIdSAC.TabIndex = 1
        Me.txtIdSAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gpBoxTipoNegocio
        '
        Me.gpBoxTipoNegocio.Controls.Add(Me.rdPersonaFisica)
        Me.gpBoxTipoNegocio.Controls.Add(Me.rdPersonalMoral)
        Me.gpBoxTipoNegocio.Location = New System.Drawing.Point(496, 132)
        Me.gpBoxTipoNegocio.Name = "gpBoxTipoNegocio"
        Me.gpBoxTipoNegocio.Size = New System.Drawing.Size(428, 55)
        Me.gpBoxTipoNegocio.TabIndex = 9
        Me.gpBoxTipoNegocio.TabStop = False
        Me.gpBoxTipoNegocio.Text = "Tipo de Negocio"
        '
        'rdPersonaFisica
        '
        Me.rdPersonaFisica.AutoSize = True
        Me.rdPersonaFisica.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdPersonaFisica.Location = New System.Drawing.Point(209, 24)
        Me.rdPersonaFisica.Name = "rdPersonaFisica"
        Me.rdPersonaFisica.Size = New System.Drawing.Size(110, 22)
        Me.rdPersonaFisica.TabIndex = 1
        Me.rdPersonaFisica.Text = "Persona física"
        Me.rdPersonaFisica.UseVisualStyleBackColor = True
        '
        'rdPersonalMoral
        '
        Me.rdPersonalMoral.AutoSize = True
        Me.rdPersonalMoral.Checked = True
        Me.rdPersonalMoral.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdPersonalMoral.Location = New System.Drawing.Point(65, 24)
        Me.rdPersonalMoral.Name = "rdPersonalMoral"
        Me.rdPersonalMoral.Size = New System.Drawing.Size(115, 22)
        Me.rdPersonalMoral.TabIndex = 0
        Me.rdPersonalMoral.TabStop = True
        Me.rdPersonalMoral.Text = "Persona moral"
        Me.rdPersonalMoral.UseVisualStyleBackColor = True
        '
        'gpBoxServicio
        '
        Me.gpBoxServicio.Controls.Add(Me.cboSocio)
        Me.gpBoxServicio.Controls.Add(Me.lblDatosGeneralesSocio)
        Me.gpBoxServicio.Controls.Add(Me.cboDivision)
        Me.gpBoxServicio.Controls.Add(Me.lblDivision)
        Me.gpBoxServicio.Controls.Add(Me.cboOficina)
        Me.gpBoxServicio.Controls.Add(Me.lblOficina)
        Me.gpBoxServicio.Controls.Add(Me.cboModalidades)
        Me.gpBoxServicio.Controls.Add(Me.Label7)
        Me.gpBoxServicio.Controls.Add(Me.txtFechaSolicitud)
        Me.gpBoxServicio.Controls.Add(Me.Label9)
        Me.gpBoxServicio.Controls.Add(Me.txtFechaEntregaReporte)
        Me.gpBoxServicio.Controls.Add(Me.lblFechaEntregaReporte)
        Me.gpBoxServicio.Controls.Add(Me.txtPeriodoFinal)
        Me.gpBoxServicio.Controls.Add(Me.lblPeriodoServicioA)
        Me.gpBoxServicio.Controls.Add(Me.txtPeriodoInicio)
        Me.gpBoxServicio.Controls.Add(Me.lblPeriodoServicio)
        Me.gpBoxServicio.Controls.Add(Me.GroupBox1)
        Me.gpBoxServicio.Controls.Add(Me.cboDatosGeneralesServicio)
        Me.gpBoxServicio.Controls.Add(Me.Label5)
        Me.gpBoxServicio.Controls.Add(Me.lblDescripcionSolicitud)
        Me.gpBoxServicio.Controls.Add(Me.txtDescripcionSolicitud)
        Me.gpBoxServicio.Enabled = False
        Me.gpBoxServicio.Location = New System.Drawing.Point(17, 255)
        Me.gpBoxServicio.Name = "gpBoxServicio"
        Me.gpBoxServicio.Size = New System.Drawing.Size(1022, 575)
        Me.gpBoxServicio.TabIndex = 19
        Me.gpBoxServicio.TabStop = False
        Me.gpBoxServicio.Text = "Datos del Servicio"
        '
        'cboSocio
        '
        Me.cboSocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSocio.DropDownWidth = 260
        Me.cboSocio.FormattingEnabled = True
        Me.cboSocio.Location = New System.Drawing.Point(114, 114)
        Me.cboSocio.Name = "cboSocio"
        Me.cboSocio.Size = New System.Drawing.Size(347, 26)
        Me.cboSocio.TabIndex = 5
        '
        'lblDatosGeneralesSocio
        '
        Me.lblDatosGeneralesSocio.AutoSize = True
        Me.lblDatosGeneralesSocio.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblDatosGeneralesSocio.Location = New System.Drawing.Point(40, 118)
        Me.lblDatosGeneralesSocio.Name = "lblDatosGeneralesSocio"
        Me.lblDatosGeneralesSocio.Size = New System.Drawing.Size(52, 18)
        Me.lblDatosGeneralesSocio.TabIndex = 4
        Me.lblDatosGeneralesSocio.Text = "Socio*:"
        '
        'cboDivision
        '
        Me.cboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDivision.DropDownWidth = 260
        Me.cboDivision.FormattingEnabled = True
        Me.cboDivision.Location = New System.Drawing.Point(114, 74)
        Me.cboDivision.Name = "cboDivision"
        Me.cboDivision.Size = New System.Drawing.Size(347, 26)
        Me.cboDivision.TabIndex = 3
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblDivision.Location = New System.Drawing.Point(40, 78)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(69, 18)
        Me.lblDivision.TabIndex = 2
        Me.lblDivision.Text = "División*:"
        '
        'cboOficina
        '
        Me.cboOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOficina.DropDownWidth = 260
        Me.cboOficina.FormattingEnabled = True
        Me.cboOficina.Location = New System.Drawing.Point(114, 34)
        Me.cboOficina.Name = "cboOficina"
        Me.cboOficina.Size = New System.Drawing.Size(347, 26)
        Me.cboOficina.TabIndex = 1
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblOficina.Location = New System.Drawing.Point(40, 38)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(62, 18)
        Me.lblOficina.TabIndex = 0
        Me.lblOficina.Text = "Oficina*:"
        '
        'cboModalidades
        '
        Me.cboModalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModalidades.DropDownWidth = 260
        Me.cboModalidades.FormattingEnabled = True
        Me.cboModalidades.Location = New System.Drawing.Point(471, 527)
        Me.cboModalidades.Name = "cboModalidades"
        Me.cboModalidades.Size = New System.Drawing.Size(285, 26)
        Me.cboModalidades.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.Label7.Location = New System.Drawing.Point(41, 530)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(417, 18)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Indique la modalidad en que se requiere la ejecución del trabajo*:"
        '
        'txtFechaSolicitud
        '
        Me.txtFechaSolicitud.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.txtFechaSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaSolicitud.Location = New System.Drawing.Point(471, 483)
        Me.txtFechaSolicitud.Name = "txtFechaSolicitud"
        Me.txtFechaSolicitud.Size = New System.Drawing.Size(125, 25)
        Me.txtFechaSolicitud.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.Label9.Location = New System.Drawing.Point(41, 486)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(398, 18)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Fecha en la que se solicita presentar la propuesta de servicios*:"
        '
        'txtFechaEntregaReporte
        '
        Me.txtFechaEntregaReporte.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.txtFechaEntregaReporte.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaEntregaReporte.Location = New System.Drawing.Point(471, 449)
        Me.txtFechaEntregaReporte.Name = "txtFechaEntregaReporte"
        Me.txtFechaEntregaReporte.Size = New System.Drawing.Size(125, 25)
        Me.txtFechaEntregaReporte.TabIndex = 16
        '
        'lblFechaEntregaReporte
        '
        Me.lblFechaEntregaReporte.AutoSize = True
        Me.lblFechaEntregaReporte.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblFechaEntregaReporte.Location = New System.Drawing.Point(41, 452)
        Me.lblFechaEntregaReporte.Name = "lblFechaEntregaReporte"
        Me.lblFechaEntregaReporte.Size = New System.Drawing.Size(321, 18)
        Me.lblFechaEntregaReporte.TabIndex = 15
        Me.lblFechaEntregaReporte.Text = "Fecha estimada de entrega del informe o reporte*:"
        '
        'txtPeriodoFinal
        '
        Me.txtPeriodoFinal.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.txtPeriodoFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtPeriodoFinal.Location = New System.Drawing.Point(631, 415)
        Me.txtPeriodoFinal.Name = "txtPeriodoFinal"
        Me.txtPeriodoFinal.Size = New System.Drawing.Size(125, 25)
        Me.txtPeriodoFinal.TabIndex = 14
        '
        'lblPeriodoServicioA
        '
        Me.lblPeriodoServicioA.AutoSize = True
        Me.lblPeriodoServicioA.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblPeriodoServicioA.Location = New System.Drawing.Point(604, 418)
        Me.lblPeriodoServicioA.Name = "lblPeriodoServicioA"
        Me.lblPeriodoServicioA.Size = New System.Drawing.Size(19, 18)
        Me.lblPeriodoServicioA.TabIndex = 13
        Me.lblPeriodoServicioA.Text = "al"
        '
        'txtPeriodoInicio
        '
        Me.txtPeriodoInicio.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.txtPeriodoInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtPeriodoInicio.Location = New System.Drawing.Point(471, 415)
        Me.txtPeriodoInicio.Name = "txtPeriodoInicio"
        Me.txtPeriodoInicio.Size = New System.Drawing.Size(125, 25)
        Me.txtPeriodoInicio.TabIndex = 12
        '
        'lblPeriodoServicio
        '
        Me.lblPeriodoServicio.AutoSize = True
        Me.lblPeriodoServicio.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblPeriodoServicio.Location = New System.Drawing.Point(41, 418)
        Me.lblPeriodoServicio.Name = "lblPeriodoServicio"
        Me.lblPeriodoServicio.Size = New System.Drawing.Size(272, 18)
        Me.lblPeriodoServicio.TabIndex = 11
        Me.lblPeriodoServicio.Text = "Periodo por el cual se prestará el servicio*:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboIdioma)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.rdIdiomaNo)
        Me.GroupBox1.Controls.Add(Me.rdIdiomaSi)
        Me.GroupBox1.Location = New System.Drawing.Point(43, 208)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(871, 65)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "¿Se requiere de personal bilingüe para la preparación y/o ejecución del servicio?" &
    ""
        '
        'cboIdioma
        '
        Me.cboIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIdioma.DropDownWidth = 260
        Me.cboIdioma.FormattingEnabled = True
        Me.cboIdioma.Location = New System.Drawing.Point(270, 27)
        Me.cboIdioma.Name = "cboIdioma"
        Me.cboIdioma.Size = New System.Drawing.Size(268, 26)
        Me.cboIdioma.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.Label6.Location = New System.Drawing.Point(201, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 18)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Idioma*:"
        '
        'rdIdiomaNo
        '
        Me.rdIdiomaNo.AutoSize = True
        Me.rdIdiomaNo.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdIdiomaNo.Location = New System.Drawing.Point(100, 29)
        Me.rdIdiomaNo.Name = "rdIdiomaNo"
        Me.rdIdiomaNo.Size = New System.Drawing.Size(44, 22)
        Me.rdIdiomaNo.TabIndex = 1
        Me.rdIdiomaNo.Text = "No"
        Me.rdIdiomaNo.UseVisualStyleBackColor = True
        '
        'rdIdiomaSi
        '
        Me.rdIdiomaSi.AutoSize = True
        Me.rdIdiomaSi.Checked = True
        Me.rdIdiomaSi.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdIdiomaSi.Location = New System.Drawing.Point(48, 29)
        Me.rdIdiomaSi.Name = "rdIdiomaSi"
        Me.rdIdiomaSi.Size = New System.Drawing.Size(36, 22)
        Me.rdIdiomaSi.TabIndex = 0
        Me.rdIdiomaSi.TabStop = True
        Me.rdIdiomaSi.Text = "Sí"
        Me.rdIdiomaSi.UseVisualStyleBackColor = True
        '
        'cboDatosGeneralesServicio
        '
        Me.cboDatosGeneralesServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDatosGeneralesServicio.DropDownWidth = 260
        Me.cboDatosGeneralesServicio.FormattingEnabled = True
        Me.cboDatosGeneralesServicio.Location = New System.Drawing.Point(114, 157)
        Me.cboDatosGeneralesServicio.Name = "cboDatosGeneralesServicio"
        Me.cboDatosGeneralesServicio.Size = New System.Drawing.Size(481, 26)
        Me.cboDatosGeneralesServicio.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.Label5.Location = New System.Drawing.Point(40, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 18)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Servicio*:"
        '
        'lblDescripcionSolicitud
        '
        Me.lblDescripcionSolicitud.AutoSize = True
        Me.lblDescripcionSolicitud.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionSolicitud.Location = New System.Drawing.Point(39, 291)
        Me.lblDescripcionSolicitud.Name = "lblDescripcionSolicitud"
        Me.lblDescripcionSolicitud.Size = New System.Drawing.Size(320, 18)
        Me.lblDescripcionSolicitud.TabIndex = 9
        Me.lblDescripcionSolicitud.Text = "Información adicional del cliente y/o del servicio*:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtDescripcionSolicitud
        '
        Me.txtDescripcionSolicitud.Location = New System.Drawing.Point(39, 315)
        Me.txtDescripcionSolicitud.Multiline = True
        Me.txtDescripcionSolicitud.Name = "txtDescripcionSolicitud"
        Me.txtDescripcionSolicitud.Size = New System.Drawing.Size(875, 81)
        Me.txtDescripcionSolicitud.TabIndex = 10
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.Location = New System.Drawing.Point(19, 138)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(42, 18)
        Me.lblRFC.TabIndex = 7
        Me.lblRFC.Text = "RFC*:"
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(153, 135)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(274, 25)
        Me.txtRFC.TabIndex = 8
        '
        'btnSubnivel
        '
        Me.btnSubnivel.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubnivel.Location = New System.Drawing.Point(881, 219)
        Me.btnSubnivel.Name = "btnSubnivel"
        Me.btnSubnivel.Size = New System.Drawing.Size(43, 25)
        Me.btnSubnivel.TabIndex = 18
        Me.btnSubnivel.Text = "..."
        Me.btnSubnivel.UseVisualStyleBackColor = True
        '
        'btnSubsector
        '
        Me.btnSubsector.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubsector.Location = New System.Drawing.Point(537, 219)
        Me.btnSubsector.Name = "btnSubsector"
        Me.btnSubsector.Size = New System.Drawing.Size(43, 25)
        Me.btnSubsector.TabIndex = 15
        Me.btnSubsector.Text = "..."
        Me.btnSubsector.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.Label2.Location = New System.Drawing.Point(599, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 18)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Subnivel*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.Label1.Location = New System.Drawing.Point(309, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 18)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Subsector*"
        '
        'lblIndustria
        '
        Me.lblIndustria.AutoSize = True
        Me.lblIndustria.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblIndustria.Location = New System.Drawing.Point(19, 196)
        Me.lblIndustria.Name = "lblIndustria"
        Me.lblIndustria.Size = New System.Drawing.Size(70, 18)
        Me.lblIndustria.TabIndex = 10
        Me.lblIndustria.Text = "Industria*"
        '
        'btnIndustria
        '
        Me.btnIndustria.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIndustria.Location = New System.Drawing.Point(248, 219)
        Me.btnIndustria.Name = "btnIndustria"
        Me.btnIndustria.Size = New System.Drawing.Size(43, 25)
        Me.btnIndustria.TabIndex = 12
        Me.btnIndustria.Text = "..."
        Me.btnIndustria.UseVisualStyleBackColor = True
        '
        'txtSubnivel
        '
        Me.txtSubnivel.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.txtSubnivel.Location = New System.Drawing.Point(599, 219)
        Me.txtSubnivel.Name = "txtSubnivel"
        Me.txtSubnivel.ReadOnly = True
        Me.txtSubnivel.Size = New System.Drawing.Size(277, 24)
        Me.txtSubnivel.TabIndex = 17
        '
        'gpBoxSubsidiaria
        '
        Me.gpBoxSubsidiaria.Controls.Add(Me.lblSubsidiaria)
        Me.gpBoxSubsidiaria.Controls.Add(Me.lblControladora)
        Me.gpBoxSubsidiaria.Controls.Add(Me.panRDSubsidiaria)
        Me.gpBoxSubsidiaria.Controls.Add(Me.panRDCompañiaControl)
        Me.gpBoxSubsidiaria.Location = New System.Drawing.Point(533, 890)
        Me.gpBoxSubsidiaria.Name = "gpBoxSubsidiaria"
        Me.gpBoxSubsidiaria.Size = New System.Drawing.Size(506, 112)
        Me.gpBoxSubsidiaria.TabIndex = 23
        Me.gpBoxSubsidiaria.TabStop = False
        '
        'lblSubsidiaria
        '
        Me.lblSubsidiaria.AutoSize = True
        Me.lblSubsidiaria.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblSubsidiaria.Location = New System.Drawing.Point(20, 27)
        Me.lblSubsidiaria.Name = "lblSubsidiaria"
        Me.lblSubsidiaria.Size = New System.Drawing.Size(90, 18)
        Me.lblSubsidiaria.TabIndex = 0
        Me.lblSubsidiaria.Text = "¿Subsidiaria?"
        '
        'lblControladora
        '
        Me.lblControladora.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblControladora.Location = New System.Drawing.Point(20, 57)
        Me.lblControladora.Name = "lblControladora"
        Me.lblControladora.Size = New System.Drawing.Size(163, 40)
        Me.lblControladora.TabIndex = 2
        Me.lblControladora.Text = "¿Reportará a su compañia controladora?"
        '
        'panRDSubsidiaria
        '
        Me.panRDSubsidiaria.Controls.Add(Me.rdSubsidiariaSi)
        Me.panRDSubsidiaria.Controls.Add(Me.rdSubsidiariaNo)
        Me.panRDSubsidiaria.Location = New System.Drawing.Point(192, 19)
        Me.panRDSubsidiaria.Name = "panRDSubsidiaria"
        Me.panRDSubsidiaria.Size = New System.Drawing.Size(122, 35)
        Me.panRDSubsidiaria.TabIndex = 1
        '
        'rdSubsidiariaSi
        '
        Me.rdSubsidiariaSi.AutoSize = True
        Me.rdSubsidiariaSi.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdSubsidiariaSi.Location = New System.Drawing.Point(9, 6)
        Me.rdSubsidiariaSi.Name = "rdSubsidiariaSi"
        Me.rdSubsidiariaSi.Size = New System.Drawing.Size(36, 22)
        Me.rdSubsidiariaSi.TabIndex = 0
        Me.rdSubsidiariaSi.Text = "Sí"
        Me.rdSubsidiariaSi.UseVisualStyleBackColor = True
        '
        'rdSubsidiariaNo
        '
        Me.rdSubsidiariaNo.AutoSize = True
        Me.rdSubsidiariaNo.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdSubsidiariaNo.Location = New System.Drawing.Point(62, 6)
        Me.rdSubsidiariaNo.Name = "rdSubsidiariaNo"
        Me.rdSubsidiariaNo.Size = New System.Drawing.Size(44, 22)
        Me.rdSubsidiariaNo.TabIndex = 1
        Me.rdSubsidiariaNo.Text = "No"
        Me.rdSubsidiariaNo.UseVisualStyleBackColor = True
        '
        'panRDCompañiaControl
        '
        Me.panRDCompañiaControl.Controls.Add(Me.rdControladoraSi)
        Me.panRDCompañiaControl.Controls.Add(Me.rdControladoraNO)
        Me.panRDCompañiaControl.Location = New System.Drawing.Point(192, 67)
        Me.panRDCompañiaControl.Name = "panRDCompañiaControl"
        Me.panRDCompañiaControl.Size = New System.Drawing.Size(122, 35)
        Me.panRDCompañiaControl.TabIndex = 3
        '
        'rdControladoraSi
        '
        Me.rdControladoraSi.AutoSize = True
        Me.rdControladoraSi.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdControladoraSi.Location = New System.Drawing.Point(9, 6)
        Me.rdControladoraSi.Name = "rdControladoraSi"
        Me.rdControladoraSi.Size = New System.Drawing.Size(36, 22)
        Me.rdControladoraSi.TabIndex = 0
        Me.rdControladoraSi.Text = "Sí"
        Me.rdControladoraSi.UseVisualStyleBackColor = True
        '
        'rdControladoraNO
        '
        Me.rdControladoraNO.AutoSize = True
        Me.rdControladoraNO.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdControladoraNO.Location = New System.Drawing.Point(62, 6)
        Me.rdControladoraNO.Name = "rdControladoraNO"
        Me.rdControladoraNO.Size = New System.Drawing.Size(44, 22)
        Me.rdControladoraNO.TabIndex = 1
        Me.rdControladoraNO.Text = "No"
        Me.rdControladoraNO.UseVisualStyleBackColor = True
        '
        'txtSubsector
        '
        Me.txtSubsector.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.txtSubsector.Location = New System.Drawing.Point(309, 219)
        Me.txtSubsector.Name = "txtSubsector"
        Me.txtSubsector.ReadOnly = True
        Me.txtSubsector.Size = New System.Drawing.Size(222, 24)
        Me.txtSubsector.TabIndex = 14
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblRazonSocial.Location = New System.Drawing.Point(19, 63)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(94, 18)
        Me.lblRazonSocial.TabIndex = 2
        Me.lblRazonSocial.Text = "Razón social*:"
        '
        'lblNombreComercial
        '
        Me.lblNombreComercial.AutoSize = True
        Me.lblNombreComercial.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblNombreComercial.Location = New System.Drawing.Point(19, 100)
        Me.lblNombreComercial.Name = "lblNombreComercial"
        Me.lblNombreComercial.Size = New System.Drawing.Size(133, 18)
        Me.lblNombreComercial.TabIndex = 5
        Me.lblNombreComercial.Text = "Nombre comercial*:"
        '
        'txtNombreComercial
        '
        Me.txtNombreComercial.Location = New System.Drawing.Point(153, 96)
        Me.txtNombreComercial.Name = "txtNombreComercial"
        Me.txtNombreComercial.Size = New System.Drawing.Size(771, 25)
        Me.txtNombreComercial.TabIndex = 6
        '
        'txtIndustria
        '
        Me.txtIndustria.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.txtIndustria.Location = New System.Drawing.Point(19, 219)
        Me.txtIndustria.Name = "txtIndustria"
        Me.txtIndustria.ReadOnly = True
        Me.txtIndustria.Size = New System.Drawing.Size(222, 24)
        Me.txtIndustria.TabIndex = 11
        '
        'gpBoxEmpresaPublica
        '
        Me.gpBoxEmpresaPublica.Controls.Add(Me.lblBolsaValoresOtra)
        Me.gpBoxEmpresaPublica.Controls.Add(Me.lblBolsaValores)
        Me.gpBoxEmpresaPublica.Controls.Add(Me.rdEmpresaPublicaNo)
        Me.gpBoxEmpresaPublica.Controls.Add(Me.rdEmpresaPublicaSi)
        Me.gpBoxEmpresaPublica.Controls.Add(Me.txtBolsaValoresOtro)
        Me.gpBoxEmpresaPublica.Controls.Add(Me.cboBolsaValores)
        Me.gpBoxEmpresaPublica.Location = New System.Drawing.Point(17, 890)
        Me.gpBoxEmpresaPublica.Name = "gpBoxEmpresaPublica"
        Me.gpBoxEmpresaPublica.Size = New System.Drawing.Size(506, 112)
        Me.gpBoxEmpresaPublica.TabIndex = 22
        Me.gpBoxEmpresaPublica.TabStop = False
        Me.gpBoxEmpresaPublica.Text = "Empresa pública"
        '
        'lblBolsaValoresOtra
        '
        Me.lblBolsaValoresOtra.AutoSize = True
        Me.lblBolsaValoresOtra.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblBolsaValoresOtra.Location = New System.Drawing.Point(321, 32)
        Me.lblBolsaValoresOtra.Name = "lblBolsaValoresOtra"
        Me.lblBolsaValoresOtra.Size = New System.Drawing.Size(35, 18)
        Me.lblBolsaValoresOtra.TabIndex = 4
        Me.lblBolsaValoresOtra.Text = "Otra"
        '
        'lblBolsaValores
        '
        Me.lblBolsaValores.AutoSize = True
        Me.lblBolsaValores.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblBolsaValores.Location = New System.Drawing.Point(136, 32)
        Me.lblBolsaValores.Name = "lblBolsaValores"
        Me.lblBolsaValores.Size = New System.Drawing.Size(109, 18)
        Me.lblBolsaValores.TabIndex = 2
        Me.lblBolsaValores.Text = "Bolsa de Valores"
        '
        'rdEmpresaPublicaNo
        '
        Me.rdEmpresaPublicaNo.AutoSize = True
        Me.rdEmpresaPublicaNo.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdEmpresaPublicaNo.Location = New System.Drawing.Point(63, 46)
        Me.rdEmpresaPublicaNo.Name = "rdEmpresaPublicaNo"
        Me.rdEmpresaPublicaNo.Size = New System.Drawing.Size(44, 22)
        Me.rdEmpresaPublicaNo.TabIndex = 1
        Me.rdEmpresaPublicaNo.Text = "No"
        Me.rdEmpresaPublicaNo.UseVisualStyleBackColor = True
        '
        'rdEmpresaPublicaSi
        '
        Me.rdEmpresaPublicaSi.AutoSize = True
        Me.rdEmpresaPublicaSi.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdEmpresaPublicaSi.Location = New System.Drawing.Point(18, 46)
        Me.rdEmpresaPublicaSi.Name = "rdEmpresaPublicaSi"
        Me.rdEmpresaPublicaSi.Size = New System.Drawing.Size(36, 22)
        Me.rdEmpresaPublicaSi.TabIndex = 0
        Me.rdEmpresaPublicaSi.Text = "Sí"
        Me.rdEmpresaPublicaSi.UseVisualStyleBackColor = True
        '
        'txtBolsaValoresOtro
        '
        Me.txtBolsaValoresOtro.Enabled = False
        Me.txtBolsaValoresOtro.Location = New System.Drawing.Point(321, 56)
        Me.txtBolsaValoresOtro.Name = "txtBolsaValoresOtro"
        Me.txtBolsaValoresOtro.Size = New System.Drawing.Size(163, 25)
        Me.txtBolsaValoresOtro.TabIndex = 5
        '
        'cboBolsaValores
        '
        Me.cboBolsaValores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBolsaValores.Enabled = False
        Me.cboBolsaValores.FormattingEnabled = True
        Me.cboBolsaValores.Location = New System.Drawing.Point(136, 55)
        Me.cboBolsaValores.Name = "cboBolsaValores"
        Me.cboBolsaValores.Size = New System.Drawing.Size(168, 26)
        Me.cboBolsaValores.TabIndex = 3
        '
        'gpBoxEntidadReguladora
        '
        Me.gpBoxEntidadReguladora.Controls.Add(Me.lblEntidadReguladoraOtra)
        Me.gpBoxEntidadReguladora.Controls.Add(Me.lblEntidadReguladora)
        Me.gpBoxEntidadReguladora.Controls.Add(Me.txtEntidadReguladoraOtro)
        Me.gpBoxEntidadReguladora.Controls.Add(Me.cboEntidadReguladora)
        Me.gpBoxEntidadReguladora.Controls.Add(Me.rdEntidadReguladaNo)
        Me.gpBoxEntidadReguladora.Controls.Add(Me.rdEntidadReguladaSi)
        Me.gpBoxEntidadReguladora.Location = New System.Drawing.Point(17, 1017)
        Me.gpBoxEntidadReguladora.Name = "gpBoxEntidadReguladora"
        Me.gpBoxEntidadReguladora.Size = New System.Drawing.Size(506, 89)
        Me.gpBoxEntidadReguladora.TabIndex = 24
        Me.gpBoxEntidadReguladora.TabStop = False
        Me.gpBoxEntidadReguladora.Text = "Entidad regulada"
        '
        'lblEntidadReguladoraOtra
        '
        Me.lblEntidadReguladoraOtra.AutoSize = True
        Me.lblEntidadReguladoraOtra.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblEntidadReguladoraOtra.Location = New System.Drawing.Point(321, 24)
        Me.lblEntidadReguladoraOtra.Name = "lblEntidadReguladoraOtra"
        Me.lblEntidadReguladoraOtra.Size = New System.Drawing.Size(35, 18)
        Me.lblEntidadReguladoraOtra.TabIndex = 4
        Me.lblEntidadReguladoraOtra.Text = "Otra"
        '
        'lblEntidadReguladora
        '
        Me.lblEntidadReguladora.AutoSize = True
        Me.lblEntidadReguladora.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblEntidadReguladora.Location = New System.Drawing.Point(136, 24)
        Me.lblEntidadReguladora.Name = "lblEntidadReguladora"
        Me.lblEntidadReguladora.Size = New System.Drawing.Size(127, 18)
        Me.lblEntidadReguladora.TabIndex = 2
        Me.lblEntidadReguladora.Text = "Entidad Reguladora"
        '
        'txtEntidadReguladoraOtro
        '
        Me.txtEntidadReguladoraOtro.Enabled = False
        Me.txtEntidadReguladoraOtro.Location = New System.Drawing.Point(321, 48)
        Me.txtEntidadReguladoraOtro.Name = "txtEntidadReguladoraOtro"
        Me.txtEntidadReguladoraOtro.Size = New System.Drawing.Size(163, 25)
        Me.txtEntidadReguladoraOtro.TabIndex = 5
        '
        'cboEntidadReguladora
        '
        Me.cboEntidadReguladora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntidadReguladora.DropDownWidth = 200
        Me.cboEntidadReguladora.Enabled = False
        Me.cboEntidadReguladora.FormattingEnabled = True
        Me.cboEntidadReguladora.Location = New System.Drawing.Point(136, 47)
        Me.cboEntidadReguladora.Name = "cboEntidadReguladora"
        Me.cboEntidadReguladora.Size = New System.Drawing.Size(168, 26)
        Me.cboEntidadReguladora.TabIndex = 3
        '
        'rdEntidadReguladaNo
        '
        Me.rdEntidadReguladaNo.AutoSize = True
        Me.rdEntidadReguladaNo.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdEntidadReguladaNo.Location = New System.Drawing.Point(63, 38)
        Me.rdEntidadReguladaNo.Name = "rdEntidadReguladaNo"
        Me.rdEntidadReguladaNo.Size = New System.Drawing.Size(44, 22)
        Me.rdEntidadReguladaNo.TabIndex = 1
        Me.rdEntidadReguladaNo.Text = "No"
        Me.rdEntidadReguladaNo.UseVisualStyleBackColor = True
        '
        'rdEntidadReguladaSi
        '
        Me.rdEntidadReguladaSi.AutoSize = True
        Me.rdEntidadReguladaSi.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdEntidadReguladaSi.Location = New System.Drawing.Point(18, 38)
        Me.rdEntidadReguladaSi.Name = "rdEntidadReguladaSi"
        Me.rdEntidadReguladaSi.Size = New System.Drawing.Size(36, 22)
        Me.rdEntidadReguladaSi.TabIndex = 0
        Me.rdEntidadReguladaSi.Text = "Sí"
        Me.rdEntidadReguladaSi.UseVisualStyleBackColor = True
        '
        'gpBoxEntidadSupervisada
        '
        Me.gpBoxEntidadSupervisada.Controls.Add(Me.lblEntidadSupervisadaOtra)
        Me.gpBoxEntidadSupervisada.Controls.Add(Me.lblEntidadSupervisada)
        Me.gpBoxEntidadSupervisada.Controls.Add(Me.txtEntidadSupervisadaOtro)
        Me.gpBoxEntidadSupervisada.Controls.Add(Me.cboEntidadSupervisada)
        Me.gpBoxEntidadSupervisada.Controls.Add(Me.rdEntidadSupervisadaNo)
        Me.gpBoxEntidadSupervisada.Controls.Add(Me.rdEntidadSupervisadaSi)
        Me.gpBoxEntidadSupervisada.Location = New System.Drawing.Point(533, 1017)
        Me.gpBoxEntidadSupervisada.Name = "gpBoxEntidadSupervisada"
        Me.gpBoxEntidadSupervisada.Size = New System.Drawing.Size(506, 89)
        Me.gpBoxEntidadSupervisada.TabIndex = 25
        Me.gpBoxEntidadSupervisada.TabStop = False
        Me.gpBoxEntidadSupervisada.Text = "Entidad supervisada"
        '
        'lblEntidadSupervisadaOtra
        '
        Me.lblEntidadSupervisadaOtra.AutoSize = True
        Me.lblEntidadSupervisadaOtra.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblEntidadSupervisadaOtra.Location = New System.Drawing.Point(321, 24)
        Me.lblEntidadSupervisadaOtra.Name = "lblEntidadSupervisadaOtra"
        Me.lblEntidadSupervisadaOtra.Size = New System.Drawing.Size(35, 18)
        Me.lblEntidadSupervisadaOtra.TabIndex = 4
        Me.lblEntidadSupervisadaOtra.Text = "Otra"
        '
        'lblEntidadSupervisada
        '
        Me.lblEntidadSupervisada.AutoSize = True
        Me.lblEntidadSupervisada.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblEntidadSupervisada.Location = New System.Drawing.Point(136, 24)
        Me.lblEntidadSupervisada.Name = "lblEntidadSupervisada"
        Me.lblEntidadSupervisada.Size = New System.Drawing.Size(92, 18)
        Me.lblEntidadSupervisada.TabIndex = 2
        Me.lblEntidadSupervisada.Text = "Normatividad"
        '
        'txtEntidadSupervisadaOtro
        '
        Me.txtEntidadSupervisadaOtro.Enabled = False
        Me.txtEntidadSupervisadaOtro.Location = New System.Drawing.Point(321, 48)
        Me.txtEntidadSupervisadaOtro.Name = "txtEntidadSupervisadaOtro"
        Me.txtEntidadSupervisadaOtro.Size = New System.Drawing.Size(163, 25)
        Me.txtEntidadSupervisadaOtro.TabIndex = 5
        '
        'cboEntidadSupervisada
        '
        Me.cboEntidadSupervisada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntidadSupervisada.Enabled = False
        Me.cboEntidadSupervisada.FormattingEnabled = True
        Me.cboEntidadSupervisada.Location = New System.Drawing.Point(136, 47)
        Me.cboEntidadSupervisada.Name = "cboEntidadSupervisada"
        Me.cboEntidadSupervisada.Size = New System.Drawing.Size(168, 26)
        Me.cboEntidadSupervisada.TabIndex = 3
        '
        'rdEntidadSupervisadaNo
        '
        Me.rdEntidadSupervisadaNo.AutoSize = True
        Me.rdEntidadSupervisadaNo.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdEntidadSupervisadaNo.Location = New System.Drawing.Point(63, 38)
        Me.rdEntidadSupervisadaNo.Name = "rdEntidadSupervisadaNo"
        Me.rdEntidadSupervisadaNo.Size = New System.Drawing.Size(44, 22)
        Me.rdEntidadSupervisadaNo.TabIndex = 1
        Me.rdEntidadSupervisadaNo.Text = "No"
        Me.rdEntidadSupervisadaNo.UseVisualStyleBackColor = True
        '
        'rdEntidadSupervisadaSi
        '
        Me.rdEntidadSupervisadaSi.AutoSize = True
        Me.rdEntidadSupervisadaSi.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdEntidadSupervisadaSi.Location = New System.Drawing.Point(18, 38)
        Me.rdEntidadSupervisadaSi.Name = "rdEntidadSupervisadaSi"
        Me.rdEntidadSupervisadaSi.Size = New System.Drawing.Size(36, 22)
        Me.rdEntidadSupervisadaSi.TabIndex = 0
        Me.rdEntidadSupervisadaSi.Text = "Sí"
        Me.rdEntidadSupervisadaSi.UseVisualStyleBackColor = True
        '
        'cboPais
        '
        Me.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPais.DropDownWidth = 260
        Me.cboPais.FormattingEnabled = True
        Me.cboPais.Location = New System.Drawing.Point(55, 847)
        Me.cboPais.Name = "cboPais"
        Me.cboPais.Size = New System.Drawing.Size(293, 26)
        Me.cboPais.TabIndex = 21
        '
        'gpBoxReferenciaGTI
        '
        Me.gpBoxReferenciaGTI.Controls.Add(Me.txtEstadoGTI)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.lblEstadoGTI)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.txtCorreoGerenteGTI)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.lblCorreoGerenteGTI)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.txtGerenteGTI)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.lblGerenteGTI)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.txtCorreoSocioGTI)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.lblCorreoSocioGTI)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.cboReferenciaGTIOficina)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.cboReferenciaGTIPais)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.lblReferenciaGTIPais)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.lblRefGTIOficina)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.txtReferenciaGTISocio)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.lbRefGTISocio)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.rdReferenciaGTINo)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.rdReferenciaGTISi)
        Me.gpBoxReferenciaGTI.Location = New System.Drawing.Point(17, 1121)
        Me.gpBoxReferenciaGTI.Name = "gpBoxReferenciaGTI"
        Me.gpBoxReferenciaGTI.Size = New System.Drawing.Size(1022, 191)
        Me.gpBoxReferenciaGTI.TabIndex = 26
        Me.gpBoxReferenciaGTI.TabStop = False
        Me.gpBoxReferenciaGTI.Text = "Referencia GTI"
        '
        'txtEstadoGTI
        '
        Me.txtEstadoGTI.Location = New System.Drawing.Point(734, 64)
        Me.txtEstadoGTI.Name = "txtEstadoGTI"
        Me.txtEstadoGTI.Size = New System.Drawing.Size(214, 25)
        Me.txtEstadoGTI.TabIndex = 13
        '
        'lblEstadoGTI
        '
        Me.lblEstadoGTI.AutoSize = True
        Me.lblEstadoGTI.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblEstadoGTI.Location = New System.Drawing.Point(665, 69)
        Me.lblEstadoGTI.Name = "lblEstadoGTI"
        Me.lblEstadoGTI.Size = New System.Drawing.Size(60, 18)
        Me.lblEstadoGTI.TabIndex = 12
        Me.lblEstadoGTI.Text = "Estado*:"
        '
        'txtCorreoGerenteGTI
        '
        Me.txtCorreoGerenteGTI.Location = New System.Drawing.Point(266, 137)
        Me.txtCorreoGerenteGTI.Name = "txtCorreoGerenteGTI"
        Me.txtCorreoGerenteGTI.Size = New System.Drawing.Size(358, 25)
        Me.txtCorreoGerenteGTI.TabIndex = 9
        '
        'lblCorreoGerenteGTI
        '
        Me.lblCorreoGerenteGTI.AutoSize = True
        Me.lblCorreoGerenteGTI.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblCorreoGerenteGTI.Location = New System.Drawing.Point(127, 140)
        Me.lblCorreoGerenteGTI.Name = "lblCorreoGerenteGTI"
        Me.lblCorreoGerenteGTI.Size = New System.Drawing.Size(127, 18)
        Me.lblCorreoGerenteGTI.TabIndex = 8
        Me.lblCorreoGerenteGTI.Text = "Correo electrónico:"
        '
        'txtGerenteGTI
        '
        Me.txtGerenteGTI.Location = New System.Drawing.Point(265, 101)
        Me.txtGerenteGTI.Name = "txtGerenteGTI"
        Me.txtGerenteGTI.Size = New System.Drawing.Size(358, 25)
        Me.txtGerenteGTI.TabIndex = 7
        '
        'lblGerenteGTI
        '
        Me.lblGerenteGTI.AutoSize = True
        Me.lblGerenteGTI.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblGerenteGTI.Location = New System.Drawing.Point(127, 104)
        Me.lblGerenteGTI.Name = "lblGerenteGTI"
        Me.lblGerenteGTI.Size = New System.Drawing.Size(63, 18)
        Me.lblGerenteGTI.TabIndex = 6
        Me.lblGerenteGTI.Text = "Gerente:"
        '
        'txtCorreoSocioGTI
        '
        Me.txtCorreoSocioGTI.Location = New System.Drawing.Point(265, 65)
        Me.txtCorreoSocioGTI.Name = "txtCorreoSocioGTI"
        Me.txtCorreoSocioGTI.Size = New System.Drawing.Size(358, 25)
        Me.txtCorreoSocioGTI.TabIndex = 5
        '
        'lblCorreoSocioGTI
        '
        Me.lblCorreoSocioGTI.AutoSize = True
        Me.lblCorreoSocioGTI.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblCorreoSocioGTI.Location = New System.Drawing.Point(127, 68)
        Me.lblCorreoSocioGTI.Name = "lblCorreoSocioGTI"
        Me.lblCorreoSocioGTI.Size = New System.Drawing.Size(134, 18)
        Me.lblCorreoSocioGTI.TabIndex = 4
        Me.lblCorreoSocioGTI.Text = "Correo electrónico*:"
        '
        'cboReferenciaGTIOficina
        '
        Me.cboReferenciaGTIOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReferenciaGTIOficina.FormattingEnabled = True
        Me.cboReferenciaGTIOficina.Location = New System.Drawing.Point(734, 100)
        Me.cboReferenciaGTIOficina.Name = "cboReferenciaGTIOficina"
        Me.cboReferenciaGTIOficina.Size = New System.Drawing.Size(214, 26)
        Me.cboReferenciaGTIOficina.TabIndex = 15
        '
        'cboReferenciaGTIPais
        '
        Me.cboReferenciaGTIPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReferenciaGTIPais.DropDownWidth = 260
        Me.cboReferenciaGTIPais.FormattingEnabled = True
        Me.cboReferenciaGTIPais.Location = New System.Drawing.Point(734, 28)
        Me.cboReferenciaGTIPais.Name = "cboReferenciaGTIPais"
        Me.cboReferenciaGTIPais.Size = New System.Drawing.Size(214, 26)
        Me.cboReferenciaGTIPais.TabIndex = 11
        '
        'lblReferenciaGTIPais
        '
        Me.lblReferenciaGTIPais.AutoSize = True
        Me.lblReferenciaGTIPais.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblReferenciaGTIPais.Location = New System.Drawing.Point(665, 32)
        Me.lblReferenciaGTIPais.Name = "lblReferenciaGTIPais"
        Me.lblReferenciaGTIPais.Size = New System.Drawing.Size(43, 18)
        Me.lblReferenciaGTIPais.TabIndex = 10
        Me.lblReferenciaGTIPais.Text = "País*:"
        '
        'lblRefGTIOficina
        '
        Me.lblRefGTIOficina.AutoSize = True
        Me.lblRefGTIOficina.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblRefGTIOficina.Location = New System.Drawing.Point(665, 104)
        Me.lblRefGTIOficina.Name = "lblRefGTIOficina"
        Me.lblRefGTIOficina.Size = New System.Drawing.Size(62, 18)
        Me.lblRefGTIOficina.TabIndex = 14
        Me.lblRefGTIOficina.Text = "Oficina*:"
        '
        'txtReferenciaGTISocio
        '
        Me.txtReferenciaGTISocio.Location = New System.Drawing.Point(264, 29)
        Me.txtReferenciaGTISocio.Name = "txtReferenciaGTISocio"
        Me.txtReferenciaGTISocio.Size = New System.Drawing.Size(358, 25)
        Me.txtReferenciaGTISocio.TabIndex = 3
        '
        'lbRefGTISocio
        '
        Me.lbRefGTISocio.AutoSize = True
        Me.lbRefGTISocio.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lbRefGTISocio.Location = New System.Drawing.Point(127, 32)
        Me.lbRefGTISocio.Name = "lbRefGTISocio"
        Me.lbRefGTISocio.Size = New System.Drawing.Size(52, 18)
        Me.lbRefGTISocio.TabIndex = 2
        Me.lbRefGTISocio.Text = "Socio*:"
        '
        'rdReferenciaGTINo
        '
        Me.rdReferenciaGTINo.AutoSize = True
        Me.rdReferenciaGTINo.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdReferenciaGTINo.Location = New System.Drawing.Point(63, 84)
        Me.rdReferenciaGTINo.Name = "rdReferenciaGTINo"
        Me.rdReferenciaGTINo.Size = New System.Drawing.Size(44, 22)
        Me.rdReferenciaGTINo.TabIndex = 1
        Me.rdReferenciaGTINo.Text = "No"
        Me.rdReferenciaGTINo.UseVisualStyleBackColor = True
        '
        'rdReferenciaGTISi
        '
        Me.rdReferenciaGTISi.AutoSize = True
        Me.rdReferenciaGTISi.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdReferenciaGTISi.Location = New System.Drawing.Point(18, 84)
        Me.rdReferenciaGTISi.Name = "rdReferenciaGTISi"
        Me.rdReferenciaGTISi.Size = New System.Drawing.Size(36, 22)
        Me.rdReferenciaGTISi.TabIndex = 0
        Me.rdReferenciaGTISi.Text = "Sí"
        Me.rdReferenciaGTISi.UseVisualStyleBackColor = True
        '
        'lblPais
        '
        Me.lblPais.AutoSize = True
        Me.lblPais.Location = New System.Drawing.Point(17, 851)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(37, 18)
        Me.lblPais.TabIndex = 20
        Me.lblPais.Text = "País:"
        '
        'gpBoxEmpresaExtranjero
        '
        Me.gpBoxEmpresaExtranjero.Controls.Add(Me.panRDDomExt)
        Me.gpBoxEmpresaExtranjero.Controls.Add(Me.panRDSubExt)
        Me.gpBoxEmpresaExtranjero.Controls.Add(Me.lblDomicilioExtranjero)
        Me.gpBoxEmpresaExtranjero.Controls.Add(Me.cboTipoEntidad)
        Me.gpBoxEmpresaExtranjero.Controls.Add(Me.lblTipoEntidad)
        Me.gpBoxEmpresaExtranjero.Controls.Add(Me.lblCompañiaSubsidiaria)
        Me.gpBoxEmpresaExtranjero.Controls.Add(Me.cboPaisResidencia)
        Me.gpBoxEmpresaExtranjero.Controls.Add(Me.lblReporteExtranjero)
        Me.gpBoxEmpresaExtranjero.Controls.Add(Me.lblPaisResidencia)
        Me.gpBoxEmpresaExtranjero.Controls.Add(Me.txtEmpresaTenedora)
        Me.gpBoxEmpresaExtranjero.Controls.Add(Me.lblEmpresaTenedora)
        Me.gpBoxEmpresaExtranjero.Controls.Add(Me.panRDRepExt)
        Me.gpBoxEmpresaExtranjero.Location = New System.Drawing.Point(17, 1324)
        Me.gpBoxEmpresaExtranjero.Name = "gpBoxEmpresaExtranjero"
        Me.gpBoxEmpresaExtranjero.Size = New System.Drawing.Size(1022, 193)
        Me.gpBoxEmpresaExtranjero.TabIndex = 27
        Me.gpBoxEmpresaExtranjero.TabStop = False
        Me.gpBoxEmpresaExtranjero.Text = "Empresa en el Extranjero"
        '
        'panRDDomExt
        '
        Me.panRDDomExt.Controls.Add(Me.rdEmpresaExtranjeroDomSi)
        Me.panRDDomExt.Controls.Add(Me.rdEmpresaExtranjeroDomNo)
        Me.panRDDomExt.Location = New System.Drawing.Point(286, 87)
        Me.panRDDomExt.Name = "panRDDomExt"
        Me.panRDDomExt.Size = New System.Drawing.Size(122, 35)
        Me.panRDDomExt.TabIndex = 3
        '
        'rdEmpresaExtranjeroDomSi
        '
        Me.rdEmpresaExtranjeroDomSi.AutoSize = True
        Me.rdEmpresaExtranjeroDomSi.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdEmpresaExtranjeroDomSi.Location = New System.Drawing.Point(9, 6)
        Me.rdEmpresaExtranjeroDomSi.Name = "rdEmpresaExtranjeroDomSi"
        Me.rdEmpresaExtranjeroDomSi.Size = New System.Drawing.Size(36, 22)
        Me.rdEmpresaExtranjeroDomSi.TabIndex = 0
        Me.rdEmpresaExtranjeroDomSi.Text = "Sí"
        Me.rdEmpresaExtranjeroDomSi.UseVisualStyleBackColor = True
        '
        'rdEmpresaExtranjeroDomNo
        '
        Me.rdEmpresaExtranjeroDomNo.AutoSize = True
        Me.rdEmpresaExtranjeroDomNo.Checked = True
        Me.rdEmpresaExtranjeroDomNo.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdEmpresaExtranjeroDomNo.Location = New System.Drawing.Point(62, 6)
        Me.rdEmpresaExtranjeroDomNo.Name = "rdEmpresaExtranjeroDomNo"
        Me.rdEmpresaExtranjeroDomNo.Size = New System.Drawing.Size(44, 22)
        Me.rdEmpresaExtranjeroDomNo.TabIndex = 1
        Me.rdEmpresaExtranjeroDomNo.TabStop = True
        Me.rdEmpresaExtranjeroDomNo.Text = "No"
        Me.rdEmpresaExtranjeroDomNo.UseVisualStyleBackColor = True
        '
        'panRDSubExt
        '
        Me.panRDSubExt.Controls.Add(Me.rdEmpresaExtranjeroSubSi)
        Me.panRDSubExt.Controls.Add(Me.rdEmpresaExtranjeroSubNo)
        Me.panRDSubExt.Location = New System.Drawing.Point(286, 144)
        Me.panRDSubExt.Name = "panRDSubExt"
        Me.panRDSubExt.Size = New System.Drawing.Size(122, 35)
        Me.panRDSubExt.TabIndex = 5
        '
        'rdEmpresaExtranjeroSubSi
        '
        Me.rdEmpresaExtranjeroSubSi.AutoSize = True
        Me.rdEmpresaExtranjeroSubSi.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdEmpresaExtranjeroSubSi.Location = New System.Drawing.Point(9, 6)
        Me.rdEmpresaExtranjeroSubSi.Name = "rdEmpresaExtranjeroSubSi"
        Me.rdEmpresaExtranjeroSubSi.Size = New System.Drawing.Size(36, 22)
        Me.rdEmpresaExtranjeroSubSi.TabIndex = 0
        Me.rdEmpresaExtranjeroSubSi.Text = "Sí"
        Me.rdEmpresaExtranjeroSubSi.UseVisualStyleBackColor = True
        '
        'rdEmpresaExtranjeroSubNo
        '
        Me.rdEmpresaExtranjeroSubNo.AutoSize = True
        Me.rdEmpresaExtranjeroSubNo.Checked = True
        Me.rdEmpresaExtranjeroSubNo.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdEmpresaExtranjeroSubNo.Location = New System.Drawing.Point(62, 6)
        Me.rdEmpresaExtranjeroSubNo.Name = "rdEmpresaExtranjeroSubNo"
        Me.rdEmpresaExtranjeroSubNo.Size = New System.Drawing.Size(44, 22)
        Me.rdEmpresaExtranjeroSubNo.TabIndex = 1
        Me.rdEmpresaExtranjeroSubNo.TabStop = True
        Me.rdEmpresaExtranjeroSubNo.Text = "No"
        Me.rdEmpresaExtranjeroSubNo.UseVisualStyleBackColor = True
        '
        'lblDomicilioExtranjero
        '
        Me.lblDomicilioExtranjero.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblDomicilioExtranjero.Location = New System.Drawing.Point(10, 86)
        Me.lblDomicilioExtranjero.Name = "lblDomicilioExtranjero"
        Me.lblDomicilioExtranjero.Size = New System.Drawing.Size(270, 36)
        Me.lblDomicilioExtranjero.TabIndex = 2
        Me.lblDomicilioExtranjero.Text = "¿Domiciliada en el extranjero con emisión de informe en México?"
        Me.lblDomicilioExtranjero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoEntidad
        '
        Me.cboTipoEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoEntidad.FormattingEnabled = True
        Me.cboTipoEntidad.Location = New System.Drawing.Point(677, 100)
        Me.cboTipoEntidad.Name = "cboTipoEntidad"
        Me.cboTipoEntidad.Size = New System.Drawing.Size(212, 26)
        Me.cboTipoEntidad.TabIndex = 11
        '
        'lblTipoEntidad
        '
        Me.lblTipoEntidad.AutoSize = True
        Me.lblTipoEntidad.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblTipoEntidad.Location = New System.Drawing.Point(677, 77)
        Me.lblTipoEntidad.Name = "lblTipoEntidad"
        Me.lblTipoEntidad.Size = New System.Drawing.Size(104, 18)
        Me.lblTipoEntidad.TabIndex = 10
        Me.lblTipoEntidad.Text = "Tipo de entidad"
        '
        'lblCompañiaSubsidiaria
        '
        Me.lblCompañiaSubsidiaria.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblCompañiaSubsidiaria.Location = New System.Drawing.Point(10, 143)
        Me.lblCompañiaSubsidiaria.Name = "lblCompañiaSubsidiaria"
        Me.lblCompañiaSubsidiaria.Size = New System.Drawing.Size(270, 36)
        Me.lblCompañiaSubsidiaria.TabIndex = 4
        Me.lblCompañiaSubsidiaria.Text = "¿Compañia en México con subsidiarias en el extranjero?"
        '
        'cboPaisResidencia
        '
        Me.cboPaisResidencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaisResidencia.DropDownWidth = 260
        Me.cboPaisResidencia.FormattingEnabled = True
        Me.cboPaisResidencia.Location = New System.Drawing.Point(450, 100)
        Me.cboPaisResidencia.Name = "cboPaisResidencia"
        Me.cboPaisResidencia.Size = New System.Drawing.Size(212, 26)
        Me.cboPaisResidencia.TabIndex = 9
        '
        'lblReporteExtranjero
        '
        Me.lblReporteExtranjero.AutoSize = True
        Me.lblReporteExtranjero.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblReporteExtranjero.Location = New System.Drawing.Point(10, 38)
        Me.lblReporteExtranjero.Name = "lblReporteExtranjero"
        Me.lblReporteExtranjero.Size = New System.Drawing.Size(229, 18)
        Me.lblReporteExtranjero.TabIndex = 0
        Me.lblReporteExtranjero.Text = "¿La compañia reporta al extranjero?"
        '
        'lblPaisResidencia
        '
        Me.lblPaisResidencia.AutoSize = True
        Me.lblPaisResidencia.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblPaisResidencia.Location = New System.Drawing.Point(450, 82)
        Me.lblPaisResidencia.Name = "lblPaisResidencia"
        Me.lblPaisResidencia.Size = New System.Drawing.Size(102, 18)
        Me.lblPaisResidencia.TabIndex = 8
        Me.lblPaisResidencia.Text = "País Residencia"
        '
        'txtEmpresaTenedora
        '
        Me.txtEmpresaTenedora.Location = New System.Drawing.Point(450, 45)
        Me.txtEmpresaTenedora.Name = "txtEmpresaTenedora"
        Me.txtEmpresaTenedora.Size = New System.Drawing.Size(439, 25)
        Me.txtEmpresaTenedora.TabIndex = 7
        '
        'lblEmpresaTenedora
        '
        Me.lblEmpresaTenedora.AutoSize = True
        Me.lblEmpresaTenedora.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblEmpresaTenedora.Location = New System.Drawing.Point(450, 27)
        Me.lblEmpresaTenedora.Name = "lblEmpresaTenedora"
        Me.lblEmpresaTenedora.Size = New System.Drawing.Size(122, 18)
        Me.lblEmpresaTenedora.TabIndex = 6
        Me.lblEmpresaTenedora.Text = "Empresa Tenedora"
        '
        'panRDRepExt
        '
        Me.panRDRepExt.Controls.Add(Me.rdEmpresaExtranjeroRepSi)
        Me.panRDRepExt.Controls.Add(Me.rdEmpresaExtranjeroRepNo)
        Me.panRDRepExt.Location = New System.Drawing.Point(286, 30)
        Me.panRDRepExt.Name = "panRDRepExt"
        Me.panRDRepExt.Size = New System.Drawing.Size(122, 35)
        Me.panRDRepExt.TabIndex = 1
        '
        'rdEmpresaExtranjeroRepSi
        '
        Me.rdEmpresaExtranjeroRepSi.AutoSize = True
        Me.rdEmpresaExtranjeroRepSi.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdEmpresaExtranjeroRepSi.Location = New System.Drawing.Point(9, 6)
        Me.rdEmpresaExtranjeroRepSi.Name = "rdEmpresaExtranjeroRepSi"
        Me.rdEmpresaExtranjeroRepSi.Size = New System.Drawing.Size(36, 22)
        Me.rdEmpresaExtranjeroRepSi.TabIndex = 0
        Me.rdEmpresaExtranjeroRepSi.Text = "Sí"
        Me.rdEmpresaExtranjeroRepSi.UseVisualStyleBackColor = True
        '
        'rdEmpresaExtranjeroRepNo
        '
        Me.rdEmpresaExtranjeroRepNo.AutoSize = True
        Me.rdEmpresaExtranjeroRepNo.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdEmpresaExtranjeroRepNo.Location = New System.Drawing.Point(62, 6)
        Me.rdEmpresaExtranjeroRepNo.Name = "rdEmpresaExtranjeroRepNo"
        Me.rdEmpresaExtranjeroRepNo.Size = New System.Drawing.Size(44, 22)
        Me.rdEmpresaExtranjeroRepNo.TabIndex = 1
        Me.rdEmpresaExtranjeroRepNo.Text = "No"
        Me.rdEmpresaExtranjeroRepNo.UseVisualStyleBackColor = True
        '
        'lblMensajeCargaDatosGenerales
        '
        Me.lblMensajeCargaDatosGenerales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMensajeCargaDatosGenerales.BackColor = System.Drawing.Color.DarkSalmon
        Me.lblMensajeCargaDatosGenerales.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeCargaDatosGenerales.ForeColor = System.Drawing.Color.White
        Me.lblMensajeCargaDatosGenerales.Location = New System.Drawing.Point(0, 44)
        Me.lblMensajeCargaDatosGenerales.Name = "lblMensajeCargaDatosGenerales"
        Me.lblMensajeCargaDatosGenerales.Size = New System.Drawing.Size(1106, 25)
        Me.lblMensajeCargaDatosGenerales.TabIndex = 2
        Me.lblMensajeCargaDatosGenerales.Text = "No se ha cargado información de los Datos Generales para el prospecto."
        Me.lblMensajeCargaDatosGenerales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeCargaDatosGenerales.Visible = False
        '
        'panLinea
        '
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(19, 34)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(300, 3)
        Me.panLinea.TabIndex = 1
        '
        'lblTituloDatosGenerales
        '
        Me.lblTituloDatosGenerales.AutoSize = True
        Me.lblTituloDatosGenerales.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloDatosGenerales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloDatosGenerales.Location = New System.Drawing.Point(19, 4)
        Me.lblTituloDatosGenerales.Name = "lblTituloDatosGenerales"
        Me.lblTituloDatosGenerales.Size = New System.Drawing.Size(200, 29)
        Me.lblTituloDatosGenerales.TabIndex = 0
        Me.lblTituloDatosGenerales.Text = "DATOS GENERALES"
        '
        'btnRegistroDatosGenerales
        '
        Me.btnRegistroDatosGenerales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRegistroDatosGenerales.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistroDatosGenerales.Location = New System.Drawing.Point(227, 668)
        Me.btnRegistroDatosGenerales.Name = "btnRegistroDatosGenerales"
        Me.btnRegistroDatosGenerales.Size = New System.Drawing.Size(130, 25)
        Me.btnRegistroDatosGenerales.TabIndex = 2
        Me.btnRegistroDatosGenerales.Text = "Habilitar"
        Me.btnRegistroDatosGenerales.UseVisualStyleBackColor = True
        '
        'panContactoInicial
        '
        Me.panContactoInicial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panContactoInicial.BackColor = System.Drawing.Color.White
        Me.panContactoInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panContactoInicial.Controls.Add(Me.lblMensajeCargaContactoInicial)
        Me.panContactoInicial.Controls.Add(Me.Panel1)
        Me.panContactoInicial.Controls.Add(Me.lblTituloCI)
        Me.panContactoInicial.Controls.Add(Me.panDatosContactoInicial)
        Me.panContactoInicial.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.panContactoInicial.Location = New System.Drawing.Point(212, 0)
        Me.panContactoInicial.Name = "panContactoInicial"
        Me.panContactoInicial.Size = New System.Drawing.Size(1106, 660)
        Me.panContactoInicial.TabIndex = 0
        Me.panContactoInicial.Tag = "2"
        Me.panContactoInicial.Visible = False
        '
        'lblMensajeCargaContactoInicial
        '
        Me.lblMensajeCargaContactoInicial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMensajeCargaContactoInicial.BackColor = System.Drawing.Color.DarkSalmon
        Me.lblMensajeCargaContactoInicial.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeCargaContactoInicial.ForeColor = System.Drawing.Color.White
        Me.lblMensajeCargaContactoInicial.Location = New System.Drawing.Point(0, 44)
        Me.lblMensajeCargaContactoInicial.Name = "lblMensajeCargaContactoInicial"
        Me.lblMensajeCargaContactoInicial.Size = New System.Drawing.Size(1104, 25)
        Me.lblMensajeCargaContactoInicial.TabIndex = 2
        Me.lblMensajeCargaContactoInicial.Text = "No se ha cargado información de Contacto Inicial para el prospecto."
        Me.lblMensajeCargaContactoInicial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeCargaContactoInicial.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(19, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 3)
        Me.Panel1.TabIndex = 1
        '
        'lblTituloCI
        '
        Me.lblTituloCI.AutoSize = True
        Me.lblTituloCI.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloCI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloCI.Location = New System.Drawing.Point(19, 4)
        Me.lblTituloCI.Name = "lblTituloCI"
        Me.lblTituloCI.Size = New System.Drawing.Size(200, 29)
        Me.lblTituloCI.TabIndex = 0
        Me.lblTituloCI.Text = "CONTACTO INICIAL"
        '
        'panDatosContactoInicial
        '
        Me.panDatosContactoInicial.Controls.Add(Me.lblContactoInicialObligatorios)
        Me.panDatosContactoInicial.Controls.Add(Me.lblTituloDatosContacto)
        Me.panDatosContactoInicial.Controls.Add(Me.txtContactoInicialFecha)
        Me.panDatosContactoInicial.Controls.Add(Me.lblContactoInicialFecha)
        Me.panDatosContactoInicial.Controls.Add(Me.lblContactoInicialPrimeraPersona)
        Me.panDatosContactoInicial.Controls.Add(Me.txtContactoInicialPrimerContacto)
        Me.panDatosContactoInicial.Controls.Add(Me.gpBoxDatosContactoInicial)
        Me.panDatosContactoInicial.Enabled = False
        Me.panDatosContactoInicial.Location = New System.Drawing.Point(21, 88)
        Me.panDatosContactoInicial.Name = "panDatosContactoInicial"
        Me.panDatosContactoInicial.Size = New System.Drawing.Size(1038, 534)
        Me.panDatosContactoInicial.TabIndex = 12
        '
        'lblContactoInicialObligatorios
        '
        Me.lblContactoInicialObligatorios.AutoSize = True
        Me.lblContactoInicialObligatorios.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Italic)
        Me.lblContactoInicialObligatorios.Location = New System.Drawing.Point(11, 480)
        Me.lblContactoInicialObligatorios.Name = "lblContactoInicialObligatorios"
        Me.lblContactoInicialObligatorios.Size = New System.Drawing.Size(266, 17)
        Me.lblContactoInicialObligatorios.TabIndex = 12
        Me.lblContactoInicialObligatorios.Text = "Los campos marcados con (*) son obligatorios."
        '
        'lblTituloDatosContacto
        '
        Me.lblTituloDatosContacto.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.lblTituloDatosContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTituloDatosContacto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloDatosContacto.ForeColor = System.Drawing.Color.White
        Me.lblTituloDatosContacto.Location = New System.Drawing.Point(11, 142)
        Me.lblTituloDatosContacto.Name = "lblTituloDatosContacto"
        Me.lblTituloDatosContacto.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.lblTituloDatosContacto.Size = New System.Drawing.Size(1015, 23)
        Me.lblTituloDatosContacto.TabIndex = 7
        Me.lblTituloDatosContacto.Text = "Datos de Contacto"
        Me.lblTituloDatosContacto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContactoInicialFecha
        '
        Me.txtContactoInicialFecha.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.txtContactoInicialFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtContactoInicialFecha.Location = New System.Drawing.Point(184, 18)
        Me.txtContactoInicialFecha.Name = "txtContactoInicialFecha"
        Me.txtContactoInicialFecha.Size = New System.Drawing.Size(125, 25)
        Me.txtContactoInicialFecha.TabIndex = 4
        '
        'lblContactoInicialFecha
        '
        Me.lblContactoInicialFecha.AutoSize = True
        Me.lblContactoInicialFecha.Location = New System.Drawing.Point(10, 21)
        Me.lblContactoInicialFecha.Name = "lblContactoInicialFecha"
        Me.lblContactoInicialFecha.Size = New System.Drawing.Size(163, 18)
        Me.lblContactoInicialFecha.TabIndex = 3
        Me.lblContactoInicialFecha.Text = "Fecha del contacto inicial"
        '
        'lblContactoInicialPrimeraPersona
        '
        Me.lblContactoInicialPrimeraPersona.AutoSize = True
        Me.lblContactoInicialPrimeraPersona.Location = New System.Drawing.Point(11, 67)
        Me.lblContactoInicialPrimeraPersona.Name = "lblContactoInicialPrimeraPersona"
        Me.lblContactoInicialPrimeraPersona.Size = New System.Drawing.Size(239, 18)
        Me.lblContactoInicialPrimeraPersona.TabIndex = 5
        Me.lblContactoInicialPrimeraPersona.Text = "Persona que tuvo el primer contacto*"
        '
        'txtContactoInicialPrimerContacto
        '
        Me.txtContactoInicialPrimerContacto.Location = New System.Drawing.Point(11, 93)
        Me.txtContactoInicialPrimerContacto.Name = "txtContactoInicialPrimerContacto"
        Me.txtContactoInicialPrimerContacto.Size = New System.Drawing.Size(1015, 25)
        Me.txtContactoInicialPrimerContacto.TabIndex = 6
        '
        'gpBoxDatosContactoInicial
        '
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.txtContactoInicialCelular)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.Label3)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.lblAcercamientoWebProspecto)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.lblContactoInicialNombre)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.txtAcercamientoWebProspecto)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.txtContactoInicialExtension)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.txtContactoInicialNombre)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.lblContactoInicialExtension)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.lblContactoInicialCargo)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.txtContactoInicialTelefono)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.txtContactoInicialCargo)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.lblContactoInicialTelefono)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.lblContactoInicialCorreo)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.txtContactoInicialCorreo)
        Me.gpBoxDatosContactoInicial.Location = New System.Drawing.Point(11, 142)
        Me.gpBoxDatosContactoInicial.Name = "gpBoxDatosContactoInicial"
        Me.gpBoxDatosContactoInicial.Size = New System.Drawing.Size(1015, 332)
        Me.gpBoxDatosContactoInicial.TabIndex = 8
        Me.gpBoxDatosContactoInicial.TabStop = False
        '
        'txtContactoInicialCelular
        '
        Me.txtContactoInicialCelular.Location = New System.Drawing.Point(380, 202)
        Me.txtContactoInicialCelular.Name = "txtContactoInicialCelular"
        Me.txtContactoInicialCelular.Size = New System.Drawing.Size(189, 25)
        Me.txtContactoInicialCelular.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(380, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 18)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Teléfono celular*"
        '
        'lblAcercamientoWebProspecto
        '
        Me.lblAcercamientoWebProspecto.AutoSize = True
        Me.lblAcercamientoWebProspecto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcercamientoWebProspecto.Location = New System.Drawing.Point(55, 245)
        Me.lblAcercamientoWebProspecto.Name = "lblAcercamientoWebProspecto"
        Me.lblAcercamientoWebProspecto.Size = New System.Drawing.Size(167, 18)
        Me.lblAcercamientoWebProspecto.TabIndex = 12
        Me.lblAcercamientoWebProspecto.Text = "Página web del prospecto"
        '
        'lblContactoInicialNombre
        '
        Me.lblContactoInicialNombre.AutoSize = True
        Me.lblContactoInicialNombre.Location = New System.Drawing.Point(55, 51)
        Me.lblContactoInicialNombre.Name = "lblContactoInicialNombre"
        Me.lblContactoInicialNombre.Size = New System.Drawing.Size(82, 18)
        Me.lblContactoInicialNombre.TabIndex = 0
        Me.lblContactoInicialNombre.Text = "Nombre(s)*"
        '
        'txtAcercamientoWebProspecto
        '
        Me.txtAcercamientoWebProspecto.Location = New System.Drawing.Point(55, 269)
        Me.txtAcercamientoWebProspecto.Name = "txtAcercamientoWebProspecto"
        Me.txtAcercamientoWebProspecto.Size = New System.Drawing.Size(898, 25)
        Me.txtAcercamientoWebProspecto.TabIndex = 13
        '
        'txtContactoInicialExtension
        '
        Me.txtContactoInicialExtension.Location = New System.Drawing.Point(254, 202)
        Me.txtContactoInicialExtension.Name = "txtContactoInicialExtension"
        Me.txtContactoInicialExtension.Size = New System.Drawing.Size(92, 25)
        Me.txtContactoInicialExtension.TabIndex = 9
        '
        'txtContactoInicialNombre
        '
        Me.txtContactoInicialNombre.Location = New System.Drawing.Point(55, 74)
        Me.txtContactoInicialNombre.Name = "txtContactoInicialNombre"
        Me.txtContactoInicialNombre.Size = New System.Drawing.Size(898, 25)
        Me.txtContactoInicialNombre.TabIndex = 1
        '
        'lblContactoInicialExtension
        '
        Me.lblContactoInicialExtension.AutoSize = True
        Me.lblContactoInicialExtension.Location = New System.Drawing.Point(254, 178)
        Me.lblContactoInicialExtension.Name = "lblContactoInicialExtension"
        Me.lblContactoInicialExtension.Size = New System.Drawing.Size(69, 18)
        Me.lblContactoInicialExtension.TabIndex = 8
        Me.lblContactoInicialExtension.Text = "Extensión"
        '
        'lblContactoInicialCargo
        '
        Me.lblContactoInicialCargo.AutoSize = True
        Me.lblContactoInicialCargo.Location = New System.Drawing.Point(596, 113)
        Me.lblContactoInicialCargo.Name = "lblContactoInicialCargo"
        Me.lblContactoInicialCargo.Size = New System.Drawing.Size(146, 18)
        Me.lblContactoInicialCargo.TabIndex = 4
        Me.lblContactoInicialCargo.Text = "Cargo en la compañia*"
        '
        'txtContactoInicialTelefono
        '
        Me.txtContactoInicialTelefono.Location = New System.Drawing.Point(55, 202)
        Me.txtContactoInicialTelefono.Name = "txtContactoInicialTelefono"
        Me.txtContactoInicialTelefono.Size = New System.Drawing.Size(189, 25)
        Me.txtContactoInicialTelefono.TabIndex = 7
        '
        'txtContactoInicialCargo
        '
        Me.txtContactoInicialCargo.Location = New System.Drawing.Point(596, 136)
        Me.txtContactoInicialCargo.Name = "txtContactoInicialCargo"
        Me.txtContactoInicialCargo.Size = New System.Drawing.Size(357, 25)
        Me.txtContactoInicialCargo.TabIndex = 5
        '
        'lblContactoInicialTelefono
        '
        Me.lblContactoInicialTelefono.AutoSize = True
        Me.lblContactoInicialTelefono.Location = New System.Drawing.Point(55, 179)
        Me.lblContactoInicialTelefono.Name = "lblContactoInicialTelefono"
        Me.lblContactoInicialTelefono.Size = New System.Drawing.Size(114, 18)
        Me.lblContactoInicialTelefono.TabIndex = 6
        Me.lblContactoInicialTelefono.Text = "Teléfono oficina*"
        '
        'lblContactoInicialCorreo
        '
        Me.lblContactoInicialCorreo.AutoSize = True
        Me.lblContactoInicialCorreo.Location = New System.Drawing.Point(55, 113)
        Me.lblContactoInicialCorreo.Name = "lblContactoInicialCorreo"
        Me.lblContactoInicialCorreo.Size = New System.Drawing.Size(130, 18)
        Me.lblContactoInicialCorreo.TabIndex = 2
        Me.lblContactoInicialCorreo.Text = "Correo electrónico*"
        '
        'txtContactoInicialCorreo
        '
        Me.txtContactoInicialCorreo.Location = New System.Drawing.Point(55, 136)
        Me.txtContactoInicialCorreo.Name = "txtContactoInicialCorreo"
        Me.txtContactoInicialCorreo.Size = New System.Drawing.Size(514, 25)
        Me.txtContactoInicialCorreo.TabIndex = 3
        '
        'panAcercamiento
        '
        Me.panAcercamiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panAcercamiento.BackColor = System.Drawing.Color.White
        Me.panAcercamiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panAcercamiento.Controls.Add(Me.Label4)
        Me.panAcercamiento.Controls.Add(Me.lblMensajeCargaAcercamiento)
        Me.panAcercamiento.Controls.Add(Me.lblMensajeErrorAcercamiento)
        Me.panAcercamiento.Controls.Add(Me.gpBoxDatosAcercamiento)
        Me.panAcercamiento.Controls.Add(Me.Panel2)
        Me.panAcercamiento.Controls.Add(Me.lblTituloAcercamiento)
        Me.panAcercamiento.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panAcercamiento.Location = New System.Drawing.Point(212, 0)
        Me.panAcercamiento.Name = "panAcercamiento"
        Me.panAcercamiento.Size = New System.Drawing.Size(1106, 660)
        Me.panAcercamiento.TabIndex = 6
        Me.panAcercamiento.Tag = "3"
        Me.panAcercamiento.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Italic)
        Me.Label4.Location = New System.Drawing.Point(91, 371)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(266, 17)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Los campos marcados con (*) son obligatorios."
        '
        'lblMensajeCargaAcercamiento
        '
        Me.lblMensajeCargaAcercamiento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMensajeCargaAcercamiento.BackColor = System.Drawing.Color.DarkSalmon
        Me.lblMensajeCargaAcercamiento.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeCargaAcercamiento.ForeColor = System.Drawing.Color.White
        Me.lblMensajeCargaAcercamiento.Location = New System.Drawing.Point(0, 44)
        Me.lblMensajeCargaAcercamiento.Name = "lblMensajeCargaAcercamiento"
        Me.lblMensajeCargaAcercamiento.Size = New System.Drawing.Size(1104, 25)
        Me.lblMensajeCargaAcercamiento.TabIndex = 11
        Me.lblMensajeCargaAcercamiento.Text = "No se ha cargado información de Acercamiento para el prospecto."
        Me.lblMensajeCargaAcercamiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeCargaAcercamiento.Visible = False
        '
        'lblMensajeErrorAcercamiento
        '
        Me.lblMensajeErrorAcercamiento.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lblMensajeErrorAcercamiento.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMensajeErrorAcercamiento.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeErrorAcercamiento.ForeColor = System.Drawing.Color.White
        Me.lblMensajeErrorAcercamiento.Location = New System.Drawing.Point(0, 633)
        Me.lblMensajeErrorAcercamiento.Name = "lblMensajeErrorAcercamiento"
        Me.lblMensajeErrorAcercamiento.Size = New System.Drawing.Size(1104, 25)
        Me.lblMensajeErrorAcercamiento.TabIndex = 4
        Me.lblMensajeErrorAcercamiento.Text = "Mensaje de error"
        Me.lblMensajeErrorAcercamiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeErrorAcercamiento.Visible = False
        '
        'gpBoxDatosAcercamiento
        '
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblMedioContactoOtro)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblAcercamientoOtro)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.cboAcercamientoMedioContacto)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblAcercamientoComoEntero)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.txtAcercamientoEnteroOtro)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.cboAcercamientoComoEntero)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblAcercamientoMedioContacto)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.txtAcercamientoContactoOtro)
        Me.gpBoxDatosAcercamiento.Enabled = False
        Me.gpBoxDatosAcercamiento.Location = New System.Drawing.Point(91, 94)
        Me.gpBoxDatosAcercamiento.Name = "gpBoxDatosAcercamiento"
        Me.gpBoxDatosAcercamiento.Size = New System.Drawing.Size(898, 266)
        Me.gpBoxDatosAcercamiento.TabIndex = 0
        Me.gpBoxDatosAcercamiento.TabStop = False
        '
        'lblMedioContactoOtro
        '
        Me.lblMedioContactoOtro.AutoSize = True
        Me.lblMedioContactoOtro.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedioContactoOtro.Location = New System.Drawing.Point(437, 69)
        Me.lblMedioContactoOtro.Name = "lblMedioContactoOtro"
        Me.lblMedioContactoOtro.Size = New System.Drawing.Size(36, 18)
        Me.lblMedioContactoOtro.TabIndex = 6
        Me.lblMedioContactoOtro.Text = "Otro"
        '
        'lblAcercamientoOtro
        '
        Me.lblAcercamientoOtro.AutoSize = True
        Me.lblAcercamientoOtro.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcercamientoOtro.Location = New System.Drawing.Point(437, 146)
        Me.lblAcercamientoOtro.Name = "lblAcercamientoOtro"
        Me.lblAcercamientoOtro.Size = New System.Drawing.Size(36, 18)
        Me.lblAcercamientoOtro.TabIndex = 2
        Me.lblAcercamientoOtro.Text = "Otro"
        '
        'cboAcercamientoMedioContacto
        '
        Me.cboAcercamientoMedioContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAcercamientoMedioContacto.FormattingEnabled = True
        Me.cboAcercamientoMedioContacto.Location = New System.Drawing.Point(45, 95)
        Me.cboAcercamientoMedioContacto.Name = "cboAcercamientoMedioContacto"
        Me.cboAcercamientoMedioContacto.Size = New System.Drawing.Size(375, 26)
        Me.cboAcercamientoMedioContacto.TabIndex = 5
        '
        'lblAcercamientoComoEntero
        '
        Me.lblAcercamientoComoEntero.AutoSize = True
        Me.lblAcercamientoComoEntero.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcercamientoComoEntero.Location = New System.Drawing.Point(45, 146)
        Me.lblAcercamientoComoEntero.Name = "lblAcercamientoComoEntero"
        Me.lblAcercamientoComoEntero.Size = New System.Drawing.Size(203, 18)
        Me.lblAcercamientoComoEntero.TabIndex = 0
        Me.lblAcercamientoComoEntero.Text = "¿Cómo se enteró de nosotros?*"
        '
        'txtAcercamientoEnteroOtro
        '
        Me.txtAcercamientoEnteroOtro.Enabled = False
        Me.txtAcercamientoEnteroOtro.Location = New System.Drawing.Point(437, 173)
        Me.txtAcercamientoEnteroOtro.Name = "txtAcercamientoEnteroOtro"
        Me.txtAcercamientoEnteroOtro.Size = New System.Drawing.Size(350, 25)
        Me.txtAcercamientoEnteroOtro.TabIndex = 3
        '
        'cboAcercamientoComoEntero
        '
        Me.cboAcercamientoComoEntero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAcercamientoComoEntero.FormattingEnabled = True
        Me.cboAcercamientoComoEntero.Location = New System.Drawing.Point(45, 172)
        Me.cboAcercamientoComoEntero.Name = "cboAcercamientoComoEntero"
        Me.cboAcercamientoComoEntero.Size = New System.Drawing.Size(375, 26)
        Me.cboAcercamientoComoEntero.TabIndex = 1
        '
        'lblAcercamientoMedioContacto
        '
        Me.lblAcercamientoMedioContacto.AutoSize = True
        Me.lblAcercamientoMedioContacto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcercamientoMedioContacto.Location = New System.Drawing.Point(45, 69)
        Me.lblAcercamientoMedioContacto.Name = "lblAcercamientoMedioContacto"
        Me.lblAcercamientoMedioContacto.Size = New System.Drawing.Size(131, 18)
        Me.lblAcercamientoMedioContacto.TabIndex = 4
        Me.lblAcercamientoMedioContacto.Text = "Medio de contacto*"
        '
        'txtAcercamientoContactoOtro
        '
        Me.txtAcercamientoContactoOtro.Enabled = False
        Me.txtAcercamientoContactoOtro.Location = New System.Drawing.Point(437, 95)
        Me.txtAcercamientoContactoOtro.Name = "txtAcercamientoContactoOtro"
        Me.txtAcercamientoContactoOtro.Size = New System.Drawing.Size(350, 25)
        Me.txtAcercamientoContactoOtro.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(19, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(300, 3)
        Me.Panel2.TabIndex = 1
        '
        'lblTituloAcercamiento
        '
        Me.lblTituloAcercamiento.AutoSize = True
        Me.lblTituloAcercamiento.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloAcercamiento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloAcercamiento.Location = New System.Drawing.Point(19, 4)
        Me.lblTituloAcercamiento.Name = "lblTituloAcercamiento"
        Me.lblTituloAcercamiento.Size = New System.Drawing.Size(177, 29)
        Me.lblTituloAcercamiento.TabIndex = 0
        Me.lblTituloAcercamiento.Text = "ACERCAMIENTO"
        '
        'panDireccion
        '
        Me.panDireccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panDireccion.BackColor = System.Drawing.Color.White
        Me.panDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panDireccion.Controls.Add(Me.lblMensajeCargaDomicilio)
        Me.panDireccion.Controls.Add(Me.Panel3)
        Me.panDireccion.Controls.Add(Me.lblTituloDomicilio)
        Me.panDireccion.Controls.Add(Me.gpBoxDatosDomicilio)
        Me.panDireccion.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panDireccion.Location = New System.Drawing.Point(212, 0)
        Me.panDireccion.Name = "panDireccion"
        Me.panDireccion.Size = New System.Drawing.Size(1106, 660)
        Me.panDireccion.TabIndex = 0
        Me.panDireccion.Tag = "4"
        Me.panDireccion.Visible = False
        '
        'lblMensajeCargaDomicilio
        '
        Me.lblMensajeCargaDomicilio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMensajeCargaDomicilio.BackColor = System.Drawing.Color.DarkSalmon
        Me.lblMensajeCargaDomicilio.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeCargaDomicilio.ForeColor = System.Drawing.Color.White
        Me.lblMensajeCargaDomicilio.Location = New System.Drawing.Point(0, 44)
        Me.lblMensajeCargaDomicilio.Name = "lblMensajeCargaDomicilio"
        Me.lblMensajeCargaDomicilio.Size = New System.Drawing.Size(1104, 25)
        Me.lblMensajeCargaDomicilio.TabIndex = 11
        Me.lblMensajeCargaDomicilio.Text = "No se ha cargado información de Domicilio para el prospecto."
        Me.lblMensajeCargaDomicilio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeCargaDomicilio.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(19, 34)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(300, 3)
        Me.Panel3.TabIndex = 1
        '
        'lblTituloDomicilio
        '
        Me.lblTituloDomicilio.AutoSize = True
        Me.lblTituloDomicilio.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloDomicilio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloDomicilio.Location = New System.Drawing.Point(19, 4)
        Me.lblTituloDomicilio.Name = "lblTituloDomicilio"
        Me.lblTituloDomicilio.Size = New System.Drawing.Size(122, 29)
        Me.lblTituloDomicilio.TabIndex = 0
        Me.lblTituloDomicilio.Text = "DOMICILIO"
        '
        'gpBoxDatosDomicilio
        '
        Me.gpBoxDatosDomicilio.Controls.Add(Me.lblCamposDomicilio)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.lblDomicilioPais)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.cboDomicilioPais)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.panDomicilioExt)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.panDomicilioNac)
        Me.gpBoxDatosDomicilio.Enabled = False
        Me.gpBoxDatosDomicilio.Location = New System.Drawing.Point(91, 101)
        Me.gpBoxDatosDomicilio.Name = "gpBoxDatosDomicilio"
        Me.gpBoxDatosDomicilio.Size = New System.Drawing.Size(898, 478)
        Me.gpBoxDatosDomicilio.TabIndex = 0
        Me.gpBoxDatosDomicilio.TabStop = False
        '
        'lblCamposDomicilio
        '
        Me.lblCamposDomicilio.AutoSize = True
        Me.lblCamposDomicilio.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Italic)
        Me.lblCamposDomicilio.Location = New System.Drawing.Point(13, 446)
        Me.lblCamposDomicilio.Name = "lblCamposDomicilio"
        Me.lblCamposDomicilio.Size = New System.Drawing.Size(266, 17)
        Me.lblCamposDomicilio.TabIndex = 14
        Me.lblCamposDomicilio.Text = "Los campos marcados con (*) son obligatorios."
        '
        'lblDomicilioPais
        '
        Me.lblDomicilioPais.AutoSize = True
        Me.lblDomicilioPais.Location = New System.Drawing.Point(127, 48)
        Me.lblDomicilioPais.Name = "lblDomicilioPais"
        Me.lblDomicilioPais.Size = New System.Drawing.Size(33, 18)
        Me.lblDomicilioPais.TabIndex = 0
        Me.lblDomicilioPais.Text = "País"
        '
        'cboDomicilioPais
        '
        Me.cboDomicilioPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDomicilioPais.DropDownWidth = 300
        Me.cboDomicilioPais.FormattingEnabled = True
        Me.cboDomicilioPais.Location = New System.Drawing.Point(166, 45)
        Me.cboDomicilioPais.Name = "cboDomicilioPais"
        Me.cboDomicilioPais.Size = New System.Drawing.Size(255, 26)
        Me.cboDomicilioPais.TabIndex = 1
        '
        'panDomicilioExt
        '
        Me.panDomicilioExt.Controls.Add(Me.txtDomicilioExtCP)
        Me.panDomicilioExt.Controls.Add(Me.lblDomicilioExtCP)
        Me.panDomicilioExt.Controls.Add(Me.lblDomicilioExtDireccion2)
        Me.panDomicilioExt.Controls.Add(Me.txtDomicilioExtDireccion2)
        Me.panDomicilioExt.Controls.Add(Me.lblDomicilioExtDireccion1)
        Me.panDomicilioExt.Controls.Add(Me.lblDomicilioExtEstado)
        Me.panDomicilioExt.Controls.Add(Me.lblDomicilioExtLocalidad)
        Me.panDomicilioExt.Controls.Add(Me.txtDomicilioExtLocalidad)
        Me.panDomicilioExt.Controls.Add(Me.txtDomicilioExtDireccion1)
        Me.panDomicilioExt.Controls.Add(Me.txtDomicilioExtEstado)
        Me.panDomicilioExt.Location = New System.Drawing.Point(80, 83)
        Me.panDomicilioExt.Name = "panDomicilioExt"
        Me.panDomicilioExt.Size = New System.Drawing.Size(738, 340)
        Me.panDomicilioExt.TabIndex = 15
        '
        'txtDomicilioExtCP
        '
        Me.txtDomicilioExtCP.Location = New System.Drawing.Point(84, 298)
        Me.txtDomicilioExtCP.Name = "txtDomicilioExtCP"
        Me.txtDomicilioExtCP.Size = New System.Drawing.Size(309, 25)
        Me.txtDomicilioExtCP.TabIndex = 9
        '
        'lblDomicilioExtCP
        '
        Me.lblDomicilioExtCP.AutoSize = True
        Me.lblDomicilioExtCP.Location = New System.Drawing.Point(84, 273)
        Me.lblDomicilioExtCP.Name = "lblDomicilioExtCP"
        Me.lblDomicilioExtCP.Size = New System.Drawing.Size(286, 18)
        Me.lblDomicilioExtCP.TabIndex = 8
        Me.lblDomicilioExtCP.Text = "Código Postal / Código ZIP / Código de Área*:"
        '
        'lblDomicilioExtDireccion2
        '
        Me.lblDomicilioExtDireccion2.AutoSize = True
        Me.lblDomicilioExtDireccion2.Location = New System.Drawing.Point(84, 81)
        Me.lblDomicilioExtDireccion2.Name = "lblDomicilioExtDireccion2"
        Me.lblDomicilioExtDireccion2.Size = New System.Drawing.Size(284, 18)
        Me.lblDomicilioExtDireccion2.TabIndex = 2
        Me.lblDomicilioExtDireccion2.Text = "Línea de Dirección 2 (Información Adicional):"
        '
        'txtDomicilioExtDireccion2
        '
        Me.txtDomicilioExtDireccion2.Location = New System.Drawing.Point(84, 106)
        Me.txtDomicilioExtDireccion2.Name = "txtDomicilioExtDireccion2"
        Me.txtDomicilioExtDireccion2.Size = New System.Drawing.Size(560, 25)
        Me.txtDomicilioExtDireccion2.TabIndex = 3
        '
        'lblDomicilioExtDireccion1
        '
        Me.lblDomicilioExtDireccion1.AutoSize = True
        Me.lblDomicilioExtDireccion1.Location = New System.Drawing.Point(84, 17)
        Me.lblDomicilioExtDireccion1.Name = "lblDomicilioExtDireccion1"
        Me.lblDomicilioExtDireccion1.Size = New System.Drawing.Size(323, 18)
        Me.lblDomicilioExtDireccion1.TabIndex = 0
        Me.lblDomicilioExtDireccion1.Text = "Línea de Dirección 1 (Número y Nombre de Calle)*:"
        '
        'lblDomicilioExtEstado
        '
        Me.lblDomicilioExtEstado.AutoSize = True
        Me.lblDomicilioExtEstado.Location = New System.Drawing.Point(84, 209)
        Me.lblDomicilioExtEstado.Name = "lblDomicilioExtEstado"
        Me.lblDomicilioExtEstado.Size = New System.Drawing.Size(251, 18)
        Me.lblDomicilioExtEstado.TabIndex = 6
        Me.lblDomicilioExtEstado.Text = "Estado / Provincia / Región / Condado*:"
        '
        'lblDomicilioExtLocalidad
        '
        Me.lblDomicilioExtLocalidad.AutoSize = True
        Me.lblDomicilioExtLocalidad.Location = New System.Drawing.Point(84, 145)
        Me.lblDomicilioExtLocalidad.Name = "lblDomicilioExtLocalidad"
        Me.lblDomicilioExtLocalidad.Size = New System.Drawing.Size(132, 18)
        Me.lblDomicilioExtLocalidad.TabIndex = 4
        Me.lblDomicilioExtLocalidad.Text = "Ciudad / Localidad*:"
        '
        'txtDomicilioExtLocalidad
        '
        Me.txtDomicilioExtLocalidad.Location = New System.Drawing.Point(84, 170)
        Me.txtDomicilioExtLocalidad.Name = "txtDomicilioExtLocalidad"
        Me.txtDomicilioExtLocalidad.Size = New System.Drawing.Size(560, 25)
        Me.txtDomicilioExtLocalidad.TabIndex = 5
        '
        'txtDomicilioExtDireccion1
        '
        Me.txtDomicilioExtDireccion1.Location = New System.Drawing.Point(84, 42)
        Me.txtDomicilioExtDireccion1.Name = "txtDomicilioExtDireccion1"
        Me.txtDomicilioExtDireccion1.Size = New System.Drawing.Size(560, 25)
        Me.txtDomicilioExtDireccion1.TabIndex = 1
        '
        'txtDomicilioExtEstado
        '
        Me.txtDomicilioExtEstado.Location = New System.Drawing.Point(84, 234)
        Me.txtDomicilioExtEstado.Name = "txtDomicilioExtEstado"
        Me.txtDomicilioExtEstado.Size = New System.Drawing.Size(560, 25)
        Me.txtDomicilioExtEstado.TabIndex = 7
        '
        'panDomicilioNac
        '
        Me.panDomicilioNac.Controls.Add(Me.lblDomicilioCalle)
        Me.panDomicilioNac.Controls.Add(Me.cboDomicilioEstado)
        Me.panDomicilioNac.Controls.Add(Me.txtDomicilioNoInt)
        Me.panDomicilioNac.Controls.Add(Me.cboDomicilioMunicipio)
        Me.panDomicilioNac.Controls.Add(Me.txtDomicilioCalle)
        Me.panDomicilioNac.Controls.Add(Me.cboDomicilioColonia)
        Me.panDomicilioNac.Controls.Add(Me.txtDomicilioNoExt)
        Me.panDomicilioNac.Controls.Add(Me.lblDomicilioEstado)
        Me.panDomicilioNac.Controls.Add(Me.lblDomicilioNoInt)
        Me.panDomicilioNac.Controls.Add(Me.lblDomicilioMunicipio)
        Me.panDomicilioNac.Controls.Add(Me.lblDomicilioNoExt)
        Me.panDomicilioNac.Controls.Add(Me.lblDomicilioColonia)
        Me.panDomicilioNac.Controls.Add(Me.txtDomicilioCP)
        Me.panDomicilioNac.Controls.Add(Me.lblDomicilioCP)
        Me.panDomicilioNac.Location = New System.Drawing.Point(80, 83)
        Me.panDomicilioNac.Name = "panDomicilioNac"
        Me.panDomicilioNac.Size = New System.Drawing.Size(738, 340)
        Me.panDomicilioNac.TabIndex = 2
        '
        'lblDomicilioCalle
        '
        Me.lblDomicilioCalle.AutoSize = True
        Me.lblDomicilioCalle.Location = New System.Drawing.Point(49, 29)
        Me.lblDomicilioCalle.Name = "lblDomicilioCalle"
        Me.lblDomicilioCalle.Size = New System.Drawing.Size(39, 18)
        Me.lblDomicilioCalle.TabIndex = 0
        Me.lblDomicilioCalle.Text = "Calle"
        '
        'cboDomicilioEstado
        '
        Me.cboDomicilioEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDomicilioEstado.FormattingEnabled = True
        Me.cboDomicilioEstado.Location = New System.Drawing.Point(197, 233)
        Me.cboDomicilioEstado.Name = "cboDomicilioEstado"
        Me.cboDomicilioEstado.Size = New System.Drawing.Size(309, 26)
        Me.cboDomicilioEstado.TabIndex = 13
        '
        'txtDomicilioNoInt
        '
        Me.txtDomicilioNoInt.Location = New System.Drawing.Point(522, 52)
        Me.txtDomicilioNoInt.Name = "txtDomicilioNoInt"
        Me.txtDomicilioNoInt.Size = New System.Drawing.Size(89, 25)
        Me.txtDomicilioNoInt.TabIndex = 3
        '
        'cboDomicilioMunicipio
        '
        Me.cboDomicilioMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDomicilioMunicipio.FormattingEnabled = True
        Me.cboDomicilioMunicipio.Location = New System.Drawing.Point(197, 188)
        Me.cboDomicilioMunicipio.Name = "cboDomicilioMunicipio"
        Me.cboDomicilioMunicipio.Size = New System.Drawing.Size(309, 26)
        Me.cboDomicilioMunicipio.TabIndex = 11
        '
        'txtDomicilioCalle
        '
        Me.txtDomicilioCalle.Location = New System.Drawing.Point(49, 52)
        Me.txtDomicilioCalle.Name = "txtDomicilioCalle"
        Me.txtDomicilioCalle.Size = New System.Drawing.Size(457, 25)
        Me.txtDomicilioCalle.TabIndex = 1
        '
        'cboDomicilioColonia
        '
        Me.cboDomicilioColonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDomicilioColonia.FormattingEnabled = True
        Me.cboDomicilioColonia.Location = New System.Drawing.Point(197, 143)
        Me.cboDomicilioColonia.Name = "cboDomicilioColonia"
        Me.cboDomicilioColonia.Size = New System.Drawing.Size(309, 26)
        Me.cboDomicilioColonia.TabIndex = 9
        '
        'txtDomicilioNoExt
        '
        Me.txtDomicilioNoExt.Location = New System.Drawing.Point(627, 52)
        Me.txtDomicilioNoExt.Name = "txtDomicilioNoExt"
        Me.txtDomicilioNoExt.Size = New System.Drawing.Size(89, 25)
        Me.txtDomicilioNoExt.TabIndex = 5
        '
        'lblDomicilioEstado
        '
        Me.lblDomicilioEstado.AutoSize = True
        Me.lblDomicilioEstado.Location = New System.Drawing.Point(132, 238)
        Me.lblDomicilioEstado.Name = "lblDomicilioEstado"
        Me.lblDomicilioEstado.Size = New System.Drawing.Size(53, 18)
        Me.lblDomicilioEstado.TabIndex = 12
        Me.lblDomicilioEstado.Text = "Estado:"
        '
        'lblDomicilioNoInt
        '
        Me.lblDomicilioNoInt.AutoSize = True
        Me.lblDomicilioNoInt.Location = New System.Drawing.Point(522, 29)
        Me.lblDomicilioNoInt.Name = "lblDomicilioNoInt"
        Me.lblDomicilioNoInt.Size = New System.Drawing.Size(66, 18)
        Me.lblDomicilioNoInt.TabIndex = 2
        Me.lblDomicilioNoInt.Text = "Núm. Int."
        '
        'lblDomicilioMunicipio
        '
        Me.lblDomicilioMunicipio.AutoSize = True
        Me.lblDomicilioMunicipio.Location = New System.Drawing.Point(49, 193)
        Me.lblDomicilioMunicipio.Name = "lblDomicilioMunicipio"
        Me.lblDomicilioMunicipio.Size = New System.Drawing.Size(136, 18)
        Me.lblDomicilioMunicipio.TabIndex = 10
        Me.lblDomicilioMunicipio.Text = "Municipio / Alcaldia:"
        '
        'lblDomicilioNoExt
        '
        Me.lblDomicilioNoExt.AutoSize = True
        Me.lblDomicilioNoExt.Location = New System.Drawing.Point(627, 29)
        Me.lblDomicilioNoExt.Name = "lblDomicilioNoExt"
        Me.lblDomicilioNoExt.Size = New System.Drawing.Size(68, 18)
        Me.lblDomicilioNoExt.TabIndex = 4
        Me.lblDomicilioNoExt.Text = "Núm. Ext."
        '
        'lblDomicilioColonia
        '
        Me.lblDomicilioColonia.AutoSize = True
        Me.lblDomicilioColonia.Location = New System.Drawing.Point(126, 148)
        Me.lblDomicilioColonia.Name = "lblDomicilioColonia"
        Me.lblDomicilioColonia.Size = New System.Drawing.Size(59, 18)
        Me.lblDomicilioColonia.TabIndex = 8
        Me.lblDomicilioColonia.Text = "Colonia:"
        '
        'txtDomicilioCP
        '
        Me.txtDomicilioCP.Location = New System.Drawing.Point(197, 99)
        Me.txtDomicilioCP.Name = "txtDomicilioCP"
        Me.txtDomicilioCP.Size = New System.Drawing.Size(135, 25)
        Me.txtDomicilioCP.TabIndex = 7
        '
        'lblDomicilioCP
        '
        Me.lblDomicilioCP.AutoSize = True
        Me.lblDomicilioCP.Location = New System.Drawing.Point(89, 103)
        Me.lblDomicilioCP.Name = "lblDomicilioCP"
        Me.lblDomicilioCP.Size = New System.Drawing.Size(96, 18)
        Me.lblDomicilioCP.TabIndex = 6
        Me.lblDomicilioCP.Text = "Código Postal:"
        '
        'FrmContacto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1318, 700)
        Me.Controls.Add(Me.btnRegistroDatosGenerales)
        Me.Controls.Add(Me.btnGuardaGeneral)
        Me.Controls.Add(Me.btnCancelaGeneral)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.panMenu)
        Me.Controls.Add(Me.panDireccion)
        Me.Controls.Add(Me.panContactoInicial)
        Me.Controls.Add(Me.panDatosGenerales)
        Me.Controls.Add(Me.panAcercamiento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmContacto"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Alta de cliente prospecto"
        Me.panMenu.ResumeLayout(False)
        Me.panMenu.PerformLayout()
        Me.panMensajesError.ResumeLayout(False)
        Me.panMensajesError.PerformLayout()
        Me.panDatosGenerales.ResumeLayout(False)
        Me.panDatosGenerales.PerformLayout()
        Me.gpBoxDatosDG.ResumeLayout(False)
        Me.gpBoxDatosDG.PerformLayout()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpBoxTipoNegocio.ResumeLayout(False)
        Me.gpBoxTipoNegocio.PerformLayout()
        Me.gpBoxServicio.ResumeLayout(False)
        Me.gpBoxServicio.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpBoxSubsidiaria.ResumeLayout(False)
        Me.gpBoxSubsidiaria.PerformLayout()
        Me.panRDSubsidiaria.ResumeLayout(False)
        Me.panRDSubsidiaria.PerformLayout()
        Me.panRDCompañiaControl.ResumeLayout(False)
        Me.panRDCompañiaControl.PerformLayout()
        Me.gpBoxEmpresaPublica.ResumeLayout(False)
        Me.gpBoxEmpresaPublica.PerformLayout()
        Me.gpBoxEntidadReguladora.ResumeLayout(False)
        Me.gpBoxEntidadReguladora.PerformLayout()
        Me.gpBoxEntidadSupervisada.ResumeLayout(False)
        Me.gpBoxEntidadSupervisada.PerformLayout()
        Me.gpBoxReferenciaGTI.ResumeLayout(False)
        Me.gpBoxReferenciaGTI.PerformLayout()
        Me.gpBoxEmpresaExtranjero.ResumeLayout(False)
        Me.gpBoxEmpresaExtranjero.PerformLayout()
        Me.panRDDomExt.ResumeLayout(False)
        Me.panRDDomExt.PerformLayout()
        Me.panRDSubExt.ResumeLayout(False)
        Me.panRDSubExt.PerformLayout()
        Me.panRDRepExt.ResumeLayout(False)
        Me.panRDRepExt.PerformLayout()
        Me.panContactoInicial.ResumeLayout(False)
        Me.panContactoInicial.PerformLayout()
        Me.panDatosContactoInicial.ResumeLayout(False)
        Me.panDatosContactoInicial.PerformLayout()
        Me.gpBoxDatosContactoInicial.ResumeLayout(False)
        Me.gpBoxDatosContactoInicial.PerformLayout()
        Me.panAcercamiento.ResumeLayout(False)
        Me.panAcercamiento.PerformLayout()
        Me.gpBoxDatosAcercamiento.ResumeLayout(False)
        Me.gpBoxDatosAcercamiento.PerformLayout()
        Me.panDireccion.ResumeLayout(False)
        Me.panDireccion.PerformLayout()
        Me.gpBoxDatosDomicilio.ResumeLayout(False)
        Me.gpBoxDatosDomicilio.PerformLayout()
        Me.panDomicilioExt.ResumeLayout(False)
        Me.panDomicilioExt.PerformLayout()
        Me.panDomicilioNac.ResumeLayout(False)
        Me.panDomicilioNac.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panMenu As Panel
    Friend WithEvents panDatosGenerales As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lnkDatosGenerales As LinkLabel
    Friend WithEvents lblTituloDatosGenerales As Label
    Friend WithEvents txtNombreComercial As TextBox
    Friend WithEvents lblNombreComercial As Label
    Friend WithEvents txtRazonSocial As TextBox
    Friend WithEvents lblRazonSocial As Label
    Friend WithEvents gpBoxEmpresaPublica As GroupBox
    Friend WithEvents rdEmpresaPublicaNo As RadioButton
    Friend WithEvents rdEmpresaPublicaSi As RadioButton
    Friend WithEvents gpBoxEntidadReguladora As GroupBox
    Friend WithEvents txtEntidadReguladoraOtro As TextBox
    Friend WithEvents cboEntidadReguladora As ComboBox
    Friend WithEvents rdEntidadReguladaNo As RadioButton
    Friend WithEvents rdEntidadReguladaSi As RadioButton
    Friend WithEvents txtBolsaValoresOtro As TextBox
    Friend WithEvents cboBolsaValores As ComboBox
    Friend WithEvents gpBoxEntidadSupervisada As GroupBox
    Friend WithEvents txtEntidadSupervisadaOtro As TextBox
    Friend WithEvents cboEntidadSupervisada As ComboBox
    Friend WithEvents rdEntidadSupervisadaNo As RadioButton
    Friend WithEvents rdEntidadSupervisadaSi As RadioButton
    Friend WithEvents gpBoxReferenciaGTI As GroupBox
    Friend WithEvents txtReferenciaGTISocio As TextBox
    Friend WithEvents rdReferenciaGTINo As RadioButton
    Friend WithEvents rdReferenciaGTISi As RadioButton
    Friend WithEvents lblRefGTIOficina As Label
    Friend WithEvents lbRefGTISocio As Label
    Friend WithEvents gpBoxEmpresaExtranjero As GroupBox
    Friend WithEvents lblPaisResidencia As Label
    Friend WithEvents txtEmpresaTenedora As TextBox
    Friend WithEvents lblEmpresaTenedora As Label
    Friend WithEvents rdEmpresaExtranjeroRepNo As RadioButton
    Friend WithEvents rdEmpresaExtranjeroRepSi As RadioButton
    Friend WithEvents lblReporteExtranjero As Label
    Friend WithEvents cboPaisResidencia As ComboBox
    Friend WithEvents cboTipoEntidad As ComboBox
    Friend WithEvents lblTipoEntidad As Label
    Friend WithEvents lblCompañiaSubsidiaria As Label
    Friend WithEvents rdEmpresaExtranjeroSubNo As RadioButton
    Friend WithEvents rdEmpresaExtranjeroSubSi As RadioButton
    Friend WithEvents lblDomicilioExtranjero As Label
    Friend WithEvents rdEmpresaExtranjeroDomNo As RadioButton
    Friend WithEvents rdEmpresaExtranjeroDomSi As RadioButton
    Friend WithEvents panLinea As Panel
    Friend WithEvents lnkContactoInicial As LinkLabel
    Friend WithEvents lnkDireccion As LinkLabel
    Friend WithEvents lnkAcercamiento As LinkLabel
    Friend WithEvents panContactoInicial As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtContactoInicialExtension As TextBox
    Friend WithEvents lblContactoInicialExtension As Label
    Friend WithEvents txtContactoInicialTelefono As TextBox
    Friend WithEvents lblContactoInicialTelefono As Label
    Friend WithEvents txtContactoInicialCorreo As TextBox
    Friend WithEvents lblContactoInicialCorreo As Label
    Friend WithEvents txtContactoInicialCargo As TextBox
    Friend WithEvents lblContactoInicialCargo As Label
    Friend WithEvents txtContactoInicialNombre As TextBox
    Friend WithEvents lblContactoInicialNombre As Label
    Friend WithEvents gpBoxDatosContactoInicial As GroupBox
    Friend WithEvents cboReferenciaGTIOficina As ComboBox
    Friend WithEvents cboReferenciaGTIPais As ComboBox
    Friend WithEvents lblReferenciaGTIPais As Label
    Friend WithEvents cboPais As ComboBox
    Friend WithEvents lblPais As Label
    Friend WithEvents panAcercamiento As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblTituloAcercamiento As Label
    Friend WithEvents gpBoxDatosAcercamiento As GroupBox
    Friend WithEvents lblAcercamientoComoEntero As Label
    Friend WithEvents txtAcercamientoEnteroOtro As TextBox
    Friend WithEvents lblAcercamientoMedioContacto As Label
    Friend WithEvents txtAcercamientoContactoOtro As TextBox
    Friend WithEvents cboAcercamientoMedioContacto As ComboBox
    Friend WithEvents cboAcercamientoComoEntero As ComboBox
    Friend WithEvents lblBolsaValoresOtra As Label
    Friend WithEvents lblBolsaValores As Label
    Friend WithEvents lblEntidadSupervisadaOtra As Label
    Friend WithEvents lblEntidadSupervisada As Label
    Friend WithEvents lblEntidadReguladoraOtra As Label
    Friend WithEvents lblEntidadReguladora As Label
    Friend WithEvents panDireccion As Panel
    Friend WithEvents gpBoxDatosDomicilio As GroupBox
    Friend WithEvents lblDomicilioPais As Label
    Friend WithEvents txtDomicilioCalle As TextBox
    Friend WithEvents cboDomicilioPais As ComboBox
    Friend WithEvents txtDomicilioNoInt As TextBox
    Friend WithEvents lblDomicilioCP As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblTituloDomicilio As Label
    Friend WithEvents txtDomicilioCP As TextBox
    Friend WithEvents lblDomicilioNoExt As Label
    Friend WithEvents lblDomicilioNoInt As Label
    Friend WithEvents lblDomicilioCalle As Label
    Friend WithEvents txtDomicilioNoExt As TextBox
    Friend WithEvents lblDomicilioEstado As Label
    Friend WithEvents lblDomicilioMunicipio As Label
    Friend WithEvents lblDomicilioColonia As Label
    Friend WithEvents lblMedioContactoOtro As Label
    Friend WithEvents lblAcercamientoOtro As Label
    Friend WithEvents cboDomicilioEstado As ComboBox
    Friend WithEvents cboDomicilioMunicipio As ComboBox
    Friend WithEvents cboDomicilioColonia As ComboBox
    Friend WithEvents Lista As DataGridView
    Friend WithEvents lblMensajeErrorAcercamiento As Label
    Friend WithEvents txtClaveProspecto As Label
    Friend WithEvents lblMensajeCargaContactoInicial As Label
    Friend WithEvents lblMensajeCargaAcercamiento As Label
    Friend WithEvents lblMensajeCargaDomicilio As Label
    Friend WithEvents btnCancelaGeneral As Button
    Friend WithEvents btnGuardaGeneral As Button
    Friend WithEvents txtDomicilioExtEstado As TextBox
    Friend WithEvents txtDomicilioExtLocalidad As TextBox
    Friend WithEvents txtDomicilioExtDireccion1 As TextBox
    Friend WithEvents lblMensajeCargaDatosGenerales As Label
    Friend WithEvents gpBoxDatosDG As GroupBox
    Friend WithEvents btnRegistroDatosGenerales As Button
    Friend WithEvents panRDDomExt As Panel
    Friend WithEvents panRDRepExt As Panel
    Friend WithEvents panRDSubExt As Panel
    Friend WithEvents gpBoxSubsidiaria As GroupBox
    Friend WithEvents txtSubnivel As TextBox
    Friend WithEvents txtSubsector As TextBox
    Friend WithEvents txtIndustria As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblIndustria As Label
    Friend WithEvents btnIndustria As Button
    Friend WithEvents btnSubnivel As Button
    Friend WithEvents btnSubsector As Button
    Friend WithEvents lblRFC As Label
    Friend WithEvents txtRFC As TextBox
    Friend WithEvents gpBoxServicio As GroupBox
    Friend WithEvents lblDescripcionSolicitud As Label
    Friend WithEvents txtDescripcionSolicitud As TextBox
    Friend WithEvents lblSubsidiaria As Label
    Friend WithEvents lblControladora As Label
    Friend WithEvents panRDSubsidiaria As Panel
    Friend WithEvents rdSubsidiariaSi As RadioButton
    Friend WithEvents rdSubsidiariaNo As RadioButton
    Friend WithEvents panRDCompañiaControl As Panel
    Friend WithEvents rdControladoraSi As RadioButton
    Friend WithEvents rdControladoraNO As RadioButton
    Friend WithEvents gpBoxTipoNegocio As GroupBox
    Friend WithEvents rdPersonaFisica As RadioButton
    Friend WithEvents rdPersonalMoral As RadioButton
    Friend WithEvents lblIdSAC As Label
    Friend WithEvents txtIdSAC As TextBox
    Friend WithEvents lblAcercamientoWebProspecto As Label
    Friend WithEvents txtAcercamientoWebProspecto As TextBox
    Friend WithEvents lblTituloDatosContacto As Label
    Friend WithEvents txtContactoInicialCelular As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblContactoInicialPrimeraPersona As Label
    Friend WithEvents txtContactoInicialPrimerContacto As TextBox
    Friend WithEvents lblContactoInicialFecha As Label
    Friend WithEvents txtContactoInicialFecha As DateTimePicker
    Friend WithEvents panDatosContactoInicial As Panel
    Friend WithEvents lblContactoInicialObligatorios As Label
    Friend WithEvents panMensajesError As Panel
    Friend WithEvents lblTituloError As Label
    Friend WithEvents txtMensaje As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblCamposDomicilio As Label
    Friend WithEvents panDomicilioExt As Panel
    Friend WithEvents lblDomicilioExtDireccion1 As Label
    Friend WithEvents lblDomicilioExtEstado As Label
    Friend WithEvents lblDomicilioExtLocalidad As Label
    Friend WithEvents panDomicilioNac As Panel
    Friend WithEvents lblDomicilioExtDireccion2 As Label
    Friend WithEvents txtDomicilioExtDireccion2 As TextBox
    Friend WithEvents txtDomicilioExtCP As TextBox
    Friend WithEvents lblDomicilioExtCP As Label
    Friend WithEvents cboDatosGeneralesServicio As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdIdiomaNo As RadioButton
    Friend WithEvents rdIdiomaSi As RadioButton
    Friend WithEvents txtCorreoSocioGTI As TextBox
    Friend WithEvents lblCorreoSocioGTI As Label
    Friend WithEvents txtCorreoGerenteGTI As TextBox
    Friend WithEvents lblCorreoGerenteGTI As Label
    Friend WithEvents txtGerenteGTI As TextBox
    Friend WithEvents lblGerenteGTI As Label
    Friend WithEvents txtEstadoGTI As TextBox
    Friend WithEvents lblEstadoGTI As Label
    Friend WithEvents txtFechaSolicitud As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents txtFechaEntregaReporte As DateTimePicker
    Friend WithEvents lblFechaEntregaReporte As Label
    Friend WithEvents txtPeriodoFinal As DateTimePicker
    Friend WithEvents lblPeriodoServicioA As Label
    Friend WithEvents txtPeriodoInicio As DateTimePicker
    Friend WithEvents lblPeriodoServicio As Label
    Friend WithEvents cboModalidades As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboIdioma As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cboDivision As ComboBox
    Friend WithEvents lblDivision As Label
    Friend WithEvents cboOficina As ComboBox
    Friend WithEvents lblOficina As Label
    Friend WithEvents lblDatosGeneralesSocio As Label
    Friend WithEvents cboSocio As ComboBox
    Friend WithEvents btnGuardarAvance As Button
    Friend WithEvents lblTituloCI As Label
End Class
