using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Web.Pages.ReturnType
{
    public class OnePageModel : PageModel
    {
        public void OnGet()
        {
            TempData["userId"] = 20;
        }
    }
}