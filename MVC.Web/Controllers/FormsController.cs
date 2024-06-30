using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;
using MVC.Web.Models.Categories;
using MVC.Web.Models.Products;
using MVC.Web.Models.Products.ViewModels;
using MVC.Web.Models.Services;
using MVC.Web.Models.ViewModels;

namespace MVC.Web.Controllers
{
    public class FormsController : Controller
    {
        private ProductService productService;
        private CategoryService categoryService;

        public FormsController()
        {
            productService = new ProductService();
            categoryService = new CategoryService();
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
            var categoryViewModelList = categoryService.GetAll();


            var productCreteWrapper = new ProductCreateWrapperModel();


            productCreteWrapper.CategoryViewModel.CategorySelectList =
                new SelectList(categoryViewModelList, "Id", "Name");

            return View(productCreteWrapper);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductCreateWrapperModel form)
        {
            productService.Create(form);
            return RedirectToAction(nameof(ProductList), "Forms");
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            return View(productService.GetProducts());
        }
    }
}