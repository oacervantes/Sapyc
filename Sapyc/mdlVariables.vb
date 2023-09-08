Module mdlVariables

    Public clsDatos As clsAccesoDatos
    Public clsDatosUsr As clsAccesoDatos
    Public clsDatosInv As clsAccesoDatos
    Public clsLocal As clsAccesoDatos
    Public clsDatosConINV As clsAccesoDatos


    Public ds As New DataSet

    Friend dtCarpetas As DataTable

    Friend sBaseDatos = "BDPPTO", sServidor = "GTMEXVTS27\SQL2016", sUsuarioBD = "Contabilidad", sContraseñaBD As String = "Control2025%Porfis"
    Friend sBaseDatosUsr As String = "CONUSRSYS"

    Friend sBaseDatosInv = "BDINV2223"
    Friend sServidorInv = "GTMEXVTS27\SQL2016", sUsuarioBDInv = "Contabilidad", sContraseñaBDInv As String = "Control2025%Porfis"

    Friend sBaseDatosLocal = "SAPYC2"
    Friend sServidorLocal = ".\sqlexpress"

    Friend dtCorreos As New DataTable
    Friend idOficina, idArea, iAñoPpto, idUsuario, idRol, iTipoArea, idSocio, idCveSocio As Integer
    Friend sCveOfi, sCveArea, sOficina, sArea, sCveUsuario, sUsuario, sNombreUsuario, sNombreSocio, sCorreoUsuario, sCveSocio As String

    Friend sFolderExcel, sFolderUserExcel, sFolderUserPrincipal, sFolderReportes, sRutaReportes, sRutaBDAccess As String


End Module