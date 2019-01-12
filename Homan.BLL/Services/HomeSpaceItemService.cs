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

        public Result<HomeSpaceItemModel> CreateItem(HomeSpaceItemModel model)
        {
            try
            {
                model.Id = Guid.NewGuid();
                var entity = Mapper.Map<HomeSpaceItem>(model);
                entity.CreatedOn = DateTime.UtcNow;
                _homeSpaceItemRepository.Add(entity);
                _unitOfWork.SaveChanges();
                return Result<HomeSpaceItemModel>.Success(model);
            }
            catch (Exception ex)
            {
                return Result<HomeSpaceItemModel>.Fail();
            }
        }

        public Result UpdateItem(HomeSpaceItemModel model)
        {
            try
            {
                var entity = _homeSpaceItemRepository.Get(model.Id);
                Mapper.Map(model, entity);
                _homeSpaceItemRepository.Update(entity);
                _unitOfWork.SaveChanges();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail();
            }
        }

        public Result RemoveItem(Guid itemId)
        {
            try
            {
                _homeSpaceItemRepository.Remove(itemId);
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