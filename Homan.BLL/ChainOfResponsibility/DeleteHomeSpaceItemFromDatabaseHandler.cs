using Homan.BLL.Services.Abstract;

namespace Homan.BLL.ChainOfResponsibility
{
    public class DeleteHomeSpaceItemFromDatabaseHandler : DeleteHomeSpaceItemHandler
    {
        private readonly IHomeSpaceItemService _homeSpaceItemService;

        public DeleteHomeSpaceItemFromDatabaseHandler(IHomeSpaceItemService homeSpaceItemService)
        {
            _homeSpaceItemService = homeSpaceItemService;
        }

        protected override void Action(DeleteHomeSpaceItemContext context)
        {
            _homeSpaceItemService.RemoveItem(context.HomeSpaceItemId);
        }
    }
}