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
            return value != null && input.EndsWith(value)
                ? input[..input.LastIndexOf(value)]
                : input;
        }

        /// <summary>
        /// Combine two strings with a dash character.
        /// </summary>
        /// <param name="input">First string.</param>
        /// <param name="value">Second string.</param>
        /// <returns>New result string.</returns>
        public static string CombineDash(this string input, string? value)
        {
            return value != null
                ? $"{input}-{value}"
                : input;
        }

        /// <summary>
        /// Add a new line to the end of the current string.
        /// </summary>
        /// <param name="input">Current string.</param>
        /// <returns>New result string.</returns>
        public static string AddNewLine(this string input)
        {
            return $"{input}{Environment.NewLine}";
        }
    }
}
