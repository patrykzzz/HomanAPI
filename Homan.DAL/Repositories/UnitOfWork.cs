using Homan.DAL.Repositories.Abstract;

namespace Homan.DAL.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly HomanContext _homanContext;

        public UnitOfWork(HomanContext homanContext)
        {
            _homanContext = homanContext;
        }

        public void SaveChanges()
        {
            _homanContext.SaveChanges();
        }
    }
}