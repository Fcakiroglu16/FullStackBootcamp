using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using WebAndAPI.Razor.Pages.Identity.Dtos;
using WebAndAPI.Razor.Pages.Identity.ViewModels;
using WebAndAPI.Razor.Services;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WebAndAPI.Razor.Pages.Identity.Services
{
    public class IdentityService(HttpClient client, IHttpContextAccessor? httpContextAccessor)
    {
        public async Task<ServiceResult> SignIn(SignInViewModel request)
        {
            var response = await client.PostAsJsonAsync("/api/Identity/SignIn", request);

            var responseContent = await response.Content.ReadFromJsonAsync<ServiceResult<TokenResponseDto>>();
            if (!response.IsSuccessStatusCode)
            {
                return ServiceResult.Failure(responseContent!.Errors!);
            }

            var handler = new JwtSecurityTokenHandler();
            var claimsFromAccessToken = handler.ReadJwtToken(responseContent!.Data!.AccessToken);


            var claimList = claimsFromAccessToken.Claims.ToList();
            var claimAsIssuer = claimList.FirstOrDefault(x => x.Type == "iss");
            var claimAsAudience = claimList.FirstOrDefault(x => x.Type == "aud");
            if (claimAsIssuer is not null) claimList.Remove(claimAsIssuer);
            if (claimAsAudience is not null) claimList.Remove(claimAsAudience);


            var authenticationTokens = new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken, Value = responseContent.Data.AccessToken
                },
                new AuthenticationToken
                    { Name = OpenIdConnectParameterNames.RefreshToken, Value = responseContent.Data.RefreshToken },

                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = responseContent.Data.RefreshTokenExpire.ToString(CultureInfo.InvariantCulture)
                }
            };


            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimList,
                CookieAuthenticationDefaults.AuthenticationScheme, JwtRegisteredClaimNames.Name, "roles");


            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);


            AuthenticationProperties authenticationProperties = new AuthenticationProperties();

            authenticationProperties.StoreTokens(authenticationTokens);


            await httpContextAccessor?.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                principal, authenticationProperties)!;

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


        public async Task<ServiceResult> SignOutAsync()
        {
            var accessTokenAsUser =
                await httpContextAccessor?.HttpContext?.GetTokenAsync(OpenIdConnectParameterNames.AccessToken)!;


            if (accessTokenAsUser is not null)
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", accessTokenAsUser);
                var response = await client.GetAsync("/api/Identity/SignOut");
            }


            return ServiceResult.Success();
        }
    }
}