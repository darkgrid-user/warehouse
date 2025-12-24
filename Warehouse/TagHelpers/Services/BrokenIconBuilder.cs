// <copyright file="BrokenIconBuilder.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.TagHelpers.Services
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Warehouse.Extensions.UI;
    using Warehouse.Models.UI.Enumerations;
    using Warehouse.TagHelpers.Services.I;

    /// <summary>
    /// Build HTML elements that indicate broken icons.
    /// </summary>
    public class BrokenIconBuilder : IBrokenIconBuilder
    {
        /// <summary>
        /// Create a custom icon from a SPAN element that replaces a broken icon.
        /// NOTE: Custom CSS classes should be provided!!!.
        /// </summary>
        /// <param name="size">Icon size.</param>
        /// <returns>SPAN element.</returns>
        public TagBuilder CreateIcon(Size size)
        {
            TagBuilder span = new("span");
            string sizeClasses = size.GetIconClasses();

            string classes = $"{sizeClasses} wh-broken-icon";
            span.Attributes.Add("class", classes);

            span.InnerHtml.Append("!");
            return span;
        }
    }
}
