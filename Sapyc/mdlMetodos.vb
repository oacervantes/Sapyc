Module mdlMetodos

    Public Sub LimpiarConsultaTabla(dt As DataTableCollection, sTabla As String)
        If dt.Contains(sTabla) Then
            dt.Remove(sTabla)
        End If
    End Sub

End Module