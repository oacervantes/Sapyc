Imports System.Windows.Forms
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data
Imports System.Data.SqlClient
Public Class ClientesRestringidos

    Private excelLec As Excel.Application = New Excel.Application
    Private elWB As Excel.Workbook
    Private sHoja, sNombre, sListado As String
    Private iFila, iAnio, iMes As Integer
    Private dtExcelEntrada, dtAnteriores, dtExcelEntradaGral, dtRestringidos, dtDetalle As New DataTable
    Private drExcelEntrada, drInformacion, drExcelEntradaGral, drExcelDetalle As DataRow

    Private Sub btnGuadar_Click(sender As Object, e As EventArgs) Handles btnGuadar.Click

        MsgBox("REGISTROS GUARDADOS CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CLIENTES")
        HabilitaMenu()
        Me.Hide()
        Me.Dispose()

    End Sub

    Private bsDet As New BindingSource

    Private Sub ClientesRestringidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dgLista.DataSource = bsDet
        ListaClientesRestringidos()
        crearTablas()

    End Sub
    Private Sub Bcancelar_Click(sender As Object, e As EventArgs) Handles Bcancelar.Click
        HabilitaMenu()
        Me.Hide()
        Me.Dispose()
    End Sub
    Private Sub Baceptar_Click(sender As Object, e As EventArgs) Handles BCargar.Click

        If ofdArchivo.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtArchivo.Text = ofdArchivo.FileName
            importarDatosExcel(ofdArchivo.FileName)
        End If

        bsDet.DataSource = dtExcelEntrada
        formatoGrid()

        btnGuadar.Enabled = True

    End Sub
    Public Function importarDatosExcel(ByVal strPath As String) As DataTable
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-MX")

        excelLec = New Excel.Application

        Try
            elWB = excelLec.Workbooks.Open(strPath)
            iFila = 4

            For x As Integer = 1 To funObtenerNumeroHojas()
                sHoja = funObtenerNombreHoja(x)

                If sHoja = "Definitivos-SAT" Then
                    iFila = 4
                    With elWB
                        While CStr(.Worksheets(sHoja).Cells(iFila, 1).Value) <> String.Empty
                            drExcelEntradaGral = dtExcelEntrada.NewRow

                            sNombre = ""
                            sListado = ""
                            sListado = "SAT" ' .Worksheets(sHoja).Cells(iFila, 1).Value.ToString()
                            sNombre = .Worksheets(sHoja).Cells(iFila, 2).Value.ToString().Trim()

                            drExcelEntradaGral("LISTADO") = .Worksheets(sHoja).Cells(iFila, 1).Value.ToString().Trim()
                            If ValidaExisteCntRestringido(sNombre.Trim()) <> "" Then
                                drExcelEntradaGral("NOMBRE") = sNombre.Trim()

                                sSQL = " UPDATE CLIENTERESTRINGIDO SET "
                                sSQL &= " ELIMINADO = '" & 1 & "'"
                                sSQL &= " WHERE NOMBRE = '" & sNombre.Trim() & "'"
                                Using con As New SqlConnection(CadenaConexion())
                                    Dim cmd As New SqlCommand(sSQL, con)
                                    con.Open()
                                    Dim t As Integer = CInt(cmd.ExecuteScalar())
                                    con.Close()
                                End Using

                            Else

                                sSQL = " INSERT CLIENTERESTRINGIDO (Listado,NOMBRE,Eliminado,RegistradoEl,RegistradoPor,ActualizadoEl,ActualizadoPor) VALUES (" & "'" & sListado.Trim() & "'" & "," & "'" & sNombre.Trim() & "'" & ",1,GETDATE(),1,GETDATE(),1)"
                                Using con As New SqlConnection(CadenaConexion())
                                    Dim cmd As New SqlCommand(sSQL, con)
                                    con.Open()
                                    Dim t As Integer = CInt(cmd.ExecuteScalar())
                                    con.Close()
                                End Using

                            End If

                            dtExcelEntrada.Rows.InsertAt(drExcelEntradaGral, dtExcelEntrada.Rows.Count)

                            iFila += 1
                        End While
                    End With

                End If
            Next

            elWB.Close(False)
            elWB = Nothing

            excelLec.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelLec)
            excelLec = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        Return dtExcelEntrada
    End Function
    Private Function funObtenerNombreHoja(NumH As Integer) As String
        Dim name As String

        name = elWB.Sheets(NumH).name

        Return name
    End Function
    Private Function funObtenerNumeroHojas() As Integer
        Dim iHojas As Integer

        Try
            iHojas = elWB.Sheets.Count
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return iHojas
    End Function
    Private Sub crearTablas()
        dtExcelEntrada = New DataTable
        dtExcelEntrada.Columns.Add("LISTADO", GetType(System.String))
        dtExcelEntrada.Columns.Add("NOMBRE", GetType(System.String))

    End Sub
    Private Sub ListaClientesRestringidos()

        Dim cnn As New SqlConnection(CadenaConexionSapyc())
        sSQL = "SELECT CVE, NOMBRE FROM CLIENTERESTRINGIDO ORDER BY CVE ASC "
        Dim da As New SqlDataAdapter(sSQL, cnn)
        Dim ds As New DataSet
        da.Fill(ds)
        dtRestringidos = ds.Tables(0)

    End Sub
    Private Function ValidaExisteCntRestringido(Cliente As String) As String
        Dim sValor = ""
        Dim dr() As DataRow

        dr = dtRestringidos.Select("NOMBRE = '" & Cliente & "' ")
        If dr.Count > 0 Then
            sValor = dr(0).Item("NOMBRE").ToString
        End If

        Return sValor

    End Function
    Private Sub formatoGrid()
        Try
            For Each col As DataGridViewColumn In Me.dgLista.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next


            Me.dgLista.Columns("LISTADO").HeaderText = "CVE."
            Me.dgLista.Columns("LISTADO").Width = 50

            Me.dgLista.Columns("NOMBRE").HeaderText = "NOMBRE"
            Me.dgLista.Columns("NOMBRE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


End Class