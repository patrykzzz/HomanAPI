using Homan.BLL.Models;
using Homan.DAL.Entities;

namespace Homan.BLL.Factories
{
    internal class HomeSpaceFactory : IHomeSpaceFactory
    {
        public HomeSpaceModel Create(HomeSpace homeSpace)
        {
            return new HomeSpaceModel
            {
                Id = homeSpace.Id,
                Name = homeSpace.Name,
                Description = homeSpace.Description
            };
        }
    }
}