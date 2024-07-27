using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebAndAPI.Razor.Pages.Identity.Dtos;
using WebAndAPI.Razor.Pages.Identity.ViewModels;
using WebAndAPI.Razor.Services;

namespace WebAndAPI.Razor.Pages.Identity.Services
{
    public class IdentityService(HttpClient client, IHttpContextAccessor httpContextAccessor)
    {
        public async Task<ServiceResult> SignIn(SignInViewModel request)
        {
            var response = await client.PostAsJsonAsync("/api/Identity/SignIn", request);

            var responseContent = await response.Content.ReadFromJsonAsync<ServiceResult<SignInResponseDto>>();
            if (!response.IsSuccessStatusCode)
            {
                return ServiceResult.Failure(responseContent!.Errors!);
            }

            var userModel = responseContent!.Data!;

            var claimList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userModel.UserId),
                new Claim(ClaimTypes.Name, userModel.UserName),
                new Claim(ClaimTypes.Email, userModel.Email)
            };

            claimList.AddRange(userModel.Roles.Select(role => new Claim(ClaimTypes.Role, role)));


            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimList,
                CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);


            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);


            await httpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                principal);


            //contextAccessor.HttpContext.Response.Cookies.Append("userId",responseContent.Data.UserId);
            //// Cookie
            //contextAccessor.HttpContext.Request.Cookies.TryGetValue("userId",out string userId)
            return ServiceResult.Success();
        }


        public async Task<ServiceResult> SignUp(SignUpViewModel request)
        {
            var response = await client.PostAsJsonAsync("/api/Identity/SignUp", request);


            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadFromJsonAsync<ServiceResult>();
                return ServiceResult.Failure(responseContent!.Errors!);
            }

            return ServiceResult.Success();
        }
    }
}