// <copyright file="IncomeController.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class IncomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
