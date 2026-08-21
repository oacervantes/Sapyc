<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgDetalleAusencia
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
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.txtProspecto = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.gpBoxAusencia = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescOtros = New System.Windows.Forms.TextBox()
        Me.txtInformacionAdicional = New System.Windows.Forms.TextBox()
        Me.panDisponibilidad = New System.Windows.Forms.Panel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.rdSinDisponibilidad = New System.Windows.Forms.RadioButton()
        Me.rdLimitada = New System.Windows.Forms.RadioButton()
        Me.rdCompleta = New System.Windows.Forms.RadioButton()
        Me.lblDisponibilidad = New System.Windows.Forms.Label()
        Me.lblFechaA = New System.Windows.Forms.Label()
        Me.lblInformacionAdicional = New System.Windows.Forms.Label()
        Me.txtFechaA = New System.Windows.Forms.DateTimePicker()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.txtFechaDe = New System.Windows.Forms.DateTimePicker()
        Me.lblMotivoAusencia = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.panPrincipal.SuspendLayout()
        Me.gpBoxAusencia.SuspendLayout()
        Me.panDisponibilidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.gpBoxAusencia)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.txtProspecto)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(672, 500)
        Me.panPrincipal.TabIndex = 0
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 29)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(672, 2)
        Me.panLinea.TabIndex = 1
        '
        'txtProspecto
        '
        Me.txtProspecto.AutoSize = True
        Me.txtProspecto.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProspecto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.txtProspecto.Location = New System.Drawing.Point(2, 2)
        Me.txtProspecto.Name = "txtProspecto"
        Me.txtProspecto.Size = New System.Drawing.Size(197, 24)
        Me.txtProspecto.TabIndex = 0
        Me.txtProspecto.Text = "DETALLE DE AUSENCIA"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(525, 507)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(135, 25)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'gpBoxAusencia
        '
        Me.gpBoxAusencia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpBoxAusencia.Controls.Add(Me.txtMotivo)
        Me.gpBoxAusencia.Controls.Add(Me.Label1)
        Me.gpBoxAusencia.Controls.Add(Me.txtDescOtros)
        Me.gpBoxAusencia.Controls.Add(Me.txtInformacionAdicional)
        Me.gpBoxAusencia.Controls.Add(Me.panDisponibilidad)
        Me.gpBoxAusencia.Controls.Add(Me.lblDisponibilidad)
        Me.gpBoxAusencia.Controls.Add(Me.lblFechaA)
        Me.gpBoxAusencia.Controls.Add(Me.lblInformacionAdicional)
        Me.gpBoxAusencia.Controls.Add(Me.txtFechaA)
        Me.gpBoxAusencia.Controls.Add(Me.lblPeriodo)
        Me.gpBoxAusencia.Controls.Add(Me.txtFechaDe)
        Me.gpBoxAusencia.Controls.Add(Me.lblMotivoAusencia)
        Me.gpBoxAusencia.Location = New System.Drawing.Point(11, 48)
        Me.gpBoxAusencia.Name = "gpBoxAusencia"
        Me.gpBoxAusencia.Size = New System.Drawing.Size(648, 430)
        Me.gpBoxAusencia.TabIndex = 2
        Me.gpBoxAusencia.TabStop = False
        Me.gpBoxAusencia.Text = "Datos de la Ausencia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Motivo de Otros:"
        '
        'txtDescOtros
        '
        Me.txtDescOtros.Enabled = False
        Me.txtDescOtros.Location = New System.Drawing.Point(186, 127)
        Me.txtDescOtros.Name = "txtDescOtros"
        Me.txtDescOtros.ReadOnly = True
        Me.txtDescOtros.Size = New System.Drawing.Size(445, 25)
        Me.txtDescOtros.TabIndex = 7
        '
        'txtInformacionAdicional
        '
        Me.txtInformacionAdicional.Location = New System.Drawing.Point(186, 322)
        Me.txtInformacionAdicional.Multiline = True
        Me.txtInformacionAdicional.Name = "txtInformacionAdicional"
        Me.txtInformacionAdicional.ReadOnly = True
        Me.txtInformacionAdicional.Size = New System.Drawing.Size(445, 82)
        Me.txtInformacionAdicional.TabIndex = 11
        '
        'panDisponibilidad
        '
        Me.panDisponibilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panDisponibilidad.Controls.Add(Me.lblInfo)
        Me.panDisponibilidad.Controls.Add(Me.rdSinDisponibilidad)
        Me.panDisponibilidad.Controls.Add(Me.rdLimitada)
        Me.panDisponibilidad.Controls.Add(Me.rdCompleta)
        Me.panDisponibilidad.Enabled = False
        Me.panDisponibilidad.Location = New System.Drawing.Point(186, 171)
        Me.panDisponibilidad.Name = "panDisponibilidad"
        Me.panDisponibilidad.Size = New System.Drawing.Size(445, 132)
        Me.panDisponibilidad.TabIndex = 9
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblInfo.ForeColor = System.Drawing.Color.White
        Me.lblInfo.Image = Global.Sapyc.My.Resources.Resources.pregunta_azul
        Me.lblInfo.Location = New System.Drawing.Point(404, 9)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(27, 25)
        Me.lblInfo.TabIndex = 3
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdSinDisponibilidad
        '
        Me.rdSinDisponibilidad.AutoSize = True
        Me.rdSinDisponibilidad.Location = New System.Drawing.Point(34, 90)
        Me.rdSinDisponibilidad.Name = "rdSinDisponibilidad"
        Me.rdSinDisponibilidad.Size = New System.Drawing.Size(137, 22)
        Me.rdSinDisponibilidad.TabIndex = 2
        Me.rdSinDisponibilidad.TabStop = True
        Me.rdSinDisponibilidad.Text = "Sin disponibilidad"
        Me.rdSinDisponibilidad.UseVisualStyleBackColor = True
        '
        'rdLimitada
        '
        Me.rdLimitada.AutoSize = True
        Me.rdLimitada.Location = New System.Drawing.Point(34, 54)
        Me.rdLimitada.Name = "rdLimitada"
        Me.rdLimitada.Size = New System.Drawing.Size(79, 22)
        Me.rdLimitada.TabIndex = 1
        Me.rdLimitada.TabStop = True
        Me.rdLimitada.Text = "Limitada"
        Me.rdLimitada.UseVisualStyleBackColor = True
        '
        'rdCompleta
        '
        Me.rdCompleta.AutoSize = True
        Me.rdCompleta.Location = New System.Drawing.Point(34, 18)
        Me.rdCompleta.Name = "rdCompleta"
        Me.rdCompleta.Size = New System.Drawing.Size(86, 22)
        Me.rdCompleta.TabIndex = 0
        Me.rdCompleta.TabStop = True
        Me.rdCompleta.Text = "Completa"
        Me.rdCompleta.UseVisualStyleBackColor = True
        '
        'lblDisponibilidad
        '
        Me.lblDisponibilidad.AutoSize = True
        Me.lblDisponibilidad.Location = New System.Drawing.Point(62, 171)
        Me.lblDisponibilidad.Name = "lblDisponibilidad"
        Me.lblDisponibilidad.Size = New System.Drawing.Size(102, 18)
        Me.lblDisponibilidad.TabIndex = 8
        Me.lblDisponibilidad.Text = "Disponibilidad:"
        '
        'lblFechaA
        '
        Me.lblFechaA.AutoSize = True
        Me.lblFechaA.Location = New System.Drawing.Point(312, 42)
        Me.lblFechaA.Name = "lblFechaA"
        Me.lblFechaA.Size = New System.Drawing.Size(19, 18)
        Me.lblFechaA.TabIndex = 2
        Me.lblFechaA.Text = "al"
        '
        'lblInformacionAdicional
        '
        Me.lblInformacionAdicional.AutoSize = True
        Me.lblInformacionAdicional.Location = New System.Drawing.Point(16, 322)
        Me.lblInformacionAdicional.Name = "lblInformacionAdicional"
        Me.lblInformacionAdicional.Size = New System.Drawing.Size(148, 18)
        Me.lblInformacionAdicional.TabIndex = 10
        Me.lblInformacionAdicional.Text = "Información Adicional:"
        '
        'txtFechaA
        '
        Me.txtFechaA.Enabled = False
        Me.txtFechaA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaA.Location = New System.Drawing.Point(337, 39)
        Me.txtFechaA.Name = "txtFechaA"
        Me.txtFechaA.Size = New System.Drawing.Size(120, 25)
        Me.txtFechaA.TabIndex = 3
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(103, 42)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(61, 18)
        Me.lblPeriodo.TabIndex = 0
        Me.lblPeriodo.Text = "Periodo:"
        '
        'txtFechaDe
        '
        Me.txtFechaDe.Enabled = False
        Me.txtFechaDe.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaDe.Location = New System.Drawing.Point(186, 39)
        Me.txtFechaDe.Name = "txtFechaDe"
        Me.txtFechaDe.Size = New System.Drawing.Size(120, 25)
        Me.txtFechaDe.TabIndex = 1
        '
        'lblMotivoAusencia
        '
        Me.lblMotivoAusencia.AutoSize = True
        Me.lblMotivoAusencia.Location = New System.Drawing.Point(107, 86)
        Me.lblMotivoAusencia.Name = "lblMotivoAusencia"
        Me.lblMotivoAusencia.Size = New System.Drawing.Size(57, 18)
        Me.lblMotivoAusencia.TabIndex = 4
        Me.lblMotivoAusencia.Text = "Motivo:"
        '
        'txtMotivo
        '
        Me.txtMotivo.Enabled = False
        Me.txtMotivo.Location = New System.Drawing.Point(186, 83)
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.ReadOnly = True
        Me.txtMotivo.Size = New System.Drawing.Size(445, 25)
        Me.txtMotivo.TabIndex = 12
        '
        'DlgDetalleAusencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 539)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgDetalleAusencia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle de Ausencia"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.gpBoxAusencia.ResumeLayout(False)
        Me.gpBoxAusencia.PerformLayout()
        Me.panDisponibilidad.ResumeLayout(False)
        Me.panDisponibilidad.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents panLinea As Panel
    Friend WithEvents txtProspecto As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents gpBoxAusencia As GroupBox
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescOtros As TextBox
    Friend WithEvents txtInformacionAdicional As TextBox
    Friend WithEvents panDisponibilidad As Panel
    Friend WithEvents lblInfo As Label
    Friend WithEvents rdSinDisponibilidad As RadioButton
    Friend WithEvents rdLimitada As RadioButton
    Friend WithEvents rdCompleta As RadioButton
    Friend WithEvents lblDisponibilidad As Label
    Friend WithEvents lblFechaA As Label
    Friend WithEvents lblInformacionAdicional As Label
    Friend WithEvents txtFechaA As DateTimePicker
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents txtFechaDe As DateTimePicker
    Friend WithEvents lblMotivoAusencia As Label
End Class
