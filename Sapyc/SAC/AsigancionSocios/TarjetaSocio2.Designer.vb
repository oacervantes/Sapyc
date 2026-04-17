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
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.btnAsignacion = New System.Windows.Forms.Button()
        Me.lblIdiomas = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblIndustrias = New System.Windows.Forms.Label()
        Me.txtServiciosColor = New System.Windows.Forms.RichTextBox()
        Me.txtIdiomasColor = New System.Windows.Forms.RichTextBox()
        Me.txtIndustriasColor = New System.Windows.Forms.RichTextBox()
        Me.lblSeleccion = New System.Windows.Forms.Label()
        Me.lblCorreo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPresupuesto = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblNombre.Location = New System.Drawing.Point(14, 9)
        Me.lblNombre.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(182, 23)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "[NOMBRE_PERSONA]"
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 62)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(954, 2)
        Me.panLinea.TabIndex = 4
        '
        'btnAsignacion
        '
        Me.btnAsignacion.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsignacion.Location = New System.Drawing.Point(829, 7)
        Me.btnAsignacion.Name = "btnAsignacion"
        Me.btnAsignacion.Size = New System.Drawing.Size(109, 25)
        Me.btnAsignacion.TabIndex = 2
        Me.btnAsignacion.Text = "ELEGIR"
        Me.btnAsignacion.UseVisualStyleBackColor = True
        '
        'lblIdiomas
        '
        Me.lblIdiomas.AutoSize = True
        Me.lblIdiomas.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdiomas.ForeColor = System.Drawing.Color.Black
        Me.lblIdiomas.Location = New System.Drawing.Point(104, 140)
        Me.lblIdiomas.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIdiomas.Name = "lblIdiomas"
        Me.lblIdiomas.Size = New System.Drawing.Size(68, 18)
        Me.lblIdiomas.TabIndex = 7
        Me.lblIdiomas.Text = "IDIOMAS:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(96, 74)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "SERVICIOS:"
        '
        'lblIndustrias
        '
        Me.lblIndustrias.AutoSize = True
        Me.lblIndustrias.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIndustrias.ForeColor = System.Drawing.Color.Black
        Me.lblIndustrias.Location = New System.Drawing.Point(85, 169)
        Me.lblIndustrias.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIndustrias.Name = "lblIndustrias"
        Me.lblIndustrias.Size = New System.Drawing.Size(87, 18)
        Me.lblIndustrias.TabIndex = 9
        Me.lblIndustrias.Text = "INDUSTRIAS:"
        '
        'txtServiciosColor
        '
        Me.txtServiciosColor.BackColor = System.Drawing.Color.White
        Me.txtServiciosColor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtServiciosColor.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiciosColor.Location = New System.Drawing.Point(175, 74)
        Me.txtServiciosColor.Name = "txtServiciosColor"
        Me.txtServiciosColor.ReadOnly = True
        Me.txtServiciosColor.Size = New System.Drawing.Size(731, 55)
        Me.txtServiciosColor.TabIndex = 6
        Me.txtServiciosColor.Text = "[SERVICIOS]"
        '
        'txtIdiomasColor
        '
        Me.txtIdiomasColor.BackColor = System.Drawing.Color.White
        Me.txtIdiomasColor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIdiomasColor.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdiomasColor.Location = New System.Drawing.Point(175, 140)
        Me.txtIdiomasColor.Name = "txtIdiomasColor"
        Me.txtIdiomasColor.ReadOnly = True
        Me.txtIdiomasColor.Size = New System.Drawing.Size(731, 18)
        Me.txtIdiomasColor.TabIndex = 8
        Me.txtIdiomasColor.Text = "[IDIOMAS]"
        '
        'txtIndustriasColor
        '
        Me.txtIndustriasColor.BackColor = System.Drawing.Color.White
        Me.txtIndustriasColor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIndustriasColor.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndustriasColor.Location = New System.Drawing.Point(175, 169)
        Me.txtIndustriasColor.Name = "txtIndustriasColor"
        Me.txtIndustriasColor.ReadOnly = True
        Me.txtIndustriasColor.Size = New System.Drawing.Size(731, 40)
        Me.txtIndustriasColor.TabIndex = 10
        Me.txtIndustriasColor.Text = "[INDUSTRIAS]"
        '
        'lblSeleccion
        '
        Me.lblSeleccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSeleccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.lblSeleccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSeleccion.Font = New System.Drawing.Font("Calibri", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccion.ForeColor = System.Drawing.Color.White
        Me.lblSeleccion.Location = New System.Drawing.Point(772, 34)
        Me.lblSeleccion.Name = "lblSeleccion"
        Me.lblSeleccion.Size = New System.Drawing.Size(166, 23)
        Me.lblSeleccion.TabIndex = 3
        Me.lblSeleccion.Text = "Socio seleccionado"
        Me.lblSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSeleccion.Visible = False
        '
        'lblCorreo
        '
        Me.lblCorreo.AutoSize = True
        Me.lblCorreo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorreo.Location = New System.Drawing.Point(14, 34)
        Me.lblCorreo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCorreo.Name = "lblCorreo"
        Me.lblCorreo.Size = New System.Drawing.Size(135, 18)
        Me.lblCorreo.TabIndex = 1
        Me.lblCorreo.Text = "[CORREO_PERSONA]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(71, 216)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 18)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "PRESUPUESTO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 244)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 18)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "CAPACIDAD INSTALADA:"
        '
        'txtPresupuesto
        '
        Me.txtPresupuesto.BackColor = System.Drawing.Color.White
        Me.txtPresupuesto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPresupuesto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPresupuesto.Location = New System.Drawing.Point(175, 216)
        Me.txtPresupuesto.Name = "txtPresupuesto"
        Me.txtPresupuesto.ReadOnly = True
        Me.txtPresupuesto.Size = New System.Drawing.Size(731, 18)
        Me.txtPresupuesto.TabIndex = 12
        Me.txtPresupuesto.Text = "100%"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.White
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(175, 244)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(731, 18)
        Me.RichTextBox1.TabIndex = 14
        Me.RichTextBox1.Text = "85%"
        '
        'TarjetaSocio2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.txtPresupuesto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCorreo)
        Me.Controls.Add(Me.lblSeleccion)
        Me.Controls.Add(Me.txtIndustriasColor)
        Me.Controls.Add(Me.txtIdiomasColor)
        Me.Controls.Add(Me.txtServiciosColor)
        Me.Controls.Add(Me.lblIndustrias)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblIdiomas)
        Me.Controls.Add(Me.btnAsignacion)
        Me.Controls.Add(Me.panLinea)
        Me.Controls.Add(Me.lblNombre)
        Me.Name = "TarjetaSocio2"
        Me.Padding = New System.Windows.Forms.Padding(4)
        Me.Size = New System.Drawing.Size(954, 280)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As Label
    Friend WithEvents panLinea As Panel
    Friend WithEvents btnAsignacion As Button
    Friend WithEvents lblIdiomas As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblIndustrias As Label
    Friend WithEvents txtServiciosColor As RichTextBox
    Friend WithEvents txtIdiomasColor As RichTextBox
    Friend WithEvents txtIndustriasColor As RichTextBox
    Friend WithEvents lblSeleccion As Label
    Friend WithEvents lblCorreo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPresupuesto As RichTextBox
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
