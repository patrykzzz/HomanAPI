using System;
using AutoMapper;
using Homan.BLL.Models;
using Homan.BLL.Services.Abstract;
using Homan.BLL.Utilities;
using Homan.DAL.Repositories.Abstract;

namespace Homan.BLL.Services
{
    internal class HomeSpaceService : IHomeSpaceService
    {
        private readonly IHomeSpaceRepository _homeSpaceRepository;

        public HomeSpaceService(IHomeSpaceRepository homeSpaceRepository)
        {
            _homeSpaceRepository = homeSpaceRepository;
        }

        public Result<HomeSpaceModel> GetHomeSpace(Guid id)
        {
            try
            {
                var entity = _homeSpaceRepository.GetById(id);
                var model = Mapper.Map<HomeSpaceModel>(entity);
                return Result<HomeSpaceModel>.Success(model);
            }
            catch (Exception)
            {
                return Result<HomeSpaceModel>.Fail();
            }
        }
    }
}