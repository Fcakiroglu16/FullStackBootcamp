using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Web.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            Console.WriteLine($"Sms Gönderildi hata:{context.Exception.Message}");
        }
    }
}