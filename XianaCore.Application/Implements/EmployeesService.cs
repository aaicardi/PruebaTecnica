// ***********************************************************************
// Assembly         : XianaCore.Application
// Author           : Jhoel Aicardi
// Created          : 11-12-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-13-2020
// ***********************************************************************
// <copyright file="EmployeesService.cs" company="XianaCore.Application">
//     Copyright (c) PruebaTécnica. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace XianaCore.Application.Implements
{
    using AutoMapper;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    using XianaCore.Application.Abstract;
    using XianaCore.Application.DTO;
    using XianaCore.Domian.IRepository;
    /// <summary>
    /// Class EmployeesService.
    /// Implements the <see cref="XianaCore.Application.Abstract.IEmployeesService" />
    /// </summary>
    /// <seealso cref="XianaCore.Application.Abstract.IEmployeesService" />
    /// <remarks>Jhoel Aicardi</remarks>
    public class EmployeesService: IEmployeesService
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IEmployeesRepository repository;
        /// <summary>
        /// The calculated annual salary service
        /// </summary>
        private readonly ICalculatedAnnualSalaryService calculatedAnnualSalaryService;
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesService" /> class.
        /// </summary>
        /// <param name="employeesRepository">The employees repository.</param>
        /// <param name="calculatedAnnualSalaryService">The calculated annual salary service.</param>
        /// <remarks>Jhoel Aicardi</remarks>
        public EmployeesService(IEmployeesRepository employeesRepository,
                                ICalculatedAnnualSalaryService calculatedAnnualSalaryService)
        {
            this.repository = employeesRepository;
            this.calculatedAnnualSalaryService = calculatedAnnualSalaryService;
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;EmployeesDto&gt;&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        public async Task<IEnumerable<EmployeesDto>> GetEmployees()
        {   
            var entityList = await this.repository.GetEmployees();
            List<EmployeesDto> resul = new List<EmployeesDto>();
            foreach (var item in entityList)
            {
                EmployeesDto employees = Mapper.Map<EmployeesDto>(item);
                employees.AnnualSalary = calculatedAnnualSalaryService.GetSalary(employees);
                resul.Add(employees);
            }                                          
            return resul;
        }

        /// <summary>
        /// Gets the employees by identifier.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;EmployeesDto&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        public async Task<EmployeesDto> GetEmployeesById(FilterDto filter)
        {
            var entityList = await this.repository.GetEmployees();
            List<EmployeesDto> resultMapper = Mapper.Map<List<EmployeesDto>>(entityList);
            EmployeesDto employees = resultMapper.Find(z => z.Id.Equals(filter.Id));
            if(employees != null)
             employees.AnnualSalary = calculatedAnnualSalaryService.GetSalary(employees);
            return employees;
        }
    }
}
