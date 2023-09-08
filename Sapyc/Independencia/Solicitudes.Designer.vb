<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Solicitudes
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
        Me.Bguardar = New System.Windows.Forms.Button()
        Me.BSalir = New System.Windows.Forms.Button()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = False
        Me.Lista.AllowUserToDeleteRows = False
        Me.Lista.AllowUserToOrderColumns = True
        Me.Lista.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Lista.Location = New System.Drawing.Point(3, 2)
        Me.Lista.Name = "Lista"
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Lista.Size = New System.Drawing.Size(1005, 466)
        Me.Lista.TabIndex = 53
        '
        'Bguardar
        '
        Me.Bguardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bguardar.Location = New System.Drawing.Point(3, 477)
        Me.Bguardar.Name = "Bguardar"
        Me.Bguardar.Size = New System.Drawing.Size(90, 25)
        Me.Bguardar.TabIndex = 56
        Me.Bguardar.Text = "&Ver"
        Me.Bguardar.UseVisualStyleBackColor = True
        '
        'BSalir
        '
        Me.BSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BSalir.Location = New System.Drawing.Point(921, 477)
        Me.BSalir.Name = "BSalir"
        Me.BSalir.Size = New System.Drawing.Size(87, 25)
        Me.BSalir.TabIndex = 54
        Me.BSalir.Text = "Salir"
        Me.BSalir.UseVisualStyleBackColor = True
        '
        'Solicitudes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 511)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bguardar)
        Me.Controls.Add(Me.BSalir)
        Me.Controls.Add(Me.Lista)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Solicitudes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SOLICITUDES PROPUESTA"
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Lista As DataGridView
    Friend WithEvents Bguardar As Button
    Friend WithEvents BSalir As Button
End Class
