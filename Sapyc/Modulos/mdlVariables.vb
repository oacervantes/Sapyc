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
    Friend sCveOfi, sCveArea, sOficina, sArea, sUsuario, sNombreSocio, sCorreoUsuario, sCveSocio As String

    Friend sFolderExcel, sFolderUserExcel, sFolderUserPrincipal, sFolderReportes, sRutaReportes, sRutaBDAccess As String

    Friend sCveUsuario As String = "0008"
    Friend sNombreUsuario As String = "DIRECCIÓN GENERAL"
    Friend sFmtDbl As String = "#,##0.00"

    '==================== Variables para el formato de grids ====================
    Friend FuenteCelda As Font = New Font("Calibri", 11, FontStyle.Regular)
    Friend FuenteCeldaNgo As Font = New Font("Calibri", 11, FontStyle.Bold)
    Friend FuenteFila As Font = New Font("Calibri", 11, FontStyle.Bold)
    Friend FuenteHeader As Font = New Font("Calibri", 10, FontStyle.Bold)
    Friend FuenteBoton As Font = New Font("Calibri", 10, FontStyle.Bold)
    Friend Morado As Color = Color.FromArgb(79, 45, 127)
    Friend Const colGrid As Integer = 40
    Friend Const filGrid As Integer = 26

    '==================== Colores de Salles ===========================
    Friend negro As Color = Color.Black
    Friend blanco As Color = Color.White
    Friend total As Color = Color.Gainsboro
    Friend totalGrupo As Color = Color.WhiteSmoke
    Friend morado_Salles As Color = Color.FromArgb(79, 45, 127)
    Friend azul_Salles As Color = Color.FromArgb(0, 167, 181)
    Friend rojo_Salles As Color = Color.FromArgb(233, 40, 65)
    Friend naranja_Salles As Color = Color.FromArgb(255, 125, 30)
    Friend verde_Salles As Color = Color.FromArgb(155, 215, 50)
    Friend gris_Salles As Color = Color.FromArgb(233, 40, 65)

End Module