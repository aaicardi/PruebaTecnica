// ***********************************************************************
// Assembly         : XianaCore.Domian
// Author           : Jhoel Aicardi
// Created          : 11-12-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-13-2020
// ***********************************************************************
// <copyright file="IEmployeesRepository.cs" company="XianaCore.Domian">
//     Copyright (c) Ingeneo. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace XianaCore.Domian.IRepository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using XianaCore.Infrastructure.Entities;

    /// <summary>
    /// Interface IEmployeesRepository
    /// </summary>
    /// <remarks>Jhoel Aicardi</remarks>
    public interface IEmployeesRepository
    {
        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;Employees&gt;&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        Task<IEnumerable<Employees>> GetEmployees();
    }
}
