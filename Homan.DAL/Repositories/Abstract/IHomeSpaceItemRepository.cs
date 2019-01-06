using Homan.DAL.Entities;

namespace Homan.DAL.Repositories.Abstract
{
    public interface IHomeSpaceItemRepository
    {
        void Add(HomeSpaceItem homeSpaceItem);
        void Update(HomeSpaceItem homeSpaceItem);
    }
}