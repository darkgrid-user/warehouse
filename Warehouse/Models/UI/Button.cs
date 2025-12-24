// <copyright file="Button.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Models.UI
{
    using Warehouse.Extensions;
    using Warehouse.Models.UI.Enumerations;

    /// <summary>
    /// Custom UI button.
    /// </summary>
    public class Button
    {
        private readonly Icon icon;
        private readonly string title;
        private readonly string controller;
        private readonly string action;

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="icon">Icon value.</param>
        /// <param name="title">Title name.</param>
        /// <param name="controller">Controller name.</param>
        /// <param name="action">Action name.</param>
        public Button(Icon icon, string title, string controller, string action = "Index")
        {
            this.icon = icon;
            this.title = title;
            this.controller = controller;
            this.action = action;
        }

        /// <summary>
        /// Gets button icon name.
        /// </summary>
        public Icon Icon
        {
            get { return this.icon; }
        }

        /// <summary>
        /// Gets button title.
        /// </summary>
        public string Title
        {
            get { return this.title; }
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
