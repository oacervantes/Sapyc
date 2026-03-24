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
        Me.lblTituloProspecto = New System.Windows.Forms.Label()
        Me.lblTituloSocios = New System.Windows.Forms.Label()
        Me.panSocios = New System.Windows.Forms.Panel()
        Me.panSolicitud = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblProspecto = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.flpSocios = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.panPrincipal.Controls.Add(Me.lblTituloProspecto)
        Me.panPrincipal.Controls.Add(Me.lblTituloSocios)
        Me.panPrincipal.Controls.Add(Me.panSocios)
        Me.panPrincipal.Controls.Add(Me.panSolicitud)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1080, 638)
        Me.panPrincipal.TabIndex = 0
        '
        'lblTituloProspecto
        '
        Me.lblTituloProspecto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTituloProspecto.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTituloProspecto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTituloProspecto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloProspecto.ForeColor = System.Drawing.Color.White
        Me.lblTituloProspecto.Location = New System.Drawing.Point(25, 10)
        Me.lblTituloProspecto.Name = "lblTituloProspecto"
        Me.lblTituloProspecto.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.lblTituloProspecto.Size = New System.Drawing.Size(1028, 23)
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
        Me.lblTituloSocios.Location = New System.Drawing.Point(25, 127)
        Me.lblTituloSocios.Name = "lblTituloSocios"
        Me.lblTituloSocios.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.lblTituloSocios.Size = New System.Drawing.Size(1028, 23)
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
        Me.panSocios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panSocios.Location = New System.Drawing.Point(25, 149)
        Me.panSocios.Name = "panSocios"
        Me.panSocios.Size = New System.Drawing.Size(1028, 477)
        Me.panSocios.TabIndex = 2
        '
        'panSolicitud
        '
        Me.panSolicitud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panSolicitud.Controls.Add(Me.Label2)
        Me.panSolicitud.Controls.Add(Me.Label1)
        Me.panSolicitud.Controls.Add(Me.lblProspecto)
        Me.panSolicitud.Location = New System.Drawing.Point(25, 10)
        Me.panSolicitud.Name = "panSolicitud"
        Me.panSolicitud.Size = New System.Drawing.Size(1028, 105)
        Me.panSolicitud.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "[SERVICIO]"
        '
        'lblProspecto
        '
        Me.lblProspecto.AutoSize = True
        Me.lblProspecto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProspecto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblProspecto.Location = New System.Drawing.Point(21, 28)
        Me.lblProspecto.Name = "lblProspecto"
        Me.lblProspecto.Size = New System.Drawing.Size(91, 18)
        Me.lblProspecto.TabIndex = 0
        Me.lblProspecto.Text = "[PROSPECTO]"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(938, 643)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(130, 25)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'flpSocios
        '
        Me.flpSocios.AutoScroll = True
        Me.flpSocios.AutoScrollMargin = New System.Drawing.Size(0, 25)
        Me.flpSocios.AutoSize = True
        Me.flpSocios.Location = New System.Drawing.Point(26, 651)
        Me.flpSocios.Margin = New System.Windows.Forms.Padding(10)
        Me.flpSocios.Name = "flpSocios"
        Me.flpSocios.Padding = New System.Windows.Forms.Padding(10, 10, 10, 50)
        Me.flpSocios.Size = New System.Drawing.Size(183, 60)
        Me.flpSocios.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(21, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "[SOCIO ENCARGADO]"
        '
        'DlgSolicitudAsignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 674)
        Me.Controls.Add(Me.flpSocios)
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
        Me.panSolicitud.ResumeLayout(False)
        Me.panSolicitud.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents panSolicitud As Panel
    Friend WithEvents panSocios As Panel
    Friend WithEvents lblTituloProspecto As Label
    Friend WithEvents lblTituloSocios As Label
    Friend WithEvents flpSocios As FlowLayoutPanel
    Friend WithEvents lblProspecto As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
