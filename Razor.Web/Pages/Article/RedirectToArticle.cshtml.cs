using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Web.Pages.Article
{
    public class RedirectToArticleModel : PageModel
    {
        public IActionResult OnGet()
        {
            return RedirectToPage("Index", new { Title = "net ile gelen yenilikler", Id = 20 });
        }
    }
}