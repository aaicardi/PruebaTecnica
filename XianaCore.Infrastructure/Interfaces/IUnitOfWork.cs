// ***********************************************************************
// Assembly         : XianaCore.Infrastructure
// Author           : Jhoel Aicardi
// Created          : 09-29-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-04-2020
// ***********************************************************************
// <copyright file="IUnitOfWork.cs" company="XianaCore.Infrastructure">
//     Copyright (c) XianaApp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace XianaCore.Infrastructure.Interfaces
{
    using System.Threading.Tasks;
    using XianaCore.Infrastructure.Classes;
    using XianaCore.Infrastructure.Entities;

    /// <summary>
    /// Interface IUnitOfWork
    /// </summary>
    /// <remarks>Jhoel Aicardi</remarks>
    public interface IUnitOfWork
    {

        Repository<Employees> EmployeesRepository { get; }
        /// <summary>
        /// Disposes this instance.
        /// </summary>
        /// <remarks>Jhoel Aicardi</remarks>
#pragma warning disable S2953 // Methods named "Dispose" should implement "IDisposable.Dispose"
        void Dispose();
#pragma warning restore S2953 // Methods named "Dispose" should implement "IDisposable.Dispose"

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        int Save();

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        Task<int> SaveAsync();
    }
}
