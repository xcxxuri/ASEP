using System;
using System.Net;

namespace WebAPIEF.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
    
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = httpContext.Response;
                response.ContentType = "text/plain";
                await response.WriteAsync("An unexcepted error has occured. Please try again later.");
            }
        }
	}
}

