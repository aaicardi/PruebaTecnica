// ***********************************************************************
// Assembly         : XianaCore.Common
// Author           : Pablo Restrepo
// Created          : 07-17-2020
//
// Last Modified By : Pablo Restrepo
// Last Modified On : 07-23-2020
// ***********************************************************************
// <copyright file="ApplicationMessages.cs" company="XianaCore.Common">
//     Copyright (c) XianaApp S.A.S. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace XianaCore.Common.Constants
{
    /// <summary>
    /// Struct ApplicationMessages
    /// </summary>
    public struct ApplicationMessages
    {
        /// <summary>
        /// Mensaje de validación.
        /// </summary>
        public const string MensajeRequerido = "El campo {0} es requerido.";

        /// <summary>
        /// Mensaje fecha inicial.
        /// </summary>
        public const string MensajeFechaInical = "El campo {0} no puede ser mayor al campo {1}";

        /// <summary>
        /// Mensaje fecha final.
        /// </summary>
        public const string MensajeMayorQueCero = "El campo {0} no puede ser mayor que 0(cero)";

        /// <summary>
        /// Mensaje rangos.
        /// </summary>
        public const string MensajeRangoMimino = "El campo {0} no puede ser mayor al campo {1}";

        /// <summary>
        /// The mensaje tamanio minimo
        /// </summary>
        public const string MensajeTamanioMinimo = "El campo {0} debe tener mínimo {1} caracteres";//El campo celular debe tener mínimo 10 caracteres

        /// <summary>
        /// The mensaje tamanio maximo
        /// </summary>
        public const string MensajeTamanioMaximo = "El campo {0} debe tener máximo {1} caracteres";//El campo celular debe tener máximo 10 caracteres

        /// <summary>
        /// The mensaje dia maximo.
        /// </summary>
        public const string MensajeDiaMaximo = "La fecha ingresada, no debe ser mayor o igual a hoy";

        /// <summary>
        /// The successful trasaction insert user message
        /// </summary>
        public const string SuccessfulTrasactionMessage = "La operación solicitada se a realizado con éxito.";

        /// <summary>
        /// The successful trasaction update user message
        /// </summary>
        public const string SuccessfulTrasactionUpdateUserMessage = "Su información ha sido modificada con éxito.";

        /// <summary>
        /// Error que viene por Excepcion de Sql
        /// </summary>
        public const string MensajeErrorSql = "Ocurrio un Error realizando la Trazacción en la Base de Datos, consulte con el Administrador";

        /// <summary>
        /// Error que viene por Excepcion
        /// </summary>
        public const string MensajeError = "Ocurrió un error realizando el procedimiento deseado, consulte con el administrador.";

        /// <summary>
        /// The file null or empty.
        /// </summary>
        public const string FileNullOrEmpty = "No se envió el archivo porque esta nulo o vacío";

        /// <summary>
        /// The file invalid extension.
        /// </summary>
        public const string FileInvalidExtension = "Extensión del archivo no valida.";

        /// <summary>
        /// The error system operate registers file.
        /// </summary>
        public const string ErrorSystemOperateRegistersFile = "Ocurrió un error al cargar la información. Por favor generar un clic a la mesa de servicios.";

        /// <summary>
        /// The error load file to system.
        /// </summary>
        public const string ErrorLoadFileToSystem = "Ocurrió un error al Cargar la información. {0}";

        /// <summary>
        /// The error months years differences.
        /// </summary>
        public const string ErrorMonthsYearsDifferences = "El archivo posee meses y/o años diferentes entre sí.";

        /// <summary>
        /// The file bad or corrupted.
        /// </summary>
        public const string FileBadOrCorrupted = "Archivo dañado o extensión no valida. {0}";

        /// <summary>
        /// The initial denpendecy without rows current month
        /// </summary>
        public const string InitialDenpendecyWithoutRowsCurrentMonth = "La dependencia {0}, no tiene registros asociados para el mes actual";
    }
}
