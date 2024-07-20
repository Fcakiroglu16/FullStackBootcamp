using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAndAPI.Razor.Pages.Identity
{
    public class SignUpModel : PageModel
    {
        [BindProperty] public SignUpViewModel Model { get; set; } = SignUpViewModel.Empty();


        public void OnGet()
        {
        }
    }
}