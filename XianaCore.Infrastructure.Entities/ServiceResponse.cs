// ***********************************************************************
// Assembly         : XianaCore.Infrastructure.Entities
// Author           : Jhoel Aicardi
// Created          : 11-12-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-12-2020
// ***********************************************************************
// <copyright file="ServiceResponse.cs" company="XianaCore.Infrastructure.Entities">
//     Copyright (c) PruebaTécnica. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace XianaCore.Infrastructure.Entities
{
    using System.Net;
    /// <summary>
    /// Class ServiceResponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>Jhoel Aicardi</remarks>
    public class ServiceResponse<T>
    {

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ServiceResponse{T}"/> is status.
        /// </summary>
        /// <value><c>true</c> if status; otherwise, <c>false</c>.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public bool Status { get; set; }


        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        /// <value>The HTTP status code.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public HttpStatusCode HttpStatusCode { get; set; }


        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public string Message { get; set; }


        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public T Data { get; set; }
    }
}
