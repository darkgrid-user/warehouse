// <copyright file="IIconProvider.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.TagHelpers.Services.I
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Warehouse.Models.UI.Enumerations;

    /// <summary>
    /// Get the HTML for custom icons.
    /// </summary>
    public interface IIconProvider
    {
        /// <summary>
        /// Create a custom icon from an available resource,
        /// or return nothing if none is available.
        /// </summary>
        /// <param name="icon">Icon value.</param>
        /// <param name="size">Icon size.</param>
        /// <returns>HTML content or NULL.</returns>
        public TagBuilder? GetIcon(Icon icon, Size size);

        /// <summary>
        /// Create a custom icon from an available resource,
        /// or return a broken icon if none is available.
        /// </summary>
        /// <param name="icon">Icon value.</param>
        /// <param name="size">Icon size.</param>
        /// <returns>HTML content.</returns>
        public TagBuilder GetIconOrBroken(Icon icon, Size size);
    }
}
