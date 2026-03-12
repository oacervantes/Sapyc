<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgColaboradorKardex
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
        Me.lblMensajeError = New System.Windows.Forms.Label()
        Me.cboDivision = New System.Windows.Forms.ComboBox()
        Me.cboOficina = New System.Windows.Forms.ComboBox()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.gpBoxTipo = New System.Windows.Forms.GroupBox()
        Me.rdGerente = New System.Windows.Forms.RadioButton()
        Me.rdSocio = New System.Windows.Forms.RadioButton()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.gpBoxTipo.SuspendLayout()
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
        Me.panPrincipal.Controls.Add(Me.cboDivision)
        Me.panPrincipal.Controls.Add(Me.cboOficina)
        Me.panPrincipal.Controls.Add(Me.lblDivision)
        Me.panPrincipal.Controls.Add(Me.lblOficina)
        Me.panPrincipal.Controls.Add(Me.gpBoxTipo)
        Me.panPrincipal.Controls.Add(Me.btnBuscar)
        Me.panPrincipal.Controls.Add(Me.txtColaborador)
        Me.panPrincipal.Controls.Add(Me.lblColaborador)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(694, 318)
        Me.panPrincipal.TabIndex = 0
        '
        'lblMensajeError
        '
        Me.lblMensajeError.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lblMensajeError.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMensajeError.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeError.ForeColor = System.Drawing.Color.White
        Me.lblMensajeError.Location = New System.Drawing.Point(0, 291)
        Me.lblMensajeError.Name = "lblMensajeError"
        Me.lblMensajeError.Size = New System.Drawing.Size(692, 25)
        Me.lblMensajeError.TabIndex = 10
        Me.lblMensajeError.Text = "Mensaje de error"
        Me.lblMensajeError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeError.Visible = False
        '
        'cboDivision
        '
        Me.cboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDivision.FormattingEnabled = True
        Me.cboDivision.Location = New System.Drawing.Point(129, 188)
        Me.cboDivision.Name = "cboDivision"
        Me.cboDivision.Size = New System.Drawing.Size(324, 26)
        Me.cboDivision.TabIndex = 6
        '
        'cboOficina
        '
        Me.cboOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOficina.FormattingEnabled = True
        Me.cboOficina.Location = New System.Drawing.Point(129, 146)
        Me.cboOficina.Name = "cboOficina"
        Me.cboOficina.Size = New System.Drawing.Size(324, 26)
        Me.cboOficina.TabIndex = 4
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(54, 192)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(69, 18)
        Me.lblDivision.TabIndex = 5
        Me.lblDivision.Text = "División*:"
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Location = New System.Drawing.Point(61, 150)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(62, 18)
        Me.lblOficina.TabIndex = 3
        Me.lblOficina.Text = "Oficina*:"
        '
        'gpBoxTipo
        '
        Me.gpBoxTipo.Controls.Add(Me.rdGerente)
        Me.gpBoxTipo.Controls.Add(Me.rdSocio)
        Me.gpBoxTipo.Location = New System.Drawing.Point(129, 58)
        Me.gpBoxTipo.Name = "gpBoxTipo"
        Me.gpBoxTipo.Size = New System.Drawing.Size(452, 68)
        Me.gpBoxTipo.TabIndex = 2
        Me.gpBoxTipo.TabStop = False
        Me.gpBoxTipo.Text = "Tipo de Colaborador"
        '
        'rdGerente
        '
        Me.rdGerente.AutoSize = True
        Me.rdGerente.Location = New System.Drawing.Point(288, 30)
        Me.rdGerente.Name = "rdGerente"
        Me.rdGerente.Size = New System.Drawing.Size(78, 22)
        Me.rdGerente.TabIndex = 1
        Me.rdGerente.TabStop = True
        Me.rdGerente.Text = "Gerente"
        Me.rdGerente.UseVisualStyleBackColor = True
        '
        'rdSocio
        '
        Me.rdSocio.AutoSize = True
        Me.rdSocio.Location = New System.Drawing.Point(87, 30)
        Me.rdSocio.Name = "rdSocio"
        Me.rdSocio.Size = New System.Drawing.Size(168, 22)
        Me.rdSocio.TabIndex = 0
        Me.rdSocio.TabStop = True
        Me.rdSocio.Text = "Socio | Gerente Coord."
        Me.rdSocio.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(586, 230)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(53, 25)
        Me.btnBuscar.TabIndex = 9
        Me.btnBuscar.Text = "..."
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtColaborador
        '
        Me.txtColaborador.Location = New System.Drawing.Point(129, 230)
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(452, 25)
        Me.txtColaborador.TabIndex = 8
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Location = New System.Drawing.Point(60, 233)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(63, 18)
        Me.lblColaborador.TabIndex = 7
        Me.lblColaborador.Text = "Nombre:"
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 36)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(694, 2)
        Me.panLinea.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(2, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(187, 32)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "NUEVO KARDEX"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(552, 324)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(130, 25)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(9, 324)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(130, 25)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'DlgColaboradorKardex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 356)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgColaboradorKardex"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nuevo Kardex"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.gpBoxTipo.ResumeLayout(False)
        Me.gpBoxTipo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents gpBoxTipo As GroupBox
    Friend WithEvents rdGerente As RadioButton
    Friend WithEvents rdSocio As RadioButton
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtColaborador As TextBox
    Friend WithEvents lblColaborador As Label
    Friend WithEvents cboDivision As ComboBox
    Friend WithEvents cboOficina As ComboBox
    Friend WithEvents lblDivision As Label
    Friend WithEvents lblOficina As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblMensajeError As Label
End Class
