Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class MttoGrupo
    Public dedonde As Integer
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private PasaNomb As Boolean = False
    Private Cliente, CveCliente As String

    Private Sub Bcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcancelar.Click
        If MsgBox("¿Cancelar cambios del registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancelar edición") = MsgBoxResult.Yes Then
            Me.Dispose()
            Grupos.Show()
        End If

    End Sub
    Private Sub Baceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Baceptar.Click

        If Ccvegpo.Text = "" Then
            MsgBox("No se capturo la clave del Grupo", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error en captura")
            Exit Sub
        End If
        If Cdescgpo.Text = "" Then
            MsgBox("No se capturo la descripción del Grupo", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error en captura")
            Exit Sub
        End If
        If dedonde = 1 Then
            Dim sCon As String = CadenaConexion()
            Dim sel As String
            NombreTabla = "GRUPOS"
            sel = "INSERT INTO " & NombreTabla &
                "(CVEGPO, DESCGPO) " &
                "VALUES " &
                "(@CVEGPO, @DESCGPO) "

            Using con As New SqlConnection(sCon)
                Dim cmd As New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("@CVEGPO", Ccvegpo.Text)
                cmd.Parameters.AddWithValue("@DESCGPO", Cdescgpo.Text.ToUpper())
                'cmd.Parameters.AddWithValue("@CVECTE", CveCliente)
                'cmd.Parameters.AddWithValue("@NOMBCTE", Cliente)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
            End Using
        End If
        If dedonde = 2 Then
            Dim sCon As String = CadenaConexion()
            Dim sel As String
            NombreTabla = "GRUPOS"
            sel = "UPDATE " & NombreTabla &
                " SET DESCGPO = @DESCGPO " &
                " WHERE CVEGPO = @CVEGPO"

            Using con As New SqlConnection(sCon)
                Dim cmd As New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("@CVEGPO", Ccvegpo.Text)
                cmd.Parameters.AddWithValue("@DESCGPO", Cdescgpo.Text.ToUpper())
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End If
        Grupos.ObtenerMostrarDatos()
        BuscaProximo(Grupos.Lista, 0, Ccvegpo.Text)
        Grupos.Show()
        Me.Dispose()

    End Sub
    Public Sub CargaDatos()
        Try

            sSQL = "SELECT CVECTENEW,NOMBRECTE NOMBRE FROM CLIENTES ORDER BY NOMBRE"

            ' Inicializar la conexión y abrir   
            Using cn As SqlConnection = New SqlConnection(CadenaConexionSiat)
                cn.Open()

                ' Inicializar DataAdapter indicando el sql para recuperar    
                'los registros de la tabla   
                '                sSQL = "SELECT CVEEMP, NOMBRE, CVEPUESTO FROM EMPLEADOS WHERE STATUS = 'A' ORDER BY CVEEMP ASC "
                Dim da As New SqlDataAdapter(sSQL, cn)
                Dim dt As New DataTable ' crear un DataTable   

                ' llenarlo   
                da.Fill(dt)

                ' enlazar el DataTable al BindingSource   
                BindingSource1.DataSource = dt
                Lista.DataSource = BindingSource1.DataSource

                ' Lista.Columns("CVECTE").HeaderText = "No"
                Lista.Columns("NOMBRE").HeaderText = "Nombre"
                Lista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                Lista.Columns(0).Width = 80
                Lista.Columns(1).Width = 300

            End Using
            ' errores   
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Function Filtrar_DataGridView(ByVal Columna As String, ByVal texto As String, ByVal BindingSource As BindingSource,
    ByVal DataGridView As DataGridView) As Integer

        ' verificar que el DataSource no esté vacio   
        If BindingSource1.DataSource Is Nothing Then
            Return 0
        End If

        Try

            Dim filtro As String = String.Empty

            'filtro = "like '" & texto.Trim & "%'"
            filtro = "like '%" & texto.Trim & "%'"

            ' Seleccionar la opción    
            '            Select Case Opcion_Filtro
            '               Case e_FILTER_OPTION.CADENA_QUE_COMIENCE_CON
            '                    filtro = "like '" & texto.Trim & "%'"
            '                 Case e_FILTER_OPTION.CADENA_QUE_NO_COMIENCE_CON
            '                    filtro = "Not like '" & texto.Trim & "%'"
            '                Case e_FILTER_OPTION.CADENA_QUE_NO_CONTENGA
            '                    filtro = "Not like '%" & texto.Trim & "%'"
            '                Case e_FILTER_OPTION.CADENA_QUE_CONTENGA
            '                    filtro = "like '%" & texto.Trim & "%'"
            '                Case e_FILTER_OPTION.CADENA_IGUAL
            '                    filtro = "='" & texto.Trim & "'"
            '            End Select

            ' Opción para no filtrar   
            '            If Opcion_Filtro = e_FILTER_OPTION.SIN_FILTRO Then
            ' filtro = String.Empty
            ' End If

            ' armar el sql   
            If filtro <> String.Empty Then
                filtro = "[" & Columna & "]" & filtro
            End If

            ' asigar el criterio a la propiedad Filter del BindingSource   
            BindingSource.Filter = filtro
            ' enlzar el datagridview al BindingSource   
            DataGridView.DataSource = BindingSource.DataSource

            ' retornar la cantidad de registros encontrados   
            Return BindingSource.Count

            ' errores   
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try

        Return 0

    End Function
    Private Sub Cnombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cnombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cnombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cnombre.TextChanged
        '  If PasaNomb Then
        If Cnombre.Text.Length > 0 Then
                CargaDatos()
                Aplicar_FiltroNombre()
            End If

        'End If
    End Sub
    Private Sub Aplicar_FiltroNombre()

        Lista.Visible = True
        ' filtrar por el campo Nombrecte
        Dim ret As Integer = Filtrar_DataGridView("NOMBRE", Cnombre.Text.Trim, BindingSource1, Lista)

        If ret > 0 Then
            ' si no hay registros cambiar el color del txtbox   
            'Cnombre.BackColor = Color.Red
            'If MsgBox("¿Este cliente se encuentra en las listas de clientes restringidos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta") = MsgBoxResult.Yes Then
            '    AltaCte = True
            'End If
        Else
            Cnombre.BackColor = Color.White
            Lista.Visible = False
        End If

    End Sub
    Private Sub Lista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lista.DoubleClick
        If Lista.SelectedRows.Count > 0 Then

            Lista.Visible = True
            ' filtrar por el campo Nombrecte
            Dim ret As Integer = Filtrar_DataGridView("NOMBRE", Cnombre.Text.Trim, BindingSource1, Lista)

            If ret > 0 Then
                ' si no hay registros cambiar el color del txtbox   
                'Cnombre.BackColor = Color.Red
                'If MsgBox("¿Este cliente se encuentra en las listas de clientes restringidos y no podras usarlo, si continuas se cerrara la pantalla?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta") = MsgBoxResult.Yes Then

                Lista.Visible = False
                PasaNomb = False
                Cliente = Lista.CurrentRow.Cells("NOMBRE").Value
                CveCliente = Lista.CurrentRow.Cells("CVECTENEW").Value
                Cnombre.Text = Lista.CurrentRow.Cells("NOMBRE").Value


                ' End If
            Else
                Cnombre.BackColor = Color.White
            End If

        End If
    End Sub


End Class