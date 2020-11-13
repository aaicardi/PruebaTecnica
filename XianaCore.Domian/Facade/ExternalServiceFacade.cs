// ***********************************************************************
// Assembly         : XianaCore.Domian
// Author           : Jhoel Aicardi
// Created          : 11-12-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-12-2020
// ***********************************************************************
// <copyright file="ExternalServiceFacade.cs" company="XianaCore.Domian">
//     Copyright (c) XianaApp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

using XianaCore.Common.Constants;
using XianaCore.Infrastructure.Entities;

namespace XianaCore.Domian.Facade
{
    /// <summary>
    /// Class ExternalServiceFacade.
    /// Implements the <see cref="XianaCore.Domian.Facade.IExternalServiceFacade" />
    /// </summary>
    /// <seealso cref="XianaCore.Domian.Facade.IExternalServiceFacade" />
    /// <remarks>Jhoel Aicardi</remarks>
    public class ExternalServiceFacade: IExternalServiceFacade
    {
        /// <summary>
        /// post rest service as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="method">The method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks>Jhoel Aicardi</remarks>
        public async Task<T> PostRestServiceAsync<T>(string url, string controller, string method, object parameters, IDictionary<string, string> headers, string token)
        {
            var baseUrl = $"{url}/{controller}/{method}";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(GeneralConstant.ApplicationJson));
            if (headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            if (!string.IsNullOrWhiteSpace(token) && !token.Equals(GeneralConstant.AddSecurityDefinitionBearer))
                client.DefaultRequestHeaders.Add(GeneralConstant.AddSecurityDefinitionName, token);

            var jsonObject = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, GeneralConstant.ApplicationJson);
            var res = await client.PostAsync(baseUrl, jsonObject);
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }

            var responseError = new ServiceResponse<string>()
            {
                HttpStatusCode = res.StatusCode,
                Status = false,
                Message = res.ReasonPhrase,
                Data = await res.Content.ReadAsStringAsync()
            };

            throw new ArgumentNullException(JsonConvert.SerializeObject(responseError));
        }

        /// <summary>
        /// post rest service as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <param name="uri">The URI.</param>
        /// <param name="item">The item.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        public async Task<HttpResponseMessage> PostRestServiceAsync<T>(HttpMethod method, string uri, T item, string token)
        {
            return await DoPostPutAsync(method, uri, item, token);
        }


        /// <summary>
        /// get rest service as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="method">The method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks>Jhoel Aicardi</remarks>
        public async Task<T> GetRestServiceAsync<T>(string url, string method, IDictionary<string, string> parameters, IDictionary<string, string> headers, string token)
        {
            var baseUrl = $"{url}/{method}";
            if (parameters.Count > 0)
                baseUrl = $"{baseUrl}?{string.Join("&", parameters.Select(p => p.Key + "=" + p.Value).ToArray())}";

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(GeneralConstant.ApplicationJson));
            if (headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            if (!string.IsNullOrWhiteSpace(token) && !token.Equals(GeneralConstant.AddSecurityDefinitionBearer))
                client.DefaultRequestHeaders.Add(GeneralConstant.AddSecurityDefinitionName, token);

            HttpResponseMessage res = await client.GetAsync(baseUrl);

            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }

            var responseError = new ServiceResponse<string>()
            {
                HttpStatusCode = res.StatusCode,
                Status = false,
                Message = res.ReasonPhrase,
                Data = await res.Content.ReadAsStringAsync()
            };
            throw new ArgumentNullException(JsonConvert.SerializeObject(responseError));
        }






        /// <summary>
        /// do post put as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <param name="uri">The URI.</param>
        /// <param name="item">The item.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        /// <exception cref="ArgumentException">Value must be either post or put. - method</exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <remarks>Jhoel Aicardi</remarks>
        private async Task<HttpResponseMessage> DoPostPutAsync<T>(HttpMethod method, string uri, T item, string token)

        {
            var client = new HttpClient();

            if (method != HttpMethod.Post && method != HttpMethod.Put)
            {
                throw new ArgumentException("Value must be either post or put.", nameof(method));
            }


            var requestMessage = new HttpRequestMessage(method, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            client.DefaultRequestHeaders.Remove("Authorization");
            if (!string.IsNullOrWhiteSpace(token) && !token.Equals(GeneralConstant.AddSecurityDefinitionBearer))
                client.DefaultRequestHeaders.Add(GeneralConstant.AddSecurityDefinitionName, token);

            var response = await client.SendAsync(requestMessage);


            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException();
            }

            return response;
        }


    }
}
