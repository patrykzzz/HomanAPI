using Homan.BLL.Services;
using Homan.BLL.Services.Abstract;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Homan.BLL.ChainOfResponsibility
{
    public class RefreshHomeSpaceCacheHandler : DeleteHomeSpaceItemHandler
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IHomeSpaceService _homeSpaceService;

        public RefreshHomeSpaceCacheHandler(IConnectionMultiplexer connectionMultiplexer, HomeSpaceService homeSpaceService)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _homeSpaceService = homeSpaceService;
        }

        protected override void Action(DeleteHomeSpaceItemContext context)
        {
            var database = _connectionMultiplexer.GetDatabase();
            var result = _homeSpaceService.GetHomeSpacesByUser(context.HomeSpaceUserId);
            if (result.Succeeded)
            {
                database.StringSet($"homespaces/{context.HomeSpaceUserId}", JsonConvert.SerializeObject(result));
            }
        }
    }
}