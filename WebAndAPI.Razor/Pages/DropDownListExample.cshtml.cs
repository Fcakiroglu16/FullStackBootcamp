using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAndAPI.Razor.Pages
{
    public class CommonService(HttpClient client)
    {
    }


    public class DropDownListExampleModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}