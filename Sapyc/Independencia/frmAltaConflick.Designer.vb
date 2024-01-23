<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAltaConflick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAltaConflick))
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.gridClaves = New System.Windows.Forms.DataGridView()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombreSocio = New System.Windows.Forms.TextBox()
        Me.txtSocio = New System.Windows.Forms.TextBox()
        Me.lblSocio = New System.Windows.Forms.Label()
        Me.txtNombreGerente = New System.Windows.Forms.TextBox()
        Me.txtGerente = New System.Windows.Forms.TextBox()
        Me.lblGerente = New System.Windows.Forms.Label()
        Me.Cuadro = New System.Windows.Forms.TabControl()
        Me.Funcionarios = New System.Windows.Forms.TabPage()
        Me.dgvFuncionarios = New System.Windows.Forms.DataGridView()
        Me.BbajaFun = New System.Windows.Forms.Button()
        Me.BaltaFun = New System.Windows.Forms.Button()
        Me.Accionistas = New System.Windows.Forms.TabPage()
        Me.dgvAccionistas = New System.Windows.Forms.DataGridView()
        Me.BbajaAcc = New System.Windows.Forms.Button()
        Me.BaltaAcc = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgTrabajos = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.gpBgc = New System.Windows.Forms.GroupBox()
        Me.CmbNivel = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GBCC = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.rbSi = New System.Windows.Forms.RadioButton()
        Me.txtMotivoIndepen = New System.Windows.Forms.TextBox()
        Me.rbNo = New System.Windows.Forms.RadioButton()
        Me.cboDivision = New System.Windows.Forms.ComboBox()
        Me.cboOficina = New System.Windows.Forms.ComboBox()
        Me.txtNombreCte = New System.Windows.Forms.TextBox()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        CType(Me.gridClaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cuadro.SuspendLayout()
        Me.Funcionarios.SuspendLayout()
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Accionistas.SuspendLayout()
        CType(Me.dgvAccionistas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgTrabajos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.gpBgc.SuspendLayout()
        Me.GBCC.SuspendLayout()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.gridClaves)
        Me.panPrincipal.Controls.Add(Me.txtServicio)
        Me.panPrincipal.Controls.Add(Me.Label3)
        Me.panPrincipal.Controls.Add(Me.txtMotivo)
        Me.panPrincipal.Controls.Add(Me.Label1)
        Me.panPrincipal.Controls.Add(Me.txtNombreSocio)
        Me.panPrincipal.Controls.Add(Me.txtSocio)
        Me.panPrincipal.Controls.Add(Me.lblSocio)
        Me.panPrincipal.Controls.Add(Me.txtNombreGerente)
        Me.panPrincipal.Controls.Add(Me.txtGerente)
        Me.panPrincipal.Controls.Add(Me.lblGerente)
        Me.panPrincipal.Controls.Add(Me.Cuadro)
        Me.panPrincipal.Controls.Add(Me.cboDivision)
        Me.panPrincipal.Controls.Add(Me.cboOficina)
        Me.panPrincipal.Controls.Add(Me.txtNombreCte)
        Me.panPrincipal.Controls.Add(Me.lblDivision)
        Me.panPrincipal.Controls.Add(Me.lblOficina)
        Me.panPrincipal.Controls.Add(Me.lblCliente)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(715, 618)
        Me.panPrincipal.TabIndex = 2
        '
        'gridClaves
        '
        Me.gridClaves.AllowUserToAddRows = False
        Me.gridClaves.AllowUserToDeleteRows = False
        Me.gridClaves.AllowUserToResizeRows = False
        Me.gridClaves.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridClaves.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridClaves.GridColor = System.Drawing.Color.Gainsboro
        Me.gridClaves.Location = New System.Drawing.Point(101, 43)
        Me.gridClaves.Name = "gridClaves"
        Me.gridClaves.RowHeadersWidth = 25
        Me.gridClaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridClaves.Size = New System.Drawing.Size(583, 211)
        Me.gridClaves.TabIndex = 6
        Me.gridClaves.Visible = False
        '
        'txtServicio
        '
        Me.txtServicio.Location = New System.Drawing.Point(104, 260)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(580, 25)
        Me.txtServicio.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 263)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 18)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Servicio :"
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(36, 210)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(648, 44)
        Me.txtMotivo.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 18)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Motivo Solicitud del Conflick : "
        '
        'txtNombreSocio
        '
        Me.txtNombreSocio.Location = New System.Drawing.Point(177, 119)
        Me.txtNombreSocio.Name = "txtNombreSocio"
        Me.txtNombreSocio.Size = New System.Drawing.Size(507, 25)
        Me.txtNombreSocio.TabIndex = 11
        '
        'txtSocio
        '
        Me.txtSocio.Location = New System.Drawing.Point(100, 119)
        Me.txtSocio.Name = "txtSocio"
        Me.txtSocio.Size = New System.Drawing.Size(71, 25)
        Me.txtSocio.TabIndex = 10
        '
        'lblSocio
        '
        Me.lblSocio.AutoSize = True
        Me.lblSocio.Location = New System.Drawing.Point(50, 122)
        Me.lblSocio.Name = "lblSocio"
        Me.lblSocio.Size = New System.Drawing.Size(45, 18)
        Me.lblSocio.TabIndex = 9
        Me.lblSocio.Text = "Socio:"
        '
        'txtNombreGerente
        '
        Me.txtNombreGerente.Location = New System.Drawing.Point(177, 149)
        Me.txtNombreGerente.Name = "txtNombreGerente"
        Me.txtNombreGerente.Size = New System.Drawing.Size(507, 25)
        Me.txtNombreGerente.TabIndex = 14
        '
        'txtGerente
        '
        Me.txtGerente.Location = New System.Drawing.Point(100, 149)
        Me.txtGerente.Name = "txtGerente"
        Me.txtGerente.Size = New System.Drawing.Size(71, 25)
        Me.txtGerente.TabIndex = 13
        '
        'lblGerente
        '
        Me.lblGerente.AutoSize = True
        Me.lblGerente.Location = New System.Drawing.Point(31, 152)
        Me.lblGerente.Name = "lblGerente"
        Me.lblGerente.Size = New System.Drawing.Size(64, 18)
        Me.lblGerente.TabIndex = 12
        Me.lblGerente.Text = "Gerente:"
        '
        'Cuadro
        '
        Me.Cuadro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cuadro.Controls.Add(Me.Funcionarios)
        Me.Cuadro.Controls.Add(Me.Accionistas)
        Me.Cuadro.Controls.Add(Me.TabPage2)
        Me.Cuadro.Controls.Add(Me.TabPage1)
        Me.Cuadro.ItemSize = New System.Drawing.Size(150, 25)
        Me.Cuadro.Location = New System.Drawing.Point(29, 302)
        Me.Cuadro.Name = "Cuadro"
        Me.Cuadro.SelectedIndex = 0
        Me.Cuadro.Size = New System.Drawing.Size(655, 292)
        Me.Cuadro.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.Cuadro.TabIndex = 7
        '
        'Funcionarios
        '
        Me.Funcionarios.Controls.Add(Me.dgvFuncionarios)
        Me.Funcionarios.Controls.Add(Me.BbajaFun)
        Me.Funcionarios.Controls.Add(Me.BaltaFun)
        Me.Funcionarios.Location = New System.Drawing.Point(4, 29)
        Me.Funcionarios.Name = "Funcionarios"
        Me.Funcionarios.Size = New System.Drawing.Size(647, 259)
        Me.Funcionarios.TabIndex = 1
        Me.Funcionarios.Text = "Funcionarios"
        Me.Funcionarios.UseVisualStyleBackColor = True
        '
        'dgvFuncionarios
        '
        Me.dgvFuncionarios.AllowUserToAddRows = False
        Me.dgvFuncionarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvFuncionarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFuncionarios.Location = New System.Drawing.Point(3, 3)
        Me.dgvFuncionarios.Name = "dgvFuncionarios"
        Me.dgvFuncionarios.Size = New System.Drawing.Size(641, 215)
        Me.dgvFuncionarios.TabIndex = 59
        '
        'BbajaFun
        '
        Me.BbajaFun.Location = New System.Drawing.Point(105, 224)
        Me.BbajaFun.Name = "BbajaFun"
        Me.BbajaFun.Size = New System.Drawing.Size(90, 25)
        Me.BbajaFun.TabIndex = 58
        Me.BbajaFun.Text = "Baja"
        Me.BbajaFun.UseVisualStyleBackColor = True
        Me.BbajaFun.Visible = False
        '
        'BaltaFun
        '
        Me.BaltaFun.Location = New System.Drawing.Point(10, 224)
        Me.BaltaFun.Name = "BaltaFun"
        Me.BaltaFun.Size = New System.Drawing.Size(90, 25)
        Me.BaltaFun.TabIndex = 57
        Me.BaltaFun.Text = "Alta"
        Me.BaltaFun.UseVisualStyleBackColor = True
        Me.BaltaFun.Visible = False
        '
        'Accionistas
        '
        Me.Accionistas.Controls.Add(Me.dgvAccionistas)
        Me.Accionistas.Controls.Add(Me.BbajaAcc)
        Me.Accionistas.Controls.Add(Me.BaltaAcc)
        Me.Accionistas.Location = New System.Drawing.Point(4, 29)
        Me.Accionistas.Name = "Accionistas"
        Me.Accionistas.Size = New System.Drawing.Size(647, 259)
        Me.Accionistas.TabIndex = 2
        Me.Accionistas.Text = "Accionistas"
        Me.Accionistas.UseVisualStyleBackColor = True
        '
        'dgvAccionistas
        '
        Me.dgvAccionistas.AllowUserToAddRows = False
        Me.dgvAccionistas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAccionistas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvAccionistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAccionistas.Location = New System.Drawing.Point(3, 3)
        Me.dgvAccionistas.Name = "dgvAccionistas"
        Me.dgvAccionistas.Size = New System.Drawing.Size(641, 195)
        Me.dgvAccionistas.TabIndex = 62
        '
        'BbajaAcc
        '
        Me.BbajaAcc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BbajaAcc.Location = New System.Drawing.Point(99, 204)
        Me.BbajaAcc.Name = "BbajaAcc"
        Me.BbajaAcc.Size = New System.Drawing.Size(70, 22)
        Me.BbajaAcc.TabIndex = 61
        Me.BbajaAcc.Text = "Baja"
        Me.BbajaAcc.UseVisualStyleBackColor = True
        Me.BbajaAcc.Visible = False
        '
        'BaltaAcc
        '
        Me.BaltaAcc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BaltaAcc.Location = New System.Drawing.Point(10, 204)
        Me.BaltaAcc.Name = "BaltaAcc"
        Me.BaltaAcc.Size = New System.Drawing.Size(70, 22)
        Me.BaltaAcc.TabIndex = 60
        Me.BaltaAcc.Text = "Alta"
        Me.BaltaAcc.UseVisualStyleBackColor = True
        Me.BaltaAcc.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgTrabajos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(647, 259)
        Me.TabPage2.TabIndex = 4
        Me.TabPage2.Text = "Trabajos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgTrabajos
        '
        Me.dgTrabajos.AllowUserToAddRows = False
        Me.dgTrabajos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgTrabajos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgTrabajos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTrabajos.Location = New System.Drawing.Point(3, 4)
        Me.dgTrabajos.Name = "dgTrabajos"
        Me.dgTrabajos.Size = New System.Drawing.Size(641, 195)
        Me.dgTrabajos.TabIndex = 64
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gpBgc)
        Me.TabPage1.Controls.Add(Me.GBCC)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(647, 259)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Calificación de riesgo"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'gpBgc
        '
        Me.gpBgc.Controls.Add(Me.CmbNivel)
        Me.gpBgc.Controls.Add(Me.Label2)
        Me.gpBgc.Location = New System.Drawing.Point(359, 36)
        Me.gpBgc.Name = "gpBgc"
        Me.gpBgc.Size = New System.Drawing.Size(276, 186)
        Me.gpBgc.TabIndex = 406
        Me.gpBgc.TabStop = False
        Me.gpBgc.Text = "Background Check"
        '
        'CmbNivel
        '
        Me.CmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbNivel.FormattingEnabled = True
        Me.CmbNivel.Location = New System.Drawing.Point(21, 92)
        Me.CmbNivel.Name = "CmbNivel"
        Me.CmbNivel.Size = New System.Drawing.Size(234, 26)
        Me.CmbNivel.TabIndex = 369
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 18)
        Me.Label2.TabIndex = 368
        Me.Label2.Text = "Nivel de riesgo:"
        '
        'GBCC
        '
        Me.GBCC.Controls.Add(Me.Label16)
        Me.GBCC.Controls.Add(Me.lblMotivo)
        Me.GBCC.Controls.Add(Me.rbSi)
        Me.GBCC.Controls.Add(Me.txtMotivoIndepen)
        Me.GBCC.Controls.Add(Me.rbNo)
        Me.GBCC.Location = New System.Drawing.Point(12, 36)
        Me.GBCC.Name = "GBCC"
        Me.GBCC.Size = New System.Drawing.Size(328, 186)
        Me.GBCC.TabIndex = 405
        Me.GBCC.TabStop = False
        Me.GBCC.Text = "Conflict Check"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 33)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(308, 18)
        Me.Label16.TabIndex = 367
        Me.Label16.Text = "¿Existe situación de conflicto de independencia?"
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Location = New System.Drawing.Point(10, 91)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(136, 18)
        Me.lblMotivo.TabIndex = 369
        Me.lblMotivo.Text = "Motivo del conflicto:"
        '
        'rbSi
        '
        Me.rbSi.AutoSize = True
        Me.rbSi.Location = New System.Drawing.Point(37, 54)
        Me.rbSi.Name = "rbSi"
        Me.rbSi.Size = New System.Drawing.Size(37, 22)
        Me.rbSi.TabIndex = 365
        Me.rbSi.TabStop = True
        Me.rbSi.Text = "Si"
        Me.rbSi.UseVisualStyleBackColor = True
        '
        'txtMotivoIndepen
        '
        Me.txtMotivoIndepen.Location = New System.Drawing.Point(10, 110)
        Me.txtMotivoIndepen.MaxLength = 120
        Me.txtMotivoIndepen.Multiline = True
        Me.txtMotivoIndepen.Name = "txtMotivoIndepen"
        Me.txtMotivoIndepen.Size = New System.Drawing.Size(308, 57)
        Me.txtMotivoIndepen.TabIndex = 368
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Location = New System.Drawing.Point(98, 54)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(44, 22)
        Me.rbNo.TabIndex = 366
        Me.rbNo.TabStop = True
        Me.rbNo.Text = "No"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'cboDivision
        '
        Me.cboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDivision.FormattingEnabled = True
        Me.cboDivision.Location = New System.Drawing.Point(101, 84)
        Me.cboDivision.Name = "cboDivision"
        Me.cboDivision.Size = New System.Drawing.Size(274, 26)
        Me.cboDivision.TabIndex = 5
        '
        'cboOficina
        '
        Me.cboOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOficina.FormattingEnabled = True
        Me.cboOficina.Location = New System.Drawing.Point(101, 49)
        Me.cboOficina.Name = "cboOficina"
        Me.cboOficina.Size = New System.Drawing.Size(274, 26)
        Me.cboOficina.TabIndex = 3
        '
        'txtNombreCte
        '
        Me.txtNombreCte.Location = New System.Drawing.Point(101, 18)
        Me.txtNombreCte.Name = "txtNombreCte"
        Me.txtNombreCte.Size = New System.Drawing.Size(583, 25)
        Me.txtNombreCte.TabIndex = 1
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(33, 87)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(62, 18)
        Me.lblDivision.TabIndex = 4
        Me.lblDivision.Text = "División:"
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Location = New System.Drawing.Point(40, 52)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(55, 18)
        Me.lblOficina.TabIndex = 2
        Me.lblOficina.Text = "Oficina:"
        '
        'lblCliente
        '
        Me.lblCliente.Location = New System.Drawing.Point(26, 8)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(112, 47)
        Me.lblCliente.TabIndex = 0
        Me.lblCliente.Text = "Cliente principal*:"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(12, 625)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(130, 25)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(573, 625)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(130, 25)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmAltaConflick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 657)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.panPrincipal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAltaConflick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos de Propuesta"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        CType(Me.gridClaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cuadro.ResumeLayout(False)
        Me.Funcionarios.ResumeLayout(False)
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Accionistas.ResumeLayout(False)
        CType(Me.dgvAccionistas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgTrabajos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.gpBgc.ResumeLayout(False)
        Me.gpBgc.PerformLayout()
        Me.GBCC.ResumeLayout(False)
        Me.GBCC.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents gridClaves As DataGridView
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNombreSocio As TextBox
    Friend WithEvents txtSocio As TextBox
    Friend WithEvents lblSocio As Label
    Friend WithEvents txtNombreGerente As TextBox
    Friend WithEvents txtGerente As TextBox
    Friend WithEvents lblGerente As Label
    Friend WithEvents Cuadro As TabControl
    Friend WithEvents Funcionarios As TabPage
    Friend WithEvents dgvFuncionarios As DataGridView
    Friend WithEvents BbajaFun As Button
    Friend WithEvents BaltaFun As Button
    Friend WithEvents Accionistas As TabPage
    Friend WithEvents dgvAccionistas As DataGridView
    Friend WithEvents BbajaAcc As Button
    Friend WithEvents BaltaAcc As Button
    Friend WithEvents cboDivision As ComboBox
    Friend WithEvents cboOficina As ComboBox
    Friend WithEvents txtNombreCte As TextBox
    Friend WithEvents lblDivision As Label
    Friend WithEvents lblOficina As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBCC As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents lblMotivo As Label
    Friend WithEvents rbSi As RadioButton
    Friend WithEvents txtMotivoIndepen As TextBox
    Friend WithEvents rbNo As RadioButton
    Friend WithEvents gpBgc As GroupBox
    Friend WithEvents CmbNivel As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgTrabajos As DataGridView
    Friend WithEvents txtServicio As TextBox
    Friend WithEvents Label3 As Label
End Class
