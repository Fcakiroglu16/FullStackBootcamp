using MVC.Repository.Identities;

namespace MVC.Service.Identities;

public interface ITokenService
{
    ServiceResult<TokenResponseDto> GetTokenWithClientCredential(ClientCredentialRequestDto request);
    Task<ServiceResult<TokenResponseDto>> GetTokenWithResourceOwner(AppUser user, List<string> roles);
}