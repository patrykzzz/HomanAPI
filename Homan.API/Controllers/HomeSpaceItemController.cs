using System;
using AutoMapper;
using Homan.API.Models;
using Homan.BLL.Models;
using Homan.BLL.Services.Abstract;
using Homan.BLL.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homan.API.Controllers
{
    [Authorize]
    [ApiController]
    public class HomeSpaceItemController : ControllerBase
    {
        private readonly IServicesFacade _servicesFacade;

        public HomeSpaceItemController(IServicesFacade servicesFacade)
        {
            _servicesFacade = servicesFacade;
        }

        /// <summary>
        /// Creates Home Space Item
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost("api/homespaceitems/create")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Create([FromBody]HomeSpaceItemCreateWebModel webModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var model = Mapper.Map<HomeSpaceItemModel>(webModel);
            var result = _servicesFacade.CreateItem(model);

            if (result.Succeeded)
            {
                var data = Mapper.Map<HomeSpaceItemWebModel>(result.Data);
                return Ok(data);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Updates Home Space Item
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost("api/homespaceitems/update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Update([FromBody]HomeSpaceItemWebModel webModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var model = Mapper.Map<HomeSpaceItemModel>(webModel);
            var result = _servicesFacade.UpdateItem(model);

            if (result.Succeeded)
            {
                return Ok();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Deletes Home Space Item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpDelete("api/homespaceitems/delete/{itemId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Remove(Guid itemId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = User.GetUserId();
            var result = _servicesFacade.RemoveItem(itemId, userId);

            if (result.Succeeded)
            {
                return Ok();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}