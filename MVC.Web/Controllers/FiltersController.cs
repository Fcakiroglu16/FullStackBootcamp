using Microsoft.AspNetCore.Mvc;
using MVC.Web.Filters;

namespace MVC.Web.Controllers
{
    public class FiltersController : Controller
    {
        [CustomAuthorizationFilter]
        [CustomActionFilter]
        [CustomExceptionFilter]
        public IActionResult Index()
        {
            throw new Exception("db hatası");
            Console.WriteLine("Index Action Method");
            return View();
        }
    }
}