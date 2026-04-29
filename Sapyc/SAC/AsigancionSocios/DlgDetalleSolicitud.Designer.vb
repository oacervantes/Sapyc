<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgDetalleSolicitud
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
        Me.panSolicitud = New System.Windows.Forms.Panel()
        Me.lblNivelRiesgo = New System.Windows.Forms.Label()
        Me.txtNivelRiesgo = New System.Windows.Forms.Label()
        Me.lblMotivoRechazo = New System.Windows.Forms.Label()
        Me.txtMotivoRechazo = New System.Windows.Forms.Label()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblIdSac = New System.Windows.Forms.Label()
        Me.txtIdSac = New System.Windows.Forms.Label()
        Me.lblIndustria = New System.Windows.Forms.Label()
        Me.txtIndustria = New System.Windows.Forms.Label()
        Me.lblIdioma = New System.Windows.Forms.Label()
        Me.txtIdioma = New System.Windows.Forms.Label()
        Me.lblSocioEncargado = New System.Windows.Forms.Label()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.txtDivision = New System.Windows.Forms.Label()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.txtOficina = New System.Windows.Forms.Label()
        Me.txtSocioEncargado = New System.Windows.Forms.Label()
        Me.txtServicio = New System.Windows.Forms.Label()
        Me.txtProspecto = New System.Windows.Forms.Label()
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
        Me.panPrincipal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.panSolicitud)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(674, 571)
        Me.panPrincipal.TabIndex = 0
        '
        'panSolicitud
        '
        Me.panSolicitud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panSolicitud.BackColor = System.Drawing.Color.White
        Me.panSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panSolicitud.Controls.Add(Me.lblNivelRiesgo)
        Me.panSolicitud.Controls.Add(Me.txtNivelRiesgo)
        Me.panSolicitud.Controls.Add(Me.lblMotivoRechazo)
        Me.panSolicitud.Controls.Add(Me.txtMotivoRechazo)
        Me.panSolicitud.Controls.Add(Me.panLinea)
        Me.panSolicitud.Controls.Add(Me.lblIdSac)
        Me.panSolicitud.Controls.Add(Me.txtIdSac)
        Me.panSolicitud.Controls.Add(Me.lblIndustria)
        Me.panSolicitud.Controls.Add(Me.txtIndustria)
        Me.panSolicitud.Controls.Add(Me.lblIdioma)
        Me.panSolicitud.Controls.Add(Me.txtIdioma)
        Me.panSolicitud.Controls.Add(Me.lblSocioEncargado)
        Me.panSolicitud.Controls.Add(Me.lblDivision)
        Me.panSolicitud.Controls.Add(Me.txtDivision)
        Me.panSolicitud.Controls.Add(Me.lblOficina)
        Me.panSolicitud.Controls.Add(Me.txtOficina)
        Me.panSolicitud.Controls.Add(Me.txtSocioEncargado)
        Me.panSolicitud.Controls.Add(Me.txtServicio)
        Me.panSolicitud.Controls.Add(Me.txtProspecto)
        Me.panSolicitud.Location = New System.Drawing.Point(11, 14)
        Me.panSolicitud.Name = "panSolicitud"
        Me.panSolicitud.Size = New System.Drawing.Size(650, 541)
        Me.panSolicitud.TabIndex = 0
        '
        'lblNivelRiesgo
        '
        Me.lblNivelRiesgo.AutoSize = True
        Me.lblNivelRiesgo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNivelRiesgo.ForeColor = System.Drawing.Color.Black
        Me.lblNivelRiesgo.Location = New System.Drawing.Point(11, 260)
        Me.lblNivelRiesgo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNivelRiesgo.Name = "lblNivelRiesgo"
        Me.lblNivelRiesgo.Size = New System.Drawing.Size(116, 18)
        Me.lblNivelRiesgo.TabIndex = 15
        Me.lblNivelRiesgo.Text = "NIVEL DE RIESGO:"
        '
        'txtNivelRiesgo
        '
        Me.txtNivelRiesgo.AutoSize = True
        Me.txtNivelRiesgo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNivelRiesgo.Location = New System.Drawing.Point(209, 260)
        Me.txtNivelRiesgo.Name = "txtNivelRiesgo"
        Me.txtNivelRiesgo.Size = New System.Drawing.Size(102, 18)
        Me.txtNivelRiesgo.TabIndex = 16
        Me.txtNivelRiesgo.Text = "[NIVEL RIESGO]"
        '
        'lblMotivoRechazo
        '
        Me.lblMotivoRechazo.AutoSize = True
        Me.lblMotivoRechazo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotivoRechazo.ForeColor = System.Drawing.Color.Black
        Me.lblMotivoRechazo.Location = New System.Drawing.Point(11, 294)
        Me.lblMotivoRechazo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMotivoRechazo.Name = "lblMotivoRechazo"
        Me.lblMotivoRechazo.Size = New System.Drawing.Size(183, 18)
        Me.lblMotivoRechazo.TabIndex = 17
        Me.lblMotivoRechazo.Text = "MOTIVO DE REASIGNACIÓN:"
        '
        'txtMotivoRechazo
        '
        Me.txtMotivoRechazo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivoRechazo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMotivoRechazo.Location = New System.Drawing.Point(209, 294)
        Me.txtMotivoRechazo.Name = "txtMotivoRechazo"
        Me.txtMotivoRechazo.Size = New System.Drawing.Size(412, 121)
        Me.txtMotivoRechazo.TabIndex = 18
        Me.txtMotivoRechazo.Text = "[RECHAZO]"
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 43)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(650, 2)
        Me.panLinea.TabIndex = 3
        '
        'lblIdSac
        '
        Me.lblIdSac.AutoSize = True
        Me.lblIdSac.Font = New System.Drawing.Font("Calibri", 12.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSac.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblIdSac.Location = New System.Drawing.Point(464, 11)
        Me.lblIdSac.Name = "lblIdSac"
        Me.lblIdSac.Size = New System.Drawing.Size(67, 21)
        Me.lblIdSac.TabIndex = 1
        Me.lblIdSac.Text = "ID. SAC:"
        '
        'txtIdSac
        '
        Me.txtIdSac.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtIdSac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdSac.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSac.ForeColor = System.Drawing.Color.SlateGray
        Me.txtIdSac.Location = New System.Drawing.Point(533, 9)
        Me.txtIdSac.Name = "txtIdSac"
        Me.txtIdSac.Size = New System.Drawing.Size(88, 25)
        Me.txtIdSac.TabIndex = 2
        Me.txtIdSac.Text = "000000"
        Me.txtIdSac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIndustria
        '
        Me.lblIndustria.AutoSize = True
        Me.lblIndustria.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIndustria.ForeColor = System.Drawing.Color.Black
        Me.lblIndustria.Location = New System.Drawing.Point(11, 226)
        Me.lblIndustria.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIndustria.Name = "lblIndustria"
        Me.lblIndustria.Size = New System.Drawing.Size(80, 18)
        Me.lblIndustria.TabIndex = 13
        Me.lblIndustria.Text = "INDUSTRIA:"
        '
        'txtIndustria
        '
        Me.txtIndustria.AutoSize = True
        Me.txtIndustria.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndustria.Location = New System.Drawing.Point(209, 226)
        Me.txtIndustria.Name = "txtIndustria"
        Me.txtIndustria.Size = New System.Drawing.Size(85, 18)
        Me.txtIndustria.TabIndex = 14
        Me.txtIndustria.Text = "[INDUSTRIA]"
        '
        'lblIdioma
        '
        Me.lblIdioma.AutoSize = True
        Me.lblIdioma.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdioma.ForeColor = System.Drawing.Color.Black
        Me.lblIdioma.Location = New System.Drawing.Point(11, 192)
        Me.lblIdioma.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIdioma.Name = "lblIdioma"
        Me.lblIdioma.Size = New System.Drawing.Size(137, 18)
        Me.lblIdioma.TabIndex = 11
        Me.lblIdioma.Text = "IDIOMA SOLICITADO:"
        '
        'txtIdioma
        '
        Me.txtIdioma.AutoSize = True
        Me.txtIdioma.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdioma.Location = New System.Drawing.Point(209, 192)
        Me.txtIdioma.Name = "txtIdioma"
        Me.txtIdioma.Size = New System.Drawing.Size(66, 18)
        Me.txtIdioma.TabIndex = 12
        Me.txtIdioma.Text = "[IDIOMA]"
        '
        'lblSocioEncargado
        '
        Me.lblSocioEncargado.AutoSize = True
        Me.lblSocioEncargado.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSocioEncargado.ForeColor = System.Drawing.Color.Black
        Me.lblSocioEncargado.Location = New System.Drawing.Point(11, 158)
        Me.lblSocioEncargado.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSocioEncargado.Name = "lblSocioEncargado"
        Me.lblSocioEncargado.Size = New System.Drawing.Size(194, 18)
        Me.lblSocioEncargado.TabIndex = 9
        Me.lblSocioEncargado.Text = "SOCIO DE OFICINA / DIVISIÓN:"
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivision.ForeColor = System.Drawing.Color.Black
        Me.lblDivision.Location = New System.Drawing.Point(11, 124)
        Me.lblDivision.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(69, 18)
        Me.lblDivision.TabIndex = 7
        Me.lblDivision.Text = "DIVISIÓN:"
        '
        'txtDivision
        '
        Me.txtDivision.AutoSize = True
        Me.txtDivision.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDivision.Location = New System.Drawing.Point(209, 124)
        Me.txtDivision.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.Size = New System.Drawing.Size(75, 18)
        Me.txtDivision.TabIndex = 8
        Me.txtDivision.Text = "[DIVISION]"
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOficina.ForeColor = System.Drawing.Color.Black
        Me.lblOficina.Location = New System.Drawing.Point(11, 90)
        Me.lblOficina.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(64, 18)
        Me.lblOficina.TabIndex = 5
        Me.lblOficina.Text = "OFICINA:"
        '
        'txtOficina
        '
        Me.txtOficina.AutoSize = True
        Me.txtOficina.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOficina.Location = New System.Drawing.Point(209, 90)
        Me.txtOficina.Margin = New System.Windows.Forms.Padding(0)
        Me.txtOficina.Name = "txtOficina"
        Me.txtOficina.Size = New System.Drawing.Size(70, 18)
        Me.txtOficina.TabIndex = 6
        Me.txtOficina.Text = "[OFICINA]"
        '
        'txtSocioEncargado
        '
        Me.txtSocioEncargado.AutoSize = True
        Me.txtSocioEncargado.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSocioEncargado.Location = New System.Drawing.Point(209, 158)
        Me.txtSocioEncargado.Name = "txtSocioEncargado"
        Me.txtSocioEncargado.Size = New System.Drawing.Size(139, 18)
        Me.txtSocioEncargado.TabIndex = 10
        Me.txtSocioEncargado.Text = "[SOCIO ENCARGADO]"
        '
        'txtServicio
        '
        Me.txtServicio.AutoSize = True
        Me.txtServicio.Font = New System.Drawing.Font("Calibri", 12.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServicio.Location = New System.Drawing.Point(11, 52)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(89, 21)
        Me.txtServicio.TabIndex = 4
        Me.txtServicio.Text = "[SERVICIO]"
        '
        'txtProspecto
        '
        Me.txtProspecto.AutoSize = True
        Me.txtProspecto.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProspecto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.txtProspecto.Location = New System.Drawing.Point(11, 8)
        Me.txtProspecto.Name = "txtProspecto"
        Me.txtProspecto.Size = New System.Drawing.Size(135, 27)
        Me.txtProspecto.TabIndex = 0
        Me.txtProspecto.Text = "[PROSPECTO]"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(527, 577)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(135, 25)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'DlgDetalleSolicitud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 607)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgDetalleSolicitud"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle de la Solicitud"
        Me.panPrincipal.ResumeLayout(False)
        Me.panSolicitud.ResumeLayout(False)
        Me.panSolicitud.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents panSolicitud As Panel
    Friend WithEvents lblSocioEncargado As Label
    Friend WithEvents lblDivision As Label
    Friend WithEvents txtDivision As Label
    Friend WithEvents lblOficina As Label
    Friend WithEvents txtOficina As Label
    Friend WithEvents txtSocioEncargado As Label
    Friend WithEvents txtServicio As Label
    Friend WithEvents txtProspecto As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblIndustria As Label
    Friend WithEvents txtIndustria As Label
    Friend WithEvents lblIdioma As Label
    Friend WithEvents txtIdioma As Label
    Friend WithEvents lblIdSac As Label
    Friend WithEvents txtIdSac As Label
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblMotivoRechazo As Label
    Friend WithEvents txtMotivoRechazo As Label
    Friend WithEvents lblNivelRiesgo As Label
    Friend WithEvents txtNivelRiesgo As Label
End Class
