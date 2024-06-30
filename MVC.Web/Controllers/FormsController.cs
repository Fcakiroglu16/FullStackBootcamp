using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;
using MVC.Web.Models.Products;
using MVC.Web.Models.Products.ViewModels;
using MVC.Web.Models.Services;

namespace MVC.Web.Controllers
{
    public class FormsController : Controller
    {
        private ProductService productService;
        private CategoryService categoryService;
        private ProductCreateWrapperModel productCreateWrapperModel;

        public FormsController()
        {
            productService = new ProductService();
            categoryService = new CategoryService();

            productCreateWrapperModel = new ProductCreateWrapperModel();
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
            productCreateWrapperModel.CategoryViewModel.CategorySelectList =
                new SelectList(categoryViewModelList, "Id", "Name");

            productCreateWrapperModel.ProductViewModel =
                new ProductCreateViewModel(productService.GetPublishDuration());


            return View(productCreateWrapperModel);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductCreateWrapperModel form)
        {
            productService.Create(form);
            return RedirectToAction(nameof(ProductList), "Forms");
        }

        public IActionResult UpdateProduct(int id)
        {
            return View(productService.GetUpdateModel(id));
        }


        [HttpGet]
        public IActionResult ProductList()
        {
            return View(productService.GetProducts());
        }


        public IActionResult Delete(int id)
        {
            productService.Delete(id);

            return RedirectToAction(nameof(ProductList));
        }
    }
}