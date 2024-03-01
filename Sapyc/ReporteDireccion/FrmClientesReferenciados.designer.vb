<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClientesReferenciados
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientesReferenciados))
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.gpBoxTipoReporte = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rdIndividual = New System.Windows.Forms.RadioButton()
        Me.rdSocioEncargado = New System.Windows.Forms.RadioButton()
        Me.lblFechaDe = New System.Windows.Forms.Label()
        Me.txtFechaA = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaDe = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaAl = New System.Windows.Forms.Label()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Cuadro = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgCteNuevo = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgCteRef = New System.Windows.Forms.DataGridView()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.gpBoxTipoReporte.SuspendLayout()
        Me.Cuadro.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgCteNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgCteRef, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.gpBoxTipoReporte)
        Me.panPrincipal.Controls.Add(Me.lblFechaDe)
        Me.panPrincipal.Controls.Add(Me.txtFechaA)
        Me.panPrincipal.Controls.Add(Me.txtFechaDe)
        Me.panPrincipal.Controls.Add(Me.lblFechaAl)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Controls.Add(Me.Cuadro)
        Me.panPrincipal.Controls.Add(Me.btnGenerar)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1182, 645)
        Me.panPrincipal.TabIndex = 1
        '
        'gpBoxTipoReporte
        '
        Me.gpBoxTipoReporte.Controls.Add(Me.Label5)
        Me.gpBoxTipoReporte.Controls.Add(Me.rdIndividual)
        Me.gpBoxTipoReporte.Controls.Add(Me.rdSocioEncargado)
        Me.gpBoxTipoReporte.Location = New System.Drawing.Point(11, 49)
        Me.gpBoxTipoReporte.Name = "gpBoxTipoReporte"
        Me.gpBoxTipoReporte.Size = New System.Drawing.Size(402, 63)
        Me.gpBoxTipoReporte.TabIndex = 32
        Me.gpBoxTipoReporte.TabStop = False
        Me.gpBoxTipoReporte.Text = "GroupBox1"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, -2)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(402, 23)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Tipo de Reporte"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdIndividual
        '
        Me.rdIndividual.Location = New System.Drawing.Point(213, 31)
        Me.rdIndividual.Name = "rdIndividual"
        Me.rdIndividual.Size = New System.Drawing.Size(154, 22)
        Me.rdIndividual.TabIndex = 25
        Me.rdIndividual.TabStop = True
        Me.rdIndividual.Text = "Individual"
        Me.rdIndividual.UseVisualStyleBackColor = True
        Me.rdIndividual.Visible = False
        '
        'rdSocioEncargado
        '
        Me.rdSocioEncargado.Location = New System.Drawing.Point(35, 31)
        Me.rdSocioEncargado.Name = "rdSocioEncargado"
        Me.rdSocioEncargado.Size = New System.Drawing.Size(154, 22)
        Me.rdSocioEncargado.TabIndex = 24
        Me.rdSocioEncargado.TabStop = True
        Me.rdSocioEncargado.Text = "Socio Encargado"
        Me.rdSocioEncargado.UseVisualStyleBackColor = True
        '
        'lblFechaDe
        '
        Me.lblFechaDe.AutoSize = True
        Me.lblFechaDe.Location = New System.Drawing.Point(30, 52)
        Me.lblFechaDe.Name = "lblFechaDe"
        Me.lblFechaDe.Size = New System.Drawing.Size(48, 18)
        Me.lblFechaDe.TabIndex = 28
        Me.lblFechaDe.Text = "Fecha:"
        '
        'txtFechaA
        '
        Me.txtFechaA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaA.Location = New System.Drawing.Point(213, 49)
        Me.txtFechaA.Name = "txtFechaA"
        Me.txtFechaA.Size = New System.Drawing.Size(99, 25)
        Me.txtFechaA.TabIndex = 31
        '
        'txtFechaDe
        '
        Me.txtFechaDe.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaDe.Location = New System.Drawing.Point(83, 49)
        Me.txtFechaDe.MinDate = New Date(2015, 8, 1, 0, 0, 0, 0)
        Me.txtFechaDe.Name = "txtFechaDe"
        Me.txtFechaDe.Size = New System.Drawing.Size(99, 25)
        Me.txtFechaDe.TabIndex = 29
        '
        'lblFechaAl
        '
        Me.lblFechaAl.AutoSize = True
        Me.lblFechaAl.Location = New System.Drawing.Point(188, 52)
        Me.lblFechaAl.Name = "lblFechaAl"
        Me.lblFechaAl.Size = New System.Drawing.Size(19, 18)
        Me.lblFechaAl.TabIndex = 30
        Me.lblFechaAl.Text = "al"
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 38)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(1182, 2)
        Me.panLinea.TabIndex = 27
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(5, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(301, 32)
        Me.lblTitulo.TabIndex = 26
        Me.lblTitulo.Text = "CLIENTES REFERENCIADOS"
        '
        'Cuadro
        '
        Me.Cuadro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cuadro.Controls.Add(Me.TabPage1)
        Me.Cuadro.Controls.Add(Me.TabPage2)
        Me.Cuadro.ItemSize = New System.Drawing.Size(300, 30)
        Me.Cuadro.Location = New System.Drawing.Point(-1, 118)
        Me.Cuadro.Name = "Cuadro"
        Me.Cuadro.SelectedIndex = 0
        Me.Cuadro.Size = New System.Drawing.Size(1181, 526)
        Me.Cuadro.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.Cuadro.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgCteNuevo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1173, 488)
        Me.TabPage1.TabIndex = 4
        Me.TabPage1.Text = "CLIENTES REFERENCIADOS NUEVOS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgCteNuevo
        '
        Me.dgCteNuevo.AllowUserToAddRows = False
        Me.dgCteNuevo.AllowUserToDeleteRows = False
        Me.dgCteNuevo.AllowUserToResizeColumns = False
        Me.dgCteNuevo.AllowUserToResizeRows = False
        Me.dgCteNuevo.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgCteNuevo.ColumnHeadersHeight = 40
        Me.dgCteNuevo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCteNuevo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCteNuevo.GridColor = System.Drawing.Color.Gainsboro
        Me.dgCteNuevo.Location = New System.Drawing.Point(0, 0)
        Me.dgCteNuevo.Name = "dgCteNuevo"
        Me.dgCteNuevo.RowHeadersWidth = 25
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.dgCteNuevo.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCteNuevo.RowTemplate.Height = 26
        Me.dgCteNuevo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCteNuevo.Size = New System.Drawing.Size(1173, 488)
        Me.dgCteNuevo.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgCteRef)
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1173, 488)
        Me.TabPage2.TabIndex = 5
        Me.TabPage2.Text = "CLIENTES REFERENCIADOS RECURRENTES"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgCteRef
        '
        Me.dgCteRef.AllowUserToAddRows = False
        Me.dgCteRef.AllowUserToDeleteRows = False
        Me.dgCteRef.AllowUserToResizeColumns = False
        Me.dgCteRef.AllowUserToResizeRows = False
        Me.dgCteRef.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgCteRef.ColumnHeadersHeight = 40
        Me.dgCteRef.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCteRef.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCteRef.GridColor = System.Drawing.Color.Gainsboro
        Me.dgCteRef.Location = New System.Drawing.Point(0, 0)
        Me.dgCteRef.Name = "dgCteRef"
        Me.dgCteRef.RowHeadersWidth = 25
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.dgCteRef.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgCteRef.RowTemplate.Height = 26
        Me.dgCteRef.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCteRef.Size = New System.Drawing.Size(1173, 488)
        Me.dgCteRef.TabIndex = 2
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(433, 87)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(130, 25)
        Me.btnGenerar.TabIndex = 6
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(1042, 653)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(130, 25)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(11, 653)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(130, 25)
        Me.btnExportar.TabIndex = 3
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'frmClientesReferenciados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 686)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmClientesReferenciados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes Referenciados"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.gpBoxTipoReporte.ResumeLayout(False)
        Me.Cuadro.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgCteNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgCteRef, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Cuadro As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgCteNuevo As DataGridView
    Friend WithEvents btnGenerar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblFechaDe As Label
    Friend WithEvents txtFechaA As DateTimePicker
    Friend WithEvents txtFechaDe As DateTimePicker
    Friend WithEvents lblFechaAl As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgCteRef As DataGridView
    Friend WithEvents gpBoxTipoReporte As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents rdIndividual As RadioButton
    Friend WithEvents rdSocioEncargado As RadioButton
End Class
