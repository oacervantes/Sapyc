Public Class TarjetaSocio2

    Public Property SocioId As String

    Public Property Nombre As String
        Get
            Return lblNombre.Text
        End Get
        Set(value As String)
            lblNombre.Text = value
        End Set
    End Property
    Public Property Oficina As String
        Get
            Return txtOficina.Text
        End Get
        Set(value As String)
            txtOficina.Text = value
        End Set
    End Property
    Public Property Division As String
        Get
            Return txtDivision.Text
        End Get
        Set(value As String)
            txtDivision.Text = value
        End Set
    End Property
    Public Property Grupo As String
        Get
            Return txtGrupo.Text
        End Get
        Set(value As String)
            If value = "" Then
                txtGrupo.Text = "N/A"
            Else
                txtGrupo.Text = value
            End If
        End Set
    End Property

    Public Event CardClick(socioId As String)

    Private Sub OnAnyClick(sender As Object, e As EventArgs)
        RaiseEvent CardClick(SocioId)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Ejemplo de botón en la tarjeta del socio: " & Nombre)
    End Sub

End Class
