using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace WebAndAPI.Razor.Pages
{
    public class AjaxTableModel : PageModel
    {
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnGetToken()
        {
            var token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);


            return new JsonResult(new { Token = token });
        }
    }
}