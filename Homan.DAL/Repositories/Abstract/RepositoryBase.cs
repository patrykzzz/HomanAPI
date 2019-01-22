using System;
using Homan.DAL.Entities;

namespace Homan.DAL.Repositories.Abstract
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : IEntity, new()
    {
        public T Create()
        {
            return new T
            {
                Id = Guid.NewGuid()
            };  
        }
    }
}