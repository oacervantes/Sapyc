<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrabajosCliente
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
        Me.BSalir = New System.Windows.Forms.Button()
        Me.dgvTrabajosCtes = New System.Windows.Forms.DataGridView()
        CType(Me.dgvTrabajosCtes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BSalir
        '
        Me.BSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BSalir.Location = New System.Drawing.Point(236, 246)
        Me.BSalir.Name = "BSalir"
        Me.BSalir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BSalir.Size = New System.Drawing.Size(101, 38)
        Me.BSalir.TabIndex = 59
        Me.BSalir.Text = "SALIR"
        Me.BSalir.UseVisualStyleBackColor = True
        '
        'dgvTrabajosCtes
        '
        Me.dgvTrabajosCtes.AllowUserToAddRows = False
        Me.dgvTrabajosCtes.AllowUserToDeleteRows = False
        Me.dgvTrabajosCtes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTrabajosCtes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvTrabajosCtes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTrabajosCtes.Location = New System.Drawing.Point(2, 1)
        Me.dgvTrabajosCtes.Name = "dgvTrabajosCtes"
        Me.dgvTrabajosCtes.Size = New System.Drawing.Size(584, 239)
        Me.dgvTrabajosCtes.TabIndex = 60
        '
        'frmTrabajosCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 290)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvTrabajosCtes)
        Me.Controls.Add(Me.BSalir)
        Me.Name = "frmTrabajosCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TRABAJOS CLIENTES"
        CType(Me.dgvTrabajosCtes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BSalir As Button
    Friend WithEvents dgvTrabajosCtes As DataGridView
End Class
