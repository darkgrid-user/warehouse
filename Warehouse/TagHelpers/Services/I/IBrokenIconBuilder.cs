// <copyright file="IBrokenIconBuilder.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.TagHelpers.Services.I
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Warehouse.Models.UI.Enumerations;

    /// <summary>
    /// Build HTML elements that indicate broken icons.
    /// </summary>
    public interface IBrokenIconBuilder
    {
        /// <summary>
        /// Create a custom icon from a SPAN element that replaces a broken icon.
        /// NOTE: Custom CSS classes should be provided!!!.
        /// </summary>
        /// <param name="size">Icon size.</param>
        /// <returns>SPAN element.</returns>
        TagBuilder CreateIcon(Size size);
    }
}
