// ***********************************************************************
// Assembly         : XianaCore.Common
// Author           : Jhoel Aicardi
// Created          : 11-06-2020
//
// Last Modified By : Jhoel Aicardi
// Last Modified On : 11-06-2020
// ***********************************************************************
// <copyright file="SettingAutomapper.cs" company="XianaCore.Common">
//     Copyright (c) XianaApp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace XianaCore.Common.Mapper
{
    /// <summary>
    /// Class SettingAutomapper.
    /// </summary>
    /// <remarks>Jhoel Aicardi</remarks>
    public static class SettingAutomapper
    {
        /// <summary>
        /// Creates the maps.
        /// </summary>
        /// <remarks>Jhoel Aicardi</remarks>
        public static void CreateMaps()
        {
            AutoMapper.Mapper.Reset();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.ValidateInlineMaps = false;
            });
        }
    }
}
