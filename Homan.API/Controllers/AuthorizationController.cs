using AutoMapper;
using Homan.API.Models;
using Homan.BLL.Models;
using Homan.BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homan.API.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUserService _userService;

        public AuthorizationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("api/register")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(409)]
        [ProducesResponseType(400)]
        public IActionResult Register([FromBody]RegistrationRequestWebModel webModel)
        {
            var model = Mapper.Map<RegistrationRequestModel>(webModel);
            var result = _userService.Register(model);

            if (result == RegistrationResponseType.Ok)
            {
                return Ok();
            }

            if (result == RegistrationResponseType.EmailIsAlreadyTaken)
            {
                return Conflict();
            }
            return BadRequest();
        }

        [HttpPost("api/login")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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