using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using WebAndAPI.Razor.Pages.Identity.Services;

namespace WebAndAPI.Razor.Pages.Identity.Handlers
{
    public class ClientCredentialHandler(TokenService tokenService) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var accessTokenResult = await tokenService.GetClientCredentialTokenAsync();

            if (accessTokenResult.IsFailure)
            {
                throw new Exception("Access token(Client Credential) elde edilemedi");
            }


            //if (!request.Headers.Contains("Authorization"))
            //{
            //    request.Headers.Add("Authorization", $"Bearer {accessTokenResult.Data}");
            //}

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessTokenResult.Data);


            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return response;
        }
    }
}