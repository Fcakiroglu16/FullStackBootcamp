using Microsoft.AspNetCore.Mvc;

namespace MVC.Web.Areas.Editor.Controllers
{
    [Area("Editor")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}