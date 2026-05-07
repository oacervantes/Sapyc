<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TarjetaSocio2
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.txtCapacidadInstalada = New System.Windows.Forms.RichTextBox()
        Me.txtValida = New System.Windows.Forms.TextBox()
        Me.txtNormatividadColor = New System.Windows.Forms.RichTextBox()
        Me.lblNormatividad = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.picSeleccion = New System.Windows.Forms.PictureBox()
        Me.panHeader = New System.Windows.Forms.Panel()
        CType(Me.picSeleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblNombre.Location = New System.Drawing.Point(55, 7)
        Me.lblNombre.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(207, 27)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "[NOMBRE_PERSONA]"
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.DarkGray
        Me.panLinea.Location = New System.Drawing.Point(0, 82)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(986, 2)
        Me.panLinea.TabIndex = 5
        '
        'btnAsignacion
        '
        Me.btnAsignacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btnAsignacion.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAsignacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan
        Me.btnAsignacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise
        Me.btnAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsignacion.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsignacion.ForeColor = System.Drawing.Color.White
        Me.btnAsignacion.Location = New System.Drawing.Point(801, 25)
        Me.btnAsignacion.Name = "btnAsignacion"
        Me.btnAsignacion.Size = New System.Drawing.Size(166, 29)
        Me.btnAsignacion.TabIndex = 3
        Me.btnAsignacion.Text = "ELEGIR"
        Me.btnAsignacion.UseVisualStyleBackColor = False
        '
        'lblIdiomas
        '
        Me.lblIdiomas.AutoSize = True
        Me.lblIdiomas.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdiomas.ForeColor = System.Drawing.Color.Black
        Me.lblIdiomas.Location = New System.Drawing.Point(18, 157)
        Me.lblIdiomas.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIdiomas.Name = "lblIdiomas"
        Me.lblIdiomas.Size = New System.Drawing.Size(68, 18)
        Me.lblIdiomas.TabIndex = 8
        Me.lblIdiomas.Text = "IDIOMAS:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 94)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "SERVICIOS:"
        '
        'lblIndustrias
        '
        Me.lblIndustrias.AutoSize = True
        Me.lblIndustrias.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIndustrias.ForeColor = System.Drawing.Color.Black
        Me.lblIndustrias.Location = New System.Drawing.Point(18, 183)
        Me.lblIndustrias.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIndustrias.Name = "lblIndustrias"
        Me.lblIndustrias.Size = New System.Drawing.Size(87, 18)
        Me.lblIndustrias.TabIndex = 10
        Me.lblIndustrias.Text = "INDUSTRIAS:"
        '
        'txtServiciosColor
        '
        Me.txtServiciosColor.BackColor = System.Drawing.Color.White
        Me.txtServiciosColor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtServiciosColor.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiciosColor.Location = New System.Drawing.Point(181, 94)
        Me.txtServiciosColor.Name = "txtServiciosColor"
        Me.txtServiciosColor.ReadOnly = True
        Me.txtServiciosColor.Size = New System.Drawing.Size(755, 55)
        Me.txtServiciosColor.TabIndex = 7
        Me.txtServiciosColor.Text = "[SERVICIOS]"
        '
        'txtIdiomasColor
        '
        Me.txtIdiomasColor.BackColor = System.Drawing.Color.White
        Me.txtIdiomasColor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIdiomasColor.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdiomasColor.Location = New System.Drawing.Point(181, 157)
        Me.txtIdiomasColor.Name = "txtIdiomasColor"
        Me.txtIdiomasColor.ReadOnly = True
        Me.txtIdiomasColor.Size = New System.Drawing.Size(755, 18)
        Me.txtIdiomasColor.TabIndex = 9
        Me.txtIdiomasColor.Text = "[IDIOMAS]"
        '
        'txtIndustriasColor
        '
        Me.txtIndustriasColor.BackColor = System.Drawing.Color.White
        Me.txtIndustriasColor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIndustriasColor.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndustriasColor.Location = New System.Drawing.Point(181, 183)
        Me.txtIndustriasColor.Name = "txtIndustriasColor"
        Me.txtIndustriasColor.ReadOnly = True
        Me.txtIndustriasColor.Size = New System.Drawing.Size(755, 40)
        Me.txtIndustriasColor.TabIndex = 11
        Me.txtIndustriasColor.Text = "[INDUSTRIAS]"
        '
        'lblSeleccion
        '
        Me.lblSeleccion.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccion.ForeColor = System.Drawing.Color.Silver
        Me.lblSeleccion.Location = New System.Drawing.Point(55, 57)
        Me.lblSeleccion.Name = "lblSeleccion"
        Me.lblSeleccion.Size = New System.Drawing.Size(241, 19)
        Me.lblSeleccion.TabIndex = 4
        Me.lblSeleccion.Text = "Socio por asignar"
        Me.lblSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCorreo
        '
        Me.lblCorreo.AutoSize = True
        Me.lblCorreo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorreo.Location = New System.Drawing.Point(55, 34)
        Me.lblCorreo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCorreo.Name = "lblCorreo"
        Me.lblCorreo.Size = New System.Drawing.Size(142, 19)
        Me.lblCorreo.TabIndex = 1
        Me.lblCorreo.Text = "[CORREO_PERSONA]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 279)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 18)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "PRESUPUESTO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(18, 305)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 18)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "CAPACIDAD INSTALADA:"
        '
        'txtPresupuesto
        '
        Me.txtPresupuesto.BackColor = System.Drawing.Color.White
        Me.txtPresupuesto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPresupuesto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPresupuesto.Location = New System.Drawing.Point(181, 279)
        Me.txtPresupuesto.Name = "txtPresupuesto"
        Me.txtPresupuesto.ReadOnly = True
        Me.txtPresupuesto.Size = New System.Drawing.Size(755, 18)
        Me.txtPresupuesto.TabIndex = 15
        Me.txtPresupuesto.Text = "[PRESUPUESTO]"
        '
        'txtCapacidadInstalada
        '
        Me.txtCapacidadInstalada.BackColor = System.Drawing.Color.White
        Me.txtCapacidadInstalada.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCapacidadInstalada.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapacidadInstalada.Location = New System.Drawing.Point(181, 305)
        Me.txtCapacidadInstalada.Name = "txtCapacidadInstalada"
        Me.txtCapacidadInstalada.ReadOnly = True
        Me.txtCapacidadInstalada.Size = New System.Drawing.Size(755, 18)
        Me.txtCapacidadInstalada.TabIndex = 17
        Me.txtCapacidadInstalada.Text = "[% CAPACIDAD INSTALADA]"
        '
        'txtValida
        '
        Me.txtValida.Location = New System.Drawing.Point(18, 129)
        Me.txtValida.Name = "txtValida"
        Me.txtValida.Size = New System.Drawing.Size(100, 20)
        Me.txtValida.TabIndex = 2
        Me.txtValida.Visible = False
        '
        'txtNormatividadColor
        '
        Me.txtNormatividadColor.BackColor = System.Drawing.Color.White
        Me.txtNormatividadColor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNormatividadColor.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNormatividadColor.Location = New System.Drawing.Point(181, 231)
        Me.txtNormatividadColor.Name = "txtNormatividadColor"
        Me.txtNormatividadColor.ReadOnly = True
        Me.txtNormatividadColor.Size = New System.Drawing.Size(755, 40)
        Me.txtNormatividadColor.TabIndex = 13
        Me.txtNormatividadColor.Text = "[MARCO NORMATIVO]"
        '
        'lblNormatividad
        '
        Me.lblNormatividad.AutoSize = True
        Me.lblNormatividad.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNormatividad.ForeColor = System.Drawing.Color.Black
        Me.lblNormatividad.Location = New System.Drawing.Point(18, 231)
        Me.lblNormatividad.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNormatividad.Name = "lblNormatividad"
        Me.lblNormatividad.Size = New System.Drawing.Size(142, 18)
        Me.lblNormatividad.TabIndex = 12
        Me.lblNormatividad.Text = "MARCO NORMATIVO:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Location = New System.Drawing.Point(181, 300)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(787, 2)
        Me.Panel1.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Location = New System.Drawing.Point(181, 274)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(787, 2)
        Me.Panel2.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Location = New System.Drawing.Point(181, 226)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(787, 2)
        Me.Panel3.TabIndex = 7
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Location = New System.Drawing.Point(181, 178)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(787, 2)
        Me.Panel4.TabIndex = 18
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Location = New System.Drawing.Point(181, 152)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(787, 2)
        Me.Panel5.TabIndex = 19
        '
        'picSeleccion
        '
        Me.picSeleccion.Image = Global.Sapyc.My.Resources.Resources.check
        Me.picSeleccion.Location = New System.Drawing.Point(16, 25)
        Me.picSeleccion.Name = "picSeleccion"
        Me.picSeleccion.Size = New System.Drawing.Size(32, 29)
        Me.picSeleccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picSeleccion.TabIndex = 20
        Me.picSeleccion.TabStop = False
        Me.picSeleccion.Visible = False
        '
        'panHeader
        '
        Me.panHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.panHeader.Controls.Add(Me.lblNombre)
        Me.panHeader.Controls.Add(Me.btnAsignacion)
        Me.panHeader.Controls.Add(Me.picSeleccion)
        Me.panHeader.Controls.Add(Me.lblSeleccion)
        Me.panHeader.Controls.Add(Me.lblCorreo)
        Me.panHeader.Location = New System.Drawing.Point(0, 0)
        Me.panHeader.Name = "panHeader"
        Me.panHeader.Size = New System.Drawing.Size(986, 82)
        Me.panHeader.TabIndex = 21
        '
        'TarjetaSocio2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.panHeader)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtNormatividadColor)
        Me.Controls.Add(Me.lblNormatividad)
        Me.Controls.Add(Me.txtValida)
        Me.Controls.Add(Me.txtCapacidadInstalada)
        Me.Controls.Add(Me.txtPresupuesto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIndustriasColor)
        Me.Controls.Add(Me.txtIdiomasColor)
        Me.Controls.Add(Me.txtServiciosColor)
        Me.Controls.Add(Me.lblIndustrias)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblIdiomas)
        Me.Controls.Add(Me.panLinea)
        Me.Name = "TarjetaSocio2"
        Me.Padding = New System.Windows.Forms.Padding(4)
        Me.Size = New System.Drawing.Size(986, 340)
        CType(Me.picSeleccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panHeader.ResumeLayout(False)
        Me.panHeader.PerformLayout()
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
    Friend WithEvents txtCapacidadInstalada As RichTextBox
    Friend WithEvents txtValida As TextBox
    Friend WithEvents txtNormatividadColor As RichTextBox
    Friend WithEvents lblNormatividad As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents picSeleccion As PictureBox
    Friend WithEvents panHeader As Panel
End Class
