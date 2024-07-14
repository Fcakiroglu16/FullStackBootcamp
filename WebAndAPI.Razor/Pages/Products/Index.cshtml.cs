using Microsoft.AspNetCore.Mvc;
using WebAndAPI.Razor.Services.Products;
using WebAndAPI.Razor.Services.Products.ViewModels;

namespace WebAndAPI.Razor.Pages.Products
{
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