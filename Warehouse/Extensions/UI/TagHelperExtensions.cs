// <copyright file="TagHelperExtensions.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Extensions.UI
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    /// <summary>
    /// Custom TagHelper extensions.
    /// </summary>
    public static class TagHelperExtensions
    {
        /// <summary>
        /// Drop the root tag element and replace it with the provided content.
        /// </summary>
        /// <param name="output">HTML output.</param>
        /// <param name="builder">Content builder.</param>
        public static void Set(this TagHelperOutput output, TagBuilder builder)
        {
            output.TagName = null;
            output.Content.SetHtmlContent(builder);
        }
    }
}
