using Microsoft.AspNetCore.Mvc;

namespace MVC.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
