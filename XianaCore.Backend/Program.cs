// ***********************************************************************
// Assembly         : XianaCore.Backend
// Author           : Jhoel Aicardi
// Created          : 09-28-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-06-2020
// ***********************************************************************
// <copyright file="Program.cs" company="XianaCore.Backend">
//     Copyright (c) XianaApp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace XianaCore.Backend
{

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    using XianaCore.Common.Mapper;
    /// <summary>
    /// Class Program.
    /// </summary>
    /// <remarks>Jhoel Aicardi</remarks>
    public static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <remarks>Jhoel Aicardi</remarks>
        public static void Main(string[] args)
        {
            // Inicialize Automapper
            SettingAutomapper.CreateMaps();
            CreateHostBuilder(args).Build().Run();

        }

        /// <summary>
        /// Creates the host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>IHostBuilder.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
