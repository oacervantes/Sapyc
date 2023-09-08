Imports System.Data
Imports System.Data.SqlClient
Public Class MttoCEntero

    Public sCve As String
    Public sDes As String
    Public iTipo As Integer
    Private Sub MttoCEntero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            sSQL = " UPDATE COMOSEENTERO SET "
            sSQL &= " DESCRIPCION = '" & Cnombre.Text.Trim() & "'"
            sSQL &= " WHERE CVE = '" & sCve.Trim() & "'"
            Using con As New SqlConnection(CadenaConexion())
                Dim cmd As New SqlCommand(sSQL, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
            End Using

            MsgBox("COMO SE ENTERO ACTUALIZADO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "COMOSEENTERO")

            Me.Hide()
            Me.Dispose()

        ElseIf iTipo = 1 Then

            sSQL = " INSERT COMOSEENTERO (DESCRIPCION) VALUES ( " & " '" & Cnombre.Text.Trim() & "' " & " )"
            Using con As New SqlConnection(CadenaConexion())
                Dim cmd As New SqlCommand(sSQL, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
            End Using

            MsgBox("COMO SE ENTERO AGREGADO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "COMOSEENTERO")

            Me.Hide()
            Me.Dispose()


        End If
    End Sub

End Class