Public Class DlgSolicitudAsignacion

    Private ds As New DataSet()
    Private sNameRpt As String = "Selección de socios para asignar propuesta"

    Private dtSocios As New DataTable
    Private tarjetaSeleccionada As TarjetaSocio2 = Nothing
    Private iPosY = 10, iValorY As Integer = 280

    Private sCveSocio, sNombreSocio, sCorreoSocio As String

    Public idSac, idPropuesta, idServicio, idIdioma As Integer
    Public sCveOfi, sCvearea, sOficina, sArea, sNombreCte, sCveInd, sServicio, sSocioEncargado, sCorreoEncargado, sUsuario, sNombre, sCorreo As String

    Private Sub DlgSolicitudAsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProspecto.Text = $"{sNombreCte}"
        lblServicio.Text = $"{sServicio}"
        txtSocioEncargado.Text = $"{sSocioEncargado}"
        txtOficina.Text = $"{sOficina}"
        txtDivision.Text = $"{sArea}"
        txtIdSac.Text = $"{idSac}"

        If sCvearea = "AUD" Then
            ListarSociosAuditoria()
        Else
            ListarSociosOficinas()
        End If

        LlenarTarjetas()
    End Sub
    Private Sub BtnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        Dim dlg As New DlgDetalleSolicitud With {
            .idSac = idSac,
            .idPropuesta = idPropuesta
        }

        dlg.ShowDialog()
    End Sub
    Private Sub BtnRechazarAsignacion_Click(sender As Object, e As EventArgs) Handles btnRechazarAsignacion.Click
        Dim dlg As New DlgRechazoPropuesta

        dlg.ShowDialog()
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
                .Correo = row("CORREO").ToString(),
                .Nombre = row("NOMBRE").ToString(),
                .Idiomas = row("sIdioma").ToString(),
                .Servicio = row("sServicio").ToString(),
                .Industrias = row("sIndustria").ToString()
            }

            AddHandler card.CardClick, AddressOf OnSocioCardClick
            card.Location = New Point(10, iPosY)
            panSocios.Controls.Add(card)
            iPosY += iValorY + 10
        Next

        panSocios.ResumeLayout()
    End Sub
    Private Sub ListarSociosAuditoria()
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
                    .subAddParameter("@idIdioma", idIdioma, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idServicio", idServicio, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idIndustria", sCveInd, SqlDbType.VarChar, ParameterDirection.Input)
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
    Private Sub ListarSociosOficinas()
        ' Aquí iría la lógica para listar los socios, por ejemplo, desde una base de datos
        ' Por ahora, se simula con datos estáticos en el método LlenarTarjetas()
        Try
            Dim sTabla As String = "tbSocios"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveOfi", sCveOfi, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@sCveArea", sCvearea, SqlDbType.VarChar, ParameterDirection.Input)
                    .subAddParameter("@idIdioma", idIdioma, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@idServicio", idServicio, SqlDbType.Int, ParameterDirection.Input)
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

    Private Sub OnSocioCardClick(tarjetaActual As TarjetaSocio2)

        ' Oculta la anterior
        If tarjetaSeleccionada IsNot Nothing AndAlso tarjetaSeleccionada IsNot tarjetaActual Then
            tarjetaSeleccionada.OcultarSeleccion()
        End If

        ' Muestra la actual
        tarjetaActual.MostrarSeleccion()

        ' Guarda referencia
        tarjetaSeleccionada = tarjetaActual

        sCveSocio = tarjetaActual.SocioId
        sNombreSocio = tarjetaActual.Nombre
        sCorreoSocio = tarjetaActual.Correo

    End Sub

End Class