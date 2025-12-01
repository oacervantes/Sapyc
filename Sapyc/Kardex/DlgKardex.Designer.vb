<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DlgKardex
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.tabKardex = New System.Windows.Forms.TabControl()
        Me.tabOficinas = New System.Windows.Forms.TabPage()
        Me.tabGeneral = New System.Windows.Forms.TabPage()
        Me.panOficinas = New System.Windows.Forms.Panel()
        Me.gridDivisiones = New System.Windows.Forms.DataGridView()
        Me.btnAgregarOficina = New System.Windows.Forms.Button()
        Me.btnQuitarOficina = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.tabKardex.SuspendLayout()
        Me.tabOficinas.SuspendLayout()
        Me.panOficinas.SuspendLayout()
        CType(Me.gridDivisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.tabKardex)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1095, 588)
        Me.panPrincipal.TabIndex = 60
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 36)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(1095, 2)
        Me.panLinea.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(2, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(122, 32)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "KARDEX - "
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(953, 595)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(130, 25)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'tabKardex
        '
        Me.tabKardex.Controls.Add(Me.tabOficinas)
        Me.tabKardex.Controls.Add(Me.tabGeneral)
        Me.tabKardex.ItemSize = New System.Drawing.Size(250, 25)
        Me.tabKardex.Location = New System.Drawing.Point(0, 45)
        Me.tabKardex.Name = "tabKardex"
        Me.tabKardex.SelectedIndex = 0
        Me.tabKardex.Size = New System.Drawing.Size(1092, 540)
        Me.tabKardex.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabKardex.TabIndex = 2
        '
        'tabOficinas
        '
        Me.tabOficinas.Controls.Add(Me.panOficinas)
        Me.tabOficinas.Location = New System.Drawing.Point(4, 29)
        Me.tabOficinas.Name = "tabOficinas"
        Me.tabOficinas.Size = New System.Drawing.Size(1084, 507)
        Me.tabOficinas.TabIndex = 0
        Me.tabOficinas.Text = "OFICINAS Y DIVISIONES"
        Me.tabOficinas.UseVisualStyleBackColor = True
        '
        'tabGeneral
        '
        Me.tabGeneral.Location = New System.Drawing.Point(4, 29)
        Me.tabGeneral.Margin = New System.Windows.Forms.Padding(0)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGeneral.Size = New System.Drawing.Size(1084, 507)
        Me.tabGeneral.TabIndex = 1
        Me.tabGeneral.Text = "DATOS GENERALES"
        Me.tabGeneral.UseVisualStyleBackColor = True
        '
        'panOficinas
        '
        Me.panOficinas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panOficinas.Controls.Add(Me.btnQuitarOficina)
        Me.panOficinas.Controls.Add(Me.btnAgregarOficina)
        Me.panOficinas.Controls.Add(Me.gridDivisiones)
        Me.panOficinas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panOficinas.Location = New System.Drawing.Point(0, 0)
        Me.panOficinas.Name = "panOficinas"
        Me.panOficinas.Size = New System.Drawing.Size(1084, 507)
        Me.panOficinas.TabIndex = 0
        '
        'gridDivisiones
        '
        Me.gridDivisiones.AllowUserToAddRows = False
        Me.gridDivisiones.AllowUserToDeleteRows = False
        Me.gridDivisiones.AllowUserToResizeRows = False
        Me.gridDivisiones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridDivisiones.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridDivisiones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.gridDivisiones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridDivisiones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridDivisiones.ColumnHeadersHeight = 45
        Me.gridDivisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridDivisiones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridDivisiones.GridColor = System.Drawing.Color.Gainsboro
        Me.gridDivisiones.Location = New System.Drawing.Point(17, 19)
        Me.gridDivisiones.MultiSelect = False
        Me.gridDivisiones.Name = "gridDivisiones"
        Me.gridDivisiones.RowHeadersWidth = 25
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gridDivisiones.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridDivisiones.RowTemplate.Height = 24
        Me.gridDivisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridDivisiones.Size = New System.Drawing.Size(717, 375)
        Me.gridDivisiones.TabIndex = 3
        '
        'btnAgregarOficina
        '
        Me.btnAgregarOficina.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregarOficina.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarOficina.Location = New System.Drawing.Point(17, 404)
        Me.btnAgregarOficina.Name = "btnAgregarOficina"
        Me.btnAgregarOficina.Size = New System.Drawing.Size(130, 25)
        Me.btnAgregarOficina.TabIndex = 4
        Me.btnAgregarOficina.Text = "Agregar"
        Me.btnAgregarOficina.UseVisualStyleBackColor = True
        '
        'btnQuitarOficina
        '
        Me.btnQuitarOficina.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuitarOficina.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitarOficina.Location = New System.Drawing.Point(153, 404)
        Me.btnQuitarOficina.Name = "btnQuitarOficina"
        Me.btnQuitarOficina.Size = New System.Drawing.Size(130, 25)
        Me.btnQuitarOficina.TabIndex = 5
        Me.btnQuitarOficina.Text = "Quitar"
        Me.btnQuitarOficina.UseVisualStyleBackColor = True
        '
        'DlgKardex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 628)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgKardex"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DlgKardex"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.tabKardex.ResumeLayout(False)
        Me.tabOficinas.ResumeLayout(False)
        Me.panOficinas.ResumeLayout(False)
        CType(Me.gridDivisiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents tabKardex As TabControl
    Friend WithEvents tabOficinas As TabPage
    Friend WithEvents tabGeneral As TabPage
    Friend WithEvents panOficinas As Panel
    Friend WithEvents btnQuitarOficina As Button
    Friend WithEvents btnAgregarOficina As Button
    Friend WithEvents gridDivisiones As DataGridView
End Class
