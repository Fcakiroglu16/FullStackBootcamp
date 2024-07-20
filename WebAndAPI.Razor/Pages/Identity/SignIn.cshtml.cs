using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAndAPI.Razor.Pages.Identity
{
    public class SignInModel : PageModel
    {
        [BindProperty] public SignInViewModel Model { get; set; } = SignInViewModel.Empty();

        public void OnGet()
        {
        }
    }
}