using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;
using System.Security.Principal;

namespace MVC.Repository.Identities
{
    public static class IdentityExt
    {
        public static Guid? GetUserId(this IHttpContextAccessor? contextAccessor)
        {
            if (contextAccessor is null) return null;


            if (!contextAccessor.HttpContext!.User.IsUserAuthenticated())
            {
                return null;
            }


            return Guid.Parse(contextAccessor.HttpContext!.User
                .FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value);
        }


        public static bool IsUserAuthenticated(this ClaimsPrincipal? claimsPrincipal)
        {
            if (claimsPrincipal is null) return false;

            return claimsPrincipal.HasClaim(x => x.Type == JwtRegisteredClaimNames.Name);
        }
    }
}