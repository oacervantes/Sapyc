Imports System.Data
Imports System.Data.SqlClient
Public Class BuscaCtesFis
    Public DeDonde As Integer
    Public Vcvecte As String
    Public Vnombrecte As String
    Public AltaCte As Boolean = False
    Public VnombrecteTem As String

    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource


    Public Sub CargaDatos(ByVal qsql As String)
        Try
            ' Inicializar la conexión y abrir   
            Using cn As SqlConnection = New SqlConnection(CadenaConexion)
                cn.Open()

                ' Inicializar DataAdapter indicando el sql para recuperar    
                'los registros de la tabla   
                '                sSQL = "SELECT CVEEMP, NOMBRE, CVEPUESTO FROM EMPLEADOS WHERE STATUS = 'A' ORDER BY CVEEMP ASC "
                Dim da As New SqlDataAdapter(qsql, cn)
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

    Private Sub Ccvecte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Aplicar_FiltroCve()
    End Sub

    Private Sub Aplicar_FiltroCve()

        ' filtrar por el campo Cvetra   

        Dim ret As Integer = Filtrar_DataGridView("NOMBRE", Cnombrecte.Text.Trim, BindingSource1, Lista)

        If ret = 0 Then
            ' si no hay registros cambiar el color del txtbox   
            ' Ccvecte.BackColor = Color.Red
        Else
            'Ccvecte.BackColor = Color.White
        End If
        ' visualizar la cantidad de registros   
        Contador.Text = ret

    End Sub

    Function Filtrar_DataGridView(ByVal Columna As String, ByVal texto As String, ByVal BindingSource As BindingSource, _
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

    Private Sub Cnombrecte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cnombrecte.TextChanged
        Aplicar_FiltroNombre()
    End Sub
    Private Sub Aplicar_FiltroNombre()

        ' filtrar por el campo Nombrecte

        Dim ret As Integer = Filtrar_DataGridView("NOMBRE", Cnombrecte.Text.Trim, BindingSource1, Lista)

        If ret = 0 Then
            ' si no hay registros cambiar el color del txtbox   
            Cnombrecte.BackColor = Color.Red
            If MsgBox("¿Dar de alta cliente?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alta") = MsgBoxResult.Yes Then
                AltaCte = True
                Vcvecte = ""
                Vnombrecte = ""
                VnombrecteTem = Cnombrecte.Text
                Me.Hide()
                MttoPropuesta.Focus()
            End If
        Else
            Cnombrecte.BackColor = Color.White
        End If
        ' visualizar la cantidad de registros   
        Contador.Text = ret

    End Sub

    Private Sub Baceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Baceptar.Click
        If Lista.SelectedRows.Count > 0 Then
            Vcvecte = Lista.CurrentRow().Cells(0).Value
            Vnombrecte = Lista.CurrentRow().Cells(1).Value
        Else
            Vcvecte = ""
            Vnombrecte = ""
        End If
        Me.Hide()
        MttoPropuesta.Focus()
    End Sub

    Private Sub Lista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lista.DoubleClick
        If Lista.SelectedRows.Count > 0 Then
            Call Baceptar_Click(Nothing, Nothing)
        End If
    End Sub
End Class