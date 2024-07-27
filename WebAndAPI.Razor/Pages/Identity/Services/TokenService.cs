using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using WebAndAPI.Razor.Models;
using WebAndAPI.Razor.Pages.Identity.Dtos;
using WebAndAPI.Razor.Services;

namespace WebAndAPI.Razor.Pages.Identity.Services
{
    public class TokenService(IOptions<BackendOptions> backendOptions, HttpClient client, IMemoryCache memoryCache)
    {
        public async Task<ServiceResult<string>> GetClientCredentialTokenAsync()
        {
            if (memoryCache.TryGetValue("AccessToken", out string? value))
            {
                return ServiceResult<string>.Success(value!);
            }


            var request = new
                { ClientId = backendOptions.Value.ClientId, ClientSecret = backendOptions.Value.ClientSecret };

            var response = await client.PostAsJsonAsync("/api/Identity/SignInWithClientCredential", request);

            var responseContent = await response.Content.ReadFromJsonAsync<ServiceResult<TokenResponseDto>>();

            if (!response.IsSuccessStatusCode)
            {
                return ServiceResult<string>.Failure(responseContent!.Errors!);
            }

            var accessToken = responseContent!.Data!.AccessToken;

            memoryCache.Set("AccessToken", accessToken, TimeSpan.FromHours(1));


            return ServiceResult<string>.Success(accessToken);
        }
    }
}