// <copyright file="IconProvider.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.TagHelpers.Services
{
    using System.Resources;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Warehouse.Models.UI.Enumerations;
    using Warehouse.Properties;
    using Warehouse.TagHelpers.Services.I;

    /// <summary>
    /// Get the HTML for custom icons.
    /// </summary>
    public class IconProvider : IIconProvider
    {
        private readonly IIconBuilder iconBuilder;
        private readonly IBrokenIconBuilder brokenIconBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="IconProvider"/> class.
        /// </summary>
        /// <param name="iconBuilder">Icon builder service.</param>
        /// <param name="brokenIconBuilder">Broken icon builder service.</param>
        public IconProvider(
            IIconBuilder iconBuilder,
            IBrokenIconBuilder brokenIconBuilder)
        {
            this.iconBuilder = iconBuilder;
            this.brokenIconBuilder = brokenIconBuilder;
        }

        /// <summary>
        /// Create a custom icon from an available resource,
        /// or return nothing if none is available.
        /// </summary>
        /// <param name="icon">Icon value.</param>
        /// <param name="size">Icon size.</param>
        /// <returns>HTML content or NULL.</returns>
        public TagBuilder? GetIcon(Icon icon, Size size)
        {
            if (icon != Icon.Undefined)
            {
                ResourceManager manager = IconResources.ResourceManager;
                string? content = manager.GetString(icon.ToString());
                if (content != null)
                {
                    return this.iconBuilder.CreateIcon(content, size);
                }
            }

            return null;
        }

        /// <summary>
        /// Create a custom icon from an available resource,
        /// or return a broken icon if none is available.
        /// </summary>
        /// <param name="icon">Icon value.</param>
        /// <param name="size">Icon size.</param>
        /// <returns>HTML content.</returns>
        public TagBuilder GetIconOrBroken(Icon icon, Size size)
        {
            return this.GetIcon(icon, size)
                ?? this.brokenIconBuilder.CreateIcon(size);
        }
    }
}
