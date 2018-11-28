using System;
using AutoMapper;
using Homan.API.Models;
using Homan.BLL.Models;
using Homan.BLL.Services.Abstract;
using Homan.BLL.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homan.API.Controllers
{
    [Authorize]
    [ApiController]
    public class HomeSpaceController : ControllerBase
    {
        private readonly IHomeSpaceService _homeSpaceService;

        public HomeSpaceController(IHomeSpaceService homeSpaceService)
        {
            _homeSpaceService = homeSpaceService;
        }

        [HttpGet("api/homespaces/{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _homeSpaceService.GetHomeSpace(id);
            if (result.Succeeded)
            {
                var model = Mapper.Map<HomeSpaceWebModel>(result.Data);
                return Ok(model);
            }
            return NotFound();
        }

        [HttpGet("api/homespaces")]
        public IActionResult GetByCurrentUser()
        {
            var userId = HttpContext.User.GetUserId();
            var result = _homeSpaceService.GetHomeSpacesByUser(userId);
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }

            return BadRequest();
        }

        [HttpPost("api/homespaces")]
        public IActionResult Create([FromBody] HomeSpaceWebModel webModel)
        {
            var model = Mapper.Map<HomeSpaceModel>(webModel);
            var userId = HttpContext.User.GetUserId();
            var result = _homeSpaceService.Create(model, userId);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
