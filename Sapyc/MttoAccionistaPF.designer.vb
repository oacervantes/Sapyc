<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MttoAccionistaPF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MttoAccionistaPF))
        Me.Cporcentaje = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Bcancelar = New System.Windows.Forms.Button
        Me.Baceptar = New System.Windows.Forms.Button
        Me.Camaterno = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Capaterno = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cnombre = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Cporcentaje
        '
        Me.Cporcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cporcentaje.ForeColor = System.Drawing.Color.Blue
        Me.Cporcentaje.Location = New System.Drawing.Point(194, 119)
        Me.Cporcentaje.MaxLength = 120
        Me.Cporcentaje.Name = "Cporcentaje"
        Me.Cporcentaje.Size = New System.Drawing.Size(80, 20)
        Me.Cporcentaje.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 316
        Me.Label3.Text = "Porcentaje:"
        '
        'Bcancelar
        '
        Me.Bcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bcancelar.Location = New System.Drawing.Point(423, 211)
        Me.Bcancelar.Name = "Bcancelar"
        Me.Bcancelar.Size = New System.Drawing.Size(93, 28)
        Me.Bcancelar.TabIndex = 5
        Me.Bcancelar.Text = "&Cancelar"
        Me.Bcancelar.UseVisualStyleBackColor = True
        '
        'Baceptar
        '
        Me.Baceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Baceptar.Location = New System.Drawing.Point(41, 211)
        Me.Baceptar.Name = "Baceptar"
        Me.Baceptar.Size = New System.Drawing.Size(93, 28)
        Me.Baceptar.TabIndex = 4
        Me.Baceptar.Text = "&Aceptar"
        Me.Baceptar.UseVisualStyleBackColor = True
        '
        'Camaterno
        '
        Me.Camaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Camaterno.ForeColor = System.Drawing.Color.Blue
        Me.Camaterno.Location = New System.Drawing.Point(194, 93)
        Me.Camaterno.MaxLength = 120
        Me.Camaterno.Name = "Camaterno"
        Me.Camaterno.Size = New System.Drawing.Size(249, 20)
        Me.Camaterno.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 315
        Me.Label2.Text = "Apellido Materno:"
        '
        'Capaterno
        '
        Me.Capaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Capaterno.ForeColor = System.Drawing.Color.Blue
        Me.Capaterno.Location = New System.Drawing.Point(194, 67)
        Me.Capaterno.MaxLength = 120
        Me.Capaterno.Name = "Capaterno"
        Me.Capaterno.Size = New System.Drawing.Size(249, 20)
        Me.Capaterno.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 314
        Me.Label1.Text = "Apellido Paterno:"
        '
        'Cnombre
        '
        Me.Cnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cnombre.ForeColor = System.Drawing.Color.Blue
        Me.Cnombre.Location = New System.Drawing.Point(194, 41)
        Me.Cnombre.MaxLength = 120
        Me.Cnombre.Name = "Cnombre"
        Me.Cnombre.Size = New System.Drawing.Size(249, 20)
        Me.Cnombre.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 313
        Me.Label5.Text = "Nombre:"
        '
        'MttoAccionistaPF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 261)
        Me.ControlBox = False
        Me.Controls.Add(Me.Cporcentaje)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Bcancelar)
        Me.Controls.Add(Me.Baceptar)
        Me.Controls.Add(Me.Camaterno)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Capaterno)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cnombre)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MttoAccionistaPF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta Accionista Persona Física"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cporcentaje As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Bcancelar As System.Windows.Forms.Button
    Friend WithEvents Baceptar As System.Windows.Forms.Button
    Friend WithEvents Camaterno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Capaterno As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
