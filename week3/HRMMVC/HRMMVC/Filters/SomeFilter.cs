using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HRMMVC.Filters
{
    public class SomeFilter : IActionFilter
    {
        private readonly ILogger<SomeFilter> _logger;
        
        public SomeFilter(ILogger<SomeFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Action Executed");
            // throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Result is ViewResult viewResult)
            {
                // here we use RedirectToActionResult to redirect to another action
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }

            _logger.LogInformation("Action Executing");
            // throw new NotImplementedException();
        }
    }
}

