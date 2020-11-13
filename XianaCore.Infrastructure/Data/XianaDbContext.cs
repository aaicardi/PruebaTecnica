// ***********************************************************************
// Assembly         : XianaCore.Infrastructure
// Author           : Jhoel Aicardi
// Created          : 09-29-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-06-2020
// ***********************************************************************
// <copyright file="XianaDbContext.cs" company="XianaCore.Infrastructure">
//     Copyright (c) XianaApp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;

using XianaCore.Infrastructure.Entities;

namespace XianaCore.Infrastructure.Data
{
    /// <summary>
    /// Class XianaDbContext.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// <remarks>Jhoel Aicardi</remarks>
    public partial class XianaDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XianaDbContext" /> class.
        /// </summary>
        /// <remarks>Jhoel Aicardi</remarks>
        public XianaDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XianaDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <remarks>Jhoel Aicardi</remarks>
        public XianaDbContext(DbContextOptions<XianaDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// The is migration
        /// </summary>
        public static bool IsMigration;

        /// <summary>
        /// Gets or sets the advertisement.
        /// </summary>
        /// <value>The advertisement.</value>
        /// <remarks>Jhoel Aicardi</remarks>
        public virtual DbSet<Employees> Employees { get; set; }

        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        /// <remarks>Jhoel Aicardi</remarks>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=sql5080.site4now.net;Database=DB_A18848_Xiana;Trusted_Connection=False;User=DB_A18848_Xiana_admin;password=Xiana2020;");
            }
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>().HasKey(a => a.Id);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
