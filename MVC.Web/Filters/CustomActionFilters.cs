using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Web.Filters
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("CustomActionFilter > OnActionExecuting");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("CustomActionFilter > OnActionExecuted");
        }
    }
}