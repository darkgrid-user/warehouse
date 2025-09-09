// <copyright file="StringExtensions.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Extensions
{
    /// <summary>
    /// Custom string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Remove the trailing value from the current string.
        /// </summary>
        /// <param name="input">Current string.</param>
        /// <param name="value">Trailing value.</param>
        /// <returns>New result string.</returns>
        public static string TrimEnd(this string input, string? value)
        {
            if (value != null && input.EndsWith(value))
            {
                return input[..input.LastIndexOf(value)];
            }

            return input;
        }
    }
}
