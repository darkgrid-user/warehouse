// <copyright file="IconTagHelper.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.TagHelpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Warehouse.Extensions.UI;
    using Warehouse.Models.UI.Enumerations;
    using Warehouse.TagHelpers.Services.I;

    /// <summary>
    /// Shorthand to generate a custom icon.
    /// </summary>
    [HtmlTargetElement("wh-icon")]
    public class IconTagHelper : TagHelper
    {
        private readonly IIconProvider iconProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="IconTagHelper"/> class.
        /// </summary>
        /// <param name="iconProvider">Icon provider service.</param>
        public IconTagHelper(IIconProvider iconProvider)
        {
            this.iconProvider = iconProvider;
        }

        /// <summary>
        /// Gets or sets the icon value.
        /// Used to load the corresponding resource.
        /// </summary>
        [HtmlAttributeName("name")]
        public Icon Icon { get; set; } // default: Icon.Undefined

        /// <summary>
        /// Gets or sets the icon size.
        /// </summary>
        [HtmlAttributeName("size")]
        public Size Size { get; set; } // default: Size.Medium

        /// <summary>
        /// Build and set HTML content.
        /// </summary>
        /// <param name="context">Local context object.</param>
        /// <param name="output">HTML output.</param>
        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            TagBuilder icon = this.iconProvider.GetIconOrBroken(
                this.Icon,
                this.Size);
            output.Set(icon);
        }
    }
}
