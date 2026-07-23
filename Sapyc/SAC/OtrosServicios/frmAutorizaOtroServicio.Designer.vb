<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAutorizaOtroServicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutorizaOtroServicio))
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.lblIdSac = New System.Windows.Forms.Label()
        Me.txtIdSac = New System.Windows.Forms.Label()
        Me.lblMotivoRechazo = New System.Windows.Forms.Label()
        Me.txtRechazo = New System.Windows.Forms.TextBox()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.txtDivision = New System.Windows.Forms.TextBox()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.txtOficina = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.txtDescripcionTrabajo = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnRechaza = New System.Windows.Forms.Button()
        Me.btnAutoriza = New System.Windows.Forms.Button()
        Me.txtSolicito = New System.Windows.Forms.TextBox()
        Me.panPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.txtSolicito)
        Me.panPrincipal.Controls.Add(Me.lblIdSac)
        Me.panPrincipal.Controls.Add(Me.txtIdSac)
        Me.panPrincipal.Controls.Add(Me.lblMotivoRechazo)
        Me.panPrincipal.Controls.Add(Me.txtRechazo)
        Me.panPrincipal.Controls.Add(Me.lblDivision)
        Me.panPrincipal.Controls.Add(Me.txtDivision)
        Me.panPrincipal.Controls.Add(Me.lblOficina)
        Me.panPrincipal.Controls.Add(Me.txtOficina)
        Me.panPrincipal.Controls.Add(Me.lblCliente)
        Me.panPrincipal.Controls.Add(Me.txtCliente)
        Me.panPrincipal.Controls.Add(Me.lblServicio)
        Me.panPrincipal.Controls.Add(Me.txtServicio)
        Me.panPrincipal.Controls.Add(Me.txtDescripcionTrabajo)
        Me.panPrincipal.Controls.Add(Me.lblDescripcion)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(845, 418)
        Me.panPrincipal.TabIndex = 2
        '
        'lblIdSac
        '
        Me.lblIdSac.AutoSize = True
        Me.lblIdSac.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSac.Location = New System.Drawing.Point(25, 56)
        Me.lblIdSac.Name = "lblIdSac"
        Me.lblIdSac.Size = New System.Drawing.Size(56, 18)
        Me.lblIdSac.TabIndex = 30
        Me.lblIdSac.Text = "ID. SAC:"
        '
        'txtIdSac
        '
        Me.txtIdSac.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtIdSac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdSac.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSac.ForeColor = System.Drawing.Color.SlateGray
        Me.txtIdSac.Location = New System.Drawing.Point(111, 53)
        Me.txtIdSac.Name = "txtIdSac"
        Me.txtIdSac.Size = New System.Drawing.Size(88, 25)
        Me.txtIdSac.TabIndex = 31
        Me.txtIdSac.Text = "000000"
        Me.txtIdSac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMotivoRechazo
        '
        Me.lblMotivoRechazo.AutoSize = True
        Me.lblMotivoRechazo.Location = New System.Drawing.Point(111, 292)
        Me.lblMotivoRechazo.Name = "lblMotivoRechazo"
        Me.lblMotivoRechazo.Size = New System.Drawing.Size(412, 18)
        Me.lblMotivoRechazo.TabIndex = 29
        Me.lblMotivoRechazo.Text = "En caso de rechazar la solicitud de servicio, especifique el motivo:"
        '
        'txtRechazo
        '
        Me.txtRechazo.Location = New System.Drawing.Point(111, 318)
        Me.txtRechazo.Multiline = True
        Me.txtRechazo.Name = "txtRechazo"
        Me.txtRechazo.Size = New System.Drawing.Size(689, 67)
        Me.txtRechazo.TabIndex = 28
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(432, 133)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(62, 18)
        Me.lblDivision.TabIndex = 27
        Me.lblDivision.Text = "División:"
        '
        'txtDivision
        '
        Me.txtDivision.Location = New System.Drawing.Point(503, 130)
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.ReadOnly = True
        Me.txtDivision.Size = New System.Drawing.Size(297, 25)
        Me.txtDivision.TabIndex = 24
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Location = New System.Drawing.Point(25, 133)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(55, 18)
        Me.lblOficina.TabIndex = 21
        Me.lblOficina.Text = "Oficina:"
        '
        'txtOficina
        '
        Me.txtOficina.Location = New System.Drawing.Point(111, 130)
        Me.txtOficina.Name = "txtOficina"
        Me.txtOficina.ReadOnly = True
        Me.txtOficina.Size = New System.Drawing.Size(297, 25)
        Me.txtOficina.TabIndex = 22
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(25, 97)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(57, 18)
        Me.lblCliente.TabIndex = 19
        Me.lblCliente.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(111, 94)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(689, 25)
        Me.txtCliente.TabIndex = 20
        '
        'lblServicio
        '
        Me.lblServicio.AutoSize = True
        Me.lblServicio.Location = New System.Drawing.Point(25, 171)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(61, 18)
        Me.lblServicio.TabIndex = 15
        Me.lblServicio.Text = "Servicio:"
        '
        'txtServicio
        '
        Me.txtServicio.Location = New System.Drawing.Point(111, 168)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.ReadOnly = True
        Me.txtServicio.Size = New System.Drawing.Size(689, 25)
        Me.txtServicio.TabIndex = 16
        '
        'txtDescripcionTrabajo
        '
        Me.txtDescripcionTrabajo.Location = New System.Drawing.Point(111, 209)
        Me.txtDescripcionTrabajo.Multiline = True
        Me.txtDescripcionTrabajo.Name = "txtDescripcionTrabajo"
        Me.txtDescripcionTrabajo.ReadOnly = True
        Me.txtDescripcionTrabajo.Size = New System.Drawing.Size(689, 67)
        Me.txtDescripcionTrabajo.TabIndex = 18
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(226, 60)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(58, 18)
        Me.lblDescripcion.TabIndex = 17
        Me.lblDescripcion.Text = "Solicito:"
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 36)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(845, 2)
        Me.panLinea.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(2, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(238, 32)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "DATOS DEL SERVICIO"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(700, 426)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(130, 25)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnRechaza
        '
        Me.btnRechaza.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRechaza.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRechaza.Location = New System.Drawing.Point(155, 426)
        Me.btnRechaza.Name = "btnRechaza"
        Me.btnRechaza.Size = New System.Drawing.Size(130, 25)
        Me.btnRechaza.TabIndex = 8
        Me.btnRechaza.Text = "Rechazar"
        Me.btnRechaza.UseVisualStyleBackColor = True
        '
        'btnAutoriza
        '
        Me.btnAutoriza.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAutoriza.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoriza.Location = New System.Drawing.Point(19, 426)
        Me.btnAutoriza.Name = "btnAutoriza"
        Me.btnAutoriza.Size = New System.Drawing.Size(130, 25)
        Me.btnAutoriza.TabIndex = 9
        Me.btnAutoriza.Text = "Autoriza"
        Me.btnAutoriza.UseVisualStyleBackColor = True
        '
        'txtSolicito
        '
        Me.txtSolicito.Location = New System.Drawing.Point(293, 53)
        Me.txtSolicito.Name = "txtSolicito"
        Me.txtSolicito.ReadOnly = True
        Me.txtSolicito.Size = New System.Drawing.Size(507, 25)
        Me.txtSolicito.TabIndex = 32
        '
        'frmAutorizaOtroServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(845, 460)
        Me.Controls.Add(Me.btnAutoriza)
        Me.Controls.Add(Me.btnRechaza)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAutorizaOtroServicio"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Revisar Solicitud de Otros Servicios"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblServicio As Label
    Friend WithEvents txtServicio As TextBox
    Friend WithEvents txtDescripcionTrabajo As TextBox
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents lblOficina As Label
    Friend WithEvents txtOficina As TextBox
    Friend WithEvents txtDivision As TextBox
    Friend WithEvents lblMotivoRechazo As Label
    Friend WithEvents txtRechazo As TextBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnRechaza As Button
    Friend WithEvents btnAutoriza As Button
    Friend WithEvents lblIdSac As Label
    Friend WithEvents txtIdSac As Label
    Friend WithEvents lblDivision As Label
    Friend WithEvents txtSolicito As TextBox
End Class
