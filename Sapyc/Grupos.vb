Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class Grupos
    Private SqlConection1 As SqlConnection
    Private SqlDataAdaptader1 As SqlDataAdapter
    Private SqlSelectCommand1 As SqlCommand
    Private SqlInsertCommand1 As SqlCommand
    Private SqlUpdateCommand1 As SqlCommand
    Private SqlDeleteCommand1 As SqlCommand
    Private DataSet1 As DataSet
    Public Bandera As Boolean

    Private Sub Bsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsalir.Click
        HabilitaMenu()
        Me.Dispose()
        Principal.Show()

    End Sub

    Private Sub Grupos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrearIniciarComponentes()
        ObtenerMostrarDatos()

        If Bandera Then
            btnRelacion.Visible = True
        End If

    End Sub

    Private Sub CrearIniciarComponentes()
        SqlConection1 = New SqlConnection
        '        SqlConection1.ConnectionString = "Data Source=.\sqlexpress;Initial Catalog=BDINVENTA; " & "Integrated Security=True"
        SqlConection1.ConnectionString = CadenaConexionSiat()

        SqlDataAdaptader1 = New SqlDataAdapter

        SqlSelectCommand1 = New SqlCommand
        SqlInsertCommand1 = New SqlCommand
        SqlUpdateCommand1 = New SqlCommand
        SqlDeleteCommand1 = New SqlCommand

        SqlDataAdaptader1.DeleteCommand = SqlDeleteCommand1
        SqlDataAdaptader1.InsertCommand = SqlInsertCommand1
        SqlDataAdaptader1.SelectCommand = SqlSelectCommand1
        SqlDataAdaptader1.UpdateCommand = SqlUpdateCommand1

        SqlSelectCommand1.Connection = SqlConection1
        SqlUpdateCommand1.Connection = SqlConection1
        SqlInsertCommand1.Connection = SqlConection1
        SqlDeleteCommand1.Connection = SqlConection1


        DataSet1 = New DataSet

    End Sub

    Public Sub ObtenerMostrarDatos()
        SqlSelectCommand1.CommandText = "SELECT CVEGPO,DESCGPO FROM GRUPOS ORDER BY CVEGPO ASC "
        SqlConection1.Open()
        DataSet1.Clear()
        SqlDataAdaptader1.Fill(DataSet1, "GRUPOS")
        SqlConection1.Close()

        Lista.DataSource = DataSet1.Tables("GRUPOS")
        Lista.Columns("CVEGPO").HeaderText = "Clave"
        Lista.Columns("DESCGPO").HeaderText = "Descripción"
        'Lista.Columns("CVECTE").HeaderText = "Clave Cliente"
        'Lista.Columns("NOMBRECTE").HeaderText = "Nombre Cliente"

        Lista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Lista.Columns(0).Width = 60
        Lista.Columns(1).Width = 60
        Lista.Columns(0).Width = 60
        Lista.Columns(1).Width = 300

        Lista.Width = Lista.Columns(0).Width + Lista.Columns(1).Width + 15 + 15
        Lista.Left = Int((Me.Width - Lista.Width) / 2)

        If Lista.Rows.Count > 0 Then
            Bbaja.Enabled = True
            Bmodificar.Enabled = True
        Else
            Bbaja.Enabled = False
            Bmodificar.Enabled = False
        End If

    End Sub


    Private Sub Balta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Balta.Click
        Dim qcve As String
        Dim ii As Double
        Dim hayado As Integer


        If MsgBox("Estas seguro de dar de alta un nuevo registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta") = MsgBoxResult.Yes Then
            '            qcve = InputBox("Clave Area:", "Alta", Space(4))

            '            LeeCve.MdiParent = Principal
            LeeCve.Text = "Clave a dar de Alta"
            LeeCve.Ccve.MaxLength = 4
            LeeCve.Letrero.Text = "Clave Grupo:"
            LeeCve.ShowDialog()

            qcve = LeeCve.Ccve.Text
            LeeCve.Dispose()
            If qcve = "" Then
                Exit Sub
            End If
            ' qcve = PonCeros4(Val(qcve))
            hayado = 0
            ii = 0
            Do While ii < Lista.RowCount And hayado = 0
                If Lista.Rows(ii).Cells(0).Value = qcve Then
                    hayado = 1
                    MsgBox("El numero de empleado ya existe", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Dato existente")
                    Lista.Rows(ii).Selected = True
                    ' nos aseguramos de que sea visible
                    Me.Lista.FirstDisplayedScrollingRowIndex = ii
                Else
                    ii = ii + 1
                End If
            Loop

            If hayado = 0 Then
                MttoGrupo.Text = "Alta de Grupo"
                MttoGrupo.dedonde = 1
                MttoGrupo.Ccvegpo.Text = qcve
                MttoGrupo.ShowDialog()
            End If
        End If

    End Sub

    Private Sub Bmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bmodificar.Click
        If Lista.SelectedRows.Count > 0 Then
            MttoGrupo.Text = "Edición de Grupo"
            MttoGrupo.dedonde = 2
            MttoGrupo.Ccvegpo.Text = Lista.CurrentRow().Cells(0).Value
            MttoGrupo.Cdescgpo.Text = Lista.CurrentRow().Cells(1).Value
            MttoGrupo.ShowDialog()
        End If

    End Sub

    Private Sub Bbaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bbaja.Click
        Dim qcve As String
        qcve = Lista.CurrentRow().Cells(0).Value

        If MsgBox("Estas seguro de dar de baja el registro " & qcve & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Baja de registro") = MsgBoxResult.Yes Then
            If MsgBox("Confirma la baja del registro " & qcve & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Baja de registro") = MsgBoxResult.Yes Then
                NombreTabla = "GRUPOS"
                Dim sCon As String = CadenaConexion()
                Dim sel As String = "DELETE FROM " & NombreTabla & " WHERE CVEGRUPO = '" & qcve & "'"

                Using con As New SqlConnection(sCon)
                    Dim cmd As New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("CVEGRUPO", qcve)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
                ObtenerMostrarDatos()
            End If
        End If

    End Sub


    Private Sub Lista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Lista.CellDoubleClick
        If Bmodificar.Enabled Then
            Call Bmodificar_Click(Nothing, Nothing)
        End If

    End Sub

End Class