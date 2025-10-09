// <copyright file="ErrorController.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Production mode error controller.
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Gets or sets the error status code.
        /// </summary>
        [ViewData]
        public required int ErrorCode { get; set; }

        /// <summary>
        /// Show error page with status code.
        /// </summary>
        /// <returns>Result view.</returns>
        public IActionResult Index()
        {
            this.ErrorCode = this.HttpContext.Response.StatusCode;
            return this.View();
        }
    }
}
