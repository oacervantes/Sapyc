<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MedioContacto
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
        Me.Bbaja = New System.Windows.Forms.Button()
        Me.Bmodificar = New System.Windows.Forms.Button()
        Me.Balta = New System.Windows.Forms.Button()
        Me.Bsalir = New System.Windows.Forms.Button()
        Me.Lista = New System.Windows.Forms.DataGridView()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bbaja
        '
        Me.Bbaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bbaja.Location = New System.Drawing.Point(207, 276)
        Me.Bbaja.Name = "Bbaja"
        Me.Bbaja.Size = New System.Drawing.Size(80, 25)
        Me.Bbaja.TabIndex = 14
        Me.Bbaja.Text = "Ba&ja"
        Me.Bbaja.UseVisualStyleBackColor = True
        '
        'Bmodificar
        '
        Me.Bmodificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bmodificar.Location = New System.Drawing.Point(121, 276)
        Me.Bmodificar.Name = "Bmodificar"
        Me.Bmodificar.Size = New System.Drawing.Size(80, 25)
        Me.Bmodificar.TabIndex = 13
        Me.Bmodificar.Text = "&Modificar"
        Me.Bmodificar.UseVisualStyleBackColor = True
        '
        'Balta
        '
        Me.Balta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Balta.Location = New System.Drawing.Point(35, 276)
        Me.Balta.Name = "Balta"
        Me.Balta.Size = New System.Drawing.Size(80, 25)
        Me.Balta.TabIndex = 12
        Me.Balta.Text = "&Alta"
        Me.Balta.UseVisualStyleBackColor = True
        '
        'Bsalir
        '
        Me.Bsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bsalir.Location = New System.Drawing.Point(412, 276)
        Me.Bsalir.Name = "Bsalir"
        Me.Bsalir.Size = New System.Drawing.Size(80, 25)
        Me.Bsalir.TabIndex = 11
        Me.Bsalir.Text = "&Salir"
        Me.Bsalir.UseVisualStyleBackColor = True
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = False
        Me.Lista.AllowUserToDeleteRows = False
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Location = New System.Drawing.Point(35, 12)
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = True
        Me.Lista.Size = New System.Drawing.Size(462, 249)
        Me.Lista.TabIndex = 10
        '
        'MedioContacto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 312)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bbaja)
        Me.Controls.Add(Me.Bmodificar)
        Me.Controls.Add(Me.Balta)
        Me.Controls.Add(Me.Bsalir)
        Me.Controls.Add(Me.Lista)
        Me.Name = "MedioContacto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MEDIOS CONTACTO"
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bbaja As Button
    Friend WithEvents Bmodificar As Button
    Friend WithEvents Balta As Button
    Friend WithEvents Bsalir As Button
    Friend WithEvents Lista As DataGridView
End Class
