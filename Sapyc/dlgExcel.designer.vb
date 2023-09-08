<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgExcel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgExcel))
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.lblDirectorio = New System.Windows.Forms.Label
        Me.lblArchivo = New System.Windows.Forms.Label
        Me.txtDirectorio = New System.Windows.Forms.TextBox
        Me.txtArchivo = New System.Windows.Forms.TextBox
        Me.btnCarpeta = New System.Windows.Forms.Button
        Me.dlgCarpeta = New System.Windows.Forms.FolderBrowserDialog
        Me.panDatos = New System.Windows.Forms.Panel
        Me.lblExtension = New System.Windows.Forms.Label
        Me.lblTexto = New System.Windows.Forms.Label
        Me.panDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.BackColor = System.Drawing.Color.Transparent
        Me.OK_Button.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(281, 220)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(91, 25)
        Me.OK_Button.TabIndex = 1
        Me.OK_Button.Text = "Aceptar"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.BackColor = System.Drawing.Color.Transparent
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(378, 220)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(91, 25)
        Me.Cancel_Button.TabIndex = 2
        Me.Cancel_Button.Text = "Cancelar"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'lblDirectorio
        '
        Me.lblDirectorio.AutoSize = True
        Me.lblDirectorio.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirectorio.Location = New System.Drawing.Point(33, 63)
        Me.lblDirectorio.Name = "lblDirectorio"
        Me.lblDirectorio.Size = New System.Drawing.Size(128, 18)
        Me.lblDirectorio.TabIndex = 1
        Me.lblDirectorio.Text = "Seleccionar carpeta"
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchivo.Location = New System.Drawing.Point(33, 129)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(132, 18)
        Me.lblArchivo.TabIndex = 4
        Me.lblArchivo.Text = "Nombre del reporte"
        '
        'txtDirectorio
        '
        Me.txtDirectorio.BackColor = System.Drawing.Color.White
        Me.txtDirectorio.Enabled = False
        Me.txtDirectorio.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirectorio.Location = New System.Drawing.Point(33, 87)
        Me.txtDirectorio.Name = "txtDirectorio"
        Me.txtDirectorio.ReadOnly = True
        Me.txtDirectorio.Size = New System.Drawing.Size(362, 25)
        Me.txtDirectorio.TabIndex = 2
        '
        'txtArchivo
        '
        Me.txtArchivo.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.Location = New System.Drawing.Point(33, 152)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(362, 25)
        Me.txtArchivo.TabIndex = 5
        '
        'btnCarpeta
        '
        Me.btnCarpeta.Location = New System.Drawing.Point(401, 87)
        Me.btnCarpeta.Name = "btnCarpeta"
        Me.btnCarpeta.Size = New System.Drawing.Size(44, 25)
        Me.btnCarpeta.TabIndex = 3
        Me.btnCarpeta.Text = "..."
        Me.btnCarpeta.UseVisualStyleBackColor = True
        '
        'dlgCarpeta
        '
        Me.dlgCarpeta.Description = "Seleccione la carpeta donde desea guardar el archivo de Excel que generará SIAT:"
        Me.dlgCarpeta.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'panDatos
        '
        Me.panDatos.BackColor = System.Drawing.Color.White
        Me.panDatos.Controls.Add(Me.lblExtension)
        Me.panDatos.Controls.Add(Me.lblTexto)
        Me.panDatos.Controls.Add(Me.lblDirectorio)
        Me.panDatos.Controls.Add(Me.btnCarpeta)
        Me.panDatos.Controls.Add(Me.lblArchivo)
        Me.panDatos.Controls.Add(Me.txtArchivo)
        Me.panDatos.Controls.Add(Me.txtDirectorio)
        Me.panDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.panDatos.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panDatos.Location = New System.Drawing.Point(0, 0)
        Me.panDatos.Name = "panDatos"
        Me.panDatos.Size = New System.Drawing.Size(478, 213)
        Me.panDatos.TabIndex = 0
        '
        'lblExtension
        '
        Me.lblExtension.AutoSize = True
        Me.lblExtension.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExtension.Location = New System.Drawing.Point(400, 156)
        Me.lblExtension.Name = "lblExtension"
        Me.lblExtension.Size = New System.Drawing.Size(36, 18)
        Me.lblExtension.TabIndex = 6
        Me.lblExtension.Text = ".xlsx"
        '
        'lblTexto
        '
        Me.lblTexto.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.lblTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTexto.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTexto.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto.ForeColor = System.Drawing.Color.White
        Me.lblTexto.Location = New System.Drawing.Point(0, 0)
        Me.lblTexto.Name = "lblTexto"
        Me.lblTexto.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblTexto.Size = New System.Drawing.Size(478, 39)
        Me.lblTexto.TabIndex = 0
        Me.lblTexto.Text = "EXPORTAR A EXCEL"
        Me.lblTexto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dlgExcel
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(478, 253)
        Me.ControlBox = False
        Me.Controls.Add(Me.panDatos)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgExcel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.panDatos.ResumeLayout(False)
        Me.panDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lblDirectorio As System.Windows.Forms.Label
    Friend WithEvents lblArchivo As System.Windows.Forms.Label
    Friend WithEvents txtDirectorio As System.Windows.Forms.TextBox
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents btnCarpeta As System.Windows.Forms.Button
    Friend WithEvents dlgCarpeta As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents panDatos As System.Windows.Forms.Panel
    Friend WithEvents lblExtension As System.Windows.Forms.Label
    Friend WithEvents lblTexto As System.Windows.Forms.Label

End Class
