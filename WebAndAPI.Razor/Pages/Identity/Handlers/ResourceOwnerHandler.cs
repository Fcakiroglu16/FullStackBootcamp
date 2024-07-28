using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using WebAndAPI.Razor.Pages.Identity.Services;

namespace WebAndAPI.Razor.Pages.Identity.Handlers
{
    public class ResourceOwnerHandler(IHttpContextAccessor contextAccessor) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.Headers.Contains("Authorization"))
            {
                return await base.SendAsync(request, cancellationToken);
            }


            var token = await contextAccessor?.HttpContext?.GetTokenAsync(OpenIdConnectParameterNames.AccessToken)!;

            if (token is null)
            {
                throw new UnauthorizedAccessException();
            }


            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);


            return await base.SendAsync(request, cancellationToken);
        }
    }
}