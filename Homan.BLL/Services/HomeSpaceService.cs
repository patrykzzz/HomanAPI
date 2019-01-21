using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Homan.BLL.Models;
using Homan.BLL.Services.Abstract;
using Homan.BLL.Utilities;
using Homan.DAL.Entities;
using Homan.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Homan.BLL.Services
{
    public class HomeSpaceService : IHomeSpaceService
    {
        private readonly IHomeSpaceRepository _homeSpaceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public HomeSpaceService(IHomeSpaceRepository homeSpaceRepository, IUnitOfWork unitOfWork,
            UserManager<User> userManager)
        {
            _homeSpaceRepository = homeSpaceRepository;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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
                entity.HomeSpaceUsers = new List<UserInHomeSpace>
                {
                    new UserInHomeSpace
                    {
                        UserId = userId
                    }
                };

                _homeSpaceRepository.Add(entity);
                _unitOfWork.SaveChanges();
                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Fail();
            }
        }

        public Result RemoveHomeSpace(Guid homeSpaceId, Guid requestingUserId)
        {
            try
            {
                var homeSpace = _homeSpaceRepository.GetById(homeSpaceId);
                if(homeSpace.OwnerId != requestingUserId)
                {
                    return Result.Fail();
                }
                _homeSpaceRepository.Remove(homeSpace);
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
            catch (Exception)
            {
                return Result<IEnumerable<HomeSpaceModel>>.Fail();
            }
        }

        public InvitationResultModel Invite(HomeSpaceInvitationModel model)
        {
            try
            {
                var homeSpace = _homeSpaceRepository.GetAllByUser(model.InvitingUserId)
                    .SingleOrDefault(x => x.Id == model.HomeSpaceId);
                var user = _userManager.FindByEmailAsync(model.UserEmail)
                    .Result;
                if (user == null)
                {
                    return InvitationResultModel.NoUserFound;
                }

                if (homeSpace != null)
                {
                    if (homeSpace.HomeSpaceUsers.Select(x => x.User).Contains(user) || homeSpace.OwnerId == user.Id)
                    {
                        return InvitationResultModel.UserAlreadyInHomeSpace;
                    }
                    homeSpace.HomeSpaceUsers.Add(new UserInHomeSpace
                    {
                        UserId = user.Id
                    });
                    _unitOfWork.SaveChanges();
                    return InvitationResultModel.Succeeded;
                }
                return InvitationResultModel.Failed;
            }
            catch (Exception)
            {
                return InvitationResultModel.Failed;
            }
        }

        public Result RemoveUser(Guid homeSpaceId, Guid userToRemoveId, Guid requestingUserId)
        {
            try
            {
                var homeSpace = _homeSpaceRepository.GetById(homeSpaceId);
                if (homeSpace.OwnerId != requestingUserId)
                {
                    return Result.Fail();
                }

                if (userToRemoveId == requestingUserId)
                {
                    return Result.Fail();
                }

                var user = homeSpace.HomeSpaceUsers.Single(x => x.UserId == userToRemoveId);
                homeSpace.HomeSpaceUsers.Remove(user);
                _unitOfWork.SaveChanges();
                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Fail();
            }
        }
    }
}