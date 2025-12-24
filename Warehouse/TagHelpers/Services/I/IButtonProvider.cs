// <copyright file="IButtonProvider.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.TagHelpers.Services.I
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Warehouse.Models.UI.Enumerations;

    /// <summary>
    /// Get the HTML for a custom button.
    /// </summary>
    public interface IButtonProvider
    {
        /// <summary>
        /// Create a custom button and fill it with the necessary content and attributes.
        /// </summary>
        /// <param name="href">Button link.</param>
        /// <param name="title">Button title.</param>
        /// <param name="icon">Button icon.</param>
        /// <param name="size">Button size.</param>
        /// <returns>HTML content.</returns>
        TagBuilder GetButton(string? href, string? title, Icon icon, Size size);
    }
}
