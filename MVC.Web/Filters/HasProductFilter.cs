using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVC.Web.Models.Products;
using MVC.Web.Models.ViewModels;

namespace MVC.Web.Filters
{
    public class HasProductFilter(IProductService productService) : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var idAsKeyValue = context.ActionArguments.FirstOrDefault(x => x.Key == "id");

            if (idAsKeyValue.Value is null)
            {
                context.Result = new RedirectToActionResult("CustomError", "Home",
                    new CustomErrorViewModel() { Message = "Beklenmeyen bir hata meydana geldi" });
            }


            var hasProduct = productService.HasProduct((int)idAsKeyValue.Value!);
            if (!hasProduct)
            {
                context.Result = new RedirectToActionResult("CustomError", "Home",
                    new CustomErrorViewModel() { Message = "Ürün bulunamadı" });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}