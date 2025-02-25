<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleAutorizaSolicitudFolio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose( disposing As Boolean)
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
        Me.btnAutoriza = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblTres = New System.Windows.Forms.Label()
        Me.lblDos = New System.Windows.Forms.Label()
        Me.lblUno = New System.Windows.Forms.Label()
        Me.lblTrabajo = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblSaldoPorCobrar = New System.Windows.Forms.Label()
        Me.lblCobranza = New System.Windows.Forms.Label()
        Me.lblHonorariosEstimados = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTituloIEs = New System.Windows.Forms.Label()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAutoriza
        '
        Me.btnAutoriza.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAutoriza.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoriza.Location = New System.Drawing.Point(12, 449)
        Me.btnAutoriza.Name = "btnAutoriza"
        Me.btnAutoriza.Size = New System.Drawing.Size(122, 25)
        Me.btnAutoriza.TabIndex = 1
        Me.btnAutoriza.Text = "Autorizar"
        Me.btnAutoriza.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(557, 449)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(122, 25)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblTres
        '
        Me.lblTres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTres.Location = New System.Drawing.Point(233, 189)
        Me.lblTres.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTres.Name = "lblTres"
        Me.lblTres.Size = New System.Drawing.Size(107, 25)
        Me.lblTres.TabIndex = 10
        Me.lblTres.Text = "0.00"
        Me.lblTres.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDos
        '
        Me.lblDos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDos.Location = New System.Drawing.Point(233, 161)
        Me.lblDos.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDos.Name = "lblDos"
        Me.lblDos.Size = New System.Drawing.Size(107, 25)
        Me.lblDos.TabIndex = 8
        Me.lblDos.Text = "0.00"
        Me.lblDos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUno
        '
        Me.lblUno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUno.Location = New System.Drawing.Point(233, 131)
        Me.lblUno.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUno.Name = "lblUno"
        Me.lblUno.Size = New System.Drawing.Size(107, 25)
        Me.lblUno.TabIndex = 6
        Me.lblUno.Text = "0.00"
        Me.lblUno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTrabajo
        '
        Me.lblTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTrabajo.Location = New System.Drawing.Point(185, 61)
        Me.lblTrabajo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTrabajo.Name = "lblTrabajo"
        Me.lblTrabajo.Size = New System.Drawing.Size(107, 25)
        Me.lblTrabajo.TabIndex = 2
        Me.lblTrabajo.Text = "Trabajo"
        Me.lblTrabajo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCliente.Location = New System.Drawing.Point(185, 92)
        Me.lblCliente.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(485, 25)
        Me.lblCliente.TabIndex = 4
        Me.lblCliente.Text = "Cliente"
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldoPorCobrar
        '
        Me.lblSaldoPorCobrar.AutoSize = True
        Me.lblSaldoPorCobrar.Location = New System.Drawing.Point(109, 192)
        Me.lblSaldoPorCobrar.Name = "lblSaldoPorCobrar"
        Me.lblSaldoPorCobrar.Size = New System.Drawing.Size(112, 18)
        Me.lblSaldoPorCobrar.TabIndex = 9
        Me.lblSaldoPorCobrar.Text = "Saldo por cobrar:"
        '
        'lblCobranza
        '
        Me.lblCobranza.AutoSize = True
        Me.lblCobranza.Location = New System.Drawing.Point(152, 164)
        Me.lblCobranza.Name = "lblCobranza"
        Me.lblCobranza.Size = New System.Drawing.Size(69, 18)
        Me.lblCobranza.TabIndex = 7
        Me.lblCobranza.Text = "Cobranza:"
        '
        'lblHonorariosEstimados
        '
        Me.lblHonorariosEstimados.AutoSize = True
        Me.lblHonorariosEstimados.Location = New System.Drawing.Point(74, 134)
        Me.lblHonorariosEstimados.Name = "lblHonorariosEstimados"
        Me.lblHonorariosEstimados.Size = New System.Drawing.Size(147, 18)
        Me.lblHonorariosEstimados.TabIndex = 5
        Me.lblHonorariosEstimados.Text = "Honorarios estimados:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(76, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Clave Trabajo :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(113, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cliente :"
        '
        'lblTituloIEs
        '
        Me.lblTituloIEs.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lblTituloIEs.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloIEs.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloIEs.ForeColor = System.Drawing.Color.White
        Me.lblTituloIEs.Location = New System.Drawing.Point(0, 0)
        Me.lblTituloIEs.Name = "lblTituloIEs"
        Me.lblTituloIEs.Padding = New System.Windows.Forms.Padding(11, 0, 0, 0)
        Me.lblTituloIEs.Size = New System.Drawing.Size(686, 34)
        Me.lblTituloIEs.TabIndex = 0
        Me.lblTituloIEs.Text = "REVISIÓN DE SOLICITUD DE FOLIO"
        Me.lblTituloIEs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Location = New System.Drawing.Point(20, 324)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(217, 18)
        Me.lblMotivo.TabIndex = 11
        Me.lblMotivo.Text = "Motivo de autorización o rechazo:"
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(20, 351)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(650, 79)
        Me.txtMotivo.TabIndex = 12
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.txtObservaciones)
        Me.panPrincipal.Controls.Add(Me.Label3)
        Me.panPrincipal.Controls.Add(Me.lblTres)
        Me.panPrincipal.Controls.Add(Me.lblMotivo)
        Me.panPrincipal.Controls.Add(Me.lblDos)
        Me.panPrincipal.Controls.Add(Me.txtMotivo)
        Me.panPrincipal.Controls.Add(Me.lblUno)
        Me.panPrincipal.Controls.Add(Me.lblTituloIEs)
        Me.panPrincipal.Controls.Add(Me.lblTrabajo)
        Me.panPrincipal.Controls.Add(Me.Label1)
        Me.panPrincipal.Controls.Add(Me.lblCliente)
        Me.panPrincipal.Controls.Add(Me.Label2)
        Me.panPrincipal.Controls.Add(Me.lblSaldoPorCobrar)
        Me.panPrincipal.Controls.Add(Me.lblHonorariosEstimados)
        Me.panPrincipal.Controls.Add(Me.lblCobranza)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(688, 443)
        Me.panPrincipal.TabIndex = 0
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(20, 257)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.Size = New System.Drawing.Size(650, 57)
        Me.txtObservaciones.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 18)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Motivo de la solicitud:"
        '
        'btnRechazar
        '
        Me.btnRechazar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRechazar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRechazar.Location = New System.Drawing.Point(140, 449)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(122, 25)
        Me.btnRechazar.TabIndex = 2
        Me.btnRechazar.Text = "Rechazar"
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'frmDetalleAutorizaSolicitudFolio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(688, 481)
        Me.Controls.Add(Me.btnRechazar)
        Me.Controls.Add(Me.panPrincipal)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAutoriza)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmDetalleAutorizaSolicitudFolio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Revisión de solicitud..."
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTituloIEs As Label
    Friend WithEvents lblMotivo As Label
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents btnAutoriza As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblSaldoPorCobrar As Label
    Friend WithEvents lblCobranza As Label
    Friend WithEvents lblHonorariosEstimados As Label
    Friend WithEvents lblTres As Label
    Friend WithEvents lblDos As Label
    Friend WithEvents lblUno As Label
    Friend WithEvents lblTrabajo As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents panPrincipal As Panel
    Friend WithEvents btnRechazar As Button
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents Label3 As Label
End Class
