<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelOpcion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelOpcion))
        Me.Baceptar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Opcion3 = New System.Windows.Forms.RadioButton
        Me.Opcion2 = New System.Windows.Forms.RadioButton
        Me.Opcion1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Baceptar
        '
        Me.Baceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Baceptar.Location = New System.Drawing.Point(109, 168)
        Me.Baceptar.Name = "Baceptar"
        Me.Baceptar.Size = New System.Drawing.Size(82, 26)
        Me.Baceptar.TabIndex = 4
        Me.Baceptar.Text = "&Aceptar"
        Me.Baceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Opcion3)
        Me.GroupBox1.Controls.Add(Me.Opcion2)
        Me.GroupBox1.Controls.Add(Me.Opcion1)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 130)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'Opcion3
        '
        Me.Opcion3.AutoSize = True
        Me.Opcion3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opcion3.Location = New System.Drawing.Point(23, 91)
        Me.Opcion3.Name = "Opcion3"
        Me.Opcion3.Size = New System.Drawing.Size(76, 17)
        Me.Opcion3.TabIndex = 2
        Me.Opcion3.TabStop = True
        Me.Opcion3.Text = "Opción 3"
        Me.Opcion3.UseVisualStyleBackColor = True
        Me.Opcion3.Visible = False
        '
        'Opcion2
        '
        Me.Opcion2.AutoSize = True
        Me.Opcion2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opcion2.Location = New System.Drawing.Point(23, 57)
        Me.Opcion2.Name = "Opcion2"
        Me.Opcion2.Size = New System.Drawing.Size(76, 17)
        Me.Opcion2.TabIndex = 1
        Me.Opcion2.TabStop = True
        Me.Opcion2.Text = "Opción 2"
        Me.Opcion2.UseVisualStyleBackColor = True
        '
        'Opcion1
        '
        Me.Opcion1.AutoSize = True
        Me.Opcion1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opcion1.Location = New System.Drawing.Point(23, 23)
        Me.Opcion1.Name = "Opcion1"
        Me.Opcion1.Size = New System.Drawing.Size(76, 17)
        Me.Opcion1.TabIndex = 0
        Me.Opcion1.TabStop = True
        Me.Opcion1.Text = "Opción 1"
        Me.Opcion1.UseVisualStyleBackColor = True
        '
        'SelOpcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 206)
        Me.ControlBox = False
        Me.Controls.Add(Me.Baceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SelOpcion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SelOpcion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Baceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Opcion3 As System.Windows.Forms.RadioButton
    Friend WithEvents Opcion2 As System.Windows.Forms.RadioButton
    Friend WithEvents Opcion1 As System.Windows.Forms.RadioButton
End Class
