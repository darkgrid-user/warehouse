// <copyright file="SizeExtensions.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Extensions.UI
{
    using Warehouse.Models.UI;
    using Warehouse.Models.UI.Enumerations;

    /// <summary>
    /// Provide size-relevant ui element class names.
    /// </summary>
    public static class SizeExtensions
    {
        private static readonly Dictionary<Size, string> SizeSuffix = new()
        {
            { Size.Small, "-sm" },
            /* Size.Medium - do not use suffix */
            { Size.Large, "-lg" },
        };

        /// <summary>
        /// Provide size-relevant icon name.
        /// </summary>
        /// <param name="size">Element size.</param>
        /// <returns>Icon class name.</returns>
        public static string GetIconClass(this Size size)
        {
            string className = Constants.Wh.CombineDash(Constants.Icon);

            return SizeSuffix.Any(pair => pair.Key == size)
                ? className + SizeSuffix[size]
                : className;
        }
    }
}
