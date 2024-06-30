using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Web.Models.Products;
using Razor.Web.Models.Products.ViewModels;

namespace Razor.Web.Pages.Forms
{
    public class ProductListModel : PageModel
    {
        private ProductService productService;

        public ProductListModel()
        {
            this.productService = new ProductService();
        }

        public List<ProductViewModel> ProductViewModels { get; set; }

        public void OnGet()
        {
            ProductViewModels = productService.GetProducts();
        }
    }
}