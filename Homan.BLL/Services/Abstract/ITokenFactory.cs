using Homan.DAL.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace Homan.BLL.Services.Abstract
{
    public interface ITokenFactory
    {
        JwtSecurityToken Create(User user);
    }
}