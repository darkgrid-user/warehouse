// <copyright file="RequestExtensions.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Extensions
{
    /// <summary>
    /// Custom http request extensions.
    /// </summary>
    public static class RequestExtensions
    {
        /// <summary>
        /// Try to get the route value as a string for this request,
        /// otherwise return the default value.
        /// </summary>
        /// <param name="request">Current request.</param>
        /// <param name="key">Route value key.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Result string.</returns>
        public static string TryGetRouteValue(
            this HttpRequest request,
            string key,
            string defaultValue = "")
        {
            RouteValueDictionary routeValues = request.RouteValues;
            return routeValues.Count > 0
             && routeValues.ContainsKey(key)
                ? routeValues[key]?.ToString() ?? defaultValue
                : defaultValue;
        }
    }
}
