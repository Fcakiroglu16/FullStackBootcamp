namespace MVC.Service.Identities;

public interface ITokenService
{
    ServiceResult<TokenResponseDto> GetTokenWithClientCredential(ClientCredentialRequestDto request);
}