// <copyright file="LogTimeOptions.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Middleware.Model
{
    /// <summary>
    /// LogTime middleware configuration options.
    /// </summary>
    public class LogTimeOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether url path is logged.
        /// </summary>
        public bool HasPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether controller name is logged.
        /// </summary>
        public bool HasController { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether action name is logged.
        /// </summary>
        public bool HasAction { get; set; }

    }
}
