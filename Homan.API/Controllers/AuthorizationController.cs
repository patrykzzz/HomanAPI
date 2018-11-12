using AutoMapper;
using Homan.API.Models;
using Homan.BLL.Models;
using Homan.BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Homan.API.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthorizationController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("api/register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody]RegistrationRequestWebModel webModel)
        {
            var model = Mapper.Map<RegistrationRequestModel>(webModel);
            var result = _userService.Register(model);

            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("api/login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody]LoginRequestWebModel webModel)
        {
            var model = Mapper.Map<LoginRequestModel>(webModel);
            var result = _userService.Login(model);

            if (result.Succeeded)
            {
                var response = Mapper.Map<LoginResponseWebModel>(result.Data);
                return Ok(response);
            }
            return BadRequest();
        }
    }
}