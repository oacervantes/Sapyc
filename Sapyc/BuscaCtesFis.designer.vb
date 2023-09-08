<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscaCtesFis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BuscaCtesFis))
        Me.Contador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Baceptar = New System.Windows.Forms.Button()
        Me.Cnombrecte = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Lista = New System.Windows.Forms.DataGridView()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Contador
        '
        Me.Contador.ForeColor = System.Drawing.Color.Blue
        Me.Contador.Location = New System.Drawing.Point(417, 10)
        Me.Contador.Name = "Contador"
        Me.Contador.Size = New System.Drawing.Size(58, 20)
        Me.Contador.TabIndex = 49
        Me.Contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(340, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "No.Registros:"
        '
        'Baceptar
        '
        Me.Baceptar.Location = New System.Drawing.Point(210, 321)
        Me.Baceptar.Name = "Baceptar"
        Me.Baceptar.Size = New System.Drawing.Size(82, 26)
        Me.Baceptar.TabIndex = 46
        Me.Baceptar.Text = "&Aceptar"
        Me.Baceptar.UseVisualStyleBackColor = True
        '
        'Cnombrecte
        '
        Me.Cnombrecte.Location = New System.Drawing.Point(86, 35)
        Me.Cnombrecte.MaxLength = 80
        Me.Cnombrecte.Name = "Cnombrecte"
        Me.Cnombrecte.Size = New System.Drawing.Size(389, 20)
        Me.Cnombrecte.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Nombre:"
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = False
        Me.Lista.AllowUserToDeleteRows = False
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Location = New System.Drawing.Point(27, 62)
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = True
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(448, 253)
        Me.Lista.TabIndex = 52
        '
        'BuscaCtesFis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 356)
        Me.ControlBox = False
        Me.Controls.Add(Me.Lista)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Baceptar)
        Me.Controls.Add(Me.Cnombrecte)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BuscaCtesFis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda de Clientes"
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Baceptar As System.Windows.Forms.Button
    Friend WithEvents Cnombrecte As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Lista As System.Windows.Forms.DataGridView
End Class
