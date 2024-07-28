using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAndAPI.Razor.Pages.Products.Services;
using WebAndAPI.Razor.Pages.Products.ViewModels;

namespace WebAndAPI.Razor.Pages.Products
{
    [Authorize]
    public class IndexModel(ProductService productService) : BasePageModel
    {
        public List<ProductViewModel>? Products { get; set; }


        public async Task OnGetAsync()
        {
            var result = await productService.GetAllAsync();


            HasError(result);

            if (result.IsSuccess)
            {
                Products = result.Data;
            }
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var result = await productService.DeleteAsync(id);

            if (HasError(result))
            {
                return Page();
            }


            return RedirectToPage("Index");
        }
    }
}