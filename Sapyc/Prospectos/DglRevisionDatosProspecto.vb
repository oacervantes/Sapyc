Imports System.Windows.Forms

Public Class DglRevisionDatosProspecto

    Private ds As New DataSet
    Private dtProspectos As DataTable

    Private sNameRpt As String = "Dialog inicio Propuesta"

    Public sCliente, sCveProspecto As String


    Private sMensajeIncompleto As String = "No se puede generar la propuesta, hasta que termine de capturar la información necesaria para este prospecto." & vbNewLine

    Private Resp As Boolean = True

    Private Sub DglRevisionDatosProspecto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultaDatosCompletos()

        If Resp = False Then
            lblDatosIncompletos.Text = sMensajeIncompleto
            lblDatosIncompletos.Visible = True

            chkConfirmacion.Enabled = False
        Else
            lblMensaje.Visible = True
            chkConfirmacion.Visible = True
            chkConfirmacion.Enabled = True
        End If

    End Sub

    Private Sub chkConfirmacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkConfirmacion.CheckedChanged
        If chkConfirmacion.Checked Then
            OcultarControles(True)

            lblPregunta.Text = "Iniciar la generación de propuesta para el prospecto: " & vbNewLine & sCliente
        Else
            OcultarControles(False)
        End If
    End Sub

    Private Sub btnSi_Click(sender As Object, e As EventArgs) Handles btnSi.Click
        gpBoxTipoPropuesta.Visible = True
        btnGenerarPropuesta.Visible = True

        btnSi.Enabled = False
        btnNo.Enabled = False
    End Sub
    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub rdAsignacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdAsignacion.CheckedChanged
        lblSocio.Visible = True
        cboSocio.Visible = True
    End Sub
    Private Sub rdTrabajo_CheckedChanged(sender As Object, e As EventArgs) Handles rdTrabajo.CheckedChanged
        lblSocio.Visible = False
        cboSocio.Visible = False
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub OcultarControles(bOculto As Boolean)
        lblPregunta.Visible = bOculto
        btnSi.Visible = bOculto
        btnNo.Visible = bOculto
    End Sub
    Private Sub ConsultaDatosCompletos()
        Try
            Dim sTabla As String = "tbProspectos"

            With ds.Tables
                LimpiarConsultaTabla(ds.Tables, sTabla)

                With clsDatosProp
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 2, SqlDbType.Int, ParameterDirection.Input)
                    .subAddParameter("@sCveProspecto", sCveProspecto, SqlDbType.VarChar, ParameterDirection.Input)
                End With

                .Add(clsDatosProp.funExecuteSPDataTable("paSSGTPropuestasProspectos", sTabla))

                dtProspectos = .Item(sTabla)
            End With

            If dtProspectos.Rows.Count > 0 Then

                For Each dr As DataRow In dtProspectos.Rows

                    Select Case dr.Item("sDato")
                        Case "DG"
                            If CInt(dr.Item("iRegs")) = 0 Then
                                sMensajeIncompleto &= vbNewLine & "- Datos generales."

                                Resp = False
                            End If
                        Case "CI"
                            If CInt(dr.Item("iRegs")) = 0 Then
                                sMensajeIncompleto &= vbNewLine & "- Contacto Inicial."

                                Resp = False
                            End If
                        Case "AC"
                            If CInt(dr.Item("iRegs")) = 0 Then
                                sMensajeIncompleto &= vbNewLine & "- Acercamiento."

                                Resp = False
                            End If
                        Case "DO"
                            If CInt(dr.Item("iRegs")) = 0 Then
                                sMensajeIncompleto &= vbNewLine & "- Domicilio."

                                Resp = False
                            End If
                    End Select

                Next

            End If
        Catch ex As Exception
            insertarErrorLog(100, sNameRpt, ex.Message, sCveUsuario, "ConsultaDatosCompletos()")
            MsgBox("Hubo un problema al consultar la información en la base de datos, intente de nuevo más tarde.", MsgBoxStyle.Exclamation, "Error")
            dtProspectos = Nothing
        End Try
    End Sub

End Class