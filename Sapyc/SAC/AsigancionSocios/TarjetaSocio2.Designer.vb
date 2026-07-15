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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCapacidadInstalada = New System.Windows.Forms.RichTextBox()
        Me.txtNormatividadColor = New System.Windows.Forms.RichTextBox()
        Me.lblNormatividad = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.picSeleccion = New System.Windows.Forms.PictureBox()
        Me.panHeader = New System.Windows.Forms.Panel()
        Me.tabDatos = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.lblCorreo = New System.Windows.Forms.Label()
        Me.lblSeleccion = New System.Windows.Forms.Label()
        Me.txtPresupuesto = New System.Windows.Forms.RichTextBox()
        Me.txtCveArea = New System.Windows.Forms.TextBox()
        Me.txtCveOfi = New System.Windows.Forms.TextBox()
        Me.txtPuntuacion = New System.Windows.Forms.TextBox()
        Me.txtValida = New System.Windows.Forms.TextBox()
        Me.txtRecurrentesPorArreglar = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblMeta = New System.Windows.Forms.Label()
        Me.txtMeta = New System.Windows.Forms.Label()
        Me.txtIngreso = New System.Windows.Forms.Label()
        CType(Me.picSeleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panHeader.SuspendLayout()
        Me.tabDatos.SuspendLayout()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 279)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 18)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "META DE INGRESOS:"
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
        Me.panHeader.Controls.Add(Me.tabDatos)
        Me.panHeader.Controls.Add(Me.lblSeleccion)
        Me.panHeader.Controls.Add(Me.lblNombre)
        Me.panHeader.Controls.Add(Me.btnAsignacion)
        Me.panHeader.Controls.Add(Me.picSeleccion)
        Me.panHeader.Location = New System.Drawing.Point(0, 0)
        Me.panHeader.Name = "panHeader"
        Me.panHeader.Size = New System.Drawing.Size(986, 82)
        Me.panHeader.TabIndex = 21
        '
        'tabDatos
        '
        Me.tabDatos.ColumnCount = 3
        Me.tabDatos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tabDatos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tabDatos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tabDatos.Controls.Add(Me.lblDivision, 2, 0)
        Me.tabDatos.Controls.Add(Me.lblOficina, 1, 0)
        Me.tabDatos.Controls.Add(Me.lblCorreo, 0, 0)
        Me.tabDatos.Location = New System.Drawing.Point(55, 36)
        Me.tabDatos.Margin = New System.Windows.Forms.Padding(0)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.RowCount = 1
        Me.tabDatos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tabDatos.Size = New System.Drawing.Size(636, 23)
        Me.tabDatos.TabIndex = 25
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivision.Location = New System.Drawing.Point(444, 0)
        Me.lblDivision.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(123, 19)
        Me.lblDivision.TabIndex = 25
        Me.lblDivision.Text = "[AREA_PERSONA]"
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOficina.Location = New System.Drawing.Point(254, 0)
        Me.lblOficina.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(140, 19)
        Me.lblOficina.TabIndex = 24
        Me.lblOficina.Text = "[OFICINA_PERSONA]"
        '
        'lblCorreo
        '
        Me.lblCorreo.AutoSize = True
        Me.lblCorreo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorreo.Location = New System.Drawing.Point(0, 0)
        Me.lblCorreo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCorreo.Name = "lblCorreo"
        Me.lblCorreo.Size = New System.Drawing.Size(142, 19)
        Me.lblCorreo.TabIndex = 1
        Me.lblCorreo.Text = "[CORREO_PERSONA]"
        '
        'lblSeleccion
        '
        Me.lblSeleccion.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccion.ForeColor = System.Drawing.Color.Silver
        Me.lblSeleccion.Location = New System.Drawing.Point(55, 57)
        Me.lblSeleccion.Name = "lblSeleccion"
        Me.lblSeleccion.Size = New System.Drawing.Size(241, 19)
        Me.lblSeleccion.TabIndex = 24
        Me.lblSeleccion.Text = "Socio por asignar"
        Me.lblSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPresupuesto
        '
        Me.txtPresupuesto.BackColor = System.Drawing.Color.White
        Me.txtPresupuesto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPresupuesto.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPresupuesto.Location = New System.Drawing.Point(181, 279)
        Me.txtPresupuesto.Name = "txtPresupuesto"
        Me.txtPresupuesto.ReadOnly = True
        Me.txtPresupuesto.Size = New System.Drawing.Size(52, 18)
        Me.txtPresupuesto.TabIndex = 27
        Me.txtPresupuesto.Text = "[META]"
        '
        'txtCveArea
        '
        Me.txtCveArea.Location = New System.Drawing.Point(348, 126)
        Me.txtCveArea.Name = "txtCveArea"
        Me.txtCveArea.Size = New System.Drawing.Size(100, 20)
        Me.txtCveArea.TabIndex = 34
        Me.txtCveArea.Visible = False
        '
        'txtCveOfi
        '
        Me.txtCveOfi.Location = New System.Drawing.Point(242, 126)
        Me.txtCveOfi.Name = "txtCveOfi"
        Me.txtCveOfi.Size = New System.Drawing.Size(100, 20)
        Me.txtCveOfi.TabIndex = 33
        Me.txtCveOfi.Visible = False
        '
        'txtPuntuacion
        '
        Me.txtPuntuacion.Location = New System.Drawing.Point(136, 126)
        Me.txtPuntuacion.Name = "txtPuntuacion"
        Me.txtPuntuacion.Size = New System.Drawing.Size(100, 20)
        Me.txtPuntuacion.TabIndex = 32
        Me.txtPuntuacion.Visible = False
        '
        'txtValida
        '
        Me.txtValida.Location = New System.Drawing.Point(21, 129)
        Me.txtValida.Name = "txtValida"
        Me.txtValida.Size = New System.Drawing.Size(100, 20)
        Me.txtValida.TabIndex = 31
        Me.txtValida.Visible = False
        '
        'txtRecurrentesPorArreglar
        '
        Me.txtRecurrentesPorArreglar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecurrentesPorArreglar.Location = New System.Drawing.Point(605, 279)
        Me.txtRecurrentesPorArreglar.Margin = New System.Windows.Forms.Padding(0)
        Me.txtRecurrentesPorArreglar.Name = "txtRecurrentesPorArreglar"
        Me.txtRecurrentesPorArreglar.Size = New System.Drawing.Size(97, 18)
        Me.txtRecurrentesPorArreglar.TabIndex = 40
        Me.txtRecurrentesPorArreglar.Text = "99,000,000.99"
        Me.txtRecurrentesPorArreglar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(737, 279)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 18)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "ING. ARREGLADOS:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(436, 279)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(167, 18)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "ING. REC. POR ARREGLAR:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMeta
        '
        Me.lblMeta.AutoSize = True
        Me.lblMeta.Font = New System.Drawing.Font("Calibri", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeta.Location = New System.Drawing.Point(258, 279)
        Me.lblMeta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMeta.Name = "lblMeta"
        Me.lblMeta.Size = New System.Drawing.Size(47, 18)
        Me.lblMeta.TabIndex = 37
        Me.lblMeta.Text = "META:"
        Me.lblMeta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMeta
        '
        Me.txtMeta.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeta.Location = New System.Drawing.Point(307, 279)
        Me.txtMeta.Margin = New System.Windows.Forms.Padding(0)
        Me.txtMeta.Name = "txtMeta"
        Me.txtMeta.Size = New System.Drawing.Size(97, 18)
        Me.txtMeta.TabIndex = 36
        Me.txtMeta.Text = "99,000,000.99"
        Me.txtMeta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIngreso
        '
        Me.txtIngreso.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngreso.Location = New System.Drawing.Point(866, 279)
        Me.txtIngreso.Margin = New System.Windows.Forms.Padding(0)
        Me.txtIngreso.Name = "txtIngreso"
        Me.txtIngreso.Size = New System.Drawing.Size(97, 18)
        Me.txtIngreso.TabIndex = 35
        Me.txtIngreso.Text = "99,000,000.99"
        Me.txtIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TarjetaSocio2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.txtRecurrentesPorArreglar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblMeta)
        Me.Controls.Add(Me.txtMeta)
        Me.Controls.Add(Me.txtIngreso)
        Me.Controls.Add(Me.txtCveArea)
        Me.Controls.Add(Me.txtCveOfi)
        Me.Controls.Add(Me.txtPuntuacion)
        Me.Controls.Add(Me.txtValida)
        Me.Controls.Add(Me.txtPresupuesto)
        Me.Controls.Add(Me.panHeader)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtNormatividadColor)
        Me.Controls.Add(Me.lblNormatividad)
        Me.Controls.Add(Me.txtCapacidadInstalada)
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
        Me.tabDatos.ResumeLayout(False)
        Me.tabDatos.PerformLayout()
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
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCapacidadInstalada As RichTextBox
    Friend WithEvents txtNormatividadColor As RichTextBox
    Friend WithEvents lblNormatividad As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents picSeleccion As PictureBox
    Friend WithEvents panHeader As Panel
    Friend WithEvents txtPresupuesto As RichTextBox
    Friend WithEvents txtCveArea As TextBox
    Friend WithEvents txtCveOfi As TextBox
    Friend WithEvents txtPuntuacion As TextBox
    Friend WithEvents txtValida As TextBox
    Friend WithEvents tabDatos As TableLayoutPanel
    Friend WithEvents lblDivision As Label
    Friend WithEvents lblOficina As Label
    Friend WithEvents lblCorreo As Label
    Friend WithEvents lblSeleccion As Label
    Friend WithEvents txtRecurrentesPorArreglar As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblMeta As Label
    Friend WithEvents txtMeta As Label
    Friend WithEvents txtIngreso As Label
End Class
