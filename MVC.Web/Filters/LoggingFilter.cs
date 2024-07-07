using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Web.Filters
{
    public class LoggingFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = context.RouteData.Values["Controller"];
            var actionName = context.RouteData.Values["Action"];
            Console.WriteLine($"Controller: {controllerName}, Action: {actionName}");
            foreach (var arg in context.ActionArguments)
            {
                Console.WriteLine($"Parameter Key: {arg.Key}= Parameter Value: {arg.Value}");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}