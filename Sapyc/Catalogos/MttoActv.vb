Imports System.Data
Imports System.Data.SqlClient

Public Class MttoActv
    Public sCve As String
    Public sDes As String
    Public iTipo As Integer

    Private Sub MttoActv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cnombre.Text = sDes
        sCve = sCve
        iTipo = iTipo

        If iTipo = 1 Then

            lblGiro.Visible = True
            cmbGiros.Visible = True

            sSQL = "SELECT CVE,DESCRIPCION FROM GIROS ORDER BY CVE"
            Carga_ComboSapyc(cmbGiros, sSQL)

        End If



    End Sub

    Private Sub Bcancelar_Click(sender As Object, e As EventArgs) Handles Bcancelar.Click
        HabilitaMenu()
        Me.Hide()
        Me.Dispose()
    End Sub

    Private Sub Baceptar_Click(sender As Object, e As EventArgs) Handles Baceptar.Click
        If iTipo = 2 Then

            sSQL = " UPDATE ACTIVIDAD SET "
            sSQL &= " DESCRIPCION = '" & Cnombre.Text.Trim() & "'"
            sSQL &= " WHERE CVE = '" & sCve.Trim() & "'"
            Using con As New SqlConnection(CadenaConexion())
                Dim cmd As New SqlCommand(sSQL, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
            End Using

            MsgBox("ACTIVIDAD ACTUALIZADO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ACTIVIDAD")

            Me.Hide()
            Me.Dispose()

        ElseIf iTipo = 1 Then
            Dim IdGiro As Integer = cmbGiros.SelectedValue

            sSQL = " INSERT ACTIVIDAD (DESCRIPCION, CVEGIRO) VALUES ( " & " '" & Cnombre.Text.Trim() & "' " & ", '" & cmbGiros.SelectedValue & "' )"
            Using con As New SqlConnection(CadenaConexion())
                Dim cmd As New SqlCommand(sSQL, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
            End Using

            MsgBox("ACTIVIDAD AGREGADO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ACTIVIDAD")

            Me.Hide()
            Me.Dispose()


        End If
    End Sub
End Class