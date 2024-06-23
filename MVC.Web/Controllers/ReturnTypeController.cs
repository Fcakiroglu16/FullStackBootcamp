using Microsoft.AspNetCore.Mvc;

namespace MVC.Web.Controllers
{
    public class ReturnTypeController : Controller
    {
        public IActionResult OnePage()
        {
            TempData["userId"] = 10;
            return View();
        }

        public IActionResult TwoPage()
        {
            return View();
        }

        public IActionResult ContentPage()
        {
            return Content("Merhaba dünya");
            //return View();
        }

        public IActionResult JsonPage()
        {
            var user = new { Name = "ahmet", Email = "ahmet@outlook.com" };

            //return new JsonResult(user);
            return Json(user);
        }

        public IActionResult EmptyPage()
        {
            return Empty;
        }
    }
}