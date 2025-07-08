<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgTipoServicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DlgTipoServicio))
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.lblMensajeError = New System.Windows.Forms.Label()
        Me.gBoxEquivalencia = New System.Windows.Forms.GroupBox()
        Me.btnServicioTres = New System.Windows.Forms.Button()
        Me.btnServicioDos = New System.Windows.Forms.Button()
        Me.btnServicioUno = New System.Windows.Forms.Button()
        Me.txtServicioTres = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtServicioDos = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtServicioUno = New System.Windows.Forms.TextBox()
        Me.lblServicioUno = New System.Windows.Forms.Label()
        Me.gBoxVisible = New System.Windows.Forms.GroupBox()
        Me.rdMostrarNo = New System.Windows.Forms.RadioButton()
        Me.rdMostrarSi = New System.Windows.Forms.RadioButton()
        Me.gpBoxObligatorio = New System.Windows.Forms.GroupBox()
        Me.rdObligatorioSi = New System.Windows.Forms.RadioButton()
        Me.rdObligatorioNo = New System.Windows.Forms.RadioButton()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.cboDivision = New System.Windows.Forms.ComboBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblTituloDatosContacto = New System.Windows.Forms.Label()
        Me.panPrincipal.SuspendLayout()
        Me.gBoxEquivalencia.SuspendLayout()
        Me.gBoxVisible.SuspendLayout()
        Me.gpBoxObligatorio.SuspendLayout()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.lblTituloDatosContacto)
        Me.panPrincipal.Controls.Add(Me.lblMensajeError)
        Me.panPrincipal.Controls.Add(Me.gBoxEquivalencia)
        Me.panPrincipal.Controls.Add(Me.gBoxVisible)
        Me.panPrincipal.Controls.Add(Me.gpBoxObligatorio)
        Me.panPrincipal.Controls.Add(Me.txtServicio)
        Me.panPrincipal.Controls.Add(Me.lblServicio)
        Me.panPrincipal.Controls.Add(Me.lblDivision)
        Me.panPrincipal.Controls.Add(Me.cboDivision)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(801, 435)
        Me.panPrincipal.TabIndex = 0
        '
        'lblMensajeError
        '
        Me.lblMensajeError.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lblMensajeError.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMensajeError.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeError.ForeColor = System.Drawing.Color.White
        Me.lblMensajeError.Location = New System.Drawing.Point(0, 408)
        Me.lblMensajeError.Name = "lblMensajeError"
        Me.lblMensajeError.Size = New System.Drawing.Size(799, 25)
        Me.lblMensajeError.TabIndex = 8
        Me.lblMensajeError.Text = "Mensaje de error"
        Me.lblMensajeError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeError.Visible = False
        '
        'gBoxEquivalencia
        '
        Me.gBoxEquivalencia.Controls.Add(Me.btnServicioTres)
        Me.gBoxEquivalencia.Controls.Add(Me.btnServicioDos)
        Me.gBoxEquivalencia.Controls.Add(Me.btnServicioUno)
        Me.gBoxEquivalencia.Controls.Add(Me.txtServicioTres)
        Me.gBoxEquivalencia.Controls.Add(Me.Label3)
        Me.gBoxEquivalencia.Controls.Add(Me.txtServicioDos)
        Me.gBoxEquivalencia.Controls.Add(Me.Label2)
        Me.gBoxEquivalencia.Controls.Add(Me.txtServicioUno)
        Me.gBoxEquivalencia.Controls.Add(Me.lblServicioUno)
        Me.gBoxEquivalencia.Location = New System.Drawing.Point(36, 196)
        Me.gBoxEquivalencia.Name = "gBoxEquivalencia"
        Me.gBoxEquivalencia.Size = New System.Drawing.Size(728, 194)
        Me.gBoxEquivalencia.TabIndex = 7
        Me.gBoxEquivalencia.TabStop = False
        Me.gBoxEquivalencia.Text = "Equivalencia Servicios GTI"
        '
        'btnServicioTres
        '
        Me.btnServicioTres.Location = New System.Drawing.Point(663, 131)
        Me.btnServicioTres.Name = "btnServicioTres"
        Me.btnServicioTres.Size = New System.Drawing.Size(50, 25)
        Me.btnServicioTres.TabIndex = 8
        Me.btnServicioTres.Text = "..."
        Me.btnServicioTres.UseVisualStyleBackColor = True
        '
        'btnServicioDos
        '
        Me.btnServicioDos.Location = New System.Drawing.Point(663, 90)
        Me.btnServicioDos.Name = "btnServicioDos"
        Me.btnServicioDos.Size = New System.Drawing.Size(50, 25)
        Me.btnServicioDos.TabIndex = 5
        Me.btnServicioDos.Text = "..."
        Me.btnServicioDos.UseVisualStyleBackColor = True
        '
        'btnServicioUno
        '
        Me.btnServicioUno.Location = New System.Drawing.Point(663, 49)
        Me.btnServicioUno.Name = "btnServicioUno"
        Me.btnServicioUno.Size = New System.Drawing.Size(50, 25)
        Me.btnServicioUno.TabIndex = 2
        Me.btnServicioUno.Text = "..."
        Me.btnServicioUno.UseVisualStyleBackColor = True
        '
        'txtServicioTres
        '
        Me.txtServicioTres.Enabled = False
        Me.txtServicioTres.Location = New System.Drawing.Point(195, 131)
        Me.txtServicioTres.Name = "txtServicioTres"
        Me.txtServicioTres.Size = New System.Drawing.Size(458, 25)
        Me.txtServicioTres.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Línea de Servicio - Nivel 3:"
        '
        'txtServicioDos
        '
        Me.txtServicioDos.Enabled = False
        Me.txtServicioDos.Location = New System.Drawing.Point(195, 90)
        Me.txtServicioDos.Name = "txtServicioDos"
        Me.txtServicioDos.Size = New System.Drawing.Size(458, 25)
        Me.txtServicioDos.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Línea de Servicio - Nivel 2:"
        '
        'txtServicioUno
        '
        Me.txtServicioUno.Enabled = False
        Me.txtServicioUno.Location = New System.Drawing.Point(195, 49)
        Me.txtServicioUno.Name = "txtServicioUno"
        Me.txtServicioUno.Size = New System.Drawing.Size(458, 25)
        Me.txtServicioUno.TabIndex = 1
        '
        'lblServicioUno
        '
        Me.lblServicioUno.AutoSize = True
        Me.lblServicioUno.Location = New System.Drawing.Point(15, 52)
        Me.lblServicioUno.Name = "lblServicioUno"
        Me.lblServicioUno.Size = New System.Drawing.Size(170, 18)
        Me.lblServicioUno.TabIndex = 0
        Me.lblServicioUno.Text = "Línea de Servicio - Nivel 1:"
        '
        'gBoxVisible
        '
        Me.gBoxVisible.Controls.Add(Me.rdMostrarNo)
        Me.gBoxVisible.Controls.Add(Me.rdMostrarSi)
        Me.gBoxVisible.Location = New System.Drawing.Point(454, 102)
        Me.gBoxVisible.Name = "gBoxVisible"
        Me.gBoxVisible.Size = New System.Drawing.Size(311, 68)
        Me.gBoxVisible.TabIndex = 5
        Me.gBoxVisible.TabStop = False
        Me.gBoxVisible.Text = "¿Se mostrará este servicio al usuario?"
        '
        'rdMostrarNo
        '
        Me.rdMostrarNo.AutoSize = True
        Me.rdMostrarNo.Location = New System.Drawing.Point(158, 33)
        Me.rdMostrarNo.Name = "rdMostrarNo"
        Me.rdMostrarNo.Size = New System.Drawing.Size(44, 22)
        Me.rdMostrarNo.TabIndex = 1
        Me.rdMostrarNo.TabStop = True
        Me.rdMostrarNo.Text = "No"
        Me.rdMostrarNo.UseVisualStyleBackColor = True
        '
        'rdMostrarSi
        '
        Me.rdMostrarSi.AutoSize = True
        Me.rdMostrarSi.Location = New System.Drawing.Point(86, 33)
        Me.rdMostrarSi.Name = "rdMostrarSi"
        Me.rdMostrarSi.Size = New System.Drawing.Size(37, 22)
        Me.rdMostrarSi.TabIndex = 0
        Me.rdMostrarSi.TabStop = True
        Me.rdMostrarSi.Text = "Sí"
        Me.rdMostrarSi.UseVisualStyleBackColor = True
        '
        'gpBoxObligatorio
        '
        Me.gpBoxObligatorio.Controls.Add(Me.rdObligatorioSi)
        Me.gpBoxObligatorio.Controls.Add(Me.rdObligatorioNo)
        Me.gpBoxObligatorio.Location = New System.Drawing.Point(101, 102)
        Me.gpBoxObligatorio.Name = "gpBoxObligatorio"
        Me.gpBoxObligatorio.Size = New System.Drawing.Size(311, 68)
        Me.gpBoxObligatorio.TabIndex = 4
        Me.gpBoxObligatorio.TabStop = False
        Me.gpBoxObligatorio.Text = "¿Se requiere información a detalle?"
        '
        'rdObligatorioSi
        '
        Me.rdObligatorioSi.AutoSize = True
        Me.rdObligatorioSi.Location = New System.Drawing.Point(86, 33)
        Me.rdObligatorioSi.Name = "rdObligatorioSi"
        Me.rdObligatorioSi.Size = New System.Drawing.Size(37, 22)
        Me.rdObligatorioSi.TabIndex = 0
        Me.rdObligatorioSi.TabStop = True
        Me.rdObligatorioSi.Text = "Sí"
        Me.rdObligatorioSi.UseVisualStyleBackColor = True
        '
        'rdObligatorioNo
        '
        Me.rdObligatorioNo.AutoSize = True
        Me.rdObligatorioNo.Location = New System.Drawing.Point(158, 33)
        Me.rdObligatorioNo.Name = "rdObligatorioNo"
        Me.rdObligatorioNo.Size = New System.Drawing.Size(44, 22)
        Me.rdObligatorioNo.TabIndex = 1
        Me.rdObligatorioNo.TabStop = True
        Me.rdObligatorioNo.Text = "No"
        Me.rdObligatorioNo.UseVisualStyleBackColor = True
        '
        'txtServicio
        '
        Me.txtServicio.Location = New System.Drawing.Point(101, 58)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(664, 25)
        Me.txtServicio.TabIndex = 3
        '
        'lblServicio
        '
        Me.lblServicio.AutoSize = True
        Me.lblServicio.Location = New System.Drawing.Point(34, 61)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(61, 18)
        Me.lblServicio.TabIndex = 2
        Me.lblServicio.Text = "Servicio:"
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(33, 20)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(62, 18)
        Me.lblDivision.TabIndex = 0
        Me.lblDivision.Text = "División:"
        '
        'cboDivision
        '
        Me.cboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDivision.FormattingEnabled = True
        Me.cboDivision.Location = New System.Drawing.Point(101, 16)
        Me.cboDivision.Name = "cboDivision"
        Me.cboDivision.Size = New System.Drawing.Size(345, 26)
        Me.cboDivision.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(659, 442)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(130, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(523, 442)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(130, 25)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblTituloDatosContacto
        '
        Me.lblTituloDatosContacto.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.lblTituloDatosContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTituloDatosContacto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloDatosContacto.ForeColor = System.Drawing.Color.White
        Me.lblTituloDatosContacto.Location = New System.Drawing.Point(36, 196)
        Me.lblTituloDatosContacto.Name = "lblTituloDatosContacto"
        Me.lblTituloDatosContacto.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.lblTituloDatosContacto.Size = New System.Drawing.Size(728, 23)
        Me.lblTituloDatosContacto.TabIndex = 6
        Me.lblTituloDatosContacto.Text = "Equivalencia Servicios GTI"
        Me.lblTituloDatosContacto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DlgTipoServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(801, 476)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgTipoServicio"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registrar servicio..."
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.gBoxEquivalencia.ResumeLayout(False)
        Me.gBoxEquivalencia.PerformLayout()
        Me.gBoxVisible.ResumeLayout(False)
        Me.gBoxVisible.PerformLayout()
        Me.gpBoxObligatorio.ResumeLayout(False)
        Me.gpBoxObligatorio.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents gBoxVisible As GroupBox
    Friend WithEvents rdMostrarNo As RadioButton
    Friend WithEvents rdMostrarSi As RadioButton
    Friend WithEvents gpBoxObligatorio As GroupBox
    Friend WithEvents rdObligatorioSi As RadioButton
    Friend WithEvents rdObligatorioNo As RadioButton
    Friend WithEvents txtServicio As TextBox
    Friend WithEvents lblServicio As Label
    Friend WithEvents lblDivision As Label
    Friend WithEvents cboDivision As ComboBox
    Friend WithEvents gBoxEquivalencia As GroupBox
    Friend WithEvents btnServicioTres As Button
    Friend WithEvents btnServicioDos As Button
    Friend WithEvents btnServicioUno As Button
    Friend WithEvents txtServicioTres As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtServicioDos As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtServicioUno As TextBox
    Friend WithEvents lblServicioUno As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblMensajeError As Label
    Friend WithEvents lblTituloDatosContacto As Label
End Class
