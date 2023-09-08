Imports System.Data
Imports System.Data.SqlClient
Public Class MttoGiros

    Public sCve As String
    Public sDes As String
    Public iTipo As Integer

    Private Sub MttoGiros_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cnombre.Text = sDes
        sCve = sCve
        iTipo = iTipo

    End Sub
    Private Sub Bcancelar_Click(sender As Object, e As EventArgs) Handles Bcancelar.Click
        HabilitaMenu()
        Me.Hide()
        Me.Dispose()
    End Sub
    Private Sub Baceptar_Click(sender As Object, e As EventArgs) Handles Baceptar.Click

        If iTipo = 2 Then

            sSQL = " UPDATE GIROS SET "
            sSQL &= " DESCRIPCION = '" & Cnombre.Text.Trim() & "'"
            sSQL &= " WHERE CVE = '" & sCve.Trim() & "'"
            Using con As New SqlConnection(CadenaConexion())
                Dim cmd As New SqlCommand(sSQL, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
            End Using

            MsgBox("GIRO ACTUALIZADO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GIROS")

            Me.Hide()
            Me.Dispose()

        ElseIf iTipo = 1 Then

            sSQL = " INSERT GIROS (DESCRIPCION) VALUES ( " & " '" & Cnombre.Text.Trim() & "' " & " )"
            Using con As New SqlConnection(CadenaConexion())
                Dim cmd As New SqlCommand(sSQL, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
            End Using

            MsgBox("GIRO AGREGADO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GIROS")

            Me.Hide()
            Me.Dispose()


        End If

    End Sub


End Class