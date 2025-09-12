Module mdlVariables

    Public clsDatos As clsAccesoDatos
    Public clsDatosUsr As clsAccesoDatos
    Public clsDatosInv As clsAccesoDatos
    Public clsLocal As clsAccesoDatos
    Public clsDatosConINV As clsAccesoDatos
    Public clsDatosProp As clsAccesoDatos

    Public ds As New DataSet

    Friend dtCarpetas As DataTable

    Friend sBaseDatos = "BDPPTO", sServidor = "GTMEXVTS27\SQL2016", sUsuarioBD = "Contabilidad", sContraseñaBD As String = "Control2025%Porfis"
    Friend sBaseDatosUsr As String = "CONUSRSYS"

    Friend sBaseDatosInv = "BDINV2425"
    Friend sServidorInv = "GTMEXVTS27\SQL2016", sUsuarioBDInv = "Contabilidad", sContraseñaBDInv As String = "Control2025%Porfis"

    Friend sBaseDatosLocal = "SAPYC2"
    Friend sServidorLocal = ".\sqlexpress"

    Friend dtCorreos, dtBasesDatos As New DataTable
    Friend idOficina, idArea, iAñoPpto, idUsuario, idRol, iTipoArea, idSocio, idCveSocio As Integer
    Friend sCveOfi, sCveArea, sOficina, sArea, sUsuario, sNombreSocio, sCorreoUsuario, sCveSocio As String

    Friend sFolderExcel, sFolderUserExcel, sFolderUserPrincipal, sFolderReportes, sRutaReportes, sRutaBDAccess As String

    Friend sCveUsuario As String = "0008"
    Friend sNombreUsuario As String = "DIRECCIÓN GENERAL"
    Friend sFmtDbl As String = "#,##0.00"

    Friend iPeriodoFirma = 11, iAñoActAn As Integer = 2023 'BuscaCampoTextoCon("SELECT TOP (1) iAñoAnteriorAc FROM PARAMETROS_REPORTES")

    '==================== Variables para el formato de grids ====================
    Friend FuenteCelda As New Font("Calibri", 11, FontStyle.Regular)
    Friend FuenteCeldaNgo As New Font("Calibri", 11, FontStyle.Bold)
    Friend FuenteFila As New Font("Calibri", 11, FontStyle.Bold)
    Friend FuenteHeader As New Font("Calibri", 10, FontStyle.Bold)
    Friend FuenteBoton As New Font("Calibri", 10, FontStyle.Bold)
    Friend Morado As Color = Color.FromArgb(79, 45, 127)
    Friend Const colGrid As Integer = 40
    Friend Const filGrid As Integer = 26

    '==================== Colores de Salles ===========================
    Friend negro As Color = Color.Black
    Friend blanco As Color = Color.White
    Friend gris As Color = Color.FromArgb(217, 217, 217)
    Friend total As Color = Color.Gainsboro
    Friend totalGrupo As Color = Color.WhiteSmoke
    Friend totalDivision As Color = Color.FromArgb(234, 234, 234)
    Friend morado_Salles As Color = Color.FromArgb(79, 45, 127)
    Friend azul_Salles As Color = Color.FromArgb(0, 167, 181)
    Friend rojo_Salles As Color = Color.FromArgb(233, 40, 65)
    Friend naranja_Salles As Color = Color.FromArgb(255, 125, 30)
    Friend verde_Salles As Color = Color.FromArgb(155, 215, 50)
    Friend gris_Salles As Color = Color.FromArgb(233, 40, 65)
    Friend amarillo_Salles As Color = Color.FromArgb(250, 224, 60)

    Friend bronce_Salles As Color = Color.FromArgb(205, 127, 50)
    Friend bronce_letra_Salles As Color = Color.FromArgb(108, 44, 18)

    Friend oro_Salles As Color = Color.FromArgb(239, 184, 16)
    Friend oro_letra_Salles As Color = Color.FromArgb(102, 67, 0)

    Friend platinum_Salles As Color = Color.FromArgb(229, 229, 229)
    Friend platinum_letra_Salles As Color = Color.FromArgb(85, 85, 85)

    Friend diamante_Salles As Color = Color.FromArgb(250, 250, 250)
    Friend diamante_letra_Salles As Color = Color.FromArgb(170, 170, 170)

End Module