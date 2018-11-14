using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Homan.BLL.Services.Abstract;
using Homan.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Homan.BLL.Services
{
    internal class TokenFactory : ITokenFactory
    {
        private readonly IConfiguration _configuration;

        public TokenFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtSecurityToken Create(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()), 
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authorization:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(_configuration["Authorization:Issuer"], _configuration["Authorization:Audience"],
                claims, expires: DateTime.Now.AddDays(7), signingCredentials:credentials);
        }
    }
}