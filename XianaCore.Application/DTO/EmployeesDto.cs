// ***********************************************************************
// Assembly         : XianaCore.Application
// Author           : Jhoel Aicardi
// Created          : 11-12-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-13-2020
// ***********************************************************************
// <copyright file="EmployeesDto.cs" company="XianaCore.Application">
//     Copyright (c) Ingeneo. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace XianaCore.Application.DTO
{
    /// <summary>
    /// Class EmployeesDto.
    /// </summary>
    /// <remarks>Jhoel Aicardi</remarks>
    public class EmployeesDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the name of the contract type.
        /// </summary>
        /// <value>The name of the contract type.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public string ContractTypeName { get; set; }
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>The role identifier.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public int RoleId { get; set; }
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>The name of the role.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public string RoleName { get; set; }
        /// <summary>
        /// Gets or sets the role description.
        /// </summary>
        /// <value>The role description.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public string RoleDescription { get; set; }
        /// <summary>
        /// Gets or sets the hourly salary.
        /// </summary>
        /// <value>The hourly salary.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public long HourlySalary { get; set; }
        /// <summary>
        /// Gets or sets the monthly salary.
        /// </summary>
        /// <value>The monthly salary.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public long MonthlySalary { get; set; }
        /// <summary>
        /// Gets or sets the annual salary.
        /// </summary>
        /// <value>The annual salary.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public long? AnnualSalary { get; set; }
    }
}
