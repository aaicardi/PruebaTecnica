// ***********************************************************************
// Assembly         : XianaCore.Application
// Author           : Jhoel Aicardi
// Created          : 11-13-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-13-2020
// ***********************************************************************
// <copyright file="HourlySalaryContract.cs" company="XianaCore.Application">
//     Copyright (c) PruebaTécnica. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace XianaCore.Application.Implements
{
    /// <summary>
    /// Class HourlySalaryContract.
    /// Implements the <see cref="XianaCore.Application.Implements.AnnualSalary" />
    /// </summary>
    /// <seealso cref="XianaCore.Application.Implements.AnnualSalary" />
    /// <remarks>Jhoel Aicardi</remarks>
    class HourlySalaryContract : AnnualSalary
    {
        /// <summary>
        /// The hourly salary
        /// </summary>
        private readonly long hourlySalary;

        /// <summary>
        /// Initializes a new instance of the <see cref="HourlySalaryContract"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <remarks>Jhoel Aicardi</remarks>
        public HourlySalaryContract(long value)
        {
            this.hourlySalary = 120 * value * 12;
        }

        /// <summary>
        /// Gets the annual salary.
        /// </summary>
        /// <returns>System.Int64.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        public override long GetAnnualSalary()
        {
            return this.hourlySalary;
        }
    }
}
