Public Class TarjetaSocio2

    Private ds As New DataSet

    Private sNameRpt As String = "Selección de socios para asignar propuesta"

    Private dtDatosSocio As New DataTable

    Private sCveSocio As String

    Public bSocioReq As Boolean = True

    Public Property SocioId As String
        Get
            Return sCveSocio
        End Get
        Set(value As String)
            sCveSocio = value
        End Set
    End Property
    Public Property Nombre As String
        Get
            Return lblNombre.Text
        End Get
        Set(value As String)
            lblNombre.Text = value
        End Set
    End Property
    Public Property Correo As String
        Get
            Return lblCorreo.Text
        End Get
        Set(value As String)
            lblCorreo.Text = value
        End Set
    End Property
    Public Property Servicio As String
        Get
            Return txtServiciosColor.Text
        End Get
        Set(value As String)
            MostrarTextoConEtiquetas(txtServiciosColor, value)
        End Set
    End Property
    Public Property Idiomas As String
        Get
            Return txtIdiomasColor.Text
        End Get
        Set(value As String)
            MostrarTextoConEtiquetas(txtIdiomasColor, value)
        End Set
    End Property
    Public Property Industrias As String
        Get
            Return txtIndustriasColor.Text
        End Get
        Set(value As String)
            MostrarTextoConEtiquetas(txtIndustriasColor, value)
        End Set
    End Property
    Public Property Marcos As String
        Get
            Return txtNormatividadColor.Text
        End Get
        Set(value As String)
            MostrarTextoConEtiquetas(txtNormatividadColor, value)
        End Set
    End Property
    Public Property Presupuesto As String
        Get
            Return txtPresupuesto.Text
        End Get
        Set(value As String)
            MostrarTextoEvaluandoValor(txtPresupuesto, value)
        End Set
    End Property
    Public Property CapacidadInstalada As String
        Get
            Return txtCapacidadInstalada.Text
        End Get
        Set(value As String)
            MostrarTextoEvaluandoValor(txtCapacidadInstalada, value)
        End Set
    End Property

    Public Event CardClick(sender As TarjetaSocio2)

    'Private Sub OnAnyClick(sender As Object, e As EventArgs) Handles Me.Click, lblNombre.Click
    '    RaiseEvent CardClick(Me)
    'End Sub

    Private Sub BtnAsignacion_Click(sender As Object, e As EventArgs) Handles btnAsignacion.Click
        RaiseEvent CardClick(Me)
    End Sub

    Public Sub MostrarTextoConEtiquetas(rtb As RichTextBox, texto As String)
        rtb.Clear()
        rtb.SelectionColor = Color.Black
        rtb.SelectionFont = New Font(rtb.Font, FontStyle.Regular)

        ' Etiquetas y colores asociados
        Dim etiquetas As New Dictionary(Of String, Color) From {
            {"ERROR", Color.FromArgb(233, 40, 65)},
            {"VACIO", Color.FromArgb(0, 167, 181)}
        }

        Dim i As Integer = 0

        While i < texto.Length

            Dim posInicioMin As Integer = -1
            Dim etiquetaEncontrada As String = Nothing

            ' Buscar la siguiente etiqueta más cercana
            For Each eTag In etiquetas.Keys
                Dim inicioTag As String = "[" & eTag & "]"
                Dim pos As Integer = texto.IndexOf(inicioTag, i)

                If pos <> -1 AndAlso (posInicioMin = -1 OrElse pos < posInicioMin) Then
                    posInicioMin = pos
                    etiquetaEncontrada = eTag
                End If
            Next

            ' No hay más etiquetas
            If posInicioMin = -1 Then
                rtb.SelectionColor = Color.Black
                rtb.SelectionFont = New Font(rtb.Font, FontStyle.Regular)
                rtb.AppendText(texto.Substring(i))
                Exit While
            End If

            ' Texto normal antes de la etiqueta
            If posInicioMin > i Then
                rtb.SelectionColor = Color.Black
                rtb.SelectionFont = New Font(rtb.Font, FontStyle.Regular)
                rtb.AppendText(texto.Substring(i, posInicioMin - i))
            End If

            ' Procesar etiqueta encontrada
            Dim inicioTagCompleto As String = "[" & etiquetaEncontrada & "]"
            Dim finTagCompleto As String = "[/" & etiquetaEncontrada & "]"

            Dim posFin As Integer = texto.IndexOf(finTagCompleto, posInicioMin)
            If posFin = -1 Then Exit While ' Seguridad

            Dim contenido As String =
            texto.Substring(
                posInicioMin + inicioTagCompleto.Length,
                posFin - (posInicioMin + inicioTagCompleto.Length)
            )

            ' Aplicar color y negrita
            rtb.SelectionColor = etiquetas(etiquetaEncontrada)
            rtb.SelectionFont = New Font(rtb.Font, FontStyle.Bold)
            rtb.AppendText(contenido)
            bSocioReq = False

            ' Avanzar índice
            i = posFin + finTagCompleto.Length
        End While

        ' Reset final
        rtb.SelectionColor = Color.Black
        rtb.SelectionFont = New Font(rtb.Font, FontStyle.Regular)
        txtValida.Text = bSocioReq.ToString()
    End Sub

    Public Sub MostrarTextoEvaluandoValor(rtb As RichTextBox, texto As String)
        rtb.Clear()

        ' Quitar el símbolo %
        Dim textoSinPorcentaje As String = texto.Replace("%", "").Trim()

        Dim valor As Decimal

        If Decimal.TryParse(textoSinPorcentaje, valor) AndAlso valor >= 100 Then
            rtb.SelectionColor = Color.FromArgb(233, 40, 65)
            rtb.SelectionFont = New Font(rtb.Font, FontStyle.Bold)
        Else
            rtb.SelectionColor = Color.Black
            rtb.SelectionFont = New Font(rtb.Font, FontStyle.Regular)
        End If

        rtb.AppendText(CInt(textoSinPorcentaje) & "%")
        rtb.SelectionColor = Color.Black
    End Sub

    Public Sub MostrarSeleccion()
        lblSeleccion.Visible = True
        lblSeleccion.Text = "Socio propuesto para asignación"
        lblSeleccion.ForeColor = Color.DarkCyan
        picSeleccion.Visible = True
        btnAsignacion.Visible = False
    End Sub
    Public Sub OcultarSeleccion()
        lblSeleccion.Visible = True
        lblSeleccion.Text = "Socio por asignar"
        lblSeleccion.ForeColor = Color.DimGray
        picSeleccion.Visible = False
        btnAsignacion.Visible = True
    End Sub

End Class