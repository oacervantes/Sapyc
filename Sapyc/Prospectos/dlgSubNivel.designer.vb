<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSubNivel
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgSubNivel))
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.gridDatos = New System.Windows.Forms.DataGridView()
        Me.txtSubNivel = New System.Windows.Forms.TextBox()
        Me.lblSubNivel = New System.Windows.Forms.Label()
        Me.panHeader = New System.Windows.Forms.Panel()
        Me.lblSubSector = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        CType(Me.gridDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'panLinea
        '
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 32)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(545, 2)
        Me.panLinea.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(402, 464)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(130, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(266, 464)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(130, 25)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'gridDatos
        '
        Me.gridDatos.AllowUserToAddRows = False
        Me.gridDatos.AllowUserToDeleteRows = False
        Me.gridDatos.AllowUserToResizeColumns = False
        Me.gridDatos.AllowUserToResizeRows = False
        Me.gridDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridDatos.ColumnHeadersHeight = 40
        Me.gridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridDatos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridDatos.GridColor = System.Drawing.Color.Gainsboro
        Me.gridDatos.Location = New System.Drawing.Point(12, 103)
        Me.gridDatos.MultiSelect = False
        Me.gridDatos.Name = "gridDatos"
        Me.gridDatos.RowHeadersWidth = 25
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gridDatos.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridDatos.RowTemplate.Height = 26
        Me.gridDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridDatos.Size = New System.Drawing.Size(518, 218)
        Me.gridDatos.TabIndex = 5
        '
        'txtSubNivel
        '
        Me.txtSubNivel.Location = New System.Drawing.Point(97, 66)
        Me.txtSubNivel.Name = "txtSubNivel"
        Me.txtSubNivel.Size = New System.Drawing.Size(434, 25)
        Me.txtSubNivel.TabIndex = 4
        '
        'lblSubNivel
        '
        Me.lblSubNivel.AutoSize = True
        Me.lblSubNivel.Location = New System.Drawing.Point(13, 70)
        Me.lblSubNivel.Name = "lblSubNivel"
        Me.lblSubNivel.Size = New System.Drawing.Size(66, 18)
        Me.lblSubNivel.TabIndex = 3
        Me.lblSubNivel.Text = "Subnivel:"
        '
        'panHeader
        '
        Me.panHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panHeader.BackColor = System.Drawing.Color.White
        Me.panHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panHeader.Controls.Add(Me.txtDescripcion)
        Me.panHeader.Controls.Add(Me.lblDescripcion)
        Me.panHeader.Controls.Add(Me.panLinea)
        Me.panHeader.Controls.Add(Me.lblSubSector)
        Me.panHeader.Controls.Add(Me.lblTitulo)
        Me.panHeader.Controls.Add(Me.gridDatos)
        Me.panHeader.Controls.Add(Me.lblSubNivel)
        Me.panHeader.Controls.Add(Me.txtSubNivel)
        Me.panHeader.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panHeader.Location = New System.Drawing.Point(0, 0)
        Me.panHeader.Name = "panHeader"
        Me.panHeader.Size = New System.Drawing.Size(545, 457)
        Me.panHeader.TabIndex = 0
        '
        'lblSubSector
        '
        Me.lblSubSector.AutoSize = True
        Me.lblSubSector.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubSector.Location = New System.Drawing.Point(15, 41)
        Me.lblSubSector.Name = "lblSubSector"
        Me.lblSubSector.Size = New System.Drawing.Size(100, 16)
        Me.lblSubSector.TabIndex = 2
        Me.lblSubSector.Text = "SUB-SECTOR"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(2, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(134, 29)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "SUBNIVELES"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(12, 329)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(80, 18)
        Me.lblDescripcion.TabIndex = 6
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(12, 352)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(518, 92)
        Me.txtDescripcion.TabIndex = 7
        '
        'dlgSubNivel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 498)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.panHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSubNivel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seleccionar Sub-Nivel..."
        CType(Me.gridDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panHeader.ResumeLayout(False)
        Me.panHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panLinea As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents gridDatos As System.Windows.Forms.DataGridView
    Friend WithEvents txtSubNivel As System.Windows.Forms.TextBox
    Friend WithEvents lblSubNivel As System.Windows.Forms.Label
    Friend WithEvents panHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblSubSector As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents lblDescripcion As Label
End Class
