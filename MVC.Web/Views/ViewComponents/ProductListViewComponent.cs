using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Web.Models.Products;

namespace MVC.Web.Views.ViewComponents
{
    public enum EProductListShowType
    {
        Light,
        Dark
    }

    public class ProductListViewComponent(IProductService productService) : ViewComponent
    {
        // Singleton < scoped < Transient
        //public IViewComponentResult Invoke()
        //{


        //}

        public async Task<IViewComponentResult> InvokeAsync(EProductListShowType eProductListShowType, bool IsPaging)
        {
            var productList = productService.GetProducts();

            var viewName = eProductListShowType switch
            {
                EProductListShowType.Light => "ProductListLightTable",
                EProductListShowType.Dark => "ProductListDarkTable",
                _ => "ProductListDarkTable"
            };

            //switch (eProductListShowType)
            //{
            //    case EProductListShowType.Light:
            //        viewName = "ProductListLightTable";
            //        break;

            //    case EProductListShowType.Dark:
            //        viewName = "ProductListDarkTable";
            //        break;
            //}


            return View(viewName, productList);
        }
    }
}