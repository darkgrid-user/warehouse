// <copyright file="ButtonTagHelper.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.TagHelpers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Warehouse.Extensions.UI;
    using Warehouse.Models.UI.Enumerations;
    using Warehouse.TagHelpers.Services.I;

    /// <summary>
    /// Shorthand to generate a custom button.
    /// </summary>
    [HtmlTargetElement("wh-button")]
    public class ButtonTagHelper : TagHelper
    {
        private readonly IButtonProvider buttonProvider;
        private readonly IUrlHelperFactory urlHelperFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonTagHelper"/> class.
        /// </summary>
        /// <param name="buttonProvider">Button provider service.</param>
        /// <param name="urlHelperFactory">Url provider service.</param>
        public ButtonTagHelper(
            IButtonProvider buttonProvider,
            IUrlHelperFactory urlHelperFactory)
        {
            this.buttonProvider = buttonProvider;
            this.urlHelperFactory = urlHelperFactory;
        }

        /// <summary>
        /// Gets or sets the value of the button icon.
        /// Used to load the corresponding resource.
        /// </summary>
        [HtmlAttributeName("icon")]
        public Icon Icon { get; set; } // default: Icon.Undefined

        /// <summary>
        /// Gets or sets the button size.
        /// </summary>
        [HtmlAttributeName("size")]
        public Size Size { get; set; } // default: Size.Medium

        /// <summary>
        /// Gets or sets the button title.
        /// </summary>
        [HtmlAttributeName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the button controller.
        /// </summary>
        [HtmlAttributeName("controller")]
        public string? Controller { get; set; }

        /// <summary>
        /// Gets or sets the button action.
        /// </summary>
        [HtmlAttributeName("action")]
        public string? Action { get; set; }

        /// <summary>
        /// Gets or sets the view context object.
        /// </summary>
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext Context { get; set; } = new();

        /// <summary>
        /// Build and set HTML content.
        /// </summary>
        /// <param name="context">Local context object.</param>
        /// <param name="output">HTML output.</param>
        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            IUrlHelper urlHelper = this.urlHelperFactory.GetUrlHelper(this.Context);
            string? href = urlHelper.Action(this.Action, this.Controller);

            TagBuilder button = this.buttonProvider.GetButton(
                href,
                this.Title,
                this.Icon,
                this.Size);
            output.Set(button);
        }
    }
}
