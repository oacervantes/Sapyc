<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MttoFuncionario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MttoFuncionario))
        Me.Cnombre = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Capaterno = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Camaterno = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Baceptar = New System.Windows.Forms.Button
        Me.Bcancelar = New System.Windows.Forms.Button
        Me.Ccargo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Cnombre
        '
        Me.Cnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cnombre.ForeColor = System.Drawing.Color.Blue
        Me.Cnombre.Location = New System.Drawing.Point(189, 31)
        Me.Cnombre.MaxLength = 120
        Me.Cnombre.Name = "Cnombre"
        Me.Cnombre.Size = New System.Drawing.Size(249, 20)
        Me.Cnombre.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(35, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 294
        Me.Label5.Text = "Nombre:"
        '
        'Capaterno
        '
        Me.Capaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Capaterno.ForeColor = System.Drawing.Color.Blue
        Me.Capaterno.Location = New System.Drawing.Point(189, 57)
        Me.Capaterno.MaxLength = 120
        Me.Capaterno.Name = "Capaterno"
        Me.Capaterno.Size = New System.Drawing.Size(249, 20)
        Me.Capaterno.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 296
        Me.Label1.Text = "Apellido Paterno:"
        '
        'Camaterno
        '
        Me.Camaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Camaterno.ForeColor = System.Drawing.Color.Blue
        Me.Camaterno.Location = New System.Drawing.Point(189, 83)
        Me.Camaterno.MaxLength = 120
        Me.Camaterno.Name = "Camaterno"
        Me.Camaterno.Size = New System.Drawing.Size(249, 20)
        Me.Camaterno.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 298
        Me.Label2.Text = "Apellido Materno:"
        '
        'Baceptar
        '
        Me.Baceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Baceptar.Location = New System.Drawing.Point(38, 221)
        Me.Baceptar.Name = "Baceptar"
        Me.Baceptar.Size = New System.Drawing.Size(93, 28)
        Me.Baceptar.TabIndex = 4
        Me.Baceptar.Text = "&Aceptar"
        Me.Baceptar.UseVisualStyleBackColor = True
        '
        'Bcancelar
        '
        Me.Bcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bcancelar.Location = New System.Drawing.Point(420, 221)
        Me.Bcancelar.Name = "Bcancelar"
        Me.Bcancelar.Size = New System.Drawing.Size(93, 28)
        Me.Bcancelar.TabIndex = 5
        Me.Bcancelar.Text = "&Cancelar"
        Me.Bcancelar.UseVisualStyleBackColor = True
        '
        'Ccargo
        '
        Me.Ccargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ccargo.ForeColor = System.Drawing.Color.Blue
        Me.Ccargo.Location = New System.Drawing.Point(189, 109)
        Me.Ccargo.MaxLength = 120
        Me.Ccargo.Name = "Ccargo"
        Me.Ccargo.Size = New System.Drawing.Size(249, 20)
        Me.Ccargo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 306
        Me.Label3.Text = "Cargo:"
        '
        'MttoFuncionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 261)
        Me.ControlBox = False
        Me.Controls.Add(Me.Ccargo)
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
        Me.Name = "MttoFuncionario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta de Funcionario"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Capaterno As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Camaterno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Baceptar As System.Windows.Forms.Button
    Friend WithEvents Bcancelar As System.Windows.Forms.Button
    Friend WithEvents Ccargo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
