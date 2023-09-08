<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSAPYCAltaCteFiscales
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Cuadro = New System.Windows.Forms.TabControl()
        Me.Domicilio = New System.Windows.Forms.TabPage()
        Me.Cnombrecomercial = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CBregimen = New System.Windows.Forms.ComboBox()
        Me.Cregimen = New System.Windows.Forms.Label()
        Me.Cemail = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Ccolonia = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Ccp = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Cpais = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Cestado = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Crfc = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Cmunicipio = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cnumint = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cnumext = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Ccalle = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cnombrecte = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Funcionarios = New System.Windows.Forms.TabPage()
        Me.dgvFuncionarios = New System.Windows.Forms.DataGridView()
        Me.Accionistas = New System.Windows.Forms.TabPage()
        Me.dgvAccionistas = New System.Windows.Forms.DataGridView()
        Me.Riesgos = New System.Windows.Forms.TabPage()
        Me.gpBgc = New System.Windows.Forms.GroupBox()
        Me.CmbNivel = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GBCC = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.rbSi = New System.Windows.Forms.RadioButton()
        Me.txtMotivoIndepen = New System.Windows.Forms.TextBox()
        Me.rbNo = New System.Windows.Forms.RadioButton()
        Me.gridClaves = New System.Windows.Forms.DataGridView()
        Me.txtNombreCte = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.cboOficina = New System.Windows.Forms.ComboBox()
        Me.cboDivision = New System.Windows.Forms.ComboBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.txtGerente = New System.Windows.Forms.TextBox()
        Me.txtSoc = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.rbPSno = New System.Windows.Forms.RadioButton()
        Me.rbPSsi = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Cuadro.SuspendLayout()
        Me.Domicilio.SuspendLayout()
        Me.Funcionarios.SuspendLayout()
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Accionistas.SuspendLayout()
        CType(Me.dgvAccionistas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Riesgos.SuspendLayout()
        Me.gpBgc.SuspendLayout()
        Me.GBCC.SuspendLayout()
        CType(Me.gridClaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cuadro
        '
        Me.Cuadro.Controls.Add(Me.Domicilio)
        Me.Cuadro.Controls.Add(Me.Funcionarios)
        Me.Cuadro.Controls.Add(Me.Accionistas)
        Me.Cuadro.Controls.Add(Me.Riesgos)
        Me.Cuadro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuadro.Location = New System.Drawing.Point(12, 214)
        Me.Cuadro.Name = "Cuadro"
        Me.Cuadro.SelectedIndex = 0
        Me.Cuadro.Size = New System.Drawing.Size(687, 387)
        Me.Cuadro.TabIndex = 321
        '
        'Domicilio
        '
        Me.Domicilio.Controls.Add(Me.Cnombrecomercial)
        Me.Domicilio.Controls.Add(Me.Label8)
        Me.Domicilio.Controls.Add(Me.Label6)
        Me.Domicilio.Controls.Add(Me.CBregimen)
        Me.Domicilio.Controls.Add(Me.Cregimen)
        Me.Domicilio.Controls.Add(Me.Cemail)
        Me.Domicilio.Controls.Add(Me.Label19)
        Me.Domicilio.Controls.Add(Me.Ccolonia)
        Me.Domicilio.Controls.Add(Me.Label17)
        Me.Domicilio.Controls.Add(Me.Ccp)
        Me.Domicilio.Controls.Add(Me.Label14)
        Me.Domicilio.Controls.Add(Me.Cpais)
        Me.Domicilio.Controls.Add(Me.Label13)
        Me.Domicilio.Controls.Add(Me.Cestado)
        Me.Domicilio.Controls.Add(Me.Label12)
        Me.Domicilio.Controls.Add(Me.Crfc)
        Me.Domicilio.Controls.Add(Me.Label10)
        Me.Domicilio.Controls.Add(Me.Cmunicipio)
        Me.Domicilio.Controls.Add(Me.Label7)
        Me.Domicilio.Controls.Add(Me.Cnumint)
        Me.Domicilio.Controls.Add(Me.Label5)
        Me.Domicilio.Controls.Add(Me.Cnumext)
        Me.Domicilio.Controls.Add(Me.Label4)
        Me.Domicilio.Controls.Add(Me.Ccalle)
        Me.Domicilio.Controls.Add(Me.Label3)
        Me.Domicilio.Controls.Add(Me.Cnombrecte)
        Me.Domicilio.Controls.Add(Me.Label2)
        Me.Domicilio.Location = New System.Drawing.Point(4, 22)
        Me.Domicilio.Name = "Domicilio"
        Me.Domicilio.Padding = New System.Windows.Forms.Padding(3)
        Me.Domicilio.Size = New System.Drawing.Size(679, 361)
        Me.Domicilio.TabIndex = 0
        Me.Domicilio.Text = "Datos Físcales"
        Me.Domicilio.UseVisualStyleBackColor = True
        '
        'Cnombrecomercial
        '
        Me.Cnombrecomercial.ForeColor = System.Drawing.Color.Blue
        Me.Cnombrecomercial.Location = New System.Drawing.Point(217, 61)
        Me.Cnombrecomercial.MaxLength = 120
        Me.Cnombrecomercial.Name = "Cnombrecomercial"
        Me.Cnombrecomercial.Size = New System.Drawing.Size(406, 20)
        Me.Cnombrecomercial.TabIndex = 40
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(34, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 13)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Nombre Comercial:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(34, 299)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Régimen Fiscal:"
        '
        'CBregimen
        '
        Me.CBregimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBregimen.ForeColor = System.Drawing.Color.Blue
        Me.CBregimen.FormattingEnabled = True
        Me.CBregimen.Location = New System.Drawing.Point(281, 295)
        Me.CBregimen.Name = "CBregimen"
        Me.CBregimen.Size = New System.Drawing.Size(342, 21)
        Me.CBregimen.TabIndex = 63
        '
        'Cregimen
        '
        Me.Cregimen.BackColor = System.Drawing.Color.White
        Me.Cregimen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cregimen.ForeColor = System.Drawing.Color.Blue
        Me.Cregimen.Location = New System.Drawing.Point(217, 295)
        Me.Cregimen.Name = "Cregimen"
        Me.Cregimen.Size = New System.Drawing.Size(56, 20)
        Me.Cregimen.TabIndex = 62
        Me.Cregimen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cemail
        '
        Me.Cemail.ForeColor = System.Drawing.Color.Blue
        Me.Cemail.Location = New System.Drawing.Point(217, 269)
        Me.Cemail.MaxLength = 100
        Me.Cemail.Name = "Cemail"
        Me.Cemail.Size = New System.Drawing.Size(406, 20)
        Me.Cemail.TabIndex = 60
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(34, 273)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 13)
        Me.Label19.TabIndex = 59
        Me.Label19.Text = "e-mail:"
        '
        'Ccolonia
        '
        Me.Ccolonia.ForeColor = System.Drawing.Color.Blue
        Me.Ccolonia.Location = New System.Drawing.Point(217, 165)
        Me.Ccolonia.MaxLength = 60
        Me.Ccolonia.Name = "Ccolonia"
        Me.Ccolonia.Size = New System.Drawing.Size(406, 20)
        Me.Ccolonia.TabIndex = 50
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(34, 169)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Colonia:"
        '
        'Ccp
        '
        Me.Ccp.ForeColor = System.Drawing.Color.Blue
        Me.Ccp.Location = New System.Drawing.Point(567, 244)
        Me.Ccp.MaxLength = 6
        Me.Ccp.Name = "Ccp"
        Me.Ccp.Size = New System.Drawing.Size(56, 20)
        Me.Ccp.TabIndex = 58
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(528, 247)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 13)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "C.P.:"
        '
        'Cpais
        '
        Me.Cpais.ForeColor = System.Drawing.Color.Blue
        Me.Cpais.Location = New System.Drawing.Point(217, 243)
        Me.Cpais.MaxLength = 60
        Me.Cpais.Name = "Cpais"
        Me.Cpais.Size = New System.Drawing.Size(304, 20)
        Me.Cpais.TabIndex = 56
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(34, 247)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "País:"
        '
        'Cestado
        '
        Me.Cestado.ForeColor = System.Drawing.Color.Blue
        Me.Cestado.Location = New System.Drawing.Point(217, 217)
        Me.Cestado.MaxLength = 60
        Me.Cestado.Name = "Cestado"
        Me.Cestado.Size = New System.Drawing.Size(406, 20)
        Me.Cestado.TabIndex = 54
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(34, 221)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 53
        Me.Label12.Text = "Estado:"
        '
        'Crfc
        '
        Me.Crfc.ForeColor = System.Drawing.Color.Blue
        Me.Crfc.Location = New System.Drawing.Point(217, 87)
        Me.Crfc.MaxLength = 13
        Me.Crfc.Name = "Crfc"
        Me.Crfc.Size = New System.Drawing.Size(113, 20)
        Me.Crfc.TabIndex = 42
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(34, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "R.F.C.:"
        '
        'Cmunicipio
        '
        Me.Cmunicipio.ForeColor = System.Drawing.Color.Blue
        Me.Cmunicipio.Location = New System.Drawing.Point(217, 191)
        Me.Cmunicipio.MaxLength = 60
        Me.Cmunicipio.Name = "Cmunicipio"
        Me.Cmunicipio.Size = New System.Drawing.Size(406, 20)
        Me.Cmunicipio.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(34, 195)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Deleg/Municipio:"
        '
        'Cnumint
        '
        Me.Cnumint.ForeColor = System.Drawing.Color.Blue
        Me.Cnumint.Location = New System.Drawing.Point(479, 139)
        Me.Cnumint.MaxLength = 40
        Me.Cnumint.Name = "Cnumint"
        Me.Cnumint.Size = New System.Drawing.Size(144, 20)
        Me.Cnumint.TabIndex = 48
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(400, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Número Int:"
        '
        'Cnumext
        '
        Me.Cnumext.ForeColor = System.Drawing.Color.Blue
        Me.Cnumext.Location = New System.Drawing.Point(217, 139)
        Me.Cnumext.MaxLength = 40
        Me.Cnumext.Name = "Cnumext"
        Me.Cnumext.Size = New System.Drawing.Size(144, 20)
        Me.Cnumext.TabIndex = 46
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(34, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Número Ext:"
        '
        'Ccalle
        '
        Me.Ccalle.ForeColor = System.Drawing.Color.Blue
        Me.Ccalle.Location = New System.Drawing.Point(217, 113)
        Me.Ccalle.MaxLength = 60
        Me.Ccalle.Name = "Ccalle"
        Me.Ccalle.Size = New System.Drawing.Size(406, 20)
        Me.Ccalle.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Calle:"
        '
        'Cnombrecte
        '
        Me.Cnombrecte.ForeColor = System.Drawing.Color.Blue
        Me.Cnombrecte.Location = New System.Drawing.Point(217, 35)
        Me.Cnombrecte.MaxLength = 200
        Me.Cnombrecte.Name = "Cnombrecte"
        Me.Cnombrecte.Size = New System.Drawing.Size(406, 20)
        Me.Cnombrecte.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Denominación/Razón Social:"
        '
        'Funcionarios
        '
        Me.Funcionarios.Controls.Add(Me.dgvFuncionarios)
        Me.Funcionarios.Location = New System.Drawing.Point(4, 22)
        Me.Funcionarios.Name = "Funcionarios"
        Me.Funcionarios.Padding = New System.Windows.Forms.Padding(3)
        Me.Funcionarios.Size = New System.Drawing.Size(679, 361)
        Me.Funcionarios.TabIndex = 3
        Me.Funcionarios.Text = "Funcionarios"
        Me.Funcionarios.UseVisualStyleBackColor = True
        '
        'dgvFuncionarios
        '
        Me.dgvFuncionarios.AllowUserToAddRows = False
        Me.dgvFuncionarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvFuncionarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFuncionarios.Location = New System.Drawing.Point(6, 11)
        Me.dgvFuncionarios.Name = "dgvFuncionarios"
        Me.dgvFuncionarios.Size = New System.Drawing.Size(667, 339)
        Me.dgvFuncionarios.TabIndex = 63
        '
        'Accionistas
        '
        Me.Accionistas.Controls.Add(Me.dgvAccionistas)
        Me.Accionistas.Location = New System.Drawing.Point(4, 22)
        Me.Accionistas.Name = "Accionistas"
        Me.Accionistas.Padding = New System.Windows.Forms.Padding(3)
        Me.Accionistas.Size = New System.Drawing.Size(679, 361)
        Me.Accionistas.TabIndex = 4
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
        Me.dgvAccionistas.Size = New System.Drawing.Size(670, 352)
        Me.dgvAccionistas.TabIndex = 66
        '
        'Riesgos
        '
        Me.Riesgos.Controls.Add(Me.gpBgc)
        Me.Riesgos.Controls.Add(Me.GBCC)
        Me.Riesgos.Location = New System.Drawing.Point(4, 22)
        Me.Riesgos.Name = "Riesgos"
        Me.Riesgos.Size = New System.Drawing.Size(679, 361)
        Me.Riesgos.TabIndex = 5
        Me.Riesgos.Text = "Calificación de riesgo"
        Me.Riesgos.UseVisualStyleBackColor = True
        '
        'gpBgc
        '
        Me.gpBgc.Controls.Add(Me.CmbNivel)
        Me.gpBgc.Controls.Add(Me.Label1)
        Me.gpBgc.Location = New System.Drawing.Point(101, 176)
        Me.gpBgc.Name = "gpBgc"
        Me.gpBgc.Size = New System.Drawing.Size(429, 129)
        Me.gpBgc.TabIndex = 405
        Me.gpBgc.TabStop = False
        Me.gpBgc.Text = "Back Ground Check"
        '
        'CmbNivel
        '
        Me.CmbNivel.FormattingEnabled = True
        Me.CmbNivel.Location = New System.Drawing.Point(9, 65)
        Me.CmbNivel.Name = "CmbNivel"
        Me.CmbNivel.Size = New System.Drawing.Size(212, 21)
        Me.CmbNivel.TabIndex = 369
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 368
        Me.Label1.Text = "Nivel de riesgo"
        '
        'GBCC
        '
        Me.GBCC.Controls.Add(Me.Label16)
        Me.GBCC.Controls.Add(Me.lblMotivo)
        Me.GBCC.Controls.Add(Me.rbSi)
        Me.GBCC.Controls.Add(Me.txtMotivoIndepen)
        Me.GBCC.Controls.Add(Me.rbNo)
        Me.GBCC.Location = New System.Drawing.Point(100, 25)
        Me.GBCC.Name = "GBCC"
        Me.GBCC.Size = New System.Drawing.Size(430, 129)
        Me.GBCC.TabIndex = 404
        Me.GBCC.TabStop = False
        Me.GBCC.Text = "Conflict Check"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(290, 13)
        Me.Label16.TabIndex = 367
        Me.Label16.Text = "¿Existe situación de conflicto de independencia ?"
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotivo.Location = New System.Drawing.Point(19, 70)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(123, 13)
        Me.lblMotivo.TabIndex = 369
        Me.lblMotivo.Text = "Motivo del conflicto:"
        '
        'rbSi
        '
        Me.rbSi.AutoSize = True
        Me.rbSi.Location = New System.Drawing.Point(51, 44)
        Me.rbSi.Name = "rbSi"
        Me.rbSi.Size = New System.Drawing.Size(36, 17)
        Me.rbSi.TabIndex = 365
        Me.rbSi.TabStop = True
        Me.rbSi.Text = "Si"
        Me.rbSi.UseVisualStyleBackColor = True
        '
        'txtMotivoIndepen
        '
        Me.txtMotivoIndepen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivoIndepen.ForeColor = System.Drawing.Color.Blue
        Me.txtMotivoIndepen.Location = New System.Drawing.Point(19, 97)
        Me.txtMotivoIndepen.MaxLength = 120
        Me.txtMotivoIndepen.Name = "txtMotivoIndepen"
        Me.txtMotivoIndepen.Size = New System.Drawing.Size(376, 20)
        Me.txtMotivoIndepen.TabIndex = 368
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Location = New System.Drawing.Point(112, 44)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(41, 17)
        Me.rbNo.TabIndex = 366
        Me.rbNo.TabStop = True
        Me.rbNo.Text = "No"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'gridClaves
        '
        Me.gridClaves.AllowUserToAddRows = False
        Me.gridClaves.AllowUserToDeleteRows = False
        Me.gridClaves.AllowUserToResizeColumns = False
        Me.gridClaves.AllowUserToResizeRows = False
        Me.gridClaves.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridClaves.BackgroundColor = System.Drawing.Color.White
        Me.gridClaves.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.gridClaves.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridClaves.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.gridClaves.ColumnHeadersHeight = 40
        Me.gridClaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridClaves.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridClaves.GridColor = System.Drawing.Color.Gainsboro
        Me.gridClaves.Location = New System.Drawing.Point(117, 26)
        Me.gridClaves.MultiSelect = False
        Me.gridClaves.Name = "gridClaves"
        Me.gridClaves.RowHeadersWidth = 25
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gridClaves.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gridClaves.RowTemplate.Height = 24
        Me.gridClaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridClaves.Size = New System.Drawing.Size(578, 217)
        Me.gridClaves.TabIndex = 324
        '
        'txtNombreCte
        '
        Me.txtNombreCte.Location = New System.Drawing.Point(117, 6)
        Me.txtNombreCte.Name = "txtNombreCte"
        Me.txtNombreCte.Size = New System.Drawing.Size(578, 20)
        Me.txtNombreCte.TabIndex = 323
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(7, 13)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(103, 13)
        Me.lblNombre.TabIndex = 322
        Me.lblNombre.Text = "Cliente Principal:"
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOficina.Location = New System.Drawing.Point(5, 40)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(106, 13)
        Me.lblOficina.TabIndex = 326
        Me.lblOficina.Text = "Oficina asignada:"
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivision.Location = New System.Drawing.Point(41, 73)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(69, 13)
        Me.lblDivision.TabIndex = 328
        Me.lblDivision.Text = "División(*):"
        '
        'cboOficina
        '
        Me.cboOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOficina.FormattingEnabled = True
        Me.cboOficina.Location = New System.Drawing.Point(117, 37)
        Me.cboOficina.Name = "cboOficina"
        Me.cboOficina.Size = New System.Drawing.Size(270, 21)
        Me.cboOficina.TabIndex = 327
        '
        'cboDivision
        '
        Me.cboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDivision.FormattingEnabled = True
        Me.cboDivision.Location = New System.Drawing.Point(116, 70)
        Me.cboDivision.Name = "cboDivision"
        Me.cboDivision.Size = New System.Drawing.Size(270, 21)
        Me.cboDivision.TabIndex = 329
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(604, 609)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(91, 36)
        Me.btnSalir.TabIndex = 330
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(16, 609)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(112, 36)
        Me.btnGuardar.TabIndex = 331
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Location = New System.Drawing.Point(275, 609)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(112, 36)
        Me.BtnCerrar.TabIndex = 332
        Me.BtnCerrar.Text = "Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = True
        Me.BtnCerrar.Visible = False
        '
        'txtGerente
        '
        Me.txtGerente.Enabled = False
        Me.txtGerente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGerente.ForeColor = System.Drawing.Color.Blue
        Me.txtGerente.Location = New System.Drawing.Point(116, 129)
        Me.txtGerente.MaxLength = 120
        Me.txtGerente.Name = "txtGerente"
        Me.txtGerente.Size = New System.Drawing.Size(270, 20)
        Me.txtGerente.TabIndex = 426
        '
        'txtSoc
        '
        Me.txtSoc.Enabled = False
        Me.txtSoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSoc.ForeColor = System.Drawing.Color.Blue
        Me.txtSoc.Location = New System.Drawing.Point(116, 99)
        Me.txtSoc.MaxLength = 120
        Me.txtSoc.Name = "txtSoc"
        Me.txtSoc.Size = New System.Drawing.Size(271, 20)
        Me.txtSoc.TabIndex = 425
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(1, 132)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(112, 13)
        Me.Label43.TabIndex = 424
        Me.Label43.Text = "Gerente Asignado:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(12, 102)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(98, 13)
        Me.Label31.TabIndex = 423
        Me.Label31.Text = "Socio asignado:"
        '
        'rbPSno
        '
        Me.rbPSno.AutoSize = True
        Me.rbPSno.Enabled = False
        Me.rbPSno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPSno.Location = New System.Drawing.Point(269, 170)
        Me.rbPSno.Name = "rbPSno"
        Me.rbPSno.Size = New System.Drawing.Size(43, 17)
        Me.rbPSno.TabIndex = 429
        Me.rbPSno.TabStop = True
        Me.rbPSno.Text = "NO"
        Me.rbPSno.UseVisualStyleBackColor = True
        '
        'rbPSsi
        '
        Me.rbPSsi.AutoSize = True
        Me.rbPSsi.Enabled = False
        Me.rbPSsi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPSsi.Location = New System.Drawing.Point(214, 170)
        Me.rbPSsi.Name = "rbPSsi"
        Me.rbPSsi.Size = New System.Drawing.Size(37, 17)
        Me.rbPSsi.TabIndex = 428
        Me.rbPSsi.TabStop = True
        Me.rbPSsi.Text = "SI"
        Me.rbPSsi.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 172)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(171, 13)
        Me.Label9.TabIndex = 427
        Me.Label9.Text = "Existe propuesta de servicio:"
        '
        'frmSAPYCAltaCteFiscales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 657)
        Me.Controls.Add(Me.gridClaves)
        Me.Controls.Add(Me.rbPSno)
        Me.Controls.Add(Me.rbPSsi)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtGerente)
        Me.Controls.Add(Me.txtSoc)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.cboDivision)
        Me.Controls.Add(Me.cboOficina)
        Me.Controls.Add(Me.lblDivision)
        Me.Controls.Add(Me.lblOficina)
        Me.Controls.Add(Me.txtNombreCte)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.Cuadro)
        Me.Name = "frmSAPYCAltaCteFiscales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ALTA CLIENTES FISCALES"
        Me.Cuadro.ResumeLayout(False)
        Me.Domicilio.ResumeLayout(False)
        Me.Domicilio.PerformLayout()
        Me.Funcionarios.ResumeLayout(False)
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Accionistas.ResumeLayout(False)
        CType(Me.dgvAccionistas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Riesgos.ResumeLayout(False)
        Me.gpBgc.ResumeLayout(False)
        Me.gpBgc.PerformLayout()
        Me.GBCC.ResumeLayout(False)
        Me.GBCC.PerformLayout()
        CType(Me.gridClaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Cuadro As TabControl
    Friend WithEvents Domicilio As TabPage
    Friend WithEvents Funcionarios As TabPage
    Friend WithEvents Accionistas As TabPage
    Friend WithEvents gridClaves As DataGridView
    Friend WithEvents txtNombreCte As TextBox
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblOficina As Label
    Friend WithEvents lblDivision As Label
    Friend WithEvents cboOficina As ComboBox
    Friend WithEvents cboDivision As ComboBox
    Friend WithEvents Cnombrecomercial As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents CBregimen As ComboBox
    Friend WithEvents Cregimen As Label
    Friend WithEvents Cemail As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Ccolonia As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Ccp As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Cpais As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Cestado As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Crfc As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Cmunicipio As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Cnumint As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Cnumext As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Ccalle As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Cnombrecte As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents BtnCerrar As Button
    Friend WithEvents Riesgos As TabPage
    Friend WithEvents gpBgc As GroupBox
    Friend WithEvents CmbNivel As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GBCC As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents lblMotivo As Label
    Friend WithEvents rbSi As RadioButton
    Friend WithEvents txtMotivoIndepen As TextBox
    Friend WithEvents rbNo As RadioButton
    Friend WithEvents txtGerente As TextBox
    Friend WithEvents txtSoc As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents dgvFuncionarios As DataGridView
    Friend WithEvents dgvAccionistas As DataGridView
    Friend WithEvents rbPSno As RadioButton
    Friend WithEvents rbPSsi As RadioButton
    Friend WithEvents Label9 As Label
End Class
