using System;
using System.Collections.Generic;
using Homan.BLL.Models;
using Homan.BLL.Services;
using Homan.BLL.Services.Abstract;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Homan.BLL.Utilities
{
    public class HomeSpaceServiceCacheDecorator : CacheDecoratorBase<HomeSpaceService>, IHomeSpaceService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public HomeSpaceServiceCacheDecorator(IConnectionMultiplexer connectionMultiplexer, HomeSpaceService homeSpaceService) : base(homeSpaceService)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public Result<HomeSpaceModel> GetHomeSpace(Guid id)
        {
            return _target.GetHomeSpace(id);
        }

        public Result Create(HomeSpaceModel homeSpace, Guid userId)
        {
            return _target.Create(homeSpace, userId);
        }

        public Result RemoveHomeSpace(Guid homeSpaceId, Guid requestingUserId)
        {
            try
            {
                var database = _connectionMultiplexer.GetDatabase();
                database.KeyDelete($"homespaces/{requestingUserId}");
                return _target.RemoveHomeSpace(homeSpaceId, requestingUserId);
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
                var database = _connectionMultiplexer.GetDatabase();
                var cacheResult = database.StringGet($"homespaces/{userId}");
                if (cacheResult.HasValue)
                {
                    return JsonConvert.DeserializeObject<Result<IEnumerable<HomeSpaceModel>>>(cacheResult);
                }
                var result = _target.GetHomeSpacesByUser(userId);
                database.StringSet($"homespaces/{userId}", JsonConvert.SerializeObject(result));
                return result;
            }
            catch (Exception)
            {
                return Result<IEnumerable<HomeSpaceModel>>.Fail();
            }
        }

        public InvitationResultModel Invite(HomeSpaceInvitationModel model)
        {
            return _target.Invite(model);
        }

        public Result RemoveUser(Guid homeSpaceId, Guid userToRemoveId, Guid requestingUserId)
        {
            return _target.RemoveUser(homeSpaceId, userToRemoveId, requestingUserId);
        }
    }
}