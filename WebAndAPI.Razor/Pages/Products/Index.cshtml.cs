using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAndAPI.Razor.Services.Products;
using WebAndAPI.Razor.Services.Products.ViewModels;

namespace WebAndAPI.Razor.Pages.Producs
{
    public class IndexModel(ProductService productService) : PageModel
    {
        public List<ProductViewModel>? Products { get; set; }

        public async Task OnGetAsync()
        {
            var result = await productService.GetAllAsync();

            if (result.IsFailure)
            {
                foreach (var resultError in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, resultError);
                }
            }

            if (result.IsSuccess)
            {
                Products = result.Data;
            }
        }
    }
}