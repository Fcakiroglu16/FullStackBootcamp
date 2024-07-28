using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace MVC.Service.Identities
{
    public class IdentityHelper(IHttpContextAccessor? contextAccessor)
    {
        public Guid? GetUserIdOrDefault()
        {
            var hasUser =
                contextAccessor!.HttpContext!.User.FindFirst(x => x.Type == JwtRegisteredClaimNames.Name) is not null;
            if (contextAccessor is null || !hasUser)
            {
                return null;
            }

            return Guid.Parse(contextAccessor!.HttpContext.User
                .FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value);
        }
    }
}