using Microsoft.AspNetCore.Mvc;

namespace MVC.Web.Areas.Editor.Controllers
{
    [Area("Editor")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}