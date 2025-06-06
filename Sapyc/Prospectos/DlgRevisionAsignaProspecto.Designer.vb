<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgRevisionAsignaProspecto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DlgRevisionAsignaProspecto))
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.lblMensajeError = New System.Windows.Forms.Label()
        Me.btnGenerarPropuesta = New System.Windows.Forms.Button()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.gpBoxTipoPropuesta = New System.Windows.Forms.GroupBox()
        Me.cboDivisiones = New System.Windows.Forms.ComboBox()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.cboOficinas = New System.Windows.Forms.ComboBox()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.cboSocio = New System.Windows.Forms.ComboBox()
        Me.lblSocio = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
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
        Me.panPrincipal.Controls.Add(Me.lblMensajeError)
        Me.panPrincipal.Controls.Add(Me.btnGenerarPropuesta)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.gpBoxTipoPropuesta)
        Me.panPrincipal.Controls.Add(Me.PictureBox1)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Controls.Add(Me.lblCliente)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 1)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(650, 357)
        Me.panPrincipal.TabIndex = 1
        '
        'lblMensajeError
        '
        Me.lblMensajeError.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lblMensajeError.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMensajeError.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeError.ForeColor = System.Drawing.Color.White
        Me.lblMensajeError.Location = New System.Drawing.Point(0, 330)
        Me.lblMensajeError.Name = "lblMensajeError"
        Me.lblMensajeError.Size = New System.Drawing.Size(648, 25)
        Me.lblMensajeError.TabIndex = 22
        Me.lblMensajeError.Text = "Mensaje de error"
        Me.lblMensajeError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeError.Visible = False
        '
        'btnGenerarPropuesta
        '
        Me.btnGenerarPropuesta.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerarPropuesta.Location = New System.Drawing.Point(106, 278)
        Me.btnGenerarPropuesta.Name = "btnGenerarPropuesta"
        Me.btnGenerarPropuesta.Size = New System.Drawing.Size(176, 25)
        Me.btnGenerarPropuesta.TabIndex = 4
        Me.btnGenerarPropuesta.Text = "Enviar cliente prospecto"
        Me.btnGenerarPropuesta.UseVisualStyleBackColor = True
        '
        'panLinea
        '
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(106, 45)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(470, 3)
        Me.panLinea.TabIndex = 1
        '
        'gpBoxTipoPropuesta
        '
        Me.gpBoxTipoPropuesta.Controls.Add(Me.cboDivisiones)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.lblDivision)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.cboOficinas)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.lblOficina)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.cboSocio)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.lblSocio)
        Me.gpBoxTipoPropuesta.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpBoxTipoPropuesta.Location = New System.Drawing.Point(106, 96)
        Me.gpBoxTipoPropuesta.Name = "gpBoxTipoPropuesta"
        Me.gpBoxTipoPropuesta.Size = New System.Drawing.Size(529, 165)
        Me.gpBoxTipoPropuesta.TabIndex = 3
        Me.gpBoxTipoPropuesta.TabStop = False
        Me.gpBoxTipoPropuesta.Text = "Oficina y socio"
        '
        'cboDivisiones
        '
        Me.cboDivisiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDivisiones.FormattingEnabled = True
        Me.cboDivisiones.Location = New System.Drawing.Point(142, 72)
        Me.cboDivisiones.Name = "cboDivisiones"
        Me.cboDivisiones.Size = New System.Drawing.Size(369, 26)
        Me.cboDivisiones.TabIndex = 3
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivision.Location = New System.Drawing.Point(72, 76)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(62, 18)
        Me.lblDivision.TabIndex = 2
        Me.lblDivision.Text = "División:"
        '
        'cboOficinas
        '
        Me.cboOficinas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOficinas.FormattingEnabled = True
        Me.cboOficinas.Location = New System.Drawing.Point(142, 32)
        Me.cboOficinas.Name = "cboOficinas"
        Me.cboOficinas.Size = New System.Drawing.Size(369, 26)
        Me.cboOficinas.TabIndex = 1
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOficina.Location = New System.Drawing.Point(79, 36)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(55, 18)
        Me.lblOficina.TabIndex = 0
        Me.lblOficina.Text = "Oficina:"
        '
        'cboSocio
        '
        Me.cboSocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSocio.FormattingEnabled = True
        Me.cboSocio.Location = New System.Drawing.Point(142, 112)
        Me.cboSocio.Name = "cboSocio"
        Me.cboSocio.Size = New System.Drawing.Size(369, 26)
        Me.cboSocio.TabIndex = 5
        '
        'lblSocio
        '
        Me.lblSocio.AutoSize = True
        Me.lblSocio.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSocio.Location = New System.Drawing.Point(22, 116)
        Me.lblSocio.Name = "lblSocio"
        Me.lblSocio.Size = New System.Drawing.Size(112, 18)
        Me.lblSocio.TabIndex = 4
        Me.lblSocio.Text = "Socio encargado:"
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = CType(resources.GetObject("PictureBox1.ErrorImage"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
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
        Me.lblTitulo.Size = New System.Drawing.Size(438, 29)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Enviar cliente prospecto a socio encargado"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Calibri", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(106, 61)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(0, 22)
        Me.lblCliente.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(488, 364)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(130, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'DlgRevisionAsignaProspecto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 398)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.panPrincipal)
        Me.Name = "DlgRevisionAsignaProspecto"
        Me.Text = "DlgRevisionAsignaProspecto"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.gpBoxTipoPropuesta.ResumeLayout(False)
        Me.gpBoxTipoPropuesta.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents lblMensajeError As Label
    Friend WithEvents btnGenerarPropuesta As Button
    Friend WithEvents panLinea As Panel
    Friend WithEvents gpBoxTipoPropuesta As GroupBox
    Friend WithEvents cboDivisiones As ComboBox
    Friend WithEvents lblDivision As Label
    Friend WithEvents cboOficinas As ComboBox
    Friend WithEvents lblOficina As Label
    Friend WithEvents cboSocio As ComboBox
    Friend WithEvents lblSocio As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents btnCancelar As Button
End Class
