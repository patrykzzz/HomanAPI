using System;
using Homan.API.Factories.Abstract;
using Homan.API.Models;
using Homan.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Homan.API.Controllers
{
    [ApiController]
    public class HomeSpaceController : ControllerBase
    {
        private readonly IHomeSpaceService _homeSpaceService;
        private readonly IHomeSpaceWebModelFactory _homeSpaceWebModelFactory;

        public HomeSpaceController(IHomeSpaceService homeSpaceService, IHomeSpaceWebModelFactory homeSpaceWebModelFactory)
        {
            _homeSpaceService = homeSpaceService;
            _homeSpaceWebModelFactory = homeSpaceWebModelFactory;
        }

        [HttpGet("api/homespaces/{id}")]
        public ActionResult<HomeSpaceWebModel> Get(Guid id)
        {
            var result = _homeSpaceService.GetHomeSpace(id);
            if (result.Succeeded)
            {
                return Ok(_homeSpaceWebModelFactory.Create(result.Data));
            }
            return NotFound();
        }
    }
}
