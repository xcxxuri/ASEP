using System;
namespace InterviewAPI.Utility
{
	public class MiddlewareExtension
	{
        private readonly RequestDelegate _next;
        public MiddlewareExtension(RequestDelegate next)
        {
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
                //_logger.LogError(ex.Message);
                // serilog to log the exception to text files
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        // here we create a method to handle the exception, in this middleware we will return a text object to the client when there is an exception
        public async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/text";
            context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync("StatusCode = " + context.Response.StatusCode + " Message = " + ex.Message);
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensionExtensions
    {
        public static IApplicationBuilder UseMiddlewareExtension(this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<MiddlewareExtension>();

        }
    }
}

