// <copyright file="LogTimeMessageProvider.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Middleware
{
    using Warehouse.Extensions;
    using Warehouse.Middleware.I;
    using Warehouse.Middleware.Model;

    /// <summary>
    /// LogTime middleware message provider.
    /// </summary>
    public class LogTimeMessageProvider : ILogTimeMessageProvider
    {
        /// <summary>
        /// Check the options and create a final log message.
        /// </summary>
        /// <param name="options">LogTime middleware configuration options.</param>
        /// <param name="executionTime">Middleware components execution time.</param>
        /// <param name="request">Current request.</param>
        /// <returns>Log message.</returns>
        public string GetMessage(LogTimeOptions options, TimeSpan executionTime, HttpRequest request)
        {
            string defaultValue = "-";
            string path = GetLine(
                options.HasPath,
                request.Path,
                "Path");
            string controller = GetLine(
                options.HasController,
                request.TryGetRouteValue("controller", defaultValue),
                "Controller");
            string action = GetLine(
                options.HasAction,
                request.TryGetRouteValue("action", defaultValue),
                "Action");
            string total = GetLine(
                true,
                executionTime.TotalSeconds.ToString(),
                "Total seconds");

            string separator = StringExtensions.CreateSeparator();
            return $"{separator}{path}{controller}{action}{total}{separator}";
        }

        private static string GetLine(bool hasValue, string value, string title)
        {
            int titleLength = 13; // reserved title length
            int remainLength = titleLength - title.Length;

            string remainSpaces = new(' ', remainLength);
            return hasValue
                ? $"{title}:{remainSpaces} | {value}".AddNewLine()
                : StringExtensions.CreateEmpty();
        }
    }
}
