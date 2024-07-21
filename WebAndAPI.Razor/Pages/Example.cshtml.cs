using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAndAPI.Razor.Pages
{
    public class ExampleModel : PageModel
    {
        public string Type { get; set; }

        public void OnGet()
        {
            Type = "OnGet";
        }

        public void OnGetWork()
        {
            Type = "OnGetWork";
        }


        public void OnGetRouteData(string name)
        {
            Type = $"OnGetRouteData- {name}";
        }

        public void OnPostWork()
        {
            Type = "OnPostWork";
        }
    }
}