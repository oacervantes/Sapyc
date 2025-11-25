Public Class DlgListaGerentes

    Private sNameRpt As String = "Lista de Gerentes"

    Private bs As New BindingSource
    Private cls As New clsDatosInventarios

    Private dtGer As New DataTable

    Public sCveGer, sGerente, sCveOfi, sCveArea As String

    Private Sub DlgListaGerentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridGerentes.DataSource = bs
        DiseñoGrid(gridGerentes)

        ListarGerentes()
        If dtGer Is Nothing Then
            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        If gridGerentes.CurrentRow IsNot Nothing Then
            sCveGer = gridGerentes.CurrentRow.Cells("CVEGER").Value
            sGerente = gridGerentes.CurrentRow.Cells("NOMGER").Value

            DialogResult = DialogResult.OK
        Else
            MsgBox("Seleccione a un gerente.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub
    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub TxtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        If txtNombre.TextLength > 0 And Not txtNombre.Text.Contains("Nombre...") Then
            bs.Filter = "NOMGER LIKE '%" & txtNombre.Text & "%'"
        Else
            If bs.Filter IsNot Nothing Then
                bs.Filter = ""
            End If
        End If
    End Sub
    Private Sub TxtNombre_Enter(sender As Object, e As EventArgs) Handles txtNombre.Enter
        If txtNombre.Text <> "" And txtNombre.Text = "Nombre..." Then
            txtNombre.Text = ""
            txtNombre.ForeColor = Color.Black
        End If
    End Sub
    Private Sub TxtNombre_Leave(sender As Object, e As EventArgs) Handles txtNombre.Leave
        If DirectCast(sender, TextBox).Text = "" Then
            DirectCast(sender, TextBox).Text = "Nombre..."
            DirectCast(sender, TextBox).ForeColor = Color.Silver
        End If
    End Sub

    Private Sub GridGerentes_DoubleClick(sender As Object, e As EventArgs) Handles gridGerentes.DoubleClick
        If gridGerentes.CurrentRow IsNot Nothing Then
            sCveGer = gridGerentes.CurrentRow.Cells("CVEGER").Value
            sGerente = gridGerentes.CurrentRow.Cells("NOMGER").Value

            DialogResult = DialogResult.OK
        Else
            MsgBox("Seleccione a un gerente.", MsgBoxStyle.Exclamation, "SIAT")
        End If
    End Sub

    Private Sub FormatoGrid()
        gridGerentes.Columns("CVEGER").Visible = False
        gridGerentes.Columns("CVEOFI").Visible = False
        gridGerentes.Columns("CVEAREA").Visible = False

        ConfigurarColumnasGrid(gridGerentes, "NOMGER", "GERENTE", 0, 1, False)
        ConfigurarColumnasGrid(gridGerentes, "DESCOFI", "OFICINA", 90, 3, False)
        ConfigurarColumnasGrid(gridGerentes, "DESCAREA", "DIVISIÓN", 90, 3, False)
        ConfigurarColumnasGrid(gridGerentes, "GPO", "GPO.", 90, 3, False)
    End Sub

    Private Sub ListarGerentes()
        dtGer = cls.ListarGerentes(sNameRpt, sCveOfi, sCveArea)

        bs.DataSource = dtGer
        FormatoGrid()
    End Sub

End Class