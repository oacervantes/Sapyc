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
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.lblSac = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDivision = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOficina = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.txtDescripcionTrabajo = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRechazo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnRechaza = New System.Windows.Forms.Button()
        Me.btnAutoriza = New System.Windows.Forms.Button()
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
        Me.panPrincipal.Controls.Add(Me.Label5)
        Me.panPrincipal.Controls.Add(Me.txtRechazo)
        Me.panPrincipal.Controls.Add(Me.Label4)
        Me.panPrincipal.Controls.Add(Me.lblSac)
        Me.panPrincipal.Controls.Add(Me.Label3)
        Me.panPrincipal.Controls.Add(Me.txtDivision)
        Me.panPrincipal.Controls.Add(Me.Label2)
        Me.panPrincipal.Controls.Add(Me.txtOficina)
        Me.panPrincipal.Controls.Add(Me.Label1)
        Me.panPrincipal.Controls.Add(Me.txtCliente)
        Me.panPrincipal.Controls.Add(Me.lblServicio)
        Me.panPrincipal.Controls.Add(Me.txtServicio)
        Me.panPrincipal.Controls.Add(Me.txtDescripcionTrabajo)
        Me.panPrincipal.Controls.Add(Me.lblDescripcion)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, -1)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(842, 449)
        Me.panPrincipal.TabIndex = 2
        '
        'lblSac
        '
        Me.lblSac.AutoSize = True
        Me.lblSac.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSac.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblSac.Location = New System.Drawing.Point(419, 51)
        Me.lblSac.Name = "lblSac"
        Me.lblSac.Size = New System.Drawing.Size(21, 32)
        Me.lblSac.TabIndex = 26
        Me.lblSac.Text = "."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(320, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 18)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Número SAC: "
        '
        'txtDivision
        '
        Me.txtDivision.Enabled = False
        Me.txtDivision.Location = New System.Drawing.Point(505, 120)
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.Size = New System.Drawing.Size(324, 25)
        Me.txtDivision.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 18)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Oficina:"
        '
        'txtOficina
        '
        Me.txtOficina.Enabled = False
        Me.txtOficina.Location = New System.Drawing.Point(104, 119)
        Me.txtOficina.Name = "txtOficina"
        Me.txtOficina.Size = New System.Drawing.Size(318, 25)
        Me.txtOficina.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 18)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(104, 150)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(725, 25)
        Me.txtCliente.TabIndex = 20
        '
        'lblServicio
        '
        Me.lblServicio.AutoSize = True
        Me.lblServicio.Location = New System.Drawing.Point(38, 184)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(61, 18)
        Me.lblServicio.TabIndex = 15
        Me.lblServicio.Text = "Servicio:"
        '
        'txtServicio
        '
        Me.txtServicio.Enabled = False
        Me.txtServicio.Location = New System.Drawing.Point(104, 181)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(725, 25)
        Me.txtServicio.TabIndex = 16
        '
        'txtDescripcionTrabajo
        '
        Me.txtDescripcionTrabajo.Enabled = False
        Me.txtDescripcionTrabajo.Location = New System.Drawing.Point(104, 214)
        Me.txtDescripcionTrabajo.Multiline = True
        Me.txtDescripcionTrabajo.Name = "txtDescripcionTrabajo"
        Me.txtDescripcionTrabajo.Size = New System.Drawing.Size(725, 67)
        Me.txtDescripcionTrabajo.TabIndex = 18
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(15, 214)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(84, 18)
        Me.lblDescripcion.TabIndex = 17
        Me.lblDescripcion.Text = "Descripción:"
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 36)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(842, 2)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(438, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 18)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "División:"
        '
        'txtRechazo
        '
        Me.txtRechazo.Location = New System.Drawing.Point(18, 349)
        Me.txtRechazo.Multiline = True
        Me.txtRechazo.Name = "txtRechazo"
        Me.txtRechazo.Size = New System.Drawing.Size(811, 67)
        Me.txtRechazo.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(280, 300)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(278, 18)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "En caso de rechazar indique una descrpción:"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(700, 454)
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
        Me.btnRechaza.Location = New System.Drawing.Point(170, 454)
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
        Me.btnAutoriza.Location = New System.Drawing.Point(19, 454)
        Me.btnAutoriza.Name = "btnAutoriza"
        Me.btnAutoriza.Size = New System.Drawing.Size(130, 25)
        Me.btnAutoriza.TabIndex = 9
        Me.btnAutoriza.Text = "Autoriza"
        Me.btnAutoriza.UseVisualStyleBackColor = True
        '
        'frmAutorizaOtroServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 491)
        Me.Controls.Add(Me.btnAutoriza)
        Me.Controls.Add(Me.btnRechaza)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.panPrincipal)
        Me.Name = "frmAutorizaOtroServicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AUTORIZA PROPUESTA SERVICIO OTROS"
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
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOficina As TextBox
    Friend WithEvents txtDivision As TextBox
    Friend WithEvents lblSac As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRechazo As TextBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnRechaza As Button
    Friend WithEvents btnAutoriza As Button
End Class
