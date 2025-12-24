// <copyright file="IIconBuilder.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.TagHelpers.Services.I
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Warehouse.Models.UI.Enumerations;

    /// <summary>
    /// Build HTML elements for a custom icon.
    /// </summary>
    public interface IIconBuilder
    {
        /// <summary>
        /// Create a custom icon from an SVG element
        /// that contains the provided resource data.
        /// </summary>
        /// <param name="data">Provided resource data.</param>
        /// <param name="size">Icon size.</param>
        /// <returns>SVG element.</returns>
        TagBuilder CreateIcon(string data, Size size);
    }
}
