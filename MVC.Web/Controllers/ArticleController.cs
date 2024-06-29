using Microsoft.AspNetCore.Mvc;

namespace MVC.Web.Controllers
{
    public class ArticleController : Controller
    {
        [Route("/makale/{title}/{id}")]
        public IActionResult Index(string title, int id)
        {
            ViewBag.title = title;
            ViewBag.id = id;

            return View();
        }
    }
}