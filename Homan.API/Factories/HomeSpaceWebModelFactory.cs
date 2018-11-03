using Homan.API.Factories.Abstract;
using Homan.API.Models;
using Homan.BLL.Models;

namespace Homan.API.Factories
{
    public class HomeSpaceWebModelFactory : IHomeSpaceWebModelFactory
    {
        public HomeSpaceWebModel Create(HomeSpaceModel model)
        {
            return new HomeSpaceWebModel
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name
            };
        }
    }
}