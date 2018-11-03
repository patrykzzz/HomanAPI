using System;
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
    }
}