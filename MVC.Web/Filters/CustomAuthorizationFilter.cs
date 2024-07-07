using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace MVC.Web.Filters
{
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine("CustomAuthorizationFilter");


            // Cookie => ?
            // Header => Token
            //if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues tokens))
            //{
            //    var token = tokens.First();

            //    // validation
            //}


            //if (!context.HttpContext.Request.Cookies.TryGetValue("blog", out string value))
            //{
            //    context.Result = new RedirectToActionResult("Signin", "Auth", null);
            //}
        }
    }
}