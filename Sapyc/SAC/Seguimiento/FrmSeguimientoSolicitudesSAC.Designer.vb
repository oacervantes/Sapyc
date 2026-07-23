<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeguimientoSolicitudesSAC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSeguimientoSolicitudesSAC))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.panFiltro = New System.Windows.Forms.Panel()
        Me.rdSolicitudTodo = New System.Windows.Forms.RadioButton()
        Me.rdSolicitudCancelada = New System.Windows.Forms.RadioButton()
        Me.rdSolicitudBG = New System.Windows.Forms.RadioButton()
        Me.rdSolicitudCompleta = New System.Windows.Forms.RadioButton()
        Me.rdSolicitudValidar = New System.Windows.Forms.RadioButton()
        Me.rdSolicitudReasigna = New System.Windows.Forms.RadioButton()
        Me.rdSolicitudOtros = New System.Windows.Forms.RadioButton()
        Me.rdSolicitudAsigna = New System.Windows.Forms.RadioButton()
        Me.txtProspecto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.gridProspectos = New System.Windows.Forms.DataGridView()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.panFiltro.SuspendLayout()
        CType(Me.gridProspectos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(1061, 675)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(130, 25)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.panFiltro)
        Me.panPrincipal.Controls.Add(Me.txtProspecto)
        Me.panPrincipal.Controls.Add(Me.Label1)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Controls.Add(Me.gridProspectos)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1203, 667)
        Me.panPrincipal.TabIndex = 0
        '
        'panFiltro
        '
        Me.panFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panFiltro.Controls.Add(Me.rdSolicitudTodo)
        Me.panFiltro.Controls.Add(Me.rdSolicitudCancelada)
        Me.panFiltro.Controls.Add(Me.rdSolicitudBG)
        Me.panFiltro.Controls.Add(Me.rdSolicitudCompleta)
        Me.panFiltro.Controls.Add(Me.rdSolicitudValidar)
        Me.panFiltro.Controls.Add(Me.rdSolicitudReasigna)
        Me.panFiltro.Controls.Add(Me.rdSolicitudOtros)
        Me.panFiltro.Controls.Add(Me.rdSolicitudAsigna)
        Me.panFiltro.Location = New System.Drawing.Point(126, 84)
        Me.panFiltro.Name = "panFiltro"
        Me.panFiltro.Size = New System.Drawing.Size(949, 71)
        Me.panFiltro.TabIndex = 4
        '
        'rdSolicitudTodo
        '
        Me.rdSolicitudTodo.AutoSize = True
        Me.rdSolicitudTodo.Location = New System.Drawing.Point(56, 9)
        Me.rdSolicitudTodo.Name = "rdSolicitudTodo"
        Me.rdSolicitudTodo.Size = New System.Drawing.Size(151, 22)
        Me.rdSolicitudTodo.TabIndex = 0
        Me.rdSolicitudTodo.TabStop = True
        Me.rdSolicitudTodo.Text = "Todas las solicitudes"
        Me.rdSolicitudTodo.UseVisualStyleBackColor = True
        '
        'rdSolicitudCancelada
        '
        Me.rdSolicitudCancelada.AutoSize = True
        Me.rdSolicitudCancelada.Location = New System.Drawing.Point(527, 39)
        Me.rdSolicitudCancelada.Name = "rdSolicitudCancelada"
        Me.rdSolicitudCancelada.Size = New System.Drawing.Size(166, 22)
        Me.rdSolicitudCancelada.TabIndex = 6
        Me.rdSolicitudCancelada.TabStop = True
        Me.rdSolicitudCancelada.Text = "Solicitudes Canceladas"
        Me.rdSolicitudCancelada.UseVisualStyleBackColor = True
        '
        'rdSolicitudBG
        '
        Me.rdSolicitudBG.AutoSize = True
        Me.rdSolicitudBG.Location = New System.Drawing.Point(56, 39)
        Me.rdSolicitudBG.Name = "rdSolicitudBG"
        Me.rdSolicitudBG.Size = New System.Drawing.Size(263, 22)
        Me.rdSolicitudBG.TabIndex = 4
        Me.rdSolicitudBG.TabStop = True
        Me.rdSolicitudBG.Text = "Solicitudes en Revisión de Background"
        Me.rdSolicitudBG.UseVisualStyleBackColor = True
        '
        'rdSolicitudCompleta
        '
        Me.rdSolicitudCompleta.AutoSize = True
        Me.rdSolicitudCompleta.Location = New System.Drawing.Point(715, 39)
        Me.rdSolicitudCompleta.Name = "rdSolicitudCompleta"
        Me.rdSolicitudCompleta.Size = New System.Drawing.Size(178, 22)
        Me.rdSolicitudCompleta.TabIndex = 7
        Me.rdSolicitudCompleta.TabStop = True
        Me.rdSolicitudCompleta.Text = "Solicitudes Completadas"
        Me.rdSolicitudCompleta.UseVisualStyleBackColor = True
        '
        'rdSolicitudValidar
        '
        Me.rdSolicitudValidar.AutoSize = True
        Me.rdSolicitudValidar.Location = New System.Drawing.Point(341, 39)
        Me.rdSolicitudValidar.Name = "rdSolicitudValidar"
        Me.rdSolicitudValidar.Size = New System.Drawing.Size(164, 22)
        Me.rdSolicitudValidar.TabIndex = 5
        Me.rdSolicitudValidar.TabStop = True
        Me.rdSolicitudValidar.Text = "Solicitudes por Validar"
        Me.rdSolicitudValidar.UseVisualStyleBackColor = True
        '
        'rdSolicitudReasigna
        '
        Me.rdSolicitudReasigna.AutoSize = True
        Me.rdSolicitudReasigna.Location = New System.Drawing.Point(418, 9)
        Me.rdSolicitudReasigna.Name = "rdSolicitudReasigna"
        Me.rdSolicitudReasigna.Size = New System.Drawing.Size(181, 22)
        Me.rdSolicitudReasigna.TabIndex = 2
        Me.rdSolicitudReasigna.TabStop = True
        Me.rdSolicitudReasigna.Text = "Solicitudes por Reasignar"
        Me.rdSolicitudReasigna.UseVisualStyleBackColor = True
        '
        'rdSolicitudOtros
        '
        Me.rdSolicitudOtros.AutoSize = True
        Me.rdSolicitudOtros.Location = New System.Drawing.Point(621, 9)
        Me.rdSolicitudOtros.Name = "rdSolicitudOtros"
        Me.rdSolicitudOtros.Size = New System.Drawing.Size(245, 22)
        Me.rdSolicitudOtros.TabIndex = 3
        Me.rdSolicitudOtros.TabStop = True
        Me.rdSolicitudOtros.Text = "Solicitudes por Revisión de Servicio"
        Me.rdSolicitudOtros.UseVisualStyleBackColor = True
        '
        'rdSolicitudAsigna
        '
        Me.rdSolicitudAsigna.AutoSize = True
        Me.rdSolicitudAsigna.Location = New System.Drawing.Point(229, 9)
        Me.rdSolicitudAsigna.Name = "rdSolicitudAsigna"
        Me.rdSolicitudAsigna.Size = New System.Drawing.Size(167, 22)
        Me.rdSolicitudAsigna.TabIndex = 1
        Me.rdSolicitudAsigna.TabStop = True
        Me.rdSolicitudAsigna.Text = "Solicitudes por Asignar"
        Me.rdSolicitudAsigna.UseVisualStyleBackColor = True
        '
        'txtProspecto
        '
        Me.txtProspecto.ForeColor = System.Drawing.Color.Silver
        Me.txtProspecto.Location = New System.Drawing.Point(112, 48)
        Me.txtProspecto.Name = "txtProspecto"
        Me.txtProspecto.Size = New System.Drawing.Size(1057, 25)
        Me.txtProspecto.TabIndex = 3
        Me.txtProspecto.Text = "Nombre..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Prospecto:"
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 36)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(1203, 2)
        Me.panLinea.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(2, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(534, 32)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "SEGUIMIENTO DE SOLICITUDES DE PROSPECTOS"
        '
        'gridProspectos
        '
        Me.gridProspectos.AllowUserToAddRows = False
        Me.gridProspectos.AllowUserToDeleteRows = False
        Me.gridProspectos.AllowUserToResizeRows = False
        Me.gridProspectos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridProspectos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.gridProspectos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.gridProspectos.ColumnHeadersHeight = 65
        Me.gridProspectos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridProspectos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.gridProspectos.Location = New System.Drawing.Point(11, 166)
        Me.gridProspectos.MultiSelect = False
        Me.gridProspectos.Name = "gridProspectos"
        Me.gridProspectos.RowHeadersWidth = 25
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gridProspectos.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridProspectos.RowTemplate.Height = 25
        Me.gridProspectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridProspectos.Size = New System.Drawing.Size(1179, 485)
        Me.gridProspectos.TabIndex = 5
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(12, 675)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(130, 25)
        Me.btnExportar.TabIndex = 7
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'FrmSeguimientoSolicitudesSAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1203, 710)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSeguimientoSolicitudesSAC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguimiento de Solicitudes de Prospectos"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.panFiltro.ResumeLayout(False)
        Me.panFiltro.PerformLayout()
        CType(Me.gridProspectos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSalir As Button
    Friend WithEvents panPrincipal As Panel
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents gridProspectos As DataGridView
    Friend WithEvents panFiltro As Panel
    Friend WithEvents rdSolicitudValidar As RadioButton
    Friend WithEvents rdSolicitudReasigna As RadioButton
    Friend WithEvents rdSolicitudOtros As RadioButton
    Friend WithEvents rdSolicitudAsigna As RadioButton
    Friend WithEvents txtProspecto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rdSolicitudCancelada As RadioButton
    Friend WithEvents rdSolicitudBG As RadioButton
    Friend WithEvents rdSolicitudCompleta As RadioButton
    Friend WithEvents rdSolicitudTodo As RadioButton
    Friend WithEvents btnExportar As Button
End Class
