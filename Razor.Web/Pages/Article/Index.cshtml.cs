using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Web.Models;

namespace Razor.Web.Pages.Article
{
    public class IndexModel : PageModel
    {
        public string Title { get; set; } = default!;
        public int Id { get; set; }

        public CommonPageModel CommonPageModel { get; set; } = new();

        public void OnGet(string title, int id)
        {
            CommonPageModel.SetModel(2, "abc");
            Title = title;
            Id = id;
        }
    }
}