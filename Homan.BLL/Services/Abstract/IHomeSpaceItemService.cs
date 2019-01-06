using Homan.BLL.Models;
using Homan.BLL.Utilities;

namespace Homan.BLL.Services.Abstract
{
    public interface IHomeSpaceItemService
    {
        Result CreateItem(HomeSpaceItemModel model);
        Result UpdateItem(HomeSpaceItemModel model);
    }
}