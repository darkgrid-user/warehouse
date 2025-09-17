// <copyright file="LogTimeMiddleware.cs" company="Anton Hirov - Private entrepreneur">
// Copyright (c) Anton Hirov - Private entrepreneur. All rights reserved.
// </copyright>

namespace Warehouse.Middleware
{
    using System.Diagnostics;
    using Microsoft.Extensions.Options;
    using Warehouse.Middleware.I;
    using Warehouse.Middleware.Model;

    /// <summary>
    /// Measure the execution time of all middleware components
    /// and write it with additional information to the debug console.
    /// </summary>
    public class LogTimeMiddleware
    {
        private readonly RequestDelegate next;
        private readonly LogTimeOptions options;
        private readonly ILogTimeMessageProvider messageProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogTimeMiddleware"/> class.
        /// </summary>
        /// <param name="next">Next component delegate.</param>
        /// <param name="options">Middleware options.</param>
        /// <param name="messageProvider">Message provider service.</param>
        public LogTimeMiddleware(
            RequestDelegate next,
            IOptions<LogTimeOptions> options,
            ILogTimeMessageProvider messageProvider)
        {
            this.next = next;
            this.options = options.Value;
            this.messageProvider = messageProvider;
        }

        /// <summary>
        /// Execute middleware component.
        /// </summary>
        /// <param name="context">Current context.</param>
        /// <returns>Task.</returns>
        public async Task Invoke(HttpContext context)
        {
            // Pipeline start time.
            Stopwatch timer = Stopwatch.StartNew();

            // Execute other middleware components.
            await this.next(context);

            // Pipeline end time.
            timer.Stop();

            // Prepare and write a log message.
            TimeSpan executionTime = timer.Elapsed;
            string message = this.messageProvider.GetMessage(
                this.options,
                executionTime,
                context.Request);
            Debug.Write(message);
        }
    }
}
