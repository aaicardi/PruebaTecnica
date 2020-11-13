// ***********************************************************************
// Assembly         : XianaCore.Backend
// Author           : Jhoel Aicardi
// Created          : 11-12-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-13-2020
// ***********************************************************************
// <copyright file="EmployeesController.cs" company="XianaCore.Backend">
//     Copyright (c) Ingeneo. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace XianaCore.Backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using XianaCore.Application.Abstract;
    using XianaCore.Application.DTO;

    /// <summary>
    /// Class EmployeesController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// <remarks>Jhoel Aicardi</remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly IEmployeesService service;
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <remarks>Jhoel Aicardi</remarks>
        public EmployeesController(IEmployeesService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;EmployeesDto&gt;&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        [HttpGet]    
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<EmployeesDto>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<EmployeesDto>> GetAll()
        {
            return await this.service.GetEmployees();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;EmployeesDto&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        [HttpPost]   
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EmployeesDto), (int)HttpStatusCode.OK)]
        public async Task<EmployeesDto> GetById(FilterDto filter)
        {
            return await this.service.GetEmployeesById(filter);
        }

    }
}
