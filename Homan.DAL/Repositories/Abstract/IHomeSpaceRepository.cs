using System;
using System.Collections.Generic;
using Homan.DAL.Entities;

namespace Homan.DAL.Repositories.Abstract
{
    public interface IHomeSpaceRepository : IRepository<HomeSpace>
    {
        HomeSpace Get(Guid id);
        void Add(HomeSpace homeSpace);
        void Remove(HomeSpace homeSpace);
        IEnumerable<HomeSpace> GetAllByUser(Guid userId);
    }
}