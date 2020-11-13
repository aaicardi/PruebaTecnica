// ***********************************************************************
// Assembly         : XianaCore.Backend
// Author           : Jhoel Aicardi
// Created          : 09-29-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 09-29-2020
// ***********************************************************************
// <copyright file="IoC.cs" company="XianaCore.Backend">
//     Copyright (c) XianaApp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace XianaCore.Backend.Middleware
{
    using Microsoft.Extensions.DependencyInjection;
    using XianaCore.Application.Abstract;
    using XianaCore.Application.Implements;
    using XianaCore.Domian.Facade;
    using XianaCore.Domian.IRepository;
    using XianaCore.Domian.Repository;
    using XianaCore.Infrastructure.Classes;
    using XianaCore.Infrastructure.Interfaces;

    /// <summary>
    /// Class IoC.
    /// </summary>
    /// <remarks>Jhoel Aicardi</remarks>
    public static class IoC
    {
        /// <summary>
        /// Adds the dependency.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Infrastructure
            #region Infrastructure
            services.AddTransient<IUnitOfWork, UnitOfwork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            //Services
            #region Services
            services.AddTransient<IEmployeesService, EmployeesService>();          
            #endregion


            //Repository
            #region Repository
            services.AddTransient<IEmployeesRepository, EmployeesRepository>();
            services.AddTransient<IExternalServiceFacade, ExternalServiceFacade>();            
            #endregion

            return services;
        }
    }
}
