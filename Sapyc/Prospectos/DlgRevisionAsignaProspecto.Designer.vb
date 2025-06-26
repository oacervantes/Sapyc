<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgRevisionAsignaProspecto
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.lblMensajeError = New System.Windows.Forms.Label()
        Me.btnGenerarPropuesta = New System.Windows.Forms.Button()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.gpBoxTipoPropuesta = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDivisiones = New System.Windows.Forms.ComboBox()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.cboOficinas = New System.Windows.Forms.ComboBox()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.cboSocio = New System.Windows.Forms.ComboBox()
        Me.lblSocio = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.panPrincipal.SuspendLayout()
        Me.gpBoxTipoPropuesta.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(508, 408)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(130, 25)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
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
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(650, 401)
        Me.panPrincipal.TabIndex = 0
        '
        'lblMensajeError
        '
        Me.lblMensajeError.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lblMensajeError.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMensajeError.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeError.ForeColor = System.Drawing.Color.White
        Me.lblMensajeError.Location = New System.Drawing.Point(0, 374)
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
        Me.btnGenerarPropuesta.Location = New System.Drawing.Point(106, 339)
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
        Me.gpBoxTipoPropuesta.Controls.Add(Me.txtServicio)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.Label1)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.cboDivisiones)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.lblDivision)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.cboOficinas)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.lblOficina)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.cboSocio)
        Me.gpBoxTipoPropuesta.Controls.Add(Me.lblSocio)
        Me.gpBoxTipoPropuesta.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpBoxTipoPropuesta.Location = New System.Drawing.Point(106, 96)
        Me.gpBoxTipoPropuesta.Name = "gpBoxTipoPropuesta"
        Me.gpBoxTipoPropuesta.Size = New System.Drawing.Size(529, 237)
        Me.gpBoxTipoPropuesta.TabIndex = 3
        Me.gpBoxTipoPropuesta.TabStop = False
        Me.gpBoxTipoPropuesta.Text = "Oficina y socio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(73, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Servicio:"
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
        Me.lblSocio.Location = New System.Drawing.Point(31, 115)
        Me.lblSocio.Name = "lblSocio"
        Me.lblSocio.Size = New System.Drawing.Size(103, 18)
        Me.lblSocio.TabIndex = 4
        Me.lblSocio.Text = "Socio asignado:"
        '

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
        'txtServicio
        '
        Me.txtServicio.Location = New System.Drawing.Point(142, 153)
        Me.txtServicio.Multiline = True
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(369, 67)
        Me.txtServicio.TabIndex = 7
        '
        'DlgRevisionAsignaProspecto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(650, 442)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgRevisionAsignaProspecto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Asignar cliente prospecto"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.gpBoxTipoPropuesta.ResumeLayout(False)
        Me.gpBoxTipoPropuesta.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents panPrincipal As Panel
    Friend WithEvents btnGenerarPropuesta As Button
    Friend WithEvents panLinea As Panel
    Friend WithEvents gpBoxTipoPropuesta As GroupBox
    Friend WithEvents cboSocio As ComboBox
    Friend WithEvents lblSocio As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents cboDivisiones As ComboBox
    Friend WithEvents lblDivision As Label
    Friend WithEvents cboOficinas As ComboBox
    Friend WithEvents lblOficina As Label
    Friend WithEvents lblMensajeError As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtServicio As TextBox
End Class
