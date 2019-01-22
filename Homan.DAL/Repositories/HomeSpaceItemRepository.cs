using System;
using System.Linq;
using Homan.DAL.Entities;
using Homan.DAL.Repositories.Abstract;

namespace Homan.DAL.Repositories
{
    internal class HomeSpaceItemRepository : RepositoryBase<HomeSpaceItem>, IHomeSpaceItemRepository
    {
        private readonly HomanContext _context;

        public HomeSpaceItemRepository(HomanContext context)
        {
            _context = context;
        }

        public void Add(HomeSpaceItem homeSpaceItem)
        {
            _context.HomeSpaceItems.Add(homeSpaceItem);
        }

        public void Update(HomeSpaceItem homeSpaceItem)
        {
            _context.HomeSpaceItems.Update(homeSpaceItem);
        }

        public void Remove(Guid id)
        {
            var item = _context.HomeSpaceItems.Single(x => x.Id == id);
            _context.HomeSpaceItems.Remove(item);
        }

        public HomeSpaceItem Get(Guid id)
        {
            return _context.HomeSpaceItems.Single(x => x.Id == id);
        }
    }
}