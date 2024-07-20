using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAndAPI.Razor.Pages.Identity.Services;
using WebAndAPI.Razor.Pages.Identity.ViewModels;

namespace WebAndAPI.Razor.Pages.Identity
{
    public class SignInModel(IdentityService identityService) : PageModel
    {
        [BindProperty] public SignInViewModel Model { get; set; } = SignInViewModel.Empty();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await identityService.SignIn(Model);

            if (result.IsSuccess) return RedirectToPage("/Products/Index");


            foreach (var error in result.Errors!)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return Page();
        }
    }
}