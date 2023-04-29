using System;
using System.Net;

namespace RecruitingAPI.Utility
{
    public class MiddlewareExtension
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddlewareExtension> _logger;
        public MiddlewareExtension(RequestDelegate next, ILogger<MiddlewareExtension> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {   // the _next will call the next middleware in the pipeline
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                // serilog to log the exception to text files
                // 1 await HandleExceptionAsync(httpContext, ex);


                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "text/plain";
                await httpContext.Response.WriteAsync("Aha An unexpected error has occured.");
            }
        }
        
        // here we create a method to handle the exception, in this middleware we will return a text object to the client when there is an exception
        // 1 public async Task HandleExceptionAsync(HttpContext context, Exception ex)
        // {
        //     context.Response.ContentType = "application/text";
        //     context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
        //     await context.Response.WriteAsync("StatusCode = " + context.Response.StatusCode + " Message = " + ex.Message);
        // }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<MiddlewareExtension>();

        }
    }
}

