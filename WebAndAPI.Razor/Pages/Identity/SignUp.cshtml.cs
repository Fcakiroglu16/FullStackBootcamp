using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAndAPI.Razor.Pages.Identity.Services;
using WebAndAPI.Razor.Pages.Identity.ViewModels;

namespace WebAndAPI.Razor.Pages.Identity
{
    public class SignUpModel(IdentityService identityService) : PageModel
    {
        [BindProperty] public SignUpViewModel Model { get; set; } = SignUpViewModel.Empty();


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await identityService.SignUp(Model);

            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return Page();
            }

            return RedirectToPage("SignIn");
        }
    }
}