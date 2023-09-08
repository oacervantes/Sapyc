<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MttoDivisiones
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
        Me.Bcancelar = New System.Windows.Forms.Button()
        Me.Baceptar = New System.Windows.Forms.Button()
        Me.Cnombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDiv = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Bcancelar
        '
        Me.Bcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bcancelar.Location = New System.Drawing.Point(305, 195)
        Me.Bcancelar.Name = "Bcancelar"
        Me.Bcancelar.Size = New System.Drawing.Size(93, 28)
        Me.Bcancelar.TabIndex = 330
        Me.Bcancelar.Text = "&Cancelar"
        Me.Bcancelar.UseVisualStyleBackColor = True
        '
        'Baceptar
        '
        Me.Baceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Baceptar.Location = New System.Drawing.Point(30, 195)
        Me.Baceptar.Name = "Baceptar"
        Me.Baceptar.Size = New System.Drawing.Size(93, 28)
        Me.Baceptar.TabIndex = 329
        Me.Baceptar.Text = "&Aceptar"
        Me.Baceptar.UseVisualStyleBackColor = True
        '
        'Cnombre
        '
        Me.Cnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cnombre.ForeColor = System.Drawing.Color.Blue
        Me.Cnombre.Location = New System.Drawing.Point(120, 36)
        Me.Cnombre.MaxLength = 120
        Me.Cnombre.Name = "Cnombre"
        Me.Cnombre.Size = New System.Drawing.Size(278, 20)
        Me.Cnombre.TabIndex = 328
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 331
        Me.Label5.Text = "Nombre Div:"
        '
        'txtDiv
        '
        Me.txtDiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiv.ForeColor = System.Drawing.Color.Blue
        Me.txtDiv.Location = New System.Drawing.Point(120, 82)
        Me.txtDiv.MaxLength = 6
        Me.txtDiv.Name = "txtDiv"
        Me.txtDiv.Size = New System.Drawing.Size(278, 20)
        Me.txtDiv.TabIndex = 332
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 333
        Me.Label1.Text = "Cve Division:"
        '
        'MttoDivisiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 259)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtDiv)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Bcancelar)
        Me.Controls.Add(Me.Baceptar)
        Me.Controls.Add(Me.Cnombre)
        Me.Controls.Add(Me.Label5)
        Me.Name = "MttoDivisiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DIVISIONES"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Bcancelar As Button
    Friend WithEvents Baceptar As Button
    Friend WithEvents Cnombre As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDiv As TextBox
    Friend WithEvents Label1 As Label
End Class
