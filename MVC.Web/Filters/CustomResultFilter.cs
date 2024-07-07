using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Web.Filters
{
    public class CustomResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("version-executing", "v1");
            context.Result = new ContentResult() { Content = "sayfaya erişim yok" };
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // context.HttpContext.Response.Headers.Add("version-executed", "v2");
        }
    }
}