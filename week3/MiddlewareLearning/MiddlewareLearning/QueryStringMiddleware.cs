using System;
namespace MiddlewareLearning
{
    public class QueryStringMiddleware
    {
        // this is for the next method in the pipeline
        private RequestDelegate _next;

        public QueryStringMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // the Invoke is the method that will be called when the middleware is executed, we don't need to call it in the program.cs
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "text/plain";
                }
                await context.Response.WriteAsync("Class middleware \n");
            }

            // next method need to pass the context
            await _next(context);

            await context.Response.WriteAsync("On my way out From class\n");
        }

    }
}

