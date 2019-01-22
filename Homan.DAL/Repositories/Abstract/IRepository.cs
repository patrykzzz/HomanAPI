using Homan.DAL.Entities;

namespace Homan.DAL.Repositories.Abstract
{
    public interface IRepository<T> where T : IEntity, new()
    {
        T Create();
    }
}