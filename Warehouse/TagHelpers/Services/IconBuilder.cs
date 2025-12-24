// <copyright file="IconBuilder.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.TagHelpers.Services
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Warehouse.Extensions.UI;
    using Warehouse.Models.UI.Enumerations;
    using Warehouse.TagHelpers.Services.I;

    /// <summary>
    /// Build HTML elements for a custom icon.
    /// </summary>
    public class IconBuilder : IIconBuilder
    {
        /// <summary>
        /// Create a custom icon from an SVG element
        /// that contains the provided resource data.
        /// </summary>
        /// <param name="data">Provided resource data.</param>
        /// <param name="size">Icon size.</param>
        /// <returns>SVG element.</returns>
        public TagBuilder CreateIcon(string data, Size size)
        {
            TagBuilder svg = new("svg");
            AttributeDictionary attrs = svg.Attributes;

            attrs.Add("xmlns", "http://www.w3.org/2000/svg");
            attrs.Add("width", "24");
            attrs.Add("height", "24");
            attrs.Add("viewBox", "0 0 24 24");
            attrs.Add("fill", "none");
            attrs.Add("stroke", "currentColor");
            attrs.Add("stroke-width", "2");
            attrs.Add("stroke-linecap", "round");
            attrs.Add("stroke-linejoin", "round");
            attrs.Add("class", size.GetIconClasses());

            svg.InnerHtml.AppendHtml(data);
            return svg;
        }
    }
}
