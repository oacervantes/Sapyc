
Public Class frmTrabajosCliente

    Public CveCtes As String
    Private dtGpos As DataTable
    Private bsGpo As New BindingSource
    Private Sub frmTrabajosCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dgvTrabajosCtes.DataSource = bsGpo
        ConsultaGrupos()
    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ConsultaGrupos()
        With ds.Tables
            With clsLocal
                .subClearParameters()
                .subAddParameter("@iOpcion", 20, SqlDbType.Int, ParameterDirection.Input)
                .subAddParameter("@sCveCte", CveCtes, SqlDbType.VarChar, ParameterDirection.Input)

            End With

            If .Contains("paSapyc") Then
                .Remove("paSapyc")
            End If

            .Add(clsLocal.funExecuteSPDataTable("paSapyc"))
            dtGpos = .Item("paSapyc")

            If dtGpos.Rows.Count > 0 Then
                bsGpo.DataSource = dtGpos
            Else
                DialogResult = Windows.Forms.DialogResult.OK
                MsgBox("no hay datos que mostrar!", MsgBoxStyle.Information, "Cliente prospecto")
            End If


        End With
    End Sub

End Class