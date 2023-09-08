Imports System.Data
Imports System.Data.SqlClient
Public Class MttoDivisiones
    Public sCve As String
    Public sDes As String
    Public sDiv As String
    Public iTipo As Integer

    Private Sub MttoDivisiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cnombre.Text = sDes
        txtDiv.Text = sDiv

        sCve = sCve
        iTipo = iTipo

    End Sub

    Private Sub Baceptar_Click(sender As Object, e As EventArgs) Handles Baceptar.Click
        If iTipo = 2 Then

            sSQL = " UPDATE DIVISION SET "
            sSQL &= " CVEDIVISION = '" & txtDiv.Text.Trim() & "'"
            sSQL &= " ,DESCRIPCION = '" & Cnombre.Text.Trim() & "'"
            sSQL &= " WHERE CVE = '" & sCve.Trim() & "'"
            Using con As New SqlConnection(CadenaConexion())
                Dim cmd As New SqlCommand(sSQL, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
            End Using

            MsgBox("DIVISION ACTUALIZADO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "DIVISION")

            Me.Hide()
            Me.Dispose()

        ElseIf iTipo = 1 Then

            sSQL = " INSERT DIVISION (DESCRIPCION, CVEDIVISION) VALUES ( " & " '" & Cnombre.Text.Trim() & "' " & ", '" & txtDiv.Text.Trim() & "' )"
            Using con As New SqlConnection(CadenaConexion())
                Dim cmd As New SqlCommand(sSQL, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
            End Using

            MsgBox("DIVISION AGREGADO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "DIVISION")

            Me.Hide()
            Me.Dispose()


        End If
    End Sub

    Private Sub Bcancelar_Click(sender As Object, e As EventArgs) Handles Bcancelar.Click
        HabilitaMenu()
        Me.Hide()
        Me.Dispose()
    End Sub

End Class