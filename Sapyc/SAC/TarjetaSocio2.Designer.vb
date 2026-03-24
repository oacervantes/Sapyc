<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TarjetaSocio2
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.txtOficina = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDivision = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtServicios = New System.Windows.Forms.TextBox()
        Me.lblServicios = New System.Windows.Forms.Label()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.txtGrupo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOficina.ForeColor = System.Drawing.Color.Black
        Me.lblOficina.Location = New System.Drawing.Point(19, 50)
        Me.lblOficina.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(64, 18)
        Me.lblOficina.TabIndex = 12
        Me.lblOficina.Text = "OFICINA:"
        '
        'txtOficina
        '
        Me.txtOficina.AutoSize = True
        Me.txtOficina.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOficina.ForeColor = System.Drawing.Color.Gray
        Me.txtOficina.Location = New System.Drawing.Point(88, 50)
        Me.txtOficina.Margin = New System.Windows.Forms.Padding(0)
        Me.txtOficina.Name = "txtOficina"
        Me.txtOficina.Size = New System.Drawing.Size(70, 18)
        Me.txtOficina.TabIndex = 10
        Me.txtOficina.Text = "[OFICINA]"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Calibri", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblNombre.Location = New System.Drawing.Point(4, 4)
        Me.lblNombre.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(217, 28)
        Me.lblNombre.TabIndex = 8
        Me.lblNombre.Text = "[NOMBRE_PERSONA]"
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 36)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(750, 2)
        Me.panLinea.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 76)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 18)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "DIVISIÓN:"
        '
        'txtDivision
        '
        Me.txtDivision.AutoSize = True
        Me.txtDivision.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDivision.ForeColor = System.Drawing.Color.Gray
        Me.txtDivision.Location = New System.Drawing.Point(88, 76)
        Me.txtDivision.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.Size = New System.Drawing.Size(75, 18)
        Me.txtDivision.TabIndex = 15
        Me.txtDivision.Text = "[DIVISION]"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(620, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 25)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "ASIGNAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtServicios
        '
        Me.txtServicios.Location = New System.Drawing.Point(19, 190)
        Me.txtServicios.Multiline = True
        Me.txtServicios.Name = "txtServicios"
        Me.txtServicios.ReadOnly = True
        Me.txtServicios.Size = New System.Drawing.Size(916, 73)
        Me.txtServicios.TabIndex = 18
        '
        'lblServicios
        '
        Me.lblServicios.AutoSize = True
        Me.lblServicios.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServicios.ForeColor = System.Drawing.Color.Black
        Me.lblServicios.Location = New System.Drawing.Point(19, 169)
        Me.lblServicios.Margin = New System.Windows.Forms.Padding(0)
        Me.lblServicios.Name = "lblServicios"
        Me.lblServicios.Size = New System.Drawing.Size(76, 18)
        Me.lblServicios.TabIndex = 19
        Me.lblServicios.Text = "SERVICIOS:"
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrupo.ForeColor = System.Drawing.Color.Black
        Me.lblGrupo.Location = New System.Drawing.Point(19, 102)
        Me.lblGrupo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(58, 18)
        Me.lblGrupo.TabIndex = 21
        Me.lblGrupo.Text = "GRUPO:"
        '
        'txtGrupo
        '
        Me.txtGrupo.AutoSize = True
        Me.txtGrupo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrupo.ForeColor = System.Drawing.Color.Gray
        Me.txtGrupo.Location = New System.Drawing.Point(88, 102)
        Me.txtGrupo.Margin = New System.Windows.Forms.Padding(0)
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Size = New System.Drawing.Size(46, 18)
        Me.txtGrupo.TabIndex = 20
        Me.txtGrupo.Text = "[GPO]"
        '
        'TarjetaSocio2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.lblGrupo)
        Me.Controls.Add(Me.txtGrupo)
        Me.Controls.Add(Me.lblServicios)
        Me.Controls.Add(Me.txtServicios)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDivision)
        Me.Controls.Add(Me.panLinea)
        Me.Controls.Add(Me.lblOficina)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtOficina)
        Me.Name = "TarjetaSocio2"
        Me.Padding = New System.Windows.Forms.Padding(4)
        Me.Size = New System.Drawing.Size(954, 280)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblOficina As Label
    Friend WithEvents txtOficina As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents panLinea As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDivision As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents txtServicios As TextBox
    Friend WithEvents lblServicios As Label
    Friend WithEvents lblGrupo As Label
    Friend WithEvents txtGrupo As Label
End Class
