<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientesRechazados
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientesRechazados))
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.cmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.gpBoxRespuesta = New System.Windows.Forms.GroupBox()
        Me.rdTodos = New System.Windows.Forms.RadioButton()
        Me.rdPeriodo = New System.Windows.Forms.RadioButton()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.gridClaves = New System.Windows.Forms.DataGridView()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.gpBoxRespuesta.SuspendLayout()
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
        Me.panPrincipal.Controls.Add(Me.cmbPeriodo)
        Me.panPrincipal.Controls.Add(Me.gpBoxRespuesta)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Controls.Add(Me.gridClaves)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1114, 561)
        Me.panPrincipal.TabIndex = 4
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodo.DropDownWidth = 160
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.Location = New System.Drawing.Point(229, 55)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(121, 26)
        Me.cmbPeriodo.TabIndex = 23
        '
        'gpBoxRespuesta
        '
        Me.gpBoxRespuesta.Controls.Add(Me.rdTodos)
        Me.gpBoxRespuesta.Controls.Add(Me.rdPeriodo)
        Me.gpBoxRespuesta.Location = New System.Drawing.Point(21, 45)
        Me.gpBoxRespuesta.Name = "gpBoxRespuesta"
        Me.gpBoxRespuesta.Size = New System.Drawing.Size(186, 40)
        Me.gpBoxRespuesta.TabIndex = 22
        Me.gpBoxRespuesta.TabStop = False
        '
        'rdTodos
        '
        Me.rdTodos.AutoSize = True
        Me.rdTodos.Location = New System.Drawing.Point(20, 13)
        Me.rdTodos.Name = "rdTodos"
        Me.rdTodos.Size = New System.Drawing.Size(62, 22)
        Me.rdTodos.TabIndex = 21
        Me.rdTodos.Text = "Todos"
        Me.rdTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdTodos.UseVisualStyleBackColor = True
        '
        'rdPeriodo
        '
        Me.rdPeriodo.AutoSize = True
        Me.rdPeriodo.Location = New System.Drawing.Point(105, 13)
        Me.rdPeriodo.Name = "rdPeriodo"
        Me.rdPeriodo.Size = New System.Drawing.Size(75, 22)
        Me.rdPeriodo.TabIndex = 22
        Me.rdPeriodo.Text = "Periodo"
        Me.rdPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdPeriodo.UseVisualStyleBackColor = True
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
        Me.lblTitulo.Size = New System.Drawing.Size(305, 32)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "SOLICITUDES RECHAZADAS"
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridClaves.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridClaves.ColumnHeadersHeight = 40
        Me.gridClaves.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridClaves.GridColor = System.Drawing.Color.Gainsboro
        Me.gridClaves.Location = New System.Drawing.Point(15, 89)
        Me.gridClaves.MultiSelect = False
        Me.gridClaves.Name = "gridClaves"
        Me.gridClaves.RowHeadersWidth = 25
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gridClaves.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridClaves.RowTemplate.Height = 24
        Me.gridClaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridClaves.Size = New System.Drawing.Size(1082, 452)
        Me.gridClaves.TabIndex = 2
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(16, 569)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(112, 25)
        Me.btnExportar.TabIndex = 11
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(1007, 569)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(91, 25)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmClientesRechazados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1115, 604)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.panPrincipal)
        Me.Controls.Add(Me.btnSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmClientesRechazados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes Rechazados"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.gpBoxRespuesta.ResumeLayout(False)
        Me.gpBoxRespuesta.PerformLayout()
        CType(Me.gridClaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents gridClaves As DataGridView
    Friend WithEvents btnExportar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents gpBoxRespuesta As GroupBox
    Friend WithEvents rdTodos As RadioButton
    Friend WithEvents rdPeriodo As RadioButton
    Friend WithEvents cmbPeriodo As ComboBox
End Class
