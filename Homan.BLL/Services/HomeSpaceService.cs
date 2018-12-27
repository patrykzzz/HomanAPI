using System;
using System.Collections.Generic;
using AutoMapper;
using Homan.BLL.Models;
using Homan.BLL.Services.Abstract;
using Homan.BLL.Utilities;
using Homan.DAL.Entities;
using Homan.DAL.Repositories.Abstract;

namespace Homan.BLL.Services
{
    internal class HomeSpaceService : IHomeSpaceService
    {
        private readonly IHomeSpaceRepository _homeSpaceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HomeSpaceService(IHomeSpaceRepository homeSpaceRepository, IUnitOfWork unitOfWork)
        {
            _homeSpaceRepository = homeSpaceRepository;
            _unitOfWork = unitOfWork;
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

        public Result Create(HomeSpaceModel homeSpace, Guid userId)
        {
            try
            {
                var entity = Mapper.Map<HomeSpace>(homeSpace);
                entity.OwnerId = userId;
                entity.Id = Guid.NewGuid();
                _homeSpaceRepository.Add(entity);
                _unitOfWork.SaveChanges();
                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Fail();
            }
        }

        public Result<IEnumerable<HomeSpaceModel>> GetHomeSpacesByUser(Guid userId)
        {
            try
            {
                var entities = _homeSpaceRepository.GetAllByUser(userId);
                var model = Mapper.Map<IEnumerable<HomeSpaceModel>>(entities);
                return Result<IEnumerable<HomeSpaceModel>>.Success(model);
            }
            catch (Exception )
            {
                return Result<IEnumerable<HomeSpaceModel>>.Fail();
            }
        }
    }
}