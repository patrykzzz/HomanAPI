using System;
using System.Collections.Generic;
using Homan.BLL.ChainOfResponsibility;
using Homan.BLL.Models;
using Homan.BLL.Services.Abstract;
using Homan.BLL.Utilities;

namespace Homan.BLL.Services
{
    public class ServicesFacade : IServicesFacade
    {
        private readonly IHomeSpaceService _homeSpaceService;
        private readonly IUserService _userService;
        private readonly IHomeSpaceItemService _homeSpaceItemService;
        private readonly DeleteHomeSpaceItemHandler _deleteHomeSpaceItemHandler;

        public ServicesFacade(IHomeSpaceService homeSpaceService, IUserService userService, IHomeSpaceItemService homeSpaceItemService,
            DeleteHomeSpaceItemHandler deleteHomeSpaceItemHandler)
        {
            _homeSpaceService = homeSpaceService;
            _userService = userService;
            _homeSpaceItemService = homeSpaceItemService;
            _deleteHomeSpaceItemHandler = deleteHomeSpaceItemHandler;
        }

        public RegistrationResponseType RegisterUser(RegistrationRequestModel model)
        {
            return _userService.Register(model);
        }

        public Result<LoginResponseModel> LoginUser(LoginRequestModel model)
        {
            return _userService.Login(model);
        }

        public Result<HomeSpaceModel> GetHomeSpace(Guid id)
        {
            return _homeSpaceService.GetHomeSpace(id);
        }

        public Result CreateHomeSpace(HomeSpaceModel homeSpace, Guid userId)
        {
            return _homeSpaceService.Create(homeSpace, userId);
        }

        public Result RemoveHomeSpace(Guid homeSpaceId, Guid requestingUserId)
        {
            return _homeSpaceService.RemoveHomeSpace(homeSpaceId, requestingUserId);
        }

        public Result<IEnumerable<HomeSpaceModel>> GetHomeSpacesByUser(Guid userId)
        {
            return _homeSpaceService.GetHomeSpacesByUser(userId);
        }

        public InvitationResultModel InviteUserToHomeSpace(HomeSpaceInvitationModel model)
        {
            return _homeSpaceService.Invite(model);
        }

        public Result RemoveUserFromHomeSpace(Guid homeSpaceId, Guid userToRemoveId, Guid requestingUserId)
        {
            return _homeSpaceService.RemoveUser(homeSpaceId, userToRemoveId, requestingUserId);
        }

        public Result<HomeSpaceItemModel> CreateItem(HomeSpaceItemModel model)
        {
            return _homeSpaceItemService.CreateItem(model);
        }

        public Result UpdateItem(HomeSpaceItemModel model)
        {
            return _homeSpaceItemService.UpdateItem(model);
        }

        public Result RemoveItem(Guid itemId, Guid userId)
        {
            try
            {
                var context = new DeleteHomeSpaceItemContext
                {
                    HomeSpaceItemId = itemId,
                    HomeSpaceUserId = userId
                };
                _deleteHomeSpaceItemHandler.Handle(context);
                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Fail();
            }
        }
    }
}