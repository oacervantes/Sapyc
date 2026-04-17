Imports System.Drawing
Imports System.Windows.Forms

Public Class TarjetaSocio

    Private ReadOnly panelHeader As New Panel()
    Private ReadOnly pic As New PictureBox()
    Private ReadOnly lblTitulo As New Label()
    Private ReadOnly tbl As New TableLayoutPanel()
    Private ReadOnly toolTip1 As New ToolTip()

    Public Event CardClick(socioId As String)
    Public Property SocioId As String

    Public Property Titulo As String
        Get
            Return lblTitulo.Text
        End Get
        Set(value As String)
            lblTitulo.Text = value
        End Set
    End Property

    Private _detalles As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))()
    Public Property Detalles As List(Of KeyValuePair(Of String, String))
        Get
            Return _detalles
        End Get
        Set(value As List(Of KeyValuePair(Of String, String)))
            _detalles = If(value, New List(Of KeyValuePair(Of String, String))())
            RenderDetalles()
        End Set
    End Property


    Public Sub New()
        ' Dimensiones base de la card
        Width = 360
        Height = 240
        Margin = New Padding(8)
        Padding = New Padding(8)
        BackColor = Color.White
        BorderStyle = BorderStyle.FixedSingle
        Cursor = Cursors.Hand

        ' Header (foto + título)
        panelHeader.Dock = DockStyle.Top
        panelHeader.Height = 68
        panelHeader.BackColor = Color.White

        pic.SizeMode = PictureBoxSizeMode.CenterImage
        pic.Width = 56
        pic.Height = 56
        pic.Left = 8
        pic.Top = 6
        pic.BackColor = Color.Gainsboro
        pic.BorderStyle = BorderStyle.FixedSingle
        pic.Image = GenerarPlaceholderImagen(pic.Width, pic.Height, "SOC")

        lblTitulo.AutoSize = False
        lblTitulo.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblTitulo.Left = pic.Right + 10
        lblTitulo.Top = 8
        lblTitulo.Width = Me.Width - lblTitulo.Left - 16
        lblTitulo.Height = 44
        lblTitulo.Text = "(Nombre)"

        panelHeader.Controls.Add(pic)
        panelHeader.Controls.Add(lblTitulo)

        ' Tabla de detalles (2 columnas)
        tbl.Dock = DockStyle.Fill
        tbl.ColumnCount = 2
        tbl.RowCount = 0
        tbl.Padding = New Padding(2)
        tbl.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 98)) ' Etiquetas
        tbl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100)) ' Valores

        Controls.Add(tbl)
        Controls.Add(panelHeader)

        ' Clicks y hover
        AddHandler Click, AddressOf OnAnyClick
        AddHandler panelHeader.Click, AddressOf OnAnyClick
        AddHandler pic.Click, AddressOf OnAnyClick
        AddHandler lblTitulo.Click, AddressOf OnAnyClick

        AddHandler MouseEnter, Sub() BackColor = Color.FromArgb(248, 250, 252)
        AddHandler MouseLeave, Sub() BackColor = Color.White
    End Sub

    Private Sub OnAnyClick(sender As Object, e As EventArgs)
        RaiseEvent CardClick(SocioId)
    End Sub

    Private Sub RenderDetalles()
        tbl.SuspendLayout()
        tbl.Controls.Clear()
        tbl.RowStyles.Clear()
        tbl.RowCount = 0

        ' Máximo 15 campos
        For Each kvp In _detalles.Take(15)
            ' Etiqueta
            Dim lblKey As New Label() With {
                .Text = kvp.Key,
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .ForeColor = Color.FromArgb(71, 85, 105),
                .AutoSize = False,
                .TextAlign = ContentAlignment.TopRight,
                .Dock = DockStyle.Fill,
                .Padding = New Padding(0, 3, 6, 3)
            }

            ' Valor multilínea (envuelve)
            Dim lblVal As New Label() With {
                .Text = If(kvp.Value, String.Empty),
                .Font = New Font("Segoe UI", 9, FontStyle.Regular),
                .ForeColor = Color.FromArgb(17, 24, 39),
                .AutoSize = True,
                .MaximumSize = New Size(Me.Width - 98 - 20, 0), ' ancho restante de la col2
                .Padding = New Padding(0, 3, 0, 3)
            }

            ' Tooltip para textos largos
            If lblVal.Text.Length > 60 Then
                toolTip1.SetToolTip(lblVal, lblVal.Text)
            End If

            tbl.RowCount += 1
            tbl.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            tbl.Controls.Add(lblKey, 0, tbl.RowCount - 1)
            tbl.Controls.Add(lblVal, 1, tbl.RowCount - 1)
        Next

        tbl.ResumeLayout()
    End Sub

    Private Function GenerarPlaceholderImagen(w As Integer, h As Integer, iniciales As String) As Image
        Dim bmp As New Bitmap(w, h)
        Using g = Graphics.FromImage(bmp)
            g.Clear(Color.Gainsboro)
            Using br As New SolidBrush(Color.DimGray)
                Using f As New Font("Segoe UI", 9, FontStyle.Bold)
                    Dim sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    g.DrawString(iniciales, f, br, New RectangleF(0, 0, w, h), sf)
                End Using
            End Using
        End Using
        Return bmp
    End Function

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        lblTitulo.Width = Width - lblTitulo.Left - 16

        ' reajusta el ancho máximo de los valores para seguir envolviendo
        For Each ctl As Control In tbl.Controls
            Dim lblVal = TryCast(ctl, Label)
            If lblVal IsNot Nothing AndAlso lblVal.Font.Style = FontStyle.Regular Then
                lblVal.MaximumSize = New Size(Width - 98 - 20, 0)
            End If
        Next
    End Sub

End Class