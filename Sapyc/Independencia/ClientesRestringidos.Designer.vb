<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientesRestringidos
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
        Me.dgLista = New System.Windows.Forms.DataGridView()
        Me.Bcancelar = New System.Windows.Forms.Button()
        Me.BCargar = New System.Windows.Forms.Button()
        Me.btnGuadar = New System.Windows.Forms.Button()
        Me.ofdArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgLista
        '
        Me.dgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLista.Location = New System.Drawing.Point(13, 13)
        Me.dgLista.Name = "dgLista"
        Me.dgLista.Size = New System.Drawing.Size(634, 332)
        Me.dgLista.TabIndex = 0
        '
        'Bcancelar
        '
        Me.Bcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bcancelar.Location = New System.Drawing.Point(554, 395)
        Me.Bcancelar.Name = "Bcancelar"
        Me.Bcancelar.Size = New System.Drawing.Size(93, 28)
        Me.Bcancelar.TabIndex = 7
        Me.Bcancelar.Text = "&Cancelar"
        Me.Bcancelar.UseVisualStyleBackColor = True
        '
        'BCargar
        '
        Me.BCargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BCargar.Location = New System.Drawing.Point(532, 351)
        Me.BCargar.Name = "BCargar"
        Me.BCargar.Size = New System.Drawing.Size(115, 28)
        Me.BCargar.TabIndex = 6
        Me.BCargar.Text = "&Cargar Lay Out"
        Me.BCargar.UseVisualStyleBackColor = True
        '
        'btnGuadar
        '
        Me.btnGuadar.Enabled = False
        Me.btnGuadar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuadar.Location = New System.Drawing.Point(13, 395)
        Me.btnGuadar.Name = "btnGuadar"
        Me.btnGuadar.Size = New System.Drawing.Size(93, 28)
        Me.btnGuadar.TabIndex = 8
        Me.btnGuadar.Text = "&Guardar"
        Me.btnGuadar.UseVisualStyleBackColor = True
        '
        'ofdArchivo
        '
        Me.ofdArchivo.Filter = "Archivos Excel | *.xlsx"
        '
        'txtArchivo
        '
        Me.txtArchivo.Location = New System.Drawing.Point(82, 356)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(432, 20)
        Me.txtArchivo.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 363)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Archivo:"
        '
        'ClientesRestringidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 435)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtArchivo)
        Me.Controls.Add(Me.btnGuadar)
        Me.Controls.Add(Me.Bcancelar)
        Me.Controls.Add(Me.BCargar)
        Me.Controls.Add(Me.dgLista)
        Me.Name = "ClientesRestringidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CLIENTES RESTRINGIDOS"
        CType(Me.dgLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgLista As DataGridView
    Friend WithEvents Bcancelar As Button
    Friend WithEvents BCargar As Button
    Friend WithEvents btnGuadar As Button
    Friend WithEvents ofdArchivo As OpenFileDialog
    Friend WithEvents txtArchivo As TextBox
    Friend WithEvents Label1 As Label
End Class
