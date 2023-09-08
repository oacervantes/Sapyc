Public Class DlgPropuesta
    Public IdProp As Integer
    Private dtDatos As DataTable

    Private Sub DlgPropuesta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultaPropuesta()
    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        HabilitaMenu()
        Me.Hide()
        Me.Dispose()
    End Sub

    Private Sub ConsultaPropuesta()
        Try
            With ds.Tables
                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input)

                End With

                If .Contains("paIndependencia") Then
                    .Remove("paIndependencia")
                End If

                .Add(clsLocal.funExecuteSPDataTable("paIndependencia"))
                dtDatos = .Item("paIndependencia")

                If dtDatos.Rows.Count > 0 Then
                    lblNom.Text = dtDatos.Rows(0)("NOMCONTINICIAL").ToString()
                    lblAct.Text = dtDatos.Rows(0)("ACTIVIDAD").ToString()
                    lblGiro.Text = dtDatos.Rows(0)("GIRO").ToString()
                    lblOfi.Text = dtDatos.Rows(0)("OFICINA").ToString()
                    lblCont.Text = dtDatos.Rows(0)("NOMCONTINICIAL").ToString()
                    lblCargo.Text = dtDatos.Rows(0)("CARGOCIA").ToString()
                    lblDivi.Text = dtDatos.Rows(0)("DIVISION").ToString()
                    lblRfc.Text = dtDatos.Rows(0)("RFC").ToString()
                    lblFecha.Text = CDate(dtDatos.Rows(0)("REGISTRADAEL")).ToShortDateString

                    chkInd.Checked = CBool(dtDatos.Rows(0)("CONFLICTODEINDEPENDENCIA"))
                    chkCC.Checked = CBool(dtDatos.Rows(0)("SOLICITUDDECONFLICTCHECK"))

                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            With ds.Tables
                If .Contains("paIndependencia") Then
                    .Remove("paIndependencia")
                End If

                With clsLocal
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 3, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@iProp", IdProp, SqlDbType.Int, ParameterDirection.Input, 10)
                    .subAddParameter("@bInd", chkInd.Checked, SqlDbType.Bit, ParameterDirection.Input, 10)
                    .subAddParameter("@bCCh", chkCC.Checked, SqlDbType.Bit, ParameterDirection.Input, 10)

                End With

                clsLocal.funExecuteSP("paIndependencia")
            End With
            MsgBox("Los cambios se guardaron correctamente.", MsgBoxStyle.Information, "Solicitudes Actualizados")
            Me.Close()
            DialogResult = DialogResult.OK

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class