using Homan.API.Models;
using Homan.BLL.Models;

namespace Homan.API.Factories.Abstract
{
    public interface IHomeSpaceWebModelFactory
    {
        HomeSpaceWebModel Create(HomeSpaceModel model);
    }
}