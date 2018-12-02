﻿using System;
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

        /// <summary>
        /// Gets a Home Space by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("api/homespaces/{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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

        /// <summary>
        /// Gets all Home Spaces by current user
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/homespaces")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
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

        /// <summary>
        /// Creates a Home Space by current user
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost("api/homespaces")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
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
