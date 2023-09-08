<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MttoGrupo
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
        Me.Cdescgpo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Ccvegpo = New System.Windows.Forms.TextBox()
        Me.Bcancelar = New System.Windows.Forms.Button()
        Me.Baceptar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lista = New System.Windows.Forms.DataGridView()
        Me.Cnombre = New System.Windows.Forms.TextBox()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cdescgpo
        '
        Me.Cdescgpo.Location = New System.Drawing.Point(186, 59)
        Me.Cdescgpo.MaxLength = 40
        Me.Cdescgpo.Name = "Cdescgpo"
        Me.Cdescgpo.Size = New System.Drawing.Size(256, 20)
        Me.Cdescgpo.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Descripción Grupo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Clave Grupo:"
        '
        'Ccvegpo
        '
        Me.Ccvegpo.Enabled = False
        Me.Ccvegpo.Location = New System.Drawing.Point(186, 28)
        Me.Ccvegpo.MaxLength = 4
        Me.Ccvegpo.Name = "Ccvegpo"
        Me.Ccvegpo.Size = New System.Drawing.Size(46, 20)
        Me.Ccvegpo.TabIndex = 5
        Me.Ccvegpo.TabStop = False
        '
        'Bcancelar
        '
        Me.Bcancelar.Location = New System.Drawing.Point(436, 255)
        Me.Bcancelar.Name = "Bcancelar"
        Me.Bcancelar.Size = New System.Drawing.Size(93, 28)
        Me.Bcancelar.TabIndex = 10
        Me.Bcancelar.Text = "&Cancelar"
        Me.Bcancelar.UseVisualStyleBackColor = True
        '
        'Baceptar
        '
        Me.Baceptar.Location = New System.Drawing.Point(41, 265)
        Me.Baceptar.Name = "Baceptar"
        Me.Baceptar.Size = New System.Drawing.Size(93, 28)
        Me.Baceptar.TabIndex = 7
        Me.Baceptar.Text = "&Aceptar"
        Me.Baceptar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Cliente :"
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = False
        Me.Lista.AllowUserToDeleteRows = False
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Location = New System.Drawing.Point(186, 114)
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = True
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(343, 135)
        Me.Lista.TabIndex = 371
        '
        'Cnombre
        '
        Me.Cnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cnombre.ForeColor = System.Drawing.Color.Blue
        Me.Cnombre.Location = New System.Drawing.Point(186, 94)
        Me.Cnombre.MaxLength = 120
        Me.Cnombre.Name = "Cnombre"
        Me.Cnombre.Size = New System.Drawing.Size(343, 20)
        Me.Cnombre.TabIndex = 7
        '
        'MttoGrupo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 317)
        Me.ControlBox = False
        Me.Controls.Add(Me.Lista)
        Me.Controls.Add(Me.Cnombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cdescgpo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Ccvegpo)
        Me.Controls.Add(Me.Bcancelar)
        Me.Controls.Add(Me.Baceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "MttoGrupo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manejo de Grupos"
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cdescgpo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Ccvegpo As System.Windows.Forms.TextBox
    Friend WithEvents Bcancelar As System.Windows.Forms.Button
    Friend WithEvents Baceptar As System.Windows.Forms.Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Lista As DataGridView
    Friend WithEvents Cnombre As TextBox
End Class
