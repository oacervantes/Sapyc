<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LeeCve
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LeeCve))
        Me.Letrero = New System.Windows.Forms.Label
        Me.Ccve = New System.Windows.Forms.TextBox
        Me.Baceptar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Letrero
        '
        Me.Letrero.AutoSize = True
        Me.Letrero.Location = New System.Drawing.Point(12, 34)
        Me.Letrero.Name = "Letrero"
        Me.Letrero.Size = New System.Drawing.Size(37, 13)
        Me.Letrero.TabIndex = 3
        Me.Letrero.Text = "Clave:"
        '
        'Ccve
        '
        Me.Ccve.Location = New System.Drawing.Point(117, 31)
        Me.Ccve.MaxLength = 6
        Me.Ccve.Name = "Ccve"
        Me.Ccve.Size = New System.Drawing.Size(60, 20)
        Me.Ccve.TabIndex = 0
        '
        'Baceptar
        '
        Me.Baceptar.Location = New System.Drawing.Point(53, 80)
        Me.Baceptar.Name = "Baceptar"
        Me.Baceptar.Size = New System.Drawing.Size(82, 26)
        Me.Baceptar.TabIndex = 1
        Me.Baceptar.Text = "&Aceptar"
        Me.Baceptar.UseVisualStyleBackColor = True
        '
        'LeeCve
        '
        Me.AcceptButton = Me.Baceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(206, 124)
        Me.ControlBox = False
        Me.Controls.Add(Me.Baceptar)
        Me.Controls.Add(Me.Ccve)
        Me.Controls.Add(Me.Letrero)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LeeCve"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clave"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Letrero As System.Windows.Forms.Label
    Friend WithEvents Ccve As System.Windows.Forms.TextBox
    Friend WithEvents Baceptar As System.Windows.Forms.Button
End Class
