// <copyright file="Program.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse
{
    using Warehouse.Middleware;
    using Warehouse.Middleware.I;
    using Warehouse.Middleware.Model;

    /// <summary>
    /// ASP.NET Core application configuration.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point at startup.
        /// </summary>
        /// <param name="args">Custom arguments.</param>
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            IServiceCollection services = builder.Services;

            // Register additional services.
            services.AddControllersWithViews();

            // Configure custom dependency injection.
            services.AddSingleton<ILogTimeMessageProvider, LogTimeMessageProvider>();

            // Configure service options.
            builder.Services.Configure<LogTimeOptions>(options =>
            {
                options.HasPath = true;
                options.HasController = true;
                options.HasAction = true;
            });

            // Build the application.
            WebApplication app = builder.Build();

            // Configure middleware components (keep the order of statements) ↓↓↓.
            if (app.Environment.IsDevelopment())
            {
                app.UseMiddleware<LogTimeMiddleware>(); // always has to be first
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            // Configure endpoints.
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Overview}/{action=Index}/{id?}");

            // Run the application.
            app.Run();
        }
    }
}
