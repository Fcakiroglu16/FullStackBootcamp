using Microsoft.AspNetCore.Mvc;
using MVC.Web.Models;
using System.Diagnostics;
using System.Reflection;
using MVC.Web.Helpers;
using MVC.Web.Models.Products;
using MVC.Web.Models.ViewModels;

namespace MVC.Web.Controllers
{
    public class HomeController(IProductService productService, ILogger<HomeController> logger) : Controller
    {
        public IActionResult Index()
        {
            return View(productService.GetProducts());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RedirectToArticle()
        {
            var Title = "Asp.Net Core ile Gelen Yenilikler.C#_ö";
            var id = 30;

            return RedirectToAction("Index", "Article", new { title = Title.MakeSeoFriendly(), id = id });
        }

        //[Route("home/product/{productId}")]
        //[Route("[controller]/[action]/{productId}")]
        //public IActionResult GetProduct(int productId)
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}