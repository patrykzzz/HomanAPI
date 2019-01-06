using Homan.DAL.Entities;
using Homan.DAL.Repositories.Abstract;

namespace Homan.DAL.Repositories
{
    internal class HomeSpaceItemRepository : IHomeSpaceItemRepository
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
    }
}