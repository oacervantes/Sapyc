<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaFolios
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaFolios))
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Cuadro = New System.Windows.Forms.TabControl()
        Me.nuevas = New System.Windows.Forms.TabPage()
        Me.dgFolios = New System.Windows.Forms.DataGridView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.Cuadro.SuspendLayout()
        Me.nuevas.SuspendLayout()
        CType(Me.dgFolios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Controls.Add(Me.Cuadro)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1182, 645)
        Me.panPrincipal.TabIndex = 2
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(-1, 38)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(1178, 2)
        Me.panLinea.TabIndex = 27
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(5, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(92, 32)
        Me.lblTitulo.TabIndex = 26
        Me.lblTitulo.Text = "FOLIOS"
        '
        'Cuadro
        '
        Me.Cuadro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cuadro.Controls.Add(Me.nuevas)
        Me.Cuadro.ItemSize = New System.Drawing.Size(260, 30)
        Me.Cuadro.Location = New System.Drawing.Point(-1, 41)
        Me.Cuadro.Name = "Cuadro"
        Me.Cuadro.SelectedIndex = 0
        Me.Cuadro.Size = New System.Drawing.Size(1178, 603)
        Me.Cuadro.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.Cuadro.TabIndex = 7
        '
        'nuevas
        '
        Me.nuevas.Controls.Add(Me.dgFolios)
        Me.nuevas.Location = New System.Drawing.Point(4, 34)
        Me.nuevas.Name = "nuevas"
        Me.nuevas.Size = New System.Drawing.Size(1170, 565)
        Me.nuevas.TabIndex = 0
        Me.nuevas.Text = "FOLIOS EXISTENTES"
        Me.nuevas.UseVisualStyleBackColor = True
        '
        'dgFolios
        '
        Me.dgFolios.AllowUserToAddRows = False
        Me.dgFolios.AllowUserToDeleteRows = False
        Me.dgFolios.AllowUserToOrderColumns = True
        Me.dgFolios.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgFolios.ColumnHeadersHeight = 40
        Me.dgFolios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgFolios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgFolios.GridColor = System.Drawing.Color.Gainsboro
        Me.dgFolios.Location = New System.Drawing.Point(0, 0)
        Me.dgFolios.Name = "dgFolios"
        Me.dgFolios.RowHeadersWidth = 25
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.dgFolios.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgFolios.RowTemplate.Height = 26
        Me.dgFolios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFolios.Size = New System.Drawing.Size(1170, 565)
        Me.dgFolios.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(1059, 649)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(115, 31)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(4, 649)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(115, 31)
        Me.btnExportar.TabIndex = 5
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'frmConsultaFolios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 686)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.panPrincipal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaFolios"
        Me.Text = "CONSULTA FOLIOS"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.Cuadro.ResumeLayout(False)
        Me.nuevas.ResumeLayout(False)
        CType(Me.dgFolios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Cuadro As TabControl
    Friend WithEvents nuevas As TabPage
    Friend WithEvents dgFolios As DataGridView
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnExportar As Button
End Class
