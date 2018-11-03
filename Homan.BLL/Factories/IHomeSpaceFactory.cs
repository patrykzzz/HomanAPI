using Homan.BLL.Models;
using Homan.DAL.Entities;

namespace Homan.BLL.Factories
{
    public interface IHomeSpaceFactory
    {
        HomeSpaceModel Create(HomeSpace homeSpace);
    }
}