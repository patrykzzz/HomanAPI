using System;
using Homan.BLL.Models;
using Homan.BLL.Utilities;

namespace Homan.BLL.Services.Abstract
{
    public interface IHomeSpaceItemService
    {
        Result<HomeSpaceItemModel> CreateItem(HomeSpaceItemModel model);
        Result UpdateItem(HomeSpaceItemModel model);
        Result RemoveItem(Guid itemId);
    }
}