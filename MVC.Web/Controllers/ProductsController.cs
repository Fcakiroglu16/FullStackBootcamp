﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Web.Filters;
using MVC.Web.Models.Categories;
using MVC.Web.Models.Products;
using MVC.Web.Models.Products.ViewModels;
using MVC.Web.Models.Services;

namespace MVC.Web.Controllers
{
    public class ProductsController(IProductService productService, ICategoryService categoryService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Create([FromServices] IProductService productServiceAsParameter)
        {
            return View(await productServiceAsParameter.LoadCreateWrapperModel());
        }


        [CustomResourceFilter]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateWrapperModel form)
        {
            if (!ModelState.IsValid)
            {
                return View(await productService.LoadCreateWrapperModel());
            }

            await productService.Create(form);
            return RedirectToAction(nameof(AllList));
        }

        //[CustomResultFilter]
        [ServiceFilter(typeof(HasProductFilter))]
        public IActionResult Update(int id)
        {
            return View(productService.GetUpdateModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateWrapperModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(productService.GetUpdateModel(model.ProductViewModel.Id));
            }


            await productService.Update(model);
            return RedirectToAction(nameof(AllList));
        }

        [HttpGet]
        public IActionResult AllList()
        {
            return View(productService.GetProducts());
        }

        [LoggingFilter]
        [ServiceFilter(typeof(HasProductFilter))]
        public IActionResult Delete(int id)
        {
            productService.Delete(id);

            return RedirectToAction(nameof(AllList));
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult HasProduct([ModelBinder(Name = "ProductViewModel.Name")] string name)
        {
            return productService.HasProduct(name.Trim().ToLower())
                ? Json("Ürün ismi veritabanında bulunmaktadır.")
                : Json(true);
        }
    }
}