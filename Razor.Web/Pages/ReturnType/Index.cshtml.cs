using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Web.Pages.ReturnType
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
        //public void OnGet()
        //{

        //}

        //public IActionResult OnGet()
        //{
        //    // return new ContentResult() { Content = "Merhaba Dünya" };
        //    //return new JsonResult(new { Name = "ahmet", Email = "ahmet@outlook.com" });
        //    return new EmptyResult();
        //}
    }
}