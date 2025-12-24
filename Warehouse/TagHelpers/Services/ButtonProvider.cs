// <copyright file="ButtonProvider.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.TagHelpers.Services
{
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Warehouse.Extensions.UI;
    using Warehouse.Models.UI.Enumerations;
    using Warehouse.TagHelpers.Services.I;

    /// <summary>
    /// Get the HTML for a custom button.
    /// </summary>
    public class ButtonProvider : IButtonProvider
    {
        private readonly IIconProvider iconProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonProvider"/> class.
        /// </summary>
        /// <param name="iconProvider">Icon provider service.</param>
        public ButtonProvider(IIconProvider iconProvider)
        {
            this.iconProvider = iconProvider;
        }

        /// <summary>
        /// Create a custom button and fill it with the necessary content and attributes.
        /// </summary>
        /// <param name="href">Button link.</param>
        /// <param name="title">Button title.</param>
        /// <param name="icon">Button icon.</param>
        /// <param name="size">Button size.</param>
        /// <returns>HTML content.</returns>
        public TagBuilder GetButton(string? href, string? title, Icon icon, Size size)
        {
            TagBuilder button = new("a");
            AttributeDictionary attrs = button.Attributes;

            attrs.Add("href", href);
            attrs.Add("type", "button");
            attrs.Add("class", size.GetButtonClasses());

            if (icon == Icon.Undefined && title == null)
            {
                // no icon and no title - set broken button
                title = "-! broken !-";
                button.AddCssClass("btn-outline-danger");
            }
            else
            {
                // set normal button
                button.AddCssClass("btn-outline-primary");
            }

            IHtmlContentBuilder html = button.InnerHtml;
            this.AppendIcon(html, icon, size);
            this.AppendTitle(html, title);

            return button;
        }

        private void AppendIcon(IHtmlContentBuilder html, Icon icon, Size size)
        {
            TagBuilder? builder = this.iconProvider.GetIcon(icon, size);
            if (builder != null)
            {
                html.AppendHtml(builder);
            }
        }

        private void AppendTitle(IHtmlContentBuilder html, string? title)
        {
            if (title != null)
            {
                TagBuilder builder = new("span");
                builder.AddCssClass("align-middle");
                builder.InnerHtml.Append(title);

                html.AppendHtml(builder);
            }
        }
    }
}
