Public Class DlgSolicitudAsignacion

    Private ds As New DataSet()
    Private sNameRpt As String = "Selección de socios para asignar propuesta"

    Private dtSocios As New DataTable

    Private iPosY = 10, iValorY As Integer = 280
    Public idSac, idPropuesta As Integer
    Public sCveOfi, sCvearea As String

    Private Sub DlgSolicitudAsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarSocios
        LlenarTarjetas()
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub LlenarTarjetas()
        panSocios.SuspendLayout()
        panSocios.Controls.Clear()

        For Each row As DataRow In dtSocios.Rows
            Dim card As New TarjetaSocio2() With {
                .SocioId = row("CVEEMP").ToString(),
                .Nombre = row("NOMBRE").ToString(),
                .Oficina = row("OFICINA").ToString(),
                .Division = row("DIVISION").ToString(),
                .Grupo = row("GPO").ToString()
            }
            AddHandler card.CardClick, AddressOf OnSocioCardClick
            card.Location = New Point(10, iPosY)
            panSocios.Controls.Add(card)
            iPosY += iValorY + 10
        Next

        panSocios.ResumeLayout()
    End Sub
    Private Sub ListarSocios()
        ' Aquí iría la lógica para listar los socios, por ejemplo, desde una base de datos
        ' Por ahora, se simula con datos estáticos en el método LlenarTarjetas()
        Try
            Dim sTabla As String = "tbSocios"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 1, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveArea", sCvearea, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosInv.funExecuteSPDataTable("paSACAsignaciones", sTabla))

                dtSocios = .Item(sTabla)
            End With
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSocios = Nothing
        End Try
    End Sub

    Private Sub OnSocioCardClick(socioId As String)
        MessageBox.Show($"Abrir detalle del socio: {socioId}", "Socio")
    End Sub





End Class
