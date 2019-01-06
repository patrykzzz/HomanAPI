using AutoMapper;
using Homan.API.Models;
using Homan.BLL.Models;
using Homan.BLL.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homan.API.Controllers
{
    public class HomeSpaceItemController : ControllerBase
    {
        private readonly IHomeSpaceItemService _homeSpaceItemService;

        public HomeSpaceItemController(IHomeSpaceItemService homeSpaceItemService)
        {
            _homeSpaceItemService = homeSpaceItemService;
        }

        /// <summary>
        /// Creates or updates specific Home Space Item
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost("api/homespaceitems")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Create([FromBody]HomeSpaceItemSaveWebModel webModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var model = Mapper.Map<HomeSpaceItemModel>(webModel);
            var result = webModel.Id.HasValue
                ? _homeSpaceItemService.UpdateItem(model)
                : _homeSpaceItemService.CreateItem(model);

            if (result.Succeeded)
            {
                return Ok();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}