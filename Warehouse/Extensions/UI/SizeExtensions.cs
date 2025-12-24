// <copyright file="SizeExtensions.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Extensions.UI
{
    using Warehouse.Models.UI;
    using Warehouse.Models.UI.Enumerations;

    /// <summary>
    /// Custom UI size extensions.
    /// </summary>
    public static class SizeExtensions
    {
        private static readonly Dictionary<Size, string> SizeSuffix = new()
        {
            { Size.Small, "-sm" },
            /* Size.Medium - default value, do not use suffix */
            { Size.Large, "-lg" },
        };

        /// <summary>
        /// Provide size-relevant icon classes.
        /// </summary>
        /// <param name="size">Icon size.</param>
        /// <returns>Icon class names.</returns>
        public static string GetIconClasses(this Size size)
        {
            return GetClasses(Constants.Icon, size, true);
        }

        /// <summary>
        /// Provide size-relevant button classes.
        /// </summary>
        /// <param name="size">Button size.</param>
        /// <returns>Button class names.</returns>
        public static string GetButtonClasses(this Size size)
        {
            return GetClasses(Constants.Button, size);
        }

        /// <summary>
        /// Provide size-relevant element classes.
        /// </summary>
        /// <param name="name">Element name.</param>
        /// <param name="size">Element size.</param>
        /// <param name="isCustom">Is the 'wh' prefix required?.</param>
        /// <returns>Element class names.</returns>
        private static string GetClasses(string name, Size size, bool isCustom = false)
        {
            string className = isCustom
                ? Constants.Wh.CombineDash(name)
                : name;

            // add standard class and size class
            // or only standard class
            return SizeSuffix.Any(pair => pair.Key == size)
                ? $"{className} {className}{SizeSuffix[size]}"
                : className;
        }
    }
}
