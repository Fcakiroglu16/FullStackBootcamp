using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using WebAndAPI.Razor.Pages.Products.Services;
using WebAndAPI.Razor.Pages.Products.ViewModels;

namespace WebAndAPI.Razor.Pages.Products
{
    [Authorize(Roles = "editor2")]
    public class CreateOrUpdateModel(ProductService productService, IDataProtectionProvider dataProtectionProvider)
        : BasePageModel
    {
        [BindProperty] public ProductCreateOrUpdateViewModel PageModel { get; set; } = default!;


        public bool IsUpdate { get; private set; }

        public string ButtonText => IsUpdate ? "Güncelle" : "Ekle";

        public async Task OnGetAsync(string? encryptId)
        {
            //var claims = User.Claims;
            //var email = User.FindFirst(x => x.Type == ClaimTypes.Email).Value;
            //var roles = User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x=>x.Value).ToList();

            if (string.IsNullOrEmpty(encryptId))
            {
                PageModel = new();
            }
            else
            {
                var dataProtector = dataProtectionProvider.CreateProtector("abc");
                IsUpdate = true;


                int id = int.Parse(dataProtector.Unprotect(encryptId));
                var result = await productService.GetByIdAsync(id);


                HasError(result);

                if (result.IsSuccess)
                {
                    var product = result.Data;

                    PageModel = new ProductCreateOrUpdateViewModel(product!.Name, product.Price,
                        product.Stock)
                    {
                        Id = product.Id
                    };


                    PageModel.CreateEncryptId(dataProtector);
                }
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var dataProtector = dataProtectionProvider.CreateProtector("abc");
            PageModel.DecryptId(dataProtector);

            var result = await productService.CreateOrUpdateAsync(PageModel);


            if (HasError(result))
            {
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}