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
        /// Create an empty string.
        /// </summary>
        /// <returns>New result string.</returns>
        public static string CreateEmpty()
        {
            return string.Empty;
        }

        /// <summary>
        /// Create a new line.
        /// </summary>
        /// <returns>New result string.</returns>
        public static string CreateNewLine()
        {
            return $"{Environment.NewLine}";
        }

        /// <summary>
        /// Create a new separator.
        /// </summary>
        /// <param name="isTrailingNewLine">A new line is added to the end of the result string.</param>
        /// <returns>New result string.</returns>
        public static string CreateSeparator(bool isTrailingNewLine = true)
        {
            string separator = "###############################################################################";
            string newLine = isTrailingNewLine
                ? CreateNewLine()
                : CreateEmpty();
            return $"{separator}{newLine}";
        }

        /// <summary>
        /// Add a new line to the end of the current string.
        /// </summary>
        /// <param name="input">Current string.</param>
        /// <returns>New result string.</returns>
        public static string AddNewLine(this string input)
        {
            string newLine = CreateNewLine();
            return $"{input}{newLine}";
        }

        /// <summary>
        /// Add a separator to the end of the current string.
        /// </summary>
        /// <param name="input">Current string.</param>
        /// <param name="isTrailingNewLine">A new line is added to the end of the result string.</param>
        /// <returns>New result string.</returns>
        public static string AddSeparator(this string input, bool isTrailingNewLine = true)
        {
            string separator = CreateSeparator(isTrailingNewLine);
            return $"{input}{separator}";
        }
    }
}
