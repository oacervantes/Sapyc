<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DglRevisionDatosProspecto
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
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.btnGenerarPropuesta = New System.Windows.Forms.Button()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.gpBoxTipoPropuesta = New System.Windows.Forms.GroupBox()
        Me.cboSocio = New System.Windows.Forms.ComboBox()
        Me.lblSocio = New System.Windows.Forms.Label()
        Me.btnSi = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.lblPregunta = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.chkConfirmacion = New System.Windows.Forms.CheckBox()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.lblDatosIncompletos = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.gpBoxTipoPropuesta.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.btnGenerarPropuesta)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.gpBoxTipoPropuesta)
        Me.panPrincipal.Controls.Add(Me.btnSi)
        Me.panPrincipal.Controls.Add(Me.btnNo)
        Me.panPrincipal.Controls.Add(Me.lblPregunta)
        Me.panPrincipal.Controls.Add(Me.PictureBox1)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Controls.Add(Me.chkConfirmacion)
        Me.panPrincipal.Controls.Add(Me.lblMensaje)
        Me.panPrincipal.Controls.Add(Me.lblDatosIncompletos)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(704, 370)
        Me.panPrincipal.TabIndex = 0
        '
        'btnGenerarPropuesta
        '
        Me.btnGenerarPropuesta.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerarPropuesta.Location = New System.Drawing.Point(108, 320)
        Me.btnGenerarPropuesta.Name = "btnGenerarPropuesta"
        Me.btnGenerarPropuesta.Size = New System.Drawing.Size(176, 25)
        Me.btnGenerarPropuesta.TabIndex = 9
        Me.btnGenerarPropuesta.Text = "Generar propuesta"
        Me.btnGenerarPropuesta.UseVisualStyleBackColor = True
        Me.btnGenerarPropuesta.Visible = False
        '
        'panLinea
        '
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(111, 45)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(260, 3)
        Me.panLinea.TabIndex = 1
        '
        'gpBoxTipoPropuesta
        '
        Me.gpBoxTipoPropuesta.Controls.Add(Me.cboSocio)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.lblSocio)
        Me.gpBoxTipoPropuesta.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpBoxTipoPropuesta.Location = New System.Drawing.Point(108, 242)
        Me.gpBoxTipoPropuesta.Name = "gpBoxTipoPropuesta"
        Me.gpBoxTipoPropuesta.Size = New System.Drawing.Size(529, 69)
        Me.gpBoxTipoPropuesta.TabIndex = 8
        Me.gpBoxTipoPropuesta.TabStop = False
        Me.gpBoxTipoPropuesta.Text = "Asignar propuesta por generar"
        Me.gpBoxTipoPropuesta.Visible = False
        '
        'cboSocio
        '
        Me.cboSocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSocio.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSocio.FormattingEnabled = True
        Me.cboSocio.Location = New System.Drawing.Point(140, 30)
        Me.cboSocio.Name = "cboSocio"
        Me.cboSocio.Size = New System.Drawing.Size(369, 26)
        Me.cboSocio.TabIndex = 3
        '
        'lblSocio
        '
        Me.lblSocio.AutoSize = True
        Me.lblSocio.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSocio.Location = New System.Drawing.Point(20, 34)
        Me.lblSocio.Name = "lblSocio"
        Me.lblSocio.Size = New System.Drawing.Size(112, 18)
        Me.lblSocio.TabIndex = 2
        Me.lblSocio.Text = "Socio encargado:"
        '
        'btnSi
        '
        Me.btnSi.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSi.Location = New System.Drawing.Point(109, 197)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(100, 25)
        Me.btnSi.TabIndex = 6
        Me.btnSi.Text = "Sí"
        Me.btnSi.UseVisualStyleBackColor = True
        Me.btnSi.Visible = False
        '
        'btnNo
        '
        Me.btnNo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.Location = New System.Drawing.Point(215, 197)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(100, 25)
        Me.btnNo.TabIndex = 7
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        Me.btnNo.Visible = False
        '
        'lblPregunta
        '
        Me.lblPregunta.Location = New System.Drawing.Point(108, 147)
        Me.lblPregunta.Name = "lblPregunta"
        Me.lblPregunta.Size = New System.Drawing.Size(531, 44)
        Me.lblPregunta.TabIndex = 5
        Me.lblPregunta.Text = "Iniciar la generación de propuesta para el prospecto:"
        Me.lblPregunta.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Sapyc.My.Resources.Resources.ingenieria
        Me.PictureBox1.Location = New System.Drawing.Point(19, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(106, 13)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(202, 29)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Generar Propuesta"
        '
        'chkConfirmacion
        '
        Me.chkConfirmacion.AutoSize = True
        Me.chkConfirmacion.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConfirmacion.Location = New System.Drawing.Point(108, 110)
        Me.chkConfirmacion.Name = "chkConfirmacion"
        Me.chkConfirmacion.Size = New System.Drawing.Size(457, 22)
        Me.chkConfirmacion.TabIndex = 4
        Me.chkConfirmacion.Text = "Confirmo que se ha capturado la información solicitada del prospecto."
        Me.chkConfirmacion.UseVisualStyleBackColor = True
        Me.chkConfirmacion.Visible = False
        '
        'lblMensaje
        '
        Me.lblMensaje.Location = New System.Drawing.Point(108, 60)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(531, 42)
        Me.lblMensaje.TabIndex = 2
        Me.lblMensaje.Text = "Antes de generar una nueva propuesta, por favor verifique que se han capturado lo" &
    "s datos solicitados; también que los datos capturados sean correctos."
        Me.lblMensaje.Visible = False
        '
        'lblDatosIncompletos
        '
        Me.lblDatosIncompletos.Location = New System.Drawing.Point(106, 91)
        Me.lblDatosIncompletos.Name = "lblDatosIncompletos"
        Me.lblDatosIncompletos.Size = New System.Drawing.Size(531, 136)
        Me.lblDatosIncompletos.TabIndex = 3
        Me.lblDatosIncompletos.Text = "No se puede generar la propuesta, hasta que termine de capturar la información ne" &
    "cesaria para este prospecto." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Datos Generales." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Contacto Inicial." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Acerc" &
    "amiento." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Domicilio."
        Me.lblDatosIncompletos.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(562, 377)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(130, 25)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'DglRevisionDatosProspecto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 411)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DglRevisionDatosProspecto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generar propuesta"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.gpBoxTipoPropuesta.ResumeLayout(False)
        Me.gpBoxTipoPropuesta.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents lblMensaje As Label
    Friend WithEvents chkConfirmacion As CheckBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblPregunta As Label
    Friend WithEvents btnSi As Button
    Friend WithEvents btnNo As Button
    Friend WithEvents lblDatosIncompletos As Label
    Friend WithEvents gpBoxTipoPropuesta As GroupBox
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblSocio As Label
    Friend WithEvents cboSocio As ComboBox
    Friend WithEvents btnGenerarPropuesta As Button
End Class
