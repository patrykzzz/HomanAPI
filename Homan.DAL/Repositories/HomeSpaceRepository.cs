using System;
using System.Collections.Generic;
using System.Linq;
using Homan.DAL.Entities;
using Homan.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Homan.DAL.Repositories
{
    internal class HomeSpaceRepository : RepositoryBase<HomeSpace>, IHomeSpaceRepository
    {
        private readonly HomanContext _homanContext;

        public HomeSpaceRepository(HomanContext homanContext)
        {
            _homanContext = homanContext;
        }

        public HomeSpace Get(Guid id)
        {
            var homeSpace = _homanContext.HomeSpaces
                .Include(x => x.HomeSpaceItems)
                .ThenInclude(x => x.User)
                .Include(x => x.HomeSpaceUsers)
                .ThenInclude(x => x.User)
                .First(x => x.Id == id);

            homeSpace.HomeSpaceItems = homeSpace.HomeSpaceItems
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return homeSpace;
        }

        public void Add(HomeSpace homeSpace)
        {
            _homanContext.HomeSpaces.Add(homeSpace);
        }

        public void Remove(HomeSpace homeSpace)
        {
            _homanContext.HomeSpaces.Remove(homeSpace);
        }

        public IEnumerable<HomeSpace> GetAllByUser(Guid userId)
        {
            return _homanContext.HomeSpaces
                    .Include(x => x.HomeSpaceUsers)
                    .ThenInclude(x => x.User)
                    .Include(x => x.HomeSpaceItems)
                    .Where(x => x.HomeSpaceUsers.Select(y => y.UserId)
                        .Contains(userId))
                    .ToList();
        }
    }
}