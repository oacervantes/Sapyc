<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Grupos
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
        Me.Lista = New System.Windows.Forms.DataGridView()
        Me.Bsalir = New System.Windows.Forms.Button()
        Me.Bbaja = New System.Windows.Forms.Button()
        Me.Bmodificar = New System.Windows.Forms.Button()
        Me.Balta = New System.Windows.Forms.Button()
        Me.btnRelacion = New System.Windows.Forms.Button()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = False
        Me.Lista.AllowUserToDeleteRows = False
        Me.Lista.AllowUserToResizeColumns = False
        Me.Lista.AllowUserToResizeRows = False
        Me.Lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Lista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Location = New System.Drawing.Point(3, 2)
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = True
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(526, 291)
        Me.Lista.TabIndex = 9
        '
        'Bsalir
        '
        Me.Bsalir.Location = New System.Drawing.Point(326, 316)
        Me.Bsalir.Name = "Bsalir"
        Me.Bsalir.Size = New System.Drawing.Size(80, 36)
        Me.Bsalir.TabIndex = 8
        Me.Bsalir.Text = "&Salir"
        Me.Bsalir.UseVisualStyleBackColor = True
        '
        'Bbaja
        '
        Me.Bbaja.Location = New System.Drawing.Point(219, 316)
        Me.Bbaja.Name = "Bbaja"
        Me.Bbaja.Size = New System.Drawing.Size(80, 36)
        Me.Bbaja.TabIndex = 7
        Me.Bbaja.Text = "&Baja"
        Me.Bbaja.UseVisualStyleBackColor = True
        '
        'Bmodificar
        '
        Me.Bmodificar.Location = New System.Drawing.Point(112, 316)
        Me.Bmodificar.Name = "Bmodificar"
        Me.Bmodificar.Size = New System.Drawing.Size(80, 36)
        Me.Bmodificar.TabIndex = 6
        Me.Bmodificar.Text = "&Modificación"
        Me.Bmodificar.UseVisualStyleBackColor = True
        '
        'Balta
        '
        Me.Balta.Location = New System.Drawing.Point(3, 316)
        Me.Balta.Name = "Balta"
        Me.Balta.Size = New System.Drawing.Size(80, 36)
        Me.Balta.TabIndex = 5
        Me.Balta.Text = "&Alta"
        Me.Balta.UseVisualStyleBackColor = True
        '
        'btnRelacion
        '
        Me.btnRelacion.Location = New System.Drawing.Point(449, 316)
        Me.btnRelacion.Name = "btnRelacion"
        Me.btnRelacion.Size = New System.Drawing.Size(80, 36)
        Me.btnRelacion.TabIndex = 10
        Me.btnRelacion.Text = "&Relaciona"
        Me.btnRelacion.UseVisualStyleBackColor = True
        Me.btnRelacion.Visible = False
        '
        'Grupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 386)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnRelacion)
        Me.Controls.Add(Me.Lista)
        Me.Controls.Add(Me.Bsalir)
        Me.Controls.Add(Me.Bbaja)
        Me.Controls.Add(Me.Bmodificar)
        Me.Controls.Add(Me.Balta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Grupos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grupos"
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lista As System.Windows.Forms.DataGridView
    Friend WithEvents Bsalir As System.Windows.Forms.Button
    Friend WithEvents Bbaja As System.Windows.Forms.Button
    Friend WithEvents Bmodificar As System.Windows.Forms.Button
    Friend WithEvents Balta As System.Windows.Forms.Button
    Friend WithEvents btnRelacion As Button
End Class
