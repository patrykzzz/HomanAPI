using System;
using AutoMapper;
using Homan.BLL.Models;
using Homan.BLL.Services.Abstract;
using Homan.BLL.Utilities;
using Homan.DAL.Entities;
using Homan.DAL.Repositories.Abstract;

namespace Homan.BLL.Services
{
    internal class HomeSpaceItemService : IHomeSpaceItemService
    {
        private readonly IHomeSpaceItemRepository _homeSpaceItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HomeSpaceItemService(IHomeSpaceItemRepository homeSpaceItemRepository, IUnitOfWork unitOfWork)
        {
            _homeSpaceItemRepository = homeSpaceItemRepository;
            _unitOfWork = unitOfWork;
        }

        public Result CreateItem(HomeSpaceItemModel model)
        {
            try
            {
                var entity = Mapper.Map<HomeSpaceItem>(model);
                _homeSpaceItemRepository.Add(entity);
                _unitOfWork.SaveChanges();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail();
            }
        }

        public Result UpdateItem(HomeSpaceItemModel model)
        {
            try
            {
                var entity = Mapper.Map<HomeSpaceItem>(model);
                _homeSpaceItemRepository.Update(entity);
                _unitOfWork.SaveChanges();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail();
            }
        }
    }
}