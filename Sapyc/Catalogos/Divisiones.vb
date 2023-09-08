Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class Divisiones

    Public sCve As String
    Public sDes As String
    Public sDiv As String
    Public iTipo As Integer
    Private Sub Divisiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarDatos()
    End Sub
    Private Sub Balta_Click(sender As Object, e As EventArgs) Handles Balta.Click
        MttoDivisiones.iTipo = 1
        MttoDivisiones.ShowDialog()
        Me.Focus()

        MostrarDatos()
        MttoDivisiones.Dispose()
    End Sub
    Private Sub Bmodificar_Click(sender As Object, e As EventArgs) Handles Bmodificar.Click
        If Lista.SelectedRows.Count > 0 Then

            sCve = Lista.CurrentRow.Cells("CVE").Value.ToString
            sDiv = Lista.CurrentRow.Cells("CVEDIVISION").Value.ToString
            sDes = Lista.CurrentRow.Cells("DESCRIPCION").Value.ToString

            MttoDivisiones.sCve = sCve
            MttoDivisiones.sDes = sDes
            MttoDivisiones.sDiv = sDiv

            MttoDivisiones.iTipo = 2
            MttoDivisiones.ShowDialog()
            Me.Focus()

            MostrarDatos()
            MttoDivisiones.Dispose()
        Else
            MsgBox("Debe seleccionar un registro de la lista", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "DIVISIONES")
        End If
    End Sub
    Private Sub Bbaja_Click(sender As Object, e As EventArgs) Handles Bbaja.Click
        If Lista.SelectedRows.Count > 0 Then

            sCve = Lista.CurrentRow.Cells("CVE").Value.ToString
            sDes = Lista.CurrentRow.Cells("DESCRIPCION").Value.ToString

            If MsgBox("¿Estas seguro de eliminar esta division", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then

                sSQL = " DELETE DIVISION "
                sSQL &= " WHERE CVE = '" & sCve.Trim() & "'"

                Using con As New SqlConnection(CadenaConexion())
                    Dim cmd As New SqlCommand(sSQL, con)
                    con.Open()
                    Dim t As Integer = CInt(cmd.ExecuteScalar())
                    con.Close()
                End Using

                MsgBox("DIVISION ELIMINADO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "DIVISION")
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
        sSQL = "SELECT CVE, CVEDIVISION , DESCRIPCION FROM DIVISION ORDER BY CVE ASC "
        Dim da As New SqlDataAdapter(sSQL, cnn)
        Dim ds As New DataSet

        da.Fill(ds)

        Lista.DataSource = ds.Tables(0)

        Lista.Columns("CVE").HeaderText = "Clave"
        Lista.Columns("CVEDIVISION").HeaderText = "Cve División"
        Lista.Columns("DESCRIPCION").HeaderText = "Descripción"


        ' Lista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Lista.Columns(0).SortMode = DataGridViewColumnSortMode.Programmatic
        Lista.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        Lista.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable


        Lista.MultiSelect = False
        Lista.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Lista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Lista.Columns(0).Width = 50
        Lista.Columns(1).Width = 80
        Lista.Columns(2).Width = 280

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