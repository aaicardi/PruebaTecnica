// ***********************************************************************
// Assembly         : XianaCore.Application
// Author           : Jhoel Aicardi
// Created          : 11-13-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-13-2020
// ***********************************************************************
// <copyright file="CalculatedAnnualSalaryService.cs" company="XianaCore.Application">
//     Copyright (c) PruebaTécnica. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace XianaCore.Application.Implements
{

    using XianaCore.Application.Abstract;
    using XianaCore.Application.DTO;
    /// <summary>
    /// Class CalculatedAnnualSalaryService.
    /// Implements the <see cref="XianaCore.Application.Abstract.ICalculatedAnnualSalaryService" />
    /// </summary>
    /// <seealso cref="XianaCore.Application.Abstract.ICalculatedAnnualSalaryService" />
    /// <remarks>Jhoel Aicardi</remarks>
    public class CalculatedAnnualSalaryService: ICalculatedAnnualSalaryService
    {
        /// <summary>
        /// The hourly salary
        /// </summary>
        private const string HOURLY_SALARY = "HourlySalaryEmployee";
        /// <summary>
        /// The monthtly salary
        /// </summary>
        private const string MONTHLY_SALARY = "MonthlySalaryEmployee";
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatedAnnualSalaryService"/> class.
        /// </summary>
        /// <remarks>Jhoel Aicardi</remarks>
        public CalculatedAnnualSalaryService()
        { 
        
        }

        /// <summary>
        /// Gets the salary.
        /// </summary>
        /// <param name="employeesDto">The employees dto.</param>
        /// <returns>System.Int64.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        public long GetSalary(EmployeesDto employeesDto)
        {
            long result;
            AnnualSalary annualSalary = null;       
            switch (employeesDto.ContractTypeName)
            {
                case HOURLY_SALARY:
                    annualSalary = new HourlySalaryContract(employeesDto.HourlySalary);
                    break;

                case MONTHLY_SALARY:
                    annualSalary = new MonthlySalaryContract(employeesDto.MonthlySalary);
                    break;

                default:
                    break;
            }
            result = annualSalary.GetAnnualSalary();
            return result;          

        }
    }
}
