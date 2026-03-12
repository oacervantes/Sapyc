Public Class DlgSolicitudAsignacion

    Private iPosY = 0, iValorY As Integer = 230

    Private Sub DlgSolicitudAsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarTarjetas()
    End Sub

    Private Sub LlenarTarjetas()
        panSocios.SuspendLayout()
        panSocios.Controls.Clear()


        Dim card As New TarjetaSocio2() With {
            .SocioId = 1,
            .Nombre = "LUIS BURGOS",
            .Oficina = "MÉXICO",
            .Division = "AUDITORÍA",
            .Grupo = "A"
        }

        AddHandler card.CardClick, AddressOf OnSocioCardClick
        iPosY = 10
        card.Location = New Point(10, iPosY)
        panSocios.Controls.Add(card)
        iPosY += iValorY + 10

        Dim card2 As New TarjetaSocio2() With {
            .SocioId = 2,
            .Nombre = "ALONDRA DE LA GARZA ERIVES",
            .Oficina = "PLD",
            .Division = "PLD",
            .Grupo = ""
        }

        AddHandler card2.CardClick, AddressOf OnSocioCardClick
        card2.Location = New Point(10, iPosY)
        panSocios.Controls.Add(card2)
        iPosY += iValorY + 10

        Dim card3 As New TarjetaSocio2() With {
            .SocioId = 3,
            .Nombre = "LUIS GUILLERMO RAMO AGUIRRE",
            .Oficina = "QUÉRETARO",
            .Division = "AUDITORÍA",
            .Grupo = ""
        }

        AddHandler card3.CardClick, AddressOf OnSocioCardClick
        card3.Location = New Point(10, iPosY)
        panSocios.Controls.Add(card3)

        panSocios.ResumeLayout()
    End Sub


    Private Sub OnSocioCardClick(socioId As String)
        MessageBox.Show($"Abrir detalle del socio: {socioId}", "Socio")
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class
