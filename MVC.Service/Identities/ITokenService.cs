using MVC.Repository.Identities;

namespace MVC.Service.Identities;

public interface ITokenService
{
    ServiceResult<TokenResponseDto> GetTokenWithClientCredentialAsync(ClientCredentialRequestDto request);
    Task<ServiceResult<TokenResponseDto>> GetTokenWithResourceOwnerAsync(AppUser user, List<string> roles);

    Task<ServiceResult> SignOutAsync();
}