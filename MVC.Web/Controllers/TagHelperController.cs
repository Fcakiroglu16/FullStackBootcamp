using Microsoft.AspNetCore.Mvc;

namespace MVC.Web.Controllers
{
    public class TagHelperController : Controller
    {
        public IActionResult Index()
        {
            var imageUrl = "/images/car.jpg";


            var path = imageUrl.Split(".");

            var thumbnailUrl = $"{path[0]}250x250.{path[1]}";


            ViewBag.imageUrl = imageUrl;
            ViewBag.thumbnailUrl = thumbnailUrl;
            return View();
        }
    }
}