<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContactoBasico
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnRegistroDatosGenerales = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.panMenu = New System.Windows.Forms.Panel()
        Me.txtClaveProspecto = New System.Windows.Forms.Label()
        Me.lnkDatosGenerales = New System.Windows.Forms.LinkLabel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.panDatosGenerales = New System.Windows.Forms.Panel()
        Me.gpBoxDatosDG = New System.Windows.Forms.GroupBox()
        Me.Lista = New System.Windows.Forms.DataGridView()
        Me.lblIndustria = New System.Windows.Forms.Label()
        Me.txtIndustria = New System.Windows.Forms.TextBox()
        Me.gpBoxTipoNegocio = New System.Windows.Forms.GroupBox()
        Me.rdPersonaFisica = New System.Windows.Forms.RadioButton()
        Me.rdPersonalMoral = New System.Windows.Forms.RadioButton()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.lblTituloContactoInicial = New System.Windows.Forms.Label()
        Me.lblTituloAcercamiento = New System.Windows.Forms.Label()
        Me.lblTituloServicio = New System.Windows.Forms.Label()
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
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.lblMensajeErrorDatosGenerales = New System.Windows.Forms.Label()
        Me.gpBoxDatosAcercamiento = New System.Windows.Forms.GroupBox()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.lblAcercamientoWebProspecto = New System.Windows.Forms.Label()
        Me.txtCiudad = New System.Windows.Forms.TextBox()
        Me.txtAcercamientoWebProspecto = New System.Windows.Forms.TextBox()
        Me.lblMedioContactoOtro = New System.Windows.Forms.Label()
        Me.lblAcercamientoOtro = New System.Windows.Forms.Label()
        Me.cboAcercamientoMedioContacto = New System.Windows.Forms.ComboBox()
        Me.lblAcercamientoComoEntero = New System.Windows.Forms.Label()
        Me.txtAcercamientoEnteroOtro = New System.Windows.Forms.TextBox()
        Me.cboAcercamientoComoEntero = New System.Windows.Forms.ComboBox()
        Me.lblAcercamientoMedioContacto = New System.Windows.Forms.Label()
        Me.txtAcercamientoContactoOtro = New System.Windows.Forms.TextBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
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
        Me.lblNombreComercial = New System.Windows.Forms.Label()
        Me.txtNombreComercial = New System.Windows.Forms.TextBox()
        Me.lblMensajeCargaDatosGenerales = New System.Windows.Forms.Label()
        Me.btnCancelaGeneral = New System.Windows.Forms.Button()
        Me.btnGuardaGeneral = New System.Windows.Forms.Button()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTituloDatosGenerales = New System.Windows.Forms.Label()
        Me.panMenu.SuspendLayout()
        Me.panDatosGenerales.SuspendLayout()
        Me.gpBoxDatosDG.SuspendLayout()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpBoxTipoNegocio.SuspendLayout()
        Me.gpBoxServicio.SuspendLayout()
        Me.panDivisiones.SuspendLayout()
        Me.gpBoxDatosAcercamiento.SuspendLayout()
        Me.gpBoxDatosContactoInicial.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRegistroDatosGenerales
        '
        Me.btnRegistroDatosGenerales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRegistroDatosGenerales.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistroDatosGenerales.Location = New System.Drawing.Point(237, 644)
        Me.btnRegistroDatosGenerales.Name = "btnRegistroDatosGenerales"
        Me.btnRegistroDatosGenerales.Size = New System.Drawing.Size(130, 25)
        Me.btnRegistroDatosGenerales.TabIndex = 4
        Me.btnRegistroDatosGenerales.Text = "Habilitar"
        Me.btnRegistroDatosGenerales.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(1097, 644)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(130, 25)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'panMenu
        '
        Me.panMenu.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panMenu.Controls.Add(Me.txtClaveProspecto)
        Me.panMenu.Controls.Add(Me.lnkDatosGenerales)
        Me.panMenu.Controls.Add(Me.lblTitulo)
        Me.panMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.panMenu.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.panMenu.Location = New System.Drawing.Point(0, 0)
        Me.panMenu.Name = "panMenu"
        Me.panMenu.Size = New System.Drawing.Size(212, 676)
        Me.panMenu.TabIndex = 6
        '
        'txtClaveProspecto
        '
        Me.txtClaveProspecto.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.txtClaveProspecto.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold)
        Me.txtClaveProspecto.ForeColor = System.Drawing.Color.White
        Me.txtClaveProspecto.Location = New System.Drawing.Point(0, 44)
        Me.txtClaveProspecto.Name = "txtClaveProspecto"
        Me.txtClaveProspecto.Size = New System.Drawing.Size(212, 45)
        Me.txtClaveProspecto.TabIndex = 1
        Me.txtClaveProspecto.Text = "PRS000000"
        Me.txtClaveProspecto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lnkDatosGenerales
        '
        Me.lnkDatosGenerales.ActiveLinkColor = System.Drawing.Color.White
        Me.lnkDatosGenerales.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lnkDatosGenerales.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lnkDatosGenerales.ForeColor = System.Drawing.Color.White
        Me.lnkDatosGenerales.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lnkDatosGenerales.LinkColor = System.Drawing.Color.White
        Me.lnkDatosGenerales.Location = New System.Drawing.Point(0, 115)
        Me.lnkDatosGenerales.Name = "lnkDatosGenerales"
        Me.lnkDatosGenerales.Padding = New System.Windows.Forms.Padding(13, 0, 0, 0)
        Me.lnkDatosGenerales.Size = New System.Drawing.Size(212, 34)
        Me.lnkDatosGenerales.TabIndex = 2
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
        'panDatosGenerales
        '
        Me.panDatosGenerales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panDatosGenerales.AutoScroll = True
        Me.panDatosGenerales.AutoScrollMargin = New System.Drawing.Size(0, 13)
        Me.panDatosGenerales.BackColor = System.Drawing.Color.White
        Me.panDatosGenerales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panDatosGenerales.Controls.Add(Me.gpBoxDatosDG)
        Me.panDatosGenerales.Controls.Add(Me.lblMensajeCargaDatosGenerales)
        Me.panDatosGenerales.Controls.Add(Me.btnCancelaGeneral)
        Me.panDatosGenerales.Controls.Add(Me.btnGuardaGeneral)
        Me.panDatosGenerales.Controls.Add(Me.panLinea)
        Me.panDatosGenerales.Controls.Add(Me.lblTituloDatosGenerales)
        Me.panDatosGenerales.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.panDatosGenerales.Location = New System.Drawing.Point(212, 1)
        Me.panDatosGenerales.Name = "panDatosGenerales"
        Me.panDatosGenerales.Size = New System.Drawing.Size(1026, 636)
        Me.panDatosGenerales.TabIndex = 7
        Me.panDatosGenerales.Tag = "1"
        Me.panDatosGenerales.Visible = False
        '
        'gpBoxDatosDG
        '
        Me.gpBoxDatosDG.Controls.Add(Me.Lista)
        Me.gpBoxDatosDG.Controls.Add(Me.lblIndustria)
        Me.gpBoxDatosDG.Controls.Add(Me.txtIndustria)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxTipoNegocio)
        Me.gpBoxDatosDG.Controls.Add(Me.lblRFC)
        Me.gpBoxDatosDG.Controls.Add(Me.txtRFC)
        Me.gpBoxDatosDG.Controls.Add(Me.lblTituloContactoInicial)
        Me.gpBoxDatosDG.Controls.Add(Me.lblTituloAcercamiento)
        Me.gpBoxDatosDG.Controls.Add(Me.lblTituloServicio)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxServicio)
        Me.gpBoxDatosDG.Controls.Add(Me.txtRazonSocial)
        Me.gpBoxDatosDG.Controls.Add(Me.lblMensajeErrorDatosGenerales)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxDatosAcercamiento)
        Me.gpBoxDatosDG.Controls.Add(Me.lblRazonSocial)
        Me.gpBoxDatosDG.Controls.Add(Me.gpBoxDatosContactoInicial)
        Me.gpBoxDatosDG.Controls.Add(Me.lblNombreComercial)
        Me.gpBoxDatosDG.Controls.Add(Me.txtNombreComercial)
        Me.gpBoxDatosDG.Enabled = False
        Me.gpBoxDatosDG.Location = New System.Drawing.Point(14, 62)
        Me.gpBoxDatosDG.Name = "gpBoxDatosDG"
        Me.gpBoxDatosDG.Size = New System.Drawing.Size(971, 866)
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
        Me.Lista.Location = New System.Drawing.Point(157, 42)
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = True
        Me.Lista.RowHeadersWidth = 25
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.Lista.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Lista.RowTemplate.Height = 26
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(735, 190)
        Me.Lista.TabIndex = 2
        Me.Lista.Visible = False
        '
        'lblIndustria
        '
        Me.lblIndustria.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblIndustria.Location = New System.Drawing.Point(25, 125)
        Me.lblIndustria.Name = "lblIndustria"
        Me.lblIndustria.Size = New System.Drawing.Size(126, 43)
        Me.lblIndustria.TabIndex = 7
        Me.lblIndustria.Text = "Industria o sector (Opcional):"
        Me.lblIndustria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIndustria
        '
        Me.txtIndustria.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtIndustria.Location = New System.Drawing.Point(157, 143)
        Me.txtIndustria.Name = "txtIndustria"
        Me.txtIndustria.Size = New System.Drawing.Size(373, 25)
        Me.txtIndustria.TabIndex = 8
        '
        'gpBoxTipoNegocio
        '
        Me.gpBoxTipoNegocio.Controls.Add(Me.rdPersonaFisica)
        Me.gpBoxTipoNegocio.Controls.Add(Me.rdPersonalMoral)
        Me.gpBoxTipoNegocio.Location = New System.Drawing.Point(549, 87)
        Me.gpBoxTipoNegocio.Name = "gpBoxTipoNegocio"
        Me.gpBoxTipoNegocio.Size = New System.Drawing.Size(343, 81)
        Me.gpBoxTipoNegocio.TabIndex = 9
        Me.gpBoxTipoNegocio.TabStop = False
        Me.gpBoxTipoNegocio.Text = "Tipo de Negocio"
        '
        'rdPersonaFisica
        '
        Me.rdPersonaFisica.AutoSize = True
        Me.rdPersonaFisica.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.rdPersonaFisica.Location = New System.Drawing.Point(188, 36)
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
        Me.rdPersonalMoral.Location = New System.Drawing.Point(44, 36)
        Me.rdPersonalMoral.Name = "rdPersonalMoral"
        Me.rdPersonalMoral.Size = New System.Drawing.Size(115, 22)
        Me.rdPersonalMoral.TabIndex = 0
        Me.rdPersonalMoral.TabStop = True
        Me.rdPersonalMoral.Text = "Persona moral"
        Me.rdPersonalMoral.UseVisualStyleBackColor = True
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblRFC.Location = New System.Drawing.Point(25, 97)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(103, 18)
        Me.lblRFC.TabIndex = 5
        Me.lblRFC.Text = "RFC (Opcional):"
        '
        'txtRFC
        '
        Me.txtRFC.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRFC.Location = New System.Drawing.Point(157, 94)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(253, 25)
        Me.txtRFC.TabIndex = 6
        '
        'lblTituloContactoInicial
        '
        Me.lblTituloContactoInicial.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloContactoInicial.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloContactoInicial.ForeColor = System.Drawing.Color.White
        Me.lblTituloContactoInicial.Location = New System.Drawing.Point(28, 181)
        Me.lblTituloContactoInicial.Name = "lblTituloContactoInicial"
        Me.lblTituloContactoInicial.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.lblTituloContactoInicial.Size = New System.Drawing.Size(909, 20)
        Me.lblTituloContactoInicial.TabIndex = 10
        Me.lblTituloContactoInicial.Text = "Contacto Inicial"
        Me.lblTituloContactoInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTituloAcercamiento
        '
        Me.lblTituloAcercamiento.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloAcercamiento.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloAcercamiento.ForeColor = System.Drawing.Color.White
        Me.lblTituloAcercamiento.Location = New System.Drawing.Point(28, 353)
        Me.lblTituloAcercamiento.Name = "lblTituloAcercamiento"
        Me.lblTituloAcercamiento.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.lblTituloAcercamiento.Size = New System.Drawing.Size(909, 20)
        Me.lblTituloAcercamiento.TabIndex = 12
        Me.lblTituloAcercamiento.Text = "Acercamiento"
        Me.lblTituloAcercamiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTituloServicio
        '
        Me.lblTituloServicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloServicio.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloServicio.ForeColor = System.Drawing.Color.White
        Me.lblTituloServicio.Location = New System.Drawing.Point(28, 598)
        Me.lblTituloServicio.Name = "lblTituloServicio"
        Me.lblTituloServicio.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.lblTituloServicio.Size = New System.Drawing.Size(909, 20)
        Me.lblTituloServicio.TabIndex = 14
        Me.lblTituloServicio.Text = "Servicio"
        Me.lblTituloServicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpBoxServicio
        '
        Me.gpBoxServicio.Controls.Add(Me.panDivisiones)
        Me.gpBoxServicio.Controls.Add(Me.lblDescripcionSolicitud)
        Me.gpBoxServicio.Controls.Add(Me.txtDescripcionSolicitud)
        Me.gpBoxServicio.Enabled = False
        Me.gpBoxServicio.Location = New System.Drawing.Point(28, 598)
        Me.gpBoxServicio.Name = "gpBoxServicio"
        Me.gpBoxServicio.Size = New System.Drawing.Size(909, 225)
        Me.gpBoxServicio.TabIndex = 15
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
        Me.panDivisiones.Location = New System.Drawing.Point(14, 23)
        Me.panDivisiones.Name = "panDivisiones"
        Me.panDivisiones.Size = New System.Drawing.Size(875, 78)
        Me.panDivisiones.TabIndex = 11
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
        Me.lblDescripcionSolicitud.Location = New System.Drawing.Point(14, 104)
        Me.lblDescripcionSolicitud.Name = "lblDescripcionSolicitud"
        Me.lblDescripcionSolicitud.Size = New System.Drawing.Size(221, 18)
        Me.lblDescripcionSolicitud.TabIndex = 9
        Me.lblDescripcionSolicitud.Text = "Descripción del servicio solicitado:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtDescripcionSolicitud
        '
        Me.txtDescripcionSolicitud.Location = New System.Drawing.Point(14, 128)
        Me.txtDescripcionSolicitud.Multiline = True
        Me.txtDescripcionSolicitud.Name = "txtDescripcionSolicitud"
        Me.txtDescripcionSolicitud.Size = New System.Drawing.Size(880, 81)
        Me.txtDescripcionSolicitud.TabIndex = 10
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Location = New System.Drawing.Point(157, 18)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(735, 25)
        Me.txtRazonSocial.TabIndex = 1
        '
        'lblMensajeErrorDatosGenerales
        '
        Me.lblMensajeErrorDatosGenerales.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lblMensajeErrorDatosGenerales.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMensajeErrorDatosGenerales.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeErrorDatosGenerales.ForeColor = System.Drawing.Color.White
        Me.lblMensajeErrorDatosGenerales.Location = New System.Drawing.Point(3, 838)
        Me.lblMensajeErrorDatosGenerales.Name = "lblMensajeErrorDatosGenerales"
        Me.lblMensajeErrorDatosGenerales.Size = New System.Drawing.Size(965, 25)
        Me.lblMensajeErrorDatosGenerales.TabIndex = 16
        Me.lblMensajeErrorDatosGenerales.Text = "Mensaje de error"
        Me.lblMensajeErrorDatosGenerales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeErrorDatosGenerales.Visible = False
        '
        'gpBoxDatosAcercamiento
        '
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblCiudad)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblAcercamientoWebProspecto)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.txtCiudad)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.txtAcercamientoWebProspecto)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblMedioContactoOtro)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblAcercamientoOtro)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.cboAcercamientoMedioContacto)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblAcercamientoComoEntero)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.txtAcercamientoEnteroOtro)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.cboAcercamientoComoEntero)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.lblAcercamientoMedioContacto)
        Me.gpBoxDatosAcercamiento.Controls.Add(Me.txtAcercamientoContactoOtro)
        Me.gpBoxDatosAcercamiento.Enabled = False
        Me.gpBoxDatosAcercamiento.Location = New System.Drawing.Point(28, 353)
        Me.gpBoxDatosAcercamiento.Name = "gpBoxDatosAcercamiento"
        Me.gpBoxDatosAcercamiento.Size = New System.Drawing.Size(909, 229)
        Me.gpBoxDatosAcercamiento.TabIndex = 13
        Me.gpBoxDatosAcercamiento.TabStop = False
        Me.gpBoxDatosAcercamiento.Text = "Acercamiento"
        '
        'lblCiudad
        '
        Me.lblCiudad.AutoSize = True
        Me.lblCiudad.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblCiudad.Location = New System.Drawing.Point(393, 165)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(119, 18)
        Me.lblCiudad.TabIndex = 10
        Me.lblCiudad.Text = "Ciudad (Opcional)"
        '
        'lblAcercamientoWebProspecto
        '
        Me.lblAcercamientoWebProspecto.AutoSize = True
        Me.lblAcercamientoWebProspecto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcercamientoWebProspecto.Location = New System.Drawing.Point(47, 160)
        Me.lblAcercamientoWebProspecto.Name = "lblAcercamientoWebProspecto"
        Me.lblAcercamientoWebProspecto.Size = New System.Drawing.Size(167, 18)
        Me.lblAcercamientoWebProspecto.TabIndex = 8
        Me.lblAcercamientoWebProspecto.Text = "Página web del prospecto"
        '
        'txtCiudad
        '
        Me.txtCiudad.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCiudad.Location = New System.Drawing.Point(393, 186)
        Me.txtCiudad.Name = "txtCiudad"
        Me.txtCiudad.Size = New System.Drawing.Size(297, 25)
        Me.txtCiudad.TabIndex = 11
        '
        'txtAcercamientoWebProspecto
        '
        Me.txtAcercamientoWebProspecto.Location = New System.Drawing.Point(47, 186)
        Me.txtAcercamientoWebProspecto.Name = "txtAcercamientoWebProspecto"
        Me.txtAcercamientoWebProspecto.Size = New System.Drawing.Size(332, 25)
        Me.txtAcercamientoWebProspecto.TabIndex = 9
        '
        'lblMedioContactoOtro
        '
        Me.lblMedioContactoOtro.AutoSize = True
        Me.lblMedioContactoOtro.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedioContactoOtro.Location = New System.Drawing.Point(393, 102)
        Me.lblMedioContactoOtro.Name = "lblMedioContactoOtro"
        Me.lblMedioContactoOtro.Size = New System.Drawing.Size(36, 18)
        Me.lblMedioContactoOtro.TabIndex = 6
        Me.lblMedioContactoOtro.Text = "Otro"
        '
        'lblAcercamientoOtro
        '
        Me.lblAcercamientoOtro.AutoSize = True
        Me.lblAcercamientoOtro.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcercamientoOtro.Location = New System.Drawing.Point(393, 38)
        Me.lblAcercamientoOtro.Name = "lblAcercamientoOtro"
        Me.lblAcercamientoOtro.Size = New System.Drawing.Size(36, 18)
        Me.lblAcercamientoOtro.TabIndex = 2
        Me.lblAcercamientoOtro.Text = "Otro"
        '
        'cboAcercamientoMedioContacto
        '
        Me.cboAcercamientoMedioContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAcercamientoMedioContacto.FormattingEnabled = True
        Me.cboAcercamientoMedioContacto.Location = New System.Drawing.Point(47, 122)
        Me.cboAcercamientoMedioContacto.Name = "cboAcercamientoMedioContacto"
        Me.cboAcercamientoMedioContacto.Size = New System.Drawing.Size(332, 26)
        Me.cboAcercamientoMedioContacto.TabIndex = 5
        '
        'lblAcercamientoComoEntero
        '
        Me.lblAcercamientoComoEntero.AutoSize = True
        Me.lblAcercamientoComoEntero.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcercamientoComoEntero.Location = New System.Drawing.Point(47, 38)
        Me.lblAcercamientoComoEntero.Name = "lblAcercamientoComoEntero"
        Me.lblAcercamientoComoEntero.Size = New System.Drawing.Size(196, 18)
        Me.lblAcercamientoComoEntero.TabIndex = 0
        Me.lblAcercamientoComoEntero.Text = "¿Cómo se enteró de nosotros?"
        '
        'txtAcercamientoEnteroOtro
        '
        Me.txtAcercamientoEnteroOtro.Enabled = False
        Me.txtAcercamientoEnteroOtro.Location = New System.Drawing.Point(393, 65)
        Me.txtAcercamientoEnteroOtro.Name = "txtAcercamientoEnteroOtro"
        Me.txtAcercamientoEnteroOtro.Size = New System.Drawing.Size(297, 25)
        Me.txtAcercamientoEnteroOtro.TabIndex = 3
        '
        'cboAcercamientoComoEntero
        '
        Me.cboAcercamientoComoEntero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAcercamientoComoEntero.FormattingEnabled = True
        Me.cboAcercamientoComoEntero.Location = New System.Drawing.Point(47, 64)
        Me.cboAcercamientoComoEntero.Name = "cboAcercamientoComoEntero"
        Me.cboAcercamientoComoEntero.Size = New System.Drawing.Size(332, 26)
        Me.cboAcercamientoComoEntero.TabIndex = 1
        '
        'lblAcercamientoMedioContacto
        '
        Me.lblAcercamientoMedioContacto.AutoSize = True
        Me.lblAcercamientoMedioContacto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcercamientoMedioContacto.Location = New System.Drawing.Point(47, 102)
        Me.lblAcercamientoMedioContacto.Name = "lblAcercamientoMedioContacto"
        Me.lblAcercamientoMedioContacto.Size = New System.Drawing.Size(123, 18)
        Me.lblAcercamientoMedioContacto.TabIndex = 4
        Me.lblAcercamientoMedioContacto.Text = "Medio de contacto"
        '
        'txtAcercamientoContactoOtro
        '
        Me.txtAcercamientoContactoOtro.Enabled = False
        Me.txtAcercamientoContactoOtro.Location = New System.Drawing.Point(393, 122)
        Me.txtAcercamientoContactoOtro.Name = "txtAcercamientoContactoOtro"
        Me.txtAcercamientoContactoOtro.Size = New System.Drawing.Size(297, 25)
        Me.txtAcercamientoContactoOtro.TabIndex = 7
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(25, 21)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(87, 18)
        Me.lblRazonSocial.TabIndex = 0
        Me.lblRazonSocial.Text = "Razón social:"
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
        Me.gpBoxDatosContactoInicial.Location = New System.Drawing.Point(28, 181)
        Me.gpBoxDatosContactoInicial.Name = "gpBoxDatosContactoInicial"
        Me.gpBoxDatosContactoInicial.Size = New System.Drawing.Size(909, 157)
        Me.gpBoxDatosContactoInicial.TabIndex = 11
        Me.gpBoxDatosContactoInicial.TabStop = False
        Me.gpBoxDatosContactoInicial.Text = "Contacto Inicial"
        '
        'lblContactoInicialNombre
        '
        Me.lblContactoInicialNombre.AutoSize = True
        Me.lblContactoInicialNombre.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblContactoInicialNombre.Location = New System.Drawing.Point(50, 32)
        Me.lblContactoInicialNombre.Name = "lblContactoInicialNombre"
        Me.lblContactoInicialNombre.Size = New System.Drawing.Size(59, 18)
        Me.lblContactoInicialNombre.TabIndex = 0
        Me.lblContactoInicialNombre.Text = "Nombre"
        '
        'txtContactoInicialExtension
        '
        Me.txtContactoInicialExtension.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtContactoInicialExtension.Location = New System.Drawing.Point(548, 113)
        Me.txtContactoInicialExtension.Name = "txtContactoInicialExtension"
        Me.txtContactoInicialExtension.Size = New System.Drawing.Size(92, 25)
        Me.txtContactoInicialExtension.TabIndex = 9
        '
        'txtContactoInicialNombre
        '
        Me.txtContactoInicialNombre.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtContactoInicialNombre.Location = New System.Drawing.Point(50, 53)
        Me.txtContactoInicialNombre.Name = "txtContactoInicialNombre"
        Me.txtContactoInicialNombre.Size = New System.Drawing.Size(332, 25)
        Me.txtContactoInicialNombre.TabIndex = 1
        '
        'lblContactoInicialExtension
        '
        Me.lblContactoInicialExtension.AutoSize = True
        Me.lblContactoInicialExtension.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblContactoInicialExtension.Location = New System.Drawing.Point(548, 92)
        Me.lblContactoInicialExtension.Name = "lblContactoInicialExtension"
        Me.lblContactoInicialExtension.Size = New System.Drawing.Size(69, 18)
        Me.lblContactoInicialExtension.TabIndex = 8
        Me.lblContactoInicialExtension.Text = "Extensión"
        '
        'lblContactoInicialCargo
        '
        Me.lblContactoInicialCargo.AutoSize = True
        Me.lblContactoInicialCargo.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblContactoInicialCargo.Location = New System.Drawing.Point(407, 32)
        Me.lblContactoInicialCargo.Name = "lblContactoInicialCargo"
        Me.lblContactoInicialCargo.Size = New System.Drawing.Size(139, 18)
        Me.lblContactoInicialCargo.TabIndex = 2
        Me.lblContactoInicialCargo.Text = "Cargo en la compañia"
        '
        'txtContactoInicialTelefono
        '
        Me.txtContactoInicialTelefono.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtContactoInicialTelefono.Location = New System.Drawing.Point(407, 113)
        Me.txtContactoInicialTelefono.Name = "txtContactoInicialTelefono"
        Me.txtContactoInicialTelefono.Size = New System.Drawing.Size(128, 25)
        Me.txtContactoInicialTelefono.TabIndex = 7
        '
        'txtContactoInicialCargo
        '
        Me.txtContactoInicialCargo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtContactoInicialCargo.Location = New System.Drawing.Point(407, 53)
        Me.txtContactoInicialCargo.Name = "txtContactoInicialCargo"
        Me.txtContactoInicialCargo.Size = New System.Drawing.Size(305, 25)
        Me.txtContactoInicialCargo.TabIndex = 3
        '
        'lblContactoInicialTelefono
        '
        Me.lblContactoInicialTelefono.AutoSize = True
        Me.lblContactoInicialTelefono.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblContactoInicialTelefono.Location = New System.Drawing.Point(407, 92)
        Me.lblContactoInicialTelefono.Name = "lblContactoInicialTelefono"
        Me.lblContactoInicialTelefono.Size = New System.Drawing.Size(63, 18)
        Me.lblContactoInicialTelefono.TabIndex = 6
        Me.lblContactoInicialTelefono.Text = "Teléfono"
        '
        'lblContactoInicialCorreo
        '
        Me.lblContactoInicialCorreo.AutoSize = True
        Me.lblContactoInicialCorreo.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.lblContactoInicialCorreo.Location = New System.Drawing.Point(50, 92)
        Me.lblContactoInicialCorreo.Name = "lblContactoInicialCorreo"
        Me.lblContactoInicialCorreo.Size = New System.Drawing.Size(123, 18)
        Me.lblContactoInicialCorreo.TabIndex = 4
        Me.lblContactoInicialCorreo.Text = "Correo electrónico"
        '
        'txtContactoInicialCorreo
        '
        Me.txtContactoInicialCorreo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtContactoInicialCorreo.Location = New System.Drawing.Point(50, 113)
        Me.txtContactoInicialCorreo.Name = "txtContactoInicialCorreo"
        Me.txtContactoInicialCorreo.Size = New System.Drawing.Size(332, 25)
        Me.txtContactoInicialCorreo.TabIndex = 5
        '
        'lblNombreComercial
        '
        Me.lblNombreComercial.AutoSize = True
        Me.lblNombreComercial.Location = New System.Drawing.Point(25, 60)
        Me.lblNombreComercial.Name = "lblNombreComercial"
        Me.lblNombreComercial.Size = New System.Drawing.Size(126, 18)
        Me.lblNombreComercial.TabIndex = 3
        Me.lblNombreComercial.Text = "Nombre comercial:"
        '
        'txtNombreComercial
        '
        Me.txtNombreComercial.Location = New System.Drawing.Point(157, 56)
        Me.txtNombreComercial.Name = "txtNombreComercial"
        Me.txtNombreComercial.Size = New System.Drawing.Size(735, 25)
        Me.txtNombreComercial.TabIndex = 4
        '
        'lblMensajeCargaDatosGenerales
        '
        Me.lblMensajeCargaDatosGenerales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMensajeCargaDatosGenerales.BackColor = System.Drawing.Color.Goldenrod
        Me.lblMensajeCargaDatosGenerales.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeCargaDatosGenerales.ForeColor = System.Drawing.Color.White
        Me.lblMensajeCargaDatosGenerales.Location = New System.Drawing.Point(0, 36)
        Me.lblMensajeCargaDatosGenerales.Name = "lblMensajeCargaDatosGenerales"
        Me.lblMensajeCargaDatosGenerales.Size = New System.Drawing.Size(990, 25)
        Me.lblMensajeCargaDatosGenerales.TabIndex = 2
        Me.lblMensajeCargaDatosGenerales.Text = "No se ha cargado información de los Datos Generales para el prospecto."
        Me.lblMensajeCargaDatosGenerales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeCargaDatosGenerales.Visible = False
        '
        'btnCancelaGeneral
        '
        Me.btnCancelaGeneral.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelaGeneral.Location = New System.Drawing.Point(717, 934)
        Me.btnCancelaGeneral.Name = "btnCancelaGeneral"
        Me.btnCancelaGeneral.Size = New System.Drawing.Size(130, 25)
        Me.btnCancelaGeneral.TabIndex = 4
        Me.btnCancelaGeneral.Text = "Cancelar"
        Me.btnCancelaGeneral.UseVisualStyleBackColor = True
        '
        'btnGuardaGeneral
        '
        Me.btnGuardaGeneral.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardaGeneral.Location = New System.Drawing.Point(855, 934)
        Me.btnGuardaGeneral.Name = "btnGuardaGeneral"
        Me.btnGuardaGeneral.Size = New System.Drawing.Size(130, 25)
        Me.btnGuardaGeneral.TabIndex = 5
        Me.btnGuardaGeneral.Text = "Guardar"
        Me.btnGuardaGeneral.UseVisualStyleBackColor = True
        '
        'panLinea
        '
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(1, 29)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(300, 3)
        Me.panLinea.TabIndex = 1
        '
        'lblTituloDatosGenerales
        '
        Me.lblTituloDatosGenerales.AutoSize = True
        Me.lblTituloDatosGenerales.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloDatosGenerales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloDatosGenerales.Location = New System.Drawing.Point(1, 2)
        Me.lblTituloDatosGenerales.Name = "lblTituloDatosGenerales"
        Me.lblTituloDatosGenerales.Size = New System.Drawing.Size(200, 29)
        Me.lblTituloDatosGenerales.TabIndex = 0
        Me.lblTituloDatosGenerales.Text = "DATOS GENERALES"
        '
        'FrmContactoBasico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1238, 676)
        Me.Controls.Add(Me.panDatosGenerales)
        Me.Controls.Add(Me.panMenu)
        Me.Controls.Add(Me.btnRegistroDatosGenerales)
        Me.Controls.Add(Me.btnCerrar)
        Me.Name = "FrmContactoBasico"
        Me.Text = "Alta de Cliente prospecto"
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
        Me.gpBoxDatosAcercamiento.ResumeLayout(False)
        Me.gpBoxDatosAcercamiento.PerformLayout()
        Me.gpBoxDatosContactoInicial.ResumeLayout(False)
        Me.gpBoxDatosContactoInicial.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnRegistroDatosGenerales As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents panMenu As Panel
    Friend WithEvents txtClaveProspecto As Label
    Friend WithEvents lnkDatosGenerales As LinkLabel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents panDatosGenerales As Panel
    Friend WithEvents gpBoxDatosDG As GroupBox
    Friend WithEvents Lista As DataGridView
    Friend WithEvents lblIndustria As Label
    Friend WithEvents txtIndustria As TextBox
    Friend WithEvents gpBoxTipoNegocio As GroupBox
    Friend WithEvents rdPersonaFisica As RadioButton
    Friend WithEvents rdPersonalMoral As RadioButton
    Friend WithEvents lblRFC As Label
    Friend WithEvents txtRFC As TextBox
    Friend WithEvents lblTituloContactoInicial As Label
    Friend WithEvents lblTituloAcercamiento As Label
    Friend WithEvents lblTituloServicio As Label
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
    Friend WithEvents txtRazonSocial As TextBox
    Friend WithEvents lblMensajeErrorDatosGenerales As Label
    Friend WithEvents gpBoxDatosAcercamiento As GroupBox
    Friend WithEvents lblCiudad As Label
    Friend WithEvents lblAcercamientoWebProspecto As Label
    Friend WithEvents txtCiudad As TextBox
    Friend WithEvents txtAcercamientoWebProspecto As TextBox
    Friend WithEvents lblMedioContactoOtro As Label
    Friend WithEvents lblAcercamientoOtro As Label
    Friend WithEvents cboAcercamientoMedioContacto As ComboBox
    Friend WithEvents lblAcercamientoComoEntero As Label
    Friend WithEvents txtAcercamientoEnteroOtro As TextBox
    Friend WithEvents cboAcercamientoComoEntero As ComboBox
    Friend WithEvents lblAcercamientoMedioContacto As Label
    Friend WithEvents txtAcercamientoContactoOtro As TextBox
    Friend WithEvents lblRazonSocial As Label
    Friend WithEvents gpBoxDatosContactoInicial As GroupBox
    Friend WithEvents lblContactoInicialNombre As Label
    Friend WithEvents txtContactoInicialExtension As TextBox
    Friend WithEvents txtContactoInicialNombre As TextBox
    Friend WithEvents lblContactoInicialExtension As Label
    Friend WithEvents lblContactoInicialCargo As Label
    Friend WithEvents txtContactoInicialTelefono As TextBox
    Friend WithEvents txtContactoInicialCargo As TextBox
    Friend WithEvents lblContactoInicialTelefono As Label
    Friend WithEvents lblContactoInicialCorreo As Label
    Friend WithEvents txtContactoInicialCorreo As TextBox
    Friend WithEvents lblNombreComercial As Label
    Friend WithEvents txtNombreComercial As TextBox
    Friend WithEvents lblMensajeCargaDatosGenerales As Label
    Friend WithEvents btnCancelaGeneral As Button
    Friend WithEvents btnGuardaGeneral As Button
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTituloDatosGenerales As Label
End Class
