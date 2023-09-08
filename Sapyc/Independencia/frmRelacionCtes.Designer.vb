<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelacionCtes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRelacionCtes))
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgCtes = New System.Windows.Forms.DataGridView()
        Me.panLinea = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        CType(Me.dgCtes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPrincipal.BackColor = System.Drawing.Color.White
        Me.panPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panPrincipal.Controls.Add(Me.txtCliente)
        Me.panPrincipal.Controls.Add(Me.Label1)
        Me.panPrincipal.Controls.Add(Me.dgCtes)
        Me.panPrincipal.Controls.Add(Me.panLinea)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1182, 645)
        Me.panPrincipal.TabIndex = 3
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(78, 52)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(1087, 25)
        Me.txtCliente.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Cliente:"
        '
        'dgCtes
        '
        Me.dgCtes.AllowUserToAddRows = False
        Me.dgCtes.AllowUserToDeleteRows = False
        Me.dgCtes.AllowUserToOrderColumns = True
        Me.dgCtes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCtes.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgCtes.ColumnHeadersHeight = 40
        Me.dgCtes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCtes.GridColor = System.Drawing.Color.Gainsboro
        Me.dgCtes.Location = New System.Drawing.Point(15, 91)
        Me.dgCtes.Name = "dgCtes"
        Me.dgCtes.RowHeadersWidth = 25
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.dgCtes.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCtes.RowTemplate.Height = 26
        Me.dgCtes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCtes.Size = New System.Drawing.Size(1150, 540)
        Me.dgCtes.TabIndex = 1
        '
        'panLinea
        '
        Me.panLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.panLinea.Location = New System.Drawing.Point(0, 38)
        Me.panLinea.Name = "panLinea"
        Me.panLinea.Size = New System.Drawing.Size(1182, 2)
        Me.panLinea.TabIndex = 27
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(5, 2)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(218, 32)
        Me.lblTitulo.TabIndex = 26
        Me.lblTitulo.Text = " LISTA DE CLIENTES"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(1035, 653)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(130, 25)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(15, 653)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(130, 25)
        Me.btnExportar.TabIndex = 7
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'frmRelacionCtes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 686)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.panPrincipal)
        Me.Controls.Add(Me.btnExportar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRelacionCtes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CLIENTES RELACIONADOS"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        CType(Me.dgCtes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panPrincipal As Panel
    Friend WithEvents panLinea As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents dgCtes As DataGridView
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents Label1 As Label
End Class
