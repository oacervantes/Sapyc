<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgPropuesta
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
        Me.BSalir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkInd = New System.Windows.Forms.CheckBox()
        Me.chkCC = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.lblAct = New System.Windows.Forms.Label()
        Me.lblGiro = New System.Windows.Forms.Label()
        Me.lblOfi = New System.Windows.Forms.Label()
        Me.lblCont = New System.Windows.Forms.Label()
        Me.lblCargo = New System.Windows.Forms.Label()
        Me.lblDivi = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblRfc = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BSalir
        '
        Me.BSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BSalir.Location = New System.Drawing.Point(338, 300)
        Me.BSalir.Name = "BSalir"
        Me.BSalir.Size = New System.Drawing.Size(74, 25)
        Me.BSalir.TabIndex = 55
        Me.BSalir.Text = "Salir"
        Me.BSalir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 310
        Me.Label2.Text = "Nombre :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 311
        Me.Label1.Text = "Actividad :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(47, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 312
        Me.Label3.Text = "Giro :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 313
        Me.Label4.Text = "Oficina :"
        '
        'chkInd
        '
        Me.chkInd.AutoSize = True
        Me.chkInd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInd.Location = New System.Drawing.Point(22, 267)
        Me.chkInd.Name = "chkInd"
        Me.chkInd.Size = New System.Drawing.Size(182, 17)
        Me.chkInd.TabIndex = 315
        Me.chkInd.Text = "Conflicto de Independencia"
        Me.chkInd.UseVisualStyleBackColor = True
        '
        'chkCC
        '
        Me.chkCC.AutoSize = True
        Me.chkCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCC.Location = New System.Drawing.Point(284, 267)
        Me.chkCC.Name = "chkCC"
        Me.chkCC.Size = New System.Drawing.Size(108, 17)
        Me.chkCC.TabIndex = 316
        Me.chkCC.Text = "Conflict check"
        Me.chkCC.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 317
        Me.Label5.Text = "Contacto :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(37, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 318
        Me.Label6.Text = "Cargo :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 319
        Me.Label7.Text = "Division :"
        '
        'lblNom
        '
        Me.lblNom.AutoSize = True
        Me.lblNom.Location = New System.Drawing.Point(94, 21)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(10, 13)
        Me.lblNom.TabIndex = 320
        Me.lblNom.Text = "."
        '
        'lblAct
        '
        Me.lblAct.AutoSize = True
        Me.lblAct.Location = New System.Drawing.Point(94, 49)
        Me.lblAct.Name = "lblAct"
        Me.lblAct.Size = New System.Drawing.Size(10, 13)
        Me.lblAct.TabIndex = 321
        Me.lblAct.Text = "."
        '
        'lblGiro
        '
        Me.lblGiro.AutoSize = True
        Me.lblGiro.Location = New System.Drawing.Point(94, 77)
        Me.lblGiro.Name = "lblGiro"
        Me.lblGiro.Size = New System.Drawing.Size(10, 13)
        Me.lblGiro.TabIndex = 322
        Me.lblGiro.Text = "."
        '
        'lblOfi
        '
        Me.lblOfi.AutoSize = True
        Me.lblOfi.Location = New System.Drawing.Point(94, 105)
        Me.lblOfi.Name = "lblOfi"
        Me.lblOfi.Size = New System.Drawing.Size(10, 13)
        Me.lblOfi.TabIndex = 323
        Me.lblOfi.Text = "."
        '
        'lblCont
        '
        Me.lblCont.AutoSize = True
        Me.lblCont.Location = New System.Drawing.Point(94, 133)
        Me.lblCont.Name = "lblCont"
        Me.lblCont.Size = New System.Drawing.Size(10, 13)
        Me.lblCont.TabIndex = 324
        Me.lblCont.Text = "."
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Location = New System.Drawing.Point(94, 161)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(10, 13)
        Me.lblCargo.TabIndex = 325
        Me.lblCargo.Text = "."
        '
        'lblDivi
        '
        Me.lblDivi.AutoSize = True
        Me.lblDivi.Location = New System.Drawing.Point(94, 189)
        Me.lblDivi.Name = "lblDivi"
        Me.lblDivi.Size = New System.Drawing.Size(10, 13)
        Me.lblDivi.TabIndex = 326
        Me.lblDivi.Text = "."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(37, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 327
        Me.Label8.Text = "RFC :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(37, 238)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 328
        Me.Label9.Text = "Fecha :"
        '
        'lblRfc
        '
        Me.lblRfc.AutoSize = True
        Me.lblRfc.Location = New System.Drawing.Point(94, 216)
        Me.lblRfc.Name = "lblRfc"
        Me.lblRfc.Size = New System.Drawing.Size(10, 13)
        Me.lblRfc.TabIndex = 329
        Me.lblRfc.Text = "."
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(94, 238)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(10, 13)
        Me.lblFecha.TabIndex = 330
        Me.lblFecha.Text = "."
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(22, 300)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(74, 25)
        Me.btnGuardar.TabIndex = 331
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'DlgPropuesta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 337)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblRfc)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblDivi)
        Me.Controls.Add(Me.lblCargo)
        Me.Controls.Add(Me.lblCont)
        Me.Controls.Add(Me.lblOfi)
        Me.Controls.Add(Me.lblGiro)
        Me.Controls.Add(Me.lblAct)
        Me.Controls.Add(Me.lblNom)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkCC)
        Me.Controls.Add(Me.chkInd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BSalir)
        Me.Name = "DlgPropuesta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle propuesta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BSalir As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chkInd As CheckBox
    Friend WithEvents chkCC As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblNom As Label
    Friend WithEvents lblAct As Label
    Friend WithEvents lblGiro As Label
    Friend WithEvents lblOfi As Label
    Friend WithEvents lblCont As Label
    Friend WithEvents lblCargo As Label
    Friend WithEvents lblDivi As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblRfc As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents btnGuardar As Button
End Class
