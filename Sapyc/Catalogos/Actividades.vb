Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class Actividades
    Public sCve As String
    Public sDes As String
    Public iTipo As Integer

    Private Sub Actividades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarDatos()
    End Sub
    Private Sub Balta_Click(sender As Object, e As EventArgs) Handles Balta.Click
        MttoActv.iTipo = 1
        MttoActv.ShowDialog()
        Me.Focus()

        MostrarDatos()
        MttoActv.Dispose()
    End Sub
    Private Sub Bmodificar_Click(sender As Object, e As EventArgs) Handles Bmodificar.Click
        If Lista.SelectedRows.Count > 0 Then

            sCve = Lista.CurrentRow.Cells("CVE").Value.ToString
            sDes = Lista.CurrentRow.Cells("DESCRIPCION").Value.ToString

            MttoActv.sCve = sCve
            MttoActv.sDes = sDes
            MttoActv.iTipo = 2
            MttoActv.ShowDialog()
            Me.Focus()

            MostrarDatos()
            MttoActv.Dispose()
        Else
            MsgBox("Debe seleccionar un registro de la lista", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ACTIVIDAD")
        End If
    End Sub
    Private Sub Bbaja_Click(sender As Object, e As EventArgs) Handles Bbaja.Click
        If Lista.SelectedRows.Count > 0 Then

            sCve = Lista.CurrentRow.Cells("CVE").Value.ToString
            sDes = Lista.CurrentRow.Cells("DESCRIPCION").Value.ToString

            If MsgBox("¿Estas seguro de eliminar esté giro", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then

                sSQL = " DELETE ACTIVIDAD "
                sSQL &= " WHERE CVE = '" & sCve.Trim() & "'"

                Using con As New SqlConnection(CadenaConexion())
                    Dim cmd As New SqlCommand(sSQL, con)
                    con.Open()
                    Dim t As Integer = CInt(cmd.ExecuteScalar())
                    con.Close()
                End Using

                MsgBox("actividad eliminado correctamente", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ACTIVIDAD")
                MostrarDatos()

            End If

        End If
    End Sub
    Private Sub Bsalir_Click(sender As Object, e As EventArgs) Handles Bsalir.Click
        HabilitaMenu()
        Me.Hide()
        Me.Dispose()
    End Sub
    Public Sub MostrarDatos()
        Dim qflag As Boolean

        Dim cnn As New SqlConnection(CadenaConexionSapyc())
        sSQL = "SELECT CVE, DESCRIPCION FROM ACTIVIDAD ORDER BY CVE ASC "
        Dim da As New SqlDataAdapter(sSQL, cnn)
        Dim ds As New DataSet

        da.Fill(ds)

        Lista.DataSource = ds.Tables(0)

        Lista.Columns("CVE").HeaderText = "Clave"
        Lista.Columns("DESCRIPCION").HeaderText = "Descripción"



        ' Lista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Lista.Columns(0).SortMode = DataGridViewColumnSortMode.Programmatic
        Lista.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable



        Lista.MultiSelect = False
        Lista.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Lista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Lista.Columns(0).Width = 50
        Lista.Columns(1).Width = 350


        '        Lista.Width = Lista.Columns(0).Width + Lista.Columns(1).Width + Lista.Columns(2).Width + Lista.Columns(3).Width + 45 + 15
        '        Lista.Left = Int((Me.Width - Lista.Width) / 2)

        If Lista.Rows.Count > 0 Then
            qflag = True
        Else
            qflag = False
        End If
        'Bbaja.Enabled = qflag
        'Bmodificar.Enabled = qflag

    End Sub

End Class