using System;
using System.IdentityModel.Tokens.Jwt;
using Homan.BLL.Models;
using Homan.BLL.Services.Abstract;
using Homan.BLL.Utilities;
using Homan.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Homan.BLL.Services
{
    class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenFactory _tokenFactory;

        public UserService(UserManager<User> userManager, ITokenFactory tokenFactory)
        {
            _userManager = userManager;
            _tokenFactory = tokenFactory;
        }
        public Result Register(RegistrationRequestModel model)
        {
            try
            {
                var user = _userManager.FindByEmailAsync(model.Email).Result;
                if (user == null)
                {
                    var newUser = new User
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                    };

                    var result = _userManager.CreateAsync(newUser, model.Password).Result;

                    if (result.Succeeded)
                    {
                        return Result.Success();
                    }
                }
                return Result.Fail();
            }
            catch (Exception)
            {
                return Result.Fail();
            }
        }

        public Result<LoginResponseModel> Login(LoginRequestModel model)
        {
            try
            {
                var user = _userManager.FindByEmailAsync(model.Email)
                    .Result;
                if (user != null)
                {
                    var isPasswordCorrect = _userManager.CheckPasswordAsync(user, model.Password)
                        .Result;
                    if (isPasswordCorrect)
                    {
                        var token = new JwtSecurityTokenHandler()
                            .WriteToken(_tokenFactory.Create(user));
                        var response = new LoginResponseModel
                        {
                            UserId = user.Id,
                            Token = token,
                            Email = model.Email,
                            FirstName = user.FirstName,
                            LastName = user.LastName
                        };
                        return Result<LoginResponseModel>.Success(response);
                    }
                }
                return Result<LoginResponseModel>.Fail();
            }
            catch (Exception)
            {
                return Result<LoginResponseModel>.Fail();
            }
        }
    }
}