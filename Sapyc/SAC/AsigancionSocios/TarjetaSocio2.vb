Public Class TarjetaSocio2

    Private ds As New DataSet

    Private sNameRpt As String = "Selección de socios para asignar propuesta"

    Private dtDatosSocio As New DataTable

    Private sCveSocio As String

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
            MostrarTextoConErrores(txtServiciosColor, value)
        End Set
    End Property
    Public Property Idiomas As String
        Get
            Return txtIdiomasColor.Text
        End Get
        Set(value As String)
            MostrarTextoConErrores(txtIdiomasColor, value)
        End Set
    End Property
    Public Property Industrias As String
        Get
            Return txtIndustriasColor.Text
        End Get
        Set(value As String)
            MostrarTextoConErrores(txtIndustriasColor, value)
        End Set
    End Property
    Public Property CapacidadInstalada As String
        Get
            Return txtCapacidadInstalada.Text
        End Get
        Set(value As String)
            MostrarTextoConErrores(txtCapacidadInstalada, value)
        End Set
    End Property

    Public Event CardClick(sender As TarjetaSocio2)

    'Private Sub OnAnyClick(sender As Object, e As EventArgs) Handles Me.Click, lblNombre.Click
    '    RaiseEvent CardClick(Me)
    'End Sub

    Private Sub BtnAsignacion_Click(sender As Object, e As EventArgs) Handles btnAsignacion.Click
        RaiseEvent CardClick(Me)
    End Sub
    Public Sub MostrarTextoConErrores(rtb As RichTextBox, texto As String)

        rtb.Clear()
        rtb.SelectionColor = Color.Black

        Dim inicioTag As String = "[ERROR]"
        Dim finTag As String = "[/ERROR]"

        Dim i As Integer = 0

        While i < texto.Length

            Dim posInicio As Integer = texto.IndexOf(inicioTag, i)

            ' No hay más errores
            If posInicio = -1 Then
                rtb.SelectionColor = Color.Black
                rtb.AppendText(texto.Substring(i))
                Exit While
            End If

            ' Texto normal antes del error
            If posInicio > i Then
                rtb.SelectionColor = Color.Black
                rtb.AppendText(texto.Substring(i, posInicio - i))
            End If

            ' Texto de error
            Dim posFin As Integer = texto.IndexOf(finTag, posInicio)
            If posFin = -1 Then Exit While ' Seguridad

            Dim textoError As String =
            texto.Substring(posInicio + inicioTag.Length,
                            posFin - (posInicio + inicioTag.Length))

            rtb.SelectionColor = Color.FromArgb(255, 125, 30)
            rtb.AppendText(textoError)

            ' Avanzar índice
            i = posFin + finTag.Length
        End While

        ' Reset final
        rtb.SelectionColor = Color.Black

    End Sub

    Public Sub MostrarSeleccion()
        lblSeleccion.Visible = True
    End Sub
    Public Sub OcultarSeleccion()
        lblSeleccion.Visible = False
    End Sub

End Class