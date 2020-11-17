// ***********************************************************************
// Assembly         : XianaCore.Common
// Author           : Jhoel Aicardi
// Created          : 10-28-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-08-2020
// ***********************************************************************
// <copyright file="GeneralConstant.cs" company="XianaCore.Common">
//     Copyright (c) XianaApp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace XianaCore.Common.Constants
{
    /// <summary>
    /// Struct GeneralConstant
    /// </summary>
    /// <remarks>Jhoel Aicardi</remarks>
    public struct GeneralConstant
    {
        /// <summary>
        /// The blank space
        /// </summary>
        public const string BlankSpace = " ";
        /// <summary>
        /// The eat
        /// </summary>
        public const string Eat = ",";
        /// <summary>
        /// At
        /// </summary>
        public const string At = "@";
        /// <summary>
        /// The key value
        /// </summary>
        public const string KeyValue = "-1";

        /// <summary>
        /// Foo API v1
        /// </summary>
        public const string EndpointDescription = "Core API";

        /// <summary>
        /// The endpoint URL
        /// </summary>
        public const string EndpointUrl = "/swagger/v1/swagger.json";

        /// <summary>
        /// Jorge Serrano
        /// </summary>
        public const string ContactName = "";

        /// <summary>
        /// The contact URL
        /// </summary>
        public const string ContactUrl = "";

        /// <summary>
        /// v1
        /// </summary>
        public const string DocNameV1 = "v1";

        /// <summary>
        /// Foo API
        /// </summary>
        public const string DocInfoTitle = "Core API";

        /// <summary>
        /// v1
        /// </summary>
        public const string DocInfoVersion = "v1";

        /// <summary>
        /// Foo Api - Sample Web API in ASP.NET Core 2
        /// </summary>
        public const string DocInfoDescription = "Core Api - Documentacion Servicios Rest";

        /// <summary>
        /// The authorize API key policy
        /// </summary>
        public const string AuthorizeApiKeyPolicy = "ApiKeyPolicy";

        /// <summary>
        /// The inter network
        /// </summary>
        public const string InterNetwork = "InterNetwork";

        /// <summary>
        /// The application json
        /// </summary>
        public const string ApplicationJson = "application/json";

        /// <summary>
        /// The default ip
        /// </summary>
        public const string DefaultIp = "127.0.0.1";

        /// <summary>
        /// The remote ip address
        /// </summary>
        public const string RemoteIpAddress = "::1";

        /// <summary>
        /// The enable cors name
        /// </summary>
        public const string EnableCorsName = "NotificationsPolicy";

        /// <summary>
        /// The domain URL
        /// </summary>
        public const string DomainUrl = "";

        /// <summary>
        /// The secret identifier
        /// </summary>
        public const string SecretId = "AZDSettings:secretId";

        /// <summary>
        /// The add security definition in
        /// </summary>
        public const string AddSecurityDefinitionIn = "header";

        /// <summary>
        /// The add security definition type
        /// </summary>
        public const string AddSecurityDefinitionType = "apiKey";

        /// <summary>
        /// The add security definition bearer
        /// </summary>
        public const string AddSecurityDefinitionBearer = "Bearer";

        /// <summary>
        /// The add security definition name
        /// </summary>
        public const string AddSecurityDefinitionName = "Authorization";

        /// <summary>
        /// The add security definition description
        /// </summary>
        public const string AddSecurityDefinitionDescription = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"";

    }
}
