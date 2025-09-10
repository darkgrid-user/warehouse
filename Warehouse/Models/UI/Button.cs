// <copyright file="Button.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Models.UI
{
    using Warehouse.Extensions;

    /// <summary>
    /// Custom UI button.
    /// </summary>
    public class Button
    {
        private readonly string title;
        private readonly string? icon;
        private readonly string controller;
        private readonly string action;

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="title">Title name.</param>
        /// <param name="icon">Icon name.</param>
        /// <param name="controller">Controller name.</param>
        /// <param name="action">Action name.</param>
        public Button(string title, string? icon, string controller, string action = "Index")
        {
            this.title = title;
            this.icon = icon;
            this.controller = controller;
            this.action = action;
        }

        /// <summary>
        /// Gets button title.
        /// </summary>
        public string Title
        {
            get { return this.title; }
        }

        /// <summary>
        /// Gets button icon name.
        /// </summary>
        public string? Icon
        {
            get { return Constants.Icon.CombineDash(this.icon); }
        }

        /// <summary>
        /// Gets route controller name without 'Controller' suffix.
        /// </summary>
        public string Controller
        {
            get { return this.controller.TrimEnd("Controller"); }
        }

        /// <summary>
        /// Gets route action name.
        /// </summary>
        public string Action
        {
            get { return this.action; }
        }
    }
}
