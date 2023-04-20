using System;
namespace HRMMVC.Middleware
{
	public static class ExceptionHandlerMiddleware
	{
		public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
	}
}

