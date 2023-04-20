using System;
namespace WebAPIEF.Middleware
{
	public static class ExceptionHandlerMiddleware
	{
		public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
	}
}

