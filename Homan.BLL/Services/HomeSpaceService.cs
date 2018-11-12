using System;
using Homan.BLL.Factories;
using Homan.BLL.Models;
using Homan.BLL.Services.Abstract;
using Homan.BLL.Utilities;
using Homan.DAL.Repositories.Abstract;

namespace Homan.BLL.Services
{
    internal class HomeSpaceService : IHomeSpaceService
    {
        private readonly IHomeSpaceRepository _homeSpaceRepository;
        private readonly IHomeSpaceFactory _homeSpaceFactory;

        public HomeSpaceService(IHomeSpaceRepository homeSpaceRepository, IHomeSpaceFactory homeSpaceFactory)
        {
            _homeSpaceRepository = homeSpaceRepository;
            _homeSpaceFactory = homeSpaceFactory;
        }

        public Result<HomeSpaceModel> GetHomeSpace(Guid id)
        {
            try
            {
                var entity = _homeSpaceRepository.GetById(id);
                var model = _homeSpaceFactory.Create(entity);
                return Result<HomeSpaceModel>.Success(model);
            }
            catch (Exception)
            {
                return Result<HomeSpaceModel>.Fail();
            }
        }
    }
}