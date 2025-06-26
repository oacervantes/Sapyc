<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmContacto
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose( disposing As Boolean)
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContacto))
        Me.panMenu = New System.Windows.Forms.Panel()
        Me.txtClaveProspecto = New System.Windows.Forms.Label()
        Me.lnkAccionistas = New System.Windows.Forms.LinkLabel()
        Me.lnkFuncionarios = New System.Windows.Forms.LinkLabel()
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
        Me.gpBoxTipoNegocio = New System.Windows.Forms.GroupBox()
        Me.rdPersonaFisica = New System.Windows.Forms.RadioButton()
        Me.rdPersonalMoral = New System.Windows.Forms.RadioButton()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.gpBoxServicio = New System.Windows.Forms.GroupBox()
        Me.panDivisiones = New System.Windows.Forms.Panel()
        Me.rdAuditoria = New System.Windows.Forms.RadioButton()
        Me.rdIBC = New System.Windows.Forms.RadioButton()
        Me.rdPLD = New System.Windows.Forms.RadioButton()
        Me.rdJBG = New System.Windows.Forms.RadioButton()
        Me.rdImpuestos = New System.Windows.Forms.RadioButton()
        Me.rdComercioExterior = New System.Windows.Forms.RadioButton()
        Me.rdBAS = New System.Windows.Forms.RadioButton()
        Me.rdPreciosTransferencia = New System.Windows.Forms.RadioButton()
        Me.rdBPS = New System.Windows.Forms.RadioButton()
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
        Me.lblMensajeErrorDatosGenerales = New System.Windows.Forms.Label()
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
        Me.btnCancelarContactoInicial = New System.Windows.Forms.Button()
        Me.btnGuardarContactoInicial = New System.Windows.Forms.Button()
        Me.btnRegistroContactoInicial = New System.Windows.Forms.Button()
        Me.lblMensajeErrorContactoInicial = New System.Windows.Forms.Label()
        Me.gpBoxDatosContactoInicial = New System.Windows.Forms.GroupBox()
        Me.lblContactoInicialNombre = New System.Windows.Forms.Label()
        Me.txtContactoInicialExtension = New System.Windows.Forms.TextBox()
        Me.txtContactoInicialNombre = New System.Windows.Forms.TextBox()
        Me.lblContactoInicialExtension = New System.Windows.Forms.Label()
        Me.lblContactoInicialCargo = New System.Windows.Forms.Label()
        Me.txtContactoInicialTelefono = New System.Windows.Forms.TextBox()
        Me.txtContactoInicialCargo = New System.Windows.Forms.TextBox()
        Me.lblContactoInicialTelefono = New System.Windows.Forms.Label()
        Me.lblContactoInicialCorreo = New System.Windows.Forms.Label()
        Me.txtContactoInicialCorreo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTituloCI = New System.Windows.Forms.Label()
        Me.panAcercamiento = New System.Windows.Forms.Panel()
        Me.lblMensajeCargaAcercamiento = New System.Windows.Forms.Label()
        Me.lblMensajeErrorAcercamiento = New System.Windows.Forms.Label()
        Me.btnCancelarAcercamiento = New System.Windows.Forms.Button()
        Me.btnGuardarAcercamiento = New System.Windows.Forms.Button()
        Me.btnRegistroAcercamiento = New System.Windows.Forms.Button()
        Me.gpBoxDatosAcercamiento = New System.Windows.Forms.GroupBox()
        Me.lblAcercamientoWebProspecto = New System.Windows.Forms.Label()
        Me.lblMedioContactoOtro = New System.Windows.Forms.Label()
        Me.lblAcercamientoOtro = New System.Windows.Forms.Label()
        Me.txtAcercamientoWebProspecto = New System.Windows.Forms.TextBox()
        Me.cboAcercamientoMedioContacto = New System.Windows.Forms.ComboBox()
        Me.lblAcercamientoComoEntero = New System.Windows.Forms.Label()
        Me.txtAcercamientoEnteroOtro = New System.Windows.Forms.TextBox()
        Me.cboAcercamientoComoEntero = New System.Windows.Forms.ComboBox()
        Me.lblAcercamientoMedioContacto = New System.Windows.Forms.Label()
        Me.txtAcercamientoContactoOtro = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTituloAcercamiento = New System.Windows.Forms.Label()
        Me.panDireccion = New System.Windows.Forms.Panel()
        Me.btnCancelarDomicilio = New System.Windows.Forms.Button()
        Me.btnGuardarDomicilio = New System.Windows.Forms.Button()
        Me.btnRegistroDomicilio = New System.Windows.Forms.Button()
        Me.lblMensajeErrorDomicilio = New System.Windows.Forms.Label()
        Me.lblMensajeCargaDomicilio = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblTituloDomicilio = New System.Windows.Forms.Label()
        Me.gpBoxDatosDomicilio = New System.Windows.Forms.GroupBox()
        Me.cboDomicilioEstado = New System.Windows.Forms.ComboBox()
        Me.cboDomicilioMunicipio = New System.Windows.Forms.ComboBox()
        Me.cboDomicilioColonia = New System.Windows.Forms.ComboBox()
        Me.lblDomicilioEstado = New System.Windows.Forms.Label()
        Me.lblDomicilioMunicipio = New System.Windows.Forms.Label()
        Me.lblDomicilioColonia = New System.Windows.Forms.Label()
        Me.lblDomicilioCP = New System.Windows.Forms.Label()
        Me.txtDomicilioCP = New System.Windows.Forms.TextBox()
        Me.lblDomicilioNoExt = New System.Windows.Forms.Label()
        Me.lblDomicilioNoInt = New System.Windows.Forms.Label()
        Me.lblDomicilioCalle = New System.Windows.Forms.Label()
        Me.txtDomicilioNoExt = New System.Windows.Forms.TextBox()
        Me.lblDomicilioPais = New System.Windows.Forms.Label()
        Me.txtDomicilioCalle = New System.Windows.Forms.TextBox()
        Me.cboDomicilioPais = New System.Windows.Forms.ComboBox()
        Me.txtDomicilioNoInt = New System.Windows.Forms.TextBox()
        Me.txtDomicilioMunicipio = New System.Windows.Forms.TextBox()
        Me.txtDomicilioEstado = New System.Windows.Forms.TextBox()
        Me.txtDomicilioColonia = New System.Windows.Forms.TextBox()
        Me.panFuncionarios = New System.Windows.Forms.Panel()
        Me.lblMensajeCargaFuncionarios = New System.Windows.Forms.Label()
        Me.btnCancelarFuncionario = New System.Windows.Forms.Button()
        Me.btnActualizarFuncionario = New System.Windows.Forms.Button()
        Me.gridFuncionarios = New System.Windows.Forms.DataGridView()
        Me.btnNuevoFuncionarios = New System.Windows.Forms.Button()
        Me.btnGuardarFuncionarios = New System.Windows.Forms.Button()
        Me.gpBoxDatosFuncionarios = New System.Windows.Forms.GroupBox()
        Me.lblFuncionariosCargo = New System.Windows.Forms.Label()
        Me.lblFuncionariosApellidoMaterno = New System.Windows.Forms.Label()
        Me.lblFuncionariosCorreo = New System.Windows.Forms.Label()
        Me.lblFuncionariosTelefono = New System.Windows.Forms.Label()
        Me.txtFuncionariosNombre = New System.Windows.Forms.TextBox()
        Me.lblFuncionariosApellidoPaterno = New System.Windows.Forms.Label()
        Me.txtFuncionariosApellidoPaterno = New System.Windows.Forms.TextBox()
        Me.txtFuncionariosApellidoMaterno = New System.Windows.Forms.TextBox()
        Me.lblFuncionariosNombre = New System.Windows.Forms.Label()
        Me.txtFuncionariosCorreo = New System.Windows.Forms.TextBox()
        Me.txtFuncionariosCargo = New System.Windows.Forms.TextBox()
        Me.txtFuncionariosTelefono = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTituloFuncionarios = New System.Windows.Forms.Label()
        Me.panAccionistas = New System.Windows.Forms.Panel()
        Me.lblMensajeCargaAccionistas = New System.Windows.Forms.Label()
        Me.btnCancelarAccionistas = New System.Windows.Forms.Button()
        Me.btnActualizarAccionistas = New System.Windows.Forms.Button()
        Me.gridAccionistas = New System.Windows.Forms.DataGridView()
        Me.btnNuevoAccionista = New System.Windows.Forms.Button()
        Me.btnGuardarAccionistas = New System.Windows.Forms.Button()
        Me.gpBoxDatosAccionistas = New System.Windows.Forms.GroupBox()
        Me.lblAccionistasTipoPersona = New System.Windows.Forms.Label()
        Me.cboAccionistasTipoPersona = New System.Windows.Forms.ComboBox()
        Me.lblAccionistasPorcentaje = New System.Windows.Forms.Label()
        Me.lblAccionistasApellidoMaterno = New System.Windows.Forms.Label()
        Me.txtAccionistasNombre = New System.Windows.Forms.TextBox()
        Me.lblAccionistasApellidoPaterno = New System.Windows.Forms.Label()
        Me.txtAccionistasApellidoPaterno = New System.Windows.Forms.TextBox()
        Me.txtAccionistasApellidoMaterno = New System.Windows.Forms.TextBox()
        Me.lblAccionistasNombre = New System.Windows.Forms.Label()
        Me.txtAccionistasPorcentaje = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblTituloAccionistas = New System.Windows.Forms.Label()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.panMenu.SuspendLayout()
        Me.panDatosGenerales.SuspendLayout()
        Me.gpBoxDatosDG.SuspendLayout()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpBoxTipoNegocio.SuspendLayout()
        Me.gpBoxServicio.SuspendLayout()
        Me.panDivisiones.SuspendLayout()
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
        Me.gpBoxDatosContactoInicial.SuspendLayout()
        Me.panAcercamiento.SuspendLayout()
        Me.gpBoxDatosAcercamiento.SuspendLayout()
        Me.panDireccion.SuspendLayout()
        Me.gpBoxDatosDomicilio.SuspendLayout()
        Me.panFuncionarios.SuspendLayout()
        CType(Me.gridFuncionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpBoxDatosFuncionarios.SuspendLayout()
        Me.panAccionistas.SuspendLayout()
        CType(Me.gridAccionistas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpBoxDatosAccionistas.SuspendLayout()
        Me.SuspendLayout()
        '
        'panMenu
        '
        Me.panMenu.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panMenu.Controls.Add(Me.lblMensaje)
        Me.panMenu.Controls.Add(Me.txtClaveProspecto)
        Me.panMenu.Controls.Add(Me.lnkAccionistas)
        Me.panMenu.Controls.Add(Me.lnkFuncionarios)
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
        'lnkAccionistas
        '
        Me.lnkAccionistas.ActiveLinkColor = System.Drawing.Color.White
        Me.lnkAccionistas.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lnkAccionistas.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lnkAccionistas.ForeColor = System.Drawing.Color.White
        Me.lnkAccionistas.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lnkAccionistas.LinkColor = System.Drawing.Color.White
        Me.lnkAccionistas.Location = New System.Drawing.Point(0, 335)
        Me.lnkAccionistas.Name = "lnkAccionistas"
        Me.lnkAccionistas.Padding = New System.Windows.Forms.Padding(13, 0, 0, 0)
        Me.lnkAccionistas.Size = New System.Drawing.Size(212, 34)
        Me.lnkAccionistas.TabIndex = 9
        Me.lnkAccionistas.TabStop = True
        Me.lnkAccionistas.Tag = "6"
        Me.lnkAccionistas.Text = "Accionistas"
        Me.lnkAccionistas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAccionistas.Visible = False
        Me.lnkAccionistas.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        '
        'lnkFuncionarios
        '
        Me.lnkFuncionarios.ActiveLinkColor = System.Drawing.Color.White
        Me.lnkFuncionarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lnkFuncionarios.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lnkFuncionarios.ForeColor = System.Drawing.Color.White
        Me.lnkFuncionarios.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lnkFuncionarios.LinkColor = System.Drawing.Color.White
        Me.lnkFuncionarios.Location = New System.Drawing.Point(0, 291)
        Me.lnkFuncionarios.Name = "lnkFuncionarios"
        Me.lnkFuncionarios.Padding = New System.Windows.Forms.Padding(13, 0, 0, 0)
        Me.lnkFuncionarios.Size = New System.Drawing.Size(212, 34)
        Me.lnkFuncionarios.TabIndex = 8
        Me.lnkFuncionarios.TabStop = True
        Me.lnkFuncionarios.Tag = "5"
        Me.lnkFuncionarios.Text = "Funcionarios"
        Me.lnkFuncionarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkFuncionarios.Visible = False
        Me.lnkFuncionarios.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        '
        'lnkDireccion
        '
        Me.lnkDireccion.ActiveLinkColor = System.Drawing.Color.White
        Me.lnkDireccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lnkDireccion.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkDireccion.ForeColor = System.Drawing.Color.White
        Me.lnkDireccion.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkDireccion.LinkColor = System.Drawing.Color.White
        Me.lnkDireccion.Location = New System.Drawing.Point(0, 247)
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
        Me.lnkAcercamiento.Location = New System.Drawing.Point(0, 203)
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
        Me.lnkContactoInicial.Location = New System.Drawing.Point(0, 159)
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
        Me.lnkDatosGenerales.Location = New System.Drawing.Point(0, 115)
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
        Me.btnCerrar.Location = New System.Drawing.Point(1096, 668)
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
        Me.panDatosGenerales.AutoScrollMargin = New System.Drawing.Size(0, 10)
        Me.panDatosGenerales.BackColor = System.Drawing.Color.White
        Me.panDatosGenerales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panDatosGenerales.Controls.Add(Me.gpBoxDatosDG)
        Me.panDatosGenerales.Controls.Add(Me.lblMensajeCargaDatosGenerales)
        Me.panDatosGenerales.Controls.Add(Me.panLinea)
        Me.panDatosGenerales.Controls.Add(Me.lblTituloDatosGenerales)
        Me.panDatosGenerales.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.panDatosGenerales.Location = New System.Drawing.Point(212, 0)
        Me.panDatosGenerales.Name = "panDatosGenerales"
        Me.panDatosGenerales.Size = New System.Drawing.Size(1026, 660)
        Me.panDatosGenerales.TabIndex = 1
        Me.panDatosGenerales.Tag = "1"
        Me.panDatosGenerales.Visible = False
        '
        'gpBoxDatosDG
        '
        Me.gpBoxDatosDG.Controls.Add(Me.Lista)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxTipoNegocio)
        Me.gpBoxDatosDG.Controls.Add(Me.txtRazonSocial)
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
        Me.gpBoxDatosDG.Controls.Add(Me.lblMensajeErrorDatosGenerales)
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
        Me.gpBoxDatosDG.Size = New System.Drawing.Size(980, 1223)
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
        Me.Lista.Location = New System.Drawing.Point(172, 53)
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = True
        Me.Lista.RowHeadersWidth = 25
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.Lista.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Lista.RowTemplate.Height = 26
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(771, 270)
        Me.Lista.TabIndex = 2
        Me.Lista.Visible = False
        '
        'gpBoxTipoNegocio
        '
        Me.gpBoxTipoNegocio.Controls.Add(Me.rdPersonaFisica)
        Me.gpBoxTipoNegocio.Controls.Add(Me.rdPersonalMoral)
        Me.gpBoxTipoNegocio.Location = New System.Drawing.Point(515, 101)
        Me.gpBoxTipoNegocio.Name = "gpBoxTipoNegocio"
        Me.gpBoxTipoNegocio.Size = New System.Drawing.Size(428, 55)
        Me.gpBoxTipoNegocio.TabIndex = 7
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
        'txtRazonSocial
        '
        Me.txtRazonSocial.Location = New System.Drawing.Point(172, 29)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(771, 25)
        Me.txtRazonSocial.TabIndex = 1
        '
        'gpBoxServicio
        '
        Me.gpBoxServicio.Controls.Add(Me.panDivisiones)
        Me.gpBoxServicio.Controls.Add(Me.lblDescripcionSolicitud)
        Me.gpBoxServicio.Controls.Add(Me.txtDescripcionSolicitud)
        Me.gpBoxServicio.Enabled = False
        Me.gpBoxServicio.Location = New System.Drawing.Point(38, 230)
        Me.gpBoxServicio.Name = "gpBoxServicio"
        Me.gpBoxServicio.Size = New System.Drawing.Size(905, 232)
        Me.gpBoxServicio.TabIndex = 16
        Me.gpBoxServicio.TabStop = False
        Me.gpBoxServicio.Text = "Servicio"
        '
        'panDivisiones
        '
        Me.panDivisiones.Controls.Add(Me.rdAuditoria)
        Me.panDivisiones.Controls.Add(Me.rdIBC)
        Me.panDivisiones.Controls.Add(Me.rdPLD)
        Me.panDivisiones.Controls.Add(Me.rdJBG)
        Me.panDivisiones.Controls.Add(Me.rdImpuestos)
        Me.panDivisiones.Controls.Add(Me.rdComercioExterior)
        Me.panDivisiones.Controls.Add(Me.rdBAS)
        Me.panDivisiones.Controls.Add(Me.rdPreciosTransferencia)
        Me.panDivisiones.Controls.Add(Me.rdBPS)
        Me.panDivisiones.Enabled = False
        Me.panDivisiones.Location = New System.Drawing.Point(14, 24)
        Me.panDivisiones.Name = "panDivisiones"
        Me.panDivisiones.Size = New System.Drawing.Size(875, 78)
        Me.panDivisiones.TabIndex = 0
        '
        'rdAuditoria
        '
        Me.rdAuditoria.AutoSize = True
        Me.rdAuditoria.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdAuditoria.Location = New System.Drawing.Point(21, 12)
        Me.rdAuditoria.Name = "rdAuditoria"
        Me.rdAuditoria.Size = New System.Drawing.Size(83, 22)
        Me.rdAuditoria.TabIndex = 0
        Me.rdAuditoria.TabStop = True
        Me.rdAuditoria.Text = "Auditoría"
        Me.rdAuditoria.UseVisualStyleBackColor = True
        '
        'rdIBC
        '
        Me.rdIBC.AutoSize = True
        Me.rdIBC.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdIBC.Location = New System.Drawing.Point(550, 42)
        Me.rdIBC.Name = "rdIBC"
        Me.rdIBC.Size = New System.Drawing.Size(208, 22)
        Me.rdIBC.TabIndex = 8
        Me.rdIBC.TabStop = True
        Me.rdIBC.Text = "International Business Center"
        Me.rdIBC.UseVisualStyleBackColor = True
        Me.rdIBC.Visible = False
        '
        'rdPLD
        '
        Me.rdPLD.AutoSize = True
        Me.rdPLD.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdPLD.Location = New System.Drawing.Point(372, 42)
        Me.rdPLD.Name = "rdPLD"
        Me.rdPLD.Size = New System.Drawing.Size(225, 22)
        Me.rdPLD.TabIndex = 6
        Me.rdPLD.TabStop = True
        Me.rdPLD.Text = "Prevención de Lavado de Dinero"
        Me.rdPLD.UseVisualStyleBackColor = True
        '
        'rdJBG
        '
        Me.rdJBG.AutoSize = True
        Me.rdJBG.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdJBG.Location = New System.Drawing.Point(372, 42)
        Me.rdJBG.Name = "rdJBG"
        Me.rdJBG.Size = New System.Drawing.Size(159, 22)
        Me.rdJBG.TabIndex = 7
        Me.rdJBG.TabStop = True
        Me.rdJBG.Text = "Japan Business Group"
        Me.rdJBG.UseVisualStyleBackColor = True
        Me.rdJBG.Visible = False
        '
        'rdImpuestos
        '
        Me.rdImpuestos.AutoSize = True
        Me.rdImpuestos.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdImpuestos.Location = New System.Drawing.Point(132, 12)
        Me.rdImpuestos.Name = "rdImpuestos"
        Me.rdImpuestos.Size = New System.Drawing.Size(91, 22)
        Me.rdImpuestos.TabIndex = 1
        Me.rdImpuestos.TabStop = True
        Me.rdImpuestos.Text = "Impuestos"
        Me.rdImpuestos.UseVisualStyleBackColor = True
        '
        'rdComercioExterior
        '
        Me.rdComercioExterior.AutoSize = True
        Me.rdComercioExterior.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdComercioExterior.Location = New System.Drawing.Point(216, 42)
        Me.rdComercioExterior.Name = "rdComercioExterior"
        Me.rdComercioExterior.Size = New System.Drawing.Size(137, 22)
        Me.rdComercioExterior.TabIndex = 5
        Me.rdComercioExterior.TabStop = True
        Me.rdComercioExterior.Text = "Comercio Exterior"
        Me.rdComercioExterior.UseVisualStyleBackColor = True
        '
        'rdBAS
        '
        Me.rdBAS.AutoSize = True
        Me.rdBAS.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdBAS.Location = New System.Drawing.Point(251, 12)
        Me.rdBAS.Name = "rdBAS"
        Me.rdBAS.Size = New System.Drawing.Size(191, 22)
        Me.rdBAS.TabIndex = 2
        Me.rdBAS.TabStop = True
        Me.rdBAS.Text = "Business Advisory Services"
        Me.rdBAS.UseVisualStyleBackColor = True
        '
        'rdPreciosTransferencia
        '
        Me.rdPreciosTransferencia.AutoSize = True
        Me.rdPreciosTransferencia.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdPreciosTransferencia.Location = New System.Drawing.Point(21, 42)
        Me.rdPreciosTransferencia.Name = "rdPreciosTransferencia"
        Me.rdPreciosTransferencia.Size = New System.Drawing.Size(176, 22)
        Me.rdPreciosTransferencia.TabIndex = 4
        Me.rdPreciosTransferencia.TabStop = True
        Me.rdPreciosTransferencia.Text = "Precios de Transferencia"
        Me.rdPreciosTransferencia.UseVisualStyleBackColor = True
        '
        'rdBPS
        '
        Me.rdBPS.AutoSize = True
        Me.rdBPS.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdBPS.Location = New System.Drawing.Point(470, 12)
        Me.rdBPS.Name = "rdBPS"
        Me.rdBPS.Size = New System.Drawing.Size(190, 22)
        Me.rdBPS.TabIndex = 3
        Me.rdBPS.TabStop = True
        Me.rdBPS.Text = "Business Process Solutions"
        Me.rdBPS.UseVisualStyleBackColor = True
        '
        'lblDescripcionSolicitud
        '
        Me.lblDescripcionSolicitud.AutoSize = True
        Me.lblDescripcionSolicitud.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionSolicitud.Location = New System.Drawing.Point(14, 112)
        Me.lblDescripcionSolicitud.Name = "lblDescripcionSolicitud"
        Me.lblDescripcionSolicitud.Size = New System.Drawing.Size(221, 18)
        Me.lblDescripcionSolicitud.TabIndex = 1
        Me.lblDescripcionSolicitud.Text = "Descripción del servicio solicitado:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtDescripcionSolicitud
        '
        Me.txtDescripcionSolicitud.Location = New System.Drawing.Point(14, 136)
        Me.txtDescripcionSolicitud.Multiline = True
        Me.txtDescripcionSolicitud.Name = "txtDescripcionSolicitud"
        Me.txtDescripcionSolicitud.Size = New System.Drawing.Size(880, 81)
        Me.txtDescripcionSolicitud.TabIndex = 2
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.Location = New System.Drawing.Point(38, 104)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(35, 18)
        Me.lblRFC.TabIndex = 5
        Me.lblRFC.Text = "RFC:"
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(172, 101)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(274, 25)
        Me.txtRFC.TabIndex = 6
        '
        'btnSubnivel
        '
        Me.btnSubnivel.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubnivel.Location = New System.Drawing.Point(900, 188)
        Me.btnSubnivel.Name = "btnSubnivel"
        Me.btnSubnivel.Size = New System.Drawing.Size(43, 25)
        Me.btnSubnivel.TabIndex = 15
        Me.btnSubnivel.Text = "..."
        Me.btnSubnivel.UseVisualStyleBackColor = True
        '
        'btnSubsector
        '
        Me.btnSubsector.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubsector.Location = New System.Drawing.Point(556, 188)
        Me.btnSubsector.Name = "btnSubsector"
        Me.btnSubsector.Size = New System.Drawing.Size(43, 25)
        Me.btnSubsector.TabIndex = 13
        Me.btnSubsector.Text = "..."
        Me.btnSubsector.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(618, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 18)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Subnivel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(328, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 18)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Subsector"
        '
        'lblIndustria
        '
        Me.lblIndustria.AutoSize = True
        Me.lblIndustria.Location = New System.Drawing.Point(38, 165)
        Me.lblIndustria.Name = "lblIndustria"
        Me.lblIndustria.Size = New System.Drawing.Size(63, 18)
        Me.lblIndustria.TabIndex = 8
        Me.lblIndustria.Text = "Industria"
        '
        'btnIndustria
        '
        Me.btnIndustria.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIndustria.Location = New System.Drawing.Point(267, 188)
        Me.btnIndustria.Name = "btnIndustria"
        Me.btnIndustria.Size = New System.Drawing.Size(43, 25)
        Me.btnIndustria.TabIndex = 10
        Me.btnIndustria.Text = "..."
        Me.btnIndustria.UseVisualStyleBackColor = True
        '
        'txtSubnivel
        '
        Me.txtSubnivel.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.txtSubnivel.Location = New System.Drawing.Point(618, 188)
        Me.txtSubnivel.Name = "txtSubnivel"
        Me.txtSubnivel.ReadOnly = True
        Me.txtSubnivel.Size = New System.Drawing.Size(277, 24)
        Me.txtSubnivel.TabIndex = 14
        '
        'gpBoxSubsidiaria
        '
        Me.gpBoxSubsidiaria.Controls.Add(Me.lblSubsidiaria)
        Me.gpBoxSubsidiaria.Controls.Add(Me.lblControladora)
        Me.gpBoxSubsidiaria.Controls.Add(Me.panRDSubsidiaria)
        Me.gpBoxSubsidiaria.Controls.Add(Me.panRDCompañiaControl)
        Me.gpBoxSubsidiaria.Location = New System.Drawing.Point(556, 523)
        Me.gpBoxSubsidiaria.Name = "gpBoxSubsidiaria"
        Me.gpBoxSubsidiaria.Size = New System.Drawing.Size(387, 112)
        Me.gpBoxSubsidiaria.TabIndex = 21
        Me.gpBoxSubsidiaria.TabStop = False
        '
        'lblSubsidiaria
        '
        Me.lblSubsidiaria.AutoSize = True
        Me.lblSubsidiaria.Location = New System.Drawing.Point(20, 27)
        Me.lblSubsidiaria.Name = "lblSubsidiaria"
        Me.lblSubsidiaria.Size = New System.Drawing.Size(90, 18)
        Me.lblSubsidiaria.TabIndex = 9
        Me.lblSubsidiaria.Text = "¿Subsidiaria?"
        '
        'lblControladora
        '
        Me.lblControladora.Location = New System.Drawing.Point(20, 57)
        Me.lblControladora.Name = "lblControladora"
        Me.lblControladora.Size = New System.Drawing.Size(163, 40)
        Me.lblControladora.TabIndex = 12
        Me.lblControladora.Text = "¿Reportará a su compañia controladora?"
        '
        'panRDSubsidiaria
        '
        Me.panRDSubsidiaria.Controls.Add(Me.rdSubsidiariaSi)
        Me.panRDSubsidiaria.Controls.Add(Me.rdSubsidiariaNo)
        Me.panRDSubsidiaria.Location = New System.Drawing.Point(192, 19)
        Me.panRDSubsidiaria.Name = "panRDSubsidiaria"
        Me.panRDSubsidiaria.Size = New System.Drawing.Size(122, 35)
        Me.panRDSubsidiaria.TabIndex = 328
        '
        'rdSubsidiariaSi
        '
        Me.rdSubsidiariaSi.AutoSize = True
        Me.rdSubsidiariaSi.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdSubsidiariaSi.Location = New System.Drawing.Point(9, 6)
        Me.rdSubsidiariaSi.Name = "rdSubsidiariaSi"
        Me.rdSubsidiariaSi.Size = New System.Drawing.Size(36, 22)
        Me.rdSubsidiariaSi.TabIndex = 10
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
        Me.rdSubsidiariaNo.TabIndex = 11
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
        Me.panRDCompañiaControl.TabIndex = 329
        '
        'rdControladoraSi
        '
        Me.rdControladoraSi.AutoSize = True
        Me.rdControladoraSi.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdControladoraSi.Location = New System.Drawing.Point(9, 6)
        Me.rdControladoraSi.Name = "rdControladoraSi"
        Me.rdControladoraSi.Size = New System.Drawing.Size(36, 22)
        Me.rdControladoraSi.TabIndex = 13
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
        Me.rdControladoraNO.TabIndex = 14
        Me.rdControladoraNO.Text = "No"
        Me.rdControladoraNO.UseVisualStyleBackColor = True
        '
        'lblMensajeErrorDatosGenerales
        '
        Me.lblMensajeErrorDatosGenerales.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lblMensajeErrorDatosGenerales.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMensajeErrorDatosGenerales.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeErrorDatosGenerales.ForeColor = System.Drawing.Color.White
        Me.lblMensajeErrorDatosGenerales.Location = New System.Drawing.Point(3, 1195)
        Me.lblMensajeErrorDatosGenerales.Name = "lblMensajeErrorDatosGenerales"
        Me.lblMensajeErrorDatosGenerales.Size = New System.Drawing.Size(974, 25)
        Me.lblMensajeErrorDatosGenerales.TabIndex = 26
        Me.lblMensajeErrorDatosGenerales.Text = "Mensaje de error"
        Me.lblMensajeErrorDatosGenerales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeErrorDatosGenerales.Visible = False
        '
        'txtSubsector
        '
        Me.txtSubsector.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.txtSubsector.Location = New System.Drawing.Point(328, 188)
        Me.txtSubsector.Name = "txtSubsector"
        Me.txtSubsector.ReadOnly = True
        Me.txtSubsector.Size = New System.Drawing.Size(222, 24)
        Me.txtSubsector.TabIndex = 12
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(38, 32)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(87, 18)
        Me.lblRazonSocial.TabIndex = 0
        Me.lblRazonSocial.Text = "Razón social:"
        '
        'lblNombreComercial
        '
        Me.lblNombreComercial.AutoSize = True
        Me.lblNombreComercial.Location = New System.Drawing.Point(38, 69)
        Me.lblNombreComercial.Name = "lblNombreComercial"
        Me.lblNombreComercial.Size = New System.Drawing.Size(126, 18)
        Me.lblNombreComercial.TabIndex = 3
        Me.lblNombreComercial.Text = "Nombre comercial:"
        '
        'txtNombreComercial
        '
        Me.txtNombreComercial.Location = New System.Drawing.Point(172, 65)
        Me.txtNombreComercial.Name = "txtNombreComercial"
        Me.txtNombreComercial.Size = New System.Drawing.Size(771, 25)
        Me.txtNombreComercial.TabIndex = 4
        '
        'txtIndustria
        '
        Me.txtIndustria.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.txtIndustria.Location = New System.Drawing.Point(38, 188)
        Me.txtIndustria.Name = "txtIndustria"
        Me.txtIndustria.ReadOnly = True
        Me.txtIndustria.Size = New System.Drawing.Size(222, 24)
        Me.txtIndustria.TabIndex = 9
        '
        'gpBoxEmpresaPublica
        '
        Me.gpBoxEmpresaPublica.Controls.Add(Me.lblBolsaValoresOtra)
        Me.gpBoxEmpresaPublica.Controls.Add(Me.lblBolsaValores)
        Me.gpBoxEmpresaPublica.Controls.Add(Me.rdEmpresaPublicaNo)
        Me.gpBoxEmpresaPublica.Controls.Add(Me.rdEmpresaPublicaSi)
        Me.gpBoxEmpresaPublica.Controls.Add(Me.txtBolsaValoresOtro)
        Me.gpBoxEmpresaPublica.Controls.Add(Me.cboBolsaValores)
        Me.gpBoxEmpresaPublica.Location = New System.Drawing.Point(38, 523)
        Me.gpBoxEmpresaPublica.Name = "gpBoxEmpresaPublica"
        Me.gpBoxEmpresaPublica.Size = New System.Drawing.Size(506, 112)
        Me.gpBoxEmpresaPublica.TabIndex = 20
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
        Me.gpBoxEntidadReguladora.Location = New System.Drawing.Point(38, 651)
        Me.gpBoxEntidadReguladora.Name = "gpBoxEntidadReguladora"
        Me.gpBoxEntidadReguladora.Size = New System.Drawing.Size(506, 89)
        Me.gpBoxEntidadReguladora.TabIndex = 22
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
        Me.gpBoxEntidadSupervisada.Location = New System.Drawing.Point(38, 752)
        Me.gpBoxEntidadSupervisada.Name = "gpBoxEntidadSupervisada"
        Me.gpBoxEntidadSupervisada.Size = New System.Drawing.Size(506, 89)
        Me.gpBoxEntidadSupervisada.TabIndex = 23
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
        Me.cboPais.Location = New System.Drawing.Point(78, 483)
        Me.cboPais.Name = "cboPais"
        Me.cboPais.Size = New System.Drawing.Size(293, 26)
        Me.cboPais.TabIndex = 19
        '
        'gpBoxReferenciaGTI
        '
        Me.gpBoxReferenciaGTI.Controls.Add(Me.cboReferenciaGTIOficina)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.cboReferenciaGTIPais)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.lblReferenciaGTIPais)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.lblRefGTIOficina)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.txtReferenciaGTISocio)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.lbRefGTISocio)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.rdReferenciaGTINo)
        Me.gpBoxReferenciaGTI.Controls.Add(Me.rdReferenciaGTISi)
        Me.gpBoxReferenciaGTI.Location = New System.Drawing.Point(38, 859)
        Me.gpBoxReferenciaGTI.Name = "gpBoxReferenciaGTI"
        Me.gpBoxReferenciaGTI.Size = New System.Drawing.Size(905, 115)
        Me.gpBoxReferenciaGTI.TabIndex = 24
        Me.gpBoxReferenciaGTI.TabStop = False
        Me.gpBoxReferenciaGTI.Text = "Referencia GTI"
        '
        'cboReferenciaGTIOficina
        '
        Me.cboReferenciaGTIOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReferenciaGTIOficina.FormattingEnabled = True
        Me.cboReferenciaGTIOficina.Location = New System.Drawing.Point(642, 55)
        Me.cboReferenciaGTIOficina.Name = "cboReferenciaGTIOficina"
        Me.cboReferenciaGTIOficina.Size = New System.Drawing.Size(214, 26)
        Me.cboReferenciaGTIOficina.TabIndex = 7
        '
        'cboReferenciaGTIPais
        '
        Me.cboReferenciaGTIPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReferenciaGTIPais.DropDownWidth = 260
        Me.cboReferenciaGTIPais.FormattingEnabled = True
        Me.cboReferenciaGTIPais.Location = New System.Drawing.Point(420, 55)
        Me.cboReferenciaGTIPais.Name = "cboReferenciaGTIPais"
        Me.cboReferenciaGTIPais.Size = New System.Drawing.Size(206, 26)
        Me.cboReferenciaGTIPais.TabIndex = 5
        '
        'lblReferenciaGTIPais
        '
        Me.lblReferenciaGTIPais.AutoSize = True
        Me.lblReferenciaGTIPais.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblReferenciaGTIPais.Location = New System.Drawing.Point(420, 33)
        Me.lblReferenciaGTIPais.Name = "lblReferenciaGTIPais"
        Me.lblReferenciaGTIPais.Size = New System.Drawing.Size(32, 18)
        Me.lblReferenciaGTIPais.TabIndex = 4
        Me.lblReferenciaGTIPais.Text = "País"
        '
        'lblRefGTIOficina
        '
        Me.lblRefGTIOficina.AutoSize = True
        Me.lblRefGTIOficina.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblRefGTIOficina.Location = New System.Drawing.Point(642, 33)
        Me.lblRefGTIOficina.Name = "lblRefGTIOficina"
        Me.lblRefGTIOficina.Size = New System.Drawing.Size(51, 18)
        Me.lblRefGTIOficina.TabIndex = 6
        Me.lblRefGTIOficina.Text = "Oficina"
        '
        'txtReferenciaGTISocio
        '
        Me.txtReferenciaGTISocio.Location = New System.Drawing.Point(128, 56)
        Me.txtReferenciaGTISocio.Name = "txtReferenciaGTISocio"
        Me.txtReferenciaGTISocio.Size = New System.Drawing.Size(276, 25)
        Me.txtReferenciaGTISocio.TabIndex = 3
        '
        'lbRefGTISocio
        '
        Me.lbRefGTISocio.AutoSize = True
        Me.lbRefGTISocio.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lbRefGTISocio.Location = New System.Drawing.Point(128, 33)
        Me.lbRefGTISocio.Name = "lbRefGTISocio"
        Me.lbRefGTISocio.Size = New System.Drawing.Size(41, 18)
        Me.lbRefGTISocio.TabIndex = 2
        Me.lbRefGTISocio.Text = "Socio"
        '
        'rdReferenciaGTINo
        '
        Me.rdReferenciaGTINo.AutoSize = True
        Me.rdReferenciaGTINo.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdReferenciaGTINo.Location = New System.Drawing.Point(63, 52)
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
        Me.rdReferenciaGTISi.Location = New System.Drawing.Point(18, 52)
        Me.rdReferenciaGTISi.Name = "rdReferenciaGTISi"
        Me.rdReferenciaGTISi.Size = New System.Drawing.Size(36, 22)
        Me.rdReferenciaGTISi.TabIndex = 0
        Me.rdReferenciaGTISi.Text = "Sí"
        Me.rdReferenciaGTISi.UseVisualStyleBackColor = True
        '
        'lblPais
        '
        Me.lblPais.AutoSize = True
        Me.lblPais.Location = New System.Drawing.Point(38, 487)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(37, 18)
        Me.lblPais.TabIndex = 18
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
        Me.gpBoxEmpresaExtranjero.Location = New System.Drawing.Point(38, 987)
        Me.gpBoxEmpresaExtranjero.Name = "gpBoxEmpresaExtranjero"
        Me.gpBoxEmpresaExtranjero.Size = New System.Drawing.Size(905, 193)
        Me.gpBoxEmpresaExtranjero.TabIndex = 25
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
        Me.lblMensajeCargaDatosGenerales.Size = New System.Drawing.Size(1024, 25)
        Me.lblMensajeCargaDatosGenerales.TabIndex = 2
        Me.lblMensajeCargaDatosGenerales.Text = "No se ha cargado información de los Datos Generales para el prospecto."
        Me.lblMensajeCargaDatosGenerales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeCargaDatosGenerales.Visible = False
        '
        'panLinea
        '
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(9, 32)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(300, 3)
        Me.panLinea.TabIndex = 1
        '
        'lblTituloDatosGenerales
        '
        Me.lblTituloDatosGenerales.AutoSize = True
        Me.lblTituloDatosGenerales.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloDatosGenerales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloDatosGenerales.Location = New System.Drawing.Point(9, 5)
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
        Me.panContactoInicial.Controls.Add(Me.btnCancelarContactoInicial)
        Me.panContactoInicial.Controls.Add(Me.btnGuardarContactoInicial)
        Me.panContactoInicial.Controls.Add(Me.btnRegistroContactoInicial)
        Me.panContactoInicial.Controls.Add(Me.lblMensajeErrorContactoInicial)
        Me.panContactoInicial.Controls.Add(Me.gpBoxDatosContactoInicial)
        Me.panContactoInicial.Controls.Add(Me.Panel1)
        Me.panContactoInicial.Controls.Add(Me.lblTituloCI)
        Me.panContactoInicial.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.panContactoInicial.Location = New System.Drawing.Point(212, 0)
        Me.panContactoInicial.Name = "panContactoInicial"
        Me.panContactoInicial.Size = New System.Drawing.Size(1026, 660)
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
        Me.lblMensajeCargaContactoInicial.Size = New System.Drawing.Size(1024, 25)
        Me.lblMensajeCargaContactoInicial.TabIndex = 6
        Me.lblMensajeCargaContactoInicial.Text = "No se ha cargado información de Contacto Inicial para el prospecto."
        Me.lblMensajeCargaContactoInicial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeCargaContactoInicial.Visible = False
        '
        'btnCancelarContactoInicial
        '
        Me.btnCancelarContactoInicial.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarContactoInicial.Location = New System.Drawing.Point(625, 327)
        Me.btnCancelarContactoInicial.Name = "btnCancelarContactoInicial"
        Me.btnCancelarContactoInicial.Size = New System.Drawing.Size(130, 25)
        Me.btnCancelarContactoInicial.TabIndex = 2
        Me.btnCancelarContactoInicial.Text = "Cancelar"
        Me.btnCancelarContactoInicial.UseVisualStyleBackColor = True
        Me.btnCancelarContactoInicial.Visible = False
        '
        'btnGuardarContactoInicial
        '
        Me.btnGuardarContactoInicial.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarContactoInicial.Location = New System.Drawing.Point(765, 327)
        Me.btnGuardarContactoInicial.Name = "btnGuardarContactoInicial"
        Me.btnGuardarContactoInicial.Size = New System.Drawing.Size(130, 25)
        Me.btnGuardarContactoInicial.TabIndex = 3
        Me.btnGuardarContactoInicial.Text = "Guardar"
        Me.btnGuardarContactoInicial.UseVisualStyleBackColor = True
        Me.btnGuardarContactoInicial.Visible = False
        '
        'btnRegistroContactoInicial
        '
        Me.btnRegistroContactoInicial.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistroContactoInicial.Location = New System.Drawing.Point(75, 327)
        Me.btnRegistroContactoInicial.Name = "btnRegistroContactoInicial"
        Me.btnRegistroContactoInicial.Size = New System.Drawing.Size(130, 25)
        Me.btnRegistroContactoInicial.TabIndex = 1
        Me.btnRegistroContactoInicial.Text = "Registrar"
        Me.btnRegistroContactoInicial.UseVisualStyleBackColor = True
        Me.btnRegistroContactoInicial.Visible = False
        '
        'lblMensajeErrorContactoInicial
        '
        Me.lblMensajeErrorContactoInicial.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lblMensajeErrorContactoInicial.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMensajeErrorContactoInicial.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeErrorContactoInicial.ForeColor = System.Drawing.Color.White
        Me.lblMensajeErrorContactoInicial.Location = New System.Drawing.Point(0, 633)
        Me.lblMensajeErrorContactoInicial.Name = "lblMensajeErrorContactoInicial"
        Me.lblMensajeErrorContactoInicial.Size = New System.Drawing.Size(1024, 25)
        Me.lblMensajeErrorContactoInicial.TabIndex = 5
        Me.lblMensajeErrorContactoInicial.Text = "Mensaje de error"
        Me.lblMensajeErrorContactoInicial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeErrorContactoInicial.Visible = False
        '
        'gpBoxDatosContactoInicial
        '
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.lblContactoInicialNombre)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.txtContactoInicialExtension)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.txtContactoInicialNombre)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.lblContactoInicialExtension)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.lblContactoInicialCargo)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.txtContactoInicialTelefono)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.txtContactoInicialCargo)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.lblContactoInicialTelefono)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.lblContactoInicialCorreo)
        Me.gpBoxDatosContactoInicial.Controls.Add(Me.txtContactoInicialCorreo)
        Me.gpBoxDatosContactoInicial.Enabled = False
        Me.gpBoxDatosContactoInicial.Location = New System.Drawing.Point(75, 72)
        Me.gpBoxDatosContactoInicial.Name = "gpBoxDatosContactoInicial"
        Me.gpBoxDatosContactoInicial.Size = New System.Drawing.Size(820, 244)
        Me.gpBoxDatosContactoInicial.TabIndex = 0
        Me.gpBoxDatosContactoInicial.TabStop = False
        '
        'lblContactoInicialNombre
        '
        Me.lblContactoInicialNombre.AutoSize = True
        Me.lblContactoInicialNombre.Location = New System.Drawing.Point(79, 61)
        Me.lblContactoInicialNombre.Name = "lblContactoInicialNombre"
        Me.lblContactoInicialNombre.Size = New System.Drawing.Size(59, 18)
        Me.lblContactoInicialNombre.TabIndex = 0
        Me.lblContactoInicialNombre.Text = "Nombre"
        '
        'txtContactoInicialExtension
        '
        Me.txtContactoInicialExtension.Location = New System.Drawing.Point(577, 159)
        Me.txtContactoInicialExtension.Name = "txtContactoInicialExtension"
        Me.txtContactoInicialExtension.Size = New System.Drawing.Size(92, 25)
        Me.txtContactoInicialExtension.TabIndex = 9
        '
        'txtContactoInicialNombre
        '
        Me.txtContactoInicialNombre.Location = New System.Drawing.Point(79, 84)
        Me.txtContactoInicialNombre.Name = "txtContactoInicialNombre"
        Me.txtContactoInicialNombre.Size = New System.Drawing.Size(332, 25)
        Me.txtContactoInicialNombre.TabIndex = 1
        '
        'lblContactoInicialExtension
        '
        Me.lblContactoInicialExtension.AutoSize = True
        Me.lblContactoInicialExtension.Location = New System.Drawing.Point(577, 136)
        Me.lblContactoInicialExtension.Name = "lblContactoInicialExtension"
        Me.lblContactoInicialExtension.Size = New System.Drawing.Size(69, 18)
        Me.lblContactoInicialExtension.TabIndex = 8
        Me.lblContactoInicialExtension.Text = "Extensión"
        '
        'lblContactoInicialCargo
        '
        Me.lblContactoInicialCargo.AutoSize = True
        Me.lblContactoInicialCargo.Location = New System.Drawing.Point(436, 61)
        Me.lblContactoInicialCargo.Name = "lblContactoInicialCargo"
        Me.lblContactoInicialCargo.Size = New System.Drawing.Size(139, 18)
        Me.lblContactoInicialCargo.TabIndex = 2
        Me.lblContactoInicialCargo.Text = "Cargo en la compañia"
        '
        'txtContactoInicialTelefono
        '
        Me.txtContactoInicialTelefono.Location = New System.Drawing.Point(436, 159)
        Me.txtContactoInicialTelefono.Name = "txtContactoInicialTelefono"
        Me.txtContactoInicialTelefono.Size = New System.Drawing.Size(128, 25)
        Me.txtContactoInicialTelefono.TabIndex = 7
        '
        'txtContactoInicialCargo
        '
        Me.txtContactoInicialCargo.Location = New System.Drawing.Point(436, 84)
        Me.txtContactoInicialCargo.Name = "txtContactoInicialCargo"
        Me.txtContactoInicialCargo.Size = New System.Drawing.Size(305, 25)
        Me.txtContactoInicialCargo.TabIndex = 3
        '
        'lblContactoInicialTelefono
        '
        Me.lblContactoInicialTelefono.AutoSize = True
        Me.lblContactoInicialTelefono.Location = New System.Drawing.Point(436, 136)
        Me.lblContactoInicialTelefono.Name = "lblContactoInicialTelefono"
        Me.lblContactoInicialTelefono.Size = New System.Drawing.Size(63, 18)
        Me.lblContactoInicialTelefono.TabIndex = 6
        Me.lblContactoInicialTelefono.Text = "Teléfono"
        '
        'lblContactoInicialCorreo
        '
        Me.lblContactoInicialCorreo.AutoSize = True
        Me.lblContactoInicialCorreo.Location = New System.Drawing.Point(79, 136)
        Me.lblContactoInicialCorreo.Name = "lblContactoInicialCorreo"
        Me.lblContactoInicialCorreo.Size = New System.Drawing.Size(123, 18)
        Me.lblContactoInicialCorreo.TabIndex = 4
        Me.lblContactoInicialCorreo.Text = "Correo electrónico"
        '
        'txtContactoInicialCorreo
        '
        Me.txtContactoInicialCorreo.Location = New System.Drawing.Point(79, 159)
        Me.txtContactoInicialCorreo.Name = "txtContactoInicialCorreo"
        Me.txtContactoInicialCorreo.Size = New System.Drawing.Size(332, 25)
        Me.txtContactoInicialCorreo.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(9, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 3)
        Me.Panel1.TabIndex = 1
        '
        'lblTituloCI
        '
        Me.lblTituloCI.AutoSize = True
        Me.lblTituloCI.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloCI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloCI.Location = New System.Drawing.Point(9, 5)
        Me.lblTituloCI.Name = "lblTituloCI"
        Me.lblTituloCI.Size = New System.Drawing.Size(200, 29)
        Me.lblTituloCI.TabIndex = 0
        Me.lblTituloCI.Text = "CONTACTO INICIAL"
        '
        'panAcercamiento
        '
        Me.panAcercamiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panAcercamiento.BackColor = System.Drawing.Color.White
        Me.panAcercamiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panAcercamiento.Controls.Add(Me.lblMensajeCargaAcercamiento)
        Me.panAcercamiento.Controls.Add(Me.lblMensajeErrorAcercamiento)
        Me.panAcercamiento.Controls.Add(Me.btnCancelarAcercamiento)
        Me.panAcercamiento.Controls.Add(Me.btnGuardarAcercamiento)
        Me.panAcercamiento.Controls.Add(Me.btnRegistroAcercamiento)
        Me.panAcercamiento.Controls.Add(Me.gpBoxDatosAcercamiento)
        Me.panAcercamiento.Controls.Add(Me.Panel2)
        Me.panAcercamiento.Controls.Add(Me.lblTituloAcercamiento)
        Me.panAcercamiento.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panAcercamiento.Location = New System.Drawing.Point(212, 0)
        Me.panAcercamiento.Name = "panAcercamiento"
        Me.panAcercamiento.Size = New System.Drawing.Size(1026, 660)
        Me.panAcercamiento.TabIndex = 6
        Me.panAcercamiento.Tag = "3"
        Me.panAcercamiento.Visible = False
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
        Me.lblMensajeCargaAcercamiento.Size = New System.Drawing.Size(1024, 25)
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
        Me.lblMensajeErrorAcercamiento.Size = New System.Drawing.Size(1024, 25)
        Me.lblMensajeErrorAcercamiento.TabIndex = 4
        Me.lblMensajeErrorAcercamiento.Text = "Mensaje de error"
        Me.lblMensajeErrorAcercamiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeErrorAcercamiento.Visible = False
        '
        'btnCancelarAcercamiento
        '
        Me.btnCancelarAcercamiento.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAcercamiento.Location = New System.Drawing.Point(691, 360)
        Me.btnCancelarAcercamiento.Name = "btnCancelarAcercamiento"
        Me.btnCancelarAcercamiento.Size = New System.Drawing.Size(130, 25)
        Me.btnCancelarAcercamiento.TabIndex = 2
        Me.btnCancelarAcercamiento.Text = "Cancelar"
        Me.btnCancelarAcercamiento.UseVisualStyleBackColor = True
        Me.btnCancelarAcercamiento.Visible = False
        '
        'btnGuardarAcercamiento
        '
        Me.btnGuardarAcercamiento.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarAcercamiento.Location = New System.Drawing.Point(831, 360)
        Me.btnGuardarAcercamiento.Name = "btnGuardarAcercamiento"
        Me.btnGuardarAcercamiento.Size = New System.Drawing.Size(130, 25)
        Me.btnGuardarAcercamiento.TabIndex = 3
        Me.btnGuardarAcercamiento.Text = "Guardar"
        Me.btnGuardarAcercamiento.UseVisualStyleBackColor = True
        Me.btnGuardarAcercamiento.Visible = False
        '
        'btnRegistroAcercamiento
        '
        Me.btnRegistroAcercamiento.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistroAcercamiento.Location = New System.Drawing.Point(63, 360)
        Me.btnRegistroAcercamiento.Name = "btnRegistroAcercamiento"
        Me.btnRegistroAcercamiento.Size = New System.Drawing.Size(130, 25)
        Me.btnRegistroAcercamiento.TabIndex = 1
        Me.btnRegistroAcercamiento.Text = "Registrar"
        Me.btnRegistroAcercamiento.UseVisualStyleBackColor = True
        Me.btnRegistroAcercamiento.Visible = False
        '
        'gpBoxDatosAcercamiento
        '
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblAcercamientoWebProspecto)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblMedioContactoOtro)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblAcercamientoOtro)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.txtAcercamientoWebProspecto)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.cboAcercamientoMedioContacto)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblAcercamientoComoEntero)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.txtAcercamientoEnteroOtro)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.cboAcercamientoComoEntero)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblAcercamientoMedioContacto)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.txtAcercamientoContactoOtro)
        Me.gpBoxDatosAcercamiento.Enabled = False
        Me.gpBoxDatosAcercamiento.Location = New System.Drawing.Point(63, 80)
        Me.gpBoxDatosAcercamiento.Name = "gpBoxDatosAcercamiento"
        Me.gpBoxDatosAcercamiento.Size = New System.Drawing.Size(898, 266)
        Me.gpBoxDatosAcercamiento.TabIndex = 0
        Me.gpBoxDatosAcercamiento.TabStop = False
        '
        'lblAcercamientoWebProspecto
        '
        Me.lblAcercamientoWebProspecto.AutoSize = True
        Me.lblAcercamientoWebProspecto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcercamientoWebProspecto.Location = New System.Drawing.Point(128, 180)
        Me.lblAcercamientoWebProspecto.Name = "lblAcercamientoWebProspecto"
        Me.lblAcercamientoWebProspecto.Size = New System.Drawing.Size(167, 18)
        Me.lblAcercamientoWebProspecto.TabIndex = 8
        Me.lblAcercamientoWebProspecto.Text = "Página web del prospecto"
        '
        'lblMedioContactoOtro
        '
        Me.lblMedioContactoOtro.AutoSize = True
        Me.lblMedioContactoOtro.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedioContactoOtro.Location = New System.Drawing.Point(474, 103)
        Me.lblMedioContactoOtro.Name = "lblMedioContactoOtro"
        Me.lblMedioContactoOtro.Size = New System.Drawing.Size(36, 18)
        Me.lblMedioContactoOtro.TabIndex = 6
        Me.lblMedioContactoOtro.Text = "Otro"
        '
        'lblAcercamientoOtro
        '
        Me.lblAcercamientoOtro.AutoSize = True
        Me.lblAcercamientoOtro.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcercamientoOtro.Location = New System.Drawing.Point(474, 35)
        Me.lblAcercamientoOtro.Name = "lblAcercamientoOtro"
        Me.lblAcercamientoOtro.Size = New System.Drawing.Size(36, 18)
        Me.lblAcercamientoOtro.TabIndex = 2
        Me.lblAcercamientoOtro.Text = "Otro"
        '
        'txtAcercamientoWebProspecto
        '
        Me.txtAcercamientoWebProspecto.Location = New System.Drawing.Point(128, 206)
        Me.txtAcercamientoWebProspecto.Name = "txtAcercamientoWebProspecto"
        Me.txtAcercamientoWebProspecto.Size = New System.Drawing.Size(332, 25)
        Me.txtAcercamientoWebProspecto.TabIndex = 9
        '
        'cboAcercamientoMedioContacto
        '
        Me.cboAcercamientoMedioContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAcercamientoMedioContacto.FormattingEnabled = True
        Me.cboAcercamientoMedioContacto.Location = New System.Drawing.Point(128, 129)
        Me.cboAcercamientoMedioContacto.Name = "cboAcercamientoMedioContacto"
        Me.cboAcercamientoMedioContacto.Size = New System.Drawing.Size(332, 26)
        Me.cboAcercamientoMedioContacto.TabIndex = 5
        '
        'lblAcercamientoComoEntero
        '
        Me.lblAcercamientoComoEntero.AutoSize = True
        Me.lblAcercamientoComoEntero.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcercamientoComoEntero.Location = New System.Drawing.Point(128, 35)
        Me.lblAcercamientoComoEntero.Name = "lblAcercamientoComoEntero"
        Me.lblAcercamientoComoEntero.Size = New System.Drawing.Size(196, 18)
        Me.lblAcercamientoComoEntero.TabIndex = 0
        Me.lblAcercamientoComoEntero.Text = "¿Cómo se enteró de nosotros?"
        '
        'txtAcercamientoEnteroOtro
        '
        Me.txtAcercamientoEnteroOtro.Enabled = False
        Me.txtAcercamientoEnteroOtro.Location = New System.Drawing.Point(474, 62)
        Me.txtAcercamientoEnteroOtro.Name = "txtAcercamientoEnteroOtro"
        Me.txtAcercamientoEnteroOtro.Size = New System.Drawing.Size(297, 25)
        Me.txtAcercamientoEnteroOtro.TabIndex = 3
        '
        'cboAcercamientoComoEntero
        '
        Me.cboAcercamientoComoEntero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAcercamientoComoEntero.FormattingEnabled = True
        Me.cboAcercamientoComoEntero.Location = New System.Drawing.Point(128, 61)
        Me.cboAcercamientoComoEntero.Name = "cboAcercamientoComoEntero"
        Me.cboAcercamientoComoEntero.Size = New System.Drawing.Size(332, 26)
        Me.cboAcercamientoComoEntero.TabIndex = 1
        '
        'lblAcercamientoMedioContacto
        '
        Me.lblAcercamientoMedioContacto.AutoSize = True
        Me.lblAcercamientoMedioContacto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcercamientoMedioContacto.Location = New System.Drawing.Point(128, 103)
        Me.lblAcercamientoMedioContacto.Name = "lblAcercamientoMedioContacto"
        Me.lblAcercamientoMedioContacto.Size = New System.Drawing.Size(124, 18)
        Me.lblAcercamientoMedioContacto.TabIndex = 4
        Me.lblAcercamientoMedioContacto.Text = "Medio de contacto"
        '
        'txtAcercamientoContactoOtro
        '
        Me.txtAcercamientoContactoOtro.Enabled = False
        Me.txtAcercamientoContactoOtro.Location = New System.Drawing.Point(474, 129)
        Me.txtAcercamientoContactoOtro.Name = "txtAcercamientoContactoOtro"
        Me.txtAcercamientoContactoOtro.Size = New System.Drawing.Size(297, 25)
        Me.txtAcercamientoContactoOtro.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(9, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(300, 3)
        Me.Panel2.TabIndex = 1
        '
        'lblTituloAcercamiento
        '
        Me.lblTituloAcercamiento.AutoSize = True
        Me.lblTituloAcercamiento.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloAcercamiento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloAcercamiento.Location = New System.Drawing.Point(9, 5)
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
        Me.panDireccion.Controls.Add(Me.btnCancelarDomicilio)
        Me.panDireccion.Controls.Add(Me.btnGuardarDomicilio)
        Me.panDireccion.Controls.Add(Me.btnRegistroDomicilio)
        Me.panDireccion.Controls.Add(Me.lblMensajeErrorDomicilio)
        Me.panDireccion.Controls.Add(Me.lblMensajeCargaDomicilio)
        Me.panDireccion.Controls.Add(Me.Panel3)
        Me.panDireccion.Controls.Add(Me.lblTituloDomicilio)
        Me.panDireccion.Controls.Add(Me.gpBoxDatosDomicilio)
        Me.panDireccion.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panDireccion.Location = New System.Drawing.Point(212, 0)
        Me.panDireccion.Name = "panDireccion"
        Me.panDireccion.Size = New System.Drawing.Size(1026, 660)
        Me.panDireccion.TabIndex = 0
        Me.panDireccion.Tag = "4"
        Me.panDireccion.Visible = False
        '
        'btnCancelarDomicilio
        '
        Me.btnCancelarDomicilio.Enabled = False
        Me.btnCancelarDomicilio.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarDomicilio.Location = New System.Drawing.Point(625, 468)
        Me.btnCancelarDomicilio.Name = "btnCancelarDomicilio"
        Me.btnCancelarDomicilio.Size = New System.Drawing.Size(130, 25)
        Me.btnCancelarDomicilio.TabIndex = 4
        Me.btnCancelarDomicilio.Text = "Cancelar"
        Me.btnCancelarDomicilio.UseVisualStyleBackColor = True
        Me.btnCancelarDomicilio.Visible = False
        '
        'btnGuardarDomicilio
        '
        Me.btnGuardarDomicilio.Enabled = False
        Me.btnGuardarDomicilio.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarDomicilio.Location = New System.Drawing.Point(765, 468)
        Me.btnGuardarDomicilio.Name = "btnGuardarDomicilio"
        Me.btnGuardarDomicilio.Size = New System.Drawing.Size(130, 25)
        Me.btnGuardarDomicilio.TabIndex = 5
        Me.btnGuardarDomicilio.Text = "Guardar"
        Me.btnGuardarDomicilio.UseVisualStyleBackColor = True
        Me.btnGuardarDomicilio.Visible = False
        '
        'btnRegistroDomicilio
        '
        Me.btnRegistroDomicilio.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistroDomicilio.Location = New System.Drawing.Point(75, 468)
        Me.btnRegistroDomicilio.Name = "btnRegistroDomicilio"
        Me.btnRegistroDomicilio.Size = New System.Drawing.Size(130, 25)
        Me.btnRegistroDomicilio.TabIndex = 3
        Me.btnRegistroDomicilio.Text = "Registrar"
        Me.btnRegistroDomicilio.UseVisualStyleBackColor = True
        Me.btnRegistroDomicilio.Visible = False
        '
        'lblMensajeErrorDomicilio
        '
        Me.lblMensajeErrorDomicilio.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lblMensajeErrorDomicilio.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMensajeErrorDomicilio.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeErrorDomicilio.ForeColor = System.Drawing.Color.White
        Me.lblMensajeErrorDomicilio.Location = New System.Drawing.Point(0, 633)
        Me.lblMensajeErrorDomicilio.Name = "lblMensajeErrorDomicilio"
        Me.lblMensajeErrorDomicilio.Size = New System.Drawing.Size(1024, 25)
        Me.lblMensajeErrorDomicilio.TabIndex = 12
        Me.lblMensajeErrorDomicilio.Text = "Mensaje de error"
        Me.lblMensajeErrorDomicilio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeErrorDomicilio.Visible = False
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
        Me.lblMensajeCargaDomicilio.Size = New System.Drawing.Size(1024, 25)
        Me.lblMensajeCargaDomicilio.TabIndex = 11
        Me.lblMensajeCargaDomicilio.Text = "No se ha cargado información de Domicilio para el prospecto."
        Me.lblMensajeCargaDomicilio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeCargaDomicilio.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(9, 32)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(300, 3)
        Me.Panel3.TabIndex = 1
        '
        'lblTituloDomicilio
        '
        Me.lblTituloDomicilio.AutoSize = True
        Me.lblTituloDomicilio.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloDomicilio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloDomicilio.Location = New System.Drawing.Point(9, 5)
        Me.lblTituloDomicilio.Name = "lblTituloDomicilio"
        Me.lblTituloDomicilio.Size = New System.Drawing.Size(122, 29)
        Me.lblTituloDomicilio.TabIndex = 0
        Me.lblTituloDomicilio.Text = "DOMICILIO"
        '
        'gpBoxDatosDomicilio
        '
        Me.gpBoxDatosDomicilio.Controls.Add(Me.cboDomicilioEstado)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.cboDomicilioMunicipio)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.cboDomicilioColonia)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.lblDomicilioEstado)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.lblDomicilioMunicipio)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.lblDomicilioColonia)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.lblDomicilioCP)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.txtDomicilioCP)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.lblDomicilioNoExt)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.lblDomicilioNoInt)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.lblDomicilioCalle)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.txtDomicilioNoExt)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.lblDomicilioPais)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.txtDomicilioCalle)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.cboDomicilioPais)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.txtDomicilioNoInt)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.txtDomicilioMunicipio)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.txtDomicilioEstado)
        Me.gpBoxDatosDomicilio.Controls.Add(Me.txtDomicilioColonia)
        Me.gpBoxDatosDomicilio.Enabled = False
        Me.gpBoxDatosDomicilio.Location = New System.Drawing.Point(75, 72)
        Me.gpBoxDatosDomicilio.Name = "gpBoxDatosDomicilio"
        Me.gpBoxDatosDomicilio.Size = New System.Drawing.Size(820, 384)
        Me.gpBoxDatosDomicilio.TabIndex = 2
        Me.gpBoxDatosDomicilio.TabStop = False
        '
        'cboDomicilioEstado
        '
        Me.cboDomicilioEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDomicilioEstado.FormattingEnabled = True
        Me.cboDomicilioEstado.Location = New System.Drawing.Point(77, 306)
        Me.cboDomicilioEstado.Name = "cboDomicilioEstado"
        Me.cboDomicilioEstado.Size = New System.Drawing.Size(255, 26)
        Me.cboDomicilioEstado.TabIndex = 15
        '
        'cboDomicilioMunicipio
        '
        Me.cboDomicilioMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDomicilioMunicipio.FormattingEnabled = True
        Me.cboDomicilioMunicipio.Location = New System.Drawing.Point(489, 229)
        Me.cboDomicilioMunicipio.Name = "cboDomicilioMunicipio"
        Me.cboDomicilioMunicipio.Size = New System.Drawing.Size(255, 26)
        Me.cboDomicilioMunicipio.TabIndex = 13
        '
        'cboDomicilioColonia
        '
        Me.cboDomicilioColonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDomicilioColonia.FormattingEnabled = True
        Me.cboDomicilioColonia.Location = New System.Drawing.Point(223, 229)
        Me.cboDomicilioColonia.Name = "cboDomicilioColonia"
        Me.cboDomicilioColonia.Size = New System.Drawing.Size(255, 26)
        Me.cboDomicilioColonia.TabIndex = 11
        '
        'lblDomicilioEstado
        '
        Me.lblDomicilioEstado.AutoSize = True
        Me.lblDomicilioEstado.Location = New System.Drawing.Point(77, 283)
        Me.lblDomicilioEstado.Name = "lblDomicilioEstado"
        Me.lblDomicilioEstado.Size = New System.Drawing.Size(49, 18)
        Me.lblDomicilioEstado.TabIndex = 14
        Me.lblDomicilioEstado.Text = "Estado"
        '
        'lblDomicilioMunicipio
        '
        Me.lblDomicilioMunicipio.AutoSize = True
        Me.lblDomicilioMunicipio.Location = New System.Drawing.Point(490, 207)
        Me.lblDomicilioMunicipio.Name = "lblDomicilioMunicipio"
        Me.lblDomicilioMunicipio.Size = New System.Drawing.Size(132, 18)
        Me.lblDomicilioMunicipio.TabIndex = 12
        Me.lblDomicilioMunicipio.Text = "Municipio / Alcaldia"
        '
        'lblDomicilioColonia
        '
        Me.lblDomicilioColonia.AutoSize = True
        Me.lblDomicilioColonia.Location = New System.Drawing.Point(223, 207)
        Me.lblDomicilioColonia.Name = "lblDomicilioColonia"
        Me.lblDomicilioColonia.Size = New System.Drawing.Size(55, 18)
        Me.lblDomicilioColonia.TabIndex = 10
        Me.lblDomicilioColonia.Text = "Colonia"
        '
        'lblDomicilioCP
        '
        Me.lblDomicilioCP.AutoSize = True
        Me.lblDomicilioCP.Location = New System.Drawing.Point(77, 207)
        Me.lblDomicilioCP.Name = "lblDomicilioCP"
        Me.lblDomicilioCP.Size = New System.Drawing.Size(92, 18)
        Me.lblDomicilioCP.TabIndex = 8
        Me.lblDomicilioCP.Text = "Código Postal"
        '
        'txtDomicilioCP
        '
        Me.txtDomicilioCP.Location = New System.Drawing.Point(77, 230)
        Me.txtDomicilioCP.Name = "txtDomicilioCP"
        Me.txtDomicilioCP.Size = New System.Drawing.Size(135, 25)
        Me.txtDomicilioCP.TabIndex = 9
        '
        'lblDomicilioNoExt
        '
        Me.lblDomicilioNoExt.AutoSize = True
        Me.lblDomicilioNoExt.Location = New System.Drawing.Point(655, 131)
        Me.lblDomicilioNoExt.Name = "lblDomicilioNoExt"
        Me.lblDomicilioNoExt.Size = New System.Drawing.Size(68, 18)
        Me.lblDomicilioNoExt.TabIndex = 6
        Me.lblDomicilioNoExt.Text = "Núm. Ext."
        '
        'lblDomicilioNoInt
        '
        Me.lblDomicilioNoInt.AutoSize = True
        Me.lblDomicilioNoInt.Location = New System.Drawing.Point(550, 131)
        Me.lblDomicilioNoInt.Name = "lblDomicilioNoInt"
        Me.lblDomicilioNoInt.Size = New System.Drawing.Size(66, 18)
        Me.lblDomicilioNoInt.TabIndex = 0
        Me.lblDomicilioNoInt.Text = "Núm. Int."
        '
        'lblDomicilioCalle
        '
        Me.lblDomicilioCalle.AutoSize = True
        Me.lblDomicilioCalle.Location = New System.Drawing.Point(77, 131)
        Me.lblDomicilioCalle.Name = "lblDomicilioCalle"
        Me.lblDomicilioCalle.Size = New System.Drawing.Size(39, 18)
        Me.lblDomicilioCalle.TabIndex = 2
        Me.lblDomicilioCalle.Text = "Calle"
        '
        'txtDomicilioNoExt
        '
        Me.txtDomicilioNoExt.Location = New System.Drawing.Point(655, 154)
        Me.txtDomicilioNoExt.Name = "txtDomicilioNoExt"
        Me.txtDomicilioNoExt.Size = New System.Drawing.Size(89, 25)
        Me.txtDomicilioNoExt.TabIndex = 7
        '
        'lblDomicilioPais
        '
        Me.lblDomicilioPais.AutoSize = True
        Me.lblDomicilioPais.Location = New System.Drawing.Point(77, 54)
        Me.lblDomicilioPais.Name = "lblDomicilioPais"
        Me.lblDomicilioPais.Size = New System.Drawing.Size(33, 18)
        Me.lblDomicilioPais.TabIndex = 0
        Me.lblDomicilioPais.Text = "País"
        '
        'txtDomicilioCalle
        '
        Me.txtDomicilioCalle.Location = New System.Drawing.Point(77, 154)
        Me.txtDomicilioCalle.Name = "txtDomicilioCalle"
        Me.txtDomicilioCalle.Size = New System.Drawing.Size(457, 25)
        Me.txtDomicilioCalle.TabIndex = 3
        '
        'cboDomicilioPais
        '
        Me.cboDomicilioPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDomicilioPais.DropDownWidth = 300
        Me.cboDomicilioPais.FormattingEnabled = True
        Me.cboDomicilioPais.Location = New System.Drawing.Point(77, 77)
        Me.cboDomicilioPais.Name = "cboDomicilioPais"
        Me.cboDomicilioPais.Size = New System.Drawing.Size(255, 26)
        Me.cboDomicilioPais.TabIndex = 1
        '
        'txtDomicilioNoInt
        '
        Me.txtDomicilioNoInt.Location = New System.Drawing.Point(550, 154)
        Me.txtDomicilioNoInt.Name = "txtDomicilioNoInt"
        Me.txtDomicilioNoInt.Size = New System.Drawing.Size(89, 25)
        Me.txtDomicilioNoInt.TabIndex = 5
        '
        'txtDomicilioMunicipio
        '
        Me.txtDomicilioMunicipio.Location = New System.Drawing.Point(489, 229)
        Me.txtDomicilioMunicipio.Name = "txtDomicilioMunicipio"
        Me.txtDomicilioMunicipio.Size = New System.Drawing.Size(255, 25)
        Me.txtDomicilioMunicipio.TabIndex = 17
        '
        'txtDomicilioEstado
        '
        Me.txtDomicilioEstado.Location = New System.Drawing.Point(77, 306)
        Me.txtDomicilioEstado.Name = "txtDomicilioEstado"
        Me.txtDomicilioEstado.Size = New System.Drawing.Size(255, 25)
        Me.txtDomicilioEstado.TabIndex = 18
        '
        'txtDomicilioColonia
        '
        Me.txtDomicilioColonia.Location = New System.Drawing.Point(223, 229)
        Me.txtDomicilioColonia.Name = "txtDomicilioColonia"
        Me.txtDomicilioColonia.Size = New System.Drawing.Size(255, 25)
        Me.txtDomicilioColonia.TabIndex = 16
        '
        'panFuncionarios
        '
        Me.panFuncionarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panFuncionarios.BackColor = System.Drawing.Color.White
        Me.panFuncionarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panFuncionarios.Controls.Add(Me.lblMensajeCargaFuncionarios)
        Me.panFuncionarios.Controls.Add(Me.btnCancelarFuncionario)
        Me.panFuncionarios.Controls.Add(Me.btnActualizarFuncionario)
        Me.panFuncionarios.Controls.Add(Me.gridFuncionarios)
        Me.panFuncionarios.Controls.Add(Me.btnNuevoFuncionarios)
        Me.panFuncionarios.Controls.Add(Me.btnGuardarFuncionarios)
        Me.panFuncionarios.Controls.Add(Me.gpBoxDatosFuncionarios)
        Me.panFuncionarios.Controls.Add(Me.Panel4)
        Me.panFuncionarios.Controls.Add(Me.lblTituloFuncionarios)
        Me.panFuncionarios.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panFuncionarios.Location = New System.Drawing.Point(212, 0)
        Me.panFuncionarios.Name = "panFuncionarios"
        Me.panFuncionarios.Size = New System.Drawing.Size(1026, 660)
        Me.panFuncionarios.TabIndex = 7
        Me.panFuncionarios.Tag = "5"
        Me.panFuncionarios.Visible = False
        '
        'lblMensajeCargaFuncionarios
        '
        Me.lblMensajeCargaFuncionarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMensajeCargaFuncionarios.BackColor = System.Drawing.Color.DarkSalmon
        Me.lblMensajeCargaFuncionarios.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeCargaFuncionarios.ForeColor = System.Drawing.Color.White
        Me.lblMensajeCargaFuncionarios.Location = New System.Drawing.Point(0, 44)
        Me.lblMensajeCargaFuncionarios.Name = "lblMensajeCargaFuncionarios"
        Me.lblMensajeCargaFuncionarios.Size = New System.Drawing.Size(1024, 25)
        Me.lblMensajeCargaFuncionarios.TabIndex = 15
        Me.lblMensajeCargaFuncionarios.Text = "No se ha cargado información de Funcionarios para el prospecto."
        Me.lblMensajeCargaFuncionarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeCargaFuncionarios.Visible = False
        '
        'btnCancelarFuncionario
        '
        Me.btnCancelarFuncionario.Enabled = False
        Me.btnCancelarFuncionario.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarFuncionario.Location = New System.Drawing.Point(624, 281)
        Me.btnCancelarFuncionario.Name = "btnCancelarFuncionario"
        Me.btnCancelarFuncionario.Size = New System.Drawing.Size(130, 25)
        Me.btnCancelarFuncionario.TabIndex = 14
        Me.btnCancelarFuncionario.Text = "Cancelar"
        Me.btnCancelarFuncionario.UseVisualStyleBackColor = True
        '
        'btnActualizarFuncionario
        '
        Me.btnActualizarFuncionario.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizarFuncionario.Location = New System.Drawing.Point(220, 281)
        Me.btnActualizarFuncionario.Name = "btnActualizarFuncionario"
        Me.btnActualizarFuncionario.Size = New System.Drawing.Size(130, 25)
        Me.btnActualizarFuncionario.TabIndex = 13
        Me.btnActualizarFuncionario.Text = "Actualizar"
        Me.btnActualizarFuncionario.UseVisualStyleBackColor = True
        '
        'gridFuncionarios
        '
        Me.gridFuncionarios.AllowUserToAddRows = False
        Me.gridFuncionarios.AllowUserToDeleteRows = False
        Me.gridFuncionarios.AllowUserToResizeRows = False
        Me.gridFuncionarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridFuncionarios.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.gridFuncionarios.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.gridFuncionarios.ColumnHeadersHeight = 40
        Me.gridFuncionarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridFuncionarios.GridColor = System.Drawing.Color.WhiteSmoke
        Me.gridFuncionarios.Location = New System.Drawing.Point(75, 328)
        Me.gridFuncionarios.Name = "gridFuncionarios"
        Me.gridFuncionarios.RowHeadersWidth = 25
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gridFuncionarios.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridFuncionarios.RowTemplate.Height = 25
        Me.gridFuncionarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridFuncionarios.Size = New System.Drawing.Size(873, 304)
        Me.gridFuncionarios.TabIndex = 12
        '
        'btnNuevoFuncionarios
        '
        Me.btnNuevoFuncionarios.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoFuncionarios.Location = New System.Drawing.Point(75, 281)
        Me.btnNuevoFuncionarios.Name = "btnNuevoFuncionarios"
        Me.btnNuevoFuncionarios.Size = New System.Drawing.Size(130, 25)
        Me.btnNuevoFuncionarios.TabIndex = 11
        Me.btnNuevoFuncionarios.Text = "Nuevo"
        Me.btnNuevoFuncionarios.UseVisualStyleBackColor = True
        '
        'btnGuardarFuncionarios
        '
        Me.btnGuardarFuncionarios.Enabled = False
        Me.btnGuardarFuncionarios.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarFuncionarios.Location = New System.Drawing.Point(765, 281)
        Me.btnGuardarFuncionarios.Name = "btnGuardarFuncionarios"
        Me.btnGuardarFuncionarios.Size = New System.Drawing.Size(130, 25)
        Me.btnGuardarFuncionarios.TabIndex = 10
        Me.btnGuardarFuncionarios.Text = "Guardar"
        Me.btnGuardarFuncionarios.UseVisualStyleBackColor = True
        '
        'gpBoxDatosFuncionarios
        '
        Me.gpBoxDatosFuncionarios.Controls.Add(Me.lblFuncionariosCargo)
        Me.gpBoxDatosFuncionarios.Controls.Add(Me.lblFuncionariosApellidoMaterno)
        Me.gpBoxDatosFuncionarios.Controls.Add(Me.lblFuncionariosCorreo)
        Me.gpBoxDatosFuncionarios.Controls.Add(Me.lblFuncionariosTelefono)
        Me.gpBoxDatosFuncionarios.Controls.Add(Me.txtFuncionariosNombre)
        Me.gpBoxDatosFuncionarios.Controls.Add(Me.lblFuncionariosApellidoPaterno)
        Me.gpBoxDatosFuncionarios.Controls.Add(Me.txtFuncionariosApellidoPaterno)
        Me.gpBoxDatosFuncionarios.Controls.Add(Me.txtFuncionariosApellidoMaterno)
        Me.gpBoxDatosFuncionarios.Controls.Add(Me.lblFuncionariosNombre)
        Me.gpBoxDatosFuncionarios.Controls.Add(Me.txtFuncionariosCorreo)
        Me.gpBoxDatosFuncionarios.Controls.Add(Me.txtFuncionariosCargo)
        Me.gpBoxDatosFuncionarios.Controls.Add(Me.txtFuncionariosTelefono)
        Me.gpBoxDatosFuncionarios.Enabled = False
        Me.gpBoxDatosFuncionarios.Location = New System.Drawing.Point(75, 72)
        Me.gpBoxDatosFuncionarios.Name = "gpBoxDatosFuncionarios"
        Me.gpBoxDatosFuncionarios.Size = New System.Drawing.Size(820, 204)
        Me.gpBoxDatosFuncionarios.TabIndex = 4
        Me.gpBoxDatosFuncionarios.TabStop = False
        '
        'lblFuncionariosCargo
        '
        Me.lblFuncionariosCargo.AutoSize = True
        Me.lblFuncionariosCargo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionariosCargo.Location = New System.Drawing.Point(36, 77)
        Me.lblFuncionariosCargo.Name = "lblFuncionariosCargo"
        Me.lblFuncionariosCargo.Size = New System.Drawing.Size(43, 18)
        Me.lblFuncionariosCargo.TabIndex = 6
        Me.lblFuncionariosCargo.Text = "Cargo"
        '
        'lblFuncionariosApellidoMaterno
        '
        Me.lblFuncionariosApellidoMaterno.AutoSize = True
        Me.lblFuncionariosApellidoMaterno.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionariosApellidoMaterno.Location = New System.Drawing.Point(546, 19)
        Me.lblFuncionariosApellidoMaterno.Name = "lblFuncionariosApellidoMaterno"
        Me.lblFuncionariosApellidoMaterno.Size = New System.Drawing.Size(118, 18)
        Me.lblFuncionariosApellidoMaterno.TabIndex = 4
        Me.lblFuncionariosApellidoMaterno.Text = "Apellido Materno"
        '
        'lblFuncionariosCorreo
        '
        Me.lblFuncionariosCorreo.AutoSize = True
        Me.lblFuncionariosCorreo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionariosCorreo.Location = New System.Drawing.Point(351, 138)
        Me.lblFuncionariosCorreo.Name = "lblFuncionariosCorreo"
        Me.lblFuncionariosCorreo.Size = New System.Drawing.Size(123, 18)
        Me.lblFuncionariosCorreo.TabIndex = 10
        Me.lblFuncionariosCorreo.Text = "Correo electrónico"
        '
        'lblFuncionariosTelefono
        '
        Me.lblFuncionariosTelefono.AutoSize = True
        Me.lblFuncionariosTelefono.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionariosTelefono.Location = New System.Drawing.Point(36, 138)
        Me.lblFuncionariosTelefono.Name = "lblFuncionariosTelefono"
        Me.lblFuncionariosTelefono.Size = New System.Drawing.Size(63, 18)
        Me.lblFuncionariosTelefono.TabIndex = 8
        Me.lblFuncionariosTelefono.Text = "Teléfono"
        '
        'txtFuncionariosNombre
        '
        Me.txtFuncionariosNombre.Location = New System.Drawing.Point(36, 42)
        Me.txtFuncionariosNombre.Name = "txtFuncionariosNombre"
        Me.txtFuncionariosNombre.Size = New System.Drawing.Size(239, 25)
        Me.txtFuncionariosNombre.TabIndex = 1
        '
        'lblFuncionariosApellidoPaterno
        '
        Me.lblFuncionariosApellidoPaterno.AutoSize = True
        Me.lblFuncionariosApellidoPaterno.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionariosApellidoPaterno.Location = New System.Drawing.Point(291, 19)
        Me.lblFuncionariosApellidoPaterno.Name = "lblFuncionariosApellidoPaterno"
        Me.lblFuncionariosApellidoPaterno.Size = New System.Drawing.Size(113, 18)
        Me.lblFuncionariosApellidoPaterno.TabIndex = 2
        Me.lblFuncionariosApellidoPaterno.Text = "Apellido Paterno"
        '
        'txtFuncionariosApellidoPaterno
        '
        Me.txtFuncionariosApellidoPaterno.Location = New System.Drawing.Point(291, 42)
        Me.txtFuncionariosApellidoPaterno.Name = "txtFuncionariosApellidoPaterno"
        Me.txtFuncionariosApellidoPaterno.Size = New System.Drawing.Size(239, 25)
        Me.txtFuncionariosApellidoPaterno.TabIndex = 3
        '
        'txtFuncionariosApellidoMaterno
        '
        Me.txtFuncionariosApellidoMaterno.Location = New System.Drawing.Point(546, 42)
        Me.txtFuncionariosApellidoMaterno.Name = "txtFuncionariosApellidoMaterno"
        Me.txtFuncionariosApellidoMaterno.Size = New System.Drawing.Size(239, 25)
        Me.txtFuncionariosApellidoMaterno.TabIndex = 5
        '
        'lblFuncionariosNombre
        '
        Me.lblFuncionariosNombre.AutoSize = True
        Me.lblFuncionariosNombre.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionariosNombre.Location = New System.Drawing.Point(36, 19)
        Me.lblFuncionariosNombre.Name = "lblFuncionariosNombre"
        Me.lblFuncionariosNombre.Size = New System.Drawing.Size(59, 18)
        Me.lblFuncionariosNombre.TabIndex = 0
        Me.lblFuncionariosNombre.Text = "Nombre"
        '
        'txtFuncionariosCorreo
        '
        Me.txtFuncionariosCorreo.Location = New System.Drawing.Point(351, 161)
        Me.txtFuncionariosCorreo.Name = "txtFuncionariosCorreo"
        Me.txtFuncionariosCorreo.Size = New System.Drawing.Size(297, 25)
        Me.txtFuncionariosCorreo.TabIndex = 11
        '
        'txtFuncionariosCargo
        '
        Me.txtFuncionariosCargo.Location = New System.Drawing.Point(36, 100)
        Me.txtFuncionariosCargo.Name = "txtFuncionariosCargo"
        Me.txtFuncionariosCargo.Size = New System.Drawing.Size(494, 25)
        Me.txtFuncionariosCargo.TabIndex = 7
        '
        'txtFuncionariosTelefono
        '
        Me.txtFuncionariosTelefono.Location = New System.Drawing.Point(36, 161)
        Me.txtFuncionariosTelefono.Name = "txtFuncionariosTelefono"
        Me.txtFuncionariosTelefono.Size = New System.Drawing.Size(297, 25)
        Me.txtFuncionariosTelefono.TabIndex = 9
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(9, 32)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(300, 3)
        Me.Panel4.TabIndex = 3
        '
        'lblTituloFuncionarios
        '
        Me.lblTituloFuncionarios.AutoSize = True
        Me.lblTituloFuncionarios.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloFuncionarios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloFuncionarios.Location = New System.Drawing.Point(9, 5)
        Me.lblTituloFuncionarios.Name = "lblTituloFuncionarios"
        Me.lblTituloFuncionarios.Size = New System.Drawing.Size(169, 29)
        Me.lblTituloFuncionarios.TabIndex = 2
        Me.lblTituloFuncionarios.Text = "FUNCIONARIOS"
        '
        'panAccionistas
        '
        Me.panAccionistas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panAccionistas.BackColor = System.Drawing.Color.White
        Me.panAccionistas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panAccionistas.Controls.Add(Me.lblMensajeCargaAccionistas)
        Me.panAccionistas.Controls.Add(Me.btnCancelarAccionistas)
        Me.panAccionistas.Controls.Add(Me.btnActualizarAccionistas)
        Me.panAccionistas.Controls.Add(Me.gridAccionistas)
        Me.panAccionistas.Controls.Add(Me.btnNuevoAccionista)
        Me.panAccionistas.Controls.Add(Me.btnGuardarAccionistas)
        Me.panAccionistas.Controls.Add(Me.gpBoxDatosAccionistas)
        Me.panAccionistas.Controls.Add(Me.Panel6)
        Me.panAccionistas.Controls.Add(Me.lblTituloAccionistas)
        Me.panAccionistas.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panAccionistas.Location = New System.Drawing.Point(212, 0)
        Me.panAccionistas.Name = "panAccionistas"
        Me.panAccionistas.Size = New System.Drawing.Size(1026, 660)
        Me.panAccionistas.TabIndex = 0
        Me.panAccionistas.Tag = "6"
        Me.panAccionistas.Visible = False
        '
        'lblMensajeCargaAccionistas
        '
        Me.lblMensajeCargaAccionistas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMensajeCargaAccionistas.BackColor = System.Drawing.Color.DarkSalmon
        Me.lblMensajeCargaAccionistas.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeCargaAccionistas.ForeColor = System.Drawing.Color.White
        Me.lblMensajeCargaAccionistas.Location = New System.Drawing.Point(0, 44)
        Me.lblMensajeCargaAccionistas.Name = "lblMensajeCargaAccionistas"
        Me.lblMensajeCargaAccionistas.Size = New System.Drawing.Size(1024, 25)
        Me.lblMensajeCargaAccionistas.TabIndex = 10
        Me.lblMensajeCargaAccionistas.Text = "No se ha cargado información de Accionistas para el prospecto."
        Me.lblMensajeCargaAccionistas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeCargaAccionistas.Visible = False
        '
        'btnCancelarAccionistas
        '
        Me.btnCancelarAccionistas.Enabled = False
        Me.btnCancelarAccionistas.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAccionistas.Location = New System.Drawing.Point(624, 243)
        Me.btnCancelarAccionistas.Name = "btnCancelarAccionistas"
        Me.btnCancelarAccionistas.Size = New System.Drawing.Size(130, 25)
        Me.btnCancelarAccionistas.TabIndex = 9
        Me.btnCancelarAccionistas.Text = "Cancelar"
        Me.btnCancelarAccionistas.UseVisualStyleBackColor = True
        '
        'btnActualizarAccionistas
        '
        Me.btnActualizarAccionistas.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizarAccionistas.Location = New System.Drawing.Point(220, 243)
        Me.btnActualizarAccionistas.Name = "btnActualizarAccionistas"
        Me.btnActualizarAccionistas.Size = New System.Drawing.Size(130, 25)
        Me.btnActualizarAccionistas.TabIndex = 8
        Me.btnActualizarAccionistas.Text = "Actualizar"
        Me.btnActualizarAccionistas.UseVisualStyleBackColor = True
        '
        'gridAccionistas
        '
        Me.gridAccionistas.AllowUserToAddRows = False
        Me.gridAccionistas.AllowUserToDeleteRows = False
        Me.gridAccionistas.AllowUserToResizeRows = False
        Me.gridAccionistas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridAccionistas.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.gridAccionistas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.gridAccionistas.ColumnHeadersHeight = 40
        Me.gridAccionistas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridAccionistas.GridColor = System.Drawing.Color.WhiteSmoke
        Me.gridAccionistas.Location = New System.Drawing.Point(75, 295)
        Me.gridAccionistas.Name = "gridAccionistas"
        Me.gridAccionistas.RowHeadersWidth = 25
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gridAccionistas.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gridAccionistas.RowTemplate.Height = 25
        Me.gridAccionistas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridAccionistas.Size = New System.Drawing.Size(873, 304)
        Me.gridAccionistas.TabIndex = 7
        '
        'btnNuevoAccionista
        '
        Me.btnNuevoAccionista.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoAccionista.Location = New System.Drawing.Point(75, 243)
        Me.btnNuevoAccionista.Name = "btnNuevoAccionista"
        Me.btnNuevoAccionista.Size = New System.Drawing.Size(130, 25)
        Me.btnNuevoAccionista.TabIndex = 0
        Me.btnNuevoAccionista.Text = "Nuevo"
        Me.btnNuevoAccionista.UseVisualStyleBackColor = True
        '
        'btnGuardarAccionistas
        '
        Me.btnGuardarAccionistas.Enabled = False
        Me.btnGuardarAccionistas.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarAccionistas.Location = New System.Drawing.Point(765, 243)
        Me.btnGuardarAccionistas.Name = "btnGuardarAccionistas"
        Me.btnGuardarAccionistas.Size = New System.Drawing.Size(130, 25)
        Me.btnGuardarAccionistas.TabIndex = 5
        Me.btnGuardarAccionistas.Text = "Guardar"
        Me.btnGuardarAccionistas.UseVisualStyleBackColor = True
        '
        'gpBoxDatosAccionistas
        '
        Me.gpBoxDatosAccionistas.Controls.Add(Me.lblAccionistasTipoPersona)
        Me.gpBoxDatosAccionistas.Controls.Add(Me.cboAccionistasTipoPersona)
        Me.gpBoxDatosAccionistas.Controls.Add(Me.lblAccionistasPorcentaje)
        Me.gpBoxDatosAccionistas.Controls.Add(Me.lblAccionistasApellidoMaterno)
        Me.gpBoxDatosAccionistas.Controls.Add(Me.txtAccionistasNombre)
        Me.gpBoxDatosAccionistas.Controls.Add(Me.lblAccionistasApellidoPaterno)
        Me.gpBoxDatosAccionistas.Controls.Add(Me.txtAccionistasApellidoPaterno)
        Me.gpBoxDatosAccionistas.Controls.Add(Me.txtAccionistasApellidoMaterno)
        Me.gpBoxDatosAccionistas.Controls.Add(Me.lblAccionistasNombre)
        Me.gpBoxDatosAccionistas.Controls.Add(Me.txtAccionistasPorcentaje)
        Me.gpBoxDatosAccionistas.Enabled = False
        Me.gpBoxDatosAccionistas.Location = New System.Drawing.Point(75, 72)
        Me.gpBoxDatosAccionistas.Name = "gpBoxDatosAccionistas"
        Me.gpBoxDatosAccionistas.Size = New System.Drawing.Size(820, 164)
        Me.gpBoxDatosAccionistas.TabIndex = 2
        Me.gpBoxDatosAccionistas.TabStop = False
        '
        'lblAccionistasTipoPersona
        '
        Me.lblAccionistasTipoPersona.AutoSize = True
        Me.lblAccionistasTipoPersona.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionistasTipoPersona.Location = New System.Drawing.Point(36, 90)
        Me.lblAccionistasTipoPersona.Name = "lblAccionistasTipoPersona"
        Me.lblAccionistasTipoPersona.Size = New System.Drawing.Size(107, 18)
        Me.lblAccionistasTipoPersona.TabIndex = 6
        Me.lblAccionistasTipoPersona.Text = "Tipo de Persona"
        '
        'cboAccionistasTipoPersona
        '
        Me.cboAccionistasTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccionistasTipoPersona.FormattingEnabled = True
        Me.cboAccionistasTipoPersona.Location = New System.Drawing.Point(36, 116)
        Me.cboAccionistasTipoPersona.Name = "cboAccionistasTipoPersona"
        Me.cboAccionistasTipoPersona.Size = New System.Drawing.Size(239, 26)
        Me.cboAccionistasTipoPersona.TabIndex = 7
        '
        'lblAccionistasPorcentaje
        '
        Me.lblAccionistasPorcentaje.AutoSize = True
        Me.lblAccionistasPorcentaje.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionistasPorcentaje.Location = New System.Drawing.Point(291, 90)
        Me.lblAccionistasPorcentaje.Name = "lblAccionistasPorcentaje"
        Me.lblAccionistasPorcentaje.Size = New System.Drawing.Size(19, 18)
        Me.lblAccionistasPorcentaje.TabIndex = 8
        Me.lblAccionistasPorcentaje.Text = "%"
        '
        'lblAccionistasApellidoMaterno
        '
        Me.lblAccionistasApellidoMaterno.AutoSize = True
        Me.lblAccionistasApellidoMaterno.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionistasApellidoMaterno.Location = New System.Drawing.Point(546, 26)
        Me.lblAccionistasApellidoMaterno.Name = "lblAccionistasApellidoMaterno"
        Me.lblAccionistasApellidoMaterno.Size = New System.Drawing.Size(118, 18)
        Me.lblAccionistasApellidoMaterno.TabIndex = 4
        Me.lblAccionistasApellidoMaterno.Text = "Apellido Materno"
        '
        'txtAccionistasNombre
        '
        Me.txtAccionistasNombre.Location = New System.Drawing.Point(36, 49)
        Me.txtAccionistasNombre.Name = "txtAccionistasNombre"
        Me.txtAccionistasNombre.Size = New System.Drawing.Size(239, 25)
        Me.txtAccionistasNombre.TabIndex = 1
        '
        'lblAccionistasApellidoPaterno
        '
        Me.lblAccionistasApellidoPaterno.AutoSize = True
        Me.lblAccionistasApellidoPaterno.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionistasApellidoPaterno.Location = New System.Drawing.Point(291, 26)
        Me.lblAccionistasApellidoPaterno.Name = "lblAccionistasApellidoPaterno"
        Me.lblAccionistasApellidoPaterno.Size = New System.Drawing.Size(113, 18)
        Me.lblAccionistasApellidoPaterno.TabIndex = 2
        Me.lblAccionistasApellidoPaterno.Text = "Apellido Paterno"
        '
        'txtAccionistasApellidoPaterno
        '
        Me.txtAccionistasApellidoPaterno.Location = New System.Drawing.Point(291, 49)
        Me.txtAccionistasApellidoPaterno.Name = "txtAccionistasApellidoPaterno"
        Me.txtAccionistasApellidoPaterno.Size = New System.Drawing.Size(239, 25)
        Me.txtAccionistasApellidoPaterno.TabIndex = 3
        '
        'txtAccionistasApellidoMaterno
        '
        Me.txtAccionistasApellidoMaterno.Location = New System.Drawing.Point(546, 49)
        Me.txtAccionistasApellidoMaterno.Name = "txtAccionistasApellidoMaterno"
        Me.txtAccionistasApellidoMaterno.Size = New System.Drawing.Size(239, 25)
        Me.txtAccionistasApellidoMaterno.TabIndex = 5
        '
        'lblAccionistasNombre
        '
        Me.lblAccionistasNombre.AutoSize = True
        Me.lblAccionistasNombre.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionistasNombre.Location = New System.Drawing.Point(36, 26)
        Me.lblAccionistasNombre.Name = "lblAccionistasNombre"
        Me.lblAccionistasNombre.Size = New System.Drawing.Size(59, 18)
        Me.lblAccionistasNombre.TabIndex = 0
        Me.lblAccionistasNombre.Text = "Nombre"
        '
        'txtAccionistasPorcentaje
        '
        Me.txtAccionistasPorcentaje.Location = New System.Drawing.Point(291, 117)
        Me.txtAccionistasPorcentaje.Name = "txtAccionistasPorcentaje"
        Me.txtAccionistasPorcentaje.Size = New System.Drawing.Size(85, 25)
        Me.txtAccionistasPorcentaje.TabIndex = 9
        Me.txtAccionistasPorcentaje.Text = "0"
        Me.txtAccionistasPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Panel6.Location = New System.Drawing.Point(9, 32)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(300, 3)
        Me.Panel6.TabIndex = 1
        '
        'lblTituloAccionistas
        '
        Me.lblTituloAccionistas.AutoSize = True
        Me.lblTituloAccionistas.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloAccionistas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloAccionistas.Location = New System.Drawing.Point(9, 5)
        Me.lblTituloAccionistas.Name = "lblTituloAccionistas"
        Me.lblTituloAccionistas.Size = New System.Drawing.Size(145, 29)
        Me.lblTituloAccionistas.TabIndex = 0
        Me.lblTituloAccionistas.Text = "ACCIONISTAS"
        '
        'lblMensaje
        '
        Me.lblMensaje.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lblMensaje.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMensaje.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.White
        Me.lblMensaje.Location = New System.Drawing.Point(0, 434)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(210, 264)
        Me.lblMensaje.TabIndex = 27
        Me.lblMensaje.Text = "Mensaje de error"
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensaje.Visible = False
        '
        'FrmContacto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1238, 700)
        Me.Controls.Add(Me.btnRegistroDatosGenerales)
        Me.Controls.Add(Me.btnGuardaGeneral)
        Me.Controls.Add(Me.btnCancelaGeneral)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.panMenu)
        Me.Controls.Add(Me.panDatosGenerales)
        Me.Controls.Add(Me.panAccionistas)
        Me.Controls.Add(Me.panFuncionarios)
        Me.Controls.Add(Me.panAcercamiento)
        Me.Controls.Add(Me.panDireccion)
        Me.Controls.Add(Me.panContactoInicial)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmContacto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta de cliente prospecto"
        Me.panMenu.ResumeLayout(False)
        Me.panMenu.PerformLayout()
        Me.panDatosGenerales.ResumeLayout(False)
        Me.panDatosGenerales.PerformLayout()
        Me.gpBoxDatosDG.ResumeLayout(False)
        Me.gpBoxDatosDG.PerformLayout()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpBoxTipoNegocio.ResumeLayout(False)
        Me.gpBoxTipoNegocio.PerformLayout()
        Me.gpBoxServicio.ResumeLayout(False)
        Me.gpBoxServicio.PerformLayout()
        Me.panDivisiones.ResumeLayout(False)
        Me.panDivisiones.PerformLayout()
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
        Me.panFuncionarios.ResumeLayout(False)
        Me.panFuncionarios.PerformLayout()
        CType(Me.gridFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpBoxDatosFuncionarios.ResumeLayout(False)
        Me.gpBoxDatosFuncionarios.PerformLayout()
        Me.panAccionistas.ResumeLayout(False)
        Me.panAccionistas.PerformLayout()
        CType(Me.gridAccionistas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpBoxDatosAccionistas.ResumeLayout(False)
        Me.gpBoxDatosAccionistas.PerformLayout()
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
    Friend WithEvents lnkAccionistas As LinkLabel
    Friend WithEvents lnkFuncionarios As LinkLabel
    Friend WithEvents lnkDireccion As LinkLabel
    Friend WithEvents lnkAcercamiento As LinkLabel
    Friend WithEvents panContactoInicial As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTituloCI As Label
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
    Friend WithEvents panFuncionarios As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblTituloFuncionarios As Label
    Friend WithEvents lblFuncionariosCargo As Label
    Friend WithEvents lblFuncionariosTelefono As Label
    Friend WithEvents lblFuncionariosCorreo As Label
    Friend WithEvents gpBoxDatosFuncionarios As GroupBox
    Friend WithEvents lblFuncionariosApellidoMaterno As Label
    Friend WithEvents txtFuncionariosNombre As TextBox
    Friend WithEvents lblFuncionariosApellidoPaterno As Label
    Friend WithEvents txtFuncionariosApellidoPaterno As TextBox
    Friend WithEvents txtFuncionariosApellidoMaterno As TextBox
    Friend WithEvents lblFuncionariosNombre As Label
    Friend WithEvents txtFuncionariosCorreo As TextBox
    Friend WithEvents txtFuncionariosCargo As TextBox
    Friend WithEvents txtFuncionariosTelefono As TextBox
    Friend WithEvents panAccionistas As Panel
    Friend WithEvents gpBoxDatosAccionistas As GroupBox
    Friend WithEvents lblAccionistasPorcentaje As Label
    Friend WithEvents lblAccionistasApellidoMaterno As Label
    Friend WithEvents txtAccionistasNombre As TextBox
    Friend WithEvents lblAccionistasApellidoPaterno As Label
    Friend WithEvents txtAccionistasApellidoPaterno As TextBox
    Friend WithEvents txtAccionistasApellidoMaterno As TextBox
    Friend WithEvents lblAccionistasNombre As Label
    Friend WithEvents txtAccionistasPorcentaje As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblTituloAccionistas As Label
    Friend WithEvents lblAccionistasTipoPersona As Label
    Friend WithEvents cboAccionistasTipoPersona As ComboBox
    Friend WithEvents gridAccionistas As DataGridView
    Friend WithEvents btnNuevoAccionista As Button
    Friend WithEvents btnGuardarAccionistas As Button
    Friend WithEvents btnActualizarAccionistas As Button
    Friend WithEvents Lista As DataGridView
    Friend WithEvents btnCancelarAccionistas As Button
    Friend WithEvents btnCancelarFuncionario As Button
    Friend WithEvents btnActualizarFuncionario As Button
    Friend WithEvents gridFuncionarios As DataGridView
    Friend WithEvents btnNuevoFuncionarios As Button
    Friend WithEvents btnGuardarFuncionarios As Button
    Friend WithEvents btnCancelarAcercamiento As Button
    Friend WithEvents btnGuardarAcercamiento As Button
    Friend WithEvents btnRegistroAcercamiento As Button
    Friend WithEvents lblMensajeErrorAcercamiento As Label
    Friend WithEvents txtClaveProspecto As Label
    Friend WithEvents lblMensajeErrorContactoInicial As Label
    Friend WithEvents btnCancelarContactoInicial As Button
    Friend WithEvents btnGuardarContactoInicial As Button
    Friend WithEvents btnRegistroContactoInicial As Button
    Friend WithEvents lblMensajeCargaContactoInicial As Label
    Friend WithEvents lblMensajeCargaAccionistas As Label
    Friend WithEvents lblMensajeCargaFuncionarios As Label
    Friend WithEvents lblMensajeCargaAcercamiento As Label
    Friend WithEvents lblMensajeCargaDomicilio As Label
    Friend WithEvents btnCancelaGeneral As Button
    Friend WithEvents btnGuardaGeneral As Button
    Friend WithEvents lblMensajeErrorDomicilio As Label
    Friend WithEvents txtDomicilioEstado As TextBox
    Friend WithEvents txtDomicilioMunicipio As TextBox
    Friend WithEvents txtDomicilioColonia As TextBox
    Friend WithEvents btnCancelarDomicilio As Button
    Friend WithEvents btnGuardarDomicilio As Button
    Friend WithEvents btnRegistroDomicilio As Button
    Friend WithEvents lblAcercamientoWebProspecto As Label
    Friend WithEvents txtAcercamientoWebProspecto As TextBox
    Friend WithEvents lblMensajeCargaDatosGenerales As Label
    Friend WithEvents gpBoxDatosDG As GroupBox
    Friend WithEvents btnRegistroDatosGenerales As Button
    Friend WithEvents panRDDomExt As Panel
    Friend WithEvents panRDRepExt As Panel
    Friend WithEvents panRDSubExt As Panel
    Friend WithEvents lblMensajeErrorDatosGenerales As Label
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
    Friend WithEvents panDivisiones As Panel
    Friend WithEvents rdAuditoria As RadioButton
    Friend WithEvents rdIBC As RadioButton
    Friend WithEvents rdPLD As RadioButton
    Friend WithEvents rdJBG As RadioButton
    Friend WithEvents rdImpuestos As RadioButton
    Friend WithEvents rdComercioExterior As RadioButton
    Friend WithEvents rdBAS As RadioButton
    Friend WithEvents rdPreciosTransferencia As RadioButton
    Friend WithEvents rdBPS As RadioButton
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
    Friend WithEvents lblMensaje As Label
End Class
