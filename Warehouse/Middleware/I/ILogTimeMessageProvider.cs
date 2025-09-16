// <copyright file="ILogTimeMessageProvider.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Middleware.I
{
    using Warehouse.Middleware.Model;

    /// <summary>
    /// LogTime middleware message provider.
    /// </summary>
    public interface ILogTimeMessageProvider
    {
        /// <summary>
        /// Check the options and create a final log message.
        /// </summary>
        /// <param name="options">LogTime middleware configuration options.</param>
        /// <param name="executionTime">Middleware components execution time.</param>
        /// <param name="request">Current request.</param>
        /// <returns>Log message.</returns>
        string GetMessage(LogTimeOptions options, TimeSpan executionTime, HttpRequest request);
    }
}
