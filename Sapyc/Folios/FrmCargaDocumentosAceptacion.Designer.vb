<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCargaDocumentosAceptacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCargaDocumentosAceptacion))
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.panSolicitud = New System.Windows.Forms.Panel()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.btnSolicitud = New System.Windows.Forms.Button()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.chkSolicitud = New System.Windows.Forms.CheckBox()
        Me.panSeparador = New System.Windows.Forms.Panel()
        Me.panDocumentos = New System.Windows.Forms.Panel()
        Me.gpBoxFechas = New System.Windows.Forms.GroupBox()
        Me.lblFechaDe = New System.Windows.Forms.Label()
        Me.dpServicios = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dpRiesgos = New System.Windows.Forms.DateTimePicker()
        Me.lblDocumentoUno = New System.Windows.Forms.Label()
        Me.txtDocumentoDos = New System.Windows.Forms.TextBox()
        Me.btnRegistrarDocumentos = New System.Windows.Forms.Button()
        Me.lblDocumentoDos = New System.Windows.Forms.Label()
        Me.txtDocumentoUno = New System.Windows.Forms.TextBox()
        Me.btnDocumentoUno = New System.Windows.Forms.Button()
        Me.btnDocumentoDos = New System.Windows.Forms.Button()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.panSolicitud.SuspendLayout()
        Me.panDocumentos.SuspendLayout()
        Me.gpBoxFechas.SuspendLayout()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.lblCliente)
        Me.panPrincipal.Controls.Add(Me.panSolicitud)
        Me.panPrincipal.Controls.Add(Me.chkSolicitud)
        Me.panPrincipal.Controls.Add(Me.panSeparador)
        Me.panPrincipal.Controls.Add(Me.panDocumentos)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Controls.Add(Me.lblMensaje)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1063, 602)
        Me.panPrincipal.TabIndex = 0
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblCliente.Location = New System.Drawing.Point(2, 32)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(188, 23)
        Me.lblCliente.TabIndex = 1
        Me.lblCliente.Text = "[NOMBRE DE CLIENTE]"
        '
        'panSolicitud
        '
        Me.panSolicitud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panSolicitud.Controls.Add(Me.lblMotivo)
        Me.panSolicitud.Controls.Add(Me.btnSolicitud)
        Me.panSolicitud.Controls.Add(Me.txtMotivo)
        Me.panSolicitud.Location = New System.Drawing.Point(24, 395)
        Me.panSolicitud.Name = "panSolicitud"
        Me.panSolicitud.Size = New System.Drawing.Size(1013, 183)
        Me.panSolicitud.TabIndex = 7
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Location = New System.Drawing.Point(42, 16)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(565, 18)
        Me.lblMotivo.TabIndex = 0
        Me.lblMotivo.Text = "Por favor, describa a continuación el motivo de la solicitud de apertura de clave" &
    " de trabajo:"
        '
        'btnSolicitud
        '
        Me.btnSolicitud.Location = New System.Drawing.Point(857, 136)
        Me.btnSolicitud.Name = "btnSolicitud"
        Me.btnSolicitud.Size = New System.Drawing.Size(130, 25)
        Me.btnSolicitud.TabIndex = 2
        Me.btnSolicitud.Text = "Solicitar"
        Me.btnSolicitud.UseVisualStyleBackColor = True
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(42, 40)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(945, 90)
        Me.txtMotivo.TabIndex = 1
        '
        'chkSolicitud
        '
        Me.chkSolicitud.AutoSize = True
        Me.chkSolicitud.Location = New System.Drawing.Point(24, 360)
        Me.chkSolicitud.Name = "chkSolicitud"
        Me.chkSolicitud.Size = New System.Drawing.Size(351, 22)
        Me.chkSolicitud.TabIndex = 5
        Me.chkSolicitud.Text = "Solicitar autorización de apertura de clave de trabajo"
        Me.chkSolicitud.UseVisualStyleBackColor = True
        '
        'panSeparador
        '
        Me.panSeparador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panSeparador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panSeparador.Location = New System.Drawing.Point(24, 372)
        Me.panSeparador.Name = "panSeparador"
        Me.panSeparador.Size = New System.Drawing.Size(1013, 1)
        Me.panSeparador.TabIndex = 6
        '
        'panDocumentos
        '
        Me.panDocumentos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panDocumentos.Controls.Add(Me.gpBoxFechas)
        Me.panDocumentos.Controls.Add(Me.lblDocumentoUno)
        Me.panDocumentos.Controls.Add(Me.txtDocumentoDos)
        Me.panDocumentos.Controls.Add(Me.btnRegistrarDocumentos)
        Me.panDocumentos.Controls.Add(Me.lblDocumentoDos)
        Me.panDocumentos.Controls.Add(Me.txtDocumentoUno)
        Me.panDocumentos.Controls.Add(Me.btnDocumentoUno)
        Me.panDocumentos.Controls.Add(Me.btnDocumentoDos)
        Me.panDocumentos.Location = New System.Drawing.Point(24, 144)
        Me.panDocumentos.Name = "panDocumentos"
        Me.panDocumentos.Size = New System.Drawing.Size(1013, 188)
        Me.panDocumentos.TabIndex = 4
        '
        'gpBoxFechas
        '
        Me.gpBoxFechas.Controls.Add(Me.lblFechaDe)
        Me.gpBoxFechas.Controls.Add(Me.dpServicios)
        Me.gpBoxFechas.Controls.Add(Me.Label1)
        Me.gpBoxFechas.Controls.Add(Me.dpRiesgos)
        Me.gpBoxFechas.Location = New System.Drawing.Point(608, 18)
        Me.gpBoxFechas.Name = "gpBoxFechas"
        Me.gpBoxFechas.Size = New System.Drawing.Size(379, 110)
        Me.gpBoxFechas.TabIndex = 6
        Me.gpBoxFechas.TabStop = False
        Me.gpBoxFechas.Text = "Fechas de Aprobación"
        '
        'lblFechaDe
        '
        Me.lblFechaDe.AutoSize = True
        Me.lblFechaDe.Location = New System.Drawing.Point(35, 33)
        Me.lblFechaDe.Name = "lblFechaDe"
        Me.lblFechaDe.Size = New System.Drawing.Size(147, 18)
        Me.lblFechaDe.TabIndex = 0
        Me.lblFechaDe.Text = "Aceptación de riesgos:"
        '
        'dpServicios
        '
        Me.dpServicios.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpServicios.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpServicios.Location = New System.Drawing.Point(198, 69)
        Me.dpServicios.Name = "dpServicios"
        Me.dpServicios.Size = New System.Drawing.Size(123, 26)
        Me.dpServicios.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Convenio de servicios:"
        '
        'dpRiesgos
        '
        Me.dpRiesgos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpRiesgos.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpRiesgos.Location = New System.Drawing.Point(198, 29)
        Me.dpRiesgos.Name = "dpRiesgos"
        Me.dpRiesgos.Size = New System.Drawing.Size(123, 26)
        Me.dpRiesgos.TabIndex = 1
        '
        'lblDocumentoUno
        '
        Me.lblDocumentoUno.AutoSize = True
        Me.lblDocumentoUno.Location = New System.Drawing.Point(24, 18)
        Me.lblDocumentoUno.Name = "lblDocumentoUno"
        Me.lblDocumentoUno.Size = New System.Drawing.Size(312, 18)
        Me.lblDocumentoUno.TabIndex = 0
        Me.lblDocumentoUno.Text = "Carta de aceptación de cliente (Documento LEAP)"
        '
        'txtDocumentoDos
        '
        Me.txtDocumentoDos.Enabled = False
        Me.txtDocumentoDos.Location = New System.Drawing.Point(27, 100)
        Me.txtDocumentoDos.Name = "txtDocumentoDos"
        Me.txtDocumentoDos.Size = New System.Drawing.Size(497, 25)
        Me.txtDocumentoDos.TabIndex = 4
        '
        'btnRegistrarDocumentos
        '
        Me.btnRegistrarDocumentos.Location = New System.Drawing.Point(818, 143)
        Me.btnRegistrarDocumentos.Name = "btnRegistrarDocumentos"
        Me.btnRegistrarDocumentos.Size = New System.Drawing.Size(169, 25)
        Me.btnRegistrarDocumentos.TabIndex = 7
        Me.btnRegistrarDocumentos.Text = "Registrar documentos"
        Me.btnRegistrarDocumentos.UseVisualStyleBackColor = True
        '
        'lblDocumentoDos
        '
        Me.lblDocumentoDos.AutoSize = True
        Me.lblDocumentoDos.Location = New System.Drawing.Point(27, 78)
        Me.lblDocumentoDos.Name = "lblDocumentoDos"
        Me.lblDocumentoDos.Size = New System.Drawing.Size(87, 18)
        Me.lblDocumentoDos.TabIndex = 3
        Me.lblDocumentoDos.Text = "Carta arreglo"
        '
        'txtDocumentoUno
        '
        Me.txtDocumentoUno.Enabled = False
        Me.txtDocumentoUno.Location = New System.Drawing.Point(27, 44)
        Me.txtDocumentoUno.Name = "txtDocumentoUno"
        Me.txtDocumentoUno.Size = New System.Drawing.Size(497, 25)
        Me.txtDocumentoUno.TabIndex = 1
        '
        'btnDocumentoUno
        '
        Me.btnDocumentoUno.Location = New System.Drawing.Point(530, 44)
        Me.btnDocumentoUno.Name = "btnDocumentoUno"
        Me.btnDocumentoUno.Size = New System.Drawing.Size(50, 25)
        Me.btnDocumentoUno.TabIndex = 2
        Me.btnDocumentoUno.Text = "..."
        Me.btnDocumentoUno.UseVisualStyleBackColor = True
        '
        'btnDocumentoDos
        '
        Me.btnDocumentoDos.Location = New System.Drawing.Point(530, 100)
        Me.btnDocumentoDos.Name = "btnDocumentoDos"
        Me.btnDocumentoDos.Size = New System.Drawing.Size(50, 25)
        Me.btnDocumentoDos.TabIndex = 5
        Me.btnDocumentoDos.Text = "..."
        Me.btnDocumentoDos.UseVisualStyleBackColor = True
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 60)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(1063, 2)
        Me.panLinea.TabIndex = 2
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(2, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(414, 28)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "CARGA DE DOCUMENTOS DE ACEPTACIÓN"
        '
        'lblMensaje
        '
        Me.lblMensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMensaje.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMensaje.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.Location = New System.Drawing.Point(-1, 71)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(1063, 50)
        Me.lblMensaje.TabIndex = 3
        Me.lblMensaje.Text = resources.GetString("lblMensaje.Text")
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(921, 610)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(130, 25)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'FrmCargaDocumentosAceptacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1063, 643)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCargaDocumentosAceptacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Carga Documentos de Aceptación"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.panSolicitud.ResumeLayout(False)
        Me.panSolicitud.PerformLayout()
        Me.panDocumentos.ResumeLayout(False)
        Me.panDocumentos.PerformLayout()
        Me.gpBoxFechas.ResumeLayout(False)
        Me.gpBoxFechas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents lblMensaje As Label
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents txtDocumentoUno As TextBox
    Friend WithEvents btnDocumentoDos As Button
    Friend WithEvents btnDocumentoUno As Button
    Friend WithEvents lblDocumentoDos As Label
    Friend WithEvents lblDocumentoUno As Label
    Friend WithEvents txtDocumentoDos As TextBox
    Friend WithEvents panDocumentos As Panel
    Friend WithEvents panSeparador As Panel
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents btnSolicitud As Button
    Friend WithEvents lblMotivo As Label
    Friend WithEvents chkSolicitud As CheckBox
    Friend WithEvents btnCerrar As Button
    Friend WithEvents panSolicitud As Panel
    Friend WithEvents lblCliente As Label
    Friend WithEvents btnRegistrarDocumentos As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblFechaDe As Label
    Friend WithEvents dpServicios As DateTimePicker
    Friend WithEvents dpRiesgos As DateTimePicker
    Friend WithEvents gpBoxFechas As GroupBox
End Class
