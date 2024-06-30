using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MVC.Web.Models;
using MVC.Web.Models.Repositories;

namespace MVC.Web.Controllers
{
    public class FormsController : Controller
    {
        private ProductService productService;

        public FormsController()
        {
            productService = new ProductService();
        }

        [HttpGet]
        public IActionResult FormExample1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormExample1Post()
        {
            #region 1.way

            string firstName = Request.Form["firstName"]!;
            string lastName = Request.Form["lastName"]!;
            string age = Request.Form["age"]!;

            #endregion

            #region 2. way

            if (Request.Form.TryGetValue("firstName", out StringValues firstNameValue))
            {
            }

            #endregion

            #region 3. way

            if (Request.Form.ContainsKey("firstName"))
            {
                string firstName2 = Request.Form["firstName"]!;
            }

            #endregion


            return View();
        }


        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductCreateWrapperModel form)
        {
            productService.Create(form);
            return RedirectToAction(nameof(ProductList));
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            return View(productService.GetProducts());
        }
    }
}