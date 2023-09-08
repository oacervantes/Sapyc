<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MttoAccionistaPM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MttoAccionistaPM))
        Me.Cporcentaje = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Bcancelar = New System.Windows.Forms.Button
        Me.Baceptar = New System.Windows.Forms.Button
        Me.Cnombre = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Cporcentaje
        '
        Me.Cporcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cporcentaje.ForeColor = System.Drawing.Color.Blue
        Me.Cporcentaje.Location = New System.Drawing.Point(191, 79)
        Me.Cporcentaje.MaxLength = 120
        Me.Cporcentaje.Name = "Cporcentaje"
        Me.Cporcentaje.Size = New System.Drawing.Size(80, 20)
        Me.Cporcentaje.TabIndex = 318
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 322
        Me.Label3.Text = "Porcentaje:"
        '
        'Bcancelar
        '
        Me.Bcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bcancelar.Location = New System.Drawing.Point(422, 201)
        Me.Bcancelar.Name = "Bcancelar"
        Me.Bcancelar.Size = New System.Drawing.Size(93, 28)
        Me.Bcancelar.TabIndex = 320
        Me.Bcancelar.Text = "&Cancelar"
        Me.Bcancelar.UseVisualStyleBackColor = True
        '
        'Baceptar
        '
        Me.Baceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Baceptar.Location = New System.Drawing.Point(40, 201)
        Me.Baceptar.Name = "Baceptar"
        Me.Baceptar.Size = New System.Drawing.Size(93, 28)
        Me.Baceptar.TabIndex = 319
        Me.Baceptar.Text = "&Aceptar"
        Me.Baceptar.UseVisualStyleBackColor = True
        '
        'Cnombre
        '
        Me.Cnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cnombre.ForeColor = System.Drawing.Color.Blue
        Me.Cnombre.Location = New System.Drawing.Point(191, 52)
        Me.Cnombre.MaxLength = 120
        Me.Cnombre.Name = "Cnombre"
        Me.Cnombre.Size = New System.Drawing.Size(324, 20)
        Me.Cnombre.TabIndex = 317
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 321
        Me.Label5.Text = "Nombre:"
        '
        'MttoAccionistaPM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 261)
        Me.ControlBox = False
        Me.Controls.Add(Me.Cporcentaje)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Bcancelar)
        Me.Controls.Add(Me.Baceptar)
        Me.Controls.Add(Me.Cnombre)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MttoAccionistaPM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta Accionista Persona Moral"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cporcentaje As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Bcancelar As System.Windows.Forms.Button
    Friend WithEvents Baceptar As System.Windows.Forms.Button
    Friend WithEvents Cnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
