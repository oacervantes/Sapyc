<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportesGRD
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportesGRD))
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.tabReportes = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.gridClientes = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gridServicios = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.gridProveedores = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.gridRolesEntidad = New System.Windows.Forms.DataGridView()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.tabReportes.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.gridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.gridServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.gridProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.gridRolesEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.btnGenerar)
        Me.panPrincipal.Controls.Add(Me.tabReportes)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1234, 634)
        Me.panPrincipal.TabIndex = 0
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Location = New System.Drawing.Point(11, 43)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(130, 25)
        Me.btnGenerar.TabIndex = 5
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'tabReportes
        '
        Me.tabReportes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabReportes.Controls.Add(Me.TabPage1)
        Me.tabReportes.Controls.Add(Me.TabPage2)
        Me.tabReportes.Controls.Add(Me.TabPage3)
        Me.tabReportes.Controls.Add(Me.TabPage4)
        Me.tabReportes.ItemSize = New System.Drawing.Size(220, 25)
        Me.tabReportes.Location = New System.Drawing.Point(1, 74)
        Me.tabReportes.Name = "tabReportes"
        Me.tabReportes.SelectedIndex = 0
        Me.tabReportes.Size = New System.Drawing.Size(1232, 557)
        Me.tabReportes.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabReportes.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gridClientes)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1224, 524)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "CLIENTES"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'gridClientes
        '
        Me.gridClientes.AllowUserToAddRows = False
        Me.gridClientes.AllowUserToDeleteRows = False
        Me.gridClientes.AllowUserToResizeRows = False
        Me.gridClientes.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.gridClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridClientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridClientes.ColumnHeadersHeight = 40
        Me.gridClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridClientes.GridColor = System.Drawing.Color.Gainsboro
        Me.gridClientes.Location = New System.Drawing.Point(0, 0)
        Me.gridClientes.Name = "gridClientes"
        Me.gridClientes.RowHeadersWidth = 25
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gridClientes.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridClientes.RowTemplate.Height = 24
        Me.gridClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridClientes.Size = New System.Drawing.Size(1224, 524)
        Me.gridClientes.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gridServicios)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1121, 524)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "SERVICIOS"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gridServicios
        '
        Me.gridServicios.AllowUserToAddRows = False
        Me.gridServicios.AllowUserToDeleteRows = False
        Me.gridServicios.AllowUserToResizeRows = False
        Me.gridServicios.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridServicios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.gridServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridServicios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gridServicios.ColumnHeadersHeight = 40
        Me.gridServicios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridServicios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridServicios.GridColor = System.Drawing.Color.Gainsboro
        Me.gridServicios.Location = New System.Drawing.Point(0, 0)
        Me.gridServicios.Name = "gridServicios"
        Me.gridServicios.RowHeadersWidth = 25
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gridServicios.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gridServicios.RowTemplate.Height = 24
        Me.gridServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridServicios.Size = New System.Drawing.Size(1121, 524)
        Me.gridServicios.TabIndex = 3
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.gridProveedores)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1121, 524)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "PROVEEDORES"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'gridProveedores
        '
        Me.gridProveedores.AllowUserToAddRows = False
        Me.gridProveedores.AllowUserToDeleteRows = False
        Me.gridProveedores.AllowUserToResizeRows = False
        Me.gridProveedores.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridProveedores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.gridProveedores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridProveedores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.gridProveedores.ColumnHeadersHeight = 40
        Me.gridProveedores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridProveedores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridProveedores.GridColor = System.Drawing.Color.Gainsboro
        Me.gridProveedores.Location = New System.Drawing.Point(0, 0)
        Me.gridProveedores.MultiSelect = False
        Me.gridProveedores.Name = "gridProveedores"
        Me.gridProveedores.RowHeadersWidth = 25
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gridProveedores.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gridProveedores.RowTemplate.Height = 24
        Me.gridProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridProveedores.Size = New System.Drawing.Size(1121, 524)
        Me.gridProveedores.TabIndex = 3
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.gridRolesEntidad)
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1121, 524)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "ROLES EN LA ENTIDAD"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'gridRolesEntidad
        '
        Me.gridRolesEntidad.AllowUserToAddRows = False
        Me.gridRolesEntidad.AllowUserToDeleteRows = False
        Me.gridRolesEntidad.AllowUserToResizeRows = False
        Me.gridRolesEntidad.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridRolesEntidad.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.gridRolesEntidad.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridRolesEntidad.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.gridRolesEntidad.ColumnHeadersHeight = 40
        Me.gridRolesEntidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridRolesEntidad.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridRolesEntidad.GridColor = System.Drawing.Color.Gainsboro
        Me.gridRolesEntidad.Location = New System.Drawing.Point(0, 0)
        Me.gridRolesEntidad.MultiSelect = False
        Me.gridRolesEntidad.Name = "gridRolesEntidad"
        Me.gridRolesEntidad.RowHeadersWidth = 25
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gridRolesEntidad.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.gridRolesEntidad.RowTemplate.Height = 24
        Me.gridRolesEntidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridRolesEntidad.Size = New System.Drawing.Size(1121, 524)
        Me.gridRolesEntidad.TabIndex = 3
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 36)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(1234, 2)
        Me.panLinea.TabIndex = 3
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(2, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(226, 32)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "REPORTES GRD-GTI"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(1092, 640)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(130, 25)
        Me.btnSalir.TabIndex = 0
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(12, 640)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(130, 25)
        Me.btnExportar.TabIndex = 1
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'FrmReportesGRD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1234, 672)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.panPrincipal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmReportesGRD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes GRD-GTI"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.tabReportes.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.gridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.gridServicios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.gridProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.gridRolesEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents tabReportes As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents gridClientes As DataGridView
    Friend WithEvents gridServicios As DataGridView
    Friend WithEvents gridProveedores As DataGridView
    Friend WithEvents gridRolesEntidad As DataGridView
    Friend WithEvents btnGenerar As Button
End Class
