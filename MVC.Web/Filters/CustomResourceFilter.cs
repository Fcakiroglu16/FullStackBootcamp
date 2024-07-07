using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace MVC.Web.Filters
{
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (context.Result is ViewResult viewResult)
            {
                var responseModelAsJson = JsonSerializer.Serialize(viewResult.Model);
                Console.WriteLine(responseModelAsJson);
            }
        }
    }
}