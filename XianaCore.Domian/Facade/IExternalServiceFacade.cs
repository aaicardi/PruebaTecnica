// ***********************************************************************
// Assembly         : XianaCore.Domian
// Author           : Jhoel Aicardi
// Created          : 11-12-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-12-2020
// ***********************************************************************
// <copyright file="IExternalServiceFacade.cs" company="XianaCore.Domian">
//     Copyright (c) XianaApp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace XianaCore.Domian.Facade
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    /// <summary>
    /// Interface IExternalServiceFacade
    /// </summary>
    /// <remarks>Jhoel Aicardi</remarks>
    public interface IExternalServiceFacade
    {

        /// <summary>
        /// Gets the rest service asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="method">The method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        Task<T> GetRestServiceAsync<T>(string url, string method, IDictionary<string, string> parameters, IDictionary<string, string> headers, string token);
        /// <summary>
        /// Posts the rest service asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="method">The method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        Task<T> PostRestServiceAsync<T>(string url, string controller, string method, object parameters, IDictionary<string, string> headers, string token);
        /// <summary>
        /// Posts the rest service asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <param name="uri">The URI.</param>
        /// <param name="item">The item.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        Task<HttpResponseMessage> PostRestServiceAsync<T>(HttpMethod method, string uri, T item, string token);
    }
}
