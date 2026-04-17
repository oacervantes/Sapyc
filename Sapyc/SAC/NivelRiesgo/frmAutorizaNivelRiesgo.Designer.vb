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
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSac = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDivision = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOficina = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.rbBajo = New System.Windows.Forms.RadioButton()
        Me.rbMedio = New System.Windows.Forms.RadioButton()
        Me.rbAlto = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAutoriza = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.GroupBox1)
        Me.panPrincipal.Controls.Add(Me.Label4)
        Me.panPrincipal.Controls.Add(Me.lblSac)
        Me.panPrincipal.Controls.Add(Me.Label3)
        Me.panPrincipal.Controls.Add(Me.txtDivision)
        Me.panPrincipal.Controls.Add(Me.Label2)
        Me.panPrincipal.Controls.Add(Me.txtOficina)
        Me.panPrincipal.Controls.Add(Me.Label1)
        Me.panPrincipal.Controls.Add(Me.txtCliente)
        Me.panPrincipal.Controls.Add(Me.lblServicio)
        Me.panPrincipal.Controls.Add(Me.txtServicio)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(1, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(842, 449)
        Me.panPrincipal.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(438, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 18)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "División:"
        '
        'lblSac
        '
        Me.lblSac.AutoSize = True
        Me.lblSac.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSac.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblSac.Location = New System.Drawing.Point(419, 51)
        Me.lblSac.Name = "lblSac"
        Me.lblSac.Size = New System.Drawing.Size(21, 32)
        Me.lblSac.TabIndex = 26
        Me.lblSac.Text = "."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(320, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 18)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Número SAC: "
        '
        'txtDivision
        '
        Me.txtDivision.Enabled = False
        Me.txtDivision.Location = New System.Drawing.Point(505, 120)
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.Size = New System.Drawing.Size(324, 25)
        Me.txtDivision.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 18)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Oficina:"
        '
        'txtOficina
        '
        Me.txtOficina.Enabled = False
        Me.txtOficina.Location = New System.Drawing.Point(104, 119)
        Me.txtOficina.Name = "txtOficina"
        Me.txtOficina.Size = New System.Drawing.Size(318, 25)
        Me.txtOficina.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 18)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(104, 150)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(725, 25)
        Me.txtCliente.TabIndex = 20
        '
        'lblServicio
        '
        Me.lblServicio.AutoSize = True
        Me.lblServicio.Location = New System.Drawing.Point(38, 184)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(61, 18)
        Me.lblServicio.TabIndex = 15
        Me.lblServicio.Text = "Servicio:"
        '
        'txtServicio
        '
        Me.txtServicio.Enabled = False
        Me.txtServicio.Location = New System.Drawing.Point(104, 181)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(725, 25)
        Me.txtServicio.TabIndex = 16
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 36)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(842, 2)
        Me.panLinea.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(2, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(200, 32)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "NIVEL DE RIESGO"
        '
        'rbBajo
        '
        Me.rbBajo.AutoSize = True
        Me.rbBajo.Location = New System.Drawing.Point(28, 46)
        Me.rbBajo.Name = "rbBajo"
        Me.rbBajo.Size = New System.Drawing.Size(89, 22)
        Me.rbBajo.TabIndex = 28
        Me.rbBajo.TabStop = True
        Me.rbBajo.Text = "Nivel Bajo"
        Me.rbBajo.UseVisualStyleBackColor = True
        '
        'rbMedio
        '
        Me.rbMedio.AutoSize = True
        Me.rbMedio.Location = New System.Drawing.Point(219, 46)
        Me.rbMedio.Name = "rbMedio"
        Me.rbMedio.Size = New System.Drawing.Size(103, 22)
        Me.rbMedio.TabIndex = 29
        Me.rbMedio.TabStop = True
        Me.rbMedio.Text = "Nivel Medio"
        Me.rbMedio.UseVisualStyleBackColor = True
        '
        'rbAlto
        '
        Me.rbAlto.AutoSize = True
        Me.rbAlto.Location = New System.Drawing.Point(440, 46)
        Me.rbAlto.Name = "rbAlto"
        Me.rbAlto.Size = New System.Drawing.Size(88, 22)
        Me.rbAlto.TabIndex = 30
        Me.rbAlto.TabStop = True
        Me.rbAlto.Text = "Nivel Alto"
        Me.rbAlto.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbBajo)
        Me.GroupBox1.Controls.Add(Me.rbAlto)
        Me.GroupBox1.Controls.Add(Me.rbMedio)
        Me.GroupBox1.Location = New System.Drawing.Point(104, 261)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(596, 100)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione una calificación"
        '
        'btnAutoriza
        '
        Me.btnAutoriza.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAutoriza.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoriza.Location = New System.Drawing.Point(12, 455)
        Me.btnAutoriza.Name = "btnAutoriza"
        Me.btnAutoriza.Size = New System.Drawing.Size(130, 25)
        Me.btnAutoriza.TabIndex = 33
        Me.btnAutoriza.Text = "Guardar"
        Me.btnAutoriza.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(693, 455)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(130, 25)
        Me.btnSalir.TabIndex = 32
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmAutorizaNivelRiesgo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 491)
        Me.Controls.Add(Me.btnAutoriza)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.panPrincipal)
        Me.Name = "frmAutorizaNivelRiesgo"
        Me.Text = "AUTORIZA NIVEL RIESGO"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents rbAlto As RadioButton
    Friend WithEvents rbMedio As RadioButton
    Friend WithEvents rbBajo As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents lblSac As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDivision As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOficina As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents lblServicio As Label
    Friend WithEvents txtServicio As TextBox
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAutoriza As Button
    Friend WithEvents btnSalir As Button
End Class
