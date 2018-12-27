using System;
using System.Collections.Generic;
using Homan.BLL.Models;
using Homan.BLL.Utilities;

namespace Homan.BLL.Services.Abstract
{
    public interface IHomeSpaceService
    {
        Result<HomeSpaceModel> GetHomeSpace(Guid id);
        Result Create(HomeSpaceModel homeSpace, Guid userId);
        Result RemoveHomeSpace(Guid homeSpaceId, Guid requestingUserId);
        Result<IEnumerable<HomeSpaceModel>> GetHomeSpacesByUser(Guid userId);
        InvitationResultModel Invite(HomeSpaceInvitationModel model);
        Result RemoveUser(Guid homeSpaceId, Guid userToRemoveId, Guid requestingUserId);
    }
}