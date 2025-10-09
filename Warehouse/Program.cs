// <copyright file="Program.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse
{
    using Microsoft.Extensions.FileProviders;
    using Warehouse.Extensions;
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

            if (builder.Environment.IsDevelopment())
            {
                // Configure custom dependency injection.
                services.AddSingleton<ILogTimeMessageProvider, LogTimeMessageProvider>();

                // Configure service options.
                IConfigurationSection options = builder
                    .Configuration
                    .GetSection("Options")
                    .GetSection("LogTime");
                builder.Services.Configure<LogTimeOptions>(options);
            }

            // Build the application.
            WebApplication app = builder.Build();
            IWebHostEnvironment env = app.Environment;

            // Configure middleware components (keep the order of statements) ↓↓↓.
            if (env.IsDevelopment())
            {
                app.UseMiddleware<LogTimeMiddleware>(); // always has to be first
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Configure static files
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider($"{env.ContentRootPath}/staticfiles"),
            });

            app.UseRouting(); // endpoint selected here
            app.UseAuthorization();

            // Configure endpoints.
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Overview}/{action=Index}/{id?}");
            app.MapFallback(async context =>
            {
                context.Response.Redirect("/");
                await Task.CompletedTask;
            });

            // Run the application.
            static string Separator(bool isTrailingNewLine)
                => StringExtensions.CreateNewLine().AddSeparator(isTrailingNewLine);
            string message = "The application is configured!!!";
            app.Logger.LogInformation(
                "{upperSeparator}{message}{lowerSeparator}",
                Separator(true),
                message,
                Separator(false));
            app.Run();
        }
    }
}
