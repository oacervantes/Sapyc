<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgSolicitudAsignacion
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
        Me.btnRechazarAsignacion = New System.Windows.Forms.Button()
        Me.btnEnviarAsignacion = New System.Windows.Forms.Button()
        Me.lblMensajeAut = New System.Windows.Forms.Label()
        Me.lblTituloProspecto = New System.Windows.Forms.Label()
        Me.lblTituloSocios = New System.Windows.Forms.Label()
        Me.panSocios = New System.Windows.Forms.Panel()
        Me.panSolicitud = New System.Windows.Forms.Panel()
        Me.btnDetalle = New System.Windows.Forms.Button()
        Me.lblIdSac = New System.Windows.Forms.Label()
        Me.txtIdSac = New System.Windows.Forms.Label()
        Me.lblSocioEncargado = New System.Windows.Forms.Label()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.txtDivision = New System.Windows.Forms.Label()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.txtOficina = New System.Windows.Forms.Label()
        Me.txtSocioEncargado = New System.Windows.Forms.Label()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.lblProspecto = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.panSolicitud.SuspendLayout()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.btnRechazarAsignacion)
        Me.panPrincipal.Controls.Add(Me.btnEnviarAsignacion)
        Me.panPrincipal.Controls.Add(Me.lblMensajeAut)
        Me.panPrincipal.Controls.Add(Me.lblTituloProspecto)
        Me.panPrincipal.Controls.Add(Me.lblTituloSocios)
        Me.panPrincipal.Controls.Add(Me.panSocios)
        Me.panPrincipal.Controls.Add(Me.panSolicitud)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1127, 699)
        Me.panPrincipal.TabIndex = 0
        '
        'btnRechazarAsignacion
        '
        Me.btnRechazarAsignacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRechazarAsignacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnRechazarAsignacion.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnRechazarAsignacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral
        Me.btnRechazarAsignacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnRechazarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRechazarAsignacion.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRechazarAsignacion.ForeColor = System.Drawing.Color.White
        Me.btnRechazarAsignacion.Location = New System.Drawing.Point(195, 661)
        Me.btnRechazarAsignacion.Name = "btnRechazarAsignacion"
        Me.btnRechazarAsignacion.Size = New System.Drawing.Size(170, 27)
        Me.btnRechazarAsignacion.TabIndex = 26
        Me.btnRechazarAsignacion.Text = "Rechazar asignación"
        Me.btnRechazarAsignacion.UseVisualStyleBackColor = False
        '
        'btnEnviarAsignacion
        '
        Me.btnEnviarAsignacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEnviarAsignacion.BackColor = System.Drawing.Color.SeaGreen
        Me.btnEnviarAsignacion.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEnviarAsignacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnEnviarAsignacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen
        Me.btnEnviarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviarAsignacion.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviarAsignacion.ForeColor = System.Drawing.Color.White
        Me.btnEnviarAsignacion.Location = New System.Drawing.Point(18, 661)
        Me.btnEnviarAsignacion.Name = "btnEnviarAsignacion"
        Me.btnEnviarAsignacion.Size = New System.Drawing.Size(170, 27)
        Me.btnEnviarAsignacion.TabIndex = 25
        Me.btnEnviarAsignacion.Text = "Enviar asignación"
        Me.btnEnviarAsignacion.UseVisualStyleBackColor = False
        '
        'lblMensajeAut
        '
        Me.lblMensajeAut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMensajeAut.AutoSize = True
        Me.lblMensajeAut.Font = New System.Drawing.Font("Calibri", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeAut.ForeColor = System.Drawing.Color.DarkRed
        Me.lblMensajeAut.Location = New System.Drawing.Point(18, 637)
        Me.lblMensajeAut.Name = "lblMensajeAut"
        Me.lblMensajeAut.Size = New System.Drawing.Size(911, 18)
        Me.lblMensajeAut.TabIndex = 17
        Me.lblMensajeAut.Text = "A nombre del Socio Director otorgo el Vo. Bo. de la asignación del socio responsa" &
    "ble para la preparación y presentación de la propuesta de servicio."
        '
        'lblTituloProspecto
        '
        Me.lblTituloProspecto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTituloProspecto.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTituloProspecto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTituloProspecto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloProspecto.ForeColor = System.Drawing.Color.White
        Me.lblTituloProspecto.Location = New System.Drawing.Point(18, 10)
        Me.lblTituloProspecto.Name = "lblTituloProspecto"
        Me.lblTituloProspecto.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.lblTituloProspecto.Size = New System.Drawing.Size(1089, 23)
        Me.lblTituloProspecto.TabIndex = 16
        Me.lblTituloProspecto.Text = "Datos del Prospecto"
        Me.lblTituloProspecto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTituloSocios
        '
        Me.lblTituloSocios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTituloSocios.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.lblTituloSocios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTituloSocios.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloSocios.ForeColor = System.Drawing.Color.White
        Me.lblTituloSocios.Location = New System.Drawing.Point(18, 144)
        Me.lblTituloSocios.Name = "lblTituloSocios"
        Me.lblTituloSocios.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.lblTituloSocios.Size = New System.Drawing.Size(1089, 23)
        Me.lblTituloSocios.TabIndex = 12
        Me.lblTituloSocios.Text = "Seleccionar socio"
        Me.lblTituloSocios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panSocios
        '
        Me.panSocios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panSocios.AutoScroll = True
        Me.panSocios.AutoScrollMargin = New System.Drawing.Size(0, 20)
        Me.panSocios.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panSocios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panSocios.Location = New System.Drawing.Point(18, 166)
        Me.panSocios.Name = "panSocios"
        Me.panSocios.Size = New System.Drawing.Size(1089, 464)
        Me.panSocios.TabIndex = 2
        '
        'panSolicitud
        '
        Me.panSolicitud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panSolicitud.Controls.Add(Me.btnDetalle)
        Me.panSolicitud.Controls.Add(Me.lblIdSac)
        Me.panSolicitud.Controls.Add(Me.txtIdSac)
        Me.panSolicitud.Controls.Add(Me.lblSocioEncargado)
        Me.panSolicitud.Controls.Add(Me.lblDivision)
        Me.panSolicitud.Controls.Add(Me.txtDivision)
        Me.panSolicitud.Controls.Add(Me.lblOficina)
        Me.panSolicitud.Controls.Add(Me.txtOficina)
        Me.panSolicitud.Controls.Add(Me.txtSocioEncargado)
        Me.panSolicitud.Controls.Add(Me.lblServicio)
        Me.panSolicitud.Controls.Add(Me.lblProspecto)
        Me.panSolicitud.Location = New System.Drawing.Point(18, 10)
        Me.panSolicitud.Name = "panSolicitud"
        Me.panSolicitud.Size = New System.Drawing.Size(1089, 120)
        Me.panSolicitud.TabIndex = 0
        '
        'btnDetalle
        '
        Me.btnDetalle.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDetalle.Location = New System.Drawing.Point(931, 87)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(135, 25)
        Me.btnDetalle.TabIndex = 24
        Me.btnDetalle.Text = "Ver Detalle"
        Me.btnDetalle.UseVisualStyleBackColor = True
        '
        'lblIdSac
        '
        Me.lblIdSac.AutoSize = True
        Me.lblIdSac.Font = New System.Drawing.Font("Calibri", 12.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSac.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblIdSac.Location = New System.Drawing.Point(909, 34)
        Me.lblIdSac.Name = "lblIdSac"
        Me.lblIdSac.Size = New System.Drawing.Size(67, 21)
        Me.lblIdSac.TabIndex = 23
        Me.lblIdSac.Text = "ID. SAC:"
        '
        'txtIdSac
        '
        Me.txtIdSac.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtIdSac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdSac.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSac.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.txtIdSac.Location = New System.Drawing.Point(978, 32)
        Me.txtIdSac.Name = "txtIdSac"
        Me.txtIdSac.Size = New System.Drawing.Size(88, 25)
        Me.txtIdSac.TabIndex = 22
        Me.txtIdSac.Text = "000000"
        Me.txtIdSac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSocioEncargado
        '
        Me.lblSocioEncargado.AutoSize = True
        Me.lblSocioEncargado.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSocioEncargado.ForeColor = System.Drawing.Color.Black
        Me.lblSocioEncargado.Location = New System.Drawing.Point(326, 90)
        Me.lblSocioEncargado.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSocioEncargado.Name = "lblSocioEncargado"
        Me.lblSocioEncargado.Size = New System.Drawing.Size(194, 18)
        Me.lblSocioEncargado.TabIndex = 21
        Me.lblSocioEncargado.Text = "SOCIO DE OFICINA / DIVISIÓN:"
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivision.ForeColor = System.Drawing.Color.Black
        Me.lblDivision.Location = New System.Drawing.Point(165, 90)
        Me.lblDivision.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(69, 18)
        Me.lblDivision.TabIndex = 20
        Me.lblDivision.Text = "DIVISIÓN:"
        '
        'txtDivision
        '
        Me.txtDivision.AutoSize = True
        Me.txtDivision.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDivision.Location = New System.Drawing.Point(236, 90)
        Me.txtDivision.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.Size = New System.Drawing.Size(75, 18)
        Me.txtDivision.TabIndex = 19
        Me.txtDivision.Text = "[DIVISION]"
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOficina.ForeColor = System.Drawing.Color.Black
        Me.lblOficina.Location = New System.Drawing.Point(21, 90)
        Me.lblOficina.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(64, 18)
        Me.lblOficina.TabIndex = 18
        Me.lblOficina.Text = "OFICINA:"
        '
        'txtOficina
        '
        Me.txtOficina.AutoSize = True
        Me.txtOficina.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOficina.Location = New System.Drawing.Point(87, 90)
        Me.txtOficina.Margin = New System.Windows.Forms.Padding(0)
        Me.txtOficina.Name = "txtOficina"
        Me.txtOficina.Size = New System.Drawing.Size(70, 18)
        Me.txtOficina.TabIndex = 17
        Me.txtOficina.Text = "[OFICINA]"
        '
        'txtSocioEncargado
        '
        Me.txtSocioEncargado.AutoSize = True
        Me.txtSocioEncargado.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSocioEncargado.Location = New System.Drawing.Point(522, 90)
        Me.txtSocioEncargado.Name = "txtSocioEncargado"
        Me.txtSocioEncargado.Size = New System.Drawing.Size(139, 18)
        Me.txtSocioEncargado.TabIndex = 2
        Me.txtSocioEncargado.Text = "[SOCIO ENCARGADO]"
        '
        'lblServicio
        '
        Me.lblServicio.AutoSize = True
        Me.lblServicio.Font = New System.Drawing.Font("Calibri", 12.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServicio.Location = New System.Drawing.Point(21, 62)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(89, 21)
        Me.lblServicio.TabIndex = 1
        Me.lblServicio.Text = "[SERVICIO]"
        '
        'lblProspecto
        '
        Me.lblProspecto.AutoSize = True
        Me.lblProspecto.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProspecto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblProspecto.Location = New System.Drawing.Point(21, 32)
        Me.lblProspecto.Name = "lblProspecto"
        Me.lblProspecto.Size = New System.Drawing.Size(115, 23)
        Me.lblProspecto.TabIndex = 0
        Me.lblProspecto.Text = "[PROSPECTO]"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(985, 704)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(130, 25)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'DlgSolicitudAsignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1127, 735)
        Me.Controls.Add(Me.panPrincipal)
        Me.Controls.Add(Me.btnCerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgSolicitudAsignacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Asignar socio a prospecto"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.panSolicitud.ResumeLayout(False)
        Me.panSolicitud.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents panSolicitud As Panel
    Friend WithEvents panSocios As Panel
    Friend WithEvents lblTituloProspecto As Label
    Friend WithEvents lblTituloSocios As Label
    Friend WithEvents lblProspecto As Label
    Friend WithEvents lblServicio As Label
    Friend WithEvents txtSocioEncargado As Label
    Friend WithEvents lblDivision As Label
    Friend WithEvents txtDivision As Label
    Friend WithEvents lblOficina As Label
    Friend WithEvents txtOficina As Label
    Friend WithEvents lblSocioEncargado As Label
    Friend WithEvents lblIdSac As Label
    Friend WithEvents txtIdSac As Label
    Friend WithEvents btnDetalle As Button
    Friend WithEvents lblMensajeAut As Label
    Friend WithEvents btnEnviarAsignacion As Button
    Friend WithEvents btnRechazarAsignacion As Button
End Class
