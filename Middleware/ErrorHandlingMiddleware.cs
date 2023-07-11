using CarServiceMate.Exceptions;
using CarServiceMate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Middleware
{
    /*
     * The class that will be responsible for processing requests.
     */
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            /*
             * If ErrorHandlingMiddleware doesn't encounter an exception, the next middleware will be executed
             * The sequence of middlewares can be set in the Startup class, within the Configure method.
             */
            Stopwatch stopwatch = new Stopwatch();
            try
            {
                await next.Invoke(context);
            }
            catch(ForbidException fobidenException)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(fobidenException.Message);
            }
            catch(BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
