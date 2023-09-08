Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Office.Interop

Public Class clsAccesoDatos
    Private cnn As SqlConnection
    Private sCadenaConexion As String
    Private sServer, sDatabase, sUser, sPassword As String
    Private m_bInTransaction As Boolean
    Private cllParametros As New Collection
    Public trTransaccion As SqlClient.SqlTransaction



#Region "SUBS"
    Public Sub New(ByVal strDatasource As String, ByVal strInitialCatalog As String, ByVal strUserId As String, ByVal strPassword As String)
        sServer = strDatasource
        sDatabase = strInitialCatalog
        sUser = strUserId
        sPassword = strPassword

        If sServer = ".\sqlexpress" Then
            sCadenaConexion = "Data Source=.\sqlexpress;Initial Catalog=SAPYC2;Integrated Security=True" ' servidor local
        Else
            sCadenaConexion = "Data Source=" & sServer & ";Initial Catalog=" & sDatabase & ";User ID=" & sUser & ";Password=" & sPassword & ";"
        End If




    End Sub
    Public Sub subClearParameters()
        Try
            For i As Integer = cllParametros.Count To 1 Step -1
                cllParametros.Remove(i)
            Next
        Catch ex As Exception
            Err.Raise(vbObjectError + 514, "Capa de acceso a datos", ex.Message)
        End Try
    End Sub
    Public Sub subAddParameter(ByVal sName As String, ByVal objValue As Object, ByVal iDataType As SqlDbType, ByVal iDirection As ParameterDirection)
        Dim Parametro As SqlParameter = New SqlParameter
        Parametro.SqlDbType = iDataType
        Parametro.Value = objValue
        Parametro.ParameterName = sName
        Parametro.Direction = iDirection
        cllParametros.Add(Parametro)
    End Sub
    Public Sub subAddParameter(ByVal sName As String, ByVal objValue As Object, ByVal iDataType As SqlDbType, ByVal iDirection As ParameterDirection, ByVal iSize As Integer)
        Dim Parametro As SqlParameter = New SqlParameter
        Parametro.SqlDbType = iDataType
        Parametro.Value = objValue
        Parametro.ParameterName = sName
        Parametro.Direction = iDirection
        Parametro.Size = iSize
        cllParametros.Add(Parametro)
    End Sub
    Public Sub subStartTransaction()
        Try
            If cnn Is Nothing Then
                cnn = New SqlConnection
            End If

            If cnn.State = ConnectionState.Closed Then
                cnn.ConnectionString = sCadenaConexion
                cnn.Open()
            End If

            trTransaccion = cnn.BeginTransaction()
        Catch ex As Exception
            If Not cnn Is Nothing Then
                cnn.Close()
                cnn.Dispose()
            End If
            Throw New Exception("No se inició la transacción.", ex)
        End Try
    End Sub
    Public Sub subCommitTransaction()
        Try
            If Not trTransaccion Is Nothing Then
                trTransaccion.Commit()
                trTransaccion.Dispose()
            End If
        Catch ex As Exception
            Throw New Exception("No se confirmó la transacción", ex)
        Finally
            If Not trTransaccion Is Nothing Then
                trTransaccion.Dispose()
            End If

            If Not cnn Is Nothing Then
                cnn.Close()
                cnn.Dispose()
            End If
        End Try
    End Sub
    Public Sub subCancelTransaction()
        Try
            If Not trTransaccion Is Nothing Then
                trTransaccion.Rollback()
                trTransaccion.Dispose()
            End If
        Catch ex As Exception
            Throw New Exception("No se deshizo la transacción.", ex)
        Finally
            If Not trTransaccion Is Nothing Then
                trTransaccion.Dispose()
            End If

            If Not cnn Is Nothing Then
                cnn.Close()
                cnn.Dispose()
            End If
        End Try
    End Sub

#End Region

#Region "FUNCIONES"

    Public Function funGetParameterValue(ByVal sName As String) As Object
        Dim Parametro As SqlParameter
        Try
            For Each Parametro In cllParametros
                If Parametro.ParameterName = sName Then
                    Return Parametro.Value
                End If
            Next
            Return String.Empty
        Catch ex As Exception
            Err.Raise(vbObjectError + 514, "Capa de acceso a datos", "No existe el parámetro en la colección")
            Return String.Empty
        End Try
    End Function
    Public Function funExecuteSPDataTable(ByVal strSPName As String, Optional ByVal strAlias As String = "") As System.Data.DataTable
        Dim cmd As New SqlCommand
        Dim prmtr As New SqlParameter
        Dim dTable As New DataTable
        Dim dAdapter As New SqlDataAdapter

        Try
            If cnn Is Nothing Then
                cnn = New SqlConnection
            End If

            If cnn.State = ConnectionState.Closed Then
                cnn.ConnectionString = sCadenaConexion
                cnn.Open()
            End If

            cmd.CommandText = strSPName
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 90

            If Not cllParametros Is Nothing Then
                For Each prmtr In cllParametros
                    cmd.Parameters.Add(prmtr)
                Next prmtr
            End If

            cmd.Connection = cnn

            If Not trTransaccion Is Nothing Then
                cmd.Transaction = trTransaccion
            End If

            dAdapter.SelectCommand = cmd
            dAdapter.Fill(dTable)

            If strAlias = String.Empty Then
                dTable.TableName = strSPName
            Else
                dTable.TableName = strAlias
            End If
        Catch exSqlClient As SqlException
            If Not trTransaccion Is Nothing Then
                subCancelTransaction()
            End If
            If exSqlClient.Number = 50000 Then
                Err.Raise(vbObjectError + 513, "Capa de acceso a datos", exSqlClient.Message)
            ElseIf exSqlClient.Number = 229 Then
                Err.Raise(vbObjectError + 513, "Capa de acceso a datos", "Acceso denegado para el usuario " + sUser)
            ElseIf exSqlClient.Number = 15330 Then
                If strAlias = String.Empty Then
                    dTable.TableName = strSPName
                Else
                    dTable.TableName = strAlias
                End If
            Else
                Err.Raise(exSqlClient.Number, "Capa de acceso a datos", exSqlClient.Message)
            End If
        Catch ex As Exception
            Err.Raise(vbObjectError + 514, "Capa de acceso a datos", ex.Message)
        Finally
            dAdapter.Dispose()
            cmd.Dispose()
            If trTransaccion Is Nothing Then
                cnn.Close()
                cnn.Dispose()
            End If
        End Try

        Return dTable
    End Function
    Public Function funExecuteSP(ByVal strSPName As String) As Integer
        Dim cmd As New SqlCommand
        Dim prmtr As New SqlParameter
        Dim intReturnValue As Integer

        Try
            If cnn Is Nothing Then
                cnn = New SqlConnection
            End If

            If cnn.State = ConnectionState.Closed Then
                cnn.ConnectionString = sCadenaConexion
                cnn.Open()
            End If

            cmd.CommandText = strSPName
            cmd.CommandType = CommandType.StoredProcedure

            If Not cllParametros Is Nothing Then
                For Each prmtr In cllParametros
                    cmd.Parameters.Add(prmtr)
                Next
            End If

            cmd.Connection = cnn

            If Not trTransaccion Is Nothing Then
                cmd.Transaction = trTransaccion
            End If

            intReturnValue = cmd.ExecuteNonQuery

            Return intReturnValue

            Exit Function
        Catch exSqlClient As SqlException
            If Not trTransaccion Is Nothing Then
                Me.subCancelTransaction()
            End If

            If exSqlClient.Number = 50000 Then
                Err.Raise(vbObjectError + 513, "Capa de acceso a datos", exSqlClient.Message)
            ElseIf exSqlClient.Number = 229 Then
                Err.Raise(vbObjectError + 513, "Capa de acceso a datos", "Acceso denegado para el usuario " + sUser)
            Else
                Err.Raise(exSqlClient.Number, "Capa de acceso a datos", exSqlClient.Message)
            End If
        Catch ex As Exception
            Err.Raise(vbObjectError + 514, "Capa de acceso a datos", ex.Message)
        Finally
            cmd.Dispose()

            If trTransaccion Is Nothing Then
                cnn.Close()
                cnn.Dispose()
            End If
        End Try
    End Function
    Public Function funExecuteSPValue(ByVal strSPName As String) As Object
        Dim cmd As New SqlCommand
        Dim prmtr As New SqlParameter
        Dim objValueRetorno As Object

        Try
            If cnn Is Nothing Then
                cnn = New SqlConnection
            End If

            If cnn.State = ConnectionState.Closed Then
                cnn.ConnectionString = sCadenaConexion
                cnn.Open()
            End If

            cmd.CommandText = strSPName
            cmd.CommandType = CommandType.StoredProcedure

            If Not cllParametros Is Nothing Then
                For Each prmtr In cllParametros
                    cmd.Parameters.Add(prmtr)
                Next
            End If

            cmd.Connection = cnn

            If Not trTransaccion Is Nothing Then
                cmd.Transaction = trTransaccion
            End If

            objValueRetorno = cmd.ExecuteScalar
            Return objValueRetorno
            Exit Function
        Catch exSqlClient As SqlException
            If Not trTransaccion Is Nothing Then
                subCancelTransaction()
            End If
            If exSqlClient.Number = 50000 Then
                Err.Raise(vbObjectError + 513, "Capa de acceso a datos", exSqlClient.Message)
            ElseIf exSqlClient.Number = 229 Then
                Err.Raise(vbObjectError + 513, "Capa de acceso a datos", "Acceso denegado para el usuario " + sUser)
            Else
                Err.Raise(exSqlClient.Number, "Capa de acceso a datos", exSqlClient.Message)
            End If
        Catch ex As Exception
            Err.Raise(vbObjectError + 514, "Capa de acceso a datos", ex.Message)
        Finally
            cmd.Dispose()

            If trTransaccion Is Nothing Then
                cnn.Close()
                cnn.Dispose()
            End If
        End Try

        Return String.Empty
    End Function
    Public Function funExecuteQueryDataTable(ByVal strSQL As String) As System.Data.DataTable
        Dim cmd As New SqlCommand
        Dim prmtr As New SqlParameter
        Dim dTable As New DataTable
        Dim dAdapter As New SqlDataAdapter

        Try
            If cnn Is Nothing Then
                cnn = New SqlConnection
            End If

            If cnn.State = ConnectionState.Closed Then
                cnn.ConnectionString = sCadenaConexion
                cnn.Open()
            End If

            cmd.CommandText = strSQL
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn
            dAdapter.SelectCommand = cmd
            dAdapter.Fill(dTable)
            Return dTable
            Exit Function

        Catch exSqlClient As SqlException
            If exSqlClient.Number = 50000 Then
                Err.Raise(vbObjectError + 513, "Capa de acceso a datos", exSqlClient.Message)
            ElseIf exSqlClient.Number = 229 Then
                Err.Raise(vbObjectError + 513, "Capa de acceso a datos", "Acceso denegado para el usuario " + sUser)
            Else
                Err.Raise(exSqlClient.Number, "Capa de acceso a datos", exSqlClient.Message)
            End If
        Catch ex As Exception
            Err.Raise(vbObjectError + 514, "Capa de acceso a datos", ex.Message)
        Finally
            dAdapter.Dispose()
            cmd.Dispose()

            If trTransaccion Is Nothing Then
                cnn.Close()
                cnn.Dispose()
            End If
        End Try

        Return dTable
    End Function
    Public Function funExecuteFunction(ByVal strFunction As String) As String
        Dim cmd As New SqlCommand
        Dim prmtr As New SqlParameter
        Dim sqlDR As SqlDataReader
        Dim strSQL As String = ""
        Dim strDato As String = ""

        Try
            If cnn Is Nothing Then
                cnn = New SqlConnection
            End If

            If cnn.State = ConnectionState.Closed Then
                cnn.ConnectionString = sCadenaConexion
                cnn.Open()
            End If
            cmd.Connection = cnn

            cmd.CommandText = strFunction
            cmd.CommandType = CommandType.Text

            sqlDR = cmd.ExecuteReader()
            sqlDR.Read()
            strDato = sqlDR.Item(0)
            sqlDR.Close()

            If Not trTransaccion Is Nothing Then
                cmd.Transaction = trTransaccion
            End If

            Return strDato
            Exit Function

        Catch exSqlClient As SqlException
            If Not trTransaccion Is Nothing Then
                subCancelTransaction()
            End If

            If exSqlClient.Number = 50000 Then
                Err.Raise(vbObjectError + 513, "Capa de acceso a datos", exSqlClient.Message)
            ElseIf exSqlClient.Number = 229 Then
                Err.Raise(vbObjectError + 513, "Capa de acceso a datos", "Acceso denegado para el usuario " + sUser)
            Else
                Err.Raise(exSqlClient.Number, "Capa de acceso a datos", exSqlClient.Message)
            End If
            Return strDato
        Catch ex As Exception
            Err.Raise(vbObjectError + 514, "Capa de acceso a datos", ex.Message)
            Return strDato
        Finally
            cmd.Dispose()
            If trTransaccion Is Nothing Then
                cnn.Close()
                cnn.Dispose()
            End If
        End Try
    End Function

#End Region

End Class