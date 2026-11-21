Public Class frmClientesGRD

    Private dtClientes, DtDatos As New DataTable
    Private bsSol As New BindingSource
    Private drDat As DataRow
    Public sCveCte, sNombreCte, sCveGRD As String
    Private Sub frmClientesGRD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtDatos = New DataTable()
        grdClientes.DataSource = bsSol

        crearTabla()
        ListaClientesActivos()
    End Sub
    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Me.Close()
    End Sub
    Private Sub btnRevisar_Click(sender As Object, e As EventArgs) Handles btnRevisar.Click
        Dim dlg As New dlgClienteGRD

        If Not grdClientes.CurrentRow Is Nothing Then
            If grdClientes.Rows.Count > 0 Then

                sCveCte = grdClientes.CurrentRow.Cells("CVECTE").Value.ToString()
                sNombreCte = grdClientes.CurrentRow.Cells("NOMBRECTE").Value.ToString()
                sCveGRD = grdClientes.CurrentRow.Cells("CVEGRD").Value.ToString()

                dlg.sCveCte = sCveCte
                dlg.sNombreCte = sNombreCte
                dlg.sCveGRD = sCveGRD

                If dlg.ShowDialog = DialogResult.OK Then
                    MsgBox("Cliente actualizado correctamente.", MsgBoxStyle.Exclamation, "SAPYC")
                    ListaClientesActivos()
                End If

            End If

        Else
            MsgBox("Seleccione la propuesta que desea actualizar.", MsgBoxStyle.Exclamation, "SAPYC")
        End If

    End Sub
    Private Sub crearTabla()

        DtDatos.Columns.Add("CVECTE", GetType(System.String))
        DtDatos.Columns.Add("NOMBRECTE", GetType(System.String))
        DtDatos.Columns.Add("CVEGRD", GetType(System.String))

    End Sub
    Private Sub ListaClientesActivos()
        Try
            Dim sTabla As String = "tbSol"

            With ds.Tables
                If .Contains(sTabla) Then
                    .Remove(sTabla)
                End If

                With clsDatosInv
                    .subClearParameters()
                    .subAddParameter("@iOpcion", 41, SqlDbType.Int, ParameterDirection.Input)

                End With

                .Add(clsDatosInv.funExecuteSPDataTable("paClientes", sTabla))
                dtClientes = .Item(sTabla)

                If dtClientes.Rows.Count > 0 Then

                    For Each dr As DataRow In dtClientes.Rows

                        drDat = DtDatos.NewRow
                        drDat("CVECTE") = dr("CVECTE").ToString()
                        drDat("NOMBRECTE") = dr("NOMBRECTE").ToString()
                        drDat("CVEGRD") = dr("CVEGRD").ToString()
                        DtDatos.Rows.InsertAt(drDat, DtDatos.Rows.Count)

                    Next

                    bsSol.DataSource = DtDatos
                    formatoGrid()
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub formatoGrid()
        For Each col As DataGridViewColumn In grdClientes.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        grdClientes.Columns("CVECTE").HeaderText = "CLAVE CLIENTE"
        grdClientes.Columns("CVECTE").Width = 150
        grdClientes.Columns("NOMBRECTE").HeaderText = "NOMBRE CLIENTE"
        grdClientes.Columns("NOMBRECTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        grdClientes.Columns("CVEGRD").HeaderText = "CLVE GRD"
        grdClientes.Columns("CVEGRD").Width = 100


    End Sub
    Private Sub txtCliente_Leave(sender As Object, e As EventArgs) Handles txtCliente.Leave
        If DirectCast(sender, TextBox).Text = "" Then
            DirectCast(sender, TextBox).Text = "Nombre Cliente.."
            DirectCast(sender, TextBox).ForeColor = Color.Silver
        End If
    End Sub
    Private Sub txtCliente_Enter(sender As Object, e As EventArgs) Handles txtCliente.Enter
        If txtCliente.Text <> "" And txtCliente.Text = "Nombre Cliente.." Then
            txtCliente.Text = ""
            txtCliente.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged
        If txtCliente.TextLength > 0 And Not txtCliente.Text.Contains("Nombre Cliente..") Then
            bsSol.Filter = "NOMBRECTE LIKE '%" & txtCliente.Text & "%'"
        Else
            If bsSol.Filter IsNot Nothing Then
                If txtCliente.TextLength > 0 And txtCliente.Text.Contains("Nombre Cliente..") Then
                    bsSol.Filter = ""
                End If
            End If
        End If
    End Sub





End Class