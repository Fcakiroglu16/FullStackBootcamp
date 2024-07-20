using Microsoft.AspNetCore.Authorization;
using WebAndAPI.Razor.Pages.Products.Services;
using WebAndAPI.Razor.Pages.Products.ViewModels;

namespace WebAndAPI.Razor.Pages.Products
{
    public class GetModel(ProductService productService) : BasePageModel
    {
        public ProductViewModel? Product { get; set; }

        public async Task OnGetAsync(int id)
        {
            var result = await productService.GetByIdAsync(id);

            HasError(result);

            if (result.IsSuccess)
            {
                Product = result.Data;
            }
        }
    }
}