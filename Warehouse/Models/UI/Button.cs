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
        private readonly string controller;
        private readonly string action;

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="controller">Controller name.</param>
        /// <param name="action">Action name.</param>
        public Button(string controller, string action = "Index")
        {
            this.controller = controller;
            this.action = action;
        }

        /// <summary>
        /// Gets or sets button icon name.
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// Gets or sets button title.
        /// </summary>
        public string? Title { get; set; }

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
