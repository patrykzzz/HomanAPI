using System;
using AutoMapper;
using Homan.API.Models;
using Homan.BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homan.API.Controllers
{
    [ApiController]
    public class HomeSpaceController : ControllerBase
    {
        private readonly IHomeSpaceService _homeSpaceService;

        public HomeSpaceController(IHomeSpaceService homeSpaceService)
        {
            _homeSpaceService = homeSpaceService;
        }

        [Authorize]
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
    }
}
