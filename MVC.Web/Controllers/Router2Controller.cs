using Microsoft.AspNetCore.Mvc;

namespace MVC.Web.Controllers
{
    public class Router2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
