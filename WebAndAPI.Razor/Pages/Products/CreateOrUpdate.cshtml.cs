using Microsoft.AspNetCore.Mvc;
using WebAndAPI.Razor.Services.Products;
using WebAndAPI.Razor.Services.Products.ViewModels;

namespace WebAndAPI.Razor.Pages.Products
{
    public class CreateOrUpdateModel(ProductService productService) : BasePageModel
    {
        [BindProperty] public ProductCreateOrUpdateViewModel PageModel { get; set; } = default!;


        public bool IsUpdate { get; private set; }

        public string ButtonText => IsUpdate ? "Güncelle" : "Ekle";

        public async Task OnGetAsync(int? id)
        {
            if (!id.HasValue)
            {
                PageModel = new();
            }
            else
            {
                IsUpdate = true;
                var result = await productService.GetByIdAsync(id.Value);

                HasError(result);

                if (result.IsSuccess)
                {
                    var product = result.Data;

                    PageModel = new ProductCreateOrUpdateViewModel(id.Value, product!.Name, product.Price,
                        product.Stock);
                }
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var result = await productService.CreateOrUpdateAsync(PageModel);


            if (HasError(result))
            {
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}