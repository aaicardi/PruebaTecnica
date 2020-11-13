// ***********************************************************************
// Assembly         : XianaCore.Infrastructure
// Author           : Jhoel Aicardi
// Created          : 09-29-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-04-2020
// ***********************************************************************
// <copyright file="UnitOfwork.cs" company="XianaCore.Infrastructure">
//     Copyright (c) XianaApp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace XianaCore.Infrastructure.Classes
{
    using System;
    using System.Threading.Tasks;

    using XianaCore.Infrastructure.Data;
    using XianaCore.Infrastructure.Entities;
    using XianaCore.Infrastructure.Interfaces;

    /// <summary>
    /// Class UnitOfwork.
    /// Implements the <see cref="XianaCore.Infrastructure.Interfaces.IUnitOfWork" />
    /// </summary>
    /// <seealso cref="XianaCore.Infrastructure.Interfaces.IUnitOfWork" />
    /// <remarks>Jhoel Aicardi</remarks>
    public class UnitOfwork : IUnitOfWork
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly XianaDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfwork" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <remarks>Jhoel Aicardi</remarks>
        public UnitOfwork(XianaDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// The avertisement repository
        /// </summary>
        private Repository<Employees> employeesRepository;




        /// <summary>
        /// Gets the avertisement repository.
        /// </summary>
        /// <value>The avertisement repository.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public Repository<Employees> EmployeesRepository
        {
            get
            {
                if (this.employeesRepository == null)
                    this.employeesRepository = new Repository<Employees>(_context);

                return employeesRepository;
            }
        }
        #region Entity

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        public int Save() => _context.SaveChanges();

        /// <summary>
        /// save as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <remarks>Jhoel Aicardi</remarks>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        /// <remarks>Jhoel Aicardi</remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
