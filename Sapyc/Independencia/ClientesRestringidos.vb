Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports SpreadsheetLight

Public Class ClientesRestringidos

    Private sHoja, sNombre, sListado, sCve, sRazon, sRFC As String
    Private iFila, iAnio, iMes As Integer
    Private dtExcelEntrada, dtAnteriores, dtExcelEntradaGral, dtRestringidos, dtDetalle As New DataTable
    Private drExcelEntrada, drInformacion, drExcelEntradaGral, drExcelDetalle As DataRow
    Private bsDet As New BindingSource

    Private Sub ClientesRestringidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dgLista.DataSource = bsDet
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
        End If

        dtExcelEntrada = importarDatosExcel(ofdArchivo.FileName)
        bsDet.DataSource = dtExcelEntrada
        formatoGrid()

        btnGuadar.Enabled = True

    End Sub
    Private Sub crearTablas()
        dtExcelEntrada = New DataTable
        dtExcelEntrada.Columns.Add("NUMCVE", GetType(System.String))
        dtExcelEntrada.Columns.Add("NOMBRE", GetType(System.String))
        dtExcelEntrada.Columns.Add("RFC", GetType(System.String))

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


            Me.dgLista.Columns("RFC").HeaderText = "CVE."
            Me.dgLista.Columns("RFC").Width = 50

            Me.dgLista.Columns("NOMBRE").HeaderText = "NOMBRE"
            Me.dgLista.Columns("NOMBRE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub btnGuadar_Click(sender As Object, e As EventArgs) Handles btnGuadar.Click
        Try
            InsertarDatosRTTabla()
            MsgBox("Se cargaron los datos con éxito.", MsgBoxStyle.Information, "Lista clientes restringidos")
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Public Function importarDatosExcel(sRuta As String) As DataTable
        Try

            Dim gral As New SLDocument(sRuta)

            iFila = 4
            limpiarFilasTabla(dtExcelEntrada)

            While gral.GetCellValueAsString("A" & iFila) <> String.Empty

                sCve = gral.GetCellValueAsString("A" & iFila)
                sRazon = gral.GetCellValueAsString("C" & iFila)
                sRFC = gral.GetCellValueAsString("B" & iFila)

                drExcelEntrada = dtExcelEntrada.NewRow
                drExcelEntrada("NOMBRE") = sRazon.Trim
                drExcelEntrada("RFC") = sRFC.Trim
                drExcelEntrada("NUMCVE") = sCve.Trim
                dtExcelEntrada.Rows.InsertAt(drExcelEntrada, dtExcelEntrada.Rows.Count)

                iFila += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return dtExcelEntrada
    End Function
    Private Sub InsertarDatosRTTabla()
        With clsLocal
            .funExecuteSPTabla("paInsertaCtesRestringidos", dtExcelEntrada)
        End With
    End Sub


End Class