<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DlgFolioInforme
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
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.btnGenerarFolio = New System.Windows.Forms.Button()
        Me.lblTituloIEs = New System.Windows.Forms.Label()
        Me.lblTituloIE = New System.Windows.Forms.Label()
        Me.gpBoxDatosInforme = New System.Windows.Forms.GroupBox()
        Me.gpBoxRespuesta = New System.Windows.Forms.GroupBox()
        Me.rdSi = New System.Windows.Forms.RadioButton()
        Me.rdNo = New System.Windows.Forms.RadioButton()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.lblPregunta = New System.Windows.Forms.Label()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.lblArchivo = New System.Windows.Forms.Label()
        Me.lblOpinion = New System.Windows.Forms.Label()
        Me.lblIdioma = New System.Windows.Forms.Label()
        Me.lblInforme = New System.Windows.Forms.Label()
        Me.lblBasadoEn = New System.Windows.Forms.Label()
        Me.cboIdioma = New System.Windows.Forms.ComboBox()
        Me.cboBasadoEn = New System.Windows.Forms.ComboBox()
        Me.cboOpinion = New System.Windows.Forms.ComboBox()
        Me.cboInforme = New System.Windows.Forms.ComboBox()
        Me.lblFechaInforme = New System.Windows.Forms.Label()
        Me.lblFechaPeriodo = New System.Windows.Forms.Label()
        Me.txtFechaInforme = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaPeriodo = New System.Windows.Forms.DateTimePicker()
        Me.txtInformeRelativo = New System.Windows.Forms.TextBox()
        Me.txtIdiomaOtro = New System.Windows.Forms.TextBox()
        Me.lblIdiomaOtro = New System.Windows.Forms.Label()
        Me.txtOpinionDetalle = New System.Windows.Forms.TextBox()
        Me.lblOpinionDetalle = New System.Windows.Forms.Label()
        Me.lblInformeRelativo = New System.Windows.Forms.Label()
        Me.lblBasadoDetalle = New System.Windows.Forms.Label()
        Me.txtBasadoDetalle = New System.Windows.Forms.TextBox()
        Me.btnCopiarFolio = New System.Windows.Forms.Button()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.gpBoxDatos = New System.Windows.Forms.GroupBox()
        Me.lblDetalle = New System.Windows.Forms.LinkLabel()
        Me.lblMsgError = New System.Windows.Forms.Label()
        Me.lblCteRel = New System.Windows.Forms.Label()
        Me.txtCteRelacionado = New System.Windows.Forms.TextBox()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.txtDivision = New System.Windows.Forms.TextBox()
        Me.txtTrabajo = New System.Windows.Forms.TextBox()
        Me.txtOficina = New System.Windows.Forms.TextBox()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.lblTrabajo = New System.Windows.Forms.Label()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.gpBoxDatosInforme.SuspendLayout()
        Me.gpBoxRespuesta.SuspendLayout()
        Me.gpBoxDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.btnGenerarFolio)
        Me.panPrincipal.Controls.Add(Me.lblTituloIEs)
        Me.panPrincipal.Controls.Add(Me.lblTituloIE)
        Me.panPrincipal.Controls.Add(Me.gpBoxDatosInforme)
        Me.panPrincipal.Controls.Add(Me.btnCopiarFolio)
        Me.panPrincipal.Controls.Add(Me.txtFolio)
        Me.panPrincipal.Controls.Add(Me.gpBoxDatos)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(964, 671)
        Me.panPrincipal.TabIndex = 0
        '
        'btnGenerarFolio
        '
        Me.btnGenerarFolio.Location = New System.Drawing.Point(313, 632)
        Me.btnGenerarFolio.Name = "btnGenerarFolio"
        Me.btnGenerarFolio.Size = New System.Drawing.Size(143, 25)
        Me.btnGenerarFolio.TabIndex = 5
        Me.btnGenerarFolio.Text = "Generar Folio"
        Me.btnGenerarFolio.UseVisualStyleBackColor = True
        '
        'lblTituloIEs
        '
        Me.lblTituloIEs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTituloIEs.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.lblTituloIEs.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloIEs.ForeColor = System.Drawing.Color.White
        Me.lblTituloIEs.Location = New System.Drawing.Point(11, 219)
        Me.lblTituloIEs.Name = "lblTituloIEs"
        Me.lblTituloIEs.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblTituloIEs.Size = New System.Drawing.Size(940, 25)
        Me.lblTituloIEs.TabIndex = 3
        Me.lblTituloIEs.Text = "DATOS DEL INFORME"
        Me.lblTituloIEs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTituloIE
        '
        Me.lblTituloIE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTituloIE.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloIE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloIE.ForeColor = System.Drawing.Color.White
        Me.lblTituloIE.Location = New System.Drawing.Point(11, 11)
        Me.lblTituloIE.Name = "lblTituloIE"
        Me.lblTituloIE.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblTituloIE.Size = New System.Drawing.Size(940, 25)
        Me.lblTituloIE.TabIndex = 1
        Me.lblTituloIE.Text = "DATOS DEL TRABAJO"
        Me.lblTituloIE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpBoxDatosInforme
        '
        Me.gpBoxDatosInforme.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpBoxDatosInforme.Controls.Add(Me.gpBoxRespuesta)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblMensaje)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblPregunta)
        Me.gpBoxDatosInforme.Controls.Add(Me.txtArchivo)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblArchivo)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblOpinion)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblIdioma)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblInforme)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblBasadoEn)
        Me.gpBoxDatosInforme.Controls.Add(Me.cboIdioma)
        Me.gpBoxDatosInforme.Controls.Add(Me.cboBasadoEn)
        Me.gpBoxDatosInforme.Controls.Add(Me.cboOpinion)
        Me.gpBoxDatosInforme.Controls.Add(Me.cboInforme)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblFechaInforme)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblFechaPeriodo)
        Me.gpBoxDatosInforme.Controls.Add(Me.txtFechaInforme)
        Me.gpBoxDatosInforme.Controls.Add(Me.txtFechaPeriodo)
        Me.gpBoxDatosInforme.Controls.Add(Me.txtInformeRelativo)
        Me.gpBoxDatosInforme.Controls.Add(Me.txtIdiomaOtro)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblIdiomaOtro)
        Me.gpBoxDatosInforme.Controls.Add(Me.txtOpinionDetalle)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblOpinionDetalle)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblInformeRelativo)
        Me.gpBoxDatosInforme.Controls.Add(Me.lblBasadoDetalle)
        Me.gpBoxDatosInforme.Controls.Add(Me.txtBasadoDetalle)
        Me.gpBoxDatosInforme.Location = New System.Drawing.Point(11, 219)
        Me.gpBoxDatosInforme.Name = "gpBoxDatosInforme"
        Me.gpBoxDatosInforme.Size = New System.Drawing.Size(940, 344)
        Me.gpBoxDatosInforme.TabIndex = 2
        Me.gpBoxDatosInforme.TabStop = False
        Me.gpBoxDatosInforme.Text = "Datos del Informe"
        '
        'gpBoxRespuesta
        '
        Me.gpBoxRespuesta.Controls.Add(Me.rdSi)
        Me.gpBoxRespuesta.Controls.Add(Me.rdNo)
        Me.gpBoxRespuesta.Location = New System.Drawing.Point(278, 281)
        Me.gpBoxRespuesta.Name = "gpBoxRespuesta"
        Me.gpBoxRespuesta.Size = New System.Drawing.Size(139, 47)
        Me.gpBoxRespuesta.TabIndex = 21
        Me.gpBoxRespuesta.TabStop = False
        '
        'rdSi
        '
        Me.rdSi.AutoSize = True
        Me.rdSi.Checked = True
        Me.rdSi.Location = New System.Drawing.Point(20, 17)
        Me.rdSi.Name = "rdSi"
        Me.rdSi.Size = New System.Drawing.Size(37, 22)
        Me.rdSi.TabIndex = 21
        Me.rdSi.TabStop = True
        Me.rdSi.Text = "Sí"
        Me.rdSi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdSi.UseVisualStyleBackColor = True
        '
        'rdNo
        '
        Me.rdNo.AutoSize = True
        Me.rdNo.Location = New System.Drawing.Point(75, 17)
        Me.rdNo.Name = "rdNo"
        Me.rdNo.Size = New System.Drawing.Size(44, 22)
        Me.rdNo.TabIndex = 22
        Me.rdNo.Text = "No"
        Me.rdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdNo.UseVisualStyleBackColor = True
        '
        'lblMensaje
        '
        Me.lblMensaje.Location = New System.Drawing.Point(534, 290)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(379, 42)
        Me.lblMensaje.TabIndex = 24
        Me.lblMensaje.Text = "Indique el nombre del archivo LEAP | Voyager en el cual se documentó la auditoría" &
    " de esta compañia."
        '
        'lblPregunta
        '
        Me.lblPregunta.AutoSize = True
        Me.lblPregunta.Location = New System.Drawing.Point(80, 264)
        Me.lblPregunta.Name = "lblPregunta"
        Me.lblPregunta.Size = New System.Drawing.Size(337, 18)
        Me.lblPregunta.TabIndex = 20
        Me.lblPregunta.Text = "¿Esta compañia cuenta con su propio LEAP | Voyager?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtArchivo
        '
        Me.txtArchivo.Enabled = False
        Me.txtArchivo.Location = New System.Drawing.Point(534, 261)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(379, 25)
        Me.txtArchivo.TabIndex = 23
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.Location = New System.Drawing.Point(453, 264)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(59, 18)
        Me.lblArchivo.TabIndex = 22
        Me.lblArchivo.Text = "Archivo:"
        '
        'lblOpinion
        '
        Me.lblOpinion.AutoSize = True
        Me.lblOpinion.Location = New System.Drawing.Point(27, 151)
        Me.lblOpinion.Name = "lblOpinion"
        Me.lblOpinion.Size = New System.Drawing.Size(62, 18)
        Me.lblOpinion.TabIndex = 8
        Me.lblOpinion.Text = "Opinión:"
        '
        'lblIdioma
        '
        Me.lblIdioma.AutoSize = True
        Me.lblIdioma.Location = New System.Drawing.Point(27, 225)
        Me.lblIdioma.Name = "lblIdioma"
        Me.lblIdioma.Size = New System.Drawing.Size(55, 18)
        Me.lblIdioma.TabIndex = 16
        Me.lblIdioma.Text = "Idioma:"
        '
        'lblInforme
        '
        Me.lblInforme.AutoSize = True
        Me.lblInforme.Location = New System.Drawing.Point(27, 114)
        Me.lblInforme.Name = "lblInforme"
        Me.lblInforme.Size = New System.Drawing.Size(62, 18)
        Me.lblInforme.TabIndex = 4
        Me.lblInforme.Text = "Informe:"
        '
        'lblBasadoEn
        '
        Me.lblBasadoEn.AutoSize = True
        Me.lblBasadoEn.Location = New System.Drawing.Point(27, 188)
        Me.lblBasadoEn.Name = "lblBasadoEn"
        Me.lblBasadoEn.Size = New System.Drawing.Size(75, 18)
        Me.lblBasadoEn.TabIndex = 12
        Me.lblBasadoEn.Text = "Basado en:"
        '
        'cboIdioma
        '
        Me.cboIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIdioma.FormattingEnabled = True
        Me.cboIdioma.Location = New System.Drawing.Point(108, 221)
        Me.cboIdioma.Name = "cboIdioma"
        Me.cboIdioma.Size = New System.Drawing.Size(309, 26)
        Me.cboIdioma.TabIndex = 17
        '
        'cboBasadoEn
        '
        Me.cboBasadoEn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBasadoEn.FormattingEnabled = True
        Me.cboBasadoEn.Location = New System.Drawing.Point(108, 184)
        Me.cboBasadoEn.Name = "cboBasadoEn"
        Me.cboBasadoEn.Size = New System.Drawing.Size(309, 26)
        Me.cboBasadoEn.TabIndex = 13
        '
        'cboOpinion
        '
        Me.cboOpinion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOpinion.FormattingEnabled = True
        Me.cboOpinion.Location = New System.Drawing.Point(108, 147)
        Me.cboOpinion.Name = "cboOpinion"
        Me.cboOpinion.Size = New System.Drawing.Size(309, 26)
        Me.cboOpinion.TabIndex = 9
        '
        'cboInforme
        '
        Me.cboInforme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInforme.FormattingEnabled = True
        Me.cboInforme.Location = New System.Drawing.Point(108, 110)
        Me.cboInforme.Name = "cboInforme"
        Me.cboInforme.Size = New System.Drawing.Size(309, 26)
        Me.cboInforme.TabIndex = 5
        '
        'lblFechaInforme
        '
        Me.lblFechaInforme.AutoSize = True
        Me.lblFechaInforme.Location = New System.Drawing.Point(108, 75)
        Me.lblFechaInforme.Name = "lblFechaInforme"
        Me.lblFechaInforme.Size = New System.Drawing.Size(124, 18)
        Me.lblFechaInforme.TabIndex = 2
        Me.lblFechaInforme.Text = "Fecha del informe:"
        '
        'lblFechaPeriodo
        '
        Me.lblFechaPeriodo.AutoSize = True
        Me.lblFechaPeriodo.Location = New System.Drawing.Point(108, 42)
        Me.lblFechaPeriodo.Name = "lblFechaPeriodo"
        Me.lblFechaPeriodo.Size = New System.Drawing.Size(195, 18)
        Me.lblFechaPeriodo.TabIndex = 0
        Me.lblFechaPeriodo.Text = "Fecha de periodo del informe:"
        '
        'txtFechaInforme
        '
        Me.txtFechaInforme.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaInforme.Location = New System.Drawing.Point(306, 72)
        Me.txtFechaInforme.MinDate = New Date(2023, 8, 1, 0, 0, 0, 0)
        Me.txtFechaInforme.Name = "txtFechaInforme"
        Me.txtFechaInforme.Size = New System.Drawing.Size(111, 25)
        Me.txtFechaInforme.TabIndex = 3
        Me.txtFechaInforme.Value = New Date(2023, 8, 1, 0, 0, 0, 0)
        '
        'txtFechaPeriodo
        '
        Me.txtFechaPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaPeriodo.Location = New System.Drawing.Point(306, 39)
        Me.txtFechaPeriodo.MinDate = New Date(2019, 12, 31, 0, 0, 0, 0)
        Me.txtFechaPeriodo.Name = "txtFechaPeriodo"
        Me.txtFechaPeriodo.Size = New System.Drawing.Size(111, 25)
        Me.txtFechaPeriodo.TabIndex = 1
        Me.txtFechaPeriodo.Value = New Date(2023, 1, 25, 23, 59, 59, 0)
        '
        'txtInformeRelativo
        '
        Me.txtInformeRelativo.Enabled = False
        Me.txtInformeRelativo.Location = New System.Drawing.Point(534, 111)
        Me.txtInformeRelativo.Name = "txtInformeRelativo"
        Me.txtInformeRelativo.ReadOnly = True
        Me.txtInformeRelativo.Size = New System.Drawing.Size(379, 25)
        Me.txtInformeRelativo.TabIndex = 7
        '
        'txtIdiomaOtro
        '
        Me.txtIdiomaOtro.Enabled = False
        Me.txtIdiomaOtro.Location = New System.Drawing.Point(534, 222)
        Me.txtIdiomaOtro.Name = "txtIdiomaOtro"
        Me.txtIdiomaOtro.ReadOnly = True
        Me.txtIdiomaOtro.Size = New System.Drawing.Size(379, 25)
        Me.txtIdiomaOtro.TabIndex = 19
        '
        'lblIdiomaOtro
        '
        Me.lblIdiomaOtro.AutoSize = True
        Me.lblIdiomaOtro.Location = New System.Drawing.Point(453, 225)
        Me.lblIdiomaOtro.Name = "lblIdiomaOtro"
        Me.lblIdiomaOtro.Size = New System.Drawing.Size(40, 18)
        Me.lblIdiomaOtro.TabIndex = 18
        Me.lblIdiomaOtro.Text = "Otro:"
        '
        'txtOpinionDetalle
        '
        Me.txtOpinionDetalle.Enabled = False
        Me.txtOpinionDetalle.Location = New System.Drawing.Point(534, 148)
        Me.txtOpinionDetalle.Name = "txtOpinionDetalle"
        Me.txtOpinionDetalle.ReadOnly = True
        Me.txtOpinionDetalle.Size = New System.Drawing.Size(379, 25)
        Me.txtOpinionDetalle.TabIndex = 11
        '
        'lblOpinionDetalle
        '
        Me.lblOpinionDetalle.AutoSize = True
        Me.lblOpinionDetalle.Location = New System.Drawing.Point(453, 151)
        Me.lblOpinionDetalle.Name = "lblOpinionDetalle"
        Me.lblOpinionDetalle.Size = New System.Drawing.Size(57, 18)
        Me.lblOpinionDetalle.TabIndex = 10
        Me.lblOpinionDetalle.Text = "Detalle:"
        '
        'lblInformeRelativo
        '
        Me.lblInformeRelativo.AutoSize = True
        Me.lblInformeRelativo.Location = New System.Drawing.Point(453, 114)
        Me.lblInformeRelativo.Name = "lblInformeRelativo"
        Me.lblInformeRelativo.Size = New System.Drawing.Size(73, 18)
        Me.lblInformeRelativo.TabIndex = 6
        Me.lblInformeRelativo.Text = "Relativo a:"
        '
        'lblBasadoDetalle
        '
        Me.lblBasadoDetalle.AutoSize = True
        Me.lblBasadoDetalle.Location = New System.Drawing.Point(453, 188)
        Me.lblBasadoDetalle.Name = "lblBasadoDetalle"
        Me.lblBasadoDetalle.Size = New System.Drawing.Size(57, 18)
        Me.lblBasadoDetalle.TabIndex = 14
        Me.lblBasadoDetalle.Text = "Detalle:"
        '
        'txtBasadoDetalle
        '
        Me.txtBasadoDetalle.Enabled = False
        Me.txtBasadoDetalle.Location = New System.Drawing.Point(534, 185)
        Me.txtBasadoDetalle.Name = "txtBasadoDetalle"
        Me.txtBasadoDetalle.ReadOnly = True
        Me.txtBasadoDetalle.Size = New System.Drawing.Size(379, 25)
        Me.txtBasadoDetalle.TabIndex = 15
        '
        'btnCopiarFolio
        '
        Me.btnCopiarFolio.Enabled = False
        Me.btnCopiarFolio.Location = New System.Drawing.Point(507, 632)
        Me.btnCopiarFolio.Name = "btnCopiarFolio"
        Me.btnCopiarFolio.Size = New System.Drawing.Size(143, 25)
        Me.btnCopiarFolio.TabIndex = 6
        Me.btnCopiarFolio.Text = "Copiar Folio"
        Me.btnCopiarFolio.UseVisualStyleBackColor = True
        '
        'txtFolio
        '
        Me.txtFolio.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFolio.Font = New System.Drawing.Font("Calibri", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.txtFolio.Location = New System.Drawing.Point(313, 574)
        Me.txtFolio.Margin = New System.Windows.Forms.Padding(0)
        Me.txtFolio.Multiline = True
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.Size = New System.Drawing.Size(337, 46)
        Me.txtFolio.TabIndex = 4
        Me.txtFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gpBoxDatos
        '
        Me.gpBoxDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpBoxDatos.Controls.Add(Me.lblDetalle)
        Me.gpBoxDatos.Controls.Add(Me.lblMsgError)
        Me.gpBoxDatos.Controls.Add(Me.lblCteRel)
        Me.gpBoxDatos.Controls.Add(Me.txtCteRelacionado)
        Me.gpBoxDatos.Controls.Add(Me.lblDivision)
        Me.gpBoxDatos.Controls.Add(Me.txtDivision)
        Me.gpBoxDatos.Controls.Add(Me.txtTrabajo)
        Me.gpBoxDatos.Controls.Add(Me.txtOficina)
        Me.gpBoxDatos.Controls.Add(Me.lblOficina)
        Me.gpBoxDatos.Controls.Add(Me.txtCliente)
        Me.gpBoxDatos.Controls.Add(Me.txtServicio)
        Me.gpBoxDatos.Controls.Add(Me.lblTrabajo)
        Me.gpBoxDatos.Controls.Add(Me.lblServicio)
        Me.gpBoxDatos.Controls.Add(Me.btnBuscar)
        Me.gpBoxDatos.Location = New System.Drawing.Point(11, 11)
        Me.gpBoxDatos.Name = "gpBoxDatos"
        Me.gpBoxDatos.Size = New System.Drawing.Size(940, 195)
        Me.gpBoxDatos.TabIndex = 0
        Me.gpBoxDatos.TabStop = False
        Me.gpBoxDatos.Text = "Datos del Trabajo"
        '
        'lblDetalle
        '
        Me.lblDetalle.ActiveLinkColor = System.Drawing.Color.Black
        Me.lblDetalle.AutoSize = True
        Me.lblDetalle.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetalle.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline
        Me.lblDetalle.LinkColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblDetalle.Location = New System.Drawing.Point(853, 71)
        Me.lblDetalle.Name = "lblDetalle"
        Me.lblDetalle.Size = New System.Drawing.Size(76, 18)
        Me.lblDetalle.TabIndex = 13
        Me.lblDetalle.TabStop = True
        Me.lblDetalle.Text = "Ver detalle"
        Me.lblDetalle.Visible = False
        '
        'lblMsgError
        '
        Me.lblMsgError.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lblMsgError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMsgError.ForeColor = System.Drawing.Color.White
        Me.lblMsgError.Location = New System.Drawing.Point(106, 66)
        Me.lblMsgError.Name = "lblMsgError"
        Me.lblMsgError.Size = New System.Drawing.Size(741, 20)
        Me.lblMsgError.TabIndex = 12
        Me.lblMsgError.Text = "No es posible generar un folio de informe para la clave de trabajo. Por favor sol" &
    "icite autorizacion."
        Me.lblMsgError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMsgError.Visible = False
        '
        'lblCteRel
        '
        Me.lblCteRel.Location = New System.Drawing.Point(12, 81)
        Me.lblCteRel.Name = "lblCteRel"
        Me.lblCteRel.Size = New System.Drawing.Size(91, 36)
        Me.lblCteRel.TabIndex = 4
        Me.lblCteRel.Text = "Cliente relacionado:"
        '
        'txtCteRelacionado
        '
        Me.txtCteRelacionado.Location = New System.Drawing.Point(106, 92)
        Me.txtCteRelacionado.Name = "txtCteRelacionado"
        Me.txtCteRelacionado.Size = New System.Drawing.Size(823, 25)
        Me.txtCteRelacionado.TabIndex = 5
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(240, 161)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(62, 18)
        Me.lblDivision.TabIndex = 10
        Me.lblDivision.Text = "División:"
        '
        'txtDivision
        '
        Me.txtDivision.Location = New System.Drawing.Point(308, 158)
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.ReadOnly = True
        Me.txtDivision.Size = New System.Drawing.Size(111, 25)
        Me.txtDivision.TabIndex = 11
        Me.txtDivision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTrabajo
        '
        Me.txtTrabajo.Location = New System.Drawing.Point(106, 36)
        Me.txtTrabajo.Name = "txtTrabajo"
        Me.txtTrabajo.ReadOnly = True
        Me.txtTrabajo.Size = New System.Drawing.Size(160, 25)
        Me.txtTrabajo.TabIndex = 1
        Me.txtTrabajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtOficina
        '
        Me.txtOficina.Location = New System.Drawing.Point(106, 158)
        Me.txtOficina.Name = "txtOficina"
        Me.txtOficina.ReadOnly = True
        Me.txtOficina.Size = New System.Drawing.Size(111, 25)
        Me.txtOficina.TabIndex = 9
        Me.txtOficina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Location = New System.Drawing.Point(12, 161)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(55, 18)
        Me.lblOficina.TabIndex = 8
        Me.lblOficina.Text = "Oficina:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(272, 36)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(499, 25)
        Me.txtCliente.TabIndex = 2
        '
        'txtServicio
        '
        Me.txtServicio.Location = New System.Drawing.Point(106, 125)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.ReadOnly = True
        Me.txtServicio.Size = New System.Drawing.Size(823, 25)
        Me.txtServicio.TabIndex = 7
        '
        'lblTrabajo
        '
        Me.lblTrabajo.AutoSize = True
        Me.lblTrabajo.Location = New System.Drawing.Point(12, 39)
        Me.lblTrabajo.Name = "lblTrabajo"
        Me.lblTrabajo.Size = New System.Drawing.Size(57, 18)
        Me.lblTrabajo.TabIndex = 0
        Me.lblTrabajo.Text = "Trabajo:"
        '
        'lblServicio
        '
        Me.lblServicio.AutoSize = True
        Me.lblServicio.Location = New System.Drawing.Point(12, 128)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(61, 18)
        Me.lblServicio.TabIndex = 6
        Me.lblServicio.Text = "Servicio:"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(777, 36)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(152, 25)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar cve."
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(809, 679)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(143, 25)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'DlgFolioInforme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 713)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgFolioInforme"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Folio del informe"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.gpBoxDatosInforme.ResumeLayout(False)
        Me.gpBoxDatosInforme.PerformLayout()
        Me.gpBoxRespuesta.ResumeLayout(False)
        Me.gpBoxRespuesta.PerformLayout()
        Me.gpBoxDatos.ResumeLayout(False)
        Me.gpBoxDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panPrincipal As System.Windows.Forms.Panel
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtTrabajo As System.Windows.Forms.TextBox
    Friend WithEvents lblTrabajo As System.Windows.Forms.Label
    Friend WithEvents gpBoxDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblDivision As System.Windows.Forms.Label
    Friend WithEvents txtDivision As System.Windows.Forms.TextBox
    Friend WithEvents txtOficina As System.Windows.Forms.TextBox
    Friend WithEvents lblOficina As System.Windows.Forms.Label
    Friend WithEvents txtServicio As System.Windows.Forms.TextBox
    Friend WithEvents lblServicio As System.Windows.Forms.Label
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents btnCopiarFolio As System.Windows.Forms.Button
    Friend WithEvents gpBoxDatosInforme As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaInforme As System.Windows.Forms.Label
    Friend WithEvents lblFechaPeriodo As System.Windows.Forms.Label
    Friend WithEvents txtFechaInforme As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFechaPeriodo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblArchivo As System.Windows.Forms.Label
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents txtInformeRelativo As System.Windows.Forms.TextBox
    Friend WithEvents txtIdiomaOtro As System.Windows.Forms.TextBox
    Friend WithEvents lblOpinionDetalle As System.Windows.Forms.Label
    Friend WithEvents lblIdiomaOtro As System.Windows.Forms.Label
    Friend WithEvents txtOpinionDetalle As System.Windows.Forms.TextBox
    Friend WithEvents txtBasadoDetalle As System.Windows.Forms.TextBox
    Friend WithEvents lblInformeRelativo As System.Windows.Forms.Label
    Friend WithEvents lblBasadoDetalle As System.Windows.Forms.Label
    Friend WithEvents lblTituloIE As System.Windows.Forms.Label
    Friend WithEvents lblTituloIEs As System.Windows.Forms.Label
    Friend WithEvents cboIdioma As System.Windows.Forms.ComboBox
    Friend WithEvents cboBasadoEn As System.Windows.Forms.ComboBox
    Friend WithEvents cboOpinion As System.Windows.Forms.ComboBox
    Friend WithEvents cboInforme As System.Windows.Forms.ComboBox
    Friend WithEvents lblOpinion As System.Windows.Forms.Label
    Friend WithEvents lblIdioma As System.Windows.Forms.Label
    Friend WithEvents lblInforme As System.Windows.Forms.Label
    Friend WithEvents lblBasadoEn As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGenerarFolio As System.Windows.Forms.Button
    Friend WithEvents lblPregunta As System.Windows.Forms.Label
    Friend WithEvents rdNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents lblCteRel As System.Windows.Forms.Label
    Friend WithEvents txtCteRelacionado As System.Windows.Forms.TextBox
    Friend WithEvents gpBoxRespuesta As System.Windows.Forms.GroupBox
    Friend WithEvents lblMsgError As Label
    Friend WithEvents lblDetalle As LinkLabel
End Class
