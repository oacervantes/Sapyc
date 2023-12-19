<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportePorClaves
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.gridClaves = New System.Windows.Forms.DataGridView()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        CType(Me.gridClaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Controls.Add(Me.gridClaves)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 1)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1114, 561)
        Me.panPrincipal.TabIndex = 4
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(15, 42)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(1082, 2)
        Me.panLinea.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(15, 8)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(384, 32)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "CLIENTES POR CLAVE DE TRABAJO"
        '
        'gridClaves
        '
        Me.gridClaves.AllowUserToAddRows = False
        Me.gridClaves.AllowUserToDeleteRows = False
        Me.gridClaves.AllowUserToResizeRows = False
        Me.gridClaves.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridClaves.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridClaves.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.gridClaves.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridClaves.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.gridClaves.ColumnHeadersHeight = 40
        Me.gridClaves.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridClaves.GridColor = System.Drawing.Color.Gainsboro
        Me.gridClaves.Location = New System.Drawing.Point(15, 61)
        Me.gridClaves.MultiSelect = False
        Me.gridClaves.Name = "gridClaves"
        Me.gridClaves.RowHeadersWidth = 25
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gridClaves.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.gridClaves.RowTemplate.Height = 24
        Me.gridClaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridClaves.Size = New System.Drawing.Size(1082, 490)
        Me.gridClaves.TabIndex = 2
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(16, 570)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(112, 25)
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Text = "Exportar Excel"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(1007, 570)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(91, 25)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmReportePorClaves
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1115, 604)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.panPrincipal)
        Me.Name = "frmReportePorClaves"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        CType(Me.gridClaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents gridClaves As DataGridView
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnSalir As Button
End Class
