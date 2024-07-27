using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MVC.Service.Identities.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using MVC.Repository;
using MVC.Repository.Identities;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace MVC.Service.Identities
{
    public class TokenService(
        IOptions<ClientCredentialsOption> clientCredentialOptions,
        IOptions<TokenOption> tokenOptions,
        IGenericRepository<RefreshToken> refreshTokenRepository,
        IUnitOfWork unitOfWork) : ITokenService
    {
        public ServiceResult<TokenResponseDto> GetTokenWithClientCredential(ClientCredentialRequestDto request)
        {
            if (!clientCredentialOptions.Value.Clients.Any(x =>
                    x.Id == request.ClientId && x.Secret == request.ClientSecret))
            {
                return ServiceResult<TokenResponseDto>.Fail("ClientId veya ClientSecret hatalı",
                    HttpStatusCode.BadRequest);
            }


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Value.SignatureKey));
            var credentials =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claimList = new List<Claim> { new Claim(JwtRegisteredClaimNames.Sub, request.ClientId) };


            var jwtSecurityToken = new JwtSecurityToken(
                issuer: tokenOptions.Value.Issuer,
                audience: tokenOptions.Value.Audience,
                claims: claimList,
                expires: DateTime.Now.AddHours(Convert.ToInt32(tokenOptions.Value.ExpireAsHour)),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            var accessToken = tokenHandler.WriteToken(jwtSecurityToken);


            var response = new TokenResponseDto(accessToken, string.Empty, 0);

            return ServiceResult<TokenResponseDto>.Success(response, HttpStatusCode.OK);
        }


        public async Task<ServiceResult<TokenResponseDto>> GetTokenWithResourceOwner(AppUser user, List<string> roles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Value.SignatureKey));
            var credentials =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claimList = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName)
            };


            claimList.AddRange(roles.Select(role => new Claim("roles", role)));

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: tokenOptions.Value.Issuer,
                audience: tokenOptions.Value.Audience,
                claims: claimList,
                expires: DateTime.Now.AddHours(Convert.ToInt32(tokenOptions.Value.ExpireAsHour)),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            var accessToken = tokenHandler.WriteToken(jwtSecurityToken);


            var hasRefreshToken = refreshTokenRepository.Where(x => x.UserId == user.Id).FirstOrDefault();


            var newRefreshToken = new RefreshToken()
            {
                Token = Guid.NewGuid().ToString(),
                UserId = user.Id,
                Expire = DateTime.Now.AddHours(tokenOptions.Value.RefreshTokenExpireAsHour)
            };


            if (hasRefreshToken is not null)
            {
                hasRefreshToken.Token = newRefreshToken.Token;
                hasRefreshToken.Expire = newRefreshToken.Expire;
                refreshTokenRepository.Update(hasRefreshToken);
            }

            if (hasRefreshToken is null)
            {
                await refreshTokenRepository.Create(newRefreshToken);
            }


            await unitOfWork.CommitAsync();


            var response = new TokenResponseDto(accessToken, newRefreshToken.Token,
                ((DateTimeOffset)newRefreshToken.Expire).ToUnixTimeSeconds());

            return ServiceResult<TokenResponseDto>.Success(response, HttpStatusCode.OK);
        }
    }
}