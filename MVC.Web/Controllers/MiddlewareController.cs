using System.CodeDom;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Web.Controllers
{
    public class MiddlewareController : Controller
    {
        public IActionResult Index()
        {
            Debug.WriteLine("Debug Kodu : index methodu çalıştı");
            return View();
        }
    }
}