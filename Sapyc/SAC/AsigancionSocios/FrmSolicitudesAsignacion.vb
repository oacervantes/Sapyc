Public Class FrmSolicitudesAsignacion

    Private bs As New BindingSource
    Private ds As New DataSet

    Private sNameRpt As String = "Asignación de Solicitudes"

    Private dtSolicitudes As New DataTable

    Private Sub FrmSolicitudesAsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridProspectos.DataSource = bs
        DesplazamientoGrid(gridProspectos)

        ListarSolicitudes()
    End Sub
    Private Sub BtnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim dlg As New DlgSolicitudAsignacion()

        If gridProspectos.CurrentRow IsNot Nothing Then
            Dim bActivo As Boolean = gridProspectos.CurrentRow.Cells("bStatus").Value
            Dim sStatus As String = gridProspectos.CurrentRow.Cells("cStatus").Value.ToString()
            Dim idSac As Integer = gridProspectos.CurrentRow.Cells("idSac").Value
            Dim idPropuesta As Integer = gridProspectos.CurrentRow.Cells("idPropuesta").Value
            Dim sCveOfi As String = gridProspectos.CurrentRow.Cells("sCveOfi").Value.ToString()
            Dim sCveArea As String = gridProspectos.CurrentRow.Cells("sCveArea").Value.ToString()
            Dim sServicio As String = gridProspectos.CurrentRow.Cells("SERVICIO").Value.ToString()
            Dim idServicio As Integer = gridProspectos.CurrentRow.Cells("IdServicio").Value
            Dim idIdioma As Integer = gridProspectos.CurrentRow.Cells("idIdioma").Value
            Dim sNombreCte As String = gridProspectos.CurrentRow.Cells("sNombreCte").Value.ToString()
            Dim sDescOfi As String = gridProspectos.CurrentRow.Cells("DESCOFI").Value.ToString()
            Dim sDescArea As String = gridProspectos.CurrentRow.Cells("DESCAREA").Value.ToString()
            Dim sSocEncargado As String = gridProspectos.CurrentRow.Cells("SOCENC").Value.ToString()
            Dim sCorreoEncargado As String = gridProspectos.CurrentRow.Cells("CORENC").Value.ToString()
            Dim sCveInd As String = gridProspectos.CurrentRow.Cells("sCveInd").Value.ToString()
            Dim sUsuario As String = gridProspectos.CurrentRow.Cells("sUsuario").Value.ToString()
            Dim sNombre As String = gridProspectos.CurrentRow.Cells("NOMBRE").Value.ToString()
            Dim sCorreo As String = gridProspectos.CurrentRow.Cells("EMAIL").Value.ToString()
            Dim idMarco As Integer = gridProspectos.CurrentRow.Cells("idNormatividad").Value

            If gridProspectos.CurrentRow.Cells("bStatus").Value IsNot Nothing AndAlso bActivo = False AndAlso sStatus = "R" Then
                MsgBox("La solicitud se encuentra en revisión por servicio y no es posible asignarla en este momento.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
                Exit Sub
            ElseIf gridProspectos.CurrentRow.Cells("bStatus").Value IsNot Nothing AndAlso bActivo = False AndAlso sStatus = "C" Then
                MsgBox("La solicitud ha sido cancelada y ya no es posible asignarla.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
                Exit Sub
            End If

            dlg.idSac = idSac
            dlg.idPropuesta = idPropuesta
            dlg.sCveOfi = sCveOfi
            dlg.sCvearea = sCveArea
            dlg.sNombreCte = sNombreCte
            dlg.idServicio = idServicio
            dlg.idIdioma = idIdioma
            dlg.sServicio = sServicio
            dlg.sSocioEncargado = sSocEncargado
            dlg.sCorreoEncargado = sCorreoEncargado
            dlg.sOficina = sDescOfi
            dlg.sArea = sDescArea
            dlg.sCveInd = sCveInd
            dlg.sUsuario = sUsuario
            dlg.sNombre = sNombre
            dlg.sCorreo = sCorreo
            dlg.idMarco = idMarco

            If dlg.ShowDialog() = DialogResult.OK Then
                ListarSolicitudes()
            End If
        End If
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub GridProspectos_DoubleClick(sender As Object, e As EventArgs) Handles gridProspectos.DoubleClick
        Dim dlg As New DlgSolicitudAsignacion()

        If gridProspectos.CurrentRow IsNot Nothing Then
            Dim bActivo As Boolean = gridProspectos.CurrentRow.Cells("bStatus").Value
            Dim sStatus As String = gridProspectos.CurrentRow.Cells("cStatus").Value.ToString()
            Dim idSac As Integer = gridProspectos.CurrentRow.Cells("idSac").Value
            Dim idPropuesta As Integer = gridProspectos.CurrentRow.Cells("idPropuesta").Value
            Dim sCveOfi As String = gridProspectos.CurrentRow.Cells("sCveOfi").Value.ToString()
            Dim sCveArea As String = gridProspectos.CurrentRow.Cells("sCveArea").Value.ToString()
            Dim sServicio As String = gridProspectos.CurrentRow.Cells("SERVICIO").Value.ToString()
            Dim idServicio As Integer = gridProspectos.CurrentRow.Cells("IdServicio").Value
            Dim idIdioma As Integer = gridProspectos.CurrentRow.Cells("idIdioma").Value
            Dim sNombreCte As String = gridProspectos.CurrentRow.Cells("sNombreCte").Value.ToString()
            Dim sDescOfi As String = gridProspectos.CurrentRow.Cells("DESCOFI").Value.ToString()
            Dim sDescArea As String = gridProspectos.CurrentRow.Cells("DESCAREA").Value.ToString()
            Dim sSocEncargado As String = gridProspectos.CurrentRow.Cells("SOCENC").Value.ToString()
            Dim sCorreoEncargado As String = gridProspectos.CurrentRow.Cells("CORENC").Value.ToString()
            Dim sCveInd As String = gridProspectos.CurrentRow.Cells("sCveInd").Value.ToString()
            Dim sUsuario As String = gridProspectos.CurrentRow.Cells("sUsuario").Value.ToString()
            Dim sNombre As String = gridProspectos.CurrentRow.Cells("NOMBRE").Value.ToString()
            Dim sCorreo As String = gridProspectos.CurrentRow.Cells("EMAIL").Value.ToString()
            Dim idMarco As Integer = gridProspectos.CurrentRow.Cells("idNormatividad").Value

            If gridProspectos.CurrentRow.Cells("bStatus").Value IsNot Nothing AndAlso bActivo = False AndAlso sStatus = "R" Then
                MsgBox("La solicitud se encuentra en revisión por servicio y no es posible asignarla en este momento.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
                Exit Sub
            ElseIf gridProspectos.CurrentRow.Cells("bStatus").Value IsNot Nothing AndAlso bActivo = False AndAlso sStatus = "C" Then
                MsgBox("La solicitud ha sido cancelada y ya no es posible asignarla.", MsgBoxStyle.Exclamation, My.Settings.NOM_SYS)
                Exit Sub
            End If

            dlg.idSac = idSac
            dlg.idPropuesta = idPropuesta
            dlg.sCveOfi = sCveOfi
            dlg.sCvearea = sCveArea
            dlg.sNombreCte = sNombreCte
            dlg.idServicio = idServicio
            dlg.idIdioma = idIdioma
            dlg.sServicio = sServicio
            dlg.sSocioEncargado = sSocEncargado
            dlg.sCorreoEncargado = sCorreoEncargado
            dlg.sOficina = sDescOfi
            dlg.sArea = sDescArea
            dlg.sCveInd = sCveInd
            dlg.sUsuario = sUsuario
            dlg.sNombre = sNombre
            dlg.sCorreo = sCorreo
            dlg.idMarco = idMarco

            If dlg.ShowDialog() = DialogResult.OK Then
                ListarSolicitudes()
            End If
        End If
    End Sub

    Private Sub ListarSolicitudes()
        Try
            Dim sTabla As String = "tbSolicitudes"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 5, SqlDbType.Int, ParameterDirection.Input)
                End With

                .Add(clsLocal.funExecuteSPDataTable("paSolicitudesSAC", sTabla))

                dtSolicitudes = .Item(sTabla)
            End With

            If dtSolicitudes.Rows.Count > 0 Then
                bs.DataSource = dtSolicitudes
                FormatoGrid()
            End If
        Catch ex As Exception
            InsertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ListarProspectos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtSolicitudes = Nothing
        End Try
    End Sub
    Private Sub FormatoGrid()
        gridProspectos.Columns("idPropuesta").Visible = False
        gridProspectos.Columns("sCveOfi").Visible = False
        gridProspectos.Columns("sCveArea").Visible = False
        gridProspectos.Columns("cStatus").Visible = False
        gridProspectos.Columns("bStatus").Visible = False
        gridProspectos.Columns("IdServicio").Visible = False
        gridProspectos.Columns("idIdioma").Visible = False
        gridProspectos.Columns("SOCENC").Visible = False
        gridProspectos.Columns("CORENC").Visible = False
        gridProspectos.Columns("sCveInd").Visible = False
        gridProspectos.Columns("sUsuario").Visible = False
        gridProspectos.Columns("NOMBRE").Visible = False
        gridProspectos.Columns("EMAIL").Visible = False

        ConfigurarColumnasGrid(gridProspectos, "idSac", "ID. SAC", 65, 3, False)
        ConfigurarColumnasGrid(gridProspectos, "sNombreCte", "PROSPECTO", 300, 1, False)
        ConfigurarColumnasGrid(gridProspectos, "DESCOFI", "OFICINA", 90, 3, False)
        ConfigurarColumnasGrid(gridProspectos, "DESCAREA", "DIVISIÓN", 90, 3, False)
        ConfigurarColumnasGrid(gridProspectos, "SERVICIO", "SERVICIO", 300, 1, False)
        ConfigurarColumnasGrid(gridProspectos, "dFechaAlta", "FECHA DE ALTA", 150, 3, False)
        ConfigurarColumnasGrid(gridProspectos, "sStatus", "STATUS SOLICITUD", 250, 1, False)
    End Sub

End Class