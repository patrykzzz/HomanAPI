using System;
using System.Collections.Generic;
using System.Linq;
using Homan.DAL.Entities;
using Homan.DAL.Repositories.Abstract;

namespace Homan.DAL.Repositories
{
    internal class HomeSpaceRepository : IHomeSpaceRepository
    {
        private readonly HomanContext _homanContext;

        public HomeSpaceRepository(HomanContext homanContext)
        {
            _homanContext = homanContext;
        }

        public HomeSpace GetById(Guid id)
        {
            return _homanContext.HomeSpaces
                .First(x => x.Id == id);
        }

        public void Add(HomeSpace homeSpace)
        {
            _homanContext.HomeSpaces.Add(homeSpace);
        }

        public IEnumerable<HomeSpace> GetAllByUser(Guid userId)
        {
            var joinedHomeSpaces =
                _homanContext.HomeSpaces.Where(x => x.HomeSpaceUsers.Select(y => y.UserId)
                    .Contains(userId));
            return _homanContext.HomeSpaces.Where(x => x.OwnerId == userId)
                .Union(joinedHomeSpaces)
                .ToList();
        }
    }
}