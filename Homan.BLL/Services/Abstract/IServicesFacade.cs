using System;
using System.Collections.Generic;
using Homan.BLL.Models;
using Homan.BLL.Utilities;

namespace Homan.BLL.Services.Abstract
{
    public interface IServicesFacade
    {
        RegistrationResponseType RegisterUser(RegistrationRequestModel model);
        Result<LoginResponseModel> LoginUser(LoginRequestModel model);
        Result<HomeSpaceModel> GetHomeSpace(Guid id);
        Result CreateHomeSpace(HomeSpaceModel homeSpace, Guid userId);
        Result RemoveHomeSpace(Guid homeSpaceId, Guid requestingUserId);
        Result<IEnumerable<HomeSpaceModel>> GetHomeSpacesByUser(Guid userId);
        InvitationResultModel InviteUserToHomeSpace(HomeSpaceInvitationModel model);
        Result RemoveUserFromHomeSpace(Guid homeSpaceId, Guid userToRemoveId, Guid requestingUserId);
        Result<HomeSpaceItemModel> CreateItem(HomeSpaceItemModel model);
        Result UpdateItem(HomeSpaceItemModel model);
        Result RemoveItem(Guid itemId, Guid userId);
    }
}