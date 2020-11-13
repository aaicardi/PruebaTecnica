// ***********************************************************************
// Assembly         : XianaCore.Application
// Author           : Jhoel Aicardi
// Created          : 11-12-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-13-2020
// ***********************************************************************
// <copyright file="IEmployeesService.cs" company="XianaCore.Application">
//     Copyright (c) Ingeneo. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace XianaCore.Application.Abstract
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using XianaCore.Application.DTO;
    /// <summary>
    /// Interface IEmployeesService
    /// </summary>
    /// <remarks>Jhoel Aicardi</remarks>
    public interface IEmployeesService
    {
        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;EmployeesDto&gt;&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        Task<IEnumerable<EmployeesDto>> GetEmployees();

        /// <summary>
        /// Gets the employees by identifier.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;EmployeesDto&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        Task<EmployeesDto> GetEmployeesById(FilterDto filter);
    }
}
