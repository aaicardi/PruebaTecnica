// ***********************************************************************
// Assembly         : XianaCore.Infrastructure.Entities
// Author           : Pablo Restrepo
// Created          : 07-17-2020
//
// Last Modified By : Pablo Restrepo
// Last Modified On : 07-23-2020
// ***********************************************************************
// <copyright file="TrailRegister.cs" company="XianaCore.Infrastructure.Entities">
//     Copyright (c) XianaApp S.A.S. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace XianaCore.Infrastructure.Entities.Trail
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class TrailRegister.
    /// </summary>
    public class TrailRegister
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [Required]
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>The modified by.</value>
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>The date modified.</value>
        [Column(TypeName = "DateTime")]
        public DateTime? DateModified { get; set; }
    }
}
