// <copyright file="SettingsController.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
