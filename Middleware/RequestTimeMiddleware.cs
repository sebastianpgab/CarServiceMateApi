using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await next.Invoke(context);
            stopwatch.Stop();
            
            if(stopwatch.ElapsedMilliseconds > 4000)
            {
                _logger.LogInformation("The request took more than 4 seconds");
            }
        }
    }
}
