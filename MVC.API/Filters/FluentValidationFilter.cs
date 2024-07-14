using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVC.Service;

namespace MVC.API.Filters
{
    public class FluentValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

            context.Result = new BadRequestObjectResult(ServiceResult.Fail(errors, HttpStatusCode.BadRequest));
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}