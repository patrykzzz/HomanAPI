using System;
using System.Collections.Generic;
using Homan.DAL.Entities;

namespace Homan.DAL.Repositories.Abstract
{
    public interface IHomeSpaceRepository
    {
        HomeSpace GetById(Guid id);
        void Add(HomeSpace homeSpace);
        IEnumerable<HomeSpace> GetAllByUser(Guid userId);
    }
}