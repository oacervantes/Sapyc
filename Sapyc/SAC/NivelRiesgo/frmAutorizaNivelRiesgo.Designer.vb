<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutorizaNivelRiesgo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutorizaNivelRiesgo))
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.gpBoxNivel = New System.Windows.Forms.GroupBox()
        Me.rbBajo = New System.Windows.Forms.RadioButton()
        Me.rbAlto = New System.Windows.Forms.RadioButton()
        Me.rbMedio = New System.Windows.Forms.RadioButton()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.txtDivision = New System.Windows.Forms.TextBox()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.txtOficina = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnAutoriza = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblIdSac = New System.Windows.Forms.Label()
        Me.txtIdSac = New System.Windows.Forms.Label()
        Me.txtComentarios = New System.Windows.Forms.TextBox()
        Me.lblComentarios = New System.Windows.Forms.Label()
        Me.panPrincipal.SuspendLayout()
        Me.gpBoxNivel.SuspendLayout()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.lblComentarios)
        Me.panPrincipal.Controls.Add(Me.txtComentarios)
        Me.panPrincipal.Controls.Add(Me.lblIdSac)
        Me.panPrincipal.Controls.Add(Me.txtIdSac)
        Me.panPrincipal.Controls.Add(Me.gpBoxNivel)
        Me.panPrincipal.Controls.Add(Me.lblDivision)
        Me.panPrincipal.Controls.Add(Me.txtDivision)
        Me.panPrincipal.Controls.Add(Me.lblOficina)
        Me.panPrincipal.Controls.Add(Me.txtOficina)
        Me.panPrincipal.Controls.Add(Me.lblCliente)
        Me.panPrincipal.Controls.Add(Me.txtCliente)
        Me.panPrincipal.Controls.Add(Me.lblServicio)
        Me.panPrincipal.Controls.Add(Me.txtServicio)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(845, 418)
        Me.panPrincipal.TabIndex = 0
        '
        'gpBoxNivel
        '
        Me.gpBoxNivel.Controls.Add(Me.rbBajo)
        Me.gpBoxNivel.Controls.Add(Me.rbAlto)
        Me.gpBoxNivel.Controls.Add(Me.rbMedio)
        Me.gpBoxNivel.Location = New System.Drawing.Point(111, 209)
        Me.gpBoxNivel.Name = "gpBoxNivel"
        Me.gpBoxNivel.Size = New System.Drawing.Size(689, 70)
        Me.gpBoxNivel.TabIndex = 12
        Me.gpBoxNivel.TabStop = False
        Me.gpBoxNivel.Text = "Calificación de Nivel de Riesgo"
        '
        'rbBajo
        '
        Me.rbBajo.AutoSize = True
        Me.rbBajo.Location = New System.Drawing.Point(139, 30)
        Me.rbBajo.Name = "rbBajo"
        Me.rbBajo.Size = New System.Drawing.Size(89, 22)
        Me.rbBajo.TabIndex = 0
        Me.rbBajo.TabStop = True
        Me.rbBajo.Text = "Nivel Bajo"
        Me.rbBajo.UseVisualStyleBackColor = True
        '
        'rbAlto
        '
        Me.rbAlto.AutoSize = True
        Me.rbAlto.Location = New System.Drawing.Point(461, 30)
        Me.rbAlto.Name = "rbAlto"
        Me.rbAlto.Size = New System.Drawing.Size(88, 22)
        Me.rbAlto.TabIndex = 2
        Me.rbAlto.TabStop = True
        Me.rbAlto.Text = "Nivel Alto"
        Me.rbAlto.UseVisualStyleBackColor = True
        '
        'rbMedio
        '
        Me.rbMedio.AutoSize = True
        Me.rbMedio.Location = New System.Drawing.Point(293, 30)
        Me.rbMedio.Name = "rbMedio"
        Me.rbMedio.Size = New System.Drawing.Size(103, 22)
        Me.rbMedio.TabIndex = 1
        Me.rbMedio.TabStop = True
        Me.rbMedio.Text = "Nivel Medio"
        Me.rbMedio.UseVisualStyleBackColor = True
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(432, 133)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(62, 18)
        Me.lblDivision.TabIndex = 8
        Me.lblDivision.Text = "División:"
        '
        'txtDivision
        '
        Me.txtDivision.Location = New System.Drawing.Point(503, 130)
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.ReadOnly = True
        Me.txtDivision.Size = New System.Drawing.Size(297, 25)
        Me.txtDivision.TabIndex = 9
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Location = New System.Drawing.Point(39, 133)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(55, 18)
        Me.lblOficina.TabIndex = 6
        Me.lblOficina.Text = "Oficina:"
        '
        'txtOficina
        '
        Me.txtOficina.Location = New System.Drawing.Point(111, 130)
        Me.txtOficina.Name = "txtOficina"
        Me.txtOficina.ReadOnly = True
        Me.txtOficina.Size = New System.Drawing.Size(297, 25)
        Me.txtOficina.TabIndex = 7
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(39, 97)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(57, 18)
        Me.lblCliente.TabIndex = 4
        Me.lblCliente.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(111, 94)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(689, 25)
        Me.txtCliente.TabIndex = 5
        '
        'lblServicio
        '
        Me.lblServicio.AutoSize = True
        Me.lblServicio.Location = New System.Drawing.Point(39, 171)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(61, 18)
        Me.lblServicio.TabIndex = 10
        Me.lblServicio.Text = "Servicio:"
        '
        'txtServicio
        '
        Me.txtServicio.Location = New System.Drawing.Point(111, 168)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.ReadOnly = True
        Me.txtServicio.Size = New System.Drawing.Size(689, 25)
        Me.txtServicio.TabIndex = 11
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 36)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(845, 2)
        Me.panLinea.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(2, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(371, 32)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "NIVEL DE RIESGO DE PROSPECTO"
        '
        'btnAutoriza
        '
        Me.btnAutoriza.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAutoriza.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoriza.Location = New System.Drawing.Point(12, 426)
        Me.btnAutoriza.Name = "btnAutoriza"
        Me.btnAutoriza.Size = New System.Drawing.Size(130, 25)
        Me.btnAutoriza.TabIndex = 1
        Me.btnAutoriza.Text = "Guardar"
        Me.btnAutoriza.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(703, 426)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(130, 25)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblIdSac
        '
        Me.lblIdSac.AutoSize = True
        Me.lblIdSac.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSac.Location = New System.Drawing.Point(39, 55)
        Me.lblIdSac.Name = "lblIdSac"
        Me.lblIdSac.Size = New System.Drawing.Size(56, 18)
        Me.lblIdSac.TabIndex = 2
        Me.lblIdSac.Text = "ID. SAC:"
        '
        'txtIdSac
        '
        Me.txtIdSac.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtIdSac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdSac.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSac.ForeColor = System.Drawing.Color.SlateGray
        Me.txtIdSac.Location = New System.Drawing.Point(111, 53)
        Me.txtIdSac.Name = "txtIdSac"
        Me.txtIdSac.Size = New System.Drawing.Size(88, 25)
        Me.txtIdSac.TabIndex = 3
        Me.txtIdSac.Text = "000000"
        Me.txtIdSac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtComentarios
        '
        Me.txtComentarios.Location = New System.Drawing.Point(111, 318)
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(689, 77)
        Me.txtComentarios.TabIndex = 14
        '
        'lblComentarios
        '
        Me.lblComentarios.AutoSize = True
        Me.lblComentarios.Location = New System.Drawing.Point(111, 292)
        Me.lblComentarios.Name = "lblComentarios"
        Me.lblComentarios.Size = New System.Drawing.Size(91, 18)
        Me.lblComentarios.TabIndex = 13
        Me.lblComentarios.Text = "Comentarios:"
        '
        'frmAutorizaNivelRiesgo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(845, 460)
        Me.Controls.Add(Me.btnAutoriza)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAutorizaNivelRiesgo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Calificar Nivel de Riesgo de Prospecto"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.gpBoxNivel.ResumeLayout(False)
        Me.gpBoxNivel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents rbAlto As RadioButton
    Friend WithEvents rbMedio As RadioButton
    Friend WithEvents rbBajo As RadioButton
    Friend WithEvents lblDivision As Label
    Friend WithEvents txtDivision As TextBox
    Friend WithEvents lblOficina As Label
    Friend WithEvents txtOficina As TextBox
    Friend WithEvents lblCliente As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents lblServicio As Label
    Friend WithEvents txtServicio As TextBox
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents gpBoxNivel As GroupBox
    Friend WithEvents btnAutoriza As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblIdSac As Label
    Friend WithEvents txtIdSac As Label
    Friend WithEvents lblComentarios As Label
    Friend WithEvents txtComentarios As TextBox
End Class
