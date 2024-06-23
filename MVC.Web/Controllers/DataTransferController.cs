using Microsoft.AspNetCore.Mvc;
using MVC.Web.Models;

namespace MVC.Web.Controllers
{
    public class DataTransferController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var name = "ahmet";

            var names = new List<string>() { "ahmet", "mehmet", "hasan", "ayşe" };

            ViewData["name"] = name;
            ViewData["nameList"] = names;


            var number = 10;

            var numbers = new List<int>() { 1, 2, 3, 4, 5 };


            ViewBag.number = number;

            ViewBag.numberList = numbers;
            ;
            //pullModel

            var pageModel = new IndexPageViewModel
            {
                Name = name,
                Names = names,
                Number = number,
                Numbers = numbers
            };

            //ViewData
            //ViewBag
            //TempData
            //Model
            return View(pageModel);
        }
    }
}