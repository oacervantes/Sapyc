<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgEnvioPropuesta
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
        Me.panFondo = New System.Windows.Forms.Panel()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.txtServicio = New System.Windows.Forms.Label()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblIdSac = New System.Windows.Forms.Label()
        Me.txtIdSac = New System.Windows.Forms.Label()
        Me.txtProspecto = New System.Windows.Forms.Label()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.panFondo.SuspendLayout()
        Me.panPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'panFondo
        '
        Me.panFondo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panFondo.Controls.Add(Me.panPrincipal)
        Me.panFondo.Location = New System.Drawing.Point(-1, 1)
        Me.panFondo.Name = "panFondo"
        Me.panFondo.Size = New System.Drawing.Size(597, 281)
        Me.panFondo.TabIndex = 4
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.txtServicio)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblIdSac)
        Me.panPrincipal.Controls.Add(Me.txtIdSac)
        Me.panPrincipal.Controls.Add(Me.txtProspecto)
        Me.panPrincipal.Controls.Add(Me.lblMensaje)
        Me.panPrincipal.Controls.Add(Me.txtMotivo)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(9, 10)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(576, 259)
        Me.panPrincipal.TabIndex = 0
        '
        'txtServicio
        '
        Me.txtServicio.AutoSize = True
        Me.txtServicio.Font = New System.Drawing.Font("Calibri", 12.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServicio.Location = New System.Drawing.Point(10, 60)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(89, 21)
        Me.txtServicio.TabIndex = 4
        Me.txtServicio.Text = "[SERVICIO]"
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 46)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(576, 2)
        Me.panLinea.TabIndex = 3
        '
        'lblIdSac
        '
        Me.lblIdSac.AutoSize = True
        Me.lblIdSac.Font = New System.Drawing.Font("Calibri", 12.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSac.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblIdSac.Location = New System.Drawing.Point(404, 13)
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
        Me.txtIdSac.Location = New System.Drawing.Point(473, 11)
        Me.txtIdSac.Name = "txtIdSac"
        Me.txtIdSac.Size = New System.Drawing.Size(88, 25)
        Me.txtIdSac.TabIndex = 2
        Me.txtIdSac.Text = "000000"
        Me.txtIdSac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtProspecto
        '
        Me.txtProspecto.AutoSize = True
        Me.txtProspecto.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProspecto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.txtProspecto.Location = New System.Drawing.Point(9, 9)
        Me.txtProspecto.Name = "txtProspecto"
        Me.txtProspecto.Size = New System.Drawing.Size(135, 27)
        Me.txtProspecto.TabIndex = 0
        Me.txtProspecto.Text = "[PROSPECTO]"
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.Black
        Me.lblMensaje.Location = New System.Drawing.Point(11, 115)
        Me.lblMensaje.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(399, 18)
        Me.lblMensaje.TabIndex = 5
        Me.lblMensaje.Text = "Especifique el motivo de la asignación en caso de ser necesario:"
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(11, 142)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(550, 91)
        Me.txtMotivo.TabIndex = 6
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(447, 287)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(135, 25)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "Cancelar"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEnviar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviar.Location = New System.Drawing.Point(9, 287)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(135, 25)
        Me.btnEnviar.TabIndex = 3
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'DlgEnvioPropuesta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 320)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.panFondo)
        Me.Controls.Add(Me.btnEnviar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgEnvioPropuesta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envio Propuestas"
        Me.panFondo.ResumeLayout(False)
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panFondo As Panel
    Friend WithEvents panPrincipal As Panel
    Friend WithEvents txtServicio As Label
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblIdSac As Label
    Friend WithEvents txtIdSac As Label
    Friend WithEvents txtProspecto As Label
    Friend WithEvents lblMensaje As Label
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnEnviar As Button
End Class
