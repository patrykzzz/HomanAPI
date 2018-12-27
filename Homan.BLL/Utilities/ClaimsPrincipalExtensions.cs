using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Homan.BLL.Utilities
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal claims)
        {
            var id = claims.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            return Guid.Parse(id);
        }
    }
}