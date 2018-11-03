using System;
using Homan.DAL.Entities;

namespace Homan.DAL.Repositories.Abstract
{
    public interface IHomeSpaceRepository
    {
        HomeSpace GetById(Guid id);
    }
}