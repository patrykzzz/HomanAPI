using System;
using Homan.BLL.Models;
using Homan.BLL.Utilities;

namespace Homan.BLL.Services.Abstract
{
    public interface IHomeSpaceService
    {
        Result<HomeSpaceModel> GetHomeSpace(Guid id);
    }
}