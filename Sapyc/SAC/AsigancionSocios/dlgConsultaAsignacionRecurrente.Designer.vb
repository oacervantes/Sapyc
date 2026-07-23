<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgConsultaAsignacionRecurrente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgConsultaAsignacionRecurrente))
        Me.panSolicitud = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUsuarioSol = New System.Windows.Forms.Label()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblIdSac = New System.Windows.Forms.Label()
        Me.txtIdSac = New System.Windows.Forms.Label()
        Me.lblSocioEncargado = New System.Windows.Forms.Label()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.txtDivision = New System.Windows.Forms.Label()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.txtOficina = New System.Windows.Forms.Label()
        Me.txtSocioEncargado = New System.Windows.Forms.Label()
        Me.txtServicio = New System.Windows.Forms.Label()
        Me.txtProspecto = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.panSolicitud.SuspendLayout()
        Me.panPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'panSolicitud
        '
        Me.panSolicitud.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panSolicitud.BackColor = System.Drawing.Color.White
        Me.panSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panSolicitud.Controls.Add(Me.Label1)
        Me.panSolicitud.Controls.Add(Me.lblUsuarioSol)
        Me.panSolicitud.Controls.Add(Me.panLinea)
        Me.panSolicitud.Controls.Add(Me.lblIdSac)
        Me.panSolicitud.Controls.Add(Me.txtIdSac)
        Me.panSolicitud.Controls.Add(Me.lblSocioEncargado)
        Me.panSolicitud.Controls.Add(Me.lblDivision)
        Me.panSolicitud.Controls.Add(Me.txtDivision)
        Me.panSolicitud.Controls.Add(Me.lblOficina)
        Me.panSolicitud.Controls.Add(Me.txtOficina)
        Me.panSolicitud.Controls.Add(Me.txtSocioEncargado)
        Me.panSolicitud.Controls.Add(Me.txtServicio)
        Me.panSolicitud.Controls.Add(Me.txtProspecto)
        Me.panSolicitud.Location = New System.Drawing.Point(12, 14)
        Me.panSolicitud.Name = "panSolicitud"
        Me.panSolicitud.Size = New System.Drawing.Size(741, 313)
        Me.panSolicitud.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(46, 100)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 18)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "USUARIO SOLICITO"
        '
        'lblUsuarioSol
        '
        Me.lblUsuarioSol.AutoSize = True
        Me.lblUsuarioSol.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioSol.Location = New System.Drawing.Point(180, 100)
        Me.lblUsuarioSol.Name = "lblUsuarioSol"
        Me.lblUsuarioSol.Size = New System.Drawing.Size(139, 18)
        Me.lblUsuarioSol.TabIndex = 12
        Me.lblUsuarioSol.Text = "[SOCIO ENCARGADO]"
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 43)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(741, 2)
        Me.panLinea.TabIndex = 3
        '
        'lblIdSac
        '
        Me.lblIdSac.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIdSac.AutoSize = True
        Me.lblIdSac.Font = New System.Drawing.Font("Calibri", 12.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSac.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblIdSac.Location = New System.Drawing.Point(555, 10)
        Me.lblIdSac.Name = "lblIdSac"
        Me.lblIdSac.Size = New System.Drawing.Size(67, 21)
        Me.lblIdSac.TabIndex = 1
        Me.lblIdSac.Text = "ID. SAC:"
        '
        'txtIdSac
        '
        Me.txtIdSac.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIdSac.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtIdSac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdSac.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSac.ForeColor = System.Drawing.Color.Black
        Me.txtIdSac.Location = New System.Drawing.Point(624, 8)
        Me.txtIdSac.Name = "txtIdSac"
        Me.txtIdSac.Size = New System.Drawing.Size(88, 25)
        Me.txtIdSac.TabIndex = 2
        Me.txtIdSac.Text = "000000"
        Me.txtIdSac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSocioEncargado
        '
        Me.lblSocioEncargado.AutoSize = True
        Me.lblSocioEncargado.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSocioEncargado.ForeColor = System.Drawing.Color.Black
        Me.lblSocioEncargado.Location = New System.Drawing.Point(12, 129)
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
        Me.lblDivision.Location = New System.Drawing.Point(47, 201)
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
        Me.txtDivision.Location = New System.Drawing.Point(122, 202)
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
        Me.lblOficina.Location = New System.Drawing.Point(47, 172)
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
        Me.txtOficina.Location = New System.Drawing.Point(122, 173)
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
        Me.txtSocioEncargado.Location = New System.Drawing.Point(215, 129)
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
        Me.txtProspecto.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProspecto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.txtProspecto.Location = New System.Drawing.Point(2, 10)
        Me.txtProspecto.Name = "txtProspecto"
        Me.txtProspecto.Size = New System.Drawing.Size(124, 24)
        Me.txtProspecto.TabIndex = 0
        Me.txtProspecto.Text = "[PROSPECTO]"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(619, 351)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(135, 25)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
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
        Me.panPrincipal.Size = New System.Drawing.Size(767, 343)
        Me.panPrincipal.TabIndex = 3
        '
        'dlgConsultaAsignacionRecurrente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 383)
        Me.Controls.Add(Me.panPrincipal)
        Me.Controls.Add(Me.btnCerrar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "dlgConsultaAsignacionRecurrente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignacion Recurrentes:"
        Me.panSolicitud.ResumeLayout(False)
        Me.panSolicitud.PerformLayout()
        Me.panPrincipal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panSolicitud As Panel
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblIdSac As Label
    Friend WithEvents txtIdSac As Label
    Friend WithEvents lblSocioEncargado As Label
    Friend WithEvents txtSocioEncargado As Label
    Friend WithEvents txtServicio As Label
    Friend WithEvents txtProspecto As Label
    Friend WithEvents lblDivision As Label
    Friend WithEvents txtDivision As Label
    Friend WithEvents lblOficina As Label
    Friend WithEvents txtOficina As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblUsuarioSol As Label
    Friend WithEvents panPrincipal As Panel
End Class
