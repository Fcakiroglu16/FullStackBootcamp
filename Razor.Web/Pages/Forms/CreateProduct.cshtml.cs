using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor.Web.Models.Categories;
using Razor.Web.Models.Products;
using Razor.Web.Models.Products.ViewModels;

namespace Razor.Web.Pages.Forms
{
    public class CreateProductModel : PageModel
    {
        private ProductService productService;
        private CategoryService categoryService;


        public CreateProductModel()
        {
            productService = new ProductService();
            categoryService = new CategoryService();

            CategoryCreateViewModel = new CategoryCreateViewModel(categoryService.GetAll());
        }


        [BindProperty] public ProductCreateViewModel ProductCreateViewModel { get; set; } = new();
        [BindProperty] public CategoryCreateViewModel CategoryCreateViewModel { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            productService.Create(this);

            return RedirectToPage("ProductList");
        }
    }
}