using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.JsonWebTokens;
using WebAndAPI.Razor.Pages.Identity.Services;
using WebAndAPI.Razor.Pages.Identity.ViewModels;

namespace WebAndAPI.Razor.Pages.Identity
{
    public class SignInModel(IdentityService identityService) : PageModel
    {
        [BindProperty] public SignInViewModel Model { get; set; } = new SignInViewModel(); //SignInViewModel.Empty();

        public IActionResult OnGet()
        {
            if (User.Identity!.IsAuthenticated)
            {
                var userId = User.FindFirst(x => x.Type == JwtRegisteredClaimNames.Sub)!.Value;
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await identityService.SignIn(Model);

            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return Page();
            }


            return RedirectToPage("/Products/Index");
        }


        public async Task<IActionResult> OnGetLogOut(int id)
        {
            await HttpContext.SignOutAsync();


            return RedirectToPage("/Index");
            //log out
        }

        public async Task<IActionResult> OnPostLogOut()
        {
            await HttpContext.SignOutAsync();


            return RedirectToPage("/Index");
            //log out
        }
    }
}